using HealthyInfomation.Facade;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.AuthorUser;
using System.Windows.Input;
using HealthyInformation.FrameWork.ClientHelper;
using HealthyInformation.ClientEntity.SystemManage.Request;
using System.Threading.Tasks;

namespace HealthyInfomation.Windows
{
    /// <summary>
    /// ModifyPassWord.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyPassWord : WindowBase
    {
        UserFacade userFacade;
        public ModifyPassWord()
        {
            InitializeComponent();
            userFacade = new UserFacade(this);
            DataContext = this;
        }

        #region Property

        public string OriginalPassword
        {
            get
            {
                return txt_OrgPwd.Password.Trim();
            }
        }

        public string NewPassword
        {
            get
            {
                return txt_NewPwd.Password.Trim();
            }
        }

        public string RePassword
        {
            get
            {
                return txt_RePwd.Password.Trim();
            }
        }

        #endregion

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    SaveHandler();
                });
            }
        }

        private async void SaveHandler()
        {
            if (!await this.CheckUserPwd()) return;

            var newPwd = NewPassword.Aes("X86123321qwerasdf", "9915098765362112");
            var request = new UserPwdUpdateRequest
            {
                UserName = CPApplication.CurrentUser.UserName,
                NewPassWord = newPwd
            };

            await this.userFacade.UpdateUserPwd(request);
            this.ShowMessage("密码修改成功！");
            this.Close();
        }

        private async Task<bool> CheckUserPwd()
        {
            if (string.IsNullOrEmpty(OriginalPassword))
            {
                this.ShowMessage("原密码不能为空！");
                return false;
            }

            if (string.IsNullOrEmpty(NewPassword))
            {
                this.ShowMessage("新密码不能为空！");
                return false;
            }

            if (NewPassword.Length < 6 || NewPassword.Length > 15)
            {
                this.ShowMessage("新密码长度必须介于6到15位！");
                return false;
            }

            if (NewPassword != RePassword)
            {
                this.ShowMessage("两次密码不一致！");
                return false;
            }

            var user = await userFacade.GetUser(CPApplication.CurrentUser.UserName);
            var decryptPwd = user.PassWord.UnAes("X86123321qwerasdf", "9915098765362112");

            if (decryptPwd != OriginalPassword)
            {
                this.ShowMessage("原密码不正确！");
                return false;
            }

            return true;
        }
    }
}
