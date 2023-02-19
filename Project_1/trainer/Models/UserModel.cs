using System;


namespace Models
{
    public class UserModel
    {
        //public int UserId { get; set; }
        //public UserModel(string fname, string lname, string email, string pass, long phno, string city)
        //{
        //    this.FirstName = fname;
        //    this.LastName = lname;
        //    this.EmailId = email;
        //    this.Password = pass;
        //    this.PhoneNo = phno;
        //    this.City = city;
        //}

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailId { get; set; }

        public string Password { get; set; }

        public long PhoneNo { get; set; }

        public string City { get; set; }


    }

    public class UserModelTrainer
    {
        //public int UserId { get; set; }
        public UserModelTrainer(string fname, string lname, string email, string pass, long phno, string city)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.EmailId = email;
            this.Password = pass;
            this.PhoneNo = phno;
            this.City = city;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailId { get; set; }

        public string Password { get; set; }

        public long PhoneNo { get; set; }

        public string City { get; set; }


    }
}

//public Author(string name, short age, string title, bool mvp, DateTime pubdate)
//{
//    this.name = name;
//    this.age = age;
//    this.title = title;
//    this.mvp = mvp;
//    this.pubdate = pubdate;
//}