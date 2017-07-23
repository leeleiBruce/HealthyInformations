using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Model;
using HealthyInformation.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.SystemManage.RecuperationInfor
{
    public class RecuperationAccompanyService : BaseService<RecuperationAccompany>, IRecuperationAccompanyService
    {
        IRecuperationInformationRepository repository;
        public RecuperationAccompanyService()
        {
            repository = new RecuperationInformationRepository(dbContext);
        }

        public BaseResponse CreateRecuperationAccompany(RecuperationInformationRequest request)
        {
            if (request.RecuperationAccompanyList != null && request.RecuperationAccompanyList.Count > 0)
            {
                foreach (var recuperationAccompany in request.RecuperationAccompanyList)
                {
                    recuperationAccompany.RecuperationInformationID = request.TransactionNumber;
                    this.Create(recuperationAccompany);
                }
            }
            return this.BuildSuccessResponse();
        }

        public void RemoveRecuperationAccompany(int key)
        {
            var members = repository.GetRecuperationAccompanies(key);
            foreach (var member in members)
            {
                this.RemoveWithoutCommit(member);
            }
            this.unitOfWork.Commit();
        }
           
    }
}
