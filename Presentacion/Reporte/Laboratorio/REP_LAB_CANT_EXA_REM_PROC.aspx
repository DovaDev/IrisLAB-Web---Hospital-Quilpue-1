<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="REP_LAB_CANT_EXA_REM_PROC.aspx.vb" Inherits="Presentacion.REP_LAB_CANT_EXA_REM_PROC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
        <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true"%>
    
    <%-- Botones --%>
    <link href="../../../../Resourses/Style/Buttons.css" rel="stylesheet" />
        <%--Esto es para que funcione el gráfico--%>
    <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>
    <script src="/js/Custom_modal.js"></script>
    <script src="/js/Custom_Objects.js"></script>
    <script src="REP_LAB_CANT_EXA_REM_PROC.js?version=1"></script>
    <%-- Declaración de Eventos --%>
    <script>

    </script>
     <%-- Datepickers --%>
    <script>
        $(document).ready(function () {



            var Date_Now = function () {
                //Obtener valores
                var obj_date = new Date();
                var dd = parseInt(obj_date.getDate());
                var mm = parseInt(obj_date.getMonth()) + 1;
                var yy = parseInt(obj_date.getFullYear());
                if (dd < 10) { dd = "0" + dd; }
                if (mm < 10) { mm = "0" + mm; }
                return String(dd + "/" + mm + "/" + yy);
            };
            $('#fecha1').datetimepicker(
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
            $('#fecha2').datetimepicker(
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
            $("#fecha1 input").val(dateNow);
            $("#fecha2 input").val(dateNow);
            //$("#TxtDate_01").val(Date_Now);
            //$("#TxtDate_02").val(Date_Now);
        });
    </script>
 
     <%-- CSS Personalizado --%>
    <style>
        #DataTable thead, #DataTable tfoot, #Table_T thead {
            background-color: #28a745;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="card mb-3 border-bar">
        <div class="card-header bg-bar">
            <h5>REM Procedencias</h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <label for="fecha">Desde:</label>
                    <div class='input-group date' id='fecha1'>
                        <input type='text' id="TxtDate_01" class="form-control" readonly="true" placeholder="Desde..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label for="fecha">Hasta:</label>
                    <div class='input-group date' id='fecha2'>
                        <input type='text' id="TxtDate_02" class="form-control" readonly="true" placeholder="Hasta..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <%--<div class="col-lg">
                    <label for="DdlExamen">Area-Sección:</label>
                    <select id="DdlExamen" class="form-control"></select>
                </div>--%>
                <%--  <div class="col-lg-1">
                   
                </div>
                <div class="col-lg-1">
                   
                </div>--%>
            </div>
            <div class="row">
                <div class="col-lg">
                    <button id="Btn_Search" type="button" class="btn btn-block btn-buscar btn-sm"><i class="fa fa-fw fa-search mr-2"></i> Buscar</button>
                </div>
                <div id="Div_Excel_DesAgrupado" class="col-lg">
                    <button id="Btn_Export" type="button" class="btn btn-block btn-success btn-sm"><i class="fa fa-fw fa-file-excel-o mr-2"></i> Excel</button>
                </div>
                <div id="Div_Excel_Agrupado" class="col-lg">
                    <button id="Btn_Export_DesAgrupar" type="button" class="btn btn-block btn-success btn-sm"><i class="fa fa-fw fa-file-excel-o mr-2"></i> Excel A</button>
                </div>
 <%--               <div id="Div_Agrupar" class="col-lg">
                    <button id="Btn_Agrupar" type="button" class="btn btn-block btn-warning btn-sm"><i class="fa fa-fw fa-hand-grab-o mr-2"></i> Agrupar</button>
                </div>--%>
                <div id="Div_DesAgrupar" class="col-lg">
                    <button id="Btn_DesAgrupar" type="button" class="btn btn-block btn-warning btn-sm"><i class="fa fa-fw fa-arrow-circle-down mr-2"></i> Desagrupar</button>
                </div>
                <div class="col-lg">
                    <button type="button" id="Btn_Modal_Email" class="btn btn-block btn-success btn-sm">
                        <i class="fa fa-mail-forward"></i>
                        <span>Enviar Email</span>
                    </button>
                </div>
            </div>
        </div>
    </div>
    <div class="card p-3 border-bar">
        <div class-="row">
            <ul class="nav nav-tabs" id="myTab" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active" id="tab1-tab" data-toggle="tab" href="#tab1" role="tab" aria-controls="tab1" aria-selected="true">REM</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="tab2-tab" data-toggle="tab" href="#tab2" role="tab" aria-controls="tab2" aria-selected="false">FROTIS</a>
                </li>
            </ul>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="row mb-3">
                    <div class="col-lg">
                        <h5>Listado de Exámenes</h5>
                        <div class="tab-content" id="tab_content">
                             <div class="tab-pane fade show active" id="tab1" role="tabpanel" aria-labelledby="tab1-tab">
                                <div id="Div_Tabla_Data" class="table table-hover table-striped table-iris" style="overflow: auto"></div>
                            </div>
                            <div class="tab-pane fade" id="tab2" role="tabpanel" aria-labelledby="tab2-tab">
                                <div id="Div_Tabla_Frotis" class="table table-hover table-striped table-iris" style="overflow: auto"></div>
    <%--                            <table id="Tabla_Frotis" class="table table-hover table-striped table-iris" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th class="text-center text-white">#</th>
                                        <th class="text-center text-white">Código Fonasa</th>
                                        <th class="text-white">Examen</th>
                                        <th class="text-center text-white">Cantidad Exámenes</th>
                                        <th class="text-center text-white">CAE</th>
                                        <th class="text-center text-white">USM HDIURNO</th>
                                        <th class="text-center text-white">PERSONAL</th>
                                        <th class="text-center text-white">MQ1</th>
                                        <th class="text-center text-white">MQ2</th>
                                        <th class="text-center text-white">MQ3</th>
                                        <th class="text-center text-white">UAPQ PABELLON</th>
                                        <th class="text-center text-white">PEDIATRIA</th>
                                        <th class="text-center text-white">NEONATOLOGIA</th>
                                        <th class="text-center text-white">UPC</th>
                                        <th class="text-center text-white">UCI A</th>
                                        <th class="text-center text-white">UTI</th>
                                        <th class="text-center text-white">MATERNIDAD</th>
                                        <th class="text-center text-white">CMA</th>
                                        <th class="text-center text-white">HOSP DOCIMI</th>
                                        <th class="text-center text-white">UEA HOSP</th>
                                        <th class="text-center text-white">UEA</th>
                                        <th class="text-center text-white">UEI</th>
                                        <th class="text-center text-white">SAUD</th>
                                        <th class="text-center text-white">UEGO</th>
                                        <th class="text-center text-white">ANATOMIA PATO</th>
                                        <th class="text-center text-white">IMAGENOLOGIA</th>
                                        <th class="text-center text-white">CESFAM IVAN MAN</th>
                                        <th class="text-center text-white">CESFAM AV AC</th>
                                        <th class="text-center text-white">CESFAM QUILPUE</th>
                                        <th class="text-center text-white">CESFAM BELLOTO</th>
                                        <th class="text-center text-white">CONS POMPEYA</th>
                                        <th class="text-center text-white">CECOSF RETIRO</th>
                                        <th class="text-center text-white">CONS BELLOTO</th>
                                        <th class="text-center text-white">CESFAM VILLA AL</th>
                                        <th class="text-center text-white">CESFAM AMERICAS</th>
                                        <th class="text-center text-white">CONS EDUARDO FREI</th>
                                        <th class="text-center text-white">CESFAM JUAN BT</th>
                                        <th class="text-center text-white">CONS AGUILAS</th>
                                        <th class="text-center text-white">SAPU FREI</th>
                                        <th class="text-center text-white">CESFAM LIMACHE</th>
                                        <th class="text-center text-white">CESFAM OLMUE</th>
                                        <th class="text-center text-white">APS CABILDO</th>
                                        <th class="text-center text-white">APS HIJUELAS</th>
                                        <th class="text-center text-white">APS CALERA</th>
                                        <th class="text-center text-white">APS LIGUA</th>
                                        <th class="text-center text-white">APS NOGALES</th>
                                        <th class="text-center text-white">APS PETORCA</th>
                                        <th class="text-center text-white">HOSP LIMACHE</th>
                                        <th class="text-center text-white">HOSP GERIATRICO LMCHE</th>
                                        <th class="text-center text-white">HOSP MODULAR LMCHE</th>
                                        <th class="text-center text-white">HOSP PENBLANCA</th>
                                        <th class="text-center text-white">HOSP GUSTAVO FRICKE</th>
                                        <th class="text-center text-white">HOSP CALERA</th>
                                        <th class="text-center text-white">HOSP PETORCA</th>
                                        <th class="text-center text-white">HOSP QUILLOTA</th>
                                        <th class="text-center text-white">HOSP CABILDO</th>
                                        <th class="text-center text-white">HOSP LIGUA</th>
                                        <th class="text-center text-white">HOSP QUINTERO</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>--%>
                            </div>
                        </div>
                </div>
              <%--  <div class="row">
                    <div class="col-lg">
                        <h5>Totales</h5>
                        <div id="Div_Tabla_02" class="table table-hover table-striped table-iris"></div>
                    </div>
                </div>--%>
            </div>
        </div>
        <%--<div class="row">
            <div class="col-lg-12">
                <h5>Gráfico</h5>
                <div id="Summary_Graph"></div>
            </div>
        </div>--%>
    </div>

        <div id="mdlExcel" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Exportar</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">
                        <i class="fa fa-check" aria-hidden="true"></i>
                        <span>Aceptar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>
            <div id="mdl_correo" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Enviar</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                   <p class="text-justify">Por favor ingrese un correo electrónico en la siguiente casilla para enviar. Cuando el correo sea válido se habilitará el botón enviar:</p>
                   <input type="text" id="txt_email" class="form-control" autocomplete="on" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">
                        <i class="fa fa-times" aria-hidden="true"></i>
                        <span>Cancelar</span>
                    </button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal" disabled="disabled" id="Btn_Email">
                        <i class="fa fa-send" aria-hidden="true"></i>
                        <span>Enviar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

