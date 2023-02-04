using System;
using DataEf;
using Microsoft.EntityFrameworkCore;

namespace UserProfile
{
    public class EducationMenu : ICrud
    {
        public int k;
        public EducationMenu(int id)
        {
            Console.WriteLine("1.Add Education Details");
            Console.WriteLine("2.Update Education Details");
            Console.WriteLine("3.Delte Education Details");
            Console.WriteLine("4.View Education Details");
            Console.WriteLine("");
            try
            {
                k = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            switch (k)
            {
                case 1:
                    Add(id);
                    break;
                case 2:
                    Update(id);
                    break;
                case 3:
                    //Delete();
                    break;
                case 4:
                    View();
                    break;
                default:
                    Console.WriteLine("Enter a valid input");
                    break;
            }


        }

        public void Add(int id)
        {
            Console.WriteLine("Enter Your Institution Name :");
            string iname = Console.ReadLine();
            Console.WriteLine("Enter Your Course Name :");
            string cname = Console.ReadLine();
            Console.WriteLine("Enter Your start date (yyyy-mm-dd) :");
            string sdate = Console.ReadLine();
            Console.WriteLine("Enter your end date (yyyy-mm-dd) :");
            string edate = Console.ReadLine();
            Console.WriteLine("Enter your cgpa :");
            string cgpa = Console.ReadLine();


            DataEf.Entities.Edu edu = new DataEf.Entities.Edu();
            edu.InstitutionName = iname;
            edu.CourseName = cname;
            edu.StartDate = Convert.ToDateTime(sdate);
            edu.EndDate = Convert.ToDateTime(edate);
            edu.Cgpa = cgpa;
            edu.UsId = id;

            DataHandle dt = new DataHandle();
            dt.UserProfileAdd(edu);


        }
        public void Update(int id)
        {
            DataEf.Entities.AbdulContext cnt = new DataEf.Entities.AbdulContext();
            var query = from st in cnt.Edus
                        where st.UsId == id
                        select st;

            foreach (var q in query)
            {
                Console.WriteLine($"Edu ID - {q.EduId}, Institution - {q.InstitutionName}, Course - {q.CourseName}, StartDate - {q.StartDate}, EndDate - {q.EndDate}, Cgpa - {q.Cgpa} ");
            }

            Console.WriteLine("Enter The Edu ID you want update :");
            int eduid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the institution name :");
            string insname = Console.ReadLine();

            Console.WriteLine("Enter the course name :");
            string cname = Console.ReadLine();


            Console.WriteLine("Enter the start date :");
            string sdate = Console.ReadLine();

            Console.WriteLine("Enter the end date :");
            string edate = Console.ReadLine();


            Console.WriteLine("Enter the Cgpa :");
            string cgpa = Console.ReadLine();
            //Console.WriteLine("Enter the ");

            DataEf.Entities.Edu edu = new DataEf.Entities.Edu();
            edu.EduId = eduid;
            edu.InstitutionName = insname;
            edu.CourseName = cname;
            edu.StartDate = Convert.ToDateTime(sdate);
            edu.EndDate = Convert.ToDateTime(edate);
            edu.Cgpa = cgpa;
            edu.UsId = id;

            DataHandle dt = new DataHandle();
            dt.UserProfileUpdate(edu);


        }
        public void Delete(int id)
        {
            DataEf.Entities.AbdulContext cnt = new DataEf.Entities.AbdulContext();
            var query = from st in cnt.Edus
                        where st.UsId == id
                        select st;


            foreach (var q in query)
            {
                Console.WriteLine($"Edu ID - {q.EduId}, Institution - {q.InstitutionName}, Course - {q.CourseName}, StartDate - {q.StartDate}, EndDate - {q.EndDate}, Cgpa - {q.Cgpa} ");
            }

            Console.WriteLine("Enter the Education Id you want to delete :");
            int dnum = Convert.ToInt32(Console.ReadLine());


        }
        public void View() { }
    }
}

