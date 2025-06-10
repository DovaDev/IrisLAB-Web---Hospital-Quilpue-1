﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="OrdenAtencion_Sum.aspx.vb" Inherits="Presentacion.OrdenAtencion_Sum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true"%>

    <%--Esto es para que funcione el gráfico--%>
<%--    <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>--%>
    <script src="../../../js/HighCharts.js"></script>
 <script src="../../../js/HighC_Exporting.js"></script>

    <script src="/js/Custom_Objects.js"></script>


    <script>
        $(document).ready(function () {
            $("#Id_conte").hide();
            //---------------------------------------- Date Pickers ----------------------------------------------|
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
            //Ajustes Visuales
            $(".block_wait").hide();
            $("#Div_Tabla").empty().css({ "background": "#ffffff" });
            $("#Div_Tabla").append(
                $("<div>").css({
                    "width": "calc(100% - 60)",
                    "text-align": "center",
                    "padding": "30px",
                    "font-size": "30px",
                    "font-weight": 900
                }).text("Realice su Búsqueda.")
            );

            //Llamar al llenado de los DropDownList
            Ajax_Ddl();

            //Registrar evento Click del Botón Buscar
            $("#Btn_Search").click(function () {
                function restaFechas(f1, f2) {
                    var aFecha1 = f1.split('-');
                    var aFecha2 = f2.split('-');
                    var fFecha1 = Date.UTC(aFecha1[2], aFecha1[1] - 1, aFecha1[0]);
                    var fFecha2 = Date.UTC(aFecha2[2], aFecha2[1] - 1, aFecha2[0]);
                    var dif = fFecha2 - fFecha1;
                    var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
                    return dias;
                }

                var Date_Diff = restaFechas(String($("#Txt_Date01 input").val()), String($("#Txt_Date02 input").val()));

                if (Date_Diff <= 31) {
                    Ajax_DataTable();

                } else {
                    $("#mError_AAH h4").text("Rango de Fechas");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione un rango de fechas menor a 30 días.");
                    $("#mError_AAH").modal();
                }
            });

            $("#Btn_Export").click(function () {
                Ajax_Excel();
            });
        });
    </script>
    <%-- Peticiones AJAX --%>

    <script>
        //Json de llenado de DropDownList
        var Mx_Ddl = [
            {
                "ID_ORDEN": 0,
                "ORD_COD": "asdf",
                "ORD_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];

        function Ajax_Ddl() {



            $.ajax({
                "type": "POST",
                "url": "OrdenAtencion_Sum.aspx/Llenar_Ddl",
                //"data": '{}'
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Ddl = json_receiver;

                        Fill_Ddl();


                    } else {


                    }
                },
                "error": function (response) {
                    alert("Error en la Recepción de Datos");


                }
            });
        }
        //Json de llenado de DataTable
        var Mx_Dtt = [
            {
                "TOTAL_ATE": 0,
                "TOTAL_PREVE": 0,
                "TOT_FONASA": 0,
                "TOTA_SIS": 0,
                "TOTA_USU": 0,
                "TOTA_COPA": 0,
                "ID_ORDEN": 0,
                "ORD_DESC": ""
            }
        ];

        function Ajax_DataTable() {
            modal_show();



            var Data_Par = JSON.stringify({
                "ID_PREV": $("#DdlOrdenes").val(),
                "DATE_str01": $("#Txt_Date01 input").val(),
                "DATE_str02": $("#Txt_Date02 input").val()
            });

            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "OrdenAtencion_Sum.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt = json_receiver;

                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].ATE_FECHA = Date_Change;
                        }

                        Hide_Modal();
                        $("#Id_conte").show();
                        Fill_DataTable();



                    } else {


                        $("#mError_AAH h4").text("Sin Resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda seleccionada.");
                        $("#mError_AAH").modal();
                        Hide_Modal();
                        $("#Div_Tabla").empty().css({ "background": "#c30000" });
                        $("#Div_dinero").empty().css({ "background": "#ffffff" });
                        $("#Summary_Graph").empty().css({ "background": "#ffffff" });
                        $("#Div_Tabla_Total").empty().css({ "background": "#ffffff" })
                        $("#Div_Tabla").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",
                                "font-weight": 900,
                                "color": "#ffffff"
                            }).text("Sin Resultados.")
                        );
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    alert("Error en la Recepción de Datos");


                }
            });
        }

        //Generar Excel
        function Ajax_Excel() {
            modal_show();



            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "ID_PREV": $("#DdlOrdenes").val(),
                "DATE_str01": $("#Txt_Date01 input").val(),
                "DATE_str02": $("#Txt_Date02 input").val()
            });

            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "OrdenAtencion_Sum.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    $(".block_wait").fadeOut(500);

                    if (json_receiver != "null") {
                        window.open(json_receiver, 'Download');
                        Hide_Modal();


                    } else {
                        $("#mError_AAH h4").text("Sin Resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para exportar.");
                        $("#mError_AAH").modal();
                        Hide_Modal();


                    }
                },
                "error": function (response) {
                    alert("Error en procesar datos");


                    Hide_Modal();
                }
            });
        }
    </script>
     <%-- Funciones de Llenado de Elementos --%>
    <script>
        //Llenar DropDownList
        function Fill_Ddl() {
            $("#DdlOrdenes").empty();

            $("<option>", {
                "value": 0
            }).text("Todas").appendTo("#DdlOrdenes");
            for (y = 0; y < Mx_Ddl.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl[y].ID_ORDEN
                }).text(Mx_Ddl[y].ORD_DESC).appendTo("#DdlOrdenes");
            }
        };
        //Llenar DataTable
        function Fill_DataTable() {
            $("#Div_Tabla").empty().css({ "background": "#ffffff" });

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
                    $("<th>", { "class": "text-center" }).text("#"),
                    $("<th>").text("Prioridad TM"),
                    $("<th>", { "class": "text-center" }).text("Cant. Atenciones"),
                    $("<th>", { "class": "text-center" }).text("Cant. Exámenes"),
                    $("<th>").text("Total Sistema"),
                    $("<th>").text("Total Usuarios"),
                    $("<th>").text("Total Copago"),
                    $("<th>").text("Total Pagado")
                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>").text(Mx_Dtt[i].ORD_DESC),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].TOTAL_ATE),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].TOT_FONASA),
                        $("<td>").text("$ " + cFormat.numToString(Mx_Dtt[i].TOTA_SIS, 0, ".", ",")),
                        $("<td>").text("$ " + cFormat.numToString(Mx_Dtt[i].TOTA_USU, 0, ".", ",")),
                        $("<td>").text("$ " + cFormat.numToString(Mx_Dtt[i].TOTA_COPA, 0, ".", ",")),
                        $("<td>").text("$ " + cFormat.numToString(parseFloat(Mx_Dtt[i].TOTA_USU) + parseFloat(Mx_Dtt[i].TOTA_COPA), 0, ".", ","))
                    )
                );
            }

            //LLENADO TABLA TOTALES

            $("#Div_Tabla_Total").empty().css({ "background": "#ffffff" });

            $("<table>", {
                "id": "DataTableTotal",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Total");

            $("#DataTableTotal").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTableTotal").attr("class", "table table-hover table-striped table-iris");
            $("#DataTableTotal thead").attr("class", "cabezera");
            $("#DataTableTotal thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "text-center" }).text("Cant. Atenciones"),
                    $("<th>", { "class": "text-center" }).text("Cant. Exámenes"),
                    $("<th>").text("Total Sistema"),
                    $("<th>").text("Total Usuarios"),
                    $("<th>").text("Total Copago"),
                    $("<th>").text("Total Pagado")
                )
            );
            var T_Ate = 0;
            var T_Exa = 0;
            var T_Sis = 0;
            var T_Usu = 0;
            var T_Cop = 0;
            var T_Pag = 0;

            for (i = 0; i < Mx_Dtt.length; i++) {

                T_Ate = parseFloat(T_Ate) + parseFloat(Mx_Dtt[i].TOTAL_ATE);
                T_Exa = parseFloat(T_Exa) + parseFloat(Mx_Dtt[i].TOT_FONASA);
                T_Sis = parseFloat(T_Sis) + parseFloat(Mx_Dtt[i].TOTA_SIS);
                T_Usu = parseFloat(T_Usu) + parseFloat(Mx_Dtt[i].TOTA_USU);
                T_Cop = parseFloat(T_Cop) + parseFloat(Mx_Dtt[i].TOTA_COPA);
                T_Pag = parseFloat(T_Pag) + parseFloat(Mx_Dtt[i].TOTA_USU) + parseFloat(Mx_Dtt[i].TOTA_COPA);
            }
            $("#DataTableTotal tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(T_Ate),
                        $("<td>", { "align": "center" }).text(T_Exa),
                        $("<td>").text("$ " + cFormat.numToString(T_Sis, 0, ".", ",")),
                        $("<td>").text("$ " + cFormat.numToString(T_Usu, 0, ".", ",")),
                        $("<td>").text("$ " + cFormat.numToString(T_Cop, 0, ".", ",")),
                        $("<td>").text("$ " + cFormat.numToString(T_Pag, 0, ".", ","))
                    )
                );

            var arr = ["Array"];
            var arr1 = [0];
            var arr2 = [0];
            for (i = 0; i < Mx_Dtt.length; i++) {
                if (i == 0) {
                    arr.pop();
                    arr1.pop();
                    arr2.pop();
                }
                arr.push(Mx_Dtt[i].ORD_DESC);
                arr1.push(parseFloat(Mx_Dtt[i].TOTAL_ATE));
                arr2.push(parseFloat(Mx_Dtt[i].TOT_FONASA));
            }
            Highcharts.chart('Summary_Graph', {

                title: {
                    text: ''
                },

                subtitle: {
                    text: ''
                },

                xAxis: {
                    categories: arr
                },
                yAxis: {
                    title: {
                        text: 'Ventas'
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },

                series: [{
                    name: 'Cantidad Atenciones',
                    data: arr1
                }, {
                    name: 'Cantidad Exámenes',
                    data: arr2
                }]

            });

            var AR_pro = [0];
            var ARTota_sis = [0];
            var ARTota_usu = [0];
            var ARTota_Copa = [0];
            var ARTota_Tota_pago = [0];
            for (i = 0; i < Mx_Dtt.length; i++) {
                if (i == 0) {
                    AR_pro.pop();
                    ARTota_sis.pop();
                    ARTota_usu.pop();
                    ARTota_Copa.pop();
                    ARTota_Tota_pago.pop();
                }
                AR_pro.push(Mx_Dtt[i].ORD_DESC);
                ARTota_sis.push(parseFloat(Mx_Dtt[i].TOTA_SIS));
                ARTota_usu.push(parseFloat(Mx_Dtt[i].TOTA_USU));
                ARTota_Copa.push(parseFloat(Mx_Dtt[i].TOTA_COPA));
                ARTota_Tota_pago.push(parseFloat(Mx_Dtt[i].TOTA_USU) + parseFloat(Mx_Dtt[i].TOTA_COPA));
            }
            Highcharts.chart('Div_dinero', {

                title: {
                    text: ''
                },

                subtitle: {
                    text: ''
                },

                xAxis: {
                    categories: AR_pro
                },
                yAxis: {
                    title: {
                        text: 'Ventas'
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },

                series: [{
                    name: 'Total Sistema',
                    data: ARTota_sis
                }, {
                    name: 'Total Usuarios',
                    data: ARTota_usu
                }, {
                    name: 'Total Copago',
                    data: ARTota_Copa
                }, {
                    name: 'Total Pagado',
                    data: ARTota_Tota_pago
                }]

            });
        }
    </script>
             <%-- CSS Personalizado --%>
    <style>
        .div_main p {margin: 0;}
        .cabezera {
            background: #46963f;
            color: white;
        }
        .cabezera2 {
            background: #081f44;
            color: white;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
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

    <div class="flex_col">
        <div class="card mb-3 border-bar">
        <div class="card-header bg-bar p-2">
            <h5>Resumen de Prioridad TM</h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
            <label for="fecha">Desde:</label>
            <div class='input-group date' id='Txt_Date01'>
                <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Desde..." />
                <span class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </span>
            </div>
        </div>
                <div class="col-lg">
            <label for="fecha">Hasta:</label>
            <div class='input-group date' id='Txt_Date02'>
                <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Desde..." />
                <span class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </span>
            </div>
        </div>
                <div class="col-lg">
                    <label for="DdlOrdenes">Programa:</label>
                    <select id="DdlOrdenes" class="form-control"></select>
                </div>
                <%--  <div class="col-lg-1">
                   
                </div>
                <div class="col-lg-1">
                   
                </div>--%>
            </div>
            <div class="row">
                <div class="col-lg">
                    <button id="Btn_Search" type="button" class="btn btn-block btn-buscar btn-sm"><i class="fa fa-fw fa-search mr-2"></i> Buscar</button>
                </div>
                <div class="col-lg">
                    <button id="Btn_Export" type="button" class="btn btn-block btn-success btn-sm"><i class="fa fa-fw fa-file-excel-o mr-2"></i> Excel</button>
                </div>
            </div>
        </div>
    </div>
        
<%--        <div id="Div_Error" class="div_error" runat="server">
            <p>Sin Resultados</p>
        </div>--%>
        <div id="Id_conte">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar p-2">
                    <h5>Listado de Atenciones</h5>
                </div>
                <div id="Div_Tabla" class="card-body" style="overflow:auto">

                </div>
            </div>
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar p-2">
                    <h5>Totales</h5>
                </div>
                <div id="Div_Tabla_Total" class="card-body" style="overflow:auto">

                </div>
            </div>
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar p-2">
                    <h5>Gráfico de Totales</h5>
                </div>
                <div id="Summary_Graph" class="card-body" style="overflow:auto">

                </div>
            </div>
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar p-2">
                    <h5>Montos por Programa</h5>
                </div>
                <div id="Div_dinero" class="card-body" style="overflow:auto">

                </div>
            </div>
        </div>
    </div>
</asp:Content>
