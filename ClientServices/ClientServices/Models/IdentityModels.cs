﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ClientServices.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<TermReason> TermReasons { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientContact> ClientContacs { get; set; }

        public DbSet<ContactType> ContactTypes { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<ClientContactPerson> ClientContactPersons { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<VendorContactPerson> VendorContactPersons { get; set; }

        public DbSet<ClientVendorRelationship> ClientVendorRelationships { get; set; }

        public DbSet<ClientVendorJunction> ClientVendorJunctions { get; set; }

        public DbSet<ContractInfo> ContractInfo { get; set; } 

        public DbSet<FormularyType> FormularyTypes { get; set; }

        public DbSet<ProgramType> ProgramTypes { get; set; }

        public DbSet<PricingType> PricingTypes { get; set; }

        public DbSet<ContractFormularyJunction> ContractFormularyJunctions { get; set; }

        public DbSet<ContractProgramJunction> ContractProgramJunctions { get; set; }

        public DbSet<RatePeriod> RatePeriods { get; set; }

        public DbSet<Rate> Rates { get; set; }

        public DbSet<RateType> RateTypes { get; set; }
    }
}