using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Model;
using HealthyInformation.Repository.ConfigDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.SystemManage
{
    public class ConfigDictionaryService : IConfigDictionaryService
    {
        IFlyerTypeRepository flyerTypeRepository;
        HealthyInformationEntities dbContext;
        public ConfigDictionaryService()
        {
            this.dbContext = new HealthyInformationEntities();
            this.flyerTypeRepository = new FlyerTypeRepository(this.dbContext);
        }

        public List<FlyerType> GetFlyerType()
        {
            return this.flyerTypeRepository.GetFlyerType();
        }

        public int CreateFlyerType(FlyerTypeRequest flyerTypeRequest)
        {
            var flyerType = new FlyerType
            {
                TypeName = flyerTypeRequest.TypeName,
                InDate = DateTime.Now,
                InUser = flyerTypeRequest.ActionUserID,
                LastEditDate = DateTime.Now,
                LastEditUser = flyerTypeRequest.ActionUserID
            };
            this.flyerTypeRepository.Create(flyerType);
            return this.dbContext.SaveChanges();
        }

        public int UpdateFlyerType(FlyerTypeRequest flyerTypeRequest)
        {
            var flyerType = flyerTypeRepository.GetFlyerTypeByKey(flyerTypeRequest.TransactionNumber);
            if (flyerType != null)
            {
                flyerType.TypeName = flyerTypeRequest.TypeName;
                flyerType.LastEditDate = DateTime.Now;
                flyerType.LastEditUser = flyerTypeRequest.ActionUserID;
                this.flyerTypeRepository.Update(flyerType);
                return this.dbContext.SaveChanges();
            }

            return -1;
        }

        public int DeleteFlyerType(string transactionNumber)
        {
            int tranID = 0;
            int.TryParse(transactionNumber,out tranID);
            var flyerType = flyerTypeRepository.GetFlyerTypeByKey(tranID);
            if (flyerType != null)
            {
                this.flyerTypeRepository.Remove(flyerType);
                return this.dbContext.SaveChanges();
            }

            return -1;
        }
    }
}
