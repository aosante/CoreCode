(function(global, factory) {
    "use strict";
    //Defining the DomHelper on the window so that can be used from anywhere.
    global.DomHelper = factory(global);
})(window, function(root) {
    let getHtmlFromRoute = function(htmlRoute, data, callback) {
        $.get(htmlRoute, data, function(response) {
            if (typeof (callback) === "function") {
                callback(response);
            }
        }).fail(function(response) {
            console.log("Erorr with:" + response);
        });
    }
    return {
        getHtmlFromRoute: getHtmlFromRoute
    };
});