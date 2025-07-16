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

        private Form2 _form2Instance;
        private Form4 _form4Instance;
        public Form3 (string databaseName, string clientName)
        {
            InitializeComponent();

            _databaseName = databaseName;
            _clientName = clientName;

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
            if (_form2Instance == null || _form2Instance.IsDisposed)
            {
               
                _form2Instance = new Form2(_databaseName, _clientName);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void mov_insert_Click(object sender, EventArgs e)
        {
            if (_form4Instance == null || _form4Instance.IsDisposed)
            {

                _form4Instance = new Form4(_databaseName, _clientName);
                _form4Instance.Show();
                this.Enabled = false;

                _form4Instance.FormClosed += (s, args) => this.Enabled = true;
            }
            else
            {
                // If Form2 is already open, bring it to the front
                _form4Instance.BringToFront();
            }
        }
    }
}
