using DearyPetProj.Сontrollers.Navigation.Primitives;
using DearyPetProj.Сontrollers.Navigation.Primitives.Interfaces;

namespace DearyPetProj.Сontrollers.Interfaces
{
    public interface IBaseController
    {
        public void PrepareParam(IParam param);

        public IResult GetResult();

        public void Start();

    }

    public interface IBaseController<P, R> : IBaseController 
        where P : BaseParam
        where R : BaseResult
    {

    }
}
