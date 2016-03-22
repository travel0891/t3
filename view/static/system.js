require.config({
    paths: {
        jquery: "jquery/jquery.min",
        jqueryv: "jquery-validation/dist/jquery.validate.min",
        student: "temp/students"
    }
});

require(["jquery", "jqueryv", "student"], function ($, a, b) {
    $(function () {
        b.v("#tempForm");
    });

    $("button[type='submit']").on("click", function () {
        if (b.v("#tempForm").form()) {
            b.s("#tempForm", $("#postType").val());
        }
    });
});