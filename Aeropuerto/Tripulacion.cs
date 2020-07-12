using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aeropuerto
{
    public class Tripulacion: iArchivo
    {
        //La clase Tripulacion maneja una coleccion de Empleados
        public List<Empleado> empTrip { get; set; }

        public Tripulacion()
        {
            empTrip = new List<Empleado>();
        }

        public void addTrip (Empleado tr)
        {
            this.empTrip.Add(tr);
        }

        public bool apertura(string nombre)
        {
            bool ok = false;
            FileStream fs = new FileStream(nombre, FileMode.Open);
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
    }
}