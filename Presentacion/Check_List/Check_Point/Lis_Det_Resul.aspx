<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Lis_Det_Resul.aspx.vb" Inherits="Presentacion.Lis_Det_Resul" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script>
        var det_r;
        var det_tm;
        var ID_ATE_RED;
        $(document).ready(function () {
            $("#Id_Conte").hide();
            Ajax_LugarTM();
            Ajax_Seccion();
            $("#btn_det").click(fn => {
                Ajax_Redirect();
            });
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
            //Registrar evento Click del Botón Buscar       
            $("#Btn_Buscar").click(function () {
                $("#Div_Tabla").empty();
                Ajax_DataTable();
            });
            //Registrar evento Click del Botón Excel       
            $("#Btn_Excel").click(function () {
                Ajax_Excel();
            });
            Btn_Excel
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
                "url": "Chk_Est_Seccion.aspx/Llenar_Ddl_LugarTM",
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
        //------------------------------------------------ AJAX DDL SECCION -------------------------------------------|
        var Mx_Seccion = [
    {
        "ID_RLS_LS": 0,
        "RLS_LS_DESC": 0
    }
        ];
        function Ajax_Seccion() {
            modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Chk_Est_Seccion.aspx/Llenar_Ddl_Seccion",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Seccion = JSON.parse(json_receiver);
                        Fill_Ddl_Seccion();
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
        //-------------------------------------------------- AJAX TABLA MAIN ----------------------------------------------|
        var Mx_Dtt = [
            {
                "ID_T_MUESTRA": 0,
                "ATE_NUM": 0,
                "T_MUESTRA_DESC": 0,
                "CB_DESC": 0,
                "IDTM": 0,
                "ID_ATENCION": 0,
                "GMUE_DESC": 0,
                "ATE_FECHA": 0,
                "ATE_NUM_INTERNO": 0,
                "ATE_EST_RECEP": 0,
                "EST_DESCRIPCION": 0,
                "CF_DESC": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "PAC_RUT": 0,
                "PROC_DESC": 0,
                "ID_PACIENTE": 0,
                "ATE_AÑO": 0,
                "ID_SEXO": 0,
                "ATE_EST_RECHAZO": 0,
                "ATE_EST_DERIVA": 0,
                "ID_CODIGO_FONASA": 0,
                "ATE_DET_V_ID_ESTADO": 0,
                "ATE_DET_REV_ID_ESTADO": 0,
                "Expr1": 0,
                "Expr2": 0,
                "SEXO_DESC": 0,
                "PAC_FNAC": 0,
                "ATE_DNI": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "ID_PROCEDENCIA": 0,
                "NAC_DESC": 0,
                "PROGRA_DESC": 0,
                "SECTOR_DESC": 0,
                "NAte": 0,
                "NExa": 0,
                "recSi": 0,
                "recNo": 0,
                "valiSi": 0,
                "valiNo": 0,
                "rechSi": 0,
                "rechNo": 0,
                "total": 0
            }
        ];
        function Ajax_DataTable() {
            modal_show();

            var Data_Par = JSON.stringify({
                "TIPO": 0,
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PRE": $("#Ddl_LugarTM").val(),
                "ID_CF": 0,
                "ID_VAL": 0,
                "ID_NMUE": 0,
                "ID_SECCION": $("#Ddl_Seccion").val(),
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_Det_Resul.aspx/Llenar_DataTable",
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
                        $("#txtNate").text(Mx_Dtt[0].NAte);
                        $("#txtNExa").text(Mx_Dtt[0].NExa);
                        $("#txtRecepSi").text(Mx_Dtt[0].recSi);
                        $("#txtRecepNo").text(Mx_Dtt[0].recNo);
                        $("#txtValidadoSisisisisisoi").text(Mx_Dtt[0].valiSi);
                        $("#txtValidadoNo").text(Mx_Dtt[0].valiNo);
                        $("#txtRechaSi").text(Mx_Dtt[0].rechSi);
                        $("#txtRechaNo").text(Mx_Dtt[0].rechNo);
                        $("#txtTotal").text(Mx_Dtt[0].total);

                        Fill_DataTable();
                        Hide_Modal();

                        $("#Id_Conte").show();
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
        function Ajax_DataTable_Det_Ate(ID_ATE, yyy) {
            modal_show();
            var pos = yyy;
            var sx = Mx_Dtt[pos].ID_SEXO;
            if (sx == 2) {
                sx = "FEMENINO";
            }
            else {
                sx = "MASCULINO";
            }

            var Data_Par = JSON.stringify({
                "ID_ATE": ID_ATE
            });
            //$(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_Det_Resul.aspx/Llenar_DataTable_Det_Ate",
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
                        Hide_Modal();

                        ID_ATE_RED = Mx_Dtt_Det_Ate[0].ENCRYPTED_ID;
                        $('#numerito').text("N° Atención: " + Mx_Dtt_Det_Ate[0].NUM_ATE);
                        $('#emodal_rut').text("RUT: " + Mx_Dtt[pos].PAC_RUT);
                        $('#nombrecito').text("Nombre: " + Mx_Dtt_Det_Ate[0].PAC_NOMBRE + " " + Mx_Dtt_Det_Ate[0].PAC_APELLIDO).addClass("text-uppercase");
                        $('#emodal_fecha').text("Fecha: " + moment(Mx_Dtt_Det_Ate[0].ATE_FECHA).format("DD-MM-YYYY"));
                        $('#emodal_lugartm').text("Lugar de TM: " + Mx_Dtt[pos].PROC_DESC);
                        $('#emodal_sexo').text("Sexo: " + sx);
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
                    Hide_Modal();
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
                "TIPO": 0,
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PRE": $("#Ddl_LugarTM").val(),
                "ID_CF": $("#Ddl_Seccion").val(),
                "ID_VAL": 0,
                "ID_NMUE": 0,
                "ID_SECCION": 0,
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_Det_Resul.aspx/Excel",
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
        //Llenar DropDownList Lugar de TM
        function Fill_Ddl_LugarTM() {
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
        function Fill_Ddl_Seccion() {

            $("#Ddl_Seccion").empty();
            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Seccion");
            for (y = 0; y < Mx_Seccion.length; ++y) {
                $("<option>", {
                    "value": Mx_Seccion[y].ID_RLS_LS
                }).text(Mx_Seccion[y].RLS_LS_DESC).appendTo("#Ddl_Seccion");
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
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Interno"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Rut Paciente"),
                    $("<th>", { "class": "textoReducido text-center" }).text("DNI"),
                    $("<th>", { "class": "textoReducido" }).text("Nacionalidad"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Nac"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Edad"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Hora"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar de TM"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Sexo"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Programa"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Sector"),
                    $("<th>", { "class": "textoReducido" }).text("Examen"),
                    $("<th>", { "class": "textoReducido" }).text("Tipo Etiqueta"),
                    $("<th>", { "class": "textoReducido" }).text("CB"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Recep."),
                    $("<th>", { "class": "textoReducido text-center" }).text("Validado"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Rechazado"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Médico")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_DataTable_Det_Ate("` + Mx_Dtt[i].ID_ATENCION + `","` + i + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_NUM);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_NUM);
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                }
                                else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_NUM_INTERNO);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_NUM_INTERNO);
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                }
                                else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].PAC_RUT);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].PAC_RUT);
                            }
                        }),
                        $("<td>").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                }
                                else {
                                    $(this).text(Mx_Dtt[i].ATE_DNI);
                                }
                            } else {
                                $(this).text(Mx_Dtt[i].ATE_DNI);
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                }
                                else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].NAC_DESC);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].NAC_DESC);
                            }
                        }),
                        $("<td>").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO);
                                }
                            } else {
                                $(this).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO);
                            }
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    //Obtener valores
                                    var obj_date = new Date(Mx_Dtt[i].PAC_FNAC);
                                    var dd = parseInt(obj_date.getDate());
                                    var mm = parseInt(obj_date.getMonth()) + 1;
                                    var yy = parseInt(obj_date.getFullYear());
                                    if (dd < 10) { dd = "0" + dd; }
                                    if (mm < 10) { mm = "0" + mm; }
                                    return String(dd + "/" + mm + "/" + yy);
                                }
                            } else {
                                //Obtener valores
                                var obj_date = new Date(Mx_Dtt[i].PAC_FNAC);
                                var dd = parseInt(obj_date.getDate());
                                var mm = parseInt(obj_date.getMonth()) + 1;
                                var yy = parseInt(obj_date.getFullYear());
                                if (dd < 10) { dd = "0" + dd; }
                                if (mm < 10) { mm = "0" + mm; }
                                return String(dd + "/" + mm + "/" + yy);
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_AÑO + " Años");
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_AÑO + " Años");
                            }
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    //Obtener valores
                                    var obj_date = new Date(Mx_Dtt[i].ATE_FECHA);
                                    var dd = parseInt(obj_date.getDate());
                                    var mm = parseInt(obj_date.getMonth()) + 1;
                                    var yy = parseInt(obj_date.getFullYear());
                                    if (dd < 10) { dd = "0" + dd; }
                                    if (mm < 10) { mm = "0" + mm; }
                                    return String(dd + "/" + mm + "/" + yy);
                                }
                            } else {
                                //Obtener valores
                                var obj_date = new Date(Mx_Dtt[i].ATE_FECHA);
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
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    //Obtener valores
                                    var obj_date2 = new Date(Mx_Dtt[i].ATE_FECHA);
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
                                var obj_date2 = new Date(Mx_Dtt[i].ATE_FECHA);
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
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                }
                                else {
                                    $(this).text(Mx_Dtt[i].PROC_DESC);
                                }
                            } else {
                                $(this).text(Mx_Dtt[i].PROC_DESC);
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                }
                                else {
                                    if (Mx_Dtt[i].ID_SEXO == "2") {
                                        $(this).css("cssText", "background-color:#f5b0e5 !important; cursor:pointer; text-align:center;").text("Femenino");
                                    }
                                    else {
                                        $(this).css("cssText", " color:inherit; background-color:#88d6e2 !important; text-align:center;").text("Masculino");
                                    }
                                }
                            } else {
                                if (Mx_Dtt[i].ID_SEXO == "2") {
                                    $(this).css("cssText", "background-color:#f5b0e5 !important; cursor:pointer; text-align:center;").text("Femenino");
                                }
                                else {
                                    $(this).css("cssText", " color:inherit; background-color:#88d6e2 !important; text-align:center;").text("Masculino");
                                }
                            }
                        }),
                        $("<td>").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                }
                                else {
                                    $(this).text(Mx_Dtt[i].PROGRA_DESC);
                                }
                            } else {
                                $(this).text(Mx_Dtt[i].PROGRA_DESC);
                            }
                        }),
                        $("<td>").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                }
                                else {
                                    $(this).text(Mx_Dtt[i].SECTOR_DESC);
                                }
                            } else {
                                $(this).text(Mx_Dtt[i].SECTOR_DESC);
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CF_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].T_MUESTRA_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CB_DESC),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt[i].ATE_EST_RECEP == "9") {
                                $(this).css("cssText", "text-align:center; background-color:#9bffb1;").text("SI");
                            }
                            else {
                                $(this).css("cssText", "text-align:center;").text("NO");
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt[i].Expr1 == "VALIDADO") {
                                $(this).css("cssText", "background-color:#9bffb1 !important;  cursor:pointer; text-align:center;").text("SI");
                            }
                            else {
                                $(this).css("cssText", "color:inherit; text-align:center;").text("NO");
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt[i].ATE_EST_RECHAZO == "7") {
                                $(this).css("cssText", "text-align:center;").text("NO");
                            }
                            else {
                                $(this).css("cssText", "text-align:center; background-color:#9bffb1;").text("SI");
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                }
                                else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].DOC_NOMBRE + " " + Mx_Dtt[i].DOC_APELLIDO);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].DOC_NOMBRE + " " + Mx_Dtt[i].DOC_APELLIDO);
                            }
                        })
                    )
                );
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
        function Ajax_Redirect() {
            var loc = location.origin;
            window.location.href = "" + loc + "/Buscar_Ate/Atencion_Det.aspx?ID_ATE=" + ID_ATE_RED + "";
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

            #Btn_Buscar_x_ate {
                width: 90vw;
                margin-left: -12px;
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
                <div class="modal-header">
                    <div class="col">
                        <h6 class="modal-title" id="numerito"></h6>
                        <h6 class="modal-title" id="emodal_rut"></h6>
                        <h6 class="modal-title" id="nombrecito"></h6>
                    </div>
                    <div class="col">
                        <h6 class="modal-title" id="emodal_sexo"></h6>
                        <h6 class="modal-title" id="emodal_fecha"></h6>
                        <h6 class="modal-title" id="emodal_lugartm"></h6>
                    </div>
                </div>
                <div class="modal-body">

                    <div id="Div_Tabla_Listado_Exa_Ate" style="width: 100%;" class="table-responsive"></div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-info" id="btn_det"><i class="fa fa-fw fa-eye mr-2"></i>Detalles</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Salir</button>
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
                        <i class="fa fa-edit"></i>
                        Listado de Detalle de Resultados
                    </h5>
                </div>
                <div class="card-body">
                    <div class="row mb-3" style="margin-left: 2px; margin-right: 2px;">
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
                        <div class="col-md">
                            <label for="Ddl_LugarTM">Lugar de TM:</label>
                            <select id="Ddl_LugarTM" class="form-control">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-md">
                            <label for="Ddl_Seccion">Sección:</label>
                            <select id="Ddl_Seccion" class="form-control">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <%--    <div class="col-md">
            <label for="Ddl_LugarTM">Recepcionado:</label>
            <select id="Ddl_Recep" class="form-control">
                <option value="0">Todos</option>
                <option value="7">No</option>
                <option value="9">Si</option>
            </select>
        </div>
        <div class="col-md">
            <label for="Ddl_LugarTM">Validado:</label>
            <select id="Ddl_Validad" class="form-control">
                <option value="0">Todos</option>
                <option value="7">No</option>
                <option value="6">Si</option>
            </select>
        </div>
        <div class="col-md">
            <label for="Ddl_LugarTM">Rechazado:</label>
            <select id="Ddl_Rechaza" class="form-control">
                <option value="0">Todos</option>
                <option value="7">No</option>
                <option value="16">Si</option>
            </select>
        </div>--%>
                    </div>
                    <div class="row" style="margin-left: 2px; margin-right: 2px;">
                        <div class="col-md">
                            <button id="Btn_Buscar" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                        </div>
                        <div class="col-md">
                            <button id="Btn_Excel" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                        </div>
                    </div>
                </div>

                <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
            </div>
            <div class="row" id="Id_Conte">
                <div class="col-md-12" id="Paciente">
                    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list"></i>Listado de Resultados</h5>
                    <div class="row" style="font-size: 15px;">
                        <div class="col-md-2">
                            <label>N° Atenciones: </label>
                            <b>
                                <label id="txtNate" class="text-primary">0</label></b>
                        </div>
                        <div class="col-md-2">
                            <label>N° Exámenes: </label>
                            <b>
                                <label id="txtNExa" class="text-primary">0</label></b>
                        </div>
                    </div>
                    <div class="row" style="font-size: 15px;">
                        <div class="col-md-2">
                            <label>Recepción SI: </label>
                            <b>
                                <label id="txtRecepSi" class="text-primary">0</label></b>
                            <label>/ NO: </label>
                            <b>
                                <label id="txtRecepNo" class="text-danger">0</label></b>
                        </div>
                        <div class="col-md-2">
                            <label>Validado SI: </label>
                            <b>
                                <label id="txtValidadoSisisisisisoi" class="text-primary">0</label></b>
                            <label>/ NO: </label>
                            <b>
                                <label id="txtValidadoNo" class="text-danger">0</label></b>
                        </div>
                        <div class="col-md-2">
                            <label>Rechazado SI: </label>
                            <b>
                                <label id="txtRechaSi" class="text-primary">0</label></b>
                            <label>/ NO: </label>
                            <b>
                                <label id="txtRechaNo" class="text-danger">0</label></b>
                        </div>
                        <div class="col-md-4">
                            <label>Total: </label>
                            <b>
                                <label id="txtTotal" class="text-primary">0</label></b>
                        </div>
                    </div>
                    <div id="Div_Tabla" style="width: 100%; max-height: 55vh; overflow: auto"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
