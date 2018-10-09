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
            this.label2 = new System.Windows.Forms.Label();
            this.inpyear = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_updatehost = new System.Windows.Forms.Button();
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
            this.CB_mes.Location = new System.Drawing.Point(149, 8);
            this.CB_mes.Name = "CB_mes";
            this.CB_mes.Size = new System.Drawing.Size(121, 21);
            this.CB_mes.TabIndex = 0;
            this.CB_mes.SelectedIndexChanged += new System.EventHandler(this.cb_mes_cambio);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mes:";
            // 
            // btn_insert
            // 
            this.btn_insert.Location = new System.Drawing.Point(455, 6);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(97, 23);
            this.btn_insert.TabIndex = 2;
            this.btn_insert.Text = "Iniciar Carga";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(12, 35);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ReadOnly = true;
            this.txt_log.Size = new System.Drawing.Size(267, 228);
            this.txt_log.TabIndex = 3;
            // 
            // txt_error
            // 
            this.txt_error.Location = new System.Drawing.Point(285, 35);
            this.txt_error.Multiline = true;
            this.txt_error.Name = "txt_error";
            this.txt_error.ReadOnly = true;
            this.txt_error.Size = new System.Drawing.Size(267, 228);
            this.txt_error.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Año";
            // 
            // inpyear
            // 
            this.inpyear.Location = new System.Drawing.Point(44, 9);
            this.inpyear.Name = "inpyear";
            this.inpyear.Size = new System.Drawing.Size(49, 20);
            this.inpyear.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Limpiar Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_updatehost
            // 
            this.btn_updatehost.Location = new System.Drawing.Point(293, 7);
            this.btn_updatehost.Name = "btn_updatehost";
            this.btn_updatehost.Size = new System.Drawing.Size(75, 23);
            this.btn_updatehost.TabIndex = 8;
            this.btn_updatehost.Text = "host - ip";
            this.btn_updatehost.UseVisualStyleBackColor = true;
            this.btn_updatehost.Click += new System.EventHandler(this.btn_updatehost_Click);
            // 
            // INR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 275);
            this.Controls.Add(this.btn_updatehost);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inpyear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_error);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_mes);
            this.MaximizeBox = false;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inpyear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_updatehost;
    }
}

