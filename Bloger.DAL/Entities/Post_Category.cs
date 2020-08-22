using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloger.DAL.Entities
{
    public partial class Post_Category
    { 
        public int PostsID { get; set; }
        public int CategoryID { get; set; }
        [Key]
        public int ID { get; set; }
        public virtual Category Category { get; set; }
        public virtual Posts Posts { get; set; }
    }
}
