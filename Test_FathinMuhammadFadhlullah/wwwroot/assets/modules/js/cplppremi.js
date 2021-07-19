$(document).ready(function () {
    function hitungPremi() {
        var sum_insured_amount = parseFloat($("#sum_insured_amount").val().replace(/[$.]+/g, ''));
        //var net_std_premi = parseFloat($("#premi_amount").val().replace(/[$.]+/g, ''));
        //var load_em = parseFloat($("#em_value").val());
        //var load_eo = parseFloat($("#eo_value").val());
        //var premi_amount = parseFloat($("#premi_amount").val().replace(/[$.]+/g, ''));
        //var bank_commission = parseFloat($("#bank_commission").val().replace(/[$.]+/g, '').replace(',', '.'));
        //var marketing_allowance = 0;

        //var sub_std_premi = (((net_std_premi - bank_commission - marketing_allowance) * load_em) + (load_eo * sum_insured_amount) + bank_commission + marketing_allowance);
        //var gross_sub_std_premi = roundUp(sub_std_premi, 0).toFixed(2);
        var net_std_premi = parseFloat($("#premi_standard_cl").val().replace(/[$.]+/g, '')) <= 0 ? parseFloat($("#premi_standard").val().replace(/[$.]+/g, '')) : parseFloat($("#premi_standard_cl").val().replace(/[$.]+/g, ''));
        var net_std_premi_tl = parseFloat($("#premi_standard_tl").val().replace(/[$.]+/g, ''));
        var load_em = parseFloat($("#em_value").val());
        var load_eo = parseFloat($("#eo_value").val());
        var premi_amount = parseFloat($("#premi_amount").val().replace(/[$.]+/g, ''));
        var bank_commission = parseFloat($("#bank_commission_cl").val().replace(/[$.]+/g, '').replace(',', '.')) <= 0 ? parseFloat($("#bank_commission").val().replace(/[$.]+/g, '').replace(',', '.')) : parseFloat($("#bank_commission_cl").val().replace(/[$.]+/g, '').replace(',', '.'));
        var marketing_allowance = 0;

        var sub_std_premi = (((net_std_premi - bank_commission - marketing_allowance) * load_em) + (load_eo * sum_insured_amount) + bank_commission + marketing_allowance);
        var gross_sub_std_premi = roundUp(sub_std_premi + net_std_premi_tl, 0).toFixed(2);
        var gross_sub_std_premi_cl = roundUp(sub_std_premi, 0).toFixed(2);
        var net_sub_std_premi = sub_std_premi - bank_commission - marketing_allowance;

        $("#premiCalc").val(gross_sub_std_premi);
    }

    $(document).on('change', '#em_value', function () {
        $("#load_em").val($(this).val());
        hitungPremi();
        //$("#emLoad").val($(this).val());
    });
    $(document).on('change', '#eo_value', function () {
        $("#load_eo").val($(this).val());
        //$("#eoLoad").val($(this).val());
        var val_load = this.options[this.selectedIndex].text;
        var val_view = 0;
        if (val_load != "Standard") {
            val_view = val_load.substring(0, 3);
        }
        $("#load_eo_view").val(val_view);
        hitungPremi();
    });
    if ($('#eo_value option:selected').val() != '') {
        $("#load_eo").val($(this).val());
        var val_load = $('#eo_value option:selected').text();
        var val_view = 0;
        if (val_load != "Standard") {
            val_view = val_load.substring(0, 3);
        }
        $("#load_eo_view").val(val_view);
    }
    if ($('#em_value option:selected').val() != '') {
        $("#load_em").val($('#em_value option:selected').val());
    }

    $(document).on('click', '#calculate', function (e) {
        e.preventDefault();
        if ($("#em_value option:selected").val() == '' || $("#eo_value option:selected").val() == '') {
            alert("Please select the Load EO and Load EM values first.");
            return false;
        }
        var sum_insured_amount = parseFloat($("#sum_insured_amount").val().replace(/[$.]+/g, ''));
        var net_std_premi = parseFloat($("#premi_standard_cl").val().replace(/[$.]+/g, '')) <= 0 ? parseFloat($("#premi_standard").val().replace(/[$.]+/g, '')) : parseFloat($("#premi_standard_cl").val().replace(/[$.]+/g, ''));
        var net_std_premi_tl = parseFloat($("#premi_standard_tl").val().replace(/[$.]+/g, ''));
        var load_em = parseFloat($("#em_value").val());
        var load_eo = parseFloat($("#eo_value").val());
        var premi_amount = parseFloat($("#premi_amount").val().replace(/[$.]+/g, ''));
        var bank_commission = parseFloat($("#bank_commission_cl").val().replace(/[$.]+/g, '').replace(',', '.')) <= 0 ? parseFloat($("#bank_commission").val().replace(/[$.]+/g, '').replace(',', '.')) : parseFloat($("#bank_commission_cl").val().replace(/[$.]+/g, '').replace(',', '.'));
        var marketing_allowance = 0;

        var sub_std_premi = (((net_std_premi - bank_commission - marketing_allowance) * load_em) + (load_eo * sum_insured_amount) + bank_commission + marketing_allowance);
        var gross_sub_std_premi = roundUp(sub_std_premi + net_std_premi_tl, 0).toFixed(2);
        var gross_sub_std_premi_cl = roundUp(sub_std_premi, 0).toFixed(2);
        var net_sub_std_premi = sub_std_premi - bank_commission - marketing_allowance;
        //alert(sub_std_premi);
        //alert('ini roundup : ' + roundUp(sub_std_premi, 0));
        //alert(gross_sub_std_premi);
        //$("#nett_substandard_premi_amount").val(addCommas(net_sub_std_premi));
        //$("#premi_amount_gross").val(addCommas(gross_sub_std_premi));
        $("#nett_substandard_premi_amount").val(net_sub_std_premi);
        $("#nett_substandard_premi_amount").maskMoney({ thousands: '.', decimal: ',', precision: 0, allowZero: true, defaultZero: false });
        $("#nett_substandard_premi_amount_cl").val(net_sub_std_premi);
        $("#nett_substandard_premi_amount_cl").maskMoney({ thousands: '.', decimal: ',', precision: 0, allowZero: true, defaultZero: false });
        $("#premi_amount_gross").val(gross_sub_std_premi);
        $("#premi_amount_gross").maskMoney({ thousands: '.', decimal: ',', allowZero: false, defaultZero: true });
        $("#premi_amount_gross_cl").val(gross_sub_std_premi_cl);
        $("#premi_amount_gross_cl").maskMoney({ thousands: '.', decimal: ',', allowZero: false, defaultZero: true });
        $("#nett_substandard_premi_amount").focus();
        $("#premi_amount_gross").trigger('focus');
        $("#premi_amount_gross_cl").trigger('focus');
    });

    $(document).on('click', '#changeStatus', function (e) {
        var preGross = parseFloat($("#premi_amount_gross").val().replace(/[$.]+/g, ''));
        var premiLoad = $("#premiLoad").val();

        if ($("#completeFlagDoc").val() == "Open" && ($("#updatestatus option:selected").val() == "B" || $("#updatestatus option:selected").val() == "S" || $("#updatestatus option:selected").val() == "R")) {
            alert("Please Click Button Complete Doc First!");
            return false;
        }

        if ($("#emLoad").val() != $("#em_value option:selected").val())
        {
            //alert(preGross);
            //alert(premiLoad);
            //if (preGross == premiLoad) {
                alert("Please save your changes!!");
                return false;
            //}
        }
        if ($("#eoLoad").val() != $("#eo_value option:selected").val()) {
            alert("Please save your changes!");
            return false;
        }
        if ($("#updatestatus option:selected").val() == "") {
            alert("Please. Select status!");
            return false;
        }
        if ($("#updatestatus option:selected").val() == "B" && ($("#emLoad").val() == "1" || !$("#emLoad").val()) && ($("#eoLoad").val() == "0" || !$("#eoLoad").val()))
        {
            alert("Please, correct your change status!!");
            return false;
        }
        if ($("#updatestatus option:selected").val() == "S" && (($("#emLoad").val() != "1" && $("#emLoad").val() != "") || ($("#eoLoad").val() != "0" && $("#eoLoad").val() != ""))) {
            alert("Please, correct your change status!");
            return false;
        }
        if (preGross != premiLoad)
        {
            alert("Please calculate your changes!!");
            return false;
        }

        $("#em_value").removeAttr("required");
        $("#eo_value").removeAttr("required");
        $(".doc_type").removeAttr("required");

        var rtn = confirm('are you sure ?');
        if (rtn == true) {
            isClose = true;
        }
        else {
            $("#em_value").attr("required", "required");
            $("#eo_value").attr("required", "required");
            $(".doc_type").attr("required", "required");
            isClose = false;
        }
        return rtn;
    });

    $(document).on('click', '#changeStatusBPS', function (e) {
        if ($("#updatestatus option:selected").val() == "") {
            alert("Please. Select status!");
            return false;
        }

        $(".doc_type").removeAttr("required");

        var rtn = confirm('are you sure ?');
        if (rtn == true) {
            isClose = true;
        }
        else {
            $(".doc_type").attr("required", "required");
            isClose = false;
        }
        return rtn;
    });

    $(document).on('click', '#AddAttach', function (e) {
        if ($("#doc_type").val() != "" && $("#doc_type").val() != "") {
            var rtn = confirm('are you sure ?');
            if (rtn == true) {
                isClose = true;
            }
            else {
                $(".doc_type").removeAttr("required");
                isClose = false;
            }
        }
        else {
            $(".doc_type").attr("required", "required");
        }
        return rtn;
    });

    $(document).on('click', '#savePremis', function (e) {
        $(".doc_type").removeAttr("required");
        var preGross = parseFloat($("#premi_amount_gross").val().replace(/[$.]+/g, ''));
        var premiLoad = $("#premiCalc").val();
        if (($("#emLoad").val() != $("#em_value option:selected").val()) && (preGross != premiLoad)) {
            //alert(preGross);
            //alert(premiLoad);
            //if (preGross == premiLoad) {
            alert("Please calculate your changes!!!");
            return false;
            //}
        }
        if (($("#eoLoad").val() != $("#eo_value option:selected").val()) && (preGross != premiLoad)) {
            alert("Please calculate your changes!");
            return false;
        }
        //if (preGross != premiLoad) {
        //    alert("Please calculate your changes!!");
        //    return false;
        //}

        var rtn = confirm('are you sure ?');
        if (rtn == true) {
            isClose = true;
        }
        //else {
        //    isClose = false;
        //}
        return rtn;
    });
})

function roundUp(num, precision) {
    precision = Math.pow(10, precision)
    return Math.ceil(num * precision) / precision
}

function addCommas(nStr) {
    nStr += '';
    var x = nStr.split('.');
    var x1 = x[0];
    var x2 = x.length > 1 ? ',' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + '.' + '$2');
    }
    return x1 + x2;
}

function buildHtmlTable(data) {
    var idx, idy, myObjx, myObjy, x, y, txtprev = "", txtcurr="", txt="";

    idx = data.name + "_prev";
    if (document.getElementById(idx).value != "") {
        myObjx = JSON.parse(document.getElementById(idx).value);
        txtprev = "";
        txtprev += "<table class='table table-striped table-bordered table-hover' id='datatables'>"
        txtprev += "<tr><td colspan='2'><center>Previous Data</center></td></tr>"
        for (x in myObjx) {
            txtprev += "<tr><td>" + x + "</td>";
            txtprev += "<td>" + myObjx[x] + "</td></tr>";
        }
        txtprev += "</table>"
    }

    idy = data.name + "_curr";
    if (document.getElementById(idy).value != "") {
        myObjy = JSON.parse(document.getElementById(idy).value);
        txtcurr = "";
        txtcurr += "<table class='table table-striped table-bordered table-hover' id='datatables'>"
        txtcurr += "<tr><td colspan='2'><center>Current Data</center></td></tr>"
        for (y in myObjy) {
            txtcurr += "<tr><td>" + y + "</td>";
            if (typeof myObjy[y] === "object") {
                txtcurr += "<td>" + JSON.stringify(myObjy[y]) + "</td></tr>";
            } else {
                txtcurr += "<td>" + myObjy[y] + "</td></tr>";
            }
        }
        txtcurr += "</table>"
    }

    txt += '<div class="modal fade" id="viewData" tabindex="-1" aria-hidden="true" style="width:100%">';
    if (txtprev != "" && txtcurr != "") {
        txt += '<div class="modal-dialog modal-lg">';
    } else {
        txt += '<div class="modal-dialog">';
    }
        txt += '<div class="modal-content">' +
                    '<div class="modal-header">' +
                        '<button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>' +
                        '<h4 class="modal-title">History Data</h4>' +
                    '</div>' +
                    '<div class="modal-body">' +
                        '<div class="row">';
    if (txtprev != "")
    {
        txt += '<div class="col-md-6">';
        txt += txtprev;
        txt += '</div>';
    }
    if (txtcurr != "") {
        txt += '<div class="col-md-6">';
        txt += txtcurr;
        txt += '</div>';
    }
                        
    txt +=               '</div>' +
                    '</div>' +
                    '<div class="modal-footer">' +
                        '<button type="button" class="btn dark btn-outline" data-dismiss="modal">Close</button>' +
                    '</div>' +
                '</div>' +
            '</div>' +
        '</div>';

    document.getElementById("dataoke").innerHTML = txt;
}