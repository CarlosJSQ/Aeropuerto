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
using System.Security.Cryptography.X509Certificates;

namespace Aeropuerto
{
    public partial class frmVenta : Form
    {
        const string urlBase = @"C:\Users\carli\source\repos\Aeropuerto\Archivos\";

        Asiento ListaAsiento;
        Aeropuerto Aero;
        List<Avion> listaAvi = new List<Avion>();
        List<Empleado> Vendor = new List<Empleado>();
        int AuxSelect = 0;

        public frmVenta()
        {
            InitializeComponent();
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            lblNroPas.Text = 1.ToString();
            ListaAsiento = new Asiento("Asientos.csv");//Creo lista de asientos desde archivo
            CargaAvion("Aviones.csv");
            Aero = new Aeropuerto("Vuelos.csv",listaAvi);
            CargaEmpleados("Empleados.csv");
            IniForm();
        }
        #region Carga de Archivos y Form

        public void CargaAvion(string dir)//Carga de Archivo Avion
        {
            string direccion = urlBase + dir;
            Avion Avi;
            StreamReader SR = new StreamReader(direccion);
            string l = SR.ReadLine();
            while (SR.Peek() != -1)
            {
                l = SR.ReadLine();
                string[] vl = l.Split(';');
                Avi = new Avion(Convert.ToInt32(vl[0]), vl[1], vl[2],ListaAsiento);
                string dirtrip = urlBase + "Trip" + vl[0] + ".csv";
                Avi.addTripu(CreoTrip(dirtrip));
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
                    Trip.empTrip.Add(auxEmp);
                }
                ST.Close();
            }
            return Trip;
        }

        public void CargaEmpleados(string dir)
        {
            Empleado aux;
            string direccion = urlBase + dir;
            StreamReader SR = new StreamReader(direccion);
            string l = SR.ReadLine();
            while(SR.Peek() != -1)
            {
                l = SR.ReadLine();
                string[] vl = l.Split(';');
                aux = new Empleado(Convert.ToInt32(vl[2]), vl[0], vl[1], Convert.ToInt32(vl[3]), vl[4]);
                Vendor.Add(aux);
            }
            SR.Close();
        }

        public void IniForm()
        {
            //Linq para no repetir en Combo Destino
            var dupli = Aero.Vuelos.GroupBy(c => c.Dest).Select(g => g.First()).ToList();
            cmbDest.DataSource = dupli;
            cmbDest.DisplayMember = "Dest";
            cmbDest.SelectedItem = null;
            cmbVendor.DataSource = Vendor;
            cmbVendor.DisplayMember = "Nombre";
            cmbVendor.SelectedItem = null;
        }
        #endregion

        //Metodo para buscar vuelos en lista segun destino
        public List<Vuelo> Buscar(string dato)
        {
            var aux = from v in Aero.Vuelos
                      where v.Dest == dato
                      select v;
            return aux.ToList();
        }

        private void cmbDest_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            var auxcmb = cmbDest.SelectedItem as Vuelo;
            bool valid = false;
            var lista = Buscar(auxcmb.Dest);
            if (auxcmb.Dest == "Buenos Aires")
            {
                //Linq para no repetir destinos en combo
                var dupli = lista.GroupBy(c => c.Origen).Select(g => g.First()).ToList();
                cmbOrigen.DataSource = dupli;
                cmbOrigen.DisplayMember = "Origen";
                cmbOrigen.Enabled = true;
                cmbOrigen.SelectedItem = null;
                valid = true;
                cmbPart.Enabled = false;
                cmbPart.DataSource = null;
            }
            else
            {
                cmbOrigen.DataSource = null;
                if (valid == false)//Valido si antes fue seleccionado algun destino
                {
                    cmbOrigen.Items.Add(auxcmb);
                    cmbOrigen.SelectedIndex = 0;
                    cmbOrigen.DisplayMember = "Origen";
                    cmbOrigen.Enabled = false;
                    valid = true;
                }
                cmbPart.DataSource = lista;
                cmbPart.DisplayMember = "horaPart";
                cmbPart.Enabled = true;
                cmbPart.SelectedItem = null;
            }
        }

        private void cmbOrigen_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            var auxcmb = cmbOrigen.SelectedItem as Vuelo;
            var lista = Buscar(auxcmb.Origen);
            cmbPart.DataSource = lista;
            cmbPart.DisplayMember = "horaPart";
            cmbPart.Enabled = true;
            cmbPart.SelectedItem = null;
        }

        private void cmbPart_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            var seleccion = cmbPart.SelectedItem as Vuelo;
            var dupli =seleccion.Avion.asientos.listaAsientos.GroupBy(c => c.Zona).Select(g => g.First()).ToList();
            txtLleg.Text = Convert.ToString(seleccion.horaLlegada);
            txtAvion.Text = Convert.ToString(seleccion.Avion.nroAvion);
            cmbCat.DataSource = dupli;
            cmbCat.Enabled = true;
            cmbCat.DisplayMember = "Zona";
            cmbCat.SelectedItem = null;
        }

        private void cmbCat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var seleccion = cmbPart.SelectedItem as Vuelo;
            var asientosel = cmbCat.SelectedItem as Asiento;
            var lista = from a in seleccion.Avion.asientos.listaAsientos
                        where a.Zona == asientosel.Zona
                        select a;
            cmbAsiento.DataSource = lista.ToList();
            cmbAsiento.Enabled = true;
            cmbAsiento.DisplayMember = "nro";
            cmbAsiento.SelectedItem = null;

            if(asientosel.Zona == "VIP")
            {
                lblPrecio.Text = "12000";
            }
            if (asientosel.Zona == "Ejecutivo")
            {
                lblPrecio.Text = "10000";
            }
            if (asientosel.Zona == "Turista")
            {
                lblPrecio.Text = "7000";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtEdad.Text != null && txtDNI.Text!=null && txtNombre.Text!=null && txtApe.Text!=null && cmbDest.SelectedItem!=null
                && cmbOrigen.SelectedItem!=null && cmbCat.SelectedItem!=null && cmbVendor.SelectedItem!=null)
            {
                double precio = Convert.ToDouble(lblPrecio.Text);

                if (Convert.ToInt32(txtEdad.Text) < 10)
                {
                    precio = precio * .5;
                    lblPrecio.Text = precio.ToString();
                }
                DialogResult Resultado;
                Resultado = MessageBox.Show("Confirmar venta?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resultado == DialogResult.Yes)
                {        
                    Pasajero nuevo = new Pasajero(Convert.ToInt32(txtDNI.Text), txtNombre.Text, txtApe.Text);
                    var elegido = cmbPart.SelectedItem as Vuelo;
                    Pasaje boleto = new Pasaje(lblNroPas.Text,precio,nuevo,elegido,DateTime.Today);
                    foreach(Vuelo v in Aero.Vuelos)
                    {
                        if(elegido.NroVuelo==v.NroVuelo)
                        {
                            foreach(Asiento a in v.Avion.asientos.listaAsientos)
                            {
                                if(a.Nro==AuxSelect)
                                {
                                    a.Estado = false;
                                }
                            }
                        }
                    }
                    
                }
                else { return; }
            }
            else
            {
                MessageBox.Show("Complete los campos faltantes", "ERROR!!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            
        }

        private void cmbVendor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var vendedor = cmbVendor.SelectedItem as Empleado;
            txtLeg.Text = vendedor.Legajo.ToString();
        }

        private void dtNaci_ValueChanged(object sender, EventArgs e)
        {
            DateTime Actual = DateTime.Today;
            int edad = Actual.Year - dtNaci.Value.Year;
            if(Actual<dtNaci.Value.AddYears(edad))
            {
                edad--;
            }
            txtEdad.Text = edad.ToString();
        }

        private void cmbAsiento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var seleccion = cmbAsiento.SelectedItem as Asiento;
            if(seleccion.Estado)
            {
                AuxSelect = seleccion.Nro;
            }
            else
            {
                MessageBox.Show("Seleccione otro asiento, ocupado", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream FS = new FileStream("Vuelos.csv", FileMode.Append);
            StreamWriter SW = new StreamWriter(FS);
            SW.WriteLine(txtNumV.Text + ";" + txtOri.Text + ";" + txtDest.Text + ";" + dtPart.Value.ToString() + ";" + dtLleg.Value.ToString() + ";" + txtAvi.Text);
            SW.Close();
            FS.Close();
        }
    }
}
