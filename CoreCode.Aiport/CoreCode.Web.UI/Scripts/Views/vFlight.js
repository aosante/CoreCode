function vFlight() {

    this.tblFlightId = 'tblFlights';
    this.service = 'flight';
    this.ctrlActions = new ControlActions();
    this.airlinesDropdownId = "dropdownAirline";
    this.destinyAirportDropdownId = "dropdownDestinyAirport";
    this.originAirportDropdownId = "dropdownOriginAirport";
    this.gateDropdownId = "dropdownGate";
    //this.gatesDropdownId = "dropdownGates";
    this.columns = "Id,Airline_Id,Origin_Airport_Id,Destiny_Airport_Id,Departure_Time,Arrival_Datetime,Id_Airplane,Id_Gate";
    this.loadAirlineDropdown = function() {
        var instance = this;
        this.ctrlActions.GetFromAPI('getAirlines', "", function (response) {
            var airlinesDropdown = $("#" + instance.airlinesDropdownId);
            if (response.Data) {
                for (var counter = 0; counter < response.Data.length; counter++) {
                    airlinesDropdown.append(new Option(response.Data[counter].Comercial_name, response.Data[counter].Id));
                }
            }
        });
    }

    this.loadAirportDropdown = function() {
        var instance = this;
        this.ctrlActions.GetFromAPI('getAirports', "", function (response) {
            var destinyAirportElement = $("#" + instance.destinyAirportDropdownId);
            var originAirportElement = $("#" + instance.originAirportDropdownId);
            if (response.Data) {
                for (var counter = 0; counter < response.Data.length; counter++) {
                    destinyAirportElement.append(new Option(response.Data[counter].Name, response.Data[counter].ID));
                    originAirportElement.append(new Option(response.Data[counter].Name, response.Data[counter].ID));
                }
            }
        });
    }


    //gate dropdown
    this.loadGateDropdown = function () {
        var instance = this;
        this.ctrlActions.GetFromAPI('getGates', "", function (response) {
            var gateElement = $("#" + instance.gateDropdownId);
            if (response.Data) {
                for (var counter = 0; counter < response.Data.length; counter++) {
                    gateElement.append(new Option(response.Data[counter].IDGate, response.Data[counter].ID));
                    //originAirportElement.append(new Option(response.Data[counter].Name, response.Data[counter].ID));
                }
            }
        });
    }
    this.FlightStatusDropdownChange = function () {

        if (document.querySelector('#statusFilter').value === "a tiempo") {
            this.ctrlActions.ClearTable(this.tblFlightId);
            this.RetrieveATiempo();

        }
        else if (document.querySelector('#statusFilter').value === "cancelado") {
            this.ctrlActions.ClearTable(this.tblFlightId);
            this.RetrieveCancelado();

        }

        else if (document.querySelector('#statusFilter').value === "retrasado") {
            this.ctrlActions.ClearTable(this.tblFlightId);
            this.RetrieveRetrasado();

        }

    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable('getFlights', this.tblFlightId, false, 'Buscar:', 'Código o nombre');
    }

    this.RetrieveATiempo = function () {
        this.ctrlActions.FillTable('getFlightOnTime', this.tblFlightId, false, 'Buscar:', 'Código o nombre');
    }

    this.RetrieveCancelado = function () {
        this.ctrlActions.FillTable('getFlightCanceled', this.tblFlightId, false, 'Buscar:', 'Código o nombre');
    }
    this.RetrieveRetrasado = function () {
        this.ctrlActions.FillTable('getFlightDelay', this.tblFlightId, false, 'Buscar:', 'Código o nombre');
    }
    this.ReloadTable = function () {
        this.ctrlActions.ReloadTable(this.tblFlightId);
    }

    this.Create = function () {
        if (!this.Validate()) {
            
            var flightData = {};
            var instance = this;
            flightData = this.ctrlActions.GetDataForm('frmEdition');
            flightData.Status = "a tiempo";
            
            //Hace el post al create
            let flights;
            let cont = 0;
            this.ctrlActions.PostToAPI('createFlight', flightData, function (response) {
                    swal({
                        title: "¡Vuelo registrado!",
                        text: "",
                        icon: "success",
                        button: "OK",
                    });
                    instance.ReloadTable();
                });


            this.CleanForm();

        }
        else {

            swal({
                title: "¡Ocurrió un error!",
                text: "Revisar campos vacíos",
                icon: "error",
                button: "OK",
            });

        }

    }

    this.ValidateUpdate = function() {
        var instance = this;
        var error = false;
        var selectDropdown = document.getElementById("txtStatus");
        if (selectDropdown) {
            if (selectDropdown.value !== "") {
                error = false;
            } else {
                error = true;
            }
        }
        return error;
    }

    this.Update = function () {

        var instance = this;
        instance.DisplayInsertForm();
        if (!instance.ValidateUpdate()) {
            var flightData = {};
            if (window.currentSelectedRow) {
                window.currentSelectedRow.remove();
                window.currentSelectedRow = null;
            }
            flightData = instance.ctrlActions.GetDataForm('frmEdition');
            flightData.Status = flightData[""];
            instance.ctrlActions.PostToAPI('updateFlight', flightData, function () {
                swal({
                    title: "¡Vuelo modificado!",
                    text: "",
                    icon: "success",
                    button: "OK"
                }).then(function () {
                    //Refresca la tabla
                    instance.CleanForm();
                    instance.ReloadTable();
                    // window.location.href = 'http://dev.corecode.com/vFlight';
                });
            });

        }
        else {
            swal({
                title: "¡Ocurrió un error!",
                text: "Revisar campos vacíos",
                icon: "error",
                button: "OK",
            });
        }

        instance.ReloadTable();


    }

    this.Validate = function () {
        let aInputs = document.querySelectorAll(':required');
        let bError = false;

        for (let i = 0; i < aInputs.length; i++) {
            if (aInputs[i].value === '') {
                bError = true;
                aInputs[i].classList.add('input-error');
            }
            else {
                aInputs[i].classList.remove('input-error');
            }

        }
        return bError;

    }


    ///fLIGHT SE ELIMINA??
    /*this.Delete = function () {

        var categoryData = {};
        categoryData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, categoryData);
        //Refresca la tabla
        this.ReloadTable();

    }*/

    this.BindFields = function (data, selectedRow) {
        var instance = this;
        document.getElementById("btnEditFlight").style.display = 'block';
        document.getElementById("btnRegisterFlight").style.display = 'none';
        window.currentSelectedRow = selectedRow;
        var txtStatusElement = $("#txtStatus");
        this.ctrlActions.BindFields('frmEdition', data);
        document.getElementById("txtId").setAttribute("disabled", "disabled");
        document.getElementById("dropdownAirline").style.display = 'none';
        document.getElementById("dropdownOriginAirport").style.display = 'none';
        document.getElementById("dropdownDestinyAirport").style.display = 'none';
        document.getElementById("txtDeparture_Time").style.display = 'none';
        document.getElementById("txtArrival_Time").style.display = 'none';
        document.getElementById("dropdownGate").style.display = 'none';//.setAttribute("disabled", "disabled");
        document.querySelector("label[for='txtArrival_Time']").style.display = 'none';
        document.querySelector("label[for='txtDeparture_Time']").style.display = 'none';
        txtStatusElement.show();
        txtStatusElement.val(data.Status);
    }

    this.DisplayInsertForm = function () {
        var instance = this;
        var txtStatusElement = $("#txtStatus");
        document.getElementById("btnEditFlight").style.display = 'none';
        document.getElementById("btnRegisterFlight").style.display = 'block';
        //instance.ctrlActions.BindFields('frmEdition', data);
        var txtIdElement = document.getElementById("txtId");
        txtIdElement.setAttribute("disabled", "");
        txtIdElement.setAttribute("enabled", "enabled");
        document.getElementById("dropdownAirline").style.display = 'block';
        document.getElementById("dropdownOriginAirport").style.display = 'block';
        document.getElementById("dropdownDestinyAirport").style.display = 'block';
        document.getElementById("txtDeparture_Time").style.display = 'block';
        document.getElementById("txtArrival_Time").style.display = 'block';
        document.querySelector("label[for='txtArrival_Time']").style.display = 'block';
        document.querySelector("label[for='txtDeparture_Time']").style.display = 'block';
        
        document.getElementById("dropdownGate").style.display = 'block';//.setAttribute("disabled", "disabled");
        txtStatusElement.hide();
    }


    this.CleanForm = function () {
        //document.querySelector('#txtId').value = '';
        //document.querySelector('#txtDescription').value = '';
        //document.querySelector('#txtId').disabled = false;


        //let aInputs = document.querySelectorAll(':required');
        //for (let i = 0; i < aInputs.length; i++) {
        //    aInputs[i].classList.remove('input-error');
        // }

    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vflight = new vFlight();
    vflight.RetrieveATiempo();
});
