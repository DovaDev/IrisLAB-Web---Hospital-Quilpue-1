import fillEtnias from '../js/es6-modules/Etnias.js';
import fillGrupoPesquisa from '../js/es6-modules/GruposPesquisa.js';

let guardadoEnProceso = false;


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

//Class AJAX---------------------------------------------------------------------
let Class_AJAX = function () {
    this.url = "";
    this.success = () => { };
    this.error = () => { };
};
Class_AJAX.prototype.callback = function (data) {
    $.ajax({
        "type": "POST",
        "url": this.url,
        "data": JSON.stringify(data),
        "contentType": "application/json;  charset=utf-8",
        "contentType": "text/plain;  charset=utf-8",
        "dataType": "json",
        //"timeout": 20000,
        "success": this.success,
        "error": this.error
    });
};

let timer = 5000;




let objAJAX_Atenc_pdf = new Class_AJAX();
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
objAJAX_Atenc_pdf.url = "http://localhost:9990/Printer/Imp_Voucher_Compr_Ate_pdf";
objAJAX_Atenc_pdf.success = (resp) => {
    console.log(`[ OK ] Impresión Voucher Atención`);
    console.log(resp);
    console.log(``);
    Swal.fire({ icon: "success", text: "La impresión de Comprobante de Atención se ha completado exitosamente.", title: "Voucher" });
    //let str_Error = `La impresión de Comprobante de Atención se ha completado exitosamente, `;
    //str_Error += `iniciando Impresión de Etiquetas.`;
    //$("#title").text("Solicitud de Voucher");
    //$("#button_modal").attr("class", "btn btn-success");
    //$("#mError_AAH p").text(str_Error);
    //$("#mError_AAH").modal("show");

    //setTimeout(() => {
    //$("#mError_AAH").modal(`hide`);

    //objAJAX_Etiq.callback([
    //    Mx_Dt023.ID_Atencion
    //]);
    //}, timer);

};
objAJAX_Atenc_pdf.error = (fail) => {
    console.log(`[ERROR] Impresión Voucher Atención`);
    console.log(fail);
    console.log(``);

    setTimeout(() => {
        $("#mError_AAH").modal(`hide`);

        objAJAX_Atenc_pdf.callback([
            Mx_Dt023.ID_Atencion
        ]);
    }, timer);
};

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


let objAJAX_Atenc = new Class_AJAX();
objAJAX_Atenc.url = "http://localhost:9990/Printer/Imp_Voucher_Compr_Ate";
objAJAX_Atenc.success = (resp) => {
    console.log(`[ OK ] Impresión Voucher Atención`);
    console.log(resp);
    console.log(``);
    Swal.fire({ icon: "success", text: "La impresión de Comprobante de Atención se ha completado exitosamente.", title: "Voucher" });
    //let str_Error = `La impresión de Comprobante de Atención se ha completado exitosamente, `;
    //str_Error += `iniciando Impresión de Etiquetas.`;
    //$("#title").text("Solicitud de Voucher");
    //$("#button_modal").attr("class", "btn btn-success");
    //$("#mError_AAH p").text(str_Error);
    //$("#mError_AAH").modal("show");

    //setTimeout(() => {
    //$("#mError_AAH").modal(`hide`);

    //objAJAX_Etiq.callback([
    //    Mx_Dt023.ID_Atencion
    //]);
    //}, timer);

};
objAJAX_Atenc.error = (fail) => {
    console.log(`[ERROR] Impresión Voucher Atención`);
    console.log(fail);
    console.log(``);

    setTimeout(() => {
        $("#mError_AAH").modal(`hide`);

        objAJAX_Atenc.callback([
            Mx_Dt023.ID_Atencion
        ]);
    }, timer);
};

let objAJAX_Etiq = new Class_AJAX();
objAJAX_Etiq.url = "http://localhost:9990/Printer/Imp_Etiquetas";
objAJAX_Etiq.success = (resp) => {
    console.log(`[ OK ] Impresión Etiquetas`);
    console.log(resp);
    console.log(``);

    let str_Error = `La impresión de Etiquetas se ha completado exitosamente, `;
    str_Error += `iniciando Impresión de Etiquetas.`;
    $("#title").text("Solicitud de Etiquetas");
    $("#button_modal").attr("class", "btn btn-success");
    $("#mError_AAH p").text(str_Error);
    $("#mError_AAH").modal(`hide`);

    setTimeout(() => {
        $("#mError_AAH").modal(`hide`);

        //objAJAX_Proc.callback([
        //    Mx_Dt023.ID_Atencion
        //]);
    }, timer);

};
objAJAX_Etiq.error = (fail) => {
    console.log(`[ERROR] Impresión Voucher Atención`);
    console.log(fail);
    console.log(``);

    setTimeout(() => {
        $("#mError_AAH").modal(`hide`);

        objAJAX_Etiq.callback([
            Mx_Dt023.ID_Atencion
        ]);
    }, timer);
};

let objAJAX_Proc = new Class_AJAX();
objAJAX_Proc.url = "http://localhost:9990/Printer/Imp_Voucher_Lugar_TM";
objAJAX_Proc.success = (resp) => {
    console.log(`[ OK ] Impresión Voucher LugarTM`);
    console.log(resp);
    console.log(``);

    //let str_Error = `La impresión de Voucher y Etiquetas se ha completado exitosamente. `;
    //str_Error += `Impresiones Finalizadas.`;
    //$("#title").text("Impresiones Finalizadas");
    //$("#button_modal").attr("class", "btn btn-success");
    //$("#mError_AAH p").text(str_Error);

    //$("#mError_AAH").modal("show");

    //setTimeout(() => {
    //    $("#mError_AAH").modal(`hide`);
    //}, timer);
    let str_Error = `La impresión de Voucher Lugar TM se ha completado exitosamente. `;
    str_Error += `Impresiones Finalizadas.`;
    $("#title").text("Impresiones Finalizadas");
    $("#button_modal").attr("class", "btn btn-success");
    $("#mError_AAH p").text(str_Error);
    $("#mError_AAH").modal(`hide`);

};
objAJAX_Proc.error = (fail) => {
    console.log(`[ERROR] Impresión Voucher Atención`);
    console.log(fail);
    console.log(``);

    setTimeout(() => {
        $("#mError_AAH").modal(`hide`);

        objAJAX_Proc.callback([
            Mx_Dt023.ID_Atencion
        ]);
    }, timer);
};

//-------------------------------------------------------------------------------

let initializing = true;
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

let Mx_Carga = [];
let Mx_Carga_Pack = [];
let est_Doc = 2;
$(document).ready(function () {

    const today = (new Date()).toLocaleString("EN-CA").slice(0, 10); // get local current date


    document.querySelectorAll('input[type="datetime-local"]').forEach(el => {
        el.max = today + "T23:59";
    });

    //Ajax_DataTable_Pack();

    const inputFecha = document.getElementById("fecha");

    // Obtener la fecha y hora actual en formato adecuado para datetime-local
    const now = new Date();
    const formattedDate = now.toISOString().slice(0, 16); // YYYY-MM-DDTHH:MM

    // Establecer el máximo permitido como la fecha actual
    inputFecha.max = formattedDate;

    // Validar cuando el usuario ingrese una fecha manualmente
    inputFecha.addEventListener("change", function () {
        const inputValue = new Date(this.value);
        const maxDate = new Date(this.max);

        if (inputValue > maxDate || isNaN(inputValue.getTime())) {
            Swal.fire({
                title: "Aviso",
                text: "Seleccione una fecha valida",
                icon: "warning"
            });
            inputFecha.value = today
        }
    });

    // Bloquear pegado manual
    inputFecha.addEventListener("paste", function (e) {
        e.preventDefault();
    });
    //Eventos para desactivar los select de grupo pesquisa
    $("#slctGrupoPesquisaVIH").attr("disabled", true)
    $("#slctGrupoPesquisaRPRChagas").attr("disabled", true)

    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    $("#btn_close_med").click(() => {
        $("#mdl_Doc").modal("hide");
    });

    $("#RUT_Doctor").val("");
    $("#Doctor").val("");
    $("#Doctor").attr("data-id", 0);
    $("#Doctor").removeAttr("readonly");

    $("#button_modal").click(() => {
        $("#mError_AAH").modal("hide");
    });

    $("#Doctor").keypress((e) => {

        if (e.which == 13) {

            if ($("#Doctor").val().length >= 4) {

                Ajax_Busca_Doc_Por_Nom($("#Doctor").val());

            } else {
                Swal.fire({
                    icon: "info",
                    title: "Información",
                    text: "Ingrese 4 carácteres o más",
                });
            }

        }

    });

    //Evento para check
    $("#chk_neo").change(function () {
        // Referenciar el input
        let inputFechaNacimiento = document.getElementById("fecha");

        if ($(this).is(':checked')) {
            inputFechaNacimiento.type = "datetime-local";
            const now = new Date();

            // Obtener componentes de la fecha
            const year = now.getFullYear();
            const month = String(now.getMonth() + 1).padStart(2, '0'); // Meses comienzan en 0
            const day = String(now.getDate()).padStart(2, '0');

            // Obtener componentes de la hora
            const hours = String(now.getHours()).padStart(2, '0');
            const minutes = String(now.getMinutes()).padStart(2, '0');

            // Formato final: YYYY-MM-DDTHH:MM
            const currentDateTime = `${year}-${month}-${day}T${hours}:${minutes}`;
            inputFechaNacimiento.value = currentDateTime;
            $("#Edad").val('');
            console.log('Checkbox s')
        } else {

            inputFechaNacimiento.type = "date";
            inputFechaNacimiento.value = today;
            $("#Edad").val('');
            console.log('Checkbox d')
        }
    });

    $("#Doctor").focusout(() => {
        if ($("#Doctor").val() == "" && $("#Doctor").attr("data-id") != 0) {
            $("#Doctor").attr("data-id", 0);
        }
    });

    $("#RUT_Doctor").keypress((e) => {
        if (e.which == 13) {

            let _RDOC = Valid_RUT($("#RUT_Doctor").val());


            console.log(_RDOC);
            if (_RDOC.Valid == true) {
                $("#RUT_Doctor").val(_RDOC.Format);
                Ajax_Busca_Doc_Por_Rut($("#RUT_Doctor").val());
            } else {
                if ($("#RUT_Doctor").val() != "") {
                    $("#mError_AAH .modal-header h4").text("Estimado usuario");
                    $("#mError_AAH .modal-body p").text("Ingrese RUT Valido");
                    $("#mError_AAH").modal("show");
                }


                $("#RUT_Doctor").val("");
                $("#Doctor").val("");
                $("#Doctor").attr("data-id", 0);
                $("#Doctor").removeAttr("readonly");
            }



        }
    });

    $("#RUT_Doctor").focusout(() => {


        let _RDOC = Valid_RUT($("#RUT_Doctor").val());
        console.log(_RDOC);
        if (_RDOC.Valid == true) {
            $("#RUT_Doctor").val(_RDOC.Format);
            Ajax_Busca_Doc_Por_Rut($("#RUT_Doctor").val());

        } else {
            if ($("#RUT_Doctor").val() != "") {
                $("#mError_AAH .modal-header h4").text("Estimado usuario");
                $("#mError_AAH .modal-body p").text("Ingrese Nombre Valido");
                $("#mError_AAH").modal("show");
                $("#RUT_Doctor").val("");
            } else {
                $("#RUT_Doctor").val("");
                $("#Doctor").val("");
                $("#Doctor").attr("data-id", 0);
                $("#Doctor").removeAttr("readonly");
            }
        }

    });
    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    // Mostrar modal para dejar cargar los ddl
    modal_show();
    setTimeout(() => {
        Hide_Modal();
    }, 800);

    Limpia_Modal_Examed();
    $("#btnInstructivos").click(() => {
        window.open("#", '_blank');
    });
    $("#examed").hide();
    $("#dni").hide();
    $("#Naten").hide();
    if ($('#XXXXXXXX').length) {
        var scrollTrigger = 100, // px
            backToTop = function () {
                var scrollTop = $(window).scrollTop();
                if (scrollTop > scrollTrigger && $("#Nom").val() != "") {

                    if ($("#checkBox999").is(':checked')) {
                        console.log("rut checked");
                        $("#xxx_xxx").text("Rut: " + $("#rut").val() + " Nombre: " + $("#Nom").val() + " " + $("#Ape").val() + " Edad: " + $("#Edad").val() + " Sexo: " + $("#sex option:selected").text())
                    }
                    else if ($("#checkBox888").is(':checked')) {
                        console.log("dni checked");
                        $("#xxx_xxx").text("D.N.I: " + $("#dni").val() + " Nombre: " + $("#Nom").val() + " " + $("#Ape").val() + " Edad: " + $("#Edad").val() + " Sexo: " + $("#sex option:selected").text())
                    }
                    else if ($("#checkBox8887").is(':checked')) {
                        console.log("nate checked");
                        $("#xxx_xxx").text("Folio: " + $("#Naten").val() + " Nombre: " + $("#Nom").val() + " " + $("#Ape").val() + " Edad: " + $("#Edad").val() + " Sexo: " + $("#sex option:selected").text())
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
    $("#button_modal_pago").click(function () {


        if (Mx_Dt023.length != 0) {

            objAJAX_Atenc.callback([
                Mx_Dt023.ID_Atencion
            ]);
        }
    });

    $(`#Procedencia`).change(() => {
        fn_Req_Prev();
    });

    $(`#Prevision`).change(() => {
        fn_Req_Prog();
    });

    $(`#Programa`).change(() => {
        fn_Req_SubP();
    });

    $("#Cuidad").change(() => {
        fn_Req_Comuna();
    });

    Ajax_DL_SEXO();
    Ajax_DL_GENERO();
    Ajax_DL_NAC();
    //Ajax_Ciudad();
    Call_AJAX_Ddl();
    fn_Req_Ciud();
    Ajax_DL_sec();
    Ajax_DL_Empresa()
    Ajax_DL_TP_ATE();
    Ajax_DL_orden_ate();
    Ajax_DataTable_examen0GObal();
    Ajax_DL_DOC();
    Ajax_Diagnostico();
    $("#checkBox2").prop('checked', false);//solo los del objeto
    $("#checkBox999").prop('checked', true);
    $("#checkBox999").change(function () {
        if ($(this).is(':checked')) {
            $("#checkBox888").prop('checked', false);
            $("#checkBox8887").prop('checked', false);
            $("#chk_Examed").prop('checked', false);
            $("#rut").show();
            $("#dni").hide();
            $("#Naten").hide();
            $("#examed").hide();
        }
    });
    $("#checkBox888").change(function () {
        if ($(this).is(':checked')) {
            $("#checkBox999").prop('checked', false);
            $("#checkBox8887").prop('checked', false);
            $("#chk_Examed").prop('checked', false);
            $("#rut").hide();
            $("#dni").show();
            $("#Naten").hide();
            $("#examed").hide();
        }
    });
    $("#checkBox8887").change(function () {
        if ($(this).is(':checked')) {
            $("#checkBox999").prop('checked', false);
            $("#checkBox888").prop('checked', false);
            $("#chk_Examed").prop('checked', false);
            $("#rut").hide();
            $("#dni").hide();
            $("#examed").hide();
            $("#Naten").show();
        }
    });

    $("#chk_Examed").change(function () {
        if ($(this).is(':checked')) {
            $("#checkBox999").prop('checked', false);
            $("#checkBox888").prop('checked', false);
            $("#rut").hide();
            $("#dni").hide();
            $("#Naten").hide();
            $("#examed").show();
        }
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
            $("<th>", { "class": "textoReducido text-center" }).text("Sitio anatómico"), //LE SAQUE EL COMENTADO
            $("<th>", { "class": "textoReducido text-center" }).text("Dias Proceso"),
            $("<th>", { "class": "textoReducido text-center" }).text("Eliminar")
            //,
            //$("<th>", { "class": "textoReducido" }).text("Cambio de Estado")
        )
    );
    add_row();


    //-*-*-*-*-*-*-*-*-*-*-*-*-*
    $("#Btnnew").click(function () {

        $("#slctGrupoPesquisaVIH, #slctGrupoPesquisaRPRChagas").empty().append(
            $("<option>", { value: 0, text: "No Aplica" })
        );
        Mx_Examed = [];
        Limpia_Modal_Examed();
        Ajax_DL_SEXO();
        Ajax_DL_NAC();
        //Ajax_Ciudad();
        fn_Req_Ciud();
        $("#txtrut").val("");
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
        $("#examed").val("");
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
        $("#ddlEtnia").val(1);
        $("#txtNombreSocial").val("");
        $("#obdser").val("");
        $("#obs_ate").val("");
        $("#PrioridadTM").val(1);
        $("#TipoAtencion").val(1);
        $("#slctGrupoPesquisaVIH").attr("disabled", true);
        $("#slctGrupoPesquisaRPRChagas").attr("disabled", true);
        $("#TipoAtencion").val(1);
        $("#Genero").val(0);
        $("#Doctor").val("");
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
        $('#XXXXXXXX').removeClass('show');

        //Actualizar Posición Ddl
        let xVal = 0;
        if ($("#chkMant_0").prop("checked") == false) {
            xVal = $("#Procedencia option").eq(0).val();
            $("#Procedencia").val(51);
        }

        setTimeout(() => {
            if ($("#chkMant_3").prop("checked") == false) {
                xVal = $("#Prevision option").eq(0).val();
                $("#Prevision").val(
                    parseInt(xVal)
                );
            }

            setTimeout(() => {
                if ($("#chkMant_4").prop("checked") == false) {
                    xVal = $("#Empresa option").eq(0).val();
                    $("#Empresa").val(
                        parseInt(xVal)
                    );
                }

                setTimeout(() => {
                    if ($("#chkMant_1").prop("checked") == false) {
                        fn_Req_Prog();
                        xVal = $("#Programa option").eq(0).val();
                        $("#Programa").val(
                            parseInt(xVal)
                        );
                    }

                    setTimeout(() => {
                        if ($("#chkMant_2").prop("checked") == false) {
                            fn_Req_SubP();
                            xVal = $("#Ddl_Prog02 option").eq(0).val();
                            $("#Ddl_Prog02").val(
                                parseInt(xVal)
                            );
                        }
                    }, 1000);
                }, 1000);
            }, 1000);
        }, 1000);
    });
    //$("#fecha").change(function () {
    //    var asd = moment($("#fecha").val()).format("DD-MM-YYYY");



    //    var array = asd.split("-");
    //    var total = "";
    //    var dia = array[0];
    //    var mes = array[1];
    //    var ano = array[2];
    //    if (dia < 10) { dia = "0" + dia; }
    //    if (mes < 10) { mes = "0" + mes; }
    //    // cogemos los valores actuales
    //    var fecha_hoy = new Date();
    //    var ahora_ano = fecha_hoy.getYear();
    //    var ahora_mes = fecha_hoy.getMonth() + 1;
    //    var ahora_dia = fecha_hoy.getDate();

    //    // realizamos el calculo
    //    var edad = (ahora_ano + 1900) - ano;
    //    if (ahora_mes < mes) {
    //        edad--;
    //    }
    //    if ((mes == ahora_mes) && (ahora_dia < dia)) {
    //        edad--;
    //    }
    //    if (edad > 1900) {
    //        edad -= 1900;
    //    }
    //    // calculamos los meses
    //    var meses = 0;
    //    if (ahora_mes > mes)
    //        meses = ahora_mes - mes;
    //    if (ahora_mes < mes)
    //        meses = 12 - (mes - ahora_mes);
    //    if (ahora_mes == mes && dia > ahora_dia)
    //        meses = 11;
    //    // calculamos los dias
    //    var dias = 0;
    //    total = String(edad + " Años " + meses + " meses " + dias + " dia");
    //    if (ahora_dia > dia) {
    //        dias = ahora_dia - dia;
    //        total = String(edad + " Años " + meses + " meses " + dias + " dia");
    //    }
    //    if (ahora_dia < dia) {
    //        let ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
    //        dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
    //        total = String(edad + " Años " + meses + " meses " + dias + " dia");
    //    }
    //    $("#Edad").val(total);

    //});

    $("#fecha").change(function () {
        let valorFecha = $("#fecha").val(); // Ejemplo: "1993-04-06T10:00"

        console.log(`Valor fecha: ${valorFecha}`);

        if (valorFecha === '') {
            $("#Edad").val('');
            return;
        }

        // Obtener solo la parte de la fecha sin la hora
        let fechaSinHora = valorFecha.split("T")[0];

        // Asegurar que Moment.js esté leyendo correctamente el formato
        let fechaNacimiento = moment(fechaSinHora, "YYYY-MM-DD");
        let hoy = moment();

        // Validar que no sea una fecha futura
        if (fechaNacimiento.isAfter(hoy)) {
            $("#Edad").val('Fecha inválida');
            return;
        }

        // Calcular diferencia exacta
        let años = hoy.diff(fechaNacimiento, 'years');
        let meses = hoy.diff(fechaNacimiento.clone().add(años, 'years'), 'months');
        let días = hoy.diff(fechaNacimiento.clone().add(años, 'years').add(meses, 'months'), 'days');

        // Formato de resultado
        let total = `${años} Años ${meses} meses ${días} días`;
        $("#Edad").val(total);
    });

    $("#sex").change(function () {
        console.log("sex change");
        var sex = $("#sex option:selected").text();
        var val_sex = $("#sex option:selected").val();

        const generoMap = { 1: 5, 2: 6 };
        if (generoMap[val_sex]) {
            $("#Genero").val(generoMap[val_sex]);
        }
      

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
                $('#XXXXXXXX').removeClass('show');
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

                    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1405) {
                        Mx_Dtt_examcof.splice(z, 1);
                        xxxer = true;
                    }

                }
                if (xxxer == true) {
                    for (let x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                        if (Mx_Dtt_exam02_respaldo[x].ID_CODIGO_FONASA == 1406) {
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
                    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1406) {
                        Mx_Dtt_examcof.splice(z, 1);
                        xxxer = true;
                    }
                    //}
                }
                if (xxxer == true) {
                    for (let x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                        if (Mx_Dtt_exam02_respaldo[x].ID_CODIGO_FONASA == 1405) {
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
                    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 690 || Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 691 || Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1405 || Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1406) {
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
                $('#XXXXXXXX').removeClass('show');

                $("#rut").val("");
                $("#rut").css({
                    "border-color": "red"
                });

            } else {
                $("#dni").css({
                    "border-color": "green"
                });
                Ajax_busca_dni();
            }
        }
    });

    $("#Naten").keydown(function EnterEvent(e) {
        if (e.keyCode == 13) {

            Ajax_modal_exa();
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


    $("#examed").keydown(function EnterEvent(e) {
        if (e.keyCode == 13) {
            Mx_Examed = [];
            Limpia_Modal_Examed();
            $("#rut").val("");
            $("#dni").val("");
            if ($("#examed").val() != "") {
                Ajax_Busca_Prei_Examed();
            }
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
                    $('#XXXXXXXX').removeClass('show');

                    $("#rut").val("");
                    $("#rut").css({
                        "border-color": "red"
                    });
                } else {
                    $("#rut").css({
                        "border-color": "green"
                    });
                    $("#rut").val(obj_RUT.Format);

                    console.log("OBJ DATA: ",obj_RUT.Format)
                    Ajax_busca_rut();
                }
            }
        }
    });
    $("#rut").focusout(function () {
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
                Ajax_busca_rut();
            }
        }
    });
    $("#dni").focusout(function () {
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
            Ajax_busca_dni();
        }
    });
    $("#Prevision").change(function () {
        Mx_Dtt_exam02.length = 0;
        Ajax_DataTable_examen02();
        $("#DataTable_pac2 tbody").empty();
        add_row();
    });

    fillEtnias({ idSelect: "ddlEtnia" });

    $("#BtnSaveAll").click(async function () {
        const fields = [
            { id: "#Nom", parent: 1 },
            { id: "#Ape", parent: 1 },
            { id: "#Edad", parent: 2, element: "#fecha" },
            { id: "#sex", parent: 1 },
            { id: "#Nacio", parent: 1 },
            { id: "#Cuidad", parent: 1 },
            { id: "#Comuna", parent: 1 },
            { id: "#Celular", parent: 1 },
            { id: "#Doctor", parent: 1 },
            { id: "#Genero", parent: 1 } // Campo del doctor para activar Ajax_Graba_Edita_Doctor
        ];

        let sum = 0;

        // Función de validación
        const validateField = (field) => {
            const element = field.element || field.id;
            const parent = field.parent === 2 ? $(element).parent().parent() : $(element).parent();

            if ($(element).val() === "" || $(element).val() === "0") {
                $(element).css("border-color", "red");
                parent.css("color", "red");
            } else {
                sum += 1;
                $(element).css("border-color", "#ccc");
                parent.css("color", "#212529");
            }
        };

        // Validar todos los campos
        fields.forEach(validateField);

        // Verificar si el campo del doctor es válido para llamar a Ajax_Graba_Edita_Doctor
        if ($("#Doctor").val() !== "") {
            await Ajax_Graba_Edita_Doctor();
        }
      
        // Validación directa del valor
        //const valorVIH = $("#slctGrupoPesquisaVIH").val();
        //if (valorVIH == 0) {
        //    $("#slctGrupoPesquisaVIH").addClass("input-error");
        //    console.log(`Error: El campo con id 'slctGrupoPesquisaVIH' no puede tener el valor 0.`);
        //} else {
        //    $("#slctGrupoPesquisaVIH").removeClass("input-error");
        //}


        //// Validación directa del valor
        //const valorRPRChagas = $("#slctGrupoPesquisaRPRChagas").val();
        //if (valorRPRChagas == 0) {
        //    $("#slctGrupoPesquisaRPRChagas").addClass("input-error");
        //    console.log(`Error: El campo con id 'slctGrupoPesquisaRPRChagas' no puede tener el valor 0.`);
        //} else {
        //    $("#slctGrupoPesquisaRPRChagas").removeClass("input-error");
        //}
        // Validación para impedir el valor 0
        const existeVIH = Mx_Dtt_examcof.some(item => item.CF_COD == "0306112");
        const existeRPRChagas = Mx_Dtt_examcof.some(item => item.CF_COD == "0306038" || item.CF_COD == "0306061");
        if (existeVIH) {
            const valorVIH = $("#slctGrupoPesquisaVIH").val();
            if (valorVIH == 0) {
                $("#slctGrupoPesquisaVIH").addClass("input-error");
                console.log(`Error: El campo con id 'slctGrupoPesquisaVIH' no puede tener el valor 0.`);
                Swal.fire({
                    title: "Aviso",
                    text: "Falta cargar grupo pesquisa VIH",
                    icon: "warning"
                });
                return
            } else {
                $("#slctGrupoPesquisaVIH").removeClass("input-error");
            }
        }
        if (existeRPRChagas) {
            const valorRPRChagas = $("#slctGrupoPesquisaRPRChagas").val();
            if (valorRPRChagas == 0) {
                $("#slctGrupoPesquisaRPRChagas").addClass("input-error");

                Swal.fire({
                    title: "Aviso",
                    text: "Falta cargar grupo pesquisa R.P.R/Chagas",
                    icon: "warning"
                });
                return
            } else {
                $("#slctGrupoPesquisaRPRChagas").removeClass("input-error");
            }
        }


        if (Mx_Dtt_examcof.length == 0) {
            return Swal.fire({
                icon: 'warning',
                title: 'Advertencia',
                text: 'Falta agregar exámenes',
                confirmButtonText: 'Aceptar'
            });
        }


        // Verificar si todos los campos son válidos
        if (sum === fields.length || Mx_Dtt_examcof.lenght > 0) {
            //if ($("#rut").val() === "") {

            //    verrut = 2;
            //}
            await Ajax_guardar();

        } else {
            guardadoEnProceso = false;

            $("#mError_AAH").modal('hide');
            $("#title").text("Faltan campos por llenar");
            $("#button_modal").attr("class", "btn btn-danger");
            $("#mError_AAH p").text("Por favor llenar los campos marcados con color rojo");
            $("#mError_AAH").modal();
            $('#XXXXXXXX').removeClass('show');

            $('body, html').animate({ scrollTop: '0px' }, 300);
        }
    });

    //-*-*-*-*-*-*-*-*-* TABLA DINAMICA -*-*-*-*-*-*-*-*-*-*-*
    $("#Examen").click(function () {
        Fill_DataTable_exam02();
        $('#eModal2').modal('show');
        $('#XXXXXXXX').removeClass('show');
        Mx_Carga = [];
    });


    $("#Pack_Exam").click(function () {
        Fill_DataTable_Pack();
        $('#eModal3').modal('show');
        $('#XXXXXXXX').removeClass('show');
        Mx_Carga_Pack = [];
    });


    /////llenado tabla con modal  a  atabla principal
    //$("#btnguardar").click(function () {
    //    $("#DataTable_pac_filter input").val("").trigger("input");
    //    for (let z = 0; z < Mx_Dtt_examcof.length; z++) {
    //        for (let x = 0; x < Mx_Carga.length; x++) {
    //            if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == Mx_Carga[x]) {
    //                Mx_Carga.splice(x, 1);
    //            }
    //        }
    //    }

    //    for (let i = 0; i < Mx_Carga.length; i++) {
    //        for (let x = 0; x < Mx_Dtt_exam02.length; x++) {
    //            if (Mx_Carga[i] == Mx_Dtt_exam02[x].ID_CODIGO_FONASA) {
    //                Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02[x]));
    //                Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
    //            }
    //        }
    //    }

    //    fill_llenado_tabla();
    //    $('#eModal2').modal('hide');
    //});

    //llenado tabla con modal  a  atabla principal
    $("#btnguardar").click(function () {
        $("#DataTable_pac_filter input").val("").trigger("input");
        selected = new Array();
        $(".pp input:checkbox:checked").each(function () {
            selected.push($(this).val());
        });
        for (var z = 0; z < Mx_Dtt_examcof.length; z++) {
            for (var x = 0; x < selected.length; x++) {
                if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == selected[x]) {
                    selected.splice(x, 1);
                    console.log("1");
                }
                    
            }
        }
        for (var i = 0; i < selected.length; i++) {
            for (var x = 0; x < Mx_Dtt_exam02.length; x++) {
                if (selected[i] == Mx_Dtt_exam02[x].ID_CODIGO_FONASA) {

                    const item1084 = Mx_Dtt_exam02.find((item) => item.ID_CODIGO_FONASA == 1084);
                    if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 941) {
                        if (item1084) {
                            Mx_Dtt_examcof.push(fnClone(item1084));
                        } else {
                            Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02[x]));
                        }
                    } else {
                        Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02[x]));
                    }

                    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo";
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

    //$(document).on('click', '.borrar', function (event) {
    //    var rowstota = document.getElementById("DataTable_pac2").rows.length;
    //    var ff = $(this).parent().parent().children().children('.td_input').attr('data-id');
    //    event.preventDefault();
    //    if (rowstota > 2) {
    //        for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
    //            if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == ff) {
    //                Mx_Dtt_examcof.splice(i, 1);
    //            }
    //            $(this).closest('tr').remove();
    //            for (let x = 0; x < Mx_Dtt_examcof.length; x++) {
    //                if (Mx_Dtt_examcof[x].ID_CODIGO_FONASA == 1054) {
    //                    sifi = 1;
    //                } else {
    //                    sifi = 0;
    //                }
    //            }
    //        }
    //    } else {
    //        var str_Error = "El campo no puede ser eliminado"
    //        $("#title").text("Eliminar Examen");
    //        $("#button_modal").attr("class", "btn btn-danger");

    //        $("#mError_AAH p").text(str_Error);
    //        $("#mError_AAH").modal();
    //        $('#XXXXXXXX').removeClass('show');
    //    }
    //});
    $(document).on('click', '.borrar', function (event) {
        var rowstota = document.getElementById("DataTable_pac2").rows.length;
        var ff = $(this).parent().parent().children().children('.td_input').attr('data-id');
        event.preventDefault();
        if (rowstota > 2) {
            for (var i = 0; i < Mx_Dtt_examcof.length; i++) {
                if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == ff) {
                    Mx_Dtt_examcof.splice(i, 1);
                }
                $(this).closest('tr').remove();
                for (var x = 0; x < Mx_Dtt_examcof.length; x++) {
                    if (Mx_Dtt_examcof[x].ID_CODIGO_FONASA == 1054) {
                        sifi = 1;
                    } else {
                        sifi = 0;
                    }
                }
            }

            const existeVIH = Mx_Dtt_examcof.some((item) => item.CF_COD == "0306112");
            const existeRPRChagas = Mx_Dtt_examcof.some((item) => item.CF_COD == "0306038" || item.CF_COD == "0306061");

            if (!existeVIH) {
                $("#slctGrupoPesquisaVIH").attr("disabled", true)
            }
            if (!existeRPRChagas) {
                $("#slctGrupoPesquisaRPRChagas").attr("disabled", true)
            }

            

            console.log(`CANTIDAD DE EXAMENES: ${Mx_Dtt_examcof.length}`)
            recalculateTotal(); // Recalcular el total
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

    $("#btn_Actu_Exa_DNI").click(() => {
        modal_show();

        if ($("#dni").val() != "") {
            $('#txtrut').val($("#dni").val());
        } else {
            $('#txtrut').val($("#rut").val());
        }

        $("#Nom").val(Mx_Examed[0].NOM_PAC_EXA);
        $("#Ape").val(Mx_Examed[0].APE_PAC_EXA);
        $("#Celular").val(Mx_Examed[0].FONO_PAC_EXA);
        $("#Email").val(Mx_Examed[0].EMAIL_PAC_EXA);
        $("#direccion").val(Mx_Examed[0].DIR_PAC_EXA);
        let fnac_exa = moment(Mx_Examed[0].FNAC_PAC_EXA).format("YYYY-MM-DD")
        $("#fecha").val(fnac_exa);
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
                let ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                total = String(edad + " Años");
            }
            return total
        });
        $("#sex").val(Mx_Examed[0].SEXO_PAC_EXA);
        $("#Nacio").val(1);

        //$("#mdl_Actu_Exa").modal("hide");
        Hide_Modal();
    });

});
let Mx_Examed = [{
    "RUT_PAC_EXA": "",
    "NOM_PAC_EXA": "",
    "APE_PAC_EXA": "",
    "FNAC_PAC_EXA": "",
    "SEXO_PAC_EXA": "",
    "FONO_PAC_EXA": "",
    "DIR_PAC_EXA": "",
    "EMAIL_PAC_EXA": ""
}]


function Limpia_Modal_Examed() {
    $("#NDE_RUT").text("");
    $("#NDE_NOM").text("");
    $("#NDE_APE").text("");
    $("#NDE_FNAC").text("");
    $("#NDE_SEX").text("");
    $("#NDE_DIR").text("");
    $("#NDE_FONO").text("");
    $("#NDE_CORR").text("");


    // ACTUALES

    $("#ADE_RUT").text("");
    $("#ADE_NOM").text("");
    $("#ADE_APE").text("");
    $("#ADE_FNAC").text("");
    $("#ADE_SEX").text("");
    $("#ADE_DIR").text("");
    $("#ADE_FONO").text("");
    $("#ADE_CORR").text("");
}

// JSON EXAMED
function Ajax_Busca_Prei_Examed() {
    var Data_Par_modal = JSON.stringify({
        "PREI_NUM": $("#examed").val()
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/BUSCA_PREI_EXAMED",
        "data": Data_Par_modal,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_Examed = json_receiver;
                console.log(Mx_Examed);

                let vrut = Valid_RUT(Mx_Examed[0].RUT_PAC_EXA).Valid;

                if (vrut == true) {
                    $("#rut").val(Mx_Examed[0].RUT_PAC_EXA);
                    Ajax_busca_rut();
                } else {
                    $("#dni").val(Mx_Examed[0].RUT_PAC_EXA);
                    Ajax_busca_dni();
                }


            } else {
                console.log(response);
            }
        },
        "error": function (response) {
            console.log(response);
        }

    });
}



//-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

//--------------------------------------- JASON DIAGNOSTICO --------------------------------------------------------------------|
var Mx_Diagnostico = [
    {
        "ID_DIAGNOSTICO": 0,
        "DIA_COD": 0,
        "DIA_DESC": 0,
        "ID_ESTADO": 0
    }
];

function Ajax_Diagnostico() {



    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_Diagnostico = json_receiver;
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
    var Data_Par_modal = JSON.stringify({
        "ID": $("#Naten").val()
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/MODAL_PAC",
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

            //// MOSTRAR EL MODAL
            //$('#eModales33').modal('show');
        },
        "error": Data_Par_modal_paciente => {
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
            $("#ddlEtnia").val(1);
            $("#txtNombreSocial").val("");
            Mx_Dtt_examcof.length = 0;
            $("#DataTable_pac2 tbody").empty();
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
        "url": "Ingreso_Ate.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_DL_Diag = json_receiver;
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
        "url": "Ingreso_Ate.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST2",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_DL_Diag2 = json_receiver;
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

    if (Mx_Detalle_ate.proparra2.length > 0) {
        $("#Avis").val(Mx_Detalle_ate.proparra2[0].ATE_NUM_AVIS);
    }
    let FechaREE = moment(Mx_Detalle_ate.proparra1[0].PAC_FNAC).format("YYYY-MM-DD");
    $("#txtrut").val(Mx_Detalle_ate.proparra1[0].PAC_NOMBRE);
    $("#dni").val(Mx_Detalle_ate.proparra1[0].DNI);
    $("#Nom").val(Mx_Detalle_ate.proparra1[0].PAC_NOMBRE);
    $("#Ape").val(Mx_Detalle_ate.proparra1[0].PAC_APELLIDO);
    $("#fecha").val(FechaREE);
    $("#Edad").val(`${Mx_Detalle_ate.proparra1[0].PREI_AÑO} años`);
    $("#telfijo").val(Mx_Detalle_ate.proparra1[0].PAC_FONO1);
    $("#Celular").val(Mx_Detalle_ate.proparra1[0].PAC_MOVIL1);
    Ajax_DataTable_examen02();
    $("#Programa").val(Mx_Detalle_ate.proparra3[0].ID_PROGRAMA);
    $("#Sector").val(Mx_Detalle_ate.proparra3[0].ID_SECTOR);
    $("#Empresa").val(Mx_Detalle_ate.proparra3[0].ID_EMPRESA);
    $("#Prevision").val(Mx_Detalle_ate.proparra3[0].ID_PREVE);
    $("#Doctor").val(Mx_Detalle_ate.proparra3[0].ID_DOCTOR);
    Ajax_DLdiag(Mx_Detalle_ate.proparra3[0].ID_DIAGNOSTICO);
    Ajax_DLdiag2(Mx_Detalle_ate.proparra3[0].ID_DIAGNOSTICO2);
    $("#sub_atencion").val(Mx_Detalle_ate.proparra3[0].Sub_atencion);
    var obj_RUT2 = Valid_RUT($("#txtrut").val());
    $("#txtrut").val(obj_RUT2.Format);
    $("#Nacio").val(Mx_Detalle_ate.proparra1[0].id_Nacionalidad);
    //$("#obs_ate").val(Mx_Detalle_ate.proparra1[0].PREI_OBS_TM);
    if (Mx_Detalle_ate.proparra1[0].SEXO_DESC == 'Masculino') {
        $("#sex").val(1);
    } else {

        $("#sex").val(2);
    }
    var aaa = {};
    if (Mx_Detalle_ate.proparra2.length > 0) {
        Mx_Dtt_examcof.length = 0;
        for (let p = 0; p < Mx_Detalle_ate.proparra2.length; p++) {
            var objId = {
                "ID_CODIGO_FONASA": Mx_Detalle_ate.proparra2[p].ID_CODIGO_FONASA,
                "CF_COD": Mx_Detalle_ate.proparra2[p].CF_COD,
                "CF_DESC": Mx_Detalle_ate.proparra2[p].CF_DESC,
                "CF_DIAS": Mx_Detalle_ate.proparra2[p].CF_DIAS,
                "ID_PER": Mx_Detalle_ate.proparra2[p].ID_PER,
                "HO_CC": Mx_Detalle_ate.proparra2[p].ATE_NUM_AVIS
            };
            Mx_Dtt_examcof.push(fnClone(objId));
            Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
        }

        for (let l = 0; l < Mx_Dtt_examcof.length; l++) {
            for (let k = 0; k < Mx_Dtt_exam02.length; k++) {

                if (Mx_Detalle_ate.proparra2[l].ID_CODIGO_FONASA == Mx_Dtt_exam02[k].ID_CODIGO_FONASA) {
                    Mx_Dtt_examcof[l]["CF_PRECIO_AMB"] = Mx_Dtt_exam02[k].CF_PRECIO_AMB
                }
            }


        }


        fill_llenado_tabla();
    } else {

        $("#DataTable_pac2 tbody").empty();
        add_row();

        var str_Error = "Estimado usuario el numero atención no contiene exámenes Pendientes"
        $("#title").text("Ingreso de Atención");
        $("#button_modal").attr("class", "btn btn-danger");
        $("#mError_AAH p").text(str_Error);
        $("#mError_AAH").modal();
        $('#XXXXXXXX').removeClass('show');

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
                        "class": "td_input negrita",
                        "value": ""
                    })
                }())),
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido td_val1 negrita"
                }).text(""),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido td_val3"
                }).text(""),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido td_val2 negrita"
                }).text(""),
                $("<td>", {
                    "align": "center"
                }).html("<button type='button' class='btn btn-danger btn-xs borrar negrita' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>")
                //,
                //$("<td>", {
                //    "align": "center"
                //}).html("<button type='button' class='btn btn-print btn-xs CEstado negrita' value='Espera' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>")

            )
        )
        //$(".td_input").keydown(function EnterEvent(e) {
        //    if (e.keyCode == 13) {
        //        xId = $(this).attr("data-id");
        //        var xcod = $(this).attr("data-cod");
        //        Ajax_DataTable_examen3($(this).val(), xId, xcod, $(this));
        //    }
        //});

        $(".td_input").keydown(function EnterEvent(e) {
            if (e.keyCode == 13) {
                xId = $(this).attr("data-id");
                var xcod = $(this).attr("data-cod");

                if (xcod === "sitio_anato") {
                    $(this).blur();
                    return;
                }


                if ($(this).val() == "0303031-3") {
                    // Si el valor es "0302048", ejecuta la función específica para Glucosa.
                    Ajax_DataTable_examen3_Glucosa($(this).val(), xId, xcod, $(this));
                } else {
                    // Para cualquier otro valor, ejecuta la función general.
                    Ajax_DataTable_examen3($(this).val(), xId, xcod, $(this));
                }
            }
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
                        "class": "td_input negrita",
                        "value": ""
                    })
                }())),
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido td_val1 negrita"
                }).text(""),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido td_val3"
                }).text(""),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido td_val2 negrita"
                }).text(""),

                $("<td>", {
                    "align": "center"
                }).html("<button type='button' class='btn btn-danger btn-xs borrar negrita' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'>Eliminar</i></button>")
                //,
                //$("<td>", {
                //    "align": "center"
                //}).html("<button type='button' class='btn btn-print btn-xs CEstado negrita' value='Espera' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Espera</button>")

            )
        )
        $(".td_input").focusout(function () {
            xId = $(this).attr("data-id");
            var xcod = $(this).attr("data-cod");

            if (xcod === "sitio_anato") {
                return;
            }

            Ajax_DataTable_examen3($(this).val(), xId, xcod, $(this));
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
Mx_Dtt_examcof.length = 0;
//-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
var Mx_Dt023 = [
    {
        "Correlativo": 0,
        "ID_Atencion": 0
    }
];
async function Ajax_guardar() {
    //modal_show();
    var fur = 0;
    var OB = "";
    var ID = 0;
    var ed = (function () {
        var asd = $("#fecha").val(); // Obtiene el valor del input en formato datetime-local
        if (!asd) return ""; // Si no hay fecha seleccionada, retorna vacío

        // Extraemos solo la parte de la fecha (YYYY-MM-DD) del valor
        var array = asd.split("T")[0].split("-");
        var dia = parseInt(array[2], 10); // Día (convertido a entero)
        var mes = parseInt(array[1], 10); // Mes (convertido a entero)
        var ano = parseInt(array[0], 10); // Año (convertido a entero)

        // Obtenemos la fecha actual
        var fecha_hoy = new Date();
        var ahora_ano = fecha_hoy.getFullYear(); // Año actual
        var ahora_mes = fecha_hoy.getMonth() + 1; // Mes actual (0-indexado, por eso +1)
        var ahora_dia = fecha_hoy.getDate(); // Día actual

        // Calculamos la edad en años
        var edad = ahora_ano - ano;
        if (ahora_mes < mes || (ahora_mes === mes && ahora_dia < dia)) {
            edad--; // Restamos un año si el mes o día actual aún no ha alcanzado el cumpleaños
        }

        // Calculamos los meses
        var meses = ahora_mes - mes;
        if (meses < 0) meses += 12; // Ajustamos los meses si son negativos
        if (meses === 0 && ahora_dia < dia) meses = 11; // Caso especial: no se cumplió el mes completo

        // Calculamos los días
        var dias = ahora_dia - dia;
        if (dias < 0) {
            let ultimoDiaMes = new Date(ahora_ano, ahora_mes - 1, 0).getDate(); // Último día del mes anterior
            dias += ultimoDiaMes;
        }

        // Retornamos solo los años como total (según tu lógica actual)
        return String(edad);
    }());

    //var ed = (function () {
    //    var asd = moment($("#fecha").val()).format("DD-MM-YYYY");
    //    var array = asd.split("-")
    //    var total = ""
    //    var dia = array[0];
    //    var mes = array[1];
    //    var ano = array[2];

    //    if (dia < 10) { dia = "0" + dia; }
    //    if (mes < 10) { mes = "0" + mes; }
    //    // cogemos los valores actuales
    //    var fecha_hoy = new Date();
    //    var ahora_ano = fecha_hoy.getYear();
    //    var ahora_mes = fecha_hoy.getMonth() + 1;
    //    var ahora_dia = fecha_hoy.getDate();

    //    // realizamos el calculo
    //    var edad = (ahora_ano + 1900) - ano;
    //    if (ahora_mes < mes) {
    //        edad--;
    //    }
    //    if ((mes == ahora_mes) && (ahora_dia < dia)) {
    //        edad--;
    //    }
    //    if (edad > 1900) {
    //        edad -= 1900;
    //    }
    //    // calculamos los meses
    //    var meses = 0;
    //    if (ahora_mes > mes)
    //        meses = ahora_mes - mes;
    //    if (ahora_mes < mes)
    //        meses = 12 - (mes - ahora_mes);
    //    if (ahora_mes == mes && dia > ahora_dia)
    //        meses = 11;
    //    // calculamos los dias
    //    var dias = 0;
    //    total = String(edad);
    //    if (ahora_dia > dia) {
    //        dias = ahora_dia - dia;
    //        total = String(edad);
    //    }
    //    if (ahora_dia < dia) {
    //        let ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
    //        dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
    //        total = String(edad);
    //    }
    //    return total;

    //}());
    console.log(`Edad: ${ed}`)
    var me = (function () {
        var asd = moment($("#fecha").val()).format("DD-MM-YYYY");
        var array = asd.split("-")
        var total = ""
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
        total = String(meses);
        if (ahora_dia > dia) {
            dias = ahora_dia - dia;
            total = String(meses);
        }
        if (ahora_dia < dia) {
            let ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
            dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
            total = String(meses);
        }
        return total;

    }());
    var di = (function () {
        var asd = moment($("#fecha").val()).format("DD-MM-YYYY");
        var array = asd.split("-")
        var total = ""
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
        total = String(dias);
        if (ahora_dia > dia) {
            dias = ahora_dia - dia;
            total = String(dias);
        }
        if (ahora_dia < dia) {
            let ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
            dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
            total = String(dias);
        }
        return total;

    }());

    var TOTAL = 0;
    var HO_CC = "";
    var numeritocliniquito = 0;
    //LO COMENTE POR QUE MAS ARRIBA HAY OTRO 
    ids = new Array();

    ids = Mx_Dtt_examcof.map(examen => {
        console.log(`Examen ${examen.SITIO_ANATO}`);

        const examenRespaldo = Mx_Dtt_exam02_respaldo_global.find(respaldo => respaldo.ID_CODIGO_FONASA == examen.ID_CODIGO_FONASA);

        // Capturar los valores de los atributos data-id y data-anato
        const inputElement = $(`input[data-id="${examen.ID_CODIGO_FONASA}"][data-cod="sitio_anato"]`);
        const sitioAnatoValue = inputElement.val() || "";
        const dataAnato = inputElement.attr("data-anato"); // También funciona, pero devuelve un string


        console.log("examenRespaldo", examenRespaldo);

        TOTAL += parseFloat(examenRespaldo.CF_PRECIO_AMB);

        return {
            id_CF: examen.ID_CODIGO_FONASA,
            id_PER: examenRespaldo.ID_PER,
            Valor: examenRespaldo.CF_PRECIO_AMB,
            Clinico: numeritocliniquito,
            CF_ESTADO_EXAMEN: examen.CF_ESTADO_EXAMEN,
            CF_VIH: examenRespaldo.CF_VIH,
            SITIO_ANATO: dataAnato ? sitioAnatoValue : null,
            IS_ANATO: dataAnato,
            CF_DESC: examen.CF_DESC
        };
    });


    console.log("deberia entrar aqui ", ids)

    const primeraLetraNombre = ($("#Nom").val() || " ")[0];
    const apellidos = ($("#Ape").val() || "").split(" ");
    let letrasApellidos = "";
    if (apellidos.length >= 2) {
        letrasApellidos = (apellidos[0][0] || " ") + (apellidos[1][0] || " ");
    } else if (apellidos.length === 1) {
        letrasApellidos = (apellidos[0][0] || " ");
    } else {
        letrasApellidos = "  "; // Si no hay apellidos, asigna dos espacios en blanco
    }
    const fechaNacimientoNumeros = moment($("#fecha").val() || "").format("DDMMYY");
    const numerosRut = ($('#rut').val() || "ABC-D").slice(-5);

    const nombreCodificadoParaSepararVIH = primeraLetraNombre + letrasApellidos + fechaNacimientoNumeros + numerosRut;

    if (ids.some(item => item.CF_VIH)) {
        const { isConfirmed: confirmaCodificacion } = await Swal.fire({
            icon: "question",
            title: nombreCodificadoParaSepararVIH,
            text: `Verifique que la codificación del paciente para el ingreso VIH sea correcta. Si necesita cambiarlo modifique nombre, apellidos, rut o fecha de nacimiento. ¿Desea continuar?`,
            showDenyButton: true,
            confirmButtonText: 'Ingresar',
            denyButtonText: `Cancelar`
        })
        if (!confirmaCodificacion) return;
    }

    

    let gg = new Array();

    $("#checkBox2:checkbox:checked").each(function () {
        gg.push($(this).val());
    });
    if (gg.length == 1) {
        fur = $("#FUR").val();
    } else {
        fur = "";
    }

    console.log(`Verrut: ${verrut}`);
    if (verrut == 1) {
        var OB = (Mx_Dtt2.length > 0 && Mx_Dtt2[0].ID_PACIENTE !== undefined)
            ? Mx_Dtt2[0].ID_PACIENTE
            : (Mx_Dtt2_dni.length > 0 && Mx_Dtt2_dni[0].ID_PACIENTE !== undefined)
                ? Mx_Dtt2_dni[0].ID_PACIENTE
                : null;

        var ID = (Mx_Dtt2.length > 0 && Mx_Dtt2[0].PAC_OBS_PERMA !== undefined)
            ? Mx_Dtt2[0].PAC_OBS_PERMA
            : (Mx_Dtt2_dni.length > 0 && Mx_Dtt2_dni[0].PAC_OBS_PERMA !== undefined)
                ? Mx_Dtt2_dni[0].PAC_OBS_PERMA
                : null;
    } else {
        var OB = "";
        var ID = 0;
    }
   

    var f = moment().format("DD-MM-YYYY");
    const idGrupoPesquisa = parseInt($("#slctGrupoPesquisaVIH").val()) || parseInt($("#slctGrupoPesquisaRPRChagas").val()) || 0;

    let vact;

    if ($("#chk_Busq_A").prop("checked") == true) {
        vact = 1;
    } else {
        vact = 0;
    }
    let Id_Doc;

    Id_Doc = $("#Doctor").attr("data-id");

    console.log(`Doctor: ${Id_Doc}`)

    if (Id_Doc == 0) {                      //<------------------------------

        Hide_Modal();
        return await Swal.fire({
            icon: "warning",
            title: "Aviso",
            text: `Verifique campos de doctor`,
        });
    }

    modal_show();
    console.log(moment($("#fecha").val()).format("DD-MM-YYYY HH:mm:ss"));
    let Data_Par = JSON.stringify({
        //-*-*-*-*Datos Paciente-*-*-*-*-*-*
        "RUT_PAC": $('#txtrut').val(),
        "NOMBRE_PAC": $("#Nom").val(),
        "APE_PAC": $("#Ape").val(),
        "FNAC_PAC": moment($("#fecha").val()).format("DD-MM-YYYY HH:mm:ss"),
        //"FNAC_PAC": $('#chk_neo').prop('checked')  ? moment($("#fecha").val()).format("DD-MM-YYYY HH:mm:ss") : moment($("#fecha").val()).format("DD-MM-YYYY"),
        "ID_SEXO": $("#sex").val(),
        "ID_GENERO": $("#Genero").val(),
        "ID_NACIONALIDAD": $("#Nacio").val(),
        "FONO1": $("#telfijo").val(),
        "MOVIL1": $("#Celular").val(),
        "ID_CIU_COM": $("#Comuna").val(),
        "DIR_PAC": $("#direccion").val(),
        "EMAIL_PAC": $("#Email").val(),
        "FUR": fur,
        "Paridad": verrut,
        "ID_PAC": OB,
        "OB": $("#obdser").val(),
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        "Procedencia": $("#Procedencia").val(),
        "Programa": $("#Programa").val(),
        "Sector": $("#Sector").val(),
        "EMPRESA": $("#Empresa").val(),
        "TipoAtencion": $("#TipoAtencion").val(),
        "PrioridadTM": $("#PrioridadTM").val(),
        "Doctor": Id_Doc,/*$("#Doctor").val(),*/
        "Prevision": $("#Prevision").val(),
        //-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*
        "EDAD": ed,
        "MES": me,
        "DIA": di,
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        "TOTAL": TOTAL,
        "FECHA_PRE": f,
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-    
        "ids": ids,
        "ate_obs": $("#obs_ate").val(),
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        "Interno": 1,
        "id_Diag": $("#DdlDiagnostico").val(),
        "id_Diag2": $("#DdlDiagnostico2").val(),
        "sub_atencion": 1,
        "vih": "",
        "dni": $("#dni").val(),
        "SUB_PROGRAMA": $("#Ddl_Prog02").val(),
        "S_Id_User": Galletas.getGalleta("ID_USER"),
        ID_ETNIA: $("#ddlEtnia").val(),
        PAC_NOM_SOCIAL: $("#txtNombreSocial").val(),
        "EPIVIGILA": $("#txt_Epivigila").val(),
        "BUSQUEDA_ACTIVA": vact,
        "EXAMED":0,
        nombreCodificadoParaSepararVIH,
        "GLUCOSA": selected_glu, //agregado
        "ID_GRUPO_PESQUISA": idGrupoPesquisa,
        "IS_NEO": $("#chk_neo").is(":checked") ? 1 : 0
    });

const filter_anato = ids.filter((item) => item.IS_ANATO == "true" && item.SITIO_ANATO == "");

console.log("ITEM: ", filter_anato);

    if (filter_anato.length > 0) {
        Hide_Modal();
        const itemList = filter_anato
            .map(item => `🔹 Examen: ${item.CF_DESC}`)
            .join("\n"); // Generar una lista con saltos de línea

        Swal.fire({
            icon: "warning",
            title: "Atención",
            html: `<strong>Los siguientes exámenes no tienen un sitio anatómico asignado:</strong><br><pre>${itemList}</pre>`,
            confirmButtonText: "Continuar ingreso",
            showCancelButton: true,
            cancelButtonText: "Regresar",
        }).then((result) => {
            if (result.isConfirmed) {
                SendData(Data_Par);
            }
        });
    } else {
        SendData(Data_Par)
    }

    
}


const SendData = (Data_Par) => {
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Guardar_TodoByVal",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": async function (response) {
            var json_receiver = response.d;
            console.log(json_receiver);
            //Comprobar Galletas
            if ((json_receiver == null) || (json_receiver == "")) {
                window.location = "/index.aspx";
                return;
            }

            if (json_receiver != null) {
                Mx_Examed = [];
                Limpia_Modal_Examed();

                Mx_Dt023 = (json_receiver);

                console.log(Mx_Dt023);
                Hide_Modal();
                Ajax_DL_SEXO();
                Ajax_DL_NAC();
                //Ajax_Ciudad();
                $('#txtrut').val("");
                //Ajax_DataTable();
                $('#chk_neo').prop('checked', false);
                $("#checkBox2").prop('checked', false);
                $('#FUR').attr("disabled", true);
                $('#checkBox2').attr("disabled", true);
                $("#fur").css("pointer-events", "none");
                var f = moment().format("DD-MM-YYYY");
                $("#obs_ate").val("");
                $("#NumeroClinico").val("");
                $("#txtNombreSocial").val("");
                $("#fecha").val(f);
                $("#fecha2").val(f);
                $("#FUR").val(f);
                $('#rut').removeAttr("disabled");
                $('#rut').val("");
                $("#examed").val("");
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
                $("#Genero").val(0);
                // Setear vacio campos para profesional
                $('#RUT_Doctor').val('');
                $('#Doctor').val('');


                Mx_Dtt_examcof.length = 0;
                $("#DataTable_pac2 tbody").empty();
                $("#Interno").val("");
                add_row();
                verrut = 0;
                Mx_Dtt2.length = 0;

                // Bandera para asegurar que preguntarImpresionPDF solo se llame una vez
                let pdfImpresoNormal = false;
                let pdfImpresoVIH = false;

                if (Mx_Dt023.CORELATIVO_VIH && Mx_Dt023.ID_Atencion_VIH) {
                    const { isConfirmed: voucher, isDismissed } = await Swal.fire({
                        icon: "success",
                        title: `N° Atención: ${Mx_Dt023.Correlativo} <br/> N° Atención VIH: ${Mx_Dt023.CORELATIVO_VIH}`,
                        text: `Se han creado 2 atenciones. ¿Desea imprimir los vouchers de atención?`,
                        showDenyButton: true,
                        showCancelButton: true,
                        confirmButtonText: 'Imprimir',
                        denyButtonText: 'Omitir',
                        cancelButtonText: 'Cerrar'
                    });

                    if (voucher) {
                        // Lógica de impresión de voucher para ambas atenciones
                        objAJAX_Atenc.success = async (resp) => {
                            console.log(`[ OK ] Impresión Voucher Atención`);
                            await Swal.fire({ icon: "success", text: "La impresión de Comprobante de Atención se ha completado exitosamente.", title: "Voucher" });

                            // Continuar con la impresión de PDFs
                            await preguntarImpresionProc();
                        };
                        objAJAX_Atenc.error = (jqXHR, textStatus, errorThrown) => {
                            console.error(`[ ERROR ] Impresión Voucher Atención`);
                            Swal.fire({ icon: "error", text: "Error en la impresión del comprobante de atención.", title: "Error" });
                        };
                        await objAJAX_Atenc.callback([Mx_Dt023.ID_Atencion, Mx_Dt023.ID_Atencion_VIH]);
                    } else if (!isDismissed) {
                        // Omitir pero continuar con la siguiente pregunta
                        await preguntarImpresionProc();
                    }
                } else {
                    const { isConfirmed, isDismissed } = await Swal.fire({
                        icon: "success",
                        title: `N° Atención: ${Mx_Dt023.Correlativo}`,
                        text: `Atención creada ¿Desea imprimir comprobante?`,
                        showDenyButton: true,
                        showCancelButton: true,
                        confirmButtonText: 'Imprimir',
                        cancelButtonText: 'Cerrar'
                    });

                    if (isConfirmed) {
                        // Lógica de impresión de voucher solo para la atención normal
                        objAJAX_Atenc.success = async (resp) => {
                            console.log(`[ OK ] Impresión Voucher Atención`);
                            //await Swal.fire({ icon: "success", text: "La impresión de Comprobante de Atención se ha completado exitosamente.", title: "Voucher" });

                            // Continuar con la impresión de PDFs
                            await preguntarImpresionProc();
                        };
                        objAJAX_Atenc.error = (jqXHR, textStatus, errorThrown) => {
                            console.error(`[ ERROR ] Impresión Voucher Atención`);
                            Swal.fire({ icon: "error", text: "Error en la impresión del comprobante de atención.", title: "Error" });
                        };
                        await objAJAX_Atenc.callback([Mx_Dt023.ID_Atencion]);
                    } else if (!isDismissed) {
                        // Omitir pero continuar con la siguiente pregunta
                        await preguntarImpresionProc();
                    }
                }

                // Función para preguntar si se desea imprimir el comprobante de toma de muestra
                async function preguntarImpresionProc() {
                    const { isConfirmed: printProc, isDismissed } = await Swal.fire({
                        icon: "question",
                        title: "Imprimir Comprobante de Toma de Muestra",
                        text: "¿Desea imprimir el comprobante de toma de muestra?",
                        showDenyButton: true,
                        showCancelButton: true,
                        confirmButtonText: 'Imprimir',
                        denyButtonText: 'Omitir',
                        cancelButtonText: 'Cerrar'
                    });

                    if (printProc) {
                        objAJAX_Proc.success = async (resp) => {
                            console.log(`[ OK ] Impresión Comprobante de Toma de Muestra`);
                            await Swal.fire({ icon: "success", text: "La impresión del comprobante de toma de muestra se ha completado exitosamente.", title: "Comprobante de Toma" });

                            // Continuar con la impresión de etiquetas
                            await preguntarImpresionEtiquetas();
                        };
                        objAJAX_Proc.error = (jqXHR, textStatus, errorThrown) => {
                            console.error(`[ ERROR ] Impresión Comprobante de Toma de Muestra`);
                            Swal.fire({ icon: "error", text: "Error en la impresión del comprobante de toma de muestra.", title: "Error" });
                        };
                        await objAJAX_Proc.callback([Mx_Dt023.ID_Atencion, Mx_Dt023.ID_Atencion_VIH]);
                    } else if (!isDismissed) {
                        // Omitir pero continuar con la impresión de etiquetas
                        await preguntarImpresionEtiquetas();
                    }
                }

                // Función para preguntar si se desea imprimir las etiquetas
                async function preguntarImpresionEtiquetas() {
                    const { isConfirmed: printEtiquetas, isDismissed } = await Swal.fire({
                        icon: "question",
                        title: "Imprimir Etiquetas",
                        text: "¿Desea imprimir las etiquetas?",
                        showDenyButton: true,
                        showCancelButton: true,
                        confirmButtonText: 'Imprimir',
                        denyButtonText: 'Omitir',
                        cancelButtonText: 'Cerrar'
                    });

                    if (printEtiquetas) {
                        objAJAX_Etiq.success = async (resp) => {
                            console.log(`[ OK ] Impresión Etiquetas`);
                            await Swal.fire({ icon: "success", text: "La impresión de Etiquetas se ha completado exitosamente.", title: "Etiquetas" });

                            // Imprimir los PDF correspondientes
                            //if (Mx_Dt023.CORELATIVO_VIH && Mx_Dt023.ID_Atencion_VIH) {
                            //    await imprimirPDFs(); // Imprime ambos PDFs
                            //} else {
                            //    await preguntarImpresionPDF(); // Imprime solo el PDF normal
                            //}
                        };
                        objAJAX_Etiq.error = (jqXHR, textStatus, errorThrown) => {
                            console.error(`[ ERROR ] Impresión Etiquetas`);
                            Swal.fire({ icon: "error", text: "Error en la impresión de etiquetas.", title: "Error" });
                        };
                        await objAJAX_Etiq.callback([Mx_Dt023.ID_Atencion, Mx_Dt023.ID_Atencion_VIH]);
                    } else if (!isDismissed) {
                        // Omitir pero continuar con la impresión de PDFs
                        //if (Mx_Dt023.CORELATIVO_VIH && Mx_Dt023.ID_Atencion_VIH) {
                        //    await imprimirPDFs(); // Imprime ambos PDFs
                        //} else {
                        //    await preguntarImpresionPDF(); // Imprime solo el PDF normal
                        //}
                    }
                }

                //// Función para imprimir ambos PDFs
                //async function imprimirPDFs() {
                //    // Imprimir el PDF de atención normal
                //    await preguntarImpresionPDF();
                //    // Esperar a que termine la impresión del primer PDF
                //    await Swal.fire({
                //        icon: "info",
                //        text: "Por favor, guarde el primer PDF y para luego imprimir el PDF VIH.",
                //        title: "Esperando Confirmación",
                //        showConfirmButton: false,  // Ocultar botón de confirmación
                //        /*timer: 3000, // Oculta automáticamente después de 3 segundos*/
                //        allowOutsideClick: false,
                //        allowEscapeKey: false
                //    });
                //    // Imprimir el PDF de atención VIH
                //    await preguntarImpresionPDF_vih();
                //}
                //// Función para preguntar si se desea imprimir el comprobante PDF normal
                //async function preguntarImpresionPDF() {
                //    // Verificar si ya se imprimió para evitar duplicados
                //    if (pdfImpresoNormal) return;
                //    pdfImpresoNormal = true;

                //    const { isConfirmed: printPDF, isDismissed } = await Swal.fire({
                //        icon: "question",
                //        title: "Imprimir Comprobante PDF",
                //        text: "¿Desea imprimir el comprobante PDF de la atención normal?",
                //        showDenyButton: true,
                //        showCancelButton: true,
                //        confirmButtonText: 'Imprimir',
                //        denyButtonText: 'Omitir',
                //        cancelButtonText: 'Cerrar'
                //    });

                //    if (printPDF) {
                //        objAJAX_Atenc_pdf.callback([Mx_Dt023.ID_Atencion]);
                //    }
                //}

                //// Función para preguntar si se desea imprimir el comprobante PDF VIH
                //async function preguntarImpresionPDF_vih() {
                //    // Verificar si ya se imprimió para evitar duplicados
                //    if (pdfImpresoVIH) return;
                //    pdfImpresoVIH = true;

                //    const { isConfirmed: printPDF, isDismissed } = await Swal.fire({
                //        icon: "question",
                //        title: "Imprimir Comprobante PDF",
                //        text: "¿Desea imprimir el comprobante PDF de la atención VIH?",
                //        showDenyButton: true,
                //        showCancelButton: true,
                //        confirmButtonText: 'Imprimir',
                //        denyButtonText: 'Omitir',
                //        cancelButtonText: 'Cerrar'
                //    });

                //    if (printPDF) {
                //        objAJAX_Atenc_pdf.callback([Mx_Dt023.ID_Atencion_VIH]);
                //    }
                //}

                let xVal = 51;

                if ($("#chkMant_0").prop("checked") == false) {
                    const optionExists = $("#Procedencia option[value='51']").length > 0;

                    if (!optionExists) {
                        xVal = 0;
                    } else {
                        xVal = $("#Procedencia option[value='51']").val();
                    }

                    $("#Procedencia").val(parseInt(xVal));
                }
                setTimeout(() => {
                    if ($("#chkMant_4").prop("checked") == false) {
                        xVal = $("#Empresa option").eq(0).val();
                        $("#Empresa").val(
                            parseInt(xVal)
                        );
                    }
                    setTimeout(() => {
                        if ($("#chkMant_3").prop("checked") == false) {
                            xVal = $("#Prevision option").eq(0).val();
                            $("#Prevision").val(
                                parseInt(xVal)
                            );
                        }

                        setTimeout(() => {
                            if ($("#chkMant_1").prop("checked") == false) {
                                fn_Req_Prog();
                                xVal = $("#Programa option").eq(0).val();
                                $("#Programa").val(
                                    parseInt(xVal)
                                );
                            }

                            setTimeout(() => {
                                if ($("#chkMant_2").prop("checked") == false) {
                                    fn_Req_SubP();
                                    xVal = $("#Ddl_Prog02 option").eq(0).val();
                                    $("#Ddl_Prog02").val(
                                        parseInt(xVal)
                                    );
                                }
                            }, 1000);
                        }, 1000);
                    }, 1000);
                }, 1000);

            } else {
                Hide_Modal();


                var str_Error = "Estimano usuario Por favor ingresar exámenes"
                $("#title").text("Ingreso de Atención");
                $("#button_modal").attr("class", "btn btn-danger");

                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();
                $('#XXXXXXXX').removeClass('show');
            }
            guardadoEnProceso = false;
        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);
            guardadoEnProceso = false;



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

var Mx_Dtt_Pack = [
    {
        "ID_PACK": 0,
        "PACK_COD": "",
        "PACK_DESC": "",
        "ID_ESTADO": 0,
        "ID_REL_PACK_CF": 0
    }
];

function Ajax_DataTable_Pack() {
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Llenar_Tabla_Pack",
        //"data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt_Pack = json_receiver;
                Fill_DataTable_Pack();
            }
        },
        "error": function (response) {
            console.log(response);
        }
    });
}


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
        "ID_PREVE": $("#Prevision").val(),
        "Fecha": f
    });

    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Llenar_tabla_exam2",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_Dtt_exam02 = json_receiver;
                Mx_Dtt_exam02_respaldo = json_receiver;
                //if ($("#sex").val() != 0) {
                //    var posicion = 0;
                //    if ($("#sex").val() == 1) {
                //        for ( let x = 0; x < Mx_Dtt_exam02.length; x++) {                              //AQUI SE QUITA O AGREGAN CREATININAS
                //            if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 691) {
                //                posicion = x;
                //            }
                //        }
                //        Mx_Dtt_exam02.splice(posicion, 1);
                //    }
                //    if ($("#sex").val() == 2) {
                //        for (let x = 0; x < Mx_Dtt_exam02.length; x++) {
                //            if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 690) {
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


var Mx_Dtt_exam02_respaldo_global = [
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
function Ajax_DataTable_examen0GObal() {
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Llenar_tabla_exam2_global",
        //"data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt_exam02_respaldo_global = json_receiver;
            } else {
            }
        },
        "error": function (response) {
            console.log(response);
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
        "ID_PREVE": $("#Prevision").val(),
        "Fecha": f,
        "CF": cod_fonasa
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Llenar_tabla_exam",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            console.log(json_receiver);
            if (json_receiver.lenght > 0) {
                Mx_Dtt_exam03 = json_receiver;
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


                Mx_Dtt_exam03.length = 0;
                console.log("digitado")
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
    var f = moment().format("YYYY");


    var Data_Par = JSON.stringify({
        "ID_PREVE": $("#Prevision").val(),
        "Fecha": f,
        "CF": cod_fonasa_2
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Llenar_tabla_exam_pack",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_Dtt_exam03 = json_receiver;
                for (let x = 0; x < Mx_Dtt_exam03.length; x++) {
                    if (Mx_Dtt_exam03[x]["CF_ESTADO_EXAMEN"] == undefined) {
                        Mx_Dtt_exam03[x]["CF_ESTADO_EXAMEN"] = "Activo";
                    }
                }
                //if ($("#sex").val() != 0) {
                //    var posicion = 0;
                //    if ($("#sex").val() == 1) {
                //        for ( let x = 0; x < Mx_Dtt_exam03.length; x++) {
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


                Mx_Dtt_exam03.length = 0;
                success(id_2, cod_2, txis_2);
            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
}



function success_2(xxid_2, xxcod_2, xtxis_2) {
    if (Mx_Dtt_exam03.length == 0) {
        $("input[data-id='" + xxid_2 + "']").val(xxcod_2);
    } else if (Mx_Dtt_exam03.length > 0) {


        var repetido = 0;

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





        $("#DataTable_pac2 tbody").empty();
        for (let i = 0; i < Mx_Dtt_examcof.length; i++) {

            if (Mx_Dtt_examcof[i]["CF_TP_PAGO"] == undefined) {
                Mx_Dtt_examcof[i]["CF_TP_PAGO"] = 18;
            }
            if (Mx_Dtt_examcof[i]["CF_TP_PROGRA"] == undefined || Mx_Dtt_examcof[i]["CF_TP_PROGRA"] == 0) {
                Mx_Dtt_examcof[i]["CF_TP_PROGRA"] = 1;
            }
            $("#DataTable_pac2 tbody").append(
                $("<tr>", {
                    "class": "textoReducido manito",
                    "padding": "1px !important",
                    "data-index": i
                }).append(
                    $("<td>", {
                        "align": "left",
                        "class": "textoReducido negrita"
                    }).html((function () {
                        //Retornar un campo input
                        return $("<input>", {
                            "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                            "data-cod": Mx_Dtt_examcof[i].CF_COD,
                            "class": "td_input negrita",
                            "value": Mx_Dtt_examcof[i].CF_COD
                        })
                    }())),

                    $("<td>", {
                        "align": "left",
                        "class": "textoReducido td_val1 negrita"
                    }).text(Mx_Dtt_examcof[i].CF_DESC),
                    //$("<td>", {
                    //    "align": "center"
                    //}).append(
                    //$("<select>", {
                    //    class: "form-control textoReducido tp_programa",
                    //    "data-id_progama": Mx_Dtt_examcof[i].ID_CODIGO_FONASA

                    //}).append(function () {
                    //    let xxx = [];
                    //    for (let x = 0; x < arrProg_2.length; x++) {
                    //        xxx.push($("<option>", {
                    //            value: arrProg_2[x].ID_PROGRA
                    //        }).text(arrProg_2[x].PROGRA_DESC));
                    //    }
                    //    console.log(xxx);
                    //    return xxx;
                    //}())),

                    //$("<td>", {

                    //    "align": "center"
                    //}).append(
                    //$("<select>", {
                    //    class: "form-control textoReducido tp_pago",
                    //    "id_pago": Mx_Dtt_examcof[i].ID_CODIGO_FONASA

                    //}).append(function () {
                    //    let xxx = [];
                    //    for (let x = 0; x < Mx_Ddl_TP_PAGO.length; x++) {
                    //        xxx.push($("<option>", {
                    //            value: Mx_Ddl_TP_PAGO[x].ID_TP_PAGO
                    //        }).text(Mx_Ddl_TP_PAGO[x].TP_PAGO_DESC));
                    //    }
                    //    console.log(xxx);
                    //    return xxx;
                    //}())),
                    $("<td>", {
                        "align": "center",
                        "class": "textoReducido td_val3 negrita"
                    }).html((function () {
                        return $("<input>", {
                            "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                            "data-cod": "sitio_anato",
                            "class": "td_input negrita",
                            "data-anato": Mx_Dtt_examcof[i].IS_ANATO,
                            "disabled": Mx_Dtt_examcof[i].IS_ANATO == true ? false : true
                        });
                    }())),
                    $("<td>", {
                        "align": "center",
                        "class": "textoReducido td_val2 negrita"
                    }).text(Mx_Dtt_examcof[i].CF_DIAS),
                    //$("<td>", {
                    //    "align": "center",
                    //    "class": "textoReducido td_val5"
                    //}).text(""),
                    //$("<td>", {
                    //    "align": "center"
                    //}).html(function () {
                    //    if (Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN == "Activo") {
                    //        return "<button type='button' class='btn btn-print btn-xs CEstado' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>"
                    //    } else {
                    //        return "<button type='button' class='btn btn-success btn-xs Activado' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Activo</button>"
                    //    }
                    //}()), 
                    //function () {
                    //    if ($("#TipoAtencion").val() == 1) {
                    //        return $("<td>", {
                    //            "align": "center",
                    //            "class": "textoReducido td_val3"
                    //        }).text("$ " + Mx_Dtt_examcof[i].CF_PRECIO_AMB)
                    //    } else {
                    //        return $("<td>", {
                    //            "align": "center",
                    //            "class": "textoReducido td_val3"
                    //        }).text("$ " + Mx_Dtt_examcof[i].CF_PRECIO_HOS)
                    //    }
                    //}(),
                  
                    $("<td>", {
                        "align": "center"
                    }).html("<button type='button' class='btn btn-danger btn-xs borrar negrita' value='Eliminar' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>")
                    //,
                    //                            $("<td>", {
                    //                                "align": "center"
                    //                            }).html(function () {
                    //                                if (Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN == "Activo") {
                    //                                    return "<button type='button' class='btn btn-print btn-xs CEstado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>"
                    //                                } else {
                    //                                    return "<button type='button' class='btn btn-success btn-xs Activado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Activo</button>"
                    //                                }


                    //                            }())
                )


            )
            //precio = parseInt(precio) + parseInt(Mx_Dtt_examcof[i].CF_PRECIO_AMB);
            //cantida_exa++;

            //let xindex = $(`#DataTable_pac2 tbody tr[data-index =${i}] select`).val(Mx_Dtt_examcof[i].CF_TP_PAGO)

            //let xindex = $(`#DataTable_pac2 tbody tr[data-index =${i}] select`).val(Mx_Dtt_examcof[i].CF_TP_PROGRA)
            //if (Mx_Dtt_examcof[i].CF_TP_PROGRA == 32) {
            //    let xindex2 = $(`#DataTable_pac2 tbody tr[data-index =${i}] select`).attr('disabled', true)
            //}

            //console.log(xindex);
        }
        //console.log(cantida_exa)
        //$("#precio_").text("$" + precio);
        //$("#Cantida_").text(cantida_exa);
        add_row();
    } else {
        $("input[data-id='" + xxid + "']").val(xxcod);
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
        "url": "Ingreso_Ate.aspx/Llenar_Ddl_LugarTM",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_Ddl = json_receiver;
                Fill_AJAX_Ddl();


                fn_Req_Prev();


            } else {



            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            alert("Error", str_Error);


        }
    });
}
var Mx_Dtt2 = [
    {
        "ID_PACIENTE": 0,
        "PAC_RUT": 0,
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
        "PREI_OBS_TM": 0,
        "PAC_DIR": 0,
        "ID_DIAGNOSTICO ": 0,
        "ID_ESTADO": 0,
        "ID_CIUDAD": 0,
        "PAC_OBS_PERMA": 0,
        "ID_COMUNA": 0,
        "ID_ETNIA": 0,
        "PAC_NOM_SOCIAL": 0
    }
];
Mx_Dtt2.length = 0;
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
        "url": "Ingreso_Ate.aspx/Llenar_rut",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver.length > 0) {
                Mx_Dtt2 = json_receiver;
                console.log("ver ver", Mx_Dtt2)
                console.log("Si Existe Rut");

                Ajax_modal_exa_RUT();



                //Fill_DL_Rut();
                //$('#txtrut').val($("#rut").val());
                //Hide_Modal();
                verrut = 1;





            } else {

                console.log("No Existe Rut");

                $('#txtrut').val($("#rut").val());
                //Ajax_DL_SEXO();
                $("#sex").val(0);
                //Ajax_DL_NAC();
                //Ajax_Ciudad();
                $("#checkBox2").prop('checked', false);
                $('#FUR').attr("disabled", true);
                $('#checkBox2').attr("disabled", true);
                $("#fur").css("pointer-events", "none");
                var f = moment().format("DD-MM-YYYY");
                $("#fecha").val(f);
                $("#fecha2").val(f);
                $("#FUR").val(f);
                $('#rut').removeAttr("disabled");

                $("#Nacio").val(1);
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
                //Mx_Dtt_examcof.length = 0;
                //$("#DataTable_pac2 tbody").empty();
                Hide_Modal();
                verrut = 2;

                // IF MX_EXAMED 

                if ($("#examed").val() != "" && Mx_Examed.length > 0) {
                    console.log("ESTOY DENTRO DE LO QUE CARGA LOS DATOS DE RUT")
                    $('#txtrut').val($("#rut").val());
                    $("#Nom").val(Mx_Examed[0].NOM_PAC_EXA);
                    $("#Ape").val(Mx_Examed[0].APE_PAC_EXA);
                    $("#Celular").val(Mx_Examed[0].FONO_PAC_EXA);
                    $("#Email").val(Mx_Examed[0].EMAIL_PAC_EXA);
                    $("#direccion").val(Mx_Examed[0].DIR_PAC_EXA);
                    let fnac_exa = moment(Mx_Examed[0].FNAC_PAC_EXA).format("YYYY-MM-DD")
                    $("#fecha").val(fnac_exa);
                    $("#ddlEtnia").val(Mx_Dtt2[0].ID_ETNIA || 1);
                    $("#txtNombreSocial").val(Mx_Dtt2[0].PAC_NOM_SOCIAL);

                    $("#obdser").val(Mx_Dtt2[0].PAC_OBS_PERMA);
                    $("#obs_ate").val(Mx_Dtt2[0].PREI_OBS_TM);


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
                            let ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                            dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                            total = String(edad + " Años");
                        }
                        return total
                    });
                    $("#sex").val(Mx_Examed[0].SEXO_PAC_EXA);
                    $("#Nacio").val(1);


                }

            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



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
function Ajax_modal_exa_RUT() {
    modal_show();
    Mx_Detalle_ate = 0;
    var Data_Par_modal = JSON.stringify({
        "ID": $("#rut").val()
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/MODAL_PAC_RUT",
        "data": Data_Par_modal,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": Data_Par_modal_paciente => {
            //Debug
            //console.log(Data_Par_modal_paciente);
            Mx_Detalle_ate = Data_Par_modal_paciente.d;
            console.log(Mx_Detalle_ate);
            //ENVIAMOS ID_ATEMCION AL MODAL
            //LLAMAMOS AL FILL MODAL
            //var obj_RUT2 = Valid_RUT(Mx_Dtt2[0].RUT_PACIENTE);
            console.log("pok");
            if (Mx_Detalle_ate.proparra1.length == 0) {
                Fill_DL_Rut();
                $('#txtrut').val($("#rut").val());
                Hide_Modal();
                //verrut = 1;
            } else {
                if (Mx_Detalle_ate.proparra1[0].PAC_RUT == Mx_Dtt2[0].PAC_RUT) {
                    console.log("la otra pagina 2");
                    var loc = location.origin;
                    Hide_Modal();
                    Swal.fire({
                        title: 'Atención',
                        text: "Este paciente ya tiene una atención hoy, ¿desea ingresar otra atención o editar la existente?",
                        icon: 'warning',
                        showDenyButton: true,
                        showCancelButton: true,
                        confirmButtonText: 'Ingresar Nueva',
                        denyButtonText: `Editar Existente`,
                        cancelButtonText: 'Cancelar'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            // Lógica para ingresar una nueva atención
                            Fill_DL_Rut();
                            $('#txtrut').val($("#rut").val());
                            Hide_Modal();
                            //verrut = 1;
                        } else if (result.isDenied) {
                            // Lógica para editar la existente
                            var loc = location.origin;
                            window.location.replace(loc + "/Agenda_Med/AGRE_EXA_ATE_NORMAL.aspx" + "?Rt" + "=" + Mx_Dtt2[0].PAC_RUT + "&Di=" + "NONE");

                        } else {
                            //$("#rut").val("");
                            $("#dni").val("");
                            $("#Naten").val("");
                        }
                    });
                } else {


                    Fill_DL_Rut();
                    $('#txtrut').val($("#rut").val());
                    Hide_Modal();
                    //verrut = 1;
                }
            }


            if ($("#examed").val() != "" && Mx_Examed.length > 0) {
                Actualiza_Datos_Examed_RUT();
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
        "PREI_OBS_TM": 0,
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
        "url": "Ingreso_Ate.aspx/Llenar_dni",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            //console.log(response);
            var json_receiver = response.d;
            if (json_receiver.length > 0) {
                Mx_Dtt2_dni = json_receiver;
                Ajax_modal_exa_DNI();
                console.log("existe dni");
                verrut = 1;
            } else {
                console.log("no existe dni");
                //Ajax_DL_SEXO();
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
                $('#txtrut').val($("#dni").val());

                $("#Nom").val("");
                $("#Interno").val("");
                $("#Ape").val("");
                $("#Edad").val("");
                $("#telfijo").val("");
                $("#Celular").val("");
                $("#Email").val("");
                $("#direccion").val("");
                Mx_Dtt_examcof.length = 0;
                //$("#DataTable_pac2 tbody").empty();
                Hide_Modal();
                verrut = 2;

                if ($("#examed").val() != "" && Mx_Examed.length > 0) {

                    $("#Nom").val(Mx_Examed[0].NOM_PAC_EXA);
                    $("#Ape").val(Mx_Examed[0].APE_PAC_EXA);
                    $("#Celular").val(Mx_Examed[0].FONO_PAC_EXA);
                    $("#Email").val(Mx_Examed[0].EMAIL_PAC_EXA);
                    $("#direccion").val(Mx_Examed[0].DIR_PAC_EXA);
                    let fnac_exa = moment(Mx_Examed[0].FNAC_PAC_EXA).format("YYYY-MM-DD")
                    $("#fecha").val(fnac_exa);
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
                            let ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                            dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                            total = String(edad + " Años");
                        }
                        return total
                    });
                    $("#sex").val(Mx_Examed[0].SEXO_PAC_EXA);
                }


            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);
        }
    });
}
function Ajax_modal_exa_DNI() {
    modal_show();
    Mx_Detalle_ate = 0;
    console.log("DNI");
    var Data_Par_modal = JSON.stringify({
        "ID": $("#dni").val()
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/MODAL_PAC_DNI",
        "data": Data_Par_modal,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": Data_Par_modal_paciente => {
            //Debug
            //console.log(Data_Par_modal_paciente);
            Mx_Detalle_ate = Data_Par_modal_paciente.d;


            if (Mx_Detalle_ate.proparra1.length == 0) {
                $('#dni').attr("disabled", true);
                $('#txtrut').val($("#dni").val());
                $("#Nom").val(Mx_Dtt2_dni[0].PAC_NOMBRE);
                $("#Ape").val(Mx_Dtt2_dni[0].PAC_APELLIDO);
                $("#txtNombreSocial").val(Mx_Dtt2_dni[0].PAC_NOM_SOCIAL);
                console.log(`Genero: ${Mx_Dtt2_dni[0].PAC_NOM_SOCIAL}`)
                $("#Genero").val(Mx_Dtt2_dni[0].ID_GENERO);
                $("#obdser").val(Mx_Dtt2_dni[0].PAC_OBS_PERMA);
                $("#fecha").val(moment(Mx_Dtt2_dni[0].PAC_FNAC).format("YYYY-MM-DD"));
                console.log(Mx_Dtt2_dni[0].PAC_FNAC);

                const comunaElement = document.getElementById("Comuna");

                const comunaExisteEnSelect = Array.from(comunaElement.options).some(item => item.value == Mx_Dtt2_dni[0].ID_REL_CIU_COM);
                if (comunaExisteEnSelect) {
                    comunaElement.value = Mx_Dtt2_dni[0].ID_REL_CIU_COM
                } else {
                    comunaElement.selectedIndex = 0
                }

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
                        let ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
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
                //verrut = 1;
            } else {
                //if (Mx_Detalle_ate.proparra1[0].DNI == Mx_Dtt2_dni[0].DNI) {
                //    console.log("la otra pagina 2");
                //    var loc = location.origin;
                //    window.location.replace(loc + "/Agenda_Med/AGRE_EXA_ATE_2.aspx" + "?Rt" + "=" + "NONE" + "&Di=" + Mx_AVIS[0].DNI);
                //} else {
                $('#dni').attr("disabled", true);
                $("#Nom").val(Mx_Dtt2_dni[0].PAC_NOMBRE);
                $("#Ape").val(Mx_Dtt2_dni[0].PAC_APELLIDO);
                $("#txtNombreSocial").val(Mx_Dtt2_dni[0].PAC_NOM_SOCIAL);
                $("#Genero").val(Mx_Dtt2_dni[0].ID_GENERO);
                $("#obdser").val(Mx_Dtt2_dni[0].PAC_OBS_PERMA);
                const comunaElement = document.getElementById("Comuna");

                const comunaExisteEnSelect = Array.from(comunaElement.options).some(item => item.value == Mx_Dtt2_dni[0].ID_REL_CIU_COM);
                if (comunaExisteEnSelect) {
                    comunaElement.value = Mx_Dtt2_dni[0].ID_REL_CIU_COM
                } else {
                    comunaElement.selectedIndex = 0
                }
                $("#fecha").val(moment(Mx_Dtt2_dni[0].PAC_FNAC).format("YYYY-MM-DD"));
                console.log(Mx_Dtt2_dni[0].PAC_FNAC);
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
                        let ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
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
                //verrut = 1;
                //}
            }


            //// MOSTRAR EL MODAL
            //$('#eModales33').modal('show');

            // IF MX_EXAMED 

            if ($("#examed").val() != "" && Mx_Examed.length > 0) {
                Actualiza_Datos_Examed_DNI();
            }

        },
        "error": Data_Par_modal_paciente => {
            Hide_Modal();
            console.log(Data_Par_modal_paciente);

        }
    });
}

function Actualiza_Datos_Examed_DNI() {

    // NUEVOS

    $("#NDE_RUT").text(Mx_Examed[0].RUT_PAC_EXA);
    $("#NDE_NOM").text(Mx_Examed[0].NOM_PAC_EXA);
    $("#NDE_APE").text(Mx_Examed[0].APE_PAC_EXA);
    $("#NDE_FNAC").text(moment(Mx_Examed[0].FNAC_PAC_EXA).format("DD-MM-YYYY"));

    let sex_N;

    if (Mx_Examed[0].SEXO_PAC_EXA == 1) {
        sex_N = "Masculino";
    } else {
        sex_N = "Femenino";
    }

    $("#NDE_SEX").text(sex_N);
    $("#NDE_DIR").text(Mx_Examed[0].DIR_PAC_EXA);
    $("#NDE_FONO").text(Mx_Examed[0].FONO_PAC_EXA);
    $("#NDE_CORR").text(Mx_Examed[0].EMAIL_PAC_EXA);


    // ACTUALES

    $("#ADE_RUT").text(Mx_Dtt2_dni[0].PAC_RUT);
    $("#ADE_NOM").text(Mx_Dtt2_dni[0].PAC_NOMBRE);
    $("#ADE_APE").text(Mx_Dtt2_dni[0].PAC_APELLIDO);
    $("#ADE_FNAC").text(moment(Mx_Dtt2_dni[0].PAC_FNAC).format("DD-MM-YYYY"));

    let sex_A;

    if (Mx_Dtt2_dni[0].ID_SEXO == 1) {
        sex_A = "Masculino";
    } else {
        sex_A = "Femenino";
    }

    $("#ADE_SEX").text(sex_A);
    $("#ADE_DIR").text(Mx_Dtt2_dni[0].PAC_DIR);
    $("#ADE_FONO").text(Mx_Dtt2_dni[0].PAC_MOVIL1);
    $("#ADE_CORR").text(Mx_Dtt2_dni[0].PAC_EMAIL);

    //$("#mdl_Actu_Exa").modal("show");
}

function Actualiza_Datos_Examed_RUT() {

    // NUEVOS

    $("#NDE_RUT").text(Mx_Examed[0].RUT_PAC_EXA);
    $("#NDE_NOM").text(Mx_Examed[0].NOM_PAC_EXA);
    $("#NDE_APE").text(Mx_Examed[0].APE_PAC_EXA);
    $("#NDE_FNAC").text(moment(Mx_Examed[0].FNAC_PAC_EXA).format("DD-MM-YYYY"));

    let sex_N;

    if (Mx_Examed[0].SEXO_PAC_EXA == 1) {
        sex_N = "Masculino";
    } else {
        sex_N = "Femenino";
    }

    $("#NDE_SEX").text(sex_N);
    $("#NDE_DIR").text(Mx_Examed[0].DIR_PAC_EXA);
    $("#NDE_FONO").text(Mx_Examed[0].FONO_PAC_EXA);
    $("#NDE_CORR").text(Mx_Examed[0].EMAIL_PAC_EXA);


    // ACTUALES

    $("#ADE_RUT").text(Mx_Dtt2[0].PAC_RUT);
    $("#ADE_NOM").text(Mx_Dtt2[0].PAC_NOMBRE);
    $("#ADE_APE").text(Mx_Dtt2[0].PAC_APELLIDO);
    $("#ADE_FNAC").text(moment(Mx_Dtt2[0].PAC_FNAC).format("DD-MM-YYYY"));

    let sex_A;

    if (Mx_Dtt2[0].ID_SEXO == 1) {
        sex_A = "Masculino";
    } else {
        sex_A = "Femenino";
    }

    $("#ADE_SEX").text(sex_A);
    $("#ADE_DIR").text(Mx_Dtt2[0].PAC_DIR);
    $("#ADE_FONO").text(Mx_Dtt2[0].PAC_MOVIL1);
    $("#ADE_CORR").text(Mx_Dtt2[0].PAC_EMAIL);

    //$("#mdl_Actu_Exa").modal("show");
}

var Mx_DL_GENERO = [
    {
        "ID_GENERO": 0,
        "GENERO_DESC": "",
        "ID_ESTADO": 0
    }
];

function Ajax_DL_GENERO() {
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Llenar_DL_GENERO",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_GENERO = JSON.parse(json_receiver);
                Fill_DL_GENERO();


            } else {

            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            cModal_Error("Error", str_Error);

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
function Ajax_DL_NAC() {



    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Llenar_DL_NAC",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_DL_NAC = json_receiver;
                Fill_DL_NAC();
                $("#Nacio").val(1);



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
        "url": "Ingreso_Ate.aspx/IRIS_WEBF_BUSCA_CIUDAD",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_Ciudad = json_receiver;
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
        "url": "Ingreso_Ate.aspx/IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            console.log(response.d);
            if (json_receiver != null) {
                Mx_Comuna = json_receiver;
                console.log("Mx_Comuna", Mx_Comuna.ID_REL_CIU_COM)
                console.log("Mx_Comuna", Mx_Comuna)
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
        "ID_ESTADO": 0
    }
];
function Ajax_DL_prevision() {



    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Llenar_DL_prevision",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_DL_prevision = json_receiver;
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
        "url": "Ingreso_Ate.aspx/Llenar_DL_aTENCIONES",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_DL_TP_ATE = json_receiver;
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
var Mx_DL_Empresa = [
    {
        "ID_EMPRESA": 0,
        "EMPRESA_COD": "asdf",
        "EMPRESA_DESC": "asdf",
        "ID_ESTADO": 0
    }
];
function Ajax_DL_Empresa() {



    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Llenar_DL_Empresa",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_DL_Empresa = json_receiver;
                Fill_DL_Empresa();




            } else {



            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            cModal_Error("Error", str_Error);


        }
    });
}
function Ajax_DL_sec() {



    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Llenar_DL_Sectores",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_DL_Sec = json_receiver;
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
        "url": "Ingreso_Ate.aspx/Llenar_DL_Programa",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_DL_Programa = json_receiver;
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
        "url": "Ingreso_Ate.aspx/Llenar_DL_DOC",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_DL_DOC = json_receiver;
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
        "url": "Ingreso_Ate.aspx/Llenar_DL_ordenATE",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_DL_orden_ate = json_receiver;
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


let objAJAX_Prev = 0;

var arrPrev = [{
    "ID_PREVE": 0,
    "PREVE_COD": "",
    "PREVE_DESC": "",
    "ID_ESTADO": 0
}];

function fn_Req_Prev() {
    var objParam = JSON.stringify({
        "ID_PROC": $("#Procedencia").val()
    });

    objAJAX_Prev = $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Request_Prevision",
        "data": objParam,
        "contentType": "application/json; charset=utf-8",
        "dataType": "json",
        "success": (resp) => {
            arrPrev = resp.d;

            // Llenar Ddl
            $("#Prevision").empty();

            arrPrev.forEach((Item) => {
                $("#Prevision").append(
                    $("<option>", {
                        "value": Item.ID_PREVE
                    }).text(Item.PREVE_DESC)
                );
            });

            // Establecer la opción por defecto si existe
            var defaultValue = "318"; // Valor por defecto deseado
            if ($("#Prevision option[value='" + defaultValue + "']").length > 0) {
                $("#Prevision").val(defaultValue);
            } else {
                // Si no existe la opción por defecto, selecciona la primera opción
                $("#Prevision").prop('selectedIndex', 0);
            }

            // Actualizar Exámenes
            Mx_Dtt_exam02.length = 0;
            Ajax_DataTable_examen02();
            $("#DataTable_pac2 tbody").empty();
            add_row();

            fn_Req_Prog();
        },
        "error": (fail) => {
            $("mdlError").modal();

            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
            $('#XXXXXXXX').removeClass('show');
        }
    });
};

let objAJAX_Prog = 0;

var arrProg = [{
    "ID_PROGRA": 0,
    "ID_PREVE": 0,
    "PROGRA_DESC": "",
}];

function fn_Req_Prog() {
    var objParam = JSON.stringify({
        "ID_PREV": $("#Prevision").val()
    });

    objAJAX_Prog = $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Request_Programa",
        "data": objParam,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": (resp) => {
            arrProg = resp.d;

            //Llenar Ddl
            $("#Programa").empty();
            //$("#Programa").append(
            //    $("<option>", {
            //        "value": 0
            //    }).text("<< TODOS >>")
            //);
            arrProg.forEach((Item) => {
                $("#Programa").append(
                    $("<option>", {
                        "value": Item.ID_PROGRA
                    }).text(Item.PROGRA_DESC)
                );
            });

            fn_Req_SubP();
        },
        "error": (fail) => {
            $("mdlError").modal();

            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
    });
};


let objAJAX_SubP = 0;

var arrSubP = [{
    "SubP_ID": 0,
    "SubP_Cod": "",
    "SubP_Desc": ""
}];

function fn_Req_SubP() {
    var objParam = JSON.stringify({
        "ID_PREV": $("#Prevision").val(),
        "ID_PROG": $("#Programa").val()
    });

    objAJAX_SubP = $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Request_SubPrograma",
        "data": objParam,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": (resp) => {
            arrSubP = resp.d;

            //Llenar Ddl
            $("#Ddl_Prog02").empty();
            if (arrSubP.length > 0) {
                arrSubP.forEach((Item) => {
                    $("#Ddl_Prog02").append(
                        $("<option>", {
                            "value": Item.SubP_ID
                        }).text(Item.SubP_Desc)
                    );
                });
            } else {
                $("#Ddl_Prog02").append(
                    $("<option>", {
                        "value": 1
                    }).text("<Sin SubPrograma>")
                );
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

let objAJAX_Ciud = 0;
var arrCiud = [{
    "text": "",
    "value": 0
}];
function fn_Req_Ciud() {
    console.log("??????")
    objAJAX_Ciud = $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/Data_Sel_Ciudad",
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": (resp) => {
            arrCiud = resp.d;
            console.log("CIUDAD: ", arrCiud)
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
        //"url": "Ingreso_Ate.aspx/Data_Sel_Comuna",
        "url": "Ingreso_Ate.aspx/Data_Sel_Comuna_id_ciu",
        "data": objParam,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": (resp) => {
            arrComuna = resp.d;
            console.log(arrComuna);
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

                    $("#Comuna").val(5);
                //if (ID_COM != null) {
                //    $("#Comuna").val(ID_COM);
                //}

                //if (initializing == true) {
                //    fn_Req_User_Location();
                //    initializing = false;
                //}
                //$("#Comuna").val("12")
                //$("#Comuna").trigger("change");
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
        "success": (resp) => {
            objLocation = resp.d;
            if ((objLocation.ID_CIUDAD != 0) && (objLocation.ID_COMUNA != 0)) {
                $("#Cuidad").val(objLocation.ID_CIUDAD);
                fn_Req_Comuna(objLocation.ID_COMUNA);
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
    // Inicializar Select2
    //$("#Doctor").select2({
    //    placeholder: "Seleccionar",
    //    allowClear: true,
    //    width: 'resolve'  // esto ajusta el ancho del select2 al contenedor padre
    //});
    //$("#Doctor").val(1463);
}
function


    Fill_DL_programa() {
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
function Fill_DL_Empresa() {
    $("#Empresa").empty();
    for (let y = 0; y < Mx_DL_Empresa.length; ++y) {
        $("<option>", {
            "value": Mx_DL_Empresa[y].ID_EMPRESA
        }).text(Mx_DL_Empresa[y].EMPRESA_DESC).appendTo("#Empresa");
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
    Ajax_DataTable_examen02();

}

function Fill_DL_Rut() {

    console.log(Mx_Dtt2);

    //let FechaREE = moment(Mx_Dtt2[0].PAC_FNAC).format("YYYY-MM-DD");

    let rawDate = Mx_Dtt2[0].PAC_FNAC; // El valor con formato de fecha en JSON
    console.log(rawDate)
    let timestamp = parseInt(rawDate.match(/\d+/)[0]); // Extrae el timestamp numérico
    let formattedDate = moment.utc(timestamp).format("YYYY-MM-DDTHH:mm"); // Formato para datetime-local

    let fechaActual = moment.utc();

    let diferencia = fechaActual.diff(moment.utc(timestamp), 'months');

    let campoFecha = $("#fecha");

    if (diferencia < 1) {
        campoFecha.attr("type", "datetime-local");
        campoFecha.val(formattedDate); // Asignar la fecha y hora


        $("#chk_neo").prop("checked", true);
    } else {
        $("#chk_neo").prop("checked", false);
        // Si la diferencia es mayor o igual a un mes, verificar la hora y minutos
        let horaMinutos = moment.utc(timestamp).format("HH:mm");
        if (Mx_Dtt2[0].IS_NEO == 1) {
            // Si la hora y minutos no son 00:00, cambiar el tipo a datetime-local
            campoFecha.attr("type", "datetime-local");
            campoFecha.val(formattedDate); // Asignar la fecha y hora
        } else {
            // Si la hora y minutos son 00:00, dejar el tipo como date
            campoFecha.attr("type", "date");
           
            campoFecha.val(moment.utc(timestamp).format("YYYY-MM-DD")); // Asignar solo la fecha
        }
    }

    $('#rut').attr("disabled", true);
    $("#Nom").val(Mx_Dtt2[0].PAC_NOMBRE);
    $("#Ape").val(Mx_Dtt2[0].PAC_APELLIDO);
    //$("#fecha").val(formattedDate);

    $("#ddlEtnia").val(Mx_Dtt2[0].ID_ETNIA || 1);
 
    $("#obdser").val(Mx_Dtt2[0].PAC_OBS_PERMA);

    //$("#txtNombreSocial").val(Mx_Detalle_ate.proparra1[0].PAC_NOM_SOCIAL);
    $("#txtNombreSocial").val(Mx_Dtt2[0].PAC_NOM_SOCIAL);
    //$("#obs_ate").val(Mx_Detalle_ate[0].PREI_OBS_TM);


    console.log("JSON: ", JSON.stringify({ "DATA": Mx_Dtt2[0] }))

    const comunaElement = document.getElementById("Comuna");

    const comunaExisteEnSelect = Array.from(comunaElement.options).some(item => item.value == Mx_Dtt2[0].ID_REL_CIU_COM);
    if (comunaExisteEnSelect) {
        comunaElement.value =  Mx_Dtt2[0].ID_REL_CIU_COM
    } else {
        comunaElement.selectedIndex = 0
    }

    console.log($("#obs_ate").val())
    console.log($("#obdser").val())
    console.log($("#ddlEtnia").val())
    console.log($("#txtNombreSocial").val())

    $("#Edad").val(function () {


        // Obtener el valor del input y convertirlo a formato "YYYY-MM-DD"
        let valorFecha = $("#fecha").val(); // Ejemplo: "2024-11-22T10:59"

        console.log(`Valor fecha: ${valorFecha}`);

        if (valorFecha == '') {
            $("#Edad").val('');
        } else {


            let fechaSinHora = valorFecha.split("T")[0]; // Extraer solo la fecha (Ejemplo: "2024-11-22")

            // Formatear la fecha usando Moment.js
            let asd = moment(fechaSinHora).format("DD-MM-YYYY");

            // Separar la fecha en día, mes y año
            let array = asd.split("-");
            let dia = parseInt(array[0], 10);
            let mes = parseInt(array[1], 10);
            let ano = parseInt(array[2], 10);

            // Asegurarnos de que día y mes tengan dos dígitos
            if (dia < 10) { dia = "0" + dia; }
            if (mes < 10) { mes = "0" + mes; }

            // Obtener la fecha actual
            let fechaHoy = new Date();
            let ahoraAno = fechaHoy.getFullYear();
            let ahoraMes = fechaHoy.getMonth() + 1; // Los meses en JS son de 0 a 11
            let ahoraDia = fechaHoy.getDate();

            // Calcular la edad en años
            let edad = ahoraAno - ano;
            if (ahoraMes < mes || (ahoraMes === mes && ahoraDia < dia)) {
                edad--; // Ajustar si el mes o día actual aún no ha llegado
            }

            // Calcular meses
            let meses = 0;
            if (ahoraMes >= mes) {
                meses = ahoraMes - mes;
            } else {
                meses = 12 - (mes - ahoraMes);
            }
            if (ahoraMes === mes && ahoraDia < dia) {
                meses = 11; // Ajuste si el día actual aún no ha llegado
            }

            // Calcular días
            let dias = 0;
            if (ahoraDia >= dia) {
                dias = ahoraDia - dia;
            } else {
                // Calcular los días restantes en el mes anterior
                let ultimoDiaMes = new Date(ahoraAno, ahoraMes - 1, 0).getDate();
                dias = ultimoDiaMes - dia + ahoraDia;
            }

            // Generar el texto de edad
           return `${edad} Años ${meses} meses ${dias} días`;
            

        }
    });

    //$("#Edad").val(function () {
    //    var asd = moment($("#fecha").val()).format("DD-MM-YYYY");
    //    var array = asd.split("-");
    //    var total = "";
    //    var dia = array[0];
    //    var mes = array[1];
    //    var ano = array[2];
    //    if (dia < 10) { dia = "0" + dia; }
    //    if (mes < 10) { mes = "0" + mes; }
    //    // cogemos los valores actuales
    //    var fecha_hoy = new Date();
    //    var ahora_ano = fecha_hoy.getYear();
    //    var ahora_mes = fecha_hoy.getMonth() + 1;
    //    var ahora_dia = fecha_hoy.getDate();

    //    // realizamos el calculo
    //    var edad = (ahora_ano + 1900) - ano;
    //    if (ahora_mes < mes) {
    //        edad--;
    //    }
    //    if ((mes == ahora_mes) && (ahora_dia < dia)) {
    //        edad--;
    //    }
    //    if (edad > 1900) {
    //        edad -= 1900;
    //    }
    //    // calculamos los meses
    //    var meses = 0;
    //    if (ahora_mes > mes)
    //        meses = ahora_mes - mes;
    //    if (ahora_mes < mes)
    //        meses = 12 - (mes - ahora_mes);
    //    if (ahora_mes == mes && dia > ahora_dia)
    //        meses = 11;
    //    // calculamos los dias
    //    var dias = 0;
    //    total = String(edad + " Años");
    //    if (ahora_dia > dia) {
    //        dias = ahora_dia - dia;
    //        total = String(edad + " Años");
    //    }
    //    if (ahora_dia < dia) {
    //        let ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
    //        dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
    //        total = String(edad + " Años");
    //    }
    //    return total
    //});
    $("#sex").val(Mx_Dtt2[0].ID_SEXO);//
    if (Mx_Dtt2[0].ID_SEXO == 2) {
        $('#checkBox2').removeAttr("disabled");
    }
    $("#Genero").val(Mx_Dtt2[0].ID_GENERO)
    $("#Nacio").val(Mx_Dtt2[0].ID_NACIONALIDAD);
    $("#telfijo").val(Mx_Dtt2[0].PAC_FONO1);
    $("#Celular").val(Mx_Dtt2[0].PAC_MOVIL1);
    Ajax_DataTable_examen02();
    $("#direccion").val(Mx_Dtt2[0].PAC_DIR);
    $("#Email").val(Mx_Dtt2[0].PAC_EMAIL);



};

function Fill_AJAX_Ddl() {
    $("#Procedencia").empty();

    var procee = Galletas.getGalleta("USU_ID_PROC");
    var defaultValue = "51"; // Valor por defecto deseado

    if (procee == 0) {
        Mx_Ddl.forEach(aaa => {
            $("<option>", {
                "value": aaa.ID_PROCEDENCIA
            }).text(aaa.PROC_DESC).appendTo("#Procedencia");
        });
    } else {
        Mx_Ddl.forEach(aaa => {
            if (aaa.ID_PROCEDENCIA == procee) {
                $("<option>", {
                    "value": aaa.ID_PROCEDENCIA
                }).text(aaa.PROC_DESC).appendTo("#Procedencia");
            }
        });
    }

    // Establecer la opción por defecto si existe
    if ($("#Procedencia option[value='" + defaultValue + "']").length > 0) {
        $("#Procedencia").val(defaultValue);
    }

    //Ajax_DataTable();
}

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
    console.log("222")
    $("#Comuna").empty();
    for (let y = 0; y < Mx_Comuna.length; ++y) {
        $("<option>", {
            "value": Mx_Comuna[y].ID_REL_CIU_COM
        }).text(Mx_Comuna[y].COM_DESC).appendTo("#Comuna");
    }

    //$("#Comuna").val(5)
};
//-------------------------------------------------------------------------------------------------------/
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
var selected_glu = new Array();
//determinaciones glucosa
function Ajax_DataTable_examen3_Glucosa(cod_fonasa, id, cod, txis) {
    var f = moment().format("DD-MM-YYYY");

    var Data_Par = JSON.stringify({
        "ID_PREVE": $("#Prevision").val(),
        "Fecha": f,
        "CF": cod_fonasa
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_BONIFICACION_GLUCOSA",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt_exam03 = JSON.parse(json_receiver);

                success(id, cod, txis);
                Ajax_DataTable_Busca_pruebas_Glucosa(Mx_Dtt_exam03[0].ID_PER);

            } else {

                Mx_Dtt_exam03.length = 0;
            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);
        }
    });
}


var Mx_Dtt_Determinaciones = [
    {
        "ID_PRUEBA": 0,
        "PRU_COD": 0,
        "PRU_DESC": 0,
        "ID_PER": 0
    }
];
function Ajax_DataTable_Busca_pruebas_Glucosa(id_per) {

    var Data_Par = JSON.stringify({
        "ID_PERFIL": id_per
    });

    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/IRIS_WEBF_CMVM_BUSCA_DETERMINACIONES_GLUCOSA",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt_Determinaciones = JSON.parse(json_receiver);

                $("#mdl_Determinaciones_Glucosa").hide();
                $("#Div_TablaDeterminaciones").empty();
                Fill_Determinaciones();

            } else {

                Mx_Dtt_Determinaciones.length = 0;
            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);
        }
    });
}

function Fill_Determinaciones() {
    $("#Div_TablaDeterminaciones").empty();
    $("<table>", {
        "id": "DataTable_Determinaciones",
        "class": "table table-hover table-striped table-iris table-iris",
        "width": "100%",
        "cellspacing": "0"
    }).appendTo("#Div_TablaDeterminaciones");

    $("#DataTable_Determinaciones").append(
        $("<thead>"),
        $("<tbody>")
    );
    $("#DataTable_Determinaciones").attr("class", "table table-hover table-striped table-iris table-striped table-iris");

    $("#DataTable_Determinaciones thead").append(
        $("<tr>").append(

            $("<th>", { "class": "textoReducido text-center" }).text("#"),
            $("<th>", { "class": "textoReducido text-left" }).text("Código"),
            $("<th>", { "class": "textoReducido text-center" }).text("Descripción"),
            $("<th>", { "class": "textoReducido text-center" }).text("Agregar")
        )
    );

    for (let i = 0; i < Mx_Dtt_Determinaciones.length; i++) {
        $("#DataTable_Determinaciones tbody").append(
            $("<tr>", {
                "padding": "1px !important",
            }).append(
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido"
                }).text(i + 1),
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido"
                }).text(Mx_Dtt_Determinaciones[i].PRU_COD),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido"
                }).text(Mx_Dtt_Determinaciones[i].PRU_DESC),
                $("<td>").css("text-align", "center").text(function () {
                    $(this).html("<div class='checkbox checkbox-success pz gluco' style='margin-top:-7px;'><input type='checkbox' value='" + Mx_Dtt_Determinaciones[i].ID_PRUEBA + "' class='manitos2' id='Hasdasd" + i + "'/><label class='manitos2' for='Hasdasd" + i + "'></label></div>")
                })

            )
        )


    }
    $("#Lbl_cantidad_glucosa").val(1);
    $("#mdl_Determinaciones_Glucosa").modal("show");
}

$("#button_carga_determinaciones").click(() => {
    let glu_new = 0;
    selected_glu = new Array();
    console.log("selected_glu", selected_glu)
    $(".gluco input:checkbox:checked").each(function () {
        selected_glu.push($(this).val());
    });

    for (let glu = 0; glu < Mx_Dtt_examcof.length; glu++) {
        if (Mx_Dtt_examcof[glu].ID_CODIGO_FONASA == 743 && $("#Lbl_cantidad_glucosa").val() != "") {
            Mx_Dtt_examcof[glu].CF_IMED_CANTIDAD = parseInt($("#Lbl_cantidad_glucosa").val());

            glu_new = 1;
            console.log("dentro del for", glu_new)
        }
    }

    if (glu_new == 1) {
        fill_llenado_tabla();
        console.log("dentro del if", glu_new)
    }

    if (selected_glu.length == 0) {
        alert("Debe agregar al menos una determinación.");
    } else {
        $("#mdl_Determinaciones_Glucosa").modal("hide");
        $("#mdl_Determinaciones_Glucosa").hide();
    }

});

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//var Mx_Dtt_4556 = [
// {
//     "ID_PROCEDENCIA": 0,
//     "PROC_DESC": 0,
//     "PROC_CANT_EXA": 0,
//     "ID_ESTADO ": 0,
//     "PRO_TIPO_I": 0,
//     "TOTAL_ATE": 0,
//     "PROC_CANT_EXA_BUSCA_DIAS": 0,
//     "CONF_DIAS_FECHA_BUSCA_DIAS": 0,
//     "CONF_DIAS_EXA_BUSCA_DIAS": 0,
//     "ID_ESTADO_BUSCA_DIAS ": 0,
//     "ID_PROCEDENCIA_BUSCA_DIAS": 0,
//     "ID_CONF_DIAS_BUSCA_DIAS": 0,


//     "AGEND_CUPO_NORMAL": 0,
//     "AGEND_PRIORITARIO": 0,
//     "AGEND_ESPONTANEO": 0,
//     "TOTAL_AGEND_CUPO_NORMAL ": 0,
//     "TOTAL_AGEND_PRIORITARIO": 0,
//     "TOTAL_AGEND_ESPONTANEO": 0
// }
//];

//function Ajax_DataTable() {




//    var Data_Par = JSON.stringify({
//        "fecha": "ssssss",
//        "id": $("#Procedencia").val()
//    });

//    $.ajax({
//        "type": "POST",
//        "url": "Ingreso_Ate.aspx/Llenar_DataTable",
//        "data": Data_Par,
//        "contentType": "application/json;  charset=utf-8",
//        "dataType": "json",
//        "success": function (response) {
//            var json_receiver = response.d;
//            if (json_receiver != "null") {
//                Mx_Dtt_4556 = JSON.parse(json_receiver);
//                Fill_DataTable();




//            } else {


//                Hide_Modal();

//                //$("#EM2 h5").text("Error:");
//                //$("#button_modal").attr("class", "btn btn-danger");
//                //$("#EM2 p").text("Sin resultados");
//                //$("#EM2").modal();
//            }
//            //$("#Id_Conte").show();
//            //$(".block_wait").fadeOut(500);
//        },
//        "error": function (response) {
//            var str_Error = response.responseJSON.ExceptionType + "\n \n";
//            str_Error = response.responseJSON.Message;
//            alert(str_Error);



//        }
//    });
//}

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
};
function Fill_DL_GENERO() {
    $("#Genero").empty();

    $("<option>", {
        "value": 0
    }).text("Seleccionar").appendTo("#Genero");
    for (let y = 0; y < Mx_DL_GENERO.length; ++y) {
        $("<option>", {
            "value": Mx_DL_GENERO[y].ID_GENERO
        }).text(Mx_DL_GENERO[y].GENERO_DESC).appendTo("#Genero");
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
};

/// llenado examenes modal
function Fill_DataTable_Pack() {
    $("#Div_Tabla_Pack").empty();
    $("<table>", {
        "id": "DataTable_pack",
        "class": "display",
        "width": "100%",
        "cellspacing": "0"
    }).appendTo("#Div_Tabla_Pack");

    $("#DataTable_pack").append(
        $("<thead>"),
        $("<tbody>")
    );
    $("#DataTable_pack").attr("class", "table table-hover table-striped table-iris");
    $("#DataTable_pack thead").attr("class", "cabzera");
    $("#DataTable_pack thead").append(
        $("<tr>").append(

            $("<th>", { "class": "textoReducido" }).text("Nº"),
            $("<th>", { "class": "textoReducido" }).text("Codigo"),
            $("<th>", { "class": "textoReducido" }).text("Descripcion"),
            $("<th>", { "class": "textoReducido" }).text("Carga")

        )
    );

    Mx_Dtt_Pack.map((item, index) => {
        $("#DataTable_pack tbody").append(
            $("<tr>", {
                "class": "textoReducido manito",
                "padding": "1px !important",
            }).append(
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido"

                }).text(index + 1),
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido"
                }).text(item.PACK_COD),
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido"
                }).text(item.PACK_DESC),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido"
                }).html("<div class='checkbox checkbox-success pp' style='margin-top:-5px;'><input type='checkbox' class='manitos2' name='chk_Btn_Pack' id='H" + index + "' value='" + item.ID_PACK+ "' /><label class='manitos2' for='H" + index + "'></label></div>")
            )
        )
    });

 
    $("#DataTable_pack").keydown(function EnterEvent(e) {
        e.stopImmediatePropagation();
        let keycode = e.keyCode;
        console.log(keycode);
        if (e.keyCode == 13) {
            selected = new Array();
            $(".pp input:checkbox:checked").each(function () {
                selected.push($(this).val());
            });
            for (var z = 0; z < Mx_Dtt_examcof.length; z++) {
                for (var x = 0; x < selected.length; x++) {
                    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == selected[x]) {
                        selected.splice(x, 1);
                    }
                }
            }
            for (var i = 0; i < selected.length; i++) {
                for (var x = 0; x < Mx_Dtt_exam02.length; x++) {
                    if (selected[i] == Mx_Dtt_exam02[x].ID_CODIGO_FONASA) {




                        Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02[x]));
                        Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                    }
                }
            }

            fill_llenado_tabla();
            $('#eModalPack').modal('hide');
        }
    });
    $("#DataTable_pack").DataTable({
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


    $("input[name=chk_Btn_Exa]").click((e) => {

        let val = $(e.currentTarget).val();
        let status = $(e.currentTarget).prop("checked");
        //console.log(val + " " + status);

        if (status == true) {
            Mx_Carga_Pack.map((item) => {
                if (aah == val) {
                    i = 1;
                }
            });

            if (i == 0) {
                Mx_Carga.push(val);
            }

        } else {
            let index = Mx_Carga.indexOf(val);
            //console.log(index);
            Mx_Carga.splice(index, 1);
        }
        //console.log(Mx_Carga);
    });
}
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
            $("<th>", { "class": "textoReducido" }).text("Valor Ambulatorio"), //DESCOMENTADO 
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
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido"
                }).text(Mx_Dtt_exam02[i].CF_PRECIO_AMB),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido"
                }).html("<div class='checkbox checkbox-success pp' style='margin-top:-5px;'><input type='checkbox' class='manitos2' name='chk_Btn_Exa' id='H" + i + "' value='" + Mx_Dtt_exam02[i].ID_CODIGO_FONASA + "' /><label class='manitos2' for='H" + i + "'></label></div>")
            )
        )
    }

    $("#DataTable_pac").keydown(function EnterEvent(e) {
        e.stopImmediatePropagation();
        let keycode = e.keyCode;
        console.log(keycode);
        if (e.keyCode == 13) {
            selected = new Array();
            $(".pp input:checkbox:checked").each(function () {
                selected.push($(this).val());
            });
            for (var z = 0; z < Mx_Dtt_examcof.length; z++) {
                for (var x = 0; x < selected.length; x++) {
                    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == selected[x]) {
                        selected.splice(x, 1);
                    }
                }
            }
            for (var i = 0; i < selected.length; i++) {
                for (var x = 0; x < Mx_Dtt_exam02.length; x++) {
                    if (selected[i] == Mx_Dtt_exam02[x].ID_CODIGO_FONASA) {




                        Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02[x]));
                        Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                    }
                }
            }

            fill_llenado_tabla();
            $('#eModal2').modal('hide');
        }
    });
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


    $("input[name=chk_Btn_Exa]").click((e) => {

        let val = $(e.currentTarget).val();
        let status = $(e.currentTarget).prop("checked");
        //console.log(val + " " + status);

        if (status == true) {
            let i = 0;
            Mx_Carga.forEach(aah => {
                if (aah == val) {
                    i = 1;
                }
            });

            if (i == 0) {
                Mx_Carga.push(val);
            }

        } else {
            let index = Mx_Carga.indexOf(val);
            //console.log(index);
            Mx_Carga.splice(index, 1);
        }
        //console.log(Mx_Carga);
    });
}


/**
* Busca si se cargó o se está intentando cargar un VIH, si se encuentra pregunta si se quiere colocar el VIH y sacar el resto o al revés.
*/
//const buscaVIHCargado = async () => {
//    const existeVIH = Mx_Dtt_examcof.some(item => item.CF_COD == "0306112");
//    if (!existeVIH) {
//        return false;
//    } if (Mx_Dtt_examcof.filter(item => item.CF_COD == "0306112").length == Mx_Dtt_examcof.length) {
//        return true
//    }
//    const { isConfirmed } = await Swal.fire({
//        icon: "warning",
//        title: 'VIH detectado',
//        text: `Al cargar un examen VIH a la atención no se pueden agregar examenes de otro tipo y
//                se quitarán los demás examenes cargados hasta el momento. ¿Desea continuar?`,
//        showDenyButton: true,
//        confirmButtonText: 'Cargar VIH',
//        denyButtonText: `Sacar VIH`
//    });
//    if (isConfirmed) {
//        Mx_Dtt_examcof = Mx_Dtt_examcof.filter(item => item.CF_COD == "0306169");
//        return true;
//    }
//    Mx_Dtt_examcof = Mx_Dtt_examcof.filter(item => item.CF_COD != "0306038" && item.CF_COD != "0306061");
//    return false;
//}
//let exaAuto = structuredClone(Examen.examAutomaticoData);
const buscaVIHCargado = async () => {
    console.log("Iniciando búsqueda de VIH en Mx_Dtt_examcof...");

    const existeVIH = Mx_Dtt_examcof.some(item => item.CF_COD == "0306112");
    console.log("¿Existe examen VIH?:", existeVIH);

    if (!existeVIH) {
        console.log("No se encontró examen VIH. Retornando false.");
        return false;
    }

    const totalVIH = Mx_Dtt_examcof.filter(item => item.CF_COD == "0306112").length;
    console.log("Cantidad de exámenes VIH encontrados:", totalVIH);
    console.log("Total de exámenes en Mx_Dtt_examcof:", Mx_Dtt_examcof.length);

    if (totalVIH === Mx_Dtt_examcof.length) {
        console.log("Todos los exámenes son VIH. Retornando true.");
        return true;
    }

    console.log("Mostrando alerta de confirmación...");
    const { isConfirmed } = await Swal.fire({
        icon: "warning",
        title: 'VIH detectado',
        text: `Al cargar un examen VIH a la atención no se pueden agregar exámenes de otro tipo y 
                se quitarán los demás exámenes cargados hasta el momento. ¿Desea continuar?`,
        showDenyButton: true,
        confirmButtonText: 'Cargar VIH',
        denyButtonText: `Sacar VIH`
    });

    console.log("Respuesta del usuario:", isConfirmed);

    if (isConfirmed) {
        console.log("Usuario confirmó. Filtrando solo VIH...");
        //Mx_Dtt_examcof = Mx_Dtt_examcof.filter(item => item.CF_COD == "0306169");
        Mx_Dtt_examcof = Mx_Dtt_examcof.filter(item => item.CF_COD == "0306112");
        console.log("Nueva lista de exámenes:", Mx_Dtt_examcof);
        return true;
    }

    console.log("Usuario negó. Eliminando ciertos exámenes...");
    //Mx_Dtt_examcof = Mx_Dtt_examcof.filter(item => item.CF_COD != "0306038" && item.CF_COD != "0306061");
    Mx_Dtt_examcof = Mx_Dtt_examcof.filter(
        item => item.CF_COD != "0306112" && item.CF_COD != "0306038" && item.CF_COD != "0306061"
    );
    console.log("Nueva lista de exámenes tras negación:", Mx_Dtt_examcof);

    return false;
}

let exaAuto = structuredClone(Examen.examAutomaticoData);
console.log("Exámenes automáticos clonados:", exaAuto);


///llenar check  selecciondas
//function fill_llenado_tabla() {
//    $("#DataTable_pac2 tbody").empty();
//    for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
//        $("#DataTable_pac2 tbody").append(
//            $("<tr>", {
//                "class": "textoReducido manito",
//                "padding": "1px !important",
//            }).append(
//                $("<td>", {
//                    "align": "left",
//                    "class": "textoReducido negrita"
//                }).html((function () {
//                    //Retornar un campo input
//                    return $("<input>", {
//                        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
//                        "data-cod": Mx_Dtt_examcof[i].CF_COD,
//                        "class": "td_input negrita",
//                        "value": Mx_Dtt_examcof[i].CF_COD
//                    })
//                }())),
//                $("<td>", {
//                    "align": "left",
//                    "class": "textoReducido td_val1 negrita"
//                }).text(Mx_Dtt_examcof[i].CF_DESC),
//                $("<td>", {
//                    "align": "center",
//                    "class": "textoReducido td_val3 negrita"
//                }).text(Mx_Dtt_examcof[i].CF_PRECIO_AMB),
//               $("<td>", {
//                   "align": "center",
//                   "class": "textoReducido td_val2 negrita"
//               }).text(Mx_Dtt_examcof[i].CF_DIAS),
//               $("<td>", {
//                   "align": "center"
//               }).html("<button type='button' class='btn btn-danger btn-xs borrar negrita' value='Eliminar' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>")
//               //,
//               // $("<td>", {
//               //     "align": "center"
//               // }).html(function () {


//               //     if (Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN == "Activo") {
//               //         return "<button type='button' class='btn btn-print btn-xs CEstado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>"
//               //     } else {
//               //         return "<button type='button' class='btn btn-success btn-xs Activado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Activo</button>"
//               //     }


//               // }())
//            )
//        )
//    }
//    add_row();
//}
//function fill_llenado_tabla() {
//    $("#DataTable_pac2 tbody").empty();
//    let total = 0; // Variable para almacenar el total

//    for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
//        let precio = parseFloat(Mx_Dtt_examcof[i].CF_PRECIO_AMB); // Obtener el precio y convertirlo a número
//        total += precio; // Sumar al total

//        $("#DataTable_pac2 tbody").append(
//            $("<tr>", {
//                "class": "textoReducido manito",
//                "padding": "1px !important",
//            }).append(
//                $("<td>", {
//                    "align": "left",
//                    "class": "textoReducido negrita"
//                }).html((function () {
//                    // Retornar un campo input
//                    return $("<input>", {
//                        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
//                        "data-cod": Mx_Dtt_examcof[i].CF_COD,
//                        "class": "td_input negrita",
//                        "value": Mx_Dtt_examcof[i].CF_COD
//                    });
//                }())),
//                $("<td>", {
//                    "align": "left",
//                    "class": "textoReducido td_val1 negrita"
//                }).text(Mx_Dtt_examcof[i].CF_DESC),
//                $("<td>", {
//                    "align": "center",
//                    "class": "textoReducido td_val3 negrita"
//                }).text(precio),
//                $("<td>", {
//                    "align": "center",
//                    "class": "textoReducido td_val2 negrita"
//                }).text(Mx_Dtt_examcof[i].CF_DIAS),
//                $("<td>", {
//                    "align": "center"
//                }).html("<button type='button' class='btn btn-danger btn-xs borrar negrita' value='Eliminar' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>")
//            )
//        );
//    }

//    // Asignar el valor total al div
//    $("#totalValue").text(total.toFixed(2)); // Asegúrate de que el div tenga el ID 'totalValue'
//    add_row();
//}

const setColors = (inputVacio, idColor) => {
    const border = inputVacio ? "red" : "#ccc";
    const color = inputVacio ? "red" : "#212529";
    $(`#${idColor}`)
        .css({ "border-color": border })
        .parent().css({ "color": color });
};
async function fill_llenado_tabla(buscarVIH = true) {
    setColors(false, "slctGrupoPesquisaVIH");
    setColors(false, "slctGrupoPesquisaRPRChagas");

    const vihSeleccionado = parseInt(document.getElementById("slctGrupoPesquisaVIH").value);
    const chagasSeleccionado = parseInt(document.getElementById("slctGrupoPesquisaRPRChagas").value);

    $("#slctGrupoPesquisaVIH, #slctGrupoPesquisaRPRChagas").empty().append(
        $("<option>", { value: 0, text: "No Aplica" })
    );
    if (Mx_Dtt_examcof.length > 0) {
        if (buscarVIH) {
            await buscaVIHCargado();
        }

        //agregar los examenes automaticos
        for (let key in exaAuto) {
            Examen.buscaUnExamenAgregaOtro(
                exaAuto[key].codigo,
                exaAuto[key].agregar,
                Mx_Dtt_examcof,
                Mx_Dtt_exam02
            );
        }

        //bloquear los examenes segun lo que esté ingresado
        for (let key in exaAuto) {
            Mx_Dtt_examcof = Examen.buscaUnExamenBloqueaOtros(
                exaAuto[key].codigo,
                exaAuto[key].bloquear,
                Mx_Dtt_examcof,
                Mx_Dtt_exam02,
                exaAuto
            );
        }

        const existeVIH = Mx_Dtt_examcof.some(item => item.CF_COD == "0306112");
        const existeRPRChagas = Mx_Dtt_examcof.some(item => item.CF_COD == "0306038" || item.CF_COD == "0306061");
        //if (existeVIH) {
        //    await fillGrupoPesquisa({ idSelect: "slctGrupoPesquisaVIH", idTipoPesquisa: 1, defaultValue: vihSeleccionado });
        //    $("#slctGrupoPesquisaVIH").attr("disabled", false)
        //    $("#slctGrupoPesquisaRPRChagas").attr("disabled", true)
        //}
        //if (existeRPRChagas) {
        //    await fillGrupoPesquisa({ idSelect: "slctGrupoPesquisaRPRChagas", idTipoPesquisa: 2, defaultValue: chagasSeleccionado });
        //    $("#slctGrupoPesquisaVIH").attr("disabled", true)
        //    $("#slctGrupoPesquisaRPRChagas").attr("disabled", false)
        //}
        if (existeVIH) {
            await fillGrupoPesquisa({ idSelect: "slctGrupoPesquisaVIH", idTipoPesquisa: 1, defaultValue: vihSeleccionado });
            $("#slctGrupoPesquisaVIH").attr("disabled", false);
            $("#slctGrupoPesquisaRPRChagas").attr("disabled", true);

            // Validación para impedir el valor 0
            //const valorVIH = $("#slctGrupoPesquisaVIH").val();
            //if (valorVIH == 0) {
            //    $("#slctGrupoPesquisaVIH").addClass("input-error");
            //    console.log(`Error: El campo con id 'slctGrupoPesquisaVIH' no puede tener el valor 0.`);
            //    return
            //} else {
            //    $("#slctGrupoPesquisaVIH").removeClass("input-error");
            //}
        }

        if (existeRPRChagas) {
            await fillGrupoPesquisa({ idSelect: "slctGrupoPesquisaRPRChagas", idTipoPesquisa: 2, defaultValue: chagasSeleccionado });
            $("#slctGrupoPesquisaVIH").attr("disabled", true);
            $("#slctGrupoPesquisaRPRChagas").attr("disabled", false);

            // Validación para impedir el valor 0
            // Validación directa del valor
            //const valorRPRChagas = $("#slctGrupoPesquisaRPRChagas").val();
            //if (valorRPRChagas == 0) {
            //    $("#slctGrupoPesquisaRPRChagas").addClass("input-error");
            //    console.log(`Error: El campo con id 'slctGrupoPesquisaRPRChagas' no puede tener el valor 0.`);
            //    return
            //} else {
            //    $("#slctGrupoPesquisaRPRChagas").removeClass("input-error");
            //}
        }

    }
    $("#DataTable_pac2 tbody").empty();
    let total = 0; // Variable para almacenar el total

    for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
        let precio = parseFloat(Mx_Dtt_examcof[i].CF_PRECIO_AMB); // Obtener el precio y convertirlo a número
        total += precio; // Sumar al total

        $("#DataTable_pac2 tbody").append(
            $("<tr>", {
                "class": "textoReducido manito",
                "padding": "1px !important",
            }).append(
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido negrita"
                }).html((function () {
                    // Retornar un campo input
                    return $("<input>", {
                        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        "data-cod": Mx_Dtt_examcof[i].CF_COD,
                        "class": "td_input negrita",
                        "value": Mx_Dtt_examcof[i].CF_COD
                    });
                }())),
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido td_val1 negrita"
                }).text(Mx_Dtt_examcof[i].CF_DESC),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido td_val3 negrita"
                }).html((function () {
                    return $("<input>", {
                        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        "data-cod": "sitio_anato",
                        "class": "td_input negrita",
                        "data-anato": Mx_Dtt_examcof[i].IS_ANATO,
                        "disabled": Mx_Dtt_examcof[i].IS_ANATO == true ? false : true
                    });
                }())),
                $("<td>", {
                    "align": "center",
                    "class": "textoReducido td_val2 negrita"
                }).text(Mx_Dtt_examcof[i].CF_DIAS),
                $("<td>", {
                    "align": "center"
                }).html("<button type='button' class='btn btn-danger btn-xs borrar negrita' value='Eliminar' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>")
            )
        );
    }

    // Formatear el total como dinero chileno sin símbolo y con punto como separador de miles
    let totalFormatted = total.toLocaleString('es-CL', { minimumFractionDigits: 0, maximumFractionDigits: 0 });
    $("#totalValue").text(totalFormatted); // Asegúrate de que el span tenga el ID 'totalValue'
    add_row();

    // Agregar manejador de eventos para el botón de eliminar
    //$(".borrar").click(function () {
    //    $(this).closest("tr").remove(); // Eliminar la fila
    //    recalculateTotal(); // Recalcular el total
    //});
}

// Función para recalcular el total
function recalculateTotal() {
    let total = 0;
    $("#DataTable_pac2 .td_val3").each(function () {
        let precio = parseFloat($(this).text());
        if (!isNaN(precio)) {
            total += precio;
        }
    });
    // Formatear el total como dinero chileno sin símbolo y con punto como separador de miles
    let totalFormatted = total.toLocaleString('es-CL', { minimumFractionDigits: 0, maximumFractionDigits: 0 });
    $("#totalValue").text(totalFormatted); // Actualizar el total en el span
}
function success(xxid, xxcod, xtxis) {
    if (Mx_Dtt_exam03.length == 0) {
        $("input[data-id='" + xxid + "']").val(xxcod);
    } else if (Mx_Dtt_exam03.length == 1) {

        var repetido = 0;
        for (let z = 0; z < Mx_Dtt_examcof.length; z++) {
            if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == Mx_Dtt_exam03[0].ID_CODIGO_FONASA) {
                repetido++
            }
        }
        if (repetido == 0) {
            if (xxid != 0) {
                Mx_Dtt_examcof.push(Mx_Dtt_exam03[0]);
                for (let i = 0; i < Mx_Dtt_examcof.length; i++) {
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

        //const existeVIH = Mx_Dtt_exam03.some(item => item.CF_COD == "0306112");
        //const existeRPRChagas = Mx_Dtt_exam03.some(item => item.CF_COD == "0306038" || item.CF_COD == "0306061");
        //if (existeVIH) {
        //    await fillGrupoPesquisa({ idSelect: "slctGrupoPesquisaVIH", idTipoPesquisa: 1, defaultValue: vihSeleccionado });
        //    $("#slctGrupoPesquisaVIH").attr("disabled", false)
        //    $("#slctGrupoPesquisaRPRChagas").attr("disabled", true)
        //}
        //if (existeRPRChagas) {
        //    await fillGrupoPesquisa({ idSelect: "slctGrupoPesquisaRPRChagas", idTipoPesquisa: 2, defaultValue: chagasSeleccionado });
        //    $("#slctGrupoPesquisaVIH").attr("disabled", true)
        //    $("#slctGrupoPesquisaRPRChagas").attr("disabled", false)
        //}
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



//$(function () {
//    $('#datetimepicker1').datetimepicker(
//{
//    debug: true,
//    icons: {
//        previous: 'fa fa-arrow-left',
//        next: 'fa fa-arrow-right'
//    },
//    format: 'dd-mm-yyyy',
//    language: 'es',
//    weekStart: 1,
//    autoclose: true,
//    minDate: Date.now(),
//    minView: 2,
//    useCurrent: true

//})
//});

$(function () {
    $('#datetimepicker3').datetimepicker(
        {
            debug: true,
            icons: {
                previous: 'fa fa-arrow-left',
                next: 'fa fa-arrow-right'
            },
            format: 'dd-mm-yyyy',
            language: 'es',
            weekStart: 1,
            autoclose: true,
            minDate: Date.now(),
            minView: 2,
            useCurrent: true

        })
});

let Mx_BUSCA_DOC = [
    {
        "ID_DOC": 0,
        "DOC_NOMBRE": 0,
        "DOC_RUT": 0
    }
];

async function Ajax_Graba_Edita_Doctor() {
    let _drut, _dnom, _did;

    _drut = $("#RUT_Doctor").val();
    _dnom = $("#Doctor").val();
    _did = $("#Doctor").attr("data-id");

    if (est_Doc != 0 && _dnom != "") {
        let data = JSON.stringify({
            "RUT": _drut,
            "NOMBRE": _dnom,
            "ID": _did,
            "TIPO": est_Doc
        });

        await $.ajax({
            "type": "POST",
            "url": "Ingreso_Ate.aspx/IRIS_WEBF_GRABA_EDITA_DOC",
            "data": data,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": function (response) {
                console.log(response.d);
                $("#Doctor").attr("data-id", response.d);
            },
            "error": function (response) {


            }
        });
    }

}
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@AGREGAR EL BUSCADOR Y CREACION DE DOCTOR@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
function Ajax_Busca_Doc_Por_Nom(nom) {

    let data = JSON.stringify({
        "NOM": nom
    });

    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/IRIS_WEBF_BUSCA_DOC_POR_NOM",
        "data": data,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {

                $("#dtt_Doc").dataTable().fnDestroy();


                $("#dtt_Doc tbody").empty();

                Mx_BUSCA_DOC = json_receiver;

                console.log(Mx_BUSCA_DOC);

                for (let i = 0; i < Mx_BUSCA_DOC.length; i++) {

                    $("<tr>").append(
                        $("<td>").text(Mx_BUSCA_DOC[i].DOC_RUT),
                        $("<td>").text(Mx_BUSCA_DOC[i].DOC_NOMBRE),
                        $("<td>").css("text-align", "center").html("<button name='btn_Doc' class='btn btn-success' data-index ='" + i + "'><i class='fa fa-check'></i>")
                    ).appendTo("#dtt_Doc tbody");
                }

                $("#dtt_Doc").DataTable({
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

                $("#mdl_Doc").modal("show");


                $("button[name='btn_Doc']").click(e => {

                    console.log(e);

                    let index = $(e.currentTarget).attr("data-index");

                    $("#RUT_Doctor").val(Mx_BUSCA_DOC[index].DOC_RUT);
                    $("#Doctor").val(Mx_BUSCA_DOC[index].DOC_NOMBRE);
                    $("#Doctor").attr("data-id", Mx_BUSCA_DOC[index].ID_DOC);

                    if (Mx_BUSCA_DOC[index].DOC_RUT == "") {
                        est_Doc = 1;
                    } else {
                        est_Doc = 0;
                        //$("#Doctor").attr("readonly", true);
                    }

                    $("#mdl_Doc").modal("hide");
                });

            } else {

                console.log(response.d);
                $("#RUT_Doctor").val("");
                $("#Doctor").val("");
                $("#Doctor").attr("data-id", 0);
                $("#Doctor").removeAttr("readonly");
                est_Doc = 2;
            }
        },
        "error": function (response) {
            $("#RUT_Doctor").val("");
            $("#Doctor").val("");
            $("#Doctor").attr("data-id", 0);
            $("#Doctor").removeAttr("readonly");
            est_Doc = 2;

        }
    });
}

function Ajax_Busca_Doc_Por_Rut(rut) {

    let data = JSON.stringify({
        "RUT": rut
    });

    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate.aspx/IRIS_WEBF_BUSCA_DOC_POR_RUT",
        "data": data,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != null) {
                Mx_BUSCA_DOC = json_receiver;

                console.log(Mx_BUSCA_DOC);

                if (Mx_BUSCA_DOC.ID_DOC != 0) {
                    $("#Doctor").val(Mx_BUSCA_DOC.DOC_NOMBRE);
                    $("#Doctor").attr("data-id", Mx_BUSCA_DOC.ID_DOC);
                    //$("#Doctor").attr("readonly", true);
                }

                est_Doc = 0;

            } else {

                console.log(response.d);

                //$("#RUT_Doctor").val("");
                $("#Doctor").val("");
                $("#Doctor").attr("data-id", 0);
                $("#Doctor").removeAttr("readonly");

                est_Doc = 2;
            }
        },
        "error": function (response) {
            $("#RUT_Doctor").val("");
            $("#Doctor").val("");
            $("#Doctor").attr("data-id", 0);
            $("#Doctor").removeAttr("readonly");
            est_Doc = 2;
        }
    });
}

