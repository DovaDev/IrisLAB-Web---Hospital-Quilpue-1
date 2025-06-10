<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Est_Result_Examen.aspx.vb" Inherits="Presentacion.Est_Result_Examen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <script type="module">
        import fetcher from '../../js/es6-modules/Fetcher.js';
        import fillPrevisiones from '../js/es6-modules/Previsiones.js';
        import fillExamenesPorPrevision from '../../js/es6-modules/Examenes.js';
        import fillDeterminaciones from '../../js/es6-modules/Determinaciones.js';
        import fillProcedencias from '../js/es6-modules/Procedencias.js';

        let table;
        let datosDatatable = [];
        //------------------------------------------------ FETCH TABLA PRINCIPAL -------------------------------------------|
        const Fetch_DataTable = async () => {
            modal_show();
            $(".block_wait").fadeIn(500);
            const body = {
                desde: $("#txtDesde").val(),
                hasta: $("#txtHasta").val(),
                idProcedencia: $("#ddlProcedencia").val(),
                idPrevision: $("#ddlPrevision").val(),
                idCodigoFonasa: $("#ddlExamen").val(),
                idDeterminacion: $("#ddlDeterminacion").val(),
            };
            const afterFetch = res => {
                console.log(res)
                if (res.length > 0) {
                    Fill_DataTable(res);
                    return;
                }
                table && table.destroy();
                $("#Div_Tabla").empty();
            }

            await fetcher("Est_Result_Examen.aspx/Fetch_Datatable", { method: 'POST', body, afterResOk: afterFetch });
            Hide_Modal();
            $(".block_wait").fadeOut(500);
        }
        //---------------------------------------------- FILL TABLA PRINCIPAL  ---------------------------------------------|
        const Fill_DataTable = (datos = datosDatatable) => {
            table && table.destroy();
            $("#Div_Tabla").empty();
            $("<table>", {
                id: "DataTable",
                class: "table table-hover table-striped table-iris",
                width: "100%",
                cellspacing: "0"
            }).appendTo("#Div_Tabla");

            $("#DataTable").append(
                $("<thead>", { class: "cabezera" }),
                $("<tbody>")
            );
            const thClass = "textoReducido text-right";
            const thCLeft = "textoReducido text-left";
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { class: thClass }).text("#"),
                    $("<th>", { class: thCLeft }).text("N° Ate."),
                    $("<th>", { class: thCLeft }).text("Fecha"),
                    $("<th>", { class: thCLeft }).text("RUT"),
                    $("<th>", { class: thCLeft }).text("Paciente"),
                    $("<th>", { class: thClass }).text("Sexo"),
                    $("<th>", { class: thClass }).text("Edad"),
                    $("<th>", { class: thClass }).text("Procedencia"),
                    $("<th>", { class: thClass }).text("Examen"),
                    $("<th>", { class: thClass }).text("Prueba"),
                    $("<th>", { class: thClass }).text("Resultado"),
                )
            );
            const tdCLeft = "textoReducido text-left";
            const tdClass = "textoReducido text-right";
            const tdStyle = "white-space: nowrap;"
            datos.forEach((item, i) => {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { class: tdClass, style: tdStyle }).text(i + 1),
                        $("<td>", { class: tdCLeft, style: tdStyle }).text(item.ATE_NUM),
                        $("<td>", { class: tdCLeft, style: tdStyle }).text(item.ATE_FECHA),
                        $("<td>", { class: tdCLeft, style: tdStyle }).text(item.PAC_RUT),
                        $("<td>", { class: tdCLeft, style: tdStyle }).text(item.NOMBRE_COMPLETO),
                        $("<td>", { class: tdClass, style: tdStyle }).text(item.SEXO_DESC),
                        $("<td>", { class: tdClass, style: tdStyle }).text(item.ATE_AÑO),
                        $("<td>", { class: tdClass, style: tdStyle }).text(item.PROC_DESC),
                        $("<td>", { class: tdClass, style: tdStyle }).text(item.CF_DESC),
                        $("<td>", { class: tdClass, style: tdStyle }).text(item.PRU_DESC),
                        $("<td>", { class: tdClass, style: tdStyle }).text(item.ATE_RESULTADO)
                    )
                );
            });
            //table = $("#DataTable").DataTable({
            //    bSort: false,
            //    iDisplayLength: 25,
            //    info: false,
            //    paging: false,
            //    language,
            //    scrollX: true
            //});
            //$("#DataTable_filter input")
            //    .addClass("border border-primary bg-white")
            //    .attr({ placeholder: "Buscar...", style: "max-width: 145px;" });
        }

        const Fetch_Excel = () => {
            modal_show();
            $(".block_wait").fadeIn(500);
            const body = {
                DOMAIN_URL: location.origin,
                desde: $("#txtDesde").val(),
                hasta: $("#txtHasta").val(),
                idProcedencia: $("#ddlProcedencia").val(),
                idPrevision: $("#ddlPrevision").val(),
                idCodigoFonasa: $("#ddlExamen").val(),
                idDeterminacion: $("#ddlDeterminacion").val(),
            }
            const afterResOk = (res) => {
                let xURL = "";
                xURL = res;
                if (xURL != null) {
                    if (xURL.match(/^http(s?):\/\//gi) == null) {
                        xURL = "http://" + xURL;
                    }
                    $("#mdlExcel .modal-body").html(`<p>Se ha generado correctamente el archivo excel. Si no se ha iniciado la descarga pulse <a href="${xURL}">aquí</a>.</p>`);
                    window.open(xURL, "_blank");
                } else {
                    $("#mdlExcel .modal-body").html(`<p>No se ha generado ningún archivo debido a que la búsqueda no retorna resultados.</p>`);
                }
                $("#mdlExcel").modal();
                Hide_Modal();
            }
            const afterCatch = res => alert(res.responseJSON.ExceptionType + "\n \n" + res.responseJSON.Message);
            fetcher("Est_Result_Examen.aspx/Excel", { afterResOk, afterCatch, body, method: "POST" });
        }

        // DOM READY @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // DOM READY @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        modal_show();

        const dateNow = new Date(Date.now());
        $("#txtDesde, #txtHasta").val(dateNow.toISOString().substr(0, 10));

        await fillProcedencias({ idSelect: "ddlProcedencia", placeholder: true });
        await fillPrevisiones({ idSelect: "ddlPrevision", placeholder: true });
        await fillExamenesPorPrevision("ddlExamen", $("#ddlPrevision").val());

        Hide_Modal();

        $("#ddlPrevision").change(() => fillExamenesPorPrevision("ddlExamen", $("#ddlPrevision").val()));

        $("#ddlExamen").change(() => fillDeterminaciones("ddlDeterminacion", $("#ddlExamen").val()));

        $("#Btn_Buscar").click(() => Fetch_DataTable());

        $("#Btn_Excel").click(() => Fetch_Excel());

        // DOM READY @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // DOM READY @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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

        .negrin {
            font-weight: 900;
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
                        Resultados por Determinación
                    </h5>
                </div>

                <div class="row mb-3" style="margin-left: 2px; margin-right: 2px;">



                    <%--<div class="col-md">
                        <label for="txtDesde">Desde:</label>
                        <div class='input-group date' id='datepickerDesde'>
                            <input type='text' id="txtDesde" class="form-control" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-md">
                        <label for="txtHasta">Hasta:</label>
                        <div class='input-group date' id='datepickerHasta'>
                            <input type='text' id="txtHasta" class="form-control" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>--%>



                    <div class="col-md">
                        <label for="txtDesde">Desde:</label>
                        <input type="date" id="txtDesde" class="form-control"/>
                    </div>
                    <div class="col-md">
                        <label for="txtHasta">Hasta:</label>
                        <input type="date" id="txtHasta" class="form-control"/>
                    </div>
                    
                    <div class="col-lg">
                        <label class="textoReducido">Procedencia:</label>
                        <select id="ddlProcedencia" class="form-control textoReducido">
                            <option value="0">Todo</option>
                        </select>
                    </div>
                    <div class="col-lg">
                        <label class="textoReducido">Previsión:</label>
                        <select id="ddlPrevision" class="form-control textoReducido">
                            <option value="0">Todo</option>
                        </select>
                    </div>

                    
                    <div class="col-lg">
                        <label class="textoReducido">Examen:</label>
                        <select id="ddlExamen" class="form-control textoReducido">
                            <option value="0">Todos</option>
                        </select>
                    </div>
                    <div class="col-lg">
                        <label class="textoReducido">Determinación:</label>
                        <select id="ddlDeterminacion" class="form-control textoReducido">
                            <option value="0">Seleccione Examen</option>
                        </select>
                    </div>


                </div>
                <div class="row" style="margin-left: 2px; margin-right: 2px;">
                    <div class="col-md">
                        <button id="Btn_Buscar" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                    </div>
                    <div class="col-md">
                        <button id="Btn_Excel" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                    </div>
                </div>


                <%-------------------------------------------------------------TABLA-------------------------------------------------------------%>
                <div class="row">
                    <div class="col-md-12" id="Paciente">
                        <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i>Listado</h5>
                        <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
