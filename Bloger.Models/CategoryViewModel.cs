using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloger.Models
{
    public class CategoryViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
