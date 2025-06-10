<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="TipoMuestraSangre.aspx.vb" Inherits="Presentacion.TipoMuestraSangre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <script>
      let IDDDDDDD = 0;
      $(document).ready(function () {
          $(".block_wait").fadeOut(0);
          Ajax_Ddl_Mantenedor();
          Ajax_Tabla();

          //BTN LIMPIAR
          $("#Btn_Limpiar").click(function () {
              Ajax_Limpiar();
              accion = 1
              alerta_Proc_Correctos();
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
                      alerta_Proc_Correctos();
                      despintarCasillas();
                  }
              }
          });
          //BTN ELIMINAR
          $("#Btn_Eliminar").click(function () {
              if (IDDDDDDD == 0) {

                  $("#mError_AAH h4").text("Error");
                  $("#mError_AAH button").attr("class", "btn btn-danger");
                  $("#mError_AAH p").text("Por favor, complete los campos solicitados.");
                  $("#mError_AAH").modal();

              } else {

                  Ajax_Delete();
                  accion = 4
                  alerta_Proc_Correctos();
                  despintarCasillas();
                  $("#Btn_Modificar").attr("disabled", true);
                  $("#Btn_Eliminar").attr("disabled", true);

              }
          });
          //BTN GUARDAR
          $("#Btn_Guardar").click(function () {
              if (validar() === 3) {
                  Ajax_Guardar();
                  accion = 2
                  alerta_Proc_Correctos();
                  despintarCasillas();
                  $("#Btn_Guardar").attr("disabled", true);
                  $("#Btn_Modificar").attr("disabled", true);
                  $("#Btn_Eliminar").attr("disabled", true);

              } else {
                  $("#mError_AAH h4").text("Error");
                  $("#mError_AAH button").attr("class", "btn btn-danger");
                  $("#mError_AAH p").text("Por favor, complete los campos solicitados.");
                  $("#mError_AAH").modal();
              }
          });
          //BTN EXCEL
          $("#Btn_Excel").click(function () {
              Ajax_Excel();
              accion = 5
              alerta_Proc_Correctos();
              Ajax_Limpiar();
          });
          $("#Btn_Guardar").attr("disabled", false);
          $("#Btn_Modificar").attr("disabled", true);
          $("#Btn_Eliminar").attr("disabled", true);
      });
  </script>
<%-------------------------- FUNCION PARA MOSTRAR UN ALERTA DE LOS PROCESOS HECHOS CORRECTAMENTE ---------%>
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
<%--------------------------------------------- FUNCION PARA VALIDAR LOS CAMPOS VACIOS -------------------%>
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
<%--------------------------------------------- FUNCION PARA PINTAR LOS INPUTS ---------------------------%>
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
<%--------------------------------------------- FUNCION PARA DESPINTAR LOS INPUTS ------------------------%>
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
<%--------------------------------------------- AJAX_CODIGUIN --------------------------------------------%>
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
<%--------------------------------------------- DDL ESTADO MANTENEDOR-------------------------------------%>
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
              "url": "TipoMuestraSangre.aspx/IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR",
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
      //Llenar DropDownList DE BANCO /ACTIVO/DESACTIVADO
      function Fill_Ddl_Mantenedor() {
          $("#Ddl_Mantenedor").empty();
          $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#Ddl_Mantenedor");
          for (y = 0; y < Mx_Dtt_Mantenedor.length; ++y) {
              $("<option>", {
                  "value": Mx_Dtt_Mantenedor[y].ID_ESTADO
              }).text(Mx_Dtt_Mantenedor[y].EST_DESCRIPCION).appendTo("#Ddl_Mantenedor");
          }
      };
  </script>
<%--------------------------------------------- BUSCAR DATOS DE LA TABLA ---------------------------------%>
<script>
      var Mx_Dtt = [
          {

              "ID_MUESTRA_SANGRE": 0,
              "MUESTRA_SANGRE_COD": 0,
              "MUESTRA_SANGRE_DESC": 0,
              "ID_ESTADO": 0
          }
      ];
      function Ajax_Tabla() {
          modal_show();

          $(".block_wait").fadeIn(500);
          $.ajax({
              "type": "POST",
              "url": "TipoMuestraSangre.aspx/IRIS_WEBF_BUSCA_MUESTRA_SANGRE",
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
      }
      //--------------------------------------------------- CREA LA TABLA -------------------------------------------|
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
                      "onclick": `Ajax_Codiguin("` + Mx_Dtt[i].MUESTRA_SANGRE_COD + `","` + Mx_Dtt[i].MUESTRA_SANGRE_DESC + `","` + Mx_Dtt[i].ID_ESTADO + `","` + Mx_Dtt[i].ID_MUESTRA_SANGRE + `")`,
                      "class": "manito"
                  }).append(
                      $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                      $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].MUESTRA_SANGRE_COD),
                      $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].MUESTRA_SANGRE_DESC),
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
  <%--------------------------------------------- GRABA ----------------------------------------------------%>
  <script>
      var numerin = 0
      function Ajax_Guardar() {
          modal_show();
          var Data_Par = JSON.stringify({
              "MUESTRA_SANGRE_COD": $("#txtCod").val(),
              "MUESTRA_SANGRE_DESC": $("#txtDesc").val(),
              "ID_ESTADO": $("#Ddl_Mantenedor").val()
          });

          $(".block_wait").fadeIn(500);
          $.ajax({
              "type": "POST",
              "url": "TipoMuestraSangre.aspx/IRIS_WEBF_GRABA_TP_DE_MUESTRA_SANGRE",
              "data": Data_Par,
              "contentType": "application/json;  charset=utf-8",
              "dataType": "json",
              "success": function (response) {
                  var json_receiver = response.d;
                  if (json_receiver != "null") {
                      numerin = JSON.parse(json_receiver);
                      Hide_Modal();

                      $("#txtCod").val("");
                      $("#txtDesc").val("");
                      Ajax_Tabla();
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
      <%--------------------------------------------- UPDATE ---------------------------------------------------%>
  <script>

      var numerin = 0
      function Ajax_Update() {

          modal_show();

          var Data_Par = JSON.stringify({
              "ID_MUESTRA_SANGRE": IDDDDDDD,
              "MUESTRA_SANGRE_COD": $("#txtCod").val(),
              "MUESTRA_SANGRE_DESC": $("#txtDesc").val(),
              "ID_ESTADO": $("#Ddl_Mantenedor").val()
          });

          $(".block_wait").fadeIn(500);
          $.ajax({
              "type": "POST",
              "url": "TipoMuestraSangre.aspx/IRIS_WEBF_UPDATE_TP_MUESTRA_SANGRE",
              "data": Data_Par,
              "contentType": "application/json;  charset=utf-8",
              "dataType": "json",
              "success": function (response) {
                  var json_receiver = response.d;
                  if (json_receiver != "null") {
                      numerin = JSON.parse(json_receiver);
                      Hide_Modal();

                      $("#txtCod").val("");
                      $("#txtDesc").val("");
                      Ajax_Tabla();
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
      <%--------------------------------------------- DELETE ---------------------------------------------------%>
  <script>

      var numerin = 0
      function Ajax_Delete() {
          modal_show();
          var Data_Par = JSON.stringify({
              "ID_MUESTRA_SANGRE": IDDDDDDD,
              "MUESTRA_SANGRE_COD": $("#txtCod").val(),
              "MUESTRA_SANGRE_DESC": $("#txtDesc").val(),
              "ID_ESTADO": 2
          });
          $(".block_wait").fadeIn(500);
          $.ajax({
              "type": "POST",
              "url": "TipoMuestraSangre.aspx/IRIS_WEBF_UPDATE_TP_MUESTRA_SANGRE",
              "data": Data_Par,
              "contentType": "application/json;  charset=utf-8",
              "dataType": "json",
              "success": function (response) {
                  var json_receiver = response.d;
                  if (json_receiver != "null") {
                      numerin = JSON.parse(json_receiver);
                      Hide_Modal();

                      $("#txtCod").val("");
                      $("#txtDesc").val("");
                      $("#Ddl_Mantenedor").val(0)
                      Ajax_Tabla();
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
        <%--------------------------------------------- LIMPIAR --------------------------------------------------%>
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
  <%--------------------------------------------- EXCEL ----------------------------------------------------%>
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
              "url": "TipoMuestraSangre.aspx/Excel",
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
<%--------------------------------------------- ESTILOS DE LA PAGINA -------------------------------------%>
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
<div class="container-fluid">
    <%------------------------------------------------------TÍTULO, TEXTBOX Y BOTONES-----------------------------------------%>
    <div class="row">
        <div class="col-lg">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar">
                    <h5 style="text-align: center; padding: 5px;">
                        <i class="fa fa-info"></i>
                         Tipo de Muestra Sangre 
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
                        <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i>Lista de derivaciones</h5>
                        <div id="Div_Tabla" style="width: 100%; height: 340px;" class="highlights"></div>
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
                        <div class="col-md">
                            <button id="Btn_Excel" class="btn btn-success btn-block" style="padding: 3px;" type="submit">Excel <i class="fa fa-eject" aria-hidden="true"></i></button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


</asp:Content>
