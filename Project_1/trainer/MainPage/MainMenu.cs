using System;
using DataEf;
namespace trainer

{
    public class MainMenu
    {
        public int k;
        public MainMenu()
        {
            Console.WriteLine("Welcome!!");
            Console.WriteLine("");
            Console.WriteLine("0.Exit");

            Console.WriteLine("1.SignUp");
            Console.WriteLine("2.Login");
            bool runner = true;

            while (runner)
            {
                Console.WriteLine("Enter Your Choice - ");
                try
                {
                    k = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please Enter an integer value {0}", e);
                }



                switch (k)
                {
                    case 0:
                        Console.WriteLine("Exit....");
                        runner = false;
                        break;
                    case 1:
                        Console.WriteLine("SignUp");
                        SignUpPage sg = new SignUpPage();
                        break;
                    case 2:
                        Console.WriteLine("Login");
                        LoginPage lg = new LoginPage();
                        break;
                    case 3:
                        DataHandle dt = new DataHandle();
                        Console.WriteLine(dt.DataHandleLogin("abdulaleem@gmail.com", "12345678"));

                        break;

                    default:
                        Console.WriteLine("Enter a valid input");
                        break;
                }
            }
        }


    }
}



