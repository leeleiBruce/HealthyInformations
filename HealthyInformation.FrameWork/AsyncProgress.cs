using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using HealthyInformation.FrameWork.Extension;
using HealthyInformation.FrameWork.ControlStyle;

namespace HealthyInformation.FrameWork
{
    public class AsyncProgress
    {
        Popup asyncPopup;
        WindowBase windowBase;
        object lockObj = new object();
        bool isShowProgress;
        static List<WindowBase> runWindowList = new List<WindowBase>();
        static AsyncProgress asyncProgress = new AsyncProgress();
        private AsyncProgress()
        {
        }

        public static AsyncProgress GetInstance()
        {
            return asyncProgress;
        }

        public void InjectWindowBase(WindowBase pagebase, bool isShowProgress = true)
        {
            this.windowBase = pagebase;
            this.isShowProgress = isShowProgress;
        }

        public void ShowPopup()
        {
            if (!isShowProgress) return;

            lock (lockObj)
            {
                if (runWindowList.Contains(windowBase)) return;

                runWindowList.Add(windowBase);
            }

            Border border = new Border();
            border.HorizontalAlignment = HorizontalAlignment.Stretch;
            border.VerticalAlignment = VerticalAlignment.Top;
            border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1162A9"));
            border.CornerRadius = new CornerRadius(10);
            StackPanel stack = new StackPanel();
            stack.HorizontalAlignment = HorizontalAlignment.Stretch;
            stack.VerticalAlignment = VerticalAlignment.Top;
            stack.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1162A9"));
            stack.Margin = new Thickness(0, 5, 30, 0);
            stack.Orientation = Orientation.Vertical;
            TextBlock txtTitle = new TextBlock();
            txtTitle.Text = "正在处理，请稍后.....";
            txtTitle.HorizontalAlignment = HorizontalAlignment.Center;
            txtTitle.FontSize = 16;
            txtTitle.Foreground = new SolidColorBrush(Colors.White);
            stack.Children.Add(txtTitle);
            var easyProgress = new EasyProgressBar();
            easyProgress.Margin = new Thickness(0, 10, 0, 0);
            stack.Children.Add(easyProgress);
            asyncPopup = new Popup();
            asyncPopup.AllowsTransparency = true;
            asyncPopup.PopupAnimation = PopupAnimation.Fade;
            asyncPopup.StaysOpen = true;
            asyncPopup.PlacementTarget = windowBase;
            asyncPopup.Opacity = 0.7;
            //asyncPopup.Width = windowBase.ActualWidth;
            //asyncPopup.Height = windowBase.ActualWidth;
            asyncPopup.Placement = PlacementMode.Center;
            stack.Height = 160;
            stack.Width = 390;
            border.Height = stack.Height + 10;
            border.Child = stack;
            asyncPopup.Child = border;
            var mainGrid = windowBase.GetChildOfType<Grid>();
            if (mainGrid == null)
            {
                mainGrid = windowBase.Content as Grid;
            }
            (mainGrid as Grid).Children.Add(asyncPopup);
            windowBase.IsEnabled = false;
            asyncPopup.IsOpen = true;
        }

        public void HidePopup()
        {
            if (this.asyncPopup != null)
            {
                lock (lockObj)
                {
                    runWindowList.Remove(windowBase);
                }
                windowBase.IsEnabled = true;
                this.asyncPopup.IsOpen = false;

            }
        }
    }
}
