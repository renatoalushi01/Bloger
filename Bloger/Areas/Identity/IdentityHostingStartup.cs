using System;
using Bloger.Areas.Identity.Data;
using Bloger.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Bloger.Areas.Identity.IdentityHostingStartup))]
namespace Bloger.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BlogerContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BlogerContextConnection")));

                services.AddDefaultIdentity<BlogerUser>()
                    .AddEntityFrameworkStores<BlogerContext>();
            });
        }
    }
}