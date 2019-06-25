function vListAirports() {


    this.tblAirportId = 'tblAirport';
    this.rolUser = UserSession.getCurrentUserInstance().Rol;
    this.ctrlActions = new ControlActions();
    this.columns = "ID", "Name", "Address", "Phone", "ZipCode", "GateTariff", "RunwayTariff", "Tax", "Latitude", "Longitude";

    this.AirportStatusDropdownChange = function () {

        if (document.querySelector('#statusFilter').value === "true") {
            document.querySelector("#btnEnableAirport").classList.add('hide');
            document.querySelector("#btnDisableAirport").classList.remove('hide');

            this.ctrlActions.ClearTable(this.tblAirportId);
            this.RetrieveAvailable();

        }
        else if (document.querySelector('#statusFilter').value === "false") {

            document.querySelector("#btnEnableAirport").classList.remove('hide');
            document.querySelector("#btnDisableAirport").classList.add('hide');

            this.ctrlActions.ClearTable(this.tblAirportId);
            this.RetrieveUnavailable();

        }

    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable('getAirports', this.tblAirportId, false, 'Buscar:', 'Código o número');
    }

    this.RetrieveAvailable = function () {
        this.ctrlActions.FillTable('getAvailableAirports', this.tblAirportId, false, 'Buscar:', 'Código o nombre');
        this.ReloadTable();
    }
    this.RetrieveUnavailable = function () {
        this.ctrlActions.FillTable('getUnavailableAirports', this.tblAirportId, false, 'Buscar:', 'Código o nombre');
        this.ReloadTable();
    }

    this.ReloadTable = function () {
        this.ctrlActions.ReloadTable(this.tblAirportId);
    }


    this.ShowAdmin = function () {



        if (document.querySelector("#txtId").value = '') {
            document.querySelector("#txtId").classList.add('input-error');
            swal({
                title: "¡Error al ver administrador!",
                text: "Seleccionar aeropuerto del administrador",
                icon: "error",
                button: "OK",
            });
        }
        else {
            localStorage.setItem('idAirport', document.getElementById("txtId").value);
            window.location.href = 'http://dev.corecode.com/vEditAirportAdmin';

        }

    }



    this.Update = function () {


        var instance = this;
        if (!this.Validate()) {


            var airportData = {};
            airportData = this.ctrlActions.GetDataForm('frmEdition');
            airportData.ID = document.getElementById("txtId").value;
            airportData.Status = true;

            instance.ctrlActions.PostToAPI('updateAirport', airportData, function () {
                swal({
                    title: "¡Aeropuerto modificado!",
                    text: "",
                    icon: "success",
                    button: "OK"
                }).then(function () {
                    if (instance.rolUser == "1") {

                        instance.CleanForm();
                        instance.ReloadTable();

                        //  window.location.href = 'http://dev.corecode.com/vCreateAirportAdmin';
                    }

                });
            });


        }
        else {
            swal({
                title: "¡Error al modificar aeropuerto!",
                text: "Por favor, seleccionar un aeropuerto a modificar en la tabla",
                icon: "error",
                button: "OK",
            });
        }




    }

    this.Enable = function () {


        var instance = this;
        if (!this.Validate()) {
            var airportData = {};
            airportData = this.ctrlActions.GetDataForm('frmEdition');
            //Hace el post al create
            airportData.ID = document.getElementById("txtId").value;
            airportData.Status = true;

            this.ctrlActions.PostToAPI('updateAirport', airportData, function () {
                //Refresca la tabla
                swal({
                    title: "¡Aeropuerto habilitado!",
                    text: "",
                    icon: "success",
                    button: "OK"
                }).then(function () {
                    if (instance.rolUser == "1") {


                        instance.CleanForm();
                        instance.ReloadTable();

                        //  window.location.href = 'http://dev.corecode.com/vCreateAirportAdmin';
                    }

                });
            });
        }
        else {
            swal({
                title: "¡Error al habilitar aeropuerto!",
                text: "Por favor, seleccionar un aeropuerto a habilitar en la tabla",
                icon: "error",
                button: "OK",
            });
        }




    }

    this.HomePage = function () {
        //if (rol == 1) {
        ////  window.location.href = 'http://dev.corecode.com/vCreateAirportAdmin';
        //} else if (rol == 2) {
        ////  window.location.href = 'http://dev.corecode.com/vCreateAirportAdmin';
        //}
    }


    this.Disable = function () {


        var instance = this;
        if (!this.Validate()) {
            var airportData = {};
            airportData = this.ctrlActions.GetDataForm('frmEdition');
            airportData.ID = document.getElementById("txtId").value;
            airportData.Status = false;

            this.ctrlActions.PostToAPI('updateAirport', airportData, function () {
                swal({
                    title: "¡Aeropuerto deshabilitado!",
                    text: "",
                    icon: "success",
                    button: "OK"
                }).then(function () {
                    if (instance.rolUser == "1") {

                        instance.CleanForm();
                        instance.ReloadTable();
                    }
                });
            });
        }
        else {
            swal({
                title: "¡Error al deshabilitar aeropuerto!",
                text: "Por favor, seleccionar un aeropuerto a deshabilitar en la tabla",
                icon: "error",
                button: "OK",
            });
        }




    }

    this.ShowGates = function () {
        if (document.querySelector("#txtId").value == "") {
            swal({
                title: "¡Error al ver puertas!",
                text: "Por favor, seleccionar un aeropuerto en la tabla",
                icon: "error",
                button: "OK",
            });
        }
        else {
            localStorage.setItem('idAirportLS', document.querySelector("#txtId").value);
            window.location.href = 'http://dev.corecode.com/vGates';
        }


    }


    this.BindFields = function (data) {



        this.ctrlActions.BindFields('frmEdition', data);
        document.getElementById("txtId").setAttribute("disabled", "disabled");

        let aInputs = document.querySelectorAll(':required');


        for (let i = 0; i < aInputs.length; i++) {
            if (aInputs[i].value === '') {
                bError = true;
                aInputs[i].classList.add('input-error');
            }
            else {
                aInputs[i].classList.remove('input-error');
            }

        }

        this.DisplayGoogleMap();



    }


    this.CleanForm = function () {
        document.querySelector("#txtId").value = "";
        document.querySelector("#txtName").value = "";
        document.querySelector("#txtPhone").value = "";
        document.querySelector("#txtZipCode").value = "";
        document.querySelector("#txtGateTariff").value = "";
        document.querySelector("#txtRunwayTariff").value = "";
        document.querySelector("#txtTax").value = "";
        document.querySelector("#txtAddress").value = "";
        document.querySelector("#coordenadaX").value = "";
        document.querySelector("#coordenadaY").value = "";

        this.DisplayGoogleMap();

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

    this.DisplayGoogleMap = function () {
        let geocoder = new google.maps.Geocoder();

        function geocodePosicion(pos) {
            geocoder.geocode({
                latLng: pos
            }, function (responses) {
                if (responses && responses.length > 0) {
                    actualizarDireccionMarcador(responses[0].formatted_address);
                } else {
                    actualizarDireccionMarcador('No se puede establecer una dirección en esta posición.'); //si el usuario suelta el marcador en el mar o en lugar recóndito
                }
            });
        }

        function actualizarStatusMarcador(str) {
            document.getElementById('statusMarcador').innerHTML = str;
        }

        function actualizarPosicionMarcador(latLng) {
            document.getElementById('coordenadaX').value =
                latLng.lat();
            document.getElementById('coordenadaY').value =
                latLng.lng();
        }

        function actualizarDireccionMarcador(str) {
            document.querySelector('#txtAddress').value = str;
        }

        function inicializar() {

            let latLng = new google.maps.LatLng(document.querySelector('#coordenadaX').value, document.querySelector('#coordenadaY').value); //Ubicacion Cenfotec
            let map = new google.maps.Map(document.getElementById('mapa'), {
                zoom: 9, //vista mapa
                center: latLng,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });
            let marcador = new google.maps.Marker({ //el marker se puede cambiar por algo mas personalizado
                position: latLng,
                title: 'Point A',
                map: map,
                draggable: true
            });

            // Actualizar posición actual
            actualizarPosicionMarcador(latLng);
            geocodePosicion(latLng);

            // Agregar event listeners para actualizar posicion cuando el usuario selecciona dirección
            google.maps.event.addListener(marcador, 'dragstart', function () {
                actualizarDireccionMarcador('Estableciendo dirección...');
            });

            google.maps.event.addListener(marcador, 'drag', function () {
                actualizarStatusMarcador('Moviendo...');
                actualizarPosicionMarcador(marcador.getPosition());
            });

            google.maps.event.addListener(marcador, 'dragend', function () {
                actualizarStatusMarcador('Mueva el marcador para seleccionar su dirección');
                geocodePosicion(marcador.getPosition());
            });
        }
        // Controlador de carga para iniciar la aplicación.
        google.maps.event.addDomListener(window, 'load', inicializar);
        if (document.readyState === "complete") {
            inicializar();
        }

    }


}

//ON DOCUMENT READY
$(document).ready(function () {

    document.querySelector('#txtId').disabled = true;
    document.querySelector("#txtAddress").disabled = true;
    document.querySelector("#txtZipCode").disabled = true;
    var vlistarpt = new vListAirports();

    if (vlistarpt.rolUser === 1) {

        document.querySelector("#DropdownAndTable").classList.remove('hide');
        document.querySelector("#btnEnableAirport").classList.add('hide');
        vlistarpt.RetrieveAvailable();

    }
    else if (vlistarpt.rolUser === 2) {
        vlistarpt.DisplayGoogleMap();
        document.querySelector("#DropdownAndTable").classList.add('hide');
        document.querySelector("#btnEnableAirport").classList.add('hide');
        document.querySelector("#btnDisableAirport").classList.add('hide');
        document.querySelector("#btnClean").classList.add('hide');


        let idAirport = {
            id: UserSession.getAirportInstance().ID
        };
        let airport;
        let callback = function (response) {

            airport = response.Data;
            document.querySelector('#txtId').value = localStorage.getItem('idAirportLS');
            document.querySelector('#txtName').value = airport.Name;
            document.querySelector('#txtAddress').value = airport.Address;
            document.querySelector('#txtPhone').value = airport.Phone;
            document.querySelector('#txtZipCode').value = airport.ZipCode;
            document.querySelector('#txtGateTariff').value = airport.GateTariff;
            document.querySelector('#txtRunwayTariff').value = airport.RunwayTariff;
            document.querySelector('#txtTax').value = airport.Tax;
            document.querySelector('#coordenadaX').value = airport.Latitude;
            document.querySelector('#coordenadaY').value = airport.Longitude;

        };
        ApiService.getFromAPI("/getAirportById", idAirport, callback);


    }




});
