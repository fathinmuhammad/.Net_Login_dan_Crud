$('.datepicker').datepicker({
    format: 'yyyymm'
});

$("#btnHolidayLookup").click(function () {
	$("#holidayLookup").click();
});

$('#holidayLookup').click(function () {
	$("#findCust").val('');
	$("#tblCust tbody tr").remove();
}); 