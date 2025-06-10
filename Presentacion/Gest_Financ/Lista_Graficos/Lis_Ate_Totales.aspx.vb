Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Lis_Ate_Totales
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Proce() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Proce As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Consultar por previsiones activas
        Data_Proce = NN_Activos.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        If (Data_Proce.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Proce, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_PROCEDENCIA As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Lis_Ate_Totales As New N_Lis_Ate_Totales
        Dim Data_Lis_Ate_Totales As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_LUGAR_TM_TOTALES)

        Data_Lis_Ate_Totales = NN_Lis_Ate_Totales.IRIS_WEBF_BUSCA_LIS_ADM_LUGAR_TM_TOTALES(ID_PROCEDENCIA, DATE_str01, DATE_str02)
        If (Data_Lis_Ate_Totales.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Lis_Ate_Totales, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal ID_PROCEDENCIA As Long, ByVal PROC_DESC As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        Dim NN_TM_Prevision As New N_Lis_Ate_Totales
        Return NN_TM_Prevision.Gen_Excel(DOMAIN_URL, ID_PROCEDENCIA, PROC_DESC, DATE_str01, DATE_str02)
    End Function

    Private Sub Lis_Ate_Totales_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class