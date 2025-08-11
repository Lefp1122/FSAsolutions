using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using ClosedXML.Excel;
using System.Web;
using DocumentFormat.OpenXml;

namespace FSAsolutions
{
    public partial class Form5 : Form
    {
        private string _databaseName;
        private string _clientName;
        private string _connection;


        public Form5(string databaseName, string clientName, string connection)
        {
            InitializeComponent();

            _databaseName = databaseName;
            _clientName = clientName;
            _connection = connection;

            // Set the values in the labels or other controls
            lblDatabaseName.Text = $"Base de datos seleccionada: {_databaseName}";
            lblClientName.Text = $"Nombre de cliente: {_clientName}";

            string fecha = _databaseName.Length >= 4
            ? _databaseName.Substring(_databaseName.Length - 4)
            : _databaseName;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private async void Form5_Load(object sender, EventArgs e)
        {
            await LoadCatalog();
            InitializeDataGridView3();


        }
        private void buscarCuenta_Click(object sender, EventArgs e)
        {

        }

        private async Task LoadData(string cuenta)
        {
            try
            {


                string cmd = $@"with numero_movimiento as ( select distinct
                                    [cpotipo], [cporefere1] AS numero
	                                      
                                    FROM [{_databaseName}].[dbo].[B2UNIPOL] 
                                     WHERE [CUENUMERO] IN ({cuenta}))
  
                                     Select  a.[CPOTIPO] as Tipo ,
                                            b.[CUENUMERO] as Cuenta, 
                                            c.[CUEDESCRI] as Descripcion
	                                ,sum(case when b.[CPOMOVIM] = 1 then b.[CPOIMPORTE] else 0 end) as Debito
	                                ,sum(case when b.[CPOMOVIM] = 2 then b.[CPOIMPORTE] else 0 end) as Credito
	                                 from numero_movimiento as a
	                                inner join [{_databaseName}].[dbo].[B2UNIPOL] as b on a.numero = b.[CPOREFERE1]
	                                left join [{_databaseName}].[dbo].[B9CATCUE] as c on b.[CUENUMERO] = c.[CUENUMERO]
	                                where a.numero is not null

	                                Group by 
	                            b.[CUENUMERO]
	                            ,c.[CUEDESCRI]
                                , a.[CPOTIPO] 
	                            order by a.CPOTIPO, b.[CUENUMERO] asc";


                using (SqlConnection conn = new SqlConnection(_connection))
                {
                    await conn.OpenAsync();


                    dataGridView1.DataSource = null;


                    var result = (await conn.QueryAsync(cmd)).Distinct().ToList();

                    dataGridView1.AutoGenerateColumns = false;  // Disable automatic column generation
                    dataGridView1.Columns.Clear();


                    // Toma las columnas del primer articulo
                    foreach (var item in result[0])
                    {
                        dataGridView1.Columns.Add(item.Key, item.Key);
                    }

                    //Ahora si inserta las filas y calcula los totales
                    Dictionary<string, TipoSummary> tipoSums = new Dictionary<string, TipoSummary>();

                    string previousTipo = null;

                    foreach (var item in result)
                    {
                        string tipo = item.Tipo.ToString();
                        decimal debito = Convert.ToDecimal(item.Debito);
                        decimal credito = Convert.ToDecimal(item.Credito);

                        // Check if 'Tipo' has changed
                        if (previousTipo != null && tipo != previousTipo)
                        {
                            // Add summary row for the previous 'Tipo'
                            var summaryRow = new DataGridViewRow();
                            summaryRow.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                            summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = $"Total for {previousTipo}" });
                            summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                            summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                            summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = tipoSums[previousTipo].Debito });
                            summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = tipoSums[previousTipo].Credito });


                            dataGridView1.Rows.Add(summaryRow);
                        }

                        // Update sums for the current 'Tipo'
                        if (!tipoSums.ContainsKey(tipo))
                        {
                            tipoSums[tipo] = new TipoSummary { Debito = 0, Credito = 0 };
                        }

                        tipoSums[tipo].Debito += debito;
                        tipoSums[tipo].Credito += credito;

                        // Add the current row
                        var row = new DataGridViewRow();
                        int currentCol = 1;
                        foreach (var col in item)
                        {

                            if (currentCol >= 4)
                            {
                                decimal? decimalValue = col.Value != null
                                ? Convert.ToDecimal(col.Value)
                                : (decimal?)null;

                                row.Cells.Add(new DataGridViewTextBoxCell { Value = decimalValue });
                            }
                            else
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = col.Value?.ToString() });

                            currentCol += 1;
                        }
                        dataGridView1.Rows.Add(row);

                        // Update the previous 'Tipo'
                        previousTipo = tipo;
                    }

                    // Add a summary row for the last 'Tipo'
                    if (previousTipo != null)
                    {
                        var summaryRow = new DataGridViewRow();
                        summaryRow.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                        summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = $"Total for {previousTipo}" });
                        summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                        summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                        summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = tipoSums[previousTipo].Debito });
                        summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = tipoSums[previousTipo].Credito });





                        dataGridView1.Rows.Add(summaryRow);
                    }

                    // Resize columns 
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }

                // dataGridView1.DataSource = result;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }


        }
        private async Task LoadCatalog()
        {
            try
            {
                // Connection string to attach the .mdf file dynamically
                

                string cmd = $@"Select[CUENUMERO] as Cuenta,[CUEDESCRI] as Descripcion from [{_databaseName}].[dbo].[B9CATCUE]";

                using (SqlConnection conn = new SqlConnection(_connection))
                {
                    await conn.OpenAsync();

                    dataGridView2.DataSource = null;

                    var result = (await conn.QueryAsync<dynamic>(cmd)).Distinct().ToList();
                    dataGridView2.AutoGenerateColumns = false;  // Disable automatic column generation
                    dataGridView2.Columns.Clear();
                                      
                    dataGridView2.Columns.Add("Cuenta", "Cuenta");
                    dataGridView2.Columns.Add("Descripcion", "Descripción");


                    foreach (var item in result)
                    {
                        dataGridView2.Rows.Add(item.Cuenta, item.Descripcion);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void ReorganizeCatalog()
        {
            try
            {
                dataGridView2.Sort(dataGridView2.Columns["Cuenta"], ListSortDirection.Ascending);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reorganizing Grid2: {ex.Message}");
            }
        }
        private void ExportToExcel(DataGridView dataGridView, string file, string nombre, string fecha)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add($"cruce de {nombre}");

                    int currentRow = 1;

                    using (var ms = new MemoryStream())
                    {
                        Properties.Resources.MyLogo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        ms.Seek(0, SeekOrigin.Begin);

                        // Insert the logo
                        var logoImage = worksheet.AddPicture(ms)
                            .MoveTo(worksheet.Cell(currentRow, 1)) // Position the image
                            .WithSize(200, 100); // Resize the image 
                        currentRow += 3;
                    }

                    // title row
                    worksheet.Cell(currentRow, 1).Value = "Cruce entre Cuentas"; // Title text
                    worksheet.Range(currentRow, 1, currentRow, dataGridView.Columns.Count).Merge(); // Merge cells for title row
                    worksheet.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                    worksheet.Cell(currentRow, 1).Style.Font.FontSize = 16;
                    currentRow++;

                    //empty row
                    currentRow++;

                    //  "Nombre de Cliente" row
                    worksheet.Cell(currentRow++, 1).Value = $"Nombre de Cliente: {_clientName}";

                    //  "Cruce" row
                    worksheet.Cell(currentRow++, 1).Value = $"Cruce: {nombre_cruce.Text.Trim()}";

                    //  "Fecha" row
                    worksheet.Cell(currentRow++, 1).Value = $"Fecha: {fecha}";

                    // empty row
                    currentRow++;


                    //Header
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        worksheet.Cell(currentRow, i + 1).Value = dataGridView.Columns[i].HeaderText;
                        worksheet.Cell(currentRow, i + 1).Style.Font.Bold = true;
                        worksheet.Cell(currentRow, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                        worksheet.Cell(currentRow, i + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    }

                    currentRow++;
                    //Rows

                    for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                    {
                        if (!dataGridView.Rows[i].IsNewRow)
                        {
                            for (int j = 0; j < dataGridView.Columns.Count; j++)
                            {
                                var cellValue = dataGridView.Rows[i].Cells[j].Value;
                                if (cellValue != null)
                                {
                                    var cell = worksheet.Cell(currentRow, j + 1);

                                    // Apply format based on column type
                                    if (cellValue is decimal || cellValue is double || cellValue is float)
                                    {


                                        cell.Style.NumberFormat.Format = "#,##0.00";
                                        cell.Value = Convert.ToDecimal(cellValue);
                                    }
                                    else
                                    {

                                        cell.Value = cellValue.ToString();
                                    }



                                }
                            }
                            currentRow++;
                        }
                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(file);
                    }
                    MessageBox.Show($"{file} generado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exportando data: {ex.Message}");
            }
        }

        private void InitializeDataGridView3()
        {
            // Clear existing columns (if any)
            dataGridView3.Columns.Clear();

            // Add predefined columns with specific names and types
            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cuenta", HeaderText = "Cuenta" });
            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn { Name = "Descripcion", HeaderText = "Descripcion" });





        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string cruce = nombre_cruce.Text.Trim();

            string fecha = _databaseName.Length >= 4
            ? _databaseName.Substring(_databaseName.Length - 4)
            : _databaseName;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
            sfd.FileName = $"Cruce de {cruce} {_clientName} {fecha}.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(dataGridView1, sfd.FileName, cruce, fecha);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row from dataGridView2
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

                // Create a new row for dataGridView3
                DataGridViewRow newRow = (DataGridViewRow)selectedRow.Clone();

                // Copy all cell values from the selected row to the new row
                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    newRow.Cells[i].Value = selectedRow.Cells[i].Value;
                }

                // Add the new row to dataGridView3
                dataGridView3.Rows.Add(newRow);

                // Optionally remove the row from dataGridView2
                dataGridView2.Rows.RemoveAt(e.RowIndex);
            }
        }




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure a valid row index is clicked
            if (e.RowIndex >= 0)
            {
                // Get the selected row from dataGridView3
                DataGridViewRow selectedRow = dataGridView3.Rows[e.RowIndex];

                // Create a new row for dataGridView2
                DataGridViewRow newRow = (DataGridViewRow)selectedRow.Clone();

                // Copy all cell values from the selected row to the new row
                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    newRow.Cells[i].Value = selectedRow.Cells[i].Value;
                }

                // Add the new row to dataGridView2
                dataGridView2.Rows.Add(newRow);

                // Optionally remove the row from dataGridView3
                dataGridView3.Rows.RemoveAt(e.RowIndex);
            }

            ReorganizeCatalog();
        }

        private void Visualize_Click(object sender, EventArgs e)
        {
            try
            {
                // Collect 'Cuenta' values from dataGridView3 into a list
                List<string> cuentaList = new List<string>();

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Cells["Cuenta"].Value != null) // Ensure the cell is not null
                    {
                        string cuentaValue = row.Cells["Cuenta"].Value.ToString();
                        cuentaList.Add(cuentaValue);
                    }
                }

                // Join the 'Cuenta' values into a comma-separated string for the query
                string cuentasForQuery = string.Join(",", cuentaList.Select(c => $"'{c}'"));

                LoadData(cuentasForQuery);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task LoadSumaria(int maestro)
        {
            try
            {
                RemoveAllGrid3();

                // Example query to fetch data for GridView3
                
                string query = $@"SELECT DISTINCT CUENUMERO as Cuenta, CUEDESCRI as Descripcion FROM [{_databaseName}].[dbo].[B9CATCUE] WHERE INDNUMERO = {maestro}";

                // Retrieve data for GridView3
                List<string> cuentasToMove = new List<string>();

                using (SqlConnection conn = new SqlConnection(_connection))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cuentasToMove.Add(reader["Cuenta"].ToString());
                            }
                        }
                    }
                }

                // Ensure there is data to match
                if (cuentasToMove.Count == 0)
                {
                    MessageBox.Show("No matching data found for transfer.");
                    return;
                }

                // Iterate through dataGridView2 and move matching rows to dataGridView3
                for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView2.Rows[i];
                    if (row.IsNewRow) continue; // Skip the uncommitted new row

                    // Check if the "Cuenta" column matches any criteria
                    string cuentaValue = row.Cells["Cuenta"].Value?.ToString();
                    if (cuentasToMove.Contains(cuentaValue))
                    {
                        // Add the row to dataGridView3
                        int newRowIdx = dataGridView3.Rows.Add();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dataGridView3.Rows[newRowIdx].Cells[cell.ColumnIndex].Value = cell.Value;
                        }

                        // Remove the row from dataGridView2
                        dataGridView2.Rows.RemoveAt(i);
                    }
                }

                ReorganizeCatalog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void RemoveAllGrid3()
        {
            for (int i = dataGridView3.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dataGridView3.Rows[i];
                if (row.IsNewRow) continue;

                // Add the row to dataGridView2
                int newRowIdx = dataGridView2.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dataGridView2.Rows[newRowIdx].Cells[cell.ColumnIndex].Value = cell.Value;
                }

                // Remove the row from dataGridView3
                dataGridView3.Rows.RemoveAt(i);
            }
        }

        private void removegrid3_Click(object sender, EventArgs e)
        {
            RemoveAllGrid3();
            ReorganizeCatalog();
        }
        private async void Inventario_Button_Click(object sender, EventArgs e)
        {
            int maestro = 11040;
            await LoadSumaria(maestro);

        }


        private async void depreciacion_Click(object sender, EventArgs e)
        {
            int maestro = 11070;
            await LoadSumaria(maestro);
        }

        private async void ingresos_Click(object sender, EventArgs e)
        {
            int maestro = 21020;
            await LoadSumaria(maestro);
        }

        

        private async void dif_Camb_Click(object sender, EventArgs e)
        {
            int maestro = 25010;
            await LoadSumaria(maestro);
        }

        public class TipoSummary
        {
            public decimal Debito { get; set; }
            public decimal Credito { get; set; }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
