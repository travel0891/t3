<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="document_action.aspx.cs" Inherits="view.document_action" %>

<!doctype html>
<html>
<head>
    <title>文档<%=String.IsNullOrEmpty(Request.QueryString["charId"])?"添加":"编辑" %> - <%=WebsiteTitle %></title>
    <link href="../../static/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../static/extend.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .error{color: #d43f3a;}
    </style>
</head>
<body>
    <div id="formList" class="container-fluid mt15">
        <ol class="breadcrumb">
            <li class="c999">当前：文档管理</li><li class="c999">文档<%=String.IsNullOrEmpty(Request.QueryString["charId"])?"添加":"编辑" %></li>
        </ol>
        <form id="documentForm" class="form-horizontal" method="post" enctype="multipart/form-data">
         <div class="form-group">
            <label class="col-sm-1  control-label">
                类型</label>
            <div class="col-sm-2" id="configList" runat="server">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1  control-label">
                章节</label>
            <div class="col-sm-2" id="parmList" runat="server">
                <span class="form-control">请先选择类型</span>
            </div>
        </div>
        <div class="form-group" style="display:none">
            <label class="col-sm-1  control-label">编号</label>
            <div class="col-sm-2">
                <input type="text" id="number" class="form-control" maxlength="6" placeholder="必填"
                    runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">名称</label>
            <div class="col-sm-5">
                <input type="text" id="title" class="form-control" maxlength="25" placeholder="必填" runat="server" />
            </div>
        </div>
         <%if (!String.IsNullOrEmpty(Request.QueryString["charId"])){%>
         <div class="form-group">
            <label class="col-sm-1 control-label">原文件</label>
            <div class="col-sm-2">
                <%= fileA %>
            </div>
        </div>
        <%}%>
        <div class="form-group">
            <label class="col-sm-1 control-label">
                文档</label> <!-- url -->
            <div class="col-sm-5">
                <input type="file" id="url" name="url" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-1 col-sm-5">
                <button type="submit" id="documentSubmit" class="btn btn-primary">
                    <%=String.IsNullOrEmpty(Request.QueryString["charId"])?"保存":"更新" %></button>
                <%=String.IsNullOrEmpty(Request.QueryString["charId"])?null:"<button type=\"button\" onclick=\"javascript:history.go(-1);\" class=\"btn btn-default\">取消编辑</button>" %>
            </div>
        </div>
        <input type="hidden" id="charId" value="<%=Request.QueryString["charId"]%>" />
        <input type="hidden" id="size" runat="server" />
        </form>
        <input type="hidden" id="postType" value="<%=String.IsNullOrEmpty(Request.QueryString["charId"])?"addDocument":"updateDocument" %>" />
    </div>
    <script src="../../static/require.js" data-main="../../static/system" type="text/javascript"></script>
</body>
</html>