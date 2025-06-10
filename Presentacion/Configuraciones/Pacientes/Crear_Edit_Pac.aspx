<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Crear_Edit_Pac.aspx.vb" Inherits="Presentacion.Crear_Edit_Pac" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
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
        $(document).ready(function () {
            Ajax_Diagnostico();
            Ajax_Sexo();
            Ajax_Nacionalidad();
            Ajax_Ciudad();

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


            $(".block_wait").fadeOut(0);
            $("#Div_Tabla").empty();
            $("#Div_Tabla").show();
            $("#Id_Conte").hide();

            $("#DdlCiudad").change(function () {
                Ajax_Comuna();
            })

            $("#Btn_Limpiar").click(function () {
                Mx_Dtt_Antiguos[0].ID_PACIENTE;

                $("#txtRut").val("");
                $("#txtNom").val("");
                $("#txtApe").val("");
                $("#DdlSexo").val(0);
                $("#Txt_Date01 input").val(dateNow);
                $("#DdlNacionalidad").val(0);
                $("#txtNuevoDireccion").val("");
                $("#txtNuevoTelefono1").val("");
                $("#txtNuevoCelular1").val("");
                $("#txtNuevoTelefono2").val("");
                $("#txtNuevoCelular2").val("");
                $("#txtNuevoEmail").val("");
                $("#DdlDiagnostico").val(0);
                $("#DdlEstado").val(0);
            });
            
            //Registrar evento Click del Botón Buscar       
            $("#Btn_Buscar").click(function () {

                if ($("#txtRut").val() == "" && $("#txtNom").val() == "" && $("#txtApe").val() == ""){

                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, ingrese el campo a buscar");
                    $("#mError_AAH").modal();

                } else {
                    $("#Div_Tabla").empty();
                    Ajax_DataTable();
                }


            });

            $("#txtRut").focusout(function () {
                if ($("#txtRut").val() != "") {

                    //Capturar Anáqlisis del RUT
                    var obj_RUT = Valid_RUT($("#txtRut").val());

                    if (obj_RUT.Valid == false) {
                        var str_Error = "El RUT ingresado no es Válido, ";
                        str_Error += "ingrese en el campo de texto un RUT válido.";

                        $("#mError_AAH h5").text("Error:");
                        $("#button_modal").attr("class", "btn btn-danger");

                        $("#mError_AAH p").text(str_Error);
                        $("#mError_AAH").modal();

                        $("#txtRut").val("");
                        $("#txtRut").css({
                            "border-color": "red"
                        });
                    } else {
                        $("#txtRut").css({
                            "border-color": "green"
                        });
                        $("#txtRut").val(obj_RUT.Format);
                        Ajax_Buscar_por_rut();
                    }
                }
            });
            //----------------- RUT NUEVOS DATOS ---------------------|
            $("#txtNuevoRut").focusout(function () {
                if ($("#txtNuevoRut").val() != "") {

                    //Capturar Anáqlisis del RUT
                    var obj_RUT = Valid_RUT($("#txtNuevoRut").val());

                    if (obj_RUT.Valid == false) {
                        var str_Error = "El RUT ingresado no es Válido, ";
                        str_Error += "ingrese en el campo de texto un RUT válido.";

                        $("#mError_AAH h5").text("Error:");
                        $("#button_modal").attr("class", "btn btn-danger");

                        $("#mError_AAH p").text(str_Error);
                        $("#mError_AAH").modal();

                        $("#txtNuevoRut").val("");
                        $("#txtNuevoRut").css({
                            "border-color": "red"
                        });
                    } else {
                        $("#txtNuevoRut").css({
                            "border-color": "green"
                        });
                        $("#txtNuevoRut").val(obj_RUT.Format);
                    }
                }
            });

            //Registrar evento Click del Botón EDITAR
            $("#Btn_Guardar").click(function () {
            
                if (Mx_Dtt_Antiguos[0].ID_PACIENTE != 0) {
                    $("#mError_AAH h4").text("Paciente Existente");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("El RUT ya se encuentra registrado en el sistema, presione botón MODIFICAR.");
                    $("#mError_AAH").modal();
                } else {
                    var sum = 0;
                    if ($("#txtRut").val() == "") {
                        $("#txtRut").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#txtRut").css({
                            "border-color": "green"
                        });
                    }

                    if ($("#txtNom").val() == "") {
                        $("#txtNom").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#txtNom").css({
                            "border-color": "green"
                        });
                    }
                    if ($("#txtApe").val() == "") {
                        $("#txtApe").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#txtApe").css({
                            "border-color": "green"
                        });
                    }
                    if ($("#DdlSexo").val() == 0) {
                        $("#DdlSexo").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#DdlSexo").css({
                            "border-color": "green"
                        });
                    }
                    if ($("#DdlNacionalidad").val() == 0) {
                        $("#DdlNacionalidad").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#DdlNacionalidad").css({
                            "border-color": "green"
                        });
                    }
                    if ($("#txtNuevoDireccion").val() == "") {
                        $("#txtNuevoDireccion").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#txtNuevoDireccion").css({
                            "border-color": "green"
                        });
                    }
                    if ($("#DdlDiagnostico").val() == 0) {
                        $("#DdlDiagnostico").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#DdlDiagnostico").css({
                            "border-color": "green"
                        });
                    }
                    if ($("#DdlEstado").val() == 0) {
                        $("#DdlEstado").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#DdlEstado").css({
                            "border-color": "green"
                        });
                    }
                    if (sum == 8) {

                        IRIS_WEBF_GRABA_PACIENTE();

                    } else {
                        $("#mError_AAH h4").text("Datos Faltantes");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("Por favor, Ingrese los datos faltantes.");
                        $("#mError_AAH").modal();
                    }
                }           

            });

            //Registrar evento Click del Botón EDITAR
            $("#Btn_Update").click(function () {
                if (Mx_Dtt_Antiguos[0].ID_PACIENTE == 0) {
                    $("#mError_AAH h4").text("Seleccionar Paciente");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Debe buscar o seleccionar un usuario.");
                    $("#mError_AAH").modal();
                } else {
                    var sum = 0;
                    if ($("#txtRut").val() == "") {
                        $("#txtRut").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#txtRut").css({
                            "border-color": "green"
                        });
                    }

                    if ($("#txtNom").val() == "") {
                        $("#txtNom").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#txtNom").css({
                            "border-color": "green"
                        });
                    }
                    if ($("#txtApe").val() == "") {
                        $("#txtApe").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#txtApe").css({
                            "border-color": "green"
                        });
                    }
                    if ($("#DdlSexo").val() == 0) {
                        $("#DdlSexo").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#DdlSexo").css({
                            "border-color": "green"
                        });
                    }
                    if ($("#DdlNacionalidad").val() == 0) {
                        $("#DdlNacionalidad").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#DdlNacionalidad").css({
                            "border-color": "green"
                        });
                    }
                    if ($("#txtNuevoDireccion").val() == "") {
                        $("#txtNuevoDireccion").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#txtNuevoDireccion").css({
                            "border-color": "green"
                        });
                    }
                    if ($("#DdlDiagnostico").val() == 0) {
                        $("#DdlDiagnostico").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#DdlDiagnostico").css({
                            "border-color": "green"
                        });
                    }
                    if ($("#DdlEstado").val() == 0) {
                        $("#DdlEstado").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#DdlEstado").css({
                            "border-color": "green"
                        });
                    }
                    if (sum == 8) {

                        Ajax_update();

                    } else {
                        $("#mError_AAH h4").text("Datos Faltantes");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("Por favor, Ingrese los datos faltantes.");
                        $("#mError_AAH").modal();
                    }
                }
               

            });

            $("#Btn_Eliminar").click(function () {
                if (Mx_Dtt_Antiguos[0].ID_PACIENTE == 0) {
                    $("#mError_AAH h4").text("Seleccionar Paciente");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Debe buscar o seleccionar un usuario.");
                    $("#mError_AAH").modal();
                } else {
                    $("#mError_AAH_CONFIRMAR").modal('hide');
                    $("#mError_AAH_CONFIRMAR h4").text("Confirmación");
                    $("#mError_AAH_CONFIRMAR p").text("¿Está seguro que desea eliminar al paciente?");
                    $("#mError_AAH_CONFIRMAR").modal();
                    }
                
            });

            $("#Btn_Confirmar").click(function () {
                Ajax_delete();
            });
            
        });
    </script>
    <script>
        //-------------------------------------------------- GRABA PACIENTE ----------------------------------------------------|
        function IRIS_WEBF_GRABA_PACIENTE() {
            modal_show();

            var Data_Par = JSON.stringify({
                "RUT_PAC": $("#txtRut").val(),
                "NOMBRE_PAC": $("#txtNom").val(),
                "APE_PAC": $("#txtApe").val(),
                "ID_SEXO": $("#DdlSexo").val(),
                "FNAC_PAC": $("#fecha ").val(),
                "ID_NACIONALIDAD": $("#DdlNacionalidad").val(),
                "DIR_PAC": $("#txtNuevoDireccion").val(),
                "ID_CIU_COM": $("#DdlComuna").val(),
                "FONO1": $("#txtNuevoTelefono1").val(),
                "FONO2": $("#txtNuevoTelefono2").val(),
                "MOVIL1": $("#txtNuevoCelular1").val(),
                "MOVIL2": $("#txtNuevoCelular2").val(),
                "EMAIL_PAC": $("#txtNuevoEmail").val(),
                "ID_DIAGNOSTICO": $("#DdlDiagnostico").val(),
                "ID_ESTADO": $("#DdlEstado").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Pac.aspx/IRIS_WEBF_GRABA_PACIENTE",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt_Antiguos[0].ID_PACIENTE = 0;
                        $("#DataTable").empty();
                        $("#txtRut").val("");
                        $("#txtNom").val("");
                        $("#txtApe").val("");
                        $("#DdlSexo").val(0);
                        var dateNow = moment().format("DD-MM-YYYY");
                        $("#Txt_Date01 input").val(dateNow);
                        $("#DdlNacionalidad").val(0);
                        $("#txtNuevoDireccion").val("");
                        $("#txtNuevoTelefono1").val("");
                        $("#txtNuevoCelular1").val("");
                        $("#txtNuevoTelefono2").val("");
                        $("#txtNuevoCelular2").val("");
                        $("#txtNuevoEmail").val("");
                        $("#DdlDiagnostico").val(0);
                        $("#DdlEstado").val(0);

                        Hide_Modal();
                        $("#DataTable").empty();
                        $("#mError_AAH h4").text("Paciente Creado");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("El paciente se ha creado de forma exitosa.");
                        $("#mError_AAH").modal();
                    } else {

                        Hide_Modal();
                        $("#DataTable").empty();
                        $("#mError_AAH h4").text("Sin Creación");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han podido realizar la creación del paciente.");
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

        //------------------------------------------------- TXT RUT CHANGE ------------------------------
        var Mx_Dtt_Por_Rut = [
        {
            "ID_PACIENTE": 0,
            "PAC_RUT": 0,
            "PAC_NOMBRE": 0,
            "ID_SEXO": 0,
            "PAC_APELLIDO": 0,
            "PAC_FNAC": 0,
            "ID_NACIONALIDAD": 0,
            "PAC_DIR": 0,
            "ID_REL_CIU_COM": 0,
            "PAC_FONO1": 0,
            "PAC_FONO2": 0,
            "PAC_MOVIL1": 0,
            "PAC_MOVIL2": 0,
            "PAC_EMAIL": 0,
            "PAC_OBS_PER": 0,
            "ID_DIAGNOSTICO": 0,
            "PAC_OBS_PERMA": 0,
            "ID_ESTADO": 0,
            "EST_DESCRIPCION": 0,
            "DIA_DESC": 0,
            "SEXO_DESC": 0,
            "NAC_DESC": 0,
            "COM_DESC": 0,
            "CIU_DESC": 0
        }
        ];

        function Ajax_Buscar_por_rut() {
            modal_show();


            var Data_Par = JSON.stringify({
                "rut": $("#txtRut").val()
            });
            //$(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Pac.aspx/Llenar_rut",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Antiguos = JSON.parse(json_receiver);
                        $("#DataTable").empty();
                        for (i = 0; i < Mx_Dtt_Antiguos.length; ++i) {
                            var date_x = Mx_Dtt_Antiguos[i].PAC_FNAC;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Antiguos[i].PAC_FNAC = Date_Change;
                        }
                        

                        $("#txtRut").val(Mx_Dtt_Antiguos[0].PAC_RUT);
                        $("#txtNom").val(Mx_Dtt_Antiguos[0].PAC_NOMBRE);
                        $("#txtApe").val(Mx_Dtt_Antiguos[0].PAC_APELLIDO);
                        $("#DdlSexo").val(Mx_Dtt_Antiguos[0].ID_SEXO);
                        $("#DdlNacionalidad").val(Mx_Dtt_Antiguos[0].ID_NACIONALIDAD);
                        $("#txtNuevoDireccion").val(Mx_Dtt_Antiguos[0].PAC_DIR);
                        //$("#DdlCiudad").val(Mx_Dtt_Antiguos[0].CIU_DESC);
                        //$("#DdlComuna").val(Mx_Dtt_Antiguos[0].ID_REL_CIU_COM);
                        $("#txtNuevoTelefono1").val(Mx_Dtt_Antiguos[0].PAC_FONO1);
                        $("#txtNuevoTelefono2").val(Mx_Dtt_Antiguos[0].PAC_FONO2);
                        $("#txtNuevoCelular1").val(Mx_Dtt_Antiguos[0].PAC_MOVIL1);
                        $("#txtNuevoCelular2").val(Mx_Dtt_Antiguos[0].PAC_MOVIL2);
                        $("#txtNuevoEmail").val(Mx_Dtt_Antiguos[0].PAC_EMAIL);

                        
                        if (Mx_Dtt_Antiguos[0].ID_ESTADO == 2) {
                            $("#DdlEstado").val(0);
                        } else {
                            $("#DdlEstado").val(Mx_Dtt_Antiguos[0].ID_ESTADO);
                        }
                        $("#DdlDiagnostico").val(Mx_Dtt_Antiguos[0].ID_DIAGNOSTICO);
                        

                        $("#fecha").val(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Antiguos[0].PAC_FNAC);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);
                        }),

                        Hide_Modal();
                    } else {
                        Mx_Dtt_Antiguos[0].ID_PACIENTE = 0;
                        $("#DataTable").empty();
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }


        //--------------------------------------------------BUSCAR PACIENTE----------------------------------------------------|
        var Mx_Dtt = [
            {
                "ID_PACIENTE": 0,
                "PAC_RUT": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "SEXO_DESC": 0,
                "PAC_DIR": 0,
                "PAC_FONO1": 0,
                "PAC_MOVIL1": 0,
                "PAC_EMAIL": 0,
                "PAC_OBS_PERMA": 0,
                "DIA_DESC": 0,
                "ID_SEXO": 0,
                "ID_ESTADO": 0
            }
        ];

        function Ajax_DataTable() {
            modal_show();


            var Data_Par = JSON.stringify({
                "RUT_P": $("#txtRut").val(),
                "NOM_P": $("#txtNom").val(),
                "APE_P": $("#txtApe").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Pac.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        $("#DataTable").empty();
                        Fill_DataTable();
                        Hide_Modal();


                    } else {


                        Hide_Modal();
                        $("#DataTable").empty();
                        Mx_Dtt_Antiguos[0].ID_PACIENTE = 0;
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

        //------------------------------------------------------- ANTIGUOS ----------------------------------------------------|
        var Mx_Dtt_Antiguos = [
        {
            "ID_PACIENTE": 0,
            "PAC_RUT": 0,
            "PAC_NOMBRE": 0,
            "ID_SEXO": 0,
            "PAC_APELLIDO": 0,
            "PAC_FNAC": 0,
            "ID_NACIONALIDAD": 0,
            "PAC_DIR": 0,
            "ID_REL_CIU_COM": 0,
            "PAC_FONO1": 0,
            "PAC_FONO2": 0,
            "PAC_MOVIL1": 0,
            "PAC_MOVIL2": 0,
            "PAC_EMAIL": 0,
            "PAC_OBS_PER": 0,
            "ID_DIAGNOSTICO": 0,
            "PAC_OBS_PERMA": 0,
            "ID_ESTADO": 0,
            "EST_DESCRIPCION": 0,
            "DIA_DESC": 0,
            "SEXO_DESC": 0,
            "NAC_DESC": 0,
            "COM_DESC": 0,
            "CIU_DESC": 0
        }
        ];


        function Ajax_DataTable_Antiguos(ID_PAC) {
            modal_show();


            var Data_Par = JSON.stringify({
                "ID_PAC": ID_PAC
            });
            //$(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Pac.aspx/Llenar_DataTable_Antiguos",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Antiguos = JSON.parse(json_receiver);
                        Ajax_Diagnostico();
                        Ajax_Sexo();
                        Ajax_Nacionalidad();
                        Ajax_Ciudad();
                        //Ajax_Comuna();
                        $("#DataTable_Antiguos").empty();
                        $("#DataTable_Antiguos2").empty();
                        $("#DataTable_Antiguos3").empty();
                        $("#DataTable_Antiguos4").empty();
                        for (i = 0; i < Mx_Dtt_Antiguos.length; ++i) {
                            var date_x = Mx_Dtt_Antiguos[i].PAC_FNAC;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Antiguos[i].PAC_FNAC = Date_Change;
                        }

                        $("#txtRut").val(Mx_Dtt_Antiguos[0].PAC_RUT);
                        $("#txtNom").val(Mx_Dtt_Antiguos[0].PAC_NOMBRE);
                        $("#txtApe").val(Mx_Dtt_Antiguos[0].PAC_APELLIDO);
                        $("#DdlSexo").val(Mx_Dtt_Antiguos[0].ID_SEXO);
                        $("#DdlNacionalidad").val(Mx_Dtt_Antiguos[0].ID_NACIONALIDAD);
                        $("#txtNuevoDireccion").val(Mx_Dtt_Antiguos[0].PAC_DIR);
                        //$("#DdlCiudad").val(Mx_Dtt_Antiguos[0].CIU_DESC);
                        //$("#DdlComuna").val(Mx_Dtt_Antiguos[0].ID_REL_CIU_COM);
                        $("#txtNuevoTelefono1").val(Mx_Dtt_Antiguos[0].PAC_FONO1);
                        $("#txtNuevoTelefono2").val(Mx_Dtt_Antiguos[0].PAC_FONO2);
                        $("#txtNuevoCelular1").val(Mx_Dtt_Antiguos[0].PAC_MOVIL1);
                        $("#txtNuevoCelular2").val(Mx_Dtt_Antiguos[0].PAC_MOVIL2);
                        $("#txtNuevoEmail").val(Mx_Dtt_Antiguos[0].PAC_EMAIL);
                        $("#DdlEstado").val(Mx_Dtt_Antiguos[0].ID_ESTADO);
                        $("#DdlDiagnostico").val(Mx_Dtt_Antiguos[0].ID_DIAGNOSTICO);

                        $("#fecha").val(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Antiguos[0].PAC_FNAC);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);
                        }),

                        Hide_Modal();
                        

                    } else {


                        Hide_Modal();
                        $("#DataTable").empty();
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

        //--------------------------------------- JASON DIAGNOSTICO --------------------------------------------------------------------|
        var Mx_Diagnostico = [
    {
        "ID_DIAGNOSTICO": 0,
        "DIA_COD": 0,
        "DIA_DESC": 0,
        "ID_ESTADO": 0
    }
        ];

        function Ajax_Diagnostico() {

            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Pac.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Diagnostico = JSON.parse(json_receiver);
                        Fill_Ddl_diagnostico();


                    } else {


                    }
                },
                "error": function (response) {


                }
            });
        }

        //--------------------------------------- JASON SEXO ---------------------------------------------------------------------------|
        var Mx_Sexo = [
    {
        "ID_SEXO": 0,
        "SEXO_COD": 0,
        "SEXO_DESC": 0,
        "ID_ESTADO": 0
    }
        ];

        function Ajax_Sexo() {



            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Pac.aspx/IRIS_WEBF_BUSCA_SEXO",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Sexo = JSON.parse(json_receiver);
                        Fill_Ddl_Sexo();
                        $(".block_wait").hide();


                    } else {


                    }
                },
                "error": function (response) {


                }
            });
        }

        //--------------------------------------- JASON NACIONALIDAD --------------------------------------------------------------------|
        var Mx_Nacionalidad = [
    {
        "ID_NACIONALIDAD": 0,
        "NAC_COD": 0,
        "NAC_DESC": 0,
        "ID_ESTADO": 0
    }
        ];

        function Ajax_Nacionalidad() {



            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Pac.aspx/IRIS_WEBF_BUSCA_NACIONALIDAD",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Nacionalidad = JSON.parse(json_receiver);
                        Fill_Ddl_Nacionalidad();
                        $(".block_wait").hide();


                    } else {


                    }
                },
                "error": function (response) {


                }
            });
        }

        //--------------------------------------- JASON CIUDAD --------------------------------------------------------------------------|
        var Mx_Ciudad = [
    {
        "ID_CIUDAD": 0,
        "CIU_COD": 0,
        "CIU_DESC": 0,
        "ID_ESTADO": 0
    }
        ];

        function Ajax_Ciudad() {

            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Pac.aspx/IRIS_WEBF_BUSCA_CIUDAD",
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

                    } else {


                    }
                },
                "error": function (response) {

                }
            });
        }

        //--------------------------------------- JASON COMUNA --------------------------------------------------------------------------|
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

            var Data_Par = JSON.stringify({
                "ID_CIU": $("#DdlCiudad").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Pac.aspx/IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Comuna = JSON.parse(json_receiver);
                        Fill_Ddl_Comuna();


                    } else {

                    }
                },
                "error": function (response) {


                }
            });
        }

        //Json Para Ingresar Paciente ***NUEVO***

        function Ajax_update() {
            modal_show();
            var Data_Par = JSON.stringify({

                "ID_PAC": Mx_Dtt_Antiguos[0].ID_PACIENTE,
                "RUT_PAC": $("#txtRut").val(),
                "NOMBRE_PAC": $("#txtNom").val(),
                "APE_PAC": $("#txtApe").val(),
                "ID_SEXO": $("#DdlSexo").val(),
                "FNAC_PAC": $("#fecha ").val(),
                "ID_NACIONALIDAD": $("#DdlNacionalidad").val(),
                "DIR_PAC": $("#txtNuevoDireccion").val(),
                "ID_CIU_COM": $("#DdlComuna").val(),
                "FONO1": $("#txtNuevoTelefono1").val(),
                "FONO2": $("#txtNuevoTelefono2").val(),
                "MOVIL1": $("#txtNuevoCelular1").val(),
                "MOVIL2": $("#txtNuevoCelular2").val(),
                "EMAIL_PAC": $("#txtNuevoEmail").val(),
                "ID_DIAGNOSTICO": $("#DdlDiagnostico").val(),
                "ID_ESTADO": $("#DdlEstado").val()


            });

            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Pac.aspx/IRIS_WEBF_UPDATE_PACIENTES",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        $("#mError_AAH h4").text("Datos Actualizados");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("Los datos del paciente han sido actualizados satisfactoriamente.");
                        $("#mError_AAH").modal();

                        Mx_Dtt_Antiguos[0].ID_PACIENTE = 0;
                        $("#DataTable").empty();
                        $("#txtRut").val("");
                        $("#txtNom").val("");
                        $("#txtApe").val("");
                        $("#DdlSexo").val(0);
                        var dateNow = moment().format("DD-MM-YYYY");
                        $("#Txt_Date01 input").val(dateNow);
                        $("#DdlNacionalidad").val(0);
                        $("#txtNuevoDireccion").val("");
                        $("#txtNuevoTelefono1").val("");
                        $("#txtNuevoCelular1").val("");
                        $("#txtNuevoTelefono2").val("");
                        $("#txtNuevoCelular2").val("");
                        $("#txtNuevoEmail").val("");
                        $("#DdlDiagnostico").val(0);
                        $("#DdlEstado").val(0);

                        Hide_Modal();
                    } else {


                        $("#Btn_Modal").attr("class", "btn btn-danger");
                        $("#mError p").text("La actualización ha fallado");
                        $("#exampleModal").modal('show');
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

        function Ajax_delete() {
            modal_show();
            var Data_Par = JSON.stringify({

                "ID_PAC": Mx_Dtt_Antiguos[0].ID_PACIENTE,
                "RUT_PAC": $("#txtRut").val(),
                "NOMBRE_PAC": $("#txtNom").val(),
                "APE_PAC": $("#txtApe").val(),
                "ID_SEXO": $("#DdlSexo").val(),
                "FNAC_PAC": $("#fecha ").val(),
                "ID_NACIONALIDAD": $("#DdlNacionalidad").val(),
                "DIR_PAC": $("#txtNuevoDireccion").val(),
                "ID_CIU_COM": $("#DdlComuna").val(),
                "FONO1": $("#txtNuevoTelefono1").val(),
                "FONO2": $("#txtNuevoTelefono2").val(),
                "MOVIL1": $("#txtNuevoCelular1").val(),
                "MOVIL2": $("#txtNuevoCelular2").val(),
                "EMAIL_PAC": $("#txtNuevoEmail").val(),
                "ID_DIAGNOSTICO": $("#DdlDiagnostico").val(),
                "ID_ESTADO": 2


            });

            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Pac.aspx/IRIS_WEBF_UPDATE_PACIENTES",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        $("#mError_AAH_CONFIRMAR").modal('hide');
                        $("#mError_AAH h4").text("Paciente Eliminado");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("El Paciente ha sido eliminado satisfactoriamente.");
                        $("#mError_AAH").modal();
                        $("#DataTable").empty();
                        $("#txtRut").val("");
                        $("#txtNom").val("");
                        $("#txtApe").val("");
                        $("#DdlSexo").val(0);
                        var dateNow = moment().format("DD-MM-YYYY");
                        $("#Txt_Date01 input").val(dateNow);
                        $("#DdlNacionalidad").val(0);
                        $("#txtNuevoDireccion").val("");
                        $("#txtNuevoTelefono1").val("");
                        $("#txtNuevoCelular1").val("");
                        $("#txtNuevoTelefono2").val("");
                        $("#txtNuevoCelular2").val("");
                        $("#txtNuevoEmail").val("");
                        $("#DdlDiagnostico").val(0);
                        $("#DdlEstado").val(0);

                        Mx_Dtt_Antiguos[0].ID_PACIENTE = 0;
                        Hide_Modal();
                    } else {
                        $("#mError_AAH_CONFIRMAR").modal('hide');
                        $("#mError_AAH h4").text("Sin Eliminar");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("Ha ocurrido un error al eliminar el paciente.");
                        $("#mError_AAH").modal
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    $("#mError_AAH_CONFIRMAR").modal('hide');
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
        //Llenar DropDownList Diagnostico
        function Fill_Ddl_diagnostico() {
            $("#DdlDiagnostico").empty();

            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#DdlDiagnostico");

            for (y = 0; y < Mx_Diagnostico.length; ++y) {
                $("<option>", {
                    "value": Mx_Diagnostico[y].ID_DIAGNOSTICO
                }).text(Mx_Diagnostico[y].DIA_DESC).appendTo("#DdlDiagnostico");
            }
            $("#DdlDiagnostico").val(Mx_Dtt_Antiguos[0].ID_DIAGNOSTICO);
        };

        //Llenar DropDownList Sexo
        function Fill_Ddl_Sexo() {
            $("#DdlSexo").empty();

            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#DdlSexo");

            for (y = 0; y < Mx_Sexo.length; ++y) {

                $("<option>", {
                    "value": (Mx_Sexo[y].ID_SEXO)
                }).text(Mx_Sexo[y].SEXO_DESC).appendTo("#DdlSexo");

            }

            $("#DdlSexo").val(Mx_Dtt_Antiguos[0].ID_SEXO);
        };

        //Llenar DropDownList Nacionalidad
        function Fill_Ddl_Nacionalidad() {
            $("#DdlNacionalidad").empty();

            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#DdlNacionalidad");

            for (y = 0; y < Mx_Nacionalidad.length; ++y) {
                $("<option>", {
                    "value": Mx_Nacionalidad[y].ID_NACIONALIDAD
                }).text(Mx_Nacionalidad[y].NAC_DESC).appendTo("#DdlNacionalidad");
            }

            $("#DdlNacionalidad").val(Mx_Dtt_Antiguos[0].ID_NACIONALIDAD);
        };

        //Llenar DropDownList Ciudad
        function Fill_Ddl_Cuidad() {
            $("#DdlCiudad").empty();          

            for (y = 0; y < Mx_Ciudad.length; ++y) {
                $("<option>", {
                    "value": Mx_Ciudad[y].ID_CIUDAD
                }).text(Mx_Ciudad[y].CIU_DESC).appendTo("#DdlCiudad");
            }
        };

        //Llenar DropDownList Comuna
        function Fill_Ddl_Comuna() {
            $("#DdlComuna").empty();
            for (y = 0; y < Mx_Comuna.length; ++y) {
                $("<option>", {
                    "value": Mx_Comuna[y].ID_REL_CIU_COM
                }).text(Mx_Comuna[y].COM_DESC).appendTo("#DdlComuna");
            }

            //$("#DdlComuna").val(Mx_Dtt_Antiguos[0].ID_REL_CIU_COM);
        };
    </script>

    <script>

        //---------------------------------------------------- TABLA PACIENTE ------------------.........-------------------------------|
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
                    $("<th>", { "class": "textoReducido" }).text("Rut"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre"),
                    $("<th>", { "class": "textoReducido" }).text("Dirección"),
                    $("<th>", { "class": "textoReducido" }).text("Celular"),
                    $("<th>", { "class": "textoReducido" }).text("Teléfono"),
                    $("<th>", { "class": "textoReducido" }).text("Sexo"),
                    $("<th>", { "class": "textoReducido" }).text("Email")

                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_DataTable_Antiguos("` + Mx_Dtt[i].ID_PACIENTE + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_RUT),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_DIR),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_MOVIL1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_FONO1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].SEXO_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_EMAIL)
                    )
                );
                $("<tr>").attr("id", i + 1);
            }
            $("#DataTable tbody tr").click(function () {
                $("#DataTable tbody tr").removeClass("active");
                $(this).addClass("active");
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
        <!-- Modal CONFIRMAR-->
    <div id="mError_AAH_CONFIRMAR" class="modal fade" role="dialog">
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
                    <button id="Btn_Confirmar" type="button" class="btn btn-danger">ELIMINAR</button>
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <%------------------------------------------------------TÍTULO, TEXTBOX Y BOTONES-----------------------------------------%>
    
    <div class="card-header bg-bar">
        <h5 style="text-align: center; padding: 5px;">
            <i class="fa fa-search"></i>
            Crear/Editar Paciente
        </h5>
    </div>
    <div>
                <%----------------------------- 1ra fila -----------------------------%>
        <div class="row">
            <div class="col-md mb-1">
            <label for="txtRut">Rut:</label>
            <input id="txtRut" class="form-control textoReducido" type="text" placeholder="BUSCAR..." />
        </div>
        <div class="col-md mb-1">
            <label for="txtNom">Nombre:</label>
            <input id="txtNom" class="form-control text-uppercase textoReducido" type="text"/>
        </div>
        <div class="col-md mb-1">
            <label for="txtApe">Apellido:</label>
            <input id="txtApe" class="form-control text-uppercase textoReducido" type="text"/>
        </div>
        <div class="col-md-2 mb-1">
            <br />
            <button id="Btn_Buscar" class="btn btn-buscar btn-block mt-1 mb-1" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
        </div>
            <div class="col-md-3">
                <label for="DdlSexo">Sexo:</label>
                <select id="DdlSexo" class="form-control textoReducido mayus">
                    <%--<option value="0">Seleccionar</option>--%>
                </select>
            </div>
        </div>
        <%------------------------------ 2da fila ---------------------------------%>
        <div class="row">
            <div class="col-md-3">
                <label for="fecha">Fecha Nacimiento:</label>
                <div class='input-group date' id='Txt_Date01'>
                    <input type='text' id="fecha" class="form-control textoReducido" readonly="true" placeholder="f. nacimiento..." />
                    <span class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                    </span>
                </div>
            </div>
            <div class="col-md-3">
                <label for="DdlNacionalidad">Nacionalidad:</label>
                <select id="DdlNacionalidad" class="form-control textoReducido mayus">
                    <option value="0">Seleccionar</option>
                </select>
            </div>
            <div class="col-md-3">
                <label for="txtNuevoDireccion">Dirección:</label>
                <input id="txtNuevoDireccion" class="form-control textoReducido mayus" type="text" placeholder="dirección..." />
            </div>
            <div class="col-md-3">
                <label for="DdlCiudad">Ciudad:</label>
                <select id="DdlCiudad" class="form-control textoReducido mayus">
                </select>
            </div>
        </div>
        <%---------------------------- 3ra fila ------------------------------------%>
        <div class="row">
            <div class="col-md-3">
                <label for="DdlComuna">Comuna:</label>
                <select id="DdlComuna" class="form-control textoReducido">
                </select>
            </div>
            <div class="col-md-3">
                <label for="txtNuevoTelefono1">Teléfono N°1:</label>
                <input id="txtNuevoTelefono1" class="form-control textoReducido" type="text" placeholder="teléfono..." />
            </div>
            <div class="col-md-3">
                <label for="txtNuevoCelular1">Celular N°1:</label>
                <input id="txtNuevoCelular1" class="form-control textoReducido" type="text" placeholder="celular..." />
            </div>
            <div class="col-md-3">
                <label for="txtNuevoTelefono2">Teléfono N°2:</label>
                <input id="txtNuevoTelefono2" class="form-control textoReducido" type="text" placeholder="teléfono..." />
            </div>
        </div>
        <%---------------------------- 4ta fila --------------------------------------%>
        <div class="row">
            <div class="col-md-3">
                <label for="txtNuevoCelular2">Celular N°2:</label>
                <input id="txtNuevoCelular2" class="form-control textoReducido" type="text" placeholder="celular..." />
            </div>
            <div class="col-md-3">
                <label for="txtNuevoEmail">Email:</label>
                <input id="txtNuevoEmail" class="form-control textoReducido mayus" type="text" placeholder="email..." />
            </div>
            <div class="col-md-3">
                <label for="DdlDiagnostico">Diagnóstico:</label>
                <select id="DdlDiagnostico" class="form-control textoReducido mayus">
                    <option value="0">Seleccionar</option>
                </select>
            </div>
            <div class="col-md-3">
                <label for="DdlEstado">Estado:</label>
                <select id="DdlEstado" class="form-control textoReducido mayus">
                    <option value="0">Seleccionar</option>
                    <option value="1"><< ACTIVADO >></option>
                    <option value="3"><< DESACTIVADO >></option>
                </select>
            </div>
        </div>
    </div>
    <div class="row">
            <div class="col-md">
                <button id="Btn_Limpiar" class="btn btn-limpiar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-eraser mr-2"></i>Limpiar</button>
            </div>
            <div class="col-md">
                <button id="Btn_Guardar" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-save mr-2"></i>Guardar</button>
            </div>
            <div class="col-md">
                <button id="Btn_Update" class="btn btn-info btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-edit mr-2"></i>Modificar</button>
            </div>
            <div class="col-md">
                <button id="Btn_Eliminar" class="btn btn-danger btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-remove mr-2"></i>Eliminar</button>
            </div>
        </div>
    <%-- <div class="col-4">
                <div class="row flexon">
                    <div class="col-12 form-group flx">
                            <label for="txtNAte">Opciones:</label>
                            <button id="Btn_Editar" class="btn btn-primary btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit">Editar</button>
                    </div>
                </div
            </div>--%>


    <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
    <div class="row" id="Id_Conte" style="margin-left: 1px; width: 100%;">
        <div class="col-lg-12" id="Paciente">
            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i> Listado Pacientes</h5>
            <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
        </div>
    </div>

</asp:Content>
