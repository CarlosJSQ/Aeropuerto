using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aeropuerto
{
    public class vtaPasaje
    {
        private Pasaje _pasaje;
        private Pasajero _pasajero;
        private Empleado _empleado;
        private int _nroVenta;
  
        public int nroVenta
        {
            get 
            { 
                return _nroVenta;
            }
        }
        public Empleado Empleado
        {
            get
            {
                return _empleado;
            }
        }

        public Pasaje Pasaje
        {
            get
            {
                return _pasaje;
            }
        }

        public Pasajero Pasajero
        {
            get
            {
                return _pasajero;
            }
        }

        public vtaPasaje(Pasajero p, int nro, Empleado e, Pasaje pa)
        {
            this._empleado = e;
            this._nroVenta = nro;
            this._pasajero = p;
            this._pasaje = pa;
        }
    }
}