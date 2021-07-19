var ComponentsSelect2 = function() {

    var handleDemo = function() {
        $.fn.select2.defaults.set("theme", "bootstrap");
        
        $(".select2, .select2-multiple").select2();

        $(".select2-allow-clear").select2({
            allowClear: true, 
            width: null
        });

        $(".select2dropdowns").each(function(){ 
            $(this).select2({
                placeholder: $(this).attr("data-placeholder"),
                allowClear: true
            });

        });
    }

    return {
        //main function to initiate the module
        init: function() {
            handleDemo();
        }
    };

}();

if (App.isAngularJsApp() === false) {
    jQuery(document).ready(function() {
        ComponentsSelect2.init();
    });
}