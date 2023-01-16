using System;
using System.Data.SqlClient;
using System.IO;

namespace datahandle
{
    public class SqlHandle
    {
        //private string connection = null;
        private string Connection = File.ReadAllText(@"/Users/abdulaleem/Documents/Project Dev/01/conf.txt");
        public int UserId;
        public string SkillName;


        //public SqlHandle()
        //{

        //    //using SqlConnection con = new SqlConnection("Server=tcp:abdul-revature-db.database.windows.net,1433;Initial Catalog=abdul_db;Persist Security Info=False;User ID=abdulaleem;Password=Aa@1052001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    using SqlConnection con = new SqlConnection(Connection);

        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select * from pro.[user];", con);
        //    using SqlDataReader reader = cmd.ExecuteReader();
        //    Console.WriteLine(reader);
        //    while (reader.Read())
        //    {

        //        Console.WriteLine(reader.GetInt32(0));

        //    }


        //    Console.WriteLine(reader.GetType().Name);
        //    con.Close();
        //    Console.WriteLine("Success");



        //}

        public int SqlQueryWriter(string q)
        {
            using SqlConnection con = new SqlConnection(Connection);

            con.Open();
            Console.WriteLine(q);
            SqlCommand cmd = new SqlCommand(q, con);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Console.WriteLine(reader.GetInt32(0));
                UserId = reader.GetInt32(0);


            }
            //Console.WriteLine(reader);
            con.Close();
            return UserId;
        }

        public string SqlQueryWriterSkill(string q)
        {
            using SqlConnection con = new SqlConnection(Connection);

            con.Open();
            Console.WriteLine(q);
            SqlCommand cmd = new SqlCommand(q, con);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                //Console.WriteLine(reader.GetInt32(3));
                //SkillId = reader.GetInt32(3);
                SkillName = reader.GetString(1);


            }
            //Console.WriteLine(reader);
            //con.Close();
            return SkillName;
        }






    }


}

