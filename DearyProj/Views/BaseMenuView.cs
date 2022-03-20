using DearyPetProj.Models.Views;
using DearyPetProj.Privitives.Enums;
using System;
using System.Collections.Generic;

namespace DearyPetProj.Views
{
    public class BaseMenuView : BaseView
    {
        private readonly List<ProgramModeModel> _programModeModelList;

        private int _currentKeyMode = 0;
        private const int LastIndexMode = 6;
        private const int FirstIndexMode = 0;

        public BaseMenuView(List<ProgramModeModel> programModeModelList)
        {
            _programModeModelList = programModeModelList;
            
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


        private void ShowMenu()
        {
            OutputMenu();
            GetMenuMode();
        }

        private void OutputMenu()
        {
            Console.Clear();
            ShowMessage($"Режимы работы ежедневника:{Environment.NewLine}");

            foreach (ProgramModeModel item in _programModeModelList)
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

            NavigateToCurrentMode();
        }

        private void UpdateKeyMode(ConsoleKeyInfo keyPushed)
        {
            if (keyPushed.Key == ConsoleKey.DownArrow)
                CurrentKeyMode++;

            if (keyPushed.Key == ConsoleKey.UpArrow)
                CurrentKeyMode--;

            OutputMenu();
        }


        //TODO добавить метод навигации в базовый класс 
        private void NavigateToCurrentMode()
        {
            switch (CurrentKeyMode)
            {
                case 0:
                    new AddEventView();
                    break;
                case 1:
                    new ChangedEventView();
                    break;
                case 2:
                    new DeleteEventView();
                    break;
                case 3:
                    new ShowEventsEvent();
                    break;
                case 4:
                    new AddPushForEventView();
                    break;
                case 5:
                    new ExportEventView();
                    break;
                case 6:
                    new ExiteView();
                    break;

                default:
                    Console.WriteLine("Что-то пошло не так, выберите режим работы заново!");
                    OutputMenu();
                    break;

            };
        }       
    }
}