function vTicket() {

    // agarrar email session storagevar emailuser = '';
    this.tblTicketId = 'tblTickets';
    this.service = 'ticket';
    this.ctrlActions = new ControlActions();
    this.columns = "Id,Id_Flight, Ticket_Class, Status, Price, Buy_Date, Id_Person, Person_Name";

    this.FlightStatusDropdownChange = function () {

        if (document.querySelector('#statusFilter').value === "a tiempo") {
            this.ctrlActions.ClearTable(this.tblTicketId);
            this.RetrieveATiempo();

        }
        else if (document.querySelector('#statusFilter').value === "cancelado") {
            this.ctrlActions.ClearTable(this.tblTicketId);
            this.RetrieveCancelado();

        }

        else if (document.querySelector('#statusFilter').value === "retrasado") {
            this.ctrlActions.ClearTable(this.tblTicketId);
            this.RetrieveRetrasado();

        }

    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable('getTickets', this.tblTicketId, false, 'Buscar:', 'Código o nombre');
    }

    this.RetrieveATiempo = function () {
        this.ctrlActions.FillTable('getTicketOnTime', this.tblTicketId, false, 'Buscar:', 'Código o nombre');
    }

    this.RetrieveCancelado = function () {
        this.ctrlActions.FillTable('getTicketCanceled', this.tblTicketId, false, 'Buscar:', 'Código o nombre');
    }
    this.RetrieveRetrasado = function () {
        this.ctrlActions.FillTable('getTicketDelay', this.tblTicketId, false, 'Buscar:', 'Código o nombre');
    }
    this.ReloadTable = function () {
        this.ctrlActions.ReloadTable(this.tblTicketId);
    }

    this.Paypal = function () {

    };

    this.Create = function () {
        if (!this.Validate()) {
            var TicketData = {};
            var instance = this;
            TicketData = this.ctrlActions.GetDataForm('frmEdition');
            TicketData.Status = "a tiempo";
            TicketData.Id_Person = "1";  //tiene que jalar el id del usuario del session storage

            var note = new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0];

            var prueba = note.toString("'yyyy-MM-dd'T'HH:mm'");

            var email = "jobrenesr@gmail.com";

            TicketData.add.email = email;

            //Fecha para poner la hora exacta a la hora de comprar el tiquete
            TicketData.Buy_Date = note.toString("'yyyy-MM-dd'T'HH:mm'");
            //Hace el post al create
            // 
            this.ctrlActions.PostToAPI('createTicket', TicketData, function (response) {
                swal({
                    title: "¡Compra registrada!",
                    text: "Le llegará un correo con los datos de su compra",
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

    this.Update = function () {

        var TicketData = {};
        TicketData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        TicketData.Status = "a tiempo";
        this.ctrlActions.PostToAPI('SP_UPDATETICKET', TicketData);
        //Refresca la tabla
        this.CleanForm();
        this.ReloadTable();
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

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
        document.getElementById("txtId").setAttribute("disabled", "disabled");
        document.getElementById("txtId").setAttribute("disabled", "disabled");
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

$(document).ready(function () {

    //document.querySelector("#txtId").disabled = true;
    //document.querySelector("#txtId_Flight").disabled = true;
    //document.querySelector("#txtStatus").disabled = true;
    //document.querySelector("#txtPrice").disabled = true;
   // document.querySelector("#txtBuy_Date").disabled = true;
    //document.querySelector("#txtId_Person").disabled = true;
   // var datenow = new Date().toString();
    //document.getElementById("#txtBuy_Date").innerHTML(datenow);
    //txtId_Flight

  //  var now = new Date();

   var note = new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0];

    var prueba = note.toString("'yyyy-MM-dd'T'HH:mm'");

    $('#txtBuy_Date').val(prueba);
    $('#txtStatus').val("a tiempo");
   

    $('#txtId').val(generar());
   // $('#txtBuy_Date').val(new Date().toDateInputValue()); 
    var vticket = new vTicket();
    vticket.RetrieveATiempo();


    //Función para generar la clave de reservación 
    function generar() {
        var caracteres = "ABCDEFGHIJKLMNPQRTUVWXYZ2346789";
        var reservation = "";
        var longitud = 6;
        for (i = 0; i < longitud; i++) reservation += caracteres.charAt(Math.floor(Math.random() * caracteres.length));
        return reservation;
    }
});