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