using Claims_Mgmt_Backend.DTOs;
using Claims_Mgmt_Backend.Models;

namespace Claims_Mgmt_Backend.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly claimsdbContext _claimsdbContext;
        public MemberRepository(claimsdbContext context)
        {
            this._claimsdbContext = context;
        }

        public Member? GetMember(int id)
        {
            return _claimsdbContext.Members.FirstOrDefault(x => x.Id == id);  
        }

        public List<Member> GetMembers()
        {
            return _claimsdbContext.Members.ToList();
        }

        public void RegisterMember(Member member)
        {
            _claimsdbContext.Members.Add(member);
            _claimsdbContext.SaveChanges();
        }

        public Member? Validate(LoginDTO dto)
        {
            return _claimsdbContext.Members.FirstOrDefault(x => x.Email == dto.Userid && x.Pwd == dto.Pwd);
        }
    }
}
