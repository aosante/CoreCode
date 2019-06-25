function vListAirlinesRequest() {


    this.tblAirlineRequestId = 'tblAirlineRequest';
    this.rolUser = "1";
    this.airportId = localStorage.getItem('idAirlineLS');
    this.ctrlActions = new ControlActions();
    this.columns = "Id", "Comercial_name", "Business_name", "Creation_year", "Description", "Email";

    this.AirlineRequestStatusDropdownChange = function () {

        if (document.querySelector('#statusFilter').value === "waiting") {
            document.querySelector("#btnAccept").classList.remove('hide');
            document.querySelector("#btnReject").classList.remove('hide');

            this.ctrlActions.ClearTable(this.tblAirlineRequestId);
            this.RetrieveWaiting();

        }
        else if (document.querySelector('#statusFilter').value === "accepted") {
            document.querySelector("#btnAccept").classList.add('hide');
            document.querySelector("#btnReject").classList.add('hide');
            document.querySelector("#btnAdmin").classList.remove('hide');
            this.ctrlActions.ClearTable(this.tblAirlineRequestId);
            this.RetrieveAccepted();

        }
        else if (document.querySelector('#statusFilter').value === "rejected") {
            document.querySelector("#btnAccept").classList.add('hide');
            document.querySelector("#btnReject").classList.add('hide');

            this.ctrlActions.ClearTable(this.tblAirlineRequestId);
            this.RetrieveRejected();

        }

    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable('getAirlines', this.tblAirlineRequestId, false, 'Buscar:', 'Código o número');
    }

    this.RetrieveWaiting = function () {
        this.ctrlActions.FillTable('getWaitingAirlines', this.tblAirlineRequestId, false, 'Buscar:', 'Código o nombre');
        this.ReloadTable();
    }
    this.RetrieveAccepted = function () {
        this.ctrlActions.FillTable('getAcceptedAirlines', this.tblAirlineRequestId, false, 'Buscar:', 'Código o nombre');
        this.ReloadTable();
    }
    this.RetrieveRejected = function () {
        this.ctrlActions.FillTable('getDeniedAirlines', this.tblAirlineRequestId, false, 'Buscar:', 'Código o nombre');
        this.ReloadTable();
    }

    this.ReloadTable = function () {
        this.ctrlActions.ReloadTable(this.tblAirlineRequestId);
    }



    this.Update = function () {



        var instance = this;

        if (!this.Validate()) {


            var airlineData = {};
            airlineData = this.ctrlActions.GetDataForm('frmEdition');
            airlineData.Request = 'accepted';
            airlineData.Status = true;
            airlineData.Creation_year = airlineData.FormattedYear;
            instance.ctrlActions.PostToAPI('updateAirline', airlineData, function () {

                swal({
                    title: "¡Aerolínea modificada!",
                    text: "",
                    icon: "success",
                    button: "OK"
                }).then(function () {
                    // window.location.href = 'http://dev.corecode.com/vCreateAirlineAdmin';
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





    }

    this.Accept = function () {

        var instance = this;

        if (!this.Validate()) {

            var airlineAdminData = {};

            var airlineData = {};
            airlineData = this.ctrlActions.GetDataForm('frmEdition');
            airlineData.Request = 'accepted';
            airlineData.Status = true;
            airlineData.Creation_year = airlineData.FormattedYear;
            instance.ctrlActions.PostToAPI('updateAirline', airlineData, function () {
                let AirlineId = {
                    ID: airlineData.Id
                };
                let callback = function (response) {
                    airlineAdminData = response.Data;
                    airlineAdminData.Status = true;
                    airlineAdminData.Password = instance.GenerateRandomPassword();


                    instance.ctrlActions.PostToAPI('/updateAndSendEmailAirlineManagerAccepted', airlineAdminData);
                };
                instance.ctrlActions.GetFromAPI("/getAirlineAdminByAirlineId", AirlineId, callback);



                swal({
                    title: "¡Aerolínea aprobada!",
                    text: "",
                    icon: "success",
                    button: "OK"
                }).then(function () {
                    //Refresca la tabla
                    instance.CleanForm();
                    instance.ReloadTable();

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



    }


    this.GenerateRandomPassword = function () {
        var caracteres = "!@abcdefghijkmnpqrtuvwxyzABCDEFGHIJKLMNPQRTUVWXYZ2346789!@";
        var pass = "";
        var longitud = 8;
        for (i = 0; i < longitud; i++) pass += caracteres.charAt(Math.floor(Math.random() * caracteres.length));
        return pass;
    }



    this.Wait = function () {


        var instance = this;

        if (!this.Validate()) {


            var airlineData = {};
            airlineData = this.ctrlActions.GetDataForm('frmEdition');
            airlineData.Request = 'waiting';
            airlineData.Status = false;
            airlineData.Creation_year = airlineData.FormattedYear;
            instance.ctrlActions.PostToAPI('updateAirline', airlineData, function () {
                //Refresca la tabla
                swal({
                    title: "¡Aerolínea en espera!",
                    text: "",
                    icon: "success",
                    button: "OK"
                }).then(function () {
                    //Refresca la tabla
                    instance.CleanForm();
                    instance.ReloadTable();

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



    }


    this.Reject = function () {

        var instance = this;

        if (!this.Validate()) {


            var airlineData = {};
            airlineData = this.ctrlActions.GetDataForm('frmEdition');
            airlineData.Request = 'rejected';
            airlineData.Status = false;
            airlineData.Creation_year = airlineData.FormattedYear;
            instance.ctrlActions.PostToAPI('updateAirline', airlineData, function () {

                let AirlineId = {
                    ID: airlineData.Id
                };
                let callback = function (response) {
                    airlineAdminData = response.Data;
                    airlineAdminData.Status = false;
                    airlineAdminData.Password = "rejected"


                    instance.ctrlActions.PostToAPI('/updateAndSendEmailAirlineManagerRejected', airlineAdminData);
                };
                instance.ctrlActions.GetFromAPI("/getAirlineAdminByAirlineId", AirlineId, callback);



                swal({
                    title: "¡Aerolínea rechazada!",
                    text: "",
                    icon: "success",
                    button: "OK"
                }).then(function () {
                    //Refresca la tabla
                    instance.CleanForm();
                    instance.ReloadTable();

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


    }


    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
        document.getElementById("txtId").setAttribute("disabled", "disabled");
    }


    this.CleanForm = function () {
        let aInputs = document.querySelectorAll(':required');

        for (let i = 0; i < aInputs.length; i++) {
            aInputs[i].value = '';
        }
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

    this.ShowAdmin = function () {
        if (document.querySelector("#txtId").value = '') {
            document.querySelector("#txtId").classList.add('input-error');
            swal({
                title: "¡Error al ver administrador!",
                text: "Seleccionar aerolínea del administrador",
                icon: "error",
                button: "OK",
            });
        }
        else {
            localStorage.setItem('idAirlineLS', document.querySelector("#txtId").value);
            window.location.href = 'http://dev.corecode.com/vEditAirlineAdmin';
        }


    }


}

//ON DOCUMENT READY
$(document).ready(function () {

    document.querySelector("#btnAdmin").classList.add('hide');
    document.querySelector('#txtId').disabled = true;
    document.querySelector('#txtEmail').disabled = true;
    var vlistairlinerequest = new vListAirlinesRequest();



    if (vlistairlinerequest.rolUser == "1") {
        document.querySelector("#btnEdit").classList.add('hide');
        document.querySelector("#DropdownAndTable").classList.remove('hide');
        document.querySelector("#btnClean").classList.remove('hide');
        document.querySelector("#btnAccept").classList.remove('hide');
        document.querySelector("#btnReject").classList.remove('hide');
        let aInputs = document.querySelectorAll(':required');

        for (let i = 0; i < aInputs.length; i++) {
            aInputs[i].disabled = true;
        }
        vlistairlinerequest.RetrieveWaiting();
    }

    if (vlistairlinerequest.rolUser == "3") {
        document.querySelector("#btnAdmin").classList.add('hide');
        document.querySelector("#DropdownAndTable").classList.add('hide');
        document.querySelector("#btnEdit").classList.remove('hide');
        document.querySelector("#btnClean").classList.add('hide');
        document.querySelector("#btnAccept").classList.add('hide');
        document.querySelector("#btnReject").classList.add('hide');


        let idAirline = {
            id: localStorage.getItem('idAirlineLS')//saca session storage IDAssigned
        };
        let airline;
        let callback = function (response) {

            airline = response.Data;
            document.querySelector('#txtId').value = localStorage.getItem('idAirlineLS');
            document.querySelector('#txtComercialName').value = airline.Comercial_name;
            document.querySelector('#txtBusinessName').value = airline.Business_name;
            document.querySelector('#txtCreationYear').value = airline.FormattedYear;
            document.querySelector('#txtDescription').value = airline.Description;
            document.querySelector('#txtEmail').value = airline.Email;

        };
        ApiService.getFromAPI("/getAirlineById", idAirline, callback);
    }


});
