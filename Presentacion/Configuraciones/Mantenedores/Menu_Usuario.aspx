<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Menu_Usuario.aspx.vb" Inherits="Presentacion.Menu_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script type="text/javascript">
        var IDDDDDDD = 0;
    </script>
    <script>
        $(document).ready(function () {
     
            Ajax_Tabla();
            $(".block_wait").fadeOut(0);
            //BTN NUEVO
            $("#Btn_Nuevo").click(function () {
                $("#txtCod").val("");
                $("#txtDesc").val("");
                
            });
            //BTN MODIFICAR
            $("#Btn_Modificar").click(function () {
                if (($("#txtCod").val() == 0) && ($("#txtDesc").val() == 0)) {
                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, complete los campos solicitados.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_Update();
                }
            });
            //BTN ELIMINAR
            $("#Btn_Eliminar").click(function () {
                Ajax_Delete();
            });
            //BTN GUARDAR
            $("#Btn_Guardar").click(function () {
                if (($("#txtCod").val() == "") || ($("#txtDesc").val() == "")) {
                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, complete los campos solicitados.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_Guardar();
                }
            });
            //BTN EXCEL
            $("#Btn_Excel").click(function () {
                Ajax_Excel();
            });
        });
    </script>
    <script>
        function Ajax_Codiguin(COD, DESC, ID) {
            $("#txtCod").val(COD);
            $("#txtDesc").val(DESC);
            IDDDDDDD = parseInt(ID);
        };

        //-------------------------------------------------- TABLA --------------------------------------------------------|
        var Mx_Dtt = [
            {
                "ID": 0,
                "NOM_MENU": 0,
                "DESC_MENU": 0
            }
        ];
        function Ajax_Tabla() {
            modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Menu_Usuario.aspx/IRIS_WEBF_BUSCA_MENU",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        $("#Div_Tabla").empty();
                        Fill_DataTable();
                        Hide_Modal();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        //-------------------------------------------------- UPDATE ----------------------------------------------------|
        var numerin = 0
        function Ajax_Update() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID": IDDDDDDD,
                "NOM_MENU": $("#txtCod").val(),
                "DESC_MENU": $("#txtDesc").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Menu_Usuario.aspx/IRIS_WEBF_UPDATE_MENU",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();

                        $("#txtCod").val("");
                        $("#txtDesc").val("");
                        Ajax_Tabla();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No ha ocurrido actualización.");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }

        //--------------------------------------------------- GRABA ----------------------------------------------------|
        var numerin = 0
        function Ajax_Guardar() {
            modal_show();
            var Data_Par = JSON.stringify({
                "NOM_MENU": $("#txtCod").val(),
                "DESC_MENU": $("#txtDesc").val()
               
            });
           
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Menu_Usuario.aspx/IRIS_WEBF_GRABA_MENU",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();

                        $("#txtCod").val("");
                        $("#txtDesc").val("");
                        Ajax_Tabla();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        
   
    </script>
    <script>
        //------------------------------------------------------------------ TABLA -------------------------------------------|
        function Fill_DataTable() {
            $("<table>", {
                "id": "DataTable",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla");
            $("#DataTable").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable thead").attr("class", "cabzera");
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Código"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Codiguin("` + Mx_Dtt[i].NOM_MENU + `","` + Mx_Dtt[i].DESC_MENU + `","` + Mx_Dtt[i].ID + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].NOM_MENU),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DESC_MENU)
                    )
                );
                
            }
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
        <div class="col-lg-1"></div>
        <div class="col-lg">
            <div>
                <h5 style="text-align: center; padding: 5px;">
                    <i class="fa fa-info"></i>
                    Bancos
                </h5>
            </div>
            <div class="row mb-3">
                <div class="col-md-4">
                    <label for="txtCod">Código:</label>
                    <input id="txtCod" class="form-control textoReducido" type="text" />
                </div>
                <div class="col-md-4">
                    <label for="txtDesc">Descripción:</label>
                    <input id="txtDesc" class="form-control text-uppercase textoReducido" type="text" />
                </div>               
            </div>

            <%------------------------------------------------------------ TABLAS -------------------------------------------------------------%>
            <div class="row mb-3" id="Id_Conte">
                <div class="col-md-12" id="Paciente">
                    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i>Lista de Menús</h5>
                    <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-md">
                    <button id="Btn_Nuevo" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit">Nuevo <i class="fa fa-plus" aria-hidden="true"></i></button>
                </div>
                <div class="col-md">
                    <button id="Btn_Guardar" class="btn btn-primary btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit">Guardar <i class="fa fa-save" aria-hidden="true"></i></button>
                </div>
                <div class="col-md">
                    <button id="Btn_Modificar" class="btn btn-warning btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit">Modificar <i class="fa fa-edit" aria-hidden="true"></i></button>
                </div>               
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>
</asp:Content>
