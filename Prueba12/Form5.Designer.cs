namespace FSAsolutions
{
    partial class Form5
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
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Catalogo_Cuentas = new System.Windows.Forms.Label();
            this.Seleccion = new System.Windows.Forms.Label();
            this.Cruce_cuentas = new System.Windows.Forms.Label();
            this.Visualize = new System.Windows.Forms.Button();
            this.removegrid3 = new System.Windows.Forms.Button();
            this.Inventario_Button = new System.Windows.Forms.Button();
            this.depreciacion = new System.Windows.Forms.Button();
            this.dif_Camb = new System.Windows.Forms.Button();
            this.ingresos = new System.Windows.Forms.Button();
            this.nombre_cruce = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Location = new System.Drawing.Point(13, 22);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(104, 13);
            this.lblDatabaseName.TabIndex = 0;
            this.lblDatabaseName.Text = "Selected Database: ";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(13, 50);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(70, 13);
            this.lblClientName.TabIndex = 1;
            this.lblClientName.Text = "Client Name: ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(691, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(590, 378);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(469, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cruce de Cuentas";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(1162, 584);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(113, 23);
            this.btnExportExcel.TabIndex = 7;
            this.btnExportExcel.Text = "Exporta a Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(16, 101);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(304, 506);
            this.dataGridView2.TabIndex = 8;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(356, 101);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(300, 357);
            this.dataGridView3.TabIndex = 9;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            this.dataGridView3.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // Catalogo_Cuentas
            // 
            this.Catalogo_Cuentas.AutoSize = true;
            this.Catalogo_Cuentas.Location = new System.Drawing.Point(122, 72);
            this.Catalogo_Cuentas.Name = "Catalogo_Cuentas";
            this.Catalogo_Cuentas.Size = new System.Drawing.Size(106, 13);
            this.Catalogo_Cuentas.TabIndex = 10;
            this.Catalogo_Cuentas.Text = "Catalogo de Cuentas";
            // 
            // Seleccion
            // 
            this.Seleccion.AutoSize = true;
            this.Seleccion.Location = new System.Drawing.Point(462, 72);
            this.Seleccion.Name = "Seleccion";
            this.Seleccion.Size = new System.Drawing.Size(54, 13);
            this.Seleccion.TabIndex = 11;
            this.Seleccion.Text = "Seleccion";
            // 
            // Cruce_cuentas
            // 
            this.Cruce_cuentas.AutoSize = true;
            this.Cruce_cuentas.Location = new System.Drawing.Point(700, 72);
            this.Cruce_cuentas.Name = "Cruce_cuentas";
            this.Cruce_cuentas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cruce_cuentas.Size = new System.Drawing.Size(92, 13);
            this.Cruce_cuentas.TabIndex = 14;
            this.Cruce_cuentas.Text = "Cruce de Cuentas";
            // 
            // Visualize
            // 
            this.Visualize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Visualize.Location = new System.Drawing.Point(1162, 495);
            this.Visualize.Name = "Visualize";
            this.Visualize.Size = new System.Drawing.Size(113, 23);
            this.Visualize.TabIndex = 16;
            this.Visualize.Text = "Visualizar Cruce";
            this.Visualize.UseVisualStyleBackColor = true;
            this.Visualize.Click += new System.EventHandler(this.Visualize_Click);
            // 
            // removegrid3
            // 
            this.removegrid3.Location = new System.Drawing.Point(555, 464);
            this.removegrid3.Name = "removegrid3";
            this.removegrid3.Size = new System.Drawing.Size(75, 23);
            this.removegrid3.TabIndex = 17;
            this.removegrid3.Text = "Eliminar todo";
            this.removegrid3.UseVisualStyleBackColor = true;
            this.removegrid3.Click += new System.EventHandler(this.removegrid3_Click);
            // 
            // Inventario_Button
            // 
            this.Inventario_Button.Location = new System.Drawing.Point(356, 464);
            this.Inventario_Button.Name = "Inventario_Button";
            this.Inventario_Button.Size = new System.Drawing.Size(116, 23);
            this.Inventario_Button.TabIndex = 18;
            this.Inventario_Button.Text = "Inventario";
            this.Inventario_Button.UseVisualStyleBackColor = true;
            this.Inventario_Button.Click += new System.EventHandler(this.Inventario_Button_Click);
            // 
            // depreciacion
            // 
            this.depreciacion.Location = new System.Drawing.Point(356, 494);
            this.depreciacion.Name = "depreciacion";
            this.depreciacion.Size = new System.Drawing.Size(116, 23);
            this.depreciacion.TabIndex = 19;
            this.depreciacion.Text = "Depreciacion";
            this.depreciacion.UseVisualStyleBackColor = true;
            this.depreciacion.Click += new System.EventHandler(this.depreciacion_Click);
            // 
            // dif_Camb
            // 
            this.dif_Camb.Location = new System.Drawing.Point(356, 555);
            this.dif_Camb.Name = "dif_Camb";
            this.dif_Camb.Size = new System.Drawing.Size(116, 23);
            this.dif_Camb.TabIndex = 20;
            this.dif_Camb.Text = "Diferencia Camb.";
            this.dif_Camb.UseVisualStyleBackColor = true;
            this.dif_Camb.Click += new System.EventHandler(this.dif_Camb_Click);
            // 
            // ingresos
            // 
            this.ingresos.Location = new System.Drawing.Point(356, 526);
            this.ingresos.Name = "ingresos";
            this.ingresos.Size = new System.Drawing.Size(116, 23);
            this.ingresos.TabIndex = 21;
            this.ingresos.Text = "Ingresos";
            this.ingresos.UseVisualStyleBackColor = true;
            this.ingresos.Click += new System.EventHandler(this.ingresos_Click);
            // 
            // nombre_cruce
            // 
            this.nombre_cruce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nombre_cruce.Location = new System.Drawing.Point(794, 498);
            this.nombre_cruce.Name = "nombre_cruce";
            this.nombre_cruce.Size = new System.Drawing.Size(114, 20);
            this.nombre_cruce.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(696, 499);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Nombre del Cruce";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1302, 635);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombre_cruce);
            this.Controls.Add(this.ingresos);
            this.Controls.Add(this.dif_Camb);
            this.Controls.Add(this.depreciacion);
            this.Controls.Add(this.Inventario_Button);
            this.Controls.Add(this.removegrid3);
            this.Controls.Add(this.Visualize);
            this.Controls.Add(this.Cruce_cuentas);
            this.Controls.Add(this.Seleccion);
            this.Controls.Add(this.Catalogo_Cuentas);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblDatabaseName);
            this.Controls.Add(this.lblClientName);
            this.Name = "Form2";
            this.Text = "Cruce de Cuentas";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label Catalogo_Cuentas;
        private System.Windows.Forms.Label Seleccion;
        private System.Windows.Forms.Label Cruce_cuentas;
        private System.Windows.Forms.Button Visualize;
        private System.Windows.Forms.Button removegrid3;
        private System.Windows.Forms.Button Inventario_Button;
        private System.Windows.Forms.Button depreciacion;
        private System.Windows.Forms.Button dif_Camb;
        private System.Windows.Forms.Button ingresos;
        private System.Windows.Forms.TextBox nombre_cruce;
        private System.Windows.Forms.Label label2;
    }
}