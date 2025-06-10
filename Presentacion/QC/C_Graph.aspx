<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="C_Graph.aspx.vb" Inherits="Presentacion.C_Graph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="../js/HighCharts.js"></script>
    <script src="../js/HighC_Exporting.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        let _ID_RESUL, _ID_ANA, _ID_LOTE, _ID_DET, _FEC, _N, Arr_Res_20 = [], _Title, _MOD_I, _bol_F_N;
        $(document).ready(() => {
            _ID_RESUL = getParameterByName("v1");
            _ID_ANA = getParameterByName("v2");
            _ID_LOTE = getParameterByName("v3");
            _ID_DET = getParameterByName("v4");
            _FEC = getParameterByName("v5");
            _N = 20;
            Ajax_Accion();
            Ajax_Fijos();
            console.log("RES: " + _ID_RESUL + " ANA: " + _ID_ANA + " LOTE: " + _ID_LOTE + " DET: " + _ID_DET + " FEC: " + _FEC);

            $("#mdl_Txt_Res").val("");
            $("#mdl_Txt_Com").val("");

            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input, #Txt_Date02 input , #Txt_Date03 input, #Txt_Date04 input").val(dateNow);

            $('#Txt_Date01, #Txt_Date02, #Txt_Date03, #Txt_Date04').datetimepicker({
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

            $("#n_20").click(() => {
                _N = 20;
                Ajax_20();
            });
            $("#n_25").click(() => {
                _N = 25;
                Ajax_20();
            });
            $("#n_30").click(() => {
                _N = 30;
                Ajax_20();
            });
            $("#n_40").click(() => {
                _N = 40;
                Ajax_20();
            });

            $("#btn_Buscar").click(() => {
                Ajax_Buscar();
            });

            $("#btn_Fijar_Var").click(() => {
                modal_show();
                Ajax_Fijar_Var();
            });

            $("#btn_Ing_Resul").click(() => {
                $("#mdl_Ing_Resul").modal("show");
            });

            $("#mdl_Txt_Res, #mdl_Txt_Res_Mod").on("keypress keyup blur", function (event) {
                $(this).val($(this).val().replace(/[^-\1-9\,]/g, ''));
                if ((event.which != 44 && event.which != 45 || $(this).val().indexOf(',') != -1 && $(this).val().indexOf('-') != -1) && (event.which < 48 || event.which > 57)) {
                    event.preventDefault();
                }
            });

            $("input[name=rbt_TC]").click(() => {
                //console.log("click");
                Ajax_Fill_Arr_20();
                Ajax_Fill_Graph();
            });

            $("#rbt_V").prop("checked", true);
            $("#rbt_1").prop("checked", true);

            $("#ru_12s").prop("checked", true);
            $("#ru_13s").prop("checked", true);
            $("#ru_22s").prop("checked", true);
            $("#ru_R4s").prop("checked", true);
            $("#ru_41s").prop("checked", true);
            $("#ru_10x").prop("checked", true);

            Ajax_20();

            $("input[name=rbt_FV]").click(() => {
                if (Arr_Res_20.length > 0) {
                    Ajax_Fill_Graph();
                }
            });

            $("#mdl_Btn_Guardar").click(() => {
                if ($("#mdl_Txt_Res").val != "") {
                    Ajax_Ingreso_Manual();
                }
            });

            $("#mdl_Btn_Guardar_Mod").click(() => {
                if ($("#mdl_Txt_Res_Mod").val != "") {
                    Ajax_Modificar_Resul();
                }
            });

            $("input[name=chk_rules]").click(() => {
                Ajax_Fill_Graph();
            });
        });

        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }

        function Ajax_Fijar_Var() {
            var Data_Par = JSON.stringify({
                ID_ANA: _ID_ANA,
                ID_LOTE: _ID_LOTE,
                ID_DET: _ID_DET,
                V_LI: $("#txt_mi_v").val(),
                V_LS: $("#txt_ma_v").val(),
                V_ME: $("#txt_me_v").val(),
                V_DE: $("#txt_ds_v").val(),
                V_CV: $("#txt_cv_v").val(),
                V_N: $("#txt_n_v").val(),
                F_LI: $("#txt_mi_f").val(),
                F_LS: $("#txt_ma_f").val(),
                F_ME: $("#txt_me_f").val(),
                F_DE: $("#txt_ds_f").val(),
                F_CV: $("#txt_cv_f").val(),
                F_N: $("#txt_n_f").val()
            });

            $.ajax({
                "type": "POST",
                "url": "C_Graph.aspx/IRIS_QC_GRABA_UPDATE_FIJA_VARIABLES",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Fijos = [];
                        Ajax_Fijos();
                        Ajax_20();
                    } else {
                        console.log(response);
                    }
                },
                "error": function (response) {
                    console.log(response);
                }
            });
        }

        function Ajax_Ingreso_Manual() {
            var Data_Par = JSON.stringify({
                ID_ANA: _ID_ANA,
                ID_LOTE: _ID_LOTE,
                ID_DET: _ID_DET,
                FECHA: $("#fecha3").val(),
                ID_TP_ACCION: $("#mdl_Slt_Accion").val(),
                RESUL: $("#mdl_Txt_Res").val(),
                COMENTARIO: $("#mdl_Txt_Com").val()
            });

            $.ajax({
                "type": "POST",
                "url": "C_Graph.aspx/IRIS_GRABA_QC_RESULTADO_MANUAL",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        if (_bol_F_N == 1) {
                            Ajax_20();
                        } else if (_bol_F_N == 2) {
                            Ajax_Buscar();
                        }
                        $("#mdl_Slt_Accion").val(18),
                        $("#mdl_Txt_Res").val(""),
                        $("#mdl_Txt_Com").val("")
                    } else {
                        console.log(response);
                    }
                },
                "error": function (response) {
                    console.log(response);
                }
            });
        }

        function Ajax_Modificar_Resul() {

            let _bol_Omitir = $("#chk_Omitir_Mod").prop("checked");

            if (_bol_Omitir == true) {
                _bol_Omitir = 1;
            } else {
                _bol_Omitir = 0;
            }

            var Data_Par = JSON.stringify({
                ID_TP_ACCION: $("#mdl_Slt_Accion_Mod").val(),
                COMENTARIO: $("#mdl_Txt_Com_Mod").val(),
                OMITIDO: _bol_Omitir,
                ID_RESUL: Mx_20[_MOD_I].ID_QC_RESULTADO
            });

            $.ajax({
                "type": "POST",
                "url": "C_Graph.aspx/IRIS_UPDATE_QC_RESULTADO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        if (_bol_F_N == 1) {
                            Ajax_20();
                        } else if (_bol_F_N == 2) {
                            Ajax_Buscar();
                        }
                    } else {
                        console.log(response);
                    }
                },
                "error": function (response) {
                    console.log(response);
                }
            });
        }

        let Mx_20 = [{
            QC_RESUL_VALOR_1: "",
            QC_RESUL_VALOR_2: "",
            QC_RESUL_VALOR_3: "",
            QC_RESUL_HORA: "",
            QC_COMENTARIOS: "",
            ID_QC_RESULTADO: "",
            ID_TP_QC_ACCION: "",
            QC_RESUL_OMITIDO: ""
        }];
        function Ajax_Buscar() {

            _bol_F_N = 2;

            var Data_Par = JSON.stringify({
                ID_ANA: _ID_ANA,
                ID_LOTE: _ID_LOTE,
                ID_DET: _ID_DET,
                DESDE: $("#fecha").val(),
                HASTA: $("#fecha2").val()
            });

            $.ajax({
                "type": "POST",
                "url": "C_Graph.aspx/IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_FECHA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_20 = json_receiver;

                        console.log(Mx_20);
                        Ajax_Fill_Arr_20();
                        let Iv_G = setInterval(() => {
                            if (Mx_Fijos.length > 0) {
                                if (Mx_Fijos[0].REL_ADL_LI_F != "") {
                                    Ajax_Fill_Graph();
                                    clearInterval(Iv_G);
                                }
                            }
                        }, 500);
                    } else {
                        console.log(response);
                        Mx_20 = [];
                        Arr_Res_20 = [];
                    }
                },
                "error": function (response) {
                    console.log(response);
                    Mx_20 = [];
                    Arr_Res_20 = [];
                }
            });
        }
        function Ajax_20() {

            _bol_F_N = 1;

            modal_show();
            var Data_Par = JSON.stringify({
                ID_ANA: _ID_ANA,
                ID_LOTE: _ID_LOTE,
                ID_DET: _ID_DET,
                FECHA: _FEC,
                N: _N
            });

            $.ajax({
                "type": "POST",
                "url": "C_Graph.aspx/IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_20 = json_receiver;

                        //console.log(Mx_20);
                        Ajax_Fill_Arr_20();
                        let Iv_G = setInterval(() => {
                            if (Mx_Fijos.length > 0) {
                                if (Mx_Fijos[0].REL_ADL_LI_F != "") {
                                    $("#mdl_Ana").val(Mx_Fijos[0].QC_ANA_DESC);
                                    $("#mdl_Lote").val(Mx_Fijos[0].QC_LOTE_DESC);
                                    $("#mdl_Det").val(Mx_Fijos[0].QC_DET_DESC);
                                    Ajax_Fill_Graph();
                                    clearInterval(Iv_G);
                                }
                            }
                        }, 500);
                    } else {
                        console.log(response);
                        Mx_20 = [];
                        Arr_Res_20 = [];
                    }
                },
                "error": function (response) {
                    console.log(response);
                    Mx_20 = [];
                    Arr_Res_20 = [];
                }
            });
        }
        function Ajax_Fill_Arr_20() {
            let _cont = 0;
            $("#DataTable tbody").empty();
            for (i = 0; i < Mx_20.length; i++) {

                if ($("#rbt_2").prop("checked") == true && Mx_20[i].QC_RESUL_OMITIDO != 1 || $("#rbt_1").prop("checked") == true) {
                    _cont += 1;
                    $("#DataTable tbody").append(
                        $("<tr>", {
                            "class": "manito",
                            "data-id": i
                        }).append(
                            $("<td>", { "class": "textoReducido" }).text(_cont),
                            $("<td>", { "class": "textoReducido" }).text(() => {
                                let _fret = Mx_20[i].QC_RESUL_HORA;
                                _fret = moment(_fret).format("DD-MM-YYYY HH:mm:ss");
                                return _fret
                            }),
                            $("<td>", { "class": "textoReducido" }).text(() => {
                                if (Mx_20[i].QC_RESUL_VALOR_1 != "") {

                                    let _Dec = 2

                                    let _f_v = parseFloat(Mx_20[i].QC_RESUL_VALOR_1.replace(",", "."));
                                    _f_v = _f_v.toFixed(_Dec).toString().replace(".", ",");

                                    return _f_v;
                                }
                                else if (Mx_20[i].QC_RESUL_VALOR_2 != "") {
                                    let _Dec = 2

                                    let _f_v = parseFloat(Mx_20[i].QC_RESUL_VALOR_2.replace(",", "."));
                                    _f_v = _f_v.toFixed(_Dec).toString().replace(".", ",");

                                    return _f_v;
                                }
                                else {
                                    let _Dec = 2

                                    let _f_v = parseFloat(Mx_20[i].QC_RESUL_VALOR_3.replace(",", "."));
                                    _f_v = _f_v.toFixed(_Dec).toString().replace(".", ",");

                                    return _f_v;
                                }
                            }),
                            $("<td>", { "class": "textoReducido", "id": "west_" + i }).text(""),
                            $("<td>", { "class": "textoReducido" }).text(Mx_20[i].QC_COMENTARIOS)
                        )
                    );
                    if (Mx_20[i].QC_RESUL_OMITIDO == 1) {
                        $("#DataTable tbody tr[data-id=" + i + "]").css("color", "red");
                    }
                }
            }
            Ajax_Fill_Var();

            $("#DataTable tbody tr").dblclick((e) => {
                _MOD_I = $(e.currentTarget).attr("data-id");

                $("#mdl_Ana_Mod").val(Mx_Fijos[0].QC_ANA_DESC);
                $("#mdl_Lote_Mod").val(Mx_Fijos[0].QC_LOTE_DESC);
                $("#mdl_Det_Mod").val(Mx_Fijos[0].QC_DET_DESC);

                $("#mdl_Txt_Res_Mod").val(Mx_20[_MOD_I].QC_RESUL_VALOR_1);
                $("#mdl_Txt_Com_Mod").val(Mx_20[_MOD_I].QC_COMENTARIOS);
                let _f_mod = moment(Mx_20[_MOD_I].QC_RESUL_HORA).format("DD-MM-YYYY");
                $("#fecha4").val(_f_mod);
                $("#mdl_Slt_Accion_Mod").val(Mx_20[_MOD_I].ID_TP_QC_ACCION);

                if (Mx_20[_MOD_I].QC_RESUL_OMITIDO == 1) {
                    $("#chk_Omitir_Mod").prop("checked", true);
                } else {
                    $("#chk_Omitir_Mod").prop("checked", false);
                }

                $("#mdl_Mod_Resul").modal("show");
            }).one();
        }
        function Ajax_Fill_Var() {
            let _Cont = Mx_20.length;
            Arr_Res_20 = [];
            Mx_20.forEach(aah=> {
                if ($("#rbt_2").prop("checked") == true && aah.QC_RESUL_OMITIDO != 1 || $("#rbt_1").prop("checked") == true) {
                    if (aah.QC_RESUL_VALOR_1 != "") {
                        Arr_Res_20.push(parseFloat(aah.QC_RESUL_VALOR_1.replace(',', '.')));
                    }
                }
            });

            let _Dec = 2
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

            $("#txt_n_v").val(_Cont);
            $("#txt_ma_v").val(_f_max);
            $("#txt_mi_v").val(_f_min);
            $("#txt_me_v").val(_f_med);
            $("#txt_ds_v").val(_f_desv);
            $("#txt_cv_v").val(_f_cv);

            Ajax_Fill_Graph();

        }

        let Mx_Accion = [{
            ID_TP_QC_ACCION: "",
            TP_QC_DESC: ""
        }]
        function Ajax_Accion() {
            $.ajax({
                "type": "POST",
                "url": "C_Graph.aspx/IRIS_QC_BUSCA_TP_ACCION_ACTIVAS",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Accion = json_receiver;
                        //console.log(Mx_20);
                        Ajax_Fill_Accion();
                    } else {
                        console.log(response);
                        Mx_Accion = [];
                    }
                },
                "error": function (response) {
                    console.log(response);
                    Mx_Accion = [];
                }
            });
        }
        function Ajax_Fill_Accion() {
            $("#mdl_Slt_Accion").empty();

            for (y = 0; y < Mx_Accion.length; ++y) {
                $("<option>", {
                    "value": Mx_Accion[y].ID_TP_QC_ACCION
                }).text(Mx_Accion[y].TP_QC_DESC).appendTo("#mdl_Slt_Accion");
            }
            $("#mdl_Slt_Accion").val(18);

            $("#mdl_Slt_Accion_Mod").empty();

            for (y = 0; y < Mx_Accion.length; ++y) {
                $("<option>", {
                    "value": Mx_Accion[y].ID_TP_QC_ACCION
                }).text(Mx_Accion[y].TP_QC_DESC).appendTo("#mdl_Slt_Accion_Mod");
            }
            $("#mdl_Slt_Accion_Mod").val(18);
        }

        let Mx_Fijos = [{
            REL_ADL_LI_F: "",
            REL_ADL_LS_F: "",
            REL_ADL_MEDIA_F: "",
            REL_ADLL_DESV_F: "",
            REL_ADL_CV_F: "",
            REL_ADL_CANT_F: "",
            QC_ANA_DESC: "",
            QC_DET_DESC: "",
            QC_LOTE_DESC: ""
        }]
        function Ajax_Fijos() {

            console.log("Ajax Fijos");
            var Data_Par = JSON.stringify({
                ID_ANA: _ID_ANA,
                ID_LOTE: _ID_LOTE,
                ID_DET: _ID_DET
            });

            $.ajax({
                "type": "POST",
                "url": "C_Graph.aspx/IRIS_QC_BUSCA_REL_ANA_DET_LOTE_POR_PARAM",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Fijos = json_receiver;
                        //console.log(Mx_20);
                        if (Mx_Fijos.length > 0) {
                            Ajax_Fill_Fijos();
                            Hide_Modal();
                        } else {
                            Hide_Modal();
                        }
                        
                    } else {
                        Hide_Modal();
                        console.log(response);
                        Mx_Fijos = [];
                    }
                },
                "error": function (response) {
                    Hide_Modal();
                    console.log(response);
                    Mx_Fijos = [];
                }
            });
        }
        function Ajax_Fill_Fijos() {

            console.log("Fill Fijos");

            _Title = Mx_Fijos[0].QC_ANA_DESC + " - " + Mx_Fijos[0].QC_LOTE_DESC + " - " + Mx_Fijos[0].QC_DET_DESC;

            let _Dec = 2

            let _f_max = parseFloat(Mx_Fijos[0].REL_ADL_LS_F.replace(",", "."));
            _f_max = _f_max.toFixed(_Dec).toString().replace(".", ",");
            let _f_min = parseFloat(Mx_Fijos[0].REL_ADL_LI_F.replace(",", "."));
            _f_min = _f_min.toFixed(_Dec).toString().replace(".", ",");
            let _f_med = parseFloat(Mx_Fijos[0].REL_ADL_MEDIA_F.replace(",", "."));
            _f_med = _f_med.toFixed(_Dec).toString().replace(".", ",");
            let _f_desv = parseFloat(Mx_Fijos[0].REL_ADLL_DESV_F.replace(",", "."));
            _f_desv = _f_desv.toFixed(_Dec).toString().replace(".", ",");
            let _f_cv = parseFloat(Mx_Fijos[0].REL_ADL_CV_F.replace(",", "."));
            _f_cv = _f_cv.toFixed(_Dec).toString().replace(".", ",");
            let _f_cant = parseFloat(Mx_Fijos[0].REL_ADL_CANT_F.replace(",", "."));
            //_f_cant = _f_cant.toFixed(_Dec).toString().replace(".", ",");

            

            $("#txt_ma_f").val(Res_NaN(_f_max));
            $("#txt_mi_f").val(Res_NaN(_f_min));
            $("#txt_me_f").val(Res_NaN(_f_med));
            $("#txt_ds_f").val(Res_NaN(_f_desv));
            $("#txt_cv_f").val(Res_NaN(_f_cv));
            $("#txt_n_f").val(Res_NaN(_f_cant));
        }

        function Res_NaN(x) {
            console.log(x);
            if (x == "NaN"|| isNaN(x) == true) {
                return "";
            } else {
                return x;
            }
        }

        function Ajax_Westgard(_3s_i, _2s_i, _1s_i, _me, _1s_s, _2s_s, _3s_s, _de) {

            console.log("Ajax Westgard");

            //console.log(_me);
            //console.log("Westgard");

            let Arr_1_2s = [];

            let _de_4i = (4 * _de) * (-1); // -R4S
            let _de_4s = (4 * _de); // +R4S


            for (i = 0; i < Mx_20.length; i++) {
                if ($("#rbt_2").prop("checked") == true && Mx_20[i].QC_RESUL_OMITIDO != 1 || $("#rbt_1").prop("checked") == true) {
                    $("#west_" + i).css("font-weight", "inherit").text("Normal"); // Todos normales antes de realizar calculos
                    let _res = parseFloat(Mx_20[i].QC_RESUL_VALOR_1.replace(",", "."));
                    //console.group("G1");
                    //console.log(Mx_20[i].QC_RESUL_VALOR_1);
                    //console.log(_res);
                    //console.log(_1s_s);
                    //console.log(_1s_i);
                    //console.groupEnd();
                    //if (_res >= _1s_i && _res <= _1s_s) { //res mayor igual a -1s y res menor igual a +1s
                    //    $("#west_" + i).text("Normal");
                    //} else
                    if (_res > _3s_i && _res <= _2s_i) { //res mayor a -3s y menor igual a -2s

                        Arr_1_2s.push({ index: i, tipo: "menor" });
                        //console.log(Arr_1_2s);

                    } else if (_res < _3s_s && _res >= _2s_s) { //res menor a +3s y mayor igual a +2s

                        Arr_1_2s.push({ index: i, tipo: "mayor" });
                        //console.log(Arr_1_2s);
                    }
                }
            }

            //<<<<<<<<<< 10x >>>>>>>>>>//
            if ($("#ru_10x").prop("checked") == true) {
                for (i = 0; i < Mx_20.length; i++) {
                    if ($("#rbt_2").prop("checked") == true && Mx_20[i].QC_RESUL_OMITIDO != 1 || $("#rbt_1").prop("checked") == true) {
                        if (i >= 9) {
                            let _10x_count = 0;
                            let _10x_tipo = "";
                            //console.log(i + " " + (i - 9));
                            for (x = i ; x >= 0 ; x--) {

                                let _res = parseFloat(Mx_20[x].QC_RESUL_VALOR_1.replace(",", "."));
                                if (_res < _me) {
                                    if ($("#rbt_2").prop("checked") == true && Mx_20[x].QC_RESUL_OMITIDO != 1 || $("#rbt_1").prop("checked") == true) {
                                        if (_10x_count == 0) {
                                            _10x_count = 1;
                                            _10x_tipo = "menor";
                                        } else {
                                            if (_10x_tipo == "menor") {
                                                //console.log("Menor " + i + " Cont:" + _10x_count + " Res: " + Mx_20[x].QC_RESUL_VALOR_1);
                                                _10x_count += 1;
                                                if (_10x_count == 10) {
                                                    $("#west_" + i).css("font-weight", "600").text("10-x");
                                                    _10x_count = 0;
                                                    _10x_tipo = "";
                                                    x = -1;
                                                }
                                            }
                                            else {
                                                _10x_count = 0;
                                                _10x_tipo = "";
                                                x = -1;
                                            }
                                        }
                                    }
                                } else if (_res >= _me) {
                                    if ($("#rbt_2").prop("checked") == true && Mx_20[x].QC_RESUL_OMITIDO != 1 || $("#rbt_1").prop("checked") == true) {
                                        if (_10x_count == 0) {
                                            _10x_count = 1;
                                            _10x_tipo = "mayor";
                                        } else {
                                            if (_10x_tipo == "mayor") {
                                                _10x_count += 1;
                                                //console.log("Mayor " + i + " Cont:" + _10x_count + " Res: " + Mx_20[x].QC_RESUL_VALOR_1);
                                                if (_10x_count == 10) {
                                                    $("#west_" + i).css("font-weight", "600").text("10-x");
                                                    _10x_count = 0;
                                                    _10x_tipo = "";
                                                    x = -1;
                                                }
                                            }
                                            else {
                                                _10x_count = 0;
                                                _10x_tipo = "";
                                                x = -1;
                                            }
                                        }
                                    }
                                } else {
                                    _10x_count = 0;
                                    _10x_tipo = "";
                                    x = -1;
                                }
                            }
                        }
                    }
                }
            }
            //<<<<<<<<<< 4-1s >>>>>>>>>>//

            if ($("#ru_41s").prop("checked") == true) {
                for (i = 0; i < Mx_20.length; i++) {
                    if ($("#rbt_2").prop("checked") == true && Mx_20[i].QC_RESUL_OMITIDO != 1 || $("#rbt_1").prop("checked") == true) {
                        if (i >= 3) {
                            let _41s_count = 0;
                            let _41s_tipo = "";
                            for (x = i ; x >= 0 ; x--) {

                                let _res = parseFloat(Mx_20[x].QC_RESUL_VALOR_1.replace(",", "."));
                                if (_res <= _1s_i) {
                                    //console.log(_res+" "+_1s_i);
                                    if ($("#rbt_2").prop("checked") == true && Mx_20[x].QC_RESUL_OMITIDO != 1 || $("#rbt_1").prop("checked") == true) {
                                        if (_41s_count == 0) {
                                            _41s_count = 1;
                                            _41s_tipo = "menor";
                                        } else {
                                            if (_41s_tipo == "menor") {
                                                _41s_count += 1;
                                                //console.log("Menor " + i + " Cont:" + _41s_count + " Res: " + Mx_20[x].QC_RESUL_VALOR_1);
                                                if (_41s_count == 4) {
                                                    $("#west_" + i).css("font-weight", "600").text("4-1s");
                                                    _41s_count = 0;
                                                    _41s_tipo = "";
                                                    x = -1;
                                                }
                                            }
                                            else {
                                                _41s_count = 0;
                                                _41s_tipo = "";
                                                x = -1;
                                            }
                                        }
                                    }
                                } else if (_res >= _1s_s) {
                                    //console.log(_res + " " + _1s_s);
                                    if ($("#rbt_2").prop("checked") == true && Mx_20[x].QC_RESUL_OMITIDO != 1 || $("#rbt_1").prop("checked") == true) {
                                        if (_41s_count == 0) {
                                            _41s_count = 1;
                                            _41s_tipo = "mayor";
                                        } else {
                                            if (_41s_tipo == "mayor") {
                                                _41s_count += 1;
                                                //console.log("Mayor " + i + " Cont:" + _41s_count + " Res: " + Mx_20[x].QC_RESUL_VALOR_1);
                                                if (_41s_count == 4) {
                                                    $("#west_" + i).css("font-weight", "600").text("4-1s");
                                                    _41s_count = 0;
                                                    _41s_tipo = "";
                                                    x = -1;
                                                }
                                            }
                                            else {
                                                _41s_count = 0;
                                                _41s_tipo = "";
                                                x = -1;
                                            }
                                        }
                                    }
                                } else {
                                    _41s_count = 0;
                                    _41s_tipo = "";
                                    x = -1;
                                }
                            }
                        }
                    }
                }
            }

            //<<<<<<<<<< R4s >>>>>>>>>>//

            if ($("#ru_R4s").prop("checked") == true) {
                for (i = 0; i < Mx_20.length; i++) { //R4s
                    if ($("#rbt_2").prop("checked") == true && Mx_20[i].QC_RESUL_OMITIDO != 1 || $("#rbt_1").prop("checked") == true) {
                        if (i > 0) {
                            let _i_su = i; // indice actual
                            let _i_an; // indice anterior

                            for (x = i - 1; x >= 0; x--) { // recorrer desde el indice actual, hacia atras
                                //console.log("X: " + x);
                                if ($("#rbt_2").prop("checked") == true && Mx_20[x].QC_RESUL_OMITIDO != 1 || $("#rbt_1").prop("checked") == true) {
                                    _i_an = x; //obtener indice anterior
                                    //console.log(Mx_20[x].QC_RESUL_VALOR_1);
                                    //console.log(x);
                                    x = -1; //finalizar ciclo For

                                }
                            }

                            let _res_su = parseFloat(Mx_20[_i_su].QC_RESUL_VALOR_1.replace(",", "."));
                            let _res_an = parseFloat(Mx_20[_i_an].QC_RESUL_VALOR_1.replace(",", "."));

                            let _res_Dif = (_res_su - _res_an); // diferencia de resultados

                            //console.log("AN: " + _i_an + "  (" + _res_an + ") | SU: " + _i_su + "  (" + _res_su + ") Res: " + _res_Dif + " -4R: " + _de_4i + " +4R: " + _de_4s);

                            //console.log(_res_Dif);
                            //console.log(_de_4i);
                            //console.log(_de_4s);
                            if (_res_Dif >= _de_4s || _res_Dif <= _de_4i) { // si el resultado es mayor igual a +R-4S o si el resultado es menor igual a -R-4s
                                //console.log("cumple mayor");
                                $("#west_" + _i_su).css("font-weight", "600").text("R-4s"); //se marca el actual como R-4s
                                //$("#west_" + _i_an).text("R-4s"); //se marca el anterior como R-4s
                            }
                        }
                    }
                }
            }

            //<<<<<<<<<< 1-2s 2-2s >>>>>>>>>>//

            if (Arr_1_2s.length > 1) { // Calcular si el anterior es 2-2s
                //console.log(">1");
                for (i = 0; i < Arr_1_2s.length; i++) {
                    if ($("#ru_12s").prop("checked") == true) {
                        $("#west_" + Arr_1_2s[0].index).css("font-weight", "600").text("1-2s"); //Primero 1-2s
                    }
                    //console.log("foreach");
                    if (i > 0) {
                        let i_an, i_su, t_an, t_su;

                        i_an = Arr_1_2s[i - 1].index;
                        i_su = Arr_1_2s[i].index;
                        t_an = Arr_1_2s[i - 1].tipo;
                        t_su = Arr_1_2s[i].tipo;

                        if ((i_su - i_an) == 1 && t_an == t_su) { //Calcular si el anterior tiene el mismo typo (menor o mayor)
                            //console.log(i_an + ": " + Mx_20[i_an].QC_RESUL_VALOR_1 + " " + i_su + ": " + Mx_20[i_su].QC_RESUL_VALOR_1);
                            if ($("#ru_22s").prop("checked") == true) {
                                //$("#west_" + i_an).text("2-2s"); // 2-2s anterior
                                $("#west_" + i_su).css("font-weight", "600").text("2-2s"); // 2-2s actual
                            }
                        } else {
                            if ($("#ru_12s").prop("checked") == true) {

                                if ($("#west_" + i_su).text() == "Normal") { //si el actual no es del mismo tipo 1-2s
                                    $("#west_" + i_su).css("font-weight", "600").text("1-2s");
                                }
                                if ($("#west_" + i_an).text() == "Normal") { //si el anterior no es del mismo tipo 1-2s
                                    // $("#west_" + i_an).text("1-2s");
                                }
                            }
                        }
                    }
                }
            }

            //<<<<<<<<<< 1-3s >>>>>>>>>>//

            if ($("#ru_13s").prop("checked") == true) {
                for (i = 0; i < Mx_20.length; i++) {
                    let _res = parseFloat(Mx_20[i].QC_RESUL_VALOR_1.replace(",", "."));
                    if (_res <= _3s_i || _res >= _3s_s) { //resultado menor igual -3s o mayor igual a +3s
                        $("#west_" + i).css("font-weight", "700").text("1-3s");
                    }
                }
            }
        }

        function Ajax_Fill_Graph() {

            console.log("Fill Graph");

            let _ma, _mi, _me, _de, _dv;
            let _VF = $("input[name=rbt_FV]:checked").val();
            let agr_CAT = [], labels_TXT = [];
            let _3s_i, _3s_s, _2s_i, _2s_s, _1s_i, _1s_s, _x;
            let _VF_C = "";

            for (i = 0; i < Arr_Res_20.length; i++) {
                agr_CAT.push(i + 1);
            }
            let _Dec = 2;

            if (_VF == "F") {
                _VF_C = "f";
            }
            else {
                _VF_C = "v";
            }

            _ma = $("#txt_ma_" + _VF_C).val();
            _ma = parseFloat(_ma.replace(",", "."));
            _mi = $("#txt_mi_" + _VF_C).val();
            _mi = parseFloat(_mi.replace(",", "."));
            _me = $("#txt_me_" + _VF_C).val();
            _me = parseFloat(_me.replace(",", "."));
            _de = $("#txt_ds_" + _VF_C).val();
            _de = parseFloat(_de.replace(",", "."));
            _dv = $("#txt_cv_" + _VF_C).val();
            _dv = parseFloat(_dv.replace(",", "."));

            _3s_i = _me - (3 * _de);

            _2s_i = _me - (2 * _de);

            _1s_i = _me - (1 * _de);

            _3s_s = _me + (3 * _de);

            _2s_s = _me + (2 * _de);

            _1s_s = _me + (1 * _de);

            Ajax_Westgard(_3s_i, _2s_i, _1s_i, _me, _1s_s, _2s_s, _3s_s, _de);

            labels_Plot = [_3s_i, _2s_i, _1s_i, _me, _1s_s, _2s_s, _3s_s];

            let _3s_i_str = _3s_i.toFixed(2).replace(".", ",");
            let _2s_i_str = _2s_i.toFixed(2).replace(".", ",");
            let _1s_i_str = _1s_i.toFixed(2).replace(".", ",");
            let _3s_s_str = _3s_s.toFixed(2).replace(".", ",");
            let _2s_s_str = _2s_s.toFixed(2).replace(".", ",");
            let _1s_s_str = _1s_s.toFixed(2).replace(".", ",");
            let _me_str = _me.toFixed(2).replace(".", ",");

            labels_TXT = [_3s_i_str + " (-3s)", _2s_i_str + " (-2s)", _1s_i_str + " (-1s)", _me_str + " (X)", _1s_s_str + " (+1s)", _2s_s_str + " (+2s)", _3s_s_str + " (+3s)"];
            //console.log(labels_Plot);

            buildGraph();
            objGraph.update({
                chart: {
                    animation: false
                },
                yAxis: {
                    title: {
                        text: ""
                    },
                    tickPositioner: function () {
                        return labels_Plot;
                    },
                    labels: {
                        formatter: function () {
                            if (this.isFirst) {
                                i = -1
                            }
                            i++;
                            //console.log(labels_TXT[i] + " " + i);
                            if (labels_TXT[i] == "") {
                                return "";
                            } else {
                                return labels_TXT[i];
                            }
                        }
                    }
                    ,
                    plotLines: [
                    {
                        //+me
                        color: '#000000',
                        width: 2,
                        value: _me
                    },
                    {
                        //+1s
                        color: '#7FFF00',
                        width: 2,
                        value: _me + _de,
                        dashStyle: "dash"
                    },
                    {
                        //-1s
                        color: '#7FFF00',
                        width: 2,
                        value: _me - _de,
                        dashStyle: "dash"
                    },
                    {
                        //+2s
                        color: '#ecf022',
                        width: 2,
                        value: _me + (_de * 2),
                        dashStyle: "shortdash"
                    },
                    {
                        //-2s
                        color: '#ecf022',
                        width: 2,
                        value: _me - (_de * 2),
                        dashStyle: "shortdash"
                    },
                    {
                        //+3s
                        color: '#FF0000',
                        width: 2,
                        value: _me + (_de * 3)
                    },
                    {
                        //-3s
                        color: '#FF0000',
                        width: 2,
                        value: _me - (_de * 3)
                    }
                    ]
                },
                xAxis: {
                    categories: agr_CAT
                },
                series: [
                    {
                        name: "Resultado",
                        data: Arr_Res_20,
                        showInLegend: false
                    }
                ]
            });
            Hide_Modal();
        }

        function buildGraph() {

            console.log("Build Graph");

            $("#divGraph").empty();
            objGraph = Highcharts.chart("divGraph", {
                chart: {
                    animation: false
                },
                plotOptions: {
                    series: {
                        line: {
                            dataLabels: {
                                enabled: true
                            }
                        },
                        enableMouseTracking: true,
                        animation: false
                    }
                },
                legend: {
                    align: "right",
                    verticalAlign: "middle",
                    layout: "vertical"
                },
                responsive: {
                    rules: [{
                        condition: {
                            maxWidth: 500
                        },
                        chartOptions: {
                            legend: {
                                layout: "horizontal",
                                align: "center",
                                verticalAlign: "bottom"
                            }
                        }
                    }]
                },
                title: {
                    text: _Title
                },
                series: [
                    {
                        name: "Resultado",
                        data: []
                    }
                ]
            });
        }
    </script>
    <style>
        .f-inline {
            display: flex;
        }

        .form_sm {
            width: 5vw;
            height: 3.5vh;
        }

        .form_sm_h {
            height: 3.5vh;
            font-size: 15px;
            font-weight: 600;
        }

        .btn-sm {
            line-height: 1 !important;
        }

        .form-mini {
            padding-left: .25rem !important;
            padding-right: .25rem !important;
            font-weight: 600;
            height: 3.5vh;
        }

        .bg_num {
            background-color: #cae6ff !important;
        }

        .bg_mm {
            background-color: #d1f7c3 !important;
        }

        .bg_xdecv {
            background-color: #ffd3d3 !important;
        }

        .custom-control-input:focus + .custom-control-indicator {
            box-shadow: none !important;
        }

        .custom-control-description::selection {
            color: inherit;
        }

        .custom-checkbox:hover {
            cursor: pointer;
        }

        .custom-control {
            margin-right: 0;
        }

        #DataTable tbody td::selection {
            color: inherit;
            cursor: pointer;
        }

        .manito {
            cursor: pointer;
        }
    </style>

    <div class="modal" tabindex="-1" role="dialog" id="mdl_Ing_Resul">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header text-center">
                    <h5 class="modal-title">Ingreso de Resultados</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg">
                            <label for="mdl_Ana">Analizador:</label>
                            <input type="text" id="mdl_Ana" class="form-control form-control-sm" readonly />
                        </div>
                        <div class="col-lg">
                            <label for="mdl_Lote">Lote:</label>
                            <input type="text" id="mdl_Lote" class="form-control form-control-sm" readonly />
                        </div>
                        <div class="col-lg">
                            <label for="mdl_Det">Determinación:</label>
                            <input type="text" id="mdl_Det" class="form-control form-control-sm" readonly />
                        </div>
                    </div>
                    <hr />
                    <div class="row mt-3">
                        <div class="col-lg">
                            <label for="mdl_Txt_Res">Resultado:</label>
                            <input type="text" class="form-control form-control-sm" id="mdl_Txt_Res" />
                        </div>
                        <div class="col-lg">
                            <label for="fecha3">Fecha:</label>
                            <div class='input-group date' id='Txt_Date03'>
                                <input type='text' id="fecha3" class="form-control form-control-sm" readonly="true" placeholder="Fecha..." style="height: calc(1.8125rem + 2px); background-color: inherit;" />
                                <span class="input-group-addon" style="height: calc(1.8125rem + 2px); background-color: inherit;">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg">
                            <label for="mdl_Slt_Accion">Acción:</label>
                            <select class="form-control form-control-sm" id="mdl_Slt_Accion"></select>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-lg">
                            <label for="mdl_Txt_Com">Comentario:</label>
                            <textarea class="form-control" id="mdl_Txt_Com"></textarea>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="mdl_Btn_Guardar">Guardar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" tabindex="-1" role="dialog" id="mdl_Mod_Resul">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header text-center">
                    <h5 class="modal-title">Omitir Resultados</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg">
                            <label for="mdl_Ana_Mod">Analizador:</label>
                            <input type="text" id="mdl_Ana_Mod" class="form-control form-control-sm" readonly />
                        </div>
                        <div class="col-lg">
                            <label for="mdl_Lote_Mod">Lote:</label>
                            <input type="text" id="mdl_Lote_Mod" class="form-control form-control-sm" readonly />
                        </div>
                        <div class="col-lg">
                            <label for="mdl_Det_Mod">Determinación:</label>
                            <input type="text" id="mdl_Det_Mod" class="form-control form-control-sm" readonly />
                        </div>
                    </div>
                    <hr />
                    <div class="row mt-3">
                        <div class="col-lg">
                            <label for="mdl_Txt_Res">Resultado:</label>
                            <input type="text" class="form-control form-control-sm" id="mdl_Txt_Res_Mod" readonly />
                        </div>
                        <div class="col-lg">
                            <label for="fecha3">Fecha:</label>
                            <div class='input-group date' id='Txt_Date04'>
                                <input type='text' id="fecha4" class="form-control form-control-sm" readonly="true" placeholder="Fecha..." style="height: calc(1.8125rem + 2px);" />
                                <span class="input-group-addon" style="height: calc(1.8125rem + 2px);">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg">
                            <label for="mdl_Slt_Accion">Acción:</label>
                            <select class="form-control form-control-sm" id="mdl_Slt_Accion_Mod"></select>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-lg">
                            <label for="mdl_Txt_Com">Comentario:</label>
                            <textarea class="form-control" id="mdl_Txt_Com_Mod"></textarea>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-lg text-center">
                            <label class="custom-control custom-checkbox">
                                <input type="checkbox" class="custom-control-input" id="chk_Omitir_Mod">
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">Omitir Resultado</span>
                            </label>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="mdl_Btn_Guardar_Mod">Modificar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4">
            <div class="card border-bar">
                <div class="card-header text-center bg-bar">
                    <h5 class="card-title">Resultados</h5>
                </div>
                <div class="card-body pl-1 pr-1 pb-1 pt-2">
                    <%--Buscar--%>
                    <div class="row pl-2 pr-2">
                        <div class="col-lg pr-1">
                            <div class="f-inline">
                                <label for="fecha2">Desde:&nbsp;</label>
                                <div class='input-group date' id='Txt_Date01'>
                                    <input type='text' id="fecha" class="form-control form-control-sm form_sm_h p-1" readonly="true" placeholder="Desde..." />
                                    <span class="input-group-addon form_sm_h pl-1 pr-1">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg pr-1">
                            <div class="f-inline">
                                <label for="fecha2">Hasta:&nbsp;</label>
                                <div class='input-group date' id='Txt_Date02'>
                                    <input type='text' id="fecha2" class="form-control form-control-sm form_sm_h p-1" readonly="true" placeholder="Hasta..." />
                                    <span class="input-group-addon form_sm_h pl-1 pr-1">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <button type="button" class="btn btn-primary btn-sm btn-block mt-0" id="btn_Buscar"><i class="fa fa-search fa-fw"></i>Buscar</button>
                        </div>
                    </div>
                    <%--Rbt--%>
                    <div class="row pl-2 pr-2 mt-0 text-center">
                        <div class="col-lg">
                            <div class="form-check m-0">
                                <input type="radio" class="manito" name="rbt_TC" id="rbt_1" value="2" checked>
                                <label class="manito" for="rbt_1">
                                    Todos
                                </label>
                            </div>
                        </div>
                        <div class="col-lg text-center">
                            <div class="form-check m-0">
                                <input type="radio" class="manito" name="rbt_TC" id="rbt_2" value="2" checked>
                                <label class="manito" for="rbt_2">
                                    Valor Recalculado
                                </label>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <button type="button" class="btn btn-warning btn-sm btn-block m-0 p-1" id="btn_Ing_Resul"><i class="fa fa-plus fa-fw"></i>Ing Resul</button>
                        </div>
                    </div>
                    <%--Tabla--%>
                    <div style="height: 48vh; overflow: auto;">
                        <table id="DataTable" class="table table-hover table-striped table-iris">
                            <thead>
                                <tr>
                                    <th>N°
                                    </th>
                                    <th>Fecha
                                    </th>
                                    <th>Resultado
                                    </th>
                                    <th>Westgard
                                    </th>
                                    <th>Comentario
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                    <%--Datos--%>
                    <div class="row mt-2">
                        <div class="col-lg-2">
                            Datos
                        </div>
                        <div class="col-lg text-center">
                            <b>N°</b>
                        </div>
                        <div class="col-lg text-center">
                            <i class="fa fa-arrow-up"></i>
                        </div>
                        <div class="col-lg text-center">
                            <i class="fa fa-arrow-down"></i>
                        </div>
                        <div class="col-lg text-center">
                            <b>X</b>
                        </div>
                        <div class="col-lg text-center">
                            <b>DS</b>
                        </div>
                        <div class="col-lg text-center">
                            <b>CV</b>
                        </div>
                        <div class="col-lg">
                        </div>
                    </div>
                    <%--Fijos--%>
                    <div class="row mt-2">
                        <div class="col-lg-2">
                            Fijos
                        </div>
                        <div class="col-lg pl-2 pr-2">
                            <input class="form-control form-control-sm form-mini bg_num" type="text" id="txt_n_f" readonly />
                        </div>
                        <div class="col-lg pl-2 pr-2">
                            <input class="form-control form-control-sm form-mini bg_mm" type="text" id="txt_ma_f" readonly />
                        </div>
                        <div class="col-lg pl-2 pr-2">
                            <input class="form-control form-control-sm form-mini bg_mm" type="text" id="txt_mi_f" readonly />
                        </div>
                        <div class="col-lg pl-2 pr-2">
                            <input class="form-control form-control-sm form-mini bg_xdecv" type="text" id="txt_me_f" readonly />
                        </div>
                        <div class="col-lg pl-2 pr-2">
                            <input class="form-control form-control-sm form-mini bg_xdecv" type="text" id="txt_ds_f" readonly />
                        </div>
                        <div class="col-lg pl-2 pr-2">
                            <input class="form-control form-control-sm form-mini bg_xdecv" type="text" id="txt_cv_f" readonly />
                        </div>
                        <div class="col-lg pl-1">
                            <input class="manito" type="radio" name="rbt_FV" id="rbt_F" value="F" checked>
                            <label class="manito" for="rbt_F">
                                F
                            </label>
                        </div>
                    </div>
                    <%--Variables--%>
                    <div class="row mt-2">
                        <div class="col-lg-2">
                            Var
                        </div>
                        <div class="col-lg pl-2 pr-2">
                            <input class="form-control form-control-sm form-mini bg_num" type="text" id="txt_n_v" readonly />
                        </div>
                        <div class="col-lg pl-2 pr-2">
                            <input class="form-control form-control-sm form-mini bg_mm" type="text" id="txt_ma_v" readonly />
                        </div>
                        <div class="col-lg pl-2 pr-2">
                            <input class="form-control form-control-sm form-mini bg_mm" type="text" id="txt_mi_v" readonly />
                        </div>
                        <div class="col-lg  pl-2 pr-2">
                            <input class="form-control form-control-sm form-mini bg_xdecv" type="text" id="txt_me_v" readonly />
                        </div>
                        <div class="col-lg pl-2 pr-2">
                            <input class="form-control form-control-sm form-mini bg_xdecv" type="text" id="txt_ds_v" readonly />
                        </div>
                        <div class="col-lg pl-2 pr-2">
                            <input class="form-control form-control-sm form-mini bg_xdecv" type="text" id="txt_cv_v" readonly />
                        </div>
                        <div class="col-lg pl-1">
                            <input class="manito" type="radio" name="rbt_FV" id="rbt_V" value="V" checked>
                            <label class="manito" for="rbt_V">
                                V
                            </label>
                        </div>
                    </div>
                    <hr class="mb-1 mt-1" />
                    <%--Reglas--%>
                    <div class="row ml-0 mr-0 text-center">
                        <div class="col-lg form-mini">
                            <label class="custom-control custom-checkbox">
                                <input type="checkbox" class="custom-control-input" name="chk_rules" id="ru_12s">
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">1/2s</span>
                            </label>
                        </div>
                        <div class="col-lg form-mini">
                            <label class="custom-control custom-checkbox">
                                <input type="checkbox" class="custom-control-input" name="chk_rules" id="ru_13s">
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">1/3s</span>
                            </label>
                        </div>
                        <div class="col-lg form-mini">
                            <label class="custom-control custom-checkbox">
                                <input type="checkbox" class="custom-control-input" name="chk_rules" id="ru_22s">
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">2/2s</span>
                            </label>
                        </div>
                        <div class="col-lg form-mini">
                            <label class="custom-control custom-checkbox">
                                <input type="checkbox" class="custom-control-input" name="chk_rules" id="ru_R4s">
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">R/4s</span>
                            </label>
                        </div>
                        <div class="col-lg form-mini">
                            <label class="custom-control custom-checkbox">
                                <input type="checkbox" class="custom-control-input" name="chk_rules" id="ru_41s">
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">4/1s</span>
                            </label>
                        </div>
                        <div class="col-lg form-mini">
                            <label class="custom-control custom-checkbox">
                                <input type="checkbox" class="custom-control-input" name="chk_rules" id="ru_10x">
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">10/x</span>
                            </label>
                        </div>
                    </div>
                    <div class="row mt-1 text-center">
                        <div class="col-lg form-mini">
                            <button type="button" class="btn btn-warning btn-sm" id="btn_Fijar_Var">
                                Fijar Variables
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-8">
            <div class="card border-bar">
                <div class="card-header text-center bg-bar">
                    <h5 class="card-title">Análisis de Datos</h5>
                </div>
                <div class="card-body" style="height: 70vh">
                    <div id="divGraph">
                        <div class="alert alert-info">Esperando Resultados</div>
                    </div>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-lg">
                    <button type="button" class="btn btn-print btn-block">
                        Imprimir
                        <br />
                        Etiquetas</button>
                </div>
                <div class="col-lg">
                    <button type="button" class="btn btn-warning btn-block">
                        Imprimir
                        <br />
                        Resultados</button>
                </div>
                <div class="col-lg">
                </div>
                <div class="col-lg">
                    <button type="button" class="btn btn-buscar btn-block" id="n_20">n=20</button>
                </div>
                <div class="col-lg">
                    <button type="button" class="btn btn-buscar btn-block" id="n_25">n=25</button>
                </div>
                <div class="col-lg">
                    <button type="button" class="btn btn-buscar btn-block" id="n_30">n=30</button>
                </div>
                <div class="col-lg">
                    <button type="button" class="btn btn-buscar btn-block" id="n_40">n=40</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
