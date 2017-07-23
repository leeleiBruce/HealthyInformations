using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Interactivity = System.Windows.Interactivity;

namespace HealthyInformation.FrameWork.ActionTrigger
{
    public class BaseTrigger<TElement, TViewModel> : Interactivity.TriggerAction<TElement>
        where TElement : DependencyObject
        where TViewModel : WindowBase
    {
        public static readonly DependencyProperty ViewModelProperty =
              DependencyProperty.Register("ViewModel", typeof(TViewModel), typeof(BaseTrigger<TElement, TViewModel>), new PropertyMetadata(null));

        Action<object> invokeAction;
        public BaseTrigger(Action<object> invokeAction)
        {
            this.invokeAction = invokeAction;
        }

        public BaseTrigger() { }

        public TViewModel ViewModel
        {
            get
            {
                return (TViewModel)GetValue(ViewModelProperty);
            }
            set
            {
                SetValue(ViewModelProperty, value);
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

        protected override void Invoke(object parameter)
        {
            if (invokeAction != null)
            {
                invokeAction(parameter);
            }
        }
    }
}
