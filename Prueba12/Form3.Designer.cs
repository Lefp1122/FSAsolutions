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
            cruce_cuentas = new Button();
            label1 = new Label();
            lblDatabaseName = new Label();
            lblClientName = new Label();
            mov_insert = new Button();
            cuentas_nuevas = new Button();
            SuspendLayout();
            // 
            // cruce_cuentas
            // 
            cruce_cuentas.Location = new Point(69, 151);
            cruce_cuentas.Margin = new Padding(4, 3, 4, 3);
            cruce_cuentas.Name = "cruce_cuentas";
            cruce_cuentas.Size = new Size(190, 51);
            cruce_cuentas.TabIndex = 0;
            cruce_cuentas.Text = "Cruce de Cuentas";
            cruce_cuentas.UseVisualStyleBackColor = true;
            cruce_cuentas.Click += cruce_cuentas_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(327, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(224, 25);
            label1.TabIndex = 1;
            label1.Text = "Menu de Operaciones";
            label1.Click += label1_Click;
            // 
            // lblDatabaseName
            // 
            lblDatabaseName.AutoSize = true;
            lblDatabaseName.Location = new Point(15, 57);
            lblDatabaseName.Margin = new Padding(4, 0, 4, 0);
            lblDatabaseName.Name = "lblDatabaseName";
            lblDatabaseName.Size = new Size(108, 15);
            lblDatabaseName.TabIndex = 0;
            lblDatabaseName.Text = "Selected Database: ";
            // 
            // lblClientName
            // 
            lblClientName.AutoSize = true;
            lblClientName.Location = new Point(15, 82);
            lblClientName.Margin = new Padding(4, 0, 4, 0);
            lblClientName.Name = "lblClientName";
            lblClientName.Size = new Size(79, 15);
            lblClientName.TabIndex = 1;
            lblClientName.Text = "Client Name: ";
            // 
            // mov_insert
            // 
            mov_insert.Location = new Point(69, 249);
            mov_insert.Margin = new Padding(4, 3, 4, 3);
            mov_insert.Name = "mov_insert";
            mov_insert.Size = new Size(190, 51);
            mov_insert.TabIndex = 2;
            mov_insert.Text = "Ajustes y Entradas posteriores";
            mov_insert.UseVisualStyleBackColor = true;
            mov_insert.Click += mov_insert_Click;
            // 
            // cuentas_nuevas
            // 
            cuentas_nuevas.Location = new Point(497, 151);
            cuentas_nuevas.Name = "cuentas_nuevas";
            cuentas_nuevas.Size = new Size(172, 51);
            cuentas_nuevas.TabIndex = 3;
            cuentas_nuevas.Text = "Cuentas Nuevas";
            cuentas_nuevas.UseVisualStyleBackColor = true;
            cuentas_nuevas.Click += cuentas_nuevas_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(cuentas_nuevas);
            Controls.Add(mov_insert);
            Controls.Add(label1);
            Controls.Add(cruce_cuentas);
            Controls.Add(lblDatabaseName);
            Controls.Add(lblClientName);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form3";
            Text = "Menu de Operaciones";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cruce_cuentas;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mov_insert;
        private Button cuentas_nuevas;
    }
}