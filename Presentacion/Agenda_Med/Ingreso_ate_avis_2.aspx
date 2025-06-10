<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Ingreso_ate_avis_2.aspx.vb" Inherits="Presentacion.Ingreso_ate_avis_2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="../js/Deep-Copy.js"></script>
    <%-- Colocar esto para forzar el evento load --%>



    <%@ OutputCache Location="None" NoStore="true" %>
    <script>
        let kmmjk = {
            suma: 0,
            callbuck: function () {
                if(this.suma >= 9){
                    this.suma = 0;
                    Ajax_modal_exa();

                } else {
                    this.suma++;
                }
            }
        };

        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }

        var xId = 0;
        var selected = new Array();
        var verrut = 0;
        var ids = new Array();
        var sifi = 0;1
        var MX_HO_ExamenCodigo = new Array();
        var agregar_folio = 0;
        var omi_save = 0;
        //Class AJAX
        let Class_AJAX = function () {
            this.url = "";
            this.success = () => { };
            this.error = () => { };
        };

        Class_AJAX.prototype.callback = function (data) {
            $.ajax({
                "type": "POST",
                "url": this.url,
                "data": JSON.stringify(data),
                "contentType": "application/json;  charset=utf-8",
                "contentType": "text/plain;  charset=utf-8",
                "dataType": "json",
                "timeout": 20000,
                "success": this.success,
                "error": this.error
            });
        };
        let timer = 4000;
        let objAJAX_Voucher = new Class_AJAX();
        objAJAX_Voucher.url = "http://localhost:9990/Printer/Imp_Voucher_Compr_Ate";
        objAJAX_Voucher.success = (resp) => {
            console.log(`[ OK ] Impresión Voucher Atención`);
            console.log(resp);
            console.log(``);

            setTimeout(() => {
                objAJAX_Etiq.callback([
                     Mx_Dt023.ID_Atencion
                ]);
            }, timer);

        };
        objAJAX_Voucher.error = (fail) => {
            console.log(`[ERROR] Impresión Voucher Atención`);
            console.log(fail);
            console.log(``);

            setTimeout(() => {
                objAJAX_Etiq.callback([
                       Mx_Dt023.ID_Atencion
                ]);
            }, timer);
        };

        let objAJAX_Etiq = new Class_AJAX();
        objAJAX_Etiq.url = "http://localhost:9990/Printer/Imp_Etiquetas";
        objAJAX_Etiq.success = (resp) => {
            console.log(`[ OK ] Impresión Etiquetas`);
            console.log(resp);
            console.log(``);

            setTimeout(() => {
                objAJAX_LugarTM.callback([
                      Mx_Dt023.ID_Atencion
                ]);
            }, timer);

        };
        objAJAX_Etiq.error = (fail) => {
            console.log(`[ERROR] Impresión Etiquetas`);
            console.log(fail);
            console.log(``);

            setTimeout(() => {
                objAJAX_LugarTM.callback([
                       Mx_Dt023.ID_Atencion
                ]);
            }, timer);
        };

        let objAJAX_LugarTM = new Class_AJAX();
        objAJAX_LugarTM.url = "http://localhost:9990/Printer/Imp_Voucher_Lugar_TM";
        objAJAX_LugarTM.success = (resp) => {
            console.log(`[ OK ] Voucher LugarTM`);
            console.log(resp);
            console.log(``);

            var str_Error = "La impresión se ha completado exitosamente"
            $("#title").text("Solicitud de voucher");
            $("#button_modal").attr("class", "btn btn-success");

            $("#button_modal").off('click');
            $("#button_modal").click(() => {
                var loc = location.origin;
                window.location.href = loc + "/Agenda_Med/Lis_Pac_TDM.aspx";
            });
             
            $("#mError_AAH p").text(str_Error);
            $("#mError_AAH").modal();

        };
        objAJAX_LugarTM.error = (fail) => {
            console.log(`[ERROR] Impresión Etiquetas`);
            console.log(fail);
            console.log(``);

        };

        $(document).ready(function () {
            var admin2 = Galletas.getGalleta("P_ADMIN");
            if (admin2 == 1) {
                $("#Examen").removeAttr('disabled');
            } else {
  
                $('#Examen').attr("disabled", true);
            }
          
            if ($('#XXXXXXXX').length) {
                var scrollTrigger = 100, // px
                    backToTop = function () {
                        var scrollTop = $(window).scrollTop();
                        if (scrollTop > scrollTrigger && $("#Nom").val() != "") {

                            $("#xxx_xxx").text("Rut: " + $("#rut").val() + " Nombre: " + $("#Nom").val() + " " + $("#Ape").val() + " Edad: " + $("#Edad").val() + " Sexo: " + $("#sex option:selected").text())
                            $('#XXXXXXXX').addClass('show');
                        } else {
                            $('#XXXXXXXX').removeClass('show');
                        }
                    };
                backToTop();
                $(window).on('scroll', function () {
                    backToTop();
                });
            }
       
            $("#button_modal2").click(function () {

                buscar_avis();

            });
            $('#eModal2 button').click((Me) => {
                $('#XXXXXXXX').removeClass('XCVB');
            });
            $('#eModal2').click((Me) => {
                if ($(Me.target).attr("id") == "eModal2") {
                    $('#XXXXXXXX').removeClass('XCVB');
                }
            });
            $('#eModal3 button').click((Me) => {
                $('#XXXXXXXX').removeClass('XCVB');
            });
            $('#eModal3').click((Me) => {
                if ($(Me.target).attr("id") == "eModal3") {
                    $('#XXXXXXXX').removeClass('XCVB');
                }
            });

            $("#button_modal_pago").click(function () {
                      
                    $('#eModales33').modal('hide');
                    objAJAX_Voucher.callback([
                           Mx_Dt023.ID_Atencion
                    ]);

            
            });
            $("#b").click(function () {
                var loc = location.origin;
                window.location.href = loc + "/Agenda_Med/Lis_Pac_TDM.aspx";

            });
            //$("#Div_Tabla").hide();
            //$("#X_SIN_RUT").click(function () {
            //    AJAX_SIN_RUT();
            //    $('#eModal_Sinrut').modal('show');
            //});
            $("#agregar_op").click(function () {   
                    buscar_omi_nuevo_folio();
            });
            $("#Procedencia").change(function () {

                Ajax_DataTable();
            });
            
   
          
            Ajax_Ciudad();
            Ajax_Diagnostico();
            Call_AJAX_Ddl();
            Ajax_DL_programa();

            Ajax_DL_sec();
            Ajax_DL_orden_ate();

            Ajax_DL_TP_ATE();


            Ajax_DataTable_examen0GObal();
            Ajax_DL_prevision();
          

            $("#checkBox2").prop('checked', false);//solo los del objeto
            $('#FUR').attr("disabled", true);
            $('#checkBox2').attr("disabled", true);
            $('#TipoAtencion').attr("disabled", true);
            $("#fur").css("pointer-events", "none");
            var f = moment().format("DD-MM-YYYY");
            $("#fecha").val(f);
            Ajax_modal_exa();
            //Ajax_DataTable();
            $("#FUR").val(f);
            /////-*-*-*-*-*-*-*-*-*-*-*-*-*
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
            $("#DataTable_pac2").attr("class", "table table-striped table-hover table-iris");
            $("#DataTable_pac2 thead").attr("class", "cabzera");
            $("#DataTable_pac2 thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Codigo Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("Descripcion"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Dias Proceso"),
                    $("<th>", { "class": "textoReducido" }).text(""),
                    $("<th>", { "class": "textoReducido" }).text("Cambio de Estado")
                )
            );
            add_row();
            //-*-*-*-*-*-*-*-*-*-*-*-*-*
            $("#Btnnew").click(function () {
                Ajax_DL_SEXO();
                Ajax_DL_NAC();
                Ajax_Ciudad();
                $("#checkBox2").prop('checked', false);
                $('#FUR').attr("disabled", true);
                $('#checkBox2').attr("disabled", true);
                $("#fur").css("pointer-events", "none");
                var f = moment().format("DD-MM-YYYY");
                $("#fecha").val(f);

                $("#FUR").val(f);
                $('#rut').removeAttr("disabled");
                $('#rut').val("");
                $("#Nom").val("");
                $("#Ape").val("");
                $("#Edad").val("");
                $("#telfijo").val("");
                $("#Celular").val("");
                $("#Email").val("");
                $("#direccion").val("");
                $("#Diag2").val("");
                $("#Diag").val("");
                $("#ddl_new_vih").val(0);
                $("#ddl_new_vih").css({ "border-color": "#ccc" });
                $("#ddl_new_vih").parent().css({ "color": "#212529" });
                $("#vih").val(0);
                $("#vih").css({ "border-color": "#ccc" });
                $("#vih").parent().css({ "color": "#212529" });
                Mx_Dtt_examcof.length = 0;
                Mx_examenes_avis.length = 0;
                $("#DataTable_pac2 tbody").empty();
                add_row();
                verrut = 0;
                Mx_Dtt2.length = 0;
                var str_Error = "Campos listo para el ingreso del nuevo paciente: "
                $("#title").text("Nuevo Paciente");
                $("#button_modal").attr("class", "btn btn-success");
                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();
            });
            $("#fecha").change(function () {
                var asd = $("#fecha").val();
                var array = asd.split("-");
                var total = "";
                var dia = array[0];
                var mes = array[1];
                var ano = array[2];
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
                if (ahora_mes > mes)
                    meses = ahora_mes - mes;
                if (ahora_mes < mes)
                    meses = 12 - (mes - ahora_mes);
                if (ahora_mes == mes && dia > ahora_dia)
                    meses = 11;
                // calculamos los dias
                var dias = 0;
                total = String(edad + " Años");
                if (ahora_dia > dia) {
                    dias = ahora_dia - dia;
                    total = String(edad + " Años");
                }
                if (ahora_dia < dia) {
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                    total = String(edad + " Años");
                }
                $("#Edad").val(total);

            });
            $("#sex").change(function () {
                var sex = $("#sex option:selected").text();
                if (sex == "Femenino") {
                    $('#checkBox2').removeAttr("disabled");
                    var HXH = 0;
                    for (x = 0; x < Mx_Dtt_examcof.length; x++) {
                        if (Mx_Dtt_examcof[x].ID_CODIGO_FONASA == 1054) {
                            HXH = 1;
                        }
                    }
                    if (HXH == 1 && $("#sex").val() == 2 && sifi == 0) {
                        var str_Error = "Por favor Rellenar el campo F.U.R"
                        $("#title").text("Recordatorio");
                        $("#button_modal").attr("class", "btn btn-success");

                        $("#mError_AAH p").text(str_Error);
                        $("#mError_AAH").modal();
                        sifi = 1;
                    }
                } else {

                    $('#checkBox2').attr("disabled", true);
                    $("#checkBox2").prop('checked', false);//solo los del objeto #diasHabilitados
                    $('#FUR').attr("disabled", true);
                    $("#fur").css("pointer-events", "none");
                    $("#FUR").val(f);
                }

                if (Mx_Dtt_exam02_respaldo.length > 0) {
                    if ($("#sex").val() == 2) {

                        var xxxer = false;
                        for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                            //for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                            if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 66) {
                                Mx_Dtt_examcof.splice(z, 1);
                                xxxer = true;
                            }
                            //}
                        }
                        if (xxxer == true) {
                            for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                                if (Mx_Dtt_exam02_respaldo[x].ID_CODIGO_FONASA == 1026) {
                                    Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02_respaldo[x]));
                                    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                                }
                            }
                            fill_llenado_tabla()
                        }

                    }
                    if ($("#sex").val() == 1) {

                        var xxxer = false;
                        for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                            //for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                            if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1026) {
                                Mx_Dtt_examcof.splice(z, 1);
                                xxxer = true;
                            }
                            //}
                        }
                        if (xxxer == true) {
                            for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                                if (Mx_Dtt_exam02_respaldo[x].ID_CODIGO_FONASA == 66) {
                                    Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02_respaldo[x]));
                                    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                                }
                            }
                            fill_llenado_tabla()
                        }

                    }
                    if ($("#sex").val() == 0) {

                        var xxxer = false;
                        for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                            //for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                            if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1026 || Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 66) {
                                Mx_Dtt_examcof.splice(z, 1);
                                xxxer = true;
                            }
                            fill_llenado_tabla();
                            //}
                        }
                    }
                }

            });
            $("#checkBox2").change(function () {
                if ($(this).is(':checked')) {
                    $("#FUR").removeAttr('disabled');
                    $("#fur").css("pointer-events", "auto");
                } else {
                    $('#FUR').attr("disabled", true);
                    $("#fur").css("pointer-events", "none");
                    $("#FUR").val(f);
                }
            });
            $("#rut").keydown(function EnterEvent(e) {
                if (e.keyCode == 13) {
                    if ($("#rut").val() != "") {
                        //Capturar Anáqlisis del RUT
                        var obj_RUT = Valid_RUT($("#rut").val());
                        if (obj_RUT.Valid == false) {
                            var str_Error = "El RUT ingresado no es Válido, ";
                            str_Error += "ingrese en el campo de texto un RUT válido.";

                            $("#mError_AAH h5").text("Error:");
                            $("#button_modal").attr("class", "btn btn-danger");

                            $("#mError_AAH p").text(str_Error);
                            $("#mError_AAH").modal();

                            $("#rut").val("");
                            $("#rut").css({
                                "border-color": "red"
                            });
                        } else {
                            $("#rut").css({
                                "border-color": "green"
                            });
                            $("#rut").val(obj_RUT.Format);
                            //Ajax_busca_rut();
                        }
                    }
                }
            });

            $("#Avis").keydown(function EnterEvent(e) {
                if (e.keyCode == 13) {

                    if (Mx_Dtt_examcof.length == 0) {
                        buscar_avis();
                    } else {
                        $("#mError_AAH2").modal('hide');
                        var str_Error = "¿Estimado usurario desea borrar datos actuales y buscar datos nuevo con el N° AVIS ingresado?";
                        $("#title8").text("Borrar datos actuales");
                        $("#mError_AAH2 p").text(str_Error);
                        $("#mError_AAH2").modal();

                    }

                }
            });
            $("#Prevision").change(function () {
        
                Ajax_DataTable_examen02();

            });



       

            $("#BtnSaveAll").click(function () {
                var sum = 0;
                var actuuu = 0;
                var actuuu2 = 0;

                if ($("#Nom").val() == "") {

                    $("#Nom").css({
                        "border-color": "red"
                    });

                    $("#Nom").css({
                        "border-width": "3px"
                    });

                    $("#Nom").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Nom").css({
                        "border-color": "#ccc"
                    });

                    $("#Nom").css({
                        "border-width": "1px"
                    });

                    $("#Nom").parent().css({
                        "color": "#212529"
                    });
                }

                if ($("#interno").val() == "") {

                    $("#interno").css({
                        "border-color": "red"
                    });

                    $("#interno").css({
                        "border-width": "3px"
                    });

                    $("#interno").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#interno").css({
                        "border-color": "#ccc"
                    });
                    $("#interno").parent().css({
                        "color": "#212529"
                    });
                    $("#interno").css({
                        "border-width": "1px"
                    });
                }


                if ($("#Ape").val() == "") {

                    $("#Ape").css({
                        "border-color": "red"
                    });

                    $("#Ape").css({
                        "border-width": "3px"
                    });

                    $("#Ape").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Ape").css({
                        "border-color": "#ccc"
                    });

                    $("#Ape").css({
                        "border-width": "1px"
                    });

                    $("#Ape").parent().css({
                        "color": "#212529"
                    });
                }

                if ($("#Edad").val() == "") {

                    $("#fecha").css({
                        "border-color": "red"
                    });
                    $("#fecha").parent().parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#fecha").css({
                        "border-color": "#ccc"
                    });
                    $("#fecha").parent().parent().css({
                        "color": "#212529"
                    });
                }

                if ($("#sex").val() == 0) {

                    $("#sex").css({
                        "border-color": "red"
                    });

                    $("#sex").css({
                        "border-width": "3px"
                    });

                    $("#sex").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#sex").css({
                        "border-color": "#ccc"
                    });

                    $("#sex").css({
                        "border-width": "1px"
                    });

                    $("#sex").parent().css({
                        "color": "#212529"
                    });
                }

                if ($("#Nacio").val() == 0) {

                    $("#Nacio").css({
                        "border-color": "red"
                    });

                    $("#Nacio").css({
                        "border-width": "3px"
                    });

                    $("#Nacio").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Nacio").css({
                        "border-color": "#ccc"
                    });

                    $("#Nacio").css({
                        "border-width": "1px"
                    });

                    $("#Nacio").parent().css({
                        "color": "#212529"
                    });
                }
                if ($("#Cuidad").val() == 0) {

                    $("#Cuidad").css({
                        "border-color": "red"
                    });
                    $("#Cuidad").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Cuidad").css({
                        "border-color": "#ccc"
                    });
                    $("#Cuidad").parent().css({
                        "color": "#212529"
                    });
                }
                if ($("#Comuna").val() == 0) {

                    $("#Comuna").css({
                        "border-color": "red"
                    });
                    $("#Comuna").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Comuna").css({
                        "border-color": "#ccc"
                    });
                    $("#Comuna").parent().css({
                        "color": "#212529"
                    });
                }



                if ($("#sub_atencion").val() == 0) {

                    $("#sub_atencion").css({
                        "border-color": "red"
                    });

                    $("#sub_atencion").css({
                        "border-width": "3px"
                    });

                    $("#sub_atencion").parent().css({
                        "color": "red"
                    });
                } else {
                    if ($("#sub_atencion").val() == 1) {
                        if ($("#Total").val() == 0) {
                            $("#sub_atencion").css({
                                "border-color": "red"
                            });
                            $("#sub_atencion").parent().css({
                                "color": "red"
                            });
                        } else {
                            sum += 1;
                            $("#sub_atencion").css({
                                "border-color": "#ccc"
                            });

                            $("#sub_atencion").css({
                                "border-width": "1px"
                            });

                            $("#sub_atencion").parent().css({
                                "color": "#212529"
                            });
                        }
                    }
                    if ($("#sub_atencion").val() == 2) {
                        if ($("#Actuales").val() == 0) {
                            $("#sub_atencion").css({
                                "border-color": "red"
                            });
                            $("#sub_atencion").parent().css({
                                "color": "red"
                            });
                        } else {
                            sum += 1;
                            $("#sub_atencion").css({
                                "border-color": "#ccc"
                            });

                            $("#sub_atencion").css({
                                "border-width": "1px"
                            });

                            $("#sub_atencion").parent().css({
                                "color": "#212529"
                            });
                        }



                    }
                    if ($("#sub_atencion").val() == 3) {

                        if ($("#Disponibles").val() == 0) {
                            $("#sub_atencion").css({
                                "border-color": "red"
                            });
                            $("#sub_atencion").parent().css({
                                "color": "red"
                            });
                        } else {
                            sum += 1;
                            $("#sub_atencion").css({
                                "border-color": "#ccc"
                            });

                            $("#sub_atencion").css({
                                "border-width": "1px"
                            });

                            $("#sub_atencion").parent().css({
                                "color": "#212529"
                            });
                        }
                    }
                    if ($("#sub_atencion").val() == 4) {

  
                            sum += 1;
                            $("#sub_atencion").css({
                                "border-color": "#ccc"
                            });
                            $("#sub_atencion").parent().css({
                                "color": "#212529"
                            });
                    }
                
                if ($("#sub_atencion").val() == 5) {


                    sum += 1;
                    $("#sub_atencion").css({
                        "border-color": "#ccc"
                    });
                    $("#sub_atencion").parent().css({
                        "color": "#212529"
                    });
                }
                    }
                

                for (xxx = 0; xxx < Mx_Dtt_examcof.length; xxx++) {
                    console.log("oa");
                    //IF RPR, MHTP, VDRL o VIH
                    if (Mx_Dtt_examcof[xxx].ID_CODIGO_FONASA == 1021 || Mx_Dtt_examcof[xxx].ID_CODIGO_FONASA == 315 || Mx_Dtt_examcof[xxx].ID_CODIGO_FONASA == 453) {
                        actuuu = 1;
                    }
                    //VIH
                    if (Mx_Dtt_examcof[xxx].ID_CODIGO_FONASA == 364) {
                        actuuu2 = 1;
                    }
                }
                console.log("actuuu: " + actuuu);
                if (actuuu2 == 1) {
                    if ($("#ddl_new_vih").val() == 0) {
                        console.log("deberia ponerse rojo new !");

                        $("#ddl_new_vih").css({
                            "border-color": "red"
                        });
                        $("#ddl_new_vih").parent().css({
                            "color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#ddl_new_vih").css({
                            "border-color": "#ccc"
                        });
                        $("#ddl_new_vih").parent().css({
                            "color": "#212529"
                        });
                    }
                }
                else {
                    sum += 1;
                }

                if (actuuu == 1) {
                    if ($("#vih").val() == 0) {
                        console.log("deberia ponerse rojo sifilis!");
                        $("#vih").css({
                            "border-color": "red"
                        });
                        $("#vih").parent().css({
                            "color": "red"
                        });
                    } else {
                        sum += 1;
                        $("#vih").css({
                            "border-color": "#ccc"
                        });
                        $("#vih").parent().css({
                            "color": "#212529"
                        });
                    }
                } else {
                    sum += 1;
                }


                if (sum == 11) {

                    if ($("#rut").val() == "") {
                        verrut = 1;
                    }
                    Ajax_guardar();
                } else {
                    $("#mError_AAH").modal('hide');
                    var str_Error = "Por favor llenar los campos marcados con color rojo";
                    $("#title").text("Faltan campos por llenar");
                    $("#button_modal").attr("class", "btn btn-danger");

                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();

                    $('body, html').animate({
                        scrollTop: '0px'
                    }, 300);
                }
            });

          



            //-*-*-*-*-*-*-*-*-* TABLA DINAMICA -*-*-*-*-*-*-*-*-*-*-*
            $("#Examen").click(function () {
                Fill_DataTable_exam02();
                $('#eModal2').modal('show');
                $('#XXXXXXXX').addClass('XCVB');
            });
            ///llenado tabla con modal  a  atabla principal
            $("#btnguardar").click(function () {
                selected = new Array();
                $(".pp input:checkbox:checked").each(function () {
                    selected.push($(this).val());
                });
                for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                    for (x = 0; x < selected.length; x++) {
                        if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == selected[x]) {
                            selected.splice(x, 1);
                        }
                    }
                }
                for (i = 0; i < selected.length; i++) {
                    for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                        if (selected[i] == Mx_Dtt_exam02[x].ID_CODIGO_FONASA) {
                            Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02[x]));
                            Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                        }
                    }
                }

                fill_llenado_tabla();
                $('#eModal2').modal('hide');
            });
            $("#btnexarepetido").click(function () {
                selected = new Array();
                $(".sub_pp input:checkbox:checked").each(function () {
                    selected.push($(this).val());
                });
                for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                    for (x = 0; x < selected.length; x++) {
                        if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == selected[x]) {
                            selected.splice(x, 1);
                        }
                    }
                }
                for (i = 0; i < selected.length; i++) {
                    for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                        if (selected[i] == Mx_Dtt_exam02[x].ID_CODIGO_FONASA) {
                            Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02[x]));
                        }
                    }
                }
                if (xId != 0) {
                    for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                        if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == xId) {
                            Mx_Dtt_examcof.splice(z, 1);
                        }
                    }
                }
                fill_llenado_tabla();
                $('#eModal3').modal('hide');
            });
            $(document).on('click', '.borrar', function (event) {
                var rowstota = document.getElementById("DataTable_pac2").rows.length;
                var ff = $(this).parent().parent().children().children('.td_input').attr('data-id');
                event.preventDefault();
                if (rowstota > 2) {
                    for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                        if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == ff) {
                            Mx_Dtt_examcof.splice(i, 1);
                        }
                        $(this).closest('tr').remove();
                        for (x = 0; x < Mx_Dtt_examcof.length; x++) {
                            if (Mx_Dtt_examcof[x].ID_CODIGO_FONASA == 1054) {
                                sifi = 1;
                            } else {
                                sifi = 0;
                            }
                        }
                    }
                } else {
                    var str_Error = "El campo no puede ser eliminado"
                    $("#title").text("Eliminar Examen");
                    $("#button_modal").attr("class", "btn btn-danger");

                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();
                }


            });

            $(document).on('click', '.CEstado', function (event) {
                //var rowstota = document.getElementById("DataTable_pac2").rows.length;
                var ff = $(this).parent().parent().children().children('.td_input').attr('data-id');
                event.preventDefault();

                for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                    if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == ff) {

                        Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN = "Espera"

                    }
                }

                fill_llenado_tabla();

            });
            $(document).on('click', '.Activado', function (event) {
                //var rowstota = document.getElementById("DataTable_pac2").rows.length;
                var ff = $(this).parent().parent().children().children('.td_input').attr('data-id');
                event.preventDefault();

                for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                    if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == ff) {

                        Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN = "Activo"

                    }
                }

                fill_llenado_tabla();

            });
        });


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
                "DNI": 0,
                "id_Nacionalidad":0

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
                "ID_PER": 0,
                "ATE_NUM_AVIS": 0
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
                "VIH": "",
                "Sub_atencion":0
            }]
        }
        function Ajax_modal_exa() {

            var fffff = getParameterByName('ID_ATE');
            var Data_Par_modal = JSON.stringify({
                "ID": fffff
            });
            $.ajax({
                "type": "POST",
                "url": "Ingreso_ate_avis_2.aspx/MODAL_PAC",
                "data": Data_Par_modal,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": Data_Par_modal_paciente => {
                    //Debug
                    //console.log(Data_Par_modal_paciente);

                    Mx_Detalle_ate = Data_Par_modal_paciente.d;

                    //ENVIAMOS ID_ATEMCION AL MODAL



                    //LLAMAMOS AL FILL MODAL
                    llenarmodal();

                    // MOSTRAR EL MODAL
                    $('#eModales33').modal('show');
                },
                "error": Data_Par_modal_paciente => {

                    console.log(Data_Par_modal_paciente);

                }
            });
        }
        var MX_DTT_SIN_RUT = [
         {
             "HO_CC": 0,
             "HO_CP": 0,
             "HO_FechaAtencion": 0,
             "HO_RutPaciente": 0,
             "HO_Nombres": 0,
             "HO_ApellidoPaterno": 0,
             "HO_ApellidoMaterno": 0,
             "HO_EstadoProceso": 0,
             "IRIS_H_ESTADO": 0
         }
        ];
        function AJAX_SIN_RUT() {
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS_2.aspx/AJAX_SIN_RUT",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        MX_DTT_SIN_RUT = JSON.parse(json_receiver);
                        FILL_SIN_RUT();

                    } else {


                    }
                },
                "error": function (response) {

                    console.log(response);



                }
            });
        }
        var Mx_Dtt_4556 = [
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
            "ID_CONF_DIAS_BUSCA_DIAS": 0,


            "AGEND_CUPO_NORMAL": 0,
            "AGEND_PRIORITARIO": 0,
            "AGEND_ESPONTANEO": 0,
            "TOTAL_AGEND_CUPO_NORMAL ": 0,
            "TOTAL_AGEND_PRIORITARIO": 0,
            "TOTAL_AGEND_ESPONTANEO": 0
        }
        ];

        function Ajax_DataTable() {




            var Data_Par = JSON.stringify({
                "fecha": "ssssss",
                "id": $("#Procedencia").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_4556 = JSON.parse(json_receiver);
                        Fill_DataTable();




                    } else {


                        Hide_Modal();

                        //$("#EM2 h5").text("Error:");
                        //$("#button_modal").attr("class", "btn btn-danger");
                        //$("#EM2 p").text("Sin resultados");
                        //$("#EM2").modal();
                    }
                    //$("#Id_Conte").show();
                    //$(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
    </script>
    <script>
        function FILL_SIN_RUT() {
            $("#Div_Tabla45").empty();
            $("<table>", {
                "id": "DataTable_pac_256",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla45");

            $("#DataTable_pac_256").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_pac_256").attr("class", "table table-striped table-hover table-iris");
            $("#DataTable_pac_256 thead").attr("class", "cabzera");
            $("#DataTable_pac_256 thead").append(
                $("<tr>").append(

                    $("<th>", { "class": "textoReducido" }).text("Nº"),
                    $("<th>", { "class": "textoReducido" }).text("HO_CC"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre"),
                    $("<th>", { "class": "textoReducido" }).text("Apellido")

                )
            );

            for (i = 0; i < MX_DTT_SIN_RUT.length; i++) {
                $("#DataTable_pac_256 tbody").append(
                    $("<tr>", {
                        "class": "textoReducido manitos2",
                        "padding": "1px !important",
                        "onclick": `Ajax_N_PACIENTE("` + MX_DTT_SIN_RUT[i].HO_CC + `")`
                    }).append(
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"

                        }).text(i + 1),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).text(MX_DTT_SIN_RUT[i].HO_CC),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).text(MX_DTT_SIN_RUT[i].HO_Nombres),
                       $("<td>", {
                           "align": "left",
                           "class": "textoReducido"
                       }).text(MX_DTT_SIN_RUT[i].HO_ApellidoPaterno + " " + MX_DTT_SIN_RUT[i].HO_ApellidoMaterno)
                    )
                )
            }
            //$('#DataTable_pac').DataTable({
            //    "iDisplayLength": false,
            //    "info": false,
            //    "bPaginate": false,
            //    "bFilter": true,
            //    "bSort": false,
            //    "language": {
            //        "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>"
            //    }
            //})
        }
        //-*-*-*-*-*-*-*-*-* TABLA DINAMICA -*-*-*-*-*-*-*-*-*-*-*
        function add_row() {
            var rowstota = document.getElementById("DataTable_pac2").rows.length;
            var xvalue = $("#DataTable_pac2 tr:last input").val();
            if (xvalue != "") {
                $("#DataTable_pac2 tbody").append(
                        $("<tr>", {
                            "class": "textoReducido manito",
                            "padding": "1px !important",
                        }).append(
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<input>", {
                                    "data-id": 0,
                                    "data-cod": "",
                                    "class": "td_input",
                                    "value": ""
                                })
                            }())),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido td_val1"
                            }).text(""),
                           $("<td>", {
                               "align": "center",
                               "class": "textoReducido td_val2"
                           }).text(""),
                        $("<td>", {
                            "align": "center"
                        }).html(function () {
                            var admin = Galletas.getGalleta("P_ADMIN");
                            if (admin == 1) {
                                return "<button type='button' class='btn btn-default btn-xs borrar' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"
                            } else {
                                return "<button type='button' class='btn btn-default btn-xs borrar' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;' disabled='disabled'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"
                            }

                           

                        }),

                        $("<td>", {
                            "align": "center"
                        }).html("<button type='button' class='btn btn-print btn-xs CEstado' value='Espera' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>")

                        )

                    )
                $(".td_input").keydown(function EnterEvent(e) {
                    if (e.keyCode == 13) {
                        xId = $(this).attr("data-id");
                        var xcod = $(this).attr("data-cod");
                        var admin = Galletas.getGalleta("P_ADMIN");
                        if (admin == 1) {
                        Ajax_DataTable_examen3($(this).val(), xId, xcod, $(this));
                    }

                    }
                });
                var HXH = 0;
                for (x = 0; x < Mx_Dtt_examcof.length; x++) {
                    if (Mx_Dtt_examcof[x].ID_CODIGO_FONASA == 1054) {
                        HXH = 1;
                    }
                }
                if (HXH == 1 && $("#sex").val() == 2 && sifi == 0) {
                    var str_Error = "Por favor Rellenar el campo F.U.R"
                    $("#title").text("Recordatorio");
                    $("#button_modal").attr("class", "btn btn-success");

                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();
                    sifi = 1;
                }
            } else if ((rowstota == 1) || (rowstota == 2)) {
                $("#DataTable_pac2 tbody").append(
                        $("<tr>", {
                            "class": "textoReducido manito",
                            "padding": "1px !important",
                        }).append(
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<input>", {
                                    "data-id": 0,
                                    "data-cod": "",
                                    "class": "td_input",
                                    "value": ""
                                })
                            }())),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido td_val1"
                            }).text(""),
                           $("<td>", {
                               "align": "center",
                               "class": "textoReducido td_val2"
                           }).text(""),
                        $("<td>", {
                            "align": "center"
                            }).html(function () {
                                var admin = Galletas.getGalleta("P_ADMIN");
                                if (admin == 1) {
                                    return "<button type='button' class='btn btn-default btn-xs borrar' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"
                                } else {
                                    return "<button type='button' class='btn btn-default btn-xs borrar' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;' disabled='disabled'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"
                                }                       
                            })
                        )
                    )
                $(".td_input").keydown(function EnterEvent(e) {
                    if (e.keyCode == 13) {
                    xId = $(this).attr("data-id");
                    var xcod = $(this).attr("data-cod");
                        var admin = Galletas.getGalleta("P_ADMIN");
                        if (admin == 1) {
                    Ajax_DataTable_examen3($(this).val(), xId, xcod, $(this));
                        }

                    }
                });
            }
            var xLen = $(".td_input");
            $(".td_input").eq(xLen.length - 1).focus();
        }
        var Mx_Dtt_examcof = [
          {
              "AÑO_DESC": 0,
              "ID_PREVE": 0,
              "ID_CODIGO_FONASA": 0,
              "CF_PRECIO_AMB": 0,
              "CF_PRECIO_HOS": 0,
              "ID_ESTADO": 0,
              "CF_COD": 0,
              "CF_DESC": 0,
              "ID_PER": 0,
              "ID_CF_PRECIO": 0,
              "CF_DIAS": 0,
          }
        ];
        Mx_Dtt_examcof.length = 0;

        //-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        var Mx_Dt023 = [
          {
              "CORELATIVO": 0,
              "ID_PREINGRESO": 0
          }
        ];
        function Ajax_guardar() {
            modal_show();
            var fur = 0;
            var OB = "";
            var ID = 0;
            var ed = (function () {
                var asd = $("#fecha").val();
                var array = asd.split("-")
                var total = ""
                var dia = array[0];
                var mes = array[1];
                var ano = array[2];

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
                if (ahora_mes > mes)
                    meses = ahora_mes - mes;
                if (ahora_mes < mes)
                    meses = 12 - (mes - ahora_mes);
                if (ahora_mes == mes && dia > ahora_dia)
                    meses = 11;
                // calculamos los dias
                var dias = 0;
                total = String(edad);
                if (ahora_dia > dia) {
                    dias = ahora_dia - dia;
                    total = String(edad);
                }
                if (ahora_dia < dia) {
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                    total = String(edad);
                }
                return total;

            }());
            var me = (function () {
                var asd = $("#fecha").val();
                var array = asd.split("-")
                var total = ""
                var dia = array[0];
                var mes = array[1];
                var ano = array[2];

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
                if (ahora_mes > mes)
                    meses = ahora_mes - mes;
                if (ahora_mes < mes)
                    meses = 12 - (mes - ahora_mes);
                if (ahora_mes == mes && dia > ahora_dia)
                    meses = 11;
                // calculamos los dias
                var dias = 0;
                total = String(meses);
                if (ahora_dia > dia) {
                    dias = ahora_dia - dia;
                    total = String(meses);
                }
                if (ahora_dia < dia) {
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                    total = String(meses);
                }
                return total;

            }());
            var di = (function () {
                var asd = $("#fecha").val();
                var array = asd.split("-")
                var total = ""
                var dia = array[0];
                var mes = array[1];
                var ano = array[2];

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
                if (ahora_mes > mes)
                    meses = ahora_mes - mes;
                if (ahora_mes < mes)
                    meses = 12 - (mes - ahora_mes);
                if (ahora_mes == mes && dia > ahora_dia)
                    meses = 11;
                // calculamos los dias
                var dias = 0;
                total = String(dias);
                if (ahora_dia > dia) {
                    dias = ahora_dia - dia;
                    total = String(dias);
                }
                if (ahora_dia < dia) {
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                    total = String(dias);
                }
                return total;

            }());
            var TOTAL = 0;
            var HO_CC = "";

            ids = new Array();
            for (x = 0; x < Mx_Dtt_examcof.length; x++) {

                for (z = 0; z < Mx_Dtt_exam02_respaldo_global.length; z++) {
                    if (Mx_Dtt_examcof[x].ID_CODIGO_FONASA == Mx_Dtt_exam02_respaldo_global[z].ID_CODIGO_FONASA) {
                        var xtotal = parseFloat(Mx_Dtt_exam02_respaldo_global[z].CF_PRECIO_AMB);
                        TOTAL += xtotal;

                        var objId = {
                            "id_CF": Mx_Dtt_examcof[x].ID_CODIGO_FONASA,
                            "id_PER": Mx_Dtt_exam02_respaldo_global[z].ID_PER,
                            "Valor": Mx_Dtt_exam02_respaldo_global[z].CF_PRECIO_AMB,
                            "HO_CC": Mx_Dtt_examcof[x].HO_CC,
                            "CF_ESTADO_EXAMEN": Mx_Dtt_examcof[x].CF_ESTADO_EXAMEN

                        };
                        ids.push(objId);
                    }
                }
            }
            gg = new Array();

            $("#checkBox2:checkbox:checked").each(function () {
                gg.push($(this).val());
            });
            if (gg.length == 1) {
                fur = $("#FUR").val();
            } else {
                fur = "";
            }
            if (verrut == 1) {
                var OB = "";
                ID = Mx_AVIS[0].HO_ID;
                HO_CC = Mx_AVIS[0].HO_CC;
            } else if (verrut == 2) {
                var OB = "";
                ID = Mx_Dtt2[0].HO_ID;
                HO_CC = Mx_Dtt2[0].HO_CC;
            } else {
                ID = "";
                HO_CC = "";


            }
            var diag = 0;
            var diag2 = 0;
            if ($("#Diag2").val() == "") {
                diag = 0;
            } else {
                diag = Mx_DL_Diag[0].ID_DIAGNOSTICO;
            }
            if ($("#Diag3").val() == "") {
                diag2 = 0;
            } else {
                diag2 = Mx_DL_Diag2[0].ID_DIAGNOSTICO;
            }
            var f = moment().format("DD-MM-YYYY");
            var fffff = getParameterByName('ID_ATE');
            let hocc_x1 = ""
            if($("#Avis").val() == ""){
                hocc_x1 = "";
            } else {
                hocc_x1 = $("#Avis").val();
            }
            var Data_Par = {
                //-*-*-*-*Datos Paciente-*-*-*-*-*-*
                "RUT_PAC": $('#rut').val(),
                "HO_CC": hocc_x1,
                "FUR": fur,
                "Paridad": verrut,
                "ID_PAC": ID,
                "OB": $("#obs_ate").val(),
                //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                "Procedencia": $("#Procedencia").val(),
                "Programa": $("#Programa").val(),
                "Sector": $("#Sector").val(),
                "TipoAtencion": $("#TipoAtencion").val(),
                "PrioridadTM": $("#PrioridadTM").val(),
                "Doctor": $("#Doctor").val(),
                "Prevision": $("#Prevision").val(),
                //-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/
                "EDAD": ed,
                "MES": me,
                "DIA": di,
                //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                "TOTAL": TOTAL,
                "FECHA_PRE": f,
                //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-    
                "ids": ids,
                "ATE_SAYDEX": "",
                "DIAG1": diag,
                "DIAG2": diag2,
                "interno": $("#interno").val(),
                "sub_atencion": $("#sub_atencion").val(),
                "vih": $("#vih").val(),
                "NOMBRE_PAC": $("#Nom").val(),
                "APE_PAC": $("#Ape").val(),
                "FNAC_PAC": $("#fecha").val(),
                "ID_SEXO": $("#sex").val(),
                "ID_NACIONALIDAD": $("#Nacio").val(),
                "FONO1": $("#telfijo").val(),
                "MOVIL1": $("#Celular").val(),
                "ID_CIU_COM": $("#Comuna").val(),
                "DIR_PAC": $("#direccion").val(),
                "EMAIL_PAC": $("#Email").val(),
                "id_ate": fffff,
                "NEW_VIH": $("#ddl_new_vih option:selected").text(),
                "S_Id_User": Galletas.getGalleta("ID_USER")
  
            };

            $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate_Avis_2.aspx/Guardar_TodoByVal",
                "data": JSON.stringify(Data_Par),
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dt023 = JSON.parse(json_receiver);

                        Hide_Modal();
                        Ajax_DL_SEXO();
                        Ajax_DataTable();
                        Ajax_DL_NAC();
                        Ajax_Ciudad();
                        Ajax_DL_sec();
                        Ajax_DL_orden_ate();
                        Ajax_DL_DOC();

                        $("#checkBox2").prop('checked', false);
                        $('#FUR').attr("disabled", true);
                        $('#checkBox2').attr("disabled", true);
                        $("#fur").css("pointer-events", "none");
                        var f = moment().format("DD-MM-YYYY");
                        $("#fecha").val(f);     
                        Ajax_DL_programa();
                        $("#Avis").val("");
                        $("#FUR").val(f);
                        $('#rut').removeAttr("disabled");
                        $('#rut').val("");
                        $("#Nom").val("");
                        $("#Ape").val("");
                        $("#Edad").val("");
                        $("#telfijo").val("");
                        $("#Celular").val("");
                        $("#Email").val("");
                        $("#direccion").val("");
                        $("#Diag").val("");
                        $("#Diag2").val("");
                        $("#interno").val("");
                        $("#Diag3").val("");
                        $("#obs_ate").val("");
                        $("#ddl_new_vih").val(0);
                        $("#ddl_new_vih").css({ "border-color": "#ccc" });
                        $("#ddl_new_vih").parent().css({ "color": "#212529" });
                        $("#vih").val(0);
                        $("#vih").css({ "border-color": "#ccc" });
                        $("#vih").parent().css({ "color": "#212529" });
                        $('#XXXXXXXX').removeClass('show');
                        Mx_Dtt_examcof.length = 0;
                        $("#DataTable_pac2 tbody").empty();
                        add_row();
                        verrut = 0;
                        Mx_Dtt2.length = 0;

                        $("#title2").text("Ingreso de Atención realizado");
                        $("#modalpccc").html("<p><strong>Nº de Atención:</strong> <strong style='font-size:20px;'>" + Mx_Dt023.Correlativo + "</strong>\n ¿Desea imprimir Etiquetas?</p>");
                        $("#MOdal_PAGO").modal();

                    } else {
                        Hide_Modal();


                        var str_Error = "Estimano usuario Por favor ingresar exámenes"
                        $("#title").text("Ingreso de Atención");
                        $("#button_modal").attr("class", "btn btn-danger");

                        $("#mError_AAH p").text(str_Error);
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

        //-*-*-**-*-**--**--*-*-*-***-*****--**-*-*-*-*-*-*-*-*-*-*-*-*-*-
        //--------------------------------------- JASON DIAGNOSTICO --------------------------------------------------------------------|
        var Mx_Diagnostico = [
                        {
                            "ID_DIAGNOSTICO": 0,
                            "DIA_COD": 0,
                            "DIA_DESC": 0,
                            "ID_ESTADO": 0
                        }
        ];
        function Fill_DataTable() {

            for (i = 0; i < Mx_Dtt_4556.length; i++) {
                if ($("#Procedencia").val() == Mx_Dtt_4556[i].ID_PROCEDENCIA) {


                    $("#Total").val(function () {
                        var resu = 0;
                        resu = Mx_Dtt_4556[i].AGEND_CUPO_NORMAL - Mx_Dtt_4556[i].TOTAL_AGEND_CUPO_NORMAL;
                        if (resu < 0) {
                            resu = 0;
                        }
                        return resu;

                    });
                    $("#Actuales").val(function () {

                        var resu = 0;
                        resu = Mx_Dtt_4556[i].AGEND_PRIORITARIO - Mx_Dtt_4556[i].TOTAL_AGEND_PRIORITARIO;
                        if (resu < 0) {
                            resu = 0;
                        }
                        return resu;
                    });
                    $("#Disponibles").val(function () {
                        var resu = 0;
                        resu = Mx_Dtt_4556[i].AGEND_ESPONTANEO - Mx_Dtt_4556[i].TOTAL_AGEND_ESPONTANEO;
                        if (resu < 0) {
                            resu = 0;
                        }
                        return resu;
                    });


                    //var p1 = Mx_Dtt[i].AGEND_CUPO_NORMAL - Mx_Dtt[i].TOTAL_AGEND_CUPO_NORMAL;
                    //var p2 = Mx_Dtt[i].AGEND_PRIORITARIO - Mx_Dtt[i].TOTAL_AGEND_PRIORITARIO;
                    //var p3 = Mx_Dtt[i].AGEND_ESPONTANEO - Mx_Dtt[i].TOTAL_AGEND_ESPONTANEO;
                    //var total = p1 + p2 + p3;
                    //if (p1 == 0 && p2 == 0 && p3 == 0) {
                    //    $('#BtnSaveAll').attr("disabled", false);
                    //} else {
                    //    uu = Mx_Dtt[i].CONF_DIAS_EXA_BUSCA_DIAS - total;
                    //    if (uu <= 0) {
                    //        $('#BtnSaveAll').attr("disabled", true);
                    //    } else {
                    //        $('#BtnSaveAll').attr("disabled", false);
                    //    }
                    //}
                }
            }
        }
        function Ajax_Diagnostico() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Diagnostico = JSON.parse(json_receiver);
                        Fill_Ddl_diagnostico();
                        $(".block_wait").hide();


                    } else {


                    }
                },
                "error": function (response) {


                }
            });
        }
        var Mx_AVIS = [
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
                  "IRIS_H_ID_PREINGRESO ": 0,
                  "HO_COD_DIAG": 0,
                  "HO_COD_PREVE ": 0,
                  "HO_COD_PROGRA ": 0,
                  "ID_DIAGNOSTICO ": 0,
                  "ID_PROGRA ": 0,
                  "ID_PREVE ": 0
              }
        ];
        function buscar_avis() {
            $('#rut').val("");
            $("#Nom").val("");
            $("#Ape").val("");

            $("#Edad").val("");
            $("#sex").val(0);//
            $("#DataTable_pac2 tbody").empty();
            //$("#Nacio").val(Mx_AVIS[0].ID_NACIONALIDAD);
            $("#telfijo").val("");
            //$("#Celular").val(Mx_AVIS[0].PAC_MOVIL1);
            $("#Diag2").val("");
            $("#Diag").val("");
            //$("#direccion").val(Mx_AVIS[0].PAC_DIR);
            $("#Email").val("");

            modal_show();
            var Data_Par = JSON.stringify({
                "AVIS": $("#Avis").val()
            });
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/Llenar_AVIS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_AVIS = JSON.parse(json_receiver);
                        //if (Mx_AVIS[0].ID_PREVE != "") {
                        // $("#Prevision").val(Mx_AVIS[0].ID_PREVE);
                        //Ajax_DataTable_examen02();
                        //}


                        $("#DataTable_pac2 tbody").empty();
                        add_row();

                        Fill_DL_AVIS();

                        Hide_Modal();
                        verrut = 1;



                    } else {


                        Hide_Modal();
                        $("#mError_AAH").modal('hide');
                        var str_Error = "El N° ingresado no pertenece a un paciente AVIS";
                        $("#title").text("N° AVIS no encontrado :");
                        $("#button_modal").attr("class", "btn btn-danger");

                        $("#mError_AAH p").text(str_Error);
                        $("#mError_AAH").modal();
                        verrut = 0;
                        MX_HO_ExamenCodigo.length = 0;
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }
        var Mx_OMI = [
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
    "IRIS_H_ID_PREINGRESO ": 0,
    "HO_COD_DIAG": 0,
    "HO_COD_PREVE ": 0,
    "HO_COD_PROGRA ": 0,
    "ID_DIAGNOSTICO ": 0,
    "ID_PROGRA ": 0,
    "ID_PREVE ": 0
}
        ];
        function buscar_omi_nuevo_folio() {
            modal_show();
            var Data_Par = JSON.stringify({
                "AVIS": $("#Avis").val()
            });
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS_2.aspx/Llenar_AVIS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_OMI = JSON.parse(json_receiver);
                        var rut_avis = Mx_Detalle_ate.proparra1[0].PAC_RUT;
                        rut_avis = `${rut_avis}`.replace(/\./gi, "");
                        if (Mx_OMI[0].HO_RutPaciente != rut_avis) {
                            Hide_Modal();
                            $("#mError_AAH").modal('hide');
                            var str_Error = "El N° ingresado no pertenece al paciente Avis";
                            $("#title").text("N° Avis:");
                            $("#button_modal").attr("class", "btn btn-danger");

                            $("#mError_AAH p").text(str_Error);
                            $("#mError_AAH").modal();

                            $('#XXXXXXXX').removeClass('show');
                            $("#Avis").val("");
                            $("#Avis").val(omi_save);
                            agregar_folio = 0;
                        } else {
                            agregar_folio = 0;

                            let drLng = $("#Doctor option").length;
                            let strAVIS = Mx_OMI[0].HO_NombreMedico;
                            let DocStat = false;
                            let regeX = new RegExp(`${strAVIS.replace(/\s+/g, "\\s+")}`, `gi`);
                            for (i = 0; i < drLng; i++) {
                                let Sel_Val = $("#Doctor option").eq(i).text();
                                if (Sel_Val.match(regeX) != null) {
                                    $("#Doctor option").eq(i).prop('selected', true);
                                    DocStat = true;
                                    break;
                                }
                            }
                            if (DocStat == false) {
                                creardoctor(Mx_OMI[0].HO_CC);
                            }

                            Fill_DL_OMI();
                            verrut = 1;
                        }
                        Hide_Modal();
                        //verrut = 1;



                    } else {

                        Ajax_N_PACIENTE_3();
                        //Hide_Modal();
                        //$("#mError_AAH").modal('hide');
                        //var str_Error = "El N° ingresado no pertenece a un paciente Avis";
                        //$("#title").text("N° Avis no encontrado :");
                        //$("#button_modal").attr("class", "btn btn-danger");

                        //$("#mError_AAH p").text(str_Error);
                        //$("#mError_AAH").modal();

                        //$('#XXXXXXXX').removeClass('show');
                        //verrut = 0;
                        MX_HO_ExamenCodigo.length = 0;
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }


        //---------------Declaración de JSON ajax llenado de pacientes--------------------->
        var Mx_Dtt2_avis_recuperado = [
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

        function Ajax_N_PACIENTE_3() {
            //Debug


            //modal_show();
            var Data_Par_tabla = JSON.stringify({
                "AVIS": $("#Avis").val()
            });
            var ajax_tabla = $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate_Avis.aspx/Llenar_AVIS",
                "data": Data_Par_tabla,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    //Debug

                    //Mx_Dtt2 = data_tabla_paciente.d;
                    //--------Llamamos al fill_datatable para llenar datos en la tabla--------->
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt2_avis_recuperado = JSON.parse(json_receiver);
                        Ajax_modal_exa_3(Mx_Dtt2_avis_recuperado[0].IRIS_H_ID_PREINGRESO, Mx_Dtt2_avis_recuperado[0].IRIS_H_ID_ATENCION, Mx_Dtt2_avis_recuperado[0].HO_CC);
                        //Hide_Modal();
                    } else {
                        //Hide_Modal();
                        Hide_Modal();
                        $("#mError_AAH2_3").modal('hide');

                        $("#title988").text("Datos actuales");
                        $("#p1").text("Estimado el número Avis : " + $("#Avis").val() + " No fue encontrado");
                        $("#mError_AAH2_3").modal();
                    }
                },
                "error": data_tabla_paciente => {

                    console.log("salio mall :P");
                    console.log(data_tabla_paciente);
                    ////-------mensaje bonito al usuario que no se encontro nada---------->
                    //$("#Div_Tabla").append(
                    //("<div class='alert alert-danger alertas'><strong>Sin Resultados</strong>  </div>")
                    //);
                    ////------------Ocultamos el div qwerty------------->
                    //$("#qwerty").hide();
                    ////--------disabled true al boton excel---------->
                    //$('#BtnAgenda').attr("disabled", true);
                }
            });
        }


        var Mx_Dtt_Ate_XXX = [
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

        function Ajax_modal_exa_3(preingreso_paciente, atencion_paciente, ATE_NUM_ATENCION_MODAL) {
            //cambiar de colores los input a normales
            Hide_Modal();
            //Debug
            var Data_Par_modal = JSON.stringify({
                "ID_PRE": preingreso_paciente,
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
                    "url": "Ingreso_Ate_Avis.aspx/Llenar_DataTable_Ate",
                    "data": Data_Par_modal,
                    "contentType": "application/json;  charset=utf-8",
                    "dataType": "json",
                    "success": function (response) {
                        var json_receiver = response.d;
                        if (json_receiver != "null") {

                            Mx_Dtt_Ate_XXX = JSON.parse(json_receiver);
                            $("#mError_AAH2_3").modal('hide');
                            $("#title988").html("<strong>Datos actuales</strong>");
                            $("#p1").html("Estimado el número Avis :<strong style='font-size:20px;'> " + $("#Avis").val() + "</strong> contiene los siguentes datos");
                            $("#p3").html("<strong>Número de agenda: </strong>" + Mx_Dtt_Ate_XXX[0].PREI_NUM);
                            $("#p4").html("<strong>Número de atención: </strong>" + Mx_Dtt_Ate_XXX[0].ATE_NUM);
                            $("#p2").html("<strong>Paciente: </strong>" + Mx_Dtt_Ate_XXX[0].PAC_NOMBRE + " " + Mx_Dtt_Ate_XXX[0].PAC_APELLIDO);
                            $("#p5").html("No se podrán cargar los exámenes ya que cuenta con una cita y/o una toma de muestra previa");
                            $("#mError_AAH2_3").modal();
                            add_row();
                        } else {


                        }

                    },
                    "error": function (response) {



                    }
                });
            }


        }
        function Fill_DL_OMI() {

            MX_HO_ExamenCodigo.length = 0;

            for (x = 0; x < Mx_OMI.length; x++) {
                switch (x) {
                    case 0:
                        var objId = {
                            "Examen": Mx_OMI[x].HO_ExamenCodigo,
                            "HO_CC": Mx_OMI[x].HO_CC
                        };
                        MX_HO_ExamenCodigo.push(fnClone(objId));
                        break;
                    default:
                        if (Mx_OMI[x].HO_ExamenCodigo != Mx_OMI[x - 1].HO_ExamenCodigo) {
                            var objId = {
                                "Examen": Mx_OMI[x].HO_ExamenCodigo,
                                "HO_CC": Mx_OMI[x].HO_CC
                            };
                            MX_HO_ExamenCodigo.push(fnClone(objId));
                        }
                }
            }

            var ftler = Array();
            var hash = {};
            MX_HO_ExamenCodigo = MX_HO_ExamenCodigo.filter(function (current) {
                var exists = !hash[current.Examen] || false;
                hash[current.Examen] = true;
                return exists;
            });
            for (x = 0; x < MX_HO_ExamenCodigo.length; x++) {
                for (y = 0; y < ftler.length; y++) {
                    if (MX_HO_ExamenCodigo[x].Examen == ftler[y].Examen) {
                        if (MX_HO_ExamenCodigo[x].HO_CC < ftler[y].HO_CC) {
                            MX_HO_ExamenCodigo.splice(x, 1);
                        }
                    }
                }
            }
            Ajax_Examens_OMI();
        }

        var Mx_examenes_OMI = [
{
    "ID_CODIGO_FONASA": 0,
    "CF_COD": "asdf",
    "CF_DESC": "asdf",
    "ID_ESTADO": 0,
    "CF_AVIS": 0,
    "CF_ESTADO_EXAMEN": "",
    "HO_CC": ""
}
        ];
        function Ajax_Examens_OMI() {


            var Data_Par = JSON.stringify({
                "examenes": MX_HO_ExamenCodigo
            });
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/IRIS_WEBF_BUSCA_examenes_paciente",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_examenes_OMI = JSON.parse(json_receiver);

                        //for (x = 0; x < Mx_examenes_OMI.length; x++) {

                        //    if ($("#sex").val() == 2) {
                        //        if (Mx_examenes_OMI[x].ID_CODIGO_FONASA == 66) {
                        //            for (d = 0; d < Mx_Dtt_exam02_respaldo.length; d++) {
                        //                if (Mx_Dtt_exam02_respaldo[d].ID_CODIGO_FONASA == 1026) {
                        //                    console.log(Mx_examenes_OMI[x].ID_CODIGO_FONASA = Mx_Dtt_exam02_respaldo[d].ID_CODIGO_FONASA);
                        //                    Mx_examenes_OMI[x].ID_CODIGO_FONASA = Mx_Dtt_exam02_respaldo[d].ID_CODIGO_FONASA;
                        //                    Mx_examenes_OMI[x].CF_DESC = Mx_Dtt_exam02_respaldo[d].CF_DESC;
                        //                    Mx_examenes_OMI[x].CF_COD = Mx_Dtt_exam02_respaldo[d].CF_COD;
                        //                    Mx_examenes_OMI[x].ID_ESTADO = Mx_Dtt_exam02_respaldo[d].ID_ESTADO;
                        //                    Mx_examenes_OMI[x]["CF_ESTADO_EXAMEN"] = "Activo"
                        //                }

                        //            }
                        //        }
                        //    } 

                        //}



                        for (i = 0; i < Mx_examenes_OMI.length; i++) {
                            if ((Mx_examenes_OMI[i].ID_CODIGO_FONASA == 66) || (Mx_examenes_OMI[i].ID_CODIGO_FONASA == 1026)) {
                                console.log("Entre al if");
                                console.log("--valor sex----");
                                console.log($("#sex").val())
                                if ($("#sex").val() == 1) {  //masculino
                                    for (h = 0; h < Mx_Dtt_exam02_respaldo.length; h++) {
                                        if (Mx_Dtt_exam02_respaldo[h].ID_CODIGO_FONASA == 66) {


                                            Mx_examenes_OMI[i].CF_COD = Mx_Dtt_exam02_respaldo[h].CF_COD;
                                            Mx_examenes_OMI[i].CF_DESC = Mx_Dtt_exam02_respaldo[h].CF_DESC;
                                            Mx_examenes_OMI[i].CF_DIAS = Mx_Dtt_exam02_respaldo[h].CF_DIAS;
                                            Mx_examenes_OMI[i].ID_CODIGO_FONASA = Mx_Dtt_exam02_respaldo[h].ID_CODIGO_FONASA;
                                            Mx_examenes_OMI[i].ID_ESTADO = Mx_Dtt_exam02_respaldo[h].ID_ESTADO;

                                            Mx_examenes_OMI[i]["CF_ESTADO_EXAMEN"] = "Activo"
                                            console.log("masculino");
                                        }
                                    }

                                } else if ($("#sex").val() == 2) { // femenino
                                    for (h = 0; h < Mx_Dtt_exam02_respaldo.length; h++) {
                                        if (Mx_Dtt_exam02_respaldo[h].ID_CODIGO_FONASA == 1026) {

                                            Mx_examenes_OMI[i].CF_COD = Mx_Dtt_exam02_respaldo[h].CF_COD;
                                            Mx_examenes_OMI[i].CF_DESC = Mx_Dtt_exam02_respaldo[h].CF_DESC;
                                            Mx_examenes_OMI[i].CF_DIAS = Mx_Dtt_exam02_respaldo[h].CF_DIAS;
                                            Mx_examenes_OMI[i].ID_CODIGO_FONASA = Mx_Dtt_exam02_respaldo[h].ID_CODIGO_FONASA;
                                            Mx_examenes_OMI[i].ID_ESTADO = Mx_Dtt_exam02_respaldo[h].ID_ESTADO;

                                            console.log("femenino");
                                        }
                                    }

                                }

                            }

                        }

                        let bFound = false;
                        let xi = 0;

                        for (let reee in Mx_examenes_OMI) {
                            bFound = false;

                            for (let ii in Mx_Dtt_examcof) {
                                console.log("IF" + Mx_examenes_OMI[reee].ID_CODIGO_FONASA + "==" + Mx_Dtt_examcof[ii].ID_CODIGO_FONASA);
                                if (Mx_examenes_OMI[reee].ID_CODIGO_FONASA == Mx_Dtt_examcof[ii].ID_CODIGO_FONASA) {
                                    bFound = true;
                                    xi = ii;
                                    break;
                                }
                            }
                            if (bFound == true) {
                                let ID_SQL = parseInt(Mx_examenes_OMI[reee].HO_CC);
                                let ID_TAB = parseInt(Mx_Dtt_examcof[xi].HO_CC);

                                if (ID_SQL > ID_TAB) {
                                    Mx_Dtt_examcof[xi] = fnClone(Mx_examenes_OMI[reee]);
                                    Mx_Dtt_examcof[xi]["CF_ESTADO_EXAMEN"] = "Activo"
                                    console.log("Repetido");
                                    console.log(Mx_Dtt_examcof[xi]);
                                }
                            } else {
                                Mx_Dtt_examcof.push(fnClone(Mx_examenes_OMI[reee]));
                                Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                                console.log("No Esta");
                                console.log(Mx_Dtt_examcof.length - 1);
                            }
                        }
                        let hocc = ""
                        //if ($("#sex").val() == 2) {

                        //    var xxxer = false;
                        //    for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                        //        //for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                        //        if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 66) {
                        //            hocc = Mx_Dtt_examcof[z].HO_CC
                        //            Mx_Dtt_examcof.splice(z, 1);
                        //            xxxer = true;
                        //        }
                        //        //}
                        //    }
                        //    if (xxxer == true) {
                        //        for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                        //            if (Mx_Dtt_exam02_respaldo[x].ID_CODIGO_FONASA == 1026) {

                        //                Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02_respaldo[x]));
                        //                Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["HO_CC"] = hocc
                        //                Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                        //            }
                        //        }
                        //    }

                        //}
                        //if ($("#sex").val() == 1) {

                        //    var xxxer = false;
                        //    for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                        //        //for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                        //        if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1026) {
                        //            hocc = Mx_Dtt_examcof[z].HO_CC
                        //            Mx_Dtt_examcof.splice(z, 1);
                        //            xxxer = true;
                        //        }
                        //        //}
                        //    }
                        //    if (xxxer == true) {
                        //        for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                        //            if (Mx_Dtt_exam02_respaldo[x].ID_CODIGO_FONASA == 66) {
                        //                Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02_respaldo[x]));
                        //                Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["HO_CC"] = hocc
                        //                Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                        //            }
                        //        }
                        //    }
                        //}


                        for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                            if ((Mx_Dtt_examcof[i].ID_CODIGO_FONASA == 66) || (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == 1026)) {
                                console.log("Entre al if");
                                console.log("--valor sex----");
                                console.log($("#sex").val())
                                if ($("#sex").val() == 1) {  //masculino
                                    for (h = 0; h < Mx_Dtt_exam02_respaldo.length; h++) {
                                        if (Mx_Dtt_exam02_respaldo[h].ID_CODIGO_FONASA == 66) {

                                            Mx_Dtt_examcof[i].AÑO_DESC = Mx_Dtt_exam02_respaldo[h].AÑO_DESC;
                                            Mx_Dtt_examcof[i].CF_COD = Mx_Dtt_exam02_respaldo[h].CF_COD;
                                            Mx_Dtt_examcof[i].CF_DESC = Mx_Dtt_exam02_respaldo[h].CF_DESC;
                                            Mx_Dtt_examcof[i].CF_DIAS = Mx_Dtt_exam02_respaldo[h].CF_DIAS;
                                            Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN = Mx_Dtt_exam02_respaldo[h].CF_ESTADO_EXAMEN;
                                            Mx_Dtt_examcof[i].CF_PRECIO_AMB = Mx_Dtt_exam02_respaldo[h].CF_PRECIO_AMB;
                                            Mx_Dtt_examcof[i].CF_PRECIO_HOS = Mx_Dtt_exam02_respaldo[h].CF_PRECIO_HOS;
                                            Mx_Dtt_examcof[i].ID_CF_PRECIO = Mx_Dtt_exam02_respaldo[h].ID_CF_PRECIO;
                                            Mx_Dtt_examcof[i].ID_CODIGO_FONASA = Mx_Dtt_exam02_respaldo[h].ID_CODIGO_FONASA;
                                            Mx_Dtt_examcof[i].ID_ESTADO = Mx_Dtt_exam02_respaldo[h].ID_ESTADO;
                                            Mx_Dtt_examcof[i].ID_PER = Mx_Dtt_exam02_respaldo[h].ID_PER;
                                            Mx_Dtt_examcof[i].ID_PREVE = Mx_Dtt_exam02_respaldo[h].ID_PREVE;
                                            Mx_Dtt_examcof[i]["CF_ESTADO_EXAMEN"] = "Activo"
                                            console.log("masculino");
                                        }
                                    }

                                } else if ($("#sex").val() == 2) { // femenino
                                    for (h = 0; h < Mx_Dtt_exam02_respaldo.length; h++) {
                                        if (Mx_Dtt_exam02_respaldo[h].ID_CODIGO_FONASA == 1026) {

                                            Mx_Dtt_examcof[i].AÑO_DESC = Mx_Dtt_exam02_respaldo[h].AÑO_DESC;
                                            Mx_Dtt_examcof[i].CF_COD = Mx_Dtt_exam02_respaldo[h].CF_COD;
                                            Mx_Dtt_examcof[i].CF_DESC = Mx_Dtt_exam02_respaldo[h].CF_DESC;
                                            Mx_Dtt_examcof[i].CF_DIAS = Mx_Dtt_exam02_respaldo[h].CF_DIAS;
                                            Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN = Mx_Dtt_exam02_respaldo[h].CF_ESTADO_EXAMEN;
                                            Mx_Dtt_examcof[i].CF_PRECIO_AMB = Mx_Dtt_exam02_respaldo[h].CF_PRECIO_AMB;
                                            Mx_Dtt_examcof[i].CF_PRECIO_HOS = Mx_Dtt_exam02_respaldo[h].CF_PRECIO_HOS;
                                            Mx_Dtt_examcof[i].ID_CF_PRECIO = Mx_Dtt_exam02_respaldo[h].ID_CF_PRECIO;
                                            Mx_Dtt_examcof[i].ID_CODIGO_FONASA = Mx_Dtt_exam02_respaldo[h].ID_CODIGO_FONASA;
                                            Mx_Dtt_examcof[i].ID_ESTADO = Mx_Dtt_exam02_respaldo[h].ID_ESTADO;
                                            Mx_Dtt_examcof[i].ID_PER = Mx_Dtt_exam02_respaldo[h].ID_PER;
                                            Mx_Dtt_examcof[i].ID_PREVE = Mx_Dtt_exam02_respaldo[h].ID_PREVE;
                                            Mx_Dtt_examcof[i]["CF_ESTADO_EXAMEN"] = "Activo"
                                            console.log("femenino");
                                        }
                                    }

                                }



                            }

                        }




                        fill_llenado_tabla();
                        Hide_Modal();



                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    alert("Error", str_Error);


                }
            });
        }






        var Mx_Dtt_exam02 = [
          {
              "AÑO_DESC": 0,
              "ID_PREVE": 0,
              "ID_CODIGO_FONASA": 0,
              "CF_PRECIO_AMB": 0,
              "CF_PRECIO_HOS": 0,
              "ID_ESTADO": 0,
              "CF_COD": 0,
              "CF_DESC": 0,
              "ID_PER": 0,
              "ID_CF_PRECIO": 0,
              "CF_DIAS": 0,
          }
        ];
        var Mx_Dtt_exam02_respaldo = [
{
    "AÑO_DESC": 0,
    "ID_PREVE": 0,
    "ID_CODIGO_FONASA": 0,
    "CF_PRECIO_AMB": 0,
    "CF_PRECIO_HOS": 0,
    "ID_ESTADO": 0,
    "CF_COD": 0,
    "CF_DESC": 0,
    "ID_PER": 0,
    "ID_CF_PRECIO": 0,
    "CF_DIAS": 0,
}
        ];
        function Ajax_DataTable_examen02() {
            modal_show();
            setTimeout(function () {
                console.log("Pasamos...");
                var f = moment().format("DD-MM-YYYY");


                $("#Div_Tabla2").empty();
                var Data_Par = JSON.stringify({
                    "ID_PREVE": $("#Prevision").val(),
                    "Fecha": f
                });

                $.ajax({
                    "type": "POST",
                    "url": "IN_PAC_AVIS.aspx/Llenar_tabla_exam2",
                    "data": Data_Par,
                    "contentType": "application/json;  charset=utf-8",
                    "dataType": "json",
                    "success": function (response) {
                        var json_receiver = response.d;
                        if (json_receiver != "null") {
                            Mx_Dtt_exam02 = JSON.parse(json_receiver);
                            Mx_Dtt_exam02_respaldo = JSON.parse(json_receiver);
                            if ($("#sex").val() != 0) {
                                var posicion = 0;
                                if ($("#sex").val() == 1) {
                                    for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                                        if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 1026) {
                                            posicion = x;
                                        }
                                    }
                                    Mx_Dtt_exam02.splice(posicion, 1);
                                }
                                if ($("#sex").val() == 2) {
                                    for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                                        if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 66) {
                                            posicion = x;
                                        }
                                    }
                                    Mx_Dtt_exam02.splice(posicion, 1);
                                }
                            }
                            Hide_Modal();
                            Fill_DataTable_exam02();

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
            }, 3000);
        }


        var Mx_Dtt_exam02_respaldo_global = [
      {
          "AÑO_DESC": 0,
          "ID_PREVE": 0,
          "ID_CODIGO_FONASA": 0,
          "CF_PRECIO_AMB": 0,
          "CF_PRECIO_HOS": 0,
          "ID_ESTADO": 0,
          "CF_COD": 0,
          "CF_DESC": 0,
          "ID_PER": 0,
          "ID_CF_PRECIO": 0,
          "CF_DIAS": 0,
      }
        ];
        function Ajax_DataTable_examen0GObal() {
       
            $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate_Avis_2.aspx/Llenar_tabla_exam2_global",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_exam02_respaldo_global = JSON.parse(json_receiver);
                    } else {


                    }
                },
                "error": function (response) {
                    console.log(response);



                }
            });
        }
        var Mx_Dtt_exam03 = [
          {
              "AÑO_DESC": 0,
              "ID_PREVE": 0,
              "ID_CODIGO_FONASA": 0,
              "CF_PRECIO_AMB": 0,
              "CF_PRECIO_HOS": 0,
              "ID_ESTADO": 0,
              "CF_COD": 0,
              "CF_DESC": 0,
              "ID_PER": 0,
              "ID_CF_PRECIO": 0,
              "CF_DIAS": 0,
          }
        ];

        function Ajax_DataTable_examen3(cod_fonasa, id, cod, txis) {
            var f = moment().format("DD-MM-YYYY");


            var Data_Par = JSON.stringify({
                "ID_PREVE": $("#Prevision").val(),
                "Fecha": f,
                "CF": cod_fonasa
            });
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/Llenar_tabla_exam",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_exam03 = JSON.parse(json_receiver);
                        if ($("#sex").val() != 0) {
                            var posicion = 0;
                            if ($("#sex").val() == 1) {
                                for (x = 0; x < Mx_Dtt_exam03.length; x++) {
                                    if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 1026) {
                                        posicion = x;
                                    }
                                }
                                Mx_Dtt_exam03.splice(posicion, 1);
                            }
                            if ($("#sex").val() == 2) {
                                for (x = 0; x < Mx_Dtt_exam03.length; x++) {
                                    if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 66) {
                                        posicion = x;
                                    }
                                }
                                Mx_Dtt_exam03.splice(posicion, 1);
                            }
                        }
                        success(id, cod, txis);


                    } else {


                        Mx_Dtt_exam03.length = 0;
                        success(id, cod, txis);
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

 
        var Mx_Ddl = [
     {
         "ID_PROCEDENCIA": "",
         "PROC_COD": "",
         "PROC_DESC": "",
         "ID_ESTADO": ""
     }
        ];
        function Call_AJAX_Ddl() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/Llenar_Ddl_LugarTM",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl = JSON.parse(json_receiver);
                        Fill_AJAX_Ddl();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    alert("Error", str_Error);


                }
            });
        }
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
               "ID_DIAGNOSTICO": 0,
               "ID_PROGRA ": 0,
               "ID_PREVE ": 0
           }
        ];
        function creardoctor(doc) {
            console.log("entre doc");
            var Data_Par = JSON.stringify({
                "AVIS": doc
            });
            $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate_Avis_2.aspx/crearDoc",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Ajax_DL_DOC2();
                        console.log("termine de actualizar");
                                   

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
        function Ajax_busca_rut() {
            $("#checkBox2").prop('checked', false);//solo los del objeto #diasHabilitados
            $('#FUR').attr("disabled", true);
            $('#checkBox2').attr("disabled", true);
            $("#fur").css("pointer-events", "none");
            $('#Avis').val("");
            $("#Nom").val("");
            $("#Ape").val("");
            // $("#fecha").val(f);
            $("#Edad").val("");
            $("#sex").val(0);//
            $("#DataTable_pac2 tbody").empty();
            //$("#Nacio").val(Mx_AVIS[0].ID_NACIONALIDAD);
            $("#telfijo").val("");
            //$("#Celular").val(Mx_AVIS[0].PAC_MOVIL1);
            $("#Diag2").val("");
            $("#Diag").val("");
            //$("#direccion").val(Mx_AVIS[0].PAC_DIR);
            $("#Email").val("");


            modal_show();
            var Data_Par = JSON.stringify({
                "RUT": $("#rut").val()
            });
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/Llenar_AVIS_RUT",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt2 = JSON.parse(json_receiver);
   
                        $("#DataTable_pac2 tbody").empty();
                        add_row();
                        Fill_DL_Rut();
                        Hide_Modal();
                        verrut = 2;





                    } else {


                        Ajax_busca_rut_22();

                        //Hide_Modal();
                        //var str_Error = "El rut ingresado no pretenece a un paciente AVIS";
                        //$("#title").text("Rut no encontrado:");
                        //$("#button_modal").attr("class", "btn btn-danger");

                        //$("#mError_AAH p").text(str_Error);
                        //$("#mError_AAH").modal();
                        verrut = 0;
                        //MX_HO_ExamenCodigo.length = 0;
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        var Mx_Dtt2_rut = [
           {
               "ID_PACIENTE": 0,
               "PAC_RUT": 0,
               "PAC_NOMBRE": 0,
               "PAC_APELLIDO ": 0,
               "ID_SEXO": 0,
               "TOTAL_ATE": 0,
               "PAC_FNAC": 0,
               "ID_NACIONALIDAD": 0,
               "ID_REL_CIU_COM": 0,
               "PAC_FONO1 ": 0,
               "PAC_FONO2": 0,
               "PAC_MOVIL1": 0,
               "PAC_MOVIL2": 0,
               "PAC_EMAIL": 0,
               "PAC_OBS_PER": 0,
               "PAC_DIR": 0,
               "ID_DIAGNOSTICO ": 0,
               "ID_ESTADO": 0,
               "ID_CIUDAD": 0,
               "PAC_OBS_PERMA": 0,
               "ID_COMUNA": 0
           }
        ];
        Mx_Dtt2.length = 0;
        function Ajax_busca_rut_22() {
            $("#checkBox2").prop('checked', false);//solo los del objeto #diasHabilitados
            $('#FUR').attr("disabled", true);
            $('#checkBox2').attr("disabled", true);
            $("#fur").css("pointer-events", "none");


            modal_show();
            var Data_Par = JSON.stringify({
                "rut": $("#rut").val()
            });
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/Llenar_rut",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt2_rut = JSON.parse(json_receiver);

                        Fill_DL_Rut_2();

                        Hide_Modal();
                        verrut = 1;





                    } else {


                        Hide_Modal();
                        verrut = 2;

                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        function Fill_DL_Rut_2() {
           
            $("#Nom").val(Mx_Dtt2_rut[0].PAC_NOMBRE);
            $("#Ape").val(Mx_Dtt2_rut[0].PAC_APELLIDO);
            $("#fecha").val(Mx_Dtt2_rut[0].PAC_FNAC);
            $("#Edad").val(function () {
                var asd = $("#fecha").val();
                var array = asd.split("-");
                var total = "";
                var dia = array[0];
                var mes = array[1];
                var ano = array[2];
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
                if (ahora_mes > mes)
                    meses = ahora_mes - mes;
                if (ahora_mes < mes)
                    meses = 12 - (mes - ahora_mes);
                if (ahora_mes == mes && dia > ahora_dia)
                    meses = 11;
                // calculamos los dias
                var dias = 0;
                total = String(edad + " Años");
                if (ahora_dia > dia) {
                    dias = ahora_dia - dia;
                    total = String(edad + " Años");
                }
                if (ahora_dia < dia) {
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                    total = String(edad + " Años");
                }
                return total
            });
            $("#sex").val(Mx_Dtt2_rut[0].ID_SEXO);//
            if (Mx_Dtt2_rut[0].ID_SEXO == 2) {
                $('#checkBox2').removeAttr("disabled");
            }
            $("#Nacio").val(Mx_Dtt2_rut[0].ID_NACIONALIDAD);
            $("#telfijo").val(Mx_Dtt2_rut[0].PAC_FONO1);
            $("#Celular").val(Mx_Dtt2_rut[0].PAC_MOVIL1);         
            $("#direccion").val(Mx_Dtt2_rut[0].PAC_DIR);
            $("#Email").val(Mx_Dtt2_rut[0].PAC_EMAIL);

        };







        var Mx_DL_SEXO = [
        {
            "ID_SEXO": 0,
            "SEXO_COD": "asdf",
            "SEXO_DESC": "asdf",
            "ID_ESTADO": 0
        }
        ];
       
        function Ajax_DL_SEXO() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/Llenar_DL_SEXO",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_SEXO = JSON.parse(json_receiver);
                        Fill_DL_SEXO();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }
        var Mx_DL_NAC = [
        {
            "ID_NACIONALIDAD": 0,
            "NAC_COD": "asdf",
            "NAC_DESC": "asdf",
            "ID_ESTADO": 0
        }
        ];
        function Ajax_DL_NAC() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/Llenar_DL_NAC",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_NAC = JSON.parse(json_receiver);
                        Fill_DL_NAC();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }

        //--------------------------------------- JASON CIUDAD --------------------------------------------------------------------------|
        var Mx_Ciudad = [
            {
                "ID_CIUDAD": 0,
                "CIU_COD": 0,
                "CIU_DESC": 0,
                "ID_ESTADO": 0
            }
        ];

        function Ajax_Ciudad() {


            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/IRIS_WEBF_BUSCA_CIUDAD",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ciudad = JSON.parse(json_receiver);
                        Fill_Ddl_Cuidad();
                        Ajax_Comuna();
                        $(".block_wait").hide();


                    } else {


                    }
                },
                "error": function (response) {


                }
            });
        }
        //--------------------------------------- JASON COMUNA --------------------------------------------------------------------------|
        var Mx_Comuna = [
            {
                "COM_DESC": 0,
                "ID_COMUNA": 0,
                "ID_ESTADO": 0,
                "ID_CIUDAD": 0,
                "ID_REL_CIU_COM": 0
            }
        ];
        function Ajax_Comuna() {



            var Data_Par = JSON.stringify({
                "ID_CIU": $("#Cuidad").val()
            });

            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Comuna = JSON.parse(json_receiver);
                        Fill_Ddl_Comuna();
                        $(".block_wait").hide();


                    } else {


                    }
                },
                "error": function (response) {


                }
            });
        }
        //--------------------------------------------------------------------------------------------
        var Mx_DL_prevision = [
      {
          "ID_COMUNA": 0,
          "COM_COD": "asdf",
          "COM_DESC": "asdf",
          "ID_ESTADO": 0
      }
        ];
        function Ajax_DL_prevision() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/Llenar_DL_prevision",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_prevision = JSON.parse(json_receiver);
                        Fill_DL_prevision();
                        //Ajax_DataTable_examen02();



                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }
        var Mx_DL_TP_ATE = [
     {
         "ID_TP_ATENCION": 0,
         "TP_ATE_COD": "asdf",
         "TP_ATE_DESC": "asdf",
         "ID_ESTADO": 0
     }
        ];
        function Ajax_DL_TP_ATE() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/Llenar_DL_aTENCIONES",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_TP_ATE = JSON.parse(json_receiver);
                        Fill_DL_TP_ATE();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }
        var Mx_DL_Sec = [
    {
        "ID_SECTOR": 0,
        "SECTOR_COD": "asdf",
        "SECTOR_DESC": "asdf",
        "ID_ESTADO": 0
    }
        ];
        function Ajax_DL_sec() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/Llenar_DL_Sectores",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_Sec = JSON.parse(json_receiver);
                        Fill_DL_sec();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
           
        }
        var Mx_DL_Programa = [
   {
       "ID_PROGRA": 0,
       "PROGRA_COD": "asdf",
       "PROGRA_DESC": "asdf",
       "ID_ESTADO": 0
   }
        ];
        function Ajax_DL_programa() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/Llenar_DL_Programa",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_Programa = JSON.parse(json_receiver);
                        Fill_DL_programa();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }
        var Mx_DL_DOC = [
  {
      "ID_DOCTOR": 0,
      "DOC_NOMBRE": "asdf",
      "DOC_APELLIDO": "asdf",
      "ID_ESTADO": 0
  }
        ];
        function Ajax_DL_DOC() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/Llenar_DL_DOC",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_DOC = JSON.parse(json_receiver);
                        Fill_DL_DOC();




                    } else {



                    }
                },
                "error": function (response) {

              
                    console.log(response)

                }
            });
        }


        var Mx_DL_DOC = [
 {
     "ID_DOCTOR": 0,
     "DOC_NOMBRE": "asdf",
     "DOC_APELLIDO": "asdf",
     "ID_ESTADO": 0
 }
        ];
        function Ajax_DL_DOC2() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/Llenar_DL_DOC",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_DOC = JSON.parse(json_receiver);
                        Fill_DL_DOC2();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }
        var Mx_DL_orden_ate = [
 {
     "ID_ORDEN": 0,
     "ORD_COD": "asdf",
     "ORD_DESC": "asdf",
     "ID_ESTADO": 0
 }
        ];
        function Ajax_DL_orden_ate() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/Llenar_DL_ordenATE",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_orden_ate = JSON.parse(json_receiver);
                        Fill_DL_orden_ate();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }
        var Mx_DL_Diag = [
{
            "ID_DIAGNOSTICO": 0,
            "DIA_COD": "asdf",
            "DIA_DESC": "asdf",
            "ID_ESTADO": 0,
            "DIA_HOST_AVIS": 0
}
        ];
        function Ajax_DLdiag(hosts) {
            Mx_DL_Diag.length = 0;


            var Data_Par = JSON.stringify({
                "HOST": hosts
            });
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_Diag = JSON.parse(json_receiver);
                        $("#Diag2").val(Mx_DL_Diag[0].DIA_DESC);
                        //$("#DdlDiagnostico").val(Mx_DL_Diag[0].ID_DIAGNOSTICO);
                    } else {
                        //$("#DdlDiagnostico").val(1);
                        $("#Diag2").val("");


                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    // cModal_Error("Error", str_Error);


                }
            });
        }

        var Mx_DL_Diag2 = [
{
    "ID_DIAGNOSTICO": 0,
    "DIA_COD": "asdf",
    "DIA_DESC": "asdf",
    "ID_ESTADO": 0,
    "DIA_HOST_AVIS": 0
}
        ];
        function Ajax_DLdiag2(hosts) {
            Mx_DL_Diag2.length = 0;


            var Data_Par = JSON.stringify({
                "HOST": hosts
            });
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_Diag2 = JSON.parse(json_receiver);
                        $("#Diag3").val(Mx_DL_Diag2[0].DIA_DESC);
                        //$("#DdlDiagnostico").val(Mx_DL_Diag[0].ID_DIAGNOSTICO);

                    } else {
                        //$("#DdlDiagnostico").val(1);
                        $("#Diag3").val("");


                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    // cModal_Error("Error", str_Error);


                }
            });
        }
        var Mx_examenes_avis = [
            {
                "ID_CODIGO_FONASA": 0,
                "CF_COD": "asdf",
                "CF_DESC": "asdf",
                "ID_ESTADO": 0,
                "CF_AVIS": 0,
            }
        ];
        function Ajax_Examens_avis() {
            Mx_Dtt_examcof.length = 0;


            var Data_Par = JSON.stringify({
                "examenes": MX_HO_ExamenCodigo
            });
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/IRIS_WEBF_BUSCA_examenes_paciente",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_examcof = JSON.parse(json_receiver);
                        //Fill_Mx_examenes_avis(); 
                        for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                            Mx_Dtt_examcof[i]["CF_ESTADO_EXAMEN"] = "Activo"
                            for (x = 0; x < Mx_Dtt_exam02.length; x++) {

                                if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == Mx_Dtt_exam02[x].ID_CODIGO_FONASA) {
                                    Mx_Dtt_examcof[i].CF_DIAS = fnClone(Mx_Dtt_exam02[x].CF_DIAS);
                        

                                }
                            }
                        }
                        let hocc = ""
                        if ($("#sex").val() == 2) {

                            var xxxer = false;
                            for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                                //for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                                if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 66) {
                                    hocc = Mx_Dtt_examcof[z].HO_CC
                                    Mx_Dtt_examcof.splice(z, 1);
                                    xxxer = true;
                                }
                                //}
                            }
                            if (xxxer == true) {
                                for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                                    if (Mx_Dtt_exam02_respaldo[x].ID_CODIGO_FONASA == 1026) {

                                        Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02_respaldo[x]));
                                        Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["HO_CC"] = hocc
                                        Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                                    }
                                }                   
                            }

                        }
                        if ($("#sex").val() == 1) {

                            var xxxer = false;
                            for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                                //for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                                if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1026) {
                                    hocc = Mx_Dtt_examcof[z].HO_CC
                                    Mx_Dtt_examcof.splice(z, 1);
                                    xxxer = true;
                                }
                                //}
                            }
                            if (xxxer == true) {
                                for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                                    if (Mx_Dtt_exam02_respaldo[x].ID_CODIGO_FONASA == 66) {
                                        Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02_respaldo[x]));
                                        Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["HO_CC"] = hocc
                                        Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                                    }
                                }                          
                            }
                        }
                        fill_llenado_tabla();
                        Hide_Modal();



                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    alert("Error", str_Error);


                }
            });
        }
    </script>
    <script>
        function Fill_Mx_examenes_avis() {


            for (i = 0; i < Mx_examenes_avis.length; i++) {
                for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                    if (Mx_examenes_avis[i].ID_CODIGO_FONASA == Mx_Dtt_exam02[x].ID_CODIGO_FONASA) {
                        Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02[x]));
                    }
                }
            }
            //fill_llenado_tabla();
        }
        function Fill_DL_orden_ate() {
            $("#PrioridadTM").empty();
            for (y = 0; y < Mx_DL_orden_ate.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_orden_ate[y].ID_ORDEN
                }).text(Mx_DL_orden_ate[y].ORD_DESC).appendTo("#PrioridadTM");
            }

            $("#PrioridadTM").val(1);
            kmmjk.callbuck();
        }
        function Fill_DL_DOC() {
            $("#Doctor").empty();
            for (y = 0; y < Mx_DL_DOC.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_DOC[y].ID_DOCTOR
                }).text(Mx_DL_DOC[y].DOC_NOMBRE + " " + Mx_DL_DOC[y].DOC_APELLIDO).appendTo("#Doctor");
            }
            $("#Doctor").val(Mx_Detalle_ate.proparra3[0].ID_DOCTOR);
    
        }

        function Fill_DL_DOC2() {
            $("#Doctor").empty();
            for (y = 0; y < Mx_DL_DOC.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_DOC[y].ID_DOCTOR
                }).text(Mx_DL_DOC[y].DOC_NOMBRE + " " + Mx_DL_DOC[y].DOC_APELLIDO).appendTo("#Doctor");
            }

            let drLng = $("#Doctor option").length;
            let strAVIS2 = Mx_AVIS[0].HO_NombreMedico;

            let regeX = new RegExp(`${strAVIS2.replace(/\s+/g, "\\s+")}`, `gi`);
            for (i = 0; i < drLng; i++) {
                let Sel_Val = $("#Doctor option").eq(i).text();
                if (Sel_Val.match(regeX) != null) {
                    $("#Doctor option").eq(i).prop('selected', true);

                    break;
                }
            }
        }
        function Fill_DL_programa() {
            $("#Programa").empty();
            for (y = 0; y < Mx_DL_Programa.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_Programa[y].ID_PROGRA
                }).text(Mx_DL_Programa[y].PROGRA_DESC).appendTo("#Programa");
            }
            kmmjk.callbuck();
        }
        function Fill_DL_sec() {
            $("#Sector").empty();
            for (y = 0; y < Mx_DL_Sec.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_Sec[y].ID_SECTOR
                }).text(Mx_DL_Sec[y].SECTOR_DESC).appendTo("#Sector");
            }
            kmmjk.callbuck();
        }
        function Fill_DL_TP_ATE() {
            $("#TipoAtencion").empty();
            for (y = 0; y < Mx_DL_TP_ATE.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_TP_ATE[y].ID_TP_ATENCION
                }).text(Mx_DL_TP_ATE[y].TP_ATE_DESC).appendTo("#TipoAtencion");
            }
            kmmjk.callbuck();
        }
        function Fill_DL_prevision() {
            $("#Prevision").empty();
            for (y = 0; y < Mx_DL_prevision.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_prevision[y].ID_PREVE
                }).text(Mx_DL_prevision[y].PREVE_DESC).appendTo("#Prevision");
            }
            kmmjk.callbuck();
        }
        
        function llenarmodal() {
            Ajax_DL_SEXO();
            Ajax_DL_NAC();
            Ajax_DL_DOC();
            if (Mx_Detalle_ate.proparra2.length > 0) {
                $("#Avis").val(Mx_Detalle_ate.proparra2[0].ATE_NUM_AVIS);
            }

            //let FechaREE = moment(Mx_Detalle_ate.proparra1[0].PAC_FNAC).format("DD-MM-YYYY");

            let FechaREE = moment(Mx_Detalle_ate.proparra1[0].PAC_FNAC).format("DD-MM-YYYY");
            $("#rut").val(Mx_Detalle_ate.proparra1[0].PAC_RUT);          
            $("#Nom").val(Mx_Detalle_ate.proparra1[0].PAC_NOMBRE);
            $("#Ape").val(Mx_Detalle_ate.proparra1[0].PAC_APELLIDO);
            $("#fecha").val(FechaREE);
            $("#Edad").val(`${Mx_Detalle_ate.proparra1[0].PREI_AÑO} años`);          
            $("#telfijo").val(Mx_Detalle_ate.proparra1[0].PAC_FONO1);
            $("#Celular").val(Mx_Detalle_ate.proparra1[0].PAC_MOVIL1);

            Ajax_DataTable_examen02();

            $("#Programa").val(Mx_Detalle_ate.proparra3[0].ID_PROGRAMA);
            $("#Sector").val(Mx_Detalle_ate.proparra3[0].ID_SECTOR);
            $("#Prevision").val(Mx_Detalle_ate.proparra3[0].ID_PREVE);




         
            Ajax_DLdiag(Mx_Detalle_ate.proparra3[0].ID_DIAGNOSTICO);
            Ajax_DLdiag2(Mx_Detalle_ate.proparra3[0].ID_DIAGNOSTICO2);
            $("#sub_atencion").val(Mx_Detalle_ate.proparra3[0].Sub_atencion);
            var obj_RUT2 = Valid_RUT($("#rut").val());
            $("#rut").val(obj_RUT2.Format);
            var aaa = {};
            if (Mx_Detalle_ate.proparra2.length > 0) {
                for (p = 0; p < Mx_Detalle_ate.proparra2.length; p++) {
                    var objId = {
                        "ID_CODIGO_FONASA": Mx_Detalle_ate.proparra2[p].ID_CODIGO_FONASA,
                        "CF_COD": Mx_Detalle_ate.proparra2[p].CF_COD,
                        "CF_DESC": Mx_Detalle_ate.proparra2[p].CF_DESC,
                        "CF_DIAS": Mx_Detalle_ate.proparra2[p].CF_DIAS,
                        "ID_PER": Mx_Detalle_ate.proparra2[p].ID_PER,
                        "HO_CC": Mx_Detalle_ate.proparra2[p].ATE_NUM_AVIS
                    };
                    Mx_Dtt_examcof.push(fnClone(objId));
                    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                }
              
                fill_llenado_tabla();

            }
            


       
   
            
       
            //Ajax_Examens_avis();
        };
        function Fill_DL_Rut() {

            var fff = Mx_Dtt2[0].HO_FechaNacimiento;
            var ffmm = moment(fff).format("DD-MM-YYYY");

            var sexo = 0;
            if (Mx_Dtt2[0].HO_Sexo = "M") {
                sexo = 1;
            } else {
                sexo = 2;
            }
            $("#Nacio").val(1);
            $("#Nom").val(Mx_Dtt2[0].HO_Nombres);
            $("#Ape").val(Mx_Dtt2[0].HO_ApellidoPaterno + " " + Mx_Dtt2[0].HO_ApellidoMaterno);
            $("#fecha").val(ffmm);
            $("#Edad").val(function () {
                var asd = ffmm;
                var array = asd.split("-");
                var total = "";
                var dia = array[0];
                var mes = array[1];
                var ano = array[2];
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
                if (ahora_mes > mes)
                    meses = ahora_mes - mes;
                if (ahora_mes < mes)
                    meses = 12 - (mes - ahora_mes);
                if (ahora_mes == mes && dia > ahora_dia)
                    meses = 11;
                // calculamos los dias
                var dias = 0;
                total = String(edad + " Años");
                if (ahora_dia > dia) {
                    dias = ahora_dia - dia;
                    total = String(edad + " Años");
                }
                if (ahora_dia < dia) {
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                    total = String(edad + " Años");
                }
                return total
            });
            $("#sex").val(sexo);//
            if (sexo == 2) {
                $('#checkBox2').removeAttr("disabled");
            }

            $("#telfijo").val(Mx_Dtt2[0].HO_TelefonoPaciente);
            Ajax_DataTable_examen02();
            $("#Email").val(Mx_Dtt2[0].ID_PROGRA);


            let drLng = $("#Doctor option").length;
            let strAVIS = Mx_Dtt2[0].HO_NombreMedico;
            let DocStat = false;
            let regeX = new RegExp(`${strAVIS.replace(/\s+/g, "\\s+")}`, `gi`);
            for (i = 0; i < drLng; i++) {
                let Sel_Val = $("#Doctor option").eq(i).text();
                if (Sel_Val.match(regeX) != null) {
                    $("#Doctor option").eq(i).prop('selected', true);
                    DocStat = true;
                    break;
                }
            }
            if (DocStat == false) {
                creardoctor(Mx_AVIS[0].HO_CC);
            }

            var asd = Mx_Dtt2[0].HO_COD_DIAG;
            var array = asd.split("|");
            var COD = array[0];
            var DIAG = array[2];
            Ajax_DLdiag(array[1]);
            Ajax_DLdiag2(array[0]);

            //if (Mx_Dtt2[0].ID_DIAGNOSTICO == null) {
            //    $("#DdlDiagnostico").val(1);
            //} else {
            //    $("#DdlDiagnostico").val(Mx_Dtt2[0].ID_DIAGNOSTICO);
            //}

            //$("#Diag").val(DIAG);

            MX_HO_ExamenCodigo.length = 0;

            for (x = 0; x < Mx_Dtt2.length; x++) {
                switch (x) {
                    case 0:
                        var objId = {
                            "Examen": Mx_Dtt2[x].HO_ExamenCodigo,
                            "HO_CC": Mx_Dtt2[x].HO_CC
                        };
                        MX_HO_ExamenCodigo.push(fnClone(objId));
                        break;
                    default:
                        if (Mx_Dtt2[x].HO_ExamenCodigo != Mx_Dtt2[x - 1].HO_ExamenCodigo) {
                            var objId = {
                                "Examen": Mx_Dtt2[x].HO_ExamenCodigo,
                                "HO_CC": Mx_Dtt2[x].HO_CC
                            };
                            MX_HO_ExamenCodigo.push(fnClone(objId));
                        }
                }
            }
            console.log(JSON.stringify(MX_HO_ExamenCodigo));
            var ftler = Array();
            var hash = {};
            MX_HO_ExamenCodigo = MX_HO_ExamenCodigo.filter(function (current) {
                var exists = !hash[current.Examen] || false;
                hash[current.Examen] = true;
                return exists;
            });
            //for (x = 0; x < MX_HO_ExamenCodigo.length; x++) {   
            //    for (y = 0; y < ftler.length; y++) {
            //        if (MX_HO_ExamenCodigo[x].Examen == ftler[y].Examen) {
            //            if (MX_HO_ExamenCodigo[x].HO_CC < ftler[y].HO_CC) {
            //                MX_HO_ExamenCodigo.splice(x, 1);
            //            }
            //        }
            //    }
            //}
            var obj_RUT2 = Valid_RUT($("#rut").val());
            $("#rut").val(obj_RUT2.Format);
            Ajax_Examens_avis();
        };

        function buscar_avis23(dddd) {
            $('#rut').val("");
            $("#Nom").val("");
            $("#Ape").val("");
            $("#Edad").val("");
            $("#sex").val(0);//
            $("#DataTable_pac2 tbody").empty();
            //$("#Nacio").val(Mx_AVIS[0].ID_NACIONALIDAD);
            $("#telfijo").val("");
            //$("#Celular").val(Mx_AVIS[0].PAC_MOVIL1);
            $("#Diag2").val("");
            $("#Diag").val("");
            //$("#direccion").val(Mx_AVIS[0].PAC_DIR);
            $("#Email").val("");
            modal_show();
            var Data_Par = JSON.stringify({
                "AVIS": dddd
            });
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS_2.aspx/Llenar_AVIS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_AVIS = JSON.parse(json_receiver);
                        $("#DataTable_pac2 tbody").empty();
                        add_row();

                        Fill_DL_AVIS();
                        $('#eModal_Sinrut').modal('hide');
                        Hide_Modal();
                        verrut = 1;
                    } else {
                        Hide_Modal();
                        $("#mError_AAH").modal('hide');
                        var str_Error = "El N° ingresado no pertenece a un paciente AVIS";
                        $("#title").text("N° AVIS no encontrado :");
                        $("#button_modal").attr("class", "btn btn-danger");

                        $("#mError_AAH p").text(str_Error);
                        $("#mError_AAH").modal();
                        verrut = 0;
                        MX_HO_ExamenCodigo.length = 0;
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }
        function Fill_DL_AVIS() {
            var fff = Mx_AVIS[0].HO_FechaNacimiento;
            var ffmm = moment(fff).format("DD-MM-YYYY");

            var sexo = 0;
            if (Mx_AVIS[0].HO_Sexo == "M") {
                sexo = 1;
            } else {
                sexo = 2;
            }
            $('#rut').val(Mx_AVIS[0].HO_RutPaciente);
            var obj_RUT3 = Valid_RUT($("#rut").val());
            $("#rut").val(obj_RUT3.Format);
            Mx_AVIS[0].HO_Nombres = `${Mx_AVIS[0].HO_Nombres}`.replace(/\s+/gi, " ");
            Mx_AVIS[0].HO_Nombres = Mx_AVIS[0].HO_Nombres.trim();

            $("#Nom").val(Mx_AVIS[0].HO_Nombres);
            $("#Ape").val(Mx_AVIS[0].HO_ApellidoPaterno.trim() + " " + Mx_AVIS[0].HO_ApellidoMaterno.trim());
            $("#fecha").val(ffmm);
            $("#Edad").val(function () {
                var asd = ffmm;
                var array = asd.split("-");
                var total = "";
                var dia = array[0];
                var mes = array[1];
                var ano = array[2];
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
                if (ahora_mes > mes)
                    meses = ahora_mes - mes;
                if (ahora_mes < mes)
                    meses = 12 - (mes - ahora_mes);
                if (ahora_mes == mes && dia > ahora_dia)
                    meses = 11;
                // calculamos los dias
                var dias = 0;
                total = String(edad + " Años");
                if (ahora_dia > dia) {
                    dias = ahora_dia - dia;
                    total = String(edad + " Años");
                }
                if (ahora_dia < dia) {
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                    total = String(edad + " Años");
                }
                return total
            });
            $("#sex").val(sexo);//

            let drLng = $("#Doctor option").length;
            let strAVIS = Mx_AVIS[0].HO_NombreMedico;
            let DocStat = false;
            let regeX = new RegExp(`${strAVIS.replace(/\s+/g, "\\s+")}`, `gi`);
            for (i = 0; i < drLng; i++) {
                let Sel_Val = $("#Doctor option").eq(i).text();                 
                if (Sel_Val.match(regeX) != null) {
                    $("#Doctor option").eq(i).prop('selected', true);
                    DocStat = true;
                    break;
                }
            }
            if (DocStat == false) {
                creardoctor(Mx_AVIS[0].HO_CC);
            }

            if (sexo == 2) {
                $('#checkBox2').removeAttr("disabled");
            }
            var asd = Mx_AVIS[0].HO_COD_DIAG;
            var array = asd.split("|");
            var COD = array[0];
            var DIAG = array[2];
            Ajax_DLdiag(array[1]);
            Ajax_DLdiag2(array[0]);
            Ajax_DataTable_examen02();
            //if (Mx_AVIS[0].ID_DIAGNOSTICO == null) {
            //    $("#DdlDiagnostico").val(1);
            //} else {
            //    $("#DdlDiagnostico").val(Mx_AVIS[0].ID_DIAGNOSTICO);
            //}
            $("#Nacio").val(1);
            $("#telfijo").val(Mx_AVIS[0].HO_TelefonoPaciente);
            //$("#Celular").val(Mx_AVIS[0].PAC_MOVIL1);
            //$("#direccion").val(Mx_AVIS[0].PAC_DIR);
            $("#Email").val(Mx_AVIS[0].HO_EmailPaciente);

            //////////////if (Mx_AVIS[0].ID_PROGRA != "") {
            //////////////    $("#Programa").val(Mx_AVIS[0].ID_PROGRA);
            //////////////}

            var id_diagnostico = 0;


            $("#Diag").val(DIAG);
            ///preparar matrix de examenes
            MX_HO_ExamenCodigo.length = 0;

            for (x = 0; x < Mx_AVIS.length; x++) {
                switch (x) {
                    case 0:
                        var objId = {
                            "Examen": Mx_AVIS[x].HO_ExamenCodigo,
                            "HO_CC": Mx_AVIS[x].HO_CC
                        };
                        MX_HO_ExamenCodigo.push(fnClone(objId));
                        break;
                    default:
                        if (Mx_AVIS[x].HO_ExamenCodigo != Mx_AVIS[x - 1].HO_ExamenCodigo) {
                            var objId = {
                                "Examen": Mx_AVIS[x].HO_ExamenCodigo,
                                "HO_CC": Mx_AVIS[x].HO_CC
                            };
                            MX_HO_ExamenCodigo.push(fnClone(objId));
                        }
                }
            }
            console.log(JSON.stringify(MX_HO_ExamenCodigo));
            var ftler = Array();
            var hash = {};
            MX_HO_ExamenCodigo = MX_HO_ExamenCodigo.filter(function (current) {
                var exists = !hash[current.Examen] || false;
                hash[current.Examen] = true;
                return exists;
            });
            //for (x = 0; x < MX_HO_ExamenCodigo.length; x++) {   
            //    for (y = 0; y < ftler.length; y++) {
            //        if (MX_HO_ExamenCodigo[x].Examen == ftler[y].Examen) {
            //            if (MX_HO_ExamenCodigo[x].HO_CC < ftler[y].HO_CC) {
            //                MX_HO_ExamenCodigo.splice(x, 1);
            //            }
            //        }
            //    }
            //}
            Ajax_Examens_avis();
        }
        function Fill_AJAX_Ddl() {
            $("#Procedencia").empty();
            var PREVT = getParameterByName('ID_PREV');
            var procee = Galletas.getGalleta("USU_TM");
            if (procee == 0) {
                Mx_Ddl.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Procedencia");
                });




                $("#Procedencia").val(PREVT);
                kmmjk.callbuck();
            }
            else {
                Mx_Ddl.forEach(aaa => {
                    if (aaa.ID_PROCEDENCIA == procee) {
                        $("<option>",
                          {
                              "value": aaa.ID_PROCEDENCIA
                          }
                       ).text(aaa.PROC_DESC).appendTo("#Procedencia");
                    }

                });

                $("#Procedencia").val(PREVT);
            }


            Ajax_DataTable();


        };

        //-----------------------------------------------------------------------------------------------------/
        //Llenar DropDownList Ciudad
        function Fill_Ddl_Cuidad() {
            $("#Cuidad").empty();
            for (y = 0; y < Mx_Ciudad.length; ++y) {
                $("<option>", {
                    "value": Mx_Ciudad[y].ID_CIUDAD
                }).text(Mx_Ciudad[y].CIU_DESC).appendTo("#Cuidad");
            }

        };
        //Llenar DropDownList Comuna
        function Fill_Ddl_Comuna() {
            $("#Comuna").empty();
            for (y = 0; y < Mx_Comuna.length; ++y) {
                $("<option>", {
                    "value": Mx_Comuna[y].ID_REL_CIU_COM
                }).text(Mx_Comuna[y].COM_DESC).appendTo("#Comuna");
            }
            kmmjk.callbuck();
        };
        //-------------------------------------------------------------------------------------------------------/


        function Fill_DL_SEXO() {
            $("#sex").empty();

            $("<option>", {
                "value": 0
            }).text("Seleccionar").appendTo("#sex");
            for (y = 0; y < Mx_DL_SEXO.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_SEXO[y].ID_SEXO
                }).text(Mx_DL_SEXO[y].SEXO_DESC).appendTo("#sex");
            }

            if (Mx_Detalle_ate.proparra1[0].SEXO_DESC == "Masculino") {
                $("#sex").val(1);//

            } else {
                $("#sex").val(2);//
                $('#checkBox2').removeAttr("disabled");
            }
        };
        function Fill_DL_NAC() {
            $("#Nacio").empty();

            $("<option>", {
                "value": 0
            }).text("Seleccionar").appendTo("#Nacio");
            for (y = 0; y < Mx_DL_NAC.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_NAC[y].ID_NACIONALIDAD
                }).text(Mx_DL_NAC[y].NAC_DESC).appendTo("#Nacio");
            }
            $("#Nacio").val(Mx_Detalle_ate.proparra1[0].id_Nacionalidad);
        };

        /// llenado examenes modal
        function Fill_DataTable_exam02() {
            $("#Div_Tabla2").empty();
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
            $("#DataTable_pac").attr("class", "table table-striped table-hover table-iris");
            $("#DataTable_pac thead").attr("class", "cabzera");
            $("#DataTable_pac thead").append(
                $("<tr>").append(

                    $("<th>", { "class": "textoReducido" }).text("Nº"),
                    $("<th>", { "class": "textoReducido" }).text("Codigo"),
                    $("<th>", { "class": "textoReducido" }).text("Descripcion"),
                    $("<th>", { "class": "textoReducido" }).text("Valor Ambulatorio"),
                    $("<th>", { "class": "textoReducido" }).text("Carga")

                )
            );
            //if ($("#sex").val() != 0) {
            //    var posicion = 0;
            //    if ($("#sex").val() == 1) {
            //        for (x = 0; x < Mx_Dtt_exam02.length; x++) {
            //            if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 1026) {
            //                posicion = x;
            //            }
            //        }
            //        Mx_Dtt_exam02.splice(posicion, 1);
            //    } else {
            //        for (x = 0; x < Mx_Dtt_exam02.length; x++) {
            //            if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 66) {
            //                posicion = x;
            //            }
            //        }

            //        Mx_Dtt_exam02.splice(posicion, 1);
            //    }
            //}
            for (i = 0; i < Mx_Dtt_exam02.length; i++) {
                $("#DataTable_pac tbody").append(
                    $("<tr>", {
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
                        }).text(Mx_Dtt_exam02[i].CF_COD),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).text(Mx_Dtt_exam02[i].CF_DESC),
                       $("<td>", {
                           "align": "center",
                           "class": "textoReducido"
                       }).text(Mx_Dtt_exam02[i].CF_PRECIO_AMB),
                    $("<td>", {
                        "align": "center",
                        "class": "textoReducido"
                    }).html("<div class='checkbox checkbox-success pp' style='margin-top:-5px;'><input type='checkbox' class='manitos2' id='H" + i + "' value='" + Mx_Dtt_exam02[i].ID_CODIGO_FONASA + "' /><label class='manitos2' for='H" + i + "'></label></div>")
                    )
                )
            }
            $("#DataTable_pac").DataTable({
                "searching": true,
                "iDisplayLength": 100,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
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
        ///llenar check  selecciondas
        function fill_llenado_tabla() {
            $("#DataTable_pac2 tbody").empty();
            for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                $("#DataTable_pac2 tbody").append(
                    $("<tr>", {
                        "class": "textoReducido manito",
                        "padding": "1px !important",
                    }).append(
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                                "data-cod": Mx_Dtt_examcof[i].CF_COD,
                                "class": "td_input",
                                "value": Mx_Dtt_examcof[i].CF_COD
                            })
                        }())),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido td_val1"
                        }).text(Mx_Dtt_examcof[i].CF_DESC),
                       $("<td>", {
                           "align": "center",
                           "class": "textoReducido td_val2"
                       }).text(Mx_Dtt_examcof[i].CF_DIAS),
                       $("<td>", {
                           "align": "center"
                                             }).html(function () {
                                                 var admin = Galletas.getGalleta("P_ADMIN");
                                                 if (admin == 1) {
                                                     return "<button type='button' class='btn btn-default btn-xs borrar' value='Eliminar' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"
                                                 } else {
                                                     return "<button type='button' class='btn btn-default btn-xs borrar' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;' disabled='disabled'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"
                                                 }

                          
                                             }),
                         $("<td>", {
                             "align": "center"
                         }).html(function () {
                             if (Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN == "Activo") {
                                 return "<button type='button' class='btn btn-print btn-xs CEstado' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>"
                             } else {
                                 return "<button type='button' class='btn btn-success btn-xs Activado' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Activo</button>"
                             }
                         }())
                    )
                )
            }
            add_row();
        }
        function success(xxid, xxcod, xtxis) {
            if (Mx_Dtt_exam03.length == 0) {
                $("input[data-id='" + xxid + "']").val(xxcod);
            } else if (Mx_Dtt_exam03.length == 1) {

                var repetido = 0;
                for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == Mx_Dtt_exam03[0].ID_CODIGO_FONASA) {
                        repetido++
                    }
                }
                if (repetido == 0) {
                    if (xxid != 0) {
                        Mx_Dtt_examcof.push(Mx_Dtt_exam03[0]);
                        for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                            if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == xxid) {
                                Mx_Dtt_examcof.splice(i, 1);
                            }
                        }

                    }

                    $("input[data-id='" + xxid + "']").val(Mx_Dtt_exam03[0].CF_COD);
                    $("input[data-id='" + xxid + "']").parent().parent().children(".td_val1").text(Mx_Dtt_exam03[0].CF_DESC);
                    $("input[data-id='" + xxid + "']").parent().parent().children(".td_val2").text(Mx_Dtt_exam03[0].CF_DIAS);
                    $("input[data-id='" + xxid + "']").attr("data-cod", Mx_Dtt_exam03[0].CF_COD);
                    $("input[data-cod='" + Mx_Dtt_exam03[0].CF_COD + "']").attr("data-id", Mx_Dtt_exam03[0].ID_CODIGO_FONASA);
                    Mx_Dtt_examcof.push(Mx_Dtt_exam03[0]);
                    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                    add_row();
                } else {
                    $("input[data-id='" + xxid + "']").val(xxcod);
                }
            } else if (Mx_Dtt_exam03.length > 1) {

                $("#Div_Tabla4").empty();
                $("<table>", {
                    "id": "DataTable_pac3",
                    "class": "display",
                    "width": "100%",
                    "cellspacing": "0"
                }).appendTo("#Div_Tabla4");

                $("#DataTable_pac3").append(
                    $("<thead>"),
                    $("<tbody>")
                );
                $("#DataTable_pac3").attr("class", "table table-hover table-striped table-iris table-iris");
                $("#DataTable_pac3 thead").attr("class", "cabzera");
                $("#DataTable_pac3 thead").append(
                    $("<tr>").append(

                        $("<th>", { "class": "textoReducido" }).text("Nº"),
                        $("<th>", { "class": "textoReducido" }).text("Codigo"),
                        $("<th>", { "class": "textoReducido" }).text("Descripcion"),
                        $("<th>", { "class": "textoReducido" }).text("Valor Ambulatorio"),
                        $("<th>", { "class": "textoReducido" }).text("Carga")

                    )
                );
                for (i = 0; i < Mx_Dtt_exam03.length; i++) {
                    $("#DataTable_pac3 tbody").append(
                        $("<tr>", {
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
                            }).text(Mx_Dtt_exam03[i].CF_COD),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).text(Mx_Dtt_exam03[i].CF_DESC),
                           $("<td>", {
                               "align": "center",
                               "class": "textoReducido"
                           }).text(Mx_Dtt_exam03[i].CF_PRECIO_AMB),
                        $("<td>", {
                            "align": "center",
                            "class": "textoReducido"
                        }).html("<div class='checkbox checkbox-success sub_pp' style='margin-top:-5px;'><input type='checkbox' class='manitos2' id='F" + i + "' value='" + Mx_Dtt_exam03[i].ID_CODIGO_FONASA + "' /><label class='manitos2' for='F" + i + "'></label></div>")
                        )
                    )

                }
                $('#XXXXXXXX').addClass('XCVB');
                $("#eModal3").modal();
            }
        }
        function Ajax_N_PACIENTE(orden) {
            $("#Avis").val(orden);

            buscar_avis23(orden);

        }
        //Llenar DropDownList Diagnostico
        function Fill_Ddl_diagnostico() {
            $("#DdlDiagnostico").empty();
            for (y = 0; y < Mx_Diagnostico.length; ++y) {
                $("<option>", {
                    "value": Mx_Diagnostico[y].ID_DIAGNOSTICO
                }).text(Mx_Diagnostico[y].DIA_DESC).appendTo("#DdlDiagnostico");
            }
            //$("#DdlDiagnostico").val(1);
            kmmjk.callbuck();
        };
    </script>
    <style>
        .alertas {
            margin-top: 180px;
            text-align: center;
        }

        .manitos2 {
            cursor: pointer;
        }

        .textoReducido {
            font-size: 11px;
        }

        .ancho-columna {
            height: 10%;
            padding: -35px;
        }

        .highlights {
            width: 100%;
            height: 300px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .highlights2 {
            width: 100%;
            height: 300px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .topbuttom {
            display: block;
            height: 80px;
            width: 100%;
        }

        .topbuttom2 {
            display: block;
            height: 80px;
        }

        .textbot {
            display: block;
            height: 22px;
            width: 100%;
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
         #XXXXXXXX {
            z-index:9000;
            width:100%;
            position:fixed;
            left: 0px;
            top:0px;
            display:flex;
            display:-webkit-flex;
            flex-flow:row nowrap;
            justify-content:center;      
            color: #444;
            border: 0;
            border-radius: 2px;
            text-decoration: none;
            transition: opacity 0.2s ease-out;
            opacity: 0;
            margin-top: 60px;
      
        }
         
     .XCVB{

         margin-top:500px !important;
     }
        #XXXXXXXX div
        {
              font-size: 18px;
              border: none;
              outline: none;
              background-color: #014B5D;
              color: white;           
              padding: 8px;
              border-radius: 4px;
              font-size: 15px;
        }

     

            #XXXXXXXX.show {
                opacity: 1;
            }

        #content {
            height: 2000px;
        }

        @media screen and (min-width: 558px) {
            .topbuttom2 {
                width: 100%;
            }
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
                <div id="modalpccc" class="modal-body">
                </div>
                <div class="modal-footer">
                    <button type="button" id="b" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                    <button type="button" id="button_modal_pago" class="btn btn-success" data-dismiss="modal">Imprimir</button>
                </div>
            </div>
        </div>
    </div>
           <!-- Modal -->
    <div id="mError_AAH2" class="modal fade" role="dialog">
        <div class="modal-dialog ml-xl-auto">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 id="title8" class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">
                    <button type="button" id="button_modal2" class="btn btn-success" data-dismiss="modal">SI</button>
                    <button type="button" id="button_modal3" class="btn btn-danger" data-dismiss="modal">NO</button>
                </div>
            </div>
        </div>
    </div>
 <div id="XXXXXXXX" class="tobackinfo">
  <div id="xxx_xxx">
    
  </div>
  </div>
     <div class="modal fade" id="eModal_Sinrut" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="xsdf">Listado de pacientes sin rut Avis</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="col-md-12">
                            <div id="Div_Tabla45" style="width: 100%;" class="highlights2"></div>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
<%--                    <button type="button" id="btnguardar" class="btn btn-success">Cargar</button>--%>
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

    <div class="modal fade" id="eModal3" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss5">Agregar Exámenes</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="col-md-12">
                            <div id="Div_Tabla4" style="width: 100%;" class="highlights2"></div>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btnexarepetido" class="btn btn-success">Cargar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="eModal2" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Agregar Exámenes</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="col-md-12">
                            <div id="Div_Tabla2" style="width: 100%;" class="highlights2"></div>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btnguardar" class="btn btn-success">Cargar</button>
                </div>
            </div>
        </div>
    </div>
    
     <div id="mError_AAH2_3" class="modal fade" role="dialog">
        <div class="modal-dialog ml-xl-auto">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 id="title988" class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p id="p1"></p>
                      <p id="p2"></p>
                      <p id="p3"></p>
                      <p id="p4"></p>
                            <p id="p5"></p>
                </div>
                <div class="modal-footer">
                    <button type="button" id="button_modal2_3" class="btn btn-success" data-dismiss="modal">CERRAR</button>
            <%--        <button type="button" id="button_modal3_3" class="btn btn-danger" data-dismiss="modal">NO</button>--%>
                </div>
            </div>
        </div>
    </div>
    <!-- Breadcrumbs -->

    <div class="card border-bar">
        <div class="card-header bg-bar p-2">
            <h5 style="text-align: center; padding: 5px;">
                <i class="fa fa-sign-in"></i>
                Ingresos de Exámenes Avis
            </h5>
        </div>
        <div class="card-body p-3">
            <div class="container" style="max-width: 100%;">
                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-lg">
                               <label class="textoReducido">N° AVIS:</label>
                                <div class="input-group" style="height: 31.75px;">
                                    <input type="text" id="Avis" class="form-control textoReducido" placeholder="Numero AVIS" />
                                    <span class="input-group-btn">                                    
                                         <button id="agregar_op" type="button" class="btn btn-info" data-toggle="tooltip" data-placement="right" title="Agregar nuevo folio al paciente actual" style="font-size: 12px;"><i class="fa fa-plus-circle"></i></button>
                                
                                    </span>
                                    
                                </div>
                            </div>
                            <div class="col-sm">
                                <label class="textoReducido">RUT:</label>
                               
                            <div class="input-group" style="height: 31.75px;">
                                    <input type='text' id="rut" class="form-control textoReducido" placeholder="12.345.789-0" />
                                    <span class="input-group-btn">
                                        <button id="X_SIN_RUT" class="btn btn-success" type="button" style="font-size: 11px;">Sin RUT</button>                                       
                                    </span>
                                    
                                </div>
                            </div>

                            <div class="col-lg">
                                <label class="textoReducido">Nombres:</label>
                                <input type='text' id="Nom" class="form-control textoReducido" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Apellidos:</label>
                                <input type='text' id="Ape" class="form-control textoReducido" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">F.Nacimiento:</label>
                                <div class='input-group date' id='datetimepicker1' style="margin-bottom: 1vh;">
                                    <input type='text' id="fecha" class="form-control textoReducido" readonly="true" placeholder="Fecha" />
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

                            <div class="col-lg">
                                <label class="textoReducido">Edad:</label>
                                <input type='text' id="Edad" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="text-align: center;" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-lg">
                                <label class="textoReducido">Sexo:</label>
                                <select id="sex" class="form-control textoReducido" style="height: 31.75px;">
                                </select>
                            </div>
                            <div class="col-lg checkbox checkbox-success">
                                <input id="checkBox2" type="checkbox" value="SoyFur" />
                                <label for="checkBox2" class="textoReducido">F.U.R:</label>
                                <div class='input-group date' id='datetimepicker3' style="margin-bottom: 1vh;">
                                    <input type='text' id="FUR" class="form-control textoReducido" readonly="true" placeholder="Fecha" />
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
                                        $('#datetimepicker3').datetimepicker(
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
                            <div class="col-lg">
                                <label class="textoReducido">Nacionalidad:</label>
                                <select id="Nacio" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Tel. Fijo:</label>
                                <input type='text' id="telfijo" class="form-control textoReducido" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Celular:</label>
                                <input type='text' id="Celular" class="form-control textoReducido" placeholder="" />
                            </div>


                            <div class="col-lg">
                                <label class="textoReducido">Ciudad:</label>
                                <select id="Cuidad" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="0">Seleccionar</option>
                                </select>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-lg">
                                <label class="textoReducido">Comuna:</label>
                                <select id="Comuna" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="0">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Nº interno:</label>
                                <input type='text' id="interno" class="form-control textoReducido" placeholder="" style="background-color:#87f0ff;"/>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Dirección:</label>
                                <input type='text' id="direccion" class="form-control textoReducido" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Email:</label>
                                <input type='text' id="Email" class="form-control textoReducido" placeholder="Irislab@irislab.cl" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">observacion:</label>
                                <input type='text' id="Diag" class="form-control textoReducido" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Diagnostico 1:</label>
                                <input type='text' id="Diag2" class="form-control textoReducido" placeholder="" disabled="disabled" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Diagnostico 2:</label>
                                <input type='text' id="Diag3" class="form-control textoReducido" placeholder="" disabled="disabled" />
                            </div>
                            <%--                        <div class="col-sm">
                            <label class="textoReducido">Diagnostico 2:</label>
                         <select id="DdlDiagnostico" class="form-control textoReducido" style="height: 31.75px;">
                                <option value="0">Seleccionar</option>
                            </select>
               
                        </div>
                         <div class="col-sm">
                            <label class="textoReducido">Diagnostico 2:</label>
                         <select id="DdlDiagnostico2" class="form-control textoReducido" style="height: 31.75px;">
                                <option value="0">Seleccionar</option>
                            </select>
               
                        </div>--%>
                        </div>


                    </div>
                </div>
            </div>
            <hr />
            <h5 style="text-align: center; padding: 5px;">Antecedentes de la Atención </h5>
            <div class="container" style="max-width: 100%;">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="row">
                            <div class="col-lg">
                                <label class="textoReducido">Procedencia:</label>
                                <select id="Procedencia" class="form-control textoReducido" style="height: 31.75px;" disabled="disabled">
                                    <option value="0">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Doctor:</label>
                                <select id="Doctor" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Tipo de Atención:</label>
                                <select id="TipoAtencion" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                     <div class="col-sm">
                            <label class="textoReducido">Cupo Normal:</label>
                            <input type='text' id="Total" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="background-color: yellow; text-align: center;" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Prioritario:</label>
                            <input type='text' id="Actuales" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="background-color: #f4abe7; text-align: center;" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Espontáneo:</label>
                            <input type='text' id="Disponibles" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="background-color: chartreuse; text-align: center;" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Sub-Atención:</label>
                            <select id="sub_atencion" class="form-control textoReducido" style="height: 31.75px; background-color:#87f0ff;">
                                <option value="0">Seleccionar</option>
                                <option value="1">Agendado Cupo normal</option>
                                <option value="5">Agendado Sobre Cupo</option>    
                                <option value="2">Agendado Prioritario</option>
                                <option value="3">Agendado Espontáneo</option>
                                <option value="4">Agendado (PAP)</option>     
                                                             
                            </select>
                        </div>
                            <div class="col-lg">
                                <label class="textoReducido">Programa:</label>
                                <select id="Programa" class="form-control textoReducido" style="height: 31.75px; background-color:#87f0ff;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Sector:</label>
                                <select id="Sector" class="form-control textoReducido" style="height: 31.75px; background-color:#87f0ff;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-lg">
                                <label class="textoReducido">Localizacion:</label>
                                <select id="Localizacion" class="form-control textoReducido" style="height: 31.75px;" disabled="disabled">
                                    <option value="volvo">TOMA DE MUESTRA</option>
                                </select>
                            </div>
                            <div class="col-lg-1">
                                <label class="textoReducido">Cama:</label>
                                <input type='text' id="cama" class="form-control textoReducido" placeholder="0" disabled="disabled" value="0" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Grupo Riesgo VIH</label>
                                <select id="ddl_new_vih" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="0">Seleccione</option>
                                    <option value="1">GESTANTES PRIMER EXAMEN</option>
                                    <option value="2">GESTANTES SEGUNDO EXAMEN</option>
                                    <option value="3">MUJER EN TRABAJO DE PRE PARTO O PARTO</option>
                                    <option value="4">PERSONAS EN CONTROL POR COMERCIO SEXUAL</option>
                                    <option value="5">PACIENTES EN DIÁLISIS</option>
                                    <option value="6">POR CONSULTA ITS</option>
                                    <option value="7">PERSONAS EN CONTROL FECUNDIDAD, GINECOLOGICO, CLIMATERIO</option>
                                    <option value="8">PERSONAS CON EMP</option>
                                    <option value="9">PERSONAS EN CONTROL DE SALUD SEGÚN CICLO VITAL</option>
                                    <option value="10">DONANTE ALTRUISTA NUEVO</option>
                                    <option value="11">DONANTE ALTRUISTA REPETIDO</option>
                                    <option value="12">DONANTE FAMILIAR O REPOSICIÓN</option>
                                    <option value="13">DONANTES DE ÓRGANOS Y/O TEJIDOS</option>
                                    <option value="14">PERSONA EN CONTROL POR TBC</option>
                                    <option value="15">VÍCTIMA DE VIOLENCIA SEXUAL</option>
                                    <option value="16">PAREJA SERODISCORDANTE</option>
                                    <option value="17">PAREJA DE GESTANTE VIH POSITIVO</option>
                                    <option value="18">PERSONAL DE SALUD EXPUESTO A ACCIDENTE CORTOPUNZANTE</option>
                                    <option value="19">PACIENTES FUENTE DE ACCIDENTE CORTOPUNZANTE</option>
                                    <option value="20">PERSONA EN CONTROL POR HEPATITIS B</option>
                                    <option value="21">PERSONA EN CONTROL POR HEPATITIS C</option>
                                    <option value="22">CONSULTANTES POR MORBILIDAD</option>
                                    <option value="23">POR CONSULTA ESPONTÁNEA</option>
                                </select>
                            </div>
                          <div class="col-sm">
                            <label class="textoReducido">Grupo Riesgo Sífilis</label>
                                 <%--<input type='text' id="vih" class="form-control textoReducido" placeholder="" text-align: center;" />--%>
                            <select id="vih" class="form-control textoReducido" style="height: 31.75px;">
                              <option value="0">Seleccione</option>
                                    <option value="1">GESTANTES PRIMER TRIMESTRE EMBARAZO</option>
                                    <option value="2">GESTANTES SEGUNDO TRIMESTRE EMBARAZO</option>
                                    <option value="3">GESTANTES TERCER TRIMESTRE EMBARAZO</option>
                                    <option value="4">GESTANTES TRIMESTRE EMBARAZO IGNORADO</option>
                                    <option value="5">GESTANTES EN SEGUIMIENTO POR DIAGNÓSTICO SÍFILIS</option>
                                    <option value="6">PAREJA DE GESTANTE CON SEROLOGÍA REACTIVA</option>
                                    <option value="7">MUJERES QUE INGRESAN A MATERNIDAD POR PARTO</option>
                                    <option value="8">MUJERES QUE INGRESAN POR ABORTO</option>
                                    <option value="9">MUJERES EN CONTROL GINECOLÓGICO</option>
                                    <option value="10">RECIÉN NACIDO Y LACTANTE PARA DETECCIÓN DE SÍFILIS CONGÉNITA</option>
                                    <option value="11">PERSONAS EN CONTROL POR COMERCIO SEXUAL</option>
                                    <option value="12">PERSONAS EN CONTROL FECUNDIDAD</option>
                                    <option value="13">CONSULTANTES POR ITS</option>
                                    <option value="14">PERSONAS CON EMP</option>
                                    <option value="15">DONANTES DE SANGRE</option>
                                    <option value="16">DONANTES DE ÓRGANOS Y/O TEJIDOS</option>
                                    <option value="17">PACIENTES EN DIÁLISIS</option>
                                    <option value="18">VÍCTIMA DE VIOLENCIA SEXUAL</option>
                          </select>
                        </div>
                            <div class="col-lg">
                                <label class="textoReducido">Observacion de Lugar TM:</label>
                                <input type='text' id="obs_ate" class="form-control textoReducido" placeholder="" style="background-color:#87f0ff;"/>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Autorizo a Retirar:</label>
                                <input type='text' id="Autorizo_retirar" class="form-control textoReducido" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Prioridad TM:</label>
                                <select id="PrioridadTM" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>



                            <%--   </div>
                         <div class="row">--%>
                            <div class="col-sm">
                                <label class="textoReducido">Previsión:</label>
                                <select id="Prevision" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <hr />
            <h5 style="text-align: center; padding: 5px;">Agregar Exámenes</h5>
            <div class="container" style="max-width: 100%;">
                <div class="row">
                    <div class="col-sm">
                        <div id="Div_Tabla3" style="width: 100%;" class="highlights"></div>
                    </div>
                </div>

            </div>
            <div class="container" style="max-width: 100%; border: 0px solid #fff;">
                <div class="row">
                    <div class="col-sm-3">
                        <button id="Examen" type="button" class="btn btn-danger btn-block">
                            <br />
                            <i class="fa fa-align-left" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                            <p style="margin-top: 2px;">Examen</p>
                        </button>
                    </div>
                    <div class="col-sm-3">
                    </div>
                    <div class="col-sm-3" style="justify-content: flex-end;">
                        <button id="Btnnew" type="button" class="btn btn-info btn-block">
                            <br />
                            <i class="fa fa-plus-square" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                            <p style="margin-top: 2px;">Nuevo</p>
                        </button>
                    </div>
                    <div class="col-sm-3">
                        <button id="BtnSaveAll" type="button" class="btn btn-primary btn-block">
                            <br />
                            <i class="fa fa-fw fa-save mr-2" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                            <p style="margin-top: 2px;">Guardar</p>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
