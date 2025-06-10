<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="LugarTM_Det.aspx.vb" Inherits="Presentacion.LugarTM_Det" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <!-- Colocar esto para forzar el evento load -->
    <%@ OutputCache Location="None" NoStore="true" %>

    <!--Custom JS-->
    <script src="../../../js/Custom_Objects.js"></script>
    <script src="../../../js/IrisLabResourses.js"></script>

    <!--Funciones Globales-->
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
            var aFecha1 = f1.split('/');
            var aFecha2 = f2.split('/');
            var fFecha1 = Date.UTC(aFecha1[2], aFecha1[1] - 1, aFecha1[0]);
            var fFecha2 = Date.UTC(aFecha2[2], aFecha2[1] - 1, aFecha2[0]);
            var dif = fFecha2 - fFecha1;
            var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
            return dias;
        };
    </script>

    <!--inicialización-->
    <script>
        $(document).ready(function () {
            $("#div_hide").hide();
            $("#Txt_Date01 input").val(Date_Now);
            $("#Txt_Date02 input").val(Date_Now);
            $("#Txt_Date01").datetimepicker({
                debug: true,
                icons: {
                    previous: 'fa fa-arrow-left',
                    next: 'fa fa-arrow-right'
                },
                format: 'dd/mm/yyyy',
                language: 'es',
                weekStart: 1,
                autoclose: true,
                minView: 2
            });

            $("#Txt_Date02").datetimepicker({
                debug: true,
                icons: {
                    previous: 'fa fa-arrow-left',
                    next: 'fa fa-arrow-right'
                },
                format: 'dd/mm/yyyy',
                language: 'es',
                weekStart: 1,
                autoclose: true,
                minView: 2
            });

            //Eventos
            $("#Btn_Search").click(function () {
                AJAX_DataTable();
            });

            modal_show();
            AJAX_Ddl_Prev();
            AJAX_Ddl_Proc();
            AJAX_Ddl_Pago();
        });
    </script>

    <!--Peticiones AJAX-->
    <script>
        //Json de llenado de DropDownList
        var Mx_Ddl_Prev = [
            {
                "ID_PREVE": 0,
                "PREVE_COD": "asdf",
                "PREVE_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];

        function AJAX_Ddl_Prev() {



            $.ajax({
                "type": "POST",
                "url": "LugarTM_Det.aspx/Llenar_Ddl",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_Prev = json_receiver;
                        Fill_Ddl_Prev();




                    } else {


                    }
                    Hide_Modal();
                },
                "failure": function (response) {
                    Hide_Modal();
                    $("#mdlNotif .modal-header h4").text(String(response.responseJSON.ExceptionType).trim());
                    $("#mdlNotif .modal-body p").html(response.responseJSON.Message);
                    $("#mdlNotif").modal();



                }
            });
        }

        var Mx_Ddl_Proc = [
            {
                "ID_PROCEDENCIA": 0,
                "PROC_COD": "asdf",
                "PROC_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];


        function AJAX_Ddl_Proc() {



            $.ajax({
                "type": "POST",
                "url": "LugarTM_Det.aspx/Llenar_Ddl_Proce",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_Proc = json_receiver;

                        Fill_Ddl_Proc();




                    } else {



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


        var Mx_Ddl_Pago = [
            {
                "ID_TP_PAGO": 0,
                "TP_PAGO_DESC": "asdf",
                "TP_PAGO_ING": "asdf",
                "ID_ESTADO": 0
            }
        ];

        function AJAX_Ddl_Pago() {



            $.ajax({
                "type": "POST",
                "url": "LugarTM_Det.aspx/Llenar_Ddl_T_Pago",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_Pago = json_receiver;
                        Fill_Ddl_Pago();




                    } else {



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


        //JSON para el DataTable
        var Mx_Dtt = [
            {
                "ATE_NUM": "",
                "ATE_FECHA": "",
                "ATE_DET_V_ID_ESTADO": "",
                "EST_DESCRIPCION": "",
                "CF_COD": "",
                "CF_DESC": "",
                "ID_CODIGO_FONASA": "",
                "ID_ATENCION": "",
                "PAC_NOMBRE": "",
                "PAC_APELLIDO": "",
                "PROC_DESC": "",
                "ID_PROCEDENCIA": "",
                "ATE_AÑO": "",
                "SEXO_DESC": "",
                "ID_PACIENTE": "",
                "ID_SEXO": "",
                "ID_ESTADO": "",
                "PAC_RUT": "",
                "PAC_FNAC": "",
                "ATE_DET_V_PREVI": "",
                "ATE_MES": "",
                "ATE_DIA": "",
                "TP_PAGO_DESC": "",
                "PREVE_DESC": "",
                "DOC_NOMBRE": "", "ATE_DIA": "",
                "DOC_APELLIDO": "",
                "PROGRA_DESC": ""
            }
        ];

        function AJAX_DataTable() {



            //Función para obtener el valor del campo de Edad
            function getEdad(txt_str) {
                var numIn = $(txt_str).val();

                if ($re.isNumeric(numIn) == true) {
                    numIn = parseFloat(numIn);
                    numIn = $re.cutDecimals(numIn, 0);
                    numIn = parseInt(numIn);

                    if ((numIn < 0) || (numIn > 150)) {
                        $("#mdlNotif .modal-header h4").text("Error");
                        $("#mdlNotif .modal-body p").html("Debe de colocar un valor entre 0 y 150. Se reemplazará el valor por cero.");
                        $("#mdlNotif").modal();

                        $(txt_str).val(0);
                        return null;
                    } else {
                        return numIn;
                    }
                } else {
                    $("#mdlNotif .modal-header h4").text("Error");
                    $("#mdlNotif .modal-body p").html("Debe de colocar un valor numérico como fecha. Se reemplazará el valor por cero.");
                    $("#mdlNotif").modal();

                    $(txt_str).val(0);
                    return null;
                }
            };

            //Declaraciones
            var E_Desde = getEdad("#Txt_Edad01");
            var E_HASTA = getEdad("#Txt_Edad02");

            if ((E_Desde == null) || (E_HASTA == null)) {



                return;
            }

            var Data_Par = JSON.stringify({
                "DESDE": String($("#Txt_Date01 input").val()),
                "HASTA": String($("#Txt_Date02 input").val()),
                "ID_CF": $("#Ddl_Proc").val(),
                "ID_FP": $("#Ddl_Pago").val(),
                "ID_PREV": $("#Ddl_Prev").val(),
                "E_DESDE": E_Desde,
                "E_HASTA": E_HASTA
            });
            modal_show();

            $.ajax({
                "type": "POST",
                "url": "LugarTM_Det.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = json_receiver;

                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].ATE_FECHA = Date_Change;
                        }

                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].PAC_FNAC;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].PAC_FNAC = Date_Change;
                        }
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

        //Generar Excel
        function AJAX_Excel() {



            //Función para obtener el valor del campo de Edad
            function getEdad(txt_str) {
                var numIn = $(txt_str).val();

                if ($re.isNumeric(numIn) == true) {
                    numIn = parseFloat(numIn);
                    numIn = $re.cutDecimals(numIn, 0);
                    numIn = parseInt(numIn);

                    if ((numIn < 0) || (numIn > 150)) {
                        $("#mdlNotif .modal-header h4").text("Error");
                        $("#mdlNotif .modal-body p").html("Debe de colocar un valor entre 0 y 150. Se reemplazará el valor por cero.");
                        $("#mdlNotif").modal();

                        $(txt_str).val(0);
                        return null;
                    } else {
                        return numIn;
                    }
                } else {
                    $("#mdlNotif .modal-header h4").text("Error");
                    $("#mdlNotif .modal-body p").html("Debe de colocar un valor numérico como fecha. Se reemplazará el valor por cero.");
                    $("#mdlNotif").modal();

                    $(txt_str).val(0);
                    return null;
                }
            };

            //Declaraciones
            var E_Desde = getEdad("#Txt_Date01");
            var E_HASTA = getEdad("#Txt_Edad02");

            if ((E_Desde == null) || (E_HASTA == null)) {



                return;
            }

            var Data_Par = JSON.stringify({
                "MAIN_URL": location.origin,
                "DESDE": String($("#Txt_Date01 input").val()).replace(/\//g, "a"),
                "HASTA": String($("#Txt_Date02 input").val()).replace(/\//g, "a"),
                "ID_CF": $("#Ddl_Proc").val(),
                "ID_FP": $("#Ddl_Pago").val(),
                "ID_PREV": $("#Ddl_Prev").val(),
                "E_DESDE": E_Desde,
                "E_HASTA": E_HASTA
            });
            modal_show();

            $.ajax({
                "type": "POST",
                "url": "LugarTM_Det.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;

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
                    Hide_Modal();
                    $("#mdlNotif .modal-header h4").text(String(response.responseJSON.ExceptionType).trim());
                    $("#mdlNotif .modal-body p").html(response.responseJSON.Message);
                    $("#mdlNotif").modal();



                }
            });
        }
    </script>

    <!--Opciones de Llenado-->
    <script>
        //Llenar DropDownList
        function Fill_Ddl_Prev() {
            $("#Ddl_Prev").empty();

            //$("<option>", {
            //    "value": 0
            //}).text("Todos").appendTo("#Ddl_Prev");
            for (y = 0; y < Mx_Ddl_Prev.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl_Prev[y].ID_PREVE
                }).text(Mx_Ddl_Prev[y].PREVE_DESC).appendTo("#Ddl_Prev");
            }
        };

        function Fill_Ddl_Proc() {
            $("#Ddl_Proc").empty();

            var procee = Galletas.getGalleta("USU_TM");

            if (procee == 0) {
                $("<option>",
                {
                    "value": "0"
                }
                ).text("Todos").appendTo("#Ddl_Proc");
                Mx_Ddl_Proc.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Ddl_Proc");
                });
            }
            else {
                Mx_Ddl_Proc.forEach(aaa => {
                    if (aaa.ID_PROCEDENCIA == procee) {
                        $("<option>",
                          {
                              "value": aaa.ID_PROCEDENCIA
                          }
                       ).text(aaa.PROC_DESC).appendTo("#Ddl_Proc");
                    }

                });
            }
        };

        function Fill_Ddl_Pago() {
            $("#Ddl_Pago").empty();

            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#Ddl_Pago");
            for (y = 0; y < Mx_Ddl_Pago.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl_Pago[y].ID_TP_PAGO
                }).text(Mx_Ddl_Pago[y].TP_PAGO_DESC).appendTo("#Ddl_Pago");
            }
        };

        //Llenar DataTable
        function Fill_DataTable() {
            $("#divTable").empty();

            $("<table>", {
                "id": "DataTable",
                "class": "table table-hover table-striped table-iris",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#divTable");

            $("#DataTable").append(
                $("<thead>"),
                $("<tbody>")
            );

            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>").text("#"),
                    $("<th>").text("N° Atención"),
                    $("<th>").text("Fecha"),
                    $("<th>").text("Rut"),
                    $("<th>").text("Sexo"),
                    $("<th>").text("Fecha Nac."),
                    $("<th>").text("Edad"),
                    $("<th>").text("Nombre"),
                    $("<th>").text("Examen"),
                    $("<th>").text("Cod. Fonasa"),
                    $("<th>").text("Procedencia"),
                    $("<th>").text("Precio"),
                    $("<th>").text("Hora Ate."),
                    $("<th>").text("Previsión"),
                    $("<th>").text("Medico"),
                    $("<th>").text("Programa")

                )
            );

            for (i = 0; i < Mx_Dtt.length; ++i) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].ATE_NUM),
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

                            return String(dd + "/" + MM + "/" + yy);
                        }),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].PAC_RUT),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].SEXO_DESC),
                        //$("<td>", { "align": "left" }).text(Mx_Dtt[i].PAC_FNAC),
                        $("<td>", { "align": "center" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt[i].PAC_FNAC);
                            var dd = parseInt(obj_date.getDate());
                            var MM = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (MM < 10) { MM = "0" + MM; }
                            return String(dd + "/" + MM + "/" + yy);
                        }),

                        $("<td>", {
                            "align": "center",
                            "style": "white-space: nowrap;"
                        }).text(Mx_Dtt[i].ATE_AÑO + "A " + Mx_Dtt[i].ATE_MES + "M " + Mx_Dtt[i].ATE_DIA + "D"),
                        $("<td>", {
                            "align": "left",
                            "style": "white-space: nowrap;"
                        }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>", {
                            "align": "left",
                            "style": "white-space: nowrap;"
                        }).text(Mx_Dtt[i].CF_DESC),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].CF_COD),

                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].PROC_DESC),
                        $("<td>", { "align": "right" }).text("$ " + cFormat.numToString(Mx_Dtt[i].ATE_DET_V_PREVI, 0, ".", ",")),
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

                            if (hh < 10) { dd = "0" + dd; }
                            if (mm < 10) { MM = "0" + MM; }

                            return String(hh + ":" + mm);
                        }),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].PREVE_DESC),
                        $("<td>", {
                            "align": "left",
                            "style": "white-space: nowrap;"
                        }).text(Mx_Dtt[i].DOC_NOMBRE + " " + Mx_Dtt[i].DOC_APELLIDO),
                        $("<td>", {
                            "align": "left",
                            "style": "white-space: nowrap;"
                        }).text(Mx_Dtt[i].PROGRA_DESC)
                    )
                );
            }

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
            $("#div_hide").show();
        };
    </script>

    <style>
        table thead {
            background-color: #28a745;
            color: white;
        }

        .label_btn {
            margin: 0;
            margin-bottom: 1px;
        }

        .form-control {
            background: #ffffff !important;
        }

        th {
            height: 18px !important;
        }

        .dataTables_wrapper > .row:nth-child(2) > div {
            overflow: auto;
        }

        td {
            padding-left: 5px;
            padding-right: 5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <!--Modal Notificación-->
    <div id="mdlNotif" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title"></h4>
                </div>
                <div class="modal-body">
                    <p></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>


    <div class="card mb-3 border-bar">
        <div class="card-header bg-bar p-2">
            <h5>Valoralización por Lugar de TM</h5>
        </div>
        <div class="card-body">
            <div class="row">
                <!--DatePicker-->
                <div class="col-md-3">
                    <div class="form-group">
                        <label>Desde:</label>
                        <div class="input-group input-group-sm date" id="Txt_Date01">
                            <input type="text" class="form-control" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Hasta:</label>
                        <div class="input-group input-group-sm date" id="Txt_Date02">
                            <input type="text" class="form-control" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                </div>

                <!--Rango de Fechas-->
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="Txt_Edad01">Edad Desde:</label>
                        <input type="number" id="Txt_Edad01" class="form-control form-control-sm" min="0" max="150" value="0" />
                    </div>
                    <div class="form-group">
                        <label for="Txt_Edad02">Edad Hasta:</label>
                        <input type="number" id="Txt_Edad02" class="form-control form-control-sm" min="0" max="150" value="0" />
                    </div>
                </div>

                <!--Drop Down List-->
                <div class="col-md-3">
                    <div class="form-group">
                        <label for="Ddl_Prev">Previsión:</label>
                        <select class="form-control form-control-sm" id="Ddl_Prev">
                        </select>
                    </div>

                    <div class="form-group">
                        <label for="Ddl_Proc">Lugar TM:</label>
                        <select class="form-control form-control-sm" id="Ddl_Proc">
                        </select>
                    </div>
                </div>

                <!--Drop Down list & Botones-->
                <div class="col-md-4">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="form-group">
                                <label for="Ddl_Pago">Forma de Pago:</label>
                                <select class="form-control form-control-sm" id="Ddl_Pago">
                                </select>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <label class="label_btn">Opciones:</label>
                            <div class="row">
                                <div class="col-sm-6">
                                    <button type="button" id="Btn_Search" class="btn btn-block btn-buscar btn-sm">
                                        <i class="fa fa-search"></i>
                                        <span>Buscar</span>
                                    </button>
                                </div>
                                <div class="col-sm-6">
                                    <button type="button" id="Btn_Export" class="btn btn-block btn-success btn-sm">
                                        <i class="fa fa-file-excel-o"></i>
                                        <span>Excel</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="card mb-3 border-bar" id="div_hide">
        <div class="card-header bg-bar p-2">
            <h5>Tabla de Resultados</h5>
        </div>
        <div id="divTable" class="card-body">
        </div>
    </div>

</asp:Content>
