using System;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using datahandle;
namespace trainer
{
    public class SignUpPage

    {
        Regex regemail = new Regex(@"/(\w+@\w+[.]+\w+)/");
        SqlHandle sq = new SqlHandle();






        private string firstname;
        private string lastname;
        private string emailid;
        private string password;
        private int phoneno;



        public string FirstName
        {
            set
            {
                firstname = value;
            }
            get
            {
                return firstname;
            }

        }

        public string LastName
        {
            set
            {
                lastname = value;
            }

            get
            {
                return lastname;
            }
        }

        public string EmailId
        {
            set
            {
                //if (regemail.IsMatch(value))
                //{
                //    emailid = value;
                //}
                emailid = value;
                //else
                //{
                //    Console.WriteLine("Enter a valid email id");
                //}
            }

            get
            {
                return emailid;
            }

        }

        public string Password
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }

        }

        public int PhoneNo
        {
            set
            {
                phoneno = value;
            }
            get
            {
                return phoneno;
            }
        }



        public void SignUpPageSubmission()
        {
            int reader = sq.SqlQueryWriter($"INSERT into pro.[user](first_name,last_name,email_id,[password],phone_no) VALUES('{this.firstname}','{this.lastname}','{this.emailid}','{this.password}','{this.phoneno}');");
            Console.WriteLine(reader);
            //while (reader.Read())
            //{

            //    Console.WriteLine(reader.GetInt32(0));

            //}

        }
    }

}


