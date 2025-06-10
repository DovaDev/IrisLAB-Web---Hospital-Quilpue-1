import { fillExamenesRlsAreaSeccPrev, fillExamenesSinPrevision } from "../js/es6-modules/Examenes.js?1";
import fillPrevisiones from "../js/es6-modules/Previsiones.js";
import fillProcedencias from "../js/es6-modules/Procedencias.js";
import fillSeccionesAreas from "../js/es6-modules/Secciones.js";
import fillTiposAtencion from "../js/es6-modules/TiposAtencion.js";
import fillTiposCritico from "../js/es6-modules/TiposCritico.js";

let ID_ATE_RES_SUPREME = 0;
let NumerototalLlamadas = 0;
let NumerototalCorreos = 0;
function updateNotificationOptions() {
    // Obtener el ID del resultado de atención actual
    const idAteRes = ID_ATE_RES_SUPREME;

    $.ajax({
        type: "POST",
        url: "Val_Criticos_Notif.aspx/GetNotificationCounts",
        data: JSON.stringify({ ID_ATE_RES: idAteRes }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            const counts = res.d;
            const numLlamadas = counts.numLlamadas || 0;
            const numCorreos = counts.numCorreos || 0;

            // // Deshabilitar opciones de llamadas ya utilizadas
            // $("#Ddl_llamado option").each(function () {
            //     if ($(this).val() <= numLlamadas) {
            //         $(this).attr("disabled", true);
            //     } else {
            //         $(this).attr("disabled", false);
            //     }
            // });
            //
            // // Deshabilitar opciones de correos ya utilizadas
            // $("#Ddl_correo option").each(function () {
            //     if ($(this).val() <= numCorreos) {
            //         $(this).attr("disabled", true);
            //     } else {
            //         $(this).attr("disabled", false);
            //     }
            // });

            toggleLlamado();
            toggleCorreo();
        }
    });
}

function Call_Guardar() {
    console.log("LLamadas enviadas:", NumerototalLlamadas, "Selccionado el", $("#Ddl_Stat_aviso2").val());
    if (NumerototalLlamadas == 3 && $("#Ddl_Stat_aviso2").val() == 2) {
        Swal.fire({ icon: "info", title: "Información", text: "Ya se realizaron el numero maximo de llamdas" });
        return;
    }

    if (NumerototalCorreos == 3 && $("#Ddl_Stat_aviso2").val() == 1) {
        Swal.fire({ icon: "info", title: "Información", text: "Ya se realizaron el numero maximo de llamdas" });
        return;
    }
    const fechaAvisado = $("#fecha3").val();
    if (fechaAvisado == "") {
        Swal.fire({ icon: "info", title: "Información", text: "Ingrese una fecha y hora válida" });
        return;
    }

    if ($("#Ddl_Stat_aviso2").val() == 2 && $("#Ddl_llamado").val() == 0) {
        Swal.fire({ icon: "info", title: "Información", text: "Debe marcar el número de llamadas" });
        return;
    }

    if ($("#Ddl_Stat_aviso2").val() == 3 && $("#Ddl_correo").val() == 0) {
        Swal.fire({ icon: "info", title: "Información", text: "Debe seleccionar el número de correos" });
        return;
    }


    const tipoNotificacion = $("#Ddl_Stat_aviso2").val();
    const numLlamadas = tipoNotificacion == 2 ? $("#Ddl_llamado").val() : 0;
    const numCorreos = tipoNotificacion == 3 ? $("#Ddl_correo").val() : 0;

    const Data_Par = JSON.stringify({
        ID_ATE_RES_SUPREME: ID_ATE_RES_SUPREME,
        S_Id_User: Galletas.getGalleta("ID_USER"),
        DATE_str01: fechaAvisado,
        NOTIFICADO: $("#txt_avisao").val(),
        ID_TP_CRITICO: tipoNotificacion,
        CAUSA: $("#txt_causa").val(),
        LLAMADO: numLlamadas,
        CORREO: numCorreos,
        ESTADO_NOTIFICADO: 3 // Agregar este parámetro
    });
    console.log("Datos enviados: ", Data_Par)
    $.ajax({
        type: "POST",
        url: "Val_Criticos_Notif.aspx/Call_Guardar",
        data: Data_Par,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            console.log("Data_Par:", Data_Par); // Para depuración
            console.log("Response:", res);

            function handleResponse(message, shouldReload) {
                Swal.fire({
                    icon: "success",
                    title: "Éxito",
                    text: message
                }).then(() => {
                    $('#mdlDet').modal('hide');
                    if (shouldReload) {
                        Call_Data_Table();
                    }
                });
            }

            switch (res.d) {
                case "1":
                    handleResponse("Notificación creada correctamente.", true);
                    break;
                case "-1":
                    Swal.fire({
                        icon: "info",
                        title: "Información",
                        text: "Se alcanzó el límite de notificaciones para este tipo."
                    }).then(() => {
                        $('#mdlDet').modal('hide');
                        Call_Data_Table();
                    });
                    break;
                case "10":
                    Swal.fire({
                        icon: "info",
                        title: "Información",
                        text: "Ocurrió un error con la fecha, intente de nuevo."
                    }).then(() => {
                        $("#fecha3").val("");
                        $('#mdlDet').modal('hide');
                        Call_Data_Table();
                    });
                    break;
                default:
                    Swal.fire({
                        icon: "error",
                        title: "Error",
                        text: "Código de respuesta desconocido."
                    }).then(() => {
                        $('#mdlDet').modal('hide');
                        Call_Data_Table();
                    });
                    break;
            }

            // Actualizar las opciones de notificación después de guardar
            updateNotificationOptions();
        },
        error: function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);
        }
    });

    $("#txt_causa").prop("disabled", false);
}


function Finalizar_Proceso() {
    const tipoNotificacion = $("#Ddl_Stat_aviso2").val();
    const numLlamadas = tipoNotificacion == 2 ? $("#Ddl_llamado").val() : 0;
    const numCorreos = tipoNotificacion == 3 ? $("#Ddl_correo").val() : 0;

    const Data_Par = JSON.stringify({
        ID_ATE_RES_SUPREME: ID_ATE_RES_SUPREME,
        S_Id_User: Galletas.getGalleta("ID_USER"),
        NOTIFICADO: $("#txt_avisao").val(),
        ID_TP_CRITICO: tipoNotificacion,
        LLAMADO: numLlamadas,
        CORREO: numCorreos,
        ESTADO_NOTIFICADO: 1 // Cambia a notificado
    });

    $.ajax({
        type: "POST",
        url: "Val_Criticos_Notif.aspx/Finalizar_Proceso",
        data: Data_Par,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            console.log(Data_Par);
            console.log(res);

            // Cerrar el modal y recargar la tabla en todos los casos
            function handleSuccess(message) {
                Swal.fire({
                    icon: "success",
                    title: "Éxito",
                    text: message
                }).then(() => {
                    $('#mdlDet').modal('hide');
                    Call_Data_Table(); // Recargar la tabla principal
                });
            }

            switch (res.d) {
                case "1":
                    handleSuccess("Proceso finalizado correctamente y estado 'Notificado'.");
                    break;
                case "-1":
                    Swal.fire({
                        icon: "info",
                        title: "Información",
                        text: "Se alcanzó el límite de notificaciones para este tipo."
                    }).then(() => {
                        $('#mdlDet').modal('hide');
                        Call_Data_Table(); // Recargar la tabla principal
                    });
                    break;
                case "10":
                    Swal.fire({
                        icon: "info",
                        title: "Información",
                        text: "Ocurrió un error, intente de nuevo."
                    }).then(() => {
                        $('#mdlDet').modal('hide');
                        Call_Data_Table(); // Recargar la tabla principal
                    });
                    break;
                case "6":
                    Swal.fire({
                        icon: "info",
                        title: "Información",
                        text: "El proceso se ha completado."
                    }).then(() => {
                        $('#mdlDet').modal('hide');
                        Call_Data_Table(); // Recargar la tabla principal
                    });
                    break;
                default:
                    Swal.fire({
                        icon: "error",
                        title: "Error",
                        text: "El proceso se ha completado."
                    }).then(() => {
                        $('#mdlDet').modal('hide');
                        Call_Data_Table(); // Recargar la tabla principal
                    });
                    break;
            }
        },
        error: function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);
        }
    });
}

//-------------------------------------------------- AJAX ESTADO -------------------------------------------------------
let JSON_Ddl_Stat = []
function Call_Data_Ddl_Stat() {
    modal_show();
    $.ajax({
        "type": "POST",
        "url": "Val_Criticos_Notif.aspx/Call_Ddl_Stat",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            JSON_Ddl_Stat = JSON.parse(response.d);
            Hide_Modal();
            Fill_Ddl_Stat();
        }
    });
}

let JSON_Data_Table = [];
function Call_Data_Table() {
    modal_show();
    let Data_Par = JSON.stringify({
        "DATE_str01": String($("#fecha").val()),
        "DATE_str02": String($("#fecha2").val()),
        "ID_EXAM": String($("#Ddl_Exam").val()),
        "ID_PREV": String($("#DdlPrevision").val()),
        "ID_STAT": String($("#Ddl_Stat").val()),
        "ID_TP_ATENCION": String($("#DdlTipoAtencion").val()),
        ID_RLS_LS: $("#Ddl_Seccion").val(),
    });

    $(".block_wait").fadeIn(500);
    $.ajax({
        "type": "POST",
        "url": "Val_Criticos_Notif.aspx/Call_DataTable",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            if (response.d.length > 0) {
                JSON_Data_Table = response.d;
                console.log("JSON_Data_Table", JSON_Data_Table)

                var value_valid = $("#Ddl_Stat_Valid").val()

                if (value_valid == 1) {
                    JSON_Data_Table = JSON_Data_Table.filter((item) => item.ATE_EST_VALIDA == 6 || item.ATE_EST_VALIDA == 14)
                } 

                if (value_valid == 2) {
                    JSON_Data_Table = JSON_Data_Table.filter((item) => item.ATE_EST_VALIDA != 6 && item.ATE_EST_VALIDA != 14)
                }

                Hide_Modal();
                $("#Id_Conte").show();
                $("#Div_Tabla").empty();
                Fill_DataTable();
            } else {
                Hide_Modal();
                $("#Id_Conte").hide();
                $("#mError_AAH h4").text("Sin resultados");
                $("#mError_AAH button").attr("class", "btn btn-danger");
                $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda solicitada.");
                $("#mError_AAH").modal();
            }
        },
        "error": function (response) {
            Hide_Modal();
        }
    });
}

let JSON_Data_Table_det = [];

const idUserCookie = Galletas.getGalleta("ID_USER");
const idAdminCookie = Galletas.getGalleta("P_ADMIN");

function Call_Data_Table_Detalle(id_ate_ressss) {
    //si el perfil es tens o si es dpereira o rorellana
    //if (idAdminCookie != 8 && ![1, 328].includes(parseInt(idUserCookie))) {
    //    return
    //}

    modal_show();

    var Data_Par = JSON.stringify({
        "ID_ATE_RES": id_ate_ressss
    });

    $(".block_wait").fadeIn(500);
    $.ajax({
        "type": "POST",
        "url": "Val_Criticos_Notif.aspx/Call_DataTable_Det",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            if (response.d != "null") {
                JSON_Data_Table_det = JSON.parse(response.d);
                Hide_Modal();
                $("#divTableDet2").empty();
                ID_ATE_RES_SUPREME = JSON_Data_Table_det[0].ID_ATE_RES

                // Get the current date and time
                const now = new Date();

                // Format the date and time as required by datetime-local input type (YYYY-MM-DDThh:mm)
                const year = now.getFullYear();
                const month = String(now.getMonth() + 1).padStart(2, '0'); // Months are zero-based
                const day = String(now.getDate()).padStart(2, '0');
                const hours = String(now.getHours()).padStart(2, '0');
                const minutes = String(now.getMinutes()).padStart(2, '0');

                // Set the value of the input element
                const datetimeInput = document.getElementById('fecha3');
                datetimeInput.value = `${year}-${month}-${day}T${hours}:${minutes}`;

                Call_Data_Table_Detalle_Past(id_ate_ressss);
            } else {
                Hide_Modal();
                $("#Id_Conte").hide();
                $("#mError_AAH h4").text("Sin resultados");
                $("#mError_AAH button").attr("class", "btn btn-danger");
                $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda solicitada.");
                $("#mError_AAH").modal();
            }

        },
        "error": function (response) {

            Hide_Modal();
        }
    });
}

let JSON_Data_Table_det2 = [];
function Call_Data_Table_Detalle_Past(id_ate_ressss) {
    modal_show();

    var Data_Par = JSON.stringify({
        ID_ATE_RES: id_ate_ressss,
        ES_SAPU: $("#DdlTipoAtencion").val() == 5,
    });

    $(".block_wait").fadeIn(500);
    $.ajax({
        "type": "POST",
        "url": "Val_Criticos_Notif.aspx/Call_DataTable_Det_past",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            JSON_Data_Table_det2.length = 0;
            if (response.d != "null") {
                JSON_Data_Table_det2 = JSON.parse(response.d);
                Hide_Modal();
                $("#divTableDet").empty();
                $("#divTableDet2").empty();



                Fill_DataTable_Det();

            } else {
                Hide_Modal();
                Fill_DataTable_Det();
                //$("#Id_Conte").hide();
                //$("#mError_AAH h4").text("Sin resultados");
                //$("#mError_AAH button").attr("class", "btn btn-danger");
                //$("#mError_AAH p").text("No se han encontrado resultados para la búsqueda solicitada.");
                //$("#mError_AAH").modal();
            }

        },
        "error": function (response) {

            Hide_Modal();
        }
    });
}


function Call_Export() {
    modal_show();
    var Data_Par = JSON.stringify({
        "DOMAIN_URL": location.origin,
        "DATE_str01": String($("#fecha").val()),
        "DATE_str02": String($("#fecha2").val()),
        "ID_EXAM": String($("#Ddl_Exam").val()),
        "ID_PREV": String($("#DdlPrevision").val()),
        "ID_STAT": String($("#Ddl_Stat").val()),
        "ID_TP_ATENCION": String($("#DdlTipoAtencion").val()),
        ID_RLS_LS: $("#Ddl_Seccion").val(),
    });

    $.ajax({
        "type": "POST",
        "url": "Val_Criticos_Notif.aspx/Call_Export",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;

            if (json_receiver != "null") {
                Hide_Modal();
                window.open(json_receiver, 'Download');

            } else {
                Hide_Modal();
                $("#mError_AAH h4").text("Sin resultados");
                $("#mError_AAH button").attr("class", "btn btn-danger");
                $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda solicitada.");
                $("#mError_AAH").modal();
            }
        },
        "error": function (response) {
            Hide_Modal();
        }
    });
}

//Llenar DropDownList Estado
function Fill_Ddl_Stat() {
    $("#Ddl_Stat").empty();

    $("<option>", { value: 0, text: "Todos" }).appendTo("#Ddl_Stat");
    JSON_Ddl_Stat.forEach(item => {
        $("<option>", { value: item.Value, text: item.Text }).appendTo("#Ddl_Stat");
    });

}
const estadoText = estado => {
    switch (estado) {
        case 1: return "Notificado";
        case 0: return "Sin Notificar";
        case 3: return "En Proceso";
        default: return "Desconocido";
    }
};

const color = estado => {
    switch (estado) {
        case 1: return "background-color:#9affb1;"; // Notificado
        case 0: return "background-color:#ff8a8a;"; // Sin Notificar
        case 3: return "background-color:#ffff99;"; // En Proceso (amarillo)
        default: return "background-color:#ffffff;"; // Desconocido (blanco)
    }
};

const apruebaColor = (es_sapu, aprueba_sapu, aprueba_normal) => {
    if (es_sapu) {
        return aprueba_sapu ? "background-color:#9affb1;" : "background-color:#ff8a8a;";
    } else {
        return aprueba_normal ? "background-color:#9affb1;" : "background-color:#ff8a8a;";
    }
};

//---------------------------------------------------- TABLA PACIENTE -------------------------------------------------------|
function Fill_DataTable() {
    $("<table>", { "id": "DataTable", "class": "display", "width": "100%", "cellspacing": "0" }).appendTo("#Div_Tabla");
    $("#DataTable").append($("<thead>"), $("<tbody>"));
    $("#DataTable").attr("class", "table table-hover table-striped table-iris");
    $("#DataTable thead").attr("class", "cabezera");
    $("#DataTable thead").append(
        $("<tr>").append(
            $("<th>", { "class": "textoReducido" }).text("#"),
            $("<th>", { "class": "textoReducido text-center" }).text("N° Ate."),
            $("<th>", { "class": "textoReducido text-center" }).text("RUT"),
            $("<th>", { "class": "textoReducido" }).text("Paciente"),
            $("<th>", { "class": "textoReducido" }).text("Edad"),
            $("<th>", { "class": "textoReducido text-center" }).text("Fecha Ingreso"),
            $("<th>", { "class": "textoReducido text-center" }).text("Lugar TdeM"),
            $("<th>", { "class": "textoReducido" }).text("Examen"),
            $("<th>", { "class": "textoReducido text-center" }).text("Determinación"),
            $("<th>", { "class": "textoReducido text-center" }).text("Resultado"),
            $("<th>", { "class": "textoReducido text-center" }).text("Alarma"),
            $("<th>", { "class": "textoReducido" }).text("Fecha Recepción"),
            $("<th>", { "class": "textoReducido" }).text("Fecha Validación"),
            $("<th>", { "class": "textoReducido text-center" }).text("Estado Notificación"),
            $("<th>", { "class": "textoReducido text-center" }).text("Fecha Notificación"),
            $("<th>", { "class": "textoReducido text-center" }).text("Diferencia Notif-Valid"),
            $("<th>", { "class": "textoReducido text-center" }).text("Aprueba Tiempo"),
            $("<th>", { "class": "textoReducido text-center" }).text("Usuario"),
            $("<th>", { "class": "textoReducido text-center" }).text("Tipo"),
            $("<th>", { "class": "textoReducido text-center" }).text("Notificado A"),
            $("<th>", { "class": "textoReducido text-center" }).text("Número de Notificaciones")
        )
    );

    JSON_Data_Table.forEach((item, i) => {
        console.log("Item Data:", item);
        console.log("Item Data:", item.APRUEBA_SAPU);
        console.log("Item Data:", item.APRUEBA_NORMAL);
        console.log("Item Data:", item.ES_SAPU);
        $("#DataTable tbody").append(
            $("<tr>", { id: item.ID_ATE_RES, class: "manito" }).append(
                $("<td>", { "align": "left", "class": "textoReducido" }).text(i + 1),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.ATE_NUM),
                $("<td>", { "align": "left", "class": "textoReducido" }).text(item.PAC_RUT_DNI),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.PAC_NOMBRE_COMPLETO),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.ATE_AÑO),
                $("<td>", { "align": "left", "class": "textoReducido" }).text(item.FECHA_INGRESO + " " + item.HORA_INGRESO),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.PROC_DESC),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.CF_DESC),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.PRU_DESC),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.RESULTADO),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.ATE_RESULTADO_ALT),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.FECHA_RECEPCION + " " + item.HORA_RECEPCION),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.FECHA_VALIDACION + " " + item.HORA_VALIDACION),
                $("<td>", { "align": "center", "class": "textoReducido", "style": color(item.NOTIFICADO) }).text(estadoText(item.NOTIFICADO)),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.FECHA_NOTIFICACION + " " + item.HORA_NOTIFICACION),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.HORAS_DIFERENCIA),
                $("<td>", { "align": "center", "class": "textoReducido", "style": apruebaColor(item.ES_SAPU, item.APRUEBA_SAPU, item.APRUEBA_NORMAL) }).html(item.ES_SAPU ? (item.APRUEBA_SAPU ? 'APRUEBA' : 'NO APRUEBA') : (item.APRUEBA_NORMAL ? 'APRUEBA' : 'NO APRUEBA')),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.QUIEN_NOTIFICA),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.MEDIO_NOTIFICACION),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.NOTIFICADO_A),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(`Llamadas: ${item.LLAMADA || 0}, Correos: ${item.DET_CORREO || 0}`)
            )
        );
    });

    $("#DataTable tbody tr").on("click", e => {
        const perfilUsuario = parseInt(Galletas.getGalleta("P_ADMIN")) || -1;
        if (![1, 9].includes(perfilUsuario)) return; // si no es tens o admin no abre el modal

        const item = JSON_Data_Table.find(item => item.ID_ATE_RES == e.currentTarget.id);
        const notificado = item ? item.NOTIFICADO : null;

        console.log("Perfil del usuario:", perfilUsuario);
        console.log("ID de la fila clicada:", e.currentTarget.id);
        console.log("Estado de notificación:", notificado);

        if (notificado === 1) {
            // Si 'notificado' es 1, ocultar los botones y hacer 'obs' solo lectura
            $("#btnguardar, #row-estado-fecha, #btnActualizar, #btnFinalizar, #row-avisado-a").attr("hidden", true);
            $("#h5-log-registros").attr("hidden", false);
            $("#txt_causa").prop("readonly", true);
        } else {
            // Si 'notificado' no es 1, ajustar la visibilidad de los botones
            $("#row-estado-fecha, #btnguardar, #btnFinalizar, #row-avisado-a").attr("hidden", false);
            $("#h5-log-registros").attr("hidden", false);
            $("#txt_causa").prop("readonly", false);
        }

        Call_Data_Table_Detalle(e.currentTarget.id);
    });

    $("#DataTable").DataTable({
        "bSort": false,
        "iDisplayLength": 100,
        "info": false,
        "language": {
            "lengthMenu": "Mostrar: MENU ",
            "zeroRecords": "&nbsp;",
            "infoEmpty": "&nbsp;",
            "infoFiltered": " TOTAL registros)",
            "search": "Buscar",
            "paginate": {
                "previous": "<",
                "next": ">"
            }
        }
    });
}




function Fill_DataTable_Det() {
    // Limpia el contenedor de la primera tabla
    $("#divTableDet").empty();
    $("#Ddl_llamado").prop("disabled", false);
    NumerototalLlamadas = 0;
    NumerototalCorreos = 0;

    // Crea la primera tabla
    const $tableDet = $("<table>", {
        "id": "DataTable_det",
        "class": "display table table-hover table-striped table-iris",
        "width": "100%",
        "cellspacing": "0"
    }).appendTo("#divTableDet");

    $tableDet.append(
        $("<thead>").append(
            $("<tr>").append(
                $("<th>", { "class": "textoReducido" }).text("#"),
                $("<th>", { "class": "textoReducido text-center" }).text("N° Atención"),
                $("<th>", { "class": "textoReducido text-center" }).text("Nombre Paciente"),
                $("<th>", { "class": "textoReducido" }).text("Edad"),
                $("<th>", { "class": "textoReducido" }).text("Fecha"),
                $("<th>", { "class": "textoReducido text-center" }).text("Lugar TM"),
                $("<th>", { "class": "textoReducido text-center" }).text("Determinación"),
                $("<th>", { "class": "textoReducido" }).text("Resultado"),
                $("<th>", { "class": "textoReducido text-center" }).text("Alarma"),
                $("<th>", { "class": "textoReducido text-center" }).text("Muy Bajo"),
                $("<th>", { "class": "textoReducido text-center" }).text("Bajo"),
                $("<th>", { "class": "textoReducido text-center" }).text("Alto"),
                $("<th>", { "class": "textoReducido text-center" }).text("Muy Alto")
            )
        ),
        $("<tbody>")
    );

    // Llena la primera tabla con datos
    JSON_Data_Table_det.forEach((item, i) => {
        $("#DataTable_det tbody").append(
            $("<tr>", { "class": "manito" }).append(
                $("<td>", { "align": "left", "class": "textoReducido" }).text(i + 1),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.ATE_NUM || 'N/A'),
                $("<td>", { "align": "left", "class": "textoReducido" }).text((item.PAC_NOMBRE || '') + " " + (item.PAC_APELLIDO || '')),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.ATE_AÑO || 'N/A'),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(moment(item.ATE_FECHA).format("DD-MM-YYYY")),
                $("<td>", { "align": "left", "class": "textoReducido" }).text(item.PROC_DESC || 'N/A'),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.PRU_DESC || 'N/A'),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.ATE_RESULTADO || 'N/A'),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.ATE_RESULTADO_ALT || 'N/A'),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.ATE_RR_DESDE || 'N/A'),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.ATE_R_DESDE || 'N/A'),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.ATE_R_HASTA || 'N/A'),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.ATE_RR_HASTA || 'N/A')
            )
        );
        $('#txt_causa').val(item.OBS || '').prop('disabled', false); // Dejar habilitado
        $('#txt_avisao').val(item.NOTIFICADO_A || '');
    });

    // Limpia el contenedor de la segunda tabla
    $("#divTableDet2").empty();

    if (JSON_Data_Table_det2.length === 0) {
        // Muestra un mensaje si no hay datos
        $("#divTableDet2").html("<h1>Sin Notificaciones</h1>");
        $("#mdlDet").modal("show");
        return;
    }

    // Verifica qué columnas se deben mostrar
    const showNumeroLlamadasColumn = JSON_Data_Table_det2.some(item => item.TP_CRITICO_DESC === 'TELEFONO');
    const showNumeroCorreosColumn = JSON_Data_Table_det2.some(item => item.TP_CRITICO_DESC === 'EMAIL');

    console.log("Show Llamadas Column:", showNumeroLlamadasColumn);
    console.log("Show Correos Column:", showNumeroCorreosColumn);

    const $tableDet2 = $("<table>", {
        "id": "DataTable_det_2",
        "class": "display table table-hover table-striped table-iris",
        "width": "100%",
        "cellspacing": "0"
    }).appendTo("#divTableDet2");

    $tableDet2.append(
        $("<thead>").append(
            $("<tr>").append(
                $("<th>", { "class": "textoReducido" }).text("#"),
                $("<th>", { "class": "textoReducido text-center" }).text("Fecha"),
                $("<th>", { "class": "textoReducido text-center" }).text("Tipo de Aviso"),
                $("<th>", { "class": "textoReducido text-center" }).text("Número de Notificaciones"),
                $("<th>", { "class": "textoReducido text-center" }).text("Usuario"),
                $("<th>", { "class": "textoReducido text-center" }).text("Estado"),
                $("<th>", { "class": "textoReducido text-center" }).text("Notificado A")
            )
        ),
        $("<tbody>")
    );

    // Llena la segunda tabla con datos
    JSON_Data_Table_det2.forEach((item, i) => {
        console.log("Item Detalle:", item); // Verifica los datos del ítem
        if (item.LLAMADA != 3 && NumerototalLlamadas != 3) {
            NumerototalLlamadas = item.LLAMADA
        }
        if (item.DET_CORREO != 3 && NumerototalCorreos != 3) {
            NumerototalCorreos = item.DET_CORREO
        }
        if (item.LLAMADA == 3) {
            // desabilita Ddl_llamada
            NumerototalLlamadas = 3
            $("#Ddl_llamado").prop("disabled", true);
        }
        if (item.DET_CORREO == 3) {
            NumerototalCorreos = 3
            $("#Ddl_correo").prop("disabled", true);
        }

        $("#DataTable_det_2 tbody").append(
            $("<tr>", { "class": "manito" }).append(
                $("<td>", { "align": "left", "class": "textoReducido" }).text(i + 1),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(moment(item.DET_CRITICO_FECHA).format("DD-MM-YYYY HH:mm")),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.TP_CRITICO_DESC || 'N/A'),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(`Llamadas: ${NumerototalLlamadas || 0}, Correos: ${NumerototalCorreos || 0}`),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.USU_NIC || 'N/A'),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.EST_DESCRIPCION || 'N/A'),
                $("<td>", { "align": "center", "class": "textoReducido" }).text(item.DET_CRITICO_DESC || 'N/A')
            )
        );
        console.log("NUMERO DE LLAMADAS: ", item.LLAMADA);

        // Deshabilitar opciones de llamas ya utilizadas
        $("#Ddl_llamado option").each(function () {
            if ($(this).val() <= NumerototalLlamadas) {
                $(this).attr("disabled", true);
                $("#Ddl_llamado").val(0)
            } else {
                $(this).attr("disabled", false);
            }
        });

        // Deshabilitar opciones de correos ya utilizadas
        $("#Ddl_correo option").each(function () {
            if ($(this).val() <= NumerototalCorreos) {
                $(this).attr("disabled", true);
                $("#Ddl_correo").val(0)
            } else {
                $(this).attr("disabled", false);
            }
        });

        if (NumerototalLlamadas == 3 && NumerototalCorreos == 3) {
            $("#btnguardar, #row-estado-fecha, #btnActualizar, #row-avisado-a").attr("hidden", true);
            $("#h5-log-registros").attr("hidden", false);
            $("#txt_causa").prop("readonly", true);
        }

        $('#txt_causa').val(item.OBS || '').prop('disabled', false); // Asegúrate de dejar habilitado
    });

    // Muestra el modal
    $("#mdlDet").modal("show");
}
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ ready @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

$("#Id_Conte").hide();

const currentDate = new Date();
const formattedDate = currentDate.toISOString().slice(0, 10);
$("#fecha, #fecha2").val(formattedDate);
// sacar párametro id que trae el id de tipo de atención hasheado, 0 para normal (todos) y 5 para sapu
const idParametro = getParameterByNameMaster("id");
// hash el id sapu para compararlo y ver si se entró al botón sapu o no
const idSapu = "ef2d127de37b942baad06145e54b0c619a1f22327b2ebbcfbec78f5564afe39d"; // await hashString("5"); // no sirve porque no hay https
const esSapu = idParametro === idSapu;
// si es sapu oculta los elementos que tenga la clase ocultar-en-sapu 
[...document.getElementsByClassName("ocultar-en-sapu")].forEach(element => element.hidden = esSapu);
let keepSecciones = [];
if (esSapu) {
    $("#span-titulo").text("Notificación Resultados SAPU")
    keepSecciones = [1, 5, 8, 10, 27, 28, 30];
}
console.log(keepSecciones);
await fillSeccionesAreas({ idSelect: "Ddl_Seccion", keep: keepSecciones });
const idPrevision = Galletas.getGalleta("ID_PREVISION") || 0;
await fillPrevisiones({ idSelect: "DdlPrevision", placeholder: true, idPrevision });

//await fillExamenesSinPrevision({ idSelect: "Ddl_Exam", placeholder: true });
await fillExamenesRlsAreaSeccPrev({ idSelect: "Ddl_Exam", placeholder: true, idRlsLs: $("#Ddl_Seccion").val(), keepRlsLs: keepSecciones });


//const idProcedencia = Galletas.getGalleta("USU_TM") || 0;
//await fillProcedencias({ idSelect: [], idProcedencia });

await fillTiposAtencion({ idSelect: "DdlTipoAtencion", idTipoAtencion: esSapu ? 5 : 0, remove: [5] });

Call_Data_Ddl_Stat();


// Función para mostrar u ocultar el div del llamado
function toggleLlamado() {
    if ($("#Ddl_Stat_aviso2").val() == 2) {
        $("#div_llamado").show();
    } else {
        $("#div_llamado").hide();
    }
}

// Función para mostrar u ocultar el div del correo
function toggleCorreo() {
    if ($("#Ddl_Stat_aviso2").val() == 3) {
        $("#div_correo").show();
    } else {
        $("#div_correo").hide();
    }
}

// Función para manejar el cambio de notificación
function handleNotificacionChange() {
    toggleLlamado();
    toggleCorreo();
}

// Función para inicializar la página
async function init() {
    // Llenar los selects
    await fillTiposCritico({ idSelect: "Ddl_Stat_aviso" });
    await fillTiposCritico({ idSelect: "Ddl_Stat_aviso2", placeholder: false });

    // Configurar eventos
    $("#Ddl_Stat_aviso2").on("change", handleNotificacionChange);

    // Configurar otros eventos y funciones
    $("#Ddl_llamado").on("change", function () {
        console.log("Valor de Ddl_llamado: ", $("#Ddl_llamado").val());
    });

    $("#Ddl_correo").on("change", function () {
        console.log("Valor de Ddl_correo: ", $("#Ddl_correo").val());
    });

    $("#Ddl_Seccion").on("change", async () => {
        await fillExamenesRlsAreaSeccPrev({ idSelect: "Ddl_Exam", placeholder: true, idRlsLs: $("#Ddl_Seccion").val(), keepRlsLs: keepSecciones });
    });

    $("#Btn_Buscar").on("click", Call_Data_Table);
    $("#Btn_Excel").on("click", Call_Export);
    $("#btnguardar").on("click", Call_Guardar);
    $("#btnFinalizar").on("click", Finalizar_Proceso);

    // Inicializar el estado de los divs basado en el valor actual
    handleNotificacionChange();
}

// Ejecutar la función de inicialización al cargar la página
$(document).ready(function () {
    init();
});
