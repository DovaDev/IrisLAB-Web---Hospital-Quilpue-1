<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Impr_Dcto2.aspx.vb" Inherits="Presentacion.Impr_Dcto2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%@ OutputCache Location="None" NoStore="true" %>

    <link href="../js/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="../js/datepicker/js/bootstrap-datepicker.js"></script>
    <script src="../js/datepicker/locales/bootstrap-datepicker.es.min.js"></script>

    <link href="../css/WebForm2.css" rel="stylesheet" />
    <script src="../js/WebForm2.js"></script>
    <script src="Impr_Dcto2.js"></script>

    <style>
        .row.vdivide > div[class*='col-']:not(:last-child) {
            padding-bottom: 1rem;
            margin-bottom: 1rem;
        }

        .row.vdivide > div[class*='col-']:not(:last-child):after {
            background: #e0e0e0;
            height: 1px;
            content: "";
            display:block;
            position: absolute;
            left:0;
            right: 0;
            bottom: 0;
        }

        @media (min-width: 768px) {
            .row.vdivide > div[class*='col-']:not(:last-child) {
                padding-bottom: 0;
                margin-bottom: 0;
            }

            .row.vdivide > div[class*='col-']:not(:last-child):after {
                background: #e0e0e0;
                width: 1px;
                content: "";
                display:block;
                position: absolute;
                top:0;
                bottom: 0;
                right: 0;
                min-height: 70px;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="m-2">
        <div class="card mb-2">
            <div class="card-header">
                <h5>Reimpresión de Documentos</h5>
            </div>
            <div class="card-body" id="divSearch">
                <div class="row vdivide">
                    <div class="col-12 col-sm-12 col-md-6">
                        <div class="row">
                            <div class="col-12 col-sm-12 col-md-4">
                                <div class="form-group">
                                    <label>Desde:</label>
                                    <input type="text" id="txtDate01" class="form-control" />
                                </div>
                                <div class="form-group">
                                    <label>Hasta:</label>
                                    <input type="text" id="txtDate02" class="form-control" />
                                </div>
                            </div>
                            <div class="col-12 col-sm-6 col-md-4">
                                <div class="form-group">
                                    <label>Procedencia:</label>
                                    <select id="selProc" class="form-control"></select>
                                </div>
                                <div class="form-group">
                                    <label>Previsión:</label>
                                    <select id="selPrev" class="form-control"></select>
                                </div>
                            </div>
                            <div class="col-12 col-sm-6 col-md-4">
                                <div class="form-group">
                                    <label>Programa:</label>
                                    <select id="selProg" class="form-control"></select>
                                </div>
                                <div class="form-group">
                                    <label>Sub Programa:</label>
                                    <select id="selSubP" class="form-control"></select>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="row">
                                    <div class="col-6">
                                        <button id="btnSearch1" class="btn btn-block btn-primary">
                                            <i class="fa fa-search" aria-hidden="true"></i>
                                            <span>Buscar</span>
                                        </button>
                                    </div>
                                    <div class="col-6">
                                        <button id="btnExcel1" class="btn btn-block btn-success">
                                            <i class="fa fa-file-excel-o" aria-hidden="true"></i>
                                            <span>Excel</span>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-sm-12 col-md-6">
                        <div class="row">
                            <div class="col-12 col-sm-6 col-md-4">
                                <div class="form-group">
                                    <label>N° Preingreso:</label>
                                    <input type="text" id="txtN_Pre" class="form-control" />
                                </div>
                                <div class="form-group">
                                    <label>DNI:</label>
                                    <input type="text" id="txtP_Dni" class="form-control" />
                                </div>
                            </div>
                            <div class="col-12 col-sm-6 col-md-4">
                                <div class="form-group">
                                    <label>N° Atención:</label>
                                    <input type="text" id="txtN_Ate" class="form-control" />
                                </div>
                                <div class="form-group">
                                    <label>Nombre Pac:</label>
                                    <input type="text" id="txtP_Name" class="form-control" />
                                </div>
                            </div>
                            <div class="col-12 col-sm-6 col-md-4">
                                <div class="form-group">
                                    <label>RUT:</label>
                                    <input type="text" id="txtP_Rut" class="form-control" />
                                </div>
                                <div class="form-group">
                                    <label>Apellido Pac:</label>
                                    <input type="text" id="txtP_Last" class="form-control" />
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="row">
                                    <div class="col-6">
                                        <button id="btnSearch2" class="btn btn-block btn-primary">
                                            <i class="fa fa-search" aria-hidden="true"></i>
                                            <span>Buscar</span>
                                        </button>
                                    </div>
                                    <div class="col-6">
                                        <button id="btnExcel2" class="btn btn-block btn-success">
                                            <i class="fa fa-file-excel-o" aria-hidden="true"></i>
                                            <span>Excel</span>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="card">
            <div class="card-header">
                <h5>Tabla de Resultados</h5>
            </div>
            <div class="card-body" id="divTable">

            </div>
        </div>
    </div>

    
    <!-- Modales -->
    <div id="mdlEmpty" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Aviso</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                    <p>Para realizar este tipo de búsqueda debe de tener al menos uno de los campos con algún valor introducido.</p>
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
                        <strong>Póngase en contacto con IrisLab para asistencia técnica.</strong>
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
</asp:Content>
