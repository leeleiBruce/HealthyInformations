using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.FrameWork
{
    public class ModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        #region property

        public int TransactionNumber { get; set; }

        #endregion

        #region event

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region implement
        public string Error
        {
            get { return string.Empty; }
        }

        public string this[string columnName]
        {
            get
            {
                var validationContext = new ValidationContext(this, null, null);
                validationContext.MemberName = columnName;
                var validateResultList = new List<ValidationResult>();
                var result = Validator.TryValidateProperty(this.GetType().GetProperty(columnName).GetValue(this, null), validationContext, validateResultList);
                if (validateResultList.Count > 0)
                {
                    return string.Join(Environment.NewLine, validateResultList.Select(r => r.ErrorMessage).ToArray());
                }

                return string.Empty;
            }
        }

        #endregion
    }
}
