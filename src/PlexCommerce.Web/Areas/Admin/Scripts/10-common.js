$(function () {

    // show shadow under title for not supporting text-shadow
    if ($("<div/>")[0].style.textShadow !== '') {
        var _a = $("#title a");
        _a.clone().attr("id", "title-shadow").insertBefore(_a);
    }

    // configure post links
    $(".confirm-post-link").live("click", function () {
        if (confirm("Are you sure?")) {
            var _form = $("<form>").attr({ action: this.href, method: "post" });
            _form.appendTo(document.documentElement);
            _form[0].submit();
        }
        return false;
    });
});