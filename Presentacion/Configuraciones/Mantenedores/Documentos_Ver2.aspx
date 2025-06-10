<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Documentos_Ver2.aspx.vb" Inherits="Presentacion.Documentos_Ver2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="../../js/Deep-Copy.js"></script>
    <script src="../../js/moment_es.js"></script>
    <script src="../../js/moment.js"></script>

    <script>
        $(function () {
            $('.list-group-item').on('click', function () {
                $('.fa-chng', this)
                  .toggleClass('fa-chevron-right')
                  .toggleClass('fa-chevron-down');
            });
        });


        $(document).ready(function () {

            Ajax_DataTable();

        });
    </script>
    <script>

        var Mx_Dtt = [
    {
        "ID_DCTO": 0,
        "DCTO_COD": 0,
        "DCTO_DESC": 0,
        "DCTO_TIPO": 0,
        "DCTO_ORDEN": 0,
        "DCTO_FECHA": 0,
        "DCTO_RUTA": 0,
        "ID_ESTADO": 0,
        "DCTO_CATEGORIA": 0,
        "DCTO_SUBCATEGORIA": 0
    }
        ];

        function Ajax_DataTable() {
            modal_show();
            $.ajax({
                "type": "POST",
                "url": "Documentos_Ver2.aspx/IRIS_WEBF_BUSCA_DOCUMENTOS2",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt = json_receiver;

                        for (x = 0; x < Mx_Dtt.length; x++) {

                            if ((Mx_Dtt[x].DCTO_COD == "TOMA DE MUESTRAS") && (Mx_Dtt[x].DCTO_DESC == "Evaluacion condiciones transporte de muestras")) {
                                $("#item-1-1").prepend("<a onclick='Ajax_Ver_Documento(" + x + ")' class='list-group-item manito'><i class='fa fa-fw fa-minus'></i>" + Mx_Dtt[x].DCTO_RUTA + "</a>");
                            }
                            if ((Mx_Dtt[x].DCTO_COD == "TOMA DE MUESTRAS") && (Mx_Dtt[x].DCTO_DESC == "Reporte mensual rechazo de muestras")) {
                                $("#item-1-2").prepend("<a onclick='Ajax_Ver_Documento(" + x + ")' class='list-group-item manito'><i class='fa fa-fw fa-minus'></i>" + Mx_Dtt[x].DCTO_RUTA + "</a>");
                            }
                            if ((Mx_Dtt[x].DCTO_COD == "TOMA DE MUESTRAS") && (Mx_Dtt[x].DCTO_DESC == "Documentos Toma muestras")) {
                                $("#item-1-3").prepend("<a onclick='Ajax_Ver_Documento(" + x + ")' class='list-group-item manito'><i class='fa fa-fw fa-minus'></i>" + Mx_Dtt[x].DCTO_RUTA + "</a>");
                            }
                            if ((Mx_Dtt[x].DCTO_COD == "INSTRUCTIVOS PASO A PASO") && (Mx_Dtt[x].DCTO_DESC == "Irislab")) {
                                $("#item-2-1").prepend("<a onclick='Ajax_Ver_Documento(" + x + ")' class='list-group-item manito'><i class='fa fa-fw fa-minus'></i>" + Mx_Dtt[x].DCTO_RUTA + "</a>");
                            }
                            if ((Mx_Dtt[x].DCTO_COD == "BIOSEGURIDAD") && ((Mx_Dtt[x].DCTO_DESC == "Documentos Bioseguridad") || (Mx_Dtt[x].DCTO_DESC == ""))) {
                                $("#item-3-1").prepend("<a onclick='Ajax_Ver_Documento(" + x + ")' class='list-group-item manito'><i class='fa fa-fw fa-minus'></i>" + Mx_Dtt[x].DCTO_RUTA + "</a>");
                            }
                            if ((Mx_Dtt[x].DCTO_COD == "DOCUMENTOS NORMATIVOS") && (Mx_Dtt[x].DCTO_DESC == "Documentos legales")) {
                                $("#item-4-1").prepend("<a onclick='Ajax_Ver_Documento(" + x + ")' class='list-group-item manito'><i class='fa fa-fw fa-minus'></i>" + Mx_Dtt[x].DCTO_RUTA + "</a>");
                            }
                            if ((Mx_Dtt[x].DCTO_COD == "DOCUMENTOS NORMATIVOS") && (Mx_Dtt[x].DCTO_DESC == "Normativas, circulares")) {
                                $("#item-4-2").prepend("<a onclick='Ajax_Ver_Documento(" + x + ")' class='list-group-item manito'><i class='fa fa-fw fa-minus'></i>" + Mx_Dtt[x].DCTO_RUTA + "</a>");
                            }
                            if ((Mx_Dtt[x].DCTO_COD == "INFORMACION GENERAL") && ((Mx_Dtt[x].DCTO_DESC == "Informaciones varias") || (Mx_Dtt[x].DCTO_DESC == ""))) {
                                $("#item-5-1").prepend("<a onclick='Ajax_Ver_Documento(" + x + ")' class='list-group-item manito'><i class='fa fa-fw fa-minus'></i>" + Mx_Dtt[x].DCTO_RUTA + "</a>");
                            }
                            if ((Mx_Dtt[x].DCTO_COD == "REAS") && ((Mx_Dtt[x].DCTO_DESC == "Certificados  Disposicion Final de Residuos") || (Mx_Dtt[x].DCTO_DESC == ""))) {
                                $("#item-6-1").prepend("<a onclick='Ajax_Ver_Documento(" + x + ")' class='list-group-item manito'><i class='fa fa-fw fa-minus'></i>" + Mx_Dtt[x].DCTO_RUTA + "</a>");
                            }
                            if ((Mx_Dtt[x].DCTO_COD == "REAS") && ((Mx_Dtt[x].DCTO_DESC == "Analisis estadistico de Residuos generados") || (Mx_Dtt[x].DCTO_DESC == ""))) {
                                $("#item-6-2").prepend("<a onclick='Ajax_Ver_Documento(" + x + ")' class='list-group-item manito'><i class='fa fa-fw fa-minus'></i>" + Mx_Dtt[x].DCTO_RUTA + "</a>");
                            }
                            if ((Mx_Dtt[x].DCTO_COD == "REAS") && ((Mx_Dtt[x].DCTO_DESC == "Normativa legal de REAS") || (Mx_Dtt[x].DCTO_DESC == ""))) {
                                $("#item-6-3").prepend("<a onclick='Ajax_Ver_Documento(" + x + ")' class='list-group-item manito'><i class='fa fa-fw fa-minus'></i>" + Mx_Dtt[x].DCTO_RUTA + "</a>");
                            }
                            if ((Mx_Dtt[x].DCTO_COD == "REAS") && ((Mx_Dtt[x].DCTO_DESC == "Protocolos internos manejo REAS") || (Mx_Dtt[x].DCTO_DESC == ""))) {
                                $("#item-6-4").prepend("<a onclick='Ajax_Ver_Documento(" + x + ")' class='list-group-item manito'><i class='fa fa-fw fa-minus'></i>" + Mx_Dtt[x].DCTO_RUTA + "</a>");
                            }
                            if ((Mx_Dtt[x].DCTO_COD == "PAP") && ((Mx_Dtt[x].DCTO_DESC == "Informacion general") || (Mx_Dtt[x].DCTO_DESC == ""))) {
                                $("#item-7-1").prepend("<a onclick='Ajax_Ver_Documento(" + x + ")' class='list-group-item manito'><i class='fa fa-fw fa-minus'></i>" + Mx_Dtt[x].DCTO_RUTA + "</a>");
                            }
                            if ((Mx_Dtt[x].DCTO_COD == "PAP") && ((Mx_Dtt[x].DCTO_DESC == "Registro de trazabilidad de PAP") || (Mx_Dtt[x].DCTO_DESC == ""))) {
                                $("#item-7-1").prepend("<a onclick='Ajax_Ver_Documento(" + x + ")' class='list-group-item manito'><i class='fa fa-fw fa-minus'></i>" + Mx_Dtt[x].DCTO_RUTA + "</a>");
                            }
                        }
                        Hide_Modal();

                    } else {
                            
                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();
                }
            });
        }

        function Ajax_Ver_Documento(UURRLL) {
            UURRLL = Mx_Dtt[UURRLL].DCTO_RUTA;
            var xURL = "/uploads/";
            window.open(location.origin + xURL + UURRLL, "_blank");

        };

    </script>

    <style>
        .progress-bar.animate {
            width: 100%;
        }

        #DataTable_1_1 tbody td {
            text-transform: uppercase;
        }

        #DataTable_Ate tbody td {
            text-transform: uppercase;
        }

        #DataTable_Lis_Exa_Ate tbody td {
            text-transform: uppercase;
        }

        .mrgn {
            margin-left: 20px;
            margin-right: 20px;
        }

        #btnFichaAcceso {
            margin-bottom: 1vh;
        }

        #i {
            display: flex;
            flex-flow: row nowrap;
        }

        .manito {
            cursor: pointer;
        }

        .cabzera {
            background: #28a745 !important;
            color: white;
        }

        .textoReducido {
            font-size: 12px;
        }

        .cabzera22222 {
            background: #28a745 !important;
            color: white;
        }

        .highlights {
            width: 710px;
            height: 380px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .highlights2 {
            width: 710px;
            height: 404px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
        }

        /*@media screen and (min-width:992px) {
            .xmb-3 {
                margin-bottom: 1rem !important;
            }
        }*/

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

        @media screen and (max-width: 600px) {
            .flexon {
                display: flex;
                flex-flow: column;
                width: 90vw;
            }

            .flx {
                flex: 1;
                max-width: 100%;
            }

            .highlights {
                height: 100%;
            }

            .buttons {
                display: flex;
                flex-flow: column;
            }

            #Btn_Buscar_x_ate {
                width: 90vw;
                margin-left: -12px;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <!-- Modal -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <%------------------------------------------------------TÍTULO, TEXTBOX Y BOTONES-----------------------------------------%>
    <div class="row">
        <div class="col-lg-12">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar">
                    <h5 style="text-align: center; padding: 5px;">
                        <i class="fa fa-info"></i>
                        Visualización de Documentos
                    </h5>
                </div>
            </div>

            <%------------------------------------------------------------ TABLAS Y DOCUMENTOS -------------------------------------------------------------%>
            <div class="row mb-3" id="Id_Conte">
                <div class="col-md-12">
                    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i>Listado de Documentos</h5>
                    <%--<div class="col-md-8"></div>--%>
                    <div class="row xmb-3">
                        <div class="col-lg-6">
                            <div class="col-lg mb-1">
                                <div class="card border-bar">
                                    <div class="list-group list-group-root well">
                                        <h6 class="mb-0">
                                            <a href="#item-1" class="list-group-item ttl" data-toggle="collapse" style="background-color: #00738e !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>TOMA DE MUESTRAS
                                            </a></h6>
                                        <div class="collapse paddd subb" id="item-1">

                                            <a href="#item-1-1" class="list-group-item" data-toggle="collapse" style="background-color: #1d96b2 !important;">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>Evaluación condiciones transporte de muestras
                                            </a>
                                            <div class="collapse  paxxx minn" id="item-1-1">
                                            </div>

                                            <a href="#item-1-2" class="list-group-item" data-toggle="collapse" style="background-color: #1d96b2 !important;">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>Reporte mensual rechazo de muestras
                                            </a>
                                            <div class="collapse  paxxx minn" id="item-1-2">
                                            </div>
                                            <a href="#item-1-3" class="list-group-item" data-toggle="collapse" style="background-color: #1d96b2 !important;">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>Documentos Toma muestras
                                            </a>
                                            <div class="collapse  paxxx minn" id="item-1-3">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="list-group list-group-root well">
                                        <h6 class="mb-0">
                                            <a href="#item-2" class="list-group-item ttl" data-toggle="collapse" style="background-color: #00738e  !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>INSTRUCTIVOS PASO A PASO
                                            </a></h6>
                                        <div class="collapse paddd subb" id="item-2">

                                            <a href="#item-2-1" class="list-group-item" data-toggle="collapse" style="background-color: #1d96b2 !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>IrisLab
                                            </a>
                                            <div class="collapse  paxxx minn" id="item-2-1">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="list-group list-group-root well">
                                        <h6 class="mb-0">
                                            <a href="#item-3" class="list-group-item ttl" data-toggle="collapse" style="background-color: #00738e !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>BIOSEGURIDAD
                                            </a></h6>
                                        <div class="collapse paddd subb" id="item-3">

                                            <a href="#item-3-1" class="list-group-item" data-toggle="collapse" style="background-color: #1d96b2 !important;">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>Documentos Bioseguridad
                                            </a>
                                            <div class="collapse  paxxx minn" id="item-3-1">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="list-group list-group-root well">
                                        <h6 class="mb-0">
                                            <a href="#item-4" class="list-group-item ttl" data-toggle="collapse" style="background-color: #00738e  !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>DOCUMENTOS NORMATIVOS
                                            </a></h6>
                                        <div class="collapse paddd subb" id="item-4">

                                            <a href="#item-4-1" class="list-group-item" data-toggle="collapse" style="background-color: #1d96b2 !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>Documentos legales
                                            </a>
                                            <div class="collapse  paxxx minn" id="item-4-1">
                                            </div>
                                            <a href="#item-4-2" class="list-group-item" data-toggle="collapse" style="background-color: #1d96b2 !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>Normativas, circulares
                                            </a>
                                            <div class="collapse  paxxx minn" id="item-4-2">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="col-lg mb-1">
                                <div class="card border-bar">
                                    <div class="list-group list-group-root well">
                                        <h6 class="mb-0">
                                            <a href="#item-5" class="list-group-item ttl" data-toggle="collapse" style="background-color: #00738e !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>INFORMACIÓN GENERAL
                                            </a></h6>
                                        <div class="collapse paddd subb" id="item-5">

                                            <a href="#item-5-1" class="list-group-item" data-toggle="collapse" style="background-color: #1d96b2 !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>Informaciones varias
                                            </a>
                                            <div class="collapse  paxxx minn" id="item-5-1">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="list-group list-group-root well">
                                        <h6 class="mb-0">
                                            <a href="#item-6" class="list-group-item ttl" data-toggle="collapse" style="background-color: #00738e !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>REAS
                                            </a></h6>
                                        <div class="collapse paddd subb" id="item-6">

                                            <a href="#item-6-1" class="list-group-item" data-toggle="collapse" style="background-color: #1d96b2 !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>Certificados  Disposicion Final de Residuos
                                            </a>
                                            <div class="collapse  paxxx minn" id="item-6-1">
                                            </div>
                                            <a href="#item-6-2" class="list-group-item" data-toggle="collapse" style="background-color: #1d96b2 !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>Analisis estadistico de Residuos generados
                                            </a>
                                            <div class="collapse  paxxx minn" id="item-6-2">
                                            </div>
                                            <a href="#item-6-3" class="list-group-item" data-toggle="collapse" style="background-color: #1d96b2 !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>Normativa legal de REAS
                                            </a>
                                            <div class="collapse  paxxx minn" id="item-6-3">
                                            </div>
                                            <a href="#item-6-4" class="list-group-item" data-toggle="collapse" style="background-color: #1d96b2 !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>Protocolos internos manejo REAS
                                            </a>
                                            <div class="collapse  paxxx minn" id="item-6-4">
                                            </div>
                                        </div>
                                    </div>
     <%--                               <div class="list-group list-group-root well">
                                        <h6 class="mb-0">
                                            <a href="#item-7" class="list-group-item ttl" data-toggle="collapse" style="background-color: #00738e !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>PAP
                                            </a></h6>
                                        <div class="collapse paddd subb" id="item-7">

                                            <a href="#item-7-1" class="list-group-item" data-toggle="collapse" style="background-color: #1d96b2 !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>Informacion general
                                            </a>
                                            <div class="collapse  paxxx minn" id="item-7-1">
                                            </div>
                                            <a href="#item-7-2" class="list-group-item" data-toggle="collapse" style="background-color: #1d96b2 !important">
                                                <i class="fa fa-fw fa-chng fa-chevron-right"></i>Registro de trazabilidad de PAP
                                            </a>
                                            <div class="collapse  paxxx minn" id="item-7-2">
                                            </div>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md">
                            <%--<div id="Div_Tabla_Prevision" style="width:100%;" class="highlights"></div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>
</asp:Content>
