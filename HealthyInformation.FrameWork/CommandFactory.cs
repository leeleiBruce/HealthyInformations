using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace HealthyInformation.FrameWork
{
    public class CommandFactory
    {
        public static ICommand CreateCommand(Action<object> action)
        {
            return new CommonCommand(action);
        }

        public static ICommand CreateCommand(Action<object> action, Func<object, bool> func)
        {
            return new CommonCommand(action, func);
        }

        class CommonCommand : ICommand
        {
            Action<object> ExecuteMethod;
            Func<object, bool> CanExecuteMethod;
            public event EventHandler CanExecuteChanged;

            public CommonCommand(Action<object> action, Func<object, bool> func)
            {
                this.ExecuteMethod = action;
                this.CanExecuteMethod = func;
            }

            public CommonCommand(Action<object> action)
            {
                this.ExecuteMethod = action;
            }

            public bool CanExecute(object parameter)
            {
                if (CanExecuteMethod != null)
                {
                    return CanExecuteMethod(parameter);
                }

                return true;
            }

            public void Execute(object parameter)
            {
                if (ExecuteMethod != null)
                {
                    ExecuteMethod(parameter);
                }
            }
        }
    }
}
