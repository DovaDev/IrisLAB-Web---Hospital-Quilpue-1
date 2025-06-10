<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Lis_OC_Sed.aspx.vb" Inherits="Presentacion.Lis_OC_Sed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script>

        var valor = 2;

        $(document).ready(function () {
            $("#Id_Conte").hide();
            $("#Btn_Marcar").hide();
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


            var dateNow = moment().format("DD-MM-YYYY");
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

            $(".block_wait").fadeOut(0);
            $("#Div_Tabla").empty();
            $("#Div_Tabla").show();
            $("#Id_Conte").hide();

            //Registrar evento Click del Botón Buscar       
            $("#Btn_Buscar").click(function () {

                if ($('#Chk_Pendientes').is(':checked')) {
                    valor = 1;
                    $("#Div_Tabla").empty();

                    Ajax_DataTable();
                } else if (($('#Chk_Todos').is(':checked'))) {
                    valor = 0;
                    $("#Div_Tabla").empty();
                    Ajax_DataTable();

                } else {
                    $("#mError_AAH h4").text("Sin Selección");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("No se ha seleccionado ningun tipo.");
                    $("#mError_AAH").modal();
                }
            });

            //AJAX GUARDAR EN EL MODAL MARCAR
            $("#Btn_Imprimir").click(function () {
                selected = new Array();
                $("input:checkbox:checked").each(function () {
                    selected.push($(this).val());
                });
                if (selected == 0) {
                    $("#mError_AAH h4").text("Sin Selección");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("No se ha marcado ninguno.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_PDF();
                }

            });

            //Registrar evento Click del Botón Excel       
            $("#Btn_Excel").click(function () {
                Ajax_Excel();

            });

            $("#Btn_Marcar").click(function () {
                $("#Btn_Marcar").hide();
                $("#Btn_Desmarcar").show();
                $(".checkBoxClass").prop('checked', true);

            });

            $("#Btn_Desmarcar").click(function () {
                $("#Btn_Desmarcar").hide();
                $("#Btn_Marcar").show();
                $(".checkBoxClass").prop('checked', false);
            });


            $("#Chk_Pendientes").prop("checked", true);
            $("#Btn_Desmarcar").hide();
        });
    </script>
    <script>

        //-------------------------------------------------- AJAX TABLA MAIN ----------------------------------------------|
        var Mx_Dtt = [
            {
                "ID_ATENCION": 0,
                "ATE_NUM": 0,
                "ATE_FECHA": 0,
                "ID_PACIENTE": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "ATE_AÑO": 0,
                "SEXO_DESC": 0,
                "ID_SEXO": 0,
                "ID_PROCEDENCIA": 0,
                "ID_ESTADO": 0,
                "PROC_DESC": 0,
                "ID_NACIONALIDAD": 0,
                "ID_ORDEN": 0,
                "ID_TP_PACI": 0,
                "CF_DESC": 0,
                "CF_CORTO": 0,
                "ATE_DET_V_ID_ESTADO": 0,
                "PAC_RUT": 0
            }

        ];
        var fechas = [];

        function Ajax_DataTable() {
            modal_show();


            var Data_Par = JSON.stringify({
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "seleccion": valor
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_OC_Sed.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        $("#Div_Tabla").empty();

                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            fechas[i] = Mx_Dtt[i].ATE_FECHA
                            var date_x = Mx_Dtt[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].ATE_FECHA = Date_Change;
                        }

                        $("#Btn_Marcar").show();
                        $("#Btn_Desmarcar").hide();
                        Fill_DataTable();
                        Hide_Modal();


                        $("#Id_Conte").show();
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

        var Mx_Dtt_Excel = [
    {
        "urls": ""
    }
        ];

        function Ajax_Excel() {
            modal_show();


            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "seleccion": valor
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_OC_Sed.aspx/Excel",
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

        var Mx_Dtt_PDF = [
{
    "urls": ""
}
        ];

        function Ajax_PDF() {
            modal_show();


            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "seleccion": valor,
                "selected": selected
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_OC_Sed.aspx/PDF",
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
                    //alert(str_Error);
                    Hide_Modal();
                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Se ha producido un error: " + str_Error);
                    $("#mError_AAH").modal();


                }
            });
        }

    </script>

    <script>

        //---------------------------------------------------- TABLA  ------------------.........-----------------------------|
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
            $("#DataTable thead").attr("class", "cabezera");
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Datos"),
                    $("<th>", { "class": "textoReducido" }).text("C.EPI"),
                    $("<th>", { "class": "textoReducido" }).text("LEUCO"),
                    $("<th>", { "class": "textoReducido" }).text("ERITRO."),
                    $("<th>", { "class": "textoReducido" }).text("BACT"),
                    $("<th>", { "class": "textoReducido" }).text("MUCUS"),
                    $("<th>", { "class": "textoReducido" }).text("CRIST."),
                    $("<th>", { "class": "textoReducido" }).text("CILIN"),
                    $("<th>", { "class": "textoReducido" }).text("OTROS 1"),
                    $("<th>", { "class": "textoReducido" }).text("OTROS 2"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Imprimir"),
                    $("<th>", { "class": "textoReducido" }).text("ID")

                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt[i].ATE_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            fechas[i] = dd + "/" + mm + "/" + yy;
                            return String(dd + "/" + mm + "/" + yy + " " + "folio: " + Mx_Dtt[i].ATE_NUM);

                            $("#DataTable tbody").append(
                                $("<tr>").append(
                                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO)

                                )
                            );

                        }),

                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("C.EPI"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("LEUCO."),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("ERITRO."),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("BACT"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("MUCUS"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("CRIST."),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("CILIN"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("OTROS 1"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("OTROS 2"),
                        $("<td>").css("text-align", "center").text(function () {
                            $(this).html("<input type='checkbox' class='checkBoxClass' id='chekito" + i + "' value='" + fechas[i] + "~" + Mx_Dtt[i].ATE_NUM + "~" + Mx_Dtt[i].PAC_NOMBRE + "~" + Mx_Dtt[i].PAC_APELLIDO + "~" + Mx_Dtt[i].ATE_AÑO + "~" + Mx_Dtt[i].CF_CORTO + "~" + Mx_Dtt[i].PAC_RUT + "'/>")
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ID_ATENCION)
                    )
                );

                $("#DataTable tbody").append(
                                    $("<tr>").append(
                                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(""),
                                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO)

                                    )
                                );

                $("#DataTable tbody").append(
                                    $("<tr>").append(
                                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(""),
                                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("Rut: " + Mx_Dtt[i].PAC_RUT + " Edad: " + Mx_Dtt[i].ATE_AÑO + " " + " Examen:" + " " + Mx_Dtt[i].CF_CORTO)

                                    )
                                );

                $("#DataTable tbody").append(
                                    $("<tr>").append(
                                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("")

                                    )
                                );
            }
        }

    </script>

    <style>
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

        .progress-bar.animate {
            width: 100%;
        }

        #DataTable tbody td {
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

        .mayus {
            text-transform: uppercase;
        }

        .highlights {
            width: 90%;
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

        @media screen and (max-width: 600px) {
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

            #Btn_Buscar_x_ate {
                width: 90vw;
                margin-left: -12px;
            }
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <!-- Modal -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
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
    <%------------------------------------------------------TÍTULO, TEXTBOX Y BOTONES-----------------------------------------%>
        <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar">
        <h5 style="text-align: center; padding: 5px;">
            <i class="fa fa-edit"></i>
            Búsqueda Orina y Sedimento
        </h5>
    </div>
    <div class="row" style="margin-left:2px; margin-right: 2px;">
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
            <label for="fecha">Hasta:</label>
            <div class='input-group date' id='Txt_Date02'>
                <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Desde..." />
                <span class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </span>
            </div>
        </div>
        <div class="col-md">
            <form action="">
                <br />
                <label for="Chk_Pendientes">Pendientes:</label>
                <input type="radio" name="gender" value="1" id="Chk_Pendientes"><br />
                <label for="Chk_Todos">Todos:</label>
                <input type="radio" name="gender" value="0" id="Chk_Todos">
            </form>
        </div>
        <div class="col-md">
            <br />
            <button id="Btn_Marcar" class="btn btn-info btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit">Marcar Todos</button>
            <button id="Btn_Desmarcar" class="btn btn-dark btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit">Desmarcar Todos</button>
        </div>
        <div class="col-md">
            <br />
            <button id="Btn_Imprimir" class="btn btn-print btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-print mr-2"></i>Imprimir</button>
        </div>
    </div>
    <div class="row" style="margin-left:2px; margin-right: 2px;">
        <div class="col-md">
            <button id="Btn_Buscar" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
        </div>
        <div class="col-md">
            <button id="Btn_Excel" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>

        </div>
    </div>



    <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
    <div class="row" id="Id_Conte">
        <div class="col-md-12" id="Paciente">
            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i>Listado de Atenciones</h5>
            <div id="Div_Tabla" style="width: 100%; overflow:auto; max-height:60vh" ></div>
        </div>
    </div>
    </div>
    </div>
    <div class="col-lg-1"></div>
    </div>
</asp:Content>
