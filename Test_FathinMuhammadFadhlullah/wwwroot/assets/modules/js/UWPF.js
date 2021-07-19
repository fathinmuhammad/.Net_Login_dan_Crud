$(document).ready(function () {
    $(".uwpf").change(function () {
        var checked = jQuery(this).is(":checked");
        var nm = this.name;
        jQuery(this).each(function () {
            if (checked) {
                var valL = parseFloat(document.getElementById(nm).value.replace(/[$.]+/g, ''));
                var valN = parseFloat($("#tsi_amount_val").val().replace(/[$.]+/g, ''));
                var valNt = parseFloat($("#tsi_amount_t").val().replace(/[$.]+/g, ''));
                var CalT = valL + valN;
                $("#tsi_amount_val").val(addCommas(CalT));
                $("#tsi_amount_t").val(addCommas(valL + valNt));
            } else {
                var valL = parseFloat(document.getElementById(nm).value.replace(/[$.]+/g, ''));
                var valN = parseFloat($("#tsi_amount_val").val().replace(/[$.]+/g, ''));
                var valNt = parseFloat($("#tsi_amount_t").val().replace(/[$.]+/g, ''));
                var CalT = valN - valL;
                $("#tsi_amount_val").val(addCommas(CalT));
                $("#tsi_amount_t").val(addCommas(valNt - valL));
            }
        });
    });
    $(".uwpfcls").change(function () {
        var checked = jQuery(this).is(":checked");
        var nm = this.name;
        jQuery(this).each(function () {
            if (checked) {
                var valL = parseFloat(document.getElementById(nm).value.replace(/[$.]+/g, ''));
                var valN = parseFloat($("#tsi_amount_valcls").val().replace(/[$.]+/g, ''));
                var valNt = parseFloat($("#tsi_amount_t").val().replace(/[$.]+/g, ''));
                var CalT = valL + valN;
                $("#tsi_amount_valcls").val(addCommas(CalT));
                $("#tsi_amount_t").val(addCommas(valL + valNt));
            } else {
                var valL = parseFloat(document.getElementById(nm).value.replace(/[$.]+/g, ''));
                var valN = parseFloat($("#tsi_amount_valcls").val().replace(/[$.]+/g, ''));
                var valNt = parseFloat($("#tsi_amount_t").val().replace(/[$.]+/g, ''));
                var CalT = valN - valL;
                $("#tsi_amount_valcls").val(addCommas(CalT));
                $("#tsi_amount_t").val(addCommas(valNt - valL));
            }
        });
    });
    $("#saveFrm").submit(function () {

    });
});

function addCommas(nStr) {
    nStr += '';
    var x = nStr.split(',');
    var x1 = x[0];
    var x2 = x.length > 1 ? ',' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + '.' + '$2');
    }
    return x1 + x2;
}