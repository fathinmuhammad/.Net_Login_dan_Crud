$(document).ready(function () {
    var start = Date.parse($('#start_date').val());
    var end = Date.parse($('#end_date').val());
    var effective_date = Date.parse($('#effective_date').val());

    $('#end_date').datepicker('setStartDate', new Date(end));
    $('#start_date').datepicker('setEndDate', new Date(end));
    $('#end_date').datepicker('setEndDate', new Date(effective_date));
    $('#effective_date').datepicker('setStartDate', new Date(end));

    $('#start_date').datepicker({
        startDate: start,
        endDate: end,
        format: "dd-mm-yyyy"
    }).on('changeDate', function () {
        $('#end_date').datepicker('setStartDate', new Date($(this).val()));
    }); 

    $('#end_date').datepicker({
        startDate: start,
        endDate: effective_date,
        format: "dd-mm-yyyy"
    }).on('changeDate', function () {
        $('#start_date').datepicker('setEndDate', new Date($(this).val()));
        $('#effective_date').datepicker('setStartDate', new Date($(this).val()));
    });

    $('#effective_date').datepicker({
        startDate: end,
        format: "dd-mm-yyyy"
    }).on('changeDate', function () {
        $('#end_date').datepicker('setEndDate', new Date($(this).val()));
    });

});