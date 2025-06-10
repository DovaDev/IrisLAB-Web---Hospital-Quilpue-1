<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="AVIS_C_D.aspx.vb" Inherits="Presentacion.AVIS_C_D" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <!-- Inicialización -->
    <script>
        let Gall_T_USU = Galletas.getGalleta("P_ADMIN");
        $(document).ready(function () {
            
            //A un div externo, colocamos mensaje bonito para el cliente>
            $("#Div_Tabla").append(
                 ("<div class='alert alert-success alertas'><strong>Por favor Ingresar Avis o Rut del paciente avis</strong>  </div>")
                );


          
            $("#AVIS").click(function () {
                $("#RUT").val("");
            });
            $("#RUT").click(function () {
                $("#AVIS").val("");
            });
            //-----------------iniciamos el boton de excel  disabled------------------------->
            $('#BtnAgenda').attr("disabled", false);

            //-------------Funcion al boton buscar --------------------->
            $("#Btnbuscar").click(function () {
                $("#Paciente").text("");

                $("#Examen").text("");
                //------------llamamos al ajax para ver los pacientes--------------->
                Ajax_N_PACIENTE();
            });
        });
    </script>
    <script>



        //---------------Declaración de JSON ajax llenado de pacientes--------------------->
        var Mx_Dtt2 = [
            {      
                "HO_ID": 0,
                "HO_CP": 0,
                "HO_CC": 0,
                "HO_FechaAtencion": 0,
                "HO_RutPaciente": 0,
                "HO_DvPaciente": 0,
                "HO_Nombres": 0,
                "HO_ApellidoPaterno": 0,
                "HO_ApellidoMaterno": 0,
                "HO_Sexo": 0,
                "HO_FechaNacimiento": 0,
                "HO_TelefonoPaciente ": 0,
                "HO_EmailPaciente ": 0,
                "HO_RutMedico ": 0,
                "HO_DvMedico ": 0,
                "HO_RutPaciente": 0,
                "HO_DvPaciente": 0,
                "HO_NombreMedico ": 0,
                "HO_TipoAtencion ": 0,
                "HO_ServicioCodigo ": 0,
                "HO_ServicioDescripcion ": 0,
                "HO_ProcedenciaCodigo ": 0,
                "HO_ProcedenciaDescripcion ": 0,
                "HO_ExamenCodigo ": 0,
                "HO_ExamenDescripcion ": 0,
                "HO_FechaRegistro ": 0,
                "HO_EstadoProceso ": 0,
                "HO_EstadoFecha ": 0,
                "HO_Iris_EstadoCarga ": 0,
                "HO_Iris_FechaCarga ": 0,
                "HO_Iris_Ruta ": 0,
                "HO_Iris_PDF ": 0,
                "HO_Iris_Recepcion ": 0,
                "HO_Iris_FechaRecep ": 0,
                "HO_IdExamenIris ": 0,
                "HO_Fecha_D ": 0,
                "NumCorrelativoCero ": 0,
                "IdSolicitudCorrelativo ": 0,
                "IRIS_H_FECHA ": 0,
                "IRIS_H_ESTADO ": 0,
                "IRIS_H_ID_PREINGRESO ": "",
                "HO_COD_DIAG": 0,
                "HO_COD_PREVE ": 0,
                "HO_COD_PROGRA ": 0,
                "ID_DIAGNOSTICO ": 0,
                "ID_PROGRA ": 0,
                "ID_PREVE ": 0,
                "IRIS_H_ID_ATENCION": ""
            }
        ];

        ///////////////////////
        ///////////////////////

        function Ajax_N_PACIENTE() {
            //Debug


            modal_show();
            var Data_Par_tabla = JSON.stringify({
                "AVIS": $("#AVIS").val(),
                "RUT": $("#RUT").val()
            });
            var ajax_tabla = $.ajax({
                "type": "POST",
                "url": "AVIS_C_D.aspx/Llenar_AVIS",
                "data": Data_Par_tabla,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    //Debug

                    //Mx_Dtt2 = data_tabla_paciente.d;
                    //--------Llamamos al fill_datatable para llenar datos en la tabla--------->
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt2 = JSON.parse(json_receiver);

                        Fill_DataTable2();
                        Hide_Modal();
                    } else {
                        Hide_Modal();

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



    </script>


    <script>
        function Ajax_Exa_no_dis(id_01) {
          
            var Data_Par_tabla = JSON.stringify({
                "AVIS":id_01
    
            });
            var ajax_tabla = $.ajax({
                "type": "POST",
                "url": "AVIS_C_D.aspx/Ajax_Exa_dis",
                "data": Data_Par_tabla,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    //Debug

                    //Mx_Dtt2 = data_tabla_paciente.d;
                    //--------Llamamos al fill_datatable para llenar datos en la tabla--------->
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Ajax_N_PACIENTE();
                    } else {
                        Ajax_N_PACIENTE();
                    }
                },
                "error": data_tabla_paciente => {
                    Hide_Modal();


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
        
        function Ajax_Exa_dis(id_02) {
            var Data_Par_tabla = JSON.stringify({
                "AVIS": id_02

            });
            var ajax_tabla = $.ajax({
                "type": "POST",
                "url": "AVIS_C_D.aspx/Ajax_Exa_no_dis",
                "data": Data_Par_tabla,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    //Debug

                    //Mx_Dtt2 = data_tabla_paciente.d;
                    //--------Llamamos al fill_datatable para llenar datos en la tabla--------->
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Ajax_N_PACIENTE();
                    } else {
                        Ajax_N_PACIENTE();
                    }
                },
                "error": data_tabla_paciente => {
                    Hide_Modal();


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
        
        //-----Fill llenar datatable---->
        function Fill_DataTable2() {
            $("#Div_Tabla").empty();
            $("<table>", {
                "id": "DataTable_pac",
                "class": "table table-hover table-striped table-iris table-iris",
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
                    $("<th>", { "class": "textoReducido text-center" }).text("Nº de orden"),
                    $("<th>", { "class": "textoReducido text-left" }).text("Desc. Examen"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Estado"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Cambiar Estado")
                    //$("<th>", { "class": "textoReducido text-center" }).text("N° Atención"),
                    //$("<th>", { "class": "textoReducido text-center" }).text("Procedencia"),
                    //$("<th>", { "class": "textoReducido text-center" }).text("Cant. Exámenes"),
                    //$("<th>", { "class": "textoReducido text-center" }).text("Estado")
                    //$("<th>", { "class": "textoReducido text-center" }).text("")

                )
            );
            //Suma para rellenar datos de cantidades de paciente en espera, atendidos;
            //var pac = 0;
            //var espera = 0;
            //var aten = 0;
            //var Noasis = 0;
            $("#Paciente").text(Mx_Dtt2[0].HO_Nombres + " " + Mx_Dtt2[0].HO_ApellidoPaterno + " " + Mx_Dtt2[0].HO_ApellidoMaterno);

            $("#Examen").text(Mx_Dtt2[0].HO_RutPaciente);
            for (i = 0; i < Mx_Dtt2.length; i++) {
                $("#DataTable_pac tbody").append(
                    $("<tr>", {
                        //llamamos a la funcion para rellenar el modal con datos del paciente seleccionado
                       
                        "class": "textoReducido manito",
                        "padding": "1px !important",
                        "data-i": i
                    }).append(
                        $("<td>", {
                            "align": "center",
                            "class": "textoReducido"
                        }).text(i + 1),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).text(Mx_Dtt2[i].HO_CC),
                        $("<td>", {
                            "align": "center",
                            "class": "textoReducido",
                            "data-ayy": true
                        }).text(Mx_Dtt2[i].HO_ExamenDescripcion),
                        $("<td>", {
                            //"onclick": `Ajax_modal_exa("` + Mx_Dtt2[i].IRIS_H_ID_PREINGRESO + `","` + Mx_Dtt2[i].IRIS_H_ID_ATENCION + `","` + Mx_Dtt2[i].HO_CC + `")`,
                            "align": "left",
                            "class": "textoReducido"
                        }).text(function () {

                            if (Mx_Dtt2[i].HO_EstadoProceso == "D") {
                                $(this).css("cssText", "background-color:#9bffb1 !important; color:inherit;  text-align:center;").addClass("espera").text("Disponible");
                            } else {
                                $(this).css("cssText", "background-color:#f44242 !important; color:#ffffff;  text-align:center;").addClass("espera_2").text("No Disponible");
                            }
                        }),
                        $("<td>", {
                            "align": "center",
                            "class": "textoReducido"
                        }).html(function () {
                        if (Gall_T_USU == 5) {
                            return "<button type='button' class='btn btn-dark btn-xs CEstado' value='Espera' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Inhabilitado</button>"
                        }else{
                        if (Mx_Dtt2[i].HO_EstadoProceso == "D") {
                                return "<button type='button' class='btn btn-print btn-xs CEstado' value='Espera' onclick='Ajax_Exa_no_dis(" + Mx_Dtt2[i].HO_ID + ")' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a No Disponible</button>"
                        } else {
                                return "<button type='button' class='btn btn-success btn-xs Activado' value='Espera' onclick='Ajax_Exa_dis(" + Mx_Dtt2[i].HO_ID + ")' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Disponible</button>"
        }
                    }
                            
                        })
                          
                    )

                )
            }

            $(`#DataTable_pac td[data-ayy=true]`).click((ev) => {
                ev.stopImmediatePropagation();
                let ii = parseInt($(ev.currentTarget).parent().attr("data-i"));

                Ajax_modal_exa(Mx_Dtt2[ii].IRIS_H_ID_PREINGRESO, Mx_Dtt2[ii].IRIS_H_ID_ATENCION, Mx_Dtt2[ii].HO_CC);
            });


            $("#DataTable_pac").DataTable({
                "searching": false,
                "iDisplayLength": 100,
                "info": false,
                "bPaginate": false,
                //"bFilter": false,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay coincidencias",
                    "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Buscar: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
        }

        function llenarmodal(ATENCION_PACIENTE_ID, id_id_id_preingreso, AATE_NNUM_ATENCION) {


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
            } else { $("#rut").val(Mx_Detalle_ate.proparra1[0].PAC_RUT); }

            $("#NOMBRE").val(Mx_Detalle_ate.proparra1[0].PAC_NOMBRE + " " + Mx_Detalle_ate.proparra1[0].PAC_APELLIDO);
           
                $("#ATENe").val(Mx_Detalle_ate.proparra1[0].PREI_NUM);
            
            let FechaREE = moment(Mx_Detalle_ate.proparra1[0].PAC_FNAC).format("DD-MM-YYYY");

            $("#FNAC").val(FechaREE);
            $("#Edad").val(Mx_Detalle_ate.proparra1[0].PREI_AÑO + " Años");
            $("#Sex").val(Mx_Detalle_ate.proparra1[0].SEXO_DESC);
            $("#FUR").val(Mx_Detalle_ate.proparra1[0].PREI_FUR);
            $("#Nacio").val(Mx_Detalle_ate.proparra1[0].NAC_DESC);
            $("#Telfijo").val(Mx_Detalle_ate.proparra1[0].PAC_FONO1);
            $("#Celular").val(Mx_Detalle_ate.proparra1[0].PAC_MOVIL1);
            $("#Ciudad").val(Mx_Detalle_ate.proparra1[0].CIU_DESC);
            $("#Comuna").val(Mx_Detalle_ate.proparra1[0].COM_DESC);
            $("#Direc").val(Mx_Detalle_ate.proparra1[0].PAC_DIR);
            $("#Email").val(Mx_Detalle_ate.proparra1[0].PAC_EMAIL);
            $("#PerPAc").val(Mx_Detalle_ate.proparra1[0].PAC_OBS_PERMA);

            if (Mx_Detalle_ate.proparra2.length == 0) {
                $("#Obate").val("No Contiene N° de orden");//Mx_Detalle_ate.proparra1[0].PREI_OBS_FICHA
            } else {
                $("#Obate").val("N° Orden Clínica: " + Mx_Detalle_ate.proparra2[0].ATE_NUM_AVIS);//Mx_Detalle_ate.proparra1[0].PREI_OBS_FICHA
            }




            $("#obtm").val(Mx_Detalle_ate.proparra3[0].PREI_OBS_TM);//Mx_Detalle_ate.proparra3[0].PREI_OBS_TM
            $("#Prev").val(Mx_Detalle_ate.proparra3[0].PREVE_DESC);//
            $("#VIH").val(Mx_Detalle_ate.proparra3[0].VIH);//);//

            if (Mx_Detalle_ate.proparra3[0].ATE_NUM_INTERNO == 0 || Mx_Detalle_ate.proparra3[0].ATE_NUM_INTERNO == "") {
                $("#Interno").val("");//
            } else {
                $("#Interno").val(Mx_Detalle_ate.proparra3[0].ATE_NUM_INTERNO);//
            }
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



            //// VERIFICAR SI EL PACIENTE ESTA ATENDIDO O NO
            //if (ATENCION_PACIENTE_ID == 0 || ATENCION_PACIENTE_ID == "") {
            //    $("#btnobs").show();

            //    $("#btnpreingreso").show();
            //    $("#btnpreingreso").off("click");
            //    $("#btnpreingreso").click(() => {
            //        var loc = location.origin;
            //        window.location.href = loc + "/Agenda_Med/Ingreso_ate_avis_2.aspx" + "?ID_ATE" + "=" + id_id_id_preingreso + "&ID_PREV" + "=" + $("#Ddl_LugarTM").val();
            //    });
            //    $("#btn_reimprimir").hide();
            //    $("#btn_actualizar").hide();
            //    $("#btn_eliminar").show();



            //    //$("#btn_v_comp_ate").hide();
            //    //$("#btn_Eti").hide();
            //    //$("#btn_lugar_tm").hide();
            //} else {

            //    if (Galletas.getGalleta("P_ADMIN") == 1) {
            //        $("#btn_eliminar").show();
            //    } else {
            //        $("#btn_eliminar").hide();
            //    }


            //    $("#btnobs").hide();
            //    $("#btnpreingreso").hide();
            //    $("#btn_reimprimir").show();
            //    //$("#btn_v_comp_ate").show();
            //    //$("#btn_Eti").show();
            //    $("#btn_actualizar").show();
            //}
        }
        var Mx_Detalle_ate = {
            "proparra1": [{
                "ID_PREINGRESO": 0,
                "PREI_NUM": 0,
                "PREI_FECHA": 0,
                "PREI_FUR": 0,
                "PREI_OBS_FICHA": 0,
                "PREI_AÑO": 0,
                "PREI_OBS_TM": 0,
                "PAC_NOMBRE": 0,
                "SEXO_DESC": 0,
                "PAC_APELLIDO ": 0,
                "PAC_FNAC": 0,
                "PAC_DIR": 0,
                "PAC_FONO1": 0,
                "PAC_MOVIL1": 0,
                "PAC_EMAIL": 0,
                "PAC_OBS_PERMA": 0,
                "NAC_DESC": 0,
                "CIU_DESC": 0,
                "COM_DESC": 0,
                "ID_PACIENTE": 0,
                "PAC_RUT": 0,
                "DNI": 0

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
            }],
            "proparra3": [{
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "ID_PREINGRESO": 0,
                "PREI_NUM": 0,
                "TP_ATE_DESC": 0,
                "LOCAL_DESC": 0,
                "ORD_DESC": 0,
                "ID_ORDEN": 0,
                "ID_PROCEDENCIA": 0,
                "ID_DOCTOR": 0,
                "ID_PREVE": 0,
                "ID_LOCAL": 0,
                "PREI_CAMA": 0,
                "PREI_OBS_FICHA": 0,
                "PROC_DESC": 0,
                "PREVE_DESC": 0,
                "ATE_NUM_INTERNO": 0,
                "PREI_OBS_TM": "",
                "ID_ATENCION": 0,
                "VIH": ""
            }]
        }
        ///////////////////
        function Ajax_modal_exa(preingreso_paciente, atencion_paciente, ATE_NUM_ATENCION_MODAL) {
            //cambiar de colores los input a normales
            $("#Interno").css({
                "border-color": "#868e96"
            });
            $("#Obate").css({
                "border-color": "#868e96"
            });
            $("#obtm").css({
                "border-color": "#868e96"
            });
            //Debug
            var Data_Par_modal = JSON.stringify({
                "ID": preingreso_paciente,
                "ID_ATE": atencion_paciente

            });

            if ((preingreso_paciente == 0 || preingreso_paciente == "null" || preingreso_paciente == null) && atencion_paciente == 0) {
                var str_Error = "El Examen No tiene una atención o preingreso asociado"
                $("#title").text("Solicitud de Información");
                $("#button_modal").attr("class", "btn btn-success");
                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();
                console.log("----------0-----------");
            } else {
                $.ajax({
                    "type": "POST",
                    "url": "AVIS_C_D.aspx/MODAL_PAC",
                    "data": Data_Par_modal,
                    "contentType": "application/json;  charset=utf-8",
                    "dataType": "json",
                    "success": Data_Par_modal_paciente => {

                        //Debug

                        Mx_Detalle_ate = Data_Par_modal_paciente.d;
                        console.log(Mx_Detalle_ate);
                        //ENVIAMOS ID_ATEMCION AL MODAL



                        //LLAMAMOS AL FILL MODAL
                        llenarmodal(atencion_paciente, preingreso_paciente, ATE_NUM_ATENCION_MODAL);

                        // MOSTRAR EL MODAL
                        $('#eModales33').modal('show');
                    },
                    "error": Data_Par_modal_paciente => {



                    }
                });

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

        .NOASISTIO {
            background-color: #e04747 !important;
            color: white !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <!-- Modal -->
    <div id="MOdal_PAGO" class="modal fade" role="dialog">
        <div class="modal-dialog ml-xl-auto">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 id="title2" class="modal-title">Error</h4>
                </div>
                <div id="bodyimpr" class="modal-body">
                    <p></p>
                </div>
                <div class="modal-footer">
                    <button type="button" id="b" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                    <button type="button" id="button_modal_pago" class="btn btn-print" data-dismiss="modal"><i class="fa fa-fw fa-print mr-2"></i>Imprimir</button>
                </div>
            </div>
        </div>
    </div>
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
                            <h5 id="xxxxxx" class="m-0">Antecedentes de Agendamiento</h5>
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
                                            <input type='text' id="Interno" class="form-control textoReducido2 borderaaa" />
                                        </div>
                                        <div class="col-sm">
                                            <label class="textoReducido2">V.I.H.:</label>
                                            <input type='text' id="VIH" class="form-control textoReducido2 borderaaa" />
                                        </div>
                                        <div class="col-sm">
                                            <label class="textoReducido2">Observaciones de la atencion:</label>
                                            <input type='text' id="Obate" class="form-control textoReducido2 borderaaa" />
                                        </div>
                                        <div class="col-sm">
                                            <label class="textoReducido2">Observaciones de toma de muestra:</label>
                                            <input type='text' id="obtm" class="form-control textoReducido2 borderaaa" />
                                        </div>
                                        <div class="col-sm">
                                            <label class="textoReducido2">Prevision:</label>
                                            <input type='text' id="Prev" class="form-control textoReducido2 borderaaa" disabled="disabled" />
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
<%--                    <button type="button" class="btn btn-success" id="btnobs"><i class="fa fa-fw fa-check mr-2"></i>Atender</button>
                    <button type="button" class="btn btn-info" id="btnpreingreso"><i class="fa fa-fw fa-check mr-2"></i>Ir Atención</button>
                    <button type="button" class="btn btn-print" id="btn_reimprimir"><i class="fa fa-fw fa-print mr-2"></i>Imprimir</button>
                    <button type="button" class="btn btn-primary" id="btn_actualizar">Actualizar Datos</button>
                    <button type="button" class="btn btn-warning" id="btn_eliminar">Eliminar</button>--%>
                    <div>
                    </div>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Breadcrumbs -->

    <div class="card border-bar">
        <div class="card-header bg-bar">
            <h5 style="text-align: center; padding: 5px;">
                <i class="fa fa-bookmark-o"></i>
                Listado de Exámenes de Paciente Avis
            </h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg">

                            <label class="">N° Avis:</label>
                            <input type='text' id="AVIS" class="form-control" placeholder="" />
                        </div>
                        <div class="col-lg">
                            <label class="">RUT o D.N.I:</label>
                            <input type='text' id="RUT" class="form-control" placeholder="" />
                        </div>

                        <%--                        <div class="col-lg-1 text-center">
                            <button id="Btnexcel" type="button" class="btn btn-success">
                                <i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel
                            </button>
                        </div>--%>
                    </div>
                    <div class="row">
                        <div class="col-lg">
                            <button id="Btnbuscar" type="button" class="btn btn-buscar btn-block">
                                <i class="fa fa-fw fa-search mr-2"></i>Buscar
                            </button>
                        </div>
                                     <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-12">
                                    <p style="font-size: 13px;" class="textbot"><strong>Antecedentes del Paciente</strong></p>
                                    <div class="row">
                                        <div class="col-sm textbot">
                                            <p style="font-size: 12px;"><strong>Nombre del Paciente:</strong></p>
                                        </div>
                                        <div class="col-sm textbot">
                                            <p id="Paciente" style="font-size: 12px;"></p>
                                        </div>
                                        <div class="col-sm textbot">
                                            <p style="font-size: 12px;"><strong>RUT o DNI:</strong></p>
                                        </div>
                                        <div class="col-sm textbot">
                                            <p id="Examen" style="font-size: 12px;"></p>
                                        </div>
                       <%--                 <div class="col-sm textbot">
                                            <p style="font-size: 12px;"><strong>N° de Atendidos:</strong></p>
                                        </div>
                                        <div class="col-sm textbot">
                                            <p id="ATEN" style="font-size: 12px;"></p>
                                        </div>

                                        <div class="col-sm textbot">
                                            <p style="font-size: 12px;"><strong>N° de No Asistio:</strong></p>
                                        </div>
                                        <div class="col-sm textbot">
                                            <p id="Noasis" style="font-size: 12px;"></p>
                                        </div>
                                        <div class="col-sm textbot">
                                            <p style="font-size: 12px;"><strong>N° En Espera:</strong></p>
                                        </div>
                                        <div class="col-sm textbot">
                                            <p id="ESPERA" style="font-size: 12px;"></p>
                                        </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
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
