﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickResponse.Data.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public string PostID { get; set; }
        public string PostName { get; set; }
        public string Category { get; set; }
        public string PostType { get; set; }
        public string Body { get; set; }
        public DateTime? PostDate { get; set; }
        public bool? IsDeleted { get; set; }
        public string UserId { get; set; }
    }
}
