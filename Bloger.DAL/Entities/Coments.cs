using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloger.DAL.Entities
{
    public partial class Coments
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public virtual int PostsID { get; set; }
        public virtual string AspNetUsersId { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Posts Posts{ get; set; }
    }
}
