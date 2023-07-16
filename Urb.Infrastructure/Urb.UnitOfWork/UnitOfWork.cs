using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urb.Domain.Urb.DataConext;
using Urb.Domain.Urb.IRepositories;

namespace Urb.Infrastructure.Urb.UnitOfWork
{
    public class UnitOfWork
    {
        IUserRepository User { get; }
        ITokenManagerRepository Token { get; }

        private MainDataContext _mainDataContext;

        private IDbContextTransaction _dbContextTransaction;

        public void BeginTransaction()
        {
            _dbContextTransaction = _mainDataContext.Database.BeginTransaction();
        }
        public int Commit()
        {
            return _mainDataContext.SaveChanges();
        }
        public void Rollback()
        {
            _dbContextTransaction.Rollback();
            _dbContextTransaction.Dispose();
            _dbContextTransaction = null;
        }
    }
}
