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
        //La clase Avion maneja una tripulacion y una coleccion de asientos

        Tripulacion _Tripulacion;
        string _empresa;
        int _nroAvion;
        string _Modelo; 

        public List<Asiento> asientos { get; set; }

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

        public Avion(int nro, string mod, string emp)
        {
            this._empresa = emp;
            this._Modelo = mod;
            this._nroAvion = nro;
            this.asientos = new List<Asiento>();
        }
        #region Metodos

        public void addTripu(Tripulacion tr)
        {
            this.Tripulacion = new Tripulacion();
            this.Tripulacion = tr;
        }

        public void addasiento(Asiento asi)
        {
            this.asientos.Add(asi);
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