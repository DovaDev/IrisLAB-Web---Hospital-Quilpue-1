<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Excel_TP_Real_ADM.aspx.vb" Inherits="Presentacion.Excel_TP_Real_ADM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="/js/moment_es.js"></script>
    <script src="/js/moment.js"></script>
    <script src="js/KeyTable.js"></script>
    <script>
        $(document).ready(function () {
            // var keys = new KeyTable();
            Ajax_LugarTM();
            $("#Btn_Modal").click(function () {

                $('#eModal2').modal('show');
            });

            $("#btnguardar").click(function () {
                Ajax_DataTable_agregar();
                $('#eModal2').modal('hide');
            });

            $("#Ddl_LugarTM").change(function () {
                ////Fill_DataTable();
                $("#DataTable tbody").empty();
                add_row();
            });
            //$("#Id_Conte").hide();
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
                    Ajax_DataTable();
                }
            });
            $("#Btn_Excel").click(function () {
                if ($("#Ddl_Exam").val() == 0) {
                    $("#mError_AAH h4").text("Seleccione");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione un examen.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_Excel();
                }

            });


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
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha y hora ingreso Irislab"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Muestras recepcionadas"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Muestras enviadas"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Folio Hoja trabajo"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha envio HGF"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha recepcion Resultados"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha Validacion en Irislab"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Eliminar")
                )
            );

            //add_row();
            $(document).on('click', '.borrar', function (event) {
                var rowstota = document.getElementById("DataTable").rows.length;
                var ff = $(this).parent().parent().children().children('.td_input').attr('data-id');
                event.preventDefault();
                ajax_eliminar(ff);
                for (i = 0; i < Mx_Dtt.length; i++) {

                    if (Mx_Dtt[i].ID_CODIGO_FONASA == ff) {
                        Mx_Dtt.splice(i, 1);
                    }
                    $(this).closest('tr').remove();

                }



            });
        });



    </script>
    <script>
        function ajax_eliminar(ID_WEN) {
            //OCULTAMOS EL MODAL DEL PACIENTE



            //Debug
            var Data_Par44 = JSON.stringify({
                "ID": ID_WEN
            });

            $.ajax({
                "type": "POST",
                "url": "Excel_TP_Real_ADM.aspx/Eliminar",
                "data": Data_Par44,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data_ATENDIDO => {

                    buscar_avis();

                },
                "error": data_ATENDIDO => {



                }
            });
        }
        function add_row() {
            var rowstota = document.getElementById("DataTable").rows.length;
            var xvalue = $("#DataTable tr:last input").val();
            $("#DataTable tbody").append(
                $("<tr>", {
                    //"onclick": `Ajax_Redirect("` + Mx_Dtt[i].ID_FCL + `")`,
                    "class": "manito"
                }).append(

                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("#"),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": "",
                                "data-cod": "8",
                                "class": "td_input jump GG",
                                "value": "",
                            })
                        }())),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            if ($("#Ddl_LugarTM").val() == 0) {
                                return $("<input>", {
                                    "data-id": "",
                                    "data-cod": "9",
                                    "class": "td_input jump GG",
                                    "value": "",
                                })
                            } else {
                                return $("<input>", {
                                    "data-id": "",
                                    "data-cod": "9",
                                    "class": "td_input jump GG",
                                    "value": $("#Ddl_LugarTM option:selected").text(),
                                })
                            }

                        }())),

                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": "",
                                "data-cod": "1",
                                "class": "td_input jump GG",
                                "value": "",
                            })
                        }())),

                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input

                                return $("<input>", {
                                    "type": "date",
                                    "data-id": "",
                                    "data-cod": "10",
                                    "class": "td_input jump feCH GG",
                                    "value": "",
                                })


                            }())),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": "",
                                "data-cod": "2",
                                "class": "td_input jump GG",
                                "value": "",
                            })
                        }())),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": "",
                                "data-cod": "3",
                                "class": "td_input jump GG",
                                "value": "",
                            })
                        }())),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": "",
                                "data-cod": "4",
                                "class": "td_input jump GG",
                                "value": "",
                            })
                        }())),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input

                            return $("<input>", {
                                "type": "date",
                                "data-id": "",
                                "data-cod": "5",
                                "class": "td_input jump feCH GG",
                                "value": 4,
                            })


                        }())),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input

                            return $("<input>", {
                                "type": "date",
                                "data-id": "",
                                "data-cod": "6",
                                "class": "td_input jump feCH GG",
                                "value": "",
                            })


                        }())),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {

                            //Retornar un campo input
                            return $("<input>", {
                                "type": "date",
                                "data-id": "",
                                "data-cod": "7",
                                "class": "td_input jump feCH GG",
                                "value": "",
                            })


                        }()))

                )
            )

            $(".td_input.GG").keydown(function EnterEvent(e) {
                e.stopImmediatePropagation();
                let keycode = e.keyCode;
                if (e.keyCode == 13) {
                    let obj_transfer = GET_Elem_Txt(e);
                    Ajax_DataTable_agregar(obj_transfer);
                } else if (keycode == 38) {
                    $(this).closest('tr').prev().find('td:eq(' + $(this).closest('td').index() + ')').find('.td_input').focus();
                } else if (keycode == 40) {
                    console.log("40");
                    $(this).closest('tr').next().find('td:eq(' + $(this).closest('td').index() + ')').find('.td_input').focus();
                } else if (keycode == 37) {
                    console.log("37");
                    $(this).closest('td').prev().find('.td_input').focus();
                }
                else if (keycode == 39) {
                    console.log("37");
                    $(this).closest('td').next().find('.td_input').focus();
                }
                console.log(keycode);
            });




            //var xLen = $(".GG");
            //$(".GG").eq(0).focus();
        }

        let GET_Elem_Txt = (me) => {
            let obj_data = {
                cod_barra: "",
                //contenedor: "",
                caja: "",
                fecha_ingreso: "",
                muestras_recepc: "",
                muestras_enviadas: "",
                folio: "",
                fecha_envio: "",
                fecha_recepc: "",
                fecha_validac: ""
            };

            let getInput = (number) => {
                let objTr = $(me.currentTarget).parent().parent();
                return objTr.children("td").eq(number + 1).children("input");
            };

            obj_data.cod_barra = getInput(0).val();
            obj_data.contenedor = getInput(1).val();
            obj_data.caja = getInput(2).val();
            obj_data.fecha_ingreso = getInput(3).val();
            obj_data.muestras_recepc = getInput(4).val();
            obj_data.muestras_enviadas = getInput(5).val();
            obj_data.folio = getInput(6).val();
            obj_data.fecha_envio = getInput(7).val();
            obj_data.fecha_recepc = getInput(8).val();
            obj_data.fecha_validac = getInput(9).val();

            return obj_data;
        };

        var Mx_Dtt = [
          {
              Cod_Barra: "",
              Establecimiento_Contenedor: "",
              Caja_Transporte: "",
              Fecha_irislab: new Date,
              Muestras_recepcionadas: "",
              Muestras_enviadas: "",
              Folio_Hoja_trabajo: "",
              Fecha_envio_HGF: new Date,
              Fecha_recepcion_Resultados: new Date,
              Fecha_Validacion_en_Irislab: new Date,
              num: "",
              ID: ""
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
                "url": "Excel_TP_Real_ADM.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt = JSON.parse(json_receiver);
                        //$("#Div_Tabla").empty();

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


                        //$("#Id_Conte").show();
                    } else {

                        $("#DataTable tbody").empty();
                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                        //$("#Id_Conte").hide();
                    }
                    //$(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        function Ajax_DataTable_agregar(value) {

            let obj_transfer = {
                cod_barra: "",
                contenedor: "",
                caja: "",
                fecha_ingreso: "",
                muestras_recepc: "",
                muestras_enviadas: "",
                folio: "",
                fecha_envio: "",
                fecha_recepc: "",
                fecha_validac: ""
            };
            obj_transfer = value;
            modal_show();
            let fecha_y_hora = "";
            if (obj_transfer.fecha_ingreso != "") {
                fecha_y_hora = moment(obj_transfer.fecha_ingreso).format("DD-MM-YYYY");
            } else {
                fecha_y_hora = "01-01-1980";
            }

            let Fecha_envio_HGF = "";
            if (obj_transfer.fecha_envio != "") {
                Fecha_envio_HGF = moment(obj_transfer.fecha_envio).format("DD-MM-YYYY");
            } else {
                Fecha_envio_HGF = "01-01-1980";
            }

            let Fecha_recepcion_Resultados = "";
            if (obj_transfer.fecha_recepc != "") {
                Fecha_recepcion_Resultados = moment(obj_transfer.fecha_recepc).format("DD-MM-YYYY");
            } else {
                Fecha_recepcion_Resultados = "01-01-1980";
            }

            let Fecha_Validacion_en_Irislab = "";
            if (obj_transfer.fecha_validac != "") {
                Fecha_Validacion_en_Irislab = moment(obj_transfer.fecha_validac).format("DD-MM-YYYY");
            } else {
                Fecha_Validacion_en_Irislab = "01-01-1980";
            }

            var Data_Par = JSON.stringify({

                "Cod_barra": obj_transfer.cod_barra,
                "Establecimiento_Contenedor": obj_transfer.contenedor,
                "Caja_Transporte": obj_transfer.caja,
                "Fecha_irislab": fecha_y_hora,
                "Muestras_recepcionadas": obj_transfer.muestras_recepc,
                "Muestras_enviadas": obj_transfer.muestras_enviadas,
                "Folio_Hoja_trabajo": obj_transfer.folio,
                "Fecha_envio_HGF": Fecha_envio_HGF,
                "Fecha_recepcion_Resultados": Fecha_recepcion_Resultados,
                "Fecha_Validacion_en_Irislab": Fecha_Validacion_en_Irislab,

            });

            $.ajax({
                "type": "POST",
                "url": "Excel_TP_Real_ADM.aspx/Ajax_DataTable_agregar",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver == "null") {

                        Mx_Dtt = JSON.parse(json_receiver);
                        //Ajax_LugarTM();
                        Ajax_DataTable();
                        //$("#Div_Tabla").empty();

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
                        $("#Fecha_Validacion_en_Irislab").val(4);
                        $("#Fecha_recepcion_Resultados").val(4);
                        $("#Fecha_envio_HGF").val(4);
                        $("#fecha_y_hora").val("");
                        $("#Cod_barra").val("");
                        $("#Establecimiento_Contenedor").val("");
                        $("#Caja_Transporte").val("");
                        $("#Muestras_recepcionadas").val("");
                        $("#Muestras_enviadas").val("");
                        $("#Folio_Hoja_trabajo").val("");
                        Hide_Modal();


                        //$("#Id_Conte").show();
                    } else {


                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                        //$("#Id_Conte").hide();
                    }
                    //$(".block_wait").fadeOut(500);
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
            modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Excel_TP_Real_ADM.aspx/Llenar_Ddl_LugarTM",
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
                "url": "Excel_TP_Real_ADM.aspx/Excel",
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

            $("<option>",
            {
                "value": "0"
            }
            ).text("Todos").appendTo("#Ddl_LugarTM");
            Mx_Dtt_LugarTM.forEach(aaa => {
                $("<option>",
                    {
                        "value": 1
                    }
                ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
            });


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
            $("#DataTable tbody").empty();
            for (i = 0; i < Mx_Dtt.length; i++) {

                $("#DataTable tbody").append(
                    $("<tr>", {
                        //"onclick": `Ajax_Redirect("` + Mx_Dtt[i].ID_FCL + `")`,
                        "class": "manito"
                    }).append(

                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<input>", {
                                    "data-id": Mx_Dtt[i].ID,
                                    "data-cod": "8",
                                    "class": "td_input jump",
                                    "value": Mx_Dtt[i].Cod_Barra,
                                })
                            }())),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<input>", {
                                    "data-id": Mx_Dtt[i].ID,
                                    "data-cod": "9",
                                    "class": "td_input jump",
                                    "value": Mx_Dtt[i].Establecimiento_Contenedor,
                                })
                            }())),

                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<input>", {
                                    "data-id": Mx_Dtt[i].ID,
                                    "data-cod": "1",
                                    "class": "td_input jump",
                                    "value": Mx_Dtt[i].Caja_Transporte,
                                })
                            }())),

                              $("<td>", {
                                  "align": "left",
                                  "class": "textoReducido"
                              }).html((function () {
                                  //Retornar un campo input
                                  if (moment(Mx_Dtt[i].Fecha_irislab).format("YYYY") > 1980) {
                                      return $("<input>", {
                                          "type": "date",
                                          "data-id": Mx_Dtt[i].ID,
                                          "data-cod": "10",
                                          "class": "td_input jump feCH",
                                          "value": moment(Mx_Dtt[i].Fecha_irislab).format("YYYY-MM-DD"),
                                      })
                                  } else {
                                      return $("<input>", {
                                          "type": "date",
                                          "data-id": Mx_Dtt[i].ID,
                                          "data-cod": "10",
                                          "class": "td_input jump feCH",
                                          "value": 4,
                                      })
                                  }

                              }())),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<input>", {
                                    "data-id": Mx_Dtt[i].ID,
                                    "data-cod": "2",
                                    "class": "td_input jump",
                                    "value": Mx_Dtt[i].Muestras_recepcionadas,
                                })
                            }())),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<input>", {
                                    "data-id": Mx_Dtt[i].ID,
                                    "data-cod": "3",
                                    "class": "td_input jump",
                                    "value": Mx_Dtt[i].Muestras_enviadas,
                                })
                            }())),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<input>", {
                                    "data-id": Mx_Dtt[i].ID,
                                    "data-cod": "4",
                                    "class": "td_input jump ",
                                    "value": Mx_Dtt[i].Folio_Hoja_trabajo,
                                })
                            }())),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                if (moment(Mx_Dtt[i].Fecha_envio_HGF).format("YYYY") > 1980) {
                                    return $("<input>", {
                                        "type": "date",
                                        "data-id": Mx_Dtt[i].ID,
                                        "data-cod": "5",
                                        "class": "td_input jump feCH",
                                        "value": moment(Mx_Dtt[i].Fecha_envio_HGF).format("YYYY-MM-DD"),
                                    })
                                } else {
                                    return $("<input>", {
                                        "type": "date",
                                        "data-id": Mx_Dtt[i].ID,
                                        "data-cod": "5",
                                        "class": "td_input jump feCH",
                                        "value": 4,
                                    })
                                }

                            }())),

                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                if (moment(Mx_Dtt[i].Fecha_recepcion_Resultados).format("YYYY") > 1980) {
                                    return $("<input>", {
                                        "type": "date",
                                        "data-id": Mx_Dtt[i].ID,
                                        "data-cod": "6",
                                        "class": "td_input jump feCH",
                                        "value": moment(Mx_Dtt[i].Fecha_recepcion_Resultados).format("YYYY-MM-DD"),
                                    })
                                } else {
                                    return $("<input>", {
                                        "type": "date",
                                        "data-id": Mx_Dtt[i].ID,
                                        "data-cod": "6",
                                        "class": "td_input jump feCH",
                                        "value": 4
                                    })
                                }

                            }())),

                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                if (moment(Mx_Dtt[i].Fecha_Validacion_en_Irislab).format("YYYY") > 1980) {
                                    //Retornar un campo input
                                    return $("<input>", {
                                        "type": "date",
                                        "data-id": Mx_Dtt[i].ID,
                                        "data-cod": "7",
                                        "class": "td_input jump feCH",
                                        "value": moment(Mx_Dtt[i].Fecha_Validacion_en_Irislab).format("YYYY-MM-DD"),
                                    })
                                } else {
                                    //Retornar un campo input
                                    return $("<input>", {
                                        "type": "date",
                                        "data-id": Mx_Dtt[i].ID,
                                        "data-cod": "7",
                                        "class": "td_input jump feCH",
                                        "value": 4
                                    })
                                }

                            }())),
                        $("<td>", {
                            "align": "center"
                        }).html(function () {
                            return "<button type='button' class='btn btn-default btn-xs borrar' value='Eliminar' data-id='" + Mx_Dtt[i].ID + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"
                        })
                    )
                );
                $(".td_input.jump").keydown(function EnterEvent(e) {
                    e.stopImmediatePropagation();
                    let keycode = e.keyCode;
                    xId = $(this).attr("data-id");
                    let exo = $(this).attr("data-cod");
                    var xcod = $(this).val();
                    if (keycode == 9) {
                        Ajax_DataTable_examen3(xId, xcod, exo);
                    } else if (keycode == 38) {
                        $(this).closest('tr').prev().find('td:eq(' + $(this).closest('td').index() + ')').find('.td_input').focus();
                        Ajax_DataTable_examen3(xId, xcod, exo);
                    } else if (keycode == 40) {
                        console.log("40");
                        $(this).closest('tr').next().find('td:eq(' + $(this).closest('td').index() + ')').find('.td_input').focus();
                        Ajax_DataTable_examen3(xId, xcod, exo);
                    } else if (keycode == 37) {
                        console.log("37");
                        $(this).closest('td').prev().find('.td_input').focus();
                        Ajax_DataTable_examen3(xId, xcod, exo);
                    }
                    else if (keycode == 39) {
                        console.log("37");
                        $(this).closest('td').next().find('.td_input').focus();
                        Ajax_DataTable_examen3(xId, xcod, exo);
                    }
                    console.log(keycode);

                });

                //$(".td_input").keypress(function EnterEvent(e) {
                //    e.stopImmediatePropagation();
                //    if (e.keycode == 40) {
                //        console.log("40");
                //        //$(this).closest('tr').next().find('td:eq(' + $(this).closest('td').index() + ')').find('td_input').focus();
                //    } else if (e.keycode == 39)
                //    {
                //        console.log("39");
                //    }
                //});
            }
            add_row();

        }
        function Ajax_DataTable_examen3(id, cod, xo) {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID": id,
                "CAMBIO": cod,
                "CASILLA": xo
            });
            $.ajax({
                "type": "POST",
                "url": "Excel_TP_Real_ADM.aspx/Llenar_tabla_exam",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Hide_Modal();
                        ////Ajax_LugarTM();
                        //Ajax_DataTable();
                    } else {
                        Hide_Modal();
                        ////Ajax_LugarTM();
                        //Ajax_DataTable();
                    }

                },
                "error": function (response) {
                    console.log(response);
                    Hide_Modal();


                }
            });
        }
    </script>
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
    <div class="modal fade" id="eModal2" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Agregar Trazabilidad PAP</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <%--    <div class="row">--%>

                        <div class="col-sm">
                            <label class="textoReducido">Cod. Barra:</label>
                            <input type='text' id="Cod_barra" class="form-control textoReducido" placeholder="" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Establecimiento/Contenedor:</label>
                            <input type='text' id="Establecimiento_Contenedor" class="form-control textoReducido" placeholder="" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Caja Transporte N°:</label>
                            <input type='text' id="Caja_Transporte" class="form-control textoReducido" placeholder="" />
                        </div>
                        <div class="col-lg">
                            <label class="textoReducido">Fecha y hora ingreso Irislab:</label>
                            <div class='input-group date' id='datetimepicker1' style="margin-bottom: 1vh;">
                                <input type="date" min="0001-01-01" max="2018-12-01" id="fecha_y_hora" class="form-control textoReducido" />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                            <style>
                                .glyphicon {
                                    display: inline-block;
                                    font-family: FontAwesome;
                                    font-style: normal;
                                    font-weight: normal;
                                    line-height: 1;
                                    -webkit-font-smoothing: antialiased;
                                    -moz-osx-font-smoothing: grayscale;
                                }

                                .glyphicon-arrow-left:before {
                                    content: "\f053";
                                }

                                .glyphicon-arrow-right:before {
                                    content: "\f054";
                                }
                            </style>
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Muestras recepcionadas:</label>
                            <input type='text' id="Muestras_recepcionadas" class="form-control textoReducido" placeholder="" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Muestras enviadas:</label>
                            <input type='text' id="Muestras_enviadas" class="form-control textoReducido" placeholder="" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Folio Hoja trabajo:</label>
                            <input type='text' id="Folio_Hoja_trabajo" class="form-control textoReducido" placeholder="" />
                        </div>
                        <div class="col-lg">
                            <label class="textoReducido">Fecha envio HGF:</label>
                            <div class='input-group date' id='datetimepicker2' style="margin-bottom: 1vh;">
                                <input type="date" min="0001-01-01" max="2018-12-01" id="Fecha_envio_HGF" class="form-control textoReducido" />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                            <style>
                                .glyphicon {
                                    display: inline-block;
                                    font-family: FontAwesome;
                                    font-style: normal;
                                    font-weight: normal;
                                    line-height: 1;
                                    -webkit-font-smoothing: antialiased;
                                    -moz-osx-font-smoothing: grayscale;
                                }

                                .glyphicon-arrow-left:before {
                                    content: "\f053";
                                }

                                .glyphicon-arrow-right:before {
                                    content: "\f054";
                                }
                            </style>
                        </div>
                        <div class="col-lg">
                            <label class="textoReducido">Fecha recepcion Resultados:</label>
                            <div class='input-group date' id='datetimepicker3' style="margin-bottom: 1vh;">
                                <input type="date" min="0001-01-01" max="2018-12-01" id="Fecha_recepcion_Resultados" class="form-control textoReducido" />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                            <style>
                                .glyphicon {
                                    display: inline-block;
                                    font-family: FontAwesome;
                                    font-style: normal;
                                    font-weight: normal;
                                    line-height: 1;
                                    -webkit-font-smoothing: antialiased;
                                    -moz-osx-font-smoothing: grayscale;
                                }

                                .glyphicon-arrow-left:before {
                                    content: "\f053";
                                }

                                .glyphicon-arrow-right:before {
                                    content: "\f054";
                                }
                            </style>
                        </div>
                        <div class="col-lg">
                            <label class="textoReducido">Fecha Validacion en Irislab:</label>
                            <div class='input-group date' id='datetimepicker4' style="margin-bottom: 1vh;">
                                <input type="date" min="0001-01-01" max="2018-12-01" id="Fecha_Validacion_en_Irislab" class="form-control textoReducido" />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                            <style>
                                .glyphicon {
                                    display: inline-block;
                                    font-family: FontAwesome;
                                    font-style: normal;
                                    font-weight: normal;
                                    line-height: 1;
                                    -webkit-font-smoothing: antialiased;
                                    -moz-osx-font-smoothing: grayscale;
                                }

                                .glyphicon-arrow-left:before {
                                    content: "\f053";
                                }

                                .glyphicon-arrow-right:before {
                                    content: "\f054";
                                }
                            </style>
                        </div>
                        <%--              </div>--%>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btnguardar" class="btn btn-success">Agregar</button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>

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
                        <div class="col-md">
                            <div class="col-md">
                                <button id="Btn_Buscar" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                            </div>
                            <div class="col-md">
                                <button id="Btn_Excel" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                            </div>
                        </div>
                    </div>
                    <%--      <div class="row" style="margin-left: 2px; margin-right: 2px;">
                        <div class="col-md">
                            <button id="Btn_Buscar" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                        </div>
                        <div class="col-md">
                            <button id="Btn_Excel" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                        </div>
                    
                    </div>--%>
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
