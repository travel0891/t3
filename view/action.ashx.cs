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

                    #region existsStuAccount
                    case "existsStuAccount":
                        students tempStudents1 = new students();
                        tempStudents1.account = context.Request["account"];
                        tempStudents1.super = 0;
                        tempStudents1.status = 0;

                        Boolean tempOutStudents1 = controllerProvider.instance().selectAccount(tempStudents1);
                        if (tempOutStudents1)
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

                    #region doSignin
                    case "doSignin":
                        String sAccount = context.Request["account"]
                            , sPassword = context.Request["password"]
                            , sKeep = context.Request["keepLineStu"];

                        if (String.IsNullOrEmpty(sAccount) || String.IsNullOrEmpty(sPassword))
                        {
                            break;
                        }

                        students sStudents = new students();
                        sStudents.account = sAccount;
                        sStudents.password = sPassword;
                        sStudents.super = 0;
                        sStudents.status = 0;

                        students studentString = controllerProvider.instance().selectStudents(sStudents);

                        if (studentString == null)
                        {
                            json["code"] = "error";
                            json["story"] = "登录验证失败";
                        }
                        else
                        {
                            if (sKeep == "on")
                            {
                                HttpCookie cookies = new HttpCookie("keepLineStu");
                                cookies["account"] = context.Server.HtmlEncode(sStudents.account);
                                cookies["password"] = context.Server.HtmlEncode(sStudents.password);
                                cookies.Expires = DateTime.Now.AddYears(1);
                                context.Response.Cookies.Add(cookies);
                            }
                            else
                            {
                                HttpCookie cookies = context.Request.Cookies.Get("keepLineStu");
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
                        inStudents.classes = addStudentClasses;
                        inStudents.super = Convert.ToInt16(String.IsNullOrEmpty(addStudentSuper) ? 0 : 1);

                        if (inStudents.super == 1)
                        {
                            inStudents.gender = 0;
                        }
                        else
                        {
                            inStudents.gender = Convert.ToInt16(addStudentGender);
                        }

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

                        if (inStudents.super == 1)
                        {
                            inStudents.gender = 0;
                        }

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
                            , addCourseContents = context.Request["hiContents"]
                        , addCourseConfigsCharId = context.Request["ConfigsCharId"]
                        , addCourseParmsCharId = context.Request["parmsCharId"];

                        courses inCourse = new courses();
                        inCourse.configs_charId = addCourseConfigsCharId;
                        inCourse.parms_charId = addCourseParmsCharId;
                        inCourse.title = addCourseTitle;
                        inCourse.contents = addCourseContents;
                       
                        String[] tempCourse = { "configs", addCourseConfigsCharId, "parms", addCourseParmsCharId, "courses"};
                        inCourse.number = controllerProvider.instance().maxNumber(tempCourse);

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
                              , updateCourseConfigsCharId = context.Request["ConfigsCharId"]
                        , updateCourseParmsCharId = context.Request["parmsCharId"]
                            , updateCourseCharId = context.Request["charId"];

                        inCourse = new courses();
                        inCourse.charId = updateCourseCharId;
                        inCourse.configs_charId = updateCourseConfigsCharId;
                        inCourse.parms_charId = updateCourseParmsCharId;
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
                            , tempName = Guid.NewGuid().ToString()
                            , addDocumentConfigsCharId = context.Request["ConfigsCharId"]
                            , addDocumentParmsCharId = context.Request["parmsCharId"];

                        HttpPostedFile postFile = context.Request.Files["url"];
                        if (postFile.ContentLength > 0)
                        {
                            inDocuments.configs_charId = addDocumentConfigsCharId;
                            inDocuments.parms_charId = addDocumentParmsCharId;
                            inDocuments.title = addDocumentTitle;
                            inDocuments.type = postFile.FileName.Substring(postFile.FileName.LastIndexOf(".") + 1).ToLower();
                            inDocuments.size = postFile.ContentLength;
                            inDocuments.url = tempFile + "/" + tempName + "." + inDocuments.type;

                            String[] tempDocument = { "configs", addDocumentConfigsCharId, "parms", addDocumentParmsCharId, "documents"};
                            inDocuments.number = controllerProvider.instance().maxNumber(tempDocument);

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
                           , updateHiSize = context.Request["size"]
                           , updateDocumentCharId = context.Request["charId"]
                           , updateDocumentConfigsCharId = context.Request["ConfigsCharId"]
                           , updateDocumentParmsCharId = context.Request["parmsCharId"];

                        inDocuments = new documents();
                        inDocuments.configs_charId = updateDocumentConfigsCharId;
                        inDocuments.parms_charId = updateDocumentParmsCharId;
                        inDocuments.number = updateDocumentNumber;
                        inDocuments.title = updateDocumentTitle;
                        inDocuments.size = Convert.ToInt32(updateHiSize);
                        inDocuments.charId = updateDocumentCharId;

                        HttpPostedFile updatePostFile = context.Request.Files["url"];

                        if (updatePostFile != null && updatePostFile.ContentLength > 0)
                        {
                            inDocuments.type = updatePostFile.FileName.Substring(updatePostFile.FileName.LastIndexOf(".") + 1).ToLower();
                            inDocuments.size = updatePostFile.ContentLength;
                            inDocuments.url = "documentFile/" + Guid.NewGuid().ToString() + "." + inDocuments.type;

                            try
                            {
                                updatePostFile.SaveAs(context.Server.MapPath(inDocuments.url));
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
                            }
                            catch (Exception ex)
                            {
                                json["code"] = "error";
                                json["story"] = "上传文档错误，" + ex.Message;
                            }
                        }
                        else
                        {
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

                    #region example

                    #region addExample

                    case "addExample":

                        String addExampleNumber = context.Request["number"]
                            , addExampleExample = context.Request["example"]
                            , addExampleOption = context.Request["option"]
                            , addExampleACountent = context.Request["aCountent"]
                            , addExampleBCountent = context.Request["bCountent"]
                            , addExampleCCountent = context.Request["cCountent"]
                            , addExampleDCountent = context.Request["dCountent"]
                            , addExampleConfigsCharId = context.Request["ConfigsCharId"]
                            , addExampleParmsCharId = context.Request["parmsCharId"];

                        examples inExamples = new examples();
                        inExamples.number = addExampleNumber;
                        // inExamples.example = addExampleExample;
                        inExamples.optionA = 0;
                        inExamples.optionB = 0;
                        inExamples.optionC = 0;
                        inExamples.optionD = 0;

                        switch (addExampleOption)
                        {
                            case "A":
                                inExamples.optionA = 1;
                                break;
                            case "B":
                                inExamples.optionB = 1;
                                break;
                            case "C":
                                inExamples.optionC = 1;
                                break;
                            case "D":
                                inExamples.optionD = 1;
                                break;
                        }

                        inExamples.aCountent = addExampleACountent;
                        inExamples.bCountent = addExampleBCountent;
                        inExamples.cCountent = addExampleCCountent;
                        inExamples.dCountent = addExampleDCountent;

                        String[] tempExample = { "configs", addExampleConfigsCharId, "parms", addExampleParmsCharId, "examples" };
                        inExamples.number = controllerProvider.instance().maxNumber(tempExample);

                        if (controllerProvider.instance().doExamples(1, inExamples))
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

                    #region updateExample

                    case "updateExample":

                        String updateExampleNumber = context.Request["number"]
                            , updateExampleExample = context.Request["example"]
                            , updateExampleOption = context.Request["option"]
                            , updateExampleACountent = context.Request["aCountent"]
                            , updateExampleBCountent = context.Request["bCountent"]
                            , updateExampleCCountent = context.Request["cCountent"]
                            , updateExampleDCountent = context.Request["dCountent"]
                            , updateExampleCharId = context.Request["charId"]
                            , updateExampleConfigsCharId = context.Request["ConfigsCharId"]
                            , updateExampleParmsCharId = context.Request["parmsCharId"];

                        inExamples = new examples();
                        inExamples.charId = updateExampleCharId;
                        inExamples.number = updateExampleNumber;
                        inExamples.example = updateExampleExample;
                        inExamples.optionA = 0;
                        inExamples.optionB = 0;
                        inExamples.optionC = 0;
                        inExamples.optionD = 0;

                        switch (updateExampleOption)
                        {
                            case "A":
                                inExamples.optionA = 1;
                                break;
                            case "B":
                                inExamples.optionB = 1;
                                break;
                            case "C":
                                inExamples.optionC = 1;
                                break;
                            case "D":
                                inExamples.optionD = 1;
                                break;
                        }

                        inExamples.aCountent = updateExampleACountent;
                        inExamples.bCountent = updateExampleBCountent;
                        inExamples.cCountent = updateExampleCCountent;
                        inExamples.dCountent = updateExampleDCountent;

                        if (controllerProvider.instance().doExamples(2, inExamples))
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

                    #region delExample

                    case "delExample":
                        String delExampleCharId = context.Request["charId"];
                        inExamples = new examples();
                        inExamples.charId = delExampleCharId;
                        if (controllerProvider.instance().doExamples(3, inExamples))
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

                    #region class

                    case "delClass":
                        String delClassCharId = context.Request["charId"];
                        classes inClasses = new classes();
                        inClasses.charId = delClassCharId;
                        if (controllerProvider.instance().doClasses(3, inClasses))
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

                    #region config parm

                    case "getParmByConfigCharId":
                        StringBuilder sbSelect = new StringBuilder();
                        String selectSelected = String.Empty;
                        Object[] whereObj = { "and", "configs_charId", "=", String.IsNullOrEmpty(context.Request["configCharId"]) ? Guid.NewGuid().ToString() : context.Request["configCharId"] };
                        List<parms> listModel = controllerProvider.instance().selectParms(whereObj);

                        if (listModel.Count == 0)
                        {
                            json["code"] = "error";
                            json["story"] = "该类型还未设置章节";
                        }
                        else
                        {
                            sbSelect.AppendFormat("<select id=\"{0}\" name=\"{0}\" class=\"{1}\" placeholder=\"{2}\">", "parmsCharId", "form-control", "必选");
                            // sbSelect.Append("<option value=\"\">请选择</option>");
                            foreach (parms item in listModel)
                            {
                                sbSelect.AppendFormat("<option {0} ", selectSelected == item.charId ? "selected=\"selected\"" : null);
                                sbSelect.AppendFormat("value=\"{0}\">{1}", item.charId, item.chapter);
                                sbSelect.Append("</option>");
                            }
                            sbSelect.Append("<select>");
                            json["code"] = "pass";
                            json["story"] = sbSelect.ToString();
                        }
                        break;

                    case "delConfig":
                        String delConfigId = context.Request["charId"];
                        configs inConfigs = new configs();
                        inConfigs.charId = delConfigId;
                        if (controllerProvider.instance().doConfig(3, inConfigs))
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
                    case "delParm":
                        String delParmId = context.Request["charId"];
                        parms inParms = new parms();
                        inParms.charId = delParmId;
                        if (controllerProvider.instance().doParm(3, inParms))
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