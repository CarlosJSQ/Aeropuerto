using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Aeropuerto
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Muestra ventana para confirmar la salida de la aplicacion
            DialogResult Resultado;
            Resultado = MessageBox.Show("Esta seguro que desea salir de la aplicacion?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
            else { return; }
        }
        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVenta frm = new frmVenta();
            frm.MdiParent = this;
            frm.Show();
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            Pasajero p = new Pasajero(1, "carlos", "sanchez", 54);
            bool ok = p.apertura("pasajeros.csv");
            if (ok)
            {
                string l = p.DNI.ToString() + ";" + p.Nombre + ";" + p.Apellido + ";" + p.nroCliente.ToString();
                p.linea("pasajeros.csv", l);
            }
        }*/

        private void lblNroPas_Click(object sender, EventArgs e)
        {

        }

        private void vuelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegAvion frm = new RegAvion();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
