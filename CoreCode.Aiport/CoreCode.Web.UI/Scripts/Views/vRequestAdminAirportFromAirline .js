
function vRequestAdminAirportFromAirline() {

    this.AirportId = UserSession.getAirportInstance().ID;//AGARRA IDASSIGNED DE SESSION STORAGE
    this.tblAirlineRequestId = 'tblAirlineRequest';
    this.ctrlActions = new ControlActions();
    this.columns = "Id", "Comercial_name", "Business_name", "Creation_year", "Description", "Email";

    this.AirlineRequestStatusDropdownChange = function () {

        if (document.querySelector('#statusFilter').value === "waiting") {
            document.querySelector("#btnAccept").classList.remove('hide');
            document.querySelector("#btnReject").classList.remove('hide');
            document.querySelector("#btnWait").classList.add('hide');
            this.ctrlActions.ClearTable(this.tblAirlineRequestId);
            this.RetrieveWaiting();

        }
        else if (document.querySelector('#statusFilter').value === "accepted") {
            document.querySelector("#btnAccept").classList.add('hide');
            document.querySelector("#btnWait").classList.add('hide');
            document.querySelector("#btnReject").classList.remove('hide');

            this.ctrlActions.ClearTable(this.tblAirlineRequestId);
            this.RetrieveAccepted();

        }
        else if (document.querySelector('#statusFilter').value === "rejected") {
            document.querySelector("#btnAccept").classList.add('hide');
            document.querySelector("#btnReject").classList.add('hide');
            document.querySelector("#btnWait").classList.remove('hide');

            this.ctrlActions.ClearTable(this.tblAirlineRequestId);
            this.RetrieveRejected();

        }
       

    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable('getAirlines', this.tblAirlineRequestId, false, 'Buscar:', 'Código o número');
    }

    this.RetrieveWaiting = function () {//Al final manda ID del aeropuerto en sesion
        this.ctrlActions.FillTable('getAirlinesWaiting', this.tblAirlineRequestId, false, 'Buscar:', 'Código o nombre', { id: this.AirportId });
        this.ReloadTable();
        this.ReloadTable();
    }
    this.RetrieveAccepted = function () {
        this.ctrlActions.FillTable('getAssociatedAirlines', this.tblAirlineRequestId, false, 'Buscar:', 'Código o nombre', { id: this.AirportId });
        this.ReloadTable();
    }

    this.RetrieveRejected = function () {
        this.ctrlActions.FillTable('getRejectedAirlines', this.tblAirlineRequestId, false, 'Buscar:', 'Código o nombre', { id: this.AirportId });
        this.ReloadTable();
    }
   

    this.ReloadTable = function () {
        this.ctrlActions.ReloadTable(this.tblAirlineRequestId);
    }

    this.Wait = function () {


        var instance = this;
        if (!this.Validate()) {

            let requestToAirport = {
                "IDAirline": document.getElementById("txtId").value,//cedula juridica de la aerolinea seleccionada
                "IDAirport": instance.AirportId, // ID aeropuerto en sesion
                "Request": "waiting",
            };
            this.ctrlActions.PostToAPI('updateRequestAirlineAirport', requestToAirport, function () {
                //Refresca la tabla
                swal({
                    title: "¡Aerolínea puesta en espera!",
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
                title: "¡Error al poner en espera aerolínea!",
                text: "Por favor, seleccionar una aerolínea en la tabla",
                icon: "error",
                button: "OK",
            });
        }
    }


    this.Accept = function () {
      

        var instance = this;
        if (!this.Validate()) {



            let requestToAirport = {
                "IDAirline": document.getElementById("txtId").value,//cedula juridica de la aerolinea seleccionada
                "IDAirport": instance.AirportId, // ID aeropuerto en sesion
                "Request": "accepted",
            };



            this.ctrlActions.PostToAPI('updateRequestAirlineAirport', requestToAirport, function () {
                //Refresca la tabla
                swal({
                    title: "¡Aerolínea asociada!",
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
                title: "¡Error al aceptar aerolínea!",
                text: "Por favor, seleccionar una aerolínea en la tabla",
                icon: "error",
                button: "OK",
            });
        }


    }

    this.Reject = function () {


        var instance = this;
        if (!this.Validate()) {

            let requestToAirport = {
                "IDAirline": document.getElementById("txtId").value,//cedula juridica de la aerolinea seleccionada
                "IDAirport": instance.AirportId, // ID aeropuerto en sesion
                "Request": "rejected",
            };
            this.ctrlActions.PostToAPI('updateRequestAirlineAirport', requestToAirport, function () {
                //Refresca la tabla
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
                title: "¡Error al rechazar aerolínea!",
                text: "Por favor, seleccionar una aerolínea en la tabla",
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


}

//ON DOCUMENT READY
$(document).ready(function () {
    document.querySelector("#btnAccept").classList.remove('hide');
    document.querySelector("#btnReject").classList.remove('hide');
    document.querySelector("#btnWait").classList.add('hide');
    let aInputs = document.querySelectorAll(':required');

    for (let i = 0; i < aInputs.length; i++) {       
            aInputs[i].disabled = true;
    }
    var vrequestAdminAirportToAirline = new vRequestAdminAirportFromAirline();
    vrequestAdminAirportToAirline.RetrieveWaiting();

});

