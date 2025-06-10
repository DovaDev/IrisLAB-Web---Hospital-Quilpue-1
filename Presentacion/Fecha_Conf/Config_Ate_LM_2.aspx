<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Config_Ate_LM_2.aspx.vb" Inherits="Presentacion.Config_Ate_LM_2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
     <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true"%>
    <script>
        $(document).ready(function () {
          
            var idd = "";
            Call_AJAX_Ddl_Año();
            Call_AJAX_Ddl_LugarTM();

            $("#Fecha").val("");
            $("#Cantidad").val("");
            $("#btnguardar").attr("disabled", true);
            $("#btnmodificar").attr("disabled", true);
            $("#btneliminar").attr("disabled", true);
            $("#normal").focusout(function () {
                var total = 0;
               $("#Cantidad").val();
                var nor = $("#normal").val();
                var pri = $("#prioritario").val();
                var esp = $("#espontaneo").val();
                total = parseInt(esp) + parseInt(pri) + parseInt(nor);
                $("#Cantidad").val(total);
            });
            $("#prioritario").focusout(function () {
                var total = 0;
                $("#Cantidad").val();
                var nor = $("#normal").val();
                var pri = $("#prioritario").val();
                var esp = $("#espontaneo").val();
                total = parseInt(esp) + parseInt(pri) + parseInt(nor);
                $("#Cantidad").val(total);
            });
            $("#espontaneo").focusout(function () {
                var total = 0;
                $("#Cantidad").val();
                var nor = $("#normal").val();
                var pri = $("#prioritario").val();
                var esp = $("#espontaneo").val();
                total = parseInt(esp) + parseInt(pri) + parseInt(nor);
                $("#Cantidad").val(total);
            });

            $("#Ddl_Año, #Ddl_Mes, #Ddl_LugarTM").change(function () {
                if ($("#Ddl_LugarTM option:selected").text() != "Seleccionar") {

                    Call_AJAX_DataTable();
                } else {
                    $("#DataTable_Ate_TM tbody").empty();
                }
            });

            $("#btnguardar").click(function () {
                $("#Div_Tabla99").empty();
                var total = 0;
                var cant = $("#Cantidad").val();
                var nor = $("#normal").val();  
                var pri = $("#prioritario").val();
                var esp = $("#espontaneo").val();
                total = parseInt(esp) + parseInt(pri) + parseInt(nor);
                if (cant == total) {
                    Call_AJAX_Guardar();
                    $("#Div_Tabla99").empty();
                } else {
                    $("#Div_Tabla99").append(
                    ("<div class='alert alert-danger alertas'><strong>La suma de los agendados (normal, prioritario y espóntaneo) debe ser igual a Agendado Total</strong>  </div>")
                   );
                }
              
            });
            $("#btnmodificar").click(function () {
                $("#Div_Tabla99").empty();
                var total = 0;
                var cant = $("#Cantidad").val();
                var nor = $("#normal").val();
                var pri = $("#prioritario").val();
                var esp = $("#espontaneo").val();
                total = parseInt(esp) + parseInt(pri) + parseInt(nor);
                if (cant == total) {
                    $("#Div_Tabla99").empty();
                     Call_AJAX_Modificar();
                } else {
                    $("#Div_Tabla99").append(
                    ("<div class='alert alert-danger alertas'><strong>La suma de los agendados (normal, prioritario y espóntaneo) debe ser igual a Agendado Total</strong>  </div>")
                    );
                                    }
               
            });
            $("#btneliminar").click(function () {
                $("#Div_Tabla99").empty();
                var total = 0;
                var cant = $("#Cantidad").val();
                var nor = $("#normal").val();
                var pri = $("#prioritario").val();
                var esp = $("#espontaneo").val();
                total = parseInt(esp) + parseInt(pri) + parseInt(nor);
                if (cant == total) {
                    $("#Div_Tabla99").empty();
                      Call_AJAX_Eliminar();
                } else {
                    $("#Div_Tabla99").append(
("<div class='alert alert-danger alertas'><strong>La suma de los agendados (normal, prioritario y espóntaneo) debe ser igual a Agendado Total</strong>  </div>")
);

                }


              
            });

        });
        //DEFINICION ARRAY AÑO
        var Mx_Ddl_Año = [{
            "ID_AÑO": "",
            "AÑO_COD": "",
            "AÑO_DESC": "",
            "ID_ESTADO": ""
        }];
        //DEFINICION ARRAY LUGARTM
        var Mx_Ddl_LugarTM = [{
            "ID_PROCEDENCIA": "",
            "PROC_COD": "",
            "PROC_DESC": "",
            "ID_ESTADO": ""
        }];
        //DEFINICION ARRAY DATATABLE
        var Mx_Dtt = [{
            "N_FECHA": "",
            "N_CANT_EXA": "",
            "N_AGEND_CUPO_NORMAL": "",
            "N_AGEND_PRIORITARIO": "",
            "N_AGEND_ESPONTANEO": "",
            "N_ESTADO": "",
            "N_ID": ""
        }];

    </script>
    <script>

        //AJAX DDL AÑO
        function Call_AJAX_Ddl_Año() {
            //Debug



            $.ajax({
                "type": "POST",
                "url": "Config_Ate_LM_2.aspx/Llenar_Ddl_Año",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Ddl_Año = JSON.parse(data.d);

                    Fill_Ddl_Año();
                },
                "error": data => {
                    //Debug



                }
            });
        }
        //AJAX DDL LUGAR TM
        function Call_AJAX_Ddl_LugarTM() {
            //Debug



            $.ajax({
                "type": "POST",
                "url": "Config_Ate_LM_2.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Ddl_LugarTM = JSON.parse(data.d);

                    Fill_Ddl_LugarTM();
                },
                "error": data => {
                    //Debug



                }
            });
        }
        //AJAX DATATABLE
        function Call_AJAX_DataTable() {
            //Debug


            var fstr = $("#Ddl_Mes").val() + "/" + $("#Ddl_Año option:selected").text();

            var strParam = JSON.stringify({
                "ID_PRO": $("#Ddl_LugarTM").val(),
                "FECHA": fstr
            });

            $.ajax({
                "type": "POST",
                "url": "Config_Ate_LM_2.aspx/Llenar_Tabla",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Dtt = JSON.parse(data.d);

                    Fill_Dtt();
                },
                "error": data => {
                    //Debug



                }
            });
        }
        //AJAX GUARDAR
        function Call_AJAX_Guardar() {
            //Debug



            var strParam = JSON.stringify({
                "ID_PRO": $("#Ddl_LugarTM").val(),
                "FECHA": $("#Fecha").val(),
                "CANT": $("#Cantidad").val(),
                "normal": $("#normal").val(),
                "prioritario": $("#prioritario").val(),
                "espontaneo": $("#espontaneo").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Config_Ate_LM_2.aspx/Guardar_Conf_Examenes",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    $("#Fecha").val("");
                    $("#Cantidad").val("");
                    $("#normal").val("");
                    $("#prioritario").val("");
                    $("#espontaneo").val("");
                    $("#btnguardar").attr("disabled", true);
                    $("#btnmodificar").attr("disabled", true);
                    $("#btneliminar").attr("disabled", true);

                    $("#EM2 h5").text("Cantidad Guardada");
                    $("#EM2 button").attr("class", "btn btn-success");
                    $("#EM2 p").text("Se realizaron los cambios con éxito");
                    $("#EM2").modal();

                    Call_AJAX_DataTable();
                },
                "error": data => {
                    //Debug



                    $("#EM2 h5").text("Error");
                    $("#EM2 button").attr("class", "btn btn-danger");
                    $("#EM2 p").text("Ocurrió un error durante el guardado de cantidad");
                    $("#EM2").modal();
                }
            });
        }
        //AJAX MODIFICAR
        function Call_AJAX_Modificar() {
            //Debug



            var strParam = JSON.stringify({
                "ID_CONF": idd,
                "CANTIDAD": $("#Cantidad").val(),
                "ID_ESTADO": 1,
                
                "normal": $("#normal").val(),
            "prioritario": $("#prioritario").val(),
            "espontaneo": $("#espontaneo").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Config_Ate_LM_2.aspx/Modificar_Conf_Examenes",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    $("#Fecha").val("");
                    $("#Cantidad").val("");
                    $("#normal").val("");
                    $("#prioritario").val("");
                    $("#espontaneo").val("");
                    $("#btnguardar").attr("disabled", true);
                    $("#btnmodificar").attr("disabled", true);
                    $("#btneliminar").attr("disabled", true);

                    $("#EM2 h5").text("Cantidad Modificada");
                    $("#EM2 button").attr("class", "btn btn-success");
                    $("#EM2 p").text("Se realizaron los cambios con éxito");
                    $("#EM2").modal();

                    Call_AJAX_DataTable();
                },
                "error": data => {
                    //Debug



                    $("#EM2 h5").text("Error");
                    $("#EM2 button").attr("class", "btn btn-danger");
                    $("#EM2 p").text("Ocurrió un error durante la modificación de cantidad");
                    $("#EM2").modal();

                }
            });
        }
        //AJAX ELIMINAR
        function Call_AJAX_Eliminar() {
            //Debug



            var strParam = JSON.stringify({
                "ID_CONF": idd,
                "CANTIDAD": $("#Cantidad").val(),
                "ID_ESTADO": 2,
                "normal": $("#normal").val(),
                "prioritario": $("#prioritario").val(),
                "espontaneo": $("#espontaneo").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Config_Ate_LM_2.aspx/Modificar_Conf_Examenes",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    $("#Fecha").val("");
                    $("#Cantidad").val("");
                    $("#btnguardar").attr("disabled", true);
                    $("#btnmodificar").attr("disabled", true);
                    $("#btneliminar").attr("disabled", true);

                    $("#EM2 h5").text("Cantidad Eliminada");
                    $("#EM2 button").attr("class", "btn btn-success");
                    $("#EM2 p").text("Se realizaron los cambios con éxito");
                    $("#EM2").modal();

                    Call_AJAX_DataTable();
                },
                "error": data => {
                    //Debug



                    $("#EM2 h5").text("Error");
                    $("#EM2 button").attr("class", "btn btn-danger");
                    $("#EM2 p").text("Ocurrió un error durante la eliminación de cantidad");
                    $("#EM2").modal();

                }
            });
        }
        //FUNCTION ON CLICK
        function Ajax_Click(fclick, cantexa, valor1,valor2,valor3, est, id) {

            $("#Fecha").val(fclick);
            $("#Cantidad").val(cantexa);

            $("#normal").val(valor1);
            $("#prioritario").val(valor2);
            $("#espontaneo").val(valor3);



            if (est == 1) {
                $("#btnguardar").attr("disabled", true);
                $("#btnmodificar").removeAttr("disabled");
                $("#btneliminar").removeAttr("disabled");
            } else {
                $("#btnmodificar").attr("disabled", true);
                $("#btneliminar").attr("disabled", true);
                $("#btnguardar").removeAttr("disabled");
            }
            idd = id;
        }
        //FUNCTION SET DATE
        function Ajax_Set_Date() {

            var m = moment().format("MM");
            var y = moment().format("YYYY");

            $("#Ddl_Año").val(y);
            $("#Ddl_Mes").val(m);

        }
        //FILL DROPDOWNLIST AÑO
        function Fill_Ddl_Año() {
            Mx_Ddl_Año.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.AÑO_DESC
                    }
                ).text(aaa.AÑO_DESC).appendTo("#Ddl_Año");
            });
            Ajax_Set_Date();
        }
        //FILL DROPDOWNLIST LUGAR TM
        function Fill_Ddl_LugarTM() {
          

            var procee = Galletas.getGalleta("USU_TM");

            if (procee == 0) {
                Mx_Ddl_LugarTM.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                });
            }
            else {
                Mx_Ddl_LugarTM.forEach(aaa => {
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
        
        //FILL DATATABLE
        function Fill_Dtt() {
            $("#DataTable_Ate_TM tbody").empty();
            //Recorrer JSON
            var i = 1

            Mx_Dtt.forEach(aah => {

                moment.locale('es');
                var fdia = moment(aah.N_FECHA, "DDMMYYYY").format('dddd');

                if (fdia != "Domingo") {
                    $("<tr>", {
                        "onclick": `Ajax_Click("` + aah.N_FECHA + `","` + aah.N_CANT_EXA + `","` + aah.N_AGEND_CUPO_NORMAL + `","` + aah.N_AGEND_PRIORITARIO + `","` + aah.N_AGEND_ESPONTANEO + `","` + aah.N_ESTADO + `","` + aah.N_ID + `")`,
                        "class": "manito"
                    }).append(
                         $("<td>").css({ "text-align": "center", "font-weight": "bold" }).text(i),
                         $("<td>").css("text-align", "center").text(aah.N_FECHA),
                         $("<td>").css("text-align", "center").text(aah.N_CANT_EXA),
                           $("<td>").css("text-align", "center").text(aah.N_AGEND_CUPO_NORMAL),
                             $("<td>").css("text-align", "center").text(aah.N_AGEND_PRIORITARIO),
                               $("<td>").css("text-align", "center").text(aah.N_AGEND_ESPONTANEO),
                         $("<td>").css("text-align", "center").text(fdia)
                    ).appendTo("#DataTable_Ate_TM tbody");
                    i += 1;
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <style>
        .divtab {
            height: 100vh;
            width: 100vw;
            position: absolute;
            top: 0;
            left: 0;
        }

        .table {
            border-collapse: collapse;
            width: 100%;
        }
               
        
        .form-control:disabled {
            background-color: white;
        }

        .manito {
            cursor: pointer;
        }
    </style>
    <div class="row">
        <div class="col-lg">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar">
            <h5>
                <i class="fa fa-list"></i>
                Configuración de Atenciones por LM
            </h5>
        </div>
        <div class="row">
            <div class="col-md"></div>
            <div class="col-md-10">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-5">
                            <div class="row">
                                <div class="col-6">
                                    <label for="Ddl_Año">Año:</label>
                                    <select id="Ddl_Año" class="form-control"></select>
                                </div>
                                <div class="col-6">
                                    <label for="Ddl_Mes">Mes:</label>
                                    <select id="Ddl_Mes" class="form-control">
                                        <option value="01">ENERO</option>
                                        <option value="02">FEBRERO</option>
                                        <option value="03">MARZO</option>
                                        <option value="04">ABRIL</option>
                                        <option value="05">MAYO</option>
                                        <option value="06">JUNIO</option>
                                        <option value="07">JULIO</option>
                                        <option value="08">AGOSTO</option>
                                        <option value="09">SEPTIEMBRE</option>
                                        <option value="10">OCTUBRE</option>
                                        <option value="11">NOVIEMBRE</option>
                                        <option value="12">DICIEMBRE</option>
                                    </select>
                                </div>
                            </div>
                            <div class="row mb-3">
                                <div class="col-12">
                                    <label for="Ddl_LugarTM">Lugar de TM:</label>
                                    <select id="Ddl_LugarTM" class="form-control">
                                        <option>Seleccionar</option>
                                    </select>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12" style="height:50vh;overflow:auto;">
                                    <table id="DataTable_Ate_TM" cellspacing="0" class="table table-hover table-striped table-iris table-iris">
                                        <thead>
                                            <tr>
                                                <th style="text-align: center">#</th>
                                                <th style="text-align: center">Fecha</th>
                                                <th style="text-align: center">Cantidad de Atenciones</th>
                                                <th style="text-align: center">Agendado cupo normal</th>
                                                <th style="text-align: center">Agendado prioritario</th>
                                                <th style="text-align: center">Agendado espóntaneo</th>
                                                <th style="text-align: center">Día</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-1"></div>
                        <div class="col-md-6">
                            <div class="container">
                                <div class="form-row">                                  
                                    <div class="col-sm-5">
                                        <h6>
                                            <label>Fecha:</label></h6>
                                        <input id="Fecha" type="text" class="form-control font-weight-bold text-center" disabled="disabled" style="color: red; font-size: 14px;" />
                                    </div>
                                    <div class="col"></div>
                                </div>
                                <div class="form-row mb-3" style="margin-top: 15px;">
                                   
                                    <div class="col-sm">
                                        <h6>
                                         <label>Agendado Total:</label></h6>
                          
                                        <input id="Cantidad" type="text" class="form-control font-weight-bold text-center" disabled="disabled" style="font-size: 10px;" />
                                    </div>
                                    <div class="col-sm">
                                        <h6>
                                         <label>Agendado Normal:</label></h6>
                                        <input id="normal" type="text" class="form-control font-weight-bold text-center" style="font-size: 10px;" />
                                    </div>
                                    <div class="col-sm">
                                        <h6>
                                         <label>Agendado Prioritario:</label></h6>
                                        <input id="prioritario" type="text" class="form-control font-weight-bold text-center" style="font-size: 10px;" />
                                    </div>
                                    <div class="col-sm">
                                        <h6>
                                         <label>Agendado Espontáneo:</label></h6>
                                        <input id="espontaneo" type="text" class="form-control font-weight-bold text-center" style="font-size: 10px;" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                         
                                    <button type="button" id="btnguardar"  class="btn btn-primary btn-block"><i class="fa fa-fw fa-save"></i>Guardar</button>
                                </div>
                                <div class="col-sm">
                           
                                    <button type="button"  id="btnmodificar"class="btn btn-info btn-block"><i class="fa fa-fw fa-edit"></i>Modificar</button>
                                </div>
                                <div class="col-sm">
                                    <button type="button" id="btneliminar" class="btn btn-danger btn-block"><i class="fa fa-fw fa-remove"></i>Eliminar</button>
                                  
                                </div>
                            </div>
                            <div class="row" style="margin-top:15px;">
                                <div class="col-sm">
                                     <div id="Div_Tabla99" class="col-md">
               
                                      </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md">
               
            </div>
        </div>

    </div>
</div>
        </div>

</asp:Content>
