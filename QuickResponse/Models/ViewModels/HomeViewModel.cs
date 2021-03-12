using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<User> Users { get; set; }
        public List<Post> Posts { get; set; }
        public User CurrentUser { get; set; }
        public User ToUser { get; set; }
    }
}
