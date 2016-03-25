using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace telegram.webHook.Models.Entities
{
    [Table("Message")]
    public class Message
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int FromId { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        public string FromUsername { get; set; }
        public string FromFirstname { get; set; }
        public string FromLastname { get; set; }
        [Required]
        public int ChatId { get; set; }
        public string LocationLatitude { get; set; }
        public string LocationLongitude { get; set; }
    }
}
