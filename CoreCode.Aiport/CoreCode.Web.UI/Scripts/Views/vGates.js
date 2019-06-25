function vGates() {


    this.tblGateId = 'tblGate';
    this.service = 'gate';
    this.ctrlActions = new ControlActions();
    this.columns = "IDGate,Number";
    this.AirportId = UserSession.getAirportInstance().ID;//AGARRA IDASSIGNED DE SESSION STORAGE //"ARPT-1";
    this.rolUser = UserSession.getCurrentUserInstance().Rol;

    this.GateStatusDropdownChange = function () {

        if (document.querySelector('#statusFilter').value === "true") {

            document.querySelector("#btnEnable").classList.add('hide');
            document.querySelector("#btnDisable").classList.remove('hide');

            this.ctrlActions.ClearTable(this.tblGateId);
            this.RetrieveAvailable();

        }
        else if (document.querySelector('#statusFilter').value === "false") {
            document.querySelector("#btnEnable").classList.remove('hide');
            document.querySelector("#btnDisable").classList.add('hide');

            this.ctrlActions.ClearTable(this.tblGateId);
            this.RetrieveUnavailable();

        }

    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable('getGates', this.tblGateId, false, 'Buscar:', 'Código ó # de puerta');
    }

    this.RetrieveAvailable = function () {
        this.ctrlActions.FillTable('getAvailableArptGates', this.tblGateId, false, 'Buscar:', 'Código ó # de puerta', { id: this.AirportId });
        this.ReloadTable();
    }
    this.RetrieveUnavailable = function () {
        this.ctrlActions.FillTable('getUnavailableArptGates', this.tblGateId, false, 'Buscar:', 'Código ó # de puerta', { id: this.AirportId });
        this.ReloadTable();
    }

    this.ReloadTable = function () {
        this.ctrlActions.ReloadTable(this.tblGateId);
    }

    this.Create = function () {

        if (document.querySelector('#txtId').value == ''
            && document.querySelector('#nbmNumber').value == '') {

            document.querySelector('#txtId').classList.remove('input-error');
            document.querySelector('#nbmNumber').classList.remove('input-error');


            var instance = this;

            let gates;
            let cont = 0;
            let callback = function (response) {
                gates = response.Data;

                for (let i = 0; i < gates.length; i++) {
                    if (gates[i]['IDAirport'] == instance.AirportId) {
                        cont++;
                    }
                }
                cont = cont + 1;

                var gateData = {};
                
                gateData.IDGate = instance.AirportId +"-GT"+ cont.toString();
                gateData.IDAirport = instance.AirportId;
                gateData.Status = true;
                gateData.Number = cont;
                instance.ctrlActions.PostToAPI('postGate', gateData, function () {
                    //Refresca la tabla
                    swal({
                        title: "¡Puerta registrada!",
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
            instance.ctrlActions.GetFromAPI("/getGates", "", callback);



        }
        else {

            document.querySelector('#txtId').classList.add('input-error');
            document.querySelector('#nbmNumber').classList.add('input-error');

            swal({
                title: "¡Error al registrar puerta!",
                text: "El formulario no debe contener información de otra puerta",
                icon: "error",
                button: "OK",
            });
        }




    }


    this.Enable = function () {
        var instance = this;
        if (!this.Validate()) {
            var gateData = {};
            gateData = this.ctrlActions.GetDataForm('frmEdition');
            //Hace el post al create
            gateData.IDAirport = instance.AirportId
            gateData.Status = true;

            this.ctrlActions.PostToAPI('updateGate', gateData, function () {
                //Refresca la tabla
                swal({
                    title: "¡Puerta habilitada!",
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
                title: "¡Error al habilitar puerta!",
                text: "Por favor, seleccionar una puerta a habilitar en la tabla",
                icon: "error",
                button: "OK",
            });
        }

    }


    this.Disable = function () {
        var instance = this;
        if (!this.Validate()) {
            var gateData = {};
            gateData = this.ctrlActions.GetDataForm('frmEdition');
            //Hace el post al create
            gateData.IDAirport = instance.AirportId
            gateData.Status = false;

            this.ctrlActions.PostToAPI('updateGate', gateData, function () {
                //Refresca la tabla
                swal({
                    title: "¡Puerta deshabilitada!",
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
                title: "¡Error al deshabilitar puerta!",
                text: "Por favor, seleccionar una puerta a habilitar en la tabla",
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
        document.querySelector('#txtId').value = '';
        document.querySelector('#nbmNumber').value = '';
        document.querySelector('#txtId').disabled = true;
        document.querySelector('#nbmNumber').disabled = true;

        let aInputs = document.querySelectorAll(':required');
        for (let i = 0; i < aInputs.length; i++) {
            aInputs[i].classList.remove('input-error');
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


    document.querySelector("#txtId").disabled = true;
    document.querySelector("#nbmNumber").disabled = true;
    document.querySelector("#btnEnable").classList.add('hide');

    var vgate = new vGates();

        vgate.RetrieveAvailable();
    




});
