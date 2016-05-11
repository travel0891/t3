<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="view.index" %>

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
                    <a class="navbar-brand" href="#">
                        <%=WebsiteTitle %></a>
                </div>
                <div class="collapse navbar-collapse" id="navbar-collapse-1">
                    <ul class="nav navbar-nav">
                        <li class="active"><a href="#">首页</a></li>
                        <li><a href="#">课件学习</a></li>
                        <li><a href="#">文档下载</a></li>
                        <li><a href="#">习题练习</a></li>
                        <li><a href="#">模拟测试</a></li>
                        <li><a href="#">在线提问</a></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li>
                            <button onclick="javascript:doSignin();" class="btn btn-info mt8">
                                学生登录</button>
                        </li>
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
                    <img alt="page3" src="static/image/temp.jpg" data-holder-rendered="true" />
                    <div class="carousel-caption">
                        <h3>
                            PAGE 3</h3>
                        <p>
                            &nbsp;</p>
                    </div>
                </div>
                <div class="item active">
                    <img alt="page1" src="static/image/temp.jpg" data-holder-rendered="true" />
                    <div class="carousel-caption">
                        <h3>
                            PAGE 1</h3>
                        <p>
                            &nbsp;</p>
                    </div>
                </div>
                <div class="item">
                    <img alt="page2" src="static/image/temp.jpg" data-holder-rendered="true" />
                    <div class="carousel-caption">
                        <h3>
                            PAGE 2</h3>
                        <p>
                            &nbsp;</p>
                    </div>
                </div>
            </div>
            <a data-slide="prev" role="button" href="#carousel-example-captions" class="left carousel-control">
                <span class="glyphicon glyphicon-chevron-left"></span><span class="sr-only">Previous</span>
            </a><a data-slide="next" role="button" href="#carousel-example-captions" class="right carousel-control">
                <span class="glyphicon glyphicon-chevron-right"></span><span class="sr-only">Next</span></a>
        </div>

        <div class="panel panel-default" style="margin-top: 20px">
            <div class="panel-heading">学习课件</div>
            <%=sbHTML1 %>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">文档下载</div>
            <%=sbHTML2 %>
        </div>

        <div class="text-center" style="color: #999; margin-top: 20px; min-height: 60px;
            background-color: #f9f9f9; padding: 20px 0; border-top: 1px solid #e7e7e7;">
            © 2016
            <%=WebsiteTitle %>
            <a href="system/login.aspx">后台管理</a>
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
</script>
