<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Crea_Edita_Med.aspx.vb" Inherits="Presentacion.Crea_Edita_Med" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>
        var ID_DOCC = "";
        var Med_Pos = "";
        $(document).ready(function () {
            //FUNCIONES SELECT
            Ajax_Sexo();
            Ajax_Nac();
            Ajax_Ciudad();
            Ajax_Espec();
            Ajax_Rel_Ciu_Com();
            Ajax_Tabla();
            $("#slt_Ciudad").change(function () {
                Ajax_Comuna();
            });
            //FUNCION DTP
            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input").val(dateNow);
            $('#Txt_Date01').datetimepicker({
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
            //EVENT ENTER - FOCUSOUT
            $("#txt_Rut").keypress(function (key) {
                if (key.which == 13) {
                    Rut();
                }
            });
            $("#txt_Rut").focusout(function () { Rut(); });
            //INICIO BOTONES
            $("#btn_Nuevo").removeAttr("disabled");
            $("#btn_Guardar").removeAttr("disabled");
            $("#btn_Modificar").attr("disabled", "disabled");
            $("#btn_Eliminar").attr("disabled", "disabled");
            //INICIO FORM
            ID_DOCC = "";
            $("#txt_Rut").val("");
            $("#txt_Nom").val("");
            $("#txt_Ape").val("");
            $("#fecha").val(moment().format("DD-MM-YYYY"));
            $("#txt_Dir").val("");
            $("#txt_Fono").val("");
            $("#txt_Celu").val("");
            $("#txt_TelU").val("");
            $("#txt_CelUr").val("");
            $("#txt_Correo").val("");
            //CLICK LIMPIAR
            $("#btn_Nuevo").click(function () {
                $("#hiden_div").empty();
                $("#btn_Nuevo").removeAttr("disabled");
                $("#btn_Guardar").removeAttr("disabled");
                $("#btn_Modificar").attr("disabled", "disabled");
                $("#btn_Eliminar").attr("disabled", "disabled");
                ID_DOCC = "";
                $("#txt_Rut").val("");
                $("#txt_Nom").val("");
                $("#txt_Ape").val("");
                $("#fecha").val(moment().format("DD-MM-YYYY"));
                $("#txt_Dir").val("");
                $("#txt_Fono").val("");
                $("#txt_Celu").val("");
                $("#txt_TelU").val("");
                $("#txt_CelUr").val("");
                $("#txt_Correo").val("");
                Ajax_Sexo();
                Ajax_Nac();
                Ajax_Ciudad();
                Ajax_Espec();
            });
            //CLICK GUARDAR
            $("#btn_Guardar").click(function () {
                if (Valida() == true) {
                    $("#btn_Nuevo").removeAttr("disabled");
                    $("#btn_Guardar").removeAttr("disabled");
                    $("#btn_Modificar").attr("disabled", "disabled");
                    $("#btn_Eliminar").attr("disabled", "disabled");
                    ID_DOCC = "";
                    Ajax_Graba();
                }
                else {
                    $("#hiden_div").append("<div class='col-md'>[ <span style='color: red'>*</span> ] Campos Requeridos</div>")
                }
            });
            //CLICK MODIFICAR
            $("#btn_Modificar").click(function () {
                if (Valida() == true) {
                    $("#btn_Nuevo").removeAttr("disabled");
                    $("#btn_Guardar").removeAttr("disabled");
                    $("#btn_Modificar").attr("disabled", "disabled");
                    $("#btn_Eliminar").attr("disabled", "disabled");

                    if (ID_DOCC != "") {
                        Ajax_Edita();
                    }
                }
                else {
                    $("#hiden_div").append("<div class='col-md'>[ <span style='color: red'>*</span> ] Campos Requeridos</div>")
                }
            });
            //CLICK ELIMINAR
            $("#btn_Eliminar").click(function () {
                $("#btn_Nuevo").removeAttr("disabled");
                $("#btn_Guardar").removeAttr("disabled");
                $("#btn_Modificar").attr("disabled", "disabled");
                $("#btn_Eliminar").attr("disabled", "disabled");

                $("#mError_AAH h4").text("Eliminar Médico");
                $("#mError_AAH button").attr("class", "btn btn-primary");
                $("#mError_AAH p").html(`
                    <p>Se procederá a eliminar al siguiente médico: </p>
                    <p>${Mx_Dtt[Med_Pos].DOC_NOMBRE} ${Mx_Dtt[Med_Pos].DOC_APELLIDO}</p>
                    <br/>
                    <p>¿Está seguro que desea eliminar a este médico?</p>`);
                $("#mError_AAH .modal-footer").empty();
                $("#mError_AAH .modal-footer").append("<button type='button' class='btn btn-danger' id='btn_Elim_Modal' data-dismiss='modal'>Eliminar</button>");
                $("#mError_AAH .modal-footer").append("<button type='button' class='btn btn-buscar' data-dismiss='modal'>Cerrar</button>");
                $("#mError_AAH").modal();

                $("#btn_Elim_Modal").click(function () {
                    if (ID_DOCC != "") {
                        Ajax_Elimina();
                    }
                });
            });
        })
        //FUNCTION VALIDA
        function Valida() {
            $("#hiden_div").empty();
            if ($("#txt_Rut").val() == "") {
                $("#txt_Rut").css("border-color","red");
                return false;
            } else {
                $("#txt_Rut").css("border-color", "inherit");
            }
            if ($("#txt_Nom").val() == "") {
                $("#txt_Nom").css("border-color", "red");
                return false;
            } else {
                $("#txt_Nom").css("border-color", "inherit");
            }
            if ($("#txt_Ape").val() == "") {
                $("#txt_Ape").css("border-color", "red");
                return false;
            } else {
                $("#txt_Ape").css("border-color", "inherit");
            }
            if ($("#txt_Dir").val() == "") {
                $("#txt_Dir").css("border-color", "red");
                return false;
            } else {
                $("#txt_Dir").css("border-color", "inherit");
            }
            if ($("#txt_Fono").val() == "") {
                $("#txt_Fono").css("border-color", "red");
                return false;
            } else {
                $("#txt_Fono").css("border-color", "inherit");
            }
            if ($("#txt_Celu").val() == "") {
                $("#txt_Celu").css("border-color", "red");
                return false;
            } else {
                $("#txt_Celu").css("border-color", "inherit");
            }
            return true;            
        }
        //FUNCTION RUT
        function Rut() {
            if ($("#txt_Rut").val() != "") {
                //Capturar Anáqlisis del RUT
                var obj_RUT = Valid_RUT($("#txt_Rut").val());
                if (obj_RUT.Valid == false) {
                    var str_Error = "El RUT ingresado no es Válido, ";
                    str_Error += "ingrese en el campo de texto un RUT válido.";

                    $("#mError_AAH h5").text("Error:");
                    $("#button_modal").attr("class", "btn btn-danger");

                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();

                    $("#txt_Rut").val("");
                    $("#txt_Rut").css({
                        "border-color": "red"
                    });
                } else {
                    $("#txt_Rut").css({
                        "border-color": "green"
                    });
                    $("#txt_Rut").val(obj_RUT.Format);
                    //LLAMA CODIGUIN
                    for (i = 0; i < Mx_Dtt.length; i++) {
                        if (Mx_Dtt[i].DOC_RUT == $("#txt_Rut").val()) {
                            Ajax_Codiguin(i);
                        }
                    }
                }
            }
        }
        //ELIMINA
        function Ajax_Elimina() {
            var Graba_REL;
            Mx_Rel_Ciu_Com.forEach(aaa => {
                if ($("#slt_Ciudad").val() == aaa.ID_CIUDAD && $("#slt_Comuna").val() == aaa.ID_COMUNA) {
                    Graba_REL = aaa.ID_REL_CIU_COM;
                }
            });

            //Busca Rel Ciu Com
            var Data_Par = JSON.stringify({
                "ID_DOC": ID_DOCC,
                "RUT_DOC": $("#txt_Rut").val(),
                "NOMBRE_DOC": $("#txt_Nom").val(),
                "APE_DOC": $("#txt_Ape").val(),
                "ID_SEXO": $("#slt_Sexo").val(),
                "FNAC_DOC": $("#fecha").val(),
                "ID_NACIONALIDAD": $("#slt_Nac").val(),
                "DIR_DOC": $("#txt_Dir").val(),
                "ID_CIU_COM": Graba_REL,
                "FONO1": $("#txt_Fono").val(),
                "FONO2": $("#txt_TelU").val(),
                "MOVIL1": $("#txt_Celu").val(),
                "MOVIL2": $("#txt_CelUr").val(),
                "EMAIL_DESC": $("#txt_Correo").val(),
                "ID_ESPECIALIDAD": $("#slt_Espec").val(),
                "ID_ESTADO": 2
            });

            $.ajax({
                "type": "POST",
                "url": "Crea_Edita_Med.aspx/Update_Medico",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        modal_show();
                        $("#btn_Nuevo").click();
                        Ajax_Tabla();
                    } else {
                    }
                },
                "error": (fail) => {
                    console.error(fail);
                }
            });
        }
        //EDITA
        function Ajax_Edita() {
            //Busca Rel Ciu Com
            var Graba_REL;
            Mx_Rel_Ciu_Com.forEach(aaa => {
                if ($("#slt_Ciudad").val() == aaa.ID_CIUDAD && $("#slt_Comuna").val() == aaa.ID_COMUNA) {
                    Graba_REL = aaa.ID_REL_CIU_COM;
                }
            });

            var Data_Par = JSON.stringify({
                "ID_DOC": ID_DOCC,
                "RUT_DOC": $("#txt_Rut").val(),
                "NOMBRE_DOC": $("#txt_Nom").val(),
                "APE_DOC": $("#txt_Ape").val(),
                "ID_SEXO": $("#slt_Sexo").val(),
                "FNAC_DOC": $("#fecha").val(),
                "ID_NACIONALIDAD": $("#slt_Nac").val(),
                "DIR_DOC": $("#txt_Dir").val(),
                "ID_CIU_COM": Graba_REL,
                "FONO1": $("#txt_Fono").val(),
                "FONO2": $("#txt_TelU").val(),
                "MOVIL1": $("#txt_Celu").val(),
                "MOVIL2": $("#txt_CelUr").val(),
                "EMAIL_DESC": $("#txt_Correo").val(),
                "ID_ESPECIALIDAD": $("#slt_Espec").val(),
                "ID_ESTADO": $("#slt_Estado").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Crea_Edita_Med.aspx/Update_Medico",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        modal_show();
                        $("#btn_Nuevo").click();
                        Ajax_Tabla();
                    } else {
                    }
                },
                "error": (fail) => {
                    console.error(fail);
                }
            });
        }
        //GRABA
        function Ajax_Graba() {
            //Busca Rel Ciu Com
            var Graba_REL;
            Mx_Rel_Ciu_Com.forEach(aaa => {
                if ($("#slt_Ciudad").val() == aaa.ID_CIUDAD && $("#slt_Comuna").val() == aaa.ID_COMUNA) {
                    Graba_REL = aaa.ID_REL_CIU_COM;
                }
            });

            var Data_Par = JSON.stringify({
                "RUT_DOC": $("#txt_Rut").val(),
                "NOMBRE_DOC": $("#txt_Nom").val(),
                "APE_DOC": $("#txt_Ape").val(),
                "ID_SEXO": $("#slt_Sexo").val(),
                "FNAC_DOC": $("#fecha").val(),
                "ID_NACIONALIDAD": $("#slt_Nac").val(),
                "DIR_DOC": $("#txt_Dir").val(),
                "ID_CIU_COM": Graba_REL,
                "FONO1": $("#txt_Fono").val(),
                "FONO2": $("#txt_TelU").val(),
                "MOVIL1": $("#txt_Celu").val(),
                "MOVIL2": $("#txt_CelUr").val(),
                "EMAIL_DESC": $("#txt_Correo").val(),
                "ID_ESPECIALIDAD": $("#slt_Espec").val(),
                "ID_ESTADO": $("#slt_Estado").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Crea_Edita_Med.aspx/Graba_Medico",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        modal_show();
                        $("#btn_Nuevo").click();
                        Ajax_Tabla();
                    } else {
                    }
                },
                "error": (fail) => {
                    console.error(fail);
                }
            });
        }
        //REL CIU COM
        var Mx_Rel_Ciu_Com = [{
            "COM_DESC": 0,
            "ID_COMUNA": 0,
            "ID_ESTADO": 0,
            "ID_CIUDAD": 0,
            "ID_REL_CIU_COM": 0
        }];
        function Ajax_Rel_Ciu_Com() {
            $.ajax({
                "type": "POST",
                "url": "Crea_Edita_Med.aspx/Llama_Rel_Ciu_Com",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Rel_Ciu_Com = json_receiver;
                    } else {
                    }
                }
            });
        }
        //CLICK TR
        function Ajax_Codiguin(i) {

            $("#btn_Nuevo").removeAttr("disabled");
            $("#btn_Guardar").attr("disabled", "disabled");
            $("#btn_Modificar").removeAttr("disabled");
            $("#btn_Eliminar").removeAttr("disabled");
            Med_Pos = i;

            ID_DOCC = Mx_Dtt[i].ID_DOCTOR;
            $("#txt_Rut").val(Mx_Dtt[i].DOC_RUT);
            $("#txt_Nom").val(Mx_Dtt[i].DOC_NOMBRE);
            $("#txt_Ape").val(Mx_Dtt[i].DOC_APELLIDO);
            $("#slt_Sexo").val(Mx_Dtt[i].ID_SEXO);
            if (Mx_Dtt[i].DOC_FNAC != "" && Mx_Dtt[i].DOC_FNAC != null) {
                var fff = moment(Mx_Dtt[i].DOC_FNAC).format("DD-MM-YYYY");
                $("#fecha").val(fff);
            }
            $("#slt_Nac").val(Mx_Dtt[i].ID_NACIONALIDAD);
            $("#txt_Dir").val(Mx_Dtt[i].DOC_DIR);
            $("#txt_Fono").val(Mx_Dtt[i].DOC_FONO1);
            $("#txt_Celu").val(Mx_Dtt[i].DOC_MOVIL1);
            $("#txt_TelU").val(Mx_Dtt[i].DOC_FONO2);
            $("#txt_CelUr").val(Mx_Dtt[i].DOC_MOVIL2);
            $("#txt_Correo").val(Mx_Dtt[i].DOC_EMAIL);
            $("#slt_Espec").val(Mx_Dtt[i].ID_ESPECIALIDAD);
            $("slt_Estado").val(Mx_Dtt[i].ID_ESTADO);

            Mx_Rel_Ciu_Com.forEach(aaa=> {
                if (aaa.ID_REL_CIU_COM == Mx_Dtt[i].ID_REL_CIU_COM) {

                    if ($("#slt_Ciudad").val() != aaa.ID_CIUDAD) {
                        $("#slt_Ciudad").val(aaa.ID_CIUDAD);
                        Ajax_Comuna();
                        setTimeout(function () { $("#slt_Comuna").val(aaa.ID_COMUNA); }, 500);

                    }
                    else {
                        $("#slt_Comuna").val(aaa.ID_COMUNA);

                    }
                }
            });
        }
        //ESPECIALIDAD
        var Mx_Espec = [{
            "ID_ESPECIALIDAD": 0,
            "ESP_COD": 0,
            "ESP_DESC": 0,
            "ID_ESTADO": 0
        }];
        function Ajax_Espec() {
            $.ajax({
                "type": "POST",
                "url": "Crea_Edita_Med.aspx/Llena_Espec",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Espec = json_receiver;
                        Fill_Ddl_Espec();
                    } else {
                    }
                    $(".block_wait").fadeOut(500);
                }
            });
        }
        function Fill_Ddl_Espec() {
            $("#slt_Espec").empty();
            Mx_Espec.forEach(aaa => {
                $("<option>", { "value": aaa.ID_ESPECIALIDAD }).text(aaa.ESP_DESC).appendTo("#slt_Espec");
            });
        }
        //COMUNA  
        var Mx_Comuna = [{
            "COM_DESC": 0,
            "ID_COMUNA": 0,
            "ID_ESTADO": 0,
            "ID_CIUDAD": 0,
            "ID_REL_CIU_COM": 0
        }];
        function Ajax_Comuna() {


            var Data_Par = JSON.stringify({
                "ID_CIU": $("#slt_Ciudad").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Crea_Edita_Med.aspx/Llenar_Comuna",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Comuna = json_receiver;
                        Fill_Ddl_Comuna();
                        $(".block_wait").hide();
                    } else {
                    }
                }
            });
        }
        function Fill_Ddl_Comuna() {
            $("#slt_Comuna").empty();
            Mx_Comuna.forEach(aaa => {
                $("<option>", { "value": aaa.ID_COMUNA }).text(aaa.COM_DESC).appendTo("#slt_Comuna");
            });
        };
        //CIUDAD
        var Mx_Ciudad = [{
            "ID_CIUDAD": 0,
            "CIU_COD": 0,
            "CIU_DESC": 0,
            "ID_ESTADO": 0
        }];
        function Ajax_Ciudad() {
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Crea_Edita_Med.aspx/Llenar_Ciudad",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Ciudad = json_receiver;
                        Fill_Ddl_Ciudad();
                    } else {
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.ExceptionType + "\n \n";
                    str_Error = response.Message;
                    alert(str_Error);
                }
            });
        }
        function Fill_Ddl_Ciudad() {
            $("#slt_Ciudad").empty();
            Mx_Ciudad.forEach(aaa => {
                $("<option>", { "value": aaa.ID_CIUDAD }).text(aaa.CIU_DESC).appendTo("#slt_Ciudad");
            });
            Ajax_Comuna();
        }
        //NACIONALIDAD
        var Mx_Nac = [{
            "ID_NACIONALIDAD": 0,
            "NAC_COD": 0,
            "NAC_DESC": 0,
            "ID_ESTADO": 0
        }];
        function Ajax_Nac() {
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Crea_Edita_Med.aspx/Llenar_Nacionalidad",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Nac = json_receiver;
                        Fill_Ddl_Nacionalidad();
                    } else {
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.ExceptionType + "\n \n";
                    str_Error = response.Message;
                    alert(str_Error);
                }
            });
        }
        function Fill_Ddl_Nacionalidad() {
            $("#slt_Nac").empty();
            Mx_Nac.forEach(aaa => {
                $("<option>", { "value": aaa.ID_NACIONALIDAD }).text(aaa.NAC_DESC).appendTo("#slt_Nac");
            });

            Ajax_Comuna();
        }
        //SEXO
        var Mx_Sexo = [{
            "ID_SEXO": 0,
            "SEXO_COD": 0,
            "SEXO_DESC": 0,
            "ID_ESTADO": 0
        }];
        function Ajax_Sexo() {
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Crea_Edita_Med.aspx/Llenar_Sexo",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Sexo = json_receiver;
                        Fill_Ddl_Sexo();
                    } else {
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.ExceptionType + "\n \n";
                    str_Error = response.Message;
                    alert(str_Error);
                }
            });
        }
        function Fill_Ddl_Sexo() {
            $("#slt_Sexo").empty();
            Mx_Sexo.forEach(aaa => {
                $("<option>", { "value": aaa.ID_SEXO }).text(aaa.SEXO_DESC).appendTo("#slt_Sexo");
            });
        }
        //TABLA
        var Mx_Dtt = [
            {
                "ID_DOCTOR": 0,
                "DOC_RUT": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "ID_SEXO": 0,
                "DOC_FNAC": 0,
                "ID_NACIONALIDAD": 0,
                "DOC_DIR": 0,
                "ID_REL_CIU_COM": 0,
                "DOC_FONO1": 0,
                "DOC_FONO2": 0,
                "DOC_MOVIL1": 0,
                "DOC_MOVIL2": 0,
                "DOC_EMAIL": 0,
                "ID_ESPECIALIDAD": 0,
                "ESP_DESC": 0,
                "ID_ESTADO": 0
            }
        ];
        function Ajax_Tabla() {
            modal_show();
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Crea_Edita_Med.aspx/Llena_Tabla",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = json_receiver
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
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.ExceptionType + "\n \n";
                    str_Error = response.Message;
                    alert(str_Error);
                }
            });
        }
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
                    $("<th>", { "class": "textoReducido" }).text("RUT"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre"),
                    $("<th>", { "class": "textoReducido" }).text("Telefono"),
                    $("<th>", { "class": "textoReducido" }).text("Celular"),
                    $("<th>", { "class": "textoReducido" }).text("Activo"),
                    $("<th>", { "class": "textoReducido" }).text("Especialidad")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Codiguin(` + i + `)`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DOC_RUT),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DOC_NOMBRE + " " + Mx_Dtt[i].DOC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DOC_FONO1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DOC_MOVIL1),
                        $("<td>").css("padding-left", "2vh").html("<input type='checkbox' id='chekito" + i + "' />"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ESP_DESC.toUpperCase())
                    )
                );
                if (Mx_Dtt[i].ID_ESTADO == 1) {
                    $("#chekito" + i).prop("checked", true);
                }
            }
            $('#DataTable').DataTable({
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>"
                }
            });
        }
    </script>
    <style>
        .manito {
            cursor: pointer;
        }

        button:disabled {
            cursor: no-drop;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <!-- Modal -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
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
    <!--Form-->
    <div class="card">
        <div class="card-header bg-bar">
            <h5>Crear/Editar Médico</h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-3">
                    <label for="txt_Rut">RUT <span style="color: red">*</span></label>
                    <input type="text" id="txt_Rut" class="form-control form-control-sm" />
                </div>
                <div class="col-md-3">
                    <label for="txt_Nom">Nombre <span style="color: red">*</span></label>
                    <input type="text" id="txt_Nom" class="form-control form-control-sm" />
                </div>
                <div class="col-md-3">
                    <label for="txt_Ape">Apellidos <span style="color: red">*</span></label>
                    <input type="text" id="txt_Ape" class="form-control form-control-sm" />
                </div>
                <div class="col-md-3">
                    <label for="slt_Sexo">Sexo</label>
                    <select id="slt_Sexo" class="form-control form-control-sm"></select>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <label for="">F.Nac</label>
                    <div class='input-group date' id='Txt_Date01'>
                        <input type='text' id="fecha" class="form-control form-control-sm" readonly="true" placeholder="Desde..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-md-3">
                    <label for="slt_Nac">Nacionalidad</label>
                    <select id="slt_Nac" class="form-control form-control-sm"></select>
                </div>
                <div class="col-md-3">
                    <label for="txt_Dir">Dirección <span style="color: red">*</span></label>
                    <input type="text" id="txt_Dir" class="form-control form-control-sm" />
                </div>
                <div class="col-md-3">
                    <label for="slt_Ciudad">Ciudad</label>
                    <select id="slt_Ciudad" class="form-control form-control-sm"></select>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <label for="slt_Comuna">Comuna</label>
                    <select id="slt_Comuna" class="form-control form-control-sm"></select>
                </div>
                <div class="col-md-3">
                    <label for="txt_Fono">Telefono <span style="color: red">*</span></label>
                    <input type="text" id="txt_Fono" class="form-control form-control-sm" />
                </div>
                <div class="col-md-3">
                    <label for="txt_Celu">Celular <span style="color: red">*</span></label>
                    <input type="text" id="txt_Celu" class="form-control form-control-sm" />
                </div>
                <div class="col-md-3">
                    <label for="txt_TelU">Tel. Urgencia</label>
                    <input type="text" id="txt_TelU" class="form-control form-control-sm" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <label for="txt_CelUr">Cel. Urgencia</label>
                    <input type="text" id="txt_CelUr" class="form-control form-control-sm" />
                </div>
                <div class="col-md-3">
                    <label for="txt_Correo">Correo</label>
                    <input type="text" id="txt_Correo" class="form-control form-control-sm" />
                </div>
                <div class="col-md-3">
                    <label for="slt_Espec">Especialidad</label>
                    <select id="slt_Espec" class="form-control form-control-sm"></select>
                </div>
                <div class="col-md-3">
                    <label for="slt_Estado">Estado</label>
                    <select id="slt_Estado" class="form-control form-control-sm">
                        <option value="1">Activado</option>
                        <option value="2">Desactivado</option>
                    </select>
                </div>
            </div>
            <div class="row mt-1" id="hiden_div">
                
            </div>
            <hr />
            <div class="row mb-3">
                <div class="col-md-3">
                    <button type="button" class="btn btn-block btn-limpiar" id="btn_Nuevo">
                        <i class="fa fa-fw fa-eraser mr-2"></i>
                        Limpiar</button>
                </div>
                <div class="col-md-3">
                    <button type="button" class="btn btn-block btn-primary" id="btn_Guardar">
                        <i class="fa fa-fw fa-save mr-2"></i>
                        Guardar</button>
                </div>
                <div class="col-md-3">
                    <button type="button" class="btn btn-block btn-info" id="btn_Modificar">
                        <i class="fa fa-fw fa-edit mr-2"></i>
                        Modificar</button>
                </div>
                <div class="col-md-3">
                    <button type="button" class="btn btn-block btn-danger" id="btn_Eliminar">
                        <i class="fa fa-fw fa-remove mr-2"></i>
                        Eliminar</button>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-lg-12" style="overflow: auto; max-height: 50vh;">
                    <h5 class="text-center"><i class="fa fa-list mr-2"></i>Lista de Médicos</h5>
                    <div id="Div_Tabla"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
