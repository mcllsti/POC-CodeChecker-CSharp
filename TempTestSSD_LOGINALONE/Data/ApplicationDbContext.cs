using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace TempTestSSD_LOGINALONE.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ApplicationUser>(config =>
            {

                config.Ignore(c => c.PhoneNumber);

                config.Ignore(c => c.EmailConfirmed);
                config.Ignore(c => c.TwoFactorEnabled);
                config.Ignore(c => c.PhoneNumberConfirmed);

            });

            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();

            
        }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {





        }





    }
}
