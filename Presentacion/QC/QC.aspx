<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="QC.aspx.vb" Inherits="Presentacion.QC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <script src="../js/HighCharts.js"></script>
    <script src="../js/HighC_Exporting.js"></script>
    <script src="QC.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">

    <div class="row">
        <div class="col-lg-3">
            <div class="card border-bar">
                <div class="card-header text-center bg-bar">
                    <h5 class="card-title">Búsqueda</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg">
                            <label for="fecha">Desde:</label>
                            <div class='input-group date' id='Txt_Date01'>
                                <input type='text' id="fecha" class="form-control  form-control-sm" readonly="true" placeholder="Desde..." style="background: #ffffff !important; font-size: 13px;" />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg">
                            <label for="fecha">Hasta:</label>
                            <div class='input-group date' id='Txt_Date02'>
                                <input type='text' id="fecha2" class="form-control  form-control-sm" readonly="true" placeholder="Hasta..." style="background: #ffffff !important; font-size: 13px;" />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg">
                            <label for="slt_Int">Interfaz:</label>
                            <select id="slt_Int" class="form-control form-control-sm"></select>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg">
                            <label for="slt_Maq">Analizador:</label>
                            <select id="slt_Maq" class="form-control form-control-sm"></select>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg">
                            <label for="slt_Det">Determinación:</label>
                            <select id="slt_Det" class="form-control form-control-sm"></select>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg">
                            <label for="txt_Tim">Actualizar:</label>
                            <div class="input-group">
                                <div class="input-group-btn">
                                    <button type="button" id="Btn_Interval" class="btn btn-success btn-sm" disabled="disabled">
                                        <i class="fa fa-play btnplay" aria-hidden="true"></i>
                                    </button>
                                    <button type="button" id="Btn_Reload" class="btn btn-primary btn-sm" disabled="disabled">
                                        <i class="fa fa-refresh" aria-hidden="true"></i>
                                    </button>
                                </div>
                                <input id="Txt_Interval" type="text" class="form-control form-control-sm">
                                <span class="input-group-addon py-0 text-primary" id="CuentaAtras"></span>
                            </div>

                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-lg">
                            <label for="txt_Agr">Agrupación:</label>

                        </div>
                        <div class="col-lg">
                            <input type="text" id="txt_Agr" class="form-control  form-control-sm" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg">
                            <div class="form-check ml-1">
                                <input type="checkbox" id="chk_Ref" checked="checked">
                                <label class="form-check-label pl-0" for="chk_Ref">Rangos de Referencia:</label>
                            </div>
                            <div class="input-group">
                                <input type="text" id="Txt_V_BAJO" class="form-control form-control-sm" placeholder="Rango Min" />
                                <span class="input-group-addon">
                                    <i class="fa fa-minus" aria-hidden="true"></i>
                                </span>
                                <span class="input-group-addon">
                                    <i class="fa fa-plus" aria-hidden="true"></i>
                                </span>
                                <input type="text" id="Txt_V_ALTO" class="form-control form-control-sm" placeholder="Rango Máx" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg">

                            <div class="form-check ml-1">
                                <input type="checkbox" id="chk_Cri" checked="checked">
                                <label class="form-check-label pl-0" for="chk_Cri">Valores Críticos</label>
                            </div>

                            <div class="input-group">
                                <input type="text" id="Txt_VC_BAJO" class="form-control form-control-sm" placeholder="Rango Min" />
                                <span class="input-group-addon">
                                    <i class="fa fa-minus" aria-hidden="true"></i>
                                </span>
                                <span class="input-group-addon">
                                    <i class="fa fa-plus" aria-hidden="true"></i>
                                </span>
                                <input type="text" id="Txt_VC_ALTO" class="form-control form-control-sm" placeholder="Rango Máx" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="col-lg-9">
            <div class="card border-bar">
                <div class="card-header text-center bg-bar">
                    <h5 class="card-title">Medias Móviles</h5>
                </div>
                <div class="card-body">
                    <div class="row text-center">
                    </div>
                    <div id="divGraph">
                        <div class="alert alert-info">Esperando Resultados</div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
