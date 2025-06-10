<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="C_Copia_Lote.aspx.vb" Inherits="Presentacion.C_Copia_Lote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-2 p-2">
            <li class="breadcrumb-item"><a href="/QC/Menu_QC.aspx">Menú</a></li>
            <li class="breadcrumb-item"><a href="/QC/Menu_Conf.aspx">Configuración</a></li>
            <li class="breadcrumb-item active" aria-current="page">Copiar Lote</li>
        </ol>
    </nav>
    <div class="card border-bar">
        <div class="card-header bg-bar text-center">
            <h3 class="m-0">Copiar Lote
            </h3>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <label for="slt_Origen">Origen</label>
                    <select id="slt_Origen" class="form-control form-control-sm">
                    </select>
                </div>
                <div class="col-lg-2"></div>
                <div class="col-lg">
                    <label for="slt_A_Origen">Analizador</label>
                    <select id="slt_A_Origen" class="form-control form-control-sm">
                    </select>
                </div>
            </div>
            <div class="row">
                <div class="col-lg">
                    <label for="slt_Destino">Destino</label>
                    <select id="slt_Destino" class="form-control form-control-sm">
                    </select>
                </div>
                <div class="col-lg-2"></div>
                <div class="col-lg">
                    <label for="slt_A_Destino">Analizador</label>
                    <select id="slt_A_Destino" class="form-control form-control-sm">
                    </select>
                </div>
            </div>
            <div class="row mt-3" style="height: 49vh">
                <div class="col-lg">
                    <table id="DataTable" class="table table-hover table-striped table-iris">
                        <thead>
                            <tr>
                                <th>Analito</th>
                                <th>Limite Inferior</th>
                                <th>Limite Superior</th>
                                <th>Media</th>
                                <th>Desviación</th>
                                <th>ID_P</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-lg">
                    <button type="button" class="btn btn-primary btn-sm btn-block mt-0" id="btn_Update"><i class="fa fa-refresh fa-fw"></i>Actualizar Valores</button>
                </div>
                <div class="col-lg-2"></div>
                <div class="col-lg">
                    <button type="button" class="btn btn-danger btn-sm btn-block mt-0" id="btn_Close"><i class="fa fa-times fa-fw"></i>Salir</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
