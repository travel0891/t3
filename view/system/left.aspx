﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="view.manage.left" %>

<!doctype html>
<html lang="zh-CN">
<head>
    <title>后台管理</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <style>
        body
        {
            margin: 0;
            padding: 0;
        }
        
        .left
        {
            width: 200px;
            height: 100%;
            border: 1px solid #ddd;
            border-bottom: none;
            font-size: 14px;
            text-align: center;
        }
        
        .all
        {
            text-align: center;
            width: 200px;
        }
        
        .bgm
        {
            height: 40px;
            line-height: 40px;
            cursor: pointer;
            font-size: 14px;
            position: relative;
            border-bottom: #ccc 1px dotted;
            background: -webkit-linear-gradient(#f9f9f9, #f3f3f3); /* Safari 5.1 - 6.0 */
            background: -o-linear-gradient(#f9f9f9, #f3f3f3); /* Opera 11.1 - 12.0 */
            background: -moz-linear-gradient(#f9f9f9, #f3f3f3); /* Firefox 3.6 - 15 */
            background: linear-gradient(#f9f9f9, #f3f3f3); /* 标准的语法 */
            background-color: #f6f6f6;
        }
        
        .icon1, .icon2, .icon3, .icon4
        {
            position: absolute;
            height: 20px;
            width: 20px;
            left: 40px;
            top: 10px;
        }
        
        .icon1
        {
            background: url(../static/image/1.png);
        }
        .icon2
        {
            background: url(../static/image/2.png);
        }
        .icon3
        {
            background: url(../static/image/3.png);
        }
        .icon4
        {
            background: url(../static/image/4.png);
        }
        
        .meun
        {
            display: none;
            cursor: pointer;
            font-size: 14px;
        }
        
        .meun ul
        {
            margin: 0;
            padding: 0;
        }
        
        .meun ul li
        {
            height: 40px;
            line-height: 40px;
            list-style: none;
            border-bottom: 1px dotted #ccc;
            text-align: center;
            color: #333;
        }
        .meun ul li:hover
        {
            color: #269abc;
        }
    </style>
</head>
<body>
    <div style="margin: 8px 0px; height: 36px; background-color: #f3f3f3; color: #999">LOGO</div>
    <div class="left">
        <div class="all">
            <div class="bgm">
                <div class="icon1">
                </div>
                用户管理</div>
            <div class="meun" id="urlList">
                <ul>
                    <li title="user_list">用户列表</li>
                    <li title="user_add">用户添加</li>
                </ul>
            </div>
            <div class="bgm">
                <div class="icon2">
                </div>
                论坛管理</div>
            <div class="meun" id="urlList">
                <ul>
                    <li title="1">板块列表</li>
                    <li title="2">板块添加</li>
                    <li title="3">帖子管理</li>
                </ul>
            </div>
            <div class="bgm">
                <div class="icon3">
                </div>
                课件管理</div>
            <div class="meun" id="urlList">
                <ul>
                    <li title="1">课件类别</li>
                    <li title="2">课件添加</li>
                    <li title="3">课件列表</li>
                    <li title="3">课件添加</li>
                </ul>
            </div>
            <div class="bgm">
                <div class="icon4">
                </div>
                上传管理</div>
            <div class="meun" id="urlList">
                <ul>
                    <li title="1">1</li>
                    <li title="2">2</li>
                    <li title="3">3</li>
                </ul>
            </div>
        </div>
    </div>
</body>
</html>
<script src="../static/temp/slide-toggle.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(".bgm").click(function () {
        $(this).next("div").slideToggle("fast").siblings(".meun:visible").slideUp("fast");
    });

    $("#urlList ul li").bind("click", function () {
        parent.mainFrame.location.href = $(this).attr("title") + ".aspx?t=" + Math.random();
    });
</script>