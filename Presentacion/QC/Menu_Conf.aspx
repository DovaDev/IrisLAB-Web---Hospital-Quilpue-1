<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Menu_Conf.aspx.vb" Inherits="Presentacion.Menu_Conf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        $(document).ready(() => {
            $("#btn_Ana").click(() => {
                window.location.href = "/QC/C_Analizador.aspx";
            });
            $("#btn_SecAna").click(() => {
                window.location.href = "/QC/C_SecAnalisis.aspx";
            });
            $("#btn_Analito").click(() => {
                window.location.href = "/QC/C_Analito.aspx";
            });
            $("#btn_Lote").click(() => {
                window.location.href = "/QC/C_Lote2.aspx";
            });
            $("#btn_AnaCan").click(() => {
                window.location.href = "/QC/C_Rel_Ana_Det_Can.aspx";
            });
            $("#btn_TPA").click(() => {
                window.location.href = "/QC/C_TP_Accion.aspx";
            });
            $("#btn_CopiaLote").click(() => {
                window.location.href = "/QC/C_Copia_Lote.aspx";
            });
            //$("#btn_Rel_NL").click(() => {
            //    window.open("/QC/C_Nivel_Lote.aspx");
            //});
            $("#btn_Rel_CAN_RANG").click(() => {
                window.open("/QC/C_Can_Rang.aspx");
            });
        });
    </script>
    <style>
        .menu_Btn {
            font-size: 25px;
            border-radius: 130px;
        }
    </style>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-2 p-2">
            <li class="breadcrumb-item"><a href="/QC/Menu_QC.aspx">Menú</a></li>
            <li class="breadcrumb-item active" aria-current="page">Configuración</li>
        </ol>
    </nav>
    <div class="card border-bar">
        <div class="card-header bg-bar text-center">
            <h3 class="m-0">Configuración QC</h3>
        </div>
        <div class="card-body pb-4 pt-4">
            <div class="row">
                <div class="col-lg">
                    <button type="button" id="btn_Ana" class="btn btn-success btn-lg p-3 menu_Btn btn-block">Analizadores</button>
                </div>
                <div class="col-lg">
                    <button type="button" id="btn_SecAna" class="btn btn-danger btn-lg p-3 menu_Btn btn-block">Sección de Análisis</button>
                </div>
                <div class="col-lg">
                    <button type="button" id="btn_Analito" class="btn btn-warning btn-lg p-3 menu_Btn btn-block">Crear Analito</button>
                </div>
                <div class="col-lg">
                    <button type="button" id="btn_Lote" class="btn btn-primary btn-lg p-3 menu_Btn btn-block">Crear Lote</button>
                </div>
            </div>
            <div class="row">
                <div class="col-lg">
                    <button type="button" id="btn_CopiaLote" class="btn btn-success btn-lg p-3 menu_Btn btn-block">Copiar Lote</button>
                </div>
                <div class="col-lg">
                    <button type="button" id="btn_TPA" class="btn btn-danger btn-lg p-3 menu_Btn btn-block">Crear Tipo de Acción</button>
                </div>
                <div class="col-lg">
                    <button type="button" id="btn_AnaCan" class="btn btn-warning btn-lg p-3 menu_Btn btn-block">Rel. Analizador-Canales</button>
                </div>
                <div class="col-lg">
                  <%--  <button type="button" id="btn_Rel_NL" class="btn btn-primary btn-lg p-3 menu_Btn btn-block">Rel. Nivel-Lote</button>--%>
                </div>
            </div>
        </div>
    </div>

    <div class="card border-bar mt-2">
        <div class="card-header bg-bar text-center">
            <h3 class="m-0">Configuración Medias Móviles</h3>
        </div>
        <div class="card-body pb-4 pt-4">
            <div class="row">
                <div class="col-lg">
                    <button type="button" id="btn_Rel_CAN_RANG" class="btn btn-success btn-lg p-3 menu_Btn btn-block">Rel. Canal-Rangos</button>
                </div>
                <div class="col-lg">
                 
                </div>
                <div class="col-lg">
                
                </div>
                <div class="col-lg">
                 
                </div>
            </div>
        </div>
    </div>
</asp:Content>
