define(["jquery", "jqueryv"], function () {

    var validate = function (form) {
        var submitStatus = $(form).validate({
            debug: true,
            rules: { account: { required: true, rangelength: [3, 8] }
            , password: { required: true, rangelength: [6, 12] }
            , confirm_password: { required: true, rangelength: [6, 12], equalTo: "#password" }
            , number: { required: true, rangelength: [10, 10] }
            , name: { required: true }
            , gender: { required: true }
            , classes: { required: true }
            }
            , messages: { account: { required: "账号必填", rangelength: "账号长度3至8位" }
            , password: { required: "密码必填", rangelength: "密码长度6至12位" }
            , confirm_password: { required: "确认密码必填", rangelength: "确认密码长度6至12位", equalTo: "两次密码输入不一致" }
            , number: { required: "学号必填", rangelength: "学号只限10位数字" }
            , name: { required: "姓名必填" }
            , gender: { required: "性别必选" }
            , classes: { required: "班级必填" }
            }
            , errorPlacement: function (error, element) { error.appendTo(element.parent()); }
        });
        return submitStatus;
    };

    var register = function (form) {
        var bLabel = "<label class=\"ajaxError\">";
        var eLabel = "</label>";

        $.ajax({
            url: "/action.ashx?type=addStudent",
            type: "post",
            data: $(form).serialize(),
            dataType: "json",
            async: false,
            success: function (data) {
                if (data["code"] != "pass") {
                    $("#promptId").html(bLabel + data["story"] + eLabel);
                }
                else {
                    alert("注册成功，点击跳转至登录");
                    location.href = "signin.aspx?from=register&t=" + Math.random();
                }
            },
            error: function () {
                $("#promptId").html(bLabel + "网络异常，请重试" + eLabel);
            }
        });
    };


    return {
        r: register,
        v: validate
    }
});