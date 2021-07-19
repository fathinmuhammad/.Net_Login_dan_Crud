$(document).ready(function () {

    function clearModal() {
        $('#question').val('');
        document.getElementById('fieldtype').value = '';
    }

    if ($('#inspection_id').val() <= 0) {
        var oTable = $('#tplFrmH').dataTable({
            dom: 'Bfrtip',
            buttons: [
                {
                    text: 'Add Question',
                    action: function (e, dt, node, config) {
                        $('#ButtontplH').val("Add");
                        clearModal();
                        $("#addTplH").modal("show");
                    }
                }
            ],
            "paging": false,
            "ordering": false,
            "info": false,
            "searching": false
        });
    } else {
        var oTable = $('#tplFrmH').dataTable({
            "paging": false,
            "ordering": false,
            "info": false,
            "searching": false
        });
    }

    $(window).keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });

    $("#ButtontplH").on('click', function () {
        if ($('#question').val() == '') {
            alert('question field required');
            return false;
        }
        if ($('#fieldtype').val() == '') {
            alert('fieldtype required');
            return false;
        }
        if ($(this).val() == 'Add') {
            var i = 0;
            if (oTable.fnGetData().length >= 1) {
                i = (isNaN(parseInt($('#tplFrmH tbody tr:last').find('#idx').val())) ? 0 : parseInt($('#tplFrmH tbody tr:last').find('#idx').val())) + 1;
            }

            var selectFieldTxt = $("#fieldtype option:selected").text();
            var selectFieldVal = $("#fieldtype option:selected").val();
            var rowIdxes = oTable.fnAddData([
                '<input type="hidden" name="idx[]" class="idx" id="idx" value = "' + i + '" > ' +
                '<input type="hidden" name="Ansline[' + i + ']" id="ansline_' + i + '" value="[]" />' +
                '<input type="hidden" name="questVal[' + i + ']" id="questVal" value="' + document.forms['frmTplH'].elements["question"].value + '" />' + document.forms['frmTplH'].elements["question"].value,
                selectFieldTxt + '<input type="hidden" name="ftVal[' + i + ']" id="ftVal" value="' + selectFieldVal + '" />'//+ ' ' + document.forms['frmTplH'].elements["fieldtype"].value
                , ($('#inspection_id').val() <= 0 ? '<a href="#" class="Delline" id = "Delline_' + i + '" > Delete</a > ' : '') + '&nbsp; ' + '<a class="editline" id="editline_' + i + '"> Edit</a>' + (selectFieldVal == '3' || selectFieldVal == '7' || selectFieldVal == '8' ?
                    '&nbsp; ' + '<a href="#" class="Ansline" id="Ansline_@i"> Answer Tpl</a>' : '')
            ]);
            var rowTr = oTable.fnGetNodes(rowIdxes[0]);

            $(rowTr).addClass('tblRowTplH');
        } else {
            var i = $('#lineNum').val();
            var selectFieldTxt = $("#fieldtype option:selected").text();
            var selectFieldVal = $("#fieldtype option:selected").val();
            oTable.fnUpdate([
                '<input type="hidden" name="idx[]" class="idx" id="idx" value = "' + i + '" > ' +
                '<input type="hidden" name="Ansline[' + i + ']" id="ansline_' + i + '" value="[]" />' +
                '<input type="hidden" name="questVal[' + i + ']" id="questVal" value="' + document.forms['frmTplH'].elements["question"].value + '" />' + document.forms['frmTplH'].elements["question"].value,
                selectFieldTxt + '<input type="hidden" name="ftVal[' + i + ']" id="ftVal" value="' + selectFieldVal + '" />'//+ ' ' + document.forms['frmTplH'].elements["fieldtype"].value
                , ($('#inspection_id').val() <= 0 ? '<a href="#" class="Delline" id = "Delline_' + i + '" > Delete</a > ' : '') + '&nbsp;' + '<a class="editline" id="editline_' + i + '"> Edit</a>' + (selectFieldVal == '3' || selectFieldVal == '7' || selectFieldVal == '8' ?
                    '&nbsp; ' + '<a href="#" class="Ansline" id="Ansline_@i"> Answer Tpl</a>' : '')
            ], i, undefined, false);
        }

        $("#clsBtn").trigger("click");
        clearModal();

    });

    $('#tplFrmH').on('click', '.Delline', function () {
        if (window.confirm('Are you sure?')) {
            var table = $('#tplFrmH').DataTable();
            var row = $(this).parents('tr');

            if ($(row).hasClass('child')) {
                table.row($(row).prev('tr')).remove().draw();
            }
            else {
                table
                    .row($(this).parents('tr'))
                    .remove()
                    .draw();
            }

            var i = 0;
            $('#tplFrmH tbody tr.tblRowTplH').each(function () {
                $(this).closest('tr').find('#ansline_' + $(this).closest('tr').find('#idx').val()).attr('name', 'Ansline[' + i + ']');
                $(this).closest('tr').find('#ansline_' + $(this).closest('tr').find('#idx').val()).attr('id', 'ansline_' + i);
                $(this).closest('tr').find('#idx').val(i);
                $(this).closest('tr').find('#questVal').attr('name', 'questVal[' + i + ']');
                $(this).closest('tr').find('#ftVal').attr('name', 'ftVal[' + i + ']');
                i += 1;
            });
            //return true;
        } 

        return false;
    });

    $("#tplFrmH").on('click', '.editline', function () {
        var columnValues = $(this).parent().siblings().map(function () {
            return $(this).text();
        }).get();
        var myModal = $('#addTplH');

        var row = $(this).closest('tr').index();
        var quest = $(this).closest('tr').find('#questVal').val();
        var ft = $(this).closest('tr').find('#ftVal').val();
        $('#question', myModal).val(quest.trim()); //columnValues[0].trim());
        $('#fieldtype', myModal).val(ft); //columnValues[1].trim());
        $('#ButtontplH', myModal).val("Update");
        $('#lineNum', myModal).val($(this).closest('tr').index());

        myModal.modal("show");
        return false;
    });

    //ANSWER

    function clearModalAns() {
        $('#answer').val('');
        $('#answerdesc').val('');
    }
    if ($('#inspection_id').val() <= 0) {
        var oTableAns = $('#tplFrmAns').dataTable({
            dom: 'Bfrtip',
            buttons: [
                {
                    text: 'Add Answer',
                    action: function (e, dt, node, config) {
                        $('#ButtontplAns').val("Add");
                        clearModalAns();
                        $("#addTplAns").modal("show");
                    }
                }
            ],
            "paging": false,
            "ordering": false,
        });
    } else {
        var oTableAns = $('#tplFrmAns').dataTable({
            "paging": false,
            "ordering": false,
        });
    }

    $("#ButtontplAns").on('click', function () {
        if ($('#answer').val() == '') {
            alert('answer field required');
            return false;
        }
        if ($('#answerdesc').val() == '') {
            alert('answer description required');
            return false;
        }

        if ($(this).val() == 'Add') {
            var i = 0;
            if (oTableAns.fnGetData().length >= 1) {
                i = (isNaN(parseInt($('#tplFrmAns tbody tr:last').find('.idxAns').val())) ? 0 : parseInt($('#tplFrmAns tbody tr:last').find('.idxAns').val())) + 1;
            }

            var rowIdxes = oTableAns.fnAddData([
                '<input type="hidden" name="idxAns[]" class="idxAns" id="idx" value = "' + i + '" > ' +
                '<input type="hidden" name="AnsVal[' + i + ']" id="AnsVal" value="' + document.forms['frmTplAns'].elements["answer"].value + '" />' + document.forms['frmTplAns'].elements["answer"].value,
                '<input type="hidden" name="AnsDescVal[' + i + ']" id="AnsDescVal" value="' + document.forms['frmTplAns'].elements["answerdesc"].value + '" />' + document.forms['frmTplAns'].elements["answerdesc"].value,
                ($('#inspection_id').val() <= 0 ? '<a href="#" class="Delline" id = "Delline_' + i + '" > Delete</a>' : '') + '&nbsp; <a class="editline" id="editline_' + i + '"> Edit</a>'
            ]);
            var rowTr = oTableAns.fnGetNodes(rowIdxes[0]);

            $(rowTr).addClass('tblRowTplAns');
        } else {
            var i = $('#lineNumAns').val();
            oTableAns.fnUpdate([
                '<input type="hidden" name="idxAns[]" class="idxAns" id="idx" value = "' + i + '" > ' +
                '<input type="hidden" name="AnsVal[' + i + ']" id="AnsVal" value="' + document.forms['frmTplAns'].elements["answer"].value + '" />' + document.forms['frmTplAns'].elements["answer"].value,
                '<input type="hidden" name="AnsDescVal[' + i + ']" id="AnsDescVal" value="' + document.forms['frmTplAns'].elements["answerdesc"].value + '" />' + document.forms['frmTplAns'].elements["answerdesc"].value,
                ($('#inspection_id').val() <= 0 ? '<a href="#" class="Delline" id = "Delline_' + i + '" > Delete</a>' : '') + '&nbsp; <a class="editline" id="editline_' + i + '"> Edit</a>'
            ], i, undefined, false);
        }

        $("#clsBtnAns").trigger("click");
        clearModalAns();
    });

    $('#tplFrmAns').on('click', '.Delline', function () {
        if (window.confirm('Are you sure?')) {
            var table = $('#tplFrmAns').DataTable();
            var row = $(this).parents('tr');

            if ($(row).hasClass('child')) {
                table.row($(row).prev('tr')).remove().draw();
            }
            else {
                table
                    .row($(this).parents('tr'))
                    .remove()
                    .draw();
            }

            var i = 0;
            $('#tplFrmAns tbody tr.tblRowTplAns').each(function () {
                $(this).closest('tr').find('#idxAns').val(i);
                $(this).closest('tr').find('#AnsVal').attr('name', 'AnsVal[' + i + ']');
                $(this).closest('tr').find('#AnsDescVal').attr('name', 'AnsDescVal[' + i + ']');
                i += 1;
            });
            //return true;
        } 

        return false;
    });

    $("#tplFrmAns").on('click', '.editline', function () {
        var columnValues = $(this).parent().siblings().map(function () {
            return $(this).text();
        }).get();
        var myModal = $('#addTplAns');

        var row = $(this).closest('tr').index();
        var quest = $(this).closest('tr').find('#AnsVal').val();
        var desc = $(this).closest('tr').find('#AnsDescVal').val();
        $('#answer', myModal).val(quest.trim()); //columnValues[0].trim());
        $('#answerdesc', myModal).val(desc.trim()); //columnValues[0].trim());
        $('#ButtontplAns', myModal).val("Update");
        $('#lineNumAns', myModal).val($(this).closest('tr').index());

        myModal.modal("show");
        return false;
    });

    //END ANSWER

    //ANSWER Header

    function clearModalAnsH() {
        $('#answerH').val('');
        $('#answerdescH').val('');
    }

    var oTableAnsH = $('#tplFrmAnsH').dataTable({
        paging: false,
        ordering: false,
        info: false,
        searching: false
    });

    $("#ButtontplAnsH").on('click', function () {
        if ($('#answerH').val() == '') {
            alert('answer field required');
            return false;
        }
        if ($('#answerdescH').val() == '') {
            alert('answer description required');
            return false;
        }

        var oTableAnsH = $('#tplFrmAnsH').dataTable();
        var ansObj = JSON.parse($('#ansline_' + $('#lineNumQuesH').val()).val());

        var myModal = $('#addTplAnsH');
        var ansH = $('input[name="answerH"]').val();
        var ansdH = $('#answerdescH', myModal).val();
        if ($(this).val() == 'Save') {
            var i = 0;
            if (oTableAnsH.fnGetData().length >= 1) {
                i = (isNaN(parseInt($('#tplFrmAnsH tbody tr:last').find('#idxAnsH').val())) ? 0 : parseInt($('#tplFrmAnsH tbody tr:last').find('#idxAnsH').val())) + 1;
            }

            var rowIdxes = oTableAnsH.fnAddData([
                '<input type="hidden" name="idxAnsH[]" class="idxAnsH" id="idxAnsH" value="' + i + '" > ' +
                '<input type="hidden" name="AnsValH[' + i + ']" id="AnsValH" value="' + ansH + '" />' + ansH,
                '<input type="hidden" name="AnsDescValH[' + i + ']" id="AnsDescValH" value="' + $('#answerdescH').val() + '" />' + $('#answerdescH').val(),
                '<a href="#" class="DellineH" id = "Delline_' + i + '" > Delete</a > &nbsp; <a class="editlineH" id="editline_' + i + '"> Edit</a>'
            ]);
            var rowTr = oTableAnsH.fnGetNodes(rowIdxes[0]);

            var obj = {};
            obj["value"] = ansH;
            obj["desc"] = ansdH;

            ansObj.push(obj);
            $('#ansline_' + $('#lineNumQuesH').val()).val(JSON.stringify(ansObj));
        } else {
            var i = $('#lineNumAnsH').val();
            oTableAnsH.fnUpdate([
                '<input type="hidden" name="idxAnsH[]" class="idxAnsH" id="idxAnsH" value="' + i + '" > ' +
                '<input type="hidden" name="AnsValH[' + i + ']" id="AnsValH" value="' + ansH + '" />' + ansH,
                '<input type="hidden" name="AnsDescValH[' + i + ']" id="AnsDescValH" value="' + $('#answerdescH').val() + '" />' + $('#answerdescH').val(),
                '<a href="#" class="DellineH" id = "Delline_' + i + '" > Delete</a > &nbsp; <a class="editlineH" id="editline_' + i + '"> Edit</a>'
            ], i, undefined, false);

            ansObj[i]["value"] = ansH;
            ansObj[i]["desc"] = ansdH;
            $('#ansline_' + $('#lineNumQuesH').val()).val(JSON.stringify(ansObj));
        }

        //$("#clsBtnAnsH").trigger("click");
        $(this).val('Save');
        clearModalAnsH();
    });

    $('#tplFrmAnsH').on('click', '.DellineH', function () {
        if (window.confirm('Are you sure?')) {
            var table = $('#tplFrmAnsH').DataTable();
            var row = $(this).parents('tr');
            var idx = $(this).closest('tr').index();
            var ansObj = JSON.parse($('#ansline_' + $('#lineNumQuesH').val()).val());
            if ($(row).hasClass('child')) {
                table.row($(row).prev('tr')).remove().draw();
            }
            else {
                table
                    .row($(this).parents('tr'))
                    .remove()
                    .draw();
            }
            ansObj.splice(idx, 1);
            $('#ansline_' + $('#lineNumQuesH').val()).val(JSON.stringify(ansObj));
            var i = 0;
            $('#tplFrmAnsH tbody tr.tblRowTplAns').each(function () {
                $(this).closest('tr').find('#idxAns').val(i);
                $(this).closest('tr').find('#AnsVal').attr('name', 'AnsVal[' + i + ']');
                $(this).closest('tr').find('#AnsDescVal').attr('name', 'AnsDescVal[' + i + ']');
                i += 1;
            });
            //return true;
        } else {
            //return false;
        }

        return false;
    });

    $("#resetAnsH").on('click', function () {
        $('#ButtontplAnsH').val("Save");
    });

    $("#tplFrmAnsH").on('click', '.editlineH', function () {
        var columnValues = $(this).parent().siblings().map(function () {
            return $(this).text();
        }).get();

        var myModal = $('#addTplAnsH');
        
        var row = $(this).closest('tr').index();
        var quest = $(this).closest('tr').find('#AnsValH').val();
        var desc = $(this).closest('tr').find('#AnsDescValH').val();
        $('#answerH', myModal).val(quest.trim()); //columnValues[0].trim());
        $('#answerdescH', myModal).val(desc.trim()); //columnValues[0].trim());
        $('#ButtontplAnsH', myModal).val("Update");
        $('#lineNumAnsH', myModal).val(row);
        
        return false;
    });

    $("#tplFrmH").on('click', '.Ansline', function () {
        var columnValues = $(this).parent().siblings().map(function () {
            return $(this).text();
        }).get();

        var dataQ = JSON.parse($('#ansline_' + $(this).closest('tr').index()).val());//JSON.parse('[{"value": "Tiger Nixon","desc": "System Architect"},{"value": "Garrett Winters","desc": "Director"}]');
        var oTableAnsH = $('#tplFrmAnsH').dataTable();
        oTableAnsH.dataTable(//{
            //destroy: false,
            //processing : true,
            //"aaData": dataQ,
            //"aoColumns": [
            //    {
            //        data: 'value',
            //        render: function (data, type, row, meta) {
            //            return '<input type="hidden" name="idxAnsH[]" id="idxAnsH" value="' + meta.row + '" /> <input type="hidden" name="AnsValH[' + meta.row + ']" id="AnsValH" value="' + data + '" />' + data;
            //        }
            //    },
            //    {
            //        data: 'desc',
            //        render: function (data, type, row, meta) {
            //            return '<input type="hidden" name="AnsDescValH[' + meta.row + ']" id="AnsDescValH" value="' + data + '" />' + data;
            //        }
            //    },
            //    {
            //        data: '', render: function (data, type, row, meta) {
            //            return '<a href="#" class="DellineH" > Delete</a > &nbsp; <a class="editlineH"> Edit</a>';
            //        }//,defaultContent: '<a href="#" class="DellineH" > Delete</a > &nbsp; <a class="editlineH"> Edit</a>'
            //    }
            //]
    //    }
        ).fnClearTable();

        $.each(dataQ, function (i, item) {
            oTableAnsH.fnAddData([
                '<input type="hidden" name="idxAnsH[]" class="idxAnsH" id="idxAnsH" value="' + i + '" > ' +
                '<input type="hidden" name="AnsValH[' + i + ']" id="AnsValH" value="' + item.value + '" />' + item.value,
                '<input type="hidden" name="AnsDescValH[' + i + ']" id="AnsDescValH" value="' + item.desc + '" />' + item.desc,
                '<a href="#" class="DellineH" id = "Delline_' + i + '" > Delete</a > &nbsp; <a class="editlineH" id="editline_' + i + '"> Edit</a>'
            ]);
        });

        var myModal = $('#addTplAnsH');

        var row = $(this).closest('tr').index();
        //$('#lineNumAnsH', myModal).val($(this).closest('tr').index());
        $('#lineNumQuesH', myModal).val($(this).closest('tr').index());
        
        myModal.modal("show");
        return false;
    });

    //END ANSWER Header

});