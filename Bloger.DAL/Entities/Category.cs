using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloger.DAL.Entities
{
    public partial class Category
    {

        [Key]
        public int ID { get; set; }

        [StringLength(150)]
        public string TitleC { get; set; }
    }
}
