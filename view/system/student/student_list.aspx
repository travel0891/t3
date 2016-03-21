<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student_list.aspx.cs" Inherits="view.student_list" %>

<!doctype html>
<html>
<head>
    <title>学生列表 - <%=WebsiteTitle %></title>
    <link href="../../static/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../static/datatables/media/css/dataTables.bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../static/extend.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="dataList" class="container-fluid mt15" runat="server">
    </div>
    <script src="../../static/jquery/jquery.min.js" type="text/javascript"></script>
    <script src="../../static/datatables/media/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="../../static/datatables/media/js/dataTables.bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#tableList").dataTable({
                "sort": false,
                "language": {
                    "lengthMenu": "每页 _MENU_ 条记录",
                    "zeroRecords": "没有找到记录",
                    "info": "当前 _START_ ~ _END_ 条记录，共 _TOTAL_ 条记录",
                    "infoEmpty": "无记录",
                    "infoFiltered": "(从 _MAX_ 条记录过滤)",
                    "search": "关键词",
                    "paginate": {
                        "first": "首页",
                        "last": "尾页",
                        "next": "下一页",
                        "previous": "上一页"
                    }
                }
            });
        });
    </script>
</body>
</html>