using System;
using System.Reflection.PortableExecutable;
using datahandle;
using System.Data.SqlClient;
using System.Data;
using UserProfile;


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
                    //MyProfile mp = new MyProfile();
                    //mp.MyProfile1(2);
                    //mp.MyProfileEdu(2);
                    //mp.MyProfileExperience(2);
                    //mp.MyProfileSkills(2);
                    //mp.MyProfileCertification(2);
                    //SqlHandle ss = new SqlHandle();

                    //try
                    //{

                    //    int k = ss.SqlQueryWriter(@"select * from ");
                    //}

                    //catch (SqlException e)
                    //{
                    //    Console.WriteLine("Some error occured");
                    //}

                    break;


                default:
                    Console.WriteLine("Wrong Input");
                    break;

            }




        }
    }
}

