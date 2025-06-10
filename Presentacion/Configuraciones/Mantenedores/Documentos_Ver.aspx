<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Documentos_Ver.aspx.vb" Inherits="Presentacion.Documentos_Ver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <script src="../../js/moment_es.js"></script>
    <script src="../../js/moment.js"></script>

       <script>

           $(document).ready(function () {

               Ajax_DataTable();
       
        });
    </script>
    <script>

        //------------------------------------------------- BUSCAR DOCUMENTOS ---------------------------------
        var Mx_Dtt = [
    {
        "ID_DCTO": 0,
        "DCTO_COD": 0,
        "DCTO_DESC": 0,
        "DCTO_TIPO": 0,
        "DCTO_ORDEN": 0,
        "DCTO_FECHA": 0,
        "DCTO_RUTA": 0,
        "ID_ESTADO": 0
    }
        ];
        function Ajax_DataTable() {
            modal_show();
            $.ajax({
                "type": "POST",
                "url": "Documentos_Ver.aspx/IRIS_WEBF_BUSCA_DOCUMENTOS_MANTENEDOR",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt = json_receiver;
                        //Mx_Dtt_Lugar_Pertenece_Respaldo = JSON.parse(json_receiver);

                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].DCTO_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].DCTO_FECHA = Date_Change;
                        }
                        $("#Div_Tabla_Prevision").empty();
                        $("#DataTable_Prevision").empty();
                        Fill_DataTable();
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

                } 
            });
        }

     

      

        //-------------------------------- AJAX PARA ABRIR EL DOCUMENTO
        function Ajax_Ver_Documento(UURRLL) {
            var xURL = "/uploads/";
            console.log("Click Ver");
            window.open(location.origin + xURL + UURRLL, "_blank");

        };

    </script>

    <script>
        //------------------------------------------------------------------ TABLA VER -------------------------------------------|
        function Fill_DataTable() {
            $("<table>", {
                "id": "DataTable_Prevision",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Prevision");
            $("#DataTable_Prevision").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Prevision").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Prevision thead").attr("class", "cabzera");
            $("#DataTable_Prevision thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Archivo"),
                    $("<th>", { "class": "textoReducido" }).text("Código"),
                    $("<th>", { "class": "textoReducido" }).text("Tipo"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Visualizar")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable_Prevision tbody").append(
                    $("<tr>", {
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DCTO_RUTA),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DCTO_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt[i].DCTO_TIPO == 1) {
                                return "PDF"
                            } else if (Mx_Dtt[i].DCTO_TIPO == 2) {
                                return "WORD"
                            } else if (Mx_Dtt[i].DCTO_TIPO == 3) {
                                return "EXCEL"
                            } else if (Mx_Dtt[i].DCTO_TIPO == 4) {
                                return "POWER POINT"
                            } else if (Mx_Dtt[i].DCTO_TIPO == 5) {
                                return "IMAGEN"
                            } else if (Mx_Dtt[i].DCTO_TIPO == 6) {
                                return "OTRO"
                            }
                        }
                        ),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DCTO_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(moment(Mx_Dtt[i].DCTO_FECHA).format("DD/MM/YYYY HH:mm")),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {                      
                            if (Mx_Dtt[i].ID_ESTADO == 1) {
                                $(this).append($("<button>", { type: "button", class: "btn btn-success btn-sm", "data-ruta": Mx_Dtt[i].DCTO_RUTA, "data-btn": 1 }).text("Ver Documento"));
                            } else {
                                $(this).append($("<button>", { disabled: "disabled", type: "button", class: "btn btn-dark btn-sm", "data-ruta": Mx_Dtt[i].DCTO_RUTA, "data-btn": 2 }).text("Eliminado"));
                            }                               
                        })
                    )
                );            
            }

            $("#DataTable_Prevision button[data-btn=1]").click((ev) => {
                ev.stopImmediatePropagation();

                let strRuta = $(ev.currentTarget).attr("data-ruta");
                Ajax_Ver_Documento(strRuta);
            });

            $("#DataTable_Prevision tbody tr").click(function () {
                $("#DataTable_Prevision tbody tr").removeClass("active");
                $(this).addClass("active");
            });

            $("#DataTable_Prevision").DataTable({
                "bSort": true,
                "binfo": false,
                "bSort": true,
                "iDisplayLength": 100,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay concidencias",
                    "info": "Mostrando Página _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se buscó en _MAX_ registros)",
                    "search": "<strong><i class='fa fa-search'></i> Filtro: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
        }
    </script>


        <style>
        .progress-bar.animate {
            width: 100%;
        }
        #DataTable tbody td {
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
            background: #46963f;
            color: white;
        }
        .textoReducido {
            font-size: 12px;
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

            <%------------------------------------------------------------ TABLAS -------------------------------------------------------------%>
            <div class="row mb-3" id="Id_Conte">
                <div class="col-md-12">
                    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i> Listado de Documentos</h5>
                    <%--<div class="col-md-8"></div>--%>
                    <div class="row">
                        <div class="col-md">
                            <div id="Div_Tabla_Prevision" style="width:100%;" class="highlights"></div>
                        </div>
                    </div>    
                </div>  
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>
</asp:Content>
