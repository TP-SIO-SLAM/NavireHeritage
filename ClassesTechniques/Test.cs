// <copyright file="Navire.cs" company="GILABERT_Theo">
// Copyright (c) GILABERT_Theo. All rights reserved.
// </copyright>

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
                // cargos
                port.EnregistrerArriveePrevue(new Cargo("IMO9780859", "CMA CGM A. LINCOLN", "43.43279 N", "134.76258 W",
                        140872, 148992, 123000, "marchandises diverses"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9250098", "CONTAINERSHIPS VII", "54.35412 N", "5.3644 E", 10499,
                        13965, 11000, "Matériel de loisirs"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9502910", "MAERSK EMERALD", "54.72202 N", "170.54304 W", 141754,
                        141189, 137000, "marchandises diverses"));

                // croisiere
                port.EnregistrerArriveePrevue(new Croisiere("IMO9241061", "RMS QUEEN MARY 2", "6.93393 N", "88.81366 E",
                        149215, 19189, 17600, "M", 2620));
                port.EnregistrerArriveePrevue(new Croisiere("IMO9803613", "MSC GRANDIOSA", "43.34408 N", "5.32912 E",
                        177000, 13610, 12000, "M", 6300));
                port.EnregistrerArriveePrevue(
                        new Croisiere("IMO9351476", "CRUISE ROMA", "41.2781 N", "3.62948 E", 54310, 7500, 3501, "M", 3501));

                // tankers
                port.EnregistrerArriveePrevue(new Tanker("IMO9334076", "EJNAN", "41.23848 N", "3.83904 E", 95824, 78403,
                        76000, "Liquefied natural gas (LNG)"));
                port.EnregistrerArriveePrevue(new Tanker("IMO9380374", "CITRUS", "25.25954 N", "35.87807 E", 29295, 46938,
                        42000, "Chemical/Oil Products"));
                port.EnregistrerArriveePrevue(
                        new Tanker("IMO9220952", "HARAD", "24.1269 N", "36.83576 E", 159990, 303115, 289000, "Crude Oil"));
                port.EnregistrerArriveePrevue(new Tanker("IMO9197832", "KALAMOS", "24.7369 N", "36.23195 E", 149282, 281037,
                        264000, "Crude Oil"));
                port.EnregistrerArriveePrevue(new Tanker("IMO9379715", "NEW DRAGON", "26.94883 N", "50.20617 E", 156726,
                        296370, 265400, "rude Oil Tanker"));

            }
            catch (GestionPortExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void TestEnregistrerArriveePrevue(Port port, Navire navire)
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AfficheAttendus(Port port)
        {
            Console.WriteLine("Liste des bateaux en attente de leur arrivée : ");
            foreach (Navire navire in port.NavireAttendus.Values)
            {
                Console.WriteLine(navire);
            }
        }


        public static void TestEnregistrerDepart(Port port, String imo)
        {
            try
            {
                port.EnregistrerDepart(imo);
                Console.WriteLine("navire " + imo + " parti");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
