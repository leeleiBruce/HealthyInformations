using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Model;
using HealthyInformation.Repository.LoginManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.LoginManage
{
    public class UserService : BaseService<User>, IUserService
    {
        IUserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository(this.dbContext);
        }

        public User GetUser(string userName)
        {
            return this.userRepository.GetUser(userName);
        }

        public void UpdateUserPassWord(UserPwdUpdateRequest request)
        {
            var user = this.GetUser(request.UserName);
            if (user != null)
            {
                user.PassWord = request.NewPassWord;
                Update(user);
            }
        }
    }
}
