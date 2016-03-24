define(["jquery", "jqueryv"], function () {

    var validate = function (form) {
        var submitStatus = $(form).validate({
            debug: true,
            rules: { account: { required: true, rangelength: [3, 8], remote: { url: encodeURI("/action.ashx?type=existsAccount"), type: "post"} }, password: { required: true, rangelength: [6, 12]} }
            , messages: { account: { required: "账号不能为空", rangelength: "账号长度3至8位", remote: "该账号不存在" }, password: { required: "密码不能为空", rangelength: "密码长度6至12位"} }
            , errorPlacement: function (error, element) {
                if (element.is("#accountInput")) {
                    $("#promptId").html(error);
                }
                if ($("#promptId").html().indexOf("账号") == -1) {
                    if (element.is("#passwordInput")) {
                        $("#promptId").html(error);
                    }
                }
            }
        });
        return submitStatus;
    };

    var login = function (form) {
        var bLabel = "<label class=\"ajaxError\">";
        var eLabel = "</label>";

        $.ajax({
            url: "/action.ashx?type=doLogin",
            type: "post",
            data: $(form).serialize(),
            dataType: "json",
            async: false,
            success: function (data) {
                if (data["code"] != "pass") {
                    $("#promptId").html(bLabel + data["story"] + eLabel);
                }
                else {
                    location.href = "mainframe.html?t=" + Math.random();
                }
            },
            error: function () {
                $("#promptId").html(bLabel + "网络异常，请重试" + eLabel);
            }
        });
    };

    return {
        l: login,
        v: validate
    }
});