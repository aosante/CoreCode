function vFaqs() {


    this.tblFaqId = 'tblFaq';
    this.service = 'category';
    this.ctrlActions = new ControlActions();
    this.columns = "ID,Question,Answer";


    this.FaqStatusDropdownChange = function () {

        if (document.querySelector('#statusFilter').value === "true") {


            document.querySelector("#btnEnable").classList.add('hide');
            document.querySelector("#btnDisable").classList.remove('hide');


            this.ctrlActions.ClearTable(this.tblFaqId);
            this.RetrieveAvailable();

        }
        else if (document.querySelector('#statusFilter').value === "false") {

            document.querySelector("#btnEnable").classList.remove('hide');
            document.querySelector("#btnDisable").classList.add('hide');

            this.ctrlActions.ClearTable(this.tblFaqId);
            this.RetrieveUnavailable();

        }

    }



    this.RetrieveAll = function () {
        this.ctrlActions.FillTable('getFAQS', this.tblFaqId, false, 'Buscar:', 'Código');
    }

    this.RetrieveAvailable = function () {
        this.ctrlActions.FillTable('getAvailableFaqs', this.tblFaqId, false, 'Buscar', 'ID/Pregunta/Respuesta');
        this.ReloadTable();
    }
    this.RetrieveUnavailable = function () {
        this.ctrlActions.FillTable('getUnavailableFaqs', this.tblFaqId, false, 'Buscar','ID/Pregunta/Respuesta');
        this.ReloadTable();
    }
    this.ReloadTable = function () {
        this.ctrlActions.ReloadTable(this.tblFaqId);
    }

    this.Create = function () {
        var instance = this;

        if (!this.Validate()) {
            document.querySelector('#txtId').value = ''
            var faqData = {};
            faqData = this.ctrlActions.GetDataForm('frmEdition');
            //Hace el post al create
            let faqs;
            let cont = 0;
            let repeatedQuestion = false;
            let callback = function (response) {

                faqs = response.Data;
                for (let i = 0; i < faqs.length; i++) {
                    if (faqs[i]['Question'] == document.querySelector('#txtQuestion').value) {
                        repeatedQuestion = true;
                    }
                }
                if (repeatedQuestion) {
                    document.querySelector('#txtQuestion').classList.add('input-error');

                    swal({
                        title: "Pregunta ya se encuentra en el sistema",
                        text: "Revisar campos resaltados",
                        icon: "error",
                        button: "Ok",
                    }).then(function () {
                        document.querySelector("#txtId").value = '';
                    });

                } else {
                    for (let i = 0; i < faqs.length; i++) {
                        cont++;

                    }
                    cont = cont + 1;
                    //Hace el post al create

                    faqData.ID = "FAQ-" + cont.toString();
                  
                    instance.ctrlActions.PostToAPI('postFAQ', faqData, function () {
                        //Refresca la tabla
                        swal({
                            title: "¡FAQ registrada!",
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



            }
            instance.ctrlActions.GetFromAPI("/getFaqs", "", callback);
           
           

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
        var instance = this;

        if (!this.Validate()) {


            var faqData = {};
            faqData = this.ctrlActions.GetDataForm('frmEdition');
            faqDataStatus = true;
            instance.ctrlActions.PostToAPI('updateFAQ', faqData, function () {
                //Refresca la tabla
                swal({
                    title: "¡FAQ actualizada!",
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

    this.Enable = function () {

        var instance = this;

        if (!this.Validate()) {


            var faqData = {};
            faqData = this.ctrlActions.GetDataForm('frmEdition');
            faqDataStatus = true;
            instance.ctrlActions.PostToAPI('updateFAQ', faqData, function () {
                //Refresca la tabla
                swal({
                    title: "¡FAQ habilitada!",
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


    this.Disable = function () {
        var instance = this;

        if (!this.Validate()) {


            var faqData = {};
            faqData = this.ctrlActions.GetDataForm('frmEdition');
            faqDataStatus = false;
            instance.ctrlActions.PostToAPI('updateFAQ', faqData, function () {
                //Refresca la tabla
                swal({
                    title: "¡FAQ actualizada!",
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
        document.querySelector("#txtId").value = '';
        document.querySelector('#txtQuestion').value = '';
        document.querySelector('#txtAnswer').value = '';
        

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
    document.querySelector("#btnEnable").classList.add('hide');
    
    var vfaq = new vFaqs();
    vfaq.RetrieveAvailable();

});
