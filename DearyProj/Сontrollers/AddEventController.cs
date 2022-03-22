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
    public class AddEventController : ControllerResult<Result>
    {
        public override Result GetResult()
        {
            throw new NotImplementedException();
        }

        public override void SetNavigationWay()
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            Console.WriteLine("AddEventController");
            Console.ReadLine();
        }
       
    }

    public class Result : BaseResult
    {
        public Result(string message, bool reject = false) : base(reject)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
