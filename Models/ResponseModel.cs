using DbModel;
using LMS_InterfaceProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS_WebProject.Models
{
    public class ResponseModel
    {
        public int State { get; set; }
        public string Msg { get; set; }
        public Object Data { get; set; }
    }

    public class RoleModel
    {
        public int State { get; set; }
        public string Msg { get; set; }
        public List<Role> Data { get; set; }
    }
    public class AssModel
    {
        public int State { get; set; }
        public string Msg { get; set; }
        public List<AssignmentDrop> Data { get; set; }
    }
    public class RoleModelAcc
    {
        public int State { get; set; }
        public string Msg { get; set; }
        public IsVerifiedAcc Data { get; set; }
    }
    public class PathModel
    {
        public int State { get; set; }
        public string Msg { get; set; }
        public ContentPath Data { get; set; }
    }

    public class AccountInitials
    {
        public int State { get; set; }
        public string Msg { get; set; }
        public AccountInitiationClass Data { get; set; }
    }
    public class CategoryModel
    {
        public int State { get; set; }
        public string Msg { get; set; }
        public List<GetCategory> Data { get; set; }
    }
    public class StateModel
    {
        public int State { get; set; }
        public string Msg { get; set; }
        public List<GetState> Data { get; set; }
    }

    public class UserRoleModel
    {
      public int State { get; set; }
      public string Msg { get; set; }
      public List<ProfileRoles> Data { get; set; }
    }

  public class EmailModel
    {
        public int State { get; set; }
        public string Msg { get; set; }
        public IsVerified Data { get; set; }
    }
    public class ForgotPasswordModel
    {
        public int State { get; set; }
        public string Msg { get; set; }
        public ForgotPassword Data { get; set; }
    }
    public class ResetPasswordModel
    {
        public int State { get; set; }
        public string Msg { get; set; }
        public ResetPassword Data { get; set; }
    }
    public class LogInModel
    {
        public int State { get; set; }
        public string Msg { get; set; }
        public LoggedInUser Data { get; set; }
    }
    public class IsFirstModel
    {
        public int State { get; set; }
        public string Msg { get; set; }
        public bool  Data { get; set; }
    }
    public static class RoleType
    {
        public static bool student { get; set; }
        public static bool Parent { get; set; }
        public static bool contentPro { get; set; }
        public static bool schoolAdmin { get; set; }
        public static Guid schoolId { get; set; }
    }

    public class ContentSessionArray
    {
        public string SectionName { get; set; }
        public string ContentTitle { get; set; }
        public string ContentDesc { get; set; }
        public string ContentType { get; set; }
        public string ContentName { get; set; }
        public byte[] ContentByte { get; set; }
        public Guid sessionId { get; set; }

    }
}