<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Gest_Financ.aspx.vb" Inherits="Presentacion.Gest_Financ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Highcharts --%>
    <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>
    <script>
        $(function () {
            $('.list-group-item').on('click', function () {
                $('.fa-chng', this)
                  .toggleClass('fa-chevron-right')
                  .toggleClass('fa-chevron-down');
            });
            AJAX_JSON_Graph();
        });

        var Mx_Data = [{
            "FECHA": "",
            "NUMERO": ""
        }];
        function AJAX_JSON_Graph() {
            modal_show();

            var mom_fecha = moment().format("DD-MM-YYYY");
            var Data_Par = JSON.stringify({
                "str_Date": mom_fecha
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Gest_Financ.aspx/Data_Graph",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Data = json_receiver;
                        grafico();
                        Hide_Modal();


                    } else {

                        Hide_Modal();
                    }

                },
                "error": function (response) {
                    Hide_Modal();
                }
            });

        }


        function grafico() {
            var grafico = 0;
            if (grafico == 0) {
                var arrPar = [];
                var arrVal = [];
                for (i = 0; i < Mx_Data.length; i++) {
                    arrVal.push(parseFloat(Mx_Data[i].NUMERO));
                    arrPar.push(function () {
                        //Obtener valores
                        var nDate = String(Mx_Data[i].FECHA);
                        nDate = nDate.toUpperCase().replace("/DATE(", "");
                        nDate = nDate.replace(")/", "");
                        var obj_date = new Date(parseInt(nDate));
                        var hh = parseInt(obj_date.getHours());
                        var mm = parseInt(obj_date.getMinutes());
                        if (hh < 10) { hh = "0" + hh; }
                        if (mm < 10) { mm = "0" + mm; }
                        return String(hh + ":" + mm);
                    }());
                }


                var fecha_now = moment().format("dddd, DD-MM-YYYY");

                Highcharts.chart('Summary_Graph', {
                    chart: {
                        type: 'line'
                    },
                    credits:{
                        enabled:false
                    },
                    title: {
                        text: 'Atenciones Diarias por Hora'
                    },
                    subtitle: {
                        text: 'Datos del día ' + fecha_now
                    },
                    xAxis: {
                        categories: arrPar
                    },
                    yAxis: {
                        title: {
                            text: 'Atenciones'
                        }
                    },
                    plotOptions: {
                        line: {
                            dataLabels: {
                                enabled: true
                            },
                            enableMouseTracking: true
                        }
                    },
                    series: [{
                        name: 'Total Atenciones',
                        data: arrVal
                    }]
                });
            }
        }
    </script>
       <style>
        /**/
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

        /*//////////////////*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <h4 class="text-center mb-3"><i class="fa fa-briefcase fa-fw"></i>Gestión Financiera</h4>

    <div class="row xmb-3">
        <div class="col-lg mb-1">
            <div class="card border-bar">
                <div class="list-group list-group-root well">
                    <h6 class="mb-0">
                        <a href="#item-1" class="list-group-item ttl" data-toggle="collapse" style="background-color: #cf3d4c  !important">
                            <i class="fa fa-fw fa-chng fa-chevron-right"></i>Estadisticas
                        </a></h6>
                    <div class="collapse paddd subb" id="item-1">

                        <a href="#item-1-1" class="list-group-item" data-toggle="collapse">
                            <i class="fa fa-fw fa-chng fa-chevron-right"></i>Detalle
                        </a>
                        <div class="collapse  paxxx minn" id="item-1-1">
                            <a href="/Gest_Financ/Estadisticas/Detalle/Prevision_Det.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Previsión</a>
                            <a href="/Gest_Financ/Estadisticas/Detalle/Medico_Det.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Médico</a>
                            <a href="/Gest_Financ/Estadisticas/Detalle/LugarTM_Det.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Atención por Lugar TM</a>
                        </div>

                        <a href="#item-1-2" class="list-group-item" data-toggle="collapse">
                            <i class="fa fa-fw fa-chng fa-chevron-right"></i>Resumen
                        </a>
                        <div class="collapse  paxxx minn" id="item-1-2">
                            <a href="/Gest_Financ/Estadisticas/Resumen/Prevision_Sum.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Previsión</a>
                            <a href="/Gest_Financ/Estadisticas/Resumen/Medico_Sum.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Médicos</a>
                            <a href="/Gest_Financ/Estadisticas/Resumen/Procedencia_Sum.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Procedencia</a>
                            <a href="/Gest_Financ/Estadisticas/Resumen/Atenciones_Sum.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Programa de Atenciones</a>
                            <a href="/Gest_Financ/Estadisticas/Resumen/Examenes_Sum.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Exámenes</a>
                            <a href="/Gest_Financ/Estadisticas/Resumen/Usuarios_Sum.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Usuarios</a>
                            <a href="/Gest_Financ/Estadisticas/Resumen/OrdenAtencion_Sum.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Orden Atención</a>
                            <%--<a href="/Gest_Financ/Estadisticas/Resumen/Pacientes_Sum.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Pacientes</a>--%>
                            <a href="/Gest_Financ/Estadisticas/Resumen/LugarTM_Prev_Sum.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Lugar TM y Previsión</a>
                            <a href="/Gest_Financ/Estadisticas/Resumen/AteResumen_Sum.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Resultados Filtrados</a>
                            <%--<a href="/Gest_Financ/Estadisticas/Resumen/Res_Peñalolen_Sum_Alt.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Resultados Peñalolen</a>
                            <a href="/Gest_Financ/Estadisticas/Resumen/Res_Peñalolen_Sum.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Resultados Peñalolen (por e-mail)</a>--%>
                        </div>

                        <a href="#item-1-3" class="list-group-item" data-toggle="collapse">
                            <i class="fa fa-fw fa-chng fa-chevron-right"></i>Multiple
                        </a>
                        <div class="collapse  paxxx minn" id="item-1-3">
                            <a href="/Gest_Financ/Estadisticas/Multiple/Prev_TM_Exa_Mult.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Prevision-LugarTM-Médicos-Exámenes</a>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="col-lg mb-1">
            <div class="card border-bar">
                <div class="list-group list-group-root well">
                    <h6 class="mb-0">
                        <a href="#item-2" class="list-group-item ttl" data-toggle="collapse" style="background-color: #923b6c  !important">
                            <i class="fa fa-fw fa-chng fa-chevron-right"></i>Estados y Gráficos
                        </a></h6>
                    <div class="collapse paddd subb" id="item-2">
                        <a href="#item-2-1" class="list-group-item" data-toggle="collapse">
                            <i class="fa fa-fw fa-chng fa-chevron-right"></i>Detalle
                        </a>
                        <div class="collapse  paxxx minn" id="item-2-1">
                            <a href="/Gest_Financ/Lista_Graficos/GraficoAtenciones.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Gráficos de Atenciones</a>
                            <a href="/Gest_Financ/Lista_Graficos/GraficoExamenes.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Gráficos de Exámenes</a>
                            <a href="/Gest_Financ/Lista_Graficos//Lis_Ate_Totales.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Listado de Atenciones (Totales)</a>
                            <a href="/Gest_Financ/Lista_Graficos/GraficoT_Sistema.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Total Sistema Mensual</a>
                            <a href="/Gest_Financ/Lista_Graficos/GraficoPAC_Mensual.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Total Paciente Mensual</a>
                            <a href="/Gest_Financ/Lista_Graficos/GraficoCOPAGO.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Total Copago Mensual</a>
                            <a href="/Gest_Financ/Lista_Graficos/GraficoPrevision.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Total Previsiones</a>
                            <a href="/Gest_Financ/Lista_Graficos/GraficoOrdAte.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Cantidad Anual de Orden de Atención</a>
                        </div>

                        <a href="#item-2-2" class="list-group-item" data-toggle="collapse">
                            <i class="fa fa-fw fa-chng fa-chevron-right"></i>Por Hora
                        </a>
                        <div class="collapse  paxxx minn" id="item-2-2">
                            <a href="/Gest_Financ/Lista_Graficos/GraficoHORA_ATE.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Atención por Hora</a>
                            <a href="/Gest_Financ/Lista_Graficos/GraficoHORA_EXA.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Examenes por Hora</a>
                        </div>

                        <a href="#item-2-3" class="list-group-item" data-toggle="collapse">
                            <i class="fa fa-fw fa-chng fa-chevron-right"></i>Análisis
                        </a>
                        <div class="collapse  paxxx minn" id="item-2-3">
                            <a href="/Gest_Financ/Lista_Graficos/Ana_LTM.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Análisis de Lugar TM</a>
                            <a href="/Gest_Financ/Lista_Graficos/GraficoAteTP.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Análisis de Atenciones por Tipo de Pago</a>
                            <a href="/Gest_Financ/Lista_Graficos/GraficoSecre.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Análisis por Secretaria</a>
                            <a href="/Gest_Financ/Lista_Graficos/Ana_MED.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Análisis por Médico</a>
                            <a href="/Gest_Financ/Lista_Graficos/Ana_PAC.aspx" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Análisis por Paciente</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg mb-1">
            <div class="card border-bar">
                <div class="list-group list-group-root well">
                    <h6 class="mb-0">
                        <a href="#item-3" class="list-group-item ttl" data-toggle="collapse" style="background-color: #5e3d8f  !important">
                            <i class="fa fa-fw fa-chng fa-chevron-right"></i>Convenio
                        </a></h6>
                    <div class="collapse paddd minn0" id="item-3">
                        <a href="/Gest_Financ/Convenio.aspx" class="list-group-item">
                            <i class="fa fa-fw fa-minus"></i>Test Fuera de Convenio</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row xmb-3">
        <div class="col-lg mb-1">
            <div class="card border-bar">
                <div class="list-group list-group-root well">
                    <h6 class="mb-0">
                        <a href="#item-4" class="list-group-item ttl" data-toggle="collapse" style="background-color: #923b6c  !important">
                            <i class="fa fa-fw fa-chng fa-chevron-right"></i>Análisis Atenciones
                        </a></h6>
                    <div class="collapse paddd minn0" id="item-4">
                        <a href="/Gest_Financ/Analisis_Atenciones/AnaAteTPago.aspx" class="list-group-item">
                            <i class="fa fa-fw fa-minus"></i>Análisis por Forma de Pago</a>
                        <a href="/Gest_Financ/Analisis_Atenciones/AnaOrdAte.aspx" class="list-group-item">
                            <i class="fa fa-fw fa-minus"></i>Análisis por Orden de Atención</a>
                        <a href="/Gest_Financ/Analisis_Atenciones/AnaPrev.aspx" class="list-group-item">
                            <i class="fa fa-fw fa-minus"></i>Análisis por Previsión</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg mb-1">
            <div class="card border-bar">
                <div class="list-group list-group-root well">
                    <h6 class="mb-0">
                        <a href="#item-5" class="list-group-item ttl" data-toggle="collapse" style="background-color: #5e3d8f  !important">
                            <i class="fa fa-fw fa-chng fa-chevron-right"></i>Administración
                        </a></h6>
                    <div class="collapse paddd minn0" id="item-5">
                        <a href="/Gest_Financ/Administracion/List_Ate_Prev_and_Prog_Ag_M.aspx" class="list-group-item">
                            <i class="fa fa-fw fa-minus"></i>Atenciones por Previsiones y Programa</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg mb-1">
            <div class="card border-bar">
                <div class="list-group list-group-root well">
                    <h6 class="mb-0">
                        <a href="#item-6" class="list-group-item ttl" data-toggle="collapse" style="background-color: #cf3d4c  !important">
                            <i class="fa fa-fw fa-chng fa-chevron-right"></i>Acreditación
                        </a></h6>
                    <div class="collapse paddd minn0" id="item-6">
                        <a href="Gest_Financ/Acreditacion/Indica_Muestra_Ingresa.aspx" class="list-group-item">
                            <i class="fa fa-fw fa-minus"></i>Indicador Muestra Ingresada </a>
                        <a href="Gest_Financ/Acreditacion/Indica_Tiempo_Respuesta.aspx" class="list-group-item">
                            <i class="fa fa-fw fa-minus"></i>Tiempo de Respuesta</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="card border-bar">
        <div class="card-header bg-bar text-center">
            <h5 class="m-0">Gráfico de Atención</h5>
        </div>
        <div class="card-body">
            <div id="Summary_Graph">
            </div>
        </div>
    </div>

</asp:Content>