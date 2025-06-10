<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Imp_Etiquetas.aspx.vb" Inherits="Presentacion.Imp_Etiquetas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <link href="../css/Custom_Modal.css" rel="stylesheet" />

    <script type="text/javascript">
        function jsDecimals(e) {

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
        //------------------------------------------
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
    </script>

    <script>
        $(document).ready(function () {
            $("#Id_Conte").hide();
            $("#txtNumAte").focus();
            //if (Mx_Dtt[i].ID_ESTADO == 1) {
            //    $("#chekito" + i).prop("checked", true);
            //}


            $("#Btn_Imprimir").hide();

            //var dateNow = moment().format("DD-MM-YYYY");
            //$("#Txt_Date01 input").val(dateNow);
            //$("#Txt_Date02 input").val(dateNow);

            //$('#Txt_Date01').datetimepicker(
            //    {
            //        debug: true,
            //        icons: {
            //            previous: 'fa fa-arrow-left',
            //            next: 'fa fa-arrow-right'
            //        },
            //        format: 'dd-mm-yyyy',
            //        language: 'es',
            //        weekStart: 1,
            //        autoclose: true,
            //        minDate: Date.now(),
            //        minView: 2
            //    }
            //);

            //$('#Txt_Date02').datetimepicker(
            //    {
            //        debug: true,
            //        icons: {
            //            previous: 'fa fa-arrow-left',
            //            next: 'fa fa-arrow-right'
            //        },
            //        format: 'dd-mm-yyyy',
            //        language: 'es',
            //        weekStart: 1,
            //        autoclose: true,
            //        minDate: Date.now(),
            //        minView: 2
            //    }
            //);

            //Registrar evento Click del Botón Buscar       
            $("#Btn_Buscar_Num_Ate").click(function () {

                if ($("#txtNumAte").val() == "") {
                    $("#Div_Tabla").empty();
                    $("#Div_Tabla2").empty();
                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, ingrese un número de atención.");
                    $("#mError_AAH").modal();
                    $("#Btn_Imprimir").hide();

                } else {
                    $("#Div_Tabla").empty();
                    $("#Div_Tabla2").empty();
                    Ajax_DataTable();
                    //Ajax_DataTable2();
                    $("#Btn_Imprimir").show();
                }
            });

            //BUSCAR AL APRETAR ENTER
            $('#txtNumAte').change(function (event) {
                var hola = $('#txtNumAte').val();

                var keycode = event.which;
                if ($("#txtNumAte").val() == "") {
                    $("#Div_Tabla").empty();
                    $("#Div_Tabla2").empty();
                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, ingrese un número de atención.");
                    $("#mError_AAH").modal();
                    $("#Btn_Imprimir").hide();

                } else {
                    $("#Div_Tabla").empty();
                    $("#Div_Tabla2").empty();
                    Ajax_DataTable();
                    //Ajax_DataTable2();
                    $("#Btn_Imprimir").show();
                }

                var keycode = event.which;

            });

            $("#Btn_Imprimir").click(function () {
                selected = new Array();
                $("input:checkbox:checked").each(function () {
                    selected.push($(this).val());
                });
                if (selected == 0) {
                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione a lo menos uno.");
                    $("#mError_AAH").modal();
                } else {

                    AJAX_REQ();
                    $("#Btn_Imprimir").show();
                }
            });

        });
    </script>
    <script>
        var Mx_Dtt = [
            {
                "ID_ATENCION": 0,
                "ATE_AÑO": 0,
                "PAC_NOMBRE": 0,
                "PAC_RUT": 0,
                "PAC_APELLIDO": 0,
                "ID_SEXO": 0,
                "SEXO_COD": 0,
                "PROC_DESC": 0,
                "PROC_COD": 0,
                "PAC_FNAC": 0
            }
        ];

        function Ajax_DataTable() {
            modal_show();


            var Data_Par = JSON.stringify({
                "NUM_ATE": $("#txtNumAte").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Imp_Etiquetas.aspx/IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        $("#Id_Conte").show();

                        var procee = Galletas.getGalleta("USU_TM");

                        var admin = Galletas.getGalleta("P_ADMIN");

                        if (admin == 1) {
                            Fill_DataTable();
                            Ajax_DataTable2();
                        } else {
                            if (procee == Mx_Dtt[0].PROC_ID) {

                                Fill_DataTable();
                                Ajax_DataTable2();
                            } else {
                                $("#Id_Conte").hide();
                                $("#mError_AAH h4").text("Sin resultados");
                                $("#mError_AAH button").attr("class", "btn btn-danger");
                                $("#mError_AAH p").text("No se han encontrado resultados");
                                $("#mError_AAH").modal();
                            }
                        }
                        Hide_Modal();


                    } else {


                        Hide_Modal();
                        $("#Id_Conte").hide();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
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
        "ID_T_MUESTRA": 0,
        "ATE_NUM": 0,
        "T_MUESTRA_DESC": 0,
        "CB_DESC": 0,
        "Expr1": 0,
        "ID_ATENCION": 0,
        "GMUE_DESC": 0,
        "ATE_FECHA": 0,
        "PAC_RUT": 0,
        "PAC_NOMBRE": 0,
        "PAC_APELLIDO": 0,
        "PROC_DESC": 0
    }
        ];

        function Ajax_DataTable2() {
            modal_show();


            var Data_Par = JSON.stringify({
                "NUM_ATE": $("#txtNumAte").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Imp_Etiquetas.aspx/IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt2 = JSON.parse(json_receiver);

                        Fill_DataTable2();
                        Hide_Modal();


                    } else {


                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados.");
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

        //function Ajax_Print() {
        //    modal_show();


        //    var Data_Par = JSON.stringify({
        //        "NUM_ATE": Mx_Dtt2[0].ATE_NUM
        //    });
        //    $(".block_wait").fadeIn(500);
        //    $.ajax({
        //        "type": "POST",
        //        "url": "Imp_Etiquetas.aspx/IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2_2",
        //        "data": Data_Par,
        //        "contentType": "application/json;  charset=utf-8",
        //        "dataType": "json",
        //        "success": function (response) {
        //            var json_receiver = response.d;
        //            if (json_receiver != "null") {
        //                // no se que vamos a poner acá

        //                Hide_Modal();


        //            } else {


        //                Hide_Modal();

        //            }
        //            $("#Id_Conte").show();
        //            $(".block_wait").fadeOut(500);
        //        },
        //        "error": function (response) {
        //            var str_Error = response.responseJSON.ExceptionType + "\n \n";
        //            str_Error = response.responseJSON.Message;
        //            alert(str_Error);



        //        }S
        //    });
        //}
    </script>

    <script>
        function AJAX_REQ() {
            //var dataParam = JSON.stringify(Mx_Dtt2[0].ID_ATENCION
            //    //"ID_CB": selected
            //});

            var dataParam = JSON.stringify([{
                ID_ATE: Mx_Dtt2[0].ID_ATENCION,
                Cod_Barra: (function () {
                    let arr = [];
                    let chekito = $(`input[name=chekito]:checked`);

                    chekito.each((i, elem) => {
                        arr.push(elem.value);
                    });

                    return arr;
                }())
            }]);

            var REE = $.ajax({
                "type": "POST",
                "url": "http://localhost:9990/Printer/Imp_Etiquetas_Cod_Barra",
                //"url": "http://localhost:9990/Printer/Imp_Voucher_Agendam",
                "data": dataParam,
                "contentType": "application/json;  charset=utf-8",
                "contentType": "text/plain;  charset=utf-8",
                "dataType": "json",
                "timeout": 15000,
                "success": function (response) {




                    var str_Error = "La impresión se ha completado exitosamente."


                    $("#mError_AAH h4").text("Impresión Correcta");
                    $("#mError_AAH button").attr("class", "btn btn-success");
                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();
                },
                "error": function (response) {


                    var str_Error = "No se a detectado ninguna interface de impresión abierta. Abra IRISLAB_PRINT" // o de lo contrario descargelo AQUI
                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();

                }
            });
        };





        //---------------------------------------------------- TABLA PACIENTE -------------------------------------------------|
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
                    $("<th>", { "class": "textoReducido" }).text("Rut"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar de TM")

                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_RUT),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PROC_DESC)
                    )
                );
            }
        }
        //---------------------------------------------------- TABLA ETIQUETA -------------------------------------------------|
        function Fill_DataTable2() {
            $("<table>", {
                "id": "DataTable2",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla2");

            $("#DataTable2").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable2").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable2 thead").attr("class", "cabezera2");
            $("#DataTable2 thead").append(
                $("<tr>").append(
                $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Barra"),
                    $("<th>", { "class": "textoReducido" }).text("Tipo de Muestra"),
                    $("<th>", { "class": "textoReducido" }).text("Color Tubo"),
                    //$("<th>", { "class": "textoReducido" }).text("Sección"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Imprimir")
                    //$("<th>", { "class": "textoReducido" }).text("Cantidad")

                )
            );

            for (i = 0; i < Mx_Dtt2.length; i++) {
                $("#DataTable2 tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt2[i].ATE_NUM),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt2[i].ATE_FECHA),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt2[i].CB_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt2[i].T_MUESTRA_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt2[i].GMUE_DESC),
                        //$("<td>", { "align": "left" }, { "class": "textoReducido" }).text(""),
                        $("<td>", { "align": "center" }).append($('<input/>', { 'type': 'checkbox', 'name': 'chekito', 'checked': 'true', 'value': Mx_Dtt2[i].CB_DESC, 'class': `checkbox checkbox-success` }))
                        //$("<td>", { "align": "left" }, { "class": "textoReducido" }).text("")
                    )
                );
                //$("#chekito").prop("checked", true);
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
            background: #46963f;
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
            height: 70px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .highlights2 {
            width: 710px;
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
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <%------------------------------------------------------TÍTULO, TEXTBOX Y BOTONES-----------------------------------------%>


    <div class="card border-bar">
    <div class="card-header bg-bar">
        <h5 style="text-align: center; padding: 5px;">
            <i class="fa fa-print"></i>
            Impresión de Etiquetas
        </h5>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">

            <div class="row" style="margin-top: 15px;">
                <div class="col-lg-4">

                    <label for="txtNumAte">Número de Atención:</label>
                    <input id="txtNumAte" maxlength="9" class="form-control textoReducido" type="text" placeholder="BUSCAR..." onkeydown="return jsDecimals(event);" />
                </div>

                <%--                        <div class="col-4 form-group flx">
                            <label for="fecha">Desde:</label>
                            <div class='input-group date' id='Txt_Date01'>
                                <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Desde..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-4 form-group flx">
                            <label for="fecha2">Hasta:</label>
                            <div class='input-group date' id='Txt_Date02'>
                                <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Hasta..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-4 form-group flx">
                            <label for="DllSeccion">Sección:</label>
                            <select id="Ddl_LugarTM" class="form-control">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <button id="Btn_Buscar" class="btn btn-primary btn-block" style="margin-bottom: 1vh; margin-left: 3px; margin-right: 3px; padding: 3px;" type="submit">Buscar</button>--%>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <button id="Btn_Buscar_Num_Ate" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; margin-right: 3px; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                </div>
            </div>

            <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
            <div class="row" id="Id_Conte">
                <div class="col-md-12" id="Paciente">

                    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-print"></i>Impresión de etiquetas</h5>
                    <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
                    <div id="Div_Tabla2" style="width: 100%;" class="highlights2"></div>

                    <button id="Btn_Imprimir" class="btn btn-print btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-print mr-2"></i>Imprimir</button>
                </div>
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>
            </div>
</asp:Content>
