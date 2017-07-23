using HealthyInformation.Entity.SystemManage.Response;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.SystemManage
{
    public class RecuperationInformationRepository : BaseRepository<RecuperationInformation>, IRecuperationInformationRepository
    {
        public RecuperationInformationRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public List<UP_GetRecuperationPlan_Result1> GetRecuperationPlanList(int? sanatoriumID, DateTime? startDate, DateTime? endDate)
        {
            return (this._context as HealthyInformationEntities).UP_GetRecuperationPlan(sanatoriumID, startDate, endDate).ToList();
        }

        public RecuperationInformationResponse GetRecuperationInformation(int key)
        {
            var response = new RecuperationInformationResponse();
            var info = this._context.Set<RecuperationInformation>().FirstOrDefault(r => r.TransactionNumber == key);

            var sanatorium = this._context.Set<Sanatorium>().FirstOrDefault(s => s.TransactionNumber == info.SanatoriumID);
            var aircrewLeader = this._context.Set<Aircrew>().FirstOrDefault(a => a.TransactionNumber == info.LeaderAircrewID);
            var aviationMedicine = this._context.Set<AviationMedicine>().FirstOrDefault(a => a.TransactionNumber == info.AviationMedicineID);
            if (info != null)
            {
                if (sanatorium != null)
                {
                    response.SanatoriumName = sanatorium.Name;
                    response.SanatoriumAddress = sanatorium.Address;
                    response.RecommendTravelMode = sanatorium.RecommendTravelMode;
                }

                if (aircrewLeader != null)
                {
                    response.LeaderAircrew = aircrewLeader.Name;
                    response.LeaderContactTel = aircrewLeader.TroopsTel;
                }

                if (aviationMedicine != null)
                {
                    response.AviationMedicineName = aviationMedicine.Name;
                    response.AviationMedicineTel = aviationMedicine.ContactPhone;
                }

                if (info.RecuperationAccompany != null)
                {
                    response.RecuperationAccompanyList = info.RecuperationAccompany.Select(r =>
                    {
                        return new Entity.SystemManage.Response.RecuperationMemberSimple
                        {
                            Name = r.Name,
                            PhoneNumber = r.ContactPhone
                        };
                    }).ToList();
                }

                if (info.RecuperationMember != null)
                {
                    response.RecuperationMemberList = info.RecuperationMember.Select(r =>
                    {
                        var aircrew = this._context.Set<Aircrew>().FirstOrDefault(a => a.TransactionNumber == r.AircrewID);
                        return new Entity.SystemManage.Response.RecuperationMemberSimple
                        {
                            Name = aircrew.Name,
                            PhoneNumber = aircrew.TroopsTel
                        };
                    }).ToList();


                }
            }
            return response;
        }

        public RecuperationInformation GetRecuperationPlanByKey(int key)
        {
            return this._context.Set<RecuperationInformation>().FirstOrDefault(r => r.TransactionNumber == key);
        }

        public RecuperationDetailResponse GetRecuperationDetail(int key)
        {
            var response = new RecuperationDetailResponse();
            var result = this._context.Set<RecuperationInformation>().FirstOrDefault(r => r.TransactionNumber == key);
            response.TransactionNumber = result.TransactionNumber;
            response.AviationMedicineID = result.AviationMedicineID;
            response.HospitalEnterDate = result.HospitalEnterDate;
            response.HospitalLeaveDate = result.HospitalLeaveDate;
            response.LeaderAircrewID = result.LeaderAircrewID;
            response.SanatoriumID = result.SanatoriumID;
            response.RecuperationAccompanyEntitys = result.RecuperationAccompany.Select(r =>
            {
                return new RecuperationAccompanyEntity
                {
                    TransactionNumber = r.TransactionNumber,
                    ContactPhone = r.ContactPhone,
                    Name = r.Name,
                    RecuperationInformationID = r.RecuperationInformationID
                };
            }).ToList();


            response.RecuperationMembers = result.RecuperationMember.Select(r =>
            {
                return new RecuperationMemberEntity
                {
                    RecuperationInformationID = r.RecuperationInformationID,
                    TransactionNumber = r.TransactionNumber,
                    AircrewID = r.AircrewID
                };
            }).ToList();
            return response;
        }

        public List<RecuperationMember> GetRecuperationMembers(int key)
        {
            return this._context.Set<RecuperationMember>().Where(r => r.RecuperationInformationID == key).ToList();
        }

        public List<RecuperationAccompany> GetRecuperationAccompanies(int key)
        {
            return this._context.Set<RecuperationAccompany>().Where(r => r.RecuperationInformationID == key).ToList();
        }
    }
}
