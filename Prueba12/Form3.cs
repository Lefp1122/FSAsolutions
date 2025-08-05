using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSAsolutions
{
    public partial class Form3 : Form
    {
        private string _databaseName;
        private string _clientName;
        private string _connection;

        private Form5 _form5Instance;
        private Form4 _form4Instance;
        private Form6 _form6Instance;
        public Form3(string databaseName, string clientName)
        {
            InitializeComponent();

            _databaseName = databaseName;
            _clientName = clientName;
            _connection = $@"Server=(local)\CAME2017;Database={_databaseName};Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

            // Set the values in the labels or other controls
            lblDatabaseName.Text = $"Base de datos seleccionada: {_databaseName}";
            lblClientName.Text = $"Nombre de cliente: {_clientName}";

            string fecha = _databaseName.Length >= 4
            ? _databaseName.Substring(_databaseName.Length - 4)
            : _databaseName;
        }

        private void cruce_cuentas_Click(object sender, EventArgs e)
        {




            // You can also open the file, or perform any other actions here
            if (_form5Instance == null || _form5Instance.IsDisposed)
            {

                _form5Instance = new Form5(_databaseName, _clientName, _connection);
                _form5Instance.Show();
                this.Enabled = false;

                _form5Instance.FormClosed += (s, args) => this.Enabled = true;
            }
            else
            {
                // If Form2 is already open, bring it to the front
                _form5Instance.BringToFront();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void mov_insert_Click(object sender, EventArgs e)
        {
            if (_form4Instance == null || _form4Instance.IsDisposed)
            {

                _form4Instance = new Form4(_databaseName, _clientName, _connection);
                _form4Instance.Show();
                this.Enabled = false;

                _form4Instance.FormClosed += (s, args) => this.Enabled = true;
            }
            else
            {

                _form4Instance.BringToFront();
            }
        }

        private void cuentas_nuevas_Click(object sender, EventArgs e)
        {
            if (_form6Instance == null || _form6Instance.IsDisposed)
            {

                _form6Instance = new Form6(_databaseName, _clientName, _connection);
                _form6Instance.Show();
                this.Enabled = false;

                _form6Instance.FormClosed += (s, args) => this.Enabled = true;
            }
            else
            {

                _form6Instance.BringToFront();
            }
        }
    }
}
