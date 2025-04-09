using Claims_Mgmt_Backend.DTOs;
using Claims_Mgmt_Backend.Models;

namespace Claims_Mgmt_Backend.Repository
{
    public interface IMemberRepository
    {
        void RegisterMember(Member member);
        Member? GetMember(int id);
        Member? Validate(LoginDTO dto);
        List<Member> GetMembers();
    }
}
