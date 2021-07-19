var isClose = false;
var rtn = false;
document.onkeydown = checkKeycode;
function checkKeycode(e) {
    var keycode;
    var ctrlkey;
    if (window.event) {
        keycode = window.event.keyCode;
        ctrlkey = window.event.ctrlKey;
    }
    else if (e) {
        keycode = e.which;
        ctrlkey = e.ctrlKey;
    }
    if (keycode == 116 || (keycode == 116 && ctrlkey == true)) {
        isClose = true;
    }
    //    alert(keycode);
}

function confirms() {
    var rtn = confirm('are you sure ?');
    if (rtn == true) {
        isClose = true;
    }
    return rtn;
}
//alert(isClose);
window.onmousedown = function () {
    if ((window.event.clientX < 0) || (window.event.clientY < 0)) {
        isClose = true;
    }
};

window.onbeforeunload = function () {
    if (isClose == false) {
        $.ajax({
            url: "/bps/assessment/Release?code=" + $("#enc_id").val(),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            method: "GET",
            timeout: 0,
            data: [],
            success: function (data) {
            },
            error: function (msg) {
                //alert(msg);
            }
        });
    }
    isClose = false;
}
