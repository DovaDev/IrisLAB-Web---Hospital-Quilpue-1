<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Reportes.aspx.vb" Inherits="Presentacion.Reportes" %>

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

        

       

        

        .list-group.list-group-root .list-group-item {
            border-width: 1px 1px 1px 1px;
            border-color: #00738e !important;
        }
        /*//////////////////*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">


    <div class="card border-bar">
        <div class="card-header bg-bar">
            <h4 class="text-center m-0"><i class="fa fa-check-square-o fa-fw"></i>Reportes</h4>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-1" class="list-group-item ttl" data-toggle="collapse" style="background-color:#cf3d4c !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Reportes
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-1">
                                <a href="/Reporte/Laboratorio/Lis_Dialisis.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Listado de Diálisis</a>
                                <a href="/Reporte/Laboratorio/REP_LAB_EXA.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Reportes Laboratorio por Exámen</a>
                                <a href="/Reporte/Laboratorio/REP_LAB_EXA_3.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Reportes Laboratorio vih y screening de sifilis</a>
                                <a href="/Reporte/Laboratorio/REP_LAB_SEC.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Reportes Laboratorio por Sección</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-2" class="list-group-item ttl" data-toggle="collapse" style="background-color:#923b6c !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Cantidad Exámenes
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-2">
                                <a href="/Reporte/Laboratorio/REP_LAB_CANT_EXA_TOT.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Cantidad de Exámenes Totales</a>
                                <a href="/Reporte/Laboratorio/REP_LAB_CANT_EXA_AREA.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Cantidad de Exámenes por Area de Trabajo</a>
                                <a href="/Reporte/Laboratorio/REP_LAB_CANT_EXA_SECC.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Cantidad de Exámenes por Sección</a>
                                <a href="/Reporte/Laboratorio/REP_LAB_CANT_EXA_ARE_SECC.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Cantidad de Exámenes Area y Sección</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-3" class="list-group-item ttl" data-toggle="collapse" style="background-color:#5e3d8f !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Secretaría
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-3">
                                <a href="/Reporte/Secretaria/DET_ATE_X_USU.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Detalle de Atenciones por Usuario</a>
                                <a href="/Reporte/Secretaria/RESU_ING_USU.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Resumen Ingresos por Usuario</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-4" class="list-group-item ttl" data-toggle="collapse" style="background-color:#155ac2 !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Hoja de Trabajo
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-4">
                                <a href="/Reporte/Hoja_de_Trabajo/HT_Sec_Imp.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>HT por Seccion sin Hemograma</a>
                                <a href="/Reporte/Hoja_de_Trabajo/HT_exa.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Hoja Trabajo por Examen</a>
                                <a href="/Reporte/Hoja_de_Trabajo/HT_Secc.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Hoja Trabajo por Seccion</a>
                                <a href="/Reporte/Hoja_de_Trabajo/HT_LugarTM.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Hoja Trabajo por Lugar TM</a>
                                <a href="/Reporte/Hoja_de_Trabajo/Ate_LTM_Detalle.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Ate. por Lugar TM Detallado</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
