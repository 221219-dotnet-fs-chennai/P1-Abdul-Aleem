using System;
using System.Data;
using datahandle;

namespace UserProfile
{
    public class CompanyMenu
    {
        public CompanyMenu(int usid)
        {
            bool runner = true;
            while (runner)
            {
                Console.WriteLine("");

                Console.WriteLine("0 - Back");
                Console.WriteLine("1. Add Company");
                Console.WriteLine("2. Update Company");
                Console.WriteLine("3. Delete Company");
                Console.WriteLine("4. View All Company Details");
                Console.WriteLine("");


                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        runner = false;
                        break;

                    case 1:
                        AddCompany ads = new AddCompany();
                        ads.CompanyAdder(usid);
                        break;
                    case 2:
                        UpdateCompany up = new UpdateCompany();
                        up.CompanyUpdate(usid);
                        break;
                    case 3:
                        DeleteCompany dl = new DeleteCompany();
                        dl.CompanyDelete(usid);
                        break;
                    case 4:
                        ViewCompany vs = new ViewCompany();
                        vs.CompanyView(usid);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input");
                        break;

                }


            }
        }
    }

    public class AddCompany
    {
        public void CompanyAdder(int usid)
        {
            Console.WriteLine("Enter The Company Name");
            string CompName = Console.ReadLine();

            Console.WriteLine("Enter Job Role");
            string CompAbout = Console.ReadLine();

            Console.WriteLine("Enter the Start Date in YYYY-MM-DD format");
            string CompStart = Console.ReadLine();

            Console.WriteLine("Enter the End Date in YYYY-MM-DD format");
            string CompEnd = Console.ReadLine();


            SqlHandle sq = new SqlHandle();
            string skill_name = sq.SqlQueryWriterSkill($"Insert into pro.comp(about,comp_name,start_date,end_date,us_id) Values('{CompAbout}','{CompName}','{CompStart}','{CompEnd}',{usid});");
            skill_name = sq.SqlQueryWriterSkill($"SELECT * from pro.comp;");
            //Console.WriteLine(skill_no);
            if (skill_name == CompAbout)
            {
                Console.WriteLine("Experience Added Successfully");
            }
            else
            {
                Console.WriteLine("Experience unable to add");
            }

        }
    }

    public class UpdateCompany
    {
        public void CompanyUpdate(int usid)
        {
            SqlHandle sq = new SqlHandle();

            DataTable reader = sq.SqlQeryWriterSkillUpdate($"select k.comp_id,k.comp_name,k.about,k.start_date,k.end_date from pro.comp as k WHERE k.us_id = {usid};");
            //Console.WriteLine(reader);
            Console.WriteLine("CompanyId    CompanyName   JobRole   StartDate    EndDate ");
            Console.WriteLine("");

            foreach (DataRow dataRow in reader.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");

            Console.WriteLine("Enter the CompanyId to update");

            int res = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Company Name to Update");
            string resname = Console.ReadLine();
            Console.WriteLine("Enter Your Job Role");
            string resabout = Console.ReadLine();
            Console.WriteLine("Enter the Start Date to Update in YYYY-MM-DD");
            string resstart = Console.ReadLine();
            Console.WriteLine("Enter the End Date to Update in YYYY-MM-DD");
            string resend = Console.ReadLine();




            //            UPDATE pro.skills
            //SET skill_name = 'helloworld', skill_experience = 21
            //WHERE skill_id = 12;

            sq.sqlQueryDelete($"UPDATE pro.comp SET about = '{resabout}', comp_name = '{resname}', start_date = '{resstart}', end_date = '{resend}' WHERE comp_id = {res};");
            Console.WriteLine("Update Success");


        }
    }

    public class DeleteCompany
    {
        public void CompanyDelete(int usid)
        {
            SqlHandle sq = new SqlHandle();


            DataTable reader = sq.SqlQeryWriterSkillUpdate($"select k.comp_id,k.comp_name,k.about,k.start_date,k.end_date from pro.comp as k WHERE k.us_id = {usid};");
            //Console.WriteLine(reader);
            Console.WriteLine("CompanyId    CompanyName   JobRole  StartDate EndDate ");
            Console.WriteLine("");

            foreach (DataRow dataRow in reader.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");

            Console.WriteLine("Enter the CompanyId you want to delete");
            int skill_id = Convert.ToInt32(Console.ReadLine());
            sq.sqlQueryDelete($"DELETE FROM pro.comp WHERE comp_id ={skill_id}");
            Console.WriteLine("Deleted SuccessFully");

        }
    }

    public class ViewCompany
    {
        public void CompanyView(int usid)
        {
            SqlHandle sq = new SqlHandle();


            DataTable reader = sq.SqlQeryWriterSkillUpdate($"select k.comp_id,k.comp_name,k.about,k.start_date,k.end_date from pro.comp as k WHERE k.us_id = {usid};");
            //Console.WriteLine(reader);
            Console.WriteLine("CompanyId    CompanyName   JobRole  StartDate  EndDate ");
            Console.WriteLine("");

            foreach (DataRow dataRow in reader.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");


        }
    }
}

