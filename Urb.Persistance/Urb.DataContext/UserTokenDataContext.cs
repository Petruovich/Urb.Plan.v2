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

namespace Urb.Persistance.Urb.DataConext
{
    public class UserTokenDataContext : IdentityDbContext
    {
        public DbSet<RentedBoard> RentedBords { get; set; }
        public DbSet<Billboard> Billboards { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.RentedBoards)
            //    .WithOne(rb => rb.User)
            //    .HasForeignKey(rb => rb.UserId)
            //    .OnDelete(DeleteBehavior.Cascade); 
          
            modelBuilder.Entity<Billboard>()
                .HasKey(b => b.BillboardId); 

            modelBuilder.Entity<Billboard>()
                .HasMany(b => b.RentedBoards)
                .WithOne(rb => rb.Billboard)
                .HasForeignKey(rb => rb.BillboardId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<RentedBoard>()
                .HasKey(rb => rb. RentedBoardId); 

            modelBuilder.Entity<RentedBoard>()
                .Property(rb => rb.StartDate)
                .IsRequired();

            modelBuilder.Entity<RentedBoard>()
                .Property(rb => rb.EndDate)
                .IsRequired();
        }



        public UserTokenDataContext(DbContextOptions<UserTokenDataContext> contextOptions)
      : base(contextOptions)
        {
        }
        
    }
}
















































//public DbSet<User> Users { get; set; }
//public DbSet<Token> Tokens { get; set; }
//protected override void OnModelCreating(ModelBuilder dbModelBuilder)
//{
//    dbModelBuilder.Entity<Token>()
//        .HasKey(t => t.TokenId);

//    dbModelBuilder.Entity<Token>()
//        .HasOne<User>(q => q.User)
//        .WithMany(q => q.Tokens)
//        .HasForeignKey(t => t.TokenId);

//    dbModelBuilder.Entity<User>()
//        .HasMany<Token>(e => e.Tokens)
//    .WithOne(x => x.User);

//    base.OnModelCreating(dbModelBuilder);

//}
//dbModelBuilder.Entity<Token>()
//        .HasRequired(x => x.User);
//        //.HasOptional(p => p.Token);