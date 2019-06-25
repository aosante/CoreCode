(function(global, factory) {
    "use strict";
    //Defining the ApiService on the window so that can be used from anywhere.
    global.ApiService = factory(global);
})(window, function(root) {//Calling the IIFE
    "use strict";
    const API_URL = "http://dev.corecodeapi.com/api/";
    var CreateApiServiceUrl = function(method) {
        return API_URL + method;
    };

    var getFromApi = function(method, data, callback) {

        //var ajax = $.ajax({
        //    type: 'GET',
        //    crossDomain: true,
        //    url: CreateApiServiceUrl(method),
        //    dataType: 'jsonp',
        //    sucess: function() {
        //        console.log("success");
        //    },
        //    error: function() {

        //    }
        //    
        //});
        
        var jqxhr = 
            $.get(CreateApiServiceUrl(method), data, function (response) {
                if (typeof (callback) === "function") {
                    callback(response);
                }
                console.log(response);
                })
                .fail(function(response) {
                    var data = response.responseJSON;
                    console.log(data);
                });
    }

    /**
     * Will post to the API according to the passed parameters. 
     * @param {any} method must be a string, which is the endpoint we are targeting.
     * @param {any} data must be a valid post type, like text, json, etc.
     */
    var postToApi = function(method, data, callback, failCallback) {
        var jqxhr = 
            $.post(CreateApiServiceUrl(method), data, function(response) {
                console.log(response);
                if (callback && typeof (callback) === "function" ) {
                    callback(response);
                }
            })
            .fail(function(response) {
                var data = response.responseJSON;
                console.log(data);
                if (failCallback && typeof (failCallback) === "function") {
                    failCallback(response);
                }

            });
    };

    var putToApi = function(method, data, callback) {
        $.ajax({
            url: CreateApiServiceUrl(method),
            type: 'POST',
            success: function(response) {
                if (typeof (callback) === "function") {
                    callback(response);
                }
            },

            error: function(error) {
                console.log(error);
            },
            //data: JSON.stringify(data),
            dataType: "jsonp",
            //contentType: 'application/json',
            data: JSON.stringify(data)

        });
    };
    var deleteToApi = function() {

    };


    var getFromApiSync = function(method, data, callback) {
        $.ajax({
            async: false,
            type: 'GET',
            url: CreateApiServiceUrl(method),
            success: function(data) {
                if (typeof (callback) === "function") {
                    callback(data);
                }
            }
        });
    };
    return {
        getFromAPI: getFromApi,
        postToAPI: postToApi,
        putToAPI: putToApi,
        deleteToAPI: deleteToApi,
        getFromAPISync: getFromApiSync
    };
});