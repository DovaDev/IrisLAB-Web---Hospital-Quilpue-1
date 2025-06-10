/// <reference path="/bootstrap_data/vendor/jquery/jquery.js"/>
$(document).ready(function () {
    var objAJAX = 0;
    $("#mdlAlert").hide();
    $(".form-control").keypress(function (key) {
        if (key.which == 13) {
            $("#Btn_Login").click();
        }
    });
    $("#Btn_Login").click(function () {
        var xUser = $("#Txt_User").val();
        var xPass = $("#Txt_Pass").val();

        user_login(xUser, xPass);

    });
    function user_login(fUser, fPass) {
        var Param = JSON.stringify({
            "xUser": fUser,
            "xPass": fPass
        });

        $("#mdlAlert").fadeOut(250);
        objAJAX = $.ajax({
            "type": "POST",
            "url": "/Account/Login.aspx/User_Login",
            "data": Param,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "timeout": 5000,
            "success": resp => {

                if (resp.d.LOGGED == true) {

                    //Registrar Cookies
                    Galletas.setGalleta("LOGGED", resp.d.LOGGED, (60 * 300));
                    Galletas.setGalleta("ID_USER", resp.d.ID_USER, (60 * 300));
                    Galletas.setGalleta("NICKNAME", resp.d.NICKNAME, (60 * 300));
                    Galletas.setGalleta("NAME", resp.d.NAME, (60 * 300));
                    Galletas.setGalleta("SURNAME", resp.d.SURNAME, (60 * 300));
                    Galletas.setGalleta("P_ADMIN", resp.d.P_ADMIN, (60 * 300));
                    Galletas.setGalleta("USU_ID_PROC", resp.d.USU_ID_PROC, (60 * 300));
                    Galletas.setGalleta("USU_TM", resp.d.USU_ID_PROC, (60 * 300));
                    Galletas.setGalleta("USU_PREV", resp.d.USU_PREV, (60 * 300));
                    Galletas.setGalleta("ID_PROF", resp.d.ID_PROF, (60 * 300));
                    //Galletas.setGalleta("USU_RUT_IMED", resp.d.USU_RUT_IMED, (60 * 300));
                    //Galletas.setGalleta("USU_PASS_IMED", resp.d.USU_PASS_IMED, (60 * 300));
                    window.location = "/Index.aspx";
                } else {
                    //Agregar Alert
                    $("#mdlAlert").removeClass("d-none");
                    $("#mdlAlert").fadeIn(250);
                    $("#mdlAlert").html("<strong>ERROR:</strong> Usuario/Contraseña incorrecto.");
                }
            },
            "error": resp => {

                //Agregar Alert
                $("#mdlAlert").removeClass("d-none");
                $("#mdlAlert").fadeIn(250);
                $("#mdlAlert").html("<strong>ERROR:</strong> Error de conexión con el Servidor.");
            }
        });
    }
});