using System;
using System.ComponentModel.DataAnnotations;


namespace CRUDWeb.Models
{
    public class PersonalInfo
    {
        [Key]
        public int? Id { get; set; }
        [MaxLength(200)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(200)]
        [Required]
        public string LastName { get; set; }
        [Required]
        public long? PhoneNumber { get; set; }
        [MaxLength(200)]
        [Required]
        public string EmailAddress { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(200)]
        public string Notes { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
