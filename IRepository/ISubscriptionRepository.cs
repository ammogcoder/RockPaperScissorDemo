using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
    public interface ISubscriptionRepository
    {
        //Subscriptions
        Task<int> AddSchoolPaymentHistory(SchoolPaymentHistories schoolPayment);
        Task<SchoolSubscriptions> GetSubscription(Guid schoolId, Guid subscriptionId);
        Task<SchoolSubscriptionVM> GetSubscriptionBySchoolId(Guid schoolId);
        Task<List<SchoolPaymentHistories>> GetSchoolPaymentHistory(Guid schoolId, Guid subscriptionId);
        Task<List<dynamic>> GetSchoolPaymentHistoryBySchoolId(Guid schoolId, DateTime startDate, DateTime endDate);
        Task<SchoolSubscriptions> GetSubscriptionById(Guid subscriptionId);
        Task<SchoolSubscriptionsView> GetSubscriptionViewById(Guid subscriptionId);
        Task<SchoolPaymentHistories> GetPaymentHistoryByTransRef(string transactionRef);
        Task<SchoolSubscriptionsHistory> GetSubscriptionHistory(Guid schoolId);

        Task<Guid> AddNewSchoolSubscription(SchoolSubscriptions schoolSubscription);
        Task<int> RenewSchoolSubscription(SchoolSubscriptions schoolSubscription);
        Task<int> UpgradeSchoolSubscription(SchoolSubscriptions schoolSubscription);
        Task<int> UpdateSchoolPaymentHistory(SchoolPaymentHistories schoolPayment);

        //Subscription Management
        Task<List<SchoolSubscriptionsView>> GetSubscriptionDueForRenewal();
        Task<List<SchoolSubscriptionsView>> GetSubscriptionDueForNextWeek();
        Task<List<SchoolSubscriptionsView>> GetSubscriptionDueForTomorrow();

        //Customer Journey
        Task<List<SchoolSubscriptionsView>> GetTrial5days();
        Task<List<SchoolSubscriptionsView>> GetTrial15days();
        Task<List<SchoolSubscriptionsView>> GetTrial25days();
        Task<List<SchoolSubscriptionsView>> GetTrial30days();

        //SubscriptionTypes
        Task<SchoolBills> GetSubscriptionTypeById(Guid id);
        Task<List<SchoolBills>> GetSubscriptionTypes();
        Task<SchoolBills> GetTrialSubscription();
    }
}
