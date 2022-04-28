using DearyPetProj.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DearyPetProj.Views
{
    public abstract class BaseView : IBaseView, IDisposable
    {
        private const string RepeatText = "Вы ввели пустое значение, повторите ввод!";
        private bool _active;
        private bool _disposedValue;

        public event Action ChangeActiveState;

        public BaseView()
        {
            Console.Clear();

            SubscribingEvents();           
        }

        public bool Active
        {
            get => _active;
            set
            {
                if (_active != value)
                {
                    _active = value;
                    ChangeActiveState?.Invoke();
                }
            }
        }


        public abstract bool ShowView();

        public void Dispose() => Dispose(true);


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                    UnsubscribingEvents();

                _disposedValue = true;
            }
        }


        protected virtual void UnsubscribingEvents() 
        {
            //nothing here...
        }


        protected virtual void SubscribingEvents() 
        {
            //nothing here...
        }



        public void ShowMessage(string messageText, ConsoleColor TextColor = ConsoleColor.White)
        {
            Console.ForegroundColor = TextColor;
            Console.WriteLine(messageText);
        }

        public string GetUserResponse()
        {
            bool isGetResponse;
            string response;

            do
            {
                response = Console.ReadLine();

                if (String.IsNullOrEmpty(response))
                {
                    Console.WriteLine(RepeatText);
                    break;
                }

                isGetResponse = true;
            } while (isGetResponse);

            return response;
        }
    }
}