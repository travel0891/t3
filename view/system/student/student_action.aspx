<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student_action.aspx.cs" Inherits="view.student_action" %>

<!doctype html>
<html>
<head>
    <title>学生<%=String.IsNullOrEmpty(Request.QueryString["charId"])?"添加":"编辑" %> - <%=WebsiteTitle %></title>
    <link href="../../static/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../static/extend.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .error{color:#d43f3a;}
    </style>

</head>
<body>
    <div id="formList" class="container-fluid mt15">
      <ol class="breadcrumb">
            <li class="c999">当前：用户管理</li><li class="c999">学生<%=String.IsNullOrEmpty(Request.QueryString["charId"])?"添加":"编辑" %></li>
        </ol>
        <form id="studentForm" class="form-horizontal">
        <div class="form-group">
            <label class="col-sm-1  control-label">账号</label>
            <div class="col-sm-5">
                <input type="text" id="account" class="form-control" maxlength="8" placeholder="必填" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                密码</label>
            <div class="col-sm-5">
                <input type="password" id="password" name="password" class="form-control" maxlength="12" placeholder="必填" value="<%=passwordInput %>" />
            </div>
        </div>
         <div class="form-group">
            <label class="col-sm-1 control-label">
                确认密码</label>
            <div class="col-sm-5">
                <input type="password" id="confirm_password" name="confirm_password" class="form-control" maxlength="12" placeholder="必填" value="<%=passwordInput %>" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                学号</label>
            <div class="col-sm-5">
                <input type="text" id="number" class="form-control" placeholder="必填，只限10位数字" runat="server" maxlength="10" onkeyup="this.value=this.value.replace(/\D/g,'')"  onafterpaste="this.value=this.value.replace(/\D/g,'')" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                姓名</label>
            <div class="col-sm-5">
                <input type="text" id="name" class="form-control" placeholder="必填" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                性别</label>
            <div class="col-sm-5">
                <select name="gender" class="form-control" placeholder="必选">
                    <%=String.IsNullOrEmpty(Request.QueryString["charId"])?"<option value=\"\">请选择</option>":null %>
                    <option value="1" <%=genderSelect %>>男</option>
                    <option value="2" <%=genderSelect %>>女</option>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                班级</label>
            <div class="col-sm-5" id="clsList" runat="server"></div>
        </div>
        <div class="form-group" style="display:none">
            <div class="col-sm-offset-1 col-sm-5">
                <div class="checkbox">
                    <label>
                        <input name="super" type="checkbox" <%=superCheckbox %> />设置为管理员
                    </label>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-1 col-sm-5">
                <button type="submit" id="studentSubmit" class="btn btn-primary"><%=String.IsNullOrEmpty(Request.QueryString["charId"])?"保存":"更新" %></button>
                <%=String.IsNullOrEmpty(Request.QueryString["charId"])?null:"<button type=\"button\" onclick=\"javascript:history.go(-1);\" class=\"btn btn-default\">取消编辑</button>" %>
            </div>
        </div>
        <input type="hidden" name="charId" value="<%=Request.QueryString["charId"]%>" />
        </form>
        <input type="hidden" id="postType" value="<%=String.IsNullOrEmpty(Request.QueryString["charId"])?"addStudent":"updateStudent" %>" />
    </div>
     <script src="../../static/require.js" data-main="../../static/system" type="text/javascript"></script>
</body>
</html>