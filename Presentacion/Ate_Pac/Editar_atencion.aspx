<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Editar_atencion.aspx.vb" Inherits="Presentacion.Editar_atencion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script>
        $(document).ready(function () {

            Ajax_LugarTM();
            Ajax_TPAte();
            Ajax_O_Ate();
            Ajax_Medico();
            Ajax_Prevision();
            Ajax_Localizacion();
            Ajax_Sector();
            Ajax_Programa();

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

            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date03 input").val(dateNow);
            $('#Txt_Date03').datetimepicker(
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

            $("#fecha3").change(function () {
                var asd = $("#fecha3").val();

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
                $("#txtEdad").val(total);
                $("#txtMes").val(meses);
                $("#txtDia").val(dias);

            });


            $(".block_wait").fadeOut(0);
            $("#Div_Tabla").empty();
            $("#Div_Tabla").show();
            $("#Id_Conte").hide();

            //Registrar evento Click del Botón Buscar       
            $("#Btn_Buscar").click(function () {
                $("#Div_Tabla").empty();
                Ajax_DataTable();
            });

            //Registrar evento Click del Botón EDITAR
            $("#Btn_Actualizar_Atencion").click(function () {
                var sum = 0;
                if ($("#DdlLugarTM").val() == 0) {
                    $("#DdlLugarTM").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#DdlLugarTM").css({
                        "border-color": "green"
                    });
                }

                if ($("#DdlTAtencion").val() == 0) {
                    $("#DdlTAtencion").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#DdlTAtencion").css({
                        "border-color": "green"
                    });
                }
                if ($("#Ddl_O_Ate").val() == 0) {
                    $("#Ddl_O_Ate").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Ddl_O_Ate").css({
                        "border-color": "green"
                    });
                }
                if ($("#DdlMedico").val() == 0) {
                    $("#DdlMedico").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#DdlMedico").css({
                        "border-color": "green"
                    });
                }
                if ($("#DdlPrevision").val() == 0) {
                    $("#DdlPrevision").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#DdlPrevision").css({
                        "border-color": "green"
                    });
                }
                if ($("#DdlLocalización").val() == 0) {
                    $("#DdlLocalización").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#DdlLocalización").css({
                        "border-color": "green"
                    });
                }
                if ($("#txtCama").val() == "") {
                    $("#txtCama").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#txtCama").css({
                        "border-color": "green"
                    });
                }
                if ($("#DdlSector").val() == 0) {
                    $("#DdlSector").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#DdlSector").css({
                        "border-color": "green"
                    });
                }
                if ($("#DdlPrograma").val() == 0) {
                    $("#DdlPrograma").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#DdlPrograma").css({
                        "border-color": "green"
                    });
                }
                if ($("#txtEdad").val() == "") {
                    $("#txtEdad").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#txtEdad").css({
                        "border-color": "green"
                    });
                }
                if ($("#txtMes").val() == "") {
                    $("#txtMes").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#txtMes").css({
                        "border-color": "green"
                    });
                }
                if ($("#txtDia").val() == "") {
                    $("#txtDia").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#txtDia").css({
                        "border-color": "green"
                    });
                }
                if (sum == 12) {
                    $("#Btn_Actualizar_Atencion").attr("class", "btn btn-success  btn-block");

                    selected = new Array();
                    $("input:checkbox:checked").each(function () {
                        selected.push($(this).val());
                    });
                    Ajax_Update_Datos();

                } else {
                    $("#Btn_Actualizar_Atencion").attr("class", "btn btn-danger btn-block");
                }

            });
        });
    </script>
    <script>
        //------------------------------------------------ AJAX DDL LUGAR DE TM -------------------------------------------|
        var Mx_Dtt_LugarTM = [
    {
        "ID_ESTADO": 0,
        "PROC_DESC": 0,
        "PROC_COD": 0,
        "ID_PROCEDENCIA": 0
    }
        ];

        function Ajax_LugarTM() {
            modal_show();



            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Editar_atencion.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_LugarTM = JSON.parse(json_receiver);

                        Fill_Ddl_LugarTM();
                        Hide_Modal();


                    } else {


                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }


        //----------------------------------------------- AJAX DDL TIPO DE ATENCIÓN --------------------------------------|
        var Mx_Dtt_TPAte = [
    {
        "ID_TP_ATENCION": 0,
        "TP_ATE_COD": 0,
        "TP_ATE_DESC": 0,
        "ID_ESTADO": 0
    }
        ];

        function Ajax_TPAte() {
            modal_show();



            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Editar_atencion.aspx/Llenar_Ddl_TPAte",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_TPAte = JSON.parse(json_receiver);

                        Fill_Ddl_TPAte();
                        Hide_Modal();


                    } else {


                        Hide_Modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        //----------------------------------------------- AJAX DDL ORDEN DE ATENCIÓN -------------------------------------|
        var Mx_Dtt_O_Ate = [
    {
        "ID_ORDEN": 0,
        "ORD_COD": 0,
        "ORD_DESC": 0,
        "ID_ESTADO": 0
    }
        ];

        function Ajax_O_Ate() {
            modal_show();



            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Editar_atencion.aspx/Llenar_Ddl_O_Ate",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_O_Ate = JSON.parse(json_receiver);

                        Fill_Ddl_O_Ate();
                        Hide_Modal();


                    } else {


                        Hide_Modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        //-------------------------------------------------- AJAX DDL MÉDICOS -----------------------------------------------|
        var Mx_Dtt_Medico = [
    {
        "ID_DOCTOR": 0,
        "DOC_NOMBRE": 0,
        "DOC_APELLIDO": 0,
        "ID_ESTADO": 0,
        "ESP_DESC": 0,
        "DOC_FONO1": 0,
        "DOC_MOVIL1": 0
    }
        ];

        function Ajax_Medico() {
            modal_show();



            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Editar_atencion.aspx/Llenar_Ddl_Medico",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Medico = JSON.parse(json_receiver);

                        Fill_Ddl_Medico();
                        Hide_Modal();


                    } else {


                        Hide_Modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        //-------------------------------------------------- AJAX DDL PREVISIÓN ---------------------------------------------|
        var Mx_Dtt_Prevision = [
    {
        "ID_PREVE": 0,
        "PREVE_COD": 0,
        "PREVE_DESC": 0,
        "ID_ESTADO": 0
    }
        ];

        function Ajax_Prevision() {
            modal_show();



            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Editar_atencion.aspx/Llenar_Ddl_Prevision",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Prevision = JSON.parse(json_receiver);

                        Fill_Ddl_Prevision();
                        Hide_Modal();


                    } else {


                        Hide_Modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        //------------------------------------------------ AJAX DDL LOCALIZACIÓN -------------------------------------------|
        var Mx_Dtt_Localizacion = [
    {
        "ID_LOCAL": 0,
        "LOCAL_COD": 0,
        "LOCAL_DESC": 0,
        "ID_ESTADO": 0
    }
        ];

        function Ajax_Localizacion() {
            modal_show();



            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Editar_atencion.aspx/Llenar_Ddl_Localizacion",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Localizacion = JSON.parse(json_receiver);

                        Fill_Ddl_Localizacion();
                        Hide_Modal();


                    } else {


                        Hide_Modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        //-------------------------------------------------- AJAX DDL SECTOR -------------------------------------------------|
        var Mx_Dtt_Sector = [
    {
        "ID_SECTOR": 0,
        "SECTOR_COD": 0,
        "SECTOR_DESC": 0,
        "ID_ESTADO": 0
    }
        ];

        function Ajax_Sector() {
            modal_show();



            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Editar_atencion.aspx/Llenar_Ddl_Sector",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Sector = JSON.parse(json_receiver);

                        Fill_Ddl_Sector();
                        Hide_Modal();


                    } else {


                        Hide_Modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        //-------------------------------------------------- AJAX DDL PROGRAMA ------------------------------------------------|
        var Mx_Dtt_Programa = [
    {
        "ID_PROGRA": 0,
        "PROGRA_COD": 0,
        "PROGRA_DESC": 0,
        "ID_ESTADO": 0
    }
        ];

        function Ajax_Programa() {
            modal_show();



            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Editar_atencion.aspx/Llenar_Ddl_Programa",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Programa = JSON.parse(json_receiver);

                        Fill_Ddl_Programa();
                        Hide_Modal();


                    } else {


                        Hide_Modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }
        //-------------------------------------------------- AJAX BUSCAR ATENCIÓN----------------------------------------------|
        var Mx_Dtt = [
            {
                "ID_ATENCION": 0,
                "ATE_NUM": 0,
                "ATE_FECHA": 0,
                "ID_PACIENTE": 0,
                "PAC_RUT": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "ATE_AÑO": 0,
                "PROC_DESC": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "SEXO_DESC": 0,
                "ID_SEXO": 0,
                "ENCRYPTED_ID": 0,
                "PAC_FNAC": 0
            }
        ];

        function Ajax_DataTable() {
            modal_show();


            var Data_Par = JSON.stringify({
                "FECHA1": $("#Txt_Date01 input").val(),
                "FECHA2": $("#Txt_Date02 input").val(),
                "LUGARTM": $("#Ddl_LugarTM").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Editar_atencion.aspx/Llenar_DataTable",
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
                        $("#Div_Tabla").empty();
                        Fill_DataTable();
                        Hide_Modal();


                    } else {


                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        //-------------------------------------------------- AJAX ATENCION MODAL ----------------------------------------------|
        var Mx_Dtt_Atencion = [
        {
            "ID_ATENCION": 0,
            "ATE_NUM": 0,
            "ATE_FECHA": 0,
            "ATE_FUR": 0,
            "ATE_OBS_FICHA": 0,
            "ATE_AÑO": 0,
            "ATE_OBS_TM": 0,
            "PAC_NOMBRE": 0,
            "SEXO_DESC": 0,
            "PAC_APELLIDO": 0,
            "PAC_FNAC": 0,
            "PAC_DIR": 0,
            "PAC_FONO1": 0,
            "PAC_MOVIL1": 0,
            "PAC_EMAIL": 0,
            "PAC_OBS_PERMA": 0,
            "NAC_DESC": 0,
            "COM_DESC": 0,
            "CIU_DESC": 0,
            "ID_PACIENTE": 0,
            "PAC_RUT": 0,
            "PROGRA_DESC": 0
        }
        ];


        function Ajax_DataTable_Atencion(ID_ATE) {
            modal_show();


            var Data_Par = JSON.stringify({
                "ID_ATE": ID_ATE
            });
            //$(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Editar_Atencion.aspx/IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Atencion = JSON.parse(json_receiver);

                        //for (i = 0; i < Mx_Dtt_Atencion.length; ++i) {
                        //    var date_x = Mx_Dtt_Atencion[i].PAC_FNAC;
                        //    date_x = String(date_x).replace("/Date(", "");
                        //    date_x = date_x.replace(")/", "");

                        //    var Date_Change = new Date(parseInt(date_x));
                        //    Mx_Dtt_Atencion[i].PAC_FNAC = Date_Change;
                        //}



                        $("#DataTable_Atencion").empty();
                        $("#DataTable_Atencion2").empty();
                        $("#DataTable_Atencion3").empty();
                        $("#DataTable_Atencion4").empty();
                        $("#DataTable_Atencion_Datos_Actuales").empty();
                        $("#DataTable_Atencion_Datos_Actuales2").empty();

                        $("#fecha3").val(Mx_Dtt_Atencion[0].PAC_FNAC);

                        FECHAS_INS();

                        Ajax_DataTable_Datos_Actuales(ID_ATE);
                        Hide_Modal();



                    } else {


                        Hide_Modal();

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

        //-------------------------------------------------- DATOS ACTUALES MODAL ---------------------------------------------|
        var Mx_Dtt_Datos_Actuales = [
        {
            "DOC_NOMBRE": 0,
            "DOC_APELLIDO": 0,
            "ID_ATENCION": 0,
            "ATE_NUM": 0,
            "TP_ATE_DESC": 0,
            "LOCAL_DESC": 0,
            "ORD_DESC": 0,
            "ID_ORDEN": 0,
            "ID_PROCEDENCIA": 0,
            "ID_TP_PACI": 0,
            "ID_DOCTOR": 0,
            "ID_SECTOR": 0,
            "ID_PREVE": 0,
            "ID_LOCAL": 0,
            "ATE_CAMA": 0,
            "ATE_OBS_FICHA": 0,
            "ID_ATE_DOCP": 0,
            "PROC_DESC": 0,
            "PREVE_DESC": 0,
            "ID_PROGRA": 0,
            "PROGRA_DESC": 0
        }
        ];


        function Ajax_DataTable_Datos_Actuales(ID_ATE) {
            modal_show();


            var Data_Par = JSON.stringify({
                "ID_ATE": ID_ATE
            });
            //$(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Editar_Atencion.aspx/IRIS_WEBF_BUSCA_EDITAR_ATE_DATOS_DE_ATENCION2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Datos_Actuales = JSON.parse(json_receiver);

                        $("#DdlLugarTM").val(Mx_Dtt_Datos_Actuales[0].ID_PROCEDENCIA);
                        $("#DdlTAtencion").val(Mx_Dtt_Datos_Actuales[0].ID_TP_PACI);
                        $("#Ddl_O_Ate").val(Mx_Dtt_Datos_Actuales[0].ID_ORDEN);
                        $("#DdlMedico").val(Mx_Dtt_Datos_Actuales[0].ID_DOCTOR);
                        $("#DdlPrevision").val(Mx_Dtt_Datos_Actuales[0].ID_PREVE);
                        $("#DdlLocalización").val(Mx_Dtt_Datos_Actuales[0].ID_LOCAL);
                        $("#DdlSector").val(Mx_Dtt_Datos_Actuales[0].ID_SECTOR);
                        $("#DdlPrograma").val(Mx_Dtt_Datos_Actuales[0].ID_PROGRA);
                        $("#txtCama").val(Mx_Dtt_Datos_Actuales[0].ATE_CAMA);
                        $("#txtObAtencion").val(Mx_Dtt_Datos_Actuales[0].ATE_OBS_FICHA);
                        //$("#txtEdad").val("");
                        //$("#txtMes").val("");
                        //$("#txtDia").val("");

                        Hide_Modal();
                        $('#eModal').modal('hide');
                        $('#eModal').modal('show');

                        Fill_DataTable_Atencion();
                        Fill_DataTable_Datos_Actuales();



                    } else {


                        Hide_Modal();

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

        //------------------------------------------------------ UPDATE DATOS ------------------------------------------------|

        var hola = 0;

        function Ajax_Update_Datos() {
            modal_show();


            var Data_Par = JSON.stringify({
                "ID_ATE": parseInt(Mx_Dtt_Atencion[0].ID_ATENCION),
                "ID_PROCE": parseInt($("#DdlLugarTM").val()),
                "ID_TP_PACI": parseInt($("#DdlTAtencion").val()),
                "ID_ORDEN": parseInt($("#Ddl_O_Ate").val()),
                "ID_DOCTOR": parseInt($("#DdlMedico").val()),
                "ID_PREVE": parseInt($("#DdlPrevision").val()),
                "ID_LOCAL": parseInt($("#DdlLocalización").val()),
                "ATE_CAMA": $("#txtCama").val(),
                "ATE_OBS_FICHA": $("#txtObAtencion").val(),
                "ID_PROGRA": parseInt($("#DdlPrograma").val()),
                "EDAD": parseInt($("#txtEdad").val()),
                "MES": parseInt($("#txtMes").val()),
                "DIA": parseInt($("#txtDia").val()),
                "SECTOR": parseInt($("#DdlSector").val()),
                "ID_PAC": parseInt(Mx_Dtt_Atencion[0].ID_PACIENTE),
                "FECHA": $("#fecha3").val(),
                "CHECK": selected
            });
            //$(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Editar_Atencion.aspx/IRIS_WEBF_UPDATE_DATOS_ATENCIONES3_PRO_SECTOR",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        hola = JSON.parse(json_receiver);
                        //$('#eModal').modal('hide');
                        Ajax_DataTable();
                        Ajax_DataTable_Atencion(Mx_Dtt_Atencion[0].ID_ATENCION);
                        Hide_Modal();


                    } else {


                        Hide_Modal();

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
                    Hide_Modal();



                }
            });
        }
    </script>




    <%-- Funciones de Llenado de Elementos --%>

    <script>


        //Llenar FECHAS
        function FECHAS_INS() {
            var asd = Mx_Dtt_Atencion[0].PAC_FNAC;

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
            $("#txtEdad").val(total);
            $("#txtMes").val(meses);
            $("#txtDia").val(dias);
        }
        //Llenar DropDownList Lugar de TM
        function Fill_Ddl_LugarTM() {
            $("#Ddl_LugarTM").empty();

            var procee = Galletas.getGalleta("USU_TM");
           // var procee = 0;
            if (procee == 0) {     
                Mx_Dtt_LugarTM.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                });
            }
            else {
                Mx_Dtt_LugarTM.forEach(aaa => {
                    if (aaa.ID_PROCEDENCIA == procee) {
                        $("<option>",
                          {
                              "value": aaa.ID_PROCEDENCIA
                          }
                       ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                    }

                });

            };



            Mx_Dtt_LugarTM.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_PROCEDENCIA
                    }
                ).text(aaa.PROC_DESC).appendTo("#DdlLugarTM");
            });





        }
        //Llenar DropDownList Tipo de Atención
        function Fill_Ddl_TPAte() {
            $("#DdlTAtencion").empty();

            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#DdlTAtencion");
            for (y = 0; y < Mx_Dtt_TPAte.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_TPAte[y].ID_TP_ATENCION
                }).text(Mx_Dtt_TPAte[y].TP_ATE_DESC).appendTo("#DdlTAtencion");
            }

        };

        //Llenar DropDownList Orden de Atención
        function Fill_Ddl_O_Ate() {
            $("#Ddl_O_Ate").empty();

            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#Ddl_O_Ate");

            for (y = 0; y < Mx_Dtt_O_Ate.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_O_Ate[y].ID_ORDEN
                }).text(Mx_Dtt_O_Ate[y].ORD_DESC).appendTo("#Ddl_O_Ate");
            }

        };

        //Llenar DropDownList Médico
        function Fill_Ddl_Medico() {
            $("#DdlMedico").empty();

            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#DdlMedico");
            for (y = 0; y < Mx_Dtt_Medico.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_Medico[y].ID_DOCTOR
                }).text(Mx_Dtt_Medico[y].DOC_NOMBRE + " " + Mx_Dtt_Medico[y].DOC_APELLIDO).appendTo("#DdlMedico");
            }

        };

        //Llenar DropDownList Prevision
        function Fill_Ddl_Prevision() {
            $("#DdlPrevision").empty();

            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#DdlPrevision");
            for (y = 0; y < Mx_Dtt_Prevision.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_Prevision[y].ID_PREVE
                }).text(Mx_Dtt_Prevision[y].PREVE_DESC).appendTo("#DdlPrevision");
            }
        };

        //Llenar DropDownList Localización
        function Fill_Ddl_Localizacion() {
            $("#DdlLocalización").empty();

            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#DdlLocalización");
            for (y = 0; y < Mx_Dtt_Localizacion.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_Localizacion[y].ID_LOCAL
                }).text(Mx_Dtt_Localizacion[y].LOCAL_DESC).appendTo("#DdlLocalización");
            }
        };

        //Llenar DropDownList Sector
        function Fill_Ddl_Sector() {
            $("#DdlSector").empty();

            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#DdlSector");
            for (y = 0; y < Mx_Dtt_Sector.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_Sector[y].ID_SECTOR
                }).text(Mx_Dtt_Sector[y].SECTOR_DESC).appendTo("#DdlSector");
            }
        };

        //Llenar DropDownList Programa
        function Fill_Ddl_Programa() {
            $("#DdlPrograma").empty();

            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#DdlPrograma");
            for (y = 0; y < Mx_Dtt_Programa.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_Programa[y].ID_PROGRA
                }).text(Mx_Dtt_Programa[y].PROGRA_DESC).appendTo("#DdlPrograma");
            }
        };
    </script>

    <script>

        //---------------------------------------------------- TABLA PACIENTE ------------------.........-----------------------------|
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
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Edad"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Hora"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar de TM"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Sexo"),
                    $("<th>", { "class": "textoReducido" }).text("Médico")

                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_DataTable_Atencion("` + Mx_Dtt[i].ID_ATENCION + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            var asd = Mx_Dtt[i].PAC_FNAC;

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
                            return total;

                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt[i].ATE_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date2 = new Date(Mx_Dtt[i].ATE_FECHA);
                            var hh = parseInt(obj_date2.getHours());
                            var mm = parseInt(obj_date2.getMinutes());
                            var ss = parseInt(obj_date2.getSeconds());

                            if (hh < 10) { hh = "0" + hh; }
                            if (mm < 10) { mm = "0" + mm; }
                            if (ss < 10) { ss = "0" + ss; }

                            return String(hh + ":" + mm + ":" + ss);
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PROC_DESC),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt[i].SEXO_DESC == "Femenino") {
                                $(this).css("cssText", "background-color:#f5b0e5 !important; cursor:pointer; text-align:center;").text("Femenino");
                            }
                            else {
                                $(this).css("cssText", " color:inherit; background-color:#88d6e2 !important; text-align:center;").text("Masculino");
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DOC_NOMBRE + " " + Mx_Dtt[i].DOC_APELLIDO)
                    )
                );
                $("<tr>").attr("id", i + 1);
            }
        }


        //------------------------------------------------ EDITAR ATENCIÓN  ----------------------------------------------------------|
        function Fill_DataTable_Atencion() {
            //     -------------------------------------------------  1   ------------------------------------------------------------|
            $("<table>", {
                "id": "DataTable_Atencion",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Atencion");

            $("#DataTable_Atencion").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Atencion").attr("class", "table table table-hover table-striped table-iris");
            $("#DataTable_Atencion thead").attr("class", "cabezera");

            $("#DataTable_Atencion thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Nac."),
                    $("<th>", { "class": "textoReducido" }).text("Edad"),
                    $("<th>", { "class": "textoReducido" }).text("Sexo"),
                    $("<th>", { "class": "textoReducido" }).text("F.U.R")

                )
            );

            for (i = 0; i < Mx_Dtt_Atencion.length; i++) {
                var sexo = "";
                if (Mx_Dtt_Atencion[i].SEXO_DESC == "Femenino") {

                } else {

                };
                $("#DataTable_Atencion tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_NOMBRE + " " + Mx_Dtt_Atencion[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_FNAC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            var asd = Mx_Dtt_Atencion[i].PAC_FNAC
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
                            return total;

                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt_Atencion[i].SEXO_DESC == "Femenino") {
                                $(this).css("cssText", "background-color:#f5b0e5 !important; cursor:pointer; text-align:center;").text("Femenino");
                            }
                            else {
                                $(this).css("cssText", " color:inherit; background-color:#88d6e2 !important; text-align:center;").text("Masculino");
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].ATE_FUR)
                    )
                );
            }
            //   ------------------------------------------------ 2 ---------------------------------------------|
            $("<table>", {
                "id": "DataTable_Atencion2",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Atencion");

            $("#DataTable_Atencion2").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Atencion2").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Atencion2 thead").attr("class", "cabezera");

            $("#DataTable_Atencion2 thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Nacionalidad"),
                    $("<th>", { "class": "textoReducido" }).text("Teléfono Fijo"),
                    $("<th>", { "class": "textoReducido" }).text("Celular"),
                    $("<th>", { "class": "textoReducido" }).text("Ciudad"),
                    $("<th>", { "class": "textoReducido" }).text("Comuna"),
                    $("<th>", { "class": "textoReducido" }).text("Dirección")
                )
            );

            for (i = 0; i < Mx_Dtt_Atencion.length; i++) {
                $("#DataTable_Atencion2 tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].NAC_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_FONO1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_MOVIL1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].CIU_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].COM_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_DIR)
                    )
                );
            }

            //------------------------------------------------------- 3 --------------------------------------------------------|
            $("<table>", {
                "id": "DataTable_Atencion3",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Atencion");

            $("#DataTable_Atencion3").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Atencion3").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Atencion3 thead").attr("class", "cabezera");

            $("#DataTable_Atencion3 thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Email"),
                    $("<th>", { "class": "textoReducido" }).text("Observaciones PERMANENTES del Paciente")
                )
            );

            for (i = 0; i < Mx_Dtt_Atencion.length; i++) {
                $("#DataTable_Atencion3 tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_EMAIL),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_OBS_PERMA)
                    )
                );
            }
            //------------------------------------------------------- 4 ---------------------------------------------------------------|
            $("<table>", {
                "id": "DataTable_Atencion4",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Atencion");

            $("#DataTable_Atencion4").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Atencion4").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Atencion4 thead").attr("class", "cabezera");

            $("#DataTable_Atencion4 thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Observación de la Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Observación de Toma de Muestra")

                )
            );

            for (i = 0; i < Mx_Dtt_Atencion.length; i++) {
                $("#DataTable_Atencion4 tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].ATE_OBS_FICHA),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].ATE_OBS_TM)
                    )
                );
            }

        }

        //------------------------------------------------ TABLA DATOS ACTUALES MODAL ------------------------------------------------|
        function Fill_DataTable_Datos_Actuales() {
            //     -------------------------------------------------  1   ------------------------------------------------------------|
            $("<table>", {
                "id": "DataTable_Atencion_Datos_Actuales",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Datos_Actuales");

            $("#DataTable_Atencion_Datos_Actuales").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Atencion_Datos_Actuales").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Atencion_Datos_Actuales thead").attr("class", "cabezera2");

            $("#DataTable_Atencion_Datos_Actuales thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Lugar de TM."),
                    $("<th>", { "class": "textoReducido" }).text("Tipo de Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Orden de Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Doctor"),
                    $("<th>", { "class": "textoReducido" }).text("Previsión")

                )
            );

            for (i = 0; i < Mx_Dtt_Datos_Actuales.length; i++) {
                $("#DataTable_Atencion_Datos_Actuales tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Datos_Actuales[i].PROC_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Datos_Actuales[i].TP_ATE_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Datos_Actuales[i].ORD_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Datos_Actuales[i].DOC_NOMBRE + " " + Mx_Dtt_Datos_Actuales[i].DOC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Datos_Actuales[i].PREVE_DESC)
                    )
                );
            }
            //   ------------------------------------------------ 2 ---------------------------------------------|
            $("<table>", {
                "id": "DataTable_Atencion_Datos_Actuales2",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Datos_Actuales");

            $("#DataTable_Atencion_Datos_Actuales2").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Atencion_Datos_Actuales2").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Atencion_Datos_Actuales2 thead").attr("class", "cabezera2");

            $("#DataTable_Atencion_Datos_Actuales2 thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Localización"),
                    $("<th>", { "class": "textoReducido" }).text("Cama"),
                    $("<th>", { "class": "textoReducido" }).text("Observación de la Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Programa")
                )
            );

            for (i = 0; i < Mx_Dtt_Datos_Actuales.length; i++) {
                $("#DataTable_Atencion_Datos_Actuales2 tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Datos_Actuales[i].LOCAL_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Datos_Actuales[i].ATE_CAMA),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Datos_Actuales[i].ATE_OBS_FICHA),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PROGRA_DESC)
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
            height: 60vh; /* Ancho y alto fijo */
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
    <div class="modal fade" id="eModal" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Editar Atención</h4>
                </div>
                <div class="modal-body">
                    <div id="Div_Tabla_Atencion" style="width: 100%;" class="table-responsive"></div>
                    <h4>Datos Actuales</h4>
                    <div id="Div_Datos_Actuales" style="width: 100%;" class="table-responsive"></div>
                    <h4>Datos Nuevos</h4>
                    <div class="container" style="width: 100%; border: 2px;">
                        <%----------------------------- fecha de nac y dias y mes y blablabla -----------------------------%>
                        <div class="row">
                            <div class="col-lg-1 checkbox checkbox-success" style="cursor: pointer;">
                                <input id="checkBox2" type="checkbox" />
                                <label for="checkBox2" class="textoReducido">Editar*</label>
                            </div>
                            <div class="col-lg-2">
                            </div>
                            <div class="col-lg-3">
                                <label for="fecha">F. Nacimiento:</label>
                                <div class='input-group date' id='Txt_Date03'>
                                    <input type='text' id="fecha3" class="form-control textoReducido" readonly="true" />
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <label for="txtEdad">Edad:</label>
                                <input id="txtEdad" class="form-control textoReducido mayus" type="text" readonly="true" />
                            </div>
                            <div class="col-lg-2">
                                <label for="txtMes">Mes:</label>
                                <input id="txtMes" class="form-control textoReducido mayus" type="text" readonly="true" />
                            </div>
                            <div class="col-lg-2">
                                <label for="txtDia">Día:</label>
                                <input id="txtDia" class="form-control textoReducido mayus" type="text" readonly="true" />
                            </div>
                        </div>
                        <br />
                        <%----------------------------- 1ra fila -----------------------------%>
                        <div class="row">
                            <div class="col-md-4">
                                <label for="DdlLugarTM">Lugar de TM:</label>
                                <select id="DdlLugarTM" class="form-control textoReducido mayus">
                                </select>
                            </div>
                            <div class="col-md-4">
                                <label for="DdlTAtencion">Tipo de Atención:</label>
                                <select id="DdlTAtencion" class="form-control textoReducido mayus">
                                </select>
                            </div>
                            <div class="col-md-4">
                                <label for="Ddl_O_Ate">Orden de Atención:</label>
                                <select id="Ddl_O_Ate" class="form-control textoReducido mayus">
                                </select>
                            </div>
                        </div>
                        <br />
                        <%------------------------------ 2da fila ---------------------------------%>
                        <div class="row">
                            <div class="col-md-3">
                                <label for="DdlMedico">Doctor:</label>
                                <select id="DdlMedico" class="form-control textoReducido mayus">
                                </select>
                            </div>
                            <div class="col-md-3">
                                <label for="DdlPrevision">Previsión:</label>
                                <select id="DdlPrevision" class="form-control textoReducido mayus">
                                </select>
                            </div>
                            <div class="col-md-3">
                                <label for="DdlLocalización">Localización:</label>
                                <select id="DdlLocalización" class="form-control textoReducido mayus">
                                </select>
                            </div>
                            <div class="col-md-3">
                                <label for="txtCama">Cama:</label>
                                <input id="txtCama" class="form-control textoReducido mayus" type="text" />
                            </div>
                        </div>
                        <br />
                        <%------------------------------ 3ra fila ---------------------------------%>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtObAtencion">Observación de la Atención:</label>
                                <input id="txtObAtencion" class="form-control textoReducido mayus" type="text" />
                            </div>
                            <div class="col-md-3">
                                <label for="DdlSector">Sector:</label>
                                <select id="DdlSector" class="form-control textoReducido mayus">
                                </select>
                            </div>
                            <div class="col-md-3">
                                <label for="DdlPrograma">Programa:</label>
                                <select id="DdlPrograma" class="form-control textoReducido mayus">
                                </select>
                            </div>
                        </div>
                        <button id="Btn_Actualizar_Atencion" class="btn btn-primary btn-block" style="padding: 1px;" type="submit"><i class="fa fa-fw fa-save mr-2"></i>Guardar</button>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Salir</button>
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
    <div class="card border-bar">
    <div class="card-header bg-bar">
        <h5 style="text-align: center; padding: 5px;">
            <i class="fa fa-fw fa-edit"></i>
            Editar Atención
        </h5>
    </div>
    <div class="row" style="margin-top:15px;margin-left: 0px !important;margin-right: 0px !important;">
     
        <div class="col-md mb-1">
            <label for="fecha" >Desde:</label>
            <div class='input-group date' id='Txt_Date01'>
                <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Desde..." />
                <span class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </span>
            </div>
        </div>
        <div class="col-md mb-1">
            <label for="fecha">Hasta:</label>
            <div class='input-group date' id='Txt_Date02'>
                <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Desde..." />
                <span class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </span>
            </div>
        </div>
        <div class="col-md mb-1">
            <label for="Ddl_LugarTM">Lugar TM:</label>
            <select id="Ddl_LugarTM" class="form-control">
            </select>
            
        </div>
        <div class="col-md-2 mb-1">
            <br class="mb-1"/>
            <button  id="Btn_Buscar" class="btn btn-buscar btn-block mt-1 mb-1" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
        </div>   
     
    </div>
   
    <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
    <div class="row" id="Id_Conte" style="margin-left: 1px; width: 100%;">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div class="row" id="Paciente">
                <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list"></i>Datos de la Atención</h5>
                <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>
         </div>
</asp:Content>
