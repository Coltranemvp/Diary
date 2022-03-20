using DearyPetProj.Сontrollers.Interfaces;
using DearyPetProj.Сontrollers.Navigation.Primitives.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DearyPetProj.Сontrollers.Extensions
{
    public static class BaseControllerExtensions
    {

        public static void NavigateTo(this BaseController baseController, IControllerWithoutParamResult newController)
        {
            newController.Start();
        }

        public static void NavigateTo<TParam>(this BaseController baseController, IControllerWithParam<TParam> newController, TParam param)
            where TParam : IParam
        {
            newController.PrepareParam(param);
            newController.Start();
        }

        public static T NavigateTo<T>(this BaseController baseController, IControllerWithResult<T> newController)
            where T : IResult
        {
            newController.Start();
            return newController.GetResult();
        }

        public static IResult NavigateTo<TParam, TResult>(this BaseController baseController, IControllerWithParamResult<TParam, TResult> newController, TParam param)
            where TParam : IParam
            where TResult : IResult
        {
            newController.PrepareParam(param);
            newController.Start();
            return newController.GetResult();
        }
    }
}
