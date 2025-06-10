    <%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Excel_TP_Real_ADM_AVIS.aspx.vb" Inherits="Presentacion.Excel_TP_Real_ADM_AVIS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="/js/moment_es.js"></script>
    <script src="/js/moment.js"></script>
    <script src="js/KeyTable.js"></script>
    <script>
        let ID_REG_SUPREMO = 0;
        let AVIS_SUPREMO = 0;
        let AVIS_BD_SUPREMO = "";

        let LBL_ATENUM_VAR = "";
        let LBL_NOM_VAR = "";
        let LBL_RUT_VAR = "";
        let LBL_EDAD_VAR = "";

        let permisRecep = Galletas.getGalleta("P_ADMIN");
        let usu_te_eme = Galletas.getGalleta("USU_TM")

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
                $("#lbl_ate_num").text("");
                $("#DataTable tbody").empty();
                add_row();
            });

            //$("#txt_Ingrese_Avis_Plis").keypress(function EnterEvent(e) {
            //$(".wenahsoro").keydown(function EnterEvent(e) {
            //    console.log("salimos de focus ma meeeeen");
            //    //e.stopImmediatePropagation();
            //    let keycode = e.keyCode;
            //    console.log("salimos de focus ma meeeeen");
            //    if (e.keyCode == 13) {
            //        console.log("salimos de focus ma meeeeen");
            //    }

                
            //});











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
                    $("<th>", { "class": "textoReducido text-center" }).text("Folio Avis"),                     //  0
                    $("<th>", { "class": "textoReducido text-center" }).text("Ate Num"),                        //  
                    $("<th>", { "class": "textoReducido text-center" }).text("Nombre Pac"),                     //  
                    $("<th>", { "class": "textoReducido text-center" }).text("Rut"),                            //  
                    $("<th>", { "class": "textoReducido text-center" }).text("Edad"),                           //  
                    $("<th>", { "class": "textoReducido text-center" }).text("Num. Contenedor"),                //  5
                    $("<th>", { "class": "textoReducido text-center" }).text("Establecimiento"),                //  6
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha y hora ingreso Irislab"),   //  7
                    $("<th>", { "class": "textoReducido text-center" }).text("Muestras recepcionadas"),         //  8
                    $("<th>", { "class": "textoreducido text-center" }).text("Diferencias"),                    
                    $("<th>", { "class": "textoReducido text-center" }).text("Muestras enviadas"),              //  9
                    $("<th>", { "class": "textoReducido text-center" }).text("Folio Hoja trabajo"),             //  10
                    $("<th>", { "class": "textoReducido text-center" }).text("Caja Transporte HGF"),            //  11
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha envio HGF"),                //  12
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha recepcion Resultados"),     //  13
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha Validacion en Irislab"),    //  14
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

            $("#Btn_redirect").click(function () {
                Redirect();
            });

            $("#Btn_Asociar").click(function () {
                $("#eModal_New_User").modal('hide');
                $("#eModal_Unir").modal('show');

                if (AVIS_BD_SUPREMO == "") {
                    $("#Btn_Unir").attr("disabled", false);
                    $("#Btn_Actualizar").attr("disabled", true);

                    $("#Lbl_Union_Reg_Avis").text("Este registro" + " (" + "Número " + ID_REG_SUPREMO + ") " + "será combinado con el folio avis: " + AVIS_SUPREMO);
                } else {
                    $("#Btn_Unir").attr("disabled", true);
                    $("#Btn_Actualizar").attr("disabled", false);

                    $("#Lbl_Union_Reg_Avis").text("El registro" + " (" + "Número " + ID_REG_SUPREMO + ") " + "ya se encuentra asociado al folio avis: " + AVIS_SUPREMO);

                }

                
            });
    
            
            $("#Btn_Atras").click(function () {
                $("#eModal_New_User").modal('show');
                $("#eModal_Unir").modal('hide');
            });

            $("#Btn_Unir").click(function () {
                Ajax_Unir_Registros();
            });

            $("#Btn_Actualizar").click(function () {
                if (ID_REG_SUPREMO == 0 || AVIS_SUPREMO == 0) {

                } else {
                    $("#eModal_Unir").modal('hide');
                    $("#mError_Seguro h4").text("Confirme");
                    $("#mError_Seguro p").text("¿Está seguro que desea actualizar el folio AVIS relacionado a este registro PAP?");
                    $("#mError_Seguro").modal();
                }
            });

            $("#Btn_Seguro").click(function () {

            });

            $("#Btn_Atras_2").on("click", () => {
                //$("#eModal_Unir").modal('hide');
                $("#mError_Seguro").modal('hide');
                $("#eModal_Unir").modal('show');
            });

        });



    </script>
    <script>
        function Redirect() {
            var loc = location.origin;
            window.open(loc + "/Buscar_Ate/Atencion_Det.aspx" + "?ID_ATE" + "=" + Mx_Dtt_Avis[0].ENCRYPTED_ID);
        };

        function ajax_eliminar(ID_WEN) {
            //OCULTAMOS EL MODAL DEL PACIENTE

            //Debug
            var Data_Par44 = JSON.stringify({
                "ID": ID_WEN
            });
            $.ajax({
                "type": "POST",
                "url": "Excel_TP_Real_ADM_AVIS.aspx/Eliminar",
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
                                "id": "txt_Ingrese_Avis_Plis",
                                "data-id": "",
                                "data-cod": "11",               //AVIS
                                "class": "td_input NUMAVISFIRST",
                                "value": "",
                            })
                        }())),
                        $("<td>", {                             //ATE NUM
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "id":"LBL_ATENUM",
                                "data-id": "",
                                "data-cod": "770",
                                "class": "td_input jump GG",
                                "disabled": "disabled",
                                "value": "",
                            })
                        }())),
                        $("<td>", {                             //NOMBRE
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "id":"LBL_NOMBRE",
                                "data-id": "",
                                "data-cod": "771",
                                "class": "td_input jump GG",
                                "disabled": "disabled",
                                "value": "",
                            })
                        }())),
                        $("<td>", {                             //RUT
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "id":"LBL_RUT",
                                "data-id": "",
                                "data-cod": "772",
                                "class": "td_input jump GG",
                                "disabled": "disabled",
                                "value": "",
                            })
                        }())),
                        $("<td>", {                             //EDAD
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "id": "LBL_EDAD",
                                "data-id": "",
                                "data-cod": "773",
                                "class": "td_input jump GG",
                                "disabled": "disabled",
                                "value": "",
                            })
                        }())),
                        $("<td>", {                         //COD. BARRA
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
                        $("<td>", {                         //	Establecimiento/Contenedor
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
                            $("<td>", {                     //Fecha y hora ingreso Irislab
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
                        $("<td>", {                     //Muestras recepcionadas
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
                        $("<th>", {                         //DIFERENCIAS
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<label>", {
                                "data-id": "",
                                "data-cod": "",
                                "class": "",
                                "value": "",
                            })
                        }())),
                        $("<td>", {                     //Muestras enviadas
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
                        $("<td>", {                     //Folio Hoja trabajo
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
                        $("<td>", {                         //Caja Transporte N°
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

            LBL_ATENUM_VAR = "";
            LBL_NOM_VAR = "";
            LBL_RUT_VAR = "";
            LBL_EDAD_VAR = "";

            //$("#LBL_ATENUM").val(LBL_ATENUM_VAR);

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

            $(".td_input.NUMAVISFIRST").focusout(function EnterEvent(e) {
                e.stopImmediatePropagation();
                var aavissssssssssssssssssssssss = $(this).val();
                //let keycode = e.keyCode;

                if (aavissssssssssssssssssssssss != "") {
                    console.log("mandó info... " + aavissssssssssssssssssssssss);
                    Ajax_Busca_Info_Por_Avis(aavissssssssssssssssssssssss);
                } else {
                    $("#LBL_ATENUM").val("");
                    $("#LBL_NOMBRE").val("");
                    $("#LBL_RUT").val("");
                    $("#LBL_EDAD").val("");
                }

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
                fecha_validac: "",
                nummm_avisssss: ""
            };

            let getInput = (number) => {
                let objTr = $(me.currentTarget).parent().parent();
                return objTr.children("td").eq(number + 1).children("input");
            };
            obj_data.nummm_avisssss = getInput(0).val();
            obj_data.cod_barra = getInput(5).val();
            obj_data.contenedor = getInput(6).val();
            obj_data.fecha_ingreso = getInput(7).val();
            obj_data.muestras_recepc = getInput(8).val();
            obj_data.muestras_enviadas = getInput(9).val();
            obj_data.folio = getInput(10).val();
            obj_data.caja = getInput(11).val();
            obj_data.fecha_envio = getInput(12).val();
            obj_data.fecha_recepc = getInput(13).val();
            obj_data.fecha_validac = getInput(14).val();

            console.log(obj_data);
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
              ID: "",
              ID_USUARIO_UNION:"",
              FECHA_UNION:"",
              ATE_AVIS_UNION:"",
              ATE_NUM_UNION: "",
              ATE_NUM: "",
              PAC_NOMBRE: "",
              PAC_APELLIDO: "",
              PAC_RUT: "",
              ATE_AÑO: ""
          }
        ];

        function Ajax_DataTable() {
            modal_show();


            var Data_Par = JSON.stringify({

                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_TM": $("#Ddl_LugarTM option:selected").text(),

            });
            $.ajax({
                "type": "POST",
                "url": "Excel_TP_Real_ADM_AVIS.aspx/Llenar_DataTable",
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

                        ID_REG_SUPREMO = 0;
                        AVIS_SUPREMO = 0;
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

        var Mx_Dtt_Avis = [
           {
               HO_CC: "",
               ID_ATENCION: "",
               ATE_NUM: "",
               ATE_FECHA: new Date,
               PROC_DESC: "",
               PREVE_DESC: "",
               PAC_RUT: "",
               PAC_NOMBRE: "",
               PAC_APELLIDO: "",
               PAC_FNAC: "",
               ID_SEXO: "",
               DOC_NOMBRE: "",
               DOC_APELLIDO: "",
               ATE_OBS_FICHA: "",
               ATE_AÑO: ""
           }
        ];


        function Ajax_Busca_Info_Por_Avis(numeritoAvis) {
            modal_show();


            var Data_Par = JSON.stringify({
                "NUM_AVIS": numeritoAvis
            });

            $.ajax({
                "type": "POST",
                "url": "Excel_TP_Real_ADM_AVIS.aspx/Llenar_AVIS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Avis = JSON.parse(json_receiver)

                        LBL_ATENUM_VAR = Mx_Dtt_Avis[0].ATE_NUM;
                        LBL_NOM_VAR = Mx_Dtt_Avis[0].PAC_NOMBRE + " " + Mx_Dtt_Avis[0].PAC_APELLIDO;
                        LBL_RUT_VAR = Mx_Dtt_Avis[0].PAC_RUT;
                        LBL_EDAD_VAR = Mx_Dtt_Avis[0].ATE_AÑO;

                        //$("#txt_Ingrese_Avis_Plis").val("pipipip");
                        $("#LBL_ATENUM").val(LBL_ATENUM_VAR);
                        $("#LBL_NOMBRE").val(LBL_NOM_VAR);
                        $("#LBL_RUT").val(LBL_RUT_VAR);
                        $("#LBL_EDAD").val(LBL_EDAD_VAR + " Años");
                        3

                        //$("#Lbl_Rut").text(Mx_Dtt_Avis[0].PAC_RUT);
                        //$("#Lbl_Nombre").text(Mx_Dtt_Avis[0].PAC_NOMBRE + " " + Mx_Dtt_Avis[0].PAC_APELLIDO);

                        //if (Mx_Dtt_Avis[0].ID_SEXO == 1) {
                        //    $("#Lbl_Sexo").text("MASCULINO")
                        //} else {
                        //    $("#Lbl_Sexo").text("FEMENINO");
                        //}
                        //$("#Lbl_Fnac").text(moment(Mx_Dtt_Avis[0].PAC_FNAC).format("DD-MM-YYYY"));                        

                        //Ajax_Examenes();

                        


                        Hide_Modal();

                    } else {
                        $("#txt_Ingrese_Avis_Plis").val("");
                        $("#LBL_ATENUM").val("");
                        $("#LBL_NOMBRE").val("");
                        $("#LBL_RUT").val("");
                        $("#LBL_EDAD").val("");
                        Hide_Modal();
                        ID_REG_SUPREMO = 0;
                        AVIS_SUPREMO = 0;
                        //$("#mError_AAH h4").text("Sin resultados");
                        //$("#mError_AAH button").attr("class", "btn btn-danger");
                        //$("#mError_AAH p").text("No se han encontrado resultados");
                        //$("#mError_AAH").modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        function Ajax_Unir_Registros() {
            modal_show();


            var Data_Par = JSON.stringify({
                "ID_REG":ID_REG_SUPREMO,
                "NUM_AVIS": AVIS_SUPREMO
            });

            $.ajax({
                "type": "POST",
                "url": "Excel_TP_Real_ADM_AVIS.aspx/IRIS_WEBF_GRABA_UNION_DATOS_PAP_AVIS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        $("#eModal_Unir").modal('hide');
                        Hide_Modal();

                        ID_REG_SUPREMO: 0,
                        AVIS_SUPREMO = 0;

                        $("#mError_AAH h4").text("Guardado Exitoso");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("Los registros se han combinado exitósamente.");
                        $("#mError_AAH").modal();

                    } else {

                        Hide_Modal();
                        $("#eModal_Unir").modal('hide');
                        ID_REG_SUPREMO = 0;
                        AVIS_SUPREMO = 0;
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
                    console.log(str_Error);



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
                fecha_validac: "",
                nummm_avisssss: ""
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
                "nummm_avisssss": obj_transfer.nummm_avisssss

            });

            $.ajax({
                "type": "POST",
                "url": "Excel_TP_Real_ADM_AVIS.aspx/Ajax_DataTable_agregar",
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
                "url": "Excel_TP_Real_ADM_AVIS.aspx/Llenar_Ddl_LugarTM",
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
                "url": "Excel_TP_Real_ADM_AVIS.aspx/Excel",
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
            $("#Ddl_LugarTM2").empty();

            if (permisRecep == "1") {
                $("<option>", { "value": "0" }).text("Todos").appendTo("#Ddl_LugarTM");

                Mx_Dtt_LugarTM.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                });

            } else if ((usu_te_eme == "0") && (permisRecep != "1")) {
                $("<option>", { "value": "0" }).text("Todos").appendTo("#Ddl_LugarTM");

                Mx_Dtt_LugarTM.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
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
                                    //"data-id": Mx_Dtt[i].ID,
                                    "data-cod": "666",
                                    "data-id": Mx_Dtt[i].ID,
                                    "data-avis": Mx_Dtt[i].ATE_AVIS_UNION,
                                    "class": "td_input NUMAVIS",
                                    "value": Mx_Dtt[i].ATE_AVIS_UNION,
                                })
                            }())),
                            $("<td>", {                                 // ATE NUM
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<input>", {
                                    "data-id": Mx_Dtt[i].ID,
                                    "data-cod": "770",
                                    "class": "td_input jump",
                                    "disabled": "disabled",
                                    "value": Mx_Dtt[i].ATE_NUM,
                                })
                            }())),
                            $("<td>", {                             //  NOMBRE PAC     
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                if (Mx_Dtt[i].PAC_NOMBRE == null) {
                                    return $("<input>", {
                                        "data-id": Mx_Dtt[i].ID,
                                        "data-cod": "771",
                                        "class": "td_input jump",
                                        "disabled": "disabled",
                                        "value": "",
                                    })
                            }
                            else{
                                    return $("<input>", {
                                        "data-id": Mx_Dtt[i].ID,
                                        "data-cod": "771",
                                        "class": "td_input jump",
                                        "disabled": "disabled",
                                        "value": Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO,
                                    })
                            }

                                
                            }())),
                            $("<td>", {                             //RUT
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                if (Mx_Dtt[i].PAC_RUT == null) {
                                    return $("<input>", {
                                        "data-id": Mx_Dtt[i].ID,
                                        "data-cod": "772",
                                        "class": "td_input jump",
                                        "disabled": "disabled",
                                        "value": "",
                                    })
                                } else {
                                    return $("<input>", {
                                        "data-id": Mx_Dtt[i].ID,
                                        "data-cod": "772",
                                        "class": "td_input jump",
                                        "disabled": "disabled",
                                        "value": Mx_Dtt[i].PAC_RUT,
                                    })
                                }

                                
                            }())),
                            $("<td>", {                         //EDAD
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                if (Mx_Dtt[i].ATE_AÑO == null) {
                                    return $("<input>", {
                                        "data-id": Mx_Dtt[i].ID,
                                        "data-cod": "773",
                                        "class": "td_input jump",
                                        "disabled": "disabled",
                                        "value": "",
                                    })
                                } else {
                                    return $("<input>", {
                                        "data-id": Mx_Dtt[i].ID,
                                        "data-cod": "773",
                                        "class": "td_input jump",
                                        "disabled": "disabled",
                                        "value": Mx_Dtt[i].ATE_AÑO + " Años",
                                    })
                                }

                                
                            }())),                          //Cod. Barra
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
                            $("<td>", {                     //Establecimiento/Contenedor	
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
                                "align": "center",
                                "class": "textoReducido"                                            //DIFERENCIAS 
                            }).html((function () {
                                if ((Mx_Dtt[i].Muestras_recepcionadas != "") && (Mx_Dtt[i].Muestras_enviadas != "")) {
                                    var mues_recep = parseInt(Mx_Dtt[i].Muestras_recepcionadas);
                                    var mues_env = parseInt(Mx_Dtt[i].Muestras_enviadas);

                                    var diferr = mues_recep - mues_env;

                                    if (diferr == 0) {
                                        return $("<label>", {
                                            "data-id": Mx_Dtt[i].ID,
                                            "data-cod": "",
                                            "class": "",
                                            "value": "",
                                            "text": diferr,
                                        })
                                    } else {
                                        return $("<label>", {
                                            "data-id": Mx_Dtt[i].ID,
                                            "data-cod": "",
                                            "class": "text-red",
                                            "value": "",
                                            "text": diferr,
                                        })
                                    }
                                } else {
                                    return "-";
                                }
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
                            return "<button type='button' class='btn btn-default btn-xs borrar' onclick='" + Mx_Dtt[i].ID + "' value='Eliminar' data-id='" + Mx_Dtt[i].ID + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"
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

        

                $(".td_input.NUMAVIS").keydown(function EnterEvent(e) {
                    e.stopImmediatePropagation();
                    let keycode = e.keyCode;
                    let exo = $(this).attr("data-cod");
                    let id_reg = $(this).attr("data-idate");
                    let data_avis = $(this).attr("data-avis");
                    var aaviss = $(this).val();

                    ID_REG_SUPREMO = id_reg;
                    AVIS_SUPREMO = aaviss;
                    AVIS_BD_SUPREMO = data_avis;

                    if (keycode == 13) {
                        console.log("");
                        console.log("AVIS: " + aaviss);
                        console.log("ID_REG: " + id_reg);
                        console.log("AVIS BD: " + data_avis)
                        console.log("--------------------------------------");

                        if (aaviss != "") {
                            Ajax_Busca_Info_Por_Avis(aaviss);
                            console.log("mandó info... " + aaviss);
                        } else {
                            console.log("vacío");
                        }

                    } else{
                        console.log("OTRA TECLA" + " " + keycode);
                    }
                    
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
                "url": "Excel_TP_Real_ADM_AVIS.aspx/Llenar_tabla_exam",
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
                        //Ajax_DataTable(); Ajax_Datable(); 

                        //$("#txtNombre").click(funtion () {
                        //});
                    }

                },
                "error": function (response) {
                    console.log(response);
                    Hide_Modal();


                }
            });
        }

        var Mx_Examenes = [{
            "ID_DET_ATE": 0,
            "CF_DESC": 0,
            "USU_NIC": 0,
            "ID_ATENCION": 0,
            "ID_ESTADO":0,
            "CF_COD": 0,
            "ATE_DET_V_ID_USU": 0,
            "ATE_DET_V_ID_ESTADO":0,
            "ATE_DET_V_FECHA": 0,
            "ID_PER": 0,
            "ATE_DET_IMPRIME": 0,
            "ATE_FECHA": 0,
            "TP_PAGO_DESC": 0,
            "ID_TP_PAGO": 0,
            "ATE_DET_NUM_COPIA": 0,
            "CF_DIAS": 0,
            "CF_IMP_SOLA":0,
            "CF_IMP_NOM_PER": 0,
            "CF_IMP_PARCIAL": 0,
            "CF_IMP_POSX": 0,
            "CF_IMP_POSY": 0,
            "CF_IMP_LETRA":0,
            "CF_IMP_TAMANO": 0,
            "SECC_DESC": 0,
            "ESTADO_WEB_DERIVADO": 0,
            "ID_CODIGO_FONASA":  0,
            "ATE_NUM": 0,
            "ATE_FECHA": 0,
            "PROC_DESC": 0,
            "PREVE_DESC": 0,
            "DOC_NOMBRE": 0,
            "DOC_APELLIDO": 0
        }];

        function Ajax_Examenes() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_ATE": Mx_Dtt_Avis[0].ID_ATENCION
            });
            $.ajax({
                "type": "POST",
                "url": "Excel_TP_Real_ADM_AVIS.aspx/Busca_Examenes",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Hide_Modal();
                         Mx_Examenes = JSON.parse(json_receiver)

                         $("#Lbl_AteNum").text(Mx_Examenes[0].ATE_NUM);
                         $("#Lbl_Fecha_Ingreso").text(moment(Mx_Examenes[0].ATE_FECHA).format("DD-MM-YYYY HH:mm"));
                         $("#Lbl_Proc_desc").text(Mx_Examenes[0].PROC_DESC);
                         $("#Lbl_Preve_desc").text(Mx_Examenes[0].PREVE_DESC);
                         $("#Lbl_Doctor").text(Mx_Examenes[0].DOC_NOMBRE + " " + Mx_Examenes[0].DOC_APELLIDO);

                        $("#Div_Tabla_Examenes").empty();

                        Fill_DataTable_Examenes();



                    } else {
                        Hide_Modal();
                    }

                },
                "error": function (response) {
                    console.log(response);
                    Hide_Modal();


                }
            });
        }

        function Fill_DataTable_Examenes() {
            $("<table>", {
                "id": "DataTable_examenes",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Examenes");

            $("#DataTable_examenes").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_examenes").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_examenes thead").attr("class", "cabezera");
            $("#DataTable_examenes thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido text-center" }).text("#"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Código Fonasa"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Descripción del Examen")
                )
            );

            for (i = 0; i < Mx_Examenes.length; i++) {
                $("#DataTable_examenes tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Examenes[i].CF_COD),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Examenes[i].CF_DESC)
                    )
                );
            }

            $("#eModal_New_User").modal('hide');
            $("#eModal_New_User").modal('show');
        }


    </script>
    <style>
        .text-red {
            color: red;
            font-weight:700;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
        <%--//---------------------------------------------- MODAL LISTADO DE EXÁMENES DE LA ATENCIÓN ------------------------------------%>
    <div class="modal fade" id="eModal_New_User" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title"></h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class ="col-lg-6">
                            <label style="font-weight:700"> Datos Paciente:</label>
                        </div>
                        <div class="col-lg-6">
                            <label style="font-weight:700">Datos Atención:</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <label style="font-weight:600">Rut: </label>
                            <label class="textoReducido" id="Lbl_Rut"></label>
                        </div>   
                        <div class="col-lg-6">
                            <label style="font-weight:600">Folio:</label>
                            <label id="Lbl_AteNum"></label>
                        </div>                     
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <label style="font-weight:600">Nombre: </label>
                            <label class="textoReducido" id="Lbl_Nombre"></label>
                        </div>
                        <div class="col-lg-6">
                            <label style="font-weight:600">Fecha Ingreso:</label>
                            <label id="Lbl_Fecha_Ingreso"></label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <label style="font-weight:600">Sexo: </label>
                            <label class="textoReducido" id="Lbl_Sexo"></label>
                        </div>
                        <div class="col-lg-6">
                            <label style="font-weight:600">Lugar TM:</label>
                            <label id="Lbl_Proc_desc"></label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <label style="font-weight:600">Fecha Nac:</label>
                            <label id="Lbl_Fnac"></label>
                        </div>
                        <div class="col-lg-6">
                            <label style="font-weight:600">Previsión:</label>
                            <label id="Lbl_Preve_desc"></label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-6">
                            <label style="font-weight:700">Profesional Solicitante:</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <label style="font-weight:600">Nombre:</label>
                            <label  id="Lbl_Doctor"></label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-6">
                            <label style="font-weight:700">Listado de Exámenes:</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div id="Div_Tabla_Examenes"></div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="Btn_redirect" class="btn btn-info"><i class="fa fa-fw fa-eye mr-2"></i>Ver Detalles</button>
                    <button type="button" id="Btn_Asociar" class="btn btn-success"><i class="fa fa-fw fa-handshake-o mr-2"></i>Asociar a Orden Avis</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-close mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>
            <%--//---------------------------------------------- MODAL UNIR ------------------------------------%>
    <div class="modal fade" id="eModal_Unir" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Información Paciente/Atención</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class ="col-lg">
                            <label style="font-weight:600" id="Lbl_Union_Reg_Avis"></label>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="Btn_Atras" class="btn btn-info"><i class="fa fa-fw fa-arrow-circle-left mr-2"></i>Volver</button>
                    <button type="button" id="Btn_Unir" class="btn btn-success"><i class="fa fa-fw fa-check mr-2"></i>Unir Datos</button>
                    <button type="button" id="Btn_Actualizar" class="btn btn-warning"><i class="fa fa-fw fa-refresh mr-2"></i>Actualizar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-close mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>
        <!-- Modal Seguro -->
    <div id="mError_Seguro" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content" style="width:350px">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                    <label style="font-weight:600">Ingrese Nuevo folio AVIS:</label>
                   <input id="Txt_Avis_Actualiza" class="form-control textoReducido" type="text"/>
                </div>
                <div class="modal-footer">
                    <button type="button" id="Btn_Atras_2" class="btn btn-info"><i class="fa fa-fw fa-arrow-circle-left mr-2"></i>Volver</button>
                    <button type="button" class="btn btn-success" id="Btn_Seguro">Actualizar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
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
                    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list"></i>Listado de Registros</h5>
                    <div id="Div_Tabla" style="width: 100%; max-height: 55vh; overflow: auto"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
