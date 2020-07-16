using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aeropuerto
{
    public class Aeropuerto
    {
        const string urlBase = @"C:\Users\carli\source\repos\Aeropuerto\Archivos\";

        public List<Vuelo> Vuelos{ get; set;}

        #region Metodos
        public void cargalista(Vuelo vu)
        {
            this.Vuelos.Add(vu);
        }

        public Aeropuerto (string dir, List<Avion> list)
        {
            string direccion = urlBase + dir;
            Vuelos = new List<Vuelo>();
            List<Avion> aviones = new List<Avion>();
            aviones = list;
            Vuelo nuevo;            
            StreamReader SR = new StreamReader(direccion);
            string l = SR.ReadLine();
            while (SR.Peek() != -1)
            {
                l = SR.ReadLine();
                string[] vl = l.Split(';');
                DateTime aux1 = DateTime.ParseExact(vl[3], "dd/MM/yyyy HH:mm:ss", null);
                DateTime aux2 = DateTime.ParseExact(vl[4], "dd/MM/yyyy HH:mm:ss", null);
                nuevo = new Vuelo(Convert.ToInt32(vl[0]), vl[1], vl[2], aux1, aux2);

                //Busco nro de Avion en lista y lo cargo en la propiedad Avion del Vuelo
                foreach (Avion a in aviones)
                {
                    if (a.nroAvion == Convert.ToInt32(vl[5]))
                    {
                        nuevo.Avion = a;
                    }
                }                
                Vuelos.Add(nuevo);
            }
            SR.Close();
        }

        public List<Vuelo> damelista()
        {
            return Vuelos;
        }
        #endregion
    }
}