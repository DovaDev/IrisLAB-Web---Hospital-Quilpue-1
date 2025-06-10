<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="N_Ver_Disponibilidad_2.aspx.vb" Inherits="Presentacion.N_Ver_Disponibilidad_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>
        window.onload = function () {
            let Gall_T_USU = Galletas.getGalleta("P_ADMIN");
            if (Gall_T_USU == 5) {
                $("#BtnAgenda").hide();
            }
        };
        $(document).ready(function () {

            $("#Div_Tabla99").append(
                ("<div class='alert alert-success alertas'><strong>Por favor seleccione una cantidad de días y Procedencia</strong>  </div>")
               );

            $("#txt_timer").focusout(function () {
                if ($("#txt_timer").val() > 30) {
                    $("#txt_timer").val("30");
                } else if ($("#txt_timer").val() < 15) {
                    $("#txt_timer").val("15");
                }
            });

            $("#txt_timer").val("15");

            var f = moment().format("DD-MM-YYYY");
            $("#fecha").val(f);
            Call_AJAX_Ddl();
            //$("#fur").css("pointer-events", "none");


            $('#BtnAgenda').attr("disabled", true);

            $("#btnbuscar").click(function () {
                $("#Div_Tabla99").empty();
                if ($("#Ddl_LugarTM").val() != 222) {
                    Ajax_DataTable();
                } else {
                    var str_Error = "Estimado usuario, por favor seleccione una procedencia"
                    $("#title").text("Seleccione una procedencia");
                    $("#button_modal").attr("class", "btn btn-success");
                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();
                    $("#Div_Tabla99").append(
                     ("<div class='alert alert-success alertas'><strong>Por favor seleccione una cantidad de días y Procedencia</strong>  </div>")
                    );
                }

            });

        });
    </script>
    <script>
        //Declaración de JSON
        var Mx_Ddl = [
            {
                "ID_PROCEDENCIA": "",
                "PROC_COD": "",
                "PROC_DESC": "",
                "ID_ESTADO": ""
            }
        ];
        //AJAX DroDownList
        function Call_AJAX_Ddl() {
            //Debug



            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "N_Ver_Disponibilidad_2.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Ddl = data.d;

                    Fill_Ddl();
                },
                "error": data => {
                    //Debug



                }
            });
        }
        //´buscar lista de procendecia maz agenda disponible
        var Mx_Dtt = [
                  {
                      "ID_PROCEDENCIA": 0,
                      "PROC_DESC": 0,
                      "PROC_CANT_EXA": 0,
                      "ID_ESTADO ": 0,
                      "DIA_DEL_DIA": 0,
                      "TOTAL_ATE": 0,
                      "PROC_CANT_EXA_BUSCA_DIAS": 0,
                      "CONF_DIAS_FECHA_BUSCA_DIAS": 0,
                      "CONF_DIAS_EXA_BUSCA_DIAS": 0,
                      "ID_ESTADO_BUSCA_DIAS ": 0,
                      "ID_PROCEDENCIA_BUSCA_DIAS": 0,
                      "ID_CONF_DIAS_BUSCA_DIAS": 0,
                      "AGEND_CUPO_NORMAL ": 0,
                      "AGEND_PRIORITARIO": 0,
                      "AGEND_ESPONTANEO": 0,
                      "TOTAL_AGEND_CUPO_NORMAL ": 0,
                      "TOTAL_AGEND_PRIORITARIO": 0,
                      "TOTAL_AGEND_ESPONTANEO": 0
                  }
        ];

        function Ajax_DataTable() {




            modal_show();

            $("#Div_Tabla").empty();
            $("#Div_Tabla2").empty();
            var Data_Par = JSON.stringify({
                "fecha": $("#fecha").val(),
                "ID_Procedencia": $("#Ddl_LugarTM").val(),
                "timer": $("#txt_timer").val()
            });

            $.ajax({
                "type": "POST",
                "url": "N_Ver_Disponibilidad_2.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        Fill_DataTable();
                        //$('#BtnAgenda').attr("disabled", true);
                        //$('#BtnModificar').attr("disabled", true);
                        //$('#BtnNoAsistio').attr("disabled", true);
                        //$('#BtnAtendido').attr("disabled", true);


                        $("#Div_Tabla2").append(
                        ("<div class='alert alert-success alertas'><strong>Por favor seleccione una Fecha</strong></div>")
                        );
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

        //buscar pacientes
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
                "PROC_DESC": 0
            }
        ];

        function Ajax_N_PACIENTE(ID, CONF_DIAS_EXA_BUSCA_DIAS, TOTAL_ATE, FECHA) {
            modal_show();
            idx = ID;
            dias = CONF_DIAS_EXA_BUSCA_DIAS;
            total = TOTAL_ATE;



            $("#Div_Tabla2").empty();
            var Data_Par = JSON.stringify({
                "ID": ID,
                "fecha": FECHA
            });

            $.ajax({
                "type": "POST",
                "url": "Ver_Disponibilidad.aspx/Llenar_PAC",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt2 = JSON.parse(json_receiver);

                        Fill_DataTable2();
                        var uu = 0;
                        uu = CONF_DIAS_EXA_BUSCA_DIAS - TOTAL_ATE;

                        if ((TOTAL_ATE == 0) || (uu <= 0)) {
                            $('#BtnAgenda').attr("disabled", true);
                            //$('#BtnModificar').attr("disabled", false);
                            //$('#BtnNoAsistio').attr("disabled", false);
                            //$('#BtnAtendido').attr("disabled", false);
                        } else {
                            $('#BtnAgenda').attr("onclick", `Ajax_Agendar("` + ID + `","` + FECHA + `")`);
                            $('#BtnAgenda').attr("disabled", false);
                            //$('#BtnModificar').attr("disabled", false);
                            //$('#BtnNoAsistio').attr("disabled", false);
                            //$('#BtnAtendido').attr("disabled", false);
                        }
                        Hide_Modal();




                    } else {




                        var uu = 0;
                        uu = CONF_DIAS_EXA_BUSCA_DIAS - TOTAL_ATE;
                        if (TOTAL_ATE == 0) {

                            $('#BtnAgenda').attr("onclick", `Ajax_Agendar("` + ID + `","` + FECHA + `")`);
                            $('#BtnAgenda').attr("disabled", false);
                            //$('#BtnModificar').attr("disabled", true);
                            //$('#BtnNoAsistio').attr("disabled", true);
                            //$('#BtnAtendido').attr("disabled", true);
                        } else {
                            $('#BtnAgenda').attr("disabled", true);
                            //$('#BtnModificar').attr("disabled", true);
                            //$('#BtnNoAsistio').attr("disabled", true);
                            //$('#BtnAtendido').attr("disabled", true);
                        }
                        if ((TOTAL_ATE == 0) && (CONF_DIAS_EXA_BUSCA_DIAS == 0)) {
                            $('#BtnAgenda').attr("disabled", true);
                            //$('#BtnModificar').attr("disabled", true);
                            //$('#BtnNoAsistio').attr("disabled", true);
                            //$('#BtnAtendido').attr("disabled", true);
                        }
                        Hide_Modal();
                        //$("#Paciente").text(0);
                        //$("#ESPERA").text(0);
                        //$("#ATEN").text(0);
                        //$("#Examen").text(0);
                        $("#Div_Tabla2").append(
                        ("<div class='alert alert-danger alertas'><strong>Sin Agendamientos</strong>  </div>")

                        );
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }
        function Ajax_Agendar(NUM, fecha_ac) {

            $('#Manual').attr("onclick", "window.location.href='/Agenda_Med/IN_PAC_MAN_2.aspx?kl=" + NUM + "&FF=" + fecha_ac + "'");
            $('#AVIS').attr("onclick", "window.location.href='/Agenda_Med/IN_PAC_AVIS_2.aspx?kl=" + NUM + "&FF=" + fecha_ac + "'");

            var admin2 = Galletas.getGalleta("P_ADMIN");
            if (admin2 == 1) {
                $("#Manual").removeAttr('disabled');
            } else {

                $('#Manual').attr("disabled", true);
            }

            $('#eModal').modal('show');
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

            }
            ],
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
                "PREVE_DESC": 0
            }]
        }
        function Ajax_modal_exa(id_ate) {

            var Data_Par = JSON.stringify({
                "ID": id_ate,
            });

            $.ajax({
                "type": "POST",
                "url": "N_Ver_Disponibilidad_2.aspx/MODAL_PAC",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Detalle_ate = JSON.parse(json_receiver);
                        llenarmodal();
                        $('#eModales').modal('show');

                    } else {


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
    <script>
        function Fill_Ddl() {
            //$("<option>",
            //    {
            //        "value": 222
            //    }
            //).text("Seleccione Procedencia").appendTo("#Ddl_LugarTM");

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


            $("#DataTable thead").append(
                $("<tr>").append(

                    $("<th>", {
                        "align": "center",
                        "class": "textoReducido ancho-columna"
                    }).text("#"),
                    $("<th>", {
                        "align": "center",
                        "class": "textoReducido ancho-columna text-center"
                    }).text("Fecha"),
                    $("<th>", {
                        "align": "center",
                        "class": "textoReducido ancho-columna"
                    }).text("Día"),
                    $("<th>", {
                        "align": "center",
                        "class": "textoReducido ancho-columna text-center"
                    }).text("Máximo"),
                    $("<th>", {
                        "align": "center",
                        "class": "textoReducido ancho-columna text-center"
                    }).text("Agendado cupo normal"),
                    $("<th>", {
                        "align": "center",
                        "class": "textoReducido ancho-columna text-center"
                    }).text("Agendado prioritario"),
                    $("<th>", {
                        "align": "center",
                        "class": "textoReducido ancho-columna text-center"
                    }).text("Agendado espontáneo"),
                    $("<th>", {
                        "align": "center",
                        "class": "textoReducido ancho-columna text-center"
                    }).text("Disponible"),
                                      $("<th>", {
                                          "align": "center",
                                          "class": "textoReducido ancho-columna text-center"
                                      }).text("Comentario")

                )
            );
            $("#DataTable thead tr").addClass("cabzera bg-custom");
            for (i = 0; i < Mx_Dtt.length; i++) {


                var p1 = Mx_Dtt[i].TOTAL_AGEND_CUPO_NORMAL;
                var p2 = Mx_Dtt[i].TOTAL_AGEND_PRIORITARIO;
                var p3 = Mx_Dtt[i].TOTAL_AGEND_ESPONTANEO;
                var to = p1 + p2 + p3


                //console.log(Mx_Dtt[i]);
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_N_PACIENTE("` + $("#Ddl_LugarTM").val() + `","` + Mx_Dtt[i].CONF_DIAS_EXA_BUSCA_DIAS + `","` + to + `","` + Mx_Dtt[i].FECHA + `")`,
                        "class": "textoReducido manito"
                    }).append(
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido ancho-columna"
                        }).text(i + 1),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido ancho-columna text-center"
                        }).text(Mx_Dtt[i].FECHA),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido ancho-columna text-capitalize"
                        }).text(Mx_Dtt[i].DIA_DEL_DIA),
                        $("<td>", {
                            "align": "right",
                            "class": "textoReducido ancho-columna text-center"
                        }).text(Mx_Dtt[i].CONF_DIAS_EXA_BUSCA_DIAS),
                        $("<td>", {
                            "align": "right",
                            "class": "textoReducido ancho-columna text-center"
                        }).text(function () {
                            var resu = 0;
                            resu = Mx_Dtt[i].AGEND_CUPO_NORMAL - Mx_Dtt[i].TOTAL_AGEND_CUPO_NORMAL;
                            if (resu < 0) {
                                resu = 0;
                            }
                            return resu;
                        }),
                        $("<td>", {
                            "align": "right",
                            "class": "textoReducido ancho-columna text-center"
                        }).text(function () {
                            var resu = 0;
                            resu = Mx_Dtt[i].AGEND_PRIORITARIO - Mx_Dtt[i].TOTAL_AGEND_PRIORITARIO;
                            if (resu < 0) {
                                resu = 0;
                            }
                            return resu;
                        }),
                        $("<td>", {
                            "align": "right",
                            "class": "textoReducido ancho-columna text-center"
                        }).text(function () {
                            var resu = 0;
                            resu = Mx_Dtt[i].AGEND_ESPONTANEO - Mx_Dtt[i].TOTAL_AGEND_ESPONTANEO;
                            if (resu < 0) {
                                resu = 0;
                            }
                            return resu;
                        }),
                        $("<td>", {
                            "align": "right",
                            "class": "textoReducido ancho-columna text-center"
                        }).text(function () {
                            var resu = 0;
                            var p1 = Mx_Dtt[i].TOTAL_AGEND_CUPO_NORMAL;
                            var p2 = Mx_Dtt[i].TOTAL_AGEND_PRIORITARIO;
                            var p3 = Mx_Dtt[i].TOTAL_AGEND_ESPONTANEO;
                            var to = p1 + p2 + p3
                            resu = Mx_Dtt[i].CONF_DIAS_EXA_BUSCA_DIAS - to;
                            if (resu < 0) {
                                resu = 0;
                            }
                            return resu;
                        }),
                                                $("<td>", {
                                                    "align": "left",
                                                    "class": "textoReducido ancho-columna text-center"
                        }).text(Mx_Dtt[i].TOTAL_COMENTARIO)
                    )
                )
            }
            active_tr();

        }
        function Fill_DataTable2() {
            $("<table>", {
                "id": "DataTable_pac",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla2");

            $("#DataTable_pac").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_pac").attr("class", "table  table-hover table-striped table-iris");
            $("#DataTable_pac thead").attr("class", "cabzera bg-custom");
            $("#DataTable_pac thead").append(
                $("<tr>").append(

                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Agendado"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Estado")

                )
            );
            var pac = 0;
            var espera = 0;
            var aten = 0;
            for (i = 0; i < Mx_Dtt2.length; i++) {
                $("#DataTable_pac tbody").append(
                    $("<tr>", {
                        //"onclick": `Ajax_Datos_BTNS("` + Mx_Dtt2[i].ID_PREINGRESO + `","` + Mx_Dtt2[i].PREI_NUM + `","` + Mx_Dtt2[i].ID_PACIENTE + `","` + Mx_Dtt2[i].ID_ATENCION + `")`,
                        "ondblclick": `Ajax_modal_exa("` + Mx_Dtt2[i].ID_PREINGRESO + `")`,
                        "class": "textoReducido manito",
                        "padding": "1px !important",
                    }).append(
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).text(i + 1),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido text-center"
                        }).text(Mx_Dtt2[i].PREI_NUM),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).text(Mx_Dtt2[i].PAC_NOMBRE + " " + Mx_Dtt2[i].PAC_APELLIDO),
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

                       /////////////////////////////////
                        //$("<td>", {
                        //    "align": "center",
                        //    "class": "textoReducido",

                        //}).html(`<i class="fa fa-info-circle" aria-hidden="true"></i>`)
                    )
                )
                if (Mx_Dtt2[i].EST_DESCRIPCION == "ESPERA") {
                    espera++;
                }
                if (Mx_Dtt2[i].EST_DESCRIPCION == "ATENDIDO") {
                    aten++;
                }
                pac++;
            }

            active_tr();

        }
        function llenarmodal() {
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
                $("#rut").val(Mx_Detalle_ate.proparra1[0].DNI)
            } else {
                $("#rut").val(Mx_Detalle_ate.proparra1[0].PAC_RUT)
            }



            $("#NOMBRE").val(Mx_Detalle_ate.proparra1[0].PAC_NOMBRE + " " + Mx_Detalle_ate.proparra1[0].PAC_APELLIDO);
            $("#ATENe").val(Mx_Detalle_ate.proparra1[0].PREI_NUM);
            $("#FNAC").val(Mx_Detalle_ate.proparra1[0].PAC_FNAC);
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
            $("#Obate").val(Mx_Detalle_ate.proparra1[0].PREI_OBS_FICHA);//Mx_Detalle_ate.proparra1[0].PREI_OBS_FICHA
            $("#obtm").val("");//Mx_Detalle_ate.proparra3[0].PREI_OBS_FICHA
            $("#Prev").val(Mx_Detalle_ate.proparra3[0].PREVE_DESC);//
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
            $("#DataTable_pac2").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_pac2 thead").attr("class", "cabzera bg-custom");
            $("#DataTable_pac2 thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Codigo Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("Descripcion"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Dias Proceso")
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
            $("#cantidad").text("Cantidad de Exámenes: " + cantidad)

        }
    </script>
    <style>
        .alertas {
            margin-top: 180px;
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
            width: 710px;
            max-height: 65vh; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
        }

        .highlights2 {
            width: 710px;
            max-height: 65vh; /* Ancho y alto fijo */
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
    <div id="MOdal_PAGO" class="modal fade" role="dialog">
        <div class="modal-dialog ml-xl-auto">

            <!-- Modal content-->
            <div class="modal-content p-3">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h3 id="title2" class="modal-title">Error</h3>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">

                    <button type="button" id="b" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                    <button type="button" id="button_modal_pago" class="btn btn-print" data-dismiss="modal"><i class="fa fa-fw fa-print mr-2"></i>Imprimir</button>

                </div>
            </div>
        </div>
    </div>
    <%--Modal Agendar--%>
    <div class="modal fade" id="eModal" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content p-3">
                <div class="modal-header">
                    <h5 class="modal-title" id="sss">OPCIONES DE INGRESO</h5>
                </div>
                <%--      <div class="modal-header">
          <h6 class="modal-title" id="Titulo">Nombre PAc</h6>
          <h6 class="modal-title" id="sub">Nombre PAc</h6>       
      </div>--%>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6" style="text-align: center;">
                            <button type="button" id="Manual" class="btn btn-primary" style="height: 120px; width: 75%;"><b>PACIENTE MANUAL</b></button>
                        </div>
                        <div class="col-md-6" style="text-align: center;">
                            <button type="button" id="AVIS" class="btn btn-info" style="height: 120px; width: 75%;"><b>PACIENTE AVIS</b></button>
                        </div>
                    </div>
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
    <div class="modal fade" id="eModales" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
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
                                            <label class="textoReducido2">Observaciones de la atencion:</label>
                                            <input type='text' id="Obate" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>
                                        <div class="col-sm">
                                            <label class="textoReducido2">Observaciones de toma de muestra:</label>
                                            <input type='text' id="obtm" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                        </div>
                                        <div class="col-sm">
                                            <label class="textoReducido2">Prevision:</label>
                                            <input type='text' id="Prev" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
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
                    <div class="card md-3">
                    </div>
                    <div class="modal-footer border-top-0">
                        <h5 id="cantidad"></h5>
                        <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <!-- Breadcrumbs -->
    <div class="card border-bar">
        <div class="card-header bg-bar">
            <h5 class="text-center m-0">
                <i class="fa fa-bookmark-o"></i>
                Ver Disponibilidad
            </h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg-6 mb-1">
                    <div class="row">
                        <div class="col-lg mb-1">
                            <div class='input-group date' id='datetimepicker1' style="margin-bottom: 1vh;">
                                <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Fecha" />
                                <span id="fur" class="input-group-addon">
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
                        <div class="col-lg mb-1">
                            <select id="Ddl_LugarTM" class="form-control">
                            </select>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 mb-1">
                    <div class="row">
                        <div class="col-lg-6 mb-1">
                            <div class="form-inline">
                                <label class="col-4">Cant. Días:</label>
                                <input id="txt_timer" type="number" class="form-control col-8" min="10" max="30" />
                            </div>

                        </div>

                        <div class="col-lg-3 text-center mb-1">
                            <button id="btnbuscar" type="button" class="btn btn-buscar btn-block" style="margin: 0"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>

                        </div>
                        <div class="col-lg-3 text-center mb-1">
                            <button id="BtnAgenda" type="button" class="btn btn-warning btn-block" style="margin: 0"><i class="fa fa-fw fa-book mr-2"></i>Agendar</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-lg-5">
                    <div id="Div_Tabla" style="width: 100%;" class="highlights">
                    </div>
                </div>
                <div class="col-lg-7">
                    <div id="Div_Tabla2" style="width: 100%;" class="highlights2">
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div id="Div_Tabla99" style="width: 100%;"></div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
