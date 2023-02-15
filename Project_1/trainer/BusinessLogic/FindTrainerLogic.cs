using System;
using Models;
using System.Collections;

namespace BusinessLogic
{
    public class FindTrainerLogic
    {

        public List<DataEf.Entities.User> queryable;

        public Dictionary<int, string> UsingCity(string city)
        {
            DataEf.Entities.AbdulContext abdulContext = new DataEf.Entities.AbdulContext();
            var query = (from st in abdulContext.Users
                         where st.City == city
                         select st).ToList();
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (var q in query)
            {
                dict.Add(q.UserId, $"{q.FirstName} {q.LastName}");
            }
            return dict;
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
                         fname = pd.FirstName,
                         lname = pd.LastName
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
                         fname = pd.FirstName,
                         lname = pd.LastName,
                     }).ToList();
            return q;
        }
    }
}

