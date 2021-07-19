var maskmoney = function () {

    return {
        //main function to initiate the module
        init: function () {
            $('.currency').maskMoney({ thousands: '.', decimal: ',', precision: 2 });
        }

    };

}();

var maskmoney2 = function () {

    return {
        //main function to initiate the module
        init: function () {
            $('.currency2').maskMoney({ thousands: '.', decimal: ',', precision: 0, allowZero: true, defaultZero: false });
        }

    };

}();

jQuery(document).ready(function () {
    maskmoney.init();
    maskmoney2.init();
});