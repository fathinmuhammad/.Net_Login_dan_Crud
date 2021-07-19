$(document).ready(function () {
    var table = $('#dtTables').DataTable(
        //{
        //"processing": true,
        //"serverSide": true,
        //"ajax": {
        //    "url": ReqUrl,
        //    "type":"GET"
        //}
        //}
    );

    $(document).on('click', '#submitUsr', function () {
        var ReqUrl = $('#dtTables').data('request-url');
        table.destroy();
        table = $('#dtTables').DataTable({
            "processing": true,
            "serverSide": true,
            "ajax": {
                "url": ReqUrl,
                "type": "GET",
                "data": function (d) {
                    d.username = $('#username').val();
                    d.fullname = $('#fullname').val();

                }
            }
        });
    });

    $(document).on('click', '#submitPenerbit', function () {
        var ReqUrl = $('#dtTables').data('request-url');
        table.destroy();
        table = $('#dtTables').DataTable({
            "processing": true,
            "serverSide": true,
            "ajax": {
                "url": ReqUrl,
                "type": "GET",
                "data": function (d) {
                    d.nama = $('#nama').val();
                    d.alamat = $('#alamat').val();

                }
            }
        });
    });

    $(document).on('click', '#submitBuku', function () {
        var ReqUrl = $('#dtTables').data('request-url');
        table.destroy();
        table = $('#dtTables').DataTable({
            "processing": true,
            "serverSide": true,
            "ajax": {
                "url": ReqUrl,
                "type": "GET",
                "data": function (d) {
                    d.judul = $('#judul').val();
                    d.penerbit = $('#penerbit').val();

                }
            }
        });
    });

});