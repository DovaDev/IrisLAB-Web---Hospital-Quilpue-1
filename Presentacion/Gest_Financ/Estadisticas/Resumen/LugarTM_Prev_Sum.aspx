<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="LugarTM_Prev_Sum.aspx.vb" Inherits="Presentacion.LugarTM_Prev_Sum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>

    <%-- Botones --%>
    <link href="../../../../Resourses/Style/Buttons.css" rel="stylesheet" />

    <%--Esto es para que funcione el gráfico--%>
    <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>
    <script src="/js/Custom_modal.js"></script>
    <script src="/js/Custom_Objects.js"></script>

    <%-- Declaración de Eventos --%>
    <script>
        $(document).ready(function () {
            //Ajustes Visuales
            //$(".block_wait").css({ "display": "none" });
            $("#Id_conte").hide();
            $(".block_wait").hide();
            $("#Div_Total").empty().css({ "display": "none" });
            $("#Div_Graph").empty().css({ "display": "none" });
            $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });
            $("#Div_Tabla_Data").append(
                $("<div>").css({
                    "width": "calc(100% - 60)",
                    "text-align": "center",
                    "padding": "30px",
                    "font-size": "30px"
                }).text("Realice su Búsqueda.")

            );

            //Llamar al llenado de los DropDownList
            Ajax_Ddl_Prev();
            Ajax_Ddl_Proce();
            Ajax_Ddl_T_Pago();

            //Registrar evento Click del Botón Buscar
            $("#Btn_Search").click(function () {

                Ajax_DataTable();

            });

            $("#Btn_Export").click(function () {
                Ajax_Excel();
            });
        });
    </script>


    <%-- Peticiones AJAX --%>
    <script>
        //Json de llenado de DropDownList
        var Mx_Ddl_Previ = [
            {
                "ID_PREVE": 0,
                "PREVE_COD": "asdf",
                "PREVE_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];

        var Mx_Ddl_Proce = [
            {
                "ID_PROCEDENCIA": 0,
                "PROC_COD": "asdf",
                "PROC_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];

        var Mx_Ddl_T_Pago = [
    {
        "ID_TP_PAGO": 0,
        "TP_PAGO_DESC": "asdf",
        "TP_PAGO_ING": "asdf",
        "ID_ESTADO": 0
    }
        ];
        function Ajax_Ddl_Prev() {



            $.ajax({
                "type": "POST",
                "url": "LugarTM_Prev_Sum.aspx/Llenar_Ddl_Prev",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_Previ = JSON.parse(json_receiver);
                        Fill_Ddl_Previ();
                        $(".block_wait").hide();



                    } else {


                        $("#Div_Tabla_Total").empty();
                        $("#Summary_Graph").empty();
                        $("#Div_dinero").empty();
                        $("#Div_Tabla").empty();
                        $("#Div_Tabla").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",

                                "color": "#000000"
                            }).text("Sin Resultados.")
                        );



                    }
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500);
                    var str_Error = "Error interno del Servidor";



                }
            });
        }

        function Ajax_Ddl_Proce() {



            $.ajax({
                "type": "POST",
                "url": "LugarTM_Prev_Sum.aspx/Llenar_Ddl_Proce",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_Proce = JSON.parse(json_receiver);
                        Fill_Ddl_Proce();
                        $(".block_wait").hide();



                    } else {


                        $("#Div_Tabla_Total").empty();
                        $("#Summary_Graph").empty();
                        $("#Div_dinero").empty();
                        $("#Div_Tabla").empty();
                        $("#Div_Tabla").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",

                                "color": "#000000"
                            }).text("Sin Resultados.")
                        );



                    }
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500);
                    var str_Error = "Error interno del Servidor";



                }
            });
        }

        function Ajax_Ddl_T_Pago() {



            $.ajax({
                "type": "POST",
                "url": "LugarTM_Prev_Sum.aspx/Llenar_Ddl_T_Pago",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_T_Pago = JSON.parse(json_receiver);
                        Fill_Ddl_T_Pago();
                        $(".block_wait").hide();



                    } else {


                        $("#Div_Tabla_Total").empty();
                        $("#Summary_Graph").empty();
                        $("#Div_dinero").empty();
                        $("#Div_Tabla").empty();
                        $("#Div_Tabla").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",

                                "color": "#ffffff"
                            }).text("Sin Resultados.")
                        );



                    }
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500);
                    var str_Error = "Error interno del Servidor";



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
                "PREVE_DESC": "asdf"

            }
        ];

        function Ajax_DataTable() {


            modal_show();
            var Data_Par = JSON.stringify({
                "ID_PRE": $("#DdlPrevi").val(),
                "ID_PRE2": $("#DdlProce").val(),
                "ID_TP_PAGO": $("#Ddl_T_Pago").val(),
                "DATE_str01": String($("#TxtDate_01").val()),
                "DATE_str02": String($("#TxtDate_02").val()),
            });

            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "LugarTM_Prev_Sum.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);

                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].ATE_FECHA = Date_Change;
                        }

                        Fill_DataTable();
                        $(".block_wait").hide();


                    } else {


                        $("#Div_Tabla_Total").empty();
                        $("#Summary_Graph").empty();
                        $("#Div_dinero").empty();
                        $("#Div_Tabla_Data").empty();
                        $("#Div_Tabla_Data").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",

                                "color": "#000000"
                            }).text("Sin Resultados.")
                        );
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500);
                    var str_Error = "Error interno del Servidor";
                    Hide_Modal();


                }
            });
        }

        //Generar Excel
        function Ajax_Excel() {



            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "ID_PRE": $("#DdlPrevi").val(),
                "ID_PRE2": $("#DdlProce").val(),
                "ID_TP_PAGO": $("#Ddl_T_Pago").val(),
                //"PROC_DESC": $("#DdlProce").val(),
                //"TP_PAGO_DESC":$("#Ddl_T_Pago").val(),
                "DATE_str01": String($("#TxtDate_01").val()).replace(/\//g, "a"),
                "DATE_str02": String($("#TxtDate_02").val()).replace(/\//g, "a")
                //"PREVE_DESC": $("#DdlPrevi").val()
            });

            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "LugarTM_Prev_Sum.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {

                    var json_receiver = response.d;

                    if (json_receiver != "null") {
                        var str_Download = "La Planilla Excel se ha generado correctamente, puede descargarla haciendo click ";
                        str_Download += "<a href='" + json_receiver + "'>AQUÍ.</a>";

                        $("#mdlNotif .modal-header h4").text("Archivo Generado");
                        $("#mdlNotif .modal-body p").html(str_Download);
                        $("#mdlNotif").modal();



                    } else {
                        var str_Error = "La petición de generación de planilla Excel no se ha realizado debido ";
                        str_Error += "a que los parámetros de búsqueda no arrojaron resultados."

                        $("#mdlNotif .modal-header h4").text("Error");
                        $("#mdlNotif .modal-body p").html(str_Error);
                        $("#mdlNotif").modal();



                    }

                    Hide_Modal();
                },
                "error": function (response) {
                    Hide_Modal();
                    $("#mdlNotif .modal-header h4").text(String(response.responseJSON.ExceptionType).trim());
                    $("#mdlNotif .modal-body p").html(response.responseJSON.Message);
                    $("#mdlNotif").modal();



                }
            });
        }
    </script>
    <%-- Funciones de Llenado de Elementos --%>
    <script>
        //Llenar DropDownList
        function Fill_Ddl_Previ() {
            $("#DdlPrevi").empty();

            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#DdlPrevi");
            for (y = 0; y < Mx_Ddl_Previ.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl_Previ[y].ID_PREVE
                }).text(Mx_Ddl_Previ[y].PREVE_DESC).appendTo("#DdlPrevi");
            }
        };

        function Fill_Ddl_Proce() {
            $("#DdlProce").empty();

            var procee = Galletas.getGalleta("USU_TM");

            if (procee == 0) {
                $("<option>",
                {
                    "value": "0"
                }
                ).text("Todos").appendTo("#DdlProce");
                Mx_Ddl_Proce.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#DdlProce");
                });
            }
            else {
                Mx_Ddl_Proce.forEach(aaa => {
                    if (aaa.ID_PROCEDENCIA == procee) {
                        $("<option>",
                          {
                              "value": aaa.ID_PROCEDENCIA
                          }
                       ).text(aaa.PROC_DESC).appendTo("#DdlProce");
                    }

                });
            }
        };

        function Fill_Ddl_T_Pago() {
            $("#Ddl_T_Pago").empty();

            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#Ddl_T_Pago");
            for (y = 0; y < Mx_Ddl_T_Pago.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl_T_Pago[y].ID_TP_PAGO
                }).text(Mx_Ddl_T_Pago[y].TP_PAGO_DESC).appendTo("#Ddl_T_Pago");
            }
        };
        //Llenar DataTable
        function Fill_DataTable() {
            $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });

            $("<table>", {
                "id": "DataTable",
                "class": "table table-hover table-striped table-iris",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Data");

            $("#DataTable").append(
                $("<thead>"),
                $("<tbody>")
            );

            $("#DataTable thead").append(
            $("<tr>").append(
                $("<th>", { "class": "text-center" }).text("#"),
                $("<th>").text("Previsión:"),
                $("<th>", { "class": "text-center" }).text("Cant. Atenciones"),
                $("<th>", { "class": "text-center" }).text("Cant. Exámenes"),
                $("<th>").text("Total Sistema"),
                $("<th>").text("Total Usuario"),
                $("<th>").text("Total Copago"),
                $("<th>").text("Total Pagado")
            )
            );
            $("#DataTable thead").attr("class", "cabezera");
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>").text(Mx_Dtt[i].PREVE_DESC),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].TOTAL_ATE),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].TOT_FONASA),
                        $("<td>").text("$ " + cFormat.numToString(Mx_Dtt[i].TOTA_SIS, 0, ".", ",")),
                        $("<td>").text("$ " + cFormat.numToString(Mx_Dtt[i].TOTA_USU, 0, ".", ",")),
                        $("<td>").text("$ " + cFormat.numToString(Mx_Dtt[i].TOTA_COPA, 0, ".", ",")),
                        $("<td>").text("$ " + cFormat.numToString(parseFloat(Mx_Dtt[i].TOTA_USU) + parseFloat(Mx_Dtt[i].TOTA_COPA), 0, ".", ","))
                    )
                );
            }

            //$("#DataTable").DataTable({
            //    "bSort": false,
            //    "bPaginate": false,
            //    "bInfo":false,
            //    "iDisplayLength": 100,
            //    "language": {
            //        "DisplayLength": 100,
            //        "lengthMenu": "Mostrar: _MENU_",
            //        "zeroRecords": "No hay concidencias",
            //        "info": "Mostrando Pagina _PAGE_ de _PAGES_",
            //        "infoEmpty": "No hay concidencias",
            //        "infoFiltered": "(Se busco en _MAX_ registros )",
            //        "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
            //        "paginate": {
            //            "previous": "Anterior",
            //            "next": "Siguiente"
            //        }
            //    }
            //});

            //LLENADO TABLA TOTALES
            $("#Div_Tabla_Total").empty().css({ "background": "#ffffff" });

            $("<table>", {
                "id": "DataTableTotal",
                "class": "table table-hover table-striped table-iris",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Total");

            $("#DataTableTotal").append(
                $("<thead>"),
                $("<tbody>")
            );
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
                arr.push(Mx_Dtt[i].PREVE_DESC);
                arr1.push(parseFloat(Mx_Dtt[i].TOTAL_ATE));
                arr2.push(parseFloat(Mx_Dtt[i].TOT_FONASA));
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
                    name: 'Cantidad Atenciones',
                    data: arr1
                }, {
                    name: 'Cantidad Exámenes',
                    data: arr2
                }]
            });

            var AR_pre = [0];
            var ARTota_sis = [0];
            var ARTota_usu = [0];
            var ARTota_Copa = [0];
            var ARTota_Tota_pago = [0];
            for (i = 0; i < Mx_Dtt.length; i++) {
                if (i == 0) {
                    AR_pre.pop();
                    ARTota_sis.pop();
                    ARTota_usu.pop();
                    ARTota_Copa.pop();
                    ARTota_Tota_pago.pop();
                }
                AR_pre.push(Mx_Dtt[i].PREVE_DESC);
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
                    categories: AR_pre
                },
                yAxis: {
                    title: {
                        text: 'Totales'
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

            $("#Id_conte").show();
            Hide_Modal();
        }
    </script>

    <%-- Datepickers --%>
    <script>
        $(document).ready(function () {
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

            //$("#TxtDate_01").val(Date_Now);
            //$("#TxtDate_02").val(Date_Now);
        });
    </script>


    <%-- CSS Personalizado --%>
    <%-- Custom CSS --%>
    <style>
        #TxtDate_01, #TxtDate_02 {
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
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Cph_Body" runat="server">
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
    <%-- Tabla de Búsqueda --%>
    <div class="flex_col">
        <div class="card mb-3 border-bar">
            <div class="card-header bg-bar p-2">
                <h5>Resumen de Atenciones por Lugar de Toma de Muestra Y Previsión</h5>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-lg">
                        <label for="fecha">Desde:</label>
                        <div class='input-group date' id='Txt_Date01'>
                            <input type='text' id="TxtDate_01" class="form-control" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-lg">
                        <label for="fecha">Hasta:</label>
                        <div class='input-group date' id='Txt_Date02'>
                            <input type='text' id="TxtDate_02" class="form-control" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-lg">
                        <label for="DdlProce">Lugar de TM:</label>
                        <select id="DdlProce" class="form-control"></select>
                    </div>
                    <div class="col-lg">
                        <label for="DdlPrevi">Previsión:</label>
                        <select id="DdlPrevi" class="form-control"></select>
                    </div>
                    <div class="col-lg">
                        <label for="Ddl_T_Pago">Forma de Pago:</label>
                        <select id="Ddl_T_Pago" class="form-control"></select>
                    </div>

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
        <div id="Id_conte">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar p-2">
                    <h5>Tabla de Resultados</h5>
                </div>
                <div id="Div_Tabla_Data" class="card-body" style="overflow:auto">

                </div>
            </div>
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar p-2">
                    <h5>Total</h5>
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
                    <h5>Cantidades por Previsión</h5>
                </div>
                <div id="Div_dinero" class="card-body" style="overflow:auto">

                </div>
            </div>
        </div>
    </div>
</asp:Content>




