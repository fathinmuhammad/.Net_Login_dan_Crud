
jQuery(document).ready(function () {

    // event on submit
    $(document).on('click', '#saveFrm', function () {
        if ($('input[name="password"]').val() != '') {
            if ($('input[name="re_password"]').val() == '') {
                alert('Password Lama Wajib di Isi !');
                return false;
            }

            var pass1 = $('#password').val();
            var pass2 = $('#re_password').val();
            if (pass1 !== pass2) {
                alert('Password dan Re-Type Password tidak sesuai !');
                return false;
            }
        }
    });
});