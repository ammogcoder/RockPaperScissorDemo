using DbModel;
using LMS_InterfaceProject;
using LMS_InterfaceProject.Extras;
using LMS_WebProject.Classes;
using LMS_WebProject.Constant;
using LMS_WebProject.Contract.Repository;
using LMS_WebProject.Helpers;
using LMS_WebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LMS_WebProject
{
    public partial class LoginViewX : System.Web.UI.Page
    {
        private readonly IGenericRepository _genericRepository;
        public Users gControler;
        private static bool _IsFirstLogin = true;
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                bool IsAdmin = true;  
                gControler = new Users().GetController();
                string token;
                try
                {
                     token = Request.QueryString["token"].ToString(); 
                }
                catch (Exception)
                {  
                        writeInfo("Invalid Login. No Authorization Found");
                        return; 
                }
                try
                {
                     CourseID = Request.QueryString["courseid"].ToString(); 
                }
                catch (Exception)
                {   
                }
                if (token == null || token == string.Empty)
                {
                    writeInfo("Invalid Login. No Authorization Found");
                    return;
                }

                string decrypted = await getDecryptedData(token);
                if (decrypted == null || decrypted == string.Empty)
                {
                    writeInfo("Invalid Token Sent");
                    return;
                }

                var splitdata = decrypted.Split('|');
                var expireddate = DateTime.ParseExact(splitdata[2].Substring(0,19), "yyyy.MM.dd.HH.mm.ss", null);
                if (expireddate < DateTime.Now)
                {
                    writeInfo("Login Failed. Token Expired");
                    return;
                }

                string result =await LoginNow(splitdata[0], splitdata[1]);
                if (result != string.Empty)
                {
                    writeInfo(result);
                    return;
                }
            }
        }

        void writeInfo(string str)
        {
            dvinfo.InnerHtml = str; 
        }
        public async Task<string> getDecryptedData(string data)
        {
            try
            {
                //UriBuilder builder = new UriBuilder(ApiConstant.BaseApiUrl)
                //{
                //    Path = ApiConstant.DecodeTokenEndpoint
                //};
                //var Indata = new oneValue()
                //{
                //    value = data
                //};

                ////get the list of p
                //var response = await _genericRepository.PostAsync<oneValue, ResponseModel>(builder.ToString(), Indata);
                //if (response.State == 1)
                //{
                //    return (string)response.Data;
                //}
                string reversed = System.Net.WebUtility.UrlDecode(data);
               return LMS_LogicBase.Extras.Simple3Des.DESDecryptWord(Convert.FromBase64String(data), APIConstant.ExternalEncryptKey);
            }
            catch (Exception ex)
            {
                BaseHandle.logger.WriteLog(ex);
            }
            return string.Empty;
        }

        public LoginViewX(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }
        
        string CourseID = "";// CourseUrl.Value;
        protected async Task<string> LoginNow(string email, string password)
        {
           string errorMesssage = string.Empty;
           try
            {
                Users gController;
                gController = new Users();

                UriBuilder builder = new UriBuilder(ApiConstant.BaseApiUrl)
                {
                    Path = ApiConstant.SignInEndpoint
                };
                var LogIn = new UserDetails()
                {
                    Email = email,
                    Password = password
                };

                //get the list of p
                var response = await _genericRepository.PostAsync<UserDetails, LogInModel>(builder.ToString(), LogIn);
                if (response.State == 1)
                {
                    //if (response.Data.profile.IsActivated.Value)
                    //{
                    var userRole = response.Data.roles.Where(c => c.IsDefault == true).SingleOrDefault();
                    if (userRole == null)  userRole = response.Data.roles.FirstOrDefault();

                    if (Request.QueryString.ToString().Contains("redirectUrl"))
                    {
                        if (Request.QueryString["redirectUrl"] != null)
                        {
                            castProfileToUser(response.Data.profile, response.Data.roles, ref gController,
                            userRole.IsSchoolAdmin.Value, userRole.IsStudent.Value, userRole.IsTeacher.Value,
                            userRole.IsContentProvider.Value, userRole.IsParent.Value, true);
                            gController.Save();
                            String u = HttpUtility.UrlDecode(Request.QueryString["redirectUrl"].ToString());
                            Response.Redirect(u, false);
                        }
                    }
                    else if ((!string.IsNullOrEmpty(CourseID)) && (userRole.IsStudent == true))
                    {
                        castProfileToUser(response.Data.profile, response.Data.roles, ref gController,
                            userRole.IsSchoolAdmin.Value, userRole.IsStudent.Value, userRole.IsTeacher.Value,
                            userRole.IsContentProvider.Value, userRole.IsParent.Value, true);
                        gController.Save();

                        Response.Redirect("_LearnNow/StartCourse?courseId=" + CourseID, false);
                    }
                    else if (userRole.IsSchoolAdmin == true)
                    {
                        castProfileToUser(response.Data.profile, response.Data.roles, ref gController,
                            userRole.IsSchoolAdmin.Value, userRole.IsStudent.Value, userRole.IsTeacher.Value,
                            userRole.IsContentProvider.Value, userRole.IsParent.Value, response.Data.SubscriptionStatus);
                        gController.Save();
                        if (response.Data.profile.IsFirstLogin.Value)
                        {
                            var builderT = ApiConstant.BaseApiUrl + ApiConstant.isFirstTimeEndPoint + response.Data.profile.ProfileId;
                            var isFirst = await _genericRepository.GetAsync<IsFirstModel>(builderT.ToString());
                            Response.Redirect("_MyProfile/MyProfile", false);
                        }
                        else
                        {

                            Response.Redirect("_Dashboard/SchoolAdmin", false);
                        }
                    }
                    else if (userRole.IsContentProvider == true)
                    {
                        castProfileToUser(response.Data.profile, response.Data.roles, ref gController,
                            userRole.IsSchoolAdmin.Value, userRole.IsStudent.Value, userRole.IsTeacher.Value,
                            userRole.IsContentProvider.Value, userRole.IsParent.Value, true);
                        gController.Save();
                        if (response.Data.profile.IsFirstLogin.Value)
                        {
                            var builderT = ApiConstant.BaseApiUrl + ApiConstant.isFirstTimeEndPoint + response.Data.profile.ProfileId;
                            var isFirst = await _genericRepository.GetAsync<IsFirstModel>(builderT.ToString());
                            Response.Redirect("_MyProfile/MyProfile", false);
                        }
                        else
                            Response.Redirect("_Dashboard/CProvider", false);
                    }
                    else if (userRole.IsParent == true)
                    {
                        castProfileToUser(response.Data.profile, response.Data.roles, ref gController,
                             userRole.IsSchoolAdmin.Value, userRole.IsStudent.Value, userRole.IsTeacher.Value,
                            userRole.IsContentProvider.Value, userRole.IsParent.Value, true);
                        gController.Save();
                        if (response.Data.profile.IsFirstLogin.Value)
                        {

                            var builderT = ApiConstant.BaseApiUrl + ApiConstant.isFirstTimeEndPoint + response.Data.profile.ProfileId;
                            var isFirst = await _genericRepository.GetAsync<IsFirstModel>(builderT.ToString());
                            Response.Redirect("_MyProfile/MyProfile", false);
                        }
                        else
                            Response.Redirect("");
                    }
                    else if (userRole.IsTeacher == true)
                    {
                        if (response.Data.profile.IsActivated.Value)
                        {
                            castProfileToUser(response.Data.profile, response.Data.roles, ref gController,
                                 userRole.IsSchoolAdmin.Value, userRole.IsStudent.Value, userRole.IsTeacher.Value,
                                userRole.IsContentProvider.Value, userRole.IsParent.Value, response.Data.SubscriptionStatus, 
                                response.Data.schoolroles.Select(c=>c.PermissionName).ToList());
                            gController.Save();
                            if (response.Data.profile.IsFirstLogin.Value)
                            {

                                var builderT = ApiConstant.BaseApiUrl + ApiConstant.isFirstTimeEndPoint + response.Data.profile.ProfileId;
                                var isFirst = await _genericRepository.GetAsync<IsFirstModel>(builderT.ToString());
                                Response.Redirect("_MyProfile/MyProfile", false);
                            }
                            else
                                Response.Redirect("_Dashboard/Teacher", false);
                        }
                        else
                        {
                            errorMesssage = "Your Account has been Deactivated, Please Contact your Admin"; 
                        }
                            

                    }
                    else
                    {
                        castProfileToUser(response.Data.profile, response.Data.roles, ref gController,
                            userRole.IsSchoolAdmin.Value, userRole.IsStudent.Value, userRole.IsTeacher.Value,
                            userRole.IsContentProvider.Value, userRole.IsParent.Value, true);
                        gController.Save();
                        if (response.Data.profile.IsFirstLogin.Value)
                        {
                            var builderT = ApiConstant.BaseApiUrl + ApiConstant.isFirstTimeEndPoint + response.Data.profile.ProfileId;
                            var isFirst = await _genericRepository.GetAsync<IsFirstModel>(builderT.ToString());

                            Response.Redirect("_MyProfile/MyProfile", false);
                        }
                        else
                        {

                            Response.Redirect("_LearnNow/LearnLibrary", false);
                        }
                    }

                    //} 
                    //else
                    //    general.BootstrapAlert(Page, "", "Your Account has been Deactivated, Please Contact your Admin", general.MsgTypes.error, divNotification);

                }
                else
                {
                    errorMesssage = response.Msg;
                    // dvMessage.showMessage(response.Msg, general.MsgTypes.error);
                }
            }
            catch (Exception ex)
            {
                 BaseHandle.logger.WriteLog(ex);
                 return "Something is temporarily wrong with your network connection, Make sure your are connected to the internet and try again";
            }
            return errorMesssage;
        }
        void castProfileToUser(Profile p, List<ProfileRoles> r, ref Users u,
            bool isAdmin, bool isStudent, bool isTeacher,
            bool isContentProvider, bool isParent, bool schoolSubscriptionStatus = false, List<string> permissionList = null)
        {
            u = new Users()
            {
                ProfileId = p.ProfileId,
                Surname = p.Surname,
                FirstName = p.FirstName,
                OtherName = p.OtherName,
                DateOfBirth = p.DateOfBirth,
                Email = p.Email,
                DateCreated = p.DateCreated,
                IsActive = p.IsActive,
                Gender = p.Gender,
                Password = p.Password,
                IsVerified = p.IsVerified,
                SchoolId = p.SchoolId,
                IsAdmin = isAdmin,
                IsFirstLogin = p.IsFirstLogin,
                IsRootAdmin = p.IsRootAdmin,
                IsParent = isParent,
                MyParentId = p.MyParentId,
                IsStudent = isStudent,
                IsContentProvider = isContentProvider,
                Schoolname = p.Schoolname,
                Address = p.Address,
                city = p.city,
                stateId = p.stateId,
                Telephone = p.Telephone,
                IsTeacher = isTeacher,
                ImageUrl = p.ImageUrl,
                IsApproved = p.IsApproved,
                IsPlatformOwner = p.IsPlatformOwner,
                SchoolSubscriptionStatus = schoolSubscriptionStatus,
                PermissionList = permissionList
            };

            u.roles = r;
            if (u.IsContentProvider == true)
            {
                u.LoginType = UserType.ContentProvider;
            }
            else if (u.IsParent == true)
            {
                u.LoginType = UserType.Parent;
            }
            else if (u.IsStudent == true)
            {
                u.LoginType = UserType.Student;
            }
            else if (u.IsAdmin == true)
            {
                u.LoginType = UserType.SchoolAdmin;
            }
            else if (u.IsTeacher == true)
            {
                u.LoginType = UserType.Teacher;
            }
        }

         public static class ValidateEmail
        {
            public static bool IsValidEmail(string email)
            {
                var r = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");

                return !string.IsNullOrEmpty(email) && r.IsMatch(email);
            }
        }
    }


}