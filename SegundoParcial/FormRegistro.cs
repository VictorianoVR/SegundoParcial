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
        private AgendaModel modelEditar = null;
        public FormRegistro(AgendaModel model )
        {
            InitializeComponent();
            if (model != null)
            {
                modelEditar = model;
                textBoxNombre.Text = model.Nombre;
                textBoxApellido.Text = model.Apellido;
                textBoxCelular.Text = model.Celular;
                dateTimePickerEntrega.Text = dateTimePickerEntrega.Text;
                textBoxDireccion.Text = model.Direccion;
            }

        }

        private void labelTitulo_Click(object sender, EventArgs e)
        {

        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {

         
            
            if (modelEditar == null)
            {
                if (!string.IsNullOrWhiteSpace(textBoxCelular.Text))
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
                else {
                    MessageBox.Show("El campo celular no debe estar vacio", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
            }
            else {
                string celularAntiguo = modelEditar.Celular;
                modelEditar.Nombre = textBoxNombre.Text;
                modelEditar.Apellido = textBoxApellido.Text;
                modelEditar.Direccion = textBoxDireccion.Text;
                modelEditar.FechaNacimiento = Convert.ToDateTime(dateTimePickerEntrega.Text);
                modelEditar.Celular = textBoxCelular.Text;
                Datos.EditarAgenda(modelEditar, celularAntiguo);

                MessageBox.Show("Contacto editado correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormInicio lista = new FormInicio();
                this.Hide();
                lista.Show();
            }
            
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            FormInicio lista = new FormInicio();
            this.Hide();
            lista.Show();
        }
    }
}
