﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Ciudad.aspx.vb" Inherits="Presentacion.Ciudad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script type="text/javascript">
        var IDDDDDDD = 0;
    </script>
    <script>
        $(document).ready(function () {
            Ajax_Ddl_Mantenedor();
            Ajax_Tabla();
            $(".block_wait").fadeOut(0);
            //BTN NUEVO
            $("#Btn_Nuevo").click(function () {
                $("#txtCod").val("");
                $("#txtDesc").val("");
                $("#Ddl_Mantenedor").val(0);

                accion = 1
                alerta_Proc_Correctos();

                $("#Btn_Guardar").attr("disabled", false);
                $("#Btn_Modificar").attr("disabled", true);
                $("#Btn_Eliminar").attr("disabled", true);
            });
            //BTN MODIFICAR
            $("#Btn_Modificar").click(function () {
                if (($("#Ddl_Mantenedor").val() == 0)) {
                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione un estado.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_Update();
                    accion = 3
                    alerta_Proc_Correctos();
                    $("#Btn_Modificar").attr("disabled", true);
                    $("#Btn_Guardar").attr("disabled", false);
                }
            });
            //BTN ELIMINAR
            $("#Btn_Eliminar").click(function () {
                Swal.fire({
                    title: '¿Estás seguro?',
                    text: "¿Deseas eliminar este elemento?",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#d33',
                    cancelButtonColor: '#3085d6',
                    confirmButtonText: 'Eliminar',
                    cancelButtonText: 'Cancelar'
                }).then((result) => {
                    if (result.isConfirmed) {
                        Ajax_Delete();
                        accion = 4;
                        alerta_Proc_Correctos();
                        $("#Btn_Guardar").attr("disabled", false);
                        $("#Btn_Modificar").attr("disabled", true);
                        $("#Btn_Eliminar").attr("disabled", true);
                    }
                });
            });
            //BTN GUARDAR
            $("#Btn_Guardar").click(function () {
                if (($("#txtCod").val() == "") || ($("#txtDesc").val() == "") || ($("#Ddl_Mantenedor").val() == 0)) {
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
                Swal.fire({
                    title: 'Excel generado',
                    text: "El archivo Excel ha sido generado. ¿Deseas descargarlo?",
                    icon: 'success',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Descargar',
                    cancelButtonText: 'Cancelar'
                }).then((result) => {
                    if (result.isConfirmed) {
                        Ajax_Excel();
                        accion = 5;
                        alerta_Proc_Correctos();
                    }
                });
            });
            $("#Btn_Guardar").attr("disabled", false);
            $("#Btn_Modificar").attr("disabled", true);
            $("#Btn_Eliminar").attr("disabled", true);
        });
    </script>
    <script>
        function Ajax_Codiguin(COD, DESC, ESTADO, ID) {
            $("#Btn_Guardar").attr("disabled", true);
            $("#Btn_Modificar").attr("disabled", false);
            $("#Btn_Eliminar").attr("disabled", false);

            $("#txtCod").val(COD);
            $("#txtDesc").val(DESC);
            $("#Ddl_Mantenedor").val(ESTADO);
            IDDDDDDD = parseInt(ID);
        };



        //-------------------------------------------------- MODAL SWEETALERT ----------------------------------------------------|
        function alerta_Proc_Correctos() {
            var text = ""
            var icon = "success"
            switch (accion) {
                case 1:
                    text = 'Limpiado correctamente'
                    break;
                case 2:
                    text = 'Guardado correctamente'
                    break;
                case 3:
                    text = 'Modificado correctamente'
                    break;
                case 4:
                    text = 'Eliminado correctamente'
                    break;
                case 5:
                    text = 'El Excel se genero correctamente'
                    break;
                case 6:
                    text = 'El Código ya existe'
                    icon = "error"
                    break;
            }

            const Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 1500,
                timerProgressBar: true,
                didOpen: (toast) => {
                    toast.addEventListener('mouseenter', Swal.stopTimer)
                    toast.addEventListener('mouseleave', Swal.resumeTimer)
                }
            })
            Toast.fire({
                icon: icon,
                title: text
            })
        }


        //-------------------------------------------------- DDL ESTADO MANTENEDOR----------------------------------------------------|
        var Mx_Dtt_Mantenedor = [
            {
                "ID_ESTADO": 0,
                "EST_DESCRIPCION": 0,
                "EST_MANTENEDOR": 0
            }
        ];
        function Ajax_Ddl_Mantenedor() {
            modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Ciudad.aspx/IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Mantenedor = JSON.parse(json_receiver);
                        Fill_Ddl_Mantenedor();
                        Hide_Modal();

                    } else {

                        Hide_Modal();
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
        //-------------------------------------------------- TABLA --------------------------------------------------------|
        var Mx_Dtt = [
            {
                "ID_CIUDAD": 0,
                "CIU_COD": 0,
                "CIU_DESC": 0,
                "ID_ESTADO": 0
            }
        ];
        function Ajax_Tabla() {
            modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Ciudad.aspx/IRIS_WEBF_BUSCA_CIUDAD",
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
                "ID_CIU": IDDDDDDD,
                "CIU_COD": $("#txtCod").val(),
                "CIU_DES": $("#txtDesc").val(),
                "ID_ESTADO": $("#Ddl_Mantenedor").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Ciudad.aspx/IRIS_WEBF_UPDATE_CIUDAD",
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
                        $("#Ddl_Mantenedor").val(0)
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
        //-------------------------------------------------- DELETE ----------------------------------------------------|
        var numerin = 0
        function Ajax_Delete() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_CIU": IDDDDDDD,
                "CIU_COD": $("#txtCod").val(),
                "CIU_DES": $("#txtDesc").val(),
                "ID_ESTADO": 2
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Ciudad.aspx/IRIS_WEBF_UPDATE_CIUDAD",
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
                        $("#Ddl_Mantenedor").val(0)
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
        //--------------------------------------------------- GRABA ----------------------------------------------------|
        var numerin = 0
        function Ajax_Guardar() {
            modal_show();
            var Data_Par = JSON.stringify({
                "CIU_COD": $("#txtCod").val(),
                "CIU_DES": $("#txtDesc").val(),
                "ID_ESTADO": $("#Ddl_Mantenedor").val()
            });
            $(".block_wait").fadeIn(500);

            if (validarCodigo()) {
                console.log("Codigo Existente")
                accion = 6
                alerta_Proc_Correctos();
                Hide_Modal();
                $(".block_wait").fadeOut(500);
                return;
            }
            $.ajax({
                "type": "POST",
                "url": "Ciudad.aspx/IRIS_WEBF_GRABA_CIUDAD",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();

                        accion = 2
                        alerta_Proc_Correctos();
                        //$("#Btn_Guardar").attr("disabled", true);
                        $("#Btn_Modificar").attr("disabled", true);
                        $("#Btn_Eliminar").attr("disabled", true);

                        $("#txtCod").val("");
                        $("#txtDesc").val("");
                        $("#Ddl_Mantenedor").val(0)
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


        function validarCodigo() {
            var codigo = $("#txtCod").val();

            var codigoExiste = Mx_Dtt.some(function (item) {
                console.log(item.CIU_COD, "-", codigo)
                return item.CIU_COD === codigo;
            });

            return codigoExiste;
        }




        //------------------------------------------ EXCEL ------------------------------------
        var Mx_Dtt_Excel = [
            {
                "urls": ""
            }
        ];
        function Ajax_Excel() {
            modal_show()

            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Ciudad.aspx/Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        //window.open(json_receiver, 'Download');
                        location.href = json_receiver;


                    } else {

                    }
                    Hide_Modal();
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>
    <%-------------------------------------------------- FUNCION DE LLENADO DE ELEMENTOS -----------------------------------%>
    <script>
        //Llenar DropDownList Tipo de Atención
        function Fill_Ddl_Mantenedor() {
            $("#Ddl_Mantenedor").empty();
            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#Ddl_Mantenedor");
            for (y = 0; y < Mx_Dtt_Mantenedor.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_Mantenedor[y].ID_ESTADO
                }).text(Mx_Dtt_Mantenedor[y].EST_DESCRIPCION).appendTo("#Ddl_Mantenedor");
            }
        };
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
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Activo")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Codiguin("` + Mx_Dtt[i].CIU_COD + `","` + Mx_Dtt[i].CIU_DESC + `","` + Mx_Dtt[i].ID_ESTADO + `","` + Mx_Dtt[i].ID_CIUDAD + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CIU_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CIU_DESC),
                        $("<td>").css("text-align", "center").html("<input type='checkbox' id='chekito" + i + "' />")
                    )
                );
                if (Mx_Dtt[i].ID_ESTADO == 1) {
                    $("#chekito" + i).prop("checked", true);
                }
            }
            $("#DataTable tbody tr").click(function () {     /* <----- Pinta de color azul la tabla*/
                $("#DataTable tbody tr").removeClass("active");
                $(this).addClass("active");
            });
            $('#DataTable').dataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
                "retrieve": true,
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong></i>Filtro: </strong>"
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
        <div class="col-lg">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar">
                <h5 style="text-align: center; padding: 5px;">
                    <i class="fa fa-info"></i>
                    Ciudad
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
                <div class="col-md-4">
                    <label for="Ddl_Mantenedor">Estado:</label>
                    <select id="Ddl_Mantenedor" class="form-control textoReducido mayus">
                    </select>
                </div>
            </div>

            <%------------------------------------------------------------ TABLAS -------------------------------------------------------------%>
            <div class="row mb-3" id="Id_Conte">
                <div class="col-md-12" id="Paciente">
               
                <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i>Lista de Ciudades</h5>
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
                <div class="col-md">
                    <button id="Btn_Eliminar" class="btn btn-danger btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit">Eliminar <i class="fa fa-eraser" aria-hidden="true"></i></button>
                </div>
                <div class="col-md">
                    <button id="Btn_Excel" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit">Excel <i class="fa fa-eject" aria-hidden="true"></i></button>
                </div>
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>
    </div>
</asp:Content>
