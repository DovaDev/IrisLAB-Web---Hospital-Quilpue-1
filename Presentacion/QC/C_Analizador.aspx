<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="C_Analizador.aspx.vb" Inherits="Presentacion.C_Analizador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">

    <script>
        let _Cod, _Desc, _Estado, _Id_Ana, _Id_Sec;

        $(document).ready(() => {
            Clear();
            Ajax_Busca_Sec();

            $("#btn_New").click(() => {
                Clear();
            });
            $("#btn_Guardar").click(() => {
                modal_show();
                _Cod = $("#txt_Cod").val();
                _Desc = $("#txt_Desc").val();
                _Estado = $("#slt_Est").val();
                _Id_Sec = $("#slt_Sec").val();

                Ajax_Guardar();
            });
            $("#btn_Eliminar").click(() => {
                _Cod = $("#txt_Cod").val();
                _Desc = $("#txt_Desc").val();
                _Estado = 3;
                _Id_Sec = $("#slt_Sec").val();

                Ajax_Update();
            });
            $("#btn_Modificar").click(() => {
                _Cod = $("#txt_Cod").val();
                _Desc = $("#txt_Desc").val();
                _Estado = $("#slt_Est").val();
                _Id_Sec = $("#slt_Sec").val();

                Ajax_Update();
            });

            Ajax_Tabla();
        });

        function Ajax_Guardar() {

            var Data_Par = JSON.stringify({
                "AREA_COD": _Cod,
                "AREA_DES": _Desc,
                "ID_ESTADO": _Estado,
                "ID_SECCION": _Id_Sec
            });

            $.ajax({
                "type": "POST",
                "url": "C_Analizador.aspx/IRIS_GRABA_QC_ANALIZADOR",
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
                "ID_AREA": _Id_Ana,
                "AREA_COD": _Cod,
                "AREA_DES": _Desc,
                "ID_ESTADO": _Estado,
                "ID_SECCION": _Id_Sec
            });

            $.ajax({
                "type": "POST",
                "url": "C_Analizador.aspx/IRIS_UPDATE_QC_ANALIZADOR",
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

        function Ajax_Codiguin(ID_QC_ANALIZADOR,
            QC_ANA_COD,
            QC_ANA_DESC,
            ID_ESTADO,
            ID_SECCION) {

            _Id_Ana = ID_QC_ANALIZADOR;
            $("#txt_Cod").val(QC_ANA_COD);
            $("#txt_Desc").val(QC_ANA_DESC);
            $("#slt_Est").val(ID_ESTADO);
            $("#slt_Sec").val(ID_SECCION);
        }

        function Clear() {
            _Id_Ana = "";
            $("#txt_Cod").val("");
            $("#txt_Desc").val("");
            $("#slt_Est").val(1);
        }

        var Mx_QC_Sec = [
           {
               ID_QC_SECCION: 0,
               QC_SECCION_DESC: 0
           }
        ];
        function Ajax_Busca_Sec() {

            $.ajax({
                "type": "POST",
                "url": "C_Analizador.aspx/IRIS_QC_BUSCA_SECCION_ACTIVO",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_QC_Sec = json_receiver;
                        Fill_QC_Ana();
                        Hide_Modal();
                    } else {
                        //Clear();
                        Hide_Modal();
                        console.log(response);
                        console.log("null");
                    }
                },
                "error": function (response) {
                    //Clear();
                    Hide_Modal();
                    console.log(response);
                }
            });
        }
        function Fill_QC_Ana() {
            $("#slt_Sec").empty();

            for (y = 0; y < Mx_QC_Sec.length; ++y) {
                $("<option>", {
                    "value": Mx_QC_Sec[y].ID_QC_SECCION
                }).text(Mx_QC_Sec[y].QC_SECCION_DESC).appendTo("#slt_Sec");
            }

        };


        var Mx_Dtt = [
            {
                ID_QC_ANALIZADOR: 0,
                QC_ANA_COD: 0,
                QC_ANA_DESC: 0,
                ID_ESTADO: 0,
                ID_QC_SECCION: 0,
                ID_QC_SECCION_DESC: 0
            }
        ];
        function Ajax_Tabla() {
            modal_show();

            $.ajax({
                "type": "POST",
                "url": "C_Analizador.aspx/IRIS_QC_BUSCA_ANALIZADOR",
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
                    $("<th>", { "class": "textoReducido" }).text("Sección"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Activo")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Codiguin("` + Mx_Dtt[i].ID_QC_ANALIZADOR + `","` + Mx_Dtt[i].QC_ANA_COD + `","` + Mx_Dtt[i].QC_ANA_DESC + `","` + Mx_Dtt[i].ID_ESTADO + `","` + Mx_Dtt[i].ID_QC_SECCION + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].QC_ANA_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].QC_ANA_DESC),
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
            <li class="breadcrumb-item active" aria-current="page">Analizadores</li>
        </ol>
    </nav>
    <div class="card border-bar">
        <div class="card-header bg-bar text-center">
            <h3 class="m-0">Antecedentes de Analizadores
            </h3>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg-2">
                    <label for="txt_Cod">Código:</label>
                    <input type="text" id="txt_Cod" class="form-control form-control-sm" />
                </div>
                <div class="col-lg">
                    <label for="txt_Desc">Descripción:</label>
                    <input type="text" id="txt_Desc" class="form-control form-control-sm" />
                </div>
                <div class="col-lg-3">
                    <label for="slt_Sec">Sección:</label>
                    <select id="slt_Sec" class="form-control form-control-sm">
                    </select>
                </div>
                <div class="col-lg-2">
                    <label for="slt_Est">Estado:</label>
                    <select id="slt_Est" class="form-control form-control-sm">
                        <option value="1">Activo</option>
                        <option value="3">Desactivado</option>
                    </select>
                </div>
            </div>
            <div class="row mt-2 text-center">
                <div class="col-lg">
                    <button type="button" class="btn btn-primary btn-block" id="btn_New"><i class="fa fa-plus-circle fa-fw"></i>Nuevo</button>
                </div>
                <div class="col-lg">
                    <button type="button" class="btn btn-success btn-block" id="btn_Guardar"><i class="fa fa-floppy-o fa-fw"></i>Guardar</button>
                </div>
                <div class="col-lg">
                    <button type="button" class="btn btn-danger btn-block" id="btn_Eliminar"><i class="fa fa-trash fa-fw"></i>Eliminar</button>
                </div>
                <div class="col-lg">
                    <button type="button" class="btn btn-warning btn-block" id="btn_Modificar"><i class="fa fa-edit fa-fw"></i>Modificar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="row mb-3" id="Id_Conte">
        <div class="col-md-12">
            <h4 style="text-align: center; padding: 5px;">Lista de Analizadores</h4>
            <div id="Div_Tabla" style="width: 100%;"></div>
        </div>
    </div>
</asp:Content>
