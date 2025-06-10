<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Copiar_Val_Prevision.aspx.vb" Inherits="Presentacion.Copiar_Val_Prevision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        var ddlAño = "";
        var ddlPreve = "";

        $(document).ready(function () {
            Llenar_Ddl_Año();
            Llenar_Ddl_Preve();

            $("#btn_guardar").click(function () {

                if ($("#ddl_Año_destino").val() == 0 || $("#ddl_Preve_destino").val() == 0) {
                    $("#mError_AAH h4").text("Seleccione");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione los datos solicitados.");
                    $("#mError_AAH").modal();
                } else {
                    if (Mx_Dtt == "") {
                        $("#mError_AAH h4").text("Seleccione");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No hay datos para copiar.");
                        $("#mError_AAH").modal();
                    } else {
                        Update_Precio();
                    }                 
                }
                
            });

            $("#ddl_Año, #ddl_Preve").change(function () {

                ddlAño = $("#ddl_Año").val();
                ddlPreve = $("#ddl_Preve").val();

                if (ddlAño != "Seleccione Año" && ddlPreve != "Seleccione Previsión") {
                    Ajax_DataTable();
                }
            });
        });
       
        var Mx_Ddl_Años = [{
            "ID_AÑO": "",
            "AÑO_COD": "",
            "AÑO_DESC": "",
            "ID_ESTADO": ""
        }];
        var Mx_Ddl_Preve = [{
            "ID_PREVE": "",
            "PREVE_COD": "",
            "PREVE_DESC": "",
            "ID_ESTADO": ""
        }];
        var Mx_Dtt = [{
            "AÑO_DESC": "",
            "ID_PREVE": "",
            "ID_CODIGO_FONASA": "",
            "CF_PRECIO_AMB": "",
            "CF_PRECIO_HOS": "",
            "CF_DESC": "",
            "CF_COD": "",
            "ID_AÑO": "",
            "ID_CF_PRECIO": ""
        }];
        function Llenar_Ddl_Año() {
            $.ajax({
                "type": "POST",
                "url": "Copiar_Val_Prevision.aspx/Llenar_Ddl_Año",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    Mx_Ddl_Años = data.d;
                    Fill_Ddl_Años();
                },
                "error": data => {
                }
            });
        }

        function Llenar_Ddl_Preve() {
            $.ajax({
                "type": "POST",
                "url": "Copiar_Val_Prevision.aspx/Llenar_Ddl_Preve",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    Mx_Ddl_Preve = data.d;
                    Fill_Ddl_Preve();
                },
                "error": data => {
                }
            });
        }
        function Ajax_DataTable() {
            modal_show();
            $("#Div_Table").empty();

            var Data_Param = JSON.stringify({
                "ID_AÑO": $("#ddl_Año").val(),
                "ID_PREVI": $("#ddl_Preve").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Copiar_Val_Prevision.aspx/Llenar_DataTable",
                "data": Data_Param,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;
                        $("#DataTable").empty();
                        Hide_Modal();
                        Fill_DataTable();
                    } else {
                        $("#Div_Table").append("<h5>No se encontraron resultados.</h5>");
                        Mx_Dtt = [];
                        $("#DataTable").empty();
                        $("#mError_AAH h4").text("Sin Resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados.");
                        $("#mError_AAH").modal();
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    Hide_Modal();
                }
            });
        }


        function Update_Precio() {
            modal_show();
            var Data_Par = JSON.stringify({
                "Mx_Pos": Mx_Dtt,
                "ID_ANO": $("#ddl_Año_destino").val(),
                "ID_PREVE": $("#ddl_Preve_destino").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Copiar_Val_Prevision.aspx/Update_Precio",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Marcar = JSON.parse(json_receiver);                                            

                        $("#mError_AAH h4").text("Previsión Actualizada");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("Los valores se han creado o actualizado correctamente.");
                        $("#mError_AAH").modal();

                        Hide_Modal();


                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin Cambios");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han realizado cambios.");
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
        function Fill_Ddl_Años() {
            $("<option>", { "value": 0 }).text("Seleccione Año (Destino)").appendTo("#ddl_Año_destino");
            Mx_Ddl_Años.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_AÑO
                    }
                ).text(aaa.AÑO_DESC).appendTo("#ddl_Año");

                $("<option>",
                    {
                        "value": aaa.ID_AÑO
                    }
                ).text(aaa.AÑO_DESC).appendTo("#ddl_Año_destino");
            });

        }
        function Fill_Ddl_Preve() {
            $("<option>", { "value": 0 }).text("Seleccione Previsión (Destino)").appendTo("#ddl_Preve_destino");
            Mx_Ddl_Preve.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_PREVE
                    }
                ).text(aaa.PREVE_DESC).appendTo("#ddl_Preve");

                $("<option>",
                    {
                        "value": aaa.ID_PREVE
                    }
                ).text(aaa.PREVE_DESC).appendTo("#ddl_Preve_destino");
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
            $("#DataTable thead").attr("class", "cabzera");
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Código"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido" }).text("Valor Ambulatorio"),
                    $("<th>", { "class": "textoReducido" }).text("Valor Hosp")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CF_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CF_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CF_PRECIO_AMB),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CF_PRECIO_HOS)
                    )
                );
            }
        }


    </script>
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
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="card mb-3 border-bar">
        <div class="card-header bg-bar">    <h5 class="text-center mb-3">Administrador de Precios</h5></div>
        <br />
        <div class="row" style="margin-top: 5px;">
            <br />
            <div class="col-md-1"></div>
            <div class="col-md-1">
                <label for="ddl_Año">Año:</label>
            </div>
            <div class="col-md-4">  
                <select id="ddl_Año" class="form-control mb-3">
                <option>Seleccione Año</option>
                </select>
            </div>
            <div class="col-md-1">
                <label for="ddl_Preve">Previsión:</label>
            </div>
            <div class="col-md-4">
                <select id="ddl_Preve" class="form-control mb-3">
                <option>Seleccione Previsión (Origen)</option>
                </select>
            </div>
            <div class="col-md-1"></div>      
        </div>
        <div class="row" style="margin-top: 5px;">
            <br />
            <div class="col-md-1"></div>
            <div class="col-md-1">
                <label for="ddl_Año_destino">Año:</label>
            </div>
            <div class="col-md-4">  
                <select id="ddl_Año_destino" class="form-control mb-3">
                </select>
            </div>
            <div class="col-md-1">
                <label for="ddl_Preve_destino">Previsión:</label>
            </div>
            <div class="col-md-4">
                <select id="ddl_Preve_destino" class="form-control mb-3">
                </select>
            </div>
            <div class="col-md-1"></div>      
        </div>
        <div class="row" style="margin-bottom: 2px; margin-left: 2px; margin-right: 2px;">
            <div class="col">
                <button type="button" class="btn btn-success btn-block mt-3" id="btn_guardar"><i class="fa fa-fw fa-save"></i>Guardar</button>
            </div>
        </div>
        <div id="Div_Tabla" style="max-height: 65vh; overflow: auto"></div>
    </div>
</asp:Content>
