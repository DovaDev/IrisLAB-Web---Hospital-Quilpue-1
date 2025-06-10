Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Medico_Sum
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl() As List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Medi_Activo As New List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        'Consultar por previsiones activas
        Data_Medi_Activo = NN_Activos.IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
        Return Data_Medi_Activo
        'If (Data_Medi_Activo.Count > 0) Then
        '    'Serializar a Json
        '    Serializer.Serialize(Data_Medi_Activo, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_DOC As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_MEDICO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_Med_Sum
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_MEDICO)
        Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_ADM_RESU_MEDICO(ID_DOC, DATE_str01, DATE_str02)
        Return Data_Med
        'If (Data_Med.Count > 0) Then
        '    'Serializar con JSON
        '    Serializer.MaxJsonLength = 999999999
        '    Serializer.Serialize(Data_Med, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal ID_MED As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        Dim NN_Med As New N_Med_Sum
        Return NN_Med.Gen_Excel(DOMAIN_URL, ID_MED, DATE_str01, DATE_str02)
    End Function

    Private Sub Medico_Sum_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class