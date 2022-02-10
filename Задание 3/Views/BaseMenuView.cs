using DiaryPetProject.Models.VIews;
using DiaryPetProject.Privitives.Enums;
using System;
using System.Collections.Generic;

namespace DiaryProject.Views
{
    public class BaseMenuView : BaseView
    {
        private readonly List<ProgramModeModel> programModeModelList;

        private int KeyMode = 0;

        public BaseMenuView(bool appStart)
        {
            if (!appStart)
                throw new Exception(message: $"{ToString()} создался до того, как запустился проект");

            programModeModelList = new List<ProgramModeModel>();

            TestProgramList();

            ShowMenu();
        }

        private void ShowMenu()
        {
            Console.Clear();
            ShowMessage("Режимы работы ежедневника:");

            foreach (ProgramModeModel item in programModeModelList)
            {
                ShowMessage(item.MessageText);
            }

            GetMenuMode();
        }

        private void GetMenuMode()
        {
            ConsoleKeyInfo keyPushed;
            bool flagEnter = true;

            do
            {
                keyPushed = Console.ReadKey();
                GetKeyMode(keyPushed);

                if (keyPushed.Key == ConsoleKey.Enter)
                    flagEnter = false;

            } while (flagEnter);
        }

        private void GetKeyMode(ConsoleKeyInfo keyPushed)
        {
            if (keyPushed.Key == ConsoleKey.DownArrow)
                KeyMode--;

            if (keyPushed.Key == ConsoleKey.UpArrow)
                KeyMode++;
        }


        // Тестовые данные               --             ----                   ---

        private void TestProgramList()
        {
            ProgramModeModel programModeModel = new ProgramModeModel();

            programModeModel.Mode = MainMenuMode.AddEvent;
            programModeModel.MessageText = ("1) Ты можешь добавить ивент, его дату и время прохождения.");
            programModeModelList.Add(programModeModel);

            ProgramModeModel programModeModel1 = new ProgramModeModel();
            programModeModel1.Mode = MainMenuMode.Changed;
            programModeModel1.MessageText = ("2) Ты можешь изменить ивент, его дату и время прохождения.");
            programModeModelList.Add(programModeModel);

            ProgramModeModel programModeModel2 = new ProgramModeModel();
            programModeModel2.Mode = MainMenuMode.DeleteEvent;
            programModeModel2.MessageText = ("3) Ты можешь удалить ивент, его дату и время прохождения.");
            programModeModelList.Add(programModeModel2);

            ProgramModeModel programModeModel3 = new ProgramModeModel();
            programModeModel3.Mode = MainMenuMode.WatchEvents;
            programModeModel3.MessageText = ("4) Ты можешь посмотреть расписание ивентов, их дату и время прохождения.");
            programModeModelList.Add(programModeModel3);

            ProgramModeModel programModeModel4 = new ProgramModeModel();
            programModeModel4.Mode = MainMenuMode.AddPushForEvent;
            programModeModel4.MessageText = ("5) Ты можешь добавить время уведомления ивента.");
            programModeModelList.Add(programModeModel4);

            ProgramModeModel programModeModel5 = new ProgramModeModel();
            programModeModel5.Mode = MainMenuMode.ExportEvent;
            programModeModel5.MessageText = ("6) Ты можешь экспортировать расписание дня в файл.");
            programModeModelList.Add(programModeModel5);

            ProgramModeModel programModeModel6 = new ProgramModeModel();
            programModeModel6.Mode = MainMenuMode.Exite;
            programModeModel6.MessageText = ("7) Выход из ежедневника.");
            programModeModelList.Add(programModeModel6);
        }
    }
}