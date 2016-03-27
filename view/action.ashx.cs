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
                    #region login

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

                    #endregion

                    #region student

                    #region addStudent
                    case "addStudent":

                        String addStudentAccount = context.Request["account"]
                            , addStudentPassword = context.Request["password"]
                            , addStudentNumber = context.Request["number"]
                            , addStudentName = context.Request["name"]
                            , addStudentGender = context.Request["gender"]
                            , addStudentClasses = context.Request["classes"]
                            , addStudentSuper = context.Request["super"];

                        inStudents = new students();
                        inStudents.account = addStudentAccount;
                        inStudents.password = addStudentPassword;
                        inStudents.number = addStudentNumber;
                        inStudents.name = addStudentName;
                        inStudents.gender = Convert.ToInt16(addStudentGender);
                        inStudents.classes = addStudentClasses;
                        inStudents.super = Convert.ToInt16(String.IsNullOrEmpty(addStudentSuper) ? 0 : 1);

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
                        String updateStudentAccount = context.Request["account"]
                            , updateStudentPassword = context.Request["password"]
                            , updateStudentNumber = context.Request["number"]
                            , updateStudentName = context.Request["name"]
                            , updateStudentGender = context.Request["gender"]
                            , updateStudentClasses = context.Request["classes"]
                            , updateStudentSuper = context.Request["super"]
                            , updateStudentCharId = context.Request["charId"];

                        inStudents = new students();
                        inStudents.charId = updateStudentCharId;
                        inStudents.account = updateStudentAccount;
                        inStudents.password = updateStudentPassword;
                        inStudents.number = updateStudentNumber;
                        inStudents.name = updateStudentName;
                        inStudents.gender = Convert.ToInt16(updateStudentGender);
                        inStudents.classes = updateStudentClasses;
                        inStudents.super = Convert.ToInt16(String.IsNullOrEmpty(updateStudentSuper) ? 0 : 1);

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
                        String delStudentCharId = context.Request["charId"];
                        inStudents = new students();
                        inStudents.charId = delStudentCharId;
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

                    #endregion

                    #region course

                    #region addCourse
                    case "addCourse":

                        String addCourseNumber = context.Request["number"]
                            , addCourseTitle = context.Request["title"]
                            , addCourseContents = context.Request["hiContents"];

                        courses inCourse = new courses();
                        inCourse.number = addCourseNumber;
                        inCourse.title = addCourseTitle;
                        inCourse.contents = addCourseContents;

                        if (controllerProvider.instance().doCourses(1, inCourse))
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

                    #region updateCourse
                    case "updateCourse":

                        String updateCourseNumber = context.Request["number"]
                            , updateCourseTitle = context.Request["title"]
                            , updateCourseContents = context.Request["hiContents"]
                            , updateCourseCharId = context.Request["charId"];

                        inCourse = new courses();
                        inCourse.charId = updateCourseCharId;
                        inCourse.number = updateCourseNumber;
                        inCourse.title = updateCourseTitle;
                        inCourse.contents = updateCourseContents;
                        inCourse.updateTime = DateTime.Now;

                        if (controllerProvider.instance().doCourses(2, inCourse))
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

                    #region delCourse

                    case "delCourse":
                        String delCourseCharId = context.Request["charId"];
                        inCourse = new courses();
                        inCourse.charId = delCourseCharId;
                        if (controllerProvider.instance().doCourses(3, inCourse))
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

                    #endregion

                    #region document

                    #region addDocument

                    case "addDocument":
                        documents inDocuments = new documents();

                        String addDocumentNumber = context.Request["number"]
                            , addDocumentTitle = context.Request["title"]
                            , tempFile = "documentFile"
                            , tempName = addDocumentTitle + "." + Guid.NewGuid().ToString();

                        HttpPostedFile postFile = context.Request.Files["url"];
                        if (postFile.ContentLength > 0)
                        {
                            inDocuments.number = addDocumentNumber;
                            inDocuments.title = addDocumentTitle;
                            inDocuments.type = postFile.FileName.Substring(postFile.FileName.LastIndexOf(".") + 1).ToLower();
                            inDocuments.size = postFile.ContentLength;
                            inDocuments.url = tempFile + "/" + tempName + "." + inDocuments.type;

                            try
                            {
                                postFile.SaveAs(context.Server.MapPath(inDocuments.url));
                                if (controllerProvider.instance().doDocuments(1, inDocuments))
                                {
                                    json["code"] = "pass";
                                    json["story"] = "保存成功";
                                }
                                else
                                {
                                    json["code"] = "error";
                                    json["story"] = "保存失败";
                                }
                            }
                            catch (Exception ex)
                            {
                                json["code"] = "error";
                                json["story"] = "上传文档错误，" + ex.Message;
                            }
                        }
                        else
                        {
                            json["code"] = "error";
                            json["story"] = "文档不能为空";
                        }

                        break;

                    #endregion

                    #region updateDocument

                    case "updateDocument":
                        String updateDocumentNumber = context.Request["number"]
                           , updateDocumentTitle = context.Request["title"]
                           , updateHiTitle = context.Request["hiTitle"]
                           , updateHiUrl = context.Request["hiUrl"]
                           , tempName1 = updateDocumentTitle + "." + Guid.NewGuid().ToString()
                           , updateDocumentCharId = context.Request["charId"];

                        inDocuments = new documents();
                        inDocuments.number = updateDocumentNumber;
                        inDocuments.title = updateDocumentTitle;
                        inDocuments.url = updateHiUrl.Replace(updateHiTitle, inDocuments.title);
                        inDocuments.charId = updateDocumentCharId;

                        if (controllerProvider.instance().doDocuments(2, inDocuments))
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

                    #region delDocument

                    case "delDocument":
                        String delDocumentCharId = context.Request["charId"];
                        inDocuments = new documents();
                        inDocuments.charId = delDocumentCharId;
                        if (controllerProvider.instance().doDocuments(3, inDocuments))
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