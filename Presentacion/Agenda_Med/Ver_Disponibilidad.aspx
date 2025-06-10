<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Ver_Disponibilidad.aspx.vb" Inherits="Presentacion.Ver_Disponibilidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
     <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true"%>
    <link href="../css/bootstrap-datetimepicker.css" rel="stylesheet" />
    <link href="../css/jquery.mCustomScrollbar.css" rel="stylesheet" />
    <script>
        var idx = 0;
        var dias = 0;
        var total = 0;
        $(document).ready(function () {
            var f = moment().format("DD-MM-YYYY");
            $("#fecha").val(f);
            Ajax_DataTable();
            $("#fecha").change(function () {
                Ajax_DataTable();
                $("#Paciente").text(0);
                $("#ESPERA").text(0);
                $("#ATEN").text(0);
                $("#Examen").text(0);
            });
        });
    </script>
    <script>
        var Mx_Dtt = [
           {
               "ID_PROCEDENCIA": 0,
               "PROC_DESC": 0,
               "PROC_CANT_EXA": 0,
               "ID_ESTADO ": 0,
               "PRO_TIPO_I": 0,
               "TOTAL_ATE": 0,
               "PROC_CANT_EXA_BUSCA_DIAS": 0,
               "CONF_DIAS_FECHA_BUSCA_DIAS": 0,
               "CONF_DIAS_EXA_BUSCA_DIAS": 0,
               "ID_ESTADO_BUSCA_DIAS ": 0,
               "ID_PROCEDENCIA_BUSCA_DIAS": 0,
               "ID_CONF_DIAS_BUSCA_DIAS": 0
           }
        ];
        function Ajax_DataTable() {


            modal_show();
            $("#Div_Tabla").empty();
            $("#Div_Tabla2").empty();
            var Data_Par = JSON.stringify({
                "fecha": $("#fecha").val(),
            });
            $.ajax({
                "type": "POST",
                "url": "Ver_Disponibilidad.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        Fill_DataTable();
                        $('#BtnAgenda').attr("disabled", true);
                        $('#BtnModificar').attr("disabled", true);
                        $('#BtnNoAsistio').attr("disabled", true);
                        $('#BtnAtendido').attr("disabled", true);

                        $("#Div_Tabla2").append(
                        ("<div class='alert alert-success alertas'><strong>Por favor seleccione una Procedencia</strong></div>")
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
        function Ajax_N_PACIENTE(ID, CONF_DIAS_EXA_BUSCA_DIAS, TOTAL_ATE) {
            idx = ID;
            dias = CONF_DIAS_EXA_BUSCA_DIAS;
            total = TOTAL_ATE;

            $("#Div_Tabla2").empty();
            var Data_Par = JSON.stringify({
                "ID": ID,
                "fecha": $("#fecha").val()
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
                        if ((TOTAL_ATE == 0) || (uu <= 0)) 
                        {
                            $('#BtnAgenda').attr("disabled", true);
                            $('#BtnModificar').attr("disabled", false);
                            $('#BtnNoAsistio').attr("disabled", false);
                            $('#BtnAtendido').attr("disabled", false);
                        } else {
                            $('#BtnAgenda').attr("onclick", `Ajax_Agendar("` + ID + `")`);
                            $('#BtnAgenda').attr("disabled", false);
                            $('#BtnModificar').attr("disabled", false);
                            $('#BtnNoAsistio').attr("disabled", false);
                            $('#BtnAtendido').attr("disabled", false);
                        }
                        ajax_cant_exa(ID);


                    } else {


                        var uu = 0;
                        uu = CONF_DIAS_EXA_BUSCA_DIAS - TOTAL_ATE;
                        if (TOTAL_ATE == 0) {
                            $('#BtnAgenda').attr("onclick", `Ajax_Agendar("` + ID + `")`);
                            $('#BtnAgenda').attr("disabled", false);
                            $('#BtnModificar').attr("disabled", true);
                            $('#BtnNoAsistio').attr("disabled", true);
                            $('#BtnAtendido').attr("disabled", true);
                        } else {
                            $('#BtnAgenda').attr("disabled", true);
                            $('#BtnModificar').attr("disabled", true);
                            $('#BtnNoAsistio').attr("disabled", true);
                            $('#BtnAtendido').attr("disabled", true);
                        }
                        if ((TOTAL_ATE == 0) && (CONF_DIAS_EXA_BUSCA_DIAS == 0)) {
                            $('#BtnAgenda').attr("disabled", true);
                            $('#BtnModificar').attr("disabled", true);
                            $('#BtnNoAsistio').attr("disabled", true);
                            $('#BtnAtendido').attr("disabled", true);
                        }
                        $("#Paciente").text(0);
                        $("#ESPERA").text(0);
                        $("#ATEN").text(0);
                        $("#Examen").text(0);
                        $("#Div_Tabla2").append(
                        ("<div class='alert alert-danger alertas'><strong>Sin Resultados</strong>  </div>")
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
        //pasar datos a BTNS de colores

        function Ajax_Datos_BTNS(ID_PREINGRESO, PREI_NUM, ID_PACIENTE, ID_ATENCION) {
            ////$("#BtnModificar").attr({
            ////    "data-ID_PREINGRESO": ID_PREINGRESO
            ////});
            ////$("#BtnNoAsistio")
            $("#BtnAtendido").attr("onClick", `Ajax_Datos_Atendido("` + ID_PREINGRESO + `","` + PREI_NUM + `","` + ID_PACIENTE + `","` + ID_ATENCION + `")`);
        }
        var Mx_AGH = [
             {
                 "ID_Atencion": 0,
                 "Correlativo": 0
             }
        ];
        function Ajax_Datos_Atendido(PREINGRESO, NUM, PACIENTE, ATENCION)
        {
        if(ATENCION == 0){
            modal_show();
                var Data_Par = JSON.stringify({
                    "PREINGRESO": PREINGRESO,
                    "NUM": NUM,
                    "ID_PACIENTE": PACIENTE
                });
                $.ajax({
                    "type": "POST",
                    "url": "Ver_Disponibilidad.aspx/grabar_atencion",
                    "data": Data_Par,
                    "contentType": "application/json;  charset=utf-8",
                    "dataType": "json",
                    "success": function (response) {
                        var json_receiver = response.d;
                        if (json_receiver != "null") {
                            Mx_AGH = JSON.parse(json_receiver);

                            Ajax_N_PACIENTE(idx, dias, total);
                            var str_Error = "Nº de Atención: " + Mx_AGH.Correlativo + "\n ¿Desea imprimir voucher?"
                            $("#title2").text("Pre- Ingreso realizado");
                            $("#button_modal_pago").click(function () {
                                var dataParam = JSON.stringify([
                                    Mx_AGH.Correlativo
                                ]);
                                var datita = JSON.stringify([
                                    Mx_AGH.ID_Atencion
                                ]);

                                var REE = $.ajax({
                                    "type": "POST",
                                     "url": "http://localhost:9990/Printer/Imp_Etiquetas",
                                    //"url": "http://localhost:9990/Printer/Imp_Voucher_Agendam",
                                    "data": dataParam,
                                    "contentType": "application/json;  charset=utf-8",
                                    "contentType": "text/plain;  charset=utf-8",
                                    "dataType": "json",
                                    "timeout": 15000,
                                    "success": function (response) {


                                        var str_Error = "La impresión se ha completado exitosamente"
                                        $("#title").text("Solicitud de voucher");
                                        $("#button_modal").attr("class", "btn btn-success");
                                        $("#mError_AAH p").text(str_Error);
                                        $("#mError_AAH").modal();
                                    },
                                    "error": function (response) {

                                    }
                                });

                                var REE = $.ajax({
                                    "type": "POST",
                                    //"url": "http://localhost:9990/Printer/Imp_Etiquetas",
                                    "url": "http://localhost:9990/Printer/Imp_Voucher_Agendam",
                                    "data": datita,
                                    "contentType": "application/json;  charset=utf-8",
                                    "contentType": "text/plain;  charset=utf-8",
                                    "dataType": "json",
                                    "timeout": 15000,
                                    "success": function (response) {


                                    },
                                    "error": function (response) {

                                        //var str_Error = "No se a detectado ninguna interface de impresión abierta. Abra IRISLAB_PRINT" // o de lo contrario descargelo AQUI
                                        //$("#title").text("Solicitud de voucher");
                                        //$("#button_modal").attr("class", "btn btn-success");
                                        //$("#mError_AAH p").text(str_Error);
                                        //$("#mError_AAH").modal();
                                    }
                                });
                            });
                            $("#MOdal_PAGO p").text(str_Error);
                            $("#MOdal_PAGO").modal();
                            Hide_Modal();
                        } else {

                        }
                    },
                    "error": function (response) {
                        var str_Error = response.responseJSON.ExceptionType + "\n \n";
                        str_Error = response.responseJSON.Message;
                        alert(str_Error);

                    }
                });
        } else {
            Hide_Modal();
            var str_Error = "El paciente ya fue atendido" ;
            $("#title").text("ERROR");
            $("#button_modal").attr("class", "btn btn-success");
            $("#mError_AAH p").text(str_Error);
            $("#mError_AAH").modal();
        }
            }
        // modal de botones
        function Ajax_Agendar(NUM) {
            $('#Manual').attr("onclick", "window.location.href='/Agenda_Med/IN_PAC_MAN.aspx?kl=" + NUM + "&FF=" + $("#fecha").val() + "'");
            $('#AVIS').attr("onclick", "window.location.href='/Agenda_Med/IN_PAC_AVIS.aspx?kl=" + NUM + "&FF=" + $("#fecha").val() + "'");
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
                    "PAC_RUT": 0
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
                    "url": "Ver_Disponibilidad.aspx/MODAL_PAC",
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
            var Mx_Dtt3 = [
          {
              "PROC_CANT_EXA_BUSCA_DIAS": 0,
              "CONF_DIAS_FECHA_BUSCA_DIAS": 0,
              "CONF_DIAS_EXA_BUSCA_DIAS": 0,
              "ID_ESTADO_BUSCA_DIAS ": 0,
              "ID_PROCEDENCIA_BUSCA_DIAS": 0,
              "ID_CONF_DIAS_BUSCA_DIAS": 0
          }
            ];
            function ajax_cant_exa(ID) {

                var Data_Par = JSON.stringify({
                    "ID": ID,
                    "fecha": $("#fecha").val()
                });
                $.ajax({
                    "type": "POST",
                    "url": "Ver_Disponibilidad.aspx/examenes",
                    "data": Data_Par,
                    "contentType": "application/json;  charset=utf-8",
                    "dataType": "json",
                    "success": function (response) {
                        var json_receiver = response.d;
                        if (json_receiver != "null") {
                            Mx_Dtt3 = JSON.parse(json_receiver);
                            Fill_examen();

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
                    $("<th>", {
                        "align": "center",
                        "class": "textoReducido ancho-columna"
                    }).text("Nº"),
                    $("<th>", {
                        "align": "center",
                        "class": "textoReducido ancho-columna"
                    }).text("Descripcion"),
                    $("<th>", {
                        "align": "center",
                        "class": "textoReducido ancho-columna"
                    }).text("Máximo"),
                    $("<th>", {
                        "align": "center",
                        "class": "textoReducido ancho-columna"
                    }).text("Agendado"),
                    $("<th>", {
                        "align": "center",
                        "class": "textoReducido ancho-columna"
                    }).text("Disponible")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_N_PACIENTE("` + Mx_Dtt[i].ID_PROCEDENCIA + `","` + Mx_Dtt[i].CONF_DIAS_EXA_BUSCA_DIAS + `","` + Mx_Dtt[i].TOTAL_ATE + `")`,
                        "class": "textoReducido manito"
                    }).append(
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido ancho-columna"
                        }).text(i + 1),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido ancho-columna"
                        }).text(Mx_Dtt[i].PROC_DESC),
                        $("<td>", {
                            "align": "right",
                            "class": "textoReducido ancho-columna"
                        }).text(Mx_Dtt[i].CONF_DIAS_EXA_BUSCA_DIAS),
                        $("<td>", {
                            "align": "right",
                            "class": "textoReducido ancho-columna"
                        }).text(Mx_Dtt[i].TOTAL_ATE),
                        $("<td>", {
                            "align": "right",
                            "class": "textoReducido ancho-columna"
                        }).text(function () {
                            var resu = 0;
                            resu = Mx_Dtt[i].CONF_DIAS_EXA_BUSCA_DIAS - Mx_Dtt[i].TOTAL_ATE;
                            if (resu < 0) {
                                resu = 0;
                            }
                            return resu;
                        })
                    )
                )
            }
            //ON CLICK CLASS TOGGLE   
            $('#DataTable').on('click', 'tr', function () {
                $("#DataTable tbody tr").removeClass("active");
                $(this).toggleClass("active");
            });
            
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
            $("#DataTable_pac").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_pac thead").attr("class", "cabzera");
            $("#DataTable_pac thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Nº"),
                    $("<th>", { "class": "textoReducido" }).text("Agendado"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Estado"),
                    $("<th>", { "class": "textoReducido" }).text("")
                )
            );
            var pac = 0;
            var espera = 0;
            var aten = 0;
            for (i = 0; i < Mx_Dtt2.length; i++) {
                $("#DataTable_pac tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Datos_BTNS("` + Mx_Dtt2[i].ID_PREINGRESO + `","` + Mx_Dtt2[i].PREI_NUM + `","` + Mx_Dtt2[i].ID_PACIENTE + `","` + Mx_Dtt2[i].ID_ATENCION + `")`,
                        "class": "textoReducido manito",
                        "padding": "1px !important",
                    }).append(
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).text(i + 1),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
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
                       }).text(Mx_Dtt2[i].EST_DESCRIPCION),
                        $("<td>", {
                            "align": "center",
                            "class": "textoReducido"
                        }).html(`<button type='button' class='btn btn-succes btn-xs borrar' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;' onclick='Ajax_modal_exa("` + Mx_Dtt2[i].ID_PREINGRESO + `")'><i class="fa fa-info-circle" aria-hidden="true"></i></button>`)
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
            //ON CLICK CLASS TOGGLE   
            $('#DataTable_pac').on('click', 'tr', function () {
                $("#DataTable_pac tbody tr").removeClass("active");
                $(this).toggleClass("active");
            });

            $("#Paciente").text(pac);
            $("#ESPERA").text(espera);
            $("#ATEN").text(aten);
        }
        function Fill_examen() {
            $("#Examen").text(Mx_Dtt3[0].PROC_CANT_EXA_BUSCA_DIAS);
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
            $("#rut").val(Mx_Detalle_ate.proparra1[0].PAC_RUT)
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
            $("#DataTable_pac2 thead").attr("class", "cabzera");
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
            $("#cantidad").text("Cantidad de Exámenes: " + cantidad)
        }
    </script>
    <style>
        /*CLASS ACTIVE*/
        table tr.active, table tr.active > td {
            background: #17a2b8 !important;
            background-color: #17a2b8 !important;
            color: white;
        }
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
        .borderaaa{
            padding: .3rem;
            text-align: center;
            
        }
        .highlights {
            width: 710px;
            max-height: 390px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/         
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
        .form-control:disabled{
                background-color: #ffffff !important;
                cursor: default !important;
            }
        .textbotLeft {
            display: block;
            height: 28px;
            width: 100%;
        }
        .cabzera {
            background: #46963f;
            color: white;
        }
        .espera {
            background: #c7ff00;
        }
        .atendido {
            background: #1fc12c;
            color: white;
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
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">
                      <button type="button" id="b" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                     <button type="button" id="button_modal_pago" class="btn btn-success" data-dismiss="modal">Imprimir</button>
                </div>
            </div>
        </div>
    </div>
    <%--Modal Agendar--%>
    <div class="modal fade" id="eModal" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
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
                            <button type="button" id="Manual" class="btn btn-info" style="height: 120px; width: 75%;">PACIENTE MANUAL</button>
                        </div>
                        <div class="col-md-6" style="text-align: center;">
                            <button type="button" id="AVIS" class="btn btn-info" style="height: 120px; width: 75%;">PACIENTE AVIS</button>
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
            <div class="modal-content">
                <div class="modal-header">
                    <div class="col-md-12" style="text-align:center;">
                    <h4 class="modal-title card-title" id="xxxxxx">Antecedentes de Agendamiento</h4>
                    </div>   
                </div>                         
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                         <div class="row">
                                <div class="col-sm-2">
                                    <label class="textoReducido2">RUT:</label>                                  
                                    <input type='text' id="rut" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled"/>                                  
                                </div>
                                <div class="col-sm-3">
                                    <label class="textoReducido2">Nombre:</label>                                  
                                    <input type='text' id="NOMBRE" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled"/>   
                                </div>
                                <div class="col-sm-2">
                                    <label class="textoReducido2">N°Atención:</label>                                   
                                     <input type='text' id="ATENe" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled"/>
                               </div>
                               <div class="col-sm-2">
                                    <label class="textoReducido2">F.Nacimiento:</label>                                  
                                    <input type='text' id="FNAC" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled"/>                                  
                                </div>
                                <div class="col-sm-1">
                                    <label class="textoReducido2">Edad:</label>                                  
                                    <input type='text' id="Edad" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled"/>   
                                </div>
                                <div class="col-sm-2">
                                    <label class="textoReducido2">Sexo:</label>                                   
                                     <input type='text' id="Sex" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled"/>
                               </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2">
                                    <label for="checkBox2" class="textoReducido2">F.U.R:</label>                                    
                                    <input type='text' id="FUR" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                </div>
                                <div class="col-sm-2">
                                    <label class="textoReducido2">Nacionalidad:</label>                                 
                                    <input type='text' id="Nacio" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled" />
                                </div>
                                <div class="col-sm-2">
                                    <label class="textoReducido2">Tel. Fijo:</label>                                  
                                    <input type='text' id="Telfijo" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled"/>
                                </div>
                                <div class="col-sm-2">
                                    <label class="textoReducido2">Celular:</label>                                  
                                    <input type='text' id="Celular" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled"/>
                                </div>
                                <div class="col-sm-2">
                                    <label class="textoReducido2">Ciudad:</label>
                                    <input type='text' id="Ciudad" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled"/>
                                </div>
                                <div class="col-sm-2">
                                    <label class="textoReducido2">Comuna:</label>                                  
                                    <input type='text' id="Comuna" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled"/>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 10px;">
                                <div class="col-sm">
                                    <label class="textoReducido2">Dirección:</label>
                                    <input type='text' id="Direc" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled"/>
                                </div>
                                <div class="col-sm">
                                    <label class="textoReducido2">Email:</label>
                                    <input type='text' id="Email" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled"/>
                                </div>
                                <div class="col-sm">
                                    <label class="textoReducido2">Observaciones Permanentes del paciente:</label>                                 
                                    <input type='text' id="PerPAc" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled"/>
                                </div>
                            </div>
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
                                    <input type='text' id="Prev" readonly="true" class="form-control textoReducido2 borderaaa" disabled="disabled"/>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 10px;">
                                <div class="col-sm-12" style="text-align:center;">
                                    <h5 class="card-title">Listado de exámenes</h5>  
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 10px;">
                                <div class="col-sm">
                                    <div id="Div_Tabla3" style="width: 100%;" class="highlights3"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
         <div class="modal-footer">
             <label class="textoReducido2" id="cantidad"></label>
            <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
        </div>
            </div>
        </div>
    </div>



    <!-- Breadcrumbs -->
    <div class="row">
        <div class="col-md-12">
            <h5 style="text-align: center; padding: 5px;">
                <i class="fa fa-bookmark-o"></i>
                Ver Disponibilidad
            </h5>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-12">
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
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div id="Div_Tabla" style="width: 100%;" class="highlights">
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div id="Div_Tabla2" style="width: 100%;" class="highlights2">
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-6">
                    <p style="font-size: 13px;" class="textbot"><strong>Antecedentes de Agendamiento</strong></p>
                    <div class="row">
                        <div class="col-6 textbot">
                            <p style="font-size: 12px; color: cornflowerblue;"><strong>N° de Paciente</strong></p>
                        </div>
                        <div class="col-6 textbot">
                            <p id="Paciente" style="font-size: 12px; color: red;">0</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6 textbot">
                            <p style="font-size: 12px; color: cornflowerblue;"><strong>N° de Exámenes</strong></p>
                        </div>
                        <div class="col-6 textbot">
                            <p id="Examen" style="font-size: 12px; color: forestgreen;">0</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-6 textbotLeft">
                            <p style="font-size: 12px; color: indianred;"><strong>N° de Atendidos</strong></p>
                        </div>
                        <div class="col-6 textbotLeft">
                            <p id="ATEN" style="font-size: 12px; color: red;">0</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6 textbotLeft">
                            <p style="font-size: 12px; color: indianred;"><strong>N° de No Asistio</strong></p>
                        </div>
                        <div class="col-6 textbotLeft">
                            <p style="font-size: 12px; color: forestgreen;">0</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6 textbotLeft">
                            <p style="font-size: 12px; color: indianred;"><strong>N° En Espera</strong></p>
                        </div>
                        <div class="col-6 textbotLeft">
                            <p id="ESPERA" style="font-size: 12px; color: forestgreen;">0</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6 boo">
            <div class="row">
                <div class="col-lg-3 boo2">
                    <button id="BtnAgenda" type="button" class="btn btn-warning topbuttom mb-3">
                        <i class="fa fa-pencil-square-o" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                        <p style="margin-top: 2px;">Agendar</p>
                    </button>
                </div>
                <div class="col-lg-3 boo2">
                    <button id="BtnModificar" type="button" class="btn btn-info topbuttom mb-3">
                        <i class="fa fa-exchange" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                        <p style="margin-top: 2px;">Modificar</p>
                    </button>
                </div>
                <div class="col-lg-3 boo2">
                    <button id="BtnNoAsistio" type="button" class="btn btn-danger topbuttom mb-3">
                        <i class="fa fa-ban" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                        <p style="margin-top: 2px;">No Asistio</p>
                    </button>
                </div>
                <div class="col-lg-3 boo2">
                    <button id="BtnAtendido" type="button" class="btn btn-success topbuttom mb-3">
                        <i class="fa fa-check-circle-o" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                        <p style="margin-top: 2px;">Atendido</p>
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
