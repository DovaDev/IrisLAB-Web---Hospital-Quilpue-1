/// <reference path="C:\Users\semeo\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Iquique\Presentacion\js/jQuery.js" />


$(document).ready(function () {

    let reg_email = /(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])/i;

    $("#Btn_Modal_Email").click(() => {
        $("#mdl_correo").modal();

    });

    $("#txt_email").keyup((me) => {
        console.log("asdasdads");
        if (me.which != 13) {
            if (txt_email.value.match(reg_email) == null) {
                $("#Btn_Email").attr("disabled", "disabled");
                //Btn_Email.locked = true;
            }
            else {
                $("#Btn_Email").removeAttr("disabled");
                //Btn_Email.locked = false;
            }
        }
    });

    $("#Btn_Email").click(() => {
        AJAX_Excel_Async();
    });

    $("#Div_DesAgrupar").hide();
    $("#Div_Agrupar").hide();
    $("#Div_Excel_Agrupado").hide();
    //Ajustes Visuales
    //$(".block_wait").css({ "display": "none" });
    $(".block_wait").hide();
    $("#Div_Total").empty().css({ "display": "none" });
    $("#Div_Graph").empty().css({ "display": "none" });
    $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });
    $("#Div_Tabla_Data").append(
        $("<div>").css({
            "width": "calc(100% - 60)",
            "text-align": "center",
            "padding": "30px",
            "font-size": "30px"
        }).text("Realice una Búsqueda.")
    );
    //Llamar al llenado de los DropDownList
    //Ajax_Ddl();
    //Registrar evento Click del Botón Buscar
    $("#Btn_Search").click(function () {

        Ajax_DataTable();
    });
    $("#Btn_Export").click(function () {
        Ajax_Excel();
    });
    $("#Btn_Export_DesAgrupar").click(function () {
        Ajax_Excel_Agrupado();
    });

    $("#Btn_Agrupar").click(function () {
        Ajax_DataTable_Agrupado();
        //Ajax_Excel();
    });
    $("#Btn_DesAgrupar").click(function () {
        Ajax_DataTable();
    });


});

//Generar Excel
function AJAX_Excel_Async() {

    var Data_Par = JSON.stringify({
        "MAIN_URL": location.origin,
        "DATE_str01": String($("#TxtDate_01").val()).replace(/\//g, "a"),
        "DATE_str02": String($("#TxtDate_02").val()).replace(/\//g, "a"),
        "ID_CODIGO_FONASA": 0, //$("#DdlExamen").val()
        "EMAIL": $("#txt_email").val()
    });
    console.log(Data_Par);
    modal_show();

    $.ajax({
        "type": "POST",
        "url": "REP_LAB_CANT_EXA_ARE_SECC_2_2.aspx/Gen_Excel_Async",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;

            if (json_receiver != "null") {
                var str_Download = "Se comenzará a generar su planilla excel, será enviada al correo electrónico ingresado.";
                //str_Download += "<a href='" + json_receiver + "'>AQUÍ.</a>"
                //cModal_Notif("Archivo Generado", str_Download);
                Hide_Modal();
                $("#mdlNotif .modal-header h4").text("Envío de Planilla");
                $("#mdlNotif .modal-body p").html(str_Download);
                $("#mdlNotif").modal();

            } else {
                var str_Error = "La petición de generación de planilla Excel no se ha realizado debido ";
                str_Error += "a que los parámetros de búsqueda no arrojaron resultados."
                //cModal_Error("Error", str_Error);
                Hide_Modal();
                $("#mdlNotif .modal-header h4").text("Sin Resultados");
                $("#mdlNotif .modal-body p").html(str_Error);
                $("#mdlNotif").modal();


            }
        },
        "error": function (response) {
            Hide_Modal();
            $("#mdlNotif .modal-header h4").text(String(response.responseJSON.ExceptionType).trim());
            $("#mdlNotif .modal-body p").html(response.responseJSON.Message);
            $("#mdlNotif").modal();



        }
    });
}

//Json de llenado de DropDownList
var Mx_Ddl = [
    {
        "ID_RLS_LS": 0,
        "ID_LABO": 0,
        "ID_SECCION": 0,
        "RLS_LS_DESC": "dddd",
        "ID_ESTADO": 0
    }
];
function Ajax_Ddl() {

    $.ajax({
        "type": "POST",
        "url": "REP_LAB_CANT_EXA_ARE_SECC_2_2.aspx/Llenar_Ddl",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Ddl = JSON.parse(json_receiver);
                Fill_Ddl();
                $(".block_wait").hide();

            } else {

                $("#Div_Tabla_Data").empty();
                $("#Div_Tabla_Total").empty();
                $("#Summary_Graph").empty();
                $("#Div_dinero").empty();
                $("#Div_Tabla_Data").append(
                    $("<div>").css({
                        "width": "calc(100% - 60)",
                        "text-align": "center",
                        "padding": "30px",
                        "font-size": "30px",

                        "color": "#000000"
                    }).text("Sin Resultados.")
                );

            }
        },
        "error": function (response) {


        }
    });
}
//Json de llenado de DataTable
//var Mx_Dtt = [
//    {
//        "TOTAL_ATE": 0,
//        "TOTAL_PREVE": 0,
//        "TOTAL_PARAMETROS": 0,
//        "TOTA_SIS": 0,
//        "TOTA_USU": 0,
//        "TOTA_COPA": 0,
//        "CF_DESC": "asdf",
//        "ID_CODIGO_FONASA": 0,
//        "ID_ESTADO": 0,
//        "RLS_LS_DESC": "asdf",
//        "AREA_DESC": "asdf",
//        "ID_AREA": 0,
//        "CF_COD": "asdf",
//        "SECC_ALT_DESC": "asdf",
//        "SECC_ORDEN": "asdf",
//        "PER_COD": "asdf"
//    }
//];


var Mx_Dtt = {
    "proparra1": [{
        "TOTAL_ATE": 0,
        "TOTAL_PREVE": 0,
        "TOTAL_PARAMETROS": 0,
        "TOTA_SIS": 0,
        "TOTA_USU": 0,
        "TOTA_COPA": 0,
        "CF_DESC": "asdf",
        "ID_CODIGO_FONASA": 0,
        "ID_ESTADO": 0,
        "RLS_LS_DESC": "asdf",
        "AREA_DESC": "asdf",
        "ID_AREA": 0,
        "CF_COD": "asdf",
        "SECC_ALT_DESC": "asdf",
        "SECC_ORDEN": "asdf",
        "PER_COD": "asdf"

    }],
    "proparra2": [{
        "TOTAL_ATE": 0,
        "PROC_DESC": 0,
        "ID_PROCEDENCIA": 0
    }]
}


function Ajax_DataTable() {

    modal_show();
    var Data_Par = JSON.stringify({
        "ID_CODIGO_FONASA": 0, //$("#DdlExamen").val(),
        "DATE_str01": String($("#TxtDate_01").val()),
        "DATE_str02": String($("#TxtDate_02").val()),
    });
    $(".block_wait").fadeIn(500);
    $.ajax({
        "type": "POST",
        "url": "REP_LAB_CANT_EXA_ARE_SECC_2_2.aspx/Llenar_DataTable2",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": Data_Par_modal_paciente => {

            Mx_Dtt = Data_Par_modal_paciente.d;

            $("#Div_DesAgrupar").hide();
            $("#Div_Excel_Agrupado").hide();
            $("#Div_Agrupar").show();
            $("#Div_Excel_DesAgrupado").show();
            Fill_DataTable();
            $(".block_wait").hide();


            Hide_Modal();

            $(".block_wait").fadeOut(500);
        },
        "error": function (response) {
            alert("Error en la Recepción de Datos");
            console.log(response);
            Hide_Modal();
        }
    });
}

function Ajax_DataTable_Agrupado() {

    modal_show();
    var Data_Par = JSON.stringify({
        "ID_CODIGO_FONASA": 0, //$("#DdlExamen").val(),
        "DATE_str01": String($("#TxtDate_01").val()),
        "DATE_str02": String($("#TxtDate_02").val()),
    });
    $(".block_wait").fadeIn(500);
    $.ajax({
        "type": "POST",
        "url": "REP_LAB_CANT_EXA_ARE_SECC_2_2.aspx/Llenar_DataTable2",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt = JSON.parse(json_receiver);

                $("#Div_Agrupar").hide();
                $("#Div_Excel_DesAgrupado").hide();
                $("#Div_DesAgrupar").show();
                $("#Div_Excel_Agrupado").show();
                Fill_DataTable_Agrupado();
                $(".block_wait").hide();

            } else {

                $("#Div_Tabla_Data").empty();
                $("#Div_Tabla_Data").append(
                    $("<div>").css({
                        "width": "calc(100% - 60)",
                        "text-align": "center",
                        "padding": "30px",
                        "font-size": "30px",

                        "color": "#000000"
                    }).text("Sin Resultados.")
                );
                Hide_Modal();
            }
            $(".block_wait").fadeOut(500);
        },
        "error": function (response) {
            alert("Error en la Recepción de Datos");
            console.log(response);
            Hide_Modal();
        }
    });
}
//Generar Excel
function Ajax_Excel() {
    modal_show();
    var Data_Par = JSON.stringify({
        "DOMAIN_URL": location.origin,
        "DATE_str01": String($("#TxtDate_01").val()).replace(/\//g, "a"),
        "DATE_str02": String($("#TxtDate_02").val()).replace(/\//g, "a"),
        "ID_CODIGO_FONASA": 0 //$("#DdlExamen").val()
        //"PREVE_DESC": $("#DdlExamen").val()
    });
    $(".block_wait").fadeIn(500);
    $.ajax({
        "type": "POST",
        "url": "REP_LAB_CANT_EXA_ARE_SECC_2_2.aspx/Gen_Excel_Desagrupado",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": (resp) => {
            let xURL = "";
            xURL = resp.d;

            if (xURL != null) {
                if (xURL.match(/^http(s?):\/\//gi) == null) {
                    xURL = "http://" + xURL;
                }

                var xMsg = `<p>Se ha generado correctamente el archivo excel. `;
                xMsg += `Si no se ha iniciado la descarga pulse <a href="${xURL}">aquí</a>.</p>`;
                $("#mdlExcel .modal-body").html(xMsg);

                window.open(xURL, "_blank");
            } else {
                var xMsg = `<p>No se ha generado ningún archivo debido a que la `;
                xMsg += `búsqueda no retorna resultados.</p>`;
                $("#mdlExcel .modal-body").html(xMsg);
            }

            $("#mdlExcel").modal();
            Hide_Modal();
        },
        "error": function (response) {
            Hide_Modal();
            $("#mdlNotif .modal-header h4").text(String(response.responseJSON.ExceptionType).trim());
            $("#mdlNotif .modal-body p").html(response.responseJSON.Message);
            $("#mdlNotif").modal();

        }
    });
}

//Generar Excel Agrupado
function Ajax_Excel_Agrupado() {
    modal_show();
    var Data_Par = JSON.stringify({
        "DOMAIN_URL": location.origin,
        "DATE_str01": String($("#TxtDate_01").val()).replace(/\//g, "a"),
        "DATE_str02": String($("#TxtDate_02").val()).replace(/\//g, "a"),
        "ID_CODIGO_FONASA": 0 //$("#DdlExamen").val()
        //"PREVE_DESC": $("#DdlExamen").val()
    });
    $(".block_wait").fadeIn(500);
    $.ajax({
        "type": "POST",
        "url": "REP_LAB_CANT_EXA_ARE_SECC_2_2.aspx/Gen_Excel_Agrupado",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": (resp) => {
            let xURL = "";
            xURL = resp.d;

            if (xURL != null) {
                if (xURL.match(/^http(s?):\/\//gi) == null) {
                    xURL = "http://" + xURL;
                }

                var xMsg = `<p>Se ha generado correctamente el archivo excel. `;
                xMsg += `Si no se ha iniciado la descarga pulse <a href="${xURL}">aquí</a>.</p>`;
                $("#mdlExcel .modal-body").html(xMsg);

                window.open(xURL, "_blank");
            } else {
                var xMsg = `<p>No se ha generado ningún archivo debido a que la `;
                xMsg += `búsqueda no retorna resultados.</p>`;
                $("#mdlExcel .modal-body").html(xMsg);
            }

            $("#mdlExcel").modal();
            Hide_Modal();
        },
        "error": function (response) {
            Hide_Modal();
            $("#mdlNotif .modal-header h4").text(String(response.responseJSON.ExceptionType).trim());
            $("#mdlNotif .modal-body p").html(response.responseJSON.Message);
            $("#mdlNotif").modal();

        }
    });
}
//Llenar DropDownList
function Fill_Ddl() {
    $("#DdlExamen").empty();
    $("<option>", {
        "value": 0
    }).text("Todos").appendTo("#DdlExamen");
    for (y = 0; y < Mx_Ddl.length; ++y) {
        $("<option>", {
            "value": Mx_Ddl[y].ID_RLS_LS
        }).text(Mx_Ddl[y].RLS_LS_DESC).appendTo("#DdlExamen");
    }
};
//Llenar DataTable
function Fill_DataTable() {
    $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });

    let xi = 0;
    let leTable = 0;
    let leTableFirst = 0;
    let newTable = true;
    let reeTOTAL = 0;
    let TOTAL_FINAL_HIPER = 0;

    leTableFirst = $("<table>", {
        "class": "display mb-2",
        "width": "100%",
        "cellspacing": "0"
    });
    leTableFirst.appendTo("#Div_Tabla_Data");




    //for (i = 0; i < Mx_Dtt.proparra2.length; ++i) {
    //    if (i == 0) {
    //        leTableFirst.append(
    //        $("<thead>").append(
    //        $("<tr>", {"id":"aidii"}).append(
    //        $("<th>", { align: "center" }).text("Código"),
    //        $("<th>", { align: "center" }).text("Glosa"),
    //        $("<th>", { align: "center" }).text("Total")
    //            )
    //            )
    //        );
    //    } else {
    //        $("#aidii").append(

    //            $("<th>", { align: "center"}).text(Mx_Dtt.proparra2[i].PROC_DESC)


    //        );
    //    }


    //}

    while (xi < Mx_Dtt.proparra1.length) {
        if ((xi > 0) && (Mx_Dtt.proparra1[xi].SECC_ALT_DESC != Mx_Dtt.proparra1[xi - 1].SECC_ALT_DESC)) {
            leTable.append(
                $("<tfoot>").append(
                    $("<tr>").append(
                        $("<th>", { align: "right", colspan: 2 }).text("Total:"),
                        $("<td>", { align: "right" }).text(reeTOTAL)
                    )
                )
            );
            newTable = true;
            reeTOTAL = 0;
        } else if (xi > 0) {
            newTable = false;
        }

        if (newTable == true) {
            leTable = $("<table>", {
                "class": "display mb-2",
                "width": "100%",
                "cellspacing": "0"
            });
            leTable.appendTo("#Div_Tabla_Data");

            leTable.append(
                $("<thead>").append(
                    $("<tr>").append(
                        $("<th>", { align: "left", colspan: 3 }).text(Mx_Dtt.proparra1[xi].SECC_ALT_DESC)
                    ),
                    $("<tr>").append(
                        $("<th>", { align: "left", style: "width: 128px;" }).text("Código"),
                        $("<th>", { align: "left" }).text("Exámenes"),
                        $("<th>", { align: "right", style: "width: 40px;" }).text("Total")
                    )
                ),
                $("<tbody>")
            );
        }
        //if (Mx_Dtt[xi].ID_CODIGO_FONASA != 145 && Mx_Dtt[xi].ID_CODIGO_FONASA != 668 && Mx_Dtt[xi].ID_CODIGO_FONASA != 76) {
        leTable.find("tbody").append(
            $("<tr>").append(
                $("<td>", { align: "center" }).text(Mx_Dtt.proparra1[xi].CF_COD),
                $("<td>", { align: "left" }).text(Mx_Dtt.proparra1[xi].CF_DESC),
                $("<td>", { align: "right" }).text(Mx_Dtt.proparra1[xi].TOTAL_ATE)
            )
        );
        reeTOTAL += Mx_Dtt.proparra1[xi].TOTAL_ATE;
        TOTAL_FINAL_HIPER += Mx_Dtt.proparra1[xi].TOTAL_ATE;
        //}

        xi++;
    }

    leTable.append(
                $("<tfoot>").append(
                    $("<tr>").append(
                        $("<th>", { align: "right", colspan: 2 }).text("Total:"),
                        $("<td>", { align: "right" }).text(reeTOTAL)
                    )
                )
            );

    leTable = $("<table>", {
        "class": "display mb-2",
        "width": "100%",
        "cellspacing": "0"
    });
    leTable.appendTo("#Div_Tabla_Data");

    leTable.append(
        $("<thead>").append(
            $("<tr>").append(
                $("<th>", { align: "left", style: "font-weight: 900;", colspan: 2 }).text("TOTAL FINAL: "),
                $("<th>", { align: "right", style: "width: 40px; font-weight:900;" }).text(TOTAL_FINAL_HIPER)
            )
        ),
        $("<tbody>")
    );
    Hide_Modal();
}

//Llenar DataTable
function Fill_DataTable_Agrupado() {
    $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });

    let xi = 0;
    let leTable = 0;
    let newTable = true;
    let reeTOTAL = 0;
    let TOTAL_FINAL_HIPER = 0;



    while (xi < Mx_Dtt.proparra1.length) {
        if ((xi > 0) && (Mx_Dtt.proparra1[xi].SECC_ALT_DESC != Mx_Dtt.proparra1[xi - 1].SECC_ALT_DESC)) {
            leTable.append(
                $("<tfoot>").append(
                    $("<tr>").append(
                        $("<th>", { align: "right", colspan: 2 }).text("Total:"),
                        $("<td>", { align: "right" }).text(reeTOTAL)
                    )
                )
            );
            newTable = true;
            reeTOTAL = 0;
        } else if (xi > 0) {
            newTable = false;
        }

        if (newTable == true) {
            leTable = $("<table>", {
                "class": "display mb-2",
                "width": "100%",
                "cellspacing": "0"
            });
            leTable.appendTo("#Div_Tabla_Data");

            leTable.append(
                $("<thead>").append(
                    $("<tr>").append(
                        $("<th>", { align: "center", colspan: 3 }).text(Mx_Dtt.proparra1[xi].SECC_ALT_DESC)
                    ),
                    $("<tr>").append(
                        $("<th>", { align: "left", style: "width: 128px;" }).text("Código"),
                        $("<th>", { align: "left" }).text("Exámenes"),
                        $("<th>", { align: "right", style: "width: 40px;" }).text("Total")
                    )
                ),
                $("<tbody>")
            );
        }     //Mx_Dtt[xi].ID_CODIGO_FONASA != 676 &&                                                                                                                                                                                                                                  //Hepatico                                                                                                                                                                                  Lipidico
        if (Mx_Dtt.proparra1[xi].ID_CODIGO_FONASA != 103 && Mx_Dtt.proparra1[xi].ID_CODIGO_FONASA != 140 && Mx_Dtt.proparra1[xi].ID_CODIGO_FONASA != 141 && Mx_Dtt.proparra1[xi].ID_CODIGO_FONASA != 66 && Mx_Dtt[xi].ID_CODIGO_FONASA != 558 && Mx_Dtt[xi].ID_CODIGO_FONASA != 138 && Mx_Dtt[xi].ID_CODIGO_FONASA != 463 && Mx_Dtt[xi].ID_CODIGO_FONASA != 57 && Mx_Dtt[xi].ID_CODIGO_FONASA != 94 && Mx_Dtt[xi].ID_CODIGO_FONASA != 136 && Mx_Dtt[xi].ID_CODIGO_FONASA != 137 && Mx_Dtt[xi].ID_CODIGO_FONASA != 140) {
            leTable.find("tbody").append(
            $("<tr>").append(
                $("<td>", { align: "center" }).text(Mx_Dtt.proparra1[xi].CF_COD),
                $("<td>", { align: "left" }).text(Mx_Dtt.proparra1[xi].CF_DESC),
                $("<td>", { align: "right" }).text(Mx_Dtt.proparra1[xi].TOTAL_ATE)

            )
        );
            reeTOTAL += Mx_Dtt.proparra1[xi].TOTAL_ATE;
            TOTAL_FINAL_HIPER += Mx_Dtt.proparra1[xi].TOTAL_ATE;
        }
        xi++;
    }

    leTable = $("<table>", {
        "class": "display mb-2",
        "width": "100%",
        "cellspacing": "0"
    });
    leTable.appendTo("#Div_Tabla_Data");

    leTable.append(
        $("<thead>").append(
            $("<tr>").append(
                $("<th>", { align: "left", style: "font-weight: 900;", colspan: 2 }).text("TOTAL FINAL: "),
                $("<th>", { align: "right", style: "width: 40px; font-weight: 900;" }).text(TOTAL_FINAL_HIPER)
            )
        ),
        $("<tbody>")
    );
    Hide_Modal();
}