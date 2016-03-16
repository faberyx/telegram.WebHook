using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace telegram.webHook.Models.Entities
{
    [Table("Dictionary")]
    public class Dictionary
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string Type { get; set; }
        public string Action { get; set; }
    }
}
