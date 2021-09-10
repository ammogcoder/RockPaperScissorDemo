using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
    public interface ISchoolQuery
    {
        Task<object> InsertSchool(Guid? SchoolId, Guid? ProfileId, string SchoolName, bool? isActive,
            string Address, string City, Guid? StateId, string Website, string Telephone);
        Task<int> UpdateSchool(School data);
        Task<int> DeleteSchool(Guid schoolId);
        Task<object> GetValidContentForSchool(Guid schoolId, Guid ProfileId);
        Task<int> StudentAccountInitialized(SchoolStudentAccount data);
        Task<object> GetSchoolByCode(string schoolCode);
        Task<object> GetSchooldetails(Guid ProfileId);
        Task<object> GetStudentForSchool(Guid SchoolId, string PathId);
        Task<School> GetSchoolInformation(Guid SchoolId);
        Task<List<StudentAssignmentSubmission>> GetDataForSchool(Guid SchoolId);
        Task<List<StudentAssignmentSubmission>> SendBroadcastToMultiple(Guid SchoolId);
        Task<List<StudentAssignmentSubmission>> GetStudentEmail(string Email);
        Task<object> GetDepartment(Guid SchoolId);
        Task<object> GetDepartmentCourseForSchool(Guid SchoolId);
        Task<object> GetDepartmentCourseByDepartmentIDForSchool(Guid DepartmentId);
        Task<int> CreateCourseSubject(CourseSubject data);
        Task<object> GetDepartmentCourseForSchoolToApprove(Guid SchoolId);
        Task<int> ModifyCourseSubject(Guid CourseSubjectId, bool action);
        Task<object> GetDapartmentChoice(Guid SchoolId);
        Task<R> ModifyDapperGenericAsync<R>(string conn, DynamicParameters dynamicParameters);
        Task<R> RetrieveDapperGenericAsync<R>(string conn, DynamicParameters dynamicParameters);
    }
}
