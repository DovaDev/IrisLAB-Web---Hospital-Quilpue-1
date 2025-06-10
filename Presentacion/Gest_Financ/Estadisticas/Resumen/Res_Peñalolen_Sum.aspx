<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Res_Peñalolen_Sum.aspx.vb" Inherits="Presentacion.Res_Peñalolen_Sum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true"%>
    
    <%-- Botones --%>
    <link href="../../../../Resourses/Style/Buttons.css" rel="stylesheet" />
    <%--Esto es para que funcione el gráfico--%>
    <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>
    <script src="/js/Custom_modal.js"></script>
    <script src="/js/Custom_Objects.js"></script>
    <%-- Declaración de Eventos --%>
    <script>
        var obj_AJAX = [];
        var obj_AJAX_Excel = 0;
        $(document).ready(function () {
            //Ajustes Visuales
            //$(".block_wait").css({ "display": "none" });
            $(".block_wait").hide();
            $("#Div_Total").empty().css({ "display": "none" }); 4
            $("#Div_Graph").empty().css({ "display": "none" });
            $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });
            $("#Div_Tabla_Data").append(
                $("<div>").css({
                    "width": "calc(100% - 60)",
                    "text-align": "center",
                    "padding": "30px",
                    "font-size": "30px",
                    "font-weight": 900
                }).text("Realice su Búsqueda.")
            );
            //Llamar al llenado de los DropDownList
            Ajax_Ddl_TM();
            //Registrar evento Click del Botón Buscar
            $("#Btn_Search").click(function () {
                function restaFechas(f1, f2) {
                    var aFecha1 = f1.split('/');
                    var aFecha2 = f2.split('/');
                    var fFecha1 = Date.UTC(aFecha1[2], aFecha1[1] - 1, aFecha1[0]);
                    var fFecha2 = Date.UTC(aFecha2[2], aFecha2[1] - 1, aFecha2[0]);
                    var dif = fFecha2 - fFecha1;
                    var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
                    return dias;
                }
                var Date_Diff = restaFechas(String($("#TxtDate_01").val()), String($("#TxtDate_02").val()));
                if (Date_Diff <= 31) {
                    Ajax_DataTable();
                } else {
                    cModal_Error("Atención", "Realice una búsqueda usando un rango menor o igual a 30 días.");
                }
            });
            $("#DdlPrevi").change(function () {
                Ajax_Ddl_Alt();
            });
            $("#Ddl_TM").change(function () {
                Ajax_Ddl_Prev();
            });
            $("#Ddl_Prev").change(function () {
                Ajax_Ddl_Prog();
            });
            $("#Ddl_Prog").change(function () {
                Ajax_Ddl_SubProg();
            });
            $("#Btn_All").click(function () {
                var Status = parseInt($("#Btn_All").attr("data-status"));
                switch (Status) {
                    case 0:
                        $("#Btn_All").attr("data-status", 1);
                        $("label[for='Btn_All']").attr("class", "btn btn_blue");
                        $("label[for='Btn_All'] span").text("Todos los Result.");
                        break;
                    default:
                        $("#Btn_All").attr("data-status", 0);
                        $("label[for='Btn_All']").attr("class", "btn btn_red");
                        $("label[for='Btn_All'] span").text("Solo 1er Result.");
                        break;
                }
            });
            $("#Btn_Export").click(function () {
                var HTML_content = "";
                var HTML_Funct = "";
                var CORRECT = false;
                var HTML_content = $("<div>", {
                    "style": "width: 100%;"
                }).append(
                    $("<p>").text("Ingrese un correo válido:"),
                    $("<input>", {
                        "type": "text",
                        "id": "Txt_Email"
                    }).css({
                        "width": "100%"
                    })
                );
                cModal_Notif_Custom("Exportar", HTML_content, "Generar Excel");
                $("#cModal_Btn_Aceptar").attr("class", "cBtn");
                $("#Txt_Email").keyup(function () {
                    var value_txt = $("#Txt_Email").val();
                    //Patron para el correo
                    var patron = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/;
                    if (value_txt.search(patron) == 0) {
                        //Mail correcto
                        $("#Txt_Email").css({
                            "color": "#000000",
                            "background": "#ffffff"
                        });
                        CORRECT = true;
                        $("#cModal_Btn_Aceptar").attr("class", "cBtn cAceptar");
                        return;
                    }
                    //Mail incorrecto
                    $("#cModal_Btn_Aceptar").attr("class", "cBtn");
                    $("#Txt_Email").css({
                        "color": "#ffffff",
                        "background": "#c30000"
                    });
                });
                $("#cModal_Btn_Aceptar").click(function () {
                    if (CORRECT == true) {
                        $("#cModal").fadeOut(500, function () {
                            Ajax_Excel();
                            setTimeout(Break_AJAX_EXCEL, 3000);
                            function Break_AJAX_EXCEL() {
                                obj_AJAX_Excel.abort();
                                $("#cModal").fadeOut(500, function () {
                                    $("#cModal .cModal_Text h1").empty();
                                    $("#cModal .cModal_Text p").empty();
                                    $("#cModal .cModal_Btn").empty();
                                });
                            }
                        });
                    }
                });
            });
        });
    </script>

    <%-- Peticiones AJAX --%>
    <script>
        //Json de llenado de DropDownList
        var Mx_Ddl_TM = [
            {
                "ID_PROCEDENCIA": 0,
                "PROC_COD": "asdf",
                "PROC_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];
        var Mx_Ddl_Prev = [
            {
                "ID_PREVE": 0,
                "PREVE_COD": "asdf",
                "PREVE_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];
        var Mx_Ddl_Prog = [
            {
                "ID_PROGRA": 0,
                "PROGRA_COD": "asdf",
                "PROGRA_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];
        var Mx_Ddl_SubProg = [
           {
               "ID_PROGRA": 0,
               "ID_SUBP": 0,
               "SUBP_DESC": "asdf",
               "ID_ESTADO": 0,
               "ID_PREVE": 0
           }
        ];
        function Ajax_Ddl_TM() {

            obj_AJAX.push($.ajax({
                "type": "POST",
                "url": "Res_Peñalolen_Sum.aspx/Llenar_Ddl_TM",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_TM = JSON.parse(json_receiver);
                        Fill_Ddl_TM();
                        $(".block_wait").hide();


                    } else {
                        $("#Div_Tabla_Total").empty().css({ "background": "#c30000" });
                        $("#Summary_Graph").empty().css({ "background": "#c30000" });
                        $("#Div_dinero").empty().css({ "background": "#c30000" });
                        $("#Div_Tabla").empty().css({ "background": "#c30000" });
                        $("#Div_Tabla").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",
                                "font-weight": 900,
                                "color": "#ffffff"
                            }).text("Sin Resultados.")
                        );


                    }
                    Ajax_Ddl_Prev()
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500, function () {
                        var str_Error = "";
                        //if (response == undefined) {
                        str_Error = response.responseJSON.ExceptionType + "\n \n";
                        str_Error = response.responseJSON.Message;
                        //} else {
                        //    str_Error = "Se ha cancelado la Petición";
                        //}
                        cModal_Error("Error", str_Error);
                    });

                }
            }));
        };
        function Ajax_Ddl_Prev() {


            var Data_Par = JSON.stringify({
                "ID_TM": parseInt($("#Ddl_TM").val())
            });
            obj_AJAX.push($.ajax({
                "type": "POST",
                "url": "Res_Peñalolen_Sum.aspx/Llenar_Ddl_Prev",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_Prev = JSON.parse(json_receiver);
                        Fill_Ddl_Prev();
                        $(".block_wait").hide();


                    } else {
                        $("#Div_Tabla_Total").empty().css({ "background": "#c30000" });
                        $("#Summary_Graph").empty().css({ "background": "#c30000" });
                        $("#Div_dinero").empty().css({ "background": "#c30000" });
                        $("#Div_Tabla").empty().css({ "background": "#c30000" });
                        $("#Div_Tabla").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",
                                "font-weight": 900,
                                "color": "#ffffff"
                            }).text("Sin Resultados.")
                        );


                    }
                    Ajax_Ddl_Prog();
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500, function () {
                        var str_Error = "";
                        //if (response == undefined) {
                        str_Error = response.responseJSON.ExceptionType + "\n \n";
                        str_Error = response.responseJSON.Message;
                        //} else {
                        //    str_Error = "Se ha cancelado la Petición";
                        //}
                        cModal_Error("Error", str_Error);
                    });

                }
            }));
        }
        function Ajax_Ddl_Prog() {


            var Data_Par = JSON.stringify({
                "ID_PREV": parseInt($("#Ddl_Prev").val())
            });
            obj_AJAX.push($.ajax({
                "type": "POST",
                "url": "Res_Peñalolen_Sum.aspx/Llenar_Ddl_Prog",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_Prog = JSON.parse(json_receiver);
                        Fill_Ddl_Prog(false);

                    } else {
                        Fill_Ddl_Prog(true);

                    }
                    Ajax_Ddl_SubProg();
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500, function () {
                        var str_Error = "";
                        if (response == undefined) {
                            str_Error = response.responseJSON.ExceptionType + "\n \n";
                            str_Error = response.responseJSON.Message;
                        } else {
                            str_Error = "Se ha cancelado la Petición";
                        }
                        cModal_Error("Error", str_Error);
                    });

                }
            }));
        }
        function Ajax_Ddl_SubProg() {


            var Data_Par = JSON.stringify({
                "DESDE": parseInt($("#Ddl_Prev").val()),
                "HASTA": parseInt($("#Ddl_Prev").val()),
                "ID_CF": parseInt($("#Ddl_Prev").val()),
                "ID_FP": parseInt($("#Ddl_Prev").val()),
                "ID_PREV": parseInt($("#Ddl_Prev").val()),
                "ID_PROG": parseInt($("#Ddl_Prog").val())
            });
            obj_AJAX.push($.ajax({
                "type": "POST",
                "url": "Res_Peñalolen_Sum.aspx/Llenar_Sub_Prog",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_SubProg = JSON.parse(json_receiver);
                        Fill_Ddl_SubProg(false);
                        $(".block_wait").hide();


                    } else {
                        Mx_Ddl_SubProg = JSON.parse(json_receiver);
                        Fill_Ddl_SubProg(true);
                        $(".block_wait").hide();


                    }
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500, function () {
                        var str_Error = "";
                        if (response == undefined) {
                            str_Error = response.responseJSON.ExceptionType + "\n \n";
                            str_Error = response.responseJSON.Message;
                        } else {
                            str_Error = "Se ha cancelado la Petición";
                        }
                        cModal_Error("Error", str_Error);
                    });

                }
            }));
        }
        var Mx_Dtt = [
           {
               "PAC_RUT": "",
               "PAC_NOMBRE": "",
               "PAC_APELLIDO": "",
               "CF_DESC": "",
               "PROC_DESC": "",
               "PREVE_DESC": "",
               "PROGRA_DESC": "",
               "SUBP_DESC": "",
               "ID_ATENCION": "",
               "ATE_NUM": "",
               "ATE_OMI": "",
               "ATE_FECHA": "",
               "TP_RESUL_COD": "",
               "ATE_RESULTADO": "",
               "ATE_RESULTADO_NUM": "",
               "ID_U_MEDIDA": "",
               "UM_DESC": "",
               "ID_PRUEBA": "",
               "ID_SEXO": "",
               "PAC_FNAC": ""
           }
        ];
        //Generar Excel
        function Ajax_Excel() {


            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "EMAIL": String($("#Txt_Email").val()),
                "ALL": function () {
                    var Status = parseInt($("#Btn_All").attr("data-status"));
                    switch (Status) {
                        case 0:
                            return false;
                        default:
                            return true;
                    }
                }(),
                "DESDE": String($("#TxtDate_01").val()),
                "HASTA": String($("#TxtDate_02").val()),
                "ID_CF": 0,
                "ID_TM": $("#Ddl_TM").val(),
                "ID_PREV": $("#Ddl_Prev").val(),
                "ID_PROG": $("#Ddl_Prog").val(),
                "ID_SUBPROG": $("#Ddl_SubProg").val()
            });
            $("#cModal").fadeOut(500, function () {
                $("#cModal .cModal_Text h1").empty();
                $("#cModal .cModal_Text p").empty();
                $("#cModal .cModal_Btn").empty();
            });
            $(".block_wait").fadeIn(500);
            obj_AJAX_Excel = $.ajax({
                "type": "POST",
                "url": "Res_Peñalolen_Sum.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    $(".block_wait").fadeOut(500);
                    if (json_receiver != "null") {
                        //var str_Download = "La Planilla Excel se ha generado correctamente, puede descargarla haciendo click ";
                        //str_Download += "<a href='" + json_receiver + "'>AQUÍ.</a>"
                        //cModal_Notif("Archivo Generado", str_Download);


                    } else {
                        var str_Error = "La petición de generación de planilla Excel no se ha realizado debido ";
                        str_Error += "a que los parámetros de búsqueda no arrojaron resultados."
                        cModal_Error("Error", str_Error);


                    }
                    obj_AJAX_Excel.abort();
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500, function () {
                        var str_Error = "";
                        var str_Msg = "";
                        if (response == undefined) {
                            str_Error = response.responseJSON.ExceptionType + "\n \n";
                            str_Error = response.responseJSON.Message;
                            cModal_Error("Error", str_Error);
                        } else {
                            str_Msg = "Se está generando el Archivo Excel. Cunado acabe, ";
                            str_Msg += "recibirá un correo con el enlace de descarga en su bandeja de entrada.";
                            cModal_Notif("Estado", str_Msg);
                        }
                    });

                }
            });
        }
    </script>
     <%-- Funciones de Llenado de Elementos --%>
    <script>
        //Llenar DropDownList
        function Fill_Ddl_TM() {
            $("#Ddl_TM").empty();
            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#Ddl_TM");
            for (y = 0; y < Mx_Ddl_TM.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl_TM[y].ID_PROCEDENCIA
                }).text(Mx_Ddl_TM[y].PROC_DESC).appendTo("#Ddl_TM");
            }
        };
        function Fill_Ddl_Prev() {
            $("#Ddl_Prev").empty();
            //$("<option>", {
            //    "value": 0
            //}).text("Todos").appendTo("#Ddl_Prev");
            for (y = 0; y < Mx_Ddl_Prev.length; ++y) {
                var ID_aaa = Mx_Ddl_Prev[y].ID_PREVE;
                var De_aaa = Mx_Ddl_Prev[y].PREVE_DESC;
                $("<option>", {
                    "value": ID_aaa
                }).text(De_aaa).appendTo("#Ddl_Prev");
            }
        };
        function Fill_Ddl_Prog(isnull) {
            $("#Ddl_Prog").empty();
            $("<option>", {
                "value": 0
            }).text("Todas").appendTo("#Ddl_Prog");
            if (isnull == false) {
                for (y = 0; y < Mx_Ddl_Prog.length; ++y) {
                    $("<option>", {
                        "value": Mx_Ddl_Prog[y].ID_PROGRA
                    }).text(Mx_Ddl_Prog[y].PROGRA_DESC).appendTo("#Ddl_Prog");
                }
            }
        };
        function Fill_Ddl_SubProg(isnull) {
            $("#Ddl_SubProg").empty();
            $("<option>", {
                "value": 0
            }).text("Todas").appendTo("#Ddl_SubProg");
            if (isnull == false) {
                for (y = 0; y < Mx_Ddl_SubProg.length; ++y) {
                    $("<option>", {
                        "value": Mx_Ddl_SubProg[y].ID_SUBP
                    }).text(Mx_Ddl_SubProg[y].SUBP_DESC).appendTo("#Ddl_SubProg");
                }
            }
        };
        //Llenar DataTable
        function Fill_DataTable() {
            $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });
            $("<table>", {
                "id": "DataTable",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Data");
            $("#DataTable").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>").text("N° Atención"),
                    $("<th>").text("Nombre Paciente"),
                    $("<th>").text("Determinación"),
                    $("<th>").text("T"),
                    $("<th>").text("Resultado"),
                    $("<th>").text("Unidad"),
                    $("<th>").text("E"),
                    $("<th>").text("Rango Desde"),
                    $("<th>").text("Rango Hasta"),
                    $("<th>").text("Previsión"),
                    $("<th>").text("Lugar de TM"),
                    $("<th>").text("Programa"),
                    $("<th>").text("RUT"),
                    $("<th>").text("Fecha Atención"),
                    $("<th>").text("Sub Programa"),
                    $("<th>").text("OC")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {


                var Rresultado = "";
                var resultado = "";
                Rresultado = Mx_Dtt[i].TP_RESUL_COD
                if (Rresultado == "A") {
                    resultado = Mx_Dtt[i].ATE_RESULTADO
                } else {
                    resultado = Mx_Dtt[i].ATE_RESULTADO_NUM
                }
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].ATE_NUM),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].CF_DESC),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].TP_RESUL_COD),
                        $("<td>", { "align": "center" }).text(function () {
                            if (Mx_Dtt[i].TP_RESUL_COD.toUpperCase() == "A") {
                                return Mx_Dtt[i].ATE_RESULTADO;
                            } else {
                                return Mx_Dtt[i].ATE_RESULTADO_NUM;
                            }
                        }),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].UM_DESC),
                        $("<td>", { "align": "center" }).text(""),
                        $("<td>", { "align": "center" }).text(""),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].PREVE_DESC),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].PROC_DESC),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].PAC_RUT),
                        $("<td>", { "align": "center" }).text(function () {
                            //Procesar datos de entrada
                            var date_x = $.extend({}, Mx_Dtt[i]).ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");
                            //Obtener valores
                            var obj_date = new Date(parseInt(date_x));
                            var dd = parseInt(obj_date.getDate());
                            var MM = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());
                            if (dd < 10) { dd = "0" + dd; }
                            if (MM < 10) { MM = "0" + MM; }
                            //var hh = parseInt(obj_date.getHours());
                            //var mm = parseInt(obj_date.getMinutes());
                            //if (hh < 10) { dd = "0" + dd; }
                            //if (mm < 10) { MM = "0" + MM; }
                            return String(dd + "/" + MM + "/" + yy);
                            //return String(dd + "/" + mm + "/" + yy + " " + hh + ":" + mm);
                        }),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].SUBP_DESC),
                        $("<td>", { "align": "center" }).text(""),
                        $("<td>", { "align": "center" }).text(""),
                        $("<td>", { "align": "center" }).text("")
                ));

            }
            $("#DataTable").DataTable({  "bSort": false,
                "iDisplayLength": 100,
                "language": {
                    "DisplayLength": 100,
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay concidencias",
                    "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
        }
    </script>
     <%-- Datepickers --%>
    <script>
        $(document).ready(function () {
            var Date_Now = function () {
                //Obtener valores
                var obj_date = new Date();
                var dd = parseInt(obj_date.getDate());
                var mm = parseInt(obj_date.getMonth()) + 1;
                var yy = parseInt(obj_date.getFullYear());
                if (dd < 10) { dd = "0" + dd; }
                if (mm < 10) { mm = "0" + mm; }
                return String(dd + "/" + mm + "/" + yy);
            };
            $("#TxtDate_01").attr({
                "data-provide": "datepicker",
                "value": Date_Now
            });
            $("#TxtDate_02").attr({
                "data-provide": "datepicker",
                "value": Date_Now
            });
            $("#TxtDate_01").datepicker({
                keyboardNavigation: false,
                autoclose: true,
                todayHighlight: true,
                format: "dd/mm/yyyy",
                disableTouchKeyboard: true,
                language: "es"
            });
            $("#TxtDate_02").datepicker({
                keyboardNavigation: false,
                autoclose: true,
                todayHighlight: true,
                format: "dd/mm/yyyy",
                disableTouchKeyboard: true,
                language: "es"
            });
            //$("#TxtDate_01").val(Date_Now);
            //$("#TxtDate_02").val(Date_Now);
        });
    </script>
 
     <%-- CSS Personalizado --%>
    <style>
        .div_main p {margin: 0;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="block_wait">
        <p>Progreso</p>
        <div>
            <div class="event_rotation">
	            <div class="other">
    	            <div></div>
                </div>
	            <div class="blank">
                </div>
            </div>
        </div>
    </div>
    <div class="flex_col">
        <div class="div_main table_gen">
            <p>Listado de Resultados SJ</p>
            <div>
                <table>
                    <tr>
                        <td width="90px" style="min-width: 100px;">
                            <div class="div_main table_gen" style="padding: 2.5px;">
                                <p>Desde:</p>
                                <div>
                                    <table>
                                        <tr>
                                            <td class="td_c" align="center">
                                                <input type="text" id="TxtDate_01" style="width: calc(100% - 10px);"> </input>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                        <td width="90px" style="min-width: 100px;">
                            <div class="div_main table_gen" style="padding: 2.5px;">
                                <p>Hasta:</p>
                                <div style="margin: 0;">
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <input type="text" id="TxtDate_02" style="width: calc(100% - 10px);"> </input>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                        <td style="width: calc(40% - 190px); min-width: 170px;">
                            <div class="div_main table_gen" style="padding: 2.5px;">
                                <p>Lugar de TM.:</p>
                                <div>
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <select id="Ddl_TM" style="width: calc(100% - 10px);">
                                                </select>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                        <td style="width: calc(40% - 190px); min-width: 170px;">
                            <div class="div_main table_gen" style="padding: 2.5px;">
                                <p>Previsión:</p>
                                <div>
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <select id="Ddl_Prev" style="width: calc(100% - 10px);">
                                                </select>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                        <td style="width: calc(40% - 190px); min-width: 170px;">
                            <div class="div_main table_gen" style="padding: 2.5px;">
                                <p>Programa:</p>
                                <div>
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <select id="Ddl_Prog" style="width: calc(100% - 10px);">
                                                </select>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                        <td style="width: calc(40% - 190px); min-width: 170px;">
                            <div class="div_main table_gen" style="padding: 2.5px;">
                                <p>Sub-Programa:</p>
                                <div>
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <select id="Ddl_SubProg" style="width: calc(100% - 10px);">
                                                </select>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                        <%--<td width="10%" align="center">
                            <input type="button" id="Btn_Search" style="display: none;"/>
                            <label id="Lbl_Search" for="Btn_Search" class="btn btn_blue">
                                <img src="../../../../Resourses/Img/Btn_Elements/Lupa.png" />
                                <span>Buscar</span>
                            </label>
                        </td>--%>
                        <td width="10%" align="center">
                            <input type="button" id="Btn_All" style="display: none;" data-status="1"/>
                            <label for="Btn_All" class="btn btn_blue">
                                <span>Todos los Result.</span>
                            </label>
                        </td>
                        <td width="10%" align="center">
                            <input type="button" id="Btn_Export" style="display: none;" />
                            <label for="Btn_Export" class="btn btn_green">
                                <img src="../../../../Resourses/Img/Btn_Elements/Excel.png" />
                                <span>Exportar</span>
                            </label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="Div_Table" class="div_main table_data" runat="server">
            <p>Listado de Atenciones</p>
            <div>
                <div id="Div_Tabla_Data">
                </div>
            </div>
        </div>  
    </div>
</asp:Content>