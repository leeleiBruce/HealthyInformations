using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Visifire.Charts;

namespace HealthyInformation.Utility
{
    public static class ChatHelper
    {
        public static void CreateChartPie(this Grid grid, string name, List<string> valuex, List<string> valuey, int width = 500, int height = 300, MouseButtonEventHandler handler = null)
        {
            //创建一个图标
            Chart chart = new Chart();

            //设置图标的宽度和高度
            chart.Width = width;
            chart.Height = height;
            chart.Margin = new Thickness(0, 5, 0, 5);
            //是否启用打印和保持图片
            chart.ToolBarEnabled = true;

            //设置图标的属性
            chart.ScrollingEnabled = false;//是否启用或禁用滚动
            chart.View3D = true;//3D效果显示

            //创建一个标题的对象
            Title title = new Title();

            //设置标题的名称
            title.Text = name;
            title.Foreground = new SolidColorBrush(Colors.Orange);
            title.Padding = new Thickness(0, 10, 5, 0);

            //向图标添加标题
            chart.Titles.Add(title);

            // 创建一个新的数据线。               
            DataSeries dataSeries = new DataSeries();

            // 设置数据线的格式
            dataSeries.RenderAs = RenderAs.Pie;//柱状Stacked

            // 设置数据点              
            DataPoint dataPoint;
            for (int i = 0; i < valuex.Count; i++)
            {
                // 创建一个数据点的实例。                   
                dataPoint = new DataPoint();
                // 设置X轴点                    
                dataPoint.AxisXLabel = valuex[i];

                dataPoint.LegendText = "##" + valuex[i];
                //设置Y轴点                   
                dataPoint.YValue = double.Parse(valuey[i]);
                dataPoint.Tag = valuex[i];
                //添加一个点击事件        
                if (handler != null)
                {
                    dataPoint.MouseLeftButtonDown += handler;
                }
                //添加数据点                   
                dataSeries.DataPoints.Add(dataPoint);
            }

            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeries);

            //将生产的图表增加到Grid，然后通过Grid添加到上层Grid.           

            grid.Children.Add(chart);
        }
    }
}
