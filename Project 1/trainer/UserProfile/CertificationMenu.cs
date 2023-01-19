using System;
using System.Data;
using datahandle;

namespace UserProfile
{
    public class CertificationMenu
    {
        public CertificationMenu(int usid)
        {
            bool runner = true;
            while (runner)
            {
                Console.WriteLine("0 - Back");
                Console.WriteLine("1. Add Certification");
                Console.WriteLine("2. Update Certification");
                Console.WriteLine("3. Delete Certification");
                Console.WriteLine("4. View All Certification");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        runner = false;
                        break;

                    case 1:
                        AddCertification ads = new AddCertification();
                        ads.CertificationAdder(usid);
                        break;
                    case 2:
                        UpdateCertification up = new UpdateCertification();
                        up.CertificationUpdate(usid);
                        break;
                    case 3:
                        DeleteCertification dl = new DeleteCertification();
                        dl.CertificationDelete(usid);
                        break;
                    case 4:
                        ViewCertification vs = new ViewCertification();
                        vs.CertificationView(usid);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input");
                        break;

                }


            }
        }
    }

    public class AddCertification
    {
        public void CertificationAdder(int usid)
        {
            Console.WriteLine("Enter The Certification Name");
            string CertName = Console.ReadLine();

            Console.WriteLine("Enter The Organisation Name  that offered the certification");
            string CertOrg = Console.ReadLine();

            Console.WriteLine("Enter The Certification Licence Number");
            string CertLicense = Console.ReadLine();




            SqlHandle sq = new SqlHandle();
            string skill_name = sq.SqlQueryWriterSkill($"Insert into pro.cert(certification_name,acquired_from,cert_licence,us_id) Values('{CertName}','{CertOrg}','{CertLicense}',{usid});");
            skill_name = sq.SqlQueryWriterSkill($"SELECT * from pro.cert;");
            //Console.WriteLine(skill_no);
            if (skill_name == CertName)
            {
                Console.WriteLine("Certification Added Successfully");
            }
            else
            {
                Console.WriteLine("Certification unable to add");
            }

        }
    }

    public class UpdateCertification
    {
        public void CertificationUpdate(int usid)
        {
            SqlHandle sq = new SqlHandle();

            DataTable reader = sq.SqlQeryWriterSkillUpdate($"select k.cert_id,k.certification_name,k.acquired_from,k.cert_licence from pro.cert as k WHERE k.us_id = {usid};");
            //Console.WriteLine(reader);
            Console.WriteLine("CertificationID    CertificationName   Organization CertificateLicence ");
            foreach (DataRow dataRow in reader.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Enter the Certification Id to update");
            int res = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the CertificationName to Update");
            string resname = Console.ReadLine();
            Console.WriteLine("Enter the Certification Organization acquired from");
            string resorg = Console.ReadLine();
            Console.WriteLine("Enter the Certification License No for update");
            string reslic = Console.ReadLine();

            //            UPDATE pro.skills
            //SET skill_name = 'helloworld', skill_experience = 21
            //WHERE skill_id = 12;

            sq.sqlQueryDelete($"UPDATE pro.cert SET certification_name = '{resname}', acquired_from = '{resorg}', cert_licence = '{reslic}' WHERE cert_id = {res};");
            Console.WriteLine("Update Success");

        }
    }

    public class DeleteCertification
    {
        public void CertificationDelete(int usid)
        {
            SqlHandle sq = new SqlHandle();

            DataTable reader = sq.SqlQeryWriterSkillUpdate($"select k.cert_id,k.certification_name,k.acquired_from,k.cert_licence from pro.cert as k WHERE k.us_id = {usid};");
            //Console.WriteLine(reader);
            Console.WriteLine("CertificationID    CertificationName   Organization CertificateLicence ");
            foreach (DataRow dataRow in reader.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("Enter the CompanyId you want to delete");
            int skill_id = Convert.ToInt32(Console.ReadLine());
            sq.sqlQueryDelete($"DELETE FROM pro.cert WHERE cert_id ={skill_id}");
            Console.WriteLine("Deleted SuccessFully");

        }
    }




    public class ViewCertification
    {
        public void CertificationView(int usid)
        {
            SqlHandle sq = new SqlHandle();

            DataTable reader = sq.SqlQeryWriterSkillUpdate($"select k.cert_id,k.certification_name,k.acquired_from,k.cert_licence from pro.cert as k WHERE k.us_id = {usid};");
            //Console.WriteLine(reader);
            Console.WriteLine("CertificationID    CertificationName   Organization CertificateLicence ");
            foreach (DataRow dataRow in reader.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}

