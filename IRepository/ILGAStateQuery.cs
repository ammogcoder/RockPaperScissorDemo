using DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
    public interface ILGAStateQuery
    {
        Task<List<GetState>> GetAllState();
        Task<List<LGAByState>> GetLGAByState(Guid stateId);
        Task<General> VerifyEmail(string Email,int pathId);
        Task<General> GetProfileId(string Email);
        Task<General> GetRolesByPathId(int pathId);
        Task<General> CheckOtherProfileExist(string Email, int pathId);
        Task<General>VerifyAccountInitiationEmail(string Email);
        Task<ForgotPassword> ForgotPassword(ForgotPassword data);
        Task<int> ResetPassword(ResetPassword data);
        Task<int> AssignRole(Guid RoleId, Guid ProfileId, bool isDefault);
        Task<LoggedInUser> UpdateRole(Guid RoleId, Guid ProfileId);
        Task<List<Role>> GetAllRole();
        Task<List<GetCategory>> GetAllCategory(Guid SchoolID);
        Task<GetCategory> GetCategory(string CategoryName);
        Task<General> UpdateIsFirstTimeLogin(Guid ProfileId);
    }
}
