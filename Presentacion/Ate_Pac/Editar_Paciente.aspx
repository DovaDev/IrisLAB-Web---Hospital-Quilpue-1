<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Editar_Paciente.aspx.vb" Inherits="Presentacion.Editar_paciente" %>

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
            //Registrar evento Click del Botón Buscar       
            $("#Btn_Buscar").click(function () {

                if ($("#txtRut").val() == "" && $("#txtNom").val() == "" && $("#txtApe").val() == "" && $("#txtDNI").val() == "") {

                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, ingrese el campo a buscar");
                    $("#mError_AAH").modal();

                } else {
                    $("#Div_Tabla").empty();
                    Ajax_DataTable();
                }


            });

            //$("#txtRut").click(function () {
            //    $("#txtNom").val("");
            //    $("#txtApe").val("")
            //});
            //$("#txtNom").click(function () {
            //    $("#txtRut").val("");
            //    $("#txtApe").val("")
            //});
            //$("#txtApe").click(function () {
            //    $("#txtNom").val("");
            //    $("#txtRut").val("");
            //});

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
            $("#Btn_Nuevo_Guardar").click(function () {
                var sum = 0;
                if ($("#txtNuevoRut").val() == "") {
                    if($("#txtNuevoDNI").val() == ""){
                        $("#txtNuevoRut").css({
                            "border-color": "red"
                        });
                    } else {
                        $("#txtNuevoDNI").css({
                        "border-color": "green"
                        });
                        sum += 1;
                    }                
                } else {
                    sum += 1;
                    $("#txtNuevoRut").css({
                        "border-color": "green"
                    });
                    $("#txtNuevoDNI").css({
                        "border-color": "green"
                    });
                }

                if ($("#txtNuevoNombre").val() == "") {
                    $("#txtNuevoNombre").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#txtNuevoNombre").css({
                        "border-color": "green"
                    });
                }
                if ($("#txtNuevoApellido").val() == "") {
                    $("#txtNuevoApellido").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#txtNuevoApellido").css({
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
                if ($("#txtNuevoFNac").val() == "") {
                    $("#txtNuevoFNac").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#txtNuevoFNac").css({
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
                if ($("#DdlComuna").val() == 0) {
                    $("#DdlComuna").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#DdlComuna").css({
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
                if (sum == 10) {

                    Ajax_Guardar_Datos();
                    $("#Btn_Nuevo_Guardar").attr("class", "btn btn-success  btn-block");

                } else {
                    $("#Btn_Nuevo_Guardar").attr("class", "btn btn-danger btn-block");
                }

            });
        });
    </script>
    <script>
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
                "ID_ESTADO": 0,
                "PAC_DNI": 0
            }
        ];

        function Ajax_DataTable() {
            modal_show();


            var Data_Par = JSON.stringify({
                "RUT_P": $("#txtRut").val(),
                "NOM_P": $("#txtNom").val(),
                "APE_P": $("#txtApe").val(),
                "DNI_P": $("#txtDNI").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Editar_Paciente.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);

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
    "CIU_DESC": 0,
    "PAC_DNI": 0
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
                "url": "Editar_Paciente.aspx/Llenar_DataTable_Antiguos",
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
                        Ajax_Comuna();
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

                        $("#txtNuevoRut").val(Mx_Dtt_Antiguos[0].PAC_RUT);
                        $("#txtNuevoDNI").val(Mx_Dtt_Antiguos[0].PAC_DNI);
                        $("#txtNuevoNombre").val(Mx_Dtt_Antiguos[0].PAC_NOMBRE);
                        $("#txtNuevoApellido").val(Mx_Dtt_Antiguos[0].PAC_APELLIDO);
                        $("#txtNuevoDireccion").val(Mx_Dtt_Antiguos[0].PAC_DIR);
                        $("#txtNuevoTelefono1").val(Mx_Dtt_Antiguos[0].PAC_FONO1);
                        $("#txtNuevoTelefono2").val(Mx_Dtt_Antiguos[0].PAC_FONO2);
                        $("#txtNuevoCelular1").val(Mx_Dtt_Antiguos[0].PAC_MOVIL1);
                        $("#txtNuevoCelular2").val(Mx_Dtt_Antiguos[0].PAC_MOVIL2);
                        $("#txtNuevoEmail").val(Mx_Dtt_Antiguos[0].PAC_EMAIL);

                        $("#DdlEstado").val(parseInt(Mx_Dtt_Antiguos[0].ID_ESTADO));

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

                        Fill_DataTable_Antiguos();
                        Hide_Modal();
                        $('#eModal').modal('show');



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
        //-------------------------------------- JSON MANTENEDOR ------------------------------------------------------------------------| 
        var Mx_Ddl_Mantenedor = [
            {
                "ID_ESTADO": 0,
                "EST_DESCRIPCION": 0,
                "EST_MANTENEDOR": 0
            }
        ];

        function Ajax_Mantenedor() {



            $.ajax({
                "type": "POST",
                "url": "Editar_Paciente.aspx/IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_Mantenedor = JSON.parse(json_receiver);

                        $(".block_wait").hide();


                    } else {


                    }
                },
                "error": function (response) {


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
                "url": "Editar_Paciente.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Diagnostico = JSON.parse(json_receiver);
                        Fill_Ddl_diagnostico();
                        $(".block_wait").hide();


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
                "url": "Editar_Paciente.aspx/IRIS_WEBF_BUSCA_SEXO",
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
                "url": "Editar_Paciente.aspx/IRIS_WEBF_BUSCA_NACIONALIDAD",
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
                "url": "Editar_Paciente.aspx/IRIS_WEBF_BUSCA_CIUDAD",
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
                "url": "Editar_Paciente.aspx/IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Comuna = JSON.parse(json_receiver);
                        Fill_Ddl_Comuna();
                        $(".block_wait").hide();


                    } else {


                    }
                },
                "error": function (response) {


                }
            });
        }

        //Json Para Ingresar Paciente ***NUEVO***
        var Guardar_datos = 0;

        function Ajax_Guardar_Datos() {



            var Data_Par = JSON.stringify({

                "ID_PAC": Mx_Dtt_Antiguos[0].ID_PACIENTE,
                "RUT_PAC": $("#txtNuevoRut").val(),
                "DNI_PAC": $("#txtNuevoDNI").val(),
                "NOMBRE_PAC": $("#txtNuevoNombre").val(),
                "APE_PAC": $("#txtNuevoApellido").val(),
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

            //$(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "Editar_Paciente.aspx/IRIS_WEBF_UPDATE_PACIENTES",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Paciente_nuevo = JSON.parse(json_receiver)
                        //$(".block_wait").hide();


                        //$("#EM2 h5").text("Datos Actualizados");
                        //$("#button_modal").attr("class", "btn btn-success");
                        //$("#EM2 p").text("Los Datos se han actualizado satisfactoriamente");
                        //$("#EM2").modal();

                        $("#mError_AAH h4").text("Datos Actualizados");
                        $("#mError_AAH button").attr("class", "btn btn-primary");
                        $("#mError_AAH p").text("Los datos del paciente han sido actualizados satisfactoriamente.");
                        $("#mError_AAH").modal();

                        $('#eModal').modal('hide');

                        Ajax_DataTable_Antiguos_UPDATE(Mx_Dtt_Antiguos[0].ID_PACIENTE);
                        Ajax_DataTable_UPDATE($("#txtNuevoRut").val(), $("#txtNuevoDNI").val())

                        $("#txtNuevoRut").val("");
                        $("#txtNuevoDNI").val("");
                        $("#txtNuevoNombre").val("");
                        $("#txtNuevoApellido").val("");
                        $("#txtNuevoDireccion").val("");
                        $("#txtNuevoTelefono1").val("");
                        $("#txtNuevoTelefono2").val("");
                        $("#txtNuevoCelular1").val("");
                        $("#txtNuevoCelular2").val("");
                        $("#txtNuevoEmail").val("");


                    } else {


                        $("#Btn_Modal").attr("class", "btn btn-danger");
                        $("#mError p").text("La actualización ha fallado");
                        $("#exampleModal").modal('show');
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        // ACTUALIZAR LOS DATOS ANTIGUOS EN EL ***MODAL*** AL HACER EL UPDATE
        function Ajax_DataTable_Antiguos_UPDATE(ID_PAC) {
            modal_show();


            var Data_Par = JSON.stringify({
                "ID_PAC": ID_PAC
            });
            //$(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Editar_Paciente.aspx/Llenar_DataTable_Antiguos",
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
                        Ajax_Comuna();
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

                        Fill_DataTable_Antiguos();
                        Hide_Modal();
                        $('#eModal').modal('hide');



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

        //CARGAR LOS DATOS EN LA PRIMERA TABLA AL HACER EL UPDATE
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

        function Ajax_DataTable_UPDATE(RUT, DNI) {
            modal_show();


            var Data_Par = JSON.stringify({
                "RUT_P": RUT,
                "NOM_P": "",
                "APE_P": "",
                "DNI_P": DNI
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Editar_Paciente.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        $("#Div_Tabla").empty();
                        Fill_DataTable();
                        Hide_Modal();


                        $('#eModal').modal('hide');
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

            $("#DdlCiudad").val(Mx_Dtt_Antiguos[0].ID_CIUDAD);
        };

        //Llenar DropDownList Comuna
        function Fill_Ddl_Comuna() {
            $("#DdlComuna").empty();

            for (y = 0; y < Mx_Comuna.length; ++y) {
                $("<option>", {
                    "value": Mx_Comuna[y].ID_REL_CIU_COM
                }).text(Mx_Comuna[y].COM_DESC).appendTo("#DdlComuna");
            }

            $("#DdlComuna").val(Mx_Dtt_Antiguos[0].ID_REL_CIU_COM);
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

            //$("#DataTable").DataTable({  "bSort": false,
            //    "iDisplayLength": 10,
            //    "language": {

            //        "lengthMenu": "Mostrar: _MENU_",
            //        "zeroRecords": "No hay concidencias",
            //        "info": "Mostrando Pagina _PAGE_ de _PAGES_",
            //        "infoEmpty": "No hay concidencias",
            //        "infoFiltered": "(Se busco en _MAX_ registros )",
            //        "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
            //        "paginate": {
            //            "previous": "Anterior",
            //            "next": "Siguiente"
            //        }
            //    }
            //});

        }


        //------------------------------------------------ DATOS ANTIGUOS  -------------------------------------------------------------|
        function Fill_DataTable_Antiguos() {

            for (i = 0; i < Mx_Dtt_Antiguos.length; i++) {

                $("#lblrut").text(Mx_Dtt_Antiguos[i].PAC_RUT),
                $("#lblnom").text(Mx_Dtt_Antiguos[i].PAC_NOMBRE),
                $("#lblape").text(Mx_Dtt_Antiguos[i].PAC_APELLIDO),
                $("#lblsex").text(Mx_Dtt_Antiguos[i].SEXO_DESC),
                $("#lblfnac").text(function () {
                    //Obtener valores
                    var obj_date = new Date(Mx_Dtt_Antiguos[i].PAC_FNAC);
                    var dd = parseInt(obj_date.getDate());
                    var mm = parseInt(obj_date.getMonth()) + 1;
                    var yy = parseInt(obj_date.getFullYear());

                    if (dd < 10) { dd = "0" + dd; }
                    if (mm < 10) { mm = "0" + mm; }

                    return String(dd + "/" + mm + "/" + yy);
                }),
                $("#lblnac").text(Mx_Dtt_Antiguos[i].NAC_DESC),
                $("#lbldir").text(Mx_Dtt_Antiguos[i].PAC_DIR),
                $("#lblciu").text(Mx_Dtt_Antiguos[i].CIU_DESC),
                $("#lblcom").text(Mx_Dtt_Antiguos[i].COM_DESC),
                $("#lbltel1").text(Mx_Dtt_Antiguos[i].PAC_FONO1),
                $("#lblcel1").text(Mx_Dtt_Antiguos[i].PAC_MOVIL1),
                $("#lbltel2").text(Mx_Dtt_Antiguos[i].PAC_FONO2),
                $("#lblcel2").text(Mx_Dtt_Antiguos[i].PAC_MOVIL2),
                $("#lblemail").text(Mx_Dtt_Antiguos[i].PAC_EMAIL),
                $("#lbldiag").text(Mx_Dtt_Antiguos[i].DIA_DESC),
                $("#lblest").text(Mx_Dtt_Antiguos[i].EST_DESCRIPCION)
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
        <div class="modal-dialog" role="document" style="max-width:75vw">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Datos Actuales del Paciente</h4>
                </div>

                <div class="modal-body">
                    <div id="Div_Tabla_Antiguos" style="width: 100%;" class="table-responsive">
                        <div class="row">
                            <div class="col-md-3">
                                <label>RUT:</label>
                                <label id="lblrut"></label>
                            </div>
                            <div class="col-md-3">
                                <label>Nombre:</label>
                                <label id="lblnom"></label>
                            </div>
                            <div class="col-md-3">
                                <label>Apellido:</label>
                                <label id="lblape"></label>
                            </div>
                            <div class="col-md-3">
                                <label>Sexo:</label>
                                <label id="lblsex"></label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>Fecha Nac:</label>
                                <label id="lblfnac"></label>
                            </div>
                            <div class="col-md-3">
                                <label>Nacionalidad:</label>
                                <label id="lblnac"></label>
                            </div>
                            <div class="col-md-3">
                                <label>Dirección:</label>
                                <label id="lbldir"></label>
                            </div>
                            <div class="col-md-3">
                                <label>Ciudad:</label>
                                <label id="lblciu"></label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>Comuna:</label>
                                <label id="lblcom"></label>
                            </div>
                            <div class="col-md-3">
                                <label>Teléfono 1:</label>
                                <label id="lbltel1"></label>
                            </div>
                            <div class="col-md-3">
                                <label>Celular 1:</label>
                                <label id="lblcel1"></label>
                            </div>
                            <div class="col-md-3">
                                <label>Teléfono 2:</label>
                                <label id="lbltel2"></label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>Celular 2:</label>
                                <label id="lblcel2"></label>
                            </div>
                            <div class="col-md-3">
                                <label>e-mail:</label>
                                <label id="lblmail"></label>
                            </div>
                            <div class="col-md-3">
                                <label>Diagnóstico:</label>
                                <label id="lbldiag"></label>
                            </div>
                            <div class="col-md-3">
                                <label>Estado:</label>
                                <label id="lblest"></label>
                            </div>
                        </div>

                    </div>
                    <hr />
                    <h4>Datos Nuevos del Paciente</h4>
                    <div class="container" style="width: 100%;">
                        <%----------------------------- 1ra fila -----------------------------%>
                        <div class="row">
                            <div class="col-md-2">
                                <label for="txtNuevoRut">Rut:</label>
                                <input id="txtNuevoRut" class="form-control textoReducido" type="text" placeholder="rut..." />
                            </div>
                            <div class="col-md-2">
                                <label for="txtNuevoDNI">DNI:</label>
                                <input id="txtNuevoDNI" class="form-control textoReducido" type="text" placeholder="dni..." />
                            </div>
                            <div class="col-md-2">
                                <label for="txtNuevoNombre">Nombre:</label>
                                <input id="txtNuevoNombre" class="form-control textoReducido mayus" type="text" placeholder="nombre..." />
                            </div>
                            <div class="col-md-2">
                                <label for="txtNuevoApellido">Apellido:</label>
                                <input id="txtNuevoApellido" class="form-control textoReducido mayus" type="text" placeholder="apellido..." />
                            </div>
                            <div class="col-md-2">
                                <label for="DdlSexo">Sexo:</label>
                                <select id="DdlSexo" class="form-control textoReducido mayus">
                                    <%--<option value="0">Seleccionar</option>--%>
                                </select>
                            </div>
                        </div>
                        <%------------------------------ 2da fila ---------------------------------%>
                        <div class="row">
                            <div class="col-md-3">
                                <label for="fecha">F.NAC.:</label>
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
                                    <option value="0">Seleccionar</option>
                                </select>
                            </div>
                        </div>
                        <%---------------------------- 3ra fila ------------------------------------%>
                        <div class="row">
                            <div class="col-md-3">
                                <label for="DdlComuna">Comuna:</label>
                                <select id="DdlComuna" class="form-control textoReducido">
                                    <option value="0">Seleccionar</option>
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
                        <button id="Btn_Nuevo_Guardar" class="btn btn-primary btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-save mr-2"></i>Guardar</button>
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
    
    <div class="card-header bg-bar">
        <h5 style="text-align: center; padding: 5px;">
            <i class="fa fa-search"></i>
            Buscar Paciente
        </h5>
    </div>
    <div class="row " style="margin-top:15px;">

        <div class="col-md mb-1">
            <label for="txtRut">Rut:</label>
            <input id="txtRut" class="form-control textoReducido" type="text" placeholder="BUSCAR..." />
        </div>
                <div class="col-md mb-1">
            <label for="txtDNI">DNI:</label>
            <input id="txtDNI" class="form-control textoReducido" type="text" placeholder="BUSCAR..." />
        </div>
        <div class="col-md mb-1">
            <label for="txtNom">Nombre:</label>
            <input id="txtNom" class="form-control text-uppercase textoReducido" type="text" placeholder="BUSCAR..." />
        </div>
        <div class="col-md mb-1">
            <label for="txtApe">Apellido:</label>
            <input id="txtApe" class="form-control text-uppercase textoReducido" type="text" placeholder="Buscar..." />
        </div>
        <div class="col-md-2 mb-1">
            <br />
            <button id="Btn_Buscar" class="btn btn-buscar btn-block mt-1 mb-1" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
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
        <div class="col-lg-1"></div>
        <div class="col-lg-10" id="Paciente">

            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i>Datos del Paciente</h5>
            <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>

        </div>
        <div class="col-lg-1"></div>
    </div>

</asp:Content>
