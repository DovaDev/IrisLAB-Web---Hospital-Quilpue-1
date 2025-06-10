Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization
Public Class F_Ate_Pac
    Inherits System.Web.UI.Page

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (C_P_ADMIN.Value)
            Case 0
                Response.Redirect("~/Index.aspx")
        End Select
    End Sub

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal RUT As String) As List(Of E_IRIS_WEBF_BUSCA_RUT_PRE_INGRESO_PACIENTE_SIN_FECHA)
        'Declaraciones internas
        Dim data_det_ate As List(Of E_IRIS_WEBF_BUSCA_RUT_PRE_INGRESO_PACIENTE_SIN_FECHA)
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_RUT_PRE_INGRESO_PACIENTE_SIN_FECHA = New N_IRIS_WEBF_BUSCA_RUT_PRE_INGRESO_PACIENTE_SIN_FECHA
        Dim caca As Integer = 0
        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_RUT_PRE_INGRESO_PACIENTE_SIN_FECHA(RUT)
        Return data_det_ate
    End Function
End Class
