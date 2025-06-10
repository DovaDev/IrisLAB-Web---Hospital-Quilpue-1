Imports Negocio
Imports Entidades
Public Class Login1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    <Services.WebMethod()>
    Public Shared Function User_Login(ByVal xUser As String, xPass As String) As E_Login2
        Dim thisPage As HttpContext = HttpContext.Current
        Dim nLogin As New N_Login2
        Dim itemUser As New E_Login2

        'itemUser = nLogin.Login2(xUser, xPass)
        itemUser = nLogin.IRIS_WEBF_CMVM_00_ASPX_LOGIN_NEW_IMED(xUser, xPass)


        If (itemUser.LOGGED = True) Then
            Dim objSession As HttpSessionState = HttpContext.Current.Session
            objSession("LOGGED") = itemUser.LOGGED
            objSession("ID_USER") = itemUser.ID_USER
            objSession("NICKNAME") = itemUser.NICKNAME
            objSession("NAME") = itemUser.NAME
            objSession("SURNAME") = itemUser.SURNAME
            objSession("P_ADMIN") = itemUser.P_ADMIN
            objSession("USU_ID_PROC") = itemUser.USU_ID_PROC
            objSession("USU_PREV") = itemUser.USU_PREV
            objSession("ID_PROF") = itemUser.ID_PROF
            objSession("USU_RUT_IMED") = itemUser.USU_RUT_IMED
            objSession("USU_PASS_IMED") = itemUser.USU_PASS_IMED
            objSession.Timeout = 30
        End If

        Return itemUser
    End Function



#Region "CODIGO ANTIGUO"
    'Public Shared Function User_Login(ByVal xUser As String, xPass As String) As E_Login2
    '    Dim thisPage As HttpContext = HttpContext.Current
    '    Dim nLogin As New N_Login2
    '    Dim itemUser As New E_Login2

    '    itemUser = nLogin.Login2(xUser, xPass)

    '    If (itemUser.LOGGED = True) Then
    '        Dim objSession As HttpSessionState = HttpContext.Current.Session
    '        objSession("LOGGED") = itemUser.LOGGED
    '        objSession("ID_USER") = itemUser.ID_USER
    '        objSession("NICKNAME") = itemUser.NICKNAME
    '        objSession("NAME") = itemUser.NAME
    '        objSession("SURNAME") = itemUser.SURNAME
    '        objSession("P_ADMIN") = itemUser.P_ADMIN
    '        objSession("USU_TM") = itemUser.USU_TM

    '        objSession.Timeout = 30
    '    End If

    '    Return itemUser
    'End Function
#End Region

    <Services.WebMethod()>
    Public Shared Function User_Logout() As Boolean
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        objSession.Clear()
        objSession.Abandon()

        Return True
    End Function
End Class