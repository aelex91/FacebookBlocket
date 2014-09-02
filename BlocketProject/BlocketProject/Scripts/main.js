
//(function () {

//    $(".textfield").on("click", function () {
//        $(this).addClass("active");
//    });

//})();

function textfieldpressed(id) {
    var element = $('#' + id);
    element.addClass("active");
    if (element[0].value == "Namn") {
        element[0].value = "";
    }
    if (element[0].value == "Email") {
        element[0].value = "";
    }
    if (element[0].value == "Telefon") {
        element[0].value = "";
    }
    if (element[0].value == "Rubrik") {
        element[0].value = "";
    }
}

function textfieldblur(id) {
    var element = $('#' + id);
    element.removeClass("active");
 
    if (element[0].value == "" && id == "email") {
        element[0].value = "Email";
    }
    else{
        element.addClass("text");
    }
    if (element[0].value == "" && id == "phone") {
        element[0].value = "Telefon";
    }
    else {
        element.addClass("text");
    }
    if (element[0].value == "" && id == "title") {
        element[0].value = "Rubrik";
    }
    else {
        element.addClass("text");
    }
}

function textfieldbigpressed() {
    var element = $('#text');
    element.addClass("active");
}

function textfieldbigblur() {
    var element = $('#text');
    element.removeClass("active");
}
