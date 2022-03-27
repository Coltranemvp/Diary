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

        public BaseView()
        {
            Console.Clear();
        }

        public virtual void Dispose()
        {

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