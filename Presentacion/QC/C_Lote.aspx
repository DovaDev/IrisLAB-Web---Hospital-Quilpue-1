<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="C_Lote.aspx.vb" Inherits="Presentacion.C_Lote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>

        let _Cod, _Desc, _Estado, _Id_Ana, _N_CAna, _Fecha_E, _Nivel, _Id_Lote, dateNow;

        $(document).ready(() => {
            Clear();

            $("#btn_Add_Ana").click(() => {
                if (_Id_Lote != "") {
                    var loc = location.origin;
                    window.open(loc + "/QC/C_Rel_Lote_Ana.aspx?IDL=" + _Id_Lote);
                }
            });

            $("#btn_New").click(() => {
                Clear();
            });
            $("#btn_Guardar").click(() => {
                modal_show();

                _Cod = $("#txt_Cod").val();
                _Desc = $("#txt_Desc").val();
                _Estado = $("#slt_Est").val();
                _Id_Ana = $("#slt_Ana").val();
                _Fecha_E = $("#fecha").val();
                _N_CAna = $("#txt_NControl").val();
                _Nivel = $("#slt_Nivel").val();

                //_Desc = getNombre(_Desc);

                console.log(_Desc);
                Ajax_Guardar();
            });
            $("#btn_Eliminar").click(() => {
                _Cod = $("#txt_Cod").val();
                _Desc = $("#txt_Desc").val();
                _Estado = 3;
                _Id_Ana = $("#slt_Ana").val();
                _Fecha_E = $("#fecha").val();
                _N_CAna = $("#txt_NControl").val();
                _Nivel = $("#slt_Nivel").val();

                //_Desc = getNombre(_Desc);

                Ajax_Update();
            });
            $("#btn_Modificar").click(() => {
                _Cod = $("#txt_Cod").val();
                _Desc = $("#txt_Desc").val();
                _Estado = $("#slt_Est").val();
                _Id_Ana = $("#slt_Ana").val();
                _Fecha_E = $("#fecha").val();
                _N_CAna = $("#txt_NControl").val();
                _Nivel = $("#slt_Nivel").val();

                //_Desc = getNombre(_Desc);

                Ajax_Update();
            });
            Ajax_Busca_Nivel();
            Ajax_Busca_Ana();

            dateNow = moment().format("DD-MM-YYYY");
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

            Ajax_Tabla();

            $("#txt_Desc").focusout(() => {
                let _desc = $("#txt_Desc").val().toUpperCase();
                //_desc = _desc.trim();
                //let _last_desc = _desc.substr(_desc.length - 2, _desc.length - 1);
                //let _last_Num = "N1", _desc_bus = "";
                //_last_desc = _last_desc.toUpperCase();
                //if (_last_desc == "N1" || _last_desc == "N2" || _last_desc == "N3") {
                //    _last_Num = _last_desc;
                //    _desc_bus = _desc.substr(0, _desc.length - 2).trim();
                //} else {
                //    _desc_bus = _desc;
                //}
                if (_Id_Lote == "") {
                    Ajax_Ordena_Nivel(_desc);
                }
            });

        });

        //function getNombre(_Nom) {
        //    let _desc_n = _Nom;
        //    _desc_n = _desc_n.trim();
        //    let _last_desc = _desc_n.substr(_desc_n.length - 2, _desc_n.length - 1);
        //    let _last_Num = "N1", _desc_bus = "";
        //    _last_desc = _last_desc.toUpperCase();
        //    if (_last_desc == "N1" || _last_desc == "N2" || _last_desc == "N3") {
        //        _last_Num = _last_desc;
        //        let _id_Nivel = $("#slt_Nivel").val();
        //        Mx_QC_NIVEL.forEach(aah=> {
        //            if (_id_Nivel == aah.ID_QC_NIVEL) {
        //                if (aah.QC_NIVEL_COD != _last_Num) {
        //                    _last_Num = aah.QC_NIVEL_COD;
        //                }
        //            }
        //        });
        //        return _desc_n.substr(0, _desc_n.length - 2).trim() + " " + _last_Num;
        //    } else {
        //        let _last_Num = "";
        //        let _id_Nivel = $("#slt_Nivel").val();
        //        Mx_QC_NIVEL.forEach(aah=> {
        //            if (_id_Nivel == aah.ID_QC_NIVEL) {
        //                _last_Num = aah.QC_NIVEL_COD;
        //            }
        //        });
        //        return _Nom + " " + _last_Num;
        //    }
        //}

        function Ajax_Ordena_Nivel(_DESC) {
            var Data_Par = JSON.stringify({
                "LOTE_DESC": _DESC,
            });

            $.ajax({
                "type": "POST",
                "url": "C_Lote.aspx/IRIS_QC_BUSCA_NIVEL_POR_LOTE_DESC",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    if (response.d != null && response.d != 0) {
                        let _index_Nivel = 0;
                        for (i = 0; i < Mx_QC_NIVEL.length; ++i) {
                            if (Mx_QC_NIVEL[i].ID_QC_NIVEL == response.d) {
                                _index_Nivel = i + 1;
                            }
                        }
                        if (_index_Nivel > 0) {
                            $("#slt_Nivel").empty();
                            for (y = _index_Nivel; y < Mx_QC_NIVEL.length; ++y) {
                                $("<option>", {
                                    "value": Mx_QC_NIVEL[y].ID_QC_NIVEL
                                }).text(Mx_QC_NIVEL[y].QC_NIVEL_DESC).appendTo("#slt_Nivel");
                            }
                        }
                    } else {
                        $("#slt_Nivel").empty();
                        for (y = 0; y < Mx_QC_NIVEL.length; ++y) {
                            $("<option>", {
                                "value": Mx_QC_NIVEL[y].ID_QC_NIVEL
                            }).text(Mx_QC_NIVEL[y].QC_NIVEL_DESC).appendTo("#slt_Nivel");
                        }
                    }
                },
                "error": function (response) {
                    console.log(response);
                }
            });
        }

        var Mx_QC_NIVEL = [{
            ID_QC_NIVEL: 0,
            QC_NIVEL_DESC: 0
        }];

        function Ajax_Busca_Nivel() {
            $.ajax({
                "type": "POST",
                "url": "C_Lote.aspx/IRIS_QC_BUSCA_NIVEL_ACTIVO",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    Mx_QC_NIVEL = response.d;
                    if (Mx_QC_NIVEL != null) {
                        Fill_QC_NIVEL();
                    } else {
                        console.log(response);
                        console.log("null");
                    }
                },
                "error": function (response) {
                    console.log(response);
                }
            });
        }

        function Fill_QC_NIVEL() {
            $("#slt_Nivel").empty();

            for (y = 0; y < Mx_QC_NIVEL.length; ++y) {
                $("<option>", {
                    "value": Mx_QC_NIVEL[y].ID_QC_NIVEL
                }).text(Mx_QC_NIVEL[y].QC_NIVEL_DESC).appendTo("#slt_Nivel");
            }
        };

        function Ajax_Guardar() {

            var Data_Par = JSON.stringify({
                "AREA_COD": _Cod,
                "AREA_DES": _Desc,
                "ID_ESTADO": _Estado,
                "ID_ANA": _Id_Ana,
                "EXP": _Fecha_E,
                "CONTROL_ANA": _N_CAna,
                "NIVEL": _Nivel
            });

            $.ajax({
                "type": "POST",
                "url": "C_Lote.aspx/IRIS_GRABA_QC_LOTE_DE_MUESTRA",
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
                "ID_LOTE": _Id_Lote,
                "LOTE_COD": _Cod,
                "LOTE_DES": _Desc,
                "ID_ESTADO": _Estado,
                "ID_ANA": _Id_Ana,
                "ID_FECHA": _Fecha_E,
                "CONTROL_ANA": _N_CAna,
                "NIVEL": _Nivel
            });

            $.ajax({
                "type": "POST",
                "url": "C_Lote.aspx/IRIS_UPDATE_QC_LOTE",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Ajax_Tabla();
                        Clear();
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

        function Ajax_Codiguin(ID_QC_LOTE,
            QC_LOTE_COD,
            QC_LOTE_DESC,
            ID_ESTADO,
            ID_QC_ANALIZADOR,
            QC_LOTE_FECHA_EXP,
            QC_CONTROL_ANA,
            ID_QC_NIVEL) {

            _Id_Lote = ID_QC_LOTE;
            $("#txt_Cod").val(QC_LOTE_COD);
            $("#txt_Desc").val(QC_LOTE_DESC);
            $("#slt_Est").val(ID_ESTADO);
            $("#slt_Ana").val(ID_QC_ANALIZADOR);
            $("#slt_Nivel").val(ID_QC_NIVEL);
            $("#fecha").val(moment(QC_LOTE_FECHA_EXP).format("DD-MM-YYYY"));
            $("#txt_NControl").val(QC_CONTROL_ANA);

        }

        function Clear() {
            _Id_Lote = "";
            $("#txt_Cod").val("");
            $("#txt_Desc").val("");
            $("#fecha").val(dateNow);
            $("#txt_NControl").val("");
            $("#slt_Est").val(1);
        }

        var Mx_QC_ANA = [{
            ID_QC_ANALIZADOR: 0,
            QC_ANA_DESC: 0
        }];
        function Ajax_Busca_Ana() {

            $.ajax({
                "type": "POST",
                "url": "C_Lote.aspx/IRIS_QC_BUSCA_ANALIZADOR_ACTIVO",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_QC_ANA = json_receiver;
                        Fill_QC_ANA();
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
        function Fill_QC_ANA() {
            $("#slt_Ana").empty();

            for (y = 0; y < Mx_QC_ANA.length; ++y) {
                $("<option>", {
                    "value": Mx_QC_ANA[y].ID_QC_ANALIZADOR
                }).text(Mx_QC_ANA[y].QC_ANA_DESC).appendTo("#slt_Ana");
            }
        };

        var Mx_Dtt = [
            {
                ID_QC_LOTE: 0,
                QC_LOTE_COD: 0,
                QC_LOTE_DESC: 0,
                ID_ESTADO: 0,
                ID_QC_ANALIZADOR: 0,
                QC_LOTE_FECHA_EXP: 0,
                QC_CONTROL_ANA: 0,
                QC_ANA_DESC: 0,
                ID_QC_NIVEL: 0,
                QC_NIVEL_DESC:0
            }
        ];
        function Ajax_Tabla() {
            modal_show();

            $.ajax({
                "type": "POST",
                "url": "C_Lote.aspx/IRIS_QC_BUSCA_LOTE_ACTIVO_DESACTIVO",
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
                    $("<th>", { "class": "textoReducido" }).text("Nivel"),
                    $("<th>", { "class": "textoReducido" }).text("Analizador"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Expiración"),
                    $("<th>", { "class": "textoReducido" }).text("N° Control Ana"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Activo")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Codiguin("` + Mx_Dtt[i].ID_QC_LOTE + `","` + Mx_Dtt[i].QC_LOTE_COD + `","` + Mx_Dtt[i].QC_LOTE_DESC + `","` + Mx_Dtt[i].ID_ESTADO + `","` + Mx_Dtt[i].ID_QC_ANALIZADOR + `","` + Mx_Dtt[i].QC_LOTE_FECHA_EXP + `","` + Mx_Dtt[i].QC_CONTROL_ANA + `","` + Mx_Dtt[i].ID_QC_NIVEL + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].QC_LOTE_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].QC_LOTE_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].QC_NIVEL_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].QC_ANA_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(() => {
                            return moment(Mx_Dtt[i].QC_LOTE_FECHA_EXP).format("DD-MM-YYYY");
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].QC_CONTROL_ANA),
                        $("<td>").css("text-align", "center").html("<input type='checkbox' id='chekito" + i + "' />")
                    )
                );
                if (Mx_Dtt[i].ID_ESTADO == 1) {
                    $("#chekito" + i).prop("checked", true);
                }
            }

            $("#DataTable tbody tr").dblclick(() => {
                if (_Id_Lote != "") {
                    var loc = location.origin;
                    window.open(loc + "/QC/C_Rel_Lote_Ana.aspx?IDL=" + _Id_Lote);
                }
            });
        }
    </script>
    <style>
        #DataTable tbody td::selection {
            color: inherit;
            cursor: pointer;
        }

        .manito {
            cursor: pointer;
        }
    </style>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-2 p-2">
            <li class="breadcrumb-item"><a href="/QC/Menu_QC.aspx">Menú</a></li>
            <li class="breadcrumb-item"><a href="/QC/Menu_Conf.aspx">Configuración</a></li>
            <li class="breadcrumb-item active" aria-current="page">Lote</li>
        </ol>
    </nav>
    <div class="card border-bar">
        <div class="card-header bg-bar text-center">
            <h3 class="m-0">Antecedentes de Lote
            </h3>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <label for="txt_Cod">Código:</label>
                    <input type="text" id="txt_Cod" class="form-control form-control-sm" />
                </div>
                <div class="col-lg-2">
                    <label for="txt_Desc">Descripción:</label>
                    <input type="text" id="txt_Desc" class="form-control form-control-sm" />
                </div>

                <div class="col-lg">
                    <label for="slt_Est">Estado:</label>
                    <select id="slt_Est" class="form-control form-control-sm">
                        <option value="1">Activo</option>
                        <option value="3">Desactivado</option>
                    </select>
                </div>
                <div class="col-lg">
                    <label for="slt_Ana">Analizador:</label>
                    <select id="slt_Ana" class="form-control form-control-sm">
                    </select>
                </div>
                <div class="col-lg">
                    <label for="slt_Nivel">Nivel:</label>
                    <select id="slt_Nivel" class="form-control form-control-sm">
                    </select>
                </div>
                <div class="col-lg">
                    <label for="txt_Desc">N° Ctrl:</label>
                    <input type="text" id="txt_NControl" class="form-control form-control-sm" />
                </div>
                <div class="col-lg">
                    <label for="fecha">Expiración:</label>
                    <div class='input-group date' id='Txt_Date01'>
                        <input type='text' id="fecha" class="form-control form-control-sm" readonly="true" placeholder="Desde..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <br />
                    <button type="button" class="btn btn-buscar btn-sm btn-block" id="btn_Add_Ana"><i class="fa fa-search fa-fw"></i>Agregar Analitos</button>
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
            <h4 style="text-align: center; padding: 5px;">Lista de Lotes</h4>
            <div id="Div_Tabla" style="width: 100%;"></div>
        </div>
    </div>
</asp:Content>
