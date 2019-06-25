function vCreateAirline() {


    this.tblAirportId = 'tblAirport';

    this.ctrlActions = new ControlActions();


    this.Create = function () {
        var instance = this;
        if (!this.Validate()) {

            var airlineData = {};
            airlineData = this.ctrlActions.GetDataForm('frmEdition');
            let repeatedId = false;
            let airlines;
            let emailRepeated = false;
            let callback = function (response) {

                airlines = response.Data;

                for (let i = 0; i < airlines.length; i++) {
                    if (airlines[i]['Id'] === document.querySelector('#txtId').value) {
                        repeatedId = true;
                        break;
                    }
                }

                if (repeatedId) {
                    document.querySelector('#txtId').classList.add('input-error');
                    swal({
                        title: "Error al registrar aerolínea",
                        text: "Cédula jurídica ya se encuentra registrada en el sistema",
                        icon: "error",
                        button: "Ok",
                    });

                }
                else {
                    for (let i = 0; i < airlines.length; i++) {
                        if (airlines[i]['Email'] == document.querySelector('#txtEmail').value) {
                            emailRepeated = true;
                        }
                    }
                    if (emailRepeated) {
                        document.querySelector('#txtEmail').classList.add('input-error');
                        swal({
                            title: "Error al registrar aerolínea",
                            text: "Correo electrónico ya se encuentra registrado en el sistema",
                            icon: "error",
                            button: "Ok",
                        });
                    }
                    else {

                        var creationYear = new Date(document.querySelector('#txtCreationYear').value.split('-'));
                        var today = new Date();
                        if (creationYear > today) {
                            document.querySelector('#txtCreationYear').classList.add('input-error');

                            swal({
                                title: "Error al registrar aerolínea",
                                text: "La fecha de creación no es válida",
                                icon: "error",
                                button: "Ok",
                            });
                        }

                        else {
                            airlineData.Status = true;
                            airlineData.Request = "waiting";
                            localStorage.setItem('idAirlineLS', airlineData.ID);

                            localStorage.setItem('emailAirportLS', document.querySelector("#txtEmail").value);


                            instance.ctrlActions.PostToAPI('CreateAirline', airlineData, function () {


                                swal({
                                    title: "¡Aerolínea registrada!",
                                    text: "Ahora procederá a registrar un administrador",
                                    icon: "success",
                                    button: "OK"
                                }).then(function () {

                                    window.location.href = 'http://dev.corecode.com/vCreateAirlineAdmin';


                                });
                            });
                        }
                    }

                    
                }
            }
            instance.ctrlActions.GetFromAPI("/getAirlines", "", callback);


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

    var vairline = new vCreateAirline();

});
