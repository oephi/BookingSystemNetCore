using System;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models
{
    public class Student
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Course { get; set; }

        public bool Paid { get; set; }

        [Display(Name = "Date Paid")]
        [DataType(DataType.Date)]
        public DateTime PaidDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [DataType(DataType.Text)]
        public string Comment { get; set; }
    }
}