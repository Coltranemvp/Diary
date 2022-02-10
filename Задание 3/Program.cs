using DiaryProject.Views;

namespace DiaryProject
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Привет! Это твой ежедневник. Он работает в нескольких режимах");
            //Event yourEvent = new Event();

            //Thread myThread = new Thread(new ThreadStart(yourEvent.Menu));
            //myThread.Start(); // запускаем основной поток

            //TimerCallback tm = new TimerCallback(yourEvent.PushCheaker);
            //Timer timer = new Timer(tm, 0, 0, 5000); // второй поток с таймером

            BaseMenuView baseMenuView = new BaseMenuView(true);




        }
    }
}
