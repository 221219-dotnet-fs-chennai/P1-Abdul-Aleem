using System;
using System.Data.SqlClient;
using datahandle;
namespace trainer
{
    public class LoginPage
    {
        public int IsUserId;
        public string UserName;
        SqlHandle sq = new SqlHandle();
        Logging lg = new Logging();
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
            try
            {
                int reader = sq.SqlQueryWriter($"SELECT * FROM pro.[user] WHERE email_id = '{this.emailid}' and password = '{this.password}';");
                IsUserId = reader;

                string reader1 = sq.SqlQueryWriterName($"SELECT * FROM pro.[user] WHERE email_id = '{this.emailid}' and password = '{this.password}';");
                UserName = reader1;
                Console.Clear();
            }
            catch (SqlException e)
            {
                lg.ErrorWriter(e);
                Console.WriteLine("Some error occured due to wrong input for login");
            }

            //Console.WriteLine(reader);
            //while (reader.Read())
            //{

            //    Console.WriteLine(reader.GetString(1));

            //}
        }
    }
}

