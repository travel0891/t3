<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student_add.aspx.cs" Inherits="view.student_add" %>

<!doctype html>
<html>
<head>
    <title>学生添加 -
        <%=WebsiteTitle %></title>
    <link href="../../static/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../static/extend.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="formList" class="container-fluid mt30">
        <form class="form-horizontal" action="/" method="post">
        <div class="form-group">
            <label class="col-sm-1  control-label">
                账号</label>
            <div class="col-sm-5">
                <input name="account" type="text" class="form-control" placeholder="必填" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                密码</label>
            <div class="col-sm-5">
                <input name="password" type="password" class="form-control" placeholder="必填" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                学号</label>
            <div class="col-sm-5">
                <input name="number" type="text" class="form-control" placeholder="必填" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                姓名</label>
            <div class="col-sm-5">
                <input name="name" type="text" class="form-control" placeholder="必填" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                性别</label>
            <div class="col-sm-5">
                <select name="gender" class="form-control" placeholder="必选">
                    <option>请选择</option>
                    <option value="1">男</option>
                    <option value="2">女</option>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                班级</label>
            <div class="col-sm-5">
                <input name="classes" type="text" class="form-control" placeholder="必填" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-1 col-sm-5">
                <div class="checkbox">
                    <label>
                        <input name="super" type="checkbox" />设置为管理员
                    </label>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-1 col-sm-5">
                <button type="submit" class="btn btn-primary">
                    提交</button>
            </div>
        </div>
        </form>
    </div>
     <script src="../../static/require.js" data-main="../../static/system" type="text/javascript"></script>
</body>
</html>
