
$(document).ready(function () {
    //Ajax_Diagnostico();
    //Ajax_Sexo();
    //Ajax_Nacionalidad();
    //Ajax_Ciudad();

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

        if ($("#txtRut").val() == "" && $("#txtNom").val() == "" && $("#txtApe").val() == "") {

            $("#mError_AAH h4").text("Error");
            $("#mError_AAH button").attr("class", "btn btn-danger");
            $("#mError_AAH p").text("Por favor, ingrese el campo a buscar");
            $("#mError_AAH").modal();

        } else {
            $("#Div_Tabla").empty();
            Ajax_DataTable();
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
                Swal.fire({
                    icon: "info",
                    title: "Datos Faltantes",
                    text: "Por favor, Ingrese los datos faltantes."
                });
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


//-------------------------------------------------- GRABA PACIENTE ----------------------------------------------------|
function IRIS_WEBF_GRABA_PACIENTE() {
    modal_show2();

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
        "url": "/Configuraciones/Pacientes/Crear_Edit_Pac.aspx/IRIS_WEBF_GRABA_PACIENTE",
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

                Hide_Modal2();
                $("#DataTable").empty();
                $("#mError_AAH h4").text("Paciente Creado");
                $("#mError_AAH button").attr("class", "btn btn-success");
                $("#mError_AAH p").text("El paciente se ha creado de forma exitosa.");
                $("#mError_AAH").modal();
            } else {

                Hide_Modal2();
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
    modal_show2();


    var Data_Par = JSON.stringify({
        "rut": $("#txtRut").val()
    });
    //$(".block_wait").fadeIn(500);
    $.ajax({
        "type": "POST",
        "url": "/Configuraciones/Pacientes/Crear_Edit_Pac.aspx/Llenar_rut",
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

                    Hide_Modal2();
            } else {
                Mx_Dtt_Antiguos[0].ID_PACIENTE = 0;
                $("#DataTable").empty();
                Hide_Modal2();
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
    modal_show2();


    var Data_Par = JSON.stringify({
        "RUT_P": $("#txtRut").val(),
        "NOM_P": $("#txtNom").val(),
        "APE_P": $("#txtApe").val()
    });
    $(".block_wait").fadeIn(500);
    $.ajax({
        "type": "POST",
        "url": "/Configuraciones/Pacientes/Crear_Edit_Pac.aspx/Llenar_DataTable",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt = JSON.parse(json_receiver);
                $("#DataTable").empty();
                Fill_DataTable();
                Hide_Modal2();


            } else {


                Hide_Modal2();
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

    var Data_Par = JSON.stringify({
        "ID_PAC": ID_PAC
    });
    //$(".block_wait").fadeIn(500);
    $.ajax({
        "type": "POST",
        "url": "/Configuraciones/Pacientes/Crear_Edit_Pac.aspx/Llenar_DataTable_Antiguos",
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
                });
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
        "url": "/Configuraciones/Pacientes/Crear_Edit_Pac.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO",
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
        "url": "/Configuraciones/Pacientes/Crear_Edit_Pac.aspx/IRIS_WEBF_BUSCA_SEXO",
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
        "url": "/Configuraciones/Pacientes/Crear_Edit_Pac.aspx/IRIS_WEBF_BUSCA_NACIONALIDAD",
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
        "url": "/Configuraciones/Pacientes/Crear_Edit_Pac.aspx/IRIS_WEBF_BUSCA_CIUDAD",
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
        "url": "/Configuraciones/Pacientes/Crear_Edit_Pac.aspx/IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA",
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
    modal_show2();
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
        "url": "/Configuraciones/Pacientes/Crear_Edit_Pac.aspx/IRIS_WEBF_UPDATE_PACIENTES",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Swal.fire({
                    icon: "success",
                    title: "Datos Actualizados",
                    text: "Los datos del paciente han sido actualizados satisfactoriamente."
                });
                objAJAX_Pac_Data.requestNow();
                Hide_Modal2();
            } else {


                $("#Btn_Modal").attr("class", "btn btn-danger");
                $("#mError p").text("La actualización ha fallado");
                $("#exampleModal").modal('show');
                Hide_Modal2();
            }
        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);

            Hide_Modal2();

        }
    });
}

function Ajax_delete() {
    modal_show2();
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
        "url": "/Configuraciones/Pacientes/Crear_Edit_Pac.aspx/IRIS_WEBF_UPDATE_PACIENTES",
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
                Hide_Modal2();
            } else {
                $("#mError_AAH_CONFIRMAR").modal('hide');
                $("#mError_AAH h4").text("Sin Eliminar");
                $("#mError_AAH button").attr("class", "btn btn-success");
                $("#mError_AAH p").text("Ha ocurrido un error al eliminar el paciente.");
                $("#mError_AAH").modal
                Hide_Modal2();
            }
        },
        "error": function (response) {
            $("#mError_AAH_CONFIRMAR").modal('hide');
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);

            Hide_Modal2();

        }
    });
}


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

