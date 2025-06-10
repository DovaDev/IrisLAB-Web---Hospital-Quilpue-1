<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="GraficoAtenciones.aspx.vb" Inherits="Presentacion.GraficoAtenciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true"%>
    
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
            $("#div_hide").hide();
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
            Ajax_Ddl_Mes();
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
                "url": "GraficoAtenciones.aspx/Llenar_Ddl",
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

        function Ajax_Ddl_Mes() {

            Fill_Ddl_Mes();
        }
        function Ajax_Ddl_Grafico() {

            Fill_Ddl_Grafico();
        }

        //JSON para el DataTable
        var Mx_Dtt = [
            {
                "E_Fecha": "",
                "E_Cantidad": "",
                "E_Dias": ""
            }
        ];
        function AJAX_DataTable() {

            var Data_Par = JSON.stringify({
                "Mes": String($("#DllMes").val()),
                "Año": $("#DllAño option:selected").text()
            });
            modal_show();
            $.ajax({
                "type": "POST",
                "url": "GraficoAtenciones.aspx/Llenar_DataTable",
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
                    Hide_Modal();
                    $(".block_wait").fadeOut(500, function () {
                        var str_Error = response.responseJSON.ExceptionType + "\n \n";
                        str_Error = response.responseJSON.Message;
                        cModal_Error("Error", str_Error);
                    });

                }
            });
        }
        //Generar Excel
        function Ajax_Excel() {


            var Data_Par = JSON.stringify({
                "MAIN_URL": location.origin,
                "Mes": String($("#DllMes").val()),
                "Año": $("#DllAño option:selected").text()
            });
            modal_show();
            $.ajax({
                "type": "POST",
                "url": "GraficoAtenciones.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    $(".block_wait").fadeOut(500);
                    Hide_Modal();
                    if (json_receiver != "null") {
                        window.open(json_receiver, 'Download');

                    } else {
                        Hide_Modal();
                        var str_Error = "La petición de generación de planilla Excel no se ha realizado debido ";
                        str_Error += "a que los parámetros de búsqueda no arrojaron resultados."
                        cModal_Error("Error", str_Error);

                    }
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500, function () {
                        var str_Error = response.responseJSON.ExceptionType + "\n \n";
                        str_Error = response.responseJSON.Message;
                        cModal_Error("Error", str_Error);
                    });

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
        function Fill_Ddl_Mes() {
            $("#DllMes").empty();
            $("<option>", {
                "value": 1
            }).text("Enero").appendTo("#DllMes");
            $("<option>", {
                "value": 2
            }).text("Febrero").appendTo("#DllMes");
            $("<option>", {
                "value": 3
            }).text("Marzo").appendTo("#DllMes");
            $("<option>", {
                "value": 4
            }).text("Abril").appendTo("#DllMes");
            $("<option>", {
                "value": 5
            }).text("Mayo").appendTo("#DllMes");
            $("<option>", {
                "value": 6
            }).text("Junio").appendTo("#DllMes");
            $("<option>", {
                "value": 7
            }).text("Julio").appendTo("#DllMes");
            $("<option>", {
                "value": 8
            }).text("Agosto").appendTo("#DllMes");
            $("<option>", {
                "value": 9
            }).text("Septiembre").appendTo("#DllMes");
            $("<option>", {
                "value": 10
            }).text("Octubre").appendTo("#DllMes");
            $("<option>", {
                "value": 11
            }).text("Noviembre").appendTo("#DllMes");
            $("<option>", {
                "value": 12
            }).text("Diciembre").appendTo("#DllMes");
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
                    $("<th>").css("text-align", "center").text("#"),
                    $("<th>").css("text-align", "center").text("Fecha"),
                    $("<th>").css("text-align", "center").text("Cantidad de Atenciones"),
                    $("<th>").css("text-align", "center").text("Día")
                )
            );
            for (i = 0; i < Mx_Dtt.length; ++i) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>", { "align": "center" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt[i].E_Fecha);
                            var dd = parseInt(obj_date.getDate());
                            var MM = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());
                            if (dd < 10) { dd = "0" + dd; }
                            if (MM < 10) { MM = "0" + MM; }

                            return String(dd + "/" + MM + "/" + yy);
                        }),
                        $("<td>", { "align": "center" }).text(cFormat.numToString(Mx_Dtt[i].E_Cantidad, 0, ".", ",")),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].E_Dias)
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
                    $("<th>").css("text-align", "center").text("Cantidad Mensual"),
                    $("<th>").css("text-align", "center").text("Promedio Diario")
                )
            );
            var T_Ate = 0;
            var T_Exa = 0;
            var T_Sis = 0;

            for (i = 0; i < Mx_Dtt.length; i++) {
                T_Ate = parseFloat(T_Ate) + parseFloat(Mx_Dtt[i].E_Cantidad);
                T_Exa = parseFloat(T_Exa) + 1
            }
            T_Sis = Math.round(T_Ate / T_Exa)
            $("#DataTableTotal tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(cFormat.numToString(T_Ate, 0, ".", ",")),
                        $("<td>", { "align": "center" }).text(cFormat.numToString(T_Sis, 0, ".", ","))
                    )
                );
            grafico();
        };
        function grafico() {
            var grafico = $("#DllGrafico").val();

            if (grafico == 0) {
                var arr = ["Array"];
                var arr1 = [0];
                var fecha = ""
                for (i = 0; i < Mx_Dtt.length; i++) {
                    if (i == 0) {
                        arr.pop();
                        arr1.pop();
                    }
                    fecha = (function () {
                        //Obtener valores
                        var obj_date = new Date(Mx_Dtt[i].E_Fecha);
                        var dd = parseInt(obj_date.getDate());
                        var MM = parseInt(obj_date.getMonth()) + 1;
                        var yy = parseInt(obj_date.getFullYear());
                        if (dd < 10) { dd = "0" + dd; }
                        if (MM < 10) { MM = "0" + MM; }

                        return String(dd + "/" + MM + "/" + yy);
                    })();
                    arr.push(fecha);
                    arr1.push(parseFloat(Mx_Dtt[i].E_Cantidad));
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
                            text: 'Atenciones'
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
                    }]
                });
            };
            $("#div_hide").show();
        };
    </script>
    <%-- Custom CSS --%>
   <style>
        table thead {
            background-color:#28a745;
            color:white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="card mb-3 border-bar">
        <div class="card-header bg-bar">
            <h5>Visor de Cantidades Atenciones Mensuales</h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <label for="DllAño">Año:</label>
                    <select id="DllAño" class="form-control"></select>
                </div>
                <div class="col-lg">
                    <label for="DllMes">Mes:</label>
                    <select id="DllMes" class="form-control"></select>
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
    <div class="card p-3 border-bar" id="div_hide">
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