using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aeropuerto
{
    public abstract class Persona : Generico<Persona>
    {
        private int doc;
        private string nom;
        private string ape;

        protected Persona(int doc, string nom, string ape)
        {
            this.doc = doc;
            this.nom = nom;
            this.ape = ape;
        }

        public int DNI
        {
            get
            {
                return doc;
            }
        }

        public string Nombre
        {
            get
            {
                return nom;
            }
        }

        public string Apellido
        {
            get
            {
                return ape;
            }
        }

        public void alta(Persona obj)
        {
            throw new NotImplementedException();
        }

        public void baja(int nroID)
        {
            throw new NotImplementedException();
        }

        public Persona buscar(int nroID)
        {
            throw new NotImplementedException();
        }

        public Persona modifica(Persona obj)
        {
            throw new NotImplementedException();
        }
    }
}