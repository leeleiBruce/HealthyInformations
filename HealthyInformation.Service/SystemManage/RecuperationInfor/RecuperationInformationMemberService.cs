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
    public class RecuperationInformationMemberService : BaseService<RecuperationMember>, IRecuperationInformationMemberService
    {
        IRecuperationInformationRepository repository;
        public RecuperationInformationMemberService()
        {
            repository = new RecuperationInformationRepository(dbContext);
        }

        public BaseResponse CreateRecuperationMember(RecuperationInformationRequest request)
        {
            if (request.RecuperationMemberList != null && request.RecuperationMemberList.Count > 0)
            {
                foreach (var recuperationMember in request.RecuperationMemberList)
                {
                    recuperationMember.RecuperationInformationID = request.TransactionNumber;
                    this.Create(recuperationMember);
                }
            }
            return this.BuildSuccessResponse();
        }

        public void RemoveRecuperationMember(int key)
        {
            var members = repository.GetRecuperationMembers(key);
            foreach (var member in members)
            {
                this.RemoveWithoutCommit(member);
            }
            this.unitOfWork.Commit();
        }
    }
}
