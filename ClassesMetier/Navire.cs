using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    public abstract class Navire
    {
        private readonly String imo;
        private readonly String nom;
        private String latitude;
        private String longitude;
        private Double tonnageActuel;
        private Double tonnageGT;
        private Double tonnageDWT;

        
        protected Navire(string imo, string nom, string latitude, string longitude, double tonnageActuel, double tonnageGT, double tonnageDWT)
        {
            this.imo = imo;
            this.nom = nom;
            this.latitude = latitude;
            this.longitude = longitude;
            this.tonnageActuel = tonnageActuel;
            this.tonnageGT = tonnageGT;
            this.tonnageDWT = tonnageDWT;
        }

        public string Imo => imo;

        public string Nom => nom;

        public String Latitude { get => latitude; set => latitude = value; }
        public String Longitude { get => longitude; set => longitude = value; }
        public double TonnageActuel { get => tonnageActuel; set => tonnageActuel = value; }
        public double TonnageGT { get => tonnageGT; set => tonnageGT = value; }
        public double TonnageDWT { get => tonnageDWT; set => tonnageDWT = value; }  
    }
}
