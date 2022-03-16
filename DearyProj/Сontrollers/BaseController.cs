using DiaryProject.Сontrollers.Interfaces;
using DiaryProject.Сontrollers.Navigation.Primitives;
using DiaryProject.Сontrollers.Navigation.Primitives.Interfaces;
using System.Collections.Generic;

namespace DiaryProject.Сontrollers
{
    public class BaseController : IBaseController
    {
        private IParam _param;
        
      
        
        
        /// <summary>
        /// вызвать ассихроно -> создать экземляр контроллера в котором вызывуться основные методы -> вернуть результат после, вызвав метод возвращающий Tresult
        /// </summary>
        public BaseController ()
        {
        }

        public virtual void PrepareParam(IParam param)
        {
            _param = param;
        }
        

    }

    public static class BaseControllerExtensions
    {
         
        public static void  NavigateTo<T> (this BaseController baseController) where T : IBaseController, new()
        {
            IBaseController newController = new T ();
        }

        public static void NavigateTo<T, P>(this BaseController baseController, IParam param) 
            where T : IBaseController, new()
            where P : BaseParam
        {
            IBaseController newController = new T();
            newController.PrepareParam(param);
            newController.Start();
        }

        public static void NavigateBack<T>(this BaseController baseController) where T : IBaseController, new()
        {
            IBaseController newController = new T();
            BaseController.navigateWay.;
        }
    }
}
