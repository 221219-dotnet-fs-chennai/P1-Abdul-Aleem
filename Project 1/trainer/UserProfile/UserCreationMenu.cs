using System;
using datahandle;

namespace UserProfile
{
    public class UserCreationMenu
    {
        public UserCreationMenu(int usid, string name)
        {
            bool runner = true;

            while (runner)
            {

                //Console.WriteLine("Hi Abdul");
                Console.WriteLine(@"
 __      __       .__                               
/  \    /  \ ____ |  |   ____  ____   _____   ____  
\   \/\/   // __ \|  | _/ ___\/  _ \ /     \_/ __ \ 
 \        /\  ___/|  |_\  \__(  <_> )  Y Y  \  ___/ 
  \__/\  /  \___  >____/\___  >____/|__|_|  /\___  >
       \/       \/          \/            \/     \/ 

");
                Console.WriteLine($"Welcome Back {name}");
                Console.WriteLine("");
                Console.WriteLine("0 - LogOut");
                Console.WriteLine("1 - Education");
                Console.WriteLine("2 - Skills");
                Console.WriteLine("3 - Experience");
                Console.WriteLine("4 - Certification");
                Console.WriteLine("5 - My Profile");
                Console.WriteLine("");



                int num = Convert.ToInt32(Console.ReadLine());

                switch (num)
                {
                    case 0:
                        Console.WriteLine(@"
   __    __  __________                  __________                   __    __    
  / /   / /  \______   \ ___.__.  ____   \______   \ ___.__.  ____    \ \   \ \   
 / /   / /    |    |  _/<   |  |_/ __ \   |    |  _/<   |  |_/ __ \    \ \   \ \  
 \ \   \ \    |    |   \ \___  |\  ___/   |    |   \ \___  |\  ___/    / /   / /  
  \_\   \_\   |______  / / ____| \___  >  |______  / / ____| \___  >  /_/   /_/   
                     \/  \/          \/          \/  \/          \/               

");
                        Logging lg = new Logging();

                        lg.InformationWriter($"user Logged ");

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

                        MyProfile mp = new MyProfile();
                        mp.MyProfile1(usid);
                        mp.MyProfileEdu(usid);
                        mp.MyProfileExperience(usid);
                        mp.MyProfileSkills(usid);
                        mp.MyProfileCertification(usid);
                        Console.ReadLine();
                        break;

                }
            }



        }
    }
}

