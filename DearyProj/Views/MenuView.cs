using DearyPetProj.Models.Views;
using DearyPetProj.Privitives.Enums;
using System.Diagnostics;

namespace DearyPetProj.Views
{
    public sealed class MenuView : BaseView
    {
        private int LastIndexMode;
        private  List<ProgramModeModel> _programModeModelList;
        private const int FirstIndexMode = 0;

        private DateTime _dateTimeNow;
        private int _currentKeyMode = 0;

        public event Action<MainMenuMode> MenuChange;

        private static MenuView _instance;
        private static object syncRoot = new();
        private static object syncUpdate = new();

        

        private MenuView()
        {

        }

        public void SetProgramMode(List<ProgramModeModel> programModelList)
        {
            if (programModelList is null)
            {
                Console.WriteLine("Что-то пошло не так...");

                Debug.WriteLine($"{nameof(_programModeModelList)} is null");
                Debugger.Break();

                return;
            }

            _programModeModelList = programModelList;
            LastIndexMode = _programModeModelList.Count - 1;

            Active = true;
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

        protected override void UnsubscribingEvents()
        {            
            ChangeActiveState -= ChangeActiveState_UpdateData;
        }


        protected override void SubscribingEvents()
        {
            ChangeActiveState += ChangeActiveState_UpdateData;
        }


        public static MenuView InitInstance()
        {
            if (_instance is null)
            {
                lock (syncRoot)
                {
                    if (_instance is null)
                        _instance = new MenuView();
                }
            }
            return _instance;
        }


        private async Task DataUpdate()
        {
            await Task.Run(() => innerDataUpdate());

            void innerDataUpdate()
            {
                do
                {
                    _dateTimeNow = DateTime.Now;
                    OutputMenu();
                    Thread.Sleep(1000);
                } while (Active);
            }
        }


        public override bool ShowView()
        {
            if (_programModeModelList is null)
            {
                ShowMessage("Что-то пошло не так...");                

                Debug.WriteLine($"{nameof(_programModeModelList)} is null");

                Debugger.Break();
                Console.ReadKey();

                return false;
            }

            OutputMenu();
            GetMenuMode();

            return true;
        }


        private void OutputMenu()
        {
            lock (syncUpdate)
            {
                Console.Clear();
                ShowMessage($"Режимы работы ежедневника:{Environment.NewLine} {Environment.NewLine}");
                ShowMessage($"Текущая дата: {_dateTimeNow} {Environment.NewLine}{Environment.NewLine}");

                foreach (ProgramModeModel item in _programModeModelList)
                {
                    if (MainMenuMode.Exite == item.Mode)
                        ShowMessage(Environment.NewLine);

                    if (CurrentKeyMode == (int)item.Mode)
                    {
                        ShowMessage(item.MessageText + "   < ---", ConsoleColor.Red);
                        continue;
                    }

                    ShowMessage(item.MessageText);
                }
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

            MenuChange.Invoke(_programModeModelList[CurrentKeyMode].Mode);
        }

        private void UpdateKeyMode(ConsoleKeyInfo keyPushed)
        {
            if (keyPushed.Key == ConsoleKey.DownArrow)
                CurrentKeyMode++;

            if (keyPushed.Key == ConsoleKey.UpArrow)
                CurrentKeyMode--;

            OutputMenu();
        }

        private void ChangeActiveState_UpdateData()
        {
            if (Active)
                DataUpdate();
        }
    }
}