<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="btns.aspx.vb" Inherits="Presentacion.btns" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <%--////////////////////// REFERENCIA DE BOTONES //////////////////////--%>

    <%--BUSCAR--%>
    <button type="button" class="btn btn-buscar"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>

    <%--GUARDAR--%>
    <button type="button" class="btn btn-primary"><i class="fa fa-fw fa-save mr-2"></i>Guardar</button>
   
     <%--CERRAR--%>
    <button type="button" class="btn btn-danger"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
    
    <%--IMPRIMIR--%>
    <button type="button" class="btn btn-print"><i class="fa fa-fw fa-print mr-2"></i>Imprimir</button>
    
    <%--ATENDIDO--%>
    <button type="button" class="btn btn-success"><i class="fa fa-fw fa-check mr-2"></i>Atendido</button>
    
    <%--AGENDAR--%>
    <button type="button" class="btn btn-warning"><i class="fa fa-fw fa-book mr-2"></i>Agendar</button>
    
    <%--MODIFICAR--%>
    <button type="button" class="btn btn-info"><i class="fa fa-fw fa-edit mr-2"></i>Modificar</button>
    
    <%--EXCEL--%>
    <button type="button" class="btn btn-success"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
    
    <%--LIMPIAR--%>
    <button type="button" class="btn btn-limpiar"><i class="fa fa-fw fa-eraser mr-2"></i>Limpiar</button>
    
    <%--FLECHA--%>
    <button type="button" class="btn btn-dark"><i class="fa fa-fw fa-arrow-right"></i></button>
    
    <%--PENDIENTE--%>
    <button type="button" class="btn btn-pendiente"><i class="fa fa-fw fa-clock-o mr-2"></i>Pendiente</button>
    
    <%--VER--%>
    <button type="button" class="btn btn-info"><i class="fa fa-fw fa-eye mr-2"></i>Ver</button>
    
    <%--NO ASISTIO--%>
    <button type="button" class="btn btn-danger"><i class="fa fa-fw fa-remove mr-2"></i>No Asistio</button>

    <%--ELIMINAR--%>
    <button type="button" class="btn btn-danger"><i class="fa fa-fw fa-remove mr-2"></i>Eliminar</button>
    <br />

  
</asp:Content>
