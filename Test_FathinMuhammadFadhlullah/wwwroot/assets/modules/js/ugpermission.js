jQuery(document).ready(function () {

    $(document).on('change', '.group-checkable', function () {
        var set = $(this).attr("data-set");
        var checked = $(this).is(":checked");
        $(set).each(function () {
            if (checked) {
                $(this).prop("checked", true);
            } else {
                $(this).prop("checked", false);
            }
        });
        $.uniform.update(set);
    });
})