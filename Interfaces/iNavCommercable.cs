﻿// <copyright file="Navire.cs" company="GILABERT_Theo">
// Copyright (c) GILABERT_Theo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Interfaces
{
    interface iNavCommercable
    {
        void Decharger(int qte);
        void Charger(int qte);
    }
}
