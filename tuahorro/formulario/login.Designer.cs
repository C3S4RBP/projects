namespace formulario
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.lbl_version = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.TextBox();
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.clave = new System.Windows.Forms.TextBox();
            this.lbl_pass = new System.Windows.Forms.Label();
            this.panel_usr_pass = new System.Windows.Forms.Panel();
            this.panel_footer = new System.Windows.Forms.Panel();
            this.btn_Ingresar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.panel_usr_pass.SuspendLayout();
            this.panel_footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Location = new System.Drawing.Point(2, 5);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(168, 13);
            this.lbl_version.TabIndex = 0;
            this.lbl_version.Text = "Conectado a {0}, Version App: {1}";
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(6, 22);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(183, 20);
            this.usuario.TabIndex = 1;
            // 
            // lbl_usuario
            // 
            this.lbl_usuario.AutoSize = true;
            this.lbl_usuario.Location = new System.Drawing.Point(3, 6);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(50, 13);
            this.lbl_usuario.TabIndex = 2;
            this.lbl_usuario.Text = "Usuario*:";
            // 
            // clave
            // 
            this.clave.Location = new System.Drawing.Point(237, 22);
            this.clave.Name = "clave";
            this.clave.PasswordChar = '*';
            this.clave.Size = new System.Drawing.Size(183, 20);
            this.clave.TabIndex = 3;
            this.clave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clave_KeyDown);
            // 
            // lbl_pass
            // 
            this.lbl_pass.AutoSize = true;
            this.lbl_pass.Location = new System.Drawing.Point(234, 6);
            this.lbl_pass.Name = "lbl_pass";
            this.lbl_pass.Size = new System.Drawing.Size(41, 13);
            this.lbl_pass.TabIndex = 4;
            this.lbl_pass.Text = "Clave*:";
            // 
            // panel_usr_pass
            // 
            this.panel_usr_pass.Controls.Add(this.lbl_usuario);
            this.panel_usr_pass.Controls.Add(this.lbl_pass);
            this.panel_usr_pass.Controls.Add(this.usuario);
            this.panel_usr_pass.Controls.Add(this.clave);
            this.panel_usr_pass.Location = new System.Drawing.Point(9, 8);
            this.panel_usr_pass.Name = "panel_usr_pass";
            this.panel_usr_pass.Size = new System.Drawing.Size(426, 58);
            this.panel_usr_pass.TabIndex = 5;
            // 
            // panel_footer
            // 
            this.panel_footer.BackColor = System.Drawing.Color.White;
            this.panel_footer.Controls.Add(this.lbl_version);
            this.panel_footer.Location = new System.Drawing.Point(1, 127);
            this.panel_footer.Name = "panel_footer";
            this.panel_footer.Size = new System.Drawing.Size(443, 23);
            this.panel_footer.TabIndex = 6;
            // 
            // btn_Ingresar
            // 
            this.btn_Ingresar.Location = new System.Drawing.Point(257, 72);
            this.btn_Ingresar.Name = "btn_Ingresar";
            this.btn_Ingresar.Size = new System.Drawing.Size(87, 34);
            this.btn_Ingresar.TabIndex = 7;
            this.btn_Ingresar.Text = "Ingresar";
            this.btn_Ingresar.UseVisualStyleBackColor = true;
            this.btn_Ingresar.Click += new System.EventHandler(this.btn_Ingresar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(348, 72);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(87, 34);
            this.btn_cancelar.TabIndex = 8;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 150);
            this.ControlBox = false;
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_Ingresar);
            this.Controls.Add(this.panel_footer);
            this.Controls.Add(this.panel_usr_pass);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tu Ahorro";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel_usr_pass.ResumeLayout(false);
            this.panel_usr_pass.PerformLayout();
            this.panel_footer.ResumeLayout(false);
            this.panel_footer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.Label lbl_usuario;
        private System.Windows.Forms.TextBox clave;
        private System.Windows.Forms.Label lbl_pass;
        private System.Windows.Forms.Panel panel_usr_pass;
        private System.Windows.Forms.Panel panel_footer;
        private System.Windows.Forms.Button btn_Ingresar;
        private System.Windows.Forms.Button btn_cancelar;
    }
}

