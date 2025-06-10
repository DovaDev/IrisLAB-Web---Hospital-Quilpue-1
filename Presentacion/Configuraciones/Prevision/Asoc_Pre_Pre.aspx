<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Asoc_Pre_Pre.aspx.vb" Inherits="Presentacion.Asoc_Pre_Pre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        var Arrpos = [];
        var Arrpos2 = [];
        var ddlAño = "";
        var ddlPreve = "";
        var Mx_Pos = [];
        var Mx_Pos2 = [];
        var Mx_Pos3 = [];
        var Mx_Pos4 = [];
        var Val_pre = 0;
        var id_desc = 0;
        $(document).ready(function () {
            Llenar_Ddl_Año();
            Llenar_Ddl_Preve();
            Llenar_Ddl_Examen();
            $("#chkk").prop("checked", false);
            $("#txt_Suma").val("");
            $("#txt_Porce").val("");
            $("#btn_guardar").click(function () {
                Update_Precio();
            });
            $("#btn_eliminar").click(function () {
                Arrpos2.forEach(function (aaa) {
                    Mx_Pos4.push({
                        "ID_PRECIO": Mx_Dtt[aaa].ID_CF_PRECIO,
                        "AMB": 0
                    });
                });
                //console.log(Mx_Pos4);
                //console.log(Mx_Pos2);
                Elimina_Precio();
            });
            $("#btn_Exa").click(aa => {
                $("#Modal_Exa").modal();
            });
            $("#btn_nuevo").click(aa => {
                $("#ddl_Año").empty();
                $("#ddl_Preve").empty();
                $('#table_Modal').dataTable().fnDestroy();
                $("#table_Modal tbody").empty();
                $('#DataTable').dataTable().fnDestroy();
                $("#DataTable").empty();
                $("#txt_Suma").val("");
                $("#txt_Porce").val("");
                Llenar_Ddl_Año();
                Llenar_Ddl_Preve();
            });
            $("#ddl_Año, #ddl_Preve").change(function () {
                ddlAño = $("#ddl_Año").val();
                ddlPreve = $("#ddl_Preve").val();
                if (ddlAño != "Seleccione Año" && ddlPreve != "Seleccione Previsión") {
                    Mx_Pos = [];
                    Mx_Pos2 = [];
                    Ajax_DataTable();
                }
            });
            $("#txt_Suma").keyup((Me) => {
                let Sum_Reg = $(Me.currentTarget).val();
                let arrFound = Sum_Reg.match(/^-?[0-9]*$/g);
                let bolPos = (function () {
                    if (Sum_Reg.match(/^-/g) != null) {
                        return false;
                    } else {
                        return true;
                    }
                }());

                if (arrFound != null) {
                    Sum_Reg = arrFound[0];
                } else {
                    Sum_Reg = Sum_Reg.replace(/\D/gi, "");
                    if (bolPos == false) {
                        Sum_Reg = `-${Sum_Reg}`;
                    }
                }

                $(Me.currentTarget).val(Sum_Reg);
            });
            $("#txt_Porce").keyup((Me) => {
                let Sum_Reg = $(Me.currentTarget).val();
                let arrFound = Sum_Reg.match(/^-?[0-9]+(\.|,)(([0-9]*)$)/gi);
                let bolPos = (function () {
                    if (Sum_Reg.match(/^-/g) != null) {
                        return false;
                    } else {
                        return true;
                    }
                }());
                if (arrFound != null) {
                    Sum_Reg = arrFound[0];
                } else {
                    arrFound = Sum_Reg.match(/([0-9]|\.|,)/gi);

                    Sum_Reg = "";
                    let countDot = false;
                    if (arrFound != null) {
                        arrFound.forEach(lol => {
                            if (lol.match(/(\.|,)/g) != null) {
                                if (countDot == false) {
                                    Sum_Reg += lol;
                                    countDot = true;
                                }
                            } else {
                                Sum_Reg += lol;
                            }
                        }); 
                    }
                    else {
                        Sum_Reg = "";
                    }
                    if (bolPos == false) {
                        Sum_Reg = `-${Sum_Reg}`;
                    }
                }
                $(Me.currentTarget).val(Sum_Reg);
            });

        });
        var Mx_Ddl_Años = [{
            "ID_AÑO": "",
            "AÑO_COD": "",
            "AÑO_DESC": "",
            "ID_ESTADO": ""
        }];
        var Mx_Ddl_Preve = [{
            "ID_PREVE": "",
            "PREVE_COD": "",
            "PREVE_DESC": "",
            "ID_ESTADO": ""
        }];
        var Mx_Ddl_Exa = [{
            "ID_CODIGO_FONASA": 0,
            "CF_COD": "",
            "CF_DESC": ""
        }];
        var Mx_Dtt = [{
            "AÑO_DESC": "",
            "ID_PREVE": "",
            "ID_CODIGO_FONASA": "",
            "CF_PRECIO_AMB": "",
            "CF_PRECIO_HOS": "",
            "CF_DESC": "",
            "CF_COD": "",
            "ID_AÑO": "",
            "ID_CF_PRECIO": ""
        }];
        function Llenar_Ddl_Examen() {
            //Debug
            $.ajax({
                "type": "POST",
                "url": "Asoc_Pre_Pre.aspx/Llenar_Ddl_Examen",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_Ddl_Exa = data.d;

                },
                "error": data => {
                    //Debug
                }
            });
        }
        function Llenar_Ddl_Año() {
            //Debug
            $.ajax({
                "type": "POST",
                "url": "Asoc_Pre_Pre.aspx/Llenar_Ddl_Año",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_Ddl_Años = data.d;
                    Fill_Ddl_Años();
                },
                "error": data => {
                    //Debug
                }
            });
        }
        function Llenar_Ddl_Preve() {
            //Debug
            $.ajax({
                "type": "POST",
                "url": "Asoc_Pre_Pre.aspx/Llenar_Ddl_Preve",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_Ddl_Preve = data.d;
                    Fill_Ddl_Preve();
                },
                "error": data => {
                    //Debug
                }
            });
        }
        function Ajax_DataTable() {
            $("#chkk").prop("checked", false);
            modal_show();
            $("#Div_Table").empty();
            var Data_Param = JSON.stringify({
                "ID_AÑO": $("#ddl_Año").val(),
                "ID_PREVI": $("#ddl_Preve").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Asoc_Pre_Pre.aspx/Llenar_DataTable",
                "data": Data_Param,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;
                        Fill_Dtt();
                    } else {
                        $("#Div_Table").append("<h5>No se encontraron resultados.</h5>");
                        Hide_Modal();

                        //$("#DataTable tbody").empty();
                        //$("#lblerror").text("No se Encontraron Pacientes.").css("color", "red");
                    }
                },
                "error": function (response) {
                    Hide_Modal();
                    //var str_Error = "Error interno del Servidor";
                }
            });
        }
        function Update_Precio() {
            if (Mx_Pos.length > 0) {
                var Data_Param = JSON.stringify({
                    "Mx_Pos": Mx_Pos
                });
                $.ajax({
                    "type": "POST",
                    "url": "Asoc_Pre_Pre.aspx/Update_Precio",
                    "data": Data_Param,
                    "contentType": "application/json;  charset=utf-8",
                    "dataType": "json",
                    "success": data => {
                        //Debug
                        //console.log("UPDATE SUCCESS " + data.d);
                        $("#mdlNotif .modal-header h4").text("Cambios realizados correctamente");
                        $("#mdlNotif .modal-body p").html("Se actualizaron " + data.d + " precio(s) de exámenes de forma correcta");
                        $("#mdlNotif").modal();
                        Mx_Pos = [];
                        Ajax_DataTable();
                    },
                    "error": data => {
                        //Debug
                        //console.log("UPDATE ERROR "+data.d);
                        $("#mdlNotif .modal-header h4").text("Algo no ocurrio como esperabamos");
                        $("#mdlNotif .modal-body p").html("Intente nuevamente mas tarde.");
                        $("#mdlNotif").modal();
                    }
                });
            }
            else {
                $("#mdlNotif .modal-header h4").text("No hay exámenes con modificaciones");
                $("#mdlNotif .modal-body p").html("Por favor modifique exámenes.");
                $("#mdlNotif").modal();
            }

        }
        function Elimina_Precio() {
            if (Mx_Pos4.length > 0) {
                console.log(Mx_Pos4);
                var Data_Param = JSON.stringify({
                    "Mx_Pos": Mx_Pos4
                });
                $.ajax({
                    "type": "POST",
                    "url": "Asoc_Pre_Pre.aspx/Elimina_Precio",
                    "data": Data_Param,
                    "contentType": "application/json;  charset=utf-8",
                    "dataType": "json",
                    "success": data => {
                        //Debug
                        //console.log("UPDATE SUCCESS " + data.d);
                        $("#mdlNotif .modal-header h4").text("Cambios realizados correctamente");
                        $("#mdlNotif .modal-body p").html("Se eliminaron " + data.d + " precios de exámenes de forma correcta");
                        $("#mdlNotif").modal();
                        Mx_Pos4 = [];
                        Arrpos2 = [];
                        Ajax_DataTable();
                    },
                    "error": data => {
                        //Debug
                        //console.log("UPDATE ERROR "+data.d);
                        $("#mdlNotif .modal-header h4").text("Algo no ocurrio como esperabamos");
                        $("#mdlNotif .modal-body p").html("Intente nuevamente mas tarde.");
                        $("#mdlNotif").modal();
                    }
                });
            }
            else {
                $("#mdlNotif .modal-header h4").text("No hay exámenes seleccionados");
                $("#mdlNotif .modal-body p").html("Por favor seleccione.");
                $("#mdlNotif").modal();
            }

        }
        function Graba_Precio() {
            //console.log("AJAX UPDATE");
            //Debug

            var Data_Param = JSON.stringify({
                "Mx_Pos": Mx_Pos2
            });

            $.ajax({
                "type": "POST",
                "url": "Asoc_Pre_Pre.aspx/Graba_Precio",
                "data": Data_Param,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    Mx_Pos2 = [];
                    Arrpos = [];
                    //Debug
                    //console.log("UPDATE SUCCESS " + data.d);
                    //$("#mdlNotif .modal-header h4").text("Cambios realizados correctamente");
                    //$("#mdlNotif .modal-body p").html("Se actualizaron " + data.d + " precios de exámenes de forma correcta");
                    //$("#mdlNotif").modal();

                },
                "error": data => {
                    //Debug
                    //console.log("UPDATE ERROR "+data.d);
                    $("#mdlNotif .modal-header h4").text("Algo no ocurrio como esperabamos");
                    $("#mdlNotif .modal-body p").html("Intente nuevamente mas tarde.");
                    $("#mdlNotif").modal();
                }
            });
            $("#close_modal_btn").click();
            Ajax_DataTable();
        }
        function Fill_Ddl_Años() {
            Mx_Ddl_Años.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_AÑO
                    }
                ).text(aaa.AÑO_DESC).appendTo("#ddl_Año");
            });
        }
        function Fill_Ddl_Preve() {
            Mx_Ddl_Preve.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_PREVE
                    }
                ).text(aaa.PREVE_DESC).appendTo("#ddl_Preve");
            });
        }
        function Fill_Exa() {
            $('#table_Modal').dataTable().fnDestroy();
            //console.log("Fill exa");

            $("#table_Modal tbody").empty();
            $("#Modal_Exa .modal-footer").empty();
            var xx = 0;
            var i = 0;
            //console.log(Mx_Ddl_Exa);
            //console.log(Mx_Dtt);
            Mx_Ddl_Exa.forEach(aah => {
                Mx_Dtt.forEach(eeh => {
                    if (aah.ID_CODIGO_FONASA == eeh.ID_CODIGO_FONASA) {
                        xx = 1;
                        //console.log("xx = 1");
                    }
                });
                if (xx == 0) {
                    //console.log("xx = 0");
                    $("#table_Modal tbody").append(
                    $("<tr>", {
                        "data-pos": i,
                        "class": "manito"
                    }).attr("value", aah.ID_CODIGO_FONASA).append(
                    $("<td>").css("font-weight", "bold").text(i + 1),
                    $("<td>").text(aah.CF_COD),
                    $("<td>").text(aah.CF_DESC),
                    $("<td>").css("text-align", "center").append("<input type='checkbox' name='Cargarr' data-val='" + i + "'/>"))

                    );
                }
                else {
                    xx = 0;
                }
                i = i + 1;

            });
            $("#table_Modal").DataTable({
                "bSort": false,
                "iDisplayLength": 100,
                "info": false,
                "bPaginate": false,
                //"bFilter": false,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay coincidencias",
                    "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Buscar: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
            $("#Modal_Exa .modal-footer").append("<button type='button' class='btn btn-primary' id='btn_Cargarr'><i class='fa fa-plus mr-2'></i>Cargar</button>");
            $("#Modal_Exa .modal-footer").append("<button type='button' class='btn btn-danger' data-dismiss='modal' id='close_modal_btn'>Cerrar</button>");

            Click_Check_Add();

            $("#btn_Cargarr").click(aah=> {
                Arrpos.forEach(function (aaa) {
                    Mx_Pos2.push({
                        "ID_PREVI": $("#ddl_Preve").val(),
                        "ID_CF": Mx_Ddl_Exa[aaa].ID_CODIGO_FONASA,
                        "ID_AÑO": $("#ddl_Año").val(),
                        "V_AMB": 0
                    });
                });
                //console.log(Mx_Pos2);
                Graba_Precio();
            });

        }
        function Fill_Dtt() {
            //console.log("fill datatable");

            $("#Div_Table").append($("<table  id='DataTable' class='table table-hover table-striped table-iris'>"));
            $('#DataTable').append($("<thead>"));
            $("<tr>").append(
                $("<th>").text("#"),
                $("<th>").text("Código Fonasa"),
                $("<th>").text("Descripción"),
                $("<th>").text("Valor Original"),
                $("<th>").text("Valor Futuro"),
                $("<th>"),
                $("<th>").css("text-align", "center").text("Chk")
                ).appendTo($("#DataTable thead"));

            $('#DataTable').append($("<tbody>"));
            $('#DataTable').dataTable().fnDestroy();
            $("#DataTable tbody").empty();
            var i = 0;

            Mx_Dtt = Mx_Dtt.sort(function (a, b) { return a - b; });

            Mx_Dtt.forEach(aah => {
                $("<tr>", {
                    "data-pos": i,
                    "class": "manito"
                }).attr("value", aah.ID_CF_PRECIO).append(
                    $("<td>").css("font-weight", "bold").text(i + 1),
                    $("<td>").text(aah.CF_COD),
                    $("<td>").text(aah.CF_DESC),
                    $("<td>").text(aah.CF_PRECIO_AMB),
                    $("<td>").append(
                    "<input id='AMB" + i + "' class='form-control btn-sm' name='amb' data-toggle='tooltip' title='Para confirmar presione Enter' data-placement='right' />"),
                    $("<td>", { "id": "Est" + i, "name": "checkitoo" }),
                    $("<td>").css("text-align", "center").append("<input type='checkbox' name='Checkedd' data-val='" + i + "'/>")

                ).appendTo("#DataTable tbody");
                $("#AMB" + i).val(aah.CF_PRECIO_AMB);
                i += 1;
            });
            $('[data-toggle="tooltip"]').tooltip({
                animated: 'fade',
                trigger: 'click'
            });
            $('[data-toggle="tooltip"]').focusout(function (Me) {
                $(Me.currentTarget).tooltip("hide");
            });
            $("#DataTable").DataTable({
                "bSort": false,
                "iDisplayLength": 100,
                "info": false,
                "bPaginate": false,
                //"bFilter": false,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay coincidencias",
                    "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Buscar: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
            $("td[name='checkitoo']").css("width", "47px");
            $("#DataTable").removeClass("dataTable");
            Hide_Modal();

            Click_Check_Checkear();

            Fill_Exa();
            $("input[name='amb']").keypress(function (e) {
                var Val_reg = 0;
                Val_reg = $(this).val();
                Val_reg = Val_reg.replace(/\D/gi, "");
                $(this).val(Val_reg);

                var pos = $(this).parents("tr").attr("data-pos");
                if (e.which == 13) {
                    ////////////////////////////
                    if (Mx_Dtt[pos].CF_PRECIO_AMB == 0) {
                        console.log("cero Est"+pos);
                        Mx_Dtt[pos].CF_PRECIO_AMB = parseInt($(this).val());

                        $("#Est" + pos).empty();
                        $("#Est" + pos).append(
                            $("<i class='fa fa-check ml-3 text-success fa-2x'></i>")
                            );
                    }
                    if (Mx_Dtt.length >= parseInt(pos) + 1) {
                        //console.log("#AMB" + (parseInt(pos) + 1));
                        $("#AMB" + (parseInt(pos) + 1)).focus();
                    }
                }
                
            });
            $("input[name='amb']").change(function (Me) {
                var Val_reg = 0;
                Val_reg = $(this).val();
                Val_reg = Val_reg.replace(/\D/gi, "");
                $(this).val(Val_reg);

                var pos = $(Me.currentTarget).parents("tr").attr("data-pos");
                var pid = $(Me.currentTarget).parents("tr").attr("value");

                for (var i = 0; i < Mx_Pos.length ; i++) {
                    if (Mx_Pos[i]["ID_PRECIO"] === pid) {
                        Mx_Pos.splice(i, 1);
                    }
                }

                var pamb = $("#AMB" + pos).val();

                //console.log("change id parent: " + pid);
                Mx_Pos.push({
                    "ID_PRECIO": pid,
                    "AMB": pamb
                });
                //console.log(Mx_Pos);
                /////////////////////////////////
                /////////////////////////////////
                var pos = $(this).parents("tr").attr("data-pos");
                if (parseInt($("#AMB" + pos).val()) != parseInt(Mx_Dtt[pos].CF_PRECIO_AMB)) {
                    //console.log("igual");
                    $("#Est" + pos).empty();
                    $("#Est" + pos).append(
                        $("<i class='fa fa-check ml-3 text-success fa-2x'></i>")
                        );
                }
                else {
                    console.log("diferente");
                    $("#Est" + pos).empty();
                }
                //console.log(parseInt($("#AMB" + pos).val())+" "+parseInt(Mx_Dtt[pos].CF_PRECIO_AMB));
                
            });

            $("#txt_Suma, #txt_Porce").on('input', aaah => {
                Sum_Per();
            });
            $("#slt_Metod").change(aah => {
                Sum_Per();
            });
            $("#chk_tod").empty();
            $("#chk_tod").append("<label><input type='checkbox' id='chkk'> CHECK TODOS </label>");
            $("#chkk").click(aah => {
                console.log("click");
                $("input[name='Checkedd']").click();
            });
        }
        function Click_Check_Add() {
            $("input[name='Cargarr']").click(function () {
                if ($(this).is(":checked")) {
                    if (Arrpos.length != 0) {
                        var Pos = $(this).attr("data-val");
                        var var_conf = "";
                        Arrpos.forEach(function (aa) {
                            if (aa == Pos) { var_conf = 1; }
                        });
                        if (var_conf == 0) { Arrpos.push(Pos); }
                    }
                    else {
                        var Pos = $(this).attr("data-val");
                        Arrpos.push(Pos);
                    }
                }
                else {
                    var Pos = $(this).attr("data-val");
                    var index = Arrpos.indexOf(Pos);
                    if (index > -1) { Arrpos.splice(index, 1); }
                }
                //ORDENAR ARRAY
                Arrpos = Arrpos.sort(function (a, b) { return a - b; });
                //console.log("AGREGAR: " + Arrpos);
            });
        }
        function Click_Check_Checkear() {
            $("input[name='Checkedd']").click(function () {
                if ($(this).is(":checked")) {
                    if (Arrpos2.length != 0) {
                        var Posxx = $(this).attr("data-val");
                        var var_confxx = "";
                        Arrpos2.forEach(function (aa) {
                            if (aa == Posxx) { var_confxx = 1; }
                        });
                        if (var_confxx == 0) { Arrpos2.push(Posxx); }
                    }
                    else {
                        var Posxx = $(this).attr("data-val");
                        Arrpos2.push(Posxx);
                    }
                }
                else {
                    var Posxx = $(this).attr("data-val");
                    var index = Arrpos2.indexOf(Posxx);
                    if (index > -1) { Arrpos2.splice(index, 1); }
                }
                //ORDENAR ARRAY
                Arrpos2 = Arrpos2.sort(function (a, b) { return a - b; });
                //console.log("CHECKEAR: " + Arrpos2);
            });
        }
        function Sum_Per() {
            var dec = 0;
            //SUMA Y PORCENTAJE
            if ($("#txt_Suma").val() != "" && $("#txt_Porce").val() != "" && Arrpos2.length > 0 ) {
                id_desc = 3;
                //PRIMERO PORCENTAJE
                if ($("#slt_Metod").val() == 0 && $("#txt_Porce").val() != "-" && $("#txt_Suma").val() != "-") {

                    Arrpos2.forEach(function (aaa) {
                        var M_min;
                        var Procc;
                        var porcee_ = $("#txt_Porce").val();
                        Procc = $("#txt_Porce").val();
                        Val_pre = Procc;
                        M_min = Val_pre.match(/^-/g);
                        Val_pre.replace("-", "");
                        porcee_ = porcee_.replace(",", ".");
                        var summ_ = $("#txt_Suma").val();
                        var tott_ = 0;

                  
                        porcee_ = parseFloat(porcee_) / 100;
                        porcee_ = parseFloat(Mx_Dtt[aaa].CF_PRECIO_AMB) * porcee_;

                        if (M_min != null) {
                            if (parseFloat(Procc) >= -100) {
                                tott_ = parseFloat(parseInt(Mx_Dtt[aaa].CF_PRECIO_AMB) + parseInt(porcee_));
                                tott_ = round(tott_ + parseInt(summ_), 0);
                                if (tott_ < 0) {
                                    tott_ = 0;
                                    $("#AMB" + aaa).val(round(tott_, 0));
                                } else {
                                    $("#AMB" + aaa).val(round(tott_, 0));
                                }
                                console.log(tott_);
                                $("#AMB" + aaa).change();
                            }
                            else {
                                $("#AMB" + aaa).val(0);
                                $("#AMB" + aaa).change();
                            }

                        }
                        else {
                            tott_ = parseFloat(parseInt(Mx_Dtt[aaa].CF_PRECIO_AMB) + parseInt(porcee_));
                            tott_ = round(tott_ + parseInt(summ_), 0);
                            if (tott_ < 0) {
                                tott_ = 0;
                                $("#AMB" + aaa).val(round(tott_, 0));
                            } else {
                                $("#AMB" + aaa).val(round(tott_, 0));
                            }
                            console.log(tott_);
                            $("#AMB" + aaa).change();
                            
                        }

                        
                    });
                }
                    //PRIMERO SUMA
                else if ($("#slt_Metod").val() == 1 && $("#txt_Porce").val() != "-" && $("#txt_Suma").val() != "-") {

                    Arrpos2.forEach(function (aaa) {
                        var M_min;
                        var Procc;
                        var summ_ = $("#txt_Suma").val();
                        var porcee_ = $("#txt_Porce").val();
                        Procc = $("#txt_Porce").val();
                        Val_pre = Procc;
                        M_min = Val_pre.match(/^-/g);
                        Val_pre.replace("-", "");
                        porcee_ = porcee_.replace(",", ".");
                        var tott_ = 0;
                        
                        summ_ = parseInt(summ_) + Mx_Dtt[aaa].CF_PRECIO_AMB;
                        porcee_ = parseFloat(porcee_) / 100;
                        porcee_ = parseFloat(summ_) * porcee_;

                        if (M_min != null) {
                            if (parseFloat(Procc) >= -100) {
                                tott_ = parseFloat(parseInt(summ_) + parseFloat(porcee_));

                                if (tott_ < 0) {
                                    tott_ = 0;
                                    $("#AMB" + aaa).val(round(tott_, 0));
                                } else {
                                    $("#AMB" + aaa).val(round(tott_, 0));
                                }
                                console.log(tott_);
                                $("#AMB" + aaa).change();
                            }
                            else {
                                $("#AMB" + aaa).val(0);
                                $("#AMB" + aaa).change();
                            }

                        }
                        else {
                            tott_ = parseFloat(parseInt(summ_) + parseFloat(porcee_));
                            if (tott_ < 0) {
                                tott_ = 0;
                                $("#AMB" + aaa).val(round(tott_, 0));
                            } else {
                                $("#AMB" + aaa).val(round(tott_, 0));
                            }
                            $("#AMB" + aaa).change();
                        }
                        

                        
                    });
                }
            }
                //SOLO SUMA
            else if ($("#txt_Suma").val() != "" && $("#txt_Porce").val() == "" && Arrpos2.length > 0 && $("#txt_Suma").val() != "-") {
                var Countt = 0;
                var tott = 0;
                Arrpos2.forEach(function (aaa) {
                    Mx_Pos.forEach(function (bbb) {
                        if ($("#AMB" + aaa).parents("tr").attr("value") == bbb.ID_PRECIO) {
                            Countt = 1;
                        }
                    });
                    if (Countt == 1) {
                        $("#AMB" + aaa).val(Mx_Dtt[aaa].CF_PRECIO_AMB);
                        Countt = 0;
                    }

                });

                Val_pre = $("#txt_Suma").val();
                Arrpos2.forEach(function (aaa) {
                    
                    //console.log(Mx_Dtt[aaa].CF_PRECIO_AMB + parseInt(Val_pre));
                    tott = round(Mx_Dtt[aaa].CF_PRECIO_AMB + parseInt(Val_pre), 0);
                    console.log(tott);
                    if (tott < 0) {
                        tott = 0;
                        $("#AMB" + aaa).val(tott);
                    } else {
                        $("#AMB" + aaa).val(tott);
                    }
                    
                    $("#AMB" + aaa).change();
                });

            }
                //SOLO PORCENTAJE
            else if ($("#txt_Porce").val() != "" && $("#txt_Suma").val() == "" && Arrpos2.length > 0 && $("#txt_Porce").val() != "0" && $("#txt_Porce").val() != "-") {
                id_desc = 2;
                var Countt = 0;
                var Val_Div = 0;
                var Val_Por = 0;
                var M_min;
                var Procc;
                Procc = $("#txt_Porce").val();
                Val_pre = Procc;
                M_min = Val_pre.match(/^-/g);
                Val_pre.replace("-", "");
                Val_pre = Val_pre.replace(",", ".");
                Arrpos2.forEach(function (aaa) {
                   
                    Var_Summ = 0;
                    Val_Por = parseFloat(Val_pre) / 100;
                    Val_Por = parseInt(Mx_Dtt[aaa].CF_PRECIO_AMB) * Val_Por;
                    if (M_min != null) {
                        if (parseFloat(Procc) >= -100) {
                            console.log("mas de -100 " + Val_Por);
                            $("#AMB" + aaa).val(round(parseInt(Mx_Dtt[aaa].CF_PRECIO_AMB) + parseFloat(Val_Por), 0));
                        }
                        else {
                            console.log("menos de -100");
                            $("#AMB" + aaa).val(0);
                        }
                    }
                    else {
                        $("#AMB" + aaa).val(round(parseInt(Mx_Dtt[aaa].CF_PRECIO_AMB) + parseFloat(Val_Por), 0));
                    }
                    
                    $("#AMB" + aaa).change();

                });
            }
                // VALOR ORIGINAL
            else {
                Arrpos2.forEach(function (aaa) {

                    $("#AMB" + aaa).val(Mx_Dtt[aaa].CF_PRECIO_AMB);
                    $("#AMB" + aaa).change();

                });
            }
        }
        function round(num, decimales) {

            var signo = (num >= 0 ? 1 : -1);
            num = num * signo;
            if (decimales === 0) //con 0 decimales
                return signo * Math.round(num);
            // round(x * 10 ^ decimales)
            num = num.toString().split('e');
            num = Math.round(+(num[0] + 'e' + (num[1] ? (+num[1] + decimales) : decimales)));
            // x * 10 ^ (-decimales)
            num = num.toString().split('e');
            return signo * (num[0] + 'e' + (num[1] ? (+num[1] - decimales) : -decimales));
        }
    </script>
    <div id="Modal_Exa" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Listado de Examenes</h4>
                </div>
                <div class="modal-body" style="max-height: 75vh; overflow: auto">
                    <table class="table table-hover table-striped table-iris" id="table_Modal">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Código</th>
                                <th>Descripción</th>
                                <th style="text-align: center">Cargar</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
    <div class="card mb-3 border-bar">
        <div class="card-header bg-bar">
            <h5 class="text-center mb-3">Asociar Precios - Previsión</h5>
        </div>
        <div class="card-body">
            <div class="row" style="margin-top: 5px;">
                <br />
                <div class="col-md-1">
                    <label for="ddl_Año">Año:</label>
                </div>
                <div class="col-md-4">
                    <select id="ddl_Año" class="form-control mb-3">
                        <option>Seleccione Año</option>
                    </select>
                </div>
                <div class="col-md-1">
                    <label for="ddl_Preve">Previsión:</label>
                </div>
                <div class="col-md-4">
                    <select id="ddl_Preve" class="form-control mb-3 btn-sm">
                        <option>Seleccione Previsión</option>
                    </select>
                </div>
                <div class="col-md-2">
                    <button type="button" id="btn_Exa" class="btn btn-buscar"><i class="fa fa-search mr-2"></i>Examen</button>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <label>Suma</label>
                </div>
                <div class="col-md">
                    <input class="form-control" id="txt_Suma" />
                </div>
                <div class="col-md-1">
                    <label>Porcentaje</label>
                </div>
                <div class="col-md">
                    <input class="form-control" id="txt_Porce" step=".01" />
                </div>
                <div class="col-md-1">
                    <label>Método</label>
                </div>
                <div class="col-md-2">
                    <select class="form-control btn-sm" id="slt_Metod">
                        <option value="0">Porcentaje Primero</option>
                        <option value="1">Suma Primero</option>
                    </select>
                </div>
                <div class="col-md-2" id="chk_tod">
                </div>
            </div>
            <hr />
            <div id="Div_Table" style="max-height: 65vh; overflow: auto"></div>
            <div class="row" style="margin-bottom: 2px;">
                <div class="col-md-3">
                    <button type="button" class="btn btn-info btn-block mt-3 btn-sm" id="btn_nuevo"><i class="fa fa-plus mr-2"></i>Nuevo</button>
                </div>
                <div class="col-md-3">
                    <button type="button" class="btn btn-primary btn-block mt-3 btn-sm" id="btn_guardar"><i class="fa fa-save mr-2"></i>Guardar</button>
                </div>
                <div class="col-md-3">
                    <button type="button" class="btn btn-danger btn-block mt-3 btn-sm" id="btn_eliminar"><i class="fa fa-remove mr-2"></i>Eliminar</button>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
