<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="example_action.aspx.cs" Inherits="view.example_action" %>

<!doctype html>
<html>
<head>
    <title>选择题<%=String.IsNullOrEmpty(Request.QueryString["charId"])?"添加":"编辑" %> - <%=WebsiteTitle %></title>
    <link href="../../static/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../static/extend.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .error{color: #d43f3a;}
    </style>
</head>
<body>
    <div id="formList" class="container-fluid mt15">
        <ol class="breadcrumb">
            <li class="c999">当前：试题管理</li><li class="c999">选择题<%=String.IsNullOrEmpty(Request.QueryString["charId"])?"添加":"编辑" %></li>
        </ol>
        <form id="exampleForm" class="form-horizontal">
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
                <input type="radio" name="option" id="optionA" value="A" />
            </label>
            <div class="col-sm-5">
                <input type="text" id="aCountent" class="form-control" maxlength="200" placeholder="必填 A选项"
                    runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                <input type="radio" name="option" id="optionB" value="B" />
            </label>
            <div class="col-sm-5">
                <input type="text" id="bCountent" class="form-control" maxlength="200" placeholder="必填 B选项"
                    runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                <input type="radio" name="option" id="optionC" value="C" />
            </label>
            <div class="col-sm-5">
                <input type="text" id="cCountent" class="form-control" maxlength="200" placeholder="必填 C选项"
                    runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                <input type="radio" name="option" id="optionD" value="D" />
            </label>
            <div class="col-sm-5">
                <input type="text" id="dCountent" class="form-control" maxlength="200" placeholder="必填 D选项"
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
<script src="../../static/jquery/jquery.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () { <%=checkJs %>});
</script>