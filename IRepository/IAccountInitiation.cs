using DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
    public interface IAccountInitiation
    {
        Task<int> InsertAccInitiation(AccountInitiationClass data);
        Task<int> UpdateAccInitiation(AccountInitiationClass data);
        Task<int> DeleteAccInitiation(Guid AccInitiationId);
        Task<int> ResetAccInitiation(Guid AccInitiationId);

        Task<List<Profile>> GetAllCreatedTeachers(GetTeacherClass data);
        Task<List<Profile>> GetAllAccountInitiated(Guid ProfileId);
        Task<List<Profile>> GetStudentInfoForAdmin(Guid ProfileId);

  }
}
