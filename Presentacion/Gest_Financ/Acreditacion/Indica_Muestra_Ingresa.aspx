<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Indica_Muestra_Ingresa.aspx.vb" Inherits="Presentacion.Indica_Muestra_Ingresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>
        var Si_Recep_Eti = 0, Si_Deriva_Eti = 0, Si_Rechazo_Eti = 0, No_Recep_Eti = 0, No_Deriva_Eti = 0, No_Rechazo_Eti = 0, last_ate = 0, tot_ate = 0;
        var tot = 0, Si_Recep_Eti_pc = 0, No_Recep_Eti_pc = 0, Si_Deriva_Eti_pc = 0, No_Deriva_Eti_pc = 0, Si_Rechazo_Eti_pc = 0, No_Rechazo_Eti_pc = 0;

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
            Ajax_Prevision();
            Ajax_Orden_Ate();
            Ajax_LugarTM();

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
                "url": "Indica_Muestra_Ingresa.aspx/Llenar_Ddl_LugarTM",
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
                "url": "Indica_Muestra_Ingresa.aspx/Llenar_Ddl_Orden_Ate",
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
                "url": "Indica_Muestra_Ingresa.aspx/Llenar_Ddl_Prevision",
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
        /////////////////////// DATATABLE
        var Mx_Dtt = [
           {
               "ID_T_MUESTRA": 0,
               "ATE_NUM": 0,
               "T_MUESTRA_DESC": 0,
               "CB_DESC": 0,
               "Expr1": 0,
               "ID_ATENCION": 0,
               "GMUE_DESC": 0,
               "ATE_FECHA": 0,
               "ID_RECEP_ETI": 0,
               "ID_RECEP_ETI_DERIVA": 0,
               "ID_RECEP_ETI_RECHAZO": 0,
               "PROC_DESC": 0,
               "PREVE_DESC": 0,
               "PAC_NOMBRE": 0,
               "PAC_APELLIDO": 0,
               "PAC_RUT": 0,
               "ID_PACIENTE": 0,
               "ATE_AÑO": 0,
               "ATE_MES": 0,
               "ATE_DIA": 0,
               "ORD_DESC": 0
           }
        ];
        function Ajax_DataTable() {
            modal_show();
            var Data_Par = JSON.stringify({
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PREV": $("#Ddl_Prevision").val(),
                "ID_PROC": $("#Ddl_LugarTM").val(),
                "ID_IE": $("#Ddl_Orden_Ate").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Indica_Muestra_Ingresa.aspx/Llenar_DataTable",
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

                        $("#lblTotal").text(Mx_Dtt.length);

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
                $("<th>", { "class": "textoReducido" }).text("Fecha"),
                $("<th>", { "class": "textoReducido" }).text("Lugar TM"),
                $("<th>", { "class": "textoReducido" }).text("Tipo Etiqueta"),
                $("<th>", { "class": "textoReducido" }).text("CB"),
                $("<th>", { "class": "textoReducido" }).text("Recep."),
                $("<th>", { "class": "textoReducido" }).text("Derivado"),
                $("<th>", { "class": "textoReducido" }).text("Rechazo")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
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
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (i == 0 || Mx_Dtt[i].ATE_NUM != Mx_Dtt[ai].ATE_NUM) {
                                return String(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO);
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
                                var obj_date = new Date(Mx_Dtt[i].ATE_FECHA);
                                var dd = parseInt(obj_date.getDate());
                                var mm = parseInt(obj_date.getMonth()) + 1;
                                var yy = parseInt(obj_date.getFullYear());

                                if (dd < 10) { dd = "0" + dd; }
                                if (mm < 10) { mm = "0" + mm; }

                                return String(dd + "/" + mm + "/" + yy);
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (i == 0 || Mx_Dtt[i].ATE_NUM != Mx_Dtt[ai].ATE_NUM) {
                                return String(Mx_Dtt[i].PROC_DESC);
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].T_MUESTRA_DESC),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CB_DESC),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt[i].ID_RECEP_ETI != 0) {
                                Si_Recep_Eti = Si_Recep_Eti + 1;

                                $(this).css("cssText", "text-align:center;background-color:#9bffb1;").text("SI");
                            }
                            else {
                                No_Recep_Eti = No_Recep_Eti + 1;

                                $(this).css("cssText", "text-align:center;").text("NO");
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt[i].ID_RECEP_ETI_DERIVA != 0) {
                                Si_Deriva_Eti = Si_Deriva_Eti + 1;

                                $(this).css("cssText", "text-align:center;background-color:#9bffb1;").text("SI");
                            }
                            else {
                                No_Deriva_Eti = No_Deriva_Eti + 1;

                                $(this).css("cssText", "color:inherit; text-align:center;").text("NO");
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt[i].ID_RECEP_ETI_RECHAZO != 0) {
                                Si_Rechazo_Eti = Si_Rechazo_Eti + 1;

                                $(this).css("cssText", "text-align:center;background-color:#9bffb1;").text("SI");
                            }
                            else {
                                No_Rechazo_Eti = No_Rechazo_Eti + 1;

                                $(this).css("cssText", "text-align:center;").text("NO");
                            }
                        })
                  )
                );
            }
            //console.log("SI RRECEP: " + Si_Recep_Eti + " - NO RECEP: " + No_Recep_Eti + " - SI DERIVA: " + Si_Deriva_Eti + " - NO DERIVA: " + No_Deriva_Eti + " - SI RECHAZO:" + Si_Rechazo_Eti + " - NO RECHAZO:" + No_Rechazo_Eti);
            tot = 0, Si_Recep_Eti_pc = 0, No_Recep_Eti_pc = 0, Si_Deriva_Eti_pc = 0, No_Deriva_Eti_pc = 0, Si_Rechazo_Eti_pc = 0, No_Rechazo_Eti_pc = 0;
            tot = Si_Recep_Eti + No_Recep_Eti;
            $("#lbl_exa_sum").text(tot);
            $("#lbl_ate_sum").text(tot_ate);

            $("#lbl_recep_si_sum").text(Si_Recep_Eti);
            $("#lbl_recep_no_sum").text(No_Recep_Eti);
            $("#lbl_deriv_si_sum").text(Si_Deriva_Eti);
            $("#lbl_deriv_no_sum").text(No_Deriva_Eti);
            $("#lbl_recha_si_sum").text(Si_Rechazo_Eti);
            $("#lbl_recha_no_sum").text(No_Rechazo_Eti);

            Si_Recep_Eti_pc = (Si_Recep_Eti * 100) / tot;
            No_Recep_Eti_pc = (No_Recep_Eti * 100) / tot;
            Si_Deriva_Eti_pc = (Si_Deriva_Eti * 100) / tot;
            No_Deriva_Eti_pc = (No_Deriva_Eti * 100) / tot;
            Si_Rechazo_Eti_pc = (Si_Rechazo_Eti * 100) / tot;
            No_Rechazo_Eti_pc = (No_Rechazo_Eti * 100) / tot;

            Si_Recep_Eti_pc = Math.round(Si_Recep_Eti_pc * 100) / 100;
            No_Recep_Eti_pc = Math.round(No_Recep_Eti_pc * 100) / 100;
            Si_Deriva_Eti_pc = Math.round(Si_Deriva_Eti_pc * 100) / 100;
            No_Deriva_Eti_pc = Math.round(No_Deriva_Eti_pc * 100) / 100;
            Si_Rechazo_Eti_pc = Math.round(Si_Rechazo_Eti_pc * 100) / 100;
            No_Rechazo_Eti_pc = Math.round(No_Rechazo_Eti_pc * 100) / 100;

            $("#lbl_ate_sum_pc").text("100%");
            $("#lbl_exa_sum_pc").text("100%");
            $("#lbl_recep_si_sum_pc").text(Si_Recep_Eti_pc + "%");
            $("#lbl_recep_no_sum_pc").text(No_Recep_Eti_pc + "%");
            $("#lbl_deriv_si_sum_pc").text(Si_Deriva_Eti_pc + "%");
            $("#lbl_deriv_no_sum_pc").text(No_Deriva_Eti_pc + "%");
            $("#lbl_recha_si_sum_pc").text(Si_Rechazo_Eti_pc + "%");
            $("#lbl_recha_no_sum_pc").text(No_Rechazo_Eti_pc + "%");
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
                "ID_PREV": $("#Ddl_Prevision").val(),
                "ID_PROC": $("#Ddl_LugarTM").val(),
                "ID_IE": $("#Ddl_Orden_Ate").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Indica_Muestra_Ingresa.aspx/Excel",
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
                        Indicadores de Muestras Ingresadas
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
                            <label for="Ddl_LugarTM">Lugar de TM:</label>
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
                            <h5 style="text-align: center;"><i class="fa fa-fw fa-list"></i>Lista de Muestras</h5>
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
                                            <label id="lbl_ate_sum_pc"></label>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-4">Examenes</div>
                                        <div class="col-4">
                                            <label id="lbl_exa_sum"></label>
                                        </div>
                                        <div class="col-4">
                                            <label id="lbl_exa_sum_pc"></label>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-4">Recepcionados. SI</div>
                                        <div class="col-4">
                                            <label id="lbl_recep_si_sum"></label>
                                        </div>
                                        <div class="col-4">
                                            <label id="lbl_recep_si_sum_pc"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-4">Recepcionados. NO</div>
                                        <div class="col-4">
                                            <label id="lbl_recep_no_sum"></label>
                                        </div>
                                        <div class="col-4">
                                            <label id="lbl_recep_no_sum_pc"></label>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-4">Derivado. SI</div>
                                        <div class="col-4">
                                            <label id="lbl_deriv_si_sum"></label>
                                        </div>
                                        <div class="col-4">
                                            <label id="lbl_deriv_si_sum_pc"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-4">Derivado. NO</div>
                                        <div class="col-4">
                                            <label id="lbl_deriv_no_sum"></label>
                                        </div>
                                        <div class="col-4">
                                            <label id="lbl_deriv_no_sum_pc"></label>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-4">Rechazado. SI</div>
                                        <div class="col-4">
                                            <label id="lbl_recha_si_sum"></label>
                                        </div>
                                        <div class="col-4">
                                            <label id="lbl_recha_si_sum_pc"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-4">Rechazado. NO</div>
                                        <div class="col-4">
                                            <label id="lbl_recha_no_sum"></label>
                                        </div>
                                        <div class="col-4">
                                            <label id="lbl_recha_no_sum_pc"></label>
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
