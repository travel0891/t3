using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Web.SessionState;

using LitJson;

namespace view
{
    using controller;
    using model;

    public class action : IHttpHandler,IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            String type = context.Request.QueryString["type"];
            JsonData json = new JsonData();

            if (!String.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "login":
                        #region login

                        String inName = context.Request["name"]
                            , inPassword = context.Request["password"]
                            , inKeep = context.Request["keepLine"];

                        if (String.IsNullOrEmpty(inName) || String.IsNullOrEmpty(inPassword) || inKeep == null)
                        {
                            break;
                        }

                        userid inUser = new userid();
                        inUser.name = inName;
                        inUser.password = inPassword;
                        inUser.super = 1;
                        inUser.status = 0;

                        c_userid cUser = new c_userid();
                        userid outUser = cUser.selectUser(inUser);

                        if (outUser.intId == 0)
                        {
                            json["code"] = "error";
                            json["story"] = "登录验证失败";
                        }
                        else
                        {
                            if (inKeep == "on")
                            {
                                HttpCookie cookies = new HttpCookie("keepLine");
                                cookies["name"] = context.Server.HtmlEncode(outUser.name);
                                cookies["password"] = context.Server.HtmlEncode(outUser.password);
                                cookies.Expires = DateTime.Now.AddYears(1);
                                context.Response.Cookies.Add(cookies);
                            }
                            else
                            {
                                HttpCookie cookies = context.Request.Cookies.Get("keepLine");
                                if (cookies != null)
                                {
                                    cookies.Values.Remove("name");
                                    cookies.Values.Remove("password");
                                    context.Response.Cookies.Add(cookies);
                                }
                            }
                            json["code"] = "pass";
                            json["story"] = "登录验证通过";
                        }
                        #endregion
                        break;
                    default:
                        break;
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