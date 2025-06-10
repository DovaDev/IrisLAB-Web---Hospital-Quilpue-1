<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Exa_Esp_V.aspx.vb" Inherits="Presentacion.Exa_Esp_V" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="Exa_Esp_V.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <style>
        
    </style>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div class="card border-bar">
                <div class="card-header bg-bar">
                    <h5>
                        <i class="fa fa-info"></i>
                        Cambio de estado Paciente
                    </h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-2"></div>
                        <div class="col-lg">
                            <label for="txtNAte">N° Atención:</label>
                            <input id="txtNAte" maxlength="9" class="form-control textoReducido" type="text" placeholder="BUSCAR..." />
                            <button id="Btn_Buscar_x_ate" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar por Num. de Atención</button>
                        </div>

                        <div class="col-lg-2"></div>
                    </div>
                </div>
            </div>
            <div class="col-lg-1"></div>

        </div>
    </div>
    <div class="row" id="datos_pac">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div class="card border-bar">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-1 text-center pt-3">
                            <i class="fa fa-user fa-5x" style="color: #00738e"></i>
                        </div>
                        <div class="col-lg">
                            <h5>Datos Paciente:</h5>
                            <div class="row">
                                <label class="col-3 col-form-label pt-0 pb-0 m-0">RUT:</label>
                                <div class="col-9">
                                    <label id="Rut" class="m-0"></label>
                                </div>
                            </div>
                            <div class="row">
                                <label class="col-3 col-form-label pt-0 pb-0 m-0">Nombre:</label>
                                <div class="col-9 text-uppercase">
                                    <label id="Nombre" class="m-0"></label>
                                </div>
                            </div>
                            <div class="row">
                                <label class="col-3 col-form-label pt-0 pb-0 m-0">Sexo:</label>
                                <div class="col-9 text-uppercase">
                                    <label id="Sexo" class="m-0"></label>
                                </div>
                            </div>
                            <div class="row">
                                <label class="col-3 col-form-label pt-0 pb-0 m-0">Fecha Nac:</label>
                                <div class="col-9 text-uppercase">
                                    <label id="FechaNac" class="m-0"></label>
                                </div>
                            </div>

                        </div>
                        <div class="col-lg">
                            <h5>Datos Atención:</h5>
                            <div class="row">
                                <label class="col-3 col-form-label pt-0 pb-0 m-0">Numero de Orden:</label>
                                <div class="col-9">
                                    <label id="NumOrden" class="m-0"></label>
                                </div>
                            </div>
                            <div class="row">
                                <label class="col-3 col-form-label pt-0 pb-0 m-0">Fecha Ingeso:</label>
                                <div class="col-9">
                                    <label id="FechaIng" class="m-0"></label>
                                </div>
                            </div>
                            <div class="row">
                                <label class="col-3 col-form-label pt-0 pb-0 m-0">Lugar TM:</label>
                                <div class="col-9 text-uppercase">
                                    <label id="LugarTM" class="m-0"></label>
                                </div>
                            </div>
                            <div class="row">
                                <label class="col-3 col-form-label pt-0 pb-0 m-0">Previsión:</label>
                                <div class="col-9 text-uppercase">
                                    <label id="Prevision" class="m-0"></label>
                                </div>
                            </div>

                        </div>
                    </div>
                    <hr>
                    <div class="row">
                        <div class="col-lg-6">
                            <h5>Profesional Solicitante:</h5>
                            <div class="text-left row">
                                <label class="col-sm-3 col-form-label">Nombre:</label>
                                <div class="col-sm-9">
                                    <label id="ProfSol"></label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr id="hrhide" />
                    <div class="row" id="rowhide">
                        <div class="col-lg-12" style="overflow: auto">
                            <h5>Lista de Exámenes</h5>
                            <div id="Div_Tabla"></div>
                            <table id="DataTable" cellspacing="0" class="table table-hover table-striped table-iris table-iris">

                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-1"></div>

        </div>
    </div>
</asp:Content>


