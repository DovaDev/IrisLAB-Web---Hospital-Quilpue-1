<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Lis_Deriv_Exa.aspx.vb" Inherits="Presentacion.Lis_Deriv_Exa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>
        $(document).ready(function () {
            Ajax_LugarTM();
            Ajax_Examen();
            $("#Id_Conte").hide();

            $("#Btn_Buscar").click(function () {
                if ($("#DdlExamen").val() == 0) {
                    $("#mError_AAH h4").text("Seleccione:");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione un Examen.");
                    $("#mError_AAH").modal();
                } else {
                    $("#Div_Tabla").empty();
                    Call_Data_Table();
                }
            });

            $("#Btn_Excel").click(function () {
                if ($("#DdlExamen").val() == 0) {
                    $("#mError_AAH h4").text("Seleccione:");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione una Sección.");
                    $("#mError_AAH").modal();
                } else {
                    //console.log("excel");
                    Call_Export();
                }
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

            $("#Div_Tabla").empty();

        });
        var Mx_LugarTM = [{
            "ID_PROCEDENCIA": 0,
            "PROC_COD": 0,
            "PROC_DESC": 0,
            "ID_ESTADO": 0
        }];

        function Ajax_LugarTM() {
           //modal_show();

            $.ajax({
                "type": "POST",
                "url": "Lis_Deriv_Exa.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_LugarTM = json_receiver;
                        Fill_Ddl_LugarTM();
                        //console.log(Mx_Dtt_Prevision);
                    } else {

                        //Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda solicitada.");
                        $("#mError_AAH").modal();
                    }

                },
                "error": function (response) {
                    var str_Error = response.ExceptionType + "\n \n";
                    str_Error = response.Message;
                    alert(str_Error);



                }
            });
        }

        //------------------------------------------------ AJAX DDL Examen -------------------------------------------|
        var Mx_Dtt_Examen = [{
            "ID_CODIGO_FONASA": 0,
            "CF_DESC": 0,
            "ID_ESTADO": 0
        }];

        function Ajax_Examen() {

            $.ajax({
                "type": "POST",
                "url": "Lis_Deriv_Exa.aspx/Llenar_Ddl_Examen",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Examen = json_receiver;
                        Fill_Ddl_Examen();
                        //Hide_Modal();
                        //console.log(Mx_LugarTM);
                    } else {

                        //Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda solicitada");
                        $("#mError_AAH").modal();
                    }
                },
                "error": function (response) {

                }
            });
        }
        function Fill_Ddl_LugarTM() {
            $("#Ddl_LugarTM").empty();
            //console.log(Mx_LugarTM);
            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_LugarTM");
            for (y = 0; y < Mx_LugarTM.length; ++y) {
                $("<option>", {
                    "value": Mx_LugarTM[y].ID_PROCEDENCIA
                }).text(Mx_LugarTM[y].PROC_DESC).appendTo("#Ddl_LugarTM");
            }

        };

        //Llenar DropDownList Prevision
        function Fill_Ddl_Examen() {
            $("#DdlExamen").empty();
            //console.log(Mx_Dtt_Examen);
            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#DdlExamen");
            for (y = 0; y < Mx_Dtt_Examen.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_Examen[y].ID_CODIGO_FONASA
                }).text(Mx_Dtt_Examen[y].CF_DESC).appendTo("#DdlExamen");
            }
        };
        var JSON_Data_Table = [{
            "ID_ATENCION": "",
            "ATE_NUM": "",
            "ATE_FECHA": "",
            "ID_PACIENTE": "",
            "PAC_FNAC": "",
            "PAC_NOMBRE": "",
            "PAC_APELLIDO": "",
            "ATE_AÑO": "",
            "DOC_NOMBRE": "",
            "PAC_RUT": "",
            "DOC_APELLIDO": "",
            "SEXO_DESC": "",
            "ID_SEXO": "",
            "ID_PROCEDENCIA": "",
            "ATE_NUM_INTERNO": "",
            "PAC_DNI": "",
            "ID_ESTADO": "",
            "PROC_DESC": "",
            "CF_COD": "",
            "CF_DESC": "",
            "ID_CODIGO_FONASA": "",
            "NAC_DESC": "",
            "PROGRA_DESC": "",
            "SECTOR_DESC": ""
        }];
        function Call_Data_Table() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DATE_str01": String($("#fecha").val()),
                "DATE_str02": String($("#fecha2").val()),
                "ID_CF": String($("#DdlExamen").val()),
                "ID_PROC": String($("#Ddl_LugarTM").val()),

            });
            //console.log(Data_Par);
            $(".block_wait").fadeIn(500);
            AJAX_Data_Table = $.ajax({
                "type": "POST",
                "url": "Lis_Deriv_Exa.aspx/Call_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    if (response.d != null) {
                        JSON_Data_Table = response.d;
                        console.log(response);
                        $("#Id_Conte").show();

                        Fill_DataTable();
                        Hide_Modal();
                    } else {
                        Hide_Modal();
                        $("#Id_Conte").hide();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda solicitada.");
                        $("#mError_AAH").modal();
                    }

                },
                "error": function (response) {
                    //console.log(response);
                    Hide_Modal();
                }
            });
        }
        function Fill_DataTable() {

            //console.log(JSON_Data_Table);
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
                    $("<th>", { "class": "textoReducido  text-center" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido  text-center" }).text("Rut o DNI"),
                    //$("<th>", { "class": "textoReducido text-center" }).text("DNI"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Nacionalidad"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Nac"),
                    $("<th>", { "class": "textoReducido  text-center" }).text("Edad"),
                    $("<th>", { "class": "textoReducido  text-center" }).text("Fecha Ate."),
                    $("<th>", { "class": "textoReducido" }).text("Lugar de TM"),
                    $("<th>", { "class": "textoReducido" }).text("Sexo"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Num Interno"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Programa"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Sector"),
                    $("<th>", { "class": "textoReducido" }).text("Médico")
                )
            );
            var procee = Galletas.getGalleta("USU_TM");
            var admin = Galletas.getGalleta("P_ADMIN");



                for (i = 0; i < JSON_Data_Table.length; i++) {

                    $("#DataTable tbody").append(
                        $("<tr>", {
                            "onclick": `Ajax_Redirect("` + JSON_Data_Table[i].ENCRYPTED_ID + `")`,
                            "class": "manito"
                        }).attr("value", JSON_Data_Table[i].ENCRYPTED_ID).append(
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].ATE_NUM),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                                if (JSON_Data_Table[i].PAC_RUT == "") {
                                    return JSON_Data_Table[i].ATE_DNI;
                                } else {
                                    return JSON_Data_Table[i].PAC_RUT;
                                }
                            }),
                            //$("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].ATE_DNI),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].NAC_DESC),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].PAC_NOMBRE + " " + JSON_Data_Table[i].PAC_APELLIDO),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                                //Procesar datos de entrada
                                var date_xd = $.extend({}, JSON_Data_Table[i]).PAC_FNAC;
                                date_xd = String(date_xd).replace("/Date(", "");
                                date_xd = date_xd.replace(")/", "");

                                //Obtener valores
                                var obj_date = new Date(parseInt(date_xd));
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
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                                var date_x = $.extend({}, JSON_Data_Table[i]).PAC_FNAC;
                                date_x = String(date_x).replace("/Date(", "");
                                date_x = date_x.replace(")/", "");

                                var total = ""
                                //Obtener valores
                                var obj_date = new Date(parseInt(date_x));
                                var dia = parseInt(obj_date.getDate());
                                var mes = parseInt(obj_date.getMonth()) + 1;
                                var ano = parseInt(obj_date.getFullYear());

                                if (dia < 10) { dia = "0" + dia; }
                                if (mes < 10) { mes = "0" + mes; }

                                // cogemos los valores actuales
                                var fecha_hoy = new Date();
                                var ahora_ano = fecha_hoy.getYear();
                                var ahora_mes = fecha_hoy.getMonth() + 1;
                                var ahora_dia = fecha_hoy.getDate();

                                // realizamos el calculo
                                var edad = (ahora_ano + 1900) - ano;
                                if (ahora_mes < mes) {
                                    edad--;
                                }
                                if ((mes == ahora_mes) && (ahora_dia < dia)) {
                                    edad--;
                                }
                                if (edad > 1900) {
                                    edad -= 1900;
                                }

                                // calculamos los meses
                                var meses = 0;
                                if (ahora_mes > mes) {
                                    meses = ahora_mes - mes;
                                }
                                if (ahora_mes < mes) {
                                    meses = 12 - (mes - ahora_mes);
                                }
                                if (ahora_mes == mes && dia > ahora_dia) {
                                    meses = 11;
                                }

                                // calculamos los dias
                                
                                total = String(edad + " Años " + meses + " Meses " );
                                //if (ahora_dia > dia) {
                                //    dias = ahora_dia - dia;
                                //    total = String(edad + " Años " + meses + " Meses " + dias + " Dias");
                                //}
                                //if (ahora_dia < dia) {
                                //    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                                //    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                                //    total = String(edad + " Años " + meses + " Meses " + dias + " Dias");
                                //}
                                return total;
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                                //Procesar datos de entrada
                                var date_x = $.extend({}, JSON_Data_Table[i]).ATE_FECHA;
                                date_x = String(date_x).replace("/Date(", "");
                                date_x = date_x.replace(")/", "");

                                //Obtener valores
                                var obj_date = new Date(parseInt(date_x));
                                var dd = parseInt(obj_date.getDate());
                                var MM = parseInt(obj_date.getMonth()) + 1;
                                var yy = parseInt(obj_date.getFullYear());

                                if (dd < 10) { dd = "0" + dd; }
                                if (MM < 10) { MM = "0" + MM; }

                                return String(dd + "/" + MM + "/" + yy);
                                //return String(dd + "/" + mm + "/" + yy + " " + hh + ":" + mm);
                            }),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].PROC_DESC),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].SEXO_DESC),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].ATE_NUM_INTERNO),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].PROGRA_DESC),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].SECTOR_DESC),

                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].DOC_NOMBRE + " " + JSON_Data_Table[i].DOC_APELLIDO)
                        )
                    );

                }
           
        }

        function Call_Export() {
            modal_show();
            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DATE_str01": String($("#fecha").val()),
                "DATE_str02": String($("#fecha2").val()),
                "ID_PROC": String($("#Ddl_LugarTM").val()),
                "ID_CF": String($("#DdlExamen").val())
            });
            //console.log(Data_Par);
            $.ajax({
                "type": "POST",
                "url": "Lis_Deriv_Exa.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    console.log("success");
                    var json_receiver = response.d;

                    if (json_receiver != null) {
                        Hide_Modal();
                        window.open(json_receiver, 'Download');

                    } else {
                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda solicitada.");
                        $("#mError_AAH").modal();
                    }
                },
                "error": function (response) {
                    console.log("error");
                    console.log(response);
                    Hide_Modal();
                }
            });
        }

        function Ajax_Redirect(id) {
            var loc = location.origin;
            window.open(loc + "/Buscar_Ate/Atencion_Det.aspx?ID_ATE=" + id);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <!-- Modal -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
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

    <div class="card mb-3 border-bar">
        <div class="card-header bg-bar p-1">
            <h5 style="text-align: center; padding: 5px;">
                <i class="fa fa-fw fa-edit"></i>
                Listado de Derivados por Examen
            </h5>
        </div>
        <div class="card-body">
            <div class="row" style="margin-left: 2px; margin-right: 2px;">
                <div class="col-md mb-1">
                    <label for="fecha">Desde:</label>
                    <div class='input-group date' id='Txt_Date01'>
                        <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Desde..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-md mb-1">
                    <label for="fecha">Hasta:</label>
                    <div class='input-group date' id='Txt_Date02'>
                        <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Desde..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-md mb-1">
                    <label for="Ddl_LugarTM">Lugar TM:</label>
                    <select id="Ddl_LugarTM" class="form-control">
                    </select>
                </div>
                <div class="col-md mb-1">
                    <label for="DdlExamen">Exámenes:</label>
                    <select id="DdlExamen" class="form-control">
                    </select>
                </div>
                <div class="col-md-2 mb-1">
                    <br class="mb-1" />
                    <button id="Btn_Buscar" class="btn btn-buscar btn-block mt-1 mb-1" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                </div>
                <div class="col-md-2 mb-1">
                    <br class="mb-1" />
                    <button id="Btn_Excel" class="btn btn-success btn-block mt-1 mb-1" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                </div>
            </div>
            <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
            <div class="row mt-3" id="Id_Conte" style="margin-left: 1px; width: 100%;">
                <div class="col-lg-12 text-center">
                    <h5><i class="fa fa-fw fa-list"></i>Resultados de la Búsqueda</h5>
                    <div class="row text-center" id="Paciente">
                        <div id="Div_Tabla" style="width: 100%; overflow: auto" class="highlights"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
