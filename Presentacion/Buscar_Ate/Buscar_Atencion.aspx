<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Buscar_Atencion.aspx.vb" Inherits="Presentacion.Buscar_Atencion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <!-- Inicialización -->
    <script>
        //Declarar AJAX
        var AJAX_Ddl = 0;
        var AJAX_Dtt = 0;
        var AJAX_Exa = 0;

        $(document).ready(function () {
            $("#div_hide_").hide();
            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input").val(dateNow);
            $("#Txt_Date02 input").val(dateNow);
            $('#Txt_Date01').datetimepicker({
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

            $('#Txt_Date02').datetimepicker({
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
            //Eventos
            Call_AJAX_Ddl();

            $("#Btn_Buscar").click(function () {
                $("#Div_Dtt").empty();
                Call_AJAX_Dtt();
            });

            //Registrar evento Click del Botón Excel       
            $("#Btn_Excel").click(function () {
                Ajax_Excel();

            });

            Hide_Modal();
        });
        //Declaración de JSON
        var Mx_Ddl = [{
            "ID_PROCEDENCIA": "",
            "PROC_COD": "",
            "PROC_DESC": "",
            "ID_ESTADO": ""
        }];

        var Mx_Dtt = [{
            "ID_ATENCION": "",
            "ATE_NUM": "",
            "ATE_FECHA": "",
            "ID_PACIENTE": "",
            "PAC_RUT": "",
            "PAC_NOMBRE": "",
            "PAC_APELLIDO": "",
            "ATE_AÑO": "",
            "PROC_DESC": "",
            "DOC_NOMBRE": "",
            "DOC_APELLIDO": "",
            "SEXO_DESC": "",
            "ID_SEXO": "",
            "ENCRYPTED_ID": ""
        }];
        //AJAX DroDownList
        function Call_AJAX_Ddl() {
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "Buscar_Atencion.aspx/Llenar_Ddl_LugarTM",
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
        //AJAX DataTable Atencion
        function Call_AJAX_Dtt() {
            var strParam = JSON.stringify({
                "FECHA1": $("#Txt_Date01 input").val(),
                "FECHA2": $("#Txt_Date02 input").val(),
                "LUGARTM": $("#Ddl_LugarTM").val()
            });
            modal_show();
            AJAX_Dtt = $.ajax({
                "type": "POST",
                "url": "Buscar_Atencion.aspx/Llenar_DataTable",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    $("#div_hide_").show();

                    Mx_Dtt = data.d;
                    if (Mx_Dtt.length != 0) {
                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");
                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].ATE_FECHA = Date_Change;
                        }
                        Fill_Dtt();
                    } else {
                        Hide_Modal();
                    }
                },
                "error": data => {
                    Hide_Modal();
                }
            });
        }

        var Mx_Dtt_Excel = [
{
    "urls": ""
}
        ];

        function Ajax_Excel() {
            modal_show();


            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "FECHA1": $("#Txt_Date01 input").val(),
                "FECHA2": $("#Txt_Date02 input").val(),
                "LUGARTM": $("#Ddl_LugarTM").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Buscar_Atencion.aspx/Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        //Mx_Dtt_Excel = JSON.parse(json_receiver);
                        window.open(json_receiver, 'Download');
                        Hide_Modal();


                    } else {


                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                        $("#Id_Conte").hide();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        function Ajax_Redirect(id) {
            var loc = location.origin;
            window.open(loc + "/Buscar_Ate/Atencion_Det.aspx?ID_ATE=" + id);
        }
        //FILL DROPDOWNLIST LUGARTM
        function Fill_Ddl() {
            var procee = Galletas.getGalleta("USU_ID_PROC");

            if (procee == 0) {
                $("#Ddl_LugarTM").append(
                    $("<option>", {
                        "value": "0"
                    }).text("TODOS")
                );
            }
            Mx_Ddl.forEach(aaa => {
                $("#Ddl_LugarTM").append(
                    $("<option>", {
                        "value": aaa.ID_PROCEDENCIA
                    }).text(aaa.PROC_DESC)
                );
            });
        }
        //FILL DATATABLE ATENCION
        function Fill_Dtt() {
            //Crear Tabla
            $("#Div_Dtt").empty();
            $("#Div_Dtt").append(
                $("<table>", {
                    "id": "Dtt_Ate",
                    "cellspacing": "0"
                }).css({
                    "width": "100%",
                    "border-collapse": "collapse"
                })
            );
            $("#Div_Dtt table").attr("class", "table table-hover table-striped table-iris");
            //Crear cabeceras
            $("#Dtt_Ate").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#Dtt_Ate thead").append(
                $("<tr>").append(
                    $("<th>").text("#"),
                    $("<th>").text("N° Atención"),
                    $("<th>").text("Fecha de Atención"),
                    $("<th>").text("RUT Paciente"),
                    $("<th>").text("Nombre Paciente"),
                    $("<th>").text("Edad"),
                    $("<th>").text("Sexo"),
                    $("<th>").text("Procedencia"),
                    $("<th>").text("Nombre Doctor")
                )
            );
            $("#Div_Dtt table thead tr th").addClass("text-center");
            //Recorrer JSON
            var i = 1
            Mx_Dtt.forEach(aah => {
                $("<tr>", {
                    "onclick": `Ajax_Redirect("` + aah.ENCRYPTED_ID + `")`,
                    "class": "manito"
                }).attr("value", aah.ENCRYPTED_ID).append(
                    $("<td>").css({ "text-align": "left", "font-weight": "bold" }).text(i),
                    $("<td>").css("text-align", "center").text(aah.ATE_NUM),
                    $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                        //Obtener valores
                        var obj_date = new Date(aah.ATE_FECHA);
                        var dd = parseInt(obj_date.getDate());
                        var MM = parseInt(obj_date.getMonth()) + 1;
                        var yy = parseInt(obj_date.getFullYear());
                        var hh = parseInt(obj_date.getHours());
                        var mm = parseInt(obj_date.getMinutes());
                        var ss = parseInt(obj_date.getSeconds());

                        if (dd < 10) { dd = "0" + dd; }
                        if (MM < 10) { MM = "0" + MM; }
                        if (hh < 10) { hh = "0" + hh; }
                        if (mm < 10) { mm = "0" + mm; }
                        if (ss < 10) { ss = "0" + ss; }

                        return String(dd + "/" + MM + "/" + yy + " " + hh + ":" + mm + ":" + ss);
                    }),
                    $("<td>").css("text-align", "left").text(aah.PAC_RUT),
                    $("<td>").text(aah.PAC_NOMBRE + " " + aah.PAC_APELLIDO),
                    $("<td>").css("text-align", "center").text(aah.ATE_AÑO + " Años"),
                    $("<td>").css("text-align", "left").text(aah.SEXO_DESC),
                    $("<td>").css("text-align", "left").text(aah.PROC_DESC),
                    $("<td>").text(function () {
                        if (aah.DOC_APELLIDO == null) {
                            aah.DOC_APELLIDO = "";
                        }
                        return String(aah.DOC_NOMBRE + " " + aah.DOC_APELLIDO);
                    })
                ).appendTo("#Dtt_Ate tbody");
                i += 1;
            });
            $("#Dtt_Ate").DataTable({
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
            Hide_Modal();
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <style>
        .modal-lg {
            max-width: 80%;
        }
    </style>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar p-2">
                    <h5>
                        <i class="fa fa-search"></i>
                        Busqueda de Atenciones
                    </h5>
                </div>
                <div class="card-body">
                    <div class="form-row">
                        <div class="col-md">
                            <label for="fecha">Desde:</label>
                            <div class='input-group date' id='Txt_Date01'>
                                <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Desde..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md">
                            <label for="fecha2">Hasta:</label>
                            <div class='input-group date' id='Txt_Date02'>
                                <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Hasta..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md">
                            <label for="Ddl_LugarTM">Lugar de TM:</label>
                            <select id="Ddl_LugarTM" class="form-control">
                            </select>
                        </div>
                        <div class="col-md-2 text-center">
                            <br />
                            <button type="button" id="Btn_Buscar" class="btn btn-buscar mt-2"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                        </div>
                        <div class="col-md-2 text-center">
                            <br />
                            <button id="Btn_Excel" class="btn btn-success mt-2" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i> Excel</button>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg" id="div_hide_">
                            <hr>
                            <h5><i class="fa fa-list fa-fw mr-2"></i>Lista de Atenciones</h5>
                            <div id="Div_Dtt" style="overflow: auto; max-height: 60vh;">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-1"></div>
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>





    <style>
        .manito {
            cursor: pointer;
        }

        td {
            font-size: 12px;
        }

        .image {
            position: absolute;
            top: 50%;
            left: 50%;
            width: 120px;
            height: 120px;
            margin: -60px 0 0 -60px;
            -webkit-animation: spin 2s linear infinite;
            -moz-animation: spin 2s linear infinite;
            animation: spin 2s linear infinite;
        }

        @-moz-keyframes spin {
            100% {
                -moz-transform: rotate(360deg);
            }
        }

        @-webkit-keyframes spin {
            100% {
                -webkit-transform: rotate(360deg);
            }
        }

        @keyframes spin {
            100% {
                -webkit-transform: rotate(360deg);
                transform: rotate(360deg);
            }
        }

        .table th {
            padding: .75rem;
        }
    </style>



</asp:Content>


