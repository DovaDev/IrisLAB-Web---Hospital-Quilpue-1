<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Rel_Prev_Prog_SubProg.aspx.vb" Inherits="Presentacion.Rel_Prev_Prog_SubProg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
       <script>
           //var Mx_Dtt_Lugar_Pertenece_Respaldo = new Array
           //var chupalo = new Array
           var selected_progra = new Array();
           var selected_subprogra = new Array();
           //var IDDDDDDD = 0;

           var IDDDD_PREVE = 0;
           var IDDDD_PROGRA = 0;
           var IDDDD_SUBPROGRA = 0;

           $(document).ready(function () {
            Ajax_Prevision();
            //Ajax_Programa();
            //Ajax_SubPrograma();
            //Ajax_Mantenedor();
            
            $("#Div_Tabla_Programa").hide();
            $("#Div_Tabla_SubPrograma").hide();

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

                    }
                    //else if (($("#Ddl_Mantenedor").val() == 1) && (selected == "")) {
                    //    $("#mError_AAH h4").text("Seleccione");
                    //    $("#mError_AAH button").attr("class", "btn btn-danger");
                    //    $("#mError_AAH p").text("Por favor, seleccione una previsión.");
                    //    $("#mError_AAH").modal();
                    //} else if (selected == "") {
                    //    $("#mError_AAH h4").text("Seleccione");
                    //    $("#mError_AAH button").attr("class", "btn btn-danger");
                    //    $("#mError_AAH p").text("Por favor, revice previsión.");
                    //    $("#mError_AAH").modal();
                    //}
                    else {
                        Ajax_Update();
                    }
                }
            });
               //BTN ELIMINAR
            $("#Btn_Eliminar").click(function () {
                $(".pzz input:checkbox:checked").each(function () {
                    selected_subprogra.push($(this).val());
                });

                if (IDDDD_PREVE == 0 || IDDDD_PROGRA == 0 || selected_subprogra == "") {
                    $("#mError_AAH h4").text("Revise");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Revise los valores.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_Delete();
                }
            });

               //BTN GUARDAR
            $("#Btn_Guardar").click(function () {
                $(".pzz input:checkbox:checked").each(function () {
                    selected_subprogra.push($(this).val());
                });
                if (selected_subprogra == "" || IDDDD_PROGRA == 0) {
                    $("#mError_AAH h4").text("Seleccione");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, complete los campos solicitados.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_Guardar();

                }
            });
            
               //AJAX GUARDAR EN EL MODAL MARCAR
            //$("#btn_Prevision").click(function () {
            //    selected = new Array();
            //    chupalo.length = 0;
            //    $(".pp input:checkbox:checked").each(function () {
            //        selected.push($(this).val());
            //    });
            //    chupalo = selected.slice();
            //    selected.length = 0;

            //    for (i = 0; i < Mx_Dtt_Lugar_Pertenece_Respaldo.length; i++) {
            //        selected.push(0);
            //    }
            //    for (i = 0; i < Mx_Dtt_Lugar_Pertenece_Respaldo.length; i++) {
            //        for (x = 0; x < chupalo.length; x++) {
            //            if (Mx_Dtt_Lugar_Pertenece_Respaldo[i].ID_PREVE == chupalo[x]) {
            //                selected[i] = chupalo[x];
            //            }
            //        }

            //    }

            //    if (selected == "") {
            //        //$("#mError_AAH h4").text("Sin Selección");
            //        //$("#mError_AAH button").attr("class", "btn btn-danger");
            //        //$("#mError_AAH p").text("No se ha seleccionado ningún lugar de TM.");
            //        //$("#mError_AAH").modal();
            //    } else {
            //        $('#eModal2').modal('hide');
            //    }
            //});

            //BTN EXCEL
            $("#Btn_Excel").click(function () {
                Ajax_Excel();
            });
        });
    </script>
    <script>

        function Ajax_Codiguin_Preve(ID) {
            IDDDD_PREVE = parseInt(ID);

            if (IDDDD_PREVE == 0) {
                $("#mError_AAH h4").text("Previsión");
                $("#mError_AAH button").attr("class", "btn btn-danger");
                $("#mError_AAH p").text("Debe Seleccionar una previsión.");
                $("#mError_AAH").modal();
            } else {
                Ajax_Programa();
            }
        };

        function Ajax_Codiguin_Progra(ID) {
            IDDDD_PROGRA = parseInt(ID);

            if (IDDDD_PREVE == 0) {
                $("#mError_AAH h4").text("Previsión");
                $("#mError_AAH button").attr("class", "btn btn-danger");
                $("#mError_AAH p").text("Debe Seleccionar una previsión.");
                $("#mError_AAH").modal();
            } else if (IDDDD_PROGRA == 0) {
                $("#mError_AAH h4").text("Programa");
                $("#mError_AAH button").attr("class", "btn btn-danger");
                $("#mError_AAH p").text("Debe Seleccionar un programa.");
                $("#mError_AAH").modal();
            } else {
                Ajax_SubPrograma();
            }
        };

        //function Ajax_Codiguin_SubProgra(ID) {
        //    IDDDD_SUBPROGRA = parseInt(ID);
        //};
        var Mx_Dtt_Mantenedor = [
          {
              "ID_ESTADO": 0,
              "EST_DESCRIPCION": 0,
              "EST_MANTENEDOR": 0
          }
        ];
        function Ajax_Mantenedor() {

            $.ajax({
                "type": "POST",
                "url": "Rel_Prev_Prog_SubProg.aspx/IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Mantenedor = JSON.parse(json_receiver);
                        Hide_Modal();

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
        //------------------------------------------------- BUSCAR PREVISIONES ---------------------------------
        var Mx_Dtt_Pevision = [
    {
        "ID_PREVE": 0,
        "PREVE_COD": 0,
        "PREVE_DESC": 0,
        "ID_ESTADO": 0
    }
        ];
        function Ajax_Prevision() {
            modal_show();
            $.ajax({
                "type": "POST",
                "url": "Rel_Prev_Prog_SubProg.aspx/IRIS_WEBF_BUSCA_PREVISION_ACTIVO",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Pevision = JSON.parse(json_receiver);
                        //Mx_Dtt_Lugar_Pertenece_Respaldo = JSON.parse(json_receiver);
                        Fill_DataTable_Prevision();
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
        //---------------------------------------------- PROGRAMA -----------------------------------------------
        var Mx_Dtt_Programa = [
    {
        "ID_PROGRA": 0,
        "PROGRA_COD": 0,
        "PROGRA_DESC": 0,
        "ID_ESTADO": 0,
        "CHECK": 0
    }
        ];
        function Ajax_Programa() {
            var Data_Par = JSON.stringify({
                "ID_PREVE": IDDDD_PREVE
            });
            $.ajax({
                "type": "POST",
                "url": "Rel_Prev_Prog_SubProg.aspx/IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Programa = JSON.parse(json_receiver);
                        $("#DataTable_Programa").empty();
                        $("#div_programa").fadeOut(500);
                        $("#Div_Tabla_Programa").fadeIn(500);
                        $("#Div_Tabla_SubPrograma").fadeOut(500);
                        
                        Fill_DataTable_Programa ();
                        Hide_Modal();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                        $("#div_programa").fadeIn(500);
                        $("#Div_Tabla_Programa").fadeOut(500);
                        $("#Div_Tabla_SubPrograma").fadeOut(500);
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        //-------------------------------------------------- SUB-PROGRAMA ---------------------------------------------------------
        var Mx_Dtt_SubPrograma = [
        {
            "ID_SUBP": 0,
            "SUBP_COD": 0,
            "SUBP_DESC": 0,
            "ID_ESTADO": 0,
            "CHECK": 0
        }
        ];
        function Ajax_SubPrograma() {

            var Data_Par = JSON.stringify({
                "ID_PREVE": IDDDD_PREVE,
                "ID_PROGRA": IDDDD_PROGRA
            });

            $.ajax({
                "type": "POST",
                "url": "Rel_Prev_Prog_SubProg.aspx/IRIS_WEBF_BUSCA_REL_PROGRAMA_SUBPROGRAMA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_SubPrograma = JSON.parse(json_receiver);
                        $("#DataTable_SubPrograma").empty();
                        $("#div_subprograma").fadeOut(500);
                        $("#DataTable_SubPrograma").empty();
                        $("#Div_Tabla_SubPrograma").fadeIn(500);
                        Fill_DataTable_SubPrograma();
                        Hide_Modal();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                        $("#div_subprograma").fadeIn(500);
                        $("#Div_Tabla_SubPrograma").fadeOut(500);
                    }
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
                "ID_PREVE": IDDDD_PREVE,
                "ID_PROGRA": IDDDD_PROGRA,
                "selected_subprogra": selected_subprogra
            });
            $.ajax({
                "type": "POST",
                "url": "Rel_Prev_Prog_subProg.aspx/IRIS_WEBF_UPDATE_PROGRAMA_SUBPROGRAMA_RELACION",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        //numerin = JSON.parse(json_receiver);

                        Hide_Modal();

                        for (i = 0; i < selected_subprogra.length; i++) {
                            selected_subprogra.splice(i);
                        }

                        $("#mError_AAH h4").text("Cambios Realizados");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("La relación se ha ELIMINADO satisfactoriamente.");
                        $("#mError_AAH").modal();

                        $("#DataTable_Programa").empty();
                        $("#DataTable_SubPrograma").empty();
                        $("#Div_Tabla_Programa").hide();
                        $("#Div_Tabla_SubPrograma").hide();
                        $("#div_programa").show();
                        $("#div_subprograma").show();
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
        var Mx_Dtt_GUARDAR = [
            {
                "ID_REL": 0
            }
        ];
        function Ajax_Guardar() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_PREVE": IDDDD_PREVE,
                "ID_PROGRA": IDDDD_PROGRA,
                "selected_subprogra": selected_subprogra
            });
            $.ajax({
                "type": "POST",
                "url": "Rel_Prev_Prog_SubProg.aspx/IRIS_WEBF_GRABA_PROGRAMA_SUBPROGRAMA_RELACION",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_GUARDAR = JSON.parse(json_receiver);
                        Hide_Modal();

                        for (i = 0; i < selected_subprogra.length; i++) {
                            selected_subprogra.splice(i);
                        }

                        $("#mError_AAH h4").text("Cambios realizados");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("La relación se ha CREADO satisfactoriamente.");
                        $("#mError_AAH").modal();

                        $("#DataTable_Programa").empty();
                        $("#DataTable_SubPrograma").empty();
                        $("#Div_Tabla_Programa").hide();
                        $("#Div_Tabla_SubPrograma").hide();
                        $("#div_programa").show();
                        $("#div_subprograma").show();
                    
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
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
                "url": "Programa.aspx/Excel",
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
        //------------------------------------------------------------------ TABLA PREVISION -------------------------------------------|
        function Fill_DataTable_Prevision() {
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
                    $("<th>", { "class": "textoReducido" }).text("Código"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción")
                )
            );
            for (i = 0; i < Mx_Dtt_Pevision.length; i++) {
                $("#DataTable_Prevision tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Codiguin_Preve("` + Mx_Dtt_Pevision[i].ID_PREVE + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Pevision[i].PREVE_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Pevision[i].PREVE_DESC)
                    )
                );
            }
            $("#DataTable_Prevision tbody tr").click(function () {
                $("#DataTable_Prevision tbody tr").removeClass("active");
                $(this).addClass("active");
            });
        }

        //------------------------------------------------------------------ TABLA PROGRAMA -------------------------------------------|
        function Fill_DataTable_Programa() {
            $("<table>", {
                "id": "DataTable_Programa",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Programa");
            $("#DataTable_Programa").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Programa").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Programa thead").attr("class", "cabzera");
            $("#DataTable_Programa thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Código"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción")
                    //$("<th>", { "class": "textoReducido text-center" }).text("Selección")
                )
            );
            for (i = 0; i < Mx_Dtt_Programa.length; i++) {
                $("#DataTable_Programa tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Codiguin_Progra("` + Mx_Dtt_Programa[i].ID_PROGRA + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Programa[i].PROGRA_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Programa[i].PROGRA_DESC)
                        //$("<td>").css("text-align", "center").html("<div class='checkbox checkbox-success pz' style='margin-top:-5px;'><input type='checkbox' class='manitos2' id='ABCCCCC" + i + "' value='" + Mx_Dtt_Programa[i].ID_PROGRA + "'/><label class='manitos2' for='ABCCCCC" + i + "'></label></div>")
                    )
                );
                //if (Mx_Dtt_Programa[i].CHECK == 1) {
                //    $("#ABCCCCC" + i).prop("checked", true);
                //}
            }
            $("#DataTable_Programa tbody tr").click(function () {
                $("#DataTable_Programa tbody tr").removeClass("active");
                $(this).addClass("active");
            });
        }
        //------------------------------------------------------------------ TABLA SUBPROGRAMA -------------------------------------------|
        function Fill_DataTable_SubPrograma() {
            $("<table>", {
                "id": "DataTable_SubPrograma",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_SubPrograma");
            $("#DataTable_SubPrograma").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_SubPrograma").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_SubPrograma thead").attr("class", "cabzera");
            $("#DataTable_SubPrograma thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Código"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Selección")
                )
            );
            for (i = 0; i < Mx_Dtt_SubPrograma.length; i++) {
                $("#DataTable_SubPrograma tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_SubPrograma[i].SUBP_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_SubPrograma[i].SUBP_DESC),
                        $("<td>").css("text-align", "center").html("<div class='checkbox checkbox-success pzz' style='margin-top:-5px;'><input type='checkbox' class='manitos2' id='FFFGGBBBB" + i + "' value='" + Mx_Dtt_SubPrograma[i].ID_SUBP + "'/><label class='manitos2' for='FFFGGBBBB" + i + "'></label></div>")
                    )
                );
                if (Mx_Dtt_SubPrograma[i].CHECK == 1) {
                    $("#FFFGGBBBB" + i).prop("checked", true);
                }
            }
            //$("#DataTable_SubPrograma tbody tr").click(function () {
            //    $("#DataTable_SubPrograma tbody tr").removeClass("active");
            //    $(this).addClass("active");
            //});
        }
        //------------------------------------------------------------------ TABLA MODAL LUGAR TM-------------------------------------------|
        //function Fill_DataTable_Prevision() {
        //    $("<table>", {
        //        "id": "DataTable_Prevision",
        //        "class": "display",
        //        "width": "100%",
        //        "cellspacing": "0"
        //    }).appendTo("#Div_Tabla_Prevision");
        //    $("#DataTable_Prevision").append(
        //        $("<thead>"),
        //        $("<tbody>")
        //    );
        //    $("#DataTable_Prevision").attr("class", "table table-hover table-striped table-iris");
        //    $("#DataTable_Prevision thead").attr("class", "cabzera");
        //    $("#DataTable_Prevision thead").append(
        //        $("<tr>").append(
        //            $("<th>", { "class": "textoReducido" }).text("#"),
        //            $("<th>", { "class": "textoReducido" }).text("Código"),
        //            $("<th>", { "class": "textoReducido" }).text("Descripción"),
        //            $("<th>", { "class": "textoReducido text-center" }).text("Selección")
        //        )
        //    );
        //    for (i = 0; i < Mx_Dtt_Pevision.length; i++) {
        //        $("#DataTable_Prevision tbody").append(
        //            $("<tr>").append(
        //                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
        //                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Pevision[i].PREVE_COD),
        //                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Pevision[i].PREVE_DESC),
        //                $("<td>").css("text-align", "center").html("<div class='checkbox checkbox-success pp' style='margin-top:-5px;'><input type='checkbox' class='manitos2' id='H" + i + "' value='" + Mx_Dtt_Pevision[i].ID_PREVE + "' /><label class='manitos2' for='H" + i + "'></label></div>")
        //            )
        //        );

        //        for (ii = 0; ii < Mx_Dtt_Lugar_Pertenece_a.length; ii++) {
        //            if (Mx_Dtt_Lugar_Pertenece_a.length != 0) {
        //                if (Mx_Dtt_Lugar_Pertenece_a[ii].ID_PREVE == Mx_Dtt_Pevision[i].ID_PREVE) {
        //                    $("#H" + i).prop("checked", true);
        //                }
        //            }

        //        }
        //    }
        //}
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
    <%---------------------------------------------------- MODAL PREVISIONES -------------------%>
<%--        <div class="modal fade" id="eModal2" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Agregar Previsión</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="col-md-12">
                            <div id="Div_Tabla_Prevision" style="width: 100%;" class="highlights2"></div>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btn_Prevision" class="btn btn-success">Cargar</button>
                </div>
            </div>
        </div>
    </div>--%>

    <%------------------------------------------------------TÍTULO, TEXTBOX Y BOTONES-----------------------------------------%>
    <div class="row">
        <div class="col-lg-12">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar">
                <h5 style="text-align: center; padding: 5px;">
                    <i class="fa fa-info"></i>
                    Relación Previsión - Programa - SubPrograma
                </h5>
            </div>
            <%--<div class="row mb-4">
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
                <%--<div class="col-md-3">
                    <label for="btn_modal">Previsión:</label>
                    <button id="btn_modal" class="btn btn-buscar btn-block" style="margin-top: 0vh" type="submit">Agregar/Quitar <i class="fa fa-plus" aria-hidden="true"></i></button>
                </div>--%>
            </div>

            <%------------------------------------------------------------ TABLAS -------------------------------------------------------------%>
            <div class="row mb-3" id="Id_Conte">
                <div class="col-md-12">
                    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i> Lista para relacionar</h5>
                    <div class="row">
                        <div class="col-md-4">
                            <div id="Div_Tabla_Prevision" style="width:100%;" class="highlights"></div>
                        </div>
                        <div class="col-md-4">
                            <div id="Div_Tabla_Programa" style="width:100%;" class="highlights"></div>
                            <div id="div_programa" class="alert alert-danger alertas" style="text-align:center;">Seleccione Previsión</div>
                        </div>
                        <div class="col-md-4">
                            <div id="Div_Tabla_SubPrograma" style="width:100%;" class="highlights"></div>
                            <div id="div_subprograma" class="alert alert-danger alertas" style="text-align:center;">Seleccione Programa</div>
                        </div>
                    </div>    
                </div>  
            </div>

            <div class="row">
                <%--<div class="col-md">
                    <button id="Btn_Nuevo" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit">Nuevo <i class="fa fa-plus" aria-hidden="true"></i></button>
                </div>--%>
                <div class="col-md">
                    <button id="Btn_Guardar" class="btn btn-primary btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit">Guardar <i class="fa fa-save" aria-hidden="true"></i></button>
                </div>
                <%--<div class="col-md">
                    <button id="Btn_Modificar" class="btn btn-warning btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit">Modificar <i class="fa fa-edit" aria-hidden="true"></i></button>
                </div>--%>
                <div class="col-md">
                    <button id="Btn_Eliminar" class="btn btn-danger btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit">Eliminar <i class="fa fa-eraser" aria-hidden="true"></i></button>
                </div>
                <%--<div class="col-md">
                    <button id="Btn_Excel" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit">Excel <i class="fa fa-eject" aria-hidden="true"></i></button>
                </div>--%>
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>
    </div>
</asp:Content>
