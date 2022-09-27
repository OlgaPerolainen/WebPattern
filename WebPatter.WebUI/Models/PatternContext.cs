using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebPatter.WebUI.Models
{
    public class PatternContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Pattern> Patterns { get; set; }
        public DbSet<UsersPattern> UsersPatterns { get; set; }
        public DbSet<ClientsPattern> ClientPatterns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersPattern>().HasKey(up => new { up.UserId, up.PatternId });
            modelBuilder.Entity<ClientsPattern>().HasKey(cp => new { cp.ClientId, cp.PatternId });
        }
    }
}