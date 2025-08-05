using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using DocumentFormat.OpenXml.Office.Word;
using Dapper;
using Microsoft.Data.SqlClient;

using static FSAsolutions.Form2;

namespace FSAsolutions
{
    public partial class Form4 : Form
    {
        private string _databaseName;
        private string _clientName;
        private string _connection;

        private string insertQuery;
        public Form4(string databaseName, string clientName, string connection)
        {
            InitializeComponent();

            _databaseName = databaseName;
            _clientName = clientName;
            _connection = connection;

            lblDatabaseName.Text = $"Base de datos seleccionada: {_databaseName}";
            lblClientName.Text = $"Nombre de cliente: {_clientName}";

            movimientosGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void pegarBtn_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                // Clear existing text and paste from clipboard

                insertQuery = Clipboard.GetText();



                movimientosGrid.DataSource = null;

                movimientosGrid.AutoGenerateColumns = false;
                movimientosGrid.Columns.Clear();

                visualizacion(insertQuery);

            }
            else
                MessageBox.Show("No hay texto que pegar.");

        }

        private void visualizacion(string query)
        {
            try
            {
                var lines = query.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var valuesOnly = string.Join("\n", lines.Skip(2));

               
                                string cmd = $@"set dateformat ymd;
                                CREATE TABLE #TempAjustes ( 
                                TIPO VARCHAR(10),
                                NUMERO INT,
                                FECHA DATETIME,
                                CUENTA VARCHAR(20),
                                CONCEP NVARCHAR(255),
                                IMPORTE DECIMAL(18,2),
                                MOVIM INT
                                );

                                INSERT INTO #TempAjustes (TIPO, NUMERO, FECHA, CUENTA, CONCEP, IMPORTE, MOVIM)
                                VALUES {valuesOnly} 

                    SELECT TIPO, NUMERO, FECHA, CUENTA, CONCEP ,(case when [MOVIM] = 1 then [IMPORTE] else 0 end) as Debito
	                                ,(case when [MOVIM] = 2 then [IMPORTE] else 0 end) as Credito FROM #TempAjustes"


                 ;


                using (IDbConnection conn = new SqlConnection(_connection))
                {
                    conn.Open();


                    movimientosGrid.DataSource = null;


                    var result = conn.Query(cmd).Distinct().ToList();

                    movimientosGrid.AutoGenerateColumns = false;
                    movimientosGrid.Columns.Clear();


                    // Toma las columnas del primer articulo
                    foreach (var item in result[0])
                    {
                        movimientosGrid.Columns.Add(item.Key, item.Key);
                    }

                    Dictionary<string, TipoSummary> tipoSums = new Dictionary<string, TipoSummary>();

                    string previousKey = null;


                    foreach (var item in result)
                    {
                        string tipo = item.TIPO.ToString();
                        int numero = item.NUMERO;
                        decimal debito = Convert.ToDecimal(item.Debito);
                        decimal credito = Convert.ToDecimal(item.Credito);
                        string key = $"{tipo}_{numero}";


                        if (previousKey != null && key != previousKey)
                        {
                            // Add summary row for the previous 'Tipo'
                            var summaryRow = new DataGridViewRow();
                            summaryRow.DefaultCellStyle.Font = new Font(movimientosGrid.Font, FontStyle.Bold);
                            summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = $"Total for {previousKey}" });
                            summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                            summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = "" });

                            summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                            summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = tipoSums[previousKey].Debito - tipoSums[previousKey].Credito });
                            summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = tipoSums[previousKey].Debito });
                            summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = tipoSums[previousKey].Credito });


                            movimientosGrid.Rows.Add(summaryRow);
                        }

                        // Update sums for the current 'Tipo'

                        if (!tipoSums.ContainsKey(key))
                        {
                            tipoSums[key] = new TipoSummary { Debito = 0, Credito = 0 };
                        }

                        tipoSums[key].Debito += debito;
                        tipoSums[key].Credito += credito;

                        // Add the current row
                        var row = new DataGridViewRow();
                        int currentCol = 1;
                        foreach (var col in item)
                        {

                            if (currentCol >= 6)
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
                        movimientosGrid.Rows.Add(row);

                        // Update the previous 'Tipo'
                        previousKey = key;
                    }

                    // Add a summary row for the last 'Tipo'
                    if (previousKey != null)
                    {
                        var summaryRow = new DataGridViewRow();
                        summaryRow.DefaultCellStyle.Font = new Font(movimientosGrid.Font, FontStyle.Bold);
                        summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = $"Total for {previousKey}" });
                        summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                        summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                        summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                        summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = tipoSums[previousKey].Debito - tipoSums[previousKey].Credito });
                        summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = tipoSums[previousKey].Debito });
                        summaryRow.Cells.Add(new DataGridViewTextBoxCell { Value = tipoSums[previousKey].Credito });





                        movimientosGrid.Rows.Add(summaryRow);

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void exportarBtn_Click(object sender, EventArgs e)
        {
            if (insertQuery != null)
            {
                exportarQuery(insertQuery);
            }
            else
                MessageBox.Show("No hay Informacion para exportar");
        }

        private void exportarQuery(string query)
        {
            try
            {
                var lines = query.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var valuesOnly = string.Join("\n", lines.Skip(2));
                                                
                string cmdText = $@"set dateformat ymd; 

                            CREATE TABLE #StagingB2UNIPOL (
                            CPOTIPO NVARCHAR(10),
                            CPONUMERO INT,
                            CPOFECHA DATETIME,
                            CUENUMERO NVARCHAR(20),
                            CPOCONCEP NVARCHAR(255),
                            CPOIMPORTE DECIMAL(18,2),
                            CPOMOVIM INT
                            );
                            INSERT INTO #StagingB2UNIPOL (CPOTIPO, CPONUMERO, CPOFECHA, CUENUMERO, CPOCONCEP, CPOIMPORTE, CPOMOVIM) Values {valuesOnly}

                            INSERT INTO [{_databaseName}].[dbo].[B2UNIPOL] (CPOTIPO, CPONUMERO, CPOFECHA, CUENUMERO, CPOCONCEP, CPOIMPORTE, CPOMOVIM)
                            SELECT s.CPOTIPO, s.CPONUMERO, s.CPOFECHA, s.CUENUMERO, s.CPOCONCEP, s.CPOIMPORTE, s.CPOMOVIM
                            FROM #StagingB2UNIPOL s
                            WHERE NOT EXISTS (
                                SELECT 1
                                FROM [AUD0012024].[dbo].[B2UNIPOL] b
                                WHERE b.CPOTIPO = s.CPOTIPO
                                  AND b.CPONUMERO = s.CPONUMERO
                                  AND b.CUENUMERO = s.CUENUMERO)

                                ";


                using (IDbConnection conn = new SqlConnection(_connection))
                {
                    conn.Open();

                    using (IDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = cmdText;
                        cmd.CommandType = CommandType.Text;

                        int rowsInserted = cmd.ExecuteNonQuery();
                        MessageBox.Show($"Se insertaron los ajustes correctamente. \n" +
                            $"Se cerrara esta ventana.");

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }

}
