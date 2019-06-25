function vRequestAdminAirlineToAirport() {

    this.AirlineId = UserSession.getAirlineSessionInstance().Id;
    this.tblAirportId = 'tblAirport';
    this.service = 'gate';
    this.ctrlActions = new ControlActions();
    this.columns = "ID", "Name", "Address", "Phone", "ZipCode", "GateTariff", "RunwayTariff", "Tax", "Latitude", "Longitude";

    this.AirportStatusDropdownChange = function () {

        if (document.querySelector('#statusFilter').value === "true") {
            document.querySelector("#btnDisable").classList.remove('hide');
            document.querySelector("#btnRequestAirport").classList.add('hide');

            this.ctrlActions.ClearTable(this.tblAirportId);
            this.RetrieveAssociatedAirports();

        }
        else if (document.querySelector('#statusFilter').value === "false") {

            document.querySelector("#btnDisable").classList.add('hide');
            document.querySelector("#btnRequestAirport").classList.remove('hide');
            
            this.ctrlActions.ClearTable(this.tblAirportId);
            this.RetrieveNonAssociatedAirports();

        }

    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable('getAirports', this.tblAirportId, false, 'Buscar:', 'Código o número');
    }

    this.RetrieveAssociatedAirports = function () {
        this.ctrlActions.FillTable('getAssociatedAirports', this.tblAirportId, false, 'Buscar:', 'Código o nombre', { id: this.AirlineId });
        this.ReloadTable();
    }
    //Cedula juridica de la aerolinea al final
    this.RetrieveNonAssociatedAirports = function () {
        this.ctrlActions.FillTable('getNonAssociatedAirports', this.tblAirportId, false, 'Buscar:', 'Código o nombre', { id: this.AirlineId });
        this.ReloadTable();
    }

   

    this.ReloadTable = function () {
        this.ctrlActions.ReloadTable(this.tblAirportId);
    }


    this.CreateRequest = function () {


        var instance = this;
        if (!this.Validate()) {
           


            let requestToAirport = {
                "IDAirline": instance.AirlineId,//cedula juridica de la aerolinea en sesion
                "IDAirport": document.getElementById("txtId").value,
            };



            this.ctrlActions.PostToAPI('postRequestAirlineAirport', requestToAirport, function () {
                //Refresca la tabla
                swal({
                    title: "¡Solicitud realizada!",
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
                title: "¡Error al realizar solicitud!",
                text: "Por favor, seleccionar un aeropuerto en la tabla",
                icon: "error",
                button: "OK",
            });
        }




    }


    this.Disable = function () {


        var instance = this;
        if (!this.Validate()) {



            let requestToAirport = {
                "IDAirline": instance.AirlineId,//cedula juridica de la aerolinea en sesion
                "IDAirport": document.getElementById("txtId").value,
                "Request": "rejected",
            };



            this.ctrlActions.PostToAPI('updateRequestAirlineAirport', requestToAirport, function () {
                //Refresca la tabla
                swal({
                    title: "¡Convenio con el aeropuerto cancelado!",
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
                title: "¡Error al cancelar convenio!",
                text: "Por favor, seleccionar un aeropuerto en la tabla",
                icon: "error",
                button: "OK",
            });
        }


    }


    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
        document.getElementById("txtId").setAttribute("disabled", "disabled");
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
    
    document.querySelector("#txtAddress").disabled = true;
    document.querySelector("#btnDisable").classList.remove('hide');
    document.querySelector("#btnRequestAirport").classList.add('hide');
     let aInputs = document.querySelectorAll(':required');

    for (let i = 0; i < aInputs.length; i++) {       
            aInputs[i].disabled = true;
    }

    var vrequestAdminAirline = new vRequestAdminAirlineToAirport();
    vrequestAdminAirline.RetrieveAssociatedAirports();

});
