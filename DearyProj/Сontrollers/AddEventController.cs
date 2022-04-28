using DearyPetProj.Models;
using DearyPetProj.Views;
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
    public class AddEventController : ControllerResult<Result>
    {

        private Result _result = new("");

        public AddEventController(IBaseView view) : base(view)
        {

        }
        public override Result GetResult()
        {
            return _result;
        }



        public override bool Start()
        {
            View.ShowView();

            return true;
        }

         

    }

    public class Result : BaseResult
    {
        private EventModel _eventModel;
        private string _message;

        public Result(string message, bool reject = false) : base(reject)
        {
            Message = message;
        }

        public string Message
        {
            get => _message;
            set => _message = value;
        }

        public EventModel EventModel
        {
            get => _eventModel;
            set => _eventModel = value;
        }
    }
}
