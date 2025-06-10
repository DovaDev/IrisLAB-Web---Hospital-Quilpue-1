<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Traza_Pap.aspx.vb" Inherits="Presentacion.Traza_Pap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <script src="../../js/moment_es.js"></script>
    <script src="../../js/moment.js"></script>

        <script type="text/javascript">

        function jsDecimals(e) {

            var evt = (e) ? e : window.event;
            var key = (evt.keyCode) ? evt.keyCode : evt.which;
            if (key != null) {
                key = parseInt(key, 10);
                if ((key < 48 || key > 57) && (key < 96 || key > 105)) {
                    //Aca tenemos que reemplazar "Decimals" por "NoDecimals" si queremos que no se permitan decimales
                    if (!jsIsUserFriendlyChar(key, "NoDecimals")) {
                        return false;
                    }
                }
                else {
                    if (evt.shiftKey) {
                        return false;
                    }
                }
            }
            return true;
        }

        // Función para las teclas especiales
        function jsIsUserFriendlyChar(val, step) {
            // Backspace, Tab, Enter, Insert, y Delete
            if (val == 8 || val == 9 || val == 13 || val == 45 || val == 46) {
                return true;
            }
            // Ctrl, Alt, CapsLock, Home, End, y flechas
            if ((val > 16 && val < 21) || (val > 34 && val < 41)) {
                return true;
            }
            if (step == "Decimals") {
                if (val == 190 || val == 110) {  //Check dot key code should be allowed
                    return true;
                }
            }
            // The rest
            return false;
        }
    </script>

       <script>
           //let DESCrip = "";
           //var B64Firma = "";

           let permisRecep = Galletas.getGalleta("P_ADMIN");
           let usu_te_eme = Galletas.getGalleta("USU_TM")
           let ususWeb = Galletas.getGalleta("ID_USER")
           
           selected = new Array();
           matrix_folios = new Array();
           var AIDI_FINALIZAR = 0;
           var AIDI_ELIMINAR = 0;

           $(document).ready(function () {
               Ajax_LugarTM();

               if (permisRecep == "8") {
                   $("#btn_Modal_Subir").attr("disabled",true);
               }

               $("#Lbl_Faltantes").hide();

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

               $("#Ddl_LugarTM").change(() => { 
                   if ($("#Ddl_LugarTM").val() != 0) {
                       $("#Ddl_LugarTM2").val($("#Ddl_LugarTM").val());
                   }
               });

               $("#Btn_Limpiar").click(() => {
                   selected = [];
                   $("#lbl_Total_Numeros_Avis").val("");
               });

               //Ajax_DataTable();
               $("#txt_Contenido").keydown(function EnterEvent(e) {
                   if (e.keyCode == 13) {

                       if ($("#txt_Contenido").val() != "") {
                           console.log("entra");
                           Ajax_Busca_Info_Por_Avis();
                       }
                       
                   }
               });

               $("#btn_numero").click(() => {
                   NUMERO();
               });

               $("#btn_Recibir").click(() => {
                   var permissssssss = Galletas.getGalleta("ID_USER");
                   if (permissssssss != Mx_Dtt_Detalle_Caja.proparra1_SUPER[0].ID_USUARIO) {

                       IRIS_WEBF_RECIBIR_CAJA();
                   }
               });

               $("#btn_Modal_Subir").click(function () {
                   $("#txt_Comentario").val("");
                   $("#lbl_Total_Numeros_Avis").val("");
                   $("#txt_Tipo").val("");
                   $("#txt_Contenido").val("");
                   selected = [];

                   $("#mCrear").modal("hide");
                   $("#mCrear").modal("show");
               });

               $("#Btn_Editar").click(() => {
                   console.log("Editar_Btn Pressed");
                   matrix_folios = [];

                   if (Mx_Dtt_Detalle_Caja.proparra1_SUPER[0].ID_ESTADO_CAJA != "3") {

                       Mx_Dtt_Detalle_Caja.proparra2_SUPER.forEach(hola => {
                           matrix_folios.push(hola.HO_CC);
                           //$("</input>", { "value": hola.HO_CC }).text("Todos").appendTo("#col_folios");
                           $("#col_folios").append($("<input>", { type: "input", class: "form-control borderBajo", disabled: "disabled" }).val(hola.HO_CC));
                           $("#col_folios").append("<button type='button' class='btn btn-default btn-xs borrar' onclick='" + hola.HO_CC + "' value='Eliminar' data-id='" + hola.HO_CC + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>")
                       })

                       $("#mDetalleCaja").modal('hide');
                       $("#mEditar").modal("show");
                       console.log(matrix_folios);
                   }
               });

               $("#btn_Buscar").click(() => {
                   Ajax_DataTable();
               });

               $("#btn_Finalizar").click(() => {
                   Ajax_DataTable_FINALIZAR_CAJA();
               });

               $("#btn_Eliminar").click(() => {
                   Ajax_DataTable_ELIMINAR_CAJA();
               });


               $("#btn_Subir_Archivo").click(function () {
                   if ($("#txt_Comentario").val() == "" || $("#txt_Tipo").val() == "" || $("#lbl_Total_Numeros_Avis").val() == "" || $("#Ddl_LugarTM2").val() == 0) {
                       $("#Lbl_Faltantes").fadeIn(300);

                       setInterval(function () {
                           $("#Lbl_Faltantes").fadeOut(300);
                       }, 1500)

                       
                       //$("#mCrear").modal("hide");
                       //$("#mSubirModal").modal("hide");
                       //$("#mError_AAH h4").text("Rectifique");
                       //$("#mError_AAH button").attr("class", "btn btn-danger");
                       //$("#mError_AAH p").text("Debe ingresar N° de contenedor, nombre de matrona y órdenes AVIS para la caja.");
                       //$("#mError_AAH").modal();

                   }else {
                       
                       Ajax_IRIS_WEBF_GRABA_CAJA();
                   }             
            });
          
        });
    </script>
    <script>



        function NUMERO() {

            var Data_Par = JSON.stringify({
                "hola": $("#txt_numero").val()
            });

            var numerazoooo;
            $.ajax({
                "type": "POST",
                "url": "Traza_Pap.aspx/NUMERO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerazoooo = JSON.parse(json_receiver)

                        $("#lbl_numero").text(numerazoooo);

                        //Hide_Modal();

                    } else {


                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }






        //---------------------------------------
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
         DOC_APELLIDO: ""
     }
        ];


        function Ajax_Busca_Info_Por_Avis() {

            var Data_Par = JSON.stringify({
                "NUM_AVIS": $("#txt_Contenido").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Traza_Pap.aspx/Llenar_AVIS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Avis = JSON.parse(json_receiver)                       

                        selected.push($("#txt_Contenido").val());
                        $("#lbl_Total_Numeros_Avis").val(selected);
                        $("#txt_Contenido").val("");
                        console.log("si es");
                        //Hide_Modal();

                    } else {

                        Hide_Modal();
                        $("#txt_Contenido").val("");
                        console.log("lo borramos");
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

            $.ajax({
                "type": "POST",
                "url": "Traza_Pap.aspx/Llenar_Ddl_LugarTM",
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
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }


        //------------------------------------------------- BUSCAR DOCUMENTOS ---------------------------------
        var Mx_Dtt = [
    {
        "ID_PAP_CAJA": 0,
        "ID_USUARIO": 0,
        "FECHA_CREACION_CAJA": 0,
        "COMENTARIO_CAJA": 0,
        "TIPO_CAJA": 0,
        "ID_ESTADO": 0,
        "USU_NIC": 0,
        "USU_ADMIN": 0,
        "PROC_DESC": 0
    }
        ];
        function Ajax_DataTable() {

        var Data_Par = JSON.stringify({
            "DESDE": $("#Txt_Date01 input").val(),
            "HASTA": $("#Txt_Date02 input").val(),
            "LUGARTM": $("#Ddl_LugarTM").val()

        });

            modal_show();
            $.ajax({
                "type": "POST",
                "url": "Traza_Pap.aspx/IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP_CAJA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt = json_receiver;
                        //Mx_Dtt_Lugar_Pertenece_Respaldo = JSON.parse(json_receiver);

                        $("#Div_Tabla_Prevision").empty();
                        $("#DataTable_Prevision").empty();
                        Fill_DataTable();
                        Hide_Modal();

                    } else {
                        $("#Div_Tabla_Prevision").empty();
                        $("#DataTable_Prevision").empty();
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

        //------------------------------------------------ GRABA CAJA -------------------------------------------------

        function Ajax_IRIS_WEBF_GRABA_CAJA() {
            modal_show();

            var permisss = Galletas.getGalleta("ID_USER");

            var Data_Par = JSON.stringify({
                "COMENTARIO": $("#txt_Comentario").val(),
                "TIPO": $("#txt_Tipo").val(),
                "ID_USUARIO": permisss,
                "MATRIZ_NUM_AVIS": selected,     
                "ID_PROC": $("#Ddl_LugarTM2").val(),

            });
            $.ajax({
                "type": "POST",
                "url": "Traza_Pap.aspx/IRIS_WEBF_GRABA_CAJA_TRAZA_PAP",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                //"dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != 0) {
                        Hide_Modal();
                        Ajax_DataTable();
                        $("#mCrear").modal("hide");
                        $("#mError_AAH h4").text("Creación Exitosa");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("El lote ha sido creado exitosamente.");
                        $("#mError_AAH").modal();
                        
                    } else {
                        $("#mCrear").modal("hide");
                        Hide_Modal();
                        $("#mError_AAH h4").text("Error");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se ha podido crear el lote.");
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

            //------------------------------------------------- BUSCAR DETALLE CAJA ---------------------------------
        var Mx_Dtt_Detalle_Caja = {
            "proparra1_SUPER": [{
                "ID_TRAZA_PAP": 0,
                "ID_USUARIO": 0,
                "FECHA_TRAZA": 0,
                "NUM_TRAZA": 0,
                "ID_ESTADO": 0,
                "ID_ESTADO_USU": 0,
                "USU_NIC": 0,
                "USU_ADMIN": 0,
                "ID_ESTADO_CAJA": 0

            }],
            "proparra2_SUPER": [{
                "HO_CC": 0,
                "ID_ATENCION": 0,
                "ATE_NUM": 0,
                "ATE_FECHA": 0,
                "PROC_DESC": 0,
                "PREVE_DESC": 0,
                "PAC_RUT": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "PAC_FNAC": 0,
                "ID_SEXO": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "ATE_OBS_FICHA": 0,
                "ATE_AÑO": 0
            }]
        }


            function Ajax_DataTable_Detalle_Caja(ID_CAJA) {

                var Data_Par = JSON.stringify({
                    "ID_CAJA": ID_CAJA
                });

                $.ajax({
                    "type": "POST",
                    "url": "Traza_Pap.aspx/IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP",
                    "data": Data_Par,
                    "contentType": "application/json;  charset=utf-8",
                    "dataType": "json",
                    "success": Data_Par_modal_paciente =>{
                        Mx_Dtt_Detalle_Caja = Data_Par_modal_paciente.d;

                            $("#DataTable_Detalle_Caja").empty();
                            $("#Div_Tabla_Detalle_Caja").empty();

                            $("#Div_Tabla_Detalle_Folios").empty();
                            $("#DataTable_Detalle_Folio").empty();

                            Fill_DataTable_Detalle_Caja();
                            Hide_Modal();


                            //Hide_Modal();
                            //$("#mError_AAH h4").text("Sin resultados");
                            //$("#mError_AAH button").attr("class", "btn btn-danger");
                            //$("#mError_AAH p").text("No se han encontrado resultados");
                            //$("#mError_AAH").modal();
                        
                    },
                    "error": function (response) {
                        var str_Error = response.responseJSON.ExceptionType + "\n \n";
                        str_Error = response.responseJSON.Message;
                        alert(str_Error);

                    }
                });
            };

        //------------------------------------------------ RECIBIR CAJA -------------------------------------------------

        function IRIS_WEBF_RECIBIR_CAJA() {
            //modal_show();

            var permissssssssoooww = Galletas.getGalleta("ID_USER");

            var Data_Par = JSON.stringify({
                "ID_USUARIO": permissssssssoooww,
                "NUM_TRAZA": Mx_Dtt_Detalle_Caja.proparra1_SUPER[0].NUM_TRAZA

            });
            $.ajax({
                "type": "POST",
                "url": "Traza_Pap.aspx/IRIS_WEBF_RECIBIR_CAJA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                //"dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != 0) {
                        Hide_Modal();

                        $("#mDetalleCaja").modal('hide');
                        $("#mError_AAH h4").text("Lote Recibida");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("El lote ha sido recibido exitosamente.");
                        $("#mError_AAH").modal();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Actualización No Completada");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se ha podido actualizar el documento.");
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

        var Mx_Dtt_PDF = [
            {
                "urls": ""
            }
        ];

        function Ajax_PDF(ID_CAJA) {
            modal_show();


            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "ID_CAJA": ID_CAJA
            });
            $.ajax({
                "type": "POST",
                "url": "Traza_Pap.aspx/PDF",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {0
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
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    //alert(str_Error);
                    Hide_Modal();
                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Se ha producido un error: " + str_Error);
                    $("#mError_AAH").modal();


                }
            });
        }

        var Mx_Dtt_Excel = [
        {
            "urls": ""
        }
        ];

        function Ajax_Excel(ID_CAJA) {

            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "ID_CAJA": ID_CAJA
            });
            $.ajax({
                "type": "POST",
                "url": "Traza_Pap.aspx/Excel",
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
        //------------------------------------------------- ELIMINAR CAJA ---------------------------------
        var checcccck2 = 0;

        function Ajax_DataTable_ELIMINAR_CAJA() {

            var Data_Par = JSON.stringify({
                "ID_CAJA": AIDI_ELIMINAR
            });

            $.ajax({
                "type": "POST",
                "url": "Traza_Pap.aspx/IRIS_WEBF_ELIMINAR_TRAZA_PAP",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver = 1) {
                        checcccck2 = json_receiver;
                        AIDI_ELIMINAR = 0;

                        $("#mELIMINAR").modal("hide");

                        Ajax_DataTable();

                    } else {

                        Hide_Modal();
                        AIDI_ELIMINAR = 0;
                        console.log("NOOOOO");
                        $("#txt_Obs_Fin").val("");

                        $("#mELIMINAR").modal("hide");
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se ha podido eliminar el lote");
                        $("#mError_AAH").modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        };



        //------------------------------------------------- FINALIZAR CAJA ---------------------------------
        var checcccck = 0;


        function Ajax_DataTable_FINALIZAR_CAJA() {

            var Data_Par = JSON.stringify({
                "ID_CAJA": AIDI_FINALIZAR,
                "COMENTARIO": $("#txt_Obs_Fin").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Traza_Pap.aspx/IRIS_WEBF_FINALIZAR_TRAZA_PAP",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver = 1) {
                        checcccck = json_receiver;
                        AIDI_FINALIZAR = 0;
                        $("#txt_Obs_Fin").val("");
                        $("#mFinalizar").modal("hide");
                        console.log("BORRADA");
                        Ajax_DataTable();

                    } else {

                        Hide_Modal();
                        AIDI_FINALIZAR = 0;
                        console.log("NOOOOO");
                        $("#txt_Obs_Fin").val("");

                        $("#mFinalizar").modal("hide");
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se ha podido finalir la recepción del lote");
                        $("#mError_AAH").modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        };

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
            //----------------------------------------------------------------------------------------------

            if (permisRecep == "1") {
                $("<option>", { "value": "0" }).text("Seleccione").appendTo("#Ddl_LugarTM2");

                Mx_Dtt_LugarTM.forEach(bbb => {
                    $("<option>",
                        {
                            "value": bbb.ID_PROCEDENCIA
                        }
                    ).text(bbb.PROC_DESC).appendTo("#Ddl_LugarTM2");
                });

            } else if ((usu_te_eme == "0") && (permisRecep != "1")) {
                $("<option>", { "value": "0" }).text("Todos").appendTo("#Ddl_LugarTM2");

                Mx_Dtt_LugarTM.forEach(bbb => {
                    $("<option>",
                        {
                            "value": bbb.ID_PROCEDENCIA
                        }
                    ).text(bbb.PROC_DESC).appendTo("#Ddl_LugarTM2");
                });


            } else {
                Mx_Dtt_LugarTM.forEach(bbb => {
                    if (bbb.ID_PROCEDENCIA == usu_te_eme) {
                        $("<option>", { "value": bbb.ID_PROCEDENCIA }).text(bbb.PROC_DESC).appendTo("#Ddl_LugarTM2");
                    }
                });
            }
            
        };

    </script>

    <script>
        //------------------------------------------------------------------ TABLA VER -------------------------------------------|
        function Fill_DataTable() {
            $("<table>", {
                "id": "DataTable_Prevision",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Prevision");
            $("#DataTable_Prevision").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Prevision").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Prevision thead").attr("class", "cabzera");
            $("#DataTable_Prevision thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Lote Num"),
                    $("<th>", { "class": "textoReducido" }).text("Creado por"),
                    //$("<th>", { "class": "textoReducido" }).text("????"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Creación"),
                    $("<th>", { "class": "textoReducido" }).text("Número de Contenedor"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Matrona"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar TM"),
                    $("<th>", { "class": "textoReducido" }).text("Detalles"),
                    $("<th>", { "class": "textoReducido" }).text("Exportar"),
                    $("<th>", { "class": "textoReducido" }).text("Imprimir"),
                    $("<th>", { "class": "textoReducido" }).text("Finalizar"),
                    $("<th>", { "class": "textoReducido" }).text("Eliminar")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable_Prevision tbody").append(
                    $("<tr>", {
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ID_PAP_CAJA),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].USU_NIC),
                        //$("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                        //    $(this).append($("<input>", { type: "input", class: "textoReducido mayus", "data-desc": Mx_Dtt[i].DCTO_DESC, "data-input": 12345, "data-ide": Mx_Dtt[i].ID_DCTO }).val(Mx_Dtt[i].DCTO_DESC));
                        //}),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(moment(Mx_Dtt[i].FECHA_CREACION_CAJA).format("DD/MM/YYYY HH:mm")),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].COMENTARIO_CAJA),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].TIPO_CAJA),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PROC_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {                      
                            $(this).append($("<button>", { type: "button", class: "btn btn-warning btn-sm", "data-ruta": Mx_Dtt[i].ID_PAP_CAJA, "data-btn": 1 }).text("Detalles"));
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {                      
                            $(this).append($("<button>", { type: "button", class: "btn btn-success btn-sm", "data-ruta": Mx_Dtt[i].ID_PAP_CAJA, "data-btn": 2 }).text("Exportar"));
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {                      
                            $(this).append($("<button>", { type: "button", class: "btn btn-info btn-sm", "data-ruta": Mx_Dtt[i].ID_PAP_CAJA, "data-btn": 3 }).text("Imprimir"));
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            //admin o los 5 usuarios web
                            if (((permisRecep == "1") || (permisRecep == "9") || ((ususWeb == "247") || (ususWeb == "57") || (ususWeb == "65") || (ususWeb == "49") || (ususWeb == "51") || (ususWeb == "145"))) && (Mx_Dtt[i].ID_ESTADO_USU != 3) && (permisRecep != "8")) {
                            $(this).append($("<button>", { type: "button", class: "btn btn-danger btn-sm", "data-ruta": Mx_Dtt[i].ID_PAP_CAJA, "data-btn": 4 }).text("Finalizar"));
                            } else {
                                $(this).append($("<button>", { disabled: "disabled", type: "button", class: "btn btn-dark btn-sm" }).text("Finalizar"));
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            //admin o los 5 usuarios web
                            if (((permisRecep == "1") || (permisRecep == "9") || ((ususWeb == "247") || (ususWeb == "57") || (ususWeb == "65") || (ususWeb == "49") || (ususWeb == "51") || (ususWeb == "145"))) && (permisRecep != "8")) {
                                $(this).append($("<button>", { type: "button", class: "btn btn-dark btn-sm", "data-ruta": Mx_Dtt[i].ID_PAP_CAJA, "data-btn": 5 }).text("Eliminar"));
                            } else {
                                $(this).append($("<button>", { disabled: "disabled", type: "button", class: "btn btn-dark btn-sm" }).text("Eliminar"));
                            }
                        })
                    )
                );            
            }

            $("#DataTable_Prevision button[data-btn=1]").click((ev) => {
                ev.stopImmediatePropagation();

                let strRuta = $(ev.currentTarget).attr("data-ruta");
                Ajax_DataTable_Detalle_Caja(strRuta);
            });

            $("#DataTable_Prevision button[data-btn=2]").click((ev) => {
                ev.stopImmediatePropagation();

                let strExcel = $(ev.currentTarget).attr("data-ruta");
                Ajax_Excel(strExcel);
            });

            $("#DataTable_Prevision button[data-btn=3]").click((ev) => {
                ev.stopImmediatePropagation();

                let strHabilitar = $(ev.currentTarget).attr("data-ruta");
                Ajax_PDF(strHabilitar);
            });

            $("#DataTable_Prevision button[data-btn=4]").click((ev) => {
                ev.stopImmediatePropagation();
                AIDI_FINALIZAR = $(ev.currentTarget).attr("data-ruta");
                $("#mFinalizar").modal();

                //Ajax_PDF(strHabilitar);
            });

            $("#DataTable_Prevision button[data-btn=5]").click((ev) => {
                ev.stopImmediatePropagation();
                AIDI_ELIMINAR = $(ev.currentTarget).attr("data-ruta");
                $("#mELIMINAR").modal();
                //Ajax_PDF(strHabilitar);
            });

            $("#DataTable_Prevision tbody tr").click(function () {
                $("#DataTable_Prevision tbody tr").removeClass("active");       
                $(this).addClass("active");
               
            });

            //$("#DataTable_Prevision tbody tr input[data-input=12345]").change((ev) => {
            //    ev.stopImmediatePropagation();
                
            //    let strIde = $(ev.currentTarget).attr("data-ide");
            //    let strDesc = $(ev.currentTarget).val();

            //    console.log(strDesc);
            //    console.log(strIde);
            //    IRIS_WEBF_UPDATE_DCTO_DESC(strIde, strDesc);
            //});

            $("#DataTable_Prevision").DataTable({
                "bSort": true,
                "binfo": false,
                "bSort": true,
                "iDisplayLength": 100,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay concidencias",
                    "info": "Mostrando Página _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se buscó en _MAX_ registros)",
                    "search": "<strong><i class='fa fa-search'></i> Filtro: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
        }

        //------------------------------------------------------------------ TABLA DETALLE CAJA -------------------------------------------|
        function Fill_DataTable_Detalle_Caja() {
            $("<table>", {
                "id": "DataTable_Detalle_Caja",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Detalle_Caja");
            $("#DataTable_Detalle_Caja").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Detalle_Caja").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Detalle_Caja thead").attr("class", "cabzera");
            $("#DataTable_Detalle_Caja thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Recepcionado por"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Recep")

                )
            );
            for (i = 0; i < Mx_Dtt_Detalle_Caja.proparra1_SUPER.length; i++) {
                $("#DataTable_Detalle_Caja tbody").append(
                    $("<tr>", {
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Detalle_Caja.proparra1_SUPER[i].USU_NIC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(moment(Mx_Dtt_Detalle_Caja.proparra1_SUPER[i].FECHA_TRAZA).format("DD/MM/YYYY HH:mm"))
                    )
                );
            }

            $("#DataTable_Detalle_Caja button[data-btn=1]").click((ev) => {
                ev.stopImmediatePropagation();

                let strRuta = $(ev.currentTarget).attr("data-ruta");
                Ajax_DataTable_Detalle_Caja(strRuta);
            });

            var permiss = Galletas.getGalleta("ID_USER");
            if ((permiss == Mx_Dtt_Detalle_Caja.proparra1_SUPER[0].ID_USUARIO) && (Mx_Dtt_Detalle_Caja.proparra1_SUPER[0].ID_ESTADO_USU == 2)) {
                $("#btn_Recibir").attr("disabled", true);
                $("#Lbl_RecepONo").text("Lote ya Recepcionado");
            }else if(Mx_Dtt_Detalle_Caja.proparra1_SUPER[0].ID_ESTADO_CAJA == "3"){
                $("#btn_Recibir").attr("disabled", true);
                $("#Btn_Editar").attr("disabled", true);
                
                $("#Lbl_RecepONo").text("Lote Finalizado");
            }
            else{
                $("#btn_Recibir").attr("disabled", false);
                $("#Btn_Editar").attr("disabled", false);
                $("#Lbl_RecepONo").text("Lote en espera");
            }

            $("#txt_total_folios").val(Mx_Dtt_Detalle_Caja.proparra1_SUPER[0].MATRIZ_NUM_AVIS);

            $("#mDetalleCaja").hide('hide');
            $("#mDetalleCaja").modal('show');

            Fill_DataTable_Detalle_Folio();
        }

        //------------------------------------------------------------------ TABLA DETALLE FOLIOS -------------------------------------------|
        function Fill_DataTable_Detalle_Folio() {
            $("<table>", {
                "id": "DataTable_Detalle_Folio",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Detalle_Folios");
            $("#DataTable_Detalle_Folio").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Detalle_Folio").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Detalle_Folio thead").attr("class", "cabzera");
            $("#DataTable_Detalle_Folio thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Folio Avis"),
                    $("<th>", { "class": "textoReducido" }).text("Ate Num."),
                    $("<th>", { "class": "textoReducido" }).text("Ate Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Rut"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Pac."),
                    $("<th>", { "class": "textoReducido" }).text("Edad")

                )
            );
            for (i = 0; i < Mx_Dtt_Detalle_Caja.proparra2_SUPER.length; i++) {
                $("#DataTable_Detalle_Folio tbody").append(
                    $("<tr>", {
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Detalle_Caja.proparra2_SUPER[i].HO_CC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(() => {
                            if (Mx_Dtt_Detalle_Caja.proparra2_SUPER[i].ATE_NUM == 0) {
                                return "Orden no cargada en Iris";
                            }else{
                                return Mx_Dtt_Detalle_Caja.proparra2_SUPER[i].ATE_NUM;
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(() => {
                            if (moment(Mx_Dtt_Detalle_Caja.proparra2_SUPER[i].ATE_FECHA).format("DD/MM/YYYY HH:mm") == "31/12/0000 22:17") {
                                return "-";
                            } else {
                                return moment(Mx_Dtt_Detalle_Caja.proparra2_SUPER[i].ATE_FECHA).format("DD/MM/YYYY HH:mm");
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(() => {
                            if (Mx_Dtt_Detalle_Caja.proparra2_SUPER[i].PAC_RUT == null) {
                                return "-";
                            } else {
                                return Mx_Dtt_Detalle_Caja.proparra2_SUPER[i].PAC_RUT;
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(() => {
                            if (Mx_Dtt_Detalle_Caja.proparra2_SUPER[i].PAC_NOMBRE == null) {
                                return "-";
                            } else {
                                return Mx_Dtt_Detalle_Caja.proparra2_SUPER[i].PAC_NOMBRE + " " + Mx_Dtt_Detalle_Caja.proparra2_SUPER[i].PAC_APELLIDO;
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(()=>{
                            if(Mx_Dtt_Detalle_Caja.proparra2_SUPER[i].ATE_AÑO == null){
                                return "-";
                            }else{
                                return Mx_Dtt_Detalle_Caja.proparra2_SUPER[i].ATE_AÑO + " Años";
                            }
                        })
                    )
                );
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
        #DataTable_Ate tbody td {
            text-transform: uppercase;
        }
        #DataTable_Lis_Exa_Ate tbody td {
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
        .cabzera {
            background: #46963f;
            color: white;
        }
        .textoReducido {
            font-size: 12px;
        }
        .highlights {
            width: 710px;
            height: 380px; /* Ancho y alto fijo */
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

            .borderBajo {
                margin-bottom:50px;
                padding:50px;
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
                </div>-
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

            <!-- Modal DETALLE CAJA -->
    <div id="mDetalleCaja" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="Lbl_RecepONo"></h4>
                </div>
                <div class="modal-body">
                    <div class="col-md-12">
                    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i> Folios Contenidos</h5>
                    <div class="row">
                        <div class="col-md">
                            <div id="Div_Tabla_Detalle_Folios" style="width:100%;" class="highlights"></div>
                        </div>
                    </div>    
                  <%--  </div> 
                    <div class="col-md-12">--%>
                    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i> Historial de Recepción</h5>
                    <div class="row">
                        <div class="col-md">
                            <br />
                            <div id="Div_Tabla_Detalle_Caja" style="width:100%;" class="highlights"></div>
                        </div>
                    </div>    
                </div>  
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="Btn_Editar" class="btn btn-primary" style="width:100px">Editar</button>
                    <button type="button" id="btn_Recibir" class="btn btn-success">Recibir</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Crear Caja -->
    <div id="mCrear" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Crear Lote</h4>
                </div>
                <div class="modal-body">
                    <div class="col-sm">
                        <label for="txt_Comentario">N° de Contenedor:</label>
                        <input id="txt_Comentario" class="form-control"/>
                    </div>
                    <div class="col-sm">
                        <label for="txt_Tipo">Nombre Matrona:</label>
                        <input id="txt_Tipo" class="form-control"/>
                        <br />
                        <label>Lugar de TM:</label>
                        <select id="Ddl_LugarTM2" class="form-control">
                        </select>
                    </div>
                    <br />
                    <div class="col-sm">
                        <label for="txt_Contenido">Contenido (Presione tecla ENTER para agregar)</label>
                        <input id="txt_Contenido"class="form-control" onkeydown="return jsDecimals(event);"/>
                        <br />
                        <label>Órdenes AVIS</label>
                        <textarea id="lbl_Total_Numeros_Avis" disabled="disabled" class="form-control" rows="8"></textarea>
                    </div>
                    <br />      
                    <label id="Lbl_Faltantes" style="color:red;">Rectifique datos faltantes.</label>     
                </div> 
                <div class="modal-footer">
                    <button type="button" id="Btn_Limpiar" class="btn btn-info" style="width:100px">Limpiar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btn_Subir_Archivo" class="btn btn-success">Crear</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal ELIMINAR Caja -->
    <div id="mELIMINAR" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Eliminar</h4>
                </div>
                <div class="modal-body">
                    <div class="col-sm">
                        <label>¿Está seguro(a) que desea ELIMINAR la este lote?</label>
                    </div>
                    <br />           
                </div> 
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btn_Eliminar" class="btn btn-success">Eliminar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal FINALIZAR Caja -->
    <div id="mFinalizar" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Finalizar</h4>
                </div>
                <div class="modal-body">
                    <div class="col-sm">
                        <label>¿Está seguro(a) que desea finalizar la recepción de este lote?</label>
                    </div>
                    <div class="col-sm">
                        <label for="txt_Obs_Fin">Observaciones:</label>
                        <textarea id="txt_Obs_Fin" class="form-control" rows="8"></textarea>
                    </div>
                    <br />           
                </div> 
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btn_Finalizar" class="btn btn-success">Finalizar</button>
                </div>
            </div>
        </div>
    </div>
        <!-- Modal EDITAR FOLIOS Caja -->
    <div id="mEditar" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Editar</h4>
                </div>
                <div class="modal-body">
                    <div class="col-sm">
                        <label>¿Desea modificar folios?</label>
                    </div>
                    <div class="col-sm" id="col_folios">
                    </div>
                    <br />           
                </div> 
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btn_Guardar_Editar" class="btn btn-success">Guardar</button>
                </div>
            </div>
        </div>
    </div>
    <%------------------------------------------------------TÍTULO, TEXTBOX Y BOTONES-----------------------------------------%>
    <div class="row">
        <div class="col-lg-12">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar">
                <h5 style="text-align: center; padding: 5px;">
                    <i class="fa fa-info"></i>
                    Visualización y Recepción de Lotes PAP
<%--                    <button type="button" id="btn_numero" class="btn btn-success">check!!!!</button>
                    <input id="txt_numero"/>
                    <label id="lbl_numero"></label>--%>
                </h5>
            </div>
            </div>

            <%------------------------------------------------------------ TABLAS -------------------------------------------------------------%>
            <div class="row">
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
                    <label>Lugar de TM:</label>
                    <select id="Ddl_LugarTM" class="form-control">
                    </select>
                </div>
                <div class="col-md">
                    <br />
                    <button type="button" id="btn_Buscar" class="btn btn-success"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                </div>
                <div class="col-md">
                    <br />
                    <button type="button" id="btn_Modal_Subir" class="btn btn-info"><i class="fa fa-fw fa-upload mr-2"></i>Crear Lote</button>
                </div>       
            </div>
            <div class="row mb-3" id="Id_Conte">
                <div class="col-md-12">
                    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i> Listado de Documentos</h5>
                    <div class="row">
                        <div class="col-md">
                            <div id="Div_Tabla_Prevision" style="width:100%;" class="highlights"></div>
                        </div>
                    </div>    
                </div>  
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>
    </div>
</asp:Content>
