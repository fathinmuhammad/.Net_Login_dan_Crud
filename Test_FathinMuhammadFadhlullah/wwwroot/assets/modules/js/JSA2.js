(function ($) {
    var $plugin = $('<div>').nestable().data('nestable');
    //console.log("plugin: %o", $plugin);

    var extensionMethods = {
        reinit: function () {
            //console.log('reinit: %o', this);

            // alias
            var list = this;

            // remove expand/collapse controls
            $.each(this.el.find(this.options.itemNodeName), function (k, el) {
                //console.log('el: %o', $(el));

                list.expandItem($(el));

                // if has <ol> child - remove previously prepended buttons
                if ($(el).children(list.options.listNodeName).length) {
                    $(el).children('button').remove();
                }
            });

            // remove delegated event handlers
            list.el.off('click', 'button');

            var hasTouch = 'ontouchstart' in document;
            if (hasTouch) {
                list.el.off('touchstart');
                list.w.off('touchmove');
                list.w.off('touchend');
                list.w.off('touchcancel');
            }

            list.el.off('mousedown');
            list.w.off('mousemove');
            list.w.off('mouseup');

            // call init again
            list.init();
        } // reinit
    };

    $.extend(true, $plugin.__proto__, extensionMethods);
})(jQuery);

var updateOutput = function (e) {
    var list = e.length ? e : $(e.target),
        output = list.data('output');
    if (window.JSON) {
        output.val(window.JSON.stringify(list.nestable('serialize'))); //, null, 2));
    } else {
        output.val('JSON browser support required for this demo.');
    }
};

$(document).ready(function () {

    function buildItem(item) {

        var html = "<li class='dd-item' data-quest='" + item.quest + "' data-id='" + item.id + "'>";
        html += "<div class='dd-handle portlet'><span class='dd-content'><div class=''><div class='clearfix portlet-title dd-nodrag pull-right'><div class='actions'><button type='button' class='btn yellow btn-sm editchild'><i class='fa fa-pencil'></i></button><button type='button' class='btn red btn-sm delchild'><i class='fa fa-trash'></i></button><button type='button' class='btn green btn-sm addchild'><i class='fa fa-child'></i></button></div></div><div class='portlet-body'>" + item.quest + "</div></div></span></div>";

        if (item.children) {

            html += "<ol class='dd-list'>";
            $.each(item.children, function (index, sub) {
                html += buildItem(sub);
            });
            html += "</ol>";

        }

        html += "</li>";

        return html;
    };

    var json = $("#jsonDtl").val();
    if (json != '') {
        var output = '';

        $.each(JSON.parse(json), function (index, item) {

            output += buildItem(item);

        });

        //$('#dd-empty-placeholder').html(output);
        //$('#outputFrmD').val($('.dd').nestable('serialize'));
        //$('#tplFrmDNested').nestable().on('load', updateOutput);
        $('.dd').nestable().on('change', updateOutput);
        updateOutput($('#tplFrmDNested').data('output', $('#outputFrmD')));
        //$('#tplFrmDNested').nestable({ group: 1 }).on('change', updateOutput);
        //$('#outputFrmD').val($('#tplFrmDNested').nestable('serialize'));
    }
    else {
        $('#tplFrmDNested').nestable({ group: 1 }).on('change', updateOutput);
        $('.dd-empty').remove();
        //updateOutput($('#tplFrmDNested').data('output', $('#outputFrmD')));
    }
    //updateOutput($('#tplFrmDNested').data('output', $('#outputFrmD')));

    //$('.dd').nestable().on('click', function (e) {
    //    var list = e.length ? e : $(e.target), output = list.nestable('serialize');
    //    console.log(output);
    //});

    function clearModalD() {
        $('#questionD').val('');
        $('#data-id').val('');
    }

    $("#ButtontplD").on('click', function () {
        if ($('#questionD').val() == '') {
            alert('question field required');
            return false;
        }

        //var max = -Infinity;
        //$('#tplFrmDNested li[class^=dd-item]').each(function () {
        //    var match = $(this).attr('data-id').match(/^([0-9]+)$/);
        //    if (max < match[1]) {
        //        max = match[1];
        //    }
        //});
        var max = 0;
        $('#tplFrmDNested li[class^=dd-item]').each(function () {
            var match = parseFloat($(this).attr('data-id'));
            if (max < match) {
                max = match;
            }
        });

        var lastdataid = max; //$("#tplFrmDNested li[class^=dd-item]").last().attr('data-id');
        var id = (isNaN(parseInt(lastdataid)) ? 0 : parseInt(lastdataid)) + 1;

        if ($(this).val() == 'Add') {
            var i = 0;

            var nestablecount = id;
            $('.dd').nestable('add', { "id": id, "content": '<div class=""><div class="clearfix portlet-title dd-nodrag pull-right"><div class="actions"><button type="button" class="btn yellow btn-sm editchild"><i class="fa fa-pencil"></i></button><button type="button" class="btn red btn-sm delchild"><i class="fa fa-trash"></i></button><button type="button" class="btn green btn-sm addchild"><i class="fa fa-child"></i></button></div></div><div class="portlet-body">' + $("#questionD").val() + '</div></div>', "quest": $("#questionD").val() });

        } else if ($(this).val() == 'Add Child') {

            $('#tplFrmDNested').nestable('add', { "id": id, "content": '<div class=""><div class="clearfix portlet-title dd-nodrag pull-right"><div class="actions"><button type="button" class="btn yellow btn-sm editchild"><i class="fa fa-pencil"></i></button><button type="button" class="btn red btn-sm delchild"><i class="fa fa-trash"></i></button><button type="button" class="btn green btn-sm addchild"><i class="fa fa-child"></i></button></div></div><div class="portlet-body">' + $("#questionD").val() + '</div></div>', "parent_id": $('#data-id').val(), "quest": $("#questionD").val() });

        } else {
            var all = "";
            $('#tplFrmDNested li[class^=dd-item]').each(function () {
                if ($('#data-id').val() == $(this).attr('data-id')) {
                    //$(this).attr('data-quest', $("#questionD").val());
                    //var chd = $('div.portlet-body')[0];
                    //$(this).find(chd).html($("#questionD").val());
                    all = $(this).children('ol.dd-list').map(function () {
                        return $(this).html();
                    }).get();
                    //console.log(all);
                }
            });
            if ($('#inspection_id').val() <= 0) {
                $('#tplFrmDNested').nestable('replace', {
                    "id": $('#data-id').val(), "content": '<div class=""><div class="clearfix portlet-title dd-nodrag pull-right"><div class="actions"><button type="button" class="btn yellow btn-sm editchild"><i class="fa fa-pencil"></i></button><button type="button" class="btn red btn-sm delchild"><i class="fa fa-trash"></i></button><button type="button" class="btn green btn-sm addchild"><i class="fa fa-child"></i></button></div></div><div class="portlet-body">' + $("#questionD").val()
                        + '</div></div>', "quest": $("#questionD").val()
                    , "children": '<ol class="dd-list">' + all + '</ol>'

                });
            } else {
                $('#tplFrmDNested').nestable('replace', {
                    "id": $('#data-id').val(), "content": '<div class=""><div class="clearfix portlet-title dd-nodrag pull-right"><div class="actions"><button type="button" class="btn yellow btn-sm editchild"><i class="fa fa-pencil"></i></button></div></div><div class="portlet-body">' + $("#questionD").val()
                        + '</div></div>', "quest": $("#questionD").val()
                    , "children": '<ol class="dd-list">' + all + '</ol>'

                });
            }
        }

        $("#clsBtnD").trigger("click");
        $(this).val('Add');
        clearModalD();
        updateOutput($('.dd').data('output', $('#outputFrmD')));
    });

    $(document).on('click', '.delchild', function (e) {
        if (window.confirm('Are you sure?')) {
            var id = $(this).closest("li.dd-item").attr('data-id');
            $('.dd').nestable('remove', id);
            updateOutput($('.dd').data('output', $('#outputFrmD')));
            return true;
        } else {
            return false;
        }
    });

    $(document).on('click', '.editchild', function (e) {
        var myModal = $('#AddsubJSA');

        var id = $(this).closest("li.dd-item").attr('data-id');
        var quest = $(this).closest("li.dd-item").attr('data-quest');

        $('#questionD', myModal).val(quest.trim()); //columnValues[0].trim());
        $('#ButtontplD', myModal).val("Update");
        $('#data-id', myModal).val(id);

        myModal.modal("show");
        return false;
    });


    $(document).on('click', '#addQuest', function () {
        $("#ButtontplD").val('Add');
    });

    $(document).on('click', '.addchild', function (e) {
        var id = $(this).closest("li.dd-item").attr('data-id');
        $('#ButtontplD').val("Add Child");
        clearModalD();
        $('#data-id').val(id);
        $("#AddsubJSA").modal("show");
    });

    var start = Date.parse($('#assigned_date').val());

    $('#assigned_date').datepicker('setStartDate', new Date(start));
    //$('#start_date').datepicker('setEndDate', new Date(end));
    //$('#end_date').datepicker('setEndDate', new Date(end));

    $('#assigned_date').datepicker({
        startDate: start,
        //endDate: end,
        format: "mm/dd/yyyy"
    });
});