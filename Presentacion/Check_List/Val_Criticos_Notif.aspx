<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Val_Criticos_Notif.aspx.vb" Inherits="Presentacion.Val_Criticos_Notif" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
        <%@ OutputCache Location="None" NoStore="true" %>
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
        <script src="Val_Criticos_Notif.js?version=<%= DateTime.Now.ToString() %>" type="module"></script>
        <link href="Val_Criticos_Notif.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <!-- Modal Registro de Información de Valores Críticos -->
<div id="mdlDet" class="modal fade" role="dialog">
    <div class="modal-dialog modal-lg" style="width: 90rem !important">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Registro de Información de Valores Críticos</h4>
            </div>
            <div class="modal-body text-left">
                <div class="row">
                    <div class="col-12 pt-2" id="divTableDet"></div>
                    <div class="col-12 pt-2" id="h5-log-registros">
                        <h5>Log de Registros Informados</h5>
                    </div>
                    <div class="col-12 pt-2" id="divTableDet2"></div>
                </div>
                <div class="row" id="row-estado-fecha">
                    <div class="col-md-4 mb-1">
                        <label for="Ddl_Stat_aviso2">Tipo de notificación:</label>
                        <select id="Ddl_Stat_aviso2" class="form-control"></select>
                    </div>
                    <div class="col-md-4 mb-1" id="div_llamado" style="display: none;">
                        <label for="Ddl_llamado">Número de llamadas:</label>
                        <select id="Ddl_llamado" class="form-control">
                            <option value="0">Seleccione</option>
                            <option value="1">1er llamado</option>
                            <option value="2">2do llamado</option>
                            <option value="3">3er llamado</option>
                        </select>

                    </div>
                    <div class="col-md-4 mb-1" id="div_correo" style="display: none;">
                        <label for="Ddl_correo">Correo:</label>
                        <select id="Ddl_correo" class="form-control">
                            <option value="0">Seleccione</option>
                            <option value="1">1er correo</option>
                            <option value="2">2do correo</option>
                            <option value="3">3er correo</option>
                        </select>

                    </div>
                    <div class="col-md-4 mb-1">
                        <label for="fecha">Fecha:</label>
                        <input type='datetime-local' id="fecha3" class="form-control" />
                    </div>
                </div>
                <div class="row" <%--hidden--%>>
                    <div class="col-md mb-1">
                        <%--<label>Causa:</label>--%>
                        <label>Observación:</label>
                        <input type="text" id="txt_causa" class="form-control" />
                    </div>
                </div>
                <div class="row" id="row-avisado-a">
                    <div class="col-md mb-1">
                        <label>Notificado a:</label>
                        <input type="text" id="txt_avisao" class="form-control" />
                    </div>
                </div>
            </div>
   
                        <div class="modal-footer d-flex justify-content-between">
                <button type="button" class="btn btn-danger" id="btnFinalizar">
                    <i class="fa fa-fw fa-file-text"></i> Finalizar Proceso
                </button>
                <div>
                    <button type="button" class="btn btn-success" id="btnguardar">
                        <i class="fa fa-fw fa-file-text"></i> Guardar
                    </button>
                   <%-- <button type="button" class="btn btn-success" id="btnActualizar">
                        <i class="fa fa-fw fa-file-text"></i> Actualizar
                    </button>--%>
                </div>
                <button type="button" class="btn btn-danger" data-dismiss="modal">
                    <span>Cerrar</span>
                </button>
            </div>
        </div>
    </div>
</div>

<!-- Modal de Error -->
<div id="mError_AAH" class="modal fade" role="dialog">
    <div class="modal-dialog modal-sm">
        <div class="modal-content">
            <div class="modal-header">
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

<!-- Título, TextBox y Botones -->
<div class="row">
    <div class="col-lg">
        <div class="card mb-3 border-bar">
            <div class="card-header bg-bar">
                <h5 style="text-align: center; padding: 5px;">
                    <i class="fa fa-fw fa-edit"></i>
                    <span id="span-titulo">Listado Notificación Valores Críticos</span>
                </h5>
            </div>

            <div class="row" style="margin-left: 2px; margin-right: 2px;">

                <div class="col-md-3 mb-1">
                    <label for="fecha">Desde:</label>
                    <input type='date' id="fecha" class="form-control" />
                </div>

                <div class="col-md-3 mb-1">
                    <label for="fecha">Hasta:</label>
                    <input type='date' id="fecha2" class="form-control" />
                </div>

                <div class="col-md-3 mb-1">
                    <label for="Ddl_Seccion">Área-Sección:</label>
                    <select id="Ddl_Seccion" class="form-control"></select>
                </div>

                <div class="col-md-3 mb-1 ocultar-en-sapu" <%--hidden=""--%>>
                    <label for="Ddl_Exam">Examen:</label>
                    <select id="Ddl_Exam" class="form-control"></select>
                </div>

                <div class="col-md-3 mb-1 ocultar-en-sapu" <%--hidden=""--%>>
                    <label for="DdlPrevision">Previsión:</label>
                    <select id="DdlPrevision" class="form-control"></select>
                </div>

                <div class="col-md-3 mb-1 ocultar-en-sapu" <%--hidden=""--%>>
                    <label for="Ddl_Stat">Estado:</label>
                    <select id="Ddl_Stat" class="form-control"></select>
                </div>

                <div class="col-md-3 mb-1 ocultar-en-sapu" <%--hidden=""--%>>
                    <label for="DdlTipoAtencion">Tipo de Atención:</label>
                    <select id="DdlTipoAtencion" class="form-control">
                        <option value="0">Todos</option>
                    </select>
                </div>

                <div class="col-md-3 mb-1 ocultar-en-sapu" <%--hidden=""--%>>
                    <label for="Ddl_Stat_aviso">Tipo Aviso:</label>
                    <select id="Ddl_Stat_aviso" class="form-control">
                        <option value="0">Todos</option>
                    </select>
                </div>

                
                <div class="col-md-3 mb-1 ocultar-en-sapu" <%--hidden=""--%>>
                    <label for="Ddl_Stat_Valid">Validados:</label>
                    <select id="Ddl_Stat_Valid" class="form-control">
                        <option value="0" selected>Todos</option>
                        <option value="1">Si</option>
                        <option value="2">No</option>
                    </select>
                </div>

                <div class="col-md-2 mb-1">
                    <br class="mb-1" />
                    <button id="Btn_Buscar" class="btn btn-buscar btn-block mt-1 mb-1" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                </div>

                <div class="col-md-2 mb-1">
                    <br class="mb-1" />
                    <button id="Btn_Excel" class="btn btn-success btn-block mt-1 mb-1" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                </div>
            </div>
            <!-- Tablas -->
            <div class="row" id="Id_Conte" style="margin-left: 1px; width: 100%;">
                <div class="col-lg-12">
                    <h5 style="text-align: center;"><i class="fa fa-fw fa-list"></i>Resultados de la Búsqueda</h5>
                    <div class="row text-center" id="Paciente">
                        <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
