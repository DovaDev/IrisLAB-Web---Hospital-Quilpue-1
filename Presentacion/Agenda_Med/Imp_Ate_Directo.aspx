<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Imp_Ate_Directo.aspx.vb" Inherits="Presentacion.Imp_Ate_Directo" %>
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
        function Ajax_imp_tm(qwerty){



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

        function Ajax_imp_ate (fffff) {
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
        function Ajax_imp_etiq (Eti) {
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
                "url": "Imp_Ate_Directo.aspx/Llenar_Ddl_LugarTM",
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
                "ID_ATENCION": 0,
                "ATE_FECHA": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO ": 0,
                "PAC_APELLIDO": 0,
                "ID_ESTADO": 0,
                "PAC_RUT": 0,
                "EST_DESCRIPCION": 0,
                "PROC_DESC ": 0,
                "ATE_NUM": 0,
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
                "url": "Imp_Ate_Directo.aspx/Llenar_PAC",
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



        var Mx_Detalle_ate = {
            "proparra1": [{
                "PAC_RUT": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "ATE_NUM": 0,
                "PAC_FNAC": 0,
                "ATE_AÑO": 0,
                "SEXO_DESC": 0,
                "ATE_FUR": 0,
                "NAC_DESC": 0,
                "PAC_FONO1 ": 0,
                "PAC_MOVIL1": 0,
                "CIU_DESC": 0,
                "PAC_DIR": 0,
                "PAC_EMAIL": 0,
                "PAC_OBS_PERMA": 0,
                "ATE_NUM_INTERNO": 0,
                "DNI":0

            }],
            "proparra2": [{
                "ID_PREINGRESO": 0,
                "ID_DET_PREI": 0,
                "ID_CODIGO_FONASA": 0,
                "CF_COD": 0,
                "CF_DESC": 0,
                "ID_ESTADO": 0,
                "PREI_DET_V_PREVI": 0,
                "PREI_DET_V_PAGADO": 0,
                "PREI_DET_V_COPAGO": 0,
                "PREI_DET_DOC": 0,
                "ID_TP_PAGO": 0,
                "TP_PAGO_DESC": 0,
                "CF_DIAS": 0,
                "ID_PER": 0
            }]
        }
        function Ajax_modal_exa(atencion_paciente) {
            //Debug
            var Data_Par_modal = JSON.stringify({
                "ID": atencion_paciente,
            });
            $.ajax({
                "type": "POST",
                "url": "Imp_Ate_Directo.aspx/MODAL_PAC",
                "data": Data_Par_modal,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": Data_Par_modal_paciente => {
                    //Debug
                    Mx_Detalle_ate = Data_Par_modal_paciente.d;
                    //ENVIAMOS ID_ATEMCION AL MODAL
                    //LLAMAMOS AL FILL MODAL
                    llenarmodal(atencion_paciente);

                    // MOSTRAR EL MODAL
                    $('#eModales33').modal('show');
                },
                "error": Data_Par_modal_paciente => {



                }
            });
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
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Voucher de Atención"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Etiquetas"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Voucher de TM"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Info")
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
                            "class": "textoReducido",
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
                                    return Mx_Dtt2[i].DNI
                                } else {
                                    return Mx_Dtt2[i].PAC_RUT
                                }

                            }),
                               $("<td>", {
                                   "align": "center",
                                   "class": "textoReducido"
                               }).text(Mx_Dtt2[i].ATE_NUM),                              
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
                                  "class": "textoReducido"
                              }).html(`<button type='button'` + habilitado + ` class='btn btn-info btn-xs' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer; width:40px;' onclick='Ajax_modal_exa("` + Mx_Dtt2[i].ID_ATENCION + `")'><i class="fa fa-fw fa-info" aria-hidden="true"></i></button>`)


                            //$("<td>", {
                            //    "align": "center",
                            //    "class": "textoReducido"
                            //}).html(`<i class="fa fa-info-circle" onclick='Ajax_modal_exa("` + Mx_Dtt2[i].ID_PREINGRESO + `","` + Mx_Dtt2[i].ID_ATENCION + `")'></i>`)
                        )
                    )

                }

            }
        function llenarmodal(ATENCION_PACIENTE_ID) {


            $("#Interno").css({
                "border-color": "#868e96",
                "background": "#fefefe"
            });
            global_id_atencion = ATENCION_PACIENTE_ID;
            //vaciar los datos
            $("#Div_Tabla3").empty();
            $("#rut").val("");
            $("#NOMBRE").val("");
            $("#ATENe").val("");
            $("#FNAC").val("");
            $("#Edad").val("");
            $("#Sex").val("");
            $("#FUR").val("");
            $("#Nacio").val("");
            $("#Telfijo").val("");
            $("#Celular").val("");
            $("#Ciudad").val("");
            $("#Comuna").val("");
            $("#Direc").val("");
            $("#Email").val("");
            $("#PerPAc").val("");
            $("#Obate").val("");
            $("#obtm").val("");
            $("#Prev").val("");

            //llenar datos
            if (Mx_Detalle_ate.proparra1[0].PAC_RUT == "") {

                $("#rut").val(Mx_Detalle_ate.proparra1[0].DNI);
            } else {
                $("#rut").val(Mx_Detalle_ate.proparra1[0].PAC_RUT);
            }
          
            $("#NOMBRE").val(Mx_Detalle_ate.proparra1[0].PAC_NOMBRE + " " + Mx_Detalle_ate.proparra1[0].PAC_APELLIDO);
            $("#ATENe").val(Mx_Detalle_ate.proparra1[0].ATE_NUM);
            $("#FNAC").val(Mx_Detalle_ate.proparra1[0].PAC_FNAC);
            $("#Edad").val(Mx_Detalle_ate.proparra1[0].ATE_AÑO + " Años");
            $("#Sex").val(Mx_Detalle_ate.proparra1[0].SEXO_DESC);
            $("#FUR").val(Mx_Detalle_ate.proparra1[0].ATE_FUR);
            $("#Nacio").val(Mx_Detalle_ate.proparra1[0].NAC_DESC);
            $("#Telfijo").val(Mx_Detalle_ate.proparra1[0].PAC_FONO1);
            $("#Celular").val(Mx_Detalle_ate.proparra1[0].PAC_MOVIL1);
            $("#Ciudad").val(Mx_Detalle_ate.proparra1[0].CIU_DESC);
            $("#Comuna").val(Mx_Detalle_ate.proparra1[0].COM_DESC);
            $("#Direc").val(Mx_Detalle_ate.proparra1[0].PAC_DIR);
            $("#Email").val(Mx_Detalle_ate.proparra1[0].PAC_EMAIL);
            $("#PerPAc").val(Mx_Detalle_ate.proparra1[0].PAC_OBS_PERMA);
            //$("#Prev").val(Mx_Detalle_ate.proparra3[0].PREVE_DESC);//
            $("#Interno").val(Mx_Detalle_ate.proparra1[0].ATE_NUM_INTERNO);//
           
            var cantidad = 0

            $("<table>", {
                "id": "DataTable_pac2",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla3");

            $("#DataTable_pac2").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_pac2").attr("class", "table table-hover table-striped table-iris table-striped table-iris");

            $("#DataTable_pac2 thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Codigo Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("Descripcion"),
                    $("<th>", { "class": "textoReducido" }).text("Dias Proceso")
                )
            );
     
            for (i = 0; i < Mx_Detalle_ate.proparra2.length; i++) {
                cantidad++;
                $("#DataTable_pac2 tbody").append(
                    $("<tr>", {
                        "class": "textoReducido manito",
                        "padding": "1px !important",
                    }).append(
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).text(Mx_Detalle_ate.proparra2[i].CF_COD),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido td_val1"
                        }).text(Mx_Detalle_ate.proparra2[i].CF_DESC),
                       $("<td>", {
                           "align": "center",
                           "class": "textoReducido td_val2"
                       }).text(Mx_Detalle_ate.proparra2[i].CF_DIAS)
                    )
                )
            }
            $("#cantidad").text("Cantidad de Exámenes: " + cantidad);

                $("#btn_reimprimir").hide();

                $("#btnobs").hide();

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">

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

  
    
    <%--Modal detalle paciente--%>
    <div class="modal fade" id="eModales33" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document" style="max-width: 90vw !important;">
            <div class="modal-content p-3">
                <div class="modal-body">
                    <div class="card border-bar mb-3">
                        <div class="card-header bg-bar text-center">
                            <h5 id="xxxxxx" class="m-0">Antecedentes de Atenciónes Directas</h5>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-sm">
                                            <label class="textoReducido2">RUT o D.N.I:</label>
                                            <input type='text' id="rut" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>

                                        <div class="col-sm">
                                            <label class="textoReducido2">Nombre:</label>
                                            <input type='text' id="NOMBRE" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>
                                        <div class="col-sm">
                                            <label class="textoReducido2">N°Atención:</label>
                                            <input type='text' id="ATENe" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>
                                        <div class="col-sm">
                                            <label class="textoReducido2">F.Nacimiento:</label>
                                            <input type='text' id="FNAC" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>

                                        <div class="col-sm">
                                            <label class="textoReducido2">Edad:</label>
                                            <input type='text' id="Edad" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm">
                                            <label class="textoReducido2">Sexo:</label>
                                            <input type='text' id="Sex" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>
                                        <div class="col-sm">
                                            <label for="checkBox2" class="textoReducido2">F.U.R:</label>
                                            <input type='text' id="FUR" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>
                                        <div class="col-sm">
                                            <label class="textoReducido2">Nacionalidad:</label>
                                            <input type='text' id="Nacio" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>
                                        <div class="col-sm">
                                            <label class="textoReducido2">Tel. Fijo:</label>
                                            <input type='text' id="Telfijo" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>
                                        <div class="col-sm">
                                            <label class="textoReducido2">Celular:</label>
                                            <input type='text' id="Celular" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>


                                    </div>
                                    <div class="row" style="margin-bottom: 10px;">
                                        <div class="col-sm">
                                            <label class="textoReducido2">Ciudad:</label>
                                            <input type='text' id="Ciudad" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>
                                        <div class="col-sm">
                                            <label class="textoReducido2">Comuna:</label>
                                            <input type='text' id="Comuna" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>
                                        <div class="col-sm">
                                            <label class="textoReducido2">Dirección:</label>
                                            <input type='text' id="Direc" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>
                                        <div class="col-sm">
                                            <label class="textoReducido2">Email:</label>
                                            <input type='text' id="Email" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>
                                        <div class="col-sm">
                                            <label class="textoReducido2">Observaciones Permanentes:</label>
                                            <input type='text' id="PerPAc" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row" style="margin-bottom: 10px;">
                                        <div class="col-sm">
                                            <label class="textoReducido2">N° Interno:</label>
                                            <input type='text' id="Interno" class="form-control textoReducido2 borderaaa" disabled="disabled"/>
                                        </div>
                                        <div class="col-sm">
                                     <%--       <label class="textoReducido2">Observaciones de la atencion:</label>
                                            <input type='text' id="Obate" class="form-control textoReducido2 borderaaa" />--%>
                                        </div>
                                        <div class="col-sm">
                                          <%--  <label class="textoReducido2">Observaciones de toma de muestra:</label>
                                            <input type='text' id="obtm" class="form-control textoReducido2 borderaaa" />--%>
                                        </div>
                                        <div class="col-sm">
                                  <%--          <label class="textoReducido2">Prevision:</label>
                                            <input type='text' id="Prev" class="form-control textoReducido2 borderaaa" disabled="disabled" />--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card border-bar">
                        <div class="card-header bg-bar text-center">
                            <h5 class="m-0">Listado de exámenes</h5>
                        </div>
                        <div class="card-body">
                            <div id="Div_Tabla3" style="width: 100%;" class="highlights3"></div>
                        </div>
                    </div>
                </div>

                <div class="modal-footer border-top-0">
                    <h5 id="cantidad"></h5>
                    <button type="button" class="btn btn-success" id="btnobs"><i class="fa fa-fw fa-check mr-2"></i> Atender</button>
                      <button type="button" class="btn btn-print" id="btn_reimprimir"><i class="fa fa-fw fa-print mr-2"></i> Imprimir</button>               
                    <div>

                    </div>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i> Cerrar</button>
                </div>
            </div>
        </div>
    </div>




    <!-- Breadcrumbs -->

    <div class="card border-bar">
        <div class="card-header bg-bar">
            <h5 style="text-align: center; padding: 5px;">
                <i class="fa fa-bookmark-o"></i>
                Listado de pacientes con atención directa
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
