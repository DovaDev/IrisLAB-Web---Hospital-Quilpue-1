<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Estadisticas.aspx.vb" Inherits="Presentacion.Estadisticas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true"%>
    <link href="../../Resourses/Style/Tabs.css" rel="stylesheet" />
    <title>Estadísticas</title>
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
                <a class="tab_item" href="Estadisticas/Detalle/Prevision_Det.aspx">
                    <img src="../../Resourses/Img/Icons/Icons_gest_finan_est/01(2).png" />
                    <p>Previsión</p>
                </a>
                <a class="tab_item" href="Estadisticas/Detalle/Medico_Det.aspx">
                    <img src="../../Resourses/Img/Icons/Icons_gest_finan_est/03(2).png" />
                    <p>Médico</p>
                </a>
                <a class="tab_item" href="Estadisticas/Detalle/LugarTM_Det.aspx">
                    <img src="../../Resourses/Img/Icons/Icons_gest_finan_est/03(2).png" />
                    <p>Atenciones por Lugar TM</p>
                </a>
            </div>
        </div>
        <div class="div_main main_tab">
            <p>Resumen</p>
            <div class="inner_tab">
                <a class="tab_item" href="Estadisticas/Resumen/Prevision_Sum.aspx">
                    <img src="../../Resourses/Img/Icons/Icons_gest_finan_est/01.png" />
                    <p>Previsión</p>
                </a>
                <a class="tab_item" href="Estadisticas/Resumen/Medico_Sum.aspx">
                    <img src="../../Resourses/Img/Icons/Icons_gest_finan_est/03.png" />
                    <p>Médicos</p>
                </a>
                <a class="tab_item" href="Estadisticas/Resumen/Procedencia_Sum.aspx">
                    <img src="../../Resourses/Img/Icons/Icons_gest_finan_est/04.png" />
                    <p>Procedencia</p>
                </a>
                <a class="tab_item" href="Estadisticas/Resumen/Atenciones_Sum.aspx">
                    <img src="../../Resourses/Img/Icons/Icons_gest_finan_est/05.png" />
                    <p>Atenciones</p>
                </a>
                <a class="tab_item" href="Estadisticas/Resumen/Examenes_Sum.aspx">
                    <img src="../../Resourses/Img/Icons/Icons_gest_finan_est/02.png" />
                    <p>Exámenes</p>
                </a>
                <a class="tab_item" href="Estadisticas/Resumen/Usuarios_Sum.aspx">
                    <img src="../../Resourses/Img/Icons/Icons_gest_finan_est/07.png" />
                    <p>Usuarios</p>
                </a>
                <a class="tab_item" href="Estadisticas/Resumen/OrdenAtencion_Sum.aspx">
                    <img src="../../Resourses/Img/Icons/Icons_gest_finan_est/06.png" />
                    <p>Orden Atención</p>
                </a>
                <a class="tab_item" href="Estadisticas/Resumen/LugarTM_Prev_Sum.aspx">
                    <img src="../../Resourses/Img/Icons/Icons_gest_finan_est/08.png" />
                    <p>Lugar TM y Previsión</p>
                </a>
                <a class="tab_item" href="Estadisticas/Resumen/Pacientes_Sum.aspx">
                    <img src="../../Resourses/Img/Icons/Icons_gest_finan_est/10.png" />
                    <p>Atenciones por Paciente</p>
                </a>
                <a class="tab_item" href="Estadisticas/Resumen/AteResumen_Sum.aspx">
                    <img src="../../Resourses/Img/Icons/Icons_gest_finan_est/09.png" />
                    <p>Resultados Filtrados</p>
                </a>
                <a class="tab_item" href="Estadisticas/Resumen/Res_Peñalolen_Sum_Alt.aspx">
                    <img src="../../Resourses/Img/Icons/Icons_gest_finan_est/09.png" />
                    <p>Resultados Peñalolén</p>
                </a>
                <a class="tab_item" href="Estadisticas/Resumen/Res_Peñalolen_Sum.aspx">
                    <img src="../../Resourses/Img/Icons/Icons_gest_finan_est/09.png" />
                    <p>Resultados Peñalolén (por email)</p>
                </a>
            </div>
        </div>
        <div class="div_main main_tab">
            <p>Múltiple</p>
            <div class="inner_tab">
                <a class="tab_item" href="Estadisticas/Multiple/Prev_TM_Exa_Mult.aspx">
                    <img src="../../Resourses/Img/Icons/Icons_gest_finan_est/09.png" />
                    <p>Previsión - Lugar TM - Médicos - Exámenes</p>
                </a>
            </div>
        </div>
    </div>
</asp:Content>