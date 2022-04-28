using DearyPetProj.Сontrollers.Interfaces;
using DearyPetProj.Сontrollers.Navigation.Primitives.Interfaces;

namespace DearyPetProj.Сontrollers.Extensions
{
    public static class BaseControllerExtensions
    {

        public static void NavigateTo(this BaseController baseController, IControllerWithoutParamResult newController)
        {
            baseController.Active = false;

            newController.Start();

            baseController.Active = true;
        }

        public static void NavigateTo<TParam>(this BaseController baseController, IControllerWithParam<TParam> newController, TParam param)
            where TParam : IParam
        {
            baseController.Active = false;

            newController.PrepareParam(param);
            newController.Start();

            baseController.Active = true;
        }

        public static T NavigateTo<T>(this BaseController baseController, IControllerWithResult<T> newController)
            where T : IResult
        {
            baseController.Active = false;           

            newController.Start();            

            baseController.Active = true;

            return newController.GetResult();


        }

        public static IResult  NavigateTo<TParam, TResult> (this BaseController baseController,
            IControllerWithParamResult<TParam, TResult> newController, TParam param)
            where TParam : IParam
            where TResult : IResult
        {
            baseController.Active = false;

            newController.PrepareParam(param);
            newController.Start();            

            baseController.Active = true;

            return newController.GetResult();
        }
    }
}