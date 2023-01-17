using System;
using System.Reflection.PortableExecutable;
using datahandle;
using System.Data.SqlClient;
using System.Data;

namespace trainer
{
    public class MainMenu

    {

        public void MainMenuLoop()
        {
            //Program.MainLoop mp = new Program.MainLoop();
            Console.WriteLine("0 - Back");
            Console.WriteLine("1 - Signup");
            Console.WriteLine("2 - Login");

            //Dummy
            Console.WriteLine("3 - Read");



            int inp = Convert.ToInt32(Console.ReadLine());

            switch (inp)
            {
                case 0:
                    Console.WriteLine("Back pressed");

                    Program.MainLoop = false;
                    break;
                case 1:
                    Console.WriteLine("Sing up menu");
                    SignUpForm sf = new SignUpForm();
                    //Program.MainLoop = false;
                    break;
                case 2:
                    Console.WriteLine("Login menu");
                    LoginForm lf = new LoginForm();
                    //Program.MainLoop = false;
                    break;
                case 3:
                    SqlHandle sq = new SqlHandle();
                    DataTable reader = sq.SqlQeryWriterSkillUpdate(@"select * from pro.[user]");
                    //Console.WriteLine(reader);
                    foreach (DataRow dataRow in reader.Rows)
                    {
                        foreach (var item in dataRow.ItemArray)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine("");
                    }

                    //Program.MainLoop = false;
                    break;


                default:
                    Console.WriteLine("Wrong Input");
                    break;

            }




        }
    }
}

