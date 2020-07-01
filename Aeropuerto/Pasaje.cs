using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aeropuerto
{
    public class Pasaje: iArchivo
    {
        private Asiento _asiento;
        private int _nroPasaje;
        private double _costo;
        private Pasajero _Pasajero;
        private Vuelo _Vuelo;
        private DateTime _fecha;

        public int nroPasaje
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

        public Asiento Asiento
        {
            get
            {
                return _asiento;
            }
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