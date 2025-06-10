<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="C_Can_Rang.aspx.vb" Inherits="Presentacion.C_Can_Rang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        let estado_Cambio = 0;
        let _ID_MOD = "";

        $(document).ready(() => {
            Llenar_Ddl_Int();

            Limpia_Campos();

            $("#slt_Int").change(() => {
                Llenar_Ddl_Maq();
            });

            //$("#slt_Ana").change(() => {
            //    if (estado_Cambio == 0) {
            //        Ajax_Busca_Rel_CR();
            //    } else {
            //        estado_Cambio = 0;
            //    }

            //});

            Ajax_Busca_Rel_CR();

            $("#btn_Limpiar").click(() => {
                Limpia_Campos();
            });

            $("#btn_Guardar").click(() => {
                if ($("#slt_Int").val() != "" && $("#slt_Ana").val() != "" && $("#txt_Can").val() != "" && $("#txt_Det").val() != "") {
                    Ajax_Guardar_Rel_CR();
                }
            });

            $("#btn_Modificar").click(() => {
                if ($("#slt_Int").val() != "" && $("#slt_Ana").val() != "" && $("#txt_Can").val() != "" && $("#txt_Det").val() != "" && _ID_MOD != "") {
                    Ajax_Modificar_Rel_CR();
                }
            });

        });

        // LIMPIA CAMPOS
        function Limpia_Campos() {
            $("#txt_Can").val("");
            $("#txt_Det").val("");
            $("#txt_RB").val("");
            $("#txt_RA").val("");
            $("#txt_CB").val("");
            $("#txt_CA").val("");
        }

        // LLENA TABLA
        let Mx_Data = [{
            "ID_REL_CANAL_MAQ": "",
            "IRIS_LNK_I_ID": "",
            "IRIS_LNK_MAQ_ID": "",
            "REL_CM_CANAL_DESC": "",
            "REL_CM_DETER_DESC": "",
            "REL_CM_R_DESDE": "",
            "REL_CM_R_HASTA": "",
            "REL_CM_RR_DESDE": "",
            "REL_CM_RR_HASTA": "",
            "IRIS_LNK_I_DESCRIPCION": "",
            "IRIS_LNK_MAQ_DESCRIPCION": "",
            "ID_ESTADO": ""
        }];

        function Ajax_Busca_Rel_CR() {
            $.ajax({
                "type": "POST",
                "url": "C_Can_Rang.aspx/Buscar_Rel_CR",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    Mx_Data = data.d;

                    if (Mx_Data.length > 0) {
                        Fill_Dtt();
                    }
                },
                "error": data => {
                }
            });
        }

        function Fill_Dtt() {
            $("#DataTable tbody").empty();
            let i = 1;
            Mx_Data.forEach(rel=> {
                $("<tr>").attr("data-index", i - 1).append(
                    $("<td>").text(i),
                    $("<td>").text(rel.REL_CM_CANAL_DESC),
                    $("<td>").text(rel.REL_CM_DETER_DESC),
                    $("<td>").text(rel.REL_CM_R_DESDE),
                    $("<td>").text(rel.REL_CM_R_HASTA),
                    $("<td>").text(rel.REL_CM_RR_DESDE),
                    $("<td>").text(rel.REL_CM_RR_HASTA),
                    $("<td>").text(rel.IRIS_LNK_I_DESCRIPCION),
                    $("<td>").text(rel.IRIS_LNK_MAQ_DESCRIPCION),
                    $("<td>").css("text-align", "center").html(() => {
                        if (rel.ID_ESTADO == 1) {
                            return "<input type='checkbox' name='chk' checked data-id='" + rel.ID_REL_CANAL_MAQ + "'/>";
                        } else {
                            return "<input type='checkbox' name='chk' data-id='" + rel.ID_REL_CANAL_MAQ + "'/>";;
                        }
                    })

            ).appendTo("#DataTable tbody");
                i += 1;
            });

            $("input[name='chk']").click((e) => {

                let _est, _id;
                _id = $(e.currentTarget).attr("data-id");

                if ($(e.currentTarget).is(':checked') == true) {
                    _est = 1;
                } else {
                    _est = 3;
                }

                Ajax_Cambia_Estado_Rel_CR(_id,_est);
            });

            $("#DataTable tbody tr").click((e) => {
                let _index = $(e.currentTarget).attr("data-index");

                _ID_MOD = Mx_Data[_index].ID_REL_CANAL_MAQ;

                $("#txt_Can").val(Mx_Data[_index].REL_CM_CANAL_DESC);
                $("#txt_Det").val(Mx_Data[_index].REL_CM_DETER_DESC);
                $("#txt_RB").val(Mx_Data[_index].REL_CM_R_DESDE);
                $("#txt_RA").val(Mx_Data[_index].REL_CM_R_HASTA);
                $("#txt_CB").val(Mx_Data[_index].REL_CM_RR_DESDE);
                $("#txt_CA").val(Mx_Data[_index].REL_CM_RR_HASTA);
                $("#slt_Int").val(Mx_Data[_index].IRIS_LNK_I_ID);

                estado_Cambio = 1;

                $("#slt_Int").trigger("change");

                let _time = setInterval(() => {
                    if ($("#slt_Int").val() == Mx_Data[_index].IRIS_LNK_I_ID) {
                        $("#slt_Ana").val(Mx_Data[_index].IRIS_LNK_MAQ_ID);
                        if ($("#slt_Ana option:selected").text() == Mx_Data[_index].IRIS_LNK_MAQ_DESCRIPCION) {
                            clearInterval(_time);
                        }
                    }
                }, 1000);


            });
        }

        // GUARDA REL
        function Ajax_Guardar_Rel_CR() {
            let Data_Param = JSON.stringify({
                "ID_I": $("#slt_Int").val(),
                "ID_MAQ": $("#slt_Ana").val(),
                "CANAL": $("#txt_Can").val(),
                "DETER": $("#txt_Det").val(),
                "R_DESDE": $("#txt_RB").val(),
                "R_HASTA": $("#txt_RA").val(),
                "RR_DESDE": $("#txt_CB").val(),
                "RR_HASTA": $("#txt_CA").val()
            });

            $.ajax({
                "type": "POST",
                "url": "C_Can_Rang.aspx/Guardar_Rel_CR",
                "contentType": "application/json;  charset=utf-8",
                "data": Data_Param,
                "dataType": "json",
                "success": data => {
                    Limpia_Campos();
                    Ajax_Busca_Rel_CR();
                },
                "error": data => {
                    Ajax_Busca_Rel_CR();
                }
            });
        }

        // MODIFICA REL
        function Ajax_Modificar_Rel_CR() {
            modal_show();
            let Data_Param = JSON.stringify({
                "ID_REL": _ID_MOD,
                "ID_I": $("#slt_Int").val(),
                "ID_MAQ": $("#slt_Ana").val(),
                "CANAL": $("#txt_Can").val(),
                "DETER": $("#txt_Det").val(),
                "R_DESDE": $("#txt_RB").val(),
                "R_HASTA": $("#txt_RA").val(),
                "RR_DESDE": $("#txt_CB").val(),
                "RR_HASTA": $("#txt_CA").val()
            });

            $.ajax({
                "type": "POST",
                "url": "C_Can_Rang.aspx/Modificar_Rel_CR",
                "contentType": "application/json;  charset=utf-8",
                "data": Data_Param,
                "dataType": "json",
                "success": data => {
                    Hide_Modal();
                    _ID_MOD = "";
                    Limpia_Campos();
                    Ajax_Busca_Rel_CR();
                },
                "error": data => {
                    Hide_Modal();
                }
            });
        }

        // CAMBIA ESTADO REL
        function Ajax_Cambia_Estado_Rel_CR(_id, _est) {
            modal_show();
            let Data_Param = JSON.stringify({
                "ID_REL": _id,
                "ID_ESTADO": _est
            });

            $.ajax({
                "type": "POST",
                "url": "C_Can_Rang.aspx/Cambia_Estado_Rel_CR",
                "contentType": "application/json;  charset=utf-8",
                "data": Data_Param,
                "dataType": "json",
                "success": data => {
                    Hide_Modal();
                    _ID_MOD = "";
                    Limpia_Campos();
                    Ajax_Busca_Rel_CR();
                },
                "error": data => {
                    Hide_Modal();
                }
            });
        }

        // BUSCA INTERFAZ
        let Mx_Ddl_Int = [{
            "IRIS_LNK_I_ID": "",
            "IRIS_LNK_I_DESCRIPCION": ""
        }];

        function Llenar_Ddl_Int() {
            $.ajax({
                "type": "POST",
                "url": "C_Can_Rang.aspx/Llenar_Ddl_Int",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    Mx_Ddl_Int = data.d;
                    Fill_Ddl_Int();
                },
                "error": data => {
                }
            });
        }

        function Fill_Ddl_Int() {
            Mx_Ddl_Int.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.IRIS_LNK_I_ID
                    }
                ).text(aaa.IRIS_LNK_I_DESCRIPCION).appendTo("#slt_Int");
            });
            $("#slt_Int").trigger('change');
        }

        // BUSCA ANALIZADOR
        let Mx_Ddl_Maq = [{
            "IRIS_LNK_MAQ_ID": "",
            "IRIS_LNK_MAQ_DESCRIPCION": ""
        }];

        function Llenar_Ddl_Maq() {
            let Data_Param = JSON.stringify({
                "IRIS_LNK_I_ID": $("#slt_Int").val()
            });
            $.ajax({
                "type": "POST",
                "url": "C_Can_Rang.aspx/Llenar_Ddl_Maq",
                "contentType": "application/json;  charset=utf-8",
                "data": Data_Param,
                "dataType": "json",
                "success": data => {
                    Mx_Ddl_Maq = data.d;

                    if (Mx_Ddl_Maq != null) {
                        Fill_Ddl_Maq();
                    } else {
                        $("#slt_Ana").empty();
                    }

                },
                "error": data => {
                }
            });
        }

        function Fill_Ddl_Maq() {
            $("#slt_Ana").empty();
            Mx_Ddl_Maq.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.IRIS_LNK_MAQ_ID
                    }
                ).text(aaa.IRIS_LNK_MAQ_DESCRIPCION).appendTo("#slt_Ana");
            });
            //$("#slt_Ana").trigger('change');
        }

    </script>
    <div class="container">
        <div class="card border-bar">
            <div class="card-header bg-bar p-2">
                <h4 class="m-0 text-center">Relación Canal-Rangos de Referencia</h4>
            </div>
            <div class="card-body p-3 pt-2">
                <div class="row">
                    <div class="col-lg-10">
                        <div class="row">
                            <div class="col-lg">
                                <label for="slt_Int">Interfaz</label>
                                <select id="slt_Int" class="form-control form-control-sm"></select>
                            </div>
                            <div class="col-lg">
                                <label for="slt_Ana">Analizador</label>
                                <select id="slt_Ana" class="form-control form-control-sm"></select>
                            </div>
                            <div class="col-lg">
                                <label for="txt_Can">Canal</label>
                                <input type="text" id="txt_Can" class="form-control form-control-sm">
                            </div>
                            <div class="col-lg">
                                <label for="txt_Det">Determinación</label>
                                <input type="text" id="txt_Det" class="form-control form-control-sm">
                            </div>
                        </div>
                        <div class="row mt-2">
                            <div class="col-lg">
                                <label for="txt_RB">Rango Bajo</label>
                                <input type="text" id="txt_RB" class="form-control form-control-sm">
                            </div>
                            <div class="col-lg">
                                <label for="txt_RA">Rango Alto</label>
                                <input type="text" id="txt_RA" class="form-control form-control-sm">
                            </div>
                            <div class="col-lg">
                                <label for="txt_CB">Critico Bajo</label>
                                <input type="text" id="txt_CB" class="form-control form-control-sm">
                            </div>
                            <div class="col-lg">
                                <label for="txt_CA">Critico Alto</label>
                                <input type="text" id="txt_CA" class="form-control form-control-sm">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-2">
                        <div class="row">
                            <div class="col-lg-12">
                                <button type="button" class="btn btn-limpiar btn-sm btn-block" id="btn_Limpiar">Limpiar</button>
                            </div>
                        </div>
                        <div class="row mt-2">
                            <div class="col-lg-12">
                                <button type="button" class="btn btn-success btn-sm btn-block mt-2" id="btn_Guardar">Guardar</button>
                            </div>
                        </div>
                        <div class="row mt-2">
                            <div class="col-lg-12">
                                <button type="button" class="btn btn-primary btn-sm btn-block mt-2" id="btn_Modificar">Modificar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container mt-2">
        <div class="card border-bar">
            <div class="card-header bg-bar p-2">
                <h4 class="m-0 text-center">Tabla Canal-Rangos de Referencia</h4>
            </div>
            <div class="card-body p-3 pt-2">
                <table id="DataTable" cellspacing="0" class="table table-hover table-striped table-iris table-iris">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Canal</th>
                            <th>Determinación</th>
                            <th>Rango Bajo</th>
                            <th>Rango Alto</th>
                            <th>Critico Bajo</th>
                            <th>Critico Alto</th>
                            <th>Interfaz</th>
                            <th>Analizador</th>
                            <th style="text-align: center">Estado</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
