<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Lis_Tot_Exams.aspx.vb" Inherits="Presentacion.Lis_Tot_Exams" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script>
        $(document).ready(function () {
            $("#Id_Conte").hide();
            Ajax_LugarTM();
            //Ajax_Exam();

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
                Ajax_Pruebas();

            });
            //Registrar evento Click del Botón Excel       
            $("#Btn_Excel").click(function () {
                Ajax_Excel();

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

            $.ajax({
                "type": "POST",
                "url": "Lis_Tot_Exams.aspx/Llenar_Ddl_LugarTM",
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

            $.ajax({
                "type": "POST",
                "url": "Lis_Tot_Exams.aspx/Llenar_Ddl_Exam",
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
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        //------------------------------------------------ AJAX PRUEBAS -------------------------------------------|
        var Mx_Pruebas = [
        {
            CANTIDAD_PRUEBAS: 0,
            ID_PRUEBA: 0,
            PRU_DESC: 0,
            CF_CORTO: 0
        }
        ];

        function Ajax_Pruebas() {

            var Data_Par = JSON.stringify({
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PRO": $("#Ddl_LugarTM").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Lis_Tot_Exams.aspx/IRIS_WEBF_LIS_TOT_EXAMS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Pruebas = json_receiver;

                        Ajax_DataTable();
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

        //-------------------------------------------------- AJAX TABLA MAIN ----------------------------------------------|
        var Mx_Dtt = [
            {
                ATE_NUM:0,
                ATE_AÑO:0,
                ATE_MES:0,
                ATE_DIA:0, 
                ID_PRUEBA:0,
                PAC_NOMBRE:0,
                PAC_APELLIDO:0,
                PAC_FNAC: 0,
                PAC_RUT:0,
                ID_CODIGO_FONASA:0,
                ID_SEXO:0,
                ATE_RESULTADO:0,
                HO_CC:0,
                HO_FechaAtencion:0
            }
        ];

        function Ajax_DataTable() {
            modal_show();


            var Data_Par = JSON.stringify({
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_PRO": $("#Ddl_LugarTM").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Lis_Tot_Exams.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt = json_receiver;
                        $("#Div_Tabla").empty();

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
                "ID_PRO": $("#Ddl_LugarTM").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Lis_Tot_Exams.aspx/Excel",
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
            $("#DataTable thead").attr("id", "aidi");

            $("#DataTable thead").append(
                $("<tr>", { "id": "hola" }).append(
                    $("<th>", { "class": "textoReducido text-center" }).text("#"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Solicitud"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha Solicitud"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Ate. Num"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Apellidos"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Nombre"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Edad"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Sexo"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Rut")
                )
            );

            for (i = 0; i < Mx_Pruebas.length; i++) {
                $("#hola").append(
                        $("<th>", { id: Mx_Pruebas[i].ID_PRUEBA, class: "textoReducido" }).text(i + 1 + " - " + Mx_Pruebas[i].ID_PRUEBA + " - " + Mx_Pruebas[i].CF_CORTO + " - " + Mx_Pruebas[i].PRU_DESC)
                    )
            };
            let xi = 0;
            for (i = 0; i < Mx_Dtt.length; i++) {
                let atee_nummm = Mx_Dtt[i].ATE_NUM
                if (xi == 0) {
                    
                    console.log("xi = 0");
                    $("#DataTable tbody").append(
                        $("<tr>", { "id": "chao" + xi }).append(
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(xi + 1),
                            $("<td>").text(function () {                                                                                                                            //HO_CC
                                if (i > 0) {
                                    if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).text(Mx_Dtt[i].HO_CC);
                                    }

                                } else {
                                    $(this).text(Mx_Dtt[i].HO_CC);
                                }
                            }),
                            $("<td>").text(function () {                                                                                                                            //FECHA SOLICITUD
                                if (i > 0) {
                                    if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        //$(this).text(moment(Mx_Dtt[i].ATE_DET_V_FECHA).format("L"));
                                        $(this).text(Mx_Dtt[i].HO_FechaAtencion);
                                    }

                                } else {
                                    //$(this).text(moment(Mx_Dtt[i].ATE_DET_V_FECHA).format("L"));
                                    $(this).text(Mx_Dtt[i].HO_FechaAtencion);
                                }
                            }),
                            $("<td>").text(function () {                                                                                                                            //ATE NUM
                                if (i > 0) {
                                    if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).text(Mx_Dtt[i].ATE_NUM);
                                    }

                                } else {
                                    $(this).text(Mx_Dtt[i].ATE_NUM);
                                }
                            }),
                            $("<td>").text(function () {                                                                                                                            //APELLIDOS
                                if (i > 0) {
                                    if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).text(Mx_Dtt[i].PAC_APELLIDO);
                                    }

                                } else {
                                    $(this).text(Mx_Dtt[i].PAC_APELLIDO);
                                }
                            }),
                            $("<td>").text(function () {                                                                                                                            //NOMBRE
                                if (i > 0) {
                                    if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).text(Mx_Dtt[i].PAC_NOMBRE);
                                    }

                                } else {
                                    $(this).text(Mx_Dtt[i].PAC_NOMBRE);
                                }
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {                                                                       //EDAD
                                if (i > 0) {
                                    if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_AÑO + "A" + " " + Mx_Dtt[i].ATE_MES + "M" + " " + Mx_Dtt[i].ATE_DIA + "D");
                                    }

                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_AÑO + "A" + " " + Mx_Dtt[i].ATE_MES + "M" + " " + Mx_Dtt[i].ATE_DIA + "D");
                                }
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {                                                                       //SEXO
                                if (i > 0) {
                                    if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        if (Mx_Dtt[i].ID_SEXO == 1) {
                                            $(this).text("Masculino");
                                        } else {
                                            $(this).text("Femenino");
                                        }

                                    }

                                } else {
                                    if (Mx_Dtt[i].ID_SEXO == 1) {
                                        $(this).text("Masculino");
                                    } else {
                                        $(this).text("Femenino");
                                    }
                                }
                            }),
                            $("<td>").text(function () {                                                                                                                            //RUT
                                if (i > 0) {
                                    if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                        $(this).css("cssText", "text-align:center;").text("");
                                    } else {
                                        $(this).text(Mx_Dtt[i].PAC_RUT);
                                    }
                                } else {
                                    $(this).text(Mx_Dtt[i].PAC_RUT);
                                }
                            })

                        )

                    );
                    for (ii = 0; ii < Mx_Dtt.length; ii++) {
                        for (iii = 0; iii < Mx_Pruebas.length; iii++) {
                            if ((Mx_Pruebas[iii].ID_PRUEBA == Mx_Dtt[ii].ID_PRUEBA) && (atee_nummm == Mx_Dtt[ii].ATE_NUM)) {
                                console.log("iguales");
                            $("#chao" + xi).append($("<td>", { "align": "center", class: "textoReducido" }).text(Mx_Dtt[ii].ATE_RESULTADO))
                            } else if (atee_nummm == Mx_Dtt[ii].ATE_NUM){
                            $("#chao" + xi).append($("<td>", { "align": "center", class: "textoReducido" }).text(" "))
                        }
                        }

                    };
                    //for (ii = 0; ii < Mx_Pruebas.length; ii++) {
                    //    //for (iii = 0; iii < Mx_Dtt.length; iii++) {
                    //    if (Mx_Pruebas[ii].ID_PRUEBA == Mx_Dtt[i].ID_PRUEBA) {
                    //        $("#chao" + i).append($("<td>", { "align": "center", class: "textoReducido" }).text(Mx_Dtt[i].ATE_RESULTADO))
                    //    } else {
                    //        $("#chao" + i).append($("<td>", { "align": "center", class: "textoReducido" }).text(" "))
                    //    }
                    //    //}

                    //};
                    xi++;
                } else if ((xi > 0) && (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM)) {
                    for (ii = 0; ii < Mx_Dtt.length; ii++) {
                        for (iii = 0; iii < Mx_Pruebas.length; iii++) {
                            if ((Mx_Pruebas[iii].ID_PRUEBA == Mx_Dtt[ii].ID_PRUEBA) && (atee_nummm == Mx_Dtt[ii].ATE_NUM)) {
                                $("#chao" + xi).append($("<td>", { "align": "center", class: "textoReducido" }).text(Mx_Dtt[ii].ATE_RESULTADO))
                            } else if (atee_nummm == Mx_Dtt[ii].ATE_NUM) {
                                $("#chao" + xi).append($("<td>", { "align": "center", class: "textoReducido" }).text(" "))
                            }
                        }

                    };
                    xi++;
                } else {
                    console.log("else");
                $("#DataTable tbody").append(
                    $("<tr>", { "id": "chao" + xi }).append(
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>").text(function () {                                                                                                                            //HO_CC
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).text(Mx_Dtt[i].HO_CC);
                                }

                            } else {
                                $(this).text(Mx_Dtt[i].HO_CC);
                            }
                        }),
                        $("<td>").text(function () {                                                                                                                            //FECHA SOLICITUD
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    //$(this).text(moment(Mx_Dtt[i].ATE_DET_V_FECHA).format("L"));
                                    $(this).text(Mx_Dtt[i].HO_FechaAtencion);
                                }

                            } else {
                                //$(this).text(moment(Mx_Dtt[i].ATE_DET_V_FECHA).format("L"));
                                $(this).text(Mx_Dtt[i].HO_FechaAtencion);
                            }
                        }),
                        $("<td>").text(function () {                                                                                                                            //ATE NUM
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).text(Mx_Dtt[i].ATE_NUM);
                                }

                            } else {
                                $(this).text(Mx_Dtt[i].ATE_NUM);
                            }
                        }),
                        $("<td>").text(function () {                                                                                                                            //APELLIDOS
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).text(Mx_Dtt[i].PAC_APELLIDO);
                                }

                            } else {
                                $(this).text(Mx_Dtt[i].PAC_APELLIDO);
                            }
                        }),
                        $("<td>").text(function () {                                                                                                                            //NOMBRE
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).text(Mx_Dtt[i].PAC_NOMBRE);
                                }

                            } else {
                                $(this).text(Mx_Dtt[i].PAC_NOMBRE);
                            }
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {                                                                       //EDAD
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_AÑO + "A" + " " + Mx_Dtt[i].ATE_MES + "M" + " " + Mx_Dtt[i].ATE_DIA + "D");
                                }

                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_AÑO + "A" + " " + Mx_Dtt[i].ATE_MES + "M" + " " + Mx_Dtt[i].ATE_DIA + "D");
                            }
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {                                                                       //SEXO
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    if (Mx_Dtt[i].ID_SEXO == 1) {
                                        $(this).text("Masculino");
                                    } else {
                                        $(this).text("Femenino");
                                    }

                                }

                            } else {
                                if (Mx_Dtt[i].ID_SEXO == 1) {
                                    $(this).text("Masculino");
                                } else {
                                    $(this).text("Femenino");
                                }
                            }
                        }),
                        $("<td>").text(function () {                                                                                                                            //RUT
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).text(Mx_Dtt[i].PAC_RUT);
                                }
                            } else {
                                $(this).text(Mx_Dtt[i].PAC_RUT);
                            }
                        })

                    )

                );
                    for (ii = 0; ii < Mx_Pruebas.length; ii++) {
                        //for (iii = 0; iii < Mx_Dtt.length; iii++) {
                        if (Mx_Pruebas[ii].ID_PRUEBA == Mx_Dtt[i].ID_PRUEBA) {
                            $("#chao" + xi).append($("<td>", { "align": "center", class: "textoReducido" }).text(Mx_Dtt[i].ATE_RESULTADO))
                        } else {
                            $("#chao" + xi).append($("<td>", { "align": "center", class: "textoReducido" }).text(" "))
                        }
                        //}

                    };
                    xi++;
                }
                //$("#DataTable").DataTable({
                //    "bSort": true,
                //    "iDisplayLength": 100,
                //    "language": {
                //        "lengthMenu": "Mostrar: _MENU_",
                //        "zeroRecords": "No hay concidencias",
                //        "info": "Mostrando Página _PAGE_ de _PAGES_",
                //        "infoEmpty": "No hay concidencias",
                //        "infoFiltered": "(Se buscó en _MAX_ registros )",
                //        "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                //        "paginate": {
                //            "previous": "Anterior",
                //            "next": "Siguiente"
                //        }
                //    }
                //});

                $("#DataTable tbody tr").click(function () {
                    $("#DataTable tbody tr").removeClass("active");
                    $(this).addClass("active");
                });
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
        .enviado {
            background-color:#5bbdff;
        }
        .cargado {
        background-color: #ff5b5b;
        }
        .disponible {
            background-color: #60e073;
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
                    <h4 class="modal-title" id="sss">Listado de Recepción de Exámenes</h4>
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
            Listado de Exámenes y Resultados por Pacientes
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
      <%--  <div class="col-md">
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
        </div>--%>
    </div>
    <div class="row" style="margin-left:2px; margin-right: 2px;">
        <div class="col-md">
            <button id="Btn_Buscar" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i> Buscar</button>
        </div>
    
        <div class="col-md">
            <button id="Btn_Excel" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i> Excel</button>
        </div>
    </div>


    <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
    <div class="row" id="Id_Conte">
        <div class="col-md-12" id="Paciente">
            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i>Listado de Exámenes</h5>
            <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
        </div>
    </div>
    </div>
    </div>
    <div class="col-lg-1"></div>
    </div>
</asp:Content>