﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="view.index" %>

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
        .w360{ width:366px; min-height:264px;}
        .fll{ float:left;}
        .ml20{ margin-left:20px;}
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
                        <li class="active"><a href="javascript:;">首页</a></li>
                        <li><a href="courseList.aspx">课件学习</a></li>
                        <li><a href="documentList.aspx">文档下载</a></li>
                        <li><a href="exampleqandaList.aspx">习题练习</a></li>
                        <li><a href="linetest.aspx">自我测评</a></li>
                        <li><a href="message.aspx">在线提问</a></li>
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

        <div data-ride="carousel" class="carousel slide" id="carousel-example-captions">
            <div role="listbox" class="carousel-inner">
                <div class="item">
                    <img alt="page3" src="static/image/temp03.jpg" data-holder-rendered="true" />
                </div>
                <div class="item active">
                    <img alt="page1" src="static/image/temp01.jpg" data-holder-rendered="true" />
                </div>
                <div class="item">
                    <img alt="page2" src="static/image/temp02.jpg" data-holder-rendered="true" />
                </div>
            </div>
            <a data-slide="prev" role="button" href="#carousel-example-captions" class="left carousel-control">
                <span class="glyphicon glyphicon-chevron-left"></span><span class="sr-only">Previous</span>
            </a><a data-slide="next" role="button" href="#carousel-example-captions" class="right carousel-control">
                <span class="glyphicon glyphicon-chevron-right"></span><span class="sr-only">Next</span></a>
        </div>

        <div class="panel panel-default w360 fll" style="margin-top: 20px">
            <div class="panel-heading">最新课件<a style="float:right" title="更多课件" href="courseList.aspx">更多<span class="caret"></span></a></div>
            <%=sbHTML1 %>
        </div>

        <div class="panel panel-default w360 fll ml20" style="margin-top: 20px">
            <div class="panel-heading">最新文档<a style="float:right" title="更多文档" href="documentList.aspx">更多<span class="caret"></span></a></div>
            <%=sbHTML2 %>
        </div>

        <div class="panel panel-default w360 fll ml20" style="margin-top: 20px">
            <div class="panel-heading">最新习题<a style="float:right" title="更多习题" href="exampleqandaList.aspx">更多<span class="caret"></span></a></div>
            <%=sbHTML3 %>
        </div>

        <div class="text-center" style="color: #999; margin-top: 20px; min-height: 60px; clear:both;
            background-color: #f9f9f9; padding: 20px 0; border-top: 1px solid #e7e7e7;">
            © 2016
            <%=WebsiteTitle %>
            <%if (Session["tempUser"] != null && Session["tempUser"].ToString().Split(',')[0] == "0"){}else{%>
            <a href="system/login.aspx">后台管理</a>
            <%}%>
        </div>
    </div>
</body>
</html>
<script src="static/jquery/jquery.min.js" type="text/javascript"></script>
<script src="static/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>

<script type="text/javascript">
    $(function () {
        $(".carousel").carousel();
    });

    var doSignin = function () {
        window.location.href = "/signin.aspx?from=index";
    };

    var doRegister = function () {
        window.location.href = "/register.aspx?from=index";
    };

    var doExit = function () {
        if (confirm("是否注销当前账号？")) {
            window.location.href = "/index.aspx?timeout=true";
        }
    };
</script>