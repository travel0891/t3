define(["jquery", "jqueryv"], function () {

    var validate = function (form) {
        var submitStatus = $(form).validate({
            debug: true,
            rules: { number: { required: true }, title: { required: true} }
            , messages: { number: { required: "编号不能为空" }, title: { required: "标题不能为空"} }
            , errorPlacement: function (error, element) { error.appendTo(element.parent()); }
        });
        return submitStatus;
    };

    var course = function (form, type) {
        $.ajax({
            url: "/action.ashx?type=" + type,
            type: "post",
            data: $(form).serialize(),
            dataType: "json",
            async: false,
            success: function (data) {
                if (data["code"] == "pass") {
                    alert(data["story"]);
                    location.href = "../course/course_list.aspx?t=" + Math.random();
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
        c: course,
        v: validate
    }
});