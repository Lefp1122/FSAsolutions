namespace FSAsolutions
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.Label lblClientName;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblDatabaseName = new Label();
            lblClientName = new Label();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            Cuenta = new DataGridViewTextBoxColumn();
            Nombre_de_Cuenta = new DataGridViewTextBoxColumn();
            btnPegar_Cuentas = new Button();
            btnExportar_Cuenta = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // lblDatabaseName
            // 
            lblDatabaseName.AutoSize = true;
            lblDatabaseName.Location = new Point(13, 22);
            lblDatabaseName.Name = "lblDatabaseName";
            lblDatabaseName.Size = new Size(108, 15);
            lblDatabaseName.TabIndex = 0;
            lblDatabaseName.Text = "Selected Database: ";
            // 
            // lblClientName
            // 
            lblClientName.AutoSize = true;
            lblClientName.Location = new Point(13, 50);
            lblClientName.Name = "lblClientName";
            lblClientName.Size = new Size(79, 15);
            lblClientName.TabIndex = 1;
            lblClientName.Text = "Client Name: ";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(38, 117);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(225, 267);
            dataGridView1.TabIndex = 2;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Cuenta, Nombre_de_Cuenta });
            dataGridView2.Location = new Point(282, 117);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(493, 267);
            dataGridView2.TabIndex = 3;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // Cuenta
            // 
            Cuenta.Frozen = true;
            Cuenta.HeaderText = "Cuenta";
            Cuenta.Name = "Cuenta";
            Cuenta.ReadOnly = true;
            // 
            // Nombre_de_Cuenta
            // 
            Nombre_de_Cuenta.Frozen = true;
            Nombre_de_Cuenta.HeaderText = "Nombre de Cuenta";
            Nombre_de_Cuenta.Name = "Nombre_de_Cuenta";
            Nombre_de_Cuenta.ReadOnly = true;
            // 
            // btnPegar_Cuentas
            // 
            btnPegar_Cuentas.Location = new Point(282, 77);
            btnPegar_Cuentas.Name = "btnPegar_Cuentas";
            btnPegar_Cuentas.Size = new Size(75, 23);
            btnPegar_Cuentas.TabIndex = 4;
            btnPegar_Cuentas.Text = "Pegar";
            btnPegar_Cuentas.UseVisualStyleBackColor = true;
            btnPegar_Cuentas.Click += btnPegar_Cuentas_Click;
            // 
            // btnExportar_Cuenta
            // 
            btnExportar_Cuenta.Location = new Point(693, 390);
            btnExportar_Cuenta.Name = "btnExportar_Cuenta";
            btnExportar_Cuenta.Size = new Size(82, 24);
            btnExportar_Cuenta.TabIndex = 5;
            btnExportar_Cuenta.Text = "Exportar";
            btnExportar_Cuenta.UseVisualStyleBackColor = true;
            btnExportar_Cuenta.Click += btnExportar_Cuenta_Click;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportar_Cuenta);
            Controls.Add(btnPegar_Cuentas);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(lblDatabaseName);
            Controls.Add(lblClientName);
            Name = "Form6";
            Text = "Cuentas NUevas";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn Cuenta;
        private DataGridViewTextBoxColumn Nombre_de_Cuenta;
        private Button btnPegar_Cuentas;
        private Button btnExportar_Cuenta;
    }
}