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
        string ArVuelos = @"C:\Users\carli\source\repos\Aeropuerto\Archivos\Vuelos.csv";
        string ArAviones = @"C:\Users\carli\source\repos\Aeropuerto\Archivos\Aviones.csv";
        string ArAsientos = @"C:\Users\carli\source\repos\Aeropuerto\Archivos\Asientos.csv";
        string ArTrip = @"C:\Users\carli\source\repos\Aeropuerto\Archivos\Trip";

        List<Avion> listaAvi = new List<Avion>();
        List<Asiento> ListaAsi = new List<Asiento>();
        Aeropuerto Aero = new Aeropuerto();
        Asiento AuxAsiento;


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
            CargaAsiento(ArAsientos);
            CargaAvion(ArAviones);
            CargaVuelos(ArVuelos);
            IniForm();
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

        private void button3_Click(object sender, EventArgs e) //Creacion de vuelos de prueba
        {
            FileStream FS = new FileStream("Vuelos.csv", FileMode.Append);
            StreamWriter SW = new StreamWriter(FS);
            SW.WriteLine(txtNumV.Text + ";" + txtOri.Text + ";" + txtDest.Text + ";" + dtPart.Value.ToString() + ";" + dtLleg.Value.ToString() + ";" + txtAvi.Text);
            SW.Close();
            FS.Close();
        }

        #region Carga de Archivos y Form
        public void CargaAsiento(string ar)//Carga de Archivo Asientos a Lista
        {
            StreamReader SR = new StreamReader(ar);
            string l = SR.ReadLine();
            while (SR.Peek() != -1)
            {
                l = SR.ReadLine();
                string[] vl = l.Split(';');
                AuxAsiento = new Asiento(Convert.ToInt32(vl[0]), vl[1], Convert.ToBoolean(vl[2]));
                ListaAsi.Add(AuxAsiento);
            }
            SR.Close();
        }

        public void CargaAvion(string ar)//Carga de Archivo Avion
        {
            Avion Avi;
            Asiento auxAsiento;
            StreamReader SR = new StreamReader(ar);
            string l = SR.ReadLine();
            while(SR.Peek() != -1)
            {
                l = SR.ReadLine();
                string[] vl = l.Split(';');
                Avi = new Avion(Convert.ToInt32(vl[0]), vl[1], vl[2]);
                foreach(Asiento a in ListaAsi)//Copia Lista de asientos a coleccion de Asientos de la clase Avion
                {
                    auxAsiento = new Asiento(a.Nro, a.Zona, a.Estado);
                    Avi.addasiento(auxAsiento);
                }
                string trip = ArTrip + vl[0] + ".csv";
                Avi.addTripu(CreoTrip(trip));
                listaAvi.Add(Avi);
            }
            SR.Close();
        }

        public Tripulacion CreoTrip(string dir)//Creo objeto tripulacion
        {
            Tripulacion Trip = new Tripulacion();
            Empleado auxEmp;
            bool ok = Trip.apertura(dir);
            if (ok)
            {
                StreamReader ST = new StreamReader(dir);
                string lin = ST.ReadLine();
                while (ST.Peek() != -1)
                {
                    lin = ST.ReadLine();
                    string[] vlaux = lin.Split(';');
                    auxEmp = new Empleado(Convert.ToInt32(vlaux[3]), vlaux[1], vlaux[2], Convert.ToInt32(vlaux[4]), vlaux[0]);
                    Trip.addTrip(auxEmp);
                }
                ST.Close();
            }
            return Trip;
        }

        public void CargaVuelos(string ar)//Carga de Archivo Vuelos
        {
            Vuelo nuevo;
            StreamReader SR = new StreamReader(ar);
            string l = SR.ReadLine();
            l = SR.ReadLine();
            while (SR.Peek() != -1)
            {
                string[] vl = l.Split(';');
                DateTime aux1 = DateTime.ParseExact(vl[3], "dd/MM/yyyy HH:mm:ss",null);
                DateTime aux2 = DateTime.ParseExact(vl[4], "dd/MM/yyyy HH:mm:ss", null);
                nuevo = new Vuelo(Convert.ToInt32(vl[0]), vl[1], vl[2], aux1, aux2);

                //Busco nro de Avion en lista y lo cargo en la propiedad Avion del Vuelo
                foreach (Avion a in listaAvi)
                {
                    if(a.nroAvion == Convert.ToInt32(vl[5]))
                    {
                        nuevo.Avion = a;
                    }
                }
                //listaVuelo.Add(nuevo);
                Aero.cargalista(nuevo);
                l = SR.ReadLine();
            }
            SR.Close();
        }

        public void IniForm()
        {
            lblNroPas.Text = 1.ToString();
            //Linq para no repetir en Combo Destino
            var dupli =Aero.Vuelos.GroupBy(c => c.Dest).Select(g => g.First()).ToList();
            cmbDest.DataSource = dupli;
            cmbDest.DisplayMember = "Dest";
        }
        #endregion

        private void cmbDest_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //CONTINUAR CARGANDO COMBOS Y TERMINAR
        }
    }
}
