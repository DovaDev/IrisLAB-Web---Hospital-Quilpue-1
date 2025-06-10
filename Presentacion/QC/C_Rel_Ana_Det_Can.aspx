<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="C_Rel_Ana_Det_Can.aspx.vb" Inherits="Presentacion.C_Rel_Ana_Det_Can" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
        <script>
        let ARR_NO_C = [], ARR_C = [], ARR_CH = [], OBJ = [];
        $(document).ready(() => {
            $("#btn_Close").click(() => {
                window.close();
            });
            $("#btn_Agregar").click(() => {
                if (ARR_NO_C.length > 0) {
                    Ajax_Guarda_Det_NO_C();
                }
            });

            $("#btn_Quitar").click(() => {
                if (ARR_C.length > 0) {
                    Ajax_Quita_REL();
                }
            });
            $("#btn_Update").click(() => {

                ARR_CH.forEach(i => {
                    let _obj = {
                        ID_REL: parseInt($("#id_" + i).attr("data-id")),
                        CANAL: $("#can_" + i).val(),
                    };
                    OBJ.push(_obj);
                });

                if (OBJ.length > 0) {
                    console.log(OBJ);
                    Ajax_Update_REL();
                }
            });

            $("#slt_Ana").change(() => {
                Ajax_Tabla1();
                Ajax_Tabla2();
            });

            Ajax_Busca_Ana();
        });

        var Mx_QC_ANA = [{
            ID_QC_ANALIZADOR: 0,
            QC_ANA_DESC: 0
        }];
        function Ajax_Busca_Ana() {

            $.ajax({
                "type": "POST",
                "url": "C_Rel_Ana_Det_Can.aspx/IRIS_QC_BUSCA_ANALIZADOR_ACTIVO",
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
            $("#slt_Ana").trigger("change").one();
        };

        var Mx_DET_NO_C = [{
            ID_QC_DETERMINACION: 0,
            QC_DET_DESC: 0
        }];

        function Ajax_Tabla1() {
            var Data_Par = JSON.stringify({
                "ID_ANA": $("#slt_Ana").val()
            });

            $.ajax({
                "type": "POST",
                "url": "C_Rel_Ana_Det_Can.aspx/IRIS_BUSCA_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_DET_NO_C = json_receiver;
                        Fill_DataTable1();
                        Hide_Modal();

                    } else {
                        $("#DataTable1 tbody").empty();
                        Hide_Modal();
                        console.log(response);
                    }
                },
                "error": function (response) {
                    $("#DataTable1 tbody").empty();
                    Hide_Modal();
                    console.log(response);
                }
            });
        }
        function Fill_DataTable1() {
            console.log("Fill DTT 1");
            $("#DataTable1 tbody").empty();

            for (i = 0; i < Mx_DET_NO_C.length; i++) {
                $("#DataTable1 tbody").append(
                    $("<tr>", {
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_DET_NO_C[i].QC_DET_DESC),
                        $("<td>").css("text-align", "center").html("<input type='checkbox' name='no_cargadas'data-id='" + Mx_DET_NO_C[i].ID_QC_DETERMINACION + "' />")
                    )
                );
            }

            $("input[name=no_cargadas]").click((aah) => {
                let NC_Index;
                NC_Index = $(aah.currentTarget).attr("data-id");
                let chk_NC = $(aah.currentTarget).prop("checked");
                console.log(chk_NC);
                if (chk_NC == true) {
                    ARR_NO_C.push(parseInt(NC_Index));
                    console.log(ARR_NO_C);
                }
                else {
                    let poss = ARR_NO_C.indexOf(NC_Index);
                    ARR_NO_C.splice(poss, 1);
                    console.log(ARR_NO_C);
                }
            }).one();
        }

        var Mx_DET_C = [{
            QC_REL_CA_DESC: 0,
            QC_DET_DESC: 0,
            ID_QC_REL_CA: 0
        }];

        function Ajax_Tabla2() {
            var Data_Par = JSON.stringify({
                "ID_ANA": $("#slt_Ana").val()
            });

            $.ajax({
                "type": "POST",
                "url": "C_Rel_Ana_Det_Can.aspx/IRIS_QC_BUSCA_ANALIZADORES_DETERMINACION_POR_CANAL",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_DET_C = json_receiver;
                        Fill_DataTable2();
                        console.log(Mx_DET_C);
                        Hide_Modal();

                    } else {
                        $("#DataTable2 tbody").empty();
                        Hide_Modal();
                        console.log(response);
                    }
                },
                "error": function (response) {
                    $("#DataTable2 tbody").empty();
                    Hide_Modal();
                    console.log(response);
                }
            });
        }

        function Fill_DataTable2() {
            console.log("Fill DTT 2");
            $("#DataTable2 tbody").empty();

            for (i = 0; i < Mx_DET_C.length; i++) {
                $("#DataTable2 tbody").append(
                    $("<tr>", {
                        "class": "manito",
                        "data-id": i
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_DET_C[i].QC_DET_DESC),
                        $("<td>").css("text-align", "center").html("<input type='checkbox' name='cargadas' id='id_"+i+"' data-id='" + Mx_DET_C[i].ID_QC_REL_CA + "' />"),
                        $("<td>").css("text-align", "center").html("<input type='text' class='text-center' name='input_t2' id='can_" + i + "' value='" + Mx_DET_C[i].QC_REL_CA_DESC + "' />")
                    )
                );
            }

            $("input[name=input_t2]").change((aah) => {
                let CH_Index;
                CH_Index = $(aah.currentTarget).parent().parent().attr("data-id");
                console.log(CH_Index);
                if (ARR_CH.length == 0) {
                    ARR_CH.push(parseInt(CH_Index));
                    console.log(ARR_CH);
                }
                else {
                    let ver = 0;
                    ARR_CH.forEach(aah=> {
                        if (aah == CH_Index) {
                            ver = 1;
                        }
                    });
                    if (ver == 0) {
                        ARR_CH.push(parseInt(CH_Index));
                    }
                    console.log(ARR_CH);
                }
            }).one();

            $("input[name=cargadas]").click((aah) => {
                let C_Index;
                C_Index = $(aah.currentTarget).attr("data-id");
                let chk_C = $(aah.currentTarget).prop("checked");
                console.log(chk_C);
                if (chk_C == true) {
                    ARR_C.push(parseInt(C_Index));
                    console.log(ARR_C);
                }
                else {
                    let poss = ARR_C.indexOf(C_Index);
                    ARR_C.splice(poss, 1);
                    console.log(ARR_C);
                }
            }).one();
        }

        function Ajax_Guarda_Det_NO_C() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_ANA": $("#slt_Ana").val(),
                "ID_DET": ARR_NO_C
            });

            console.log(Data_Par);
            $.ajax({
                "type": "POST",
                "url": "C_Rel_Ana_Det_Can.aspx/IRIS_GRABA_QC_RELACION_ANALIZADOR_DETERMINACION_CANAL",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        console.log("Re Fill Dtt");
                        ARR_NO_C = [];
                        Ajax_Tabla1();
                        Ajax_Tabla2();
                        Hide_Modal();

                    } else {
                        Hide_Modal();
                        console.log(response);
                    }
                },
                "error": function (response) {
                    Hide_Modal();
                    console.log(response);
                }
            });
        }
        function Ajax_Quita_REL() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_REL": ARR_C
            });

            console.log(Data_Par);
            $.ajax({
                "type": "POST",
                "url": "C_Rel_Ana_Det_Can.aspx/IRIS_UPDATE_QC_RELACION_MAQ_DETERMINACON_CANAL_QUITAR",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        console.log("Re Fill Dtt");
                        ARR_C = [];
                        Ajax_Tabla1();
                        Ajax_Tabla2();
                        Hide_Modal();

                    } else {
                        Hide_Modal();
                        console.log(response);
                    }
                },
                "error": function (response) {
                    Hide_Modal();
                    console.log(response);
                }
            });
        }

        function Ajax_Update_REL() {
            modal_show();
            var Data_Par = JSON.stringify({
                "OBJ": OBJ
            });

            console.log(Data_Par);
            $.ajax({
                "type": "POST",
                "url": "C_Rel_Ana_Det_Can.aspx/IRIS_UPDATE_QC_ANALIZADOR_DETERMINACION_CANAL_UPDATE",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {

                        ARR_CH = [];
                        OBJ = [];
                        Hide_Modal();

                    } else {
                        Hide_Modal();
                        console.log(response);
                    }
                },
                "error": function (response) {
                    Hide_Modal();
                    console.log(response);
                }
            });
        }

    </script>
    <style>
        .f-inline {
            display: flex;
            align-items: center;
        }

        .btn-sq {
            width: 112px !important;
            height: 112px !important;
            font-size: 15px;
        }
    </style>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-2 p-2">
            <li class="breadcrumb-item"><a href="/QC/Menu_QC.aspx">Menú</a></li>
            <li class="breadcrumb-item"><a href="/QC/Menu_Conf.aspx">Configuración</a></li>
            <li class="breadcrumb-item active" aria-current="page">Rel. ADC</li>
        </ol>
    </nav>
    <div class="card border-bar">
        <div class="card-header bg-bar text-center">
            <h3 class="m-0">Relación Analizador-Determinación-Canal
            </h3>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <div class="f-inline">
                        <label for="txt_Ana" class="mr-2">Analizador:&nbsp;</label>
                        <select id="slt_Ana" class="form-control form-control-sm"></select>
                    </div>
                </div>
                <div class="col-lg-3">
                    <button type="button" class="btn btn-primary btn-sm btn-block mt-0" id="btn_Update"><i class="fa fa-refresh fa-fw"></i>Actualizar Valores</button>
                </div>
                <div class="col-lg-3">
                    <button type="button" class="btn btn-danger btn-sm btn-block mt-0" id="btn_Close"><i class="fa fa-times fa-fw"></i>Salir</button>
                </div>
            </div>
        </div>
    </div>

    <div class="row mt-5">
        <div class="col-lg-3">
            <div class="card border-bar">
                <div class="card-header bg-bar text-center">
                    <h5 class="m-0">Por Seleccionar</h5>
                </div>
                <div class="card-body p-0" style="height: 50vh; overflow: auto">
                    <table id="DataTable1" class="table table-hover table-striped table-iris">
                        <thead>
                            <tr>
                                <th>Analito</th>
                                <th class="text-center">Agregar</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class="col-lg-2">
            <div class="row text-center mt-5">
                <div class="col-lg">
                    <button class="btn btn-sq btn-primary" id="btn_Agregar">
                        <i class="fa fa-arrow-right fa-3x mb-2"></i><b>
                            <br />
                            Agregar</b></button>
                </div>
            </div>
            <div class="row text-center mt-5">
                <div class="col-lg">
                    <button class="btn btn-sq btn-primary" id="btn_Quitar">
                        <i class="fa fa-arrow-left fa-3x mb-2"></i><b>
                            <br />
                            Quitar</b></button>
                </div>
            </div>
        </div>
        <div class="col-lg-7">
            <div class="card border-bar">
                <div class="card-header bg-bar text-center">
                    <h5 class="m-0">Agregados</h5>
                </div>
                <div class="card-body p-0" style="height: 50vh; overflow: auto">
                    <table id="DataTable2" class="table table-hover table-striped table-iris">
                        <thead>
                            <tr>
                                <th>Analito</th>
                                <th class="text-center">Quitar</th>
                                <th class="text-center">Canal</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
