using DearyPetProj.Сontrollers.Interfaces;
using DearyPetProj.Сontrollers.Navigation.Primitives;
using DearyPetProj.Сontrollers.Navigation.Primitives.Interfaces;
using System.Collections.Generic;

namespace DearyPetProj.Сontrollers
{
    public abstract class BaseController : IBaseController
    {
        private IParam _param;
        private IResult _result;


        /// <summary>
        /// вызвать ассихроно -> создать экземляр контроллера в котором вызывуться основные методы -> вернуть результат после, вызвав метод возвращающий Tresult
        /// </summary>
        public BaseController()
        {
           //nothing here...
        }


        public IResult GetResult()
        {
            return _result;
        }


        public virtual void PrepareParam(IParam param)
        {
            _param = param;
        }


        public abstract void Start();
    }


    public static class BaseControllerExtensions
    {

        public static void NavigateTo(this BaseController baseController, IBaseController newController)
        {
            newController.Start();
        }

        public static void NavigateTo(this BaseController baseController, IBaseController newController, IParam param)
        {
            newController.PrepareParam(param);
            newController.Start();
        }

        public static void NavigateTo(this BaseController baseController, IBaseController newController, out IResult result)
        {
            newController.Start();
            result = newController.GetResult();
        }

        public static void NavigateTo(this BaseController baseController, IBaseController newController, IParam param, out IResult result)
        {
            newController.PrepareParam(param);
            newController.Start();
            result = newController.GetResult();
        }
    }
}
