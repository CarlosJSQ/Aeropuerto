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
    public partial class RegAvion : Form
    {
        public RegAvion()
        {
            InitializeComponent();
        }

        private void RegAvion_Load(object sender, EventArgs e)
        {
            CargaAvion("Aviones.csv");
        }

        public void CargaAvion(string dir)
        {
            const string urlBase = @"C:\Users\carli\source\repos\Aeropuerto\Archivos\";
            string direccion = urlBase + dir;
            StreamReader SR = new StreamReader(direccion);
            string lec = SR.ReadLine();
            string[] vlec = lec.Split(';');
            while (SR.Peek() != -1)
            {
                lec = SR.ReadLine();
                vlec = lec.Split(';');
                //CREACION DE OBJETO MOVIL
                dgvAvion.Rows.Add(Convert.ToInt32(vlec[0]), (vlec[1]), vlec[2]);
            }
            SR.Close();
        }
    }
}
