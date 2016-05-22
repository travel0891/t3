require.config({
    paths: {
        jquery: "jquery/jquery.min",
        jqueryv: "jquery-validation/dist/jquery.validate.min",
        l: "temp/login",
        s: "temp/signin",
        r: "temp/register"
    }
});

require(["jquery", "jqueryv", "l", "s", "r"], function ($, a, b, c, d) {
    $(function () {
        b.v("#loginForm");
        c.v("#signinForm");
        d.v("#registerForm");
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
    $("#doRegister").on("click", function () {
        if (d.v("#registerForm").form()) {
            d.r("#registerForm");
        }
    });
});