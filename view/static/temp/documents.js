define(["jquery", "jqueryv"], function () {

    var validate = function (form) {
        var submitStatus = $(form).validate({
            debug: true,
            rules: { configsCharId: { required: true }, number: { required: true }, title: { required: true }
            }
            , messages: { configsCharId: { required: "类型必选" }, number: { required: "编号必填" }, title: { required: "名称必填" }
            }
            , errorPlacement: function (error, element) { error.appendTo(element.parent()); }
        });
        return submitStatus;
    };

    var documentle = function (form, type) {
        var formData = new FormData();
        formData.append("url", document.getElementById("url").files[0]);
        formData.append("number", $("#number").val());
        formData.append("title", $("#title").val());
        formData.append("size", $("#size").val());
        formData.append("configsCharId", $("#configsCharId").val());
        formData.append("parmsCharId", $("#parmsCharId").val());
        formData.append("charId",$("#charId").val());

        if ($("#parmsCharId") != undefined) {
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
                    alert("表单异常，请重试");
                }
            });
        }
        else {
            alert("表单异常，请重试");
        }
    };

    return {
        d: documentle,
        v: validate
    }
});