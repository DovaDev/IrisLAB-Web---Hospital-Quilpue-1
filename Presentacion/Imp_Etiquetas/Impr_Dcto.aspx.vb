Imports Entidades
Imports Negocio
Public Class Impr_Dcto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()>
    Public Shared Function Get_Sel_Proc() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim NNN As New N_Gen_Activos
        Dim listIn As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)

        listIn = NNN.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO

        Return listIn
    End Function

    <Services.WebMethod()>
    Public Shared Function Get_Data(ByVal DATE_01 As String, ByVal DATE_02 As String, ByVal ID_PROC As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA3)
        Dim NNN As New N_Impr_Dcto
        Dim listOut As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA3)

        Dim objDate As New N_Date_Operat
        Dim DateA As Date = objDate.strToDate(DATE_01.Split("/")(2), DATE_01.Split("/")(1), DATE_01.Split("/")(0))
        Dim DateB As Date = objDate.strToDate(DATE_02.Split("/")(2), DATE_02.Split("/")(1), DATE_02.Split("/")(0))

        listOut = NNN.IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA3(DateA, DateB, ID_PROC, 0)
        Return listOut
    End Function
End Class