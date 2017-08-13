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

        protected int minYear = 2010;

        private int year;
        public int Year
        {
            get { return year; }
            set { year = value; RaisePropertyChanged("Year"); }
        }

        public List<KeyValuePair<int, string>> YearList
        {
            get
            {
                var years = new List<KeyValuePair<int, string>>();
                years.Insert(0,new KeyValuePair<int, string>(0, "--- 请选择 ---"));
                var yearRange = Enumerable.Range(minYear, DateTime.Now.Year - minYear + 1);
                IEnumerator<int> yearEnumerator = yearRange.GetEnumerator();
                while (yearEnumerator.MoveNext())
                {
                    years.Add(new KeyValuePair<int, string>(yearEnumerator.Current, string.Concat(yearEnumerator.Current, " 年")));
                }
                return years.OrderByDescending(y => y.Key).ToList();
            }
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
