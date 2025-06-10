<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="C_Graph_Niveles.aspx.vb" Inherits="Presentacion.C_Graph_Niveles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="../js/HighCharts.js"></script>
    <script src="../js/HighC_Exporting.js"></script>
    <link href="../css/jsLists.css" rel="stylesheet" />
    <script src="../js/jsLists.js"></script>
    <script src="../js/Deep-Copy.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        let _ID_RESUL, _ID_ANA, _ID_LOTE, _ID_DET, _FEC, _N, Arr_Res_20_N1 = [], Arr_Res_20_N2 = [], agr_CAT_F_CLONE = [], _Title, _Subtitle, _T_N1, _T_N2, _MOD_I, _bol_F_N, _slt_N1 = "", _slt_N2 = "", agr_CAT_F = [], _ana_desc_N1, _ana_desc_N2, _f_med_N1, _f_med_N2, _f_desv_N1, _f_desv_N2, _lot_desc_N1, _lot_desc_N2, N1_id_Mod, N2_id_Mod;
        let _det_20_N1, _lote_20_N1, _ana_20_N1, _det_20_N2, _lote_20_N2, _ana_20_N2;
        let Mx_20_N1_CLONE = [];
        let Mx_20_N2_CLONE = [];
        $(window).on('load', function () {
            //console.log("Load");
            $("#div_datatable").attr("hidden", true);
        });

        $(document).ready(() => {
            $("#txt_ma_f").val("");
            $("#txt_mi_f").val("");
            $("#txt_me_f").val("");
            $("#txt_ds_f").val("");
            $("#txt_cv_f").val("");
            $("#txt_n_f").val("");

            Ajax_Buscar_TreeView();

            Ajax_Accion();

            $("#mdl_Txt_Res").val("");
            $("#mdl_Txt_Com").val("");

            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input, #Txt_Date02 input , #Txt_Date03 input, #fecha4_N1, #fecha4_N2").val(dateNow);

            $('#Txt_Date01, #Txt_Date02, #Txt_Date03, #Txt_Date04_N1 input, #Txt_Date04_N2 input').datetimepicker({
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
                Mx_20_N1 = [];
                Mx_20_N2 = [];
                Ajax_20(_det_20_N1, _lote_20_N1, _ana_20_N1, 1);
                Ajax_20(_det_20_N2, _lote_20_N2, _ana_20_N2, 2);
            });
            $("#n_25").click(() => {
                _N = 25;
                Mx_20_N1 = [];
                Mx_20_N2 = [];
                Ajax_20(_det_20_N1, _lote_20_N1, _ana_20_N1, 1);
                Ajax_20(_det_20_N2, _lote_20_N2, _ana_20_N2, 2);
            });
            $("#n_30").click(() => {
                _N = 30;
                Mx_20_N1 = [];
                Mx_20_N2 = [];
                Ajax_20(_det_20_N1, _lote_20_N1, _ana_20_N1, 1);
                Ajax_20(_det_20_N2, _lote_20_N2, _ana_20_N2, 2);
            });
            $("#n_40").click(() => {
                _N = 40;
                Mx_20_N1 = [];
                Mx_20_N2 = [];
                Ajax_20(_det_20_N1, _lote_20_N1, _ana_20_N1, 1);
                Ajax_20(_det_20_N2, _lote_20_N2, _ana_20_N2, 2);
            });

            $("#btn_Buscar").click(() => {
                Mx_20_N1 = [];
                Mx_20_N2 = [];
                Ajax_Buscar(_det_20_N1, _lote_20_N1, _ana_20_N1, 1);
                Ajax_Buscar(_det_20_N2, _lote_20_N2, _ana_20_N2, 2);
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

            $("#mdl_Btn_Guardar_Mod_N1").click(() => {
                if ($("#mdl_Txt_Res_Mod_N1").val != "") {
                    Ajax_Modificar_Resul(1);
                }
            });
            $("#mdl_Btn_Guardar_Mod_N2").click(() => {
                if ($("#mdl_Txt_Res_Mod_N2").val != "") {
                    Ajax_Modificar_Resul(2);
                }
            });

            $("input[name=chk_rules]").click(() => {
                Ajax_Westgard(1);
                Ajax_Westgard(2);
            });


            $("#btn_Sec").click(() => {
                $("#btn_Sec").addClass("btn-primary");
                $("#btn_Tabla").removeClass("btn-primary");

                $("#div_treeview").attr("hidden", false);
                $("#div_datatable").attr("hidden", true);

            });
            $("#btn_Tabla").click(() => {
                $("#btn_Tabla").addClass("btn-primary");
                $("#btn_Sec").removeClass("btn-primary");


                $("#div_treeview").attr("hidden", true);
                $("#div_datatable").attr("hidden", false);
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
                "url": "C_Graph_Niveles.aspx/IRIS_QC_GRABA_UPDATE_FIJA_VARIABLES",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Fijos = [];
                        //Ajax_Fijos();

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
                "url": "C_Graph_Niveles.aspx/IRIS_GRABA_QC_RESULTADO_MANUAL",
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

        function Ajax_Modificar_Resul(t) {

            let _N_Mod = "";
            if (t == 1) {
                _N_Mod = "_N1";
                _MOD_I = N1_id_Mod;
            } else {
                _N_Mod = "_N2";
                _MOD_I = N2_id_Mod;
            }

            let _bol_Omitir = $("#chk_Omitir_Mod" + _N_Mod).prop("checked");

            if (_bol_Omitir == true) {
                _bol_Omitir = 1;
            } else {
                _bol_Omitir = 0;
            }

            var Data_Par = JSON.stringify({
                ID_TP_ACCION: $("#mdl_Slt_Accion_Mod" + _N_Mod).val(),
                COMENTARIO: $("#mdl_Txt_Com_Mod" + _N_Mod).val(),
                OMITIDO: _bol_Omitir,
                ID_RESUL: _MOD_I
            });

            $.ajax({
                "type": "POST",
                "url": "C_Graph_Niveles.aspx/IRIS_UPDATE_QC_RESULTADO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        if (_bol_F_N == 1) {
                            Ajax_20(_det_20_N1, _lote_20_N1, _ana_20_N1, 1);
                            Ajax_20(_det_20_N2, _lote_20_N2, _ana_20_N2, 2);
                        } else if (_bol_F_N == 2) {
                            Ajax_Buscar(_det_20_N1, _lote_20_N1, _ana_20_N1, 1);
                            Ajax_Buscar(_det_20_N2, _lote_20_N2, _ana_20_N2, 2);
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

        let Mx_Tree = [{
            ID_QC_SECCION: "",
            QC_SECCION_DESC: "",
            ID_QC_ANALIZADOR: "",
            QC_ANA_DESC: "",
            ID_QC_LOTE: "",
            QC_LOTE_DESC: "",
            ID_QC_DETERMINACION: "",
            QC_DET_DESC: "",
            UM_DESC: ""
        }];
        function Ajax_Buscar_TreeView() {
            modal_show();
            $.ajax({
                "type": "POST",
                "url": "C_Graph_Niveles.aspx/IRIS_QC_BUSCA_TREEVIEW",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Tree = json_receiver;
                        Fill_Tree();
                        //console.log(Mx_Tree);
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
        function Fill_Tree() {

            //Fill Sección

            let id_Sec = "", bol_sec = false;

            Mx_Tree.forEach(aah => {

                if (id_Sec == "") {
                    id_Sec = aah.ID_QC_SECCION;
                    bol_sec = true;
                } else {
                    if (id_Sec != aah.ID_QC_SECCION) {
                        id_Sec = aah.ID_QC_SECCION;
                        bol_sec = true;
                    } else {
                        bol_sec = false;
                    }
                }
                if (bol_sec == true) {
                    $("#ul_body").append(
							$("<li>").html(aah.QC_SECCION_DESC + '<ul id="ul_Sec_' + aah.ID_QC_SECCION + '"></ul>')

                    );
                }
            });

            //Fill Analizador

            let id_Sec_Ana = "", id_Ana = "", bol_sec_ana = false;

            Mx_Tree.forEach(aah => {

                if (id_Sec_Ana == "" && id_Ana == "") {
                    id_Sec_Ana = aah.ID_QC_SECCION;
                    id_Ana = aah.ID_QC_ANALIZADOR;
                    bol_sec_ana = true;
                } else {
                    if ((id_Sec_Ana != aah.ID_QC_SECCION && id_Ana != aah.ID_QC_ANALIZADOR) || (id_Sec_Ana == aah.ID_QC_SECCION && id_Ana != aah.ID_QC_ANALIZADOR)) {
                        id_Sec_Ana = aah.ID_QC_SECCION;
                        id_Ana = aah.ID_QC_ANALIZADOR;
                        bol_sec_ana = true;
                    } else {
                        bol_sec_ana = false;
                    }
                }
                if (bol_sec_ana == true) {
                    $("#ul_Sec_" + aah.ID_QC_SECCION).append(
							$("<li>").html(aah.QC_ANA_DESC + '<ul id="ul_Ana_' + aah.ID_QC_SECCION + aah.ID_QC_ANALIZADOR + '"></ul>')
                    );
                }
            });

            //Fill Lote

            let id_Sec_Ana_Lote = "", id_Ana_Lote = "", id_Lote = "", bol_ana_lote = false;

            Mx_Tree.forEach(aah => {

                if (id_Sec_Ana_Lote == "" && id_Ana_Lote == "" && id_Lote == "") {
                    id_Sec_Ana_Lote = aah.ID_QC_SECCION;
                    id_Ana_Lote = aah.ID_QC_ANALIZADOR;
                    id_Lote = aah.ID_QC_LOTE;
                    bol_sec_ana = true;
                } else {
                    if ((id_Sec_Ana_Lote != aah.ID_QC_SECCION && id_Ana_Lote != aah.ID_QC_ANALIZADOR && id_Lote != aah.ID_QC_LOTE) || (id_Sec_Ana_Lote == aah.ID_QC_SECCION && id_Ana_Lote == aah.ID_QC_ANALIZADOR && id_Lote != aah.ID_QC_LOTE) || (id_Sec_Ana_Lote == aah.ID_QC_SECCION && id_Ana_Lote != aah.ID_QC_ANALIZADOR && id_Lote != aah.ID_QC_LOTE)) {
                        id_Sec_Ana_Lote = aah.ID_QC_SECCION;
                        id_Ana_Lote = aah.ID_QC_ANALIZADOR;
                        id_Lote = aah.ID_QC_LOTE;
                        bol_sec_ana = true;
                    } else {
                        bol_sec_ana = false;
                    }
                }
                if (bol_sec_ana == true) {
                    $("#ul_Ana_" + aah.ID_QC_SECCION + aah.ID_QC_ANALIZADOR).append(
							$("<li>").html(aah.QC_LOTE_DESC + '<ul id="ul_Lote_' + aah.ID_QC_SECCION + aah.ID_QC_ANALIZADOR + aah.ID_QC_LOTE + '"></ul>')
                    );
                }
            });

            //Fill Determinación

            Mx_Tree.forEach(aah => {
                let _li_det, _li_lote, _li_ana, _li_sec;

                _li_det = aah.ID_QC_DETERMINACION
                _li_lote = aah.ID_QC_LOTE
                _li_ana = aah.ID_QC_ANALIZADOR
                _li_sec = aah.ID_QC_SECCION
                ;
                $("#ul_Lote_" + _li_sec + _li_ana + _li_lote).append(
							$("<li>", { "name": "li_det", "id": "li_det_" + _li_ana + _li_lote + _li_det, "data-ana": _li_ana, "data-lote": _li_lote, "data-det": _li_det }).text(aah.QC_DET_DESC + " " + aah.UM_DESC)
                    );
            });

            JSLists.createTree("f1combined");

            $("li[name=li_det]").click((e) => {

                if (_slt_N1 != "") {
                    _slt_N1 = "";
                    _slt_N2 = "";
                    Mx_20_N1 = [];
                    Mx_20_N2 = [];
                }


                $("li[name=li_det]").css({ "color": "inherit", "font-weight": "inherit" });
                if (_slt_N2 == "") {
                    _slt_N2 = $(e.currentTarget).attr("id");

                    _T_N1 = $(e.currentTarget).text();
                    _Title = _T_N1;

                    let _ana_id = $(e.currentTarget).parent().parent().parent().attr("id");
                    _ana_desc_N1 = $("#" + _ana_id).parent().clone().children().remove().end().text();
                    _lot_desc_N1 = $(e.currentTarget).parent().parent().clone().children().remove().end().text();

                    _Subtitle = _ana_desc_N1 + ": " + _lot_desc_N1;

                    $("#" + _slt_N2).css({ "color": "rgb(5, 135, 235)", "font-weight": "600" });

                    _det_20_N2 = $("#" + _slt_N2).attr("data-det");
                    _lote_20_N2 = $("#" + _slt_N2).attr("data-lote");
                    _ana_20_N2 = $("#" + _slt_N2).attr("data-ana");

                } else {
                    _slt_N1 = _slt_N2;
                    _slt_N2 = $(e.currentTarget).attr("id");

                    _T_N2 = $(e.currentTarget).text();

                    if (_T_N1 != _T_N2) {
                        _Title = _Title + " - " + $(e.currentTarget).text();
                    }

                    let _ana_id = $(e.currentTarget).parent().parent().parent().attr("id");
                    _ana_desc_N2 = $("#" + _ana_id).parent().clone().children().remove().end().text();
                    _lot_desc_N2 = $(e.currentTarget).parent().parent().clone().children().remove().end().text();

                    if (_ana_desc_N1 != _ana_desc_N2) {
                        _Subtitle = _Subtitle + " - " + _ana_desc_N2 + ": " + _lot_desc_N2;
                    } else {
                        _Subtitle = _Subtitle + " - " + _lot_desc_N2;
                    }

                    $("#" + _slt_N1).css({ "color": "rgb(5, 135, 235)", "font-weight": "600" });
                    $("#" + _slt_N2).css({ "color": "rgb(230, 0, 161)", "font-weight": "600" });

                    _det_20_N1 = $("#" + _slt_N1).attr("data-det");
                    _lote_20_N1 = $("#" + _slt_N1).attr("data-lote");
                    _ana_20_N1 = $("#" + _slt_N1).attr("data-ana");

                    _det_20_N2 = $("#" + _slt_N2).attr("data-det");
                    _lote_20_N2 = $("#" + _slt_N2).attr("data-lote");
                    _ana_20_N2 = $("#" + _slt_N2).attr("data-ana");
                }
                _N = 20;
                if (_slt_N1 != "" && _slt_N2 != "") {

                    Ajax_20(_det_20_N1, _lote_20_N1, _ana_20_N1, 1);
                    Ajax_20(_det_20_N2, _lote_20_N2, _ana_20_N2, 2);
                }
            });

            Hide_Modal();
        }

        let Mx_20_N1 = [{
            QC_RESUL_VALOR_1: "",
            QC_RESUL_VALOR_2: "",
            QC_RESUL_VALOR_3: "",
            QC_RESUL_HORA: "",
            QC_COMENTARIOS: "",
            ID_QC_RESULTADO: "",
            ID_TP_QC_ACCION: "",
            QC_RESUL_OMITIDO: ""
        }];
        let Mx_20_N2 = [{
            QC_RESUL_VALOR_1: "",
            QC_RESUL_VALOR_2: "",
            QC_RESUL_VALOR_3: "",
            QC_RESUL_HORA: "",
            QC_COMENTARIOS: "",
            ID_QC_RESULTADO: "",
            ID_TP_QC_ACCION: "",
            QC_RESUL_OMITIDO: ""
        }];
        function Ajax_Buscar(_det_20, _lote_20, _ana_20, t_20) {

            _bol_F_N = 2;

            var Data_Par = JSON.stringify({
                ID_ANA: _ana_20,
                ID_LOTE: _lote_20,
                ID_DET: _det_20,
                DESDE: $("#fecha").val(),
                HASTA: $("#fecha2").val()
            });

            $.ajax({
                "type": "POST",
                "url": "C_Graph_Niveles.aspx/IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_FECHA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {

                        if (t_20 == 1) {
                            Mx_20_N1 = json_receiver;

                        } else {
                            Mx_20_N2 = json_receiver;

                        }

                        if (Mx_20_N1.length > 0 && Mx_20_N2.length > 0) {
                            if (Mx_20_N1[0].ID_QC_RESULTADO != "" && Mx_20_N2[0].ID_QC_RESULTADO != "") {
                                $("#divGraph").attr("hidden", false);
                                Ajax_Fill_Graph();

                            }
                        }
                        Hide_Modal();
                    } else {
                        $("#divGraph").attr("hidden", true);
                        Hide_Modal();
                        console.log(response);
                        $("#DataTable tbody").empty();
                    }
                },
                "error": function (response) {
                    $("#divGraph").attr("hidden", true);
                    Hide_Modal();
                    console.log(response);
                    $("#DataTable tbody").empty();
                }
            });
        }
        function Ajax_20(_det_20, _lote_20, _ana_20, t_20) {
            _bol_F_N = 1;

            modal_show();
            var Data_Par = JSON.stringify({
                ID_ANA: _ana_20,
                ID_LOTE: _lote_20,
                ID_DET: _det_20,
                N: _N
            });

            $.ajax({
                "type": "POST",
                "url": "C_Graph_Niveles.aspx/IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_ULT",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {

                        if (t_20 == 1) {
                            Mx_20_N1 = json_receiver;

                        } else {
                            Mx_20_N2 = json_receiver;

                        }

                        if (Mx_20_N1.length > 0 && Mx_20_N2.length > 0) {
                            if (Mx_20_N1[0].ID_QC_RESULTADO != "" && Mx_20_N2[0].ID_QC_RESULTADO != "") {
                                $("#divGraph").attr("hidden", false);
                                Ajax_Fill_Graph();

                            }
                        }
                        Hide_Modal();
                    } else {
                        $("#divGraph").attr("hidden", true);
                        Hide_Modal();
                        console.log(response);
                        $("#DataTable tbody").empty();
                    }
                },
                "error": function (response) {
                    $("#divGraph").attr("hidden", true);
                    Hide_Modal();
                    console.log(response);
                    $("#DataTable tbody").empty();
                }
            });
        }

        let Mx_Accion = [{
            ID_TP_QC_ACCION: "",
            TP_QC_DESC: ""
        }]
        function Ajax_Accion() {
            $.ajax({
                "type": "POST",
                "url": "C_Graph_Niveles.aspx/IRIS_QC_BUSCA_TP_ACCION_ACTIVAS",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Accion = json_receiver;
                        //console.log(Mx_20);
                        Ajax_Fill_Accion(1);
                        Ajax_Fill_Accion(2);
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
        function Ajax_Fill_Accion(t) {
            let _n_accion = "";
            if (t == 1) {
                _n_accion = "_N1";
            } else {
                _n_accion = "_N2";
            }

            $("#mdl_Slt_Accion").empty();

            for (y = 0; y < Mx_Accion.length; ++y) {
                $("<option>", {
                    "value": Mx_Accion[y].ID_TP_QC_ACCION
                }).text(Mx_Accion[y].TP_QC_DESC).appendTo("#mdl_Slt_Accion");
            }
            $("#mdl_Slt_Accion").val(18);

            $("#mdl_Slt_Accion_Mod" + _n_accion).empty();

            for (y = 0; y < Mx_Accion.length; ++y) {
                $("<option>", {
                    "value": Mx_Accion[y].ID_TP_QC_ACCION
                }).text(Mx_Accion[y].TP_QC_DESC).appendTo("#mdl_Slt_Accion_Mod" + _n_accion);
            }
            $("#mdl_Slt_Accion_Mod" + _n_accion).val(18);
        }

        function Ajax_Westgard(_nivel) {
            let Arr_1_2s = [];
            let Mx_20 = [];
            let _de_4i;
            let _de_4s;
            let _west;
            let _r_me;
            let _r_ds;

            let _me = 0;

            let _3s_i = -3;

            let _2s_i = -2;

            let _1s_i = -1;

            let _3s_s = 3;

            let _2s_s = 2;

            let _1s_s = 1;

            if (_nivel == 1) {
                Mx_20 = Mx_20_N1.slice();
                _de_4i = -4;
                _de_4s = 4;
                _west = "#wN1_";
                _r_ds = _f_desv_N1;
                _r_me = _f_med_N1;
            } else {
                Mx_20 = Mx_20_N2.slice();
                _de_4i = -4;
                _de_4s = 4;
                _west = "#wN2_";
                _r_ds = _f_desv_N2;
                _r_me = _f_med_N2;
            }

            let x_index = 0;

            for (i = 0; i < Mx_20.length; i++) {
                if ($("#rbt_2").prop("checked") == true && Mx_20[i].QC_RESUL_OMITIDO != 1 || $("#rbt_1").prop("checked") == true) {
                    $(_west + Mx_20[i].ID_QC_RESULTADO).css("font-weight", "inherit").text("Normal"); // Todos normales antes de realizar calculos

                    if (_nivel == 1) {
                        $(_west + Mx_20[i].ID_QC_RESULTADO).parent().attr("data-N1", Mx_20[i].ID_QC_RESULTADO);
                    } else {
                        $(_west + Mx_20[i].ID_QC_RESULTADO).parent().attr("data-N2", Mx_20[i].ID_QC_RESULTADO);
                    }


                    let _res = parseFloat(Mx_20[i].QC_RESUL_VALOR_1.replace(",", "."));

                    if (_r_ds == 0) {
                        _res = (_res - _r_me).toFixed(2);
                    } else {
                        _res = ((_res - _r_me) / _r_ds).toFixed(2);
                    }


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

                        Arr_1_2s.push({ id: Mx_20[i].ID_QC_RESULTADO, index: x_index, tipo: "menor" });
                        //console.log(Arr_1_2s);

                    } else if (_res < _3s_s && _res >= _2s_s) { //res menor a +3s y mayor igual a +2s

                        Arr_1_2s.push({ id: Mx_20[i].ID_QC_RESULTADO, index: x_index, tipo: "mayor" });
                        //console.log(Arr_1_2s);
                    }
                    x_index++;
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
                                if (_r_ds == 0) {
                                    _res = (_res - _r_me).toFixed(2);
                                } else {
                                    _res = ((_res - _r_me) / _r_ds).toFixed(2);
                                }

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
                                                    $(_west + Mx_20[i].ID_QC_RESULTADO).css("font-weight", "600").text("10-x");
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
                                                    $(_west + Mx_20[i].ID_QC_RESULTADO).css("font-weight", "600").text("10-x");
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
                                if (_r_ds == 0) {
                                    _res = (_res - _r_me).toFixed(2);
                                } else {
                                    _res = ((_res - _r_me) / _r_ds).toFixed(2);
                                }

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
                                                    $(_west + Mx_20[i].ID_QC_RESULTADO).css("font-weight", "600").text("4-1s");
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
                                                    $(_west + Mx_20[i].ID_QC_RESULTADO).css("font-weight", "600").text("4-1s");
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

                            if (_r_ds == 0) {
                                _res_su = (_res_su - _r_me).toFixed(2);
                                _res_an = (_res_an - _r_me).toFixed(2);
                            } else {
                                _res_su = ((_res_su - _r_me) / _r_ds).toFixed(2);
                                _res_an = ((_res_an - _r_me) / _r_ds).toFixed(2);
                            }

                            let _res_Dif = (_res_su - _res_an); // diferencia de resultados

                            //console.log("AN: " + _i_an + "  (" + _res_an + ") | SU: " + _i_su + "  (" + _res_su + ") Res: " + _res_Dif + " -4R: " + _de_4i + " +4R: " + _de_4s);
                            //console.group("R4s");
                            //console.log(_res_Dif);
                            //console.log(_de_4i);
                            //console.log(_de_4s);
                            //console.groupEnd();
                            if (_res_Dif >= _de_4s || _res_Dif <= _de_4i) { // si el resultado es mayor igual a +R-4S o si el resultado es menor igual a -R-4s
                                //console.log("cumple mayor");
                                $(_west + Mx_20[i].ID_QC_RESULTADO).css("font-weight", "600").text("R-4s"); //se marca el actual como R-4s
                                //$("#west_" + _i_an).text("R-4s"); //se marca el anterior como R-4s
                            }
                        }
                    }
                }
            }

            //<<<<<<<<<< 1-2s 2-2s >>>>>>>>>>//

            if (Arr_1_2s.length > 0) { // Calcular si el anterior es 2-2s
                //console.log(">1");
                for (i = 0; i < Arr_1_2s.length; i++) {
                    if ($("#ru_12s").prop("checked") == true) {
                        //console.log("1-2s");
                        $(_west + Arr_1_2s[0].id).css("font-weight", "600").text("1-2s"); //Primero 1-2s
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
                                $(_west + Arr_1_2s[i].id).css("font-weight", "600").text("2-2s"); // 2-2s actual
                                //console.log("2-2s");
                            }
                        } else {
                            if ($("#ru_12s").prop("checked") == true) {
                                if ($(_west + Arr_1_2s[i].id).text() == "Normal") { //si el actual no es del mismo tipo 1-2s
                                    $(_west + Arr_1_2s[i].id).css("font-weight", "600").text("1-2s");
                                    //console.log("1-2s");
                                }
                                //if ($(_west + Arr_1_2s[i_an].id).text() == "Normal") { //si el anterior no es del mismo tipo 1-2s
                                //    // $("#west_" + i_an).text("1-2s");
                                //}
                            }
                        }
                    }
                }
            }

            //<<<<<<<<<< 1-3s >>>>>>>>>>//

            if ($("#ru_13s").prop("checked") == true) {
                for (i = 0; i < Mx_20.length; i++) {
                    let _res = parseFloat(Mx_20[i].QC_RESUL_VALOR_1.replace(",", "."));
                    if (_r_ds == 0) {
                        _res = (_res - _r_me).toFixed(2);
                    } else {
                        _res = ((_res - _r_me) / _r_ds).toFixed(2);
                    }

                    if (_res <= _3s_i || _res >= _3s_s) { //resultado menor igual -3s o mayor igual a +3s
                        $(_west + Mx_20[i].ID_QC_RESULTADO).css("font-weight", "700").text("1-3s");
                    }
                }
            }
            else if ($("#ru_12s").prop("checked") == true) {
                for (i = 0; i < Mx_20.length; i++) {
                    let _res = parseFloat(Mx_20[i].QC_RESUL_VALOR_1.replace(",", "."));
                    if (_r_ds == 0) {
                        _res = (_res - _r_me).toFixed(2);
                    } else {
                        _res = ((_res - _r_me) / _r_ds).toFixed(2);
                    }

                    if (_res <= _3s_i || _res >= _3s_s) { //resultado menor igual -3s o mayor igual a +3s
                        $(_west + Mx_20[i].ID_QC_RESULTADO).css("font-weight", "700").text("1-2s");
                    }
                }
            }
        }

        function Fill_DataTable() {
            let Res_Id_N1;
            let Res_Id_N2;

            //////// Fill DataTable
            $("#DataTable tbody").empty();
            for (i = 0; i < agr_CAT_F_CLONE.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "class": "manito",
                        "data-id": i
                    }).append(
                        $("<td>", { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "class": "textoReducido" }).text(agr_CAT_F_CLONE[i].replace(/\N/g, "")),
                        $("<td>", { "class": "textoReducido" }).css({ "color": "#0079d6", "font-weight": "600" }).html(() => {
                            let RN1 = "";
                            let _cnt_1 = 0;
                            Mx_20_N1_CLONE.forEach(aah=> {
                                if (aah.QC_RESUL_HORA == agr_CAT_F_CLONE[i]) {
                                    //console.log(aah.QC_RESUL_VALOR_1);
                                    RN1 = parseFloat(aah.QC_RESUL_VALOR_1.replace(",", "."));
                                    if (_f_desv_N1 == 0) {
                                        RN1 = (RN1 - _f_med_N1).toFixed(2);
                                    } else {
                                        RN1 = ((RN1 - _f_med_N1) / _f_desv_N1).toFixed(2);
                                    }
                                    if (aah.QC_RESUL_OMITIDO == 1) {
                                        RN1 = RN1 + " <span class='text-dark'>(*)</span>";
                                    }
                                    Res_Id_N1 = aah.ID_QC_RESULTADO.toString();
                                    _cnt_1 = 1;
                                }
                            });
                            if (_cnt_1 == 0) {
                                Res_Id_N1 = "";
                            }
                            return RN1;
                        }),
                $("<td>", { "class": "textoReducido" }).css({ "color": "#d60096", "font-weight": "600" }).html((e) => {
                    let RN2 = "";
                    let _cnt_2 = 0;
                    Mx_20_N2_CLONE.forEach(aah=> {
                        if (aah.QC_RESUL_HORA == agr_CAT_F_CLONE[i]) {
                            //console.log(aah.QC_RESUL_VALOR_1);
                            RN2 = parseFloat(aah.QC_RESUL_VALOR_1.replace(",", "."));
                            if (_f_desv_N2 == 0) {
                                RN2 = (RN2 - _f_med_N2).toFixed(2);
                            } else {
                                RN2 = ((RN2 - _f_med_N2) / _f_desv_N2).toFixed(2);
                            }
                            if (aah.QC_RESUL_OMITIDO == 1) {
                                RN2 = RN2 + " <span class='text-dark'>(*)</span>";
                            }
                            Res_Id_N2 = aah.ID_QC_RESULTADO.toString();
                            _cnt_2 = 1;
                        }
                    });
                    if (_cnt_2 == 0) {
                        Res_Id_N2 = "";
                    }
                    return RN2;
                }),
                        $("<td>", { "class": "textoReducido fw600", "id": "wN1_" + Res_Id_N1 }).css({ "color": "#0079d6", "font-weight": "600" }).text((e) => {

                            return "";
                        }),
                        $("<td>", { "class": "textoReducido fw600", "id": "wN2_" + Res_Id_N2 }).css({ "color": "#d60096", "font-weight": "600" }).text((e) => {
                            $("#DataTable tbody tr[data-id='" + i + "']").attr("data-N2", Res_Id_N2);
                            return "";
                        })
                    )
                );
            }

            //////// Fill Westgard
            Ajax_Westgard(1);
            Ajax_Westgard(2);

            $("#DataTable tbody tr").dblclick((e) => {
                N1_id_Mod = "";
                N1_id_Mod = $(e.currentTarget).attr("data-n1");
                N2_id_Mod = "";
                N2_id_Mod = $(e.currentTarget).attr("data-n2");

                if (N1_id_Mod != undefined) {
                    $("#mdl_Ana_Mod_N1").val(_ana_desc_N1);
                    $("#mdl_Lote_Mod_N1").val(_lot_desc_N1);
                    $("#mdl_Det_Mod_N1").val(_T_N1);

                    Mx_20_N1.forEach(aah=> {
                        if (N1_id_Mod == aah.ID_QC_RESULTADO) {

                            let RN1 = parseFloat(aah.QC_RESUL_VALOR_1.replace(",", "."));
                            if (_f_desv_N1 == 0) {
                                RN1 = (RN1 - _f_med_N1).toFixed(2);
                            } else {
                                RN1 = ((RN1 - _f_med_N1) / _f_desv_N1).toFixed(2);
                            }
                            console.log(RN1);
                            $("#mdl_Txt_Res_Mod_N1").val(RN1);

                            $("#mdl_Txt_Com_Mod_N1").val(aah.QC_COMENTARIOS);
                            let _f_mod = moment(aah.QC_RESUL_HORA).format("DD-MM-YYYY");
                            $("#fecha4_N1").val(_f_mod);

                            if (aah.ID_TP_QC_ACCION > 0) {
                                $("#mdl_Slt_Accion_Mod_N1").val(aah.ID_TP_QC_ACCION);
                            } else {
                                $("#mdl_Slt_Accion_Mod_N1").val(18);
                            }

                            if (aah.QC_RESUL_OMITIDO == 1) {
                                $("#chk_Omitir_Mod_N1").prop("checked", true);
                            } else {
                                $("#chk_Omitir_Mod_N1").prop("checked", false);
                            }
                        }
                    });
                } else {
                    $("#mdl_Ana_Mod_N1").val("");
                    $("#mdl_Lote_Mod_N1").val("");
                    $("#mdl_Det_Mod_N1").val("");
                    $("#mdl_Txt_Res_Mod_N1").val("");
                    $("#mdl_Txt_Com_Mod_N1").val("");
                    let _f_mod = moment().format("DD-MM-YYYY");
                    $("#fecha4_N1").val(_f_mod);
                    $("#mdl_Slt_Accion_Mod_N1").val(18);
                    $("#chk_Omitir_Mod_N1").prop("checked", false);
                }

                if (N2_id_Mod != undefined) {
                    $("#mdl_Ana_Mod_N2").val(_ana_desc_N2);
                    $("#mdl_Lote_Mod_N2").val(_lot_desc_N2);
                    $("#mdl_Det_Mod_N2").val(_T_N2);

                    Mx_20_N2.forEach(aah=> {
                        if (N2_id_Mod == aah.ID_QC_RESULTADO) {

                            let RN2 = parseFloat(aah.QC_RESUL_VALOR_1.replace(",", "."));
                            if (_f_desv_N1 == 0) {
                                RN2 = (RN2 - _f_med_N2).toFixed(2);
                            } else {
                                RN2 = ((RN2 - _f_med_N2) / _f_desv_N2).toFixed(2);
                            }
                            console.log(RN2);
                            $("#mdl_Txt_Res_Mod_N2").val(RN2);
                            $("#mdl_Txt_Com_Mod_N2").val(aah.QC_COMENTARIOS);
                            let _f_mod = moment(aah.QC_RESUL_HORA).format("DD-MM-YYYY");
                            $("#fecha4_N2").val(_f_mod);

                            if (aah.ID_TP_QC_ACCION > 0) {
                                $("#mdl_Slt_Accion_Mod_N2").val(aah.ID_TP_QC_ACCION);
                            } else {
                                $("#mdl_Slt_Accion_Mod_N2").val(18);
                            }

                            if (aah.QC_RESUL_OMITIDO == 1) {
                                $("#chk_Omitir_Mod_N2").prop("checked", true);
                            } else {
                                $("#chk_Omitir_Mod_N2").prop("checked", false);
                            }
                        }
                    });
                } else {
                    $("#mdl_Ana_Mod_N2").val("");
                    $("#mdl_Lote_Mod_N2").val("");
                    $("#mdl_Det_Mod_N2").val("");
                    $("#mdl_Txt_Res_Mod_N2").val("");
                    $("#mdl_Txt_Com_Mod_N2").val("");
                    let _f_mod = moment().format("DD-MM-YYYY");
                    $("#fecha4_N2").val(_f_mod);
                    $("#mdl_Slt_Accion_Mod_N2").val(18);
                    $("#chk_Omitir_Mod_N2").prop("checked", false);
                }

                $("#mdl_Mod_Resul").modal("show");
            }).one();

        }

        function Ajax_Fill_Graph() {
            let agr_CAT = [], labels_TXT = [], Arr_Test_N1, _f_Mx, _LOT_N1, _LOT_N2;
            agr_CAT_F = [];
            let _3s_i, _3s_s, _2s_i, _2s_s, _1s_i, _1s_s, _x;
            let an_Fec = "";
            let cont_n = 1;
            let cont_n2 = 1;
            Mx_20_N1_CLONE = [];
            Mx_20_N2_CLONE = [];

            Mx_20_N1_CLONE = fnClone(Mx_20_N1);
            Mx_20_N2_CLONE = fnClone(Mx_20_N2);

            //console.log(Mx_20_N1);
            //console.log(Mx_20_N2);

            for (i = 0; i < Mx_20_N1_CLONE.length; i++) {
                if (!(($("#rbt_2").prop("checked") == true && Mx_20_N1_CLONE[i].QC_RESUL_OMITIDO != 1 || $("#rbt_1").prop("checked") == true))) {
                    Mx_20_N1_CLONE.splice(i, 1);
                }
            }

            for (i = 0; i < Mx_20_N2_CLONE.length; i++) {
                if (!(($("#rbt_2").prop("checked") == true && Mx_20_N2_CLONE[i].QC_RESUL_OMITIDO != 1 || $("#rbt_1").prop("checked") == true))) {
                    Mx_20_N2_CLONE.splice(i, 1);
                }
            }

            ///////////////////////////// Compara fecha actual y anterior de N1, si coincide se le concatena "N"
            for (i = 0; i < Mx_20_N1_CLONE.length; i++) {
                if (i > 0) {
                    let an_i = i - 1;
                    let su_Fec = moment(Mx_20_N1_CLONE[i].QC_RESUL_HORA).format("DD-MM-YYYY");
                    if (an_Fec == su_Fec) {

                        Mx_20_N1_CLONE[i].QC_RESUL_HORA = su_Fec + "N".repeat(cont_n);
                        an_Fec = su_Fec;
                        cont_n += 1;
                    } else {
                        Mx_20_N1_CLONE[i].QC_RESUL_HORA = su_Fec;
                        an_Fec = su_Fec;
                        cont_n = 1;
                    }
                } else {
                    an_Fec = moment(Mx_20_N1_CLONE[i].QC_RESUL_HORA).format("DD-MM-YYYY");
                    Mx_20_N1_CLONE[i].QC_RESUL_HORA = an_Fec;
                }
            }

            ///////////////////////////// Compara fecha actual y anterior de N2, si coincide se le concatena "N"
            for (i = 0; i < Mx_20_N2_CLONE.length; i++) {
                if (i > 0) {
                    let an_i = i - 1;
                    let su_Fec = moment(Mx_20_N2_CLONE[i].QC_RESUL_HORA).format("DD-MM-YYYY");
                    if (an_Fec == su_Fec) {

                        Mx_20_N2_CLONE[i].QC_RESUL_HORA = su_Fec + "N".repeat(cont_n2);
                        an_Fec = su_Fec;
                        cont_n2 += 1;
                    } else {
                        Mx_20_N2_CLONE[i].QC_RESUL_HORA = su_Fec;
                        an_Fec = su_Fec;
                        cont_n2 = 1;
                    }
                } else {
                    an_Fec = moment(Mx_20_N2_CLONE[i].QC_RESUL_HORA).format("DD-MM-YYYY");
                    Mx_20_N2_CLONE[i].QC_RESUL_HORA = an_Fec;
                }
            }

            ///////////////////////////// compara N1 con N2 para agregar fechas N1 que coincidan o no con N2
            let cnt_res = 0;
            for (i = 0; i < Mx_20_N1_CLONE.length; i++) {
                for (x = 0; x < Mx_20_N2_CLONE.length; x++) {
                    if (Mx_20_N1_CLONE[i].QC_RESUL_HORA == Mx_20_N2_CLONE[x].QC_RESUL_HORA) {
                        agr_CAT_F.push(Mx_20_N1_CLONE[i].QC_RESUL_HORA);
                        cnt_res += 1;
                    }
                }
                if (cnt_res == 0) {
                    agr_CAT_F.push(Mx_20_N1_CLONE[i].QC_RESUL_HORA);
                    cnt_res = 0;
                } else {
                    cnt_res = 0;
                }
            }
            //console.log(agr_CAT_F);
            ///////////////////////////// compara N2 con Categoria Fecha para agregar fechas N2 que no esten en la categoria
            let cnt_res2 = 0;
            for (i = 0; i < Mx_20_N2_CLONE.length; i++) {
                for (x = 0; x < agr_CAT_F.length; x++) {
                    if (Mx_20_N2_CLONE[i].QC_RESUL_HORA == agr_CAT_F[x]) {
                        cnt_res2 += 1;
                    }
                }
                if (cnt_res2 == 0) {
                    agr_CAT_F.push(Mx_20_N2_CLONE[i].QC_RESUL_HORA);
                    cnt_res2 = 0;
                } else {
                    cnt_res2 = 0;
                }
            }

            ///////////////////////////// convierte Categoria Fecha String a Date 
            for (i = 0; i < agr_CAT_F.length; i++) {
                let str = agr_CAT_F[i].replace(/\N/g, "");
                var parts = str.split("-");
                var dt = new Date(parseInt(parts[2], 10),
                                  parseInt(parts[1], 10) - 1,
                                  parseInt(parts[0], 10));
                agr_CAT_F[i] = dt;
            }

            ///////////////////////////// Ordena Categoria Fecha de menor a mayor
            agr_CAT_F.sort(function (a, b) {
                return a > b;
            });

            ///////////////////////////// Compara fecha actual y anterior de Categoria Fecha, si coincide se le concatena "N"
            let cont_n3 = 1;
            for (i = 0; i < agr_CAT_F.length; i++) {
                if (i > 0) {
                    let an_i = i - 1;
                    let su_Fec = moment(agr_CAT_F[i]).format("DD-MM-YYYY");
                    if (an_Fec == su_Fec) {

                        agr_CAT_F[i] = su_Fec + "N".repeat(cont_n3);
                        an_Fec = su_Fec;
                        cont_n3 += 1;
                    } else {
                        agr_CAT_F[i] = su_Fec;
                        an_Fec = su_Fec;
                        cont_n3 = 1;
                    }
                } else {
                    an_Fec = moment(agr_CAT_F[i]).format("DD-MM-YYYY");
                    agr_CAT_F[i] = an_Fec;
                }
            }

            ///////////////////////////// Compara Categoria Fecha con Mx N1 para agregar valores a Res N1
            let cont_4 = 0;
            Arr_Res_20_N1 = [];

            for (i = 0; i < agr_CAT_F.length; i++) {
                for (x = 0; x < Mx_20_N1_CLONE.length; x++) {
                    if (agr_CAT_F[i] == Mx_20_N1_CLONE[x].QC_RESUL_HORA) {
                        Arr_Res_20_N1.push(parseFloat(Mx_20_N1_CLONE[x].QC_RESUL_VALOR_1.replace(',', '.')));
                        cont_4 = 1;
                    }
                }
                if (cont_4 == 0) {
                    Arr_Res_20_N1.push(null);
                } else {
                    cont_4 = 0;
                }
            }

            let _OP_Arr_Res_20_N1 = [];

            Arr_Res_20_N1.forEach(aah=> {
                if (aah != null) {
                    _OP_Arr_Res_20_N1.push(aah);
                }
            });

            _f_med_N1 = math.mean(_OP_Arr_Res_20_N1);
            _f_desv_N1 = math.std(_OP_Arr_Res_20_N1);

            for (i = 0; i < Arr_Res_20_N1.length; i++) {
                if (Arr_Res_20_N1[i] != null) {
                    if (_f_desv_N1 == 0) {
                        Arr_Res_20_N1[i] = (Arr_Res_20_N1[i] - _f_med_N1).toFixed(2);
                    } else {
                        Arr_Res_20_N1[i] = ((Arr_Res_20_N1[i] - _f_med_N1) / _f_desv_N1).toFixed(2);
                    }

                    Arr_Res_20_N1[i] = parseFloat(Arr_Res_20_N1[i]);
                }
            }

            ///////////////////////////// Compara Categoria Fecha con Mx N2 para agregar valores a Res N2
            let cont_5 = 0;
            Arr_Res_20_N2 = [];

            for (i = 0; i < agr_CAT_F.length; i++) {
                for (x = 0; x < Mx_20_N2_CLONE.length; x++) {
                    if (agr_CAT_F[i] == Mx_20_N2_CLONE[x].QC_RESUL_HORA) {
                        Arr_Res_20_N2.push(parseFloat(Mx_20_N2_CLONE[x].QC_RESUL_VALOR_1.replace(',', '.')));
                        cont_5 = 1;
                    }
                }
                if (cont_5 == 0) {
                    Arr_Res_20_N2.push(null);
                } else {
                    cont_5 = 0;
                }
            }

            let _OP_Arr_Res_20_N2 = [];

            Arr_Res_20_N2.forEach(aah=> {
                if (aah != null) {
                    _OP_Arr_Res_20_N2.push(aah);
                }
            });

            _f_med_N2 = math.mean(_OP_Arr_Res_20_N2);
            _f_desv_N2 = math.std(_OP_Arr_Res_20_N2);

            for (i = 0; i < Arr_Res_20_N2.length; i++) {
                if (Arr_Res_20_N2[i] != null) {
                    if (_f_desv_N2 == 0) {
                        Arr_Res_20_N2[i] = (Arr_Res_20_N2[i] - _f_med_N2).toFixed(2);
                    } else {
                        Arr_Res_20_N2[i] = ((Arr_Res_20_N2[i] - _f_med_N2) / _f_desv_N2).toFixed(2);
                    }

                    Arr_Res_20_N2[i] = parseFloat(Arr_Res_20_N2[i]);
                }
            }

            ///////////////////////////// Quita todas las "N" de Categoria Fecha

            agr_CAT_F_CLONE = agr_CAT_F.slice();

            for (i = 0; i < agr_CAT_F.length; i++) {
                agr_CAT_F[i] = agr_CAT_F[i].replace(/\N/g, "");
            }

            _3s_i = -3;

            _2s_i = -2;

            _1s_i = -1;

            _me = 0;

            _3s_s = 3;

            _2s_s = 2;

            _1s_s = 1;

            labels_Plot = [_3s_i, _2s_i, _1s_i, _me, _1s_s, _2s_s, _3s_s];

            let _3s_i_str = _3s_i.toFixed(2).replace(".", ",");
            let _2s_i_str = _2s_i.toFixed(2).replace(".", ",");
            let _1s_i_str = _1s_i.toFixed(2).replace(".", ",");
            let _3s_s_str = _3s_s.toFixed(2).replace(".", ",");
            let _2s_s_str = _2s_s.toFixed(2).replace(".", ",");
            let _1s_s_str = _1s_s.toFixed(2).replace(".", ",");
            let _me_str = _me.toFixed(2).replace(".", ",");

            labels_TXT = [_3s_i_str + " (-3s)", _2s_i_str + " (-2s)", _1s_i_str + " (-1s)", _me_str + " (X)", _1s_s_str + " (+1s)", _2s_s_str + " (+2s)", _3s_s_str + " (+3s)"];

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
                        value: 0
                    },
                    {
                        //+1s
                        color: '#7FFF00',
                        width: 2,
                        value: 1,
                        dashStyle: "dash"
                    },
                    {
                        //-1s
                        color: '#7FFF00',
                        width: 2,
                        value: -1,
                        dashStyle: "dash"
                    },
                    {
                        //+2s
                        color: '#ecf022',
                        width: 2,
                        value: 2,
                        dashStyle: "shortdash"
                    },
                    {
                        //-2s
                        color: '#ecf022',
                        width: 2,
                        value: -2,
                        dashStyle: "shortdash"
                    },
                    {
                        //+3s
                        color: '#FF0000',
                        width: 2,
                        value: 3
                    },
                    {
                        //-3s
                        color: '#FF0000',
                        width: 2,
                        value: -3
                    }
                    ]
                },
                xAxis: {
                    categories: agr_CAT_F
                },
                series: [
                    {
                        name: "N1",
                        data: Arr_Res_20_N1,
                        color: '#0587eb',
                        connectNulls: true,
                        marker: {
                            radius: 6
                        }
                    },
                    {
                        name: "N2",
                        data: Arr_Res_20_N2,
                        color: '#e600a1',
                        connectNulls: true,
                        marker: {
                            radius: 6
                        }
                    }
                ]
            });
            Hide_Modal();
            Fill_DataTable();
        }

        function buildGraph() {
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
                subtitle: {
                    text: _Subtitle
                },
                series: [
					{
					    name: "Resultado",
					    data: []
					},
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

        .true {
            cursor: pointer;
        }

        .fw600 {
            font-weight: 600 !important;
        }

        .bg-n1 {
            background-color: #def1ff !important;
        }

        .bg-n2 {
            background-color: #ffe9f8 !important;
        }
    </style>
    <%--Modal Ingreso--%>
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
    <%--Modal Omitir--%>
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
                            <div class="row">
                                <div class="col-lg">
                                    <h4 style="color: #0079d6">N1</h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg">
                                    <label for="mdl_Ana_Mod_N1">Analizador:</label>
                                    <input type="text" id="mdl_Ana_Mod_N1" class="form-control form-control-sm bg-n1" readonly />
                                </div>
                                <div class="col-lg">
                                    <label for="mdl_Lote_Mod_N1">Lote:</label>
                                    <input type="text" id="mdl_Lote_Mod_N1" class="form-control form-control-sm bg-n1" readonly />
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col-lg">
                                    <label for="mdl_Det_Mod_N1">Determinación:</label>
                                    <input type="text" id="mdl_Det_Mod_N1" class="form-control form-control-sm bg-n1" readonly />
                                </div>
                            </div>
                            <hr />
                            <div class="row mt-3">
                                <div class="col-lg">
                                    <label for="mdl_Txt_Res_N1">Resultado:</label>
                                    <input type="text" class="form-control form-control-sm bg-n1" id="mdl_Txt_Res_Mod_N1" readonly />
                                </div>
                                <div class="col-lg">
                                    <label for="fecha3_N1">Fecha:</label>
                                    <div class='input-group date' id='Txt_Date04_N1'>
                                        <input type='text' id="fecha4_N1" class="form-control form-control-sm bg-n1" readonly="true" placeholder="Fecha..." style="height: calc(1.8125rem + 2px);" />
                                        <span class="input-group-addon" style="height: calc(1.8125rem + 2px);">
                                            <i class="fa fa-calendar"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col-lg">
                                    <label for="mdl_Slt_Accion_Mod_N1">Acción:</label>
                                    <select class="form-control form-control-sm bg-n1" id="mdl_Slt_Accion_Mod_N1"></select>
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col-lg">
                                    <label for="mdl_Txt_Com_N1">Comentario:</label>
                                    <textarea class="form-control bg-n1" id="mdl_Txt_Com_Mod_N1"></textarea>
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col-lg text-center">
                                    <label class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="chk_Omitir_Mod_N1">
                                        <span class="custom-control-indicator"></span>
                                        <span class="custom-control-description">Omitir Resultado</span>
                                    </label>
                                </div>
                            </div>
                            <div class="row mt-3 text-center">
                                <div class="col-lg">
                                    <button type="button" class="btn btn-primary" id="mdl_Btn_Guardar_Mod_N1">Modificar N1</button>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg">
                            <div class="row">
                                <div class="col-lg">
                                    <h4 style="color: #d60096">N2</h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg">
                                    <label for="mdl_Ana_Mod_N2">Analizador:</label>
                                    <input type="text" id="mdl_Ana_Mod_N2" class="form-control form-control-sm bg-n2" readonly />
                                </div>
                                <div class="col-lg">
                                    <label for="mdl_Lote_Mod_N2">Lote:</label>
                                    <input type="text" id="mdl_Lote_Mod_N2" class="form-control form-control-sm bg-n2" readonly />
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col-lg">
                                    <label for="mdl_Det_Mod_N2">Determinación:</label>
                                    <input type="text" id="mdl_Det_Mod_N2" class="form-control form-control-sm bg-n2" readonly />
                                </div>
                            </div>
                            <hr />
                            <div class="row mt-3">
                                <div class="col-lg">
                                    <label for="mdl_Txt_Res_N2">Resultado:</label>
                                    <input type="text" class="form-control form-control-sm bg-n2" id="mdl_Txt_Res_Mod_N2" readonly />
                                </div>
                                <div class="col-lg">
                                    <label for="fecha3_N2">Fecha:</label>
                                    <div class='input-group date' id='Txt_Date04_N2'>
                                        <input type='text' id="fecha4_N2" class="form-control form-control-sm bg-n2" readonly="true" placeholder="Fecha..." style="height: calc(1.8125rem + 2px);" />
                                        <span class="input-group-addon" style="height: calc(1.8125rem + 2px);">
                                            <i class="fa fa-calendar"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col-lg">
                                    <label for="mdl_Slt_Accion_Mod_N2">Acción:</label>
                                    <select class="form-control form-control-sm bg-n2" id="mdl_Slt_Accion_Mod_N2"></select>
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col-lg">
                                    <label for="mdl_Txt_Com_N2">Comentario:</label>
                                    <textarea class="form-control bg-n2" id="mdl_Txt_Com_Mod_N2"></textarea>
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col-lg text-center">
                                    <label class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="chk_Omitir_Mod_N2">
                                        <span class="custom-control-indicator"></span>
                                        <span class="custom-control-description">Omitir Resultado</span>
                                    </label>
                                </div>
                            </div>
                            <div class="row mt-3 text-center">
                                <div class="col-lg">
                                    <button type="button" class="btn btn-primary" id="mdl_Btn_Guardar_Mod_N2">Modificar N2</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--Body--%>
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
                        <%--<div class="col-lg-3">
                            <button type="button" class="btn btn-warning btn-sm btn-block m-0 p-1" id="btn_Ing_Resul"><i class="fa fa-plus fa-fw"></i>Ing Resul</button>
                        </div>--%>
                    </div>
                    <%--Ocultar Tabla--%>
                    <div class="row text-center mb-1">
                        <div class="col-lg">
                            <button type="button" class="btn btn-block btn-sm btn-primary m-0 p-1" id="btn_Sec">Secciones</button>
                        </div>
                        <div class="col-lg">
                            <button type="button" class="btn btn-block btn-sm m-0 p-1" id="btn_Tabla">Tabla</button>
                        </div>
                    </div>
                    <%--Tabla--%>
                    <div style="height: 62vh; overflow: auto;" id="div_treeview" class="pt-2">
                        <ul id='f1combined' class='jslists'>
                            <li style="margin-left: 1vh !important">IrisLab QC
						        <ul id="ul_body">
                                </ul>
                            </li>
                        </ul>
                    </div>
                    <div style="height: 62vh; overflow: auto;" id="div_datatable">
                        <div class="pl-2 pb-1">
                            (*) Omitidos
                        </div>
                        <table id="DataTable" class="table table-hover table-striped table-iris">
                            <thead>
                                <tr>
                                    <th>N°
                                    </th>
                                    <th>Fecha
                                    </th>
                                    <th>N1
                                    </th>
                                    <th>N2
                                    </th>
                                    <th>West. N1
                                    </th>
                                    <th>West. N2
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                    <%--Datos--%>
                    <%--<div class="row mt-2">
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
                    </div>--%>
                    <%--Fijos--%>
                    <%--<div class="row mt-1">
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
                    </div>--%>
                    <%--Variables--%>
                    <%--<div class="row mt-1">
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
                    </div>--%>
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
                    <%--<div class="row mt-1 text-center">
                        <div class="col-lg form-mini">
                            <button type="button" class="btn btn-warning btn-sm" id="btn_Fijar_Var">
                                Fijar Variables
                            </button>
                        </div>
                    </div>--%>
                </div>
            </div>
        </div>
        <div class="col-lg-8">
            <div class="card border-bar">
                <div class="card-header text-center bg-bar">
                    <h5 class="card-title">Análisis de Datos N1 y N2</h5>
                </div>
                <div class="card-body" style="height: 70vh">
                    <div id="divGraph">
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
