Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Atenciones_Sum
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Aten_Activo As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        'Consultar por previsiones activas
        Data_Aten_Activo = NN_Activos.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO
        If (Data_Aten_Activo.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Aten_Activo, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_PROGRA As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Aten As New N_Atenciones_Sum
        Dim Data_Aten As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PROGRAMA)
        Data_Aten = NN_Aten.IRIS_WEBF_BUSCA_LIS_ADM_RESU_PROGRAMA(ID_PROGRA, DATE_str01, DATE_str02)
        If (Data_Aten.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Aten, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal ID_PROGRA As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        Dim NN_Prev As New N_Atenciones_Sum
        Return NN_Prev.Gen_Excel(DOMAIN_URL, ID_PROGRA, DATE_str01, DATE_str02)
    End Function

    Private Sub Atenciones_Sum_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class