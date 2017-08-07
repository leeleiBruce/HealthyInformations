using HealthyInfomation.Facade;
using HealthyInformation.ClientEntity.SystemManage.Response;
using HealthyInformation.FrameWork;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;

namespace HealthyInfomation.Windows
{
    /// <summary>
    /// RecuperationPrint.xaml 的交互逻辑
    /// </summary>
    public partial class RecuperationPrint : WindowBase
    {
        RecuperationInformationFacade facade;
        RecuperationInformationResponse response;
        public RecuperationPrint()
        {
            InitializeComponent();
            facade = new RecuperationInformationFacade(this);
        }

        public RecuperationPrint(int key) : this()
        {
            BuildReportData(key);
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            if (e.ReportPath == "RecuperationMember")
            {
                response.RecuperationMemberList = this.ProcessMemberList(response.RecuperationMemberList);
                e.DataSources.Add(new ReportDataSource("DataSet1", response.RecuperationMemberList));
            }
            else
            {
                response.RecuperationAccompanyList = this.ProcessMemberList(response.RecuperationAccompanyList);
                e.DataSources.Add(new ReportDataSource("DataSet2", response.RecuperationAccompanyList));
            }
        }

        private async void BuildReportData(int key)
        {
            response = await this.facade.GetRecuperationInformation(key);
            ReportViewer.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = new List<RecuperationInformationResponse> { response };
            ReportViewer.LocalReport.DataSources.Add(reportDataSource);
            ReportViewer.LocalReport.ReportEmbeddedResource = "HealthyInfomation.Report.Recuperation.rdlc";
            ReportViewer.ProcessingMode = ProcessingMode.Local;
            ReportViewer.RefreshReport();
        }

        private List<RecuperationMember> ProcessMemberList(List<RecuperationMember> list)
        {
            var recuperationMembers = new List<RecuperationMember>();
            if (list != null)
            {
                RecuperationMember member = new RecuperationMember();
                for (int i = 0; i < list.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        member.Name = list[i].Name;
                        member.PhoneNumber = list[i].PhoneNumber;
                    }
                    else
                    {
                        member.NameRepeat = list[i].Name;
                        member.PhoneNumberRepeat = list[i].PhoneNumber;
                        recuperationMembers.Add(member);
                        member = new RecuperationMember();
                    }

                    if (i == list.Count - 1 && list.Count % 2 != 0)
                    {
                        recuperationMembers.Add(member);
                    }
                }
            }

            return recuperationMembers;
        }

    }
}
