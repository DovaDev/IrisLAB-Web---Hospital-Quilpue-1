$(document).ready(function () {
    $("#button1id").click(function () {
        var nn = 0;
        if ($("#password1").val().toUpperCase() == Mx_Dtt_4556[0].USU_PASS.trim().toUpperCase()) {
            $("#password1").css({
                "border-color": "#ccc"
            });
            $("#1_1").hide();
            $("#1_2").hide();
            nn = nn + 1;
        } else {
            $("#1_1").hide();
            $("#1_2").show();
            $("#password1").css({
                "border-color": "#f20000"
            });
        }
        if ($("#password3").val() == $("#password2").val()) {
            nn = nn + 1;
        }
    
            if ($("#password2").val() == "") {
                $("#2_1").show();
                $("#password2").css({
                    "border-color": "#f20000"
                });
            } else {
                nn = nn + 1;
            }
          
      
     
            if ($("#password3").val() == "") {
                $("#3_1").show();
                $("#password3").css({
                    "border-color": "#f20000"
                });
            } else {
                nn = nn + 1;
            }          
      
        if (nn == 4) {
            G_C();
        } else {
            console.log("no se puede");
        }
    });
});

var Mx_Dtt_4556 = [
  {
      "pss": 0,   
  }
];
function B_C(id) {
    var Data_Par = JSON.stringify({     
        "id": id
    });
    $.ajax({
        "type": "POST",
        "url": "C_C.aspx/B_C",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt_4556 = JSON.parse(json_receiver);     
            } else {
            }
        },
        "error": function (response) {         
        }
    });
}

function G_C() {
    var Data_Par = JSON.stringify({
        "NContraseña": $("#password2").val(),
        "id": Galletas.getGalleta("ID_USER")
    });
    $.ajax({
        "type": "POST",
        "url": "C_C.aspx/G_C",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                //Mx_Dtt_4556 = JSON.parse(json_receiver);
                $("#mError_AAH2").modal('hide');
                var str_Error = "Contraseña guradada correctamente";
                $("#title8").text("Cambio de contraseña");
                $("#mError_AAH2 p").text(str_Error);
                $("#mError_AAH2").modal();

                $("#password1").val("");
                $("#password2").val("");
                $("#password3").val("");

            } else {
                $("#mError_AAH2").modal('hide');
                var str_Error = "No se pudo guardar la contraseña, porfavor intentar nuevamente";
                $("#title8").text("Cambio de contraseña");
                $("#mError_AAH2 p").text(str_Error);
                $("#mError_AAH2").modal();

            }
        },
        "error": function (response) {
        }
    });
}
