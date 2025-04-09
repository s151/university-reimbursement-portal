using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Claims_Mgmt_Backend.DTOs
{
    public class LoginDTO
    {
        [Required]
        [DefaultValue("admin")]
        public string Userid  { get; set; }
        [Required]
        [DefaultValue("admin")]
        public string Pwd { get; set; }
    }
}
