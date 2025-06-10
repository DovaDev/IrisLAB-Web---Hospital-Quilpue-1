<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Lis_Recha_Mues.aspx.vb" Inherits="Presentacion.Lis_Recha_Mues" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script>
        $(document).ready(function () {
            Ajax_LugarTM();
            $("#Id_Conte").hide();

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
                $("#Div_Tabla").empty();
                Ajax_DataTable();

            });
            //Registrar evento Click del Botón Excel       
            $("#Btn_Excel").click(function () {
                Ajax_Excel();

            });
            Btn_Excel
        });
    </script>
    <script>
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
            modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_Recha_Mues.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_LugarTM = JSON.parse(json_receiver);
                        Fill_Ddl_LugarTM();
                        Hide_Modal();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
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

        //-------------------------------------------------- AJAX TABLA MAIN ----------------------------------------------|
        var Mx_Dtt = [
            {
                "LOTE_RECHAZO_NUM": 0,
                "ID_ATENCION": 0,
                "RECEP_ETI_CURVA_RECHAZO": 0,
                "RECEP_ETI_NUM_ATE_RECHAZO": 0,
                "ID_USUARIO": 0,
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
                "USU_NIC": 0,
                "RECEP_ETI_RECHAZO_OBS": 0,
                "ATE_DIA": 0,
                "SEXO_DESC": 0,
                "PAC_RUT": 0,
                "PAC_FNAC": 0,
                "ATE_NUM": 0,
                "ATE_NUM_INTERNO": 0,
                "ATE_DNI": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "ID_PROCEDENCIA": 0,
                "NAC_DESC": 0,
                "PROGRA_DESC": 0,
                "SECTOR_DESC": 0,
                "TP_RECHA_DESC": 0
            }
        ];

        function Ajax_DataTable() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PRE": $("#Ddl_LugarTM").val(),
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_Recha_Mues.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        $("#Div_Tabla").empty();

                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].RECEP_ETI_FECHA_RECHAZO;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].RECEP_ETI_FECHA_RECHAZO = Date_Change;
                        }

                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].PAC_FNAC;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].PAC_FNAC = Date_Change;
                        }
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
                "ID_PRE": $("#Ddl_LugarTM").val(),
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_Recha_Mues.aspx/Excel",
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

    </script>
    <script>
        //Llenar DropDownList Lugar de TM
        function Fill_Ddl_LugarTM() {
            $("#Ddl_LugarTM").empty();
            var procee = Galletas.getGalleta("P_ADMIN");
            if (procee == 2) {
                $("<option>",
                    {
                        "value": "0"
                    }
                ).text("Todos").appendTo("#Ddl_LugarTM");
                Mx_Dtt_LugarTM.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                });
            }
            else {
                //var picoo = Galletas.getGalleta("USU_ID_PROC");
                //if (picoo == 0) {
                Mx_Dtt_LugarTM.forEach(aaa => {

                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");

                });
                //} 
                //else {
                //Mx_Dtt_LugarTM.forEach(aaa => {
                //    if (pico == aaa.ID_PROCEDENCIA) {
                //        $("<option>",
                //    {
                //        "value": aaa.ID_PROCEDENCIA
                //    }
                // ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                //    }
                //});
                //}

            }

        };
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
                    $("<th>", { "class": "textoReducido text-center" }).text("#"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Número Atención"),
                    //$("<th>", { "class": "textoReducido text-center" }).text("Num Interno"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Rut o DNI"),
                    //$("<th>", { "class": "textoReducido text-center" }).text("DNI"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Nac"),
                    $("<th>", { "class": "textoReducido" }).text("Edad"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Nacionalidad"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Etiqueta"),
                    $("<th>", { "class": "textoReducido" }).text("Examen Fonasa"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Descripción Sección"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Motivo"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Observación"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Estado"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Hora"),
                    $("<th>", { "class": "textoReducido" }).text("Folio"),
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Lote"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Usuario"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Lugar de TM"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Programa"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Sector"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Médico")

                )
            );


            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ATE_NUM),
                        //$("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ATE_NUM_INTERNO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt[i].PAC_RUT == "") {
                                return Mx_Dtt[i].ATE_DNI;
                            } else {
                                return Mx_Dtt[i].PAC_RUT;
                            }
                        }),
                        //$("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ATE_DNI),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt[i].PAC_FNAC);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);

                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ATE_AÑO + " Años"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].NAC_DESC),
                        $("<td>").css("text-align", "center").text(function () {
                            $(this).css("cssText", "text-align:center;").text("[" + Mx_Dtt[i].RECEP_ETI_CURVA_RECHAZO + "]" + " " + Mx_Dtt[i].T_MUESTRA_DESC);
                        }),
                        $("<td>").text(function () {
                            $(this).text(Mx_Dtt[i].CF_DESC);
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt[i].RLS_LS_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].TP_RECHA_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].RECEP_ETI_RECHAZO_OBS),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            $(this).css("cssText", "background-color:#f5b0e5 !important;  text-align:center;").text(Mx_Dtt[i].EST_DESCRIPCION);

                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt[i].RECEP_ETI_FECHA_RECHAZO);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);

                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date2 = new Date(Mx_Dtt[i].RECEP_ETI_FECHA_RECHAZO);
                            var hh = parseInt(obj_date2.getHours());
                            var mm = parseInt(obj_date2.getMinutes());
                            var ss = parseInt(obj_date2.getSeconds());

                            if (hh < 10) { hh = "0" + hh; }
                            if (mm < 10) { mm = "0" + mm; }
                            if (ss < 10) { ss = "0" + ss; }

                            return String(hh + ":" + mm + ":" + ss);
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].RECEP_ETI_NUM_ATE_RECHAZO),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt[i].LOTE_RECHAZO_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].USU_NIC),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PROC_DESC),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PROGRA_DESC),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt[i].SECTOR_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DOC_NOMBRE + " " + Mx_Dtt[i].DOC_APELLIDO)
                    )
                );

            }

        }

    </script>

    <style>
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
            max-height: 60vh; /* Ancho y alto fijo */
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
    <%--//---------------------------------------------- MODAL LISTADO DE EXÁMENES DE LA ATENCIÓN ------------------------------------%>
    <div class="modal fade" id="eModal" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Listado de Recepción de Exámenes</h4>
                </div>
                <div class="modal-header">
                    <div class="col">
                        <h6 class="modal-title" id="numerito">num ATEEE</h6>
                        <h6 class="modal-title" id="nombrecito">Nombreee</h6>
                    </div>
                </div>
                <div class="modal-body">
                    <form>
                        <div id="Div_Tabla_Listado_Exa_Ate" style="width: 100%;" class="table-responsive"></div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Salir</button>
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
        <div class="col-lg"> 
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar">
                    <h5 style="text-align: center; padding: 5px;">
                    <i class="fa fa-edit"></i>
                    Listado de Exámenes Rechazados
                    </h5>
                </div>
            <div class="row mb-3" style="margin-left:2px; margin-right: 2px;">
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
                    <label>Lugar de TM:</label>
                    <select id="Ddl_LugarTM" class="form-control"></select>
                </div>
            </div>
            <div class="row" style="margin-left:2px; margin-right: 2px;">
                <div class="col-md">
                    <button id="Btn_Buscar" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i> Buscar</button>
                </div>   
                <div class="col-md">
                    <button id="Btn_Excel" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i> Excel</button>
                </div>
            </div>
            <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
            <div class="row" id="Id_Conte">
                <div class="col-md-12" id="Paciente">
                    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i>Listado de Muestras Rechazadas</h5>
                    <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
                </div>
            </div>
            </div>
        </div>
    </div>
</asp:Content>