<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Lis_Env_Mues_Lab_2.aspx.vb" Inherits="Presentacion.Lis_Env_Mues_Lab_2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script src="/js/moment_es.js"></script>
    <script src="/js/moment.js"></script>
    <script>
        $(document).ready(function () {
            $("#Id_Conte").hide();
            Ajax_LugarTM();
            Ajax_Exam();

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

            $(".block_wait").fadeOut(0);
            $("#Div_Tabla").empty();
            $("#Div_Tabla").show();
            $("#Id_Conte").hide();

            //Registrar evento Click del Botón Buscar       
            $("#Btn_Buscar").click(function () {
                $("#Div_Tabla").empty();
                Ajax_DataTable();

            });

            //Registrar evento Click del Botón Excel       
            $("#Btn_Excel").click(function () {
                Ajax_Excel();
            });

            $("#Btn_Imprimir").click(function () {
                Ajax_PDF();
            });      
        });
    </script>
    <script>
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
                "url": "Lis_Env_Mues_Lab_2.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
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
                "url": "Lis_Env_Mues_Lab_2.aspx/Llenar_Ddl_Exam",
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

        //-------------------------------------------------- AJAX TABLA MAIN ----------------------------------------------|
        var Mx_Dtt = {
            List_Data: [
                {
                    "ID_T_MUESTRA": 0,
                    "ATE_NUM": 0,
                    "T_MUESTRA_DESC": 0,
                    "CB_DESC": 0,
                    "IDTM": 0,
                    "ID_ATENCION": 0,
                    "GMUE_DESC": 0,
                    "ATE_FECHA": 0,
                    "ATE_EST_RECEP": 0,
                    "EST_DESCRIPCION": 0,
                    "CF_DESC": 0,
                    "PAC_NOMBRE": 0,
                    "PAC_APELLIDO": 0,
                    "PAC_RUT": 0,
                    "PROC_DESC": 0,
                    "ID_PACIENTE": 0,
                    "ATE_AÑO": 0,
                    "ID_SEXO": 0,
                    "ATE_EST_RECHAZO": 0,
                    "ATE_EST_DERIVA": 0,
                    "ID_CODIGO_FONASA": 0,
                    "ATE_DET_V_ID_ESTADO": 0,
                    "ATE_DET_REV_ID_ESTADO": 0,
                    "ID_PROCEDENCIA": 0,
                    "PAC_FNAC": 0,
                    "ATE_NUM_INTERNO": 0,
                    "ID_ENVIO": 0, 
                    "ENVIO_NUM": 0, 
                    "USU_NIC": 0, 
                    "ID_USUARIO": 0,
                    "ENVIO_ETI_FECHA": 0
                }
            ],
            Dictionary: {
                "Aaaahhh": 213543
            }
        };

        function Ajax_DataTable() {
            modal_show();


            var Data_Par = JSON.stringify({
                "TIPO": $("#Ddl_Recep").val(),
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PRE": $("#Ddl_LugarTM").val(),
                "ID_CF": $("#Ddl_Exam").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_Env_Mues_Lab_2.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;

                    if (json_receiver.List_Data.length > 0) {
                        Mx_Dtt = json_receiver;
                        $("#Div_Tabla").empty();
                        $("#Div_Totales").empty();

                        for (i = 0; i < Mx_Dtt.List_Data.length; ++i) {
                            var date_x = Mx_Dtt.List_Data[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt.List_Data[i].ATE_FECHA = Date_Change;
                        }

                        for (i = 0; i < Mx_Dtt.List_Data.length; ++i) {
                            var date_x = Mx_Dtt.List_Data[i].ENVIO_ETI_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt.List_Data[i].ENVIO_ETI_FECHA = Date_Change;
                        }

                        $("#txtNate").text(Mx_Dtt.List_Data[0].NAte);
                        $("#txtNExa").text(Mx_Dtt.List_Data[0].NExa);
                        $("#txtRecepSi").text(Mx_Dtt.List_Data[0].recSi);
                        $("#txtRecepNo").text(Mx_Dtt.List_Data[0].recNo);
                        $("#txtValidadoSisisisisisoi").text(Mx_Dtt.List_Data[0].valiSi);
                        $("#txtValidadoNo").text(Mx_Dtt.List_Data[0].valiNo);
                        $("#txtRechaSi").text(Mx_Dtt.List_Data[0].rechSi);
                        $("#txtRechaNo").text(Mx_Dtt.List_Data[0].rechNo);

                        $("#txtTotal").text(Mx_Dtt.List_Data[0].total);


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

        var Mx_Dtt_Excel = [
    {
        "urls": ""
    }
        ];

        function Ajax_Excel() {
            modal_show();


            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "TIPO": $("#Ddl_Recep").val(),
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PRE": $("#Ddl_LugarTM").val(),
                "ID_CF": $("#Ddl_Exam").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_Env_Mues_Lab_2.aspx/Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    let xURL = "";
                    xURL = resp.d;

                    if (xURL != null) {
                        if (xURL.match(/^http(s?):\/\//gi) == null) {
                            xURL = "http://" + xURL;
                        }

                        var xMsg = `<p>Se ha generado correctamente el archivo excel. `;
                        xMsg += `Si no se ha iniciado la descarga pulse <a href="${xURL}">aquí</a>.</p>`;
                        $("#mdlExcel .modal-body").html(xMsg);

                        window.open(xURL, "_blank");
                    } else {
                        var xMsg = `<p>No se ha generado ningún archivo debido a que la `;
                        xMsg += `búsqueda no retorna resultados.</p>`;
                        $("#mdlExcel .modal-body").html(xMsg);
                    }

                    $("#mdlExcel").modal();
                    Hide_Modal();
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        var Mx_Dtt_PDF = [
{
    "urls": ""
}
        ];

        function Ajax_PDF() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "TIPO": $("#Ddl_Recep").val(),
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PRE": $("#Ddl_LugarTM").val(),
                "ID_CF": $("#Ddl_Exam").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Lis_Env_Mues_Lab_2.aspx/PDFF",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    let xURL = "";
                    xURL = resp.d;

                    if (xURL != null) {
                        if (xURL.match(/^http(s?):\/\//gi) == null) {
                            xURL = "http://" + xURL;
                        }

                        var xMsg = `<p>Se ha generado correctamente el archivo PDF. `;
                        xMsg += `Si no se ha iniciado la descarga pulse <a href="${xURL}">aquí</a>.</p>`;
                        $("#mdlExcel .modal-body").html(xMsg);

                        window.open(xURL, "_blank");
                    } else {
                        var xMsg = `<p>No se ha generado ningún archivo debido a que la `;
                        xMsg += `búsqueda no retorna resultados.</p>`;
                        $("#mdlExcel .modal-body").html(xMsg);
                    }

                    $("#mdlExcel").modal();
                    Hide_Modal();
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

    </script>


    <%-- Funciones de Llenado de Elementos --%>
    <script>
        //Llenar DropDownList Lugar de TM
        function Fill_Ddl_LugarTM() {
            $("#Ddl_LugarTM").empty();

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
        function Fill_Ddl_Exam() {
            $("#Ddl_Exam").empty();

            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Exam");
            for (y = 0; y < Mx_Exam.length; ++y) {
                $("<option>", {
                    "value": Mx_Exam[y].ID_CODIGO_FONASA
                }).text(Mx_Exam[y].CF_DESC).appendTo("#Ddl_Exam");
            }

        };


    </script>

    <script>

        //---------------------------------------------------- TABLA  ------------------.........-----------------------------|
        function Fill_DataTable() {
            let super_contador = 0;

            $("<table>", {
                "id": "DataTable_Totales",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Totales");

            $("#DataTable_Totales").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Totales").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Totales thead").attr("class", "cabezera");
            $("#DataTable_Totales thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido"}).text("Etiqueta"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Total")

                )
            );

            for (var leKey in Mx_Dtt.Dictionary) {
                $("#DataTable_Totales tbody").append(
                    $("<tr>").append(
                        $("<td>", { class: "textoReducido" }).text(leKey),
                        $("<td>", { class: "textoReducido text-center" }).text(Mx_Dtt.Dictionary[leKey])
                    )
                );

                super_contador += Mx_Dtt.Dictionary[leKey]

            }
            $("#DataTable_Totales tbody").append(
                    $("<tr>").append(
                        $("<td>", { class: "textoReducido negrin" }).text("TOTAL"),
                        $("<td>", { class: "textoReducido text-center negrin" }).text(super_contador)
                    )
                );

            //-----------------------------------------------------------------------------------------------------------------------




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
                    $("<th>", { "class": "textoReducido text-center" }).text("#"),
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Interno"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Edad"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha Atención"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha Envío"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar de TM"),
                    $("<th>", { "class": "textoReducido" }).text("Etiqueta"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Estado"),
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Lote"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Usuario")

                )
            );
            let xi = 0;
            let indexx = 1;
            for (i = 0; i < Mx_Dtt.List_Data.length; i++) {
                if (xi == 0) {
                    $("#DataTable tbody").append(
                        $("<tr>").append(
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(indexx),
                            $("<td>").css("text-align", "center").text(function () {
                                if (i > 0){
                                    if (Mx_Dtt.List_Data[i-1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    }else {
                                        $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_NUM);
                                    }
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_NUM);
                                }
                            }),
                            $("<td>").css("text-align", "center").text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_NUM_INTERNO);
                                    }
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_NUM_INTERNO);
                                }
                            }),
                            $("<td>").text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).text(Mx_Dtt.List_Data[i].PAC_NOMBRE + " " + Mx_Dtt.List_Data[i].PAC_APELLIDO);
                                    }

                                } else {
                                    $(this).text(Mx_Dtt.List_Data[i].PAC_NOMBRE + " " + Mx_Dtt.List_Data[i].PAC_APELLIDO);
                                }
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).text(Mx_Dtt.List_Data[i].ATE_AÑO + " Años");
                                    }

                                } else {
                                    $(this).text(Mx_Dtt.List_Data[i].ATE_AÑO + " Años");
                                }
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).css("cssText", "text-align:center;").text(moment(Mx_Dtt.List_Data[i].ATE_FECHA).format("DD/MM/YYYY HH:mm:ss"));
                                    }

                                } else {
                                    $(this).css("cssText", "text-align:center;").text(moment(Mx_Dtt.List_Data[i].ATE_FECHA).format("DD/MM/YYYY HH:mm:ss"));
                                }                            
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).css("cssText", "text-align:center;").text(moment(Mx_Dtt.List_Data[i].ENVIO_ETI_FECHA).format("DD/MM/YYYY HH:mm:ss"));
                                    }

                                } else {
                                    $(this).css("cssText", "text-align:center;").text(moment(Mx_Dtt.List_Data[i].ENVIO_ETI_FECHA).format("DD/MM/YYYY HH:mm:ss"));
                                }              
                            }),
                            $("<td>").text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    }
                                    else {
                                        $(this).text(Mx_Dtt.List_Data[i].PROC_DESC);
                                    }
                                } else {
                                    $(this).text(Mx_Dtt.List_Data[i].PROC_DESC);
                                }
                            }),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("[" + Mx_Dtt.List_Data[i].CB_DESC + "]" + " - " + Mx_Dtt.List_Data[i].T_MUESTRA_DESC),
                            $("<td>").css("text-align", "center").text(function () {
                                if (Mx_Dtt.List_Data[i].EST_DESCRIPCION == "RECEP.") {
                                    $(this).css("cssText", "background-color:#f5b0e5 !important;  text-align:center;").text(Mx_Dtt.List_Data[i].EST_DESCRIPCION);
                                }
                                else {
                                    $(this).css("cssText", "background-color:#88d6e2 !important; text-align:center;").text(Mx_Dtt.List_Data[i].EST_DESCRIPCION);
                                }
                            }),
                            $("<td>").css("text-align", "center").text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ENVIO_NUM);
                                    }
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ENVIO_NUM);
                                }
                            }),
                            $("<td>").css("text-align", "center").text(function () {
                                if (i > 0) {
                                    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].USU_NIC);
                                    }
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].USU_NIC);
                                }
                            })
                        )
                    );
                    indexx++;
                } else if ((((xi > 0) && (Mx_Dtt.List_Data[xi].CB_DESC != Mx_Dtt.List_Data[xi - 1].CB_DESC))) || Mx_Dtt.List_Data[xi].ATE_NUM != Mx_Dtt.List_Data[xi - 1].ATE_NUM || Mx_Dtt.List_Data[xi].T_MUESTRA_DESC != Mx_Dtt.List_Data[xi - 1].T_MUESTRA_DESC) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(indexx),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_NUM);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_NUM);
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_NUM_INTERNO);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ATE_NUM_INTERNO);
                            }
                        }),
                        $("<td>").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).text(Mx_Dtt.List_Data[i].PAC_NOMBRE + " " + Mx_Dtt.List_Data[i].PAC_APELLIDO);
                                }

                            } else {
                                $(this).text(Mx_Dtt.List_Data[i].PAC_NOMBRE + " " + Mx_Dtt.List_Data[i].PAC_APELLIDO);
                            }
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).text(Mx_Dtt.List_Data[i].ATE_AÑO + " Años");
                                }

                            } else {
                                $(this).text(Mx_Dtt.List_Data[i].ATE_AÑO + " Años");
                            }
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(moment(Mx_Dtt.List_Data[i].ATE_FECHA).format("DD/MM/YYYY HH:mm:ss"));
                                }

                            } else {
                                $(this).css("cssText", "text-align:center;").text(moment(Mx_Dtt.List_Data[i].ATE_FECHA).format("DD/MM/YYYY HH:mm:ss"));
                            }
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(moment(Mx_Dtt.List_Data[i].ENVIO_ETI_FECHA).format("DD/MM/YYYY HH:mm:ss"));
                                }

                            } else {
                                $(this).css("cssText", "text-align:center;").text(moment(Mx_Dtt.List_Data[i].ENVIO_ETI_FECHA).format("DD/MM/YYYY HH:mm:ss"));
                            }
                        }),
                        $("<td>").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                }
                                else {
                                    $(this).text(Mx_Dtt.List_Data[i].PROC_DESC);
                                }
                            } else {
                                $(this).text(Mx_Dtt.List_Data[i].PROC_DESC);
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("[" + Mx_Dtt.List_Data[i].CB_DESC + "]" + " - " + Mx_Dtt.List_Data[i].T_MUESTRA_DESC),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt.List_Data[i].EST_DESCRIPCION == "RECEP.") {
                                $(this).css("cssText", "background-color:#f5b0e5 !important;  text-align:center;").text(Mx_Dtt.List_Data[i].EST_DESCRIPCION);
                            }
                            else {
                                $(this).css("cssText", "background-color:#88d6e2 !important; text-align:center;").text(Mx_Dtt.List_Data[i].EST_DESCRIPCION);
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            //if (i > 0) {
                            //    if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                            //        $(this).css("cssText", "text-align:center;").text("");
                            //    } else {
                            //        $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ENVIO_NUM);
                            //    }
                            //} else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].ENVIO_NUM);
                            //}
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt.List_Data[i - 1].ATE_NUM == Mx_Dtt.List_Data[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].USU_NIC);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt.List_Data[i].USU_NIC);
                            }
                        })
                    )
                );
                indexx++;
                }
                xi++;
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
        .negrin{
            font-weight: 900;
        }

        .mayus {
            text-transform: uppercase;
        }

        .highlights {
            width: 90%;
            max-height: 60vh; /* Ancho y alto fijo */
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
    <%--//---------------------------------------------- MODAL LISTADO DE EXÁMENES DE LA ATENCIÓN ------------------------------------%>
    <div class="modal fade" id="eModal" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Listado de Recepción de Exámenes por Tubo</h4>
                </div>
                <div class="modal-header">
                    <div class="col">
                        <h6 class="modal-title" id="numerito">num ATEEE</h6>
                        <h6 class="modal-title" id="nombrecito">Nombreee</h6>
                    </div>
                </div>
                <div class="modal-body">
                    <form>
                        <div id="Div_Tabla_Listado_Exa_Ate" style="width: 100%;" class="table-responsive"></div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Salir</button>
                </div>
            </div>
        </div>
    </div>
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
        <div class="col-lg-1"></div>
        <div class="col-lg"> 
            <div class="card mb-3 border-bar">
    <div class="card-header bg-bar">
        <h5 style="text-align: center; padding: 5px;">
            <i class="fa fa-edit"></i>
            Listado de Estados de Exámenes por Tubos
        </h5>
    </div>

    <div class="row mb-3" style="margin-left:2px; margin-right: 2px;">
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
            <label for="Ddl_Exam">Exámenes:</label>
            <select id="Ddl_Exam" class="form-control">
                <option value="0">Seleccionar</option>
            </select>
        </div>
        <div class="col-md">
            <label for="Ddl_Recep">Estado:</label>
            <select id="Ddl_Recep" class="form-control">
                <option value="0">Todos</option>
                <option value="5">< Enviado ></option>
                <option value="7">< Espera ></option>
            </select>
        </div>
    </div>
    <div class="row" style="margin-left:2px; margin-right: 2px;">
        <div class="col-md">
            <button id="Btn_Buscar" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i> Buscar</button>
        </div>
    
        <div class="col-md">
            <button id="Btn_Excel" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i> Excel</button>
        </div>
        <div class="col-md">
            <button id="Btn_Imprimir" class="btn btn-warning btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-paper-plane mr-2"></i> Imprimir</button>
        </div>
    </div>


    <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
    <div class="row" id="Id_Conte">
        <div class="col-md-12" id="Paciente">
            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i> Listado de Determinaciones</h5>
            <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
            <br />    
            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-table"></i> TOTALES</h5>
            <div id="Div_Totales" style="width: 100%; border-radius: 5px;" class="highlights"></div>
        </div>
    </div>
    </div>
    </div>
    <div class="col-lg-1"></div>
    </div>
</asp:Content>