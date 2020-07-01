using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aeropuerto
{
    public class Asiento

    {
		private int nro;
		private string zona;
		private bool estado;

		public bool Estado
		{
			get { return estado; }
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

		public Asiento(int num, string zon, bool ok)
		{
			this.nro = num;
			this.zona = zon;
			this.estado = ok;
		}
	}
}