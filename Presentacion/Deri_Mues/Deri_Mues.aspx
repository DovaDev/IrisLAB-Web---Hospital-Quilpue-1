<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Deri_Mues.aspx.vb" Inherits="Presentacion.Deri_Mues" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%--<link href="../css/Custom_Modal.css" rel="stylesheet" />--%>
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <%--  <link href="css/bootstrap.min.css" rel="stylesheet" />--%> <%------------------ IMPORT QUE DAJA LA CAGÁ ---------%>

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
        var correlativin = 0;
        let AATTEE_NNUUMM = 0;

        $(document).ready(function () {
            Ajax_Ddl_Derivados();
            Ajax_Ddl();
            $("#Btn_Desmarcar").hide();
            $("#Id_Conte").hide();

            let dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input, #Txt_Date02 input").val(dateNow);
            $('#Txt_Date01, #Txt_Date02').datetimepicker({
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
            });

            $("#Btn_Marcar").click(function () {
                $("#Btn_Marcar").hide();
                $("#Btn_Desmarcar").show();
                //$(".checkbox-success input").prop('checked', true);
                $(".checkBoxClass2").prop('checked', true);

            });

            $("#Btn_Desmarcar").click(function () {
                $("#Btn_Desmarcar").hide();
                $("#Btn_Marcar").show();
                //$(".checkbox-success input").prop('checked', false);
                $(".checkBoxClass2").prop('checked', false);
            });

            $("#btn_buscar_seccion").click(() => {
                Ajax_DataTable_Buscar_Sección();
            });

            $("#btn_cerrrrarrrrrrrr_modalll").click(() => {
                setTimeout(() => {
                    $("#Div_Tabla_Seccion").attr("overflow", "auto");
                }, 6000);

            });


            $('#txtNAte').change(function (event) {
                if ($('#txtNAte').val() != "") {
                    var hola = $('#txtNAte').val();

                    var keycode = event.which;
                    Ajax_DataTable_2(hola);

                    var keycode = event.which;
                }

            });

            $("#Btn_Agregar_Seccion").click(() => {
                $("#Div_Tabla_Seccion").empty();
                $("#Div_Tabla_Lis_Exa_ate").empty();
                $("#eModal_Seccion").modal();
            });

            $("#btn_agregar_seccion_2").click(() => {
                selected3 = new Array();
                $("input:checkbox:checked").each(function () {
                    selected3.push($(this).val());
                });
                if (selected3 == 0) {
                    $("#mError_AAH h4").text("Sin Selección");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("No se ha marcado ninguno.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_Agregar(selected3);
                }
            });

            //AJAX AGREGAR EN EL MODAL MARCAR
            $("#Btn_Agregar").click(function () {
                selected = new Array();
                $("input:checkbox:checked").each(function () {
                    selected.push($(this).val());
                });
                if (selected == 0) {
                    $("#mError_AAH h4").text("Sin Selección");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("No se ha marcado ninguno.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_Agregar(selected);
                }

            });

            $("#Btn_Guardar").click(function () {
                selected2 = new Array();

                for (i = 0; i < Mx_Dtt_Agregar_DEFINITIVA.length; ++i) {
                    selected2.push(Mx_Dtt_Agregar_DEFINITIVA[i].ID_ATENCION + "~" + Mx_Dtt_Agregar_DEFINITIVA[i].ID_CODIGO_FONASA);
                }

                Ajax_Guardar();

            });

            $("#Btn_Izquierda").click(function () {
                if ($("#txtNAte").val() == "") {
                    $("#mError_AAH h4").text("Ingrese Número de Atención");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, Ingrese un número de atención.");
                    $("#mError_AAH").modal();
                } else {
                    var izquierda = 0;
                    izquierda = parseInt($("#txtNAte").val());

                    izquierda = izquierda - 1;
                    $("#txtNAte").val(izquierda);
                    Ajax_DataTable_2(izquierda);
                }

            });

            $("#Btn_Derecha").click(function () {
                if ($("#txtNAte").val() == "") {
                    $("#mError_AAH h4").text("Ingrese Número de Atención");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, Ingrese un número de atención.");
                    $("#mError_AAH").modal();
                } else {
                    var derecha = 0;
                    derecha = parseInt($("#txtNAte").val());

                    derecha = derecha + 1;
                    $("#txtNAte").val(derecha);
                    Ajax_DataTable_2(derecha);
                }

            });

            $("#Btn_Imprimir").click(function () {
                Ajax_PDF();
            });


            $("#Btn_Cierra_Modal_Comprobante").click(function () {
                Mx_Dtt_Agregar_DEFINITIVA.length = 0;
                $("#mError_AAH_COMPROBANTE").modal('hide');
                $("#mError_AAH_DERIVACION h3").text(correlativin);
                $("#mError_AAH_DERIVACION").modal();
            });


        });
    </script>
    <script>
        function Fill_IMG_Fill(atetetete_nummmmmumumu) {
            AATTEE_NNUUMM = atetetete_nummmmmumumu;
            Llenar_IMG();
        };

        $("img[name='show_img']").click(function () {
            let ii = $(this).attr("data-index");
            //Show_Image(ii)
            Show_Image_2(ii);
        });

        function Show_Image_2(i) {
            let img = parseInt(i);// + 1;
            let Nombre_Doc_S;
            //$("#mod_Name").text(Nombre_Doc_S);
            $("#Mdl_Image_Ate_2 img").attr("src", "data:image/jpeg;base64," + Mx_IMG[i].IMG);
            $("#Mdl_Image_Ate_2 img").attr("name", "show_img_2");
            $("#Mdl_Image_Ate_2 img").attr("data-index", img);

            $("#modal_Imagenes .modal-footer").html("<button type='button' class='btn btn-danger' data-dismiss='modal'><i class='fa fa-fw fa-remove mr-2'></i>Cerrar</button>");




            //$("#Mdl_Image_Ate_2 .modal-footer").html("<button type='button' class='btn btn-warning' onClick='Desasoc(" + Mx_IMG[i].ID_FOTO_ATE + ");'>Desvincular</button><button type='button' class='btn btn-danger' data-dismiss='modal'>Cerrar</button>");
            //$("#Mdl_Image_Ate_2 img").attr("onClick", "Show_Image(" + img + ");");                                    FUNCION DE IMAGEN GRANDE <-------------------------------
            //$("#Mdl_Image_Ate_2 img").css("cursor", "pointer");
            //$("#Mdl_Image_Ate_2 .modal-footer").html("<button type='button' class='btn btn-warning'>Desvincular</button><button type='button' class='btn btn-danger' data-dismiss='modal'>Cerrar</button>");
            // onClick='Desasoc(" + Mx_IMG[i].ID_FOTO_ATE + ");'
            //$("#Mdl_Image_Ate").modal();
        }

        //Json de llenado de DataTable
        var Mx_Dtt_Buscar_Seccion = [
            {
                "ID_ATENCION": 0,
                "ATE_NUM": 0,
                "ATE_FECHA": 0,
                "ID_PACIENTE": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "ATE_AÑO": "asdf",
                "SEXO_DESC": 0,
                "ID_SEXO": 0,
                "ID_PROCEDENCIA": "asdf",
                "ID_ESTADO": "asdf",
                "PROC_DESC": 0,
                "ID_NACIONALIDAD": 0,
                "ID_ORDEN": "asdf",
                "ID_TP_PACI": "asdf",
                "CF_DESC": 0,
                "ID_CODIGO_FONASA": "asdf",
                "ID_RLS_LS": 0,
                "AREA_DESC": "asdf",
                "RLS_LS_DESC": "asdf"
            }
        ];
        function Ajax_DataTable_Buscar_Sección() {

            modal_show();
            var Data_Par = JSON.stringify({
                "ID_SECCION": $("#DdlExamen").val(),
                "DATE_str01": $("#fecha").val(),
                "DATE_str02": $("#fecha2").val(),
            });
            $.ajax({
                "type": "POST",
                "url": "Deri_Mues.aspx/Llenar_DataTable_Seccion",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Buscar_Seccion = JSON.parse(json_receiver);

                        $("#Div_Tabla_Lis_Exa_ate").empty();
                        $("#Div_Tabla_Seccion").empty();
                        Hide_Modal();
                        Fill_DataTable_Secciones();

                    } else {
                        $("#Div_Tabla_Seccion").empty();
                        $("#Div_Tabla_Lis_Exa_ate").empty();
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    alert("Error en la Recepción de Datos");

                    Hide_Modal();
                }
            });
        }
        //Json de llenado de Seccion
        var Mx_Ddl_Seccion = [
            {
                "ID_RLS_LS": 0,
                "ID_LABO": 0,
                "ID_SECCION": 0,
                "RLS_LS_DESC": 0,
                "ID_ESTADO": 0



                //"ID_AREA": 0,
                //"AREA_COD": 0,
                //"AREA_DESC": 0,
                //"ID_ESTADO": 0
            }
        ];
        function Ajax_Ddl() {

            $.ajax({
                "type": "POST",
                "url": "Deri_Mues.aspx/Llenar_Ddl",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_Seccion = JSON.parse(json_receiver);
                        Fill_Ddl();

                    } else {

                    }
                },
                "error": function (response) {


                }
            });
        }

        let Mx_Dtt_Modal = [{
            ATE_NUM: "",
            ATE_FECHA: "",
            ATE_DET_V_ID_ESTADO: "",
            EST_DESCRIPCION: "",
            CF_COD: "",
            CF_DESC: "",
            ID_CODIGO_FONASA: "",
            ID_ATENCION: "",
            PAC_NOMBRE: "",
            PAC_APELLIDO: "",
            PROC_DESC: "",
            ID_PROCEDENCIA: "",
            ATE_AÑO: "",
            SEXO_DESC: "",
            ID_PACIENTE: "",
            ID_SEXO: "",
            ID_ESTADO: "",
            PAC_RUT: "",
            PAC_FNAC: "",
            ATE_DET_V_PREVI: "",
            ATE_MES: "",
            ATE_DIA: "",
            TP_PAGO_DESC: "",
            DOC_NOMBRE: "",
            DOC_APELLIDO: "",
            PROGRA_DESC: "",
            ORD_DESC: "",
            ATE_DET_V_PAGADO: "",
            ATE_DET_V_COPAGO: "",
            ID_USUARIO: "",
            USUARIO_DET: "",
            REVE_DESC: "",
            USU_REV: "",
            USU_CRE: "",
            ATE_DET_RCAJA_ESTADO: "",
            ATE_DET_RCAJA_FECHA: "",
            ATE_DET_RCAJA_VALORD: "",
            ATE_DET_RCAJA_VALORU: "",
            ID_DET_ATE: "",
            ID_PREVE: "",
            ATE_DET_VALOR_BENEF: "",
            ATE_DET_VALOR_CS: "",
            DOCS_CANT: ""
        }];
        function Ajax_DataTable_Folio_Modal(atetetete_nummmmmumumuummumumu) {
            //console.log("enter function");
            modal_show();
            let Data_Par = JSON.stringify({
                "ATE_NUM": atetetete_nummmmmumumuummumumu
            });

            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/Llenar_DataTable_Modal",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Modal = json_receiver;
                        $("#Div_Tabla_Modal").empty();
                        Hide_Modal();
                        $("#lbl_tiiiitle").text("Listado de Documentos " + " " + "N° Atención: " + Mx_Dtt_Modal[0].ATE_NUM + " - " + "Pac. Nombre: " + Mx_Dtt_Modal[0].PAC_NOMBRE + " " + Mx_Dtt_Modal[0].PAC_APELLIDO);
                        //$("#lbl_pac_nom").text("N° Ate: " + Mx_Dtt_Modal[0].ATE_NUM);
                        //$("#lbl_ate_num").text("Pac. Nombre: " + Mx_Dtt_Modal[0].PAC_NOMBRE + " " + Mx_Dtt_Modal[0].PAC_APELLIDO);

                        Fill_DataTable_Modal();
                    } else {

                        $("#Div_Tabla_Modal").empty();
                        Hide_Modal();
                    }
                },
                "error": function (response) {

                    Hide_Modal();
                }
            });
        }

        let Mx_IMG = [{
            "ID_FOTO_ATE": "",
            "IMG": "",
            "USU_NIC": "",
            "FECHA_ASOC": "",
            "FOTO_ATE_PLATAFORMA": ""
        }];

        function Llenar_IMG() {

            $("#Grid_Img").empty();
            let Data_Par = JSON.stringify({
                "ID_ATENCION": AATTEE_NNUUMM//$("#txt_Folio").val()
            });
            //Debug
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "Deri_Mues.aspx/Get_Img",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {

                    Mx_IMG = data.d;
                    IIDD_AATTEE = 0;


                    //Debug
                    if (Mx_IMG != null) {
                        Fill_IMG();
                    } else {
                        AATTEE_NNUUMM = 0;
                        //Debug
                        Hide_Modal();
                    }
                },
                "error": data => {
                    //Debug
                    AATTEE_NNUUMM = 0;
                    Hide_Modal();
                }
            });

        }

        function Fill_IMG() {
            $("#modal_Imagenes .modal-footer").html("<button type='button' class='btn btn-danger' data-dismiss='modal'><i class='fa fa-fw fa-remove mr-2'></i>Cerrar</button>");
            Ajax_DataTable_Folio_Modal(AATTEE_NNUUMM);
            AATTEE_NNUUMM = 0;
            //$("#Grid_Img").empty();
            $("#Mdl_Image_Ate_2 img").attr("src", "");
            let count = 0;
            let count_div = 1;
            let D_Index = 0;
            let _D_Count = 1;
            $("#Grid_Img").append(
                $("<div id='div_Img_" + count_div + "' class='row mt-2 pl-4' style='max-width:calc(100% - 20px) !important'></div>")
            );
            Mx_IMG.forEach((imgx) => {
                if (imgx.IMG.length > 300) {
                    count += 1;
                    let _Plat;
                    if (imgx.FOTO_ATE_PLATAFORMA == 2) {
                        _Plat = "(PC)";
                    } else {
                        _Plat = "(APP)";

                    }
                    if (imgx.USU_NIC != null) {
                        Nombre_Doc = imgx.USU_NIC + " " + _Plat + " </br> " + moment(imgx.FECHA_ASOC).format("DD/MM/YYYY HH:mm:ss");
                    } else {
                        Nombre_Doc = "Web" + " " + _Plat + " </br> " + moment(imgx.FECHA_ASOC).format("DD/MM/YYYY HH:mm:ss");
                        _D_Count += 1;
                    }
                    $("#div_Img_" + count_div).append(
                        ("<div class='col gallery-docs'><img src='data:image/jpeg;base64," + imgx.IMG + "' class='mt-2' style='max-height:200px; max-width:150px; cursor:pointer;' name='show_img' data-index='" + D_Index + "'/><div class='row'><div class='col-lg text-center' style='height:56px'><label>" + Nombre_Doc + "</label></div</div></div>")
                    );

                    if (count == 5) {
                        count = 0;
                        count_div += 1;
                        $("#Grid_Img").append(
                            $("<div id='div_Img_" + count_div + "' class='row pl-4' style='max-width:calc(100% - 20px) !important'></div>")
                        );
                    }
                }
                D_Index += 1;
                if (Mx_IMG.length == D_Index) {
                    let restt = 5 - count;
                    for (xx = 1; xx <= restt; xx++) {
                        $("#div_Img_" + count_div).append(
                            ("<div class='col-lg'></div>")
                        );
                    }
                }
            });
            $("img[name='show_img']").click(function () {
                let ii = $(this).attr("data-index");
                //Show_Image(ii)
                Show_Image_2(ii);
            });

            //$("img[name='show_img_2']").click(function () {
            //    let ii = $(this).attr("data-index");
            //    Show_Image(ii)
            //});

            //Hide_Modal();
            $("#modal_Imagenes").modal();
        }

        //Llenar DropDownList
        function Fill_Ddl() {

            //    "ID_RLS_LS":0,
            //"ID_LABO":0,
            //"ID_SECCION":0,
            //"RLS_LS_DESC":0,
            //"ID_ESTADO":0

            $("#DdlExamen").empty();
            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#DdlExamen");
            for (y = 0; y < Mx_Ddl_Seccion.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl_Seccion[y].ID_RLS_LS
                }).text(Mx_Ddl_Seccion[y].RLS_LS_DESC).appendTo("#DdlExamen");
            }
        };

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
                "url": "Deri_Mues.aspx/IRIS_WEBF_BUSCA_DERIVADOS",
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
        //-------------------------------------------------- TABLA 2 NATE ----------------------------------------------------|
        var Mx_Dtt_Nate = [
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
                "ATE_NUM": 0,
                "DOCS_CANT": 0
            }
        ];

        function Ajax_DataTable_2(N_ATE) {
            modal_show();

            var Data_Par = JSON.stringify({
                "NATE": N_ATE
            });
            $.ajax({
                "type": "POST",
                "url": "Deri_Mues.aspx/Llenar_DataTable_2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Nate = JSON.parse(json_receiver);

                        $("#NomWichipirichi").text(Mx_Dtt_Nate[0].PAC_NOMBRE + " " + Mx_Dtt_Nate[0].PAC_APELLIDO);
                        $("#NumWichipirichi").text(Mx_Dtt_Nate[0].ATE_NUM);

                        for (i = 0; i < Mx_Dtt_Nate.length; ++i) {
                            var date_x = Mx_Dtt_Nate[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Nate[i].ATE_FECHA = Date_Change;
                        }

                        $("#Div_Tabla_Lis_Exa_ate").empty();
                        $("#Div_Tabla_Seccion").empty();
                        $("#eModal").modal('hide');
                        $("#eModal").modal('show');
                        Fill_DataTable_2();
                        Hide_Modal();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);


                }
            });
        }

        //------------------------------------------------------------------- AGREGAR -----------------------------------------------------------|

        var Mx_Dtt_Agregar = [
            {
                "ID_ATENCION": 0,
                "ID_DET_ATE": 0,
                "CF_DESC": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "SEXO_DESC": 0,
                "PAC_FNAC": 0,
                "PAC_RUT": 0,
                "ID_CODIGO_FONASA": 0,
                "ORD_DESC": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "ATE_FECHA": 0,
                "ATE_NUM": 0
            }
        ];


        var Mx_Dtt_Agregar_DEFINITIVA = [
        ];

        var fechas = [];

        function Ajax_Agregar(selectin) {
            modal_show();


            var Data_Par = JSON.stringify({
                "selected": selectin
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Deri_Mues.aspx/Agregar",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        $("#eModal").modal('hide');
                        Mx_Dtt_Agregar = JSON.parse(json_receiver);

                        for (i = 0; i < Mx_Dtt_Agregar.length; ++i) {
                            var date_x = Mx_Dtt_Agregar[i].PAC_FNAC;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Agregar[i].PAC_FNAC = Date_Change;
                        }

                        Mx_Dtt_Agregar.forEach((REEE) => {
                            Mx_Dtt_Agregar_DEFINITIVA.push(REEE)
                        });

                        $("#eModal_Seccion").modal("hide");
                        Hide_Modal();
                        $("#DataTable").empty();
                        Fill_DataTable();


                    } else {


                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin Resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados.");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
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

        //------------------------------------------------------------------- GUARDAR -----------------------------------------------------------|

        var Mx_Dtt_Guardar = [
            {

            }
        ];



        function Ajax_Guardar() {
            modal_show();


            var Data_Par = JSON.stringify({
                "ID_ATE_y_CF": selected2,
                "ID_DERIVADOR": $("#Ddl_Derivados").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Deri_Mues.aspx/Guardar",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        correlativin = JSON.parse(json_receiver);

                        Hide_Modal();
                        $("#mError_AAH_COMPROBANTE h4").text("Comprobate Atención");
                        $("#mError_AAH_COMPROBANTE p").text("¿Desea imprimir el comprobante de atención?.");
                        $("#mError_AAH_COMPROBANTE").modal();


                        $("#DataTable").empty();
                        $("#Div_Tabla").empty();
                        $("#Id_Conte").hide();

                    } else {


                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin Guardar");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se ha podido guardar el proceso.");
                        $("#mError_AAH").modal();
                    }
                    $(".block_wait").fadeOut(500);
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

        //------------------------------------------------------------------- IMPRIMIR -----------------------------------------------------------|

        function Ajax_PDF() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "datitos": Mx_Dtt_Agregar_DEFINITIVA,
                "Derivador": $("#Ddl_Derivados option:selected").text()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Deri_Mues.aspx/PDF",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Hide_Modal();
                        $("#mError_AAH_COMPROBANTE").modal('hide');
                        $("#mError_AAH_DERIVACION h3").text(correlativin);
                        $("#mError_AAH_DERIVACION").modal();
                        Mx_Dtt_Agregar_DEFINITIVA.length = 0;
                        window.open(json_receiver, 'Download');

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Impresión");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se ha podido imprimir el documento.");
                        $("#mError_AAH").modal();
                    }
                    $(".block_wait").fadeOut(500);
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


    </script>

        <%-- Funciones de Llenado de Elementos --%>
    <script>

        //Llenar DropDownList Derivados
        function Fill_Ddl_Derivados() {
            $("#Ddl_Derivados").empty();

            for (i = 0; i < Mx_Ddl_Derivados.length; ++i) {
                $("<option>", { "value": Mx_Ddl_Derivados[i].ID_DERIVADO }).text(Mx_Ddl_Derivados[i].DERI_DESC).appendTo("#Ddl_Derivados");
            }
        };

    </script>

    <script>
        //-----------------------------------------TABLA PACIENTE---------------------------------------------|
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
            $("#DataTable thead").attr("class", "cabzera");
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("N° Atencion"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Exámenes"),
                    $("<th>", { "class": "textoReducido" }).text("Orden"),
                    $("<th>", { "class": "textoReducido" }).text("Médico"),
                    $("<th>", { "class": "textoReducido" }).text("Sexo"),
                    $("<th>", { "class": "textoReducido" }).text("F.Nac")

                )
            );

            for (i = 0; i < Mx_Dtt_Agregar_DEFINITIVA.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Agregar_DEFINITIVA[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Agregar_DEFINITIVA[i].ATE_FECHA),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Agregar_DEFINITIVA[i].PAC_NOMBRE + " " + Mx_Dtt_Agregar_DEFINITIVA[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Agregar_DEFINITIVA[i].CF_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Agregar_DEFINITIVA[i].ORD_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Agregar_DEFINITIVA[i].DOC_NOMBRE + " " + Mx_Dtt_Agregar_DEFINITIVA[i].DOC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Agregar_DEFINITIVA[i].SEXO_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Agregar_DEFINITIVA[i].PAC_FNAC);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            fechas[i] = dd + "/" + mm + "/" + yy;
                            return String(dd + "/" + mm + "/" + yy);
                        })
                    )
                );
            }
        }

        //-----------------------------------------TABLA PACIENTE---------------------------------------------|
        function Fill_DataTable_2() {
            $("<table>", {
                "id": "DataTable_Lis_Exa_Ate",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Lis_Exa_ate");

            $("#DataTable_Lis_Exa_Ate").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Lis_Exa_Ate").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Lis_Exa_Ate thead").attr("class", "cabzera");
            $("#DataTable_Lis_Exa_Ate thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Código"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción del Examen"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Hora"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario"),
                    //$("<th>", { "class": "textoReducido" }).text("Ver Orden"),
                    $("<th>", { "class": "textoReducido" }).text("Seleccionar")

                )
            );

            for (i = 0; i < Mx_Dtt_Nate.length; i++) {
                $("#DataTable_Lis_Exa_Ate tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Nate[i].CF_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Nate[i].CF_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Nate[i].ATE_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date2 = new Date(Mx_Dtt_Nate[i].ATE_FECHA);
                            var hh = parseInt(obj_date2.getHours());
                            var mm = parseInt(obj_date2.getMinutes());
                            var ss = parseInt(obj_date2.getSeconds());

                            if (hh < 10) { hh = "0" + hh; }
                            if (mm < 10) { mm = "0" + mm; }
                            if (ss < 10) { ss = "0" + ss; }

                            return String(hh + ":" + mm + ":" + ss);
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Nate[i].USU_NIC),
                        //$("<td>", { "align": "right" }, { "class": "textoReducido" }).text(function () {
                        //    if (Mx_Dtt_Nate[i].DOCS_CANT == 0) {
                        //        $(this).append("<button type='button' disabled='disabled' class='btn btn-secondary btn-sm'><i class='fa fa-fw fa-file-text mr-2'></i>Ver Orden</button>");
                        //    } else {
                        //        $(this).append("<button type='button' class='btn btn-limpiar btn-sm' onclick='Fill_IMG_Fill(" + Mx_Dtt_Nate[i].ATE_NUM + ")'><i class='fa fa-fw fa-file-text mr-2'></i>Ver Orden</button>");
                        //    }
                        //}),
                        $("<td>").css("text-align", "center").text(function () {
                            $(this).html("<input type='checkbox' class='checkBoxClass' id='chekito" + i + "' value='" + Mx_Dtt_Nate[i].ID_ATENCION + "~" + Mx_Dtt_Nate[i].ID_CODIGO_FONASA + "'/>")
                        })
                    )
                );
            }
        }
        //-----------------------------------------TABLA SECCIONES ---------------------------------------------|
        function Fill_DataTable_Secciones() {
            $("<table>", {
                "id": "DataTable_Seccion",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Seccion");

            $("#DataTable_Seccion").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Seccion").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Seccion thead").attr("class", "cabzera");
            $("#DataTable_Seccion thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Pac"),
                    $("<th>", { "class": "textoReducido" }).text("Edad"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Hora"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar TM"),
                    $("<th>", { "class": "textoReducido" }).text("Sexo"),
                    $("<th>", { "class": "textoReducido" }).text("Examen"),
                    //$("<th>", { "class": "textoReducido" }).text("Ver Orden"),
                    $("<th>", { "class": "textoReducido" }).text("cargar")

                )
            );

            for (i = 0; i < Mx_Dtt_Buscar_Seccion.length; i++) {
                $("#DataTable_Seccion tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Buscar_Seccion[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Buscar_Seccion[i].PAC_NOMBRE + " " + Mx_Dtt_Buscar_Seccion[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Buscar_Seccion[i].ATE_AÑO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(moment(Mx_Dtt_Buscar_Seccion[i].ATE_FECHA).format("DD-MM-YYYY")),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(moment(Mx_Dtt_Buscar_Seccion[i].ATE_FECHA).format("HH:mm")),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Buscar_Seccion[i].PROC_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Buscar_Seccion[i].SEXO_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Buscar_Seccion[i].CF_DESC),
                        //$("<td>", { "align": "right" }, { "class": "textoReducido" }).text(function () {
                        //    if (Mx_Dtt_Buscar_Seccion[i].DOCS_CANT == 0) {
                        //        $(this).append("<button type='button' disabled='disabled' class='btn btn-secondary btn-sm'><i class='fa fa-fw fa-file-text mr-2'></i>Ver Orden</button>");
                        //    } else {
                        //        $(this).append("<button type='button' class='btn btn-limpiar btn-sm' onclick='Fill_IMG_Fill(" + Mx_Dtt_Buscar_Seccion[i].ATE_NUM + ")'><i class='fa fa-fw fa-file-text mr-2'></i>Ver Orden</button>");
                        //    }
                        //}),
                        $("<td>").css("text-align", "center").text(function () {
                            $(this).html("<input type='checkbox' class='checkBoxClass2' id='chekito" + i + "' value='" + Mx_Dtt_Buscar_Seccion[i].ID_ATENCION + "~" + Mx_Dtt_Buscar_Seccion[i].ID_CODIGO_FONASA + "'/>")
                        })
                    )
                );
            }
            $("#DataTable_Seccion").DataTable({
                "bSort": false,
                "iDisplayLength": 100,
                "info": false,
                "bPaginate": false,
                //"bFilter": false,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay coincidencias",
                    "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Buscar: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
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
    <div class="modal fade" id="eModal" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Listado Exámenes de la Atención</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col">
                                <label>N° de Atención: </label>
                                <label id="NumWichipirichi"></label>
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col">
                                <label>Nombre Paciente: </label>
                                <label id="NomWichipirichi"></label>
                            </div>
                        </div>
                    </div>
                    <form>
                        <div id="Div_Tabla_Lis_Exa_ate" style="width: 100%;" class="table-responsive"></div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-info" id="Btn_Agregar"><i class="fa fa-fw fa-save mr-2"></i>Agregar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Salir</button>
                    <%--<button type="button" id="btnguardar" class="btn btn-success">Guardar</button>--%>
                </div>
            </div>
        </div>
    </div>
    <%-- -------------------------------------- MODAL SECCION --------------------------------------------------------%>
        <div class="modal fade" id="eModal_Seccion" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" style="max-height:80vh; min-height:80vh; overflow:auto;">
        <div class="modal-dialog modal-lg w-100" role="document" style="max-width: 80vw; max-height:80vh; min-height:80vh">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Listado de Hoja de Trabajo por Sección</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-2">
                            <label for="fecha">Desde:</label>
                            <div class='input-group date' id='Txt_Date01'>
                                <input type='text' id="fecha" class="form-control form-control-sm" readonly="true" placeholder="Desde..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                    <div class="col-md-2">
                        <label for="fecha2">Hasta:</label>
                        <div class='input-group date' id='Txt_Date02'>
                            <input type='text' id="fecha2" class="form-control form-control-sm" readonly="true" placeholder="Hasta..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                        <div class="col-md-2">
                            <label>Seccion:</label>
                            <select id="DdlExamen" class="form-control">
                                <option value="0">Todos</option>
                            </select>
                        </div>
                        <div class="col-md-2">
                            <label>Buscar Sección:</label>
                            <button type="button" id="btn_buscar_seccion" class="btn btn-success"><i class="fa fa-fw fa-reply mr-2"></i>Buscar</button>
                        </div>
                        <div class="col-md-2">
                            <label>Agregar Exámenes:</label>
                            <button type="button" id="btn_agregar_seccion_2" class="btn btn-info"><i class="fa fa-fw fa-reply mr-2"></i>Agregar</button>
                        </div>
                        <div class="col-md-1">
                            <label>Marcar:</label>
                            <button id="Btn_Marcar" class="btn btn-dark" type="submit">Todos</button>
                            <button id="Btn_Desmarcar" class="btn btn-dark" type="submit">Desmarcar</button>
                       </div>
                        <div class="col-md-1">
                            <label>Salir</label>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Salir</button>
                        </div>
                    </div>
                        <br />
                        <form>
                            <div id="Div_Tabla_Seccion" style="width: 100%;" class="table-responsive"></div>
                        </form>
                    
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Salir</button>
                    <%--<button type="button" id="btnguardar" class="btn btn-success">Guardar</button>--%>
                </div>
            </div>
        </div>
    </div>

            <!-- Modal Galeria de Imagenes -->
    <div id="modal_Imagenes" class="modal fade" role="dialog" style="max-height:90vh; min-height:89vh">
        <div class="modal-dialog" style="max-width: 98vw; max-height:90vh; min-height:89vh">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" style="text-align:center;" id="lbl_tiiiitle">Listado de Documentos</h4>
                </div>
                <div class="modal-body">
                    <div class="col">
<%--                        <h5 id="lbl_pac_nom"></h5>
                        <br />
                        <h5 id="lbl_ate_num"></h5>--%>
                        <div class="row">
                            <div class="col-lg">
                                <div class="card border-bar mb-3">
                                    <div class="card-header text-center bg-bar">
                                        <h5 class="m-0"><i class="fa fa-picture-o fa-fw"></i> Galería</h5>
                                    </div>
                                    <div class="card-body p-0" style="background-color: #f5f5f5">
                                        <div id="Grid_Img" class="text-center" style="max-height: 500px;"></div>
                                    </div>
                                </div>
                                <div id="Div_Tabla_Modal" style="overflow:auto;">

                                </div>
                            </div>
                            <div class="col-lg">
                                <div id="Mdl_Image_Ate_2" class="col-lg">
                                    <h3 class="modal-title w-100" id="mod_Name_2"></h3>
                                    <img src="" style="max-width: 50vw; max-height:90vh;" />
                            </div>
                            </div>                       
                        </div>
                    </div>
                    
                </div>
                <div class="modal-footer">       
                    <%--<button type="button" id="btn_Marcar_Modal" class="btn btn-limpiar"><i class="fa fa-crosshairs fa-fw"></i>Marcar</button>--%>    
                    <%--<button type='button' id="btn_desvincular_modal" class='btn btn-warning'>Desvincular</button>--%> 
                    <button type="button" class="btn btn-danger" id="btn_cerrrrarrrrrrrr_modalll" data-dismiss="modal"><i class="fa fa-fw fa-remove mr-2"></i>Cerrar</button>
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
        <!-- Modal COMPROBANTE-->
    <div id="mError_AAH_COMPROBANTE" class="modal fade" role="dialog">
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
                    <button id="Btn_Cierra_Modal_Comprobante" type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                    <button id="Btn_Imprimir" type="button" class="btn btn-success">Imprimir</button>
                </div>
            </div>
        </div>
    </div>
            <!-- Modal DERIVACION-->
    <div id="mError_AAH_DERIVACION" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">N° Derivación</h4>
                </div>
                <div class="modal-body">
                    <h3 style="text-align:center;">AAAAAAAHHHH</h3>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <%------------------------------------------------------TÍTULO, TEXTBOX Y BOTONES-----------------------------------------%>
<div class="row">
    <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div class="card mb-3 border-bar" style="padding-bottom: 8px;">
                <div class="card-header bg-bar">
                    <h5 style="text-align: center; padding: 5px;">
                        <i class="fa fa-search"></i>
                        Mantenedor de Derivados
                    </h5>
                </div>
                <div class="row">
                <div class="col-lg-1"></div>
                    <div class="col-lg-10">
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="row">
                                    <div class="col-lg-6">
                                        <label for="txtNAte">N° Atención:</label>
                                        <input id="txtNAte" class="form-control textoReducido" type="text" placeholder="BUSCAR..." onkeydown="return jsDecimals(event);" />
                                    </div>
                                    <div class="col-lg-3">
                                        <br />
                                        <button id="Btn_Izquierda" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px; width: 100%; background-color:#008e7a; border-color: #008e7a;" type="submit"><i class="fa fa-fw fa-arrow-left mr-2"></i></button>
                                    </div>
                                    <div class="col-lg-3">
                                        <br />
                                        <button id="Btn_Derecha" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px; width: 100%; background-color: #008e7a; border-color: #008e7a;" type="submit"><i class="fa fa-fw fa-arrow-right mr-2"></i></button>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3"></div>
                            <div class="col-lg-5">
                                <div class="row">
                                        <div class="col-lg-4">
                                            <br />
                                            <button id="Btn_Guardar" type="button" class="btn btn-primary btn-block" style="margin-bottom: 1vh; padding: 3px;"><i class="fa fa-fw fa-save mr-2"></i>Guardar</button>
                                        </div>
                                        <div class="col-lg-6">
                                            <br />
                                            <button id="Btn_Agregar_Seccion" class="btn btn-warning btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-check mr-2"></i>Agregar Sección</button>
                                        </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-4">
                                <label for="Ddl_Derivados">Laboratorio Derivador:</label>
                                <select id="Ddl_Derivados" class="form-control">
                                </select>
                            </div>
                        </div>
                    </div>
                <div class="col-lg-1"></div>
            </div>

    <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
                <div>
                    <div class="row" id="Id_Conte">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-10" id="Paciente">
                            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list"></i>Listado de Exámenes Derivados</h5>
                            <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                </div>
            </div>
        </div>
    <div class="col-lg-1"></div>
</div>
</asp:Content>
