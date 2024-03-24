using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Interfaces
{
    interface Istationable
    {
        void EnregistrerArriveePrevue(object objet);
        void EnregistrerArrivee(String id);
        void EnregistrerDepart(String id);

        bool EstAttendu(String id);
        bool EstPresent(String id);
        bool EstParti(String id);
        object GetUnAttendu(String id);
        object GetUnArrive(String id);
        object GetUnParti(String id);
    
    }
}
