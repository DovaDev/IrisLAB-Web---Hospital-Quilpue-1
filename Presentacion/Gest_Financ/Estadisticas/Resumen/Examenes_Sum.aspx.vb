Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Examenes_Sum
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        If (Data_Prev_Activo.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Prev_Activo, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_CODIGO_FONASA As Long, ByVal DATE_str01 As String,
                                                                      ByVal DATE_str02 As String, ByVal PROCEDENCIA As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_Examenes_Sum
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES)
        Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES(ID_CODIGO_FONASA, DATE_str01, DATE_str02, PROCEDENCIA)
        If (Data_Prev.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Prev, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal ID_CODIGO_FONASA As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal PROCEDENCIA As Integer) As String
        Dim NN_Exam As New N_Examenes_Sum
        Return NN_Exam.Gen_Excel(DOMAIN_URL, ID_CODIGO_FONASA, DATE_str01, DATE_str02, PROCEDENCIA)
    End Function

    Private Sub Examenes_Sum_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class