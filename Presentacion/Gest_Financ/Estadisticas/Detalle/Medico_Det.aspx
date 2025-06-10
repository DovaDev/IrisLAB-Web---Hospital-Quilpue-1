<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Medico_Det.aspx.vb" Inherits="Presentacion.Medico_Det" %>

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
            var aFecha1 = f1.split('-');
            var aFecha2 = f2.split('-');
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
            $("#Id_conte").hide();
            //Establecer Datepickers
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

            //Iniciar petición de datos requeridos en el inicio
            AJAX_DropDownList();
            //Registrar Botón Buscar
            $("#Btn_Search").click(function () {
                var Date_Diff = restaFechas(String($("#Txt_Date01 input").val()), String($("#Txt_Date02 input").val()));
                var Days_Lim = 90;
                if (Date_Diff <= Days_Lim) {
                    AJAX_DataTable();
                } else {
                    $("#mError_AAH h4").text("Rango de Fechas");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione un rango de fechas menor a 90 días.");
                    $("#mError_AAH").modal();
                }
            });
            //Registrar Botón Exportar
            $("#Btn_Export").click(function () {
                Ajax_Excel();
            });
        });
    </script>
    <%-- Peticiones AJAX --%>
    <script>
        //JSON de los DropDownList
        var MxDdl = [
            {
                "ID_DOCTOR": "",
                "DOC_NOMBRE": "",
                "DOC_APELLIDO": "",
                "ID_ESTADO": "",
                "ESP_DESC": "",
                "DOC_FONO1": "",
                "DOC_MOVIL1": ""
            }
        ];
        function AJAX_DropDownList() {

            $.ajax({
                "type": "POST",
                "url": "Medico_Det.aspx/Llenar_Ddl",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    Mx_Ddl = response.d;
                    Fill_Ddl();

                },
                "error": function (response) {
                    var str_Error = "Error interno del Servidor";
                    //cModal_Error("Error", str_Error);

                }
            });
        }
        //JSON para el DataTable
        var Mx_Dtt = [
            {
                "ID_ATENCION": "",
                "ATE_NUM": "",
                "ATE_FECHA": "",
                "PREVE_DESC": "",
                "ID_PREVE": "",
                "ID_ESTADO": "",
                "CF_DESC": "",
                "CF_COD": "",
                "ATE_DET_V_PREVI": "",
                "ATE_DET_V_PAGADO": "",
                "ATE_DET_V_COPAGO": "",
                "PROC_DESC": "",
                "DOC_NOMBRE": "",
                "DOC_APELLIDO": "",
                "ID_DOCTOR": "",
                "ID_CODIGO_FONASA": "",
                "PAC_NOMBRE": "",
                "PAC_APELLIDO": ""
            }
        ];
        function AJAX_DataTable() {
            modal_show();

            var Data_Par = JSON.stringify({
                "ID_DOC": $("#DdlMedico").val(),
                "DATE_str01": $("#Txt_Date01 input").val(),
                "DATE_str02": $("#Txt_Date02 input").val(),
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Medico_Det.aspx/Llenar_DataTable",
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
                        $("#Id_conte").show();
                        Fill_DataTable();

                    } else {

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
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
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
                "ID_MED": $("#DdlMedico").val(),
                "DATE_str01": $("#Txt_Date01 input").val(),
                "DATE_str02": $("#Txt_Date02 input").val(),
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Medico_Det.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    $(".block_wait").fadeOut(500);
                    if (json_receiver != "null") {
                        window.open(json_receiver, 'Download');
                        //cModal_Notif("Archivo Generado", str_Download);

                        Hide_Modal();
                    } else {
                        var str_Error = "La petición de generación de planilla Excel no se ha realizado debido ";
                        str_Error += "a que los parámetros de búsqueda no arrojaron resultados."
                        //cModal_Error("Error", str_Error);

                        Hide_Modal();
                    }
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
    <%-- Funciones de Llenado --%>
    <script>
        function Fill_Ddl() {
            $("#DdlMedico").empty();
            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#DdlMedico");
            for (y = 0; y < Mx_Ddl.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl[y].ID_DOCTOR
                }).text(Mx_Ddl[y].DOC_NOMBRE + " " + Mx_Ddl[y].DOC_APELLIDO).appendTo("#DdlMedico");
            }
        }
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
                    $("<th>", { "class": "text-center" }).text("N° Atención"),
                    $("<th>").text("Paciente"),
                    $("<th>").text("Médico"),
                    $("<th>", { "class": "text-center" }).text("Fecha"),
                    $("<th>").text("Lugar TM"),
                    $("<th>", { "class": "text-center" }).text("Código"),
                    $("<th>").text("Descripción"),
                    $("<th>").text("Valor Sistema"),
                    $("<th>").text("Valor Usuario"),
                    $("<th>").text("Valor Copago"),
                    $("<th>").text("Valor Pagado")
                )
            );
            for (i = 0; i < Mx_Dtt.length; ++i) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].ID_ATENCION),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].DOC_NOMBRE + " " + Mx_Dtt[i].DOC_APELLIDO),
                        $("<td>", { "align": "center" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt[i].ATE_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var MM = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());
                            if (dd < 10) { dd = "0" + dd; }
                            if (MM < 10) { MM = "0" + MM; }
                            var hh = parseInt(obj_date.getHours());
                            var mm = parseInt(obj_date.getMinutes());
                            if (hh < 10) { hh = "0" + hh; }
                            if (mm < 10) { mm = "0" + mm; }
                            return String(dd + "/" + MM + "/" + yy + " " + hh + ":" + mm);
                        }),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].PROC_DESC),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].CF_COD),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].CF_DESC),
                        $("<td>").text("$ " + cFormat.numToString(Mx_Dtt[i].ATE_DET_V_PREVI, 0, ".", ",")),
                        $("<td>").text("$ " + cFormat.numToString(Mx_Dtt[i].ATE_DET_V_PAGADO, 0, ".", ",")),
                        $("<td>").text("$ " + cFormat.numToString(Mx_Dtt[i].ATE_DET_V_COPAGO, 0, ".", ",")),
                        $("<td>").text("$ " + cFormat.numToString((parseFloat(Mx_Dtt[i].ATE_DET_V_PAGADO) + parseFloat(Mx_Dtt[i].ATE_DET_V_COPAGO)), 0, ".", ","))
                    )
                );
            }
            //llenar Totales
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
                    $("<th>").text("Total Sistema"),
                    $("<th>").text("Total Usuario"),
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
                T_Sis = parseFloat(T_Sis) + parseFloat(Mx_Dtt[i].ATE_DET_V_PREVI);
                T_Usu = parseFloat(T_Usu) + parseFloat(Mx_Dtt[i].ATE_DET_V_PAGADO);
                T_Cop = parseFloat(T_Cop) + parseFloat(Mx_Dtt[i].ATE_DET_V_COPAGO);
                T_Pag = parseFloat(T_Pag) + parseFloat(Mx_Dtt[i].ATE_DET_V_PAGADO) + parseFloat(Mx_Dtt[i].ATE_DET_V_COPAGO);
            }
            $("#DataTableTotal tbody").append(
                $("<tr>").append(
                    $("<td>").text("$ " + cFormat.numToString(T_Sis, 0, ".", ",")),
                    $("<td>").text("$ " + cFormat.numToString(T_Usu, 0, ".", ",")),
                    $("<td>").text("$ " + cFormat.numToString(T_Cop, 0, ".", ",")),
                    $("<td>").text("$ " + cFormat.numToString(T_Pag, 0, ".", ","))
                )
            );
            $("#DataTable").DataTable({
                "bSort": false,
                "binfo": false,
                "bSort": false,
                "iDisplayLength": 25,
                "language": {
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

        };
    </script>
    <style>
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
    <%-- Tabla de Búsqueda --%>
    <div class="card mb-3 border-bar">
        <div class="card-header bg-bar p-2">
            <h5>Valorización de Atenciones por Médicos</h5>
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
                    <label for="DdlMedico">Médico:</label>
                    <select id="DdlMedico" class="form-control"></select>
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
    <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
    <div id="Id_conte" class="w-100">

        <div class="card mb-3 border-bar">
            <div class="card-header bg-bar p-2">
                <h5>Tabla de Resultados</h5>
            </div>
            <div id="Div_Tabla" style="width: 100%; overflow: auto;" class="card-body"></div>
        </div>

        <div class="card mb-3 border-bar">
            <div class="card-header bg-bar p-2">
                <h5>Tabla Totales</h5>
            </div>
            <div id="Div_Tabla_Total" style="width: 100%;" class="card-body"></div>
        </div>
    </div>



</asp:Content>
