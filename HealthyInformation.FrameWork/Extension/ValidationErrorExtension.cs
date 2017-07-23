using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.FrameWork.Extension
{
    public static class ValidationErrorExtension
    {
        public static bool HasValidationError(this IDataErrorInfo dataError)
        {
            var ctx = new ValidationContext(dataError, null, null);
            var errors = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            return !Validator.TryValidateObject(dataError, ctx, errors, true);
        }

        public static List<System.ComponentModel.DataAnnotations.ValidationResult> GetValidationError(this IDataErrorInfo dataError)
        {
            var ctx = new ValidationContext(dataError, null, null);
            var errors = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            Validator.TryValidateObject(dataError, ctx, errors, true);
            return errors;
        }
    }
}
