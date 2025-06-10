<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master_Solicitud.Master" CodeBehind="Documentos_Ver_Usuarios2.aspx.vb" Inherits="Presentacion.Documentos_Ver_Usuarios2" %>
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
            "ID_PRESTA_PRESTA":0, 
            "DCTO_PRESTA_PRESTA_DESC": 0, 
            "PRESTA_PRESTA_LUGAR": 0, 
            "PRESTA_PRESTA_PLAZO": 0, 
            "PRESTA_PRESTA_DOCU": 0,
            "PRESTA_PRESTA_SECCION": 0
        }
        ];
        function Ajax_DataTable() {
     
            $.ajax({
                "type": "POST",
                "url": "Documentos_Ver_Usuarios2.aspx/IRIS_WEBF_BUSCA_DOCUMENTOS_PRESTACION",
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
                        $("#Div_Tabla").empty();
                        $("#DataDataTable_PrevisionTable").empty();
                        Fill_DataTable();
   

                    } else {

           
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
            var xURL = "/Prestaciones/";
            console.log("Click Ver");
            window.open(location.origin + xURL + UURRLL, "_blank");

        };

    </script>

    <script>

        function Fill_DataTable() {
            $("<table>", {
                "id": "DataTable_Prevision",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla");
            $("#DataTable_Prevision").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Prevision").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Prevision thead").attr("class", "cabzera");
            $("#DataTable_Prevision thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción de Prestación"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar donde se efectúa la Prestación"),
                    $("<th>", { "class": "textoReducido" }).text("Plazos para entrega de resultados"),
                    $("<th>", { "align": "center" }, { "class": "textoReducido" }).text("Instructivo preparación paciente")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable_Prevision tbody").append(
                    $("<tr>", {
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DCTO_PRESTA_PRESTA_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PRESTA_PRESTA_LUGAR),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PRESTA_PRESTA_PLAZO),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                                $(this).append($("<button>", { type: "button", class: "btn btn-success btn-sm", "data-ruta": Mx_Dtt[i].PRESTA_PRESTA_DOCU, "data-btn": 1 }).text("Ver Documento"));                   
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








































        //function Fill_DataTable() {
        //    $("#Div_Tabla").empty().css({ "background": "#ffffff" });

        //    let xi = 0;
        //    let leTable = 0;
        //    let newTable = true;
        //    let reeTOTAL = 0;
        //    let TOTAL_FINAL_HIPER = 0;
        //    while (xi < Mx_Dtt.length) {
        //        if ((xi > 0) && (Mx_Dtt[xi].PRESTA_PRESTA_SECCION != Mx_Dtt[xi - 1].PRESTA_PRESTA_SECCION)) {
        //            //leTable.append(
        //            //    $("<tfoot>").append(
        //            //        $("<tr>").append(
        //            //            $("<th>", { align: "right", colspan: 2 }).text("Total:"),
        //            //            $("<td>", { align: "right" }).text(reeTOTAL)
        //            //        )
        //            //    )
        //            //);
        //            newTable = true;
        //            reeTOTAL = 0;
        //        } else if (xi > 0) {
        //            newTable = false;
        //        }

        //        if (newTable == true) {
        //            leTable = $("<table>", {
        //                "class": "display mb-2",
        //                "width": "100%",
        //                "cellspacing": "0"
        //            });
        //            leTable.appendTo("#Div_Tabla");

        //            leTable.append(
        //                $("<thead>").append(
        //                    $("<tr>").append(
        //                        $("<th>", { align: "left", colspan: 4 }).text(Mx_Dtt[xi].PRESTA_PRESTA_SECCION)
        //                    ),
        //                    $("<tr>").append(
        //                        $("<th>", { align: "left", style: "width: 128px;" }).text("Descripción de Prestación"),
        //                        $("<th>", { align: "left" }).text("Lugar donde se efectúa la Prestación"),
        //                        $("<th>", { align: "right", style: "width: 40px;" }).text("Plazo entrega resultados"),
        //                        $("<th>", { align: "right", style: "width: 40px;" }).text("Instructivo preparación paciente")
        //                    )
        //                ),
        //                $("<tbody>")
        //            );
        //        }
        //        //if (Mx_Dtt[xi].ID_CODIGO_FONASA != 145 && Mx_Dtt[xi].ID_CODIGO_FONASA != 668 && Mx_Dtt[xi].ID_CODIGO_FONASA != 76) {
        //            leTable.find("tbody").append(
        //                $("<tr>").append(
        //                    $("<td>", { align: "center" }).text(Mx_Dtt[xi].DCTO_PRESTA_PRESTA_DESC),
        //                    $("<td>", { align: "left" }).text(Mx_Dtt[xi].PRESTA_PRESTA_LUGAR),
        //                    $("<td>", { align: "right" }).text(Mx_Dtt[xi].PRESTA_PRESTA_PLAZO),
        //                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
        //                            $(this).append($("<button>", { type: "button", class: "btn btn-success btn-sm", "data-ruta": Mx_Dtt[xi].PRESTA_PRESTA_DOCU, "data-btn": 1 }).text("Ver Documento"));                            
        //                    })
        //                )
        //            );

        //        //}

        //        xi++;
        //    }

        //    $("table button[data-btn=1]").click((ev) => {
        //        ev.stopImmediatePropagation();

        //        let strRuta = $(ev.currentTarget).attr("data-ruta");
        //        Ajax_Ver_Documento(strRuta);
        //    });

        //    $("table").DataTable({
        //        "bSort": true,
        //        "binfo": false,
        //        "bSort": true,
        //        "iDisplayLength": 100,
        //        "language": {
        //            "lengthMenu": "Mostrar: _MENU_",
        //            "zeroRecords": "No hay concidencias",
        //            "info": "",
        //            "infoEmpty": "",
        //            "infoFiltered": "",
        //            "search": "<strong><i class='fa fa-search'></i> Filtro: </strong>",
        //            "paginate": {
        //                "previous": "Anterior",
        //                "next": "Siguiente"
        //            }
        //        }
        //    });
        //}
    </script>


        <style>
        #DataTable thead, #DataTable tfoot, #Table_T thead {
            background-color: #28a745;
            color: white;
        }
        
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
                    CARTERA PRESTACIONES EXÁMENES LABORATORIO CLÍNICO
                </h5>
            </div>
            </div>

            <%------------------------------------------------------------ TABLAS -------------------------------------------------------------%>
            <div class="row mb-3" id="Id_Conte">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i> </h5>
                    <%--<div class="col-md-8"></div>--%>
                    <div class="row">
                        <div class="col-md">
                            <div class="col-lg-3"></div>
                            <div id="Div_Tabla" class="col-lg-6 table table-hover table-striped table-iris" style="overflow:auto"></div>
                            <div class="col-lg-3"></div>
                        </div>
                    </div>    
                </div>  
                <div class="col-md-1"></div>
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>
</asp:Content>
