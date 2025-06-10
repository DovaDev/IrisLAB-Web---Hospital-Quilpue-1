<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Lis_Pac_TDM.aspx.vb" Inherits="Presentacion.Lis_Pac_TDM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
 <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
<%-- Colocar esto para forzar el evento load --%>
<%@ OutputCache Location="None" NoStore="true" %>
<!-- Inicialización -->
<script type="module">
    import { habilitarBotonEditarAgenda } from "../js/es6-modules/EditarAgenda.js";
    import fillPrevisiones from "../js/es6-modules/Previsiones.js";

    import fillProcedencias from "../js/es6-modules/Procedencias.js";


    var global_id_atencion = 0

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
            "timeout": 20000,
            "success": this.success,
            "error": this.error
        });
    };
    let timer = 4000;
    let objAJAX_Voucher = new Class_AJAX();
    objAJAX_Voucher.url = "http://localhost:9990/Printer/Imp_Voucher_Compr_Ate";
    objAJAX_Voucher.success = (resp) => {
        console.log(`[ OK ] Impresión Voucher Atención`);
        console.log(resp);
        console.log(``);

        setTimeout(() => {
            objAJAX_Etiq.callback([
                Mx_AGH[0].ID_ATENCION
            ]);
        }, timer);

    };
    objAJAX_Voucher.error = (fail) => {
        console.log(`[ERROR] Impresión Voucher Atención`);
        console.log(fail);
        console.log(``);

        setTimeout(() => {
            objAJAX_Etiq.callback([
                Mx_AGH[0].ID_ATENCION
            ]);
        }, timer);
    };

    let objAJAX_Etiq = new Class_AJAX();
    objAJAX_Etiq.url = "http://localhost:9990/Printer/Imp_Etiquetas";
    objAJAX_Etiq.success = (resp) => {
        console.log(`[ OK ] Impresión Etiquetas`);
        console.log(resp);
        console.log(``);

        setTimeout(() => {
            objAJAX_LugarTM.callback([
                Mx_AGH[0].ID_ATENCION
            ]);
        }, timer);

    };
    objAJAX_Etiq.error = (fail) => {
        console.log(`[ERROR] Impresión Etiquetas`);
        console.log(fail);
        console.log(``);

        setTimeout(() => {
            objAJAX_LugarTM.callback([
                Mx_AGH[0].ID_ATENCION
            ]);
        }, timer);
    };

    let objAJAX_LugarTM = new Class_AJAX();
    objAJAX_LugarTM.url = "http://localhost:9990/Printer/Imp_Voucher_Lugar_TM";
    objAJAX_LugarTM.success = (resp) => {
        console.log(`[ OK ] Voucher LugarTM`);
        console.log(resp);
        console.log(``);

        var str_Error = "La impresión se ha completado exitosamente"
        $("#title").text("Solicitud de voucher");
        $("#button_modal").attr("class", "btn btn-success");
        $("#mError_AAH p").text(str_Error);
        $("#mError_AAH").modal();

    };
    objAJAX_LugarTM.error = (fail) => {
        console.log(`[ERROR] Impresión Etiquetas`);
        console.log(fail);
        console.log(``);

    };

    //---------------Declaración de JSON ajax call_ajax_ddl--------------------->

    var Mx_Ddl = [
        {
            "ID_PROCEDENCIA": "",
            "PROC_COD": "",
            "PROC_DESC": "",
            "ID_ESTADO": ""
        }
    ];

    // Ajax Ddl
    async function Call_AJAX_Ddl() {
        //Debug



        return await $.ajax({
            "type": "POST",
            "url": "Lis_Pac_TDM.aspx/Llenar_Ddl_LugarTM",
            //"data": Data_Par,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
                //Debug
                /*console.log(data.d); // Agrega esta línea*/
                Mx_Ddl = data.d;
                Fill_Ddl();
            },
            "error": data => {
                //Debug


            }
        });
    }

    //---------------Declaración de JSON ajax llenado de pacientes--------------------->
    var Mx_Dtt2 = [
        {
            "ID_PREINGRESO": 0,
            "PREI_NUM": 0,
            "PREI_FECHA": 0,
            "PAC_NOMBRE ": 0,
            "PAC_APELLIDO": 0,
            "ID_ESTADO": 0,
            "PAC_RUT": 0,
            "PREI_FEC_FLE": 0,
            "PREI_FECHA_PRE": 0,
            "ID_PACIENTE ": 0,
            "PREI_IID_ESTADO": 0,
            "EST_DESCRIPCION": 0,
            "ID_ATENCION": 0,
            "PROC_DESC": 0,
            "CANT_EXAM": 0,
            "ATE_NUM": 0,
            "DNI": 0,
            "PREI_HORA": 0
        }
    ];

    ///////////////////////
    ///////////////////////

    function Ajax_N_PACIENTE() {
        //Debug


        modal_show();
        var Data_Par_tabla = JSON.stringify({
            ID_PROCEDENCIA: $("#slct-procedencia").val(),
            ID_PREVISION: $("#slct-prevision").val(),
            desde: $("#desde").val(),
            hasta: $("#hasta").val(),
            ESTADO: $("#slct-estado").val()
        });
        console.log("Data_Par_tabla", Data_Par_tabla)
        var ajax_tabla = $.ajax({
            "type": "POST",
            //"url": "Lis_Pac_TDM.aspx/Llenar_PAC",
            "url": "Lis_Pac_TDM.aspx/IRIS_WEBF_BUSCA_LIS_PAC_TDM_TRAER_POR_ESTADO",
            "data": Data_Par_tabla,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data_tabla_paciente => {
                //Debug
                console.log("Data_Par_tabla", Data_Par_tabla)
                console.log("data_tabla_paciente", data_tabla_paciente)
                Mx_Dtt2 = data_tabla_paciente.d;
                //--------Llamamos al fill_datatable para llenar datos en la tabla--------->
                if (Mx_Dtt2.length != 0) {
                    Fill_DataTable2();
                    Hide_Modal();
                } else {
                    Hide_Modal();

                    $("#Div_Tabla").empty();
                    //-------mensaje bonito al usuario que no se encontro nada---------->
                    $("#Div_Tabla").append(
                        ("<div class='alert alert-danger alertas'><strong>Sin Resultados</strong>  </div>")
                    );
                    //------------Ocultamos el div qwerty------------->
                    $("#qwerty").hide();
                    //--------disabled true al boton excel---------->
                    $('#BtnAgenda').attr("disabled", true);
                }
            },
            "error": data_tabla_paciente => {
                Hide_Modal();


                //-------mensaje bonito al usuario que no se encontro nada---------->
                $("#Div_Tabla").append(
                    ("<div class='alert alert-danger alertas'><strong>Sin Resultados</strong>  </div>")
                );
                //------------Ocultamos el div qwerty------------->
                $("#qwerty").hide();
                //--------disabled true al boton excel---------->
                $('#BtnAgenda').attr("disabled", true);
            }
        });
    }

    function Ajax_Excel(TIPO = "Excel") {
        modal_show();


        var Data_Par = JSON.stringify({
            "DOMAIN_URL": location.origin,
            "ID_PROCEDENCIA": $("#slct-procedencia").val(),
            ID_PREVISION: $("#slct-prevision").val(),
            "desde": $("#desde").val(),
            "hasta": $("#hasta").val(),
            ESTADO: $("#slct-estado").val()
        });
        $(".block_wait").fadeIn(500);
        $.ajax({
            "type": "POST",
            "url": `Lis_Pac_TDM.aspx/${TIPO}`,
            "data": Data_Par,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": function (response) {
                var json_receiver = response.d;
                if (json_receiver != null) {
                    //Mx_Dtt_Excel = JSON.parse(json_receiver);
                    window.open(json_receiver, 'Download');
                    Hide_Modal();
                } else {
                    Hide_Modal();
                    $("#mError_AAH h4").text("Sin resultados");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("No se han encontrado resultados");
                    $("#mError_AAH").modal();
                    $("#Id_Conte").hide();
                }
                $(".block_wait").fadeOut(500);
            },
            "error": function (response) {
                var str_Error = response.responseJSON.ExceptionType + "\n \n";
                str_Error = response.responseJSON.Message;
                alert(str_Error);
            }
        });
    }

    function Ajax_Excel_Absentismo() {
        modal_show();
        var Data_Par = JSON.stringify({
            ID_PROCEDENCIA: $("#slct-procedencia").val(),
            ID_PREVISION: $("#slct-prevision").val(),
            fecha: $("#desde").val(),
            proc_desc: $("#slct-procedencia option:selected").text(),
            preve_desc: $("#slct-prevision option:selected").text(),
        });
        $(".block_wait").fadeIn(500);
        $.ajax({
            "type": "POST",
            "url": "Lis_Pac_TDM.aspx/Excel_Absentismo",
            "data": Data_Par,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": function (response) {
                var json_receiver = response.d;
                if (json_receiver != null) {
                    window.open(json_receiver, 'Download');
                    Hide_Modal();
                } else {
                    Hide_Modal();
                    $("#mError_AAH h4").text("Sin resultados");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("No se han encontrado resultados");
                    $("#mError_AAH").modal();
                    $("#Id_Conte").hide();
                }
                $(".block_wait").fadeOut(500);
            },
            "error": function (response) {
                var str_Error = response.responseJSON.ExceptionType + "\n \n";
                str_Error = response.responseJSON.Message;
                alert(str_Error);
            }
        });
    }
    //----Declaración de JSON ajax llenado de modal con el paciente------->

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
            "DNI": 0

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
            "ID_PER": 0
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
            "VIH": ""
        }]
    }
    ///////////////////
    ///////////////////
    function Ajax_modal_exa(preingreso_paciente, atencion_paciente, ATE_NUM_ATENCION_MODAL, soloTablaExamenes = false) {
        //cambiar de colores los input a normales
        $("#Interno").css({
            "border-color": "#868e96"
        });
        $("#Obate").css({
            "border-color": "#868e96"
        });
        $("#obtm").css({
            "border-color": "#868e96"
        });
        //Debug
        var Data_Par_modal = JSON.stringify({
            "ID": preingreso_paciente,
            "ID_ATE": atencion_paciente
        });
        $.ajax({
            "type": "POST",
            "url": "Lis_Pac_TDM.aspx/MODAL_PAC",
            "data": Data_Par_modal,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": Data_Par_modal_paciente => {

                //Debug
                console.log(Data_Par_modal)
                Mx_Detalle_ate = Data_Par_modal_paciente.d;


                //LLAMAMOS AL FILL MODAL
                llenarmodal(atencion_paciente, preingreso_paciente, ATE_NUM_ATENCION_MODAL);


                habilitarBotonEditarAgenda({ ver_hiv: false,  idElementoBrother: "cantidad", Mx_Detalle_ate, idAtencion: atencion_paciente, Ajax_modal_exa});


                const datos = { idElementoBrother: "cantidad", Mx_Detalle_ate, atencion_paciente, Ajax_modal_exa }
                console.log(datos)


                if (soloTablaExamenes) { console.log("recargar modal sin modal show"); return };


                // MOSTRAR EL MODAL
                $('#eModales33').modal('show');
            },
            "error": Data_Par_modal_paciente => {



            }
        });
    }

    //------Declaración de JSON ajax PARA GUARDAR Y CAMBIAR ESTADO AL PACIENTE------------>
    var Mx_AGH = [
        {
            "ID_ATENCION": 0,
            "Correlativo": 0
        }
    ];

    function ajax_grabar(ATE_PAC_ID, PRE_PAC_ID) {
        //OCULTAMOS EL MODAL DEL PACIENTE
        $('#eModales33').modal('hide');
        modal_show();

        //Debug
        var Data_Par44 = JSON.stringify({
            "ID_ate": ATE_PAC_ID,
            "id_pre": PRE_PAC_ID,
            "obs_TDM": $("#obtm").val(),
            "obs": $("#Obate").val(),
            "interno": 1,
            ID_USUARIO: Galletas.getGalleta("ID_USER")
        });

        $.ajax({
            "type": "POST",
            "url": "Lis_Pac_TDM.aspx/MODAL_update",
            "data": Data_Par44,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data_ATENDIDO => {
                //Debug


                Mx_AGH = data_ATENDIDO.d;

                //LLAMAMOS AL MODAL DE IMPRIMIR
                var IMPRIMIR = "";
                IMPRIMIR = "<p><strong>Nº de Atención: </strong> <strong style='font-size:20px;'>" + Mx_AGH[0].Correlativo + "</strong>\\n ¿Desea imprimir Etiquetas?</p>"
                $("#title2").text("Ingreso realizado");
                $("#bodyimpr").html("<p style='text-align: center;'><strong>Nº de Atención: </strong> <strong style='font-size:20px;'>" + Mx_AGH[0].Correlativo + "</strong></p> <p style='text-align: center;'>¿Desea imprimir Etiquetas?</p>");

                Hide_Modal();
                $("#MOdal_PAGO").modal('show');
                //LLAMAMOS A CARGAR LA TABLA


                Ajax_N_PACIENTE();
            },
            "error": data_ATENDIDO => {



            }
        });
    }


    function ajax_Actualizar(ATE_PAC_ID_5, PRE_PAC_ID_5) {
        //OCULTAMOS EL MODAL DEL PACIENTE
        $('#eModales33').modal('hide');
        modal_show();

        //Debug
        var Data_Par44 = JSON.stringify({
            "ID_ate": ATE_PAC_ID_5,
            "id_pre": PRE_PAC_ID_5,
            "obs_TDM": $("#obtm").val(),
            "obs": $("#Obate").val(),
            "interno": 1
        });

        $.ajax({
            "type": "POST",
            "url": "Lis_Pac_TDM.aspx/MODAL_Actualizar",
            "data": Data_Par44,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data_ATENDIDO => {
                //Debug


                //Mx_AGH = data_ATENDIDO.d;

                //LLAMAMOS AL MODAL DE IMPRIMIR
                //var IMPRIMIR = "";
                //IMPRIMIR = "<p><strong>Nº de Atención: </strong> <strong style='font-size:20px;'>" + Mx_AGH[0].Correlativo + "</strong>\\n ¿Desea imprimir Etiquetas?</p>"
                //$("#title2").text("Ingreso realizado");
                //$("#bodyimpr").html("<p style='text-align: center;'><strong>Nº de Atención: </strong> <strong style='font-size:20px;'>" + Mx_AGH[0].Correlativo + "</strong></p> <p style='text-align: center;'>¿Desea imprimir Etiquetas?</p>");

                //Hide_Modal();
                //$("#MOdal_PAGO").modal('show');
                //LLAMAMOS A CARGAR LA TABLA


                Ajax_N_PACIENTE();
            },
            "error": data_ATENDIDO => {



            }
        });
    }
    //--------FILL DROPDOWNLIST LUGARTM---------->
    function Fill_Ddl() {
        $("#slct-procedencia").empty();

        var procee = Galletas.getGalleta("USU_ID_PROC") || 0; // Esto ya está manejando null como 0
        console.log(procee);
        console.log(Mx_Ddl);

        // Cambiar la condición para verificar si procee es 0 o null
        if (procee == 0 || procee === null) {
            $("<option>", { value: 0, text: "Todo" }).appendTo("#slct-procedencia");
            Mx_Ddl.forEach(aaa => {
                $("<option>", {
                    "value": aaa.ID_PROCEDENCIA
                }).text(aaa.PROC_DESC).appendTo("#slct-procedencia");
            });
        } else {
            Mx_Ddl.forEach(aaa => {
                if (aaa.ID_PROCEDENCIA == procee) {
                    $("<option>", {
                        "value": aaa.ID_PROCEDENCIA
                    }).text(aaa.PROC_DESC).appendTo("#slct-procedencia");
                }
            });
        }
    }

    //-----Fill llenar datatable---->
    function Fill_DataTable2() {
        $("#Div_Tabla").empty();
        $("<table>", {
            "id": "DataTable_pac",
            "class": "table table-hover table-striped table-iris table-iris",
            "width": "100%",
            "cellspacing": "0"
        }).appendTo("#Div_Tabla");

        $("#DataTable_pac").append(
            $("<thead>"),
            $("<tbody>")
        );
        $("#DataTable_pac").attr("class", "table table-hover table-striped table-iris table-striped table-iris");

        $("#DataTable_pac thead").append(
            $("<tr>").append(

                $("<th>", { "class": "textoReducido text-center" }).text("Nº"),
                $("<th>", { "class": "textoReducido text-center" }).text("Hora"),
                $("<th>", { "class": "textoReducido text-left" }).text("Nombre Paciente"),
                $("<th>", { "class": "textoReducido text-center" }).text("Rut o D.N.I"),
                $("<th>", { "class": "textoReducido text-center" }).text("N° Pre-Ingreso"),
                $("<th>", { "class": "textoReducido text-center" }).text("N° Atención"),
                $("<th>", { "class": "textoReducido text-center" }).text("Procedencia"),
                $("<th>", { "class": "textoReducido text-center" }).text("Cant.Exa."),
                $("<th>", { "class": "textoReducido text-center" }).text("Estado")
                //$("<th>", { "class": "textoReducido text-center" }).text("")

            )
        );
        //Suma para rellenar datos de cantidades de paciente en espera, atendidos;
        var pac = 0;
        var espera = 0;
        var aten = 0;
        var Noasis = 0;

        for (let i = 0; i < Mx_Dtt2.length; i++) {
            $("#DataTable_pac tbody").append(
                $("<tr>", {
                    //llamamos a la funcion para rellenar el modal con datos del paciente seleccionado
                    id: Mx_Dtt2[i].ID_PREINGRESO,
                    "class": "textoReducido manito",
                    "padding": "1px !important",
                }).append(
                    $("<td>", { "align": "center", "class": "textoReducido" }).text(i + 1),
                    $("<td>", { "align": "center", "class": "textoReducido" }).text(Mx_Dtt2[i].PREI_HORA),
                    $("<td>", { "align": "left", "class": "textoReducido" }).text(Mx_Dtt2[i].PAC_NOMBRE + " " + Mx_Dtt2[i].PAC_APELLIDO),
                    $("<td>", { "align": "left", "class": "textoReducido" }).text(Mx_Dtt2[i].PAC_RUT == "" ? Mx_Dtt2[i].DNI : Mx_Dtt2[i].PAC_RUT),
                    $("<td>", { "align": "center", "class": "textoReducido" }).text(Mx_Dtt2[i].PREI_NUM),
                    $("<td>", { "align": "center", "class": "textoReducido" }).text(Mx_Dtt2[i].ATE_NUM),
                    $("<td>", { "align": "center", "class": "textoReducido" }).text(Mx_Dtt2[i].PROC_DESC),
                    $("<td>", { "align": "center", "class": "textoReducido" }).text(Mx_Dtt2[i].CANT_EXAM),
                    $("<td>", {
                        "align": "center",
                        "class": function () {
                            if (Mx_Dtt2[i].EST_DESCRIPCION == "ESPERA") {
                                return "textoReducido espera"
                            }
                            if (Mx_Dtt2[i].EST_DESCRIPCION == "ATENDIDO") {
                                return "textoReducido atendido"
                            }
                            if (Mx_Dtt2[i].EST_DESCRIPCION == "NO ASISTIO") {
                                return "textoReducido NOASISTIO"
                            }
                        }
                    }).text(Mx_Dtt2[i].EST_DESCRIPCION)
                )
            )
            if (Mx_Dtt2[i].EST_DESCRIPCION == "ESPERA") {
                espera++;
            }
            if (Mx_Dtt2[i].EST_DESCRIPCION == "ATENDIDO") {
                aten++;
            }
            if (Mx_Dtt2[i].EST_DESCRIPCION == "NO ASISTIO") {
                Noasis++;
            }
            pac++;
        }

        $("#DataTable_pac tbody tr").on("click", (e) => {
            const objetoClick = Mx_Dtt2.find(item => item.ID_PREINGRESO == e.currentTarget.id);
            Ajax_modal_exa(objetoClick.ID_PREINGRESO, objetoClick.ID_ATENCION, objetoClick.ATE_NUM);
        });


        $("#Paciente").text(pac);
        $("#ESPERA").text(espera);
        $("#ATEN").text(aten);
        $("#Examen").html(Mx_Dtt2.reduce((acc, cur) => acc + cur.CANT_EXAM, 0));
        $("#Noasis").text(Noasis);

        $("#DataTable_pac").DataTable({
            "searching": true, // Esto habilita la funcionalidad de búsqueda
            "iDisplayLength": 100,
            "info": false,
            "bPaginate": false,
            "bFilter": true, // Habilita el filtro
            "language": {
                "lengthMenu": "Mostrar: _MENU_",
                "zeroRecords": "No hay coincidencias",
                "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                "infoEmpty": "No hay concidencias",
                "infoFiltered": "(Se busco en _MAX_ registros )",
                "search": "<strong>Buscar: </strong>",
                "paginate": {
                    "previous": "Anterior",
                    "next": "Siguiente"
                }
            }
        });
    }

    //-----LLENADO DEL MODAL---->


    function llenarmodal(ATENCION_PACIENTE_ID, id_id_id_preingreso, AATE_NNUM_ATENCION) {


        $("#Interno").css({
            "border-color": "#868e96",
            "background": "#fefefe"
        });
        global_id_atencion = ATENCION_PACIENTE_ID;
        //vaciar los datos

        $("#rut").val("");
        $("#NOMBRE").val("");
        $("#ATENe").val("");
        $("#FNAC").val("");
        $("#Edad").val("");
        $("#Sex").val("");
        $("#FUR").val("");
        $("#Nacio").val("");
        $("#Telfijo").val("");
        $("#Celular").val("");
        $("#Ciudad").val("");
        $("#Comuna").val("");
        $("#Direc").val("");
        $("#Email").val("");
        $("#PerPAc").val("");
        $("#Obate").val("");
        $("#obtm").val("");
        $("#Prev").val("");

        //llenar datos
        if (Mx_Detalle_ate.proparra1[0].PAC_RUT == "") {
            $("#rut").val(Mx_Detalle_ate.proparra1[0].DNI);
        } else { $("#rut").val(Mx_Detalle_ate.proparra1[0].PAC_RUT); }

        $("#NOMBRE").val(Mx_Detalle_ate.proparra1[0].PAC_NOMBRE + " " + Mx_Detalle_ate.proparra1[0].PAC_APELLIDO);
        if (AATE_NNUM_ATENCION == "-") {
            $("#ATENe").val(Mx_Detalle_ate.proparra1[0].PREI_NUM);
        } else {
            $("#ATENe").val(AATE_NNUM_ATENCION);
        }
        let FechaREE = moment(Mx_Detalle_ate.proparra1[0].PAC_FNAC).format("DD-MM-YYYY");

        $("#FNAC").val(FechaREE);
        $("#Edad").val(Mx_Detalle_ate.proparra1[0].PREI_AÑO + " Años");
        $("#Sex").val(Mx_Detalle_ate.proparra1[0].SEXO_DESC);
        $("#FUR").val(Mx_Detalle_ate.proparra1[0].PREI_FUR);
        $("#Nacio").val(Mx_Detalle_ate.proparra1[0].NAC_DESC);
        $("#Telfijo").val(Mx_Detalle_ate.proparra1[0].PAC_FONO1);
        $("#Celular").val(Mx_Detalle_ate.proparra1[0].PAC_MOVIL1);
        $("#Ciudad").val(Mx_Detalle_ate.proparra1[0].CIU_DESC);
        $("#Comuna").val(Mx_Detalle_ate.proparra1[0].COM_DESC);
        $("#Direc").val(Mx_Detalle_ate.proparra1[0].PAC_DIR);
        $("#Email").val(Mx_Detalle_ate.proparra1[0].PAC_EMAIL);
        $("#PerPAc").val(Mx_Detalle_ate.proparra1[0].PAC_OBS_PERMA);
        $("#Obate").val(Mx_Detalle_ate.proparra1[0].PREI_OBS_FICHA);//Mx_Detalle_ate.proparra1[0].PREI_OBS_FICHA
        $("#obtm").val(Mx_Detalle_ate.proparra3[0].PREI_OBS_TM);//Mx_Detalle_ate.proparra3[0].PREI_OBS_TM
        $("#Prev").val(Mx_Detalle_ate.proparra3[0].PREVE_DESC);//
        $("#VIH").val(Mx_Detalle_ate.proparra3[0].VIH);//);//

        //if (Mx_Detalle_ate.proparra3[0].ATE_NUM_INTERNO == 0 || Mx_Detalle_ate.proparra3[0].ATE_NUM_INTERNO == "") {
        //    $("#Interno").val("");//
        //} else {
        //    $("#Interno").val(Mx_Detalle_ate.proparra3[0].ATE_NUM_INTERNO);//
        //}
        var cantidad = 0

        $("#Div_Tabla3").empty();
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
        $("#DataTable_pac2").attr("class", "table table-hover table-striped table-iris table-striped table-iris");

        $("#DataTable_pac2 thead").append(
            $("<tr>").append(
                $("<th>", { "class": "textoReducido" }).text("Codigo Fonasa"),
                $("<th>", { "class": "textoReducido" }).text("Descripcion"),
                $("<th>", { "class": "textoReducido" }).text("Dias Proceso"),
                $("<th>", { "class": "textoReducido" }).text(""),
            )
        );

        const idPreingreso = Mx_Detalle_ate.proparra3[0].ID_PREINGRESO;
        const estaAtendido = Mx_Dtt2.find(item => item.ID_PREINGRESO == idPreingreso).ID_ATENCION > 0


        const btnElimPrinter = (value = 0) => estaAtendido ? "" : `<button type='button' class='btn btn-danger' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;' value="${value}"><i class='fa fa-trash-o' aria-hidden='true'></i>&nbsp;Eliminar</button>`;
        for (let i = 0; i < Mx_Detalle_ate.proparra2.length; i++) {
            cantidad++;
            $("#DataTable_pac2 tbody").append($("<tr>", { "class": "textoReducido manito", "padding": "1px !important", }).append(
                $("<td>", { "align": "left", "class": "textoReducido" }).text(Mx_Detalle_ate.proparra2[i].CF_COD),
                $("<td>", { "align": "left", "class": "textoReducido td_val1" }).text(Mx_Detalle_ate.proparra2[i].CF_DESC),
                $("<td>", { "align": "left", "class": "textoReducido td_val2" }).text(Mx_Detalle_ate.proparra2[i].CF_DIAS),
                $("<td>", { "align": "left", "class": "textoReducido td_val2" }).html(btnElimPrinter(Mx_Detalle_ate.proparra2[i].ID_CODIGO_FONASA)),
            ))
        }

        $("#DataTable_pac2 tbody tr td button").on("click", async (e) => {
            const idUsuario = parseInt(Galletas.getGalleta("ID_USER"));

            if (!idUsuario) {
                window.location.href = '/'
                return;
            };

            const idPreingreso = Mx_Detalle_ate.proparra3[0].ID_PREINGRESO;
            const idAtencion = Mx_Detalle_ate.proparra3[0].ID_ATENCION;
            const ateNum = Mx_Detalle_ate.proparra3[0].ATE_NUM;

            const idCodigoFonasa = parseInt(e.currentTarget.value);

            const body = JSON.stringify({
                ID_PREINGRESO: idPreingreso,
                ID_USUARIO: idUsuario,
                ID_CODIGO_FONASA: idCodigoFonasa,
            });

            const cfDesc = Mx_Detalle_ate.proparra2.find(exa => exa.ID_CODIGO_FONASA == idCodigoFonasa).CF_DESC;
            const { isConfirmed: quitarExamen } = await Swal.fire({
                title: '¿Está seguro?',
                icon: 'question',
                html: `Se eliminará '<b>${cfDesc}</b>' del agendamiento.`,
                showCancelButton: true,
                confirmButtonText: 'Eliminar',
                confirmButtonColor: '#E92727',
                cancelButtonText: 'Cancelar',
                reverseButtons: false
            });
            if (!quitarExamen) return

            $.ajax({
                "type": "POST",
                "url": "/Agenda_Med/Lis_Pac_TDM.aspx/DeleteExamenfromPreingreso",
                "data": body,
                "contentType": "application/json; charset=utf-8",
                "dataType": "json",
                "success": (res) => {
                    Swal.fire({ icon: "success", title: "Éxito", html: "Examen eliminado con éxito." });
                    Ajax_modal_exa(idPreingreso, idAtencion, ateNum, true);
                }
            });

        })


        $("#cantidad").text("Cantidad de Exámenes: " + cantidad);



        // VERIFICAR SI EL PACIENTE ESTA ATENDIDO O NO
        if (ATENCION_PACIENTE_ID == 0 || ATENCION_PACIENTE_ID == "") {
            $("#btnobs").show();
            $("#btnpreingreso").hide();
            $("#btnpreingreso").show();
            $("#btnpreingreso").off("click");
            $("#btnpreingreso").click(() => {
                var loc = location.origin;
                window.location.href = loc + "/Agenda_Med/Ingreso_ate_avis_2.aspx" + "?ID_ATE" + "=" + id_id_id_preingreso + "&ID_PREV" + "=" + $("#slct-procedencia").val();
            });
            $("#btn_reimprimir").hide();
            $("#btn_actualizar").hide();
            //$("#btn_v_comp_ate").hide();
            //$("#btn_Eti").hide();
            //$("#btn_lugar_tm").hide();
        } else {
            $("#btnobs").hide();
            $("#btnpreingreso").hide();
            $("#btn_reimprimir").show();
            //$("#btn_v_comp_ate").show();
            //$("#btn_Eti").show();
            $("#btn_actualizar").show();
        }
    }


    // @@@@@@@@@@@@@@@@@@@ ready @@@@@@@@@@@@@@@@@@@
    // @@@@@@@@@@@@@@@@@@@ ready @@@@@@@@@@@@@@@@@@@
    // @@@@@@@@@@@@@@@@@@@ ready @@@@@@@@@@@@@@@@@@@
    // @@@@@@@@@@@@@@@@@@@ ready @@@@@@@@@@@@@@@@@@@
    //------ BOTON CLICK PARA ATENDER AL PACIENTE------->

    modal_show();


    $("#btnobs").click(function () {

        ajax_grabar(global_id_atencion, Mx_Detalle_ate.proparra1[0].ID_PREINGRESO);

    });

    $("#btn_actualizar").click(function () {
        var sum = 0;
        if ($("#Interno").val() != "") {
            sum++;
            $("#Interno").css({
                "border-color": "#868e96",
                "background": "#fefefe"
            });
        } else {
            $("#Interno").css({
                "border-color": "red",
                "background": "yellow"
            });
        }
        if (sum == 1) {
            if (Mx_Detalle_ate.proparra1.length != 0) {
                ajax_Actualizar(global_id_atencion, Mx_Detalle_ate.proparra1[0].ID_PREINGRESO);
            } else {

            }
        }
    });

    $("#button_modal_pago").click(function () {
        $('#eModales33').modal('hide');
        objAJAX_Voucher.callback([
            Mx_AGH[0].ID_ATENCION
        ]);
    });


    $("#btn_reimprimir").click(function () {
        $('#eModales33').modal('hide');
        var dataParam = JSON.stringify([
            global_id_atencion
        ]);



        var REE = $.ajax({
            "type": "POST",
            "url": "http://localhost:9990/Printer/Imp_Voucher_Compr_Ate",
            "data": dataParam,
            "contentType": "application/json;  charset=utf-8",
            "contentType": "text/plain;  charset=utf-8",
            "dataType": "json",
            "timeout": 20000,
            "success": function (response) {





                var dataParam2 = JSON.stringify([
                    global_id_atencion
                ]);

                var REE2 = $.ajax({
                    "type": "POST",
                    "url": "http://localhost:9990/Printer/Imp_Etiquetas",
                    "data": dataParam2,
                    "contentType": "application/json;  charset=utf-8",
                    "contentType": "text/plain;  charset=utf-8",
                    "dataType": "json",
                    "timeout": 90000,
                    "success": function (response) {






                        var dataParam3 = JSON.stringify([
                            global_id_atencion
                        ]);




                        var REE3 = $.ajax({
                            "type": "POST",
                            "url": "http://localhost:9990/Printer/Imp_Voucher_Lugar_TM",
                            "data": dataParam3,
                            "contentType": "application/json;  charset=utf-8",
                            "contentType": "text/plain;  charset=utf-8",
                            "dataType": "json",
                            "timeout": 20000,
                            "success": function (response) {




                                var str_Error = "La impresión se ha completado exitosamente"
                                $("#title").text("Solicitud de voucher");
                                $("#button_modal").attr("class", "btn btn-success");
                                $("#mError_AAH p").text(str_Error);
                                $("#mError_AAH").modal();

                            },
                            "error": function (response) {





                            }
                        });
                    },
                    "error": function (response) {




                    }
                });
            },
            "error": function (response) {


                var str_Error = "No se a detectado ninguna interface de impresión abierta. Abra IRISLAB_PRINT" // o de lo contrario descargelo AQUI
                $("#title").text("Solicitud de voucher");
                $("#button_modal").attr("class", "btn btn-success");
                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();

            }
        });

    });


    //A un div externo, colocamos mensaje bonito para el cliente>
    $("#Div_Tabla").append(
        ("<div class='alert alert-success alertas'><strong>Por favor seleccione una Fecha y Procedencia</strong>  </div>")
    );
    //-----iniciamos una varible para dar Date actual al input------>         
    var f = moment().format("DD-MM-YYYY");
    $("#desde").val(f);
    $("#hasta").val(f);

    //-----------------iniciamos el boton de excel  disabled------------------------->
    $('#BtnAgenda').attr("disabled", false);

    //-------------Funcion al boton buscar --------------------->
    $("#Btnbuscar").click(function () {
        //--------------asignamos a los datos superiores de la table valores 0--------->
        $("#Paciente").text(0);
        $("#ESPERA").text(0);
        $("#ATEN").text(0);
        $("#Examen").text(0);
        //-------------habilitamos el boton del excel--------------------------->
        if ($("#slct-procedencia").val() == 222) {
            $('#BtnAgenda').attr("disabled", true);
        } else {
            $('#BtnAgenda').attr("disabled", false);
        }
        //------------llamamos al ajax para ver los pacientes--------------->
        Ajax_N_PACIENTE();

    });

    $("#Btnexcel").click(function () {
        Ajax_Excel();
    });
    $("#btn-excel-con-examen").click(function () {
        Ajax_Excel("Excel_Con_Examenes");
    });
    $("#btn-excel-absentismo").click(async () => {

        const hidePopupAbsentismoLisPac = parseInt(localStorage.getItem('hidePopupAbsentismoLisPac')) || 0;

        if (hidePopupAbsentismoLisPac) {
            Ajax_Excel_Absentismo();
            return;
        }

        const { isConfirmed: confirmado, value: inputValue } = await Swal.fire({
            title: 'Información',
            icon: 'info',
            html: 'La estadística de Ausentismo se generará para un mes entero.<br/><br/> El mes que se usará es el que está seleccionado actualmente en el filtro de fecha "Desde".',
            input: 'checkbox',
            inputPlaceholder: 'Entiendo, no mostrar este mensaje de nuevo.',
            showCancelButton: true,
            confirmButtonText: 'Generar Archivo',
            confirmButtonColor: '#3ca513',
            cancelButtonText: 'Cancelar',
            reverseButtons: false
        });
        if (!confirmado) return

        localStorage.setItem('hidePopupAbsentismoLisPac', inputValue);
        Ajax_Excel_Absentismo();


    });

    $('#datetimepicker1, #datetimepicker2').datetimepicker({
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
        useCurrent: true,
    });

    //-------llamamos al ajax para llenar el DdL de previsión---------> previsión??????????????
    await Call_AJAX_Ddl();
    const idPrevisionUser = Galletas.getGalleta("USU_PREV") || 0;
    await fillPrevisiones({ idSelect: 'slct-prevision', placeholder: true, placeholderText: "Todo", idPrevision: idPrevisionUser });
    Hide_Modal();

</script>
<style>
    .alertas {
        margin-top: 90px;
        text-align: center;
    }

    .manito {
        cursor: pointer;
    }

    .textoReducido {
        font-size: 10px;
    }

    .textoReducido2 {
        font-size: 14px;
    }

    .ancho-columna {
        height: 10%;
        padding: -35px;
    }

    .borderaaa {
        padding: .3rem;
        text-align: center;
    }

    .highlights {
        /*width: 710px;*/
        max-height: 70vh; /* Ancho y alto fijo */
        overflow: auto; /* Se oculta el contenido desbordado */
    }

    .highlights2 {
        width: 710px;
        height: 434px; /* Ancho y alto fijo */
        overflow: auto; /* Se oculta el contenido desbordado */
    }

    .highlights3 {
        width: 100%;
        max-height: 170px; /* Ancho y alto fijo */
        overflow: auto; /* Se oculta el contenido desbordado */
    }

    .topbuttom {
        display: block;
        height: 80px;
        width: 100%;
    }

    .textbot {
        display: block;
        height: 22px;
        width: 100%;
    }

    .form-control:disabled {
        background-color: #ffffff !important;
        cursor: default !important;
    }

    .textbotLeft {
        display: block;
        height: 28px;
        width: 100%;
    }

    .NOASISTIO {
        background-color: #e04747 !important;
        color: white !important;
    }

    .glyphicon {
        display: inline-block;
        font-family: FontAwesome;
        font-style: normal;
        font-weight: normal;
        line-height: 1;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }

    .glyphicon-arrow-left:before {
        content: "\f053";
    }

    .glyphicon-arrow-right:before {
        content: "\f054";
    }

    .grid-antecedentes {
        display: grid;
        grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
        gap: 1rem;
        align-items: end;
        grid-auto-flow: dense;
        margin-bottom: 1rem;
    }
    .form-group{
        margin-bottom: 0px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
     <!-- Modal -->
 <div id="MOdal_PAGO" class="modal fade" role="dialog">
     <div class="modal-dialog ml-xl-auto">

         <!-- Modal content-->
         <div class="modal-content">
             <div class="modal-header">
                 <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                 <h4 id="title2" class="modal-title">Error</h4>
             </div>
             <div id="bodyimpr" class="modal-body">
                 <p></p>
             </div>
             <div class="modal-footer">
                 <button type="button" id="b" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                 <button type="button" id="button_modal_pago" class="btn btn-print" data-dismiss="modal"><i class="fa fa-fw fa-print mr-2"></i>Imprimir</button>
             </div>
         </div>
     </div>
 </div>
 <!-- Modal -->
 <div id="mError_AAH" class="modal fade" role="dialog">
     <div class="modal-dialog ml-xl-auto">

         <!-- Modal content-->
         <div class="modal-content">
             <div class="modal-header">
                 <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                 <h4 id="title" class="modal-title">Error</h4>
             </div>
             <div class="modal-body">
                 <p>AAAHAHHHHH</p>
             </div>
             <div class="modal-footer">
                 <button type="button" id="button_modal" class="btn btn-danger" data-dismiss="modal">Aceptar</button>
             </div>
         </div>
     </div>
 </div>

 <%--Modal detalle paciente--%>
 <div class="modal fade" id="eModales33" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
     <div class="modal-dialog modal-lg" role="document" style="max-width: 90vw !important;">
         <div class="modal-content p-3">
             <div class="modal-body">
                 <div class="card border-bar mb-3">
                     <div class="card-header bg-bar text-center">
                         <h5 id="xxxxxx" class="m-0">Antecedentes de Agendamiento</h5>
                     </div>
                     <div class="card-body">
                         <div class="row">
                             <div class="col-md-12">
                                 <div class="row">
                                     <div class="col-sm">
                                         <label class="textoReducido2">RUT o D.N.I:</label>
                                         <input type='text' id="rut" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                     </div>

                                     <div class="col-sm">
                                         <label class="textoReducido2">Nombre:</label>
                                         <input type='text' id="NOMBRE" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                     </div>
                                     <div class="col-sm">
                                         <label class="textoReducido2">N°Atención:</label>
                                         <input type='text' id="ATENe" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                     </div>
                                     <div class="col-sm">
                                         <label class="textoReducido2">F.Nacimiento:</label>
                                         <input type='text' id="FNAC" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                     </div>

                                     <div class="col-sm">
                                         <label class="textoReducido2">Edad:</label>
                                         <input type='text' id="Edad" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                     </div>

                                 </div>
                                 <div class="row">
                                     <div class="col-sm">
                                         <label class="textoReducido2">Sexo:</label>
                                         <input type='text' id="Sex" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                     </div>
                                     <div class="col-sm">
                                         <label for="checkBox2" class="textoReducido2">F.U.R:</label>
                                         <input type='text' id="FUR" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                     </div>
                                     <div class="col-sm">
                                         <label class="textoReducido2">Nacionalidad:</label>
                                         <input type='text' id="Nacio" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                     </div>
                                     <div class="col-sm">
                                         <label class="textoReducido2">Tel. Fijo:</label>
                                         <input type='text' id="Telfijo" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                     </div>
                                     <div class="col-sm">
                                         <label class="textoReducido2">Celular:</label>
                                         <input type='text' id="Celular" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                     </div>


                                 </div>
                                 <div class="row" style="margin-bottom: 10px;">
                                     <div class="col-sm">
                                         <label class="textoReducido2">Ciudad:</label>
                                         <input type='text' id="Ciudad" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                     </div>
                                     <div class="col-sm">
                                         <label class="textoReducido2">Comuna:</label>
                                         <input type='text' id="Comuna" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                     </div>
                                     <div class="col-sm">
                                         <label class="textoReducido2">Dirección:</label>
                                         <input type='text' id="Direc" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                     </div>
                                     <div class="col-sm">
                                         <label class="textoReducido2">Email:</label>
                                         <input type='text' id="Email" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                     </div>
                                     <div class="col-sm">
                                         <label class="textoReducido2">Observaciones Permanentes:</label>
                                         <input type='text' id="PerPAc" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                     </div>
                                 </div>
                                 <hr />
                                 <div class="row" style="margin-bottom: 10px;">
                                     <%--                                        <div class="col-sm">
                                         <label class="textoReducido2">N° Interno:</label>
                                         <input type='text' id="Interno" class="form-control textoReducido2 borderaaa" />
                                     </div>--%>
                                     <div class="col-sm">
                                         <label class="textoReducido2">V.I.H.:</label>
                                         <input type='text' id="VIH" class="form-control textoReducido2 borderaaa" />
                                     </div>
                                     <div class="col-sm">
                                         <label class="textoReducido2">Observaciones de la atencion:</label>
                                         <input type='text' id="Obate" class="form-control textoReducido2 borderaaa" />
                                     </div>
                                     <div class="col-sm">
                                         <label class="textoReducido2">Observaciones de toma de muestra:</label>
                                         <input type='text' id="obtm" class="form-control textoReducido2 borderaaa" />
                                     </div>
                                     <div class="col-sm">
                                         <label class="textoReducido2">Prevision:</label>
                                         <input type='text' id="Prev" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                     </div>
                                 </div>
                             </div>
                         </div>
                     </div>
                 </div>
                 <div class="card border-bar">
                     <div class="card-header bg-bar text-center">
                         <h5 class="m-0">Listado de exámenes</h5>
                     </div>
                     <div class="card-body">
                         <div id="Div_Tabla3" style="width: 100%;" class="highlights3"></div>
                     </div>
                 </div>
             </div>

             <div class="modal-footer border-top-0">
                 <h5 id="cantidad"></h5>
                 <button type="button" class="btn btn-success" id="btnobs"><i class="fa fa-fw fa-check mr-2"></i>Atender</button>
                 <%--<button type="button" class="btn btn-info" id="btnpreingreso"><i class="fa fa-fw fa-check mr-2"></i>Ir Atención</button>--%>
                 <button type="button" class="btn btn-print" id="btn_reimprimir"><i class="fa fa-fw fa-print mr-2"></i>Imprimir</button>
                 <%--      <button type="button" class="btn btn-primary" id="btn_actualizar"><i class="fa fa-fw fa-print mr-2"></i>Actualizar Datos</button>--%>
                 <div>
                 </div>
                 <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
             </div>
         </div>
     </div>
 </div>






 <!-- Breadcrumbs -->

 <div class="card border-bar">
     <div class="card-header bg-bar">
         <h5 style="text-align: center; padding: 5px;">
             <i class="fa fa-bookmark-o"></i>
             Listado de pacientes
         </h5>
     </div>
     <div class="card-body">

         <div class="grid-antecedentes">
             <div class="form-group">
                 <label for="desde">Desde:</label>
                 <div class='input-group date' id='datetimepicker1'>
                     <input type='text' id="desde" class="form-control" readonly="true" placeholder="Fecha" />
                     <span class="input-group-addon">
                         <i class="fa fa-calendar"></i>
                     </span>
                 </div>
             </div>

             <div class="form-group">
                 <label for="hasta">Hasta:</label>
                 <div class='input-group date' id='datetimepicker2'>
                     <input type='text' id="hasta" class="form-control" readonly="true" placeholder="Fecha" />
                     <span class="input-group-addon">
                         <i class="fa fa-calendar"></i>
                     </span>
                 </div>
             </div>

             <div class="form-group">
                 <label for="slct-procedencia">Procedencia:</label>
                 <select id="slct-procedencia" class="form-control"></select>
             </div>


             <div class="form-group">
                 <label for="slct-prevision">Previsión:</label>
                 <select id="slct-prevision" class="form-control"></select>
             </div>

             <div class="form-group">
                <label for="slct-estado">Estado:</label>
                <select id="slct-estado" class="form-control">
                     <option value="1">TODO</option>
                    <option value="2">ATENDIDO</option>
                    <option value="3">ESPERA</option>
                    <option value="4">NO ASISTIO</option>
                </select>
            </div>
            </div>

             <button id="Btnbuscar" type="button" class="btn btn-buscar"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
             <button id="Btnexcel" type="button" class="btn btn-success"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
             <button hidden="" id="btn-excel-con-examen" type="button" class="btn btn-success"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Detalle</button>
             <button hidden="" id="btn-excel-absentismo" type="button" class="btn btn-success"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Ausentismo</button>

         </div>



         <div class="row">
             <div class="col-lg-12">
                 <div class="row">
                     <div class="col-sm-12">
                         <div class="row">
                             <div class="col-sm-12">
                                 <p style="font-size: 13px;" class="textbot"><strong>Antecedentes de Agendamiento</strong></p>
                                 <div class="row">
                                     <div class="col-sm textbot">
                                         <p style="font-size: 12px;"><strong>N° de Pacientes:</strong></p>
                                     </div>
                                     <div class="col-sm textbot">
                                         <p id="Paciente" style="font-size: 12px;">0</p>
                                     </div>
                                     <div class="col-sm textbot">
                                         <p style="font-size: 12px;"><strong>N° de Exámenes:</strong></p>
                                     </div>
                                     <div class="col-sm textbot">
                                         <p id="Examen" style="font-size: 12px;">0</p>
                                     </div>
                                     <div class="col-sm textbot">
                                         <p style="font-size: 12px;"><strong>N° de Atendidos:</strong></p>
                                     </div>
                                     <div class="col-sm textbot">
                                         <p id="ATEN" style="font-size: 12px;">0</p>
                                     </div>

                                     <div class="col-sm textbot">
                                         <p style="font-size: 12px;"><strong>N° de No Asistio:</strong></p>
                                     </div>
                                     <div class="col-sm textbot">
                                         <p id="Noasis" style="font-size: 12px;">0</p>
                                     </div>
                                     <div class="col-sm textbot">
                                         <p style="font-size: 12px;"><strong>N° En Espera:</strong></p>
                                     </div>
                                     <div class="col-sm textbot">
                                         <p id="ESPERA" style="font-size: 12px;">0</p>
                                     </div>
                                 </div>
                             </div>
                         </div>
                     </div>
                 </div>
                 <div class="row">
                     <div class="col-lg-12">
                         <div id="Div_Tabla" style="width: 100%;" class="highlights">
                         </div>
                     </div>
                 </div>
             </div>
         </div>
     </div>
 

</asp:Content>

