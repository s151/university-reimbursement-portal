using System;
using System.Collections.Generic;

namespace Claims_Mgmt_Backend.Models
{
    public partial class Member
    {
        public Member()
        {
            Claims = new HashSet<Claim>();
        }

        public int Id { get; set; }
        public string Mname { get; set; } = null!;
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;
        public string Pwd { get; set; } = null!;
        public bool Isadmin { get; set; } = false;

        public virtual ICollection<Claim> Claims { get; set; }
    }
}
