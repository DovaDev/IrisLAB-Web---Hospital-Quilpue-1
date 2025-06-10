<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="C_Mon_Res_QC.aspx.vb" Inherits="Presentacion.C_Mon_Res_QC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        let Arr_Res_20 = [], Mx_Fill_20 = [], Arr_Busca_20 = [];

        $(document).ready(() => {
            $("#txt_Dec").val(2);
            Ajax_T_Hidden();

            $("#txt_Dec").keydown((e) => {
                if (event.keyCode == 13) {
                    Ajax_T_Hidden();
                }
            });

            

            $("#btn_Graph_Sec").click(() => {
                window.open("/QC/C_Graph_Sec.aspx");
            });

            $("#chk_Resumen").click(() => {
                Ajax_T_Hidden();
            });

            $("#chk_Var").click(() => {
                Ajax_T_Hidden();
            });

            $("#btn_Buscar").click(() => {
                Ajax_DataTable();
            });

            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input, #Txt_Date02 input").val(dateNow);

            $('#Txt_Date01, #Txt_Date02').datetimepicker(
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
            Ajax_Busca_Ana();
        });
        var Mx_QC_ANA = [{
            ID_QC_ANALIZADOR: 0,
            QC_ANA_DESC: 0
        }];
        function Ajax_Busca_Ana() {

            $.ajax({
                "type": "POST",
                "url": "C_Mon_Res_QC.aspx/IRIS_QC_BUSCA_ANALIZADOR_ACTIVO",
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

        function Ajax_T_Hidden() {
            let _ver = 0;
            let _N;
            let _Dec = $("#txt_Dec").val();
            let chk_Estado = $("#chk_Resumen").prop("checked");

            if (chk_Estado == true) {
                _N = 1;
            } else {
                _N = 0;
            }


            $("#DataTable thead").empty();
            $("#DataTable tbody").empty();
            if (_N == 1) {
                $("#DataTable thead").append(
               $("<tr>").append(
                   $("<th>", { "class": "align-middle" }).text("Lote"),
                   $("<th>", { "class": "align-middle" }).text("Determinacion"),
                   $("<th>", { "class": "align-middle" }).text("Resultado"),
                   $("<th>").html("Fijo/ <br/> N°"),
                   $("<th>").html("Fijo/ <br/> Max"),
                   $("<th>").html("Fijo/ <br/> Min"),
                   $("<th>").html("Fijo/ <br/> Media"),
                   $("<th>").html("Fijo/ <br/> Desv"),
                   $("<th>").html("Fijo/ <br/> CV"),
                   $("<th>").html(""),
                   $("<th>").html("Var/ <br/> N°"),
                   $("<th>").html("Var/ <br/> Max"),
                   $("<th>").html("Var/ <br/> Min"),
                   $("<th>").html("Var/ <br/> Media"),
                   $("<th>").html("Var/ <br/> Desv"),
                   $("<th>").html("Var/ <br/> CV")
               )
           );

                if (Mx_Dtt[0].ID_QC_RESULTADO != "") {
                    for (i = 0; i < Mx_Dtt.length; i++) {
                        $("#DataTable tbody").append(
                            $("<tr>", {
                                "class": "manito",
                                "data-id": i
                            }).append(
                                $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].QC_LOTE_DESC),
                                $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].QC_DET_DESC),
                                $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].QC_RESUL_VALOR_1),
                                $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].REL_ADL_CANT_F),
                                $("<td>", { "class": "textoReducido" }).text(() => {
                                    if (Mx_Dtt[i].REL_ADL_LS_F != "") {
                                        let v = parseFloat(Mx_Dtt[i].REL_ADL_LS_F.replace(',', '.'));
                                        return v.toFixed(_Dec).toString().replace(".", ",");
                                    } else {
                                        return "";
                                    }
                                    
                                }),
                                $("<td>", { "class": "textoReducido" }).text(() => {
                                    if (Mx_Dtt[i].REL_ADL_LI_F != "") {
                                        let v = parseFloat(Mx_Dtt[i].REL_ADL_LI_F.replace(',', '.'));
                                        return v.toFixed(_Dec).toString().replace(".", ",");
                                    } else {
                                        return "";
                                    }
                                    
                                }),
                                $("<td>", { "class": "textoReducido" }).text(() => {
                                    if (Mx_Dtt[i].REL_ADL_MEDIA_F != "") {
                                        let v = parseFloat(Mx_Dtt[i].REL_ADL_MEDIA_F.replace(',', '.'));
                                        return v.toFixed(_Dec).toString().replace(".", ",");
                                    } else {
                                        return "";
                                    }
                                   
                                }),
                                $("<td>", { "class": "textoReducido" }).text(() => {
                                    if (Mx_Dtt[i].REL_ADLL_DESV_F != "") {
                                        let v = parseFloat(Mx_Dtt[i].REL_ADLL_DESV_F.replace(',', '.'));
                                        return v.toFixed(_Dec).toString().replace(".", ",");
                                    } else {
                                        return "";
                                    }
                                    
                                }),
                                $("<td>", { "class": "textoReducido" }).text(() => {
                                    if (Mx_Dtt[i].REL_ADL_CV_F != "") {
                                        let v = parseFloat(Mx_Dtt[i].REL_ADL_CV_F.replace(',', '.'));
                                        return v.toFixed(_Dec).toString().replace(".", ",");
                                    } else {
                                        return "";
                                    }
                                    
                                }),
                                $("<td>", { "class": "textoReducido" }).text(""),
                                $("<td>", { "class": "textoReducido", "id": "cant_" + i }).text(""),
                                $("<td>", { "class": "textoReducido", "id": "max_" + i }).text(""),
                                $("<td>", { "class": "textoReducido", "id": "min_" + i }).text(""),
                                $("<td>", { "class": "textoReducido", "id": "media_" + i }).text(""),
                                $("<td>", { "class": "textoReducido", "id": "desv_" + i }).text(""),
                                $("<td>", { "class": "textoReducido", "id": "cv_" + i }).text("")
                            )
                        );
                    }
                    Ajax_Fill_Arr_20();
                }

            } else {
                $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "align-middle" }).text("Analizador"),
                    $("<th>", { "class": "align-middle" }).text("Lote"),
                    $("<th>", { "class": "align-middle" }).text("Determinacion"),
                    $("<th>", { "class": "align-middle" }).text("Resultado"),
                    $("<th>", { "class": "align-middle" }).text("Fecha"),
                    $("<th>", { "class": "align-middle" }).text("Error"),
                    $("<th>", { "class": "align-middle" }).text("Comentario"),
                    $("<th>").html("Fijo/ <br/> N°"),
                    $("<th>").html("Fijo/ <br/> Max"),
                    $("<th>").html("Fijo/ <br/> Min"),
                    $("<th>").html("Fijo/ <br/> Media"),
                    $("<th>").html("Fijo/ <br/> Desv"),
                    $("<th>").html("Fijo/ <br/> CV"),
                    $("<th>").html(""),
                    $("<th>").html("Var/ <br/> N°"),
                    $("<th>").html("Var/ <br/> Max"),
                    $("<th>").html("Var/ <br/> Min"),
                    $("<th>").html("Var/ <br/> Media"),
                    $("<th>").html("Var/ <br/> Desv"),
                    $("<th>").html("Var/ <br/> CV")
                )
            );
                if (Mx_Dtt[0].ID_QC_RESULTADO != "") {
                    for (i = 0; i < Mx_Dtt.length; i++) {
                        $("#DataTable tbody").append(
                            $("<tr>", {
                                "class": "manito",
                                "data-id": i
                            }).append(
                                $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].QC_ANA_DESC),
                                $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].QC_LOTE_DESC),
                                $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].QC_DET_DESC),
                                $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].QC_RESUL_VALOR_1),
                                $("<td>", { "class": "textoReducido" }).text(() => {
                                    return moment(Mx_Dtt[i].QC_RESUL_HORA).format("DD-MM-YYYY HH:mm:ss");
                                }),
                                $("<td>", { "class": "textoReducido" }).text(""),
                                $("<td>", { "class": "textoReducido" }).text(""),
                                $("<td>", { "class": "textoReducido" }).text(Mx_Dtt[i].REL_ADL_CANT_F),
                                $("<td>", { "class": "textoReducido" }).text(() => {
                                    if (Mx_Dtt[i].REL_ADL_LS_F != "") {
                                        let v = parseFloat(Mx_Dtt[i].REL_ADL_LS_F.replace(',', '.'));
                                        return v.toFixed(_Dec).toString().replace(".", ",");
                                    } else {
                                        return "";
                                    }

                                }),
                                $("<td>", { "class": "textoReducido" }).text(() => {
                                    if (Mx_Dtt[i].REL_ADL_LI_F != "") {
                                        let v = parseFloat(Mx_Dtt[i].REL_ADL_LI_F.replace(',', '.'));
                                        return v.toFixed(_Dec).toString().replace(".", ",");
                                    } else {
                                        return "";
                                    }

                                }),
                                $("<td>", { "class": "textoReducido" }).text(() => {
                                    if (Mx_Dtt[i].REL_ADL_MEDIA_F != "") {
                                        let v = parseFloat(Mx_Dtt[i].REL_ADL_MEDIA_F.replace(',', '.'));
                                        return v.toFixed(_Dec).toString().replace(".", ",");
                                    } else {
                                        return "";
                                    }

                                }),
                                $("<td>", { "class": "textoReducido" }).text(() => {
                                    if (Mx_Dtt[i].REL_ADLL_DESV_F != "") {
                                        let v = parseFloat(Mx_Dtt[i].REL_ADLL_DESV_F.replace(',', '.'));
                                        return v.toFixed(_Dec).toString().replace(".", ",");
                                    } else {
                                        return "";
                                    }

                                }),
                                $("<td>", { "class": "textoReducido" }).text(() => {
                                    if (Mx_Dtt[i].REL_ADL_CV_F != "") {
                                        let v = parseFloat(Mx_Dtt[i].REL_ADL_CV_F.replace(',', '.'));
                                        return v.toFixed(_Dec).toString().replace(".", ",");
                                    } else {
                                        return "";
                                    }

                                }),
                                $("<td>", { "class": "textoReducido" }).text(""),
                                $("<td>", { "class": "textoReducido", "id": "cant_" + i }).text(""),
                                $("<td>", { "class": "textoReducido", "id": "max_" + i }).text(""),
                                $("<td>", { "class": "textoReducido", "id": "min_" + i }).text(""),
                                $("<td>", { "class": "textoReducido", "id": "media_" + i }).text(""),
                                $("<td>", { "class": "textoReducido", "id": "desv_" + i }).text(""),
                                $("<td>", { "class": "textoReducido", "id": "cv_" + i }).text("")
                            )
                        );
                    }
                    Ajax_Fill_Arr_20();
                }
            }
            $("#DataTable tbody tr").dblclick((e) => {
                let d_id = $(e.currentTarget).attr("data-id");
                let v_res = Mx_Dtt[d_id].ID_QC_RESULTADO;
                let v_ana = Mx_Dtt[d_id].ID_QC_ANALIZADOR;
                let v_lot = Mx_Dtt[d_id].ID_QC_LOTE;
                let v_det = Mx_Dtt[d_id].ID_QC_DETERMINACION;
                let v_fec = Mx_Dtt[d_id].QC_RESUL_HORA;
                v_fec = moment(v_fec).format("DD-MM-YYYY HH:mm:ss");
                window.open("/QC/C_Graph.aspx?v1=" + v_res + "&v2=" + v_ana + "&v3=" + v_lot + "&v4=" + v_det + "&v5=" + v_fec)

            });
        }
        var Mx_Dtt = [{
            ID_QC_RESULTADO: "",
            ID_QC_ANALIZADOR: "",
            QC_ANA_DESC: "",
            ID_QC_LOTE: "",
            QC_LOTE_DESC: "",
            ID_QC_DETERMINACION: "",
            QC_DET_DESC: "",
            QC_RESUL_FECHA: "",
            QC_RESUL_VALOR_1: "",
            QC_COMENTARIOS: "",
            QC_RESUL_HORA: "",
            QC_RESUL_OMITIDO: "",
            TP_QC_DESC: "",
            REL_ADL_LI_F: "",
            REL_ADL_LS_F: "",
            REL_ADL_MEDIA_F: "",
            REL_ADLL_DESV_F: "",
            REL_ADL_LI_P: "",
            REL_ADL_LS_P: "",
            REL_ADL_MEDIA_P: "",
            REL_ADLL_DESV_P: "",
            REL_ADL_CANT_F: "",
            REL_ADL_CANT_P: "",
            REL_ADL_CV_F: "",
            REL_ADL_CV_P: "",
            ID_TP_QC_ACCION: ""
        }];
        function Ajax_DataTable() {
            modal_show();

            var Data_Par = JSON.stringify({
                DESDE: $("#fecha").val(),
                HASTA: $("#fecha2").val(),
                ID_ANA: $("#slt_Ana").val()
            });

            $.ajax({
                "type": "POST",
                "url": "C_Mon_Res_QC.aspx/IRIS_QC_BUSCA_MONITOR_CONTROLES_3",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;
                        console.log(Mx_Dtt);
                        Ajax_T_Hidden();
                        Mx_Fill_20 = [];
                        Arr_Busca_20 = [];

                        if (Mx_Dtt[0].ID_QC_RESULTADO != "") {
                            for (i = 0; i < Mx_Dtt.length; i++) {
                                let fm = moment(Mx_Dtt[i].QC_RESUL_HORA).format("DD-MM-YYYY HH:mm:ss.SSS");
                                console.log(fm);
                                let xx = { ID_ANA: Mx_Dtt[i].ID_QC_ANALIZADOR, ID_LOTE: Mx_Dtt[i].ID_QC_LOTE, ID_DET: Mx_Dtt[i].ID_QC_DETERMINACION, FECHA: fm, N: 20, i: i };
                                Arr_Busca_20.push(xx);
                            }
                        }
                        Ajax_20();
                        Hide_Modal();

                    } else {
                        $("#DataTable tbody").empty();
                        Hide_Modal();
                        console.log(response);
                        Mx_Dtt = [];
                        Mx_Fill_20 = [];
                        Arr_Busca_20 = [];
                    }
                },
                "error": function (response) {
                    $("#DataTable tbody").empty();
                    Hide_Modal();
                    console.log(response);
                    Mx_Dtt = [];
                    Mx_Fill_20 = [];
                    Arr_Busca_20 = [];
                }
            });
        }

        var Mx_20 = [];
        function Ajax_20() {
            var Data_Par = JSON.stringify({
                Obj: Arr_Busca_20
            });

            $.ajax({
                "type": "POST",
                "url": "C_Mon_Res_QC.aspx/IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_20 = json_receiver;
                        console.log(Mx_20);
                        Ajax_Fill_Arr_20();

                    } else {
                        Hide_Modal();
                        console.log(response);
                        Mx_20 = [];
                        Arr_Res_20 = [];
                        Mx_Fill_20 = [];
                    }
                },
                "error": function (response) {
                    console.log(response);
                    Mx_20 = [];
                    Arr_Res_20 = [];
                    Mx_Fill_20 = [];
                }
            });


        }
        function Ajax_Fill_Arr_20() {
            let chk_Var = $("#chk_Var").prop("checked");

            if (chk_Var == true) {
                Mx_20.forEach(Obj=> {
                    let _i = Obj.i;
                    let _Num = Obj.LOS;
                    let _Cont = Obj.LOS.length;
                    Arr_Res_20 = [];
                    _Num.forEach(Num => {
                        if (Num.QC_RESUL_VALOR_1 != "") {
                            Arr_Res_20.push(parseFloat(Num.QC_RESUL_VALOR_1.replace(',', '.')));
                        }
                        else if (Num.QC_RESUL_VALOR_2 != "") {
                            Arr_Res_20.push(parseFloat(Num.QC_RESUL_VALOR_2.replace(',', '.')));
                        }
                        else if (Num.QC_RESUL_VALOR_3 != "") {
                            Arr_Res_20.push(parseFloat(Num.QC_RESUL_VALOR_3.replace(',', '.')));
                        }
                    })
                    let _Dec = $("#txt_Dec").val();
                    let _f_max = math.max(Arr_Res_20);
                    _f_max = _f_max.toFixed(_Dec).toString().replace(".", ",");
                    let _f_min = math.min(Arr_Res_20);
                    _f_min = _f_min.toFixed(_Dec).toString().replace(".", ",");
                    let _f_med = math.mean(Arr_Res_20);
                    _f_med = _f_med.toFixed(_Dec).toString().replace(".", ",");
                    let _f_desv = math.std(Arr_Res_20);
                    _f_desv = _f_desv.toFixed(_Dec).toString().replace(".", ",");
                    let _f_cv = math.variance(Arr_Res_20);
                    _f_cv = _f_cv.toFixed(_Dec).toString().replace(".", ",");

                    $("#cant_" + _i).text(_Cont);
                    $("#max_" + _i).text(_f_max);
                    $("#min_" + _i).text(_f_min);
                    $("#media_" + _i).text(_f_med);
                    $("#desv_" + _i).text(_f_desv);
                    $("#cv_" + _i).text(_f_cv);
                });
            }
        }

    </script>
    <style>
        .f-inline {
            display: flex;
        }

        .manito {
            cursor: pointer;
        }

        #DataTable tbody td::selection {
            color: inherit;
            cursor: pointer;
        }
    </style>
    <div class="card border-bar">
        <div class="card-header bg-bar text-center">
            <h3 class="m-0">Monitor de Resultados QC
            </h3>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg-7">
                    <div class="row">
                        <div class="col-lg">
                            <label for="fecha">Desde:</label>
                            <div class='input-group date' id='Txt_Date01'>
                                <input type='text' id="fecha" class="form-control form-control-sm" readonly="true" placeholder="Desde..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg">
                            <label for="fecha2">Hasta:</label>
                            <div class='input-group date' id='Txt_Date02'>
                                <input type='text' id="fecha2" class="form-control form-control-sm" readonly="true" placeholder="Desde..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg">
                            <label>Analizador:</label>
                            <select id="slt_Ana" class="form-control form-control-sm">
                            </select>
                        </div>
                        <div class="col-lg">
                            <br />
                            <button class="btn btn-buscar btn-block mt-0" id="btn_Buscar"><i class="fa fa-search fa-fw"></i>Buscar</button>
                        </div>
                    </div>
                </div>
                <div class="col-lg-1">
                </div>
                <div class="col-lg-4">
                    <div class="row">
                        <div class="col-lg">
                            <button class="btn btn-danger btn-block">
                                Omitir
                                <br />
                                por Lote</button>
                        </div>
                        <div class="col-lg">
                            <button class="btn btn-warning btn-block" id="btn_Graph_Sec">
                                Visor QC
                                <br />
                                por Sección</button>
                        </div>
                        <div class="col-lg">
                            <button class="btn btn-primary btn-block">
                                Modificar Val
                                <br />
                                Fijos Control</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-lg-2">
                    <input type="checkbox" id="chk_Resumen">
                    <label for="chk_Resumen">Resumen</label>
                </div>
                <div class="col-lg-2">
                    <input type="checkbox" id="chk_Var">
                    <label for="chk_Var">Con Variabilidad</label>
                </div>
                <div class="col-lg-2">
                    <div class="f-inline">
                        <label for="txt_Dec" class="mr-2">Decimales:&nbsp;</label>
                        <input type="text" id="txt_Dec" class="form-control form-control-sm" style="width: 4vw; height: 3vh;" />
                    </div>
                </div>
            </div>
            <div class="row mt-2" style="overflow: auto">
                <table id="DataTable" class="table table-hover table-striped table-iris">
                    <thead>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
