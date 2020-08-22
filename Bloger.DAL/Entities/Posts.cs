using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloger.DAL.Entities
{
    public partial class Posts
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public virtual string AspNetUsersId { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual ICollection<Coments> Coments { get; set; }


    }
}
