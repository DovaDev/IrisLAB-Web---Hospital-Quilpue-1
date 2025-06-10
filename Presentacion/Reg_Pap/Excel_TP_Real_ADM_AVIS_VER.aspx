<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Excel_TP_Real_ADM_AVIS_VER.aspx.vb" Inherits="Presentacion.Excel_TP_Real_ADM_AVIS_VER" %>

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

            $("#Ddl_LugarTM").change(function () {
                ////Fill_DataTable();
                $("#lbl_ate_num").text("");
                $("#DataTable tbody").empty();
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
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha Validacion en Irislab")     //  14
                )
            );

        });



    </script>
    <script>

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
                "url": "Excel_TP_Real_ADM_AVIS_VER.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt = JSON.parse(json_receiver);

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
                "url": "Excel_TP_Real_ADM_AVIS_VER.aspx/Llenar_AVIS",
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
                "url": "Excel_TP_Real_ADM_AVIS_VER.aspx/Llenar_Ddl_LugarTM",
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
                "url": "Excel_TP_Real_ADM_AVIS_VER.aspx/Excel",
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

        //---------------------------------------------------- TABLA  -----------------------------------------------|
        function Fill_DataTable() {
            $("#DataTable tbody").empty();
            for (i = 0; i < Mx_Dtt.length; i++) {

                $("#DataTable tbody").append(
                    $("<tr>", {
                        //"onclick": `Ajax_Redirect("` + Mx_Dtt[i].ID_FCL + `")`,
                        "class": "manito"
                    }).append(

                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                            $("<td>", { "align": "left", "class": "textoReducido" }).text(Mx_Dtt[i].ATE_AVIS_UNION),
                            $("<td>", { "align": "left", "class": "textoReducido" }).text(Mx_Dtt[i].ATE_NUM),
                            $("<td>", { "align": "left", "class": "textoReducido" }).text(() => {
                                if (Mx_Dtt[i].PAC_NOMBRE == null) {
                                    return "";
                                }
                                else {
                                    return Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO;
                                }
                            }
                            ),
                            $("<td>", { "align": "left", "class": "textoReducido" }).text(() => {
                                if (Mx_Dtt[i].PAC_RUT == null) {
                                    return "";
                                }
                                else {
                                    return Mx_Dtt[i].PAC_RUT;
                                }
                            }
                            ),
                            $("<td>", { "align": "left", "class": "textoReducido" }).text(() => {
                                if (Mx_Dtt[i].ATE_AÑO == null) {
                                    return "";
                                }
                                else {
                                    return Mx_Dtt[i].ATE_AÑO + " Años";
                                }
                            }
                            ),
                            $("<td>", { "align": "center", "class": "textoReducido" }).text(Mx_Dtt[i].Cod_Barra),
                            $("<td>", { "align": "left", "class": "textoReducido" }).text(Mx_Dtt[i].Establecimiento_Contenedor),
                            $("<td>", { "align": "center", "class": "textoReducido" }).text(() => {
                                if (moment(Mx_Dtt[i].Fecha_irislab).format("YYYY") > 1980) {
                                    return moment(Mx_Dtt[i].Fecha_irislab).format("YYYY-MM-DD");
                                }
                                else {
                                    return "";
                                }
                            }
                            ),
                            $("<td>", { "align": "center", "class": "textoReducido" }).text(Mx_Dtt[i].Muestras_recepcionadas),
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
                                            "data-id": "",
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
                            $("<td>", { "align": "center", "class": "textoReducido" }).text(Mx_Dtt[i].Muestras_enviadas),
                            $("<td>", { "align": "center", "class": "textoReducido" }).text(Mx_Dtt[i].Folio_Hoja_trabajo),
                            $("<td>", { "align": "center", "class": "textoReducido" }).text(Mx_Dtt[i].Caja_Transporte),
                            $("<td>", { "align": "center", "class": "textoReducido" }).text(() => {
                                if (moment(Mx_Dtt[i].Fecha_envio_HGF).format("YYYY") > 1980) {
                                    return moment(Mx_Dtt[i].Fecha_envio_HGF).format("YYYY-MM-DD");
                                } else {
                                    return "";
                                }
                            }),
                            $("<td>", { "align": "left", "class": "textoReducido" }).text(()=> {
                                if (moment(Mx_Dtt[i].Fecha_recepcion_Resultados).format("YYYY") > 1980){
                                    return moment(Mx_Dtt[i].Fecha_recepcion_Resultados).format("YYYY-MM-DD");
                                }else{
                                    return "";
                                }
                            }),
                            $("<td>", { "align": "left", "class": "textoReducido" }).text(() => {
                                if(moment(Mx_Dtt[i].Fecha_Validacion_en_Irislab).format("YYYY") > 1980){
                                    return moment(Mx_Dtt[i].Fecha_Validacion_en_Irislab).format("YYYY-MM-DD");
                                }else{
                                    return "";
                                }
                            })
                            )
                )}

        };

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
