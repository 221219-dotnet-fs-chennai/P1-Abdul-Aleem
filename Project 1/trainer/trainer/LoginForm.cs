using System;
using UserProfile;
using datahandle;
namespace trainer
{
    public class LoginForm
    {
        public LoginForm()
        {
            LoginPage lg = new LoginPage();
            bool runner = true;
            Console.WriteLine(@"
 __     __    ___   __   __ _ 
(  )   /  \  / __) (  ) (  ( \
/ (_/\(  O )( (_ \  )(  /    /
\____/ \__/  \___/ (__) \_)__)
        ");
            while (runner)
            {
                //Console.Clear();

                string IsLoggedIn = (lg.IsUserId > 0) ? "Your Logged In" : "";
                Console.WriteLine("Welcome To Login Page");
                Console.WriteLine("0 - Back");
                Console.WriteLine("1 - Email ID {0}", lg.EmailId);
                Console.WriteLine("2 - Password {0}", lg.Password);
                Console.WriteLine("3 - Submit");
                Console.WriteLine(IsLoggedIn);

                if (IsLoggedIn == "Your Logged In")
                {
                    UserCreationMenu uc = new UserCreationMenu(lg.IsUserId, lg.UserName);
                    Logging log = new Logging();
                    log.InformationWriter($"LogIn done by user - {lg.EmailId}");


                    runner = false;

                }

                else
                {


                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            Console.Clear();
                            runner = false;
                            break;
                        case 1:
                            Console.WriteLine("Enter The Email ID");
                            lg.EmailId = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter Your Password");
                            lg.Password = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Submitting....");
                            lg.LoginPageSubmission();
                            Console.WriteLine("Submited");
                            break;


                    }
                }
            }


        }
    }
}

