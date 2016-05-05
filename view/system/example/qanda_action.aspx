<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qanda_action.aspx.cs" Inherits="view.qanda_action" %>

<!doctype html>
<html>
<head>
    <title>问答题<%=String.IsNullOrEmpty(Request.QueryString["charId"])?"添加":"编辑" %> - <%=WebsiteTitle %></title>
    <link href="../../static/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../static/extend.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .error{color: #d43f3a;}
    </style>
</head>
<body>
    <div id="formList" class="container-fluid mt15">
        <ol class="breadcrumb">
            <li class="c999">当前：试题管理</li><li class="c999">问答题<%=String.IsNullOrEmpty(Request.QueryString["charId"])?"添加":"编辑" %></li>
        </ol>
        <form id="qandaForm" class="form-horizontal">

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
                <input type="text" id="qanda" class="form-control" maxlength="200" placeholder="必填"
                    runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-1 control-label">
               答案</label>
            <div class="col-sm-10">
                <textarea class="form-control" id="contents" name="contents" style="width: 100%;height: 300px; visibility: hidden;"></textarea>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-1 col-sm-5">
                <button type="submit" id="qandaSubmit" class="btn btn-primary" onclick="javascript:document.getElementById('hiContents').value = editor.html();">
                <%=String.IsNullOrEmpty(Request.QueryString["charId"])?"保存":"更新" %></button>
                <%=String.IsNullOrEmpty(Request.QueryString["charId"])?null:"<button type=\"button\" onclick=\"javascript:history.go(-1);\" class=\"btn btn-default\">取消编辑</button>" %>
            </div>
        </div>
        <input type="hidden" name="charId" value="<%=Request.QueryString["charId"]%>" />
        <input type="hidden" id="hiContents" runat="server" />
        </form>
        <input type="hidden" id="postType" value="<%=String.IsNullOrEmpty(Request.QueryString["charId"])?"addQanda":"updateQanda" %>" />
    </div>
    <script src="../../static/require.js" data-main="../../static/system" type="text/javascript"></script>
</body>
</html>
<script src="../../static/jquery/jquery.min.js" type="text/javascript"></script>
<script src="../../static/kindeditor/kindeditor-min.js" type="text/javascript"></script>
<script src="../../static/kindeditor/lang/zh_CN.js" type="text/javascript"></script>

<script type="text/javascript">

    var editor;

    KindEditor.ready(function (K) {
        editor = K.create("#contents", {
            resizeType: 1,
            allowPreviewEmoticons: false,
            allowImageUpload: true,
            newlineTag: "br",
            items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'image', 'flash', 'link', '|', 'wordpaste', 'clearhtml', 'table', '|', 'source', 'preview', 'fullscreen']
        });
        editor.html(document.getElementById("hiContents").value);
    });

</script>
