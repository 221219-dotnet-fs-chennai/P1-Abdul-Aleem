using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class SkillModel
    {

        public int SkillId { get; set; }


        public string SkillName { get; set; }

        public int SkillExperience { get; set; }

        //public int UsId { get; set; }

    }

    public class ASkillModel : TokenClass
    {
        new public string Token { get; set; }


        //public int SkillId { get; set; }


        public string SkillName { get; set; }

        public int SkillExperience { get; set; }

        //public int UsId { get; set; }

    }

    public class USkillModel : TokenClass
    {
        new public string Token { get; set; }


        public int SkillId { get; set; }


        public string SkillName { get; set; }

        public int SkillExperience { get; set; }

        //public int UsId { get; set; }

    }
}

