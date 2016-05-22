<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="linetest.aspx.cs" Inherits="view.linetest" %>

<!doctype html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>首页 -
        <%=WebsiteTitle %></title>
    <link href="static/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .mt8 {margin-top: 8px;}
        .w360{ width:366px; min-height:412px;}
        .fll{ float:left;}
        .ml20{ margin-left:20px;}
        label{ color:#666; font-weight:normal;}
        .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th{ line-height:200%;}
    </style>
</head>
<body>
    <div class="container">
        <div class="navbar navbar-default">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-collapse-1">
                        <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span
                            class="icon-bar"></span><span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="javascript:;">
                        <%=WebsiteTitle %></a>
                </div>
                <div class="collapse navbar-collapse" id="navbar-collapse-1">
                    <ul class="nav navbar-nav">
                        <li><a href="index.aspx">首页</a></li>
                        <li><a href="courseList.aspx">课件学习</a></li>
                        <li><a href="documentList.aspx">文档下载</a></li>
                        <li><a href="exampleqandaList.aspx">习题练习</a></li>
                        <li class="active"><a href="javascript:;">自我测评</a></li>
                        <li ><a href="message.aspx">在线提问</a></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li>
                            <%if (Session["tempUser"] != null){
                                  %>
                                  <a href="javascript:doExit();">当前登录：<%=getUserInfo(Session["tempUser"].ToString()) %></a>
                                  <%
                              }else{%>
                              <button onclick="javascript:doRegister();" class="btn btn-success mt8">学生注册</button>
                              <button onclick="javascript:doSignin();" class="btn btn-info mt8">学生登录</button>
                            <%} %>
                        </li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="panel panel-default" style="margin-top: 20px">
            <div class="panel-heading">自我测评<span style="float:right">共 <%=tempCount %> 条记录</span></div>
            <form id="postForm">
            <%=sbHTML1 %>
            <div style="text-align:center; margin:20px;">
             <button type="button" id="vtest" onclick="javascript:doPost();" class="btn btn-warning btn-lg btn-block">提交答案并评分</button>
            </div>
            <input type="hidden" id="hiValidateTest" runat="server" />
            <input type="hidden" id="hiCounts" value="<%=tempCount %>" />
            </form>
        </div>

        <div class="text-center" style="color: #999; margin-top: 20px; min-height: 60px; clear:both;
            background-color: #f9f9f9; padding: 20px 0; border-top: 1px solid #e7e7e7;">
            © 2016 <%=WebsiteTitle %>
            <a href="system/login.aspx">后台管理</a>
        </div>
    </div>
</body>
</html>
<script src="static/jquery/jquery.min.js" type="text/javascript"></script>
<script type="text/javascript">
    var doSignin = function () {
        window.location.href = "/signin.aspx?from=linetest";
    };

    var doRegister = function () {
        window.location.href = "/register.aspx?from=linetest";
    };

    var doExit = function () {
        if (confirm("是否注销当前账号？")) {
            window.location.href = "/index.aspx?timeout=true";
        }
    };

    var doPost = function () {
        var tempCounts = $("#hiCounts").val();
        var tempPass = 0;
        var words1 = $("#postForm").serialize().split('&');
        var words2 = $("#hiValidateTest").val().split('&');
        if (words1.length == (parseInt(tempCounts) + 1)) {
            for (var i = 0; i < words1.length; i++) {
                if (words1[i] == words2[i]) {
                    tempPass++;
                }
            }
            $("#vtest").html("当前正确率为：" + parseInt((tempPass / tempCounts) * 100) + "%");
        }
        else {
            alert("请完成所有题目后再提交");
        }
    };
</script>