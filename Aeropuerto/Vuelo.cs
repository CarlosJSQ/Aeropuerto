using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Aeropuerto
{
    public class Vuelo : iArchivo
    {
        public List<Vuelo> Vuelos { get; set; }

        string _Avion;
        string _origen;
        string _dest;
        DateTime _hrPart;
        DateTime _hrLleg;
        int _nroVuelo;

        public string Avion
        {
            get
            {
                return _Avion;
            }
        }

        public string Origen
        {
            get
            {
                return _origen;
            }
        }

        public string Dest
        {
            get
            {
                return _dest;
            }
        }

        public DateTime horaPart
        {
            get
            {
                return _hrPart;
            }
        }

        public DateTime horaLlegada
        {
            get
            {
                return _hrLleg;
            }
        }

        public int NroVuelo
        {
            get
            {
                return _nroVuelo;
            }
        }

        public Vuelo(int nv, string ori,string dest, DateTime part, DateTime lleg, string avi)
        {
            this._nroVuelo = nv;
            this._origen = ori;
            this._dest = dest;
            this._hrPart = part;
            this._hrLleg = lleg;
            this._Avion = avi;
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