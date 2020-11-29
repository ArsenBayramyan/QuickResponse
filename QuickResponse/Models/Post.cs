﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models
{
    public class Post
    {
        [Key]
        public string Id { get; set; }
        public string PostName { get; set; }
        public string PostType { get; set; }
        public string Body { get; set; }
        public DateTime? PostDate { get; set; }
        public bool? IsDeleted { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
    }
}
