namespace FSAsolutions
{
    partial class Form4
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
            this.Header = new System.Windows.Forms.Label();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.pegarBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.movimientosGrid = new System.Windows.Forms.DataGridView();
            this.exportarBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.movimientosGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.Location = new System.Drawing.Point(531, 9);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(211, 25);
            this.Header.TabIndex = 0;
            this.Header.Text = "Insertar Movimientos";
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Location = new System.Drawing.Point(13, 49);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(104, 13);
            this.lblDatabaseName.TabIndex = 0;
            this.lblDatabaseName.Text = "Selected Database: ";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(13, 71);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(70, 13);
            this.lblClientName.TabIndex = 1;
            this.lblClientName.Text = "Client Name: ";
            // 
            // pegarBtn
            // 
            this.pegarBtn.Location = new System.Drawing.Point(123, 104);
            this.pegarBtn.Name = "pegarBtn";
            this.pegarBtn.Size = new System.Drawing.Size(75, 23);
            this.pegarBtn.TabIndex = 4;
            this.pegarBtn.Text = "Pegar";
            this.pegarBtn.UseVisualStyleBackColor = true;
            this.pegarBtn.Click += new System.EventHandler(this.pegarBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pegar codigo aqui:";
            // 
            // movimientosGrid
            // 
            this.movimientosGrid.AllowUserToDeleteRows = false;
            this.movimientosGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.movimientosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.movimientosGrid.Location = new System.Drawing.Point(24, 149);
            this.movimientosGrid.Name = "movimientosGrid";
            this.movimientosGrid.ReadOnly = true;
            this.movimientosGrid.Size = new System.Drawing.Size(1196, 430);
            this.movimientosGrid.TabIndex = 6;
            // 
            // exportarBtn
            // 
            this.exportarBtn.Location = new System.Drawing.Point(1145, 622);
            this.exportarBtn.Name = "exportarBtn";
            this.exportarBtn.Size = new System.Drawing.Size(75, 23);
            this.exportarBtn.TabIndex = 7;
            this.exportarBtn.Text = "Exportar";
            this.exportarBtn.UseVisualStyleBackColor = true;
            this.exportarBtn.Click += new System.EventHandler(this.exportarBtn_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 668);
            this.Controls.Add(this.exportarBtn);
            this.Controls.Add(this.movimientosGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pegarBtn);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.lblDatabaseName);
            this.Controls.Add(this.lblClientName);
            this.Name = "Form4";
            this.Text = "Insertar Movimientos";
            ((System.ComponentModel.ISupportInitialize)(this.movimientosGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.Button pegarBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView movimientosGrid;
        private System.Windows.Forms.Button exportarBtn;
    }
}