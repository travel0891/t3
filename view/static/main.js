require.config({
    paths: {
        jquery: "jquery/jquery.min",
        l: "temp/login",
        jqueryv: "jquery-validation/dist/jquery.validate.min"
    }
});

require(["jquery", "l", "jqueryv"], function ($, a, b) {

    $(function () {
        a.v("#tempForm");
    });

    $("button[type='submit']").on("click", function () {
        if (a.v("#tempForm").form()) {
            a.l("#tempForm");
        }
    });
});