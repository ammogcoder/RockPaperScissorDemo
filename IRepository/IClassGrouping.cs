using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
    public interface IClassGrouping
    {
        Task<int> InsertClassGroup(ClassGroup data);
        Task<int> UpdateClassGroup(ClassGroup data);
        Task<int> DeleteClassGroup(Guid ClassGroupId);
        Task<ClassGroupStudent> GetUserByProfileId(string Email);
        Task<List<ClassGroupStudent>> GetAllClassGroupId(Guid? ClassGroupId);
        Task<List<object>> AssignStudentToClassGroup(Guid ProfileId);
        Task<List<ClassGroup>> GetAllClassGroup(Guid ProfileId);
        Task<List<ProfileCourseSubject>> GetAllCourseSubject(Guid CourseSubjectID);
    }

    public interface IClassGroupingStudent
    {
        Task<int> InsertClassGroupStud(ClassGroupStudent data);
        Task<int> UpdateClassGroupStud(ClassGroupStudent data);
        Task<int> DeleteClassGroupStud(Guid ClassGroupStudentId);
        Task<List<AssignClassGroupStudent>> AssignStudentToClassGroup(Guid SchoolId);
        Task<List<AssignClassGroupStudent>> GetAllTeacherInSchool(Guid SchoolId);
    }
}
