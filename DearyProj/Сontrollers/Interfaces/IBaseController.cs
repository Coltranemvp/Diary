using DiaryProject.Сontrollers.Navigation.Primitives;
using DiaryProject.Сontrollers.Navigation.Primitives.Interfaces;

namespace DiaryProject.Сontrollers.Interfaces
{
    public interface IBaseController
    {
        public void PrepareParam(IParam param);

    }

    public interface IBaseController<P, R> : IBaseController 
        where P : BaseParam
        where R : BaseResult
    {

    }
}
