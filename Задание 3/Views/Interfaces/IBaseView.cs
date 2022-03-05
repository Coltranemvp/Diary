using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryProject.Views.Interfaces
{
    public interface IBaseView
    {
        void ShowMessage(string messageText, ConsoleColor consoleColor);
        string GetUserResponse();
    }
}
