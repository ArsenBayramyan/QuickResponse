using Microsoft.AspNetCore.Identity;
using QuickResponse.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace QuickResponse.Data.Models
{
    public class User:IdentityUser<int>,IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<Post> Posts { get; set; }
       
    }
}
