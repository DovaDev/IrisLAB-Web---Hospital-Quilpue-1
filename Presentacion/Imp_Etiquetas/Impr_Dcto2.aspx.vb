Imports Entidades
Imports Negocio

Public Class Impr_Dcto2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()>
    Public Shared Function GET_Sel_Proc(ByVal ID_PREV As Integer) As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim NNN As New N_Gen_Activos

        Return NNN.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO_BY_ID_PREV(ID_PREV)
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_Sel_Prev(ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim NNN As New N_Gen_Activos

        Return NNN.IRIS_WEBF_BUSCA_PREVISION_ACTIVO_BY_ID_PROC(ID_PROC)
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_Sel_Prog() As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        Dim NNN As New N_Gen_Activos

        Return NNN.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO()
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_Sel_SubP(ByVal ID_PREV As Long, ByVal ID_PROG As Long) As List(Of E_IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG)
        Dim NNN As New N_Gen_Activos

        Return NNN.IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG(ID_PREV, ID_PROG)
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_DataTable_Filther_1(ByVal DESDE As Date, ByVal HASTA As Date,
                                                   ByVal ID_PROC As Long, ByVal ID_PREV As Long,
                                                   ByVal ID_PROG As Long, ByVal ID_SUBP As Long) As List(Of E_IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER)
        Dim NNN As New N_Impr_Dcto2

        Return NNN.IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER_1(DESDE, HASTA, ID_PROC, ID_PREV, ID_PROG, ID_SUBP)
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_DataTable_Filther_2(ByVal PRE_NUM As String, ByVal ATE_NUM As String, ByVal PAC_RUT As String,
                                                   ByVal PAC_DNI As String, ByVal PAC_NAME As String, ByVal PAC_LAST As String) As List(Of E_IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER)
        Dim NNN As New N_Impr_Dcto2

        Return NNN.IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER_2(PRE_NUM, ATE_NUM, PAC_RUT, PAC_DNI, PAC_NAME, PAC_LAST)
    End Function
End Class