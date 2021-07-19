$(document).ready(function () {
    $("#MPOSTF").submit(function (event) {
        if ($("#KTP_NO").val() == "" && $("#FNAME").val() == "" && $("#LNAME").val() == "") {
            alert("Please, select one of filters");
            $("#KTP_NO").focus();
            return false;
        }

        return true;
    });
});