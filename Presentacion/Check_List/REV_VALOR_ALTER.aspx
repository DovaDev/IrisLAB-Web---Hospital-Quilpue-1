<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="REV_VALOR_ALTER.aspx.vb" Inherits="Presentacion.REV_VALOR_ALTER" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script>
        $(document).ready(function () {
            $("#Id_Conte").hide();
            Ajax_Prevision();
            Ajax_Exam();
            Call_Data_Ddl_Stat();
            Ajax_Ddl();
            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input").val(dateNow);
            $('#Txt_Date01').datetimepicker(
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
                    minView: 2
                }
            );


            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date02 input").val(dateNow);
            $('#Txt_Date02').datetimepicker(
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
                    minView: 2
                }
            );

            $("#Div_Tabla").empty();

            //Registrar evento Click del Botón Buscar       
            $("#Btn_Buscar").click(function () {
                //if ($("#DdlPrevision").val() == 0) {
                //    $("#mError_AAH h4").text("Seleccione:");
                //    $("#mError_AAH button").attr("class", "btn btn-danger");
                //    $("#mError_AAH p").text("Por favor, seleccione una previsión.");
                //    $("#mError_AAH").modal();
                //} else {
                    $("#Div_Tabla").empty();
                    Call_Data_Table();
                //}
            });

            $("#Btn_Excel").click(function () {
                if ($("#DdlPrevision").val() == 0) {
                    $("#mError_AAH h4").text("Seleccione:");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione una previsión.");
                    $("#mError_AAH").modal();
                } else {
                    Call_Export();
                }
            });

        });
    </script>
    <script>
        var Mx_Ddl123 = [
           {
               "ID_RLS_LS": 0,
               "ID_LABO": 0,
               "ID_SECCION": 0,
               "RLS_LS_DESC": "dddd",
               "ID_ESTADO": 0
           }
        ];
        function Ajax_Ddl() {

            $.ajax({
                "type": "POST",
                "url": "REV_VALOR_ALTER.aspx/Llenar_Ddl_22",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl123 = JSON.parse(json_receiver);
                        Fill_Ddl();
                        $(".block_wait").hide();

                    } else {

                    }
                },
                "error": function (response) {


                }
            });
        }

        //-------------------------------------------------- AJAX DDL PREVISIÓN ---------------------------------------------|
        var Mx_Dtt_Prevision = [
    {
        "ID_PREVE": 0,
        "PREVE_COD": 0,
        "PREVE_DESC": 0,
        "ID_ESTADO": 0
    }
        ];

        function Ajax_Prevision() {
            modal_show();

            $.ajax({
                "type": "POST",
                "url": "Val_Criticos.aspx/Llenar_Ddl_Prevision",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Prevision = JSON.parse(json_receiver);
                        Fill_Ddl_Prevision();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda solicitada.");
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

        //------------------------------------------------ AJAX DDL EXAMEN -------------------------------------------|
        var Mx_Exam = [
    {
        "ID_CODIGO_FONASA": 0,
        "CF_DESC": 0,
        "ID_ESTADO": 0
    }
        ];

        function Ajax_Exam() {

            $.ajax({
                "type": "POST",
                "url": "Val_Criticos.aspx/Llenar_Ddl_Exam",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Exam = JSON.parse(json_receiver);

                        Fill_Ddl_Exam();
                        Hide_Modal();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda solicitada");
                        $("#mError_AAH").modal();
                    }
                },
                "error": function (response) {

                }
            });
        }

        //-------------------------------------------------- AJAX ESTADO -------------------------------------------------------
        var AJAX_Ddl_Stat = 0;

        function Call_Data_Ddl_Stat() {
            modal_show();

            AJAX_Ddl_Stat = $.ajax({
                "type": "POST",
                "url": "Val_Criticos.aspx/Call_Ddl_Stat",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    JSON_Ddl_Stat = JSON.parse(response.d);
                    Hide_Modal();
                    Fill_Ddl_Stat();
                },
                "error": function (response) {

                    Hide_Modal();

                }
            });
        }

        var JSON_Data_Table = [{
            "PAC_RUT": "",
            "PAC_NOMBRE": "",
            "PAC_APELLIDO": "",
            "PAC_FNAC": "",
            "PRU_DESC": "",
            "CF_DESC": "",
            "ATE_AÑO": "",
            "ID_PACIENTE": "",
            "ATE_NUM": "",
            "ATE_FECHA": "",
            "ATE_RESULTADO": "",
            "ID_ATENCION": "",
            "ATE_RESULTADO_NUM": "",
            "ATE_RR_DESDE": "",
            "ATE_RR_HASTA": "",
            "ATE_RR_ALTOBAJO": "",
            "ATE_R_DESDE": "",
            "ATE_R_HASTA": "",
            "ATE_RESULTADO_ALT": "",
            "PROC_DESC": "",
            "ORD_DESC": "",
            "ATE_EST_VALIDA": "",
            "ID_CODIGO_FONASA": "",
            "ATE_DNI": "",
            "NAC_DESC": "",
            "PROGRA_DESC": "",
            "SECTOR_DESC": "",
            "ATE_NUM_INTERNO": "",
            "DOC_NOMBRE": "",
            "DOC_APELLIDO": ""
        }];


        function Call_Data_Table() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DATE_str01": String($("#fecha").val()),
                "DATE_str02": String($("#fecha2").val()),
                "ID_EXAM": String($("#Ddl_Exam").val()),
                "ID_PREV": String($("#DdlPrevision").val()),
                "ID_STAT": String($("#Ddl_Stat").val()),
                "SECCION": String($("#Ddl_seccion").val())
            });

            $(".block_wait").fadeIn(500);
            AJAX_Data_Table = $.ajax({
                "type": "POST",
                "url": "REV_VALOR_ALTER.aspx/Call_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    if (response.d != "null") {
                        JSON_Data_Table = JSON.parse(response.d);
                        Hide_Modal();
                        $("#Id_Conte").show();

                        //for (i = 0; i < JSON_Data_Table.length; ++i) {
                        //    var date_x = JSON_Data_Table[i].PAC_FNAC;
                        //    date_x = String(date_x).replace("/Date(", "");
                        //    date_x = date_x.replace(")/", "");
                        //    var Date_Change = new Date(parseInt(date_x));
                        //    JSON_Data_Table[i].PAC_FNAC = Date_Change;
                        //}

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


        function Call_Export() {
            modal_show();
            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DATE_str01": String($("#fecha").val()),
                "DATE_str02": String($("#fecha2").val()),
                "ID_EXAM": String($("#Ddl_Exam").val()),
                "ID_PREV": String($("#DdlPrevision").val()),
                "ID_STAT": String($("#Ddl_Stat").val()),
                "SECCION": String($("#Ddl_seccion").val())
            });

            AJAX_Data_Table = $.ajax({
                "type": "POST",
                "url": "REV_VALOR_ALTER.aspx/Call_Export",
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

    </script>

    <script>

        //Llenar DropDownList Examen
        function Fill_Ddl_Exam() {
            $("#Ddl_Exam").empty();

            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Exam");
            for (y = 0; y < Mx_Exam.length; ++y) {
                // if (Mx_Exam[y].ID_CODIGO_FONASA != 682) {
                $("<option>", {
                    "value": Mx_Exam[y].ID_CODIGO_FONASA
                }).text(Mx_Exam[y].CF_DESC).appendTo("#Ddl_Exam");
                // }

            }

        };

        //Llenar DropDownList Prevision
        function Fill_Ddl_Prevision() {
            $("#DdlPrevision").empty();

            $("<option>", { "value": 0 }).text("Todos").appendTo("#DdlPrevision");
            for (y = 0; y < Mx_Dtt_Prevision.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_Prevision[y].ID_PREVE
                }).text(Mx_Dtt_Prevision[y].PREVE_DESC).appendTo("#DdlPrevision");
            }
        };
        //Llenar DropDownList Estado
        function Fill_Ddl_Stat() {
            $("#Ddl_Stat").empty();

            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#Ddl_Stat");
            for (y = 0; y < JSON_Ddl_Stat.length; ++y) {
                $("<option>", {
                    "value": JSON_Ddl_Stat[y].Value
                }).text(JSON_Ddl_Stat[y].Text).appendTo("#Ddl_Stat");
            }

        }
        function Fill_Ddl() {
            $("#Ddl_seccion").empty();
            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#Ddl_seccion");
            for (y = 0; y < Mx_Ddl123.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl123[y].ID_RLS_LS
                }).text(Mx_Ddl123[y].RLS_LS_DESC).appendTo("#Ddl_seccion");
            }
        };
    </script>

    <script>

        //---------------------------------------------------- TABLA PACIENTE ------------------.........-----------------------------|
        function Fill_DataTable() {
            $("<table>", {
                "id": "DataTable",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla");

            $("#DataTable").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable thead").attr("class", "cabezera");
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido  text-center" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido  text-center" }).text("Rut o D.N.I"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Nacionalidad"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Nac"),
                    $("<th>", { "class": "textoReducido  text-center" }).text("Edad"),
                    $("<th>", { "class": "textoReducido  text-center" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar de TM"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Num Interno"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Programa"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Sector"),
                    $("<th>", { "class": "textoReducido" }).text("Determinación"),
                    $("<th>", { "class": "textoReducido" }).text("Resultado"),
                    $("<th>", { "class": "textoReducido" }).text("Médico"),
                    $("<th>", { "class": "textoReducido" }).text("Alarma"),
                    $("<th>", { "class": "textoReducido  text-center" }).text("Muy Bajo"),
                    $("<th>", { "class": "textoReducido  text-center" }).text("Bajo"),
                    $("<th>", { "class": "textoReducido  text-center" }).text("Alto"),
                    $("<th>", { "class": "textoReducido  text-center" }).text("Muy Alto")

                )
            );
            var procee = Galletas.getGalleta("USU_TM");
            var admin = Galletas.getGalleta("P_ADMIN");

                for (i = 0; i < JSON_Data_Table.length; i++) {

                    $("#DataTable tbody").append(
                        $("<tr>").append(
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].ATE_NUM),
                                             $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {

                                                 if (JSON_Data_Table[i].PAC_NOMBRE == "") {
                                                     return JSON_Data_Table[i].ATE_DNI;
                                                 } else {
                                                     return JSON_Data_Table[i].PAC_RUT;
                                                 }
                                             }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].NAC_DESC),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].PAC_NOMBRE + " " + JSON_Data_Table[i].PAC_APELLIDO),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                                //Procesar datos de entrada
                                var date_xd = $.extend({}, JSON_Data_Table[i]).PAC_FNAC;
                                date_xd = String(date_xd).replace("/Date(", "");
                                date_xd = date_xd.replace(")/", "");

                                //Obtener valores
                                var obj_date = new Date(parseInt(date_xd));
                                var dd = parseInt(obj_date.getDate());
                                var MM = parseInt(obj_date.getMonth()) + 1;
                                var yy = parseInt(obj_date.getFullYear());

                                if (dd < 10) { dd = "0" + dd; }
                                if (MM < 10) { MM = "0" + MM; }

                                //var hh = parseInt(obj_date.getHours());
                                //var mm = parseInt(obj_date.getMinutes());

                                //if (hh < 10) { dd = "0" + dd; }
                                //if (mm < 10) { MM = "0" + MM; }

                                return String(dd + "/" + MM + "/" + yy);
                                //return String(dd + "/" + mm + "/" + yy + " " + hh + ":" + mm);
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                                var date_x = $.extend({}, JSON_Data_Table[i]).PAC_FNAC;
                                date_x = String(date_x).replace("/Date(", "");
                                date_x = date_x.replace(")/", "");

                                var total = ""
                                //Obtener valores
                                var obj_date = new Date(parseInt(date_x));
                                var dia = parseInt(obj_date.getDate());
                                var mes = parseInt(obj_date.getMonth()) + 1;
                                var ano = parseInt(obj_date.getFullYear());

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
                                if (ahora_mes > mes) {
                                    meses = ahora_mes - mes;
                                }
                                if (ahora_mes < mes) {
                                    meses = 12 - (mes - ahora_mes);
                                }
                                if (ahora_mes == mes && dia > ahora_dia) {
                                    meses = 11;
                                }

                                // calculamos los dias
                                var dias = 0;
                                total = String(edad + " Años " + meses + " Meses " + dias + " Dias");
                                if (ahora_dia > dia) {
                                    dias = ahora_dia - dia;
                                    total = String(edad + " Años " + meses + " Meses " + dias + " Dias");
                                }
                                if (ahora_dia < dia) {
                                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                                    total = String(edad + " Años " + meses + " Meses " + dias + " Dias");
                                }
                                return total;
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                                //Procesar datos de entrada
                                var date_x = $.extend({}, JSON_Data_Table[i]).ATE_FECHA;
                                date_x = String(date_x).replace("/Date(", "");
                                date_x = date_x.replace(")/", "");

                                //Obtener valores
                                var obj_date = new Date(parseInt(date_x));
                                var dd = parseInt(obj_date.getDate());
                                var MM = parseInt(obj_date.getMonth()) + 1;
                                var yy = parseInt(obj_date.getFullYear());

                                if (dd < 10) { dd = "0" + dd; }
                                if (MM < 10) { MM = "0" + MM; }

                                //var hh = parseInt(obj_date.getHours());
                                //var mm = parseInt(obj_date.getMinutes());

                                //if (hh < 10) { dd = "0" + dd; }
                                //if (mm < 10) { MM = "0" + MM; }

                                return String(dd + "/" + MM + "/" + yy);
                                //return String(dd + "/" + mm + "/" + yy + " " + hh + ":" + mm);
                            }),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].PROC_DESC),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].ATE_NUM_INTERNO),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].PROGRA_DESC),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].SECTOR_DESC),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].PRU_DESC),
                            $("<td>").css("text-align", "left").text(function () {
                                //Declaraciones
                                var Res_Num = JSON_Data_Table[i].ATE_RESULTADO_NUM;
                                var Res_Str = JSON_Data_Table[i].ATE_RESULTADO;
                                var Res_Alt = JSON_Data_Table[i].ATE_RESULTADO_ALT;

                                //Evaluar
                                if (Res_Num != 0) {
                                    return Res_Num;
                                } else if (Res_Str != "") {
                                    return Res_Str;
                                } else {
                                    return Res_Alt;
                                }
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].DOC_NOMBRE + " " + JSON_Data_Table[i].DOC_APELLIDO),
                            $("<td>").css("text-align", "center").text(JSON_Data_Table[i].ATE_RESULTADO_ALT),
                           $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].ATE_RR_DESDE),
                           $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].ATE_R_DESDE),
                           $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].ATE_R_HASTA),
                           $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].ATE_RR_HASTA)
                        )
                    );

                }
                $("#DataTable").DataTable({
                    "bSort": true,
                    "iDisplayLength": 100,
                    "info": true,
                    "bPaginate": true,
                    //"bFilter": false,
                    "language": {
                        "lengthMenu": "Mostrar: _MENU_",
                        "zeroRecords": "No hay coincidencias",
                        "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                        "infoEmpty": "No hay concidencias",
                        "infoFiltered": "(Se buscó en _MAX_ registros )",
                        "search": "<strong><i class='fa fa-search'></i>Buscar: </strong>",
                        "paginate": {
                            "previous": "Anterior",
                            "next": "Siguiente"
                        }
                    }
                });

        }

    </script>

    <style>
        .progress-bar.animate {
            width: 100%;
        }

        #DataTable tbody td {
            text-transform: uppercase;
        }

        .mrgn {
            margin-left: 20px;
            margin-right: 20px;
        }

        #btnFichaAcceso {
            margin-bottom: 1vh;
        }

        #i {
            display: flex;
            flex-flow: row nowrap;
        }

        .manito {
            cursor: pointer;
        }

        .cabezera {
            background: #46963f;
            color: white;
        }

        .cabezera2 {
            background: #081f44;
            color: white;
        }

        .textoReducido {
            font-size: 12px;
        }

        .mayus {
            text-transform: uppercase;
        }

        .highlights {
            width: 90%;
            max-height: 70vh; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .highlights2 {
            width: 710px;
            height: 404px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
        }

        @media screen and (max-width: 600px) {
            .flexon {
                display: flex;
                flex-flow: column;
                width: 90vw;
            }

            .flx {
                flex: 1;
                max-width: 100%;
            }

            .highlights {
                height: 100%;
            }

            .buttons {
                display: flex;
                flex-flow: column;
            }

            #Btn_Buscar_x_ate {
                width: 90vw;
                margin-left: -12px;
            }
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <!-- Modal -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <%------------------------------------------------------TÍTULO, TEXTBOX Y BOTONES-----------------------------------------%>
    <div class="row">
        <div class="col-lg">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar">
                    <h5 style="text-align: center; padding: 5px;">
                        <i class="fa fa-fw fa-edit"></i>
                        Revisión de Valores Alterados Validados
                    </h5>
                </div>
                <div class="card-body">
                    <div class="row" style="margin-left: 2px; margin-right: 2px;">
                    <div class="col-md mb-1">
                        <label for="fecha">Desde:</label>
                        <div class='input-group date' id='Txt_Date01'>
                            <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-md mb-1">
                        <label for="fecha">Hasta:</label>
                        <div class='input-group date' id='Txt_Date02'>
                            <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-md mb-1">
                        <label for="Ddl_Exam">Examen:</label>
                        <select id="Ddl_Exam" class="form-control">
                        </select>
                    </div>
                    <div class="col-md mb-1">
                        <label for="DdlPrevision">Previsión:</label>
                        <select id="DdlPrevision" class="form-control">
                        </select>
                    </div>
                    <div class="col-md mb-1">
                        <label for="Ddl_Stat">Estado:</label>
                        <select id="Ddl_Stat" class="form-control">
                        </select>
                    </div>
                    <div class="col-md mb-1">
                        <label for="Ddl_Stat">Sección:</label>
                        <select id="Ddl_seccion" class="form-control">
                        </select>
                    </div>
                    <div class="col-md mb-1">
                        <br class="mb-1" />
                        <button id="Btn_Buscar" class="btn btn-buscar btn-block" type="submit"><i class="fa fa-fw fa-search "></i>Buscar</button>
                    </div>
                    <div class="col-md mb-1">
                        <br class="mb-1" />
                        <button id="Btn_Excel" class="btn btn-success btn-block" type="submit"><i class="fa fa-fw fa-file-excel-o "></i>Excel</button>
                    </div>
                </div>
                </div>
                

                <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
                
            </div>
            <div class="row" id="Id_Conte" style="margin-left: 1px; width: 100%;">
                    <div class="col-lg-12 text-center">
                        <h5><i class="fa fa-fw fa-list"></i>Resultados de la Búsqueda</h5>
                        <div class="row text-center" id="Paciente">
                            <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
                        </div>
                    </div>
                </div>
        </div>
    </div>
</asp:Content>
