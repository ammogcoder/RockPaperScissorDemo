using LMS_WebProject.Classes;
using LMS_WebProject.Contract.Repository;
using LMS_WebProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace LMS_WebProject.Repositorys
{
    public class GenericRepository : IGenericRepository
    {
        public async Task<T> GetAsync<T>(string uri, string authToken = "")
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(authToken);
                string jsonResult = string.Empty;

                var responseMessage =  await httpClient.GetAsync(uri);

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json = JsonConvert.DeserializeObject<T>(jsonResult);
                    return json;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                    responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return (T)(object)new ResponseModel
                    {
                        State = -1,
                        Data = null,
                        Msg = "Session Timeout, Please Re-Login"
                    };
                }
                return (T)(object)new ResponseModel
                {
                    State = -1,
                    Data = null,
                    Msg = "No Record Found"
                }; ;
            }
            catch (Exception ex)
            {
                BaseHandle.logger.WriteLog(ex);
                throw;
            }
        }

        public async Task<T> PostAsync<T>(string uri, T data, string authToken = "")
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(authToken);

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                string jsonResult = string.Empty;

                var responseMessage = await httpClient.PostAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json = JsonConvert.DeserializeObject<T>(jsonResult);
                    return json;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                    responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return (T)(object)new ResponseModel
                    {
                        State = -1,
                        Data = null,
                        Msg = "Session Timeout, Please Re-Login"
                    }; ;
                }
                return (T)(object)new ResponseModel
                {
                    State = -1,
                    Data = null,
                    Msg = "No Record Found"
                }; ;
                
            }
            catch (Exception ex)
            {
                BaseHandle.logger.WriteLog(ex);
                throw;
            }
        }
        
        public async Task<T> PutAsync<T>(string uri, T data, string authToken = "")
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(authToken);

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                string jsonResult = string.Empty;

                var responseMessage =  await httpClient.PutAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json = JsonConvert.DeserializeObject<T>(jsonResult);
                    return json;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                   responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return (T)(object)new ResponseModel
                    {
                        State = -1,
                        Data = null,
                        Msg = "Session Timeout, Please Re-Login"
                    }; 
                }
                return (T)(object)new ResponseModel
                {
                    State = -1,
                    Data = null,
                    Msg = "No Record Found"
                }; ;
            }
            catch (Exception ex)
            {
                BaseHandle.logger.WriteLog(ex);
                throw;
            }
        }

        public async Task DeleteAsync(string uri, string authToken = "")
        {
            HttpClient httpClient = CreateHttpClient(authToken);
            await httpClient.DeleteAsync(uri);
        }

        public async Task<TR> PostAsync<T, TR>(string uri, T data, string authToken = "")
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(authToken);

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                string jsonResult = string.Empty;

                var responseMessage = await httpClient.PostAsync(uri, content);
                jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (responseMessage.IsSuccessStatusCode)
                {
                   
                    var json = JsonConvert.DeserializeObject<TR>(jsonResult);
                    return json;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                   responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return (TR)(object)new ResponseModel
                    {
                        State = -1,
                        Data = null,
                        Msg = "Session Timeout, Please Re-Login"
                    };
                }
                return (TR)(object)new ResponseModel
                {
                    State = -1,
                    Data = null,
                    Msg = "No Record Found"
                }; 
            }
            catch (Exception ex)
            {
                BaseHandle.logger.WriteLog(ex);
                throw;
            }
        }
        private HttpClient CreateHttpClient(string authToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(authToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            }
            return httpClient;
        }
    }
}