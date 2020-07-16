using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aeropuerto
{
    public class Empleado : Persona, iArchivo

    {
        int _legajo;
        string _categoria;
        public int Legajo
        {
            get
            {
                return _legajo;
            }
        }

        public string Categoria
        {
            get
            {
                return _categoria;
            }
        }

        public Empleado(int doc, string nom, string ape, int leg, string cat) : base(doc, nom, ape)
        {
            this._legajo = leg;
            this._categoria = cat;
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

        #region Not Implemented
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