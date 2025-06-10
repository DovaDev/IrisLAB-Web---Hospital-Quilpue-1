<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Rem.aspx.vb" Inherits="Presentacion._Rem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script src="Rem.js?version=<%= DateTime.Now.ToString() %>"></script>
    <style>
        .manito {
            cursor: pointer;
        }
    </style>
    <div class="card-header bg-bar"><h5 class="text-center"><i class="fa fa-fw fa-info"></i>Información de Código Fonasa Formato Rem</h5></div>
        <hr />
        <div class="col-3" id="div_chk">
            <div class="col-sm">
                <label for="ddl_secc">Sección Rem</label>
                <select id="ddl_secc" class="form-control"></select>
            </div>
        </div>
        <hr />
        <div class="row mb-3" style="height: 41vh; overflow: auto;">
            <div class="col-sm-1"></div>
            <div class="col-sm-10">
                <table id="Dtt_Codigos_Format" cellspacing="0" class="table table-hover table-striped table-iris">
                    <thead>
                        <tr>
                            <th style="text-align: center">#</th>
                            <th style="text-align: center">Codigo Fonasa REM</th>
                            <th style="width: 16vw;">Descripción</th>
                            <th class="text-center">Estado</th>
                            <th style="text-align: center">Sección</th>
                            <th style="text-align: center">Relacionar</th>
                            <th style="text-align: center">Ajustar</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
            <div class="col-sm-1"></div>
        </div>
        <hr />
    <%--MODAL: RELACIONAR REM IRIS--%>
    <div id="mdlPanel" class="modal fade" data-backdrop="static">
    <div class="modal-dialog modal-lg">
        <div class="modal-content border-bar">
            <div class="modal-header bg-bar text-center">
                <h4 class="modal-title w-100">Paneles de Relacion Codigo REM - IRIS</h4>
            </div>
            <div class="modal-body pt-6 pb-6 text-left">
                <div class="row" id="dat_Ate">
                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <table class="table table-hover table-striped table-iris" cellspacing="0" id="row_codigo_rem">
                            <thead>
                                <tr>
                                    <th>Código
                                    </th>
                                    <th>Descripción
                                    </th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <h4 class='w-100 text-center mb-3' style='color: #014b5d !important'>Panel REM-IRIS</h4>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-5" style="height: 45vh; overflow: auto;">
                        <table class="table table-hover table-striped table-iris" cellspacing="0" id="dtt_exam">
                            <thead>
                                <tr>
                                    <th>Codigo REM
                                    </th>
                                    <th>Descripción
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
                        <table class="table table-hover table-striped table-iris"  cellspacing="0" id="dtt_exam_rel">
                            <thead>
                                <tr>
                                    <th>Codigo IRIS
                                    </th>
                                    <th>Descripción
                                    </th>
                                    <th>Quitar
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

    <%--MODAL: AJUSTAR REM-IRIS--%>
        <div id="mdlPanelAjustar" class="modal fade" data-backdrop="static">
    <div class="modal-dialog modal-lg">
        <div class="modal-content border-bar">
            <div class="modal-header bg-bar text-center">
                <h4 class="modal-title w-100">Paneles de Ajustes Exclusión/Prioridad</h4>
            </div>
            <div class="modal-body pt-6 pb-6 text-left">
                <div class="row" id="">
                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <table class="table table-hover table-striped table-iris" cellspacing="0" id="dtt_examenes_asoc">
                            <thead>
                                <tr>
                                    <th>Código
                                    </th>
                                    <th>Descripción
                                    </th>          
                                    <th>Excluir/Priorizar
                                    </th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <h4 class='w-100 text-center mb-3' style='color: #014b5d !important'>Panel REM-IRIS</h4>
                    </div>
                </div>
                <div class="modal-footer">
                 <%--   <button type="button" class="btn btn-primary" id="btn_Guardar_">
                        <i class="fa fa-save" aria-hidden="true"></i>
                        <span>Guardar</span>
                    </button>--%>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        <i class="fa fa-check" aria-hidden="true"></i>
                        <span>Cerrar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>

