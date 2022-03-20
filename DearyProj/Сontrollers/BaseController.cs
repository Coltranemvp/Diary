using DearyPetProj.Сontrollers.Interfaces;
using DearyPetProj.Сontrollers.Navigation.Primitives.Interfaces;

namespace DearyPetProj.Сontrollers
{
    public abstract class BaseController : IBaseController
    {  
        public BaseController()
        {
            //nothing here...
        }


        public abstract void Start();


        public abstract void SetNavigationWay();
    }

    /// <summary>
    /// BaseController is for navigation without Param and Result
    /// </summary>
    
    public abstract class ControllerWithoutParamResult : BaseController, IControllerWithoutParamResult
    {
        public abstract override void SetNavigationWay();

        public abstract override void Start();
    }

    /// <summary>
    /// BaseController is for navigation with Result
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    
    public abstract class ControllerResult<TResult> : BaseController, IControllerWithResult<TResult>
        where TResult : IResult
    {
        public abstract TResult GetResult();
    }

    /// <summary>
    /// BaseController is for navigation with Param
    /// </summary>
    /// <typeparam name="TParam"></typeparam>
    
    public abstract class ControllerParam<TParam> : BaseController, IControllerWithParam<TParam>
        where TParam : IParam
    {

        public abstract void PrepareParam(TParam param);
    }

    /// <summary>
    ///  BaseController is for navigation with Param and Result
    /// </summary>
    /// <typeparam name="TParam"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    
    public abstract class ControllerWithParamResult<TParam, TResult> : BaseController, IControllerWithParamResult<TParam, TResult>
         where TParam : IParam
         where TResult : IResult
    {
        public abstract TResult GetResult();

        public abstract void PrepareParam(TParam param);
    }    
}