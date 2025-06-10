    <%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Reg_Residuos_ADM.aspx.vb" Inherits="Presentacion.Reg_Residuos_ADM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="/js/moment_es.js"></script>
    <script src="/js/moment.js"></script>
    <script src="js/KeyTable.js"></script>
    <script>
 
        $(document).ready(function () {
            // var keys = new KeyTable();
            Ajax_LugarTM();
            Ajax_TP_RESIDUO();
            Ajax_SECCION_RESIDUO();
            $("#Btn_Modal").click(function () {

                $('#eModal2').modal('show');
            });

            $("#Ddl_LugarTM").change(function () {
                ////Fill_DataTable();
                $("#DataTable tbody").empty();
                $("#Div_Totales").empty();
                add_row();
            });

            $("#btnguardar").click(function () {
                Ajax_DataTable_agregar();
                $('#eModal2').modal('hide');
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
                    Ajax_Excel();
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
                    $("<th>", { "class": "textoReducido text-center" }).text("Folio"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Código"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Sección"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Tipo Residuo"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Bolsa/Contenedor"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Kilos"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Responsable Acopio"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Supervisor REAS"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Lugar TM"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Eliminar")
                )
            );

            //add_row();
            $(document).on('click', '.borrar', function (event) {
                var rowstota = document.getElementById("DataTable").rows.length;
                var ff = $(this).parent().parent().children().children('.td_input').attr('data-id');
                event.preventDefault();
                ajax_eliminar(ff);
                for (i = 0; i < Mx_Dtt.List_Data.length; i++) {

                    if (Mx_Dtt.List_Data[i].ID_CODIGO_FONASA == ff) {
                        Mx_Dtt.List_Data.splice(i, 1);
                    }
                    $(this).closest('tr').remove();

                }

            });
            setTimeout(function () {
                add_row();
            }, 2000);
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
                "url": "Reg_Residuos_ADM.aspx/Eliminar",
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
                "<br>",
                $("<tr>", {
                    //"onclick": `Ajax_Redirect("` + Mx_Dtt[i].ID_FCL + `")`,
                    "class": "manito"
                }).append(

                        $("<td>", { "class": "textoReducido negrin" }).text("Agregar"),
                        $("<td>", {                                                                 //FOLIO
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": "",
                                "data-cod": "1",
                                "class": "td_input jump GG border_round",
                                "value": "",
                            })
                        }())),
                        $("<td>", {                                                                 //FECHA
                            "align": "left",
                            "class": "textoReducido border_round"
                        }).html((function () {
                            //Retornar un campo input

                            return $("<input>", {
                                "type": "date",
                                "data-id": "",
                                "data-cod": "2",
                                "class": "td_input jump feCH GG border_round",
                                "value": "",
                            })


                        }())),
                        //$("<td>", {
                        //    "align": "left",
                        //    "class": "textoReducido"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    if ($("#Ddl_LugarTM").val() == 0) {
                        //        return $("<input>", {
                        //            "data-id": "",
                        //            "data-cod": "3",
                        //            "class": "td_input jump GG",
                        //            "value": "",
                        //        })
                        //    } else {
                        //        return $("<input>", {
                        //            "data-id": "",
                        //            "data-cod": "3",
                        //            "class": "td_input jump GG",
                        //            "value": $("#Ddl_LugarTM option:selected").text(),
                        //        })
                        //    }

                        //}())),
                        
                        $("<td>", {                                                     //CODIGO
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<select>", {
                                "id": "DdlCodigo",
                                "data-id": "",
                                "data-cod": "3",
                                "class": "td_input jump GG anchooo border_round",
                                "value": "",
                            })
                        }())),
                        $("<td>", {                                                 //SECCION
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<select>", {
                                "id": "DdlSeccion",
                                "data-id": "",
                                "data-cod": "4",
                                "class": "td_input jump GG border_round",
                                "value": "",
                                //"change": 
                            })
                        }())),
                        //$("<td>", {
                        //    "align": "left",
                        //    "class": "textoReducido"
                        //}).html((function () {
                        //    //Retornar un campo input
                        //    return $("<input>", {
                        //        "data-id": "",
                        //        "data-cod": "10",
                        //        "class": "td_input jump GG",
                        //        "value": "",
                        //    })
                        //}())),

                        $("<td>", {                                             //TIPO RESIDUO
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<select>", {
                                "id":"DleTPResiduo",
                                "data-id": "",
                                "data-cod": "5",
                                "class": "td_input jump GG border_round",
                                "value": "",
                            })
                        }())),
                        $("<td>", {                                             //BOLSA
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": "",
                                "data-cod": "6",
                                "class": "td_input jump GG border_round",
                                "value": "",
                            })
                        }())),
                        $("<td>", {                                             //KILOS
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": "",
                                "data-cod": "7",
                                "class": "td_input jump GG border_round",
                                "value": "",
                            })
                        }())),
                        $("<td>", {                                             //RESPONSABLE
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": "",
                                "data-cod": "8",
                                "class": "td_input jump GG border_round",
                                "value": "",
                            })
                        }())),
                        $("<td>", {                                             //SUPERVISOR REAS CAMPO NUEVO
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": "",
                                "data-cod": "10",
                                "class": "td_input jump GG border_round",
                                "value": "",
                            })
                        }())),
                        $("<td>", {                                             //LUGAR TM
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<select>", {
                                "id": "DdlLugatTMTabbla",
                                "data-id": "",
                                "data-cod": "9",
                                "class": "td_input jump GG border_round",
                                "value": "",
                            })
                        }()))

                )
            )

            
            $("#DdlCodigo").empty();
            $("#DdlSeccion").empty();
            $("#DleTPResiduo").empty();
            $("#DdlLugatTMTabbla").empty();

            $("<option>", { "value": 1 }).text("ESPECIAL (bolsa amarilla)").appendTo("#DleTPResiduo");
            $("<option>", { "value": 2 }).text("ESPECIAL CORTANTE (amarillo rigido)").appendTo("#DleTPResiduo");
            $("<option>", { "value": 3 }).text("PELIGROSO (bolsa roja)").appendTo("#DleTPResiduo");
            $("<option>", { "value": 4 }).text("PELIGROSO CORTANTE (rojo rigido)").appendTo("#DleTPResiduo");

            for (y = 0; y < Mx_Dtt_SECCION_RESIDUO.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_SECCION_RESIDUO[y].ID_SECC_RESIDUO
                }).text(Mx_Dtt_SECCION_RESIDUO[y].COD_SECC_RESIDUO).appendTo("#DdlCodigo");

                $("<option>", {
                    "value": Mx_Dtt_SECCION_RESIDUO[y].ID_SECC_RESIDUO
                }).text(Mx_Dtt_SECCION_RESIDUO[y].SECC_RESIDUO_DESC).appendTo("#DdlSeccion");
            }
           
            Mx_Dtt_LugarTM.forEach(aaa => { $("<option>", { "value": aaa.ID_PROCEDENCIA }).text(aaa.PROC_DESC).appendTo("#DdlLugatTMTabbla"); });


            $(".td_input.GG").keydown(function EnterEvent(e) {
                e.stopImmediatePropagation();
                let keycode = e.keyCode;
                if (e.keyCode == 13) {
                    let obj_transfer = GET_Elem_Txt(e);
                    console.log(obj_transfer);
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
            
            $("#DdlCodigo").change(function () {
                $("#DdlSeccion").val($("#DdlCodigo").val());
            });

            $("#DdlSeccion").change(function () {
                $("#DdlCodigo").val($("#DdlSeccion").val());
            });

            $("#DdlLugatTMTabbla").change(function () {
                $("#Ddl_LugarTM").val($("#DdlLugatTMTabbla").val());
            });

            $("#Ddl_LugarTM").change(function () {
                $("#Div_Totales").empty();
                $("#DdlLugatTMTabbla").val($("#Ddl_LugarTM").val());

            });
            //var xLen = $(".GG");
            //$(".GG").eq(0).focus();
        }

        let GET_Elem_Txt = (me) => {
            let obj_data = {
                fOLIO_RESIDUO: "",          //FOLIO
                fECHA_RESIDUO: "",
                iD_SECCION_RESIDUO: "",
                iD_TIPO_RESIDUO: "",
                bOLSA_CONT_RESIDUO: "",
                kILOS_RESIDUO: "",
                rESPONSABLE_RESIDUO: "",
                iD_PROCEDENCIA: "",
                sUPERVISOR:""
            };

            let getInput = (number) => {
                let objTr = $(me.currentTarget).parent().parent();
                return objTr.children("td").eq(number + 1).children("input");
            };

            obj_data.fOLIO_RESIDUO = getInput(0).val();
            obj_data.fECHA_RESIDUO = getInput(1).val();
            obj_data.iD_SECCION_RESIDUO = getInput(2).val();
            obj_data.iD_TIPO_RESIDUO = getInput(3).val();
            obj_data.bOLSA_CONT_RESIDUO = getInput(5).val();
            obj_data.kILOS_RESIDUO = getInput(6).val();
            obj_data.rESPONSABLE_RESIDUO = getInput(7).val();
            obj_data.sUPERVISOR = getInput(8).val();
            obj_data.iD_PROCEDENCIA = getInput(9).val();
            

            return obj_data;
        };

        var Mx_Dtt = {
            List_Data: [
                {
                    ID_RESIDUO: 0,
                    FOLIO_RESIDUO: 0,
                    FECHA_RESIDUO: new Date,
                    COD_SECC_RESIDUO: 0,
                    SECC_RESIDUO_DESC: 0,
                    TP_RESIDUO_DESC: 0,
                    BOLSA_CONT_RESIDUO: 0,
                    KILOS_RESIDUO: 0,
                    RESPONSABLE_RESIDUO: 0,
                    ESTADO_RESIDUO: 0,
                    PROC_DESC: 0,
                    ID_TP_RESIDUO: 0,
                    ID_SECC_RESIDUO: 0,
                    ID_PROCEDENCIA: 0,
                    SUPERVISOR:0
                }
            ],
            Dictionary: {
                "Aaaahhh": 213543
            }
        };






        
        function Ajax_DataTable() {
            modal_show();

            var Data_Par = JSON.stringify({

                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_TM": $("#Ddl_LugarTM").val(),
                //"ID_TM": $("#Ddl_LugarTM option:selected").text(),

            });
            $.ajax({
                "type": "POST",
                "url": "Reg_Residuos_ADM.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.List_Data.length > 0) {

                        Mx_Dtt = json_receiver;
                        $("#Div_Totales").empty();
                        Fill_DataTable();
                        Hide_Modal();


                        //$("#Id_Conte").show();
                    } else {

                        //$("#DataTable tbody").empty();
                        //$("#Div_Totales").empty();
                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                        //$("#Id_Conte").hide();
                    }
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
                    fOLIO_RESIDUO: "",
                    fECHA_RESIDUO: "",
                    iD_SECCION_RESIDUO: "",
                    iD_TIPO_RESIDUO: "",
                    bOLSA_CONT_RESIDUO: "",
                    kILOS_RESIDUO: "",
                    rESPONSABLE_RESIDUO: "",
                    iD_PROCEDENCIA: "",
                    sUPERVISOR:""
                };

                obj_transfer = value;
                console.log(obj_transfer);
                modal_show();
                let fecha_y_hora = "";
                if (obj_transfer.fECHA_RESIDUO != "") {
                    fecha_y_hora = moment(obj_transfer.fECHA_RESIDUO).format("DD-MM-YYYY");
                } else {
                    fecha_y_hora = "01-01-1980";
                }

                var Data_Par = JSON.stringify({

                    "FFOLIO": obj_transfer.fOLIO_RESIDUO,
                    "FFECHA": fecha_y_hora,
                    "IID_SECCION": $("#DdlSeccion").val(),
                    "IID_TP_RESIDUO": $("#DleTPResiduo").val(),
                    "BBOLSA_CONTENEDOR": obj_transfer.bOLSA_CONT_RESIDUO,
                    "KKILOS_RESIDUO": obj_transfer.kILOS_RESIDUO,
                    "RRESPONSABLE": obj_transfer.rESPONSABLE_RESIDUO,
                    "SSUPERVISOR": obj_transfer.sUPERVISOR,
                    "IID_PROCEDENCIA": $("#DdlLugatTMTabbla").val()

                });
                console.log(Data_Par);

                if ($("#DdlLugatTMTabbla").val() != undefined) {
                    $.ajax({
                        "type": "POST",
                        "url": "Reg_Residuos_ADM.aspx/Ajax_DataTable_agregar",
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
                        },
                        "error": function (response) {
                            var str_Error = response.responseJSON.ExceptionType + "\n \n";
                            str_Error = response.responseJSON.Message;
                            alert(str_Error);



                        }
                    });
                } else {
                    Hide_Modal();
                    $("#mError_AAH h4").text("Seleccione");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Debe seleccionar una procedencia.");
                    $("#mError_AAH").modal();
                }

                
            
        }

        // ------------------------- AJAX SECCIOn RESUDUO -------------------------------------------
        var Mx_Dtt_SECCION_RESIDUO = [
        {
            "ID_SECC_RESIDUO": 0,
            "COD_SECC_RESIDUO": 0,
            "SECC_RESIDUO_DESC": 0
        }
        ];
        function Ajax_SECCION_RESIDUO() {


            $.ajax({
                "type": "POST",
                "url": "Reg_Residuos_ADM.aspx/Llenar_Ddl_SECCCION_RESIDUO",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_SECCION_RESIDUO = JSON.parse(json_receiver);

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
        // ------------------------- AJAX TP RESUDUO -------------------------------------------
        var Mx_Dtt_TP_RESIDUO = [
        {
            "ID_TP_RESIDUO": 0,
            "TP_RESIDUO_DESC": 0
        }
        ];
        function Ajax_TP_RESIDUO() {


            $.ajax({
                "type": "POST",
                "url": "Reg_Residuos_ADM.aspx/Llenar_Ddl_TP_RESIDUO",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_TP_RESIDUO = JSON.parse(json_receiver);

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
                "url": "Reg_Residuos_ADM.aspx/Llenar_Ddl_LugarTM",
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
                "ID_TM": $("#Ddl_LugarTM").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Reg_Residuos_ADM.aspx/Excel",
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
                        "value": aaa.ID_PROCEDENCIA
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
                    $("<th>", { "class": "textoReducido" }).text("Lugar TM"),
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






            $("#DataTable tbody").empty();
            for (i = 0; i < Mx_Dtt.List_Data.length; i++) {

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
                                    "data-id": Mx_Dtt.List_Data[i].ID_RESIDUO,
                                    "data-cod": "1",
                                    "class": "td_input jump border_round",
                                    "value": Mx_Dtt.List_Data[i].FOLIO_RESIDUO,
                                })
                            }())),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                if (moment(Mx_Dtt.List_Data[i].FECHA_RESIDUO).format("YYYY") > 1980) {
                                    return $("<input>", {
                                        "type": "date",
                                        "data-id": Mx_Dtt.List_Data[i].ID_RESIDUO,
                                        "data-cod": "2",
                                        "class": "td_input jump feCH border_round",
                                        "value": moment(Mx_Dtt.List_Data[i].FECHA_RESIDUO).format("YYYY-MM-DD"),
                                    })
                                } else {
                                    return $("<input>", {
                                        "type": "date",
                                        "data-id": Mx_Dtt.List_Data[i].ID_RESIDUO,
                                        "data-cod": "2",
                                        "class": "td_input jump feCH border_round",
                                        "value": 4,
                                    })
                                }

                            }())),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<select>", {
                                    "id": "slctCod" + i,
                                    "data-id": Mx_Dtt.List_Data[i].ID_RESIDUO,
                                    "data-cod": "3",
                                    "class": "td_input jump border_round"
                                })
                            }())),

                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<select>", {
                                    "id": "slctSecc" + i,
                                    "data-id": Mx_Dtt.List_Data[i].ID_RESIDUO,
                                    "data-cod": "4",
                                    "class": "td_input jump border_round"
                                })
                            }())),

                              
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<select>", {
                                    "id": "slctTipoResi" + i,
                                    "data-id": Mx_Dtt.List_Data[i].ID_RESIDUO,
                                    "data-cod": "5",
                                    "class": "td_input jump border_round"
                                })
                            })),

                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<input>", {
                                    "data-id": Mx_Dtt.List_Data[i].ID_RESIDUO,
                                    "data-cod": "6",
                                    "class": "td_input jump border_round",
                                    "value": Mx_Dtt.List_Data[i].BOLSA_CONT_RESIDUO,
                                })
                            }())),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<input>", {
                                    "data-id": Mx_Dtt.List_Data[i].ID_RESIDUO,
                                    "data-cod": "7",
                                    "class": "td_input jump border_round",
                                    "value": Mx_Dtt.List_Data[i].KILOS_RESIDUO + " " + "kg.",
                                })
                            }())),
                            
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<input>", {
                                    "data-id": Mx_Dtt.List_Data[i].ID_RESIDUO,
                                    "data-cod": "8",
                                    "class": "td_input jump border_round",
                                    "value": Mx_Dtt.List_Data[i].RESPONSABLE_RESIDUO,
                                })
                            }())),
                            $("<td>", {             //SUPERVISOR REAS CAMPO NUEVO
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<input>", {
                                    "data-id": Mx_Dtt.List_Data[i].ID_RESIDUO,
                                    "data-cod": "10",
                                    "class": "td_input jump border_round",
                                    "value": Mx_Dtt.List_Data[i].SUPERVISOR,
                                })
                            }())),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<select>", {
                                    "id": "slctProce" + i,
                                    "data-id": Mx_Dtt.List_Data[i].ID_RESIDUO,
                                    "data-cod": "9",
                                    "class": "td_input jump border_round"
                                })
                            }())),
                        $("<td>", {
                            "align": "center"
                        }).html(function () {
                            return "<button type='button' class='btn btn-danger btn-xs borrar border_round' value='Eliminar' data-id='" + Mx_Dtt.List_Data[i].ID_RESIDUO + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"
                        })

                    )

                );

                $("<option>", { "value": 1 }).text("ESPECIAL (bolsa amarilla)").appendTo("#slctTipoResi" + i);
                $("<option>", { "value": 2 }).text("ESPECIAL CORTANTE (amarillo rigido)").appendTo("#slctTipoResi" + i);
                $("<option>", { "value": 3 }).text("PELIGROSO (bolsa roja)").appendTo("#slctTipoResi" + i);
                $("<option>", { "value": 4 }).text("PELIGROSO CORTANTE (rojo rigido)").appendTo("#slctTipoResi" + i);
                $("#slctTipoResi" + i).val(Mx_Dtt.List_Data[i].ID_TP_RESIDUO);

                for (y = 0; y < Mx_Dtt_SECCION_RESIDUO.length; ++y)
                {
                    $("<option>", { "value": Mx_Dtt_SECCION_RESIDUO[y].ID_SECC_RESIDUO }).text(Mx_Dtt_SECCION_RESIDUO[y].COD_SECC_RESIDUO).appendTo("#slctCod" + i);
                    $("<option>", { "value": Mx_Dtt_SECCION_RESIDUO[y].ID_SECC_RESIDUO }).text(Mx_Dtt_SECCION_RESIDUO[y].SECC_RESIDUO_DESC).appendTo("#slctSecc" + i);
                }

                $("#slctCod" + i).val(Mx_Dtt.List_Data[i].ID_SECC_RESIDUO);
                $("#slctSecc" + i).val(Mx_Dtt.List_Data[i].ID_SECC_RESIDUO);

                Mx_Dtt_LugarTM.forEach(aaa => {$("<option>", { "value": aaa.ID_PROCEDENCIA }).text(aaa.PROC_DESC).appendTo("#slctProce" + i);
                    $("#slctProce" + i).val(Mx_Dtt.List_Data[i].ID_PROCEDENCIA);

                });

                $(".td_input.jump").keydown(function EnterEvent(e) {
                    e.stopImmediatePropagation();
                    let keycode = e.keyCode;
                    xId = $(this).attr("data-id");
                    let exo = $(this).attr("data-cod");
                    var xcod = $(this).val();
                    if (keycode == 9) {
                        IRIS_WEBF_UPDATE_RESIDUOS(xId, xcod, exo);
                    } else if (keycode == 38) {
                        $(this).closest('tr').prev().find('td:eq(' + $(this).closest('td').index() + ')').find('.td_input').focus();
                        IRIS_WEBF_UPDATE_RESIDUOS(xId, xcod, exo);
                    } else if (keycode == 40) {
                        console.log("40");
                        $(this).closest('tr').next().find('td:eq(' + $(this).closest('td').index() + ')').find('.td_input').focus();
                        IRIS_WEBF_UPDATE_RESIDUOS(xId, xcod, exo);
                    } else if (keycode == 37) {
                        console.log("37");
                        $(this).closest('td').prev().find('.td_input').focus();
                        IRIS_WEBF_UPDATE_RESIDUOS(xId, xcod, exo);
                    }
                    else if (keycode == 39) {
                        console.log("37");
                        $(this).closest('td').next().find('.td_input').focus();
                        IRIS_WEBF_UPDATE_RESIDUOS(xId, xcod, exo);
                    }
                    console.log(keycode);

                });

                if ($("#slctTipoResi" + i).val() == 1) {
                    $("#slctTipoResi" + i).attr("class", "yellow_bottom");
                }else if($("#slctTipoResi" + i).val() == 2){
                    $("#slctTipoResi" + i).attr("class", "yellow_bottom_rigid");
                } else if ($("#slctTipoResi" + i).val() == 3) {
                    $("#slctTipoResi" + i).attr("class", "red_bottom");
                } else if ($("#slctTipoResi" + i).val() == 4) {
                    $("#slctTipoResi" + i).attr("class", "red_bottom_rigid");
                }
                
            }
            add_row();

        }
        function IRIS_WEBF_UPDATE_RESIDUOS(id, cod, xo) {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID": id,
                "CAMBIO": cod,
                "CASILLA": xo
            });
            $.ajax({
                "type": "POST",
                "url": "Reg_Residuos_ADM.aspx/IRIS_WEBF_UPDATE_RESIDUOS",
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
    <style>
        .anchooo {
            width: 100%;
        }
        .negrin {
            font-weight:800;
        }
        .border_round {
            border-radius: 5px;
        }
        .red_bottom {
            color: red;
            border-radius: 5px;
            width:100%;
        }
        .red_bottom_rigid {
            color: red;
            font-weight:700;
            border-radius: 5px;
            width:100%;
        }
        .yellow_bottom {
        color:#bdbf28;
        border-radius: 5px;
        width:100%;
        }
        .yellow_bottom_rigid {
        color:#bdbf28;
        font-weight: 700;
        border-radius: 5px;
        width:100%;
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
    <div class="modal fade" id="eModal2" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Agregar Trazabilidad Residuos</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <%--    <div class="row">--%>

                        <div class="col-sm">
                            <label class="textoReducido">Folio:</label>
                            <input type='text' id="FOLIO_RESIDUO" class="form-control textoReducido" placeholder="HOLAAAAA" />
                        </div>
                        <div class="col-lg">
                            <label class="textoReducido">Fecha y hora ingreso Irislab:</label>
                            <div class='input-group date' id='datetimepicker1' style="margin-bottom: 1vh;">
                                <input type="date" min="0001-01-01" max="2018-12-01" id="FECHA_RESIDUO" class="form-control textoReducido" />
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
                            <label class="textoReducido">Sección:</label>
                            <input type='text' id="ID_SECCION_RESIDUO" class="form-control textoReducido" placeholder="" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">TP Residuo:</label>
                            <input type='text' id="ID_TIPO_RESIDUO" class="form-control textoReducido" placeholder="" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Bolsa:</label>
                            <input type='text' id="BOLSA_CONT_RESIDUO" class="form-control textoReducido" placeholder="" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Kilos:</label>
                            <input type='text' id="KILOS_RESIDUO" class="form-control textoReducido" placeholder="" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Responsable:</label>
                            <input type='text' id="RESPONSABLE_RESIDUO" class="form-control textoReducido" placeholder="" />
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
                        Registro REAS Administrador
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
                        <%--                        <div class="col-md">
                            <button id="Btn_Excel" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                        </div>--%>
                        <%--                        <div class="col-md">

                            <button id="Btn_Modal" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;"><i class="fa fa-fw fa-search mr-2"></i>Agregar</button>

                        </div>--%>
                    </div>
                </div>

                <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
            </div>
            <div class="row" id="Id_Conte">
                <div class="col-md-12" id="Paciente">
                    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list"></i>Listado/Agregar Reas</h5>
                    <div id="Div_Tabla" style="width: 100%; max-height: 55vh; overflow: auto"></div>
                    <br />    
                    <h5 style="text-align: center; padding: 5px; font-size: 15px;" font-weight:700;><i class="fa fa-table"></i> TOTALES</h5>
                    <div id="Div_Totales" style="width: 100%; border-radius: 5px;" class="highlights"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
