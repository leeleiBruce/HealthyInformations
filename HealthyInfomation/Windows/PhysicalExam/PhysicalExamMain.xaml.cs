using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInfomation.Windows.PhysicalExam.UserControl;
using HealthyInformation.ClientEntity.SystemManage.Entity;
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

namespace HealthyInfomation.Windows.PhysicalExam
{
    /// <summary>
    /// PhysicalExamMain.xaml 的交互逻辑
    /// </summary>
    public partial class PhysicalExamMain : WindowBase
    {
        int minYear = 2010;
        AircrewEntity currentAircrew;
        PhysicalExamMaxFacade physicalExamMaxFacade;
        MedicalIdentificationFacade medicalIdentificationFacade;
        public PhysicalExamMain()
        {
            InitializeComponent();
        }

        public PhysicalExamMain(AircrewEntity aircrewEntity)
            : this()
        {
            currentAircrew = aircrewEntity;
            this.DataContext = this;
            this.Year = DateTime.Now.Year;
            this.physicalExamMaxFacade = new PhysicalExamMaxFacade(this);
            this.medicalIdentificationFacade = new MedicalIdentificationFacade(this);
            this.PropertyChanged += PhysicalExamMain_PropertyChanged;
        }

        private void PhysicalExamMain_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Year")
            {

            }
        }

        private int year;
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
                RaisePropertyChanged("Year");
            }
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
                return years;
            }
        }

        public ICommand OpenCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    string className = string.Concat(this.GetType().Namespace, ".UserControl.", obj.ToString());
                    var instance = Activator.CreateInstance(Type.GetType(className), currentAircrew, this.Year);
                    (instance as WindowBase).ShowDialog();
                });
            }
        }
    }
}
