showAirlines();
document.querySelector('#txtFilter').addEventListener('keyup', showAirlines);
document.querySelector('#statusFilter').addEventListener('change', showAirlines);
document.querySelector('#btnRegisterAirline').addEventListener('click', redirectToRegisterAirline);

document.querySelector('#tblAirline').classList.add('hide');
document.querySelector('#tblAirline2').classList.add('hide');
showAirlines();


function showAirlines() {

    let airlines;
    let callback = function (response) {
        airlines = response.Data;


        let bodyTable = document.querySelector('#tblAirline tbody');
        let bodyTable2 = document.querySelector('#tblAirline2 tbody');

        let sFilter = document.querySelector('#txtFilter').value.toLowerCase();
        let statusFilter = document.querySelector('#statusFilter').value;

        bodyTable.innerHTML = '';
        bodyTable2.innerHTML = '';

        for (let i = 0; i < airlines.length; i++) {
            if ((airlines[i]['Id'].toLowerCase().includes(sFilter))
                || (airlines[i]['Comercial_name'].toLowerCase().includes(sFilter))) {

                if (statusFilter == "true") {

                    if (airlines[i]['Status'] == true) {
                        document.querySelector('#tblAirline').classList.remove('hide');
                        document.querySelector('#tblAirline2').classList.add('hide');
                        let row = bodyTable.insertRow();

                        let cCodeId = row.insertCell();
                        let cComercialName = row.insertCell();
                        let cBusinesslName = row.insertCell();
                        let cCreationyear = row.insertCell();
                        let cDescription = row.insertCell();
                        let cEmail = row.insertCell();
                        let cConfiguration = row.insertCell();

                        cCodeId.appendChild(document.createTextNode(airlines[i]['Id']));
                        cComercialName.appendChild(document.createTextNode(airlines[i]['Comercial_name']));
                        cBusinesslName.appendChild(document.createTextNode(airlines[i]['Business_name']));
                        cCreationyear.appendChild(document.createTextNode(airlines[i]['Creation_year']));
                        cDescription.appendChild(document.createTextNode(airlines[i]['Description']));
                        cEmail.appendChild(document.createTextNode(airlines[i]['Email']));


                        let editBtn = document.createElement('button');
                        editBtn.classList.add("btn", "btn-outline-success");
                        editBtn.innerHTML = 'Editar';
                        editBtn.dataset.idAirline = airlines[i]['Id'];

                        //EDIT BUTTON FUNCTION, POSSIBLE ERROR
                        let edit = function () {
                            let idAirline = this.dataset.idAirline;
                            localStorage.setItem('idAirlineLS', idAirline);
                            console.log("edit");
                            window.location.href = 'http://dev.corecode.com/EditAirline';
                            
                            
                        }

                        editBtn.addEventListener('click', edit);

                        let disableBtn = document.createElement('button');
                        disableBtn.innerHTML = 'Deshabilitar';
                        disableBtn.classList.add("btn", "btn-outline-danger");
                        disableBtn.dataset.idAirline = airlines[i]['Id'];

                        disableBtn.addEventListener('click', disable);

                        cConfiguration.appendChild(editBtn);
                        cConfiguration.appendChild(disableBtn);

                    }

                }

                if (statusFilter == "false") {

                    document.querySelector('#tblAirline').classList.add('hide');
                    document.querySelector('#tblAirline2').classList.remove('hide');

                    if (airlines[i]['Status'] == false) {
                        let row = bodyTable2.insertRow();

                        let cCodeId = row.insertCell();
                        let cComercialName = row.insertCell();
                        let cBusinesslName = row.insertCell();
                        let cCreationyear = row.insertCell();
                        let cDescription = row.insertCell();
                        let cEmail = row.insertCell();
                        let cEnable = row.insertCell();

                        cCodeId.appendChild(document.createTextNode(airlines[i]['Id']));
                        cComercialName.appendChild(document.createTextNode(airlines[i]['Comercial_name']));
                        cBusinesslName.appendChild(document.createTextNode(airlines[i]['Business_name']));
                        cCreationyear.appendChild(document.createTextNode(airlines[i]['Creation_year']));
                        cDescription.appendChild(document.createTextNode(airlines[i]['Description']));
                        cEmail.appendChild(document.createTextNode(airlines[i]['Email']));

                        let enableBtn = document.createElement('button');
                        enableBtn.innerHTML = 'Habilitar';
                        enableBtn.classList.add("btn", "btn-outline-success");
                        enableBtn.dataset.idAirline = airlines[i]['Id'];

                        enableBtn.addEventListener('click', enable);

                        cEnable.appendChild(enableBtn);
                    }
                }
            }
        }
    }
    ApiService.getFromAPI("/getAirlines", "", callback);
}


function enable() {
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
        title: "Aerolinea habilitada",
        text: "",
        icon: "success",
        button: "OK",
    }).then(function () {
        showAirlines();

    });
}

function disable() {

    let idAirline = {
        id: this.dataset.idAirline
    };

    let airline;
    let callback = function (response) {
        airline = response.Data;
        airline.Status = false;

        let callback2 = function (response) {
        };

        ApiService.postToAPI("/updateAirline", airline, callback2);
    };
    ApiService.getFromAPI("/getAirlineById", idAirline, callback);

    swal({
        title: "Aerolinea deshabilitada",
        text: "",
        icon: "success",
        button: "OK",
    }).then(function () {
        showAirlines();

    });
}

function redirectToRegisterAirline() {
    window.location.href = 'http://dev.corecode.com/CreateAirline';
}