using System;
using System.Collections.Generic;

namespace Claims_Mgmt_Backend.Models
{
    public partial class Claim
    {
        public Claim()
        {
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Vno { get; set; } = null!;
        public string Vtype { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int InsuranceAmount { get; set; }
        public int? ClaimAmount { get; set; }
        public int? FinalAmount { get; set; }
        public DateTime? ReqDate { get; set; }=DateTime.Now;
        public string? Reason { get; set; }
        public DateTime? ProcessDate { get; set; }
        public string? Status { get; set; }
        public string? RejReason { get; set; }
        public int? Memberid { get; set; }

        public virtual Member? Member { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
