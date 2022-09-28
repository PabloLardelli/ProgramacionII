using RecetasSLN.datos;
using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasSLN.presentación
{
    public partial class FrmConsultarRecetas : Form
    {
        private Receta nuevo;
        private HelperDB ayudante;
        public FrmConsultarRecetas()
        {
            InitializeComponent();
            nuevo = new Receta();
            ayudante = new HelperDB();
        }

        private void FrmConsultarRecetas_Load(object sender, EventArgs e)
        {
            CargarTipo();
        }

        private void CargarTipo()
        {
            DataTable tabla = new DataTable();
            tabla = ayudante.EjecutarSql();

            if (tabla != null)
            {
                cboIngrediente.DataSource = tabla;
                cboIngrediente.ValueMember = "id_ingrediente";
                cboIngrediente.DisplayMember = "n_ingrediente";
                cboIngrediente.DropDownStyle = ComboBoxStyle.DropDownList;
            }

        }

        private int ProximaReceta()
        {
            int proximo = ayudante.ConsultaUltimo();
            return proximo;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre!","Aviso!",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            if (txtCheff.Text == "")
            {
                MessageBox.Show("Debe ingresar un Cheff!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (txtTipo.Text == "")
            {
                MessageBox.Show("Debe ingresar un tipo!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            foreach (DetalleReceta det in nuevo.Detalle)
            {
                if (det.Ingrediente.Nombre == cboIngrediente.Text)
                {
                    MessageBox.Show("Ese ingrediente ya fue ingresado!","Aviso!",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    return;
                }
            }

            DataRowView fila = (DataRowView)cboIngrediente.SelectedItem;

            int id = Convert.ToInt32(fila.Row.ItemArray[0]);
            string nombre = fila.Row.ItemArray[1].ToString();
            string unidad = fila.Row.ItemArray[2].ToString();

            Ingrediente ingrediente = new Ingrediente(id, nombre, unidad);

            int cant = (int)nudCantidad.Value;

            DetalleReceta detalle = new DetalleReceta(cant, ingrediente);

            nuevo.AgregarDetalle(detalle);

            dgvDetalles.Rows.Add(new object []{ nombre, cant });

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Seguro desea salir?","salir",MessageBoxButtons.YesNo,MessageBoxIcon.Stop,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
                this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombreReceta = txtNombre.Text;
            string cheff = txtCheff.Text;
            int tipo = Convert.ToInt32(txtTipo.Text);

            if (ayudante.Confirmar(nuevo))
            {
                MessageBox.Show("La receta se cargo con exito!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("La receta no se pudo cargar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void Proximo()
        {
            int next = ayudante.ProximaReceta();
            if (next>0)
            {
                label4.Text = "Presupuesto Nº: " + next.ToString();

            }
            else
                MessageBox.Show("Error de datos. No se puede obtener Nº de presupuesto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }




    }
}
