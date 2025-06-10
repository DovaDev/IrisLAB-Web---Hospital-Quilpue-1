<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="C_Nivel_Lote.aspx.vb" Inherits="Presentacion.C_Nivel_Lote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        $(document).ready(() => {
            Ajax_Busca_Lote();
            Ajax_Busca_Rel_Nivel_Lote();

            $("#btn_Guardar").click(() => {
                let val_1, val_2, val_3;

                val_1 = $("#slt_l1").val();
                val_2 = $("#slt_l2").val();
                val_3 = $("#slt_l3").val();

                if ($("#rbt1").prop("checked") == true && val_1 != null && val_2 != null) {
                    Ajax_Graba_Rel_Nivel_Lote(val_1, val_2);
                } else if ($("#rbt2").prop("checked") == true && val_1 != null && val_3 != null) {
                    Ajax_Graba_Rel_Nivel_Lote(val_1, val_3);
                } else if ($("#rbt3").prop("checked") == true && val_2 != null && val_3 != null) {
                    Ajax_Graba_Rel_Nivel_Lote(val_2, val_3);
                }
            });
        });

        function Ajax_Graba_Rel_Nivel_Lote(_N1, _N2) {

            var Data_Par = JSON.stringify({
                N1: _N1,
                N2: _N2
            });

            $.ajax({
                "type": "POST",
                "url": "C_Nivel_Lote.aspx/IRIS_GRABA_QC_REL_NIVEL_LOTE",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Ajax_Busca_Lote();
                        Ajax_Busca_Rel_Nivel_Lote();
                    } else {
                        console.log(response);
                    }
                },
                "error": function (response) {
                    console.log(response);
                }
            });
        }

        var Mx_Lotes = [
            {
                ID_QC_LOTE: 0,
                QC_LOTE_DESC: 0,
                ID_QC_NIVEL: 0
            }
        ];
        function Ajax_Busca_Lote() {
            $.ajax({
                "type": "POST",
                "url": "C_Nivel_Lote.aspx/IRIS_QC_BUSCA_LOTE_NIVEL_SIN_REL",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Lotes = json_receiver;
                        Fill_Lote();
                    } else {
                        console.log(response);
                    }
                },
                "error": function (response) {
                    console.log(response);
                }
            });
        }
        function Fill_Lote() {
            $("#slt_l1").empty();
            $("#slt_l2").empty();
            $("#slt_l3").empty();

            let id_Slt = "";
            Mx_Lotes.forEach(aah => {
                if (aah.ID_QC_NIVEL == 1) {
                    id_Slt = "#slt_l1";
                } else if (aah.ID_QC_NIVEL == 2) {
                    id_Slt = "#slt_l2";
                } else {
                    id_Slt = "#slt_l3";
                }

                $("<option>", {
                    "value": aah.ID_QC_LOTE
                }).text(aah.QC_LOTE_DESC).appendTo(id_Slt);
            });

        }

        var Mx_Dtt = [
            {
                ID_QC_REL_NIVEL_LOTE: 0,
                ID_QC_LOTE_1: 0,
                QC_LOTE_DESC_1: 0,
                ID_QC_NIVEL_1: 0,
                QC_NIVEL_DESC_1: 0,
                ID_QC_LOTE_2: 0,
                QC_LOTE_DESC_2: 0,
                ID_QC_NIVEL_2: 0,
                QC_NIVEL_DESC_2: 0,
                ID_ESTADO: 0,
            }
        ];
        function Ajax_Busca_Rel_Nivel_Lote() {
            $.ajax({
                "type": "POST",
                "url": "C_Nivel_Lote.aspx/IRIS_QC_BUSCA_REL_NIVEL_LOTE",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;
                        $("#Div_Tabla").empty();
                        Fill_DataTable();
                    } else {
                        console.log(response);
                    }
                },
                "error": function (response) {
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
                    $("<th>", { "class": "textoReducido" }).text("Lote"),
                    $("<th>", { "class": "textoReducido" }).text("Nivel"),
                    $("<th>", { "class": "textoReducido" }).text("Lote"),
                    $("<th>", { "class": "textoReducido" }).text("Nivel"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Activo")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].QC_LOTE_DESC_1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].QC_NIVEL_DESC_1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].QC_LOTE_DESC_2),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].QC_NIVEL_DESC_2),
                        $("<td>", { "onclick": `Ajax_Codiguin("` + Mx_Dtt[i].ID_QC_REL_NIVEL_LOTE + `","` + Mx_Dtt[i].ID_ESTADO + `")` }).css("text-align", "center").html("<input type='checkbox' id='chekito" + i + "' />")
                    )
                );
                if (Mx_Dtt[i].ID_ESTADO == 1) {
                    $("#chekito" + i).prop("checked", true);
                }
            }
        }
        function Ajax_Codiguin(ID_REL, ID_ESTADO) {

            let _ID_EST = "";

            if (ID_ESTADO == 1) {
                _ID_EST = 3;
            } else {
                _ID_EST = 1;
            }
            var Data_Par = JSON.stringify({
                "ID_REL": ID_REL,
                "ID_ESTADO": _ID_EST
            });

            $.ajax({
                "type": "POST",
                "url": "C_Nivel_Lote.aspx/IRIS_UPDATE_QC_ESTADO_REL_LOTE_NIVEL",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Ajax_Busca_Lote();
                        Ajax_Busca_Rel_Nivel_Lote();
                    } else {
                        console.log(response);
                    }
                },
                "error": function (response) {
                    console.log(response);
                }
            });
        }
    </script>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-2 p-2">
            <li class="breadcrumb-item"><a href="/QC/Menu_QC.aspx">Menú</a></li>
            <li class="breadcrumb-item"><a href="/QC/Menu_Conf.aspx">Configuración</a></li>
            <li class="breadcrumb-item active" aria-current="page">Rel Nivel Lote</li>
        </ol>
    </nav>
    <div class="card border-bar">
        <div class="card-header bg-bar text-center">
            <h3 class="m-0">Relación Nivel-Lote
            </h3>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <label for="slt_l1">Lote N1</label>
                    <select id="slt_l1" class="form-control form-control-sm"></select>
                </div>
                <div class="col-lg">
                    <label for="slt_l2">Lote N2</label>
                    <select id="slt_l2" class="form-control form-control-sm"></select>
                </div>
                <div class="col-lg">
                    <label for="slt_l3">Lote N3</label>
                    <select id="slt_l3" class="form-control form-control-sm"></select>
                </div>
                <div class="col-lg-1 text-center">
                    <div class="form-check m-0">
                        <input class="form-check-input mt-2" type="radio" name="rbt" id="rbt1" value="1" checked>
                        <label class="form-check-label p-0" for="rbt1">
                            N1 - N2
                        </label>
                    </div>
                    <div class="form-check m-0">
                        <input class="form-check-input mt-2" type="radio" name="rbt" id="rbt2" value="2">
                        <label class="form-check-label p-0" for="rbt2">
                            N1 - N3
                        </label>
                    </div>
                    <div class="form-check m-0">
                        <input class="form-check-input mt-2" type="radio" name="rbt" id="rbt3" value="3">
                        <label class="form-check-label p-0" for="rbt3">
                            N2 - N3
                        </label>
                    </div>
                </div>
                <div class="col-lg-2">
                    <br />
                    <button type="button" class="btn btn-primary btn-block btn-sm mt-2" id="btn_Guardar"><i class="fa fa-floppy-o fa-fw"></i>Guardar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="row mb-3" id="Id_Conte">
        <div class="col-md-12">
            <h4 style="text-align: center; padding: 5px;">Lista Relación Nivel-Lote</h4>
            <div id="Div_Tabla" style="width: 100%;"></div>
        </div>
    </div>
</asp:Content>
