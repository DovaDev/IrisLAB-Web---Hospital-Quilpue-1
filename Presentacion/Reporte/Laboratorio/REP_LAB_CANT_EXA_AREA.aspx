<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="REP_LAB_CANT_EXA_AREA.aspx.vb" Inherits="Presentacion.REP_LAB_CANT_EXA_AREA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
        <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true"%>
    
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
                }).text("Realice una Búsqueda.")
            );
            //Llamar al llenado de los DropDownList
            Ajax_Ddl();
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
        var Mx_Ddl = [
            {
                "ID_AREA": 0,
                "AREA_COD": "asdf",
                "AREA_DESC": "dddd",
                "ID_ESTADO": 0
            }
        ];
        function Ajax_Ddl() {

            $.ajax({
                "type": "POST",
                "url": "REP_LAB_CANT_EXA_AREA.aspx/Llenar_Ddl",
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
                      
                        $("#Div_Tabla_Data").empty();
                        $("#Div_Tabla_Total").empty();
                        $("#Summary_Graph").empty();
                        $("#Div_dinero").empty();
                        $("#Div_Tabla_Data").append(
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
                "CF_DESC": "asdf",
                "ID_CODIGO_FONASA": 0,
                "ID_ESTADO": 0,
                "RLS_LS_DESC": "asdf",
                "AREA_DESC": "asdf",
                "ID_AREA": 0,
                "CF_COD": "asdf"
            }
        ];
        function Ajax_DataTable() {

            modal_show();
            var Data_Par = JSON.stringify({
                "ID_CODIGO_FONASA": $("#DdlExamen").val(),
                "DATE_str01": String($("#TxtDate_01").val()),
                "DATE_str02": String($("#TxtDate_02").val()),
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "REP_LAB_CANT_EXA_AREA.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        Fill_DataTable();
                        $(".block_wait").hide();

                    } else {

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
                    alert("Error en la Recepción de Datos");

                    Hide_Modal();
                }
            });
        }
        //Generar Excel
        function Ajax_Excel() {

            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DATE_str01": String($("#TxtDate_01").val()).replace(/\//g, "a"),
                "DATE_str02": String($("#TxtDate_02").val()).replace(/\//g, "a"),
                "ID_CODIGO_FONASA": $("#DdlExamen").val(),
                //"PREVE_DESC": $("#DdlExamen").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "REP_LAB_CANT_EXA_AREA.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    $(".block_wait").fadeOut(500);
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
        function Fill_Ddl() {
            $("#DdlExamen").empty();
            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#DdlExamen");
            for (y = 0; y < Mx_Ddl.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl[y].ID_AREA
                }).text(Mx_Ddl[y].AREA_DESC).appendTo("#DdlExamen");
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
                    $("<th>", { "class": "text-center" }).text("Código Fonasa"),
                    $("<th>").text("Descripción de Prestación"),
                    $("<th>", { "class": "text-center" }).text("Cantidad Exámenes")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].CF_COD),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].CF_DESC),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].TOTAL_ATE)
                    )
                );
            }
            $("#DataTable").DataTable({  "bSort": false,
                "iDisplayLength": 25,
                "language": {
                    "DisplayLength": 100,
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay concidencias",
                    "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
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
            //$("#TxtDate_01").val(Date_Now);
            //$("#TxtDate_02").val(Date_Now);
        });
    </script>
 
     <%-- CSS Personalizado --%>
    <style>
        #DataTable thead, #Table_T thead {
            background-color: #28a745;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="card mb-3 border-bar">
        <div class="card-header bg-bar">
            <h5>Cantidad de Exámenes por Area de Trabajo</h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <label for="fecha">Desde:</label>
                    <div class='input-group date' id='fecha1'>
                        <input type='text' id="TxtDate_01" class="form-control" readonly="true" placeholder="Desde..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label for="fecha">Desde:</label>
                    <div class='input-group date' id='fecha2'>
                        <input type='text' id="TxtDate_02" class="form-control" readonly="true" placeholder="Hasta..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label for="DdlExamen">Area de Trabajo:</label>
                    <select id="DdlExamen" class="form-control"></select>
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
            <div class="col-lg-12">
                <div class="row mb-3">
                    <div class="col-lg">
                        <h5>Listado de Exámenes</h5>
                        <div id="Div_Tabla_Data" class="table table-hover table-striped table-iris" style="overflow:auto"></div>
                    </div>
                </div>
              <%--  <div class="row">
                    <div class="col-lg">
                        <h5>Totales</h5>
                        <div id="Div_Tabla_02" class="table table-hover table-striped table-iris"></div>
                    </div>
                </div>--%>
            </div>
        </div>
        <%--<div class="row">
            <div class="col-lg-12">
                <h5>Gráfico</h5>
                <div id="Summary_Graph"></div>
            </div>
        </div>--%>
    </div>
</asp:Content>
