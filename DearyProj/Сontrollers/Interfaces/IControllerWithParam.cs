using DearyPetProj.Сontrollers.Navigation.Primitives.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DearyPetProj.Сontrollers.Interfaces
{
    public interface IControllerWithParam<TParam> : IBaseController
        where TParam : IParam
    {
        public void PrepareParam(TParam param);
    }
}
