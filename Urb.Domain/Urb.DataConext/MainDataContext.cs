using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urb.Domain.Urb.Models;
using IdentityDbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Urb.Domain.Urb.DataConext
{
    public class MainDataContext : IdentityDbContext
    
    {
        
        public MainDataContext(DbContextOptions<MainDataContext> contextOptions)
       : base(contextOptions)
        {
        }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
