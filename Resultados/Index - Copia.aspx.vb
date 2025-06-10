Imports Entidades
Imports Negocio

Public Class Login_Pacientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()>
    Public Shared Function Login(ByVal RUT As String, ByVal N_ATE As Long, ByVal Date_ATE As Integer()) As String
        Dim objN As New N_Login2
        Dim objList As New List(Of E_IRIS_WEBF_00_ASPX_LOGIN_PACIENTES)

        Dim Date_Parser As New N_Date_Operat
        Dim Date_01 As Date = Date_Parser.strToDate(Date_ATE(2), Date_ATE(1), Date_ATE(0))

        Dim Encrypt As New N_Encrypt
        objList = objN.IRIS_WEBF_00_ASPX_LOGIN_PACIENTES(RUT, N_ATE, Date_01)

        If (objList.Count = 0) Then
            Return Nothing
        End If

        Dim Response As HttpCookieCollection = HttpContext.Current.Response.Cookies
        Response("ID_ATE").Value = Encrypt.Encode(objList(0).ID_ATENCION)
        Response("ID_ATE").Expires = DateAdd(DateInterval.Minute, 30, Date.Now)

        Dim strOut As String = "Det_Atenc.aspx?ID_ATE=" & Encrypt.Encode(objList(0).ID_ATENCION)

        Return strOut
    End Function
End Class