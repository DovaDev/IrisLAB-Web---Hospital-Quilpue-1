<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Lis_Dialisis.aspx.vb" Inherits="Presentacion.Lis_Dialisis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script>
        var det_r;
        var det_tm;
        var ID_ATE_RED;
        $(document).ready(function () {
            $("#Id_Conte").hide();
            Ajax_previ();
            $("#btn_det").click(fn => {
                Ajax_Redirect();
            });
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
            $(".block_wait").fadeOut(0);
            $("#Div_Tabla").empty();
            $("#Div_Tabla").show();
            //Registrar evento Click del Botón Buscar       
            $("#Btn_Buscar").click(function () {
                $("#Div_Tabla").empty();
                MX_Excel = [];
                Ajax_DataTable();
            });
            //Registrar evento Click del Botón Excel       
            $("#Btn_Excel").click(function () {
                Ajax_Excel();
            });
        });
    </script>
    <script>
        //------------------------------------------------ AJAX DDL previ -------------------------------------------|
        var Mx_Dtt_previ = [
    {
        "ID_PREVE": 0,
        "PREVE_DESC": 0,
        "PREVE_DIA": 0,
        "PREVE_DIA_ORD": 0
    }
        ];
        function Ajax_previ() {
            modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_Dialisis.aspx/IRIS_WEBF_BUSCA_PREVISON_DIALISIS",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_previ = json_receiver;
                        Fill_Ddl_previ();
                        Hide_Modal();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        //------------------------------------------------ AJAX DDL EXAMEN -------------------------------------------|
        var Mx_Exam = [
    {
        "ID_CODIGO_FONASA": 0,
        "CF_DESC": 0,
        "ID_ESTADO": 0
    }
        ];
        function Ajax_Exam() {
            modal_show();

            $.ajax({
                "type": "POST",
                "url": "Lis_Dialisis.aspx/Llenar_Ddl_Exam",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Exam = JSON.parse(json_receiver);
                        Fill_Ddl_Exam();
                        Hide_Modal();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }


        //-------------------------------------------------- AJAX PRUEBAS DIALISIS ----------------------------------------------|
        var Mx_Dtt_PRUE_DIA = [
            {   "ID_AÑO": 0,
                "ID_PREVE": 0,
                "ID_PRUEBA": 0,
                "AGRU_PRU_DESC": 0,
                "ANO_DESC": 0
            }
        ];
        function IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS() {
            modal_show();

            var Data_Par = JSON.stringify({
                //"DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PRE": $("#Ddl_previ").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Lis_Dialisis.aspx/IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_PRUE_DIA = json_receiver;
                        IRIS_WEBF_BUSCA_RESULTADO_DIALISIS();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                        $("#Id_Conte").hide();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        //-------------------------------------------------- AJAX TABLA MAIN ----------------------------------------------|
        var Mx_Dtt = [
            {
                "ID_ATENCION": 0,
                "ATE_NUM": 0,
                "ATE_FECHA": 0,
                "ID_PACIENTE": 0,
                "PREVE_DESC": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "PAC_RUT": 0,
                "ATE_AÑO": 0,
                "ATE_MES": 0,
                "ATE_DIA": 0,
                "ID_SEXO": 0,
                "SEXO_DESC": 0,
                "PROC_DESC": 0,
                "PAC_FNAC": 0
            }
        ];
        function Ajax_DataTable() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PRE": $("#Ddl_previ").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Lis_Dialisis.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt = json_receiver;
                        $("#Div_Tabla").empty();

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

                        IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS();                      

                        $("#Id_Conte").show();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                        $("#Id_Conte").hide();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        //-------------------------------------------------- AJAX RESULTADOS ----------------------------------------------|
        var Mx_Dtt_Resultados = [
            {
                "ID_ATENCION": 0,
                "ATE_RESULTADO": 0,
                "ATE_RESULTADO_NUM": 0,
                "ID_PRUEBA": 0,
                "ATE_EST_VALIDA": 0
            }
        ];
        function IRIS_WEBF_BUSCA_RESULTADO_DIALISIS() {
            modal_show();

            var Data_Par = JSON.stringify({
                "PACIENTES": Mx_Dtt,
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PRE": $("#Ddl_previ").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Lis_Dialisis.aspx/IRIS_WEBF_BUSCA_RESULTADO_DIALISIS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0 ) {
                        Mx_Dtt_Resultados = json_receiver;
                        $("#Div_Tabla").empty();
                        Fill_DataTable();
                        Hide_Modal();

                        $("#Id_Conte").show();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                        $("#Id_Conte").hide();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
//------------------------------------------------------------------------- EXCEL ---------------------------------------------------------------------
        var Mx_Dtt_Excel = [
    {
        "urls": ""
    }
        ];
        function Ajax_Excel() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PRE": $("#Ddl_previ").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Lis_Dialisis.aspx/Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        //Mx_Dtt_Excel = JSON.parse(json_receiver);
                        window.open(json_receiver, 'Download');
                        Hide_Modal();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                        $("#Id_Conte").hide();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>

    <%-- Funciones de Llenado de Elementos --%>
    <script>
        //Llenar DropDownList Lugar de TM
        function Fill_Ddl_previ() {
            $("#Ddl_previ").empty();
            for (y = 0; y < Mx_Dtt_previ.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_previ[y].ID_PREVE
                }).text(Mx_Dtt_previ[y].PREVE_DESC).appendTo("#Ddl_previ");
            }
        };
    </script>
    <script>
        //---------------------------------------------------- TABLA  ----------------------------------------------------------|
        function Fill_DataTable() {
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
                $("<tr>").attr("id", "head_pruebas").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Rut"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Lugar de TM")
                )
            );

            for (i = 0; i < Mx_Dtt_PRUE_DIA.length; i++) {
                $("<th>", { "id": Mx_Dtt_PRUE_DIA[i].ID_PRUEBA}, { "class": "textoReducido text-center" }).text(Mx_Dtt_PRUE_DIA[i].AGRU_PRU_DESC).appendTo("#head_pruebas");
            };
            //-------------------------------------------------------------------------------------------------------------------------------
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>").attr("id", "tr" + i).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>").css("text-align", "center").text(Mx_Dtt[i].ATE_NUM),
                        $("<td>").css("text-align", "center").text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>").css("text-align", "center").text(Mx_Dtt[i].PAC_RUT),
                        $("<td>").css("text-align", "center").text(Mx_Dtt[i].PROC_DESC)

                    )
                );
                for (ii = 0; ii < Mx_Dtt_PRUE_DIA.length; ii++) {
                    $("<td>", { "id": Mx_Dtt_PRUE_DIA[ii].ID_PRUEBA }, { "class": "textoReducido text-center" }).text(function () {
                        for (iii = 0; iii < Mx_Dtt_Resultados.length; iii++) {
                            if (Mx_Dtt_Resultados[iii].ID_ATENCION == Mx_Dtt[i].ID_ATENCION && Mx_Dtt_Resultados[iii].ID_PRUEBA == Mx_Dtt_PRUE_DIA[ii].ID_PRUEBA) {
                                $(this).text(Mx_Dtt_Resultados[iii].ATE_RESULTADO);
                            }
                        };
                    }).appendTo("#tr" + i);
                };
            };
        }
    </script>
    <style>
        .progress-bar.animate {
            width: 100%;            
        }
        #DataTable tbody td {
            text-transform: uppercase;
        }
        .mrgn {
            margin-left: 20px;
            margin-right: 20px;
        }
        #btnFichaAcceso {
            margin-bottom: 1vh;
        }
        #i {
            display: flex;
            flex-flow: row nowrap;
        }
        .manito {
            cursor: pointer;
        }
        .cabezera {
            background: #46963f;
            color: white;
        }
        .cabezera2 {
            background: #081f44;
            color: white;
        }
        .textoReducido {
            font-size: 12px;
        }
        .mayus {
            text-transform: uppercase;
        }
        .highlights {
            width: 90%;
            max-height: 60vh; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }
        .highlights2 {
            width: 710px;
            height: 404px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
        }
        @media screen and (max-width: 600px) {
            .flexon {
                display: flex;
                flex-flow: column;
                width: 90vw;
            }
            .flx {
                flex: 1;
                max-width: 100%;
            }
            
            .buttons {
                display: flex;
                flex-flow: column;
            }
            #Btn_Buscar_x_ate {
                width: 90vw;
                margin-left: -12px;
            }
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <%--//---------------------------------------------- MODAL LISTADO DE EXÁMENES DE LA ATENCIÓN ------------------------------------%>
    <div class="modal fade" id="eModal" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Listado Exámenes de la Atención</h4>
                </div>
                <div class="modal-header">
                    <div class="col">
                        <h6 class="modal-title" id="numerito"></h6>
                        <h6 class="modal-title" id="emodal_rut"></h6>
                        <h6 class="modal-title" id="nombrecito"></h6>
                    </div>
                    <div class="col">
                        <h6 class="modal-title" id="emodal_sexo"></h6>
                        <h6 class="modal-title" id="emodal_fecha"></h6>
                        <h6 class="modal-title" id="emodal_lugartm"></h6>
                    </div>
                </div>
                <div class="modal-body">
                    <form>
                        <div id="Div_Tabla_Listado_Exa_Ate" style="width: 100%;" class="table-responsive"></div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" id="btn_det">Detalles</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Salir</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal -->
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
    <%------------------------------------------------------TÍTULO, TEXTBOX Y BOTONES-----------------------------------------%>
    <div class="row">
        <div class="col-lg">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar">
        <h5 style="text-align: center; padding: 5px;">
            <i class="fa fa-edit"></i>
            Listado de Atenciones por Diálisis
        </h5>
    </div>
    <div class="row mb-3" style="margin-left:2px; margin-right: 2px;">
        <div class="col-md">
            <label for="fecha">Desde:</label>
            <div class='input-group date' id='Txt_Date01'>
                <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Desde..." />
                <span class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </span>
            </div>
        </div>
        <div class="col-md">
            <label for="fecha">Hasta:</label>
            <div class='input-group date' id='Txt_Date02'>
                <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Desde..." />
                <span class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </span>
            </div>
        </div>
        <div class="col-md">
            <label for="Ddl_previ">Previsión:</label>
            <select id="Ddl_previ" class="form-control">
                <option value="0">Seleccionar</option>
            </select>
        </div>
    </div>
   <div class="row" style="margin-left:2px; margin-right: 2px;">
        <div class="col-md">
            <button id="Btn_Buscar" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i> Buscar</button>
        </div>
        <div class="col-md">
            <button id="Btn_Excel" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i> Excel</button>
        </div>
    </div>

    <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
    <div class="row" id="Id_Conte">
        <div class="col" id="Paciente">
            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list"></i>Listado de Atenciones</h5>
            <div class="row">
                <div id="Div_Tabla" class="highlights col-md"></div>
            </div>
        </div>
    </div>
    </div>
    </div>
    </div>
</asp:Content>