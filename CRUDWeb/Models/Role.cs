using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Role
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Role Name is Required")]
        public string RoleName { get; set; }
    }
}
