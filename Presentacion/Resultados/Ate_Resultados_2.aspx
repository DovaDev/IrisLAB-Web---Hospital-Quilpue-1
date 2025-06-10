<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Ate_Resultados_2.aspx.vb" Inherits="Presentacion.Ate_Resultados_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%@ OutputCache Location="None" NoStore="true" %>

    <script src="../js/HighCharts.js"></script>
    <script src="../js/HighC_Exporting.js"></script>

    <script src="/js/WebForm.js"></script>
    <script src="/js/math.js"></script>

    <script src="Ate_Resultados_2.js?version=<%= DateTime.Now.ToString() %>" type="module"></script>
    <script src="Editar_Paciente_Visor.js?version=<%= DateTime.Now.ToString() %>"></script>
    <script src="AgregarQuitarExamenVisor.js?version=<%= DateTime.Now.ToString() %>" type="module"></script>
    <script src="../js/Galletas.js"></script>
    <link href="Ate_Resultados.css" rel="stylesheet" />
    <script src="../js/Deep-Copy.js"></script>
    <script src="../js/Custom_modal.js"></script>
    <script src="../js/colResizable-1.6.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <style>
        /*#region SWEET ALERT*/
        .swal-wide {
            width: 850px !important;
        }
        /*#endregion*/
        .v_pink {
            background-color: #fb91de !important;
        }

        .v_green {
            background-color: #c0ffc0 !important;
        }

        .v_blue {
            background-color: #0000ff !important;
        }

        .grid-informacion-atencion {
            align-self: center;
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(75px, 1fr));
            gap: 2px;
            align-items: center;
            grid-auto-flow: dense;
        }

        .grid-editar-paciente {
            align-self: center;
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(100px, 1fr));
            gap: 1rem;
            align-items: center;
            grid-auto-flow: dense;
            place-content: center;
        }

        .grid-botones-footer {
            align-self: center;
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(100px, 1fr));
            gap: 1rem;
            align-items: center;
            grid-auto-flow: dense;
            place-content: center;
        }

        .bg-color-info-ate {
            background-color: white !important;
        }

        tr {
            height: 30px
        }

        th, td {
            white-space: nowrap;
        }

        div.dataTables_wrapper {
            margin: 0 auto;
        }


        table.dataTable tbody th, table.dataTable tbody td {
            padding: 0px 4px !important;
        }

        .selectSize {
            /*height:calc(1.89rem + 1px);*/
            height: 1000px;
        }

        .negrita {
            font-weight: 700;
        }

        .borderRound {
            border-radius: .25rem;
        }

        .carlos_sama {
            width: 5vw;
        }

        .dark_text {
            font-weight: 700;
        }

        .alertas {
            margin-top: 180px;
            text-align: center;
        }

        .manito {
            cursor: pointer;
        }

        .manitos2 {
            cursor: pointer;
        }

        .textoReducido {
            font-size: 11px;
        }

        .textDerecho {
            text-align: right;
        }

        .ancho-columna {
            height: 10%;
            padding: -35px;
        }

        .highlights {
            width: 100%;
            /*height: 300px; /* Ancho y alto fijo */ 
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .highlights2 {
            width: 100%;
            height: 300px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .topbuttom {
            display: block;
            height: 80px;
            width: 100%;
        }

        .topbuttom2 {
            display: block;
            height: 80px;
        }

        .textbot {
            display: block;
            height: 22px;
            width: 100%;
        }

        .textbotLeft {
            display: block;
            height: 28px;
            width: 100%;
        }

        .cabzera {
            background: #46963f;
            color: white;
        }

        .espera {
            background: #c7ff00;
        }

        .atendido {
            background: #1fc12c;
            color: white;
        }

        #XXXXXXXX {
            z-index: 9000;
            width: 100%;
            position: fixed;
            left: 0px;
            top: 0px;
            display: flex;
            display: -webkit-flex;
            flex-flow: row nowrap;
            justify-content: center;
            color: #444;
            border: 0;
            border-radius: 2px;
            text-decoration: none;
            transition: opacity 0.2s ease-out;
            opacity: 0;
            margin-top: 60px;
        }

            #XXXXXXXX div {
                font-size: 18px;
                border: none;
                outline: none;
                background-color: #014B5D;
                color: white;
                padding: 8px;
                border-radius: 4px;
                font-size: 15px;
            }



            #XXXXXXXX.show {
                opacity: 1;
            }

        #content {
            height: 2000px;
        }

        @media screen and (min-width: 558px) {
            .topbuttom2 {
                width: 100%;
            }
        }


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

        .rechazado {
            background-color: #ffd5d5 !important;
        }

        .sin-recep {
            background-color: #dcbeff !important;
        }

        .sin-recep-sec {
            background-color: #bedcff !important;
        }

        .cincuentamilzindex {
            z-index: 50000 !important;
        }

        .modal-custom {
            max-width: 90%;          
        }
        /*desde aki param abajo es la traza*/
        /*.modal-custom .modal-content {
            height: 90vh;
        }*/

        #trazabilidadFrame {
            width: 100%;
            height: calc(80vh - 150px); /* Ajusta la altura según el espacio que ocupa el header y footer del modal */
        }

        .custom-close {
            font-size: 3rem; /* Tamaño de la "X" */
            color: #000; /* Color de la "X" */
        }
        .custom-close span {
            display: inline-block;
            width: 1em;
            height: 1em;
            line-height: 1em;
        }
        #trazabilidadModalLabel {
            font-size: 24px; /* Ajusta el tamaño del título */
            text-align: center; /* Centra el título */
            margin: 0;
        }
        
    </style>



<!-- Modal de la traza oee -->

<div class="modal fade" id="trazabilidadModal" tabindex="-1" role="dialog" aria-labelledby="trazabilidadModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-custom" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="trazabilidadModalLabel">Trazabilidad de Atención</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <iframe id="trazabilidadFrame" frameborder="0"></iframe>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
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

    <!-- Modal -->
    <div id="mError_AAH_Consulta" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Atención</h4>
                </div>
                <div class="modal-body">
                    <p>Se detecta determinación ya validada, se recargará visor de resultados.</p>
                </div>
                <div class="modal-footer">
                    <%--<button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>--%>
                    <button type="button" class="btn btn-success" data-dismiss="modal" id="btn_consulta">Cerrar/Recargar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal -->
    <div id="mError_AAH_Trigliceridos" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Atención</h4>
                </div>
                <div class="modal-body">
                    <p>Triglicéridos mayor a 400, se anula fórmula.</p>
                </div>
                <div class="modal-footer">
                    <%--<button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>--%>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div id="mdls"></div>


    <div class="row">
        <div class="col-md-12">
            <div class="card mb-2 border-bar">
                <div class="card-header bg-bar">
                    <h5 class="m-0" id="title_Det_Ate">Detalle Atención</h5>

                    <div class="grid-informacion-atencion">

                        <div style="grid-column: span 3">
                            <label for="txtNombrePaciente">Paciente:</label>
                            <input id="txtNombrePaciente" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>
                        <div style="grid-column: span 2">
                            <label for="txtRutDni">RUT/DNI:</label>
                            <input id="txtRutDni" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>
                        <div style="grid-column: span 2">
                            <label for="txtFechaAtencion">Fecha Atención:</label>
                            <input id="txtFechaAtencion" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>
                        <div style="grid-column: span 2">
                            <label for="txtEdad">Edad:</label>
                            <input id="txtEdad" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>
                        <div style="grid-column: span 2">
                            <label for="txtSexo">Sexo:</label>
                            <input id="txtSexo" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>
                        <div style="grid-column: span 2">
                            <label for="txtFUR">FUR:</label>
                            <input id="txtFUR" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>
                        <div style="grid-column: span 2" hidden="">
                            <label for="txtIngresadoPor">Ingresado por:</label>
                            <input id="txtIngresadoPor" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>
                        <div style="grid-column: span 2" hidden="">
                            <label for="txtCantidadAtenciones">N° Atenciones:</label>
                            <input id="txtCantidadAtenciones" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>
                        <div style="grid-column: span 2" hidden="">
                            <label for="txtCantidadExamenes">N° Exámenes:</label>
                            <input id="txtCantidadExamenes" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>
                        <div style="grid-column: span 2">
                            <label for="txtOrdenDeAtención">Orden:</label>
                            <input id="txtOrdenDeAtención" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>
                        
                        
                        
                        <div style="grid-column: span 1" hidden="">
                            <label for="txtNumeroAvis">N° RAYEN:</label>
                            <input id="txtNumeroAvis" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>
                        <div style="grid-column: span 2" class="accu-chek-input" hidden="">
                            <label for="txtAccuChekBasal">Accu-Chek Basal:</label>
                            <input id="txtAccuChekBasal" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>
                        <div style="grid-column: span 2" class="accu-chek-input" hidden="">
                            <label for="txtAccuChek120">Accu-Chek 120:</label>
                            <input id="txtAccuChek120" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>
                        <div style="grid-column: span 2">
                            <label for="txtOrdenDeAtención">Peso:</label>
                            <input id="txtPeso" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>
                        <div style="grid-column: span 2">
                            <label for="txtOrdenDeAtención">Talla:</label>
                            <input id="txtTalla" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>
                        
                        <div style="grid-column: span 3">
                            <label for="txtOrdenDeAtención">HGT (mg/dL):</label>
                            <input id="txtHgt" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>
                     <%--   <div style="grid-column: span 5">
                            <label for="txtObsAtencion">Observación Atención:</label>
                            <input id="txtObsAtencion" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>--%>
                        <div style="grid-column: span 5">
                            <label for="txtObsTomaMuestra">Observación Atención:</label>
                            <input id="txtObsTomaMuestra" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>

                        <div style="grid-column: span 5">
                            <label for="txtObsPermanente">Observación Permanente:</label>
                            <input id="txtObsPermanente" class="form-control form-control-sm textoReducido bg-color-info-ate" type="text" disabled="" />
                        </div>

                    </div>

                </div>
                <div class="form-header card-body pl-2 pr-2 pt-1 pb-1">
                    <div class="row pl-2 pr-2">
                        <div class="col-lg">
                            <label>N° Ate:</label>

                            <input type="checkbox" id="Chk_Pendientes" name="Chk_Filther" data-text="Pend:" data-value="8" />

                            <%--<input type="checkbox" id="Chk_Pendientes_R" name="Chk_Filther" data-text="Res:" data-value="7" hidden/>--%>

                            <span></span>
                            <div class="input-group mb-2">
                                <input type="text" id="Txt_NumAte" class="form-control form-control-sm" style="font-size: 0.9rem !important" />
                                <div class="input-group-btn">
                                    <button type="button" class="btn btn-primary btn-sm" id="Btn_AteL">
                                        <i class="fa fa-chevron-left" aria-hidden="true"></i>
                                    </button>
                                    <button type="button" class="btn btn-primary btn-sm" id="Btn_AteR">
                                        <i class="fa fa-chevron-right" aria-hidden="true"></i>
                                    </button>
                                </div>
                            </div>

                            

                                <div class="btn-group" role="group">
                                    <button id="btnGroupDrop1" type="button" class="btn btn-sm btn-info dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="width:100%">
                                        <i class="fa fa-bars"></i>
                                        Opciones
                                    </button>
                                    <div id="dropdown-botones" class="dropdown-menu" aria-labelledby="btnGroupDrop1" style="padding:1rem; gap:1rem;">


                                        <button type="button" class="btn  btn-primary btn-sm" data-toggle="modal" data-target="#modal-atenciones" style="width: 100%">
                                            <i class="fa fa-search"></i>
                                            <span>Atenciones</span>
                                        </button>
                                        <button type="button" class="btn  btn-warning btn-sm" id="btnTrazabilidadAtencion" style="width: 100%">
                                            <i class="fa fa-search"></i>
                                            <span>Trazabilidad</span>
                                        </button>
                                        <button type="button" class="btn  btn-limpiar btn-sm" id="btn-modal-paciente" style="width: 100%" hidden="">
                                            <i class="fa fa-user"></i>
                                            <span>Paciente</span>
                                        </button>
                                        <button id="Btn_Obs_Exam" type="button" class="btn btn-light btn-print btn-sm" style="width: 100%">
                                            <i class="fa fa-list"></i>
                                            <span>Determinaciones</span>
                                        </button>
                                        <button id="btn-pendientes" type="button" class="btn btn-secondary btn-sm" style="width: 100%">
                                            <i class="fa fa-list"></i>
                                            <span>Pendientes</span>
                                        </button>
                                        <button id="btn-agregar-quitar-examenes" type="button" class="btn btn-danger btn-sm" style="width: 100%">
                                            <i class="fa fa-plus"></i>
                                            /
                                            <i class="fa fa-minus"></i>
                                            <span>&nbsp;Exámenes</span>
                                        </button>

                                        
                                        <button id="Btn_P_Anti" type="button" class="btn  btn-limpiar btn-sm" style="width: 100%">
                                            <i class="fa fa-flask"></i>
                                            <span>Panel Antibiograma</span>
                                        </button>
                                        
                                        <button id="btn-quitar-estado" type="button" class="btn btn-light btn-sm" style="width: 100%">
                                            <i class="fa fa-chain-broken"></i>
                                            <span>Quitar Estado</span>
                                        </button>
                                        <button id="btn-critico-manual" type="button" class="btn btn-dark btn-sm" style="width: 100%">
                                            <i class="fa fa-exclamation"></i>
                                            <span>Crítico Manual</span>
                                        </button>



                                    </div>
                                </div>


                        </div>
                        <div class="col-lg">
                            <div class="form-group mb-2" id="chk_Nombre">
                                <input type="checkbox" name="Chk_Filther" data-text="Paciente:" data-value="6" />
                                <div class="form-group mb-2">
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary btn-sm btn-block mt-0" id="Btn_Hist">
                                            <i class="fa fa-search" aria-hidden="true"></i>
                                            <span>Ver Hist.</span>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg">
                            <div class="form-group  mb-2">
                                <input type="checkbox" name="Chk_Filther" data-text="Procedencia:" data-value="0" />
                                <select id="Sel_Proc" class="form-control form-control-sm">
                                </select>
                            </div>
                        </div>
                        <div class="col-lg">
                            <div class="form-group  mb-2">
                                <input type="checkbox" name="Chk_Filther" data-text="Previsión:" data-value="1" />
                                <select id="Sel_Prev" class="form-control form-control-sm">
                                </select>
                            </div>
                        </div>

                        <div class="col-lg" hidden>
                            <div class="form-group mb-2">
                                <input type="checkbox" name="Chk_Filther" data-text="Programa:" data-value="2" />
                                <select id="Sel_Prog" class="form-control form-control-sm">
                                </select>
                            </div>
                        </div>
                       <%--<div class="col-lg">
                            <div class="form-group mb-2">
                                <input type="checkbox" id="cb-area"/>
                                <label for="cb-area">Área:</label>
                                <select id="slct-area-main" class="form-control form-control-sm"></select>
                            </div>
                        </div>
                        <div class="col-lg">
                            <div class="form-group mb-2">
                                <input type="checkbox" id="cb-seccion"/>
                                <label for="cb-seccion">Sección:</label>
                                <select id="slct-seccion-main" class="form-control form-control-sm"></select>
                            </div>
                        </div>--%>

                        <div class="col-lg">
                            <div class="form-group mb-2">
                                <input type="checkbox" id="cb-rls-area-seccion"/>
                                <label for="cb-rls-area-seccion">Área-Sección:</label>
                                <select id="slct-rls-area-seccion-main" class="form-control form-control-sm"></select>
                            </div>
                        </div>


                        <div class="col-lg">
                            <div class="form-group mb-2">
                                <input type="checkbox" id="cb-examen"/>
                                <label for="cb-examen">Examen:</label>
                                <select id="slct-examen-main" class="form-control form-control-sm"></select>

                                <button type="button" class="btn btn-info btn-sm btn-block mt-1" id="Btn_PDF">
                                    <i class="fa fa-search" aria-hidden="true"></i>
                                    <span>V. Previa</span>
                                </button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <div class="card card-last border-bar">
                <div class="card-header bg-bar">
                    <h6 class="m-0 text-left" id="title_Det_Ate_2" style="font-weight: 600;">Resultados Atención</h6>
                </div>
                <div class="card-body pl-0 pr-0" id="Dtt_Exam">
                </div>
            </div>
        </div>











    </div>

    <div style="padding-top: 6rem"></div>
    <!-- Botones lado inferior -->
    <div class="float_buttons border-bar grid-botones-footer" style="padding: 0.5rem">
        


        <button id="Btn_Audit" type="button" class="btn  btn-primary btn-sm">
            <i class="fa fa-calendar"></i>
            <span>Auditoría</span>
        </button>
        <button id="Btn_Graph" type="button" class="btn  btn-warning btn-sm">
            <i class="fa fa-line-chart"></i>
            <span>Graficar</span>
        </button>
        <button id="Btn_Validar" type="button" class="btn  btn-success btn-sm" disabled="disabled">
            <i class="fa fa-check"></i>
            <span>Validar</span>
        </button>
        <button id="Btn_Desvalidar" type="button" class="btn  btn-danger btn-sm" disabled="disabled">
            <i class="fa fa-times"></i>
            <span>Desvalidar</span>
        </button>
        <button id="Btn_Print" type="button" class="btn  btn-success btn-sm">
            <i class="fa fa-print"></i>
            <span>Imprimir</span>
        </button>
        <button id="Btn_Crit" type="button" class="btn  btn-limpiar btn-sm" hidden="">
            <i class="fa fa-exclamation-triangle"></i>
            <span>Crit. Manual</span>
        </button>
        
    </div>

    <!-- Modales -->
    <div id="mdlLoading" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Cargando</h4>
                </div>
                <div class="modal-body pt-6 pb-6 text-center">
                    <i class="fa fa-spinner fa-pulse fa-5x fa-fw"></i>
                </div>
            </div>
        </div>
    </div>

    <div id="mdlError" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">ERROR</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                    <div>
                        <strong>Tipo de Error: </strong>
                        <p id="mdlTxt_Type"></p>
                        <br />
                    </div>
                    <div>
                        <strong>Descripción: </strong>
                        <p id="mdlTxt_Descr"></p>
                        <br />
                    </div>
                    <div>
                        <strong>Pila de Seguimiento: </strong>
                        <code id="mdlTxt_StackT"></code>
                        <br />
                    </div>
                    <div>
                        <strong>Contáctese con IrisLab para asistencia técnica.</strong>
                    </div>
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

    <div id="mdlLimit" class="modal fade" data-backdrop="static">
        <div class="modal-dialog modal-sm">
            <div class="modal-content border-bar">
                <div class="modal-header text-center bg-bar">
                    <h4 class="modal-title w-100">Aviso</h4>
                </div>
                <div class="modal-body pt-6 pb-6 text-left">
                    <p data-status="none">El número de atención introducido no existe o no tiene permisos para verlo, por favor introduzca un número válido.</p>
                    <p data-status="left">No se han encontrado atenciones anteriores a la actualmente seleccionada, por favor introduzca un número existente.</p>
                    <p data-status="right">No se han encontrado atenciones anteriores a la actualmente seleccionada, por favor introduzca un número existente.</p>
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


    <div id="mdlCritManual" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Valor Crítico Manual</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="btn_Acept_CM">Aceptar</button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

    <div id="mdlAlert" class="modal fade" data-backdrop="static">
        <div class="modal-dialog modal-md">
            <div class="modal-content border-bar">
                <div class="modal-header bg-bar text-center">
                    <h4 class="modal-title w-100"></h4>
                </div>
                <div class="modal-body pt-6 pb-6 text-left">
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

    <div id="mdlAudit" class="modal fade" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content border-bar">
                <div class="modal-header bg-bar text-center">
                    <h4 class="modal-title w-100">Auditoría {name}</h4>
                </div>
                <div id="Dtt_Audit" class="modal-body pt-6 pb-6 text-left">
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

    <div id="mdlGraph" class="modal fade" data-backdrop="static" style="z-index: 9999">
        <div class="modal-dialog modal-lg">
            <div class="modal-content border-bar">
                <div class="modal-header bg-bar text-center">
                    <h4 class="modal-title w-100">Historial de la Determinación</h4>
                </div>
                <div class="modal-body pt-6 pb-6 text-left">
                    <div class="row">
                        <div class="col-12 col-sm-12 col-md-9" id="divGraph">
                        </div>
                        <div class="col-12 col-sm-12 col-md-3" id="divGraphData">
                        </div>
                    </div>
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

    <div id="mdlHistExam" class="modal fade" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content border-bar">
                <div class="modal-header bg-bar text-center">
                    <div class="row w-100">
                        <div class="col-1"></div>
                        <div class="col-10">
                            <h4 class="modal-title w-100">Valorización de Exámenes Paciente</h4>
                        </div>
                        <div class="col-1">
                            <button type="button" class="btn btn-danger" data-dismiss="modal">
                                <i class="fa fa-times" aria-hidden="true" style="font-size: 20px"></i>
                            </button>
                        </div>
                    </div>
                </div>
                <div class="modal-body pt-6 pb-6 text-left">
                </div>
            </div>
        </div>
    </div>

    <div id="mdlHistPruebas" class="modal fade" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content border-bar">
                <div class="modal-header bg-bar text-center">
                    <div class="row w-100">
                        <div class="col-2">
                            <button type="button" class="btn btn-warning" id="Btn_GraphAlt">
                                <i class="fa fa-line-chart"></i>
                                <span style="font-weight: 600">Graf</span>
                            </button>
                        </div>
                        <div class="col-8">
                            <h4 class="modal-title w-100">Valorización de Examen Paciente</h4>
                        </div>
                        <div class="col-2">
                            <button type="button" class="btn btn-danger" data-dismiss="modal" id="Btn_HistPruExit">
                                <i class="fa fa-chevron-left" aria-hidden="true" style="font-size: 20px"></i>
                            </button>
                        </div>
                    </div>
                </div>
                <div class="modal-body pt-6 pb-6">
                    <div class="text-center pt-5 pb-5">
                        <i class="fa fa-spinner fa-pulse fa-5x fa-fw"></i>
                        <h3 class="text-center mt-3">Cargando...</h3>
                    </div>
                    <div class="text-left" style="display: none; overflow: auto;">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="mdlValidateError" class="modal fade" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content border-bar">
                <div class="modal-header bg-bar text-center">
                    <h4 class="modal-title w-100">Aviso Validación</h4>
                </div>
                <div class="modal-body pt-6 pb-6 text-left">
                    <p>Se han encontrado parámetros obligatorios sin valor. Los siguientes Exámenes no pueden ser validados mientras tales parámetros no tengan valor asignado.</p>
                    <p>Los Parámetros obligatorios sin valor son los siguientes:</p>
                    <ul></ul>
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

    <div id="mdlResCodificados" class="modal fade" data-backdrop="static">
        <div class="modal-dialog modal-lg" style="width: 930px; max-width: 950px;">
            <div class="modal-content border-bar">
                <div class="modal-header bg-bar text-center">
                    <h4 class="modal-title w-100">Opciones para tipo de Dato <small>Type of Data</small></h4>
                </div>
                <div class=" pt-6 pb-6 text-left">
                    <div class="modal-body row">
                        <div class="col-12">
                            <div class="form-group">
                                <label>Determinación:</label>
                                <input type="text" class="form-control" id="Txt_ResCod_Det" />
                            </div>
                        </div>
                        <div class="col-6">
                            <label>Descripción:</label>
                            <div class="mini-table">
                            </div>
                        </div>
                        <div class="col-6">
                            <label>Resultado:</label>
                            <textarea class="form-control" id="Txt_ResCod_Out"></textarea>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="Btn_RC_New" class="btn">
                        <i class="fa fa-file-o" aria-hidden="true"></i>
                        <span>Nuevo</span>
                    </button>
                    <button type="button" id="Btn_RC_Add" class="btn btn-success" data-dismiss="modal">
                        <i class="fa fa-save" aria-hidden="true"></i>
                        <span>Guardar</span>
                    </button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal">
                        <i class="fa fa-times" aria-hidden="true"></i>
                        <span>Cancelar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div id="mdlPanel" class="modal fade" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content border-bar">
                <div class="modal-header bg-bar text-center">
                    <h4 class="modal-title w-100">Paneles de Antibiogramas</h4>
                </div>
                <div class="modal-body pt-6 pb-6 text-left">
                    <div class="row" id="dat_Ate">
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <table class="table table-hover table-striped table-iris" id="table_Cultivos">
                                <thead>
                                    <tr>
                                        <th>Código
                                        </th>
                                        <th>Descripción
                                        </th>
                                        <th>Fecha
                                        </th>
                                        <th>Usuario Validación
                                        </th>
                                        <th>Validado
                                        </th>
                                        <th>Impreso
                                        </th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <h4 class='w-100 text-center mb-3' style='color: #014b5d !important'>Panel Antibióticos</h4>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-5" style="height: 45vh; overflow: auto;">
                            <table class="table table-hover table-striped table-iris" id="table_No_Cargado">
                                <thead>
                                    <tr>
                                        <th>Panel Antibióticos
                                        </th>
                                        <th>Cargar
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                        <div class="col-lg-2">
                            <div class="row  text-center mb-3 mt-3">
                                <div class="col">
                                    <a class="btn btn-sq-lg btn-primary" style="color: white" id="btn_Agregar"><b><i class="fa fa-arrow-right fa-3x"></i>
                                        <br />
                                        Agregar</b></a>
                                </div>
                            </div>
                            <div class="row  text-center">
                                <div class="col">
                                    <a class="btn btn-sq-lg btn-danger" style="color: white; min-width: 85.6px;" id="btn_Quitar"><b><i class="fa fa-arrow-left fa-3x"></i>
                                        <br />
                                        Quitar</b></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-5" style="height: 45vh; overflow: auto;">
                            <table class="table table-hover table-striped table-iris" id="table_Cargado">
                                <thead>
                                    <tr>
                                        <th>Panel Antibióticos
                                        </th>
                                        <th>Quitar
                                        </th>
                                        <th>Folio
                                        </th>
                                        <th>Cultivo
                                        </th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="btn_Guardar_Panel">
                        <i class="fa fa-save" aria-hidden="true"></i>
                        <span>Guardar</span>
                    </button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        <i class="fa fa-check" aria-hidden="true"></i>
                        <span>Cerrar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div id="mdlObsExam" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Listado de Exámenes</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                    <div id="Div_Exam_Agrega" style="width: 100%;" class="table-responsive"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-info" data-dismiss="modal" id="btnAgregaDeter" disabled="disabled">
                        <i class="fa fa-plus" aria-hidden="true"></i>
                        <span>Agregar Observación</span>
                    </button>
                     <button type="button" class="btn btn-danger" data-dismiss="modal">
                        <i class="fa fa-close" aria-hidden="true"></i>
                        <span>Cerrar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div id="mdlObsExa2" class="modal fade" role="dialog" style="z-index:9999999;">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Agregar Determinación</h4>
                </div>
<%--                <div class="modal-body pt-5 pb-5 text-left">
                    <div class="row">
                        <div class="col-sm-5">
                            <span>Tipo Determinación:</span>
                            <select id="slc_soli_o_no_soli" class="form-control">
                                <option value="0">No Solicitada</option>
                                <option value="1">Solicitada</option>
                            </select>
                        </div>
                        <div class="col-sm-5">
                            <br />
                            <button type="button" class="btn btn-info" id="btnBuscaDeter">
                                <i class="fa fa-search" aria-hidden="true"></i>
                                <span>Buscar</span>
                            </button>
                        </div>
                    </div>
                </div>--%>
                <div class="modal-body pt-5 pb-5 text-left">
                    <div id="Div_Exam_Agrega2" style="width: 100%;" class="table-responsive"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal" id="btnGuardaObsExam2">
                        <i class="fa fa-check" aria-hidden="true"></i>
                        <span>Guardar</span>
                    </button>
                     <button type="button" class="btn btn-danger" data-dismiss="modal">
                        <i class="fa fa-close" aria-hidden="true"></i>
                        <span>Cerrar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal" id="modal-pendientes" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document" style="width: 60vw; max-width: 900px;">
            <div class="modal-content">

                <div class="modal-body">



                    <div class="card border-bar">
                        <div class="card-header bg-bar">
                            <h4 class="m-0">Exámenes Pendientes</h4>
                        </div>
                        <div class="card-body p-1">
                            <div class="row">
                                <div class="col-md-6 pr-1">
                                    <div class='input-group date' id='div-desde-pendiente'>
                                        <input type='text' id="txt-desde-pendiente" class="form-control form-control-sm" readonly="" placeholder="Desde..." style="font-size: 12px" />
                                        <span class="input-group-addon p-1">
                                            <i class="fa fa-calendar"></i>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-md-6 pl-1">
                                    <div class='input-group date' id='div-hasta-pendiente'>
                                        <input type='text' id="txt-hasta-pendiente" class="form-control form-control-sm" readonly="" placeholder="Hasta..." style="font-size: 12px" />
                                        <span class="input-group-addon p-1">
                                            <i class="fa fa-calendar"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row mt-1">
                              <%--  <div class="col-md-4 pr-1">
                                    <select class="form-control form-control-sm" id="slct-area" style="font-size: 12px; height: 26.7px">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                                <div class="col-md-4 pr-0 px-0">
                                    <select class="form-control form-control-sm" id="slct-seccion" style="font-size: 12px; height: 26.7px">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>--%>
                                
                                <div class="col-md-6 pr-1">
                                    <select class="form-control form-control-sm" id="slct-rls-area-seccion" style="font-size: 12px; height: 26.7px">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>

                                <div class="col-md-6 pl-1">
                                    <select class="form-control form-control-sm" id="Ddl_Examen_Ate_pendiente" style="font-size: 12px; height: 26.7px">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                            </div>
                            <div class="row mt-1">
                                <div class="col-md">
                                    <select class="form-control form-control-sm" id="Ddl_Proc_Ate_pendiente" style="font-size: 12px; height: 26.7px">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                            </div>
                            <div class="row mt-1">
                                <div class="col-md-12">
                                    <button class="btn btn-primary btn-sm btn-block mt-0" style="font-size: 12px" id="btn_Busca_Ate_Sec_pendiente">Buscar</button>
                                </div>
                            </div>
                            <div class="row mt-1">
                                <div class="col-md-12">
                                    <div id="Div_Dtt_pendiente" style="max-height: 60vh; overflow: auto"></div>
                                </div>
                            </div>
                        </div>
                    </div>






                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>


    <!-- Modal_Eliminar -->
    <div id="Modal_Eliminar" class="modal fade" role="dialog">
        <div class="modal-dialog ml-xl-auto">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Eliminar Examen</h4>
                </div>
                <div class="modal-body">
                    <span>Estimado usuario: ¿Confirma eliminación de exámen?</span>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btn_Eliminar_Confirma" class="btn btn-danger">Eliminar</button>
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal" id="modal-agregar-quitar-examenes" tabindex="-1" role="dialog" style="z-index:1041">
        <div class="modal-dialog" role="document" style="width: 60vw; max-width: 900px;">
            <div class="modal-content">

                <div class="modal-body">






                    <!-- Breadcrumbs -->
            <div class="card border-bar">
                <div class="card-header bg-bar p-2">
                    <h5 style="text-align: center; padding: 5px;">
                        <i class="fa fa-sign-in"></i>
                        Agregar/Quitar Exámenes
                    </h5>
                </div>
                <div class="card-body p-3">
                    <div class="container" style="max-width: 100%;" hidden="">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="row">
                                    <div class="col-md checkbox checkbox-success">
                                        <input id="checkBox999" value="rutee" type="checkbox" />
                                        <label class="textoReducido" style="padding-left: 0px !important;" for="checkBox999">RUT</label><input id="checkBox888" value="DNI" type="checkbox" /><label style="margin-left: 15px; padding-left: 0px !important;" class="textoReducido" for="checkBox888">DNI:</label><input id="checkBox8887" value="DNI" type="checkbox" /><label style="margin-left: 15px; padding-left: 0px !important;" class="textoReducido" for="checkBox8887">N°Ate:</label>

                                        <input type='text' id="rut" class="form-control textoReducido" placeholder="12.345.789-0" />
                                        <input type='text' id="dni" class="form-control textoReducido" placeholder="D.N.I" />
                                        <input type='text' id="Naten" class="form-control textoReducido" placeholder="N° Atención" />

                                    </div>
                                    <div class="col-lg">
                                        <label class="textoReducido">RUT:</label>
                                        <input type='text' id="Rut_2m" class="form-control textoReducido" readonly="true" placeholder="" style="text-align: center;" />
                                    </div>
                                    <div class="col-lg">
                                        <label class="textoReducido">Nombres:</label>
                                        <input type='text' id="Nom" class="form-control textoReducido" placeholder="" />
                                    </div>
                                    <div class="col-lg">
                                        <label class="textoReducido">Apellidos:</label>
                                        <input type='text' id="Ape" class="form-control textoReducido" placeholder="" />
                                    </div>
                                    <div class="col-lg">
                                        <label class="textoReducido">F.Nacimiento:</label>
                                        <div class='input-group date' id='datetimepicker1' style="margin-bottom: 1vh;">
                                            <input type="date" min="0001-01-01" max="2018-12-01" id="fecha" class="form-control textoReducido" placeholder="Fecha" />
                                            <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="col-lg">
                                        <label class="textoReducido">Edad:</label>
                                        <input type='text' id="Edad" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="text-align: center;" />
                                    </div>




                                </div>
                                <div class="row">
                                    <div class="col-lg">
                                        <label class="textoReducido">Sexo:</label>
                                        <select id="sex" class="form-control textoReducido" style="height: 31.75px;">
                                        </select>
                                    </div>
                                    <div class="col-lg checkbox checkbox-success">
                                        <input id="checkBox2" type="checkbox" value="SoyFur" />
                                        <label for="checkBox2" class="textoReducido">F.U.R:</label>
                                        <div class='input-group date' id='datetimepicker3' style="margin-bottom: 1vh;">
                                            <input type='text' id="FUR" class="form-control textoReducido" readonly="true" placeholder="Fecha" />
                                            <span id="fur" class="input-group-addon">
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
                                        <script type="text/javascript">
                                            ////////////////////////////////////
                                            ////////////////////////////////////
                                            $(function () {
                                                $('#datetimepicker3').datetimepicker(
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
                                                        minView: 2,
                                                        useCurrent: true

                                                    })
                                            });
                                        </script>
                                    </div>
                                    <div class="col-lg">
                                        <label class="textoReducido">Nacionalidad:</label>
                                        <select id="Nacio" class="form-control textoReducido" style="height: 31.75px;">
                                            <option value="volvo">Seleccionar</option>
                                        </select>
                                    </div>
                                    <div class="col-lg">
                                        <label class="textoReducido">Tel. Fijo:</label>
                                        <input type='text' id="telfijo" class="form-control textoReducido" placeholder="" />
                                    </div>
                                    <div class="col-lg">
                                        <label class="textoReducido">Celular:</label>
                                        <input type='text' id="Celular" class="form-control textoReducido" placeholder="" />
                                    </div>
                                    <div class="col-lg">
                                        <label class="textoReducido">Dirección:</label>
                                        <input type='text' id="direccion" class="form-control textoReducido" placeholder="" />
                                    </div>
                                </div>
                                <div>
                                    <div class="row" style="margin-bottom: 10px;">
                                        <div class="col-lg">
                                            <label class="textoReducido">Región:</label>
                                            <select id="Cuidad" class="form-control textoReducido" style="height: 31.75px;">
                                                <option value="0">Seleccionar</option>
                                            </select>
                                        </div>
                                        <div class="col-lg">
                                            <label class="textoReducido">Comuna:</label>
                                            <select id="Comuna" class="form-control textoReducido" style="height: 31.75px;">
                                                <option value="0">Seleccionar</option>
                                            </select>
                                        </div>
                                        <div class="col-lg">
                                            <label class="textoReducido">Email:</label>
                                            <input type='text' id="Email" class="form-control textoReducido" placeholder="Irislab@irislab.cl" />
                                        </div>
                                        <div class="col-lg-3">
                                            <label class="textoReducido">observaciones permanentes del paciente:</label>
                                            <input type='text' id="obdser" class="form-control textoReducido" placeholder="" />
                                        </div>
                                        <div class="col-lg">
                                            <label class="textoReducido">Diagnostico N° 1</label>
                                            <select id="DdlDiagnosticoAgregarQuitarExamen" class="form-control textoReducido" style="height: 31.75px;">
                                                <option value="0">Seleccionar</option>
                                            </select>
                                        </div>
                                        <div class="col-lg">
                                            <label class="textoReducido">Diagnostico N° 2</label>
                                            <select id="DdlDiagnostico2" class="form-control textoReducido" style="height: 31.75px;">
                                                <option value="0">Seleccionar</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <h5 style="text-align: center; padding: 5px;" id="titulooo"></h5>
                    <div class="container" style="max-width: 100%;">
                        <div class="row">
                            <div class="col-sm">
                                <div id="Div_Tabla78" style="width: 100%;" class="highlights"></div>
                            </div>
                        </div>

                    </div>
                    <hr />
                    <hr />
                    <h5 style="text-align: center; padding: 5px;">Agregar nuevos exámenes a la atención actual </h5>
                    <div class="container" style="max-width: 100%;">
                        <div class="row">
                            <div class="col-sm">
                                <div id="Div_Tabla3" style="width: 100%;" class="highlights"></div>
                            </div>
                        </div>

                    </div>
                    <div class="container" style="max-width: 100%; border: 0px solid #fff;">
                        <div class="row" style="justify-content: space-between">
                            <div class="col-sm-3">
                                <button id="Examen" type="button" class="btn btn-danger btn-block">
                                    <br />
                                    <i class="fa fa-align-left" aria-hidden="true" style="font-size: 30px;"></i>
                                    <p style="margin-top: 2px;">Examen</p>
                                </button>
                            </div>

                            <div class="col-sm-3">
                                <button id="BtnSaveAll" type="button" class="btn btn-primary btn-block">
                                    <br />
                                    <i class="fa fa-fw fa-save" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                                    <p style="margin-top: 2px;">Guardar</p>
                                </button>
                            </div>
                            <div class="col-sm-4" hidden="">
                                <div class="row">
                                    <div class="col-sm-6" style="font-size: 13px">
                                        <label>T. Copa Fonasa</label>
                                    </div>
                                    <div class="col-sm-6" style="font-size: 13px">
                                        <label>Total Particular</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <input type="text" id="Lbl_tot_copa_fonasa" style="font-weight: 700" class="form-control" disabled="disabled" />
                                    </div>
                                    <div class="col-sm-6">
                                        <input type="text" id="Lbl_tot_copa_particular" style="font-weight: 700" class="form-control" disabled="disabled" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4" style="font-size: 13px">
                                        <label>T. Fonasa/Particular</label>
                                    </div>
                                    <div class="col-sm-4" style="font-size: 13px">
                                        <label>Seguro Complementario</label>
                                    </div>
                                    <div class="col-sm-4" style="font-size: 13px">
                                        <label>Total a Pagar</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <input type="text" id="Lbl_tot_prevision" style="font-weight: 700" class="form-control" disabled="disabled" />
                                    </div>
                                    <div class="col-sm-4">
                                        <input type="text" id="Lbl_tot_beneficiario" style="font-weight: 700" class="form-control" disabled="" />
                                    </div>
                                    <div class="col-sm-4">
                                        <input type="text" id="Lbl_tot_a_pagar" style="font-weight: 900; border: solid" class="form-control" disabled="disabled" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>





















                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="eModal2" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Agregar Exámenes</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="col-md-12">
                            <div id="Div_Tabla2" style="width: 100%;" class="highlights2"></div>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btnguardar" class="btn btn-success">Cargar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal" id="modal-atenciones" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Buscar Atenciones</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="card border-bar">
                        <div class="card-header bg-bar">
                            <h4 class="m-0">Lista Atenciones</h4>
                        </div>
                        <div class="card-body p-1">
                            <div class="row">
                                <div class="col-md-6 pr-1">
                                    <div class='input-group date' id='Txt_Date11'>
                                        <input type='text' id="fecha11" class="form-control form-control-sm" readonly="" placeholder="Desde..." style="font-size: 12px" />
                                        <span class="input-group-addon p-1">
                                            <i class="fa fa-calendar"></i>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-md-6 pl-1">
                                    <div class='input-group date' id='Txt_Date22'>
                                        <input type='text' id="fecha22" class="form-control form-control-sm" readonly="" placeholder="Hasta..." style="font-size: 12px" />
                                        <span class="input-group-addon p-1">
                                            <i class="fa fa-calendar"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <%--<div class="row mt-1">
                                <div class="col-md-6 pr-1">
                                    <select class="form-control form-control-sm" id="Ddl_Area" style="font-size: 12px; height: 26.7px">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                                <div class="col-md-6 pl-1">
                                    <select class="form-control form-control-sm" id="Ddl_Seccion" style="font-size: 12px; height: 26.7px">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                            </div>--%>
                            
                            <div class="row mt-1">
                                <div class="col-md-12">
                                    <select class="form-control form-control-sm" id="Ddl_Area_Seccion" style="font-size: 12px; height: 26.7px">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                            </div>

                            <div class="row mt-1">
                                <div class="col-md">
                                    <select class="form-control form-control-sm" id="Ddl_Proc_Ate" style="font-size: 12px; height: 26.7px">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                            </div>
                            <div class="row mt-1">
                                <div class="col-md-12">
                                    <button class="btn btn-primary btn-sm btn-block mt-0" style="font-size: 12px" id="btn_Busca_Ate_Sec">Buscar</button>
                                </div>
                            </div>
                            <div class="row mt-1">
                                <div class="col-md-12">
                                    <button class="btn btn-warning btn-sm btn-block mt-0" style="font-size: 12px" id="btn_Busca_Ate_Sec_Pendientes">Buscar Pendientes</button>
                                </div>
                            </div>
                            <div class="row mt-1">
                                <div class="col-md-12 p-0">
                                    <div id="Div_Dtt" style="max-height: 60vh; overflow: auto"></div>
                                </div>
                            </div>
                        </div>
                    </div>






                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal" id="modal-editar-paciente" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document" style="max-width: 50vw;">
            <div class="modal-content">
                <div class="modal-header" hidden="">
                    <h5 class="modal-title">Editar Paciente</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">






                    <div class="card text-center">
                        <div class="card-header" style="background-color: #00738e;">

                            <span style="color: white; font-size: 2rem;"><i class="fa fa-fw fa-pencil mr-2"></i>Editar Paciente</span>

                        </div>
                        <div class="card-body">



                            <div class="grid-editar-paciente">

                                <div style="grid-column: span 2">
                                    <label for="txtRut">Rut:</label>
                                    <input id="txtRut" class="form-control textoReducido" type="text" placeholder="Rut.." />
                                </div>


                                <div style="grid-column: span 2">
                                    <label for="txtNom">Nombre:</label>
                                    <input id="txtNom" class="form-control textoReducido" type="text" />
                                </div>


                                <div style="grid-column: span 2">
                                    <label for="txtApe">Apellido:</label>
                                    <input id="txtApe" class="form-control textoReducido" type="text" />
                                </div>


                                <div style="grid-column: span 2">
                                    <label for="DdlSexo">Sexo:</label>
                                    <select id="DdlSexo" class="form-control textoReducido mayus">
                                        <%--<option value="0">Seleccionar</option>--%>
                                    </select>
                                </div>



                                <div style="grid-column: span 2">
                                    <label for="fecha">Fecha Nacimiento:</label>
                                    <div class='input-group date' id='Txt_Date01'>
                                        <input type='text' id="fecha" class="form-control textoReducido" readonly="true" placeholder="f. nacimiento..." />
                                        <span class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </span>
                                    </div>
                                </div>


                                <div style="grid-column: span 2">
                                    <label for="DdlNacionalidad">Nacionalidad:</label>
                                    <select id="DdlNacionalidad" class="form-control textoReducido mayus">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>


                                <div style="grid-column: span 2">
                                    <label for="txtNuevoDireccion">Dirección:</label>
                                    <input id="txtNuevoDireccion" class="form-control textoReducido mayus" type="text" placeholder="dirección..." />
                                </div>


                                <div style="grid-column: span 2">
                                    <label for="DdlCiudad">Ciudad:</label>
                                    <select id="DdlCiudad" class="form-control textoReducido mayus">
                                    </select>
                                </div>



                                <div style="grid-column: span 2">
                                    <label for="DdlComuna">Comuna:</label>
                                    <select id="DdlComuna" class="form-control textoReducido">
                                    </select>
                                </div>


                                <div style="grid-column: span 2">
                                    <label for="txtNuevoTelefono1">Teléfono N°1:</label>
                                    <input id="txtNuevoTelefono1" class="form-control textoReducido" type="text" placeholder="teléfono..." />
                                </div>


                                <div style="grid-column: span 2">
                                    <label for="txtNuevoCelular1">Celular N°1:</label>
                                    <input id="txtNuevoCelular1" class="form-control textoReducido" type="text" placeholder="celular..." />
                                </div>


                                <div style="grid-column: span 2">
                                    <label for="txtNuevoTelefono2">Teléfono N°2:</label>
                                    <input id="txtNuevoTelefono2" class="form-control textoReducido" type="text" placeholder="teléfono..." />
                                </div>



                                <div style="grid-column: span 2">
                                    <label for="txtNuevoCelular2">Celular N°2:</label>
                                    <input id="txtNuevoCelular2" class="form-control textoReducido" type="text" placeholder="celular..." />
                                </div>


                                <div style="grid-column: span 2">
                                    <label for="txtNuevoEmail">Email:</label>
                                    <input id="txtNuevoEmail" class="form-control textoReducido mayus" type="text" placeholder="email..." />
                                </div>


                                <div style="grid-column: span 2">
                                    <label for="DdlDiagnostico">Diagnóstico:</label>
                                    <select id="DdlDiagnostico" class="form-control textoReducido mayus">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>

                                <div style="grid-column: span 2" hidden="">
                                    <label for="DdlEstado">Estado:</label>
                                    <select id="DdlEstado" class="form-control textoReducido mayus">
                                        <option value="1"><< ACTIVADO >></option>
                                    </select>
                                </div>

                            </div>
                        </div>
                        <div class="card-footer text-muted" style="text-align: end;">

                            <button id="Btn_Update" class="btn btn-info" type="button"><i class="fa fa-fw fa-edit mr-2"></i>Modificar</button>

                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>




    <div class="modal" id="modal-quitar-estado" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document" style="max-width: 30vw;">
            <div class="modal-content">
                <div class="modal-header" hidden="">
                    <h5 class="modal-title">Quitar Estado</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="card text-center">
                        <div class="card-header" style="background-color: #00738e;">
                            <span style="color: white; font-size: 2rem;"><i class="fa fa-fw fa-pencil mr-2"></i>Quitar Estado</span>
                        </div>
                   
                        <div class="card-body">

                            
                            <div id="Div_DataTable_Quitar_Estado" style="grid-column: span 4"></div>


                        </div>
                        <div class="card-footer text-muted" style="display: flex; justify-content: space-around;">
                            <button id="btn-guardar-quitar-estado" class="btn btn-danger" type="button"><i class="fa fa-fw fa-edit mr-2"></i>Quitar Estado</button>
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>






















    <div id="mdlDet" class="modal fade cincuentamilzindex" role="dialog" style="z-index:50000">
        <div class="modal-dialog" style="width: 90vw;max-width:90vw">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title">Registro de Información de Valores Críticos</h3>
                </div>
                <div class="modal-body text-left">
                    <div class="row">
                        <div class="col-12 pt-2" id="divTableDet">
                        </div>
                        <br />
                        <div class="col-12 pt-2" id="h4-log-registros">
                            <h4>Log de Registros Informados</h4>
                        </div>

                        <div class="col-12 pt-2" id="divTableDet2">
                        </div>
                        <br />
                    </div>
                    <div class="row" id="row-estado-fecha">
                        
                        <div class="col-12 pt-2" id="h4-instrucciones-notificacion">
                            <h5>Todos los resultados que no han sido notificados se notificarán con la información que ingrese a continuación:</h5>
                        </div>

                        <div class="col-md-4 mb-1">
                            <label for="Ddl_Stat_aviso2">Estado:</label>
                            <select id="Ddl_Stat_aviso2" class="form-control">
                            </select>
                        </div>
                        <div class="col-md-4mb-1">
                            <%--<label for="fecha">Fecha:</label>
                            <input type='datetime-local' id="fecha3" class="form-control" />--%>
                        </div>
                        <div class="col-md-4 mb-1">
                        </div>
                    </div>
                    <div class="row" hidden="">
                        <div class="col-md mb-1">
                            <label>Causa:</label>
                            <input type="text" id="txt_causa" class="form-control" />
                        </div>
                    </div>
                    <div class="row" id="row-avisado-a">
                        <div class="col-md mb-1">
                            <label>Notificado a:</label>
                            <input type="text" id="txt-avisado" class="form-control" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" id="btn-guardar-notificacion" data-dismiss="modal"><i class="fa fa-fw fa-file-text"></i>Guardar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        <span>Cerrar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>



























    <div id="MOdal_NUEVO_SELECCION" class="modal fade" role="dialog">
        <div class="modal-dialog" role="document" style="max-width:60vw">

            <!-- Modal content-->
            <div class="modal-content">
                <br />
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 id="title2NuevoSeleccion" class="modal-title" style="margin-top:65px; text-align:center;">¿Cómo pagará el copago el paciente?</h4>
                <div id="modalpcccNuevoSeleccion" class="modal-body">
                    <div class="row">
                        <div class="col-lg">
                            <label>Forma de Pago</label>
                        </div> 
                        <div class="col-lg-5">
                            <label>Tarjeta (N° Operación) y Cheque (Nom. y Número)</label>
                        </div>
                        <div class="col-lg">
                            <label id="lbl_tot_copago"></label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg">
                            <select id="Ddl_Ttp_Modal" class="form-control">
                                <option value="1">Efectivo</option>
                                <option value="21">Tarjeta Débito</option>
                                <option value="9">Tarjeta Crédito</option>
                                <option value="22">Transferencia</option>
                            </select>
                        </div>
                        <div class="col-lg-5">
                            <input type="text" id="txt_nTarjeta_1_modal" class="form-control"/>
                        </div>
                        <div class="col-lg">
                            <input type="text" id="lbl_Tot_Fonasa_Modal" class="form-control" disabled="disabled" onkeydown="return jsDecimals(event)" maxlength="9"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-8">
                        </div>
                        <div class="col-lg-4 text-right">
                            <span id="spanAgregaMedioPago" style="font-weight:600;">Agregar Medio de Pago <i id="agregaMedioPago" class="fa fa-plus" style="color:#039921; cursor:pointer"></i></span>                          
                        </div>
                    </div>
                    <%--NUEVO TIPO DE PAGO--%>
                    <div id="divNewPaymen" style="display:none;">
                        <div class="row">
                        <div class="col-lg">
                            <label>Forma de Pago</label>
                        </div> 
                        <div class="col-lg-5">
                            <label>Tarjeta (N° Operación) y Cheque (Nom. y Número)</label>
                        </div>
                        <div class="col-lg">
                            <label>VALOR (Fonasa)</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg">
                            <select id="Ddl_Ttp_Modal_2" class="form-control">
                                <option value="1">Efectivo</option>
                                <option value="21">Tarjeta Débito</option>
                                <option value="9">Tarjeta Crédito</option>
                                <option value="22">Transferencia</option>
                            </select>
                        </div>
                        <div class="col-lg-5">
                            <input type="text" id="txt_nTarjeta_1_modal_2" class="form-control"/>
                        </div>
                        <div class="col-lg">
                            <input type="text" id="lbl_Tot_Fonasa_Modal_2" value="0" class="form-control" disabled="disabled" onkeydown="return jsDecimals(event)"/>
                        </div>
                    </div>
                        <div class="row">
                        <div class="col-lg-8">
                        </div>
                        <div class="col-lg-4 text-right">
                            <span  style="font-weight:600;">Quitar Medio de Pago <i id="quitaMedioPago" class="fa fa-minus" style="color:#e02619; cursor:pointer"></i></span>                          
                        </div>
                    </div>
                    </div>
                    <%--FIN NUEVO TIPO DE PAGO--%>
                    <br />
                    <div>
                        <div class="row">
                            <div class="col-lg">
                                <label>Forma de Pago</label>
                            </div>
                            <div class="col-lg-5">
                                <div>
                                    <label>Tarjeta (N° Operación) y Cheque (Nom. y Número)</label>
                                </div>
                            </div>
                            <div class="col-lg">
                                <div>
                                    <label id="lbl_valor_parti"></label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg">
                                <select id="Ddl_Ttp_Modal2" class="form-control">
                                    <option value="1">Efectivo</option>
                                    <option value="21">Tarjeta Débito</option>
                                    <option value="9">Tarjeta Crédito</option>
                                </select>
                            </div>
                            <div class="col-lg-5">                   
                                <input type="text" id="txt_nTarjeta_2_modal" class="form-control"/>
                            </div>
                            <div class="col-lg">
                                <input type="text" id="lbl_Tot_Pagar_Insumos_Particul_Modal" class="form-control" disabled="disabled" onkeydown="return jsDecimals(event)"/>
                            </div>
                        </div>
                        <div class="row">
                        <div class="col-lg-8">
                        </div>
                        <div class="col-lg-4 text-right">
                            <span id="spanAgregaMedioPago_Parti" style="font-weight:600;">Agregar Medio de Pago Particular <i id="agregaMedioPago_Parti" class="fa fa-plus" style="color:#039921; cursor:pointer"></i></span>                          
                        </div>
                        <br />
                    </div>
                    <%--NUEVO TIPO DE PAGO PARTI--%>
                    <div id="divNewPaymen_Parti" style="display:none;">
                        <div class="row">
                        <div class="col-lg">
                            <label>Forma de Pago</label>
                        </div> 
                        <div class="col-lg-5">
                            <label>Tarjeta (N° Operación) y Cheque (Nom. y Número)</label>
                        </div>
                        <div class="col-lg">
                            <label>VALOR (Particular)</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg">
                            <select id="Ddl_Ttp_Modal_2_Parti" class="form-control">
                                <option value="1">Efectivo</option>
                                <option value="21">Tarjeta Débito</option>
                                <option value="9">Tarjeta Crédito</option>                 
                            </select>
                        </div>
                        <div class="col-lg-5">
                            <input type="text" id="txt_nTarjeta_1_modal_2_Parti" class="form-control"/>
                        </div>
                        <div class="col-lg">
                            <input type="text" id="lbl_Tot_Fonasa_Modal_2_Parti" value="0" class="form-control" disabled="disabled" onkeydown="return jsDecimals(event)"/>
                        </div>
                    </div>
                        <div class="row">
                        <div class="col-lg-8">
                        </div>
                        <div class="col-lg-4 text-right">
                            <span style="font-weight:600;">Quitar Medio de Pago <i id="quitaMedioPago_Parti" class="fa fa-minus" style="color:#e02619; cursor:pointer"></i></span>                          
                        </div>
                    </div>
                    </div>
                    <%--FIN NUEVO TIPO DE PAGO PARTI--%>
                        <br />
                        <div class="row">
                            <div class="col-lg-6">
                            </div>
                            <div class="col-lg-3">
                                <label style="font-weight:700">N° Boleta</label>
                                <input type="text" id="txt_nBoleta_2_modal" class="form-control" onkeydown="return jsDecimals(event)"/>
                            </div>
                            <div class="col-lg-3">
                                <label style="font-weight:700">Total a Pagar</label>
                                <input type="text" class="form-control" disabled="disabled" id="lbl_Tot_Pagar_Modal" style="font-weight:700; font-size:19px;" height:"calc(1.89rem + 1px);"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="button_modal_pagoNuevoSeleccion" class="btn btn-success">Guardar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>                  
                </div>
            </div>
        </div>
    </div>


    <%----------------- MODAL CRITICOS -----------------------%>
   <div id="mdlCritico" class="modal fade cincuentamilzindex" role="dialog">
    <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-header card-header bg-bar">
                <h3 class="modal-title">¡Alerta de Valores Críticos!</h3>             
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col">
                        <table id="datatable_criticos" cellspacing="0" class="table table-hover table-iris table-striped">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Descripción</th>
                                    <th>Resultado</th>
                                    <th>Examen</th>
                                    <th>Sección</th>
                                    <th class="text-center">Notificado</th>
                                </tr>
                            </thead>
                            <tbody>

                            </tbody>
                        </table>
                    </div>
                    <br />        
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-danger" data-dismiss="modal">
                    <span>Cerrar</span>
                </button>
            </div>
        </div>
    </div>
</div>
</asp:Content>
