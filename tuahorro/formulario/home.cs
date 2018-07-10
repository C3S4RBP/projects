using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formulario
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        public void OpenWindows(String usuario,String idrol, String version)
        {
            lbl_user.Text = String.Format(lbl_user.Text, usuario);
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_usuarios_Click(object sender, EventArgs e)
        {
            Usuarios usuariosForm = new Usuarios();
            usuariosForm.Show();
        }
    }
}
