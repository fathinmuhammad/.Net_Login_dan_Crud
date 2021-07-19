var phoneNumber = function () {
    return {
        init: function () {
            $(".mask_phone").inputmask("mask", { mask: "(999) 999-9999" })
        }
    }
}

jQuery(document).ready(function () {
    phoneNumber.init();
});