<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="GraficoHORA_EXA.aspx.vb" Inherits="Presentacion.GraficoHORA_EXA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
     <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true"%>
    
    <%-- Highcharts --%>
    <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>
    <%-- Custom Libraries --%>
<%--    <script src="/js/Custom_modal.js"></script>--%>
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
            $('#Txt_Fecha').datetimepicker(
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
            $("#Txt_Date01 input").val(dateNow);

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
            $("#Flex_Supremo").hide();
            //Iniciar petición de datos requeridos en el inicio
            Fill_Ddl_Graph()
            //Registrar Botón Buscar
            $("#Btn_Search").click(function () {
                AJAX_JSON_Graph();
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
        //JSON del Gráfico
        var Mx_Data = [
            {
                "FECHA": "",
                "NUMERO": ""
            }
        ];
        function AJAX_JSON_Graph() {
            modal_show();


            var Data_Par = JSON.stringify({
                "str_Date": String($("#Txt_Fecha").val())
            });
           
            $.ajax({
                "type": "POST",
                "url": "GraficoHORA_EXA.aspx/Data_Graph",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Data = JSON.parse(json_receiver);
                        $("#Flex_Supremo").fadeIn(500);
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
                        Hide_Modal();
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
        //Generar Excel
        function Ajax_Excel() {

            modal_show();
            var Data_Par = JSON.stringify({
                "MAIN_URL": location.origin,
                "str_Date": String($("#Txt_Fecha").val())
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "GraficoHORA_EXA.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    $(".block_wait").fadeOut(500);
                    if (json_receiver != "null") {
                        window.open(json_receiver, 'Download');
                        Hide_Modal();

                        Hide_Modal();
                    } else {

                        Hide_Modal();
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
        function Fill_Ddl_Graph() {
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
                    $("<th>").css("text-align", "center").text("Hora"),
                    $("<th>").css("text-align", "center").text("Atenciones")
                )
            );
            for (i = 0; i < Mx_Data.length; ++i) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>", { "align": "center" }).text(function () {
                            //Obtener valores
                            var nDate = String(Mx_Data[i].FECHA);
                            nDate = nDate.toUpperCase().replace("/DATE(", "");
                            nDate = nDate.replace(")/", "");
                            var obj_date = new Date(parseInt(nDate));
                            //var dd = parseInt(obj_date.getDate());
                            //var MM = parseInt(obj_date.getMonth()) + 1;
                            //var yy = parseInt(obj_date.getFullYear());
                            //if (dd < 10) { dd = "0" + dd; }
                            //if (MM < 10) { MM = "0" + MM; }
                            var hh = parseInt(obj_date.getHours());
                            var mm = parseInt(obj_date.getMinutes());
                            if (hh < 10) { hh = "0" + hh; }
                            if (mm < 10) { mm = "0" + mm; }
                            return String(hh + ":" + mm);
                        }),
                        $("<td>", { "align": "center" }).text(cFormat.numToString(Mx_Data[i].NUMERO, 0, ".", ","))
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
                    $("<th>").css("text-align", "center").text("Cant. Total"),
                    $("<th>").css("text-align", "center").text("Promedio")
                )
            );
            var T_Ate = 0;
            var T_Pro = 0;
            for (i = 0; i < Mx_Data.length; i++) {
                T_Ate = parseFloat(T_Ate) + parseFloat(Mx_Data[i].NUMERO);
            }
            T_Pro = T_Ate / Mx_Data.length;
            $("#DataTableTotal tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(cFormat.numToString(T_Ate, 0, ".", ",")),
                        $("<td>", { "align": "center" }).text(cFormat.numToString(T_Pro, 2, ".", ","))
                    )
                );
            grafico();
        };
        function grafico() {
            var grafico = $("#DllGrafico").val();
            if (grafico == 0) {
                var arrPar = [];
                var arrVal = [];
                for (i = 0; i < Mx_Data.length; i++) {
                    arrVal.push(parseFloat(Mx_Data[i].NUMERO));
                    arrPar.push(function () {
                        //Obtener valores
                        var nDate = String(Mx_Data[i].FECHA);
                        nDate = nDate.toUpperCase().replace("/DATE(", "");
                        nDate = nDate.replace(")/", "");
                        var obj_date = new Date(parseInt(nDate));
                        //var dd = parseInt(obj_date.getDate());
                        //var MM = parseInt(obj_date.getMonth()) + 1;
                        //var yy = parseInt(obj_date.getFullYear());
                        //if (dd < 10) { dd = "0" + dd; }
                        //if (MM < 10) { MM = "0" + MM; }
                        var hh = parseInt(obj_date.getHours());
                        var mm = parseInt(obj_date.getMinutes());
                        if (hh < 10) { hh = "0" + hh; }
                        if (mm < 10) { mm = "0" + mm; }
                        return String(hh + ":" + mm);
                    }());
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
                        categories: arrPar
                    },
                    yAxis: {
                        title: {
                            text: 'Exámenes'
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
                        name: 'Total Atenciones',
                        data: arrVal
                    }]
                });
            };
        };
    </script>
    <style>
        .tableth {
            background-color:#28a745;
            color:white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="card mb-3 border-bar">
        <div class="card-header bg-bar">
            <h5>Visor de Exámenes por Hora</h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <label for="Txt_Fecha">Fecha:</label>
                   <div class='input-group date' id='Txt_Date01'>
                                <input type='text' id="Txt_Fecha" class="form-control" readonly="true" placeholder="Desde..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
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




