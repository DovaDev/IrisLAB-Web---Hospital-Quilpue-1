<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="M_Prevision.aspx.vb" Inherits="Presentacion.M_Prevision" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
       <script>
           //selected = new Array();
           var Mx_Dtt_Lugar_Pertenece_Respaldo = new Array
           var chupalo = new Array
           var selected = new Array();
           var IDDDDDDD = 0;
        $(document).ready(function () {
            Ajax_Ddl_Mantenedor();
            Ajax_Lugar_TM();
            Ajax_Tabla();
            $(".block_wait").fadeOut(0);
            //BTN NUEVO
            $("#Btn_Nuevo").click(function () {
                $("#txtCod").val("");
                $("#txtDesc").val("");
                $("#Ddl_Mantenedor").val(0);
                Mx_Dtt_Lugar_Pertenece_a.length = 0;
                selected.length = 0;
                
            });

            $("#btn_modal").click(function () {
                $('#eModal2').modal('hide');
                $('#eModal2').modal('show');
                $("#DataTable_Lugar_Tm").empty();
                Fill_DataTable_Lugar_TM();
            });

            //BTN MODIFICAR
            $("#Btn_Modificar").click(function () {
                //selected = new Array();
                //$(".pp input:checkbox:checked").each(function () {
                //    selected.push($(this).val());
                //});
                if (IDDDDDDD == 0) {
                    $("#mError_AAH h4").text("Previsión");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Debe Seleccionar una previsión.");
                    $("#mError_AAH").modal();
                } else {
                    if (($("#Ddl_Mantenedor").val() == 0)) {
                        $("#mError_AAH h4").text("Seleccione");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("Por favor, seleccione un estado.");
                        $("#mError_AAH").modal();

                    } else if (($("#Ddl_Mantenedor").val() == 1) && (selected == "")) {
                        $("#mError_AAH h4").text("Seleccione");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("Por favor, verifique lugar TM.");
                        $("#mError_AAH").modal();
                    }
                    else {
                        Ajax_Update();
                    }
                }
            });
            //BTN ELIMINAR
            $("#Btn_Eliminar").click(function () {
                if (IDDDDDDD == 0) {
                    $("#mError_AAH h4").text("Previsión");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Debe Seleccionar una previsión.");
                    $("#mError_AAH").modal();
                } else {
                    //selected = new Array();
                    //$(".pp input:checkbox:checked").each(function () {
                    //    selected.push($(this).val());
                    //});
                    Ajax_Delete();
                }              
            });
            //BTN GUARDAR
            $("#Btn_Guardar").click(function () {
                //selected = new Array();
                //$(".pp input:checkbox:checked").each(function () {
                //    selected.push($(this).val());
                //});
                if (($("#txtCod").val() == "") || ($("#txtDesc").val() == "") || ($("#Ddl_Mantenedor").val() == 0) || (selected == "")) {
                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, complete los campos solicitados.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_Guardar();
                    
                }
            });

            //AJAX GUARDAR EN EL MODAL MARCAR
            $("#btn_cargar_TM").click(function () {
                selected = new Array();
                chupalo.length = 0;
                $(".pp input:checkbox:checked").each(function () {
                    selected.push($(this).val());
                });
                chupalo = selected.slice();
                selected.length = 0;

                for (i = 0; i < Mx_Dtt_Lugar_Pertenece_Respaldo.length; i++) {
                    selected.push(0);
                }
                for (i = 0; i < Mx_Dtt_Lugar_Pertenece_Respaldo.length; i++) {
                    for (x = 0; x < chupalo.length; x++) {
                        if (Mx_Dtt_Lugar_Pertenece_Respaldo[i].ID_PROCEDENCIA == chupalo[x]) {
                            selected[i] = chupalo[x];
                        } 
                    }

                }
               
                if (selected == "") {
                    //$("#mError_AAH h4").text("Sin Selección");
                    //$("#mError_AAH button").attr("class", "btn btn-danger");
                    //$("#mError_AAH p").text("No se ha seleccionado ningún lugar de TM.");
                    //$("#mError_AAH").modal();
                } else {
                    $('#eModal2').modal('hide');
                }
            });

            //BTN EXCEL
            $("#Btn_Excel").click(function () {
                Ajax_Excel();
            });
        });
    </script>
    <script>
        //------------------------------------------------- BUSCAR PROCEDENCIA ------------------------------------------------
        var Mx_Dtt_Proce = [
    {
        "ID_PROCEDENCIA": 0,
        "PROC_COD": 0,
        "PROC_DESC": 0,
        "ID_ESTADO": 0
    }
        ];
        function Ajax_Lugar_TM() {
            modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "M_Prevision.aspx/IRIS_WEBF_BUSCA_PROCEDENCIA",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Proce = JSON.parse(json_receiver);
                        Mx_Dtt_Lugar_Pertenece_Respaldo = JSON.parse(json_receiver);
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

        function Ajax_Codiguin(COD, DESC, ESTADO, ID) {
            $("#txtCod").val(COD);
            $("#txtDesc").val(DESC);
            $("#Ddl_Mantenedor").val(ESTADO);
            IDDDDDDD = parseInt(ID);

            Ajax_Busca_LugarTM_Pertenece_a(IDDDDDDD);
        };
        //------------------------------------------- BUSCAR ESTADO DEL MANTENEDOR -----------------------------------------
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
                "url": "M_Prevision.aspx/IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR",
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

        //------------------------------------------------- BUSCAR PREVISIONES ---------------------------------
        var Mx_Dtt = [
    {
        "ID_PREVE": 0,
        "PREVE_COD": 0,
        "PREVE_DESC": 0,
        "ID_ESTADO": 0
    }
        ];
        function Ajax_Tabla() {
            modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "M_Prevision.aspx/IRIS_WEBF_BUSCA_PREVISION_ACTIVO",
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
        //------------------------------------------------------- GRABAR ----------------------------------------------------|
        var numerin = 0
        function Ajax_Guardar() {
            modal_show();
            var Data_Par = JSON.stringify({
                "PREVE_COD": $("#txtCod").val(),
                "PREVE_DESC": $("#txtDesc").val(),
                "ID_ESTADO": $("#Ddl_Mantenedor").val(),
                "LUGARES": selected
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "M_Prevision.aspx/IRIS_WEBF_GRABA_PREVISION",
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
                        Mx_Dtt_Lugar_Pertenece_a.length = 0;
                        selected.length = 0;
                        Ajax_Tabla();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("");
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

        //---------------------------------------------------- UPDATE ----------------------------------------------------|
        var numerin = 0
        function Ajax_Update() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_PREVE": IDDDDDDD,
                "PREVE_COD": $("#txtCod").val(),
                "PREVE_DES": $("#txtDesc").val(),
                "ID_ESTADO": $("#Ddl_Mantenedor").val(),
                "LUGARES_TM": selected
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "M_Prevision.aspx/IRIS_WEBF_UPDATE_PREVISION",
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
                        Mx_Dtt_Lugar_Pertenece_a.length = 0;
                        Ajax_Tabla();
                        selected.length = 0;
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
                "ID_PREVE": IDDDDDDD,
                "PREVE_COD": $("#txtCod").val(),
                "PREVE_DES": $("#txtDesc").val(),
                "ID_ESTADO": 2
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "M_Prevision.aspx/DELETE_PRE",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        //numerin = JSON.parse(json_receiver);
                        Hide_Modal();

                        $("#txtCod").val("");
                        $("#txtDesc").val("");
                        $("#Ddl_Mantenedor").val(0);
                        Ajax_Tabla();
                        Mx_Dtt_Lugar_Pertenece_a.length = 0;
                        selected.length = 0;
                        
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
        //------------------------------------------------------- BUSCAR LUGAR TM PERTENECE A ----------------------------------------------------|
        var Mx_Dtt_Lugar_Pertenece_a = [
            {
                "PROC_DESC": 0,
                "ID_PROCEDENCIA": 0,
                "ID_ESTADO": 0,
                "ID_PREVE": 0,
                "ID_REL_PREV_PROC": 0
            }
        ];
        function Ajax_Busca_LugarTM_Pertenece_a(IDDDDDDD) {
            //modal_show();
            var Data_Par = JSON.stringify({
                "ID_PREVE": IDDDDDDD
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "M_Prevision.aspx/IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Lugar_Pertenece_a = JSON.parse(json_receiver);
                        
                        //Hide_Modal();

                    } else {

                        Hide_Modal();
   
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        //------------------------------------------ EXCEL ------------------------------------
        var Mx_Dtt_Excel = [
            {
                "urls": ""
            }
        ];
        function Ajax_Excel() {


            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "M_Prevision.aspx/Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        window.open(json_receiver, 'Download');


                    } else {

                    }
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
                        "onclick": `Ajax_Codiguin("` + Mx_Dtt[i].PREVE_COD + `","` + Mx_Dtt[i].PREVE_DESC + `","` + Mx_Dtt[i].ID_ESTADO + `","` + Mx_Dtt[i].ID_PREVE + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PREVE_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PREVE_DESC),
                        $("<td>").css("text-align", "center").html("<div class='checkbox checkbox-success pz' style='margin-top:-5px;'><input type='checkbox' class='manitos2' id='Hasdasd" + i + "'/><label class='manitos2' for='Hasdasd" + i + "'></label></div>")
                    )
                );
                if (Mx_Dtt[i].ID_ESTADO == 1) {
                    $("#Hasdasd" + i).prop("checked", true);
                }
            }
            $("#DataTable tbody tr").click(function () {
                $("#DataTable tbody tr").removeClass("active");
                $(this).addClass("active");
            });
        }
        //------------------------------------------------------------------ TABLA MODAL LUGAR TM-------------------------------------------|
        function Fill_DataTable_Lugar_TM() {
            $("<table>", {
                "id": "DataTable_Lugar_Tm",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Lugar_Tm");
            $("#DataTable_Lugar_Tm").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Lugar_Tm").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Lugar_Tm thead").attr("class", "cabzera");
            $("#DataTable_Lugar_Tm thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Código"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Selección")
                )
            );
            for (i = 0; i < Mx_Dtt_Proce.length; i++) {
                $("#DataTable_Lugar_Tm tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Proce[i].PROC_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Proce[i].PROC_DESC),
                        $("<td>").css("text-align", "center").html("<div class='checkbox checkbox-success pp' style='margin-top:-5px;'><input type='checkbox' class='manitos2' id='H" + i + "' value='" + Mx_Dtt_Proce[i].ID_PROCEDENCIA + "' /><label class='manitos2' for='H" + i + "'></label></div>")
                    )
                );

                for (ii = 0; ii < Mx_Dtt_Lugar_Pertenece_a.length; ii++) {
                    if (Mx_Dtt_Lugar_Pertenece_a.length != 0) {
                        if (Mx_Dtt_Lugar_Pertenece_a[ii].ID_PROCEDENCIA == Mx_Dtt_Proce[i].ID_PROCEDENCIA) {
                            $("#H" + i).prop("checked", true);
                        }
                    }
                    
                }
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

    <div class="modal fade" id="eModal2" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Agregar Lugar TM</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="col-md-12">
                            <div id="Div_Tabla_Lugar_Tm" style="width: 100%;" class="highlights2"></div>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btn_cargar_TM" class="btn btn-success">Cargar</button>
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
                    Previsión
                </h5>
            </div>
            <div class="row mb-3">
                <div class="col-md">
                    <label for="txtCod">Código:</label>
                    <input id="txtCod" class="form-control textoReducido" type="text" />
                </div>
                <div class="col-md">
                    <label for="txtDesc">Descripción:</label>
                    <input id="txtDesc" class="form-control text-uppercase textoReducido" type="text" />
                </div>
                <div class="col-md">
                    <label for="Ddl_Mantenedor">Estado:</label>
                    <select id="Ddl_Mantenedor" class="form-control textoReducido mayus">
                    </select>
                </div>
                <div class="col-md">
                    <label for="btn_modal">Lugar TM:</label>
                    <button id="btn_modal" class="btn btn-buscar btn-block" style="margin-top: 0vh" type="submit">Agregar/Quitar <i class="fa fa-plus" aria-hidden="true"></i></button>
                </div>
            </div>

            <%------------------------------------------------------------ TABLAS -------------------------------------------------------------%>
            <div class="row mb-3" id="Id_Conte">
                <div class="col-md-12" id="Paciente">
                    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i> Lista de Previsión</h5>
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
