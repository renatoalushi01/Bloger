using Bloger.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloger.Models
{
    public class PostViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Photo { get; set; }
        public IFormFile ImageFile { get; set; }
        public string CTitle { get; set; }
        public List<Coments> coments { get; set; }

        public List<SelectListItem> Category; 
        public string[] Categories { get; set; }
        public string AspNetUsersId { get; set; }
    }
}
