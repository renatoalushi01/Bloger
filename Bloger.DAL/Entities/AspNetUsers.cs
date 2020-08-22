using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloger.DAL.Entities
{
    public partial class AspNetUsers
    {
        [Key]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
        public virtual ICollection<Coments> Coments { get; set; }




    }
}
