using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Word = Microsoft.Office.Interop.Word;


namespace Задание_3
{
    class Event : IEvent
    {
        
        List<string> events = new List<string> {};
        List<DateTime> timeEvent = new List<DateTime> {};
        List<DateTime> timeEventEnd = new List<DateTime> {};
        List<DateTime> timeEventPush = new List<DateTime> {};
        

       //Метод Menu реализует основное меню программы ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Режимы работы ежедневника:");
            Console.WriteLine("1) Ты можешь добавить ивент, его дату и время прохождения.");
            Console.WriteLine("2) Ты можешь изменить ивент, его дату и время прохождения.");
            Console.WriteLine("3) Ты можешь удалить ивент, его дату и время прохождения.");
            Console.WriteLine("4) Ты можешь посмотреть расписание ивентов, их дату и время прохождения.");
            Console.WriteLine("5) Ты можешь добавить время уведомления ивента.");
            Console.WriteLine("6) Ты можешь экспортировать расписание дня в файл.");
            Console.WriteLine("7) Выход из ежедневника.");
            Console.Write("Введи значение от 1-7, чтобы выбрать режим : ");
            string cheaker = Console.ReadLine();
            int cheakerInt = 0;
            for (int i = 0; i < 1; i += 0)
            {
                if ((cheaker == "1") || (cheaker == "2") || (cheaker == "3") || (cheaker == "4") || (cheaker == "5") || (cheaker == "6") || (cheaker == "7"))
                {
                    cheakerInt = Convert.ToInt32(cheaker);
                    i++;
                }
                else
                {
                    Console.WriteLine("Вы ввели не допустимое значение");
                    Console.Write("Введи значение от 1-7, чтобы выбрать режим : ");
                    cheaker = Console.ReadLine();
                }
                switch (cheakerInt)
                {
                    case 1:
                        AddEvent();
                        break;
                    case 2:
                        ChangeEvent();
                        break;
                    case 3:
                        DeleteEvent();
                        break;
                    case 4:
                        ShowEvent();
                        break;
                    case 5:
                        AddPushEvent();
                        break;
                    case 6:
                        ExportEvent();
                        break;
                    case 7:
                        break;
                }
            }
        }

        // Метод AddEvent() добавляет название ивента и его дату//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AddEvent()
        {
            Console.Clear();            
            DateTime dateEvent = new DateTime();
            DateTime dateEventTwo = new DateTime();
            DateTime dateEventEnd = new DateTime();
            // Проверка и ввод даты
            for (int i = 0; i < 1; i += 0)
            {
                do
                {
                    string dateEventQ;
                    do
                    {
                        Console.WriteLine("Укажите дату Вашего ивента: дд.ММ.гггг чч:мм (день.месяц.год час:минута):");
                        dateEventQ = Console.ReadLine();
                        if (dateEventQ == "menu") { Menu(); }

                    }
                    while (!DateTime.TryParseExact(dateEventQ, "dd.MM.yyyy HH:mm", null, DateTimeStyles.None, out dateEvent));
                }
                while (dateEvent < DateTime.Now);
                dateEventTwo = dateEvent;
                // Проверка и ввод времени через сколько закончится ивент
                do
                {
                    Console.WriteLine("Укажите через сколько закончится ивент чч:мм (час:минута):");

                }
                while (!DateTime.TryParseExact(Console.ReadLine(), "HH:mm", null, DateTimeStyles.None, out dateEventEnd));
                dateEventTwo = dateEvent.AddHours(dateEventEnd.Hour);
                dateEventTwo = dateEvent.AddMinutes(dateEventEnd.Minute);
                // Проверка пересекается ли заданное время с уже запланированным
                if (timeEvent.Count > 0)
                {
                    for (int j = 0; j < 1; j += 0)
                    {

                        if ((timeEvent[j] > dateEvent) && (timeEvent[j] > dateEventTwo))
                        {
                            i++;
                            j++;
                        }
                        else if ((timeEventEnd[j] < dateEvent) && (timeEventEnd[j] < dateEventTwo))
                        {
                            i++;
                            j++;
                        }
                        else
                        {
                            Console.WriteLine("На указанное время уже запланировано мероприятие, введите другое время!");
                            Console.WriteLine();
                            j++;
                        }

                    }
                }
                else { i++; }
            }
            timeEvent.Add(dateEvent);
            timeEventEnd.Add(dateEventTwo);
            Console.Write("Укажите название Вашего ивента: ");
            string nameEvent = Console.ReadLine();
            events.Add(nameEvent);
            Console.WriteLine();
            Console.WriteLine("Ваши данные приняты, нажмите любое кнопку на клавиатуре, чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
            Menu();

        }

        //Метод ChangeEvent() изменяет название ивента и его дату/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ChangeEvent()
        {
            Console.Clear();
            int index;            
            do
            {
                Console.Write("Введите название ивента для изменения:");
                string nameEvent = Console.ReadLine();
                if (nameEvent == "menu") { Menu(); }
                index = events.FindIndex((x) => x == nameEvent);
            } while (index < 0);
            Console.WriteLine($"Название указоного ивента : {events[index]}");
            Console.WriteLine($"Начало указоного ивента : {timeEvent[index]}");
            Console.WriteLine($"Конец указоного ивента : {timeEventEnd[index]}");
            Console.WriteLine();
            for (int i = 0; i < 1; i += 0)
            {
                Console.WriteLine("Данный элемент будет изменен, Вы уверены? (да/нет)");
                string ques = Console.ReadLine();
                if (ques == "да")
                {
                    DateTime dateEvent;
                    DateTime dateEventEnd;
                    do
                    {
                        do
                        {
                            Console.WriteLine("Укажите дату Вашего ивента: дд.ММ.гггг чч:мм (день.месяц.год час:минута):");

                        }
                        while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm", null, DateTimeStyles.None, out dateEvent));
                    }
                    while (dateEvent < DateTime.Now);
                    timeEvent[index] = dateEvent;
                    //Проверка и ввод времени через сколько закончится ивент
                    do
                    {
                        Console.WriteLine("Укажите через сколько закончится ивент чч:мм (час:минута):");

                    }
                    while (!DateTime.TryParseExact(Console.ReadLine(), "HH:mm", null, DateTimeStyles.None, out dateEventEnd));


                    dateEvent = dateEvent.AddHours(dateEventEnd.Hour);
                    dateEvent = dateEvent.AddMinutes(dateEventEnd.Minute);
                    timeEventEnd[index] = dateEvent;
                    Console.WriteLine("Ваши данные приняты, нажмите любое кнопку на клавиатуре, чтобы вернуться в меню");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;


                }
                else if (ques == "нет")
                {
                    i++;
                    Console.WriteLine("Нажмите любую кнопку, чтобы вернуться в главное меню");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                }
                else { Console.WriteLine("Вы ввели не корректный ответ, повторите еще раз!"); Console.WriteLine(); }
            }
            Console.WriteLine("Ивент успешно удален, нажмите любую кнопку, чтобы вернуться в главное меню");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        //Метод DeleteEvent() удаляет ивент///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void DeleteEvent()
        {
            Console.Clear();
            int index;
            do
            {
                Console.Write("Введите название ивента для удаления:");
                string nameEvent = Console.ReadLine();
                if (nameEvent == "menu") { Menu(); }
                index = events.FindIndex((x) => x == nameEvent);

            } while (index < 0);
            Console.WriteLine($"Название указоного ивента : {events[index]}");
            Console.WriteLine($"Начало указоного ивента : {timeEvent[index]}");
            Console.WriteLine($"Конец указоного ивента : {timeEventEnd[index]}");
            Console.WriteLine();
            for (int i = 0; i < 1; i += 0)
            {
                Console.WriteLine("Данный элемент будет удален, Вы уверены? (да/нет)");
                string ques = Console.ReadLine();
                if (ques == "да")
                {
                    i++;
                    events.RemoveAt(index);
                    timeEvent.RemoveAt(index);
                    timeEventEnd.RemoveAt(index);


                }
                else if (ques == "нет")
                {
                    i++;
                    Console.WriteLine("Нажмите любую кнопку, чтобы вернуться в главное меню");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                }
                else { Console.WriteLine("Вы ввели не корректный ответ, повторите еще раз!"); Console.WriteLine(); }
            }
            Console.WriteLine("Ивент успешно удален, нажмите любую кнопку, чтобы вернуться в главное меню");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        //Метод ShowEvent() показывает список ивентов////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ShowEvent()
        {
            Console.Clear();
            List<int> indexList = new List<int> { };
            List<DateTime> dateList = new List<DateTime> { };

            for (int i = 0; i < 1; i += 0)
            {

                DateTime nameEvent;
                string dateEventQ;
                do
                {
                    Console.WriteLine("Укажите дату Вашего ивента: дд.ММ.гггг (день.месяц.год):");
                    dateEventQ = Console.ReadLine();
                    if (dateEventQ == "menu") { Menu(); }


                }
                while (!DateTime.TryParseExact(dateEventQ, "dd.MM.yyyy", null, DateTimeStyles.None, out nameEvent));
                dateList = timeEvent.FindAll((x) => x == nameEvent);
                // Запрос в список ивентов по году/дате/дню
                var dateList1 = from h in timeEvent where (h.Year == nameEvent.Year) && (h.Day == nameEvent.Day) && (h.Month == nameEvent.Month) select h;
                // Получение списка индексов с полученного запроса
                foreach (DateTime dateFor in dateList1)
                {
                    indexList.Add(timeEvent.FindIndex((x) => x == dateFor));
                }

                if (indexList.Count > 0) { i++; } else { Console.WriteLine("На эту дату нет расписания, повторите еще раз!"); }
            }
            foreach (int indexFor in indexList)
            {
                Console.WriteLine($"Название указоного ивента : {events[indexFor]}");
                Console.WriteLine($"Начало указоного ивента : {timeEvent[indexFor]}");
                Console.WriteLine($"Конец указоного ивента : {timeEventEnd[indexFor]}");
                Console.WriteLine();
            }
            int err = 0;
            do
            {
                err = 0;
                Console.WriteLine("Хотите посмотреть другую дату? (да/нет)");
                string cheaker = Console.ReadLine();

                if (cheaker == "да") { ShowEvent(); break; }
                else if (cheaker == "нет") { Menu(); break; }
                else { Console.WriteLine("Вы ввели не корректный ответ, повторите еще раз!"); err++; }
            } while (err == 0);


        }
        //Метод AddPushEvent() добавляет уведомления о ивенте//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AddPushEvent()
        {
            Console.Clear();
            int index;

            do
            {
                Console.Write("Введите название ивента для добавления/изменения уведомления о его начале:");
                string nameEvent = Console.ReadLine();
                if (nameEvent == "menu") { Menu(); }
                index = events.FindIndex((x) => x == nameEvent);
            } while (index < 0);

            Console.WriteLine($"Название указоного ивента : {events[index]}");
            Console.WriteLine($"Начало указоного ивента : {timeEvent[index]}");
            Console.WriteLine($"Конец указоного ивента : {timeEventEnd[index]}");
            Console.WriteLine();
            DateTime someDate = new DateTime(5001, 01, 01);
            //добавляет даты до необходимого индекса т.к список может быть пустым и индексы могут не совпадать
            for (int i = 0; i <= (index - timeEventPush.Count); i++)
            {
                timeEventPush.Add(someDate);
            }

            DateTime dateEvent;

            do
            {
                Console.WriteLine("Укажите за сколько по времени необходимо Вас уведомить о ивенте. Укажите занчение формате чч:мм (час:минута):");

            }
            while (!DateTime.TryParseExact(Console.ReadLine(), "HH:mm", null, DateTimeStyles.None, out dateEvent));

            timeEventPush[index] = timeEvent[index].AddMinutes(-dateEvent.Minute).AddHours(-dateEvent.Hour);
            Console.WriteLine();
            Console.WriteLine($"Ваши данные приняты, уведомление сработает {timeEventPush[index]}");
            Console.WriteLine("Нажмите любую кнопку на клавиатуре, чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        //Метод  ExportEvent() экспортирует данные в текстовый файл///////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ExportEvent()
        {
            if (timeEvent.Count > 0)
            {                
                Word.Application app = new Word.Application();
                Word.Document doc = app.Documents.Add();
                // создание пустых параграфов в соотношении 2 пустых к 1 заполняемому
                for (int i = 0; i < (timeEvent.Count * 8); i++)
                {
                    doc.Paragraphs.Add();
                }
                int j = 1;
                // печать расписания
                for (int i = 0; i < timeEvent.Count; i++)
                {
                    doc.Paragraphs[j].Range.Text = $"Название ивента : {events[i]}";
                    doc.Paragraphs[j + 1].Range.Text = $"Время начала ивента : {timeEvent[i]}";
                    doc.Paragraphs[j + 2].Range.Text = $"Время конца ивента : {timeEventEnd[i]}";
                    doc.Paragraphs[j + 3].Range.Text = $"";
                    j = j + 4;

                }
                app.Visible = true;
                Console.ReadKey();
                Menu();
            }
            else { Console.WriteLine("У вас нет запланированных ивентов."); Console.ReadKey(); Menu(); }
        }
        //Метод  PushCheaker(object obj) производит проверку на уведомление ///////////////////////////////////////////////////////////////////////////////////////////////////////
        public void PushCheaker(object obj)
        {
            DateTime someDate = new DateTime(5001, 01, 01);
            //добавляет даты до необходимого индекса т.к список может быть пустым и индексы могут не совпадать
            for (int i = 0; i < (timeEvent.Count - timeEventPush.Count); i++)
            {
                timeEventPush.Add(someDate);
            }

            if (timeEventPush.Count > 0)
            {
                for (int j = 0; j < timeEvent.Count; j++)

                {
                    if ((timeEventPush[j] <= DateTime.Now) && (timeEvent[j] >= DateTime.Now))
                    {
                        Console.Clear();
                        Console.WriteLine($"Скоро начнется ивент под названием: {events[j]}");
                        Console.WriteLine($"До начала осталось: {timeEvent[j].Subtract(DateTime.Now)}");
                        Console.WriteLine("Для того, чтобы вернуться в меню нажмите любую кнопку!");
                        timeEventPush[j] = someDate;
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }

    }
}
