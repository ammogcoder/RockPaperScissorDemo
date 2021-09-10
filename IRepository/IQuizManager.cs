using DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
  public interface IQuizManager
  {
    Task<object> GetQuizDetails(Guid QuizId);
    Task<string> CreateQuiz(Quiz data);
    Task<object> GetAllQuizQuestion(Guid QuizId);
    Task<int> DeleteQuiz(Guid QuizId);
    Task<int> UpdateQuizTabOne(Quiz data);
    Task<int> UpdateQuizTabTwo(Quiz data);
    Task<object> GetAllQuizForStudent(int PathId);
    Task<object> GetAllQuizForAnomynous();
    Task<object> GetAllQuizByQuizId(Guid QuizId, Guid ProfileId);
    Task<int> PublishQuiz(Guid QuizId);
    Task<FinalScoreInfo> GetQuizTotalScore(Guid CandidateLibrayId);
    Task<object> ContinueQuiz(Guid CandidateLibrayId);
    Task<List<object>> CreateQuizQuestion(QuizQuestion data);
    Task<List<object>> UpdateQuizQuestion(QuizQuestion data);
    Task<object> DeleteQuizQuestion(Guid QuizQuestionId, Guid QuizId);
    Task<object> StartQuiz(StartQuizHandler data);
    Task<QuizQuestion> GetObjQuizQuestionByQuestionId(Guid QuestionId, Guid QuizSessionId);
    Task<QuizQuestion> GetQuizQuestionById(Guid QuizQuestionId);
    Task<int> UpdateQuizResponse(UserResponse data);
    Task<QuizQuestion> GetQuizQuestion(Guid QuestionId, Guid QuizSessionId);

    Task<int> CreateQuizLibrary(Quizlibrary data);
    Task<int> UpdateQuizLibrary(Quizlibrary data);
    Task<int> DeleteQuizLibrary(Guid QuizLibId);
    Task<int> CreateQuizResponse(QuizResponse data);
    Task<int> UpdateQuizResponse(QuizResponse data);
    Task<int> DeleteQuizResponse(Guid QuizResponseId);
    Task<string> GetQuizSecretKey(string quizId);
    Task<List<QuizReview>> GetQuizQuestionForReview(Guid QuizLibraryId);
    Task<int> InsertQuizStudent(QuizStudent data);
    Task<object> GetAllQuizByProvider(Guid ProfileId);
    Task<object> GetAllQuizAssignedToStudent(Guid QuizId);
    Task<object> GetAllQuizForStudent(Guid ProfileId);
    Task<object> GetQuizInformationByProfileId(Guid ProfileId);
    Task<object> GetQuizInformationForCard(Guid ProfileId);
    Task<object> GetQuizInformationByQuizId(Guid QuizId, Guid ProfileId);
    Task<object> GetAllQuizByProfileId(Guid ProfileId);
    Task<object> GetQuizSummaryForTeacher(Guid QuizId);
    Task<LoggedInUser> RefreshSession(Guid CandidateLibraryId, double MinuteLeft, Guid QuizSessionId);
    Task<StudentAssignmentSubmission> QuizCompletionNotification(Guid QuizlibraryId);
    Task<object> GetAllIndividualQuizAttempts(Guid ProfileId, Guid QuizId);
    Task<object> GetStudentPerformance(Guid QuizlibraryId);
     Task<object> GetQuizList(Guid ProfileId);
    }

}

