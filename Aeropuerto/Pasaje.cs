using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aeropuerto
{
    public class Pasaje: iArchivo
    {
        private string _nroPasaje;
        private double _costo;
        private Pasajero _Pasajero;
        private Vuelo _Vuelo;
        private DateTime _fecha;

        public string nroPasaje
        {
            get
            {
                return _nroPasaje;
            }
        }

        public double Costo
        {
            get
            {
                return _costo;
            }
        }

        public Pasajero Pasajero
        {
            get
            {
                return _Pasajero;
            }
        }

        public Vuelo Vuelo
        {
            get
            {
                return _Vuelo;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }
        }   

        public Pasaje(string nro,double cost, Pasajero pa, Vuelo vu,DateTime dat)
        {
            this._nroPasaje = nro;
            this._costo = cost;
            this._Pasajero = pa;
            this._Vuelo = vu;
            this._fecha = dat;
        }

        public bool apertura(string nombre)
        {
            bool ok = false;
            FileStream fs = new FileStream(nombre, FileMode.Append);
            StreamReader sr = new StreamReader(fs);
            if (sr != null)
            {
                ok = true;
                sr.Close();
                fs.Close();
                return ok;
            }
            sr.Close();
            fs.Close();
            return ok;
        }

        public bool cierre(string nombre)
        {
            throw new NotImplementedException();
        }

        public void linea(string nombre, string lin)
        {
            throw new NotImplementedException();
        }
    }
}