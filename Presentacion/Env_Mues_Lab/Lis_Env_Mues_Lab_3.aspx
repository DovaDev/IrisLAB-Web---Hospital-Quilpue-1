<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Lis_Env_Mues_Lab_3.aspx.vb" Inherits="Presentacion.Lis_Env_Mues_Lab_3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script src="/js/moment_es.js"></script>
    <script src="/js/moment.js"></script>

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

        let num_envio_Master = 0;
        $(document).ready(function () {
            $("#Id_Conte").hide();
            //Ajax_LugarTM();
            //Ajax_Exam();
            Ajax_Ver_Lotes_Anteriores();
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
  
            $("#Btn_Buscar").click(function () {
                Ajax_Ver_Lotes_Anteriores_Fecha();
            });
   
            $("#Btn_Excel").click(function () {
                if (num_envio_Master == 0) {
                    $("#mError_AAH h4").text("Seleccione Lote");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione un Lote para realizar la búsqueda.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_Excel();
                } 
            });

            $("#Btn_Imprimir").click(function () {
                if (num_envio_Master == 0) {
                    $("#mError_AAH h4").text("Seleccione Lote");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione un Lote para realizar la búsqueda.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_PDF();
                }
            });

            $("#Btn_Lote").click(function (){
                Ajax_Ver_Lotes_Anteriores();
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
                "url": "Lis_Env_Mues_Lab_2.aspx/Llenar_Ddl_LugarTM",
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
                "url": "Lis_Env_Mues_Lab_2.aspx/Llenar_Ddl_Exam",
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
        //-------------------------------------------------- VER LOTES ANTERIORES ------------------------------------------------------|
        var Mx_Dtt_Lotes_Anteriores = [
            {
                "ENVIO_NUM": 0,
                "ID_USUARIO": 0,
                "ENVIO_FECHA": 0,
                "USU_NIC": 0
            }
        ];

        function Ajax_Ver_Lotes_Anteriores() {

            $.ajax({
                "type": "POST",
                "url": "Lis_Env_Mues_Lab_3.aspx/IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Lotes_Anteriores = json_receiver;
                        Hide_Modal();

                        $('#eModalLotesAnteriores').modal('hide');
                        $('#eModalLotesAnteriores').modal('show');
                        $("#Div_Tabla_Lotes_Anteriores").empty();

                        for (i = 0; i < Mx_Dtt_Lotes_Anteriores.length; ++i) {
                            var date_x = Mx_Dtt_Lotes_Anteriores[i].ENVIO_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Lotes_Anteriores[i].ENVIO_FECHA = Date_Change;
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

        //-------------------------------------------------- VER LOTES ANTERIORES ------------------------------------------------------|
        function Ajax_Ver_Lotes_Anteriores_Fecha() {

            var Data_Par = JSON.stringify({
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "NLOTE": $("#TxtNLote").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Lis_Env_Mues_Lab_3.aspx/IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO_POR_FECHA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Lotes_Anteriores = json_receiver;
                        Hide_Modal();

                        $('#eModalLotesAnteriores').modal('hide');
                        $('#eModalLotesAnteriores').modal('show');
                        $("#Div_Tabla_Lotes_Anteriores").empty();

                        for (i = 0; i < Mx_Dtt_Lotes_Anteriores.length; ++i) {
                            var date_x = Mx_Dtt_Lotes_Anteriores[i].ENVIO_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Lotes_Anteriores[i].ENVIO_FECHA = Date_Change;
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
        var Mx_Dtt_Muestras_Lotes = {
            List_Data: [
                {
                    "ENVIO_NUM": 0,
                    "ID_ATENCION": 0,
                    "ENVIO_ETI_CURVA": 0,
                    "ENVIO_ETI_NUM_ATE": 0,
                    "ID_USUARIO": 0,
                    "ENVIO_ETI_FECHA": 0,
                    "ID_ENVIO": 0,
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
                    "USU_NIC": 0,
                    "ATE_NUM_INTERNO": 0,
                    "ATE_NUM": 0,
                    "ATE_FECHA": 0,
                    "ATE_OBS_TM": 0,
                    "PAC_RUT": 0,
                    "PAC_DNI": 0
                }
            ],
            Dictionary: {
                "Aaaahhh": 213543
            }
        };
        function Ajax_Muestras_Lotes(NUMLOTE) {
            num_envio_Master = NUMLOTE;
            modal_show();

            var Data_Par = JSON.stringify({
                "NUMLOTE": NUMLOTE
            });
            $.ajax({
                "type": "POST",
                "url": "Lis_Env_Mues_Lab_3.aspx/IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.List_Data.length > 0) {
                        Mx_Dtt_Muestras_Lotes = json_receiver;
                        Hide_Modal();

                        $("#lote_nummmmm").text(Mx_Dtt_Muestras_Lotes.List_Data[0].ENVIO_NUM);
                        $("#Div_Totales").empty();
                        $("#DataTable_Muestras_Por_Lotes").empty();
                        $('#eModalLotesAnteriores').modal('hide');
                        //$('#eModal_Muestras_Por_Lotes').modal('hide');
                        //$('#eModal_Muestras_Por_Lotes').modal('show');

                        for (i = 0; i < Mx_Dtt_Muestras_Lotes.length; ++i) {
                            var date_x = Mx_Dtt_Muestras_Lotes.List_Data[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Muestras_Lotes.List_Data[i].ATE_FECHA = Date_Change;
                        }

                        Fill_DataTable_Muestras_Por_Lotes();
                        $("#Id_Conte").show();
                    } else {

                        $("#DataTable_Muestras_Por_Lotes").empty();
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

        var Mx_Dtt_Excel = [
            {
                "urls": ""
            }
        ];

        function Ajax_Excel() {
            modal_show();


            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "NUMLOTE": num_envio_Master
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_Env_Mues_Lab_3.aspx/Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    let xURL = "";
                    xURL = resp.d;

                    if (xURL != null) {
                        if (xURL.match(/^http(s?):\/\//gi) == null) {
                            xURL = "http://" + xURL;
                        }

                        var xMsg = `<p>Se ha generado correctamente el archivo excel. `;
                        xMsg += `Si no se ha iniciado la descarga pulse <a href="${xURL}">aquí</a>.</p>`;
                        $("#mdlExcel .modal-body").html(xMsg);

                        window.open(xURL, "_blank");
                    } else {
                        var xMsg = `<p>No se ha generado ningún archivo debido a que la `;
                        xMsg += `búsqueda no retorna resultados.</p>`;
                        $("#mdlExcel .modal-body").html(xMsg);
                    }

                    $("#mdlExcel").modal();
                    Hide_Modal();
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        var Mx_Dtt_PDF = [
{
    "urls": ""
}
        ];

        function Ajax_PDF() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "NUMLOTE": num_envio_Master
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_Env_Mues_Lab_3.aspx/PDFF",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    let xURL = "";
                    xURL = resp.d;

                    if (xURL != null) {
                        if (xURL.match(/^http(s?):\/\//gi) == null) {
                            xURL = "http://" + xURL;
                        }

                        var xMsg = `<p>Se ha generado correctamente el archivo PDF. `;
                        xMsg += `Si no se ha iniciado la descarga pulse <a href="${xURL}">aquí</a>.</p>`;
                        $("#mdlExcel .modal-body").html(xMsg);

                        window.open(xURL, "_blank");
                    } else {
                        var xMsg = `<p>No se ha generado ningún archivo debido a que la `;
                        xMsg += `búsqueda no retorna resultados.</p>`;
                        $("#mdlExcel .modal-body").html(xMsg);
                    }

                    $("#mdlExcel").modal();
                    Hide_Modal();
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
        function Fill_Ddl_LugarTM() {
            $("#Ddl_LugarTM").empty();

            $("#Ddl_LugarTM").empty();

            var procee = Galletas.getGalleta("USU_TM");

            if (procee == 0) {
                $("<option>",
                {
                    "value": "0"
                }
                ).text("Todos").appendTo("#Ddl_LugarTM");
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
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("N° Lote")
                )
            );

            for (i = 0; i < Mx_Dtt_Lotes_Anteriores.length; i++) {
                $("#DataTable_Lotes_Anteriores tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Muestras_Lotes("` + Mx_Dtt_Lotes_Anteriores[i].ENVIO_NUM + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Lotes_Anteriores[i].USU_NIC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Lotes_Anteriores[i].ENVIO_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido2" }).text(Mx_Dtt_Lotes_Anteriores[i].ENVIO_NUM)
                    )
                );
            }
        }
        //------------------------------------------------ TABLA MUESTRAS POR LOTES -----------------------------------------------------|
        function Fill_DataTable_Muestras_Por_Lotes() {
            let super_contador = 0;

            $("<table>", {
                "id": "DataTable_Totales",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Totales");

            $("#DataTable_Totales").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Totales").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Totales thead").attr("class", "cabezera");
            $("#DataTable_Totales thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Etiqueta"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Total")

                )
            );

            for (var leKey in Mx_Dtt_Muestras_Lotes.Dictionary) {
                $("#DataTable_Totales tbody").append(
                    $("<tr>").append(
                        $("<td>", { class: "textoReducido" }).text(leKey),
                        $("<td>", { class: "textoReducido text-center" }).text(Mx_Dtt_Muestras_Lotes.Dictionary[leKey])
                    )
                );

                super_contador += Mx_Dtt_Muestras_Lotes.Dictionary[leKey]

            }
            $("#DataTable_Totales tbody").append(
                    $("<tr>").append(
                        $("<td>", { class: "textoReducido negrin" }).text("TOTAL"),
                        $("<td>", { class: "textoReducido text-center negrin" }).text(super_contador)
                    )
                );


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
                    $("<th>", { "class": "textoReducido" }).text("Nº Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Nº Interno"),
                    $("<th>", { "class": "textoReducido" }).text("Rut/DNI"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Edad"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Envío"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar TM"),
                    $("<th>", { "class": "textoReducido" }).text("Etiqueta"),
                    //$("<th>", { "class": "textoReducido" }).text("Examen Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("Estado"),
                    $("<th>", { "class": "textoReducido" }).text("N° Lote"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario"),
                    $("<th>", { "class": "textoReducido" }).text("Observación")
                )
            );


            let xi = 0;
            let indexx = 1;
            for (i = 0; i < Mx_Dtt_Muestras_Lotes.List_Data.length; i++) {
                if (xi == 0) {
                    $("#DataTable_Muestras_Por_Lotes tbody").append(
                        $("<tr>").append(
                            $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(indexx),
                            $("<td>", { "align": "center" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes.List_Data[i].ATE_NUM),
                            $("<td>", { "align": "center" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes.List_Data[i].ATE_NUM_INTERNO),
                            $("<td>", { "align": "center" }, { "class": "textoReducido2" }).text(function () {
                                var wasa;
                                if (Mx_Dtt_Muestras_Lotes.List_Data[i].PAC_RUT == "") {
                                    wasa = Mx_Dtt_Muestras_Lotes.List_Data[i].PAC_DNI;
                                    return wasa;
                                } else {
                                    wasa = Mx_Dtt_Muestras_Lotes.List_Data[i].PAC_RUT;
                                    return wasa;
                                }
                            }),
                            $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes.List_Data[i].PAC_NOMBRE + " " + Mx_Dtt_Muestras_Lotes.List_Data[i].PAC_APELLIDO),
                            $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes.List_Data[i].ATE_AÑO + " " + "Años"),
                            $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(moment(Mx_Dtt_Muestras_Lotes.List_Data[i].ATE_FECHA).format("DD/MM/YYYY HH:mm:ss")),
                            $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(moment(Mx_Dtt_Muestras_Lotes.List_Data[i].ENVIO_ETI_FECHA).format("DD/MM/YYYY HH:mm:ss")),
                            $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes.List_Data[i].PROC_DESC),
                            $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text("[" + Mx_Dtt_Muestras_Lotes.List_Data[i].CB_DESC + "]" + " - " + Mx_Dtt_Muestras_Lotes.List_Data[i].T_MUESTRA_DESC),
                            //$("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].CF_DESC),
                            $("<td>").css("text-align", "center").text(function () {
                                if (Mx_Dtt_Muestras_Lotes.List_Data[i].EST_DESCRIPCION == "ENVIADO") {
                                    $(this).css("cssText", "background-color: #88d6e2 !important; cursor:pointer; text-align:center;").text(Mx_Dtt_Muestras_Lotes.List_Data[i].EST_DESCRIPCION);
                                }
                                else {
                                    $(this).css("cssText", "background-color:#f5b0e5 !important; text-align:center;").text(Mx_Dtt_Muestras_Lotes.List_Data[i].EST_DESCRIPCION);
                                }
                            }),
                            //$("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].ENVIO_ETI_NUM_ATE),
                            $("<td>", { "align": "center" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes.List_Data[i].ENVIO_NUM),
                            $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes.List_Data[i].USU_NIC),
                            $("<td>", { "align": "center" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes.List_Data[i].ATE_OBS_TM)
                            //$("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].RLS_LS_DESC),
                        )
                    );
                    indexx++;
                } else if ((((xi > 0) && (Mx_Dtt_Muestras_Lotes.List_Data[xi].CB_DESC != Mx_Dtt_Muestras_Lotes.List_Data[xi - 1].CB_DESC))) || Mx_Dtt_Muestras_Lotes.List_Data[xi].ATE_NUM != Mx_Dtt_Muestras_Lotes.List_Data[xi - 1].ATE_NUM || Mx_Dtt_Muestras_Lotes.List_Data[xi].T_MUESTRA_DESC != Mx_Dtt_Muestras_Lotes.List_Data[xi - 1].T_MUESTRA_DESC) {
                    $("#DataTable_Muestras_Por_Lotes tbody").append(
                        $("<tr>").append(
                            $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(indexx),
                            $("<td>", { "align": "center" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes.List_Data[i].ATE_NUM),
                            $("<td>", { "align": "center" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes.List_Data[i].ATE_NUM_INTERNO),
                            $("<td>", { "align": "center" }, { "class": "textoReducido2" }).text(function () {
                                var wasa;
                                if (Mx_Dtt_Muestras_Lotes.List_Data[i].PAC_RUT == "") {
                                    wasa = Mx_Dtt_Muestras_Lotes.List_Data[i].PAC_DNI;
                                    return wasa;
                                } else {
                                    wasa = Mx_Dtt_Muestras_Lotes.List_Data[i].PAC_RUT;
                                    return wasa;
                                }
                            }),
                            $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes.List_Data[i].PAC_NOMBRE + " " + Mx_Dtt_Muestras_Lotes.List_Data[i].PAC_APELLIDO),
                            $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes.List_Data[i].ATE_AÑO + " " + "Años"),
                            $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(moment(Mx_Dtt_Muestras_Lotes.List_Data[i].ATE_FECHA).format("DD/MM/YYYY HH:mm:ss")),
                            $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(moment(Mx_Dtt_Muestras_Lotes.List_Data[i].ENVIO_ETI_FECHA).format("DD/MM/YYYY HH:mm:ss")),
                            $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes.List_Data[i].PROC_DESC),
                            $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text("[" + Mx_Dtt_Muestras_Lotes.List_Data[i].CB_DESC + "]" + " - " + Mx_Dtt_Muestras_Lotes.List_Data[i].T_MUESTRA_DESC),
                            //$("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].CF_DESC),
                            $("<td>").css("text-align", "center").text(function () {
                                if (Mx_Dtt_Muestras_Lotes.List_Data[i].EST_DESCRIPCION == "ENVIADO") {
                                    $(this).css("cssText", "background-color: #88d6e2 !important; cursor:pointer; text-align:center;").text(Mx_Dtt_Muestras_Lotes.List_Data[i].EST_DESCRIPCION);
                                }
                                else {
                                    $(this).css("cssText", "background-color:#f5b0e5 !important; text-align:center;").text(Mx_Dtt_Muestras_Lotes.List_Data[i].EST_DESCRIPCION);
                                }
                            }),
                            //$("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].ENVIO_ETI_NUM_ATE),
                            $("<td>", { "align": "center" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes.List_Data[i].ENVIO_NUM),
                            $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes.List_Data[i].USU_NIC),
                            $("<td>", { "align": "center" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes.List_Data[i].ATE_OBS_TM)
                            //$("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].RLS_LS_DESC),
                        )
                    );
                    indexx++;
                }
                xi++;
            }
        }
        //---------------------------------------------------- TABLA  ------------------------------------------------------------------|
        function Fill_DataTable() {
            let super_contador = 0;

            $("<table>", {
                "id": "DataTable_Totales",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Totales");

            $("#DataTable_Totales").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Totales").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Totales thead").attr("class", "cabezera");
            $("#DataTable_Totales thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido"}).text("Etiqueta"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Total")

                )
            );

            for (var leKey in Mx_Dtt.Dictionary) {
                $("#DataTable_Totales tbody").append(
                    $("<tr>").append(
                        $("<td>", { class: "textoReducido" }).text(leKey),
                        $("<td>", { class: "textoReducido text-center" }).text(Mx_Dtt.Dictionary[leKey])
                    )
                );

                super_contador += Mx_Dtt.Dictionary[leKey]

            }
            $("#DataTable_Totales tbody").append(
                    $("<tr>").append(
                        $("<td>", { class: "textoReducido negrin" }).text("TOTAL"),
                        $("<td>", { class: "textoReducido text-center negrin" }).text(super_contador)
                    )
                );

            //-----------------------------------------------------------------------------------------------------------------------

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
                    $("<th>", { "class": "textoReducido text-center" }).text("#"),
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Interno"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Edad"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Hora"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar de TM"),
                    $("<th>", { "class": "textoReducido" }).text("Etiqueta"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Estado"),
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Lote"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Usuario"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Observacíon")

                )
            );
            let xi = 0;
            let cantidad = 0;
            let indexx = 1;
            for (i = 0; i < Mx_Dtt.List_Data.length; i++) {
                if (xi == 0) {
                    cantidad++;
                    $("#DataTable tbody").append(
                        $("<tr>").append(
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(indexx),
                            $("<td>").css("text-align", "center").text(function () {
                                if (i > 0){
                                    if (Mx_Dtt.List_Data[i-1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    }else {
                                        $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_NUM);
                                    }
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_NUM);
                                }
                            }),
                            $("<td>").css("text-align", "center").text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_NUM_INTERNO);
                                    }
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_NUM_INTERNO);
                                }
                            }),
                            $("<td>").text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).text(Mx_Dtt.List_Data[i].PAC_NOMBRE + " " + Mx_Dtt.List_Data[i].PAC_APELLIDO);
                                    }

                                } else {
                                    $(this).text(Mx_Dtt.List_Data[i].PAC_NOMBRE + " " + Mx_Dtt.List_Data[i].PAC_APELLIDO);
                                }
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).text(Mx_Dtt.List_Data[i].ATE_AÑO + " Años");
                                    }

                                } else {
                                    $(this).text(Mx_Dtt.List_Data[i].ATE_AÑO + " Años");
                                }
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        //Obtener valores
                                        var obj_date = new Date(Mx_Dtt.List_Data[i].ATE_FECHA);
                                        var dd = parseInt(obj_date.getDate());
                                        var mm = parseInt(obj_date.getMonth()) + 1;
                                        var yy = parseInt(obj_date.getFullYear());

                                        if (dd < 10) { dd = "0" + dd; }
                                        if (mm < 10) { mm = "0" + mm; }

                                        return String(dd + "/" + mm + "/" + yy);
                                    }

                                } else {
                                    //Obtener valores
                                    var obj_date = new Date(Mx_Dtt.List_Data[i].ATE_FECHA);
                                    var dd = parseInt(obj_date.getDate());
                                    var mm = parseInt(obj_date.getMonth()) + 1;
                                    var yy = parseInt(obj_date.getFullYear());

                                    if (dd < 10) { dd = "0" + dd; }
                                    if (mm < 10) { mm = "0" + mm; }

                                    return String(dd + "/" + mm + "/" + yy);
                                }                            
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        //Obtener valores
                                        var obj_date2 = new Date(Mx_Dtt.List_Data[i].ATE_FECHA);
                                        var hh = parseInt(obj_date2.getHours());
                                        var mm = parseInt(obj_date2.getMinutes());
                                        var ss = parseInt(obj_date2.getSeconds());

                                        if (hh < 10) { hh = "0" + hh; }
                                        if (mm < 10) { mm = "0" + mm; }
                                        if (ss < 10) { ss = "0" + ss; }

                                        return String(hh + ":" + mm + ":" + ss);;
                                    }

                                } else {
                                    //Obtener valores
                                    var obj_date2 = new Date(Mx_Dtt.List_Data[i].ATE_FECHA);
                                    var hh = parseInt(obj_date2.getHours());
                                    var mm = parseInt(obj_date2.getMinutes());
                                    var ss = parseInt(obj_date2.getSeconds());

                                    if (hh < 10) { hh = "0" + hh; }
                                    if (mm < 10) { mm = "0" + mm; }
                                    if (ss < 10) { ss = "0" + ss; }

                                    return String(hh + ":" + mm + ":" + ss);
                                }              
                            }),
                            $("<td>").text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    }
                                    else {
                                        $(this).text(Mx_Dtt.List_Data[i].PROC_DESC);
                                    }
                                } else {
                                    $(this).text(Mx_Dtt.List_Data[i].PROC_DESC);
                                }
                            }),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("[" + Mx_Dtt.List_Data[i].CB_DESC + "]" + " - " + Mx_Dtt.List_Data[i].T_MUESTRA_DESC),
                            $("<td>").css("text-align", "center").text(function () {
                                if (Mx_Dtt.List_Data[i].EST_DESCRIPCION == "RECEP.") {
                                    $(this).css("cssText", "background-color:#f5b0e5 !important;  text-align:center;").text(Mx_Dtt.List_Data[i].EST_DESCRIPCION);
                                }
                                else {
                                    $(this).css("cssText", "background-color:#88d6e2 !important; text-align:center;").text(Mx_Dtt.List_Data[i].EST_DESCRIPCION);
                                }
                            }),
                            $("<td>").css("text-align", "center").text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ENVIO_NUM);
                                    }
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ENVIO_NUM);
                                }
                            }),
                            $("<td>").css("text-align", "center").text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].USU_NIC);
                                    }
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].USU_NIC);
                                }
                            }),
                            $("<td>").css("text-align", "center").text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_OBS_TM);
                                    }
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_OBS_TM);
                                }
                            })
                        )
                    );
                    indexx++;
                } else if ((((xi > 0) && (Mx_Dtt.List_Data[xi].CB_DESC != Mx_Dtt.List_Data[xi - 1].CB_DESC))) || Mx_Dtt.List_Data[xi].ATE_NUM != Mx_Dtt.List_Data[xi - 1].ATE_NUM) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(indexx),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_NUM);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_NUM);
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_NUM_INTERNO);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_NUM_INTERNO);
                            }
                        }),
                        $("<td>").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).text(Mx_Dtt.List_Data[i].PAC_NOMBRE + " " + Mx_Dtt.List_Data[i].PAC_APELLIDO);
                                }

                            } else {
                                $(this).text(Mx_Dtt.List_Data[i].PAC_NOMBRE + " " + Mx_Dtt.List_Data[i].PAC_APELLIDO);
                            }
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).text(Mx_Dtt.List_Data[i].ATE_AÑO + " Años");
                                }

                            } else {
                                $(this).text(Mx_Dtt.List_Data[i].ATE_AÑO + " Años");
                            }
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    //Obtener valores
                                    var obj_date = new Date(Mx_Dtt.List_Data[i].ATE_FECHA);
                                    var dd = parseInt(obj_date.getDate());
                                    var mm = parseInt(obj_date.getMonth()) + 1;
                                    var yy = parseInt(obj_date.getFullYear());

                                    if (dd < 10) { dd = "0" + dd; }
                                    if (mm < 10) { mm = "0" + mm; }

                                    return String(dd + "/" + mm + "/" + yy);
                                }

                            } else {
                                //Obtener valores
                                var obj_date = new Date(Mx_Dtt.List_Data[i].ATE_FECHA);
                                var dd = parseInt(obj_date.getDate());
                                var mm = parseInt(obj_date.getMonth()) + 1;
                                var yy = parseInt(obj_date.getFullYear());

                                if (dd < 10) { dd = "0" + dd; }
                                if (mm < 10) { mm = "0" + mm; }

                                return String(dd + "/" + mm + "/" + yy);
                            }
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    //Obtener valores
                                    var obj_date2 = new Date(Mx_Dtt.List_Data[i].ATE_FECHA);
                                    var hh = parseInt(obj_date2.getHours());
                                    var mm = parseInt(obj_date2.getMinutes());
                                    var ss = parseInt(obj_date2.getSeconds());

                                    if (hh < 10) { hh = "0" + hh; }
                                    if (mm < 10) { mm = "0" + mm; }
                                    if (ss < 10) { ss = "0" + ss; }

                                    return String(hh + ":" + mm + ":" + ss);;
                                }

                            } else {
                                //Obtener valores
                                var obj_date2 = new Date(Mx_Dtt.List_Data[i].ATE_FECHA);
                                var hh = parseInt(obj_date2.getHours());
                                var mm = parseInt(obj_date2.getMinutes());
                                var ss = parseInt(obj_date2.getSeconds());

                                if (hh < 10) { hh = "0" + hh; }
                                if (mm < 10) { mm = "0" + mm; }
                                if (ss < 10) { ss = "0" + ss; }

                                return String(hh + ":" + mm + ":" + ss);
                            }
                        }),
                        $("<td>").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                }
                                else {
                                    $(this).text(Mx_Dtt.List_Data[i].PROC_DESC);
                                }
                            } else {
                                $(this).text(Mx_Dtt.List_Data[i].PROC_DESC);
                            }
                        }),
                        //$("<td>").text(function () {
                        //    if (i > 0) {                             
                        //            $(this).text(cantidad);                         
                        //    } 
                            
                        //}),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("[" + Mx_Dtt.List_Data[i].CB_DESC + "]" + " - " + Mx_Dtt.List_Data[i].T_MUESTRA_DESC),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt.List_Data[i].EST_DESCRIPCION == "RECEP.") {
                                $(this).css("cssText", "background-color:#f5b0e5 !important;  text-align:center;").text(Mx_Dtt.List_Data[i].EST_DESCRIPCION);
                            }
                            else {
                                $(this).css("cssText", "background-color:#88d6e2 !important; text-align:center;").text(Mx_Dtt.List_Data[i].EST_DESCRIPCION);
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ENVIO_NUM);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ENVIO_NUM);
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].USU_NIC);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].USU_NIC);
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_OBS_TM);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_OBS_TM);
                            }
                        })
                    )
                );
                indexx++;
                }
                xi++;
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
        .negrin{
            font-weight: 900;
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
    <%--//---------------------------------------------- MODAL LISTADO DE EXÁMENES DE LA ATENCIÓN ------------------------------------%>
    <div class="modal fade" id="eModal" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Listado de Recepción de Exámenes por Lote</h4>
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
        <%---------------------------------------------------- MODAL MUESTRAS DE LOTE --------------------------------------------------------%>
    <div class="modal fade" id="eModal_Muestras_Por_Lotes" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document" style="width: 80vw; max-width: 80vw;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Listar Lote de Trabajo</h4>
                </div>
                <div class="modal-header">
                    <h5>N° Lote: </h5>
                    <button type="button" id="Btn_Anterior_Muestras_Lotes" class="btn btn-success fa fa-arrow-circle-o-left"></button>
                    <h5 id="lote_nummmmm"></h5>
                    <button type="button" id="Btn_Siguiente_Muestras_Lotes" class="btn btn-success fa fa-arrow-circle-o-right"></button>
                    <button type="button" id="Btn_Grupos_Muestras_Lotes" class="btn btn-info"><i class="fa fa-fw fa-eye mr-2"></i>Ver Grupos Anteriores</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Salir</button>
                </div>
                <div class="modal-body" style="overflow: auto;">
                    <h5 class="modal-title" id="numerito">Listado de Muestra Recepcionada</h5>
                    <%--<div id="Div_Muestras_Lotes" class="table-responsive" style="width: 100%; overflow: auto; max-height: 40vh;"></div>--%>
                </div>
                <div class="modal-footer">
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
        <div class="col-lg-1"></div>
        <div class="col-lg"> 
            <div class="card mb-3 border-bar">
    <div class="card-header bg-bar">
        <h5 style="text-align: center; padding: 5px;">
            <i class="fa fa-edit"></i>
            Listado de Estados de Exámenes por Lote
        </h5>
    </div>

    <div class="row mb-3" style="margin-left:2px; margin-right: 2px;">
        <div class="col-md">
            <label for="fecha">N° Lote:</label>
                <input type='text' id="TxtNLote" class="form-control" onkeydown="return jsDecimals(event);"/>
        </div>
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
    </div>
    <div class="row" style="margin-left:2px; margin-right: 2px;">
        <div class="col-md">
            <button id="Btn_Buscar" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i> Buscar</button>
        </div>
        <div class="col">
            <button id="Btn_Lote" class="btn btn-info btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-eye mr-2"></i>Ver Lote</button>
        </div>
        <div class="col-md">
            <button id="Btn_Excel" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i> Excel</button>
        </div>
        <div class="col-md">
            <button id="Btn_Imprimir" class="btn btn-warning btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-paper-plane mr-2"></i> Imprimir</button>
        </div>
    </div>


    <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
    <div class="row" id="Id_Conte">
        <div class="col-md-12" id="Paciente">
<%--            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i> Listado de Determinaciones</h5>
            <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
            <br />    
            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-table"></i> TOTALES</h5>
            <div id="Div_Totales" style="width: 100%; border-radius: 5px;" class="highlights"></div>
            <br /> --%>   
            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i> Listado de Determinaciones</h5> 
            <div id="Div_Muestras_Lotes" style="width: 100%;" class="highlights"></div>
            <br />    
            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-table"></i> TOTALES</h5>
            <div id="Div_Totales" style="width: 100%; border-radius: 5px;" class="highlights"></div>
        </div>
    </div>
    </div>
    </div>
    <div class="col-lg-1"></div>
    </div>
</asp:Content>