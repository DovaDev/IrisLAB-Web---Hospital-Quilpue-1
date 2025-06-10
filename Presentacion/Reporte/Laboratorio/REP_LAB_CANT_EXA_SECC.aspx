<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="REP_LAB_CANT_EXA_SECC.aspx.vb" Inherits="Presentacion.REP_LAB_CANT_EXA_SECC" %>

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
    <%-- Funciones Varias --%>
    <script>
        function Empty_Box(fr_color, bg_color, text) {
            ///<summary>Limpia el bloque de las tablas y escribe en él una cadena de texto</summary>
            ///<param name="fr_color" type="String">Color del texto en algún formato válido de CSS</param>
            ///<param name="bg_color" type="String">Color del fondo en algún formato válido de CSS</param>
            ///<param name="text" type="String">Texto a ingresar dentro del bloque</param>
            $("#Div_Table_Total").hide();
            $("#Div_Tabla_Data").empty().css({ "background": bg_color });
            $("#Div_Tabla_Data").append(
                $("<div>").css({
                    "width": "calc(100% - 60)",
                    "text-align": "center",
                    "padding": "30px",
                    "font-size": "30px",

                    "color": fr_color
                }).text(text)
            );
        }
    </script>
    <%-- Declaración de Eventos --%>
    <script>
        //DatePickers
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
            Empty_Box("#00000", "#ffffff", "Realice una Búsqueda.");
            AJAX_Ddl();
        });
        //Ajustes Visuales
        Empty_Box("#ffffff", "Realice una Búsqueda.");
        //Registrar Eventos
        $(document).ready(function () {
            //Registrar evento Click del Botón Buscar
            $("#Btn_Search").click(function () {
                AJAX_Dtt();
            });
            //Registrar evento Click del Botón Exportar
            $("#Btn_Export").click(function () {
                AJAX_Xls();
            });
        });
    </script>
    <%-- Llamadas AJAX --%>
    <script>
        //Objetos AJAX
        obj_AJAX_Ddl = 0;
        obj_AJAX_Dtt = 0;
        obj_AJAX_Xls = 0;
        //Objetos JSON
        obj_JSON_Ddl = [{
            "ID_SECCION": "",
            "SECC_COD": "",
            "SECC_DESC": "",
            "ID_ESTADO": ""
        }];
        obj_JSON_Dtt = [{
            "CF_COD": "",
            "CF_DESC": "",
            "TOTAL_ATE": ""
        }];
        //Declaraciones Funciones AJAX
        function AJAX_Ddl() {


            obj_AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "REP_LAB_CANT_EXA_SECC.aspx/Llenar_Ddl",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        obj_JSON_Ddl = JSON.parse(json_receiver);
                        Fill_Ddl();


                    } else {

                    }
                    $(".block_wait").hide();
                },
                "error": function (response) {

                }
            });
        }
        function AJAX_Dtt() {

            modal_show();
            var Data_Par = JSON.stringify({
                "ID_SECC": $("#DdlSeccion").val(),
                "DATE_str01": String($("#TxtDate_01").val()),
                "DATE_str02": String($("#TxtDate_02").val()),
            });
            obj_AJAX_Dtt = $.ajax({
                "type": "POST",
                "url": "REP_LAB_CANT_EXA_SECC.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        obj_JSON_Dtt = JSON.parse(json_receiver);
                        Fill_Dtt();
                        $(".block_wait").hide();


                    } else {
                        Empty_Box("#000000", "#ffffff", "Sin Resultados");

                        Hide_Modal();
                    }
                },
                "error": function (response) {

                    Hide_Modal();
                }
            });
        }
        function AJAX_Xls() {


            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "ID_SECC": $("#DdlSeccion").val(),
                "DATE_str01": String($("#TxtDate_01").val()),
                "DATE_str02": String($("#TxtDate_02").val()),
            });
            obj_AJAX_Xls = $.ajax({
                "type": "POST",
                "url": "REP_LAB_CANT_EXA_SECC.aspx/Gen_Excel",
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
    <%-- Funciones de Llenado --%>
    <script>
        function Fill_Ddl() {
            ///<summary>llenar DropDownList de Secciones</summary>
            $("#DdlSeccion").append(
                $("<option>", {
                    "value": 0
                }).text("Todos")
            );
            for (y = 0; y < obj_JSON_Ddl.length; ++y) {
                $("#DdlSeccion").append(
                    $("<option>", {
                        "value": obj_JSON_Ddl[y].ID_SECCION
                    }).text(obj_JSON_Ddl[y].SECC_DESC)
                );
            }
        }
        function Fill_Dtt() {
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
                $("<th>", { "class": "text-center"}).text("#"),
                $("<th>", { "class": "text-center"}).text("Código Fonasa"),
                $("<th>").text("Descripción de Preestación"),
                $("<th>", { "class": "text-center"}).text("Cantidad Exámenes")
                )
            );
            for (i = 0; i < obj_JSON_Dtt.length; ++i) {
                $("#DataTable tbody").append(

                    $("<tr>").append(
                    $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>", {
                            "align": "center",
                            "width": "20%"
                        }).text(obj_JSON_Dtt[i].CF_COD),
                        $("<td>", {
                            "align": "left",
                            "width": "60%"
                        }).text(obj_JSON_Dtt[i].CF_DESC),
                        $("<td>", {
                            "align": "center",
                            "width": "20%"
                        }).text(cFormat.numToString(obj_JSON_Dtt[i].TOTAL_ATE, 0, ".", ","))
                    )
                );
            }
            $("#DataTable").DataTable({
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
            $("#Div_Table_Total").show(function () {
                $("#Div_Total_Data").empty().css({ "background": "#ffffff" });
                $("<table>", {
                    "id": "DataTable_T",
                    "class": "display",
                    "width": "100%",
                    "cellspacing": "0"
                }).appendTo("#Div_Total_Data");
                $("#DataTable_T").append(
                    $("<tbody>")
                );
                $("#DataTable_T tbody").append(
                    $("<tr>").append(
                        $("<th>", {
                            "align": "right",
                            "width": "80%"
                        }).text("Total Exámenes"),
                        $("<td>", {
                            "align": "right",
                            "width": "20%"
                        }).text(function () {
                            var T_Total = 0;
                            for (y = 0; y < obj_JSON_Dtt.length; ++y) {
                                T_Total += parseFloat(obj_JSON_Dtt[y].TOTAL_ATE);
                            }
                            return cFormat.numToString(T_Total, 0, ".", ",");
                        }())
                    )
                );
            });
            Hide_Modal();
        }
    </script>

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
            <h5>Cantidad de Exámenes por Sección</h5>
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
                    <label for="DdlSeccion">Sección:</label>
                    <select id="DdlSeccion" class="form-control"></select>
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


