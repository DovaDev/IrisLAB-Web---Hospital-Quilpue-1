<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="iaas.aspx.vb" Inherits="Presentacion.iaas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">


<script>
    $(function () {
        $('.list-group-item').on('click', function () {
            $('.fa-chng', this)
                .toggleClass('fa-chevron-right')
                .toggleClass('fa-chevron-down');
        });
    });
</script>
<style>
    @media screen and (min-width:992px) {
        .xmb-3 {
            margin-bottom: 1rem !important;
        }
    }

    .fa-minus, .fa-chevron-right, .fa-chevron-down {
        margin-right: .25rem;
    }

    .card > .list-group:first-child .list-group-item:first-child {
        border-top-left-radius: 0;
        border-top-right-radius: 0;
    }

    .ttl {
        background-color: #00738e !important;
        color: white;
        border-top-right-radius: .25rem !important;
        border-top-left-radius: .25rem !important;
    }

    .subb > a:hover {
        background-color: #11819b;
        color: white;
    }

    .minn > a:hover, .minn0 > a:hover {
        background-color: #d1edf0;
        color: black;
    }

    .fa-minus {
        font-size: 12px;
    }

    .fa-chng {
        font-size: 14px;
    }

    .ttl:hover {
        color: white;
    }

    .subb > a {
        padding-left: 2em;
        background-color: #1d96b2;
        color: white;
    }

    .minn0 > a {
        padding-left: 2em;
        color: #212529;
    }

    .minn > a {
        padding-left: 3.5em;
        color: #212529;
    }


    .list-group.list-group-root {
        padding: 0;
        overflow: hidden;
    }

        .list-group.list-group-root .list-group {
            margin-bottom: 0;
        }

        .list-group.list-group-root .list-group-item {
            border-radius: 0;
            border-width: 1px 0 0 0;
        }

        .list-group.list-group-root > .list-group-item:first-child {
            border-top-width: 0;
        }

        .list-group.list-group-root > .list-group > .list-group-item {
            padding-left: 30px;
        }

        .list-group.list-group-root > .list-group > .list-group > .list-group-item {
            padding-left: 45px;
        }

    .list-group-item .glyphicon {
        margin-right: 5px;
    }
/*
    html {
        background-image: url("/Imagenes/background_gr_comp.jpg");
        background-repeat: no-repeat;
        min-height: 100%;
        min-width: 100%;
        background-size: cover;
        background-position: bottom left;
    }*/

    body, .content-wrapper, .card {
        background: none !important;
        background-color: none !important;
    }

    .card {
        border: none;
    }

    .list-group.list-group-root .list-group-item {
        border-width: 1px 1px 1px 1px;
        border-color: #00738e !important;
    }
    /*//////////////////*/
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">


    <div class="card">
        <div class="card-header bg-bar">
            <h4 class="text-center m-0"><i class="fa fa-check-square-o fa-fw"></i>IAAS</h4>
        </div>
        <div class="card-body">
            <div class="row xmb-3">
        <div class="col-lg mb-1">
            <div class="card border-bar">
                <div class="list-group list-group-root well">
                    <h6 class="m-0">
                    <a href="#item-1" class="list-group-item ttl" data-toggle="collapse">
                        <i class="fa fa-fw fa-chng fa-chevron-right"></i>IAAS
                    </a></h6>
                    <div class="collapse paddd minn0" id="item-1">
                        <a href="/iaas/reporte_iaas.aspx" class="list-group-item">
                            <i class="fa fa-fw fa-minus"></i>Reporte IAAS por Folio</a>

                         <a href="/iaas/reporte_iaas_fechas.aspx" class="list-group-item">
                            <i class="fa fa-fw fa-minus"></i>Reportes IAAS por Fechas</a>
<%--                        <a href="/Check_List/Rev_Deter_Exa.aspx" class="list-group-item">
                            <i class="fa fa-fw fa-minus"></i>Listado Resultados por Determinación</a>--%>
<%--                   <a href="/Check_List/Check_Point/Chk_Est_Exam.aspx" class="list-group-item">
                            <i class="fa fa-fw fa-minus"></i>Estados por Exámenes</a>
                    <a href="/Recha_Mues/Lis_recha_Mues.aspx" class="list-group-item">
                            <i class="fa fa-fw fa-minus"></i>Listado de examen rechazado </a>
                        <a href="/Reporte/Laboratorio/REP_LAB_CANT_EXA_TOT.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Cantidad total de exámenes realizados</a>
                        <a href="/Reporte/Hoja_de_Trabajo/HT_LugarTM.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Nomina pacientes atendidos con detalle de exámenes solicitados</a>
                        <a href="/Check_List/Val_Criticos.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Reporte de exámenes con Resultados Críticos</a>
                        <a href="/Check_List/REV_VALOR_ALTER.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Reporte de exámenes con Resultados alterados </a>
                        <a href="/Check_List/Rev_Deter_Exa_3.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Reporte de exámenes (todos) con Resultados </a>--%>
                    </div>
                    <div class="collapse paddd minn0" id="item-2">


                    </div>
                </div>
            </div>
        </div>
    </div>
        </div>
    </div>

    





</asp:Content>
