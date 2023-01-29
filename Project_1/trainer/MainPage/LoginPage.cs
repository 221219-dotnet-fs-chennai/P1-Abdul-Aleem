using System;
using DataEf;
using UserProfile;
namespace trainer
{
    public class LoginPage
    {
        public string email { get; set; }
        public string pass { get; set; }
        public int LoginId;
        public int k;

        public LoginPage()
        {
            Console.WriteLine("Welcome To Login");


            bool runner = true;

            while (runner)
            {
                Console.WriteLine("1.Email - {0}", email);
                Console.WriteLine("2.Password - {0}", pass);
                Console.WriteLine("3.Submit");
                Console.WriteLine("0.Exit");

                Console.WriteLine("Enter the Choice :");
                try
                {
                    k = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Enter a valid input -{0}", e);
                }

                switch (k)
                {
                    case 1:
                        Console.WriteLine("Enter Your EmailID :");
                        email = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter Your PassWord : ");
                        pass = Console.ReadLine();
                        break;
                    case 3:
                        var lgdetails = LoginSubmission();
                        if (lgdetails.Id > 0)
                        {
                            Console.WriteLine(lgdetails.Id);
                            Console.WriteLine("Logged In SuccessFully");
                            UserMenu us = new UserMenu(lgdetails.Id);

                        }
                        else
                        {
                            Console.WriteLine("Incorrect email or Password");
                        }
                        break;
                    case 0:
                        runner = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid num");
                        break;
                }


            }


        }
        public LoginClass LoginSubmission()
        {

            DataHandle dt = new DataHandle();
            var LoginDetails = dt.DataHandleLogin(email, pass);
            return LoginDetails;
        }
    }
}

