<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Lis_Lote_Recha.aspx.vb" Inherits="Presentacion.Lis_Lote_Recha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>

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
        var CB_Pendiente = 0;
        var ATE_NUM_Pendiente = 0;
        var ID_RECEP_ETI_RECHAZO_SUPREMO = 0;
        var correxxx = 0;
        var ID_Ateee = 0;
        var ID_Pac = 0;
        var nombre_waaa = "";

        $(document).ready(function () {
            $("#txtNAte").focus();

            //Llenar FECHAS
            function FECHAS_INS() {
                var asd = Mx_Dtt[0].nac;

                asd = asd.replace(/-/g, "/");
                var array = asd.split("/");
                var total = "";
                var dia = array[0];
                var mes = array[1];
                var ano = array[2];
                //if (dia < 10) { dia = "0" + dia; }
                //if (mes < 10) { mes = "0" + mes; }
                // cogemos los valores actuales
                var fecha_hoy = new Date();
                var ahora_ano = fecha_hoy.getYear();
                var ahora_mes = fecha_hoy.getMonth() + 1;
                var ahora_dia = fecha_hoy.getDate();

                // realizamos el calculo
                var edad = (ahora_ano + 1900) - ano;
                if (ahora_mes < mes) {
                    edad--;
                }
                if ((mes == ahora_mes) && (ahora_dia < dia)) {
                    edad--;
                }
                if (edad > 1900) {
                    edad -= 1900;
                }
                // calculamos los meses
                var meses = 0;
                if (ahora_mes > mes)
                    meses = ahora_mes - mes;
                if (ahora_mes < mes)
                    meses = 12 - (mes - ahora_mes);
                if (ahora_mes == mes && dia > ahora_dia)
                    meses = 11;
                // calculamos los dias
                var dias = 0;
                total = String(edad + " Años");
                if (ahora_dia > dia) {
                    dias = ahora_dia - dia;
                    total = String(edad + " Años");
                }
                if (ahora_dia < dia) {
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                    total = String(edad + " Años");
                }
                //$("#txtEdad").val(total);
            }

            $("#Div_Tabla").empty();
            //$("#Id_Conte").hide();

            $("#Btn_Buscar_x_ate").click(function () {

                if ($("#txtNAte").val() == "") {

                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, ingrese un número de folio");
                    $("#mError_AAH").modal();

                } else {
                    var num_loteqq = $('#txtNAte').val();
                    Ajax_Muestras_Lotes(num_loteqq);
                }
            });

            $('#txtNAte').change(function (event) {
                var hola = $('#txtNAte').val();

                var keycode = event.which;
                Ajax_Muestras_Lotes(hola);

                var keycode = event.which;

            });


            // VER LOTES
            $("#Btn_Lote").click(function () {
                Ajax_Ver_Lotes_Anteriores();
            });

            $("#Btn_Anterior_Muestras_Lotes").click(function () {
                var direccion = parseInt(Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM);
                direccion = --direccion;
                var jejeje = parseInt($('#txtNAte').val());
                jejeje = --jejeje;
                $('#txtNAte').val(jejeje);
                Ajax_Muestras_Lotes_direccion_negativo(jejeje);
            });

            $("#Btn_Siguiente_Muestras_Lotes").click(function () {
                var direccion = parseInt(Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM);
                direccion = ++direccion;
                var jijiji = parseInt($('#txtNAte').val());
                jijiji = ++jijiji;
                $('#txtNAte').val(jijiji);
                Ajax_Muestras_Lotes_direccion_positivo(jijiji);
            });

        });


    </script>


    <script>
        //-------------------------------------------------- VER LOTES ANTERIORES ------------------------------------------------------|
        var Mx_Dtt_Lotes_Anteriores = [
            {
                "LOTE_RECHAZO_NUM": 0,
                "ID_USUARIO": 0,
                "LOTE_RECHAZO_FECHA": 0,
                "USU_NIC": 0
            }
        ];

        function Ajax_Ver_Lotes_Anteriores() {

            //var Data_Par = JSON.stringify({
            //    "ID_Pac": ID_Pac
            //});
            $.ajax({
                "type": "POST",
                "url": "Lis_Lote_Recha.aspx/IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Lotes_Anteriores = json_receiver;
                        Hide_Modal();

                        $('#eModal_Muestras_Por_Lotes').modal('hide');
                        $('#eModalLotesAnteriores').modal('hide');
                        $('#eModalLotesAnteriores').modal('show');
                        $("#Div_Tabla_Lotes_Anteriores").empty();

                        for (i = 0; i < Mx_Dtt_Lotes_Anteriores.length; ++i) {
                            var date_x = Mx_Dtt_Lotes_Anteriores[i].LOTE_RECHAZO_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Lotes_Anteriores[i].LOTE_RECHAZO_FECHA = Date_Change;
                        }

                        Fill_DataTable_Lotes_Anteriores();


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
                    Hide_Modal();


                }
            });
        }

        //-------------------------------------------------- VER MUESTRAS POR LOTES ----------------------------------------------------|
        var Mx_Dtt_Muestras_Lotes = [
            {
                "LOTE_RECHAZO_NUM": 0,
                "ID_ATENCION": 0,
                "RECEP_ETI_CURVA_RECHAZO": 0,
                "RECEP_ETI_NUM_ATE_RECHAZO": 0,
                "ID_USUARIO": 0,
                "RECEP_ETI_RECHAZO_OBS": 0,
                "RECEP_ETI_FECHA_RECHAZO": 0,
                "ID_LOTE_RECHAZO": 0,
                "ID_ESTADO": 0,
                "CB_DESC": 0,
                "T_MUESTRA_DESC": 0,
                "CF_DESC": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "RLS_LS_DESC": 0,
                "ID_RLS_LS": 0,
                "EST_DESCRIPCION": 0,
                "ID_PER": 0,
                "PROC_DESC": 0,
                "ATE_AÑO": 0,
                "ATE_MES": 0,
                "ATE_DIA": 0,
                "SEXO_DESC": 0,
                "TP_RECHA_DESC": 0,
                "ID_TP_RECHA": 0,
                "USU_NIC": 0
            }
        ];

        function Ajax_Muestras_Lotes(NUMLOTE) {
            modal_show();

            var Data_Par = JSON.stringify({
                "NUMLOTE": NUMLOTE
            });
            $.ajax({
                "type": "POST",
                "url": "Lis_Lote_Recha.aspx/IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Muestras_Lotes = json_receiver;
                        Hide_Modal();

                        $('#txtNAte').val(Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM);
                        $("#DataTable_Muestras_Por_Lotes").empty();
                        $('#eModalLotesAnteriores').modal('hide');
                        $('#eModal_Muestras_Por_Lotes').modal('hide');
                        //$('#eModal_Muestras_Por_Lotes').modal('show');

                        for (i = 0; i < Mx_Dtt_Muestras_Lotes.length; ++i) {
                            var date_x = Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_FECHA_RECHAZO;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_FECHA_RECHAZO = Date_Change;
                        }

                        Fill_DataTable_Muestras_Por_Lotes();

                    } else {

                        $("#DataTable_Muestras_Por_Lotes").empty();
                        Hide_Modal();
                        //$("#mError_AAH h4").text("Sin resultados");
                        //$("#mError_AAH button").attr("class", "btn btn-danger");
                        //$("#mError_AAH p").text("No se han encontrado resultados");
                        //$("#mError_AAH").modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();

                }
            });
        }

        function Ajax_Muestras_Lotes_direccion_negativo(NUMLOTE) {
            modal_show();

            var Data_Par = JSON.stringify({
                "NUMLOTE": NUMLOTE
            });

            $.ajax({
                "type": "POST",
                "url": "Lis_Lote_Recha.aspx/IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Muestras_Lotes = json_receiver;
                        $('#txtNAte').val(Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM);
                        $("#DataTable_Muestras_Por_Lotes").empty();

                        for (i = 0; i < Mx_Dtt_Muestras_Lotes.length; ++i) {
                            var date_x = Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_FECHA_RECHAZO;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_FECHA_RECHAZO = Date_Change;
                        }

                        Hide_Modal();
                        Fill_DataTable_Muestras_Por_Lotes();

                    } else {

                        Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM--;
                        //$('#txtNAte').val(Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM);

                        Hide_Modal();
                        $("#DataTable_Muestras_Por_Lotes").empty();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();


                }
            });
        }

        function Ajax_Muestras_Lotes_direccion_positivo(NUMLOTE) {
            modal_show();

            var Data_Par = JSON.stringify({
                "NUMLOTE": NUMLOTE
            });
            $.ajax({
                "type": "POST",
                "url": "Lis_Lote_Recha.aspx/IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Muestras_Lotes = json_receiver;
                        $('#txtNAte').val(Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM);
                        $("#DataTable_Muestras_Por_Lotes").empty();

                        for (i = 0; i < Mx_Dtt_Muestras_Lotes.length; ++i) {
                            var date_x = Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_FECHA_RECHAZO;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_FECHA_RECHAZO = Date_Change;
                        }

                        Hide_Modal();
                        Fill_DataTable_Muestras_Por_Lotes();

                    } else {

                        Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM++;
                        //$('#txtNAte').val(Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM);
                        Hide_Modal();
                        $("#DataTable_Muestras_Por_Lotes").empty();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();

                }
            });
        }


    </script>

    <script>

        //------------------------------------------------ TABLA LOTES ANTERIORES   -----------------------------------------------------|
        function Fill_DataTable_Lotes_Anteriores() {
            $("<table>", {
                "id": "DataTable_Lotes_Anteriores",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Lotes_Anteriores");

            $("#DataTable_Lotes_Anteriores").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Lotes_Anteriores").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Lotes_Anteriores thead").attr("class", "cabezera2");

            $("#DataTable_Lotes_Anteriores thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario"),
                    $("<th>", { "class": "textoReducido" }).text("fecha"),
                    $("<th>", { "class": "textoReducido" }).text("N° Lote")
                )
            );

            for (i = 0; i < Mx_Dtt_Lotes_Anteriores.length; i++) {
                $("#DataTable_Lotes_Anteriores tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Muestras_Lotes("` + Mx_Dtt_Lotes_Anteriores[i].LOTE_RECHAZO_NUM + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Lotes_Anteriores[i].USU_NIC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Lotes_Anteriores[i].LOTE_RECHAZO_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Lotes_Anteriores[i].LOTE_RECHAZO_NUM)
                    )
                );
            }
        }

        //------------------------------------------------ TABLA MUESTRAS POR LOTES -----------------------------------------------------|
        function Fill_DataTable_Muestras_Por_Lotes() {
            $("<table>", {
                "id": "DataTable_Muestras_Por_Lotes",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Muestras_Lotes");

            $("#DataTable_Muestras_Por_Lotes").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Muestras_Por_Lotes").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Muestras_Por_Lotes thead").attr("class", "cabezera");

            $("#DataTable_Muestras_Por_Lotes thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Etiqueta"),
                    $("<th>", { "class": "textoReducido" }).text("Examen Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("Estado"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Folio"),
                    $("<th>", { "class": "textoReducido" }).text("N° Lote"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario"),
                    $("<th>", { "class": "textoReducido" }).text("Desc. Sección"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar")
                )
            );

            for (i = 0; i < Mx_Dtt_Muestras_Lotes.length; i++) {
                $("#DataTable_Muestras_Por_Lotes tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text("[" + Mx_Dtt_Muestras_Lotes[i].CB_DESC + "]" + " " + Mx_Dtt_Muestras_Lotes[i].T_MUESTRA_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].CF_DESC),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt_Muestras_Lotes[i].EST_DESCRIPCION == "RECEP.") {
                                $(this).css("cssText", "background-color: #88d6e2 !important; cursor:pointer; text-align:center;").text("RECEP.");
                            }
                            else {
                                $(this).css("cssText", "background-color:#f5b0e5 !important; text-align:center;").text(Mx_Dtt_Muestras_Lotes[i].EST_DESCRIPCION);
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_FECHA_RECHAZO);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].PAC_NOMBRE + " " + Mx_Dtt_Muestras_Lotes[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_NUM_ATE_RECHAZO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].LOTE_RECHAZO_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].USU_NIC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].RLS_LS_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].PROC_DESC)
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

        .textoReducido2 {
            font-size: 10px;
        }

        .highlights {
            width: 710px;
            height: 404px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .highlights2 {
            width: 710px;
            height: 404px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
        }

        .checkbox-success input[type="checkbox"]:checked + label::before {
            background-color: #5cb85c;
            border-color: #5cb85c;
        }

        .checkbox-success input[type="checkbox"]:checked + label::after {
            color: #fff;
        }

        .checkbox-success {
            line-height: 13px;
            margin-bottom: 3px;
        }

            .checkbox-success input[type="checkbox"], label {
                cursor: pointer;
            }

        .checkbox label {
            width: 90%;
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

            .highlights {
                height: 100%;
            }

            .buttons {
                display: flex;
                flex-flow: column;
            }
            #Btn_Anterior_Muestras_Lotes{
                width: 100%;
            }
            #Btn_Siguiente_Muestras_Lotes{
                width: 100%;
            }
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <!-- Modal -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <%-------------------------------------------------- MODAL LOTES ANTERIORES ---------------------------------------------------%>
    <div id="eModalLotesAnteriores" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Últimos Lotes</h4>
                </div>
                <div class="modal-body">
                    <div id="Div_Tabla_Lotes_Anteriores" style="width: 100%;" class="table-responsive"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <%---------------------------------------------------- MODAL MUESTRAS DE LOTE --------------------------------------------------------%>
    <div class="modal fade" id="eModal_Muestras_Por_Lotes" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document" style="width: 80vw; max-width: 80vw;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Listar Lote de Trabajo</h4>
                </div>
                <div class="modal-header">
                    <h5>N° Lote: </h5>
                    
                    <h5 id="lote_nummmmm"></h5>
                    
                    
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Salir</button>
                </div>
                <div class="modal-body" style="overflow: auto;">
                    <h5 class="modal-title" id="numerito">Listado de Muestra Rechazada</h5>
                    <div id="" class="table-responsive" style="width: 100%; overflow: auto; max-height: 40vh;"></div>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>

    <%------------------------------------------------------TÍTULO, TEXTBOX Y BOTONES----------------------------------------------%>
    <div>
        <div class="col-lg-1"></div>
    <div class="card-header bg-bar">
        <h5 style="text-align: center; padding: 5px;">
            <i class="fa fa-search"></i>
            Listado de Rechazo de Muestras
        </h5>
    </div>
    <div class="row">
        <div class="col-lg">
            <div class="row">
                <div class="col-lg-2">
                    <label for="txtNAte">N° Rechazo:</label>
                    <input id="txtNAte" maxlength="9" class="form-control textoReducido" type="text" placeholder="BUSCAR..." onkeydown="return jsDecimals(event);" />
                    <button id="Btn_Buscar_x_ate" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                </div>              
                <div class="col-lg-1">
                    <br />
                    <button type="button" id="Btn_Anterior_Muestras_Lotes" class="btn btn-success fa fa-arrow-circle-o-left" style="margin-top: 5px;"></button>
                </div>
                <div class="col-lg-3">
                    <br />
                    <button type="button" id="Btn_Siguiente_Muestras_Lotes" class="btn btn-success fa fa-arrow-circle-o-right" style="margin-top: 5px;"></button>
                </div>
                <div class="col-lg-4">
                </div>
                <div class="col-lg-2">
                    <br />
                    <button id="Btn_Lote" class="btn btn-warning btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-eye mr-2"></i>Ver Lotes Anteriores</button>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-1"></div>
    </div>

    <%-------------------------------------------------------------TABLAS-----------------------------------------------------------%>
    <div class="row" id="Id_Conte">
        <div class="col-lg-12" id="Paciente">
            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list"></i>Listado de Muestras Recepcionadas</h5>
            <div id="Div_Muestras_Lotes" style="width: 100%;" class="highlights"></div>
        </div>
    </div>
</asp:Content>

