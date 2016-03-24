require.config({
    paths: {
        jquery: "jquery/jquery.min",
        jqueryv: "jquery-validation/dist/jquery.validate.min",
        l: "temp/login"
    }
});

require(["jquery", "jqueryv", "l"], function ($, a, b) {
    $(function () {
        b.v("#tempForm");
    });

    $("button[type='submit']").on("click", function () {
        if (b.v("#tempForm").form()) {
            b.l("#tempForm");
        }
    });
});