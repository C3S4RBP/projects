using System;
using System.Collections.Generic;
using System.Windows.Forms;
using servicios;

namespace formulario
{
    public partial class login : Form
    {
        Database db = new Database();
        List<string> datausuario = null;
        List<string> version = null;

        public login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            version = db.GetVersionDataBase();
            lbl_version.Text = String.Format(lbl_version.Text, version[1], version[0]);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            if (usuario.Text.Length > 0 || clave.Text.Length > 0)
            {
                datausuario = db.Login(usuario.Text.ToUpper(),clave.Text);
                if (datausuario[0] == "1")
                {
                    home homeForm = new home();
                    homeForm.OpenWindows(datausuario[1], datausuario[3], version[0]);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o clave erroneo");
                }
            }
            else
            {
                MessageBox.Show("Por favor digite usuario y clave");
            }
        }

        private void clave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Ingresar_Click(sender, e);
            }
        }  
    }
}
