using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using ClosedXML.Excel;

namespace FSAsolutions
{
    public partial class Form2 : Form
    {
        private string _databaseName;
        private string _clientName;
        public Form2(string databaseName, string clientName)
        {
            InitializeComponent();

            _databaseName = databaseName;
            _clientName = clientName;

            // Set the values in the labels or other controls
            lblDatabaseName.Text = $"Base de datos seleccionada: {_databaseName}";
            lblClientName.Text = $"Nombre de cliente: {_clientName}";
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void buscarCuenta_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {

                // Connection string to attach the .mdf file dynamically
                string connectionString = $@"Server=(local)\CAME2017;Database={_databaseName};Integrated Security=True;";

                string cuenta = numeroDeCuenta.Text.Trim();
                
                    string cmd = $@"with numero_movimiento as ( select 
                                    [cpotipo],[cuenumero], [cponumero],
	                                case when [CUENUMERO] = @Cuenta then [CPONUMERO] else null end as numero
      
                                    FROM [{_databaseName}].[dbo].[B2UNIPOL] )
  
                                     Select DISTINCT a.[CPOTIPO] as Tipo , b.[CueNUMERO] as Cuenta, c.[CUEDESCRI] as Descipcion
	                                ,sum(case when b.[CPOMOVIM] = 1 then b.[CPOIMPORTE] else 0 end) as Debito
	                                ,sum(case when b.[CPOMOVIM] = 2 then b.[CPOIMPORTE] else 0 end) as Credito
	                                 from numero_movimiento as a
	                                   left join [{_databaseName}].[dbo].[B2UNIPOL] as b on a.numero = b.[CPONUMERO]
	                                left join [{_databaseName}].[dbo].[B9CATCUE] as c on b.[CUENUMERO] = c.[CUENUMERO]
	                                where a.numero is not null

	                                Group by 
	                            b.[CUENUMERO]
	                            ,c.[CUEDESCRI]
                                , a.[CPOTIPO] 
	                            order by a.CPOTIPO asc";
                

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();


                    dataGridView1.DataSource = null;


                    var result = conn.Query(cmd, new {Cuenta = cuenta}).Distinct().ToList();

                    dataGridView1.DataSource = result;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }

        }
        private void ExportToExcel(DataGridView dataGridView, string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("DataGridView Export");

                    //Header
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dataGridView.Columns[i].HeaderText;
                    }

                    //Rows

                    for (int i = 0; i < dataGridView.Rows.Count - 1 ; i++)
                    {
                        if (!dataGridView.Rows[i].IsNewRow)
                        {
                            for (int j = 0; j < dataGridView.Columns.Count; j++)
                            {
                                var cellValue = dataGridView.Rows[i].Cells[j].Value;
                                if (cellValue != null)
                                    worksheet.Cell(i + 2, j + 1).Value = dataGridView.Rows[i].Cells[j].Value?.ToString();

                            }
                        }
                    }

                    workbook.SaveAs(filePath);
                }
                MessageBox.Show("La tabla ha sido exportada satisfactoriamente a Excel");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exportando data: {ex.Message}");
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
            sfd.FileName = "DataExport.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(dataGridView1, sfd.FileName);
            }
        }
    }
}
