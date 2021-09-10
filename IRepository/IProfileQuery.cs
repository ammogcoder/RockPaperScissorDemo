using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbModel;

namespace LMS_InterfaceProject.IRepository
{
    public interface IProfileQuery
    {
        Task<int> InsertProfile(Profile data); 
        Task<int> UpdateProfile(Profile data);
        Task<int> ActivateProfile(Guid profileId, bool IsActive);

        Task<int> DeleteProfile(Guid profileId);
        Task<IsVerified> IsVerified(Guid profileId);
        Task<IsVerifiedAcc> IsVerifiedAcc(Guid profileId);
        Task<int> UpdateVerified(IsVerified data);
        Task<int> AddVerified(IsVerified data);
        Task<object> GetProfile(Guid profileId);
        Task<object> GetTeacherInfoForAdmin(Guid profileId);
        Task<int> UpdateUserProfile(UserProfile data);
        Task<int> ChangePassword(ChangePassword data);
        Task<int> AddLearningPath(LearningPath data);
        Task<int> UpdateAreaOfInterest(AreaOfInterestModelDetails data);
        Task<SubAccountModel> GetSubAccount(Guid profileId);
        Task<SubAccountModel> AddNewSubAccount(SubAccountModel data);
        Task<LearningPathModel> GetPathByProfileId(Guid? profileId);
        Task<object> GetAreaOfInterestByPathId(int pathId);
        Task<LearningPathModel> GetPathByProfileIdForAOI(string profileId); 
        Task<SubscribesOverview> GetInstrutorMetrics(Guid profileId);
        Task<IsVerified> CheckIsVerified(string email);
        Task<int> AddNotification(Notification data);
        Task<object> GetAllNotification(Guid ProfileId, int PathId);
        Task<object> GetNotification(Guid ProfileId, int PathId);
        Task<int> UpdateNotification(Guid NotificationId);
    }
}
