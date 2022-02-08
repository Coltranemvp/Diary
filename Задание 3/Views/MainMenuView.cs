using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryProject.Views
{
    public  class MainMenuView : BaseView
    {
        public MainMenuView(bool appStart) 
        {
            if (!appStart)
                throw new Exception(message: $"{ToString()} создался до того, как запустился проект");

            
        }
    }
}
