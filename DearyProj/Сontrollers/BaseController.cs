using DearyPetProj.Views.Interfaces;
using DearyPetProj.Сontrollers.Interfaces;
using DearyPetProj.Сontrollers.Navigation.Primitives.Interfaces;

namespace DearyPetProj.Сontrollers
{
    public abstract class BaseController : IBaseController, IDisposable
    {
        public readonly IBaseView View;

        private bool _active;
        private bool _disposedValue;
        
        public event Action ChangeActiveState;



        public BaseController(IBaseView view)
        {
            View = view;

            SubscribingEvents();
            Active = true;
        }



        public bool Active
        {
            get => _active;
            set
            {
                if (_active != value)
                {
                    _active = value;
                    ChangeActiveState?.Invoke();
                }
            }
        }


        public abstract bool Start();


        public void Dispose() => Dispose(true);


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                    UnsubscribingEvents();

                _disposedValue = true;
            }
        }


        private void UnsubscribingEvents()
        {
            ChangeActiveState -= ChangeActiveState_Changed;
        }


        private void SubscribingEvents()
        {
            ChangeActiveState += ChangeActiveState_Changed;
        }


        private void ChangeActiveState_Changed()
        {
            if (_active)
            {
                View.Active = true;
                return;
            }

            View.Active = false;           
        }
    }



    /// <summary>
    /// BaseController is for navigation without Param and Result
    /// </summary>

    public abstract class ControllerWithoutParamResult : BaseController, IControllerWithoutParamResult
    {
        public ControllerWithoutParamResult(IBaseView view) : base(view)
        {
            //nothing here...
        }
    }



    /// <summary>
    /// BaseController is for navigation with Result
    /// </summary>
    /// <typeparam name="TResult"></typeparam>

    public abstract class ControllerResult<TResult> : BaseController, IControllerWithResult<TResult>
        where TResult : IResult
    {
        public ControllerResult(IBaseView view) : base(view)
        {
            //nothing here...
        }



        public abstract TResult GetResult();
    }



    /// <summary>
    /// BaseController is for navigation with Param
    /// </summary>
    /// <typeparam name="TParam"></typeparam>

    public abstract class ControllerParam<TParam> : BaseController, IControllerWithParam<TParam>
        where TParam : IParam
    {
        public ControllerParam(IBaseView view) : base(view)
        {
            //nothing here...
        }



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
        public ControllerWithParamResult(IBaseView view) : base(view)
        {
            //nothing here...
        }



        public abstract TResult GetResult();

        public abstract void PrepareParam(TParam param);
    }
}