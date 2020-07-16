using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aeropuerto
{
    public class Asiento	
		
    {
		const string urlBase = @"C:\Users\carli\source\repos\Aeropuerto\Archivos\";
		public List<Asiento> listaAsientos { get; set; }

		private int nro;
		private string zona;
		private bool estado;

		public bool Estado
		{
			get { return estado; }
			set { estado = value; }
		}

		public int Nro
		{
			get 
			{ 
				return nro;
			}
		}

		public string Zona
		{
			get
			{ 
				return zona;
			}
		}
		public Asiento (int nro, string zona, Boolean ok)
        {
			this.nro = nro;
			this.zona = zona;
			this.estado = ok;
		}

		public Asiento(string dir)
		{
			listaAsientos = new List<Asiento>();
			Asiento aux;
			string direccion = urlBase + dir;
			StreamReader SR = new StreamReader(direccion);
			string l = SR.ReadLine();
			while (SR.Peek() != -1)
			{
				l = SR.ReadLine();
				string[] vl = l.Split(';');
				aux = new Asiento(Convert.ToInt32(vl[0]), vl[1], Convert.ToBoolean(vl[2]));
				listaAsientos.Add(aux);
			}
			SR.Close();
		}
	}
}