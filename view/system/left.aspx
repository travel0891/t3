﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="view.left" %>

<!doctype html>
<html lang="zh-CN">
<head>
    <title>后台管理</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <style>
        body {
            margin: 0;
            padding: 0;
        }
        
        .left {
            width: 200px;
            height: 100%;
            border: 1px solid #ddd;
            border-bottom: none;
            font-size: 14px;
            text-align: center;
        }
        
        .all {
            text-align: center;
            width: 200px;
        }
        
        .bgm {
            height: 40px;
            line-height: 40px;
            cursor: pointer;
            font-size: 14px;
            position: relative;
            border-bottom: #ccc 1px dotted;
            background: -webkit-linear-gradient(#f9f9f9, #f3f3f3);
            background: -o-linear-gradient(#f9f9f9, #f3f3f3);
            background: -moz-linear-gradient(#f9f9f9, #f3f3f3);
            background: linear-gradient(#f9f9f9, #f3f3f3);
            background-color: #f6f6f6;
        }
        
        .icon1, .icon2, .icon3, .icon4 {
            position: absolute;
            height: 20px;
            width: 20px;
            left: 40px;
            top: 10px;
        }
        
        .icon1 {
            background: url(../static/image/1.png);
        }
        .icon2 {
            background: url(../static/image/2.png);
        }
        .icon3 {
            background: url(../static/image/3.png);
        }
        .icon4 {
            background: url(../static/image/4.png);
        }
        
        .meun {
            display: none;
            cursor: pointer;
            font-size: 14px;
        }
        
        .meun ul {
            margin: 0;
            padding: 0;
        }
        
        .meun ul li {
            height: 40px;
            line-height: 40px;
            list-style: none;
            border-bottom: 1px dotted #ccc;
            text-align: center;
            color: #333;
        }
        .meun ul li:hover {
            color: #269abc;
        }
    </style>
</head>
<body>
    <div style="margin: 8px 0px; height: 36px; text-align: center; line-height: 36px;
        background-color: #f3f3f3; color: #999">
        <%=WebsiteTitle %></div>
    <div class="left">
        <div class="all">
            <div class="bgm">
                <div class="icon2">
                </div>
                用户管理</div>
            <div class="meun">
                <ul>
                    <li title="student/student_list">用户列表</li>
                    <li title="student/student_action">学生添加</li>
                    <li title="student/manager_action">管理员添加</li>
                </ul>
            </div>
            <div class="bgm">
                <div class="icon3">
                </div>
                课件管理</div>
            <div class="meun">
                <ul>
                    <li title="course/course_list">课件列表</li>
                    <li title="course/course_action">课件添加</li>
                </ul>
            </div>
            <div class="bgm">
                <div class="icon3">
                </div>
                文档管理</div>
            <div class="meun">
                <ul>
                    <li title="document/document_list">文档列表</li>
                    <li title="document/document_action">文档添加</li>
                </ul>
            </div>
            <div class="bgm">
                <div class="icon4">
                </div>
                试题管理</div>
            <div class="meun">
                <ul>
                    <li title="example/example_list">选择题列表</li>
                    <li title="example/example_action">选择题添加</li>
                    <li title="example/qanda_list">问答题列表</li>
                    <li title="example/qanda_action">问答题添加</li>
                </ul>
            </div>
            <div class="bgm">
                <div class="icon1">
                </div>
                参数预设</div>
            <div class="meun">
                <ul>
                    <li title="config/class_list">班级设置</li>
                    <li title="config/config_list">类型设置</li>
                    <li title="config/parm_list">章节设置</li>
                </ul>
            </div>
        </div>
    </div>
</body>
</html>
<script src="/static/jquery/slide-toggle.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(".bgm").click(function () {
        $(this).next("div").slideToggle("fast").siblings(".meun:visible").slideUp("fast");
    });

    $(".meun ul li").bind("click", function () {
        parent.mainFrame.location.href = $(this).attr("title") + ".aspx?t=" + Math.random();
    });
</script>
