using LMS_InterfaceProject.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
    public interface IAdminRepository
    {
        Task<SchoolDetailsDto> GetSchoolsDetails();
        Task<StudentDetailsDto> GetStudentsDetails();
        Task<object> GetSchoolsStatisticAsync();
        Task<object> GetLearnerAsync();
    }
}
