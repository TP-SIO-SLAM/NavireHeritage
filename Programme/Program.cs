// <copyright file="Navire.cs" company="GILABERT_Theo">
// Copyright (c) GILABERT_Theo. All rights reserved.
// </copyright>

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


                Test.AfficheAttendus(port);

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
