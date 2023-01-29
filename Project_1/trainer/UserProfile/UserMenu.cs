namespace UserProfile;
public class UserMenu
{
    public int k;
    public UserMenu(int usid)
    {
        bool runner = true;
        while (runner)
        {
            Console.WriteLine("0.Back");
            Console.WriteLine("1.Education Menu");
            Console.WriteLine("2.Skills Menu");
            Console.WriteLine("3.Experience Menu");
            Console.WriteLine("4.Certification Menu");
            Console.WriteLine("5.My Profile");
            Console.WriteLine("");
            Console.WriteLine("Enter Your Choice");
            try
            {
                k = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter a correct output {0}", e);
            }

            switch (k)
            {
                case 0:
                    runner = false;
                    break;
                case 1:
                    EducationMenu ed = new EducationMenu(usid);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }



        }
    }

}

