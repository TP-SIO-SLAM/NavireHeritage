using GestionNavire.Exceptions;
using NavireHeritage.classesMetier;
using NavireHeritage.ClassesTechniques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Port port = new Port("Marseille", "43.2976N", "5.3471E", 4, 4, 3, 2);
                Test.ChargementInitial(port);
                Console.WriteLine(port);


                Console.WriteLine("---------------------------------------------");
                Test.AfficheAttendus(port);
                Console.WriteLine("---------------------------------------------");

                Test.TesteEnregistrerArriveePrevue(port, new Cargo("IMO9780859", "CMA CGM A. LINCOLN", "43.43279 N", "134.76258 W",
                140872, 148992, 123000, "marchandises diverses"));
                
                Test.TestEnregistrerArrivee(port, "IMO9241061");
                Test.TestEnregistrerArrivee(port, "IMO0000000");
                Test.TestEnregistrerArrivee(port, "IMO9241061");
                Test.TestEnregistrerArrivee(port, "IMO9334076");
                Test.TestEnregistrerArrivee(port, "IMO9197832");
                Test.TestEnregistrerArrivee(port, "IMO9220952");
                Test.TestEnregistrerArrivee(port, "IMO9379715");

                Test.testEnregistrerDepart(port, "IMO9197822");
                Test.testEnregistrerDepart(port, "IMO9241061");
                Test.testEnregistrerDepart(port, "IMO9334076");
                Test.testEnregistrerDepart(port, "IMO9197832");

                Test.TesteEnregistrerArriveePrevue(port, new Cargo("IMO9755933", "MSC DIANA", "39.74224 N", "5.99304 E",
                        193489, 202036, 176000, "Matériel industriel"));
                Test.TesteEnregistrerArriveePrevue(port, new Cargo("IMO9204506", "HOLANDIA", "41.74844 N", "6.87008 E",
                        8737, 9113, 7500, "marchandises diverses"));

                Test.TestEnregistrerArrivee(port, "IMO9780859");
                Test.TestEnregistrerArrivee(port, "IMO9250098");
                Test.TestEnregistrerArrivee(port, "IMO9502910");
                Test.TestEnregistrerArrivee(port, "IMO9755933");
                Test.TestEnregistrerArrivee(port, "IMO9204506");

                Test.testEnregistrerDepart(port, "IMO9220952");
                Test.testEnregistrerDepart(port, "IMO9755933");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(port);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Fin normale du programme...");

                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur " + ex.Message);
            }
            
            Console.ReadKey();
        }
    }
}
