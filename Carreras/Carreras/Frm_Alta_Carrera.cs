using Carreras.Datos;
using Carreras.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carreras
{
    public partial class Frm_Alta_Carrera : Form
    {
        private HelperDB ayudante;
        private Carrera nuevo;
        public Frm_Alta_Carrera()
        {
            InitializeComponent();
            ayudante = new HelperDB();
            nuevo = new Carrera();
        }

        private void Frm_Alta_Carrera_Load(object sender, EventArgs e)
        {
            CargarCombo();
            
        }

        private void CargarCombo()
        {
            string consulta = "SP_CARGAR_ASIGNATURA";
            DataTable tabla = ayudante.ConsultaSql(consulta);

            cboAsignatura.DataSource = tabla;
            cboAsignatura.ValueMember = "id_asignatura";
            cboAsignatura.DisplayMember = "nombre";
            cboAsignatura.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe ingresar un nombre!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (txtAño.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe ingresar un año!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (txtCuatrimestre.Text == "")
            {
                MessageBox.Show("Debe ingresar un cuatrimestre!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            foreach(DetalleCarrera det in nuevo.Detalles)
            {
                if(det.Asignatura.Nombre == cboAsignatura.Text)
                {
                    MessageBox.Show("La asignatura ya fue ingresada!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            DataRowView item = (DataRowView)cboAsignatura.SelectedItem;

            int id = Convert.ToInt32(item.Row.ItemArray[0]);
            string nombre = item.Row.ItemArray[1].ToString();

            Asignatura p = new Asignatura(id, nombre);

            int año = Convert.ToInt32(txtAño.Text);
            int cuatrimestre = Convert.ToInt32(txtCuatrimestre.Text);

            DetalleCarrera detalle = new DetalleCarrera(año,cuatrimestre,p);

            nuevo.AgregarDetalle(detalle);

            dgvDetalle.Rows.Add(new object[] {id,nombre,año,cuatrimestre});

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                this.Dispose();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            nuevo.Titulo = txtNombre.Text;
            
            if (ayudante.Confirmar(nuevo))
                MessageBox.Show("La carrera se cargo con exito!!", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            else
                MessageBox.Show("La carrera no se pudo cargar!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }



}
