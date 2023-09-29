using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urb.Persistance.Urb.Repositories
{
    internal class UserRepository
    {

        DbContext _dbContext;
        public void Create(User user)
        {
            _dbContext.Set<User>().Add(user);
        }
        public User GetById(string id)
        {
            return _dbContext.Set<User>().Find(id);
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _dbContext.Set<User>().FindAsync(id);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
        public void Update(User user)
        {
            _dbContext.Set<User>().Update(user);
        }
    }
}
