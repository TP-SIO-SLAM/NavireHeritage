// <copyright file="Navire.cs" company="GILABERT_Theo">
// Copyright (c) GILABERT_Theo. All rights reserved.
// </copyright>

using NavireHeritage.classesMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Interfaces
{
    interface ICroisierable
    {
        void Embarquer(List<Passager> passagers);
        List<Passager> Debarquer(List<Passager> objects);

    }
}
