using System;
using System.Windows.Forms;
using tuahorro.Clases;
using tuahorro.objetos;
using System.ComponentModel;

namespace tuahorro
{
    public partial class home : Form
    {
        Acceso_archivo file = new Acceso_archivo();

        public home()
        {
            InitializeComponent();
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
        }

        private void guardar_usuario_Click(object sender, EventArgs e)
        {
            
            if (txt_socio.TextLength > 0)
            {
                User usuario = new User();
                usuario.Nombre = txt_socio.Text;
                usuario.Cupos = Convert.ToInt32(txt_cupos.Text);
                usuario.Estado = "Activo";
                usuario.Fecha = DateTime.Now.ToString("MM/dd/yyyy");
                file.CrearUsuario(usuario);
            }
            else
            {
                MessageBox.Show("Es necesario diligenciar los campos de la seccion Crear");
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            this.list_usuarios.Items.Clear();
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            file.ConsultarUsuarios().ForEach(delegate (String name)
            {
                list_usuarios.Items.Add(name);
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}
