using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.ClientEntity.SystemManage.Request;
using HealthyInformation.ClientEntity.SystemManage.ViewModel;
using HealthyInformation.FrameWork;
using System;
using System.Windows;
using System.Windows.Input;
using HealthyInformation.FrameWork.ActionTrigger;
using HealthyInformation.FrameWork.Enums;
using Microsoft.Win32;
using System.IO;
using HealthyInformation.FrameWork.AuthorUser;
using System.Windows.Media.Imaging;
using System.Drawing;
using HealthyInformation.FrameWork.Extension;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyInfomation.Windows.UserControl
{
    /// <summary>
    /// UserManageUpdate.xaml 的交互逻辑
    /// </summary>
    public partial class AircrewUpdate : WindowBase
    {
        AircrewFacade facade;
        AircrewEntity aircrewEntity;
        List<FlightRecordEntity> flightRecordList;

        public AircrewUpdate()
        {
            InitializeComponent();
        }

        public AircrewUpdate(AircrewEntity aircrewEntity)
            : this()
        {
            this.facade = new AircrewFacade(this);
            this.aircrewEntity = aircrewEntity;
            this.DataContext = this;
            this.InitData();
            this.InitTriggerAction();
        }

        #region Command

        public ICommand EditCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.IsSaveEnabled = true;
                    this.IsEditEnabled = false;
                });
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.UpdateAircrew();
                });
            }
        }

        public ICommand PhotoCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.CreatePhoto();
                });
            }
        }

        public ICommand FlightRecordCommand
        {
            get
            {
                return CommandFactory.CreateCommand(async(obj) =>
                {
                    await this.InitFlightRecordList();
                    var flightRecord = new FlyRecord(this.flightRecordList);
                    flightRecord.ShowDialog();
                    if (flightRecord.FlightRecordList != null
                        && flightRecord.FlightRecordList.Count > 0)
                    {
                        flightRecordList = flightRecord.FlightRecordList.ToList();
                    }
                    else
                    {
                        flightRecordList = null;
                    }
                });
            }
        }

        #endregion

        #region ViewModel

        private bool isEditEnabled;
        public bool IsEditEnabled
        {
            get
            {
                return isEditEnabled;
            }
            set
            {
                isEditEnabled = value;
                RaisePropertyChanged("IsEditEnabled");
            }
        }

        private bool isSaveEnabled;
        public bool IsSaveEnabled
        {
            get
            {
                return isSaveEnabled;
            }
            set
            {
                isSaveEnabled = value;
                RaisePropertyChanged("IsSaveEnabled");
            }
        }

        private AircrewModel aircrewModel;
        public AircrewModel AircrewModel
        {
            get
            {
                return aircrewModel;
            }
            set
            {
                aircrewModel = value;
                RaisePropertyChanged("AircrewModel");
            }
        }

        private bool isOpen;
        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
            set
            {
                isOpen = value;
                RaisePropertyChanged("IsOpen");
            }
        }

        #endregion

        #region Method

        private void InitData()
        {
            this.IsEditEnabled = true;
            this.IsSaveEnabled = false;
            this.AircrewModel = AutoMapper.Mapper.Map<AircrewEntity, AircrewModel>(aircrewEntity);
            if (!string.IsNullOrEmpty(AircrewModel.Photo))
            {
                byte[] bt = Convert.FromBase64String(AircrewModel.Photo);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(bt);
                Bitmap bitmap = new Bitmap(stream);
                Img_Photo.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
        }

        private async Task InitFlightRecordList()
        {
            var flightRecords = await facade.GetFlightRecord(aircrewEntity.TransactionNumber);
            this.flightRecordList = flightRecords;
        }

        private void InitTriggerAction()
        {
            this.Img_Photo.AttchEventTriggerAction(new BaseTrigger<DependencyObject, AircrewCreate>((obj) =>
            {
                this.IsOpen = true;
            }), EventEnums.MouseEnter.ToString());

            this.Pop_Photo.AttchEventTriggerAction(new BaseTrigger<DependencyObject, AircrewCreate>((obj) =>
            {
                this.IsOpen = false;
            }), EventEnums.MouseLeave.ToString());
        }

        private async void UpdateAircrew()
        {
            if (this.AircrewModel.HasValidationError()) return;

            var updateAircrewEntity = AutoMapper.Mapper.Map<AircrewModel, AircrewEntity>(this.AircrewModel);
            updateAircrewEntity.LastEditDate = DateTime.Now;
            var request = new AircrewRequest { Aircrew = updateAircrewEntity };
            request.FlightRecordList = this.flightRecordList;
            var response = await this.facade.UpdateAircrew(request);
            if (response.IsSucess)
            {
                this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
                this.DialogResult = true;
            }
        }

        private async void CreatePhoto()
        {
            var openDialog = new OpenFileDialog
            {
                Filter = "All Image Files|*.bmp;*.gif;*.jpeg;*.jpg;*.png;*.tif",
                FilterIndex = 0
            };

            if (openDialog.ShowDialog().GetValueOrDefault(false))
            {
                string filePath = openDialog.FileName;
                try
                {
                    MemoryStream m = new MemoryStream();
                    Bitmap bp = new Bitmap(filePath);
                    bp.Save(m, bp.RawFormat);
                    byte[] b = m.GetBuffer();
                    string base64string = Convert.ToBase64String(b);

                    var request = new AircrewPhotoRequest
                    {
                        TransactionNumber = this.AircrewModel.TransactionNumber,
                        ActionUserID = CPApplication.CurrentUser.UserName,
                        PhotoBinary = base64string
                    };

                    await this.facade.UpdateAircrewPhoto(request);
                    this.ShowMessage(CommonMsgResource.Msg_SetSucess);
                }
                catch
                {
                    this.ShowMessage(CommonMsgResource.Msg_FileException);
                }
            }
        }

        #endregion
    }
}
