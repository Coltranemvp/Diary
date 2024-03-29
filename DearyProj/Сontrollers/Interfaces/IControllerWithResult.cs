﻿using DearyPetProj.Сontrollers.Navigation.Primitives.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DearyPetProj.Сontrollers.Interfaces
{
    public interface IControllerWithResult<T> : IBaseController    
        where T : IResult
    {
        public T GetResult();
    }
}
