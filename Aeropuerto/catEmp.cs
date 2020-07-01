using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace Aeropuerto
{
    public abstract class catEmp : iArchivo
    {
        public int IDcat { get; set; }

        public string cargo  { get; set; }

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