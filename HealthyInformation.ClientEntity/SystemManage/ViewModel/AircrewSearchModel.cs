using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.ViewModel
{
    public class AircrewSearchModel : ModelBase
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        private DateTime? startDate;
        public DateTime? StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
                RaisePropertyChanged("StartDate");
            }
        }

        private DateTime? endDate;
        public DateTime? EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
                RaisePropertyChanged("EndDate");
            }
        }

        private ObservableCollection<AircrewEntity> aircrewList;
        public ObservableCollection<AircrewEntity> AircrewList
        {
            get
            {
                return aircrewList;
            }
            set
            {
                aircrewList = value;
                RaisePropertyChanged("AircrewList");
            }
        }

        private AircrewEntity selectedAircrew;
        public AircrewEntity SelectedAircrew
        {
            get
            {
                return selectedAircrew;
            }
            set
            {
                selectedAircrew = value;
                RaisePropertyChanged("SelectedAircrew");
            }
        }

        private int totalCount;
        public int TotalCount
        {
            get
            {
                return totalCount;
            }
            set
            {
                totalCount = value;
                RaisePropertyChanged("TotalCount");
            }
        }

        private int pageIndex;
        public int PageIndex
        {
            get
            {
                return pageIndex;
            }
            set
            {
                pageIndex = value;
                RaisePropertyChanged("PageIndex");
            }
        }

        private int currentPageIndex;
        public int CurrentPageIndex
        {
            get
            {
                return currentPageIndex;
            }
            set
            {
                currentPageIndex = value;
                RaisePropertyChanged("CurrentPageIndex");
            }
        }

        private bool hasPreviousPage;
        public bool HasPreviousPage
        {
            get
            {
                return hasPreviousPage;
            }
            set
            {
                hasPreviousPage = value;
                RaisePropertyChanged("HasPreviousPage");
            }
        }

        private bool hasNextPage;
        public bool HasNextPage
        {
            get
            {
                return hasNextPage;
            }
            set
            {
                hasNextPage = value;
                RaisePropertyChanged("HasNextPage");
            }
        }
    }
}
