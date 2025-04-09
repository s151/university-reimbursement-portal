using Claims_Mgmt_Backend.Models;

namespace Claims_Mgmt_Backend.DTOs
{
    public class ClaimsRequestDTO
    {
        public string Vno { get; set; } = null!;
        public string Vtype { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int InsuranceAmount { get; set; }
        public int? ClaimAmount { get; set; }
        public int? Memberid { get; set; }
        public string? doctype1 { get; set; }
        public string? doctype2 { get; set;}
        public string? doctype3 { get; set;}
        public IFormFile? docFile1 { get; set; }
        public IFormFile? docFile2 { get;set; }
        public IFormFile? docFile3 { get;set; }

    }
}
