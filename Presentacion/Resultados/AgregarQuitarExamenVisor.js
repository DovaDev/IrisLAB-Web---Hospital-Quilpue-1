
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
$(document).ready(function () {
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
    fn_Req_Ciud();
    Ajax_DL_SEXO();
    Ajax_DL_NAC();
    //Ajax_Ciudad();
    //$("#button_modal_pago").click(function () {


    //    if (Mx_Dt023.length != 0) {

    //        objAJAX_Atenc.callback([
    //             Mx_Dt023.ID_Atencion
    //        ]);
    //    }
    //});

    //let rt = getParameterByName("Rt");
    //let di = getParameterByName("Di");
    //if (rt != "NONE") {
    //    $("#rut").val(rt);
    //    var obj_RUT2 = Valid_RUT($("#rut").val());
    //    $("#rut").val(obj_RUT2.Format);

    //    Ajax_modal_exa_RUT();
    //} else {
    //    $("#checkBox999").prop('checked', false);
    //    $("#checkBox8887").prop('checked', false);
    //    $("#rut").hide();
    //    $("#dni").show();
    //    $("#Naten").hide();
    //    $("#dni").val(di);
    //    Ajax_modal_exa_DNI();
    //}

    $("#Procedencia").change(function () {
        Ajax_DataTable();
    });
    //$("#Div_Tabla").hide();


    // Call_AJAX_Ddl();
    //Ajax_DL_programa();
    //Ajax_DL_sec();
    //Ajax_DL_TP_ATE();
    //Ajax_DL_orden_ate();
    //Ajax_DL_prevision();
    //Ajax_DL_DOC();
    Ajax_Diagnostico();
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
            $("<th>", { "class": "textoReducido text-center" }).text("Valor a Pagar"),
            $("<th>", { "class": "textoReducido text-center" }).text("Dias Proceso"),
            $("<th>", { "class": "textoReducido" }).text(""),
            $("<th>", { "class": "textoReducido" }).text("Cambio de Estado")
        )
    );
    add_row();


    //-*-*-*-*-*-*-*-*-*-*-*-*-*
    $("#Btnnew").click(function () {
        Ajax_DL_SEXO();
        Ajax_DL_NAC();
        Ajax_Ciudad();
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
            for (x = 0; x < Mx_Dtt_examcof.length; x++) {
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
                for (z = 0; z < Mx_Dtt_examcof.length; z++) {

                    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 66) {
                        Mx_Dtt_examcof.splice(z, 1);
                        xxxer = true;
                    }

                }
                if (xxxer == true) {
                    for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
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
                for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                    //for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1026) {
                        Mx_Dtt_examcof.splice(z, 1);
                        xxxer = true;
                    }
                    //}
                }
                if (xxxer == true) {
                    for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
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
                for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                    //for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
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
        $("#DataTable_pac2 tbody").empty();
        add_row();
    });



    $("#BtnSaveAll").click(function () {
        var sum = 9;
        if (sum == 9) {

            if ($("#rut").val() == "") {
                verrut = 2;
            }
            Ajax_guardar();
        } else {
            $("#mError_AAH").modal('hide');
            var str_Error = "Por favor llenar los campos marcados con color rojo";
            $("#title").text("Faltan campos por llenar");
            $("#button_modal").attr("class", "btn btn-danger");

            $("#mError_AAH p").text(str_Error);
            $("#mError_AAH").modal();

            $('body, html').animate({
                scrollTop: '0px'
            }, 300);
        }
    });

    //-*-*-*-*-*-*-*-*-* TABLA DINAMICA -*-*-*-*-*-*-*-*-*-*-*
    $("#Examen").click(function () {
        Ajax_DataTable_examen02();
        //Fill_DataTable_exam02();
        $('#eModal2').modal('show');
    });



    ///llenado tabla con modal  a  atabla principal
    $("#btnguardar").click(function () {
        selected = new Array();
        $(".pp input:checkbox:checked").each(function () {
            selected.push($(this).val());
        });
        for (z = 0; z < Mx_Dtt_examcof.length; z++) {
            for (x = 0; x < selected.length; x++) {
                if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == selected[x]) {
                    selected.splice(x, 1);
                }
            }
        }
        for (i = 0; i < selected.length; i++) {
            for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                if (selected[i] == Mx_Dtt_exam02[x].ID_CODIGO_FONASA) {




                    Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02[x]));
                    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                }
            }
        }

        fill_llenado_tabla();
        $('#eModal2').modal('hide');
    });


    $("#btnexarepetido").click(function () {
        selected = new Array();
        $(".sub_pp input:checkbox:checked").each(function () {
            selected.push($(this).val());
        });
        for (z = 0; z < Mx_Dtt_examcof.length; z++) {
            for (x = 0; x < selected.length; x++) {
                if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == selected[x]) {
                    selected.splice(x, 1);
                }
            }
        }
        for (i = 0; i < selected.length; i++) {
            for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                if (selected[i] == Mx_Dtt_exam02[x].ID_CODIGO_FONASA) {
                    Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02[x]));
                    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                }
            }
        }
        if (xId != 0) {
            for (z = 0; z < Mx_Dtt_examcof.length; z++) {
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
            for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == ff) {
                    Mx_Dtt_examcof.splice(i, 1);
                }
                $(this).closest('tr').remove();
                for (x = 0; x < Mx_Dtt_examcof.length; x++) {
                    if (Mx_Dtt_examcof[x].ID_CODIGO_FONASA == 1054) {
                        sifi = 1;
                    } else {
                        sifi = 0;
                    }
                }
            }
        } else {
            var str_Error = "El campo no puede ser eliminado"
            $("#title").text("Eliminar Examen");
            $("#button_modal").attr("class", "btn btn-danger");

            $("#mError_AAH p").text(str_Error);
            $("#mError_AAH").modal();
        }
    });
    $(document).on('click', '.CEstado', function (event) {
        //var rowstota = document.getElementById("DataTable_pac2").rows.length;
        var ff = $(this).parent().parent().children().children('.td_input').attr('data-id');
        event.preventDefault();

        for (i = 0; i < Mx_Dtt_examcof.length; i++) {
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

        for (i = 0; i < Mx_Dtt_examcof.length; i++) {
            if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == ff) {

                Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN = "Activo"

            }
        }

        fill_llenado_tabla();

    });
});
//-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

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
        "url": "/Agenda_Med/IN_PAC_AVIS_2.aspx/Llenar_AVIS",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_OMI = JSON.parse(json_receiver);

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



function Fill_DL_OMI() {

    //MX_HO_ExamenCodigo.length = 0;
    //for (x = 0; x < MX_HO_ExamenCodigo.length; x++) {
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
    //var hash = { };
    //MX_HO_ExamenCodigo = MX_HO_ExamenCodigo.filter(function (current) {
    //    var exists = !hash[current.Examen] || false;
    //    hash[current.Examen] = true;
    //    return exists;
    //});
    //for (x = 0; x < MX_HO_ExamenCodigo.length; x++) {
    //    for (y = 0; y < ftler.length; y++) {
    //        if (MX_HO_ExamenCodigo[x].Examen == ftler[y].Examen) {
    //            if (MX_HO_ExamenCodigo[x].HO_CC < ftler[y].HO_CC) {
    //                MX_HO_ExamenCodigo.splice(x, 1);
    //            }
    //        }
    //    }
    //}
    //console.log(JSON.stringify(MX_HO_ExamenCodigo));

    //for (x = 0; x < MX_HO_ExamenCodigo.length; x++) {
    //    for (i = 0; i < Mx_AVIS.length; i++) {

    //        if (MX_HO_ExamenCodigo[x].HO_CC != Mx_AVIS[i].N_OMI && MX_HO_ExamenCodigo[x].Examen == Mx_AVIS[i].COD_EXA_INTERNO) {

    //            if (MX_HO_ExamenCodigo[x].CF_MULTIPLICADOS == "") {
    //                MX_HO_ExamenCodigo[x].CF_MULTIPLICADOS = MX_HO_ExamenCodigo[x].HO_CC + "|" + Mx_AVIS[i].N_OMI + "|";
    //            } else {
    //                MX_HO_ExamenCodigo[x].CF_MULTIPLICADOS = `${MX_HO_ExamenCodigo[x]["CF_MULTIPLICADOS"]}${Mx_AVIS[i].N_OMI}|`;
    //            }
    //        }

    //    }
    //}
    for (x = 0; x < Mx_OMI.length; x++) {
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
    for (x = 0; x < MX_HO_ExamenCodigo.length; x++) {
        for (y = 0; y < ftler.length; y++) {
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
        "url": "/Agenda_Med/AGRE_EXA_ATE.aspx/IRIS_WEBF_BUSCA_examenes_paciente",
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




                for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                    if ((Mx_Dtt_examcof[i].ID_CODIGO_FONASA == 690) || (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == 691)) {
                        if ($("#sex").val() == 1) {
                            for (h = 0; h < Mx_Dtt_exam02_respaldo.length; h++) {
                                if (Mx_Dtt_exam02_respaldo[h].ID_CODIGO_FONASA == 690) {

                                    Mx_Dtt_examcof[i].AÑO_DESC = Mx_Dtt_exam02_respaldo[h].AÑO_DESC;
                                    Mx_Dtt_examcof[i].CF_COD = Mx_Dtt_exam02_respaldo[h].CF_COD;
                                    Mx_Dtt_examcof[i].CF_DESC = Mx_Dtt_exam02_respaldo[h].CF_DESC;
                                    Mx_Dtt_examcof[i].CF_DIAS = Mx_Dtt_exam02_respaldo[h].CF_DIAS;
                                    Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN = Mx_Dtt_exam02_respaldo[h].CF_ESTADO_EXAMEN;
                                    Mx_Dtt_examcof[i].CF_PRECIO_AMB = Mx_Dtt_exam02_respaldo[h].CF_PRECIO_AMB;
                                    Mx_Dtt_examcof[i].CF_PRECIO_HOS = Mx_Dtt_exam02_respaldo[h].CF_PRECIO_HOS;
                                    Mx_Dtt_examcof[i].ID_CF_PRECIO = Mx_Dtt_exam02_respaldo[h].ID_CF_PRECIO;
                                    Mx_Dtt_examcof[i].ID_CODIGO_FONASA = Mx_Dtt_exam02_respaldo[h].ID_CODIGO_FONASA;
                                    Mx_Dtt_examcof[i].ID_ESTADO = Mx_Dtt_exam02_respaldo[h].ID_ESTADO;
                                    Mx_Dtt_examcof[i].ID_PER = Mx_Dtt_exam02_respaldo[h].ID_PER;
                                    Mx_Dtt_examcof[i].ID_PREVE = Mx_Dtt_exam02_respaldo[h].ID_PREVE;
                                    Mx_Dtt_examcof[i]["CF_ESTADO_EXAMEN"] = "Activo"
                                }
                            }

                        } else if ($("#sex").val() == 2) {
                            for (h = 0; h < Mx_Dtt_exam02_respaldo.length; h++) {
                                if (Mx_Dtt_exam02_respaldo[h].ID_CODIGO_FONASA == 691) {

                                    Mx_Dtt_examcof[i].AÑO_DESC = Mx_Dtt_exam02_respaldo[h].AÑO_DESC;
                                    Mx_Dtt_examcof[i].CF_COD = Mx_Dtt_exam02_respaldo[h].CF_COD;
                                    Mx_Dtt_examcof[i].CF_DESC = Mx_Dtt_exam02_respaldo[h].CF_DESC;
                                    Mx_Dtt_examcof[i].CF_DIAS = Mx_Dtt_exam02_respaldo[h].CF_DIAS;
                                    Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN = Mx_Dtt_exam02_respaldo[h].CF_ESTADO_EXAMEN;
                                    Mx_Dtt_examcof[i].CF_PRECIO_AMB = Mx_Dtt_exam02_respaldo[h].CF_PRECIO_AMB;
                                    Mx_Dtt_examcof[i].CF_PRECIO_HOS = Mx_Dtt_exam02_respaldo[h].CF_PRECIO_HOS;
                                    Mx_Dtt_examcof[i].ID_CF_PRECIO = Mx_Dtt_exam02_respaldo[h].ID_CF_PRECIO;
                                    Mx_Dtt_examcof[i].ID_CODIGO_FONASA = Mx_Dtt_exam02_respaldo[h].ID_CODIGO_FONASA;
                                    Mx_Dtt_examcof[i].ID_ESTADO = Mx_Dtt_exam02_respaldo[h].ID_ESTADO;
                                    Mx_Dtt_examcof[i].ID_PER = Mx_Dtt_exam02_respaldo[h].ID_PER;
                                    Mx_Dtt_examcof[i].ID_PREVE = Mx_Dtt_exam02_respaldo[h].ID_PREVE;
                                    Mx_Dtt_examcof[i]["CF_ESTADO_EXAMEN"] = "Activo"
                                }
                            }

                        }



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
var Mx_Diagnostico = [{
    "ID_DIAGNOSTICO": 0,
    "DIA_COD": 0,
    "DIA_DESC": 0,
    "ID_ESTADO": 0
}];

function Ajax_Diagnostico() {
    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/IN_PAC_AVIS.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO",
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
        "ATE_NUM_AVIS": 0,
        "ID_ATENCION": 0,
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
        "url": "/Agenda_Med/AGRE_EXA_ATE.aspx/MODAL_PAC",
        "data": Data_Par_modal,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": Data_Par_modal_paciente => {
            //Debug
            //console.log(Data_Par_modal_paciente);
            Mx_Detalle_ate = Data_Par_modal_paciente.d;
            //ENVIAMOS ID_ATEMCION AL MODAL
            //LLAMAMOS AL FILL MODAL
            llenarmodal();
            $("#Btn_Print").removeAttr("disabled");

            //// MOSTRAR EL MODAL
            //$('#eModales33').modal('show');
        },
        "error": Data_Par_modal_paciente => {
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
        "url": "/Agenda_Med/AGRE_EXA_ATE.aspx/MODAL_PAC_RUT",
        "data": Data_Par_modal,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": Data_Par_modal_paciente => {
            //Debug
            //console.log(Data_Par_modal_paciente);
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
        "url": "/Agenda_Med/AGRE_EXA_ATE.aspx/MODAL_PAC_DNI",
        "data": Data_Par_modal,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": Data_Par_modal_paciente => {
            //Debug
            //console.log(Data_Par_modal_paciente);
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
            Hide_Modal();
            console.log(Data_Par_modal_paciente);

        }
    });
}
var Mx_DL_Diag = [{
    "ID_DIAGNOSTICO": 0,
    "DIA_COD": "asdf",
    "DIA_DESC": "asdf",
    "ID_ESTADO": 0,
    "DIA_HOST_AVIS": 0
}];
function Ajax_DLdiag(hosts) {
    Mx_DL_Diag.length = 0;


    var Data_Par = JSON.stringify({
        "HOST": hosts
    });
    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/IN_PAC_AVIS.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST",
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

var Mx_DL_Diag2 = [{
    "ID_DIAGNOSTICO": 0,
    "DIA_COD": "asdf",
    "DIA_DESC": "asdf",
    "ID_ESTADO": 0,
    "DIA_HOST_AVIS": 0
}];
function Ajax_DLdiag2(hosts) {
    Mx_DL_Diag2.length = 0;


    var Data_Par = JSON.stringify({
        "HOST": hosts
    });
    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/IN_PAC_AVIS.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST2",
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
function llenarmodal() {

    Ajax_DL_NAC();
    Ajax_DL_SEXO();

    let FechaREE = moment(Mx_Detalle_ate.proparra1[0].PAC_FNAC).format("YYYY-MM-DD");
    $("#Rut_2m").val(Mx_Detalle_ate.proparra1[0].PAC_RUT);
    $("#Nom").val(Mx_Detalle_ate.proparra1[0].PAC_NOMBRE);
    $("#Ape").val(Mx_Detalle_ate.proparra1[0].PAC_APELLIDO);
    $("#fecha").val(FechaREE);
    $("#Edad").val(`${Mx_Detalle_ate.proparra1[0].PREI_AÑO} años`);
    $("#telfijo").val(Mx_Detalle_ate.proparra1[0].PAC_FONO1);
    $("#Celular").val(Mx_Detalle_ate.proparra1[0].PAC_MOVIL1);
    Ajax_DataTable_examen02();
    var obj_RUT2 = Valid_RUT($("#rut").val());
    $("#rut").val(obj_RUT2.Format);


    var aaa = {};


    if (Mx_Detalle_ate.proparra2.length > 0) {
        Mx_Dtt_examcof.length = 0;
        //for (p = 0; p < Mx_Detalle_ate.proparra2.length; p++) {
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


        for (p = 0; p < Mx_Detalle_ate.proparra2.length; p++) {
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
                "class": "textoReducido manito",
                "padding": "1px !important",
            }).append(
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido"
                }).html((function () {
                    //Retornar un campo input
                    return $("<input>", {
                        "data-id": 0,
                        "data-cod": "",
                        "class": "td_input",
                        "value": ""
                    })
                }())),
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido td_val1"
                }).text(""),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido td_val3"
                }).text(""),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido td_val2"
                }).text(""),
                $("<td>", {
                    "align": "center"
                }).html("<button type='button' class='btn btn-default btn-xs borrar' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"),
                $("<td>", {
                    "align": "center"
                }).html("<button type='button' class='btn btn-print btn-xs CEstado' value='Espera' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>")

            )

        )
        $(".td_input").keydown(function EnterEvent(e) {
            if (e.keyCode == 13) {
                xId = $(this).attr("data-id");
                var xcod = $(this).attr("data-cod");
                Ajax_DataTable_examen3($(this).val(), xId, xcod, $(this));
                //ESTE SI
            }
        });

        var HXH = 0;
        for (x = 0; x < Mx_Dtt_examcof.length; x++) {
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
    } else if ((rowstota == 1) || (rowstota == 2)) {
        $("#DataTable_pac2 tbody").append(
            $("<tr>", {
                "class": "textoReducido manito",
                "padding": "1px !important",
            }).append(
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido"
                }).html((function () {
                    //Retornar un campo input
                    return $("<input>", {
                        "data-id": 0,
                        "data-cod": "",
                        "class": "td_input",
                        "value": ""
                    })
                }())),
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido td_val1"
                }).text(""),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido td_val3"
                }).text(""),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido td_val2"
                }).text(""),

                $("<td>", {
                    "align": "center"
                }).html("<button type='button' class='btn btn-default btn-xs borrar' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'>Eliminar</i></button>"),
                $("<td>", {
                    "align": "center"
                }).html("<button type='button' class='btn btn-print btn-xs CEstado' value='Espera' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Espera</button>")

            )
        )
        $(".td_input").focusout(function () {
            xId = $(this).attr("data-id");
            var xcod = $(this).attr("data-cod");
            Ajax_DataTable_examen3($(this).val(), xId, xcod, $(this));
        });
    }
    var xLen = $(".td_input");
    $(".td_input").eq(xLen.length - 1).focus();
}
var Mx_Dtt_examcof = [{
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
}];
var exa_actuales_xd = [{
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
}];
Mx_Dtt_examcof.length = 0;
//-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
var Mx_Dt023 = [{
    "Correlativo": 0,
    "ID_Atencion": 0
}];

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
    for (x = 0; x < exa_actuales_xd.length; x++) {
        for (i = 0; i < Mx_Dtt_examcof.length; i++) {
            if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == exa_actuales_xd[x].ID_CODIGO_FONASA) {
                Mx_Dtt_examcof.splice(i, 1);
            }
        }
    }


    for (x = 0; x < Mx_Dtt_examcof.length; x++) {
        var xtotal = parseFloat(Mx_Dtt_examcof[x].CF_PRECIO_AMB);
        TOTAL += xtotal;
        if (Mx_Dtt_examcof[x]["CF_MULTIPLICADOS"] == undefined) {
            Mx_Dtt_examcof[x]["CF_MULTIPLICADOS"] = "";
        }
        var objId = {
            "id_CF": Mx_Dtt_examcof[x].ID_CODIGO_FONASA,
            "id_PER": Mx_Dtt_examcof[x].ID_PER,
            "Valor": Mx_Dtt_examcof[x].CF_PRECIO_AMB,
            "Clinico": numeritocliniquito,
            "CF_ESTADO_EXAMEN": Mx_Dtt_examcof[x].CF_ESTADO_EXAMEN,
            "CF_MULTIPLICADOS": Mx_Dtt_examcof[x].CF_MULTIPLICADOS,
            "CODIGO_TEST": Mx_Dtt_examcof[x].CODIGO_TEST,
            "HO_CC": Mx_Dtt_examcof[x].HO_CC
        };


        ids.push(objId);

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
        "ID_ATENCION": Mx_Detalle_ate.proparra3[0].ID_ATENCION

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

    });
    console.log("ID_ATENCION:", Mx_Detalle_ate.proparra3[0].ID_ATENCION);

    console.log(`DATA PAR: ${Data_Par}`)
    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/AGRE_EXA_ATE.aspx/Guardar_TodoByVal",
        "data": Data_Par,
        "contentType": "application/json;charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_Dt023 = JSON.parse(json_receiver);
                Hide_Modal();
                //Ajax_DL_SEXO();
                //Ajax_DL_NAC();
                //Ajax_Ciudad();
                //Ajax_DataTable();
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

                $("#modal-agregar-quitar-examenes").modal('hide');






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
//-*-*-**-*-**--**--*-*-*-***-*****--**-*-*-*-*-*-*-*-*-*-*-*-*-*-
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
    }
];
function Ajax_DataTable_examen02() {
    var f = moment().format("DD-MM-YYYY");


    $("#Div_Tabla2").empty();
    var Data_Par = JSON.stringify({
        "ID_PREVE": Mx_Detalle_ate.proparra3[0].ID_PREVE,
        "Fecha": f
    });

    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/IN_PAC_AVIS.aspx/Llenar_tabla_exam2",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt_exam02 = JSON.parse(json_receiver);
                Mx_Dtt_exam02_respaldo = JSON.parse(json_receiver);
                if ($("#sex").val() != 0) {
                    var posicion = 0;
                    if ($("#sex").val() == 1) {
                        for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                            if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 691) {
                                posicion = x;
                            }
                        }
                        Mx_Dtt_exam02.splice(posicion, 1);
                    }
                    if ($("#sex").val() == 2) {
                        for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                            if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 690) {
                                posicion = x;
                            }
                        }
                        Mx_Dtt_exam02.splice(posicion, 1);
                    }
                }
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
    }
];
function Ajax_DataTable_examen3(cod_fonasa, id, cod, txis) {
    var f = moment().format("DD-MM-YYYY");


    var Data_Par = JSON.stringify({
        "ID_PREVE": 8,
        "Fecha": f,
        "CF": cod_fonasa
    });
    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/IN_PAC_MAN.aspx/Llenar_tabla_exam",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt_exam03 = JSON.parse(json_receiver);

                //if ($("#sex").val() != 0) {
                //    var posicion = 0;
                //    if ($("#sex").val() == 1) {
                //        for (x = 0; x < Mx_Dtt_exam03.length; x++) {
                //            if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 1026) {
                //                posicion = x;
                //            }
                //        }
                //        Mx_Dtt_exam03.splice(posicion, 1);
                //    }
                //    if ($("#sex").val() == 2) {
                //        for (x = 0; x < Mx_Dtt_exam03.length; x++) {
                //            if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 66) {
                //                posicion = x;
                //            }
                //        }
                //        Mx_Dtt_exam03.splice(posicion, 1);
                //    }
                //}
                success(id, cod, txis);


            } else {


                Mx_Dtt_exam03.length = 0;
                success(id, cod, txis);
            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
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
        "url": "/Agenda_Med/IN_PAC_MAN.aspx/Llenar_Ddl_LugarTM",
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
        "url": "/Agenda_Med/IN_PAC_MAN.aspx/Llenar_rut",
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
        "url": "/Agenda_Med/IN_PAC_MAN_2.aspx/Llenar_dni",
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
function Ajax_DL_SEXO() {



    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/IN_PAC_MAN.aspx/Llenar_DL_SEXO",
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
function Ajax_DL_NAC() {



    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/IN_PAC_MAN.aspx/Llenar_DL_NAC",
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

function Ajax_Ciudad() {


    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/IN_PAC_MAN.aspx/IRIS_WEBF_BUSCA_CIUDAD",
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
var Mx_Comuna = [];
function Ajax_Comuna() {
    var Data_Par = JSON.stringify({
        "ID_CIU": $("#Cuidad").val()
    });
    $.ajax({
        "type": "POST",
        "url": "Ate_Resultados_2.aspx/IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Comuna = JSON.parse(json_receiver);
                Fill_Ddl_Comuna();
                $(".block_wait").hide();
            }
        }
    });
}
//--------------------------------------------------------------------------------------------
var Mx_DL_prevision = [];
function Ajax_DL_prevision() {
    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/IN_PAC_MAN.aspx/Llenar_DL_prevision",
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_prevision = JSON.parse(json_receiver);
                Fill_DL_prevision();
            }
        },
        "error": function (response) {
            var str_Error = "Error interno del Servidor";
            cModal_Error("Error", str_Error);
        }
    });
}
var Mx_DL_TP_ATE = [];
function Ajax_DL_TP_ATE() {
    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/IN_PAC_MAN.aspx/Llenar_DL_aTENCIONES",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_TP_ATE = JSON.parse(json_receiver);
                Fill_DL_TP_ATE();
            }
        },
        "error": function (response) {
            var str_Error = "Error interno del Servidor";
            cModal_Error("Error", str_Error);
        }
    });
}
var Mx_DL_Sec = [];
function Ajax_DL_sec() {
    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/IN_PAC_MAN.aspx/Llenar_DL_Sectores",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_Sec = JSON.parse(json_receiver);
                Fill_DL_sec();
            }
        },
        "error": function (response) {
            var str_Error = "Error interno del Servidor";
            cModal_Error("Error", str_Error);
        }
    });
}
var Mx_DL_Programa = [];
function Ajax_DL_programa() {
    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/IN_PAC_MAN.aspx/Llenar_DL_Programa",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_Programa = JSON.parse(json_receiver);
                Fill_DL_programa();
            }
        },
        "error": function (response) {
            var str_Error = "Error interno del Servidor";
            cModal_Error("Error", str_Error);
        }
    });
}
var Mx_DL_DOC = [];
function Ajax_DL_DOC() {
    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/IN_PAC_MAN.aspx/Llenar_DL_DOC",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_DOC = JSON.parse(json_receiver);
                Fill_DL_DOC();
            }
        },
        "error": function (response) {
            var str_Error = "Error interno del Servidor";
            cModal_Error("Error", str_Error);
        }
    });
}
var Mx_DL_orden_ate = [];
function Ajax_DL_orden_ate() {
    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/IN_PAC_MAN.aspx/Llenar_DL_ordenATE",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_orden_ate = JSON.parse(json_receiver);
                Fill_DL_orden_ate();
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
    Mx_DL_orden_ate.forEach(item => $("<option>", { value: item.ID_ORDEN, text: item.ORD_DESC }).appendTo("#PrioridadTM"));
    $("#PrioridadTM").val(1);
}
function Fill_DL_DOC() {
    $("#Doctor").empty();
    for (y = 0; y < Mx_DL_DOC.length; ++y) {
        $("<option>", {
            "value": Mx_DL_DOC[y].ID_DOCTOR
        }).text(Mx_DL_DOC[y].DOC_NOMBRE + " " + Mx_DL_DOC[y].DOC_APELLIDO).appendTo("#Doctor");
    }
}
function Fill_DL_programa() {
    $("#Programa").empty();
    for (y = 0; y < Mx_DL_Programa.length; ++y) {
        $("<option>", {
            "value": Mx_DL_Programa[y].ID_PROGRA
        }).text(Mx_DL_Programa[y].PROGRA_DESC).appendTo("#Programa");
    }
}
function Fill_DL_sec() {
    $("#Sector").empty();
    for (y = 0; y < Mx_DL_Sec.length; ++y) {
        $("<option>", {
            "value": Mx_DL_Sec[y].ID_SECTOR
        }).text(Mx_DL_Sec[y].SECTOR_DESC).appendTo("#Sector");
    }
}
function Fill_DL_TP_ATE() {
    $("#TipoAtencion").empty();
    for (y = 0; y < Mx_DL_TP_ATE.length; ++y) {
        $("<option>", {
            "value": Mx_DL_TP_ATE[y].ID_TP_ATENCION
        }).text(Mx_DL_TP_ATE[y].TP_ATE_DESC).appendTo("#TipoAtencion");
    }
}
function Fill_DL_prevision() {
    $("#Prevision").empty();

    for (y = 0; y < Mx_DL_prevision.length; ++y) {
        $("<option>", {
            "value": Mx_DL_prevision[y].ID_PREVE
        }).text(Mx_DL_prevision[y].PREVE_DESC).appendTo("#Prevision");

    }
    Ajax_DataTable_examen02();

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
    $("#direccion").val(Mx_Dtt2[0].PAC_DIR);
    $("#Email").val(Mx_Dtt2[0].PAC_EMAIL);

};

function Fill_AJAX_Ddl() {
    $("#Procedencia").empty();

    var procee = Galletas.getGalleta("USU_TM");
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
    for (y = 0; y < Mx_Ciudad.length; ++y) {
        $("<option>", {
            "value": Mx_Ciudad[y].ID_CIUDAD
        }).text(Mx_Ciudad[y].CIU_DESC).appendTo("#Cuidad");
    }
};
//Llenar DropDownList Comuna
function Fill_Ddl_Comuna() {
    $("#Comuna").empty();
    for (y = 0; y < Mx_Comuna.length; ++y) {
        $("<option>", {
            "value": Mx_Comuna[y].ID_REL_CIU_COM
        }).text(Mx_Comuna[y].COM_DESC).appendTo("#Comuna");
    }
};
//-------------------------------------------------------------------------------------------------------/
var Mx_Dtt_4556 = [];

function Ajax_DataTable() {
    var Data_Par = JSON.stringify({
        "fecha": "ssssss",
        "id": $("#Procedencia").val()
    });
    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/AGRE_EXA_ATE.aspx/Llenar_DataTable",
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
            }
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
    for (y = 0; y < Mx_DL_SEXO.length; ++y) {
        $("<option>", {
            "value": Mx_DL_SEXO[y].ID_SEXO
        }).text(Mx_DL_SEXO[y].SEXO_DESC).appendTo("#sex");
    }
    $("#sex").val(Mx_Detalle_ate.proparra1[0].ID_SEXO);

};
function Fill_DL_NAC() {
    $("#Nacio").empty();

    $("<option>", {
        "value": 0
    }).text("Seleccionar").appendTo("#Nacio");
    for (y = 0; y < Mx_DL_NAC.length; ++y) {
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
function fn_Req_Ciud() {
    objAJAX_Ciud = $.ajax({
        "type": "POST",
        "url": "/Account/Conf_User.aspx/Data_Sel_Ciudad",
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": (resp) => {
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

            fn_Req_Comuna();
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

function fn_Req_Comuna(ID_COM) {
    var objParam = JSON.stringify({
        "ID_CIUD": $("#Cuidad").val()
    });

    objAJAX_Comuna = $.ajax({
        "type": "POST",
        "url": "/Account/Conf_User.aspx/Data_Sel_Comuna",
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
            $("<th>", { "class": "textoReducido" }).text("Valor Ambulatorio"),
            $("<th>", { "class": "textoReducido" }).text("Carga")

        )
    );
    for (i = 0; i < Mx_Dtt_exam02.length; i++) {
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
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido"
                }).text(Mx_Dtt_exam02[i].CF_PRECIO_AMB),
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
        },
        "scrollY": "400px",
    });

}
///llenar check  selecciondas
function fill_llenado_tabla() {
    $("#DataTable_pac2 tbody").empty();
    for (i = 0; i < Mx_Dtt_examcof.length; i++) {
        $("#DataTable_pac2 tbody").append(
            $("<tr>", {
                "class": "textoReducido manito",
                "padding": "1px !important",
            }).append(
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido"
                }).html((function () {
                    //Retornar un campo input
                    return $("<input>", {
                        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        "data-cod": Mx_Dtt_examcof[i].CF_COD,
                        "class": "td_input",
                        "value": Mx_Dtt_examcof[i].CF_COD
                    })
                }())),
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido td_val1"
                }).text(Mx_Dtt_examcof[i].CF_DESC),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido td_val3"
                }).text(Mx_Dtt_examcof[i].CF_PRECIO_AMB),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido td_val2"
                }).text(Mx_Dtt_examcof[i].CF_DIAS),
                $("<td>", {
                    "align": "center"
                }).html("<button type='button' class='btn btn-default btn-xs borrar' value='Eliminar' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"),
                $("<td>", {
                    "align": "center"
                }).html(function () {


                    if (Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN == "Activo") {
                        return "<button type='button' class='btn btn-print btn-xs CEstado' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>"
                    } else {
                        return "<button type='button' class='btn btn-success btn-xs Activado' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Activo</button>"
                    }


                }())
            )
        )
    }
    add_row();
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
            //$("<th>", {"class": "textoReducido text-center" }).text("Valor a Pagar"),
            $("<th>", { "class": "textoReducido text-center" }).text("Dias Proceso"),
            $("<th>", { "class": "textoReducido text-center" }).text("Eliminar")
        )
    );
    $("#DataTable_pac73 tbody").empty();

    const btnElimPrinter = () => `<button type='button' class='btn btn-danger btn-xs negrita btn-eliminar-examen' value='Eliminar' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;opacity: 1;'><i class='fa fa-trash-o' aria-hidden='true'></i>Eliminar</button>`

    for (i = 0; i < exa_actuales_xd.length; i++) {
        $("#DataTable_pac73 tbody").append(
            $("<tr>", {
                "class": "textoReducido manito",
                "padding": "1px !important",
                id: exa_actuales_xd[i].ID_CODIGO_FONASA
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
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido td_val2"
                }).text(exa_actuales_xd[i].CF_DIAS),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido td_val2"
                }).html(btnElimPrinter),

            )
        )
    }

    $("#DataTable_pac73 tbody tr td .btn-eliminar-examen").click(async (e) => {
        const idCodigoFonasa = e.currentTarget.parentElement.parentElement.id;
        const detallePinchado = exa_actuales_xd.find(item => item.ID_CODIGO_FONASA == idCodigoFonasa);
        const { isConfirmed } = await Swal.fire({
            icon: 'question',
            title: '¿Está seguro?',
            html: `Se eliminará el examen de la atención: <br><br>
                    <b>&#8226; ${detallePinchado.CF_DESC} <br><br> </b> 
                    ¿Desea continuar?`,
            //confirmButtonColor: ,
            showDenyButton: true,
            confirmButtonText: 'Eliminar',
            denyButtonText: `Cancelar`,
        })

        if (!isConfirmed) {
            return
        }
        Eliminar_Examen(idCodigoFonasa);
    });



}

function Eliminar_Examen(ID_CODIGO_FONASA) {
    modal_show();
    var Data_Par = JSON.stringify({
        ID_ATENCION: Mx_Detalle_ate.proparra3[0].ID_ATENCION,
        ID_CODIGO_FONASA,
        ID_USUARIO: Galletas.getGalleta("ID_USER")
    });
    $.ajax({
        "type": "POST",
        "url": "/Agenda_Med/AGRE_EXA_ATE.aspx/Eliminar_Examen",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver > 0) {
                exa_actuales_xd = exa_actuales_xd.filter(item => item.ID_CODIGO_FONASA != ID_CODIGO_FONASA);
                fill_llenado_tabla_2();
                Hide_Modal();
                Swal.fire({ icon: "success", title: "Éxito", text: "El exámen fue eliminado con éxito." });
            } else {
                $("#Modal_Eliminar").modal("hide");
                Hide_Modal();
                Swal.fire({ icon: "error", title: "Error", text: "No se ha pudo eliminar el examen." });
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




function success(xxid, xxcod, xtxis) {
    if (Mx_Dtt_exam03.length == 0) {
        $("input[data-id='" + xxid + "']").val(xxcod);
    } else if (Mx_Dtt_exam03.length == 1) {

        var repetido = 0;
        for (z = 0; z < Mx_Dtt_examcof.length; z++) {
            if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == Mx_Dtt_exam03[0].ID_CODIGO_FONASA) {
                repetido++
            }
        }
        if (repetido == 0) {
            if (xxid != 0) {
                Mx_Dtt_examcof.push(Mx_Dtt_exam03[0]);
                for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                    if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == xxid) {
                        Mx_Dtt_examcof.splice(i, 1);
                    }
                }

            }

            $("input[data-id='" + xxid + "']").val(Mx_Dtt_exam03[0].CF_COD);
            $("input[data-id='" + xxid + "']").parent().parent().children(".td_val1").text(Mx_Dtt_exam03[0].CF_DESC);
            $("input[data-id='" + xxid + "']").parent().parent().children(".td_val2").text(Mx_Dtt_exam03[0].CF_DIAS);
            $("input[data-id='" + xxid + "']").parent().parent().children(".td_val3").text(Mx_Dtt_exam03[0].CF_PRECIO_AMB);
            $("input[data-id='" + xxid + "']").attr("data-cod", Mx_Dtt_exam03[0].CF_COD);
            $("input[data-cod='" + Mx_Dtt_exam03[0].CF_COD + "']").attr("data-id", Mx_Dtt_exam03[0].ID_CODIGO_FONASA);

            Mx_Dtt_examcof.push(Mx_Dtt_exam03[0]);
            Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"

            add_row();
        } else {
            $("input[data-id='" + xxid + "']").val(xxcod);
        }
    } else if (Mx_Dtt_exam03.length > 1) {

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
                $("<th>", { "class": "textoReducido" }).text("Valor Ambulatorio"),
                $("<th>", { "class": "textoReducido" }).text("Carga")

            )
        );
        for (i = 0; i < Mx_Dtt_exam03.length; i++) {
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
                    $("<td>", {
                        "align": "center",
                        "class": "textoReducido"
                    }).text(Mx_Dtt_exam03[i].CF_PRECIO_AMB),
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
    for (y = 0; y < Mx_Diagnostico.length; ++y) {
        $("<option>", {
            "value": Mx_Diagnostico[y].ID_DIAGNOSTICO
        }).text(Mx_Diagnostico[y].DIA_DESC).appendTo("#DdlDiagnostico");
    }
    $("#DdlDiagnostico").val(1);


    $("#DdlDiagnostico2").empty();
    for (y = 0; y < Mx_Diagnostico.length; ++y) {
        $("<option>", {
            "value": Mx_Diagnostico[y].ID_DIAGNOSTICO
        }).text(Mx_Diagnostico[y].DIA_DESC).appendTo("#DdlDiagnostico2");
    }
    $("#DdlDiagnostico2").val(1);
};