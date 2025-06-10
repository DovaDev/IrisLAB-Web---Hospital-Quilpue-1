Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class List_Ate_Prev_and_Prog_Ag_M
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Prev() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
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
    Public Shared Function Llenar_Ddl_Prog() As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prog_Activo As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        'Consultar por previsiones activas
        Data_Prog_Activo = NN_Activos.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO
        Return Data_Prog_Activo
        'If (Data_Prog_Activo.Count > 0) Then
        '    'Serializar a Json
        '    Serializer.Serialize(Data_Prog_Activo, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Prog_Alt(ByVal ID_PREV As Long) As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prog_Alt As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO)
        'Consultar por previsiones activas
        Data_Prog_Alt = NN_Activos.IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO(ID_PREV)
        Return Data_Prog_Alt
        'If (Data_Prog_Alt.Count > 0) Then
        '    'Serializar a Json
        '    Serializer.Serialize(Data_Prog_Alt, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_PREV As Long, ByVal ID_PROG As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As List(Of E_Ate_Prev_Prog_JSON_Output)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Consulta
        Dim NN_Search As New N_List_Ate_Prev_and_Prog_Alt_G_Resumen
        Dim Data_OUT As New List(Of E_Ate_Prev_Prog_JSON_Output)
        Data_OUT = NN_Search.Gen_Table(ID_PREV, ID_PROG, DATE_str01, DATE_str02)
        Return Data_OUT
        ''Serializar con JSON
        'If (Data_OUT.Count > 0) Then
        '    Serializer.MaxJsonLength = 999999999
        '    Serializer.Serialize(Data_OUT, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal GROUP As Integer, ByVal ID_PREV As Long, ByVal ID_PROG As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        Dim NN_Search As New N_List_Ate_Prev_and_Prog_Alt_G_Resumen
        Return NN_Search.Gen_Excel(DOMAIN_URL, GROUP, ID_PREV, ID_PROG, DATE_str01, DATE_str02)
    End Function

    Private Sub List_Ate_Prev_and_Prog_Ag_M_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class