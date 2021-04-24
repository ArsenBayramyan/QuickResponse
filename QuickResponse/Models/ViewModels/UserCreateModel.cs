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
        [Display(Name = "ԱՆուն")]
        public string FirstName { get; set; }
        [Display(Name = "Ազգանուն")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Ծննդյան ամսաթիվ")]
        [Required]
        [UIHint("date")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Սեռ")]
        [Required]
        public string Gender { get; set; }
        [Display(Name = "Քաղաք")]

        [Required]
        public string City { get; set; }
        [Display(Name = "Հասցե")]
        public string Address { get; set; }
        [Display(Name = "Բջջային հեռախոսահամար")]
        [Required]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        [Required]
        [UIHint("email")]
        public string Email { get; set; }
        [Display(Name = "Գաղտնաբառ")]
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        [Display(Name = "Կրկնեք գաղտնաբառը")]
        [Required]
        [UIHint("password")]
        [Compare("Password", ErrorMessage = "Confirm password and password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
