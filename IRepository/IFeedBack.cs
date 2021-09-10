using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
    public interface IFeedBack
    {
        Task<int> InsertFeedBack(FeedBack data);
    }
}
