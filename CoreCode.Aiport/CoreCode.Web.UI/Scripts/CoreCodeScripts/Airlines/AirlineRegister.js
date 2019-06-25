let btnRegister = document.querySelector('#btnRegisterAirline');
btnRegister.addEventListener('click', registerAirline);

//document.querySelector("#btnCancel").addEventListener('click', cleanForm);

function registerAirline() {



    let bError = validate();
    if (bError == true) {

        swal({
            title: "¡Ocurrió un error!",
            text: "Revisar campos vacíos",
            icon: "error",
            button: "OK",
        });
    }
    else {


        let nameValue = document.querySelector('#txtComercialName').value;
        let businessValue = document.querySelector('#txtBusinessName').value;
        let creationyearValue = document.querySelector('#txtCreationYear').value;
        let descriptionValue = document.querySelector('#txtDescription').value;
        let emailValue = document.querySelector('#txtEmail').value;

        let cont = 0;
        let airlines;
        let Callback = function (response) {
            airlines = response.Data;
            let valido = false;

            for (let i = 0; i < airlines.length; i++) {
                cont++;

            }

            cont = cont + 1;

 

            let jsonItem = {
                "ID": "AIR-"+ cont.toString(),
                "COMERCIAL_NAME": nameValue,
                "BUSINESS_NAME": businessValue,
                "CREATION_YEAR": creationyearValue,
                "DESCRIPTION": descriptionValue,
                "EMAIL": emailValue,
                "STATUS": false,
                "REQUESTED": true,
                "DENIED":false

                };

                ApiService.postToAPI("/CreateAirline", jsonItem);

            

        }
        ApiService.getFromAPI("/getAirlines", "", Callback);

        swal({
            title: "Aerolinea registrada",
            text: "",
            icon: "success",
            button: "Ok",
        }).then(function () {
          
            window.location.href = "http://dev.corecode.com/CreateAirline ";
        });
    }
}

function validate() {
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


function cleanForm() {
    document.querySelector('#txtId').value = '';
    document.querySelector('#txtComercialName').value = '';
    document.querySelector('#txtBusinessName').value = '';
    document.querySelector('#txtCreationYear').value = '';
    document.querySelector('#txtDescription').value = '';
    document.querySelector('#txtEmail').value = '';
    document.querySelector('#txtStatus').value = '';
}



    /*function checkEmail() {

        var email = document.getElementById('txtEmail');
        var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

        if (!filter.test(email.value)) {
            alert('Please provide a valid email address');
            email.focus;
            return false;
        }
    }*/
