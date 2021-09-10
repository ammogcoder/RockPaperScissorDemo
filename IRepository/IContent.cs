using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
    public interface IContent
    {
        Task<Content> GetContentDetails(Guid ContentId);
        Task<Content> GetContentDetailsForDownload(Guid ContentId);
        Task<string> InsertContent(Content data);
        Task<int> UpdateContent(Content data);
        Task<int> DeleteContent(Guid ContentId);
        Task<ContentPath> getContentPath(Guid ContentId);
        Task<int> InsertMyLibrary(MyLibrary data);
        Task<List<LibraryResultModel>> GetContentFromLibrary(LibraryModel data);
    }

    public interface IContentSection
    {
        Task<int> InsertContentSection(ContentSection data);
        Task<int> UpdateContentSection(ContentSection data);
        Task<int> DeleteContentSection(Guid ContentSectionId);
        Task<object> GetAllContentBySectionId(Guid SessionId);
        Task<object> GetAllCourseInformation(Guid SessionId);
        Task<object> GetAllCommemtRating(Guid ProfileId);
        Task<object> GetAllContentSectionForReview(Guid SessionId);
        Task<int> PublishReviewContent(Guid SessionId);
        Task<int> RevokeReviewContent(Guid SessionId, ContentReview data);
    }

    public interface IContentSectionProfile
    {
        Task<int> InsertContentSectionPro(ContentSectionProfile data);
        Task<int> UpdateContentSectionPro(ContentSectionProfile data);
        Task<int> DeleteContentSectionPro(Guid ContentSectionProfileId);
    }

    public interface IContentSession
    {
        Task<int> InsertContentSession(ContentSession data);
        Task<int> updateSessionPublish(Guid SessionId);
        Task<List<object>> GetContentSessionDetails(Guid SessionID);
        Task<int> UpdateContentSession(ContentSession data);
        Task<int> UpdateTabsContentSession(ContentSession data, int action);
        Task<int> DeleteContentSession(Guid ContentSessionId);
        Task<int> AddContentSessionTag(ContentSessionTag data);
        Task<int> DeleteAllTagsAvailable(Guid SessionId);
        Task<object> GetAllPathInterest(int pathId);
        Task<List<LibraryResultModel>> GetAllContentSession(LibraryModel data);
        Task<List<LibraryResultModel>> GetAllCourse(int action, string name);
        Task<List<LibraryResultModel>> GetAllCourseByPathId(string name, int PathId);
        Task<object> GetAllContentSessionByPath(LibraryModel data);
        Task<object> GetAllSessionForEdit(Guid ContentSessionId);
        Task<object> GetAllSessionForStudentInSchool(GetAllSessionForStudentInSchool data);
        Task<List<LibraryResultModel>> GetAllContentSessionByProfileId(Guid ProfileId);
        Task<List<LibraryResultModel>> GetContentForSchool(SchoolLibraryModel data);
        Task<List<object>> GetAllContentSessionByCategoryId(Guid ContentCategoryId);
        Task<int> AddBill(ContentBills data);
        Task<int> AddAreaOfInterest(string subject, int Path);
        Task<List<ContentSession>> GetAllSessionForReview();
        Task<List<ContentSession>> GetAllSessionForSchoolToReview(Guid SchoolId);

    }

    public interface IContentSessionComment
    {
        Task<int> InsertContentSessionComm(ContentSessionComment data);
        Task<List<object>> GetAllComment(Guid SessionId);
        Task<int> UpdateContentSessionComm(ContentSessionComment data);
        Task<int> DeleteContentSessionComm(Guid ContentSessionCommentId);
    }

    public interface IContentSessionRating
    {
        Task<int> InsertContentSessionRating(ContentSessionRating data);
        Task<int> UpdateContentSessionRating(ContentSessionRating data);
        Task<int> DeleteContentSessionRating(Guid ContentSessionRatingId);
    }
}
