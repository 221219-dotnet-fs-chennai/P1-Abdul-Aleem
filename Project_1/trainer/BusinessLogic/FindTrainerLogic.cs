using System;
using Models;
using System.Collections;

namespace BusinessLogic
{
    public class FindTrainerLogic
    {

        public List<DataEf.Entities.User> queryable;

        public IList UsingCity(string city)
        {
            DataEf.Entities.AbdulContext abdulContext = new DataEf.Entities.AbdulContext();
            var query = (from st in abdulContext.Users
                         where st.City == city
                         select st).ToList();
            //Dictionary<int, string> dict = new Dictionary<int, string>();
            //List<DataEf.Entities.User> users = new List<DataEf.Entities.User>();
            List<Models.UserModelTrainer> users = new List<UserModelTrainer>();
            foreach (var q in query)
            {
                //dict.Add(q.UserId, $"{q.FirstName} {q.LastName}");
                //AuthorList.Add(new Author("Mahesh Chand", 35, "A Prorammer's Guide to ADO.NET", true, new DateTime(2003, 7, 10)));
                users.Add(new Models.UserModelTrainer(q.FirstName, q.LastName, q.EmailId, q.Password, q.PhoneNo, q.City));

            }
            return users;
        }

        public IList UsingSkill(string skill)
        {

            DataEf.Entities.AbdulContext abdulContext = new DataEf.Entities.AbdulContext();
            var query = (from st in abdulContext.Skills
                         where st.SkillName == skill
                         select st);




            var q = (from pd in abdulContext.Users
                     join od in query
                     on pd.UserId equals od.UsId
                     select new
                     {
                         userid = pd.UserId,
                         firstName = pd.FirstName,
                         lastName = pd.LastName,
                         emailId = pd.EmailId,
                         phoneNo = pd.PhoneNo,
                         city = pd.City,


                     }
                     ).ToList();
            return q;
        }

        public IList UsingCertification(string cert)
        {
            DataEf.Entities.AbdulContext abdulContext = new DataEf.Entities.AbdulContext();

            var query = (from st in abdulContext.Certs
                         where st.CertificationName == cert
                         select st);

            var q = (from pd in abdulContext.Users
                     join od in query
                     on pd.UserId equals od.UsId
                     select new
                     {
                         userid = pd.UserId,
                         firstName = pd.FirstName,
                         lastName = pd.LastName,
                         emailId = pd.EmailId,
                         phoneNo = pd.PhoneNo,
                         city = pd.City,
                     }).ToList();
            return q;
        }
    }
}

