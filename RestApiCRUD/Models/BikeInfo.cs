using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class BikeInfo
    {
        [Key]
        public int? Id { get; set; }
        [MaxLength(200)]
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public DateTime? CheckOutTime { get; set; }
        [Required]
        public DateTime? CheckInTime { get; set; }
        public int? TotalTimeSpent { get; set; }
        public DateTime? DateModified { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
