
function ControlActions() {

    this.URL_API = "http://dev.corecodeapi.com/api/";

    this.GetUrlApiService = function (service) {
        return this.URL_API + service;
    }

    this.GetTableColumsDataName = function (tableId) {
        var val = $('#' + tableId).attr("ColumnsDataName");
        return val;
    }

    this.ReloadTable = function(tableId) {
        $('#' + tableId).DataTable().ajax.reload();
    }

    this.FillTable = function (service, tableId, refresh, searchLabel, searchPlaceHolder, requestData) {

        if (!refresh) {
            columns = this.GetTableColumsDataName(tableId).split(',');
            var arrayColumnsData = [];


            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                arrayColumnsData.push(obj);
            });

            $('#' + tableId).DataTable({
                "processing": true,
                "ajax": {
                    "url": this.GetUrlApiService(service),
                    dataSrc: 'Data',
                    "type" : "GET",
                    "data": requestData
                },
                "createdRow": function( row, data, dataIndex ) {
                    //let tdCollection = row.querySelectorAll("td").length;
                    //var tableElement = $("#" + tableId);
                    //var currentDateColumnIndex = 0;
                    //var currentRowDateElement;
                    //var currentDateValue;
                    //var translatedDate;
                    //var tableDateColumnElements = tableElement.find("th[data-column-type='date']");
                    //for (let index = 0; index < tableDateColumnElements.length; index++) {
                    //    currentDateColumnIndex = $(tableDateColumnElements[index]).index();
                    //    currentRowDateElement = $(row).find("td:nth-child(" + (currentDateColumnIndex + 1) + ")"); 
                    //    currentDateValue = currentRowDateElement.text();
                    //    translatedDate = new Date(currentDateValue);
                    //    currentRowDateElement.text(translatedDate.getFullYear() + "/" + translatedDate.getDay() + "/" + translatedDate.getMonth());
                    //}
                },
                language: {
                    search: searchLabel,
                    searchPlaceholder: searchPlaceHolder
                },
                "columns": arrayColumnsData
            });
        }

    }

    /**
     * This will not perform an AJAX Call, but it will use an array of elements passed in the DataSource
     * @param {any} tableId
     * @param {any} searchLabel
     * @param {any} searchPlaceHolder
     * @param {array} dataSource
     */
    this.FillTableFromDataSource = function(tableId, searchLabel, searchPlaceHolder, dataSource, noSearch) {
            var columns = this.GetTableColumsDataName(tableId).split(',');
            var arrayColumnsData = [];
            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                arrayColumnsData.push(obj);
            });

        if (noSearch) {
            $('#' + tableId).DataTable({
                "data": dataSource,
                searching: false, 
                paging: false, 
                info: false,
                "columns": arrayColumnsData
            });
        } else {
            $('#' + tableId).DataTable({
                "data": dataSource,
                language: {
                    search: searchLabel,
                    searchPlaceholder: searchPlaceHolder
                },
                
                "columns": arrayColumnsData
            });
        }
    }

    this.ClearTable = function (tableId) {
        $('#' + tableId).DataTable().destroy();//.clear().draw();
    }

    this.GetSelectedRow = function () {
        var data = sessionStorage.getItem(tableId + '_selected');

        return data;
    };

    this.BindFields = function (formId, data) {
        console.log(data);
        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            this.value = data[columnDataName];
        });
    }

    this.GetDataForm = function (formId) {
        var data = {};

        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            data[columnDataName] = this.value;
        });

        console.log(data);
        return data;
    }

    this.ShowMessage = function (type, message) {
        if (type == 'E') {
            $("#alert_container").removeClass("alert alert-success alert-dismissable")
            $("#alert_container").addClass("alert alert-danger alert-dismissable");
            $("#alert_message").text(message);
        } else if (type == 'I') {
            $("#alert_container").removeClass("alert alert-danger alert-dismissable")
            $("#alert_container").addClass("alert alert-success alert-dismissable");
            $("#alert_message").text(message);
        }
        $('.alert').show();
    };

    this.GetFromAPI = function(service, data, callback) {
        $.get(this.GetUrlApiService(service), data,
            function(response) {
                if (typeof (callback) == "function") {
                    callback(response);
                }
            });
    }

    this.GetFromAPISync = function(service, data, callback) {
        var responseFromSync;
       
        $.ajax({
            url: this.GetUrlApiService(service),
            type: 'GET',
            success: function(response) {
                responseFromSync = response;
                if (typeof (callback) === "function") {
                    callback(response);
                }
            },
            data: data,
            async: false
        });
        return responseFromSync;
    }
    
    this.PostToAPI = function (service, data, callback) {
        var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
            if (typeof (callback) === "function") {
                callback(response);
            }
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };

    this.PutToAPI = function (service, data) {
        var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };

    this.DeleteToAPI = function (service, data) {
        var jqxhr = $.delete(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };
}

//Custom jquery actions
$.put = function (url, data, callback) {
    if ($.isFunction(data)) {
        type = type || callback,
            callback = data,
            data = {}
    }
    return $.ajax({
        url: url,
        type: 'PUT',
        success: callback,
        data: JSON.stringify(data),
        contentType: 'application/json'
    });
}



$.delete = function (url, data, callback) {
    if ($.isFunction(data)) {
        type = type || callback,
            callback = data,
            data = {}
    }
    return $.ajax({
        url: url,
        type: 'DELETE',
        success: callback,
        data: JSON.stringify(data),
        contentType: 'application/json'
    });
}
