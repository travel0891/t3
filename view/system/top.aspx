<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="view.top" %>

<!doctype html>
<html lang="zh-CN">
<head>
    <title>后台管理</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <style type="text/css">
        .top
        {
            height: 32px;
            line-height: 34px;
            border: 1px solid #ddd;
            text-align: right;
            background: -webkit-linear-gradient(#f9f9f9, #f3f3f3); /* Safari 5.1 - 6.0 */
            background: -o-linear-gradient(#f9f9f9, #f3f3f3); /* Opera 11.1 - 12.0 */
            background: -moz-linear-gradient(#f9f9f9, #f3f3f3); /* Firefox 3.6 - 15 */
            background: linear-gradient(#f9f9f9, #f3f3f3); /* 标准的语法 */
            background-color: #f6f6f6;
            font-size: 12px;
            color: #269abc;
            padding: 0 12px;
        }
        a
        {
            color: #000;
            text-decoration: none;
            padding: 0 4px;
        }
        a:hover
        {
            color: #269abc;
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <div class="top">
        当前账号：管理员 <a target="_parent" href="login.aspx?logout=true">[安全退出]</a>
    </div>
</body>
</html>
