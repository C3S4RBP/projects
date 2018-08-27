namespace tuahorro
{
    partial class home
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_usuario = new System.Windows.Forms.TabPage();
            this.guardar_usuario = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.list_usuarios = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_cupos = new System.Windows.Forms.TextBox();
            this.txt_socio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tab_consignaciones = new System.Windows.Forms.TabPage();
            this.tab_resumen = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tab_usuario.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_usuario);
            this.tabControl1.Controls.Add(this.tab_consignaciones);
            this.tabControl1.Controls.Add(this.tab_resumen);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(644, 412);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_usuario
            // 
            this.tab_usuario.Controls.Add(this.guardar_usuario);
            this.tab_usuario.Controls.Add(this.groupBox2);
            this.tab_usuario.Controls.Add(this.groupBox1);
            this.tab_usuario.Location = new System.Drawing.Point(4, 22);
            this.tab_usuario.Name = "tab_usuario";
            this.tab_usuario.Padding = new System.Windows.Forms.Padding(3);
            this.tab_usuario.Size = new System.Drawing.Size(636, 386);
            this.tab_usuario.TabIndex = 0;
            this.tab_usuario.Text = "Socios";
            this.tab_usuario.UseVisualStyleBackColor = true;
            // 
            // guardar_usuario
            // 
            this.guardar_usuario.Location = new System.Drawing.Point(535, 355);
            this.guardar_usuario.Name = "guardar_usuario";
            this.guardar_usuario.Size = new System.Drawing.Size(75, 23);
            this.guardar_usuario.TabIndex = 4;
            this.guardar_usuario.Text = "Guardar";
            this.guardar_usuario.UseVisualStyleBackColor = true;
            this.guardar_usuario.Click += new System.EventHandler(this.guardar_usuario_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.list_usuarios);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(6, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(617, 153);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actualizar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Socio:";
            // 
            // list_usuarios
            // 
            this.list_usuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.list_usuarios.FormattingEnabled = true;
            this.list_usuarios.Location = new System.Drawing.Point(20, 43);
            this.list_usuarios.Name = "list_usuarios";
            this.list_usuarios.Size = new System.Drawing.Size(334, 21);
            this.list_usuarios.TabIndex = 3;
            this.list_usuarios.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Estado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre socio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cupos:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_cupos);
            this.groupBox1.Controls.Add(this.txt_socio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 103);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crear";
            // 
            // txt_cupos
            // 
            this.txt_cupos.Location = new System.Drawing.Point(63, 46);
            this.txt_cupos.Name = "txt_cupos";
            this.txt_cupos.Size = new System.Drawing.Size(29, 20);
            this.txt_cupos.TabIndex = 3;
            // 
            // txt_socio
            // 
            this.txt_socio.Location = new System.Drawing.Point(109, 20);
            this.txt_socio.Name = "txt_socio";
            this.txt_socio.Size = new System.Drawing.Size(252, 20);
            this.txt_socio.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre socio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cupos:";
            // 
            // tab_consignaciones
            // 
            this.tab_consignaciones.Location = new System.Drawing.Point(4, 22);
            this.tab_consignaciones.Name = "tab_consignaciones";
            this.tab_consignaciones.Size = new System.Drawing.Size(636, 400);
            this.tab_consignaciones.TabIndex = 1;
            this.tab_consignaciones.Text = "Consignaciones";
            this.tab_consignaciones.UseVisualStyleBackColor = true;
            // 
            // tab_resumen
            // 
            this.tab_resumen.Location = new System.Drawing.Point(4, 22);
            this.tab_resumen.Name = "tab_resumen";
            this.tab_resumen.Size = new System.Drawing.Size(636, 400);
            this.tab_resumen.TabIndex = 2;
            this.tab_resumen.Text = "Consolidado";
            this.tab_resumen.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 410);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(644, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 433);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tu Ahorro";
            this.tabControl1.ResumeLayout(false);
            this.tab_usuario.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_usuario;
        private System.Windows.Forms.Button guardar_usuario;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_cupos;
        private System.Windows.Forms.TextBox txt_socio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tab_consignaciones;
        private System.Windows.Forms.TabPage tab_resumen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox list_usuarios;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

