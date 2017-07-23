using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HealthyInformation.FrameWork
{
    public class WindowBase : Window, INotifyPropertyChanged
    {
        public WindowBase()
        {
            this.FontFamily = new System.Windows.Media.FontFamily("Microsoft YaHei");
        }

        private Visibility removeVisibility;
        public Visibility RemoveVisibility
        {
            get
            {
                return removeVisibility;
            }
            set
            {
                removeVisibility = value;
                RaisePropertyChanged("RemoveVisibility");
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.Close();
                });
            }
        }

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region messagebox

        protected void ShowMessage(string message)
        {
            MessageBox.Show(message, "提示", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        protected void ShowWarning(string message)
        {
            MessageBox.Show(message, "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        protected MessageBoxResult ShowConfirm(string message)
        {
            return MessageBox.Show(message, "提示信息", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        #endregion
    }
}
