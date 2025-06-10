<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Deri_Lis.aspx.vb" Inherits="Presentacion.Deri_Lis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
<%--      <link href="css/bootstrap.min.css" rel="stylesheet" />--%>


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

<script>
        var modal_activador = 0;
        var N_lotex = 0;
        
        $(document).ready(function () {
            //$("#Id_Conte").hide();
            Ajax_Ddl_Derivados();
            Hide_Modal();
            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input").val(dateNow);
            $("#Txt_Date02 input").val(dateNow);

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
            
            $("#Btn_Buscar").click(function () {
                Ajax_DataTable();
            });

            $("#Btn_Izquierdaa").click(function () {
                N_lotex = N_lotex - 1;
                    
                    Ajax_DataTable_Click(N_lotex);
                
            });

            $("#Btn_Derechaa").click(function () {
                N_lotex = N_lotex + 1;
                    
                    Ajax_DataTable_Click(N_lotex);
                
            });

            $("#Btn_Activador").click(function () {
                modal_activador = 0;
                $("#eModalHOLA").modal('hide');
            });
            
            $("#Btn_Excel").click(function () {
                Ajax_Excel();
            });

            $("#Btn_Excel_Clickk").click(function () {
                console.log("boton excel click");
                Ajax_Excel_Click(N_lotex);
            });
            
        });

    </script>

    <!-- Funciones AJAX -->
    <script>
        //-------------------------------------------------- DDL DERIVADOS----------------------------------------------------|
        var Mx_Ddl_Derivados = [
            {
                "ID_DERIVADO": 0,
                "DERI_DESC": 0,
                "ID_ESTADO": 0,
                "DERI_COD": 0
            }
        ];

        function Ajax_Ddl_Derivados() {

            $.ajax({
                "type": "POST",
                "url": "Deri_Lis.aspx/IRIS_WEBF_BUSCA_DERIVADOS",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_Derivados = JSON.parse(json_receiver);
                        Fill_Ddl_Derivados();

                    } else {

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

        //---------------------------------------------------------- DATA TABLE -------------------------------------------|

        var Mx_Dtt = [
    {
        "ID_DERIV_PRO": 0,
        "DERIV_NUM": 0,
        "DERIV_PRO_FECHA": 0,
        "ID_USUARIO": 0,
        "ID_ESTADO": 0,
        "ID_DERIVADO": 0,
        "DERI_DESC": 0,
        "USU_NOMBRE": 0,
        "USU_APELLIDO": 0
    }
        ];

        function Ajax_DataTable() {
            modal_show();

            var Data_Par = JSON.stringify({
                "NUM": $("#Ddl_Derivados").val(),
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Deri_Lis.aspx/IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt = JSON.parse(json_receiver);

                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].DERIV_PRO_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].DERIV_PRO_FECHA = Date_Change;
                        }

                        Hide_Modal();
                        $("#DataTableAJA").empty();
                        $("#Id_Conte").show();
                        Fill_DataTableAJA();


                    } else {

                        Hide_Modal();
                        $("#DataTableAJA").empty();
                        $("#mError_AAH h4").text("Sin Resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados.");
                        $("#mError_AAH").modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    //alert(str_Error);
                    Hide_Modal();
                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Se ha producido un error: " + str_Error);
                    $("#mError_AAH").modal();


                }
            });
        }


        //---------------------------------------------------------- DATA TABLE CLICK -------------------------------------------|

        var Mx_Dtt_Click = [
        {
        "DERIV_NUM": 0,
        "ATE_FECHA": 0,
        "CF_DESC": 0,
        "ID_PACIENTE": 0,
        "PAC_NOMBRE": 0,
        "PAC_APELLIDO": 0,
        "PAC_RUT": 0,
        "PAC_FNAC": 0,
        "SEXO_COD": 0,
        "DOC_NOMBRE": 0,
        "DOC_APELLIDO": 0,
        "ORD_DESC": 0,
        "ATE_NUM": 0,
        "ID_DET_DERIV_PRO": 0,
        "DERI_DESC": 0,
        "DERIV_PRO_FECHA": 0,
        "ATE_OBS_FICHA": 0,
        "ATE_NUM_INTERNO": 0,
        "PROC_DESC": 0
        }
        ];


        function Ajax_DataTable_Click(NUM) {
           modal_show();
            
            var Data_Par = JSON.stringify({
                "NUM": NUM
            });

            $.ajax({
                "type": "POST",
                "url": "Deri_Lis.aspx/IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Click = JSON.parse(json_receiver);

                        for (i = 0; i < Mx_Dtt_Click.length; ++i) {
                            var date_x = Mx_Dtt_Click[i].PAC_FNAC;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Click[i].PAC_FNAC = Date_Change;
                        }

                        for (i = 0; i < Mx_Dtt_Click.length; ++i) {
                            var date_x = Mx_Dtt_Click[i].DERIV_PRO_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Click[i].DERIV_PRO_FECHA = Date_Change;
                        }

                        $("#txtFechaDerivador").text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Click[0].DERIV_PRO_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return dd + "/" + mm + "/" + yy;
                        });

                        N_lotex = Mx_Dtt_Click[0].DERIV_NUM;
                        $("#txtNLote").val(N_lotex);
                        $("#DataTable_ClickAJA").empty();
                        //$("#Div_Dtt").empty();
                        
                        $("#txtLabDerivador").text(Mx_Dtt_Click[0].DERI_DESC);
                        $("#txtUsuDerivador").text(Mx_Dtt_Click[0].DOC_NOMBRE + " " + Mx_Dtt_Click[0].DOC_APELLIDO);

                        //$("#eModalHOLA").modal('hide');
                        $("#eModalHOLA").modal();



                        
                        Fill_DataTable_ClickAJA();
                                       
                       Hide_Modal();
                       //$("#eModalHOLA").modal('show');

                    }else{
                        //modal_activador = 0;
                        //$("#eModalHOLA").modal('hide')

                        Hide_Modal();
                        $("#txtNLote").val(N_lotex);
                        $("#txtLabDerivador").text("");
                        $("#txtUsuDerivador").text("");
                        $("#txtFechaDerivador").text("");
                        $("#DataTable_ClickAJA").empty();
                        $("#mError_AAH h4").text("Sin Resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados.");
                        $("#mError_AAH").modal();
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    //alert(str_Error);
                    //Hide_Modal();
                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Se ha producido un error: " + str_Error);
                    $("#mError_AAH").modal();


                }
            });
        }

        var Mx_Dtt_Excel = [
{
    "urls": ""
}
        ];

        function Ajax_Excel() {
            modal_show();


            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "NUM": $("#Ddl_Derivados").val(),
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Deri_Lis.aspx/Excel",
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

        var Mx_Dtt_Excel_Click = [
{
    "urls": ""
}
        ];

        function Ajax_Excel_Click(NUM) {
            modal_show();


            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "NUM": NUM
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Deri_Lis.aspx/Excel_Click",
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

    <!-- Funciones de llenado -->
    <script>
        //Llenar DropDownList Derivados
        function Fill_Ddl_Derivados() {
            $("#Ddl_Derivados").empty();
            $("<option>", { "value": 0 }).text("TODOS").appendTo("#Ddl_Derivados");
            for (i = 0; i < Mx_Ddl_Derivados.length; ++i) {
                $("<option>", { "value": Mx_Ddl_Derivados[i].ID_DERIVADO }).text(Mx_Ddl_Derivados[i].DERI_DESC).appendTo("#Ddl_Derivados");
            }
        };

        //-----------------------------------------TABLA LISTADO DE EXAMENES de la ATENCIONES-------------------------------------------|
        function Fill_DataTableAJA() {
            $("<table>", {
                "id": "DataTableAJA",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla");

            $("#DataTableAJA").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTableAJA").attr("class", "table table-hover table-striped table-iris");
            $("#DataTableAJA thead").attr("class", "cabzera");
            $("#DataTableAJA thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("N°"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre del Laboratorio"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre del Usuario"),
                    $("<th>", { "class": "textoReducido" }).text("fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Hora")

                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTableAJA tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_DataTable_Click("` + Mx_Dtt[i].DERIV_NUM + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DERIV_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DERI_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].USU_NOMBRE + " " + Mx_Dtt[i].USU_APELLIDO),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt[i].DERIV_PRO_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date2 = new Date(Mx_Dtt[i].DERIV_PRO_FECHA);
                            var hh = parseInt(obj_date2.getHours());
                            var mm = parseInt(obj_date2.getMinutes());
                            var ss = parseInt(obj_date2.getSeconds());

                            if (hh < 10) { hh = "0" + hh; }
                            if (mm < 10) { mm = "0" + mm; }
                            if (ss < 10) { ss = "0" + ss; }

                            return String(hh + ":" + mm + ":" + ss);
                        })
                    )
                );
            }
        }

        //-----------------------------------------TABLA CLICK-------------------------------------------|
        function Fill_DataTable_ClickAJA() {
            $("<table>", {
                "id": "DataTable_ClickAJA",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#DataTable_ClickAJAAJA");

            $("#DataTable_ClickAJA").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_ClickAJA").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_ClickAJA thead").attr("class", "cabzera");
            $("#DataTable_ClickAJA thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Exámenes"),
                    $("<th>", { "class": "textoReducido" }).text("Orden"),
                    $("<th>", { "class": "textoReducido" }).text("Médico"),
                    $("<th>", { "class": "textoReducido" }).text("Sexo"),
                    $("<th>", { "class": "textoReducido" }).text("F. Nac")

                )
            );

            for (i = 0; i < Mx_Dtt_Click.length; i++) {
                $("#DataTable_ClickAJA tbody").append(
                    $("<tr>", {
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Click[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Click[i].ATE_FECHA),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Click[i].PAC_NOMBRE + " " + Mx_Dtt_Click[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Click[i].CF_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Click[i].ORD_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Click[i].DOC_NOMBRE + " " + Mx_Dtt_Click[i].DOC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Click[i].SEXO_COD),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Click[i].PAC_FNAC);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);
                        })
                    )
                );
            }
        }


    </script>
    <style>
        .progress-bar.animate {
            width: 100%;
        }

        #DataTable tbody td {
            text-transform: uppercase;
        }

        #DataTable_Ate tbody td {
            text-transform: uppercase;
        }

        #DataTable_Lis_Exa_Ate tbody td {
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

        .cabzera {
            background: #46963f;
            color: white;
        }

        .textoReducido {
            font-size: 12px;
        }

        .highlights {
            width: 710px;
            height: 60vh; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .highlights2 {
            width: 710px;
            height: 60vh; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
        }

        @media screen and (max-width: 600px) {
            #Paciente {
                margin-bottom: 1rem;
            }

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
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <%--//---------------------------------------------- MODAL LISTADO DE EXÁMENES DE LA ATENCIÓN ------------------------------------%>
    <div class="modal fade" id="eModalHOLA" tabindex="-1" role="dialog" aria-labelledby="eModalHOLALabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Listado Exámenes de la Atención</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-2">
                            <label>N° Lote</label>
                        </div>
                        <div class="col-lg-3">
                            <input type='text' id="txtNLote" class="form-control" readonly="true"/>
                        </div>
                        <div class="col-lg-1">
                            <button id="Btn_Izquierdaa" type="button" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px; width: 30px;"><i class="fa fa-fw fa-arrow-left mr-2"></i></button>
                        </div>
                        <div class="col-lg-1">
                            <button id="Btn_Derechaa" type="button" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px; width: 30px;"><i class="fa fa-fw fa-arrow-right mr-2"></i></button>
                        </div>
                        <div class="col-lg-3">
                        </div>
                        <div class="col-lg-2">
                            <button id="Btn_Excel_Clickk" class="btn btn-success mt-2" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="col">
                                <label>Laboratorio Derivador: </label>
                                <label id="txtLabDerivador"></label>
                            </div>
                            <div class="col"></div>
                            <div class="col">
                                <label>Usuario: </label>
                                <label id="txtUsuDerivador"></label>
                            </div>
                            <div class="col">
                                <label>Fecha: </label>
                                <label id="txtFechaDerivador"></label>
                            </div>
                        </div>
                    </div> 
                    <div>              
                        <form>
                            <div id="DataTable_ClickAJAAJA" style="width: 100%;" class="table-responsive"></div>
                        </form>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="Btn_Activador" type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Salir</button>
                    <%--<button type="button" id="btnguardar" class="btn btn-success">Guardar</button>--%>
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
            <i class="fa fa-search"></i>
            Búsqueda de Listados de Derivación
        </h5>
    </div>
    <div class="row">
        <div class="col-lg">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-7">
                    <div class="row">
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
                            <label for="fecha2">Hasta:</label>
                            <div class='input-group date' id='Txt_Date02'>
                                <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Hasta..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md">
                            <label for="Ddl_Derivados">Laboratorio de Derivación:</label>
                            <select id="Ddl_Derivados" class="form-control">
                            </select>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="row">
                        <div class="col-md text-center">
                            <br />
                            <button type="button" id="Btn_Buscar" class="btn btn-buscar mt-2"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                        </div>
                        <div class="col-md text-center">
                            <br />
                            <button id="Btn_Excel" class="btn btn-success mt-2" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                        </div>
                    </div>
                </div>
                <div class="col-lg-1"></div>
            </div>
        </div>
    </div>




    <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
    <div class="row" id="Id_Conte">
        <div class="col-lg-1"></div>
        <div class="col-lg-10" id="Paciente">

            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list"></i>Listado de Atenciones</h5>
            <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>

        </div>
        <div class="col-lg-1"></div>
    </div>
            </div>
            </div>
        </div>
</asp:Content>
