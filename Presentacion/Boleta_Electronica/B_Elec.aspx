<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="B_Elec.aspx.vb" Inherits="Presentacion.B_Elec" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        let id_atee = "";
        let ate_numm = "";

        let Mx_DataTable = [{
            "ID_ATENCION": "",
            "ATE_NUM": "",
            "ATE_FECHA": "",
            "PAC_NOMBRE": "",
            "PAC_APELLIDO": "",
            "ID_PACIENTE": "",
            "PAC_RUT": "",
            "PREVE_DESC": "",
            "PROC_DESC": ""
        }];

        $(document).ready(function () {
            $("#txt_Folio").val("");


            id_atee = getParameterByName("IDA");
            let isn = $.isNumeric(id_atee);

            if (isn == true) {
                Data_Par = JSON.stringify({
                    "ID_ATENCION": id_atee
                });

                AJAX_Grabar = $.ajax({
                    "type": "POST",
                    "url": "B_Elec.aspx/Busca_Folio",
                    "data": Data_Par,
                    "contentType": "application/json;  charset=utf-8",
                    "dataType": "json",
                    "success": data => {
                        if (data != null) {
                            ate_numm = data.d
                            $("#txt_Folio").val(ate_numm);
                            Llenar_DataTable();
                        } else {
                        }
                    },
                    "error": data => {
                        console.log(data);
                    }
                });
            } else {
            }

            $("#txt_Folio").focus();

            $("#Btn_Buscar").click(() => {
                ate_numm = $("#txt_Folio").val();
                Llenar_DataTable();
            });

            $("#btn_Left").click(() => {
                let v_txt_Ate = $("#txt_Folio").val();
                if (v_txt_Ate != "" && $.isNumeric(v_txt_Ate) == true && v_txt_Ate > 1) {
                    v_txt_Ate = parseInt(v_txt_Ate) - 1;
                    $("#txt_Folio").val(v_txt_Ate);
                    ate_numm = v_txt_Ate;
                    Llenar_DataTable();
                }
            });

            $("#btn_Right").click(() => {
                let v_txt_Ate = $("#txt_Folio").val();
                if (v_txt_Ate != "" && $.isNumeric(v_txt_Ate) == true) {
                    v_txt_Ate = parseInt(v_txt_Ate) + 1;
                    $("#txt_Folio").val(v_txt_Ate);
                    ate_numm = v_txt_Ate;
                    Llenar_DataTable();
                }
            });

            $("#txt_Folio").on('keypress', (e) => {
                if (e.which == 13) {
                    ate_numm = $("#txt_Folio").val();
                    Llenar_DataTable();
                }
            });


            $("#Btn_Limpiar").click(() => {
                Limpiar();
            });

            $("#btn_BE").click(() => {

                let xp = id_atee;
                var dataParam = JSON.stringify(xp);

                console.log(dataParam);

                $.ajax({
                    "type": "POST",

                    "url": "http://localhost:9990/Printer/Imp_Boleta_Electronica",
                    "data": dataParam,
                    "contentType": "application/json;  charset=utf-8",
                    "contentType": "text/plain;  charset=utf-8",
                    "dataType": "json",
                    "timeout": 15000,
                    "success": function (response) {

                        console.log(response);
                    },
                    "error": function (response) {

                        console.log(response);

                    }
                });

            });
        });

        function Limpiar() {
            id_atee = "";
            ate_numm = "";
            $("#Ate_Folio").text("");
            $("#Ate_Nombre").text("");
            $("#Ate_Fecha").text("");
            $("#Ate_Rut").text("");
            $("#Ate_Proce").text("");
            $("#Ate_Preve").text("");
            $("#txt_Folio").val("");
            $("#txt_Folio").focus();
            $("#btn_BE").attr("hidden", true);
        }

        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }

        function modal_show() {
            $(".modalcarga").show();
            $(".container-fluid, .navbar").addClass("blur");


        };

        function Hide_Modal() {
            $(".container-fluid, .navbar").removeClass("blur");
            $(".modalcarga").fadeOut(250);
        }

        function Llenar_DataTable() {
            modal_show();
            $("#txt_BE").text("");

            let Data_Par = JSON.stringify({
                "ATE_NUM": ate_numm
            });
            //Debug
            AJAX_Dtt = $.ajax({
                "type": "POST",
                "url": "B_Elec.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_DataTable = data.d;
                    //console.log(Mx_DataTable);
                    if (Mx_DataTable != null) {
                        Fill_DataTable();
                    } else {
                        $("#btn_BE").attr("hidden",true);
                        Limpiar();
                        Hide_Modal();
                    }
                },
                "error": data => {
                    $("#btn_BE").attr("hidden",true);
                    Limpiar();
                    Hide_Modal();
                }
            });
        }

        function Fill_DataTable() {

            id_atee = Mx_DataTable.ID_ATENCION

            $("#Ate_Folio").text(Mx_DataTable.ATE_NUM);
            $("#Ate_Nombre").text(Mx_DataTable.PAC_NOMBRE + " " + Mx_DataTable.PAC_APELLIDO);
            $("#Ate_Fecha").text(moment(Mx_DataTable.ATE_FECHA).format("DD-MM-YYYY"));
            $("#Ate_Rut").text(Mx_DataTable.PAC_RUT);
            $("#Ate_Proce").text(Mx_DataTable.PROC_DESC);
            $("#Ate_Preve").text(Mx_DataTable.PREVE_DESC);

            if (Mx_DataTable.TOT_BE > 0) {
                $("#btn_BE").removeAttr("hidden");

                let xx = getParameterByName("IDA");
                if (xx != "" && xx == id_atee) {
                    $("#btn_BE").trigger("click");
                }

            }
            else {
                $("#btn_BE").attr("hidden", true);
                $("#txt_BE").text("Sin exámenes afectos.");
            }

            Hide_Modal();
        }
    </script>
    <style>
        .gallery-docs {
            padding: 7px;
            background-color: white;
            border: 1px #a7a7a7 solid !important;
            border-radius: 2px;
            margin: 10px 5px 10px 5px;
        }

        .f-h5 {
            font-size: 1.2rem;
        }

        .modal-dialog {
            margin: 10px auto !important;
        }
    </style>
    <div class="container">
        <div class="card border-bar mb-3 mt-3">
            <div class="card-header text-center bg-bar">
                <h5 class="m-0"><i class="fa fa-user fa-fw"></i>Datos de Atención</h5>
            </div>
            <div class="card-body">
                <div class="row mb-2">
                    <div class="col-lg-3 mb-2">
                        <div class="row">
                            <div class="col pr-0">
                                Folio:
                            </div>
                            <i class="fa fa-arrow-left d-inline btn btn-sm btn-primary" id="btn_Left"></i>
                            <div class="col-6 p-0">
                                <input type="text" id="txt_Folio" class="form-control form-control-sm text-danger font-weight-bold pt-0 pb-0" style="font-size: 1.2rem" />
                            </div>
                            <i class="fa fa-arrow-right d-inline btn btn-sm btn-primary" id="btn_Right"></i>
                        </div>
                    </div>
                    <div class="col-lg mb-2">
                        <button type="button" id="Btn_Buscar" class="btn btn-buscar btn-sm btn-block">Buscar</button>
                    </div>
                    <div class="col-lg mb-2">
                        <button type="button" id="Btn_Limpiar" class="btn btn-limpiar btn-sm btn-block">Limpiar</button>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg f-h5">Folio: <span id="Ate_Folio"></span></div>
                    <div class="col-lg-4 f-h5">Fecha: <span id="Ate_Fecha"></span></div>
                </div>
                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg f-h5">Nombre: <span id="Ate_Nombre"></span></div>
                    <div class="col-lg-4 f-h5">RUT: <span id="Ate_Rut"></span></div>
                </div>
                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg f-h5">Procedencia: <span id="Ate_Proce"></span></div>
                    <div class="col-lg-4 f-h5">Previsión: <span id="Ate_Preve"></span></div>
                </div>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg text-center">
                <h4>Boleta Electrónica</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-lg text-center">
                <h5 class="text-danger" id="txt_BE"></h5>
                <button type="button" id="btn_BE" class="btn btn-success" hidden>Emitir Boleta</button>
            </div>
        </div>
    </div>

</asp:Content>
