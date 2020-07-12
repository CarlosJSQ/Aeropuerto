
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace Aeropuerto
{
    public class Pasajero : Persona, iArchivo
    {
        int _nroCliente;
        public int nroCliente
        {
            get
            {
                return _nroCliente;
            }
        }

        //Constructor de objeto Pasajero
        public Pasajero(int doc, string nom, string ape, int cliente): base(doc, nom, ape)
        {
            this._nroCliente = cliente;
        }

        //Metodo de lectura de archivo Pasajeros
        public bool apertura(string nombre)
        {
            bool ok = false;
            FileStream fs = new FileStream(nombre, FileMode.Append);
            StreamReader sr = new StreamReader(fs);
            if(sr != null)
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

        public bool cierre(string nombre)
        {
            throw new NotImplementedException();
        }

        //Metodo escritura de archivo de Pasajeros
        public void linea(string nombre, string lin)
        {
            bool ok = false;
            FileStream fs = new FileStream(nombre, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            if (sw != null)
            {
                sw.WriteLine(lin);
                sw.Close();
                fs.Close();
            }
            sw.Close();
            fs.Close();
        }
    }
}