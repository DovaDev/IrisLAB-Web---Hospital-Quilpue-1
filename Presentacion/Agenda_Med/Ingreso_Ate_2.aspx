<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Ingreso_Ate_2.aspx.vb" Inherits="Presentacion.Ingreso_Ate_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="../js/Deep-Copy.js"></script>
    <%--<script src="js/Deep-Copy.js"></script>--%>
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>

        <script type="text/javascript">

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
    </script>

    <script>
        //Focusear los checkbox cuando el modal de Agregar exámenes es mostrado
        $(document).ready(() => {
            $("#eModal2").on("shown.bs.modal", (me) => {
                let obj_target = $(me.currentTarget).find("table tbody tr:first td input[type=checkbox]");
                obj_target.focus();
            });

        });
    </script>

    <script>

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
                "timeout": 20000,
                "success": this.success,
                "error": this.error
            });
        };

        let timer = 4000;
        let objAJAX_Atenc = new Class_AJAX();
        objAJAX_Atenc.url = "http://localhost:9990/Printer/Imp_Voucher_Compr_Ate";
        objAJAX_Atenc.success = (resp) => {

            (`[ OK ] Impresión Voucher Atención`);
            console.log(resp);
            console.log(``);

            let str_Error = `La impresión de Comprobante de Atención se ha completado exitosamente, `;
            str_Error += `iniciando Impresión de Etiquetas.`;
            $("#title").text("Solicitud de Voucher");
            $("#button_modal").attr("class", "btn btn-success");
            $("#mError_AAH p").text(str_Error);
            $("#mError_AAH").modal(`show`);

            setTimeout(() => {
                $("#mError_AAH").modal(`hide`);

                objAJAX_Etiq.callback([
                    Mx_Dt023.ID_Atencion
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
            $("#mError_AAH").modal(`show`);

            setTimeout(() => {
                $("#mError_AAH").modal(`hide`);

                objAJAX_Proc.callback([
                    Mx_Dt023.ID_Atencion
                ]);
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

            let str_Error = `La impresión de Voucher Lugar TM se ha completado exitosamente. `;
            str_Error += `Impresiones Finalizadas.`;
            $("#title").text("Impresiones Finalizadas");
            $("#button_modal").attr("class", "btn btn-success");
            $("#mError_AAH p").text(str_Error);
            $("#mError_AAH").modal(`show`);

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

            $("#button_modal_pago").click(function () {


                if (Mx_Dt023.length != 0) {

                    objAJAX_Atenc.callback([
                         Mx_Dt023.ID_Atencion
                    ]);
                }
            });



            $("#Procedencia").change(function () {
                Ajax_DataTable();
            });
            //$("#Div_Tabla").hide();

            Ajax_DL_SEXO();
            Ajax_DL_NAC();
            Ajax_Ciudad();
            Call_AJAX_Ddl();
            Ajax_DL_programa();
            Ajax_DL_sec();
            Ajax_DL_TP_ATE();
            Ajax_DL_orden_ate();
            Ajax_DL_prevision();
            Ajax_DL_DOC();
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
                Mx_Dtt_examcof =[];
                $("#DataTable_pac2 tbody").empty();
                add_row();
                verrut = 0;
                Mx_Dtt2 = [];
                $("#DdlDiagnostico").val(1);
                $("#DdlDiagnostico2").val(1);
                $("#obdser").val("");
                $("#Doctor").val(1);
                $("#obs_ate").val("");
                $("#Autorizo_retirar").val("");
                $("#PrioridadTM").val(1);
                $("#NumeroClinico").val("");
                $("#Prevision").val(263);
                $("#TipoAtencion").val(1);
                $("#sub_atencion").val(0);
                $("#Programa").val(1);
                $("#Sector").val(1);
                $("#ddl_new_vih").val(0);
                $("#ddl_new_vih").css({ "border-color": "#ccc" });
                $("#ddl_new_vih").parent().css({ "color": "#212529" });
                $("#vih").val(0);
                $("#vih").css({ "border-color": "#ccc" });
                $("#vih").parent().css({ "color": "#212529" });
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
            $("#Prevision").change(function () {
                Mx_Dtt_exam02 = [];
                Mx_Dtt_examcof = [];
                Ajax_DataTable_examen02();
                $("#DataTable_pac2 tbody").empty();
                add_row();
            });



            $("#BtnSaveAll").click(function () {
                var sum = 0;
                var actuuu = 0;
                var actuuu2 = 0;

                if ($("#Nom").val() == "") {

                    $("#Nom").css({
                        "border-color": "red"
                    });
                    $("#Nom").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Nom").css({
                        "border-color": "#ccc"
                    });
                    $("#Nom").parent().css({
                        "color": "#212529"
                    });
                }

                if ($("#Interno").val() == "") {

                    $("#Interno").css({
                        "border-color": "red"
                    });
                    $("#Interno").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Interno").css({
                        "border-color": "#ccc"
                    });
                    $("#Interno").parent().css({
                        "color": "#212529"
                    });
                }


                if ($("#Ape").val() == "") {

                    $("#Ape").css({
                        "border-color": "red"
                    });
                    $("#Ape").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Ape").css({
                        "border-color": "#ccc"
                    });
                    $("#Ape").parent().css({
                        "color": "#212529"
                    });
                }

                if ($("#Edad").val() == "") {

                    $("#fecha").css({
                        "border-color": "red"
                    });
                    $("#fecha").parent().parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#fecha").css({
                        "border-color": "#ccc"
                    });
                    $("#fecha").parent().parent().css({
                        "color": "#212529"
                    });
                }

                if ($("#sex").val() == 0) {

                    $("#sex").css({
                        "border-color": "red"
                    });
                    $("#sex").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#sex").css({
                        "border-color": "#ccc"
                    });
                    $("#sex").parent().css({
                        "color": "#212529"
                    });
                }

                if ($("#Nacio").val() == 0) {

                    $("#Nacio").css({
                        "border-color": "red"
                    });
                    $("#Nacio").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Nacio").css({
                        "border-color": "#ccc"
                    });
                    $("#Nacio").parent().css({
                        "color": "#212529"
                    });
                }
                if ($("#Cuidad").val() == 0) {

                    $("#Cuidad").css({
                        "border-color": "red"
                    });
                    $("#Cuidad").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Cuidad").css({
                        "border-color": "#ccc"
                    });
                    $("#Cuidad").parent().css({
                        "color": "#212529"
                    });
                }
                if ($("#Comuna").val() == 0) {

                    $("#Comuna").css({
                        "border-color": "red"
                    });
                    $("#Comuna").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Comuna").css({
                        "border-color": "#ccc"
                    });
                    $("#Comuna").parent().css({
                        "color": "#212529"
                    });
                }

                if ($("#sub_atencion").val() == 0) {

                    $("#sub_atencion").css({
                        "border-color": "red"
                    });
                    $("#sub_atencion").parent().css({
                        "color": "red"
                    });
                } else {
                    if ($("#sub_atencion").val() == 1) {
                        if ($("#Total").val() == 0) {
                            $("#sub_atencion").css({
                                "border-color": "red"
                            });
                            $("#sub_atencion").parent().css({
                                "color": "red"
                            });
                        } else {
                            sum += 1;
                            $("#sub_atencion").css({
                                "border-color": "#ccc"
                            });
                            $("#sub_atencion").parent().css({
                                "color": "#212529"
                            });
                        }
                    }
                    if ($("#sub_atencion").val() == 2) {
                        if ($("#Actuales").val() == 0) {
                            $("#sub_atencion").css({
                                "border-color": "red"
                            });
                            $("#sub_atencion").parent().css({
                                "color": "red"
                            });
                        } else {
                            sum += 1;
                            $("#sub_atencion").css({
                                "border-color": "#ccc"
                            });
                            $("#sub_atencion").parent().css({
                                "color": "#212529"
                            });
                        }



                    }
                    if ($("#sub_atencion").val() == 3) {

                        if ($("#Disponibles").val() == 0) {
                            $("#sub_atencion").css({
                                "border-color": "red"
                            });
                            $("#sub_atencion").parent().css({
                                "color": "red"
                            });
                        } else {
                            sum += 1;
                            $("#sub_atencion").css({
                                "border-color": "#ccc"
                            });
                            $("#sub_atencion").parent().css({
                                "color": "#212529"
                            });
                        }
                    }
                    if ($("#sub_atencion").val() == 4) {


                        sum += 1;
                        $("#sub_atencion").css({
                            "border-color": "#ccc"
                        });
                        $("#sub_atencion").parent().css({
                            "color": "#212529"
                        });
                    }
                    if ($("#sub_atencion").val() == 5) {


                        sum += 1;
                        $("#sub_atencion").css({
                            "border-color": "#ccc"
                        });
                        $("#sub_atencion").parent().css({
                            "color": "#212529"
                        });
                    }
                } 
                for (xxx = 0; xxx < Mx_Dtt_examcof.length; xxx++) {
                    console.log("oa");
                    //IF RPR, MHTP, VDRL o VIH
                    if (Mx_Dtt_examcof[xxx].ID_CODIGO_FONASA == 1021 || Mx_Dtt_examcof[xxx].ID_CODIGO_FONASA == 315 || Mx_Dtt_examcof[xxx].ID_CODIGO_FONASA == 453) {
                        actuuu = 1;
                    }
                    //VIH
                    if (Mx_Dtt_examcof[xxx].ID_CODIGO_FONASA == 364) {
                        actuuu2 = 1;
                    }
                }
                console.log("actuuu: " + actuuu );
                if (actuuu2 == 1) {
                    if ($("#ddl_new_vih").val() == 0) {
                        console.log("deberia ponerse rojo new !");

                        $("#ddl_new_vih").css({
                            "border-color": "red"
                        });
                        $("#ddl_new_vih").parent().css({
                            "color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#ddl_new_vih").css({
                            "border-color": "#ccc"
                        });
                        $("#ddl_new_vih").parent().css({
                            "color": "#212529"
                        });
                    }                    
                }
                else{
                    sum += 1;
                }

                if (actuuu == 1) {
                    if ($("#vih").val() == 0) {
                        console.log("deberia ponerse rojo sifilis!");
                        $("#vih").css({
                            "border-color": "red"
                        });
                        $("#vih").parent().css({
                            "color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#vih").css({
                            "border-color": "#ccc"
                        });
                        $("#vih").parent().css({
                            "color": "#212529"
                        });
                    }
                } else {
                    sum += 1;
                }
                
                if (sum == 11) {

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
                $("#ulol").empty();
                $('#eModal2').modal('show');
                Fill_DataTable_exam02();

            });



            ///llenado tabla con modal  a  atabla principal
            $("#btnguardar").click(function () {
                selected = new Array();
                $(".pp_order input:checkbox:checked").each(function () {
                //$(".pp_order").each(function () {
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
    </script>
    <script>
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
            var Data_Par_modal = JSON.stringify({
                "ID": $("#Naten").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate_2.aspx/MODAL_PAC",
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
        function llenarmodal() {

            if (Mx_Detalle_ate.proparra2.length > 0) {
                $("#Avis").val(Mx_Detalle_ate.proparra2[0].ATE_NUM_AVIS);
            }
            let FechaREE = moment(Mx_Detalle_ate.proparra1[0].PAC_FNAC).format("YYYY-MM-DD");
            $("#rut").val(Mx_Detalle_ate.proparra1[0].PAC_RUT);
            $("#Nom").val(Mx_Detalle_ate.proparra1[0].PAC_NOMBRE);
            $("#Ape").val(Mx_Detalle_ate.proparra1[0].PAC_APELLIDO);
            $("#fecha").val(FechaREE);
            $("#Edad").val(`${Mx_Detalle_ate.proparra1[0].PREI_AÑO} años`);
            $("#telfijo").val(Mx_Detalle_ate.proparra1[0].PAC_FONO1);
            $("#Celular").val(Mx_Detalle_ate.proparra1[0].PAC_MOVIL1);
            Ajax_DataTable_examen02();
            $("#Programa").val(Mx_Detalle_ate.proparra3[0].ID_PROGRAMA);
            $("#Sector").val(Mx_Detalle_ate.proparra3[0].ID_SECTOR);
            $("#Prevision").val(Mx_Detalle_ate.proparra3[0].ID_PREVE);
            $("#Doctor").val(Mx_Detalle_ate.proparra3[0].ID_DOCTOR);
            Ajax_DLdiag(Mx_Detalle_ate.proparra3[0].ID_DIAGNOSTICO);
            Ajax_DLdiag2(Mx_Detalle_ate.proparra3[0].ID_DIAGNOSTICO2);
            $("#sub_atencion").val(Mx_Detalle_ate.proparra3[0].Sub_atencion);
            var obj_RUT2 = Valid_RUT($("#rut").val());
            $("#rut").val(obj_RUT2.Format);
            $("#Nacio").val(Mx_Detalle_ate.proparra1[0].id_Nacionalidad);
            if (Mx_Detalle_ate.proparra1[0].SEXO_DESC == 'Masculino') {
                $("#sex").val(1);
            } else {

                $("#sex").val(2);
            }
            var aaa = {};
            if (Mx_Detalle_ate.proparra2.length > 0) {
                Mx_Dtt_examcof.length = 0;
                for (p = 0; p < Mx_Detalle_ate.proparra2.length; p++) {
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

                fill_llenado_tabla();
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
        function Ajax_guardar() {
            modal_show();
            var fur = 0;
            var OB = "";
            var ID = 0;
            var ed = (function () {
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
                total = String(edad);
                if (ahora_dia > dia) {
                    dias = ahora_dia - dia;
                    total = String(edad);
                }
                if (ahora_dia < dia) {
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                    total = String(edad);
                }
                return total;

            }());
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
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
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
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                    total = String(dias);
                }
                return total;

            }());
            var TOTAL = 0;
            ids = new Array();
            var numeritocliniquito = 0;
            if ($("#NumeroClinico").val() == "") {
                numeritocliniquito = 0;
            } else {
                numeritocliniquito = $("#NumeroClinico").val();
            }
            for (x = 0; x < Mx_Dtt_examcof.length; x++) {
                var xtotal = parseFloat(Mx_Dtt_examcof[x].CF_PRECIO_AMB);
                TOTAL += xtotal;

                var objId = {
                    "id_CF": Mx_Dtt_examcof[x].ID_CODIGO_FONASA,
                    "id_PER": Mx_Dtt_examcof[x].ID_PER,
                    "Valor": Mx_Dtt_examcof[x].CF_PRECIO_AMB,
                    "Clinico": numeritocliniquito,
                    "CF_ESTADO_EXAMEN": Mx_Dtt_examcof[x].CF_ESTADO_EXAMEN
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
                //-*-*-*-*Datos Paciente-*-*-*-*-*-*
                "RUT_PAC": $('#rut').val(),
                "NOMBRE_PAC": $("#Nom").val(),
                "APE_PAC": $("#Ape").val(),
                "FNAC_PAC": moment($("#fecha").val()).format("DD-MM-YYYY"),
                "ID_SEXO": $("#sex").val(),
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
                "TipoAtencion": $("#TipoAtencion").val(),
                "PrioridadTM": $("#PrioridadTM").val(),
                "Doctor": $("#Doctor").val(),
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
                "Interno": $("#Interno").val(),
                "id_Diag": $("#DdlDiagnostico").val(),
                "id_Diag2": $("#DdlDiagnostico2").val(),
                "sub_atencion": $("#sub_atencion").val(),
                "vih": $("#vih").val(), //SIFILIS
                "dni": $("#dni").val(),
                "NEW_VIH": $("#ddl_new_vih option:selected").text(),    //NEW VIH
                "S_Id_User": Galletas.getGalleta("ID_USER")

            });
            $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate_2.aspx/Guardar_TodoByVal",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dt023 = JSON.parse(json_receiver);
                        Hide_Modal();
                        Ajax_DL_SEXO();
                        Ajax_DL_NAC();
                        Ajax_Ciudad();
                        Ajax_DataTable();
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
                        $("#ddl_new_vih").val(0);
                        $("#ddl_new_vih").css({"border-color": "#ccc"});
                        $("#ddl_new_vih").parent().css({ "color": "#212529" });
                        $("#vih").val(0);
                        $("#vih").css({"border-color": "#ccc"});
                        $("#vih").parent().css({ "color": "#212529" });
                        $("#DdlDiagnostico").val(1);
                        $("#DdlDiagnostico2").val(1);
                        $("#obdser").val("");
                        $("#Doctor").val(1);
                        $("#Autorizo_retirar").val("");
                        $("#PrioridadTM").val(1);
                        $("#Prevision").val(263);
                        $("#TipoAtencion").val(1);
                        $("#sub_atencion").val(0);
                        $("#Programa").val(1);
                        $("#Sector").val(1);
                        Mx_Dtt_examcof.length = 0;
                        $("#DataTable_pac2 tbody").empty();
                        $("#Interno").val("");
                        add_row();
                        verrut = 0;
                        Mx_Dtt2.length = 0;
                        $('#XXXXXXXX').removeClass('show');
                        $("#title2").text("Ingreso de Atención realizado");
                        $("#modalpccc").html("<p><strong>Nº de Folio:</strong> <strong style='font-size:20px;'>" + Mx_Dt023.Correlativo + "</strong>\n ¿Desea imprimir Etiquetas?</p>");
                        $("#MOdal_PAGO").modal();
                    } else {
                        Hide_Modal();


                        var str_Error = "Estimano usuario Por favor ingresar exámenes"
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
                "ID_PREVE": $("#Prevision").val(),
                "Fecha": f
            });

            $.ajax({
                "type": "POST",
                //"url": "IN_PAC_AVIS.aspx/Llenar_tabla_exam2",
                "url": "Ingreso_Ate_2.aspx/Llenar_tabla_exam2",
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
                                    if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 1026) {
                                        posicion = x;
                                    }
                                }
                                Mx_Dtt_exam02.splice(posicion, 1);
                            }
                            if ($("#sex").val() == 2) {
                                for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                                    if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 66) {
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
                "ID_PREVE": $("#Prevision").val(),
                "Fecha": f,
                "CF": cod_fonasa
            });
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/Llenar_tabla_exam",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    console.log(response.d[0].CF_DESC);
                    Mx_Dtt_exam03 = json_receiver;
                    //if (json_receiver != "null") {
                    if(Mx_Dtt_exam03.length > 0){
                        console.log(Mx_Dtt_exam03);
                        if ($("#sex").val() != 0) {
                            console.log("entra al IF");
                            var posicion = 0;
                            if ($("#sex").val() == 1) {
                                for (x = 0; x < Mx_Dtt_exam03.length; x++) {
                                    if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 1026) {
                                        posicion = x;
                                        Mx_Dtt_exam03.splice(posicion, 1);
                                    }
                                }
                                
                            }
                            if ($("#sex").val() == 2) {
                                for (x = 0; x < Mx_Dtt_exam03.length; x++) {
                                    if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 66) {
                                        posicion = x;
                                        Mx_Dtt_exam03.splice(posicion, 1);
                                    }
                                }
                               
                            }
                        }

                        console.log(id+" "+cod+" "+txis);

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
               "PAC_OBS_PER": 0,
               "PAC_DIR": 0,
               "ID_DIAGNOSTICO ": 0,
               "ID_ESTADO": 0,
               "ID_CIUDAD": 0,
               "PAC_OBS_PERMA": 0,
               "ID_COMUNA": 0
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

        function Ajax_Ciudad() {


            $.ajax({
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
          "ID_ESTADO": 0
      }
        ];
        function Ajax_DL_prevision() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/Llenar_DL_prevision",
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
    </script>
    <script>
        function Fill_DL_orden_ate() {
            $("#PrioridadTM").empty();
            for (y = 0; y < Mx_DL_orden_ate.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_orden_ate[y].ID_ORDEN
                }).text(Mx_DL_orden_ate[y].ORD_DESC).appendTo("#PrioridadTM");

            }
            $("#PrioridadTM").val(1);
        }
        function Fill_DL_DOC() {
            $("#Doctor").empty();
            for (y = 0; y < Mx_DL_DOC.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_DOC[y].ID_DOCTOR
                }).text(Mx_DL_DOC[y].DOC_NOMBRE + " " + Mx_DL_DOC[y].DOC_APELLIDO).appendTo("#Doctor");
            }
            $("#Doctor").val(1);
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
                "url": "Ingreso_Ate_2.aspx/Llenar_DataTable",
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
            for (y = 0; y < Mx_DL_SEXO.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_SEXO[y].ID_SEXO
                }).text(Mx_DL_SEXO[y].SEXO_DESC).appendTo("#sex");
            }
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
        };

        /// llenado examenes modal
        function Fill_DataTable_exam02() {

            var iii = 0;
            var xxx = 0;
            var colorb = 1;
            var indexxx = 1;
            var act_3_row = 0;
            //Mx_secc[s].DESC_ORDEN
            //cant = Mx_secc.length / 3 + 1
            var cant_exams = 0;
            for (l = 0; l < 1; l++) {

                if (Mx_Dtt_examcof.length > 0) {

                }

                //for (x = 0; x < Mx_Dtt_examcof.length; x++) {

                

                //agregamos primer div
                $("#ulol").append(
                    $("<div>").attr("id", "contai2" + l)
                );


                $("#contai2" + l).attr("class", "row");
                $("#contai2" + l).css({"border-radious":"10px"});

                //for (h = 0; h < 3; h++) {
                //for (s = 0; s < Mx_secc.length; s++) {
                $("#contai2" + l).append(
                $("<div>").attr("id", "contai3" + iii)
                );
                $("#contai3" + iii).append(
                      $("<h5>").html("<i class='fa fa-get-pocket colorcoso' aria-hidden='true'></i> " + "")
                );
                $("#contai3" + iii).css("border-radius", "10px");
                $("#contai3" + iii).attr("class", "col-lg-6");
                if (colorb == 1) {
                    $("#contai3" + iii).attr("style", "background-color: #ffffff; border-radius: 8px");
                    //$("#contai3" + iii).attr("style", "border-radius: 10px");
                }
                if (colorb == 2) {
                    $("#contai3" + iii).attr("style", "background-color: #ffffff; border-radius: 8px");
                    //$("#contai3" + iii).attr("style", "border-radius: 10px");
                }
                if (colorb == 3) {
                    $("#contai3" + iii).attr("style", "background-color: #ffffff; border-radius: 8px");
                    //$("#contai3" + iii).attr("style", "border-radius: 10px");
                }
                for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                    if (cant_exams < 32 && (Mx_Dtt_exam02[x].ID_CODIGO_FONASA != 453 && Mx_Dtt_exam02[x].ID_CODIGO_FONASA != 315 && Mx_Dtt_exam02[x].ID_CODIGO_FONASA != 1021 && Mx_Dtt_exam02[x].ID_CODIGO_FONASA != 364)) {
                        $("#contai3" + iii).append(
                          //$("<div>").html("<input type='checkbox' id='H" + xxx + "' value='" + Mx_Dtt_exam02[x].ID_CODIGO_FONASA + "' /><label for='H" + xxx + "'>" + Mx_Dtt_exam02[x].CF_DESC + "</label>")
                           $("<div>").html("<div class='checkbox checkbox-success pp_order' style='margin-top:-5px;'><input type='checkbox' class='manitos2 VBG2 pp_order' id='H" + xxx + "' value='" + Mx_Dtt_exam02[x].ID_CODIGO_FONASA + "' /><label class='manitos2 VBG pp_order' for='H" + xxx + "'>" + indexxx + " - " + Mx_Dtt_exam02[x].CF_DESC + " - " +Mx_Dtt_exam02[x].CF_COD +"</label></div>")
                      );
                        //$("#contai3" + iii + " div").attr("class", "checkbox checkbox-success");
                        xxx++;

                        colorb++
                        if (colorb == 3) {
                            colorb = 1;
                        }

                    } else if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 453 || Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 315 || Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 1021) {
                        cant_exams = 0;
                        iii++;
                        $("#contai2" + l).append(
                        $("<div>").attr("id", "contai3" + iii)
                        );
                        if (act_3_row == 0) {

                            $("#contai3" + iii).append(
                                  $("<h5>").html("<i class='fa fa-get-pocket colorcoso' aria-hidden='true'></i> " + "")
                            );

                        } else {
                            $("#contai3" + iii).append(
                                  $("<h5>").html("<label></label>")
                            );
                        }
                        $("#contai2" + l).append(
                        $("<div>").attr("id", "contai3" + iii)
                        );
                        $("#contai3" + iii).css("border-radius", "10px");
                        $("#contai3" + iii).attr("class", "col-lg-4");

                        act_3_row++;

                        //$("#ulol").append(
                        //    $("<div>").attr("id", "contai2" + l)
                        //);

                        //$("#contai2" + l).attr("class", "row");
                            
                        if (colorb == 1) {
                            $("#contai3" + iii).attr("style", "background-color: #ffffff; border-radius: 8px");
                            //$("#contai3" + iii).attr("style", "background-color: #ffffff; border-radius: 8px");
                            //$("#contai3" + iii).attr("style", "border-radius: 10px");
                        }
                        if (colorb == 2) {
                            $("#contai3" + iii).attr("style", "background-color: #ffffff; border-radius: 8px");
                            //$("#contai3" + iii).attr("style", "background-color: #dce6f7; border-radius: 8px");
                            //$("#contai3" + iii).attr("style", "border-radius: 10px");
                        }
                        if (colorb == 3) {
                            $("#contai3" + iii).attr("style", "background-color: #ffffff; border-radius: 8px");
                            //$("#contai3" + iii).attr("style", "border-radius: 10px");
                        }
                        $("#contai3" + iii).append(
                         //$("<div>").html("<input type='checkbox' id='H" + xxx + "' value='" + Mx_Dtt_exam02[x].ID_CODIGO_FONASA + "' /><label for='H" + xxx + "'>" + Mx_Dtt_exam02[x].CF_DESC + "</label>")
                         $("<div>").html("<div class='checkbox checkbox-success pp_order' style='margin-top:-5px;'><input type='checkbox' class='manitos2 VBG2 pp_order' id='H" + xxx + "' value='" + Mx_Dtt_exam02[x].ID_CODIGO_FONASA + "' /><label class='manitos2 VBG pp_order' for='H" + xxx + "'>" + indexxx + " - " + Mx_Dtt_exam02[x].CF_DESC + " - " + Mx_Dtt_exam02[x].CF_COD + "</label></div>")

                             
                     );
                        //$("#contai3" + iii + " div").attr("class", "checkbox checkbox-success pp");
                        xxx++;

                        colorb++
                        if (colorb == 3) {
                            colorb = 1;
                        }
                    }else if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 364) {
                        cant_exams = 0;
                        iii++;
                        //$("#ulol").append(
                        //    $("<div>").attr("id", "contai2" + l)
                        //);

                        //$("#contai2" + l).attr("class", "row");
                        $("#contai2" + l).append(
                        $("<div>").attr("id", "contai3" + iii)
                        );
                        $("#contai3" + iii).append(
                              $("<h5>").html("<i class='fa fa-get-pocket colorcoso' aria-hidden='true'></i> " + "")
                        );
                        $("#contai3" + iii).css("border-radius", "10px");
                        $("#contai3" + iii).attr("class", "col-lg-6");
                        if (colorb == 1) {
                            $("#contai3" + iii).attr("style", "background-color: #ffffff; border-radius: 8px");
                            //$("#contai3" + iii).attr("style", "border-radius: 10px");
                        }
                        if (colorb == 2) {
                            $("#contai3" + iii).attr("style", "background-color: #ffffff; border-radius: 8px");
                            //$("#contai3" + iii).attr("style", "background-color: #dce6f7; border-radius: 8px");
                            //$("#contai3" + iii).attr("style", "border-radius: 10px");
                        }
                        if (colorb == 3) {
                            $("#contai3" + iii).attr("style", "background-color: #ffffff; border-radius: 8px");
                            //$("#contai3" + iii).attr("style", "background-color: #d1e1f9; border-radius: 8px");
                            //$("#contai3" + iii).attr("style", "border-radius: 10px");
                        }
                        $("#contai3" + iii).append(
                         //$("<div>").html("<input type='checkbox' id='H" + xxx + "' value='" + Mx_Dtt_exam02[x].ID_CODIGO_FONASA + "' /><label for='H" + xxx + "'>" + Mx_Dtt_exam02[x].CF_DESC + "</label>")
                         $("<div>").html("<div class='checkbox checkbox-success pp_order' style='margin-top:-5px;'><input type='checkbox' class='manitos2 VBG2 pp_order' id='H" + xxx + "' value='" + Mx_Dtt_exam02[x].ID_CODIGO_FONASA + "' /><label class='manitos2 VBG pp_order' for='H" + xxx + "'>" + indexxx + " - " + Mx_Dtt_exam02[x].CF_DESC + " - " + Mx_Dtt_exam02[x].CF_COD + "</label></div>")


                     );
                        //$("#contai3" + iii + " div").attr("class", "checkbox checkbox-success pp");
                        xxx++;

                        colorb++
                        if (colorb == 3) {
                            colorb = 1;
                        }
                    }
                    else {
                        cant_exams = 0;
                        iii++;
                        //$("#ulol").append(
                        //    $("<div>").attr("id", "contai2" + l)
                        //);

                        //$("#contai2" + l).attr("class", "row");
                        $("#contai2" + l).append(
                        $("<div>").attr("id", "contai3" + iii)
                        );
                        $("#contai3" + iii).append(
                              $("<h5>").html("<i class='fa fa-get-pocket colorcoso' aria-hidden='true'></i> " + "")
                        );
                        $("#contai3" + iii).css("border-radius", "10px");
                        $("#contai3" + iii).attr("class", "col-lg-6");
                        if (colorb == 1) {
                            $("#contai3" + iii).attr("style", "background-color: #ffffff; border-radius: 8px");
                            //$("#contai3" + iii).attr("style", "background-color: #d1e1f9; border-radius: 8px");
                            //$("#contai3" + iii).attr("style", "border-radius: 10px");
                        }
                        if (colorb == 2) {
                            $("#contai3" + iii).attr("style", "background-color: #ffffff; border-radius: 8px");
                            //$("#contai3" + iii).attr("style", "background-color: #dce6f7; border-radius: 8px");
                            //$("#contai3" + iii).attr("style", "border-radius: 10px");
                        }
                        if (colorb == 3) {
                            $("#contai3" + iii).attr("style", "background-color: #ffffff; border-radius: 8px");
                            //$("#contai3" + iii).attr("style", "background-color: #d1e1f9; border-radius: 8px");
                            //$("#contai3" + iii).attr("style", "border-radius: 10px");
                        }
                        $("#contai3" + iii).append(
                         //$("<div>").html("<input type='checkbox' id='H" + xxx + "' value='" + Mx_Dtt_exam02[x].ID_CODIGO_FONASA + "' /><label for='H" + xxx + "'>" + Mx_Dtt_exam02[x].CF_DESC + "</label>")
                         $("<div>").html("<div class='checkbox checkbox-success pp_order' style='margin-top:-5px;'><input type='checkbox' class='manitos2 VBG2 pp_order' id='H" + xxx + "' value='" + Mx_Dtt_exam02[x].ID_CODIGO_FONASA + "' /><label class='manitos2 VBG pp_order' for='H" + xxx + "'>" + indexxx + " - " + Mx_Dtt_exam02[x].CF_DESC + " - " + Mx_Dtt_exam02[x].CF_COD + "</label></div>")

                             
                     );
                        //$("#contai3" + iii + " div").attr("class", "checkbox checkbox-success pp");
                        xxx++;

                        colorb++
                        if (colorb == 3) {
                            colorb = 1;
                        }
                    }
                    cant_exams++;
                    indexxx++;
                }
                    
                //}
                //}    
            //}
            }


            //$("#Div_Tabla2").empty();
            //$("<table>", {
            //    "id": "DataTable_pac",
            //    "class": "display",
            //    "width": "100%",
            //    "cellspacing": "0"
            //}).appendTo("#Div_Tabla2");

            //$("#DataTable_pac").append(
            //    $("<thead>"),
            //    $("<tbody>")
            //);
            //$("#DataTable_pac").attr("class", "table table-hover table-striped table-iris");
            //$("#DataTable_pac thead").attr("class", "cabzera");
            //$("#DataTable_pac thead").append(
            //    $("<tr>").append(

            //        $("<th>", { "class": "textoReducido" }).text("Nº"),
            //        $("<th>", { "class": "textoReducido" }).text("Codigo"),
            //        $("<th>", { "class": "textoReducido" }).text("Descripcion"),
            //        $("<th>", { "class": "textoReducido" }).text("Valor Ambulatorio"),
            //        $("<th>", { "class": "textoReducido" }).text("Carga")

            //    )
            //);
            //for (i = 0; i < Mx_Dtt_exam02.length; i++) {
            //    $("#DataTable_pac tbody").append(
            //        $("<tr>", {
            //            "class": "textoReducido manito",
            //            "padding": "1px !important",
            //        }).append(
            //            $("<td>", {
            //                "align": "left",
            //                "class": "textoReducido"

            //            }).text(i + 1),
            //            $("<td>", {
            //                "align": "left",
            //                "class": "textoReducido"
            //            }).text(Mx_Dtt_exam02[i].CF_COD),
            //            $("<td>", {
            //                "align": "left",
            //                "class": "textoReducido"
            //            }).text(Mx_Dtt_exam02[i].CF_DESC),
            //           $("<td>", {
            //               "align": "center",
            //               "class": "textoReducido"
            //           }).text(Mx_Dtt_exam02[i].CF_PRECIO_AMB),
            //        $("<td>", {
            //            "align": "center",
            //            "class": "textoReducido"
            //        }).html("<div class='checkbox checkbox-success pp' style='margin-top:-5px;'><input type='checkbox' class='manitos2 VBG2' id='H" + i + "' value='" + Mx_Dtt_exam02[i].ID_CODIGO_FONASA + "' /><label class='manitos2 VBG' for='H" + i + "'></label></div>")
            //        )
            //    );

            //}
            $("#DataTable_pac").keydown(function EnterEvent(e) {
                e.stopImmediatePropagation();
                let keycode = e.keyCode;
                console.log(keycode);
                if (e.keyCode == 13) {
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
            //var xLen = $(".VBG");
            //let LOOL = $(".VBG").eq(0);
            //LOOL.focus();
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






        function success(xxid, xxcod, xtxis) {
            console.log("entra en SUCCESS");
            if (Mx_Dtt_exam03.length == 0) {
                $("input[data-id='" + xxid + "']").val(xxcod);

                console.log("A");

            } else if (Mx_Dtt_exam03.length == 1) {

                console.log("B");

                var repetido = 0;
                for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == Mx_Dtt_exam03[0].ID_CODIGO_FONASA) {
                        repetido++
                        console.log("C");
                    }
                }
                if (repetido == 0) {
                    if (xxid != 0) {

                        console.log("D");

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
        function Fill_DataTable() {

            for (i = 0; i < Mx_Dtt_4556.length; i++) {
                if ($("#Procedencia").val() == Mx_Dtt_4556[i].ID_PROCEDENCIA) {


                    $("#Total").val(function () {
                        var resu = 0;
                        resu = Mx_Dtt_4556[i].AGEND_CUPO_NORMAL - Mx_Dtt_4556[i].TOTAL_AGEND_CUPO_NORMAL;
                        if (resu < 0) {
                            resu = 0;
                        }
                        return resu;

                    });
                    $("#Actuales").val(function () {

                        var resu = 0;
                        resu = Mx_Dtt_4556[i].AGEND_PRIORITARIO - Mx_Dtt_4556[i].TOTAL_AGEND_PRIORITARIO;
                        if (resu < 0) {
                            resu = 0;
                        }
                        return resu;
                    });
                    $("#Disponibles").val(function () {
                        var resu = 0;
                        resu = Mx_Dtt_4556[i].AGEND_ESPONTANEO - Mx_Dtt_4556[i].TOTAL_AGEND_ESPONTANEO;
                        if (resu < 0) {
                            resu = 0;
                        }
                        return resu;
                    });


                    //var p1 = Mx_Dtt[i].AGEND_CUPO_NORMAL - Mx_Dtt[i].TOTAL_AGEND_CUPO_NORMAL;
                    //var p2 = Mx_Dtt[i].AGEND_PRIORITARIO - Mx_Dtt[i].TOTAL_AGEND_PRIORITARIO;
                    //var p3 = Mx_Dtt[i].AGEND_ESPONTANEO - Mx_Dtt[i].TOTAL_AGEND_ESPONTANEO;
                    //var total = p1 + p2 + p3;
                    //if (p1 == 0 && p2 == 0 && p3 == 0) {
                    //    $('#BtnSaveAll').attr("disabled", false);
                    //} else {
                    //    uu = Mx_Dtt[i].CONF_DIAS_EXA_BUSCA_DIAS - total;
                    //    if (uu <= 0) {
                    //        $('#BtnSaveAll').attr("disabled", true);
                    //    } else {
                    //        $('#BtnSaveAll').attr("disabled", false);
                    //    }
                    //}
                }
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
    </script>
    <style>

        .colorcoso {
            color: #009639;
        }
        .alertas {
            margin-top: 180px;
            text-align: center;
        }

        .manitos2 {
            cursor: pointer;
        }

        .textoReducido {
            font-size: 11px;
        }

        .ancho-columna {
            height: 10%;
            padding: -35px;
        }

        .highlights {
            width: 100%;
            height: 300px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .highlights2 {
            width: 100%;
            height: 300px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .topbuttom {
            display: block;
            height: 80px;
            width: 100%;
        }

        .topbuttom2 {
            display: block;
            height: 80px;
        }

        .textbot {
            display: block;
            height: 22px;
            width: 100%;
        }

        .textbotLeft {
            display: block;
            height: 28px;
            width: 100%;
        }

        .cabzera {
            background: #46963f;
            color: white;
        }

        .espera {
            background: #c7ff00;
        }

        .atendido {
            background: #1fc12c;
            color: white;
        }

        #XXXXXXXX {
            z-index: 9000;
            width: 100%;
            position: fixed;
            left: 0px;
            top: 0px;
            display: flex;
            display: -webkit-flex;
            flex-flow: row nowrap;
            justify-content: center;
            color: #444;
            border: 0;
            border-radius: 2px;
            text-decoration: none;
            transition: opacity 0.2s ease-out;
            opacity: 0;
            margin-top: 60px;
        }

            #XXXXXXXX div {
                font-size: 18px;
                border: none;
                outline: none;
                background-color: #014B5D;
                color: white;
                padding: 8px;
                border-radius: 4px;
                font-size: 15px;
            }



            #XXXXXXXX.show {
                opacity: 1;
            }

        #content {
            height: 2000px;
        }

        @media screen and (min-width: 558px) {
            .topbuttom2 {
                width: 100%;
            }
        }

        .modal-header {
            background-color:#009639;
            color:white;
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
                <div id="modalpccc" class="modal-body">
                </div>
                <div class="modal-footer">
                    <button type="button" id="b" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                    <button type="button" id="button_modal_pago" class="btn btn-success" data-dismiss="modal">Imprimir</button>
                </div>
            </div>
        </div>
    </div>
     <div id="XXXXXXXX" class="tobackinfo">
  <div id="xxx_xxx">
    
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
                    <p></p>
                </div>
                <div class="modal-footer">
                    <button type="button" id="button_modal" class="btn btn-danger" data-dismiss="modal">Aceptar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="eModal3" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss5">Agregar Exámenes</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="col-md-12">
                            <div id="Div_Tabla4" style="width: 100%;" class="highlights2"></div>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btnexarepetido" class="btn btn-success">Cargar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="eModal2" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true" >
        <div class="modal-dialog modal-lg" role="document" style="max-width: 70vw;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Agregar Exámenes a Atención</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="col-lg-12">
                            <div id="ulol" style="width: 100%; height:90%; font-size: 12px;"></div>
                            <%--<div id="Div_Tabla2" style="width: 100%;" class="highlights2"></div>--%>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btnguardar" class="btn btn-success">Cargar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Breadcrumbs -->
    <div class="card border-bar">
        <div class="card-header bg-bar p-2">
            <h5 style="text-align: center; padding: 5px;">
                <i class="fa fa-sign-in"></i>
                Ingreso de Atención
            </h5>
        </div>
        <div class="card-body p-3">
            <div class="container" style="max-width: 100%;">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="row">
                        <div class="col-md checkbox checkbox-success">                    
                            <input id="checkBox999" value="rutee" type="checkbox"/> <label class="textoReducido" style="padding-left: 0px !important;" for="checkBox999">RUT</label><input id="checkBox888" value="DNI" type="checkbox"/><label style="margin-left: 15px; padding-left: 0px !important;" class="textoReducido" for="checkBox888">DNI:</label><input id="checkBox8887" value="DNI" type="checkbox"/><label style="margin-left: 15px; padding-left: 0px !important;" class="textoReducido" for="checkBox8887">N° Atención:</label>
                           
                            <input type='text' id="rut" class="form-control textoReducido" placeholder="12.345.789-0" />
                            <input type='text' id="dni" class="form-control textoReducido" placeholder="D.N.I" />
                            <input type='text' id="Naten" class="form-control textoReducido" placeholder="N° Atención" />
                                 
                        </div>
                            <div class="col-lg">
                                <label class="textoReducido">Nombres:</label>
                                <input type='text' id="Nom" class="form-control textoReducido" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Apellidos:</label>
                                <input type='text' id="Ape" class="form-control textoReducido" placeholder="" />
                            </div>
                            <%--     </div>
                        <div class="row">--%>
                            <div class="col-lg">
                                <label class="textoReducido">F.Nacimiento:</label>
                                <div class='input-group date' id='datetimepicker1' style="margin-bottom: 1vh;">
                                    <input type="date" min="0001-01-01" max="2018-12-01" id="fecha" class="form-control textoReducido" placeholder="Fecha"/>
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                                <style>
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
                                </style>
                                <%--<script type="text/javascript">
                 
                                    $(function () {
                                        $('#datetimepicker1').datetimepicker(
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
                                </script>--%>
                            </div>

                            <div class="col-lg">
                                <label class="textoReducido">Edad:</label>
                                <input type='text' id="Edad" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="text-align: center;" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Sexo:</label>
                                <select id="sex" class="form-control textoReducido" style="height: 31.75px;">
                                </select>
                            </div>
                            
                        </div>
                        <div class="row">
                    <div class="col-lg checkbox checkbox-success">
                                <input id="checkBox2" type="checkbox" value="SoyFur" />
                                <label for="checkBox2" class="textoReducido">F.U.R:</label>
                                <div class='input-group date' id='datetimepicker3' style="margin-bottom: 1vh;">
                                    <input type='text' id="FUR" class="form-control textoReducido" readonly="true" placeholder="Fecha" />
                                    <span id="fur" class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                                <style>
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
                                </style>
                                <script type="text/javascript">
                                    ////////////////////////////////////
                                    ////////////////////////////////////
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
                                </script>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Nacionalidad:</label>
                                <select id="Nacio" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Tel. Fijo:</label>
                                <input type='text' id="telfijo" class="form-control textoReducido" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Celular:</label>
                                <input type='text' id="Celular" class="form-control textoReducido" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Dirección:</label>
                                <input type='text' id="direccion" class="form-control textoReducido" placeholder="" />
                            </div>

                            <div class="col-lg">
                                <label class="textoReducido">Ciudad:</label>
                                <select id="Cuidad" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="0">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Comuna:</label>
                                <select id="Comuna" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="0">Seleccionar</option>
                                </select>
                            </div>
                        </div>
                        <div>
                            <div class="row" style="margin-bottom: 10px;">
                                <div class="col-lg">
                                    <label class="textoReducido">Email:</label>
                                    <input type='text' id="Email" class="form-control textoReducido" placeholder="Irislab@irislab.cl" />
                                </div>
                                <div class="col-lg">
                                    <label class="textoReducido">Nº Interno:</label>
                                    <input type='text' id="Interno" class="form-control textoReducido" placeholder="" style="background-color: #87f0ff;"/>
                                </div>
                                <div class="col-lg-5">
                                    <label class="textoReducido">observaciones permanentes del paciente:</label>
                                    <input type='text' id="obdser" class="form-control textoReducido" placeholder="" />
                                </div>
                                <div class="col-lg">
                                    <label class="textoReducido">Diagnostico N° 1</label>
                                    <select id="DdlDiagnostico" class="form-control textoReducido" style="height: 31.75px;">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                               <div class="col-lg">
                                    <label class="textoReducido">Diagnostico N° 2</label>
                                    <select id="DdlDiagnostico2" class="form-control textoReducido" style="height: 31.75px;">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <hr />
            <h5 style="text-align: center; padding: 5px;">Antecedentes de la Atención  </h5>
            <div class="container" style="max-width: 100%;">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="row">
                            <div class="col-lg">
                                <label class="textoReducido">Procedencia:</label>
                                <select id="Procedencia" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="0">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Doctor:</label>
                                <select id="Doctor" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Tipo de Atención:</label>
                                <select id="TipoAtencion" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                     <div class="col-sm">
                            <label class="textoReducido">Cupo Normal:</label>
                            <input type='text' id="Total" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="background-color: yellow; text-align: center;" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Prioritario:</label>
                            <input type='text' id="Actuales" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="background-color: #f4abe7; text-align: center;" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Espontáneo:</label>
                            <input type='text' id="Disponibles" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="background-color: chartreuse; text-align: center;" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Sub-Atención:</label>
                            <select id="sub_atencion" class="form-control textoReducido" style="height: 31.75px; background-color: #87f0ff;">
                                <option value="0">Seleccionar</option>
                                   <option value="5">Agendado Sobre Cupo</option>   
                               <%-- <option value="1">Agendado Cupo normal</option>--%>
                                <option value="2">Agendado Prioritario</option>
                                <option value="3">Agendado Espontáneo</option>
                                <option value="4">Agendado (PAP)</option>
                              
                                
                            </select>
                        </div>
                            <div class="col-lg">
                                <label class="textoReducido">Programa:</label>
                                <select id="Programa" class="form-control textoReducido" style="height: 31.75px;background-color: #87f0ff;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Sector:</label>
                                <select id="Sector" class="form-control textoReducido" style="height: 31.75px;background-color: #87f0ff;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-lg">
                                <label class="textoReducido">Localizacion:</label>
                                <select id="Localizacion" class="form-control textoReducido" style="height: 31.75px;" disabled="disabled">
                                    <option value="volvo">TOMA DE MUESTRA</option>
                                </select>
                            </div>
                            <%--<div class="col-lg-1">
                                <label class="textoReducido">Cama:</label>
                                <input type='text' id="cama" class="form-control textoReducido" placeholder="0" disabled="disabled" value="0" />
                            </div>--%>
                            <div class="col-lg">
                                <label class="textoReducido">Grupo Riesgo VIH</label>
                                <select id="ddl_new_vih" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="0">Seleccione</option>
                                    <option value="1">GESTANTES PRIMER EXAMEN</option>
                                    <option value="2">GESTANTES SEGUNDO EXAMEN</option>
                                    <option value="3">MUJER EN TRABAJO DE PRE PARTO O PARTO</option>
                                    <option value="4">PERSONAS EN CONTROL POR COMERCIO SEXUAL</option>
                                    <option value="5">PACIENTES EN DIÁLISIS</option>
                                    <option value="6">POR CONSULTA ITS</option>
                                    <option value="7">PERSONAS EN CONTROL FECUNDIDAD, GINECOLOGICO, CLIMATERIO</option>
                                    <option value="8">PERSONAS CON EMP</option>
                                    <option value="9">PERSONAS EN CONTROL DE SALUD SEGÚN CICLO VITAL</option>
                                    <option value="10">DONANTE ALTRUISTA NUEVO</option>
                                    <option value="11">DONANTE ALTRUISTA REPETIDO</option>
                                    <option value="12">DONANTE FAMILIAR O REPOSICIÓN</option>
                                    <option value="13">DONANTES DE ÓRGANOS Y/O TEJIDOS</option>
                                    <option value="14">PERSONA EN CONTROL POR TBC</option>
                                    <option value="15">VÍCTIMA DE VIOLENCIA SEXUAL</option>
                                    <option value="16">PAREJA SERODISCORDANTE</option>
                                    <option value="17">PAREJA DE GESTANTE VIH POSITIVO</option>
                                    <option value="18">PERSONAL DE SALUD EXPUESTO A ACCIDENTE CORTOPUNZANTE</option>
                                    <option value="19">PACIENTES FUENTE DE ACCIDENTE CORTOPUNZANTE</option>
                                    <option value="20">PERSONA EN CONTROL POR HEPATITIS B</option>
                                    <option value="21">PERSONA EN CONTROL POR HEPATITIS C</option>
                                    <option value="22">CONSULTANTES POR MORBILIDAD</option>
                                    <option value="23">POR CONSULTA ESPONTÁNEA</option>
                                </select>
                            </div>
                      <div class="col-sm">
                            <label class="textoReducido">Grupo Riesgo Sífilis</label>
                                 <%--<input type='text' id="vih" class="form-control textoReducido" placeholder="" text-align: center;" />--%>
                          <select id="vih" class="form-control textoReducido" style="height: 31.75px;">
                              <option value="0">Seleccione</option>
                                    <option value="1">GESTANTES PRIMER TRIMESTRE EMBARAZO</option>
                                    <option value="2">GESTANTES SEGUNDO TRIMESTRE EMBARAZO</option>
                                    <option value="3">GESTANTES TERCER TRIMESTRE EMBARAZO</option>
                                    <option value="4">GESTANTES TRIMESTRE EMBARAZO IGNORADO</option>
                                    <option value="5">GESTANTES EN SEGUIMIENTO POR DIAGNÓSTICO SÍFILIS</option>
                                    <option value="6">PAREJA DE GESTANTE CON SEROLOGÍA REACTIVA</option>
                                    <option value="7">MUJERES QUE INGRESAN A MATERNIDAD POR PARTO</option>
                                    <option value="8">MUJERES QUE INGRESAN POR ABORTO</option>
                                    <option value="9">MUJERES EN CONTROL GINECOLÓGICO</option>
                                    <option value="10">RECIÉN NACIDO Y LACTANTE PARA DETECCIÓN DE SÍFILIS CONGÉNITA</option>
                                    <option value="11">PERSONAS EN CONTROL POR COMERCIO SEXUAL</option>
                                    <option value="12">PERSONAS EN CONTROL FECUNDIDAD</option>
                                    <option value="13">CONSULTANTES POR ITS</option>
                                    <option value="14">PERSONAS CON EMP</option>
                                    <option value="15">DONANTES DE SANGRE</option>
                                    <option value="16">DONANTES DE ÓRGANOS Y/O TEJIDOS</option>
                                    <option value="17">PACIENTES EN DIÁLISIS</option>
                                    <option value="18">VÍCTIMA DE VIOLENCIA SEXUAL</option>
                          </select>
                        </div>
                            <div class="col-lg">
                                <label class="textoReducido">Observacion de la Atencion:</label>
                                <input type='text' id="obs_ate" class="form-control textoReducido" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Autorizo a Retirar:</label>
                                <input type='text' id="Autorizo_retirar" class="form-control textoReducido" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Prioridad TM:</label>
                                <select id="PrioridadTM" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                          <div class="col-sm">
                                <label class="textoReducido">N° Orden Clínica</label>
                                     <input type='text' id="NumeroClinico" class="form-control textoReducido" placeholder="" text-align: center;" />
                            </div>


                            <%--   </div>
                         <div class="row">--%>
                            <div class="col-sm">
                                <label class="textoReducido">Previsión:</label>
                                <select id="Prevision" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <hr />
            <h5 style="text-align: center; padding: 5px;">Agregar Exámenes </h5>
            <div class="container" style="max-width: 100%;">
                <div class="row">
                    <div class="col-sm">
                        <%--                    <div id="Div_Tabla" style="width: 100%;" class="highlights">                     
                         <table style="width:100%" class="table table-bordered">
                              <tr>
                                <th style="width: 20%;">Codigo Fonasa</th>
                                <th style="width: 100%;">Descripcion</th>
                                <th style="width: 50%;">Dias Proceso</th>
                              </tr>
                              <tr>
                                <td> <input type='text' id="Examen01" class="form-control textoReducido" placeholder=""/></td>
                                <td ><label id="desc1" style="margin-top:8px;"></label></td>
                                <td ><label id="dias1" style="margin-top:8px;"></label></td>
                              </tr>
                        </table> 
                    </div>--%>
                        <div id="Div_Tabla3" style="width: 100%;" class="highlights"></div>
                    </div>
                </div>

            </div>
            <div class="container" style="max-width: 100%; border: 0px solid #fff;">
                <div class="row">
                    <div class="col-sm-3">
                        <button id="Examen" type="button" class="btn btn-danger btn-block">
                            <br />
                            <i class="fa fa-align-left" aria-hidden="true" style="font-size: 30px;"></i>
                            <p style="margin-top: 2px;">Examen</p>
                        </button>
                    </div>
                    <div class="col-sm-3">
                    </div>
                    <div class="col-sm-3" style="justify-content: flex-end;">
                        <button id="Btnnew" type="button" class="btn btn-info btn-block">
                            <br />
                            <i class="fa fa-plus-square" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                            <p style="margin-top: 2px;">Nuevo</p>
                        </button>
                    </div>
                    <div class="col-sm-3">
                        <button id="BtnSaveAll" type="button" class="btn btn-primary btn-block">
                            <br />
                            <i class="fa fa-fw fa-save" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                            <p style="margin-top: 2px;">Guardar</p>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
