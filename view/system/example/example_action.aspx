<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="example_action.aspx.cs" Inherits="view.example_action" %>

<!doctype html>
<html>
<head>
    <title>习题<%=String.IsNullOrEmpty(Request.QueryString["charId"])?"添加":"编辑" %>-<%=WebsiteTitle %></title>
    <link href="../../static/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../static/extend.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .error{color: #d43f3a;}
    </style>
</head>
<body>
    <div id="formList" class="container-fluid mt15">
        <ol class="breadcrumb">
            <li class="c999">当前：习题管理</li><li class="c999">习题<%=String.IsNullOrEmpty(Request.QueryString["charId"])?"添加":"编辑" %></li>
        </ol>
        <form id="exampleForm" class="form-horizontal" onsubmit="return false;">
        <div class="form-group">
            <label class="col-sm-1  control-label">
                编号</label>
            <div class="col-sm-2">
                <input type="text" id="number" class="form-control" maxlength="6" placeholder="必填"
                    runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                题目</label>
            <div class="col-sm-10">
                <input type="text" id="example" class="form-control" maxlength="200" placeholder="必填"
                    runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                <input type="radio" name="ra" />
            </label>
            <div class="col-sm-5">
                <input type="text" id="optionA" class="form-control" maxlength="20" placeholder="必填 A选项"
                    runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                <input type="radio" name="ra" />
            </label>
            <div class="col-sm-5">
                <input type="text" id="optionB" class="form-control" maxlength="20" placeholder="必填 B选项"
                    runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                <input type="radio" name="ra" />
            </label>
            <div class="col-sm-5">
                <input type="text" id="Text1" class="form-control" maxlength="20" placeholder="必填 C选项"
                    runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                <input type="radio" name="ra" />
            </label>
            <div class="col-sm-5">
                <input type="text" id="Text2" class="form-control" maxlength="20" placeholder="必填 D选项"
                    runat="server" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-1 col-sm-5">
                <button type="submit" id="exampleSubmit" class="btn btn-primary">
                    <%=String.IsNullOrEmpty(Request.QueryString["charId"])?"保存":"更新" %></button>
                <%=String.IsNullOrEmpty(Request.QueryString["charId"])?null:"<button type=\"button\" onclick=\"javascript:history.go(-1);\" class=\"btn btn-default\">取消编辑</button>" %>
            </div>
        </div>
        <input type="hidden" name="charId" value="<%=Request.QueryString["charId"]%>" />
        </form>
        <input type="hidden" id="postType" value="<%=String.IsNullOrEmpty(Request.QueryString["charId"])?"addExample":"updateExample" %>" />
    </div>
    <script src="../../static/require.js" data-main="../../static/system" type="text/javascript"></script>
</body>
</html>
