<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Impr_Etiq.aspx.vb" Inherits="Presentacion.Impr_Etiq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%@ OutputCache Location="None" NoStore="true" %>

    <link href="/js/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="/js/datepicker/js/bootstrap-datepicker.js"></script>

    <link href="/js/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="/js/datepicker/locales/bootstrap-datepicker.es.min.js"></script>

    <link href="/vendor/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="/css/Load_Modal.css" rel="stylesheet" />
    <script type="module" src="Impr_Etiq.js?version=<%= DateTime.Now.ToString() %>"></script>

    <style>
        input[type=text]:read-only {
            background: #ffffff;
        }

        button {
            cursor: pointer;
        }

        .div-button {
            text-align: end;
        }

        #divTable table th {
            text-align: center;
        }

        #divTable table td {
            vertical-align: central;
        }
        
        input[type=checkbox] ~ .div-chk i {
            font-size: 20px;
        }
        
        input[type=checkbox] ~ .div-chk i:nth-child(1) {
            display: inherit;
        }

        input[type=checkbox] ~ .div-chk i:nth-child(2) {
            display: none;
        }

        input[type=checkbox]:checked ~ .div-chk i:nth-child(1) {
            display: none;
        }

        input[type=checkbox]:checked ~ .div-chk i:nth-child(2) {
            display: inherit;
        }

        @media (max-width: 575.98px) {
            .div-button {
                display: flex;
                display: -webkit-flex;
                justify-content: space-between;
            }
        }
        
        .grid-input-imprim-etiq {
            align-self: center;
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(120px, 1fr));
            gap: 1rem;
            align-items: center;
            grid-auto-flow: dense;
            place-content: center;
            margin: 1rem 0rem;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
       <div class="p-2">
        <div class="card border-bar">
            <div class="card-header bg-bar">
                <h5 class="mb-0">Etiquetas</h5>
            </div>
            <div class="card-body">
                <div class="grid-input-imprim-etiq">

                    <div>
                        <label>Desde:</label>
                        <input type="date" id="txt-desde" class="form-control form-control-sm" />
                    </div>
                    
                    <div>
                        <label>Hasta:</label>
                        <input type="date" id="txt-hasta" class="form-control form-control-sm" />
                    </div>

                    <div>
                        <label>Procedencia:</label>
                        <select class="form-control form-control-sm" id="slct-procedencia" tabindex="2"></select>
                    </div>
                    <div>
                        <label>Área:</label>
                        <select class="form-control form-control-sm" id="slct-area" tabindex="2"></select>
                    </div>
                    <div>
                        <label>Sección:</label>
                        <select class="form-control form-control-sm" id="slct-seccion" tabindex="2"></select>
                    </div>
                                      
                    <div>
                        <label>Examen:</label>
                        <select class="form-control form-control-sm" id="slct-examen" tabindex="2"></select>
                    </div>

                    <button type="button" class="btn btn-primary" id="btn-buscar-filtro">
                        <i class="fa fa-search" aria-hidden="true"></i>
                        <span>Buscar</span>
                    </button>

                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#mdlSearch">
                        <i class="fa fa-search" aria-hidden="true"></i>
                        <span>Folio</span>
                    </button>

                    <button type="button" class="btn btn-danger" id="Btn_Print">
                        <i class="fa fa-print" aria-hidden="true"></i>
                        <span>Imprimir</span>
                    </button>

                    <button type="button" class="btn btn-success" id="Btn_Export">
                        <i class="fa fa-file-excel-o" aria-hidden="true"></i>
                        <span>Exportar</span>
                    </button>





                    
                </div>

                <div class="row">
                    <div class="col-12 table-responsive" id="divData">
                    </div>
                    <div class="col-12 table-responsive" id="divTable">
                        <div class="alert alert-info mb-0">
                            <span>Use los filtros para buscar etiquetas.</span>
                        </div>
                    </div>
                    <div class="col-6">
                        <button type="button" class="btn mt-3" id="Btn_ChkFull">
                            <i class="fa fa-check-square-o" aria-hidden="true"></i>
                            <span>Todos</span>
                        </button>
                    </div>
                    <div class="col-6 div-button">
                        <button type="button" class="btn mt-3" id="Btn_ChkEmpty">
                            <i class="fa fa-square-o" aria-hidden="true"></i>
                            <span>Ninguno</span>
                        </button>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <div id="mdlPrint" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
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

    <div id="mdlExport" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Planilla Excel</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                    <p data-found="true">El archivo solicitado se ha generado correctamente, si no se inicia automáticamente la descarga haga click en <a href="#">Este Enlace.</a></p>
                    <p data-found="false">La búsqueda solicitada no devuelve resultados, por lo cual el archivo no ha sido creado.</p>
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

    <div class="modal fade" tabindex="-1" role="dialog" id="mdlSearch" data-backdrop="static">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Búsqueda</h5>
                </div>
                <div class="modal-body">
                    <div class="form-group date">
                        <label>Nro Atención:</label>
                        <div class="input-group">
                            <input type="text" class="form-control" id="Txt_Nate" tabindex="1" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="Btn_Search" data-dismiss="modal">
                        <i class="fa fa-search" aria-hidden="true"></i>
                        <span>Buscar</span>
                    </button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">
                        <i class="fa fa-times" aria-hidden="true"></i>
                        <span>Cerrar</span>
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
