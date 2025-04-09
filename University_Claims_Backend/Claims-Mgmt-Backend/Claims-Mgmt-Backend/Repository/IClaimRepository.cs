using Claims_Mgmt_Backend.DTOs;
using Claims_Mgmt_Backend.Models;

namespace Claims_Mgmt_Backend.Repository
{
    public interface IClaimRepository
    {
        int SaveClaim(ClaimsRequestDTO dto);
        List<Claim> AllClaims();
        List<Claim> MemberClaims(int id);
        void updateClaim(UpdateClaimDTO dto);
        Claim? GetClaim(int id);
        List<Claim> FilterClaims(FilterClaimDTO filter);
    }
}
