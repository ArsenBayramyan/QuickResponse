using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models.ViewModels
{
    public class ContactViewModel
    {
        [Display(Name = "Անուն")]
        public string Name { get; set; }
        [Display(Name = "Еmail")]
        public string Email { get; set; }
        [Display(Name = "Հեռախոսահամար")]
        public string Phone { get; set; }
        [Display(Name = "Հաղորդագրություն")]
        public string Message { get; set; }
    }
}
