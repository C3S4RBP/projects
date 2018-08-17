using servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace formulario
{
    public partial class Usuarios : Form
    {
        Database db = new Database();
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            grid_usuarios.DataSource = db.Usuarios("S", 1, null).Tables[0];
            grid_usuarios.Columns[0].ReadOnly = true;
            grid_usuarios.Columns[4].ReadOnly = true;
            cb_rol.ValueMember = "id";
            cb_rol.DisplayMember = "valor";
            cb_rol.DataSource = db.Roles().Tables[0];
        }

        private void grid_usuarios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            servicios.Usuarios data_user = new servicios.Usuarios();
            data_user.idusuarios = Int32.Parse(grid_usuarios.Rows[e.RowIndex].Cells[grid_usuarios.Columns[0].Name].Value.ToString());
            data_user.nombreusuario = grid_usuarios.Rows[e.RowIndex].Cells[grid_usuarios.Columns[2].Name].Value.ToString();
            data_user.email = grid_usuarios.Rows[e.RowIndex].Cells[grid_usuarios.Columns[3].Name].Value.ToString();
            data_user.username = grid_usuarios.Rows[e.RowIndex].Cells[grid_usuarios.Columns[4].Name].Value.ToString();
            db.Usuarios("U", data_user.idusuarios, data_user);
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            txt_nombre.Enabled = !txt_nombre.Enabled;
            txt_username.Enabled = !txt_username.Enabled;
            txt_clave.Enabled = !txt_clave.Enabled;
            txt_email.Enabled = !txt_email.Enabled;
            cb_rol.Enabled = !cb_rol.Enabled;
            if(btn_guardar.Text == "Guadar")
            {
                if(txt_nombre.Text.Length > 0 || txt_username.Text.Length > 0)
                {
                    MessageBox.Show("Existen campos vacios que son obligatorios");
                }
                else
                {
                    MessageBox.Show("Creando usuario");
                }
            }
            btn_guardar.Text = btn_guardar.Text == "Crear" ? "Guadar" : "Crear";
        }
    }
}