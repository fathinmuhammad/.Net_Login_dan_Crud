
function transInfo(obj, id) {
    var url = $("#urlTransInfo").val() + '?obj=' + obj + '&id=' + id; 
    $.post(url, {}, function (data) {
        $("#created_user").val('');
        $("#created_date").val('');
        $("#updated_user").val('');
        $("#updated_date").val('');
        $("#approval_user").val('');
        $("#approval_date").val('');

        $("#created_user").val(data.created_fullname);
        $("#created_date").val(data.created_date);
        $("#updated_user").val(data.updated_fullname);
        $("#updated_date").val(data.updated_date); 
        $("#approval_user").val(data.approve_fullname);
        $("#approval_date").val(data.approval_date);
    });
}