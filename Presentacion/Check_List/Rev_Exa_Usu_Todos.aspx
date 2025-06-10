<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Rev_Exa_Usu_Todos.aspx.vb" Inherits="Presentacion.Rev_Exa_Usu_Todos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/ClockPicker.css" rel="stylesheet" />
    <script src="/js/ClockPicker.js"></script>


    <script>
        $(document).ready(() => {
            Ajax_Ddl_Exa();
            Ajax_Ddl_Usu();
            Call_AJAX_Ddl();

            $("#txtClock_D, #txtClock_H").clockpicker();

            $("#txtClock_D input").val("00:00");
            $("#txtClock_H input").val("23:59");

            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input, #Txt_Date02 input").val(dateNow);
            $("#Txt_Date01, #Txt_Date02").datetimepicker({
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
            });

            $("#Btn_Search").click(() => {
                Ajax_Table();
            });

            $("#Btn_Export").click(() => {
                Ajax_Excel();
            });
            
        });

        let Mx_Ddl_Exa = [
            {
                "ID_CODIGO_FONASA": 0,
                "CF_DESC": "",
                "ID_ESTADO": 0
            }
        ];

        function Ajax_Ddl_Exa() {
            $.ajax({
                "type": "POST",
                "url": "Rev_Exa_Usu_Todos.aspx/Llenar_Ddl_Exa",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Ddl_Exa = json_receiver;
                        Fill_Ddl_Exa();

                    } else {

                    }
                },
                "error": function (response) {
                }
            });
        }

        var Mx_Ddl_Usu = [
            {
                "ID_USUARIO": 0,
                "USU_NOMBRE": "",
                "USU_APELLIDO": "",
                "ID_ESTADO": 0,
                "PER_USU_DESC": "",
                "USU_NIC": ""
            }
        ];

        function Ajax_Ddl_Usu() {

            $.ajax({
                "type": "POST",
                "url": "Rev_Exa_Usu_Todos.aspx/Llenar_Ddl_Usu",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Ddl_Usu = json_receiver;
                        Fill_Ddl_Usu();
                    } else {
                    }
                },
                "error": function (response) {
                }
            });
        }

        //Declaración de JSON
        var Mx_Ddl = [{
            "ID_PROCEDENCIA": "",
            "PROC_COD": "",
            "PROC_DESC": "",
            "ID_ESTADO": ""
        }];

        //AJAX DroDownList
        function Call_AJAX_Ddl() {
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "Rev_Exa_Usu_Todos.aspx/Llenar_Ddl_LugarTM",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    Mx_Ddl = data.d;
                    Fill_Ddl();
                },
                "error": data => {
                }
            });
        }

        //FILL DROPDOWNLIST LUGARTM
        function Fill_Ddl() {
            var procee = Galletas.getGalleta("USU_ID_PROC");

                $("#Ddl_LugarTM").append(
                    $("<option>", {
                        "value": "0"
                    }).text("TODOS")
                );
            
            Mx_Ddl.forEach(aaa => {
                $("#Ddl_LugarTM").append(
                    $("<option>", {
                        "value": aaa.ID_PROCEDENCIA
                    }).text(aaa.PROC_DESC)
                );
            });
        }

        function Fill_Ddl_Exa() {
            $("#DdlExamen").empty();
            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#DdlExamen");
            for (y = 0; y < Mx_Ddl_Exa.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl_Exa[y].ID_CODIGO_FONASA
                }).text(Mx_Ddl_Exa[y].CF_DESC).appendTo("#DdlExamen");
            }
        };

        function Fill_Ddl_Usu() {
            $("#DdlUsuario").empty();

            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#DdlUsuario");
            for (y = 0; y < Mx_Ddl_Usu.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl_Usu[y].ID_USUARIO
                }).text(Mx_Ddl_Usu[y].USU_NOMBRE+ " " + Mx_Ddl_Usu[y].USU_APELLIDO).appendTo("#DdlUsuario");
            }
        };

        let Mx_Dtt = [{
            Folio: "",
            Fecha_Ingreso: "",
            Hora_Ingreso: "",
            Rut: "",
            Nombre_Pac: "",
            Examen: "",
            Fecha_Valida: "",
            Hora_Valida: "",
            Usuario_Valida: "",
            Procedencia: "",
            PRU_DESC:"",
            ATE_RESULTADO: "",
            ATE_RESULTADO_NUM: "",
            PAC_FNAC: "",
            ID_SEXO: "",
            ATE_OBS_FICHA: "",
            ATE_OBS_TM:""
        }];

        function Ajax_Table() {
            let f1, f2, h1, h2;

            f1 = $("#fecha").val();
            f2 = $("#fecha2").val();

            h1 = $("#txtClock_D input").val();
            h2 = $("#txtClock_H input").val();

            if (h1 == "23:59") {
                h1 = h1 + ":59";
            } else {
                h1 = h1 + ":00";
            }

            if (h2 == "23:59") {
                h2 = h2 + ":59";
            } else {
                h2 = h2 + ":00";
            }

            f1 = f1 + " " + h1;
            f2 = f2 + " " + h2;

            console.log(f1);
            console.log(f2);


            modal_show();
            let Data_Par = JSON.stringify({
                "DESDE": f1,
                "HASTA": f2,
                "ID_CF": $("#DdlExamen").val(),
                "ID_USU": $("#DdlUsuario").val(),
                "ID_PROC": $("#Ddl_LugarTM").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Rev_Exa_Usu_Todos.aspx/Llenar_DTT",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;

                        fn_Fill_Table();

                        Hide_Modal();
                    } else {
                        console.log(response);
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    console.log(response);
                    Hide_Modal();
                }
            });


        }

        function fn_Fill_Table() {
            $("#div_Tabla").empty();

            $("#div_Tabla").html("<div class='text-center mt-3 w-100'><h5 class='mb-0'>Listado de Exámenes Validados</h5></div>");

            $("<table>").attr({ id: "DataTable", cellspacing: "0", class: "table table-hover table-striped table-iris dataTable no-footer" }).appendTo($("#div_Tabla"));

            $("#DataTable").append(
                $("<thead>").append(
                    $("<tr>").append(
                        $("<th>").text("#"),
                        $("<th>").text("Folio"),
                        $("<th>").text("Fecha Ingreso"),
                        $("<th>").text("Hora Ingreso"),
                        $("<th>").text("RUT"),
                        $("<th>").text("Nombre Pac"),
                        $("<th>").text("Pac FNac"),
                        $("<th>").text("Sexo"),
                        $("<th>").text("Obs."),
                        $("<th>").text("Procedencia"),
                        $("<th>").text("Examen"),
                        $("<th>").text("Determinación"),
                        $("<th>").text("Resultado"),
                        $("<th>").text("Fecha Validación"),                   
                        $("<th>").text("Hora Validación"),
                        $("<th>").text("Profesional")
                    )
                )
            );

            $("#DataTable").append(
                $("<tbody>")
            );

            let i = 1

            Mx_Dtt.forEach(aah => {
                $("<tr>").append(
                    $("<td>").text(i),
                    $("<td>").text(aah.Folio),
                    $("<td>").text(aah.Fecha_Ingreso),
                    $("<td>").text(aah.Hora_Ingreso),
                    $("<td>").text(aah.Rut),
                    $("<td>").text(aah.Nombre_Pac),
                    $("<td>").text(moment(aah.PAC_FNAC).format("DD-MM-YYYY")),
                    $("<td>").text(function () {
                        if (aah.ID_SEXO == 1) {
                            return "Masculino";
                        } else {
                            return "Femenino";
                        }
                    }),
                    $("<td>").text(aah.ATE_OBS_FICHA + " " + aah.ATE_OBS_TM),
                    $("<td>").text(aah.Procedencia),
                    $("<td>").text(aah.Examen),
                    $("<td>").text(aah.PRU_DESC),
                    $("<td>").text(function () {
                        if (aah.ATE_RESULTADO_NUM == "") {
                            return aah.ATE_RESULTADO;
                        } else {
                            return aah.ATE_RESULTADO_NUM;
                        }
                    }),
                    $("<td>").text(aah.Fecha_Valida),
                    $("<td>").text(aah.Hora_Valida),
                    $("<td>").text(aah.Usuario_Valida)
                ).appendTo($("#DataTable tbody"));
                i++;
            });

            $("#DataTable").DataTable({
                "bSort": true,
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

        function Ajax_Excel() {
            let f1, f2, h1, h2;

            f1 = $("#fecha").val();
            f2 = $("#fecha2").val();

            h1 = $("#txtClock_D input").val();
            h2 = $("#txtClock_H input").val();

            if (h1 == "23:59") {
                h1 = h1 + ":59";
            } else {
                h1 = h1 + ":00";
            }

            if (h2 == "23:59") {
                h2 = h2 + ":59";
            } else {
                h2 = h2 + ":00";
            }

            f1 = f1 + " " + h1;
            f2 = f2 + " " + h2;

            console.log(f1);
            console.log(f2);


            modal_show();
            let Data_Par = JSON.stringify({
                "MAIN_URL": location.origin,
                "DESDE": f1,
                "HASTA": f2,
                "ID_CF": $("#DdlExamen").val(),
                "ID_USU": $("#DdlUsuario").val(),
                "ID_PROC": $("#Ddl_LugarTM").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Rev_Exa_Usu_Todos.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        window.open(json_receiver, 'Download');
                        Hide_Modal();
                    } else {
                        console.log(response);
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    console.log(response);
                    Hide_Modal();
                }
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">

    <div class="card border-bar">
        <div class="card-header bg-bar text-center">
            <h4 class="mb-0">Revisión Exámenes por Fecha Validación</h4>
        </div>
        <div class="card-body pt-2 pb-2">
            <div class="row">
                <div class="col-lg">
                    <label for="fecha">Fecha Desde:</label>
                    <div class='input-group date' id='Txt_Date01'>
                        <input type='text' id="fecha" class="form-control bg-white" readonly="true" placeholder="Desde..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label class="textoReducido">Hora Desde:</label>
                    <!--Clockpicker-->
                    <div class='input-group clockPicker' id='txtClock_D' style="margin-bottom: 1vh;" data-align="top" data-autoclose="true">
                        <input type="text" class="form-control bg-white" value="00:00" readonly="true" />
                        <span class="input-group-addon">
                            <i class="fa fa-clock-o"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label for="fecha">Fecha Hasta:</label>
                    <div class='input-group date' id='Txt_Date02'>
                        <input type='text' id="fecha2" class="form-control bg-white" readonly="true" placeholder="Desde..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label class="textoReducido">Hora Hasta:</label>
                    <!--Clockpicker-->
                    <div class='input-group clockPicker' id='txtClock_H' style="margin-bottom: 1vh;" data-align="top" data-autoclose="true">
                        <input type="text" class="form-control bg-white" value="23:59" readonly="true" />
                        <span class="input-group-addon">
                            <i class="fa fa-clock-o"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label for="Ddl_LugarTM">Lugar de TM:</label>
                    <select id="Ddl_LugarTM" class="form-control">
                    </select>
                </div>
                <div class="col-lg">
                    <label for="DdlExamen">Examen:</label>
                    <select id="DdlExamen" class="form-control"></select>
                </div>
                <div class="col-lg">
                    <label for="DdlUsuario">Profesional:</label>
                    <select id="DdlUsuario" class="form-control"></select>
                </div>
                <div class="col-lg">
                    <button id="Btn_Search" type="button" class="btn btn-block btn-buscar btn-sm mt-0"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                    <button id="Btn_Export" type="button" class="btn btn-block btn-success btn-sm"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                </div>
            </div>
            <div class="row mt-2" id="div_Tabla">
            </div>
        </div>
    </div>
</asp:Content>
