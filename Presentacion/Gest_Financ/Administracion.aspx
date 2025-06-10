<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Administracion.aspx.vb" Inherits="Presentacion.Administracion" %>
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
                <a class="tab_item" href="Administracion/List_Ate_Prev_and_Prog_Ag_M.aspx">
                    <img src="../../Resourses/Img/Icons/Icon_Graph.png" />
                    <p>Atenciones por Previsión y Programa</p>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
