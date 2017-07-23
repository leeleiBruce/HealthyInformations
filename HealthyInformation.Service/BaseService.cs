using HealthyInformation.Entity;
using HealthyInformation.Infrastructrue;
using HealthyInformation.Model;
using HealthyInformation.Repository;
using System;

namespace HealthyInformation.Service
{
    public class BaseService<TEntity> : IService<TEntity>
        where TEntity : class, new()
    {
        protected HealthyInformationEntities dbContext;
        IRepository<TEntity> repository;
        protected IUnitOfWork unitOfWork;

        public BaseService()
        {
            this.dbContext = new HealthyInformationEntities();
            this.unitOfWork = new UnitOfWork(dbContext);
            this.repository = new BaseRepository<TEntity>(dbContext);
        }

        public BaseResponse Create(TEntity entity)
        {
            this.repository.Create(entity);
            this.unitOfWork.Commit();
            return this.BuildSuccessResponse();
        }

        public BaseResponse Remove(TEntity entity)
        {
            this.repository.Remove(entity);
            this.unitOfWork.Commit();
            return this.BuildSuccessResponse();
        }

        public void RemoveWithoutCommit(TEntity entity)
        {
            this.repository.Remove(entity);
        }

        public BaseResponse Update(TEntity entity)
        {
            this.repository.Update(entity);
            this.unitOfWork.Commit();
            return this.BuildSuccessResponse();
        }

        protected BaseResponse BuildErrorResponse(string code)
        {
            return new BaseResponse { IsSucess = false, ResponseCode = code, ErrorMessage = MessageResourceBuilder.GetMessageResource(code) };
        }

        protected BaseResponse BuildExceptionResponse(Exception ex)
        {
            return new BaseResponse { IsSucess = false, ErrorMessage = ex.Message };
        }

        protected BaseResponse BuildSuccessResponse()
        {
            return new BaseResponse { IsSucess = true};
        }
    }
}
