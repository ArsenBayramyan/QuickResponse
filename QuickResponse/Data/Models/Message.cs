using QuickResponse.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Data.Models
{
    public class Message:IMessage
    {
        public int MessageId { get; set; }
        public string FromUserEmail { get; set; }
        public string ToUserEmail { get; set; }
        public string Body { get; set; }
        public string PostLink { get; set; }
        public DateTime MessageSentDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
