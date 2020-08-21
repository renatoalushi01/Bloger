using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Bloger.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the BlogerUser class
    public class BlogerUser : IdentityUser
    {
        [Column]
        public string FirstName { get; set; }
        [Column]
        public string LastName { get; set; }
    }
}
