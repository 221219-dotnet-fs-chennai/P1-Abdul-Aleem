using System;
using Models;
using System.Collections;

namespace BusinessLogic
{
    public class CertLogic
    {
        //public IList GetAll(int id)
        //{
        //    DataEf.Entities.AbdulContext cnt = new DataEf.Entities.AbdulContext();
        //    

        //    var tr = query.Select(x => new SkillModel()
        //    {
        //        SkillId = x.SkillId,
        //        SkillName = x.SkillName,
        //        SkillExperience = x.SkillExperience
        //    }).ToList();
        //    return tr;
        //}

        public IList GetAll(int id)
        {
            DataEf.Entities.AbdulContext cnt = new DataEf.Entities.AbdulContext();


            var query1 = (from st in cnt.Certs
                          where st.UsId == id
                          select st).ToList();

            var tr = query1.Select(x => new CertModel()
            {
                CertId = x.CertId,
                CertificationName = x.CertificationName,
                AcquiredFrom = x.AcquiredFrom,
                CertLicence = x.CertLicence
            }).ToList();

            return tr;
        }



        //public bool Add(int id, ASkillModel aSkillModel)
        //{

        //    DataEf.Entities.Skill skill = new DataEf.Entities.Skill();



        //    skill.SkillName = aSkillModel.SkillName;
        //    skill.SkillExperience = aSkillModel.SkillExperience;
        //    skill.UsId = id;


        //    DataEf.Entities.AbdulContext abdulContext = new DataEf.Entities.AbdulContext();
        //    abdulContext.Skills.Add(skill);


        //    int res = abdulContext.SaveChanges();

        //    if (res > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public bool Add(int id, ACertModel aCertModel)
        {
            DataEf.Entities.Cert cert = new DataEf.Entities.Cert();

            cert.CertificationName = aCertModel.CertificationName;
            cert.AcquiredFrom = aCertModel.AcquiredFrom;
            cert.CertLicence = aCertModel.CertLicence;
            cert.UsId = id;

            DataEf.Entities.AbdulContext abdulContext = new DataEf.Entities.AbdulContext();
            abdulContext.Certs.Add(cert);

            int res = abdulContext.SaveChanges();
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //public bool Delete(int id)
        //{
        //    DataEf.Entities.Skill skill = new DataEf.Entities.Skill() { SkillId = id };
        //    DataEf.Entities.AbdulContext abdulContext = new DataEf.Entities.AbdulContext();
        //    abdulContext.Skills.Attach(skill);
        //    abdulContext.Skills.Remove(skill);
        //    int k = abdulContext.SaveChanges();
        //    if (k > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public bool Delete(int id)
        {
            DataEf.Entities.Cert cert = new DataEf.Entities.Cert() { CertId = id };
            DataEf.Entities.AbdulContext abdulContext = new DataEf.Entities.AbdulContext();
            abdulContext.Certs.Attach(cert);
            abdulContext.Certs.Remove(cert);
            int k = abdulContext.SaveChanges();
            if (k > 0)
            {
                return true;
            }
            else
            {
                return true;
            }
        }


        //public bool Update(int id, USkillModel uSkillModel)
        //{
        //    DataEf.Entities.Skill skill = new DataEf.Entities.Skill();
        //    skill.SkillId = uSkillModel.SkillId;
        //    skill.SkillName = uSkillModel.SkillName;
        //    skill.SkillExperience = uSkillModel.SkillExperience;
        //    skill.UsId = id;
        //    DataEf.Entities.AbdulContext abdulContext = new DataEf.Entities.AbdulContext();
        //    abdulContext.Skills.Update(skill);
        //    int j = abdulContext.SaveChanges();
        //    if (j > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public bool Update(int id, UCertModel uCertModel)
        {
            DataEf.Entities.Cert cert = new DataEf.Entities.Cert();
            cert.CertId = uCertModel.CertId;
            cert.AcquiredFrom = uCertModel.AcquiredFrom;
            cert.CertificationName = uCertModel.CertificationName;
            cert.CertLicence = uCertModel.CertLicence;
            cert.UsId = id;

            DataEf.Entities.AbdulContext abdulContext = new DataEf.Entities.AbdulContext();
            abdulContext.Certs.Update(cert);
            int j = abdulContext.SaveChanges();
            if (j > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

