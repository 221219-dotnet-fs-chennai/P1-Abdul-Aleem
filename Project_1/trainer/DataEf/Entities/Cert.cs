using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataEf.Entities;

[Table("cert", Schema = "pro")]
public partial class Cert
{
    [Key]
    [Column("cert_id")]
    public int CertId { get; set; }

    [Column("certification_name")]
    [StringLength(256)]
    [Unicode(false)]
    public string CertificationName { get; set; } = null!;

    [Column("acquired_from")]
    [StringLength(256)]
    [Unicode(false)]
    public string AcquiredFrom { get; set; } = null!;

    [Column("cert_licence")]
    [StringLength(256)]
    [Unicode(false)]
    public string CertLicence { get; set; } = null!;

    [Column("us_id")]
    public int UsId { get; set; }

    [ForeignKey("UsId")]
    [InverseProperty("Certs")]
    public virtual User Us { get; set; } = null!;
}
