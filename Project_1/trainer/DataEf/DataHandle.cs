using System;
using System.Linq;


namespace DataEf
{

    public class DataHandle
    {
        //using (var db = new UniContextEntities()) {
        //using (var db = new Entities.AbdulContext())


        public int id;
        public string name;

        //public DataHandle()
        //{
        //    using (var db = new Entities.AbdulContext())
        //    {
        //        var query = from b in db.Users select b;

        //        foreach (var item in query)
        //        {
        //            Console.WriteLine(item.EmailId);
        //        }
        //    }
        //}

        public LoginClass DataHandleLogin(string email, string pass)
        {
            using (var db = new Entities.AbdulContext())
            {
                var query = from b in db.Users where b.EmailId == email && b.Password == pass select b;


                foreach (var item in query)
                {
                    //Console.WriteLine(item.EmailId);
                    id = item.UserId;
                    name = item.FirstName;
                }

            }

            return new LoginClass(id, name);
        }

        public void DataHandleSignUp(string fname, string lname, string email, string pass, Int64 phone)
        {
            Entities.AbdulContext cnt = new Entities.AbdulContext();
            Entities.User user = new Entities.User();

            user.FirstName = fname;
            user.LastName = lname;
            user.EmailId = email;
            user.Password = pass;
            user.PhoneNo = phone;

            cnt.Users.Add(user);

            int i = cnt.SaveChanges();

            if (i > 0)
            {
                Console.WriteLine("User created success fully");
            }
            else
            {
                Console.WriteLine("Unable to create user");
            }

        }
    }

}

