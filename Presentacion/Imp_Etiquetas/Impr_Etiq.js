/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\js/jQuery.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\js/bootstrap.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\js/datepicker/js/bootstrap-datepicker.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\vendor/datatables/jquery.dataTables.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\vendor/datatables/dataTables.bootstrap4.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\js/moment.js" />

//import { fillExamenesSeccion } from "../js/es6-modules/Examenes.js";
//import fillSeccionesAreas from "../js/es6-modules/SeccionesAreas.js";
//import { fillExamenesSeccionArea } from "../../js/es6-modules/Examenes.js";
import { fillExamenesSeccionArea2 } from "../../js/es6-modules/Examenes.js";
import fillProcedencias from "../../js/es6-modules/Procedencias.js";
import { fillAreas, fillSecciones } from "../../js/es6-modules/SeccionesAreas.js";

let Class_AJAX = function () {
    this.instance = null;
    this.url = "";
    this.success = () => { };
    this.error = (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");

        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        } catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    };
};
Class_AJAX.prototype.callback = function (data) {
    let objParam = {
        "type": "POST",
        "url": this.url,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": this.success,
        "error": this.error
    };

    if (data != null) {
        objParam["data"] = JSON.stringify(data);
    }

    this.instance = $.ajax(objParam);
};

//AJAX----------------------------------------------
let arrInfo = {
    ID_ATENCION: 0,
    ATE_NUM: "",
    ATE_FECHA: new Date,
    PROC_DESC: "",
    PREVE_DESC: "",
    PAC_RUT: "",
    PAC_NOMBRE: "",
    PAC_APELLIDO: "",
    SEXO_DESC: ""
};
let objAJAX_Info = new Class_AJAX();
objAJAX_Info.url = "Impr_Etiq.aspx/Get_Info";
objAJAX_Info.success = (resp) => {
    $("#divData").empty();

    arrInfo = resp.d;
    if (resp.length == 0) {
        return;
    }

    let letTable = $("<table>", {
        class: "w-100 table table-hover table-striped table-iris table-bordered"
    });

    letTable.append(
        $("<thead>").append(
            $("<tr>").append(
                $("<th>", { align: "center" }).text("N° Atenc."),
                $("<th>", { align: "center" }).text("RUT"),
                $("<th>", { align: "center" }).text("Nombre Pac."),
                $("<th>", { align: "center" }).text("Procedencia"),
                $("<th>", { align: "center" }).text("Previsión")
            )
        )
    );

    let tbody = $("<tbody>");
    tbody.append(
        $("<tr>").append(
            $("<td>", { align: "center" }).html(arrInfo.ATE_NUM),
            $("<td>", { align: "center" }).html(arrInfo.PAC_RUT),
            $("<td>", { align: "left" }).html(`${arrInfo.PAC_NOMBRE} ${arrInfo.PAC_APELLIDO}`),
            $("<td>", { align: "left" }).html(arrInfo.PROC_DESC),
            $("<td>", { align: "left" }).html(arrInfo.PREVE_DESC)
        )
    );

    letTable.append(tbody);
    $("#divData").append(letTable);
};

let arrTableData = [{
    ID_ATENCION: 0,
    ATE_NUM: "",
    ATE_FECHA: new Date(),
    ID_PROCEDENCIA: 0,
    ID_PREVE: 0,
    ID_CODIGO_BARRA: 0,
    CB_COD: "",
    CB_DESC: "",
    ID_T_MUESTRA: 0,
    T_MUESTRA_COD: "",
    T_MUESTRA_DESC: "",
    ID_G_MUESTRA: 0,
    GMUE_COD: "",
    GMUE_DESC: ""
}];
let objAJAX_TableData = new Class_AJAX();
objAJAX_TableData.url = "Impr_Etiq.aspx/Get_Etiquetas";
objAJAX_TableData.success = (resp) => {
    $("#divTable").empty();

    arrTableData = resp.d;
    if (arrTableData.length == 0) {
        $("#divTable").append(
            $("<div>", {
                class: "alert alert-danger mb-0"
            }).text(`No se han encontrado etiquetas asociadas a ese Nro de Atención.`)
        );

        return;
    }

    let letTable = $("<table>", {
        class: "w-100 table table-hover table-striped table-iris"
    });

    letTable.append(
        $("<thead>").append(
            $("<tr>").append(
                $("<th>", { align: "center" }).text(""),
                $("<th>", { align: "center" }).text("Folio"),
                $("<th>", { align: "center" }).text("Paciente"),
                $("<th>", { align: "center" }).text("Fecha"),
                $("<th>", { align: "center" }).text("N° Barra"),
                $("<th>", { align: "center" }).text("Tipo de Muestra"),
                $("<th>", { align: "center" }).text("Color Tubo"),
                $("<th>", { align: "center" }).text("Imprimir")
            )
        )
    );

    let tbody = $("<tbody>");
    arrTableData.forEach((xItem, xIndex) => {
        tbody.append(
            $("<tr>").append(
                $("<td>", { align: "right" }).html(function () {
                    let reee = `${xIndex + 1}`;

                    while (reee.length < `${arrTableData.length}`.length) {
                        reee = `0${reee}`;
                    }

                    return reee;
                }()),
                $("<td>", { align: "center" }).html(xItem.ATE_NUM),
                $("<td>", { align: "center" }).html(xItem.PAC_FULLNAME),
                $("<td>", { align: "center" }).html(moment(xItem.ATE_FECHA).format("DD/MM/YYYY - hh:mm")),
                $("<td>", { align: "center" }).html(xItem.CB_COD),
                $("<td>", { align: "left" }).html(xItem.T_MUESTRA_DESC),
                $("<td>", { align: "left" }).text(xItem.GMUE_DESC),
                $("<td>", { align: "center" }).append(
                    $("<input>", {
                        type: "checkbox",
                        name: "chkPrint",
                        class: "m-0",
                        id: `chk_${xIndex}`,
                        value: xItem.ID_T_MUESTRA,
                        "data-id-ate": xItem.ID_ATENCION,
                        checked: "checked",
                        style: "display: none;"
                    }),
                    $("<label>", {
                        class: "div-chk",
                        for: `chk_${xIndex}`
                    }).append(
                        `<i class="fa fa-square"></i>`,
                        `<i class="fa fa-check-square"></i>`)
                )
            )
        );
    });

    letTable.append(tbody);
    $("#divTable").append(letTable);
};
let objAJAX_TableData_Filtro = new Class_AJAX();
objAJAX_TableData_Filtro.url = "Impr_Etiq.aspx/Get_Etiquetas_Filtro";
objAJAX_TableData_Filtro.success = objAJAX_TableData.success

const Ajax_Imprimir = async (idAtencion, idTipoMuestra) => {
    modal_show();
    var Data_Par_modal = JSON.stringify({
        ID_ATE: idAtencion,
        ID_TMU: idTipoMuestra
    });
    let impreso = 0;
    await $.ajax({
        "type": "POST",
        "url": "http://localhost:9990/Printer/Imp_Etiquetas_Cod_Barra",
        "data": Data_Par_modal,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": res => {
            console.log(res)
            impreso++;
        }
    });
    return impreso;
}

let objAJAX_Export = new Class_AJAX();
objAJAX_Export.url = "Impr_Etiq.aspx/Get_Excel";
objAJAX_Export.success = (resp) => {
    let strURL = resp.d;
    let bolFound = false;

    $(`#mdlExport .modal-body p`).hide();
    if (strURL != null) {
        bolFound = true;

        if (strURL.match(/^https?:\/\//gi) == null) {
            strURL = `http://${strURL}`;
        }

        $(`#mdlExport .modal-body p a`).attr("href", strURL);
    }

    $(`#mdlExport .modal-body p[data-found=${bolFound}]`).show();
    $(`#mdlExport`).modal();

    location.href = strURL;
};
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ dom ready @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
// inicio-------------------------------------------- 
let arrStr = [
    "#Txt_Date01",
    "#Txt_Date02"
];
var today = new Date();
var formattedDate = today.getFullYear() + '-' + (today.getMonth() + 1).toString().padStart(2, '0') + '-' + today.getDate().toString().padStart(2, '0');

//await fillSeccionesAreas({ idSelect: "slct-seccion" });
//await fillExamenesSeccion({ idSelect: "slct-examen", idSeccion: $("#slct-seccion").val() });

modal_show();

await fillAreas({ idSelect: "slct-area", placeholder: true });
await fillSecciones($("#slct-area").val(), { idSelect: "slct-seccion", placeholder: true });
await fillProcedencias({ idSelect: "slct-procedencia", placeholder: true });
$("#slct-seccion").on("change", () => {
    //fillExamenesSeccionArea({ idSelect: "slct-examen", idSeccion: $("#slct-seccion").val(), idArea: $("#slct-area").val() })
    fillExamenesSeccionArea2({ idSelect: "slct-examen", idSeccion: $("#slct-seccion").val(), idArea: $("#slct-area").val() })
});
$("#slct-area").on("change", async () => {
    await fillSecciones($("#slct-area").val(), { idSelect: "slct-seccion", placeholder: true });
    //fillExamenesSeccionArea({ idSelect: "slct-examen", idSeccion: $("#slct-seccion").val(), idArea: $("#slct-area").val() })
    fillExamenesSeccionArea2({ idSelect: "slct-examen", idSeccion: $("#slct-seccion").val(), idArea: $("#slct-area").val() })
});
$("#slct-area").trigger("change");


$("#txt-desde, #txt-hasta").val(formattedDate);
arrStr.forEach((xItem) => {
    $(xItem).val(moment().format("DD/MM/YYYY"));

    $(xItem).parent().parent().datepicker({
        format: "dd/mm/yyyy",
        language: "es",
        autoclose: true
    });
});

$("#mdlSearch").modal({
    show: false
});
$("#mdlSearch").on("show.bs.modal", () => {
    $("#Txt_Nate").val("");
});
$("#mdlSearch").on("shown.bs.modal", () => {
    $("#Txt_Nate").focus();
});

//Eventos--------------------------------------------
let fn_Search_filtro = () => {
    objAJAX_TableData_Filtro.callback({
        DESDE: $("#txt-desde").val().split("-").reverse().join("-"),
        HASTA: $("#txt-hasta").val().split("-").reverse().join("-"),
        ID_PROC: $("#slct-procedencia").val(),
        ID_SECC: $("#slct-seccion").val(),
        ID_CF: $("#slct-examen").val(),
        ID_AREA: $("#slct-area").val()
    });
};

$("#btn-buscar-filtro").click((Me) => {
    fn_Search_filtro();
});
//$("#slct-seccion").change(() => {
//    fillExamenesSeccion({ idSelect: "slct-examen", idSeccion: $("#slct-seccion").val() });
//});
$("#Btn_Search").click((Me) => {
    fn_Search();
});
$("#Txt_Nate").keydown((Me) => {
    let strData = $("#Txt_Nate").val();

    strData = strData.replace(/[^0-9]/gi, "");
    strData = strData.match(/[0-9]{1,10}/gi);

    if (strData != null) {
        strData = strData[0];
    }

    if (strData != null) {
        strData = strData.replace(/^0/gi, "");
    }
    $("#Txt_Nate").val(strData);
});
$("#Txt_Nate").keyup((Me) => {
    if (Me.which == 13) {
        fn_Search();
    } else {
        let strData = $("#Txt_Nate").val();

        strData = strData.replace(/[^0-9]/gi, "");
        strData = strData.match(/[0-9]{1,10}/gi);

        if (strData == null) {
            strData = "0";
        } else {
            strData = strData[0];
        }

        $("#Txt_Nate").val(strData);
    }
});

let fn_Search = () => {
    objAJAX_Info.callback({
        ATE_NUM: $("#Txt_Nate").val()
    });
    objAJAX_TableData.callback({
        ATE_NUM: $("#Txt_Nate").val()
    });
    $("#mdlSearch").modal("hide");
};

$("#Btn_Print").click(async () => {
    const seleccionados = [...document.querySelectorAll("input[name=chkPrint]:checked")];
    const arrayAMedias = seleccionados.map(item => ({
        idAtencion: item.getAttribute("data-id-ate"),
        idTipoMuestra: item.value
    }));
    const atenciones = arrayAMedias.reduce((result, current) => {
        var group = result.find((item) => {
            return item.idAtencion === current.idAtencion;
        });
        if (!group) {
            group = {
                idAtencion: current.idAtencion,
                idTipoMuestra: []
            };
            result.push(group);
        }
        group.idTipoMuestra.push(current.idTipoMuestra);

        return result;
    }, []);
    let impresionesCorrecta = 0;
    for (const atencion of atenciones) {
        impresionesCorrecta += await Ajax_Imprimir(atencion.idAtencion, atencion.idTipoMuestra);
    }
    Hide_Modal();
});
$("#Btn_Export").click(() => {
    objAJAX_Export.callback({
        DESDE: $("#txt-desde").val().split("-").reverse().join("-"),
        HASTA: $("#txt-hasta").val().split("-").reverse().join("-"),
        ID_PROC: $("#slct-procedencia").val(),
        ID_SECC: $("#slct-seccion").val(),
        ID_CF: $("#slct-examen").val(),
        ID_AREA: $("#slct-area").val()
    });
});

$("#Btn_ChkFull").click(() => {
    $("input[name=chkPrint]").prop("checked", true);
});

$("#Btn_ChkEmpty").click(() => {
    $("input[name=chkPrint]").prop("checked", false);
});


Hide_Modal();