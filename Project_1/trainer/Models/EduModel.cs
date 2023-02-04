﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;
public class EduModel
{
    public int EduId { get; set; }

    public string InstitutionName { get; set; } = null!;

    public string CourseName { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Cgpa { get; set; } = null!;

    public int UsId { get; set; }

}

