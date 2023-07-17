using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoParcial
{
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();

        }

        private void labelTitulo_Click(object sender, EventArgs e)
        {

        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {

            AgendaModel model = new AgendaModel()
            {
                Nombre = textBoxNombre.Text,
                Apellido = textBoxApellido.Text,
                Celular = textBoxCelular.Text,
                FechaNacimiento = Convert.ToDateTime(dateTimePickerEntrega.Text),
                Direccion = textBoxDireccion.Text
            };

            Datos.CrearRegistro(model);

            MessageBox.Show("Contacto agregado correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FormInicio lista = new FormInicio();
            this.Hide();
            lista.Show();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
