using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.LoginManage
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUser(string userName);
    }
}
