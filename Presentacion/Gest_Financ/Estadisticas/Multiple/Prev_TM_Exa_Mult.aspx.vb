Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Prev_TM_Exa_Mult
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
    Public Shared Function Llenar_Ddl_Medi() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Medi As New List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        'Consultar por previsiones activas
        Data_Medi = NN_Activos.IRIS_WEBF_BUSCA_MEDICOS_ACTIVO()
        If (Data_Medi.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Medi, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Exa() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Exa As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Consultar por previsiones activas
        Data_Exa = NN_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS()
        If (Data_Exa.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Exa, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_TP_PAGO As Long, ByVal ID_PRE As Long, ByVal ID_PRE2 As Long,
                                            ByVal ID_PRE3 As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_TM_Prevision As New N_Prev_TM_Exa_Mult
        Dim Data_TM_Provision As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, DATE_str01, DATE_str02)
        If (Data_TM_Provision.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_TM_Provision, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal ID_TP_PAGO As Long, ByVal ID_PRE As Long, ByVal ID_PRE2 As Long,
                                            ByVal ID_PRE3 As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal PROCE_DESC As String) As String
        Dim NN_TM_Prevision As New N_Prev_TM_Exa_Mult
        If ID_PRE <> 0 Then
            Return NN_TM_Prevision.Gen_Excel(DOMAIN_URL, ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, DATE_str01, DATE_str02, PROCE_DESC)
        Else
            Return NN_TM_Prevision.Gen_Excel_2(DOMAIN_URL, ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, DATE_str01, DATE_str02)
        End If

    End Function

    Private Sub Prev_TM_Exa_Mult_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class