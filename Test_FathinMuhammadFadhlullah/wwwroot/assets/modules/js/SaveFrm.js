    function saveFrm() {
        if (window.confirm('Are you sure?')) {
            html = '<div class="loading-message-boxed"><img src="/assets/global/img/loading-spinner-blue.gif" align=""><span>&nbsp;&nbsp;LOADING...</span></div>';
            var cenrerY = false;
            var el = $('.BlockData');
            if (el.height() <= ($(window).height())) {
                cenrerY = true;
            }
            var boxed = 0;
            var overlayColor = 0;
            el.block({
                message: html,
                baseZ: 1000,
                centerY: cenrerY !== undefined ? cenrerY : false,
                css: {
                    top: '10%',
                    border: '0',
                    padding: '0',
                    backgroundColor: 'none'
                },
                overlayCSS: {
                    backgroundColor: overlayColor ? overlayColor : '#555',
                    opacity: boxed ? 0.05 : 0.1,
                    cursor: 'wait'
                }
            });
            //$.blockUI({
            //    target: '.BlockData',
            //    animate: true,
            //    overlayColor: 'none',
            //    boxed: true//,message: '<div class="border p-3"><div class="d-flex align-items-center"><strong>Loading...</strong><div class="spinner-border ml-auto" role="status" aria-hidden="true"></div></div></div>',
            //});

            return true;
        }
        else {
            return false;
        }
    }