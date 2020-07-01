using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aeropuerto
{
    public class Empleado : Persona, iArchivo

    {
        int _legajo;
        catEmp _categoria;
        public int Legajo
        {
            get
            {
                return _legajo;
            }
        }

        public catEmp catEmp
        {
            get
            {
                return _categoria;
            }
        }

        public Empleado(int doc, string nom, string ape, int leg, catEmp cat) : base(doc, nom, ape)
        {
            this._legajo = leg;
            this._categoria = cat;
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