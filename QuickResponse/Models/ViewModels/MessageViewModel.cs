using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models.ViewModels
{
    public class MessageViewModel
    {
        public int MessageId { get; set; }
        [Display(Name = "Ուղարկողի Էլ․ հասցե")]
        public string FromUserEmail { get; set; }
        [Display(Name = "Ստացողի Էլ․ հասցե")]
        public string ToUserEmail { get; set; }
        [Display(Name = "Հաղորդագրություն")]
        [Required]
        public string Body { get; set; }
        [Display(Name = "Փոստի լինքը")]
        public string PostLink { get; set; }
        [Display(Name = "Հաղորդագրությունը ուղարկելու ամսաթիվը")]
        public DateTime MessageSentDate { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<MessageViewModel> Messages { get; set; }
        public IEnumerable<UserCreateModel> Users { get; set; }
    }
}
