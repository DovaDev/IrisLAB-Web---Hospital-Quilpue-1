<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Perm_Usu.aspx.vb" Inherits="Presentacion.Perm_Usu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
    <script src="//wzrd.in/standalone/blob-util@latest"></script>
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

        var ID_UPDATE_USUARIO = 0;
        var B64Firma = "";

        $(document).ready(function () {
            function readFile() {
                if (this.files && this.files[0]) {
                    var FR = new FileReader();
                    FR.addEventListener("load", function (e) {
                        if (e.target.result != "") {
                            B64Firma = e.target.result;
                        }
                        else {
                            B64Firma = "vacio";
                        }
                        
                    });
                    FR.readAsDataURL(this.files[0]);
                }
            }

            document.getElementById("Inp_Image").addEventListener("change", readFile);

            Ajax_Ciudad();
            Ajax_LugarTM();
            Ajax_LugarTMOLD();
            Ajax_Profesion();
            Ajax_Cargo();
            Ajax_Mantenedor();
            Ajax_Permisos();
            Ajax_DataTable();
            $(".block_wait").fadeOut(0);
            $("#Div_Tabla").empty();

            $("#Div_Tabla").show();
            $("#Id_Conte").hide();

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
            $("#Txt_Date01OLD input").val(dateNow);

            $('#Txt_Date01OLD').datetimepicker(
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


            $("#txtRut").focusout(function () {
                if ($("#txtRut").val() != "") {

                    //Capturar Anáqlisis del RUT
                    var obj_RUT = Valid_RUT($("#txtRut").val());

                    if (obj_RUT.Valid == false) {
                        //var str_Error = "El RUT ingresado no es Válido, ";
                        //str_Error += "ingrese en el campo de texto un RUT válido.";

                        //$("#mError_AAH h5").text("Error:");
                        //$("#button_modal").attr("class", "btn btn-danger");

                        //$("#mError_AAH p").text(str_Error);
                        //$("#mError_AAH").modal();

                        $("#txtRut").val("");
                        $("#txtRut").css({
                            "border-color": "red"
                        });
                    } else {
                        $("#txtRut").css({
                            "border-color": "green"
                        });
                        $("#txtRut").val(obj_RUT.Format);

                    }
                }
            });


            //Registrar evento Click del Botón Crear Usuario       
            $("#Btn_New_User").click(function () {
                $("#txtNombre").val("");
                $("#txtApellido").val("");
                $("#txtNick").val("");
                $("#txtPass").val("");
                $("#txtFono").val("");
                $("#txtEmail").val("");
                $("#Ddl_Permiso").val("0");
                $("#Ddl_LugarTM").val("xx");


                $("#txtRut").css({
                    "border-color": "#868e96"
                });

                $("#txtNick").css({
                    "border-color": "#868e96"
                });
                $("#txtPass").css({
                    "border-color": "#868e96"
                });
                $("#Ddl_LugarTM").css({
                    "border-color": "#868e96"
                });

                $("#eModal_New_User").modal('hide');
                $("#eModal_New_User").modal('show');

            });

            $("#btn_Guardar").click(function () {
                var sum = 0;
                //if ($("#txtRut").val() == "") {
                //    $("#txtRut").css({
                //        "border-color": "red"
                //    });
                //} else {
                //    sum += 1;
                //    $("#txtRut").css({
                //        "border-color": "green"
                //    });
                //}
                //if ($("#txtNombre").val() == "") {
                //    $("#txtNombre").css({
                //        "border-color": "red"
                //    });
                //} else {
                //    sum += 1;
                //    $("#txtNombre").css({
                //        "border-color": "green"
                //    });
                //}

                //if ($("#txtApellido").val() == "") {
                //    $("#txtApellido").css({
                //        "border-color": "red"
                //    });
                //} else {
                //    sum += 1;
                //    $("#txtApellido").css({
                //        "border-color": "green"
                //    });
                //}

                if ($("#txtNick").val() == "") {
                    $("#txtNick").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#txtNick").css({
                        "border-color": "green"
                    });
                }
                if ($("#txtPass").val() == "") {
                    $("#txtPass").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#txtPass").css({
                        "border-color": "green"
                    });
                }
                //if ($("#txtFono").val() == "") {
                //    $("#txtFono").css({
                //        "border-color": "red"
                //    });
                //} else {
                //    sum += 1;
                //    $("#txtFono").css({
                //        "border-color": "green"
                //    });
                //}
                //if ($("#txtEmail").val() == "") {
                //    $("#txtEmail").css({
                //        "border-color": "red"
                //    });
                //} else {
                //    sum += 1;
                //    $("#txtEmail").css({
                //        "border-color": "green"
                //    });
                //}
                //if ($("#txtDireccion").val() == "") {
                //    $("#txtDireccion").css({
                //        "border-color": "red"
                //    });
                //} else {
                //    sum += 1;
                //    $("#txtDireccion").css({
                //        "border-color": "green"
                //    });
                //}
                //if ($("#txtMovil").val() == "") {
                //    $("#txtMovil").css({
                //        "border-color": "red"
                //    });
                //} else {
                //    sum += 1;
                //    $("#txtMovil").css({
                //        "border-color": "green"
                //    });
                //}
                if ($("#Ddl_LugarTM").val() == "xx") {
                    $("#Ddl_LugarTM").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Ddl_LugarTM").css({
                        "border-color": "green"
                    });
                }
                if (sum == 3) {
                    Ajax_GRABA_USUARIO();
                } else {
                    $("#mError_AAH h4").text("Completar");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, Revise los campos marcados en rojo.");
                    $("#mError_AAH").modal();
                }
            });

            $("#btnEditar").click(function () {
                $("#txtRutOLD").css({
                    "border-color": "#868e96"
                });

                $("#txtNickOLD").css({
                    "border-color": "#868e96"
                });
                $("#txtPass").css({
                    "border-color": "#868e96"
                });
                $("#Ddl_LugarTMOLD").css({
                    "border-color": "#868e96"
                });

                var sum = 0;
                if ($("#txtNickOLD").val() == "") {
                    $("#txtNickOLD").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#txtNickOLD").css({
                        "border-color": "green"
                    });
                }
                if ($("#txtPassOLD").val() == "") {
                    $("#txtPassOLD").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#txtPassOLD").css({
                        "border-color": "green"
                    });
                }
                if ($("#Ddl_LugarTMOLD").val() == "xx") {
                    $("#Ddl_LugarTMOLD").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Ddl_LugarTMOLD").css({
                        "border-color": "green"
                    });
                }

                if (sum == 3) {
                    Ajax_UPDATE_USUARIO();
                } else {
                    $("#mError_AAH h4").text("Completar");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, Revise los campos marcados en rojo.");
                    $("#mError_AAH").modal();
                }
            });

            $("#Btn_Limpiar").click(function () {
                $("#txtRut").val("");
                $("#txtNombre").val("");
                $("#txtApellido").val("");
                $("#fecha").val(dateNow);
                $("#txtDireccion").val("");
                $("#txtEmail").val("");
                $("#DdlEstado").val("1");
                $("#DdlProfesion").val(5);
                $("#DdlCargo").val(1);
                $("#txtNick").val("");
                $("#txtPass").val("");
                $("#txtFono").val("");
                $("#txtMovil").val("");
                $("#Ddl_Permiso").val("0");
                $("#Ddl_LugarTM").val("xx");


                $("#txtRut").css({
                    "border-color": "#868e96"
                });
                $("#txtNick").css({
                    "border-color": "#868e96"
                });
                $("#txtPass").css({
                    "border-color": "#868e96"
                });
                $("#Ddl_LugarTM").css({
                    "border-color": "#868e96"
                });
            });



            $("#Ddl_Permiso").change(function () {
                if ($("#Ddl_Permiso").val() == 1) {
                    $("#Ddl_LugarTM").empty();
                    $("<option>", { "value": "0" }).text("Todos").appendTo("#Ddl_LugarTM");
                }
                else if ($("#Ddl_Permiso").val() == 2) {
                    $("#Ddl_LugarTM").empty();
                    $("<option>", { "value": "0" }).text("Todos").appendTo("#Ddl_LugarTM");
                    Fill_Ddl_LugarTM();
                }
                else {
                    $("#Ddl_LugarTM").empty();
                    Fill_Ddl_LugarTM();
                }
            });

            $("#Ddl_PermisoOLD").change(function () {
                if ($("#Ddl_PermisoOLD").val() == 1) {
                    $("#Ddl_LugarTMOLD").empty();
                    $("<option>", { "value": "0" }).text("Todos").appendTo("#Ddl_LugarTMOLD");

                }
                else if ($("#Ddl_PermisoOLD").val() == 2) {
                    $("#Ddl_LugarTMOLD").empty();
                    $("<option>", { "value": "0" }).text("Todos").appendTo("#Ddl_LugarTMOLD");
                    Fill_Ddl_LugarTM();
                }
                else {
                    $("#Ddl_LugarTMOLD").empty();
                    Fill_Ddl_LugarTMOLD();
                }
            });

        });
    </script>
    <script>

        //-------------------------------------------------- PERMISOS USUARIO --------------------------------------------------------|
        var Mx_Dtt_Permisos = [
            {
                "ID_PER_USU": 0,
                "PER_USU_COD": 0,
                "PER_USU_DESC": 0,
                "ID_ESTADO": 0
            }
        ];

        function Ajax_Permisos() {
            ////console.log("Inicializando petición de datos:");
            ////console.log('"DataTable"');
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Perm_usu.aspx/IRIS_WEBF_BUSCA_PERMISO_USUARIO",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Permisos = JSON.parse(json_receiver);
                        Fill_Ddl_Permiso();
                        ////console.log('>>>LLENADO COMPLETADO<<<');
                        ////console.log('');
                    } else {
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

                    ////console.log('>>>ERROR EN LLENADO<<<');
                    ////console.log('');
                }
            });
        }


        //-------------------------------------- JSON MANTENEDOR ------------------------------------------------------------------------| 
        var Mx_Ddl_Mantenedor = [
            {
                "ID_ESTADO": 0,
                "EST_DESCRIPCION": 0,
                "EST_MANTENEDOR": 0
            }
        ];

        function Ajax_Mantenedor() {
            ////console.log("Inicializando petición de datos:");
            ////console.log('"DropDownList"');

            $.ajax({
                "type": "POST",
                "url": "Perm_Usu.aspx/IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_Mantenedor = JSON.parse(json_receiver);
                        Fill_Ddl_Estado();
                        $(".block_wait").hide();
                        ////console.log('>>>LLENADO COMPLETADO<<<');
                        ////console.log('');
                    } else {
                        ////console.log('>>>0 RESULTADOS<<<');
                        ////console.log('');
                    }
                },
                "error": function (response) {
                    ////console.log('>>>ERROR EN LLENADO<<<');
                    ////console.log('');
                }
            });
        }



        //---------------------------------------------- CARGO --------------------------------------------

        var Mx_Dtt_Cargo = [
    {
        "ID_CAR": 0,
        "CAR_COD": 0,
        "CARD_DESC": 0,
        "ID_ESTADO": 0
    }
        ];

        function Ajax_Cargo() {


            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Perm_Usu.aspx/IRIS_WEBF_BUSCA_CARGO",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Cargo = JSON.parse(json_receiver);
                        Fill_Ddl_Cargo();

                    } else {

                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                    ////console.log('>>>ERROR EN LLENADO<<<');
                    ////console.log('');
                }
            });
        }





        //-------------------------------------------------- Profesion --------------------------------------------------------|
        var Mx_Dtt_Profesion = [
            {
                "ID_PRO": 0,
                "PRO_COD": 0,
                "PRO_DESC": 0,
                "ID_ESTADO": 0
            }
        ];

        function Ajax_Profesion() {
            //modal_show();
            ////console.log("Inicializando petición de datos:");
            ////console.log('"DataTable"');
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Perm_Usu.aspx/IRIS_WEBF_BUSCA_PROFESION",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Profesion = JSON.parse(json_receiver);
                        ////console.log(Mx_Dtt);

                        Fill_Ddl_Profesion();
                        //Hide_Modal();
                        ////console.log('>>>LLENADO COMPLETADO<<<');
                        ////console.log('');
                    } else {
                        ////console.log('>>>0 RESULTADOS<<<');
                        ////console.log('');
                        //Hide_Modal();
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

                    ////console.log('>>>ERROR EN LLENADO<<<');
                    ////console.log('');
                }
            });
        }



        //--------------------------------------- JSON CIUDAD --------------------------------------------------------------------------|
        var Mx_Ciudad = [
    {
        "ID_CIUDAD": 0,
        "CIU_COD": 0,
        "CIU_DESC": 0,
        "ID_ESTADO": 0
    }
        ];

        function Ajax_Ciudad() {
            ////console.log("Inicializando petición de datos:");
            ////console.log('"DropDownList"');

            $.ajax({
                "type": "POST",
                "url": "Perm_Usu.aspx/IRIS_WEBF_BUSCA_CIUDAD",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ciudad = JSON.parse(json_receiver);
                        Fill_Ddl_Cuidad();
                        Ajax_Comuna();
                        $(".block_wait").hide();
                        ////console.log('>>>LLENADO COMPLETADO<<<');
                        ////console.log('');
                    } else {
                        ////console.log('>>>0 RESULTADOS<<<');
                        ////console.log('');
                    }
                },
                "error": function (response) {
                    ////console.log('>>>ERROR EN LLENADO<<<');
                    ////console.log('');
                }
            });
        }

        //--------------------------------------- JSON COMUNA --------------------------------------------------------------------------|
        var Mx_Comuna = [
    {
        "COM_DESC": 0,
        "ID_COMUNA": 0,
        "ID_ESTADO": 0,
        "ID_CIUDAD": 0,
        "ID_REL_CIU_COM": 0
    }
        ];

        function Ajax_Comuna() {
            ////console.log("Inicializando petición de datos:");
            ////console.log('"DropDownList"');

            var Data_Par = JSON.stringify({
                "ID_CIU": $("#DdlCiudad").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Perm_Usu.aspx/IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Comuna = JSON.parse(json_receiver);
                        Fill_Ddl_Comuna();
                        $(".block_wait").hide();
                        ////console.log('>>>LLENADO COMPLETADO<<<');
                        ////console.log('');
                    } else {
                        ////console.log('>>>0 RESULTADOS<<<');
                        ////console.log('');
                    }
                },
                "error": function (response) {
                    ////console.log('>>>ERROR EN LLENADO<<<');
                    ////console.log('');
                }
            });
        }


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
            ////console.log("Inicializando petición de datos:");
            ////console.log('"DataTable"');

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Perm_Usu.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_LugarTM = JSON.parse(json_receiver);

                        Fill_Ddl_LugarTM();
                        //Fill_Ddl_LugarTMOLD();
                        Hide_Modal();
                        ////console.log('>>>LLENADO COMPLETADO<<<');
                        ////console.log('');
                    } else {
                        ////console.log('>>>0 RESULTADOS<<<');
                        ////console.log('');
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

                    ////console.log('>>>ERROR EN LLENADO<<<');
                    ////console.log('');
                }
            });
        }

        var Mx_Dtt_LugarTMOLD = [
{
    "ID_ESTADO": 0,
    "PROC_DESC": 0,
    "PROC_COD": 0,
    "ID_PROCEDENCIA": 0
}
        ];

        function Ajax_LugarTMOLD() {
            modal_show();
            ////console.log("Inicializando petición de datos:");
            ////console.log('"DataTable"');

            $.ajax({
                "type": "POST",
                "url": "Perm_Usu.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_LugarTMOLD = JSON.parse(json_receiver);

                        //Fill_Ddl_LugarTM();
                        Fill_Ddl_LugarTMOLD();
                        Hide_Modal();
                        ////console.log('>>>LLENADO COMPLETADO<<<');
                        ////console.log('');
                    } else {
                        ////console.log('>>>0 RESULTADOS<<<');
                        ////console.log('');
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

                    ////console.log('>>>ERROR EN LLENADO<<<');
                    ////console.log('');
                }
            });
        }

        //--------------------------------------------------BUSCAR USUARIOS TABLA ----------------------------------------------------|
        var Mx_Dtt = [
            {
                "ID_USUARIO": 0,
                "USU_NOMBRE": 0,
                "USU_APELLIDO": 0,
                "ID_ESTADO": 0,
                "PER_USU_DESC": 0,
                "USU_NIC": 0,
                "USU_ADMIN": 0,
                "proc_desc": 0
            }
        ];

        function Ajax_DataTable() {
            modal_show();
            //console.log("Inicializando petición de datos:");
            //console.log('"DataTable"');
            //var Data_Par = JSON.stringify({
            //    "RUT_P": $("#txtRut").val(),
            //    "NOM_P": $("#txtNom").val(),
            //    "APE_P": $("#txtApe").val()
            //});
            $.ajax({
                "type": "POST",
                "url": "Perm_Usu.aspx/IRIS_WEBF_BUSCA_USUARIO_TODOS",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                //"dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        $("#Div_Tabla").empty();
                        Fill_DataTable();
                        Hide_Modal();
                        //console.log('>>>LLENADO COMPLETADO<<<');
                        //console.log('');
                    } else {
                        //console.log('>>>0 RESULTADOS<<<');
                        //console.log('');
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

                    //console.log('>>>ERROR EN LLENADO<<<');
                    //console.log('');
                }
            });
        }



        //-------------------------------------------------- BUSCAR USUARIO CLICK TABLE----------------------------------------------------|
        var Mx_Dtt_Existente = [
            {
                "USU_NIC": 0,
                "USU_PASS": 0,
                "ID_PER_USU": 0,
                "USU_NOMBRE": 0,
                "USU_APELLIDO": 0,
                "ID_ESTADO": 0,
                "ID_PROFESION": 0,
                "USU_RUT": 0,
                "USU_DIR": 0,
                "ID_REL_CIU_COM": 0,
                "USU_FONO": 0,
                "USU_MOVIL": 0,
                "USU_EMAIL": 0,
                "ID_CARGO": 0,
                "USU_FNAC": 0,
                "ID_CIUDAD": 0,
                "ID_USUARIO": 0
            }
        ];

        function Ajax_DataTable_Ate_ONCLICK(ID_USUARIO) {
            //modal_show();
            //console.log("Inicializando petición de datos:");
            //console.log('"DataTable"');
            var Data_Par = JSON.stringify({
                "ID_USUARIO": ID_USUARIO
            });
            $.ajax({
                "type": "POST",
                "url": "Perm_Usu.aspx/IRIS_WEBF_BUSCA_USUARIO_POR_ID",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                //"dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Existente = JSON.parse(json_receiver);

                        ID_UPDATE_USUARIO = Mx_Dtt_Existente[0].ID_USUARIO;

                        $("#txtRutOLD").val(Mx_Dtt_Existente[0].USU_RUT);
                        $("#txtNombreOLD").val(Mx_Dtt_Existente[0].USU_NOMBRE);
                        $("#txtApellidoOLD").val(Mx_Dtt_Existente[0].USU_APELLIDO);
                        $("#txtNickOLD").val(Mx_Dtt_Existente[0].USU_NIC);
                        $("#txtPassOLD").val(Mx_Dtt_Existente[0].USU_PASS);

                        for (i = 0; i < Mx_Dtt_Existente.length; ++i) {
                            var date_x = Mx_Dtt_Existente[i].USU_FNAC;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Existente[i].USU_FNAC = Date_Change;
                        }

                        $("#fechaOLD").val(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Existente[0].USU_FNAC);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "-" + mm + "-" + yy);
                        }),
                        $("#txtDireccionOLD").val(Mx_Dtt_Existente[0].USU_DIR);
                        $("#txtEmailOLD").val(Mx_Dtt_Existente[0].USU_EMAIL);
                        $("#txtFonoOLD").val(Mx_Dtt_Existente[0].USU_FONO);
                        $("#txtMovilOLD").val(Mx_Dtt_Existente[0].USU_MOVIL);
                        $("#DdlCiudadOLD").val(Mx_Dtt_Existente[0].ID_CIUDAD);
                        $("#DdlComunaOLD").val(Mx_Dtt_Existente[0].ID_REL_CIU_COM);
                        $("#DdlProfesionOLD").val(Mx_Dtt_Existente[0].ID_PROFESION);
                        $("#DdlCargoOLD").val(Mx_Dtt_Existente[0].ID_CARGO);
                        $("#DdlEstadoOLD").val(Mx_Dtt_Existente[0].ID_ESTADO);

                        $("#eModal_Old_User").modal('hide');
                        $("#eModal_Old_User").modal('show');
                        //console.log('>>>LLENADO COMPLETADO<<<');
                        //console.log('');
                        Hide_Modal();
                    } else {
                        //console.log('>>>0 RESULTADOS<<<');
                        //console.log('');
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

                    //console.log('>>>ERROR EN LLENADO<<<');
                    //console.log('');
                }
            });
        }

        //------------------------------------------------ CREAR USUARIO -------------------------------------------------

        function Ajax_GRABA_USUARIO() {
            modal_show();
            //console.log("Inicializando petición de datos:");
            //console.log('"Creando Usuario.."');
            var Data_Par = JSON.stringify({
                "USU_RUT": $("#txtRut").val(),
                "NOMBRE_USU": $("#txtNombre").val(),
                "APE_USU": $("#txtApellido").val(),
                "FNAC_USU": $("#fecha ").val(),
                "DIR_USU": $("#txtDireccion").val(),
                "EMAIL_USU": $("#txtEmail").val(),
                "ID_EST_USU": $("#DdlEstado").val(),
                "ID_CIU_COM": $("#DdlComuna").val(),
                "ID_PRO_USU": $("#DdlProfesion").val(),
                "ID_CAR_USU": $("#DdlCargo").val(),
                "USUARIO": $("#txtNick").val(),
                "PASS": $("#txtPass").val(),
                "FONO": $("#txtFono").val(),
                "MOVIL": $("#txtMovil").val(),
                "USU_ADMIN": $("#Ddl_Permiso").val(),
                "USU_TM": $("#Ddl_LugarTM").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Perm_Usu.aspx/IRIS_WEBF_GRABA_USUARIO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                //"dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        $("#eModal_New_User").modal('hide');
                        $("#mError_AAH h4").text("Funcionario Creado");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("El funcionario ha sido creado satisfactoriamente.");
                        $("#mError_AAH").modal();
                        Ajax_DataTable();
                        //Hide_Modal();
                    } else {
                        //console.log('>>>SIN CREACION RESULTADOS<<<');
                        //console.log('');
                        Hide_Modal();
                        $("#mError_AAH h4").text("Falla Creación");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se ha podido completar la creación del funcionario.");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                    //console.log('>>>ERROR EN LLENADO<<<');
                    //console.log('');
                }
            });
        }

        //------------------------------------------------ UPDATE USUARIO -------------------------------------------------

        function Ajax_UPDATE_USUARIO() {
            modal_show();
            //console.log("Inicializando petición de datos:");
            //console.log('"UPDATE Usuario.."');
            var Data_Par = JSON.stringify({
                "ID_USU": ID_UPDATE_USUARIO,
                "RUT_USU": $("#txtRutOLD").val(),
                "NOMBRE_USU": $("#txtNombreOLD").val(),
                "APE_USU": $("#txtApellidoOLD").val(),
                "FNAC_USU": $("#fechaOLD").val(),
                "DIR_USU": $("#txtDireccionOLD").val(),
                "EMAIL_USU": $("#txtEmailOLD").val(),
                "ID_EST_USU": $("#DdlEstadoOLD").val(),
                "ID_REL_CIU": $("#DdlComunaOLD").val(),
                "ID_PRO_USU": $("#DdlProfesionOLD").val(),
                "ID_CAR_USU": $("#DdlCargoOLD").val(),
                "USUARIO": $("#txtNickOLD").val(),
                "PASS": $("#txtPassOLD").val(),
                "ID_PER_USU": 1,
                "FONO": $("#txtFonoOLD").val(),
                "MOVIL": $("#txtMovilOLD").val(),
                "USU_ADMIN": $("#Ddl_PermisoOLD").val(),
                "USU_TM": $("#Ddl_LugarTMOLD").val(),
                "USU_FIRMA": B64Firma
            });
            $.ajax({
                "type": "POST",
                "url": "Perm_Usu.aspx/IRIS_WEBF_UPDATE_USUARIOS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                //"dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        $("#eModal_Old_User").modal('hide');
                        $("#mError_AAH h4").text("Funcionario Actualizado");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("Los datos del usuario han sido actualizados satisfactoriamente.");
                        $("#mError_AAH").modal();
                        Ajax_DataTable();
                        //Hide_Modal();
                    } else {
                        //console.log('>>>Actualización No Completada<<<');
                        //console.log('');
                        Hide_Modal();
                        $("#mError_AAH h4").text("Actualización No Completada");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se ha podido actualizar el funcionario.");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                    //console.log('>>>ERROR EN LLENADO<<<');
                    //console.log('');
                }
            });
        }

        //Llenar DropDownList Permiso
        function Fill_Ddl_Permiso() {
            $("#Ddl_Permiso").empty();

            //for (y = 0; y < Mx_Dtt_Permisos.length; ++y) {
            //    $("<option>", {
            //        "value": Mx_Dtt_Permisos[y].ID_PER_USU
            //    }).text(Mx_Dtt_Permisos[y].PER_USU_DESC).appendTo("#Ddl_Permiso");

            //}

            $("<option>", { "value": 0 }).text("Usuario Normal").appendTo("#Ddl_Permiso");
            $("<option>", { "value": 1 }).text("Administrador").appendTo("#Ddl_Permiso");
            $("<option>", { "value": 2 }).text("Clínica").appendTo("#Ddl_Permiso");
            $("<option>", { "value": 3 }).text("Usuario Gestion").appendTo("#Ddl_Permiso");
            $("<option>", { "value": 4 }).text("Usuario Agenda").appendTo("#Ddl_Permiso");

            $("<option>", { "value": 0 }).text("Usuario Normal").appendTo("#Ddl_PermisoOLD");
            $("<option>", { "value": 1 }).text("Administrador").appendTo("#Ddl_PermisoOLD");
            $("<option>", { "value": 2 }).text("Clínica").appendTo("#Ddl_PermisoOLD");
            $("<option>", { "value": 3 }).text("Usuario Gestion").appendTo("#Ddl_PermisoOLD");
            $("<option>", { "value": 4 }).text("Usuario Agenda").appendTo("#Ddl_PermisoOLD");

        };



        //Llenar DropDownList Estado
        function Fill_Ddl_Estado() {
            $("#DdlEstado").empty();
            $("#DdlEstadoOLD").empty();

            for (y = 0; y < Mx_Ddl_Mantenedor.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl_Mantenedor[y].ID_ESTADO
                }).text(Mx_Ddl_Mantenedor[y].EST_DESCRIPCION).appendTo("#DdlEstado");

                $("<option>", {
                    "value": Mx_Ddl_Mantenedor[y].ID_ESTADO
                }).text(Mx_Ddl_Mantenedor[y].EST_DESCRIPCION).appendTo("#DdlEstadoOLD");
            }
        };

        //Llenar DropDownList Profesion
        function Fill_Ddl_Profesion() {
            $("#DdlProfesion").empty();
            $("#DdlProfesionOLD").empty();

            for (y = 0; y < Mx_Dtt_Profesion.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_Profesion[y].ID_PRO
                }).text(Mx_Dtt_Profesion[y].PRO_DESC).appendTo("#DdlProfesion");

                $("<option>", {
                    "value": Mx_Dtt_Profesion[y].ID_PRO
                }).text(Mx_Dtt_Profesion[y].PRO_DESC).appendTo("#DdlProfesionOLD");
            }
        };

        //Llenar DropDownList Cargo
        function Fill_Ddl_Cargo() {
            $("#DdlCargo").empty();
            $("#DdlCargoOLD").empty();

            for (y = 0; y < Mx_Dtt_Cargo.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_Cargo[y].ID_CAR
                }).text(Mx_Dtt_Cargo[y].CARD_DESC).appendTo("#DdlCargo");

                $("<option>", {
                    "value": Mx_Dtt_Cargo[y].ID_CAR
                }).text(Mx_Dtt_Cargo[y].CARD_DESC).appendTo("#DdlCargoOLD");
            }
        };


        //Llenar DropDownList Ciudad
        function Fill_Ddl_Cuidad() {
            $("#DdlCiudad").empty();
            $("#DdlCiudadOLD").empty();

            for (y = 0; y < Mx_Ciudad.length; ++y) {
                $("<option>", {
                    "value": Mx_Ciudad[y].ID_CIUDAD
                }).text(Mx_Ciudad[y].CIU_DESC).appendTo("#DdlCiudad");

                $("<option>", {
                    "value": Mx_Ciudad[y].ID_CIUDAD
                }).text(Mx_Ciudad[y].CIU_DESC).appendTo("#DdlCiudadOLD");
            }
        };

        //Llenar DropDownList Comuna
        function Fill_Ddl_Comuna() {
            $("#DdlComuna").empty();
            $("#DdlComunaOLD").empty();

            for (y = 0; y < Mx_Comuna.length; ++y) {
                $("<option>", {
                    "value": Mx_Comuna[y].ID_REL_CIU_COM
                }).text(Mx_Comuna[y].COM_DESC).appendTo("#DdlComuna");

                $("<option>", {
                    "value": Mx_Comuna[y].ID_REL_CIU_COM
                }).text(Mx_Comuna[y].COM_DESC).appendTo("#DdlComunaOLD");
            }
        };

        function Fill_Ddl_LugarTM() {
            //$("#Ddl_LugarTM").empty();

            $("<option>", { "value": "xx" }).text("Seleccionar").appendTo("#Ddl_LugarTM");

            for (y = 0; y < Mx_Dtt_LugarTM.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_LugarTM[y].ID_PROCEDENCIA
                }).text(Mx_Dtt_LugarTM[y].PROC_DESC).appendTo("#Ddl_LugarTM");
            }
        };
        //
        function Fill_Ddl_LugarTMOLD() {
            //$("#Ddl_LugarTMOLD").empty();
            $("<option>", { "value": "xx" }).text("Seleccionar").appendTo("#Ddl_LugarTMOLD");

            for (y = 0; y < Mx_Dtt_LugarTMOLD.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_LugarTMOLD[y].ID_PROCEDENCIA
                }).text(Mx_Dtt_LugarTMOLD[y].PROC_DESC).appendTo("#Ddl_LugarTMOLD");
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
                    $("<th>", { "class": "textoReducido" }).text("Usuario"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Activo"),
                    $("<th>", { "class": "textoReducido" }).text("Perfil"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar de TM")

                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_DataTable_Ate_ONCLICK("` + Mx_Dtt[i].ID_USUARIO + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].USU_NIC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].USU_NOMBRE + " " + Mx_Dtt[i].USU_APELLIDO),
                        $("<td>", {
                            "class": "text-center"
                        }).html("<input type='checkbox' id='chekito" + i + "' />"),
                        $("<td>").css("text-align", "left").text(function () {
                            if (Mx_Dtt[i].USU_ADMIN == 1) {
                                $(this).css("cssText", "text-align:left;").text("Administrador");
                            }
                            else if (Mx_Dtt[i].USU_ADMIN == 2) {
                                $(this).css("cssText", "text-align:left;").text("Clínico");
                            }
                            else if (Mx_Dtt[i].USU_ADMIN == 3) {
                                $(this).css("cssText", "text-align:left;").text("Usuario Gestión");
                            }
                            else if (Mx_Dtt[i].USU_ADMIN == 4) {
                                $(this).css("cssText", "text-align:left;").text("Usuario Agenda");
                            }
                            else {
                                $(this).css("cssText", "text-align:left;").text("Usuario Normal");
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].proc_desc)
                    )
                );
                if (Mx_Dtt[i].ID_ESTADO == 1) {
                    $("#chekito" + i).prop("checked", true);
                }
                $("<tr>").attr("id", i + 1);
            }
            active_tr();
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
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <%--//---------------------------------------------- MODAL LISTADO DE EXÁMENES DE LA ATENCIÓN ------------------------------------%>
    <div class="modal fade" id="eModal_New_User" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Creación de Nuevo Funcionario</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-4">
                            <label>Rut: </label>
                            <input id="txtRut" class="form-control textoReducido mayus" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label>Nombre: </label>
                            <input id="txtNombre" class="form-control textoReducido mayus" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label>Apellido: </label>
                            <input id="txtApellido" class="form-control textoReducido mayus" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label>Nick: </label>
                            <input id="txtNick" class="form-control textoReducido mayus" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label>Password: </label>
                            <input id="txtPass" class="form-control textoReducido mayus" type="password" />
                        </div>
                        <div class="col-md-4">
                            <label for="fecha">F. Nacimiento:</label>
                            <div class='input-group date' id='Txt_Date01'>
                                <input type='text' id="fecha" class="form-control textoReducido" readonly="true" placeholder="f. nacimiento..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Direccion: </label>
                            <input id="txtDireccion" class="form-control textoReducido mayus" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label>Email: </label>
                            <input id="txtEmail" class="form-control textoReducido mayus" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label>Fono: </label>
                            <input id="txtFono" class="form-control textoReducido mayus" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label>Celular: </label>
                            <input id="txtMovil" class="form-control textoReducido mayus" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label for="DdlCiudad">Ciudad:</label>
                            <select id="DdlCiudad" class="form-control textoReducido mayus">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-md-4">
                            <label for="DdlComuna">Comuna:</label>
                            <select id="DdlComuna" class="form-control textoReducido">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-md-5">
                            <label for="Ddl_Permiso">Permiso:</label>
                            <select id="Ddl_Permiso" class="form-control textoReducido mayus">
                            </select>
                        </div>
                        <div class="col-md-2"></div>
                        <div class="col-md-5">
                            <label for="Ddl_LugarTM">Lugar de TM:</label>
                            <select id="Ddl_LugarTM" class="form-control textoReducido mayus">
                            </select>
                        </div>
                        <div class="col-md-4">
                            <label for="DdlProfesion">Profesión:</label>
                            <select id="DdlProfesion" class="form-control textoReducido mayus">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-md-4">
                            <label for="DdlCargo">Cargo:</label>
                            <select id="DdlCargo" class="form-control textoReducido mayus">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-md-4">
                            <label for="DdlEstado">Estado:</label>
                            <select id="DdlEstado" class="form-control textoReducido mayus">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="Btn_Limpiar" class="btn btn-info">Limpiar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Salir</button>
                    <button type="button" id="btn_Guardar" class="btn btn-success">Guardar</button>
                </div>
            </div>
        </div>
    </div>


    <%---------------------------------------------------    MODAL EDITAR USUARIO   ----------------------------------------%>

    <div class="modal fade" id="eModal_Old_User" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="ssss">Editar Funcionario</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-4">
                            <label>Rut: </label>
                            <input id="txtRutOLD" class="form-control textoReducido mayus" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label>Nombre: </label>
                            <input id="txtNombreOLD" class="form-control textoReducido mayus" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label>Apellido: </label>
                            <input id="txtApellidoOLD" class="form-control textoReducido mayus" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label>Nick: </label>
                            <input id="txtNickOLD" class="form-control textoReducido mayus" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label>Password: </label>
                            <input id="txtPassOLD" class="form-control textoReducido mayus" type="password" />
                        </div>
                        <div class="col-md-4">
                            <label for="fecha">F. Nacimiento:</label>
                            <div class='input-group date' id='Txt_Date01OLD'>
                                <input type='text' id="fechaOLD" class="form-control textoReducido" readonly="true" placeholder="f. nacimiento..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Direccion: </label>
                            <input id="txtDireccionOLD" class="form-control textoReducido mayus" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label>Email: </label>
                            <input id="txtEmailOLD" class="form-control textoReducido mayus" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label>Fono: </label>
                            <input id="txtFonoOLD" class="form-control textoReducido mayus" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label>Celular: </label>
                            <input id="txtMovilOLD" class="form-control textoReducido mayus" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label for="DdlCiudadOLD">Ciudad:</label>
                            <select id="DdlCiudadOLD" class="form-control textoReducido mayus">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-md-4">
                            <label for="DdlComunaOLD">Comuna:</label>
                            <select id="DdlComunaOLD" class="form-control textoReducido">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-md-4">
                            <label for="DdlProfesionOLD">Profesión:</label>
                            <select id="DdlProfesionOLD" class="form-control textoReducido mayus">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-md-4">
                            <label for="DdlCargoOLD">Cargo:</label>
                            <select id="DdlCargoOLD" class="form-control textoReducido mayus">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-md-4">
                            <label for="DdlEstadoOLD">Estado:</label>
                            <select id="DdlEstadoOLD" class="form-control textoReducido mayus">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-md-4">
                            <label for="Ddl_PermisoOLD">Permiso:</label>
                            <select id="Ddl_PermisoOLD" class="form-control textoReducido mayus">
                            </select>
                        </div>
                        <div class="col-md-4">
                            <label for="Ddl_LugarTMOLD">Lugar de TM:</label>
                            <select id="Ddl_LugarTMOLD" class="form-control textoReducido mayus">
                            </select>
                        </div>
                        <div class="col-md-4">
                            <label for="Inp_Image">Firma:</label>
                            <label class="custom-file">
                                <input type="file" id="Inp_Image" class="custom-file-input">
                                <span class="custom-file-control" style="border-color: #868e96;"></span>
                            </label>
                            <style>
                                .custom-file-control:before {
                                    content: "Buscar";
                                    border-color: #868e96;
                                }

                                .custom-file-control:after {
                                    content: "Agregue Firma...";
                                    border-color: #868e96;
                                }

                                .custom-file-control.selected::after {
                                    content: "" !important;
                                }
                            </style>
                            <script>
                              
                                $('.custom-file-input').on('change', function () {
                                    var fileName = $(this).val().split('\\').slice(-1)[0];
                                    $(this).next('.custom-file-control').addClass("selected").html(fileName);
                                })
                            </script>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Salir</button>
                    <button type="button" id="btnEditar" class="btn btn-success">Actualizar</button>
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
                        Crear/Modificar Usuarios
                    </h5>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10">
                        <div class="row">
                            <div class="col-lg-3">
                                <label for="Btn_New_User">Nuevo Usuario:</label>
                                <button type="button" class="btn btn-block btn-info p-1" id="Btn_New_User">Crear Nuevo Usuario</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
                <div class="row" id="Id_Conte">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10" id="Paciente">
                        <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list"></i>Listado de Funcionarios</h5>
                        <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
