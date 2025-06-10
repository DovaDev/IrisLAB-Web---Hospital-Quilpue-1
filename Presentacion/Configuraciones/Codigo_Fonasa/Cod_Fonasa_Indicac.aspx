<%@ Page Title="Mantenedor Indicaciones" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Cod_Fonasa_Indicac.aspx.vb" Inherits="Presentacion.Cod_Fonasa_Indicac" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="/js/WebForm_2.js"></script>
    <script src="Cod_Fonasa_Indicac.js"></script>

    <style>
        table tbody tr.selected {
            color: #ffffff;
            background-color: #6a55b8!important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="row">
        <div class="col-sm-12 col-md-6">
            <div class="card">
                <div class="card-header">
                    <h5 class="mb-0">Exámenes:</h5>
                </div>
                <div class="card-body" id="dtt_cod_fonasa">

                </div>
            </div>
        </div>
    </div>
</asp:Content>
