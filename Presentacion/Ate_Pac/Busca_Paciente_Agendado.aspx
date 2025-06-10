<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Busca_Paciente_Agendado.aspx.vb" Inherits="Presentacion.Busca_Paciente_Agendado" %>
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
            $(".block_wait").fadeOut(0);
            $("#Div_Tabla").empty();

            $("#Div_Tabla_Listado_Exa_Ate").empty();
            $("#Div_Tabla_Ate_ONCLICK").empty();
            $("#Div_Tabla").show();
            $("#Div_Tabla_Listado_Exa_Ate").show();
            $("#Id_Conte").hide();
            //Registrar evento Click del Botón Buscar       
            $("#Btn_Buscar").click(function () {

                if ($("#txtRut").val() == "" && $("#txtNom").val() == "" && $("#txtApe").val() == "" && $("#txtDNI").val() == "") {

                    $("#mError_AAH h4").text("Ingrese");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, ingrese el campo a buscar");
                    $("#mError_AAH").modal();

                } else {
                    $("#Div_Tabla").empty();
                    $("#Div_Tabla_Listado_Exa_Ate").empty();
                    Ajax_DataTable();
                }


            });
            $("#Btn_Buscar_x_ate").click(function () {

                if ($("#txtNAte").val() == "") {

                    $("#mError_AAH h4").text("Ingrese un Número");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, ingrese el campo a buscar");
                    $("#mError_AAH").modal();

                } else {
                    $("#Div_Tabla_Ate").empty();
                    $("#Div_Tabla_Listado_Exa_Ate").empty();
                    $("#Div_Tabla_Ate_ONCLICK").empty();
                    Ajax_DataTable_Ate();
                }


            });
            $("#Btn_limpiar").click(function () {
                $("#DataTable").empty();
                $("#Div_Tabla_Ate").empty();
                $("#Div_Tabla_Listado_Exa_Ate").empty();
                $("#Div_Tabla_Ate_ONCLICK").empty();
                $("#txtRut").val("");
                $("#txtNom").val("");
                $("#txtApe").val("");
                $("#txtNAte").val("");
                $("#txtDNI").val("");
                $("#txtRut").css({"border-color": "#868e96"});
                

            });

            $("#Btn_redirect").click(function () {
                Redirect();
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

                    }
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
                "ID_LUGAR_TM": 0,
                "DESC_LUGAR_TM": 0,
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
            $.ajax({
                "type": "POST",
                "url": "Busca_Paciente_Agendado.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);

                        $("#Div_Tabla_Ate_ONCLICK").empty();
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
                    $("#Div_Tabla_Ate").hide();
                    $("#Div_Tabla_Ate_ONCLICK").hide();
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);


                }
            });
        }


        //---------------------------------------------LISTADO DE ATENCIONES ON CLICK------------------------------------|
        var Mx_Dtt_Ate_ONCLICK = [
          {
              "ID_ATENCION": 0,
              "PAC_NOMBRE": 0,
              "PAC_APELLIDO": 0,
              "ATE_NUM": 0,
              "ATE_FECHA": 0,
              "DOC_NOMBRE": 0,
              "DOC_APELLIDO": 0,
              "PREVE_DESC": 0,
              "PROC_DESC": 0,
              "TP_ATE_DESC": 0,
              "ID_PACIENTE": 0,
              "PREI_FECHA_PRE": 0
          }
        ];

        function Ajax_DataTable_Ate_ONCLICK(ID_PAC) {
            modal_show();

            var Data_Par = JSON.stringify({
                "ID_PAC": ID_PAC
            });
            $.ajax({
                "type": "POST",
                "url": "Busca_Paciente_Agendado.aspx/Llenar_DataTable_Ate_ONCLICK",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Ate_ONCLICK = JSON.parse(json_receiver);
                        $("#Div_Tabla_Ate_ONCLICK").empty();

                        $("#NombreWichipirichi").text(Mx_Dtt_Ate_ONCLICK[0].PAC_NOMBRE + " " + Mx_Dtt_Ate_ONCLICK[0].PAC_APELLIDO);

                        $("#DocWichipirichi").text(Mx_Dtt_Ate_ONCLICK[0].DOC_NOMBRE + " " + Mx_Dtt_Ate_ONCLICK[0].DOC_APELLIDO);

                        for (i = 0; i < Mx_Dtt_Ate_ONCLICK.length; ++i) {
                            var date_x = Mx_Dtt_Ate_ONCLICK[i].PREI_FECHA_PRE;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Ate_ONCLICK[i].PREI_FECHA_PRE = Date_Change;
                        }

                        Fill_DataTable_Ate_ONCLICK();
                        Hide_Modal();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados.");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $("#Div_Tabla_Ate").hide();
                    $("#Div_Tabla_Ate_ONCLICK").show();
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);


                }
            });
        }

        //---------------------------------------------LISTADO DE ATENCIONES------------------------------------|
        var Mx_Dtt_Ate = [
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
              "DOC_NOMBRE": 0,
              "DOC_APELLIDO": 0,
              "PREI_FECHA_PRE": 0
          }
        ];

        function Ajax_DataTable_Ate() {


            var Data_Par = JSON.stringify({
                "NUM_ATE": $("#txtNAte").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Busca_Paciente_Agendado.aspx/Llenar_DataTable_Ate",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Ate = JSON.parse(json_receiver);
                        $("#Div_Tabla").empty();

                        $("#NombreWichipirichi").text(Mx_Dtt_Ate[0].PAC_NOMBRE + " " + Mx_Dtt_Ate[0].PAC_APELLIDO);
                        $("#DocWichipirichi").text(Mx_Dtt_Ate[0].DOC_NOMBRE + " " + Mx_Dtt_Ate[0].DOC_APELLIDO);

                        for (i = 0; i < Mx_Dtt_Ate.length; ++i) {
                            var date_x = Mx_Dtt_Ate[i].PREI_FECHA_PRE;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Ate[i].PREI_FECHA_PRE = Date_Change;
                        }

                        Fill_DataTable_Ate();


                    } else {


                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados.");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $("#Div_Tabla_Ate").show();
                    $("#Div_Tabla_Ate_ONCLICK").hide();
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
            $.ajax({
                "type": "POST",
                "url": "Busca_Paciente_Agendado.aspx/Llenar_DataTable_Det_Ate",
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
                        $('#numerito').text("N° de Atención: " + Mx_Dtt_Det_Ate[0].NUM_ATE);
                        $('#nombrecito').text("Nombre: " + Mx_Dtt_Det_Ate[0].PAC_NOMBRE + " " + Mx_Dtt_Det_Ate[0].PAC_APELLIDO);
                        $('#eModal').modal('show');


                    } else {


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

        function Ajax_Redirect(ID_ATE) {


            var Data_Par = JSON.stringify({
                "ID_ATE": ID_ATE
            });
            $.ajax({
                "type": "POST",
                "url": "Busca_Paciente_Agendado.aspx/Llenar_DataTable_Det_Ate",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Det_Ate = JSON.parse(json_receiver);


                        //window.location.href = "/Buscar_Ate/Buscar_Atencion.aspx" + 


                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);


                }
            });
        }

        //Llenar DropDownList Ciudad
        function Redirect() {
            var loc = location.origin;
            window.open(loc + "/Buscar_Ate/Atencion_Det.aspx" + "?ID_ATE" + "=" + Mx_Dtt_Det_Ate[0].ENCRYPTED_ID);
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
                    $("<th>", { "class": "textoReducido" }).text("Rut"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre"),
                    //$("<th>", { "class": "textoReducido" }).text("Fono"),
                    $("<th>", { "class": "textoReducido" }).text("Procedencia")

                )
            );
            var procee = Galletas.getGalleta("USU_ID_PROC");
            var admin = Galletas.getGalleta("P_ADMIN");
            if (procee == 0) {
                for (i = 0; i < Mx_Dtt.length; i++) {

                    $("#DataTable tbody").append(
                        $("<tr>", {
                            "onclick": `Ajax_DataTable_Ate_ONCLICK("` + Mx_Dtt[i].ID_PACIENTE + `")`,
                            "class": "manito"
                        }).append(
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_RUT),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                            //$("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_FONO1),

                           $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DESC_LUGAR_TM)
                        )
                    );
                    $("<tr>").attr("id", i + 1);
                }
            } else {
                var count = 0;
                for (i = 0; i < Mx_Dtt.length; i++) {
                    if (Mx_Dtt[i].ID_LUGAR_TM == procee) {
                        count++;
                        $("#DataTable tbody").append(
                            $("<tr>", {
                                "onclick": `Ajax_DataTable_Ate_ONCLICK("` + Mx_Dtt[i].ID_PACIENTE + `")`,
                                "class": "manito"
                            }).append(
                                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(count),
                                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_RUT),
                                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                                //$("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_FONO1),

                           $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DESC_LUGAR_TM)
                            )
                        );
                        $("<tr>").attr("id", i + 1);
                    }

                }
            }


            active_tr();
        }


        //-----------------------------------------------TABLA ATENCIONES ON CLICK DESDE PACIENTE-------------------------------------------|
        function Fill_DataTable_Ate_ONCLICK() {
            $("<table>", {
                "id": "DataTable_Ate_ONCLICK",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Ate_ONCLICK");

            $("#DataTable_Ate_ONCLICK").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Ate_ONCLICK").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Ate_ONCLICK thead").attr("class", "cabzera");
            $("#DataTable_Ate_ONCLICK thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Nº Agendamiento"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Agendamiento"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Toma de Muestra"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre")

                )
            );

            for (i = 0; i < Mx_Dtt_Ate_ONCLICK.length; i++) {
                $("#DataTable_Ate_ONCLICK tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_DataTable_Det_Ate("` + Mx_Dtt_Ate_ONCLICK[i].ID_ATENCION + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Ate_ONCLICK[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Ate_ONCLICK[i].ATE_FECHA),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(moment(Mx_Dtt_Ate_ONCLICK[i].PREI_FECHA_PRE).format("DD/MM/YYYY")),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Ate_ONCLICK[i].PAC_NOMBRE + " " + Mx_Dtt_Ate_ONCLICK[i].PAC_APELLIDO)
                    )
                );
                $("<tr>").attr("id", i + 1);
            }
            active_tr();
        }

        //-----------------------------------------------TABLA ATENCIONES-------------------------------------------|
        function Fill_DataTable_Ate() {
            $("<table>", {
                "id": "DataTable_Ate",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Ate");

            $("#DataTable_Ate").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Ate").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Ate thead").attr("class", "cabzera");
            $("#DataTable_Ate thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Nº Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Agendamiento"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Toma de Muestra"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre")

                )
            );

            for (i = 0; i < Mx_Dtt_Ate.length; i++) {
                $("#DataTable_Ate tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_DataTable_Det_Ate("` + Mx_Dtt_Ate[i].ID_ATENCION + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Ate[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Ate[i].ATE_FECHA),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(moment(Mx_Dtt_Ate[i].PREI_FECHA_PRE).format("DD/MM/YYYY")),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Ate[i].PAC_NOMBRE + " " + Mx_Dtt_Ate[i].PAC_APELLIDO)
                    )
                );
                $("<tr>").attr("id", i + 1);
            }

        }
        //-----------------------------------------TABLA LISTADO DE EXAMENES de la ATENCIONES-------------------------------------------|
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
            $("#DataTable_Lis_Exa_Ate thead").attr("class", "cabzera");
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
                        //"onclick": `Redirect("` + Mx_Dtt_Det_Ate[i].ENCRYPTED_ID + `")`,
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

            //Declarar evento
            $("#DataTable_Lis_Exa_Ate tbody tr").click(function () {
                $("#DataTable_Lis_Exa_Ate tbody tr").removeClass("active");
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
            max-height: 60vh; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .highlights2 {
            width: 710px;
            max-height: 60vh; /* Ancho y alto fijo */
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
                    <h5 style="text-align: center; padding: 5px;" class="modal-title" id="sss">Listado Exámenes de la Atención</h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col">
                                <label>Nombre Paciente: </label>
                                <label id="NombreWichipirichi"></label>
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <label>Nombre Doctor: </label>
                                <label id="DocWichipirichi"></label>
                            </div>
                        </div>
                    </div>
                    <form>
                        <div id="Div_Tabla_Listado_Exa_Ate" style="width: 100%;" class="table-responsive"></div>
                    </form>
                </div>
                <div class="modal-footer">
                    <%--<button type="button" class="btn btn-info" id="Btn_redirect"><i class="fa fa-fw fa-eye mr-2"></i>Ver Detalles</button>--%>
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
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div class="card border-bar">
                <div class="card-header bg-bar p-2">
                    <h5 style="text-align: center;">
                        <i class="fa fa-search"></i>
                        Buscar Pacientes Agendados
                    </h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-8">
                            <div class="row">
                                <div class="col-lg">
                                    <label for="txtRut">RUT:</label>
                                    <input id="txtRut" class="form-control textoReducido" type="text" placeholder="BUSCAR..." />
                                </div>
                                <div class="col-lg">
                                    <label for="txtDNI">DNI:</label>
                                    <input id="txtDNI" class="form-control textoReducido" type="text"/>
                                </div>
                                <div class="col-lg">
                                    <label for="txtNom">Nombre:</label>
                                    <input id="txtNom" class="form-control text-uppercase textoReducido" type="text"/>
                                </div>
                                <div class="col-lg">
                                    <label for="txtApe">Apellido:</label>
                                    <input id="txtApe" class="form-control text-uppercase textoReducido" type="text"/>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-lg">
                                    <button id="Btn_Buscar" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                                </div>
                                <div class="col-lg-4">
                                    <button id="Btn_limpiar" class="btn btn-limpiar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-eraser mr-2"></i>Limpiar</button>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="row">
                                <div class="col-lg">
                                    <label for="txtNAte">N° Agendamiento:</label>
                                    <input id="txtNAte" maxlength="9" class="form-control textoReducido" type="text" placeholder="BUSCAR POR NUM AGEN..." onkeydown="return jsDecimals(event);" />
                                    <button id="Btn_Buscar_x_ate" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar por Num. de Agen.</button>
                                </div>

                            </div>

                        </div>
                    </div>
                    <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
                    <div id="Id_Conte">
                        <hr />
                        <div class="row">
                            <div class="col-lg-6" id="Paciente">
                                <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list mr-2"></i>Datos del Paciente</h5>
                                <div id="Div_Tabla" style="max-width: 100%;" class="highlights"></div>
                            </div>
                            <div class="col-lg-6">
                                <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list mr-2"></i>Listado de Agenda/Atenciones</h5>
                                <div id="Div_Tabla_Ate" style="max-width: 100%; margin-left: 2px;" class="highlights2"></div>
                                <div id="Div_Tabla_Ate_ONCLICK" style="max-width: 100%; margin-left: 2px;" class="highlights2"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>
</asp:Content>
