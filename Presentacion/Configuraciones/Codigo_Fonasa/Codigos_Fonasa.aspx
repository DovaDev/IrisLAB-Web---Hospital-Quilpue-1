<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Codigos_Fonasa.aspx.vb" Inherits="Presentacion.Codigos_Fonasa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
     <script>
         let id_cod_fona = 0
         let id_cod_Estudio = -1
         $(document).ready(function () {
             $(".block_wait").fadeOut(0);

             //BTN MODAL INDICACIONES
             $("#btn_modal_indicaciones").click(function () {
                 $('#eModal3').modal('hide');
                 $('#eModal3').modal('show');
                 console.log("si funco");
                 Ajax_Tabla_indicaciones()
                 Ajax_Indicaciones_Relacionadas()
             });
             //BTN SALIR MODAL INDICACIONES
             $("#btnSalirModal2").click(function () {
                 $('#eModal3').modal('hide')
             });
             //BTN AGREGAR MODAL INDICACIONES
             $("#btn_Agregar").click(function () {

                 let lista_comunas = Mx_Dtt_tabla_modal_indicaciones.filter(item => item.CHECK == 1).map(item => item.ID_IND)
                 console.log(lista_comunas)

                 Ajax_Agregar();

             });
             //BTN QUITAR MODAL INDICACIONES
             $("#btn_Quitar").click(function () {

                 let lista_comunas2 = Mx_Dtt_Indicaciones_rel.filter(item => item.CHECK == 1).map(item => item.ID_RLS_CF_IND)
                 console.log(lista_comunas2)

                 Ajax_Quitar();
             });


             //ON CLICK CLASS TOGGLE   
             $('table').on('click', 'tbody tr', function () {
                 $("table tbody tr").removeClass("active");
                 $(this).toggleClass("active");
             });
             $("#btn_guardar").attr("disabled", false);
             $("#btn_modificar").attr("disabled", true);
             $("#btn_eliminar").attr("disabled", true);
             $("#btn_modal").attr("disabled", true);
             $("#btn_modal_indicaciones").attr("disabled", true);
             Llenar_Ddl_Estado_Mant();

             //BTN MODIFICAR
             $("#btn_modificar").click(function () {
                 if (ID_CFF == 0) {

                     $("#mError_AAH h4").text("Seleccionar el dato en la tabla");
                     $("#mError_AAH button").attr("class", "btn btn-danger");
                     $("#mError_AAH p").text("Seleccionar en la tabla el dato que desea Eliminar .");
                     $("#mError_AAH").modal();
                 }
                 else {
                     if (validar() === 6) {
                         Hide_Modal();
                         Ajax_Update();
                         Ajax_Update_PF();
                         accion = 3
                         alerta_Proc_Correctos();
                         despintarCasillas();

                     }
                 }
             });
             //BTN ELIMINAR
             $("#btn_eliminar").click(function () {
                 if (ID_CFF == 0) {
                     $("#mError_AAH h4").text("Seleccionar el dato en la tabla");
                     $("#mError_AAH button").attr("class", "btn btn-danger");
                     $("#mError_AAH p").text("Seleccionar en la tabla el dato que desea Eliminar .");
                     $("#mError_AAH").modal();

                 } else {

                     accion = 4
                     alerta_Proc_Correctos();
                     despintarCasillas();
                     Ajax_Delete();
                     Ajax_Delete_PF();
                     Ajax_Clear();
                     $("#btn_modificar").attr("disabled", true);
                     $("#btn_eliminar").attr("disabled", true);
                 }
             });
             //BTN NUEVO(LIMPIAR)
             $("#btn_nuevo").click(function () {
                 Ajax_Clear();
                 accion = 1
                 alerta_Proc_Correctos();
                 despintarCasillas();
                 $("#btn_guardar").attr("disabled", false);
                 $("#btn_modificar").attr("disabled", true);
                 $("#btn_eliminar").attr("disabled", true);
                 $("#btn_modal").attr("disabled", true);
             });
             //BTN GUARDAR
             $("#btn_guardar").click(function () {
                 if (validar() === 6) {
                     Ajax_Create();
                     accion = 2
                     alerta_Proc_Correctos();
                     despintarCasillas();
                     $("#btn_guardar").attr("disabled", true);
                     $("#btn_modificar").attr("disabled", true);
                     $("#btn_eliminar").attr("disabled", true);
                 } else {
                     $("#mError_AAH h4").text("Error");
                     $("#mError_AAH button").attr("class", "btn btn-danger");
                     $("#mError_AAH p").text("Por favor, complete los campos solicitados.");
                     $("#mError_AAH").modal();
                 }
             });
             //BTN EXCEL
             $("#btn_Excel").click(function () {
                 Ajax_Excel();
                 accion = 5
                 alerta_Proc_Correctos();
                 despintarCasillas();
                 Ajax_Clear();
             });
             //PARTE DEL MODAL DE ASOCIAR ESTUDIO
             $("#btn_modal").click(function () {

                 $('#eModal2').modal('hide');
                 $('#eModal2').modal('show');
                 $("#Div_Tabla_Estudio_Cod_Fonasa").empty();
                 Ajax_Tabla_2()
                 id_cod_Estudio = -1
                 Ajax_Tabla_sin_id()
                 $("#txtCodigoEstudioModal").val("");
                 $("#txtDescripcionEstudioModal").val("");

             });
             //BTN SALIR Modal
             $("#btnSalir").click(function () {

                 $('#eModal2').modal('hide')
             });
             //BTN VINCULAR Modal
             $("#btnVincular").click(function () {

                 Ajax_vincular()

             });
             //BTN DESVINCULAR Modal
             $("#btnDesvincular").click(function () {

                 Ajax_desvincular()

             });
             //BTN VER ESTUDIO
             $("#btnVerEstudio").click(function () {

                 window.open('/Configuraciones/Estudios/Estudio_Crea_Modifica.aspx', '_blank');
                 //window.location.href = "/Configuraciones/Estudios/Estudio_Crea_Modifica.aspx";

             });

             //FINAL DEL MODAL ASOCIAR ESTUDIO

             //DEJA LOS CHECK EN 1 O EN 0
             $(document).on("change", "#div_chk input[type='checkbox']", function () {
                 if ($(this).is(':checked')) {
                     $(this).val("1");
                 } else {
                     $(this).val("0");
                 }
             });
         });
     </script>
 <%--------------------------------------------- VARIABLES ------------------------------------------------%>
 <script>
     //VARIBLES
     var POSS = 0;
     var AÑOO = "";
     var ID_CFF = "";
     var Mx_Ddl_Estado_Mant = [{
         "ID_ESTADO": "",
         "EST_DESCRIPCION": "",
         "EST_MANTENEDOR": ""
     }];
     var Mx_Ddl_Agrupacion_Mant = [{
         "ID_AMUESTRA": "",
         "AMUE_COD": "",
         "AMUE_DESC": "",
         "ID_ESTADO": ""
     }];
     var Mx_Año = [{
         "ID_AÑO": "",
         "AÑO_COD": "",
         "AÑO_DESC": "",
         "ID_ESTADO": ""
     }];
     var Mx_Dtt = [{
         "ID_CODIGO_FONASA": "",
         "CF_COD": "",
         "CF_DESC": "",
         "CF_CORTO": "",
         "CF_IMP_SOLA": "",
         "CF_IMP_NOM_PER": "",
         "CF_SEL_PRUE": "",
         "CF_DIAS": "",
         "ID_ESTADO": "",
         "CF_IMP_NUEVO": "",
         "CF_IMP_PARCIAL": "",
         "CF_HOST": "",
         "ID_AMUESTRA": ""
     }];
 </script>
 <%------------------------------- FUNCION PARA MOSTRAR UN ALERTA DE LOS PROCESOS HECHOS CORRECTAMENTE ------%>
 <script>
     function alerta_Proc_Correctos() {
         var text = ""
         switch (accion) {
             case 1:
                 text = 'Limpiado correctamente'
                 break;
             case 2:
                 text = 'Guardado correctamente'
                 break;
             case 3:
                 text = 'Modificado correctamente'
                 break;
             case 4:
                 text = 'Eliminado correctamente'
                 break;
             case 5:
                 text = 'El Excel se genero correctamente'
                 break;
         }

         const Toast = Swal.mixin({
             toast: true,
             position: 'top-end',
             showConfirmButton: false,
             timer: 1500,
             timerProgressBar: true,
             didOpen: (toast) => {
                 toast.addEventListener('mouseenter', Swal.stopTimer)
                 toast.addEventListener('mouseleave', Swal.resumeTimer)
             }
         })
         Toast.fire({
             icon: 'success',
             title: text
         })
     }
 </script>
 <%------------------------------- FUNCION PARA VALIDAR LOS CAMPOS VACIOS -------------------%>
 <script>
     function validar() {
         var sum = 0;
         if ($("#txt_cod").val() == "") {
             $("#txt_cod").css({
                 "border-color": "red"
             });
         } else {
             sum += 1;
             $("#txt_cod").css({ "border-color": "#868e96" });
         }

         if ($("#txt_des").val() == "") {
             $("#txt_des").css({
                 "border-color": "red"
             });
         } else {
             sum += 1;
             $("#txt_des").css({ "border-color": "#868e96" });
         }

         if ($("#txtdes_cor").val() == "") {
             $("#txtdes_cor").css({
                 "border-color": "red"
             });
         } else {
             sum += 1;
             $("#txtdes_cor").css({ "border-color": "#868e96" });
         }

         if ($("#txt_ndias").val() == "") {
             $("#txt_ndias").css({
                 "border-color": "red"
             });
         } else {
             sum += 1;
             $("#txt_ndias").css({ "border-color": "#868e96" });
         }

         if ($("#ddl_est").val() == 0) {
             $("#ddl_est").css({
                 "border-color": "red"
             });
         } else {
             sum += 1;
             $("#ddl_est").css({ "border-color": "#868e96" });
         }
         if ($("#txtcod_host").val()) {
             $("#txtcod_host").css({
                 "border-color": "#868e96"
             });
         } else {

             $("#txtcod_host").css({ "border-color": "#868e96" });
         }
         if ($("#ddl_agr").val() == 0) {
             $("#ddl_agr").css({
                 "border-color": "red"
             });
         } else {
             sum += 1;
             $("#ddl_agr").css({ "border-color": "#868e96" });
         }
         Swal.fire("Completar los campos en color rojo")
         return sum;
     }
 </script>
 <%------------------------------- FUNCION PARA PINTAR LOS INPUTS ---------------------------%>
 <script>
     function pintarCasillas() {

         if (($("#txt_cod").val()) || ($("#txt_des").val()) || ($("#txtdes_cor").val()) || ($("#txt_ndias").val()) || ($("#ddl_est").val()) || ($("#txtcod_host").val()) || ($("#ddl_agr").val())) {
             $("#txt_cod").css({
                 "border-color": "black",
                 "border-width": "medium"
             });
             $("#txt_des").css({
                 "border-color": "black",
                 "border-width": "medium"
             });
             $("#txtdes_cor").css({
                 "border-color": "black",
                 "border-width": "medium"
             });
             $("#txt_ndias").css({
                 "border-color": "black",
                 "border-width": "medium"
             });
             $("#ddl_est").css({
                 "border-color": "black",
                 "border-width": "medium"
             });
             $("#txtcod_host").css({
                 "border-color": "black",
                 "border-width": "medium"
             });
             $("#ddl_agr").css({
                 "border-color": "black",
                 "border-width": "medium"
             });

         }
     }

 </script>
 <%------------------------------- FUNCION PARA DESPINTAR LOS INPUTS ------------------------%>
 <script>
     function despintarCasillas() {
         if (($("#txt_cod").val()) || ($("#txt_des").val()) || ($("#txtdes_cor").val()) || ($("#txt_ndias").val()) || ($("#ddl_est").val()) || ($("#txtcod_host").val()) || ($("#ddl_agr").val())) {
             $("#txt_cod").css({
                 "border-color": "#868e96",
                 "border-width": "thin"
             });
             $("#txt_des").css({
                 "border-color": "#868e96",
                 "border-width": "thin"
             });
             $("#txtdes_cor").css({
                 "border-color": "#868e96",
                 "border-width": "thin"
             });
             $("#txt_ndias").css({
                 "border-color": "#868e96",
                 "border-width": "thin"
             });
             $("#ddl_est").css({
                 "border-color": "#868e96",
                 "border-width": "thin"
             });
             $("#txtcod_host").css({
                 "border-color": "#868e96",
                 "border-width": "thin"
             });
             $("#ddl_agr").css({
                 "border-color": "#868e96",
                 "border-width": "thin"
             });

         }

     }
 </script>
 <%------------------------------- DDL ESTADO MANTENEDOR-------------------------------------%>
 <script>
     //AJAX DDL ESTADO MANTENEDOR
     function Llenar_Ddl_Estado_Mant() {
         //Debug

         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/Llenar_Ddl_Estado_Mant",
             //"data": Data_Par,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": data => {

                 //Debug
                 Mx_Ddl_Estado_Mant = JSON.parse(data.d);

                 Fill_Ddl_Estado_Mantenedor();
                 Llenar_Ddl_Agrupacion_Mant();

             },
             "error": data => {
                 //Debug

             }
         });
     }
     //FILL DROPDOWNLIST AGRUPACION MANTENEDOR
     function Fill_Ddl_Agrupacion_Mantenedor() {
         Mx_Ddl_Agrupacion_Mant.forEach(aax => {
             $("<option>", {
                 "value": aax.ID_AMUESTRA
             }
             ).text(aax.AMUE_DESC).appendTo("#ddl_agr");
         });
     }
 </script>
 <%------------------------------- DDL AGRUPACION MANTENEDOR---------------------------------%>
 <script>
     //AJAX DDL AGRUPACION MANTENEDOR
     function Llenar_Ddl_Agrupacion_Mant() {
         //Debug

         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/Llenar_Ddl_Agrupacion_Mant",
             //"data": Data_Par,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": data => {
                 //Debug
                 Mx_Ddl_Agrupacion_Mant = JSON.parse(data.d);
                 Fill_Ddl_Agrupacion_Mantenedor();
                 Llenar_Dtt();

             },
             "error": data => {
                 //Debug

             }
         });
     }
     //FILL DROPDOWNLIST ESTADO MANTENEDOR
     function Fill_Ddl_Estado_Mantenedor() {
         Mx_Ddl_Estado_Mant.forEach(aaa => {
             $("<option>",
                 {
                     "value": aaa.ID_ESTADO
                 }
             ).text(aaa.EST_DESCRIPCION).appendTo("#ddl_est");
         });
     }
 </script>
 <%------------------------------- AJAX BUSCAR AÑO ------------------------------------------%>
 <script>
     //AJAX BUSCAR AÑO 
     function Llenar_Ano() {
         var año = moment().format("YYYY");
         //Parámetros
         var strParam = JSON.stringify({
             "ANO": año
         });
         //Debug

         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/Llenar_Año",
             "data": strParam,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": data => {
                 //Debug
                 Mx_Año = JSON.parse(data.d);
                 Mx_Año.forEach(aaññoo => {
                     AÑOO = aaññoo.ID_AÑO;
                 });
             },
             "error": data => {
                 //Debug

             }
         });
     }
 </script>
 <%------------------------------- GRABA ----------------------------------------------------%>
 <script>
     //AJAX GUARDAR
     function Ajax_Create() {
         //Parámetros
         var strParam = JSON.stringify({
             "COD_CF": $("#txt_cod").val(),
             "DESC_CF": $("#txt_des").val(),
             "CORTO_CF": $("#txtdes_cor").val(),
             "DIAS_CF": $("#txt_ndias").val(),
             "ID_ESTADO": $("#ddl_est").val(),
             "SOLA_CF": $("#chk_imp_una_pag").val(),
             "IMP_NOM_CF": $("#chk_imp_nom_est").val(),
             "IMP_SEL_CF": $("#chk_imp_sel_prueba").val(),
             "IMP_PAR_CF": $("#chk_imp_parcial").val(),
             "HOST_CF": $("#txtcod_host").val(),
             "ID_MUESTRA": $("#ddl_agr").val(),
         });
         //Debug

         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/Create_CF",
             "data": strParam,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": data => {
                 //Debug
                 $("table").dataTable().fnDestroy();
                 $("#DataTable").empty();
                 $("DataTable_Fonasa").dataTable().fnDestroy();
                 Llenar_Dtt();
                 Ajax_Clear();
                 $("#EM2 h5").text("Código Fonasa Guardado");
                 $("#EM2 button").attr("class", "btn btn-success");
                 $("#EM2 p").text("Se realizaron los cambios con éxito");
                 $("#EM2").modal();

             },
             "error": data => {
                 //Debug

                 $("#EM2 h5").text("Error");
                 $("#EM2 button").attr("class", "btn btn-danger");
                 $("#EM2 p").text("Ocurrió un error durante el guardado del Código Fonasa");
                 $("#EM2").modal();
             }
         });


     }
 </script>
 <%------------------------------- UPDATE ---------------------------------------------------%>
 <script>
     //AJAX MODIFICAR
     function Ajax_Update() {
         //Parámetros
         var strParam = JSON.stringify({
             "ID_CF": ID_CFF,
             "COD_CF": $("#txt_cod").val(),
             "DESC_CF": $("#txt_des").val(),
             "CORTO_CF": $("#txtdes_cor").val(),
             "DIAS_CF": $("#txt_ndias").val(),
             "ID_ESTADO": $("#ddl_est").val(),
             "SOLA_CF": $("#chk_imp_una_pag").val(),
             "IMP_NOM_CF": $("#chk_imp_nom_est").val(),
             "IMP_SEL_CF": $("#chk_imp_sel_prueba").val(),
             "IMP_PAR_CF": $("#chk_imp_parcial").val(),
             "HOST_CF": $("#txtcod_host").val(),
             "ID_MUESTRA": $("#ddl_agr").val()
         });
         //Debug

         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/Update_CF",
             "data": strParam,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": data => {
                 //Debug
                 $("DataTable_Fonasa").dataTable().fnDestroy();
                 $("#EM2 h5").text("Código Fonasa Modificado");
                 $("#EM2 button").attr("class", "btn btn-success");
                 $("#EM2 p").text("Se realizaron los cambios con éxito");
                 $("#EM2").modal();

             },
             "error": data => {
                 //Debug
                 $("DataTable_Fonasa").dataTable().fnDestroy();
                 $("#EM2 h5").text("Error");
                 $("#EM2 button").attr("class", "btn btn-danger");
                 $("#EM2 p").text("Ocurrió un error durante el guardado del Código Fonasa");
                 $("#EM2").modal();
             }
         });
         MX_UPD();
         Ajax_Clear();
     }
     function Ajax_Update_PF() {
         //Parámetros
         var strParam = JSON.stringify({
             "ID_ANO": AÑOO,
             "ID_USUARIO": "1",
             "ID_FONASA": ID_CFF,
             "ID_ESTADO": $("#ddl_est").val()
         });
         //Debug

         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/Update_PF",
             "data": strParam,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": data => {
                 //Debug

             },
             "error": data => {
                 //Debug

             }
         });
     }
 </script>
 <%------------------------------- DELETE ---------------------------------------------------%>
 <script>
     //AJAX ELIMINAR
     function Ajax_Delete() {
         //Parámetros
         var strParam = JSON.stringify({
             "ID_CF": ID_CFF,
             "COD_CF": $("#txt_cod").val(),
             "DESC_CF": $("#txt_des").val(),
             "CORTO_CF": $("#txtdes_cor").val(),
             "DIAS_CF": $("#txt_ndias").val(),
             "ID_ESTADO": "2",
             "SOLA_CF": $("#chk_imp_una_pag").val(),
             "IMP_NOM_CF": $("#chk_imp_nom_est").val(),
             "IMP_SEL_CF": $("#chk_imp_sel_prueba").val(),
             "IMP_PAR_CF": $("#chk_imp_parcial").val(),
             "HOST_CF": $("#txtcod_host").val(),
             "ID_MUESTRA": $("#ddl_agr").val()
         });
         //Debug

         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/Update_CF",
             "data": strParam,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": data => {
                 //Debug

                 $("#EM2 h5").text("Código Fonasa Eliminado");
                 $("#EM2 button").attr("class", "btn btn-success");
                 $("#EM2 p").text("Se realizaron los cambios con éxito");
                 $("#EM2").modal();
             },
             "error": data => {
                 //Debug

                 $("#EM2 h5").text("Error");
                 $("#EM2 button").attr("class", "btn btn-danger");
                 $("#EM2 p").text("Ocurrió un error durante la Eliminación del Código Fonasa");
                 $("#EM2").modal();
             }
         });
         MX_DEL();
         Ajax_Clear();
     }
     function Ajax_Delete_PF() {
         //Parámetros
         var strParam = JSON.stringify({
             "ID_ANO": AÑOO,
             "ID_USUARIO": "1",
             "ID_FONASA": ID_CFF,
             "ID_ESTADO": "2"
         });
         //Debug

         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/Update_PF",
             "data": strParam,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": data => {
                 //Debug
             },
             "error": data => {
                 //Debug

             }
         });
     }
 </script>
 <%------------------------------- BUSCAR DATOS DE LA TABLA CODIGO FONASA (PRIMERA TABLA) ---%>
 <script>
     //AJAX DataTable
     function Llenar_Dtt() {
         modal_show();
         //Debug

         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/Llenar_Dtt",
             //"data": strParam,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": data => {
                 //Debug
                 Mx_Dtt = JSON.parse(data.d);
                 Fill_Dtt();

             },
             "error": data => {
                 //Debug

                 Hide_Modal();
             }
         });
     }
     //MATRIZ DELETE
     function MX_DEL() {
         Mx_Dtt.splice(POSS, 1); //eliminar 
         $("DataTable_Fonasa").dataTable().fnDestroy();
         $("#DataTable_Fonasa").empty();
         Fill_Dtt();
     }
     //MATRIZ UPDATE
     function MX_UPD() {
         Mx_Dtt.splice(POSS, 1, {
             "CF_COD": $("#txt_cod").val(),
             "CF_CORTO": $("#txtdes_cor").val(),
             "CF_DESC": $("#txt_des").val(),
             "CF_DIAS": $("#txt_ndias").val(),
             "CF_IMP_SOLA": $("#chk_imp_una_pag").val(),
             "CF_IMP_NOM_PER": $("#chk_imp_nom_est").val(),
             "CF_IMP_NUEVO": "",
             "CF_IMP_PARCIAL": $("#chk_imp_parcial").val(),
             "CF_SEL_PRUE": $("#chk_imp_sel_prueba").val(),
             "ID_AMUESTRA": $("#ddl_agr").val(),
             "ID_CODIGO_FONASA": ID_CFF,
             "ID_ESTADO": $("#ddl_est").val()
         }); //actualizar
         $("DataTable_Fonasa").dataTable().fnDestroy();
         $("#DataTable_Fonasa").empty();
         Fill_Dtt();
     }
     //--------------------------- CREA LA TABLA -------------------------------------------|
     function Fill_Dtt() {
         $("#DataTable_Fonasa").empty();
         $("<table>", {
             "id": "DataTable",
             "class": "Display",
             "width": "100%",
             "cellspacing": "0",
         }).appendTo("#DataTable_Fonasa");
         $("#DataTable").append(
             $("<thead>"),
             $("<tbody>"),
         );
         $("#DataTable").attr("class", "table table-hover table-striped table-iris");
         $("#DataTable thead").attr("class", "cabezera");
         $("#DataTable thead").append(
             $("<tr>").append(
                 $("<th>", { "class": "textoReducido" }).text("#"),
                 $("<th>", { "class": "textoReducido" }).text("Codigo"),
                 $("<th>", { "class": "textoReducido" }).text("Descripción"),
                 $("<th>", { "class": "textoReducido" }).text("Activo"),
                 $("<th>", { "class": "textoReducido" }).text("Imp. 1 Pag."),
                 $("<th>", { "class": "textoReducido" }).text("Imp. Nom Est."),
                 $("<th>", { "class": "textoReducido" }).text("Sel. Prueba"),
                 $("<th>", { "class": "textoReducido" }).text("Imp-Parcial."),
             )
         );
         //Recorrer JSON
         //VAR i PARA ID DE CHK
         var i = 1
         Mx_Dtt.forEach(aah => {
             $("<tr>", {
                 "onclick": `Ajax_Llenar_Form("` + aah.ID_CODIGO_FONASA + `","` + i + `")`,
                 "class": "manito",
                 "id": aah.ID_CODIGO_FONASA
             }).append(
                 $("<td>").css({ "text-align": "left", "font-weight": "bold" }).text(i),
                 $("<td>").css("text-align", "left").text(aah.CF_COD),
                 $("<td>").css("text-align", "left").text(aah.CF_DESC),
                 //CREAR CHK CON ID
                 $("<td>").css("text-align", "center").html("<input type='checkbox' style='pointer-events:none' id='chk_Id_E" + i + "' value='" + aah.ID_ESTADO + "' />"),
                 $("<td>").css("text-align", "center").html("<input type='checkbox' style='pointer-events:none' id='chk_Id_S" + i + "' value='" + aah.CF_IMP_SOLA + "' />"),
                 $("<td>").css("text-align", "center").html("<input type='checkbox' style='pointer-events:none' id='chk_Id_N" + i + "' value='" + aah.CF_IMP_NOM_PER + "' />"),
                 $("<td>").css("text-align", "center").html("<input type='checkbox' style='pointer-events:none' id='chk_Id_P" + i + "' value='" + aah.CF_SEL_PRUE + "' />"),
                 $("<td>").css("text-align", "center").html("<input type='checkbox' style='pointer-events:none' id='chk_Id_I" + i + "' value='" + aah.CF_IMP_PARCIAL + "' />")
             ).appendTo("#DataTable_Fonasa tbody");
             //SI EL ESTADO DEL CHK ES 1.. CHECKEAR :B
             if (aah.ID_ESTADO == 1) {
                 $("#chk_Id_E" + i).prop("checked", true);
             }
             if (aah.CF_IMP_SOLA == 1) {
                 $("#chk_Id_S" + i).prop("checked", true);
             }
             if (aah.CF_IMP_NOM_PER == 1) {
                 $("#chk_Id_N" + i).prop("checked", true);
             }
             if (aah.CF_SEL_PRUE == 1) {
                 $("#chk_Id_P" + i).prop("checked", true);
             }
             if (aah.CF_IMP_PARCIAL == 1) {
                 $("#chk_Id_I" + i).prop("checked", true);
             }
             i += 1;
             Hide_Modal();
         });
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
 <%------------------------------- BUSCAR DATOS DE ASOCIAR CODIGO FONASA A UN ESTUDIO SIN ID OSEA QUE MOSTRARA TODOS LOS DATOS --%>
 <script>
     var Mx_Dtt_tabla_modal = [
         {
             "ID_PER": 0,
             "PER_COD": 0,
             "PER_DESC": 0,
             "PER_NUM_PRU": 0,
             "RLS_LS_DESC": 0,
         }
     ];
     function Ajax_Tabla_sin_id() {
         modal_show();

         $(".block_wait").fadeIn(500);
         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/LLENAR_TABLA_CODIGO_FONASA_ESTUDIO_SIN_ID",
             //"data": Data_Par,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": function (response) {
                 var json_receiver = response.d;
                 console.log(json_receiver)
                 if (json_receiver != "null") {

                     Mx_Dtt_tabla_modal = (json_receiver);
                     $("#Div_Tabla_Estudios").empty();
                     Fill_DataTable2();
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
     //----------------------------------- CREA LA TABLA -------------------------------------------|
     function Fill_DataTable2() {
         $("<table>", {
             "id": "Div_Tabla_Estudios",
             "class": "display",
             "width": "100%",
             "cellspacing": "0"
         }).appendTo("#Div_Tabla");
         $("#Div_Tabla_Estudios").append(
             $("<thead>"),
             $("<tbody>")
         );
         $("#Div_Tabla_Estudios").attr("class", "table table-hover table-striped table-iris");
         $("#Div_Tabla_Estudios thead").attr("class", "cabezera");
         $("#Div_Tabla_Estudios thead").append(
             $("<tr>").append(
                 $("<th>", { "class": "textoReducido" }).text("#"),
                 $("<th>", { "class": "textoReducido" }).text("Código Estudios"),
                 $("<th>", { "class": "textoReducido" }).text("Descripción Estudios"),
                 $("<th>", { "class": "textoReducido" }).text("N° Determinaciones "),
                 $("<th>", { "class": "textoReducido" }).text("Seccion"),
             )
         );
         for (i = 0; i < Mx_Dtt_tabla_modal.length; i++) {
             $("#Div_Tabla_Estudios tbody").append(
                 $("<tr>", {
                     "onclick": `viewInfoEstudio("` + Mx_Dtt_tabla_modal[i].ID_PER + `","` + Mx_Dtt_tabla_modal[i].PER_COD + `","` + Mx_Dtt_tabla_modal[i].PER_DESC + `")`,
                     "class": "manito"
                 }).append(
                     $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                     $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_tabla_modal[i].PER_COD),
                     $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_tabla_modal[i].PER_DESC),
                     $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_tabla_modal[i].PER_NUM_PRU),
                     $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_tabla_modal[i].RLS_LS_DESC),
                 )
             );
         }
         $("#Div_Tabla_Estudios tbody tr").click(function () {     /* <----- Pinta de color azul la tabla*/
             $("#Div_Tabla_Estudios tbody tr").removeClass("active");
             $(this).addClass("active");
         });
         $('#Div_Tabla_Estudios').DataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
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
     function viewInfoEstudio(id_per, per_cod, per_desc) {
         $("#txtCodigoEstudioModal").val("");
         $("#txtDescripcionEstudioModal").val("");
         console.log(id_per, per_cod, per_desc)


         localStorage.setItem("perfil", id_per);
         id_cod_Estudio = id_per

         $("#txtCodigoEstudioModal").val(per_cod);
         $("#txtDescripcionEstudioModal").val(per_desc);

     }
 </script>
 <%------------------------------- VINCULAR Y DESVINCULAR -----------------------------------%>
 <script>
     //AJAX ELIMINAR
     function Ajax_vincular() {
         //Parámetros
         let strParamVinculo = JSON.stringify({
             "ID_EST": id_cod_Estudio,
             "ID_FONASA": id_cod_fona,

         });
         //Debug

         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/vincular_estudio_fonasa",
             "data": strParamVinculo,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": data => {
                 //Debug
                 Ajax_Tabla_2()
                 $("#EM2 h5").text("Vinculados");
                 $("#EM2 button").attr("class", "btn btn-success");
                 $("#EM2 p").text("Se realizaron la Vinculacion");
                 $("#EM2").modal();
             },
             "error": data => {
                 //Debug

                 $("#EM2 h5").text("Error");
                 $("#EM2 button").attr("class", "btn btn-danger");
                 $("#EM2 p").text("Ocurrió un error durante la Eliminación del Código Fonasa");
                 $("#EM2").modal();
             }
         });
     }

     function Ajax_desvincular() {
         //Parámetros
         let strParamDesvincular = JSON.stringify({
             "ID_EST": id_cod_Estudio,
             "ID_FONASA": id_cod_fona,
         });
         console.log('params enviados desde desvinvular:', strParamDesvincular);
         //Debug

         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/desvincular_estudio_fonasa",
             "data": strParamDesvincular,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": data => {
                 //Debug
                 Ajax_Tabla_2()
                 $("#EM2 h5").text("Desvinculados");
                 $("#EM2 button").attr("class", "btn btn-success");
                 $("#EM2 p").text("Estudio desvinculado correctamente");
                 $("#EM2").modal();
             },
             "error": data => {
                 //Debug

                 $("#EM2 h5").text("Error");
                 $("#EM2 button").attr("class", "btn btn-danger");
                 $("#EM2 p").text("Ocurrió un error durante la Eliminación del Código Fonasa");
                 $("#EM2").modal();
             }
         });
     }

 </script>
 <%------------------------------- BUSCAR DATOS DE ASOCIAR CODIGO FONASA A UN ESTUDIO MEDIANTE LA ID --%>
 <script>
     var Mx_Dtt_fonasa_estudio = [
         {
             "ID_CODIGO_FONASA": 0,
             "CF_COD": 0,
             "CF_DESC": 0,
             "PER_DESC": 0,
             "ID_PER": 0,
             "PER_COD": 0
         }
     ];
     function Ajax_Tabla_2() {
         modal_show();

         $(".block_wait").fadeIn(500);
         const body = JSON.stringify({
             "ID_FONASA": id_cod_fona
         })
         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/LLENAR_TABLA_CODIGO_FONASA_ESTUDIO",
             "data": body,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": function (response) {
                 var json_receiver = response.d;

                 console.log('Json con codigo fonasa estudio', json_receiver);
                 if (json_receiver != "null") {
                     Mx_Dtt_fonasa_estudio = /*JSON.parse*/(json_receiver);


                     if (Mx_Dtt_fonasa_estudio.length > 0) {
                         console.log('este es mi  ID_PER despues de if', Mx_Dtt_fonasa_estudio[0].ID_PER)
                         localStorage.setItem("perfil", Mx_Dtt_fonasa_estudio[0].ID_PER);
                     }
                     $("#Div_Tabla_Estudio_Cod_Fonasa").empty();
                     Fill_DataTable_fonasa_estudio();
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
     //----------------------------------- CREA LA TABLA -------------------------------------------|
     function Fill_DataTable_fonasa_estudio() {
         $("<table>", {
             "id": "DataTable1",
             "class": "display",
             "width": "100%",
             "cellspacing": "0"
         }).appendTo("#Div_Tabla_Estudio_Cod_Fonasa");
         $("#DataTable1").append(
             $("<thead>"),
             $("<tbody>")
         );
         $("#DataTable1").attr("class", "table table-hover table-striped table-iris");
         $("#DataTable1 thead").attr("class", "cabzera");
         $("#DataTable1 thead").append(
             $("<tr>").append(
                 $("<th>", { "class": "textoReducido" }).text("Codigo Estudio"),
                 $("<th>", { "class": "textoReducido" }).text("Descripción Estudio"),
             )
         );
         for (i = 0; i < Mx_Dtt_fonasa_estudio.length; i++) {
             $("#DataTable1 tbody").append(
                 $("<tr>", {
                     "class": "manito",
                     id: Mx_Dtt_fonasa_estudio[i].ID_CODIGO_FONASA
                 }).append(
                     $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_fonasa_estudio[i].PER_COD),
                     $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_fonasa_estudio[i].PER_DESC),
                 )
             );

         }
         $("#DataTable1 tbody tr").click(function () {     /* <----- Pinta de color azul la tabla*/
             $("#DataTable1 tbody tr").removeClass("active");
             const filtrado = Mx_Dtt_fonasa_estudio.find(item => item.ID_CODIGO_FONASA == $(this).attr("id"))

             Ajax_Codiguin_COD_FONASA_ESTUDIO(filtrado.ID_CODIGO_FONASA, filtrado.CF_COD, filtrado.CF_DESC, filtrado.PER_DESC, filtrado.ID_PER, filtrado.PER_COD)
             $(this).addClass("active");
         });
     }
 </script>
 <%------------------------------- LIMPIAR --------------------------------------------------%>
 <script>
     //LIMPIAR CAMPOS
     function Ajax_Clear() {
         ID_CFF = 0;
         $("#txt_cod").val("");
         $("#txt_des").val("");
         $("#txtdes_cor").val("");
         $("#txt_ndias").val("");
         $("#chk_imp_una_pag").val("0");
         $("#chk_imp_una_pag").prop("checked", false);
         $("#chk_imp_nom_est").val("0");
         $("#chk_imp_nom_est").prop("checked", false);
         $("#chk_imp_sel_prueba").val("0");
         $("#chk_imp_sel_prueba").prop("checked", false);
         $("#chk_imp_parcial").val("0");
         $("#chk_imp_parcial").prop("checked", false);
         $("#txtcod_host").val("");
         $("table tbody tr").removeClass("active");
         $("#btn_guardar").attr("disabled", false);
         $("#btn_modificar").attr("disabled", true);
         $("#btn_eliminar").attr("disabled", true);
         $("#btn_modal_indicaciones").attr("disabled", true);
     }
 </script>
 <%------------------------------- LLENAR FORMULARIO (CODIGUIN) -----------------------------%>
 <script>
     //LLENAR FORMULARIO 
     function Ajax_Llenar_Form(idd, i) {
         POSS = i - 1;
         $("#btn_guardar").attr("disabled", true);
         $("#btn_modificar").attr("disabled", false);
         $("#btn_eliminar").attr("disabled", false);
         $("#btn_modal").attr("disabled", false);
         $("#btn_modal_indicaciones").attr("disabled", false);
         pintarCasillas();
         const filtrado = Mx_Dtt.find(fona => fona.ID_CODIGO_FONASA == idd);
         if (!filtrado) {
             return
         }
         id_cod_fona = filtrado.ID_CODIGO_FONASA
         //APARTADO DEL MODAL
         $("#txtCodigoFonasaModal").val(filtrado.CF_COD);
         $("#txtDescripcionFonasaModal").val(filtrado.CF_DESC);
         //APARTADO DEL MODAL DE INDICACIONES
         $("#txtCodigoFonasaModal2").val(filtrado.CF_COD);
         $("#txtDescripcionFonasaModal2").val(filtrado.CF_DESC);
         //FIN DEL APARTADO DEL MODAL
         ID_CFF = filtrado.ID_CODIGO_FONASA;

         $("#txt_cod").val(filtrado.CF_COD);
         $("#txt_des").val(filtrado.CF_DESC);
         $("#txtdes_cor").val(filtrado.CF_CORTO);
         $("#txt_ndias").val(filtrado.CF_DIAS);
         $("#ddl_est").val(filtrado.ID_ESTADO);
         if (filtrado.CF_IMP_SOLA == 1) {
             $("#chk_imp_una_pag").prop("checked", true);
             $("#chk_imp_una_pag").val("1");
         }
         else {
             $("#chk_imp_una_pag").prop("checked", false);
             $("#chk_imp_una_pag").val("0");
         }
         if (filtrado.CF_IMP_NOM_PER == 1) {
             $("#chk_imp_nom_est").prop("checked", true);
             $("#chk_imp_nom_est").val("1");
         }
         else {
             $("#chk_imp_nom_est").val("0");
             $("#chk_imp_nom_est").prop("checked", false);
         }
         if (filtrado.CF_SEL_PRUE == 1) {
             $("#chk_imp_sel_prueba").prop("checked", true);
             $("#chk_imp_sel_prueba").val("1");
         }
         else {
             $("#chk_imp_sel_prueba").prop("checked", false);
             $("#chk_imp_sel_prueba").val("0");
         }
         if (filtrado.CF_IMP_PARCIAL == 1) {
             $("#chk_imp_parcial").prop("checked", true);
             $("#chk_imp_parcial").val("1");
         }
         else {
             $("#chk_imp_parcial").prop("checked", false);
             $("#chk_imp_parcial").val("0");
         }
         $("#txtcod_host").val(filtrado.CF_HOST);
         $("#ddl_agr").val(filtrado.ID_AMUESTRA);



     }
 </script>
 <%------------------------------- EXCEL ----------------------------------------------------%>
 <script>
     var Mx_Dtt_Excel = [
         {
             "urls": ""
         }
     ];

     function Ajax_Excel() {

         var Data_Par = JSON.stringify({
             "DOMAIN_URL": location.origin
         });
         $(".block_wait").fadeIn(500);
         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/Excel",
             "data": Data_Par,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": function (response) {
                 var json_receiver = response.d;
                 if (json_receiver != "null") {
                     window.open(json_receiver, 'Download');


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
 </script>
 <%------------------------------- BUSCAR INDICACIONES NO RELACIONADA (TABLA MODAL) --%>
 <script>
     var Mx_Dtt_tabla_modal_indicaciones = [
         {
             "ID_ESTADO": 0,
             "ID_IND": 0,
             "IND_COD": 0,
             "IND_DES": 0,
             "CHECK": 0

         }
     ];
     function Ajax_Tabla_indicaciones() {
         var Data_Par = JSON.stringify({
             "ID_FONASA": id_cod_fona

         });

         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/IRIS_WEBF_CMVM_BUSCA_INDICACIONES_BY_ID_CODIGO_FONASA_NO_RELACIONADAS",
             "data": Data_Par,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": function (response) {
                 var json_receiver = response.d;
                 if (json_receiver != "null") {

                     Mx_Dtt_tabla_modal_indicaciones = (json_receiver);

                     $("#Div_Tabla_indicaciones").empty();
                     Fill_DataTable4();
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
     //----------------------------------- CREA LA TABLA -------------------------------------------|
     function Fill_DataTable4() {
         $("<table>", {
             "id": "Div_Tabla_indicaciones",
             "class": "display",
             "width": "100%",
             "cellspacing": "0"
         }).appendTo("#Div_Tabla_indi");
         $("#Div_Tabla_indicaciones").append(
             $("<thead>"),
             $("<tbody>")
         );
         $("#Div_Tabla_indicaciones").attr("class", "table table-hover table-striped table-iris");
         $("#Div_Tabla_indicaciones thead").attr("class", "cabezera");
         $("#Div_Tabla_indicaciones thead").append(
             $("<tr>").append(
                 $("<th>", { "class": "textoReducido" }).text("#"),
                 $("<th>", { "class": "textoReducido" }).text("Descripción"),
                 $("<th>", { "class": "textoReducido" }).text("Agregar")

             )
         );
         for (i = 0; i < Mx_Dtt_tabla_modal_indicaciones.length; i++) {
             $("#Div_Tabla_indicaciones tbody").append(
                 $("<tr>", {
                     "onclick": `Ajax_Codiguin_No_Relacionadas("` + Mx_Dtt_tabla_modal_indicaciones[i].ID_IND + `")`,
                     "class": "manito"
                 }).append(
                     $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                     $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_tabla_modal_indicaciones[i].IND_DES),
                     $("<td>").css("text-align", "left",).html("<input type='checkbox'  id='No_relacionado" + Mx_Dtt_tabla_modal_indicaciones[i].ID_IND + "' />"),
                 )
             );
         }
         $("#Div_Tabla_indicaciones tbody tr").click(function () {
             $("#Div_Tabla_indicaciones tbody tr").removeClass("active");
             $(this).addClass("active");
         });
         $("#Div_Tabla_indicaciones tbody tr td input").click(function (e) {
             let id_check = $(e.currentTarget).attr('id');


             let aux = Mx_Dtt_tabla_modal_indicaciones.find(item => item.ID_IND == id_check.split('No_relacionado')[1]);

             aux.CHECK = $('#' + id_check).is(':checked') ? 1 : 0;
         });
         $('#Div_Tabla_indicaciones').DataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
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
 <%------------------------------- BUSCA INDICACIONES RELACIONADA  --%>
 <script>
     var Mx_Dtt_Indicaciones_rel = [
         {
             "ID_ESTADO": 0,
             "ID_IND": 0,
             "IND_COD": 0,
             "IND_DES": 0,
             "CHECK": 0,
             "ID_RLS_CF_IND": 0

         }
     ];
     function Ajax_Indicaciones_Relacionadas() {
         var Data_Par = JSON.stringify({
             "ID_FONASA": id_cod_fona

         });
         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/IRIS_WEBF_CMVM_BUSCA_RELACION_FONASA_INDICACION_ID_CODFONASA_MANTENEDOR_REL",
             "data": Data_Par,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": function (response) {
                 var json_receiver = response.d;
                 if (json_receiver != "null") {

                     Mx_Dtt_Indicaciones_rel = (json_receiver);
                     Mx_Dtt_Indicaciones_rel = Mx_Dtt_Indicaciones_rel.map(item => {
                         item.CHECK = 0;
                         return item;
                     });
                     $("#Div_Tabla_Indicaciones_Rel").empty();


                     Fill_DataTable_Indicaciones_Relacionada();
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
     /*----------------------------------- CREACION DE LA TABLA CON LAS INDICACIONES REALACIONADAS -----------------------------*/
     function Fill_DataTable_Indicaciones_Relacionada() {
         $("<table>", {
             "id": "DataTable_indi_id",
             "class": "display",
             "width": "100%",
             "cellspacing": "0"
         }).appendTo("#Div_Tabla_Indicaciones_Rel");
         $("#DataTable_indi_id").append(
             $("<thead>"),
             $("<tbody>")
         );
         $("#DataTable_indi_id").attr("class", "table table-hover table-striped table-iris");
         $("#DataTable_indi_id thead").attr("class", "cabezera");
         $("#DataTable_indi_id thead").append(
             $("<tr>").append(
                 $("<th>", { "class": "textoReducido" }).text("#"),
                 $("<th>", { "class": "textoReducido" }).text("Descripción"),
                 $("<th>", { "class": "textoReducido" }).text("Quitar")

             )
         );
         for (i = 0; i < Mx_Dtt_Indicaciones_rel.length; i++) {
             $("#DataTable_indi_id tbody").append(
                 $("<tr>", {
                     "onclick": `Ajax_Codiguin_Tabla_Relacionada("` + Mx_Dtt_Indicaciones_rel[i].ID_RLS_CF_IND + `")`,
                     "class": "manito"
                 }).append(
                     $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                     $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Indicaciones_rel[i].IND_DES),
                     $("<td>").css("text-align", "left",).html("<input type='checkbox'  id='relacionado" + Mx_Dtt_Indicaciones_rel[i].ID_RLS_CF_IND + "' />"),
                 )
             );
         }
         $("#DataTable_indi_id tbody tr").click(function () {
             $("#DataTable_indi_id tbody tr").removeClass("active");
             $(this).addClass("active");
         });
         $("#DataTable_indi_id tbody tr td input").click(function (e) {
             let id_check = $(e.currentTarget).attr('id');
             console.log(id_check)


             let aux = Mx_Dtt_Indicaciones_rel.find(item => "" + item.ID_RLS_CF_IND == id_check.split('relacionado')[1]);
             console.log(aux)
             aux.CHECK = $('#' + id_check).is(':checked') ? 1 : 0;
         });
         $('#DataTable_indi_id').DataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
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
 <%------------------------------- BOTON AGREGAR -------------------------------------------%>
 <script>
     function Ajax_Agregar() {
         modal_show();
         var Data_Par = JSON.stringify({
             "ID_FONASA": id_cod_fona,
             "ARRAY_COMUNAS": Mx_Dtt_tabla_modal_indicaciones.filter(item => item.CHECK == 1).map(item => item.ID_IND)

         });
         console.log(Data_Par);
         $(".block_wait").fadeIn(500);
         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/IRIS_WEBF_AGREGA_INDICACIONES_FONASA",
             "data": Data_Par,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": function (response) {
                 var json_receiver = response.d;
                 if (json_receiver != "null") {
                     numerin = JSON.parse(json_receiver);
                     Hide_Modal();

                     Ajax_Tabla_indicaciones()

                     Ajax_Indicaciones_Relacionadas();
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
 <%------------------------------- BOTON QUITAR -------------------------------------------%>
 <script>
     function Ajax_Quitar() {
         modal_show();
         var Data_Par = JSON.stringify({
             "ARRAY_COMUNAS": Mx_Dtt_Indicaciones_rel.filter(item => item.CHECK == 1).map(item => item.ID_RLS_CF_IND)

         });

         $(".block_wait").fadeIn(500);
         $.ajax({
             "type": "POST",
             "url": "Codigos_Fonasa.aspx/IRIS_WEBF_UPDATE_REL_INDICACION_FONASA_QUITAR_RELACION",
             "data": Data_Par,
             "contentType": "application/json;  charset=utf-8",
             "dataType": "json",
             "success": function (response) {
                 var json_receiver = response.d;
                 if (json_receiver != "null") {
                     numerin = JSON.parse(json_receiver);
                     Hide_Modal();


                     Ajax_Tabla_indicaciones();
                     Ajax_Indicaciones_Relacionadas();
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
 <%------------------------------- NO SE OCUPAN, PERO LOS DEJE POR SI EN ALGUN MOMENTO SE LLEGARAN A NECESITAR --%>
 <script>
     function Ajax_Codiguin_Tabla_Relacionada() {

     }
     function Ajax_Codiguin_No_Relacionadas() {

     }
 </script>
 <%------------------------------- ESTILOS DE LA PAGINA -------------------------------------%>
 <style>
     .manito {
         cursor: pointer;
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

     .rowPrimeraFila {
         margin: 4px;
     }

     .rowSegundaFila {
         margin: 4px;
     }

     .rowBotones {
         margin: 4px;
     }

     #ddl_est {
         width: 100%;
         height: 50px;
     }

     #ddl_agr {
         width: 100%;
         height: 50px;
     }

     .check {
         width: 30px;
         height: 30px;
     }

     .papa-input {
         display: flex;
         align-content: center;
         text-align: center;
         flex-direction: row;
         justify-content: flex-start;
         align-items: center;
     }

     .border-bar {
         border-top: none;
         margin: -2px;
     }

     .btn-sq-lg {
         width: 100px !important;
         height: 100px !important;
     }

     .card-header {
         margin: -1px;
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

    <div class="container-fluid">
    <div class="card mb-3 border-bar">
        <div class="card-header bg-bar">
            <h5 class="text-center"><i class="fa fa-fw fa-info"></i>Información de Código Fonasa</h5>
        </div>
        <%------------------------------------------------ PRIMERA FILA -----------------------------------%>
        <div class="rowPrimeraFila">
            <div class="row mb-1">
                <div class="col-sm">
                    <label for="txt_cod">Código</label>
                    <input type="text" id="txt_cod" class="form-control" required="" />
                </div>
                <div class="col-sm">
                    <label for="txt_des">Descripción</label>
                    <input type="text" id="txt_des" class="form-control" required="" />
                </div>
                <div class="col-sm">
                    <label for="txtdes_cor">Desc. Corta</label>
                    <input type="text" id="txtdes_cor" class="form-control" required="" />
                </div>
                <div class="col-sm">
                    <label for="txt_ndias">N° Días</label>
                    <input type="number" id="txt_ndias" class="form-control" required="" />
                </div>
                <div class="col-sm">
                    <label for="ddl_est">Estado</label>
                    <select id="ddl_est" class="form-control"></select>
                </div>
            </div>
        </div>
        <%------------------------------------------------ SEGUNDA FILA -----------------------------------%>
        <div class="rowSegundaFila">
            <div class="row mb-3" id="div_chk">
                <div class="col-sm">
                    <label for="chk_imp_una_pag">Imp. Una Página</label>
                    <div class="form-check">
                        <label class="form-check-label">
                            <input class="form-check-input" type="checkbox" value="0" id="chk_imp_una_pag" />
                            ACTIVO
                        </label>
                    </div>
                </div>
                <div class="col-sm">
                    <label for="chk_imp_nom_est">Imp. Nom Estudio</label>
                    <div class="form-check">
                        <label class="form-check-label">
                            <input class="form-check-input" type="checkbox" value="0" id="chk_imp_nom_est" />
                            ACTIVO                   
                        </label>
                    </div>
                </div>
                <div class="col-sm">
                    <label for="chk_imp_sel_prueba">Sel. Prueba</label>
                    <div class="form-check">
                        <label class="form-check-label">
                            <input class="form-check-input" type="checkbox" value="0" id="chk_imp_sel_prueba" />
                            ACTIVO                      
                        </label>
                    </div>
                </div>
                <div class="col-sm">
                    <label for="chk_imp_parcial">Imp. Parcial</label>
                    <div class="form-check">
                        <label class="form-check-label">
                            <input class="form-check-input" type="checkbox" value="0" id="chk_imp_parcial" />
                            ACTIVO                   
                        </label>
                    </div>
                </div>
                <div class="col-sm">
                    <label for="txtcod_host">Código HOST</label>
                    <input type="text" id="txtcod_host" class="form-control" />
                </div>
                <div class="col-sm">
                    <label for="ddl_agr">Agrupación</label>
                    <select id="ddl_agr" class="form-control"></select>
                </div>
            </div>
        </div>
        <%------------------------------------------------ TABLA ------------------------------------------%>
        <div id="DataTable_Fonasa" style="width: 100%; height: 290px" class="highlights"></div>
        <hr />
        <%------------------------------------------------ BOTONES ----------------------------------------%>
        <div class="rowBotones">
            <div class="row">
                <div class="col-sm">
                    <button type="button" class="btn btn-warning btn-block" style="padding: 3px" id="btn_modal_indicaciones"><i class="fa fa-fw fa-file-text-o mr-2"></i>Indicaciones</button>
                </div>
                <div class="col-sm">
                    <button type="button" class="btn btn-warning btn-block" style="padding: 3px" id="btn_modal"><i class="fa fa-fw fa-link mr-2"></i>Asociar Estudio</button>
                </div>
                <div class="col-sm">
                    <button type="button" class="btn btn-pendiente btn-block" style="padding: 3px" id="btn_nuevo"><i class="fa fa-fw fa-eraser mr-2" aria-hidden="true"></i>Limpiar</button>
                </div>
                <div class="col-sm">
                    <button type="button" class="btn btn-primary btn-block" style="padding: 3px" id="btn_guardar"><i class="fa fa-fw fa-save mr-2"></i>Guardar</button>
                </div>
                <div class="col-sm">
                    <button type="button" class="btn btn-info btn-block" style="padding: 3px" id="btn_modificar"><i class="fa fa-fw fa-edit mr-2"></i>Modificar</button>
                </div>
                <div class="col-sm">
                    <button type="button" class="btn btn-danger btn-block" style="padding: 3px" id="btn_eliminar"><i class="fa fa-fw fa-remove mr-2"></i>Eliminar</button>
                </div>
                <div class="col-sm">
                    <button type="button" class="btn btn-success btn-block" style="padding: 3px" id="btn_Excel"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                </div>
            </div>
        </div>
    </div>
</div>
<%------------------------------------------------ MODAL PARA HACER LA COSA DE EL CODIGO FONASA Y EL ESTUDIO ----------------------------------%>
<div class="modal fade" id="eModal2" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg" style="max-width: 1200px" role="document">
        <div class="modal-content">
            <div class="modal-body">

                <h6 style="text-align: center">FONASA</h6>
                <div class="row">
                    <div class="col-sm">
                        <p for="floatingInput">CODIGO FONASA</p>
                        <input type="text" class="form-control" id="txtCodigoFonasaModal" disabled="" />
                    </div>
                    <div class="col-sm" style="grid-column: span 2">
                        <p for="floatingInput">DESCRIPCIÓN FONASA</p>
                        <input type="text" class="form-control" id="txtDescripcionFonasaModal" disabled="" />
                    </div>

                    <div class="col-md-12">
                        <hr />
                        <h6>El Código Fonasa está enlazado con el siguiente estudio:</h6>
                        <div id="Div_Tabla_Estudio_Cod_Fonasa" style="width: 100%; height: auto" class="highlights2"></div>
                    </div>
                </div>
                <h6 style="text-align: center">ESTUDIO</h6>
                <div class="row">
                    <div class="col-sm">
                        <label for="floatingInput">CODIGO ESTUDIO</label>
                        <input type="text" class="form-control" id="txtCodigoEstudioModal" disabled="" />
                    </div>
                    <div class="col-sm" style="grid-column: span 2">
                        <label for="floatingInput">DESCRIPCIÓN ESTUDIO</label>
                        <input type="text" class="form-control" id="txtDescripcionEstudioModal" disabled="" />
                    </div>
                </div>
                <hr />
                <form>
                    <div class="col-md-12">
                        <div id="Div_Tabla" style="width: 100%; height: 200px" class="highlights2"></div>
                    </div>
                </form>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-primary" id="btnVerEstudio">
                    <i class="fa-solid fa-down-left-and-up-right-to-center"></i>Ver Estudio
                </button>
                <button type="button" class="btn btn-primary" id="btnVincular">
                    <i class="fa-solid fa-down-left-and-up-right-to-center"></i>Vincular
                </button>
                <button type="button" class="btn btn-danger" id="btnDesvincular">
                    <i class="fa-solid fa-up-right-and-down-left-from-center"></i>Desvincular
                </button>
                <button type="button" class="btn btn-secondary" id="btnSalir" data-bs-dismiss="modal">
                    Salir
                </button>

            </div>
        </div>
    </div>
</div>
<%------------------------------------------------ MODAL DE INDICACIONES --%>
<div class="modal fade" id="eModal3" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg" style="max-width: 1400px" role="document">
        <div class="modal-content">
            <div class="modal-body">


                <h6 style="text-align: center">Asociar Indicaciones Medicas</h6>
                <div class="row">
                    <div class="col-sm">
                        <p for="floatingInput">CODIGO FONASA</p>
                        <input type="text" class="form-control" id="txtCodigoFonasaModal2" disabled="" />
                    </div>
                    <div class="col-sm" style="grid-column: span 2">
                        <p for="floatingInput">DESCRIPCIÓN FONASA</p>
                        <input type="text" class="form-control" id="txtDescripcionFonasaModal2" disabled="" />
                    </div>
                </div>

                <hr />
                <div class="row">
                    <div class="col-lg-5 mb-3" style="overflow: auto; height: 55vh; width: 100%" id="Div_Tabla_indi">
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
                    <div class="col-lg-5 mb-3" style="overflow: auto; height: 55vh;" id="Div_Tabla_Indicaciones_Rel">
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


</asp:Content>
