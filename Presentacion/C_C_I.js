$(document).ready(function () {
    $("#1_1").hide();//req
    $("#2_1").hide();//req
    $("#2_2").hide();
    $("#3_1").hide();//req
    $("#3_2").hide();
    $("#1_2").hide();

    var Nom = Galletas.getGalleta("NAME");
    var Ape = Galletas.getGalleta("SURNAME");
    var nick = Galletas.getGalleta("NICKNAME");
    var id_usuario = Galletas.getGalleta("ID_USER");
    B_C(id_usuario);

    $("#usuario_id").val(nick);
    $("#nombre_usauio").val(Nom + " " + Ape);


    $("#password1").focusout(function () {
        if ($("#password1").val() == "") {
            $("#1_1").show();
            $("#password1").css({
                "border-color": "#f20000"
            });
        } else {
            $("#1_1").hide();
            $("#password1").css({
                "border-color": "#868e96"
            });
        }

    });
    $("#password2").focusout(function () {
        if ($("#password2").val() == "") {
            $("#2_1").show();
            $("#password2").css({
                "border-color": "#f20000"
            });
        } else {
            $("#2_1").hide();
            $("#password2").css({
                "border-color": "#868e96"
            });
        }
        $("#3_1").hide();
        $("#3_2").hide();
    });
    $("#password3").focusout(function () {
        if ($("#password3").val() == "") {
            $("#3_1").show();
            $("#password3").css({
                "border-color": "#f20000"
            });
        } else {
            $("#3_1").hide();
            $("#password2").css({
                "border-color": "#868e96"
            });
        }
        if ($("#password3").val() == $("#password2").val()) {
            $("#password3").css({
                "border-color": "#868e96"
            });
            $("#password2").css({
                "border-color": "#868e96"
            });
        } else {
            $("#3_1").hide();
            $("#3_2").show();
            $("#password3").css({
                "border-color": "#f20000"
            });
            $("#password2").css({
                "border-color": "#f20000"
            });
        }
    });





});

