Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Pacientes_Sum
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Return Data_Prev_Activo
        'If (Data_Prev_Activo.Count > 0) Then
        '    'Serializar a Json
        '    Serializer.Serialize(Data_Prev_Activo, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_PREVE As Long, ByVal DATE_str01 As String,
                                                                  ByVal DATE_str02 As String) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_PACIENTES)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Pac_Sum As New N_Paciente_Sum
        Dim Data_Pac_Sum As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_PACIENTES)
        Data_Pac_Sum = NN_Pac_Sum.IRIS_WEBF_BUSCA_LIS_ADM_PACIENTES(ID_PREVE, DATE_str01, DATE_str02)
        Return Data_Pac_Sum
        'If (Data_Pac_Sum.Count > 0) Then
        '    'Serializar con JSON
        '    Serializer.MaxJsonLength = 999999999
        '    Serializer.Serialize(Data_Pac_Sum, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal ID_PREVE As Long, ByVal PREVE_DESC As String,
                                     ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        Dim NN_Pac_Sum As New N_Paciente_Sum
        Return NN_Pac_Sum.Gen_Excel(DOMAIN_URL, ID_PREVE, PREVE_DESC, DATE_str01, DATE_str02)
    End Function

    Private Sub Pacientes_Sum_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class