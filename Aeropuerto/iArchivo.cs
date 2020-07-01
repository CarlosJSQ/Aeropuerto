using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aeropuerto
{
    public interface iArchivo
    {
        bool apertura(string nombre);
        bool cierre(string nombre);
        void linea(string nombre, string lin);
    }
}