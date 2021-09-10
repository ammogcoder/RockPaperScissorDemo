using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
  public interface IAssignment
  {
    Task<List<AssignmentSubmissionDocs>> GetAssignmentSubmissionDocument(Guid AssignmentSubDocumentId);
    Task<List<AssignmentDocs>> GetAssignmentDocument(Guid AssignmentDocumentId);
    Task<string> InsertAssignment(Assignment data);
    Task<int> UpdateAssignment(Assignment data);
    Task<string> InsertAssignmentDocument(AssignmentDocs data);
    Task<int> InsertAssignmentSubDocument(AssignmentDocs data);
    Task<int> UpdateAssignmentDocument(UpdateAssDoc data);
    Task<int> DeleteAssignment(Guid AssignmentId);
    Task<object> GetAssignments(Guid ProfileId);
    Task<List<AssignmentDrop>> GetAllAssignment(Guid ProfileId);
    Task<object> GetAllAssignmentByTeacherId(Guid ProfileId, Guid AssignmentId);
    Task<object> GetAllAssignmentSubmitted(Guid AssignmentId);
    Task<object> GetAllAssignmentCollaborated(Guid AssignmentId);
    Task<List<object>> GetAllAssignmentOtherCollaborated(Guid ProfileId);
    Task<object> GetAllAssignmentDetailsSubmittedById(Guid AssignmentSubmissionId);
    Task<object> GetAllAssignmentApproval(Guid ProfileId);
    Task<object> GetAssignmentDoc(Guid AssignmentId);
    Task<int> DeleteAssignmentDocument(Guid AssignmentId);
    Task<int> PublishAssignment(Guid AssignmentId);
  }

  public interface IAssignmentProfile
  {
    Task<int> InsertAssignmentPro(AssignmentProfile data);
    Task<int> UpdateAssignmentPro(AssignmentProfile data);
    Task<int> DeleteAssignmentPro(Guid AssignmentProfileId);
  }
  public interface IAssignmentStudent
  {
    Task<int> InsertAssignmentStudent(AssignmentStudent data);
    Task<int> ExtendAssignmentDeadlineForStudent(AssignmentStudent data);
    Task<int> UpdateAssignmentStudent(AssignmentStudent data);
    Task<int> DeleteAssignmentStudent(Guid AssignmentStudentId);
    Task<object> GetAllAssignmentForStudent(Guid ProfileId, int PathId);
    Task<object> GetAllAssignmentDetailForStudent(Guid AssignmentId);

  }
  public interface IAssignmentSubmission
  {
    Task<string> InsertAssignmentSub(AssignmentSubmission data);
    Task<int> UpdateAssignmentSub(AssignmentSubmission data);
    Task<int> DeleteAssignmentSub(Guid AssignmentSubmissionId);
    Task<int> InsertAssignmentSubDocument(AssignmentDocs data);
    Task<StudentAssignmentSubmission> AssignmentSubmissionNotification(Guid AssignmentId);
  }
}
