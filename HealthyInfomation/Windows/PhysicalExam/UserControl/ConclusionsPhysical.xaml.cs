using HealthyInformation.ClientEntity.PhysicalExam.ViewModel;
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
using HealthyInformation.FrameWork.Extension;
using HealthyInformation.ClientEntity.PhysicalExam.Request;
using HealthyInformation.FrameWork.AuthorUser;
using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using System.ComponentModel;
using HealthyInformation.ClientEntity.PhysicalExam.Entity;

namespace HealthyInfomation.Windows.PhysicalExam.UserControl
{
    /// <summary>
    /// ConclusionsPhysical.xaml 的交互逻辑
    /// </summary>
    public partial class ConclusionsPhysical : WindowBase
    {
        PhysicalExamMaxFacade physicalExamMaxFacade;
        CommonDiseaseFacade commonDiseaseFacade;
        AircrewEntity aircrewEntity;
        public ConclusionsPhysical()
        {
            InitializeComponent();
        }

        public ConclusionsPhysical(AircrewEntity aircrewEntity, int year)
            : this()
        {
            this.aircrewEntity = aircrewEntity;
            this.physicalExamMaxFacade = new PhysicalExamMaxFacade(this);
            this.commonDiseaseFacade = new CommonDiseaseFacade(this);
            this.InitData(year);
            this.DataContext = this;
            this.PropertyChanged += ConclusionsPhysical_PropertyChanged;
        }

        #region ViewModel

        private ConclusionPhysicalModel conclusionPhysicalModel;
        public ConclusionPhysicalModel ConclusionPhysicalModel
        {
            get
            {
                return conclusionPhysicalModel;
            }
            set
            {
                conclusionPhysicalModel = value;
                RaisePropertyChanged("ConclusionPhysicalModel");
            }
        }

        private List<CommonDiseaseEntity> commonDiseaseList;
        public List<CommonDiseaseEntity> CommonDiseaseList
        {
            get
            {
                return commonDiseaseList;
            }
            set
            {
                commonDiseaseList = value;
                RaisePropertyChanged("CommonDiseaseList");
            }
        }

        private CommonDiseaseEntity commonDiseaseEntity;
        public CommonDiseaseEntity CommonDiseaseEntity
        {
            get
            {
                return commonDiseaseEntity;
            }
            set
            {
                commonDiseaseEntity = value;
                RaisePropertyChanged("CommonDiseaseEntity");
            }
        }

        public List<KeyValuePair<int, string>> HealthGradeList
        {
            get
            {
                return new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(0,CommonResource.Default_Select),
                    new KeyValuePair<int, string>(1,"甲类"),
                    new KeyValuePair<int, string>(1,"乙类"),
                    new KeyValuePair<int, string>(1,"丙类")
                };
            }
        }

        #endregion

        #region Command

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (ConclusionPhysicalModel.TransactionNumber > 0)
                    {
                        UpdateConclusionPhysical();
                    }
                    else
                    {
                        CreateConclusionPhysical();
                    }
                });
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) => 
                {
                    RemoveConclusionPhysical();
                });
            }
        }

        #endregion

        #region Method

        private async void InitData(int year)
        {
            RemoveVisibility = Visibility.Collapsed;
            var response = await this.commonDiseaseFacade.GetCommonDiseaseList(string.Empty, 0, 1000);
            var commonDiseases = response != null ? response.CommonDiseaseList : null;
            commonDiseases.Insert(0, new CommonDiseaseEntity { TransactionNumber = 0, SymptomName = CommonResource.Default_Select });
            this.CommonDiseaseList = commonDiseases;
            this.CommonDiseaseEntity = CommonDiseaseList.FirstOrDefault();

            var conclusionPhysical = await this.physicalExamMaxFacade.GetConclusionsphysical(aircrewEntity.TransactionNumber, year);
            if (conclusionPhysical != null)
            {
                RemoveVisibility = Visibility.Visible;
                ConclusionPhysicalModel = AutoMapper.Mapper.Map<ConclusionsphysicalexamEntity, ConclusionPhysicalModel>(conclusionPhysical);
            }
        }

        private async void CreateConclusionPhysical()
        {
            if (this.ConclusionPhysicalModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<ConclusionPhysicalRequest>(this.ConclusionPhysicalModel);
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            request.AircrewID = this.aircrewEntity.TransactionNumber;
            await physicalExamMaxFacade.CreateConclusionPhysical(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        private async void UpdateConclusionPhysical()
        {
            if (this.ConclusionPhysicalModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<ConclusionPhysicalRequest>(this.ConclusionPhysicalModel);
            request.TransactionNumber = ConclusionPhysicalModel.TransactionNumber;
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            request.AircrewID = this.aircrewEntity.TransactionNumber;
            await physicalExamMaxFacade.UpdateConclusionPhysical(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        private async void RemoveConclusionPhysical()
        {
            if (this.ShowConfirm(CommonMsgResource.Msg_RemoveConfirm) == MessageBoxResult.Yes)
            {
                await this.physicalExamMaxFacade.RemoveConclusionPhysical(ConclusionPhysicalModel.TransactionNumber);
                this.ShowMessage(CommonMsgResource.Msg_RemoveSuccess);
                this.ConclusionPhysicalModel = new ConclusionPhysicalModel();
                this.RemoveVisibility = Visibility.Collapsed;
            }
        }

        #endregion

        private void ConclusionsPhysical_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "CommonDiseaseEntity")
            {
                if (this.CommonDiseaseEntity != null && this.CommonDiseaseEntity.TransactionNumber > 0)
                {
                    this.ConclusionPhysicalModel.DiseaseKeyword = CommonDiseaseEntity.SymptomName;
                }
            }
        }
    }
}
