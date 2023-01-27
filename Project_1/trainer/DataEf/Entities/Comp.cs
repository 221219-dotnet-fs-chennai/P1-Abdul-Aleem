using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataEf.Entities;

[Table("comp", Schema = "pro")]
public partial class Comp
{
    [Key]
    [Column("comp_id")]
    public int CompId { get; set; }

    [Column("about")]
    [StringLength(100)]
    [Unicode(false)]
    public string About { get; set; } = null!;

    [Column("comp_name")]
    [StringLength(256)]
    [Unicode(false)]
    public string CompName { get; set; } = null!;

    [Column("start_date", TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column("end_date", TypeName = "date")]
    public DateTime EndDate { get; set; }

    [Column("us_id")]
    public int UsId { get; set; }

    [ForeignKey("UsId")]
    [InverseProperty("Comps")]
    public virtual User Us { get; set; } = null!;
}
