using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;

using LitJson;

namespace view
{
    using model.table;
    using controller;

    public class action : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            String type = context.Request.QueryString["type"];
            JsonData json = new JsonData();

            if (!String.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    #region existsAccount
                    case "existsAccount":
                        students tempStudents = new students();
                        tempStudents.account = context.Request["account"];
                        tempStudents.super = 1;
                        tempStudents.status = 0;

                        Boolean tempOutStudents = controllerProvider.instance().selectAccount(tempStudents);
                        if (tempOutStudents)
                        {
                            context.Response.Write("true");
                        }
                        else
                        {
                            context.Response.Write("false");
                        }
                        context.Response.End();
                        return;
                    #endregion

                    #region doLogin
                    case "doLogin":
                        String inAccount = context.Request["account"]
                            , inPassword = context.Request["password"]
                            , inKeep = context.Request["keepLine"];

                        if (String.IsNullOrEmpty(inAccount) || String.IsNullOrEmpty(inPassword))
                        {
                            break;
                        }

                        students inStudents = new students();
                        inStudents.account = inAccount;
                        inStudents.password = inPassword;
                        inStudents.super = 1;
                        inStudents.status = 0;

                        students outStudents = controllerProvider.instance().selectStudents(inStudents);

                        if (outStudents == null)
                        {
                            json["code"] = "error";
                            json["story"] = "登录验证失败";
                        }
                        else
                        {
                            if (inKeep == "on")
                            {
                                HttpCookie cookies = new HttpCookie("keepLine");
                                cookies["account"] = context.Server.HtmlEncode(outStudents.account);
                                cookies["password"] = context.Server.HtmlEncode(outStudents.password);
                                cookies.Expires = DateTime.Now.AddYears(1);
                                context.Response.Cookies.Add(cookies);
                            }
                            else
                            {
                                HttpCookie cookies = context.Request.Cookies.Get("keepLine");
                                if (cookies != null)
                                {
                                    cookies.Values.Remove("account");
                                    cookies.Values.Remove("password");
                                    context.Response.Cookies.Add(cookies);
                                }
                            }
                            json["code"] = "pass";
                            json["story"] = "登录验证通过";
                        }
                        break;
                    #endregion

                    #region addStudent
                    case "addStudent":

                        String addAccount = context.Request["account"]
                            , addPassword = context.Request["password"]
                            , addNumber = context.Request["number"]
                            , addName = context.Request["name"]
                            , addGender = context.Request["gender"]
                            , addClasses = context.Request["classes"]
                            , addSuper = context.Request["super"];

                        inStudents = new students();
                        inStudents.account = addAccount;
                        inStudents.password = addPassword;
                        inStudents.number = addNumber;
                        inStudents.name = addName;
                        inStudents.gender = Convert.ToInt16(addGender);
                        inStudents.classes = addClasses;
                        inStudents.super = Convert.ToInt16(String.IsNullOrEmpty(addSuper) ? 0 : 1);

                        if (controllerProvider.instance().doStudent(1, inStudents))
                        {
                            json["code"] = "pass";
                            json["story"] = "保存成功";
                        }
                        else
                        {
                            json["code"] = "error";
                            json["story"] = "保存失败";
                        }

                        break;
                    #endregion

                    #region updateStudent

                    case "updateStudent":
                        String updateAccount = context.Request["account"]
                            , updatePassword = context.Request["password"]
                            , updateNumber = context.Request["number"]
                            , updateName = context.Request["name"]
                            , updateGender = context.Request["gender"]
                            , updateClasses = context.Request["classes"]
                            , updateSuper = context.Request["super"]
                            , updateCharId = context.Request["charId"];

                        inStudents = new students();
                        inStudents.charId = updateCharId;
                        inStudents.account = updateAccount;
                        inStudents.password = updatePassword;
                        inStudents.number = updateNumber;
                        inStudents.name = updateName;
                        inStudents.gender = Convert.ToInt16(updateGender);
                        inStudents.classes = updateClasses;
                        inStudents.super = Convert.ToInt16(String.IsNullOrEmpty(updateSuper) ? 0 : 1);

                        if (controllerProvider.instance().doStudent(2, inStudents))
                        {
                            json["code"] = "pass";
                            json["story"] = "更新成功";
                        }
                        else
                        {
                            json["code"] = "error";
                            json["story"] = "更新失败";
                        }
                        break;

                    #endregion

                    #region delStudent

                    case "delStudent":
                        String delCharId = context.Request["charId"];
                        inStudents = new students();
                        inStudents.charId = delCharId;
                        if (controllerProvider.instance().doStudent(3, inStudents))
                        {
                            json["code"] = "pass";
                            json["story"] = "删除成功";
                        }
                        else
                        {
                            json["code"] = "error";
                            json["story"] = "删除失败";
                        }
                        break;

                    #endregion
                }
            }
            if (!json.IsObject)
            {
                json["code"] = "error";
                json["story"] = "Empty";
            }
            context.Response.ContentType = "application/json";
            context.Response.Write(json.ToJson());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}