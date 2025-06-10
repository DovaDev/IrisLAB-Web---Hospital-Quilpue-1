/// <reference path="C:\Users\cvelo\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Holanda Rebuild\Presentacion\vendor/popper/popper.js" />
/// <reference path="C:\Users\cvelo\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Holanda Rebuild\Presentacion\vendor/jquery/jquery.js" />
/// <reference path="C:\Users\cvelo\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Holanda Rebuild\Presentacion\js/bootstrap-datetimepicker.js" />
/// <reference path="C:\Users\cvelo\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Holanda Rebuild\Presentacion\js/moment.js" />
/// <reference path="C:\Users\cvelo\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Holanda Rebuild\Presentacion\vendor/bootstrap/js/bootstrap.js" />

let ARR_GRABA_PREVE = [];
let ARR_GRABA_PROCE = [];
let ARR_GRABA_USUARIO = [];
let XXPERM = 0;
$(document).ready(function () {
    var dateNow = moment().format("DD-MM-YYYY hh:mm");
    $("#Txt_Date01 input").val(dateNow);
    $('#Txt_Date01').datetimepicker({
        debug: true,
        icons: {
            previous: 'fa fa-arrow-left',
            next: 'fa fa-arrow-right'
        },
        format: 'dd-mm-yyyy hh:ii',
        language: 'es',
        weekStart: 1,
        autoclose: true,
        minDate: Date.now(),
        enabledHours: true,
        startDate: dateNow
    });
    $("#Txt_Date02 input").val(dateNow);
    $('#Txt_Date02').datetimepicker({
        debug: true,
        icons: {
            previous: 'fa fa-arrow-left',
            next: 'fa fa-arrow-right'
        },
        format: 'dd-mm-yyyy hh:ii',
        language: 'es',
        weekStart: 1,
        autoclose: true,
        minDate: Date.now(),
        enabledHours: true,
        startDate: dateNow
    });

    //LLAMAR FUNCIONES
    Llenar_Ddl_Preve();
    Llenar_Ddl_Proce();
    Llenar_Ddl_Users();

    $("#btn_guardar_RNUM").click(aah=> {
        if (ARR_GRABA_USUARIO.length > 0) {
            console.log("click");
            Grabar_Notificaciones();
        }
    });
    $("#btn_preve_RNUM").click(aah=> {
        ARR_GRABA_USUARIO = [];
        if (ARR_GRABA_PREVE.length > 0) {
            console.log("click preve");
            ARR_GRABA_PREVE.forEach(aah=> {
                Mx_Users.forEach(eeh=> {
                    if (eeh.USU_ID_PREV == aah) {
                        ARR_GRABA_USUARIO.push(eeh.ID_USUARIO);
                    }
                });
            });
            Grabar_Notificaciones();
        }
    });

    $("#btn_proce_RNUM").click(aah=> {
        ARR_GRABA_USUARIO = [];
        if (ARR_GRABA_PROCE.length > 0) {
            console.log("click proce");
            ARR_GRABA_PROCE.forEach(aah=> {
                Mx_Users.forEach(eeh=> {
                    if (eeh.USU_ID_PROC == aah) {
                        ARR_GRABA_USUARIO.push(eeh.ID_USUARIO);
                    }
                });
            });
            Grabar_Notificaciones();
        }
    });

});
var Mx_Ddl_Preve = [{
    "ID_PREVE": "",
    "PREVE_COD": "",
    "PREVE_DESC": "",
    "ID_ESTADO": ""
}];
var Mx_Ddl_Proce = [{
    "ID_PROCEDENCIA": "",
    "PROC_COD": "",
    "PROC_DESC": "",
    "ID_ESTADO": ""
}];
var Mx_Users = [{
    "ID_USUARIO": "",
    "USU_NOMBRE": "",
    "USU_APELLIDO": "",
    "ID_ESTADO": "",
    "USU_NIC": "",
    "ADMIN_DESC": "",
    "USU_ID_PREV": "",
    "USU_ID_PROC": "",
    "PROC_DESC": "",
    "PREVE_DESC": "",
    "ADMIN_DESC":""
}];

function Grabar_Notificaciones() {

    var Data_Par = JSON.stringify({
        "TIPO_MENSAJE": $("#slt_Tipo").val(),
        "MENSAJE": $("#txt_Msg").val(),
        "FECHA_D": $("#fecha").val(),
        "FECHA_H": $("#fecha2").val(),
        "PERMANENTE": XXPERM,
        ARR_USER: ARR_GRABA_USUARIO
    });

    //Debug
    $.ajax({
        "type": "POST",
        "url": "Notificaciones.aspx/Graba_Notificaciones",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": data => {
            //Debug
            if (data.d > 0 && data.d != null) {
                $("#mdlNotif_usu_Master h5").text("Registro Correcto");
                $("#mdlNotif_usu_Master p").text("La notificación se registro correctamente.");
                $("#mdlNotif_usu_Master").modal();
            } else {
                $("#mdlNotif_usu_Master h5").text("Problemas en el registro");
                $("#mdlNotif_usu_Master p").text("La notificación se pudo registrar en el sistema.");
                $("#mdlNotif_usu_Master").modal();
            }
        },
        "error": data => {
            //Debug
            $("#mdlNotif_usu_Master h5").text("Problemas en el registro");
            $("#mdlNotif_usu_Master p").text("Error al registrar la notificación.");
            $("#mdlNotif_usu_Master").modal();
        }
    });
}

function Llenar_Ddl_Users() {
    //Debug
    $.ajax({
        "type": "POST",
        "url": "Notificaciones.aspx/Call_Users",
        //"data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": data => {
            //Debug
            Mx_Users = data.d;
            Fill_Ddl_Usu();
        },
        "error": data => {
            //Debug
        }
    });
}
function Llenar_Ddl_Preve() {
    //Debug
    $.ajax({
        "type": "POST",
        "url": "Notificaciones.aspx/Llenar_Ddl_Preve",
        //"data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": data => {
            //Debug
            Mx_Ddl_Preve = data.d;
            Fill_Ddl_Preve();
        },
        "error": data => {
            //Debug
        }
    });
}
function Llenar_Ddl_Proce() {
    AJAX_Ddl = $.ajax({
        "type": "POST",
        "url": "Notificaciones.aspx/Llenar_Ddl_LugarTM",
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": data => {
            Mx_Ddl_Proce = data.d;
            Fill_Ddl_Proce();
        },
        "error": data => {
        }
    });
}
function Fill_Ddl_Preve() {
    $("#Dtt_Preve tbody").empty();
    var i = 1
    Mx_Ddl_Preve.forEach(aah => {
        let indexx = i - 1;
        $("<tr>").attr("data-index", i - 1).append(
            $("<td>").css({ "text-align": "left", "font-weight": "bold" }).text(i),
            $("<td>").css("text-align", "left").text(aah.PREVE_DESC),
            $("<td>").css("text-align", "center").html("<input type='checkbox' name='preve' data-index='" + indexx + "'/>")
        ).appendTo("#Dtt_Preve tbody");
        i += 1;
    });

    $("input[name=preve]").click((aah) => {
        let Preve_Index;
        Preve_Index = $(aah.currentTarget).attr("data-index");
        let chk_preve = $(aah.currentTarget).prop("checked");
        console.log(chk_preve);
        if (chk_preve == true) {
            ARR_GRABA_PREVE.push((Mx_Ddl_Preve[Preve_Index].ID_PREVE).toString());
            console.log(ARR_GRABA_PREVE);
        }
        else {
            let poss = ARR_GRABA_PREVE.indexOf(Mx_Ddl_Preve[Preve_Index].ID_PREVE);
            ARR_GRABA_PREVE.splice(poss, 1);
            console.log(poss);
        }
    });
}
function Fill_Ddl_Proce() {
    $("#Dtt_Proce tbody").empty();
    var i = 1
    Mx_Ddl_Proce.forEach(aah => {
        let indexx = i - 1;
        $("<tr>").append(
            $("<td>").css({ "text-align": "left", "font-weight": "bold" }).text(i),
            $("<td>").css("text-align", "left").text(aah.PROC_DESC),
            $("<td>").css("text-align", "center").html("<input type='checkbox' name='proce' data-index='" + indexx + "'/>")
        ).appendTo("#Dtt_Proce tbody");
        i += 1;
    });

    $("input[name=proce]").click((aah) => {
        let Proce_Index;
        Proce_Index = $(aah.currentTarget).attr("data-index");
        let chk_proce = $(aah.currentTarget).prop("checked");
        console.log(chk_proce);
        if (chk_proce == true) {
            ARR_GRABA_PROCE.push(Mx_Ddl_Proce[Proce_Index].ID_PROCEDENCIA);
            console.log(ARR_GRABA_PROCE);
        }
        else {
            let poss = ARR_GRABA_PROCE.indexOf(Mx_Ddl_Proce[Proce_Index].ID_PROCEDENCIA);
            ARR_GRABA_PROCE.splice(poss, 1);
            console.log(ARR_GRABA_PROCE);
        }
    });
}
function Fill_Ddl_Usu() {
    $("#Dtt_Usu tbody").empty();
    var i = 1
    Mx_Users.forEach(aah => {
        let indexx = i - 1;
        $("<tr>").attr("data-index", i - 1).append(
            $("<td>").css({ "text-align": "left", "font-weight": "bold" }).text(i),
            $("<td>").css("text-align", "left").text(aah.USU_NIC),
            $("<td>").css("text-align", "left").text(aah.USU_NOMBRE + " " + aah.USU_APELLIDO),
            $("<td>").css("text-align", "left").text(eeh => {
                if (aah.USU_ID_PROC == 0) {
                    return "TODOS";
                }
                else {
                    return aah.PROC_DESC;
                }
            }),
            $("<td>").css("text-align", "left").text(eah => {
                if (aah.USU_ID_PREV == 0) {
                    return "TODOS";
                }
                else {
                    return aah.PREVE_DESC;
                }
            }),
            $("<td>").css("text-align", "left").text(aah.ADMIN_DESC),
            $("<td>").css("text-align", "center").html("<input type='checkbox' name='usuario' data-index='" + indexx + "'/>")
        ).appendTo("#Dtt_Usu tbody");
        i += 1;
    });
    Usu_Dtt();

    $("input[name=usuario]").click((aah) => {
        let Usu_Index;
        Usu_Index = $(aah.currentTarget).attr("data-index");
        let chk_Usu = $(aah.currentTarget).prop("checked");
        console.log(chk_Usu);
        if (chk_Usu == true) {
            ARR_GRABA_USUARIO.push(Mx_Users[Usu_Index].ID_USUARIO);
            console.log(ARR_GRABA_USUARIO);
        }
        else {
            let poss = ARR_GRABA_USUARIO.indexOf(Mx_Users[Usu_Index].ID_USUARIO);
            ARR_GRABA_USUARIO.splice(poss, 1);
            console.log(ARR_GRABA_USUARIO);
        }
    });
    $("#chk_perma").click(aah=> {
        let estado_chk_p = $("#chk_perma").prop("checked");
        if (estado_chk_p == true) {
            XXPERM = 1;
        }
        else {
            XXPERM = 0;
        }
    });

    $("#chk_todos").click(aah=> {
        let estado_chk = $("#chk_todos").prop("checked");
        if (estado_chk == true) {
            $("input[name=usuario]").prop("checked", true);
            Mx_Users.forEach(aah => {
                ARR_GRABA_USUARIO.push(aah.ID_USUARIO);
            });
            console.log(ARR_GRABA_USUARIO);
        }
        else {
            $("input[name=usuario]").prop("checked", false);
            ARR_GRABA_USUARIO = [];
            console.log(ARR_GRABA_USUARIO);
        }
    });
}
function Usu_Dtt() {
    $("#Dtt_Usu, #Dtt_Preve, #Dtt_Proce").DataTable({
        //"bSort": false,
        "iDisplayLength": 100,
        "info": false,
        "bPaginate": false,
        "bFilter": true,
        "language": {
            "lengthMenu": "Mostrar: _MENU_",
            "zeroRecords": "No hay coincidencias",
            "info": "Mostrando Pagina _PAGE_ de _PAGES_",
            "infoEmpty": "No hay concidencias",
            "infoFiltered": "(Se busco en _MAX_ registros )",
            "search": "<strong><i class='fa fa-search'></i>Buscar: </strong>",
            "paginate": {
                "previous": "Anterior",
                "next": "Siguiente"
            }
        }
    });

    $("#Dtt_Proce_wrapper .row div:first, #Dtt_Preve_wrapper .row div:first").remove();
}