using System;
using DataEf;
namespace trainer
{
    public class SignUpPage
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Int64 Phone { get; set; }
        public int k;
        public SignUpPage()
        {
            bool runner = true;

            while (runner)
            {

                Console.WriteLine("Welcome To SignUp Menu");
                Console.WriteLine("0.Exit");
                Console.WriteLine("1.First Name - {0}", Fname);
                Console.WriteLine("2.Last Name - {0}", Lname);
                Console.WriteLine("3.EmailId - {0}", Email);
                Console.WriteLine("4.Password - {0}", Password);
                Console.WriteLine("5.Phone No - {0}", Phone);
                Console.WriteLine("6.Submit");

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
                        Console.WriteLine("Enter Your First Name :");
                        Fname = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter Your Last Name :");
                        Lname = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Enter Your Email ID :");
                        Email = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Enter Your Password :");
                        Password = Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("Enter Your Phone No :");
                        Phone = Convert.ToInt64(Console.ReadLine());
                        break;
                    case 6:
                        SignUpSubmission();
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
        public void SignUpSubmission()
        {
            DataHandle dt = new DataHandle();
            dt.DataHandleSignUp(this.Fname, this.Lname, this.Email, this.Password, this.Phone);
        }
    }
}

