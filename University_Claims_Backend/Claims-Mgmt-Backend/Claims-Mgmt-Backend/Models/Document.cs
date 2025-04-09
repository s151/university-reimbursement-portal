using System;
using System.Collections.Generic;

namespace Claims_Mgmt_Backend.Models
{
    public partial class Document
    {
        public int Id { get; set; }
        public int? ClaimId { get; set; }
        public string? Doctype { get; set; }
        public string? Docfile { get; set; }

        public virtual Claim? Claim { get; set; }
    }
}
