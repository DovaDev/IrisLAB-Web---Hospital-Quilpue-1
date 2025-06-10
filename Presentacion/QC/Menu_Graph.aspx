<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Menu_Graph.aspx.vb" Inherits="Presentacion.Menu_Graph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        $(document).ready(() => {
            $("#btn_Ana").click(() => {
                window.open("/QC/C_Mon_Res_QC.aspx");
            });
            $("#btn_Sec").click(() => {
                window.open("/QC/C_Graph_Sec.aspx");
            });
            $("#btn_Nivel").click(() => {
                window.open("/QC/C_Graph_Niveles.aspx");
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
            <li class="breadcrumb-item active" aria-current="page">Controles de Calidad</li>
        </ol>
    </nav>
    <div class="card border-bar">
        <div class="card-header bg-bar text-center">
            <h3 class="m-0">Controles de Calidad</h3>
        </div>
        <div class="card-body pb-4 pt-4">
            <div class="row">
                <div class="col-lg">
                    <button type="button" id="btn_Ana" class="btn btn-success btn-lg p-3 menu_Btn btn-block">QC Análisis</button>
                </div>
                <div class="col-lg">
                    <button type="button" id="btn_Sec" class="btn btn-danger btn-lg p-3 menu_Btn btn-block">QC Secciones</button>
                </div>
                <div class="col-lg">
                    <button type="button" id="btn_Nivel" class="btn btn-warning btn-lg p-3 menu_Btn btn-block">QC Niveles</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
