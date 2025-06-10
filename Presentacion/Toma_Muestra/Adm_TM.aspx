<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Adm_TM.aspx.vb" Inherits="Presentacion.Adm_TM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <script>
        var XTIME = 1000;  //1 sec en milisec
        var SECS;
        var totalTiempo;
        var INTERVAL;
        var INTERVALCD;
        var id_ate;
        var n_ate;
        var id_pac_glob;

        var is_complete_anato;
        window.onload = function () {
            $("#txt_timer").val("15");
        };

        var checkboxIds = [
            'chkDipCUP',
            'chkDipCVC',
            'chkDipPICCLINE',
            'chkDipTET',
            'chkDipTQT',
            'chkDipAREpi'
        ];

        $(document).ready(function () {


            $("#btnSegundaCargaLista").prop("disabled", true);
            $("#btnTomaSegundaPTGO").prop("disabled", true);

            $("#btn_atendido").attr("disabled", "disabled");
            $("#btn_pendiente").attr("disabled", "disabled");
            $("#btn_imprimir").attr("disabled", "disabled");
            $("#btn_actualizar_obs").attr("disabled", "disabled");

            //Eventos para modal de listado de examenes
            // Eventos para modal de listado de exámenes
            $("#btn-atender-muestras, #btn-pendientear-muestras, #btn-en-proceso-muestras").on("click", e => {
                console.log("MODAL MODAL MODAL", $.fn.modal);

                let idUsuario = $('#prof_tm').val();

                console.log("ID de toma de muestra seleccionado:", idUsuario);

                if (!idUsuario) {
                    Swal.fire({ icon: "info", title: "Información", text: "Para modificar muestras seleccionar un Usuario TdeM " });
                    return;
                }

                let idEstado;
                if (e.currentTarget.id === "btn-atender-muestras") {
                    idEstado = 8;
                } else if (e.currentTarget.id === "btn-pendientear-muestras") {
                    idEstado = 4;
                } else if (e.currentTarget.id === "btn-en-proceso-muestras") {
                    idEstado = 19;
                }

                console.log("Botón presionado:", e.currentTarget.id, "ID Estado:", idEstado);

                const muestrasSeleccionadas = Array.from(document.querySelectorAll('input.form-check-input[name="etiquetas-atencion"]:checked'));
                const perfiles = muestrasSeleccionadas.map(item => parseInt(item.getAttribute("data-perfil")));
                const codigosBarra = muestrasSeleccionadas.map(item => item.getAttribute("data-cb"));
                const codigosFonasa = muestrasSeleccionadas.map(item => item.getAttribute("data-cf"));
                const idAtencion = parseInt(e.currentTarget.getAttribute("data-id-atencion"));

                const ateRes = Array.from(document.querySelectorAll('input.inputGuardar'))
                    .filter(input =>
                        !input.disabled &&
                        input.getAttribute("data-ate") != "0" &&
                        muestrasSeleccionadas.some(checkbox =>
                            checkbox.closest('tr') == input.closest('tr') // Verifica que el input pertenece

                        ));

                console.log("Muestras seleccionadas:", muestrasSeleccionadas.length);
                console.log("Perfiles:", perfiles);
                console.log("Códigos de barra:", codigosBarra);
                console.log("Códigos Fonasa:", codigosFonasa);
                console.log("Input: ", muestrasSeleccionadas);

                const  muestrasAnatomicas = muestrasSeleccionadas.filter(input => !input.disabled);

                console.log(ateRes)

                if (ateRes.length > 0) {
                    if (ateRes.some(item => item.value == "")) {
                        Swal.fire({
                            title: "Aviso",
                            text: "Tiene exámenes con sitio anatómico vacío, complételo para poder atender por favor",
                            icon: "warning",
                            showCancelButton: false,
                            confirmButtonText: "OK"
                        });

                        return; 
                    } else {

                        ateRes.forEach(input => {
                            let inputName = input.getAttribute("name");
                            let inputCF = input.getAttribute("data-cf-ate");
                            let inputAte = input.getAttribute("data-ate");
                            let inputValue = input.value.trim();

                            console.log("Name:", inputName);
                            console.log("CF:", inputCF);
                            console.log("Ate:", inputAte);
                            console.log("Value:", inputValue);
                            Update_Anatomico(inputValue, inputAte, inputCF)
                            input.setAttribute("disabled", true);
                        });
                    }
                }
               


                Update_Estado_Examen(idAtencion, idEstado, idUsuario, perfiles, codigosBarra, codigosFonasa);
                Ajax_DataTable();
                Ajax_Detalle_Atencion({ ID_ATENCION: idAtencion, modal: false });


            });

            $("#btnMarcarCheckboxes").on("click", () => {
                const table = document.getElementById('DataTable_Detalle_Atencion');
                const checkboxes = table.querySelectorAll('input[type="checkbox"]');
                checkboxes.forEach(checkbox => checkbox.checked = !checkbox.checked);
            });


            $('.readonly-checkbox').on('click', function (e) {
                e.preventDefault();
                return false;
            });

            // Prevenir cambios a través del teclado
            $('.readonly-checkbox').on('keydown', function (e) {
                e.preventDefault();
                return false;
            });


            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input").val(dateNow);
            $("#Txt_Date02 input").val(dateNow);

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
            Llenar_Ddl_Estados();
            Llenar_Ddl_LugarTM();
            Ajax_DL_orden_ate();

            $("#Ddl_LugarTM").on("change", function () {
                Ajax_Ddl_tm();
            });

            $("#prof_tm").on("change", function () {
                //$("#prof_tm option:selected").each(function () {
                //    $("#per_veno2").val($(this).text());
                //console.log($("#prof_tm").val())
                if ($("#prof_tm").val() != "") {
                    //console.log("no esta vacio")
                }
                //});
            });


            $("#btn_timer").on("click", function () {

                if ($("#txt_timer").val() >= 15 && $("#txt_timer").val() <= 60) {
                    SECS = $("#txt_timer").val() * XTIME;
                    if ($("#btn_Play").find("i").is(".fa-pause")) {

                        FNAME();
                        clearInterval(INTERVAL);
                        clearInterval(INTERVALCD);
                        INTERVAL = setInterval(FNAME, SECS);

                        totalTiempo = $("#txt_timer").val();
                        updateReloj();
                    }
                }
            });

            $("#btn_Play").on("click", function () {
                if ($("#txt_timer").val() >= 15 && $("#txt_timer").val() <= 60) {
                    //ajax bd
                    SECS = $("#txt_timer").val() * XTIME;
                    $(this).toggleClass("btn-success btn-danger");
                    $(this).find("i").toggleClass("fa-play fa-pause");
                    if ($(this).find("i").is(".fa-pause")) {

                        FNAME();
                        totalTiempo = $("#txt_timer").val();

                        clearInterval(INTERVAL);

                        INTERVAL = setInterval(FNAME, SECS);
                        updateReloj();
                    } else {

                        clearInterval(INTERVAL);
                        clearInterval(INTERVALCD);
                    }
                }
                else {

                }
            });


            //$('input[id="chkRevisaDiabetico"]').on("click", function () {
            //    if ($(this).is(":checked")) {
            //        console.log("checked");
            //    } else {
            //        console.log("unchecked");
            //    }
            //});
            checkboxIds.forEach(function (id) {
                $('input[id="' + id + '"]').on("click", function () {
                    if ($(this).is(":checked")) {
                        console.log(id + " checked");
                    } else {
                        console.log(id + " unchecked");
                    }
                });
            });



            ///////////////// pausa al clickear botones
            $("#btn_atendido").click(function () {
                if ($("#prof_tm").val() != "") {
                    console.log("Se dio atendido")
                    Ajax_Update_Atendido();
                    $("#span_est").text("ATENDIDO").css("color", "#28a745");
                    $("#btn_atendido").attr("disabled", "disabled");
                    $("#btn_pendiente").removeAttr("disabled");
                    return;
                }
                Swal.fire({
                    title: 'Error',
                    text: 'Debe seleccionar un profesional para continuar.',
                    icon: 'error',
                    confirmButtonText: 'Aceptar'
                });
            });

            // parte nueva
            function setInputFilter(textbox, inputFilter, message) {
                ["input", "keydown", "keyup", "mousedown", "mouseup", "select", "contextmenu", "drop"].forEach(function (event) {
                    textbox.addEventListener(event, function () {
                        if (inputFilter(this.value)) {
                            this.oldValue = this.value;
                            this.oldSelectionStart = this.selectionStart;
                            this.oldSelectionEnd = this.selectionEnd;
                        } else if (this.hasOwnProperty("oldValue")) {
                            this.value = this.oldValue;
                            this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
                        } else {
                            this.value = "";
                        }
                    });
                });
                textbox.addEventListener("invalid", function (event) {
                    event.preventDefault();
                    message ? alert(message) : null;
                });
            }

            $("#btn_Act_Obs").click(() => Act_Obs());

            $("#lbl_Peso, #lbl_Talla,  #txt_hgt").on("input", (e) => {
                const valor = e.currentTarget.value.split("")
                const ultimoChar = e.currentTarget.value.split("").reverse()[0];
                if (valor[0] == "," || valor[0] == ".") {
                    valor.unshift("0");
                    e.currentTarget.value = valor.join("")
                }
                if (ultimoChar != "," && ultimoChar != "." && ultimoChar) {
                    console.log(ultimoChar);
                    e.currentTarget.value = parseFloat(valor.join("").replace(",", ".")).toLocaleString("es-CL");
                }
            });
            $("#lbl_Peso, #lbl_Talla,  #txt_hgt").focusout((e) => {
                const ultimoChar = e.currentTarget.value.split("").reverse()[0];
                if (ultimoChar == "," || ultimoChar == ".") {
                    e.currentTarget.value = parseFloat(e.currentTarget.value.replace(",", ".")).toLocaleString("es-CL");
                }
            });

            setInputFilter(document.getElementById("lbl_Peso"), function (value) {
                return /^\d*\,?\d*$/.test(value);
            }, "Sólo dígitos y una coma.");
            setInputFilter(document.getElementById("lbl_Talla"), function (value) {
                return /^\d*\,?\d*$/.test(value);
            }, "Sólo dígitos y una coma.");
            setInputFilter(document.getElementById("txt_hgt"), function (value) {
                return /^\d*$/.test(value);
            }, "Sólo dígitos.");



            $("#btn_pendiente").click(function () {
                Ajax_Update_Pendiente();
                $("#span_est").text("PENDIENTE").css("color", "#ffa837");
                $("#btn_pendiente").attr("disabled", "disabled");
                $("#btn_atendido").removeAttr("disabled");
            });
            $("#btn_imprimir").click(function () {
                AJAX_REQ();
            });

            // MODAL DIP
            $("#btn_actualizar_obs").click(function () {
                $("#mdlActualizarObs").modal("show");
            });

            $("#btnGuardarObservaciones").click(function () {
                Ajax_Guardar_Observaciones();
            });

            $("#btn_salir_modalobs").click(function () {
                $("#mdlActualizarObs").modal("hide");
            });

            $("#btnTomaSegundaPTGO").on('click', Ajax_Update_segundaCarga);
            $("#btnSegundaCargaLista").on('click', Ajax_Update_segundaPTGO);

        });

        function updateReloj() {
            document.getElementById('CuentaAtras').innerHTML = totalTiempo;

            if (totalTiempo == 0) {
                if ($("#txt_timer").val() >= 15 && $("#txt_timer").val() <= 60) {
                    totalTiempo = $("#txt_timer").val();
                    updateReloj();
                }
                else {
                    totalTiempo = SECS / 1000;
                    updateReloj();
                }


            }
            else {
                /* Restamos un segundo al tiempo restante */
                totalTiempo -= 1;
                /* Ejecutamos nuevamente la función al pasar 1000 milisegundos (1 segundo) */
                INTERVALCD = setTimeout("updateReloj()", 1000);
            }


        }

        function FNAME() {
            Ajax_DataTable();

            if ($("#txt_timer").val() >= 15 && $("#txt_timer").val() <= 60) {
                SECS = $("#txt_timer").val() * XTIME;
            }
        }

        //Declaración de JSON
        var Mx_Ddl_LugarTM = [{
            "ID_PROCEDENCIA": "",
            "PROC_COD": "",
            "PROC_DESC": "",
            "ID_ESTADO": ""
        }];
        var Mx_Ddl_Estados = [{
            "EST_DESCRIPCION": "",
            "EST_TM_ACTIVA": "",
            "ID_ESTADO": ""
        }];
        var Mx_DL_orden_ate = [{
            "ID_ORDEN": 0,
            "ORD_COD": "asdf",
            "ORD_DESC": "asdf",
            "ID_ESTADO": 0
        }];
        var Mx_Dtt = [{
            "ID_ATENCION": "",
            "ATE_NUM": "",
            "ATE_FECHA": "",
            "ATE_AÑO": "",
            "PROC_DESC": "",
            "ORD_DESC": "",
            "PAC_NOMBRE": "",
            "PAC_APELLIDO": "",
            "PAC_FONO1": "",
            "PAC_MOVIL1": "",
            "SEXO_DESC": "",
            "ID_PACIENTE": "",
            "EST_DESCRIPCION": "",
            "ESPERA": "",
            "USU_NIC": "",
            "ATE_ID_ESTADO_TM": ""
        }];
        //AJAX DDL ESTADOS
        function Llenar_Ddl_Estados() {
            //Debug
            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Llenar_Ddl_Estados",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Ddl_Estados = data.d;


                    Fill_Ddl_Estados();
                },
                "error": data => {
                    //Debug


                }
            });
        }
        //FILL DROPDOWNLIST ESTADO MANTENEDOR
        function Fill_Ddl_Estados() {
            Mx_Ddl_Estados.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_ESTADO
                    }
                ).text(aaa.EST_DESCRIPCION).appendTo("#Ddl_Estados");
            });
        }
        function Llenar_Ddl_LugarTM() {
            //Debug
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Ddl_LugarTM = data.d;

                    Fill_Ddl_LugarTM();
                },
                "error": data => {
                    //Debug
                }
            });
        }
        function Fill_Ddl_LugarTM() {
            var procee = Galletas.getGalleta("USU_ID_PROC");
            //var procee = 0;
            if (procee == 0) {
                $("<option>",
                    {
                        "value": "0"
                    }
                ).text("Todos").appendTo("#Ddl_LugarTM");
                Mx_Ddl_LugarTM.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                });
            }
            else {
                Mx_Ddl_LugarTM.forEach(aaa => {
                    if (aaa.ID_PROCEDENCIA == procee) {
                        $("<option>",
                            {
                                "value": aaa.ID_PROCEDENCIA
                            }
                        ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                    }

                });
            }
            Ajax_Ddl_tm();
        }
        function Ajax_DL_orden_ate() {



            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Llenar_DL_ordenATE",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_orden_ate = json_receiver;
                        Fill_DL_orden_ate();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";


                }
            });
        }
        function Fill_DL_orden_ate() {


            Mx_DL_orden_ate.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_ORDEN
                    }
                ).text(aaa.ORD_DESC).appendTo("#Ddl_Orden_Ate");
            });
        }

        const Ajax_DataTable = async () => {

            var Data_Param = JSON.stringify({
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "ID_ORD": $("#Ddl_Orden_Ate").val(),
                "ID_PROC": $("#Ddl_LugarTM").val(),
                "ID_ESTADO": $("#Ddl_Estados").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Llenar_DataTable",
                "data": Data_Param,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;
                            console.log("Respuesta del servidor:", response); 
                        $("#lblerror").text("");
                        Fill_Dtt();
                    } else {
                        $("#DataTable tbody").empty();
                        $("#lblerror").text("No se Encontraron Pacientes.").css("color", "red");
                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                }
            });
        }

        const Alert_Complete = () => {
            Swal.fire({
                icon: "warning",
                title: "Aviso",
                text: "Tiene Examenes con sitio anatomicos vacio, completelo para poder atender por favor",
            });
        } 

        function Ajax_Update_Atendido() {

            if (is_complete_anato == "0") {
               return Alert_Complete();
            }

            var Data_Param = JSON.stringify({
                "ID_ATE": id_ate,
                "ID_USUARIO": $("#prof_tm").val() == '' ? 0 : $("#prof_tm").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Update_Estado_Atendido_TM",
                "data": Data_Param,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    if (response.d != 0) {
                        Ajax_DataTable();



                    } else {




                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";



                }
            });
        }
        function Ajax_Update_Pendiente() {

            var Data_Param = JSON.stringify({
                "ID_ATE": id_ate,
                "ID_USER": $("#prof_tm").val() == '' ? 0 : $("#prof_tm").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Update_Estado_Pendiente",
                "data": Data_Param,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Ajax_DataTable();



                    } else {




                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";



                }
            });
        }

        function Ajax_Guardar_Observaciones() {
            var Data_Param = JSON.stringify({
                "ID_ATE": id_ate,
                "ATE_NUM": n_ate,
                "DIP_CUP": $("#chkDipCUP").prop("checked") ? 1 : 0,
                "DIP_CVC": $("#chkDipCVC").prop("checked") ? 1 : 0,
                "DIP_PICCLINE": $("#chkDipPICCLINE").prop("checked") ? 1 : 0,
                "DIP_TET": $("#chkDipTET").prop("checked") ? 1 : 0,
                "DIP_TQT": $("#chkDipTQT").prop("checked") ? 1 : 0,
                "DIP_AREpi": $("#chkDipAREpi").prop("checked") ? 1 : 0,
            });

            console.log("Datos enviados:", Data_Param);

            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Guardar_Observaciones",
                "data": Data_Param,
                "contentType": "application/json; charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Swal.fire({
                            title: 'Éxito',
                            text: 'Las observaciones fueron guardadas correctamente.',
                            icon: 'success',
                            confirmButtonText: 'Aceptar'
                        });
                    } else {
                        Swal.fire({
                            title: 'Error',
                            text: 'No se pudieron guardar las observaciones.',
                            icon: 'error',
                            confirmButtonText: 'Intentar de nuevo'
                        });
                    }
                },
                "error": function () {
                    Swal.fire({
                        title: 'Error',
                        text: 'Hubo un problema con el servidor.',
                        icon: 'error',
                        confirmButtonText: 'Cerrar'
                    });
                }
            });
        }

        function Fill_Dtt(limpiarPaciente) {
            // Destruir DataTables antes de vaciar la tabla
            if ($.fn.DataTable.isDataTable("#DataTable")) {
                $('#DataTable').DataTable().destroy();
            }

            $("#DataTable").empty(); // Vaciar completamente la tabla

            // Determinar si hay pacientes con PTGO para agregar columnas adicionales
            const hayPTGO = Mx_Dtt.some(item => item.TIENE_PTGO);

            // Generar el encabezado de la tabla dinámicamente
            var $thead = $("<thead>").append(
                $("<tr>").append(
                    $("<th>").addClass("text-center").text("#"),
                    $("<th>").addClass("text-center").text("N° Atención"),
                    $("<th>").text("Nombre Paciente"),
                    $("<th>").text("Lugar de TdeM"),
                    $("<th>").addClass("text-center").text("Edad"),
                    $("<th>").text("Orden"),
                    $("<th>").text("Usuario"),
                    $("<th>").addClass("text-center").text("PTGO"), // Nueva columna PTGO
                    $("<th>").addClass("text-center").text("Estado"),
                    $("<th>").addClass("text-center").text("Fecha"),
                    $("<th>", { class: "text-center", style: "max-width:110px;" }).text("Hora 75g Glucosa"),
                    $("<th>", { class: "text-center", style: "max-width:110px;" }).text("Hora ideal TdeM 120 min"),
                    $("<th>", { class: "text-center", style: "max-width:110px;" }).text("TdeM real 120 min PTGO"),
                )
            );

            //// Si hay pacientes con PTGO, agregar columnas adicionales
            //if (hayPTGO) {
            //    $thead.find("tr").append(
            //        $("<th>", { class: "text-center", style: "max-width:110px;" }).text("Hr Sobrecarga Mx PTGO"),
            //        $("<th>", { class: "text-center", style: "max-width:110px;" }).text("Hr Sobrecarga 2"),
            //        $("<th>", { class: "text-center", style: "max-width:110px;" }).text("TdeM Sobrecarga Mx PTGO"),

            //    );
            //}

            var $tbody = $("<tbody>");

            var i = 0;
            Mx_Dtt.forEach((aah, index) => {
                var fecha = moment(aah.ATE_FECHA).format("DD-MM-YYYY HH:mm:ss");

                let horaTomarSegundaMuestra = "";
                if (aah.HORA_SEGUNDA_PTGO && aah.TIENE_PTGO) {

                    const parts = aah.HORA_SEGUNDA_PTGO.split(" ");
                    let dateParts = parts[0].split("-");
                    if (dateParts.length === 1) {
                        dateParts = parts[0].split("/");
                    }

                    const newDateStr = `${dateParts[1]}-${dateParts[0]}-${dateParts[2]} ${parts[1]}`;

                    horaTomarSegundaMuestra = new Date(newDateStr);
                    horaTomarSegundaMuestra.setHours(horaTomarSegundaMuestra.getHours() + 2);
                }
                var $row = $("<tr>", {
                    "id": "row-" + aah.ID_ATENCION, // Se asigna un ID único a cada fila
                    "class": "manito",
                    "value": aah.ID_ATENCION
                }).append(
                    $("<td>").css({ "text-align": "center", "font-weight": "bold" }).text(i + 1),
                    $("<td>").css("text-align", "center").text(aah.ATE_NUM),
                    $("<td>").text(aah.PAC_NOMBRE + " " + aah.PAC_APELLIDO),
                    $("<td>").text(aah.PROC_DESC),
                    $("<td>").css("text-align", "center").text(getEdad(aah)),
                    $("<td>").text(aah.ORD_DESC),
                    $("<td>").text(aah.USU_NIC),

                    // Nueva columna PTGO generada dinámicamente
                    $("<td>").css({
                        "text-align": "center",
                        "background": getColorPTGO(aah.TIENE_PTGO)
                    }).text(aah.TIENE_PTGO ? "SI" : "NO"),

                    $("<td>").css({
                        "text-align": "center",
                        "background": getColorEstado(aah.ESPERA)
                    }).text(aah.ESPERA),

                    $("<td>").css("text-align", "center").text(fecha)
                );
                function formatFechaHoraCompleta(fechaStr) {
                    if (!fechaStr) return "-"; // Maneja valores nulos o indefinidos

                    const fecha = new Date(fechaStr);
                    if (isNaN(fecha.getTime())) return "-"; // Si la fecha es inválida, retorna "-"

                    const dia = fecha.getDate().toString().padStart(2, "0");
                    const mes = (fecha.getMonth() + 1).toString().padStart(2, "0");
                    const anio = fecha.getFullYear();
                    const horas = fecha.getHours().toString().padStart(2, "0");
                    const minutos = fecha.getMinutes().toString().padStart(2, "0");
                    const segundos = fecha.getSeconds().toString().padStart(2, "0");

                    return `${dia}-${mes}-${anio} ${horas}:${minutos}:${segundos}`;
                }

                function convertirFechaHoraA24Horas(horaString) {
                    if (!horaString) return "-"; // Maneja valores nulos o indefinidos
                    const parts = horaString.split(" ");
                    let dateParts = parts[0].split("-");
                    if (dateParts.length === 1) {
                        dateParts = parts[0].split("/");
                    }

                    const newDateStr = `${dateParts[1]}-${dateParts[0]}-${dateParts[2]} ${parts[1]}`;
                    const fecha = new Date(newDateStr);

                    if (isNaN(fecha.getTime())) return "-"; // Si la fecha es inválida

                    return formatFechaHoraCompleta(fecha);
                }

                // Si hay PTGO, agregar las nuevas columnas con los valores de cada paciente
                $row.append(
                    $("<td>", { id: "hora-carga-" + aah.ID_ATENCION }).css("text-align", "center").text(
                        aah.TIENE_PTGO
                            ? (aah.HORA_SEGUNDA_PTGO ? convertirFechaHoraA24Horas(aah.HORA_SEGUNDA_PTGO) : "En espera Sobrecarga Carga Lista PTGO")
                            : "-"
                    ),
                    $("<td>", { id: "hora-carga-" + aah.ID_ATENCION }).css("text-align", "center").text(
                        aah.TIENE_PTGO
                            ? (horaTomarSegundaMuestra ? formatFechaHoraCompleta(horaTomarSegundaMuestra) : "-")
                            : "-"
                    ),
                    $("<td>", { id: "hora-2da-mx-" + aah.ID_ATENCION }).css("text-align", "center").text(
                        aah.TIENE_PTGO
                            ? (aah.HORA_TOMA_SEGUNDA_CARGA ? convertirFechaHoraA24Horas(aah.HORA_TOMA_SEGUNDA_CARGA) : "-")
                            : "-"
                    )
                );

                // Manejo de evento click
                $row.on('click', function () {
                    Ajax_Redirect(index);
                });

                // Manejo de evento doble click
                $row.on('dblclick', async function (e) {
                    $("#Div_Tabla_Detalle_Atencion").empty();
                    document.getElementById("btn-atender-muestras").setAttribute("data-id-atencion", aah.ID_ATENCION);
                    document.getElementById("btn-en-proceso-muestras").setAttribute("data-id-atencion", aah.ID_ATENCION);
                    document.getElementById("btn-pendientear-muestras").setAttribute("data-id-atencion", aah.ID_ATENCION);
                    await Ajax_Detalle_Atencion(aah);
                });

                $row.appendTo($tbody); // Agregar la fila al tbody

                i += 1;
            });

            // Agregar el thead y tbody a la tabla
            $("#DataTable").append($thead).append($tbody);

            // Inicializar DataTable después de regenerar la tabla
            $("#DataTable").DataTable({
                "bSort": false,
                "iDisplayLength": 100,
                "info": false,
                "bPaginate": false,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay coincidencias",
                    "info": "Mostrando Página _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay coincidencias",
                    "infoFiltered": "(Se buscó en _MAX_ registros)",
                    "search": "<strong><i class='fa fa-search'></i>Buscar: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });

            $("th").removeClass("sorting_asc");
        }

        /**
         * 🔹 Función para actualizar la hora de PTGO cuando se hace clic en los botones.
         */
        function ActualizarHoraPTGO(id, horaCarga, hora2daMx) {
            let fechaHoraActual = new Date().toLocaleTimeString("es-CL", { hour: "2-digit", minute: "2-digit" });

            // Asignar la nueva hora en la tabla
            $("#hora-carga-" + id).text(horaCarga || fechaHoraActual);
            $("#hora-2da-mx-" + id).text(hora2daMx || fechaHoraActual);
        }

        /**
         * 🔹 Evento para actualizar la hora de PTGO cuando se presiona un botón
         */
        $("#btnTomaSegundaPTGO").on("click", function () {
            let idAtencion = ultimaPosCliqueada; // ID del paciente seleccionado
            if (idAtencion !== -1) {
                ActualizarHoraPTGO(idAtencion);
            }
        });

        // Función para obtener el color de estado PTGO
        function getColorPTGO(tienePTGO) {
            return tienePTGO ? "#9bffb1" : "#ffaaaa"; // Verde si tiene PTGO, rojo si no
        }

        // Función para obtener el color de estado general
        function getColorEstado(estado) {
            switch (estado.toUpperCase()) {
                case "ESPERA":
                    return "#ffdaaa";
                case "PENDIENTE":
                    return "#a9d1fc";
                default:
                    return "#9bffb1";
            }
        }

        // Función para calcular la edad del paciente
        function getEdad(aah) {
            if (!aah || !aah.PAC_FNAC) {
                return "Fecha no disponible";
            }
            if (aah.ATE_AÑO === 0) {
                let fechaNacimientoStr = aah.PAC_FNAC;
                let fechaNacimiento = new Date(fechaNacimientoStr.replace(" ", "T"));
                if (isNaN(fechaNacimiento)) {
                    return "Fecha inválida";
                }

                let fechaActual = new Date();
                let diferenciaMilisegundos = fechaActual - fechaNacimiento;
                let diferenciaDias = Math.floor(diferenciaMilisegundos / (1000 * 60 * 60 * 24));

                if (diferenciaDias < 30) {
                    return diferenciaDias + " Días";
                } else if (diferenciaDias < 365) {
                    return Math.floor(diferenciaDias / 30) + " Meses";
                } else {
                    return Math.floor(diferenciaDias / 365) + " Años";
                }
            } else {
                return aah.ATE_AÑO + " Años";
            }
        }


        function Ajax_Detalle_Atencion(atencion) {
            var Data_Par = JSON.stringify({
                "ID_ATENCION": atencion.ID_ATENCION
            });

            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Detalle_De_Atencion",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {

                    Fill_Detalle_Atencion(response.d, atencion);
                },
                "error": function (response) {

                }
            });
        }

        function Fill_Detalle_Atencion(datos, atencionObjeto) {

            console.log("fill detalle datos: ", datos)
            console.log("fill detalle atencionObjeto: ", atencionObjeto)
            //ATE_OBS_TM            //ATE_OBS_FICHA            //PAC_OBS_PERMA
            //const txtObservTM = document.getElementById('txt-obs-toma-muestra');
            //const txtObservAtencion = document.getElementById('txt-obs-toma-atencion');
            //txtObservAtencion.value = atencionObjeto?.ATE_OBS_FICHA || "";
            //txtObservTM.value = atencionObjeto?.OBS || "";
            //txtObservTM.value = atencionObjeto?.ATE_OBS_TM || "";
            //txtObservTM.setAttribute('data-id-atencion', atencionObjeto?.ID_ATENCION || 0);

            $("#Div_Tabla_Detalle_Atencion").empty()
                .append($("<table>", { id: "DataTable_Detalle_Atencion", class: "display table table-iris" }).append($("<thead>"), $("<tbody>")));

            $("#DataTable_Detalle_Atencion thead").append($("<tr>").append(
                $("<th>", { class: "textoReducido" }).text("#"),
                $("<th>", { class: "textoReducido" }).text("Etiqueta"),
                $("<th>", { class: "textoReducido" }).text("Examen"),
                $("<th>", { class: "textoReducido" }).text("Sitio Anatómico"),
                $("<th>", { class: "textoReducido" }).text("Color"),
                $("<th>", { class: "textoReducido" }).text("Estado"),
                $("<th>", { class: "textoReducido" }).text("Fecha Hora"),
                $("<th>", { class: "textoReducido" }).text("Usuario TdeM"),
                $("<th>", { class: "textoReducido", style: "text-align:center" }).text("Marcar")
            ));
            const asignaEspera = estado => {
                if (estado == 7) {
                    return "background-color:#ffdaaa;"; // Color para estado 7
                } else if (estado == 4) {
                    return "background-color:#a9d1fc;"; // Color para estado 4
                } else if (estado == 19) {
                    return "background-color:#c877ff;"; // Color para estado 19 (puedes cambiar este color según prefieras)
                } else {
                    return "background-color:#9bffb1;"; // Color por defecto
                }
            };

            const checkAtender = examen => {
                const perfil = examen.ID_PER;
                const cb = examen.CB_DESC;
                const cf = examen.ID_CODIGO_FONASA;
                return `<input class="form-check-input" type="checkbox" value="" name="etiquetas-atencion" style="margin:0px;width:25px;height:25px;"
             data-perfil="${perfil}" data-cb="${cb}"  data-cf="${cf}" checked>`
            }

            datos.forEach((item, i) => {
                $("#DataTable_Detalle_Atencion tbody").append(
                    $("<tr>", {
                        "class": "manito blockcolor",
                        "data-perfil": item.ID_PER,
                        "data-cb": item.CB_DESC,
                        "data-cf": item.ID_CODIGO_FONASA
                    }).append(
                        $("<td>", { "align": "left", "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left", "class": "textoReducido" }).text(`[${item.CB_DESC}] ${item.T_MUESTRA_DESC}`),
                        $("<td>", { "align": "left", "class": "textoReducido" }).text(item.CF_DESC),
                        $("<td>", { "align": "left", "class": "textoReducido" }).append(function () {

 
                           return $("<input>", {
                                type: "text",
                                name: `txtSitioAnato${i}`,
                                class: "inputGuardar",
                               "data-cf-ate": item.ID_CODIGO_FONASA,
                               "data-ate": item.ID_ATE_RES,
                               "disabled": item.IS_ANATO == 0 || item.ATE_EST_TM == 8 ? true : false,
                                "value": item.IS_ANATO == 1 ? item.ATE_RESULTADO : ""
                            })
                        }
                        ),
                        $("<td>", { "align": "left", "class": "textoReducido" }).text(`[${item.GMUE_DESC.toUpperCase()}]`),
                        $("<td>", { "class": "textoReducido", style: asignaEspera(item.ATE_EST_TM) + "text-align:center" }).text(item.EST_DESCRIPCION),
                        $("<td>", { "align": "left", "class": "textoReducido" }).text(item.ATE_FEC_TM),
                        $("<td>", { "align": "left", "class": "textoReducido" }).text(item.USU_FULL_NAME),
                        $("<td>", { "align": "center", "class": "textoReducido" }).html(checkAtender(item))
                    )
                );
            });

            // Mostrar tooltip en focus
            $(document).on("focus", ".inputGuardar", function () {
                let input = $(this);
                input.attr("title", "Presione Enter para guardar").tooltip({
                    trigger: "manual",
                    placement: "top"
                }).tooltip("show");

                setTimeout(() => {
                    input.tooltip("hide");
                }, 2000);
            });

            // Capturar Enter y mostrar SweetAlert
            $(document).on("keydown", ".inputGuardar", function (e) {
                if (e.key === "Enter") {
                    e.preventDefault(); // Evita que el formulario se envíe automáticamente

                    let inputName = $(this).attr("name");
                    let inputCF = $(this).attr("data-cf-ate");
                    let inputAte = $(this).attr("data-ate");
                    let inputValue = $(this).val().trim();

                    if (inputValue == "") {
                        return Swal.fire({
                            title: "Aviso",
                            text: `No puede dejar vacio el sitio anatómico`,
                            icon: "warning",
                            showCancelButton: false,
                            confirmButtonText: "Ok"
                        });
                    }

                    Swal.fire({
                        title: "¿Guardar?",
                        text: `¿Desea guardar el Sitio anatómico "${inputValue}"?`,
                        icon: "question",
                        showCancelButton: true,
                        confirmButtonText: "Sí, guardar",
                        cancelButtonText: "Cancelar"
                    }).then((result) => {
                        if (result.isConfirmed) {
                            //Swal.fire("Guardado", "El valor ha sido guardado exitosamente.", "success");
                            // Aquí podrías agregar la lógica para enviar el valor al servidor
                            Update_Anatomico(inputValue, inputAte, inputCF);
                        }
                    });
                }
            });

            //actualizarEstadoAtencion(datos);

            if (!Array.from(document.getElementById("modal_detalle_atencion").classList).includes("show")) {
                $("#modal_detalle_atencion").modal("show");
            }


        }

        const Update_Anatomico = (ate_res, id_atencion, id_cf) => {

            var Data_Param = JSON.stringify({
                "ID_ATE_RES": id_atencion,
                "SITIO_ANATO": ate_res,
                "ID_CODIGO_FONASA": id_cf
            });

            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Update_Anato",
                "data": Data_Param,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": res => {
                    if (res.d) {

                        Swal.fire("Guardado", "El valor ha sido guardado exitosamente.", "success");

                        return;
                    }
                }
            });
        }

        const Ajax_Update_segundaPTGO = () => {
            const atencion = Mx_Dtt.find(item => item.ID_ATENCION == id_ate);
            if (!atencion) {
                return
            }
            var Data_Param = JSON.stringify({
                "idAtencion": id_ate
            });
            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Update_Segunda_PTGO",
                "data": Data_Param,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": res => {
                    if (res.d) {
                        $("#btn_Play").click();
                        Ajax_DataTable()

                        Swal.fire({ icon: "success", title: "Éxito", text: "Hora de toma de muestra de Sobrecarga PTGO actualizada." })
                        $("#btnSegundaCargaLista").prop("disabled", true);
                        $("#btnTomaSegundaPTGO").prop("disabled", true);
                        return;
                    }
                }
            });
        }
        const Ajax_Update_segundaCarga = () => {
            const atencion = Mx_Dtt.find(item => item.ID_ATENCION == id_ate);
            if (!atencion) {
                return
            }
            var Data_Param = JSON.stringify({
                "idAtencion": id_ate
            });
            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Update_Segunda_Carga",
                "data": Data_Param,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": res => {
                    if (res.d) {
                        $("#btn_Play").click();
                        Ajax_DataTable();

                        Swal.fire({ icon: "success", title: "Éxito", text: "Hora toma segunda carga actualizada." })
                        $("#btnSegundaCargaLista").prop("disabled", true);
                        $("#btnTomaSegundaPTGO").prop("disabled", true);
                        return;
                    }
                }
            });
        }

        function actualizarEstadoAtencion(datos) {
            let todosAtendidos = true;
            let algunPendiente = false;
            let algunEnProceso = false;

            datos.forEach(item => {
                console.log(`ITEM: ${item.EST_DESCRIPCION}`)
                if (item.EST_DESCRIPCION !== 'ATENDIDO') {
                    todosAtendidos = false;
                }
                if (item.EST_DESCRIPCION === 'PENDIENTE') {
                    algunPendiente = true;
                }
                if (item.EST_DESCRIPCION === 'EN PROCESO') {
                    algunEnProceso = true;
                }
            });

            if (algunPendiente) {
                Ajax_Update_Pendiente();
            } else if (todosAtendidos) {
                Ajax_Update_Atendido();
            } else if (algunEnProceso) {
                //Ajax_Update_Proceso();
            }
        }


        function Update_Estado_Examen(idAtencion, idEstado, idUsuario, perfiles, codigosBarra, codigosFonasa) {
            console.log("Dentro de la llamada - Usuario:", idUsuario);
            console.log("Estado enviado:", idEstado);

            if (!idUsuario || isNaN(idUsuario)) {
                console.error("No se seleccionó un usuario de toma de muestras.");
                return;
            }

            var Data_Param = JSON.stringify({
                ID_ATENCION: idAtencion,
                ID_ESTADO: idEstado,
                ID_USUARIO: idUsuario,
                perfiles,
                codigosBarra,
            });

            $.ajax({
                type: "POST",
                url: "Adm_TM.aspx/Update_Estado_Examen",
                data: Data_Param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log("Respuesta del servidor:", response);

                    // Combinación de listas
                    const list_unida = perfiles.map((perfil, index) => ({
                        perfil,
                        cb: codigosBarra[index],
                        cf: codigosFonasa[index]
                    }));

                    console.log("Lista combinada:", list_unida);

                    // Selecciona las filas de la tabla con el ID 'DataTable_Detalle_Atencion'
                    const filas = document.querySelectorAll('#DataTable_Detalle_Atencion tbody tr');

                    console.log(`Filas encontradas en la tabla: ${filas.length}`);

                    filas.forEach(fila => {
                        const perfil = parseInt(fila.getAttribute('data-perfil'));
                        const cb = fila.getAttribute('data-cb');
                        const cf = fila.getAttribute('data-cf');

                        console.log("Datos de la fila:", perfil, cb, cf);

                        // Busca coincidencias en la lista combinada
                        const itemEncontrado = list_unida.find(item =>
                            item.perfil === perfil && item.cb === cb && item.cf === cf
                        );

                        if (itemEncontrado) {
                            const estadoCell = fila.children[5]; // El 5º <td> es el índice 4
                            if (idEstado == 8) {
                                console.log("Cambiando estado a ATENDIDO");
                                estadoCell.textContent = "ATENDIDO";
                                estadoCell.style.backgroundColor = "#9bffb1";
                            } else if (idEstado == 4) {
                                console.log("Cambiando estado a PENDIENTE");
                                estadoCell.textContent = "PENDIENTE";
                                estadoCell.style.backgroundColor = "#a9d1fc"; // Color azul claro
                            }
                        }
                    });

                    // Revisar lista de estados en la tabla
                    const listaEstados = [];
                    document.querySelectorAll('#DataTable_Detalle_Atencion tbody tr').forEach(item => {
                        listaEstados.push(item.children[4].textContent.trim());
                    });

                    console.log("Lista de estados en la tabla después de actualizar:", listaEstados);

                    const todosAtendidos = listaEstados.every(estado => estado === "ATENDIDO");
                    const todosPendientes = listaEstados.every(estado => estado === "PENDIENTE");

                    if (todosAtendidos) {
                        console.log("Todos los estados son ATENDIDO, ejecutando Ajax_Update_Atendido()");
                        Ajax_Update_Atendido();
                    } else if (todosPendientes) {
                        console.log("Todos los estados son PENDIENTE, ejecutando Ajax_Update_Pendiente()");
                        Ajax_Update_Pendiente();
                    }

                },
                error: function (response) {
                    console.error("Error en la solicitud AJAX:", response);
                }
            });
        }
        let ultimaPosCliqueada = -1
        function Ajax_Redirect(pos = ultimaPosCliqueada) {
            const clicDistinto = pos != ultimaPosCliqueada;

            ultimaPosCliqueada = pos;
            if (ultimaPosCliqueada == -1 || pos > Mx_Dtt.length - 1) {
                ultimaPosCliqueada = -1
                id_ate = 0;
                n_ate = 0;
                $(`#obs_ate, #obdser, #obdser_tm, #txtTalla, #txtPeso, #txtGramaje, #txtHGT, #txtUltimaDosisDroga, #txtGlicemiaBasal`).val("");
                $(`#lblnate, #lblnom, #lbledad, #lblsexo, #lblfono, #lblcelu, #span_est`).text("");

                $("#span_est").css("color", "#FFFFFF");
                $("#btn_pendiente, #btn_atendido, #btn_imprimir").attr("disabled", "asdasdasd");

                return;
            }
            $("#btnTomaSegundaPTGO, #btnSegundaCargaLista").attr("disabled", true);


            const localDate = moment(Mx_Dtt[pos].FECHA_HORA_ULTIMA_DOSIS, "DD-MM-YYYY HH:mm:ss").format("YYYY-MM-DD HH:mm:ss.SSS");

            console.log("DATO IMPORTANTE: ", Mx_Dtt[pos])
            Ajax_Busca_Observaciones(Mx_Dtt[pos].ID_ATENCION);
            id_ate = Mx_Dtt[pos].ID_ATENCION;
            n_ate = Mx_Dtt[pos].ATE_NUM;

            is_complete_anato = Mx_Dtt[pos].IS_COMPLETE_ANATO;

            $("#lblnate").text(Mx_Dtt[pos].ATE_NUM);
            $("#lblnom").text(Mx_Dtt[pos].PAC_NOMBRE + " " + Mx_Dtt[pos].PAC_APELLIDO);
            $("#lbledad").text(Mx_Dtt[pos].ATE_AÑO + " AÑOS");
            $("#lblsexo").text(Mx_Dtt[pos].SEXO_DESC.toUpperCase());
            $("#lblfono").text(Mx_Dtt[pos].PAC_FONO1);
            $("#lblcelu").text(Mx_Dtt[pos].PAC_MOVIL1);

            $("#lblnomSoc").text(Mx_Dtt[pos]?.NOM_SOC);
            $("#lblGenero").text(Mx_Dtt[pos]?.GENERO_DESC);
            $("#lblEtnia").text(Mx_Dtt[pos]?.ETNIA_DESC);

            $("#lblnate2").text(Mx_Dtt[pos].ATE_NUM);
            $("#lblnom2").text(Mx_Dtt[pos].PAC_NOMBRE + " " + Mx_Dtt[pos].PAC_APELLIDO);
            $("#lbledad2").text(Mx_Dtt[pos].ATE_AÑO + " AÑOS");
            $("#lblsexo2").text(Mx_Dtt[pos].SEXO_DESC.toUpperCase());
            $("#lblfono2").text(Mx_Dtt[pos].PAC_FONO1);
            $("#lblcelu2").text(Mx_Dtt[pos].PAC_MOVIL1);

            // PARTE DE PESO, TALLA, HGT, HORA ULTIMA DOSIS
            $("#lbl_Peso").val(Mx_Dtt[pos].PESO);
            $("#lbl_Talla").val(Mx_Dtt[pos].TALLA);
            $("#txt_hgt").val(Mx_Dtt[pos].HGT);
            //$("#txtFechaUltimaDosis").val(Mx_Dtt[pos].FECHA_HORA_ULTIMA_DOSIS);
            //console.log("FECHA HORA ULTIMA DOSIS", Mx_Dtt[pos].FECHA_HORA_ULTIMA_DOSIS, "FECHA FORMATEADA: ", localDate)
            //$("#txtFechaUltimaDosis").val(localDate);
            $("#txt-obs-toma-muestra").val(Mx_Dtt[pos].ATE_OBS_TM);
            $("#lbl_obs_per").val(Mx_Dtt[pos].PAC_OBS_PERMA);
            $("#txt-obs-toma-atencion").val(Mx_Dtt[pos].ATE_OBS_FICHA);

            $("#lbl_Diuresis").val(Mx_Dtt[pos].DIURESIS);
            $("#txtGramaje").val(Mx_Dtt[pos].GRAMAJE);
            $("#txt-zona-toma-muestra").val(Mx_Dtt[pos].ZONA_TM);
            // Obtener las fechas
            let fechaOriginal = Mx_Dtt[pos].PAC_FNAC;
            let fechaActual = Mx_Dtt[pos].FECHA_ACTUAL;

            let fechaDosisOriginal = localDate;

            // Mostrar en consola
            console.log(`Fecha original: ${fechaOriginal}`);
            console.log(`Fecha actual: ${fechaActual}`);
            console.log(`fechaDosisOriginal: ${fechaDosisOriginal}`);

            // Convertir fechas a objetos Date
            let date1 = new Date(fechaOriginal.replace(" ", "T"));
            let date2 = new Date(fechaActual.replace(" ", "T"));
            let date3 = new Date(fechaDosisOriginal.replace(" ", "T"));


            // Validar si las fechas son válidas
            //if (isNaN(date1) || isNaN(date2)) {
            //    console.error("Una de las fechas no es válida.");
            //} else {
            //    // Referenciar el input
            //    let inputFechaNacimiento = document.getElementById("txt-fecha-hora-nacimiento");


            //    // Mostrar fecha y hora
            //    inputFechaNacimiento.type = "datetime-local";
            //    let fechaConHora = fechaOriginal.split(" ")[0] + "T" + fechaOriginal.split(" ")[1].slice(0, 5); // Formato: YYYY-MM-DDTHH:mm
            //    inputFechaNacimiento.value = fechaConHora;

            //}
            // Validar si las fechas son válidas
            if (isNaN(date1) && isNaN(date2)) {
                console.error("Una de las fechas no es válida.");

                document.getElementById("txt-fecha-dosis").value = ""; // Solo fecha
                document.getElementById("txt-hora-dosis").value = ""; // Solo hora
            } else {
                // Extraer la fecha y la hora por separado
                let fecha = fechaOriginal.split(" ")[0]; // Obtiene solo la fecha (YYYY-MM-DD)
                let hora = fechaOriginal.split(" ")[1].slice(0, 5); // Obtiene solo la hora (HH:mm)

                console.log(fecha);
                console.log(hora);
                // Mostrar la fecha y la hora en los respectivos inputs
                document.getElementById("txt-fecha-nacimiento").value = fecha; // Solo fecha
                document.getElementById("txt-hora-nacimiento").value = hora; // Solo hora

                //Fecha ultima dosis
                let fechaDosis = fechaDosisOriginal.split(" ")[0]; // Obtiene solo la fecha (YYYY-MM-DD)
                let horaDosis = fechaDosisOriginal.split(" ")[1].slice(0, 5); // Obtiene solo la hora (HH:mm)

                document.getElementById("txt-fecha-dosis").value = fechaDosis; // Solo fecha
                document.getElementById("txt-hora-dosis").value = horaDosis; // Solo hora
            }

            id_pac_glob = Mx_Dtt[pos].ID_PACIENTE;


            if (Mx_Dtt[pos].ESPERA == "ESPERA") {
                $("#span_est").css("color", "#ffdaaa");
                $("#btn_atendido").prop("disabled", false);
                $("#btn_pendiente").prop("disabled", false);
                $("#btn_actualizar_obs").prop("disabled", false);
                $("#btnTomaSegundaPTGO, #btnSegundaCargaLista").prop("disabled", !Mx_Dtt[pos].TIENE_PTGO);
            }
            else if (Mx_Dtt[pos].ESPERA == "ATENDIDO") {
                $("#span_est").css("color", "#9bffb1");
                $("#btn_pendiente").prop("disabled", false);
                $("#btn_atendido").prop("disabled", true);
                $("#btn_actualizar_obs").prop("disabled", false);
                $("#btnTomaSegundaPTGO, #btnSegundaCargaLista").prop("disabled", !Mx_Dtt[pos].TIENE_PTGO);
            }
            else {
                $("#span_est").css("color", "#a9d1fc");
                $("#btn_atendido").prop("disabled", false);
                $("#btn_pendiente").prop("disabled", true);
                $("#btn_actualizar_obs").prop("disabled", false);
                $("#btnTomaSegundaPTGO, #btnSegundaCargaLista").prop("disabled", true);
            }

            console.log(" ya tien cargar", Mx_Dtt[pos].HORA_SEGUNDA_PTGO)
            console.log(" ya tien cargar", Mx_Dtt[pos].HORA_TOMA_SEGUNDA_CARGA)

            if (Mx_Dtt[pos].TIENE_PTGO && Mx_Dtt[pos].HORA_SEGUNDA_PTGO && !Mx_Dtt[pos].HORA_TOMA_SEGUNDA_CARGA) {
                console.log("1")
                $("#btnSegundaCargaLista").prop("disabled", true);
            } else if (Mx_Dtt[pos].HORA_SEGUNDA_PTGO && !Mx_Dtt[pos].HORA_TOMA_SEGUNDA_CARGA) {
                console.log("2")
                $("#btnSegundaCargaLista").prop("disabled", true);
                $("#btnTomaSegundaPTGO").prop("disabled", false);
            } else if (Mx_Dtt[pos].HORA_SEGUNDA_PTGO && Mx_Dtt[pos].HORA_TOMA_SEGUNDA_CARGA) {
                console.log("3")
                $("#btnSegundaCargaLista").prop("disabled", true);
                $("#btnTomaSegundaPTGO").prop("disabled", true);
            } else {
                console.log("4")
            }

            $("#txtGlicemiaBasal").val(Mx_Dtt[pos].GLICEMIA_BASAL);
            // si es un clic en la tabla distinto al último que se cliqueó 
            if (clicDistinto) {

                $("#obs_ate").val(Mx_Dtt[pos].ATE_OBS_FICHA);
                $("#obdser").val(Mx_Dtt[pos].PAC_OBS_PERMA);
                $("#obdser_tm").val(Mx_Dtt[pos].ATE_OBS_TM);

                $("#txtTalla").val(Mx_Dtt[pos].TALLA_TM);
                $("#txtPeso").val(Mx_Dtt[pos].PESO_TM);
                $("#txtGramaje").val(Mx_Dtt[pos].GRAMAJE_TM);

                $("#txtHGT").val(Mx_Dtt[pos].HGT);
                const dateString = Mx_Dtt[pos].ULTIMA_DOSIS_DROGA?.replaceAll("/", "-");
                if (dateString != null) {
                    var parts = dateString.split(/[- :]/);
                    var year = parseInt(parts[2], 10);
                    var month = parseInt(parts[1], 10) - 1;
                    var day = parseInt(parts[0], 10);
                    var hours = parseInt(parts[3], 10);
                    var minutes = parseInt(parts[4], 10);
                    var seconds = parseInt(parts[5], 10);

                    var dateTime = new Date(year, month, day, hours, minutes, seconds);
                    console.log(dateTime);
                    var dateTimeLocalString = dateTime.toLocaleString("en-CA", { timeZone: "America/Santiago", hour12: false }).replace(", ", "T");
                    console.log(dateTimeLocalString);
                    document.getElementById("txtUltimaDosisDroga").value = dateTimeLocalString;
                } else {
                    $("#txtUltimaDosisDroga").val("");
                }

            }
        }

        // PARTE NUEVA

        function Act_Obs() {

            //let fechaUltimaDosis = $("#txtFechaUltimaDosis").val();

            let fechaUltimaDosis = `${$("#txt-fecha-dosis").val()}T${$("#txt-hora-dosis").val()}`;

            //let fechaUltimaDosis = $("#txt-fecha-dosis").val();

            //let horaUltimaDosis = $("#txt-hora-dosis").val();

            if (('T' + $("#txt-hora-dosis").val()) == fechaUltimaDosis) {
                fechaUltimaDosis = 'T';
            }

            //console.log("fechaUltimaDosis", fechaUltimaDosis);
            //console.log("fechaUltimaDosis === '0'", fechaUltimaDosis === '0');
            //console.log("!fechaUltimaDosis", !fechaUltimaDosis);
            //Si la fecha es 0 o no está definida, establece un valor predeterminado
            //if (fechaUltimaDosis === 'T' || !fechaUltimaDosis) {
            //    fechaUltimaDosis = moment('1900-01-01T00:00:00').format();
            //    fechaUltimaDosis = moment(fechaUltimaDosis).format('YYYY-MM-DDTHH:mm:ss');
            //} else {
            //    // Asegura que la fecha esté en formato ISO 8601, sin milisegundos
            //    //fechaUltimaDosis = moment(fechaUltimaDosis).utc().format('YYYY-MM-DDTHH:mm:ss');
            //    fechaUltimaDosis = moment(fechaUltimaDosis).format('YYYY-MM-DDTHH:mm:ss');
            //}

            ////fechaUltimaDosis = moment(fechaUltimaDosis).format('YYYY-MM-DDTHH:mm:ss');
            console.log("fechaUltimaDosis", fechaUltimaDosis);

            console.log("id_pac_glob", id_pac_glob);
            let Data_Par = JSON.stringify({
                "ATE_NUM": $("#lblnate").text(),
                "PESO": $("#lbl_Peso").val(),
                "TALLA": $("#lbl_Talla").val(),
                "HGT": $("#txt_hgt").val(),
                "FECHA_HORA_ULTIMA_DOSIS": fechaUltimaDosis,
                "OBSERVACION_TM": $("#txt-obs-toma-muestra").val(),
                "ATE_OBS_FICHA": $("#txt-obs-toma-atencion").val(),
                "OBSERVACION_PER": $("#lbl_obs_per").val(),
                "DIURESIS": $("#lbl_Diuresis").val(),
                "GRAMAJE": $("#txtGramaje").val(),
                "ID_PAC": id_pac_glob,
                "ZONA_TM": $("#txt-zona-toma-muestra").val()
                //"CONCENTRACION_MEDICAMENTO": $("#txtConcentracionMedicamento").val(),
                //"PERSONA": $("#lbl_Venopuncion").val(),
            });
            console.log("Dato enviado", Data_Par);
            console.log("id_pac_glob", id_pac_glob);
            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Actualiza_Obs_Normal",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {

                    Swal.fire({
                        title: "Valores Actualizados",
                        text: "Valores nuevos ingresados",
                        icon: "success"
                    });
                    Hide_Modal();
                    Ajax_DataTable();

                },
                "error": function (response) {

                    Hide_Modal();
                }
            });
        }

        function Ajax_Busca_Observaciones(id_ate) {
            var Data_Param = JSON.stringify({
                "ID_ATE": id_ate
            });
            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Busca_Observaciones",
                "data": Data_Param,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        //console.log("DATOS RECIVIDOS DE LOS CHECKS: ", json_receiver[0].CUP)
                        // Agrega Cheks a datos en pantalla
                        $("#chkDipCUP2").prop("checked", json_receiver[0].CUP == 1);
                        $("#chkDipCVC2").prop("checked", json_receiver[0].CVC == 1);
                        $("#chkDipPICCLINE2").prop("checked", json_receiver[0].PICCLINE == 1);
                        $("#chkDipTET2").prop("checked", json_receiver[0].TET == 1);
                        $("#chkDipTQT2").prop("checked", json_receiver[0].TQT == 1);
                        $("#chkDipAREpi2").prop("checked", json_receiver[0].AREpi == 1);

                        // Agrega Checks a modal

                        $("#chkDipCUP").prop("checked", json_receiver[0].CUP == 1);
                        $("#chkDipCVC").prop("checked", json_receiver[0].CVC == 1);
                        $("#chkDipPICCLINE").prop("checked", json_receiver[0].PICCLINE == 1);
                        $("#chkDipTET").prop("checked", json_receiver[0].TET == 1);
                        $("#chkDipTQT").prop("checked", json_receiver[0].TQT == 1);
                        $("#chkDipAREpi").prop("checked", json_receiver[0].AREpi == 1);
                    } else {
                        //console.log("No se encontraron observaciones")
                        // Dejar los checks en false
                        $("#chkDipCUP2").prop("checked", false);
                        $("#chkDipCVC2").prop("checked", false);
                        $("#chkDipPICCLINE2").prop("checked", false);
                        $("#chkDipTET2").prop("checked", false);
                        $("#chkDipTQT2").prop("checked", false);
                        $("#chkDipAREpi2").prop("checked", false);

                        // Dejar los checks del modal en false

                        $("#chkDipCUP").prop("checked", false);
                        $("#chkDipCVC").prop("checked", false);
                        $("#chkDipPICCLINE").prop("checked", false);
                        $("#chkDipTET").prop("checked", false);
                        $("#chkDipTQT").prop("checked", false);
                        $("#chkDipAREpi").prop("checked", false);

                    }
                },
                "error": function (response) {
                    var str_Error = "Error interno del Servidor";
                }
            });
        }



        function AJAX_REQ() {
            var dataParam = [
                id_ate
            ];
            function AR_Success() {


                var str_Error = "La impresión se ha completado exitosamente."

                $("#mError_AAH h4").text("Impresión Correcta");
                $("#mError_AAH button").attr("class", "btn btn-success");
                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();
            }
            function AR_Error() {


                var str_Error = "No se a detectado ninguna interface de impresión abierta. Abra IRISLAB_PRINT o " // o de lo contrario descargelo AQUI
                str_Error += "descargue la aplicación aquí <a href='" + window.origin + "/Iris_Print/Setup.exe'>DESCARGAR</a>";

                $("#mError_AAH h4").text("Error");
                $("#mError_AAH button").attr("class", "btn btn-danger");
                $("#mError_AAH p").html(str_Error);
                $("#mError_AAH").modal();
            }


            var AR_Eti = new Iris_Print(dataParam, AR_Success, AR_Error);
            AR_Eti.imp_Etiquetas();
        };


        Mx_Ddl_tm = [{
            "ID_USUARIO": 0,
            "USU_FULL_NAME": "",
            "USU_NIC": ""
        }];

        function Ajax_Ddl_tm() {
            var Data_procedencia = JSON.stringify({
                "ID_PROCEDENCIA": $("#Ddl_LugarTM").val()
            });
            //console.log(Data_procedencia)
            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA",
                "data": Data_procedencia,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_tm = json_receiver;
                        Fill_Ddl_tm();
                    } else {
                    }
                },
                "error": function (response) {
                    var str_Error = "Error interno del Servidor";
                }
            });
        }

        function Fill_Ddl_tm() {
            $("#prof_tm").empty(); // Vaciar el menú desplegable

            // Añadir la opción predeterminada "Seleccionar"
            $("<option>", {
                "value": ""
            }).text("Seleccionar").appendTo("#prof_tm");
            for (y = 0; y < Mx_Ddl_tm.length; ++y) {
                //console.log("ID_USUARIO: ", Mx_Ddl_tm[y].ID_USUARIO);
                //console.log("USU_FULL_NAME: ", Mx_Ddl_tm[y].USU_FULL_NAME);
                $("<option>", {
                    "value": Mx_Ddl_tm[y].ID_USUARIO
                }).text(Mx_Ddl_tm[y].USU_FULL_NAME).appendTo("#prof_tm");
            }

            // Inicializar Select2
            $("#prof_tm").select2({
                placeholder: "Seleccionar",
                allowClear: true,
                width: 'resolve'  // esto ajusta el ancho del select2 al contenedor padre
            });
        }


    </script>
    <style>
        .readonly-checkbox {
            cursor: not-allowed;
        }

        .redtx {
            color: red;
        }

        #DataTable {
            border-collapse: collapse;
        }

        #lblnom, #lbledad, #lblsexo, #lblfono, #lblcelu, #lblnate {
            color: #015457;
        }


        #lblnom2, #lbledad2, #lblsexo2, #lblfono2, #lblcelu2 {
            color: #015457;
        }

        #DataTable thead {
            background-color: #155fa0;
            color: white;
        }

        .grid-antecedentes {
            align-self: center;
            display: grid;
            grid-template-columns: repeat(2, minmax(150px, 1fr));
            grid-template-rows: minmax(70px, auto) minmax(140px, auto) minmax(70px, auto);
            column-gap: 1rem;
            align-items: center;
            grid-auto-flow: dense;
            max-width: 80vw;
            min-width: 50vw;
        }

        .modal-xl {
            max-width: 70%;
        }

        #inp_social {
            background-color: #00738e;
            border-radius: 10px;
            color: white;
        }

        .form-check-input-small {
            width: 15px;
            height: 15px;
            margin-right: 5px;
        }

        .form-check-label-small {
            display: inline-block;
            margin-left: 5px;
        }

        #btn_atendido:disabled {
            pointer-events: none;
        }
        #inp_social {
            background-color: #00738e;
            border-radius: 10px;
            color: white;
        }

        /* Cambia la altura del input de select2 */
        .select2-container .select2-selection--single {
            height: 40px; /* Ajusta la altura según tus necesidades */
        }

            .select2-container .select2-selection--single .select2-selection__rendered {
                line-height: 36px; /* Ajusta el alineamiento del texto dentro del select */
            }

        /* Cambia la altura del dropdown desplegable */
        .select2-container--default .select2-results--single {
            max-height: 200px; /* Ajusta la altura máxima del dropdown */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <!-- Modales -->
    <!-- Modal DETALLE -->
    <div id="modal_detalle_atencion" class="modal fade" role="dialog">
        <div class="modal-dialog" style="min-width: 1000px;">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" style="text-align: center;" id="">Listado de Exámenes</h4>
                </div>
                <div class="modal-body" style="display: grid; gap: 1rem;">
                    <div style="display: flex; justify-content: space-between;">
                        <button type="button" id="btnMarcarCheckboxes" class="btn btn-dark m-1"><i class="fa fa-check" aria-hidden="true"></i>Marcar/Desmarcar</button>
                    </div>

                    <div class="col">
                        <div class="row">
                            <div class="col-lg">
                                <div id="Div_Tabla_Detalle_Atencion" style="overflow: auto;"></div>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" id="btn-atender-muestras"><i class="fa fa-fw fa-check mr-2"></i>Atendido</button>
                    <button type="button" class="btn btn-warning" id="btn-en-proceso-muestras" hidden=""><i class="fa fa-fw fa-clock-o mr-2"></i>En Proceso</button>
                    <button type="button" class="btn btn-warning" id="btn-pendientear-muestras"><i class="fa fa-fw fa-clock-o mr-2"></i>Pendiente</button>

                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-remove mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- INICIO: MODAL Actualizar datos-->
    <div class="modal fade" id="mdlActualizarObs" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <h4 class="text-center">Datos del Paciente Seleccionado</h4>
                    <div class="row">
                        <div class="col-lg" id="n_atencion2">
                            <label for="lblnate2">N° Atención: <b><span id="lblnate2"></span></b></label>
                        </div>
                        <div class="col-lg-4">
                            <div class="row">
                                <label for="lblnom2">Nombre: <b><span id="lblnom2"></span></b></label>
                            </div>
                        </div>
                        <div class="col-lg">
                            <label for="lbledad2">Edad: <b><span id="lbledad2"></span></b></label>
                        </div>
                        <div class="col-lg">
                            <label for="lblsexo2">Sexo: <b><span id="lblsexo2"></span></b></label>
                        </div>
                        <div class="col-lg">
                            <label for="lblcelu2">Fono 1: <b><span id="lblcelu2"></span></b></label>
                        </div>
                        <div class="col-lg">
                            <label for="lblfono2">Fono 2: <b><span id="lblfono2"></span></b></label>
                        </div>
                    </div>
                    <hr />
                    <div class="container">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btn_salir_modalobs" class="btn btn-secondary">Salir</button>
                </div>
            </div>
        </div>
    </div>

    <!-- FIN: MODAL Actualizar datos-->
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


    <div class="card border-bar">
        <div class="card-header bg-bar">
            <h3 style="text-align: center; padding: 5px;">Administración de Toma de Muestra</h3>
        </div>
        <div class="row" style="margin-top: 15px; margin-left: 0px !important; margin-right: 0px !important;">
            <div class="col-lg-10">
                <div class="row">
                    <div class="col-lg">
                        <label for="fecha">Desde:</label>
                        <div class='input-group date' id='Txt_Date01'>
                            <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-lg">
                        <label for="fecha">Hasta:</label>
                        <div class='input-group date' id='Txt_Date02'>
                            <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Hasta..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-lg">
                        <label for="Ddl_LugarTM">Lugar de TdeM</label>
                        <select id="Ddl_LugarTM" class="form-control">
                        </select>
                    </div>
                    <div class="col-lg">
                        <label for="Ddl_Orden_Ate">Orden de Atención</label>
                        <select id="Ddl_Orden_Ate" class="form-control">
                            <option value="0">Todos</option>
                        </select>
                    </div>
                    <div class="col-lg">
                        <label for="Ddl_Estados">Estados</label>
                        <select id="Ddl_Estados" class="form-control">
                            <option value="0">Todos</option>
                        </select>
                    </div>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="row" style="margin-left: 0px !important; margin-right: 0px !important;">
                    <div class="col-lg">
                        <label for="txt_timer">Tiempo de Refresco:</label>
                        <div class="row">
                            <div class="col">
                                <input id="txt_timer" type="number" class="form-control" min="15" max="60" />
                            </div>
                            <div class="col text-center">
                                <h2 id="CuentaAtras">00</h2>
                            </div>
                        </div>

                        <div class="row" style="margin-left: 0px !important; margin-right: 0px !important;">
                            <div class="col">
                                <button type="button" id="btn_timer" class="btn btn-block btn-buscar">Actualizar</button>
                            </div>
                            <div class="col">
                                <button type="button" id="btn_Play" class="btn btn-block btn-success active"><i class="fa fa-w fa-play btnplay"></i></button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <h3 class="text-center">Datos del Paciente Seleccionado</h3>
        <div class="row" style="margin-left: 0px !important; margin-right: 0px !important;">

            <div class="col-lg" id="n_atencion">
                <label for="lblnate" style="font-size: 1.2em;">N° Atención: <b><span id="lblnate"></span></b></label>
            </div>
            <div class="col-lg-3">
                <label for="lblnom" style="font-size: 1.2em;">Nombre: <b><span id="lblnom"></span></b></label>

            </div>
            <div class="col-lg">
                <label for="lbledad" style="font-size: 1.2em;">Edad: <b><span id="lbledad"></span></b></label>

            </div>
            <div class="col-lg">
                <label for="lblsexo" style="font-size: 1.2em;">Sexo: <b><span id="lblsexo"></span></b></label>

            </div>

            <div class="col-lg">
                <label for="lblcelu" style="font-size: 1.2em;">Fono 1: <b><span id="lblcelu"></span></b></label>

            </div>

            <div class="col-lg">
                <label for="lblfono" style="font-size: 1.2em;">Fono 2: <b><span id="lblfono"></span></b></label>

            </div>
            <hr />
        </div>
        <div class="row" style="margin-left: 5px !important; margin-right: 0px !important;">
            <div class="col-3 ml-2" id="inp_social">
                <label for="lblnomSoc" class="mt-1" style="font-size: 1.2em;">Nombre Social: <b><span id="lblnomSoc"></span></b></label>
            </div>
            <div class="col-3 ml-2" id="txt_genero">
                <label for="lblGenero" class="mt-1" style="font-size: 1.2em;">Genero: <b><span id="lblGenero"></span></b></label>
            </div>
            <div class="col-3 ml-2" id="txt_etnia">
                <label for="lblEtnia" class="mt-1" style="font-size: 1.2em;">Pueblos originarios: <b><span id="lblEtnia"></span></b></label>
            </div>
        </div>
        <hr />
        <div class="container">
            <div class="row">

                <div class="d-flex align-items-center" style="width: 100%;">
                    <div class="container">
                        <div class="row">
                            <div class="col-7">
                                <h5 class="marque-x">Marque <b>'✓'</b> en cada cuadro si se realiza uso de DIP.</h5>

                                <div class="row ml-4">
                                    <div class="col">
                                        <input class="form-check-input" type="checkbox" id="chkDipCUP" />
                                        <label class="form-check-label" for="chkDipCUP">CUP</label>
                                    </div>
                                    <div class="col">
                                        <input class="form-check-input" type="checkbox" id="chkDipCVC" />
                                        <label class="form-check-label" for="chkDipCVC">CVC</label>
                                    </div>
                                    <div class="col">
                                        <input class="form-check-input" type="checkbox" id="chkDipPICCLINE" />
                                        <label class="form-check-label" for="chkDipPICCLINE">PICC LINE</label>
                                    </div>
                                    <div class="col">
                                        <input class="form-check-input" type="checkbox" id="chkDipTET" />
                                        <label class="form-check-label" for="chkDipTET">TET</label>
                                    </div>
                                    <div class="col">
                                        <input class="form-check-input" type="checkbox" id="chkDipTQT" />
                                        <label class="form-check-label" for="chkDipTQT">TQT</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col">
                                <label>
                                    <input class="form-check-input" type="checkbox" id="chkDipAREpi" />
                                    <h5 class="form-check-label" for="chkDipAREpi">Marque <b>'✓'</b> si tiene sospecha de AREpi.</h5>
                                </label>
                            </div>
                            <div class="col-1">
                                <button type="button" class="btn btn-success" id="btnGuardarObservaciones">
                                    Guardar Datos IAAS
                                </button>
                            </div>
                        </div>
                    </div>
                  
                </div>
                <div class="p-2">
                    <div class="row">
                        <ul>
                            <li>
                                <h5 class="marque-x">Datos Extras</h5>
                            </li>
                        </ul>
                    </div>
                    <div class="row">
                        <div class="col-md-3 col-sm-6 mb-3">
                            <label for="txt_hgt">HGT (mg/dL):</label>
                            <input type="text" class="form-control" id="txt_hgt" />
                        </div>
                        <div class="col-md-3 col-sm-6 mb-3">
                            <label for="lbl_Talla">Talla (cm):</label>
                            <input type="text" class="form-control" id="lbl_Talla" />
                        </div>
                        <div class="col-md-3 col-sm-6 mb-3">
                            <label for="lbl_Peso">Peso (kg):</label>
                            <input type="text" class="form-control" id="lbl_Peso" />
                        </div>

                        <div class="col-md-3 col-sm-6 mb-3">
                            <label for="lbl_Diuresis">Diuresis (mL)</label>
                            <input type="text" class="form-control" id="lbl_Diuresis" />
                        </div>

                    <%--    <div class="col-md-3 col-sm-6 mb-3">
                            <label for="txtFechaUltimaDosis">Hora última dosis:</label>
                            <input type="datetime-local" class="form-control" id="txtFechaUltimaDosis" />
                        </div>--%>
                     

                        <div class="col-md-3 col-sm-6 mb-3">
                            <label for="lbl_obs_per">Observación permanente</label>
                            <input type="text" class="form-control" id="lbl_obs_per" />
                        </div>
                        <div class="col-md-3 col-sm-6 mb-3">
                            <label>Observación de Atención:</label>
                            <input type="text" id="txt-obs-toma-atencion" class="form-control" placeholder="" />
                        </div>
                        <div class="col-md-3 col-sm-6 mb-3">
                            <label>Observación de TdeM:</label>
                            <input type="text" id="txt-obs-toma-muestra" class="form-control" placeholder="" />
                        </div>
                        <div class="col-md-3 col-sm-6 mb-3" hidden>
                            <label>Zona de TdeM:</label>
                            <input type="text" id="txt-zona-toma-muestra" class="form-control" placeholder="" />
                        </div>
                        <div class="col-md-2 col-sm-6 mb-3">
                            <label>Fecha última dosis:</label>
                            <input type="date" id="txt-fecha-dosis" class="form-control" />
                          
                        </div>
                        
                        <div class="col-md-2 col-sm-6 mb-3">
                           
                            <label>Hora última dosis:</label>
                            <input type="time" id="txt-hora-dosis" class="form-control" />
                        </div>
                        <div class="col-md-3 col-sm-6 mb-3">
                            <label for="txtGramaje" id="lblGramaje">Dosis: (g o mg)</label>
                            <input id="txtGramaje" type="number" step="any" class="form-control" />
                        </div>
                        <div class="col-md-2 col-sm-6 mb-3">
                            <label>Fecha Nacimiento:</label>
                            <input type="date" id="txt-fecha-nacimiento" disabled="" class="form-control" />
                        </div>
                        <div class="col-md-2 col-sm-6 mb-3">
                            <label>Hora Nacimiento:</label>
                            <input type="time" id="txt-hora-nacimiento" disabled="" class="form-control" />
                        </div>

                        <div class="col-md-3 col-sm-6 mb-3 d-flex align-items-end">
                            <button type="button" class="btn btn-primary" id="btn_Act_Obs">Actualizar/Guardar Datos</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="row">
        <div class="col-4"></div>
        <div class=" col-4 form-group">
            <label for="prof_tm">Profesional que realiza la TdeM:</label>
            <select id="prof_tm" class="form-control">
                <option value="volvo">Seleccionar</option>
            </select>
        </div>
    </div>


    <div style="display: flex; width: 100%; justify-content: end; gap: 1rem;">
        <button type="button" id="btnSegundaCargaLista" class="btn btn-danger btn-busca btn-block" style="max-width: fit-content;">
            <i class="fa fa-fw fa-check"></i>
            Glucosa 75g OK
        </button>
        <button type="button" id="btnTomaSegundaPTGO" class="btn btn-warning btn-busca btn-block" style="max-width: fit-content; margin-right: 1rem;">
            <i class="fa fa-fw fa-check"></i>
            Glicemia 120 OK
        </button>
    </div>
    <div class="row mb-3" style="overflow: auto; max-height: 50vh; margin-left: 0px !important; margin-right: 0px !important;">
        <div class="col-12">
            <h4 class="text-center">Listado de Pacientes</h4>
            <table id="DataTable" class="w-100 table table-hover table-striped table-iris"></table>

        </div>
    </div>
    <div class="row">
        <div class="col-lg text-center mb-3">
            <h5 id="lblerror"></h5>
        </div>
    </div>
    <div class="row" style="margin-left: 0px !important; margin-right: 0px !important;">
        <div class="col-lg">
            <h5>N° de Pacientes: <b><span id="span_num_pac" style="color: red"></span></b></h5>
        </div>
        <div class="col-lg">
            <h5>Estado: <b><span id="span_est"></span></b></h5>
        </div>
        <div class="col-lg">
            <button type="button" id="btn_atendido" class="btn btn-success btn-block m-1"><i class="fa fa-fw fa-check"></i>Atendido</button>
        </div>
        <div class="col-lg" hidden=" ">
            <button type="button" id="btn_actualizar_obs" class="btn btn-warning btn-block m-1"><i class="fa fa-fw fa-pencil"></i>DIP - AREpi</button>
        </div>
        <div class="col-lg">
            <button type="button" id="btn_pendiente" class="btn btn-pendiente btn-block m-1"><i class="fa fa-fw fa-clock-o"></i>Pendiente</button>
        </div>
        <div class="col-lg">
            <button type="button" id="btn_imprimir" class="btn btn-print btn-block m-1"><i class="fa fa-fw fa-print"></i>Imprimir</button>
        </div>
    </div>
</asp:Content>
