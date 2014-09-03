
//(function () {

//    $(".textfield").on("click", function () {
//        $(this).addClass("active");
//    });

//})();

function textfieldpressed(id) {
    var element = $('#' + id);
    element.addClass("active");
    //if (element[0].value == "Namn") {
    //    element[0].value = "";
    //}
    //if (element[0].value == "Email") {
    //    element[0].value = "";
    //}
    //if (element[0].value == "Telefon") {
    //    element[0].value = "";
    //}
    //if (element[0].value == "Rubrik") {
    //    element[0].value = "";
    //}
    //if (element[0].value == "Pris") {
    //    element[0].value = "";
    //}
    if (element[0].id == "email" || element[0].id == "phone" || element[0].id == "title" || element[0].id == "price")
    {
        $('#' + id).focus();
        $('#' + id).get(0).setSelectionRange(0, 0);
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
    if (element[0].value == "" && id == "price") {
        element[0].value = "Pris";
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

function emailkoll() {

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

function focus() {
    var element = $('#phone');
    element.addClass("active");
}

function change(id){
    var element = $('#' + id);
    if (element[0].value == "Email")
    {
        element[0].value = "";
    }
    if (element[0].value == "Telefon") {
        element[0].value = "";
    }
    if (element[0].value == "Rubrik") {
        element[0].value = "";
    }
    if (element[0].value == "Pris") {
        element[0].value = "";
    }
}