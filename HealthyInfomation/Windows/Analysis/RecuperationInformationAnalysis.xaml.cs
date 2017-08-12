using HealthyInfomation.Facade;
using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Visifire.Charts;

namespace HealthyInfomation.Windows.UserControl
{
    /// <summary>
    /// RecuperationInformationAnalysis.xaml 的交互逻辑
    /// </summary>
    public partial class RecuperationInformationAnalysis : WindowBase
    {
        RecuperationInformationFacade facade;
        public RecuperationInformationAnalysis()
        {
            InitializeComponent();
            facade = new RecuperationInformationFacade(this);
            InitData();
        }

        private async void InitData()
        {
            var result = await facade.GetRecuperationAnalysisCountResult();
            this.CreateChartPie(string.Concat(DateTime.Now.Year, "年度疗养人员统计"), new List<string> { "未参加疗养人员", "参加疗养人员" }
            , new List<string> { (result.TotalCont - result.AppendCount).ToString(), result.AppendCount.ToString() });
        }

        public void CreateChartPie(string name, List<string> valuex, List<string> valuey)
        {
            //创建一个图标
            Chart chart = new Chart();

            //设置图标的宽度和高度
            chart.Width = 500;
            chart.Height = 340;
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
                dataPoint.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown);
                //添加数据点                   
                dataSeries.DataPoints.Add(dataPoint);
            }

            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeries);

            //将生产的图表增加到Grid，然后通过Grid添加到上层Grid.           

            AnalysisChart.Children.Add(chart);
        }

        private async void dataPoint_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((sender as DataPoint).Tag.ToString() == "参加疗养人员")
            {
                var result = await facade.GetRecuperationAnalysisResult();
                this.DG_Detail.ItemsSource = result;
            }
        }
    }
}
