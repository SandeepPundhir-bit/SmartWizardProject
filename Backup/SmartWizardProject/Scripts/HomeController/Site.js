

//define a golbal ajax utils
(function (window) {
    if (window.AjaxUtils) {
        return;
    }
    window.AjaxUtils = {};
    var _ajaxUtils = window.AjaxUtils;
    

    /// <summary>
    /// ajax post data to server.
    /// </summary>
    /// <param name="url">the url will post to.</param>
    /// <param name="data">the data will post to.</param>
    /// <param name="successCallBack">the success callback function</param>
    /// <param name="busyContent">the content of busy.</param>
    /// <param name="contentType">submit type.</param>
    _ajaxUtils.ajaxPostBusy = function (url, data, successCallBack, busyContent, contentType) { 
        var processData = false;
        if (!contentType) {
            processData = true;
            contentType = "application/x-www-form-urlencoded";
        }
        $.ajax({
            type: "post",
            url: url,
            contentType: contentType,
            data: data,
            beforeSend: function (request) {           
            },
            success: function (result) {                
               successCallBack(result);
            },
            error: function (err) {              
                if (err.status != 0) {
                    alert(err);
                }
            },
            processData: processData
        });
    };


    /// <summary>
    /// ajax load html, append to container.
    /// </summary>
    /// <param name="wrapper">the container.</param>
    /// <param name="url">the ajax request url.</param>
    /// <param name="successCallback">the seccess callback.</param>
    _ajaxUtils.ajaxLoad = function (wrapper, url, successCallback, isSilent) {
        var $wrapper = $(wrapper);
        $wrapper.empty();
        $.ajax({
            type: "get",
            url: url,
            success: function (result) {
                $wrapper.html(result);
                if (successCallback != undefined && successCallback != null) {
                    successCallback();
                }
            },
            error: function (err) {
                $wrapper.html("<div class='load-error'><span class='error'>Error occuurred.</span><a href='javascript:void(0);'>Re-try</a></div>");
                $wrapper.find("a").click(function () {
                    _ajaxUtils.ajaxLoad(wrapper, url, successCallback);
                });
            }
        });
    };



   

   
  
    $.extend({
        stringify: function (value, replacer) {
            return window.JSON.stringify(value, replacer);
        }
    });

  


})(window);

