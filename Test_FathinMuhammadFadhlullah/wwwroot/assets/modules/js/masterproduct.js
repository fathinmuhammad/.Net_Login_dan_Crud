$(document).ready(function () {
    var start = Date.parse($('#start_date').val());
    var end = Date.parse($('#end_date').val());

    $('#end_date').datepicker('setStartDate', new Date(end));
    $('#start_date').datepicker('setEndDate', new Date(end));
    //$('#end_date').datepicker('setEndDate', new Date(end));

    $('#start_date').datepicker({
        startDate: start,
        endDate: end,
        format: "mm/dd/yyyy"
    }).on('changeDate', function () {
        $('#end_date').datepicker('setStartDate', new Date($(this).val()));
    });

    $('#end_date').datepicker({
        startDate: end,
        format: "mm/dd/yyyy"
    }).on('changeDate', function () {
        $('#start_date').datepicker('setEndDate', new Date($(this).val()));
        //$('#end_date').datepicker('setStartDate', new Date($(this).val()));
    });

});