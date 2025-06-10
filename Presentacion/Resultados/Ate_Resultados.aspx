<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Ate_Resultados.aspx.vb" Inherits="Presentacion.Ate_Resultados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">


    <script src="/js/WebForm.js"></script>
    <script src="Ate_Resultados.js"></script>

    <style>
        table {
            border-collapse: collapse!important;
        }

        table td {
            height: 35px;
        }

        table td:nth-child(5) {
            padding: 0px!important;
        }

        table input[type=text] {
            width: calc(100% - 4px);
            height: calc(100% - 4px);

            border: none;
            background: #ffffff;
    
            padding: 2px 10px 2px 10px;
            box-shadow: 0 0 0 2px rgba(0,0,0,.1);
            border-radius: 3px;
            box-sizing: border-box;
        }

        table input[type=text] {
            -webkit-transition-duration: 0.25s;
            transition-duration: 0.25s;
        }

        table .input_error[type=text] {
            -webkit-transition-duration: 0.25s;
            transition-duration: 0.25s;

            box-shadow: 0 0 0 2px rgba(231, 43, 43, 0.75);
        }

        table tr:hover input[type=text] {
            -webkit-transition-duration: 0.25s;
            transition-duration: 0.25s;
    
            width: calc(100% - 12.5px);
            height: calc(100% - 12.5px);
    
            margin: 5px;
            box-shadow: 0 0 0 5px rgba(0,123,255,.25);
        }

        .tr_selected input[type=text] {
            -webkit-transition-duration: 0.25s;
            transition-duration: 0.25s;
    
            padding: 2px 10px 2px 10px;
            box-shadow: 0 0 0 2px rgba(0,123,255,.6);
        }

        .tr_selected:hover input[type=text] {
            -webkit-transition-duration: 0.25s;
            transition-duration: 0.25s;
    
            padding: 2px 10px 2px 10px;
            box-shadow: 0 0 0 5px rgba(0,123,255,.6);
        }


        input[class="input_error"] {
            color: #ff0000;
            box-shadow: 0 0 0 2px #ff0000!important;
        }

        .tr_selected:hover input[class="input_error"] {
            -webkit-transition-duration: 0.25s;
            transition-duration: 0.25s;
    
            padding: 2px 10px 2px 10px;
            box-shadow: 0 0 0 5px #ff0000!important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="card mb-2">
        <div class="card-header">
            <h5>Detalles Atención</h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-12 col-sm-4">
                    <div class="row">
                        <div class="col-6 col-sm-12 col-md-12 col-lg-6">
                            <label>N° Ate:</label>
                            <div class="input-group pb-3">
                                <div class="input-group-btn">
                                    <button type="button" class="btn btn-primary btn-sm">
                                        <i class="fa fa-chevron-left" aria-hidden="true"></i>
                                    </button>
                                    <button type="button" class="btn btn-primary btn-sm">
                                        <i class="fa fa-chevron-right" aria-hidden="true"></i>
                                    </button>
                                </div>
                                <input type="text" id="Txt_NumAte" class="form-control form-control-sm"/>
                            </div>
                        </div>
                        <div class="col-6 col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                                <label>Fecha:</label>
                                <input type="text" id="Txt_DateAte" class="form-control form-control-sm" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-sm-8">
                    <div class="row">
                        <div class="col-md-12 col-lg-6">
                            <div class="form-group">
                                <label>Nombre Paciente:</label>
                                <input type="text" id="Txt_Nombre" class="form-control form-control-sm" />
                            </div>
                        </div>
                        <div class="col-md-12 col-lg-6">
                            <div class="row">
                                <div class="col-4">
                                    <div class="form-group">
                                        <label>Edad:</label>
                                        <input type="text" id="Txt_Edad" class="form-control form-control-sm" />
                                    </div>
                                </div>
                                <div class="col-4">
                                    <div class="form-group">
                                        <label>Sexo:</label>
                                        <input type="text" id="Txt_Sexo" class="form-control form-control-sm" />
                                    </div>
                                </div>
                                <div class="col-4">
                                    <div class="form-group">
                                        <label>F.U.R.:</label>
                                        <input type="text" id="Txt_FUR" class="form-control form-control-sm" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!---->
                <div class="col-12 col-sm-6 col-md-4 col-lg-2">
                    <div class="form-group">
                        <label>Previsión:</label>
                        <select id="Sel_Prev" class="form-control form-control-sm">
                        </select>
                    </div>
                </div>
                <div class="col-12 col-sm-6 col-md-4 col-lg-2">
                    <div class="form-group">
                        <label>Procedencia:</label>
                        <select id="Sel_Proc" class="form-control form-control-sm">
                        </select>
                    </div>
                </div>
                <div class="col-12 col-sm-6 col-md-4 col-lg-2">
                    <div class="form-group">
                        <label>Programa:</label>
                        <select id="Sel_Prog" class="form-control form-control-sm">
                        </select>
                    </div>
                </div>
                <div class="col-12 col-sm-6 col-md-6 col-lg-2">
                    <div class="form-group">
                        <label>Sección:</label>
                        <select id="Sel_Secc" class="form-control form-control-sm">
                        </select>
                    </div>
                </div>
                <div class="col-sm-12 col-md-6 col-lg-4">
                    <div class="form-group">
                        <label>Exámen:</label>
                        <select id="Sel_Exam" class="form-control form-control-sm">
                        </select>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="card">
        <div class="card-header">
            <h5>Resultados Atención</h5>
        </div>
        <div class="card-body" id="Dtt_Exam">

        </div>
    </div>
    
    <!-- Modales -->
    <div id="mdlLoading" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Cargando</h4>
                </div>
                <div class="modal-body pt-6 pb-6 text-center"">
                    <i class="fa fa-spinner fa-pulse fa-5x fa-fw"></i>
                </div>
            </div>
        </div>
    </div>

    <div id="mdlRange" class="modal fade" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Aviso</h4>
                </div>
                <div class="modal-body pt-6 pb-6 text-left">

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn-primary" data-dismiss="modal">
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
