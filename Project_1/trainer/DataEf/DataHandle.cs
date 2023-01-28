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
    }

}

