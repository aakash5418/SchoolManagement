using SchoolManagementStore;
using System.Collections;

namespace SchoolManagementService
{
    public interface IAcademicService
    {
        List<AcademicServiceInfo> GetAcademic();
        AcademicServiceInfo GetAcademicId(long AcademicId);
        ArrayList AddAcademic(AcademicServiceInfo academic);
        ArrayList UpdateAcademic(AcademicServiceInfo academic);
        string DeleteAcademic(long AcademicId);
    }
    public class AcademicService : IAcademicService
    {
        private readonly IAcademicStore _academicStore;
        public AcademicService(IAcademicStore academicStore)
        {
            _academicStore = academicStore;
        }
        public List<AcademicServiceInfo> GetAcademic()
        {
            try
            {
                var academicStoreInfo = _academicStore.GetAcademic();
                if (academicStoreInfo == null)
                {
                    return null;
                }
                else
                {
                    var academicList = new List<AcademicServiceInfo>();
                    foreach (var academic in academicStoreInfo)
                    {
                        academicList.Add(new AcademicServiceInfo
                        {
                            AcademicId = academic.AcademicId,
                            AcademicStartYear = academic.AcademicStartYear,
                            AcademicEndYear = academic.AcademicEndYear,
                            CreatedDate = academic.CreatedDate,
                            ModifiedDate = academic.ModifiedDate,
                        });
                    }
                    return academicList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public AcademicServiceInfo GetAcademicId(long AcademicId)
        {
            try
            {
                var academicStoreInfo = _academicStore.GetAcademicId(AcademicId);
                if (academicStoreInfo == null)
                {
                    return null;
                }
                else
                {
                    return new AcademicServiceInfo
                    {
                        AcademicId = academicStoreInfo.AcademicId,
                        AcademicStartYear = academicStoreInfo.AcademicStartYear,
                        AcademicEndYear = academicStoreInfo.AcademicEndYear,
                        CreatedDate = academicStoreInfo.CreatedDate,
                        ModifiedDate = academicStoreInfo.ModifiedDate,
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ArrayList AddAcademic(AcademicServiceInfo academic)
        {
            try
            {
                var validAcademic = ValidateAcademic(academic);
                if (validAcademic.Count == 0)
                {
                    var validExists = IsAcademicExists(academic);
                    if (validExists.Count == 0)
                    {
                        var academicStore = new AcademicStoreInfo();
                        academicStore.AcademicId = academic.AcademicId;
                        academicStore.AcademicStartYear = academic.AcademicStartYear;
                        academicStore.AcademicEndYear = academic.AcademicEndYear;
                        _academicStore.AddAcademic(academicStore);
                    }
                    else
                    {
                        return validExists;
                    }
                }
                else
                {
                    return validAcademic;
                }
                return validAcademic;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ArrayList UpdateAcademic(AcademicServiceInfo academic)
        {
            try
            {
                var validAcademic = ValidateAcademic(academic);
                if (validAcademic.Count == 0)
                {
                    var validExists = IsAcademicExists(academic);
                    if (validExists.Count == 0)
                    {
                        var academicStore = new AcademicStoreInfo();
                        academicStore.AcademicId = academic.AcademicId;
                        academicStore.AcademicStartYear = academic.AcademicStartYear;
                        academicStore.AcademicEndYear = academic.AcademicEndYear;
                        _academicStore.UpdateAcademic(academicStore);
                    }
                    else
                    {
                        return validExists;
                    }
                }
                else
                {
                    return validAcademic;
                }
                return validAcademic;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteAcademic(long AcademicId)
        {
            try
            {
                var academicList = _academicStore.DeleteAcademic(AcademicId);
                return academicList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private ArrayList ValidateAcademic(AcademicServiceInfo academic)
        {
            ArrayList validAcademic = new ArrayList();

            if (academic.AcademicStartYear <= 0)
            {
                validAcademic.Add("AcademicStartYear Does Not Exists");
            }
            if (academic.AcademicEndYear <= 0)
            {
                validAcademic.Add("AcademicEndYear Does Not Exists");
            }
            return validAcademic;
        }
        private ArrayList IsAcademicExists(AcademicServiceInfo academic)
        {
            ArrayList AcademicExists = new ArrayList();
            var validExists = _academicStore.GetAcademic();
            var validStartYear = validExists.Any(a => a.AcademicStartYear == academic.AcademicStartYear);
            if (validStartYear)
            {
                AcademicExists.Add("AcademicStartYear Already Exists");
                return AcademicExists;
            }
            var validEndYear = validExists.Any(a => a.AcademicEndYear == academic.AcademicEndYear);
            if (validEndYear)
            {
                AcademicExists.Add("AcademicEndYaer Already Exists");
                return AcademicExists;
            }
            return AcademicExists;
        }
    }
}
