<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="IN_PAC_MAN.aspx.vb" Inherits="Presentacion.IN_PAC_MAN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">


    <script src="../js/Deep-Copy.js"></script>
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>

    <!--ClockPicker-->
    <link href="../css/ClockPicker.css" rel="stylesheet" />
    <script src="/js/ClockPicker.js"></script>
    <script src="/js/highlight.js"></script>

    <script>
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

        var DDD = getParameterByName('FF');
        $(document).ready(function () {




            $("#button_modal_pago").click(function () {
                if (Mx_Dt023.length != 0) {

                    var dataParam = [Mx_Dt023.ID_PREINGRESO];
                    function AR_Success() {


                        var str_Error = "La impresión se ha completado exitosamente."

                        $("#mError_AAH h4").text("Impresión Correcta");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text(str_Error);
                        $("#mError_AAH").modal();
                    }
                    function AR_Error() {


                        var str_Error = "No se a detectado ninguna interface de impresión abierta. Abra IRISLAB_PRINT o " // o de lo contrario descargelo AQUI
                        str_Error += "descargue la aplicación aquí <a href='" + window.origin + "/Iris_Print/Setup.exe'>DESCARGAR</a>";

                        $("#mError_AAH h4").text("Error");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").html(str_Error);
                        $("#mError_AAH").modal();
                    }


                    var AR_Eti = new Iris_Print(dataParam, AR_Success, AR_Error);
                    AR_Eti.Imp_Voucher_Agendam();

                } else {
                    alert("no hay datos")
                }
            });


            Ajax_Diagnostico();
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
            $("#checkBox2").prop('checked', false);//solo los del objeto
            $('#FUR').attr("disabled", true);
            $('#checkBox2').attr("disabled", true);
            $('#TipoAtencion').attr("disabled", true);
            $("#fur").css("pointer-events", "none");
            var f = moment().format("DD-MM-YYYY");
            $("#fecha").val(f);

            $("#fecha2").val(DDD);
            Ajax_DataTable();
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
                    $("<th>", { "class": "textoReducido" }).text("Dias Proceso"),
                    $("<th>", { "class": "textoReducido" }).text("")
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
                $("#FUR").val(f);
                $('#rut').removeAttr("disabled");
                $('#rut').val("");
                $("#Nom").val("");
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
                var asd = $("#fecha").val();
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
                $("#Edad").val(total);

            });
            $("#sex").change(function () {
                Ajax_DataTable_examen02();
                var sex = $("#sex option:selected").text();
                if (sex == "Femenino") {
                    $('#checkBox2').removeAttr("disabled");

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
                            //for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                            if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 66) {
                                Mx_Dtt_examcof.splice(z, 1);
                                xxxer = true;
                            }
                            //}
                        }
                        if (xxxer == true) {
                            for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                                if (Mx_Dtt_exam02_respaldo[x].ID_CODIGO_FONASA == 1026) {
                                    Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02_respaldo[x]));
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
                Mx_Dtt_exam02.length = 0;
                Ajax_DataTable_examen02();
                $("#DataTable_pac2 tbody").empty();
                add_row();
            });

            $("#BtnSaveAll").click(function () {
                var sum = 0;

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

                if (sum == 7) {

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

                    //window.location = '#page-top';
                    $('body, html').animate({
                        scrollTop: '0px'
                    }, 300);
                }
            });

            //$("#BtnSaveAll").click(function () {
            //    var sum = 0;

            //    if ($("#Nom").val() == "") {

            //        $("#Nom").css({
            //            "border-color": "red"
            //        });

            //    } else {
            //        sum += 1;
            //        $("#Nom").css({
            //            "border-color": "#ccc"
            //        });
            //    }
            //    if ($("#Ape").val() == "") {

            //        $("#Ape").css({
            //            "border-color": "red"
            //        });

            //    } else {
            //        sum += 1;
            //        $("#Ape").css({
            //            "border-color": "#ccc"
            //        });
            //    }

            //    if ($("#Edad").val() == "") {

            //        $("#fecha").css({
            //            "border-color": "red"
            //        });

            //    } else {
            //        sum += 1;
            //        $("#fecha").css({
            //            "border-color": "#ccc"
            //        });
            //    }

            //    if ($("#sex").val() == 0) {

            //        $("#sex").css({
            //            "border-color": "red"
            //        });

            //    } else {
            //        sum += 1;
            //        $("#sex").css({
            //            "border-color": "#ccc"
            //        });
            //    }

            //    if ($("#Nacio").val() == 0) {

            //        $("#Nacio").css({
            //            "border-color": "red"
            //        });

            //    } else {
            //        sum += 1;
            //        $("#Nacio").css({
            //            "border-color": "#ccc"
            //        });
            //    }
            //    if ($("#Cuidad").val() == 0) {

            //        $("#Cuidad").css({
            //            "border-color": "red"
            //        });

            //    } else {
            //        sum += 1;
            //        $("#Cuidad").css({
            //            "border-color": "#ccc"
            //        });
            //    }
            //    if ($("#Comuna").val() == 0) {

            //        $("#Comuna").css({
            //            "border-color": "red"
            //        });

            //    } else {
            //        sum += 1;
            //        $("#Comuna").css({
            //            "border-color": "#ccc"
            //        });
            //    }

            //    if (sum == 7) {


            //        if ($("#rut").val() == "") {
            //            verrut = 2;
            //        }
            //        Ajax_guardar();
            //    } else {

            //    }
            //});
            //-*-*-*-*-*-*-*-*-* TABLA DINAMICA -*-*-*-*-*-*-*-*-*-*-*
            $("#Examen").click(function () {
                Fill_DataTable_exam02();
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
                    }
                } else {
                    var str_Error = "El campo no puede ser eliminado"
                    $("#title").text("Eliminar Examen");
                    $("#button_modal").attr("class", "btn btn-danger");

                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();
                }


            });
        });
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
    </script>
    <script>
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
                               "class": "textoReducido td_val2"
                           }).text(""),
                        $("<td>", {
                            "align": "center"
                        }).html("<button type='button' class='btn btn-default btn-xs borrar' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>")
                        )

                    )
                $(".td_input").keydown(function EnterEvent(e) {
                    if (e.keyCode == 13) {
                        xId = $(this).attr("data-id");
                        var xcod = $(this).attr("data-cod");
                        Ajax_DataTable_examen3($(this).val(), xId, xcod, $(this));
                    }
                });

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
                               "class": "textoReducido td_val2"
                           }).text(""),
                        $("<td>", {
                            "align": "center"
                        }).html("<button type='button' class='btn btn-default btn-xs borrar' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'>Eliminar</i></button>")
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
          }
        ];
        Mx_Dtt_examcof.length = 0;
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        var Mx_Dt023 = [
          {
              "CORELATIVO": 0,
              "ID_PREINGRESO": 0
          }
        ];
        function Ajax_guardar() {
            modal_show();
            var fur = 0;
            var OB = "";
            var ID = 0;
            var ed = (function () {
                var asd = $("#fecha").val();
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
                var asd = $("#fecha").val();
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
                var asd = $("#fecha").val();
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
            for (x = 0; x < Mx_Dtt_examcof.length; x++) {
                var xtotal = parseFloat(Mx_Dtt_examcof[x].CF_PRECIO_AMB);
                TOTAL += xtotal;

                var objId = {
                    "id_CF": Mx_Dtt_examcof[x].ID_CODIGO_FONASA,
                    "id_PER": Mx_Dtt_examcof[x].ID_PER,
                    "Valor": Mx_Dtt_examcof[x].CF_PRECIO_AMB
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
            var Data_Par = JSON.stringify({
                //-*-*-*-*Datos Paciente-*-*-*-*-*-*
                "RUT_PAC": $('#rut').val(),
                "NOMBRE_PAC": $("#Nom").val(),
                "APE_PAC": $("#Ape").val(),
                "FNAC_PAC": $("#fecha").val(),
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
                "OB": ID,
                //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                "Procedencia": $("#Procedencia").val(),
                "Programa": $("#Programa").val(),
                "Sector": $("#Sector").val(),
                "TipoAtencion": $("#TipoAtencion").val(),
                "PrioridadTM": $("#PrioridadTM").val(),
                "Doctor": $("#Doctor").val(),
                "Prevision": $("#Prevision").val(),
                //-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/
                "EDAD": ed,
                "MES": me,
                "DIA": di,
                //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                "TOTAL": TOTAL,
                "FECHA_PRE": $("#fecha2").val(),
                //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-    
                "ids": ids,
                "xHora": $("#txtClock input").val(),
                "id_Diag": $("#DdlDiagnostico").val(),
                "id_Diag2": $("#DdlDiagnostico2").val()
            });
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/Guardar_TodoByVal",
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
                        $("#fecha").val(f);

                        $("#FUR").val(f);
                        $('#rut').removeAttr("disabled");
                        $('#rut').val("");
                        $("#Nom").val("");
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


                        $("#title2").text("Ingreso de Atención realizado");
                        $("#modalpccc").html("<p><strong>Nº de Agendamiento:</strong> <strong style='font-size:20px;'>" + Mx_Dt023.CORELATIVO + "</strong>\n ¿Desea imprimir Voucher?</p>");
                        $("#MOdal_PAGO").modal();

                    } else {
                        Hide_Modal();


                        var str_Error = "Estimano usuario Por favor ingresar exámenes"
                        $("#title").text("Agendamiento");
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



            $("#Div_Tabla2").empty();
            var Data_Par = JSON.stringify({
                "ID_PREVE": $("#Prevision").val(),
                "Fecha": $("#fecha2").val()
            });

            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/Llenar_tabla_exam2",
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


            var Data_Par = JSON.stringify({
                "ID_PREVE": $("#Prevision").val(),
                "Fecha": $("#fecha2").val(),
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
                    if (json_receiver != "null") {
                        Mx_Dtt_exam03 = JSON.parse(json_receiver);

                        if ($("#sex").val() != 0) {
                            var posicion = 0;
                            if ($("#sex").val() == 1) {
                                for (x = 0; x < Mx_Dtt_exam03.length; x++) {
                                    if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 1026) {
                                        posicion = x;
                                    }
                                }
                                Mx_Dtt_exam03.splice(posicion, 1);
                            }
                            if ($("#sex").val() == 2) {
                                for (x = 0; x < Mx_Dtt_exam03.length; x++) {
                                    if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 66) {
                                        posicion = x;
                                    }
                                }
                                Mx_Dtt_exam03.splice(posicion, 1);
                            }
                        }
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

        function Ajax_DataTable() {




            var Data_Par = JSON.stringify({
                "fecha": $("#fecha2").val(),
            });

            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
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
                        Ajax_DataTable_examen02();



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
    </script>
    <script>
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
        }
        function Fill_DataTable() {
            var ur2 = getParameterByName('kl');
            for (i = 0; i < Mx_Dtt.length; i++) {
                if (ur2 == Mx_Dtt[i].ID_PROCEDENCIA) {
                    $("#Total").val(Mx_Dtt[i].CONF_DIAS_EXA_BUSCA_DIAS);
                    $("#Actuales").val(Mx_Dtt[i].TOTAL_ATE);
                    $("#Disponibles").val(function () {
                        var resu = 0;
                        resu = Mx_Dtt[i].CONF_DIAS_EXA_BUSCA_DIAS - Mx_Dtt[i].TOTAL_ATE;
                        if (resu < 0) {
                            resu = 0;
                        }
                        return resu;
                    });


                    if (Mx_Dtt[i].TOTAL_ATE == 0) {
                        $('#BtnSaveAll').attr("disabled", false);
                    } else {
                        uu = Mx_Dtt[i].CONF_DIAS_EXA_BUSCA_DIAS - Mx_Dtt[i].TOTAL_ATE;
                        if (uu <= 0) {
                            $('#BtnSaveAll').attr("disabled", true);
                        } else {
                            $('#BtnSaveAll').attr("disabled", false);
                        }
                    }
                }
            }
        }
        function Fill_DL_Rut() {
            $('#rut').attr("disabled", true);
            $("#Nom").val(Mx_Dtt2[0].PAC_NOMBRE);
            $("#Ape").val(Mx_Dtt2[0].PAC_APELLIDO);
            $("#fecha").val(Mx_Dtt2[0].PAC_FNAC);
            $("#Edad").val(function () {
                var asd = $("#fecha").val();
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
            for (y = 0; y < Mx_Ddl.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl[y].ID_PROCEDENCIA
                }).text(Mx_Ddl[y].PROC_DESC).appendTo("#Procedencia");
            }
            var ur = getParameterByName('kl');
            $("#Procedencia").val(ur);
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

            if ($("#sex").val() != 0) {
                var posicion = 0;
                if ($("#sex").val() == 1) {
                    for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                        if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 1026) {
                            posicion = x;
                        }
                    }
                    Mx_Dtt_exam02.splice(posicion, 1);
                } else {
                    for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                        if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 66) {
                            posicion = x;
                        }
                    }

                    Mx_Dtt_exam02.splice(posicion, 1);
                }
            }
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
            $('#DataTable_pac').DataTable({
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>"
                }
            })
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
                           "class": "textoReducido td_val2"
                       }).text(Mx_Dtt_examcof[i].CF_DIAS),
                       $("<td>", {
                           "align": "center"
                       }).html("<button type='button' class='btn btn-default btn-xs borrar' value='Eliminar' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>")
                    )
                )
            }
            add_row();
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
                    $("input[data-id='" + xxid + "']").attr("data-cod", Mx_Dtt_exam03[0].CF_COD);
                    $("input[data-cod='" + Mx_Dtt_exam03[0].CF_COD + "']").attr("data-id", Mx_Dtt_exam03[0].ID_CODIGO_FONASA);
                    Mx_Dtt_examcof.push(Mx_Dtt_exam03[0]);
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
    </script>
    <style>
        .clockPicker input[type=text] {
            background: #ffffff;
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
            width: 40%;
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

        @media screen and (min-width: 558px) {
            .topbuttom2 {
                width: 100%;
            }
        }
    </style>

    <!--Felipe estuvo aquí :^)-->
    <!--Nueva Rama-->
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

    <div class="modal fade" id="eModal2" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Agregar Exámenes</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="col-md-12">
                            <div id="Div_Tabla2" style="width: 100%;" class="highlights2"></div>
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
    <div class="row">
        <div class="col-md-12">
            <h5 style="text-align: center; padding: 5px;">
                <i class="fa fa-sign-in"></i>
                Pre-Ingresos de Exámenes
            </h5>
        </div>
    </div>
    <div class="card border-bar">
        <div class="container" style="max-width: 100%;">
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-sm">
                            <label class="textoReducido">RUT:</label>
                            <input type='text' id="rut" class="form-control textoReducido" placeholder="12.345.789-0" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Nombres:</label>
                            <input type='text' id="Nom" class="form-control textoReducido" placeholder="" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Apellidos:</label>
                            <input type='text' id="Ape" class="form-control textoReducido" placeholder="" />
                        </div>
                        <%--     </div>
                        <div class="row">--%>
                        <div class="col-sm">
                            <label class="textoReducido">F.Nacimiento:</label>
                            <div class='input-group date' id='datetimepicker1' style="margin-bottom: 1vh;">
                                <input type='text' id="fecha" class="form-control textoReducido" readonly="true" placeholder="Fecha" />
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
                            <script type="text/javascript">
                                ////////////////////////////////////
                                ////////////////////////////////////
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
                            </script>
                        </div>

                        <div class="col-sm">
                            <label class="textoReducido">Edad:</label>
                            <input type='text' id="Edad" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="text-align: center;" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Sexo:</label>
                            <select id="sex" class="form-control textoReducido" style="height: 31.75px;">
                            </select>
                        </div>
                        <div class="col-sm checkbox checkbox-success">
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
                                    $('#datetimepicker3').datetimepicker({
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
                                    });




                                });
                            </script>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 10px;">
                        <div class="col-sm">
                            <label class="textoReducido">Nacionalidad:</label>
                            <select id="Nacio" class="form-control textoReducido" style="height: 31.75px;">
                                <option value="volvo">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Tel. Fijo:</label>
                            <input type='text' id="telfijo" class="form-control textoReducido" placeholder="" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Celular:</label>
                            <input type='text' id="Celular" class="form-control textoReducido" placeholder="" />
                        </div>
                        <div>
                            <div class="row">
                                <div class="col-sm">
                                    <label class="textoReducido">Ciudad:</label>
                                    <select id="Cuidad" class="form-control textoReducido" style="height: 31.75px;">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>

                                <div class="col-sm">
                                    <label class="textoReducido">Comuna:</label>
                                    <select id="Comuna" class="form-control textoReducido" style="height: 31.75px;">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                                <div class="col-sm">
                                    <label class="textoReducido">Dirección:</label>
                                    <input type='text' id="direccion" class="form-control textoReducido" placeholder="" />
                                </div>
                                <div class="col-sm">
                                    <label class="textoReducido">Email:</label>
                                    <input type='text' id="Email" class="form-control textoReducido" placeholder="Irislab@irislab.cl" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Breadcrumbs -->
    <div class="row">
        <div class="col-md-12">
            <h6 style="text-align: center; padding: 5px;">Antecedentes de la Atención
            </h6>
        </div>
    </div>
    <div class="card border-bar">
        <div class="container" style="max-width: 100%;">
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-sm">
                            <label class="textoReducido">Procedencia:</label>
                            <select id="Procedencia" class="form-control textoReducido" style="height: 31.75px;" disabled="disabled">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-sm">
                            <label for="fecha2" class="textoReducido">Fecha Pre-Ingreso:</label>
                            <div class='input-group date' id='datetimepicker2' style="margin-bottom: 1vh;">
                                <input type='text' id="fecha2" class="form-control textoReducido" readonly="true" placeholder="Fecha" />
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
                        </div>

                        <div class="col-sm">
                            <label class="textoReducido">Total:</label>
                            <input type='text' id="Total" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="background-color: yellow; text-align: center;" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Actuales:</label>
                            <input type='text' id="Actuales" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="background-color: #f4abe7; text-align: center;" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Disponibles:</label>
                            <input type='text' id="Disponibles" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="background-color: chartreuse; text-align: center;" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Programa:</label>
                            <select id="Programa" class="form-control textoReducido" style="height: 31.75px;">
                                <option value="volvo">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Sector:</label>
                            <select id="Sector" class="form-control textoReducido" style="height: 31.75px;">
                                <option value="volvo">Seleccionar</option>
                            </select>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 10px;">
                        <div class="col-sm">
                            <label class="textoReducido">Hora Cita:</label>
                            <!--Clockpicker-->
                            <div class='input-group clockPicker' id='txtClock' style="margin-bottom: 1vh;" data-align="top" data-autoclose="true">
                                <input type="text" class="form-control" value="08:00" readonly="true" />
                                <span class="input-group-addon">
                                    <i class="fa fa-clock-o"></i>
                                </span>
                            </div>

                            <script type="text/javascript">
                                $('#txtClock').clockpicker();
                            </script>
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Tipo de Atención:</label>
                            <select id="TipoAtencion" class="form-control textoReducido" style="height: 31.75px;">
                                <option value="volvo">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Prioridad TM:</label>
                            <select id="PrioridadTM" class="form-control textoReducido" style="height: 31.75px;">
                                <option value="volvo">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Doctor:</label>
                            <select id="Doctor" class="form-control textoReducido" style="height: 31.75px;">
                                <option value="volvo">Seleccionar</option>
                            </select>
                        </div>
                        <%--   </div>
                         <div class="row">--%>
                        <div class="col-sm">
                            <label class="textoReducido">Previsión:</label>
                            <select id="Prevision" class="form-control textoReducido" style="height: 31.75px;">
                                <option value="volvo">Seleccionar</option>
                            </select>
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

    <!-- Breadcrumbs -->
    <div class="row">
        <div class="col-md-12">
            <h6 style="text-align: center; padding: 5px;">Agregar Exámenes
            </h6>
        </div>
    </div>
    <div class="card border-bar">
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
    </div>
    <div class="card border-bar">
        <div class="container" style="max-width: 100%; border: 0px solid #fff;">
            <div class="row">
                <div class="col-sm-3">
                    <button id="Examen" type="button" class="btn btn-danger topbuttom2">
                        <i class="fa fa-align-left" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                        <p style="margin-top: 2px;">Examen</p>
                    </button>
                </div>
                <div class="col-sm-3">
                </div>
                <div class="col-sm-3" style="justify-content: flex-end;">
                    <button id="Btnnew" type="button" class="btn btn-info topbuttom">
                        <i class="fa fa-plus-square" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                        <p style="margin-top: 2px;">Nuevo</p>
                    </button>
                </div>
                <div class="col-sm-3">
                    <button id="BtnSaveAll" type="button" class="btn btn-primary topbuttom">
                        <i class="fa fa-fw fa-save mr-2" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                        <p style="margin-top: 2px;">Guardar</p>
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

