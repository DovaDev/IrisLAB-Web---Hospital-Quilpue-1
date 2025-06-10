/// <reference path="/bootstrap_data/vendor/jquery/jquery.js"/>
/// <reference path="/Resourses/JS/Galletas.js"/>
$(document).ready(function () {
    var LoginStat = Galletas.getGalleta("LOGGED");
    if (LoginStat == null || LoginStat == "false") {
        xKillCookie();
        window.location = "/Account/Login.aspx";

    } else {
        Galletas.modTime("LOGGED", 30 * 60);
        Galletas.modTime("ID_USER", 30 * 60);
        Galletas.modTime("NICKNAME", 30 * 60);
        Galletas.modTime("NAME", 30 * 60);
        Galletas.modTime("SURNAME", 30 * 60);
        Galletas.modTime("USU_TM", 30 * 60);
        Galletas.modTime("P_ADMIN", 30 * 60);
    }

    function xKillCookie() {
        Galletas.killGalleta("LOGGED");
        Galletas.killGalleta("ID_USER");
        Galletas.killGalleta("NICKNAME");
        Galletas.killGalleta("NAME");
        Galletas.killGalleta("SURNAME");
        Galletas.killGalleta("USU_TM");
        Galletas.killGalleta("P_ADMIN");
    }

    $("#btn_close_session").click(event => {
        xKillCookie();

        var objAJAX = $.ajax({
            "type": "POST",
            "url": "/Account/Login.aspx/User_Logout",
            //"data": Param,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": resp => {



                if (resp.d == true) {
                    window.location = "/Account/Login.aspx";
                }
            },
            "error": resp => {



            }
        });
    });
});