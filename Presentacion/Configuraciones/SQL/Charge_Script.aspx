<%@ Page Title="Carga de Script" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Charge_Script.aspx.vb" Inherits="Presentacion.Charge_Script" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <style>
        .result {
            margin-top: 15px;
            color: green;
        }

        .error {
            margin-top: 15px;
            color: red;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="container">
        <h2>Cargar Script SQL</h2>
        <asp:FileUpload ID="FileUploadSQL" runat="server" />
        <asp:Button ID="btnUpload" Text="Cargar Script" runat="server" OnClick="btnUpload_Click" />
        <asp:Label ID="lblResult" runat="server" CssClass="result"></asp:Label>
        <asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
