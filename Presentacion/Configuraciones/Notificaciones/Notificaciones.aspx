<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Notificaciones.aspx.vb" Inherits="Presentacion.Notificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <link href="/css/Iris_Css.css" rel="stylesheet" />
    <script src="Notificaciones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <%--<div class="container">--%>
    <div class="card border-bar">
        <div class="card-header bg-bar text-center">
            <h4 class="m-0">Crear Notificaciones de Sistema</h4>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <label for="slt_Tipo">Tipo:</label>
                    <select class="form-control" id="slt_Tipo">
                        <option value="1">Cache</option>
                        <option value="2">Sistema</option>
                        <option value="3">Mantención</option>
                        <option value="4">Otro</option>
                    </select>
                </div>
                <div class="col-lg">
                    <label for="txt_Durac">Fecha Desde:</label>
                    <div class='input-group date' id='Txt_Date01'>
                        <input type='text' id="fecha" class="form-control" readonly="true" placeholder="" />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label for="txt_Durac">Fecha Hasta:</label>
                    <div class='input-group date' id='Txt_Date02'>
                        <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="" />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label>Permanente:</label><br />
                    <label class="form-check-label">
                        <input class="form-check-input" type="checkbox" id="chk_perma">
                        Permanente
                    </label>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-lg">
                    <label for="txt_Msg">Mensaje:</label>
                    <textarea id="txt_Msg" class="form-control" maxlength="250"></textarea>
                </div>
            </div>
            <hr />
            <div class="row mt-3">
                <div class="col-lg-3 text-center">
                    <%-- <label class="form-check-label">
                            <input class="form-check-input" type="checkbox">
                            Todos
                        </label>--%>
                </div>
                <div class="col-lg-3 text-center">
                    <%--<label class="form-check-label">
                            <input class="form-check-input" type="checkbox">
                            Todos
                        </label>--%>
                </div>
                <div class="col-lg-6 text-center">
                    <label class="form-check-label">
                        <input class="form-check-input" type="checkbox" id="chk_todos">
                        Seleccionar Todos
                    </label>
                </div>
            </div>
            <div class="row mt-3 p-2">
                <div class="col-lg-3" style="max-height: 45vh; overflow: auto;">
                    <label>Procedencia:</label>
                    <table id="Dtt_Proce" class="table table-hover table-striped table-iris" cellspacing="0">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Procedencia</th>
                                <th>Check</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
                <div class="col-lg-3" style="max-height: 45vh; overflow: auto;">
                    <label>Previsión:</label>
                    <table id="Dtt_Preve" class="table table-hover table-striped table-iris" cellspacing="0">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Previsión</th>
                                <th>Check</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
                <div class="col-lg-6" style="max-height: 45vh; overflow: auto;">
                    <label>Usuario:</label>
                    <table id="Dtt_Usu" class="table table-hover table-striped table-iris" cellspacing="0">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Nick</th>
                                <th>Usuario</th>
                                <th>Prodecencia</th>
                                <th>Previsión</th>
                                <th>Tipo</th>
                                <th>Check</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-lg-3 text-center">
                    <button class="btn btn-buscar" id="btn_proce_RNUM">Guardar por Procedencia</button>                    
                </div>
                <div class="col-lg-3 text-center">
                    <button class="btn btn-buscar" id="btn_preve_RNUM">Guardar por Previsión</button>
                </div>
                <div class="col-lg-6 text-center">
                    <button class="btn btn-buscar" id="btn_guardar_RNUM">Guardar por Usuario</button>
                </div>
            </div>
        </div>
    </div>
    <%-- </div>--%>
</asp:Content>
