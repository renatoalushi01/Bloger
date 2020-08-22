using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloger.Models
{
    public class ComentsViewModel
    {

        public int ID { get; set; }
        [Required]
        public string Description { get; set; }
        public  int PostsID { get; set; }
        public string UserName { get; set; }
        public  string AspNetUsersId { get; set; }
    }
}
