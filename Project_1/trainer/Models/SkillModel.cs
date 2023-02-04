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

        public int UsId { get; set; }

    }
}

