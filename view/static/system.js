require.config({
    paths: {
        jquery: "jquery/jquery.min",
        jqueryv: "jquery-validation/dist/jquery.validate.min"
    }
});

require(["jquery"], function ($) {
    $(function () {
        $(document).css("color","#f60");
    });
});