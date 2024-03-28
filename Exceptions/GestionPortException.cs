// <copyright file="Navire.cs" company="GILABERT_Theo">
// Copyright (c) GILABERT_Theo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace GestionNavire.Exceptions
{
    class GestionPortExceptions : Exception
    {
        public GestionPortExceptions(string message)
            : base("Erreur de : " + System.Environment.UserName + " le " + DateTime.Now.ToLocalTime() + "\n" + message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
    }
}