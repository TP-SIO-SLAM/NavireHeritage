using GestionNavire.Exceptions;
using Station.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    class Croisière : Navire, 
        ICroisierable
    {
        private String typeNavireCroisière;
        private int nbPassagersMaxi;
        private Dictionary<String, Passager> passagers;


        public Croisière(string imo, string nom, string latitude, string longitude, double tonnageActuel, double tonnageGT, double tonnageDWT, string typeNavireCroisière, int nbPassagersMaxi)
            : base(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            this.typeNavireCroisière = typeNavireCroisière;
            this.nbPassagersMaxi = nbPassagersMaxi;
        }
        public Croisière(string imo, string nom, string latitude, string longitude, double tonnageActuel, double tonnageGT, double tonnageDWT,string typeNavireCroisière, int nbPassagersMaxi, Dictionary<string, Passager> passagers) 
            :base(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            this.typeNavireCroisière = typeNavireCroisière;
            this.nbPassagersMaxi = nbPassagersMaxi;
            this.Passagers = passagers;
            
        }

        public string TypeNavireCroisière { get => typeNavireCroisière; set => typeNavireCroisière = value; }
        public int NbPassagersMaxi { get => nbPassagersMaxi; set => nbPassagersMaxi = value; }
        internal Dictionary<string, Passager> Passagers { get => this.passagers; set => this.passagers = value; }


        public void Embarquer(List<Object> objets)
        {
            foreach(Passager passager in objets) {
                if(this.Passagers.Count < this.nbPassagersMaxi)
                {
                    this.Passagers.Add(passager.NumPasseport, passager);
                }
                else
                {
                    throw new GestionPortExceptions("Le bâteau ne peut acceuillir plus de passager");
                }
            }
        }
        public List<Object> Debarquer(List<Object> objets)
        {
            List<Object> listPassager = new List<Object>();
            foreach(Passager passager in this.passagers.Values)
            {
                if (objets.Contains(passager))
                {
                    this.passagers.Remove(passager.NumPasseport);
                }
                else
                {
                    listPassager.Add(passager);
                }
            }
            return listPassager;
            
        }
    }
}
