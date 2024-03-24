using Station.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    class Tanker : Navire , iNavCommercable
    {
        private String typeFluide;

        public Tanker(string imo, string nom, string latitude, string longitude, double tonnageActuel, double tonnageGT, double tonnageDWT, string typeFluide) : base(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            this.TypeFluide = typeFluide;
        }

        public string TypeFluide { get => typeFluide; set => typeFluide = value; }

        public void Charger(int qte)
        {
            this.TonnageActuel += qte;
        }
        public void Decharger(int qte)
        {
            this.TonnageActuel -= qte;
        }
    }
}
