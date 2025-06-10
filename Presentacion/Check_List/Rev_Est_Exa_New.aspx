<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Rev_Est_Exa_New_New.aspx.vb" Inherits="Presentacion.Rev_Est_Exa_New" %>

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
            Ajax_Exam();
            Call_AJAX_Ddl();
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
            $("#Id_Conte").hide();
            //Registrar evento Click del Botón Buscar       
            $("#Btn_Buscar").click(function () {
                $("#Div_Tabla").empty();
                Ajax_DataTable();
            });
            //Registrar evento Click del Botón Excel       
            $("#Btn_Excel").click(function () {
                Ajax_Excel();
            });
            
        });
    </script>
    <script>

        var Mx_Ddl = [
    {
        "ID_PROCEDENCIA": "",
        "PROC_COD": "",
        "PROC_DESC": "",
        "ID_ESTADO": ""
    }
        ];
        function Call_AJAX_Ddl() {



            $.ajax({
                "type": "POST",
                "url": "Rev_Est_Exa_New.aspx/Llenar_Ddl_LugarTM",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl = JSON.parse(json_receiver);
                        Fill_AJAX_Ddl();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    alert("Error", str_Error);


                }
            });
        }
        function Fill_AJAX_Ddl() {
            $("#Procedencia").empty();
            $("<option>",
                    {
                        "value": 0
                    }
                ).text("Todas").appendTo("#Procedencia");

            Mx_Ddl.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_PROCEDENCIA
                    }
                ).text(aaa.PROC_DESC).appendTo("#Procedencia");
            });
        }
        //------------------------------------------------ AJAX DDL previ -------------------------------------------|
        var Mx_Dtt_previ = [
    {
        "ID_ESTADO": 0,
        "PREVE_DESC": 0,
        "PREVE_COD": 0,
        "ID_PREVE": 0
    }
        ];
        function Ajax_previ() {
            modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rev_Est_Exa_New.aspx/Llenar_DdL_prevision",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_previ = JSON.parse(json_receiver);
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

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rev_Est_Exa_New.aspx/Llenar_Ddl_Exam",
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
                "ATE_NUM": 0,
                "ATE_FECHA": 0,
                "PAC_RUT": 0,
                "PAC_DNI": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "PAC_SEXO": 0,
                "PAC_EDAD": 0,
                "PROC_DESC": 0,
                "PAC_FONO": 0,
                "PAC_MOVIL": 0,
                "PAC_DIR": 0,
                "CF_DESC": 0,
                "EST_VALIDA": 0,
                "FECHA_VALIDA": 0
            }
        ];
        function Ajax_DataTable() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PROC": $("#Procedencia").val(),
                "ID_PRE": $("#Ddl_previ").val(),
                "ID_CF": $("#Ddl_Exam").val(),
                "ID_EST": $("#Ddl_Estado").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rev_Est_Exa_New.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    Mx_Dtt = response.d;
                    if (Mx_Dtt.length > 0) {
                        
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
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        //-----------------------------------------------DETALLE ATENCION---------------------------------------|
        var Mx_Dtt_Det_Ate = [
  {
      "ID_DET_ATE": 0,
      "CF_DESC": 0,
      "ID_CODIGO_FONASA": 0,
      "USU_NIC": 0,
      "ID_ATENCION": 0,
      "ID_ESTADO": 0,
      "CF_COD": 0,
      "ATE_FECHA": 0,
      "ATE_DET_V_ID_USU": 0,
      "ATE_DET_V_ID_ESTADO": 0,
      "ATE_DET_V_FECHA": 0,
      "ID_PER": 0,
      "ATE_DET_IMPRIME": 0,
      "ID_TP_PAGO": 0,
      "TP_PAGO_DESC": 0,
      "PAC_NOMBRE": 0,
      "PAC_APELLIDO": 0,
      "NUM_ATE": 0,
      "ENCRYPTED_ID": 0
  }
        ];
        function Ajax_DataTable_Det_Ate(ID_ATE, yyyy) {
            var pos = yyyy;
            var sx = Mx_Dtt[pos].ID_SEXO;
            if (sx == 2) {
                sx = "FEMENINO";
            }
            else {
                sx = "MASCULINO";
            }

            var Data_Par = JSON.stringify({
                "ID_ATE": ID_ATE
            });
            //$(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rev_Est_Exa_New.aspx/Llenar_DataTable_Det_Ate",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Det_Ate = JSON.parse(json_receiver);
                        for (i = 0; i < Mx_Dtt_Det_Ate.length; ++i) {
                            var date_x = Mx_Dtt_Det_Ate[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");
                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Det_Ate[i].ATE_FECHA = Date_Change;
                        }
                        $("#Div_Tabla_Listado_Exa_Ate").empty();
                        Fill_DataTable_Listado_Exa_Ate();
                        ID_ATE_RED = Mx_Dtt_Det_Ate[0].ENCRYPTED_ID;
                        $('#numerito').text("N° Atención: " + Mx_Dtt_Det_Ate[0].NUM_ATE);
                        $('#emodal_rut').text("RUT: " + Mx_Dtt[pos].PAC_RUT);
                        $('#nombrecito').text("Nombre: " + Mx_Dtt_Det_Ate[0].PAC_NOMBRE + " " + Mx_Dtt_Det_Ate[0].PAC_APELLIDO).addClass("text-uppercase");
                        $('#emodal_fecha').text("Fecha: " + moment(Mx_Dtt_Det_Ate[0].ATE_FECHA).format("DD-MM-YYYY"));
                        $('#emodal_lugartm').text("Lugar de TM: " + Mx_Dtt[pos].PROC_DESC);
                        $('#emodal_sexo').text("Sexo: " + sx);
                        $('#eModal').modal('show');

                    } else {

                        $("#mError_AAH h4").text("Sin Resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    // $("#Id_Conte").show();
                    //$(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

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
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PROC": $("#Procedencia").val(),
                "ID_PRE": $("#Ddl_previ").val(),
                "ID_CF": $("#Ddl_Exam").val(),
                "ID_EST": $("#Ddl_Estado").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rev_Est_Exa_New.aspx/Excel",
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
                    $(".block_wait").fadeOut(500);
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
            //$("<option>", { "value": 0 }).text("Seleccionar").appendTo("#Ddl_LugarTM");
            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_previ");
            for (y = 0; y < Mx_Dtt_previ.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_previ[y].ID_PREVE
                }).text(Mx_Dtt_previ[y].PREVE_DESC).appendTo("#Ddl_previ");
            }
        };
        //Llenar DropDownList Tipo de Atención
        function Fill_Ddl_Exam() {
            $("#Ddl_Exam").empty();
            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Exam");
            for (y = 0; y < Mx_Exam.length; ++y) {
                $("<option>", {
                    "value": Mx_Exam[y].ID_CODIGO_FONASA
                }).text(Mx_Exam[y].CF_DESC).appendTo("#Ddl_Exam");
            }
        };

    </script>
    <script>
        //---------------------------------------------------- TABLA  ------------------.........-----------------------------|
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
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Folio"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Atención"),
                    $("<th>", { "class": "textoReducido" }).text("RUT/DNI"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre"),
                    $("<th>", { "class": "textoReducido" }).text("Apellido Paterno"),
                    $("<th>", { "class": "textoReducido" }).text("Apellido Materno"),
                    $("<th>", { "class": "textoReducido" }).text("Sexo"),
                    $("<th>", { "class": "textoReducido" }).text("Edad"),
                    $("<th>", { "class": "textoReducido" }).text("Procedencia"),
                    $("<th>", { "class": "textoReducido" }).text("Teléfono"),
                    $("<th>", { "class": "textoReducido" }).text("Dirección"),
                    $("<th>", { "class": "textoReducido" }).text("Examen"),
                    $("<th>", { "class": "textoReducido" }).text("Estado"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Validación"),
                    $("<th>", { "class": "textoReducido" }).text("Hora Validación")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {

                let AP, AM, FONO, VALID;
                
                let APES = Mx_Dtt[i].PAC_APELLIDO.split(" ");

                switch (APES.length) {
                    case 2:
                        AP = APES[0];
                        AM = APES[1];
                        break;
                    case 3:
                        AP = APES[0] + " " + APES[1];
                        AM = APES[2];
                        break;
                    case 4:
                        AP = APES[0] + " " + APES[1];
                        AM = APES[2] + " " + APES[3];
                        break;
                    case 5:
                        AP = APES[0] + " " + APES[1] + " " + APES[2];
                        AM = APES[3] + " " + APES[4];
                        break;
                    default:
                        AP = Mx_Dtt[i].PAC_APELLIDO;
                        AM = "";
                }

                if (Mx_Dtt[i].PAC_FONO != "") {
                    FONO = Mx_Dtt[i].PAC_FONO;
                } else {
                    FONO = Mx_Dtt[i].PAC_MOVIL;
                }

                if (Mx_Dtt[i].EST_VALIDA == 6 || Mx_Dtt[i].EST_VALIDA == 14) {
                    VALID = "Validado";
                } else {
                    VALID = "Espera";
                }


                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].ATE_NUM),
                        $("<td>", { "class": "textoReducido" }).text(moment(Mx_Dtt[i].ATE_FECHA).format("DD-MM-YYYY")),
                        $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_RUT),
                        $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_NOMBRE),
                        $("<td>", { "class": "textoReducido" }).text(AP),
                        $("<td>", { "class": "textoReducido" }).text(AM),
                        $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_SEXO),
                        $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_EDAD+" Años"),
                        $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].PROC_DESC),
                        $("<td>", { "class": "textoReducido" }).text(FONO),
                        $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].PC_DIR),
                        $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].CF_DESC),
                        $("<td>", { "class": "textoReducido" }).text(VALID),
                        $("<td>", { "class": "textoReducido" }).text(() => {
                            if (VALID == "Validado") {
                                return moment(Mx_Dtt[i].FECHA_VALIDA).format("DD-MM-YYYY")
                            } else {
                                return ""
                            }
                        }),
                        $("<td>", { "class": "textoReducido" }).text(() => {
                            if (VALID == "Validado") {
                                return moment(Mx_Dtt[i].FECHA_VALIDA).format("HH:mm:ss")
                            } else {
                                return ""
                            }
                        })
                    )
                );
            }
        }
        //-----------------------------------------TABLA LISTADO DE EXAMENES de la ATENCIONES-------------------------------------------|
        function Fill_DataTable_Listado_Exa_Ate() {
            $("<table>", {
                "id": "DataTable_Lis_Exa_Ate",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Listado_Exa_Ate");
            $("#DataTable_Lis_Exa_Ate").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Lis_Exa_Ate").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Lis_Exa_Ate thead").attr("class", "cabezera");
            $("#DataTable_Lis_Exa_Ate thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Código"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción del Examen"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Hora"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario"),
                    $("<th>", { "class": "textoReducido" }).text("Forma de Pago")
                )
            );

            for (i = 0; i < Mx_Dtt_Det_Ate.length; i++) {
                $("#DataTable_Lis_Exa_Ate tbody").append(
                    $("<tr>", {
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Det_Ate[i].CF_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Det_Ate[i].CF_DESC),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Det_Ate[i].ATE_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());
                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }
                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date2 = new Date(Mx_Dtt_Det_Ate[i].ATE_FECHA);
                            var hh = parseInt(obj_date2.getHours());
                            var mm = parseInt(obj_date2.getMinutes());
                            var ss = parseInt(obj_date2.getSeconds());
                            if (hh < 10) { hh = "0" + hh; }
                            if (mm < 10) { mm = "0" + mm; }
                            if (ss < 10) { ss = "0" + ss; }
                            return String(hh + ":" + mm + ":" + ss);
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Det_Ate[i].USU_NIC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Det_Ate[i].TP_PAGO_DESC)
                    )
                );
                $("<tr>").attr("id", i + 1);
            }
        }
        function Ajax_Redirect() {
            var loc = location.origin;
            window.location.href = "" + loc + "/Buscar_Ate/Atencion_Det.aspx?ID_ATE=" + ID_ATE_RED + "";
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
                        Listado de Estados de Exámenes</h5>
                </div>
                <div class="card-body">
                    <div class="row" style="margin-left: 2px; margin-right: 2px;">
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
                            <label for="Ddl_Exam">Exámenes:</label>
                            <select id="Ddl_Exam" class="form-control">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-md">
                            <label for="Procedencia">Procedencia:</label>
                            <select id="Procedencia" class="form-control">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-md">
                            <label for="Ddl_previ">Previsión:</label>
                            <select id="Ddl_previ" class="form-control">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-md">
                            <label for="Ddl_Estado">Estado:</label>
                            <select id="Ddl_Estado" class="form-control">
                                <option value="0">Todos</option>
                                <option value="7">Espera</option>
                                <option value="6">Validado</option>
                                <option value="14">Impreso</option>
                            </select>
                        </div>
                        <div class="col-md">
                            <button id="Btn_Buscar" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>

                            <button id="Btn_Excel" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                        </div>
                    </div>
                </div>



                <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
                <div class="row" id="Id_Conte">
                    <div class="col-md-12" id="Paciente">
                        <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list"></i>Listado de Determinaciones</h5>
                        <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
