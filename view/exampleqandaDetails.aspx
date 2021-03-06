﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="exampleqandaDetails.aspx.cs" Inherits="view.exampleqandaDetails" %>

<!doctype html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title><%=exampleqanda%> - 习题练习 - <%=WebsiteTitle %></title>
    <link href="static/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .mt8 {
            margin-top: 8px;
        }
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
                        <li class="active"><a href="exampleqandaList.aspx">习题练习</a></li>
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

        <div class="panel panel-default" style="margin-top: 20px">
            <div class="panel-heading"><strong><%=exampleqanda%></strong> (<%=number %>)<a style="float:right" href="javascript:history.go(-1);">返回</a></div>
            <div style="padding:20px"><span class="label label-primary"><%=tempConfig%></span> <span class="label label-info"><%=tempParm%></span></div>
             <%if (Session["tempUser"] != null)
               {%>
                 <%if (!String.IsNullOrEmpty(Request.QueryString["charId1"]))
                 {%>
               <div style="padding:20px; padding-top:0;">
               <strong>A</strong>：<%=aCountent %>
               <strong>B</strong>：<%=bCountent %>
               <strong>C</strong>：<%=cCountent %>
               <strong>D</strong>：<%=dCountent %>
               <hr />
               正确答案：<strong><%=checkJs %></strong>
               </div>
               <%}%>
               <%if (!String.IsNullOrEmpty(Request.QueryString["charId2"]))
                 {%>
               <div style="padding:20px; padding-top:0;"><%=hiContents%></div>
               <%}%>
             <%}
               else
               { %>
               <div style="padding:20px; padding-top:0;"><span class="label label-danger">您还未登录，无法查看！</span></div>
             <%}%>
        </div>

        <div class="text-center" style="color: #999; margin-top: 20px; min-height: 60px;
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
<script type="text/javascript">

    var doSignin = function () {
        window.location.href = "/signin.aspx?from=exampleqandaDetails";
    };

    var doRegister = function () {
        window.location.href = "/register.aspx?from=exampleqandaDetails";
    };

    var doExit = function () {
        if (confirm("是否注销当前账号？")) {
            window.location.href = "/index.aspx?timeout=true";
        }
    };
</script>