using DearyPetProj.Views;
using DearyPetProj.Сontrollers.Extensions;
using DearyPetProj.Сontrollers.Navigation.Primitives;
using DearyPetProj.Сontrollers.Navigation.Primitives.Interfaces;
using DearyPetProj.Models.Views;
using DearyPetProj.Privitives.Enums;

namespace DearyPetProj.Сontrollers
{
    public class BaseMenuController : BaseController
    {
        private readonly List<ProgramModeModel> _programModeModelList = new();
        private static BaseMenuController instance;
        private static object syncRoot = new();


        private BaseMenuController()
        {
            var asd = new AddEventController();

            var ass = new ShowEventController<BaseParam>();
            this.NavigateTo<BaseParam>(ass, new BaseParam());


           
            var naviResult = this.NavigateTo<Result>(asd);
            Console.WriteLine(naviResult.Message);
            Console.ReadKey();
           
            Start();
        }

        public static BaseMenuController GetInstance()
        {
            if (instance is null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new BaseMenuController();
                }
            }
            return instance;
        }

        public override void Start()
        {
            TestProgramList();
            BaseMenuView baseMenuView = new BaseMenuView(_programModeModelList);
        }

        public override void SetNavigationWay()
        {
            throw new NotImplementedException();
        }


        // Тестовые данные               --             ----                   ---

        private void TestProgramList()
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
        }
    }
}
