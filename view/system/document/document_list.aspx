<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="document_list.aspx.cs" Inherits="view.document_list" %>

<!doctype html>
<html>
<head>
    <title>文档列表 - <%=WebsiteTitle %></title>
    <link href="../../static/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../static/datatables/media/css/dataTables.bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../static/extend.css" rel="stylesheet" type="text/css" />
    <link href="../../static/layer/skin/layer.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container-fluid mt15">
        <ol class="breadcrumb"><li class="c999">当前：文档管理</li><li class="c999">文档列表</li></ol>
        <div id="dataList" runat="server"></div>
    </div>
    <script src="../../static/jquery/jquery.min.js" type="text/javascript"></script>
    <script src="../../static/datatables/media/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="../../static/datatables/media/js/dataTables.bootstrap.min.js" type="text/javascript"></script>
    <script src="../../static/bootstrap/js/dropdowns.min.js" type="text/javascript"></script>
    <script src="../../static/layer/layer.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            
            $(".dropdown-toggle").dropdown();

            $("#tableList").dataTable({
                "sort": false
                , "language": {
                    "lengthMenu": "每页 _MENU_ 条记录",
                    "zeroRecords": "没有找到记录",
                    "info": "当前 _START_ ~ _END_ 条记录，共 _TOTAL_ 条记录",
                    "infoEmpty": "",
                    "infoFiltered": "(从 _MAX_ 条记录检索)",
                    "search": "关键词",
                    "paginate": { "first": "首页", "last": "尾页", "next": "下一页", "previous": "上一页" }
                }
            });
        });

        var del = function (indexCharId) {
            if (confirm("确定继续删除？"))
                $.ajax({
                    url: "/action.ashx?type=delDocument",
                    type: "post",
                    data: { charId: indexCharId },
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data["code"] == "pass") {
                            alert(data["story"]);
                            window.location.reload();
                        }
                        else {
                            alert(data["story"]);
                        }
                    },
                    error: function () {
                        alert("网络异常，请重试");
                    }
                });
        };
    </script>
</body>
</html>
