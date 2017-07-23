using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Interactivity = System.Windows.Interactivity;

namespace HealthyInformation.FrameWork.Behavior
{
    public abstract class BaseBehavior<TElement, TViewModel> : Interactivity.Behavior<TElement>
        where TElement : DependencyObject
        where TViewModel : ModelBase
    {
        public static readonly DependencyProperty ViewModelProperty =
              DependencyProperty.Register("ViewModel", typeof(TViewModel), typeof(BaseBehavior<TElement, TViewModel>), new PropertyMetadata(null));

        public BaseBehavior()
            : base()
        {
           
        }

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
            this.AttachEvent();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.DetachEvent();
        }

        protected abstract void AttachEvent();
        protected abstract void DetachEvent();

    }
}
