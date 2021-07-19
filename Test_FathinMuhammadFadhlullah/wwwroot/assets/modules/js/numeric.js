var numeric = function () {

    return {
        //main function to initiate the module
        init: function () {
            $(".numeric").numeric_input({ thousands: '.', decimal: ',', precision: 2 });
        }

    };

}();

var numericc = function () {

    return {
        //main function to initiate the module
        init: function () {
            $(".numericc").numeric_input({ thousands: '.', decimal: ',', precision: 0 });
        }

    };

}();

var numericrate = function () {

    return {
        //main function to initiate the module
        init: function () {
            $(".numericrate").numeric_input({ thousands: '.', decimal: ',', precision: 0, });
        }

    };

}();

var numNoDigitGroup = function () {

    return {
        //main function to initiate the module
        init: function () {
            $(".numNoDigitGroup").numeric_input({ thousands: '', decimal: '', precision: 0 });
        }

    };

}();

jQuery(document).ready(function () {
    numeric.init();
    numericc.init();
    numNoDigitGroup.init();
    numericrate.init();
});

$(document).ready(function () {
    $("#MRate").submit(function (event) {
        var term_type = $("#insurance_term_type").val();
        var rate_val = $("#rate_value").val();
        if (term_type <= 0) {
            alert("Term Type cannot be null or zero value");
        } else if (rate_val <= 0) {
            alert("Rate Value cannot be null or zero value");
        } else {
            return true;
        }
        return false;
    });
});