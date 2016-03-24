require.config({
    paths: {
        jquery: "jquery/jquery.min",
        jqueryv: "jquery-validation/dist/jquery.validate.min",
        student: "temp/students",
        course: "temp/courses"
    }
});

require(["jquery", "jqueryv", "student", "course"], function ($, a, b, c) {
    $(function () {
        b.v("#studentForm");
        c.v("#courseForm");
    });

    $("#studentSubmit").on("click", function () {
        if (b.v("#studentForm").form()) {
            b.s("#studentForm", $("#postType").val());
        }
    });

    $("#courseSubmit").on("click", function () {
        if (c.v("#courseForm").form()) {
            c.c("#courseForm", $("#postType").val());
        }
    });
});