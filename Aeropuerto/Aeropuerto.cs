using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aeropuerto
{
    public class Aeropuerto
    {
        public List<Vuelo> Vuelos{ get; set;}
        public Aeropuerto()
        {
            Vuelos = new List<Vuelo>();
        }
        #region Metodos
        public void cargalista(Vuelo vu)
        {
            this.Vuelos.Add(vu);
        }

        public List<Vuelo> damelista()
        {
            return Vuelos;
        }
        #endregion

    }
}