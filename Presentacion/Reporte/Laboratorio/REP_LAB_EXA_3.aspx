<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="REP_LAB_EXA_3.aspx.vb" Inherits="Presentacion.REP_LAB_EXA_3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>

    <%-- Botones --%>
    <link href="../../../../Resourses/Style/Buttons.css" rel="stylesheet" />

    <%--Esto es para que funcione el gráfico--%>
    <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>
    <script src="/js/Custom_modal.js"></script>
    <script src="/js/Custom_Objects.js"></script>

    <%-- Declaración de Eventos --%>
    <script>
        $(document).ready(function () {
            //Ajustes Visuales
            //$(".block_wait").css({ "display": "none" });
            $(".block_wait").hide();
            $("#Div_Total").empty().css({ "display": "none" });
            $("#Div_Graph").empty().css({ "display": "none" });
            $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });
            $("#Div_Tabla_Data").append(
                $("<div>").css({
                    "width": "calc(100% - 60)",
                    "text-align": "center",
                    "padding": "30px",
                    "font-size": "30px"
                }).text("Realice una Búsqueda.")

            );

            //Llamar al llenado de los DropDownList
            Ajax_Ddl();
            Ajax_Ddl_Proce();
            //Registrar evento Click del Botón Buscar
            $("#Btn_Search").click(function () {

                Ajax_DataTable();


            });

            $("#Btn_Export").click(function () {
                Ajax_Excel();
            });
            $("#Btn_PDF").click(function () {
                Ajax_PDF();
            });

            $("#Btn_Print").click((Me) => {
                let bolChecked = $(`#chkAll`).is(":checked");
                let arrOutput = [];
                let arrIn = [];

                if (bolChecked == true) {
                    Mx_Dtt.forEach((xItem, i) => {
                        arrOutput.push({
                            ID_ATE: Mx_Dtt[i].ID_ATENCION,
                            Cod_Barra: [
                                Mx_Dtt[i].CB_DESC       
                            ]
                        });
                    });
                } else {
                    arrIn = $(`input[name=chkREEEE]:checked`);
             
                    for (i = 0; i < arrIn.length; i++) {
                        arrOutput.push(JSON.parse(atob(arrIn.eq(i).val())));
                    }
                }

                var REE = $.ajax({
                    "type": "POST",
                    "url": "http://localhost:9990/Printer/Imp_Etiquetas_Cod_Barra",
                    //"url": "http://localhost:9990/Printer/Imp_Voucher_Agendam",
                    "data": JSON.stringify(arrOutput),
                    "contentType": "application/json;  charset=utf-8",
                    "contentType": "text/plain;  charset=utf-8",
                    "dataType": "json",
                    "timeout": 15000,
                    "success": (Resp) => {
                    
                        var json_receiver = Resp.d;
                        $(".block_wait").fadeOut(500);

                        if (json_receiver != "null") {
                            var str_Download = "Las etiquetas se imprimieron correctamente.";


                            $("#mdlNotif .modal-header h4").text("Impresión Etiquetas");
                            $("#mdlNotif .modal-body p").html(str_Download);
                            $("#mdlNotif").modal();
                        }
                        else {

                        }
                    },
                    "error": (Resp) => {
                        alert("Error en la Recepción de Datos");


                        Hide_Modal();
                        console.log(Resp.d);
                    }
                });
            });

        });
    </script>


    <%-- Peticiones AJAX --%>
    <script>
        //Json de llenado de DropDownList
        var Mx_Ddl = [
            {
                "ID_CODIGO_FONASA": 0,
                "CF_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];
        var Mx_Ddl_Proce = [
               {
                   "ID_PROCEDENCIA": "",
                   "PROC_COD": "",
                   "PROC_DESC": "",
                   "ID_ESTADO": ""
               }
        ];
        function Ajax_Ddl_Proce() {
            //Debug



            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "REP_LAB_EXA_3.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Ddl = JSON.parse(data.d);

                    Fill_Ddl_Proce();
                },
                "error": data => {
                    //Debug



                }
            });
        }
        function Fill_Ddl_Proce() {

            var procee = Galletas.getGalleta("USU_TM");

            if (procee == 0) {
                $("<option>",
                {
                    "value": "0"
                }
                ).text("Todos").appendTo("#DdlProce");
                Mx_Ddl.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#DdlProce");
                });
            }
            else {
                Mx_Ddl.forEach(aaa => {
                    if (aaa.ID_PROCEDENCIA == procee) {
                        $("<option>",
                          {
                              "value": aaa.ID_PROCEDENCIA
                          }
                       ).text(aaa.PROC_DESC).appendTo("#DdlProce");
                    }

                });
            }
        }
        function Ajax_Ddl() {



            $.ajax({
                "type": "POST",
                "url": "REP_LAB_EXA_3.aspx/Llenar_Ddl",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl = JSON.parse(json_receiver);
                        Fill_Ddl();
                        $(".block_wait").hide();



                    } else {

                        $("#Div_Tabla_Data").empty();
                        $("#Div_Tabla_Total").empty();
                        $("#Summary_Graph").empty();
                        $("#Div_dinero").empty();
                        $("#Div_Tabla_Data").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",
                                "color": "#000000"
                            }).text("Sin Resultados.")
                        );



                    }
                },
                "error": function (response) {



                }
            });
        }
        //Json de llenado de DataTable
        var Mx_Dtt = [
            {
                "ID_ATENCION": 0,
                "ATE_NUM": 0,
                "ATE_FECHA": 0,
                "ID_PACIENTE": 0,
                "PAC_RUT": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "ATE_AÑO": "asdf",
                "SEXO_DESC": 0,
                "ID_SEXO": 0,
                "ID_PROCEDENCIA": "asdf",
                "ID_ESTADO": "asdf",
                "PROC_DESC": 0,
                "ID_NACIONALIDAD": 0,
                "ID_ORDEN": "asdf",
                "ID_TP_PACI": "asdf",
                "CF_DESC": 0,
                "ID_CODIGO_FONASA": "asdf",
                "FECHA_NAC": 0,
                "DNI": 0,
                "NACIONALIDAD": 0,
                "PROGRAMA": 0,
                "SECTOR": 0,
                "NUMERO_INTERNO": 0,
                "MEDICO_SOLICITANTE": 0,
                "MEDICO_SOLICITANTE_2": 0,
                "CB_DESC": 0,
                "ATE_OBS_TM": 0

            }
        ];

        function Ajax_DataTable() {


            modal_show();
            var Data_Par = JSON.stringify({
                "ID_CODIGO_FONASA": 0,
                "DATE_str01": String($("#TxtDate_01").val()),
                "DATE_str02": String($("#TxtDate_02").val()),
                "PROCEDENCIA": String($("#DdlProce").val())
            });

            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "REP_LAB_EXA_3.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);

                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].ATE_FECHA = Date_Change;
                        }

                        Fill_DataTable();
                        $(".block_wait").hide();


                    } else {


                        $("#Div_Tabla_Data").empty();
                        $("#Div_Tabla_Data").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",
                                "color": "#000000"
                            }).text("Sin Resultados.")
                        );
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    alert("Error en la Recepción de Datos");


                    Hide_Modal();
                }
            });
        }

        //Generar Excel
        function Ajax_Excel() {



            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,

                "DATE_str01": String($("#TxtDate_01").val()).replace(/\//g, "a"),
                "DATE_str02": String($("#TxtDate_02").val()).replace(/\//g, "a"),
                "ID_CODIGO_FONASA":0,
                "PROCEDENCIA": $("#DdlProce").val()
                //"PREVE_DESC": $("#DdlExamen").val()
            });

            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "REP_LAB_EXA_3.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    $(".block_wait").fadeOut(500);

                    if (json_receiver != "null") {
                        var str_Download = "La Planilla Excel se ha generado correctamente, puede descargarla haciendo click ";
                        str_Download += "<a href='" + json_receiver + "'>AQUÍ.</a>";

                        $("#mdlNotif .modal-header h4").text("Archivo Generado");
                        $("#mdlNotif .modal-body p").html(str_Download);
                        $("#mdlNotif").modal();



                    } else {
                        var str_Error = "La petición de generación de planilla Excel no se ha realizado debido ";
                        str_Error += "a que los parámetros de búsqueda no arrojaron resultados."

                        $("#mdlNotif .modal-header h4").text("Error");
                        $("#mdlNotif .modal-body p").html(str_Error);
                        $("#mdlNotif").modal();



                    }
                },
                "error": function (response) {
                    Hide_Modal();
                    $("#mdlNotif .modal-header h4").text(String(response.responseJSON.ExceptionType).trim());
                    $("#mdlNotif .modal-body p").html(response.responseJSON.Message);
                    $("#mdlNotif").modal();



                }
            });
        }
        function Ajax_PDF() {

            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "ID_CODIGO_FONASA": parseInt(0),
                "DATE_str01": $("#TxtDate_01").val(),
                "DATE_str02": $("#TxtDate_02").val(),
                "PROCEDENCIA": parseInt($("#DdlProce").val())
                //"PREVE_DESC": $("#DdlExamen").val()
            });
            console.log(Data_Par);
            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "REP_LAB_EXA_3.aspx/PDFF",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    $(".block_wait").fadeOut(500);

                    if (json_receiver != null) {
                        var str_Download = "El PDF se ha generado correctamente, puede descargarlo haciendo click ";
                        str_Download += "<a href='" + json_receiver + "'>AQUÍ.</a>";

                        $("#mdlNotif .modal-header h4").text("Archivo Generado");
                        $("#mdlNotif .modal-body p").html(str_Download);
                        $("#mdlNotif").modal();



                    } else {
                        var str_Error = "La petición de generación del PDF no se ha realizado debido ";
                        str_Error += "a que los parámetros de búsqueda no arrojaron resultados."

                        $("#mdlNotif .modal-header h4").text("Error");
                        $("#mdlNotif .modal-body p").html(str_Error);
                        $("#mdlNotif").modal();



                    }
                },
                "error": function (response) {
                    Hide_Modal();
                    console.log(response);
                    $("#mdlNotif .modal-header h4").text(String(response.ExceptionType).trim());
                    $("#mdlNotif .modal-body p").html(response.Message);
                    $("#mdlNotif").modal();



                }
            });
        }
    </script>

    <%-- Funciones de Llenado de Elementos --%>
    <script>
        //Llenar DropDownList
        function Fill_Ddl() {
            $("#DdlExamen").empty();

            $("<option>", {
                "value": 0
            }).text("VIH Y SCREENING DE SIFILIS").appendTo("#DdlExamen");

        };
        //Llenar DataTable
        function Fill_DataTable() {
            $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });

            $("<table>", {
                "id": "DataTable",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Data");

            $("#DataTable").append(
                $("<thead>"),
                $("<tbody>")
            );

            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "text-center" }).text("#"),
                    $("<th>", { "class": "text-center" }).text("Folio"),
                    $("<th>", { "class": "text-center" }).text("RUT/D.N.I"),
                    $("<th>", { "class": "text-center" }).text("Nombre Paciente"),
                    $("<th>", { "class": "text-center" }).text("Fecha Nac."),
                    $("<th>", { "class": "text-center" }).text("Edad"),
                    $("<th>", { "class": "text-center" }).text("Nacionalidad"),
                    $("<th>", { "class": "text-center" }).text("Fecha"),
                    $("<th>", { "class": "text-center" }).text("Hora"),
                    $("<th>", { "class": "text-center" }).text("Lugar de TM"),
                    $("<th>", { "class": "text-center" }).text("Sexo"),
                    $("<th>", { "class": "text-center" }).text("Exámen"),
                    $("<th>", { "class": "text-center" }).text("Programa"),
                    $("<th>", { "class": "text-center" }).text("Sector"),
                    $("<th>", { "class": "text-center" }).text("Doctor"),
                    $("<th>", { "class": "text-center" }).text("Obs. TM"),
                    $("<th>", { "class": "text-center", style: "min-width: 150px;" }).append(
                        $(`<label>`, { for: "chkAll", style: "margin-right: 1rem;" }).text("Imp. Etiquetas"),
                        $(`<input>`, {
                            type: "checkbox",
                            id: "chkAll"
                        })
                    )
                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {

                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].ATE_NUM),
                        $("<td>", { "align": "center" }).text(function () {
                            if (Mx_Dtt[i].PAC_RUT == "") {
                                return Mx_Dtt[i].DNI
                            } else {
                                return Mx_Dtt[i].PAC_RUT
                            }

                        }),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].FECHA_NAC),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].ATE_AÑO),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].NACIONALIDAD),
                          $("<td>", { "align": "center" }).text(function () {
                              //Obtener valores
                              var obj_date = new Date(Mx_Dtt[i].ATE_FECHA);
                              var dd = parseInt(obj_date.getDate());
                              var mm = parseInt(obj_date.getMonth()) + 1;
                              var yy = parseInt(obj_date.getFullYear());

                              if (dd < 10) { dd = "0" + dd; }
                              if (mm < 10) { mm = "0" + mm; }

                              return String(dd + "/" + mm + "/" + yy);
                          }),
                        $("<td>", { "align": "center" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt[i].ATE_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var MM = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (MM < 10) { MM = "0" + MM; }

                            var hh = parseInt(obj_date.getHours());
                            var mm = parseInt(obj_date.getMinutes());

                            if (hh < 10) { hh = "0" + hh; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(hh + ":" + mm);
                        }),
                        $("<td>").text(Mx_Dtt[i].PROC_DESC),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].SEXO_DESC),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].CF_DESC),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].PROGRAMA),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].SECTOR),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].MEDICO_SOLICITANTE + " " + Mx_Dtt[i].MEDICO_SOLICITANTE_2),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].ATE_OBS_TM),
                        $("<td>", { "align": "center" }).append(
                            $(`<input>`, {
                                type: "checkbox",
                                name: "chkREEEE",
                                value: btoa(JSON.stringify({
                                    ID_ATE: Mx_Dtt[i].ID_ATENCION,
                                    Cod_Barra: [
                                        Mx_Dtt[i].CB_DESC       //CARLOS AGREGA AL PA ESTA COSA!!!!!!!!!UNO!!!1
                                    ]
                                }))
                            })
                        )
                    )
                );
            }

            let objDTT = $("#DataTable").DataTable({
                "bSort": false,
                "iDisplayLength": 25,
                "language": {
                    "DisplayLength": 100,
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay concidencias",
                    "info": "Mostrando Página _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
            Hide_Modal();

            $(`#chkAll`).click((Me) => {
                let bolChecked = $(Me.currentTarget).is(":checked");
                $(`input[name=chkREEEE]`).attr("checked", bolChecked);
            });

            objDTT.on("draw", () => {
                let bolChecked = $(`#chkAll`).is(":checked");
                $(`input[name=chkREEEE]`).attr("checked", bolChecked);
            });
        }
    </script>

    <%-- Datepickers --%>
    <script>
        $(document).ready(function () {
            var Date_Now = function () {
                //Obtener valores
                var obj_date = new Date();
                var dd = parseInt(obj_date.getDate());
                var mm = parseInt(obj_date.getMonth()) + 1;
                var yy = parseInt(obj_date.getFullYear());

                if (dd < 10) { dd = "0" + dd; }
                if (mm < 10) { mm = "0" + mm; }

                return String(dd + "/" + mm + "/" + yy);
            };

            $('#fecha1').datetimepicker(
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
            $('#fecha2').datetimepicker(
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
            $("#fecha1 input").val(dateNow);
            $("#fecha2 input").val(dateNow);

            //$("#TxtDate_01").val(Date_Now);
            //$("#TxtDate_02").val(Date_Now);
        });
    </script>


    <%-- CSS Personalizado --%>
    <style>
        #DataTable thead, #Table_T thead {
            background-color: #28a745;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cph_Body" runat="server">

    <div class="card mb-3 border-bar">
        <div class="card-header bg-bar">
            <h5>Búsqueda de Atenciones VIH Y SCREENING DE SIFILIS</h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <label for="fecha">Desde:</label>
                    <div class='input-group date' id='fecha1'>
                        <input type='text' id="TxtDate_01" class="form-control" readonly="true" placeholder="Desde..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label for="fecha">Desde:</label>
                    <div class='input-group date' id='fecha2'>
                        <input type='text' id="TxtDate_02" class="form-control" readonly="true" placeholder="Hasta..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label for="DdlExamen">Tipo de Exámen:</label>
                    <select id="DdlExamen" class="form-control"></select>
                </div>
                <div class="col-lg">
                    <label for="DdlProce">Lugar de TM:</label>
                    <select id="DdlProce" class="form-control"></select>
                </div>
                <%--  <div class="col-lg-1">
                   
                </div>
                <div class="col-lg-1">
                   
                </div>--%>
            </div>
            <div class="row">
                <div class="col-lg">
                    <button id="Btn_Search" type="button" class="btn btn-block btn-buscar btn-sm"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                </div>
                <div class="col-lg">
                    <button id="Btn_Export" type="button" class="btn btn-block btn-success btn-sm"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                </div>
                <div class="col-lg">
                    <button id="Btn_PDF" type="button" class="btn btn-block btn-info btn-sm"><i class="fa fa-fw fa-file-pdf-o mr-2"></i>PDF</button>
                </div>
                <div class="col-lg">
                    <button id="Btn_Print" type="button" class="btn btn-block btn-print btn-sm">
                        <i class="fa fa-fw fa-print mr-2"></i>
                        <span>Imprimir</span>
                    </button>
                </div>
            </div>
        </div>
    </div>
    <div class="card p-3 border-bar">
        <div class="row">
            <div class="col-lg-12">
                <div class="row mb-3">
                    <div class="col-lg">
                        <h5>Listado de Atenciones</h5>
                        <div id="Div_Tabla_Data" class="table table-hover table-striped table-iris" style="overflow: auto"></div>
                    </div>
                </div>
                <%--  <div class="row">
                    <div class="col-lg">
                        <h5>Totales</h5>
                        <div id="Div_Tabla_02" class="table table-hover table-striped table-iris"></div>
                    </div>
                </div>--%>
            </div>

        </div>
        <%--<div class="row">
            <div class="col-lg-12">
                <h5>Gráfico</h5>
                <div id="Summary_Graph"></div>
            </div>
        </div>--%>
    </div>
</asp:Content>
