using DearyPetProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DearyPetProj.Views
{
    public class AddEventView : BaseView
    {
        private const string AddEventNameText = "Введите название мероприятия";
        private const string AddDateEventText = "Введите время начал мероприятия";
        private const string AddPushTimeEventText = "Введите время за которое нужно уведометь о начале мероприятия";

        public event Action<EventModel> SelectedMenu;
        public AddEventView()
        {

        }

        public override bool ShowView()
        {
            ShowMessage(AddEventNameText);
            GetEventModel();

            return true;
        }

        private EventModel GetEventModel()
        {
            Console.ReadKey();
            return new EventModel();
        }
    }
}
