using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LMS_WebProject.Constant
{
    public static class ApiConstant
    {
        public static string LiveURLPart = "luminate.ng";
        public static string BaseApiUrl = ConfigurationManager.AppSettings["BaseApiUrlKey"];

        public const string AuthenticateEndpoint = "api/Profile/AddNewProfile";
        public const string ContSignUp = "api/Profile/UpdateProfile";
        public const string GetState = "api/Location/GetState";
        public const string GetRole = "api/Location/GetAllRole";
        public const string GetLGAByState = "api/Location/GetLGAByState";
        public const string emailverify = "api/Profile/VerifyAccount/";
        public const string SignInEndpoint = "api/SignIn/SignIn/";
        public const string DecodeTokenEndpoint = "api/SignIn/DecodeToken/";
        public const string addContentsession = "api/Session/AddNewContentSession";
        public const string ForgotPassword = "api/Profile/ForgotPassword";
        public const string ResetPassword = "api/Profile/ResetPassword";
        public static string GetCategoryBySchool(Guid SchoolID) { 
            return $"api/Location/GetAllCategoryBySchool/{SchoolID}";
            }
        public const string GetCategory = "api/Location/GetAllCategory";
        public const string UpdateContentsession = "api/Session/UpdateContentSession";
        public const string GetContentPath = "api/Content/GetContentFileName";
        public const string VerifyAcountInitials = "api/Profile/VerifyAccountAcc/";
        public const string AddNewAcountInitials = "api/Profile/AddNewAccountInitiation";
        public const string GetAllAssignment = "api/Assignment/GetAssignment";
        public const string UpdateRole = "api/Profile/UpdateRole";
        public const string Refresh = "api/Quiz/RefreshSession";
        public const string isFirstTimeEndPoint = "api/Profile/IsfirstTime?ProfileId=";
        public const string AddToShoppingCartEndpoint = "api/ShoppingCart/AddToShoppingCart";
        public const string GetShoppingCartItemsEndpoint = "api/ShoppingCart/GetShoppingCartItems";
        public const string RemoveShoppingCartItemEndpoint = "api/ShoppingCart/RemoveFromShoppingCart";
        public const string ClearShoppingCartEndpoint = "api/ShoppingCart/ClearCart";
        public const string GetShoppingCartTotalEndpoint = "api/ShoppingCart/GetShoppingCartTotal";
        public const string ProcessOrderEndpoint = "api/Payment/ProcessOrder";
        public const string CompleteOrderEndpoint = "api/Payment/VerifyPayment/";
        
        //Subscription
        public const string GetSubscriptionEndpoint = "api/Subscription/GetSubscription";
        public const string GetSubscriptionTypeEndpoint = "api/Subscription/GetSubscriptionTypeById";
        public const string GetSubscriptionTypesEndpoint = "api/Subscription/GetNonTrialSubscriptions";
        public const string StartNewSubscriptionEndpoint = "api/Subscription/NewSubscription";
        public const string StartSubscriptionRenewalEndpoint = "api/Subscription/RenewSubscription";
        public const string StartSubcriptionUpgradeEndpoint = "api/Subscription/UpgradeSubscription";
        public const string ProcessNewSubscriptionEndpoint = "api/Subscription/ProcessNewSubscription";
        public const string ProcessSubscriptionRenewalEndpoint = "api/Subscription/ProcessSubscriptionRenewal";
        public const string ProcessSubscriptionUpgradeEndpoint = "api/Subscription/ProcessSubscriptionUpgrade";
        public const string CompleteNewSubscriptionEndpoint = "api/Subscription/CompleteNewSubscription/";
        public const string CompleteRenewSubscriptionEndpoint = "api/Subscription/CompleteRenewSubscription/";
        public const string CompleteUpgradeSubscriptionEndpoint = "api/Subscription/CompleteUpgradeSubscription/";

        public static string GetAllCourseInfomation(string contentsessionId) { return $"api/Content/GetAllCourseInfomation/{contentsessionId}"; }
        public static string GetContentSessionDetails(string sessionid) { return $"api/Content/GetContentSessionDetails/{sessionid}"; }
        public static string GetContentDetails(string ContentId) { return $"api/Content/GetContentDetails/{ContentId}"; }
        public static string GetContentDownload(string ContentId) { return $"api/General/GetContentAsDownload/{ContentId}"; }
        public static string GetAssignmentDoc(string AssignmentDocumentId) { return $"api/General/GetAssignmentDoc/{AssignmentDocumentId}"; }
        public static string GetAssignmentDocDetails(string AssignmentDocumentId) { return $"api/Assignment/GetAssignmentDocumentDetails/{AssignmentDocumentId}"; }
        public static string GetAssignmentSubmissionDoc(string AssignmentSubDocumentId) { return $"api/General/GetAssignmentSubmissionDoc/{AssignmentSubDocumentId}"; }
        public static string StreamAssignmentSubmissionDoc(string AssignmentSubDocumentId) { return $"api/General/StreamAssignmentSubmissionDoc/{AssignmentSubDocumentId}"; }
        public static string GetQuizDetails(string QuizId) { return $"api/Quiz/GetQuizDetails/{QuizId}"; }
    }
}


