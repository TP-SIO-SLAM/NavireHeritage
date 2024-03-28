// <copyright file="Navire.cs" company="GILABERT_Theo">
// Copyright (c) GILABERT_Theo. All rights reserved.
// </copyright>

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
    class Croisiere : Navire, 
        ICroisierable
    {
        private String typeNavireCroisière;
        private int nbPassagersMaxi;
        private Dictionary<String, Passager> passagers;


        public Croisiere(string imo, string nom, string latitude, string longitude, double tonnageActuel, double tonnageGT, double tonnageDWT, string typeNavireCroisière, int nbPassagersMaxi)
            : base(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            this.typeNavireCroisière = typeNavireCroisière;
            this.nbPassagersMaxi = nbPassagersMaxi;
        }
        public Croisiere(string imo, string nom, string latitude, string longitude, double tonnageActuel, double tonnageGT, double tonnageDWT,string typeNavireCroisière, int nbPassagersMaxi, Dictionary<string, Passager> passagers) 
            :base(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            this.typeNavireCroisière = typeNavireCroisière;
            this.nbPassagersMaxi = nbPassagersMaxi;
            this.Passagers = passagers;
            
        }


        /*public void Embarquer(List<Object> objets)
        {
            foreach (Passager passager in objets)
            {
                if (objets.Count < (nbPassagersMaxi - this.passagers.Count))
                {
                    this.Passagers.Add(passager.NumPasseport, passager);
                }
                else
                {
                    throw new GestionPortExceptions("Le bâteau ne peut acceuillir plus de passager");
                }
            }
        }*/

        /*public List<Object> Debarquer(List<Object> objets)
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
            
        }*/

        public void Embarquer(List<Passager> pPassagers)
        {
            foreach (Passager passager in pPassagers)
            {
                if (pPassagers.Count < (nbPassagersMaxi - this.passagers.Count)) this.Passagers.Add(passager.NumPasseport, passager);
                else throw new GestionPortExceptions("Le bâteau ne peut accueillir plus de passager");
            }
        }

        public List<Passager> Debarquer(List<Passager> pPassagers)
        {
            List<Passager> listPassager = new List<Passager>();
            foreach (Passager passager in this.passagers.Values)
            {
                if (pPassagers.Contains(passager)) this.passagers.Remove(passager.NumPasseport);
                else listPassager.Add(passager);
            }

            return listPassager;
        }


        public string TypeNavireCroisière { get => typeNavireCroisière; set => typeNavireCroisière = value; }
        public int NbPassagersMaxi { get => nbPassagersMaxi; set => nbPassagersMaxi = value; }
        internal Dictionary<string, Passager> Passagers { get => this.passagers; set => this.passagers = value; }
    }
}
