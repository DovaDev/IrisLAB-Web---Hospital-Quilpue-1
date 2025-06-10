<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Asoc_Costo_Exa.aspx.vb" Inherits="Presentacion.Asoc_Costo_Exa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>
        var Arrpos = [];
        var Mx_Pos4 = [];
        var Mx_Pos5 = [];
        var Mx_Pos6 = [];
        var Arrpos_Q = [];
        var ID_Nuevo = "";
        var val_Costo = 0;
        var tot_Costo = 0;
        $(document).ready(function () {

            Ajax_Examen();

            $("#slt_Examen").change(function () {
                modal_show();
                Ajax_Asoc_CF_Costo();
            });

            //BTN AGREGAR
            $("#btn_Agregar").click(function () {
                Mx_Pos4 = [];
                Arrpos.forEach(function (aaa) {
                    Mx_Pos4.push({
                        "ID_CONTROL": ID_Nuevo,
                        "ID_COSTO": Mx_Costos[aaa].ID_COSTO,
                        "PRECIO": 0,
                        "ID_USUARIO": ID_USUU
                    });
                });
                Ajax_Graba_Det_Control_Costo();
                //console.log(Mx_Pos4);
            });

            //BTN QUITAR
            $("#btn_Quitar").click(function () {
                Mx_Pos5 = [];
                Arrpos_Q.forEach(function (aaa) {
                    Mx_Pos5.push({
                        "ID_CONTROL": ID_Nuevo,
                        "ID_COSTO": Mx_Costos[aaa].ID_COSTO
                    });
                });
                Ajax_Quita_Det_Control_Costo();
            });

            //BTN GUARDAR
            $("#btn_Guardar").click(function () {
                Mx_Pos6 = [];
                val_Costo = 0;
                tot_Costo = 0;
                //console.log("guardar click");
                if (Mx_Costo_Cargado.length > 1) {
                    Mx_Costo_Cargado.forEach(function (aaa) {
                        val_Costo = $("#Val_" + aaa.ID_COSTO).val();
                        tot_Costo = parseInt(tot_Costo) + parseInt(val_Costo);
                    });
                    $("#Suma_Total").text("Total Costo: $" + tot_Costo);
                    Mx_Costo_Cargado.forEach(function (aaa) {
                        val_Costo = $("#Val_" + aaa.ID_COSTO).val();
                        if (val_Costo == "") {
                            val_Costo = 0;
                        }
                        ///////////
                        Mx_Pos6.push({
                            "ID_CONTROL_COSTO": ID_Nuevo,
                            "ID_COSTO": aaa.ID_COSTO,
                            "PRECIO": parseInt(val_Costo),
                            "TOTAL_PRECIO": tot_Costo
                        });

                    });
                    Ajax_Update_CF_Costo();
                    //console.log(Mx_Pos6);
                }

            });

        });
        var ID_USUU = Galletas.getGalleta("ID_USER");
        var Total_Costo = 0;
        var Folio_ = "";
        var Folio_2 = "";
        var Mx_Costos_Precio = [];
        //CARGAR EXAMEN
        var Mx_Examen = [{
            "ID_CODIGO_FONASA": 0,
            "CF_COD": 0,
            "CF_DESC": 0
        }];
        function Ajax_Examen() {
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Asoc_Costo_Exa.aspx/Llenar_Examen",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Examen = json_receiver;
                        Fill_Ddl_Examen();
                    } else {
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    $("#mdlNotif .modal-header h4").text("Algo no ocurrio como esperabamos");
                    $("#mdlNotif .modal-body p").html("Intente nuevamente mas tarde.");
                    $("#mdlNotif").modal();
                }
            });
        }
        function Fill_Ddl_Examen() {
            $("#slt_Examen").empty();
            $("<option>", { "value": 000 }).text("Seleccione Exámen").appendTo("#slt_Examen");
            Mx_Examen.forEach(aaa => {
                $("<option>", { "value": aaa.ID_CODIGO_FONASA }).text(aaa.CF_DESC).appendTo("#slt_Examen");
            });
        }
        //BUSCAR ASOC COSTO CF
        var Mx_Costo_CF = [{
            "ID_CODIGO_FONASA": 0,
            "CONTROL_COSTO_NUM": 0,
            "ID_CONTROL_COSTO": 0,
            "ID_ESTADO": 0,
            "EXIST": 0,
            "COUNT_DET": 0
        }];
        function Ajax_Asoc_CF_Costo() {
            Total_Costo = 0;
            ID_Nuevo = "";
            $(".block_wait").fadeIn(500);
            Arrpos = [];
            $("#DataTable_Costos tbody").empty();
            $("#DataTable_Valor tbody").empty();
            Mx_Costo_Cargado = [];
            var Data_Par = JSON.stringify({
                "ID_FONASA": $("#slt_Examen").val(),
                "ID_USUARIO": ID_USUU
            });
            $.ajax({
                "type": "POST",
                "url": "Asoc_Costo_Exa.aspx/Busca_Control_Fonasa",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    //console.log(json_receiver);
                    if (json_receiver[0].ID_CONTROL_COSTO != 0) {
                        Mx_Costo_CF = json_receiver;
                        //CARGADOS Y NO CARGADOS
                        ID_Nuevo = Mx_Costo_CF[0].ID_CONTROL_COSTO;
                        /////////////////
                        if (Mx_Costo_CF[0].COUNT_DET != 0) {
                            //console.log("true");
                            Ajax_C_Cargado();
                        }
                        else {
                            //console.log("false");
                            Ajax_Costos();
                        }
                    } else {
                        //console.log("todos");
                        //CARGAR TODOS
                        Ajax_Costos();
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    $("#mdlNotif .modal-header h4").text("Algo no ocurrio como esperabamos");
                    $("#mdlNotif .modal-body p").html("Intente nuevamente mas tarde.");
                    $("#mdlNotif").modal();
                }
            });
        }
        //CARGAR COSTOS TODOS
        var Mx_Costos = [{
            "ID_COSTO": 0,
            "COSTO_COD": "",
            "COSTO_DESC": ""
        }];
        function Ajax_Costos() {
    
            $("#DataTable_Valor tbody").empty();
            $("#DataTable_Costos tbody").empty();
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Asoc_Costo_Exa.aspx/Llenar_Costos",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {

                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Costos = json_receiver;
                        if (Mx_Costo_CF[0].COUNT_DET == 0) {
                            Fill_Table_Costos();
                            Hide_Modal();
                        }
                        else {
                            var cc = 0;
                            var pos = 0;
                            //TABLE
                           
                            Mx_Costos.forEach(cost => {
                                
                                Mx_Costo_Cargado.forEach(carg => {
                         
                                    if (cost.ID_COSTO == carg.ID_COSTO) {
                                        cc = 1;
                                        //console.log(cost);
                                        costt = carg.DET_CONT_COSTO_PRECIO;
                                    }
                                });
                                if (cc == 0) {
                                    //console.log("cc0");
                                    //izq                        
                                    $("#DataTable_Costos tbody").append(
                                        $("<tr>", { "class": "manito", "id": cost.ID_COSTO }).append(
                                            $("<td>", { "align": "left", "class": "textoReducido" }).text(cost.COSTO_DESC),
                                            $("<td>", { style: "padding-left: 2vh" }).html("<input type='checkbox' name='Agregaa' data-value='" + pos + "'/>")
                                        )
                                    );
                                    pos = pos + 1;
                                }
                                else {
                                    //console.log("cc1");
                                    //der
                                    $("#DataTable_Valor tbody").append(
                                        $("<tr>", { "class": "manito" }).append(
                                            $("<td>", { "align": "left", "class": "textoReducido" }).text(cost.COSTO_DESC),
                                            $("<td>").html("<input type='text' name='Costoss' id='Val_" + cost.ID_COSTO + "' value = '" + costt + "'/> "),
                                            $("<td>", { style: "padding-left: 2vh" }).html("<input type='checkbox' name='Quitarr' data-value='" + pos + "'/>")

                                        )
                                    );
                                    Total_Costo = Total_Costo + costt;
                                    cc = 0;
                                    pos = pos + 1;
                                }
                            });
                            Click_Check_Add();
                            Click_Check_Quit();

                        }

                        $("#Suma_Total").text("Total Costo: $" + Total_Costo);

                        $("input[name='Costoss']").on("input", aah => {
                            


                            //console.log("change");
                            //console.log(Mx_Costo_Cargado);
                            var valCosto = 0;
                            var totCosto = 0;

                            if (Mx_Costo_Cargado.length > 1) {
                                Mx_Costo_Cargado.forEach(function (aaa) {
                                    valCosto = $("#Val_" + aaa.ID_COSTO).val();
                                    valCosto = valCosto.replace(/\D/gi, "");
                                    $("#Val_" + aaa.ID_COSTO).val(valCosto);
                          
                                    if (valCosto == "") {
                                        valCosto = 0;
                                    }
                                    //console.log(valCosto);
                                    totCosto = parseInt(totCosto) + parseInt(valCosto);
                                    //console.log(totCosto);
                                });
                                $("#Suma_Total").text("Total Costo: $" + totCosto);
                                //console.log(tot_Costo);
                            }
                        });
                    } else {
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    Hide_Modal();
                    $("#mdlNotif .modal-header h4").text("Algo no ocurrio como esperabamos");
                    $("#mdlNotif .modal-body p").html("Intente nuevamente mas tarde.");
                    $("#mdlNotif").modal();
                }
            });
        }
        function Fill_Table_Costos() {
            //console.log("COSTOS");
            for (i = 0; i < Mx_Costos.length; i++) {
                $("#DataTable_Costos tbody").append(
                    $("<tr>", { "class": "manito", "id": Mx_Costos[i].ID_COSTO }).append(
                        $("<td>", { "align": "left", "class": "textoReducido" }).text(Mx_Costos[i].COSTO_DESC),
                        $("<td>", { style: "padding-left: 2vh" }).html("<input type='checkbox' name='Agregaa' data-value='" + i + "'/>")
                    )
                );
            }
            Click_Check_Add();
        }
        //BUSCA COSTOS CARGADOS
        var Mx_Costo_Cargado = [{
            "ID_COSTO": 0,
            "DET_CONT_COSTO_PRECIO": 0
        }];
        function Ajax_C_Cargado() {
            $(".block_wait").fadeIn(500);

            var Data_Par = JSON.stringify({
                "ID_CONTROL": ID_Nuevo
            });

            $.ajax({
                "type": "POST",
                "url": "Asoc_Costo_Exa.aspx/Busca_Cargados",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        $("#DataTable_Costos tbody").empty();
                        $("#DataTable_Valor tbody").empty();
                        Mx_Costo_Cargado = json_receiver;
                        //console.log(Mx_Costo_Cargado);
                        Ajax_Costos();
                        Hide_Modal();
                    } else {
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    $("#mdlNotif .modal-header h4").text("Algo no ocurrio como esperabamos");
                    $("#mdlNotif .modal-body p").html("Intente nuevamente mas tarde.");
                    $("#mdlNotif").modal();
                }
            });
        }
        //GRABA DET CONTROL COSTO
        function Ajax_Graba_Det_Control_Costo() {
            //console.log(Mx_Pos4);
            var Data_Par = JSON.stringify({
                "Mx_Pos": Mx_Pos4
            });
            //console.log("DET " + Data_Par);
            $.ajax({
                "type": "POST",
                "url": "Asoc_Costo_Exa.aspx/Graba_Det_Control_Costo",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != 0) {
                        Mx_Pos4 = [];
                        Ajax_Asoc_CF_Costo();
                        //console.log("SUCCES DETALLE " + aaa);
                        //console.log(json_receiver);

                    } else {
                        //console.log("ERROR DETALLE ");
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    Hide_Modal();
                    $("#mdlNotif .modal-header h4").text("Algo no ocurrio como esperabamos");
                    $("#mdlNotif .modal-body p").html("Intente nuevamente mas tarde.");
                    $("#mdlNotif").modal();
                }
            });
        }
        //UPDATE QUITA DET CONTROL COSTO
        function Ajax_Quita_Det_Control_Costo() {
            //console.log("QUITA DET control costo");
            //ID_DET_CONT
            var Data_Par = JSON.stringify({
                "Mx_Pos": Mx_Pos5
            });
            //ID COSTO MAS ID REL COSTO
            $.ajax({
                "type": "POST",
                "url": "Asoc_Costo_Exa.aspx/Update_Det_Control_Costo",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        console.log("SUCCESS DET QUITA COSTO");
                        Mx_Pos5 = [];
                        Ajax_Asoc_CF_Costo();
                    } else {
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    $("#mdlNotif .modal-header h4").text("Algo no ocurrio como esperabamos");
                    $("#mdlNotif .modal-body p").html("Intente nuevamente mas tarde.");
                    $("#mdlNotif").modal();
                }
            });
        }
        //UPDATE DET CONTROL COSTO
        function Ajax_Update_CF_Costo() {

            //console.log("UPDATE COSTO CONTROL COSTO");
            /////////////////////TOT
            var Data_Par = JSON.stringify({
                "Mx_Pos": Mx_Pos6
            });
            //console.log(Data_Par);
            $.ajax({
                "type": "POST",
                "url": "Asoc_Costo_Exa.aspx/Update_CF_Control",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        //console.log("SUCCESS UPDATE CF COSTO");
                        Mx_Pos6 = [];
                        Ajax_Asoc_CF_Costo();
                        //MODAL
                    } else {
                        Hide_Modal();
                        //console.log("ERROR UPDATE CF COSTO");
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    $("#mdlNotif .modal-header h4").text("Algo no ocurrio como esperabamos");
                    $("#mdlNotif .modal-body p").html("Intente nuevamente mas tarde.");
                    $("#mdlNotif").modal();
                }
            });
        }
        //FUNCTON CLICK CHECK
        function Click_Check_Add() {
            $("input[name='Agregaa']").click(function () {
                if ($(this).is(":checked")) {
                    if (Arrpos.length != 0) {
                        var Pos = $(this).attr("data-value");
                        var var_conf = "";
                        Arrpos.forEach(function (aa) {
                            if (aa == Pos) { var_conf = 1; }
                        });
                        if (var_conf == 0) { Arrpos.push(Pos); }
                    }
                    else {
                        var Pos = $(this).attr("data-value");
                        Arrpos.push(Pos);
                    }
                }
                else {
                    var Pos = $(this).attr("data-value");
                    var index = Arrpos.indexOf(Pos);
                    if (index > -1) { Arrpos.splice(index, 1); }
                }
                //ORDENAR ARRAY
                Arrpos = Arrpos.sort(function (a, b) { return a - b; });
                //console.log("AGREGAR: "+Arrpos);
            });
        }
        function Click_Check_Quit() {
            $("input[name='Quitarr']").click(function () {
                if ($(this).is(":checked")) {
                    if (Arrpos_Q.length != 0) {
                        var Pos_q = $(this).attr("data-value");
                        var var_conf_q = "";
                        Arrpos_Q.forEach(function (aa) {
                            if (aa == Pos_q) { var_conf_q = 1; }
                        });
                        if (var_conf_q == 0) { Arrpos_Q.push(Pos_q); }
                    }
                    else {
                        var Pos_q = $(this).attr("data-value");
                        Arrpos_Q.push(Pos_q);
                    }
                }
                else {
                    var Pos_q = $(this).attr("data-value");
                    var index = Arrpos_Q.indexOf(Pos_q);
                    if (index > -1) { Arrpos_Q.splice(index, 1); }
                }
                //ORDENAR ARRAY
                Arrpos_Q = Arrpos_Q.sort(function (a, b) { return a - b; });
                //console.log("QUITAR:"+Arrpos_Q);
            });
        }


    </script>
    <style>
        .btn-sq-lg {
            width: 100px !important;
            height: 100px !important;
        }

        .Suma_Total {
            font-size: 22px;
            color: red !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <!-- Modal -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
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
    <div class="card">
        <div class="card-header bg-bar p-2">
            <h5>Asociar Costo a Exámen</h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-3">
                    <label>Exámen:</label>
                    <select id="slt_Examen" class="form-control"></select>
                </div>
                <div class="col-md-3">
                    <button type="button" class="btn btn-primary" id="btn_Guardar" style="margin-top: 2rem"><i class="fa fa-save mr-2"></i>Guardar</button>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-lg-5 mb-3" style="overflow: auto; height: 60vh;">
                    <table class="table table-hover table-striped table-iris" id="DataTable_Costos">
                        <thead>
                            <tr>
                                <th>Costo</th>
                                <th>Cargar</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
                <div class="col-lg-2 mb-3">
                    <div class="row  text-center mb-3">
                        <div class="col">
                            <a class="btn btn-sq-lg btn-primary" style="color: white" id="btn_Agregar"><b><i class="fa fa-arrow-right fa-3x"></i>
                                <br />
                                Agregar</b></a>
                        </div>
                    </div>
                    <div class="row  text-center">
                        <div class="col">
                            <a class="btn btn-sq-lg btn-danger" style="color: white" id="btn_Quitar"><b><i class="fa fa-arrow-left fa-3x"></i>
                                <br />
                                Quitar</b></a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-5" style="overflow: auto; height: 60vh;">
                    <table class="table table-hover table-striped table-iris" id="DataTable_Valor">
                        <thead>
                            <tr>
                                <th>Costo</th>
                                <th>Valor</th>
                                <th>Quitar</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-7"></div>
                <div class="col-lg-5">
                    <a id="Suma_Total" class="Suma_Total"></a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
