using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Urb.Domain.Urb.Models;

namespace Urb.Domain.Urb.DataConext
{
    public class UserTokenDataContext: IdentityDbContext
    {
     public DbSet<IdentityUser> Users { get; set; }
     public DbSet<Token> Tokens { get; set; }
        protected override void OnModelCreating(ModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Entity<Token>()
                .HasKey(t => t.TokenId);

            dbModelBuilder.Entity<Token>()
                .HasOne<User>(q => q.User)
                .WithMany(q => q.Tokens)
                .HasForeignKey(t => t.TokenId);                

            dbModelBuilder.Entity<User>()
                .HasMany<Token>(e => e.Tokens)
            .WithOne(x => x.User);

                base.OnModelCreating(dbModelBuilder);

        }
        public UserTokenDataContext(DbContextOptions<UserTokenDataContext> contextOptions)
      : base(contextOptions)
        {
        }
    }
}

















































//dbModelBuilder.Entity<Token>()
//        .HasRequired(x => x.User);
//        //.HasOptional(p => p.Token);