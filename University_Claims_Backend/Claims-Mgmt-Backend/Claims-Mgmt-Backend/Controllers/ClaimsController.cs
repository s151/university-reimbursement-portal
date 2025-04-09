using Claims_Mgmt_Backend.DTOs;
using Claims_Mgmt_Backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Claims_Mgmt_Backend.Controllers
{
    [Route("api/v{version:apiVersion}/claims")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class Claimsv1Controller : ControllerBase
    {
        private readonly IClaimRepository _claimRepository;

        public Claimsv1Controller(IClaimRepository claimRepository)   
        {
            _claimRepository = claimRepository;
        }

        [HttpPost]
        public IActionResult saveClaim([FromForm] ClaimsRequestDTO dto)
        {
            var claimId=_claimRepository.SaveClaim(dto);
            return Ok(new { msg = "Claim submitted successfully",claimId=claimId });
        }

        [HttpGet]
        public IActionResult getAllClaims() 
        {
            return Ok(_claimRepository.AllClaims());
        }

        [HttpGet("{id}")]
        public IActionResult getClaimsDetails(int id) 
        {
            return Ok(_claimRepository.GetClaim(id));
        }

        [HttpGet("members/{id}")]
        public IActionResult getMemberClaims(int id)
        {
            return Ok(_claimRepository.MemberClaims(id));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClaim(int id,UpdateClaimDTO dto)
        {
            dto.ClaimId= id;
            _claimRepository.updateClaim(dto);
            return Ok(new {msg="Claim updated successfully"});
        }

        [HttpGet("filter")]
        public IActionResult filterClaims([FromQuery]FilterClaimDTO dto)
        {
            return Ok(_claimRepository.FilterClaims(dto));
        }
    }
}
