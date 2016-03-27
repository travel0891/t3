define(["jquery", "jqueryv"], function () {

    var validate = function (form) {
        var submitStatus = $(form).validate({
            debug: true,
            rules: { number: { required: true }, title: { required: true }, url: { required: true} }
            , messages: { number: { required: "编号不能为空" }, title: { required: "名称不能为空" }, url: { required: "文件不能为空"} }
            , errorPlacement: function (error, element) { error.appendTo(element.parent()); }
        });
        return submitStatus;
    };

    var documentle = function (form, type) {
        var formData = new FormData();
        formData.append("url", document.getElementById("url").files[0]);
        formData.append("number", document.getElementById("number").value);
        formData.append("title", document.getElementById("title").value);
        $.ajax({
            url: "/action.ashx?type=" + type,
            type: "post",
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                if (data["code"] == "pass") {
                    alert(data["story"]);
                    location.href = "../document/document_list.aspx?t=" + Math.random();
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

    var documentle1 = function (form, type) {
        $.ajax({
            url: "/action.ashx?type=" + type,
            type: "post",
            data: $(form).serialize(),
            dataType: "json",
            async: false,
            success: function (data) {
                if (data["code"] == "pass") {
                    alert(data["story"]);
                    location.href = "../document/document_list.aspx?t=" + Math.random();
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
        d: documentle,
        d1: documentle1,
        v: validate
    }
});