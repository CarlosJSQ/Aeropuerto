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
    public partial class Form1 : Form
    {
        string ArVuelos = "Vuelos.csv";
        string ArAviones = "Aviones.csv";
        string ArAsientos = "Asientos.csv";


        Vuelo Lista;
        Avion AviLista;

        //List<Vuelo> Vuelos = new List<Vuelo>();//Lista de Vuelos que se van a cargar desde el archivo
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblNroPas.Text = 1.ToString();
            CargaAvion();
            CargaVuelos(ArVuelos);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pasajero p = new Pasajero(1, "carlos", "sanchez", 54);
            bool ok = p.apertura("pasajeros.csv");
            if (ok)
            {
                string l = p.DNI.ToString() + ";" + p.Nombre + ";" + p.Apellido + ";" + p.nroCliente.ToString();
                p.linea("pasajeros.csv", l);
            }
        }

        private void lblNroPas_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream FS = new FileStream("Vuelos.csv", FileMode.Append);
            StreamWriter SW = new StreamWriter(FS);
            SW.WriteLine(txtNumV.Text + ";" + txtOri.Text + ";" + txtDest.Text + ";" + dtPart.Value.ToString() + ";" + dtLleg.Value.ToString() + ";" + txtAvi.Text);
            SW.Close();
            FS.Close();
        }

        public void CargaVuelos(string ar)
        {
            Vuelo nuevo;
            StreamReader SR = new StreamReader(ar);
            string l = SR.ReadLine();
            l = SR.ReadLine();
            while (SR.Peek() != -1)
            {
                string[] vl = l.Split(';');
                nuevo = new Vuelo(Convert.ToInt32(vl[0]), vl[1], vl[2], Convert.ToDateTime(vl[3]), Convert.ToDateTime(vl[4]), vl[5]);
                Lista.Vuelos.Add(nuevo);
                l = SR.ReadLine();
            }
            SR.Close();
        }
    }
}
