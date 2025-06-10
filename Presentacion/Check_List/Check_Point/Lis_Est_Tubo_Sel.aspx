<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Lis_Est_Tubo_Sel.aspx.vb" Inherits="Presentacion.Lis_Est_Tubo_Sel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>

        $(document).ready(function () {
            $("#Id_Conte").hide();
            Ajax_LugarTM();
            Ajax_Seccion();

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

            $("#Btn_Buscar").click(function () {
                $("#Div_Tabla").empty();
                Ajax_DataTable();
            });
            $("#Btn_Excel").click(function () {
                Ajax_Excel();
            });
        });

        //------------------------------------------------ AJAX DDL LUGAR DE TM -------------------------------------------|
        var Mx_Dtt_LugarTM = [
    {
        "ID_ESTADO": 0,
        "PROC_DESC": 0,
        "PROC_COD": 0,
        "ID_PROCEDENCIA": 0
    }
        ];
        function Ajax_LugarTM() {
            modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_Est_Tubo_Sel.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_LugarTM = JSON.parse(json_receiver);
                        Fill_Ddl_LugarTM();
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
        //------------------------------------------------ AJAX DDL SECCION -------------------------------------------|
        var Mx_Seccion = [
    {
        "CB_DESC": 0,
        "Expr1": 0,
        "T_MUESTRA_COD": 0,
        "T_MUESTRA_DESC": 0,
        "ID_ESTADO": 0
    }
        ];
        function Ajax_Seccion() {
            modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_Est_Tubo_Sel.aspx/Llenar_Ddl_Seccion",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Seccion = JSON.parse(json_receiver);
                        Fill_Ddl_Seccion();
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
        function Fill_Ddl_LugarTM() {
            $("#Ddl_LugarTM").empty();
            var procee = Galletas.getGalleta("USU_TM");
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

        };
        //Llenar DropDownList Tipo de Atención
        function Fill_Ddl_Seccion() {

            $("#Ddl_Seccion").empty();
            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Seccion");
            for (y = 0; y < Mx_Seccion.length; ++y) {
                $("<option>", {
                    "value": Mx_Seccion[y].Expr1
                }).text(Mx_Seccion[y].CB_DESC + " " + Mx_Seccion[y].T_MUESTRA_DESC).appendTo("#Ddl_Seccion");
            }
        };

        /////////////////////// DATATABLE
        var Mx_Dtt = [
           {
               "ID_T_MUESTRA": 0,
               "ATE_NUM": 0,
               "T_MUESTRA_DESC": 0,
               "CB_DESC": 0,
               "IDTM":0,
               "ID_ATENCION": 0,
               "GMUE_DESC": 0,
               "ATE_FECHA": 0,
               "ATE_NUM_INTERNO": 0,
               "ATE_EST_RECEP": 0,
               "EST_DESCRIPCION": 0,
               "CF_DESC": 0,
               "PAC_NOMBRE":0,
               "PAC_APELLIDO":0,
               "PAC_RUT":0,
               "PROC_DESC":0,
               "ID_PACIENTE":0,
               "ATE_AÑO":0,
               "ID_SEXO":0,
               "ATE_EST_RECHAZO":0,
               "ATE_EST_DERIVA":0,
               "ID_CODIGO_FONASA":0,
               "ATE_DET_V_ID_ESTADO":0,
               "ATE_DET_REV_ID_ESTADO":0,
               "Expr1":0,
               "Expr2": 0,
               "ENCRYPTED_ID":0
           }
        ];

        function Ajax_DataTable() {
            modal_show();

            var Data_Par = JSON.stringify({
                "TIPO" : 0,
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PRE": $("#Ddl_LugarTM").val(),
                "ID_CF":0,
                "ID_VAL":0,
                "ID_NMUE":0,
                "ID_SECCION":0,
                "ID_TUBO": $("#Ddl_Seccion").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_Est_Tubo_Sel.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
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
                    Hide_Modal();
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                }
            });
        }
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
            $("#DataTable thead").attr("class", "cabezera");
            $("#DataTable thead").append(
                 $("<tr>").append(
                $("<th>", { "class": "textoReducido" }).text("#"),
                $("<th>", { "class": "textoReducido" }).text("N°Ate."),
                $("<th>", { "class": "textoReducido" }).text("Nombre"),
                $("<th>", { "class": "textoReducido" }).text("Edad"),
                $("<th>", { "class": "textoReducido" }).text("Fecha"),
                $("<th>", { "class": "textoReducido" }).text("Lugar TM"),
                $("<th>", { "class": "textoReducido" }).text("Examen"),
                $("<th>", { "class": "textoReducido" }).text("Tipo Etiqueta"),
                $("<th>", { "class": "textoReducido" }).text("CB"),
                $("<th>", { "class": "textoReducido" }).text("Recep."),
                $("<th>", { "class": "textoReducido" }).text("Validado"),
                $("<th>", { "class": "textoReducido" }).text("Revisado"),
                $("<th>", { "class": "textoReducido" }).text("Nueva Muestra"),
                $("<th>", { "class": "textoReducido" }).text("RUT"),
                $("<th>", { "class": "textoReducido" }).text("N° Interno")   
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
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

                            if (i == 0 || Mx_Dtt[i].ATE_NUM != Mx_Dtt[ai].ATE_NUM)
                            {  
                                return String(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO);
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
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CF_DESC),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt[i].T_MUESTRA_DESC),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CB_DESC),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt[i].ATE_EST_RECEP == "9") {
                                $(this).css("cssText", "text-align:center;").text("SI");
                            }
                            else {
                                $(this).css("cssText", "text-align:center;").text("NO");
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt[i].ATE_DET_V_ID_ESTADO == "6" || Mx_Dtt[i].ATE_DET_V_ID_ESTADO == "14") {
                                $(this).css("cssText", "text-align:center;").text("SI");
                            }
                            else {
                                $(this).css("cssText", "color:inherit; text-align:center;").text("NO");
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt[i].ATE_DET_REV_ID_ESTADO == "1") {
                                $(this).css("cssText", "text-align:center;").text("SI");
                            }
                            else {
                                $(this).css("cssText", "text-align:center;").text("NO");
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt[i].ATE_EST_RECHAZO == "16") {
                                $(this).css("cssText", "text-align:center;").text("SI");
                            }
                            else {
                                $(this).css("cssText", "text-align:center;").text("NO");
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {

                            if (i == 0 || Mx_Dtt[i].ATE_NUM != Mx_Dtt[ai].ATE_NUM) {
                                return String(Mx_Dtt[i].PAC_RUT);
                            }
                        }),                      
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {

                            if (i == 0 || Mx_Dtt[i].ATE_NUM != Mx_Dtt[ai].ATE_NUM) {
                                return String(Mx_Dtt[i].ATE_NUM_INTERNO);
                            }
                        })
                  )
                );
            }
        }

        var Mx_Dtt_Excel = [
   {
       "urls": ""
   }
        ];
        function Ajax_Excel() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "TIPO": 0,
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PRE": $("#Ddl_LugarTM").val(),
                "ID_CF": 0,
                "ID_VAL": 0,
                "ID_NMUE": 0,
                "ID_SECCION": 0,
                "ID_TUBO": $("#Ddl_Seccion").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_Est_Tubo_Sel.aspx/Excel",
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
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        function Ajax_Redirect(id) {
            var loc = location.origin;
            window.open(loc + "/Buscar_Ate/Atencion_Det.aspx?ID_ATE=" + id);

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
                <div class="card-header bg-bar">
                    <h5 style="text-align: center; padding: 5px;">
                        <i class="fa fa-edit"></i>
                        Listado de Estados por Tubos Selección
                    </h5>
                </div>
                <div class="row mb-3" style="margin-left: 2px; margin-right: 2px;">
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
                        <label for="Ddl_Seccion">Tubos:</label>
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
                    <div class="col-md-12" id="Paciente">
                        <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list"></i>Impresión de Etiquetas</h5>
                        <div class="row" style="font-size: 15px;">
                            <div class="col-md-2">
                                <label>TOTAL: </label>
                                <b>
                                    <label id="lblTotal" class="text-primary">0</label></b>
                            </div>
                        </div>
                        <div id="Div_Tabla" style="width: 100%; max-height: 55vh; overflow: auto"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
