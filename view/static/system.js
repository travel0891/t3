require.config({
    paths: {
        jquery: "jquery/jquery.min",
        jqueryv: "jquery-validation/dist/jquery.validate.min",
        student: "temp/students",
        course: "temp/courses",
        document: "temp/documents",
        example: "temp/examples"
    }
});

require(["jquery", "jqueryv", "student", "course", "document", "example"], function ($, a, b, c, d, e) {
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

    $("#documentSubmit").on("click", function () {
        if (d.v("#documentForm").form()) {
            d.d("#documentForm", $("#postType").val());
        }
    });

    $("#exampleSubmit").on("click", function () {
        if (e.v("#exampleForm").form()) {
            e.e("#exampleForm", $("#postType").val());
        }
    });
});