using System;
using datahandle;

namespace trainer
{
    public class Program
    {


        public static bool MainLoop = true;


        public static void Main()
        {

            Console.WriteLine("Hello, How are you and Welcome");
            Logging lg = new Logging();
            lg.InformationWriter("-----------------------New Run Started-------------------------");
            MainMenu menu = new MainMenu();


            while (MainLoop)
            {
                menu.MainMenuLoop();

            }

        }

    }

}

