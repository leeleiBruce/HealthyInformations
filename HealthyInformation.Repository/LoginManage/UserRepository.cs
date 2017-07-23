using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.LoginManage
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public User GetUser(string userName)
        {
            return this._context.Set<User>().FirstOrDefault(u => u.UserName == userName);
        }
    }
}
