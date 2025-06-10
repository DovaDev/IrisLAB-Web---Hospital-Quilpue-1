<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Ver_Orden.aspx.vb" Inherits="Presentacion.Ver_Orden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        let id_atee = "";
        let id_usu = "";
        let ate_numm = "";
        let imgSrc = "";
        let Mx_IMG = [{
            "ID_FOTO_ATE": "",
            "IMG": "",
            "USU_NIC": "",
            "FECHA_ASOC": "",
            "FOTO_ATE_PLATAFORMA": ""
        }];
        let Mx_DataTable = [{
            "ID_ATENCION": "",
            "ATE_NUM": "",
            "ID_PREINGRESO": "",
            "PREI_NUM": "",
            "ATE_FECHA": "",
            "PAC_NOMBRE": "",
            "PAC_APELLIDO": "",
            "ID_PACIENTE": "",
            "PAC_RUT": "",
            "PREVE_DESC": "",
            "PROC_DESC": ""
        }];
        let Mx_IMG_Asoc = [{
            "ID_FOTO_ATE": "",
            "NO_ASOC_NUM": "",
            "IMG": "",
            "FECHA_LOG": "",
            "USU_NIC": "",
            "FOTO_ATE_PLATAFORMA": ""
        }];
        let ARR_IMG = [];

        $(document).ready(function () {
            //CARGAR Y TRANSFORMA IMAGEN EN BASE64
            $(function () {
                $("#file1").change(function () {
                    if (this.files && this.files[0]) {
                        var reader = new FileReader();
                        reader.onload = imageIsLoaded;
                        reader.readAsDataURL(this.files[0]);
                    }
                });
            })

            $("#txt_Folio").val("");

            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input, #Txt_Date02 input").val(dateNow);

            $('#Txt_Date01, #Txt_Date02').datetimepicker({
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
            });

            id_usu = getParameterByName("IDU");
            id_atee = getParameterByName("IDA");
            let isn = $.isNumeric(id_atee);

            if (isn == true) {
                Data_Par = JSON.stringify({
                    "ID_ATENCION": id_atee
                });
                AJAX_Grabar = $.ajax({
                    "type": "POST",
                    "url": "Ver_Orden.aspx/Busca_Folio",
                    "data": Data_Par,
                    "contentType": "application/json;  charset=utf-8",
                    "dataType": "json",
                    "success": data => {
                        if (data != null) {
                            ate_numm = data.d
                            $("#txt_Folio").val(ate_numm);
                            Llenar_DataTable();
                            Llenar_IMG();
                            $("#Btn_Scan").removeAttr("hidden");
                            $("#Btn_Asoc").removeAttr("hidden");
                        } else {
                            $("#Btn_Scan_SF").removeAttr("hidden");
                        }
                    },
                    "error": data => {
                        console.log(data);
                        $("#Btn_Scan_SF").removeAttr("hidden");
                    }
                });
            } else {
                $("#Btn_Scan_SF").removeAttr("hidden");
            }

            $("#txt_Folio").focus();

            $("#Btn_Buscar").click(() => {
                ate_numm = $("#txt_Folio").val();
                Llenar_DataTable();
                // Llenar_IMG();
            });

            $("#Btn_Buscar_Asoc").click(() => {
                Llenar_IMG_ASOC();
            });

            $("#btn_Left").click(() => {
                let v_txt_Ate = $("#txt_Folio").val();
                if (v_txt_Ate != "" && $.isNumeric(v_txt_Ate) == true && v_txt_Ate > 1) {
                    v_txt_Ate = parseInt(v_txt_Ate) - 1;
                    $("#txt_Folio").val(v_txt_Ate);
                    ate_numm = v_txt_Ate;
                    Llenar_DataTable();
                    //Llenar_IMG();
                }
            });

            $("#btn_Right").click(() => {
                let v_txt_Ate = $("#txt_Folio").val();
                if (v_txt_Ate != "" && $.isNumeric(v_txt_Ate) == true) {
                    v_txt_Ate = parseInt(v_txt_Ate) + 1;
                    $("#txt_Folio").val(v_txt_Ate);
                    ate_numm = v_txt_Ate;
                    Llenar_DataTable();
                    //Llenar_IMG();
                }
            });

            $("#txt_Folio").on('keypress', (e) => {
                if (e.which == 13) {
                    ate_numm = $("#txt_Folio").val();
                    Llenar_DataTable();
                    //Llenar_IMG();
                }
            });
            //--------------------- SCANNER UPLOAD ----------------------
            $("#Btn_Scan").click(() => {
                $("#file1").val("");
                $("#ImgMed").removeAttr("src");
                $('#ImgMed').attr("hidden", "hidden");
                $("#modal_elegir").modal();
            });

            $("#btn_Escanear_confirm").click(() => {
                Call_Scan();
            });


            $("#btn_Subir_confirm").click(() => {

                var img_comp = $('#ImgMed').attr('src');
                if (img_comp == "" || img_comp == undefined) {

                } else {
                    PRUEBA_ORDER_MED();
                }

            });

            // ---------------------- FIN SCANNER UPLOAD ---------------



            $("#Btn_Scan_SF").click(() => {
                Call_Scan_SF();
            });

            $("#Btn_Asoc").click(() => {
                $("#Mdl_Asoc").modal("show");
                Llenar_IMG_ASOC();
            });

            $("#Close_Mdl_Asoc").click(() => {
                $("#Mdl_Asoc").modal("hide");
            });

            $("#Btn_Limpiar").click(() => {
                $("#Btn_Scan_SF").removeAttr("hidden");
                $("#Btn_Scan").attr("hidden", true);
                $("#Btn_Asoc").attr("hidden", true);
                id_atee = "";
                id_usu = "";
                ate_numm = "";
                $("#Ate_Folio").text("");
                $("#Ate_Nombre").text("");
                $("#Ate_Fecha").text("");
                $("#Ate_Rut").text("");
                $("#Ate_Proce").text("");
                $("#Ate_Preve").text("");
                $("#Grid_Img").empty();
                $("#txt_Folio").val("");
                $("#txt_Folio").focus();
            });

            $("#Btn_Asoc_Img").click(() => {
                if (ARR_IMG.length > 0) {

                    let Id_User;
                    if (id_usu == "") {
                        Id_User = 0;
                    } else {
                        Id_User = id_usu;
                    }

                    //Data_Par = JSON.stringify({
                    //    "ID_USUARIO": Id_User,
                    //    "ID_ATENCION": Mx_DataTable.ID_ATENCION,
                    //    "ATE_NUM": Mx_DataTable.ATE_NUM,
                    //    ARRAY_IMG: ARR_IMG
                    //});
                    Data_Par = JSON.stringify({
                        "ID_USUARIO": Id_User,
                        "ID_ATENCION": Mx_DataTable.ID_ATENCION,
                        "ATE_NUM": Mx_DataTable.ATE_NUM,
                        "ID_PREINGRESO": Mx_DataTable.ID_PREINGRESO,
                        "PREI_NUM": Mx_DataTable.PREI_NUM,
                        ARRAY_IMG: ARR_IMG
                    });

                    console.log(Data_Par)
                    AJAX_Grabar = $.ajax({
                        "type": "POST",
                        "url": "Ver_Orden.aspx/Graba_Asoc",
                        "data": Data_Par,
                        "contentType": "application/json;  charset=utf-8",
                        "dataType": "json",
                        "success": data => {
                            //Debug
                            console.log("Si: " + data);
                            $("#Mdl_Asoc").modal("hide");
                            Llenar_IMG();
                            Llenar_IMG_ASOC();
                            ARR_IMG = [];
                        },
                        "error": data => {
                            console.log(data);
                            //Debug
                        }
                    });
                } else {
                    console.log("ARR_IMG 0");
                }
            });

            //Creamos la instancia
            const valores = window.location.search;
            const urlParams = new URLSearchParams(valores);
            //Accedemos a los valores
            var atencion = urlParams.get('Ate');

            if (atencion != null && atencion > 0) {
                ate_numm = atencion;
                $("#txt_Folio").val(atencion);
                Llenar_DataTable();
                //Llenar_IMG();
            }

        });


        function imageIsLoaded(e) {
            imgSrc = e.target.result;
            console.log(e)
            if (e.target.result.split(",")[0] == "data:application/pdf;base64") {
                $('#ImgMed').attr('src', '../Utilidades/pdf2.png');
                $("#ImgMed").removeAttr("hidden");
                return
            }
            $('#ImgMed').attr('src', e.target.result);
            $("#ImgMed").removeAttr("hidden");
        };

        //ENVIA LA IMAGEN AL BACK CON EL TIPO DE ARCHIVO

        function PRUEBA_ORDER_MED() {
            modal_show();
            console.log(imgSrc);
            var img = imgSrc;
            var validador = img.split(",")
            var count = 0;
            var tp_order = ""
            console.log(validador[0]);
            switch (validador[0]) {

                case "data:text/plain;base64":
                    tp_order = "txt"
                    img = validador[1]
                    count = 0
                    break

                case "data:image/png;base64":
                    tp_order = "png";
                    img = validador[1];
                    count = 1;
                    break

                case "data:application/pdf;base64":
                    tp_order = "pdf";
                    img = validador[1];
                    count = 1;
                    break
                case "data:image/jpeg;base64":
                    tp_order = "jpeg";
                    img = validador[1];
                    count = 1;
                    break
            };

            if (count == 0) {
                Hide_Modal();
                $("#modal_elegir").modal("hide");
                $("#mError_AAH h4").text("Formato Incompatible");
                $("#mError_AAH button").attr("class", "btn btn-danger");
                $("#mError_AAH p").text("Estimado Usuario, el formato del documento no es compatible.");
                $("#mError_AAH").modal();
            } else {
                var datos = JSON.stringify({
                    "imgbase64": img,
                    "ID_ATENCION": Mx_DataTable.ID_ATENCION,
                    "ID_USUARIO": Galletas.getGalleta("ID_USER"),
                    "ATE_NUM": $("#txt_Folio").val(),
                    fileType: validador[0].split("/")[1].split(";")[0]

                });



                $.ajax({
                    "type": "POST",
                    "url": "Ver_Orden.aspx/prueba_order_med_PDF",
                    "contentType": "application/json;  charset=utf-8",
                    "data": datos,
                    "dataType": "json",
                    "success": function (response) {
                        var json = response.d;
                        $("#modal_segurin_upload").modal("hide");
                        $("#modal_elegir").modal("hide");

                        $("#file1").val("");
                        $("#ImgMed").removeAttr("src");
                        $('#ImgMed').attr("hidden", "hidden");

                        $("#mError_AAH h4").text("Documento");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("Estimado Usuario, el Documento se ha cargado satisfactoriamente");
                        $("#mError_AAH").modal();
                        Llenar_IMG();


                        console.log("paso por el success");
                        Hide_Modal();
                        imgSrc = ""
                    },
                    "error": function (response) {
                        imgSrc = "";
                        console.log("paso por el ERROR");
                        Hide_Modal();
                        console.log(response);
                        var str_Error = "Error interno del Servidor";
                        //cModal_Error("Error", str_Error);
                    }
                });

            }
        }

        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }

        function modal_show() {
            $(".modalcarga").show();
            $(".container-fluid, .navbar").addClass("blur");


        };

        function Hide_Modal() {
            $(".container-fluid, .navbar").removeClass("blur");
            $(".modalcarga").fadeOut(250);
        }

        function Llenar_DataTable() {
            modal_show();
            let Data_Par = JSON.stringify({
                "ATE_NUM": ate_numm
            });
            //Debug
            AJAX_Dtt = $.ajax({
                "type": "POST",
                "url": "Ver_Orden.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_DataTable = data.d;
                    Llenar_IMG();
                    $("#Btn_Scan").removeAttr("hidden");
                    $("#Btn_Asoc").removeAttr("hidden");
                    $("#Btn_Scan_SF").attr("hidden", true);

                    if (Mx_DataTable === null || Mx_DataTable.ATE_NUM === undefined) {
                        Hide_Modal();
                        $("#modal_elegir").modal("hide");
                        $("#mError_AAH h4").text("No existe N° de Atencion");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("Estimado Usuario, favor de ingresar otro N° de atencion");
                        $("#mError_AAH").modal();
                    } else {
                        $("#Btn_Scan").text("Escanear Folio: " + Mx_DataTable.ATE_NUM);
                    }

                    Fill_DataTable();
                },
                "error": data => {
                    //Debug
                    $("#Btn_Scan_SF").removeAttr("hidden");
                    $("#Btn_Scan").attr("hidden", true);
                    $("#Btn_Asoc").attr("hidden", true);
                    Hide_Modal();
                }
            });
        }

        function Fill_DataTable() {
            //Llenar_IMG();
            if (Mx_DataTable === null || Mx_DataTable.ATE_NUM === undefined) {
                Hide_Modal();
                $("#modal_elegir").modal("hide");
                $("#mError_AAH h4").text("No existe N° de Atencion");
                $("#mError_AAH button").attr("class", "btn btn-danger");
                $("#mError_AAH p").text("Estimado Usuario, favor de ingresar otro N° de atencion");
                $("#mError_AAH").modal();
            } else {

                $("#Ate_Folio").text(Mx_DataTable.ATE_NUM);
                $("#PREI_NUM").text(Mx_DataTable.PREI_NUM);
                $("#Ate_Nombre").text(Mx_DataTable.PAC_NOMBRE + " " + Mx_DataTable.PAC_APELLIDO);
                $("#Ate_Fecha").text(moment(Mx_DataTable.ATE_FECHA).format("DD-MM-YYYY"));
                $("#Ate_Rut").text(Mx_DataTable.PAC_RUT);
                $("#Ate_Proce").text(Mx_DataTable.PROC_DESC);
                $("#Ate_Preve").text(Mx_DataTable.PREVE_DESC);
            }

            /*$("#PREI_NUM").text(Mx_DataTable.PREI_NUM);*/
            //$("#Ate_Nombre").text(Mx_DataTable.PAC_NOMBRE + " " + Mx_DataTable.PAC_APELLIDO);
            //$("#Ate_Fecha").text(moment(Mx_DataTable.ATE_FECHA).format("DD-MM-YYYY"));
            //$("#Ate_Rut").text(Mx_DataTable.PAC_RUT);
            //$("#Ate_Proce").text(Mx_DataTable.PROC_DESC);
            //$("#Ate_Preve").text(Mx_DataTable.PREVE_DESC);
        }

        function Llenar_IMG() {
            $("#Grid_Img").empty();
            //console.log("llenar normal");
            let Data_Par = JSON.stringify({
                "PREI_NUM": Mx_DataTable?.PREI_NUM || -1,
                "ATE_NUM": $("#txt_Folio").val()
            });
            //Debug
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "Ver_Orden.aspx/Get_Img_PDF",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //console.log("Success SOlo");
                    Mx_IMG = data.d;
                    //Debug

                    if (Mx_IMG != null) {
                        Fill_IMG();
                    } else {
                        //console.log(data);
                        //Debug
                        Hide_Modal();
                    }

                },
                "error": data => {
                    console.log(data);
                    //Debug
                    Hide_Modal();
                }
            });

        }
        // function Llenar_IMG() {
        //    $("#Grid_Img").empty();
        //    //console.log("llenar normal");
        //    let Data_Par = JSON.stringify({
        //        "ID_ATENCION": Mx_DataTable.PREI_NUM
        //    });
        //    //Debug
        //    AJAX_Ddl = $.ajax({
        //        "type": "POST",
        //        "url": "Ver_Orden.aspx/Get_Img_PDF",
        //        "data": Data_Par,
        //        "contentType": "application/json;  charset=utf-8",
        //        "dataType": "json",
        //        "success": data => {
        //            //console.log("Success SOlo");
        //            Mx_IMG = data.d;
        //            //Debug
        //            if (Mx_IMG != null) {
        //                Fill_IMG();
        //            } else {
        //                //console.log(data);
        //                //Debug
        //                Hide_Modal();
        //            }
        //        },
        //        "error": data => {
        //            console.log(data);
        //            //Debug
        //            Hide_Modal();
        //        }
        //    });

        //}


        function Fill_IMG() {

            let count = 0;
            let count_div = 1;
            let D_Index = 0;
            let _D_Count = 1;
            $("#Grid_Img").append(
                $("<div id='div_Img_" + count_div + "' class='row mt-2 pl-4' style='max-width:calc(100% - 20px) !important'></div>")
            );
            Mx_IMG.forEach((imgx) => {
                if (imgx.IMG.length > 300) {
                    count += 1;
                    let _Plat;
                    if (imgx.FOTO_ATE_PLATAFORMA == 2) {
                        _Plat = "(PC)";
                    } else {
                        _Plat = "(APP)";

                    }
                    if (imgx.USU_NIC != null) {
                        Nombre_Doc = imgx.USU_NIC + " " + _Plat + " </br> " + moment(imgx.FECHA_ASOC).format("DD/MM/YYYY HH:mm:ss");
                    } else {
                        Nombre_Doc = "Web" + " " + _Plat + " </br> " + moment(imgx.FECHA_ASOC).format("DD/MM/YYYY HH:mm:ss");
                        _D_Count += 1;
                    }

                    $("#div_Img_" + count_div).append(
                        imgx.TIPO == "pdf" ?
                            "<div class='col gallery-docs'><img src='../Utilidades/pdf2.png' class='mt-2' style='max-height:200px; max-width:150px' name='show_img' data-index='" + D_Index + "'/></img><div class='row'><div class='col-lg text-center' style='height:56px'><label>" + Nombre_Doc + "</label></div</div></div>" :
                            "<div class='col gallery-docs'><img src='data:image/jpeg;base64," + imgx.IMG + "' class='mt-2' style='max-height:200px; max-width:150px' name='show_img' data-index='" + D_Index + "'/><div class='row'><div class='col-lg text-center' style='height:56px'><label>" + Nombre_Doc + "</label></div</div></div>"
                    );
                    if (count == 5) {
                        count = 0;
                        count_div += 1;
                        $("#Grid_Img").append(
                            $("<div id='div_Img_" + count_div + "' class='row pl-4' style='max-width:calc(100% - 20px) !important'></div>")
                        );
                    }
                }
                D_Index += 1;
                if (Mx_IMG.length == D_Index) {
                    let restt = 5 - count;
                    for (xx = 1; xx <= restt; xx++) {
                        $("#div_Img_" + count_div).append(
                            ("<div class='col-lg'></div>")
                        );
                    }
                }
            });
            $("img[name='show_img']").click(function () {
                let ii = $(this).attr("data-index");
                Show_Image(ii)
            });

            Hide_Modal();
        }

        function Show_Image(i) {
            let img = parseInt(i) + 1;
            let Nombre_Doc_S;

            let _Plat;
            if (Mx_IMG[i].FOTO_ATE_PLATAFORMA == 2) {
                _Plat = "(PC)";
            } else {
                _Plat = "(APP)";
            }

            if (Mx_IMG[i].USU_NIC != null) {
                Nombre_Doc_S = Mx_IMG[i].USU_NIC + " - " + moment(Mx_IMG[i].FECHA_ASOC).format("DD/MM/YYYY HH:mm:ss") + " " + _Plat;
            } else {
                Nombre_Doc_S = "Web - " + moment(Mx_IMG[i].FECHA_ASOC).format("DD/MM/YYYY HH:mm:ss") + " " + _Plat;
            }


            $("#mod_Name").text(Nombre_Doc_S);
            if (Mx_IMG[i].TIPO == "pdf") {
                $("#Mdl_Image_Ate img").attr("src", "").hide();
                $("#iframeModalPDF").attr("src", "data:application/pdf;base64," + Mx_IMG[i].IMG).show();
            } else {
                $("#iframeModalPDF").attr("src", "").hide();
                $("#Mdl_Image_Ate img").attr("src", "data:image/jpeg;base64," + Mx_IMG[i].IMG).show();
            }
            $("#Mdl_Image_Ate .modal-footer").html("<button type='button' class='btn btn-warning' onClick='Desasoc(" + Mx_IMG[i].ID_FOTO_ATE + ");'>Desvincular</button><button type='button' class='btn btn-danger' data-dismiss='modal'>Cerrar</button>");
            $("#Mdl_Image_Ate").modal();
        }

        function Eliminar(ID_FOTO_ATE) {
            Data_Par = JSON.stringify({
                "ID_FOTO_ATE": ID_FOTO_ATE
            });
            AJAX_Grabar = $.ajax({
                "type": "POST",
                "url": "Ver_Orden.aspx/Elimina_Img",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    console.log("Si: " + data);
                    Llenar_IMG();
                    Llenar_IMG_ASOC();
                    ARR_IMG = [];
                    $("#Mdl_Image_Ate").modal("hide");
                },
                "error": data => {
                    console.log(data);
                    //Debug
                }
            });
        }

        function Desasoc(ID_FOTO_ATE) {
            Data_Par = JSON.stringify({
                "ID_FOTO_ATE": ID_FOTO_ATE
            });
            AJAX_Grabar = $.ajax({
                "type": "POST",
                "url": "Ver_Orden.aspx/Elimina_Asoc",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    console.log("Si: " + data);
                    $("#Mdl_Image_Ate").modal("hide");
                    Llenar_IMG();
                    Llenar_IMG_Asoc();
                    ARR_IMG = [];
                },
                "error": data => {
                    console.log(data);
                    //Debug
                }
            });
        }

        function Ch_Name(i) {
            let NOMBRE_DOC = $("#Re_Name").val();
            NOMBRE_DOC = NOMBRE_DOC.toUpperCase();

            let Data_Par = JSON.stringify({
                "ID": Mx_IMG[i].ID,
                "NOMBRE_DOC": NOMBRE_DOC,
            });

            //Debug
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "Ver_Scan.aspx/ReName",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Llenar_IMG();
                    $("#mod_Name").text(NOMBRE_DOC);
                    $("#lbl_Rename").css("color", "green").text("Documento Renombrado");
                },
                "error": data => {
                    $("#lbl_Rename").css("color", "red").text("No se pudo Renombrar");
                    //Debug
                }
            });
        }

        //function Call_Scan() {

        //    if (id_usu == "") {
        //        id_usu = 0;
        //    }

        //    Data_Par = JSON.stringify({
        //        "ID_USUARIO": id_usu,
        //        "ID_ATENCION": Mx_DataTable.ID_ATENCION,
        //        "ATE_NUM": Mx_DataTable.ATE_NUM
        //    });
        //    $.ajax({
        //        "type": "POST",
        //        "url": "http://localhost:9990/SCAN/SCAN_ASOC",
        //        "data": Data_Par,
        //        "contentType": "application/json;  charset=utf-8",
        //        "dataType": "json",
        //        "timeout": 50000,
        //        "success": data => {
        //            //Debug
        //            console.log("Si: " + data);
        //            $("#modal_elegir").modal("hide");
        //            Llenar_IMG();
        //            ARR_IMG = [];
        //        },
        //        "error": data => {
        //            console.log("No: " + data);
        //            $("#modal_elegir").modal("hide");
        //            //Debug
        //        }
        //    });
        //}

        function Call_Scan() {

            if (id_usu == "") {
                id_usu = 0;
            }

            Data_Par = JSON.stringify({
                "ID_USUARIO": id_usu,
                "ID_ATENCION": Mx_DataTable.ID_ATENCION,
                "ATE_NUM": Mx_DataTable.ATE_NUM,
                "ID_PREINGRESO": Mx_DataTable.ID_PREINGRESO,
                "PREI_NUM": Mx_DataTable.PREI_NUM,
            });
            $.ajax({
                "type": "POST",
                "url": "http://localhost:9990/SCAN/SCAN_ASOC_PREI",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "timeout": 50000,
                "success": data => {
                    //Debug
                    console.log("Si: " + data);
                    $("#modal_elegir").modal("hide");
                    Llenar_IMG();
                    ARR_IMG = [];
                },
                "error": data => {
                    console.log("No: " + data);
                    $("#modal_elegir").modal("hide");
                    //Debug
                }
            });
        }

        function Call_Scan_SF() {
            if (id_usu == "") {
                id_usu = 0;
            }
            Data_Par = JSON.stringify({
                "ID_USUARIO": id_usu
            });
            $.ajax({
                "type": "POST",
                "url": "http://localhost:9990/SCAN/SCAN",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "timeout": 50000,
                "success": data => {
                    //Debug
                    console.log("Si: " + data);
                    Llenar_IMG();
                    ARR_IMG = [];
                },
                "error": data => {
                    console.log("No: " + data);
                    //Debug
                }
            });
        }

        function Llenar_IMG_ASOC() {
            $("#Grid_Img_2").empty();
            let Data_Par = JSON.stringify({
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val()
            });
            //Debug
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "Ver_Orden.aspx/Get_Img_Asoc_PDF",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_IMG_Asoc = data.d;

                    if (Mx_IMG_Asoc != null) {
                        console.log(Mx_IMG_Asoc);
                        Fill_IMG_Asoc();
                    } else {
                        console.log("Sin Resultados");
                    }
                },
                "error": data => {
                    console.log(data);
                    //Debug
                }
            });
        }

        function Fill_IMG_Asoc() {
            //modal_show();
            if (Mx_IMG_Asoc != null) {

                let count = 0;
                let count_div = 1;
                let D_Index = 0;

                $("#Grid_Img_2").append(
                    $("<div id='div_Img_Asoc_" + count_div + "' class='row mt-2' style='max-width:calc(100% - 15px)' ></div>")
                );
                Mx_IMG_Asoc.forEach((imgx) => {
                    console.log(imgx);
                    if (imgx.IMG.length > 300) {
                        count += 1;
                        $("#div_Img_Asoc_" + count_div).append(
                            ("<div class='col-lg'><img src=" + (imgx.TIPO == "pdf" ? "'../Utilidades/pdf2.png'" : "'data:image/jpeg;base64," + imgx.IMG) + "' class='mt-2' style='max-height:180px; width:auto' name='show_img_2' data-index='" + D_Index + "'/><div class='row text-center'><div class='col-lg'><label>Seleccionar<input type='checkbox' name='chk' value='" + D_Index + "' class='ml-2'/></label></div></div></div>")
                        );

                        if (count == 6) {
                            count = 0;
                            count_div += 1;
                            $("#Grid_Img_2").append(
                                $("<div id='div_Img_Asoc_" + count_div + "' class='row' style='max-width:calc(100% - 15px)'></div>")
                            );
                        }
                    }
                    D_Index += 1;
                    if (Mx_IMG_Asoc.length == D_Index) {
                        let restt = 6 - count;
                        for (xx = 1; xx <= restt; xx++) {
                            $("#div_Img_Asoc_" + count_div).append(
                                ("<div class='col-lg'></div>")
                            );
                        }
                    }
                });
                $("img[name='show_img_2']").click(function () {
                    let ii = $(this).attr("data-index");
                    Show_Image_Asoc(ii);
                });
                $("input[name=chk]").click((aah) => {
                    let Img_Index;
                    Img_Index = $(aah.currentTarget).val();

                    let chk_Img = $(aah.currentTarget).prop("checked");

                    if (chk_Img == true) {
                        ARR_IMG.push(Mx_IMG_Asoc[Img_Index].ID_FOTO_ATE);
                    }
                    else {
                        let poss = ARR_IMG.indexOf(Mx_IMG_Asoc[Img_Index].ID_FOTO_ATE);
                        ARR_IMG.splice(poss, 1);
                    }
                });
            }
        }

        function Show_Image_Asoc(i) {
            let img = parseInt(i) + 1;
            let _Plat;
            if (Mx_IMG_Asoc[i].FOTO_ATE_PLATAFORMA == 2) {
                _Plat = "(PC)";
            } else {
                _Plat = "(APP)";
            }
            $("#Mdl_Image_Ate h3").text(() => {
                if (Mx_IMG_Asoc[i].USU_NIC != null) {
                    return Mx_IMG_Asoc[i].USU_NIC + " - " + moment(Mx_IMG_Asoc[i].FECHA_LOG).format("DD/MM/YYYY HH:mm:ss") + " " + _Plat;
                } else {
                    return "Web - " + moment(Mx_IMG_Asoc[i].FECHA_LOG).format("DD/MM/YYYY HH:mm:ss") + " " + _Plat;
                }
            });


            if (Mx_IMG_Asoc[i].TIPO == "pdf") {
                $("#Mdl_Image_Ate img").attr("src", "").hide();
                $("#iframeModalPDF").attr("src", "data:application/pdf;base64," + Mx_IMG_Asoc[i].IMG).show();
            } else {
                $("#iframeModalPDF").attr("src", "").hide();
                $("#Mdl_Image_Ate img").attr("src", "data:image/jpeg;base64," + Mx_IMG_Asoc[i].IMG).show();
            }

            $("#Mdl_Image_Ate .modal-footer").html("<button type='button' class='btn btn-warning' onClick='Eliminar(" + Mx_IMG_Asoc[i].ID_FOTO_ATE + ");'>Eliminar</button><button type='button' class='btn btn-danger' data-dismiss='modal'>Cerrar</button>");
            $("#Mdl_Image_Ate").modal();
        }
    </script>
    <style>
        .gallery-docs {
            padding: 7px;
            background-color: white;
            border: 1px #a7a7a7 solid !important;
            border-radius: 2px;
            margin: 10px 5px 10px 5px;
        }

        .f-h5 {
            font-size: 1.2rem;
        }

        .modal-dialog {
            margin: 10px auto !important;
        }
    </style>

    <!-- Modal ERROR -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>


    <!-- Modal pregunta escaneo/subir -->
    <div id="modal_elegir" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Escanear/Subir</h4>
                </div>
                <div class="modal-body">
                    <p>¿Estimado Usuario, desea escanear o Subir un Documento?</p>
                    <div class="col-lg-6">
                        <input type="file" name="file1" id="file1" class="inputfile" />
                        <label for="file1" class="btn btn-primary btn-lg" style="background-color: transparent; color: green; border: transparent; cursor: pointer">
                            <i class="fa fa-paperclip fa-2x" aria-hidden="true"></i>
                        </label>
                        <%--<button type="button" id="btn_PRUEBA_ORDER_MED" class="btn btn-success btn-block btn-sm"><i class="fa fa-search-plus fa-fw"></i>Prueba Orden Médica</button>--%>
                    </div>

                    <div class="col-lg-12 text-center">
                        <img src="#" id="ImgMed" style="max-width: 25%; border: 1px #009639 solid; padding: 1rem" hidden />
                        <%--<iframe id="iframeModalUploadPDF" src="" style="width: 100%; height:80vh " ></iframe>--%>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btn_Escanear_confirm" class="btn btn-success"><i class="fa fa-upload fa-fw"></i>Escanear</button>
                    <button type="button" id="btn_Subir_confirm" class="btn btn-success"><i class="fa fa-upload fa-fw"></i>Subir</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-remove mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <!------ modal de carga -------->
    <div class="modal modalcarga">
        <div>
            <h2><b>Cargando...</b></h2>
            <div class="flex-content">
                <div class="box2">
                    <div style="display: inline-block">
                        <img class="imght" src="/Imagenes/ILWS.png" />
                    </div>
                </div>
                <div class="box1">
                    <img class="img360" src="/Imagenes/IRISSSS.png" />
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="card border-bar mb-3 mt-3">
            <div class="card-header text-center bg-bar">
                <h5 class="m-0"><i class="fa fa-user fa-fw"></i>Datos de Atención</h5>
            </div>
            <div class="card-body">
                <div class="row mb-2">
                    <div class="col-lg-3 mb-2">
                        <div class="row">
                            <div class="col pr-0">
                                Folio:
                            </div>
                            <i class="fa fa-arrow-left d-inline btn btn-sm btn-primary" id="btn_Left"></i>
                            <div class="col-6 p-0">
                                <input type="text" id="txt_Folio" class="form-control form-control-sm text-danger font-weight-bold pt-0 pb-0" style="font-size: 1.2rem" />
                            </div>
                            <i class="fa fa-arrow-right d-inline btn btn-sm btn-primary" id="btn_Right"></i>
                        </div>
                    </div>
                    <div class="col-lg mb-2">
                        <button type="button" id="Btn_Buscar" class="btn btn-buscar btn-sm btn-block mt-0">Buscar</button>
                    </div>
                    <div class="col-lg mb-2">
                        <button type="button" id="Btn_Limpiar" class="btn btn-limpiar btn-sm btn-block mt-0">Limpiar</button>
                    </div>
                    <div class="col-lg mb-2">
                        <button type="button" id="Btn_Scan" hidden class="btn btn-primary btn-lg btn-block m-0 font-weight-bold">Escanear</button>
                        <button type="button" id="Btn_Scan_SF" hidden class="btn btn-warning btn-lg btn-block m-0 font-weight-bold">Escanear Sin Folio</button>
                    </div>
                    <div class="col-lg mb-2">
                        <button type="button" id="Btn_Asoc" hidden class="btn btn-print btn-lg btn-block font-weight-bold mt-0">Vincular</button>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg f-h5">Fecha: <span id="Ate_Fecha"></span></div>
                    <div class="col-lg-4 f-h5"></div>
                </div>
                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg f-h5">N Atencion: <span id="Ate_Folio"></span></div>
                    <div class="col-lg-4 f-h5">N Agendamiento: <span id="PREI_NUM"></span></div>
                </div>
                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg f-h5">Nombre: <span id="Ate_Nombre"></span></div>
                    <div class="col-lg-4 f-h5">RUT: <span id="Ate_Rut"></span></div>
                </div>
                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg f-h5">Procedencia: <span id="Ate_Proce"></span></div>
                    <div class="col-lg-4 f-h5">Previsión: <span id="Ate_Preve"></span></div>
                </div>
            </div>
        </div>

        

<%--        <!--Aquí el video embebido de la webcam -->
        <div class="video-wrap">
            <video id="video" playsinline autoplay></video>
        </div>
        <!--El elemento canvas -->
        <div class="controller">
            <button id="snap">Capture</button>
            <button id="Plyy">Play</button>
            <button id="Stpp">Stop</button>
        </div>
        <!--Botón de captura -->
        <canvas id="canvas" width="680" height="880"></canvas>

        <script>
         
            

            'use strict';

            const video = document.getElementById('video');
            const snap = document.getElementById("snap");
            const stopo = document.getElementById("Stpp");
            const playo = document.getElementById("Plyy");
            
            const canvas = document.getElementById('canvas');
            const errorMsgElement = document.querySelector('span#errorMsg');
            var stream ;
            const constraints = {
                audio: false,
                video: {
                    width: 4000, height: 8000
                }
            };

            // Acceso a la webcam
             async function init() {
                 try {
                     
                     
                    stream = await navigator.mediaDevices.getUserMedia(constraints);
                    handleSuccess(stream);
                    console.log("TRY SI");
                 } catch (e) {
                    
                     console.log(`navigator.getUserMedia error:${e.toString()}`);
                     console.log("TRY NO");
                }
            }
            // Correcto!
             function handleSuccess(stream) {
                 console.log("handleSuccess");
                //window.stream = stream;
                video.srcObject = stream;
            }
            // Load init
            //init();
            // Dibuja la imagen
            var context = canvas.getContext('2d');
            snap.addEventListener("click", function() {
                context.drawImage(video, 0, 0, 800, 600,0,0,1080,880);
            });
            stopo.addEventListener("click", function() {
                video.pause();
                video.src = 
                video.srcObject = null;
                //stream.getTracks()[0].stop();
            });
            playo.addEventListener("click", function() {
                init();
            });
        </script>--%>


        <div class="card border-bar mb-3">
            <div class="card-header text-center bg-bar">
                <h5 class="m-0"><i class="fa fa-picture-o fa-fw"></i>Galería de Documentos</h5>
            </div>
            <div class="card-body p-0" style="background-color: #f5f5f5">
                <div id="Grid_Img" class="text-center" style="max-height: 610px; overflow: auto;"></div>
            </div>
        </div>
    </div>

    <div id="Mdl_Image_Ate" class="modal fade text-center p-0" role="dialog" style="z-index: 9999">
        <div class="modal-dialog" style="min-width: 55vw">
            <!-- Modal content-->
            <div class="modal-content border-bar">
                <div class="modal-header text-center bg-bar p-1">
                    <h3 class="modal-title w-100" id="mod_Name"></h3>
                </div>
                <div  class="modal-body text-center">
                    <img src="" style="max-width: 50vw" />
                    <iframe id="iframeModalPDF" src="" style="width:100%;height:80vh;display:none;"></iframe>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>

    <div id="Mdl_Asoc" class="modal fade text-center p-0" role="dialog">
        <div class="modal-dialog" style="min-width: 75vw">
            <!-- Modal content-->
            <div class="modal-content border-bar">
                <div class="modal-header text-center p-1 bg-bar">
                    <h3 class="modal-title w-100">Vincular Imágen</h3>
                </div>
                <div class="modal-body text-center">
                    <div class="row">
                        <div class="col-lg">
                            <div class='input-group date' id='Txt_Date01'>
                                <label for="fecha" class="pr-3">Desde:</label>
                                <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Desde..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg">
                            <div class='input-group date' id='Txt_Date02'>
                                <label for="fecha2" class="pr-3">Hasta:</label>
                                <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Hasta..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <button type="button" id="Btn_Buscar_Asoc" class="btn btn-buscar btn-block">Buscar</button>
                        </div>
                        <div class="col-lg-2">
                            <button type="button" id="Btn_Asoc_Img" class="btn btn-print btn-block">Vincular</button>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg" id="Grid_Img_2"></div>
                    </div>
                </div>
                <div class="modal-footer text-right">
                    <button type="button" id="Close_Mdl_Asoc" class="btn btn-danger">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
