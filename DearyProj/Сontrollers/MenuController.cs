using DearyPetProj.Models;
using DearyPetProj.Models.ProgramMode;
using DearyPetProj.Privitives.Enums;
using DearyPetProj.Views;
using DearyPetProj.Views.Interfaces;
using DearyPetProj.Сontrollers.Extensions;
using System.Diagnostics;
using System.IO.Pipes;

namespace DearyPetProj.Сontrollers
{
    public sealed class MenuController : BaseController
    {
        private static MenuController instance;
        private ProgramModeModel _programtModel;
        private static object syncRoot = new();


        private MenuController(IBaseView view) : base(view)
        {

        }

        public static MenuController GetInstance()
        {
            if (instance is null)
            {
                lock (syncRoot)
                {
                    if (instance is null)
                        instance = new MenuController(MenuView.InitInstance());
                }
            }
            return instance;
        }

        public override bool Start()
        {
            if (View is MenuView menuView)
            {
                _programtModel = new ProgramModeModel();
                var response = _programtModel.GetProgramList();

                menuView.SetProgramMode(response);
                menuView.MenuChange += SelectedMenu_NavigateToCurrentMode;
                bool showFlag = menuView.ShowView();

                if (!showFlag)
                    return false;

                return true;
            }

            return false;
        }

        private void SelectedMenu_NavigateToCurrentMode(MainMenuMode currentKeyMode)
        {
            this.Active = false;

            switch (currentKeyMode)
            {
                case MainMenuMode.AddEvent:
                    NavigationToAddEventController();
                    break;

                case MainMenuMode.ChangedEvent:
                    //new ChangedEventController();
                    break;

                case MainMenuMode.DeleteEvent:
                    // new DeleteEventController();
                    break;

                case MainMenuMode.ShowEvents:
                    // new ShowEventsController();
                    break;

                case MainMenuMode.AddPushForEvent:
                    //  new AddPushForEventController();
                    break;

                case MainMenuMode.ExportEvent:
                    NavigationToExportEventController();
                    break;

                case MainMenuMode.Exite:
                    // new ExiteController();
                    break;

                default:
                    ErrorNavigation();
                    break;
            };

            MenuView.InitInstance().ShowView();

            void ErrorNavigation()
            {
                Debug.WriteLine($"{nameof(currentKeyMode)} is unknow type");
                Debugger.Break();
            }
        }

        private void NavigationToAddEventController()
        {
            var navigationResult = this.NavigateTo(new AddEventController(new AddEventView()));
        }

        private void NavigationToExportEventController()
        {
            var param = new ExportEventController.Param(new UserEvent());
            this.NavigateTo(new ExportEventController(new ExportEventView()), param);
        }
    }
}