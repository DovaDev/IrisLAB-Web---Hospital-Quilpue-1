﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="GraficoAteTP.aspx.vb" Inherits="Presentacion.GraficoAteTP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <%-- Highcharts --%>
    <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>
    <%-- Custom Libraries --%>
    <script src="/js/Custom_modal.js"></script>
    <script src="/js/Custom_Objects.js"></script>
    <%-- --------------------------------------------------------------- --%>
    <%-- Funciones varias --%>
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
        //Devuelve una cadena con la Fecha de hoy del tipo "dd/MM/yyyy"
        var Date_Now = function () {
            //Obtener valores
            var obj_date = new Date();
            var dd = parseInt(obj_date.getDate());
            var mm = parseInt(obj_date.getMonth()) + 1;
            var yy = parseInt(obj_date.getFullYear());
            if (dd < 10) { dd = "0" + dd; }
            if (mm < 10) { mm = "0" + mm; }
            return String(dd + "/" + mm + "/" + yy);
        };
        //Devuelve un entero con la diferencia de días entre 2 fechas
        function restaFechas(f1, f2) {
            var aFecha1 = f1.split('/');
            var aFecha2 = f2.split('/');
            var fFecha1 = Date.UTC(aFecha1[2], aFecha1[1] - 1, aFecha1[0]);
            var fFecha2 = Date.UTC(aFecha2[2], aFecha2[1] - 1, aFecha2[0]);
            var dif = fFecha2 - fFecha1;
            var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
            return dias;
        }
    </script>
    <%-- Registro de Eventos --%>
    <script>
        $(document).ready(function () {
            //Establecer Datepickers
            /*$("#TxtDate_01").attr({
                "data-provide": "datepicker",
                "value": Date_Now
            });
            $("#TxtDate_02").attr({
                "data-provide": "datepicker",
                "value": Date_Now
            });
            $("#TxtDate_01").datepicker({
                keyboardNavigation: false,
                autoclose: true,
                todayHighlight: true,
                format: "dd/mm/yyyy",
                disableTouchKeyboard: true,
                language: "es"
            });
            $("#TxtDate_02").datepicker({
                keyboardNavigation: false,
                autoclose: true,
                todayHighlight: true,
                format: "dd/mm/yyyy",
                disableTouchKeyboard: true,
                language: "es"
            });*/
            //Modificaciones Visuales del DOM
            $(".block_wait").hide();
            $("#Div_Tabla").empty().css({ "background": "#ffffff" });
            $("#Div_Tabla").append(
                $("<div>").css({
                    "width": "calc(100% - 60)",
                    "text-align": "center",
                    "padding": "30px",
                    "font-size": "30px"
                }).text("Realice su Búsqueda.")
            );
            //Iniciar petición de datos requeridos en el inicio
            Ajax_Ddl();
            Ajax_Ddl_TP();
            Ajax_Ddl_Grafico();
            //Registrar Botón Buscar
            $("#Btn_Search").click(function () {
                AJAX_DataTable();
            });
            //Registrar Botón Exportar
            $("#Btn_Export").click(function () {
                Ajax_Excel();
            });

            $("#E_DESDE").change(function () {
                var desde = $("#E_DESDE").val();
                if (desde == "") {
                    E_Desde = $("#E_DESDE").val(0);
                }
            });
        });
    </script>
    <%-- Peticiones AJAX --%>
    <script>
        //Json de llenado de DropDownList
        var Mx_Ddl = [
            {
                "ID_AÑO": 0,
                "AÑO_COD": "asdf",
                "AÑO_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];
        function Ajax_Ddl() {

            $.ajax({
                "type": "POST",
                "url": "GraficoAteTP.aspx/Llenar_Ddl",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl = JSON.parse(json_receiver);
                        Fill_Ddl();
                        $(".block_wait").hide();

                    } else {

                    }
                },
                "failure": function (response) {
                    alert("Error en la Recepción de Datos");

                }
            });
        }

        var Mx_Ddl_TP = [
        {
            "ID_TP_PAGO": 0,
            "TP_PAGO_DESC": "asdf",
            "TP_PAGO_ING": "asdf",
            "ID_ESTADO": 0
        }
        ];

        function Ajax_Ddl_TP() {

            $.ajax({
                "type": "POST",
                "url": "GraficoAteTP.aspx/Llenar_Ddl_TP",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_TP = JSON.parse(json_receiver);
                        Fill_Ddl_TP();
                        $(".block_wait").hide();

                    } else {

                    }
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500);
                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);

                }
            });
        }

        function Ajax_Ddl_Grafico() {

            Fill_Ddl_Grafico();
        }

        //JSON para el DataTable
        var Mx_Dtt = [
            {
                "MES": "",
                "CANT_ATE": "",
                "CANT_EXA": ""
            }
        ];
        function AJAX_DataTable() {

            modal_show();
            var Data_Par = JSON.stringify({
                "Dll": String($("#DllTP").val()),
                "Año": $("#DllAño option:selected").text()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "GraficoAteTP.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].E_Fecha;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");
                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].E_Fecha = Date_Change;
                        }
                        Fill_DataTable();
                        Hide_Modal();

                    } else {

                        $("#Div_Tabla").empty().css({ "background": "#c30000" });
                        $("#Div_Tabla_Total").empty().css({ "background": "#c30000" });
                        $("#Summary_Graph").empty().css({ "background": "#c30000" });
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
                    Hide_Modal();
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500, function () {
                        var str_Error = response.responseJSON.ExceptionType + "\n \n";
                        str_Error = response.responseJSON.Message;
                        cModal_Error("Error", str_Error);
                    });
                    Hide_Modal();

                }
            });
        }
        //Generar Excel
        function Ajax_Excel() {

            modal_show();
            var Data_Par = JSON.stringify({
                "MAIN_URL": location.origin,
                "Dll": String($("#DllTP").val()),
                "Año": $("#DllAño option:selected").text()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "GraficoAteTP.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    $(".block_wait").fadeOut(500);
                    if (json_receiver != "null") {
                        var str_Download = "La Planilla Excel se ha generado correctamente, puede descargarla haciendo click ";
                        str_Download += "<a href='" + json_receiver + "'>AQUÍ.</a>"
                        cModal_Notif("Archivo Generado", str_Download);
                        Hide_Modal();

                    } else {
                        var str_Error = "La petición de generación de planilla Excel no se ha realizado debido ";
                        str_Error += "a que los parámetros de búsqueda no arrojaron resultados."
                        cModal_Error("Error", str_Error);
                        Hide_Modal();

                    }
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500, function () {
                        var str_Error = response.responseJSON.ExceptionType + "\n \n";
                        str_Error = response.responseJSON.Message;
                        cModal_Error("Error", str_Error);
                        
                    });
                    Hide_Modal();

                }
            });
        }
    </script>
    <%-- Funciones de Llenado --%>
    <script>
        //Llenar DropDownList
        function Fill_Ddl() {
            $("#DllAño").empty();
            //$("<option>", {
            //    "value": 0
            //}).text("Todos").appendTo("#DllPreV");
            for (y = 0; y < Mx_Ddl.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl[y].ID_AÑO
                }).text(Mx_Ddl[y].AÑO_DESC).appendTo("#DllAño");
            }
        };
        function Fill_Ddl_TP() {
            $("#DllTP").empty();
            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#DllTP");
            for (y = 0; y < Mx_Ddl_TP.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl_TP[y].ID_TP_PAGO
                }).text(Mx_Ddl_TP[y].TP_PAGO_DESC).appendTo("#DllTP");
            }
        };
        function Fill_Ddl_Grafico() {
            $("#DllGrafico").empty();
            $("<option>", {
                "value": 0
            }).text("1-. Grafico lineal").appendTo("#DllGrafico");
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
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>").text("#"),
                    $("<th>").text("Meses"),
                    $("<th>").text("Cantidad de Atenciones"),
                    $("<th>").text("Cantidad de Exámenes")
                )
            );
            for (i = 0; i < Mx_Dtt.length; ++i) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].MES),
                        $("<td>", { "align": "center" }).text(cFormat.numToString(Mx_Dtt[i].CANT_ATE, 0, ".", ",")),
                       $("<td>", { "align": "center" }).text(cFormat.numToString(Mx_Dtt[i].CANT_EXA, 0, ".", ","))
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
            $("#DataTableTotal thead").append(
                $("<tr>").append(
                    $("<th>").text("Total Atenciones"),
                    $("<th>").text("Total Exámenes")
                )
            );
            var T_Ate = 0;
            var T_Exa = 0;
            var T_Sis = 0;

            for (i = 0; i < Mx_Dtt.length; i++) {
                T_Ate = parseFloat(T_Ate) + parseFloat(Mx_Dtt[i].CANT_ATE);
                T_Exa = parseFloat(T_Exa) + parseFloat(Mx_Dtt[i].CANT_EXA);
                T_Sis = Math.round(T_Ate / Mx_Dtt.length)
            }
            $("#DataTableTotal tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(cFormat.numToString(T_Ate, 0, ".", ",")),
                        $("<td>", { "align": "center" }).text(cFormat.numToString(T_Exa, 0, ".", ","))
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
                arr.push(Mx_Dtt[i].MES);
                arr1.push(parseFloat(Mx_Dtt[i].CANT_ATE));
                arr2.push(parseFloat(Mx_Dtt[i].CANT_EXA));
            }

            Highcharts.chart('Summary_Graph', {
                chart: {
                    type: 'line'
                },
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
                        text: 'Atenciones/Exámenes'
                    }
                },
                plotOptions: {
                    line: {
                        dataLabels: {
                            enabled: true
                        },
                        enableMouseTracking: true
                    }
                },
                series: [{
                    name: 'Cantidad de Atenciones',
                    data: arr1
                }, {
                    name: 'Cantidad de Exámenes',
                    data: arr2
                }]
            });
        };

    </script>
    <%-- Custom CSS --%>
    <style>
        table thead {
            background-color: #28a745;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="card mb-3 border-bar">
        <div class="card-header bg-bar">
            <h5>Cantidad Anuales por Tipo de Pago</h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <label for="DllAño">Año:</label>
                    <select id="DllAño" class="form-control"></select>
                </div>
                <div class="col-lg">
                    <label for="DllTP">Tipo de Pago:</label>
                    <select id="DllTP" class="form-control"></select>
                </div>
                <div class="col-lg">
                    <label for="DllGrafico">Tipo de Gráfico:</label>
                    <select id="DllGrafico" class="form-control"></select>
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
    <div class="card p-3 border-bar">
        <div class="row">
            <div class="col-lg-3">
                <div class="row mb-3">
                    <div class="col-lg">
                        <h5>Detalle Mensual</h5>
                        <div id="Div_Tabla" class="table table-hover table-striped table-iris"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg">
                        <h5>Totales</h5>
                        <div id="Div_Tabla_Total" class="table table-hover table-striped table-iris"></div>
                    </div>
                </div>
            </div>
            <div class="col-lg-9">
                <h5>Gráfico</h5>
                <div id="Summary_Graph"></div>
            </div>
        </div>
    </div>
</asp:Content>
