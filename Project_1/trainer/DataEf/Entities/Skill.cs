using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataEf.Entities;

[Table("skills", Schema = "pro")]
public partial class Skill
{
    [Key]
    [Column("skill_id")]
    public int SkillId { get; set; }

    [Column("skill_name")]
    [StringLength(256)]
    [Unicode(false)]
    public string SkillName { get; set; } = null!;

    [Column("skill_experience")]
    public int SkillExperience { get; set; }

    [Column("us_id")]
    public int UsId { get; set; }

    [ForeignKey("UsId")]
    [InverseProperty("Skills")]
    public virtual User Us { get; set; } = null!;
}
