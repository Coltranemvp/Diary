using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DearyPetProj
{
    interface IEvent
    {
        void ChangeEvent();
        void DeleteEvent();
        void ShowEvent();
        void AddPushEvent();
        void ExportEvent();
        void AddEvent();
        void PushCheaker(object obj);

    }
}
