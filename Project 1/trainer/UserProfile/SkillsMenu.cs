using System;
using System.Collections.Generic;
using datahandle;
namespace UserProfile
{
    public class SkillsMenu
    {
        public SkillsMenu(int usid)
        {
            bool runner = true;
            while (runner)
            {
                Console.WriteLine("0 - Back");
                Console.WriteLine("1. Add Skills");
                Console.WriteLine("2. Update Skills");
                Console.WriteLine("3. Delete Skills");
                Console.WriteLine("4. View All Skills");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        runner = false;
                        break;

                    case 1:
                        AddSkills ads = new AddSkills();
                        ads.SkillAdder(usid);
                        break;
                }


            }



        }
    }

    public class AddSkills
    {
        public void SkillAdder(int usid)
        {
            Console.WriteLine("Enter The Skill Name");
            string SkillName = Console.ReadLine();

            Console.WriteLine("Enter the Skill experience in months");
            int SkillExperience = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(usid);

            SqlHandle sq = new SqlHandle();
            string skill_name = sq.SqlQueryWriterSkill($"Insert into pro.skills(skill_name,skill_experience,us_id) Values('{SkillName}',{SkillExperience},{usid});");
            skill_name = sq.SqlQueryWriterSkill($"SELECT * from pro.skills;");
            //Console.WriteLine(skill_no);
            if (skill_name == SkillName)
            {
                Console.WriteLine("Skill Added Successfully");
            }
            else
            {
                Console.WriteLine("Skill unable to add");
            }

            //                INSERT into pro.skills(skill_name, skill_experience, us_id)
            //VALUES('Python', 20, 3);





        }

    }
}

