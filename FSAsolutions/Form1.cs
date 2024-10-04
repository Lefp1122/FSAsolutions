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
using static System.Net.WebRequestMethods;

namespace FSAsolutions
{
    public partial class Form1 : Form
    {
        private Form2 _form2Instance;

        public Form1()
        {
            InitializeComponent();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load the last directory from settings
            string lastDirectory = Properties.Settings.Default.LastDirectory;

            if (!string.IsNullOrEmpty(lastDirectory) && Directory.Exists(lastDirectory))
            {
                // Automatically load the databases from the last selected directory
                LoadDatabases(lastDirectory);
            }
        }
        private void LoadDatabases(string folderPath)
        {
            try
            {
                // Get all .mdf files in the folder and all subfolders
                string[] databaseFiles = Directory.GetFiles(folderPath, "*.mdf", SearchOption.AllDirectories);

                // Create a DataTable to hold the file info
                DataTable table = new DataTable();
                table.Columns.Add("Database Name", typeof(string));
                table.Columns.Add("Nombre del Cliente", typeof(string));

                //Eliminates unsolicited databases
                var filteredFiles = databaseFiles.Where(file =>
            !file.EndsWith("mail.mdf", StringComparison.OrdinalIgnoreCase) &&
            !file.EndsWith("general.mdf", StringComparison.OrdinalIgnoreCase));

                // Add each database to the DataTable
                foreach (string filePath in filteredFiles)
                {
                    DataRow row = table.NewRow();
                    row["Database Name"] = Path.GetFileNameWithoutExtension(filePath);
                    string DBNAME = Path.GetFileNameWithoutExtension(filePath).ToLower();

                      var dbInfo = GetDatabaseInformation(filePath);
                        if (dbInfo != null)
                        {
                            row["Nombre del Cliente"] = dbInfo.SISNOMBRE;

                        }
                        else
                        {
                            row["Nombre del Cliente"] = "N/A";

                        }
                   
                    

                    table.Rows.Add(row);
                }

                // Bind the DataTable to the DataGridView
                dataGridView1.DataSource = table;
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle case where access to certain directories is denied
                MessageBox.Show($"Access Denied: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle any other errors that may occur
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private DatabaseInfo GetDatabaseInformation(string mdfFilePath)
        {
            try
            {
                string newDatabase = Path.GetFileNameWithoutExtension(mdfFilePath);
                // Connection string to attach the .mdf file dynamically
                string connectionString = $@"Server=(local)\CAME2017;Database={newDatabase};Integrated Security=True;";

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Query to get the number of tables in the database
                    string cmd = $@"SELECT [SISNOMBRE] FROM [{newDatabase}].[dbo].[B2CATEMP]";
                    string nombreDeCliente = conn.QuerySingleOrDefault<string>(cmd);



                    // Return the database info
                    return new DatabaseInfo
                    {
                        SISNOMBRE = nombreDeCliente,
                        
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to retrieve information from {mdfFilePath}: {ex.Message}");
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderDialog.SelectedPath;

                    // Save the selected directory path in the settings
                    Properties.Settings.Default.LastDirectory = folderPath;
                    Properties.Settings.Default.Save();

                    // Load databases from the selected folder
                    LoadDatabases(folderPath);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string lastDirectory = Properties.Settings.Default.LastDirectory;

            if (!string.IsNullOrEmpty(lastDirectory) && Directory.Exists(lastDirectory))
            {
                // Refresh the databases from the last selected directory
                LoadDatabases(lastDirectory);
            }
            else
            {
                MessageBox.Show("No directory selected yet. Please select a directory first.", "Error");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked row is valid
            if (e.RowIndex >= 0)
            {
                // Get the clicked row
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Retrieve the database name and full path from the row
                string databaseName = row.Cells["Database Name"].Value.ToString();
                string clientName = row.Cells["Nombre del Cliente"].Value.ToString();

                // Example action: Show a message with the selected database info
                //MessageBox.Show($"Selected Database: {databaseName}\nClient: {clientName}", "Database Selected");

                // You can also open the file, or perform any other actions here
                if (_form2Instance == null || _form2Instance.IsDisposed)
                {
                    // Create and show Form2 if it's not already open
                    _form2Instance = new Form2(databaseName, clientName);
                    _form2Instance.Show();
                    this.Enabled = false;

                    _form2Instance.FormClosed += (s, args) => this.Enabled = true;
                }
                else
                {
                    // If Form2 is already open, bring it to the front
                    _form2Instance.BringToFront();
                }
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();  // Ensure settings are saved when the form closes
        }

      
    }
    public class DatabaseInfo
    {
        public string SISNOMBRE{ get; set; }
    }
}
