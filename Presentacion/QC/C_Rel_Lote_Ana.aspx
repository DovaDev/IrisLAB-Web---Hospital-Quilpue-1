<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="C_Rel_Lote_Ana.aspx.vb" Inherits="Presentacion.C_Rel_Lote_Ana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        let _Id_Lote = "", ARR_NO_C = [], ARR_C = [], ARR_CH = [], OBJ = [];
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
                    Ajax_Quita_REL_ADL();
                }
            });
            $("#btn_Update").click(() => {

                ARR_CH.forEach(i => {
                    let _obj = {
                        ID_REL: parseInt($("#id_" + i).text()),
                        LI: $("#li_" + i).val(),
                        LS: $("#ls_" + i).val(),
                        MEDIA: $("#me_" + i).val(),
                        DESVIACION: $("#de_" + i).val(),
                        CV: $("#cv_" + i).val(),
                        NUM: $("#nmue_" + i).val()
                    };
                    OBJ.push(_obj);
                });

                if (OBJ.length > 0) {
                    console.log(OBJ);
                    Ajax_Update_REL_ADL();
                }
            });

            _Id_Lote = getParameterByName("IDL");
            console.log(_Id_Lote);

            Ajax_Busca_Lote();
        });
        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }

        var Mx_QC_LOTE = [{
            ID_QC_LOTE: 0,
            QC_LOTE_DESC: 0,
            ID_QC_ANALIZADOR: 0,
            QC_ANA_DESC: 0
        }];
        function Ajax_Busca_Lote() {

            var Data_Par = JSON.stringify({
                "ID_LOTE": _Id_Lote
            });

            $.ajax({
                "type": "POST",
                "url": "C_Rel_Lote_Ana.aspx/IRIS_QC_BUSCA_LOTE",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_QC_LOTE = json_receiver;
                        Ajax_Tabla1();
                        Ajax_Tabla2();
                        console.log(Mx_QC_LOTE);
                        Fill_QC_LOTE();
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
        function Fill_QC_LOTE() {
            $("#txt_Lote").val(Mx_QC_LOTE[0].QC_LOTE_DESC);
            $("#txt_Ana").val(Mx_QC_LOTE[0].QC_ANA_DESC);
        }

        var Mx_DET_NO_C = [{
            ID_QC_DETERMINACION: 0,
            QC_DET_COD: 0,
            QC_DET_DESC: 0
        }];

        function Ajax_Tabla1() {
            var Data_Par = JSON.stringify({
                "ID_ANA": Mx_QC_LOTE[0].ID_QC_ANALIZADOR,
                "ID_LOTE": Mx_QC_LOTE[0].ID_QC_LOTE
            });

            $.ajax({
                "type": "POST",
                "url": "C_Rel_Lote_Ana.aspx/IRIS_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS_POR_ANALIZAOR_LOTE",
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
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_DET_NO_C[i].ID_QC_DETERMINACION),
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
            ID_QC_ANALIZADOR: 0,
            ID_QC_DETERMINACION: 0,
            ID_QC_LOTE: 0,
            ID_QC_NIVEL: 0,
            REL_ADL_LI_F: 0,
            REL_ADL_LS_F: 0,
            REL_ADL_MEDIA_F: 0,
            REL_ADLL_DESV_F: 0,
            REL_ADL_LI_P: 0,
            REL_ADL_LS_P: 0,
            REL_ADL_MEDIA_P: 0,
            REL_ADLL_DESV_P: 0,
            ID_REL_ADL: 0,
            QC_DET_DESC: 0,
            REL_ADL_CANT_F: 0,
            REL_ADL_CV_F: 0
        }];

        function Ajax_Tabla2() {
            var Data_Par = JSON.stringify({
                "ID_ANA": Mx_QC_LOTE[0].ID_QC_ANALIZADOR,
                "ID_LOTE": Mx_QC_LOTE[0].ID_QC_LOTE
            });

            $.ajax({
                "type": "POST",
                "url": "C_Rel_Lote_Ana.aspx/IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE",
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
                        $("<td>", { "id": "id_" + i }).text(Mx_DET_C[i].ID_REL_ADL),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_DET_C[i].QC_DET_DESC),
                        $("<td>").css("text-align", "center").html("<input type='checkbox' name='cargadas' data-id='" + Mx_DET_C[i].ID_REL_ADL + "' />"),
                        $("<td>").css("text-align", "center").html("<input type='text' class='text-center' name='input_t2' id='nmue_" + i + "' value='" + Mx_DET_C[i].REL_ADL_CANT_F + "' />"),
                        $("<td>").css("text-align", "center").html("<input type='text' class='text-center' name='input_t2' id='li_" + i + "' value='" + Mx_DET_C[i].REL_ADL_LI_F + "' />"),
                        $("<td>").css("text-align", "center").html("<input type='text' class='text-center' name='input_t2' id='ls_" + i + "' value='" + Mx_DET_C[i].REL_ADL_LS_F + "' />"),
                        $("<td>").css("text-align", "center").html("<input type='text' class='text-center' name='input_t2' id='me_" + i + "' value='" + Mx_DET_C[i].REL_ADL_MEDIA_F + "' />"),
                        $("<td>").css("text-align", "center").html("<input type='text' class='text-center' name='input_t2' id='de_" + i + "' value='" + Mx_DET_C[i].REL_ADLL_DESV_F + "' />"),
                        $("<td>").css("text-align", "center").html("<input type='text' class='text-center' name='input_t2' id='cv_" + i + "' value='" + Mx_DET_C[i].REL_ADL_CV_F + "' />")
                    )
                );
            }

            $("input[name=input_t2]").on("keypress keyup blur", function (event) {
                $(this).val($(this).val().replace(/[^-\1-9\,]/g, ''));
                if ((event.which != 44 && event.which != 45 || $(this).val().indexOf(',') != -1 && $(this).val().indexOf('-') != -1) && (event.which < 48 || event.which > 57)) {
                    event.preventDefault();
                }
            });

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
                "ID_ANA": Mx_QC_LOTE[0].ID_QC_ANALIZADOR,
                "ID_LOTE": Mx_QC_LOTE[0].ID_QC_LOTE,
                "ID_DET": ARR_NO_C
            });

            console.log(Data_Par);
            $.ajax({
                "type": "POST",
                "url": "C_Rel_Lote_Ana.aspx/IRIS_GRABA_QC_RELACION_MAQ_LOTE_DETERMINACION2",
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
        function Ajax_Quita_REL_ADL() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_REL_ADL": ARR_C
            });

            console.log(Data_Par);
            $.ajax({
                "type": "POST",
                "url": "C_Rel_Lote_Ana.aspx/IRIS_UPDATE_QC_REL_ADL",
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

        function Ajax_Update_REL_ADL() {
            modal_show();
            var Data_Par = JSON.stringify({
                "OBJ": OBJ
            });

            console.log(Data_Par);
            $.ajax({
                "type": "POST",
                "url": "C_Rel_Lote_Ana.aspx/IRIS_UPDATE_PARAMS_QC_REL_ADL",
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

        input[name="input_t2"] {
            width: 5vw;
        }
    </style>
    <div class="card border-bar">
        <div class="card-header bg-bar text-center">
            <h3 class="m-0">Relación Analizador-Determinación-Lote
            </h3>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <div class="f-inline">
                        <label for="txt_Ana" class="mr-2">Analizador:&nbsp;</label>
                        <input type="text" id="txt_Ana" class="form-control form-control-sm" readonly />
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="f-inline">
                        <label for="txt_Lote" class="mr-2">Lote:&nbsp;</label>
                        <input type="text" id="txt_Lote" class="form-control form-control-sm" readonly />
                    </div>
                </div>
                <div class="col-lg">
                    <button type="button" class="btn btn-primary btn-sm btn-block mt-0" id="btn_Update"><i class="fa fa-refresh fa-fw"></i>Actualizar Valores</button>
                </div>
                <div class="col-lg">
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
                                <th>ID</th>
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
                                <th>ID</th>
                                <th>Analito</th>
                                <th class="text-center">Quitar</th>
                                <th class="text-center">N° Muestra</th>
                                <th class="text-center">Limite Inferior</th>
                                <th class="text-center">Limite Superior</th>
                                <th class="text-center">Media</th>
                                <th class="text-center">Desviación</th>
                                <th class="text-center">CV</th>
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
