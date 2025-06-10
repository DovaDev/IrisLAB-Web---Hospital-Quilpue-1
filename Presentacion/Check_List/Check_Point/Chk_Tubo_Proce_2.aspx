<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Chk_Tubo_Proce_2.aspx.vb" Inherits="Presentacion.Chk_Tubo_Proce_2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%--<link href="../css/Custom_Modal.css" rel="stylesheet" />--%>
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script>

        $(document).ready(function () {
            $("#Id_Conte").hide();
            Ajax_LugarTM();
            //Ajax_Seccion();

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
            $.ajax({
                "type": "POST",
                "url": "Chk_Tubo_Proce_2.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_LugarTM = JSON.parse(json_receiver);
                        Fill_Ddl_LugarTM();
                        console.log("FILL");
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

        //-------------------------------------------------- AJAX TABLA MAIN ----------------------------------------------|
        var Mx_Dtt = [
            {
                "ATE_NUM": 0,
                "T_MUESTRA_DESC": 0,
                "CB_DESC": 0,
                "GMUE_DESC": 0,
                "ATE_FECHA": 0,
                "PAC_RUT": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "ATE_NUM_INTERNO": 0,
                "PROC_DESC": 0
            }
        ];

        function Ajax_DataTable() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PRE": $("#Ddl_LugarTM").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Chk_Tubo_Proce_2.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        $("#Div_Tabla").empty();

                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].ATE_FECHA = Date_Change;
                        }

                        $("#lblTotal").text(Mx_Dtt.length);

                        Fill_DataTable();
                        Hide_Modal();

                        $("#Id_Conte").show();
                    } else {

                        Hide_Modal();
                        $("#lblTotal").text("0");
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                        $("#Id_Conte").hide();
                    }
                },
                "error": function (response) {
                    Hide_Modal();
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
                "ID_PRE": $("#Ddl_LugarTM").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Chk_Tubo_Proce_2.aspx/Excel",
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
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>

    <%-- Funciones de Llenado de Elementos --%>
    <script>
        //Llenar DropDownList Lugar de TM
        function Fill_Ddl_LugarTM() {
            $("#Ddl_LugarTM").empty();
            var procee = Galletas.getGalleta("USU_ID_PROC");
            if (procee == 0) {
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
                Mx_Dtt_LugarTM.forEach(aaa => {
                    if (aaa.ID_PROCEDENCIA == procee) {
                        $("<option>",
                          {
                              "value": aaa.ID_PROCEDENCIA
                          }
                        ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                    }
                });
            }
        };

    </script>
    <script>
        //------------------------------------------------------------------------------------ TABLA  -----------------------------------------------------------------------------------------------------|
        function Fill_DataTable() {
            // Crear la tabla y agregarla al contenedor
            const $table = $("<table>", {
                id: "DataTable",
                class: "table table-hover table-striped table-iris display",
                width: "100%",
                cellspacing: "0"
            });
            $("#Div_Tabla").append($table);

            // Crear elementos thead y tbody
            const $thead = $("<thead>", { class: "cabezera" });
            const $tbody = $("<tbody>");
            $table.append($thead, $tbody);

            // Construir la fila de encabezado
            const $headerRow = $("<tr>").append(
                $("<th>", { class: "textoReducido" }).text("#"),
                $("<th>", { class: "textoReducido text-center" }).text("N° Atención"),
                $("<th>", { class: "textoReducido" }).text("Num. Interno"),
                $("<th>", { class: "textoReducido text-center" }).text("Fecha"),
                $("<th>", { class: "textoReducido text-center" }).text("Etiqueta"),
                $("<th>", { class: "textoReducido text-center" }).text("Color Tubo"),
                $("<th>", { class: "textoReducido" }).text("Rut Paciente"),
                $("<th>", { class: "textoReducido" }).text("Nombre Paciente"),
                $("<th>", { class: "textoReducido" }).text("Lugar TM")
            );
            $thead.append($headerRow);

            // Construir el HTML para todas las filas de la tabla
            let rowsHtml = "";
            for (let i = 0, len = Mx_Dtt.length; i < len; i++) {
                const row = Mx_Dtt[i];
                const formattedDate = moment(row.ATE_FECHA).format("DD/MM/YYYY");
                rowsHtml += `
            <tr>
                <td align="left" class="textoReducido">${i + 1}</td>
                <td align="center" class="textoReducido">${row.ATE_NUM}</td>
                <td align="left" class="textoReducido">${row.ATE_NUM_INTERNO}</td>
                <td align="center" class="textoReducido">${formattedDate}</td>
                <td align="center" class="textoReducido">[${row.CB_DESC}] - ${row.T_MUESTRA_DESC}</td>
                <td align="center" class="textoReducido">${row.GMUE_DESC}</td>
                <td align="left" class="textoReducido">${row.PAC_RUT}</td>
                <td align="left" class="textoReducido">${row.PAC_NOMBRE} ${row.PAC_APELLIDO}</td>
                <td align="left" class="textoReducido">${row.PROC_DESC}</td>
            </tr>`;
            }
            $tbody.html(rowsHtml);

            // Inicializar DataTables para agregar paginación y otras funcionalidades
            $table.DataTable({
                paging: true,         // Activa la paginación
                pageLength: 25,       // Número de registros por página (ajusta según tus necesidades)
                lengthChange: false,  // Opcional: oculta la opción para cambiar la cantidad de registros por página
                searching: true,      // Activa el buscador
                ordering: true,       // Permite el ordenamiento de columnas
                info: true,           // Muestra información de la tabla
                autoWidth: false      // Desactiva el ajuste automático de ancho de columnas
                // Puedes agregar opciones de idioma u otras configuraciones según lo requieras
            });
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
            height: 404px;
            overflow: auto;
        }

        .highlights2 {
            width: 710px;
            height: 404px;
            overflow: auto;
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
        <div class="col-lg">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar">
        <h5 style="text-align: center; padding: 5px;">
            <i class="fa fa-edit"></i>
            Listado de Tubos por Procedencia
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
            <label for="Ddl_LugarTM">Lugar de TM:</label>
            <select id="Ddl_LugarTM" class="form-control">
                <option value="0">Seleccionar</option>
            </select>
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
            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list"></i>Listado de Muestras</h5>
            <div class="row" style="font-size: 15px;">
                <div class="col-md-2">
                    <label>TOTAL: </label>
                    <b>
                        <label id="lblTotal" class="text-primary">0</label></b>
                </div>
            </div>
            <div id="Div_Tabla" style="width: 100%; max-height: 55vh; overflow: auto"></div>
        </div>
    </div>
    </div>
    </div>
    </div>
</asp:Content>
