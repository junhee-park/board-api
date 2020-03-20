using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoardApi.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        public string UserPassword { get; set; }

        [Required]
        public string UserName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UserDate { get; set; }
    }
}