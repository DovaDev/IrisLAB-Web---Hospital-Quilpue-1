<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Paciente.Master" CodeBehind="Reg_Solicitud.aspx.vb" Inherits="Resultados.Reg_Solicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
        <style>
                body {
            background: url(/Imagenes/IMAGEN_IRISHIS.jpg);
            background-size: cover;
            background-repeat: no-repeat;
        }
    </style>
    <script>
        let Id_User, Asunto = "", Formulario = "", Mensaje = "", Fecha, Est_Checkbox;
        let pais_val = 0;
        $(document).ready(function () {
            Ajax_LugarTM();
            $("#txt_pais").val("CHILE");
            $('#Chk_Chilena').click(function () {
                $("#Chk_Chilena").prop("checked", true);
                    $("#txt_pais").val("CHILE");
                    $("#txt_pais").attr("readonly", true)
                
                });
                
            $('#Chk_Extranjera').click(function () {
                $("#Chk_Extranjera").prop("checked", true);
                    $("#txt_pais").attr("readonly", false)
                    if (pais_val == 0) {
                        $("#txt_pais").val("");
                        pais_val == 1;
                    }
                
            });       
            
            $("#Chk_Chilena").prop("checked", true);
            $("#Chk_Hombre").prop("checked", true);
            $("#Chk_Consulta").prop("checked", true);

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

            //Registrar evento Click del Botón GUARDAR
            $("#Btn_Enviar").click(function () {
                var sum = 0;
                if ($("#txt_Rut").val() == "") {
                    $("#txt_Rut").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#txt_Rut").css({
                        "border-color": "green"
                    });
                }

                if ($("#txt_Nombre").val() == "") {
                    $("#txt_Nombre").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#txt_Nombre").css({
                        "border-color": "green"
                    });
                }

                if ($("#txt_Apellido").val() == "") {
                    $("#txt_Apellido").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#txt_Apellido").css({
                        "border-color": "green"
                    });
                }
                if ($("#txt_Movil").val() == "") {
                    $("#txt_Movil").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#txt_Movil").css({
                        "border-color": "green"
                    });
                }
                if ($("#txt_Email").val() == "") {
                    $("#txt_Email").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#txt_Email").css({
                        "border-color": "green"
                    });
                }
                if ($("#Ddl_LugarTM").val() == 0) {
                    $("#Ddl_LugarTM").css({
                        "border-color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Ddl_LugarTM").css({
                        "border-color": "green"
                    });
                }

                //if ($("#Ddl_Motivo").val() == 0) {
                //    $("#Ddl_Motivo").css({
                //        "border-color": "red"
                //    });
                //} else {
                //    sum += 1;
                //    $("#Ddl_Motivo").css({
                //        "border-color": "green"
                //    });
                //}
                if ($("#txt_Mensaje").val() == "") {
                    $("#txt_Mensaje").css({
                        "border-color": "red"
                    });

                } else {
                    sum += 1;
                    $("#txt_Mensaje").css({
                        "border-color": "green"
                    });
                }
                if ($("#txt_pais").val() == "") {
                    $("#txt_pais").css({
                        "border-color": "red"
                    });

                } else {
                    sum += 1;
                    $("#txt_pais").css({
                        "border-color": "green"
                    });
                }
                if (sum == 8) {
                    $("#Btn_Enviar").attr("class", "btn btn-success");
                    $("#button_modal").attr("class", "btn btn-success");
                    IRIS_WEBF_GRABA_REG_SOLICITUD()
                    
                } else {
                    $("#Btn_Enviar").attr("class", "btn btn-danger");
                }

            });

            $("#Btn_limpiar").click(function () {
                $("#txt_Rut").val("");     
                $("#txt_Rut").css({ "border-color": "#868e96" });
                
                $("#txt_Nombre").val("");
                $("#txt_Nombre").css({ "border-color": "#868e96" });

                $("#txt_Apellido").val("");
                $("#txt_Apellido").css({ "border-color": "#868e96" });

                $("#txt_Movil").val("");
                $("#txt_Movil").css({ "border-color": "#868e96" });

                $("#txt_Movil2").val("");
                $("#txt_Movil2").css({ "border-color": "#868e96" });

                $("#txt_Mensaje").val("");
                $("#txt_Mensaje").css({ "border-color": "#868e96" });

                $("#Ddl_LugarTM").val(0);
                $("#Ddl_LugarTM").css({ "border-color": "#868e96" });

                //$("#Ddl_Motivo").val(0);
                //$("#Ddl_Motivo").css({ "border-color": "#868e96" });

                $("#txt_Email").val("");
                $("#txt_Email").css({ "border-color": "#868e96" });
                
                $("#txt_pais").val("");
                $("#txt_pais").css({ "border-color": "#868e96" });
           
                $("#Btn_Enviar").attr("class", "btn btn-buscar");

                $("#Chk_Chilena").prop("checked", true);
                $("#txt_pais").val("CHILE");
                $("#txt_pais").attr("readonly", true)

                $("#Chk_Consulta").prop("checked", true);

                $("#Chk_Hombre").prop("checked",true);

            });

            $("#txt_Rut").focusout(function () {
                if ($("#txt_Rut").val() != "") {

                    //Capturar Anáqlisis del RUT
                    var obj_RUT = Valid_RUT($("#txt_Rut").val());

                    if (obj_RUT.Valid == false) {
                        var str_Error = "El RUT ingresado no es Válido, ";
                        str_Error += "ingrese en el campo de texto un RUT válido.";

                        $("#mError_AAH h5").text("Error:");
                        $("#button_modal").attr("class", "btn btn-danger");

                        $("#mError_AAH p").text(str_Error);
                        $("#mError_AAH").modal();

                        $("#txt_Rut").val("");
                        $("#txt_Rut").css({
                            "border-color": "red"
                        });
                    } else {
                        $("#txt_Rut").css({
                            "border-color": "green"
                        });
                        $("#txt_Rut").val(obj_RUT.Format);

                    }
                }
            });
        });

        function IRIS_WEBF_GRABA_REG_SOLICITUD() {
            modal_show();
            let nacionnnnn = "";
            let paisss = "";
            let sexxxxx = "";
            let motivo = "";

            if ($('#Chk_Chilena').is(':checked')) {
                nacionnnnn = "CHILENA"
                paisss = "CHILE"
            } else if ($('#Chk_Extranjera').is(':checked')) {
                nacionnnnn = "EXTRANJERA"
                paisss = $("#txt_Pais").val();
            }

            if ($('#Chk_Hombre').is(':checked')) {
                sexxxxx = "HOMBRE"
            } else if ($('#Chk_Mujer').is(':checked')) {
                sexxxxx = "MUJER"
            } else if ($('#Chk_Otro').is(':checked')) {
                sexxxxx = "OTRO"
            }

            if ($("#Chk_Consulta").is(":checked")) {
                motivo = "Consulta";
            } else if ($("#Chk_Sugerencia").is(":checked")) {
                motivo = "Sugerencia";
            } else if ($("#Chk_Felicitaciones").is(":checked")) {
                motivo = "Felicitaciones";
            } else if ($("#Chk_Reclamo").is(":checked")) {
                motivo = "Reclamo";
            }

            var Data_Par = JSON.stringify({
                "RUT": $("#txt_Rut").val(),
                "NOMBRE": $("#txt_Nombre").val(),
                "APELLIDO": $("#txt_Apellido").val(),
                "NACIONALIDAD": nacionnnnn,
                "FECHA_NAC": $("#Txt_Date01 input").val(),
                "SEXO": sexxxxx,
                "MOVIL": $("#txt_Movil").val(),
                "MOVIL2": $("#txt_Movil2").val(),
                "EMAIL": $("#txt_Email").val(),
                "LUGARTM": $("#Ddl_LugarTM option:selected").text(),
                "MOTIVO": motivo,//$("#Ddl_Motivo option:selected").text(),
                "FECHA_EVENTO": $("#Txt_Date02 input").val(),
                "MENSAJE": $("#txt_Mensaje").val(),
                "PAIS": $("#txt_pais").val()

            });


            $.ajax({
                "type": "POST",
                "url": "Reg_Solicitud.aspx/IRIS_WEBF_GRABA_REG_SOLICITUD",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        //Mx_Dtt_LugarTM = JSON.parse(json_receiver);

                        //Fill_Ddl_LugarTM();

                        $("#txt_Rut").val("");
                        $("#txt_Rut").css({ "border-color": "#868e96" });

                        $("#txt_Nombre").val("");
                        $("#txt_Nombre").css({ "border-color": "#868e96" });

                        $("#txt_Apellido").val("");
                        $("#txt_Apellido").css({ "border-color": "#868e96" });

                        $("#txt_Movil").val("");
                        $("#txt_Movil").css({ "border-color": "#868e96" });
            
                        $("#txt_Movil2").val("");
                        $("#txt_Movil2").css({ "border-color": "#868e96" });
                        
                        $("#txt_Mensaje").val("");
                        $("#txt_Mensaje").css({ "border-color": "#868e96" });

                        $("#Ddl_LugarTM").val(0);
                        $("#Ddl_LugarTM").css({ "border-color": "#868e96" });

                        //$("#Ddl_Motivo").val(0);
                        //$("#Ddl_Motivo").css({ "border-color": "#868e96" });

                        $("#txt_Email").val("");
                        $("#txt_Email").css({ "border-color": "#868e96" });

                        $("#txt_pais").val("");
                        $("#txt_pais").css({ "border-color": "#868e96" });

                        $("#Btn_Enviar").attr("class", "btn btn-buscar");
                        
                        Hide_Modal();

                        $("#mError_AAH h4").text("Solicitud enviada");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("Su solicitud ha sido enviada correctamente.");
                        $("#mError_AAH").modal();
                    } else {


                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
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


            $.ajax({
                "type": "POST",
                "url": "Reg_Solicitud.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_LugarTM = JSON.parse(json_receiver);

                        Fill_Ddl_LugarTM();

                    } else {


                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
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

        //Llenar DropDownList Lugar de TM
        function Fill_Ddl_LugarTM() {
            $("#Ddl_LugarTM").empty();

            $("<option>", { "value": "0" }).text("Seleccione").appendTo("#Ddl_LugarTM");

                Mx_Dtt_LugarTM.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                });
            
        };

        function kotoba() {
            $("#carac_restantes").text("Escritos: " + $("#txt_Mensaje").val().length + " " + "Restantes: " + (3000 - $("#txt_Mensaje").val().length)); //Detectamos los Caracteres del Input
            //$("#result").addClass('mui--is-not-empty'); //Agregamos la Clase de Mui para decir que el input no esta vacio y que suba el Texto del Label(Como cuando haces Focus)
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
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Rut NO Válido</h4>
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
    <div class="container mt-3">
        <div class="card border-bar">
            <div class="card-header bg-bar text-center">
                <h4><i class="fa fa-plane fa-fw"></i>FORMULARIO DE CONSULTAS, SUGERENCIAS Y RECLAMOS </h4>
                <h5>LABORATORIO CLÍNICO CMVALPARAÍSO </h5>
                <h6>Campos obligatorios(*)</h6>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-lg-4">
                        <label for="">Rut:(*)</label>
                        <input type="text" class="form-control" id="txt_Rut" placeholder="Ejemplo: 12.345.678-9" />
                    </div>
                    <div class="col-lg-4">
                        <label for="">Nombre:(*)</label>
                        <input type="text" class="form-control" id="txt_Nombre" />
                    </div>
                    <div class="col-lg-4">
                        <label for="">Apellido:(*)</label>
                        <input type="text" class="form-control" id="txt_Apellido" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-3">
                        <label>Nacionalidad:(*)</label>
                    <br /><form>
                        <div class="row">         
                            <label for="Chk_Chilena" style="margin-right:5px">Chilena:</label>
                            <input type="radio" name="gender" value="0" id="Chk_Chilena" style="margin-right:5px"><br />
                            <label for="Chk_Extranjera" style="margin-right:5px">Extranjera:</label>
                            <input type="radio" name="gender" value="1" id="Chk_Extranjera">
                        </form>
                        </div>            
                    </div>
                <div class="col-lg-3">
                        <div class="row">         
                           <label for="txt_pais" style="margin-right:5px">País:</label>
                            <input type='text' id="txt_pais" class="form-control" readonly="true"/>
                        </div>            
                    </div>
                    <div class="col-lg-3">
                        <label for="fecha">Fecha Nacimiento:(*)</label>
                         <div class='input-group date' id='Txt_Date01'>
                        <input type='text' id="pac_fnac" class="form-control" placeholder="31-12-1900" />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <label>Sexo:(*)</label>
                        <br />
                        <div class="row">         
                            <label for="Chk_Hombre" style="margin-right:5px">Hombre:</label>
                            <input type="radio" name="gender" value="0" id="Chk_Hombre" style="margin-right:5px"><br />
                            <label for="Chk_Mujer" style="margin-right:5px">Mujer:</label>
                            <input type="radio" name="gender" value="1" id="Chk_Mujer" style="margin-right:5px">
                            <label for="Chk_Otro" style="margin-right:5px">Otro:</label>
                            <input type="radio" name="gender" value="2" id="Chk_Otro">
                        </div>            
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4">
                        <label for="">Teléfono móvil:(*)</label>
                        <input type="text" class="form-control" id="txt_Movil" placeholder="+569 11223344"/>
                    </div>
                    <div class="col-lg-4">
                        <label for="">Otro teléfono de contacto:</label>
                        <input type="text" class="form-control" id="txt_Movil2" placeholder="+569 11223344"/>
                    </div>
                    <div class="col-lg-4">
                        <label for="">Email:(*)</label>
                        <input type="text" class="form-control" id="txt_Email"/>
                    </div>
                </div>
            </div>


            <div class="card border-bar">
            <div class="card-header bg-bar text-center">
                <h5>DESARROLLO DEL REQUERIMIENTO</h5>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-lg-4">
                        <label for="Ddl_LugarTM">Centro de salud en que se atiende:(*)</label>
                        <select id="Ddl_LugarTM" class="form-control">
                            <option value="0">Seleccionar</option>
                        </select>
                    </div>
                    <div class="col-lg-4">
                        <label>Requerimiento:(*)</label>
                    <br /><form>      
                        <div class="row">
                            <div class="col-5">
                                <label for="Chk_Consulta" style="margin-right:5px">Consulta:</label>
                                <input type="radio" name="gender" value="0" id="Chk_Consulta" style="margin-right:5px"><br />
                            </div>
                            <div class="col-1"></div>
                            <div class="col-5">
                                <label for="Chk_Sugerencia" style="margin-right:5px">Sugerencia: </label>
                                <input type="radio" name="gender" value="1" id="Chk_Sugerencia">
                            </div>                       
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <label for="Chk_Felicitaciones" style="margin-right:5px">Felicitaciones: </label>
                                <input type="radio" name="gender" value="2" id="Chk_Felicitaciones">
                            </div>
                            <div class="col-6">
                                <label for="Chk_Reclamo" style="margin-right:5px">Reclamo:</label>
                                <input type="radio" name="gender" value="3" id="Chk_Reclamo">
                            </div>               
                        </div>        
                        </form>
                        </div>  
                    <div class="col-lg-4">
                        <label for="fecha">Fecha en que se generó el requerimiento:(*)</label>
                         <div class='input-group date' id='Txt_Date02'>
                        <input type='text' id="fec_evento" class="form-control" readonly="true" placeholder="asdasd" />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg">
                        <label>Describa brévemente su requerimiento:</label>
                        <textarea class="form-control" id="txt_Mensaje" onkeydown="kotoba()" onkeyup="kotoba()" maxlength="3000"></textarea>
                        <label>Máximo 3000 caracteres.</label>
                        <label id="carac_restantes">Escritos: 0 Restantes: 3000</label>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg">
                        <label style="text-align:center">Su requerimiento será revisado por el laboratorio Clínico Valparaíso, y se remitirá la respuesta a su correo electrónico.</label>
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col-lg text-center">
                        <button type="button" class="btn btn-limpiar" id="Btn_limpiar"><i class="fa fa-eraser fa-fw"></i>Limpiar formulario</button>
                    </div>
                    <div class="col-lg text-center">
                        <button type="button" class="btn btn-buscar" id="Btn_Enviar"><i class="fa fa-paper-plane fa-fw"></i>Guardar y enviar</button>
                    </div>
                </div>
                </div>
            </div>


        </div>
</asp:Content>