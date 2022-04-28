using DearyPetProj.Views.Interfaces;
using DearyPetProj.Сontrollers.Navigation.Primitives;
using DearyPetProj.Сontrollers.Navigation.Primitives.Interfaces;

namespace DearyPetProj.Сontrollers.Interfaces
{
    public interface IBaseController
    {       

        bool Start();

        bool Active { get; set; }

    }
}
