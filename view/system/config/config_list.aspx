<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="config_list.aspx.cs" Inherits="view.config_list" %>

<!doctype html>
<html>
<head>
    <title>类型列表 -
        <%=WebsiteTitle %></title>
    <link href="/static/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="/static/datatables/media/css/dataTables.bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="/static/extend.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container-fluid mt15">
        <ol class="breadcrumb">
            <li class="c999">当前：参数预设</li><li class="c999">类型设置</li></ol>
        <form id="classForm" class="form-horizontal" action="/system/config/config_list.aspx" onsubmit="javascript:return doCheck();">
        <div class="form-group">
            <div class="col-sm-4">
            </div>
            <label class="col-sm-1 control-label">
                新增类型</label>
            <div class="col-sm-3">
                <div class="input-group">
                    <input id="configName" name="configName" type="text" class="form-control" placeholder="必填" />
                    <span class="input-group-btn">
                        <button class="btn btn-primary" type="submit">
                            保存</button>
                    </span>
                </div>
            </div>
            <div class="col-sm-4">
            </div>
        </div>
        </form>
        <hr />
        <div id="dataList" runat="server">
        </div>
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
                    url: "/action.ashx?type=delConfig",
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
            if ($("#configName").val() == "") {
                alert("类型必填");
                return false;
            } else {
                return true;
            }
        };
    </script>
</body>
</html>
