using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
    public interface IGenericRepository
    {
        Task<T> GetAsync<T>(string uri, string authToken = "", string clientToken = "");
        Task<T> PostAsync<T>(string uri, T data, string authToken = "", string clientToken = "");
        Task<T> PutAsync<T>(string uri, T data, string authToken = "", string clientToken = "");
        Task DeleteAsync(string uri, string authToken = "", string clientToken = "");
        Task<R> PostAsync<T, R>(string uri, T data, string authToken = "", string clientToken = "");
    }
}
