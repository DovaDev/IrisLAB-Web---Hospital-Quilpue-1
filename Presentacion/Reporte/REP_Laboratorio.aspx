<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="REP_Laboratorio.aspx.vb" Inherits="Presentacion.REP_Laboratorio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true"%>
    <link href="../../Resourses/Style/Tabs.css" rel="stylesheet" />
    <script src="../../Resourses/JS/jQuery.js"></script>
    <%-- <script>
        $(document).ready(function () {
            $('.main_tab p').click(function () {
                $(this).parent(".main_tab").children('.inner_tab').slideToggle(250);
            });
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="flex_col">
        <div class="div_main main_tab">
            <p>Detalle</p>
            <div class="inner_tab">
                <a class="tab_item" href="Laboratorio/REP_LAB_EXA.aspx">
                    <img src="../../Resourses/Img/Icons/ReporXexa.png" />
                    <p>Reportes Laboratorio por Exámen</p>
                </a>
                <a class="tab_item" href="Laboratorio/REP_LAB_SEC.aspx">
                    <img src="../../Resourses/Img/Icons/RepXsec.png" />
                    <p>Reportes Laboratorio por Sección</p>
                </a>
                <a class="tab_item" href="Laboratorio/REP_LAB_CANT_EXA_TOT.aspx">
                    <img src="../../Resourses/Img/Icons/ReporXexa.png" />
                    <p>Cantidad de Exámenes Totales</p>
                </a>
                <a class="tab_item" href="Laboratorio/REP_LAB_CANT_EXA_AREA.aspx">
                    <img src="../../Resourses/Img/Icons/RepAreTrab.png" />
                    <p>Cantidad de Exámenes por Ärea de Trabajo</p>
                </a>
                 <a class="tab_item" href="Laboratorio/REP_LAB_CANT_EXA_ARE_SECC.aspx">
                    <img src="../../Resourses/Img/Icons/RepXexsec.png" />
                    <p>Cantidad de Exámenes por Seccion</p>
                </a>
                <a class="tab_item" href="Laboratorio/REP_LAB_CANT_EXA_ARE_SECC.aspx">
                    <img src="../../Resourses/Img/Icons/RepXtsec.png" />
                    <p>Cantidad de Exámenes Área y Seccion</p>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
