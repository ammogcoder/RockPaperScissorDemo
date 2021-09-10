using DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
    public interface ISignIn
    {
        Task<LoggedInUser> SignInUser(UserDetails login);
        Task<object> SignInMobile(UserDetails login);


    }
}