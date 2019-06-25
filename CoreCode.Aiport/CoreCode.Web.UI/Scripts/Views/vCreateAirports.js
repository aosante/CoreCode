function vCreateAirports() {


    this.tblAirportId = 'tblAirport';

    this.ctrlActions = new ControlActions();


    this.Create = function () {
        var instance = this;
        if (!this.Validate()) {

            var airportData = {};
            airportData = this.ctrlActions.GetDataForm('frmEdition');

            let repeatedZipCode = false;
            let repeatedCoordenates = false;
            let airports;
            let cont = 0;
            let cont2 = 0
            let callback = function (response) {

                airports = response.Data;

                for (let i = 0; i < airports.length; i++) {
                    if (airports[i]['ZipCode'] == document.querySelector('#txtZipCode').value) {
                        repeatedZipCode = true;
                    }
                }

                if (repeatedZipCode) {
                    document.querySelector('#txtZipCode').classList.add('input-error');

                    swal({
                        title: "Codigo postal ya se encuentra asignado",
                        text: "Otro aeropuerto cuenta con el mismo código postal",
                        icon: "error",
                        button: "Ok",
                    });

                }
                else {
                    for (let i = 0; i < airports.length; i++) {
                        if (airports[i]['Latitude'] == document.getElementById('coordenadaX').value
                            && airports[i]['Longitude'] == document.getElementById('coordenadaY').value) {
                            repeatedCoordenates = true;
                        }
                    }

                    if (repeatedCoordenates) {
                        document.querySelector('#txtAddress').classList.add('input-error');
                        swal({
                            title: "Ubicación no permitida",
                            text: "Otro aeropuerto se encuentra en está ubicación",
                            icon: "error",
                            button: "Ok",
                        });
                    }
                    else {
                        for (let i = 0; i < airports.length; i++) {
                            cont++;

                        }
                        cont = cont + 1;
                        airportData.ID = "ARPT-" + cont.toString();
                        airportData.Status = true;
                        localStorage.setItem('idAirportLS', airportData.ID);


                        instance.ctrlActions.PostToAPI('postAirport', airportData, function () {

                            let numberGates = document.querySelector('#nbmGates').value;

                            if (numberGates <= 0) {
                                document.querySelector('#nbmGates').classList.add('input-error');
                                swal({
                                    title: "Cantidad de puertas no permitida",
                                    text: "Por favor, ingresar un número positivo",
                                    icon: "error",
                                    button: "Ok",
                                });
                            }
                            else {
                                for (let i = 0; i < numberGates; i++) {
                                    let callback2 = function (response) {
                                        gates = response.Data;

                                        //for (let i = 0; i < gates.length; i++) {
                                        //    if (gates[i]['IDAirport'] == localStorage.getItem('idAirportLS')) {
                                        //        cont2++;
                                        //    }
                                        //}
                                        cont2 = cont2 + 1;

                                        var gateData = {};

                                        gateData.IDGate = localStorage.getItem('idAirportLS') + "-GT" + cont2.toString();
                                        gateData.IDAirport = localStorage.getItem('idAirportLS');
                                        gateData.Status = true;
                                        gateData.Number = cont2;
                                        instance.ctrlActions.PostToAPI('postGate', gateData, function () {

                                        });

                                    }
                                    ApiService.getFromAPI("/getGates", "", callback2);
                                }

                                swal({
                                    title: "¡Aeropuerto registrado!",
                                    text: "Ahora procederá a registrar un administrador",
                                    icon: "success",
                                    button: "OK"
                                }).then(function () {

                                    window.location.href = 'http://dev.corecode.com/vCreateAirportAdmin';
                                });
                            }


                        });


                    }
                }
            }
            instance.ctrlActions.GetFromAPI("getAirports", "", callback);


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

    this.CleanForm = function () {
        let aInputs = document.querySelectorAll(':required');
        for (let i = 0; i < aInputs.length; i++) {

            aInputs[i].value = '';


        }

    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    document.querySelector('#txtAddress').disabled = true;

    let geocoder = new google.maps.Geocoder();

    function geocodePosicion(pos) {
        geocoder.geocode({
            latLng: pos
        }, function (responses) {
            if (responses && responses.length > 0) {
                actualizarDireccionMarcador(responses[0].formatted_address); mapa
            } else {
                actualizarDireccionMarcador('No es posible establecer una dirección en esta posición.'); //si el usuario suelta el marcador en el mar o en lugar recóndito
            }
        });
    }

    //function actualizarStatusMarcador(str) {
    //    document.getElementById('statusMarcador').innerHTML = str;
    //}

    function actualizarPosicionMarcador(latLng) {
        document.getElementById('coordenadaX').value =
            latLng.lat();
        document.getElementById('coordenadaY').value =
            latLng.lng();
    }

    function actualizarDireccionMarcador(str) {
        //    document.getElementById('direccion').innerHTML = str;
        document.querySelector('#txtAddress').value = str;
    }

    function inicializar() {

        let latLng = new google.maps.LatLng(9.93268296319376, -84.03102832412719); //Ubicacion Cenfotec
        let map = new google.maps.Map(document.getElementById('mapa'), {
            zoom: 8, //vista mapa
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
            // actualizarStatusMarcador('Moviendo...');
            actualizarPosicionMarcador(marcador.getPosition());
        });

        google.maps.event.addListener(marcador, 'dragend', function () {
            //   actualizarStatusMarcador('Mueva el marcador para seleccionar su dirección');
            geocodePosicion(marcador.getPosition());
        });
    }

    // Controlador de carga para iniciar la aplicación.
    google.maps.event.addDomListener(window, 'load', inicializar);
    //fin del mapa


    var vairport = new vCreateAirports();
    //  vairport.RetrieveAll();

});
