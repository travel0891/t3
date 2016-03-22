<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="course_action.aspx.cs" Inherits="view.system.course_action" %>

<!doctype html>
<html>
<head>
    <title>课件<%=String.IsNullOrEmpty(Request.QueryString["charId"])?"添加":"编辑" %> -<%=WebsiteTitle %></title>
    <link href="../../static/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../static/extend.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .error{color:#d43f3a;}
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
