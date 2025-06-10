function format_toCLP(AAAAAA) {
    var num = AAAAAA;
    if (!isNaN(num)) {
        num = num.toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g, '$1.');
        num = num.split('').reverse().join('').replace(/^[\.]/, '');
        return num;
        //input.value = num;
    }
}

function jsDecimals(e) {

    var evt = (e) ? e : window.event;
    var key = (evt.keyCode) ? evt.keyCode : evt.which;
    if (key != null) {
        key = parseInt(key, 10);
        if ((key < 48 || key > 57) && (key < 96 || key > 105)) {
            //Aca tenemos que reemplazar "Decimals" por "NoDecimals" si queremos que no se permitan decimales
            if (!jsIsUserFriendlyChar(key, "NoDecimals")) {
                return false;
            }
        }
        else {
            if (evt.shiftKey) {
                return false;
            }
        }
    }
    return true;
}

// Función para las teclas especiales
//------------------------------------------
function jsIsUserFriendlyChar(val, step) {
    // Backspace, Tab, Enter, Insert, y Delete
    if (val == 8 || val == 9 || val == 13 || val == 45 || val == 46) {
        return true;
    }
    // Ctrl, Alt, CapsLock, Home, End, y flechas
    if ((val > 16 && val < 21) || (val > 34 && val < 41)) {
        return true;
    }
    if (step == "Decimals") {
        if (val == 190 || val == 110) {  //Check dot key code should be allowed
            return true;
        }
    }
    // The rest
    return false;
}

var MX_HO_ExamenCodigo = new Array();
//Class AJAX---------------------------------------------------------------------
let Class_AJAX = function () {
    this.url = "";
    this.success = () => { };
    this.error = () => { };
};
var omi_save = 0;
let WOO_ID_ATE = 0;
Class_AJAX.prototype.callback = function (data) {
    $.ajax({
        "type": "POST",
        "url": this.url,
        "data": JSON.stringify(data),
        "contentType": "application/json;  charset=utf-8",
        "contentType": "text/plain;  charset=utf-8",
        "dataType": "json",
        "timeout": 20000,
        "success": this.success,
        "error": this.error
    });
};

let timer = 4000;
let objAJAX_Atenc = new Class_AJAX();
objAJAX_Atenc.url = "http://localhost:9990/Printer/Imp_Voucher_Compr_Ate";
objAJAX_Atenc.success = (resp) => {
    console.log(`[ OK ] Impresión Voucher Atención`);
    console.log(resp);
    console.log(``);

    let str_Error = `${resp.Message}. `;
    str_Error += `Iniciando Impresión de Voucher LugarTM.`;
    $("#title").text("Solicitud de Voucher");
    $("#button_modal").attr("class", "btn btn-success");
    $("#mError_AAH p").html(str_Error);
    $("#mError_AAH").modal(`show`);

    setTimeout(() => {
        $("#mError_AAH").modal(`hide`);

        objAJAX_Proc.callback([
            WOO_ID_ATE
        ]);
    }, timer);

};
objAJAX_Atenc.error = (fail) => {
    console.log(`[ERROR] Impresión Voucher Atención`);
    console.log(fail);
    console.log(``);

    setTimeout(() => {
        $("#mError_AAH").modal(`hide`);

        objAJAX_Atenc.callback([
            WOO_ID_ATE
        ]);
    }, timer);
};

let objAJAX_Proc = new Class_AJAX();
objAJAX_Proc.url = "http://localhost:9990/Printer/Imp_Voucher_Lugar_TM";
objAJAX_Proc.success = (resp) => {
    console.log(`[ OK ] Impresión Voucher LugarTM`);
    console.log(resp);
    console.log(``);

    let str_Error = `${resp.Message} `;
    str_Error += `Iniciando Impresión de Etiquetas.`;
    $("#title").text("Impresiones Finalizadas");
    $("#button_modal").attr("class", "btn btn-success");
    $("#mError_AAH p").html(str_Error);
    $("#mError_AAH").modal(`show`);

    setTimeout(() => {
        $("#mError_AAH").modal(`hide`);

        objAJAX_Etiq.callback([
            WOO_ID_ATE
        ]);
    }, timer);

};
objAJAX_Proc.error = (fail) => {
    console.log(`[ERROR] Impresión Voucher Atención`);
    console.log(fail);
    console.log(``);

    setTimeout(() => {
        $("#mError_AAH").modal(`hide`);

        objAJAX_Etiq.callback([
            WOO_ID_ATE
        ]);
    }, timer);
};

let objAJAX_Etiq = new Class_AJAX();
objAJAX_Etiq.url = "http://localhost:9990/Printer/Imp_Etiquetas";
objAJAX_Etiq.success = (resp) => {
    console.log(`[ OK ] Impresión Etiquetas`);
    console.log(resp);
    console.log(``);

    let str_Error = `${resp.Message}. `;
    str_Error += `Impresiones Finalizadas.`;
    $("#title").text("Solicitud de Etiquetas");
    $("#button_modal").attr("class", "btn btn-success");
    $("#mError_AAH p").html(str_Error);
    $("#mError_AAH").modal(`show`);

};
objAJAX_Etiq.error = (fail) => {
    console.log(`[ERROR] Impresión Voucher Atención`);
    console.log(fail);
    console.log(``);

    setTimeout(() => {
        $("#mError_AAH").modal(`hide`);

        objAJAX_Etiq.callback([
            WOO_ID_ATE
        ]);
    }, timer);
};

var GLOBAL_TOT_SEGURO_COMPLEMENTARIO = 0;
var GLOBAL_TOT_PREVISION = 0;
var GLOBAL_TOT_FONASA = 0;
var GLOBAL_TOT_COPA_PART = 0;
var GLOBAL_TOT_PREVISION = 0;
var GLOBAL_TOT_BENEFICIARIO = 0;
var GLOBAL_TOT_A_PAGAR = 0;

var PASS_SAVE = 1;

var Mx_Dtt_Resp_valAmbulatorio = [{}];

function addCommas(nStr) {
    nStr += '';
    var x = nStr.split('.');
    var x1 = x[0];
    var x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + '.' + '$2');
    }
    return x1 + x2;
}

function HOLAAAAAAAAAAA() {
    console.log("ENTER HOLAAAAA");

    //GLOBAL_TOT_SEGURO_COMPLEMENTARIO = parseInt($("#Lbl_tot_beneficiario").val());

    GLOBAL_TOT_PREVISION = 0;
    GLOBAL_TOT_FONASA = 0;
    GLOBAL_TOT_COPA_PART = 0;
    GLOBAL_TOT_PREVISION = 0;
    GLOBAL_TOT_BENEFICIARIO = 0;
    GLOBAL_TOT_A_PAGAR = 0;
    GLOBAL_TOT_SEGURO_COMPLEMENTARIO = 0;

    var asdasd = 0;
    asdasd.toLocaleString // ?

    //$(`.td_scomplementario`).each(function () {

    //    GLOBAL_TOT_SEGURO_COMPLEMENTARIO += parseInt(this.value);
    //    if (isNaN(GLOBAL_TOT_SEGURO_COMPLEMENTARIO)) {

    //    }

    //});

    $(`.td_prevision`).each(function () {
        GLOBAL_TOT_PREVISION += parseInt(this.value);
    });

    $(`.td_valorapagar`).each(function () {
        let tipo = $(this).attr("data-tipo");


        if (tipo == 1 || tipo == "1" || tipo == 20 || tipo == "20") {
            GLOBAL_TOT_COPA_PART += parseInt(this.value);
        } else {
            GLOBAL_TOT_FONASA += parseInt(this.value);
        }

        GLOBAL_TOT_A_PAGAR += parseInt(this.value);
    });

    $(`.td_valorBeneficiario`).each(function () {
        GLOBAL_TOT_BENEFICIARIO += parseInt(this.value);

        if (isNaN(GLOBAL_TOT_BENEFICIARIO)) {

        }
    });

    ////////////////////////// CON FORMATO //////////////////////////////////////////////////////////////////////////////////////
    //GLOBAL_TOT_A_PAGAR = GLOBAL_TOT_A_PAGAR - (GLOBAL_TOT_SEGURO_COMPLEMENTARIO + GLOBAL_TOT_BENEFICIARIO);

    //$("#Lbl_tot_a_pagar").val(format_toCLP((GLOBAL_TOT_COPA_PART + GLOBAL_TOT_FONASA) - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));
    //$("#lbl_Tot_Pagar_Modal").val(format_toCLP((GLOBAL_TOT_COPA_PART + GLOBAL_TOT_FONASA) - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));     


    $("#Lbl_tot_a_pagar").val(format_toCLP((GLOBAL_TOT_COPA_PART + (GLOBAL_TOT_FONASA - (GLOBAL_TOT_SEGURO_COMPLEMENTARIO)))));
    $("#lbl_Tot_Pagar_Modal").val(format_toCLP((GLOBAL_TOT_COPA_PART + (GLOBAL_TOT_FONASA - (GLOBAL_TOT_SEGURO_COMPLEMENTARIO)))));  //MODAL

    $("#Lbl_tot_prevision").val(format_toCLP(GLOBAL_TOT_PREVISION));

    //$("#Lbl_tot_beneficiario").val(format_toCLP(GLOBAL_TOT_SEGURO_COMPLEMENTARIO + GLOBAL_TOT_BENEFICIARIO));
    //$("#Lbl_tot_beneficiario").val(format_toCLP(GLOBAL_TOT_SEGURO_COMPLEMENTARIO));
    $("#Lbl_tot_beneficiario").val(format_toCLP((GLOBAL_TOT_PREVISION - (GLOBAL_TOT_COPA_PART + (GLOBAL_TOT_FONASA - (GLOBAL_TOT_SEGURO_COMPLEMENTARIO)))) - GLOBAL_TOT_BENEFICIARIO)); // perdón bro


    //$("#Lbl_tot_copa_fonasa").val(format_toCLP(GLOBAL_TOT_FONASA));
    //$("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_FONASA));  //MODAL

    $("#Lbl_tot_copa_fonasa").val(format_toCLP(GLOBAL_TOT_FONASA - (GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));
    $("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_FONASA) - (GLOBAL_TOT_SEGURO_COMPLEMENTARIO));  //MODAL

    $("#Lbl_tot_copa_particular").val(format_toCLP(GLOBAL_TOT_COPA_PART));
    $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val(format_toCLP(GLOBAL_TOT_COPA_PART));  //MODAL
};

function ddl_Change_onTable(index, idcodfona, idtppago) {
    console.log("ddl_Change_onTable");

    let fckc2 = idtppago;
    if (Mx_Dtt_examcof.length == 0) {

    } else {
        for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
            if (Mx_Dtt_examcof[i]["ATE_DET_TP_1"] == undefined || Mx_Dtt_examcof[i]["ATE_DET_TP_1"] == 0) {
                Mx_Dtt_examcof[i]["CF_TP_PAGO"] = $("input[name=inlineMaterialRadiosExample]:checked").val();
                Mx_Dtt_examcof[i]["ATE_DET_TP_1"] = $("input[name=inlineMaterialRadiosExample]:checked").val();
            } else {
                //Mx_Dtt_examcof[i].CF_TP_PAGO = $("input[name=inlineMaterialRadiosExample]:checked").val();
            }
        }

        if (fckc2 == 11 || fckc2 == 8) {                                        //PENDIENTE, SIN COSTO, garantía
            for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
                for (let x = 0; x < Mx_Dtt_exam02.length; x++) {
                    //if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == Mx_Dtt_examcof[i].ID_CODIGO_FONASA) {
                    if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == idcodfona) {
                        //Mx_Dtt_examcof[i].CF_TP_PAGO = $("input[name=inlineMaterialRadiosExample]:checked").val();
                        Mx_Dtt_examcof[i].CF_TP_PAGO = fckc2
                        Mx_Dtt_examcof[i].CF_PRECIO_AMB = 0;
                        Mx_Dtt_examcof[i].CF_BONIFICACION = 0;
                        Mx_Dtt_examcof[i].ATE_DET_TP_1 = fckc2
                        return 0;//Mx_Dtt_examcof[i].CF_PRECIO_AMB = 0;
                    }
                }
            }
        } else if (fckc2 == 4) {                                            //BONO TRADICIONAL
            for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
                for (let x = 0; x < Mx_Dtt_Resp_valAmbulatorio.length; x++) {
                    if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == idcodfona && Mx_Dtt_Resp_valAmbulatorio[x].ID_CODIGO_FONASA == idcodfona) {//== Mx_Dtt_examcof[i].ID_CODIGO_FONASA) {
                        Mx_Dtt_examcof[i].CF_PRECIO_AMB = Mx_Dtt_Resp_valAmbulatorio[x].CF_PRECIO_AMB;
                        Mx_Dtt_examcof[i].CF_BONIFICACION = Mx_Dtt_Resp_valAmbulatorio[x].CF_PRECIO_AMB;
                        Mx_Dtt_examcof[i].CF_TP_PAGO = fckc2;
                        Mx_Dtt_examcof[i].ATE_DET_TP_1 = fckc2;
                        return Mx_Dtt_Resp_valAmbulatorio[x].CF_PRECIO_AMB;
                    }
                }
            }
        } else if (fckc2 == 1 || fckc2 == 20) {                                                             //CAMBIAMOS VALORES POR EFECTIVO O PARTICULAR
            var findet = 0;
            for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
                for (let x = 0; x < Mx_Dtt_exam02_Particular.length; x++) {
                    if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == idcodfona && Mx_Dtt_exam02_Particular[x].ID_CODIGO_FONASA == idcodfona) {
                        findet = 1;
                        //Mx_Dtt_examcof[i].CF_TP_PAGO = $("input[name=inlineMaterialRadiosExample]:checked").val();
                        Mx_Dtt_examcof[i].CF_TP_PAGO = fckc2;
                        Mx_Dtt_examcof[i].CF_BONIFICACION = 0;
                        Mx_Dtt_examcof[i].CF_PRECIO_AMB = Mx_Dtt_exam02_Particular[x].CF_PRECIO_AMB;
                        Mx_Dtt_examcof[i].ATE_DET_TP_1 = fckc2;
                        return Mx_Dtt_exam02_Particular[x].CF_PRECIO_AMB;
                    }
                }
            }
            for (let x = 0; x < Mx_Dtt_Resp_valAmbulatorio.length; x++) {
                if (Mx_Dtt_Resp_valAmbulatorio[x].ID_CODIGO_FONASA == idcodfona) {
                    //Mx_Dtt_examcof[i].ID_CODIGO_FONASA) {
                    findet = 1;
                    return Mx_Dtt_Resp_valAmbulatorio[x].CF_PRECIO_AMB;
                    //return Mx_Dtt_exam02[x].CF_PRECIO_AMB;
                }
            }
        }
        else if (fckc2 == 18 || fckc2 == 5 || fckc2 == 3 || fckc2 == 2 || fckc2 == 19 || fckc2 == 19) {
            for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
                for (let x = 0; x < Mx_Dtt_Resp_valAmbulatorio.length; x++) {
                    if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == idcodfona && Mx_Dtt_Resp_valAmbulatorio[x].ID_CODIGO_FONASA == idcodfona) {//== Mx_Dtt_examcof[i].ID_CODIGO_FONASA) {
                        Mx_Dtt_examcof[i].CF_PRECIO_AMB = Mx_Dtt_Resp_valAmbulatorio[x].CF_PRECIO_AMB;
                        Mx_Dtt_examcof[i].CF_BONIFICACION = Mx_Dtt_Resp_valAmbulatorio[x].CF_BONIFICACION;
                        Mx_Dtt_examcof[i].CF_TP_PAGO = fckc2;
                        Mx_Dtt_examcof[i].ATE_DET_TP_1 = fckc2;
                        return Mx_Dtt_Resp_valAmbulatorio[x].CF_PRECIO_AMB;
                    }
                }
            }
        }
        else {

            //for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
            for (let x = 0; x < Mx_Dtt_Resp_valAmbulatorio.length; x++) {
                if (Mx_Dtt_Resp_valAmbulatorio[x].ID_CODIGO_FONASA == idcodfona) {
                    //Mx_Dtt_examcof[i].ID_CODIGO_FONASA) {
                    findet = 1;
                    Mx_Dtt_examcof[i].CF_TP_PAGO = fckc2;
                    Mx_Dtt_examcof[i].CF_BONIFICACION = Mx_Dtt_Resp_valAmbulatorio[x].CF_BONIFICACION;
                    Mx_Dtt_examcof[i].CF_PRECIO_AMB = Mx_Dtt_Resp_valAmbulatorio[x].CF_PRECIO_AMB;
                    Mx_Dtt_examcof[i].ATE_DET_TP_1 = fckc2;
                    return Mx_Dtt_Resp_valAmbulatorio[x].CF_PRECIO_AMB;
                    //return Mx_Dtt_exam02[x].CF_PRECIO_AMB;
                }
            }
            //}
        }

    }
    //fill_llenado_tabla();
}
let tp111 = 0;
let tp222 = 0;

let tp111_Parti = 0;
let tp222_Parti = 0;

let activador = 0;
let activador_Parti = 0

function Ajax_ONCLICK_2(ID_USU, ID_ATE) {
    var loc = location.origin;
    window.open(loc + "/Scan_Docs/Ver_Orden.aspx?IDU=" + ID_USU + "&IDA=" + ID_ATE);
}

var cod_or_desc = 0;
//-------------------------------------------------------------------------------
$(document).ready(() => {
    $("#Btn_Print, #Btn_Print_Mdl").click(() => {
        WOO_ID_ATE = parseInt(Mx_Detalle_ate.proparra3[0].ID_PREINGRESO);

        objAJAX_Atenc.callback([
            WOO_ID_ATE
        ]);
    });

    $("button[data-dismiss=modal]").click(() => {
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
    });
});

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}
var xId = 0;
var selected = new Array();
var verrut = 0;
var ids = new Array();
var hh = 0;
var hh2 = 0;
var hh3 = 0;
var sifi = 0;
var checked_rdn = 0;
var cod_fo_eli = 0;
var fila_eli = 0;
$(document).ready(async function () {
    $("#mdlCheck_Print").on("hidden.bs.modal", () => {

        window.location.replace(location.origin + "/Index.aspx");
    })
    $("#button_modal_s_comple").click(() => {
        Ajax_guardar();
    });

    $("#btn_Eliminar_Confirma").click(() => {
        console.log("click en confirma " + cod_fo_eli, fila_eli);
        Eliminar_Examen(cod_fo_eli, fila_eli);

    });

    $("#Lbl_tot_beneficiario").click(() => {
        console.log("click SC");
        if ($("#Lbl_tot_beneficiario").val() == "0") {
            $("#Lbl_tot_beneficiario").val("");
        } else {

        }
    });

    $("#Lbl_tot_beneficiario").focusout(() => {
        console.log("focusout SC");
        if ($("#Lbl_tot_beneficiario").val() == "") {
            $("#Lbl_tot_beneficiario").val("0");
            GLOBAL_TOT_SEGURO_COMPLEMENTARIO = 0;
            //GLOBAL_TOT_BENEFICIARIO = 0;
        } else {

        }
    });

    $("#lbl_Tot_Fonasa_Modal_2").click(() => {
        if ($("#lbl_Tot_Fonasa_Modal_2").val() == "0") {
            $("#lbl_Tot_Fonasa_Modal_2").val("");
        } else {

        }
    });

    $("#lbl_Tot_Fonasa_Modal_2").focusout(() => {
        if ($("#lbl_Tot_Fonasa_Modal_2").val() == "") {
            $("#lbl_Tot_Fonasa_Modal_2").val("0");
            tp222 = 0;
        } else {

        }
    });

    $("#lbl_Tot_Fonasa_Modal_2_Parti").click(() => {
        if ($("#lbl_Tot_Fonasa_Modal_2_Parti").val() == "0") {
            $("#lbl_Tot_Fonasa_Modal_2_Parti").val("");
        } else {

        }
    });

    $("#lbl_Tot_Fonasa_Modal_2_Parti").focusout(() => {
        if ($("#lbl_Tot_Fonasa_Modal_2_Parti").val() == "") {
            $("#lbl_Tot_Fonasa_Modal_2_Parti").val("0");
            tp222_Parti = 0;
        } else {

        }
    });


    $("#agregaMedioPago").click(() => {
        activador = 1;
        $("#agregaMedioPago").hide();
        $("#spanAgregaMedioPago").hide();
        $("#divNewPaymen").show();

        $("#lbl_Tot_Fonasa_Modal").removeAttr("disabled");
        $("#lbl_Tot_Fonasa_Modal_2").removeAttr("disabled");

        $("#lbl_Tot_Fonasa_Modal_2").val("0");

        tp111 = $("#lbl_Tot_Fonasa_Modal").val();
        tp111 = tp111.replace(".", "");

    });

    $("#quitaMedioPago").click(() => {
        activador = 0;
        $("#divNewPaymen").hide();
        $("#agregaMedioPago").show();
        $("#spanAgregaMedioPago").show();
        //$("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_PREVISION - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));

        //$("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_PREVISION - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));
        $("#Lbl_tot_copa_fonasa").val(format_toCLP(GLOBAL_TOT_FONASA));
        $("#lbl_Tot_Fonasa_Modal").attr("disabled", "disabled");

    });

    $("#agregaMedioPago_Parti").click(() => {
        activador_Parti = 1;
        $("#agregaMedioPago_Parti").hide();
        $("#spanAgregaMedioPago_Parti").hide();
        $("#divNewPaymen_Parti").show();

        $("#lbl_Tot_Pagar_Insumos_Particul_Modal").removeAttr("disabled");
        $("#lbl_Tot_Fonasa_Modal_2_Parti").removeAttr("disabled");

        $("#lbl_Tot_Fonasa_Modal_2_Parti").val("0");

        tp111_Parti = $("#Lbl_tot_copa_particular").val();
        tp111_Parti = tp111_Parti.replace(".", "");

    });

    $("#quitaMedioPago_Parti").click(() => {
        activador_Parti = 0;
        $("#divNewPaymen_Parti").hide();
        $("#agregaMedioPago_Parti").show();
        $("#spanAgregaMedioPago_Parti").show();
        //$("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_PREVISION - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));

        //$("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_PREVISION - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));


        $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val($("#Lbl_tot_copa_particular").val());
        $("#lbl_Tot_Pagar_Insumos_Particul_Modal").attr("disabled", "disabled");

    });

    $("#agregaMedioPago").click(() => {
        activador = 1;
        $("#agregaMedioPago").hide();
        $("#spanAgregaMedioPago").hide();
        $("#divNewPaymen").show();

        $("#lbl_Tot_Fonasa_Modal").removeAttr("disabled");
        $("#lbl_Tot_Fonasa_Modal_2").removeAttr("disabled");

        $("#lbl_Tot_Fonasa_Modal_2").val("0");

        tp111 = $("#lbl_Tot_Fonasa_Modal").val();
        tp111 = tp111.replace(".", "");

        if (GLOBAL_TOT_FONASA == 0) {
            $("#lbl_Tot_Fonasa_Modal").attr("disabled", "disabled");
            $("#lbl_Tot_Fonasa_Modal_2").attr("disabled", "disabled");
            $("#Ddl_Ttp_Modal").attr("disabled", "disabled");
            $("#Ddl_Ttp_Modal_2").attr("disabled", "disabled");
            console.log("bloquea copago");
        } else {
            $("#lbl_Tot_Fonasa_Modal").removeAttr("disabled");
            $("#lbl_Tot_Fonasa_Modal_2").removeAttr("disabled");
            $("#Ddl_Ttp_Modal").removeAttr("disabled");
            $("#Ddl_Ttp_Modal_2").removeAttr("disabled");
            console.log("desbloquea copago");
        }

        if (GLOBAL_TOT_COPA_PART == 0) {
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").attr("disabled", "disabled");
            $("#lbl_Tot_Fonasa_Modal_2_Parti").attr("disabled", "disabled");
            $("#Ddl_Ttp_Modal_2_Parti").attr("disabled", "disabled");
            $("#Ddl_Ttp_Modal2").attr("disabled", "disabled");
            console.log("bloquea particular");
        } else {
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").removeAttr("disabled");
            $("#lbl_Tot_Fonasa_Modal_2_Parti").removeAttr("disabled");
            $("#Ddl_Ttp_Modal_2_Parti").removeAttr("disabled");
            $("#Ddl_Ttp_Modal2").removeAttr("disabled");
            console.log("desbloquea particular");
        }

    });

    $("#quitaMedioPago").click(() => {
        activador = 0;
        $("#divNewPaymen").hide();
        $("#agregaMedioPago").show();
        $("#spanAgregaMedioPago").show();
        //$("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_PREVISION - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));

        //$("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_PREVISION - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));
        $("#Lbl_tot_copa_fonasa").val(format_toCLP(GLOBAL_TOT_FONASA));
        $("#lbl_Tot_Fonasa_Modal").attr("disabled", "disabled");
        $("#lbl_Tot_Fonasa_Modal").val(parseInt(GLOBAL_TOT_FONASA));

        $("#lbl_Tot_Fonasa_Modal_2").val(0);

    });

    $("#agregaMedioPago_Parti").click(() => {
        console.log("agregaMedioPago_Parti: " + tp111_Parti);
        activador_Parti = 1;
        $("#agregaMedioPago_Parti").hide();
        $("#spanAgregaMedioPago_Parti").hide();
        $("#divNewPaymen_Parti").show();

        $("#lbl_Tot_Pagar_Insumos_Particul_Modal").removeAttr("disabled");
        $("#lbl_Tot_Fonasa_Modal_2_Parti").removeAttr("disabled");

        $("#lbl_Tot_Fonasa_Modal_2_Parti").val("0");

        tp111_Parti = $("#Lbl_tot_copa_particular").val();
        tp111_Parti = tp111_Parti.replace(".", "");

        tp222_parti = 0;

        if (GLOBAL_TOT_FONASA == 0) {
            $("#lbl_Tot_Fonasa_Modal").attr("disabled", "disabled");
            $("#lbl_Tot_Fonasa_Modal_2").attr("disabled", "disabled");
            $("#Ddl_Ttp_Modal").attr("disabled", "disabled");
            $("#Ddl_Ttp_Modal_2").attr("disabled", "disabled");
            console.log("bloquea copago");
        } else {
            $("#lbl_Tot_Fonasa_Modal").removeAttr("disabled");
            $("#lbl_Tot_Fonasa_Modal_2").removeAttr("disabled");
            $("#Ddl_Ttp_Modal").removeAttr("disabled");
            $("#Ddl_Ttp_Modal_2").removeAttr("disabled");
            console.log("desbloquea copago");
        }

        if (GLOBAL_TOT_COPA_PART == 0) {
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").attr("disabled", "disabled");
            $("#lbl_Tot_Fonasa_Modal_2_Parti").attr("disabled", "disabled");
            $("#Ddl_Ttp_Modal_2_Parti").attr("disabled", "disabled");
            $("#Ddl_Ttp_Modal2").attr("disabled", "disabled");
            console.log("bloquea particular");
        } else {
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").removeAttr("disabled");
            $("#lbl_Tot_Fonasa_Modal_2_Parti").removeAttr("disabled");
            $("#Ddl_Ttp_Modal_2_Parti").removeAttr("disabled");
            $("#Ddl_Ttp_Modal2").removeAttr("disabled");
            console.log("desbloquea particular");
        }

    });

    $("#quitaMedioPago_Parti").click(() => {
        activador_Parti = 0;
        $("#divNewPaymen_Parti").hide();
        $("#agregaMedioPago_Parti").show();
        $("#spanAgregaMedioPago_Parti").show();
        //$("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_PREVISION - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));

        //$("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_PREVISION - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));

        tp222_parti = 0;
        $("#lbl_Tot_Fonasa_Modal_2_Parti").val(0);
        $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val($("#Lbl_tot_copa_particular").val());
        $("#lbl_Tot_Pagar_Insumos_Particul_Modal").attr("disabled", "disabled");

    });

    $("#lbl_Tot_Fonasa_Modal").keyup(() => {

        $("#lbl_Tot_Fonasa_Modal_2").val(0);

        let tp11 = $("#lbl_Tot_Fonasa_Modal").val();
        let tp22 = $("#lbl_Tot_Fonasa_Modal_2").val();

        tp111 = tp11.replace(".", "");
        $("#lbl_Tot_Fonasa_Modal").val(addCommas(tp111));

        tp222 = tp22.replace(".", "");
        $("#lbl_Tot_Fonasa_Modal_2").val(addCommas(tp222));

        if ($("#lbl_Tot_Fonasa_Modal").val() == "") {
            $("#lbl_Tot_Fonasa_Modal").val(0);
            tp111 = parseInt(0);
        } else {
            tp111 = parseInt(tp111);
        }

        if ($("#lbl_Tot_Fonasa_Modal_2").val() == "") {
            $("#lbl_Tot_Fonasa_Modal_2").val(0);
            tp222 = parseInt(0);
        } else {
            tp222 = parseInt(tp222);
        }

        if (tp111 > tp222) {
            console.log("mayor");
            tp111 = tp111 - tp222;

            $("#lbl_Tot_Fonasa_Modal").val(tp111);

        } else if (tp111 < tp222) {
            console.log("mayor");

        } else {
            console.log("iguales");
        }

        if ((tp111 + tp222) == parseInt(GLOBAL_TOT_FONASA)) {
            $("#lbl_Tot_Fonasa_Modal").css({
                "border-color": "#ccc"
            });
            $("#lbl_Tot_Fonasa_Modal").parent().css({
                "color": "#212529"
            });
            $("#lbl_Tot_Fonasa_Modal_2").css({
                "border-color": "#ccc"
            });
            $("#lbl_Tot_Fonasa_Modal_2").parent().css({
                "color": "#212529"
            });
        } else {
            $("#lbl_Tot_Fonasa_Modal").css({
                "border-color": "red"
            });
            $("#lbl_Tot_Fonasa_Modal").parent().css({
                "color": "red"
            });
            $("#lbl_Tot_Fonasa_Modal_2").css({
                "border-color": "red"
            });
            $("#lbl_Tot_Fonasa_Modal_2").parent().css({
                "color": "red"
            });
        }
    });


    $("#lbl_Tot_Fonasa_Modal_2").keyup(() => {

        $("#lbl_Tot_Fonasa_Modal").val(parseInt(GLOBAL_TOT_FONASA));

        let tp11 = $("#lbl_Tot_Fonasa_Modal").val();
        let tp22 = $("#lbl_Tot_Fonasa_Modal_2").val();

        tp111 = tp11.replace(".", "");
        $("#lbl_Tot_Fonasa_Modal").val(addCommas(tp111));

        tp222 = tp22.replace(".", "");
        $("#lbl_Tot_Fonasa_Modal_2").val(addCommas(tp222));

        if ($("#lbl_Tot_Fonasa_Modal").val() == "") {
            $("#lbl_Tot_Fonasa_Modal").val(0);
            tp111 = parseInt(0);
        } else {
            tp111 = parseInt(tp111);
        }

        if ($("#lbl_Tot_Fonasa_Modal_2").val() == "") {
            $("#lbl_Tot_Fonasa_Modal_2").val(0);
            tp222 = parseInt(0);
        } else {
            tp222 = parseInt(tp222);
        }

        if (tp111 > tp222) {
            console.log("mayor");
            tp111 = tp111 - tp222;

            $("#lbl_Tot_Fonasa_Modal").val(tp111);

        } else if (tp111 < tp222) {
            console.log("mayor");

        } else {
            console.log("iguales");
        }

        if ((tp111 + tp222) == parseInt(GLOBAL_TOT_FONASA)) {
            $("#lbl_Tot_Fonasa_Modal").css({
                "border-color": "#ccc"
            });
            $("#lbl_Tot_Fonasa_Modal").parent().css({
                "color": "#212529"
            });
            $("#lbl_Tot_Fonasa_Modal_2").css({
                "border-color": "#ccc"
            });
            $("#lbl_Tot_Fonasa_Modal_2").parent().css({
                "color": "#212529"
            });
        } else {
            $("#lbl_Tot_Fonasa_Modal").css({
                "border-color": "red"
            });
            $("#lbl_Tot_Fonasa_Modal").parent().css({
                "color": "red"
            });
            $("#lbl_Tot_Fonasa_Modal_2").css({
                "border-color": "red"
            });
            $("#lbl_Tot_Fonasa_Modal_2").parent().css({
                "color": "red"
            });
        }
    });

    //--------------------------- PARA PARTICULARES -------------

    $("#lbl_Tot_Pagar_Insumos_Particul_Modal").keyup(() => {
        console.log("lbl_Tot_Pagar_Insumos_Particul_Modal____");
        $("#lbl_Tot_Fonasa_Modal_2_Parti").val(0);

        let tp11_parti = $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val();
        let tp22_parti = $("#lbl_Tot_Fonasa_Modal_2_Parti").val();

        let JJJHHHUUUU = $("#Lbl_tot_copa_particular").val();
        JJJHHHUUUU = JJJHHHUUUU.replace(".", "");
        JJJHHHUUUU = parseInt(JJJHHHUUUU);

        tp111_parti = tp11_parti.replace(".", "");
        $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val(addCommas(tp111_parti));

        tp222_parti = tp22_parti.replace(".", "");
        $("#lbl_Tot_Fonasa_Modal_2_Parti").val(addCommas(tp222_parti));

        if ($("#lbl_Tot_Pagar_Insumos_Particul_Modal").val() == "") {
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val(0);
            tp111_parti = parseInt(0);
        } else {
            tp111_parti = parseInt(tp111_parti);
        }

        if ($("#lbl_Tot_Fonasa_Modal_2_Parti").val() == "") {
            $("#lbl_Tot_Fonasa_Modal_2_Parti").val(0);
            tp222_parti = parseInt(0);
        } else {
            tp222_parti = parseInt(tp222_parti);
        }

        if (tp111_parti > tp222_parti) {
            console.log("mayor");
            tp111_parti = tp111_parti - tp222_parti;

            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val(tp111_parti);

        } else if (tp111_parti < tp222_parti) {
            console.log("mayor");

        } else {
            console.log("iguales");
        }

        if ((tp111_parti + tp222_parti) == parseInt(JJJHHHUUUU)) {
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").css({
                "border-color": "#ccc"
            });
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").parent().css({
                "color": "#212529"
            });
            $("#lbl_Tot_Fonasa_Modal_2_Parti").css({
                "border-color": "#ccc"
            });
            $("#lbl_Tot_Fonasa_Modal_2_Parti").parent().css({
                "color": "#212529"
            });
        } else {
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").css({
                "border-color": "red"
            });
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").parent().css({
                "color": "red"
            });
            $("#lbl_Tot_Fonasa_Modal_2_Parti").css({
                "border-color": "red"
            });
            $("#lbl_Tot_Fonasa_Modal_2_Parti").parent().css({
                "color": "red"
            });
        }
    });

    $("#lbl_Tot_Fonasa_Modal_2_Parti").keyup(() => {


        $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val(parseInt(GLOBAL_TOT_COPA_PART));

        let tp11_parti = $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val();
        let tp22_parti = $("#lbl_Tot_Fonasa_Modal_2_Parti").val();

        tp111_parti = tp11_parti.replace(".", "");
        $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val(addCommas(tp111_parti));

        tp222_parti = tp22_parti.replace(".", "");
        $("#lbl_Tot_Fonasa_Modal_2_Parti").val(addCommas(tp222_parti));

        if ($("#lbl_Tot_Pagar_Insumos_Particul_Modal").val() == "") {
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val(0);
            tp111_parti = parseInt(0);
        } else {
            tp111_parti = parseInt(tp111_parti);
        }

        if ($("#lbl_Tot_Fonasa_Modal_2_Parti").val() == "") {
            $("#lbl_Tot_Fonasa_Modal_2_Parti").val(0);
            tp222_parti = parseInt(0);
        } else {
            tp222_parti = parseInt(tp222_parti);
        }

        if (tp111_parti > tp222_parti) {
            console.log("mayor");
            tp111_parti = tp111_parti - tp222_parti;

            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val(tp111_parti);

        } else if (tp111_parti < tp222_parti) {
            console.log("menor");

        } else {
            console.log("iguales");
        }

        if ((tp111_parti + tp222_parti) == parseInt(GLOBAL_TOT_COPA_PART)) {
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").css({
                "border-color": "#ccc"
            });
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").parent().css({
                "color": "#212529"
            });

            $("#lbl_Tot_Fonasa_Modal_2_Parti").css({
                "border-color": "#ccc"
            });
            $("#lbl_Tot_Fonasa_Modal_2_Parti").parent().css({
                "color": "#212529"
            });

        } else {
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").css({
                "border-color": "red"
            });
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").parent().css({
                "color": "red"
            });

            $("#lbl_Tot_Fonasa_Modal_2_Parti").css({
                "border-color": "red"
            });
            $("#lbl_Tot_Fonasa_Modal_2_Parti").parent().css({
                "color": "red"
            });
        }
    });

    $("#Lbl_tot_beneficiario").val(0);

    $("#Lbl_tot_beneficiario").keyup(() => {
        console.log("keyup SC");
        if ($("#Lbl_tot_beneficiario").val() == "") {
            $("#Lbl_tot_beneficiario").val(0);
            GLOBAL_TOT_SEGURO_COMPLEMENTARIO = 0;
            //GLOBAL_TOT_BENEFICIARIO = 0;
        }

        //$(`.td_scomplementario`).each(function () {
        //    $(`.td_scomplementario`).val($("#Lbl_tot_beneficiario").val());
        //});

        //GLOBAL_TOT_SEGURO_COMPLEMENTARIO + GLOBAL_TOT_BENEFICIARIO = parseInt($("#Lbl_tot_beneficiario").val());
        GLOBAL_TOT_SEGURO_COMPLEMENTARIO = parseInt($("#Lbl_tot_beneficiario").val());

        //$("#Lbl_tot_copa_fonasa").val(format_toCLP(GLOBAL_TOT_PREVISION - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));
        //$("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_PREVISION - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));    //MODAL

        //$("#Lbl_tot_copa_fonasa").val(format_toCLP(GLOBAL_TOT_FONASA - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));     //T. Copa Fonasa
        //$("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_FONASA - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));    //T. Copa Fonasa MODAL

        //GLOBAL_TOT_FONASA = parseInt($("#Lbl_tot_prevision").val());

        //$("#Lbl_tot_copa_fonasa").val(format_toCLP(GLOBAL_TOT_FONASA - (GLOBAL_TOT_SEGURO_COMPLEMENTARIO + GLOBAL_TOT_BENEFICIARIO)));     //T. Copa Fonasa
        //$("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_FONASA - (GLOBAL_TOT_SEGURO_COMPLEMENTARIO + GLOBAL_TOT_BENEFICIARIO)));    //T. Copa Fonasa GLOBAL DE


        //$("#Lbl_tot_a_pagar").val(format_toCLP((GLOBAL_TOT_COPA_PART + GLOBAL_TOT_FONASA - (GLOBAL_TOT_SEGURO_COMPLEMENTARIO + GLOBAL_TOT_BENEFICIARIO))));
        //$("#lbl_Tot_Pagar_Modal").val(format_toCLP((GLOBAL_TOT_COPA_PART + GLOBAL_TOT_FONASA - (GLOBAL_TOT_SEGURO_COMPLEMENTARIO + GLOBAL_TOT_BENEFICIARIO))));  //MODAL AL PRESIONAR BOTOn GUARDADO

        HOLAAAAAAAAAAA();

    });


    //$("#lbl_Tot_Fonasa_Modal").keyup(() => {
    //    let tp11 = $("#lbl_Tot_Fonasa_Modal").val();
    //    let tp111 = tp11.replace(".","");
    //    $("#lbl_Tot_Fonasa_Modal").val(format_toCLP(tp111));
    //});

    $("#lbl_Tot_Fonasa_Modal, #lbl_Tot_Fonasa_Modal_2").keyup(() => {
        let tp11 = $("#lbl_Tot_Fonasa_Modal").val();
        let tp22 = $("#lbl_Tot_Fonasa_Modal_2").val();

        tp111 = tp11.replace(".", "");
        $("#lbl_Tot_Fonasa_Modal").val(addCommas(tp111));

        tp222 = tp22.replace(".", "");
        $("#lbl_Tot_Fonasa_Modal_2").val(addCommas(tp222));

        if ($("#lbl_Tot_Fonasa_Modal").val() == "") {
            $("#lbl_Tot_Fonasa_Modal").val(0);
            tp111 = parseInt(0);
        } else {
            tp111 = parseInt(tp111);
        }

        if ($("#lbl_Tot_Fonasa_Modal_2").val() == "") {
            $("#lbl_Tot_Fonasa_Modal_2").val(0);
            tp222 = parseInt(0);
        } else {
            tp222 = parseInt(tp222);
        }

        if ((tp111 + tp222) == parseInt(GLOBAL_TOT_FONASA)) {
            $("#lbl_Tot_Fonasa_Modal").css({
                "border-color": "#ccc"
            });
            $("#lbl_Tot_Fonasa_Modal").parent().css({
                "color": "#212529"
            });

            $("#lbl_Tot_Fonasa_Modal_2").css({
                "border-color": "#ccc"
            });
            $("#lbl_Tot_Fonasa_Modal_2").parent().css({
                "color": "#212529"
            });

        } else {
            $("#lbl_Tot_Fonasa_Modal").css({
                "border-color": "red"
            });
            $("#lbl_Tot_Fonasa_Modal").parent().css({
                "color": "red"
            });

            $("#lbl_Tot_Fonasa_Modal_2").css({
                "border-color": "red"
            });
            $("#lbl_Tot_Fonasa_Modal_2").parent().css({
                "color": "red"
            });
        }

    });

    //--------------------------- PARA PARTICULARES -------------

    $("#lbl_Tot_Pagar_Insumos_Particul_Modal, #lbl_Tot_Fonasa_Modal_2_Parti").keyup(() => {
        let tp11_parti = $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val();
        let tp22_parti = $("#lbl_Tot_Fonasa_Modal_2_Parti").val();

        let JJJHHHUUUU = $("#Lbl_tot_copa_particular").val();
        JJJHHHUUUU = JJJHHHUUUU.replace(".", "");
        JJJHHHUUUU = parseInt(JJJHHHUUUU);

        tp111_parti = tp11_parti.replace(".", "");
        $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val(addCommas(tp111_parti));

        tp222_parti = tp22_parti.replace(".", "");
        $("#lbl_Tot_Fonasa_Modal_2_Parti").val(addCommas(tp222_parti));

        if ($("#lbl_Tot_Pagar_Insumos_Particul_Modal").val() == "") {
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val(0);
            tp111_parti = parseInt(0);
        } else {
            tp111_parti = parseInt(tp111_parti);
        }

        if ($("#lbl_Tot_Fonasa_Modal_2_Parti").val() == "") {
            $("#lbl_Tot_Fonasa_Modal_2_Parti").val(0);
            tp222_parti = parseInt(0);
        } else {
            tp222_parti = parseInt(tp222_parti);
        }

        if ((tp111_parti + tp222_parti) == parseInt(JJJHHHUUUU)) {
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").css({
                "border-color": "#ccc"
            });
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").parent().css({
                "color": "#212529"
            });

            $("#lbl_Tot_Fonasa_Modal_2_Parti").css({
                "border-color": "#ccc"
            });
            $("#lbl_Tot_Fonasa_Modal_2_Parti").parent().css({
                "color": "#212529"
            });

        } else {
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").css({
                "border-color": "red"
            });
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").parent().css({
                "color": "red"
            });

            $("#lbl_Tot_Fonasa_Modal_2_Parti").css({
                "border-color": "red"
            });
            $("#lbl_Tot_Fonasa_Modal_2_Parti").parent().css({
                "color": "red"
            });
        }

    });


    //$("#lbl_Tot_Fonasa_Modal_2").keyup(() => {
    //    let tp22 = $("#lbl_Tot_Fonasa_Modal_2").val();
    //    tp222 = tp22.replace(".", "");
    //    $("#lbl_Tot_Fonasa_Modal_2").val(addCommas(tp222));

    //    if ($("#lbl_Tot_Fonasa_Modal_2").val() == "") {
    //        $("#lbl_Tot_Fonasa_Modal_2").val(0);
    //        tp222 = 0;
    //    } else {
    //        tp222 = parseInt(tp222);
    //    }
    //});

    $("#lbl_Tot_Pagar_Insumos_Particul_Modal").keyup(() => {
        let tp11_Parti = $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val();
        tp111_Parti = tp11_Parti.replace(".", "");
        $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val(addCommas(tp111_Parti));
        if ($("#lbl_Tot_Pagar_Insumos_Particul_Modal").val() == "") {
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val(0);
            tp111_Parti = 0;
        } else {

        }
    });

    $("#lbl_Tot_Fonasa_Modal_2_Parti").keyup(() => {
        let tp22_Parti = $("#lbl_Tot_Fonasa_Modal_2_Parti").val();
        tp222_Parti = tp22_Parti.replace(".", "");
        $("#lbl_Tot_Fonasa_Modal_2_Parti").val(addCommas(tp222_Parti));

        if ($("#lbl_Tot_Fonasa_Modal_2_Parti").val() == "") {
            $("#lbl_Tot_Fonasa_Modal_2_Parti").val(0);
            tp222_Parti = 0;
        } else {

        }
    });

    $("#lbl_Tot_Fonasa_Modal_2").click(() => {
        if ($("#lbl_Tot_Fonasa_Modal_2").val() == "0") {
            $("#lbl_Tot_Fonasa_Modal_2").val("");
        } else {

        }
    });

    $("#lbl_Tot_Fonasa_Modal_2").focusout(() => {
        if ($("#lbl_Tot_Fonasa_Modal_2").val() == "") {
            $("#lbl_Tot_Fonasa_Modal_2").val("0");
            tp222 = 0;
        } else {

        }
    });

    $("#lbl_Tot_Fonasa_Modal_2_Parti").click(() => {
        if ($("#lbl_Tot_Fonasa_Modal_2_Parti").val() == "0") {
            $("#lbl_Tot_Fonasa_Modal_2_Parti").val("");
        } else {

        }
    });

    $("#lbl_Tot_Fonasa_Modal_2_Parti").focusout(() => {
        if ($("#lbl_Tot_Fonasa_Modal_2_Parti").val() == "") {
            $("#lbl_Tot_Fonasa_Modal_2_Parti").val("0");
            tp222_Parti = 0;
        } else {

        }
    });

    $("#Btn_Print").attr("disabled", true);
    $("#dni").hide();
    $("#Naten").hide();
    if ($('#XXXXXXXX').length) {
        var scrollTrigger = 100, // px
            backToTop = function () {
                var scrollTop = $(window).scrollTop();
                if (scrollTop > scrollTrigger && $("#Nom").val() != "") {
                    if (checked_rdn == 0) {
                        $("#xxx_xxx").text("Rut: " + $("#rut").val() + " Nombre: " + $("#Nom").val() + " " + $("#Ape").val() + " Edad: " + $("#Edad").val() + " Sexo: " + $("#sex option:selected").text())
                    } else {
                        $("#xxx_xxx").text("D.N.I: " + $("#dni").val() + " Nombre: " + $("#Nom").val() + " " + $("#Ape").val() + " Edad: " + $("#Edad").val() + " Sexo: " + $("#sex option:selected").text())
                    }

                    $('#XXXXXXXX').addClass('show');
                } else {
                    $('#XXXXXXXX').removeClass('show');
                }
            };
        backToTop();
        $(window).on('scroll', function () {
            backToTop();
        });
    }
    $("#titulooo").text("Exámenes Tomados el " + moment().format("DD/MM/YYYY"));
    await fn_Req_Ciud();
    await fn_Req_Comuna();
    await Ajax_DL_SEXO();
    await Ajax_DL_NAC();
    await Ajax_DL_prevision();
    await Ajax_Diagnostico();
    await fn_Req_Pago();
    //Ajax_Ciudad();
    //$("#Cuidad").change(function () {
    //    Ajax_Comuna();
    //});

    //$("#button_modal_pago").click(function () {


    //    if (Mx_Dt023.length != 0) {

    //        objAJAX_Atenc.callback([
    //             Mx_Dt023.ID_Atencion
    //        ]);
    //    }
    //});

    let rt = getParameterByName("Rt");
    let di = getParameterByName("Di");
    if (rt != "NONE") {
        $("#rut").val(rt);
        var obj_RUT2 = Valid_RUT($("#rut").val());
        $("#rut").val(obj_RUT2.Format);

        Ajax_modal_exa_RUT();
    } else {
        $("#checkBox999").prop('checked', false);
        $("#checkBox8887").prop('checked', false);
        $("#rut").hide();
        $("#dni").show();
        $("#Naten").hide();
        $("#dni").val(di);
        Ajax_modal_exa_DNI();
    }

    $("#Procedencia").change(function () {
        Ajax_DataTable();
    });
    //$("#Div_Tabla").hide();


    // Call_AJAX_Ddl();
    //Ajax_DL_programa();
    //Ajax_DL_sec();
    //Ajax_DL_TP_ATE();
    //Ajax_DL_orden_ate();
    //Ajax_DL_DOC();
    $("#checkBox2").prop('checked', false);//solo los del objeto
    $("#checkBox999").prop('checked', true);
    $("#checkBox999").change(function () {
        if ($(this).is(':checked')) {
            $("#checkBox888").prop('checked', false);
            $("#checkBox8887").prop('checked', false);
            $("#rut").show();
            $("#dni").hide();
            $("#Naten").hide();
        }
    });
    $("#checkBox888").change(function () {
        if ($(this).is(':checked')) {
            $("#checkBox999").prop('checked', false);
            $("#checkBox8887").prop('checked', false);
            $("#rut").hide();
            $("#dni").show();
            $("#Naten").hide();
        }
    });
    $("#checkBox8887").change(function () {
        if ($(this).is(':checked')) {
            $("#checkBox999").prop('checked', false);
            $("#checkBox888").prop('checked', false);
            $("#rut").hide();
            $("#dni").hide();
            $("#Naten").show();
        }
    });

    $("#agregar_op").click(function () {

        buscar_omi_nuevo_folio();



    });

    $('#FUR').attr("disabled", true);

    $('#checkBox2').attr("disabled", true);

    $("#fur").css("pointer-events", "none");
    var f = moment().format("YYYY-MM-DD");
    $("#fecha").val(f);
    $("#FUR").val(f);


    /////-*-*-*-*-*-*-*-*-*-*-*-*-*
    $("<table>", {
        "id": "DataTable_pac2",
        "class": "display",
        "width": "100%",
        "cellspacing": "0"
    }).appendTo("#Div_Tabla3");

    $("#DataTable_pac2").append(
        $("<thead>"),
        $("<tbody>")
    );
    $("#DataTable_pac2").attr("class", "table table-hover table-striped table-iris");
    $("#DataTable_pac2 thead").attr("class", "cabzera");
    $("#DataTable_pac2 thead").append(
        $("<tr>").append(
            $("<th>", { "class": "textoReducido" }).text("Codigo Fonasa"),
            $("<th>", { "class": "textoReducido" }).text("Descripcion"),
            //$("<th>", { "class": "textoReducido" }).text("Previsión"),
            //$("<th>", { "class": "textoReducido", hidden: true }).text("Tipo Pago"),
            //$("<th>", { "class": "textoReducido text-center", hidden: true }).text("Días Proceso"),
            //$("<th>", { "class": "textoReducido text-center", hidden: true }).text("Obs. Examen"),
            //$("<th>", { "class": "textoReducido text-center", hidden: true }).text("N° de Folio de Bono"),
            //$("<th>", { "class": "textoReducido text-center", hidden: true }).text("S. Complementario"),
            //$("<th>", { "class": "textoReducido text-center", hidden: true }).text("Total Fonasa"),
            //$("<th>", { "class": "textoReducido text-center", hidden: true }).text("Bonificación"),
            //$("<th>", { "class": "textoReducido text-center", hidden: true }).text("Valor a Pagar"),
            $("<th>", { "class": "textoReducido" }).text(""),
            $("<th>", { "class": "textoReducido" }).text("Cambio de Estado")
        )
    );
    add_row();


    //-*-*-*-*-*-*-*-*-*-*-*-*-*
    $("#Btnnew").on("click", async function () {
        await Ajax_DL_SEXO();
        await Ajax_DL_NAC();
        await Ajax_Ciudad();
        $("#checkBox2").prop('checked', false);
        $('#FUR').attr("disabled", true);
        $('#checkBox2').attr("disabled", true);
        $("#fur").css("pointer-events", "none");
        var f = moment().format("DD-MM-YYYY");
        $("#fecha").val(f);
        $("#fecha2").val(f);
        $("#FUR").val(f);
        $('#rut').removeAttr("disabled");
        $('#rut').val("");
        $('#dni').removeAttr("disabled");
        $('#dni').val("");
        $("#Nom").val("");
        $("#Interno").val("");
        $("#Ape").val("");
        $("#Edad").val("");
        $("#telfijo").val("");
        $("#Celular").val("");
        $("#Email").val("");
        $("#direccion").val("");
        Mx_Dtt_examcof.length = 0;
        $("#DataTable_pac2 tbody").empty();
        add_row();
        verrut = 0;
        Mx_Dtt2.length = 0;
        var str_Error = "Campos listo para el ingreso del nuevo paciente: "
        $("#title").text("Nuevo Paciente");
        $("#button_modal").attr("class", "btn btn-success");
        $("#mError_AAH p").text(str_Error);
        $("#mError_AAH").modal();
    });
    $("#fecha").change(function () {
        var asd = moment($("#fecha").val()).format("DD-MM-YYYY");



        var array = asd.split("-");
        var total = "";
        var dia = array[0];
        var mes = array[1];
        var ano = array[2];
        if (dia < 10) { dia = "0" + dia; }
        if (mes < 10) { mes = "0" + mes; }
        // cogemos los valores actuales
        var fecha_hoy = new Date();
        var ahora_ano = fecha_hoy.getYear();
        var ahora_mes = fecha_hoy.getMonth() + 1;
        var ahora_dia = fecha_hoy.getDate();

        // realizamos el calculo
        var edad = (ahora_ano + 1900) - ano;
        if (ahora_mes < mes) {
            edad--;
        }
        if ((mes == ahora_mes) && (ahora_dia < dia)) {
            edad--;
        }
        if (edad > 1900) {
            edad -= 1900;
        }
        // calculamos los meses
        var meses = 0;
        if (ahora_mes > mes)
            meses = ahora_mes - mes;
        if (ahora_mes < mes)
            meses = 12 - (mes - ahora_mes);
        if (ahora_mes == mes && dia > ahora_dia)
            meses = 11;
        // calculamos los dias
        var dias = 0;
        total = String(edad + " Años " + meses + " meses " + dias + " dia");
        if (ahora_dia > dia) {
            dias = ahora_dia - dia;
            total = String(edad + " Años " + meses + " meses " + dias + " dia");
        }
        if (ahora_dia < dia) {
            ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
            dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
            total = String(edad + " Años " + meses + " meses " + dias + " dia");
        }
        $("#Edad").val(total);

    });
    $("#sex").change(function () {
        var sex = $("#sex option:selected").text();
        if (sex == "Femenino") {
            $('#checkBox2').removeAttr("disabled");
            var HXH = 0;
            for (let x = 0; x < Mx_Dtt_examcof.length; x++) {
                if (Mx_Dtt_examcof[x].ID_CODIGO_FONASA == 1054) {
                    HXH = 1;
                }
            }
            if (HXH == 1 && $("#sex").val() == 2 && sifi == 0) {
                var str_Error = "Por favor Rellenar el campo F.U.R"
                $("#title").text("Recordatorio");
                $("#button_modal").attr("class", "btn btn-success");

                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();
                sifi = 1;
            }
        } else {

            $('#checkBox2').attr("disabled", true);
            $("#checkBox2").prop('checked', false);//solo los del objeto #diasHabilitados
            $('#FUR').attr("disabled", true);
            $("#fur").css("pointer-events", "none");
            $("#FUR").val(f);
        }

        if (Mx_Dtt_exam02_respaldo.length > 0) {
            if ($("#sex").val() == 2) {

                var xxxer = false;
                for (let z = 0; z < Mx_Dtt_examcof.length; z++) {

                    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 66) {
                        Mx_Dtt_examcof.splice(z, 1);
                        xxxer = true;
                    }

                }
                if (xxxer == true) {
                    for (let x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                        if (Mx_Dtt_exam02_respaldo[x].ID_CODIGO_FONASA == 1026) {
                            Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02_respaldo[x]));
                            Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                        }
                    }
                    fill_llenado_tabla()
                }

            }



            if ($("#sex").val() == 1) {

                var xxxer = false;
                for (let z = 0; z < Mx_Dtt_examcof.length; z++) {
                    //for (let x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1026) {
                        Mx_Dtt_examcof.splice(z, 1);
                        xxxer = true;
                    }
                    //}
                }
                if (xxxer == true) {
                    for (let x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                        if (Mx_Dtt_exam02_respaldo[x].ID_CODIGO_FONASA == 66) {
                            Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02_respaldo[x]));
                            Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                        }
                    }
                    fill_llenado_tabla()
                }

            }
            if ($("#sex").val() == 0) {

                var xxxer = false;
                for (let z = 0; z < Mx_Dtt_examcof.length; z++) {
                    //for (let x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1026 || Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 66) {
                        Mx_Dtt_examcof.splice(z, 1);
                        xxxer = true;
                    }
                    fill_llenado_tabla();
                    //}
                }
            }
        }
    });
    $("#dni").keydown(function EnterEvent(e) {
        if (e.keyCode == 13) {
            if ($("#dni").val() == "") {
                var str_Error = "Ingrese un D.N.I Por favor.";
                $("#mError_AAH h5").text("Error:");
                $("#button_modal").attr("class", "btn btn-danger");

                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();

                $("#rut").val("");
                $("#rut").css({
                    "border-color": "red"
                });

            } else {
                $("#dni").css({
                    "border-color": "green"
                });
                Ajax_modal_exa_DNI();
                //ESTE SI
            }
        }
    });

    $("#Naten").keydown(function EnterEvent(e) {
        if (e.keyCode == 13) {

            Ajax_modal_exa();
            //ESTE SI
        }
    });


    $("#checkBox2").change(function () {
        if ($(this).is(':checked')) {
            $("#FUR").removeAttr('disabled');
            $("#fur").css("pointer-events", "auto");
        } else {
            $('#FUR').attr("disabled", true);
            $("#fur").css("pointer-events", "none");
            $("#FUR").val(f);
        }
    });

    $("#rut").keydown(function EnterEvent(e) {
        if (e.keyCode == 13) {


            if ($("#rut").val() != "") {
                //Capturar Anáqlisis del RUT
                var obj_RUT = Valid_RUT($("#rut").val());
                if (obj_RUT.Valid == false) {
                    var str_Error = "El RUT ingresado no es Válido, ";
                    str_Error += "ingrese en el campo de texto un RUT válido.";

                    $("#mError_AAH h5").text("Error:");
                    $("#button_modal").attr("class", "btn btn-danger");
                    1
                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();

                    $("#rut").val("");
                    $("#rut").css({
                        "border-color": "red"
                    });
                } else {
                    $("#rut").css({
                        "border-color": "green"
                    });
                    $("#rut").val(obj_RUT.Format);
                    Ajax_modal_exa_RUT();
                    //ESTE SI
                }
            }
        }
    });

    $("#Prevision").change(function () {
        Mx_Dtt_exam02.length = 0;
        Ajax_DataTable_examen02();
        Ajax_DataTable_examen02_Particular();
        $("#DataTable_pac2 tbody").empty();
        add_row();
    });



    $("#BtnSaveAll").click(function () {
        console.log("click!");

        if (Mx_Dtt_examcof.length == 0) {
            $("#mError_AAH").modal('hide');
            var str_Error = "Estimado, usuario, debe agregar exámenes.";
            $("#title").text("Agregar Exámenes");
            $("#button_modal").attr("class", "btn btn-danger");

            $("#mError_AAH p").text(str_Error);
            $("#mError_AAH").modal();
        } else {
            //$('#XXXXXXXX').removeClass('XXXXXXXX');
            //$('#XXXXXXXX_2').addClass('XXXXXXXX_2');
            //$("#Ddl_Ttp_Modal").empty();
            //$("#Ddl_Ttp_Modal2").empty();                                                                             //MODAL DE INSUMOS MODAL             
            //GLOBAL_TOT_COPA_PART = 0;

            //$(`.tp_pago2`).each(function () {
            //    if (this.value == 20) {
            //        $(`.tp_pago2`).each(function () {
            //            $(`.td_valorapagar`).each(function () {
            //                GLOBAL_TOT_A_PAGAR += parseInt(this.value);
            //            });

            //        });


            //        GLOBAL_TOT_COPA_PART += parseInt(this.value);
            //    }

            //});

            //$("#Lbl_tot_copa_particular").val(GLOBAL_TOT_COPA_PART);

            //arrPago.forEach(aaa => {

            //    $("<option>", { "value": aaa.ID_TP_PAGO }).text(aaa.TP_PAGO_DESC).appendTo("#Ddl_Ttp_Modal");
            //    //$("<option>", { "value": aaa.ID_TP_PAGO }).text(aaa.TP_PAGO_DESC).appendTo("#Ddl_Ttp_Modal2");        MODAL DE INSUMOS MODAL

            //});

            //$("#Ddl_Ttp_Modal").val(1);
            //$("#Ddl_Ttp_Modal2").val(1);

            //tp111 = GLOBAL_TOT_FONASA;

            $("#lbl_Tot_Fonasa_Modal").css({
                "border-color": "#868e96"
            });
            $("#lbl_Tot_Fonasa_Modal").parent().css({
                "color": "#212529"
            });

            $("#lbl_Tot_Fonasa_Modal_2").css({
                "border-color": "#868e96"
            });
            $("#lbl_Tot_Fonasa_Modal_2").parent().css({
                "color": "#212529"
            });

            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").css({
                "border-color": "#868e96"
            });
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").parent().css({
                "color": "#212529"
            });

            $("#lbl_Tot_Fonasa_Modal_2_Parti").css({
                "border-color": "#868e96"
            });
            $("#lbl_Tot_Fonasa_Modal_2_Parti").parent().css({
                "color": "#212529"
            });

            tp111 = $("#Lbl_tot_copa_fonasa").val();
            tp111 = tp111.replace(".", "");
            GLOBAL_TOT_FONASA = parseInt(tp111);

            //$("#lbl_tot_copago").text("VALOR (Fonasa): " + addCommas(GLOBAL_TOT_FONASA));
            if (isNaN(GLOBAL_TOT_FONASA) == true || GLOBAL_TOT_FONASA == null) {
                $("#lbl_tot_copago").html("VALOR (Fonasa): " + "<strong>" + 0 + "</strong>");
            } else {
                $("#lbl_tot_copago").html("VALOR (Fonasa): " + "<strong>" + addCommas(GLOBAL_TOT_FONASA) + "</strong>");
            }


            let JJJKKKKK = $("#Lbl_tot_copa_particular").val()
            JJJKKKKK = JJJKKKKK.replace(".", "");
            JJJKKKKK = parseInt(JJJKKKKK);

            if (isNaN(JJJKKKKK) == true || JJJKKKKK == null) {
                $("#lbl_valor_parti").html("VALOR (Particular): " + "<strong>" + 0 + "</strong>")
            } else {
                $("#lbl_valor_parti").html("VALOR (Particular): " + "<strong>" + addCommas(JJJKKKKK) + "</strong>")
            }

            tp222 = 0;

            activador = 0;
            $("#divNewPaymen").hide();
            $("#agregaMedioPago").show();
            $("#spanAgregaMedioPago").show();
            //$("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_PREVISION - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));

            //$("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_PREVISION - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));
            $("#lbl_Tot_Fonasa_Modal").attr("disabled", "disabled");
            $("#lbl_Tot_Fonasa_Modal").val($("#Lbl_tot_copa_fonasa").val());

            activador_Parti = 0;
            $("#divNewPaymen_Parti").hide();
            $("#agregaMedioPago_Parti").show();
            $("#spanAgregaMedioPago_Parti").show();
            //$("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_PREVISION - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));

            //$("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_PREVISION - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));


            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val($("#Lbl_tot_copa_particular").val());
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").attr("disabled", "disabled");

            //$("#MOdal_NUEVO_SELECCION").modal();

            $("#button_modal_s_comple").click();
        }


    });

    $("#button_modal_pagoNuevoSeleccion").click(function () {                     //  <------------- BOTÓN NO CREADO
        var sum = 0;
        var falta_bon = 0;

        sum += 1;
        for (let aaa = 0; aaa < Mx_Dtt_examcof.length; aaa++) {
            if ((Mx_Dtt_examcof[aaa].ATE_DET_TP_1 == "4" || Mx_Dtt_examcof[aaa].ATE_DET_TP_1 == "5") && Mx_Dtt_examcof[aaa].ATE_DET_NUM_BONO == "") {
                console.log("enter if comprueba num bono");
                //sum -= 1;
                falta_bon = 1;
            }
        }

        //------------------------------ ACTIVADOR COPAGO --------------------------------
        if (activador == 0) {
            sum += 1;
        } else {
            let lbl_tot_guar = $("#Lbl_tot_copa_fonasa").val()
            lbl_tot_guar = lbl_tot_guar.replace(".", "");
            lbl_tot_guar = parseInt(lbl_tot_guar);


            tp111 = parseInt(tp111);
            tp222 = parseInt(tp222);

            if (lbl_tot_guar == (tp111 + tp222)) {

                $("#lbl_Tot_Fonasa_Modal").css({
                    "border-color": "#ccc"
                });
                $("#lbl_Tot_Fonasa_Modal").parent().css({
                    "color": "#212529"
                });

                $("#lbl_Tot_Fonasa_Modal_2").css({
                    "border-color": "#ccc"
                });
                $("#lbl_Tot_Fonasa_Modal_2").parent().css({
                    "color": "#212529"
                });

                sum += 1;
            } else {


                $("#lbl_Tot_Fonasa_Modal").css({
                    "border-color": "red"
                });
                $("#lbl_Tot_Fonasa_Modal").parent().css({
                    "color": "red"
                });

                $("#lbl_Tot_Fonasa_Modal_2").css({
                    "border-color": "red"
                });
                $("#lbl_Tot_Fonasa_Modal_2").parent().css({
                    "color": "red"
                });

                $("#mError_AAH").modal('hide');
                var str_Error = "Vetificar Valores";
                $("#title").text("Los valores no corresponden.");
                $("#button_modal").attr("class", "btn btn-danger");

                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();

            }

        };
        //----------------------------------- FIN ACTIVADOR --------------------------


        //--------------------------------- ACTIVADOR PARTICULAR --------------------------------
        if (activador_Parti == 0) {
            sum += 1;
        } else {
            let lbl_tot_guar_Parti = $("#Lbl_tot_copa_particular").val()
            lbl_tot_guar_Parti = lbl_tot_guar_Parti.replace(".", "");
            lbl_tot_guar_Parti = parseInt(lbl_tot_guar_Parti);

            console.log("entra al presionar guardar");
            tp111_Parti = parseInt(tp111_Parti);
            tp222_Parti = parseInt(tp222_Parti);

            var check_par_1 = $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val();
            check_par_1 = check_par_1.replace(".", "");
            check_par_1 = parseInt(check_par_1);

            check_par_2 = $("#lbl_Tot_Fonasa_Modal_2_Parti").val();
            check_par_2 = check_par_2.replace(".", "");
            check_par_2 = parseInt(check_par_2);

            if (lbl_tot_guar_Parti == (check_par_1 + check_par_2)) {
                $("#lbl_Tot_Pagar_Insumos_Particul_Modal").css({
                    "border-color": "#ccc"
                });
                $("#lbl_Tot_Pagar_Insumos_Particul_Modal").parent().css({
                    "color": "#212529"
                });

                $("#lbl_Tot_Fonasa_Modal_2_Parti").css({
                    "border-color": "#ccc"
                });
                $("#lbl_Tot_Fonasa_Modal_2_Parti").parent().css({
                    "color": "#212529"
                });

                sum += 1;
            } else {

                $("#lbl_Tot_Pagar_Insumos_Particul_Modal").css({
                    "border-color": "red"
                });
                $("#lbl_Tot_Pagar_Insumos_Particul_Modal").parent().css({
                    "color": "red"
                });

                $("#lbl_Tot_Fonasa_Modal_2_Parti").css({
                    "border-color": "red"
                });
                $("#lbl_Tot_Fonasa_Modal_2_Parti").parent().css({
                    "color": "red"
                });

                $("#mError_AAH").modal('hide');
                var str_Error = "Vetificar Valores";
                $("#title").text("Los valores no corresponden al TOTAL PARTICULAR.");
                $("#button_modal").attr("class", "btn btn-danger");

                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();



            }

        };

        if (PASS_SAVE == 1) {
            sum += 1;
        } else {

        }



        //----------------------------------- FIN ACTIVADOR PARTICULAR --------------------------
        console.log("sum: " + sum);
        if (sum == 4) {

            if ($("#rut").val() == "") {
                verrut = 2;
            }

            if ($("#Lbl_tot_beneficiario").val() == 0 || $("#Lbl_tot_beneficiario").val() == "0") {
                $("#mError_AAH2").modal('hide');

                $("#mError_AAH2").modal();
                $('#XXXXXXXX').removeClass('show');

            } else {
                Ajax_guardar();
            }

        } else {
            if (falta_bon == 100000) { //debe ser == 1
                $("#mError_AAH").modal('hide');
                var str_Error = "Debe ingresar N° de bono en caso de tipo de pago BONO o BONO ELECTRÓNICO.";
                $("#title").text("Número de bono");
                $("#button_modal").attr("class", "btn btn-danger");

                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();
                $('#XXXXXXXX').removeClass('show');

                $('body, html').animate({
                    scrollTop: '0px'
                }, 300);

            } else {
                $("#mError_AAH").modal('hide');
                var str_Error = "Por favor llenar los campos marcados con color rojo.";
                $("#title").text("Faltan campos por llenar");
                $("#button_modal").attr("class", "btn btn-danger");

                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();
                $('#XXXXXXXX').removeClass('show');

                $('body, html').animate({
                    scrollTop: '0px'
                }, 300);
            }
        }
    });

    //-*-*-*-*-*-*-*-*-* TABLA DINAMICA -*-*-*-*-*-*-*-*-*-*-*
    $("#Examen").click(function () {

        if (Mx_Detalle_ate.proparra3[0].ID_PREVE == 0) {
            $("#title").text("Estimado Usuario");
            $("#button_modal").attr("class", "btn btn-danger");
            $("#mError_AAH p").text("Primero, debe cargar información de paciente.");
            $("#mError_AAH").modal();
        }
        else {
            Fill_DataTable_exam02();
            Ajax_DataTable_examen02_Particular();
            $('#eModal2').modal('show');
        }

    });



    ///llenado tabla con modal  a  atabla principal
    $("#btnguardar").click(function () {

        $("#DataTable_pac_filter input").val("").trigger("input");
        console.log("btnguardar click!");

        selected = new Array();

        var rem_glu = 0;
        var rem_ivy = 0;

        selected = new Array();
        $(".pp input:checkbox:checked").each(function () {
            selected.push($(this).val());
        });
        for (let z = 0; z < Mx_Dtt_examcof.length; z++) {
            for (let x = 0; x < selected.length; x++) {
                if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == selected[x]) {
                    selected.splice(x, 1);
                }
            }
        }
        for (let i = 0; i < selected.length; i++) {
            for (let x = 0; x < Mx_Dtt_exam02.length; x++) {
                if (selected[i] == Mx_Dtt_exam02[x].ID_CODIGO_FONASA) {




                    Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02[x]));
                    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                }
            }
        }

        console.log(Mx_Dtt_examcof[0].CF_PART_TIPO);

        for (let rrr = 0; rrr < Mx_Dtt_examcof.length; rrr++) {

            if (Mx_Dtt_examcof[rrr].CF_PART_TIPO != null && Mx_Dtt_examcof[rrr].CF_PART_TIPO != 0 && Mx_Dtt_examcof[rrr].CF_PART_TIPO != "") {
                Mx_Dtt_examcof[rrr]["CF_TP_PAGO"] = 20;
                Mx_Dtt_examcof[rrr]["ATE_DET_TP_1"] = 20;

                for (let x = 0; x < Mx_Dtt_exam02_Particular.length; x++) {
                    if (Mx_Dtt_exam02_Particular[x].ID_CODIGO_FONASA == Mx_Dtt_examcof[rrr].ID_CODIGO_FONASA) {
                        Mx_Dtt_examcof[rrr].CF_PRECIO_AMB = Mx_Dtt_exam02_Particular[x].CF_PRECIO_AMB;
                        Mx_Dtt_examcof[rrr].CF_BONIFICACION = 0;
                    }
                }
                console.log("PARTICULAR");
            } else {
                console.log("NO particular");
            }
        }
        acti_cf_part = 0;

        fill_llenado_tabla();
        $('#eModal2').modal('hide');
    });


    $("#btnexarepetido").click(function () {
        selected = new Array();
        $(".sub_pp input:checkbox:checked").each(function () {
            selected.push($(this).val());
        });
        for (let z = 0; z < Mx_Dtt_examcof.length; z++) {
            for (let x = 0; x < selected.length; x++) {
                if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == selected[x]) {
                    selected.splice(x, 1);
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        if (cod_or_desc == 1) {
            for (let i = 0; i < selected.length; i++) {
                for (let x = 0; x < Mx_Dtt_exam03.length; x++) {
                    if (selected[i] == Mx_Dtt_exam03[x].ID_CODIGO_FONASA) {
                        Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam03[x]));
                        Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                    }
                }
            }
        } else if (cod_or_desc == 2) {
            for (let i = 0; i < selected.length; i++) {
                for (let x = 0; x < Mx_Dtt_exam03_Desc.length; x++) {
                    if (selected[i] == Mx_Dtt_exam03_Desc[x].ID_CODIGO_FONASA) {
                        Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam03_Desc[x]));
                        Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                    }
                }
            }
        }


        if (xId != 0) {
            for (let z = 0; z < Mx_Dtt_examcof.length; z++) {
                if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == xId) {
                    Mx_Dtt_examcof.splice(z, 1);
                }
            }
        }
        fill_llenado_tabla();
        $('#eModal3').modal('hide');
    });

    $(document).on('click', '.borrar', function (event) {
        var rowstota = document.getElementById("DataTable_pac2").rows.length;
        var ff = $(this).parent().parent().children().children('.td_input').attr('data-id');
        event.preventDefault();
        if (rowstota > 2) {
            for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
                if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == ff) {
                    Mx_Dtt_examcof.splice(i, 1);
                }
                $(this).closest('tr').remove();
                for (let x = 0; x < Mx_Dtt_examcof.length; x++) {
                    if (Mx_Dtt_examcof[x].ID_CODIGO_FONASA == 1054) {
                        sifi = 1;
                    } else {
                        sifi = 0;
                    }
                }
            }
            HOLAAAAAAAAAAA();
        } else {
            var str_Error = "El campo no puede ser eliminado"
            $("#title").text("Eliminar Examen");
            $("#button_modal").attr("class", "btn btn-danger");

            $("#mError_AAH p").text(str_Error);
            $("#mError_AAH").modal();
            $('#XXXXXXXX').removeClass('show');
        }
    });


    $(document).on('click', '.borrar2', function EnterEvent(event) {
        event.stopImmediatePropagation();

        var rowstota = document.getElementById("DataTable_pac73").rows.length;
        var ff = $(this).parent().attr('data-id-elim');
        var indi = $(this).parent().parent().attr('data-index');

        cod_fo_eli = ff;
        fila_eli = indi;

        event.preventDefault();

        if (rowstota > 1) {
            $("#Modal_Eliminar").modal("show");
            //Eliminar_Examen(ff, indi);

        } else {
            var str_Error = "El campo no puede ser eliminado"
            $("#title").text("Eliminar Examen");
            $("#button_modal").attr("class", "btn btn-danger");

            $("#mError_AAH p").text(str_Error);
            $("#mError_AAH").modal();
            //$('#XXXXXXXX').removeClass('show');
        }
    });

    $(document).on('click', '.CEstado', function (event) {
        //var rowstota = document.getElementById("DataTable_pac2").rows.length;
        var ff = $(this).parent().parent().children().children('.td_input').attr('data-id');
        event.preventDefault();

        for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
            if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == ff) {

                Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN = "Espera"

            }
        }

        fill_llenado_tabla();

    });
    $(document).on('click', '.Activado', function (event) {
        //var rowstota = document.getElementById("DataTable_pac2").rows.length;
        var ff = $(this).parent().parent().children().children('.td_input').attr('data-id');
        event.preventDefault();

        for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
            if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == ff) {

                Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN = "Activo"

            }
        }

        fill_llenado_tabla();

    });
});
//-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*



var Mx_Eliminar = [
    {
        "N_OMI": 0,
        "RUT_PACIENTE": 0,
        "NOMBRE_PACIENTE": 0,
        "APELLIDO_PACIENTE": 0,
        "SEXO_PACIENTE": 0,
        "FECHA_NAC_PACIENTE": 0,
        "DIRECCION": 0,
        "COD_EXA_INTERNO": 0,
        "NOMBRE_EXAMEN": 0,
        "COD_EXA_HOMO": 0,
        "OBSERVACIONES": 0,
        "RUT_MEDICO ": 0,
        "NOMBRE": 0,
        "APELLIDO_MEDICO": 0
    }
];
function Eliminar_Examen(aidi_codi_fonisi, index) {
    modal_show();
    var Data_Par = JSON.stringify({
        "ID_ATENCION": Mx_Detalle_ate.proparra1[0].ID_PREINGRESO,
        "ID_CODIGO_FONASA": aidi_codi_fonisi,
        "S_Id_User": Galletas.getGalleta("ID_USER")
    });
    $.ajax({
        "type": "POST",
        "url": "AGRE_EXA_ATE_NORMAL.aspx/Eliminar_Examen",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {

                cod_fo_eli = 0;
                fila_eli = 0;
                $("#Modal_Eliminar").modal("hide");
                $(`#DataTable_pac73 tbody tr[data-index =${index}]`).remove();
                console.log("aidi_codi_fonisi: " + aidi_codi_fonisi);

                for (let x = 0; x < exa_actuales_xd.length; x++) {
                    console.log("exa_actuales_xd[x].ID_CODIGO_FONASA: " + exa_actuales_xd[x].ID_CODIGO_FONASA);
                    if (aidi_codi_fonisi == exa_actuales_xd[x].ID_CODIGO_FONASA) {
                        console.log("yep, it deletes");
                        exa_actuales_xd.splice(x, 1);
                    }
                }
                Hide_Modal();

            } else {
                $("#Modal_Eliminar").modal("hide");
                cod_fo_eli = 0;
                fila_eli = 0;
                Hide_Modal();
                $("#mError_AAH").modal('hide');
                var str_Error = "No se ha podido eliminar el examen";
                $("#title").text("Examen no eliminado");
                $("#button_modal").attr("class", "btn btn-danger");

                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();

                $('#XXXXXXXX').removeClass('show');
                verrut = 0;
                MX_HO_ExamenCodigo.length = 0;

            }

        },
        "error": function (response) {
            $("#Modal_Eliminar").modal("hide");
            cod_fo_eli = 0;
            fila_eli = 0;
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
}

var Mx_OMI = [
    {
        "N_OMI": 0,
        "RUT_PACIENTE": 0,
        "NOMBRE_PACIENTE": 0,
        "APELLIDO_PACIENTE": 0,
        "SEXO_PACIENTE": 0,
        "FECHA_NAC_PACIENTE": 0,
        "DIRECCION": 0,
        "COD_EXA_INTERNO": 0,
        "NOMBRE_EXAMEN": 0,
        "COD_EXA_HOMO": 0,
        "OBSERVACIONES": 0,
        "RUT_MEDICO ": 0,
        "NOMBRE": 0,
        "APELLIDO_MEDICO": 0
    }
];
function buscar_omi_nuevo_folio() {
    modal_show();
    var Data_Par = JSON.stringify({
        "AVIS": $("#Avis").val()
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Omi.aspx/Llenar_AVIS",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_OMI = JSON.parse(json_receiver);
                cod_fo_eli = 0;
                fila_eli = 0;
                var obj_RUT = Valid_RUT(Mx_OMI[0].RUT_PACIENTE);
                if (obj_RUT.Format != Mx_Detalle_ate.proparra1[0].PAC_RUT) {
                    Hide_Modal();
                    $("#mError_AAH").modal('hide');
                    var str_Error = "El N° ingresado no pertenece al paciente OMI";
                    $("#title").text("N° OMI:");
                    $("#button_modal").attr("class", "btn btn-danger");

                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();

                    $('#XXXXXXXX').removeClass('show');
                    $("#Avis").val("");
                    $("#Avis").val(omi_save);
                    agregar_folio = 0;
                } else {
                    cod_fo_eli = 0;
                    fila_eli = 0;
                    agregar_folio = 0;
                    Fill_DL_OMI();
                    $("#Btn_Print").removeAttr("disabled");
                }
                Hide_Modal();
                //verrut = 1;



            } else {


                Hide_Modal();
                $("#mError_AAH").modal('hide');
                var str_Error = "El N° ingresado no pertenece a un paciente OMI";
                $("#title").text("N° OMI no encontrado :");
                $("#button_modal").attr("class", "btn btn-danger");

                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();

                $('#XXXXXXXX').removeClass('show');
                verrut = 0;
                MX_HO_ExamenCodigo.length = 0;
            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
}

var arrPago = [{
    "ID_TP_PAGO": 0,
    "TP_PAGO_DESC": "",
    "TP_PAGO_ING": "",
    "ID_ESTADO": 0
}];
async function fn_Req_Pago() {
    objAJAX_Prev = await $.ajax({
        "type": "POST",
        "url": "AGRE_EXA_ATE_NORMAL.aspx/tipo_pago",          //"2do PA, que excluye el Tp pago efecto, y mantiene "particular"
        //"data": objParam,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": (resp) => {
            arrPago = resp.d;
        },
        "error": (fail) => {

        }
    });
};

function Fill_DL_OMI() {

    //MX_HO_ExamenCodigo.length = 0;
    //for (let x = 0; x < MX_HO_ExamenCodigo.length; x++) {
    //    switch (x) {
    //        case 0:
    //            var objId = {
    //                "Examen": MX_HO_ExamenCodigo[x].COD_EXA_INTERNO,
    //                "HO_CC": MX_HO_ExamenCodigo[x].N_OMI,
    //                "CF_MULTIPLICADOS": ""
    //            };
    //            MX_HO_ExamenCodigo.push(fnClone(objId));
    //            break;
    //        default:
    //            if (MX_HO_ExamenCodigo[x].COD_EXA_INTERNO != MX_HO_ExamenCodigo[x - 1].COD_EXA_INTERNO) {
    //                var objId = {
    //                    "Examen": MX_HO_ExamenCodigo[x].COD_EXA_INTERNO,
    //                    "HO_CC": MX_HO_ExamenCodigo[x].N_OMI,
    //                    "CF_MULTIPLICADOS": ""
    //                };
    //                MX_HO_ExamenCodigo.push(fnClone(objId));
    //            }
    //    }
    //}
    //var ftler = Array();
    //var hash = {};
    //MX_HO_ExamenCodigo = MX_HO_ExamenCodigo.filter(function (current) {
    //    var exists = !hash[current.Examen] || false;
    //    hash[current.Examen] = true;
    //    return exists;
    //});
    //for (let x = 0; x < MX_HO_ExamenCodigo.length; x++) {
    //    for (let y = 0; y < ftler.length; y++) {
    //        if (MX_HO_ExamenCodigo[x].Examen == ftler[y].Examen) {
    //            if (MX_HO_ExamenCodigo[x].HO_CC < ftler[y].HO_CC) {
    //                MX_HO_ExamenCodigo.splice(x, 1);
    //            }
    //        }
    //    }
    //}
    //console.log(JSON.stringify(MX_HO_ExamenCodigo));

    //for (let x = 0; x < MX_HO_ExamenCodigo.length; x++) {
    //    for (let i = 0; i < Mx_AVIS.length; i++) {

    //        if (MX_HO_ExamenCodigo[x].HO_CC != Mx_AVIS[i].N_OMI && MX_HO_ExamenCodigo[x].Examen == Mx_AVIS[i].COD_EXA_INTERNO) {

    //            if (MX_HO_ExamenCodigo[x].CF_MULTIPLICADOS == "") {
    //                MX_HO_ExamenCodigo[x].CF_MULTIPLICADOS = MX_HO_ExamenCodigo[x].HO_CC + "|" + Mx_AVIS[i].N_OMI + "|";
    //            } else {
    //                MX_HO_ExamenCodigo[x].CF_MULTIPLICADOS = `${MX_HO_ExamenCodigo[x]["CF_MULTIPLICADOS"]}${Mx_AVIS[i].N_OMI}|`;
    //            }
    //        }

    //    }
    //}
    for (let x = 0; x < Mx_OMI.length; x++) {
        switch (x) {
            case 0:
                var objId = {
                    "Examen": Mx_OMI[x].COD_EXA_INTERNO,
                    "HO_CC": Mx_OMI[x].N_OMI
                };
                MX_HO_ExamenCodigo.push(fnClone(objId));
                break;
            default:
                if (Mx_OMI[x].COD_EXA_INTERNO != Mx_OMI[x - 1].COD_EXA_INTERNO) {
                    var objId = {
                        "Examen": Mx_OMI[x].COD_EXA_INTERNO,
                        "HO_CC": Mx_OMI[x].N_OMI
                    };
                    MX_HO_ExamenCodigo.push(fnClone(objId));
                }
        }
    }

    var ftler = Array();
    var hash = {};
    MX_HO_ExamenCodigo = MX_HO_ExamenCodigo.filter(function (current) {
        var exists = !hash[current.Examen] || false;
        hash[current.Examen] = true;
        return exists;
    });
    for (let x = 0; x < MX_HO_ExamenCodigo.length; x++) {
        for (let y = 0; y < ftler.length; y++) {
            if (MX_HO_ExamenCodigo[x].Examen == ftler[y].Examen) {
                if (MX_HO_ExamenCodigo[x].HO_CC < ftler[y].HO_CC) {
                    MX_HO_ExamenCodigo.splice(x, 1);
                }
            }
        }
    }
    Ajax_Examens_OMI();
}

var Mx_examenes_OMI = [
    {
        "ID_CODIGO_FONASA": 0,
        "CF_COD": "asdf",
        "CF_DESC": "asdf",
        "ID_ESTADO": 0,
        "CF_AVIS": 0,
    }
];
function Ajax_Examens_OMI() {


    var Data_Par = JSON.stringify({
        "examenes": MX_HO_ExamenCodigo
    });
    $.ajax({
        "type": "POST",
        "url": "AGRE_EXA_ATE_NORMAL.aspx/IRIS_WEBF_BUSCA_examenes_paciente",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_examenes_OMI = JSON.parse(json_receiver);

                let bFound = false;
                let xi = 0;

                for (let reee in Mx_examenes_OMI) {
                    bFound = false;

                    for (let ii in Mx_Dtt_examcof) {
                        if (Mx_examenes_OMI[reee].ID_CODIGO_FONASA == Mx_Dtt_examcof[ii].ID_CODIGO_FONASA) {
                            bFound = true;
                            xi = ii;
                            break;
                        }
                    }

                    if (bFound == true) {
                        let ID_SQL = parseInt(Mx_examenes_OMI[reee].HO_CC);
                        let ID_TAB = parseInt(Mx_Dtt_examcof[xi].HO_CC);

                        if (ID_SQL > ID_TAB) {
                            Mx_Dtt_examcof[xi] = fnClone(Mx_examenes_OMI[reee]);
                            Mx_Dtt_examcof[xi]["CF_ESTADO_EXAMEN"] = "Activo";

                            if (Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] == undefined) {
                                Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] = ID_SQL + "|"
                            }
                            Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] = `${Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"]}${ID_TAB}|`;
                        } else {
                            if (Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] == undefined) {
                                Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] = ID_TAB + "|"
                            }
                            Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] = `${Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"]}${ID_SQL}|`;
                        }
                    } else {
                        Mx_Dtt_examcof.push(fnClone(Mx_examenes_OMI[reee]));
                        Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo";

                    }

                }

                fill_llenado_tabla();
                Hide_Modal();
            } else {

            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            alert("Error", str_Error);


        }
    });
}
//--------------------------------------- JASON DIAGNOSTICO --------------------------------------------------------------------|
var Mx_Diagnostico = [
    {
        "ID_DIAGNOSTICO": 0,
        "DIA_COD": 0,
        "DIA_DESC": 0,
        "ID_ESTADO": 0
    }
];

async function Ajax_Diagnostico() {



    await  $.ajax({
        "type": "POST",
        "url": "IN_PAC_AVIS.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Diagnostico = JSON.parse(json_receiver);
                Fill_Ddl_diagnostico();
                $(".block_wait").hide();


            } else {


            }
        },
        "error": function (response) {


        }
    });
}


var Mx_Detalle_ate = {
    "proparra1": [{
        "ID_PREINGRESO": 0,
        "PREI_NUM": 0,
        "PREI_FECHA": 0,
        "PREI_FUR": 0,
        "PREI_OBS_FICHA": 0,
        "PREI_AÑO": 0,
        "PREI_OBS_TM": 0,
        "PAC_NOMBRE": 0,
        "SEXO_DESC": 0,
        "PAC_APELLIDO ": 0,
        "PAC_FNAC": 0,
        "PAC_DIR": 0,
        "PAC_FONO1": 0,
        "PAC_MOVIL1": 0,
        "PAC_EMAIL": 0,
        "PAC_OBS_PERMA": 0,
        "NAC_DESC": 0,
        "CIU_DESC": 0,
        "COM_DESC": 0,
        "ID_PACIENTE": 0,
        "PAC_RUT": 0,
        "DNI": 0,
        "id_Nacionalidad": 0

    }],
    "proparra2": [{
        "ID_PREINGRESO": 0,
        "ID_DET_PREI": 0,
        "ID_CODIGO_FONASA": 0,
        "CF_COD": 0,
        "CF_DESC": 0,
        "ID_ESTADO": 0,
        "PREI_DET_V_PREVI": 0,
        "PREI_DET_V_PAGADO": 0,
        "PREI_DET_V_COPAGO": 0,
        "PREI_DET_DOC": 0,
        "ID_TP_PAGO": 0,
        "TP_PAGO_DESC": 0,
        "CF_DIAS": 0,
        "ID_PER": 0,
        "ATE_NUM_AVIS": 0
    }],
    "proparra3": [{
        "DOC_NOMBRE": 0,
        "DOC_APELLIDO": 0,
        "ID_PREINGRESO": 0,
        "PREI_NUM": 0,
        "TP_ATE_DESC": 0,
        "LOCAL_DESC": 0,
        "ORD_DESC": 0,
        "ID_ORDEN": 0,
        "ID_PROCEDENCIA": 0,
        "ID_DOCTOR": 0,
        "ID_PREVE": 0,
        "ID_LOCAL": 0,
        "PREI_CAMA": 0,
        "PREI_OBS_FICHA": 0,
        "PROC_DESC": 0,
        "PREVE_DESC": 0,
        "ATE_NUM_INTERNO": 0,
        "PREI_OBS_TM": "",
        "ID_ATENCION": 0,
        "VIH": "",
        "Sub_atencion": 0
    }]
}
function Ajax_modal_exa() {
    modal_show();
    Mx_Detalle_ate = 0;
    var Data_Par_modal = JSON.stringify({
        "ID": $("#Naten").val()
    });
    $.ajax({
        "type": "POST",
        "url": "AGRE_EXA_ATE_NORMAL.aspx/MODAL_PAC",
        "data": Data_Par_modal,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": Data_Par_modal_paciente => {
            //Debug
            //console.log(Data_Par_modal_paciente);
            cod_fo_eli = 0;
            fila_eli = 0;
            Mx_Detalle_ate = Data_Par_modal_paciente.d;
            //ENVIAMOS ID_ATEMCION AL MODAL
            //LLAMAMOS AL FILL MODAL
            llenarmodal();
            $("#Btn_Print").removeAttr("disabled");

            //// MOSTRAR EL MODAL
            //$('#eModales33').modal('show');
        },
        "error": Data_Par_modal_paciente => {
            cod_fo_eli = 0;
            fila_eli = 0;
            Hide_Modal();
            console.log(Data_Par_modal_paciente);

        }
    });
}


function Ajax_modal_exa_RUT() {
    modal_show();
    Mx_Detalle_ate = 0;
    var Data_Par_modal = JSON.stringify({
        "ID": $("#rut").val()
    });
    $.ajax({
        "type": "POST",
        "url": "AGRE_EXA_ATE_CJ.aspx/MODAL_PAC_RUT",
        "data": Data_Par_modal,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": Data_Par_modal_paciente => {
            //Debug
            //console.log(Data_Par_modal_paciente);
            cod_fo_eli = 0;
            fila_eli = 0;
            Mx_Detalle_ate = Data_Par_modal_paciente.d;
            //ENVIAMOS ID_ATEMCION AL MODAL
            //LLAMAMOS AL FILL MODAL
            if (Mx_Detalle_ate.proparra1 != null) {
                llenarmodal();
                $("#Btn_Print").removeAttr("disabled");
            } else {
                Hide_Modal();
            }


            //// MOSTRAR EL MODAL
            //$('#eModales33').modal('show');
        },
        "error": Data_Par_modal_paciente => {
            cod_fo_eli = 0;
            fila_eli = 0;
            Hide_Modal();
            console.log(Data_Par_modal_paciente);

        }
    });
}
function Ajax_modal_exa_DNI() {
    modal_show();
    Mx_Detalle_ate = 0;
    var Data_Par_modal = JSON.stringify({
        "ID": $("#dni").val()
    });
    $.ajax({
        "type": "POST",
        "url": "AGRE_EXA_ATE_NORMAL.aspx/MODAL_PAC_DNI",
        "data": Data_Par_modal,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": Data_Par_modal_paciente => {
            //Debug
            //console.log(Data_Par_modal_paciente);
            cod_fo_eli = 0;
            fila_eli = 0;
            Mx_Detalle_ate = Data_Par_modal_paciente.d;
            //ENVIAMOS ID_ATEMCION AL MODAL
            if (Mx_Detalle_ate.proparra1 != null) {
                //LLAMAMOS AL FILL MODAL
                llenarmodal();
                $("#Btn_Print").removeAttr("disabled");
            } else {
                Hide_Modal();
            }


            //// MOSTRAR EL MODAL
            //$('#eModales33').modal('show');
        },
        "error": Data_Par_modal_paciente => {
            cod_fo_eli = 0;
            fila_eli = 0;
            Hide_Modal();
            console.log(Data_Par_modal_paciente);

        }
    });
}
var Mx_DL_Diag = [
    {
        "ID_DIAGNOSTICO": 0,
        "DIA_COD": "asdf",
        "DIA_DESC": "asdf",
        "ID_ESTADO": 0,
        "DIA_HOST_AVIS": 0
    }
];
function Ajax_DLdiag(hosts) {
    Mx_DL_Diag.length = 0;


    var Data_Par = JSON.stringify({
        "HOST": hosts
    });
    $.ajax({
        "type": "POST",
        "url": "IN_PAC_AVIS.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_Diag = JSON.parse(json_receiver);
                $("#Diag2").val(Mx_DL_Diag[0].DIA_DESC);
                //$("#DdlDiagnostico").val(Mx_DL_Diag[0].ID_DIAGNOSTICO);
            } else {
                //$("#DdlDiagnostico").val(1);
                $("#Diag2").val("");


            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            // cModal_Error("Error", str_Error);


        }
    });
}

var Mx_DL_Diag2 = [
    {
        "ID_DIAGNOSTICO": 0,
        "DIA_COD": "asdf",
        "DIA_DESC": "asdf",
        "ID_ESTADO": 0,
        "DIA_HOST_AVIS": 0
    }
];
function Ajax_DLdiag2(hosts) {
    Mx_DL_Diag2.length = 0;


    var Data_Par = JSON.stringify({
        "HOST": hosts
    });
    $.ajax({
        "type": "POST",
        "url": "IN_PAC_AVIS.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST2",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_Diag2 = JSON.parse(json_receiver);
                $("#Diag3").val(Mx_DL_Diag2[0].DIA_DESC);
                //$("#DdlDiagnostico").val(Mx_DL_Diag[0].ID_DIAGNOSTICO);

            } else {
                //$("#DdlDiagnostico").val(1);
                $("#Diag3").val("");


            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            // cModal_Error("Error", str_Error);


        }
    });
}
async function llenarmodal() {



    await Ajax_DL_NAC();
    await Ajax_DL_SEXO();

    let FechaREE = moment(Mx_Detalle_ate.proparra1[0].PAC_FNAC).format("YYYY-MM-DD");
    $("#Rut_2m").val(Mx_Detalle_ate.proparra1[0].PAC_RUT);
    $("#Nom").val(Mx_Detalle_ate.proparra1[0].PAC_NOMBRE);
    $("#Ape").val(Mx_Detalle_ate.proparra1[0].PAC_APELLIDO);
    $("#fecha").val(FechaREE);
    $("#Edad").val(`${Mx_Detalle_ate.proparra1[0].PREI_AÑO} años`);
    $("#telfijo").val(Mx_Detalle_ate.proparra1[0].PAC_FONO1);
    $("#Celular").val(Mx_Detalle_ate.proparra1[0].PAC_MOVIL1);
    await Ajax_DataTable_examen02();
    await Ajax_DataTable_examen02_Particular();
    var obj_RUT2 = Valid_RUT($("#rut").val());
    $("#rut").val(obj_RUT2.Format);


    var aaa = {};


    if (Mx_Detalle_ate.proparra2.length > 0) {
        Mx_Dtt_examcof.length = 0;
        //for (let p = 0; p < Mx_Detalle_ate.proparra2.length; p++) {
        //    var objId = {
        //        "ID_CODIGO_FONASA": Mx_Detalle_ate.proparra2[p].ID_CODIGO_FONASA,
        //        "CF_COD": Mx_Detalle_ate.proparra2[p].CF_COD,
        //        "CF_DESC": Mx_Detalle_ate.proparra2[p].CF_DESC,
        //        "CF_DIAS": Mx_Detalle_ate.proparra2[p].CF_DIAS,
        //        "ID_PER": Mx_Detalle_ate.proparra2[p].ID_PER,
        //        "HO_CC": Mx_Detalle_ate.proparra2[p].ATE_NUM_AVIS
        //    };
        //    Mx_Dtt_examcof.push(fnClone(objId));
        //    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo";      
        //}

        exa_actuales_xd.length = 0;
        exa_actuales_xd = [];


        for (let p = 0; p < Mx_Detalle_ate.proparra2.length; p++) {
            var objId = {
                "ID_CODIGO_FONASA": Mx_Detalle_ate.proparra2[p].ID_CODIGO_FONASA,
                "CF_COD": Mx_Detalle_ate.proparra2[p].CF_COD,
                "CF_DESC": Mx_Detalle_ate.proparra2[p].CF_DESC,
                "CF_DIAS": Mx_Detalle_ate.proparra2[p].CF_DIAS,
                "ID_PER": Mx_Detalle_ate.proparra2[p].ID_PER,
                "HO_CC": Mx_Detalle_ate.proparra2[p].ATE_NUM_AVIS
            };
            exa_actuales_xd.push(fnClone(objId));
            exa_actuales_xd[exa_actuales_xd.length - 1]["CF_ESTADO_EXAMEN"] = "Activo";
        }




        //fill_llenado_tabla();
        fill_llenado_tabla_2();
    } else {

        $("#DataTable_pac2 tbody").empty();
        add_row();

        var str_Error = "Estimado usuario el numero atención no contiene exámenes Pendientes"
        $("#title").text("Ingreao de Atención");
        $("#button_modal").attr("class", "btn btn-danger");
        $("#mError_AAH p").text(str_Error);
        $("#mError_AAH").modal();

    }

    Hide_Modal();
    //Ajax_Examens_avis();
};
//-*-*-*-*-*-*-*-*-* TABLA DINAMICA -*-*-*-*-*-*-*-*-*-*-*
function add_row() {
    var rowstota = document.getElementById("DataTable_pac2").rows.length;
    var xvalue = $("#DataTable_pac2 tr:last input").val();
    if (xvalue != "") {
        $("#DataTable_pac2 tbody").append(
            $("<tr>", {
                "class": "textoReducido manito negrita",
                "padding": "1px !important",
            }).append(
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido negrita"
                }).html((function () {
                    //Retornar un campo input
                    return $("<input>", {
                        "data-id": 0,
                        "data-cod": "",
                        "class": "td_input td_inputSearch negrita",
                        "value": ""
                    })
                }())),

                $("<td>", {
                    "align": "left",
                    "class": "textoReducido negrita"
                }).html((function () {
                    //Retornar un campo input
                    return $("<input>", {
                        "data-id": 0,
                        "data-cod": "",
                        "class": "textoReducido td_val1 negrita td_inputSearchDesc",           //NUEVO CAMPO DE BUSQUEDA POR DESCRIPCION
                        "value": ""
                    })
                }())),

                //$("<td>", {
                //    "align": "left",
                //    "class": "textoReducido td_val1 negrita"          //VIEJO CAMPO DE BUSQUEDA POR DESCRIPCION
                //}).text(""),
                //$("<td>", {
                //    "align": "center"
                //}).append(
                //    $("<select>", {
                //        class: "form-control textoReducido tp_pago negrita",
                //        "data-id_pago": 0,
                //        "data-cod-exa": 0,
                //        "data-posicion": 10000000000000,
                //        "height": "calc(1.89rem + 1px)"

                //    }).append(function () {
                //        let xxx = [];
                //        for (let x = 0; x < arrPago.length; x++) {
                //            xxx.push($("<option>", {
                //                value: arrPago[x].ID_TP_PAGO
                //            }).text(arrPago[x].TP_PAGO_DESC));
                //        }

                //        return xxx;
                //    }())),
                //$("<td>", {
                //    "align": "center",
                //    "class": "textoReducido td_val3 negrita"
                //}).text(""),
                //$("<td>", {
                //    "align": "left",
                //    "class": "textoReducido td_val4 negrita"
                //}).text(""),
                //$("<td>", {
                //    "align": "left",
                //    "class": "textoReducido td_val4444 negrita"     //OBSERVACION EXAMEN
                //}).text(""),
                //$("<td>", {
                //    "align": "left",
                //    "class": "textoReducido td_val5 negrita"
                //}).text(""),
                //$("<td>", {
                //    "align": "left",
                //    "class": "textoReducido td_val6 negrita"
                //}).text(""),
                //$("<td>", {
                //    "align": "center",
                //    "class": "textoReducido td_val2 negrita"
                //}).text(""),
                //$("<td>", {
                //    "align": "center",
                //    "class": "textoReducido negrita"                        //NUEVA COLUMNA SIN CLASE !!!!!!!!!!!!!!!!!!!!!!!!!
                //}).text(""),
                $("<td>", {
                    "align": "center"
                }).html("<button type='button' class='btn btn-default btn-xs borrar negrita' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"),
                $("<td>", {
                    "align": "center"
                }).html("<button type='button' class='btn btn-print btn-xs CEstado negrita' value='Espera' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>")

            )

        )
        $(".td_inputSearch").keydown(function EnterEvent(e) {
            if (e.keyCode == 13) {
                xId = $(this).attr("data-id");
                var xcod = $(this).attr("data-cod");
                Ajax_DataTable_examen3($(this).val(), xId, xcod, $(this));
            }
        });

        $(".td_inputSearchDesc").keydown(function EnterEvent(e) {                                    //BUSCAR EXAMEN POR RPEVISION AL PRESIONAR ENTER
            if (e.keyCode == 13) {
                xId = $(this).attr("data-id");
                var xcod = $(this).attr("data-cod");
                Ajax_DataTable_examen3_Desc($(this).val(), xId, xcod, $(this));
            }
        });

        $(".tp_prevision").change(function EnterEvent(e) {
            e.stopImmediatePropagation();
            var xId_preve = $(this).attr("data-id_prevision");
            var x_id_cod = $(this).attr("data-cod-exa");

            var x_id_pos = $(this).parents("tr").attr('data-index');


            Ajax_DataTable_examen3_preve(xId_preve, $(this).val(), x_id_cod, x_id_pos);


        });
        $(".tp_pago").change(function EnterEvent(e) {
            e.stopImmediatePropagation();

            var xId_index = $(this).attr("data-id_pago");
            var x_id_pos = $(this).parents("tr").attr('data-index');

            Ajax_DataTable_examen3_tp_pago(xId_index, x_id_pos, $(this).val());


        });
        var HXH = 0;
        for (let x = 0; x < Mx_Dtt_examcof.length; x++) {
            if (Mx_Dtt_examcof[x].ID_CODIGO_FONASA == 1054) {
                HXH = 1;
            }
        }
        if (HXH == 1 && $("#sex").val() == 2 && sifi == 0) {
            var str_Error = "Por favor Rellenar el campo F.U.R"
            $("#title").text("Recordatorio");
            $("#button_modal").attr("class", "btn btn-success");

            $("#mError_AAH p").text(str_Error);
            $("#mError_AAH").modal();
            $('#XXXXXXXX').removeClass('show');
            sifi = 1;
        }
    } else if ((rowstota == 1) || (rowstota == 2)) {
        $("#DataTable_pac2 tbody").append(
            $("<tr>", {
                "class": "textoReducido manito negrita",
                "padding": "1px !important",
            }).append(
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido negrita"
                }).html((function () {
                    //Retornar un campo input
                    return $("<input>", {
                        "data-id": 0,
                        "data-cod": "",
                        "class": "td_inputSearch negrita",
                        "value": ""
                    })
                }())),

                $("<td>", {
                    "align": "left",
                    "class": "textoReducido negrita"
                }).html((function () {
                    //Retornar un campo input
                    return $("<input>", {
                        "data-id": 0,
                        "data-cod": "",
                        "class": "textoReducido td_val1 negrita td_inputSearchDesc",                   //NUEVO CAMPO PARA BUSCAR POR DESC
                        "value": ""
                    })
                }())),
                //$("<td>", {
                //    "align": "left",
                //    "class": "textoReducido td_val1 negrita"                  //VIEJO CAMPO PARA BUSCAR POR DESC
                //}).text(""),
                //$("<td>", {
                //    "align": "center"
                //}).append(
                //    $("<select>", {
                //        class: "form-control textoReducido tp_pago negrita",
                //        "data-id_pago": 0,
                //        "data-cod-exa": 0,
                //        "data-posicion": 10000000000000,
                //        "height": "calc(1.89rem + 1px)"

                //    }).append(function () {
                //        let xxx = [];
                //        for (let x = 0; x < arrPago.length; x++) {
                //            xxx.push($("<option>", {
                //                value: arrPago[x].ID_TP_PAGO
                //            }).text(arrPago[x].TP_PAGO_DESC));
                //        }

                //        return xxx;
                //    }())),
                //$("<td>", {
                //    "align": "center",
                //    "class": "textoReducido td_val3 negrita"
                //}).text(""),
                //$("<td>", {
                //    "align": "left",
                //    "class": "textoReducido td_val4 negrita"
                //}).text(""),
                //$("<td>", {
                //    "align": "left",
                //    "class": "textoReducido td_val4444 negrita"             //OBSERVACION EXAMEN
                //}).text(""),
                //$("<td>", {
                //    "align": "left",
                //    "class": "textoReducido td_val5 negrita"
                //}).text(""),
                //$("<td>", {
                //    "align": "left",
                //    "class": "textoReducido td_val6 negrita"
                //}).text(""),

                //$("<td>", {
                //    "align": "center",
                //    "class": "textoReducido td_val2 negrita"
                //}).text(""),

                $("<td>", {
                    "align": "center"
                }).html("<button type='button' class='btn btn-default btn-xs borrar negrita' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'>Eliminar</i></button>"),
                $("<td>", {
                    "align": "center"
                }).html("<button type='button' class='btn btn-print btn-xs CEstado negrita' value='Espera' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Espera</button>")

            )
        )
        $(".td_inputSearch").focusout(function () {
            xId = $(this).attr("data-id");
            var xcod = $(this).attr("data-cod");
            Ajax_DataTable_examen3($(this).val(), xId, xcod, $(this));
        });

        $(".tp_prevision").change(function EnterEvent(e) {
            e.stopImmediatePropagation();
            var xId_preve = $(this).attr("data-id_prevision");
            var x_id_cod = $(this).attr("data-cod-exa");

            var x_id_pos = $(this).parents("tr").attr('data-index');


            Ajax_DataTable_examen3_preve(xId_preve, $(this).val(), x_id_cod, x_id_pos);


        });
    }
    var xLen = $(".td_input");
    $(".td_input").eq(xLen.length - 1).focus();
}
var Mx_Dtt_examcof = [
    {
        "AÑO_DESC": 0,
        "ID_PREVE": 0,
        "ID_CODIGO_FONASA": 0,
        "CF_PRECIO_AMB": 0,
        "CF_PRECIO_HOS": 0,
        "ID_ESTADO": 0,
        "CF_COD": 0,
        "CF_DESC": 0,
        "ID_PER": 0,
        "ID_CF_PRECIO": 0,
        "CF_DIAS": 0,
        "CF_ESTADO_EXA": 0
    }
];
var exa_actuales_xd = [
    {
        "AÑO_DESC": 0,
        "ID_PREVE": 0,
        "ID_CODIGO_FONASA": 0,
        "CF_PRECIO_AMB": 0,
        "CF_PRECIO_HOS": 0,
        "ID_ESTADO": 0,
        "CF_COD": 0,
        "CF_DESC": 0,
        "ID_PER": 0,
        "ID_CF_PRECIO": 0,
        "CF_DIAS": 0,
        "CF_ESTADO_EXA": 0
    }
];
Mx_Dtt_examcof.length = 0;
//-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
var Mx_Dt023 = [
    {
        "Correlativo": 0,
        "ID_Atencion": 0
    }
];

function Ajax_guardar() {
    modal_show();
    var fur = 0;
    var OB = "";
    var ID = 0;

    var TOTAL = 0;
    ids = new Array();
    var numeritocliniquito = 0;
    if ($("#NumeroClinico").val() == "") {
        numeritocliniquito = 0;
    } else {
        numeritocliniquito = $("#NumeroClinico").val();
    }
    for (let x = 0; x < exa_actuales_xd.length; x++) {
        for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
            if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == exa_actuales_xd[x].ID_CODIGO_FONASA) {
                Mx_Dtt_examcof.splice(i, 1);
            }
        }
    }


    for (let x = 0; x < Mx_Dtt_examcof.length; x++) {
        var xtotal = parseFloat(Mx_Dtt_examcof[x].CF_PRECIO_AMB);
        TOTAL += xtotal;

        var objId = {
            "id_CF": Mx_Dtt_examcof[x].ID_CODIGO_FONASA,
            "id_PER": Mx_Dtt_examcof[x].ID_PER,
            "Valor": Mx_Dtt_examcof[x].CF_PRECIO_AMB,
            "Clinico": numeritocliniquito,
            "CF_ESTADO_EXAMEN": Mx_Dtt_examcof[x].CF_ESTADO_EXAMEN,
            "CF_TP_PAGO": Mx_Dtt_examcof[x].ATE_DET_TP_1,
            "ATE_DET_VALOR_BENEF": Mx_Dtt_examcof[x].ATE_DET_VALOR_BENEF,
            "ATE_DET_VALOR_CS": Mx_Dtt_examcof[x].ATE_DET_VALOR_CS,
            "ATE_DET_TP_1": Mx_Dtt_examcof[x].ATE_DET_TP_1,
            "ATE_DET_TP_OBS": $("#txt_nTarjeta_1_modal").val(),
            "ATE_DET_NUM_BOL": 0,
            "ATE_DET_NUM_BONO": Mx_Dtt_examcof[x].ATE_DET_NUM_BONO,
            "OBS_EXAM": Mx_Dtt_examcof[x].OBS_EXAM
        };


        ids.push(objId);
        SEGURRRR__COMPLEMNT_SOLO_PRIMERO = 0;
    }
    gg = new Array();

    $("#checkBox2:checkbox:checked").each(function () {
        gg.push($(this).val());
    });
    if (gg.length == 1) {
        fur = $("#FUR").val();
    } else {
        fur = "";
    }
    if (verrut == 1) {
        var OB = Mx_Dtt2[0].ID_PACIENTE;
        var ID = Mx_Dtt2[0].PAC_OBS_PERMA;
    } else {
        var OB = "";
        var ID = 0;
    }
    var f = moment().format("DD-MM-YYYY");
    var Data_Par = JSON.stringify({
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-    
        "ids": ids,
        "ID_ATENCION": Mx_Detalle_ate.proparra3[0].ID_PREINGRESO,
        "ATE_V_SISTEMA": GLOBAL_TOT_PREVISION,                                                                          //1     VALOR PREVISIION
        "ATE_V_BENEF": GLOBAL_TOT_BENEFICIARIO, //+ GLOBAL_TOT_SEGURO_COMPLEMENTARIO),                                  //2     VALOR BENEFICIARIO +  SEGURO COMPLEMENATRIO/ SE CAMBIA LUEGO A SOLO BENEFICIARIO
        "ATE_V_CF": GLOBAL_TOT_FONASA,                                                                                  //3     TOTAL FONASA
        "ATE_V_CF_FP": $("#Ddl_Ttp_Modal").val(),                                                                       //4     TIPO DE PAGO FONASA
        "ATE_V_CP": $("#Lbl_tot_copa_particular").val(),                                                                //5     VALOR PARTICULAR
        "ATE_V_CP_FP": $("#Ddl_Ttp_Modal2").val(),                                                                      //6     TIPO DE PAGO PARTICULAR
        "ATE_V_BOLETA": $("#txt_nBoleta_2_modal").val(),                                                                //7     NUMERO DE BOLETA
        "ATE_V_PAGADO": $("#lbl_Tot_Pagar_Modal").val(),                                                                //8     TOTAL SUPREMO
        "ATE_V_SEG_COMP": GLOBAL_TOT_SEGURO_COMPLEMENTARIO,                                                             //9     SEGURO COMPLEMENTARIO
        // ---------------------------------------------------------- SE AGREGA SEGUNDO COPAGO -------------------------------------------------------
        "ATE_TP_COPAGO_1": $("#Ddl_Ttp_Modal").val(),                                                                   //10    TIPO COPAGO 1
        "ATE_VALOR_COPAGO_1": tp111,                                                                                    //11    VALOR COPAGO 1
        "ATE_TP_COPAGO_2": $("#Ddl_Ttp_Modal_2").val(),                                                                 //12    TIPO COPAGO 2   
        "ATE_VALOR_COPAGO_2": tp222,                                                                                    //14    VALOR COPAGO 2
        //---------------------------------------------------------- SE AGREGA SEGUNDO PAGO PARTICULAR --------------------------------------------              
        "ATE_TP_PARTICULAR_1": $("#Ddl_Ttp_Modal2").val(),                                                              //15    TIPO PAGO PARTICULAR 1  
        "ATE_VALOR_PARTICULAR_1": $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val(),                                     //16    VALOR PARTICULAR 1
        "ATE_TP_PARTICULAR_2": $("#Ddl_Ttp_Modal_2_Parti").val(),                                                       //17    TIPO PAGO PARTICULAR 2
        "ATE_VALOR_PARTICULAR_2": $("#lbl_Tot_Fonasa_Modal_2_Parti").val(),                                             //18    VALOR PARTICULAR 2
        //------------------------------------------  SE AGREGA SEGURO COMPLEMENTARIO PARA TABLA IRIS_ATENCION _________________________________________
        "ATE_V_SC": GLOBAL_TOT_SEGURO_COMPLEMENTARIO,
        "S_Id_User": Galletas.getGalleta("ID_USER")

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

    });
    $.ajax({
        "type": "POST",
        "url": "AGRE_EXA_ATE_NORMAL.aspx/Guardar_TodoByVal",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_Dt023 = JSON.parse(json_receiver);
                Hide_Modal();
                $("#checkBox2").prop('checked', false);
                $('#FUR').attr("disabled", true);
                $('#checkBox2').attr("disabled", true);
                $("#fur").css("pointer-events", "none");
                var f = moment().format("DD-MM-YYYY");
                $("#obs_ate").val("");
                $("#NumeroClinico").val("");
                $("#fecha").val(f);
                $("#fecha2").val(f);
                $("#FUR").val(f);
                $('#rut').removeAttr("disabled");
                $('#rut').val("");
                $('#dni').removeAttr("disabled");
                $('#dni').val("");
                $("#Nom").val("");
                $("#Ape").val("");
                $("#Edad").val("");
                $("#telfijo").val("");
                $("#Celular").val("");
                $("#Email").val("");
                $("#direccion").val("");
                $("#obdser").val("");
                Mx_Dtt_examcof.length = 0;
                $("#DataTable_pac2 tbody").empty();
                $("#Interno").val("");
                $("#Rut_2m").val("");
                $("#Avis").val("");

                GLOBAL_TOT_SEGURO_COMPLEMENTARIO = 0;
                GLOBAL_TOT_PREVISION = 0;
                GLOBAL_TOT_FONASA = 0;
                GLOBAL_TOT_COPA_PART = 0;
                GLOBAL_TOT_PREVISION = 0;
                GLOBAL_TOT_BENEFICIARIO = 0;
                GLOBAL_TOT_A_PAGAR = 0;

                tp111 = 0;
                tp222 = 0;
                activador = 0;

                tp111_Parti = 0;
                tp222_Parti = 0;
                activador_Parti = 0;

                $("#Lbl_tot_a_pagar").val("");
                $("#Lbl_tot_copa_fonasa").val("");
                $("#Lbl_tot_copa_particular").val("");
                $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val("");
                $("#Lbl_tot_prevision").val("");
                $("#Lbl_tot_beneficiario").val("");
                $("#lbl_Tot_Pagar_Modal").val("");
                $("#lbl_Tot_Fonasa_Modal").val("");
                $("#txt_nTarjeta_1_modal").val("");
                $("#txt_nTarjeta_2_modal").val("");
                $("#txt_nBoleta_2_modal").val("");
                $("#lbl_Tot_Fonasa_Modal_2").val("0");

                $("#MOdal_NUEVO_SELECCION").modal("hide");

                $("#divNewPaymen").hide();
                $("#agregaMedioPago").show();
                $("#spanAgregaMedioPago").show();
                $("#lbl_Tot_Fonasa_Modal").attr("disabled", "disabled");

                $("#divNewPaymen_Parti").hide();
                $("#agregaMedioPago_Parti").show();
                $("#spanAgregaMedioPago_Parti").show();
                $("#lbl_Tot_Pagar_Insumos_Particul_Modal").attr("disabled", "disabled");

                add_row();
                $("#Div_Tabla78").empty();
                verrut = 0;
                try {
                    Mx_Dtt2.length = 0;
                } catch (lol) {
                }
                $('#XXXXXXXX').removeClass('show');

                //var str_Error = "Los exámenes fueron ingresados correctamente"
                //$("#title").text("Ingreso de Atención realizado");
                //$("#button_modal").attr("class", "btn btn-succes");

                //$("#mError_AAH p").text(str_Error);
                //$("#mError_AAH").modal();

                $("#mdlCheck_Print").modal();
                $("#Btn_Print").attr("disabled", true);
            } else {
                Hide_Modal();


                var str_Error = "Estimado usuario Por favor ingresar exámenes"
                $("#title").text("Ingreao de Atención");
                $("#button_modal").attr("class", "btn btn-danger");

                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();
            }
        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
}

//-*-*-**-*-**--**--*-*-*-***-*****--**-*-*-*-*-*-*-*-*-*-*-*-*-*- if (aidi_procvbvbvbvb == "503" || aidi_procvbvbvbvb == "574" || aidi_procvbvbvbvb == "350" || aidi_procvbvbvbvb == "444"
var Mx_Dtt_exam02 = [
    {
        "AÑO_DESC": 0,
        "ID_PREVE": 0,
        "ID_CODIGO_FONASA": 0,
        "CF_PRECIO_AMB": 0,
        "CF_PRECIO_HOS": 0,
        "ID_ESTADO": 0,
        "CF_COD": 0,
        "CF_DESC": 0,
        "ID_PER": 0,
        "ID_CF_PRECIO": 0,
        "CF_DIAS": 0,
        "CF_PART_CF": 0,
        "CF_PART_TIPO": 0
    }
];
var Mx_Dtt_exam02_respaldo = [
    {
        "AÑO_DESC": 0,
        "ID_PREVE": 0,
        "ID_CODIGO_FONASA": 0,
        "CF_PRECIO_AMB": 0,
        "CF_PRECIO_HOS": 0,
        "ID_ESTADO": 0,
        "CF_COD": 0,
        "CF_DESC": 0,
        "ID_PER": 0,
        "ID_CF_PRECIO": 0,
        "CF_DIAS": 0,
        "CF_PRECIO_PARTICULAR": 0,
        "CF_BONIFICACION": 0,
        "CF_PART_CF": 0,
        "CF_PART_TIPO": 0
    }
];
async function Ajax_DataTable_examen02() {
    var f = moment().format("DD-MM-YYYY");


    $("#Div_Tabla2").empty();
    var Data_Par = JSON.stringify({
        "ID_PREVE": Mx_Detalle_ate.proparra3[0].ID_PREVE,
        "Fecha": f
    });

    await $.ajax({
        "type": "POST",
        "url": "AGRE_EXA_ATE_NORMAL.aspx/Llenar_tabla_exam2",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {

            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt_exam02 = JSON.parse(json_receiver);
                Mx_Dtt_exam02_respaldo = JSON.parse(json_receiver);
                Mx_Dtt_Resp_valAmbulatorio = JSON.parse(json_receiver);
                //if ($("#sex").val() != 0) {
                //    var posicion = 0;
                //    if ($("#sex").val() == 1) {
                //        for (let x = 0; x < Mx_Dtt_exam02.length; x++) {
                //            if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 691 || Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 1406) {
                //                posicion = x;
                //            }
                //        }
                //        Mx_Dtt_exam02.splice(posicion, 1);
                //    }
                //    if ($("#sex").val() == 2) {
                //        for (let x = 0; x < Mx_Dtt_exam02.length; x++) {
                //            if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 690 || Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 1405) {
                //                posicion = x;
                //            }
                //        }
                //        Mx_Dtt_exam02.splice(posicion, 1);
                //    }
                //}
                Fill_DataTable_exam02();

            } else {


            }
        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
}

//AJAX BUSCA PRECIOS PARTICULAR

var Mx_Dtt_exam02_Particular = [
    {
        "AÑO_DESC": 0,
        "ID_PREVE": 0,
        "ID_CODIGO_FONASA": 0,
        "CF_PRECIO_AMB": 0,
        "CF_PRECIO_HOS": 0,
        "ID_ESTADO": 0,
        "CF_COD": 0,
        "CF_DESC": 0,
        "ID_PER": 0,
        "ID_CF_PRECIO": 0,
        "CF_DIAS": 0,
        "CF_PRECIO_PARTICULAR": 0,
        "CF_BONIFICACION": 0
    }
];
async function Ajax_DataTable_examen02_Particular() {



    let id_prev_part = 0;

    Mx_DL_prevision.forEach((nenene) => {
        if (nenene.ID_PREVE == Mx_Detalle_ate.proparra3[0].ID_PREVE) {
            id_prev_part = nenene.PREVE_PARTICULAR;
        }
    });

    if (id_prev_part == 0) {
        id_prev_part = 308;
    }

    var f = moment().format("DD-MM-YYYY");

    var Data_Par = JSON.stringify({
        "ID_PREVE": id_prev_part,//185,//$("#Prevision").val(), 185 = PART N°1
        "Fecha": f
    });

    await $.ajax({
        "type": "POST",
        "url": "AGRE_EXA_ATE_NORMAL.aspx/Llenar_tabla_exam2_particular",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {

            var json_receiver = response.d;
            if (json_receiver != "null") {

                Mx_Dtt_exam02_Particular = JSON.parse(json_receiver);


            } else {


            }
        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
}

var Mx_Dtt_exam03 = [
    {
        "AÑO_DESC": 0,
        "ID_PREVE": 0,
        "ID_CODIGO_FONASA": 0,
        "CF_PRECIO_AMB": 0,
        "CF_PRECIO_HOS": 0,
        "ID_ESTADO": 0,
        "CF_COD": 0,
        "CF_DESC": 0,
        "ID_PER": 0,
        "ID_CF_PRECIO": 0,
        "CF_DIAS": 0,
        "CF_ESTADO_EXAMEN": "Activo",
        "CF_BONIFICACION": 0,
        "CF_HOST_IMED": 0,
        "ID_INSUMO": 0,
        "CF_PART_CF": 0,
        "CF_PART_TIPO": 0
    }
];
function Ajax_DataTable_examen3(cod_fonasa, id, cod, txis) {
    var f = moment().format("DD-MM-YYYY");


    var Data_Par = JSON.stringify({
        "ID_PREVE": Mx_Detalle_ate.proparra3[0].ID_PREVE,//126,//$("#Prevision").val(),
        "Fecha": f,
        "CF": cod_fonasa
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Caja4_Bn_Obs.aspx/IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_BONIFICACION",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt_exam03 = JSON.parse(json_receiver);
                cod_or_desc = 1;
                //if ($("#sex").val() != 0) {
                //    var posicion = 0;
                //    if ($("#sex").val() == 1) {
                //        for (let x = 0; x < Mx_Dtt_exam03.length; x++) {
                //            if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 1026) {
                //                posicion = x;
                //            }
                //        }
                //        Mx_Dtt_exam03.splice(posicion, 1);
                //    }
                //    if ($("#sex").val() == 2) {
                //        for (let x = 0; x < Mx_Dtt_exam03.length; x++) {
                //            if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 66) {
                //                posicion = x;
                //            }
                //        }
                //        Mx_Dtt_exam03.splice(posicion, 1);
                //    }
                //}
                success(id, cod, txis);


            } else {

                cod_or_desc = 0;
                Mx_Dtt_exam03.length = 0;
                //success(id, cod, txis);
                Ajax_DataTable_examen3_PACK(cod_fonasa, id, cod, txis);

            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
}

function Ajax_DataTable_examen3_PACK(cod_fonasa_2, id_2, cod_2, txis_2) {
    var f = moment().format("DD-MM-YYYY");


    var Data_Par = JSON.stringify({
        "ID_PREVE": Mx_Detalle_ate.proparra3[0].ID_PREVE,//$("#Prevision").val(),
        "Fecha": f,
        "CF": cod_fonasa_2
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Caja4_Bn_Obs.aspx/Llenar_tabla_exam_pack",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                cod_or_desc = 1;
                Mx_Dtt_exam03 = JSON.parse(json_receiver);
                for (let x = 0; x < Mx_Dtt_exam03.length; x++) {
                    if (Mx_Dtt_exam03[x]["CF_ESTADO_EXAMEN"] == undefined) {
                        Mx_Dtt_exam03[x]["CF_ESTADO_EXAMEN"] = "Activo";
                    }
                }
                //if ($("#sex").val() != 0) {
                //    var posicion = 0;
                //    if ($("#sex").val() == 1) {
                //        for (let x = 0; x < Mx_Dtt_exam03.length; x++) {
                //            if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 1026) {
                //                posicion = x;
                //            }
                //        }
                //        Mx_Dtt_exam03.splice(posicion, 1);
                //    }
                //    if ($("#sex").val() == 2) {
                //        for (let x = 0; x < Mx_Dtt_exam03.length; x++) {
                //            if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 66) {
                //                posicion = x;
                //            }
                //        }
                //        Mx_Dtt_exam03.splice(posicion, 1);
                //    }
                //}
                success_2(id_2, cod_2, txis_2);


            } else {

                cod_or_desc = 0;
                Mx_Dtt_exam03.length = 0;
                //success(id_2, cod_2, txis_2);
            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
}

function success_2(xxid_2, xxcod_2, xtxis_2) {                  //TABLA DE PACKS DE EXAMENES

    let xxid = xxid_2;
    let xxcod = xxcod_2;

    if (Mx_Dtt_exam03.length == 0) {

        $("input[data-id='" + xxid + "']").val(xxcod);
    } else if (Mx_Dtt_exam03.length == 1) {


        let repetido = 0;
        for (let z = 0; z < Mx_Dtt_examcof.length; z++) {
            if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == Mx_Dtt_exam03[0].ID_CODIGO_FONASA) {
                repetido++

            }
        }
        if (repetido == 0) {

            //if (xxid != 0) {
            Mx_Dtt_exam03[0].CF_ESTADO_EXAMEN = "Activo"
            Mx_Dtt_examcof.push(Mx_Dtt_exam03[0]);

            for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
                if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == xxid) {
                    Mx_Dtt_examcof.splice(i, 1);

                }
            }

            for (let rrr = 0; rrr < Mx_Dtt_examcof.length; rrr++) {

                if (Mx_Dtt_examcof[rrr].CF_PART_TIPO != null && Mx_Dtt_examcof[rrr].CF_PART_TIPO != 0 && Mx_Dtt_examcof[rrr].CF_PART_TIPO != "") {

                    Mx_Dtt_examcof[rrr]["CF_TP_PAGO"] = 20;
                    Mx_Dtt_examcof[rrr]["ATE_DET_TP_1"] = 20;

                    for (let x = 0; x < Mx_Dtt_exam02_Particular.length; x++) {
                        if (Mx_Dtt_exam02_Particular[x].ID_CODIGO_FONASA == Mx_Dtt_examcof[rrr].ID_CODIGO_FONASA) {
                            Mx_Dtt_examcof[rrr].CF_PRECIO_AMB = Mx_Dtt_exam02_Particular[x].CF_PRECIO_AMB;
                            Mx_Dtt_examcof[rrr].CF_BONIFICACION = 0;
                        }
                    }
                    console.log("PARTICULAR");
                } else {
                    console.log("NO particular");
                }
            }

            acti_cf_part = 0;

            //}

            $("#DataTable_pac2 tbody").empty();

            for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
                if (Mx_Dtt_examcof[i]["ATE_DET_TP_1"] == undefined || Mx_Dtt_examcof[i]["ATE_DET_TP_1"] == 0) {
                    Mx_Dtt_examcof[i]["CF_TP_PAGO"] = 5;
                    Mx_Dtt_examcof[i]["ATE_DET_TP_1"] = 5;
                }
                if (Mx_Dtt_examcof[i]["CF_TP_PREVE"] == undefined || Mx_Dtt_examcof[i]["CF_TP_PREVE"] == 0) {
                    Mx_Dtt_examcof[i]["CF_TP_PREVE"] = $('#Prevision').val();
                }
                $("#DataTable_pac2 tbody").append(
                    $("<tr>", {
                        "class": "textoReducido manito negrita",
                        "padding": "1px !important",
                        "data-index": i
                    }).append(
                        $("<td>", {                                                         // CODIGO FONASA
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                                "data-cod": Mx_Dtt_examcof[i].CF_COD,
                                "class": "td_input td_inputSearch negrita",
                                "value": Mx_Dtt_examcof[i].CF_COD
                            })
                        }())),

                        $("<td>", {                                                         //CF DESC
                            "align": "left",
                            "class": "textoReducido td_val1 negrita"
                        }).text(Mx_Dtt_examcof[i].CF_DESC),
                        //$("<td>", {                                                             //DROP TIPO DE PAGO
                        //    "align": "center"
                        //}).append(
                        //    $("<select>", {
                        //        class: "form-control textoReducido tp_pago tp_pago2 negrita",
                        //        "data-id_pago": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod-exa": Mx_Dtt_examcof[i].CF_COD,
                        //        "data-posicion": i,
                        //        "height": "calc(1.89rem + 1px)"

                        //    }).append(function () {
                        //        let xxx = [];

                        //        if (Mx_Dtt_examcof[i].CF_PART_TIPO == 1) {
                        //            console.log("es particuleichon");
                        //            for (let x = 0; x < arrPago.length; x++) {
                        //                if (arrPago[x].ID_TP_PAGO == 20 || arrPago[x].ID_TP_PAGO == 3) {
                        //                    xxx.push($("<option>", {
                        //                        value: arrPago[x].ID_TP_PAGO
                        //                    }).text(arrPago[x].TP_PAGO_DESC));
                        //                }

                        //            }

                        //            return xxx;
                        //        } else {
                        //            console.log("no es naa");
                        //            for (let x = 0; x < arrPago.length; x++) {
                        //                xxx.push($("<option>", {
                        //                    value: arrPago[x].ID_TP_PAGO
                        //                }).text(arrPago[x].TP_PAGO_DESC));
                        //            }

                        //            return xxx;
                        //        }


                        //    }())),
                        //$("<td>", {                                                          //DIAS
                        //    "align": "center",
                        //    "class": "textoReducido carlos_sama td_val2 negrita"
                        //}).text(Mx_Dtt_examcof[i].CF_DIAS),
                        //$("<td>", {                                                         //OBSERVACION EXAMEN
                        //    "align": "right",
                        //    "class": "textoReducido negrita"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input carlos_sama textDerecho borderRound td_obsexam negrita",
                        //        "value": ""
                        //    })
                        //}())),
                        //$("<td>", {                                                         //NUM BONO
                        //    "align": "right",
                        //    "class": "textoReducido negrita"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input carlos_sama textDerecho borderRound td_documento negrita",
                        //        "onkeydown": "return jsDecimals(event)",
                        //        //"disabled": "disabled",
                        //        "value": ""
                        //    })
                        //}())),
                        //$("<td>", {                                                         //SEGURO COMPLEMENTARIO
                        //    "align": "right",
                        //    "class": "textoReducido"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input  carlos_sama textDerecho borderRound td_scomplementario negrita",
                        //        "maxlength": "7",
                        //        "onkeydown": "return jsDecimals(event)",
                        //        "disabled": "disabled",
                        //        "value": "0"
                        //    })
                        //}())),
                        //$("<td>", {                                                         //VALOR PREVISION
                        //    "align": "right",
                        //    "class": "textoReducido negrita"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input textoReducido carlos_sama textDerecho borderRound td_val3 dark_text td_prevision negrita",
                        //        "disabled": "disabled",
                        //        "maxlength": "7",
                        //        "onkeydown": "return jsDecimals(event)",
                        //        "value": Mx_Dtt_examcof[i].CF_PRECIO_AMB
                        //    })
                        //}())),
                        ////$("<td>", {                                                             //VALOR PREVISION
                        ////    "align": "right",
                        ////    "class": "textoReducido td_val3 dark_text td_prevision"
                        ////}).text(Mx_Dtt_examcof[i].CF_PRECIO_AMB),
                        //$("<td>", {                                                         //VALOR BENEFICIARIO
                        //    "align": "right",
                        //    "class": "textoReducido negrita"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input textDerecho carlos_sama borderRound td_valorBeneficiario negrita",
                        //        "maxlength": "7",
                        //        "onkeydown": "return jsDecimals(event)",
                        //        //"disabled": "disabled",
                        //        "value": Mx_Dtt_examcof[i].CF_BONIFICACION
                        //    })
                        //}())),
                        //$("<td>", {                                                         //VALOR A PAGAR 
                        //    "align": "right",
                        //    "class": "textoReducido"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//,Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input textDerecho carlos_sama dark_text borderRound td_valorapagar negrita",
                        //        "maxlength": "7",
                        //        "onkeydown": "return jsDecimals(event)",
                        //        "disabled": "disabled",
                        //        "value": (Mx_Dtt_examcof[i].CF_PRECIO_AMB - Mx_Dtt_examcof[i].CF_BONIFICACION)
                        //    })
                        //}())),


                        $("<td>", {
                            "align": "center"
                        }).html("<button type='button' class='btn btn-default btn-xs borrar negrita' value='Eliminar' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"),
                        $("<td>", {
                            "align": "center"
                        }).html(function () {


                            //if (Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN == "Activo") {
                            return "<button type='button' class='btn btn-print btn-xs CEstado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>"
                            //} else {
                            //return "<button type='button' class='btn btn-success btn-xs Activado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Activo</button>"
                            //}

                        }())
                    )
                )

                let xindex = $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_pago`).val(Mx_Dtt_examcof[i].ATE_DET_TP_1);
                let xindex3 = $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_prevision`).val(Mx_Dtt_examcof[i].CF_TP_PREVE);

                $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_pago2`).val(Mx_Dtt_examcof[i].ATE_DET_TP_1);

                Mx_Dtt_examcof[i].ATE_DET_VALOR_BENEF = $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_valorBeneficiario`).val();                            //1
                Mx_Dtt_examcof[i].ATE_DET_VALOR_CS = $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_scomplementario`).val();                                 //2
                Mx_Dtt_examcof[i].ATE_DET_TP_1 = $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_pago2`).val();                                               //3
                Mx_Dtt_examcof[i].ATE_DET_TP_OBS = "ate det tp obss";                                                                                           //4 
                Mx_Dtt_examcof[i].ATE_DET_NUM_BOL = 0;                                                                                                          //5 
                Mx_Dtt_examcof[i].ATE_DET_NUM_BONO = "";                                                                                                        //6
                Mx_Dtt_examcof[i].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_obsexam`).val();

                $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_valorapagar`).attr("data-tipo", Mx_Dtt_examcof[i].ATE_DET_TP_1);

                //----------------------------------    
                //CAMBIO EN NUM BONO
                $(`#DataTable_pac2 tbody tr .td_documento`).change(function EnterEvent(e) {                                                                         //CAMBIO EN NUM BONO
                    console.log("cambio num bono 3");
                    e.stopImmediatePropagation();
                    var x_id_pos_td_num_bono3333 = $(this).parents("tr").attr('data-index');

                    Mx_Dtt_examcof[x_id_pos_td_num_bono3333].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bono3333}] .td_documento`).val();                                                           //7
                });

                //----------------------------------    
                //CAMBIO EN OBS EXAMEN
                $(`#DataTable_pac2 tbody tr .td_obsexam`).change(function EnterEvent(e) {                                                                         //CAMBIO EN OBS EXAMEN
                    console.log("cambio obs examen 3");
                    e.stopImmediatePropagation();
                    var x_id_pos_td_obs3 = $(this).parents("tr").attr('data-index');

                    Mx_Dtt_examcof[x_id_pos_td_obs3].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_obs3}] .td_obsexam`).val();                                                           //7
                });
                //CAMBIO EN DROP TIPO DEPAGO
                $(`#DataTable_pac2 tbody tr .tp_pago2`).change(function EnterEvent(e) {                                                                         //CAMBIO EN DROP TIPO DE PAGO
                    console.log("cambio tp 3");
                    console.log("AQUI 6");
                    e.stopImmediatePropagation();
                    var x_id_pos_td = $(this).parents("tr").attr('data-index');
                    var x_id_codFonasa_td = $(this).attr('data-id_pago');
                    var x_id_tpago_td = $(this).val();


                    //var xId_index_td_val_documento = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();
                    var xId_index_td_val_scomplementario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val();
                    var xId_index_td_val_prevision = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).val();
                    var xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
                    var xId_index_td_val_valorapagar = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).val();

                    //if (x_id_tpago_td == 1 || x_id_tpago_td == 20) {
                    //    xId_index_td_val_prevision = ddl_Change_onTable(x_id_pos_td, x_id_codFonasa_td, x_id_tpago_td);                             //FUNCION CAMBIO VALOR        

                    //    $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).text(xId_index_td_val_prevision);
                    //} else {
                    //    xId_index_td_val_prevision = Mx_Dtt_examcof[x_id_pos_td].CF_PRECIO_AMB;
                    //    $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).text(xId_index_td_val_prevision);
                    //}

                    xId_index_td_val_prevision = ddl_Change_onTable(x_id_pos_td, x_id_codFonasa_td, x_id_tpago_td);                             //FUNCION CAMBIO VALOR        
                    $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).val(xId_index_td_val_prevision);

                    if (x_id_tpago_td == 1 || x_id_tpago_td == 11 || x_id_tpago_td == 20 || x_id_tpago_td == 8) {
                        xId_index_td_val_valorBeneficiario = 0;
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(0);
                    } else if (x_id_tpago_td == 4) {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(Mx_Dtt_examcof[x_id_pos_td].CF_PRECIO_AMB);
                        xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
                    } else {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(Mx_Dtt_examcof[x_id_pos_td].CF_BONIFICACION);
                        xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
                    }

                    var SC_VB = parseInt(xId_index_td_val_scomplementario) + parseInt(xId_index_td_val_valorBeneficiario)

                    var provisorio = (parseInt(xId_index_td_val_prevision) - SC_VB);

                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_VALOR_BENEF = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();                            //1
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_VALOR_CS = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val();                                 //2
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_1 = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .tp_pago2`).val();                                               //3
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_OBS = "ate det tp obss";                                                                                                     //4 
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_NUM_BOL = 0;                                                                                                                    //5 
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();                                       //6
                    Mx_Dtt_examcof[x_id_pos_td].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_obsexam`).val();                                                 //7

                    $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).attr("data-tipo", Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_1);          //SE MARCA ID TIPO PAGO PARA DIFERENCIAR DE FONASA O PARTICULAR

                    if (provisorio < 0) {
                        alert("Rectifique");
                    } else {
                        console.log("AQUI 7");
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).val(parseInt(provisorio));

                        HOLAAAAAAAAAAA();
                    }
                });


                $(`#DataTable_pac2 tbody tr .td_scomplementario`).keyup(function EnterEvent(e) {                                                //POR FILA SEGURO COMPLEMENTARIO
                    e.stopImmediatePropagation();
                    var x_id_pos_td = $(this).parents("tr").attr('data-index');

                    if ($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val() == "") {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(0);
                    }

                    if ($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val() == "") {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val(0);
                    }

                    //var xId_index_td_val_documento = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();
                    var xId_index_td_val_scomplementario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val();
                    var xId_index_td_val_prevision = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).val();
                    var xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
                    var xId_index_td_val_valorapagar = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).val();

                    var SC_VB = parseInt(xId_index_td_val_scomplementario) + parseInt(xId_index_td_val_valorBeneficiario)

                    var provisorio = (parseInt(xId_index_td_val_prevision) - SC_VB);

                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_VALOR_BENEF = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();                            //1
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_VALOR_CS = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val();                                 //2
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_1 = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .tp_pago2`).val();                                               //3
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_OBS = "ate det tp obss";                                                                                                     //4 
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_NUM_BOL = 0;                                                                                                                    //5 
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();                                       //6
                    Mx_Dtt_examcof[x_id_pos_td].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_obsexam`).val();                                                 //7



                    if (provisorio < 0) {
                        alert("Rectifique");
                    } else {
                        console.log("AQUI 8");
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).val(parseInt(provisorio));

                        HOLAAAAAAAAAAA();
                    }


                    //$(".td_valorapagar").trigger("change")();

                    //$(".td_valorBeneficiario").trigger("change")();
                });

                $(`#DataTable_pac2 tbody tr .td_valorBeneficiario`).keyup(function EnterEvent(e) {                                                                    //POR BONIFICACION

                    console.log("beneficiario 1");
                    e.stopImmediatePropagation();
                    //var x_id_pos_td = $(this).parents("tr").attr('data-index');sd
                    //let x_id_pos_td_2 = $(`#DataTable_pac2 tbody tr[data-index =${i}]`).attr('data-index');a

                    var x_id_pos_td_2 = $(this).parents("tr").attr('data-index');
                    //let x_id_pos_td_2 = $(`#DataTable_pac2 tbody tr[data-index =${i}]`).attr('data-index');

                    if ($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val() == "") {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val(0);
                    }

                    if ($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val() == "") {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val(0);
                    }

                    //var xId_index_td_val_documento = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();
                    var xId_index_td_val_scomplementario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val();
                    var xId_index_td_val_prevision = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_prevision`).val();
                    var xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val();
                    var xId_index_td_val_valorapagar = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorapagar`).val();

                    var SC_VB = parseInt(xId_index_td_val_scomplementario) + parseInt(xId_index_td_val_valorBeneficiario)

                    var provisorio = (parseInt(xId_index_td_val_prevision) - SC_VB);

                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_VALOR_BENEF = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val();                            //1
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_VALOR_CS = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val();                                 //2
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_TP_1 = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .tp_pago2`).val();                                               //3
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_TP_OBS = "ate det tp obss";                                                                                                       //4 
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_NUM_BOL = 0;                                                                                                                      //5 
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_documento`).val();                                       //6
                    Mx_Dtt_examcof[x_id_pos_td_2].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_obsexam`).val();                                                 //7

                    if (provisorio < 0) {
                        $(this).parents("tr").attr('data-index');

                        PASS_SAVE = 0;
                        $(this).css({ "border-color": "red" });
                        $(this).css({ "color": "red" });

                        $("#Lbl_tot_beneficiario").css({ "border-color": "red" });
                        $("#Lbl_tot_beneficiario").css({ "color": "red" });


                    } else {
                        console.log("AQUI 2");
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorapagar`).val(parseInt(provisorio));
                        PASS_SAVE = 1;
                        $(this).css({ "border-color": "#ccc" });
                        $(this).css({ "color": "#212529" });
                        $("#Lbl_tot_beneficiario").css({ "border-color": "#868e96" });
                        $("#Lbl_tot_beneficiario").css({ "color": "#495057" });
                        HOLAAAAAAAAAAA();
                    }

                    //$(".td_valorBeneficiario").trigger("change")();

                    //$(".td_valorapagar").trigger("change")();
                    //});

                });
                //-------------------------------------
            }       //<---------------------------



            actualizaValores();

            //--------------


            //filas.forEach(function (e) {
            //    var columnas = e.querySelectorAll("td");
            //    
            //    var cantidad = parseFloat(columnas[0].textContent);

            //   
            //});

            //--------------


            add_row();




            //$("input[data-id='" + xxid + "']").val(Mx_Dtt_exam03[0].CF_COD);
            //$("input[data-id='" + xxid + "']").parent().parent().children(".td_val1").text(Mx_Dtt_exam03[0].CF_DESC);
            //$("input[data-id='" + xxid + "']").parent().parent().children(".td_val2").text(Mx_Dtt_exam03[0].CF_DIAS);
            //$("input[data-id='" + xxid + "']").parent().parent().children(".td_val3").text(Mx_Dtt_exam03[0].CF_PRECIO_AMB);
            //$("input[data-id='" + xxid + "']").attr("data-cod", Mx_Dtt_exam03[0].CF_COD);
            //$("input[data-id='" + xxid + "']").parents("tr").find(`.tp_pago`).attr("data-id_pago", Mx_Dtt_exam03[0].ID_CODIGO_FONASA);
            //$("input[data-id='" + xxid + "']").parents("tr").find(`.tp_prevision`).attr("data-cod-exa", Mx_Dtt_exam03[0].CF_COD);
            //$("input[data-id='" + xxid + "']").parents("tr").find(`.tp_prevision`).attr("data-id_prevision", Mx_Dtt_exam03[0].ID_CODIGO_FONASA);

            //$("input[data-id='" + xxid + "']").parents("tr").find(`.tp_pago`).val(5);



            //$("input[data-cod='" + Mx_Dtt_exam03[0].CF_COD + "']").attr("data-id", Mx_Dtt_exam03[0].ID_CODIGO_FONASA);
            //Mx_Dtt_examcof.push(Mx_Dtt_exam03[0]);
            //Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
            //if (Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PAGO"] == undefined || Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PAGO"] == 0) {
            //    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PAGO"] = 5;
            //}
            //if (Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PREVE"] == undefined || Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PREVE"] == 0) {
            //    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PREVE"] = $('#Prevision').val();
            //}
            //add_row();

        } else {
            $("input[data-id='" + xxid + "']").val(xxcod);
        }
    } else if (Mx_Dtt_exam03.length > 1) {                      //SI VIENE MAS DE UN EXAMEN AL APRETAR ENTER

        var repetido = 0;
        //for (let z = 0; z < Mx_Dtt_examcof.length; z++) {
        //    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == Mx_Dtt_exam03[0].ID_CODIGO_FONASA) {
        //        repetido++

        //    }
        //}
        if (repetido == 0) {

            //if (xxid != 0) {
            //Mx_Dtt_exam03[0].CF_ESTADO_EXAMEN = "Activo"
            //Mx_Dtt_examcof.push(Mx_Dtt_exam03[0]);

            //for (let i = 0; i < Mx_Dtt_exam03.length; i++) {
            //    Mx_Dtt_exam03[i].CF_ESTADO_EXAMEN = "Activo"
            //    Mx_Dtt_examcof.push(Mx_Dtt_exam03[i]);
            //}

            ////for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
            ////    for (let ii = 0; ii < Mx_Dtt_exam03.length; ii++) {
            ////        if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == Mx_Dtt_exam03[ii].ID_CODIGO_FONASA) {
            ////            Mx_Dtt_exam03.splice(ii, 1);                   
            ////        }
            ////    }
            ////}

            //for (let i = 0; i < Mx_Dtt_exam03.length; i++) {
            //    for (let ii = 0; ii < Mx_Dtt_examcof.length; ii++) {
            //        if (Mx_Dtt_exam03[i].ID_CODIGO_FONASA == Mx_Dtt_examcof[ii].ID_CODIGO_FONASA) {
            //            Mx_Dtt_exam03.splice(i, 1);
            //        }
            //    }
            //}

            //}


            if (Mx_Dtt_examcof.length > 0) {
                for (let x = 0; x < Mx_Dtt_exam03.length; x++) {
                    for (let c = 0; c < Mx_Dtt_examcof.length; c++) {
                        if (Mx_Dtt_examcof[c].ID_CODIGO_FONASA == Mx_Dtt_exam03[x].ID_CODIGO_FONASA) {
                            Mx_Dtt_examcof.splice(c, 1);
                            break;
                        }
                    }

                }

                for (let z = 0; z < Mx_Dtt_exam03.length; z++) {
                    Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam03[z]));
                }
            }
            else {
                for (let z = 0; z < Mx_Dtt_exam03.length; z++) {
                    Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam03[z]));
                }
            }

            for (let rrr = 0; rrr < Mx_Dtt_examcof.length; rrr++) {

                if (Mx_Dtt_examcof[rrr].CF_PART_TIPO != null && Mx_Dtt_examcof[rrr].CF_PART_TIPO != 0 && Mx_Dtt_examcof[rrr].CF_PART_TIPO != "") {

                    Mx_Dtt_examcof[rrr]["CF_TP_PAGO"] = 20;
                    Mx_Dtt_examcof[rrr]["ATE_DET_TP_1"] = 20;

                    for (let x = 0; x < Mx_Dtt_exam02_Particular.length; x++) {
                        if (Mx_Dtt_exam02_Particular[x].ID_CODIGO_FONASA == Mx_Dtt_examcof[rrr].ID_CODIGO_FONASA) {
                            Mx_Dtt_examcof[rrr].CF_PRECIO_AMB = Mx_Dtt_exam02_Particular[x].CF_PRECIO_AMB;
                            Mx_Dtt_examcof[rrr].CF_BONIFICACION = 0;
                        }
                    }
                    console.log("PARTICULAR");
                } else {
                    console.log("NO particular");
                }
            }

            acti_cf_part = 0;

            $("#DataTable_pac2 tbody").empty();

            for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
                if (Mx_Dtt_examcof[i]["ATE_DET_TP_1"] == undefined || Mx_Dtt_examcof[i]["ATE_DET_TP_1"] == 0) {
                    Mx_Dtt_examcof[i]["CF_TP_PAGO"] = 5;
                    Mx_Dtt_examcof[i]["ATE_DET_TP_1"] = 5;
                }
                if (Mx_Dtt_examcof[i]["CF_TP_PREVE"] == undefined || Mx_Dtt_examcof[i]["CF_TP_PREVE"] == 0) {
                    Mx_Dtt_examcof[i]["CF_TP_PREVE"] = $('#Prevision').val();
                }
                $("#DataTable_pac2 tbody").append(
                    $("<tr>", {
                        "class": "textoReducido manito negrita",
                        "padding": "1px !important",
                        "data-index": i
                    }).append(
                        $("<td>", {                                                         // CODIGO FONASA
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                                "data-cod": Mx_Dtt_examcof[i].CF_COD,
                                "class": "td_input td_inputSearch negrita",
                                "value": Mx_Dtt_examcof[i].CF_COD
                            })
                        }())),

                        $("<td>", {                                                         //CF DESC
                            "align": "left",
                            "class": "textoReducido td_val1 negrita"
                        }).text(Mx_Dtt_examcof[i].CF_DESC),
                        //$("<td>", {                                                             //DROP TIPO DE PAGO
                        //    "align": "center"
                        //}).append(
                        //    $("<select>", {
                        //        class: "form-control textoReducido tp_pago tp_pago2 negrita",
                        //        "data-id_pago": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod-exa": Mx_Dtt_examcof[i].CF_COD,
                        //        "data-posicion": i,
                        //        "height": "calc(1.89rem + 1px)"

                        //    }).append(function () {
                        //        let xxx = [];
                        //        if (Mx_Dtt_examcof[i].CF_PART_TIPO == 1) {
                        //            console.log("es particuleichon");
                        //            for (let x = 0; x < arrPago.length; x++) {
                        //                if (arrPago[x].ID_TP_PAGO == 20 || arrPago[x].ID_TP_PAGO == 3) {
                        //                    xxx.push($("<option>", {
                        //                        value: arrPago[x].ID_TP_PAGO
                        //                    }).text(arrPago[x].TP_PAGO_DESC));
                        //                }

                        //            }

                        //            return xxx;
                        //        } else {
                        //            console.log("no es naa");
                        //            for (let x = 0; x < arrPago.length; x++) {
                        //                xxx.push($("<option>", {
                        //                    value: arrPago[x].ID_TP_PAGO
                        //                }).text(arrPago[x].TP_PAGO_DESC));
                        //            }

                        //            return xxx;
                        //        }
                        //    }())),
                        //$("<td>", {                                                          //DIAS
                        //    "align": "center",
                        //    "class": "textoReducido carlos_sama td_val2 negrita"
                        //}).text(Mx_Dtt_examcof[i].CF_DIAS),
                        //$("<td>", {                                                         //OBSERVACION EXAMEN
                        //    "align": "right",
                        //    "class": "textoReducido negrita"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input carlos_sama textDerecho borderRound td_obsexam negrita",
                        //        "value": ""
                        //    })
                        //}())),
                        //$("<td>", {                                                         //DOCUMENTO
                        //    "align": "right",
                        //    "class": "textoReducido negrita"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input carlos_sama textDerecho borderRound td_documento negrita",
                        //        "onkeydown": "return jsDecimals(event)",
                        //        //"disabled": "disabled",
                        //        "value": ""
                        //    })
                        //}())),
                        //$("<td>", {                                                         //SEGURO COMPLEMENTARIO
                        //    "align": "right",
                        //    "class": "textoReducido"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input  carlos_sama textDerecho borderRound td_scomplementario negrita",
                        //        "maxlength": "7",
                        //        "onkeydown": "return jsDecimals(event)",
                        //        "disabled": "disabled",
                        //        "value": "0"
                        //    })
                        //}())),
                        //$("<td>", {                                                         //VALOR PREVISION
                        //    "align": "right",
                        //    "class": "textoReducido negrita"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input textoReducido carlos_sama textDerecho borderRound td_val3 dark_text td_prevision negrita",
                        //        "disabled": "disabled",
                        //        "maxlength": "7",
                        //        "onkeydown": "return jsDecimals(event)",
                        //        "value": Mx_Dtt_examcof[i].CF_PRECIO_AMB
                        //    })
                        //}())),
                        ////$("<td>", {                                                             //VALOR PREVISION
                        ////    "align": "right",
                        ////    "class": "textoReducido td_val3 dark_text td_prevision"
                        ////}).text(Mx_Dtt_examcof[i].CF_PRECIO_AMB),
                        //$("<td>", {                                                         //VALOR BENEFICIARIO
                        //    "align": "right",
                        //    "class": "textoReducido negrita"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input textDerecho carlos_sama borderRound td_valorBeneficiario negrita",
                        //        "maxlength": "7",
                        //        "onkeydown": "return jsDecimals(event)",
                        //        //"disabled": "disabled",
                        //        "value": Mx_Dtt_examcof[i].CF_BONIFICACION
                        //    })
                        //}())),
                        //$("<td>", {                                                         //VALOR A PAGAR 
                        //    "align": "right",
                        //    "class": "textoReducido"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//,Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input textDerecho carlos_sama dark_text borderRound td_valorapagar negrita",
                        //        "maxlength": "7",
                        //        "onkeydown": "return jsDecimals(event)",
                        //        "disabled": "disabled",
                        //        "value": (Mx_Dtt_examcof[i].CF_PRECIO_AMB - Mx_Dtt_examcof[i].CF_BONIFICACION)
                        //    })
                        //}())),


                        $("<td>", {
                            "align": "center"
                        }).html("<button type='button' class='btn btn-default btn-xs borrar negrita' value='Eliminar' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"),
                        $("<td>", {
                            "align": "center"
                        }).html(function () {


                            //if (Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN == "Activo") {
                            return "<button type='button' class='btn btn-print btn-xs CEstado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>"
                            //} else {
                            //return "<button type='button' class='btn btn-success btn-xs Activado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Activo</button>"
                            //}

                        }())
                    )
                )

                let xindex = $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_pago`).val(Mx_Dtt_examcof[i].ATE_DET_TP_1);
                let xindex3 = $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_prevision`).val(Mx_Dtt_examcof[i].CF_TP_PREVE);

                $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_pago2`).val(Mx_Dtt_examcof[i].ATE_DET_TP_1);

                Mx_Dtt_examcof[i].ATE_DET_VALOR_BENEF = $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_valorBeneficiario`).val();                            //1
                Mx_Dtt_examcof[i].ATE_DET_VALOR_CS = $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_scomplementario`).val();                                 //2
                Mx_Dtt_examcof[i].ATE_DET_TP_1 = $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_pago2`).val();                                               //3
                Mx_Dtt_examcof[i].ATE_DET_TP_OBS = "ate det tp obss";                                                                                           //4 
                Mx_Dtt_examcof[i].ATE_DET_NUM_BOL = 0;                                                                                                          //5 
                Mx_Dtt_examcof[i].ATE_DET_NUM_BONO = "";                                                                                                        //6
                Mx_Dtt_examcof[i].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_obsexam`).val();                                                 //7

                $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_valorapagar`).attr("data-tipo", Mx_Dtt_examcof[i].ATE_DET_TP_1);

                //----------------------------------   
                //CAMBIO EN NUM BONO
                $(`#DataTable_pac2 tbody tr .td_documento`).change(function EnterEvent(e) {                                                                         //CAMBIO EN NUM BONO
                    console.log("cambio num bono 4");
                    e.stopImmediatePropagation();
                    var x_id_pos_td_num_bon444 = $(this).parents("tr").attr('data-index');

                    if (x_id_pos_td_num_bon444 == 0) {
                        if (Mx_Dtt_examcof.length == 1) {
                            if (Mx_Dtt_examcof[x_id_pos_td_num_bon444].ATE_DET_TP_1 == 1 || Mx_Dtt_examcof[x_id_pos_td_num_bon444].ATE_DET_TP_1 == 20) {
                                Mx_Dtt_examcof[x_id_pos_td_num_bon444].ATE_DET_NUM_BONO = "";
                                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bon444}] .td_documento`).val("");
                                console.log("A");
                            } else {
                                Mx_Dtt_examcof[x_id_pos_td_num_bon444].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bon444}] .td_documento`).val();
                                console.log("B");
                            }

                        } else {
                            for (let i = 0; i < Mx_Dtt_examcof.length; i++) {

                                if (Mx_Dtt_examcof[i].ATE_DET_TP_1 == 1 || Mx_Dtt_examcof[i].ATE_DET_TP_1 == 20) {
                                    Mx_Dtt_examcof[i].ATE_DET_NUM_BONO = "";
                                    $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_documento`).val("");
                                    console.log("C");
                                } else {
                                    Mx_Dtt_examcof[i].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bon444}] .td_documento`).val();
                                    $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_documento`).val($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bon444}] .td_documento`).val());
                                    console.log("D");
                                }

                            }
                        }
                    } else {
                        if (Mx_Dtt_examcof[x_id_pos_td_num_bon444].ATE_DET_TP_1 == 1 || Mx_Dtt_examcof[x_id_pos_td_num_bon444].ATE_DET_TP_1 == 20) {
                            Mx_Dtt_examcof[x_id_pos_td_num_bon444].ATE_DET_NUM_BONO = "";
                            $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bon444}] .td_documento`).val("");
                            console.log("E");
                        } else {
                            Mx_Dtt_examcof[x_id_pos_td_num_bon444].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bon444}] .td_documento`).val();
                            console.log("F");
                        }
                    }                                                         //7
                });

                //----------------------------------   
                //CAMBIO EN OBS EXAMEN
                $(`#DataTable_pac2 tbody tr .td_obsexam`).change(function EnterEvent(e) {                                                                         //CAMBIO EN OBS EXAMEN
                    console.log("cambio obs examen 4");
                    e.stopImmediatePropagation();
                    var x_id_pos_td_obs4 = $(this).parents("tr").attr('data-index');

                    Mx_Dtt_examcof[x_id_pos_td_obs4].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_obs4}] .td_obsexam`).val();                                                           //7
                });

                //CAMBIO EN DROP TIPO DEPAGO
                $(`#DataTable_pac2 tbody tr .tp_pago2`).change(function EnterEvent(e) {                                                                         //CAMBIO EN DROP TIPO DE PAGO
                    console.log("cambio tp 4");
                    e.stopImmediatePropagation();
                    var x_id_pos_td = $(this).parents("tr").attr('data-index');
                    var x_id_codFonasa_td = $(this).attr('data-id_pago');
                    var x_id_tpago_td = $(this).val();


                    //var xId_index_td_val_documento = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();
                    var xId_index_td_val_scomplementario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val();
                    var xId_index_td_val_prevision = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).val();
                    var xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
                    var xId_index_td_val_valorapagar = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).val();

                    //if (x_id_tpago_td == 1 || x_id_tpago_td == 20) {
                    //    xId_index_td_val_prevision = ddl_Change_onTable(x_id_pos_td, x_id_codFonasa_td, x_id_tpago_td);                             //FUNCION CAMBIO VALOR        

                    //    $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).text(xId_index_td_val_prevision);
                    //} else {
                    //    xId_index_td_val_prevision = Mx_Dtt_examcof[x_id_pos_td].CF_PRECIO_AMB;
                    //    $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).text(xId_index_td_val_prevision);
                    //}

                    xId_index_td_val_prevision = ddl_Change_onTable(x_id_pos_td, x_id_codFonasa_td, x_id_tpago_td);                             //FUNCION CAMBIO VALOR        
                    $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).val(xId_index_td_val_prevision);

                    if (x_id_tpago_td == 1 || x_id_tpago_td == 11 || x_id_tpago_td == 20 || x_id_tpago_td == 8) {
                        xId_index_td_val_valorBeneficiario = 0;
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(0);
                    } else if (x_id_tpago_td == 4) {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(Mx_Dtt_examcof[x_id_pos_td].CF_PRECIO_AMB);
                        xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
                    } else {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(Mx_Dtt_examcof[x_id_pos_td].CF_BONIFICACION);
                        xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
                    }

                    var SC_VB = parseInt(xId_index_td_val_scomplementario) + parseInt(xId_index_td_val_valorBeneficiario)

                    var provisorio = (parseInt(xId_index_td_val_prevision) - SC_VB);

                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_VALOR_BENEF = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();                            //1
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_VALOR_CS = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val();                                 //2
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_1 = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .tp_pago2`).val();                                               //3
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_OBS = "ate det tp obss";                                                                                                     //4 
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_NUM_BOL = 0;                                                                                                                    //5 
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();                                       //6
                    Mx_Dtt_examcof[x_id_pos_td].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_obsexam`).val();                                                 //7

                    $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).attr("data-tipo", Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_1);          //SE MARCA ID TIPO PAGO PARA DIFERENCIAR DE FONASA O PARTICULAR

                    if (provisorio < 0) {
                        alert("Rectifique");
                    } else {
                        console.log("AQUI 10");
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).val(parseInt(provisorio));

                        HOLAAAAAAAAAAA();
                    }
                });


                $(`#DataTable_pac2 tbody tr .td_scomplementario`).keyup(function EnterEvent(e) {                                                //POR FILA SEGURO COMPLEMENTARIO
                    e.stopImmediatePropagation();
                    var x_id_pos_td = $(this).parents("tr").attr('data-index');

                    if ($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val() == "") {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(0);
                    }

                    if ($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val() == "") {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val(0);
                    }

                    //var xId_index_td_val_documento = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();
                    var xId_index_td_val_scomplementario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val();
                    var xId_index_td_val_prevision = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).val();
                    var xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
                    var xId_index_td_val_valorapagar = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).val();

                    var SC_VB = parseInt(xId_index_td_val_scomplementario) + parseInt(xId_index_td_val_valorBeneficiario)

                    var provisorio = (parseInt(xId_index_td_val_prevision) - SC_VB);

                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_VALOR_BENEF = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();                            //1
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_VALOR_CS = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val();                                 //2
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_1 = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .tp_pago2`).val();                                               //3
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_OBS = "ate det tp obss";                                                                                                     //4 
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_NUM_BOL = 0;                                                                                                                    //5 
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();                                       //6
                    Mx_Dtt_examcof[x_id_pos_td].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_obsexam`).val();                                                 //7



                    if (provisorio < 0) {
                        alert("Rectifique");
                    } else {
                        console.log("AQUI 11");
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).val(parseInt(provisorio));

                        HOLAAAAAAAAAAA();
                    }


                    //$(".td_valorapagar").trigger("change")();

                    //$(".td_valorBeneficiario").trigger("change")();
                });

                $(`#DataTable_pac2 tbody tr .td_valorBeneficiario`).keyup(function EnterEvent(e) {                                                                    //POR BONIFICACION

                    console.log("beneficiario 1");
                    e.stopImmediatePropagation();
                    //var x_id_pos_td = $(this).parents("tr").attr('data-index');sd
                    //let x_id_pos_td_2 = $(`#DataTable_pac2 tbody tr[data-index =${i}]`).attr('data-index');a

                    var x_id_pos_td_2 = $(this).parents("tr").attr('data-index');
                    //let x_id_pos_td_2 = $(`#DataTable_pac2 tbody tr[data-index =${i}]`).attr('data-index');

                    if ($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val() == "") {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val(0);
                    }

                    if ($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val() == "") {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val(0);
                    }

                    //var xId_index_td_val_documento = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();
                    var xId_index_td_val_scomplementario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val();
                    var xId_index_td_val_prevision = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_prevision`).val();
                    var xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val();
                    var xId_index_td_val_valorapagar = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorapagar`).val();

                    var SC_VB = parseInt(xId_index_td_val_scomplementario) + parseInt(xId_index_td_val_valorBeneficiario)

                    var provisorio = (parseInt(xId_index_td_val_prevision) - SC_VB);

                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_VALOR_BENEF = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val();                            //1
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_VALOR_CS = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val();                                 //2
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_TP_1 = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .tp_pago2`).val();                                               //3
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_TP_OBS = "ate det tp obss";                                                                                                       //4 
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_NUM_BOL = 0;                                                                                                                      //5 
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_documento`).val();                                       //6
                    Mx_Dtt_examcof[x_id_pos_td_2].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_obsexam`).val();                                                 //7

                    if (provisorio < 0) {
                        $(this).parents("tr").attr('data-index');

                        PASS_SAVE = 0;
                        $(this).css({ "border-color": "red" });
                        $(this).css({ "color": "red" });

                        $("#Lbl_tot_beneficiario").css({ "border-color": "red" });
                        $("#Lbl_tot_beneficiario").css({ "color": "red" });


                    } else {
                        console.log("AQUI 2");
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorapagar`).val(parseInt(provisorio));
                        PASS_SAVE = 1;
                        $(this).css({ "border-color": "#ccc" });
                        $(this).css({ "color": "#212529" });
                        $("#Lbl_tot_beneficiario").css({ "border-color": "#868e96" });
                        $("#Lbl_tot_beneficiario").css({ "color": "#495057" });
                        HOLAAAAAAAAAAA();
                    }

                    //$(".td_valorBeneficiario").trigger("change")();

                    //$(".td_valorapagar").trigger("change")();
                    //});

                });

                //-------------------------------------
            }       //<---------------------------



            actualizaValores();

            //--------------


            //filas.forEach(function (e) {
            //    var columnas = e.querySelectorAll("td");
            //    
            //    var cantidad = parseFloat(columnas[0].textContent);

            //   
            //});

            //--------------


            add_row();




            //$("input[data-id='" + xxid + "']").val(Mx_Dtt_exam03[0].CF_COD);
            //$("input[data-id='" + xxid + "']").parent().parent().children(".td_val1").text(Mx_Dtt_exam03[0].CF_DESC);
            //$("input[data-id='" + xxid + "']").parent().parent().children(".td_val2").text(Mx_Dtt_exam03[0].CF_DIAS);
            //$("input[data-id='" + xxid + "']").parent().parent().children(".td_val3").text(Mx_Dtt_exam03[0].CF_PRECIO_AMB);
            //$("input[data-id='" + xxid + "']").attr("data-cod", Mx_Dtt_exam03[0].CF_COD);
            //$("input[data-id='" + xxid + "']").parents("tr").find(`.tp_pago`).attr("data-id_pago", Mx_Dtt_exam03[0].ID_CODIGO_FONASA);
            //$("input[data-id='" + xxid + "']").parents("tr").find(`.tp_prevision`).attr("data-cod-exa", Mx_Dtt_exam03[0].CF_COD);
            //$("input[data-id='" + xxid + "']").parents("tr").find(`.tp_prevision`).attr("data-id_prevision", Mx_Dtt_exam03[0].ID_CODIGO_FONASA);

            //$("input[data-id='" + xxid + "']").parents("tr").find(`.tp_pago`).val(5);



            //$("input[data-cod='" + Mx_Dtt_exam03[0].CF_COD + "']").attr("data-id", Mx_Dtt_exam03[0].ID_CODIGO_FONASA);
            //Mx_Dtt_examcof.push(Mx_Dtt_exam03[0]);
            //Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
            //if (Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PAGO"] == undefined || Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PAGO"] == 0) {
            //    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PAGO"] = 5;
            //}
            //if (Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PREVE"] == undefined || Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PREVE"] == 0) {
            //    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PREVE"] = $('#Prevision').val();
            //}
            //add_row();

        } else {
            $("input[data-id='" + xxid + "']").val(xxcod);
        }

    }



    //---------------------------------------------------------------------------------------------------------------




















    //if (Mx_Dtt_exam03.length == 0) {
    //    $("input[data-id='" + xxid_2 + "']").val(xxcod_2);
    //} else if (Mx_Dtt_exam03.length > 0) {


    //    var repetido = 0;

    //    if (Mx_Dtt_examcof.length > 0) {
    //        for (let x = 0; x < Mx_Dtt_exam03.length; x++) {
    //            for (let c = 0; c < Mx_Dtt_examcof.length; c++) {
    //                if (Mx_Dtt_examcof[c].ID_CODIGO_FONASA == Mx_Dtt_exam03[x].ID_CODIGO_FONASA) {
    //                    Mx_Dtt_examcof.splice(c, 1);
    //                    break;
    //                }
    //            }

    //        }

    //        for (let z = 0; z < Mx_Dtt_exam03.length; z++) {
    //            Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam03[z]));
    //        }
    //    }
    //    else {
    //        for (let z = 0; z < Mx_Dtt_exam03.length; z++) {
    //            Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam03[z]));
    //        }



    //    }





    //    $("#DataTable_pac2 tbody").empty();
    //    for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
    //        if (Mx_Dtt_examcof[i]["CF_TP_PAGO"] == undefined || Mx_Dtt_examcof[i]["CF_TP_PAGO"] == 0) {
    //            Mx_Dtt_examcof[i]["CF_TP_PAGO"] = 5;
    //        }
    //        if (Mx_Dtt_examcof[i]["CF_TP_PREVE"] == undefined || Mx_Dtt_examcof[i]["CF_TP_PREVE"] == 0) {
    //            Mx_Dtt_examcof[i]["CF_TP_PREVE"] = $('#Prevision').val();
    //        }
    //        $("#DataTable_pac2 tbody").append(
    //            $("<tr>", {
    //                "class": "textoReducido manito negrita",
    //                "padding": "1px !important",
    //                "data-index": i
    //            }).append(
    //                $("<td>", {
    //                    "align": "left",
    //                    "class": "textoReducido negrita"
    //                }).html((function () {
    //                    //Retornar un campo input
    //                    return $("<input>", {
    //                        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
    //                        "data-cod": Mx_Dtt_examcof[i].CF_COD,
    //                        "class": "td_input td_inputSearch negrita",
    //                        "value": Mx_Dtt_examcof[i].CF_COD
    //                    })
    //                }())),
    //                $("<td>", {
    //                    "align": "left",
    //                    "class": "textoReducido td_val1 negrita"
    //                }).text(Mx_Dtt_examcof[i].CF_DESC),
    //                $("<td>", {
    //                    "align": "center"
    //                }).append(
    //                $("<select>", {
    //                    class: "form-control textoReducido tp_prevision negrita",
    //                    "data-id_prevision": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
    //                    "data-cod-exa": Mx_Dtt_examcof[i].CF_COD,
    //                    "data-posicion": i,
    //                    "height": "calc(1.89rem + 1px)"

    //                }).append(function () {
    //                    let xxx = [];
    //                    for (let x = 0; x < arrPrev.length; x++) {
    //                        xxx.push($("<option>", {
    //                            value: arrPrev[x].ID_PREVE
    //                        }).text(arrPrev[x].PREVE_DESC));
    //                    }

    //                    return xxx;
    //                }())),


    //                           $("<td>", {
    //                               "align": "center"
    //                           }).append(
    //                $("<select>", {
    //                    class: "form-control textoReducido tp_pago negrita",
    //                    "data-id_pago": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
    //                    "data-cod-exa": Mx_Dtt_examcof[i].CF_COD,
    //                    "data-posicion": i,
    //                    "height": "calc(1.89rem + 1px)"

    //                }).append(function () {
    //                    let xxx = [];
    //                    for (let x = 0; x < arrPago.length; x++) {
    //                        xxx.push($("<option>", {
    //                            value: arrPago[x].ID_TP_PAGO
    //                        }).text(arrPago[x].TP_PAGO_DESC));
    //                    }

    //                    return xxx;
    //                }())),
    //            $("<td>", {
    //                "align": "center",
    //                "class": "textoReducido td_val3 negrita"
    //            }).text(Mx_Dtt_examcof[i].CF_PRECIO_AMB),
    //               $("<td>", {
    //                   "align": "left",
    //                   "class": "textoReducido td_val4 negrita"
    //               }).text(""),
    //                $("<td>", {
    //                    "align": "left",
    //                    "class": "textoReducido td_val5 negrita"
    //                }).text(""),
    //                 $("<td>", {
    //                     "align": "left",
    //                     "class": "textoReducido td_val6 negrita"
    //                 }).text(""),

    //               $("<td>", {
    //                   "align": "center",
    //                   "class": "textoReducido td_val2 negrita"
    //               }).text(Mx_Dtt_examcof[i].CF_DIAS),
    //               $("<td>", {
    //                   "align": "center"
    //               }).html("<button type='button' class='btn btn-default btn-xs borrar negrita' value='Eliminar' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"),
    //                $("<td>", {
    //                    "align": "center"                     
    //                }).html(function () {
    //                    if (Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN == "Activo") {
    //                        return "<button type='button' class='btn btn-print btn-xs CEstado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>"
    //                    } else {
    //                        return "<button type='button' class='btn btn-success btn-xs Activado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Activo</button>"
    //                    }
    //                }())
    //            )
    //        )
    //        //let xindex = $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_programa`).val(Mx_Dtt_examcof[i].CF_TP_PROGRA)
    //        ////$("input[data-id='" + i + "']").parents("tr").find(`select`).val(Mx_Dtt_exam03[0].CF_TP_PROGRA);
    //        //if (Mx_Dtt_examcof[i].CF_TP_PROGRA == 32) {
    //        //    let xindex2 = $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_programa`).attr('disabled', true)
    //        //}
    //        let xindex3 = $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_prevision`).val(Mx_Dtt_examcof[i].CF_TP_PREVE)
    //        //$("input[data-id='" + i + "']").parents("tr").find(`select`).val(Mx_Dtt_exam03[0].CF_TP_PROGRA);
    //        let xindex = $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_pago`).val(Mx_Dtt_examcof[i].CF_TP_PAGO);


    //    }
    //    add_row();
    //}
}

var Mx_Dtt_exam03_Desc = [
    {
        "AÑO_DESC": 0,
        "ID_PREVE": 0,
        "ID_CODIGO_FONASA": 0,
        "CF_PRECIO_AMB": 0,
        "CF_PRECIO_HOS": 0,
        "ID_ESTADO": 0,
        "CF_COD": 0,
        "CF_DESC": 0,
        "ID_PER": 0,
        "ID_CF_PRECIO": 0,
        "CF_DIAS": 0,
        "CF_ESTADO_EXAMEN": "Activo",
        "CF_BONIFICACION": 0,
        "CF_PART_CF": 0,
        "CF_PART_TIPO": 0
    }
];
function Ajax_DataTable_examen3_Desc(cod_fonasa, id, cod, txis) {

    var f = moment().format("DD-MM-YYYY");


    var Data_Par = JSON.stringify({
        "ID_PREVE": Mx_Detalle_ate.proparra3[0].ID_PREVE,//$("#Prevision").val(),
        "Fecha": f,
        "CF": cod_fonasa
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Caja4_Bn_Obs.aspx/IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_DESC",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                cod_or_desc = 2;
                Mx_Dtt_exam03_Desc = JSON.parse(json_receiver);
                //if ($("#sex").val() != 0) {
                //    var posicion = 0;
                //    if ($("#sex").val() == 1) {
                //        for (let x = 0; x < Mx_Dtt_exam03_Desc.length; x++) {
                //            if (Mx_Dtt_exam03_Desc[x].ID_CODIGO_FONASA == 1026) {
                //                posicion = x;
                //            }
                //        }
                //        Mx_Dtt_exam03_Desc.splice(posicion, 1);
                //    }
                //    if ($("#sex").val() == 2) {
                //        for (let x = 0; x < Mx_Dtt_exam03_Desc.length; x++) {
                //            if (Mx_Dtt_exam03_Desc[x].ID_CODIGO_FONASA == 66) {
                //                posicion = x;
                //            }
                //        }
                //        Mx_Dtt_exam03_Desc.splice(posicion, 1);
                //    }
                //}
                success_3(id, cod, txis);


            } else {

                cod_or_desc = 0;
                Mx_Dtt_exam03_Desc.length = 0;
                //success(id, cod, txis);
                //Ajax_DataTable_examen3_PACK(cod_fonasa, id, cod, txis);

            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
}

function success_3(xxid, xxcod, xtxis) {                                              //ESTA ES CUANDO SE ESCRIBE DESC DE EXAMEN A MANO Y SE DA ENTER

    var acti_glu3 = 0;
    var acti_ivy3 = 0;

    if (Mx_Dtt_exam03_Desc.length == 0) {
        $("input[data-id='" + xxid + "']").val(xxcod);
    } else if (Mx_Dtt_exam03_Desc.length == 1) {
        console.log("uno solo por desc de examen");
        var repetido = 0;
        for (let z = 0; z < Mx_Dtt_examcof.length; z++) {
            if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == Mx_Dtt_exam03_Desc[0].ID_CODIGO_FONASA) {
                console.log("repetido++");
                repetido++

            }
        }
        if (repetido == 0) {

            //if (xxid != 0) {
            Mx_Dtt_exam03_Desc[0].CF_ESTADO_EXAMEN = "Activo"
            Mx_Dtt_examcof.push(Mx_Dtt_exam03_Desc[0]);
            for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
                if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == xxid) {
                    console.log("enter for repetido == 0");
                    Mx_Dtt_examcof.splice(i, 1);

                }
            }

            for (let rrr = 0; rrr < Mx_Dtt_examcof.length; rrr++) {

                if (Mx_Dtt_examcof[rrr].CF_PART_TIPO != null && Mx_Dtt_examcof[rrr].CF_PART_TIPO != 0 && Mx_Dtt_examcof[rrr].CF_PART_TIPO != "") {

                    Mx_Dtt_examcof[rrr]["CF_TP_PAGO"] = 20;
                    Mx_Dtt_examcof[rrr]["ATE_DET_TP_1"] = 20;

                    for (let x = 0; x < Mx_Dtt_exam02_Particular.length; x++) {
                        if (Mx_Dtt_exam02_Particular[x].ID_CODIGO_FONASA == Mx_Dtt_examcof[rrr].ID_CODIGO_FONASA) {
                            Mx_Dtt_examcof[rrr].CF_PRECIO_AMB = Mx_Dtt_exam02_Particular[x].CF_PRECIO_AMB;
                            Mx_Dtt_examcof[rrr].CF_BONIFICACION = 0;
                        }
                    }
                    console.log("PARTICULAR");
                } else {
                    console.log("NO particular");
                }
            }

            acti_cf_part = 0;


            $("#DataTable_pac2 tbody").empty();
            console.log(Mx_Dtt_exam03_Desc);
            for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
                if (Mx_Dtt_examcof[i]["ATE_DET_TP_1"] == undefined || Mx_Dtt_examcof[i]["ATE_DET_TP_1"] == 0) {
                    console.log("se le pone tp pago 5");
                    Mx_Dtt_examcof[i]["CF_TP_PAGO"] = 5;
                    Mx_Dtt_examcof[i]["ATE_DET_TP_1"] = 5;
                }
                if (Mx_Dtt_examcof[i]["CF_TP_PREVE"] == undefined || Mx_Dtt_examcof[i]["CF_TP_PREVE"] == 0) {
                    Mx_Dtt_examcof[i]["CF_TP_PREVE"] = $('#Prevision').val();
                }
                $("#DataTable_pac2 tbody").append(
                    $("<tr>", {
                        "class": "textoReducido manito negrita",
                        "padding": "1px !important",
                        "data-index": i
                    }).append(
                        $("<td>", {                                                         // CODIGO FONASA
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                                "data-cod": Mx_Dtt_examcof[i].CF_COD,
                                "class": "td_input td_inputSearch negrita",
                                "value": Mx_Dtt_examcof[i].CF_COD
                            })
                        }())),

                        $("<td>", {                                                         //CF DESC
                            "align": "left",
                            "class": "textoReducido td_val1 negrita td_inputSearchDesc"
                        }).text(Mx_Dtt_examcof[i].CF_DESC),
                        //$("<td>", {                                                             //DROP TIPO DE PAGO
                        //    "align": "center"
                        //}).append(
                        //    $("<select>", {
                        //        class: "form-control textoReducido tp_pago tp_pago2 negrita",
                        //        "data-id_pago": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod-exa": Mx_Dtt_examcof[i].CF_COD,
                        //        "data-posicion": i,
                        //        "height": "calc(1.89rem + 1px)"

                        //    }).append(function () {
                        //        let xxx = [];

                        //        if (Mx_Dtt_examcof[i].CF_PART_TIPO == 1) {
                        //            for (let x = 0; x < arrPago.length; x++) {
                        //                if (arrPago[x].ID_TP_PAGO == 20 || arrPago[x].ID_TP_PAGO == 3) {
                        //                    xxx.push($("<option>", {
                        //                        value: arrPago[x].ID_TP_PAGO
                        //                    }).text(arrPago[x].TP_PAGO_DESC));
                        //                }
                        //            }

                        //            return xxx;
                        //        } else {
                        //            for (let x = 0; x < arrPago.length; x++) {
                        //                xxx.push($("<option>", {
                        //                    value: arrPago[x].ID_TP_PAGO
                        //                }).text(arrPago[x].TP_PAGO_DESC));
                        //            }

                        //            return xxx;
                        //        }


                        //    }())),
                        //$("<td>", {                                                          //DIAS
                        //    "align": "center",
                        //    "class": "textoReducido carlos_sama td_val2 negrita"
                        //}).text(Mx_Dtt_examcof[i].CF_DIAS),
                        //$("<td>", {                                                         //OBSEERVACION EXAMEN
                        //    "align": "right",
                        //    "class": "textoReducido negrita"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input carlos_sama textDerecho borderRound td_obsexam negrita",
                        //        "value": ""
                        //    })
                        //}())),
                        //$("<td>", {                                                         //DOCUMENTO
                        //    "align": "right",
                        //    "class": "textoReducido negrita"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input carlos_sama textDerecho borderRound td_documento negrita",
                        //        "onkeydown": "return jsDecimals(event)",
                        //        //"disabled": "disabled",
                        //        "value": ""
                        //    })
                        //}())),
                        //$("<td>", {                                                         //SEGURO COMPLEMENTARIO
                        //    "align": "right",
                        //    "class": "textoReducido"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input  carlos_sama textDerecho borderRound td_scomplementario negrita",
                        //        "maxlength": "7",
                        //        "onkeydown": "return jsDecimals(event)",
                        //        "disabled": "disabled",
                        //        "value": "0"
                        //    })
                        //}())),
                        //$("<td>", {                                                         //VALOR PREVISION
                        //    "align": "right",
                        //    "class": "textoReducido negrita"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input textoReducido carlos_sama textDerecho borderRound td_val3 dark_text td_prevision negrita",
                        //        "disabled": "disabled",
                        //        "maxlength": "7",
                        //        "onkeydown": "return jsDecimals(event)",
                        //        "value": Mx_Dtt_examcof[i].CF_PRECIO_AMB
                        //    })
                        //}())),
                        ////$("<td>", {                                                             //VALOR PREVISION
                        ////    "align": "right",
                        ////    "class": "textoReducido td_val3 dark_text td_prevision"
                        ////}).text(Mx_Dtt_examcof[i].CF_PRECIO_AMB),
                        //$("<td>", {                                                         //VALOR BENEFICIARIO
                        //    "align": "right",
                        //    "class": "textoReducido negrita"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input textDerecho carlos_sama borderRound td_valorBeneficiario negrita",
                        //        "maxlength": "7",
                        //        "onkeydown": "return jsDecimals(event)",
                        //        //"disabled": "disabled",
                        //        "value": Mx_Dtt_examcof[i].CF_BONIFICACION
                        //    })
                        //}())),
                        //$("<td>", {                                                         //VALOR A PAGAR 
                        //    "align": "right",
                        //    "class": "textoReducido"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        //        "data-cod": "",//,Mx_Dtt_examcof[i].CF_COD,
                        //        "class": "td_input textDerecho carlos_sama dark_text borderRound td_valorapagar negrita",
                        //        "maxlength": "7",
                        //        "onkeydown": "return jsDecimals(event)",
                        //        "disabled": "disabled",
                        //        "value": (Mx_Dtt_examcof[i].CF_PRECIO_AMB - Mx_Dtt_examcof[i].CF_BONIFICACION)
                        //    })
                        //}())),


                        $("<td>", {
                            "align": "center"
                        }).html("<button type='button' class='btn btn-default btn-xs borrar negrita' value='Eliminar' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"),
                        $("<td>", {
                            "align": "center"
                        }).html(function () {


                            //if (Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN == "Activo") {
                            return "<button type='button' class='btn btn-print btn-xs CEstado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>"
                            //} else {
                            //return "<button type='button' class='btn btn-success btn-xs Activado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Activo</button>"
                            //}

                        }())
                    )
                )

                let xindex = $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_pago`).val(Mx_Dtt_examcof[i].ATE_DET_TP_1);
                let xindex3 = $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_prevision`).val(Mx_Dtt_examcof[i].CF_TP_PREVE);

                console.log($(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_pago2`).val());
                $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_pago2`).val(Mx_Dtt_examcof[i].ATE_DET_TP_1);

                Mx_Dtt_examcof[i].ATE_DET_VALOR_BENEF = $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_valorBeneficiario`).val();                            //1
                Mx_Dtt_examcof[i].ATE_DET_VALOR_CS = $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_scomplementario`).val();                                 //2
                Mx_Dtt_examcof[i].ATE_DET_TP_1 = $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_pago2`).val();                                               //3
                Mx_Dtt_examcof[i].ATE_DET_TP_OBS = "ate det tp obss";                                                                                           //4 
                Mx_Dtt_examcof[i].ATE_DET_NUM_BOL = 0;                                                                                                          //5 
                Mx_Dtt_examcof[i].ATE_DET_NUM_BONO = "";                                                                                                        //6
                Mx_Dtt_examcof[i].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_obsexam`).val();                                                 //7

                $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_valorapagar`).attr("data-tipo", Mx_Dtt_examcof[i].ATE_DET_TP_1);

                //CAMBIO EN NUM BONO
                $(`#DataTable_pac2 tbody tr .td_documento`).change(function EnterEvent(e) {                                                                         //CAMBIO EN OBS EXAMEN
                    console.log("cambio num bono 5");
                    e.stopImmediatePropagation();
                    var x_id_pos_td_num_bono555 = $(this).parents("tr").attr('data-index');

                    if (x_id_pos_td_num_bono555 == 0) {
                        if (Mx_Dtt_examcof.length == 1) {
                            if (Mx_Dtt_examcof[x_id_pos_td_num_bono555].ATE_DET_TP_1 == 1 || Mx_Dtt_examcof[x_id_pos_td_num_bono555].ATE_DET_TP_1 == 20) {
                                Mx_Dtt_examcof[x_id_pos_td_num_bono555].ATE_DET_NUM_BONO = "";
                                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bono555}] .td_documento`).val("");
                                console.log("A");
                            } else {
                                Mx_Dtt_examcof[x_id_pos_td_num_bono555].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bono555}] .td_documento`).val();
                                console.log("B");
                            }

                        } else {
                            for (let i = 0; i < Mx_Dtt_examcof.length; i++) {

                                if (Mx_Dtt_examcof[i].ATE_DET_TP_1 == 1 || Mx_Dtt_examcof[i].ATE_DET_TP_1 == 20) {
                                    Mx_Dtt_examcof[i].ATE_DET_NUM_BONO = "";
                                    $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_documento`).val("");
                                    console.log("C");
                                } else {
                                    Mx_Dtt_examcof[i].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bono555}] .td_documento`).val();
                                    $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_documento`).val($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bono555}] .td_documento`).val());
                                    console.log("D");
                                }

                            }
                        }
                    } else {
                        if (Mx_Dtt_examcof[x_id_pos_td_num_bono555].ATE_DET_TP_1 == 1 || Mx_Dtt_examcof[x_id_pos_td_num_bono555].ATE_DET_TP_1 == 20) {
                            Mx_Dtt_examcof[x_id_pos_td_num_bono555].ATE_DET_NUM_BONO = "";
                            $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bono555}] .td_documento`).val("");
                            console.log("E");
                        } else {
                            Mx_Dtt_examcof[x_id_pos_td_num_bono555].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bono555}] .td_documento`).val();
                            console.log("F");
                        }
                    }                                                          //7
                });

                //----------------------------------         
                //CAMBIO EN OBS EXAMEN
                $(`#DataTable_pac2 tbody tr .td_obsexam`).change(function EnterEvent(e) {                                                                         //CAMBIO EN OBS EXAMEN
                    console.log("cambio obs examen 5");
                    e.stopImmediatePropagation();
                    var x_id_pos_td_obs5 = $(this).parents("tr").attr('data-index');

                    Mx_Dtt_examcof[x_id_pos_td_obs5].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_obs5}] .td_obsexam`).val();                                                           //7
                });
                //CAMBIO EN DROP TIPO DEPAGO
                $(`#DataTable_pac2 tbody tr .tp_pago2`).change(function EnterEvent(e) {                                                                         //CAMBIO EN DROP TIPO DE PAGO
                    console.log("cambio tp 5");
                    e.stopImmediatePropagation();
                    var x_id_pos_td = $(this).parents("tr").attr('data-index');
                    var x_id_codFonasa_td = $(this).attr('data-id_pago');
                    var x_id_tpago_td = $(this).val();


                    //var xId_index_td_val_documento = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();
                    var xId_index_td_val_scomplementario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val();
                    var xId_index_td_val_prevision = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).val();
                    var xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
                    var xId_index_td_val_valorapagar = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).val();

                    //if (x_id_tpago_td == 1 || x_id_tpago_td == 20) {
                    //    xId_index_td_val_prevision = ddl_Change_onTable(x_id_pos_td, x_id_codFonasa_td, x_id_tpago_td);                             //FUNCION CAMBIO VALOR        

                    //    $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).text(xId_index_td_val_prevision);
                    //} else {
                    //    xId_index_td_val_prevision = Mx_Dtt_examcof[x_id_pos_td].CF_PRECIO_AMB;
                    //    $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).text(xId_index_td_val_prevision);
                    //}

                    xId_index_td_val_prevision = ddl_Change_onTable(x_id_pos_td, x_id_codFonasa_td, x_id_tpago_td);                             //FUNCION CAMBIO VALOR        
                    $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).val(xId_index_td_val_prevision);

                    if (x_id_tpago_td == 1 || x_id_tpago_td == 11 || x_id_tpago_td == 20 || x_id_tpago_td == 8) {
                        xId_index_td_val_valorBeneficiario = 0;
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(0);
                    } else if (x_id_tpago_td == 4) {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(Mx_Dtt_examcof[x_id_pos_td].CF_PRECIO_AMB);
                        xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
                    } else {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(Mx_Dtt_examcof[x_id_pos_td].CF_BONIFICACION);
                        xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
                    }

                    var SC_VB = parseInt(xId_index_td_val_scomplementario) + parseInt(xId_index_td_val_valorBeneficiario)

                    var provisorio = (parseInt(xId_index_td_val_prevision) - SC_VB);

                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_VALOR_BENEF = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();                            //1
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_VALOR_CS = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val();                                 //2
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_1 = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .tp_pago2`).val();                                               //3
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_OBS = "ate det tp obss";                                                                                                     //4 
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_NUM_BOL = 0;                                                                                                                    //5 
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();                                       //6
                    Mx_Dtt_examcof[x_id_pos_td].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_obsexam`).val();                                                 //7

                    $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).attr("data-tipo", Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_1);          //SE MARCA ID TIPO PAGO PARA DIFERENCIAR DE FONASA O PARTICULAR

                    if (provisorio < 0) {
                        alert("Rectifique");
                    } else {
                        console.log("AQUI 13");
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).val(parseInt(provisorio));

                        HOLAAAAAAAAAAA();
                    }
                });


                $(`#DataTable_pac2 tbody tr .td_scomplementario`).keyup(function EnterEvent(e) {                                                //POR FILA SEGURO COMPLEMENTARIO
                    e.stopImmediatePropagation();
                    var x_id_pos_td = $(this).parents("tr").attr('data-index');

                    if ($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val() == "") {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(0);
                    }

                    if ($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val() == "") {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val(0);
                    }

                    //var xId_index_td_val_documento = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();
                    var xId_index_td_val_scomplementario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val();
                    var xId_index_td_val_prevision = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).val();
                    var xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
                    var xId_index_td_val_valorapagar = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).val();

                    var SC_VB = parseInt(xId_index_td_val_scomplementario) + parseInt(xId_index_td_val_valorBeneficiario)

                    var provisorio = (parseInt(xId_index_td_val_prevision) - SC_VB);

                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_VALOR_BENEF = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();                            //1
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_VALOR_CS = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val();                                 //2
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_1 = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .tp_pago2`).val();                                               //3
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_OBS = "ate det tp obss";                                                                                                     //4 
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_NUM_BOL = 0;                                                                                                                    //5 
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();                                       //6
                    Mx_Dtt_examcof[x_id_pos_td].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_obsexam`).val();                                                 //7



                    if (provisorio < 0) {
                        alert("Rectifique");
                    } else {
                        console.log("AQUI 14");
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).val(parseInt(provisorio));

                        HOLAAAAAAAAAAA();
                    }


                    //$(".td_valorapagar").trigger("change")();

                    //$(".td_valorBeneficiario").trigger("change")();
                });

                $(`#DataTable_pac2 tbody tr .td_valorBeneficiario`).keyup(function EnterEvent(e) {                                                                    //POR BONIFICACION

                    console.log("beneficiario 1");
                    e.stopImmediatePropagation();
                    //var x_id_pos_td = $(this).parents("tr").attr('data-index');sd
                    //let x_id_pos_td_2 = $(`#DataTable_pac2 tbody tr[data-index =${i}]`).attr('data-index');a

                    var x_id_pos_td_2 = $(this).parents("tr").attr('data-index');
                    //let x_id_pos_td_2 = $(`#DataTable_pac2 tbody tr[data-index =${i}]`).attr('data-index');

                    if ($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val() == "") {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val(0);
                    }

                    if ($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val() == "") {
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val(0);
                    }

                    //var xId_index_td_val_documento = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();
                    var xId_index_td_val_scomplementario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val();
                    var xId_index_td_val_prevision = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_prevision`).val();
                    var xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val();
                    var xId_index_td_val_valorapagar = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorapagar`).val();

                    var SC_VB = parseInt(xId_index_td_val_scomplementario) + parseInt(xId_index_td_val_valorBeneficiario)

                    var provisorio = (parseInt(xId_index_td_val_prevision) - SC_VB);

                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_VALOR_BENEF = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val();                            //1
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_VALOR_CS = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val();                                 //2
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_TP_1 = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .tp_pago2`).val();                                               //3
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_TP_OBS = "ate det tp obss";                                                                                                       //4 
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_NUM_BOL = 0;                                                                                                                      //5 
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_documento`).val();                                       //6
                    Mx_Dtt_examcof[x_id_pos_td_2].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_obsexam`).val();                                                 //7

                    if (provisorio < 0) {
                        $(this).parents("tr").attr('data-index');

                        PASS_SAVE = 0;
                        $(this).css({ "border-color": "red" });
                        $(this).css({ "color": "red" });

                        $("#Lbl_tot_beneficiario").css({ "border-color": "red" });
                        $("#Lbl_tot_beneficiario").css({ "color": "red" });


                    } else {
                        console.log("AQUI 2");
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorapagar`).val(parseInt(provisorio));
                        PASS_SAVE = 1;
                        $(this).css({ "border-color": "#ccc" });
                        $(this).css({ "color": "#212529" });
                        $("#Lbl_tot_beneficiario").css({ "border-color": "#868e96" });
                        $("#Lbl_tot_beneficiario").css({ "color": "#495057" });
                        HOLAAAAAAAAAAA();
                    }

                    //$(".td_valorBeneficiario").trigger("change")();

                    //$(".td_valorapagar").trigger("change")();
                    //});

                });
                //-------------------------------------
            }       //<---------------------------






            actualizaValores();

            add_row();




            //$("input[data-id='" + xxid + "']").val(Mx_Dtt_exam03[0].CF_COD);
            //$("input[data-id='" + xxid + "']").parent().parent().children(".td_val1").text(Mx_Dtt_exam03[0].CF_DESC);
            //$("input[data-id='" + xxid + "']").parent().parent().children(".td_val2").text(Mx_Dtt_exam03[0].CF_DIAS);
            //$("input[data-id='" + xxid + "']").parent().parent().children(".td_val3").text(Mx_Dtt_exam03[0].CF_PRECIO_AMB);
            //$("input[data-id='" + xxid + "']").attr("data-cod", Mx_Dtt_exam03[0].CF_COD);
            //$("input[data-id='" + xxid + "']").parents("tr").find(`.tp_pago`).attr("data-id_pago", Mx_Dtt_exam03[0].ID_CODIGO_FONASA);
            //$("input[data-id='" + xxid + "']").parents("tr").find(`.tp_prevision`).attr("data-cod-exa", Mx_Dtt_exam03[0].CF_COD);
            //$("input[data-id='" + xxid + "']").parents("tr").find(`.tp_prevision`).attr("data-id_prevision", Mx_Dtt_exam03[0].ID_CODIGO_FONASA);

            //$("input[data-id='" + xxid + "']").parents("tr").find(`.tp_pago`).val(5);



            //$("input[data-cod='" + Mx_Dtt_exam03[0].CF_COD + "']").attr("data-id", Mx_Dtt_exam03[0].ID_CODIGO_FONASA);
            //Mx_Dtt_examcof.push(Mx_Dtt_exam03[0]);
            //Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
            //if (Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PAGO"] == undefined || Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PAGO"] == 0) {
            //    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PAGO"] = 5;
            //}
            //if (Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PREVE"] == undefined || Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PREVE"] == 0) {
            //    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_TP_PREVE"] = $('#Prevision').val();
            //}
            //add_row();

        } else {
            $("input[data-id='" + xxid + "']").val(xxcod);
        }
    } else if (Mx_Dtt_exam03_Desc.length > 1) {                      //SI VIENE MAS DE UN EXAMEN AL APRETAR ENTER

        $("#Div_Tabla4").empty();
        $("<table>", {
            "id": "DataTable_pac3",
            "class": "display",
            "width": "100%",
            "cellspacing": "0"
        }).appendTo("#Div_Tabla4");

        $("#DataTable_pac3").append(
            $("<thead>"),
            $("<tbody>")
        );
        $("#DataTable_pac3").attr("class", "table table-hover table-striped table-iris");
        $("#DataTable_pac3 thead").attr("class", "cabzera");
        $("#DataTable_pac3 thead").append(
            $("<tr>").append(

                $("<th>", { "class": "textoReducido" }).text("Nº"),
                $("<th>", { "class": "textoReducido" }).text("Codigo"),
                $("<th>", { "class": "textoReducido" }).text("Descripcion"),
                //$("<th>", { "class": "textoReducido" }).text("Valor Ambulatorio"),
                $("<th>", { "class": "textoReducido" }).text("Carga")

            )
        );
        for (let i = 0; i < Mx_Dtt_exam03_Desc.length; i++) {
            $("#DataTable_pac3 tbody").append(
                $("<tr>", {
                    "class": "textoReducido manito",
                    "padding": "1px !important",
                }).append(
                    $("<td>", {
                        "align": "left",
                        "class": "textoReducido"

                    }).text(i + 1),
                    $("<td>", {
                        "align": "left",
                        "class": "textoReducido"
                    }).text(Mx_Dtt_exam03_Desc[i].CF_COD),
                    $("<td>", {
                        "align": "left",
                        "class": "textoReducido"
                    }).text(Mx_Dtt_exam03_Desc[i].CF_DESC),
                    //$("<td>", {
                    //    "align": "center",
                    //    "class": "textoReducido"
                    //}).text(Mx_Dtt_exam03_Desc[i].CF_PRECIO_AMB),
                    $("<td>", {
                        "align": "center",
                        "class": "textoReducido"
                    }).html("<div class='checkbox checkbox-success sub_pp' style='margin-top:-5px;'><input type='checkbox' class='manitos2' id='F" + i + "' value='" + Mx_Dtt_exam03_Desc[i].ID_CODIGO_FONASA + "' /><label class='manitos2' for='F" + i + "'></label></div>")
                )
            )

        }
        $("#eModal3").modal();

    }

}

var Mx_Dtt = [
    {
        "ID_PROCEDENCIA": 0,
        "PROC_DESC": 0,
        "PROC_CANT_EXA": 0,
        "ID_ESTADO ": 0,
        "PRO_TIPO_I": 0,
        "TOTAL_ATE": 0,
        "PROC_CANT_EXA_BUSCA_DIAS": 0,
        "CONF_DIAS_FECHA_BUSCA_DIAS": 0,
        "CONF_DIAS_EXA_BUSCA_DIAS": 0,
        "ID_ESTADO_BUSCA_DIAS ": 0,
        "ID_PROCEDENCIA_BUSCA_DIAS": 0,
        "ID_CONF_DIAS_BUSCA_DIAS": 0
    }
];
var Mx_Ddl = [
    {
        "ID_PROCEDENCIA": "",
        "PROC_COD": "",
        "PROC_DESC": "",
        "ID_ESTADO": ""
    }
];
function Call_AJAX_Ddl() {



    $.ajax({
        "type": "POST",
        "url": "IN_PAC_MAN.aspx/Llenar_Ddl_LugarTM",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Ddl = JSON.parse(json_receiver);
                Fill_AJAX_Ddl();




            } else {



            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            alert("Error", str_Error);


        }
    });
}
//var Mx_Dtt2 = [
//   {
//       "ID_PACIENTE": 0,
//       "PAC_RUT": 0,
//       "PAC_NOMBRE": 0,
//       "PAC_APELLIDO ": 0,
//       "ID_SEXO": 0,
//       "TOTAL_ATE": 0,
//       "PAC_FNAC": 0,
//       "ID_NACIONALIDAD": 0,
//       "ID_REL_CIU_COM": 0,
//       "PAC_FONO1 ": 0,
//       "PAC_FONO2": 0,
//       "PAC_MOVIL1": 0,
//       "PAC_MOVIL2": 0,
//       "PAC_EMAIL": 0,
//       "PAC_OBS_PER": 0,
//       "PAC_DIR": 0,
//       "ID_DIAGNOSTICO ": 0,
//       "ID_ESTADO": 0,
//       "ID_CIUDAD": 0,
//       "PAC_OBS_PERMA": 0,
//       "ID_COMUNA": 0
//   }
//];
//Mx_Dtt2.length = 0;
function Ajax_busca_rut() {
    $("#checkBox2").prop('checked', false);//solo los del objeto #diasHabilitados
    $('#FUR').attr("disabled", true);
    $('#checkBox2').attr("disabled", true);
    $("#fur").css("pointer-events", "none");


    modal_show();
    var Data_Par = JSON.stringify({
        "rut": $("#rut").val()
    });
    $.ajax({
        "type": "POST",
        "url": "IN_PAC_MAN.aspx/Llenar_rut",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt2 = JSON.parse(json_receiver);

                Fill_DL_Rut();

                Hide_Modal();
                verrut = 1;





            } else {


                Hide_Modal();
                verrut = 2;

            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
}



//*--------------------------------------------------------------------------------------------------------------------------







//*-----------------------------------------------------------------------------------------------------------------------------*
var Mx_Dtt2_dni = [
    {
        "ID_PACIENTE": 0,
        "PAC_DNI": 0,
        "PAC_NOMBRE": 0,
        "PAC_APELLIDO ": 0,
        "ID_SEXO": 0,
        "TOTAL_ATE": 0,
        "PAC_FNAC": 0,
        "ID_NACIONALIDAD": 0,
        "ID_REL_CIU_COM": 0,
        "PAC_FONO1 ": 0,
        "PAC_FONO2": 0,
        "PAC_MOVIL1": 0,
        "PAC_MOVIL2": 0,
        "PAC_EMAIL": 0,
        "PAC_OBS_PER": 0,
        "PAC_DIR": 0,
        "ID_DIAGNOSTICO ": 0,
        "ID_ESTADO": 0,
        "ID_CIUDAD": 0,
        "PAC_OBS_PERMA": 0,
        "ID_COMUNA": 0
    }
];
Mx_Dtt2_dni.length = 0;
function Ajax_busca_dni() {
    $("#checkBox2").prop('checked', false);//solo los del objeto #diasHabilitados
    $('#FUR').attr("disabled", true);
    $('#checkBox2').attr("disabled", true);
    $("#fur").css("pointer-events", "none");


    modal_show();
    var Data_Par = JSON.stringify({
        "dni": $("#dni").val()
    });
    $.ajax({
        "type": "POST",
        "url": "IN_PAC_MAN_2.aspx/Llenar_dni",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt2_dni = JSON.parse(json_receiver);

                $('#dni').attr("disabled", true);
                $("#Nom").val(Mx_Dtt2_dni[0].PAC_NOMBRE);
                $("#Ape").val(Mx_Dtt2_dni[0].PAC_APELLIDO);
                $("#fecha").val(Mx_Dtt2_dni[0].PAC_FNAC);
                $("#Edad").val(function () {
                    var asd = moment($("#fecha").val()).format("DD-MM-YYYY");
                    var array = asd.split("-");
                    var total = "";
                    var dia = array[0];
                    var mes = array[1];
                    var ano = array[2];
                    if (dia < 10) { dia = "0" + dia; }
                    if (mes < 10) { mes = "0" + mes; }
                    // cogemos los valores actuales
                    var fecha_hoy = new Date();
                    var ahora_ano = fecha_hoy.getYear();
                    var ahora_mes = fecha_hoy.getMonth() + 1;
                    var ahora_dia = fecha_hoy.getDate();

                    // realizamos el calculo
                    var edad = (ahora_ano + 1900) - ano;
                    if (ahora_mes < mes) {
                        edad--;
                    }
                    if ((mes == ahora_mes) && (ahora_dia < dia)) {
                        edad--;
                    }
                    if (edad > 1900) {
                        edad -= 1900;
                    }
                    // calculamos los meses
                    var meses = 0;
                    if (ahora_mes > mes)
                        meses = ahora_mes - mes;
                    if (ahora_mes < mes)
                        meses = 12 - (mes - ahora_mes);
                    if (ahora_mes == mes && dia > ahora_dia)
                        meses = 11;
                    // calculamos los dias
                    var dias = 0;
                    total = String(edad + " Años");
                    if (ahora_dia > dia) {
                        dias = ahora_dia - dia;
                        total = String(edad + " Años");
                    }
                    if (ahora_dia < dia) {
                        ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                        dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                        total = String(edad + " Años");
                    }
                    return total
                });
                $("#sex").val(Mx_Dtt2_dni[0].ID_SEXO);//
                if (Mx_Dtt2_dni[0].ID_SEXO == 2) {
                    $('#checkBox2').removeAttr("disabled");
                }
                $("#Nacio").val(Mx_Dtt2_dni[0].ID_NACIONALIDAD);


                $("#telfijo").val(Mx_Dtt2_dni[0].PAC_FONO1);
                $("#Celular").val(Mx_Dtt2_dni[0].PAC_MOVIL1);
                Ajax_DataTable_examen02();
                Ajax_DataTable_examen02_Particular();
                $("#direccion").val(Mx_Dtt2_dni[0].PAC_DIR);
                $("#Email").val(Mx_Dtt2_dni[0].PAC_EMAIL);

                Hide_Modal();
                verrut = 1;
            } else {


                Hide_Modal();
                verrut = 2;

            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);
        }
    });
}
var Mx_DL_SEXO = [
    {
        "ID_SEXO": 0,
        "SEXO_COD": "asdf",
        "SEXO_DESC": "asdf",
        "ID_ESTADO": 0
    }
];
async function Ajax_DL_SEXO() {



    await $.ajax({
        "type": "POST",
        "url": "IN_PAC_MAN.aspx/Llenar_DL_SEXO",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_SEXO = JSON.parse(json_receiver);
                Fill_DL_SEXO();




            } else {



            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            cModal_Error("Error", str_Error);


        }
    });
}
var Mx_DL_NAC = [
    {
        "ID_NACIONALIDAD": 0,
        "NAC_COD": "asdf",
        "NAC_DESC": "asdf",
        "ID_ESTADO": 0
    }
];
async function Ajax_DL_NAC() {



    await $.ajax({
        "type": "POST",
        "url": "IN_PAC_MAN.aspx/Llenar_DL_NAC",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_NAC = JSON.parse(json_receiver);
                Fill_DL_NAC();




            } else {



            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            cModal_Error("Error", str_Error);


        }
    });
}
//--------------------------------------------------------------------------------------------
//--------------------------------------- JASON CIUDAD --------------------------------------------------------------------------|
var Mx_Ciudad = [
    {
        "ID_CIUDAD": 0,
        "CIU_COD": 0,
        "CIU_DESC": 0,
        "ID_ESTADO": 0
    }
];

async function Ajax_Ciudad() {


    await $.ajax({
        "type": "POST",
        "url": "IN_PAC_MAN.aspx/IRIS_WEBF_BUSCA_CIUDAD",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Ciudad = JSON.parse(json_receiver);
                Fill_Ddl_Cuidad();
                Ajax_Comuna();
                $(".block_wait").hide();


            } else {


            }
        },
        "error": function (response) {


        }
    });
}
//--------------------------------------- JASON COMUNA --------------------------------------------------------------------------|
var Mx_Comuna = [
    {
        "COM_DESC": 0,
        "ID_COMUNA": 0,
        "ID_ESTADO": 0,
        "ID_CIUDAD": 0,
        "ID_REL_CIU_COM": 0
    }
];
function Ajax_Comuna() {



    var Data_Par = JSON.stringify({
        "ID_CIU": $("#Cuidad").val()
    });

    $.ajax({
        "type": "POST",
        "url": "IN_PAC_MAN.aspx/IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Comuna = JSON.parse(json_receiver);
                Fill_Ddl_Comuna();
                $(".block_wait").hide();


            } else {


            }
        },
        "error": function (response) {


        }
    });
}
//--------------------------------------------------------------------------------------------
var Mx_DL_prevision = [
    {
        "ID_COMUNA": 0,
        "COM_COD": "asdf",
        "COM_DESC": "asdf",
        "ID_ESTADO": 0,
        "PREVE_PARTICULAR": 0
    }
];
async function Ajax_DL_prevision() {



    await $.ajax({
        "type": "POST",
        "url": "AGRE_EXA_ATE_NORMAL.aspx/Llenar_DL_prevision",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_prevision = JSON.parse(json_receiver);
                Fill_DL_prevision();




            } else {



            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            cModal_Error("Error", str_Error);


        }
    });
}
var Mx_DL_TP_ATE = [
    {
        "ID_TP_ATENCION": 0,
        "TP_ATE_COD": "asdf",
        "TP_ATE_DESC": "asdf",
        "ID_ESTADO": 0
    }
];
function Ajax_DL_TP_ATE() {



    $.ajax({
        "type": "POST",
        "url": "IN_PAC_MAN.aspx/Llenar_DL_aTENCIONES",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_TP_ATE = JSON.parse(json_receiver);
                Fill_DL_TP_ATE();




            } else {



            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            cModal_Error("Error", str_Error);


        }
    });
}
var Mx_DL_Sec = [
    {
        "ID_SECTOR": 0,
        "SECTOR_COD": "asdf",
        "SECTOR_DESC": "asdf",
        "ID_ESTADO": 0
    }
];
function Ajax_DL_sec() {



    $.ajax({
        "type": "POST",
        "url": "IN_PAC_MAN.aspx/Llenar_DL_Sectores",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_Sec = JSON.parse(json_receiver);
                Fill_DL_sec();




            } else {



            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            cModal_Error("Error", str_Error);


        }
    });
}
var Mx_DL_Programa = [
    {
        "ID_PROGRA": 0,
        "PROGRA_COD": "asdf",
        "PROGRA_DESC": "asdf",
        "ID_ESTADO": 0
    }
];
function Ajax_DL_programa() {



    $.ajax({
        "type": "POST",
        "url": "IN_PAC_MAN.aspx/Llenar_DL_Programa",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_Programa = JSON.parse(json_receiver);
                Fill_DL_programa();




            } else {



            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            cModal_Error("Error", str_Error);


        }
    });
}
var Mx_DL_DOC = [
    {
        "ID_DOCTOR": 0,
        "DOC_NOMBRE": "asdf",
        "DOC_APELLIDO": "asdf",
        "ID_ESTADO": 0
    }
];
function Ajax_DL_DOC() {



    $.ajax({
        "type": "POST",
        "url": "IN_PAC_MAN.aspx/Llenar_DL_DOC",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_DOC = JSON.parse(json_receiver);
                Fill_DL_DOC();




            } else {



            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            cModal_Error("Error", str_Error);


        }
    });
}
var Mx_DL_orden_ate = [
    {
        "ID_ORDEN": 0,
        "ORD_COD": "asdf",
        "ORD_DESC": "asdf",
        "ID_ESTADO": 0
    }
];
function Ajax_DL_orden_ate() {



    $.ajax({
        "type": "POST",
        "url": "IN_PAC_MAN.aspx/Llenar_DL_ordenATE",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_orden_ate = JSON.parse(json_receiver);
                Fill_DL_orden_ate();




            } else {



            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            cModal_Error("Error", str_Error);


        }
    });
}

function Fill_DL_orden_ate() {
    $("#PrioridadTM").empty();
    for (let y = 0; y < Mx_DL_orden_ate.length; ++y) {
        $("<option>", {
            "value": Mx_DL_orden_ate[y].ID_ORDEN
        }).text(Mx_DL_orden_ate[y].ORD_DESC).appendTo("#PrioridadTM");

    }
    $("#PrioridadTM").val(1);
}
function Fill_DL_DOC() {
    $("#Doctor").empty();
    for (let y = 0; y < Mx_DL_DOC.length; ++y) {
        $("<option>", {
            "value": Mx_DL_DOC[y].ID_DOCTOR
        }).text(Mx_DL_DOC[y].DOC_NOMBRE + " " + Mx_DL_DOC[y].DOC_APELLIDO).appendTo("#Doctor");
    }
}
function Fill_DL_programa() {
    $("#Programa").empty();
    for (let y = 0; y < Mx_DL_Programa.length; ++y) {
        $("<option>", {
            "value": Mx_DL_Programa[y].ID_PROGRA
        }).text(Mx_DL_Programa[y].PROGRA_DESC).appendTo("#Programa");
    }
}
function Fill_DL_sec() {
    $("#Sector").empty();
    for (let y = 0; y < Mx_DL_Sec.length; ++y) {
        $("<option>", {
            "value": Mx_DL_Sec[y].ID_SECTOR
        }).text(Mx_DL_Sec[y].SECTOR_DESC).appendTo("#Sector");
    }
}
function Fill_DL_TP_ATE() {
    $("#TipoAtencion").empty();
    for (let y = 0; y < Mx_DL_TP_ATE.length; ++y) {
        $("<option>", {
            "value": Mx_DL_TP_ATE[y].ID_TP_ATENCION
        }).text(Mx_DL_TP_ATE[y].TP_ATE_DESC).appendTo("#TipoAtencion");
    }
}
function Fill_DL_prevision() {
    $("#Prevision").empty();

    for (let y = 0; y < Mx_DL_prevision.length; ++y) {
        $("<option>", {
            "value": Mx_DL_prevision[y].ID_PREVE
        }).text(Mx_DL_prevision[y].PREVE_DESC).appendTo("#Prevision");

    }
    //Ajax_DataTable_examen02();
    //Ajax_DataTable_examen02_Particular();

}

function Fill_DL_Rut() {
    let FechaREE = moment(Mx_Dtt2[0].PAC_FNAC).format("YYYY-MM-DD");


    $('#rut').attr("disabled", true);
    $("#Nom").val(Mx_Dtt2[0].PAC_NOMBRE);
    $("#Ape").val(Mx_Dtt2[0].PAC_APELLIDO);
    $("#fecha").val(FechaREE);
    $("#Edad").val(function () {
        var asd = moment($("#fecha").val()).format("DD-MM-YYYY");
        var array = asd.split("-");
        var total = "";
        var dia = array[0];
        var mes = array[1];
        var ano = array[2];
        if (dia < 10) { dia = "0" + dia; }
        if (mes < 10) { mes = "0" + mes; }
        // cogemos los valores actuales
        var fecha_hoy = new Date();
        var ahora_ano = fecha_hoy.getYear();
        var ahora_mes = fecha_hoy.getMonth() + 1;
        var ahora_dia = fecha_hoy.getDate();

        // realizamos el calculo
        var edad = (ahora_ano + 1900) - ano;
        if (ahora_mes < mes) {
            edad--;
        }
        if ((mes == ahora_mes) && (ahora_dia < dia)) {
            edad--;
        }
        if (edad > 1900) {
            edad -= 1900;
        }
        // calculamos los meses
        var meses = 0;
        if (ahora_mes > mes)
            meses = ahora_mes - mes;
        if (ahora_mes < mes)
            meses = 12 - (mes - ahora_mes);
        if (ahora_mes == mes && dia > ahora_dia)
            meses = 11;
        // calculamos los dias
        var dias = 0;
        total = String(edad + " Años");
        if (ahora_dia > dia) {
            dias = ahora_dia - dia;
            total = String(edad + " Años");
        }
        if (ahora_dia < dia) {
            ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
            dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
            total = String(edad + " Años");
        }
        return total
    });
    $("#sex").val(Mx_Dtt2[0].ID_SEXO);//
    if (Mx_Dtt2[0].ID_SEXO == 2) {
        $('#checkBox2').removeAttr("disabled");
    }
    $("#Nacio").val(Mx_Dtt2[0].ID_NACIONALIDAD);
    $("#telfijo").val(Mx_Dtt2[0].PAC_FONO1);
    $("#Celular").val(Mx_Dtt2[0].PAC_MOVIL1);
    Ajax_DataTable_examen02();
    Ajax_DataTable_examen02_Particular();
    $("#direccion").val(Mx_Dtt2[0].PAC_DIR);
    $("#Email").val(Mx_Dtt2[0].PAC_EMAIL);

};

function Fill_AJAX_Ddl() {
    $("#Procedencia").empty();

    var procee = Galletas.getGalleta("USU_ID_PROC");
    if (procee == 0) {
        Mx_Ddl.forEach(aaa => {
            $("<option>",
                {
                    "value": aaa.ID_PROCEDENCIA
                }
            ).text(aaa.PROC_DESC).appendTo("#Procedencia");
        });
    }
    else {
        Mx_Ddl.forEach(aaa => {
            if (aaa.ID_PROCEDENCIA == procee) {
                $("<option>",
                    {
                        "value": aaa.ID_PROCEDENCIA
                    }
                ).text(aaa.PROC_DESC).appendTo("#Procedencia");
            }

        });
    }
    Ajax_DataTable();
};

//-----------------------------------------------------------------------------------------------------/
//Llenar DropDownList Ciudad
function Fill_Ddl_Cuidad() {
    $("#Cuidad").empty();
    for (let y = 0; y < Mx_Ciudad.length; ++y) {
        $("<option>", {
            "value": Mx_Ciudad[y].ID_CIUDAD
        }).text(Mx_Ciudad[y].CIU_DESC).appendTo("#Cuidad");
    }
};
//Llenar DropDownList Comuna
function Fill_Ddl_Comuna() {
    $("#Comuna").empty();
    for (let y = 0; y < Mx_Comuna.length; ++y) {
        $("<option>", {
            "value": Mx_Comuna[y].ID_REL_CIU_COM
        }).text(Mx_Comuna[y].COM_DESC).appendTo("#Comuna");
    }
};
//-------------------------------------------------------------------------------------------------------/
var Mx_Dtt_4556 = [
    {
        "ID_PROCEDENCIA": 0,
        "PROC_DESC": 0,
        "PROC_CANT_EXA": 0,
        "ID_ESTADO ": 0,
        "PRO_TIPO_I": 0,
        "TOTAL_ATE": 0,
        "PROC_CANT_EXA_BUSCA_DIAS": 0,
        "CONF_DIAS_FECHA_BUSCA_DIAS": 0,
        "CONF_DIAS_EXA_BUSCA_DIAS": 0,
        "ID_ESTADO_BUSCA_DIAS ": 0,
        "ID_PROCEDENCIA_BUSCA_DIAS": 0,
        "ID_CONF_DIAS_BUSCA_DIAS": 0,


        "AGEND_CUPO_NORMAL": 0,
        "AGEND_PRIORITARIO": 0,
        "AGEND_ESPONTANEO": 0,
        "TOTAL_AGEND_CUPO_NORMAL ": 0,
        "TOTAL_AGEND_PRIORITARIO": 0,
        "TOTAL_AGEND_ESPONTANEO": 0
    }
];

function Ajax_DataTable() {




    var Data_Par = JSON.stringify({
        "fecha": "ssssss",
        "id": $("#Procedencia").val()
    });

    $.ajax({
        "type": "POST",
        "url": "AGRE_EXA_ATE_NORMAL.aspx/Llenar_DataTable",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt_4556 = JSON.parse(json_receiver);
                Fill_DataTable();




            } else {


                Hide_Modal();

                //$("#EM2 h5").text("Error:");
                //$("#button_modal").attr("class", "btn btn-danger");
                //$("#EM2 p").text("Sin resultados");
                //$("#EM2").modal();
            }
            //$("#Id_Conte").show();
            //$(".block_wait").fadeOut(500);
        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
}

function Fill_DL_SEXO() {
    $("#sex").empty();

    $("<option>", {
        "value": 0
    }).text("Seleccionar").appendTo("#sex");
    for (let y = 0; y < Mx_DL_SEXO.length; ++y) {
        $("<option>", {
            "value": Mx_DL_SEXO[y].ID_SEXO
        }).text(Mx_DL_SEXO[y].SEXO_DESC).appendTo("#sex");
    }
    if (Mx_Detalle_ate.proparra1[0].SEXO_DESC == 'Masculino') {
        $("#sex").val(1);
    } else {

        $("#sex").val(2);
    }
};
function Fill_DL_NAC() {
    $("#Nacio").empty();

    $("<option>", {
        "value": 0
    }).text("Seleccionar").appendTo("#Nacio");
    for (let y = 0; y < Mx_DL_NAC.length; ++y) {
        $("<option>", {
            "value": Mx_DL_NAC[y].ID_NACIONALIDAD
        }).text(Mx_DL_NAC[y].NAC_DESC).appendTo("#Nacio");
    }
    $("#Nacio").val(Mx_Detalle_ate.proparra1[0].id_Nacionalidad);
};
let objAJAX_Ciud = 0;
var arrCiud = [{
    "text": "",
    "value": 0
}];
async function fn_Req_Ciud() {
    objAJAX_Ciud = await $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Data_Sel_Ciudad",
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": async (resp) => {
            arrCiud = resp.d;

            //Llenar Ddl
            $("#Cuidad").empty();
            if (arrCiud.length > 0) {
                arrCiud.forEach((Item) => {
                    $("#Cuidad").append(
                        $("<option>", {
                            "value": Item.value
                        }).text(Item.text)
                    );
                });
            }

        },
        "error": (fail) => {
            $("mdlError").modal();

            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
    });
};

let objAJAX_Comuna = 0;
var arrComuna = [{
    "text": "",
    "value": 0
}];

async function fn_Req_Comuna(ID_COM) {
    var objParam = JSON.stringify({
        "ID_CIUD": $("#Cuidad").val()
    });

    objAJAX_Comuna = await $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Data_Sel_Comuna",
        "data": objParam,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": (resp) => {
            arrComuna = resp.d;

            //Llenar Ddl
            $("#Comuna").empty();
            if (arrComuna.length > 0) {
                arrComuna.forEach((Item) => {
                    $("#Comuna").append(
                        $("<option>", {
                            "value": Item.value
                        }).text(Item.text)
                    );
                });

                if (ID_COM != null) {
                    $("#Comuna").val(ID_COM);
                }

                //if (initializing == true) {
                //    fn_Req_User_Location();
                //    initializing = false;
                //}
            }
        },
        "error": (fail) => {
            $("mdlError").modal();

            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
    });
};

let objAJAX_Location = 0;
var objLocation = {
    "ID_CIUDAD": 0,
    "ID_COMUNA": 0
};

function fn_Req_User_Location() {
    var objParam = JSON.stringify({
        "ID_USER": Galletas.getGalleta("ID_USER")
    });

    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Get_Ciu_Com_User",
        "data": objParam,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": async (resp) => {
            objLocation = resp.d;
            if ((objLocation.ID_CIUDAD != 0) && (objLocation.ID_COMUNA != 0)) {
                $("#Cuidad").val(objLocation.ID_CIUDAD);
                await fn_Req_Comuna(objLocation.ID_COMUNA);
            }
        },
        "error": (fail) => {
            $("mdlError").modal();

            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
    });
};
/// llenado examenes modal
function Fill_DataTable_exam02() {
    $("#Div_Tabla2").empty();
    $("<table>", {
        "id": "DataTable_pac",
        "class": "display",
        "width": "100%",
        "cellspacing": "0"
    }).appendTo("#Div_Tabla2");

    $("#DataTable_pac").append(
        $("<thead>"),
        $("<tbody>")
    );
    $("#DataTable_pac").attr("class", "table table-hover table-striped table-iris");
    $("#DataTable_pac thead").attr("class", "cabzera");
    $("#DataTable_pac thead").append(
        $("<tr>").append(

            $("<th>", { "class": "textoReducido" }).text("Nº"),
            $("<th>", { "class": "textoReducido" }).text("Codigo"),
            $("<th>", { "class": "textoReducido" }).text("Descripcion"),
            //$("<th>", { "class": "textoReducido" }).text("Valor Ambulatorio"),
            $("<th>", { "class": "textoReducido" }).text("Carga")

        )
    );
    for (let i = 0; i < Mx_Dtt_exam02.length; i++) {
        $("#DataTable_pac tbody").append(
            $("<tr>", {
                "class": "textoReducido manito",
                "padding": "1px !important",
            }).append(
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido"

                }).text(i + 1),
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido"
                }).text(Mx_Dtt_exam02[i].CF_COD),
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido"
                }).text(Mx_Dtt_exam02[i].CF_DESC),
                //$("<td>", {
                //    "align": "center",
                //    "class": "textoReducido"
                //}).text(Mx_Dtt_exam02[i].CF_PRECIO_AMB),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido"
                }).html("<div class='checkbox checkbox-success pp' style='margin-top:-5px;'><input type='checkbox' class='manitos2' id='H" + i + "' value='" + Mx_Dtt_exam02[i].ID_CODIGO_FONASA + "' /><label class='manitos2' for='H" + i + "'></label></div>")
            )
        )
    }
    $("#DataTable_pac").DataTable({
        "searching": true,
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

}
/**
 * Busca si el examen con un código existe en la lista de agregados y bloquea uno o varios exámenes más
 * @param {string} codigoPrerequisite El código que si se encuentra, se bloquea uno o varios exámenes automáticamente.
 * @param {string | Array.<string>} codigoBloquear Acepta un string o un array con strings representando los códigos que se quieren bloquear automáticamente si se encuentra el examen que se pasa en codigoPrerequisite.
 */
const buscaUnExamenBloqueaOtros = (codigoPrerequisite, codigoBloquear) => {
    codigoBloquear = typeof codigoBloquear == "string" ? [codigoBloquear] : codigoBloquear;
    const existeExamenBuscado = Mx_Dtt_examcof.some(item => item.CF_COD == codigoPrerequisite);
    if (!existeExamenBuscado) return;
    let existeExamenesBloquear = Mx_Dtt_examcof.some(item => codigoBloquear.includes(item.CF_COD));
    if (!existeExamenesBloquear) return;
    Mx_Dtt_examcof = Mx_Dtt_examcof.filter(item => !codigoBloquear.includes(item.CF_COD));
    const { CF_DESC: nombreExamenEncontrado } = Mx_Dtt_exam02.find(item => item.CF_COD == codigoPrerequisite);
    Swal.fire({
        icon: "info",
        title: `${nombreExamenEncontrado} detectado`,
        html: `Se intentó cargar el o los siguientes exámenes: <br/><br/>
               ${codigoBloquear.map(codigo => "• " + Mx_Dtt_exam02.find(item => item.CF_COD == codigo).CF_DESC + " <br/>").join(" ")} <br/>
               Las determinaciones de estos exámenes están incluidas dentro del ${nombreExamenEncontrado} y se han quitado para evitar redundancia.`
    });

}

/**
 * Busca si el examen con un código existe en la lista de agregados y agrega uno o varios exámenes más
 * @param {string} codigoPrerequisite El código que si se encuentra, se agrega uno o varios exámenes automáticamente.
 * @param {string | Array.<string>} codigoAgregar Acepta un string o un array con strings representando los códigos que se quieren agregar automáticamente si se encuentra el examen que se pasa en codigoPrerequisite.
 */
const buscaUnExamenAgregaOtro = (codigoPrerequisite, codigoAgregar) => {
    codigoAgregar = typeof codigoAgregar == "string" ? [codigoAgregar] : codigoAgregar;
    const existeExamenBuscado = Mx_Dtt_examcof.some(item => item.CF_COD == codigoPrerequisite);
    if (!existeExamenBuscado) return;
    codigoAgregar.forEach(codigo => {
        const examenAgregar = Mx_Dtt_exam02.find(item => item.CF_COD == codigo);
        if (!Mx_Dtt_examcof.some(item => item.CF_COD == codigo)) {
            examenAgregar.CF_ESTADO_EXAMEN = "Activo";
            Mx_Dtt_examcof.push(examenAgregar);
        }
    })
}
/**
 * Busca si se cargó o se está intentando cargar un VIH, si se encuentra pregunta si se quiere colocar el VIH y sacar el resto o al revés.
 */
const buscaVIHCargado = async () => {
    const existeVIH = Mx_Dtt_examcof.some(item => item.CF_COD == "0306169" || item.CF_COD == "TVIH");
    if (!existeVIH) {
        return false;
    }
    //en agrega o quita exam esto siempre lo quita porque un vih no puede ir con otros exémenes
    Mx_Dtt_examcof = Mx_Dtt_examcof.filter(item => item.CF_COD != "0306169" && item.CF_COD != "TVIH");
    Swal.fire({
        icon: "warning",
        title: `VIH detectado`,
        html: `No es posible cargar exámenes VIH por este módulo.`
    });
    return false;
}

//NUEVA TABLA CON BOTON DE EXÁMENES <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
async function fill_llenado_tabla() {
    buscaVIHCargado();
    buscaUnExamenAgregaOtro("0302075", "0302047");                // Perfil Bioquímico => Glicemia
    buscaUnExamenAgregaOtro("0301045--1", "0301086");             // Hemograma => VHS
    buscaUnExamenAgregaOtro("0302076", "0301059");                // Perfil Hepático => Tiempo de Protrombina (TP)+INR
    buscaUnExamenBloqueaOtros("0302075", ["0302076", "0302034"]); // Perfil Bioquímico => Perfil Lipídico y Perfil Hepático
    buscaUnExamenBloqueaOtros("0302048-3", "0303031");            // Prueba de Tolerancia a la Glucosa => Curva de Insulina (Basal,120)
    $("#DataTable_pac2 tbody").empty();
    console.log("enter fill_llenado_tabla");
    $("#DataTable_pac2 tbody").empty();

    for (let rrr = 0; rrr < Mx_Dtt_examcof.length; rrr++) {
        console.log("PARTI?: " + Mx_Dtt_examcof[rrr].CF_PART_TIPO);

        if (Mx_Dtt_examcof[rrr].CF_PART_TIPO != null && Mx_Dtt_examcof[rrr].CF_PART_TIPO != 0 && Mx_Dtt_examcof[rrr].CF_PART_TIPO != "") {

            Mx_Dtt_examcof[rrr]["CF_TP_PAGO"] = 20;
            Mx_Dtt_examcof[rrr]["ATE_DET_TP_1"] = 20;

            for (let x = 0; x < Mx_Dtt_exam02_Particular.length; x++) {
                if (Mx_Dtt_exam02_Particular[x].ID_CODIGO_FONASA == Mx_Dtt_examcof[rrr].ID_CODIGO_FONASA) {
                    Mx_Dtt_examcof[rrr].CF_PRECIO_AMB = Mx_Dtt_exam02_Particular[x].CF_PRECIO_AMB;
                    Mx_Dtt_examcof[rrr].CF_BONIFICACION = 0;
                }
            }
            console.log("PARTICULAR");
        } else {
            console.log("NO particular");
        }
    }

    acti_cf_part = 0;


    for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
        if (Mx_Dtt_examcof[i]["ATE_DET_TP_1"] == undefined || Mx_Dtt_examcof[i]["ATE_DET_TP_1"] == 0) {
            Mx_Dtt_examcof[i]["CF_TP_PAGO"] = 5;
            Mx_Dtt_examcof[i]["ATE_DET_TP_1"] = 5;
        }
        if (Mx_Dtt_examcof[i]["CF_TP_PREVE"] == undefined || Mx_Dtt_examcof[i]["CF_TP_PREVE"] == 0) {
            Mx_Dtt_examcof[i]["CF_TP_PREVE"] = $('#Prevision').val();
        }
        $("#DataTable_pac2 tbody").append(
            $("<tr>", {
                "class": "textoReducido manito negrita",
                "padding": "1px !important",
                "data-index": i
            }).append(
                $("<td>", {                                                         // CODIGO FONASA
                    "align": "left",
                    "class": "textoReducido"
                }).html((function () {
                    //Retornar un campo input
                    return $("<input>", {
                        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        "data-cod": Mx_Dtt_examcof[i].CF_COD,
                        "class": "td_input td_inputSearch negrita",
                        "value": Mx_Dtt_examcof[i].CF_COD
                    })
                }())),

                $("<td>", {                                                         //CF DESC
                    "align": "left",
                    "class": "textoReducido td_val1 negrita"
                }).text(Mx_Dtt_examcof[i].CF_DESC),













                //$("<td>", {                                                             //DROP TIPO DE PAGO
                //    "align": "center"
                //}).append(
                //    $("<select>", {
                //        class: "form-control textoReducido tp_pago tp_pago2 negrita",
                //        "data-id_pago": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                //        "data-cod-exa": Mx_Dtt_examcof[i].CF_COD,
                //        "data-posicion": i,
                //        "height": "calc(1.89rem + 1px)"

                //    }).append(function () {
                //        let xxx = [];

                //        if (Mx_Dtt_examcof[i].CF_PART_TIPO == 1) {
                //            for (let x = 0; x < arrPago.length; x++) {
                //                if (arrPago[x].ID_TP_PAGO == 20 || arrPago[x].ID_TP_PAGO == 3) {
                //                    xxx.push($("<option>", {
                //                        value: arrPago[x].ID_TP_PAGO
                //                    }).text(arrPago[x].TP_PAGO_DESC));
                //                }
                //            }

                //            return xxx;
                //        } else {
                //            for (let x = 0; x < arrPago.length; x++) {
                //                xxx.push($("<option>", {
                //                    value: arrPago[x].ID_TP_PAGO
                //                }).text(arrPago[x].TP_PAGO_DESC));
                //            }

                //            return xxx;
                //        }

                //    }())),
                //$("<td>", {                                                          //DIAS
                //    "align": "center",
                //    "class": "textoReducido carlos_sama td_val2 negrita"
                //}).text(Mx_Dtt_examcof[i].CF_DIAS),
                //$("<td>", {                                                         //OBSERVACION EXAMEN
                //    "align": "right",
                //    "class": "textoReducido negrita"
                //}).html((function () {
                //    //Retornar un campo input
                //    return $("<input>", {
                //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                //        "class": "td_input carlos_sama textDerecho borderRound td_obsexam negrita",
                //        "value": ""
                //    })
                //}())),
                //$("<td>", {                                                         //DOCUMENTO
                //    "align": "right",
                //    "class": "textoReducido negrita"
                //}).html((function () {
                //    //Retornar un campo input
                //    return $("<input>", {
                //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                //        "class": "td_input carlos_sama textDerecho borderRound td_documento negrita",
                //        "onkeydown": "return jsDecimals(event)",
                //        //"disabled": "disabled",
                //        "value": ""
                //    })
                //}())),
                //$("<td>", {                                                         //SEGURO COMPLEMENTARIO
                //    "align": "right",
                //    "class": "textoReducido"
                //}).html((function () {
                //    //Retornar un campo input
                //    return $("<input>", {
                //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                //        "class": "td_input  carlos_sama textDerecho borderRound td_scomplementario negrita",
                //        "maxlength": "7",
                //        "onkeydown": "return jsDecimals(event)",
                //        //"disabled": "disabled",
                //        "value": "0"
                //    })
                //}())),
                //$("<td>", {                                                         //VALOR PREVISION
                //    "align": "right",
                //    "class": "textoReducido negrita"
                //}).html((function () {
                //    //Retornar un campo input
                //    return $("<input>", {
                //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                //        "class": "td_input textoReducido carlos_sama textDerecho borderRound td_val3 dark_text td_prevision negrita",
                //        "disabled": "disabled",
                //        "maxlength": "7",
                //        "onkeydown": "return jsDecimals(event)",
                //        "value": Mx_Dtt_examcof[i].CF_PRECIO_AMB
                //    })
                //}())),
                ////$("<td>", {                                                             //VALOR PREVISION
                ////    "align": "right",
                ////    "class": "textoReducido td_val3 dark_text td_prevision"
                ////}).text(Mx_Dtt_examcof[i].CF_PRECIO_AMB),
                //$("<td>", {                                                         //VALOR BENEFICIARIO/BONIFICACION
                //    "align": "right",
                //    "class": "textoReducido negrita"
                //}).html((function () {
                //    //Retornar un campo input
                //    return $("<input>", {
                //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                //        "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                //        "class": "td_input textDerecho carlos_sama borderRound td_valorBeneficiario negrita",
                //        "maxlength": "7",
                //        "onkeydown": "return jsDecimals(event)",
                //        //"disabled": "disabled",
                //        "value": Mx_Dtt_examcof[i].CF_BONIFICACION
                //    })
                //}())),
                //$("<td>", {                                                         //VALOR A PAGAR 
                //    "align": "right",
                //    "class": "textoReducido"
                //}).html((function () {
                //    //Retornar un campo input
                //    return $("<input>", {
                //        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                //        "data-cod": "",//,Mx_Dtt_examcof[i].CF_COD,
                //        "class": "td_input textDerecho carlos_sama dark_text borderRound td_valorapagar negrita",
                //        "maxlength": "7",
                //        "onkeydown": "return jsDecimals(event)",
                //        "disabled": "disabled",
                //        "value": (Mx_Dtt_examcof[i].CF_PRECIO_AMB - Mx_Dtt_examcof[i].CF_BONIFICACION)
                //    })
                //}())),









                $("<td>", {
                    "align": "center"
                }).html("<button type='button' class='btn btn-default btn-xs borrar negrita' value='Eliminar' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"),
                $("<td>", {
                    "align": "center"
                }).html(function () {


                    if (Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN == "Activo") {
                        return "<button type='button' class='btn btn-print btn-xs CEstado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>"
                    } else {
                        return "<button type='button' class='btn btn-success btn-xs Activado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Activo</button>"
                    }

                }())
            )
        )

        let xindex = $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_pago`).val(Mx_Dtt_examcof[i].ATE_DET_TP_1);
        let xindex3 = $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_prevision`).val(Mx_Dtt_examcof[i].CF_TP_PREVE);

        ////NUEVO FIX
        //$(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_pago2`).val(Mx_Dtt_examcof[i].ATE_DET_TP_1);
        //$(`#DataTable_pac2 tbody tr[data-index =${i}] .td_prevision`).val(Mx_Dtt_examcof[i].CF_PRECIO_AMB);
        //$(`#DataTable_pac2 tbody tr[data-index =${i}] .td_valorBeneficiario`).val(Mx_Dtt_examcof[i].CF_BONIFICACION);
        ////FIN NUEVO FIX



        Mx_Dtt_examcof[i].ATE_DET_VALOR_BENEF = $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_valorBeneficiario`).val();                            //1
        Mx_Dtt_examcof[i].ATE_DET_VALOR_CS = $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_scomplementario`).val();                                 //2
        Mx_Dtt_examcof[i].ATE_DET_TP_1 = $(`#DataTable_pac2 tbody tr[data-index =${i}] .tp_pago2`).val();                                               //3
        Mx_Dtt_examcof[i].ATE_DET_TP_OBS = "ate det tp obss";                                                                                           //4 
        Mx_Dtt_examcof[i].ATE_DET_NUM_BOL = 0;                                                                                                          //5 
        Mx_Dtt_examcof[i].ATE_DET_NUM_BONO = "";                                                                                                        //6
        Mx_Dtt_examcof[i].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_obsexam`).val();                                                 //7

        $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_valorapagar`).attr("data-tipo", Mx_Dtt_examcof[i].ATE_DET_TP_1);

        //----------------------------------        
        //CAMBIO NUM BOLETA
        $(`#DataTable_pac2 tbody tr .td_documento`).change(function EnterEvent(e) {                                                                         //CAMBIO EN OBS EXAMEN
            console.log("cambio num bono 1");
            e.stopImmediatePropagation();
            var x_id_pos_td_num_bono = $(this).parents("tr").attr('data-index');

            if (x_id_pos_td_num_bono == 0) {
                if (Mx_Dtt_examcof.length == 1) {
                    if (Mx_Dtt_examcof[x_id_pos_td_num_bono].ATE_DET_TP_1 == 1 || Mx_Dtt_examcof[x_id_pos_td_num_bono].ATE_DET_TP_1 == 20) {
                        Mx_Dtt_examcof[x_id_pos_td_num_bono].ATE_DET_NUM_BONO = "";
                        $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bono}] .td_documento`).val("");
                        console.log("A");
                    } else {
                        Mx_Dtt_examcof[x_id_pos_td_num_bono].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bono}] .td_documento`).val();
                        console.log("B");
                    }

                } else {
                    for (let i = 0; i < Mx_Dtt_examcof.length; i++) {

                        if (Mx_Dtt_examcof[i].ATE_DET_TP_1 == 1 || Mx_Dtt_examcof[i].ATE_DET_TP_1 == 20) {
                            Mx_Dtt_examcof[i].ATE_DET_NUM_BONO = "";
                            $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_documento`).val("");
                            console.log("C");
                        } else {
                            Mx_Dtt_examcof[i].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bono}] .td_documento`).val();
                            $(`#DataTable_pac2 tbody tr[data-index =${i}] .td_documento`).val($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bono}] .td_documento`).val());
                            console.log("D");
                        }

                    }
                }
            } else {
                if (Mx_Dtt_examcof[x_id_pos_td_num_bono].ATE_DET_TP_1 == 1 || Mx_Dtt_examcof[x_id_pos_td_num_bono].ATE_DET_TP_1 == 20) {
                    Mx_Dtt_examcof[x_id_pos_td_num_bono].ATE_DET_NUM_BONO = "";
                    $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bono}] .td_documento`).val("");
                    console.log("E");
                } else {
                    Mx_Dtt_examcof[x_id_pos_td_num_bono].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_num_bono}] .td_documento`).val();
                    console.log("F");
                }
            }                                                        //7
        });

        //----------------------------------        
        //CAMBIO EN OBS EXAMEN
        $(`#DataTable_pac2 tbody tr .td_obsexam`).change(function EnterEvent(e) {                                                                         //CAMBIO EN OBS EXAMEN
            console.log("cambio obs examen 1");
            e.stopImmediatePropagation();
            var x_id_pos_td_obs = $(this).parents("tr").attr('data-index');

            Mx_Dtt_examcof[x_id_pos_td_obs].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_obs}] .td_obsexam`).val();                                                           //7
        });

        //CAMBIO EN DROP TIPO DEPAGO
        $(`#DataTable_pac2 tbody tr .tp_pago2`).change(function EnterEvent(e) {                                                                         //CAMBIO EN DROP TIPO DE PAGO
            console.log("cambio tp 1");
            e.stopImmediatePropagation();
            var x_id_pos_td = $(this).parents("tr").attr('data-index');
            var x_id_codFonasa_td = $(this).attr('data-id_pago');
            var x_id_tpago_td = $(this).val();

            console.log(x_id_pos_td, x_id_codFonasa_td, x_id_tpago_td);

            //var xId_index_td_val_documento = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();
            var xId_index_td_val_scomplementario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val();
            var xId_index_td_val_prevision = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).val();
            var xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
            var xId_index_td_val_valorapagar = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).val();

            //if (x_id_tpago_td == 1 || x_id_tpago_td == 20) {
            //    xId_index_td_val_prevision = ddl_Change_onTable(x_id_pos_td, x_id_codFonasa_td, x_id_tpago_td);                                   //FUNCION CAMBIO VALOR        

            //    $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).text(xId_index_td_val_prevision);
            //} else {
            //    xId_index_td_val_prevision = Mx_Dtt_examcof[x_id_pos_td].CF_PRECIO_AMB;
            //    $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).text(xId_index_td_val_prevision);
            //}

            xId_index_td_val_prevision = ddl_Change_onTable(x_id_pos_td, x_id_codFonasa_td, x_id_tpago_td);                                         //FUNCION CAMBIO VALOR     
            $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_prevision`).val(xId_index_td_val_prevision);

            if (x_id_tpago_td == 1 || x_id_tpago_td == 11 || x_id_tpago_td == 20 || x_id_tpago_td == 8) {
                xId_index_td_val_valorBeneficiario = 0;
                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(0);
            } else if (x_id_tpago_td == 4) {
                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(Mx_Dtt_examcof[x_id_pos_td].CF_PRECIO_AMB);
                xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
            } else {
                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(Mx_Dtt_examcof[x_id_pos_td].CF_BONIFICACION);
                xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
            }

            var SC_VB = parseInt(xId_index_td_val_scomplementario) + parseInt(xId_index_td_val_valorBeneficiario)

            var provisorio = (parseInt(xId_index_td_val_prevision) - SC_VB);

            Mx_Dtt_examcof[x_id_pos_td].ATE_DET_VALOR_BENEF = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();                            //1
            Mx_Dtt_examcof[x_id_pos_td].ATE_DET_VALOR_CS = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val();                                 //2
            Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_1 = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .tp_pago2`).val();                                               //3
            Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_OBS = "ate det tp obss";                                                                                                     //4 
            Mx_Dtt_examcof[x_id_pos_td].ATE_DET_NUM_BOL = 0;                                                                                                                    //5 
            Mx_Dtt_examcof[x_id_pos_td].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();                                       //6
            Mx_Dtt_examcof[x_id_pos_td].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_obsexam`).val();                                                           //7

            $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).attr("data-tipo", Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_1);          //SE MARCA ID TIPO PAGO PARA DIFERENCIAR DE FONASA O PARTICULAR

            if (provisorio < 0) {
                console.log("MALO EN TP PAGO");
                $(this).parents("tr").attr('data-index');

                PASS_SAVE = 0;

                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).css({ "border-color": "red" });
                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).css({ "color": "red" });

                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).css({ "border-color": "red" });
                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).css({ "color": "red" });

                $("#Lbl_tot_beneficiario").css({ "border-color": "red" });
                $("#Lbl_tot_beneficiario").css({ "color": "red" });

            } else {
                console.log("BUENO EN TP PAGO");
                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).val(parseInt(provisorio));

                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).css({ "border-color": "#ccc" });
                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).css({ "color": "#212529" });

                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).css({ "border-color": "#ccc" });
                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).css({ "color": "#212529" });

                $("#Lbl_tot_beneficiario").css({ "border-color": "#868e96" });
                $("#Lbl_tot_beneficiario").css({ "color": "#495057" });

                PASS_SAVE = 1;
                HOLAAAAAAAAAAA();
            }

            $("#Lbl_tot_beneficiario").trigger("keyup");
        });


        $(`#DataTable_pac2 tbody tr .td_scomplementario`).keyup(function EnterEvent(e) {                                                                    //POR FILA SEGURO COMPLEMENTARIO

            console.log("s complementario 1");
            e.stopImmediatePropagation();
            //var x_id_pos_td = $(this).parents("tr").attr('data-index');sd
            //let x_id_pos_td_2 = $(`#DataTable_pac2 tbody tr[data-index =${i}]`).attr('data-index');a

            var x_id_pos_td_2 = $(this).parents("tr").attr('data-index');
            //let x_id_pos_td_2 = $(`#DataTable_pac2 tbody tr[data-index =${i}]`).attr('data-index');

            if ($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val() == "") {
                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val(0);
            }

            if ($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val() == "") {
                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val(0);
            }

            //var xId_index_td_val_documento = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();
            var xId_index_td_val_scomplementario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val();
            var xId_index_td_val_prevision = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_prevision`).val();
            var xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val();
            var xId_index_td_val_valorapagar = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorapagar`).val();

            var SC_VB = parseInt(xId_index_td_val_scomplementario) + parseInt(xId_index_td_val_valorBeneficiario)

            var provisorio = (parseInt(xId_index_td_val_prevision) - SC_VB);

            Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_VALOR_BENEF = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val();                            //1
            Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_VALOR_CS = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val();                                 //2
            Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_TP_1 = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .tp_pago2`).val();                                               //3
            Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_TP_OBS = "ate det tp obss";                                                                                                       //4 
            Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_NUM_BOL = 0;                                                                                                                      //5 
            Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_documento`).val();                                       //6
            Mx_Dtt_examcof[x_id_pos_td_2].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_obsexam`).val();                                                 //7



            if (provisorio < 0) {
                $(this).parents("tr").attr('data-index');

                PASS_SAVE = 0;
                $(this).css({ "border-color": "red" });
                $(this).css({ "color": "red" });

                $("#Lbl_tot_beneficiario").css({ "border-color": "red" });
                $("#Lbl_tot_beneficiario").css({ "color": "red" });


            } else {
                console.log("AQUI 1");
                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorapagar`).val(parseInt(provisorio));
                PASS_SAVE = 1;
                $(this).css({ "border-color": "#ccc" });
                $(this).css({ "color": "#212529" });
                $("#Lbl_tot_beneficiario").css({ "border-color": "#868e96" });
                $("#Lbl_tot_beneficiario").css({ "color": "#495057" });
                HOLAAAAAAAAAAA();
            }


            //$(".td_valorapagar").trigger("change")();

            //$(".td_valorBeneficiario").trigger("change")();
        });
        $(`#DataTable_pac2 tbody tr .td_valorBeneficiario`).keyup(function EnterEvent(e) {                                                                    //POR BONIFICACION

            console.log("beneficiario 1");
            e.stopImmediatePropagation();
            //var x_id_pos_td = $(this).parents("tr").attr('data-index');sd
            //let x_id_pos_td_2 = $(`#DataTable_pac2 tbody tr[data-index =${i}]`).attr('data-index');a

            var x_id_pos_td_2 = $(this).parents("tr").attr('data-index');
            //let x_id_pos_td_2 = $(`#DataTable_pac2 tbody tr[data-index =${i}]`).attr('data-index');

            if ($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val() == "") {
                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val(0);
            }

            if ($(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val() == "") {
                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val(0);
            }

            //var xId_index_td_val_documento = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();
            var xId_index_td_val_scomplementario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val();
            var xId_index_td_val_prevision = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_prevision`).val();
            var xId_index_td_val_valorBeneficiario = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val();
            var xId_index_td_val_valorapagar = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorapagar`).val();

            var SC_VB = parseInt(xId_index_td_val_scomplementario) + parseInt(xId_index_td_val_valorBeneficiario)

            var provisorio = (parseInt(xId_index_td_val_prevision) - SC_VB);

            Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_VALOR_BENEF = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val();                            //1
            Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_VALOR_CS = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val();                                 //2
            Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_TP_1 = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .tp_pago2`).val();                                               //3
            Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_TP_OBS = "ate det tp obss";                                                                                                       //4 
            Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_NUM_BOL = 0;                                                                                                                      //5 
            Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_NUM_BONO = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_documento`).val();                                       //6
            Mx_Dtt_examcof[x_id_pos_td_2].OBS_EXAM = $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_obsexam`).val();                                                 //7

            if (provisorio < 0) {
                $(this).parents("tr").attr('data-index');

                PASS_SAVE = 0;
                $(this).css({ "border-color": "red" });
                $(this).css({ "color": "red" });

                $("#Lbl_tot_beneficiario").css({ "border-color": "red" });
                $("#Lbl_tot_beneficiario").css({ "color": "red" });


            } else {
                console.log("AQUI 2");
                $(`#DataTable_pac2 tbody tr[data-index =${x_id_pos_td_2}] .td_valorapagar`).val(parseInt(provisorio));
                PASS_SAVE = 1;
                $(this).css({ "border-color": "#ccc" });
                $(this).css({ "color": "#212529" });
                $("#Lbl_tot_beneficiario").css({ "border-color": "#868e96" });
                $("#Lbl_tot_beneficiario").css({ "color": "#495057" });
                HOLAAAAAAAAAAA();
            }

            //$(".td_valorBeneficiario").trigger("change")();

            //$(".td_valorapagar").trigger("change")();
            //});

        });
        //-------------------------------------
    }       //<---------------------------

    //$(".td_valorBeneficiario").trigger("Keyup")();
    $(".tp_pago2").trigger("keyup");



    actualizaValores()

    add_row();
}
//FIN NUEVA CON BOTÓN DE EXÁMENES

const actualizaValores = () => {
    var tot_a_pagar = 0;
    var GLOBAL_TOT_PREVISION = 0;
    var GLOBAL_TOT_BENEFICIARIO = 0;
    var GLOBAL_TOT_FONASA = 0;
    var GLOBAL_TOT_COPA_PART = 0;

    Mx_Dtt_examcof.forEach((exam) => {
        const precio_amb = parseInt(exam.CF_PRECIO_AMB);
        const bonificacion = parseInt(exam.CF_BONIFICACION);
        const tipo_examen = parseInt(exam.ATE_DET_TP_1);

        tot_a_pagar += precio_amb - bonificacion;
        GLOBAL_TOT_PREVISION += precio_amb;

        if ([18, 5, 2, 19, 3, 11, 8].includes(tipo_examen)) {
            GLOBAL_TOT_BENEFICIARIO += bonificacion;
            GLOBAL_TOT_FONASA += precio_amb;
        } else if ([1, 20].includes(tipo_examen)) {
            GLOBAL_TOT_COPA_PART += precio_amb;
        }
    });

    $("#Lbl_tot_copa_fonasa").val(format_toCLP(GLOBAL_TOT_FONASA - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));
    $("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_FONASA - (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO)));  //MODAL

    $("#Lbl_tot_copa_particular").val(format_toCLP(GLOBAL_TOT_COPA_PART));
    $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val(format_toCLP(GLOBAL_TOT_COPA_PART));  //MODAL

    $("#Lbl_tot_prevision").val(format_toCLP(GLOBAL_TOT_PREVISION));
    $("#Lbl_tot_a_pagar").val(format_toCLP(tot_a_pagar));
    $("#lbl_Tot_Pagar_Modal").val(format_toCLP(tot_a_pagar));                            //MODAL
    $("#Lbl_tot_beneficiario").val(0);
    $("#lbl_Tot_Pagar_Modal").val(format_toCLP(tot_a_pagar));                            //MODAL
}


function fill_llenado_tabla_2() {

    $("#Div_Tabla78").empty();
    $("<table>", {
        "id": "DataTable_pac73",
        "class": "display",
        "width": "100%",
        "cellspacing": "0"
    }).appendTo("#Div_Tabla78");

    $("#DataTable_pac73").append(
        $("<thead>"),
        $("<tbody>")
    );
    $("#DataTable_pac73").attr("class", "table table-hover table-striped table-iris");
    $("#DataTable_pac73 thead").attr("class", "cabzera");
    $("#DataTable_pac73 thead").append(
        $("<tr>").append(
            $("<th>", { "class": "textoReducido" }).text("Codigo Fonasa"),
            $("<th>", { "class": "textoReducido" }).text("Descripcion"),
            //$("<th>", { "class": "textoReducido text-center", hidden: true }).text("Valor a Pagar"),
            //$("<th>", { "class": "textoReducido text-center", hidden: true }).text("Días Proceso"),
            $("<th>", { "class": "textoReducido text-center" }).text("Eliminar")
        )
    );
    $("#DataTable_pac73 tbody").empty();
    for (let i = 0; i < exa_actuales_xd.length; i++) {


        const examen = Mx_Detalle_ate.proparra2.find(item => item.ID_CODIGO_FONASA == exa_actuales_xd[i].ID_CODIGO_FONASA);
        let validado = false;
        if (examen) {
            validado = examen.ATE_DET_V_ID_ESTADO == 6 || examen.ATE_DET_V_ID_ESTADO == 14;
        }

        const btnElimPrinter = enabled => `<button type='button' ${enabled ? "disabled" : ""} class='btn btn-${enabled ? "success" : "danger"} btn-xs borrar2 negrita' value='${enabled ? "Validado" : "Eliminar"}' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;opacity: 1;'><i class='fa fa-${enabled ? "check-circle" : "trash"}-o' aria-hidden='true'></i> ${enabled ? "Validado" : "Eliminar"}</button>`



        $("#DataTable_pac73 tbody").append(
            $("<tr>", {
                "class": "textoReducido manito",
                "padding": "1px !important",
                "data-index": i
            }).append(
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido"
                }).text(exa_actuales_xd[i].CF_COD),
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido td_val1"
                }).text(exa_actuales_xd[i].CF_DESC),
                //$("<td>", {
                //    "align": "center",
                //    "class": "textoReducido td_val3"
                //}).text(exa_actuales_xd[i].CF_PRECIO_AMB),
                //$("<td>", {
                //    "align": "center",
                //    "class": "textoReducido td_val2"
                //}).text(exa_actuales_xd[i].CF_DIAS),
                $("<td>", {
                    "data-id-elim": exa_actuales_xd[i].ID_CODIGO_FONASA,
                    "align": "center",
                    "class": "td_input textoReducido td_val2"
                }).html(btnElimPrinter(validado))
            )
        )
    }
}



//ESTA ES CUANDO SE ESCRIBO COD CF A MANO Y SE DA ENTER

function success(xxid, xxcod, xtxis) {
    if (Mx_Dtt_exam03.length == 0) {
        $("input[data-id='" + xxid + "']").val(xxcod);
    } else if (Mx_Dtt_exam03.length == 1) {
        console.log("es uno");
        const repetido = Mx_Dtt_examcof.some(item => item.ID_CODIGO_FONASA == Mx_Dtt_exam03[0].ID_CODIGO_FONASA);
        if (!repetido) {
            //if (xxid != 0) {
            Mx_Dtt_exam03[0].CF_ESTADO_EXAMEN = "Activo"

            Mx_Dtt_examcof.push(Mx_Dtt_exam03[0]);

            fill_llenado_tabla();
        } else {
            $("input[data-id='" + xxid + "']").val(xxcod);
        }
    } else if (Mx_Dtt_exam03.length > 1) {                      //SI VIENE MAS DE UN EXAMEN AL APRETAR ENTER
        console.log("2 o mas examenes con cod fonasa enter");
        $("#Div_Tabla4").empty();
        $("<table>", {
            "id": "DataTable_pac3",
            "class": "display",
            "width": "100%",
            "cellspacing": "0"
        }).appendTo("#Div_Tabla4");

        $("#DataTable_pac3").append(
            $("<thead>"),
            $("<tbody>")
        );
        $("#DataTable_pac3").attr("class", "table table-hover table-striped table-iris");
        $("#DataTable_pac3 thead").attr("class", "cabzera");
        $("#DataTable_pac3 thead").append(
            $("<tr>").append(

                $("<th>", { "class": "textoReducido" }).text("Nº"),
                $("<th>", { "class": "textoReducido" }).text("Codigo"),
                $("<th>", { "class": "textoReducido" }).text("Descripcion"),
                //$("<th>", { "class": "textoReducido" }).text("Valor Ambulatorio"),
                $("<th>", { "class": "textoReducido" }).text("Carga")

            )
        );
        for (let i = 0; i < Mx_Dtt_exam03.length; i++) {
            $("#DataTable_pac3 tbody").append(
                $("<tr>", {
                    "class": "textoReducido manito",
                    "padding": "1px !important",
                }).append(
                    $("<td>", {
                        "align": "left",
                        "class": "textoReducido"

                    }).text(i + 1),
                    $("<td>", {
                        "align": "left",
                        "class": "textoReducido"
                    }).text(Mx_Dtt_exam03[i].CF_COD),
                    $("<td>", {
                        "align": "left",
                        "class": "textoReducido"
                    }).text(Mx_Dtt_exam03[i].CF_DESC),
                    //$("<td>", {
                    //    "align": "center",
                    //    "class": "textoReducido"
                    //}).text(Mx_Dtt_exam03[i].CF_PRECIO_AMB),
                    $("<td>", {
                        "align": "center",
                        "class": "textoReducido"
                    }).html("<div class='checkbox checkbox-success sub_pp' style='margin-top:-5px;'><input type='checkbox' class='manitos2' id='F" + i + "' value='" + Mx_Dtt_exam03[i].ID_CODIGO_FONASA + "' /><label class='manitos2' for='F" + i + "'></label></div>")
                )
            )

        }
        $("#eModal3").modal();

    }

}



function Fill_Ddl_diagnostico() {
    $("#DdlDiagnostico").empty();
    for (let y = 0; y < Mx_Diagnostico.length; ++y) {
        $("<option>", {
            "value": Mx_Diagnostico[y].ID_DIAGNOSTICO
        }).text(Mx_Diagnostico[y].DIA_DESC).appendTo("#DdlDiagnostico");
    }
    $("#DdlDiagnostico").val(1);


    $("#DdlDiagnostico2").empty();
    for (let y = 0; y < Mx_Diagnostico.length; ++y) {
        $("<option>", {
            "value": Mx_Diagnostico[y].ID_DIAGNOSTICO
        }).text(Mx_Diagnostico[y].DIA_DESC).appendTo("#DdlDiagnostico2");
    }
    $("#DdlDiagnostico2").val(1);
};

