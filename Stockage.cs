using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    class Stockage : Navire
    {
        private int numero;
        private int capaciteMaxi;
        private int capacitéDispo;

        public Stockage(string imo, string nom, string latitude, string longitude, double tonnageActuel, double tonnageGT, double tonnageDWT, int numero, int capaciteMaxi, int capacitéDispo) : base(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            this.numero = numero;
            this.capaciteMaxi = capaciteMaxi;
            this.capacitéDispo = capacitéDispo;
        }

        public int Numero { get => numero; set => numero = value; }
        public int CapaciteMaxi { get => capaciteMaxi; set => capaciteMaxi = value; }
        public int CapacitéDispo { get => capacitéDispo; set => capacitéDispo = value; }
    }
}
