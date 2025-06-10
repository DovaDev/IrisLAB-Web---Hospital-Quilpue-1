<%@ Page Title="Listado de atenciones por Previsión" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="List_Ate_Prev_and_Prog_Ag_M.aspx.vb" Inherits="Presentacion.List_Ate_Prev_and_Prog_Ag_M" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <!--No guardar caché de la página-->
    <%@ OutputCache Location="None" NoStore="true" %>
    <!--Custom JS-->
    <script src="/js/Deep-Copy.js"></script>
    <script src="/js/Custom_Objects.js"></script>
    <script src="/js/IrisLabResourses.js"></script>
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
        }
    </script>
    <!--Rutina de inicialización-->
    <script>
        $(document).ready(function () {
            $("#div_hide").hide();
            //Datepickers
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
            $("#Btn_Group").click(function () {
                var group = parseInt($("#Btn_Group").attr("data-switch"));
                var dTable = $("#divTable table");

                switch (group) {
                    case 0:
                        if (dTable.length > 0) {
                            Fill_DataTable(Mx_Dtt_Grp);
                        }
                        $("#Btn_Group i").attr("class", "fa fa-object-ungroup");
                        $("#Btn_Group span").text("Desagrupar");
                        $("#Btn_Group").attr("data-switch", 1);
                        break;
                    default:
                        if (dTable.length > 0) {
                            Fill_DataTable(Mx_Dtt);
                        }
                        $("#Btn_Group i").attr("class", "fa fa-object-group");
                        $("#Btn_Group span").text("Agrupar");
                        $("#Btn_Group").attr("data-switch", 0);
                }
            });
            $("#Btn_Search").click(function () {
                AJAX_DataTable();
            });
            $("#Btn_Export").click(function () {
                Ajax_Excel();
            });
            $("#Ddl_Prev").change(function () {
                AJAX_Ddl_Prog_Alt();
            });
            //Llamar Funciones
            modal_show();
            AJAX_Ddl_Prev();
            AJAX_Ddl_Prog();
        });
    </script>
    <!--Declaraciones AJAX-->
    <script>
        //JSON del DropDownList de Previsiones
        var MxDdl_Prev = [
            {
                "ID_PREVE": "",
                "PREVE_COD": "",
                "PREVE_DESC": "",
                "ID_ESTADO": ""
            }
        ];
        function AJAX_Ddl_Prev() {


            $.ajax({
                "type": "POST",
                "url": "List_Ate_Prev_and_Prog_Ag_M.aspx/Llenar_Ddl_Prev",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    MxDdl_Prev = response.d;
                    Fill_Ddl_Prev();
                },
                "error": function (response) {
                    Hide_Modal();
                    $("#mdlNotif .modal-header h4").text(String(response.responseJSON.ExceptionType).trim());
                    $("#mdlNotif .modal-body p").html(response.responseJSON.Message);
                    $("#mdlNotif").modal();

                }
            });
        }
        //JSON del DropDownList de Programa
        var MxDdl_Prog = [
            {
                "ID_PROGRA": "",
                "PROGRA_COD": "",
                "PROGRA_DESC": "",
                "ID_ESTADO": ""
            }
        ];
        function AJAX_Ddl_Prog() {


            $.ajax({
                "type": "POST",
                "url": "List_Ate_Prev_and_Prog_Ag_M.aspx/Llenar_Ddl_Prog",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    MxDdl_Prog = response.d;
                    Fill_Ddl_Prog();
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
        function AJAX_Ddl_Prog_Alt() {


            var Data_Par = JSON.stringify({
                "ID_PREV": $("#DdlPrevision").val(),
            });
            $.ajax({
                "type": "POST",
                "url": "List_Ate_Prev_and_Prog_Ag_M.aspx/Llenar_Ddl_Prog_Alt",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    MxDdl_Prog = response.d;
                    Fill_Ddl_Prog();
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
                "TOTAL_ATE": "",
                "TOTAL_PREVE": "",
                "TOT_FONASA": "",
                "TOTA_SIS": "",
                "TOTA_USU": "",
                "TOTA_COPA": "",
                "CF_DESC": "",
                "ID_CODIGO_FONASA": "",
                "ID_ESTADO": "",
                "CF_COD": "",
                "ID_PROGRA": "",
                "PROGRA_DESC": "",
                "Data_Fonasa": {
                    "CF_COD": "",
                    "CF_DESC": "",
                    "CF_PRECIO_AMB": "",
                    "CF_SEL_PRUE": "",
                    "CF_NO_FONASA": "",
                    "CF_PRECIO_HOS": "",
                    "AÑO_COD": "",
                    "CF_DIAS": "",
                    "ID_PER": "",
                    "ID_PREVE": "",
                    "ID_ESTADO": "",
                    "ID_CF_PRECIO": "",
                    "ID_CODIGO_FONASA": ""
                },
                "Data_Proced": [{
                    "PROC_DESC": "",
                    "PREVE_DESC": "",
                    "ID_PREVE": "",
                    "ID_PROCEDENCIA": "",
                    "TOTAL_ATE": "",
                    "TOTAL_PREVE": "",
                    "TOT_FONASA": "",
                    "TOTA_SIS": "",
                    "TOTA_USU": "",
                    "TOTA_COPA": ""
                }]
            }
        ];
        var Mx_Dtt_Grp = [
            {
                "TOTAL_ATE": "",
                "TOTAL_PREVE": "",
                "TOT_FONASA": "",
                "TOTA_SIS": "",
                "TOTA_USU": "",
                "TOTA_COPA": "",
                "CF_DESC": "",
                "ID_CODIGO_FONASA": "",
                "ID_ESTADO": "",
                "CF_COD": "",
                "ID_PROGRA": "",
                "PROGRA_DESC": "",
                "Data_Fonasa": {
                    "CF_COD": "",
                    "CF_DESC": "",
                    "CF_PRECIO_AMB": "",
                    "CF_SEL_PRUE": "",
                    "CF_NO_FONASA": "",
                    "CF_PRECIO_HOS": "",
                    "AÑO_COD": "",
                    "CF_DIAS": "",
                    "ID_PER": "",
                    "ID_PREVE": "",
                    "ID_ESTADO": "",
                    "ID_CF_PRECIO": "",
                    "ID_CODIGO_FONASA": ""
                },
                "Data_Proced": [{
                    "PROC_DESC": "",
                    "PREVE_DESC": "",
                    "ID_PREVE": "",
                    "ID_PROCEDENCIA": "",
                    "TOTAL_ATE": "",
                    "TOTAL_PREVE": "",
                    "TOT_FONASA": "",
                    "TOTA_SIS": "",
                    "TOTA_USU": "",
                    "TOTA_COPA": ""
                }]
            }
        ];
        function AJAX_DataTable() {

            $("#divTable").empty();
            var Data_Par = JSON.stringify({
                "ID_PREV": $("#Ddl_Prev").val(),
                "ID_PROG": $("#Ddl_Prog").val(),
                "DATE_str01": $("#Txt_Date01 input").val(),
                "DATE_str02": $("#Txt_Date02 input").val()
            });
            modal_show();
            $.ajax({
                "type": "POST",
                "url": "List_Ate_Prev_and_Prog_Ag_M.aspx/Llenar_DataTable",
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
                        Group_JSON();
                        var gSwitch = parseInt($("#Btn_Group").attr("data-switch"));
                        if (Mx_Dtt.length > 0 || Mx_Dtt_Grp.length > 0) {
                            switch (gSwitch) {
                                case 0:
                                    Fill_DataTable(Mx_Dtt);
                                    break;
                                default:
                                    Fill_DataTable(Mx_Dtt_Grp);
                                    break;
                            }
                        }
                        else {
                            $("#divTable").append(
                                $("<h5>", { "class": "text-center m-3" }).text("No se encontraron resultados.")
                                );
                        }

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
        function Ajax_Excel() {


            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "GROUP": parseInt($("#Btn_Group").attr("data-switch")),
                "ID_PREV": $("#Ddl_Prev").val(),
                "ID_PROG": $("#Ddl_Prog").val(),
                "DATE_str01": String($("#Txt_Date01 input").val()),
                "DATE_str02": String($("#Txt_Date02 input").val())
            });
            modal_show();
            $.ajax({
                "type": "POST",
                "url": "List_Ate_Prev_and_Prog_Ag_M.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        var str_Download = "La Planilla Excel se ha generado correctamente, puede descargarla haciendo click ";
                        str_Download += "<a href='" + json_receiver + "'>AQUÍ.</a>"
                        $("#mdlNotif .modal-header h4").text("Archivo Generado");
                        $("#mdlNotif .modal-body p").html(str_Download);
                        $("#mdlNotif").modal();

                    } else {
                        var str_Error = "La petición de generación de planilla Excel no se ha realizado debido ";
                        str_Error += "a que los parámetros de búsqueda no arrojaron resultados."
                        $("#mdlNotif .modal-header h4").text("Error");
                        $("#mdlNotif .modal-body p").html(str_Download);
                        $("#mdlNotif").modal();

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
    </script>
    <!--Funciones de Llenado-->
    <script>
        function Fill_Ddl_Prev() {
            $("#Ddl_Prev").empty();
            //$("<option>", {
            //    "value": 0
            //}).text("Todos").appendTo("#Ddl_Prev");
            for (y = 0; y < MxDdl_Prev.length; ++y) {
                $("<option>", {
                    "value": MxDdl_Prev[y].ID_PREVE
                }).text(MxDdl_Prev[y].PREVE_DESC).appendTo("#Ddl_Prev");
            }
        }
        function Fill_Ddl_Prog() {
            $("#Ddl_Prog").empty();
            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#Ddl_Prog");
            for (y = 0; y < MxDdl_Prog.length; ++y) {
                $("<option>", {
                    "value": MxDdl_Prog[y].ID_PROGRA
                }).text(MxDdl_Prog[y].PROGRA_DESC).appendTo("#Ddl_Prog");
            }
        }

        //Llenar DataTable
        function Fill_DataTable(JSON_AAA) {
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
                    $("<th>", { "class": "text-center" }).text("N°"),
                    $("<th>", { "class": "text-center" }).text("Código"),
                    $("<th>").text("Exámen"),
                    $("<th>", { "class": "text-center" }).text("Cant. Exámenes"),
                    $("<th>").text("Precio"),
                    $("<th>").text("Programa")
                )
            );
            for (i = 0; i < JSON_AAA[0].Data_Proced.length; ++i) {
                $("<th>").text(JSON_AAA[0].Data_Proced[i].PROC_DESC).appendTo("#DataTable thead tr");
            }
            for (i = 0; i < JSON_AAA.length; ++i) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>", { "align": "center" }).text(JSON_AAA[i].CF_COD),
                        $("<td>").text(JSON_AAA[i].CF_DESC),
                        $("<td>", { "align": "center" }).text(cFormat.numToString(JSON_AAA[i].TOTAL_ATE, 0, ".", ",")),
                        $("<td>").text(function () {
                            var value = JSON_AAA[i].Data_Fonasa.CF_PRECIO_AMB;
                            return "$ " + cFormat.numToString(value, 0, ".", ",");
                        }()),
                        $("<td>").text($("#DdlPrograma option:selected").text())
                    )
                );
                for (ii = 0; ii < JSON_AAA[i].Data_Proced.length; ++ii) {
                    $("#DataTable tbody tr").eq(i).append(
                        $("<td>", { "align": "right" }).text(cFormat.numToString(JSON_AAA[i].Data_Proced[ii].TOTAL_ATE, 0, ".", ","))
                    );
                }
            }
            $("#DataTable").DataTable({
                "bSort": false,
                "iDisplayLength": 100,
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
            //llenar Totales
            $("#divTotal").empty().css({ "background": "#ffffff" });
            $("<table>", {
                "id": "DataTableTotal",
                "class": "table table-hover table-striped table-iris",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#divTotal");
            $("#DataTableTotal").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTableTotal thead").append(
                $("<tr>").append(
                    $("<th>").text("Cant. Exámenes"),
                    $("<th>").text("Precio Total")
                )
            );
            for (i = 0; i < JSON_AAA[0].Data_Proced.length; ++i) {
                $("<th>").text(JSON_AAA[0].Data_Proced[i].PROC_DESC).appendTo("#DataTableTotal thead tr");
            }
            var T_ATE = 0;
            var T_PRECIO = 0;
            var T_PROC = [];
            for (ii = 0; ii < JSON_AAA[0].Data_Proced.length; ++ii) {
                T_PROC.push(0);
            }
            for (i = 0; i < JSON_AAA.length; i++) {
                T_ATE = parseFloat(T_ATE) + parseFloat(JSON_AAA[i].TOTAL_ATE);
                T_PRECIO = parseFloat(T_PRECIO) + parseFloat(JSON_AAA[i].Data_Fonasa.CF_PRECIO_AMB);
                for (ii = 0; ii < JSON_AAA[i].Data_Proced.length; ++ii) {
                    T_PROC[ii] += parseFloat(JSON_AAA[i].Data_Proced[ii].TOTAL_ATE);
                }
            }
            $("#DataTableTotal tbody").append(
                $("<tr>").append(
                    $("<td>").text(cFormat.numToString(T_ATE, 0, ".", ",")),
                    $("<td>").text("$ " + cFormat.numToString(T_PRECIO, 0, ".", ","))
                )
            );
            for (ii = 0; ii < T_PROC.length; ++ii) {
                $("#DataTableTotal tbody tr").append(
                    $("<td>", { "align": "right" }).text(cFormat.numToString(T_PROC[ii], 0, ".", ","))
                );
            }
            $("#div_hide").show();
        };
        function Group_JSON() {


            var Mx_COD = [];
            Mx_Dtt_Grp.length = 0;
            //Crear Matrix con todos los Códigos sin repetirse
            for (y = 0; y < Mx_Dtt.length; ++y) {
                var COD_new = String(Mx_Dtt[y].CF_COD);
                if ((y == 0) || ((y > 0) && (COD_new != Mx_COD[Mx_COD.length - 1]))) {
                    var existe = false;
                    for (i = 0; i < Mx_COD.length; ++i) {
                        if (COD_new == Mx_COD[i]) {
                            existe = true;
                            break;
                        }
                    }
                    if (existe == false) {
                        Mx_COD.push(COD_new);
                    }
                }
            }
            //recorrer Array de Códigos
            for (y = 0; y < Mx_COD.length; ++y) {
                for (yy = 0; yy < Mx_Dtt.length; ++yy) {
                    //Declaraciones de evaluación
                    var Curr_CODF = String(Mx_COD[y]);
                    var Container = fnClone(Mx_Dtt[yy]);
                    //Buscar Coincidencia
                    if (Container.CF_COD == Curr_CODF) {
                        var Pos = Mx_Dtt_Grp.length - 1;
                        //Cambiar Descripción
                        Container.CF_DESC = (function () {
                            var AAA = Container.CF_DESC;
                            switch (Container.CF_COD) {
                                case "0302063":
                                    return "Transaminas GOT y/o GPT";
                                    break;
                                case "0302032":
                                    return "Electrolitos Plasmaticos";
                                    break;
                                case "0302023":
                                    return "Creatinina en Sangre";
                                    break;
                                case "0309022":
                                    return "Orina Completa";
                                    break;
                                case "0302060":
                                    return "Albumina y/o Proteinas Totales en Sangre";
                                    break;
                                case "0302035":
                                    return "Niveles Plasmaticos";
                                    break;
                                default:
                                    return AAA;
                                    break;
                            }
                        }());
                        if (Pos < 0) {
                            Mx_Dtt_Grp.push(Container);
                            continue;
                        }
                        if (Container.CF_COD != Mx_Dtt_Grp[Pos].CF_COD) {
                            //Cuando no existe otro ejemplar...
                            Mx_Dtt_Grp.push(Container);
                        } else {
                            //Cuando sí existe otro ejemplar...
                            Mx_Dtt_Grp[Pos].CF_COD = Container.CF_COD;
                            Mx_Dtt_Grp[Pos].TOTAL_ATE += Container.TOTAL_ATE;
                            //Mx_Dtt_Grp[Pos].Data_Fonasa.CF_PRECIO_AMB += Container.Data_Fonasa.CF_PRECIO_AMB;
                            if (Mx_Dtt_Grp[Pos].Data_Proced != null) {
                                for (i = 0; i < Mx_Dtt_Grp[Pos].Data_Proced.length; ++i) {
                                    Mx_Dtt_Grp[Pos].Data_Proced[i].TOTAL_ATE += Container.Data_Proced[i].TOTAL_ATE;
                                }
                            }
                        }
                    }
                }
            }


        }
    </script>
    <style>
        /*.dataTable th {
            background: #46963f;
            color: white;
        }
        .dataTable td {
            font-size: 14px;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="card border-bar mb-3">
        <div class="card-header bg-bar p-2" >
            <h5>Atenciones por Previsiones y Programa</h5>
        </div>
        <div class="card-body  p-3">
        <div class="row">
            <div class="col-sm">
                <div class="row">
                    <div class="col-md">
                        <label for="inputTxt_Date_01">Desde:</label>
                        <div class="input-group date" id="Txt_Date01">
                            <input type="text" class="form-control form-control-sm" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-md">
                        <label for="inputTxt_Date_02">Hasta:</label>
                        <div class="input-group date" id="Txt_Date02">
                            <input type="text" class="form-control form-control-sm" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm">
                <div class="row">
                    <div class="col-md">
                        <label for="Ddl_Prev">Previsión:</label>
                        <select class="form-control form-control-sm" id="Ddl_Prev">
                        </select>
                    </div>
                    <div class="col-md">
                        <label for="Ddl_Prog">Programa:</label>
                        <select class="form-control form-control-sm" id="Ddl_Prog">
                        </select>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <button type="button" id="Btn_Search" class="btn btn-block btn-buscar">
                    <i class="fa fa-search"></i>
                    <span>Buscar</span>
                </button>
            </div>
            <div class="col-sm-4">
                <button type="button" id="Btn_Group" class="btn btn-block btn-secondary" data-switch="0">
                    <i class="fa fa-object-group"></i>
                    <span>Agrupar</span>
                </button>
            </div>
            <div class="col-sm-4">
                <button type="button" id="Btn_Export" class="btn btn-block btn-success">
                    <i class="fa fa-file-excel-o"></i>
                    <span>Excel</span>
                </button>
            </div>
        </div>
    </div>
    </div>
    
    <div id="div_hide" style="overflow:auto">
        <div id="divTable" class="card p-2 mb-1 border-bar">
        </div>
        <div id="divTotal" class="card p-3 border-bar">
        </div>
    </div>

</asp:Content>
