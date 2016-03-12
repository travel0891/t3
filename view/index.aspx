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
</head>
<body>
    <div class="container">
        <div class="navbar navbar-default">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-collapse-1"
                        aria-expanded="false">
                        <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span
                            class="icon-bar"></span><span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="#">
                        <%=WebsiteTitle %></a>
                </div>
                <div class="collapse navbar-collapse" id="navbar-collapse-1">
                    <ul class="nav navbar-nav">
                        <li class="active"><a href="#">首页</a></li>
                        <li><a href="#">上级实验</a></li>
                        <li><a href="#">模拟考试</a></li>
                        <li><a href="#">在线授课</a></li>
                        <li><a href="#">论坛交流</a></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="#">登录</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div data-ride="carousel" class="carousel slide" id="carousel-example-captions">
            <ol class="carousel-indicators">
                <li data-slide-to="0" data-target="#carousel-example-captions"></li>
                <li data-slide-to="1" data-target="#carousel-example-captions"></li>
                <li data-slide-to="2" data-target="#carousel-example-captions"></li>
            </ol>
            <div role="listbox" class="carousel-inner">
                <div class="item">
                    <img src="static/image/temp.jpg" data-holder-rendered="true" />
                    <div class="carousel-caption">
                        <h3>
                            First slide label</h3>
                        <p>
                            Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
                    </div>
                </div>
                <div class="item active">
                    <img src="static/image/temp.jpg" data-holder-rendered="true" />
                    <div class="carousel-caption">
                        <h3>
                            Second slide label</h3>
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                    </div>
                </div>
                <div class="item">
                    <img src="static/image/temp.jpg" data-holder-rendered="true" />
                    <div class="carousel-caption">
                        <h3>
                            Third slide label</h3>
                        <p>
                            Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
                    </div>
                </div>
            </div>
            <a data-slide="prev" role="button" href="#carousel-example-captions" class="left carousel-control">
                <span aria-hidden="true" class="glyphicon glyphicon-chevron-left"></span><span class="sr-only">
                    Previous</span> </a><a data-slide="next" role="button" href="#carousel-example-captions"
                        class="right carousel-control"><span aria-hidden="true" class="glyphicon glyphicon-chevron-right">
                        </span><span class="sr-only">Next</span> </a>
        </div>
        <div class="text-center" style="color:#999; margin-top:20px; min-height:60px; background-color:#f9f9f9;padding:20px 0; border-top:1px solid #e7e7e7;">
            © 2016 <%=WebsiteTitle %> <a href="system/login.aspx">后台管理</a>
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
</script>
