namespace Claims_Mgmt_Backend.DTOs
{
    public class UpdateClaimDTO
    {
        public int? FinalAmount { get; set; }
        public DateTime? ProcessDate { get; set; }= DateTime.Now;
        public string? Status { get; set; }
        public string? RejReason { get; set; }
        public int ClaimId { get; set; }
    }
}
