$(document).ready(function () {
    $('#mcu_date').datepicker('setStartDate', new Date());

    $('#MCULookup').click(function () {
        $('#mp_name_val').val('');
        $('#mp_addr').val('');
        $('#mp_std').val('');
        $('#mp_oh').val('');
        $('#tblMCU tbody tr').remove();
    });

    $('#btnMCUClear').click(function () {
        $("#partner_name_mcu").val('');
        $('#mpAddr').val('');
        $('#mpSTD').val('');
        $('#mpOH').val('');
    });

    var oTable = $('#tblMCU').dataTable({
        "aoColumns": [
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null
        ]
    });

    var entityMap = {
        "&": "&amp;",
        "<": "&lt;",
        ">": "&gt;",
        '"': '&quot;',
        "'": '&#39;',
        "/": '&#x2F;'
      };
    
      function escapeHtml(string) {
        return String(string).replace(/[&<>"'\/]/g, function (s) {
          return entityMap[s];
        });
      }

    $('#findDataMCUBtn').click(function () {
        var el = $(".MCUData");
        App.blockUI({target:".MCUData"});
        $.getJSON("getMPMCU",
            { mp_name_val: $('#mp_name_val').val(), mp_addr: $('#mp_addr').val(), mp_std: $('#mp_std').val(), mp_oh: $('#mp_oh').val() },
            function (data) {
                var len = data.length;
                if (len >= 1) {
                    oTable.fnClearTable();
                    var i = 0;
                    $.each(data, function (i, item) {
                        oTable.fnAddData([
                            '<input type="radio" value="' + i + '" name="fmp_id" id="fmp_id" />',
                            item.param_value + '<input type="hidden" value="' + item.mp_id + '" name="fmcu[' + i + '][mp_id]" id="fmcu[' + i + '][mp_id]" />',
                            item.mp_name + '<input type="hidden" value="' + item.mp_name + '" name="fmcu[' + i + '][mp_name]" id="fmcu[' + i + '][mp_name]" />',
                            item.mp_address + '<input type="hidden" value="' + item.mp_address + '" name="fmcu[' + i + '][mp_address]" id="fmcu[' + i + '][mp_address]" />',
                            item.mp_phone,
                            item.mp_fax,
                            item.standard_facility + '<input type="hidden" value="' + item.standard_facility + '" name="fmcu[' + i + '][standard_facility]" id="fmcu[' + i + '][standard_facility]" />',
                            item.operational_hours + '<input type="hidden" value="' + item.operational_hours + '" name="fmcu[' + i + '][operational_hours]" id="fmcu[' + i + '][operational_hours]" />'
                        ]);
                        i++;
                    });
                } else {
                    alert('Medical Partner Not Found');
                    oTable.fnClearTable();
                    $('#mp_name_val').val('');
                    $('#mp_addr').val('');
                    $('#mp_std').val('');
                    $('#mp_oh').val('');
                }
            })
            .done(function () {
                window.setTimeout(function () {
                    App.unblockUI(".MCUData");
                }, 100);
                // el.preventDefault();
            });
        return false;
    });

    $("#chooseMCU").click(function () {
        var rowID = $("#rowID").val();
        if (!$("input[name='fmp_id']:checked").val()) {
            alert('Please, select one of the medical partner');
            return false;
        }
        var bpID = $("input[name='fmp_id']:checked").val();
        $('#partner_id').val($("input[name='fmcu[" + bpID + "][mp_id]']").val());
        $('#partner_name_mcu').val($("input[name='fmcu[" + bpID + "][mp_name]']").val());
        $("#mpAddr").val($("input[name='fmcu[" + bpID + "][mp_address]']").val());
        $("#mpSTD").val($("input[name='fmcu[" + bpID + "][standard_facility]']").val());
        $("#mpOH").val($("input[name='fmcu[" + bpID + "][operational_hours]']").val());
        $("#closeFindMCU").trigger('click');

    });
});