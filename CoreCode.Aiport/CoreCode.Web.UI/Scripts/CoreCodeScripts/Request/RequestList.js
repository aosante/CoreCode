


showAirlinesRequests();
document.querySelector('#tblAirline').classList.add('hide');
showAirlinesRequests();


function showAirlinesRequests() {


    let user = JSON.parse(sessionStorage.getItem('user'));


    let airlines;
    let callback = function (response) {
        airlines = response.Data;


        let bodyTable = document.querySelector('#tblAirline tbody');
        
        bodyTable.innerHTML = '';

        for (let i = 0; i < airlines.length; i++) {

            //if (user['Rol'] == '1') {

                

            //}
            //if (user['Rol'] == '2') {

            //}

            if (airlines[i]['Status'] == false && airlines[i]['Requested'] == true) {//ESTO VA EN EL IF 
                        document.querySelector('#tblAirline').classList.remove('hide');//DE ROL '1'
                        let row = bodyTable.insertRow();

                        let cCodeId = row.insertCell();
                        let cComercialName = row.insertCell();
                        let cCreationyear = row.insertCell();
                        let cDescription = row.insertCell();
                        let cEmail = row.insertCell();
                        let cConfiguration = row.insertCell();

                        cCodeId.appendChild(document.createTextNode(airlines[i]['Id']));
                        cComercialName.appendChild(document.createTextNode(airlines[i]['Comercial_name']));
                        cCreationyear.appendChild(document.createTextNode(airlines[i]['Creation_year']));
                        cDescription.appendChild(document.createTextNode(airlines[i]['Description']));
                        cEmail.appendChild(document.createTextNode(airlines[i]['Email']));


                        let acceptBtn = document.createElement('button');
                        acceptBtn.innerHTML = 'Aceptar';
                        acceptBtn.dataset.idAirline = airlines[i]['Id'];
                

                        acceptBtn.addEventListener('click', accept);

                        let rejectBtn = document.createElement('button');
                        rejectBtn.innerHTML = 'Rechazar';
                        rejectBtn.dataset.idAirline = airlines[i]['Id'];

                        rejectBtn.addEventListener('click', reject);

                        cConfiguration.appendChild(acceptBtn);
                        cConfiguration.appendChild(rejectBtn);

                    }

                

              
        }
    }
    ApiService.getFromAPI("/getAirlines", "", callback);
}


function accept() {
    let idAirline = {
        id: this.dataset.idAirline
    };
    let airline;
    let callback = function (response) {

        airline = response.Data;
        airline.Status = true;

        let callback2 = function (response) {
        };
        ApiService.postToAPI("/updateAirline", airline, callback2);

    };

    ApiService.getFromAPI("/getAirlineById", idAirline, callback);

    swal({
        title: "Aerolinea aceptada",
        text: "",
        icon: "success",
        button: "OK",
    }).then(function () {
        showAirlinesRequests();

    });
}

function reject() {

    let idAirline = {
        id: this.dataset.idAirline
    };

    let airline;
    let callback = function (response) {
        airline = response.Data;
        airline.Status = false;
        airline.Denied = true;

        let callback2 = function (response) {
        };

        ApiService.postToAPI("/updateAirline", airline, callback2);
    };
    ApiService.getFromAPI("/getAirlineById", idAirline, callback);

    swal({
        title: "Aerolinea rechazada",
        text: "",
        icon: "success",
        button: "OK",
    }).then(function () {
        showAirlinesRequests();

    });
}

function redirectToRegisterAirline() {
    window.location.href = 'http://dev.corecode.com/CreateAirline';
}