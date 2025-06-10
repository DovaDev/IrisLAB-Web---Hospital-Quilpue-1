<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="C_SecAnalisis.aspx.vb" Inherits="Presentacion.C_SecAnalisis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">

    <script>
        let _Cod, _Desc, _Estado, _Id_Sec;
        $(document).ready(() => {

            Clear();

            $("#btn_New").click(() => {
                Clear();
            });
            $("#btn_Guardar").click(() => {
                modal_show();
                _Cod = $("#txt_Cod").val();
                _Desc = $("#txt_Desc").val();
                _Estado = $("#slt_Est").val();

                Ajax_Guardar();
            });
            $("#btn_Eliminar").click(() => {
                _Cod = $("#txt_Cod").val();
                _Desc = $("#txt_Desc").val();
                _Estado = 3;

                Ajax_Update();
            });
            $("#btn_Modificar").click(() => {
                _Cod = $("#txt_Cod").val();
                _Desc = $("#txt_Desc").val();
                _Estado = $("#slt_Est").val();

                Ajax_Update();
            });

            Ajax_Tabla();
        });

        function Clear() {
            _Id_Sec = "";
            $("#txt_Cod").val("");
            $("#txt_Desc").val("");
            $("#slt_Est").val(1);
        }

        function Ajax_Codiguin(ID_QC_SECCION,
            QC_SECCION_COD,
            QC_SECCION_DESC,
            ID_ESTADO) {

            _Id_Sec = ID_QC_SECCION;
            $("#txt_Cod").val(QC_SECCION_COD);
            $("#txt_Desc").val(QC_SECCION_DESC);
            $("#slt_Est").val(ID_ESTADO);
        }

        function Ajax_Guardar() {

            var Data_Par = JSON.stringify({
                "AREA_COD": _Cod,
                "AREA_DES": _Desc,
                "ID_ESTADO": _Estado
            });

            $.ajax({
                "type": "POST",
                "url": "C_SecAnalisis.aspx/IRIS_GRABA_QC_SECCIONES",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Clear();
                        Ajax_Tabla();
                        Hide_Modal();
                    } else {
                        Clear();
                        Hide_Modal();
                        console.log(response);
                        console.log("null");
                    }
                },
                "error": function (response) {
                    Clear();
                    Hide_Modal();
                    console.log(response);
                }
            });
        }
        
        function Ajax_Update() {
            var Data_Par = JSON.stringify({
                "ID_AREA": _Id_Sec,
                "AREA_COD": _Cod,
                "AREA_DES": _Desc,
                "ID_ESTADO": _Estado
            });

            $.ajax({
                "type": "POST",
                "url": "C_SecAnalisis.aspx/IRIS_UPDATE_QC_SECCIONES",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Clear();
                        Ajax_Tabla();
                        Hide_Modal();
                    } else {
                        Clear();
                        Hide_Modal();
                        console.log(response);
                        console.log("null");
                    }
                },
                "error": function (response) {
                    Clear();
                    Hide_Modal();
                    console.log(response);
                }
            });
        }

        var Mx_Dtt = [
            {
                ID_QC_SECCION: 0,
                QC_SECCION_COD: 0,
                QC_SECCION_DESC: 0,
                ID_ESTADO: 0,
            }
        ];
        function Ajax_Tabla() {
            modal_show();

            $.ajax({
                "type": "POST",
                "url": "C_SecAnalisis.aspx/IRIS_QC_BUSCA_SECCIONES",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;
                        $("#Div_Tabla").empty();
                        Fill_DataTable();
                        Hide_Modal();

                    } else {
                        Clear();
                        Hide_Modal();
                        console.log(response);
                    }
                },
                "error": function (response) {
                    Clear();
                    Hide_Modal();
                    console.log(response);
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
            $("#DataTable thead").attr("class", "cabzera");
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Código"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Activo")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Codiguin("` + Mx_Dtt[i].ID_QC_SECCION + `","` + Mx_Dtt[i].QC_SECCION_COD + `","` + Mx_Dtt[i].QC_SECCION_DESC + `","` + Mx_Dtt[i].ID_ESTADO + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].QC_SECCION_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].QC_SECCION_DESC),
                        $("<td>").css("text-align", "center").html("<input type='checkbox' id='chekito" + i + "' />")
                    )
                );
                if (Mx_Dtt[i].ID_ESTADO == 1) {
                    $("#chekito" + i).prop("checked", true);
                }
            }
        }
    </script>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-2 p-2">
            <li class="breadcrumb-item"><a href="/QC/Menu_QC.aspx">Menú</a></li>
            <li class="breadcrumb-item"><a href="/QC/Menu_Conf.aspx">Configuración</a></li>
            <li class="breadcrumb-item active" aria-current="page">Secciones</li>
        </ol>
    </nav>
    <div class="card border-bar">
        <div class="card-header bg-bar text-center">
            <h3 class="m-0">Antecedentes de Sección
            </h3>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg-3">
                    <label for="txt_Cod">Código:</label>
                    <input type="text" id="txt_Cod" class="form-control form-control-sm" />
                </div>
                <div class="col-lg">
                    <label for="txt_Desc">Descripción:</label>
                    <input type="text" id="txt_Desc" class="form-control form-control-sm" />
                </div>
                <div class="col-lg-3">
                    <label for="slt_Est">Estado:</label>
                    <select id="slt_Est" class="form-control form-control-sm">
                        <option value="1">Activo</option>
                        <option value="3">Desactivado</option>
                    </select>
                </div>
            </div>
            <div class="row mt-2 text-center">
                <div class="col-lg">
                    <button type="button" id="btn_New" class="btn btn-primary btn-block"><i class="fa fa-plus-circle fa-fw"></i>Nuevo</button>
                </div>
                <div class="col-lg">
                    <button type="button" id="btn_Guardar" class="btn btn-success btn-block"><i class="fa fa-floppy-o fa-fw"></i>Guardar</button>
                </div>
                <div class="col-lg">
                    <button type="button" id="btn_Eliminar" class="btn btn-danger btn-block"><i class="fa fa-trash fa-fw"></i>Eliminar</button>
                </div>
                <div class="col-lg">
                    <button type="button" id="btn_Modificar" class="btn btn-warning btn-block"><i class="fa fa-edit fa-fw"></i>Modificar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="row mb-3" id="Id_Conte">
        <div class="col-md-12">
            <h4 style="text-align: center; padding: 5px;">Lista de Secciones</h4>
            <div id="Div_Tabla" style="width: 100%;"></div>
        </div>
    </div>
</asp:Content>
