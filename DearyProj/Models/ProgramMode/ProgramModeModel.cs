using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DearyPetProj.Privitives.Enums;

namespace DearyPetProj.Models.ProgramMode
{
    public class ProgramModeModel
    {

        public List<ProgramMode> GetProgramList()
        {
            List<ProgramMode> _programModeModelList = new();

            ProgramMode programModeModel = new ProgramMode();
            programModeModel.Mode = MainMenuMode.AddEvent;
            programModeModel.MessageText = ("Добавить ивент, его дату и время проведения");
            _programModeModelList.Add(programModeModel);

            ProgramMode programModeModel1 = new ProgramMode();
            programModeModel1.Mode = MainMenuMode.ChangedEvent;
            programModeModel1.MessageText = ("Изменить ивент, его дату и время проведения");
            _programModeModelList.Add(programModeModel1);

            ProgramMode programModeModel2 = new ProgramMode();
            programModeModel2.Mode = MainMenuMode.DeleteEvent;
            programModeModel2.MessageText = ("Удалить ивент, его дату и время проведения");
            _programModeModelList.Add(programModeModel2);

            ProgramMode programModeModel3 = new ProgramMode();
            programModeModel3.Mode = MainMenuMode.ShowEvents;
            programModeModel3.MessageText = ("Посмотреть расписание ивентов, их дату и время проведения");
            _programModeModelList.Add(programModeModel3);

            ProgramMode programModeModel4 = new ProgramMode();
            programModeModel4.Mode = MainMenuMode.AddPushForEvent;
            programModeModel4.MessageText = ("Добавить время уведомления ивента");
            _programModeModelList.Add(programModeModel4);

            ProgramMode programModeModel5 = new ProgramMode();
            programModeModel5.Mode = MainMenuMode.ExportEvent;
            programModeModel5.MessageText = ("Экспортировать расписание дня в файл");
            _programModeModelList.Add(programModeModel5);

            ProgramMode programModeModel6 = new ProgramMode();
            programModeModel6.Mode = MainMenuMode.Exite;
            programModeModel6.MessageText = ("Выход из ежедневника");
            _programModeModelList.Add(programModeModel6);

            return _programModeModelList;
        }
    }
}