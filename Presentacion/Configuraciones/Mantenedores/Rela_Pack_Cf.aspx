<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Rela_Pack_Cf.aspx.vb" Inherits="Presentacion.Rela_Pack_Cf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>
        $(document).ready(function () {
            Ajax_Tabla_PACK()
            Ajax_Pack();
            Ajax_Ddl_Mantenedor();
            //BTN MODAL CREAR PACK
            $("#btn_modal_PACK").click(function () {
                $('#eModal3').modal('hide');
                $('#eModal3').modal('show');
                console.log("si funco");
                /*Ajax_Tabla_indicaciones()*/
                /*Ajax_Indicaciones_Relacionadas()*/
            });
            //BTN SALIR MODAL CREAR PACK
            $("#btnSalirModal2").click(function () {
                $('#eModal3').modal('hide')
                Ajax_Pack();
                $("#Div_Tabla_Seccion_Rel").empty();
                $("#DataTable_pack_id").empty();
                $("#Div_Tabla_Seccion_NO_Relacionadas").empty();
                $("#DataTable_pack").empty();
            });
            //BTN LIMPIAR
            $("#Btn_Limpiar").click(function () {
                Ajax_Limpiar();
                accion = 1
                /* alerta_Proc_Correctos();*/
                despintarCasillas();
                $("#Btn_Guardar").attr("disabled", false);
                $("#Btn_Modificar").attr("disabled", true);
                $("#Btn_Eliminar").attr("disabled", true);
            });

            //BTN MODIFICAR
            $("#Btn_Modificar").click(function () {
                if (IDDDDDDD == 0) {

                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione un valor en la tabla.");
                    $("#mError_AAH").modal();
                } else {
                    if (validar() === 3) {
                        Ajax_Update();
                        accion = 3
                        /*alerta_Proc_Correctos();*/
                        despintarCasillas();
                        Ajax_Pack();
                    }
                }
            });
            //BTN ELIMINAR
            $("#Btn_Eliminar").click(function () {
                if (IDDDDDDD == 0) {

                    //$("#mError_AAH h4").text("Error");
                    //$("#mError_AAH button").attr("class", "btn btn-danger");
                    //$("#mError_AAH p").text("Por favor, complete los campos solicitados.");
                    //$("#mError_AAH").modal();

                    Swal.fire({
                        title: "Aviso",
                        text: "Por favor, complete los campos solicitados.",
                        icon: "warning"
                    });

                } else {

                    Ajax_Delete();
                    accion = 4
                    /*alerta_Proc_Correctos();*/
                    despintarCasillas();
                    $("#Btn_Modificar").attr("disabled", true);
                    $("#Btn_Eliminar").attr("disabled", true);
                    Ajax_Pack();

                }
            });
            //BTN GUARDAR
            $("#Btn_Guardar").click(function () {
                if (validar() === 3) {
                    Ajax_Guardar();
                    accion = 2
                    /*alerta_Proc_Correctos();*/
                    despintarCasillas();
                    $("#Btn_Guardar").attr("disabled", true);
                    $("#Btn_Modificar").attr("disabled", true);
                    $("#Btn_Eliminar").attr("disabled", true);
                    Ajax_Pack();

                } else {
                    Swal.fire({
                        title: "Aviso",
                        text: "Por favor, complete los campos solicitados.",
                        icon: "warning"
                    });

                }
            });

            $("#Btn_Guardar").attr("disabled", false);
            $("#Btn_Modificar").attr("disabled", true);
            $("#Btn_Eliminar").attr("disabled", true);

            $("#btn_Agregar").click(function () {
                let lista_Secciones = Mx_Dtt_cf_No_Relacionadas.filter(item => item.CHECK == 1).map(item => item.ID_CODIGO_FONASA)
                console.log(lista_Secciones)

                Ajax_Agregar_Rel();

            });
            $("#btn_Quitar").click(function () {

                let lista_comunas2 = Mx_Dtt_cf_Relacionada.filter(item => item.CHECK == 1).map(item => item.IRIS_REL_PACK_CF)
                console.log(lista_comunas2)

                Ajax_Quitar_Rel();
            });

            $("#slt_Pack").change(function () {
                
                if ($("#slt_Pack").val() == 0) {
                    Hide_Modal();
                    
                    //$("#mError_AAH h4").text("Sin resultados");
                    //$("#mError_AAH button").attr("class", "btn btn-danger");
                    //$("#mError_AAH p").text("Seleccionar una Area porfavor");
                    //$("#mError_AAH").modal();

                    Swal.fire({
                        title: "Aviso",
                        text: "Seleccionar una Area porfavor",
                        icon: "warning"
                    });

                    $('#Div_Tabla_Seccion_NO_Relacionadas').hide();
                    $('#Div_Tabla_Seccion_Rel').hide();
                    $('#btn_Agregar').hide();
                    $('#btn_Quitar').hide();

                } else {

                    Hide_Modal();
                    IDDDD_PACK = $("#slt_Pack").val()
                    console.log(IDDDD_PACK);
                    Ajax_cf_No_Relacionadas();
                    Ajax_cf_Relacionada();
                    $('#Div_Tabla_Seccion_NO_Relacionadas').show();
                    $('#Div_Tabla_Seccion_Rel').show();
                    $('#btn_Agregar').show();
                    $('#btn_Quitar').show();
                    $("#Div_Tabla_Seccion_Rel").empty();
                    $("#DataTable_pack_id").empty();
                    $("#Div_Tabla_Seccion_NO_Relacionadas").empty();
                    $("#DataTable_pack").empty();
                    
                }


              
            });
        });
    </script>

    <%--------------------------------------------------------- BOTON AGREGAR ---------------------------------------------%>
    <script>
        function Ajax_Agregar_Rel() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_PACK": IDDDD_PACK,
                "ARRAY_COD_FONASA": Mx_Dtt_cf_No_Relacionadas.filter(item => item.CHECK == 1).map(item => item.ID_CODIGO_FONASA)

            });
            console.log(Data_Par)
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rela_Pack_Cf.aspx/IRIS_WEBF_GRABA_RELACION_PACK_CF",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();

                        Ajax_cf_Relacionada();
                        Ajax_cf_No_Relacionadas();
                    } else {

                        Hide_Modal();
                        //$("#mError_AAH h4").text("Sin resultados");
                        //$("#mError_AAH button").attr("class", "btn btn-danger");
                        //$("#mError_AAH p").text("No se han encontrado resultados");
                        //$("#mError_AAH").modal();
                        Swal.fire({
                            title: "Sin resultados",
                            text: "No se han encontrado resultados.",
                            icon: "warning"
                        });

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
    <%--------------------------------------------------------- BOTON QUITAR ----------------------------------------------%>
    <script>
        function Ajax_Quitar_Rel() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ARRAY_COD_FONASA": Mx_Dtt_cf_Relacionada.filter(item => item.CHECK == 1).map(item => item.IRIS_REL_PACK_CF)

            });
            console.log(Data_Par)
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rela_Pack_Cf.aspx/IRIS_WEBF_UPDATE_REL_PACK_CF_QUITAR_RELACION",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();


                        Ajax_cf_Relacionada();
                        Ajax_cf_No_Relacionadas();
                    } else {

                        Hide_Modal();
                        //$("#mError_AAH h4").text("Sin resultados");
                        //$("#mError_AAH button").attr("class", "btn btn-danger");
                        //$("#mError_AAH p").text("No se han encontrado resultados");
                        //$("#mError_AAH").modal();
                        Swal.fire({
                            title: "Sin resultados",
                            text: "No se han encontrado resultados.",
                            icon: "warning"
                        });
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
    <%---------------------------------------------------------------------------- AJAX DE PACK ---------------------------%>
    <script>
        var Mx_Dtt_Pack = [{
            "ID_PACK": 0,
            "PACK_COD": 0,
            "PACK_DESC": 0,
            "ID_ESTADO": 0,
        }];

        function Ajax_Pack() {
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rela_Pack_Cf.aspx/LLENAR_DDL_PACK",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Pack = json_receiver;
                        Fill_Ddl_Pack();
                    } else {
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    //$("#mdlNotif .modal-header h4").text("Algo no ocurrio como esperabamos");
                    //$("#mdlNotif .modal-body p").html("Intente nuevamente mas tarde.");
                    //$("#mdlNotif").modal();

                    Swal.fire({
                        title: "Algo no ocurrio como esperabamo",
                        text: "Intente nuevamente.",
                        icon: "warning"
                    });
                }
            });
        }
        /* --------------------------- FUNCION PARA RELLENAR EL SELECT -------------------------------*/
        function Fill_Ddl_Pack() {
            $("#slt_Pack").empty();
            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#slt_Pack");
            for (y = 0; y < Mx_Dtt_Pack.length; ++y) {

                $("<option>", {
                    "value": Mx_Dtt_Pack[y].ID_PACK
                }).text(Mx_Dtt_Pack[y].PACK_DESC).appendTo("#slt_Pack");
            }
        };
    </script>
    <%------------------------------------------- NO RELACIONADAS PACK-CF -------------------------------------------------%>
    <script>
        var Mx_Dtt_cf_No_Relacionadas = [
            {
                "ID_CODIGO_FONASA": 0,
                "CF_COD": 0,
                "CF_DESC": 0,
                "ID_ESTADO": 0,
                "CHECK": 0
            }
        ];
        function Ajax_cf_No_Relacionadas() {
            var Data_Par = JSON.stringify({
                "ID_PACK": IDDDD_PACK

            });
            console.log(Data_Par);
            $.ajax({
                "type": "POST",
                "url": "Rela_Pack_Cf.aspx/IRIS_WEBF_BUSCA_RELACION_PACK_CF_NO_CARGADAS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt_cf_No_Relacionadas = (json_receiver);

                        $("#Div_Tabla_Seccion_NO_Relacionadas").empty();
                        $("#DataTable_pack").empty();


                        Fill_DataTable_cf();
                        Hide_Modal();
                    } else {

                        Hide_Modal();
                        //$("#mError_AAH h4").text("Sin resultados");
                        //$("#mError_AAH button").attr("class", "btn btn-danger");
                        //$("#mError_AAH p").text("No se han encontrado resultados");
                        //$("#mError_AAH").modal();
                        Swal.fire({
                            title: "Sin resultados",
                            text: "No se han encontrado resultados.",
                            icon: "warning"
                        });

                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        //------------------------------------------------------------------ TABLA COMUNA NO RELACIONADAS -------------------------------------------|
        function Fill_DataTable_cf() {
            $("<table>", {
                "id": "DataTable_pack",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Seccion_NO_Relacionadas");
            $("#DataTable_pack").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_pack").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_pack thead").attr("class", "cabezera");
            $("#DataTable_pack thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido" }).text("Agregar")

                )
            );
            for (i = 0; i < Mx_Dtt_cf_No_Relacionadas.length; i++) {
                $("#DataTable_pack tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Codiguin_No_Relacionadas("` + Mx_Dtt_cf_No_Relacionadas[i].ID_CODIGO_FONASA + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_cf_No_Relacionadas[i].CF_DESC),
                        $("<td>").css("text-align", "left",).html("<input type='checkbox'  id='No_relacionado" + Mx_Dtt_cf_No_Relacionadas[i].ID_CODIGO_FONASA + "' />"),
                    )
                );
            }
            $("#DataTable_pack tbody tr").click(function () {
                $("#DataTable_pack tbody tr").removeClass("active");
                $(this).addClass("active");
            });
            $("#DataTable_pack tbody tr td input").click(function (e) {
                let id_check = $(e.currentTarget).attr('id');
                console.log(id_check)


                let aux = Mx_Dtt_cf_No_Relacionadas.find(item => item.ID_CODIGO_FONASA == id_check.split('No_relacionado')[1]);
                console.log(aux)
                aux.CHECK = $('#' + id_check).is(':checked') ? 1 : 0;
            });
            $('#DataTable_pack').DataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
                "retrieve": true,
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong></i>Filtro: </strong>"
                }
            });
        }
    </script>
    <%------------------------------------------ TABLAS RELACIONADAS PACK - CF --------------------------------------------%>
    <script>
        var Mx_Dtt_cf_Relacionada = [
            {

                "ID_CODIGO_FONASA": 0,
                "CF_COD": 0,
                "CF_DESC": 0,
                "ID_ESTADO": 0,
                "CHECK": 0,
                "IRIS_REL_PACK_CF": 0

            }
        ];
        function Ajax_cf_Relacionada() {
            var Data_Par = JSON.stringify({
                "ID_PACK": IDDDD_PACK

            });
            console.log(Data_Par)
            $.ajax({
                "type": "POST",
                "url": "Rela_Pack_Cf.aspx/IRIS_WEBF_CMVM_BUSCA_RELACION_PACK_CF_MANTENEDOR_REL",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt_cf_Relacionada = (json_receiver);
                        Mx_Dtt_cf_Relacionada = Mx_Dtt_cf_Relacionada.map(item => {
                            item.CHECK = 0;
                            return item;
                        });
                        $("#Div_Tabla_Seccion_Rel").empty();
                        $("#DataTable_pack_id").empty();


                        Fill_DataTable_cf_Relacionada();
                        Hide_Modal();
                    } else {

                        Hide_Modal();
                        //$("#mError_AAH h4").text("Sin resultados");
                        //$("#mError_AAH button").attr("class", "btn btn-danger");
                        //$("#mError_AAH p").text("No se han encontrado resultados");
                        //$("#mError_AAH").modal();
                        Swal.fire({
                            title: "Sin resultados",
                            text: "No se han encontrado resultados.",
                            icon: "warning"
                        });

                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                }
            });
        }
        /*----------------------------------------------------------- TABLA DE LAS COMUNAS REALACIONADAS -----------------------------*/
        function Fill_DataTable_cf_Relacionada() {
            $("<table>", {
                "id": "DataTable_pack_id",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Seccion_Rel");
            $("#DataTable_pack_id").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_pack_id").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_pack_id thead").attr("class", "cabezera");
            $("#DataTable_pack_id thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido" }).text("Quitar")

                )
            );
            for (i = 0; i < Mx_Dtt_cf_Relacionada.length; i++) {
                $("#DataTable_pack_id tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Codiguin_Tabla_Relacionada("` + Mx_Dtt_cf_Relacionada[i].IRIS_REL_PACK_CF + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_cf_Relacionada[i].CF_DESC),
                        $("<td>").css("text-align", "left",).html("<input type='checkbox'  id='relacionado" + Mx_Dtt_cf_Relacionada[i].IRIS_REL_PACK_CF + "' />"),
                    )
                );
            }
            $("#DataTable_pack_id tbody tr").click(function () {
                $("#DataTable_pack_id tbody tr").removeClass("active");
                $(this).addClass("active");
            });
            $("#DataTable_pack_id tbody tr td input").click(function (e) {
                let id_check = $(e.currentTarget).attr('id');
                console.log(id_check)

                let aux = Mx_Dtt_cf_Relacionada.find(item => "" + item.IRIS_REL_PACK_CF == id_check.split('relacionado')[1]);
                console.log(aux)
                aux.CHECK = $('#' + id_check).is(':checked') ? 1 : 0;
            });
            $('#DataTable_pack_id').DataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
                "retrieve": true,
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong></i>Filtro: </strong>"
                }
            });
        }
    </script>
 
    <%--------------------------------- PARTE DEL MODAL -------------------------------------------------------------------%>
    <script>
        var Mx_Dtt_Mantenedor = [
            {
                "ID_ESTADO": 0,
                "EST_DESCRIPCION": 0,
                "EST_MANTENEDOR": 0
            }
        ];
        function Ajax_Ddl_Mantenedor() {
            modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rela_Pack_Cf.aspx/IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Mantenedor = JSON.parse(json_receiver);
                        Fill_Ddl_Mantenedor();
                        Hide_Modal();
                    } else {
                        Hide_Modal();
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
        //Llenar DropDownList DE ESTADOS
        function Fill_Ddl_Mantenedor() {
            $("#Ddl_Mantenedor").empty();
            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#Ddl_Mantenedor");
            for (y = 0; y < Mx_Dtt_Mantenedor.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_Mantenedor[y].ID_ESTADO
                }).text(Mx_Dtt_Mantenedor[y].EST_DESCRIPCION).appendTo("#Ddl_Mantenedor");
            }
            //$("#Ddl_Mantenedor").val(1);

        };
    </script>
    <%-------------------------------------------------- FUNCION PARA VALIDAR LOS CAMPOS VACIOS ---------------------------%>
    <script>
        function validar() {
            var sum = 0;
            if ($("#txtCod").val() == "") {
                $("#txtCod").css({
                    "border-color": "red"
                });
            } else {
                sum += 1;
                $("#txtCod").css({ "border-color": "#868e96" });
            }

            if ($("#txtDesc").val() == "") {
                $("#txtDesc").css({
                    "border-color": "red"
                });
            } else {
                sum += 1;
                $("#txtDesc").css({ "border-color": "#868e96" });
            }
            if ($("#Ddl_Mantenedor").val() == 0) {
                $("#Ddl_Mantenedor").css({
                    "border-color": "red"
                });
            } else {
                sum += 1;
                $("#Ddl_Mantenedor").css({ "border-color": "#868e96" });
            }
            return sum;
        }
    </script>
    <%-------------------------------------------------- FUNCION PARA PINTAR LOS INPUTS -----------------------------------%>
    <script>
        function pintarCasillas() {

            if (($("#txtCod").val()) || ($("#txtDesc").val()) || ($("#Ddl_Mantenedor").val())) {
                $("#txtCod").css({
                    "border-color": "black",
                    "border-width": "medium"
                });
                $("#txtDesc").css({
                    "border-color": "black",
                    "border-width": "medium"
                });
                $("#Ddl_Mantenedor").css({
                    "border-color": "black",
                    "border-width": "medium"
                });
            }
        }

    </script>
    <%-------------------------------------------------- FUNCION PARA DESPINTAR LOS INPUTS --------------------------------%>
    <script>
        function despintarCasillas() {
            if (($("#txtCod").val()) || ($("#txtDesc").val()) || ($("#Ddl_Mantenedor").val())) {
                $("#txtCod").css({
                    "border-color": "#868e96",
                    "border-width": "thin"
                });
                $("#txtDesc").css({
                    "border-color": "#868e96",
                    "border-width": "thin"
                });
                $("#Ddl_Mantenedor").css({
                    "border-color": "#868e96",
                    "border-width": "thin"
                });
            }

        }
    </script>
    <%-------------------------------------------------- AJAX_CODIGUIN ----------------------------------------------------%>
    <script>
        function Ajax_Codiguin(COD, DESC, ESTADO, ID) {
            $("#Btn_Guardar").attr("disabled", true);
            $("#Btn_Modificar").attr("disabled", false);
            $("#Btn_Eliminar").attr("disabled", false);

            $("#txtCod").val(COD);
            $("#txtDesc").val(DESC);
            $("#Ddl_Mantenedor").val(ESTADO);
            IDDDDDDD = parseInt(ID);
            pintarCasillas()
        };
    </script>
    <%-------------------------------------------------- BUSCAR DATOS DE LA TABLA -----------------------------------------%>
    <script>
        var Mx_Dtt = [
            {
                "ID_PACK": 0,
                "PACK_COD": 0,
                "PACK_DESC": 0,
                "ID_ESTADO": 0
            }
        ];
        function Ajax_Tabla_PACK() {
            modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rela_Pack_Cf.aspx/IRIS_WEBF_BUSCA_PACK_2023",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        $("#Div_Tabla").empty();
                        Fill_DataTable();
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
            //--------------------------------------------------- CREA LA TABLA -------------------------------------------|
        }
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
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Código"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Activo")
                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Codiguin("` + Mx_Dtt[i].PACK_COD + `","` + Mx_Dtt[i].PACK_DESC + `","` + Mx_Dtt[i].ID_ESTADO + `","` + Mx_Dtt[i].ID_PACK + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PACK_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PACK_DESC),
                        $("<td>").css("text-align", "center",).html("<input type='checkbox' style='pointer-events:none'   id='chekito" + i + "' />"),
                    )
                );
                if (Mx_Dtt[i].ID_ESTADO == 1) {
                    $("#chekito" + i).prop("checked", true);
                }
            }
            $("#DataTable tbody tr").click(function () {     /* <----- Pinta de color azul la tabla*/
                $("#DataTable tbody tr").removeClass("active");
                $(this).addClass("active");
            });
            $('#DataTable').dataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
                "retrieve": true,
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong></i>Filtro: </strong>"
                }
            });
        }
    </script>
    <%-------------------------------------------------- GRABA ----------------------------------------------------|--%>
    <script>
        var numerin = 0
        function Ajax_Guardar() {
            modal_show();
            var Data_Par = JSON.stringify({
                "PACK_COD": $("#txtCod").val(),
                "PACK_DES": $("#txtDesc").val(),
                "ID_ESTADO": $("#Ddl_Mantenedor").val()
            });

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rela_Pack_Cf.aspx/IRIS_WEBF_GRABA_PACK",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();

                        Ajax_Limpiar();
                        Ajax_Tabla_PACK();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
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
    <%-------------------------------------------------- UPDATE ------------------------------------------------------%>
    <script>
        var numerin = 0
        function Ajax_Update() {

            modal_show();

            var Data_Par = JSON.stringify({
                "ID_PACK": IDDDDDDD,
                "PACK_COD": $("#txtCod").val(),
                "PACK_DES": $("#txtDesc").val(),
                "ID_ESTADO": $("#Ddl_Mantenedor").val()
            });

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rela_Pack_Cf.aspx/IRIS_WEBF_CMVM_UPDATE_PACK",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();

                        Ajax_Limpiar();
                        Ajax_Tabla_PACK();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No ha ocurrido actualización.");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
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
    <%-------------------------------------------------- DELETE ------------------------------------------------------%>
    <script>

        var numerin = 0
        function Ajax_Delete() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_PACK": IDDDDDDD,
                "PACK_COD": $("#txtCod").val(),
                "PACK_DES": $("#txtDesc").val(),
                "ID_ESTADO": 2
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rela_Pack_Cf.aspx/IRIS_WEBF_CMVM_UPDATE_PACK",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();

                        Ajax_Limpiar();
                        Ajax_Tabla_PACK();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
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
    <%-------------------------------------------------- LIMPIAR ---------------------------------------------%>
    <script>
        function Ajax_Limpiar() {
            IDDDDDDD = 0;
            $("#txtCod").val("");
            $("#txtDesc").val("");
            $("#Ddl_Mantenedor").val(0);

            $("table tbody tr").removeClass("active");

            $("#Btn_Guardar").attr("disabled", false);
            $("#Btn_Modificar").attr("disabled", true);
            $("#Btn_Eliminar").attr("disabled", true);
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <!-- Estilos -->
    <style>
        .btn-sq-lg {
            width: 100px !important;
            height: 100px !important;
        }

        #bordes {
            margin: -1px;
        }

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

        .cabezera {
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

        /*.row {*/ /* Le agregue esto para que se vea mas ordenado */
        /*margin: 1px;
        }*/
        .rowBotones {
            margin: 4px;
        }

        .rowPrimeraFila {
            margin: 4px;
        }

        .border-bar {
            border-top: none;
            margin: -2px;
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

            #mError_AAH {
                z-index: 10;
            }
        }
    </style>
    <!-- Modal -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
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
    <div class="container-fluid">
        <div class="card mb-3 border-bar">
            <div class="card-header bg-bar p-2" id="bordes">
                <h5>Relación Pack - Codigo Fonasa</h5>
            </div>

            <div class="card-body">
                <div class="row">
                    <div class="col-md-6">
                        <label>Pack:</label>
                        <select id="slt_Pack" class="form-control"></select>
                    </div>
                    <div class="col-md-6">
                        <label>Crear Pack:</label>
                        <button type="button" class="btn btn-warning form-control" id="btn_modal_PACK"><i class="fa fa-fw fa-file-text-o mr-2"></i>Crear Pack</button>
                    </div>
                </div>

                <hr />
                <div class="row">
                    <div class="col-lg-5 mb-3" style="overflow: auto; height: 60vh;" id="Div_Tabla_Seccion_NO_Relacionadas">
                    </div>
                    <div class="col-lg-2 mb-3">
                        <div class="row  text-center mb-3">
                            <div class="col">
                                <a class="btn btn-sq-lg btn-primary" style="color: white" id="btn_Agregar"><b><i class="fa fa-arrow-right fa-3x"></i>
                                    <br />
                                    Agregar</b></a>
                            </div>
                        </div>
                        <div class="row  text-center">
                            <div class="col">
                                <a class="btn btn-sq-lg btn-danger" style="color: white" id="btn_Quitar"><b><i class="fa fa-arrow-left fa-3x"></i>
                                    <br />
                                    Quitar</b></a>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-5 mb-3" style="overflow: auto; height: 60vh;" id="Div_Tabla_Seccion_Rel">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%------------------------------------------------ MODAL DE INDICACIONES --%>
    <div class="modal fade" id="eModal3" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="max-width: 1400px" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="container-fluid">
                        <%------------------------------------------------------TÍTULO, TEXTBOX Y BOTONES-----------------------------------------%>
                        <div class="row">
                            <div class="col-lg">
                                <div class="card mb-3 border-bar">
                                    <div class="card-header bg-bar">
                                        <h5 style="text-align: center; padding: 5px;">
                                            <i class="fa fa-info"></i>
                                            PACK
                                        </h5>
                                    </div>
                                    <div class="rowPrimeraFila">
                                        <div class="row mb-3">
                                            <div class="col-md-4">
                                                <label for="txtCod">Código:</label>
                                                <input id="txtCod" class="form-control textoReducido" type="text" />
                                            </div>
                                            <div class="col-md-4">
                                                <label for="txtDesc">Descripción:</label>
                                                <input id="txtDesc" class="form-control text-uppercase textoReducido" type="text" />
                                            </div>
                                            <div class="col-md-4">
                                                <label for="Ddl_Mantenedor">Estado:</label>
                                                <select id="Ddl_Mantenedor" class="form-control textoReducido mayus">
                                                </select>
                                            </div>
                                        </div>
                                    </div>

                                    <%------------------------------------------------------------ TABLAS -------------------------------------------------------------%>
                                    <div class="row mb-3" id="Id_Conte">
                                        <div class="col-md-12" id="Paciente">
                                            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i>Lista de Pack</h5>
                                            <div id="Div_Tabla" style="width: 100%; height: 360px;" class="highlights"></div>
                                        </div>
                                    </div>
                                    <div class="rowBotones">
                                        <div class="row">
                                            <div class="col-md">
                                                <button id="Btn_Limpiar" class="btn btn-buscar btn-block" style="padding: 3px;" type="submit">Limpiar <i class="fa fa-fw fa-eraser mr-2" aria-hidden="true"></i></button>
                                            </div>
                                            <div class="col-md">
                                                <button id="Btn_Guardar" class="btn btn-primary btn-block" style="padding: 3px;" type="submit">Guardar <i class="fa fa-save" aria-hidden="true"></i></button>
                                            </div>
                                            <div class="col-md">
                                                <button id="Btn_Modificar" class="btn btn-warning btn-block" style="padding: 3px;" type="submit">Modificar <i class="fa fa-edit" aria-hidden="true"></i></button>
                                            </div>
                                            <div class="col-md">
                                                <button id="Btn_Eliminar" class="btn btn-danger btn-block" style="padding: 3px;" type="submit">Eliminar <i class="fa fa-fw fa-remove mr-2" aria-hidden="true"></i></button>
                                            </div>
                                            <%--<div class="col-md">
                                                <button id="Btn_Excel" class="btn btn-success btn-block" style="padding: 3px;" type="submit">Excel <i class="fa fa-eject" aria-hidden="true"></i></button>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" id="btnSalirModal2" data-bs-dismiss="modal">
                            Salir
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
