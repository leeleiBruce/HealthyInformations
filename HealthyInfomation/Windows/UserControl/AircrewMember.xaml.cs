using HealthyInfomation.Facade;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.ClientEntity.SystemManage.ViewModel;
using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using HealthyInfomation.Resource;

namespace HealthyInfomation.Windows.UserControl
{
    /// <summary>
    /// AircrewMember.xaml 的交互逻辑
    /// </summary>
    public partial class AircrewMember : WindowBase
    {
        AircrewFacade aircrewFacade;

        public AircrewMember(List<RecuperationMemberEntity> recuperationMemberList)
        {
            InitializeComponent();
            this.AircrewMemberModel = new AircrewMemberModel();
            this.aircrewFacade = new AircrewFacade(this);
            this.DataContext = this;
            this.InitAircrew(recuperationMemberList);
        }

        #region ViewModel

        private AircrewMemberModel aircrewMemberModel;
        public AircrewMemberModel AircrewMemberModel
        {
            get
            {
                return aircrewMemberModel;
            }
            set
            {
                aircrewMemberModel = value;
                RaisePropertyChanged("AircrewMemberModel");
            }
        }

        #endregion

        #region Command

        public ICommand SelectAllCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    var param = obj as string;
                    if (param == "Right")
                    {
                        ProcessAllSelect(AircrewMemberModel.AircrewEntityList);
                    }
                    else
                    {
                        ProcessAllSelect(AircrewMemberModel.SelectedAircrewEntityList);
                    }
                });
            }
        }

        public ICommand InvertSelectCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    var param = obj as string;
                    if (param == "Right")
                    {
                        ProcessInvertSelect(AircrewMemberModel.AircrewEntityList);
                    }
                    else
                    {
                        ProcessInvertSelect(AircrewMemberModel.SelectedAircrewEntityList);
                    }
                });
            }
        }

        public ICommand MoveLeftCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (AircrewMemberModel.SelectedAircrewEntityList == null)
                    {
                        AircrewMemberModel.SelectedAircrewEntityList = new ObservableCollection<AircrewEntity>();
                    }

                    var selectedAircrewList = AircrewMemberModel.AircrewEntityList.Where(a => a.IsChecked).ToList();
                    List<AircrewEntity> originalList = AircrewMemberModel.SelectedAircrewEntityList.ToList();
                    foreach (var selectedAircrew in selectedAircrewList)
                    {
                        if (originalList.Any(o => o.TransactionNumber == selectedAircrew.TransactionNumber)) continue;

                        originalList.Add(new AircrewEntity
                        {
                            TransactionNumber = selectedAircrew.TransactionNumber,
                            Name = selectedAircrew.Name,
                            JobTitle = selectedAircrew.JobTitle,
                            TroopsType = selectedAircrew.TroopsType
                        });
                    }

                    AircrewMemberModel.SelectedAircrewEntityList = new ObservableCollection<AircrewEntity>(originalList);
                    AircrewMemberModel.AircrewEntityList = new ObservableCollection<AircrewEntity>(AircrewMemberModel.AircrewEntityList.Except(originalList, new CollectionEqualityCompare()));
                });
            }
        }

        public ICommand MoveRightCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (this.AircrewMemberModel.AircrewEntityList != null
                        && this.AircrewMemberModel.SelectedAircrewEntityList != null
                        && this.AircrewMemberModel.SelectedAircrewEntityList.Count > 0)
                    {
                        var selectedAircrews = AircrewMemberModel.SelectedAircrewEntityList.Where(a => a.IsChecked).ToList();
                        foreach (var aircrew in selectedAircrews)
                        {
                            if (!AircrewMemberModel.AircrewEntityList.Any(a => a.TransactionNumber == aircrew.TransactionNumber))
                            {
                                AircrewMemberModel.AircrewEntityList.Add(aircrew);
                            }
                        }

                        AircrewMemberModel.SelectedAircrewEntityList = new ObservableCollection<AircrewEntity>(AircrewMemberModel.SelectedAircrewEntityList.Except(selectedAircrews, new CollectionEqualityCompare()).ToList());
                    }
                });
            }
        }

        public ICommand ConfirmCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (AircrewMemberModel.SelectedAircrewEntityList == null
                        || AircrewMemberModel.SelectedAircrewEntityList.Count == 0)
                    {
                        this.ShowMessage(RecuperationInformationResource.Msg_NoAircrew);
                        return;
                    }

                    this.Tag = AircrewMemberModel.SelectedAircrewEntityList.ToList();
                    this.Close();
                });
            }
        }

        public new ICommand CloseCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) => 
                {
                    this.Tag = AircrewMemberModel.SelectedAircrewEntityList.ToList();
                    this.Close();
                });
            }
        }

        #endregion

        #region Method

        private async void InitAircrew(List<RecuperationMemberEntity> recuperationMemberList = null)
        {
            var response = await aircrewFacade.GetAircrewList(string.Empty, DateTime.MinValue, DateTime.MaxValue, 0, 2000);

            if (recuperationMemberList != null)
            {
                this.AircrewMemberModel.SelectedAircrewEntityList = new ObservableCollection<AircrewEntity>(recuperationMemberList.Select(r =>
                {
                    var aircrew = response.AircrewList.FirstOrDefault(a => a.TransactionNumber == r.AircrewID);
                    return new AircrewEntity
                    {
                        TransactionNumber = r.AircrewID.GetValueOrDefault(0),
                        Name = aircrew != null ? aircrew.Name : string.Empty,
                        JobTitle = aircrew != null ? aircrew.JobTitle : string.Empty,
                        TroopsType = aircrew != null ? aircrew.TroopsType : string.Empty
                    };
                }).ToList());

                this.AircrewMemberModel.AircrewEntityList = new ObservableCollection<AircrewEntity>(response.AircrewList.Except(AircrewMemberModel.SelectedAircrewEntityList, new CollectionEqualityCompare()).ToList());
            }
            else
            {
                this.AircrewMemberModel.AircrewEntityList = new ObservableCollection<AircrewEntity>(response.AircrewList);
            }
        }

        private void ProcessAllSelect(ObservableCollection<AircrewEntity> aircrewEntityList)
        {
            if (aircrewEntityList == null || aircrewEntityList.Count == 0) return;

            foreach (var aircrew in aircrewEntityList)
            {
                aircrew.IsChecked = true;
            }
        }

        private void ProcessInvertSelect(ObservableCollection<AircrewEntity> aircrewEntityList)
        {
            if (aircrewEntityList == null || aircrewEntityList.Count == 0) return;

            foreach (var aircrew in aircrewEntityList)
            {
                aircrew.IsChecked = !aircrew.IsChecked;
            }
        }

        #endregion
    }

    public class CollectionEqualityCompare : IEqualityComparer<AircrewEntity>
    {
        public bool Equals(AircrewEntity t1, AircrewEntity t2)
        {
            return t1.TransactionNumber == t2.TransactionNumber;
        }

        public int GetHashCode(AircrewEntity t1)
        {
            return t1.TransactionNumber.GetHashCode();
        }
    }
}
