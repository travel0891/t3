require.config({
    paths: {
        jquery: "jquery/jquery.min",
        jqueryv: "jquery-validation/dist/jquery.validate.min",
        l: "temp/login",
        s: "temp/signin"
    }
});

require(["jquery", "jqueryv", "l", "s"], function ($, a, b, c) {
    $(function () {
        b.v("#loginForm");
        c.v("#signinForm");
    });
    $("#doLogin").on("click", function () {
        if (b.v("#loginForm").form()) {
            b.l("#loginForm");
        }
    });
    $("#doSignin").on("click", function () {
        if (c.v("#signinForm").form()) {
            c.s("#signinForm");
        }
    });
});