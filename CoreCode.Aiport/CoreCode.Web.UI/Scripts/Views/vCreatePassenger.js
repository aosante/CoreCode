function vCreatePassenger() {


    this.ctrlActions = new ControlActions();
    this.userEmailHtmlElementId = "txtEmail ";
    this.userIdHtmlElementId = "txtId";
    this.Create = function () {

        var instance = this;
        if (!this.Validate()) {
            var user;
            var PassengerData = {};
            PassengerData = this.ctrlActions.GetDataForm('frmEdition');

            let callback = function (response) {
                user = response.Data;
                if (!user) {
                    var regEmail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                    if (!regEmail.test(document.querySelector('#txtEmail').value)) {
                        document.querySelector('#txtEmail').classList.add('input-error');
                        swal({
                            title: "Error al registrar Pasajero",
                            text: "Correo electrónico no cuenta con formato correcto",
                            icon: "error",
                            button: "Ok",
                        });

                    }
                    else {
                        var birthday = new Date(document.querySelector('#txtBirthDate').value.split('-'));
                        var today = new Date();
                        var age = today.getFullYear() - birthday.getFullYear();
                        var m = today.getMonth() - birthday.getMonth();

                        if (m < 0 || (m === 0 && today.getDate() < birthday.getDate())) {
                            age--;
                        }
                        console.log(age, typeof (age));
                        if (age < 18) {
                            document.querySelector('#txtBirthDate').classList.add('input-error');
                            swal({
                                title: "Error al registrar el Pasajero",
                                text: "Usuario debe ser mayor de edad",
                                icon: "error",
                                button: "Ok",
                            });
                        }

                        else {

                            PassengerData.Status = true;
                            PassengerData.Rol = "4";
                            PassengerData.Password = instance.GenerateRandomPassword();

                            instance.ctrlActions.PostToAPI('CreatePassenger', PassengerData, function () {

                                swal({
                                    title: "¡Pasajero registrado!",
                                    text: "Gracias por confiar en nosotros",
                                    icon: "success",
                                    button: "OK"
                                }).then(function () {
                                    instance.CleanForm();
                                    //    window.location.href = 'http://dev.corecode.com/vCreateAirlineAdmin';
                                });
                            });
                        }
                    }

                } else if (user.ID === document.querySelector('#txtId').value) {
                    document.querySelector('#txtId').classList.add('input-error');

                    swal({
                        title: "Error al registrar Pasajero",
                        text: "Cédula de identidad ya se encuentra registrada",
                        icon: "error",
                        button: "Ok",
                    });
                } else if (user.Email === document.querySelector('#txtEmail').value) {
                    document.querySelector('#txtEmail').classList.add('input-error');

                    swal({
                        title: "Error al registrar Pasajero",
                        text: "Correo electrónico ya se encuentra registrado",
                        icon: "error",
                        button: "Ok",
                    });

                }
            }
            instance.ctrlActions.GetFromAPI("checkIfUserExistsByUserNameOrId?userName=" + $("#" + instance.userEmailHtmlElementId).val() + "&id=" + $("#" + instance.userIdHtmlElementId).val() + "", "", callback);

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


        if (document.querySelector('#txtSecondName').value == "") {
            document.querySelector('#txtSecondName').value = "N/N";
        }
        if (document.querySelector('#txtSecondLastName').value == "") {
            document.querySelector('#txtSecondLastName').value = "N/N";
        }



        return bError;

    }



    this.CleanForm = function () {
        let aInputs = document.querySelectorAll(':required');
        for (let i = 0; i < aInputs.length; i++) {

            aInputs[i].value = '';


        }
        document.querySelector('#txtSecondName').value = '';
        document.querySelector('#txtSecondLastName').value = '';
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vPassenger = new vCreatePassenger();


});