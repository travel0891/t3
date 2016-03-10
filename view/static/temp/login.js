define(["jquery"], function () {
    var login = function (form) {
        $.ajax({
            url: "../action.ashx?type=login",
            type: "post",
            data: $("" + form + "").serialize(),
            dataType: "json",
            async: false,
            success: function (data) {
                alert(data["story"]);
            },
            error: function () {
                alert("网络异常，请重试！");
            }
        });
    };
    return {
        l: login
    }
});