<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="parm_list.aspx.cs" Inherits="view.parm_list" %>

<!doctype html>
<html>
<head>
    <title>章节列表 -
        <%=WebsiteTitle %></title>
    <link href="/static/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="/static/datatables/media/css/dataTables.bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="/static/extend.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container-fluid mt15">
        <ol class="breadcrumb">
            <li class="c999">当前：参数预设</li><li class="c999">章节设置</li></ol>
        <form id="classForm" class="form-horizontal" action="/system/config/parm_list.aspx" onsubmit="javascript:return doCheck();">
        <div class="form-group">
            <div class="col-sm-4">
            </div>
            <label class="col-sm-1 control-label">
                新增章节</label>
            <div class="col-sm-3">
                <div class="input-group">
                    <div class="input-group-btn">
                        <button data-toggle="dropdown" class="btn btn-default dropdown-toggle" type="button">
                        <span class="configName">选择类型</span>
                        <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu" id="selectList" runat="server">
                        </ul>
                    </div>
                    <input id="parmName" name="parmName" type="text" class="form-control" placeholder="必填" />
                    <span class="input-group-btn">
                        <button class="btn btn-primary" type="submit">保存</button>
                    </span>
                </div>
            </div>
            <div class="col-sm-4">
            </div>
        </div>
         <input type="hidden" name="configCharId" id="hiConfigId" />
        </form>
        <hr />
        <div id="dataList" runat="server">
        </div>
    </div>
    <script src="/static/jquery/jquery.min.js" type="text/javascript"></script>
    <script src="/static/bootstrap/js/dropdowns.min.js" type="text/javascript"></script>
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
                    url: "/action.ashx?type=delParm",
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
            if ($("#hiConfigId").val() == "") {
                alert("类型必选");
                return false;
            }
            else if ($("#hiConfigId").val() == "00000000-0000-0000-0000-000000000000") {
                alert("请先设置类型");
                return false;
            }
            else if ($("#parmName").val() == "") {
                alert("章节必填");
                return false;
            }
            else {
                return true;
            }
        };

        $(".input-group-btn ul li a").bind("click", function () {
            var array = $(this).data("charid").split("|");
            $("#hiConfigId").val(array[0]);
            $(".configName").html(array[1]);
        });

    </script>
</body>
</html>
