<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Imp_Ate_P.aspx.vb" Inherits="Presentacion.Impresion_atendidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%--  --%>
    <script>
        $(document).ready(function () {
            //A un div externo, colocamos mensaje bonito para el cliente>
            $("#Div_Tabla").append(
                 ("<div class='alert alert-success alertas'><strong>Por favor seleccione una Fecha y Procedencia</strong>  </div>")
                );
            //-----iniciamos una varible para dar fecha actual al input------>         
            var f = moment().format("DD-MM-YYYY");
            $("#fecha").val(f);
            //-------llamamos al ajax para llenar el DdL de previsión--------->
            Call_AJAX_Ddl();
            //-------------Funcion al boton buscar --------------------->
            $("#Btnbuscar").click(function () {

                //-------------habilitamos el boton del excel--------------------------->
                if ($("#Ddl_LugarTM").val() == 222) {
                    $('#BtnAgenda').attr("disabled", true);
                } else {
                    $('#BtnAgenda').attr("disabled", false);
                }
                //------------llamamos al ajax para ver los pacientes--------------->
                Ajax_N_PACIENTE();

            });


        })

    </script>
    <script>


        function Ajax_imp_PRE(ytrewq) {



            var dataParam3 = JSON.stringify([
                ytrewq
            ]);

            ////console.log("Iniciando Petición AJAX...");
            ////console.log("VOUCHER LUGAR TM");

            var REE3 = $.ajax({
                "type": "POST",
                "url": "http://localhost:9990/Printer/Imp_Voucher_Agendam",
                "data": dataParam3,
                "contentType": "application/json;  charset=utf-8",
                "contentType": "text/plain;  charset=utf-8",
                "dataType": "json",
                "timeout": 20000,
                "success": function (response) {

                    ////console.log("[ OK ]");
                    ////console.log(response);
                    ////console.log("---•---");
                    var str_Error = "La impresión se ha completado exitosamente"
                    $("#title").text("Solicitud de voucher");
                    $("#button_modal").attr("class", "btn btn-success");
                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();

                },
                "error": function (response) {
                    ////console.log("[FAIL]");
                    ////console.log(response);
                    ////console.log("---•---");


                }
            });


        }
        function Ajax_imp_tm(qwerty) {



            var dataParam3 = JSON.stringify([
                qwerty
            ]);

            ////console.log("Iniciando Petición AJAX...");
            ////console.log("VOUCHER LUGAR TM");

            var REE3 = $.ajax({
                "type": "POST",
                "url": "http://localhost:9990/Printer/Imp_Voucher_Lugar_TM",
                "data": dataParam3,
                "contentType": "application/json;  charset=utf-8",
                "contentType": "text/plain;  charset=utf-8",
                "dataType": "json",
                "timeout": 20000,
                "success": function (response) {

                    ////console.log("[ OK ]");
                    ////console.log(response);
                    ////console.log("---•---");
                    var str_Error = "La impresión se ha completado exitosamente"
                    $("#title").text("Solicitud de voucher");
                    $("#button_modal").attr("class", "btn btn-success");
                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();

                },
                "error": function (response) {
                    ////console.log("[FAIL]");
                    ////console.log(response);
                    ////console.log("---•---");


                }
            });


        }

        function Ajax_imp_ate(fffff) {

            var dataParam3 = JSON.stringify([
                fffff
            ]);

            ////console.log("Iniciando Petición AJAX...");
            ////console.log("VOUCHER LUGAR TM");

            var REE3 = $.ajax({
                "type": "POST",
                "url": "http://localhost:9990/Printer/Imp_Voucher_Compr_Ate",
                "data": dataParam3,
                "contentType": "application/json;  charset=utf-8",
                "contentType": "text/plain;  charset=utf-8",
                "dataType": "json",
                "timeout": 20000,
                "success": function (response) {

                    ////console.log("[ OK ]");
                    ////console.log(response);
                    ////console.log("---•---");
                    var str_Error = "La impresión se ha completado exitosamente"
                    $("#title").text("Solicitud de voucher");
                    $("#button_modal").attr("class", "btn btn-success");
                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();

                },
                "error": function (response) {
                    ////console.log("[FAIL]");
                    ////console.log(response);
                    ////console.log("---•---");


                }
            });




        };
        function Ajax_imp_etiq(Eti) {
            var dataParam3 = JSON.stringify([Eti]);

            ////console.log("Iniciando Petición AJAX...");
            ////console.log("VOUCHER LUGAR TM");

            var REE3 = $.ajax({
                "type": "POST",
                "url": "http://localhost:9990/Printer/Imp_Etiquetas",
                "data": dataParam3,
                "contentType": "application/json;  charset=utf-8",
                "contentType": "text/plain;  charset=utf-8",
                "dataType": "json",
                "timeout": 20000,
                "success": function (response) {

                    ////console.log("[ OK ]");
                    ////console.log(response);
                    ////console.log("---•---");
                    var str_Error = "La impresión se ha completado exitosamente"
                    $("#title").text("Solicitud de Etiquetas");
                    $("#button_modal").attr("class", "btn btn-success");
                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();

                },
                "error": function (response) {
                    ////console.log("[FAIL]");
                    ////console.log(response);
                    ////console.log("---•---");


                }
            });

        };

        //---------------Declaración de JSON ajax call_ajax_ddl--------------------->

        var Mx_Ddl = [
            {
                "ID_PROCEDENCIA": "",
                "PROC_COD": "",
                "PROC_DESC": "",
                "ID_ESTADO": ""
            }
        ];

        // Ajax Ddl
        function Call_AJAX_Ddl() {
            //Debug
            ////console.log(">>>PETICIÓN AJAX<<<");
            //////////console.log("Iniciando petición de datos para DropDownList");

            var AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "Imp_Ate_P.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    ////console.log("[ OK ] Recepción de Datos DropDownList");
                    Mx_Ddl = JSON.parse(data.d);
                    Fill_Ddl();
                },
                "error": data => {
                    //Debug
                    ////console.log("[ERROR] Recepción de Datos DropDownList");
                    ////console.log(data);
                }
            });
        }
        //---------------Declaración de JSON ajax llenado de pacientes--------------------->
        var Mx_Dtt2 = [
            {
                "ID_PREINGRESO": 0,
                "PREI_NUM": 0,
                "PREI_FECHA": 0,
                "PAC_NOMBRE ": 0,
                "PAC_APELLIDO": 0,
                "ID_ESTADO": 0,
                "PAC_RUT": 0,
                "PREI_FEC_FLE": 0,
                "PREI_FECHA_PRE": 0,
                "ID_PACIENTE ": 0,
                "PREI_IID_ESTADO": 0,
                "EST_DESCRIPCION": 0,
                "ID_ATENCION": 0,
                "PROC_DESC": 0,
                "CANT_EXAM": 0,
                "DNI": 0
            }
        ];
        function Ajax_N_PACIENTE() {
            //Debug
            ////console.log(">>>PETICIÓN AJAX_Tabla Pacientes<<<");
            //////console.log("Iniciando petición de datos para Tabla PAcientes");
            modal_show();
            var Data_Par_tabla = JSON.stringify({
                "ID": $("#Ddl_LugarTM").val(),
                "fecha": $("#fecha").val()
            });
            var ajax_tabla = $.ajax({
                "type": "POST",
                "url": "Imp_Ate_P.aspx/Llenar_PAC",
                "data": Data_Par_tabla,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data_tabla_paciente => {
                    //Debug
                    ////console.log("[ OK ] Recepción de Datos de tabla paciente");
                    Mx_Dtt2 = data_tabla_paciente.d;
                    //--------Llamamos al fill_datatable para llenar datos en la tabla--------->
                    if (Mx_Dtt2.length != 0) {
                        Fill_DataTable2();
                        Hide_Modal();
                    } else {
                        Hide_Modal();
                        ////console.log('>>>0 RESULTADOS<<<');
                        $("#Div_Tabla").empty();
                        //-------mensaje bonito al usuario que no se encontro nada---------->
                        $("#Div_Tabla").append(
                        ("<div class='alert alert-danger alertas'><strong>Sin Resultados</strong>  </div>")
                        );
                        //------------Ocultamos el div qwerty------------->
                        $("#qwerty").hide();
                        //--------disabled true al boton excel---------->
                        $('#BtnAgenda').attr("disabled", true);
                    }
                },
                "error": data_tabla_paciente => {
                    Hide_Modal();
                    ////console.log('>>>0 RESULTADOS<<<');

                    //-------mensaje bonito al usuario que no se encontro nada---------->
                    $("#Div_Tabla").append(
                    ("<div class='alert alert-danger alertas'><strong>Sin Resultados</strong>  </div>")
                    );
                    //------------Ocultamos el div qwerty------------->
                    $("#qwerty").hide();
                    //--------disabled true al boton excel---------->
                    $('#BtnAgenda').attr("disabled", true);
                }
            });
        }
        //--------FILL DROPDOWNLIST LUGARTM---------->
        function Fill_Ddl() {
            $("#Ddl_LugarTM").empty();

            var procee = Galletas.getGalleta("USU_TM");
            if (procee == 0) {
                Mx_Ddl.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                });
            }
            else {
                Mx_Ddl.forEach(aaa => {
                    if (aaa.ID_PROCEDENCIA == procee) {
                        $("<option>",
                          {
                              "value": aaa.ID_PROCEDENCIA
                          }
                       ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                    }

                });
            }
        }



        //-----Fill llenar datatable---->
        function Fill_DataTable2() {
            $("#Div_Tabla").empty();
            $("<table>", {
                "id": "DataTable_pac",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla");

            $("#DataTable_pac").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_pac").attr("class", "table table-hover table-striped table-iris table-striped table-iris");

            $("#DataTable_pac thead").append(
                $("<tr>").append(

                    $("<th>", { "class": "textoReducido text-center" }).text("Nº"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Rut o D.N.I "),
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Pre-Ingreso"),
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Voucher de Pre-Ingreso"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Voucher de Atención"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Etiquetas"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Voucher de TM"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Estado")

                )
            );


            for (i = 0; i < Mx_Dtt2.length; i++) {
                var habilitado = (function () {
                    if (Mx_Dtt2[i].EST_DESCRIPCION == "ESPERA") {
                        return "disabled"
                    }
                    if (Mx_Dtt2[i].EST_DESCRIPCION == "ATENDIDO") {
                        return ""
                    }
                }());

                var habilitado2 = (function () {
                    if (Mx_Dtt2[i].EST_DESCRIPCION == "ESPERA") {
                        return ""
                    }
                    if (Mx_Dtt2[i].EST_DESCRIPCION == "ATENDIDO") {
                        return "disabled"
                    }
                }());

                $("#DataTable_pac tbody").append(
                    $("<tr>", {
                        //llamamos a la funcion para rellenar el modal con datos del paciente seleccionado
                        //"onclick": `Ajax_modal_exa("` + Mx_Dtt2[i].ID_PREINGRESO + `","` + Mx_Dtt2[i].ID_ATENCION + `")`,
                        "class": "textoReducido manito",
                        "padding": "1px !important",
                    }).append(
                        $("<td>", {
                            "align": "center",
                            "class": "textoReducido"
                        }).text(i + 1),
                        $("<td>", {
                            "align": "center",
                            "class": "textoReducido"
                        }).text(Mx_Dtt2[i].PAC_NOMBRE + " " + Mx_Dtt2[i].PAC_APELLIDO),
                        $("<td>", {
                            "align": "center",
                            "class": "textoReducido"
                        }).text(function () {
                            if (Mx_Dtt2[i].PAC_RUT == "") {
                                return Mx_Dtt2[i].DNI;
                            } else {
                                return Mx_Dtt2[i].PAC_RUT;
                            }
                        }),
                        $("<td>", {
                            "align": "center",
                            "class": "textoReducido"
                        }).text(Mx_Dtt2[i].PREI_NUM),
                           $("<td>", {
                               "align": "center",
                               "class": "textoReducido"
                           }).text(Mx_Dtt2[i].ATE_NUM),
                        $("<td>", {
                            "align": "center",
                            "class": "textoReducido"
                        }).html(`<button type='button' class='btn btn-print btn-xs' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer; width:40px;' onclick='Ajax_imp_PRE("` + Mx_Dtt2[i].ID_PREINGRESO + `")'><i class="fa fa-fw fa-print" aria-hidden="true"></i></button>`),


                        $("<td>", {
                            "align": "center",
                            "class": "textoReducido"
                        }).html(`<button type='button'` + habilitado + ` class='btn btn-print btn-xs' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer; width:40px;' onclick='Ajax_imp_ate("` + Mx_Dtt2[i].ID_ATENCION + `")'><i class="fa fa-fw fa-print" aria-hidden="true"></i></button>`),

                        $("<td>", {
                            "align": "center",
                            "class": "textoReducido"
                        }).html(`<button type='button'` + habilitado + ` class='btn btn-print btn-xs' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer; width:40px;' onclick='Ajax_imp_etiq("` + Mx_Dtt2[i].ID_ATENCION + `")'><i class="fa fa-fw fa-print" aria-hidden="true"></i></button>`),

                        $("<td>", {
                            "align": "center",
                            "class": "textoReducido"
                        }).html(`<button type='button'` + habilitado + ` class='btn btn-print btn-xs' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer; width:40px;' onclick='Ajax_imp_tm("` + Mx_Dtt2[i].ID_ATENCION + `")'><i class="fa fa-fw fa-print" aria-hidden="true"></i></button>`),


                        $("<td>", {
                            "align": "center",
                            "class": function () {

                                if (Mx_Dtt2[i].EST_DESCRIPCION == "ESPERA") {
                                    return "textoReducido espera"
                                }
                                if (Mx_Dtt2[i].EST_DESCRIPCION == "ATENDIDO") {
                                    return "textoReducido atendido"
                                }
                            }
                        }).text(Mx_Dtt2[i].EST_DESCRIPCION)

                        //$("<td>", {
                        //    "align": "center",
                        //    "class": "textoReducido"
                        //}).html(`<i class="fa fa-info-circle" onclick='Ajax_modal_exa("` + Mx_Dtt2[i].ID_PREINGRESO + `","` + Mx_Dtt2[i].ID_ATENCION + `")'></i>`)
                    )
                )

            }

        }


    </script>







    <style>
        .alertas {
            margin-top: 90px;
            text-align: center;
        }

        .manito {
            cursor: pointer;
        }

        .textoReducido {
            font-size: 10px;
        }

        .textoReducido2 {
            font-size: 14px;
        }

        .ancho-columna {
            height: 10%;
            padding: -35px;
        }

        .borderaaa {
            padding: .3rem;
            text-align: center;
        }

        .highlights {
            /*width: 710px;*/
            max-height: 70vh; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
        }

        .highlights2 {
            width: 710px;
            height: 434px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
        }

        .highlights3 {
            width: 100%;
            max-height: 170px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
        }

        .topbuttom {
            display: block;
            height: 80px;
            width: 100%;
        }

        .textbot {
            display: block;
            height: 22px;
            width: 100%;
        }

        .form-control:disabled {
            background-color: #ffffff !important;
            cursor: default !important;
        }

        .textbotLeft {
            display: block;
            height: 28px;
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">

    <!-- Modal -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog ml-xl-auto">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 id="title" class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">
                    <button type="button" id="button_modal" class="btn btn-danger" data-dismiss="modal">Aceptar</button>
                </div>
            </div>
        </div>
    </div>







    <!-- Breadcrumbs -->

    <div class="card border-bar">
        <div class="card-header bg-bar">
            <h5 style="text-align: center; padding: 5px;">
                <i class="fa fa-bookmark-o"></i>
                Listado de pacientes
            </h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-sm-12 col-md-5">

                            <div class='input-group date' id='datetimepicker1' style="margin-bottom: 1vh;">
                                <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Fecha" />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                            <style>
                                .glyphicon {
                                    display: inline-block;
                                    font-family: FontAwesome;
                                    font-style: normal;
                                    font-weight: normal;
                                    line-height: 1;
                                    -webkit-font-smoothing: antialiased;
                                    -moz-osx-font-smoothing: grayscale;
                                }

                                .glyphicon-arrow-left:before {
                                    content: "\f053";
                                }

                                .glyphicon-arrow-right:before {
                                    content: "\f054";
                                }
                            </style>
                            <script type="text/javascript">
                                ////////////////////////////////////
                                ////////////////////////////////////
                                $(function () {
                                    $('#datetimepicker1').datetimepicker(
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
                                            minView: 2,
                                            useCurrent: true

                                        })
                                });
                            </script>
                        </div>
                        <div class="col-sm-8 col-md-5 mb-2">
                            <select id="Ddl_LugarTM" class="form-control">
                            </select>
                        </div>
                        <div class="col-sm-4 col-md-2 mb-2">
                            <button id="Btnbuscar" type="button" class="btn btn-buscar btn-block mt-0">
                                <i class="fa fa-fw fa-search mr-2"></i>Buscar
                            </button>
                        </div>
                        <%--                        <div class="col-lg-1" style="margin-top: 3.5px;">
                            <button id="BtnAgenda" type="button" class="btn btn-success btn-sm">
                                <span class="fa fa-file-excel-o"></span>Excel
                            </button>
                        </div>--%>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div id="Div_Tabla" style="width: 100%;" class="highlights">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

