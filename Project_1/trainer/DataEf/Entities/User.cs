using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataEf.Entities;

[Table("user", Schema = "pro")]
public partial class User
{
    [Key]
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("first_name")]
    [StringLength(100)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(100)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column("email_id")]
    [StringLength(100)]
    [Unicode(false)]
    public string EmailId { get; set; } = null!;

    [Column("password")]
    [StringLength(20)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Column("phone_no")]
    public long PhoneNo { get; set; }

    [Column("city")]
    [StringLength(100)]
    [Unicode(false)]
    public string? City { get; set; }

    [InverseProperty("Us")]
    public virtual ICollection<Cert> Certs { get; } = new List<Cert>();

    [InverseProperty("Us")]
    public virtual ICollection<Comp> Comps { get; } = new List<Comp>();

    [InverseProperty("Us")]
    public virtual ICollection<Edu> Edus { get; } = new List<Edu>();

    [InverseProperty("Us")]
    public virtual ICollection<Skill> Skills { get; } = new List<Skill>();
}
