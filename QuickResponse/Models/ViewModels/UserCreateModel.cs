using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models.ViewModels
{
    public class UserCreateModel
    {
        public int UserID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [UIHint("date")]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [UIHint("email")]
        public string Email { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        [Required]
        [UIHint("password")]
        [Compare("Password", ErrorMessage = "Confirm password and password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
