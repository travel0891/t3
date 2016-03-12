<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="view.manage.login" %>

<!doctype html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>管理员登录 - <%=WebsiteTitle %></title>
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
            <p><%=WebsiteTitle %></p>
        </div>
        <div class="content">
        <form id="tempForm" onsubmit="return false">
            <div class="input-group form-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                <input type="text" name="name" id="nameInput" class="form-control" placeholder="请输入账号" maxlength="8" value="<%=name %>" />
            </div>
            <div class="input-group form-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
                <input type="password" name="password" id="passwordInput" class="form-control" placeholder="请输入密码" maxlength="12" value="<%=password %>" />
            </div>
            <div class="form-group">
                <div class="checkbox">
                    <label class="color999"><input type="checkbox" name="keepLine" <%=keep %> />记住账号密码</label>
                </div>
            </div>
            <div class="form-group">
                <span id="promptId"></span>
                <button type="submit" class="btn btn-info btn-block">登 录</button>
            </div>
        </form>
        </div>
        <div class="footer text-center color999">
            © 2016 <%=WebsiteTitle %>
        </div>
    </div>
    <script src="../static/require.js" data-main="../static/main" type="text/javascript"></script>
</body>
</html>