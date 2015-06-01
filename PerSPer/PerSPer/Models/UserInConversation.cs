using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PerSPer.Models
{
    public class UserInConversation
    {
        [Key]
        public int Id { get; set; }

        public bool Owner { get; set; }

        public int ConversationId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("ConversationId")]
        public virtual Conversation Conversation { get; set; }

    }
}