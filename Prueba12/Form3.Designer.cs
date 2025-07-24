namespace FSAsolutions
{
    partial class Form3
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
            this.cruce_cuentas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.mov_insert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cruce_cuentas
            // 
            this.cruce_cuentas.Location = new System.Drawing.Point(59, 131);
            this.cruce_cuentas.Name = "cruce_cuentas";
            this.cruce_cuentas.Size = new System.Drawing.Size(163, 44);
            this.cruce_cuentas.TabIndex = 0;
            this.cruce_cuentas.Text = "Cruce de Cuentas";
            this.cruce_cuentas.UseVisualStyleBackColor = true;
            this.cruce_cuentas.Click += new System.EventHandler(this.cruce_cuentas_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(245, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(224, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Menu de Operaciones";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            // mov_insert
            // 
            this.mov_insert.Location = new System.Drawing.Point(59, 216);
            this.mov_insert.Name = "mov_insert";
            this.mov_insert.Size = new System.Drawing.Size(163, 44);
            this.mov_insert.TabIndex = 2;
            this.mov_insert.Text = "Insertar Ajustes";
            this.mov_insert.UseVisualStyleBackColor = true;
            this.mov_insert.Click += new System.EventHandler(this.mov_insert_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mov_insert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cruce_cuentas);
            this.Controls.Add(this.lblDatabaseName);
            this.Controls.Add(this.lblClientName);
            this.Name = "Form3";
            this.Text = "Menu de Operaciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cruce_cuentas;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mov_insert;
    }
}