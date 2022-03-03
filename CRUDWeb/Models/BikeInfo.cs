using System;
using System.ComponentModel.DataAnnotations;


namespace Web.Models
{
    public class BikeInfo
    {
        [Key]
        public int? Id { get; set; }
        [MaxLength(200)]
        [Required]
        public string CustomerName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}")]
        public DateTime? CheckOutTime { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}")]
        public DateTime? CheckInTime { get; set; }
        public int? TotalTimeSpent { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}")]
        public DateTime? DateModified { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
