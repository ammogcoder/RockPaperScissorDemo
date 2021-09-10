using DbModel;
using LMS_InterfaceProject;
using LMS_WebProject.Constant;
using LMS_WebProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LMS_WebProject.Repository
{
    public class LogInRepo
    {
        public async Task<LogInModel> LogInUser(string email, string password)
        {
            try
            {
                var LogIn = new UserDetails()
                {
                    Email = email,
                    Password = password
                };

                string url = ApiConstant.BaseApiUrl + ApiConstant.SignInEndpoint;

                var httpclient = new HttpClient();

                var json = JsonConvert.SerializeObject(LogIn);
                var contentformat = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpclient.PostAsync(url, contentformat);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode == true)
                {
                    var responseJson = JsonConvert.DeserializeObject<LogInModel>(content);
                    if (responseJson.State == 1)
                    {
                        return responseJson;
                    }
                    else
                    {
                        return responseJson;
                    }
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return (new LogInModel
                        {
                            State = -1,
                            Data = null,
                            Msg = "Session Timeout, Please Re-Login"
                        });
                    }

                    return (new LogInModel
                    {
                        State = 0,
                        Data = null,
                        Msg = "Unable to complete your request"
                    });
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        internal Task LogInUser(object value)
        {
            throw new NotImplementedException();
        }
    }
}