using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Visifire.Charts;
using HealthyInformation.Utility;

namespace HealthyInfomation.Windows.Analysis
{
    /// <summary>
    /// HealthyLevelAnalysis.xaml 的交互逻辑
    /// </summary>
    public partial class HealthyGradeAnalysis : WindowBase
    {
        AnalysisFacade facade;
        public HealthyGradeAnalysis()
        {
            InitializeComponent();
            facade = new AnalysisFacade(this);
            this.DataContext = this;
            this.Loaded += HealthyGradeAnalysis_Loaded;
            this.PropertyChanged += HealthyGradeAnalysis_PropertyChanged;
        }

        private void HealthyGradeAnalysis_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Year))
            {
                this.InitData();
            }
        }

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
                years.Add(new KeyValuePair<int, string>(0, CommonResource.Default_Select));
                var yearRange = Enumerable.Range(minYear, DateTime.Now.Year - minYear + 1);
                IEnumerator<int> yearEnumerator = yearRange.GetEnumerator();
                while (yearEnumerator.MoveNext())
                {
                    years.Add(new KeyValuePair<int, string>(yearEnumerator.Current, string.Concat(yearEnumerator.Current, " 年")));
                }
                return years.OrderByDescending(y => y.Key).ToList();
            }
        }

        private void HealthyGradeAnalysis_Loaded(object sender, RoutedEventArgs e)
        {
            this.Year = DateTime.Now.Year;
            this.InitData();
        }

        private async void InitData()
        {
            var datalist = await facade.GetGetHealthyGradeAnalysis(this.Year);
            string[] healthyGradeNames = Enum.GetNames(typeof(HealthyGradeEnums));
            int[] healthyGradeValues = Enum.GetValues(typeof(HealthyGradeEnums)).Cast<int>().ToArray();
            List<string> dataYList = (from int grade in healthyGradeValues
                                      join data in datalist on grade equals data.HealthyGrade into temp
                                      from tt in temp.DefaultIfEmpty()
                                      select tt != null ? tt.TotalCount.GetValueOrDefault(0).ToString() : decimal.Zero.ToString()).ToList();
            this.AnalysisChart.CreateChartPie("健康等级年度分析统计", healthyGradeNames.ToList(), dataYList, 500, 260, dataPoint_MouseLeftButtonDown);
            this.DG_Detail.ItemsSource = null;
        }

        private async void dataPoint_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int grade = 0;
            string gradeName = (sender as DataPoint).Tag as string;
            if (gradeName == "甲")
            {
                grade = 1;
            }
            else if (gradeName == "乙")
            {
                grade = 2;
            }
            else
            {
                grade = 3;
            }
            var result = await facade.GetHealthyGradeDetail(grade, Year);
            this.DG_Detail.ItemsSource = result;
        }
    }
}
