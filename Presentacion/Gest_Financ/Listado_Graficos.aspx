<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Listado_Graficos.aspx.vb" Inherits="Presentacion.Listado_Graficos" %>
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
                <a class="tab_item" href="Lista_Graficos/GraficoAtenciones.aspx">
                    <img src="../../Resourses/Img/Icons/icoGraficoATE.png" />
                    <p>Gráfico de Atenciones</p>
                </a>
                <a class="tab_item" href="Lista_Graficos/GraficoExamenes.aspx">
                    <img src="../../Resourses/Img/Icons/icGraficoEXA.png" />
                    <p>Gráfico de Exámenes</p>
                </a>
                <a class="tab_item" href="Lista_Graficos/Lis_Ate_Totales.aspx">
                    <img src="../../Resourses/Img/Icons/icoGraficoATETo.png" />
                    <p>Listado de Atenciones (Totales)</p>
                </a>
                <a class="tab_item" href="Lista_Graficos/GraficoT_Sistema.aspx">
                    <img src="../../Resourses/Img/Icons/icoGraficoSis.png" />
                    <p>Total Sistema Mensual</p>
                </a>
                <a class="tab_item" href="Lista_Graficos/GraficoPAC_Mensual.aspx">
                    <img src="../../Resourses/Img/Icons/icoGraficoPAC.png" />
                    <p>Total Paciente Mensual</p>
                </a>
                 <a class="tab_item" href="Lista_Graficos/GraficoCOPAGO.aspx">
                    <img src="../../Resourses/Img/Icons/Icon_Graph.png" />
                    <p>Total Copago Mensual</p>
                </a>
                <a class="tab_item" href="Lista_Graficos/GraficoPrevision.aspx">
                    <img src="../../Resourses/Img/Icons/Icon_Graph.png" />
                    <p>Total Previsiones</p>
                </a>
                <a class="tab_item" href="Lista_Graficos/GraficoOrdAte.aspx">
                    <img src="../../Resourses/Img/Icons/Icon_Graph.png" />
                    <p>Cantidad Anual de Orden de Atenc.</p>
                </a>
            </div>
        </div>
        
        <div class="div_main main_tab">
            <p>Por Hora</p>
            <div class="inner_tab">
                <a class="tab_item" href="Lista_Graficos/GraficoHORA_ATE.aspx">
                    <img src="../../Resourses/Img/Icons/Icon_Graph.png" />
                    <p>Atenciones por Hora</p>
                </a>
                 <a class="tab_item" href="Lista_Graficos/GraficoHORA_EXA.aspx">
                    <img src="../../Resourses/Img/Icons/Icon_Graph.png" />
                    <p>Exámenes por Hora</p>
                </a>
            </div>
        </div>
        
        <div class="div_main main_tab">
            <p>Análisis</p>
            <div class="inner_tab">
                 <a class="tab_item" href="Lista_Graficos/Ana_LTM.aspx">
                    <img src="../../Resourses/Img/Icons/Icon_Graph.png" />
                    <p>Análisis de Lugar de Toma de Muestra</p>
                </a>
                 <a class="tab_item" href="Lista_Graficos/GraficoAteTP.aspx">
                    <img src="../../Resourses/Img/Icons/Icon_Graph.png" />
                    <p>Análisis de Atenciones por Tipo de Pago</p>
                </a>
                <a class="tab_item" href="Lista_Graficos/GraficoSecre.aspx">
                    <img src="../../Resourses/Img/Icons/Icon_Graph.png" />
                    <p>Análisis por Secretaria </p>
                </a>
                 <a class="tab_item" href="Lista_Graficos/Ana_MED.aspx">
                    <img src="../../Resourses/Img/Icons/Icon_Graph.png" />
                    <p>Análisis por Médico</p>
                </a>
                <a class="tab_item" href="Lista_Graficos/Ana_PAC.aspx">
                    <img src="../../Resourses/Img/Icons/Icon_Graph.png" />
                    <p>Análisis por Paciente</p>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
