<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Menu_QC.aspx.vb" Inherits="Presentacion.Menu_QC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        $(document).ready(() => {
            $("#btn_CO").click(() => {
                window.location.href = "/QC/Menu_Conf.aspx";
            });
            $("#btn_QC").click(() => {
                window.location.href = "/QC/Menu_Graph.aspx";
            });
            $("#btn_MM").click(() => {
                window.location.href = "/QC/Medias_Moviles.aspx";
            });
        });
    </script>
    <div class="row">
        <div class="col-lg text-center">
            <img class="align-middle" style="max-height: 30vh" src="../Imagenes/IrisLab%20Logo%20LARGOa.png" />
            <span style="font-size: 100px" class="align-middle font-weight-bold pb-3 text-success">Q</span>
            <span style="font-size: 100px; color: #85d000;" class="align-middle font-weight-bold pb-3">C</span>
        </div>
    </div>
    <div class="row text-center mt-5">
        <div class="col-lg">
            <button type="button" id="btn_QC" class="btn btn-danger btn-lg p-4" style="font-size: 35px; border-radius: 130px"><i class="fa fa-line-chart mr-3"></i>Control de Calidad</button>
        </div>
        <div class="col-lg">
            <button type="button" id="btn_MM" class="btn btn-warning btn-lg p-4" style="font-size: 35px; border-radius: 130px"><i class="fa fa-line-chart mr-3"></i>Medias Móviles</button>
        </div>
        <div class="col-lg">
            <button type="button" id="btn_CO" class="btn btn-primary btn-lg p-4" style="font-size: 35px; border-radius: 130px"><i class="fa fa-cog mr-3"></i>Configuración</button>
        </div>
    </div>
</asp:Content>
