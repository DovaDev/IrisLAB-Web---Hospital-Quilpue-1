<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Impr_Dcto.aspx.vb" Inherits="Presentacion.Impr_Dcto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <link href="/js/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="/js/datepicker/js/bootstrap-datepicker.js"></script>
    <script src="/js/datepicker/locales/bootstrap-datepicker.es.min.js"></script>

    <link href="../css/Load_Modal.css" rel="stylesheet" />
    <script src="Impr_Dcto.js"></script>

    <style>
        .card-body th {
            padding: 5px;
            color: #ffffff;
            background: #28a745;
        }

        .card-body tbody button {
            background: #ff8500;
            border-color: #f89830;
        }

        .card-body tbody button:disabled {
            background: #ffc689;
            border-color: #ffc689;
        }

        input[type=text] {
            color: #212529!important;
            background: #ffffff!important;
        }

        div:host(#Btn_Search) {
            padding-left: 1rem;
            padding-right: 1rem;
        }

        @media (min-width: 576px) {
            #Btn_Search {
                margin-top: 2rem;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="m-2">
        <div class="card">
            <div class="card-header text-center">
                <h5>Impresión de Documentos</h5>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-12 col-sm-6 col-md-3">
                        <div class="form-group form-control-sm">
                            <label>Desde:</label>
                            <div class="input-group date">
                                <input type="text" id="Txt_Date01" class="form-control form-control-sm" readonly="" tabindex="1" style="cursor: pointer;" />
                                <span class="input-group-addon" style="">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-sm-6 col-md-3">
                        <div class="form-group form-control-sm">
                            <label>Hasta:</label>
                            <div class="input-group date">
                                <input type="text" id="Txt_Date02" class="form-control form-control-sm" readonly="" tabindex="2" style="cursor: pointer;" />
                                <span class="input-group-addon" style="">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-sm-6 col-md-3">
                        <div class="form-group form-control-sm">
                            <label>Procedencia:</label>
                            <select class="form-control form-control-sm" id="Sel_Proc" tabindex="2"></select>
                        </div>
                    </div>
                    <div class="col-12 col-sm-6 col-md-3 pl-4 pr-4">
                        <button type="button" class="btn btn-sm btn-block btn-primary" id="Btn_Search">
                            <i class="fa fa-search" aria-hidden="true"></i>
                            <span>Buscar</span>
                        </button>
                    </div>
                </div>
            </div>
        </div>

        <div id="divTable" class="card mt-3">
            <div class="card-header">
                <h5>Resultados</h5>
            </div>
            <div class="card-body">
                <div class="alert alert-success m-3">
                    <p>Por favor <strong>seleccione los parámetros</strong> por los cuales desea filtrar la búsqueda.</p>
                </div>
            </div>
        </div>
    </div>

    <!-- Modales -->

    <div id="mdlPrint" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Impresión</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                    <p>Impresión finalizada correctamente</p>
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
