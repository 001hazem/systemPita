using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pita.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pita.Web.Data
{
    public class PitaDbContext : IdentityDbContext<User>
    {
        public PitaDbContext(DbContextOptions<PitaDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CategoryCompany>().HasKey(x => new { x.CategoryId, x.CompanyId });
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<CategoryCompany> CategoryCompanies { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ContentChangeLog> ContentChangeLogs { get; set; }

    }
}
