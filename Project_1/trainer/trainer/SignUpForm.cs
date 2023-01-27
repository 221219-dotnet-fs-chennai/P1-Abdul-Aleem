using System;
using datahandle;
namespace trainer
{
    public class SignUpForm
    {

        public SignUpForm()
        {

            SignUpPage sg = new SignUpPage();
            Logging lg = new Logging();
            bool run = true;
            while (run)
            {
                //Console.Clear();
                Console.WriteLine("");

                Console.WriteLine("----SignUp----");
                Console.WriteLine("");

                Console.WriteLine("1 - First Name {0}", sg.FirstName);
                Console.WriteLine("2 - Last Name {0}", sg.LastName);
                Console.WriteLine("3 - Email Id {0}", sg.EmailId);
                Console.WriteLine("4 - Password {0}", sg.Password);
                Console.WriteLine("5 - Phone No {0}", sg.PhoneNo);
                Console.WriteLine("6 - Submit");
                Console.WriteLine("0 - Back");
                Console.WriteLine("");

                Console.WriteLine("Enter Your Value :");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        //Console.Clear();
                        run = false;
                        break;
                    case 1:
                        Console.WriteLine("Enter Your First Name : ");
                        sg.FirstName = Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("Enter Your Last Name");
                        sg.LastName = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Enter Your EmailId");
                        sg.EmailId = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Enter Your Password");
                        sg.Password = Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("Enter Your Phone No");
                        try
                        {
                            sg.PhoneNo = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Enter a valid number");
                            lg.ErrorWriter(e);
                        }
                        break;
                    case 6:
                        Console.WriteLine("Sbmitting....");
                        sg.SignUpPageSubmission();
                        Console.WriteLine("Submitted Successfully");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input");
                        break;
                }
            }

        }
    }
}

