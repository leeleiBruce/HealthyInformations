using HealthyInformation.ClientEntity.SystemManage.Response;
using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Model;
using HealthyInformation.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.SystemManage
{
    public class SanatoriumManageService : BaseService<Sanatorium>, ISanatoriumManageService
    {
        ISanatoriumRepository sanatoriumRepository;
        public SanatoriumManageService()
        {
            sanatoriumRepository = new SanatoriumRepository(this.dbContext);
        }

        public SanatoriumResponse GetSanatoriumList(string name, int pageIndex, int pageSize)
        {
            var result = sanatoriumRepository.GetSanatoriumList(name, pageIndex, pageSize);
            return new SanatoriumResponse
            {
                SanatoriumList = result.ToList(),
                TotalCount = result.TotalCount
            };
        }

        public BaseResponse CreateSanatorium(SanatoriumRequest request)
        {
            var sanatorium = new Sanatorium
            {
                Name = request.Name,
                Address = request.Address,
                ContactPhone = request.ContactPhone,
                RecommendTravelMode = request.RecommendTravelMode,
                InUser = request.ActionUserID,
                LastEditUser = request.ActionUserID,
                InDate = DateTime.Now,
                LastEditDate = DateTime.Now
            };

            this.Create(sanatorium);
            this.unitOfWork.Commit();
            return this.BuildSuccessResponse();
        }

        public BaseResponse UpdateSanatorium(SanatoriumRequest request)
        {
            var sanatorium = this.sanatoriumRepository.GetSanatoriumByKey(request.TransactionNumber);
            if (sanatorium == null)
            {
                return this.BuildErrorResponse("002"); //does not exist
            }

            sanatorium.Name = request.Name;
            sanatorium.Address = request.Address;
            sanatorium.ContactPhone = request.ContactPhone;
            sanatorium.RecommendTravelMode = request.RecommendTravelMode;
            sanatorium.LastEditDate = DateTime.Now;
            sanatorium.LastEditUser = request.ActionUserID;

            this.Update(sanatorium);
            this.unitOfWork.Commit();

            return this.BuildSuccessResponse();
        }

        public BaseResponse RemoveSanatorium(int transactionNumber)
        {
            var sanatorium = this.sanatoriumRepository.GetSanatoriumByKey(transactionNumber);
            if (sanatorium != null)
            {
                this.sanatoriumRepository.Remove(sanatorium);
                this.unitOfWork.Commit();
            }

            return this.BuildSuccessResponse();
        }

        public Sanatorium GetSanatoriumByKey(int transactionNumber)
        {
            return sanatoriumRepository.GetSanatoriumByKey(transactionNumber);   
        }
    }
}
