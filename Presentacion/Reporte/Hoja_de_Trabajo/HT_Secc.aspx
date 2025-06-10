<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="HT_Secc.aspx.vb" Inherits="Presentacion.HT_Secc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>
        $(document).ready(function () {
            $("#Id_Conte").hide();
            Ajax_Seccion();

            $("#Btn_Buscar").click(function () {
                $("#Div_Tabla").empty();
                Ajax_DataTable();
            });

            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input").val(dateNow);
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

            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date02 input").val(dateNow);
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
        });

        function Ajax_Redirect(id) {
            var loc = location.origin;
            window.open(loc + "/Buscar_Ate/Atencion_Det.aspx?ID_ATE=" + id);
        }

        var Mx_SEC = [{
            "ID_SECCION": 0,
            "SECC_COD": 0,
            "SECC_DESC": 0,
            "ID_ESTADO": 0
        }];

        function Ajax_Seccion() {
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "HT_SECC.aspx/Llenar_Ddl_Seccion",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_SEC = json_receiver;
                        Fill_Ddl_SEC();
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
                    var str_Error = response.ExceptionType + "\n \n";
                    str_Error = response.Message;
                    alert(str_Error);

                }
            });
        }
        function Fill_Ddl_SEC() {
            $("#Ddl_Seccion").empty();
            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Seccion");
            Mx_SEC.forEach(aaa => {
                $("<option>", { "value": aaa.ID_SECCION }).text(aaa.SECC_DESC).appendTo("#Ddl_Seccion");
            });
        }
        var Mx_Dtt = [{
            "ID_ATENCION": 0,
            "ATE_NUM": 0,
            "ATE_FECHA": 0,
            "ID_PACIENTE": 0,
            "PAC_RUT": 0,
            "PAC_NOMBRE": 0,
            "PAC_APELLIDO": 0,
            "PAC_FNAC": 0,
            "SEXO_DESC": 0,
            "ID_ESTADO": 0,
            "Expr1": 0,
            "CF_DESC": 0,
            "PER_DESC": 0,
            "RLS_LS_DESC": 0,
            "AREA_DESC": 0,
            "ID_AREA": 0,
            "ATE_AÑO": 0,
            "ATE_MES": 0,
            "ATE_DIA": 0,
            "PROC_DESC": 0,
            "ID_SEXO": 0,
            "ID_CODIGO_FONASA": 0,
            "DOC_NOMBRE": 0,
            "DOC_APELLIDO": 0,
            "ATE_DNI": 0,
            "NAC_DESC": 0,
            "PROGRA_DESC": 0,
            "SECTOR_DESC": 0,
            "ATE_NUM_INTERNO": 0
        }];
        function Ajax_DataTable() {
            modal_show();
            var Data_Par, Rutaa;

            var _DESDE = $("#Txt_Date01 input").val().replace(/-/g, '/');;
            var _HASTA = $("#Txt_Date02 input").val().replace(/-/g, '/');;

            _DESDE = moment(_DESDE, "DD/MM/YYYY").toDate();
            _HASTA = moment(_HASTA, "DD/MM/YYYY").toDate();

            Rutaa = "HT_Secc.aspx/Llenar_DataTable";

            Data_Par = JSON.stringify({
                "DESDE": _DESDE,
                "HASTA": _HASTA,
                "ID_TP_PAGO": $("#Ddl_Seccion").val()
            });
            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": Rutaa,
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    console.log("success");
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;
                        $("#Div_Tabla").empty();
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
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    console.log(response);
                    console.log("error");
                    Hide_Modal();
                    var str_Error = response.ExceptionType + "\n \n";
                    str_Error = response.Message;
                    alert(str_Error);
                }
            });
        }
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
                $("<th>", { "class": "textoReducido" }).text("N°Ate."),
                $("<th>", { "class": "textoReducido" }).text("Nombre"),
                $("<th>", { "class": "textoReducido" }).text("RUT"),
                $("<th>", { "class": "textoReducido" }).text("DNI"),
                $("<th>", { "class": "textoReducido" }).text("Edad"),
                $("<th>", { "class": "textoReducido" }).text("Lugar TM"),
                $("<th>", { "class": "textoReducido" }).text("Sexo"),
                $("<th>", { "class": "textoReducido" }).text("Nacionalidad"),
                $("<th>", { "class": "textoReducido" }).text("Examen"),
                $("<th>", { "class": "textoReducido" }).text("Programa"),
                $("<th>", { "class": "textoReducido" }).text("Sector"),
                $("<th>", { "class": "textoReducido" }).text("N°Inter."),
                $("<th>", { "class": "textoReducido" }).text("Doctor")
                )
            );
            var cont = 1;
            for (i = 0; i < Mx_Dtt.length; i++) {
                if (i != 0)
                { var ai = i - 1; }
                else
                { var ai = 0; }
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Redirect("` + Mx_Dtt[i].ENCRYPTED_ID + `")`,
                        "class": "manito"
                    }).attr("value", Mx_Dtt[i].ENCRYPTED_ID).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(cont),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {

                            if (i == 0 || Mx_Dtt[i].ATE_NUM != Mx_Dtt[ai].ATE_NUM) {
                                return String(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO);
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {

                            if (i == 0 || Mx_Dtt[i].ATE_NUM != Mx_Dtt[ai].ATE_NUM) {
                                return String(Mx_Dtt[i].PAC_RUT);
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {

                            if (i == 0 || Mx_Dtt[i].ATE_NUM != Mx_Dtt[ai].ATE_NUM) {
                                if (Mx_Dtt[ai].DNI != "null") {
                                    return String(Mx_Dtt[i].ATE_DNI);
                                }
                                else {
                                    return "";
                                }
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {

                            if (i == 0 || Mx_Dtt[i].ATE_NUM != Mx_Dtt[ai].ATE_NUM) {
                                return String(Mx_Dtt[i].ATE_AÑO);
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {

                            if (i == 0 || Mx_Dtt[i].ATE_NUM != Mx_Dtt[ai].ATE_NUM) {
                                return String(Mx_Dtt[i].PROC_DESC);
                            }
                        }),
                       $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {

                           if (i == 0 || Mx_Dtt[i].ATE_NUM != Mx_Dtt[ai].ATE_NUM) {
                               if (Mx_Dtt[i].SEXO_DESC == "Femenino") {
                                   $(this).css("background-color", "#ff99ec");
                               } else {
                                   $(this).css("background-color", "#99f9ff");
                               }
                               return String(Mx_Dtt[i].SEXO_DESC);
                           }
                       }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {

                            if (i == 0 || Mx_Dtt[i].ATE_NUM != Mx_Dtt[ai].ATE_NUM) {
                                return String(Mx_Dtt[i].NAC_DESC);
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CF_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {

                            if (Mx_Dtt[i].PROGRA_DESC != "<Sin Programa>") {
                                return String(Mx_Dtt[i].PROGRA_DESC);
                            }
                            else {
                                return String("<Sin/P>")
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {

                            if (Mx_Dtt[i].SECTOR_DESC != "<SIN SECTOR>") {
                                return String(Mx_Dtt[i].SECTOR_DESC);
                            }
                            else {
                                return String("<Sin/S>")
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ATE_NUM_INTERNO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {

                            return String(Mx_Dtt[i].DOC_NOMBRE + " " + Mx_Dtt[i].DOC_APELLIDO);
                        })
                  )
                );
                cont = cont + 1;
            }
            $("#lblTotal").text(cont - 1);
        }
    </script>
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
                <div class="card-header bg-bar p-1">
                    <h5 style="text-align: center; padding: 5px;">
                        <i class="fa fa-edit"></i>
                        Listado de hoja de trabajo por Sección
                    </h5>
                </div>
                <div class="card-body">
                    <div class="row" style="margin-left: 2px; margin-right: 2px;">
                        <div class="col-md-1">
                        </div>
                        <div class="col-md">
                            <label for="fecha">Fecha Desde:</label>
                            <div class='input-group date' id='Txt_Date01'>
                                <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Desde..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md">
                            <label for="fecha">Fecha Hasta:</label>
                            <div class='input-group date' id='Txt_Date02'>
                                <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Desde..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>

                        <div class="col-md">
                            <label for="Ddl_Seccion">Seccion:</label>
                            <select id="Ddl_Seccion" class="form-control">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>

                        <div class="col-md mt-4">
                            <button id="Btn_Buscar" class="btn btn-buscar btn-block" style="margin-bottom: 1vh;" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                        </div>
                        <div class="col-md-1">
                        </div>
                    </div>
                    <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
                    <div class="row" id="Id_Conte">
                        <div class="col-md-12 mt-3" id="Paciente">
                            <h5 style="text-align: center;"><i class="fa fa-fw fa-list"></i>Lista de Examenes</h5>
                            <div class="row" style="font-size: 15px;">
                                <div class="col-md-2">
                                    <label>TOTAL: </label>
                                    <b>
                                        <label id="lblTotal" class="text-primary">0</label></b>
                                </div>
                            </div>
                        </div>
                        <div id="Div_Tabla" style="width: 100%; max-height: 55vh; overflow: auto" class="p-3 mb-3"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
