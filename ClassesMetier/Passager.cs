using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    class Passager
    {
        private String numPasseport;
        private String nom;
        private String prenom;
        private String nationalite;

        public Passager(string numPasseport, string nom, string prenom, string nationalite)
        {
            this.numPasseport = numPasseport;
            this.nom = nom;
            this.prenom = prenom;
            this.nationalite = nationalite;
        }

        public string NumPasseport { get => numPasseport; set => numPasseport = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Nationalite { get => nationalite; set => nationalite = value; }
    }
}
