<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Conf_User.aspx.vb" Inherits="Presentacion.Conf_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%@ OutputCache Location="None" NoStore="true" %>

    <link href="/js/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="/js/datepicker/js/bootstrap-datepicker.js"></script>
    <script src="/js/datepicker/locales/bootstrap-datepicker.es.min.js"></script>

    <link href="/vendor/datatables/dataTables.bootstrap4.css" rel="stylesheet" />
    <script src="/vendor/datatables/jquery.dataTables.js"></script>
    <script src="/vendor/datatables/dataTables.bootstrap4.js"></script>
    <script src="/js/RUT.js"></script>

    <link href="Conf_User.css" rel="stylesheet" />
    <script src="/js/WebForm.js"></script>
    <script src="Conf_User.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div id="divContainer" class="">
        <div class="row">
            <div class="col-sm-12 col-md-4 p-1">
                <div class="card">
                    <div class="card-header">
                        <h5>Configuración</h5>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-12 col-sm-6 col-md-12 col-lg-6">
                                <button type="button" class="btn btn-block btn-sm btn-success mt-0" id="Btn_Add">
                                    <i class="fa fa-user-plus" aria-hidden="true"></i>
                                    <span>Agregar Usuario</span>
                                </button>
                            </div>
                            <div class="col-12 col-sm-6 col-md-12 col-lg-6">
                                <button type="button" class="btn btn-block btn-sm btn-primary mt-0" id="Btn_Edit">
                                    <i class="fa fa-user" aria-hidden="true"></i>
                                    <span>Editar Usuario</span>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card mt-2" id="divData">
                    <div class="card-header">
                        <h5>Datos Usuario</h5>
                    </div>
                    <div class="card-body" style="overflow-x: hidden;">
                        <div class="row">
                            <div class="col-md-12 col-lg-6">
                                <div class="form-group">
                                    <label for="Txt_Nick">Nickname:</label>
                                    <input type="text" class="form-control form-control-sm" id="Txt_Nick" />
                                </div>
                            </div>
                            <div class="col-md-12 col-lg-6">
                                <div class="form-group">
                                    <label for="Sel_Role">Perfil:</label>
                                    <select class="form-control form-control-sm" id="Sel_Role"></select>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="Txt_Pass01">Password:</label>
                                    <input type="text" class="form-control form-control-sm" id="Txt_Pass01" />
                                </div>
                            </div>
                            <div class="col-md-12 col-lg-6">
                                <div class="form-group">
                                    <label for="Txt_FNac">Fecha Nac:</label>
                                    <div id="Txt_FNac"></div>
                                </div>
                            </div>
                            <div class="col-md-12 col-lg-6">
                                <div class="form-group">
                                    <label for="Txt_Rut">RUT:</label>
                                    <input type="text" class="form-control form-control-sm" id="Txt_Rut" placeholder="Ej: 12.345.678-9" />
                                </div>
                            </div>
                            <div class="col-md-12 col-lg-6">
                                <div class="form-group">
                                    <label for="Sel_Proc">Procedencia:</label>
                                    <select class="form-control form-control-sm" id="Sel_Proc"></select>
                                </div>
                            </div>
                            <div class="col-md-12 col-lg-6">
                                <div class="form-group">
                                    <label for="Sel_Prev">Previsión:</label>
                                    <select class="form-control form-control-sm" id="Sel_Prev"></select>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="Txt_Nombre">Nombres:</label>
                                    <input type="text" class="form-control form-control-sm" id="Txt_Nombre" />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="Txt_Surn">Apellidos:</label>
                                    <input type="text" class="form-control form-control-sm" id="Txt_Surn" />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="Txt_Direct">Dirección:</label>
                                    <input type="text" class="form-control form-control-sm" id="Txt_Direct" />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="Txt_Email">E-mail:</label>
                                    <input type="text" class="form-control form-control-sm" id="Txt_Email" />
                                </div>
                            </div>
                            <div class="col-md-12 col-lg-6">
                                <div class="form-group">
                                    <label for="Txt_Fono">Fono:</label>
                                    <input type="text" class="form-control form-control-sm" id="Txt_Fono" />
                                </div>
                            </div>
                            <div class="col-md-12 col-lg-6">
                                <div class="form-group">
                                    <label for="Txt_Cel">Celular:</label>
                                    <input type="text" class="form-control form-control-sm" id="Txt_Cel" />
                                </div>
                            </div>
                            <div class="col-md-12 col-lg-6">
                                <div class="form-group">
                                    <label for="Sel_Cudad">Ciudad:</label>
                                    <select class="form-control form-control-sm" id="Sel_Ciudad"></select>
                                </div>
                            </div>
                            <div class="col-md-12 col-lg-6">
                                <div class="form-group">
                                    <label for="Sel_Comuna">Comuna:</label>
                                    <select class="form-control form-control-sm" id="Sel_Comuna"></select>
                                </div>
                            </div>
                            <div class="col-md-12 col-lg-6">
                                <div class="form-group">
                                    <label for="Sel_Profesion">Profesión:</label>
                                    <select class="form-control form-control-sm" id="Sel_Profesion"></select>
                                </div>
                            </div>
                            <div class="col-md-12 col-lg-6">
                                <div class="form-group">
                                    <label for="Sel_Cargo">Cargo:</label>
                                    <select class="form-control form-control-sm" id="Sel_Cargo"></select>
                                </div>
                            </div>
                            <div class="col-md-12 col-lg-6">
                                <div class="form-group">
                                    <label for="Sel_Estado">Estado:</label>
                                    <select class="form-control form-control-sm" id="Sel_Estado"></select>
                                </div>
                            </div>
                            <div class="col-md-12 col-lg-6">
                                <div class="form-group mb-0">
                                    <label for="Inp_Image">Firma:</label>
                                    <div class="custom-file" style="display: block;">
                                        <input type="file" id="Inp_Image" class="custom-file-input" />
                                        <span class="custom-file-control form-control-sm" style="border-color: #868e96;"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <button type="button" class="btn btn-block btn-sm btn-success" id="Btn_Save">
                                        <i class="fa fa-floppy-o" aria-hidden="true"></i>
                                        <span>Guardar</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12 col-md-8 p-1">
                <div class="card card-table">
                    <div class="card-header">
                        <h5>Tabla de Usuarios</h5>
                    </div>
                    <div class="card-body" id="divTable">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modales -->
    <div id="lbl_Message" class="float-lbl-container" style="display: none;">
        <div class="float-lbl-content">
            <i class="fa fa-exclamation-circle" aria-hidden="true"></i>
            <p>Usuario editado <strong>correctamente.</strong></p>
        </div>
    </div>

    <div id="mdlData" class="modal" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-fade" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title"></h5>
                </div>
                <div class="modal-body">

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-sm btn-primary" data-dismiss="modal">
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
</asp:Content>
