using DearyPetProj.Сontrollers.Navigation.Primitives.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DearyPetProj.Сontrollers.Interfaces
{
    public interface IControllerWithParamResult<TParam,TResult> : IControllerWithParam<TParam>, IControllerWithResult<TResult>
        where TParam : IParam
        where TResult : IResult
    {
        //nothing here...
    }
}
