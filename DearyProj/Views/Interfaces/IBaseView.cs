using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DearyPetProj.Views.Interfaces
{
    public interface IBaseView
    {
        bool Active { get; set; }

        void ShowMessage(string messageText, ConsoleColor consoleColor);

        string GetUserResponse();

        bool ShowView();
    }
}
