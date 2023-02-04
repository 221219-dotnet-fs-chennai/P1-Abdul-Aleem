using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class CertModel
    {
        public int CertId { get; set; }

        public string CertificationName { get; set; } = null!;

        public string AcquiredFrom { get; set; } = null!;

        public string CertLicence { get; set; } = null!;

        public int UsId { get; set; }

    }
}

