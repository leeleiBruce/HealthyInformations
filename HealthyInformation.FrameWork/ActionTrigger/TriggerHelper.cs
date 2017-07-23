using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Interactivity = System.Windows.Interactivity;

namespace HealthyInformation.FrameWork.ActionTrigger
{
    public static class TriggerHelper
    {
        public static void AttchEventTriggerAction<TViewModel>(this DependencyObject dpObj, BaseTrigger<DependencyObject, TViewModel> triggerAcion, string eventName)
            where TViewModel : WindowBase
        {
            if (dpObj == null || triggerAcion == null || string.IsNullOrEmpty(eventName)) return;

            Interactivity.EventTrigger eventTrigger = new Interactivity.EventTrigger(eventName);
            eventTrigger.Actions.Add(triggerAcion);
            Interactivity.Interaction.GetTriggers(dpObj).Add(eventTrigger);
        }

        public static void DetachEventTriggerAction(this DependencyObject dpObj)
        {
            if (dpObj == null) return;

            Interactivity.TriggerCollection triggerCollection = Interactivity.Interaction.GetTriggers(dpObj);
            if (triggerCollection != null && triggerCollection.Count == 0) return;
            foreach (var triggerAction in triggerCollection)
            {
                triggerAction.Detach();
            }
        }
    }
}
