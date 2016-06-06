<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="view.register" %>

<!doctype html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>学生注册 - <%=WebsiteTitle %></title>
    <link rel="stylesheet" href="../static/bootstrap/css/bootstrap.min.css?v=20160220" />
    <style type="text/css">
        body
        {
            background-color: #f6f6f6;
        }
        .t_form
        {
            width: 96%;
            min-width: 320px;
            max-width: 400px;
            margin: 6% auto;
        }
        .t_form .header
        {
            margin-bottom: 30px;
            height: 54px;
            line-height: 54px;
        }
        .t_form .header p
        {
            font-size: 22px;
            color: #333;
        }
        .t_form .content
        {
            border: 1px solid #ececec;
            padding: 40px 40px 25px 40px;
            height: auto;
            background-color: #fff;
            box-shadow: 0 0 3px #eee, 0 0 3px #fff inset;
        }
        .t_form .content .tool
        {
            font-size: 12px;
            margin-top: 15px;
        }
        .color999
        {
            color: #999;
        }
        .t_form .footer
        {
            margin-top: 40px;
        }
        .right
        {
            float: right;
        }

        #promptId .error ,.ajaxError{ font-size:12px;font-weight:normal; color:#d43f3a; padding-right:8px; line-height:200%; margin-bottom:15px; }
        .error{color:#d43f3a;}
    </style>
</head>
<body>
    <div class="t_form">
        <div class="header text-center">
            <p>学生注册</p>
        </div>
        <div class="content">
            <form id="registerForm">
            <div class="input-group form-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-user color999"></span>
                </span>
                <input type="text" name="account" class="form-control" placeholder="请输入账号"
                    maxlength="8" />
            </div>
            <div class="input-group form-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-lock color999"></span>
                </span>
                <input type="password" name="password" id="password" class="form-control" placeholder="请输入密码"
                    maxlength="12" />
            </div>
            <div class="input-group form-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-lock color999"></span>
                </span>
                <input type="password" name="confirm_password" class="form-control"
                    placeholder="请确认密码" maxlength="12" />
            </div>
            <div class="input-group form-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-education color999">
                </span></span>
                <input type="text" name="number" class="form-control" placeholder="请输入学号，只限10位数字" maxlength="10" onkeyup="this.value=this.value.replace(/\D/g,'')"  onafterpaste="this.value=this.value.replace(/\D/g,'')" />
            </div>
            <div class="input-group form-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-home color999"></span>
                </span>
                <input type="text" name="name" class="form-control" placeholder="请输入姓名" />
            </div>
            <div class="form-group">
                <select name="gender" class="form-control">
                    <option value="">请选择性别</option>
                    <option value="1">男</option>
                    <option value="2">女</option>
                </select>
            </div>
            <div class="form-group" id="clsList" runat="server">
            </div>
            <div class="form-group">
                <span id="promptId"></span>
                <button id="doRegister" type="submit" class="btn btn-info btn-block">确认注册</button>
            </div>
            </form>
        </div>
        <div class="footer text-center color999">
            © 2016 <%=WebsiteTitle %> <a href="/index.aspx">返回首页</a> <a href="signin.aspx">返回登录</a>
        </div>
    </div>
    <script src="../static/require.js" data-main="../static/main" type="text/javascript"></script>
</body>
</html>