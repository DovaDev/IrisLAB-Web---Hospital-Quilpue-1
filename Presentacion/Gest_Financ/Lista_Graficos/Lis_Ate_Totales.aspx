<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Lis_Ate_Totales.aspx.vb" Inherits="Presentacion.Lis_Ate_Totales" %>

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
            $("#div_hide").hide();
            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input").val(dateNow);
            $("#Txt_Date02 input").val(dateNow);

            //Ajustes Visuales
            //$(".block_wait").css({ "display": "none" });
            $(".block_wait").hide();
            $("#Div_Total").empty().css({ "display": "none" });
            $("#Div_Graph").empty().css({ "display": "none" });
            $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });
            $("#Div_Tabla_Data").append(
                $("<div>").css({
                    "width": "calc(100% - 60)",
               
                    "padding": "30px",
                    "font-size": "30px"
                }).text("Realice su Búsqueda.")

            );

            $('#fecha1').datetimepicker(
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
            $('#fecha2').datetimepicker(
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
            $("#fecha1 input").val(dateNow);
            $("#fecha2 input").val(dateNow);
            //Llamar al llenado de los DropDownList
            Ajax_Ddl_Proce();

            //Registrar evento Click del Botón Buscar
            $("#Btn_Search").click(function () {
                //function restaFechas(f1, f2) {
                //    var aFecha1 = f1.split('/');
                //    var aFecha2 = f2.split('/');
                //    var fFecha1 = Date.UTC(aFecha1[2], aFecha1[1] - 1, aFecha1[0]);
                //    var fFecha2 = Date.UTC(aFecha2[2], aFecha2[1] - 1, aFecha2[0]);
                //    var dif = fFecha2 - fFecha1;
                //    var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
                //    return dias;
                //}

                //var Date_Diff = restaFechas(String($("#Txt_Date01").val()), String($("#Txt_Date02").val()));

                //if (Date_Diff <= 31) {
                    Ajax_DataTable();

                //} else {
                //    //cModal_Error("Atención", "Realice una búsqueda usando un rango menor o igual a 30 días.");
                //}
            });

            $("#Btn_Export").click(function () {
                Ajax_Excel();
            });
        });
    </script>


    <%-- Peticiones AJAX --%>
    <script>
        //Json de llenado de DropDownList
        var Mx_Ddl_Proce = [
            {
                "ID_PROCEDENCIA": 0,
                "PROC_COD": "asdf",
                "PROC_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];

        function Ajax_Ddl_Proce() {



            $.ajax({
                "type": "POST",
                "url": "Lis_Ate_Totales.aspx/Llenar_Ddl_Proce",
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
                        //cModal_Error("ERROR", "asdfasdfasdfas");

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
                                "color": "#ffffff"
                            }).text("Sin Resultados.")
                        );



                    }
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500);
                    var str_Error = "Error interno del Servidor";
                    //cModal_Error("Error", str_Error);


                }
            });
        }

        //Json de llenado de DataTable
        var Mx_Dtt = [
            {
                "ID_ATENCION": 0,
                "ATE_NUM": 0,
                "9": "asdf",
                "ID_PACIENTE": 0,
                "PAC_NOMBRE": "asdf",
                "PAC_APELLIDO": "asdf",
                "ATE_AÑO": 0,
                "DOC_NOMBRE": "asdf",
                "DOC_APELLIDO": "asdf",
                "SEXO_DESC": "asdf",
                "ID_SEXO": 0,
                "ID_PROCEDENCIA": 0,
                "ID_ESTADO": 0,
                "PROC_DESC": "asdf",
                "ATE_TOTAL": 0,
                "ATE_TOTAL_PREVI": 0,
                "ATE_TOTAL_COPA": 0
            }
        ];

        function Ajax_DataTable() {
            modal_show();



            var Data_Par = JSON.stringify({
                "ID_PROCEDENCIA": $("#DdlProce").val(),
                "DATE_str01": String($("#Txt_Date01").val()),
                "DATE_str02": String($("#Txt_Date02").val()),
            });

            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "Lis_Ate_Totales.aspx/Llenar_DataTable",
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
                        Hide_Modal();
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
                    //cModal_Error("Error", str_Error);


                    Hide_Modal();
                }
            });
        }

        //Generar Excel
        function Ajax_Excel() {
            modal_show();



            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "ID_PROCEDENCIA": $("#DdlProce").val(),
                "PROC_DESC": $("#DdlProce option:selected").text(),
                "DATE_str01": $("#Txt_Date01").val(),
                "DATE_str02": $("#Txt_Date02").val()
            });

            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "Lis_Ate_Totales.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    $(".block_wait").fadeOut(500);

                    if (json_receiver != "null") {
                        window.open(json_receiver, 'Download');



                    } else {



                    }
                    Hide_Modal();
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500);
                    var str_Error = "Error interno del Servidor";
                    //cModal_Error("Error", str_Error);


                    Hide_Modal();
                }
            });
        }
    </script>
    <%-- Funciones de Llenado de Elementos --%>
    <script>
        //Llenar DropDownList
        function Fill_Ddl_Proce() {
         

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

            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "text-center" }).text("#"),
                    $("<th>", { "class": "text-center" }).text("N° Atención"),
                    $("<th>").text("Nombre Paciente"),
                    $("<th>", { "class": "text-center" }).text("Edad"),
                    $("<th>", { "class": "text-center" }).text("Fecha"),
                    $("<th>", { "class": "text-center" }).text("Hora"),
                    $("<th>").text("Lugar de TM"),
                    $("<th>", { "class": "text-center" }).text("Sexo"),
                    $("<th>").text("Total")
                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].ATE_NUM),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].ATE_AÑO + " años"),

                        $("<td>", { "align": "center" }).text(function () {
                            //Solo Día, Mes y Año
                            var obj_date = new Date(Mx_Dtt[i].ATE_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var MM = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (MM < 10) { MM = "0" + MM; }
                            return String(dd + "/" + MM + "/" + yy);
                        }),

                        $("<td>", { "align": "center" }).text(function () {
                            //Solo Hora, Minutos y Segundos
                            var obj_date = new Date(Mx_Dtt[i].ATE_FECHA);

                            var hh = parseInt(obj_date.getHours());
                            var mm = parseInt(obj_date.getMinutes());
                            var ss = parseInt(obj_date.getSeconds());

                            if (hh < 10) { hh = "0" + hh; }
                            if (mm < 10) { mm = "0" + mm; }
                            if (ss < 10) { ss = "0" + ss; }

                            return String(hh + ":" + mm + ":" + ss);
                        }),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].PROC_DESC),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].SEXO_DESC),
                        $("<td>").text("$ " + cFormat.numToString(parseFloat(Mx_Dtt[i].ATE_TOTAL), 0, ".", ","))
                    )
                );
            }

            $("#DataTable").DataTable({  "bSort": false,
                "iDisplayLength": 100,
                "language": {
                    "DisplayLength": 100,
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay concidencias",
                    "info": "Mostrando Página _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });

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
                    $("<th>").text("Total Pagado").css("text-align","center")
                )
            );
            var T_Pag = 0;

            for (i = 0; i < Mx_Dtt.length; i++) {

                T_Pag = parseFloat(T_Pag) + parseFloat(Mx_Dtt[i].ATE_TOTAL);

            }
            $("#DataTableTotal tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text("$ " + cFormat.numToString(T_Pag, 0, ".", ","))
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
                arr.push(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO);
                arr1.push(parseFloat(Mx_Dtt[i].ATE_TOTAL));
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
                    name: 'Total',
                    data: arr1
                }]
            });
            $("#div_hide").show();
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



            //$("#TxtDate_01").val(Date_Now);
            //$("#TxtDate_02").val(Date_Now);
        });
    </script>


    <%-- CSS Personalizado --%>
    <style>
        #DataTable thead, #DataTableTotal thead {
            background-color: #28a745;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cph_Body" runat="server">

    <div class="card mb-3 border-bar">
        <div class="card-header bg-bar">
            <h5>Visor Listado de Atenciones Totales</h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <label for="fecha">Desde:</label>
                    <div class='input-group date' id='fecha1'>
                        <input type='text' id="Txt_Date01" class="form-control" readonly="true" placeholder="Desde..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label for="fecha">Desde:</label>
                    <div class='input-group date' id='fecha2'>
                        <input type='text' id="Txt_Date02" class="form-control" readonly="true" placeholder="Hasta..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label for="DdlProce">Lugar de TM:</label>
                    <select id="DdlProce" class="form-control"></select>
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
            <div class="col-lg-12">
                <div class="row mb-3">
                    <div class="col-lg">
                        <h5>Detalle Mensual</h5>
                        <div id="Div_Tabla_Data" class="table table-hover table-striped table-iris" style="overflow:auto"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg">
                        <h5>Totales</h5>
                        <div id="Div_Tabla_Total" class="table table-hover table-striped table-iris"></div>
                    </div>
                </div>
            </div>

        </div>
        <div class="row">
            <div class="col-lg-12">
                <h5>Gráfico</h5>
                <div id="Summary_Graph"></div>
            </div>
        </div>
    </div>
</asp:Content>