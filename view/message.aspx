<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="message.aspx.cs" Inherits="view.message" %>

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
        b{color:#999; font-weight:normal;}
        .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th{ line-height:200%;}
        .h54{ height:54px;}
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
                        <li><a href="linetest.aspx">自我测评</a></li>
                        <li class="active"><a href="javascript:;">在线提问</a></li>
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

            <%if (Session["tempUser"] != null && Session["tempUser"].ToString().Split(',')[0] == "0"){%>
        <div class="input-group" style="margin-top: 20px">
            <input type="text" id="cttInput" class="form-control" placeholder="请填写问题描述" />
            <span class="input-group-btn">
                <button class="btn btn-primary" type="button" onclick="javascript:doCreate();">发布问题</button>
            </span>
        </div>
            <%} %>

        <div class="panel panel-default" style="margin-top: 20px">
            <div class="panel-heading">
                在线提问<span style="float: right">共
                    <%=tempCount %>
                    条记录</span></div>
            <%=sbHTML1 %>
        </div>

         <div class="input-group" id="postPlan" style="margin-top: 20px;display:none;">
            <textarea rows="" cols="" id="textInput" class="form-control" placeholder="请填写问题答案" style=" height:54px"></textarea>
            <span class="input-group-btn">
                <button class="btn btn-primary h54" onclick="javascript:doPost();" type="button">提交回答</button><button onclick="javascript:doQuit();" class="btn btn-default h54" type="button">取消</button>
            </span>
        </div>

        <div class="text-center" style="color: #999; margin-top: 20px; min-height: 60px; clear:both;
            background-color: #f9f9f9; padding: 20px 0; border-top: 1px solid #e7e7e7;">
            © 2016
            <%=WebsiteTitle %>
            <a href="system/login.aspx">后台管理</a>
        </div>
    </div>
</body>
</html>

<script type="text/javascript">
    var pPlan = document.getElementById("postPlan"), qPlan = document.getElementById("quitPlan"), iText = document.getElementById("textInput");
    var tempCharId = "";

    var doSignin = function () {
        window.location.href = "/signin.aspx?from=message";
    };

    var doRegister = function () {
        window.location.href = "/register.aspx?from=message";
    };

    var doExit = function () {
        if (confirm("是否注销当前账号？")) {
            window.location.href = "/index.aspx?timeout=true";
        }
    };

    var doCreate = function () {
        if (window.XMLHttpRequest) {
            xmlhttp = new XMLHttpRequest();
        }
        else {
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                var dataList = xmlhttp.responseText;
                if (dataList.indexOf("pass") > -1) {
                    alert("发布成功");
                    location.href = "../message.aspx?t=" + Math.random();
                }
                else {
                    alert("发布成功");
                }
            }
        }
        xmlhttp.open("POST", "/action.ashx?type=insertMessages", false);
        xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xmlhttp.send("title=" + escape(document.getElementById("cttInput").value));
    };

    var doDel = function (indexCharId, indexTxt) {
        if (confirm("是否确认删除：" + indexTxt)) {
            if (window.XMLHttpRequest) {
                xmlhttp = new XMLHttpRequest();
            }
            else {
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    var dataList = xmlhttp.responseText;
                    if (dataList.indexOf("pass") > -1) {
                        alert("删除成功");
                        location.href = "../message.aspx?t=" + Math.random();
                    }
                    else {
                        alert("删除失败");
                    }
                }
            }
            xmlhttp.open("POST", "/action.ashx?type=deleteMessages", false);
            xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            xmlhttp.send("charId=" + indexCharId);
        }
    };

    var doAdd = function (indexCharId) {
        iText.value = "";
        pPlan.style.display = "";
        tempCharId = indexCharId;
    };

    var doEdit = function (indexCharId, indexTxt) {
        iText.value = "";
        pPlan.style.display = "";
        iText.value = indexTxt;
        tempCharId = indexCharId;
    };

    var doPost = function () {
        if (window.XMLHttpRequest) {
            xmlhttp = new XMLHttpRequest();
        }
        else {
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                var dataList = xmlhttp.responseText;
                if (dataList.indexOf("pass") > -1) {
                    alert("提交成功");
                    location.href = "../message.aspx?t=" + Math.random();
                }
                else {
                    alert("提交失败");
                }
            }
        }
        xmlhttp.open("POST", "/action.ashx?type=updateMessages", false);
        xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xmlhttp.send("charId=" + tempCharId + "&reply=" + escape(document.getElementById("textInput").value));
    };

    var doQuit = function () {
        pPlan.style.display = "none";
    };
</script>