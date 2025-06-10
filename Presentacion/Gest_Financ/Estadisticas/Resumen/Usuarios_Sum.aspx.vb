Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Usuarios_Sum
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl() As List(Of E_IRIS_WEBF_BUSCA_USUARIO2)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Usuarios As New N_Usuario_Sum
        Dim Data_Usuarios_Resumen As New List(Of E_IRIS_WEBF_BUSCA_USUARIO2)
        'Consultar por previsiones activas
        Data_Usuarios_Resumen = NN_Usuarios.IRIS_WEBF_BUSCA_USUARIO2()
        Return Data_Usuarios_Resumen
        'If (Data_Usuarios_Resumen.Count > 0) Then
        '    'Serializar a Json
        '    Serializer.Serialize(Data_Usuarios_Resumen, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_USUARIO As Long, ByVal DATE_str01 As String,
                                                                  ByVal DATE_str02 As String) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_USUARIO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Usuario_Sum As New N_Usuario_Sum
        Dim Data_Usuario_Sum As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_USUARIO)
        Data_Usuario_Sum = NN_Usuario_Sum.IRIS_WEBF_BUSCA_LIS_ADM_RESU_USUARIO(ID_USUARIO, DATE_str01, DATE_str02)
        Return Data_Usuario_Sum
        'If (Data_Usuario_Sum.Count > 0) Then
        '    'Serializar con JSON
        '    Serializer.MaxJsonLength = 999999999
        '    Serializer.Serialize(Data_Usuario_Sum, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal ID_USUARIO As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        Dim NN_Usuario_Sum As New N_Usuario_Sum
        Return NN_Usuario_Sum.Gen_Excel(DOMAIN_URL, ID_USUARIO, DATE_str01, DATE_str02)
    End Function

    Private Sub Usuarios_Sum_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class