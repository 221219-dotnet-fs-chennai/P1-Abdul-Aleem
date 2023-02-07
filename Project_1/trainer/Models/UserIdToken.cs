using System;
namespace Models
{
    public class UserIdToken : TokenClass
    {
        public string Token { set; get; }

        public int Id { get; set; }
    }
}

