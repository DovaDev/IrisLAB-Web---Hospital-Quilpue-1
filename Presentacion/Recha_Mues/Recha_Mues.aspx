<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Recha_Mues.aspx.vb" Inherits="Presentacion.Recha_Mues" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    <script type="module">

        import fetcher from "../js/es6-modules/FetcherV1.js";
        import { fillUsuariosPorProcedenciaFlebo, fillUsuariosPorProcedenciaFlebotomista } from "../js/es6-modules/Usuarios.js";

        await fillUsuariosPorProcedenciaFlebo(0, { idSelect: "slct-usuario-tdem", placeholder: true });

        //Llenar FECHAS
        function FECHAS_INS() {
            var asd = Mx_Dtt[0].nac;

            asd = asd.replace(/-/g, "/");
            var array = asd.split("/");
            var total = "";
            var dia = array[0];
            var mes = array[1];
            var ano = array[2];
            //if (dia < 10) { dia = "0" + dia; }
            //if (mes < 10) { mes = "0" + mes; }
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
            //$("#txtEdad").val(total);
        }

        function jsDecimals(e) { // aunque no lo parezca esta wea se usa en el html <img src="https://media.tenor.com/ppqVQB1PoBAAAAAC/tom-y-jerry-tom-and-jerry.gif">

            var evt = (e) ? e : window.event;
            var key = (evt.keyCode) ? evt.keyCode : evt.which;
            if (key != null) {
                key = parseInt(key, 10);
                if ((key < 48 || key > 57) && (key < 96 || key > 105)) {
                    //Aca tenemos que reemplazar "Decimals" por "NoDecimals" si queremos que no se permitan decimales
                    if (!jsIsUserFriendlyChar(key, "NoDecimals")) {
                        return false;
                    }
                }
                else {
                    if (evt.shiftKey) {
                        return false;
                    }
                }
            }
            return true;
        }

        // Función para las teclas especiales
        function jsIsUserFriendlyChar(val, step) {
            // Backspace, Tab, Enter, Insert, y Delete
            if (val == 8 || val == 9 || val == 13 || val == 45 || val == 46) {
                return true;
            }
            // Ctrl, Alt, CapsLock, Home, End, y flechas
            if ((val > 16 && val < 21) || (val > 34 && val < 41)) {
                return true;
            }
            if (step == "Decimals") {
                if (val == 190 || val == 110) {  //Check dot key code should be allowed
                    return true;
                }
            }
            // The rest
            return false;
        }
        var CB_Pendiente = 0;
        var ATE_NUM_Pendiente = 0;
        var ID_RECEP_ETI_RECHAZO_SUPREMO = 0;
        var correxxx = 0;
        var ID_Ateee = 0;
        var ID_Pac = 0;
        var nombre_waaa = "";
        let selected = [];
        $(document).ready(function () {

            // Agregar evento al botón
            //$("#btnGenerar").on("click", generarMensaje);

            $("#txtNAte").focus();
            $("#txtNAte").on("keydown", jsDecimals);
            // AJAX AL CARGAR EL FORMULARIO
            //Ajax_DataTable_Load();
            Ajax_DDL_RECHAZOS_ACTIVOS();


            $("#Div_Tabla").empty();
            $("#Id_Conte").hide();

            $("#Btn_Buscar_x_ate").click(function () {

                if ($("#txtNAte").val() == "") {

                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, ingrese un número de folio");
                    $("#mError_AAH").modal();

                } else {
                    var ID_USU = $("#slct-usuario-tdem").val();

                    if (ID_USU === null || ID_USU === '0' || ID_USU == 0) {
                        $("#mError_AAH h4").text("Error");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("Por favor, seleccione un usuario");
                        $("#mError_AAH").modal();
                        return;
                    } else {
                        Ajax_DataTable();
                    }  
                }
            });

            let idCodigoFonasaMarcado = 0;
            //AJAX GUARDAR EN EL MODAL MARCAR
            $("#Btn_Guardar").click(function () {
                idCodigoFonasaMarcado = 0;
                selected = new Array();
                $("input:checkbox[name='rechazo-marcar']:checked").each(function () {
                    selected.push($(this).val());
                    idCodigoFonasaMarcado = parseInt(this.parentElement.parentElement.id) || 0;
                });
                if (selected == "") {
                    $("#mError_AAH h4").text("Sin Selección");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("No se ha seleccionado ninguna muestra.");
                    $("#mError_AAH").modal();
                } else {
                    $("#Modal_Confirmar_rechazo").modal('hide');
                    $("#Ddl_Motivo").val(0);
                    $("#Txt_Motivo").val("");
                    $("#Modal_Confirmar_rechazo h4").text("Información de Rechazo");
                    $("#Modal_Confirmar_rechazo").modal();
                }
            });

            //$("#Btn_Confirmar_Rechazo").click(function () {
            //    if ($("#Ddl_Motivo").val() == 0) {
            //        $("#mError_AAH h4").text("Sin Selección");
            //        $("#mError_AAH button").attr("class", "btn btn-danger");
            //        $("#mError_AAH p").text("No se ha seleccionado ningún tipo de rechazo.");
            //        $("#mError_AAH").modal();
            //    } else {
            //        Ajax_Marcar_Guardar(idCodigoFonasaMarcado);
            //    }
            //});
            $("#Btn_Confirmar_Rechazo").click(function () {
                if ($("#Ddl_Motivo").val() == 0) {
                    $("#mError_AAH h4").text("Sin Selección");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("No se ha seleccionado ningún tipo de rechazo.");
                    $("#mError_AAH").modal();
                } else {
                    // Generar el mensaje antes de llamar a la función AJAX
                    const responsable = $("#Txt_responsable").val().trim();
                    const datosExtras = $("#Ddl_Motivo option:selected").text().trim();
                    const fecha_rechazo = $("#Txt_Motivo").val().trim();
                    let fecha; 
                    let hora; 
                    if (fecha_rechazo) {
                        const fechaObj = new Date(fecha_rechazo);

                         fecha = fechaObj.toLocaleDateString('es-CL'); // Formato de fecha local
                         hora = fechaObj.toLocaleTimeString('es-CL', {
                            hour: '2-digit',
                            minute: '2-digit',
                            second: '2-digit'
                        });

                        console.log("Fecha:", fecha);
                        console.log("Hora:", hora);
                    }

                    if (!responsable) {
                        Swal.fire({
                            title: "Aviso",
                            text: "Por favor, ingrese el nombre de la persona que dara aviso.",
                            icon: "warning"
                        });
                        return;
                    }

                    const mensajeGenerado = `AVISADO A : ${responsable} | TIPO DE RECHAZO: ${datosExtras} | FECHA: ${fecha} | HORA: ${hora}`;

                    // Insertar el mensaje generado en el textarea para mostrarlo
                    $("#Txt_mensajeGenerado").val(mensajeGenerado);

                    // Llamar a la función AJAX enviando el mensaje generado
                    Ajax_Marcar_Guardar(idCodigoFonasaMarcado, mensajeGenerado);
                }
            });

            $("#Btn_Confirmar_Rechazo_DIRECTO").click(function () {
                if ($("#Ddl_Motivo_DIRECTO").val() == 0) {
                    $("#mError_AAH h4").text("Sin Selección");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("No se ha seleccionado ningún tipo de rechazo.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_Marcar_Guardar_DIRECTO();
                }
            });

            //AJAX PENDIENTE EN EL MODAL MARCAR
            $("#Btn_Pendiente").click(function () {

                if (CB_Pendiente == 0 || ATE_NUM_Pendiente == 0 || ID_RECEP_ETI_RECHAZO_SUPREMO == 0) {
                    $("#mError_AAH h4").text("Seleccione una muestra");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione una muestra a eliminar.");
                    $("#mError_AAH").modal();
                } else {
                    $("#modal_pendientes h4").text("¿Eliminar Etiqueta?");
                    $("#modal_pendientes p").text("¿Esta seguro que desea eliminar la etiqueta: " + "[" + CB_Pendiente + "]" + "-" + ATE_NUM_Pendiente);
                    $("#modal_pendientes").modal();
                }

            });

            //AJAX CONFIRMACION PENDIENTE EN EL MODAL MARCAR
            $("#Btn_Pendiente_Si").click(function () {
                Ajax_Pendiente_Marcar();
            });

            $("#slct-usuario-tdem").change(function () {
                Ajax_DataTable_Load();
            });

            $("#Btn_Anterior").click(function () {
                var direccion = parseInt(Mx_Dtt_Marcar[0].ATE_NUM);
                direccion = direccion - 1;
                Ajax_DataTable_Marcar_Direccion(direccion);
            });

            $("#Btn_Siguiente").click(function () {
                var direccion = parseInt(Mx_Dtt_Marcar[0].ATE_NUM);
                direccion = direccion + 1;
                Ajax_DataTable_Marcar_Direccion(direccion);
            });


            $('#txtNAte').change(function (event) {
                var hola = $('#txtNAte').val();

                // Verificar el ID_USU antes de llamar a Ajax_DataTable
                var ID_USU = $("#slct-usuario-tdem").val();

                if (ID_USU === null || ID_USU === '0' || ID_USU == 0) {
                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione un usuario");
                    $("#mError_AAH").modal();
                    return;
                }

                Ajax_DataTable();

            });


            //CREAR LOTE
            $("#Btn_Crear_Lote").click(function () {
                if (Mx_Dtt_Load[0].ID_USUARIO == 0) {
                    $("#mError_AAH h4").text("Creación Fallida");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("No se puede crear un lote vacío.");
                    $("#mError_AAH").modal();
                } else {
                    Guardar_Lote();
                }

            });


            //CONFIRMAR LOTE
            $("#Btn_Confirmar_Lote").click(function () {
                Guardar_Lote_2(correxxx);
            });


            //MAS INFO PACIENTE
            $("#Btn_Info").click(function () {
                if (ID_Ateee == 0) {
                    $("#mError_AAH h4").text("Busque Folio");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Primero debe buscar un número de folio.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_Info();
                }
            });

            // VER LOTES
            $("#Btn_Lote").click(function () {
                Ajax_Ver_Lotes_Anteriores();
            });

            $("#Btn_Anterior_Muestras_Lotes").click(function () {
                var direccion = parseInt(Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM);
                direccion = --direccion;
                Ajax_Muestras_Lotes_direccion_negativo(direccion);
            });

            $("#Btn_Siguiente_Muestras_Lotes").click(function () {
                var direccion = parseInt(Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM);
                direccion = ++direccion;
                Ajax_Muestras_Lotes_direccion_positivo(direccion);
            });

            $("#Btn_Grupos_Muestras_Lotes").click(function () {
                Ajax_Ver_Lotes_Anteriores();
            });

            $("#Btn_Marcar").click(function () {
                //$("#Btn_Marcar").hide();
                //$("#Btn_Desmarcar").show();
                $("input[name='rechazo-marcar']").prop("checked", true);


            });

            $("#Btn_Desmarcar").click(function () {
                //$("#Btn_Desmarcar").hide();
                //$("#Btn_Marcar").show();
                $("input[name='rechazo-marcar']").prop("checked", false);
            });



            // esto sirve para buscar los tipos de rechazo segun el estado de recepción de la muestra
            // hace que si el tubo no tiene recepción solo sale el tipo de rechazo "muestra no recepcionada"
            //$("#Modal_Confirmar_rechazo, #Modal_Confirmar_rechazo_DIRECTO").on('shown.bs.modal', async () => {
            //    modal_show();
            //    /** @type {string | number} */
            //    let ateNum = $("#txtNAte").val();
            //    /** @type {string} */
            //    let cbDesc;

            //    const seAbrePorPistola = ateNum.length === 10;

            //    if (seAbrePorPistola) {
            //        cbDesc = ateNum.substring(0, 2);
            //        ateNum = parseInt(ateNum.substring(2));
            //    } else {
            //        cbDesc = $("input:radio[name='rechazo-marcar']:checked")[0].value;
            //        ateNum = Mx_Dtt_Marcar[0].ATE_NUM
            //    }

            //    await fillTipoRechazo({ idSelect: ["Ddl_Motivo", "Ddl_Motivo_DIRECTO"], ateNum, cbDesc });
            //    Hide_Modal();

            //});
        });


        //-------------------------------------------------- DDL TIPO RECHAZOS ACTIVOS --------------------------------------------------
        var Mx_DLL_RECHAZOS_ACTIVOS = [{
            "ID_TP_RECHA": 0,
            "TP_RECHA_COD": 0,
            "TP_RECHA_DESC": 0,
            "ID_ESTADO": 0
        }];

        function Ajax_DDL_RECHAZOS_ACTIVOS() {

            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/DDL_TIPO_RECHAZO_ACTIVOS",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {

                        Mx_DLL_RECHAZOS_ACTIVOS = json_receiver;
                        Fill_Ddl_Motivo();
                    } else {

                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();


                }
            });
        }
        //-------------------------------------------------- TABLA LOAD ---------------------------------------------------------------|
        var Mx_Dtt_Load = [{
            "ID_USUARIO": 0,
            "RECEP_ETI_NUM_ATE_RECHAZO": 0,
            "RECEP_ETI_CURVA_RECHAZO": 0,
            "RECEP_ETI_FECHA_RECHAZO": 0,
            "CB_DESC": 0,
            "ATE_NUM": 0,
            "PAC_NOMBRE": 0,
            "PAC_APELLIDO": 0,
            "ID_ESTADO": 0,
            "EST_DESCRIPCION": 0,
            "T_MUESTRA_DESC": 0,
            "ID_RECEP_ETI_RECHAZO": 0,
            "CF_DESC": 0,
            "USU_NIC": 0
        }];

        function Ajax_DataTable_Load() {
            modal_show();


            var ID_USU = $("#slct-usuario-tdem").val();

            if (ID_USU === null || ID_USU === 0) {
                alert("Por favor, seleccione un usuario.");
                Hide_Modal();
                return;
            }

            var Data_par = JSON.stringify({
                "ID_USU": ID_USU
            });
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/Form_Table",
                "data": Data_par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Load = json_receiver;
                        Hide_Modal();
                        $("#Id_Conte").show();
                        $("#Div_Tabla_Load").empty();
                        $("#Div_Tabla").hide();
                        $("#Div_Tabla_Load").show();

                        for (let i = 0; i < Mx_Dtt_Load.length; ++i) {
                            var date_x = Mx_Dtt_Load[i].RECEP_ETI_FECHA_RECHAZO;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Load[i].RECEP_ETI_FECHA_RECHAZO = Date_Change;
                        }

                        $("#txtNAte").focus();

                        Fill_DataTable_Load();


                    } else {
                        $("#txtNAte").val("");
                        $("#txtNAte").focus();
                        Hide_Modal();
                        $("#Div_Tabla_Load").empty();
                        $("#txtNum").val("");
                        $("#txtRut").val("");
                        $("#txtNom").val("");
                        $("#txtEdad").val("");
                        $("#txtSexo").val("");
                        $("#txtFono").val("");
                        $("#txtCel").val("");
                        $("#txtObsAte").val("");
                        $("#txtObsTm").val("");
                        $("#txtNAte").focus();
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();


                }
            });
        }

        //-------------------------------------------------- DATOS PACIENTE Y LOTE O AGREGAR LA MUESTAR DEL LOTE ----------------------|
        var Mx_Dtt = [
            {
                "ATE_OBS_FICHA": 0,
                "ATE_OBS_TM": 0,
                "PAC_FONO1": 0,
                "PAC_MOVIL1": 0,
                "PAC_EMAIL": 0,
                "ATE_AÑO": 0,
                "SEXO_DESC": 0,
                "ID_T_MUESTRA": 0,
                "ATE_NUM": 0,
                "ID_ATENCION": 0,
                "T_MUESTRA_DESC": 0,
                "CB_DESC": 0,
                "Expr1": 0,
                "CF_DESC": 0,
                "ID_ENVIO": 0,
                "ID_USUARIO": 0,
                "PAC_RUT": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "ID_ESTADO": 0,
                "Expr2": 0,
                "ID_PER": 0,
                "USU_NIC": 0,
                "ENVIO_ETI_FECHA": 0
            }
        ];
        let GLOBAL_ETIQUETA_ESCANEADA = 0;
        const cutCodBarSiRechazaExamen = () => {
            GLOBAL_ETIQUETA_ESCANEADA = 0;
            let inputIngresado = $("#txtNAte").val();

            const radioTipoRechazoSelected = $("input[name='radiosTipoRechazo']:checked").val();
            const inputEsCodigoBarra = inputIngresado.length === 10;

            if (radioTipoRechazoSelected === 'Examen' && inputEsCodigoBarra) {
                GLOBAL_ETIQUETA_ESCANEADA = inputIngresado.substring(0, 2);
                inputIngresado = inputIngresado.substring(2, 10);
                inputIngresado = inputIngresado.replace(/^0+/, '');
            }
            $("#txtNAte").val(inputIngresado);
            return inputIngresado;
        }

        function Ajax_DataTable() {
            modal_show();

            cutCodBarSiRechazaExamen()

            var ID_USU = $("#slct-usuario-tdem").val();

            if (ID_USU === null || ID_USU === 0) {
                alert("Por favor, seleccione un usuario.");
                Hide_Modal();
                return;
            }

            var Data_Par = JSON.stringify({
                "NUM_ATE": $("#txtNAte").val(),
                "ID_USU": ID_USU
            });
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        if (json_receiver == "recepcionada") {
                            Ajax_DataTable_Load();
                        }
                        else if (json_receiver == "table") {
                            $('#txtNAte').val("");
                            Ajax_DataTable_Load();
                        } else if (json_receiver == "entregada") {
                            $("#mError_AAH").modal('hide');
                            $("#mError_AAH h4").text("Muestra Rechazada");
                            $("#mError_AAH button").attr("class", "btn btn-danger");
                            $("#mError_AAH p").text("La muestra ya  ha sido rechazada.");
                            $("#mError_AAH").modal();
                            $('#txtNAte').val("");



                            setInterval(function () {
                                $("#mError_AAH").modal('hide');
                                //$("#txtNAte").focus();
                            }, 1800)

                            //$("#txtNAte").focus();
                            Ajax_DataTable_Load();
                        } else if (json_receiver == "Modal_Confirmar_rechazo_DIRECTO") {
                            Hide_Modal();
                            $("#Ddl_Motivo_DIRECTO").val(0);
                            $("#Txt_Motivo_DIRECTO").val("");
                            $("#Modal_Confirmar_rechazo_DIRECTO").modal('hide');
                            $("#Modal_Confirmar_rechazo_DIRECTO h4").text("Información de Rechazo");
                            $("#Modal_Confirmar_rechazo_DIRECTO").modal();
                        }

                        else {
                            Mx_Dtt = JSON.parse(json_receiver);
                            ID_Ateee = Mx_Dtt[0].ID_ATENCION;

                            //$("#txtNAte").val(Mx_Dtt[0].ATE_NUM);

                            $("#txtNum").val(Mx_Dtt[0].ATE_NUM);
                            $("#txtRut").val(Mx_Dtt[0].PAC_RUT);
                            $("#txtNom").val(Mx_Dtt[0].PAC_NOMBRE + " " + Mx_Dtt[0].PAC_APELLIDO);
                            $("#txtEdad").val(Mx_Dtt[0].ATE_AÑO);
                            $("#txtSexo").val(Mx_Dtt[0].SEXO_DESC);
                            $("#txtFono").val(Mx_Dtt[0].PAC_FONO1);
                            $("#txtCel").val(Mx_Dtt[0].PAC_MOVIL1);
                            $("#txtObsAte").val(Mx_Dtt[0].ATE_OBS_FICHA);
                            $("#txtObsTm").val(Mx_Dtt[0].ATE_OBS_TM);

                            Ajax_Info_Asereje();
                            Ajax_DataTable_Marcar();



                        }
                    } else {


                        Hide_Modal();
                        $("#mError_AAH").modal('hide');
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                        $("#txtNAte").val("");
                        $("#txtNum").val("");
                        $("#txtRut").val("");
                        $("#txtNom").val("");
                        $("#txtEdad").val("");
                        $("#txtSexo").val("");
                        $("#txtFono").val("");
                        $("#txtCel").val("");
                        $("#txtObsAte").val("");
                        $("#txtObsTm").val("");
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }


        var Mx_Dtt_Atencion_Asereje = [
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
                "ID_PACIENTE": 0
            }
        ];

        function Ajax_Info_Asereje() {

            //modal_show();


            var Data_Par = JSON.stringify({
                "ID_USU": ID_Ateee
            });
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/Info",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Atencion_Asereje = json_receiver;

                        ID_Pac = Mx_Dtt_Atencion_Asereje[0].ID_PACIENTE;
                        //$("#superNumAte").val(Mx_Dtt_Atencion_Asereje[0].ATE_NUM)
                        //$("#superNombre").val(Mx_Dtt_Atencion_Asereje[0].PAC_NOMBRE + " " + Mx_Dtt_Atencion_Asereje[0].PAC_APELLIDO);




                        Ajax_Info_Exa_Asereje();
                    } else {

                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    //Hide_Modal();


                }
            });
        }

        // -------------------------------------------- INFO DEL PACIENTE QUE VA EN EL MODAL Y LA WE@
        var Mx_Dtt_Datos_Actuales_Asereje = [
            {
                "ID_ATENCION": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "ATE_NUM": 0,
                "ATE_FECHA": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "PREVE_DESC": 0,
                "PROC_DESC": 0,
                "TP_ATE_DESC": 0,
                "ID_PACIENTE": 0
            }
        ];

        function Ajax_Info_Exa_Asereje() {


            var ID_USU = $("#slct-usuario-tdem").val();

            if (ID_USU === null || ID_USU === 0) {
                alert("Por favor, seleccione un usuario.");
                return;
            }

            var Data_Par = JSON.stringify({
                "ID_Pac": ID_Pac,
                "ID_USU": ID_USU
            });

            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/Exa_Info",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Datos_Actuales_Asereje = json_receiver;
                        //Hide_Modal();

                        //$("#Div_Tabla_Atencion").empty();
                        //$("#Div_Datos_Actuales").empty();

                        //$('#eModalInfo').modal('hide');
                        //$('#eModalInfo').modal('show');

                        //$("#numAtessss").text(Mx_Dtt_Datos_Actuales.length);
                        //Fill_DataTable_Atencion();
                        //Fill_DataTable_Datos_Actuales();



                        $("#superNumAte").text(Mx_Dtt_Datos_Actuales_Asereje[0].ATE_NUM);
                        $("#superNombre").text(Mx_Dtt_Datos_Actuales_Asereje[0].DOC_NOMBRE + " " + Mx_Dtt_Datos_Actuales_Asereje[0].DOC_APELLIDO);
                        $("#superPrevision").text(Mx_Dtt_Datos_Actuales_Asereje[0].PREVE_DESC);
                        $("#superLugar").text(Mx_Dtt_Datos_Actuales_Asereje[0].PROC_DESC);
                        //nombre_waaa = $("#txtNom").val();
                        nombre_waaa = Mx_Dtt_Datos_Actuales_Asereje[0].PAC_NOMBRE + " " + Mx_Dtt_Datos_Actuales_Asereje[0].PAC_APELLIDO;
                        $("#superNomPaciente").text(nombre_waaa);


                        Hide_Modal();


                    } else {
                        //$("#superNumAte").text("");
                        //$("#superNombre").text("");
                        //$("#superPrevision").text("");
                        //$("#superLugar").text("");
                        //$("#superNomPaciente").text("");

                        Hide_Modal();

                        //$("#mError_AAH h4").text("Sin Resultados");
                        //$("#mError_AAH button").attr("class", "btn btn-danger");
                        //$("#mError_AAH p").text("No se han encontrado resultados.");
                        //$("#mError_AAH").modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();


                }
            });
        }












        //-------------------------------------------------- DATOS PACIENTE AL CAMBIAR DE MODAL ----------------------|
        var Mx_Dtt_Asereje = [
            {
                "ID_ATENCION": 0,
                "ATE_NUM": 0,
                "ATE_OBS_FICHA": 0,
                "ATE_OBS_TM": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "PAC_FONO1": 0,
                "PAC_MOVIL1": 0,
                "PAC_RUT": 0,
                "PAC_EMAIL": 0,
                "ATE_AÑO": 0,
                "SEXO_DESC": 0
            }
        ];

        function Ajax_DataTable_Asereje() {
            //modal_show();
            var ID_USU = $("#slct-usuario-tdem").val();

            if (ID_USU === null || ID_USU === 0) {
                alert("Por favor, seleccione un usuario.");
                Hide_Modal();
                return;
            }
            var Data_Par = JSON.stringify({
                "NUM_ATE": $("#txtNAte").val(),
                "ID_USU": ID_USU
            });
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        if (json_receiver == "recepcionada") {
                            Ajax_DataTable_Load();
                        }
                        else if (json_receiver == "table") {
                            $('#txtNAte').val("");
                            Ajax_DataTable_Load();
                        } else if (json_receiver == "entregada") {
                            //$("#mError_AAH h4").text("Muestra Recepcionada");
                            //$("#mError_AAH button").attr("class", "btn btn-danger");
                            //$("#mError_AAH p").text("La muestra ya se encuentra recepcionada.");
                            //$("#mError_AAH").modal();
                            //$('#txtNAte').val("");
                            Ajax_DataTable_Load();
                        }

                        else {
                            Mx_Dtt_Asereje = JSON.parse(json_receiver);
                            ID_Ateee = Mx_Dtt_Asereje[0].ID_ATENCION;
                            $("#txtNum").val(Mx_Dtt_Asereje[0].ATE_NUM);
                            $("#txtRut").val(Mx_Dtt_Asereje[0].PAC_RUT);
                            $("#txtNom").val(Mx_Dtt_Asereje[0].PAC_NOMBRE + " " + Mx_Dtt_Asereje[0].PAC_APELLIDO);
                            $("#txtEdad").val(Mx_Dtt_Asereje[0].ATE_AÑO);
                            $("#txtSexo").val(Mx_Dtt_Asereje[0].SEXO_DESC);
                            $("#txtFono").val(Mx_Dtt_Asereje[0].PAC_FONO1);
                            $("#txtCel").val(Mx_Dtt_Asereje[0].PAC_MOVIL1);
                            $("#txtObsAte").val(Mx_Dtt_Asereje[0].ATE_OBS_FICHA);
                            $("#txtObsTm").val(Mx_Dtt_Asereje[0].ATE_OBS_TM);

                            //Ajax_DataTable_Marcar();



                        }
                    } else {


                        //Hide_Modal();
                        //$("#mError_AAH h4").text("Sin resultados");
                        //$("#mError_AAH button").attr("class", "btn btn-danger");
                        //$("#mError_AAH p").text("No se han encontrado resultados");
                        //$("#mError_AAH").modal();

                        $("#txtNum").val("");
                        $("#txtRut").val("");
                        $("#txtNom").val("");
                        $("#txtEdad").val("");
                        $("#txtSexo").val("");
                        $("#txtFono").val("");
                        $("#txtCel").val("");
                        $("#txtObsAte").val("");
                        $("#txtObsTm").val("");
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }


        //-------------------------------------------------- GUARDAR TABLA MARCAR -----------------------------------------------------|
        var Mx_Dtt = [
            {
                "ID_ATENCION": 0,
                "ATE_NUM": 0,
                "ATE_OBS_FICHA": 0,
                "ATE_OBS_TM": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "PAC_FONO1": 0,
                "PAC_MOVIL1": 0,
                "PAC_RUT": 0,
                "PAC_EMAIL": 0,
                "ATE_AÑO": 0,
                "SEXO_DESC": 0
            }
        ];

        function Ajax_Marcar_Guardar(idCodigoFonasaMarcado = 0, mensajeGenerado) {
            modal_show();
            const tipoRechazoChecked = $("input[name='radiosTipoRechazo']:checked").val()
            if (tipoRechazoChecked === "Tubo") {
                idCodigoFonasaMarcado = 0
            }

            const ID_USER = Galletas.getGalleta("ID_USER");


            if (isNaN(ID_USER) || ID_USER <= 0) {
                window.location.href = "index.aspx";
                return;
            }

            var ID_USU = $("#slct-usuario-tdem").val();

            if (ID_USU === null || ID_USU === 0) {
                alert("Por favor, seleccione un usuario.");
                Hide_Modal();
                return;
            }

            var Data_Par = JSON.stringify({
                "NUM_ATE": Mx_Dtt_Marcar[0].ATE_NUM,
                "ID_ATE": Mx_Dtt_Marcar[0].ID_ATENCION,
                "MUESTRA": selected,
                "ID_TIPO": $("#Ddl_Motivo").val(),
                "OBSER": $("#Txt_Motivo").val(),
                "TEXT_MOTIVO": $("#Ddl_Motivo option:selected").text(),
                ID_USU,
                idCodigoFonasaMarcado,
                "MENSAJE_GENERADO": mensajeGenerado // ✅ Nuevo campo con el mensaje generado
            });
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/Llenar_DataTable_Marcar",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver == "error") {
                        Hide_Modal();
                        $("#mError_AAH h4").text("Error al Rechazar");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se ha podido rechazar la muestra");
                        $("#mError_AAH").modal();

                        $("#txtNum").val("");
                        $("#txtRut").val("");
                        $("#txtNom").val("");
                        $("#txtEdad").val("");
                        $("#txtSexo").val("");
                        $("#txtFono").val("");
                        $("#txtCel").val("");
                        $("#txtObsAte").val("");
                        $("#txtObsTm").val("");
                        $("#Txt_responsable").val("");
                        return
                    }
                    if (json_receiver == "validado") {
                        Swal.fire({ icon: "info", title: "Información", text: "El examen ya fue validado, no es posible rechazar." });
                        Hide_Modal();
                        return
                    } else if (json_receiver == "rechazado") {
                        $("#Modal_Confirmar_rechazo").modal('hide');
                        $("#Ddl_Motivo").val(0);
                        $("#Txt_Motivo").val("");

                        $("#txtNum").val("");
                        $("#txtRut").val("");
                        $("#txtNom").val("");
                        $("#txtEdad").val("");
                        $("#txtSexo").val("");
                        $("#txtFono").val("");
                        $("#txtCel").val("");
                        $("#txtObsAte").val("");
                        $("#txtObsTm").val("");
                        $('#eModal').modal('hide');
                        Ajax_DataTable_Load();
                    } else {
                        Mx_Dtt = JSON.parse(json_receiver);

                        $("#txtNum").val(Mx_Dtt[0].ATE_NUM);
                        $("#txtRut").val(Mx_Dtt[0].PAC_RUT);
                        $("#txtNom").val(Mx_Dtt[0].PAC_NOMBRE + " " + Mx_Dtt[0].PAC_APELLIDO);
                        FECHAS_INS();
                        $("#txtEdad").val(Mx_Dtt[0].ATE_AÑO);
                        $("#txtSexo").val(Mx_Dtt[0].SEXO_DESC);
                        $("#txtFono").val(Mx_Dtt[0].PAC_FONO1);
                        $("#txtCel").val(Mx_Dtt[0].PAC_MOVIL1);
                        $("#txtObsAte").val(Mx_Dtt[0].ATE_OBS_FICHA);
                        $("#txtObsTm").val(Mx_Dtt[0].ATE_OBS_TM);

                        Ajax_DataTable_Marcar();
                    }



                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }
        //-------------------------------------------------- GUARDAR DIRECTO -----------------------------------------------------|
        var Mx_Dtt = [
            {
                "ID_ATENCION": 0,
                "ATE_NUM": 0,
                "ATE_OBS_FICHA": 0,
                "ATE_OBS_TM": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "PAC_FONO1": 0,
                "PAC_MOVIL1": 0,
                "PAC_RUT": 0,
                "PAC_EMAIL": 0,
                "ATE_AÑO": 0,
                "SEXO_DESC": 0
            }
        ];

        function Ajax_Marcar_Guardar_DIRECTO() {
            modal_show();


            const ID_USER = Galletas.getGalleta("ID_USER");


            if (isNaN(ID_USER) || ID_USER <= 0) {
                window.location.href = "index.aspx";
                return;
            }
            var ID_USU = $("#slct-usuario-tdem").val();

            if (ID_USU === null || ID_USU === 0) {
                alert("Por favor, seleccione un usuario.");
                Hide_Modal();
                return;
            }
            var Data_Par = JSON.stringify({
                "NUM_ATE": $("#txtNAte").val(), // aqui va el 9900002222 codigo de barra, con el num etiqueta los primeros 2 y el resto el numero de atención
                "ID_TIPO": $("#Ddl_Motivo_DIRECTO").val(),
                "OBSER": $("#Txt_Motivo_DIRECTO").val(),
                "TEXT_MOTIVO": $("#Ddl_Motivo_DIRECTO option:selected").text(),
                ID_USU,
            });
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/GUARDAR_AL_PISTOLEAR_EL_TUBO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver == "error") {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Error en Rechazo");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se ha podido rechazar la muestra.");
                        $("#mError_AAH").modal();

                        $("#txtNum").val("");
                        $("#txtRut").val("");
                        $("#txtNom").val("");
                        $("#txtEdad").val("");
                        $("#txtSexo").val("");
                        $("#txtFono").val("");
                        $("#txtCel").val("");
                        $("#txtObsAte").val("");
                        $("#txtObsTm").val("");
                        return
                    }
                    if (json_receiver == "validado") {

                        Swal.fire({ icon: "info", title: "Información", text: "El examen ya fue validado, no es posible rechazar." });
                        Hide_Modal();
                    }
                    else if (json_receiver == "rechazado") {
                        $("#Modal_Confirmar_rechazo_DIRECTO").modal('hide');
                        $("#Ddl_Motivo_DIRECTO").val(0);
                        $("#Txt_Motivo_DIRECTO").val("");
                        //$("#mError_AAH h4").text("Muestra Recepcionada");
                        //$("#mError_AAH button").attr("class", "btn btn-success");
                        //$("#mError_AAH p").text("La muestra ha sido recepcionada satisfactoriamente.");
                        //$("#mError_AAH").modal();
                        //$('#eModal').modal('hide');

                        $("#txtNum").val("");
                        $("#txtRut").val("");
                        $("#txtNom").val("");
                        $("#txtEdad").val("");
                        $("#txtSexo").val("");
                        $("#txtFono").val("");
                        $("#txtCel").val("");
                        $("#txtObsAte").val("");
                        $("#txtObsTm").val("");
                        $('#eModal').modal('hide');
                        Ajax_DataTable_Load();
                    }

                    else {
                        Mx_Dtt = JSON.parse(json_receiver);

                        $("#txtNum").val(Mx_Dtt[0].ATE_NUM);
                        $("#txtRut").val(Mx_Dtt[0].PAC_RUT);
                        $("#txtNom").val(Mx_Dtt[0].PAC_NOMBRE + " " + Mx_Dtt[0].PAC_APELLIDO);
                        FECHAS_INS();
                        $("#txtEdad").val(Mx_Dtt[0].ATE_AÑO);
                        $("#txtSexo").val(Mx_Dtt[0].SEXO_DESC);
                        $("#txtFono").val(Mx_Dtt[0].PAC_FONO1);
                        $("#txtCel").val(Mx_Dtt[0].PAC_MOVIL1);
                        $("#txtObsAte").val(Mx_Dtt[0].ATE_OBS_FICHA);
                        $("#txtObsTm").val(Mx_Dtt[0].ATE_OBS_TM);

                        Ajax_DataTable_Marcar();



                    }


                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }
        //--------------------------------------------- TABLE -------------------------------------------------------------------------|
        var Mx_Dtt_Table = [
            {
                "ID_USUARIO": 0,
                "RECEP_ETI_NUM_ATE": 0,
                "RECEP_ETI_CURVA": 0,
                "ENVIO_ETI_FECHA": 0,
                "CB_DESC": 0,
                "ATE_NUM": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "ID_ESTADO": 0,
                "EST_DESCRIPCION": 0,
                "T_MUESTRA_DESC": 0,
                "ID_RECEP_ETI": 0,
                "CF_DESC": 0,
                "ID_PER": 0,
                "ID_T_MUESTRA": 0,
                "ID_ATENCION": 0,
                "Expr1": 0,
                "ATE_EST_TM": 0,
                "USU_NIC": 0,
                "EST_DESCRIPCION": 0
            }
        ];

        function Ajax_DataTable_Ate_ONCLICK() {

            var Data_Par = JSON.stringify({
                "N_ATE": $("#txtNAte").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab.aspx/Llenar_DataTable2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Table = JSON.parse(json_receiver);

                        for (let i = 0; i < Mx_Dtt_Table.length; ++i) {
                            var date_x = Mx_Dtt_Table[i].ENVIO_ETI_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Table[i].ENVIO_ETI_FECHA = Date_Change;
                        }

                        $("#Id_Conte").show();
                        $("#Div_Tabla").empty();
                        Ajax_DataTable_Marcar();


                    } else {


                        $("#Div_Tabla").empty();
                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados.");
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


        //-------------------------------------------------- TABLA MARCAR -------------------------------------------------------------|
        var Mx_Dtt_Marcar = [
            {
                "ID_T_MUESTRA": 0,
                "ATE_NUM": 0,
                "ID_ATENCION": 0,
                "ID_PER": 0,
                "T_MUESTRA_DESC": 0,
                "CB_DESC": 0,
                "Expr1": 0,
                "CF_DESC": 0,
                "ATE_EST_RECHAZO": 0,
                "ID_PRUEBA": 0,
                "ATE_FEC_RECHAZO": 0,
                "ATE_USU_RECHAZO": 0,
                "EST_DESCRIPCION": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "USU_NIC": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "PREVE_DESC": 0,
                "PROC_DESC": 0,
                "ATE_NUM_OMI": 0,
                "ATE_CODIGO_TEST": 0
                //"ID_ENVIO": 0,
                //"ID_USUARIO": 0,
                //"PAC_RUT": 0,
                //"PAC_NOMBRE": 0,
                //"PAC_APELLIDO": 0,
                //"ID_ESTADO": 0,
                //"Expr2": 0,
                //"ID_PER": 0,
                //"ENVIO_ETI_FECHA": 0,
                //"EST_DESCRIPCION": 0

            }
        ];

        function Ajax_DataTable_Marcar() {

            var ID_USU = $("#slct-usuario-tdem").val();

            if (ID_USU === null || ID_USU === 0) {
                alert("Por favor, seleccione un usuario.");
                return;
            }


            var Data_Par = JSON.stringify({
                "N_ATE": $("#txtNAte").val(),
                "ID_USU": ID_USU
            });
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/Llenar_DataTable3",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Marcar = JSON.parse(json_receiver);

                        for (let i = 0; i < Mx_Dtt_Marcar.length; ++i) {
                            var date_x = Mx_Dtt_Marcar[i].ATE_FEC_RECHAZO;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Marcar[i].ATE_FEC_RECHAZO = Date_Change;
                        }
                        $("#Div_Tabla_Antiguos").empty();
                        $("#sss").text("Detalle de Estado Folio N°:" + " " + Mx_Dtt_Marcar[0].ATE_NUM);

                        $("#superNumAte").text(Mx_Dtt_Marcar[0].ATE_NUM);
                        $("#superNombre").text(Mx_Dtt_Marcar[0].DOC_NOMBRE + " " + Mx_Dtt_Marcar[0].DOC_APELLIDO);
                        $("#superPrevision").text(Mx_Dtt_Marcar[0].PREVE_DESC);
                        $("#superLugar").text(Mx_Dtt_Marcar[0].PROC_DESC);
                        //nombre_waaa = $("#txtNom").val();
                        nombre_waaa = Mx_Dtt_Marcar[0].PAC_NOMBRE + " " + Mx_Dtt_Marcar[0].PAC_APELLIDO;
                        $("#superNomPaciente").text(nombre_waaa);


                        Fill_DataTable_Antiguos();
                        $('#eModal').modal('hide');
                        $('#eModal').modal('show');

                        Hide_Modal();


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

        //-------------------------------------------------- BOTON GUARDAR TABLA MARCAR -----------------------------------------------|
        function Ajax_Pendiente_Marcar() {

            var Data_Par = JSON.stringify({
                "ATE_NUM": ATE_NUM_Pendiente,
                "CB": CB_Pendiente,
                "ID_RECEP_ETI_RECHAZO_SUPREMO": ID_RECEP_ETI_RECHAZO_SUPREMO
            });
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/Ajax_Pendiente_Marcar",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {



                        $('#modal_pendientes').modal('hide');
                        //$("#mError_AAH h4").text("Muestra Eliminada");
                        //$("#mError_AAH button").attr("class", "btn btn-success");
                        //$("#mError_AAH p").text("La muestra ha sido eliminada satisfactoriamente.");
                        //$("#mError_AAH").modal();
                        $("#txtNum").val("");
                        $("#txtNAte").val("");
                        $("#txtRut").val("");
                        $("#txtNom").val("");
                        $("#txtEdad").val("");
                        $("#txtSexo").val("");
                        $("#txtFono").val("");
                        $("#txtCel").val("");
                        $("#txtObsAte").val("");
                        $("#txtObsTm").val("");
                        //$('#eModal').modal('hide');
                        Ajax_DataTable_Load();
                    } else {

                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado muestras recepcionadas por el usuario.");
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

        //-------------------------------------------------- TABLA MARCAR -------------------------------------------------------------|
        var Mx_Dtt_Marcar = [
            {
                "ID_T_MUESTRA": 0,
                "ATE_NUM": 0,
                "ID_ATENCION": 0,
                "ID_PER": 0,
                "T_MUESTRA_DESC": 0,
                "CB_DESC": 0,
                "Expr1": 0,
                "CF_DESC": 0,
                "ATE_EST_TM": 0,
                "ID_PRUEBA": 0,
                "ATE_USU_RECHAZO": 0,
                "EST_DESCRIPCION": 0,
                "ATE_FEC_RECHAZO": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "USU_NIC": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "PREVE_DESC": 0,
                "PROC_DESC": 0

            }
        ];

        function Llenar_Modal_Cargar_Doble_click(NUM_ATE) {
            $("#txtNAte").val(NUM_ATE);
            $("#txtNum").val(NUM_ATE);
            modal_show();

            var Data_Par = JSON.stringify({
                "NUM_ATE": NUM_ATE
            });
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/Llenar_Modal_Cargar_Doble_click",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Ajax_Info_Exa_Asereje();
                        Mx_Dtt_Marcar = JSON.parse(json_receiver);
                        //ID_Pac = Mx_Dtt_Marcar[0].ID_PACIENTE;
                        Ajax_Info_Exa_Asereje();

                        for (let i = 0; i < Mx_Dtt_Marcar.length; ++i) {
                            var date_x = Mx_Dtt_Marcar[i].ATE_FEC_RECHAZO;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Marcar[i].ATE_FEC_RECHAZO = Date_Change;
                        }

                        //$("#superNumAte").text(Mx_Dtt_Marcar[0].ATE_NUM);
                        $("#superNombre").text(Mx_Dtt_Marcar[0].DOC_NOMBRE + " " + Mx_Dtt_Marcar[0].DOC_APELLIDO);
                        //$("#superPrevision").text(Mx_Dtt_Marcar[0].PREVE_DESC);
                        //$("#superLugar").text(Mx_Dtt_Marcar[0].PROC_DESC);
                        //nombre_waaa = $("#txtNom").val();
                        //$("#superNomPaciente").text(Mx_Dtt_Marcar[0].PAC_NOMBRE + " " + Mx_Dtt_Marcar[0].PAC_APELLIDO);

                        $("#Div_Tabla_Antiguos").empty();
                        $("#sss").text("Detalle de Estado N°:" + " " + Mx_Dtt_Marcar[0].ATE_NUM);
                        $('#eModal').modal('hide');
                        Fill_DataTable_Antiguos();

                        $("#superNumAte").text(Mx_Dtt_Marcar[0].ATE_NUM);
                        //$("#superNombre").text(Mx_Dtt_Marcar[0].DOC_NOMBRE + " " + Mx_Dtt_Marcar[0].DOC_APELLIDO);
                        $("#superPrevision").text(Mx_Dtt_Marcar[0].PREVE_DESC);
                        $("#superLugar").text(Mx_Dtt_Marcar[0].PROC_DESC);
                        nombre_waaa = $("#txtNom").val();
                        $("#superNomPaciente").text(Mx_Dtt_Marcar[0].PAC_NOMBRE + " " + Mx_Dtt_Marcar[0].PAC_APELLIDO);

                        $('#eModal').modal('show');

                        Hide_Modal();


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


        //-------------------------------------------------- TABLA MARCAR SEGUN DIRECCION ---------------------------------------------|
        var Mx_Dtt_Marcar = [
            {
                "ID_T_MUESTRA": 0,
                "ATE_NUM": 0,
                "ID_ATENCION": 0,
                "ID_PER": 0,
                "T_MUESTRA_DESC": 0,
                "CB_DESC": 0,
                "Expr1": 0,
                "CF_DESC": 0,
                "ATE_EST_RECHAZO": 0,
                "ID_PRUEBA": 0,
                "ATE_FEC_RECHAZO": 0,
                "ATE_USU_RECHAZO": 0,
                "EST_DESCRIPCION": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "USU_NIC": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "PREVE_DESC": 0,
                "PROC_DESC": 0

            }
        ];

        function Ajax_DataTable_Marcar_Direccion(direccion) {
            modal_show();
            var ID_USU = $("#slct-usuario-tdem").val();

            if (ID_USU === null || ID_USU === 0) {
                alert("Por favor, seleccione un usuario.");
                return;
            }

            var Data_Par = JSON.stringify({
                "N_ATE": direccion,
                "ID_USU": ID_USU
            });
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/Llenar_DataTable3",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Marcar = JSON.parse(json_receiver);

                        for (let i = 0; i < Mx_Dtt_Marcar.length; ++i) {
                            var date_x = Mx_Dtt_Marcar[i].ATE_FEC_RECHAZO;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Marcar[i].ATE_FEC_RECHAZO = Date_Change;
                        }

                        $("#superNumAte").text(Mx_Dtt_Marcar[0].ATE_NUM);
                        //$("#superNombre").text(Mx_Dtt_Marcar[0].DOC_NOMBRE + " " + Mx_Dtt_Marcar[0].DOC_APELLIDO);
                        $("#superPrevision").text(Mx_Dtt_Marcar[0].PREVE_DESC);
                        $("#superLugar").text(Mx_Dtt_Marcar[0].PROC_DESC);
                        nombre_waaa = $("#txtNom").val();
                        $("#superNomPaciente").text(Mx_Dtt_Marcar[0].PAC_NOMBRE + " " + Mx_Dtt_Marcar[0].PAC_APELLIDO);

                        $("#Div_Tabla_Antiguos").empty();
                        $("#sss").text("Detalle de Estado Folio N°:" + " " + Mx_Dtt_Marcar[0].ATE_NUM);
                        $('#txtNAte').val(Mx_Dtt_Marcar[0].ATE_NUM);
                        ID_Ateee = Mx_Dtt_Marcar[0].ID_ATENCION;
                        Ajax_DataTable_Asereje();
                        Ajax_Info_Asereje();
                        Fill_DataTable_Antiguos();

                        $("#superNumAte").text(Mx_Dtt_Marcar[0].ATE_NUM);
                        $("#superNombre").text(Mx_Dtt_Marcar[0].DOC_NOMBRE + " " + Mx_Dtt_Marcar[0].DOC_APELLIDO);
                        $("#superPrevision").text(Mx_Dtt_Marcar[0].PREVE_DESC);
                        $("#superLugar").text(Mx_Dtt_Marcar[0].PROC_DESC);
                        nombre_waaa = $("#txtNom").val();
                        $("#superNomPaciente").text(Mx_Dtt_Marcar[0].PAC_NOMBRE + " " + Mx_Dtt_Marcar[0].PAC_APELLIDO);

                        //Hide_Modal();


                    } else {


                        Hide_Modal();
                        Mx_Dtt_Marcar.length = 1;
                        $("#Div_Tabla_Antiguos").empty();
                        $("#DataTable_Antiguos").empty();
                        Mx_Dtt_Marcar[0].ATE_NUM = direccion;
                        $("#sss").text("Detalle de Estado Folio N°:" + " " + Mx_Dtt_Marcar[0].ATE_NUM);
                        Mx_Dtt_Marcar[0].ID_T_MUESTRA = "";
                        Mx_Dtt_Marcar[0].ID_ATENCION = "";
                        Mx_Dtt_Marcar[0].ID_PER = "";
                        Mx_Dtt_Marcar[0].T_MUESTRA_DESC = "";
                        Mx_Dtt_Marcar[0].CB_DESC = "";
                        Mx_Dtt_Marcar[0].Expr1 = "";
                        Mx_Dtt_Marcar[0].CF_DESC = "";
                        Mx_Dtt_Marcar[0].ATE_EST_TM = "";
                        Mx_Dtt_Marcar[0].EST_DESCRIPCION = "";
                        Mx_Dtt_Marcar[0].RECEP_ETI_FECHA = "";
                        Mx_Dtt_Marcar[0].PAC_NOMBRE = "";
                        Mx_Dtt_Marcar[0].PAC_APELLIDO = "";
                        Mx_Dtt_Marcar[0].USU_NIC = "";

                        $("#superNumAte").text("");
                        $("#superNombre").text("");
                        $("#superPrevision").text("");
                        $("#superLugar").text("");
                        $("#superNomPaciente").text("");

                        Fill_DataTable_Antiguos();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        //-------------------------------------------------- BOTON GUARDAR LOTE -------------------------------------------------------|
        var correlativin = 0;

        function Guardar_Lote() {

            //var Data_Par = JSON.stringify({
            //    "ATE_NUM": ATE_NUM_Pendiente,
            //    "CB": CB_Pendiente
            //});
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/Guardar_Lote",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        correlativin = JSON.parse(json_receiver)


                        $("#Modal_Correlativo h4").text("Lote CREADO");
                        $("#Modal_Correlativo button").attr("class", "btn btn-success");
                        $("#Modal_Correlativo p").text("Lote Número: " + correlativin);
                        $("#Modal_Correlativo").modal();
                        Mx_Dtt_Load[0].ID_USUARIO = 0;
                        correxxx = correlativin;
                        //Ajax_Get_values_to_Lote(correlativin);
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

        //-------------------------------------------------- GUARDAR LOTE 2da PARTE ---------------------------------------------------|
        function Guardar_Lote_2(correlativin2) {
            var ID_USU = $("#slct-usuario-tdem").val();

            if (ID_USU === null || ID_USU === 0) {
                alert("Por favor, seleccione un usuario.");
                return;
            }

            var Data_Par = JSON.stringify({
                "correlativin": correlativin2,
                ID_USU
            });
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/Guardar_Lote2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver == "null") {


                        $('#Modal_Correlativo').modal('hide');
                        $("#Modal_Correlativo").hide();
                        Ajax_DataTable_Load();
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

        //-------------------------------------------------- MAS INFO PACIENTE --------------------------------------------------------|
        var Mx_Dtt_Atencion = [
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
                "ID_PACIENTE": 0
            }
        ];

        function Ajax_Info() {
            modal_show();

            var Data_Par = JSON.stringify({
                "ID_USU": ID_Ateee
            });
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/Info",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Atencion = json_receiver;

                        for (let i = 0; i < Mx_Dtt_Atencion.length; ++i) {
                            var date_x = Mx_Dtt_Atencion[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Atencion[i].ATE_FECHA = Date_Change;
                        }

                        ID_Pac = Mx_Dtt_Atencion[0].ID_PACIENTE;
                        Ajax_Exa_Info();



                    } else {

                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();


                }
            });
        }

        //-------------------------------------------------- EXAMENES INFO PACIENTE ---------------------------------------------------|
        var Mx_Dtt_Datos_Actuales = [
            {
                "ID_ATENCION": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "ATE_NUM": 0,
                "ATE_FECHA": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "PREVE_DESC": 0,
                "PROC_DESC": 0,
                "TP_ATE_DESC": 0,
                "ID_PACIENTE": 0
            }
        ];

        function Ajax_Exa_Info() {


            var ID_USU = $("#slct-usuario-tdem").val();

            if (ID_USU === null || ID_USU === 0) {
                alert("Por favor, seleccione un usuario.");
                return;
            }

            var Data_Par = JSON.stringify({
                "ID_Pac": ID_Pac,
                "ID_USU": ID_USU
            });
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/Exa_Info",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Datos_Actuales = json_receiver;
                        Hide_Modal();

                        $("#Div_Tabla_Atencion").empty();
                        $("#Div_Datos_Actuales").empty();

                        $('#eModalInfo').modal('hide');
                        $('#eModalInfo').modal('show');

                        $("#numAtessss").text(Mx_Dtt_Datos_Actuales.length);
                        Fill_DataTable_Atencion();
                        Fill_DataTable_Datos_Actuales();


                    } else {

                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();


                }
            });
        }


        //-------------------------------------------------- VER LOTES ANTERIORES ------------------------------------------------------|
        var Mx_Dtt_Lotes_Anteriores = [
            {
                "LOTE_RECHAZO_NUM": 0,
                "ID_USUARIO": 0,
                "LOTE_RECHAZO_FECHA": 0,
                "USU_NIC": 0
            }
        ];

        function Ajax_Ver_Lotes_Anteriores() {

            //var Data_Par = JSON.stringify({
            //    "ID_Pac": ID_Pac
            //});
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Lotes_Anteriores = json_receiver;
                        Hide_Modal();

                        $('#eModal_Muestras_Por_Lotes').modal('hide');
                        $('#eModalLotesAnteriores').modal('hide');
                        $('#eModalLotesAnteriores').modal('show');
                        $("#Div_Tabla_Lotes_Anteriores").empty();

                        for (let i = 0; i < Mx_Dtt_Lotes_Anteriores.length; ++i) {
                            var date_x = Mx_Dtt_Lotes_Anteriores[i].LOTE_RECHAZO_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Lotes_Anteriores[i].LOTE_RECHAZO_FECHA = Date_Change;
                        }

                        Fill_DataTable_Lotes_Anteriores();


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
                    Hide_Modal();


                }
            });
        }

        //-------------------------------------------------- VER MUESTRAS POR LOTES ----------------------------------------------------|
        var Mx_Dtt_Muestras_Lotes = [
            {
                "LOTE_RECHAZO_NUM": 0,
                "ID_ATENCION": 0,
                "RECEP_ETI_CURVA_RECHAZO": 0,
                "RECEP_ETI_NUM_ATE_RECHAZO": 0,
                "ID_USUARIO": 0,
                "RECEP_ETI_RECHAZO_OBS": 0,
                "RECEP_ETI_FECHA_RECHAZO": 0,
                "ID_LOTE_RECHAZO": 0,
                "ID_ESTADO": 0,
                "CB_DESC": 0,
                "T_MUESTRA_DESC": 0,
                "CF_DESC": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "RLS_LS_DESC": 0,
                "ID_RLS_LS": 0,
                "EST_DESCRIPCION": 0,
                "ID_PER": 0,
                "PROC_DESC": 0,
                "ATE_AÑO": 0,
                "ATE_MES": 0,
                "ATE_DIA": 0,
                "SEXO_DESC": 0,
                "TP_RECHA_DESC": 0,
                "ID_TP_RECHA": 0,
                "USU_NIC": 0
            }
        ];

        function Ajax_Muestras_Lotes(NUMLOTE) {
            modal_show();

            var Data_Par = JSON.stringify({
                "NUMLOTE": NUMLOTE
            });
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Muestras_Lotes = json_receiver;
                        Hide_Modal();

                        $("#lote_nummmmm").text(Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM);
                        $("#DataTable_Muestras_Por_Lotes").empty();
                        $('#eModalLotesAnteriores').modal('hide');
                        $('#eModal_Muestras_Por_Lotes').modal('hide');
                        $('#eModal_Muestras_Por_Lotes').modal('show');

                        for (let i = 0; i < Mx_Dtt_Muestras_Lotes.length; ++i) {
                            var date_x = Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_FECHA_RECHAZO;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_FECHA_RECHAZO = Date_Change;
                        }

                        Fill_DataTable_Muestras_Por_Lotes();

                    } else {

                        $("#DataTable_Muestras_Por_Lotes").empty();
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();

                }
            });
        }

        function Ajax_Muestras_Lotes_direccion_negativo(NUMLOTE) {
            modal_show();

            var Data_Par = JSON.stringify({
                "NUMLOTE": NUMLOTE
            });

            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Muestras_Lotes = json_receiver;
                        $("#lote_nummmmm").text(Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM);
                        $("#DataTable_Muestras_Por_Lotes").empty();

                        for (let i = 0; i < Mx_Dtt_Muestras_Lotes.length; ++i) {
                            var date_x = Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_FECHA_RECHAZO;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_FECHA_RECHAZO = Date_Change;
                        }

                        Hide_Modal();
                        Fill_DataTable_Muestras_Por_Lotes();

                    } else {

                        Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM--;
                        $("#lote_nummmmm").text(Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM);

                        Hide_Modal();
                        $("#DataTable_Muestras_Por_Lotes").empty();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();


                }
            });
        }

        function Ajax_Muestras_Lotes_direccion_positivo(NUMLOTE) {
            modal_show();

            var Data_Par = JSON.stringify({
                "NUMLOTE": NUMLOTE
            });
            $.ajax({
                "type": "POST",
                "url": "Recha_Mues.aspx/IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Muestras_Lotes = json_receiver;
                        $("#lote_nummmmm").text(Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM);
                        $("#DataTable_Muestras_Por_Lotes").empty();

                        for (let i = 0; i < Mx_Dtt_Muestras_Lotes.length; ++i) {
                            var date_x = Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_FECHA_RECHAZO;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_FECHA_RECHAZO = Date_Change;
                        }

                        Hide_Modal();
                        Fill_DataTable_Muestras_Por_Lotes();

                    } else {

                        Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM++;
                        $("#lote_nummmmm").text(Mx_Dtt_Muestras_Lotes[0].LOTE_RECHAZO_NUM);
                        Hide_Modal();
                        $("#DataTable_Muestras_Por_Lotes").empty();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();

                }
            });
        }

        //--------------------------------------------------- CLICK EN TABLA ----------------------------------------------------------|
        function Ajax_Get_values_to_Pendiente(CBB, ATE_NUMM, ID_RECEP_ETI_RECHAZOooo) {

            CB_Pendiente = CBB;
            ATE_NUM_Pendiente = ATE_NUMM;
            ID_RECEP_ETI_RECHAZO_SUPREMO = ID_RECEP_ETI_RECHAZOooo

        };

        function Ajax_Get_values_to_Lote(LOTE) {

            correxxx = LOTE;

        };

        function Fill_Ddl_Motivo() {
            $("#Ddl_Motivo").empty();
            $("<option>", { "value": 0 }).text("Seleccione Motivo").appendTo("#Ddl_Motivo");
            $("<option>", { "value": 0 }).text("Seleccione Motivo").appendTo("#Ddl_Motivo_DIRECTO");
            for (let y = 0; y < Mx_DLL_RECHAZOS_ACTIVOS.length; ++y) {
                $("<option>", {
                    "value": Mx_DLL_RECHAZOS_ACTIVOS[y].ID_TP_RECHA
                }).text(Mx_DLL_RECHAZOS_ACTIVOS[y].TP_RECHA_DESC).appendTo("#Ddl_Motivo");

                $("<option>", {
                    "value": Mx_DLL_RECHAZOS_ACTIVOS[y].ID_TP_RECHA
                }).text(Mx_DLL_RECHAZOS_ACTIVOS[y].TP_RECHA_DESC).appendTo("#Ddl_Motivo_DIRECTO");

            }
            $('#Ddl_Motivo').select2({
                theme: 'bootstrap4',
                width: 'resolve',
                placeholder: 'Seleccione Motivo'
            });
        };

        //------------------------------------------------ TABLA Load -----------------------------------------------------------------|
        function Fill_DataTable_Load() {
            $("<table>", {
                "id": "DataTable_Load",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Load");

            $("#DataTable_Load").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Load").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Load thead").attr("class", "cabzera");
            $("#DataTable_Load thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Etiqueta"),
                    $("<th>", { "class": "textoReducido" }).text("Examen Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("Estado"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Hora"),
                    $("<th>", { "class": "textoReducido" }).text("Tipo Rechazo"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Folio"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario")
                )
            );

            for (let i = 0; i < Mx_Dtt_Load.length; i++) {
                $("#DataTable_Load tbody").append(
                    $("<tr>", {
                        "class": "manito",
                        id: Mx_Dtt_Load[i].ID_RECEP_ETI_RECHAZO,

                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("[" + Mx_Dtt_Load[i].CB_DESC + "]" + " " + Mx_Dtt_Load[i].T_MUESTRA_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].CF_DESC),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt_Load[i].EST_DESCRIPCION == "RECHAZO") {
                                $(this).css("cssText", "background-color: #ff4f4f !important; cursor:pointer; text-align:center;").text(Mx_Dtt_Load[i].EST_DESCRIPCION);
                            }
                            else {
                                $(this).css("cssText", "background-color:#f5b0e5 !important; text-align:center;").text(Mx_Dtt_Load[i].EST_DESCRIPCION);
                            }
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Load[i].RECEP_ETI_FECHA_RECHAZO);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date2 = new Date(Mx_Dtt_Load[i].RECEP_ETI_FECHA_RECHAZO);
                            var hh = parseInt(obj_date2.getHours());
                            var mm = parseInt(obj_date2.getMinutes());
                            var ss = parseInt(obj_date2.getSeconds());

                            if (hh < 10) { hh = "0" + hh; }
                            if (mm < 10) { mm = "0" + mm; }
                            if (ss < 10) { ss = "0" + ss; }

                            return String(hh + ":" + mm + ":" + ss);
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].TP_RECHA_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].PAC_NOMBRE + " " + Mx_Dtt_Load[i].PAC_APELLIDO),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].USU_NIC)
                    )
                );
            }

            $("#DataTable_Load tbody tr").on("click", (e) => {
                const idCliqued = e.currentTarget.id;
                const objClicked = Mx_Dtt_Load.find(item => item.ID_RECEP_ETI_RECHAZO == idCliqued);
                Ajax_Get_values_to_Pendiente(objClicked.CB_DESC, objClicked.ATE_NUM, objClicked.ID_RECEP_ETI_RECHAZO);
            });
            $("#DataTable_Load tbody tr").on("dblclick", (e) => {
                const idCliqued = e.currentTarget.id;
                const objClicked = Mx_Dtt_Load.find(item => item.ID_RECEP_ETI_RECHAZO == idCliqued);
                Llenar_Modal_Cargar_Doble_click(objClicked.ATE_NUM);
            });

            //Declarar evento
            $("#DataTable_Load tbody tr").click(function () {
                $("#DataTable_Load tbody tr").removeClass("active");
                $(this).addClass("active");
            });
        }
        //------------------------------------------------ TABLA LISTADO DE MUESTRAS --------------------------------------------------|
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
                    $("<th>", { "class": "textoReducido" }).text(""),
                    $("<th>", { "class": "textoReducido" }).text("Etiqueta"),
                    $("<th>", { "class": "textoReducido" }).text("Examen Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("Estado"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Hora"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Folio"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario")

                )
            );

            for (let i = 0; i < Mx_Dtt_Table.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("[" + Mx_Dtt_Table[i].CB_DESC + "]" + " " + Mx_Dtt_Table[i].T_MUESTRA_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Table[i].CF_DESC),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt_Table[i].EST_DESCRIPCION == "RECHAZO") {
                                $(this).css("cssText", "background-color: #ff4f4f !important; color:white; cursor:pointer; text-align:center;").text(Mx_Dtt_Table[i].EST_DESCRIPCION);
                            }
                            else {
                                $(this).css("cssText", " color:inherit; background-color:#ff4f4f !important; text-align:center;").text(Mx_Dtt_Table[i].EST_DESCRIPCION);
                            }
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Table[i].RECEP_ETI_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date2 = new Date(Mx_Dtt_Table[i].RECEP_ETI_FECHA);
                            var hh = parseInt(obj_date2.getHours());
                            var mm = parseInt(obj_date2.getMinutes());
                            var ss = parseInt(obj_date2.getSeconds());

                            if (hh < 10) { hh = "0" + hh; }
                            if (mm < 10) { mm = "0" + mm; }
                            if (ss < 10) { ss = "0" + ss; }

                            return String(hh + ":" + mm + ":" + ss);
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Table[i].PAC_NOMBRE + " " + Mx_Dtt_Table[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Table[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Table[i].USU_NIC)
                    )
                );
            }
        }

        //------------------------------------------------ TABLA MARCAR  --------------------------------------------------------------|
        function Fill_DataTable_Antiguos() {
            $("<table>", { "id": "DataTable_Antiguos", "class": "display", "width": "100%", "cellspacing": "0" }).appendTo("#Div_Tabla_Antiguos");

            $("#DataTable_Antiguos").append($("<thead>"), $("<tbody>"));
            $("#DataTable_Antiguos").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Antiguos thead").attr("class", "cabzera");

            $("#DataTable_Antiguos thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Etiqueta"),
                    $("<th>", { "class": "textoReducido" }).text("Examen Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("Estado"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Hora"),
                    $("<th>", { "class": "textoReducido" }).text("Tipo Rechazo"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Folio"),
                    $("<th>", { "class": "textoReducido" }).text("Marcar"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario")
                )
            );
            const contieneCBEscaneado = Mx_Dtt_Marcar.some(item => item.CB_DESC === GLOBAL_ETIQUETA_ESCANEADA);
            Mx_Dtt_Marcar = Mx_Dtt_Marcar.filter(item => item.CB_DESC === GLOBAL_ETIQUETA_ESCANEADA || GLOBAL_ETIQUETA_ESCANEADA === 0 || !contieneCBEscaneado);
            for (let i = 0; i < Mx_Dtt_Marcar.length; i++) {
                $("#DataTable_Antiguos tbody").append(
                    $("<tr>", { id: Mx_Dtt_Marcar[i].ID_CODIGO_FONASA }).append(
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt_Marcar[i].CB_DESC == "") {
                                $(this).css("cssText", "text-align:center;").text("");
                            }
                            else {
                                $(this).css("cssText", "text-align:center;").text(i + 1);
                            }
                        }),

                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt_Marcar[i].CB_DESC == "") {
                                $(this).css("cssText", "text-align:center;").text("");
                            }
                            else {
                                $(this).css("cssText", "text-align:left;").text("[" + Mx_Dtt_Marcar[i].CB_DESC + "]" + " " + Mx_Dtt_Marcar[i].T_MUESTRA_DESC);
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Marcar[i].CF_DESC),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt_Marcar[i].EST_DESCRIPCION == "ESPERA") {
                                $(this).css("cssText", "text-align:center;background-color:#efedc9;").text(Mx_Dtt_Marcar[i].EST_DESCRIPCION);
                            } else if (Mx_Dtt_Marcar[i].EST_DESCRIPCION == "RECHAZO") {
                                $(this).css("cssText", "text-align:center;background-color:#ff4f4f;").text(Mx_Dtt_Marcar[i].EST_DESCRIPCION);
                            } else if ((Mx_Dtt_Marcar[i].EST_DESCRIPCION == "ATENDIDO") || (Mx_Dtt_Marcar[i].EST_DESCRIPCION == "RECEP.")) {
                                $(this).css("cssText", "text-align:center;background-color:#4bbc62;").text(Mx_Dtt_Marcar[i].EST_DESCRIPCION);
                            }
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt_Marcar[i].EST_DESCRIPCION == "ESPERA") {
                                return "-/-";
                            } else {
                                //Obtener valores
                                var obj_date = new Date(Mx_Dtt_Marcar[i].ATE_FEC_RECHAZO);
                                var dd = parseInt(obj_date.getDate());
                                var mm = parseInt(obj_date.getMonth()) + 1;
                                var yy = parseInt(obj_date.getFullYear());

                                if (dd < 10) { dd = "0" + dd; }
                                if (mm < 10) { mm = "0" + mm; }

                                return String(dd + "/" + mm + "/" + yy);
                            }

                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt_Marcar[i].EST_DESCRIPCION == "ESPERA") {
                                return "-/-";
                            } else {
                                //Obtener valores
                                var obj_date2 = new Date(Mx_Dtt_Marcar[i].ATE_FEC_RECHAZO);
                                var hh = parseInt(obj_date2.getHours());
                                var mm = parseInt(obj_date2.getMinutes());
                                var ss = parseInt(obj_date2.getSeconds());

                                if (hh < 10) { hh = "0" + hh; }
                                if (mm < 10) { mm = "0" + mm; }
                                if (ss < 10) { ss = "0" + ss; }

                                return String(hh + ":" + mm);
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Marcar[i].TP_RECHA_DESC),
                        $("<td>").css("text-align", "center").text(function () {
                            $(this).css("cssText", "text-align:left;").text(Mx_Dtt_Marcar[i].PAC_NOMBRE + " " + Mx_Dtt_Marcar[i].PAC_APELLIDO);
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt_Marcar[i].CB_DESC == "") {
                                $(this).css("cssText", "text-align:center;").text("");
                            }
                            else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt_Marcar[i].ATE_NUM);
                            }
                        }),
                        //Mostrar Check Segun estado de recep 
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt_Marcar[i].CB_DESC == "") {
                            } else {
                                if (Mx_Dtt_Marcar[i].EST_DESCRIPCION == "RECHAZO") {
                                    $(this).css("cssText", "text-align:center;background-color:#f7e1f4;").text("");
                                }
                                else {
                                    $(this).html("<input type='checkbox' name='rechazo-marcar' id='chekito" + i + "' value='" + Mx_Dtt_Marcar[i].CB_DESC + "'/>")
                                }
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Marcar[i].USU_NIC)
                    )
                );
            }
        }

        //------------------------------------------------ ANTECEDENTES PACIENTE  ----------------------------------------------------|
        function Fill_DataTable_Atencion() {
            //     -------------------------------------------------  1   ---------------------------------------|
            $("<table>", {
                "id": "DataTable_Atencion",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Atencion");

            $("#DataTable_Atencion").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Atencion").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Atencion thead").attr("class", "cabezera");

            $("#DataTable_Atencion thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Nac."),
                    $("<th>", { "class": "textoReducido" }).text("Edad"),
                    $("<th>", { "class": "textoReducido" }).text("Sexo"),
                    $("<th>", { "class": "textoReducido" }).text("F.U.R")

                )
            );

            for (let i = 0; i < Mx_Dtt_Atencion.length; i++) {
                var sexo = "";
                if (Mx_Dtt_Atencion[i].SEXO_DESC == "Femenino") {

                } else {

                };
                $("#DataTable_Atencion tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_NOMBRE + " " + Mx_Dtt_Atencion[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_FNAC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].ATE_AÑO + " Años"),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt_Atencion[i].SEXO_DESC == "Femenino") {
                                $(this).css("cssText", "background-color:#f5b0e5 !important;  cursor:pointer; text-align:center;").text("Femenino");
                            }
                            else {
                                $(this).css("cssText", " color:inherit; background-color:#88d6e2 !important; text-align:center;").text("Masculino");
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].ATE_FUR)
                    )
                );
            }
            //   ------------------------------------------------ 2 ---------------------------------------------|
            $("<table>", {
                "id": "DataTable_Atencion2",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Atencion");

            $("#DataTable_Atencion2").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Atencion2").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Atencion2 thead").attr("class", "cabezera");

            $("#DataTable_Atencion2 thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Nacionalidad"),
                    $("<th>", { "class": "textoReducido" }).text("Teléfono Fijo"),
                    $("<th>", { "class": "textoReducido" }).text("Celular"),
                    $("<th>", { "class": "textoReducido" }).text("Ciudad"),
                    $("<th>", { "class": "textoReducido" }).text("Comuna"),
                    $("<th>", { "class": "textoReducido" }).text("Dirección")
                )
            );

            for (let i = 0; i < Mx_Dtt_Atencion.length; i++) {
                $("#DataTable_Atencion2 tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].NAC_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_FONO1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_MOVIL1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].CIU_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].COM_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_DIR)
                    )
                );
            }

            //------------------------------------------------------- 3 --------------------------------------------------------|
            $("<table>", {
                "id": "DataTable_Atencion3",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Atencion");

            $("#DataTable_Atencion3").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Atencion3").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Atencion3 thead").attr("class", "cabezera");

            $("#DataTable_Atencion3 thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Email"),
                    $("<th>", { "class": "textoReducido" }).text("Observaciones PERMANENTES del Paciente")
                )
            );

            for (let i = 0; i < Mx_Dtt_Atencion.length; i++) {
                $("#DataTable_Atencion3 tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_EMAIL),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_OBS_PERMA)
                    )
                );
            }
            //------------------------------------------------------- 4 ---------------------------------------------------------------|
            $("<table>", {
                "id": "DataTable_Atencion4",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Atencion");

            $("#DataTable_Atencion4").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Atencion4").attr("class", "table table table-hover table-striped table-iris");
            $("#DataTable_Atencion4 thead").attr("class", "cabezera");

            $("#DataTable_Atencion4 thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Observación de la Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Observación de Toma de Muestra")

                )
            );

            for (let i = 0; i < Mx_Dtt_Atencion.length; i++) {
                $("#DataTable_Atencion4 tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].ATE_OBS_FICHA),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].ATE_OBS_TM)
                    )
                );
            }

        }

        //------------------------------------------------ TABLA ATENCIONES REGISTRADAS ANTECEDENTES PACIENTE --------------------------|
        function Fill_DataTable_Datos_Actuales() {
            $("<table>", {
                "id": "DataTable_Atencion_Datos_Actuales",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Datos_Actuales");

            $("#DataTable_Atencion_Datos_Actuales").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Atencion_Datos_Actuales").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Atencion_Datos_Actuales thead").attr("class", "cabezera2");

            $("#DataTable_Atencion_Datos_Actuales thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar de TM"),
                    $("<th>", { "class": "textoReducido" }).text("Tipo Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Previsión"),
                    $("<th>", { "class": "textoReducido" }).text("Médico")
                )
            );

            for (let i = 0; i < Mx_Dtt_Datos_Actuales.length; i++) {
                $("#DataTable_Atencion_Datos_Actuales tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Datos_Actuales[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Datos_Actuales[i].PAC_NOMBRE + " " + Mx_Dtt_Datos_Actuales[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Datos_Actuales[i].ATE_FECHA),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Datos_Actuales[i].PROC_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Datos_Actuales[i].TP_ATE_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Datos_Actuales[i].PREVE_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Datos_Actuales[i].DOC_NOMBRE + " " + Mx_Dtt_Datos_Actuales[i].DOC_APELLIDO)
                    )
                );
            }
        }

        //------------------------------------------------ TABLA LOTES ANTERIORES   -----------------------------------------------------|
        function Fill_DataTable_Lotes_Anteriores() {
            $("<table>", {
                "id": "DataTable_Lotes_Anteriores",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Lotes_Anteriores");

            $("#DataTable_Lotes_Anteriores").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Lotes_Anteriores").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Lotes_Anteriores thead").attr("class", "cabezera2");

            $("#DataTable_Lotes_Anteriores thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario"),
                    $("<th>", { "class": "textoReducido" }).text("fecha"),
                    $("<th>", { "class": "textoReducido" }).text("N° Lote")
                )
            );

            for (let i = 0; i < Mx_Dtt_Lotes_Anteriores.length; i++) {
                $("#DataTable_Lotes_Anteriores tbody").append(
                    $("<tr>", {
                        "data-lote-num": Mx_Dtt_Lotes_Anteriores[i].LOTE_RECHAZO_NUM,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Lotes_Anteriores[i].USU_NIC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Lotes_Anteriores[i].LOTE_RECHAZO_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Lotes_Anteriores[i].LOTE_RECHAZO_NUM)
                    )
                );
            }
            $("#DataTable_Lotes_Anteriores tbody tr").on("click", e => {
                const loteNum = e.currentTarget.getAttribute("data-lote-num");
                Ajax_Muestras_Lotes(loteNum);
            })
        }

        //------------------------------------------------ TABLA MUESTRAS POR LOTES -----------------------------------------------------|
        function Fill_DataTable_Muestras_Por_Lotes() {
            $("<table>", {
                "id": "DataTable_Muestras_Por_Lotes",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Muestras_Lotes");

            $("#DataTable_Muestras_Por_Lotes").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Muestras_Por_Lotes").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Muestras_Por_Lotes thead").attr("class", "cabezera");

            $("#DataTable_Muestras_Por_Lotes thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Etiqueta"),
                    $("<th>", { "class": "textoReducido" }).text("Examen Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("Estado"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Hora"),
                    $("<th>", { "class": "textoReducido" }).text("Tipo Rechazo"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Folio"),
                    $("<th>", { "class": "textoReducido" }).text("N° Lote"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario"),
                    $("<th>", { "class": "textoReducido" }).text("Desc. Sección"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar")
                )
            );

            for (let i = 0; i < Mx_Dtt_Muestras_Lotes.length; i++) {
                $("#DataTable_Muestras_Por_Lotes tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text("[" + Mx_Dtt_Muestras_Lotes[i].CB_DESC + "]" + " " + Mx_Dtt_Muestras_Lotes[i].T_MUESTRA_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].CF_DESC),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt_Muestras_Lotes[i].EST_DESCRIPCION == "RECEP.") {
                                $(this).css("cssText", "background-color: #88d6e2 !important; cursor:pointer; text-align:center;").text("RECEP.");
                            }
                            else {
                                $(this).css("cssText", "background-color:#f5b0e5 !important; text-align:center;").text(Mx_Dtt_Muestras_Lotes[i].EST_DESCRIPCION);
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(function () {
                            var obj_date = new Date(Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_FECHA_RECHAZO);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(function () {
                            const fec_recha = new Date(Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_FECHA_RECHAZO);

                            const hours = String(fec_recha.getHours()).padStart(2, '0');
                            const minutes = String(fec_recha.getMinutes()).padStart(2, '0');
                            const seconds = String(fec_recha.getSeconds()).padStart(2, '0');

                            return `${hours}:${minutes}:${seconds}`;
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].TP_RECHA_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].PAC_NOMBRE + " " + Mx_Dtt_Muestras_Lotes[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].RECEP_ETI_NUM_ATE_RECHAZO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].LOTE_RECHAZO_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].USU_NIC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].RLS_LS_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].PROC_DESC)
                    )
                );
            }
        }

        //function generarMensaje() {
        //    const responsable = document.getElementById("Txt_responsable").value.trim();
        //    const datosExtras = document.getElementById("Txt_datosExtras").value.trim();
        //    const fecha = new Date().toLocaleDateString('es-CL');
        //    const hora = new Date().toLocaleTimeString('es-CL', { hour: '2-digit', minute: '2-digit', second: '2-digit' });

        //    if (!responsable) {
        //        alert("Por favor, ingrese el nombre del responsable.");
        //        return;
        //    }

        //    const mensaje = `RESPONSABLE : ${responsable} | INFORMACION EXTRA: ${datosExtras} | FECHA: ${fecha} | HORA: ${hora}`;

        //    document.getElementById("Txt_mensajeGenerado").value = mensaje;
        //}

    </script>


    <style>
        
        .progress-bar.animate {
            width: 100%;
        }

        #DataTable tbody td {
            text-transform: uppercase;
        }

        #DataTable_Ate tbody td {
            text-transform: uppercase;
        }

        #DataTable_Lis_Exa_Ate tbody td {
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

        .cabzera {
            background: #46963f;
            color: white;
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

        .textoReducido2 {
            font-size: 10px;
        }

        .highlights {
            width: 710px;
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

        .checkbox-success input[type="checkbox"]:checked + label::before {
            background-color: #5cb85c;
            border-color: #5cb85c;
        }

        .checkbox-success input[type="checkbox"]:checked + label::after {
            color: #fff;
        }

        .checkbox-success {
            line-height: 13px;
            margin-bottom: 3px;
        }

            .checkbox-success input[type="checkbox"], label {
                cursor: pointer;
            }

        .checkbox label {
            width: 90%;
        }

        @media screen and (max-width: 600px) {
            #Paciente {
                margin-bottom: 1rem;
            }

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
        }

        
        .radios-reb-aum-stock {
            display: -webkit-box;
            display: -ms-flexbox;
            display: flex;
            -ms-flex-pack: distribute;
            justify-content: space-around;
            width: 100%;
            -webkit-box-align: center;
            -ms-flex-align: center;
            align-items: center;
            -ms-grid-column-span: 2;
            grid-column: span 2;
        }
        input[type=radio] {
            width: 40px;
            height: 40px;
            cursor: pointer;
        }

        /**SELECT2 para tipos de rechazo */
  .select2-container--bootstrap4 .select2-selection {
  border: 1px solid #ced4da !important;
  border-radius: .25rem !important;
  padding: .375rem .75rem;
  height: auto !important;
}

.select2-container--bootstrap4 .select2-results__option {
  white-space: normal !important;
  word-break: break-word;
  line-height: 1.2;
  padding: 6px 12px;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="modal fade" id="eModal" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document" style="max-width:60vw">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss"></h4>
                </div>
                <div class="row">
                    <div class="col-md-1"></div>
                <div class="col-md-7">
                    <div class="row">
                        <div class="col-md-2">
                            <label>Paciente: </label>
                        </div>
                        <div class="col-md-10">
                            <label id="superNomPaciente"></label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <label>Médico: </label>
                        </div>
                        <div class="col-md-10">
                            <label id="superNombre"></label>
                        </div>
                    </div>
                </div>
                    <div class="col-md-4">
                    <div class="row">
                        <div class="col">
                            <label>N° Atención: </label>
                        </div>
                        <div class="col">
                            <label id="superNumAte"></label>
                        </div>
                    </div>
                        <div class="row">
                            <div class="col">
                                <label>Previsión: </label>
                            </div>
                            <div class="col">
                                <label id="superPrevision"></label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Lugar de TM: </label>
                            </div>
                            <div class="col">
                                <label id="superLugar"></label>
                            </div>
                        </div>
                       
                    </div>
            </div>
                <div class="modal-body">
                    <div id="Div_Tabla_Antiguos" style="width: 100%;" class="table-responsive"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="Btn_Anterior" class="btn btn-dark fa fa-arrow-circle-o-left"></button>
                    <button type="button" id="Btn_Siguiente" class="btn btn-dark fa fa-arrow-circle-o-right"></button>
                    <button type="button" id="Btn_Guardar" class="btn btn-primary"><i class="fa fa-fw fa-save mr-2"></i>Guardar</button>
                    <button type="button" id="Btn_Marcar" class="btn btn-dark"><i class="fa fa-fw fa-check mr-2"></i>Marcar Todos</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Salir</button>
                </div>
                </div>
            </div>
        </div>
    <!-- Modal de confirmacion pendientes -->
    <div id="modal_pendientes" class="modal fade" role="dialog">
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
                    <button type="button" id="Btn_Pendiente_Si" class="btn btn-success"><i class="fa fa-fw fa-check mr-2"></i>Si</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-remove mr-2"></i>No</button>
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
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Correlativo-->
    <div id="Modal_Correlativo" class="modal fade" role="dialog">
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
                    <button id="Btn_Confirmar_Lote" class="btn btn-danger" type="submit"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>
        <!-- Modal Confirmar rechazo-->
    <div id="Modal_Confirmar_rechazo" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <div class="col-lg ml-3">
                        <div class="row">
                        <label for="Ddl_Motivo">Tipo de Rechazo:</label>
                        </div>
                        <div class="row">
                       <select id="Ddl_Motivo" class="form-control"style="width: 93%;">
                            <option value="0">Seleccionar Motivo</option>
                        </select>
                        </div>
                    </div>
                    <div class="col-lg">
                        <label for="Txt_Motivo">Hora de Notificación:</label>
                        <input type="datetime-local" id="Txt_Motivo" class="form-control"/>
                    </div>
                    <div class="col-lg">
                        <label for="Txt_responsable">Avisado A:</label>
                        <input type="text" id="Txt_responsable" class="form-control" placeholder="Ingrese a quien desea"/>
                    </div>

                  <%--  <div class="col-lg mt-2">
                        <label for="Txt_datosExtras">Información Extra:</label>
                        <textarea id="Txt_datosExtras" class="form-control"></textarea>
                    </div>--%>

                    <%--<button id="btnGenerar" class="btn btn-primary mt-2">Generar Mensaje</button>

                    <div class="col-lg mt-2">
                        <label for="Txt_mensajeGenerado">Mensaje Generado:</label>
                        <textarea id="Txt_mensajeGenerado" class="form-control" readonly></textarea>
                    </div>--%>
                </div>
                <div class="modal-footer">
                    <button id="Btn_Confirmar_Rechazo" class="btn btn-success" type="submit"><i class="fa fa-fw fa-save mr-2"></i>Guardar</button>
                    <button class="btn btn-danger" type="submit" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>
            <!-- Modal Confirmar rechazo DIRECTP-->
    <div id="Modal_Confirmar_rechazo_DIRECTO" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <div class="col-lg">
                        <label for="Ddl_Motivo_DIRECTO">Tipo de Rechazo:</label>
                        <select id="Ddl_Motivo_DIRECTO" class="form-control">
                            <option value="0">Seleccionar Motivo</option>
                        </select>
                    </div>
                    <div class="col-lg">
                        <label for="Txt_Motivo_DIRECTO">Observación de Rechazo:</label>
                        <textarea id="Txt_Motivo_DIRECTO" class="form-control"></textarea>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="Btn_Confirmar_Rechazo_DIRECTO" class="btn btn-success" type="submit"><i class="fa fa-fw fa-save mr-2"></i>Guardar</button>
                    <button class="btn btn-danger" type="submit" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <%-------------------------------------------------- MODAL DE INFO PACIENTE -------------------------------------------------------%>
    <div class="modal fade" id="eModalInfo" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Antecedentes del Paciente</h4>
                </div>
                <div class="modal-body">
                    <div id="Div_Tabla_Atencion" style="width: 100%;" class="table-responsive"></div>
                    <h4>Listado de Atenciones Registradas</h4>
                    <div id="Div_Datos_Actuales" style="width: 100%;" class="table-responsive"></div>
                </div>
                <div class="modal-footer">
                    <h5>N° de Atenciones: </h5>
                    <h5 id="numAtessss"></h5>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <%-------------------------------------------------- MODAL LOTES ANTERIORES ---------------------------------------------------%>
    <div id="eModalLotesAnteriores" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Últimos Lotes</h4>
                </div>
                <div class="modal-body">
                    <div id="Div_Tabla_Lotes_Anteriores" style="width: 100%;" class="table-responsive"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <%---------------------------------------------------- MODAL MUESTRAS DE LOTE --------------------------------------------------------%>
    <div class="modal fade" id="eModal_Muestras_Por_Lotes" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document" style="width: 80vw; max-width: 80vw;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Listar Lote de Trabajo</h4>
                </div>
                <div class="modal-header">
                    <h5>N° Lote: </h5>
                    <button type="button" id="Btn_Anterior_Muestras_Lotes" class="btn btn-success fa fa-arrow-circle-o-left"></button>
                    <h5 id="lote_nummmmm"></h5>
                    <button type="button" id="Btn_Siguiente_Muestras_Lotes" class="btn btn-success fa fa-arrow-circle-o-right"></button>
                    <button type="button" id="Btn_Grupos_Muestras_Lotes" class="btn btn-info"><i class="fa fa-fw fa-eye mr-2"></i>Ver Grupos Anteriores</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Salir</button>
                </div>
                <div class="modal-body" style="overflow: auto;">
                    <h5 class="modal-title" id="numerito">Listado de Muestra Rechazada</h5>
                    <div id="Div_Muestras_Lotes" class="table-responsive" style="width: 100%; overflow: auto; max-height: 40vh;"></div>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>

    <%------------------------------------------------------TÍTULO, TEXTBOX Y BOTONES----------------------------------------------%>
    <div>
        <div class="col-lg-1"></div>
    <div class="card-header bg-bar">
        <h5 style="text-align: center; padding: 5px;">
            <i class="fa fa-search"></i>
            Proceso Rechazo de Muestras
        </h5>
    </div>
    <div class="row">
        <div class="col-lg-2">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtNAte">N° Etiqueta:</label>
                    <input id="txtNAte" maxlength="13" class="form-control textoReducido" type="text" placeholder="BUSCAR..." />
                    <button id="Btn_Buscar_x_ate" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                </div>
            </div>
        </div>
        <div class="col-lg-1">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtNum">N° Aten:</label>
                    <input id="txtNum" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
        <div class="col-lg-2">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtRut">Rut:</label>
                    <input id="txtRut" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
        <div class="col-lg-3">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtNom">Nombre:</label>
                    <input id="txtNom" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
        <div class="col-lg-1">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtEdad">Edad:</label>
                    <input id="txtEdad" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
        <div class="col-lg-1">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtSexo">Sexo:</label>
                    <input id="txtSexo" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
        <div class="col-lg-1">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtFono">Fono:</label>
                    <input id="txtFono" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
        <div class="col-lg-1">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtCel">Celular:</label>
                    <input id="txtCel" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
    </div>
         <%-- <div>
      
          <label for="slct-usuario-tdem">Usuario Recepción de Muestras</label>
          <select id="slct-usuario-tdem" class="form-control"></select>
      
  </div>--%>
        <div class="row">
            <div class="col">
                <div style="width: fit-content;">
                    <label for="slct-usuario-tdem">Usuario Rechazo de Muestras</label>
                    <select id="slct-usuario-tdem" class="form-control"></select>
                </div>
            </div>
            <div class="col radios-reb-aum-stock">
                <div>
                    <input class="border-secondary radioGrande" type="radio" name="radiosTipoRechazo" id="radio-tubo" value="Tubo" >
                    <label class="form-check-label" for="radio-tubo">
                        <b>Rechazo
                        <br />
                            Tubo</b></label>
                </div>
                <div>
                    <input class="border-secondary radioGrande" type="radio" name="radiosTipoRechazo" id="radio-examen" value="Examen" checked>
                    <label class="form-check-label" for="radio-examen">
                        <b>Rechazo
                        <br />
                            Examen</b></label>
                </div>
            </div>
        </div>
    <div class="row">
        <div class="col-lg-6">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtObsAte">Observaciones de la Atención:</label>
                    <input id="txtObsAte" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtObsTm">Observaciones de Toma de Muestra:</label>
                    <input id="txtObsTm" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <button id="Btn_Lote" class="btn btn-warning btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-eye mr-2"></i>Ver Lote</button>
        </div>
        <div class="col">
            <button id="Btn_Crear_Lote" class="btn btn-primary btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-save mr-2"></i>Crear Lote</button>
        </div>
        <div class="col">
            <button id="Btn_Pendiente" class="btn btn-danger btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-clock-o mr-2"></i>Pendiente</button>
        </div>
        <div class="col">
            <button id="Btn_Info" class="btn btn-info btn-block" style="margin-bottom: 1vh; padding: 3px; border: 1px;" type="submit"><i class="fa fa-fw fa-eye mr-2"></i>Más Info</button>
        </div>
    </div>
    <div class="col-lg-1"></div>
    </div>

    <%-------------------------------------------------------------TABLAS-----------------------------------------------------------%>
    <div class="row" id="Id_Conte">
        <div class="col-lg-12" id="Paciente">
            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list"></i>Listado de Muestras Rechazadas</h5>
            <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
            <div id="Div_Tabla_Load" style="width: 100%;" class="highlights"></div>
        </div>
    </div>
</asp:Content>

