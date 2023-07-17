using System;
using System.Collections;
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
    public partial class FormInicio : Form
    {
        List<AgendaModel> lista = new List<AgendaModel>();
        public FormInicio()
        {
            InitializeComponent();
            ObtenerLista();
        }
        private void ObtenerLista()
        {
            lista = Datos.GetList();

            dataGridView.AutoGenerateColumns = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Asociar la lista de usuarios al DataGridView
            dataGridView.DataSource = lista;
        }
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            FormRegistro registro = new FormRegistro(null);
            this.Hide();
            registro.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int filaSeleccionada = dataGridView.SelectedCells[0].RowIndex;
            AgendaModel elementoSeleccionado = lista[filaSeleccionada];

            Datos.Eliminar(elementoSeleccionado.Celular);
            MessageBox.Show("Registro eliminado correctamente", "Listado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ObtenerLista();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            int filaSeleccionada = dataGridView.SelectedCells[0].RowIndex;
            AgendaModel elementoSeleccionado = lista[filaSeleccionada];
            FormRegistro registro = new FormRegistro(elementoSeleccionado);
            this.Hide();
            registro.Show();
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
