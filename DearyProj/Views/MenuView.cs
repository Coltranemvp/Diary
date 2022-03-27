using DearyPetProj.Models.Views;
using DearyPetProj.Privitives.Enums;
using System.Diagnostics;

namespace DearyPetProj.Views
{
    public class MenuView : BaseView
    {
        private readonly int LastIndexMode;
        private readonly List<ProgramModeModel> ProgramModeModelList;
        private const int FirstIndexMode = 0;

        private int _currentKeyMode = 0;
       
        public event Action<MainMenuMode> SelectedMenu;


        public MenuView(List<ProgramModeModel> programModeModelList)
        {
            if (ProgramModeModelList is null)
            {
                Console.WriteLine("Что-то пошло не так...");

                Debug.WriteLine($"{nameof(ProgramModeModelList)} is null");
                Debugger.Break();

                return;
            }

            ProgramModeModelList = programModeModelList;
            LastIndexMode = ProgramModeModelList.Count;

            ShowMenu();
        }


        private int CurrentKeyMode
        {
            get => _currentKeyMode;
            set
            {
                if (value < FirstIndexMode)
                {
                    _currentKeyMode = LastIndexMode;
                    return;
                }

                if (value > LastIndexMode)
                {
                    _currentKeyMode = FirstIndexMode;
                    return;
                }

                _currentKeyMode = value;
            }
        }


        public void ShowMenu()
        {
            OutputMenu();
            GetMenuMode();
        }

        private void OutputMenu()
        {
            Console.Clear();
            ShowMessage($"Режимы работы ежедневника:{Environment.NewLine}");

            foreach (ProgramModeModel item in ProgramModeModelList)
            {
                if (MainMenuMode.Exite == item.Mode)
                    ShowMessage("\n");

                if (CurrentKeyMode == (int)item.Mode)
                {
                    ShowMessage(item.MessageText + "   < ---", ConsoleColor.Red);
                    continue;
                }

                ShowMessage(item.MessageText);
            }
        }

        private void GetMenuMode()
        {
            ConsoleKeyInfo keyPushed;
            bool flagEnter = true;

            do
            {
                keyPushed = Console.ReadKey();
                UpdateKeyMode(keyPushed);

                if (keyPushed.Key == ConsoleKey.Enter)
                    flagEnter = false;

            } while (flagEnter);

            SelectedMenu.Invoke(ProgramModeModelList[CurrentKeyMode].Mode);
        }

        private void UpdateKeyMode(ConsoleKeyInfo keyPushed)
        {
            if (keyPushed.Key == ConsoleKey.DownArrow)
                CurrentKeyMode++;

            if (keyPushed.Key == ConsoleKey.UpArrow)
                CurrentKeyMode--;

            OutputMenu();
        }       
    }
}