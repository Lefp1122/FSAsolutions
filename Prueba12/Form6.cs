using Dapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace FSAsolutions
{
    public partial class Form6 : Form
    {
        private string _databaseName;
        private string _clientName;
        private string _connection;

        public Form6(string databaseName, string clientName, string connection)
        {
            InitializeComponent();

            _databaseName = databaseName;
            _clientName = clientName;
            _connection = connection;

            // Set the values in the labels or other controls
            lblDatabaseName.Text = $"Base de datos seleccionada: {_databaseName}";
            lblClientName.Text = $"Nombre de cliente: {_clientName}";

            Load += Form6_Load;
        }

        private async void Form6_Load(object sender, EventArgs e)
        {
            await cuentasFaltantes();
        }
        private async Task cuentasFaltantes()
        {
            try
            {
                string cmd = $@"WITH mayor AS( SELECT DISTINCT cuenumero AS cuentas
                            FROM [{_databaseName}].[dbo].[b2unipol])
                            SELECT a.cuentas
                            FROM mayor AS a
                            LEFT JOIN[{_databaseName}].[dbo].[B9CATCUE] AS b
                            ON a.cuentas = b.CUENUMERO
                            WHERE b.CUENUMERO IS NULL;";

                using (SqlConnection conn = new SqlConnection(_connection))
                {
                    await conn.OpenAsync();


                    dataGridView1.DataSource = null;


                    var result = await conn.QueryAsync<string>(cmd);

                    dataGridView1.AutoGenerateColumns = false;  // Disable automatic column generation
                    dataGridView1.Columns.Clear();

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Cuentas", typeof(string));


                    foreach (var item in result)
                    {
                        dataTable.Rows.Add(item);
                    }

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Cuentas",
                        HeaderText = "Cuentas",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    });


                    dataGridView1.DataSource = dataTable;



                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPegar_Cuentas_Click(object sender, EventArgs e)
        {
            try
            {

                string clipboardText = Clipboard.GetText();

                // Split the clipboard text into rows
                string[] rows = clipboardText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                // Clear existing rows and columns in DataGridView
                dataGridView2.Rows.Clear();


                if (rows.Length > 0)
                {

                    for (int i = 0; i < rows.Length; i++)
                    {
                        string[] cells = rows[i].Split('\t');
                        dataGridView2.Rows.Add(cells);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error pegando las cuentas: " + ex.Message);
            }
        }

        private async void btnExportar_Cuenta_Click(object sender, EventArgs e)
        {
            try
            {
                string comando = $@"INSERT INTO [{_databaseName}].[dbo].[B9CATCUE] (CUENUMERO, CUEDESCRI, CUENIVEL)         
VALUES ";

                for (int i = 1; i < dataGridView2.Rows.Count - 1; i++)
                {

                    string nuevaCuenta = "(";

                    if (!dataGridView2.Rows[i].IsNewRow)
                    {
                        for (int j = 0; j < dataGridView2.Columns.Count; j++)
                        {
                            var cellValue = dataGridView2.Rows[i].Cells[j].Value;

                            nuevaCuenta += "'" + cellValue.ToString() + "',";
                        }

                        nuevaCuenta += " 1),";
                            
                    }

                    comando += nuevaCuenta;

                }
                comando = comando.Substring(0, comando.Length - 1) + ";";

                await ExportarCuenta(comando);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error cargardo cuentas: " + ex.Message);
            }
        }

        private async Task ExportarCuenta(string cmd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connection))
                {
                    await conn.OpenAsync();

                    int rowsAffected = await conn.ExecuteAsync(cmd);

                    MessageBox.Show($"Se han agregado {rowsAffected} cuentas");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando cuentas: " + ex.Message);
            }
        }
    }
}
