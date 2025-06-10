<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Documentos.aspx.vb" Inherits="Presentacion.Documentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <script src="../../js/moment_es.js"></script>
    <script src="../../js/moment.js"></script>

       <script>
           let DESCrip = "";
           var B64Firma = "";

           $(document).ready(function () {
               Fill_Ddl_Tipo();
               function readFile() {
                   if (this.files && this.files[0]) {
                       var FR = new FileReader();
                       FR.addEventListener("load", function (e) {
                           if (e.target.result != "") {
                               B64Firma = e.target.result;
                           }
                           else {
                               B64Firma = "vacio";
                           }

                       });
                       FR.readAsDataURL(this.files[0]);
                   }
               }

               document.getElementById("Inp_Image").addEventListener("change", readFile);

               Ajax_DataTable();

               $("#btn_Modal_Subir").click(function (){
                   $("#mSubirModal").modal("hide");
                   $("#mSubirModal").modal("show");
               });

               $("#btn_Subir_Archivo").click(function () {
                   if ($("#txtCodigo").val() == "" || $("#txtDescripcion").val() == "" || $("#Ddl_Tipo").val() == 0 || $("#Ddl_Codigo").val() == 0 || $("#Ddl_Descripcion").val() == 0) {
                       $("#mSubirModal").modal("hide");
                       $("#mError_AAH h4").text("Ingrese");
                       $("#mError_AAH button").attr("class", "btn btn-danger");
                       $("#mError_AAH p").text("Debe ingresar código, descripción y tipo para el archivo.");
                       $("#mError_AAH").modal();

                   }else if($('#Inp_Image').val() == ""){
                       $("#mSubirModal").modal("hide");
                       $("#mError_AAH h4").text("Ingrese");
                       $("#mError_AAH button").attr("class", "btn btn-danger");
                       $("#mError_AAH p").text("Debe seleccionar un archivo para subir.");
                       $("#mError_AAH").modal();
                   } else {
                       
                       Ajax_IRIS_WEBF_GRABA_DOCUMENTO();
                   }             
            });
            
                $("#Ddl_Codigo").empty();
                $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#Ddl_Codigo");
                $("<option>", { "value": 1 }).text("TOMA DE MUESTRAS").appendTo("#Ddl_Codigo");
                $("<option>", { "value": 2 }).text("INSTRUCTIVOS PASO A PASO").appendTo("#Ddl_Codigo");
                $("<option>", { "value": 3 }).text("BIOSEGURIDAD").appendTo("#Ddl_Codigo");
                $("<option>", { "value": 4 }).text("DOCUMENTOS NORMATIVOS").appendTo("#Ddl_Codigo");
                $("<option>", { "value": 5 }).text("INFORMACION GENERAL").appendTo("#Ddl_Codigo");
                $("<option>", { "value": 6 }).text("REAS").appendTo("#Ddl_Codigo");
                $("<option>", { "value": 7 }).text("PAP").appendTo("#Ddl_Codigo");

               //DESCRIPCIÓN
               $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#Ddl_Descripcion");
               
               $("#Ddl_Codigo").change(function () {
                   $("#Ddl_Descripcion").empty();

                   if ($("#Ddl_Codigo").val() == 0) {
                       $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#Ddl_Descripcion");
                   }
                   else if ($("#Ddl_Codigo").val() == 1) {
                       $("<option>", { "value": 11 }).text("Evaluacion condiciones transporte de muestras").appendTo("#Ddl_Descripcion");
                       $("<option>", { "value": 12 }).text("Reporte mensual rechazo de muestras").appendTo("#Ddl_Descripcion");
                       $("<option>", { "value": 13 }).text("Documentos Toma muestras").appendTo("#Ddl_Descripcion");
                   }
                   else if ($("#Ddl_Codigo").val() == 2) {
                       $("<option>", { "value": 21 }).text("Irislab").appendTo("#Ddl_Descripcion");
                   }
                   else if ($("#Ddl_Codigo").val() == 3) {
                       $("<option>", { "value": 31 }).text("Documentos Bioseguridad").appendTo("#Ddl_Descripcion");
                   }
                   else if ($("#Ddl_Codigo").val() == 4) {
                       $("<option>", { "value": 41 }).text("Documentos legales").appendTo("#Ddl_Descripcion");
                       $("<option>", { "value": 42 }).text("Normativas, circulares").appendTo("#Ddl_Descripcion");
                   }
                   else if ($("#Ddl_Codigo").val() == 5) {
                       $("<option>", { "value": 51 }).text("Informaciones varias").appendTo("#Ddl_Descripcion");
                   }
                   else if ($("#Ddl_Codigo").val() == 6) {
                       $("<option>", { "value": 61 }).text("Certificados  Disposicion Final de Residuos").appendTo("#Ddl_Descripcion");
                       $("<option>", { "value": 62 }).text("Analisis estadistico de Residuos generados").appendTo("#Ddl_Descripcion");
                       $("<option>", { "value": 63 }).text("Normativa legal de REAS").appendTo("#Ddl_Descripcion");
                       $("<option>", { "value": 64 }).text("Protocolos internos manejo REAS").appendTo("#Ddl_Descripcion");
                   }
                   else if ($("#Ddl_Codigo").val() == 7) {
                       $("<option>", { "value": 71 }).text("Informacion general").appendTo("#Ddl_Descripcion");
                       $("<option>", { "value": 72 }).text("Registro de trazabilidad de PAP").appendTo("#Ddl_Descripcion");
                   }
               });

          
        });
    </script>
    <script>

        //------------------------------------------------- BUSCAR DOCUMENTOS ---------------------------------
        var Mx_Dtt = [
    {
        "ID_DCTO": 0,
        "DCTO_COD": 0,
        "DCTO_DESC": 0,
        "DCTO_TIPO": 0,
        "DCTO_ORDEN": 0,
        "DCTO_FECHA": 0,
        "DCTO_RUTA": 0,
        "ID_ESTADO": 0
    }
        ];
        function Ajax_DataTable() {
            modal_show();
            $.ajax({
                "type": "POST",
                "url": "Documentos.aspx/IRIS_WEBF_BUSCA_DOCUMENTOS_MANTENEDOR",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt = json_receiver;
                        //Mx_Dtt_Lugar_Pertenece_Respaldo = JSON.parse(json_receiver);

                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].DCTO_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].DCTO_FECHA = Date_Change;
                        }
                        $("#Div_Tabla_Prevision").empty();
                        $("#DataTable_Prevision").empty();
                        Fill_DataTable();
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

        //------------------------------------------------ GRABA DOCUMENTO-------------------------------------------------

        function Ajax_IRIS_WEBF_GRABA_DOCUMENTO() {
            modal_show();
            //console.log("Inicializando petición de datos:");
            //console.log('"UPDATE Usuario.."');
            var Data_Par = JSON.stringify({
                "DCTO_DESC": $("#Ddl_Descripcion option:selected").text(),
                "DCTO_TIPO": $("#Ddl_Tipo").val(),
                "DCTO_FECHA": moment(),
                "DCTO_RUTA": $('#Inp_Image').val(),
                "DCTO_BITS": B64Firma,
                "DCTO_COD": $("#Ddl_Codigo option:selected").text()

            });
            $.ajax({
                "type": "POST",
                "url": "Documentos.aspx/IRIS_WEBF_GRABA_DOCUMENTO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                //"dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != 0) {
                        if (json_receiver == 3) {
                            $("#mSubirModal").modal("hide");
                            Hide_Modal();
                            $("#mError_AAH h4").text("Carga NO Realizada");
                            $("#mError_AAH button").attr("class", "btn btn-danger");
                            $("#mError_AAH p").text("El documento ya se encuentra cargado.");
                            $("#mError_AAH").modal();
                        } else {
                            Mx_Dtt = JSON.parse(json_receiver);

                            Guardar_En_Servers();

                        }
                        
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Actualización No Completada");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se ha podido guardar el documento.");
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

        function Guardar_En_Servers() {
            var form = new FormData();
            var inputFile = document.getElementById("Inp_Image");
            form.append("file", inputFile.files[0]);

            $.ajax({
                data: form,
                processData: false,
                contentType: false,
                type: 'POST',
                datatype: 'json',
                url: '/Uploads.ashx',
                success: function (data) {
                    $("#mSubirModal").modal("hide");
                    Hide_Modal();
                    $("#eModal_Old_User").modal('hide');
                    $("#mError_AAH h4").text("Guardado Exitoso");
                    $("#mError_AAH button").attr("class", "btn btn-success");
                    $("#mError_AAH p").text("El documento se ha guardado exitosamente.");
                    $("#mError_AAH").modal();
                    Ajax_DataTable();
                },
                error: function (xhr, textStatus, errorThrown) {
                    Hide_Modal();
                    $("#mError_AAH h4").text("Error al Guardar");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("No se ha podido guardar el archivo.");
                    $("#mError_AAH").modal();
                },
                cache: false
            });
        };

        //-------------------------------- AJAX PARA ABRIR EL DOCUMENTO
        function Ajax_Ver_Documento(UURRLL) {
            var xURL = "/uploads/";
            console.log("Click Ver");
            window.open(location.origin + xURL + UURRLL, "_blank");

        };

        //------------------------------- AJAX ELIMINAR DOCUMENTO
        function Ajax_Eliminar_Documento(ID_DOCU) {

            var Data_Par = JSON.stringify({
                "ID_DCTO": ID_DOCU
            });
            $.ajax({
                "type": "POST",
                "url": "Documentos.aspx/IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                //"dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != 0) {
                       
                        Ajax_DataTable();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Actualización No Completada");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se ha podido eliminar el documento.");
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
        
        //------------------------------- AJAX HABILITAR DOCUMENTO
        function Ajax_Habilitar_Documento(ID_DOCU) {

            var Data_Par = JSON.stringify({
                "ID_DCTO": ID_DOCU
            });
            $.ajax({
                "type": "POST",
                "url": "Documentos.aspx/IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS_HABILITAR",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                //"dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != 0) {

                        Ajax_DataTable();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Actualización No Completada");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se ha podido habilitar el documento.");
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

        //------------------------------------------------ UPDATE DESC DOCUMENTO-------------------------------------------------

        function IRIS_WEBF_UPDATE_DCTO_DESC(AIDI, DESCRIP) {
            //modal_show();
            var Data_Par = JSON.stringify({
                "ID_DCTO": AIDI,
                "DCTO_DESC": DESCRIP

            });
            $.ajax({
                "type": "POST",
                "url": "Documentos.aspx/IRIS_WEBF_UPDATE_DCTO_DESC",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                //"dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != 0) {
                        Ajax_DataTable_simple();
                        $("#mError_AAH h4").text("Actualización Completada");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("Se ha Actualizado la descripción del documento.");
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

        //------------------------------------------------- BUSCAR DOCUMENTOS SIMPLIFICADO ---------------------------------
        var Mx_Dtt = [
    {
        "ID_DCTO": 0,
        "DCTO_COD": 0,
        "DCTO_DESC": 0,
        "DCTO_TIPO": 0,
        "DCTO_ORDEN": 0,
        "DCTO_FECHA": 0,
        "DCTO_RUTA": 0,
        "ID_ESTADO": 0
    }
        ];
        function Ajax_DataTable_simple() {
            $.ajax({
                "type": "POST",
                "url": "Documentos.aspx/IRIS_WEBF_BUSCA_DOCUMENTOS_MANTENEDOR",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt = json_receiver;
                        //Mx_Dtt_Lugar_Pertenece_Respaldo = JSON.parse(json_receiver);

                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].DCTO_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].DCTO_FECHA = Date_Change;
                        }
                        $("#Div_Tabla_Prevision").empty();
                        $("#DataTable_Prevision").empty();
                        Fill_DataTable();
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

    </script>

        <%-------------------------------------------------- FUNCION DE LLENADO DE ELEMENTOS -----------------------------------%>
    <script>
        //Llenar DropDownList Tipo de Atención
        function Fill_Ddl_Tipo() {
            $("#Ddl_Tipo").empty();
            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#Ddl_Tipo");
            $("<option>", { "value": 1 }).text("Pdf").appendTo("#Ddl_Tipo");
            $("<option>", { "value": 2 }).text("Word").appendTo("#Ddl_Tipo");
            $("<option>", { "value": 3 }).text("Excel").appendTo("#Ddl_Tipo");
            $("<option>", { "value": 4 }).text("Power Point").appendTo("#Ddl_Tipo");
            $("<option>", { "value": 5 }).text("Imagen").appendTo("#Ddl_Tipo");
            $("<option>", { "value": 6 }).text("Otro").appendTo("#Ddl_Tipo");
            //$("<option>", { "value": 7 }).text("Seleccionar").appendTo("#Ddl_Tipo");
            //$("<option>", { "value": 8 }).text("Seleccionar").appendTo("#Ddl_Tipo");
            //$("<option>", { "value": 9 }).text("Seleccionar").appendTo("#Ddl_Tipo");
            //$("<option>", { "value": 10 }).text("Seleccionar").appendTo("#Ddl_Tipo");

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
                    $("<th>", { "class": "textoReducido" }).text("Nombre Archivo"),
                    $("<th>", { "class": "textoReducido" }).text("Código"),
                    $("<th>", { "class": "textoReducido" }).text("Tipo"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),          
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Visualizar"),
                    $("<th>", { "class": "textoReducido" }).text("Habilitar/Eliminar")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable_Prevision tbody").append(
                    $("<tr>", {
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DCTO_RUTA),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DCTO_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt[i].DCTO_TIPO == 1) {
                                return "PDF"
                            } else if (Mx_Dtt[i].DCTO_TIPO == 2) {
                                return "WORD"
                            } else if (Mx_Dtt[i].DCTO_TIPO == 3) {
                                return "EXCEL"
                            } else if (Mx_Dtt[i].DCTO_TIPO == 4) {
                                return "POWER POINT"
                            } else if (Mx_Dtt[i].DCTO_TIPO == 5) {
                                return "IMAGEN"
                            } else if (Mx_Dtt[i].DCTO_TIPO == 6) {
                                return "OTRO"
                            }
                        }
                        ),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            $(this).append($("<input>", { type: "input", class: "textoReducido mayus", "data-desc": Mx_Dtt[i].DCTO_DESC, "data-input": 12345, "data-ide": Mx_Dtt[i].ID_DCTO }).val(Mx_Dtt[i].DCTO_DESC));
                        }),
                        //$("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DCTO_DESC),
                        //<input id="txtCodigo" class="form-control textoReducido mayus" type="text" />
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(moment(Mx_Dtt[i].DCTO_FECHA).format("DD/MM/YYYY HH:mm")),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {                      
                            if (Mx_Dtt[i].ID_ESTADO == 1) {
                                $(this).append($("<button>", { type: "button", class: "btn btn-success btn-sm", "data-ruta": Mx_Dtt[i].DCTO_RUTA, "data-btn": 1 }).text("Ver Documento"));
                            } else {
                                $(this).append($("<button>", { disabled: "disabled", type: "button", class: "btn btn-dark btn-sm", "data-ruta": Mx_Dtt[i].DCTO_RUTA, "data-btn": 2 }).text("Eliminado"));
                            }                               
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt[i].ID_ESTADO == 1) {
                                $(this).append($("<button>", {type: "button",class: "btn btn-danger btn-sm","data-ruta": Mx_Dtt[i].ID_DCTO,"data-btn": 3}).text("Eliminar"));
                            } else {
                                $(this).append($("<button>", { type: "button", class: "btn btn-success btn-sm", "data-ruta": Mx_Dtt[i].ID_DCTO, "data-btn": 4 }).text("Habilitar"));
                            }
                        })
                    )
                );            
            }

            $("#DataTable_Prevision button[data-btn=1]").click((ev) => {
                ev.stopImmediatePropagation();

                let strRuta = $(ev.currentTarget).attr("data-ruta");
                Ajax_Ver_Documento(strRuta);
            });

            $("#DataTable_Prevision button[data-btn=3]").click((ev) => {
                ev.stopImmediatePropagation();

                let strEliminar = $(ev.currentTarget).attr("data-ruta");
                Ajax_Eliminar_Documento(strEliminar);
            });

            $("#DataTable_Prevision button[data-btn=4]").click((ev) => {
                ev.stopImmediatePropagation();

                let strHabilitar = $(ev.currentTarget).attr("data-ruta");
                Ajax_Habilitar_Documento(strHabilitar);
            });

            $("#DataTable_Prevision tbody tr").click(function () {
                $("#DataTable_Prevision tbody tr").removeClass("active");       
                $(this).addClass("active");
               
            });

            $("#DataTable_Prevision tbody tr input[data-input=12345]").change((ev) => {
                ev.stopImmediatePropagation();
                
                let strIde = $(ev.currentTarget).attr("data-ide");
                let strDesc = $(ev.currentTarget).val();

                console.log(strDesc);
                console.log(strIde);
                IRIS_WEBF_UPDATE_DCTO_DESC(strIde, strDesc);
            });

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

        <!-- Modal -->
    <div id="mSubirModal" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Subir Archivo...</h4>
                </div>
                <div class="modal-body">
                    <%--<div class="row">--%>
                    <div class="col-sm">
                        <label for="Ddl_Codigo">Código:</label>
                        <select id="Ddl_Codigo" class="form-control textoReducido mayus">
                        </select>
                    </div>
                    <div class="col-sm">
                        <label for="Ddl_Descripcion">Descripción:</label>
                        <select id="Ddl_Descripcion" class="form-control textoReducido mayus">
                        </select>
                    </div>
                    <div class="col-sm">
                        <label for="Ddl_Tipo">Tipo:</label>
                        <select id="Ddl_Tipo" class="form-control textoReducido mayus">
                        </select>
                    </div>
                    <br />           
                    <%--</div>--%>
                    <form>
                        <div class="col-sm">
                            <%--<label for="Inp_Image">Subir Nuevo:</label>--%>
                            <label class="custom-file">
                                <input type="file" id="Inp_Image" class="custom-file-input">
                                <span class="custom-file-control" style="border-color: #868e96;"></span>
                            </label>
                            <style>
                                .custom-file-control:before {
                                    content: "Examinar";
                                    border-color: #868e96;
                                }

                                .custom-file-control:after {
                                    content: "";
                                    border-color: #868e96;
                                }

                                .custom-file-control.selected::after {
                                    content: "" !important;
                                }
                            </style>
                            <script>          
                                $('.custom-file-input').on('change', function () {
                                    var fileName = $(this).val().split('\\').slice(-1)[0];
                                    $(this).next('.custom-file-control').addClass("selected").html(fileName);
                                })
                            </script>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btn_Subir_Archivo" class="btn btn-success">Guardar</button>
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
                    Visualización y Carga de Documentos
                </h5>
            </div>
            </div>

            <%------------------------------------------------------------ TABLAS -------------------------------------------------------------%>
            <div class="row">
                <div class="col-md-10"></div>
                <div class="col-md-2">
                    <button type="button" id="btn_Modal_Subir" class="btn btn-info"><i class="fa fa-fw fa-upload mr-2"></i>Subir Archivo</button>
                </div>       
            </div>
            <div class="row mb-3" id="Id_Conte">
                <div class="col-md-12">
                    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i> Listado de Documentos</h5>
                    <%--<div class="col-md-8"></div>--%>
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
