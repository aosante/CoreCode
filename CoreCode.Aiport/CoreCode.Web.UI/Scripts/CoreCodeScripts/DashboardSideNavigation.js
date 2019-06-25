var DashboardNav = function() {
    var instance = this;
    this.userObject = JSON.parse(sessionStorage.getItem("userObject"));
};

DashboardNav.prototype.init = function() {
    var instance = this;
    var logOutElement = document.getElementById("log-out-btn");
    if (logOutElement) {
        logOutElement.style.display = 'block';
        logOutElement.addEventListener("click",
            function() {
                sessionStorage.removeItem("userObject");
                window.location.href = "http://dev.corecode.com";
            });
    }
    if (instance.userObject) {
        switch (instance.userObject.Rol) {
        case 1:
            instance.setNavForGeneralAdmin();
            break;
        case 3:
            instance.setNavForAirlineAdmin();
            break;
        case 2:
            instance.setNavForAirportAdmin();
            break;
        default:
            //Redirect to home page.
            location.href = window.location.protocol + "//" + window.location.hostname;
        }
    } else {
        //location.href = window.location.protocol + "//" + window.location.hostname;
    }
}


DashboardNav.prototype.setNavForGeneralAdmin = function() {
    //Airport List
    $("#airportNavBtn").fadeIn();
    $("#seeAirportsNavBtn").removeAttr('style');
    $("#createAirportsNavBtn").removeAttr('style');
    
    //Category List
    $("#categoryStore").fadeIn(1000);
    $("#addCategoryNavBtn").removeAttr('style');
    $("#viewCategoryNavBtn").removeAttr('style');
    
    $("#airlineNavBtn").fadeIn(1400);
    $("#viewAirlinesNavBtn").removeAttr('style');

    $("#faqNavBtn").fadeIn(1800);
    $("#viewFaqNavBtn").removeAttr('style');

    $("#flightsNavBtn").fadeIn(2200);
    $("#viewFlightsNavBtn").removeAttr('style');
};

DashboardNav.prototype.setNavForAirportAdmin = function() {
    //Airport List
    $("#airportNavBtn").fadeIn();
    $("#editAirportNavBtn").removeAttr('style');

    //Store List
    $("#storesNavBtn").fadeIn(1000);
    $("#createStoreNavBtn").removeAttr('style');
    $("#viewStores").removeAttr('style');

    //Gate List
    $("#gatesNavBtn").fadeIn(1600);
    $("#addGateNavBtn").removeAttr('style');
    $("#seeGatesNavBtn").removeAttr('style');

    //Airlines List
   $("#airlineNavBtn").fadeIn(2000);
    $("#viewAirlineRequests").removeAttr('style');
};

DashboardNav.prototype.setNavForAirlineAdmin = function() {
    //General Report
    //Airport 
    //Airport List
    $("#airportNavBtn").fadeIn();
    $("#seeAirportsRequests").removeAttr('style');
    //When Looking at a Airport Detail
    //Gates
    //See All Gates
    //Airline
    //Edit Airline
    //Delete Airline
    //Flights
        $("#flightsNavBtn").fadeIn(4000);
    $("#viewFlightsNavBtn").removeAttr('style');
    $("#viewTickets").removeAttr('style');
};

$(document).ready(function() {
    var dashboardNavInstance = new DashboardNav();
    dashboardNavInstance.init();
    setSidenavListeners();
});


// Sidenav list sliding functionality
function setSidenavListeners() {
    const subHeadings = $('.navList__subheading'); console.log('subHeadings: ', subHeadings);
    const SUBHEADING_OPEN_CLASS = 'navList__subheading--open';
    const SUBLIST_HIDDEN_CLASS = 'subList--hidden';

    subHeadings.each((i, subHeadingEl) => {
        $(subHeadingEl).on('click', (e) => {
            const subListEl = $(subHeadingEl).siblings();

            // Add/remove selected styles to list category heading
            if (subHeadingEl) {
                toggleClass($(subHeadingEl), SUBHEADING_OPEN_CLASS);
            }

            // Reveal/hide the sublist
            if (subListEl && subListEl.length === 1) {
                toggleClass($(subListEl), SUBLIST_HIDDEN_CLASS);
            }
        });
    });
}

function toggleClass(el, className) {
    if (el.hasClass(className)) {
        el.removeClass(className);
    } else {
        el.addClass(className);
    }
}



