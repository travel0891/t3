define(["jquery", "jqueryv"], function () {

    var validate = function (form) {
        var submitStatus = $(form).validate({
            debug: true,
            rules: { account: { required: true, rangelength: [3, 8] }
            , password: { required: true, rangelength: [6, 12] }
            , confirm_password: { required: true, rangelength: [6, 12], equalTo: "#password" }
            , number: { required: true }
            , name: { required: true }
            , gender: { required: true }
            , classes: { required: true }
            }
            , messages: { account: { required: "账号必填", rangelength: "账号长度3至8位" }
            , password: { required: "密码必填", rangelength: "密码长度6至12位" }
            , confirm_password: { required: "确认密码必填", rangelength: "确认密码长度6至12位", equalTo: "两次密码输入不一致" }
            , number: { required: "学号必填" }
            , name: { required: "姓名必填" }
            , gender: { required: "性别必选" }
            , classes: { required: "班级必填" }
            }
            , errorPlacement: function (error, element) { error.appendTo(element.parent()); }
        });
        return submitStatus;
    };

    var student = function (form, type) {
        $.ajax({
            url: "/action.ashx?type=" + type,
            type: "post",
            data: $(form).serialize(),
            dataType: "json",
            async: false,
            success: function (data) {
                if (data["code"] == "pass") {
                    alert(data["story"]);
                    location.href = "../student/student_list.aspx?t=" + Math.random();
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

    return {
        s: student,
        v: validate
    }
});