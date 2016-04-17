define(["jquery"], function () {

    var config = function (domId, configId) {
        if (configId != "") {
            $("#" + domId).html("章节加载中...")
            $.ajax({
                url: "/action.ashx?type=getParmByConfigCharId",
                type: "post",
                data: "configCharId=" + configId,
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data["code"] == "pass") {
                        $("#" + domId).html(data["story"]);
                    }
                    else {
                        $("#" + domId).html("<span class='form-control'>该类型还未设置章节</span>");
                    }
                },
                error: function () {
                    alert("网络异常，请重试");
                }
            });
        }
        else {
            $("#" + domId).html("<span class='form-control'>请先选择类型</span>");
        }
    };

    return {
        c: config
    }
});