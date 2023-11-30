using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urb.Application.Urb.IRepositories;
using Urb.Persistance.Urb.DataConext;

namespace Urb.Persistance.Urb.UnitOfWork
{
    public class UnitOfWork
    {
        //UserManager IdentityUserManager;
        IUserRepository User { get; }
        ITokenManagerRepository Token { get; }

        private MainDataContext _mainDataContext;
        private UserTokenDataContext UserTokenDataContext { get; }

        private IDbContextTransaction _dbContextTransaction;

        public void BeginTransaction()
        {
            _dbContextTransaction = UserTokenDataContext.Database.BeginTransaction();
        }
        public int Commit()
        {
            return UserTokenDataContext.SaveChanges();
        }
        public void Rollback()
        {
            _dbContextTransaction.Rollback();
            _dbContextTransaction.Dispose();
            _dbContextTransaction = null;
        }
    }
}
