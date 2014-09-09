
(function () {

})();



function textfieldpressed(onClass) {
   
    var element = $('#' + id);
    if (id == 'textfield') {
        element.addClass("active");

        element[0].value = "";
    }
    
}
function textfieldblur(id) {
    var element = $('#' + id);
    element.removeClass("active");

    var hasvalue = true;

    if (element[0].value == "" && id == "email") {
        element[0].value = "Email";
        element.removeClass("hasText");
        hasvalue = false;
    }

    if (element[0].value == "" && id == "phone") {
        element[0].value = "Telefon";
        element.removeClass("hasText");
        hasvalue = false;
    }

    if (element[0].value == "" && id == "title") {
        element[0].value = "Rubrik";
        element.removeClass("hasText");
        hasvalue = false;
    }

    if (element[0].value == "" && id == "price") {
        element[0].value = "Pris";
        element.removeClass("hasText");
        hasvalue = false;
    }
    if (hasvalue == true) {
        element.addClass("hasText");
    }
}

function textareapressed(id) {
    var element = $('#' + id);
    element.addClass("active");
    element[0].placeholder = "";

}

function textareablur(id) {
    var element = $('#' + id);
    element.removeClass("active");
}

function validateemail() {

    var element = $('#email');

    if (element[0].value != "" && element[0].value != "Email") {
        var filter = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
        if (!filter.test(element[0].value)) {
            element.addClass("error");
            return false;
        }
        else {
            element.removeClass("error");
        }
    }
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}
