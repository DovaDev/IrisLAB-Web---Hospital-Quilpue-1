
var AJAX_Datos = 0;
var AJAX_DTT = 0;
var idAte = 0;
var ateIDD = 0;

window.onload = function () {
    $("#datos_pac").hide();
};

$(document).ready(function () {



    $("#Btn_Buscar_x_ate").click(function () {

        modal_show();
        Ajax_Llenar_Datos();
        Ajax_Llenar_Datatable();


    });





});



function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
    results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

//Declaacones JSON
var Mx_Datos = [{
    "ID_ATENCION": "",
    "PAC_RUT": "",
    "PAC_NOMBRE": "",
    "PAC_APELLIDO": "",
    "SEXO_DESC": "",
    "PAC_FNAC": "",
    "ATE_NUM": "",
    "ATE_FECHA": "",
    "PROC_DESC": "",
    "PREVE_DESC": "",
    "DOC_NOMBRE": "",
    "DOC_APELLIDO": "",
    "ENCRYPTED_ID": "",
    "ATE_AVIS": ""
}];
var Mx_DataTable = [{
    "CF_COD": "",
    "CF_DESC": "",
    "ATE_DET_V_FECHA": "",
    "TP_PAGO_DESC": "",
    "CF_DIAS": "",
    "ATE_DET_IMPRIME": "",
    "ATE_DET_V_ID_ESTADO": "",
    "ESTADO_WEB_DERIVADO": "",
    "ID_DET_ATE": "",
    "ID_PER": "",
    "CF_AVIS": "",
    "ATE_NUM_AVIS": "",
    "ID_CODIGO_FONASA":""
}];


function Ajax_Llenar_Datos() {
    //Debug



    //Parámetros
    var strParam = JSON.stringify({
        "ID_ATE": $("#txtNAte").val()
    });
    AJAX_Datos = $.ajax({
        "type": "POST",
        "url": "Exa_Esp_V.aspx/Llenar_Datos",
        "data": strParam,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": data => {
            //Debug


            if (data.d != null) {
                Mx_Datos = JSON.parse(data.d);
                ////console.log(Mx_Datos);
                for (i = 0; i < Mx_Datos.length; ++i) {
                    var date_y = Mx_Datos[i].PAC_FNAC;
                    var date_x = Mx_Datos[i].ATE_FECHA;
                    date_x = String(date_x).replace("/Date(", "");
                    date_x = date_x.replace(")/", "");
                    date_y = String(date_y).replace("/Date(", "");
                    date_y = date_y.replace(")/", "");
                    var Date_Change = new Date(parseInt(date_x));
                    var Date_Change2 = new Date(parseInt(date_y));
                    Mx_Datos[i].ATE_FECHA = Date_Change;
                    Mx_Datos[i].PAC_FNAC = Date_Change2;
                }
                Fill_Data();
                $("#datos_pac").show();
            } else {
                Hide_Modal();

                $("#datos_pac").hide();

            }
        },
        "error": data => {
            //Debug
        }
    });
}
function Ajax_Llenar_Datatable() {
    //Debug
    //Parámetros
    var strParam = JSON.stringify({
        "ID_ATE": $("#txtNAte").val()
    });
    AJAX_DTT = $.ajax({
        "type": "POST",
        "url": "Exa_Esp_V.aspx/Llenar_DataTable",
        "data": strParam,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": data => {
            //Debug
           if (data.d != null) {
                Mx_DataTable = JSON.parse(data.d);
                ////console.log(Mx_DataTable);
                for (i = 0; i < Mx_DataTable.length; ++i) {
                    var date_x = Mx_DataTable[i].ATE_DET_V_FECHA;
                    date_x = String(date_x).replace("/Date(", "");
                    date_x = date_x.replace(")/", "");
                    var Date_Change = new Date(parseInt(date_x));
                    Mx_DataTable[i].ATE_DET_V_FECHA = Date_Change;
                }
                Fill_Dtt();

            } else {
                $("#btnprintall").remove();
                $("#hrhide").remove();
                $("#rowhide").remove();
                //$("#btnverresu").remove();
                Hide_Modal();
            }
        },
        "error": data => {
            Hide_Modal();
            //Debug
        }
    });
}
function Ajax_Exa_Print(id_atencion, numero_avis, num_ate, Codigo_Fonasa_avis,ID_CODIGO_FONASA) {
    //Actualizar Examenes
    //Parámetros
    var datos_recividos = 0;
    var strParam = JSON.stringify({
        "ID_ATE": id_atencion,
        "numero_avis": numero_avis,
        "num_ate": num_ate,
        "Codigo_Fonasa_avis": Codigo_Fonasa_avis,
        "ID_CODIGO_FONASA": ID_CODIGO_FONASA
    });
    AJAX_DTT = $.ajax({
        "type": "POST",
        "url": "Exa_Esp_V.aspx/Actualiar_Examenes",
        "data": strParam,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": data => {
            //Debug
            if (data.d != null) {
                modal_show();
                Ajax_Llenar_Datatable();
            } else {
                modal_show();
                Ajax_Llenar_Datatable();
            }
        },
        "error": data => {
            Hide_Modal();
            //Debug
        }
    });


}
function Fill_Data() {

    ateIDD = Mx_Datos[0].ID_ATENCION;
    //console.log(ateIDD);
    var FNac = Mx_Datos[0].PAC_FNAC;
    var FIngr = Mx_Datos[0].ATE_FECHA;
    FNac = moment(FNac).format("DD-MM-YYYY");
    FIngr = moment(FIngr).format("DD-MM-YYYY HH:mm:SS");



    $("#Rut").text(Mx_Datos[0].PAC_RUT);
    $("#Nombre").text(Mx_Datos[0].PAC_NOMBRE + " " + Mx_Datos[0].PAC_APELLIDO);
    $("#Sexo").text(Mx_Datos[0].SEXO_DESC);
    $("#FechaNac").text(FNac);
    $("#NumOrden").text(Mx_Datos[0].ATE_AVIS);
    $("#FechaIng").text(FIngr);
    $("#LugarTM").text(Mx_Datos[0].PROC_DESC);
    $("#Prevision").text(Mx_Datos[0].PREVE_DESC);
    $("#ProfSol").text(Mx_Datos[0].DOC_NOMBRE + " " + Mx_Datos[0].DOC_APELLIDO);

}
function Fill_Dtt() {

    var tab = "";
    var id_det_ate = "";
    var inExa = 0;
    var inDer = 0;
    var inEsp = 0;
    var cont_no_esp = 0;

    $("#Div_Tabla").empty();
    $("<table>", {
        "id": "DataTable",
        "class": "table table-hover table-striped table-iris table-iris",
        "width": "100%",
        "cellspacing": "0"
    }).appendTo("#Div_Tabla");

    $("#DataTable").append(
        $("<thead>"),
        $("<tbody>")
    );
    $("#DataTable").attr("class", "table table-hover table-striped table-iris table-striped table-iris");

    $("#DataTable thead").append(
        $("<tr>").append(

            $("<th>", { "style": "text-align: center" }).text("Nº"),
            $("<th>", { "style": "text-align: center" }).text("Código"),
            $("<th>", { "style": "text-align: center" }).text("Descripción del Exámen"),
            $("<th>", { "style": "text-align: center" }).text("Fecha de Creación"),
            $("<th>", { "style": "text-align: center" }).text("Forma de Pago"),
            $("<th>", { "style": "text-align: center" }).text("Días Hábiles de Proceso"),
            $("<th>", { "style": "text-align: center" }).text("Estado"),
            $("<th>", { "style": "text-align: center" }).text("-")


        )
    );
    Mx_DataTable.forEach(examen=> {


        if (examen.ATE_DET_V_ID_ESTADO == 6 || examen.ATE_DET_V_ID_ESTADO == 14) {
            tab = "Exa";
            inExa += 1;
        }
        else if (examen.ATE_DET_V_ID_ESTADO == 4) {
            tab = "Pen";
            inEsp += 1;
        }
        else if (examen.ATE_DET_V_ID_ESTADO == 7) {
            tab = "Esp";
            inEsp += 1;
        }
        else {
 
            tab = "Der";
            inDer += 1;
        }

        id_det_ate = examen.ID_DET_ATE;
        var date_ate_det = examen.ATE_DET_V_FECHA;
        date_ate_det = moment(date_ate_det).format("DD-MM-YYYY HH:mm:SS");
        var ffinal = date_ate_det;

        $("#DataTable tbody").append(
        $("<tr>").append(
            $("<td>").css({ "text-align": "center", "font-weight": "bold" }).text(function () {
                if (tab == "Exa") { return inExa; }
                else if (tab == "Der") { return inDer; }
                else { return inEsp; }
            }),
            $("<td>").css("text-align", "center").text(examen.CF_COD),
            $("<td>").text(examen.CF_DESC),
            $("<td>").css("text-align", "center").text(ffinal),
            $("<td>").css("text-align", "center").text(examen.TP_PAGO_DESC),
            $("<td>").css("text-align", "center").text(examen.CF_DIAS),
            $("<td>").css("text-align", "center").text(function () {
                if (tab == "Esp") {
                    $(this).css("cssText", "background-color:#ffdaaa !important; color:inherit; cursor:pointer; text-align:center;").text("Espera");

                }
                else if (tab == "Der") {
                    $(this).css("cssText", "background-color:#a9d1fc !important; color:inherit;  text-align:center;").addClass("espera").text("Derivado");

                }
                else if (tab == "Pen") {
                    $(this).css("cssText", "background-color:#98f442 !important; color:inherit;  text-align:center;").addClass("espera").text("Pendiente");

                }
                else {
                    $(this).css("cssText", "background-color:#9bffb1 !important; color:inherit;  text-align:center;").addClass("espera").text("Realizado");

                }
            }),
            $("<td>").css("text-align", "center").text(function () {
                if (tab != "Pen") {
                    //$(this).css("cssText", "background-color:#28a745 !important; color:white; cursor:pointer; text-align:center;").text("Imprimir");
                    //$(this).attr({ "onclick": `Ajax_Exa_Print("` + id_det_ate + `")` });
                    $(this).append("<button type='button' class='btn btn-warning btn-sm' onclick='Ajax_Exa_Print(" + examen.ID_ATENCION + "," + examen.ATE_NUM_AVIS + "," + $("#txtNAte").val() + "," + examen.CF_AVIS + "," + examen.ID_CODIGO_FONASA + ")'> Cambiar Estado</button>");

                }
                else {
                    $(this).append("<button type='button' class='btn btn-danger btn-sm' disabled='disabled'> Cambiar Estado</button>");
                }
            })
    )
    )
    });


    Hide_Modal();
}

