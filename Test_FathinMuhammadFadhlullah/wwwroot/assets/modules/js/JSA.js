$(document).ready(function () {

    function clearModal() {
        var title = "Add Job Task";
        document.getElementById("Title").innerHTML = title;
        document.getElementById("job_task").disabled = false;
        $('#job_task').val('');
        document.getElementById('hazard_id').value = '';
        $('#potential_harm').val('');
        $('#consecuences').val('');
        document.getElementById('value_l').value = '';
        document.getElementById('value_s').value = '';
        $('#value_r').val('');
        $('#value_rs').val('');
        $('#det_control').val('');
        document.getElementById('control_id').value = '';
    }

    $(document).on('click', '#addJSAHDR', function () {
        $("#AddNewJSA").val('Add');
        clearModal();
    });

    $("#AddNewJSA").on('click', function () {     

        var i;
        var selectHazardTxt;
        var selectHazardVal;
        var selectLTxt;
        var selectLVal;
        var selectSTxt;
        var selectSVal;
        var selectHierarchyTxt;
        var selectHierarchyVal;
        //var parent_id;
        var rowIdxes;
        var rowTr;
        //var rowTrChild;

        if ($(this).val() === 'Add') {

        if ($('#job_task').val() === '') {
            alert('Job Task is required');
            $('#job_task').focus();
            return false;
        }
        if ($('#hazard_id').val() === '') {
            alert('Hazard is required');
            $('#Hazard').focus();
            return false;
        }
        if ($('#potential_harm').val() === '') {
            alert('Potential Harm is required');
            $('#potential_harm').focus();
            return false;
        }
        if ($('#consecuences').val() === '') {
            alert('Consecuences is required');
            $('#consecuences').focus();
            return false;
        }
        if ($('#value_l').val() === '') {
            alert('Inherent Risk L is required');
            $('#value_l').focus();
            return false;
        }
        if ($('#value_s').val() === '') {
            alert('Inherent Risk S is required');
            $('#value_s').focus();
            return false;
        }
        if ($('#value_r').val() === '') {
            alert('Inherent Risk R is required');
            $('#value_r').focus();
            return false;
        }
        if ($('#value_rs').val() === '') {
            alert('Inherent Risk RL is required');
            $('#value_rs').focus();
            return false;
        }
        if ($('#det_control').val() === '') {
            alert('Determining control is required');
            $('#det_control').focus();
            return false;
        }
        if ($('#control_id').val() === '') {
            alert('Hierarchy of control is required');
            $('#control_id').focus();
            return false;
        }

            job_task = document.forms['frmJSA'].elements["job_task"].value;
            selectHazardTxt = $("#hazard_id option:selected").text();
            selectHazardVal = $("#hazard_id option:selected").val();
            potential_harm = document.forms['frmJSA'].elements["potential_harm"].value;
            consecuences = document.forms['frmJSA'].elements["consecuences"].value;
            selectLTxt = $("#value_l option:selected").text();
            selectLVal = $("#value_l option:selected").val();
            selectSTxt = $("#value_s option:selected").text();
            selectSVal = $("#value_s option:selected").val();
            r = document.forms['frmJSA'].elements["value_r"].value;
            rs = document.forms['frmJSA'].elements["value_rs"].value;
            det_control = document.forms['frmJSA'].elements["det_control"].value;
            selectHierarchyTxt = $("#control_id option:selected").text();
            selectHierarchyVal = $("#control_id option:selected").val();

            var jobtask = {
                job_task: job_task,
                Hazard: selectHazardVal,
                Hazardtext: selectHazardTxt,
                potential_harm: potential_harm,
                consecuences: consecuences,
                L: selectLVal,
                S: selectSVal,
                R: r,
                RS: rs,
                det_control: det_control,
                Hierarchy: selectHierarchyVal,
                Hierarchytext: selectHierarchyTxt
            };

            $.ajax({
                type: "POST",
                url: $("#urlJobTask").val(),
                data: jobtask,
                success: function (data) {
                    var Job = JSON.parse(data);
                    //console.log(JSON.stringify(data));
                    //var parent_id = 0;
                    //var oTable = jQuery('#JSAForm >tbody >tr');
                    //var RowID = ('#data-id');

                    var parent_id = jQuery('#JSAForm >tbody >tr').length + 1;

                    //if (oTable.length >= 1) {
                    //    var parent_id = oTable.length;
                    //}                    

                    var row = `<tr id="${parent_id}">
  						            <td>
                                        <input type="hidden" name="parent[${parent_id}]" id="parent" value="0" />
                                        <input type="hidden" name="jtVal[${parent_id}]" id="jtVal" value="${Job.job_task}" /> ${Job.job_task} 
                                    </td>
  						            <td><input type="hidden" name="hVal[${parent_id}]" id="hVal" value="${Job.Hazard}" /> ${Job.Hazardtext}</td>
                                    <td><input type="hidden" name="phVal[${parent_id}]" id="phVal" value="${Job.potential_harm}" /> ${Job.potential_harm}</td>
                                    <td><input type="hidden" name="cVal[${parent_id}]" id="cVal" value="${Job.consecuences}" /> ${Job.consecuences}</td>
                                    <td><input type="hidden" name="lVal[${parent_id}]" id="lVal" value="${Job.L}" /> ${Job.L}</td>
                                    <td><input type="hidden" name="sVal[${parent_id}]" id="sVal" value="${Job.S}" /> ${Job.S}</td>
                                    <td><input type="hidden" name="rVal[${parent_id}]" id="rVal" value="${Job.R}" /> ${Job.R}</td>
                                    <td><input type="hidden" name="rsVal[${parent_id}]" id="rsVal" value="${Job.RS}" /> ${Job.RS}</td>
                                    <td><input type="hidden" name="dcVal[${parent_id}]" id="dcVal" value="${Job.det_control}" /> ${Job.det_control}</td>
                                    <td><input type="hidden" name="hyVal[${parent_id}]" id="hyVal" value="${Job.Hierarchy}" /> ${Job.Hierarchytext}</td>
                                    <td>
                                        <a href="#" class="Delline" id = "${parent_id}" > <i class="fa fa-trash-o"></i></a> &nbsp;
                                        <a class="editline" id="${parent_id}"> <i class="fa fa-pencil"></i></a> &nbsp;
                                        <a class="addsub" id="${parent_id}"> <i class="fa fa-plus"></i></a>
                                    </td>
                                </tr>`
                    var table = $('#tblBRow')
                    table.append(row)
                },
                error: function (error) {
                    console.log(error);
                }
            });
        } else if ($(this).val() === 'AddSub') {

            if ($('#job_task').val() === '') {
                alert('Job Task is required');
                $('#job_task').focus();
                return false;
            }
            if ($('#hazard_id').val() === '') {
                alert('Hazard is required');
                $('#Hazard').focus();
                return false;
            }
            if ($('#potential_harm').val() === '') {
                alert('Potential Harm is required');
                $('#potential_harm').focus();
                return false;
            }
            if ($('#consecuences').val() === '') {
                alert('Consecuences is required');
                $('#consecuences').focus();
                return false;
            }
            if ($('#value_l').val() === '') {
                alert('Inherent Risk L is required');
                $('#value_l').focus();
                return false;
            }
            if ($('#value_s').val() === '') {
                alert('Inherent Risk S is required');
                $('#value_s').focus();
                return false;
            }
            if ($('#value_r').val() === '') {
                alert('Inherent Risk R is required');
                $('#value_r').focus();
                return false;
            }
            if ($('#value_rs').val() === '') {
                alert('Inherent Risk RL is required');
                $('#value_rs').focus();
                return false;
            }
            if ($('#det_control').val() === '') {
                alert('Determining control is required');
                $('#det_control').focus();
                return false;
            }
            if ($('#control_id').val() === '') {
                alert('Hierarchy of control is required');
                $('#control_id').focus();
                return false;
            }

            parent = document.forms['frmJSA'].elements["id_parent"].value;
            job_task = document.forms['frmJSA'].elements["job_task"].value;
            selectHazardTxt = $("#hazard_id option:selected").text();
            selectHazardVal = $("#hazard_id option:selected").val();
            potential_harm = document.forms['frmJSA'].elements["potential_harm"].value;
            consecuences = document.forms['frmJSA'].elements["consecuences"].value;
            selectLTxt = $("#value_l option:selected").text();
            selectLVal = $("#value_l option:selected").val();
            selectSTxt = $("#value_s option:selected").text();
            selectSVal = $("#value_s option:selected").val();
            r = document.forms['frmJSA'].elements["value_r"].value;
            rs = document.forms['frmJSA'].elements["value_rs"].value;
            det_control = document.forms['frmJSA'].elements["det_control"].value;
            selectHierarchyTxt = $("#control_id option:selected").text();
            selectHierarchyVal = $("#control_id option:selected").val();

            var jobtask = {
                parent: parent,
                job_task: job_task,
                Hazard: selectHazardVal,
                Hazardtext: selectHazardTxt,
                potential_harm: potential_harm,
                consecuences: consecuences,
                L: selectLVal,
                S: selectSVal,
                R: r,
                RS: rs,
                det_control: det_control,
                Hierarchy: selectHierarchyVal,
                Hierarchytext: selectHierarchyTxt
            };

            $.ajax({
                type: "POST",
                url: $("#urlJobTask").val(),
                data: jobtask,
                success: function (data) {
                    var Job = JSON.parse(data);
                    var parent_id = Job.parent;
                    var child_id = jQuery('#JSAForm >tbody >tr').length + 1;
                    
                    //var oTable = jQuery('#JSAForm >tbody >tr');
                    //var RowID = ('#data-id');

                    //console.log(RowID);

                    //if (oTable.length >= 1) {
                    //    var child_id = oTable.length;
                    //}             

                    var row = `<tr id="${child_id}" class="Child${parent_id}">
  						            <td>
                                        <input type="hidden" name="child[${child_id}]" id="child" value="${child_id}" />
                                        <input type="hidden" name="parent[${child_id}]" id="parent" value="${parent_id}" />
                                        <input type="hidden" name="jtVal[${child_id}]" id="jtVal" class="${parent_id}" value="${Job.job_task}" />
                                    </td>
  						            <td><input type="hidden" name="hVal[${child_id}]" id="hVal" value="${Job.Hazard}" /> ${Job.Hazardtext}</td>
                                    <td><input type="hidden" name="phVal[${child_id}]" id="phVal" value="${Job.potential_harm}" /> ${Job.potential_harm}</td>
                                    <td><input type="hidden" name="cVal[${child_id}]" id="cVal" value="${Job.consecuences}" /> ${Job.consecuences}</td>
                                    <td><input type="hidden" name="lVal[${child_id}]" id="lVal" value="${Job.L}" /> ${Job.L}</td>
                                    <td><input type="hidden" name="sVal[${child_id}]" id="sVal" value="${Job.S}" /> ${Job.S}</td>
                                    <td><input type="hidden" name="rVal[${child_id}]" id="rVal" value="${Job.R}" /> ${Job.R}</td>
                                    <td><input type="hidden" name="rsVal[${child_id}]" id="rsVal" value="${Job.RS}" /> ${Job.RS}</td>
                                    <td><input type="hidden" name="dcVal[${child_id}]" id="dcVal" value="${Job.det_control}" /> ${Job.det_control}</td>
                                    <td><input type="hidden" name="hyVal[${child_id}]" id="hyVal" value="${Job.Hierarchy}" /> ${Job.Hierarchytext}</td>
                                    <td>
                                        <a href="#" class="DellineSub" id = "${child_id}" > <i class="fa fa-trash-o"></i></a> &nbsp;
                                        <a class="editlineSub" id="${child_id}"> <i class="fa fa-pencil"></i></a> &nbsp;
                                    </td>
                                </tr>`

                    //row.After($('#JSAForm tbody tr:(' + parent_id + ')'));
                    //var table = $('#JSAForm > tbody > tr:nth-child(' + parent_id +')');
                    var table = $('#' + parent_id + '');
                    table.after(row);
                    console.log(table);
                },
                error: function (error) {
                    console.log(error);
                }
            });
        } else if ($(this).val() === 'Update') {

            if ($('#job_task').val() === '') {
                alert('Job Task is required');
                $('#job_task').focus();
                return false;
            }
            if ($('#hazard_id').val() === '') {
                alert('Hazard is required');
                $('#Hazard').focus();
                return false;
            }
            if ($('#potential_harm').val() === '') {
                alert('Potential Harm is required');
                $('#potential_harm').focus();
                return false;
            }
            if ($('#consecuences').val() === '') {
                alert('Consecuences is required');
                $('#consecuences').focus();
                return false;
            }
            if ($('#value_l').val() === '') {
                alert('Inherent Risk L is required');
                $('#value_l').focus();
                return false;
            }
            if ($('#value_s').val() === '') {
                alert('Inherent Risk S is required');
                $('#value_s').focus();
                return false;
            }
            if ($('#value_r').val() === '') {
                alert('Inherent Risk R is required');
                $('#value_r').focus();
                return false;
            }
            if ($('#value_rs').val() === '') {
                alert('Inherent Risk RL is required');
                $('#value_rs').focus();
                return false;
            }
            if ($('#det_control').val() === '') {
                alert('Determining control is required');
                $('#det_control').focus();
                return false;
            }
            if ($('#control_id').val() === '') {
                alert('Hierarchy of control is required');
                $('#control_id').focus();
                return false;
            }

            parent = document.forms['frmJSA'].elements["id_parent"].value;
            job_task = document.forms['frmJSA'].elements["job_task"].value;
            selectHazardTxt = $("#hazard_id option:selected").text();
            selectHazardVal = $("#hazard_id option:selected").val();
            potential_harm = document.forms['frmJSA'].elements["potential_harm"].value;
            consecuences = document.forms['frmJSA'].elements["consecuences"].value;
            selectLTxt = $("#value_l option:selected").text();
            selectLVal = $("#value_l option:selected").val();
            selectSTxt = $("#value_s option:selected").text();
            selectSVal = $("#value_s option:selected").val();
            r = document.forms['frmJSA'].elements["value_r"].value;
            rs = document.forms['frmJSA'].elements["value_rs"].value;
            det_control = document.forms['frmJSA'].elements["det_control"].value;
            selectHierarchyTxt = $("#control_id option:selected").text();
            selectHierarchyVal = $("#control_id option:selected").val();

            var jobtask = {
                parent: parent,
                job_task: job_task,
                Hazard: selectHazardVal,
                Hazardtext: selectHazardTxt,
                potential_harm: potential_harm,
                consecuences: consecuences,
                L: selectLVal,
                S: selectSVal,
                R: r,
                RS: rs,
                det_control: det_control,
                Hierarchy: selectHierarchyVal,
                Hierarchytext: selectHierarchyTxt
            };

            $.ajax({
                type: "POST",
                url: $("#urlJobTask").val(),
                data: jobtask,
                success: function (data) {
                    var Job = JSON.parse(data);
                    //console.log(JSON.stringify(data));

                    var parent_id = Job.parent;

                    var row = ` <td>
                                    <input type="hidden" name="parent[${parent_id}]" id="parent" value="0" />
                                    <input type="hidden" name="jtVal[${parent_id}]" id="jtVal" value="${Job.job_task}" /> ${Job.job_task} 
                                </td>
  						        <td><input type="hidden" name="hVal[${parent_id}]" id="hVal" value="${Job.Hazard}" /> ${Job.Hazardtext}</td>
                                <td><input type="hidden" name="phVal[${parent_id}]" id="phVal" value="${Job.potential_harm}" /> ${Job.potential_harm}</td>
                                <td><input type="hidden" name="cVal[${parent_id}]" id="cVal" value="${Job.consecuences}" /> ${Job.consecuences}</td>
                                <td><input type="hidden" name="lVal[${parent_id}]" id="lVal" value="${Job.L}" /> ${Job.L}</td>
                                <td><input type="hidden" name="sVal[${parent_id}]" id="sVal" value="${Job.S}" /> ${Job.S}</td>
                                <td><input type="hidden" name="rVal[${parent_id}]" id="rVal" value="${Job.R}" /> ${Job.R}</td>
                                <td><input type="hidden" name="rsVal[${parent_id}]" id="rsVal" value="${Job.RS}" /> ${Job.RS}</td>
                                <td><input type="hidden" name="dcVal[${parent_id}]" id="dcVal" value="${Job.det_control}" /> ${Job.det_control}</td>
                                <td><input type="hidden" name="hyVal[${parent_id}]" id="hyVal" value="${Job.Hierarchy}" /> ${Job.Hierarchytext}</td>
                                <td>
                                    <a href="#" class="Delline" id = "${parent_id}" > <i class="fa fa-trash-o"></i></a> &nbsp;
                                    <a class="editline" id="${parent_id}"> <i class="fa fa-pencil"></i></a> &nbsp;
                                    <a class="addsub" id="${parent_id}"> <i class="fa fa-plus"></i></a>
                                </td>`
                    var table = $('#tblBRow > tr#' + parent_id);
                    console.log(table);
                    table.empty().append(row);
                    //table.append(row);
                },
                error: function (error) {
                    console.log(error);
                }
            });
        } else if ($(this).val() === 'UpdateSub') {

            if ($('#job_task').val() === '') {
                alert('Job Task is required');
                $('#job_task').focus();
                return false;
            }
            if ($('#hazard_id').val() === '') {
                alert('Hazard is required');
                $('#Hazard').focus();
                return false;
            }
            if ($('#potential_harm').val() === '') {
                alert('Potential Harm is required');
                $('#potential_harm').focus();
                return false;
            }
            if ($('#consecuences').val() === '') {
                alert('Consecuences is required');
                $('#consecuences').focus();
                return false;
            }
            if ($('#value_l').val() === '') {
                alert('Inherent Risk L is required');
                $('#value_l').focus();
                return false;
            }
            if ($('#value_s').val() === '') {
                alert('Inherent Risk S is required');
                $('#value_s').focus();
                return false;
            }
            if ($('#value_r').val() === '') {
                alert('Inherent Risk R is required');
                $('#value_r').focus();
                return false;
            }
            if ($('#value_rs').val() === '') {
                alert('Inherent Risk RL is required');
                $('#value_rs').focus();
                return false;
            }
            if ($('#det_control').val() === '') {
                alert('Determining control is required');
                $('#det_control').focus();
                return false;
            }
            if ($('#control_id').val() === '') {
                alert('Hierarchy of control is required');
                $('#control_id').focus();
                return false;
            }

            child = document.forms['frmJSA'].elements["id_child"].value;
            parent = document.forms['frmJSA'].elements["id_parent"].value;
            job_task = document.forms['frmJSA'].elements["job_task"].value;
            selectHazardTxt = $("#hazard_id option:selected").text();
            selectHazardVal = $("#hazard_id option:selected").val();
            potential_harm = document.forms['frmJSA'].elements["potential_harm"].value;
            consecuences = document.forms['frmJSA'].elements["consecuences"].value;
            selectLTxt = $("#value_l option:selected").text();
            selectLVal = $("#value_l option:selected").val();
            selectSTxt = $("#value_s option:selected").text();
            selectSVal = $("#value_s option:selected").val();
            r = document.forms['frmJSA'].elements["value_r"].value;
            rs = document.forms['frmJSA'].elements["value_rs"].value;
            det_control = document.forms['frmJSA'].elements["det_control"].value;
            selectHierarchyTxt = $("#control_id option:selected").text();
            selectHierarchyVal = $("#control_id option:selected").val();

            var jobtask = {
                child: child,
                parent: parent,
                job_task: job_task,
                Hazard: selectHazardVal,
                Hazardtext: selectHazardTxt,
                potential_harm: potential_harm,
                consecuences: consecuences,
                L: selectLVal,
                S: selectSVal,
                R: r,
                RS: rs,
                det_control: det_control,
                Hierarchy: selectHierarchyVal,
                Hierarchytext: selectHierarchyTxt
            };

            $.ajax({
                type: "POST",
                url: $("#urlJobTask").val(),
                data: jobtask,
                success: function (data) {
                    var Job = JSON.parse(data);
                    //console.log(JSON.stringify(data));

                    //var child_id = jQuery(this).attr('id');
                    var child_id = Job.child;

                    var row = ` <td>
                                    <input type="hidden" name="child[${child_id}]" id="child" value="${child_id}" />
                                    <input type="hidden" name="parent[${child_id}]" id="parent" value="${Job.parent}" />
                                    <input type="hidden" name="jtVal[${child_id}]" id="jtVal" class="${Job.parent}" value="${Job.job_task}" />
                                </td>
  						        <td><input type="hidden" name="hVal[${child_id}]" id="hVal" value="${Job.Hazard}" /> ${Job.Hazardtext}</td>
                                <td><input type="hidden" name="phVal[${child_id}]" id="phVal" value="${Job.potential_harm}" /> ${Job.potential_harm}</td>
                                <td><input type="hidden" name="cVal[${child_id}]" id="cVal" value="${Job.consecuences}" /> ${Job.consecuences}</td>
                                <td><input type="hidden" name="lVal[${child_id}]" id="lVal" value="${Job.L}" /> ${Job.L}</td>
                                <td><input type="hidden" name="sVal[${child_id}]" id="sVal" value="${Job.S}" /> ${Job.S}</td>
                                <td><input type="hidden" name="rVal[${child_id}]" id="rVal" value="${Job.R}" /> ${Job.R}</td>
                                <td><input type="hidden" name="rsVal[${child_id}]" id="rsVal" value="${Job.RS}" /> ${Job.RS}</td>
                                <td><input type="hidden" name="dcVal[${child_id}]" id="dcVal" value="${Job.det_control}" /> ${Job.det_control}</td>
                                <td><input type="hidden" name="hyVal[${child_id}]" id="hyVal" value="${Job.Hierarchy}" /> ${Job.Hierarchytext}</td>
                                <td>
                                    <a href="#" class="DellineSub" id = "${child_id}" > <i class="fa fa-trash-o"></i></a> &nbsp;
                                    <a class="editlineSub" id="${child_id}"> <i class="fa fa-pencil"></i></a>
                                </td>`
                    var table = $('#tblBRow > tr#' + child_id);
                    console.log(table);
                    table.empty().append(row);
                    //table.append(row);
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }

        $("#clsBtn").trigger("click");
        clearModal();

    });


    // Start Job Task
    $('#JSAForm').on('click', '.Delline', function () {
        var didConfirm = confirm("Are you sure You want to delete");
        if (didConfirm == true) {
            var id = jQuery(this).attr('id');
            var row = jQuery('#' + id);
            var child = jQuery('.Child' + id);

            row.remove();
            child.remove();
            return true;
        } else {
            return false;
        }
    });

    $("#JSAForm").on('click', '.editline', function () {
        var columnValues = $(this).parent().siblings().map(function () {
            return $(this).text();
        }).get();
        var myModal = $('#AddJSA');

        var row = $(this).closest('tr').index();
        var jobtask = $(this).closest('tr').find('#jtVal').val();
        var ha = $(this).closest('tr').find('#hVal').val().trim();
        var ph = $(this).closest('tr').find('#phVal').val();
        var c = $(this).closest('tr').find('#cVal').val();
        var l = $(this).closest('tr').find('#lVal').val().trim();
        var s = $(this).closest('tr').find('#sVal').val().trim();
        var r = $(this).closest('tr').find('#rVal').val();
        var rl = $(this).closest('tr').find('#rsVal').val();
        var d = $(this).closest('tr').find('#dcVal').val();
        var h = $(this).closest('tr').find('#hyVal').val().trim();
        var title = "Edit Job Task";
        var id_parent = jQuery(this).attr('id');

        document.getElementById("job_task").disabled = false;
        document.getElementById("Title").innerHTML = title;
        $('#id_parent').val(id_parent.trim());
        $('#job_task', myModal).val(jobtask.trim()); //columnValues[0].trim());
        $('#hazard_id', myModal).val(ha); //columnValues[1].trim());
        $('#potential_harm', myModal).val(ph.trim()); //columnValues[2].trim());
        $('#consecuences', myModal).val(c); //columnValues[3].trim());
        $('#value_l', myModal).val(l); //columnValues[4].trim());
        $('#value_s', myModal).val(s); //columnValues[5].trim());
        $('#value_r', myModal).val(r.trim()); //columnValues[6].trim());
        $('#value_rs', myModal).val(rl.trim()); //columnValues[7].trim());
        $('#det_control', myModal).val(d.trim()); //columnValues[8].trim());
        $('#control_id', myModal).val(h); //columnValues[9].trim());
        $('#AddNewJSA', myModal).val("Update");
        $('#lineNum', myModal).val($(this).closest('tr').index());

        myModal.modal("show");
        return false;
    });
    // End Job Task

    // Start Sub Job Task
    $("#JSAForm").on('click', '.addsub', function () {
        var myModal = $('#AddJSA');
        var id_parent = jQuery(this).attr('id');        
        var jobtask = $(this).closest('tr').find('#jtVal').val();
        var title = "Add Sub Job Task";
        document.getElementById("job_task").disabled = true;

        document.getElementById("Title").innerHTML = title;
        $('#id_parent').val(id_parent.trim());
        $('#job_task').val(jobtask.trim());
        document.getElementById('hazard_id').value = '';
        $('#potential_harm').val('');
        $('#consecuences').val('');
        document.getElementById('value_l').value = '';
        document.getElementById('value_s').value = '';
        $('#value_r').val('');
        $('#value_rs').val('');
        $('#det_control').val('');
        document.getElementById('control_id').value = '';
        $('#AddNewJSA', myModal).val("AddSub");

        myModal.modal("show");
        return false;
    });
    
    $("#JSAForm").on('click', '.editlineSub', function () {
        var columnValues = $(this).parent().siblings().map(function () {
            return $(this).text();
        }).get();
        var id = $(this).closest('tr').find('#parent').val();
        var myModal = $('#AddJSA');
        var jVal = ('.' + id);
        //console.log(jVal);

        var row = $(this).closest('tr').index();
        var parent = $(this).closest('tr').find('#parent').val().trim();
        var jobtask = $(this).closest('tr').find(jVal).val();
        var ha = $(this).closest('tr').find('#hVal').val().trim();
        var ph = $(this).closest('tr').find('#phVal').val();
        var c = $(this).closest('tr').find('#cVal').val();
        var l = $(this).closest('tr').find('#lVal').val().trim();
        var s = $(this).closest('tr').find('#sVal').val().trim();
        var r = $(this).closest('tr').find('#rVal').val();
        var rl = $(this).closest('tr').find('#rsVal').val();
        var d = $(this).closest('tr').find('#dcVal').val();
        var h = $(this).closest('tr').find('#hyVal').val().trim();
        var title = "Edit Sub Job Task";
        var child_id = jQuery(this).attr('id');

        document.getElementById("job_task").disabled = true;
        document.getElementById("Title").innerHTML = title;
        $('#id_child').val(child_id.trim());
        $('#id_parent').val(parent.trim());
        $('#job_task', myModal).val(jobtask.trim()); //columnValues[0].trim());
        $('#hazard_id', myModal).val(ha); //columnValues[1].trim());
        $('#potential_harm', myModal).val(ph.trim()); //columnValues[2].trim());
        $('#consecuences', myModal).val(c); //columnValues[3].trim());
        $('#value_l', myModal).val(l); //columnValues[4].trim());
        $('#value_s', myModal).val(s); //columnValues[5].trim());
        $('#value_r', myModal).val(r.trim()); //columnValues[6].trim());
        $('#value_rs', myModal).val(rl.trim()); //columnValues[7].trim());
        $('#det_control', myModal).val(d.trim()); //columnValues[8].trim());
        $('#control_id', myModal).val(h); //columnValues[9].trim());
        $('#AddNewJSA', myModal).val("UpdateSub");

        myModal.modal("show");
        return false;
    });

    $('#JSAForm').on('click', '.DellineSub', function () {
        var didConfirm = confirm("Are you sure You want to delete");
        if (didConfirm == true) {
            var id = jQuery(this).attr('id');

            $('#' + id).remove();
            return true;
        } else {
            return false;
        }
    });
    // End Sub Job Task
});

// Start Inherent Risk
$(document).ready(function () {
    $("#value_s").on("change", function () {

        var selectLVal = $("#value_l option:selected").val();
        var selectSVal = $("#value_s option:selected").val();

        $.ajax({
            type: "POST",
            url: $("#urlInherent").val(),
            data: {
                L: selectLVal,
                S: selectSVal
            },
            success: function (data) {
                var a = JSON.parse(data);
                //console.log(a);

                $('#value_r').val(a.i_r);
                $('#value_rs').val(a.i_rl);
            },
            error: function (error) {
                console.log(error);
            }
        });
    });
});
// End Inherent Risk

// Start Edit Sub Jobtask
$(document).ready(function () {
    $("#job_task").on("change", function () {

        var parent = document.forms['frmJSA'].elements["id_parent"].value;
        var js = $("#job_task").val();

        $.ajax({
            type: "POST",
            url: $("#urlJobTask").val(),
            data: {
                job_task: js,
                parent: parent
            },
            success: function (data) {
                var SubJS = JSON.parse(data);
                console.log(SubJS.job_task);

                $('.' + SubJS.parent).val(SubJS.job_task);

                //var test = $('#jtVal' + SubJS.parent);
                //console.log(test);
                //test.val(SubJS.job_task);
            },
            error: function (error) {
                console.log(error);
            }
        });
    });
});
// End Edit Sub Jobtask

// Start Edit JSA
$(document).ready(function () {

    Tampil_JSA();

    function Tampil_JSA() {
        $.ajax({
            type: "ajax",
            url: $("#urlEdit").val(),
            async: false,
            dataType: 'json',
            success: function (oJSA_Hdr) {
                var JSA = JSON.parse(oJSA_Hdr);

                console.log(JSA);

            },
            error: function (error) {
                console.log(error);
            }
        });
    };
});
// End Edit JSA