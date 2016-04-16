<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="class_list.aspx.cs" Inherits="view.class_list" %>

<!doctype html>
<html>
<head>
    <title>班级列表 - <%=WebsiteTitle %></title>
    <link href="/static/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="/static/datatables/media/css/dataTables.bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="/static/extend.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container-fluid mt15">
        <ol class="breadcrumb"><li class="c999">当前：参数设置</li><li class="c999">班级列表</li></ol>
        <form id="classForm" class="form-horizontal" action="/system/config/class_list.aspx" onsubmit="javascript:return doCheck();">
        <div class="form-group">
         <div class="col-sm-4"></div>
            <label class="col-sm-1 control-label">新增班级</label>
            <div class="col-sm-3">
                <div class="input-group">
                    <input id="className" name="className" type="text" class="form-control" placeholder="必填" />
                    <span class="input-group-btn">
                        <button class="btn btn-primary" type="submit">保存</button>
                    </span>
                </div>
            </div>
             <div class="col-sm-4"></div>
        </div>
        </form>
        <hr />
        <div id="dataList" runat="server"></div>
    </div>
    <script src="/static/jquery/jquery.min.js" type="text/javascript"></script>
    <script src="/static/datatables/media/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="/static/datatables/media/js/dataTables.bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
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
                    url: "/action.ashx?type=delClass",
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

            var doCheck = function () {
                if ($("#className").val() == "") {
                    alert("班级不能为空");
                    return false;
                } else {
                    return true;
                }
            };
    </script>
</body>
</html>