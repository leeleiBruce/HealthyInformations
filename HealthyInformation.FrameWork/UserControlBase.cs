using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HealthyInformation.FrameWork
{
    public class UserControlBase : UserControl, INotifyPropertyChanged
    {
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaiseError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                ((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
            }
            else
            {
                ((Control)sender).ToolTip = "";
            }
        }

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
