require.config({
    paths: {
        jquery: "jquery/jquery.min",
        l: "temp/login",
        jqueryv: "jquery-validation/dist/jquery.validate.min"
    }
    //    , shim: {
    //        "jqueryv": ["jquery"]
    //    }
});

require(["jquery", "l", "jqueryv"], function ($, a, b) {

    var submitStatus;

    $(function () {
        submitStatus = $("#tempForm").validate({
            debug: true,
            rules: {
                name: {
                    required: true,
                    rangelength: [3, 8]
                }
                , password: {
                    required: true,
                    rangelength: [6, 12]
                }
            },
            messages: {
                name: {
                    required: "账号不能为空",
                    rangelength: "账号应3至8位"
                }
                , password: {
                    required: "密码不能为空",
                    rangelength: "密码应6至12位"
                }
            }
        });
    });

    $("button[type='submit']").on("click", function () {
        if (submitStatus.form()) {
            a.l("#tempForm");
        }
    });
});