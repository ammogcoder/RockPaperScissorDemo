using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
    public interface ITransaction
    {
        Task<string> AddTransaction(TransactionViewModel data);       
        Task<TransactionViewModel> GetTransactionById(string transactionId);
        Task<int> UpdateTransaction(TransactionModel data);
        Task<List<Pricing>> GetAllPricing();
        Task<int> ManageContentSubscribers(ContentSubscribers data);
        Task<RT> FinalizeUserPayment(FinalizedModel data);
        Task<int> HasValidContentSubscription(ValidSubModel data);


        //Content Provider Revenue & Subscription Details
        Task<List<RevenueDetails>> GetContentProviderRevenueDetails(Guid profileId, DateTime startDate, DateTime endDate);
        Task<List<dynamic>> GetContentProviderSubscriptionDetails(Guid profileId,  DateTime startDate, DateTime endDate);
    }
}
