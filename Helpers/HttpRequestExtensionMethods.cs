using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.IO; 
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LMS_WebProject.Helpers
{
    public static class HttpRequestExtensionMethods
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
            {
                return false;
            }

            if (request != null)
            {
                return (request.Headers["X-Requested-With"] == "XMLHttpRequest") || ((request.Headers != null) && (request.Headers["X-Requested-With"] == "XMLHttpRequest"));
            }

            return false;
        }
    }


 
}