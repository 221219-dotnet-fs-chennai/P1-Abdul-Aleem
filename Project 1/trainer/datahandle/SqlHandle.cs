using System;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace datahandle
{
    public class SqlHandle
    {
        //private string connection = null;
        private string Connection = File.ReadAllText(@"/Users/abdulaleem/Documents/Project Dev/01/conf.txt");

        public int UserId;
        public string SkillName;
        public string UserNameLogin;


        //public SqlHandle()
        //{


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

        /// <summary>
        /// This method is used to fetch information from DB.Pass the query as a parameter to the method.
        /// </summary>
        /// <param name="q"></param>
        /// <returns>UserId as an integer.</returns>
        public int SqlQueryWriter(string q)
        {

            using SqlConnection con = new SqlConnection(Connection);




            con.Open();
            //Console.WriteLine(q);
            SqlCommand cmd = new SqlCommand(q, con);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Console.WriteLine(reader.GetInt32(0));
                UserId = reader.GetInt32(0);
                //UserNameLogin = reader.GetString(1);

            }
            //Console.WriteLine(reader);
            con.Close();
            return UserId;
        }

        /// <summary>
        /// This method is used to fetch information from DB.Pass the query as a parameter to the method
        /// </summary>
        /// <param name="q"></param>
        /// <returns>UserName from the given query as String</returns>
        public string SqlQueryWriterName(string q)
        {
            using SqlConnection con = new SqlConnection(Connection);

            con.Open();
            //Console.WriteLine(q);
            SqlCommand cmd = new SqlCommand(q, con);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserNameLogin = reader.GetString(1);
                //Console.WriteLine(reader.GetInt32(0));
                //UserId = reader.GetInt32(0);
                //UserNameLogin = reader.GetString(1);

            }
            //Console.WriteLine(reader);
            con.Close();
            return UserNameLogin;

        }

        /// <summary>
        /// Used To fetch last string value in the 1st coloumn for validation
        /// </summary>
        /// <param name="q"></param>
        /// <returns>Last value of 2nd coloumn in String</returns>
        public string SqlQueryWriterSkill(string q)
        {
            using SqlConnection con = new SqlConnection(Connection);

            con.Open();
            //Console.WriteLine(q);
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

        /// <summary>
        /// Used to fetch all the information in the query. Uses disconnected architecture.
        /// </summary>
        /// <param name="q"></param>
        /// <returns>DataTable</returns>
        public DataTable SqlQeryWriterSkillUpdate(string q)
        {
            using SqlConnection con = new SqlConnection(Connection);

            con.Open();
            //Console.WriteLine(q);
            SqlCommand cmd = new SqlCommand(q, con);
            //SqlDataAdapter reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                a.Fill(dt);
            }

            return dt;

        }


        public void sqlQueryDelete(string q)
        {
            using SqlConnection con = new SqlConnection(Connection);
            con.Open();
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();


        }








    }


}

