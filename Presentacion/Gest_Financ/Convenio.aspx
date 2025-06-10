<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Convenio.aspx.vb" Inherits="Presentacion.Convenio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>

    <%-- Botones --%>
    <link href="../../Resourses/Style/Buttons.css" rel="stylesheet" />
    <%--Esto es para que funcione el gráfico--%>
    <script src="../../Resourses/JS/HighCharts.js"></script>
    <script src="../../Resourses/JS/HighC_Exporting.js"></script>
    <script src="../../Resourses/JS/Custom/Custom_modal.js"></script>
    <script src="../../Resourses/JS/Custom/Custom_Objects.js"></script>
    <%-- Funciones del formulario --%>
    <script>
        var Date_Now = function () {
            ///<summary>Devuelve la Fecha de Hoy en formato dd/MM/yyyy</summary>
            //Obtener valores
            var obj_date = new Date();
            var dd = parseInt(obj_date.getDate());
            var mm = parseInt(obj_date.getMonth()) + 1;
            var yy = parseInt(obj_date.getFullYear());
            if (dd < 10) { dd = "0" + dd; }
            if (mm < 10) { mm = "0" + mm; }
            return String(dd + "/" + mm + "/" + yy);
        };
        function Empty_Box(fr_color, bg_color, text) {
            ///<summary>Limpia el bloque de las tablas y escribe en él una cadena de texto</summary>
            ///<param name="fr_color" type="String">Color del texto en algún formato válido de CSS</param>
            ///<param name="bg_color" type="String">Color del fondo en algún formato válido de CSS</param>
            ///<param name="text" type="String">Texto a ingresar dentro del bloque</param>
            $("#Div_Tabla_02").hide();
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
        //Objetos AJAX
        var AJAX_Ddl = 0;
        var AJAX_Dtt = 0;
        var AJAX_Xls = 0;
        //Datepickers
        $(document).ready(function () {
            $("#div_hide").hide();
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
            //Debug

        });
        //Eventos
        $(document).ready(function () {

            Call_Data_Ddl();
            $(".block_wait").fadeOut(500);
            $("#Btn_Search").click(function () {
                Call_Data_Table();
            });
            $("#Btn_Export").click(function () {
                Call_Gen_Xls();
            });
            //Debug

        });
    </script>
    <%-- Funciones AJAX --%>
    <script>
        //Elementos JSON
        var JSON_Ddl = [
            {
                "ID_PREVE": "null",
                "PREVE_COD": "null",
                "PREVE_DESC": "null",
                "ID_ESTADO": "null"
            }
        ];
        var JSON_Dtt = [
            {
                "CF_COD": "null",
                "CF_DESC": "null",
                "CANTIDAD": "null",
                "CF_PRECIO_AMB": "null",
                "COSTO_AMB": "null",
                "COSTO_DERIV": "null",
                "COSTO_TOTAL": "null",
                "PJE_CONV": "null",
                "PJE_LAB": "null"
            }
        ];
        function Call_Data_Ddl() {
            //Debug


            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "Convenio.aspx/JSON_Prev_Call",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (resp) {
                    var str_JSON = resp.d;
                    switch (str_JSON) {
                        case "null":
                            Empty_Box("#ffffff", "#c30000", "Sin Resultados");
                            //Debug

                            break;
                        default:
                            JSON_Ddl = JSON.parse(str_JSON);
                            Llenar_Ddl();
                            //Debug

                            break;
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (resp) {
                    $(".block_wait").fadeOut(500);
                    switch (resp) {
                        case "":
                            var str_Error = "El servidor no responde, comuníquese con el desarrollador del proyecto.";
                            cModal_Error("Error", str_Error);
                            //Debug

                            break;
                        default:
                            var str_Error = resp.responseJSON.ExceptionType + "\n \n";
                            str_Error = resp.responseJSON.Message;
                            cModal_Error("Error", str_Error);
                            //Debug

                            break;
                    }
                }
            });
        }
        function Call_Data_Table() {
            //Debug


            //Insertar parámetros
            var Data_Par = JSON.stringify({
                "ID_PREV": $("#DdlPrevision").val(),
                "DATE_str01": String($("#TxtDate_01").val()),
                "DATE_str02": String($("#TxtDate_02").val())
            });
            //Inicializar Objeto AJAX
            modal_show();
            AJAX_Dtt = $.ajax({
                "type": "POST",
                "url": "Convenio.aspx/JSON_Data_Call",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (resp) {
                    var str_JSON = resp.d;
                    switch (str_JSON) {
                        case "null":
                            Empty_Box("#000000", "#ffffff", "Sin Resultados");
                            //Debug

                            break;
                        default:
                            JSON_Dtt = JSON.parse(str_JSON);
                            Llenar_Dtt();
                            //Debug

                            break;
                    }
                    Hide_Modal();
                },
                "error": function (resp) {
                    $(".block_wait").fadeOut(500);
                    switch (resp) {
                        case "":
                            var str_Error = "El servidor no responde, comuníquese con el desarrollador del proyecto.";
                            cModal_Error("Error", str_Error);
                            //Debug

                            break;
                        default:
                            var str_Error = resp.responseJSON.ExceptionType + "\n \n";
                            str_Error = resp.responseJSON.Message;
                            cModal_Error("Error", str_Error);
                            //Debug

                            break;
                    }
                    Hide_Modal();
                    //Debug

                }
            });
        }
        function Call_Gen_Xls() {
            //Debug


            //Insertar parámetros
            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "ID_PREV": $("#DdlPrevision").val(),
                "DATE_str01": String($("#TxtDate_01").val()),
                "DATE_str02": String($("#TxtDate_02").val())
            });
            $(".block_wait").fadeIn(500);
            AJAX_Xls = $.ajax({
                "type": "POST",
                "url": "Convenio.aspx/Gen_Xls",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (resp) {
                    var str_JSON = resp.d;
                    $(".block_wait").fadeOut(500);
                    switch (str_JSON) {
                        case "null":
                            var str_Error = "La petición de generación de planilla Excel no se ha realizado debido ";
                            str_Error += "a que los parámetros de búsqueda no arrojaron resultados.";
                            cModal_Error("Error", str_Error);
                            //Debug

                            break;
                        default:
                            var str_Download = "La Planilla Excel se ha generado correctamente, puede descargarla haciendo click ";
                            str_Download += "<a href='" + str_JSON + "'>AQUÍ.</a>";
                            cModal_Notif("Archivo Generado", str_Download);
                            //Debug

                            break;
                    }
                },
                "error": function (resp) {
                    switch (resp) {
                        case "":
                            var str_Error = "El servidor no responde, comuníquese con el desarrollador del proyecto.";
                            cModal_Error("Error", str_Error);
                            //Debug

                            break;
                        default:
                            var str_Error = resp.responseJSON.ExceptionType + "\n \n";
                            str_Error = resp.responseJSON.Message;
                            cModal_Error("Error", str_Error);
                            //Debug

                            break;
                    }
                    //Debug

                }
            });
        }
    </script>
    <%-- Funciones de Llenado --%>
    <script>
        function Llenar_Ddl() {
            $("#DdlPrevision").empty();
            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#DdlPrevision");
            for (y = 0; y < JSON_Ddl.length; ++y) {
                $("<option>", {
                    "value": JSON_Ddl[y].ID_PREVE
                }).text(JSON_Ddl[y].PREVE_DESC).appendTo("#DdlPrevision");
            }
        }
        function Llenar_Dtt() {
            $("#Div_Tabla_Data").css({
                "color": "#000000",
                "background": "#ffffff"
            }).empty();
            $("#Div_Tabla_Data").append(
                $("<table>", {
                    "id": "Dtt_Data",
                    "class": "display",
                    "width": "100%",
                    "cellspacing": 0
                })
            );
            $("#Dtt_Data").append(
                $("<thead>").append(
                    $("<tr>").append(
                        $("<th>").text("#"),
                        $("<th>").text("Cod Fonasa"),
                        $("<th>").text("Descripción"),
                        $("<th>").text("Cantidad"),
                        $("<th>").text("Valor Unit."),
                        $("<th>").text("Valor Pac."),
                        $("<th>").text("Costo Deriv."),
                        $("<th>").text("Total Costos"),
                        $("<th>").text("Diferencial"),
                        $("<th>").text("% Aconcagua"),
                        $("<th>").text("% Laboratorio")
                    )
                ),
                $("<tbody>")
            );
            for (y = 0; y < JSON_Dtt.length; ++y) {
                $("<tr>").append(
                    $("<td>").attr({ "align": "left" }).text(function () {
                        var number_y = y + 1;
                        var n_Length = JSON_Dtt.length;
                        var str_L = String(n_Length).length;
                        for (i = 0; i < str_L; ++i) {
                            var y_Length = String(number_y).length;
                            if (y_Length < str_L) {
                                number_y = "0" + number_y;
                            }
                        }
                        return number_y;
                    }()),
                    $("<td>").attr({ "align": "left" }).text(JSON_Dtt[y].CF_COD),
                    $("<td>").attr({ "align": "left" }).text(JSON_Dtt[y].CF_DESC),
                    $("<td>").attr({ "align": "right" }).text(JSON_Dtt[y].CANTIDAD),
                    $("<td>").attr({ "align": "right" }).text("$ " + cFormat.numToString(JSON_Dtt[y].CF_PRECIO_AMB, 0, ".", ",")),
                    $("<td>").attr({ "align": "right" }).text("$ " + cFormat.numToString(JSON_Dtt[y].COSTO_AMB, 0, ".", ",")),
                    $("<td>").attr({ "align": "right" }).text("$ " + cFormat.numToString(JSON_Dtt[y].COSTO_DERIV, 0, ".", ",")),
                    $("<td>").attr({ "align": "right" }).text("$ " + cFormat.numToString(JSON_Dtt[y].COSTO_TOTAL, 0, ".", ",")),
                    $("<td>").attr({ "align": "right" }).text(function () {
                        var Str_OUT = "$ ";
                        var value = JSON_Dtt[y].COSTO_AMB - JSON_Dtt[y].COSTO_TOTAL;
                        Str_OUT += cFormat.numToString(value, 0, ".", ",");
                        return Str_OUT;
                    }()),
                    $("<td>").attr({ "align": "right" }).text(function () {
                        var Str_OUT = "$ ";
                        var value = JSON_Dtt[y].COSTO_AMB - JSON_Dtt[y].COSTO_TOTAL;
                        value = value * (JSON_Dtt[y].PJE_CONV * 0.01);
                        Str_OUT += cFormat.numToString(value, 0, ".", ",");
                        Str_OUT += " (" + JSON_Dtt[y].PJE_CONV + "%)";
                        return Str_OUT;
                    }()),
                    $("<td>").attr({ "align": "right" }).text(function () {
                        var Str_OUT = "$ ";
                        var value = JSON_Dtt[y].COSTO_AMB - JSON_Dtt[y].COSTO_TOTAL;
                        var value = value * (JSON_Dtt[y].PJE_LAB * 0.01);
                        Str_OUT += cFormat.numToString(value, 0, ".", ",");
                        Str_OUT += " (" + JSON_Dtt[y].PJE_LAB + "%)";
                        return Str_OUT;
                    }())
                ).appendTo("#Dtt_Data tbody");
            }
            $("#Dtt_Data").DataTable({
                "bSort": false,
                "iDisplayLength": 100,
                "language": {
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
            //Dibujar Totales
            var T_Cant = 0;
            var T_Prec = 0;
            var T_Deri = 0;
            var T_Tota = 0;
            var T_Dife = 0;
            var Pje_Ac = 0;
            var Pje_La = 0;
            for (y = 0; y < JSON_Dtt.length; ++y) {
                T_Cant += JSON_Dtt[y].CANTIDAD;
                T_Prec += JSON_Dtt[y].COSTO_AMB;
                T_Deri += JSON_Dtt[y].COSTO_DERIV;
                T_Tota += JSON_Dtt[y].COSTO_TOTAL;
                T_Dife += function () {
                    return JSON_Dtt[y].COSTO_AMB - JSON_Dtt[y].COSTO_TOTAL;
                }();
                Pje_Ac += function () {
                    var value = JSON_Dtt[y].COSTO_AMB - JSON_Dtt[y].COSTO_TOTAL;
                    value = value * (JSON_Dtt[y].PJE_CONV * 0.01);
                    return value;
                }();
                Pje_La += function () {
                    var value = JSON_Dtt[y].COSTO_AMB - JSON_Dtt[y].COSTO_TOTAL;
                    var value = value * (JSON_Dtt[y].PJE_LAB * 0.01);
                    return value;
                }();
            }
            $("#Div_Tabla_02").show();
            $("#Div_Tabla_02 div").empty();
            $("#Div_Tabla_02 div").append(
                $("<table>", {
                    "id": "Table_T"
                }).append(
                    $("<tbody>").append(
                        $("<tr>").append(
                            $("<th>", { "align": "center" }).text(""),
                            $("<th>", { "align": "center" }).text("Cant. Exám."),
                            $("<th>", { "align": "center" }).text("Valor Pac."),
                            $("<th>", { "align": "center" }).text("Cost. Deriv."),
                            $("<th>", { "align": "center" }).text("Cost. Total."),
                            $("<th>", { "align": "center" }).text("Diferencial"),
                            $("<th>", { "align": "center" }).text("% Aconcagua"),
                            $("<th>", { "align": "center" }).text("% Laboratorio")
                        ),
                        $("<tr>").append(
                            $("<th>", { "align": "right" }).text("Total:"),
                            $("<td>", { "align": "right" }).text(cFormat.numToString(T_Cant, 0, ".", ",")),
                            $("<td>", { "align": "right" }).text("$ " + cFormat.numToString(T_Prec, 0, ".", ",")),
                            $("<td>", { "align": "right" }).text("$ " + cFormat.numToString(T_Deri, 0, ".", ",")),
                            $("<td>", { "align": "right" }).text("$ " + cFormat.numToString(T_Tota, 0, ".", ",")),
                            $("<td>", { "align": "right" }).text("$ " + cFormat.numToString(T_Dife, 0, ".", ",")),
                            $("<td>", { "align": "right" }).text("$ " + cFormat.numToString(Pje_Ac, 0, ".", ",")),
                            $("<td>", { "align": "right" }).text("$ " + cFormat.numToString(Pje_La, 0, ".", ","))
                        )
                    )
                )
            );

            $("#div_hide").show();
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
            <h5>Tests fuera de Convenio</h5>
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
                    <label for="DdlPrevision">Previsión:</label>
                    <select id="DdlPrevision" class="form-control"></select>
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
    <div class="card p-3 border-bar" id="div_hide">
        <div class="col-lg">
            <h5>Detalle Mensual</h5>
            <div id="Div_Tabla_Data" class="table table-hover table-striped table-iris"></div>
        </div>

        <h5>Totales</h5>
        <div id="Div_Tabla_02" class="table table-hover table-striped table-iris"></div>
    </div>



</asp:Content>

