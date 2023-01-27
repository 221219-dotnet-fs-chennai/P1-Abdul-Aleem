using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataEf.Entities;

[Table("edu", Schema = "pro")]
public partial class Edu
{
    [Key]
    [Column("edu_id")]
    public int EduId { get; set; }

    [Column("institution_name")]
    [StringLength(256)]
    [Unicode(false)]
    public string InstitutionName { get; set; } = null!;

    [Column("course_name")]
    [StringLength(256)]
    [Unicode(false)]
    public string CourseName { get; set; } = null!;

    [Column("start_date", TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column("end_date", TypeName = "date")]
    public DateTime EndDate { get; set; }

    [Column("cgpa")]
    [StringLength(10)]
    [Unicode(false)]
    public string Cgpa { get; set; } = null!;

    [Column("us_id")]
    public int UsId { get; set; }

    [ForeignKey("UsId")]
    [InverseProperty("Edus")]
    public virtual User Us { get; set; } = null!;
}
