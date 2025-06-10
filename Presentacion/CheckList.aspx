<%@ Page Title="CheckList" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="CheckList.aspx.vb" Inherits="Presentacion.CheckList" %>

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
            <h4 class="text-center m-0"><i class="fa fa-check-square-o fa-fw"></i>Check List</h4>
        </div>
        <div class="card-body">
            <div class="row xmb-3">
                <div class="col-lg mb-1">
                    <div class="card">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-1" class="list-group-item ttl" data-toggle="collapse" style="background-color: #d29d2f !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Check Point
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-1">
                                <a href="/Check_List/Check_Point/Chk_Est_Exam.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Estados por Exámenes</a>
                                <a href="/Check_List/Check_Point/Chk_Est_Seccion.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Estados por Sección</a>
                                <a href="/Check_List/Check_Point/Chk_Tubo_Sec.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Check Tubos (Por Sección)</a>
                                <a href="/Check_List/Check_Point/Chk_Tubo_Proce_2.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Check de Tubos y Procedencia</a>
                                <a href="/Check_List/Check_Point/Lis_OC_Sed.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Búsqueda Orina y Sedimento</a>
                                <a href="/Check_List/Check_Point/HT_Sec_Proce.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>HT - Sección y Procedencia</a>
                                <a href="/Check_List/Check_Point/Lis_Deriv_Exa.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Listado de Exámenes Derivados</a>
                                <a href="/Check_List/Check_Point/Traza_Folio.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Trazabilidad por Folio</a>
                                <a href="/Check_List/Check_Point/Traza_Fechas.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Trazabilidad por Fechas</a>
                                <a href="/Check_List/Check_Point/Traza_Env_RecepLab.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Trazabilidad por Envío - Recepción y Recepción en Laboratorio</a>
                                <a href="/Check_List/Check_Point/Lis_Det_Resul.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Listado de Detalle de Resultados</a>
                                <a href="/Check_List/Check_Point/List_Pap.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Listado PAP</a>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-lg mb-1">
                    <div class="card">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-2" class="list-group-item ttl" data-toggle="collapse" style="background-color: #cf3d3d !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Revisiones</a>
                            </h5>
                            <div class="collapse paddd minn0" id="item-2">
                                <a href="/Check_List/Rev_Est_Exa.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Revisar Estado de Exám.</a>
                                <a href="/Check_List/Rev_Est_Exa2.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Revisar Estado de Exám. 2</a>
                                <a href="/Check_List/Ver_Det_Pend.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Revisar Determinaciones en Espera</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg mb-1">
                    <div class="card">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-3" class="list-group-item ttl" data-toggle="collapse" style="background-color: #923b6c !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Exám. Pendiente 
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-3">
                                <a href="/Check_List/Exa_Pen_Sec.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Ver Exám. Pendiente por Sección</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg mb-1">
                    <div class="card">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-4" class="list-group-item ttl" data-toggle="collapse" style="background-color: #5e3d8f !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Cantidad Exámenes
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-4">
                                <a href="/Check_List/Cant_Exa_Dia.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Ver Cantidad Exámenes Diarios</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg mb-1">
                    <div class="card">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-5" class="list-group-item ttl" data-toggle="collapse" style="background-color: #008cd8 !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Resultados por Det.
                                </a>
                            </h5>
                            <div class="collapse paddd minn0" id="item-5">
                                <a href="/Check_List/Rev_Deter_Exa.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Listado de Exámenes con Resultados</a>
                                <a href="/Check_List/Rev_Deter_Exa_3.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Listado de Exámenes con Resultados y Notificaciones</a>
                                <a href="/Check_List/Rev_Deter_Exa_4.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Listado de Exámenes con Resultados y Notificaciones (Avisos)</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg mb-1">
                    <div class="cardd">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-6" class="list-group-item ttl" data-toggle="collapse" style="background-color: #009666 !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Valores Críticos
                                </a>
                            </h5>
                            <div class="collapse paddd minn0" id="item-6">
                                <a href="/Check_List/Val_Criticos.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Ver Valores Críticos</a>
                                <a href="/Check_List/REV_VALOR_ALTER.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Valores Alterados Validados</a>
                                 <%-- <a href="/Check_List/Check_Point/ValoresCriticos_EMB.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i> Nuevo Valores Críticos</a>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>





</asp:Content>

