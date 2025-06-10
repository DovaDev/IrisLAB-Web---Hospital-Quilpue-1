<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Indica_Tiempo_Respuesta.aspx.vb" Inherits="Presentacion.Indica_Tiempo_Respuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>
        $(Document).ready(function () {
            $("#Id_Conte").hide();

            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input").val(dateNow);
            $('#Txt_Date01').datetimepicker(
                {
                    debug: true,
                    icons: {
                        previous: 'fa fa-arrow-left',
                        next: 'fa fa-arrow-right'
                    },
                    format: 'dd-mm-yyyy',
                    language: 'es',
                    weekStart: 1,
                    autoclose: true,
                    minDate: Date.now(),
                    minView: 2
                }
            );

            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date02 input").val(dateNow);
            $('#Txt_Date02').datetimepicker(
                {
                    debug: true,
                    icons: {
                        previous: 'fa fa-arrow-left',
                        next: 'fa fa-arrow-right'
                    },
                    format: 'dd-mm-yyyy',
                    language: 'es',
                    weekStart: 1,
                    autoclose: true,
                    minDate: Date.now(),
                    minView: 2
                }
            );

            // Llenar DDLS
            Ajax_LugarTM();
            Ajax_Prevision();
            Ajax_Orden_Ate();
            Ajax_Seccion();

            //$("#Btn_Buscar").click(function () {
            //    $("#Div_Tabla").empty();
            //    Ajax_DataTable();
            //});
            //$("#Btn_Excel").click(function () {
            //    Ajax_Excel();
            //});
            $("#Btn_Buscar").click(function () {
                $("#Div_Tabla").empty();
                Ajax_DataTable();
            });
            $("#Btn_Excel").click(function () {
                Ajax_Excel();
            });
        });
        function Ajax_Redirect(id) {
            var loc = location.origin;
            window.open(loc + "/Buscar_Ate/Atencion_Det.aspx?ID_ATE=" + id);
        }
        //------------------------------------------------ AJAX DDL LUGAR DE TM -------------------------------------------|
        var Mx_Dtt_LugarTM = [{
            "ID_ESTADO": 0,
            "PROC_DESC": 0,
            "PROC_COD": 0,
            "ID_PROCEDENCIA": 0
        }];
        function Ajax_LugarTM() {
            //modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Indica_Tiempo_Respuesta.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_LugarTM = json_receiver;
                        Fill_Ddl_LugarTM();
                        //Hide_Modal();
                    } else {
                        //Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.ExceptionType + "\n \n";
                    str_Error = response.Message;
                    alert(str_Error);
                }
            });
        }
        //------------------------------------------------ AJAX DDL ORDEN ATE -------------------------------------------|
        var Mx_Orden_Ate = [{
            "ID_ORDEN": 0,
            "ORD_COD": 0,
            "ORD_DESC": 0,
            "ID_ESTADO": 0
        }];
        function Ajax_Orden_Ate() {
            //modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Indica_Tiempo_Respuesta.aspx/Llenar_Ddl_Orden_Ate",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Orden_Ate = json_receiver;
                        Fill_Ddl_Orden_Ate();
                        // Hide_Modal();

                    } else {

                        // Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.ExceptionType + "\n \n";
                    str_Error = response.Message;
                    alert(str_Error);
                }
            });
        }
        //------------------------------------------------ AJAX DDL PREVISION -------------------------------------------|
        var Mx_Prevision = [{
            "ID_PREVE": 0,
            "PREVE_COD": 0,
            "PREVE_DESC": 0,
            "ID_ESTADO": 0
        }];
        function Ajax_Prevision() {
            //modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Indica_Tiempo_Respuesta.aspx/Llenar_Ddl_Prevision",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Prevision = json_receiver;
                        Fill_Ddl_Prevision();
                        //Hide_Modal();

                    } else {

                        //Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.ExceptionType + "\n \n";
                    str_Error = response.Message;
                    alert(str_Error);
                }
            });
        }
        //------------------------------------------------ AJAX DDL SECCION -------------------------------------------|
        var Mx_Seccion = [{
            "ID_SECCION": 0,
            "SECC_COD": 0,
            "SECC_DESC": 0,
            "ID_ESTADO": 0
        }];
        function Ajax_Seccion() {
            //modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Indica_Tiempo_Respuesta.aspx/Llenar_Ddl_Seccion",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Seccion = json_receiver;
                        Fill_Ddl_Seccion();
                        //Hide_Modal();

                    } else {

                        //Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.ExceptionType + "\n \n";
                    str_Error = response.Message;
                    alert(str_Error);

                }
            });
        }
        function Fill_Ddl_LugarTM() {
            $("#Ddl_LugarTM").empty();
            var procee = Galletas.getGalleta("USU_ID_PROC");
            if (procee == 0) {
                $("<option>",
                {
                    "value": "0"
                }
                ).text("Todos").appendTo("#Ddl_LugarTM");
                Mx_Dtt_LugarTM.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                });
            }
            else {
                Mx_Dtt_LugarTM.forEach(aaa => {
                    if (aaa.ID_PROCEDENCIA == procee) {
                        $("<option>",
                          {
                              "value": aaa.ID_PROCEDENCIA
                          }
                       ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                    }
                });
            }
        }
        //Llenar DropDownList Tipo de Atención
        function Fill_Ddl_Orden_Ate() {

            $("#Ddl_Orden_Ate").empty();
            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Orden_Ate");
            Mx_Orden_Ate.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_ORDEN
                    }
                ).text(aaa.ORD_DESC).appendTo("#Ddl_Orden_Ate");
            });
        }

        function Fill_Ddl_Prevision() {

            $("#Ddl_Prevision").empty();
            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Prevision");
            Mx_Prevision.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_PREVE
                    }
                ).text(aaa.PREVE_DESC).appendTo("#Ddl_Prevision");
            });
        }
        function Fill_Ddl_Seccion() {

            $("#Ddl_Seccion").empty();
            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Seccion");
            Mx_Seccion.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_SECCION
                    }
                ).text(aaa.SECC_DESC).appendTo("#Ddl_Seccion");
            });
        }
        /////////////////////// DATATABLE
        var Mx_Dtt = [
           {
               "ATE_NUM": 0,
               "ATE_AÑO": 0,
               "ID_ATENCION": 0,
               "ATE_FECHA": 0,
               "PAC_NOMBRE": 0,
               "PAC_APELLIDO": 0,
               "PAC_RUT": 0,
               "ID_RECEP_ETI": 0,
               "ID_RECEP_ETI_DERIVA": 0,
               "ID_RECEP_ETI_RECHAZO": 0,
               "PROC_DESC": 0,
               "T_MUESTRA_DESC": 0,
               "CB_DESC": 0              
           }
        ];
        function Ajax_DataTable() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_CF": $("#Ddl_LugarTM").val(),
                "ID_FP": 0,
                "ID_PREV": $("#Ddl_Prevision").val(),
                "ID_IE": $("#Ddl_Orden_Ate").val(),
                "ID_SECC": $("#Ddl_Seccion").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Indica_Tiempo_Respuesta.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    console.log("success");
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;
                        $("#Div_Tabla").empty();

                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].ATE_FECHA = Date_Change;
                        }

                        //console.log(Mx_Dtt);
                        Fill_DataTable();
                        Hide_Modal();

                        $("#Id_Conte").show();
                    } else {

                        Hide_Modal();
                        $("#lblTotal").text("0");
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                        $("#Id_Conte").hide();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    console.log("error");
                    Hide_Modal();
                    var str_Error = response.ExceptionType + "\n \n";
                    str_Error = response.Message;
                    alert(str_Error);
                }
            });
        }
        function Fill_DataTable() {
            var dif_hora = 0;
            var dif_minutos = 0;
            var fecha_a;
            var fecha_b;
            var dif_apro;
            var cant_ate = 0, cant_exa = 0, cump_si = 0, cump_no = 0, cont = 1;
            //console.log(Mx_Dtt);
            ///////////////////////////
            Si_Recep_Eti = 0, Si_Deriva_Eti = 0, Si_Rechazo_Eti = 0, No_Recep_Eti = 0, No_Deriva_Eti = 0, No_Rechazo_Eti = 0, last_ate = 0, tot_ate = 0;
            //console.log(Mx_Dtt);
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
            $("#DataTable thead").attr("class", "cabezera");
            $("#DataTable thead").append(
                $("<tr>").append(
                $("<th>", { "class": "textoReducido" }).text("#"),
                $("<th>", { "class": "textoReducido" }).text("N°Ate."),
                $("<th>", { "class": "textoReducido" }).text("Nombre"),
                $("<th>", { "class": "textoReducido" }).text("RUT"),
                $("<th>", { "class": "textoReducido" }).text("Edad"),
                $("<th>", { "class": "textoReducido" }).text("Lugar TM"),
                $("<th>", { "class": "textoReducido" }).text("Examen"),
                $("<th>", { "class": "textoReducido" }).text("Fecha Creación"),
                $("<th>", { "class": "textoReducido" }).text("Fecha Valida."),
                $("<th>", { "class": "textoReducido" }).text("Max"),
                $("<th>", { "class": "textoReducido" }).text("Diferencia"),
                $("<th>", { "class": "textoReducido" }).text("Aprobo")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {

                if (Mx_Dtt[i].ATE_DET_V_ID_ESTADO == 6 || Mx_Dtt[i].ATE_DET_V_ID_ESTADO == 14) {
                    cant_exa = cant_exa + 1;
                    if (last_ate != Mx_Dtt[i].ID_ATENCION) {
                        tot_ate += 1;
                        last_ate = Mx_Dtt[i].ID_ATENCION;
                    }
                    if (i != 0)
                    { var ai = i - 1; }
                    else
                    { var ai = 0; }
                    $("#DataTable tbody").append(

                        $("<tr>", {
                            "onclick": `Ajax_Redirect("` + Mx_Dtt[i].ENCRYPTED_ID + `")`,
                            "class": "manito"
                        }).attr("value", Mx_Dtt[i].ENCRYPTED_ID).append(
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(cont),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ATE_NUM),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {

                                if (i == 0 || Mx_Dtt[i].ATE_NUM != Mx_Dtt[ai].ATE_NUM) {
                                    if (Mx_Dtt[i].CF_DESC == "VIH") {
                                        var vNom, vArrApe, vApe, vRut, vFnac;
                                        vNom = Mx_Dtt[i].PAC_NOMBRE.substr(0, 1);
                                        if (Mx_Dtt[i].PAC_APELLIDO != null) {
                                            vApe = Mx_Dtt[i].PAC_APELLIDO.substr(0, 1);
                                        }
                                        else {
                                            vApe = "#";
                                        }
                                        var vFnac_Split = moment(Mx_Dtt[i].PAC_FNAC).format("DD-MM-YYYY").split("-");
                                        vFnac = vFnac_Split[0] + vFnac_Split[1] + vFnac_Split[2].substr(2, 4);

                                        if (Mx_Dtt[i].PAC_RUT != null && Mx_Dtt[i].PAC_RUT != "") {
                                            vRut = Mx_Dtt[i].PAC_RUT.substr(Mx_Dtt[i].PAC_RUT.length - 5);
                                        }
                                        else {
                                            vRut = "ABC-D";
                                        }
                                        /////////////////////////////////////
                                        return String(vNom + vApe + vFnac + vRut);
                                        //console.log(vNom + vApe + vFnac + vRut);
                                    }
                                    else {
                                        return String(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO);
                                    }
                                }
                            }),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {

                                if (i == 0 || Mx_Dtt[i].ATE_NUM != Mx_Dtt[ai].ATE_NUM) {
                                    return String(Mx_Dtt[i].PAC_RUT);
                                }
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {

                                if (i == 0 || Mx_Dtt[i].ATE_NUM != Mx_Dtt[ai].ATE_NUM) {
                                    return String(Mx_Dtt[i].ATE_AÑO);
                                }
                            }),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {

                                if (i == 0 || Mx_Dtt[i].ATE_NUM != Mx_Dtt[ai].ATE_NUM) {
                                    return String(Mx_Dtt[i].PROC_DESC);
                                }
                            }),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CF_DESC),
                            //FECHA CREA
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {

                                fecha_a = moment(Mx_Dtt[i].ATE_FECHA).format("DD-MM-YYYY kk:mm:ss");

                                return String(fecha_a);

                            }),
                            //FECHA VALIDA
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {

                                fecha_b = moment(Mx_Dtt[i].ATE_DET_V_FECHA).format("DD-MM-YYYY kk:mm:ss");

                                return String(fecha_b);
                            }),
                            //MAX
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                                if (Mx_Dtt[i].CF_TIEMPO_NORMAL != null) {

                                    dif_hora = Mx_Dtt[i].CF_TIEMPO_NORMAL;

                                    return String(Mx_Dtt[i].CF_TIEMPO_NORMAL + " Hrs");
                                }
                                else {
                                    dif_hora = 24;
                                    return String(dif_hora + " Hrs");
                                }
                            }),
                            //DIFERENCIA
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                                //console.log(fecha_a + " " + fecha_b);
                                dif_minutos = moment(Mx_Dtt[i].ATE_DET_V_FECHA).diff(moment(Mx_Dtt[i].ATE_FECHA), "seconds");

                                dif_hora = ((dif_hora * 60) * 60) - 1;
                                if (dif_minutos <= dif_hora && dif_minutos != "0") {
                                    dif_apro = "SI";
                                    cump_si = cump_si + 1;
                                }
                                else if (dif_minutos > dif_hora && dif_minutos != "0") {
                                    dif_apro = "NO";
                                    cump_no = cump_no + 1;
                                }
                                else {
                                    dif_apro = "";
                                }
                                //console.log(dif_minutos + " " + dif_hora + " " + dif_apro);

                                var sec_num = parseInt(dif_minutos);
                                var hours = Math.floor(sec_num / 3600);
                                var minutes = Math.floor((sec_num - (hours * 3600)) / 60);
                                var seconds = sec_num - (hours * 3600) - (minutes * 60);

                                if (hours < 10) { hours = "0" + hours; }
                                if (minutes < 10) { minutes = "0" + minutes; }
                                if (seconds < 10) { seconds = "0" + seconds; }
                                return hours + ':' + minutes + ':' + seconds;
                            }).css("background-color", "#fdff89"),
                            //APROABDO
                            $("<td>").css("text-align", "center").text(function () {
                                if (dif_apro == "SI") {
                                    $(this).css("background-color", "#c4ff9b");
                                    return dif_apro;
                                }
                                else if (dif_apro == "NO") {
                                    $(this).css("background-color", "#ff9191");
                                    return dif_apro;
                                }
                                else {
                                    $(this).css("background-color", "#cffcf5");
                                    return dif_apro;
                                }
                            })
                      )
                    );
                    cont = cont + 1;
                }
            }
            $("#lblTotal").text(cant_exa);
            $("#lbl_ate_sum").text(tot_ate);
            $("#lbl_exa_sum").text(cant_exa);
            $("#lbl_recep_si_sum").text(cump_si);
            $("#lbl_recep_no_sum").text(cump_no);
            var cump_si_pc, cump_no_pc;
            if (cump_si != 0) {
                cump_si_pc = (cump_si * 100) / cant_exa;
                cump_si_pc = Math.round(cump_si_pc * 100) / 100;
            }
            else {
                cump_si_pc = "0";
            }
            if (cump_no != 0) {
                cump_no_pc = (cump_no * 100) / cant_exa;
                cump_no_pc = Math.round(cump_no_pc * 100) / 100;
            }
            else {
                cump_no_pc = "0";
            }
            $("#lbl_recep_si_sum_pc").text(cump_si_pc + "%");
            $("#lbl_recep_no_sum_pc").text(cump_no_pc + "%");
        }

        var Mx_Dtt_Excel = [{
            "urls": ""
        }];
        function Ajax_Excel() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_CF": $("#Ddl_LugarTM").val(),
                "ID_FP": 0,
                "ID_PREV": $("#Ddl_Prevision").val(),
                "ID_IE": $("#Ddl_Orden_Ate").val(),
                "ID_SECC": $("#Ddl_Seccion").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Indica_Tiempo_Respuesta.aspx/Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        //Mx_Dtt_Excel = JSON.parse(json_receiver);
                        window.open(json_receiver, 'Download');
                        Hide_Modal();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                        $("#Id_Conte").hide();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.ExceptionType + "\n \n";
                    str_Error = response.Message;
                    alert(str_Error);

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

        .cabezera {
            background: #46963f;
            color: white;
        }

        .cabezera2 {
            background: #081f44;
            color: white;
        }

        .textoReducido {
            font-size: 12px;
        }

        .mayus {
            text-transform: uppercase;
        }

        .highlights {
            width: 90%;
            height: 404px; /* Ancho y alto fijo */
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
                <div class="card-header bg-bar p-1">
                    <h5 style="text-align: center; padding: 5px;">
                        <i class="fa fa-edit"></i>
                        Indicadores de Urgencias, Tiempo de Respuesta y Secciones
                    </h5>
                </div>
                <div class="card-body">
                    <div class="row mb-3 p-3" style="margin-left: 2px; margin-right: 2px;">
                        <div class="col-md">
                            <label for="fecha">Desde:</label>
                            <div class='input-group date' id='Txt_Date01'>
                                <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Desde..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md">
                            <label for="fecha">Hasta:</label>
                            <div class='input-group date' id='Txt_Date02'>
                                <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Desde..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md">
                            <label for="Ddl_LugarTM">Lugar TM:</label>
                            <select id="Ddl_LugarTM" class="form-control">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-md">
                            <label for="Ddl_Orden_Ate">Orden de Atención:</label>
                            <select id="Ddl_Orden_Ate" class="form-control">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-md">
                            <label for="Ddl_Prevision">Previsión:</label>
                            <select id="Ddl_Prevision" class="form-control">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="col-md">
                            <label for="Ddl_Seccion">Sección:</label>
                            <select id="Ddl_Seccion" class="form-control">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 2px; margin-right: 2px;">
                        <div class="col-md">
                            <button id="Btn_Buscar" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                        </div>
                        <div class="col-md">
                            <button id="Btn_Excel" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                        </div>
                    </div>
                    <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
                    <div class="row" id="Id_Conte">
                        <div class="col-md-12 mt-3" id="Paciente">
                            <h5 style="text-align: center;"><i class="fa fa-fw fa-list"></i>Lista de Examenes</h5>
                            <div class="row" style="font-size: 15px;">
                                <div class="col-md-2">
                                    <label>TOTAL: </label>
                                    <b>
                                        <label id="lblTotal" class="text-primary">0</label></b>
                                </div>
                            </div>
                        </div>
                        <div id="Div_Tabla" style="width: 100%; max-height: 55vh; overflow: auto" class="p-3 mb-3"></div>
                        <div id="Div_Stats" style="width: 100%;">
                            <div class="row">
                                <div class="col-lg-4"></div>
                                <div class="col-lg-4 border-bar p-2 m-3" style="border: solid 1px">
                                    <div class="row">
                                        <div class="col-4">Descripción</div>
                                        <div class="col-4">Total</div>
                                        <div class="col-4">Porcentaje</div>

                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-4">Atenciones</div>
                                        <div class="col-4">
                                            <label id="lbl_ate_sum"></label>
                                        </div>
                                        <div class="col-4">
                                            <label id="lbl_ate_sum_pc">100%</label>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-4">Examenes</div>
                                        <div class="col-4">
                                            <label id="lbl_exa_sum"></label>
                                        </div>
                                        <div class="col-4">
                                            <label id="lbl_exa_sum_pc">100%</label>
                                        </div>

                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-4">Cumplio [SI]</div>
                                        <div class="col-4">
                                            <label id="lbl_recep_si_sum"></label>
                                        </div>
                                        <div class="col-4">
                                            <label id="lbl_recep_si_sum_pc"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-4">Cumplio [NO]</div>
                                        <div class="col-4">
                                            <label id="lbl_recep_no_sum"></label>
                                        </div>
                                        <div class="col-4">
                                            <label id="lbl_recep_no_sum_pc"></label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-4"></div>
                            </div>
                        </div>
               
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
