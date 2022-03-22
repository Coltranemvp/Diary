using DearyPetProj.Models.Views;
using DearyPetProj.Privitives.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DearyPetProj.Models
{
    public class EventModel
    {
        private List<ProgramModeModel> _programModeModelList = new();

       

        public List<ProgramModeModel> GetProgramList()
        {
            ProgramModeModel programModeModel = new ProgramModeModel();
            programModeModel.Mode = MainMenuMode.AddEvent;
            programModeModel.MessageText = ("Добавить ивент, его дату и время проведения");
            _programModeModelList.Add(programModeModel);

            ProgramModeModel programModeModel1 = new ProgramModeModel();
            programModeModel1.Mode = MainMenuMode.ChangedEvent;
            programModeModel1.MessageText = ("Изменить ивент, его дату и время проведения");
            _programModeModelList.Add(programModeModel1);

            ProgramModeModel programModeModel2 = new ProgramModeModel();
            programModeModel2.Mode = MainMenuMode.DeleteEvent;
            programModeModel2.MessageText = ("Удалить ивент, его дату и время проведения");
            _programModeModelList.Add(programModeModel2);

            ProgramModeModel programModeModel3 = new ProgramModeModel();
            programModeModel3.Mode = MainMenuMode.ShowEvents;
            programModeModel3.MessageText = ("Посмотреть расписание ивентов, их дату и время проведения");
            _programModeModelList.Add(programModeModel3);

            ProgramModeModel programModeModel4 = new ProgramModeModel();
            programModeModel4.Mode = MainMenuMode.AddPushForEvent;
            programModeModel4.MessageText = ("Добавить время уведомления ивента");
            _programModeModelList.Add(programModeModel4);

            ProgramModeModel programModeModel5 = new ProgramModeModel();
            programModeModel5.Mode = MainMenuMode.ExportEvent;
            programModeModel5.MessageText = ("Экспортировать расписание дня в файл");
            _programModeModelList.Add(programModeModel5);

            ProgramModeModel programModeModel6 = new ProgramModeModel();
            programModeModel6.Mode = MainMenuMode.Exite;
            programModeModel6.MessageText = ("Выход из ежедневника");
            _programModeModelList.Add(programModeModel6);

            return _programModeModelList;
        }
    }
}
