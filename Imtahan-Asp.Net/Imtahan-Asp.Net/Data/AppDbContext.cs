using Imtahan_Asp.Net.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.Data
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<CustomUser> customUsers { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<Setting> settings { get; set; }
        public DbSet<SocialMedia> socialMedias { get; set; }
        public DbSet<Team> teams { get; set; }
    }
}
