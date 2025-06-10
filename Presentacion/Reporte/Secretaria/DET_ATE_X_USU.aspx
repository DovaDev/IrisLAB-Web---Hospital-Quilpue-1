<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="DET_ATE_X_USU.aspx.vb" Inherits="Presentacion.DET_ATE_X_USU" %>

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
    <%-- Funciones varias --%>
    <script type="text/javascript">
        function jsDecimals(e) {

            var evt = (e) ? e : window.event;
            var key = (evt.keyCode) ? evt.keyCode : evt.which;
            if (key != null) {
                key = parseInt(key, 10);
                if ((key < 48 || key > 57) && (key < 96 || key > 105)) {
                    //Aca tenemos que reemplazar "Decimals" por "NoDecimals" si queremos que no se permitan decimales
                    if (!jsIsUserFriendlyChar(key, "NoDecimals")) {
                        return false;
                    }
                }
                else {
                    if (evt.shiftKey) {
                        return false;
                    }
                }
            }
            return true;
        }

        // Función para las teclas especiales
        //------------------------------------------
        function jsIsUserFriendlyChar(val, step) {
            // Backspace, Tab, Enter, Insert, y Delete
            if (val == 8 || val == 9 || val == 13 || val == 45 || val == 46) {
                return true;
            }
            // Ctrl, Alt, CapsLock, Home, End, y flechas
            if ((val > 16 && val < 21) || (val > 34 && val < 41)) {
                return true;
            }
            if (step == "Decimals") {
                if (val == 190 || val == 110) {  //Check dot key code should be allowed
                    return true;
                }
            }
            // The rest
            return false;
        }
    </script>

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
                }).text("Realice su Búsqueda.")

            );

            //Llamar al llenado de los DropDownList
            Ajax_Ddl_Prev();
            Ajax_Ddl_Proce();
            Ajax_Ddl_T_Pago();
            Ajax_Ddl();

            //Registrar evento Click del Botón Buscar
            $("#Btn_Search").click(function () {

                Ajax_DataTable();

            });

            $("#Btn_Export").click(function () {
                Ajax_Excel();
            });
            $("#E_DESDE").change(function () {
                var desde = $("#E_DESDE").val();

                if (desde == "") {
                    $("#E_DESDE").val(0);
                }

                if ((isNaN(desde) = false) && (desde > 150)) {
                    $("#E_DESDE").val(150);
                }

            });
            $("#E_HASTA").change(function () {
                var hasta = $("#E_HASTA").val();
                if (hasta == "") {
                    $("#E_HASTA").val(0);
                }

                if ((isNaN(hasta) = false) && (hasta > 150)) {
                    $("#E_HASTA").val(150);
                }
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

        var Mx_Ddl = [
                {
                    "ID_USUARIO": 0,
                    "USU_NOMBRE": "asdf",
                    "USU_APELLIDO": "asdf",
                    "ID_ESTADO": 0,
                    "PER_USU_DESC": "asdf",
                    "USU_NIC": "asdf"
                }
        ];

        function Ajax_Ddl_Prev() {



            $.ajax({
                "type": "POST",
                "url": "DET_ATE_X_USU.aspx/Llenar_Ddl_Prev",
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
                "url": "DET_ATE_X_USU.aspx/Llenar_Ddl_Proce",
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
                "url": "DET_ATE_X_USU.aspx/Llenar_Ddl_T_Pago",
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
        function Ajax_Ddl() {



            $.ajax({
                "type": "POST",
                "url": "DET_ATE_X_USU.aspx/Llenar_Ddl",
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
                "ATE_NUM": 0,
                "ATE_FECHA": 0,
                "ATE_DET_V_ID_ESTADO": 0,
                "EST_DESCRIPCION": 0,
                "CF_COD": 0,
                "CF_DESC": 0,
                "ID_CODIGO_FONASA": 0,
                "ID_ATENCION": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "PROC_DESC": 0,
                "ID_PROCEDENCIA": 0,
                "ATE_AÑO": 0,
                "SEXO_DESC": 0,
                "ID_PACIENTE": 0,
                "ID_SEXO": 0,
                "ID_ESTADO": 0,
                "PAC_RUT": 0,
                "PAC_FNAC": 0,
                "ATE_DET_V_PREVI": 0,
                "ATE_MES": 0,
                "ATE_DIA": 0,
                "TP_PAGO_DESC": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "PROGRA_DESC": 0,
                "ORD_DESC": 0,
                "ATE_DET_V_PAGADO": 0,
                "ATE_DET_V_COPAGO": 0,
                "ID_USUARIO": 0,
                "USU_NIC": 0,
                "USUARIO_DET": 0,
                "PREVE_DESC": 0

            }
        ];

        function Ajax_DataTable() {


            modal_show();
            var ss = $("#NUM").is(":checked");
            var estado = 0
            if (ss == true) {
                estado = $("#NUM").val();
            } else {
                estado = $("#Prev").val();
            }
            var Data_Par = JSON.stringify({
                "ID_PRE": $("#DdlPrevi").val(),
                "ID_PROCE": $("#DdlProce").val(),
                "ID_TP_PAGO": $("#Ddl_T_Pago").val(),
                "USUARIO": $("#DLLUSU").val(),
                "DATE_str01": String($("#TxtDate_01").val()),
                "DATE_str02": String($("#TxtDate_02").val()),
                "EDAD_DESDE": $("#E_DESDE").val(),
                "EDAD_HASTA": $("#E_HASTA").val(),
                "radio": estado,
            });

            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "DET_ATE_X_USU.aspx/Llenar_DataTable",
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


            var ss = $("#NUM").is(":checked");
            var estado = 0
            if (ss == true) {
                estado = $("#NUM").val();
            } else {
                estado = $("#Prev").val();
            }
            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "ID_PRE": $("#DdlPrevi").val(),
                "ID_PROCE": $("#DdlProce").val(),
                "ID_TP_PAGO": $("#Ddl_T_Pago").val(),
                "USUARIO": $("#DLLUSU").val(),
                "DATE_str01": String($("#TxtDate_01").val()),
                "DATE_str02": String($("#TxtDate_02").val()),
                "EDAD_DESDE": $("#E_DESDE").val(),
                "EDAD_HASTA": $("#E_HASTA").val(),
                "radio": estado,
            });

            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "DET_ATE_X_USU.aspx/Gen_Excel",
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
        }

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
        function Fill_Ddl() {
            $("#DLLUSU").empty();

            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#DLLUSU");
            for (y = 0; y < Mx_Ddl.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl[y].ID_USUARIO
                }).text(Mx_Ddl[y].USU_APELLIDO + " " + Mx_Ddl[y].USU_NOMBRE).appendTo("#DLLUSU");
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
                    $("<th>", { "class": "text-center" }).text("N° Atencion"),
                    $("<th>", { "class": "text-center" }).text("Fecha"),
                    $("<th>").text("Nombre"),
                    $("<th>").text("Exámen"),
                    $("<th>", { "class": "text-center" }).text("Cod. Fonasa"),
                    $("<th>").text("Procedencia"),
                    $("<th>").text("F. Pago"),
                    $("<th>").text("Previsión"),
                    $("<th>").text("Medico"),
                    $("<th>").text("Usuario")
                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].ATE_NUM),
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
                        $("<td>").text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>").text(Mx_Dtt[i].CF_DESC),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].CF_COD),
                        $("<td>").text(Mx_Dtt[i].PROC_DESC),
                        $("<td>").text(Mx_Dtt[i].TP_PAGO_DESC),
                        $("<td>").text(Mx_Dtt[i].PREVE_DESC),
                        $("<td>").text(Mx_Dtt[i].DOC_NOMBRE + " " + Mx_Dtt[i].DOC_APELLIDO),
                        $("<td>").text(Mx_Dtt[i].USU_NIC)
                    )
                );
            }

            $("#DataTable").DataTable({
                "bSort": false,
                "iDisplayLength": 25,
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
            <h5>Resumen de Atenciones por Usuario</h5>
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
                    <label for="fecha">Hasta:</label>
                    <div class='input-group date' id='fecha2'>
                        <input type='text' id="TxtDate_02" class="form-control" readonly="true" placeholder="Hasta..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label for="DLLUSU">Usuario:</label>
                    <select id="DLLUSU" class="form-control"></select>
                </div>
                <div class="col-lg">
                    <label for="Ddl_T_Pago">Forma de Pago:</label>
                    <select id="Ddl_T_Pago" class="form-control"></select>
                </div>
                <div class="col-lg">
                    <label for="NUM">Ordenar Por:</label><br />
                    <input type="radio" name="ee" value="0" id="NUM" checked="true" />
                    <label for="NUM">Numero</label><br />
                    <input type="radio" name="ee" value="1" id="Prev" />
                    <label for="Prev">Prevision</label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg">
                    <label for="Ddl_T_Pago">Edad Desde:</label>
                    <input onkeydown="return jsDecimals(event);" type="number" class="form-control" id="E_DESDE" size="3" max="150" min="0" value="0" />
                </div>
                <div class="col-lg">
                    <label for="Ddl_T_Pago">Edad Hasta:</label>
                    <input onkeydown="return jsDecimals(event);" type="number" class="form-control" id="E_HASTA" size="3" max="150" min="0" value="0" />
                </div>
                <div class="col-lg">
                    <label for="DdlProce">Lugar de TM:</label>
                    <select id="DdlProce" class="form-control"></select>
                </div>
                <div class="col-lg">
                    <label for="DdlPrevi">Prevision:</label>
                    <select id="DdlPrevi" class="form-control"></select>
                </div>
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
                        <h5>Listado de Atenciones</h5>
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


