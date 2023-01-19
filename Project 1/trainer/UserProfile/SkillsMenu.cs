using System;
using System.Collections.Generic;
using System.Data;
using datahandle;
using Microsoft.VisualBasic;

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
                    case 2:
                        UpdateSkills up = new UpdateSkills();
                        up.SkillUpdate(usid);
                        break;
                    case 3:
                        DeleteSkill dl = new DeleteSkill();
                        dl.SkillDelete(usid);
                        break;
                    case 4:
                        ViewSkills vs = new ViewSkills();
                        vs.SkillView(usid);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input");
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

    public class UpdateSkills
    {
        public void SkillUpdate(int usid)
        {
            SqlHandle sq = new SqlHandle();

            DataTable reader = sq.SqlQeryWriterSkillUpdate($"select k.skill_id,k.skill_name,k.skill_experience from pro.Skills as k WHERE k.us_id = {usid};");
            //Console.WriteLine(reader);
            Console.WriteLine("SkillID    SkillName   SkillExperience");
            foreach (DataRow dataRow in reader.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Enter the SkillId to update");
            int res = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the SkillName to Update to");
            string resname = Console.ReadLine();
            Console.WriteLine("Enter the Skill Experience");
            int resex = Convert.ToInt32(Console.ReadLine());

            //            UPDATE pro.skills
            //SET skill_name = 'helloworld', skill_experience = 21
            //WHERE skill_id = 12;

            sq.sqlQueryDelete($"UPDATE pro.skills SET skill_name = '{resname}', skill_experience = {resex} WHERE skill_id = {res};");
            Console.WriteLine("Update Success");








        }
    }

    public class DeleteSkill
    {
        public void SkillDelete(int usid)
        {
            SqlHandle sq = new SqlHandle();

            DataTable reader = sq.SqlQeryWriterSkillUpdate($"select k.skill_id,k.skill_name,k.skill_experience from pro.Skills as k WHERE k.us_id = {usid};");
            //Console.WriteLine(reader);
            Console.WriteLine("SkillID    SkillName   SkillExperience");
            foreach (DataRow dataRow in reader.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("Enter the SkillId you want to delete");
            int skill_id = Convert.ToInt32(Console.ReadLine());
            sq.sqlQueryDelete($"DELETE FROM pro.skills WHERE skill_id ={skill_id}");
            Console.WriteLine("Deleted SuccessFully");

        }
    }

    public class ViewSkills
    {
        public void SkillView(int usid)
        {
            SqlHandle sq = new SqlHandle();

            DataTable reader = sq.SqlQeryWriterSkillUpdate($"select k.skill_id,k.skill_name,k.skill_experience from pro.Skills as k WHERE k.us_id = {usid};");
            //Console.WriteLine(reader);
            Console.WriteLine("SkillID    SkillName   SkillExperience");
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

