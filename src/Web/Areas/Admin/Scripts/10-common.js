$(function () {
    // show shadow under title for not supporting text-shadow
    if ($("<div/>")[0].style.textShadow !== '') {
        var _a = $("#title a");
        _a.clone().attr("id", "title-shadow").insertBefore(_a);
    }
});