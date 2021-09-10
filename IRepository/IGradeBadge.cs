using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
   public interface IGradeBadge
    {
        Task<int> InsertGradeBadge(GradeBadge data);
    }

    public interface IStudentLearningAchievement
    {
        Task<int> InsertStuLearningAch(StudentLearningAchievement data);
    }
}
