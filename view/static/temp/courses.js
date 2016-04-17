define(["jquery", "jqueryv"], function () {

    var validate = function (form) {
        var submitStatus = $(form).validate({
            debug: true,
            rules: { configsCharId: { required: true }, number: { required: true }, title: { required: true} }
            , messages: { configsCharId: { required: "类型必选" }, number: { required: "编号必填" }, title: { required: "标题必填"} }
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