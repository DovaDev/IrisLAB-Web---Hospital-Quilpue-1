Imports System.Web
Imports Negocio
Imports Entidades
Public Class Crear_Asunto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Graba_Asunto(ByVal ASUNTO As String, ByVal TEXT As String, ByVal DOC As String, ByVal IMG As String) As Integer
        'Crar Asunto
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER_1 As Integer = CInt(objSession("ID_USER"))
        Dim ID_USER_2 As Integer = 48
        Dim FECHA As DateTime = DateTime.Now
        Dim TIPO As Integer

        Dim NN_ASUNTO As New N_IRIS_WEBF_CMVM_GRABA_ASUNTO
        Dim ID_MSG_ASUNTO As Integer
        ID_MSG_ASUNTO = NN_ASUNTO.IRIS_WEBF_CMVM_GRABA_ASUNTO(ASUNTO, ID_USER_1, ID_USER_2, FECHA)

        If ID_MSG_ASUNTO <> 0 Then
            'Grabar Texto
            If TEXT <> "" Then
                TIPO = 1
                Dim G_Text As Integer = NN_ASUNTO.IRIS_WEBF_CMVM_GRABA_ASUNTO_MSG(ID_MSG_ASUNTO, ID_USER_1, TIPO, TEXT, FECHA)
                If (G_Text = 0) Then
                    Return 2
                End If
            End If
            'Grabar Documento
            If DOC <> "" Then
                TIPO = 2
                Dim G_Doc As Integer = NN_ASUNTO.IRIS_WEBF_CMVM_GRABA_ASUNTO_MSG(ID_MSG_ASUNTO, ID_USER_1, TIPO, DOC, FECHA)
                If (G_Doc = 0) Then
                    Return 3
                End If
            End If
            'Grabar Imagen
            If IMG <> "" Then
                TIPO = 3
                Dim G_Img As Integer = NN_ASUNTO.IRIS_WEBF_CMVM_GRABA_ASUNTO_MSG(ID_MSG_ASUNTO, ID_USER_1, TIPO, IMG, FECHA)
                If (G_Img = 0) Then
                    Return 4
                End If
            End If
            Return 1
        Else
            Return 0
        End If

    End Function
End Class