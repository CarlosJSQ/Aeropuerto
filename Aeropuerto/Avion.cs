using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.IO;

namespace Aeropuerto
{
    public class Avion : iArchivo
    {
        const string urlBase = @"C:\Users\carli\source\repos\Aeropuerto\Archivos\";

        Tripulacion _Tripulacion;
        Asiento _asientos;
        string _empresa;
        int _nroAvion;
        string _Modelo; 

        public Tripulacion Tripulacion
        {
            get
            {
                return _Tripulacion;
            }
            set
            {
                _Tripulacion = value;
            }
        }
        public Asiento asientos
        {
            get
            {
                return _asientos;
            }
        }

        public string Modelo
        {
            get
            {
                return _Modelo;
            }
        }

        public int nroAvion
        {
            get
            {
                return _nroAvion;
            }
        }

        public string Empresa
        {
            get
            {
                return _empresa;
            }
        }

        public Avion(int nro, string mod, string emp, Asiento asi)
        {
            this._empresa = emp;
            this._Modelo = mod;
            this._nroAvion = nro;
            this._asientos =asi;
        }
        #region Metodos

        public void addTripu(Tripulacion tr)
        {
            this.Tripulacion = new Tripulacion();
            this.Tripulacion = tr;
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
        #region NotImplemented
        public bool cierre(string nombre)
        {
            throw new NotImplementedException();
        }

        public void linea(string nombre, string lin)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}