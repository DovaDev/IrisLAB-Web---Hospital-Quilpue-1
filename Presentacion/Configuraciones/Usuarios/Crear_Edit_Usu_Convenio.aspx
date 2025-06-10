<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Crear_Edit_Usu_Convenio.aspx.vb" Inherits="Presentacion.Crear_Edit_Usu_Convenio" %>
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
            Ajax_LugarTM();
            Ajax_Prevision();
            Ajax_Load();

            $(".block_wait").fadeOut(0);
            $("#Div_Tabla").empty();
            $("#Div_Tabla").show();
            $("#Id_Conte").hide();

            $("#Btn_Limpiar").click(function () {
                Mx_Dtt_Por_Id[0].ID_USUARIO_CONV = 0;

                $("#txtNick").val("");
                $("#txtPass").val("");
                $("#txtNom").val("");
                $("#txtApe").val("");
                $("#txtRut").val("");
                $("#txtDir").val("");
                $("#txtFono").val("");
                $("#txtCelular").val("");
                $("#txtEmail").val("");
                $("#DdlEstado").val(0);
                $("#DdlLab").val(0);
                $("#DdlPrevision").val(0);
                $("#DdlPrevision2").val(0);
                $("#DdlProcedencia").val(0);
                
                $("#txtNick, #txtPass, #txtNom, #txtApe, #txtRut, #txtDir, #txtFono, #txtCelular, #txtEmail, #DdlEstado, #DdlLab, #DdlPrevision, #DdlProcedencia").css({"border-color": "#868e96"});
            });
            

            $("#txtRut").focusout(function () {
                if ($("#txtRut").val() != "") {

                    //Capturar Anáqlisis del RUT
                    var obj_RUT = Valid_RUT($("#txtRut").val());

                    if (obj_RUT.Valid == false) {
                        var str_Error = "El RUT ingresado no es Válido, ";
                        str_Error += "ingrese en el campo de texto un RUT válido.";

                        $("#mError_AAH h4").text("Error:");
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


            //Registrar evento Click del Botón EDITAR
            $("#Btn_Guardar").click(function () {
            
                if (Mx_Dtt_Por_Id[0].ID_USUARIO_CONV != 0) {
                    $("#mError_AAH h4").text("Usuario Existente");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("El RUT ya se encuentra registrado en el sistema, presione botón MODIFICAR.");
                    $("#mError_AAH").modal();
                } else {
                    var sum = 0;
                    if ($("#txtNick").val() == "") {
                        $("#txtNick").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtNick").css({"border-color": "#868e96"});
                    }

                    if ($("#txtPass").val() == "") {
                        $("#txtPass").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtPass").css({"border-color": "#868e96"});
                    }
                    if ($("#txtNom").val() == "") {
                        $("#txtNom").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtNom").css({"border-color": "#868e96"});
                    }
                    if ($("#txtApe").val() == "") {
                        $("#txtApe").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtApe").css({"border-color": "#868e96"});
                    }
                    if ($("#txtRut").val() == "") {
                        $("#txtRut").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtRut").css({"border-color": "#868e96"});
                    }
                    if ($("#txtDir").val() == "") {
                        $("#txtDir").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtDir").css({"border-color": "#868e96"});
                    }
                    if ($("#txtFono").val() == "") {
                        $("#txtFono").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtFono").css({"border-color": "#868e96"});
                    }
                    if ($("#txtCelular").val() == "") {
                        $("#txtCelular").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtCelular").css({"border-color": "#868e96"});
                    }
                    if ($("#txtEmail").val() == "") {
                        $("#txtEmail").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtEmail").css({"border-color": "#868e96"});
                    }
                    if ($("#DdlEstado").val() == 0) {
                        $("#DdlEstado").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#DdlEstado").css({"border-color": "#868e96"});
                    }
                    if ($("#DdlLab").val() == 0) {
                        $("#DdlLab").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#DdlLab").css({"border-color": "#868e96"});
                    }
                    if ($("#DdlPrevision").val() == 0) {
                        $("#DdlPrevision").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#DdlPrevision").css({"border-color": "#868e96"});
                    }
                    if ($("#DdlProcedencia").val() == 0) {
                        $("#DdlProcedencia").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#DdlProcedencia").css({"border-color": "#868e96"});
                    }
                    if (sum == 13) {

                        Ajax_graba();

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
                if (Mx_Dtt_Por_Id[0].ID_USUARIO_CONV == 0) {
                    $("#mError_AAH h4").text("Seleccionar Usuario");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Debe buscar o seleccionar un usuario convenio.");
                    $("#mError_AAH").modal();
                } else {
                    var sum = 0;
                    if ($("#txtNick").val() == "") {
                        $("#txtNick").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtNick").css({"border-color": "#868e96"});
                    }

                    if ($("#txtPass").val() == "") {
                        $("#txtPass").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtPass").css({"border-color": "#868e96"});
                    }
                    if ($("#txtNom").val() == "") {
                        $("#txtNom").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtNom").css({"border-color": "#868e96"});
                    }
                    if ($("#txtApe").val() == "") {
                        $("#txtApe").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtApe").css({"border-color": "#868e96"});
                    }
                    if ($("#txtRut").val() == "") {
                        $("#txtRut").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtRut").css({"border-color": "#868e96"});
                    }
                    if ($("#txtDir").val() == "") {
                        $("#txtDir").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtDir").css({"border-color": "#868e96"});
                    }
                    if ($("#txtFono").val() == "") {
                        $("#txtFono").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtFono").css({"border-color": "#868e96"});
                    }
                    if ($("#txtCelular").val() == "") {
                        $("#txtCelular").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtCelular").css({"border-color": "#868e96"});
                    }
                    if ($("#txtEmail").val() == "") {
                        $("#txtEmail").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#txtEmail").css({"border-color": "#868e96"});
                    }
                    if ($("#DdlEstado").val() == 0) {
                        $("#DdlEstado").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#DdlEstado").css({"border-color": "#868e96"});
                    }
                    if ($("#DdlLab").val() == 0) {
                        $("#DdlLab").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#DdlLab").css({"border-color": "#868e96"});
                    }
                    if ($("#DdlPrevision").val() == 0) {
                        $("#DdlPrevision").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#DdlPrevision").css({"border-color": "#868e96"});
                    }
                    if ($("#DdlProcedencia").val() == 0) {
                        $("#DdlProcedencia").css({
                            "border-color": "red"
                        });
                    } else {
                        sum += 1;
                            $("#DdlProcedencia").css({"border-color": "#868e96"});
                    }
                    if (sum == 13) {

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
                if (Mx_Dtt_Por_Id[0].ID_USUARIO_CONV == 0) {
                    $("#mError_AAH h4").text("Seleccionar Usuario");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Debe buscar o seleccionar un usuario convenio.");
                    $("#mError_AAH").modal();
                } else {
                    $("#mError_AAH_CONFIRMAR").modal('hide');
                    $("#mError_AAH_CONFIRMAR h4").text("Confirmación");
                    $("#mError_AAH_CONFIRMAR p").text("¿Está seguro que desea eliminar al usuario convenio?");
                    $("#mError_AAH_CONFIRMAR").modal();
                    }
                
            });

            $("#Btn_Confirmar").click(function () {
                Ajax_delete();
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
                "url": "Crear_Edit_Usu_Convenio.aspx/Llenar_Ddl_LugarTM",
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

            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Usu_convenio.aspx/Llenar_Ddl_Prevision",
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
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        //-------------------------------------------------- LOAD ----------------------------------------------------|
        var Mx_Dtt_Load = [
            {
                "ID_USUARIO_CONV": 0,
                "USU_CONV_NIC": 0,
                "USU_CONV_PASS": 0,
                "USU_CONV_NOMBRE": 0,
                "USU_CONV_APELLIDO": 0,
                "ID_ESTADO": 0,
                "USU_RUT": 0,
                "USU_DIR": 0,
                "USU_FONO": 0,
                "USU_MOVIL": 0,
                "USU_EMAIL": 0,
                "ID_PREVE": 0,
                "ID_PROCEDENCIA": 0,
                "ID_PREVE2": 0,
                "ID_LAB": 0,
                "PROC_DESC": 0,
                "PREVE_DESC": 0,
                "PREVE_DESC_2": 0
            }
        ];

        function Ajax_Load() {
            modal_show();

            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Usu_Convenio.aspx/IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_TODOS",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt_Load = JSON.parse(json_receiver);
                        $("#Id_Conte").show();
                        $("#DataTable").empty();
                        Fill_DataTable_Load();
                        Hide_Modal();

                    } else {

                        Hide_Modal();
                        $("#DataTable").empty();
                        $("#mError_AAH h4").text("Sin Resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado usuarios convenio.");
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

        //------------------------------------------------------- CLICK EN TABLA ----------------------------------------------------|
        var Mx_Dtt_Por_Id = [
        {
            "ID_USUARIO_CONV": 0,
            "USU_CONV_NIC": 0,
            "USU_CONV_PASS": 0,
            "USU_CONV_NOMBRE": 0,
            "USU_CONV_APELLIDO": 0,
            "ID_ESTADO": 0,
            "USU_RUT": 0,
            "USU_DIR": 0,
            "USU_FONO": 0,
            "USU_MOVIL": 0,
            "USU_EMAIL": 0,
            "ID_PREVE": 0,
            "ID_PROCEDENCIA": 0,
            "ID_PREVE2": 0,
            "ID_LAB": 0,
            "PROC_DESC": 0,
            "PREVE_DESC": 0,
            "PREVE_DESC_2": 0
        }
        ];


        function Ajax_Busca_Usu_Por_Id(ID_USU) {
            modal_show();


            var Data_Par = JSON.stringify({
                "ID_USU": ID_USU
            });
            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Usu_convenio.aspx/IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_POR_ID",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Por_Id = JSON.parse(json_receiver);

                        $("#txtNick, #txtPass, #txtNom, #txtApe, #txtRut, #txtDir, #txtFono, #txtCelular, #txtEmail, #DdlEstado, #DdlLab, #DdlPrevision, #DdlProcedencia").css({ "border-color": "#868e96" });

                        $("#txtNick").val(Mx_Dtt_Por_Id[0].USU_CONV_NIC);
                        $("#txtPass").val(Mx_Dtt_Por_Id[0].USU_CONV_PASS);
                        $("#txtNom").val(Mx_Dtt_Por_Id[0].USU_CONV_NOMBRE);
                        $("#txtApe").val(Mx_Dtt_Por_Id[0].USU_CONV_APELLIDO);
                        $("#txtRut").val(Mx_Dtt_Por_Id[0].USU_RUT);
                        $("#txtDir").val(Mx_Dtt_Por_Id[0].USU_DIR);
                        $("#txtFono").val(Mx_Dtt_Por_Id[0].USU_FONO);
                        $("#txtCelular").val(Mx_Dtt_Por_Id[0].USU_MOVIL);
                        $("#txtEmail").val(Mx_Dtt_Por_Id[0].USU_EMAIL);
                        $("#DdlEstado").val(Mx_Dtt_Por_Id[0].ID_ESTADO);

                        if (Mx_Dtt_Por_Id[0].ID_LAB != null) {
                            $("#DdlLab").val(Mx_Dtt_Por_Id[0].ID_LAB);
                        } else {
                            $("#DdlLab").val(0);
                        }
                        
                        if (Mx_Dtt_Por_Id[0].ID_PREVE != null) {
                            $("#DdlPrevision").val(Mx_Dtt_Por_Id[0].ID_PREVE);
                        } else {
                            $("#DdlPrevision").val(0);
                        }

                        if (Mx_Dtt_Por_Id[0].ID_PREVE2 != null) {
                            $("#DdlPrevision2").val(Mx_Dtt_Por_Id[0].ID_PREVE2);
                        } else {
                            $("#DdlPrevision2").val(0);
                        }

                        if (Mx_Dtt_Load[0].ID_PROCEDENCIA != null) {
                            $("#DdlProcedencia").val(Mx_Dtt_Por_Id[0].ID_PROCEDENCIA);
                        } else {
                            $("#DdlProcedencia").val(0);
                        }

                        Hide_Modal();
                        
                    } else {
                        $("#txtNick, #txtPass, #txtNom, #txtApe, #txtRut, #txtDir, #txtFono, #txtCelular, #txtEmail, #DdlEstado, #DdlLab, #DdlPrevision, #DdlProcedencia").css({ "border-color": "#868e96" });
                        Hide_Modal();
                    
                        $("#txtNick").val("");
                        $("#txtPass").val("");
                        $("#txtNom").val("");
                        $("#txtApe").val("");
                        $("#txtRut").val("");
                        $("#txtDir").val("");
                        $("#txtFono").val("");
                        $("#txtCelular").val("");
                        $("#txtEmail").val("");
                        $("#DdlEstado").val(0);
                        $("#DdlLab").val(0);
                        $("#DdlPrevision").val(0);
                        $("#DdlPrevision2").val(0);                      
                        $("#DdlProcedencia").val(0);

                        Mx_Dtt_Por_Id[0].ID_USUARIO_CONV = 0;
                                                    

                        $("#mError_AAH h4").text("Sin Resultados");
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

        //----------------------------------------------------------- AJAX UPDATE --------------------------------------------
        function Ajax_update(ID_USU) {
            modal_show();

            var Data_Par = JSON.stringify({
                "ID_USU": Mx_Dtt_Por_Id[0].ID_USUARIO_CONV,
                "USU_CONV_NIC": $("#txtNick").val(),
                "USU_CONV_PASS": $("#txtPass").val(),
                "USU_CONV_NOMBRE": $("#txtNom").val(),
                "USU_CONV_APELLIDO": $("#txtApe").val(),
                "USU_RUT": $("#txtRut").val(),
                "USU_DIR": $("#txtDir").val(),
                "USU_FONO": $("#txtFono").val(),
                "USU_MOVIL": $("#txtCelular").val(),
                "USU_EMAIL": $("#txtEmail").val(),
                "ID_ESTADO": $("#DdlEstado").val(),
                "ID_LAB": $("#DdlLab").val(),
                "ID_PREVE": $("#DdlPrevision").val(),
                "ID_PREVE2": $("#DdlPrevision2").val(),
                "ID_PROCEDENCIA": $("#DdlProcedencia").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Usu_convenio.aspx/IRIS_WEBF_UPDATE_USUARIOS_CONVENIO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        
                        Mx_Dtt_Por_Id[0].ID_USUARIO_CONV = 0;

                        $("#txtNick").val("");
                        $("#txtPass").val("");
                        $("#txtNom").val("");
                        $("#txtApe").val("");
                        $("#txtRut").val("");
                        $("#txtDir").val("");
                        $("#txtFono").val("");
                        $("#txtCelular").val("");
                        $("#txtEmail").val("");
                        $("#DdlEstado").val(0);
                        $("#DdlLab").val(0);
                        $("#DdlPrevision").val(0);
                        $("#DdlPrevision2").val(0);                      
                        $("#DdlProcedencia").val(0);                
                        
                        $("#mError_AAH h4").text("Actualización Correcta");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("El usuario convenio ha sido actualizado satisfactoriamente.");
                        $("#mError_AAH").modal();

                        Ajax_Load();

                    } else {

                        Hide_Modal();

                        $("#txtNick").val("");
                        $("#txtPass").val("");
                        $("#txtNom").val("");
                        $("#txtApe").val("");
                        $("#txtRut").val("");
                        $("#txtDir").val("");
                        $("#txtFono").val("");
                        $("#txtCelular").val("");
                        $("#txtEmail").val("");
                        $("#DdlEstado").val(0);
                        $("#DdlLab").val(0);
                        $("#DdlPrevision").val(0);
                        $("#DdlPrevision2").val(0);
                        $("#DdlProcedencia").val(0);

                        Mx_Dtt_Por_Id[0].ID_USUARIO_CONV = 0;


                        $("#mError_AAH h4").text("Sin Actualización");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se ha podido actualizar al usuario convenio.");
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

        //----------------------------------------------------------- AJAX GRABA --------------------------------------------
        function Ajax_graba(ID_USU) {
            modal_show();

            var Data_Par = JSON.stringify({
                "ID_USU": Mx_Dtt_Por_Id[0].ID_USUARIO_CONV,
                "USU_CONV_NIC": $("#txtNick").val(),
                "USU_CONV_PASS": $("#txtPass").val(),
                "USU_CONV_NOMBRE": $("#txtNom").val(),
                "USU_CONV_APELLIDO": $("#txtApe").val(),
                "USU_RUT": $("#txtRut").val(),
                "USU_DIR": $("#txtDir").val(),
                "USU_FONO": $("#txtFono").val(),
                "USU_MOVIL": $("#txtCelular").val(),
                "USU_EMAIL": $("#txtEmail").val(),
                "ID_ESTADO": $("#DdlEstado").val(),
                "ID_LAB": $("#DdlLab").val(),
                "ID_PREVE": $("#DdlPrevision").val(),
                "ID_PREVE2": $("#DdlPrevision2").val(),
                "ID_PROCEDENCIA": $("#DdlProcedencia").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Usu_convenio.aspx/IRIS_WEBF_GRABA_USUARIOS_CONVENIO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        
                        Mx_Dtt_Por_Id[0].ID_USUARIO_CONV = 0;

                        $("#txtNick").val("");
                        $("#txtPass").val("");
                        $("#txtNom").val("");
                        $("#txtApe").val("");
                        $("#txtRut").val("");
                        $("#txtDir").val("");
                        $("#txtFono").val("");
                        $("#txtCelular").val("");
                        $("#txtEmail").val("");
                        $("#DdlEstado").val(0);
                        $("#DdlLab").val(0);
                        $("#DdlPrevision").val(0);
                        $("#DdlPrevision2").val(0);                      
                        $("#DdlProcedencia").val(0);                
                
                        $("#mError_AAH h4").text("Creación Correcta");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("El usuario convenio ha sido creado satisfactoriamente.");
                        $("#mError_AAH").modal();
    
                        Ajax_Load();

                    } else {

                        Hide_Modal();

                        $("#txtNick").val("");
                        $("#txtPass").val("");
                        $("#txtNom").val("");
                        $("#txtApe").val("");
                        $("#txtRut").val("");
                        $("#txtDir").val("");
                        $("#txtFono").val("");
                        $("#txtCelular").val("");
                        $("#txtEmail").val("");
                        $("#DdlEstado").val(0);
                        $("#DdlLab").val(0);
                        $("#DdlPrevision").val(0);
                        $("#DdlPrevision2").val(0);
                        $("#DdlProcedencia").val(0);

                        Mx_Dtt_Por_Id[0].ID_USUARIO_CONV = 0;


                        $("#mError_AAH h4").text("Sin Creación");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se ha podido crear al usuario convenio.");
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

        //----------------------------------------------------------- AJAX DELETE --------------------------------------------
        function Ajax_delete(ID_USU) {
            modal_show();

            var Data_Par = JSON.stringify({
                "ID_USU": Mx_Dtt_Por_Id[0].ID_USUARIO_CONV,
                "USU_CONV_NIC": $("#txtNick").val(),
                "USU_CONV_PASS": $("#txtPass").val(),
                "USU_CONV_NOMBRE": $("#txtNom").val(),
                "USU_CONV_APELLIDO": $("#txtApe").val(),
                "USU_RUT": $("#txtRut").val(),
                "USU_DIR": $("#txtDir").val(),
                "USU_FONO": $("#txtFono").val(),
                "USU_MOVIL": $("#txtCelular").val(),
                "USU_EMAIL": $("#txtEmail").val(),
                "ID_ESTADO": 2,
                "ID_LAB": $("#DdlLab").val(),
                "ID_PREVE": $("#DdlPrevision").val(),
                "ID_PREVE2": $("#DdlPrevision2").val(),
                "ID_PROCEDENCIA": $("#DdlProcedencia").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Crear_Edit_Usu_convenio.aspx/IRIS_WEBF_UPDATE_USUARIOS_CONVENIO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt_Por_Id[0].ID_USUARIO_CONV = 0;

                        $("#txtNick").val("");
                        $("#txtPass").val("");
                        $("#txtNom").val("");
                        $("#txtApe").val("");
                        $("#txtRut").val("");
                        $("#txtDir").val("");
                        $("#txtFono").val("");
                        $("#txtCelular").val("");
                        $("#txtEmail").val("");
                        $("#DdlEstado").val(0);
                        $("#DdlLab").val(0);
                        $("#DdlPrevision").val(0);
                        $("#DdlPrevision2").val(0);
                        $("#DdlProcedencia").val(0);

                        $("#mError_AAH_CONFIRMAR").modal('hide');
                        $("#mError_AAH h4").text("Eliminación Correcta");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("El usuario convenio ha sido eliminado satisfactoriamente.");
                        $("#mError_AAH").modal();

                        Ajax_Load();

                    } else {

                        Hide_Modal();

                        $("#txtNick").val("");
                        $("#txtPass").val("");
                        $("#txtNom").val("");
                        $("#txtApe").val("");
                        $("#txtRut").val("");
                        $("#txtDir").val("");
                        $("#txtFono").val("");
                        $("#txtCelular").val("");
                        $("#txtEmail").val("");
                        $("#DdlEstado").val(0);
                        $("#DdlLab").val(0);
                        $("#DdlPrevision").val(0);
                        $("#DdlPrevision2").val(0);
                        $("#DdlProcedencia").val(0);
                        $("#mError_AAH_CONFIRMAR").modal('hide');
                        Mx_Dtt_Por_Id[0].ID_USUARIO_CONV = 0;


                        $("#mError_AAH h4").text("Sin Eliminación");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se ha podido eliminar al usuario convenio.");
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
    </script>

    <%-- Funciones de Llenado de Elementos --%>

    <script>
        //Llenar DropDownList Diagnostico
        function Fill_Ddl_LugarTM() {
            $("#DdlProcedencia").empty();

            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#DdlProcedencia");

            for (y = 0; y < Mx_Dtt_LugarTM.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_LugarTM[y].ID_PROCEDENCIA
                }).text(Mx_Dtt_LugarTM[y].PROC_DESC).appendTo("#DdlProcedencia");
            }
        };

        function Fill_Ddl_Prevision() {
            $("#DdlPrevision").empty();
            $("#DdlPrevision2").empty();

            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#DdlPrevision");
            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#DdlPrevision2");

            for (y = 0; y < Mx_Dtt_Prevision.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_Prevision[y].ID_PREVE
                }).text(Mx_Dtt_Prevision[y].PREVE_DESC).appendTo("#DdlPrevision");

                $("<option>", {
                    "value": Mx_Dtt_Prevision[y].ID_PREVE
                }).text(Mx_Dtt_Prevision[y].PREVE_DESC).appendTo("#DdlPrevision2");
            }
        };

    </script>

    <script>

        //---------------------------------------------------- TABLA PACIENTE ------------------.........-------------------------------|
        function Fill_DataTable_Load() {
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
                    $("<th>", { "class": "textoReducido" }).text("Nick"),                
                    $("<th>", { "class": "textoReducido" }).text("Nombre"),
                    $("<th>", { "class": "textoReducido" }).text("Rut"),
                    $("<th>", { "class": "textoReducido" }).text("Dirección"),
                    $("<th>", { "class": "textoReducido" }).text("Celular"),
                    $("<th>", { "class": "textoReducido" }).text("Teléfono"),
                    $("<th>", { "class": "textoReducido" }).text("Email"),
                    $("<th>", { "class": "textoReducido" }).text("Laboratorio"),
                    $("<th>", { "class": "textoReducido" }).text("Previsión"),
                    $("<th>", { "class": "textoReducido" }).text("Previsión 2"),
                    $("<th>", { "class": "textoReducido" }).text("Procedencia")

                )
            );

            for (i = 0; i < Mx_Dtt_Load.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Busca_Usu_Por_Id("` + Mx_Dtt_Load[i].ID_USUARIO_CONV + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].USU_CONV_NIC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].USU_CONV_NOMBRE + " " + Mx_Dtt_Load[i].USU_CONV_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].USU_RUT),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].USU_DIR),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].USU_MOVIL),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].USU_FONO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].USU_EMAIL),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(""),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].PREVE_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].PREVE_DESC_2),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].PROC_DESC)
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
            Crear/Editar Usuario Convenio
        </h5>
    </div>
    <div>
                <%----------------------------- 1ra fila -----------------------------%>
    <div class="row">
        <div class="col-md-3">
            <label for="txtNick">Nick:</label>
            <input id="txtNick" class="form-control text-uppercase textoReducido" type="text"/>
        </div>
        <div class="col-md-3">
            <label for="txtPass">Contraseña:</label>
            <input id="txtPass" class="form-control text-uppercase textoReducido" type="password"/>
        </div>
        <div class="col-md-3">
            <label for="txtNom">Nombre:</label>
            <input id="txtNom" class="form-control text-uppercase textoReducido" type="text"/>
        </div>
        <div class="col-md-3">
            <label for="txtApe">Apellido:</label>
            <input id="txtApe" class="form-control text-uppercase textoReducido" type="text"/>
        </div>
    </div>
        <%------------------------------ 2da fila ---------------------------------%>
        <div class="row">
            <div class="col-md-2">
                <label for="txtRut">Rut:</label>
                <input id="txtRut" class="form-control textoReducido" type="text"/>
            </div>
            <div class="col-md-2">
                <label for="txtDir">Dirección:</label>
                <input id="txtDir" class="form-control textoReducido" type="text"/>
            </div>
            <div class="col-md-2">
                <label for="txtFono">Fono:</label>
                <input id="txtFono" class="form-control textoReducido mayus" type="text"/>
            </div>
            <div class="col-md-2">
                <label for="txtCelular">Celular:</label>
                <input id="txtCelular" class="form-control textoReducido mayus" type="text"/>
            </div>
            <div class="col-md-2">
                <label for="txtEmail">Email:</label>
                <input id="txtEmail" class="form-control textoReducido mayus" type="text"/>
            </div>
            <div class="col-md-2">
                <label for="DdlEstado">Estado:</label>
                <select id="DdlEstado" class="form-control textoReducido">
                    <option value="0">Seleccionar</option>
                    <option value="1"><< Activado >></option>
                    <option value="3"><< Desactivado >></option>
                </select>
            </div>
        </div>
        <%---------------------------- 3ra fila ------------------------------------%>
        <div class="row">
            <div class="col-md-3">
                <label for="DdlLab">Laboratorio:</label>
                <select id="DdlLab" class="form-control textoReducido">
                    <option value="0">Seleccionar</option>
                    <option value="1">Valor PRUEBA</option>
                </select>
            </div>
            <div class="col-md-3">
                <label for="DdlPrevision">Previsión:</label>
                <select id="DdlPrevision" class="form-control textoReducido">
                </select>
            </div>
            <div class="col-md-3">
                <label for="DdlPrevision2">Previsión 2:</label>
                <select id="DdlPrevision2" class="form-control textoReducido">
                </select>
            </div>
            <div class="col-md-3">
                <label for="DdlProcedencia">Procedencia:</label>
                <select id="DdlProcedencia" class="form-control textoReducido">
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
    <div class="row" id="Id_Conte" style="margin-left: 1px; width: 100%;">
        <div class="col-lg-12" id="Paciente">
            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i> Listado de Usuarios Convenio</h5>
            <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
        </div>
    </div>
</asp:Content>
