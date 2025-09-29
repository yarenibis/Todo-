using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;


namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>

    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Todo> Todos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Todo>()
            .HasOne(t => t.User)
            .WithMany()  // Eğer AppUser'da Todos koleksiyonu yoksa
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole{
                   Id = "Admin",
                   Name="Admin",
                   NormalizedName="ADMIN"
                },
                new IdentityRole{
                   Id = "User",
                   Name="User",
                   NormalizedName="USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }


}