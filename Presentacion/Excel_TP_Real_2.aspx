<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Excel_TP_Real_2.aspx.vb" Inherits="Presentacion.Excel_TP_Real_2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="/js/moment_es.js"></script>
    <script src="/js/moment.js"></script>
    <script>
        let interval = 0;
        let permiss = Galletas.getGalleta("P_ADMIN");
        let usu_te_eme = Galletas.getGalleta("USU_TM");
        $(document).ready(function () {
            Ajax_LugarTM();
  
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
            $("#Btn_Buscar").click(function () {
                if ($("#Ddl_Exam").val() == 0) {
                    $("#mError_AAH h4").text("Seleccione");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione un examen.");
                    $("#mError_AAH").modal();
                } else {
                    clearInterval(interval);
                    Ajax_DataTable();
                    interval = setInterval(Ajax_DataTable2, 1000);
                }
            });
            $("#Btn_Excel").click(function () {

                    Ajax_Excel();
                

            });

        });
    </script>
    <script>
        var Mx_Dtt = [
          {
              Cod_Barra: "",
              Establecimiento_Contenedor: "",
              Caja_Transporte: "",
              Contenedor_Envio: "",
              Fecha_irislab: new Date,
              Muestras_recepcionadas: "",
              Muestras_enviadas: "",
              Folio_Hoja_trabajo: "",
              Fecha_envio_HGF: new Date,
              Fecha_recepcion_Resultados: new Date,
              Fecha_Validacion_en_Irislab: new Date,
              num: ""
          }
        ];

        function Ajax_DataTable() {
            modal_show();


            var Data_Par = JSON.stringify({

                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_TM": $("#Ddl_LugarTM option:selected").text(),
       
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Excel_TP_Real_2.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt = JSON.parse(json_receiver);
                        $("#Div_Tabla").empty();

                        //for (i = 0; i < Mx_Dtt.length; ++i) {
                        //    var date_x = Mx_Dtt[i].PAC_FNAC;
                        //    date_x = String(date_x).replace("/Date(", "");
                        //    date_x = date_x.replace(")/", "");

                        //    var Date_Change = new Date(parseInt(date_x));
                        //    Mx_Dtt[i].PAC_FNAC = Date_Change;
                        //}

                        //for (i = 0; i < Mx_Dtt.length; ++i) {
                        //    var date_x = Mx_Dtt[i].ATE_FECHA;
                        //    date_x = String(date_x).replace("/Date(", "");
                        //    date_x = date_x.replace(")/", "");

                        //    var Date_Change = new Date(parseInt(date_x));
                        //    Mx_Dtt[i].ATE_FECHA = Date_Change;
                        //}


                        Fill_DataTable();
                        Hide_Modal();


                        $("#Id_Conte").show();
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


        function Ajax_DataTable2() {
          


            var Data_Par = JSON.stringify({

                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_TM": $("#Ddl_LugarTM option:selected").text(),

            });
        
            $.ajax({
                "type": "POST",
                "url": "Excel_TP_Real_2.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt = JSON.parse(json_receiver);
                        $("#Div_Tabla").empty();
                        //Ajax_LugarTM();
                        //for (i = 0; i < Mx_Dtt.length; ++i) {
                        //    var date_x = Mx_Dtt[i].PAC_FNAC;
                        //    date_x = String(date_x).replace("/Date(", "");
                        //    date_x = date_x.replace(")/", "");

                        //    var Date_Change = new Date(parseInt(date_x));
                        //    Mx_Dtt[i].PAC_FNAC = Date_Change;
                        //}

                        //for (i = 0; i < Mx_Dtt.length; ++i) {
                        //    var date_x = Mx_Dtt[i].ATE_FECHA;
                        //    date_x = String(date_x).replace("/Date(", "");
                        //    date_x = date_x.replace(")/", "");

                        //    var Date_Change = new Date(parseInt(date_x));
                        //    Mx_Dtt[i].ATE_FECHA = Date_Change;
                        //}


                        Fill_DataTable();
                


    
                    } else {


                        Hide_Modal();
                        //$("#mError_AAH h4").text("Sin resultados");
                        //$("#mError_AAH button").attr("class", "btn btn-danger");
                        //$("#mError_AAH p").text("No se han encontrado resultados");
                        //$("#mError_AAH").modal();
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
           

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Excel_TP_Real_2.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_LugarTM = JSON.parse(json_receiver);
                        Fill_Ddl_LugarTM();
                      

                    } else {

                    
                        //$("#mError_AAH h4").text("Sin resultados");
                        //$("#mError_AAH button").attr("class", "btn btn-danger");
                        //$("#mError_AAH p").text("No se han encontrado resultados");
                        //$("#mError_AAH").modal();
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
        //------------------------------------------------ AJAX DDL EXAMEN -------------------------------------------|
        var Mx_Exam = [
    {
        "ID_CODIGO_FONASA": 0,
        "CF_DESC": 0,
        "ID_ESTADO": 0
    }
        ];

        function Ajax_Exam() {
            modal_show();



            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Chk_Est_Exam.aspx/Llenar_Ddl_Exam",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Exam = JSON.parse(json_receiver);

                        Fill_Ddl_Exam();
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
        var Mx_Dtt_Excel = [
    {
        "urls": ""
    }
        ];

        function Ajax_Excel() {
            modal_show();


            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_TM": $("#Ddl_LugarTM option:selected").text(),
            });
    
            $.ajax({
                "type": "POST",
                "url": "Excel_TP_Real_2.aspx/Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
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
    </script>
    <script>
        //Llenar DropDownList Lugar de TM
        function Fill_Ddl_LugarTM() {
            $("#Ddl_LugarTM").empty();

            if (permiss == "1") {
                $("<option>", { "value": "0" }).text("Todos").appendTo("#Ddl_LugarTM");

                Mx_Dtt_LugarTM.forEach(aaa => {
                    $("<option>",
                        {
                            "value": 1
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                });

            } else if ((usu_te_eme == "0") && (permiss != "1")) {
                $("<option>", { "value": "0" }).text("Todos").appendTo("#Ddl_LugarTM");

                Mx_Dtt_LugarTM.forEach(aaa => {
                    $("<option>",
                        {
                            "value": 1
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                });


            } else {
                Mx_Dtt_LugarTM.forEach(aaa => {
                    if (aaa.ID_PROCEDENCIA == usu_te_eme) {
                        $("<option>", { "value": aaa.ID_PROCEDENCIA }).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                    }
                });
            }



                


        };
        //Llenar DropDownList Tipo de Atención
        function Fill_Ddl_Exam() {
            $("#Ddl_Exam").empty();

   
            for (y = 0; y < Mx_Exam.length; ++y) {
          
                    $("<option>", {
                        "value": Mx_Exam[y].ID_CODIGO_FONASA
                    }).text(Mx_Exam[y].CF_DESC).appendTo("#Ddl_Exam");
                }

      

        };
        function Ajax_Redirect(id) {
            var loc = location.origin;
            window.open(loc + "/Buscar_Ate/Atencion_Det.aspx?ID_ATE=" + id);
        }
        //---------------------------------------------------- TABLA  ------------------.........-----------------------------|
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
                    $("<th>", { "class": "textoReducido text-center" }).text("Cod. Barra"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Establecimiento/Contenedor"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Caja Transporte N°"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Contenedor de Envió AP"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha y hora ingreso Irislab"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Muestras recepcionadas"),
                    $("<th>", { "class": "text-reducido text-center" }).text("Diferencias"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Muestras enviadas"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Folio Hoja trabajo"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha envio HGF"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha recepcion Resultados"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha Validacion en Irislab")
                )
            );

                for (i = 0; i < Mx_Dtt.length; i++) {

                    $("#DataTable tbody").append(
                        $("<tr>", {
                            //"onclick": `Ajax_Redirect("` + Mx_Dtt[i].ID_FCL + `")`,
                            "class": "manito"
                        }).append(

                                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].Cod_Barra),
                                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].Establecimiento_Contenedor),
                                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].Caja_Transporte),
                                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].Contenedor_Envio),
                                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                                    if (moment(Mx_Dtt[i].Fecha_irislab).format("YYYY") > 1980) {
                                        return moment(Mx_Dtt[i].Fecha_irislab).format("DD/MM/YYYY HH:mm")

                                    } else {
                                        return ""
                                    }
                                }),
                                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].Muestras_recepcionadas),
                                $("<td>", { "align": "left" }, { "class": "textReducido" }).text(function () {
                                    var mues_recep = parseInt(Mx_Dtt[i].Muestras_recepcionadas);
                                    var mues_env = parseFloat(Mx_Dtt[i].Muestras_enviadas);

                                    var diferr = mues_recep - mues_env;

                                    if (diferr == 0) {
                                        return "0";
                                    } else {
                                        $(this).attr("class", "red-text");
                                        return diferr;
                                    }
                                }),
                                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].Muestras_enviadas),
                                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].Folio_Hoja_trabajo),
                                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function() {
                                    if (moment(Mx_Dtt[i].Fecha_envio_HGF).format("YYYY") > 1980) {
                                        return moment(Mx_Dtt[i].Fecha_envio_HGF).format("DD/MM/YYYY")
                                    
                                    } else {
                                        return ""
                                    }
                                }),
                                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                                    
                                    if (moment(Mx_Dtt[i].Fecha_recepcion_Resultados).format("YYYY") > 1980) {
                                        //Retornar un campo input
                                        return moment(Mx_Dtt[i].Fecha_recepcion_Resultados).format("DD/MM/YYYY")
                                    } else {
                                        //Retornar un campo input
                                        return ""
                                    }
                                }


                      


                        ),
                                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function(){

                                    if (moment(Mx_Dtt[i].Fecha_Validacion_en_Irislab).format("YYYY") > 1980) {
                                        return moment(Mx_Dtt[i].Fecha_Validacion_en_Irislab).format("DD/MM/YYYY")
                                    } else {
                                        return ""
                                    }
                                }

                    



                        )
                        )
                    );

                }
         
        }

    </script>
    <style>
        .red-text {
            color:red;
            font-weight:700;
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
                      Trazabilidad PAP
                    </h5>
                </div>
                <div class="card-body">
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
                </div>

                <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
                
            </div>
            <div class="row" id="Id_Conte">
                    <div class="col-md-12" id="Paciente">
                        <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list"></i>Listado de Atenciones</h5>
                        <div id="Div_Tabla" style="width: 100%; max-height: 55vh; overflow: auto"></div>
                    </div>
                </div>
        </div>
    </div>
</asp:Content>


