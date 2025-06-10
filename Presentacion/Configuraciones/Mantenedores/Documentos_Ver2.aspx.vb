Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Documentos_Ver2
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_DOCUMENTOS2() As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)

        Dim DATA_DOCUMENTO As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        Dim NN_DATA As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS

        DATA_DOCUMENTO = NN_DATA.IRIS_WEBF_BUSCA_DOCUMENTOS2()

        Return DATA_DOCUMENTO
    End Function

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        'If (IsNothing(C_P_ADMIN) = True) Then
        '    Response.Redirect("~/Index.aspx")
        'End If

        'Select Case (C_P_ADMIN.Value)
        '    Case Is <> 1
        '        Response.Redirect("~/Index.aspx")
        'End Select
    End Sub

End Class