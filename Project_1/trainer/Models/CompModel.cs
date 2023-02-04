using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class CompModel
    {
        public int CompId { get; set; }

        public string About { get; set; } = null!;

        public string CompName { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int UsId { get; set; }

    }
}

