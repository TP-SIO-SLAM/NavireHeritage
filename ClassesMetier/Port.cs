using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionNavire.Exceptions;
using NavireHeritage.classesMetier;
using Station.Interfaces;

namespace NavireHeritage.classesMetier
{
    public class Port : Istationable

    {
        private String nom;
        private String latitude;
        private String longitude;
        private int nbPortique;
        private int nbQuaisPassager;
        private int nbQuaisTanker;
        private int nbQuaisSuperTanker;
        private Dictionary<String, Navire> navireAttendus;
        private Dictionary<String, Navire> navireArrives;
        private Dictionary<String, Navire> navirePartis;
        private Dictionary<String, Navire> navireEnAttente;

        public Port(string nom, string latitude, string longitude, int nbPortique, int nbQuaisPassager, int nbQuaisTanker, int nbQuaisSuperTanker)
        {
            this.nom = nom;
            this.latitude = latitude;
            this.longitude = longitude;
            this.nbPortique = nbPortique;
            this.nbQuaisPassager = nbQuaisPassager;
            this.nbQuaisTanker = nbQuaisTanker;
            this.nbQuaisSuperTanker = nbQuaisSuperTanker;
            this.navireAttendus = new Dictionary<string, Navire>();
            this.navireArrives = new Dictionary<string, Navire>();
            this.navirePartis = new Dictionary<string, Navire>();
            this.navireEnAttente = new Dictionary<string, Navire>();
        }

        public string Nom { get => nom; set => nom = value; }
        public string Latitude { get => latitude; set => latitude = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public int NbPortique { get => nbPortique; set => nbPortique = value; }
        public int NbQuaisPassager { get => nbQuaisPassager; set => nbQuaisPassager = value; }
        public int NbQuaisTanker { get => nbQuaisTanker; set => nbQuaisTanker = value; }
        public int NbQuaisSuperTanker { get => nbQuaisSuperTanker; set => nbQuaisSuperTanker = value; }
        internal Dictionary<string, Navire> NavireAttendus { get => navireAttendus; set => navireAttendus = value; }
        internal Dictionary<string, Navire> NavireArrives { get => navireArrives; set => navireArrives = value; }
        internal Dictionary<string, Navire> NavirePartis { get => navirePartis; set => navirePartis = value; }
        internal Dictionary<string, Navire> NavireEnAttente { get => navireEnAttente; set => navireEnAttente = value; }

        public void EnregistrerArrivee(String imo)
        {
            try
            {
                if (EstAttendu(imo))
                {
                    Navire unNavire = GetUnAttendu(imo) as Navire;
                    if (unNavire is Croisière && this.GetNbCroisiereArrives() < this.nbQuaisPassager)
                    {
                        this.AjoutNavireArrivee(GetUnAttendu(imo));
                    }
                    else
                    {
                        AjoutNavireMarchand(unNavire);
                    }
                }
                else
                {
                    throw new Exception($"Le navire {imo} n'est pas attendu ou est déja arrivée dans le port");
                }
            }
            catch (Exception ex)
            {
                throw new GestionPortExceptions(ex.Message);
            }
        }

        public void EnregistrerArriveePrevue(Object objet)
        {
            if (objet is Navire navire)
            {
                if (!this.navireAttendus.ContainsKey(navire.Imo))

                    this.navireAttendus.Add(navire.Imo, navire);
                else
                {
                    throw new GestionPortExceptions
                        ("Le navire" + navire.Imo + "est déja attendus");
                }
            }
            else
            {
                throw new GestionPortExceptions("Veuillez mettre un bâteau");
            }

        }

        public void EnregistrerDepart(String imo)
        {
            if (EstPresent(imo))
            {
                Navire navire = GetUnArrive(imo) as Navire;
                this.NavirePartis.Add(imo, navire);
                this.NavireArrives.Remove(imo);
                bool placePrise = false;
                int i = 0;
                while (!placePrise && i < this.NavireEnAttente.Count)
                {
                    Navire unNavireEnAttente = this.NavireEnAttente.Values.ElementAt(i);
                    string cle = this.NavireEnAttente.Keys.ElementAt(i);

                    if (unNavireEnAttente.GetType() == navire.GetType())
                    {
                        placePrise = true;
                        this.NavireArrives.Add(cle, unNavireEnAttente);
                        this.NavireEnAttente.Remove(cle);
                    }
                    i++;
                }
                Console.WriteLine($"Le navire {imo} est parti");
            }
            else
            {
                throw new GestionPortExceptions("Enregistrement départ impossible pour " + imo + ", le navire n'est pas dans le port");
            }

        }

        /*public void Chargement(String imo, int qte)
        {

        }
        public void Dechargement(String imo, int qte)
        {

        }*/

        private void AjoutNavireEnAttente(Object objet)
        {
            Navire navire = objet as Navire;
            this.navireEnAttente.Add(navire.Imo, navire);
            this.navireAttendus.Remove(navire.Imo);
        }

        private void AjoutNavireArrivee(Object objet)
        {
            Navire navire = objet as Navire;
            this.navireArrives.Add(navire.Imo, navire);
            this.navireAttendus.Remove(navire.Imo);
        }

        private void AjoutNavireMarchand(Navire navire)
        {
            if (navire is Cargo)
            {
                if (this.GetNbCargoArrives() < this.nbPortique)
                {
                    this.AjoutNavireArrivee(GetUnAttendu(navire.Imo));
                }
                else
                {
                    this.AjoutNavireEnAttente(GetUnAttendu(navire.Imo));
                }
            }
            else
            {
                Tanker tanker = navire as Tanker;
                if (tanker.TonnageGT <= 130000 && this.GetNbTankerArrives() >= this.nbQuaisTanker)
                {
                    this.AjoutNavireEnAttente(tanker);
                }
                else if (tanker.TonnageGT > 130000 && this.GetNbSuperTankerArrives() >= this.nbQuaisSuperTanker)
                {
                    this.AjoutNavireEnAttente(tanker);
                }
                else
                {
                    this.AjoutNavireArrivee(tanker);
                }
            }
        }

        public bool EstEnAttente(String imo)
        {
            return this.navireEnAttente.ContainsKey(imo);
        }

        public bool EstAttendu(String imo)
        {
            return this.navireAttendus.ContainsKey(imo);
        }

        public bool EstPresent(String imo)
        {
            return this.navireArrives.ContainsKey(imo);
        }

        public int GetNbCroisiereArrives()
        {
            int nb = 0;
            foreach (Navire navire in this.navireArrives.Values)
            {
                if (navire is Croisière)
                {
                    nb++;
                }
            }
            return nb;
        }

        public int GetNbCargoArrives()
        {
            int nb = 0;
            foreach (Navire navire in this.navireArrives.Values)
            {
                if (navire is Cargo)
                {
                    nb++;
                }
            }
            return nb;
        }
        public int GetNbTankerArrives()
        {
            int nb = 0;
            foreach (Navire navire in this.navireArrives.Values)
            {
                if (navire is Tanker && navire.TonnageGT <= 130000)
                {
                    nb++;
                }
            }
            return nb;
        }
        public int GetNbSuperTankerArrives()
        {
            int nb = 0;
            foreach (Navire navire in this.navireArrives.Values)
            {
                if (navire is Tanker && navire.TonnageGT > 130000)
                {
                    nb++;
                }
            }
            return nb;
        }

        public bool EstParti(string imo)
        {
            return this.NavirePartis.ContainsKey(imo);
        }

        public object GetUnAttendu(string imo)
        {
            return this.navireAttendus[imo];
        }

        public object GetUnArrive(string imo)
        {
            return this.NavireArrives[imo];
        }

        public object GetUnParti(string imo)
        {
            return this.NavirePartis[imo];
        }

        public object GetUnEnAttente(string imo)
        {
            return this.navireEnAttente[imo];
        }
        public override String ToString()
        {
            return 
                " --------------------------------------------------------- "
                + "\n Port de " + this.nom
                + "\n Coordonnées GPS : " + this.latitude + "  /  " + this.longitude
                + "\n       Nb portiques : " + this.nbPortique
                + "\n       Nb quais croisière : " + this.nbQuaisPassager
                + "\n       Nb quais tankers : " + this.nbQuaisTanker
                + "\n       Nb quais super tankers : " + this.nbQuaisSuperTanker
                + "\n       Nb Navires à quai : " + this.navireArrives.Count
                + "\n       Nb Navirre attendus: " + this.navireAttendus.Count
                + "\n       Nb Navires à partis : " + this.navirePartis.Count
                + "\n       Nb Navires en attente : " + this.navireEnAttente.Count

                + "\n Nombre de cargos dans le port : " + this.GetNbCargoArrives()
                + "\n Nombre de tankers dans le port : " + this.GetNbTankerArrives()
                + "\n Nombre de super tankers dans le port : " + this.GetNbSuperTankerArrives()
                + "\n --------------------------------------------------------- ";

        }

    }
}
