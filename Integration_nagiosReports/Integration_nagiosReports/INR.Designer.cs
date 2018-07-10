namespace Integration_nagiosReports
{
    partial class INR
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.CB_mes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_insert = new System.Windows.Forms.Button();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.txt_error = new System.Windows.Forms.TextBox();
            this.btn_dataDiary = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CB_mes
            // 
            this.CB_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_mes.FormattingEnabled = true;
            this.CB_mes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.CB_mes.Location = new System.Drawing.Point(48, 8);
            this.CB_mes.Name = "CB_mes";
            this.CB_mes.Size = new System.Drawing.Size(121, 21);
            this.CB_mes.TabIndex = 0;
            this.CB_mes.SelectedIndexChanged += new System.EventHandler(this.cb_mes_cambio);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mes:";
            // 
            // btn_insert
            // 
            this.btn_insert.Location = new System.Drawing.Point(461, 6);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(91, 33);
            this.btn_insert.TabIndex = 2;
            this.btn_insert.Text = "Iniciar proceso";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(12, 48);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(271, 215);
            this.txt_log.TabIndex = 4;
            // 
            // txt_error
            // 
            this.txt_error.Location = new System.Drawing.Point(289, 48);
            this.txt_error.Multiline = true;
            this.txt_error.Name = "txt_error";
            this.txt_error.Size = new System.Drawing.Size(263, 215);
            this.txt_error.TabIndex = 5;
            // 
            // btn_dataDiary
            // 
            this.btn_dataDiary.Location = new System.Drawing.Point(367, 6);
            this.btn_dataDiary.Name = "btn_dataDiary";
            this.btn_dataDiary.Size = new System.Drawing.Size(88, 33);
            this.btn_dataDiary.TabIndex = 6;
            this.btn_dataDiary.Text = "Proceso Diario";
            this.btn_dataDiary.UseVisualStyleBackColor = true;
            this.btn_dataDiary.Click += new System.EventHandler(this.btn_dataDiary_Click);
            // 
            // INR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 275);
            this.Controls.Add(this.btn_dataDiary);
            this.Controls.Add(this.txt_error);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_mes);
            this.Name = "INR";
            this.Text = "Integration Nagios Reports";
            this.Load += new System.EventHandler(this.INR_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_mes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.TextBox txt_error;
        private System.Windows.Forms.Button btn_dataDiary;
    }
}

