Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class AteResumen_Sum
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Prev() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Consultar por previsiones activas
        Data_Prev = NN_Activos.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        If (Data_Prev.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Prev, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
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
    Public Shared Function Llenar_Ddl_Alt(ByVal ID_PREV As Long) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Aten_Activo As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO)
        'Consultar por previsiones activas
        Data_Aten_Activo = NN_Activos.IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO(ID_PREV)
        If (Data_Aten_Activo.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Aten_Activo, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar(ByVal ID_PREV As Integer, ByVal ID_PROG As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Sub As New List(Of E_IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG)
        'Consultar por previsiones activas
        Data_Sub = NN_Activos.IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG(ID_PREV, ID_PROG)
        If (Data_Sub.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Sub, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_TM As Long, ByVal ID_PREVE As Long, ByVal ID_PRG As Long, ByVal ID_SUB As Long, ByVal DATE_str01 As String,
                                                                      ByVal DATE_str02 As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_AteResumen_Sum
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_EST_EXAMENES_RESULTADOS2)
        Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_EST_EXAMENES_RESULTADOS2(ID_TM, ID_PREVE, ID_PRG, ID_SUB, DATE_str01, DATE_str02)
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
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal ID_TM As Long, ByVal ID_PREVE As Long, ByVal ID_PRG As Long, ByVal ID_SUB As Long, ByVal DATE_str01 As String,
                                                                      ByVal DATE_str02 As String) As String
        Dim NN_Usuario_Sum As New N_AteResumen_Sum
        Return NN_Usuario_Sum.Gen_Excel(DOMAIN_URL, ID_TM, ID_PREVE, ID_PRG, ID_SUB, DATE_str01, DATE_str02)
    End Function

    Private Sub AteResumen_Sum_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class