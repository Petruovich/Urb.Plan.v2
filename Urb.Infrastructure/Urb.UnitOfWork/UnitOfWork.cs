using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urb.Domain.Urb.DataConext;

namespace Urb.Infrastructure.Urb.UnitOfWork
{
    public class UnitOfWork
    {
        MainDataContext _mainDataContext;

        public int Commit()
        {
            return _mainDataContext.SaveChanges();
        }
    } 
}
