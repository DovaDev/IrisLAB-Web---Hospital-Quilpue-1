<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Pacientes_Sum.aspx.vb" Inherits="Presentacion.Pacientes_Sum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true"%>
    
    <%-- Botones --%>
    <link href="../../../../Resourses/Style/Buttons.css" rel="stylesheet" />

        <%--Esto es para que funcione el gráfico--%>
 <%--   <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>--%>

    <script src="/js/Custom_modal.js"></script>
    <script src="/js/Custom_Objects.js"></script>

    <%-- Declaración de Eventos --%>
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
            //$(".block_wait").css({ "display": "none" });
            $(".block_wait").hide();
            $("#Div_Total").empty().css({ "display": "none" });
            $("#Div_Graph").empty().css({ "display": "none" });
            $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });
            $("#Div_Tabla_Data").append(
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
                "ID_PREVE": 0,
                "PREVE_COD": "asdf",
                "PREVE_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];

        function Ajax_Ddl() {



            $.ajax({
                "type": "POST",
                "url": "Pacientes_Sum.aspx/Llenar_Ddl",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Ddl = json_receiver;
                        Fill_Ddl();
                        $(".block_wait").hide();



                    } else {
                        //cModal_Error("ERROR", "asdfasdfasdfas");
                        $("#mError_AAH h4").text("Sin Resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda seleccionada.");
                        $("#mError_AAH").modal();
                        Hide_Modal();
                        $("#Div_Tabla_Total").empty().css({ "background": "#c30000" });
                        $("#Summary_Graph").empty().css({ "background": "#c30000" });
                        $("#Div_dinero").empty().css({ "background": "#c30000" });
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
                },
                "error": function (response) {
                    //cModal_Error("ERROR", "A ocurrido un error a nivel interno del lado del Server, disculpe las molestias.");


                    Hide_Modal();
                    
                }
            });
        }
        //Json de llenado de DataTable
        var Mx_Dtt = [
            {
                "ATE_NUM": 0,
                "PAC_RUT": "asdf",
                "PAC_NOMBRE": "asdf",
                "PAC_APELLIDO": "asdf",
                "TP_PAGO_DESC": "asdf",
                "ATE_TOTAL_PREVI": 0,
                "ATE_TOTAL_COPA": 0
            }
        ];

        function Ajax_DataTable() {
            modal_show();



            var Data_Par = JSON.stringify({
                "ID_PREVE": $("#DdlPrevi").val(),
                "DATE_str01": $("#Txt_Date01 input").val(),
                "DATE_str02": $("#Txt_Date02 input").val()
            });

            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "Pacientes_Sum.aspx/Llenar_DataTable",
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
                        $(".block_wait").hide();


                    } else {


                        $("#mError_AAH h4").text("Sin Resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda seleccionada.");
                        $("#mError_AAH").modal();
                        Hide_Modal();
                        $("#Div_Tabla_Total").empty().css({ "background": "#c30000" });
                        $("#Summary_Graph").empty().css({ "background": "#c30000" });
                        $("#Div_dinero").empty().css({ "background": "#c30000" });
                        $("#Div_Tabla_Data").empty().css({ "background": "#c30000" });
                        $("#Div_Tabla_Data").append(
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
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    alert("Error en la Recepción de Datos");


                    Hide_Modal();
                }
            });
        }

        //Generar Excel
        function Ajax_Excel() {
            modal_show();



            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "PREVE_DESC": $("#DdlPrevi option:selected").text(),
                "ID_PREVE": $("#DdlPrevi").val(),
                "DATE_str01": $("#Txt_Date01 input").val(),
                "DATE_str02": $("#Txt_Date02 input").val()
            });

            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "Pacientes_Sum.aspx/Gen_Excel",
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
                        var str_Error = "La petición de generación de planilla Excel no se ha realizado debido ";
                        str_Error += "a que los parámetros de búsqueda no arrojaron resultados."
                        $("#mError_AAH h4").text("Sin Resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para exportar en la búsqueda seleccionada.");
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
            $("#DdlPrevi").empty();

            //$("<option>", {
            //    "value": 0
            //}).text("Todos").appendTo("#DdlPrevi");
            for (y = 0; y < Mx_Ddl.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl[y].ID_PREVE
                }).text(Mx_Ddl[y].PREVE_DESC).appendTo("#DdlPrevi");
            }
        };
        //Llenar DataTable
        function Fill_DataTable() {
            $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });

            $("<table>", {
                "id": "DataTable",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Data");

            $("#DataTable").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable thead").attr("class", "cabezera");
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>").text("#"),
                    $("<th>").text("Folio"),
                    $("<th>").text("R.U.T"),
                    $("<th>").text("Nombre"),
                    $("<th>").text("Forma de Pago"),
                    $("<th>").text("N° Bonos"),
                    $("<th>").text("Total Bonos"),
                    $("<th>").text("Total Copago"),
                    $("<th>").text("Total Particular")
                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                    $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].ATE_NUM),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].PAC_RUT),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].PAC_APELLIDO + " " + Mx_Dtt[i].PAC_NOMBRE),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].TP_PAGO_DESC),
                        $("<td>", { "align": "right" }).text(" "),
                        $("<td>", { "align": "right" }).text("$ " + cFormat.numToString(parseFloat(Mx_Dtt[i].ATE_TOTAL_PREVI) + parseFloat(Mx_Dtt[i].ATE_TOTAL_COPA), 0, ".", ",")),
                        $("<td>", { "align": "right" }).text("$ " + cFormat.numToString(Mx_Dtt[i].ATE_TOTAL_COPA, 0, ".", ",")),
                        $("<td>", { "align": "right" }).text(" ")
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
                    $("<th>").text("N° Bonos"),
                    $("<th>").text("Total Bonos"),
                    $("<th>").text("Total Copago"),
                    $("<th>").text("Total Particular")
                )
            );
            var T_Bon = 0;
            var T_Cop = 0;

            for (i = 0; i < Mx_Dtt.length; i++) {

                T_Bon = parseFloat(T_Bon) + parseFloat(Mx_Dtt[i].ATE_TOTAL_PREVI);
                T_Cop = parseFloat(T_Cop) + parseFloat(Mx_Dtt[i].ATE_TOTAL_COPA);
            }
            $("#DataTableTotal tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "right" }).text(""),
                        $("<td>", { "align": "right" }).text("$ " + cFormat.numToString(T_Bon, 0, ".", ",")),
                        $("<td>", { "align": "right" }).text("$ " + cFormat.numToString(T_Cop, 0, ".", ",")),
                        $("<td>", { "align": "right" }).text("")
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
                arr.push(Mx_Dtt[i].PAC_APELLIDO + " " + Mx_Dtt[i].PAC_NOMBRE);
                arr1.push(parseFloat(Mx_Dtt[i].ATE_TOTAL_PREVI));
                arr2.push(parseFloat(Mx_Dtt[i].ATE_TOTAL_COPA));
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
                        text: 'Totales'
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
                    name: 'Total Bonos',
                    data: arr1
                }, {
                    name: 'Total Copago',
                    data: arr2
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
        <div class="card-header bg-bar">
            <h5>Resumen de Pacientes</h5>
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
                    <label for="DdlPrevi">Previsión:</label>
                    <select id="DdlPrevi" class="form-control"></select>
                </div>
                <%--  <div class="col-lg-1">
                   
                </div>
                <div class="col-lg-1">
                   
                </div>--%>
            </div>
            <div class="row">
                <div class="col-lg">
                    <button id="Btn_Search" type="button" class="btn btn-block btn-primary btn-sm">Buscar</button>
                </div>
                <div class="col-lg">
                    <button id="Btn_Export" type="button" class="btn btn-block btn-success btn-sm">Excel</button>
                </div>
            </div>
        </div>
    </div>
    <div id="Id_conte">
        <div class="card mb-3 border-bar">
            <div class="card-header bg-bar">
                <h5>Listado de Atenciones</h5>
            </div>
            <div id="Div_Tabla_Data" class="card-body">

            </div>
        </div>
        <div class="card mb-3 border-bar">
            <div class="card-header bg-bar">
                <h5>Totales</h5>
            </div>
            <div id="Div_Tabla_Total" class="card-body">

            </div>
        </div>
        <div class="card mb-3 border-bar">
            <div class="card-header bg-bar">
                <h5>Gráfico de Totales</h5>
            </div>
            <div id="Summary_Graph" class="card-body">

            </div>
        </div>
    </div>
</div>
</asp:Content>
