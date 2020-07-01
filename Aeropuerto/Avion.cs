using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Aeropuerto
{
    public class Avion : iArchivo
    {
        Asiento _asiento;
        Tripulacion _Tripulacion;
        int _empresa;
        int _nroAvion;
        string _Modelo; 

        List<Asiento> asientos = new List<Asiento>();
        List<Tripulacion> Tripu = new List<Tripulacion>();

        public Tripulacion Tripulacion
        {
            get
            {
                return _Tripulacion;
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

        public int Empresa
        {
            get
            {
                return _empresa;
            }
        }

        public Asiento Asiento
        {
            get
            {
                return _asiento;
            }
        }

        public Avion(int nro, string mod, int emp, Asiento asi, Tripulacion trip)
        {
            this._asiento = asi;
            asientos.Add(asi);
            this._empresa = emp;
            this._Modelo = mod;
            this._Tripulacion = trip;
            Tripu.Add(trip);
            this._nroAvion = nro;
        }


        public bool apertura(string nombre)
        {
            throw new NotImplementedException();
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