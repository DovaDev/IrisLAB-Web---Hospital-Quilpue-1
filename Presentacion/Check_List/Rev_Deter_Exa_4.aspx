<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Rev_Deter_Exa_4.aspx.vb" Inherits="Presentacion.Rev_Deter_Exa_4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
    <script src="/js/IrisLabResourses.js"></script>
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script>

        ID_ATE_RES_GLOBAL = 0;
        ID_USER_GLOBAL = 0;

        $(document).ready(function () {
            $("#Id_Conte").hide();
              
            $("#Btn_Actualizar_Atencion").click(() => {
                ID_USER_GLOBAL = Galletas.getGalleta("ID_USER");
                
                if (ID_ATE_RES_GLOBAL == 0 || ID_USER_GLOBAL == 0) {
                    $("#mError_AAH h4").text("Recargue");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Debe Recargar la página.");
                    $("#mError_AAH").modal();
                } else if ($("#DdlTpAviso").val() == 0 || $("#lblCausa").val() == "" || $("#lblAvisado").val() == "") {
                    $("#mError_AAH h4").text("Ingrese");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Debe seleccionar un tipo de aviso e ingresar CAUSA y AVISADO A.");
                    $("#mError_AAH").modal();
                }else {
                    IRIS_WEBF_GRABA_DET_VALORES_CRITICOS_DESCRIPCION();
                }

            });

            $("#Btn_Agregar_Deter").click(() => {
            
                if ($("#Ddl_Exam").val() != 0) {
                    Ajax_Det();
                } else {
                    $("#mError_AAH h4").text("Seleccione");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor seleccione un examen.");
                    $("#mError_AAH").modal();
                }

            });


            $("#Btn_Cargados").click(function () {
                selected = new Array();
                $("input:checkbox:checked").each(function () {
                    selected.push($(this).val());
                });
                if (selected == "" || selected == 0) {
                    $("#mError_AAH h4").text("Sin Selección");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("No se ha seleccionado ninguna determinación.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_DataTable();
                }
            });


            Ajax_Exam();
            Ajax_tp_aviso();
            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input").val(dateNow);
            //$("#Txt_Date01 input").val("12-08-2019");
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
            //$("#Txt_Date02 input").val("12-08-2019");
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

            $(".block_wait").fadeOut(0);
            $("#Div_Tabla").empty();
            $("#Div_Tabla").show();
            $("#Id_Conte").hide();

            $("#Btn_Excel").click(function () {
                Ajax_Excel();
            });
            

            $("#Btn_Marcar").click(function () {
                //$("#Btn_Marcar").hide();
                //$("#Btn_Desmarcar").show();
                $(".checkbox-success input").prop('checked', true);

            });

            $("#Btn_Desmarcar").click(function () {
                //$("#Btn_Desmarcar").hide();
                //$("#Btn_Marcar").show();
                $(".checkbox-success input").prop('checked', false);
            });

            $("#Btn_Marcar2").click(function () {
                //$("#Btn_Marcar").hide();
                //$("#Btn_Desmarcar").show();
                $(".checkbox-success2 input").prop('checked', true);

            });

            $("#Btn_Desmarcar2").click(function () {
                //$("#Btn_Desmarcar").hide();
                //$("#Btn_Marcar").show();
                $(".checkbox-success2 input").prop('checked', false);
            });

        });
    </script>
    <script>
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
                "url": "Rev_Deter_Exa_4.aspx/Llenar_Ddl_Exam",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Exam = JSON.parse(json_receiver);
                        Fill_Ddl_Exam();
                        Ajax_Det();
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
        //------------------------------------------------ AJAX Ddl_Det -------------------------------------------|
        var Mx_Dtt_Det = [
    {
        "ID_CODIGO_FONASA": 0,
        "CF_COD": 0,
        "PRU_DESC": 0,
        "ID_PRUEBA": 0,
        "CF_DESC": 0,
        "ID_ESTADO": 0
    }
        ];
        function Ajax_Det() {

            var Data_Par = JSON.stringify({
                "ID_CF": $("#Ddl_Exam").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_4.aspx/Llenar_Ddl_Det",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Det = JSON.parse(json_receiver);

                        $("#Div_Tabla_Examenes").empty();

                        Fill_Ddl_Det();
                        Hide_Modal();

                    } else {

                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();

                }
            });
        }

        //------------------------------------------------ AJAX DDL TP AVISO -------------------------------------------|
        var Mx_Dtt_tp_aviso = [
        {
            ID_TP_CRITICO: 0,
            TP_CRITICO_COD: "",
            TP_CRITICO_DESC: "",
            ID_ESTADO: 0
        }
            ];
        function Ajax_tp_aviso() {

            $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_4.aspx/Llenar_Ddl_tp_aviso",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_tp_aviso = JSON.parse(json_receiver);

                        Fill_Ddl_tp_aviso();
                        Hide_Modal();

                    } else {

                        Hide_Modal();
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
        //-------------------------------------------------- AJAX TABLA MAIN ----------------------------------------------|
        var Mx_Dtt = [
            {
                "ID_ATENCION": 0,
                "ATE_NUM": 0,
                "ATE_FECHA": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "CF_DESC": 0,
                "CF_COD": 0,
                "ATE_AÑO": 0,
                "PRU_DESC": 0,
                "ATE_RESULTADO": 0,
                "ATE_RESULTADO_NUM": 0,
                "ID_CODIGO_FONASA": 0,
                "ID_PRUEBA": 0,
                "ID_ATE_RES":0,
                "PAC_FNAC": 0,
                "ID_SEXO": 0,
                "UM_DESC": 0,
                "ID_TP_RESULTADO": 0,
                "TP_RESUL_DESC": 0,
                "TP_RESUL_COD": 0,
                "ID_U_MEDIDA": 0,
                "ATE_RR_DESDE": 0,
                "ATE_R_DESDE": 0,
                "ATE_R_HASTA": 0,
                "ATE_RR_HASTA": 0,
                "PRU_DECIMAL": 0,
                "PROC_DESC": 0,
                "ATE_NUM_INTERNO": 0,
                "ATE_DNI": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "id_proce":0,
                "NAC_DESC": 0,
                "PROGRA_DESC": 0,
                "SECTOR_DESC": 0
            }
        ];
        function Ajax_DataTable() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_CF": $("#Ddl_Exam").val(),
                "MUESTRA": selected
            });
           
            $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_4.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
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
                        Fill_DataTable();
                        Hide_Modal();

                        $("#Id_Conte").show();
                    } else {

                        Hide_Modal();
                        $("#Id_Conte").hide();
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
        function Ajax_DataTable_Det_Ate(ID_ATE) {

            var Data_Par = JSON.stringify({
                "ID_ATE": ID_ATE
            });
            //$(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_4.aspx/Llenar_DataTable_Det_Ate",
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
                        $('#numerito').text("N° Atención: " + Mx_Dtt_Det_Ate[0].NUM_ATE);
                        $('#nombrecito').text("Nombre: " + Mx_Dtt_Det_Ate[0].PAC_NOMBRE + " " + Mx_Dtt_Det_Ate[0].PAC_APELLIDO).addClass("text-uppercase");
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

        //-----------------------------------------------DETALLE ATENCION---------------------------------------|
        var Mx_Dtt_Click_1 = [
          {
              PAC_NOMBRE: "",
              PAC_APELLIDO: "",
              PRU_DESC: "",
              CF_DESC: "",
              ATE_AÑO: "",
              ID_PACIENTE: 0,
              ATE_NUM: "",
              ATE_FECHA: new Date,
              ATE_RESULTADO: "",
              ID_ATENCION: 0,
              ATE_RESULTADO_NUM: "",
              ATE_RR_DESDE: "",
              ATE_RR_HASTA: "",
              ATE_RR_ALTOBAJO: "",
              ATE_R_DESDE: "",
              ATE_R_HASTA: "",
              ATE_RESULTADO_ALT: "",
              PROC_DESC: "",
              ORD_DESC: "",
              ATE_EST_VALIDA: "",
              ID_CODIGO_FONASA: 0,
              ID_ATE_RES: 0,
              ID_DET_CRITICO: 0,
              ID_ATE_RES: 0,        //2
              ID_USUARIO: 0,
              DET_CRITICO_FECHA: new Date,
              DET_CRITICO_DESC: "",
              ID_ESTADO: 0,
              ID_TP_CRITICO: 0,
              TP_CRITICO_DESC: "",
              USU_NIC: "",
              EST_DESCRIPCION: "",
              DET_CRITICO_FECHA_MANUAL: new Date
          }
                ];
        function Ajax_DataTable_Click_1(ID_ATE_RES) {
            
            ID_ATE_RES_GLOBAL = ID_ATE_RES;

            var Data_Par = JSON.stringify({
                "ID_ATE_RES": ID_ATE_RES
            });
            $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_4.aspx/IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt_Click_1 = JSON.parse(json_receiver);

                        for (i = 0; i < Mx_Dtt_Click_1.length; ++i) {
                            var date_x = Mx_Dtt_Click_1[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");
                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Click_1[i].ATE_FECHA = Date_Change;
                        }
                        
                        $("#DataTable_click_1").empty();
                        $("#DataTable_click_Log").empty();
                        
                        Ajax_DataTable_Click_2(ID_ATE_RES);

                        //Fill_DataTable_click_1();

                    } else {

                        //$("#mError_AAH h4").text("Sin Resultados");
                        //$("#mError_AAH button").attr("class", "btn btn-danger");
                        //$("#mError_AAH p").text("No se han encontrado resultados");
                        //$("#mError_AAH").modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }

        //-----------------------------------------------DETALLE ATENCION---------------------------------------|
        var Mx_Dtt_Click_2 = [
          {
              ID_DET_CRITICO: 0,
              ID_ATE_RES: 0,
              ID_USUARIO: 0,
              DET_CRITICO_FECHA: new Date,
              DET_CRITICO_DESC: "",
              ID_ESTADO: 0,
              ID_TP_CRITICO: 0,
              TP_CRITICO_DESC: "",
              USU_NIC: "",
              EST_DESCRIPCION: "",
              DET_CRITICO_FECHA_MANUAL: new Date,
              DET_CRITICO_CAUSA: ""
          }
        ];
        function Ajax_DataTable_Click_2(ID_ATE_RES) {

            var Data_Par = JSON.stringify({
                "ID_ATE_RES": ID_ATE_RES
            });
            $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_4.aspx/IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt_Click_2 = JSON.parse(json_receiver);

                        for (i = 0; i < Mx_Dtt_Click_2.length; ++i) {
                            var date_x = Mx_Dtt_Click_2[i].DET_CRITICO_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");
                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Click_2[i].DET_CRITICO_FECHA = Date_Change;
                        }

                        $("#DataTable_click_1").empty();
                        $("#DataTable_click_Log").empty();

                        Fill_DataTable_click_1();

                    } else {
                        Mx_Dtt_Click_2 = 0;
                        Fill_DataTable_click_1();
                        //$("#mError_AAH h4").text("Sin Resultados");
                        //$("#mError_AAH button").attr("class", "btn btn-danger");
                        //$("#mError_AAH p").text("No se han encontrado resultados");
                        //$("#mError_AAH").modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }

        //----------------------------------------------- GRABAR ---------------------------------------|

        function IRIS_WEBF_GRABA_DET_VALORES_CRITICOS_DESCRIPCION() {
        
        
            var Data_Par = JSON.stringify({
                "ID_ATE_RES": ID_ATE_RES_GLOBAL,
                "ID_USUARIO": ID_USER_GLOBAL,
                "DET_CRITICO_DESC": ("Notificado A: " + $("#lblAvisado").val()),
                "ID_TP_CRITICO": $("#DdlTpAviso").val(),
                "FECHA": $("#Txt_Date03 input").val(),
                "CAUSA": ("Causa: " + $("#lblCausa").val())
            });
            $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_4.aspx/IRIS_WEBF_GRABA_DET_VALORES_CRITICOS_DESCRIPCION",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        $("#DataTable_click_1").empty();
                        $("#DataTable_click_Log").empty();

                        $("#eModal_Historico").modal("hide");

                        ID_ATE_RES_GLOBAL = 0;

                        $("#mError_AAH h4").text("Guardardo Exitoso");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("El registro se ha creado exitosamente.");
                        $("#mError_AAH").modal();

                    } else {

                        //$("#mError_AAH h4").text("Sin Resultados");
                        //$("#mError_AAH button").attr("class", "btn btn-danger");
                        //$("#mError_AAH p").text("No se han encontrado resultados");
                        //$("#mError_AAH").modal();
                    }
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
                "ID_CF": $("#Ddl_Exam").val(),
                "MUESTRA": selected

            });
            $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_4.aspx/Excel",
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
        function Fill_Ddl_tp_aviso() {
            $("#DdlTpAviso").empty();

            $("<option>", {"value": 0}).text("Seleccione").appendTo("#DdlTpAviso");

            for (y = 0; y < Mx_Dtt_tp_aviso.length; ++y) {

                $("<option>", {
                    "value": Mx_Dtt_tp_aviso[y].ID_TP_CRITICO
                }).text(Mx_Dtt_tp_aviso[y].TP_CRITICO_DESC).appendTo("#DdlTpAviso");

            }
        };



        //Llenar DropDownList Determinacion
        function Fill_Ddl_Det() {
            $("#Ddl_Det").empty();
            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Det");
            for (y = 0; y < Mx_Dtt_Det.length; ++y) {
              
                $("<option>", {
                    "value": Mx_Dtt_Det[y].ID_PRUEBA
                }).text(Mx_Dtt_Det[y].PRU_DESC).appendTo("#Ddl_Det");
                
            }

            $("<table>", {
                "id": "DataTable_Examenes",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Examenes");
            $("#DataTable_Examenes").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Examenes").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Examenes thead").attr("class", "cabezera");
            $("#DataTable_Examenes thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Check")
                )
            );

            for (i = 0; i < Mx_Dtt_Det.length; i++) {

                $("#DataTable_Examenes tbody").append(
                    $("<tr>", {
                        //"onclick": `Ajax_DataTable_Det_Ate("` + Mx_Dtt[i].ID_ATENCION + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>").css("text-align", "center").text(Mx_Dtt_Det[i].PRU_DESC),
                        $("<td>").css("text-align", "center").text(function () {
                            $(this).html("<div class='checkbox checkbox-success pz' style='margin-top:-10px;'><input type='checkbox' value='" + Mx_Dtt_Det[i].ID_PRUEBA + "' class='manitos2' id='Hasdasd" + i + "'/><label class='manitos2' for='Hasdasd" + i + "'></label></div>")
                        })
                    )
                );

            }

            $("#DataTable_Examenes").DataTable({
                "bSort": true,
                "iDisplayLength": 100,
                "info": false,
                "bPaginate": false,
                //"bFilter": false,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay coincidencias",
                    "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se buscó en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Buscar: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
            
            $("#Modal_Deter").modal("show");
           
        };
        //Llenar DropDownList Tipo de Examen
        function Fill_Ddl_Exam() {
            $("#Ddl_Exam").empty();
            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#Ddl_Exam");

            for (y = 0; y < Mx_Exam.length; ++y) {
                if (Mx_Exam[y].ID_CODIGO_FONASA != 682) {
                    $("<option>", {
                        "value": Mx_Exam[y].ID_CODIGO_FONASA
                    }).text(Mx_Exam[y].CF_DESC).appendTo("#Ddl_Exam");
                }
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
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha Ingreso"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Lugar TM"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Num Interno"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Nac"),
                    $("<th>", { "class": "textoReducido" }).text("Edad"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Rut Paciente"),
                    $("<th>", { "class": "textoReducido text-center" }).text("DNI"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Nacionalidad"),
                    $("<th>", { "class": "textoReducido" }).text("Programa"),
                    $("<th>", { "class": "textoReducido" }).text("Sector"),
                    $("<th>", { "class": "textoReducido" }).text("Determinación"),
                    $("<th>", { "class": "textoReducido text-center" }).text("T"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Resultado"),
                    $("<th>", { "class": "textoReducido" }).text("Médico"),
                    $("<th>", { "class": "textoReducido" }).text("Unidad"),
                    $("<th>", { "class": "textoReducido" }).text("E"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Rango Desde"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Rango Hasta"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Detalles"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Registro")
                    //$("<th>", { "class": "textoReducido text-center" }).text("Check")
                )
            );
           
            var admin = Galletas.getGalleta("P_ADMIN");

            for (i = 0; i < Mx_Dtt.length; i++) {
              
                $("#DataTable tbody").append(
                    $("<tr>", {
                        //"onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")`,
                        //"onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")`,
                        "class": "manito"
                    }).append(
                                $("<td>", {"onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")`},{ "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).css("text-align", "center").text(Mx_Dtt[i].ATE_NUM),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).css("text-align", "center").text(function () {
                                    $(this).css("cssText", "text-align:center;").text(function () {
                                        //Obtener valores
                                        var obj_date = new Date(Mx_Dtt[i].ATE_FECHA);
                                        var dd = parseInt(obj_date.getDate());
                                        var mm = parseInt(obj_date.getMonth()) + 1;
                                        var yy = parseInt(obj_date.getFullYear());

                                        if (dd < 10) { dd = "0" + dd; }
                                        if (mm < 10) { mm = "0" + mm; }

                                        return String(dd + "/" + mm + "/" + yy);

                                    });                                                                       
                                }),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).css("text-align", "center").text(Mx_Dtt[i].PROC_DESC),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).css("text-align", "center").text(Mx_Dtt[i].ATE_NUM_INTERNO),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).css("text-align", "center").text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).text(function () {
                                    $(this).text(function () {
                                        //Obtener valores
                                        var obj_date = new Date(Mx_Dtt[i].PAC_FNAC);
                                        var dd = parseInt(obj_date.getDate());
                                        var mm = parseInt(obj_date.getMonth()) + 1;
                                        var yy = parseInt(obj_date.getFullYear());

                                        if (dd < 10) { dd = "0" + dd; }
                                        if (mm < 10) { mm = "0" + mm; }

                                        return String(dd + "/" + mm + "/" + yy);

                                    });                              
                                }),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).text(Mx_Dtt[i].ATE_AÑO + " Años"),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).css("text-align", "center").text(Mx_Dtt[i].PAC_RUT),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).css("text-align", "center").text(Mx_Dtt[i].ATE_DNI),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).css("text-align", "center").text(Mx_Dtt[i].NAC_DESC),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).css("text.align", "center").text(Mx_Dtt[i].PROGRA_DESC),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).css("text-align", "center").text(Mx_Dtt[i].SECTOR_DESC),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).css("text-align", "").text(Mx_Dtt[i].PRU_DESC),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }, { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt[i].TP_RESUL_COD),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).css("text-align", "center").text(function () {
                                    if (Mx_Dtt[i].ATE_RESULTADO == "") {
                                        $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_RESULTADO_NUM);
                                    } else {
                                        $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_RESULTADO);
                                    }
                                }),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).css("text-align", "center").text(Mx_Dtt[i].DOC_NOMBRE + " " + Mx_Dtt[i].DOC_APELLIDO),

                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }, { "align": "left" }, { "class": "textoReducido" }).text(),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].UM_DESC),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }, { "align": "left" }, { "class": "textoReducido" }).text(""),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).css("text-align", "center").text((function () {
                                    if (Mx_Dtt[i].ATE_R_DESDE != "") {
                                        var dword = Mx_Dtt[i].ATE_R_DESDE;
                                        if (dword != null) {
                                            dword = dword.replace(",", ".");
                                            var dword = $re.cutDecimals(dword, Mx_Dtt[i].PRU_DECIMAL);
                                            return dword;
                                        } else {
                                            return " - ";
                                        }
                                    } else {
                                        if (dword != null) {
                                            var dword = Mx_Dtt[i].ATE_RR_DESDE;
                                            dword = dword.replace(",", ".");
                                            dword = $re.cutDecimals(dword, Mx_Dtt[i].PRU_DECIMAL);
                                            return dword;
                                        } else {
                                            return " - ";
                                        }
                                    }
                                })),
                                $("<td>", { "onclick": `Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")` }).css("text-align", "center").text((function () {
                                    if (Mx_Dtt[i].ATE_R_HASTA != "") {
                                        var dword = Mx_Dtt[i].ATE_R_HASTA;
                                        if (dword != null) {
                                            dword = dword.replace(",", ".");
                                            var dword = $re.cutDecimals(dword, Mx_Dtt[i].PRU_DECIMAL);
                                            return dword;
                                        } else {
                                            return " - ";
                                        }
                                    } else {
                                        if (dword != null) {
                                            var dword = Mx_Dtt[i].ATE_RR_HASTA;
                                            dword = dword.replace(",", ".");
                                            dword = $re.cutDecimals(dword, Mx_Dtt[i].PRU_DECIMAL);
                                            return dword;
                                        } else {
                                            return " - ";
                                        }
                                    }
                                })),
                                $("<td>", { "align": "center" }).html(`<button class='btn btn-primary' onclick='Ajax_DataTable_Det_Ate("` + Mx_Dtt[i].ID_ATENCION + `")'>Ver</button>`),
                                $("<td>", { "align": "center" }).html(`<button class='btn btn-success' onclick='Ajax_DataTable_Click_1("` + Mx_Dtt[i].ID_ATE_RES + `")'>Aviso</button>`)
                                //$("<td>").css("text-align", "center").text(function () {
                                //    $(this).html("<div class='checkbox checkbox-success2 pz' style='margin-top:-10px;'><input type='checkbox' value='" + Mx_Dtt[i].ATE_AÑO + "' class='manitos2' id='Hasdasd" + i + "'/><label class='manitos2' for='Hasdasd" + i + "'></label></div>")
                                //})
                            )
                        );
                    
            }

            $("#DataTable").DataTable({
                "bSort": true,
                "iDisplayLength": 100,
                "info": true,
                "bPaginate": true,
                //"bFilter": false,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay coincidencias",
                    "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se buscó en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Buscar: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
            
        }
        //-----------------------------------------TABLA LISTADO DE EXAMENES de la ATENCIONES   DOUBLE CLICK-------------------------------------------|
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



        //-----------------------------------------TABLA CLICK 111111111 -------------------------------------------|
        function Fill_DataTable_click_1() {
            $("<table>", {
                "id": "DataTable_click_1",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_click_1");
            $("#DataTable_click_1").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_click_1").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_click_1 thead").attr("class", "cabezera");
            $("#DataTable_click_1 thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Ate Num"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Edad"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Hora"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar TM"),
                    //$("<th>", { "class": "textoReducido" }).text("Sexo"),
                    $("<th>", { "class": "textoReducido" }).text("Determinación")
                )
            );

            for (i = 0; i < Mx_Dtt_Click_1.length; i++) {
                $("#DataTable_click_1 tbody").append(
                    $("<tr>", {
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Click_1[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Click_1[i].PAC_NOMBRE + " " + Mx_Dtt_Click_1[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Click_1[i].ATE_AÑO + " Años"),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Click_1[i].ATE_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());
                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }
                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date2 = new Date(Mx_Dtt_Click_1[i].ATE_FECHA);
                            var hh = parseInt(obj_date2.getHours());
                            var mm = parseInt(obj_date2.getMinutes());
                            var ss = parseInt(obj_date2.getSeconds());
                            if (hh < 10) { hh = "0" + hh; }
                            if (mm < 10) { mm = "0" + mm; }
                            if (ss < 10) { ss = "0" + ss; }
                            return String(hh + ":" + mm);
                        }),
                        
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Click_1[i].PROC_DESC),
                        //$("<td>", { "align": "left" }, { "class": "textoReducido" }).text(""),                            //SEXO 
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Click_1[i].PRU_DESC)
                    )
                );
                $("<tr>").attr("id", i + 1);
            }


            //------------------------------------------------ TABLA LOG ----------------------------------------------------------------------

            $("<table>", {
                "id": "DataTable_click_Log",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Log_Registros");
            $("#DataTable_click_Log").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_click_Log").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_click_Log thead").attr("class", "cabezera");
            $("#DataTable_click_Log thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Tipo de Aviso"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario"),
                    $("<th>", { "class": "textoReducido" }).text("Estado"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción")
                )
            );

            for (i = 0; i < Mx_Dtt_Click_2.length; i++) {
                $("#DataTable_click_Log tbody").append(
                    $("<tr>", {
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Click_2[i].DET_CRITICO_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            var obj_date2 = new Date(Mx_Dtt_Click_2[i].DET_CRITICO_FECHA);
                            var hh = parseInt(obj_date2.getHours());
                            var mmm = parseInt(obj_date2.getMinutes());
                            var ss = parseInt(obj_date2.getSeconds());

                            if (hh < 10) { hh = "0" + hh; }
                            if (mmm < 10) { mmm = "0" + mmm; }
                            if (ss < 10) { ss = "0" + ss; }

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy + " " + hh + ":" + mmm);
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Click_2[i].TP_CRITICO_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Click_2[i].USU_NIC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Click_2[i].EST_DESCRIPCION),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Click_2[i].DET_CRITICO_CAUSA)
                    )
                );
                $("<tr>").attr("id", i + 1);
            }

            $("#DdlTpAviso").val(0);
            $("#lblCausa").val("");
            $("#lblAvisado").val("");

            $("#eModal_Historico").modal("show");
        };
        

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
        <div class="modal fade" id="eModal_Historico" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" style="text-align:center">Registro de información de valores críticos</h4>
                </div>
                <div class="modal-body">
                    <div id="Div_Tabla_click_1" style="width: 100%;" class="table-responsive"></div>
                    <h4>Log de registros informados</h4>
                    <div id="Div_Log_Registros" style="width: 100%;" class="table-responsive"></div>
                    <br />
                    <h4>Agregar Nuevo Evento Log</h4>
                    <div class="container" style="width: 100%; border: 2px;">
                        <%------------------------------ 1ra fila ---------------------------------%>
                        <div class="row">
                            <div class="col-md-4">
                                <label for="DdlTpAviso">Tipo de Aviso:</label>
                                <select id="DdlTpAviso" class="form-control textoReducido mayus">
                                </select>
                            </div>
                            <div class="col-md-4">
                                <label for="fecha">Fecha:</label>
                                <div class='input-group date' id='Txt_Date03'>
                                    <input type='text' id="fecha3" class="form-control" readonly="true" placeholder="Desde..." />
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label></label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md">
                                <label for="lblCausa">Causa:</label>
                                <textarea id="lblCausa" class="form-control" rows="5" maxlength="490"></textarea>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md">
                                <label for="lblAvisado">Avisado a:</label>
                                <input id="lblAvisado" class="form-control"/>
                            </div>
                        </div>
                        

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                    <button id="Btn_Actualizar_Atencion" class="btn btn-success" type="submit"><i class="fa fa-fw fa-save mr-2"></i>Guardar</button>
                </div>
            </div>
        </div>
    </div>













    <%--//---------------------------------------------- MODAL LISTADO DE EXÁMENES DE LA ATENCIÓN ------------------------------------%>
    <div class="modal fade" id="eModal" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Listado Exámenes de la Atención</h4>
                </div>
                <div class="modal-header">
                    <div class="col">
                        <h6 class="modal-title" id="numerito">num ATEEE</h6>
                        <h6 class="modal-title" id="nombrecito">Nombreee</h6>
                    </div>
                </div>
                <div class="modal-body">
                    <form>
                        <div id="Div_Tabla_Listado_Exa_Ate" style="width: 100%;" class="table-responsive"></div>
                    </form>
                </div>
                <div class="modal-footer">
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

        <div id="Modal_Deter" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Seleccione Determinaciones</h4>
                </div>
                <div class="modal-body">
                    <div>
                        <div id="Div_Tabla_Examenes" style="width: 100%;" class="highlights"></div>
                    </div>
                </div>
                <div class="modal-footer">
                     <button id="Btn_Marcar" class="btn btn-dark" type="submit"><i class="fa fa-fw fa-check mr-2"></i>Marcar Todos</button>
                     <button id="Btn_Desmarcar" class="btn btn-dark" type="submit"><i class="fa fa-fw fa-remove mr-2"></i>Desmarcar Todos</button>        
                    <%--<button type="button" id="Btn_Excel" class="btn btn-print"><i class="fa fa-fw fa-file-excel-o mr-2"></i> Excel</button>--%>
                    <button type="button" class="btn btn-danger" style="margin-left:120px" data-dismiss="modal">Cerrar</button>
                    <button type="button" id="Btn_Cargados" class="btn btn-success" data-dismiss="modal">Buscar</button>
                </div>
            </div>
        </div>
    </div>
    <%------------------------------------------------------TÍTULO, TEXTBOX Y BOTONES-----------------------------------------%>
    <div class="row">
        <div class="col-lg">
            <div class="card mb-3">
                <div class="card-header bg-bar">
        <h5 style="text-align: center; padding: 5px;">
            <i class="fa fa-edit"></i>
            Listado de exámenes con Resultados
        </h5>
    </div>
    <div class="row mb" style="margin-left:2px; margin-right: 2px;">
        <div class="col-md-3">
            <label for="fecha">Desde:</label>
            <div class='input-group date' id='Txt_Date01'>
                <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Desde..." />
                <span class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </span>
            </div>
        </div>
        <div class="col-md-3">
            <label for="fecha">Hasta:</label>
            <div class='input-group date' id='Txt_Date02'>
                <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Desde..." />
                <span class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </span>
            </div>
        </div>
<%--        <div class="col-md-3">
            <label for="Ddl_Det">Determinación:</label>
            <select id="Ddl_Det" class="form-control">
                <option value="0">Seleccionar</option>
            </select>
        </div>--%>
        <div class="col-md-2">
            <label>Examen</label>
            <select id="Ddl_Exam" class="form-control">
                <option value="0">Seleccionar</option>
            </select>
        </div>
        <div class="col-md-2">
            <label>Determinación</label>
            <br />
            <button id="Btn_Agregar_Deter" class="btn btn-info" type="submit"><i class="fa fa-fw fa-plus-circle"></i> Opciones</button> 
        </div>
<%--        <div class="col-md-2">
            <label>Aviso</label>
            <br />
            <button id="Btn_Agregar_Detasdasdasdasasd" class="btn btn-warning" type="submit"><i class="fa fa-fw fa-plus-circle"></i> Notificar</button> 
        </div>--%>
    </div>
       <div class="row" style="margin-left:2px; margin-right: 2px;">
        <div class="col-md">
            <%--<button id="Btn_Buscar" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i> Buscar</button>--%>
        </div>

<%--           <button id="Btn_Marcar2" class="btn btn-dark btn-block" style="margin-bottom: 1vh; padding: 3px; border: 1px;" type="submit"><i class="fa fa-fw fa-check mr-2"></i>Marcar Todos</button>
            <button id="Btn_Desmarcar2" class="btn btn-dark btn-block" style="margin-bottom: 1vh; padding: 3px; border: 1px;" type="submit"><i class="fa fa-fw fa-remove mr-2"></i>Desmarcar Todos</button>--%>
    </div>
    <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
    <div class="row" id="Id_Conte">
        <div class="col-md-12" id="Paciente">
            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i>Listado de Determinaciones</h5>
            <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
        </div>
    </div>
    </div>
    </div>
    </div>
</asp:Content>