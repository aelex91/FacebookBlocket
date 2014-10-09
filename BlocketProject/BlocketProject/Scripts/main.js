
(function () {

})();



function textfieldpressed(onClass) {

    var element = $('#' + id);
    if (id == 'textfield') {
        element.addClass("active");

        element[0].value = "";
    }

}
function ensureNumeric(e) {

    var evt = window.event || e;
    var code = evt.keyCode || evt.charCode;

    return code <= 30 || (/^[0-9]+$/.test(String.fromCharCode(code)));
}


$(document).ready(function () {
    $("#municipality").hide();
    $("#counties").change(function () {
        var dID = $(this).val();
        $.getJSON("ChangeIdOnDropDownList", { dropdownId: dID },
               function (data) {
                   $("#municipality").show();
                   var select = $("#municipality");
                   select.empty();
                   select.append($('<option/>', {
                       value: 0,
                       text: "Välj kommun"
                   }));
                   $.each(data, function (index, itemData) {
                       select.append($('<option/>', {
                           value: itemData.Value,
                           text: itemData.Text
                       }));
                   });
               });
    });
    $("#txtboxToFilter").keydown(function (e) {
        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            // Allow: Ctrl+A
            (e.keyCode == 65 && e.ctrlKey === true) ||
            // Allow: home, end, left, right
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });
});

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

$(function () {
    $('.datepicker').datepicker({
        minDate: 0,
        maxDate: 90,
        inline: true,
        changeYear: true,
        changeMonth: true,
        showOtherMonths: true,
        dayNamesMin: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
    });
});

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}
(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&appId=745986415461593&version=v2.0";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));


$(function () {
    $('.friendsLink').on('click', function () {
        if ($(this).hasClass('selected')) {
            deselect($(this));
        } else {
            $(this).addClass('selected');
            $('.pop').slideFadeToggle();
            $(".pop").position({
                my: "center",
                at: "center",
                of: window
            })
        }
        return false;
    });
    $('.closeDialog').on('click', function () {
        deselect($('.commonFriends'));
        return false;
    });

});


$(function () {
    $('.InvitePopup').on('click', function () {
        if ($(this).hasClass('selected')) {
            deselect($(this));
        } else {
            $(this).addClass('selected');
            $('.pop').slideFadeToggle();
            $(".pop").position({
                my: "center",
                at: "center",
                of: window
            })
        }
        return false;
    });

    $('.closeDialog').on('click', function () {
        deselect($('.InvitePopup'));
        return false;
    });
});



$(function () {
    $('.commonFriends').on('click', function () {
        if ($(this).hasClass('selected')) {
            deselect($(this));
        } else {
            $(this).addClass('selected');
            $('.pop').slideFadeToggle();
            $(".pop").position({
                my: "center",
                at: "center",
                of: window
            })
        }
        return false;
    });

    $('.closeDialog').on('click', function () {
        deselect($('.commonFriends'));
        return false;
    });
});

$.fn.slideFadeToggle = function (easing, callback) {
    return this.animate({ opacity: 'toggle', height: 'toggle' }, 'fast', easing, callback);

};

function deselect(e) {
    $('.pop').slideFadeToggle(function () {
        e.removeClass('selected');
    });
}


//Klicka en gång sätt variable värde till true
// om den är true, så skapa en metod som stänger den.
$(document).ready(function () {
    $("#UserTable").hide();

});


$('#showProfile').click(function () {
    if ($("#UserTable").is(":hidden")) {

        $('#showProfile').animate({ marginLeft: '-10px' });
        $("#UserTable").show(500);

    }
    else if ($("#UserTable").is(":visible")) {
        $('#showProfile').animate({ marginLeft: '-33px' });
        $("#UserTable").hide();
    }


});


function readURL(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imagefile').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$("#file").change(function () {
    readURL(this);
});


$(document).ready(function () {
    $(".searchField").hide();

    $(".searchTrigger").click(function () {

        // Set the effect type
        var effect = 'slide';

        // Set the options for the effect type chosen
        var options = { direction: 'left' };

        // Set the duration (default: 400 milliseconds)
        var duration = 400;

        $('.searchField').toggle(effect, options, duration);
    });
});
