using System;


namespace trainer
{
    public class Program
    {


        public static bool MainLoop = true;


        public static void Main()
        {

            Console.WriteLine("Hello, How are you and Welcome");
            MainMenu menu = new MainMenu();


            while (MainLoop)
            {
                menu.MainMenuLoop();

            }

        }

    }

}

