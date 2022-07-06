using DearyPetProj.Models;
using DearyPetProj.Views.Interfaces;
using DearyPetProj.Сontrollers.Navigation.Primitives;
using System.Text;
using static DearyPetProj.Сontrollers.ExportEventController;

namespace DearyPetProj.Сontrollers
{
    public class ExportEventController : ControllerParam<Param>
    {
        private const string DefaultFileName = "Список_Мероприятий";
        private UserEvent _userEvent;


        public event Action<string> RecordEventsFinished;


        public ExportEventController(IBaseView view) : base(view)
        {

        }


        public override void PrepareParam(Param param)
        {
            _userEvent = param.UserEvent;
        }


        public override bool Start()
        {
            if (_userEvent == null)
                return false;

            string fileName = CreateFileName(_userEvent);
            string path = CreateFilePath(fileName);
            StringBuilder eventReport = CreateEventReport(_userEvent);

            RecordEventInFile(path, eventReport);

            return true;
        }


        private async Task RecordEventInFile(string path, StringBuilder EventText)
        {
            bool flagRecord = false;

            using (FileStream fstream = new(path, FileMode.OpenOrCreate))
            {
                byte[] textEventBuffer = Encoding.Default.GetBytes(EventText.ToString());

                await fstream.WriteAsync(textEventBuffer, 0, textEventBuffer.Length);

                flagRecord = true;
            }

            if (flagRecord)
                RecordEventsFinished?.Invoke("Файл успешно записан");
            else
                RecordEventsFinished?.Invoke("Файл не записался, попробуйти заново");
        }


        private StringBuilder CreateEventReport(UserEvent userEvent)
        {
            StringBuilder EventReport = new StringBuilder();
            return EventReport;
        }


        private string CreateFilePath(string fileName)
        {
            string path = Directory.GetCurrentDirectory();

            fileName = fileName is null ? DefaultFileName : fileName;
            path = Directory.GetParent(path)?.FullName + $"\\{fileName}.doc";

            return path;
        }


        private string CreateFileName(UserEvent userEvent)
        {
            return userEvent.NameEvent;
        }


        public class Param : BaseParam
        {
            public Param(UserEvent userEvent)
            {
                UserEvent = userEvent;
            }

            public UserEvent UserEvent { get; set; }
        }
    }
}