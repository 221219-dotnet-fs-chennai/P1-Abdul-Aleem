using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataEf.Entities;

[Table("movies")]
public partial class Movie
{
    [Key]
    public int Mid { get; set; }

    public string Mname { get; set; } = null!;

    public string Director { get; set; } = null!;

    public int TicketPrice { get; set; }
}
