using System;
namespace DataEf
{
    public class LoginClass
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public LoginClass(int idd, string namee)
        {
            this.Id = idd;
            this.Name = namee;
        }
    }
}

