using DearyPetProj.Views.Interfaces;
using DearyPetProj.Сontrollers.Interfaces;
using DearyPetProj.Сontrollers.Navigation.Primitives;
using DearyPetProj.Сontrollers.Navigation.Primitives.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DearyPetProj.Сontrollers
{
    public class ShowEventsController : BaseController
    {
        public ShowEventsController(IBaseView view) : base(view)
        {
        }

        public override bool Start()
        {
            throw new NotImplementedException();
        }
    }


}
