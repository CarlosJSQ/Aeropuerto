using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aeropuerto
{
    public interface Generico<T>
    {
        void alta(T obj);
        void baja(int nroID);
        T buscar(int nroID);
        T modifica(T obj);
    }
}