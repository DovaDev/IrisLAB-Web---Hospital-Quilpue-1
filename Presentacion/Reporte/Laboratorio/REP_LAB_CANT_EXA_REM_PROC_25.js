/// <reference path="C:\Users\semeo\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Iquique\Presentacion\js/jQuery.js" />

$(document).ready(function () {


    $("#Btn_Export").attr("disabled", true)
    $("#Btn_Modal_Email").attr("disabled", true)

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


    //Ocultar div
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

    //Registrar evento Click del Botón Buscar
    $("#Btn_Search").click(function () {
        Ajax_DataTable();
    });
    $("#Btn_Export").click(function () {
        Ajax_Excel();
    });
    $("#Btn_Export_DesAgrupar").click(function () {
        //Ajax_Excel_Agrupado();
    });

    $("#Btn_Agrupar").click(function () {
        //Ajax_DataTable_Agrupado();
        //Ajax_Excel();
    });
    $("#Btn_DesAgrupar").click(function () {
        //Ajax_DataTable();
    });


});


//#region  AJAX
function AJAX_Excel_Async() {
    Mx_Dtt = Mx_Dtt.filter((item) => item.ID_CODIGO_FONASA != 0 && item.EXISTE_CF == true)

    //Mx_Dtt = Mx_Dtt.filter((item, index, self) =>
    //    index === self.findIndex((t) => (
    //        t.CF_COD_IRIS === item.CF_COD_IRIS && t.ID_SECCION === item.ID_SECCION
    //    ))
    //);

    Mx_Dtt = Mx_Dtt.reduce((acc, item) => {
        const key = `${item.CF_DESC_HOSP}-${item.ID_SECCION}`;

        if (!acc[key]) {
            acc[key] = { ...item };
        } else {
            acc[key].CANTIDAD += item.CANTIDAD;
            acc[key].ATENCION_ABIERTA += item.ATENCION_ABIERTA;
            acc[key].ATENCION_CERRADA += item.ATENCION_CERRADA;
            acc[key].EMERGENCIA += item.EMERGENCIA;
        }

        return acc;
    }, {});

    const result = Object.values(Mx_Dtt);

    console.log(result)
    var Data_Par = JSON.stringify({
        "DOMAIN_URL": location.origin,
        "DESDE": String($("#TxtDate_01").val()).replace(/\//g, "a"),
        "HASTA": String($("#TxtDate_02").val()).replace(/\//g, "a"),
        "ID_CODIGO_FONASA": 0, //$("#DdlExamen").val()
        "EMAIL": $("#txt_email").val(),
    });
    console.log(Data_Par);
    modal_show();

    $.ajax({
        "type": "POST",
        "url": "REP_LAB_CANT_EXA_REM_PROC_25.aspx/Gen_Excel_Async",
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

var Mx_Dtt = [{
    "CF_COD_IRIS": "",
    "ID_CODIGO_FONASA": 0,
    "CF_DESC_HOSP": "",
    "ID_PER": 0,
    "PER_DESC": "",
    "CANTIDAD": 0,
    "EXISTE_CF": false,
    "ID_RLS_LS": 0,
    "RLS_LS_DESC": "",
    "SECC_DESC": "",
    "ID_SECCION": 0
}]
function Ajax_Excel() {
    modal_show();

    Mx_Dtt = Mx_Dtt.filter((item) => item.ID_CODIGO_FONASA != 0)

    //Mx_Dtt = Mx_Dtt.filter((item, index, self) =>
    //    index === self.findIndex((t) => (
    //        t.CF_COD_IRIS === item.CF_COD_IRIS && t.ID_SECCION === item.ID_SECCION
    //    ))
    //);

    Mx_Dtt = Mx_Dtt.reduce((acc, item) => {
        const key = `${item.CF_DESC_HOSP}-${item.ID_SECCION}`;

        if (!acc[key]) {
            acc[key] = { ...item };
        } else {
            acc[key].CANTIDAD += item.CANTIDAD;
            acc[key].ATENCION_ABIERTA += item.ATENCION_ABIERTA;
            acc[key].ATENCION_CERRADA += item.ATENCION_CERRADA;
            acc[key].EMERGENCIA += item.EMERGENCIA;
        }

        return acc;
    }, {});

    const result = Object.values(Mx_Dtt);

    console.log(result)
    Mx_Dtt = result;
    var Data_Par = JSON.stringify({
        "DOMAIN_URL": location.origin,
        "DESDE": String($("#TxtDate_01").val()).replace(/\//g, "a"),
        "HASTA": String($("#TxtDate_02").val()).replace(/\//g, "a"),
        "List_Data": result
    });

    $(".block_wait").fadeIn(500);

    $.ajax({
        "type": "POST",
        "url": "REP_LAB_CANT_EXA_REM_PROC_25.aspx/Gen_Excel_Desagrupado",
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

function Ajax_DataTable() {
    modal_show();
    var Data_Par = JSON.stringify({
        "DESDE": String($("#TxtDate_01").val()),
        "HASTA": String($("#TxtDate_02").val()),
    });
    $(".block_wait").fadeIn(500);
    $.ajax({
        "type": "POST",
        "url": "REP_LAB_CANT_EXA_REM_PROC_25.aspx/Llenar_DataTable_REM",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": resp => {

            Mx_Dtt = resp.d;

            //Mx_Dtt = Mx_Dtt.filter((item) => item.ID_CODIGO_FONASA != 0 && item.EXISTE_CF == true);


            $("#Btn_Export").attr("disabled", false)
            $("#Btn_Modal_Email").attr("disabled", false)
            //Mx_Dtt = Mx_Dtt.filter((item, index, self) =>
            //    index === self.findIndex((t) => (
            //        t.CF_COD_IRIS === item.CF_COD_IRIS && t.ID_SECCION === item.ID_SECCION
            //    ))
            //);

            //Mx_Dtt = Mx_Dtt.reduce((acc, item) => {
            //    const key = `${item.CF_DESC_HOSP}-${item.ID_SECCION}`;

            //    if (!acc[key]) {
            //        acc[key] = { ...item };
            //    } else {
            //        acc[key].CANTIDAD += item.CANTIDAD;
            //        acc[key].ATENCION_ABIERTA += item.ATENCION_ABIERTA;
            //        acc[key].ATENCION_CERRADA += item.ATENCION_CERRADA;
            //        acc[key].EMERGENCIA += item.EMERGENCIA;
            //    }

            //    return acc;
            //}, {});

            const result = Object.values(Mx_Dtt);
            Mx_Dtt = result;
            console.log(result);

            $("#Div_DesAgrupar").hide();
            $("#Div_Excel_Agrupado").hide();
            $("#Div_Agrupar").show();
            $("#Div_Excel_DesAgrupado").show();
            Fill_DataTable();

            Call_Frotis(Data_Par)

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

var Mx_Dtt_Frotis = []

function Call_Frotis(Data_Par) {
    $.ajax({
        type: "POST",
        url: "REP_LAB_CANT_EXA_REM_PROC_25.aspx/Call_Frotis",
        data: Data_Par,
        contentType: "application/json;  charset=utf-8",
        dataType: "json",
        success: (resp) => {
            var json_receiver = resp.d
            if (json_receiver != null) {
                Mx_Dtt_Frotis = json_receiver;
                Fill_DataTable_Frotis();
            }
        },
        error: (xhr, status, error) => {
            console.error(`Error en la llamada ${xhr.status} - ${xhr.responseText || error}`);
        }
    });
}

function Fill_DataTable_Frotis() {
    $("#Div_Tabla_Frotis").empty().css({ "background": "#ffffff" });
    $("<table>", {
        "id": "Tabla_Frotis",
        "class": "display",
        "width": "100%",
        "cellspacing": "0"
    }).appendTo("#Div_Tabla_Frotis");

    $("#Tabla_Frotis").append(
        $("<thead>"),
        $("<tbody>")
    );
    $("#Tabla_Frotis").attr("class", "table table-hover table-striped table-iris");
    $("#Tabla_Frotis thead").attr("class", "cabzera");
    $("#Tabla_Frotis thead").append(
        $("<tr>").append(
            $("<th>", { "class": "textoReducido" }).text("#"),
            $("<th>", { "class": "textoReducido" }).text("Cantidad Exámenes"),
            $("<th>", { "class": "textoReducido" }).text("CAE"),
            $("<th>", { "class": "textoReducido" }).text("USM HDIURNO"),
            $("<th>", { "class": "textoReducido" }).text("PERSONAL"),
            $("<th>", { "class": "textoReducido" }).text("MQ1"),
            $("<th>", { "class": "textoReducido" }).text("MQ2"),
            $("<th>", { "class": "text-center text-white" }).text("MQ3"),
            $("<th>", { "class": "text-center text-white" }).text("UAPQ PABELLON"),
            $("<th>", { "class": "text-center text-white" }).text("PEDIATRIA"),
            $("<th>", { "class": "text-center text-white" }).text("NEONATOLOGIA"),
            $("<th>", { "class": "text-center text-white" }).text("UPC"),
            $("<th>", { "class": "text-center text-white" }).text("UCI A"),
            $("<th>", { "class": "text-center text-white" }).text("UTI"),
            $("<th>", { "class": "text-center text-white" }).text("MATERNIDAD"),
            $("<th>", { "class": "text-center text-white" }).text("CMA"),
            $("<th>", { "class": "text-center text-white" }).text("HOSP DOCIMI"),
            $("<th>", { "class": "text-center text-white" }).text("UEA HOSP"),
            $("<th>", { "class": "text-center text-white" }).text("UEA"),
            $("<th>", { "class": "text-center text-white" }).text("UEI"),
            $("<th>", { "class": "text-center text-white" }).text("SAUD"),
            $("<th>", { "class": "text-center text-white" }).text("UEGO"),
            $("<th>", { "class": "text-center text-white" }).text("ANATOMIA PATO"),
            $("<th>", { "class": "text-center text-white" }).text("IMAGENOLOGIA"),
            $("<th>", { "class": "text-center text-white" }).text("CESFAM IVAN MAN"),
            $("<th>", { "class": "text-center text-white" }).text("CESFAM AV AC"),
            $("<th>", { "class": "text-center text-white" }).text("CESFAM QUILPUE"),
            $("<th>", { "class": "text-center text-white" }).text("CESFAM BELLOTO"),
            $("<th>", { "class": "text-center text-white" }).text("CONS POMPEYA"),
            $("<th>", { "class": "text-center text-white" }).text("CECOSF RETIRO"),
            $("<th>", { "class": "text-center text-white" }).text("CONS BELLOTO"),
            $("<th>", { "class": "text-center text-white" }).text("CESFAM VILLA AL"),
            $("<th>", { "class": "text-center text-white" }).text("CESFAM AMERICAS"),
            $("<th>", { "class": "text-center text-white" }).text("CONS EDUARDO FREI"),
            $("<th>", { "class": "text-center text-white" }).text("CESFAM JUAN BT"),
            $("<th>", { "class": "text-center text-white" }).text("CONS AGUILAS"),
            $("<th>", { "class": "text-center text-white" }).text("SAPU FREI"),
            $("<th>", { "class": "text-center text-white" }).text("CESFAM LIMACHE"),
            $("<th>", { "class": "text-center text-white" }).text("CESFAM OLMUE"),
            $("<th>", { "class": "text-center text-white" }).text("APS CABILDO"),
            $("<th>", { "class": "text-center text-white" }).text("APS HIJUELAS"),
            $("<th>", { "class": "text-center text-white" }).text("APS CALERA"),
            $("<th>", { "class": "text-center text-white" }).text("APS LIGUA"),
            $("<th>", { "class": "text-center text-white" }).text("APS NOGALES"),
            $("<th>", { "class": "text-center text-white" }).text("APS PETORCA"),
            $("<th>", { "class": "text-center text-white" }).text("HOSP LIMACHE"),
            $("<th>", { "class": "text-center text-white" }).text("HOSP GERIATRICO LMCHE"),
            $("<th>", { "class": "text-center text-white" }).text("HOSP MODULAR LMCHE"),
            $("<th>", { "class": "text-center text-white" }).text("HOSP PENBLANCA"),
            $("<th>", { "class": "text-center text-white" }).text("HOSP GUSTAVO FRICKE"),
            $("<th>", { "class": "text-center text-white" }).text("HOSP CALERA"),
            $("<th>", { "class": "text-center text-white" }).text("HOSP PETORCA"),
            $("<th>", { "class": "text-center text-white" }).text("HOSP QUILLOTA"),
            $("<th>", { "class": "text-center text-white" }).text("HOSP CABILDO"),
            $("<th>", { "class": "text-center text-white" }).text("HOSP LIGUA"),
            $("<th>", { "class": "text-center text-white" }).text("HOSP QUINTERO")

        )
    );

    Mx_Dtt_Frotis.forEach((item, index) => {
        console.log(`Item ${item.CAE}`);

        $("#Tabla_Frotis tbody").append(
            $("<tr>").append(
                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(index + 1),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(calcularCantidadTotal(item), 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.CAE, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.USM_HDIURNO, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.PERSONAL, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.MQ1, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.MQ2, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.MQ3, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.UAPQ_PABELLON, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.PEDIATRIA, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.NEONATOLOGIA, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.UPC, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.UCI_A, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.UTI, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.MATERNIDAD, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.CMA, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.HOSP_DOCIMI, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.UEA_HOSP, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.UEA, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.UEI, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.SAUD, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.UEGO, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.ANATOMIA_PATO, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.IMAGENOLOGIA, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.CESFAM_IVAN_MAN, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.CESFAM_AV_AC, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.CESFAM_QUILPUE, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.CESFAM_BELLOTO, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.CONS_POMPEYA, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.CECOSF_RETIRO, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.CONS_BELLOTO, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.CESFAM_VILLA_AL, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.CESFAM_AMERICAS, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.CONS_EDUARDO_FREI, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.CESFAM_JUAN_BT, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.CONS_AGUILAS, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.SAPU_FREI, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.CESFAM_LIMACHE, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.CESFAM_OLMUE, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.APS_CABILDO, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.APS_HIJUELAS, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.APS_CALERA, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.APS_LIGUA, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.APS_NOGALES, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.APS_PETORCA, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.HOSP_LIMACHE, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.HOSP_GERIATRICO_LMCHE, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.HOSP_MODULAR_LMCHE, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.HOSP_PENBLANCA, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.HOSP_GUSTAVO_FRICKE, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.HOSP_CALERA, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.HOSP_PETORCA, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.HOSP_QUILLOTA, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.HOSP_CABILDO, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.HOSP_LIGUA, 0)),
                $("<td>", { "align": "center", css: { "width": "5%" } }).text(Math.max(item.HOSP_QUINTERO, 0))
            )
        )
    });

}


//function Fill_DataTable() {
//    $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });
//    Hide_Modal();
//    //Mx_Dtt = Mx_Dtt.filter((item) => item.EXISTE_CF == true)
//    //Mx_Dtt = Mx_Dtt.reduce((unique, item) => {
//    //    return unique.some(i => i.ID_CODIGO_FONASA === item.ID_CODIGO_FONASA) ? unique : [...unique, item];
//    //}, []);
//    var groupedData = Mx_Dtt.reduce((acc, item) => {
//        if (!acc[item.ID_SECC_REM]) {
//            acc[item.ID_SECC_REM] = {
//                SECC_REM_DESC: item.SECC_REM_DESC,
//                totalCantidad: 0,
//                items: []
//            };
//        }
//        acc[item.ID_SECC_REM].totalCantidad += item.CANTIDAD;
//        acc[item.ID_SECC_REM].items.push(item);
//        return acc;
//    }, {});


//    var tableHTML = '<table id="DataTable" class="display" width="100%" cellspacing="0"><thead</thead><tbody>';

//    for (const id in groupedData) {
//        console.log(id)
//        if (groupedData.hasOwnProperty(id)) {
//            const group = groupedData[id];
//            console.log(group)
//            tableHTML += `<tr><td colspan="3" style="background-color: #1d96b2;" class="text-center text-white"><strong>${group.SECC_REM_DESC}</strong></td>
//              <td style="background-color: #1d96b2;" class="text-center text-white"><strong>TOTAL EXÁMENES: ${group.totalCantidad}</strong></td></tr>`;
//            tableHTML += `<tr  style="background-color: #1d96b2;"><th class="text-center text-white">#</th><th class="text-center text-white">Código Fonasa</th><th class="text-white">Examen</th><th class="text-center text-white">Cantidad Exámenes</th><th class="text-center text-white">CAE</th><th class="text-center text-white">MQ1</th></tr>`;

//            group.items.forEach((item, ind) => {
//                ind +=1
//                tableHTML += `<tr>
//                    <td align="center">${ind++}</td>
//                    <td align="center" width="10%">${item.CF_COD_IRIS}</td>
//                    <td align="left" width="60%">${item.CF_DESC_HOSP}</td>
//                    <td align="center" width="5%">${item.CANTIDAD}</td>
//                    <td align="center" width="5%">${item.CAE}</td>
//                     <td align="center" width="5%">${item.MQ1}</td>
//                </tr>`;
//            });
//        }
//    }

//    tableHTML += '</tbody></table>';

//    $("#Div_Tabla_Data").html(tableHTML);

//    //$("#DataTable").DataTable({
//    //    "bSort": false,
//    //    "iDisplayLength": 25,
//    //    "language": {
//    //        "lengthMenu": "Mostrar: _MENU_",
//    //        "zeroRecords": "No hay concidencias",
//    //        "info": "Mostrando Página _PAGE_ de _PAGES_",
//    //        "infoEmpty": "No hay concidencias",
//    //        "infoFiltered": "(Se busco en _MAX_ registros )",
//    //        "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
//    //        "paginate": {
//    //            "previous": "Anterior",
//    //            "next": "Siguiente"
//    //        }
//    //    }
//    //});

//    // Mostrar el total de exámenes
//    $("#Div_Table_Total").show(function () {
//        $("#Div_Total_Data").empty().css({ "background": "#ffffff" });
//        $("<table>", {
//            "id": "DataTable_T",
//            "class": "display",
//            "width": "100%",
//            "cellspacing": "0"
//        }).appendTo("#Div_Total_Data");
//        $("#DataTable_T").append(
//            $("<tbody>")
//        );
//        $("#DataTable_T tbody").append(
//            $("<tr>").append(
//                $("<th>", {
//                    "align": "right",
//                    "width": "80%"
//                }).text("Total Exámenes"),
//                $("<td>", {
//                    "align": "right",
//                    "width": "20%"
//                }).text(function () {
//                    var T_Total = 0;
//                    for (let y = 0; y < Mx_Dtt.length; ++y) {
//                        T_Total += parseFloat(Mx_Dtt[y].CANTIDAD);
//                    }
//                    return cFormat.numToString(T_Total, 0, ".", ",");
//                }())
//            )
//        );
//    });

//    Hide_Modal();
//}
function Fill_DataTable() {

    $("#Div_Tabla_Data").empty().css({ "background": "#ffffff", "overflow": "scroll", "max-height": "60vh" });
    Hide_Modal();
    //Mx_Dtt = Mx_Dtt.filter((item) => item.EXISTE_CF == true)
    //Mx_Dtt = Mx_Dtt.reduce((unique, item) => {
    //    return unique.some(i => i.ID_CODIGO_FONASA === item.ID_CODIGO_FONASA) ? unique : [...unique, item];
    //}, []);
    var groupedData = Mx_Dtt.reduce((acc, item) => {
        if (!acc[item.ID_SECC_REM]) {
            acc[item.ID_SECC_REM] = {
                SECC_REM_DESC: item.SECC_REM_DESC,
                totalCantidad: 0,
                items: []
            };
        }
        acc[item.ID_SECC_REM].totalCantidad += item.CANTIDAD;
        acc[item.ID_SECC_REM].items.push(item);
        return acc;
    }, {});


    var tableHTML = '<table id="DataTable" class="display" width="100%" cellspacing="0"><thead></thead><tbody>';

    for (const id in groupedData) {
        console.log(id);

        if (groupedData.hasOwnProperty(id)) {
            const group = groupedData[id];
            console.log(group)
            tableHTML += `<tr>
                <td colspan="57" style="background-color: #1d96b2;" class="text-white"><strong>${group.SECC_REM_DESC}</strong></td>
                <td style="background-color: #1d96b2;" class="text-center text-white"><strong>TOTAL: ${group.totalCantidad}</strong></td>
              </tr>`;
            tableHTML += `<tr  style="background-color: #1d96b2;">
                    <th class="text-center text-white">#</th>
                    <th class="text-center text-white">Código Fonasa</th>
                    <th class="text-white">Examen</th>
                    <th class="text-center text-white">Cantidad Exámenes</th>
                    <th class="text-center text-white">CAE</th>
                   <th class="text-center text-white">USM HDIURNO</th>
                   <th class="text-center text-white">PERSONAL</th>
                   <th class="text-center text-white">MQ1</th>
                   <th class="text-center text-white">MQ2</th>
                   <th class="text-center text-white">MQ3</th>
                   <th class="text-center text-white">UAPQ PABELLON</th>
                   <th class="text-center text-white">PEDIATRIA</th>
                   <th class="text-center text-white">NEONATOLOGIA</th>
                   <th class="text-center text-white">UPC</th>
                   <th class="text-center text-white">UCI A</th>
                   <th class="text-center text-white">UTI</th>
                   <th class="text-center text-white">MATERNIDAD</th>
                   <th class="text-center text-white">CMA</th>
                   <th class="text-center text-white">HOSP DOCIMI</th>
                   <th class="text-center text-white">UEA HOSP</th>
                   <th class="text-center text-white">UEA</th>
                   <th class="text-center text-white">UEI</th>
                   <th class="text-center text-white">SAUD</th>
                   <th class="text-center text-white">UEGO</th>
                   <th class="text-center text-white">ANATOMIA PATO</th>
                   <th class="text-center text-white">IMAGENOLOGIA</th>
                   <th class="text-center text-white">CESFAM IVAN MAN</th>
                   <th class="text-center text-white">CESFAM AV AC</th>
                   <th class="text-center text-white">CESFAM QUILPUE</th>
                   <th class="text-center text-white">CESFAM BELLOTO</th>
                   <th class="text-center text-white">CONS POMPEYA</th>
                   <th class="text-center text-white">CECOSF RETIRO</th>
                   <th class="text-center text-white">CONS BELLOTO</th>
                   <th class="text-center text-white">CESFAM VILLA AL</th>
                   <th class="text-center text-white">CESFAM AMERICAS</th>
                   <th class="text-center text-white">CONS EDUARDO FREI</th>
                   <th class="text-center text-white">CESFAM JUAN BT</th>
                   <th class="text-center text-white">CONS AGUILAS</th>
                   <th class="text-center text-white">SAPU FREI</th>
                   <th class="text-center text-white">CESFAM LIMACHE</th>
                   <th class="text-center text-white">CESFAM OLMUE</th>
                   <th class="text-center text-white">APS CABILDO</th>
                   <th class="text-center text-white">APS HIJUELAS</th>
                   <th class="text-center text-white">APS CALERA</th>
                   <th class="text-center text-white">APS LIGUA</th>
                   <th class="text-center text-white">APS NOGALES</th>
                   <th class="text-center text-white">APS PETORCA</th>
                   <th class="text-center text-white">HOSP LIMACHE</th>
                   <th class="text-center text-white">HOSP GERIATRICO LMCHE</th>
                   <th class="text-center text-white">HOSP MODULAR LMCHE</th>
                   <th class="text-center text-white">HOSP PENBLANCA</th>
                   <th class="text-center text-white">HOSP GUSTAVO FRICKE</th>
                   <th class="text-center text-white">HOSP CALERA</th>
                   <th class="text-center text-white">HOSP PETORCA</th>
                   <th class="text-center text-white">HOSP QUILLOTA</th>
                   <th class="text-center text-white">HOSP CABILDO</th>
                   <th class="text-center text-white">HOSP LIGUA</th>
                   <th class="text-center text-white">HOSP QUINTERO</th>
                </tr>`;
            function getCellStyle(value) {
                return value > 0
                    ? 'background-color: green; color: white; font-weight: bold;'
                    : '';
            }
            //<td align="center" width="5%">${Math.max(calcularCantidadTotal(item), 0)}</td>
            group.items.forEach((item, ind) => {
                ind += 1
                tableHTML += `<tr>
                    <td align="center">${ind}</td>
                    <td align="center" width="10%">${item.CF_COD_IRIS}</td>
                    <td align="left" width="60%">${item.CF_DESC_HOSP}</td>
                    <td align="center" width="5%">${Math.max(calcularCantidadTotal(item), 0)}</td>
                    <td align="center" width="5%">${Math.max(item.CAE, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.USM_HDIURNO, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.PERSONAL, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.MQ1, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.MQ2, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.MQ3, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.UAPQ_PABELLON, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.PEDIATRIA, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.NEONATOLOGIA, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.UPC, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.UCI_A, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.UTI, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.MATERNIDAD, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.CMA, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.HOSP_DOCIMI, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.UEA_HOSP, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.UEA, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.UEI, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.SAUD, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.UEGO, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.ANATOMIA_PATO, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.IMAGENOLOGIA, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.CESFAM_IVAN_MAN, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.CESFAM_AV_AC, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.CESFAM_QUILPUE, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.CESFAM_BELLOTO, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.CONS_POMPEYA, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.CECOSF_RETIRO, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.CONS_BELLOTO, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.CESFAM_VILLA_AL, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.CESFAM_AMERICAS, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.CONS_EDUARDO_FREI, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.CESFAM_JUAN_BT, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.CONS_AGUILAS, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.SAPU_FREI, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.CESFAM_LIMACHE, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.CESFAM_OLMUE, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.APS_CABILDO, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.APS_HIJUELAS, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.APS_CALERA, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.APS_LIGUA, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.APS_NOGALES, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.APS_PETORCA, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.HOSP_LIMACHE, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.HOSP_GERIATRICO_LMCHE, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.HOSP_MODULAR_LMCHE, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.HOSP_PENBLANCA, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.HOSP_GUSTAVO_FRICKE, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.HOSP_CALERA, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.HOSP_PETORCA, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.HOSP_QUILLOTA, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.HOSP_CABILDO, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.HOSP_LIGUA, 0)}</td>
                    <td align="center" width="5%">${Math.max(item.HOSP_QUINTERO, 0)}</td>
                </tr>`;
            });
        }
    }

    tableHTML += '</tbody></table>';

    $("#Div_Tabla_Data").html(tableHTML);

    //$("#DataTable").DataTable({
    //    "bSort": false,
    //    "iDisplayLength": 25,
    //    "language": {
    //        "lengthMenu": "Mostrar: _MENU_",
    //        "zeroRecords": "No hay concidencias",
    //        "info": "Mostrando Página _PAGE_ de _PAGES_",
    //        "infoEmpty": "No hay concidencias",
    //        "infoFiltered": "(Se busco en _MAX_ registros )",
    //        "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
    //        "paginate": {
    //            "previous": "Anterior",
    //            "next": "Siguiente"
    //        }
    //    }
    //});

    // Mostrar el total de exámenes
    $("#Div_Table_Total").show(function () {
        $("#Div_Total_Data").empty().css({ "background": "#ffffff" });
        $("<table>", {
            "id": "DataTable_T",
            "class": "display",
            "width": "100%",
            "cellspacing": "0"
        }).appendTo("#Div_Total_Data");
        $("#DataTable_T").append(
            $("<tbody>")
        );
        $("#DataTable_T tbody").append(
            $("<tr>").append(
                $("<th>", {
                    "align": "right",
                    "width": "80%"
                }).text("Total Exámenes"),
                $("<td>", {
                    "align": "right",
                    "width": "20%"
                }).text(function () {
                    var T_Total = 0;
                    for (let y = 0; y < Mx_Dtt.length; ++y) {
                        T_Total += parseFloat(Mx_Dtt[y].CANTIDAD);
                    }
                    return cFormat.numToString(T_Total, 0, ".", ",");
                }())
            )
        );
    });

    Hide_Modal();
}

// Función para sumar todas las propiedades necesarias y asignar el resultado a item.CANTIDAD
function calcularCantidadTotal(item) {
    let total = 0;

    total += item.CAE || 0;
    total += item.USM_HDIURNO || 0;
    total += item.PERSONAL || 0;
    total += item.MQ1 || 0;
    total += item.MQ2 || 0;
    total += item.MQ3 || 0;
    total += item.UAPQ_PABELLON || 0;
    total += item.PEDIATRIA || 0;
    total += item.NEONATOLOGIA || 0;
    total += item.UPC || 0;
    total += item.UCI_A || 0;
    total += item.UTI || 0;
    total += item.MATERNIDAD || 0;
    total += item.CMA || 0;
    total += item.HOSP_DOCIMI || 0;
    total += item.UEA_HOSP || 0;
    total += item.UEA || 0;
    total += item.UEI || 0;
    total += item.SAUD || 0;
    total += item.UEGO || 0;
    total += item.ANATOMIA_PATO || 0;
    total += item.IMAGENOLOGIA || 0;
    total += item.CESFAM_IVAN_MAN || 0;
    total += item.CESFAM_AV_AC || 0;
    total += item.CESFAM_QUILPUE || 0;
    total += item.CESFAM_BELLOTO || 0;
    total += item.CONS_POMPEYA || 0;
    total += item.CECOSF_RETIRO || 0;
    total += item.CONS_BELLOTO || 0;
    total += item.CESFAM_VILLA_AL || 0;
    total += item.CESFAM_AMERICAS || 0;
    total += item.CONS_EDUARDO_FREI || 0;
    total += item.CESFAM_JUAN_BT || 0;
    total += item.CONS_AGUILAS || 0;
    total += item.SAPU_FREI || 0;
    total += item.CESFAM_LIMACHE || 0;
    total += item.CESFAM_OLMUE || 0;
    total += item.APS_CABILDO || 0;
    total += item.APS_HIJUELAS || 0;
    total += item.APS_CALERA || 0;
    total += item.APS_LIGUA || 0;
    total += item.APS_NOGALES || 0;
    total += item.APS_PETORCA || 0;
    total += item.HOSP_LIMACHE || 0;
    total += item.HOSP_GERIATRICO_LMCHE || 0;
    total += item.HOSP_MODULAR_LMCHE || 0;
    total += item.HOSP_PENBLANCA || 0;
    total += item.HOSP_GUSTAVO_FRICKE || 0;
    total += item.HOSP_CALERA || 0;
    total += item.HOSP_PETORCA || 0;
    total += item.HOSP_QUILLOTA || 0;
    total += item.HOSP_CABILDO || 0;
    total += item.HOSP_LIGUA || 0;
    total += item.HOSP_QUINTERO || 0;

    item.CANTIDAD = total;
    return item.CANTIDAD;
}
//#endregion 