using PilasColasPABLO.Clases;
using PilasColasPABLO.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PilasColasPABLO
{
    public partial class Form1 : Form
    {
        private ICollection coleccion;
        public Form1()
        {
            InitializeComponent();
            coleccion = new Pila(20);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtElemento.Text))
            {
                object elemento = txtElemento.Text;
                if (coleccion.Añadir(elemento))
                {
                    lstElemento.Items.Add(elemento);
                    MessageBox.Show("Elemento Añadido", "Elemento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lista llena!", "Elemento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            if (!coleccion.EstaVacia())
                MessageBox.Show("Primer elemento: " + coleccion.Primero(), "Elemento", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnVacia_Click(object sender, EventArgs e)
        {
            string mensaje = coleccion.EstaVacia() ? "Pila vacía" : "Pila con elementos";
            MessageBox.Show(mensaje, "Elemento", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnExtraer_Click(object sender, EventArgs e)
        {
            object elemento = coleccion.Extraer();
            lstElemento.Items.Remove(elemento);

        }
    }
}
