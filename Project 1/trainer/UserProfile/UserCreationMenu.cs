using System;

namespace UserProfile
{
    public class UserCreationMenu
    {
        public UserCreationMenu(int usid)
        {
            bool runner = true;

            while (runner)
            {

                Console.WriteLine("Hi Abdul");
                Console.WriteLine("0 - LogOut");
                Console.WriteLine("1 - Education");
                Console.WriteLine("2 - Skills");
                Console.WriteLine("3 - Experience");
                Console.WriteLine("4 - Certification");
                Console.WriteLine("5 - My Profile");

                int num = Convert.ToInt32(Console.ReadLine());

                switch (num)
                {
                    case 0:
                        runner = false;
                        break;
                    case 1:
                        Console.WriteLine("Education");
                        EducationMenu em = new EducationMenu(usid);
                        break;
                    case 2:
                        Console.WriteLine("Skills");
                        SkillsMenu sk = new SkillsMenu(usid);
                        break;
                    case 3:
                        Console.WriteLine("Experience");
                        CompanyMenu ex = new CompanyMenu(usid);
                        break;
                    case 4:
                        Console.WriteLine("Certification");
                        CertificationMenu ct = new CertificationMenu(usid);
                        break;
                    case 5:
                        Console.WriteLine("My Profile");
                        break;

                }
            }



        }
    }
}

