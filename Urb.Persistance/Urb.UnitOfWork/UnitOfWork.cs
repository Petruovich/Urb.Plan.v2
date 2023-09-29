using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urb.Persistance.Urb.DataConext;

namespace Urb.Persistance.Urb.UnitOfWork
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
