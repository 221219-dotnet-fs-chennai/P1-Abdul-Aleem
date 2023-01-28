using System;
using System.Reflection.PortableExecutable;
using datahandle;
using System.Data.SqlClient;
using System.Data;
using UserProfile;
using DataEf;


namespace trainer
{
    public class MainMenu

    {

        public void MainMenuLoop()
        {
            //Program.MainLoop mp = new Program.MainLoop();
            Console.WriteLine("");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Signup");
            Console.WriteLine("2 - Login");
            Console.WriteLine("");
            Logging lg = new Logging();


            //Dummy
            //Console.WriteLine("3 - Read");



            int inp = Convert.ToInt32(Console.ReadLine());

            switch (inp)
            {
                case 0:
                    lg.InformationWriter("---------------------------Exiting Run--------------------------------");

                    Console.WriteLine("Exit...........");
                    Program.MainLoop = false;
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Sing up menu");
                    SignUpForm sf = new SignUpForm();
                    //Program.MainLoop = false;
                    break;
                case 2:
                    Console.Clear();

                    Console.WriteLine("Login menu");
                    LoginForm lf = new LoginForm();
                    //Program.MainLoop = false;
                    break;
                case 3:
                    Class1 cs = new Class1();



                    break;


                default:
                    Console.WriteLine("Wrong Input");
                    break;

            }




        }
    }
}

