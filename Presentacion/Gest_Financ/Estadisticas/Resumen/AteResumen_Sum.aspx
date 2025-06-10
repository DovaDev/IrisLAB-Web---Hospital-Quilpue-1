<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="AteResumen_Sum.aspx.vb" Inherits="Presentacion.AteResumen_Sum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>

    <%-- Botones --%>
    <link href="../../../../Resourses/Style/Buttons.css" rel="stylesheet" />

    <%--Esto es para que funcione el gráfico--%>
    <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>
    <script src="/js/Custom_modal.js"></script>
    <script src="/js/Custom_Objects.js"></script>

    <%-- Declaración de Eventos --%>
    <script>
        $(document).ready(function () {
            $("#Id_conte").hide();

            //---------------------------------------- Date Pickers ----------------------------------------------|
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
            //Ajustes Visuales
            //$(".block_wait").css({ "display": "none" });
            $(".block_wait").hide();
            $("#Div_Total").empty().css({ "display": "none" });
            $("#Div_Graph").empty().css({ "display": "none" });
            $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });
            $("#Div_Tabla_Data").append(
                $("<div>").css({
                    "width": "calc(100% - 60)",
                    "text-align": "center",
                    "padding": "30px",
                    "font-size": "30px",
                    "font-weight": 900
                }).text("Realice su Búsqueda.")

            );

            //Llamar al llenado de los DropDownList
            Ajax_Ddl_Proce();

            //Registrar evento Click del Botón Buscar
            $("#Btn_Search").click(function () {
                function restaFechas(f1, f2) {
                    var aFecha1 = f1.split('-');
                    var aFecha2 = f2.split('-');
                    var fFecha1 = Date.UTC(aFecha1[2], aFecha1[1] - 1, aFecha1[0]);
                    var fFecha2 = Date.UTC(aFecha2[2], aFecha2[1] - 1, aFecha2[0]);
                    var dif = fFecha2 - fFecha1;
                    var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
                    return dias;
                }

                var Date_Diff = restaFechas(String($("#Txt_Date01 input").val()), String($("#Txt_Date02 input").val()));

                if (Date_Diff <= 31) {
                    Ajax_DataTable();

                } else {
                    $("#mError_AAH h4").text("Rango de Fechas");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione un rango de fechas menor a 31 días.");
                    $("#mError_AAH").modal();
                }
            });

            $("#DdlPrevi").change(function () {
                Ajax_Ddl_Alt();
            });

            $("#Btn_Export").click(function () {
                Ajax_Excel();
            });
            //$("#DdlPrevi").change(function () {
            //    Ajax_Ddl_sub();
            //});
            //$("#DdlAtenciones").change(function () {
            //    Ajax_Ddl_sub();
            //});

        });

    </script>


    <%-- Peticiones AJAX --%>
    <script>
        //Json de llenado de DropDownList
        var Mx_Ddl_Previ = [
            {
                "ID_PREVE": 0,
                "PREVE_COD": "asdf",
                "PREVE_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];

        var Mx_Ddl_Proce = [
            {
                "ID_PROCEDENCIA": 0,
                "PROC_COD": "asdf",
                "PROC_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];
        var Mx_Ddl = [
            {
                "ID_PROGRA": 0,
                "PROGRA_COD": "asdf",
                "PROGRA_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];
        var Mx_Ddl_sub = [
           {
               "ID_PROGRA": 0,
               "ID_SUBP": 0,
               "SUBP_DESC": "asdf",
               "ID_ESTADO": 0,
               "ID_PREVE": 0
           }
        ];
        function Ajax_Ddl_Prev() {



            $.ajax({
                "type": "POST",
                "url": "AteResumen_Sum.aspx/Llenar_Ddl_Prev",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_Previ = JSON.parse(json_receiver);
                        Fill_Ddl_Previ();
                        $(".block_wait").hide();



                    } else {
                        //cModal_Error("ERROR", "asdfasdfasdfas");

                        $("#Div_Tabla_Total").empty().css({ "background": "#c30000" });
                        $("#Summary_Graph").empty().css({ "background": "#c30000" });
                        $("#Div_dinero").empty().css({ "background": "#c30000" });
                        $("#Div_Tabla").empty().css({ "background": "#c30000" });
                        $("#Div_Tabla").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",
                                "font-weight": 900,
                                "color": "#ffffff"
                            }).text("Sin Resultados.")
                        );



                    }
                    Ajax_Ddl();
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500);
                    var str_Error = "Error interno del Servidor";
                    //cModal_Error("Error", str_Error);


                }
            });


        }

        function Ajax_Ddl_Proce() {



            $.ajax({
                "type": "POST",
                "url": "AteResumen_Sum.aspx/Llenar_Ddl_Proce",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_Proce = JSON.parse(json_receiver);
                        Fill_Ddl_Proce();
                        $(".block_wait").hide();



                    } else {
                        //cModal_Error("ERROR", "asdfasdfasdfas");

                        $("#Div_Tabla_Total").empty().css({ "background": "#c30000" });
                        $("#Summary_Graph").empty().css({ "background": "#c30000" });
                        $("#Div_dinero").empty().css({ "background": "#c30000" });
                        $("#Div_Tabla").empty().css({ "background": "#c30000" });
                        $("#Div_Tabla").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",
                                "font-weight": 900,
                                "color": "#ffffff"
                            }).text("Sin Resultados.")
                        );



                    }
                    Ajax_Ddl_Prev()

                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500);
                    var str_Error = "Error interno del Servidor";
                    //cModal_Error("Error", str_Error);


                }
            });


        };
        var Mx_Dtt = [
           {
               "ID_ATENCION": "",
               "ATE_NUM": "",
               "ATE_FECHA": "asdf",
               "PAC_NOMBRE": "",
               "PAC_APELLIDO": "",
               "CF_DESC": "",
               "CF_COD": "",
               "ATE_AÑO": "asdf",
               "PRU_DESC": "",
               "ATE_RESULTADO": "",
               "ATE_RESULTADO_NUM": "",
               "ID_CODIGO_FONASA": "",
               "ID_PRUEBA": "asdf",
               "PAC_FNAC": "",
               "UM_DESC": "",
               "ID_TP_RESULTADO": "",
               "TP_RESUL_DESC": "",
               "TP_RESUL_COD": "asdf",
               "ID_U_MEDIDA": "",
               "PREVE_DESC": "",
               "PROC_DESC": "",
               "PAC_RUT": "",
               "PRU_ORDEN": "asdf",
               "SUBP_DESC": "",
               "ATE_OMI": "",
               "SEXO_DESC": ""
           }
        ];
        function Ajax_DataTable() {
            modal_show();



            var Data_Par = JSON.stringify({
                "ID_TM": $("#DdlProce").val(),
                "ID_PREVE": $("#DdlPrevi").val(),
                "ID_PRG": $("#DdlAtenciones").val(),
                //"ID_SUB": $("#DLlSub").val(),
                "ID_SUB": 0,
                "DATE_str01": $("#Txt_Date01 input").val(),
                "DATE_str02": $("#Txt_Date02 input").val()
            });

            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "AteResumen_Sum.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);

                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].ATE_FECHA = Date_Change;
                        }
                        Hide_Modal();
                        $("#Id_conte").show();
                        Fill_DataTable();
                        $(".block_wait").hide();


                    } else {


                        $("#mError_AAH h4").text("Sin Resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados.");
                        $("#mError_AAH").modal();
                        $("#Div_Tabla_Total").empty().css({ "background": "#c30000" });
                        $("#Summary_Graph").empty().css({ "background": "#c30000" });
                        $("#Div_dinero").empty().css({ "background": "#c30000" });
                        $("#Div_Tabla_Data").empty().css({ "background": "#c30000" });
                        $("#Div_Tabla_Data").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",
                                "font-weight": 900,
                                "color": "#ffffff"
                            }).text("Sin Resultados.")
                        );
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500);



                    Hide_Modal();
                }
            });
        }
        function Ajax_Ddl() {



            $.ajax({
                "type": "POST",
                "url": "AteResumen_Sum.aspx/Llenar_Ddl",
                //"data": '{}'
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl = JSON.parse(json_receiver);

                        Fill_Ddl();


                    } else {


                    }
                    //Ajax_Ddl_sub();

                },
                "error": function (response) {
                    alert("Error en la Recepción de Datos");


                }

            });

        }

        function Ajax_Ddl_Alt() {



            var Data_Par = JSON.stringify({
                "ID_PREV": $("#DdlPrevi").val()
            });

            $.ajax({
                "type": "POST",
                "url": "AteResumen_Sum.aspx/Llenar_Ddl_Alt",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl = JSON.parse(json_receiver);

                        Fill_Ddl();


                    } else {


                    }
                    //Ajax_Ddl_sub();

                },
                "error": function (response) {
                    alert("Error en la Recepción de Datos");


                }

            });

        }

        function Ajax_Ddl_sub() {



            var Data_Par = JSON.stringify({
                "ID_PREV": $("#DdlPrevi").val(),
                "ID_PROG": $("#DdlAtenciones").val()
            });
            $.ajax({
                "type": "POST",
                "url": "AteResumen_Sum.aspx/Llenar",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_sub = JSON.parse(json_receiver);
                        Fill_Ddl_sub(false);
                        $(".block_wait").hide();



                    } else {
                        Mx_Ddl_sub = JSON.parse(json_receiver);
                        Fill_Ddl_sub(true);
                        $(".block_wait").hide();





                    }
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500, function () {
                        var str_Error = "";

                        if (response == undefined) {
                            str_Error = response.responseJSON.ExceptionType + "\n \n";
                            str_Error = response.responseJSON.Message;
                        } else {
                            str_Error = "Se ha cancelado la Petición";
                        }
                        //cModal_Error("Error", str_Error);
                    });



                }
            });
        }


        //Generar Excel
        function Ajax_Excel() {
            modal_show();
            Hide_Modal();



            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "ID_TM": $("#DdlProce").val(),
                "ID_PREVE": $("#DdlPrevi").val(),
                "ID_PRG": $("#DdlAtenciones").val(),
                //"ID_SUB": $("#DLlSub").val(),
                "ID_SUB": 0,
                "DATE_str01": $("#Txt_Date01 input").val(),
                "DATE_str02": $("#Txt_Date02 input").val()
            });

            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "AteResumen_Sum.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    $(".block_wait").fadeOut(500);

                    if (json_receiver != "null") {
                        window.open(json_receiver, 'Download');



                    } else {

                        $("#mError_AAH h4").text("Sin Resultados:");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para la busqueda solicitadayy.");
                        $("#mError_AAH").modal();



                    }
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500, function () {
                        var str_Error = "";

                        if (response == undefined) {
                            str_Error = response.responseJSON.ExceptionType + "\n \n";
                            str_Error = response.responseJSON.Message;
                        } else {
                            str_Error = "Se ha cancelado la Petición";
                        }
                        //cModal_Error("Error", str_Error);
                    });



                }
            });
        }
    </script>
    <%-- Funciones de Llenado de Elementos --%>
    <script>
        //Llenar DropDownList
        function Fill_Ddl_Previ() {
            $("#DdlPrevi").empty();

            //$("<option>", {
            //    "value": 0
            //}).text("Todos").appendTo("#DdlPrevi");
            for (y = 0; y < Mx_Ddl_Previ.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl_Previ[y].ID_PREVE
                }).text(Mx_Ddl_Previ[y].PREVE_DESC).appendTo("#DdlPrevi");
            }
        };

        function Fill_Ddl_Proce() {
            $("#DdlProce").empty();

            var procee = Galletas.getGalleta("USU_ID_PROC");

            if (procee == 0) {
                $("<option>",
                {
                    "value": "0"
                }
                ).text("Todos").appendTo("#DdlProce");
                Mx_Ddl_Proce.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#DdlProce");
                });
            }
            else {
                Mx_Ddl_Proce.forEach(aaa => {
                    if (aaa.ID_PROCEDENCIA == procee) {
                        $("<option>",
                          {
                              "value": aaa.ID_PROCEDENCIA
                          }
                       ).text(aaa.PROC_DESC).appendTo("#DdlProce");
                    }

                });
            }
        };
        function Fill_Ddl() {
            $("#DdlAtenciones").empty();

            $("<option>", {
                "value": 0
            }).text("Todas").appendTo("#DdlAtenciones");
            for (y = 0; y < Mx_Ddl.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl[y].ID_PROGRA
                }).text(Mx_Ddl[y].PROGRA_DESC).appendTo("#DdlAtenciones");
            }
        };

        //function Fill_Ddl_sub(isnull) {
        //    $("#DLlSub").empty();

        //    if (isnull == true) {
        //        $("<option>", {
        //            "value": 0
        //        }).text("Sin Resultados").appendTo("#DLlSub");
        //    } else {
        //        for (y = 0; y < Mx_Ddl_sub.length; ++y) {
        //            $("<option>", {
        //                "value": Mx_Ddl_sub[y].ID_SUBP
        //            }).text(Mx_Ddl_sub[y].SUBP_DESC).appendTo("#DLlSub");
        //        }
        //    }
        //};

        //Llenar DataTable
        function Fill_DataTable() {
            $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });

            $("<table>", {
                "id": "DataTable",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Data");

            $("#DataTable").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable thead").attr("class", "cabezera");
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "text-center" }).text("#"),
                    $("<th>", { "class": "text-center" }).text("N° Atención"),
                    $("<th>").text("Nombre Paciente"),
                    $("<th>").text("Determinación"),
                    $("<th>", { "class": "text-center" }).text("Resultado"),
                    $("<th>", { "class": "text-center" }).text("Unidad"),
                    $("<th>").text("Previsión"),
                    $("<th>").text("Lugar TM"),
                    $("<th>").text("Programa"),
                    $("<th>", { "class": "text-center" }).text("Rut"),
                    $("<th>", { "class": "text-center" }).text("Fecha Ate."),
                    $("<th>", { "class": "text-center" }).text("OC"),
                    $("<th>", { "class": "text-center" }).text("Sexo"),
                    $("<th>", { "class": "text-center" }).text("Edad")
                )
            );


            var numero = 0;

            for (i = 0; i < Mx_Dtt.length; i++) {
                var Rresultado = "";
                var resultado = "";
                numero = i + 1
                Rresultado = Mx_Dtt[i].TP_RESUL_COD
                if (Rresultado == "A") {
                    resultado = Mx_Dtt[i].ATE_RESULTADO
                } else {
                    resultado = Mx_Dtt[i].ATE_RESULTADO_NUM
                }

                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", {
                            "align": "center",
                            "width": "5%"
                        }).text(numero),
                        $("<td>", {
                            "align": "center",
                            "width": "10%"
                        }).text(Mx_Dtt[i].ATE_NUM),
                        $("<td>", {
                            "align": "center",
                            "width": "15%"
                        }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>", {

                            "width": "10%"
                        }).text(Mx_Dtt[i].CF_DESC + "-" + Mx_Dtt[i].PRU_DESC),
                        $("<td>", {
                            "align": "center",
                            "width": "10%"
                        }).text(resultado),
                        $("<td>", {
                            "align": "center",
                            "width": "10%"
                        }).text(Mx_Dtt[i].UM_DESC),
                        $("<td>", {
                            "align": "center",
                            "width": "10%"
                        }).text(Mx_Dtt[i].PREVE_DESC),
                        $("<td>", {

                            "width": "10%"
                        }).text(Mx_Dtt[i].PROC_DESC),
                        $("<td>", {

                            "width": "10%"
                        }).text(Mx_Dtt[i].PROGRA_DESC),
                        $("<td>", {
                            "align": "center",
                            "width": "10%"
                        }).text(Mx_Dtt[i].PAC_RUT),
                        $("<td>", {
                            "align": "center",
                            "width": "10%"
                        }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt[i].ATE_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var MM = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (MM < 10) { MM = "0" + MM; }

                            //var hh = parseInt(obj_date.getHours());
                            //var mm = parseInt(obj_date.getMinutes());

                            //if (hh < 10) { dd = "0" + dd; }
                            //if (mm < 10) { MM = "0" + MM; }

                            return String(dd + "/" + MM + "/" + yy);
                            //return String(dd + "/" + mm + "/" + yy + " " + hh + ":" + mm);
                        }),
                        //$("<td>", {
                        //    "align": "center",
                        //    "width": "10%"
                        //}).text(Mx_Dtt[i].SUBP_DESC),
                        $("<td>", {
                            "align": "center",
                            "width": "10%"
                        }).text(Mx_Dtt[i].ATE_OMI),
                        $("<td>", {
                            "align": "center",
                            "width": "10%"
                        }).text(Mx_Dtt[i].SEXO_DESC),
                        $("<td>", {
                            "align": "center",
                            "width": "10%"
                        }).text(Mx_Dtt[i].ATE_AÑO)


                ));
            }
            $("#DataTable").DataTable({
                "bSort": false,
                "binfo": false,
                "bSort": false,
                "iDisplayLength": 25,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay concidencias",
                    "info": "Mostrando Página _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
        }
    </script>

    <%-- CSS Personalizado --%>
    <style>
        .div_main p {
            margin: 0;
        }

        .cabezera {
            background: #46963f;
            color: white;
        }

        .cabezera2 {
            background: #081f44;
            color: white;
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="flex_col">
        <div class="card mb-3 border-bar">
            <div class="card-header bg-bar  p-2">
                <h5>Resultados Filtrados</h5>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-lg">
                        <label for="fecha">Desde:</label>
                        <div class='input-group date' id='Txt_Date01'>
                            <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-lg">
                        <label for="fecha">Hasta:</label>
                        <div class='input-group date' id='Txt_Date02'>
                            <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-lg">
                        <label for="DdlProce">Lugar de TM:</label>
                        <select id="DdlProce" class="form-control"></select>
                    </div>
                    <div class="col-lg">
                        <label for="DdlPrevi">Previsión:</label>
                        <select id="DdlPrevi" class="form-control"></select>
                    </div>
                    <div class="col-lg">
                        <label for="DdlAtenciones">Programa:</label>
                        <select id="DdlAtenciones" class="form-control"></select>
                    </div>
                    <%--  <div class="col-lg-1">
                   
                </div>
                <div class="col-lg-1">
                   
                </div>--%>
                </div>

                <div class="row">
                    <div class="col-lg">
                        <button id="Btn_Search" type="button" class="btn btn-block btn-buscar btn-sm"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                    </div>
                    <div class="col-lg">
                        <button id="Btn_Export" type="button" class="btn btn-block btn-success btn-sm"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="Id_conte">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar p-2">
                    <h5>Listado de Atenciones</h5>
                </div>
                <div>
                    <div id="Div_Tabla_Data" class="card-body" style="overflow: auto">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
