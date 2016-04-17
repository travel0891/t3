define(["jquery", "jqueryv"], function () {

    var validate = function (form) {
        var submitStatus = $(form).validate({
            debug: true,
            rules: { number: { required: true }, example: { required: true }, aCountent: { required: true }, bCountent: { required: true }, cCountent: { required: true }, dCountent: { required: true} }
            , messages: { number: { required: "编号必填" }, example: { required: "题目必填" }, aCountent: { required: "A选项必填" }, bCountent: { required: "B选项必填" }, cCountent: { required: "C选项必填" }, dCountent: { required: "D选项必填"} }
            , errorPlacement: function (error, element) { error.appendTo(element.parent()); }
        });
        return submitStatus;
    };

    var example = function (form, type) {
        $.ajax({
            url: "/action.ashx?type=" + type,
            type: "post",
            data: $(form).serialize(),
            dataType: "json",
            async: false,
            success: function (data) {
                if (data["code"] == "pass") {
                    alert(data["story"]);
                    location.href = "../example/example_list.aspx?t=" + Math.random();
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
        e: example,
        v: validate
    }
});