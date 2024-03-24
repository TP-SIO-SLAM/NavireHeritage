using NavireHeritage.classesMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionNavire.Exceptions;

namespace NavireHeritage.ClassesTechniques
{
    public abstract class Test
    {
        public static void ChargementInitial(Port port)
        {
            try
            {
                // Cargos
                port.EnregistrerArriveePrevue(new Cargo("IMO9780859", "CMA CGM A. LINCOLN", "43.43279 N", "134.76258 W", 140872, 148992, 123000, "marchandises diverses"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9250098", "CONTAINERSHIPS VII", "54.35412 N", "5.3644 E", 10499, 13965, 11000, "Matériel de loisirs"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9502910", "MAERSK EMERALD", "54.72202 N", "170.54304 W", 141754, 141189, 137000, "marchandises diverses"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9755933", "MSC DIANA", "39.74224 N", "5.99304 E", 193489, 202036, 176000, "Matériel industriel"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9204506", "HOLANDIA", "41.74844 N", "6.87008 E", 8737, 9113, 7500, "marchandises diverses"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9305893", "VENTO DI ZEFIRO", "41.50706 N", "11.41972 E", 17665, 22033, 0, "Matériel industriel"));

                // Croisiere
                port.EnregistrerArriveePrevue(new Croisière("IMO9241061", "RMS QUEEN MARY 2", "6.93393 N", "88.81366 E", 149215, 19189, 17600, "M", 2620));
                port.EnregistrerArriveePrevue(new Croisière("IMO9803613", "MSC GRANDIOSA", "43.34408 N", "5.32912 E", 177000, 13610, 12000, "M", 6300));
                port.EnregistrerArriveePrevue(new Croisière("IMO9351476", "CRUISE ROMA", "41.2781 N", "3.62948 E", 54310, 7500, 3501, "M", 3501));
                port.EnregistrerArriveePrevue(new Croisière("IMO9007491", "CLUB MED 2", "14.60094 N", "61.06202 W", 14983, 1674, 1567, "V", 386));
                port.EnregistrerArriveePrevue(new Croisière("IMO9783576", "MEIN SCHIFF 2", "14.0138 N", "60.99717 W", 111500, 7900, 7400, "M", 2894));
                port.EnregistrerArriveePrevue(new Croisière("IMO9682875", "HARMONY OF THE SEAS", "20.48245 N", "86.97593 W", 226963, 20236, 17896, "M", 5479));


                // Tanker
                port.EnregistrerArriveePrevue(new Tanker("IMO9220952", "HARAD", "24.1269 N", "36.83576 E", 159990, 303115, 289000, "Crude Oil"));
                port.EnregistrerArriveePrevue(new Tanker("IMO9197832", "KALAMOS", "24.7369 N", "36.23195 E", 149282, 281037, 264000, "Crude Oil"));
                port.EnregistrerArriveePrevue(new Tanker("IMO9288887", "NORDIC FREEDOM", "23.75946 N", "37.70968 E", 83594, 159331, 149000, "Crude Oil"));
                port.EnregistrerArriveePrevue(new Tanker("IMO9405423", "SERENEA", "29.92358 N", "90.13907 W", 81502, 158583, 134000, "Crude Oil"));
                port.EnregistrerArriveePrevue(new Tanker("IMO9334076", "EJNAN", "41.23848 N", "3.83904 E", 95824, 78403, 76000, "iquefied natural gas (LNG)"));
                port.EnregistrerArriveePrevue(new Tanker("IMO9380374", "CITRUS", "25.25954 N", "35.87807 E", 29295, 46938, 42000, "Chemical/Oil Products"));
                port.EnregistrerArriveePrevue(new Tanker("IMO9401570", "GASCHEM RHONE", "41.53079 N", "10.19177 E", 5970, 7341, 5600, "Oil"));
                port.EnregistrerArriveePrevue(new Tanker("IMO9275359", "FUJI LNG", "37.44031 N", "11.00449 E", 118219, 77351, 7509, "iquefied natural gas (LNG)"));
                port.EnregistrerArriveePrevue(new Tanker("IMO9379715", "NEW DRAGON", "26.94883 N", "50.20617 E", 156726, 296370, 265400, "rude Oil Tanker"));
                




            }
            catch (GestionPortExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void TesteEnregistrerArriveePrevue( Port port, Navire navire)
        {
            try
            {
                port.EnregistrerArriveePrevue(navire);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void TestEnregistrerArrivee(Port port, String imo)
        {
            try
            {
                port.EnregistrerArrivee(imo);
                Console.WriteLine("navire " + imo + " arrivé");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 
        internal static void AfficheAttendus(Port port)
        {
            Console.WriteLine("Liste des bateaux en attente de leur arrivée:");
            foreach(Navire navire in port.NavireAttendus.Values)
            {
                Console.WriteLine($"{navire.Imo} \t {navire.Nom} : {navire.GetType().Name}");
            }
        }


        internal static void testEnregistrerDepart(Port port, string v)
        {
            try
            {

                port.EnregistrerDepart(v);
            } catch (GestionPortExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
