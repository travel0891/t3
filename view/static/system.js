﻿require.config({
    paths: {
        jquery: "jquery/jquery.min",
        jqueryv: "jquery-validation/dist/jquery.validate.min",
        student: "temp/students",
        course: "temp/courses",
        document: "temp/documents",
        example: "temp/examples",
        manager: "temp/managers",
        cfg: "temp/configs",
        qanda: "temp/qandas"
    }
});

require(["jquery", "jqueryv", "student", "course", "document", "example", "manager", "cfg", "qanda"], function ($, a, b, c, d, e, f, g, h) {
    $(function () {
        b.v("#studentForm");
        c.v("#courseForm");
        f.v("#managerForm");
        h.v("#qandaForm");
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

    $("#managerSubmit").on("click", function () {
        if (f.v("#managerForm").form()) {
            f.m("#managerForm", $("#postType").val());
        }
    });

    $("#configsCharId").on("change", function () {
        g.c("parmList", $(this).val());
    });

    $("#qandaSubmit").on("click", function () {
        if (h.v("#qandaForm").form()) {
            h.q("#qandaForm", $("#postType").val());
        }
    });
});