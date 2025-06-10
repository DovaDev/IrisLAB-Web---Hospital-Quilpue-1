<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Prevision_Det.aspx.vb" Inherits="Presentacion.Prevision_Det" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <%--Esto es para que funcione el gráfico--%>
    <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>
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
            $(".block_wait").hide();
            $("#Div_Tabla").empty().css({ "background": "#ffffff" });
            $("#Div_Tabla").append(
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
                "url": "Prevision_Det.aspx/Llenar_Ddl",
                //"data": '{}'
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl = JSON.parse(json_receiver);
                        Fill_Ddl();

                    } else {

                    }
                },
                "error": function (response) {
                    alert("Error en la Recepción de Datos");

                }
            });
        }
        //Json de llenado de DataTable
        var Mx_Dtt = [
            {
                "ID_ATENCION": 0,
                "ATE_NUM": 0,
                "ATE_FECHA": 0,
                "PREVE_DESC": 0,
                "ID_PREVE": 0,
                "ID_ESTADO": 0,
                "CF_DESC": 0,
                "CF_COD": 0,
                "ATE_DET_V_PREVI": 0,
                "ATE_DET_V_PAGADO": 0,
                "ATE_DET_V_COPAGO": 0,
                "PROC_DESC": 0,
                "ID_CODIGO_FONASA": 0,
                "PAC_NOMBRE": "",
                "PAC_APELLIDO": "",
                "PAC_RUT": "",
                "PAC_DNI": ""
            }
        ];
        function Ajax_DataTable() {
            modal_show();

            var Data_Par = JSON.stringify({
                "ID_PREV": $("#DdlPrevision").val(),
                "DATE_str01": $("#Txt_Date01 input").val(),
                "DATE_str02": $("#Txt_Date02 input").val(),
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Prevision_Det.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
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
                "ID_PREV": $("#DdlPrevision").val(),
                "DATE_str01": $("#Txt_Date01 input").val(),
                "DATE_str02": $("#Txt_Date02 input").val(),
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Prevision_Det.aspx/Gen_Excel",
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
                        cModal_Error("Error", str_Error);

                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500);
                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);

                    Hide_Modal();
                }
            });
        }
    </script>
    <%-- Funciones de Llenado de Elementos --%>
    <script>
        //Llenar DropDownList
        function Fill_Ddl() {
            $("#DdlPrevision").empty();
            //$("<option>", {
            //    "value": 0
            //}).text("Todos").appendTo("#DdlPrevision");
            for (y = 0; y < Mx_Ddl.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl[y].ID_PREVE
                }).text(Mx_Ddl[y].PREVE_DESC).appendTo("#DdlPrevision");
            }
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
            $("#DataTable").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable thead").attr("class", "cabezera");
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "text-center" }).text("#"),
                    $("<th>", { "class": "text-center" }).text("N° Atención"),
                    $("<th>").text("RUT/DNI"),
                    $("<th>").text("Nombre Paciente"),
                    $("<th>").text("Previsión"),
                    $("<th>", { "class": "text-center" }).text("Fecha"),
                    $("<th>").text("Lugar de TM"),
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
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].ATE_NUM),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].PAC_RUT + Mx_Dtt[i].PAC_DNI),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].PREVE_DESC),
                        $("<td>", { "align": "center" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt[i].ATE_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());
                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }
                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].PROC_DESC),
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
                    $("<th>").text("Valor Sistema"),
                    $("<th>").text("Valor Usuario"),
                    $("<th>").text("Valor Copago"),
                    $("<th>").text("Valor Pagado")
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
    <div class="flex_col">
        <div class="card mb-3 border-bar">
            <div class="card-header bg-bar p-2">
                <h5>Valorización de Atenciones por Previsión</h5>
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
                        <label for="DdlPrevision">Previsión:</label>
                        <select id="DdlPrevision" class="form-control"></select>
                    </div>
                    <div class="col-lg">
                        <button id="Btn_Search" type="button" class="btn btn-block btn-buscar btn-sm mt-0"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                        <button id="Btn_Export" type="button" class="btn btn-block btn-success btn-sm"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                    </div>
                </div>
                <%--<div class="row">
                    
                    <div class="col-lg">
                        
                    </div>
                </div>--%>
            </div>
        </div>

        <%--        <div id="Div_Error" class="div_error" runat="server">
            <p>Sin Resultados</p>
        </div>--%>
        <div id="Id_conte">
            <%-- Datatables con Resultados --%>
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar p-2">
                    <h5>Detalle Atenciones</h5>
                </div>

                <div id="Div_Tabla" class="card-body" style="width: 100%; overflow: auto">
                </div>

            </div>
            <%-- Table con Resultados --%>
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar p-2">
                    <h5>Totales</h5>
                </div>
                <div id="Div_Tabla_Total" class="card-body">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
