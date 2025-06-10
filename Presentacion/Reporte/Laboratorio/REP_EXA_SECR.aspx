<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="REP_EXA_SECR.aspx.vb" Inherits="Presentacion.REP_EXA_SECR" %>
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
                    "font-size": "30px",
                    "font-weight": 900
                }).text("Realice su Búsqueda.")
            );
            //Llamar al llenado de los DropDownList
            Ajax_Ddl();
            //Registrar evento Click del Botón Buscar
            $("#Btn_Search").click(function () {
                function restaFechas(f1, f2) {
                    var aFecha1 = f1.split('/');
                    var aFecha2 = f2.split('/');
                    var fFecha1 = Date.UTC(aFecha1[2], aFecha1[1] - 1, aFecha1[0]);
                    var fFecha2 = Date.UTC(aFecha2[2], aFecha2[1] - 1, aFecha2[0]);
                    var dif = fFecha2 - fFecha1;
                    var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
                    return dias;
                }
                var Date_Diff = restaFechas(String($("#TxtDate_01").val()), String($("#TxtDate_02").val()));
                if (Date_Diff <= 31) {
                    Ajax_DataTable();
                } else {
                    cModal_Error("Atención", "Realice una búsqueda usando un rango menor o igual a 30 días.");
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
                "ID_SECCION": 0,
                "SECC_COD": 0,
                "SECC_DESC": 0,
                "ID_ESTADO": "dddd"
            }
        ];
   
        function Ajax_Ddl() {

            $.ajax({
                "type": "POST",
                "url": "REP_EXA_SECR.aspx/Llenar_Ddl",
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
                        //cModal_Error("ERROR", "asdfasdfasdfas");
                        $("#Div_Tabla_Data").empty().css({ "background": "#c30000" });
                        $("#Div_Tabla_Total").empty().css({ "background": "#ffffff" });
                        $("#Summary_Graph").empty().css({ "background": "#ffffff" });
                        $("#Div_dinero").empty().css({ "background": "#ffffff" });
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

                    }
                },
                "error": function (response) {
                    cModal_Error("ERROR", "A ocurrido un error a nivel interno del lado del Server, disculpe las molestias.");

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
                "CF_COD": "asdf",
                "SECC_DESC": "asdf",
                "ID_SECCION": 0
                
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
                "url": "REP_EXA_SECR.aspx/Llenar_DataTable",
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
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    alert("Error en la Recepción de Datos");

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
                "url": "REP_EXA_SECR.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    $(".block_wait").fadeOut(500);
                    if (json_receiver != "null") {
                        var str_Download = "La Planilla Excel se ha generado correctamente, puede descargarla haciendo click ";
                        str_Download += "<a href='" + json_receiver + "'>AQUÍ.</a>"
                        cModal_Notif("Archivo Generado", str_Download);

                    } else {
                        var str_Error = "La petición de generación de planilla Excel no se ha realizado debido ";
                        str_Error += "a que los parámetros de búsqueda no arrojaron resultados."
                        cModal_Error("Error", str_Error);

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
            $("#DdlExamen").empty();
            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#DdlExamen");
            for (y = 0; y < Mx_Ddl.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl[y].ID_SECCION
                }).text(Mx_Ddl[y].SECC_DESC).appendTo("#DdlExamen");
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
                    $("<th>").text("#"),
                    $("<th>").text("Código Fonasa"),
                    $("<th>").text("Descripción de Prestación"),
                    $("<th>").text("Cantidad de Exámenes")
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
                "iDisplayLength": 100,
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
            $("#TxtDate_01").attr({
                "data-provide": "datepicker",
                "value": Date_Now
            });
            $("#TxtDate_02").attr({
                "data-provide": "datepicker",
                "value": Date_Now
            });
            $("#TxtDate_01").datepicker({
                format: "dd/mm/yyyy",
                disableTouchKeyboard: true,
                language: "es"
            });
            $("#TxtDate_02").datepicker({
                format: "dd/mm/yyyy",
                disableTouchKeyboard: true,
                language: "es"
            });
            //$("#TxtDate_01").val(Date_Now);
            //$("#TxtDate_02").val(Date_Now);
        });
    </script>
 
     <%-- CSS Personalizado --%>
    <style>
        .div_main p {margin: 0;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="block_wait">
        <p>Progreso</p>
        <div>
            <div class="event_rotation">
	            <div class="other">
    	            <div></div>
                </div>
	            <div class="blank">
                </div>
            </div>
        </div>
    </div>
    <div class="flex_col">
        <div class="div_main table_gen">
            <p>Cantidad de Exámenes Área y Seccion</p>
            <div>
                <table>
                    <tr>
                        <td width="90px" style="min-width: 90px;">
                            <div class="div_main table_gen" style="padding: 2.5px;">
                                <p>Desde:</p>
                                <div>
                                    <table>
                                        <tr>
                                            <td class="td_c" align="center">
                                                <input type="text" id="TxtDate_01" style="width: calc(100% - 10px);"> </input>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                        <td width="90px" style="min-width: 90px;">
                            <div class="div_main table_gen" style="padding: 2.5px;">
                                <p>Hasta:</p>
                                <div style="margin: 0;">
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <input type="text" id="TxtDate_02" style="width: calc(100% - 10px);"> </input>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                        <td style="width: calc(40% - 190px); min-width: 240px;">
                            <div class="div_main table_gen" style="padding: 2.5px;">
                                <p>Secciones:</p>
                                <div>
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <select id="DdlExamen" style="width: calc(100% - 10px);">
                                                </select>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                        <td width="30%" align="center">
                            <input type="button" id="Btn_Search" style="display: none;"/>
                            <label id="Lbl_Search" for="Btn_Search" class="btn btn_blue">
                                <img src="../../../../Resourses/Img/Btn_Elements/Lupa.png" />
                                <span>Buscar</span>
                            </label>
                        </td>
                        <td width="30%" align="center">
                            <input type="button" id="Btn_Export" style="display: none;" />
                            <label id="Lbl_Export" for="Btn_Export" class="btn btn_green">
                                <img src="../../../../Resourses/Img/Btn_Elements/Excel.png" />
                                <span>Exportar</span>
                            </label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="Div_Table" class="div_main table_data" runat="server">
            <p>Listado de Atenciones</p>
            <div>
                <div id="Div_Tabla_Data">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
