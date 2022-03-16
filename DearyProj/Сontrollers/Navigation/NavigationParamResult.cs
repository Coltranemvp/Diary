using DiaryProject.Сontrollers.Interfaces;
using DiaryProject.Сontrollers.Navigation.Primitives;

namespace DiaryProject.Сontrollers.Navigation
{
    public class Navigation<TParam, TResult> 
        where TParam : BaseParam 
        where TResult : BaseResult
    {
        public Navigation() { }
        
        public void  NavigateTo(IBaseController controller, TParam param) 
        {
           
        }
    }

}
