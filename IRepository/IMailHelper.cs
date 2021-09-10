using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
   public interface IMailHelper
    {
        Task<bool> SendEmailMessenger(string Email, string activationCode, string UserType, string Path ="",
            byte[] AttachedFileName = null, string CC = "", string BCC = "", string Link = "", string subject = "");

        Task SendEmailAsync(string email, string subject, string message);
        Task<bool> SendMailToStudentAsync(string email, string Name, string ActionLink, string subject, string message, string Path = "");
        Task<bool> SendMailToStudentForInviteAsync(string email, string ActionLink, string subject, string SchoolName, string SchoolCode, string Path = "");
    }
}
