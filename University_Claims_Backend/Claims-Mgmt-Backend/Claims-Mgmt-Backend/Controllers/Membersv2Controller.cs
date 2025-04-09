using Claims_Mgmt_Backend.DTOs;
using Claims_Mgmt_Backend.Models;
using Claims_Mgmt_Backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Claims_Mgmt_Backend.Controllers
{
    [Route("api/v{version:apiVersion}/members")]
    [ApiController]
    [ApiVersion("2")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class Membersv2Controller : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IClaimRepository _claimRepository;
        public Membersv2Controller(IMemberRepository repository,IClaimRepository claimRepository)
        {
            this._memberRepository = repository;
            this._claimRepository = claimRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new {msg="version2",data=_memberRepository.GetMembers()});
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            return Ok(new
            {
                members = _memberRepository.GetMembers().Count,
                claims = _claimRepository.AllClaims().Count
            });
        }

        [HttpPost]
        public IActionResult Register(Member member) 
        {
            _memberRepository.RegisterMember(member);
            return Ok(new { msg="Member registered successfully" });
        }

        [HttpPost("validate")]
        public IActionResult Validate(LoginDTO dto)
        {
            var result=_memberRepository.Validate(dto);
            if(result is null)
            {
                return BadRequest("Invalid username or password");
            }
            return Ok(result);
        }
    }
}
