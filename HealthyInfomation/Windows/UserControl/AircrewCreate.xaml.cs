using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.ClientEntity.SystemManage.Request;
using HealthyInformation.ClientEntity.SystemManage.ViewModel;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.AuthorUser;
using HealthyInformation.FrameWork.Enums;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using HealthyInformation.FrameWork.ActionTrigger;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
using HealthyInformation.FrameWork.Extension;
using System.Collections.Generic;
using System.Linq;

namespace HealthyInfomation.Windows.UserControl
{
    /// <summary>
    /// UserManageCreate.xaml 的交互逻辑
    /// </summary>
    public partial class AircrewCreate : WindowBase
    {
        bool dialogResult = false;
        AircrewFacade aircrewFacade;
        List<FlightRecordEntity> flightRecordList;

        public AircrewCreate()
        {
            InitializeComponent();
            this.aircrewFacade = new AircrewFacade(this);
            this.DataContext = this;
            this.InitData();
            this.InitTriggerAction();
        }

        #region ViewModel
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

        #region Command

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.CreateAircrew();
                });
            }
        }

        public ICommand FlightRecorderCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    var flightRecord = new FlyRecord();
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

        #endregion

        #region method

        private void CreatePhoto()
        {
            var openDialog = new OpenFileDialog
            {
                Filter = "All Image Files|*.bmp;*.gif;*.jpeg;*.jpg;*.png;*.tif",
                FilterIndex = 0
            };

            if (openDialog.ShowDialog().GetValueOrDefault(false))
            {
                this.Img_Photo.Source = new BitmapImage(new Uri(openDialog.FileName));
            }
        }

        private void InitData()
        {
            this.AircrewModel = new AircrewModel();
            this.AircrewModel.Sex = ((int)SexEnums.Male).ToString();
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

        private async void CreateAircrew()
        {
            if (this.AircrewModel.HasValidationError()) return;

            var request = new AircrewRequest
            {
                Aircrew = AutoMapper.Mapper.Map<AircrewModel, AircrewEntity>(this.AircrewModel)
            };

            request.Aircrew.InUser = CPApplication.CurrentUser.UserName;
            request.Aircrew.LastEditUser = CPApplication.CurrentUser.UserName;
            request.Aircrew.InDate = DateTime.Now;
            request.Aircrew.LastEditDate = DateTime.Now;
            request.FlightRecordList = flightRecordList;

            try
            {
                MemoryStream m = new MemoryStream();
                BitmapSource oldmap = (BitmapSource)Img_Photo.Source;
                Bitmap bp = this.ToBitmap(oldmap);
                bp.Save(m, ImageFormat.Jpeg);
                byte[] b = m.GetBuffer();
                request.Aircrew.Photo = Convert.ToBase64String(b);
            }
            catch { }

            var response = await this.aircrewFacade.CreateAircrew(request);
            if (response.IsSucess)
            {
                this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
                this.dialogResult = true;
            }

            this.InitData();
        }

        public Bitmap ToBitmap(BitmapSource src)
        {
            if (src == null)
            {
                return null;
            }
            int width = src.PixelWidth;
            int height = src.PixelHeight;
            Bitmap result = new Bitmap(width, height);
            BitmapData bits = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int size = width * height * 4;
            byte[] argb = new byte[size];
            src.CopyPixels(argb, bits.Stride, 0);
            Marshal.Copy(argb, 0, bits.Scan0, size);
            return result;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.DialogResult = dialogResult;
        }

        #endregion
    }
}
