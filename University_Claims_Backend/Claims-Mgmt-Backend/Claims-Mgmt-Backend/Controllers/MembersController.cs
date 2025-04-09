using Claims_Mgmt_Backend.DTOs;
using Claims_Mgmt_Backend.Models;
using Claims_Mgmt_Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace Claims_Mgmt_Backend.Controllers
{
    [Route("api/v{version:apiVersion}/members")]
    [ApiController]
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Authorize]
    public class Membersv1Controller : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IClaimRepository _claimRepository;
        public Membersv1Controller(IMemberRepository repository, IClaimRepository claimRepository)
        {
            this._memberRepository = repository;
            this._claimRepository = claimRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_memberRepository.GetMembers());
        }

        [HttpGet("{id}")]
        public IActionResult GetMemeberDetails(int id)
        {
            return Ok(_memberRepository.GetMember(id));
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
        [AllowAnonymous]
        public IActionResult Register(Member member)
        {
            _memberRepository.RegisterMember(member);
            return Ok(new { msg = "Member registered successfully" });
        }

        [HttpPost("validate")]
        [AllowAnonymous]
        //[SwaggerDefaultValue({"userid": "admin","pwd":"admin"})]
        [Produces("application/json")]
        public IActionResult Validate(LoginDTO dto)
        {
            var result=_memberRepository.Validate(dto);
            if(result is null)
            {
                return BadRequest("Invalid username or password");
            }
            var response = new LoginResponse
            {
                Token = CreateToken(result),
            };

            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken);

            return Ok(response);
        }

        private void SetRefreshToken(RefreshToken refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires=refreshToken.Expires,

            };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token=Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires=DateTime.Now.AddMinutes(5),
                Created= DateTime.Now
            };
            return refreshToken;
        }

        private string CreateToken(Member member)
        {

            List<System.Security.Claims.Claim> claims = new List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim("username",member.Mname),
                new System.Security.Claims.Claim("email",member.Email),
                new System.Security.Claims.Claim("id",member.Id.ToString()),
                new System.Security.Claims.Claim("role", member.Isadmin ? "Admin" : "Member")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AnandMasterKeyVeryLongKeyForSecurity"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims,expires:DateTime.Now.AddMinutes(5),signingCredentials: creds);

            var jwt=new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
