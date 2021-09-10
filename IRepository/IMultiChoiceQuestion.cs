using LMS_InterfaceProject.DbModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
    public interface IMultiChoiceQuestion
    {
        Task<List<MultiChoiceQuestion>> GetQuestionsByAssignmentId(Guid assignmentId);
        Task<MultiChoiceQuestion> GetQuestionByQuestionId(Guid questionId);
        Task<int> InsertQuestion(MultiChoiceQuestion data);
        Task<int> UpdateQuestion(MultiChoiceQuestion data);
        Task<int> DeleteQuestion(DeleteQuestionModel data);
    }
}