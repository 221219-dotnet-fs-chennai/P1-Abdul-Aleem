using System;
using System.Data.SqlClient;
using datahandle;
namespace trainer
{
    public class LoginPage
    {
        public int IsUserId;
        SqlHandle sq = new SqlHandle();
        private string emailid;
        private string password;

        public string EmailId
        {
            set
            {
                emailid = value;
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
        public void LoginPageSubmission()
        {
            int reader = sq.SqlQueryWriter($"SELECT * FROM pro.[user] WHERE email_id = '{this.emailid}' and password = '{this.password}';");
            IsUserId = reader;
            //Console.WriteLine(reader);
            //while (reader.Read())
            //{

            //    Console.WriteLine(reader.GetString(1));

            //}
        }
    }
}

