<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Cupo_Tot_ate_2.aspx.vb" Inherits="Presentacion.Cupo_Tot_ate_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>

    <%-- Botones --%>
<%--    <link href="../../../../Resourses/Style/Buttons.css" rel="stylesheet" />--%>
    <%--Esto es para que funcione el gráfico--%>
<%--    <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>
    <script src="/js/Custom_modal.js"></script>
    <script src="/js/Custom_Objects.js"></script>--%>
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
                //function restaFechas(f1, f2) {
                //    var aFecha1 = f1.split('-');
                //    var aFecha2 = f2.split('-');
                //    var fFecha1 = Date.UTC(aFecha1[2], aFecha1[1] - 1, aFecha1[0]);
                //    var fFecha2 = Date.UTC(aFecha2[2], aFecha2[1] - 1, aFecha2[0]);
                //    var dif = fFecha2 - fFecha1;
                //    var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
                //    return dias;
                //}
                //var Date_Diff = restaFechas(String($("#Txt_Date01 input").val()), String($("#Txt_Date02 input").val()));
                //if (Date_Diff <= 31) {
                console.log("Botonclivk");
                    Ajax_DataTable();
                //} else {
                //    $("#mError_AAH h4").text("Rango de Fechas");
                //    $("#mError_AAH button").attr("class", "btn btn-danger");
                //    $("#mError_AAH p").text("Por favor, seleccione un rango de fechas menor a 30 días.");
                //    $("#mError_AAH").modal();
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
        var Mx_Ddl = [
            {
                "ID_PROCEDENCIA": "",
                "PROC_COD": "",
                "PROC_DESC": "",
                "ID_ESTADO": ""
            }
        ];
        function Ajax_Ddl() {

            $.ajax({
                "type": "POST",
                "url": "Cupo_Tot_ate.aspx/Llenar_Ddl_LugarTM",
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

                    console.log(response);


                }
            });
        }
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
        
        };
        //Json de llenado de DataTable
        var Mx_Dtt = [
            {
                "CONF_DIAS_EXA":0,
                "TOTAL_AGEND_CUPO_NORMAL ": 0,
                "TOTAL_AGEND_PRIORITARIO": 0,
                "TOTAL_AGEND_ESPONTANEO": 0,
                "TOTAL_CUPO_NORMAL ": 0,
                "TOTAL_PRIORITARIO": 0,
                "TOTAL_ESPONTANEO": 0,
                "PREI_FECHA_PRE": ""
            }
        ];
        function Ajax_DataTable() {
            modal_show();
            var Data_Par = JSON.stringify({
                "id": $("#Procedencia").val(),
                "fecha": $("#Txt_Date01 input").val(),
                "fecha2": $("#Txt_Date02 input").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Cupo_Tot_ate_2.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;
                        //for (i = 0; i < Mx_Dtt.length; ++i) {
                        //    var date_x = Mx_Dtt[i].ATE_FECHA;
                        //    date_x = String(date_x).replace("/Date(", "");
                        //    date_x = date_x.replace(")/", "");
                        //    var Date_Change = new Date(parseInt(date_x));
                        //    Mx_Dtt[i].ATE_FECHA = Date_Change;
                        //}
                        //console.log(Mx_Dtt);
                        Hide_Modal();
                        $("#Id_conte").show();
                        Fill_DataTable();
   

                    } else {
                        Hide_Modal();
                        console.log("no");
                        $("#mError_AAH h4").text("Sin Resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda seleccionada.");
                        $("#mError_AAH").modal();
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
                    console.log(response);

                }
            });
        }
        //Generar Excel
        function Ajax_Excel() {
            modal_show();
            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "PROC": $("#Procedencia").val(),
                "FECHA1": $("#Txt_Date01 input").val(),
                "FECHA2": $("#Txt_Date02 input").val()
                //"PREVE_DESC": $("#DdlPrevision").val()
            });
            console.log(Data_Par);
            $.ajax({
                "type": "POST",
                "url": "Cupo_Tot_ate_2.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    Hide_Modal();
                    if (json_receiver != "null") {
                        window.open(json_receiver, 'Download');

                    } else {
                        $("#mError_AAH h4").text("Sin Resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para exportar en la búsqueda seleccionada.");
                        $("#mError_AAH").modal();

                    }
                },
                "error": function (response) {
                    alert("Error en procesar datos");

                }
            });
        }
    </script>
    <%-- Funciones de Llenado de Elementos --%>
    <script>
        //Llenar DropDownList
        function Fill_Ddl() {
            $("#DdlPrevision").empty();
            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#DdlPrevision");
            for (y = 0; y < Mx_Ddl.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl[y].ID_PREVE
                }).text(Mx_Ddl[y].PREVE_DESC).appendTo("#DdlPrevision");
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
                    $("<th>", { "class": "text-center" }).text("#"),
                    $("<th>", { "class": "text-center" }).text("Fecha"),
                    $("<th>", { "class": "text-center" }).text("Día"),
                    $("<th>", { "class": "text-center" }).text("Cupo Normal"),
                    $("<th>", { "class": "text-center" }).text("Agen. Normal"),
                    $("<th>", { "class": "text-center" }).text("Disponible Normal"),
                    //$("<th>", { "class": "text-center" }).text("Cupo Prioritario"),
                    //$("<th>", { "class": "text-center" }).text("Agen. Prioritario"),
                    //$("<th>", { "class": "text-center" }).text("Disponible Prioritario"),
                    //$("<th>", { "class": "text-center" }).text("Cupo Espontáneo"),
                    //$("<th>", { "class": "text-center" }).text("Agen. Espontáneo"),
                    //$("<th>", { "class": "text-center" }).text("Disponible Espontáneo"),
                    $("<th>", { "class": "text-center" }).text("Total")
                )
            );
            let cnt_i = 1;
            Mx_Dtt.forEach(aah => {

                moment.locale('es');
                var ffec = moment(aah.PREI_FECHA_PRE).format("DD-MM-YYYY");
                var fdia = moment(ffec, "DDMMYYYY").format('dddd');

                if (fdia != "Domingo") {
                    $("<tr>").append(
                         $("<td>").css({ "text-align": "center", "font-weight": "bold" }).text(cnt_i),
                         $("<td>").css("text-align", "center").text(moment(aah.PREI_FECHA_PRE).format("DD-MM-YYYY")),
                         $("<td>").css("text-align", "center").text(fdia),
                         $("<td>").css("text-align", "center").text(aah.TOTAL_CUPO_NORMAL),
                         $("<td>").css("text-align", "center").text(aah.TOTAL_AGEND_CUPO_NORMAL),
                         //$("<td>").css("text-align", "center").text(() => {
                         //    let dif_Norm;
                         //    dif_Norm = aah.TOTAL_CUPO_NORMAL - aah.TOTAL_AGEND_CUPO_NORMAL;
                         //    if (dif_Norm >= 0) {
                         //        return dif_Norm;
                         //    }
                         //    else {
                         //        return 0;
                         //    }
                         //}),
                         //$("<td>").css("text-align", "center").text(aah.TOTAL_PRIORITARIO),
                         //$("<td>").css("text-align", "center").text(aah.TOTAL_AGEND_PRIORITARIO),
                         //$("<td>").css("text-align", "center").text(() => {
                         //    let dif_Prio;
                         //    dif_Prio = aah.TOTAL_PRIORITARIO - aah.TOTAL_AGEND_PRIORITARIO;
                         //    if (dif_Prio >= 0) {
                         //        return dif_Prio;
                         //    }
                         //    else {
                         //        return 0;
                         //    }
                         //}),
                         //$("<td>").css("text-align", "center").text(aah.TOTAL_ESPONTANEO),
                         //$("<td>").css("text-align", "center").text(aah.TOTAL_AGEND_ESPONTANEO),
                         $("<td>").css("text-align", "center").text(() => {
                             let dif_Espo; 
                             dif_Espo = aah.TOTAL_ESPONTANEO - aah.TOTAL_AGEND_ESPONTANEO;
                             if (dif_Espo >= 0) {
                                 return dif_Espo;
                             }
                             else {
                                 return 0;
                             }
                         }),
                         $("<td>").css("text-align", "center").text(aah.TOTAL_CUPO_NORMAL + aah.TOTAL_PRIORITARIO + aah.TOTAL_ESPONTANEO)
                      
                    ).appendTo("#DataTable tbody");
                    cnt_i += 1;
                }
            });
            ////LLENADO TABLA TOTALES
            //$("#Div_Tabla_Total").empty().css({ "background": "#ffffff" });
            //$("<table>", {
            //    "id": "DataTableTotal",
            //    "class": "display",
            //    "width": "100%",
            //    "cellspacing": "0"
            //}).appendTo("#Div_Tabla_Total");
            //$("#DataTableTotal").append(
            //    $("<thead>"),
            //    $("<tbody>")
            //);
            //$("#DataTableTotal").attr("class", "table table-hover table-striped table-iris");
            //$("#DataTableTotal thead").attr("class", "cabezera");
            //$("#DataTableTotal thead").append(
            //    $("<tr>").append(
            //        $("<th>", { "class": "text-center" }).text("Cant. Cupo Normal"),
            //        $("<th>", { "class": "text-center" }).text("Cant. Cupo Prioritario"),
            //        $("<th>", { "class": "text-center" }).text("Cant. Cupo Espontáneo"),
            //        $("<th>", { "class": "text-center" }).text("Cant. Cupo PAP"),
            //            $("<th>", { "class": "text-center" }).text("Cant. Sobre Cupo"),
            //        $("<th>", { "class": "text-center" }).text("Total")
            //    )
            //);
            var T_Ate = 0;
            var T_Exa = 0;
            var T_Sis = 0;
            var T_Usu = 0;
            var T_Usu_2 = 0;
            for (i = 0; i < Mx_Dtt.length; i++) {
                T_Ate = T_Ate + Mx_Dtt[i].TOTAL_AGEND_CUPO_NORMAL;
                T_Exa = T_Exa + Mx_Dtt[i].TOTAL_AGEND_PRIORITARIO;
                T_Sis = T_Sis + Mx_Dtt[i].TOTAL_AGEND_ESPONTANEO;
                T_Usu = T_Usu + Mx_Dtt[i].TOTAL_AGEND_PAP;
                T_Usu_2 = T_Usu_2 + Mx_Dtt[i].TOTAL_SOBRE_CUPO;
                         
            }
            $("#DataTableTotal tbody").append(
                $("<tr>").append(
                    $("<td>", { "align": "center" }).text(T_Ate),
                    $("<td>", { "align": "center" }).text(T_Exa),
                    $("<td>", { "align": "center" }).text(T_Sis),
                    $("<td>", { "align": "center" }).text(T_Usu),
                           $("<td>", { "align": "center" }).text(T_Usu_2),
                    $("<td>", { "align": "center" }).text(T_Usu + T_Sis + T_Exa + T_Ate + T_Usu_2)
                )
            );
            //var arr = ["Array"];
            //var arr1 = [0];
            //var arr2 = [0];
            //for (i = 0; i < Mx_Dtt.length; i++) {
            //    if (i == 0) {
            //        arr.pop();
            //        arr1.pop();
            //        arr2.pop();
            //    }
            //    arr.push(Mx_Dtt[i].PREVE_DESC);
            //    arr1.push(parseFloat(Mx_Dtt[i].TOTAL_ATE));
            //    arr2.push(parseFloat(Mx_Dtt[i].TOT_FONASA));
            //}
            //Highcharts.chart('Summary_Graph', {
            //    chart: {
            //        type: 'line'
            //    },
            //    title: {
            //        text: ''
            //    },
            //    subtitle: {
            //        text: ''
            //    },
            //    xAxis: {
            //        categories: arr
            //    },
            //    yAxis: {
            //        title: {
            //            text: 'Ventas'
            //        }
            //    },
            //    plotOptions: {
            //        line: {
            //            dataLabels: {
            //                enabled: true
            //            },
            //            enableMouseTracking: false
            //        }
            //    },
            //    series: [{
            //        name: 'Cantidad Atenciones',
            //        data: arr1
            //    }, {
            //        name: 'Cantidad Exámenes',
            //        data: arr2
            //    }]
            //});
            //var AR_pre = [0];
            //var ARTota_sis = [0];
            //var ARTota_usu = [0];
            //var ARTota_Copa = [0];
            //var ARTota_Tota_pago = [0];
            //for (i = 0; i < Mx_Dtt.length; i++) {
            //    if (i == 0) {
            //        AR_pre.pop();
            //        ARTota_sis.pop();
            //        ARTota_usu.pop();
            //        ARTota_Copa.pop();
            //        ARTota_Tota_pago.pop();
            //    }
            //    AR_pre.push(Mx_Dtt[i].PREVE_DESC);
            //    ARTota_sis.push(parseFloat(Mx_Dtt[i].TOTA_SIS));
            //    ARTota_usu.push(parseFloat(Mx_Dtt[i].TOTA_USU));
            //    ARTota_Copa.push(parseFloat(Mx_Dtt[i].TOTA_COPA));
            //    ARTota_Tota_pago.push(parseFloat(Mx_Dtt[i].TOTA_USU) + parseFloat(Mx_Dtt[i].TOTA_COPA));
            //}
            //Highcharts.chart('Div_dinero', {
            //    title: {
            //        text: ''
            //    },
            //    subtitle: {
            //        text: ''
            //    },
            //    xAxis: {
            //        categories: AR_pre
            //    },
            //    yAxis: {
            //        title: {
            //            text: 'Ventas'
            //        }
            //    },
            //    legend: {
            //        layout: 'vertical',
            //        align: 'right',
            //        verticalAlign: 'middle'
            //    },
            //    series: [{
            //        name: 'Total Sistema',
            //        data: ARTota_sis
            //    }, {
            //        name: 'Total Usuarios',
            //        data: ARTota_usu
            //    }, {
            //        name: 'Total Copago',
            //        data: ARTota_Copa
            //    }, {
            //        name: 'Total Pagado',
            //        data: ARTota_Tota_pago
            //    }]
            //});
        }
    </script>

    <%-- CSS Personalizado --%>
    <style>
        .div_main p {
            margin: 0;
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
                <h5>Resumen de Cupos Agendados</h5>
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
                        <label for="DdlPrevision">Procedencia:</label>
                        <select id="Procedencia" class="form-control"></select>
                    </div>
                    <%--  <div class="col-lg-1">
                   
                </div>
                <div class="col-lg-1">
                   
                </div>--%>
                </div>
                <div class="row">
                    <div class="col-lg">
                        <button id="Btn_Search" type="button" class="btn btn-block btn-buscar btn-sm"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                    </div>
                    <div class="col-lg">
                        <button id="Btn_Export" type="button" class="btn btn-block btn-success btn-sm"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                    </div>
                </div>
            </div>
        </div>

        <div id="Id_conte">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar p-2">
                    <h5>Total de Agendados por Cupo</h5>
                </div>
                <div id="Div_Tabla_Data" class="card-body" style="overflow:auto">
                </div>
            </div>

            <%--<div class="card mb-3 border-bar">
                <div class="card-header bg-bar p-2">
                    <h5>Totales</h5>
                </div>
                <div id="Div_Tabla_Total" class="card-body" style="overflow:auto">
                </div>
            </div>        --%>
        </div>
    </div>
</asp:Content>
