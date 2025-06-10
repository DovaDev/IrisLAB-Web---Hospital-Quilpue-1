<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Analisis_Atenciones.aspx.vb" Inherits="Presentacion.Analisis_Atenciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true"%>
    <link href="../../Resourses/Style/Tabs.css" rel="stylesheet" />
    <script src="../../Resourses/JS/jQuery.js"></script>
    <script>
        $(document).ready(function () {
            $('.main_tab p').click(function () {
                $(this).parent(".main_tab").children('.inner_tab').slideToggle(250);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="flex_col">
        <div class="div_main main_tab">
            <p>Detalle</p>
            <div class="inner_tab">
                <a class="tab_item" href="Analisis_Atenciones/AnaAteTPago.aspx">
                    <img src="../../Resourses/Img/Icons/icoGraficoATE.png" />
                    <p>Análisis por Forma de Pago</p>
                </a>
                <a class="tab_item" href="Analisis_Atenciones/AnaOrdAte.aspx">
                    <img src="../../Resourses/Img/Icons/icoGraficoATE.png" />
                    <p>Análisis por Orden de Atención</p>
                </a>
                <a class="tab_item" href="Analisis_Atenciones/AnaPrev.aspx">
                    <img src="../../Resourses/Img/Icons/icoGraficoATE.png" />
                    <p>Análisis por Previsión</p>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
