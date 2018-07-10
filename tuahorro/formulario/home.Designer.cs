namespace formulario
{
    partial class home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(home));
            this.lbl_user = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_usuarios = new System.Windows.Forms.Button();
            this.btn_cuentas = new System.Windows.Forms.Button();
            this.btn_consolidar = new System.Windows.Forms.Button();
            this.btn_informe = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(8, 7);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(92, 13);
            this.lbl_user.TabIndex = 0;
            this.lbl_user.Text = "Bienvenido(a): {0}";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btn_informe);
            this.groupBox1.Controls.Add(this.btn_consolidar);
            this.groupBox1.Controls.Add(this.btn_cuentas);
            this.groupBox1.Controls.Add(this.btn_usuarios);
            this.groupBox1.Location = new System.Drawing.Point(11, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 212);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones";
            // 
            // btn_usuarios
            // 
            this.btn_usuarios.Location = new System.Drawing.Point(6, 19);
            this.btn_usuarios.Name = "btn_usuarios";
            this.btn_usuarios.Size = new System.Drawing.Size(156, 23);
            this.btn_usuarios.TabIndex = 0;
            this.btn_usuarios.Text = "Gestionar Usuario";
            this.btn_usuarios.UseVisualStyleBackColor = true;
            this.btn_usuarios.Click += new System.EventHandler(this.btn_usuarios_Click);
            // 
            // btn_cuentas
            // 
            this.btn_cuentas.Location = new System.Drawing.Point(6, 48);
            this.btn_cuentas.Name = "btn_cuentas";
            this.btn_cuentas.Size = new System.Drawing.Size(156, 23);
            this.btn_cuentas.TabIndex = 1;
            this.btn_cuentas.Text = "Gestionar cuentas mensuales";
            this.btn_cuentas.UseVisualStyleBackColor = true;
            // 
            // btn_consolidar
            // 
            this.btn_consolidar.Location = new System.Drawing.Point(7, 77);
            this.btn_consolidar.Name = "btn_consolidar";
            this.btn_consolidar.Size = new System.Drawing.Size(156, 23);
            this.btn_consolidar.TabIndex = 2;
            this.btn_consolidar.Text = "Consolidar cuentas";
            this.btn_consolidar.UseVisualStyleBackColor = true;
            // 
            // btn_informe
            // 
            this.btn_informe.Location = new System.Drawing.Point(7, 106);
            this.btn_informe.Name = "btn_informe";
            this.btn_informe.Size = new System.Drawing.Size(156, 23);
            this.btn_informe.TabIndex = 2;
            this.btn_informe.Text = "Informe General";
            this.btn_informe.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(6, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cerrar sesion";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 247);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_user);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tu ahorro - home";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_informe;
        private System.Windows.Forms.Button btn_consolidar;
        private System.Windows.Forms.Button btn_cuentas;
        private System.Windows.Forms.Button btn_usuarios;
    }
}