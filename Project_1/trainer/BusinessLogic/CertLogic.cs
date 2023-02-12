using System;
using Models;
using System.Collections;

namespace BusinessLogic
{
    public class CertLogic : ICrud<ACertModel, UCertModel>
    {

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

