Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class LugarTM_Prev_Sum
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
    Public Shared Function Llenar_Ddl_T_Pago() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_T_Pago As New List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        'Consultar por previsiones activas
        Data_T_Pago = NN_Activos.IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE()
        If (Data_T_Pago.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_T_Pago, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_PRE As Long, ByVal ID_PRE2 As Long, ByVal ID_TP_PAGO As Long,
                                            ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_TM_Prevision As New N_Lugar_TM_Sum
        Dim Data_TM_Provision As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_LTM2)
        DATE_str01 = DATE_str01.Replace("-", "/")
        DATE_str02 = DATE_str02.Replace("-", "/")
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))
        Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_LTM2(ID_PRE, ID_PRE2, ID_TP_PAGO, Date_01, Date_02)
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
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal ID_PRE As Long, ByVal ID_PRE2 As Long, ByVal ID_TP_PAGO As Long,
                                     ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        Dim NN_TM_Prevision As New N_Lugar_TM_Sum
        Return NN_TM_Prevision.Gen_Excel(DOMAIN_URL, ID_PRE, ID_PRE2, ID_TP_PAGO, DATE_str01, DATE_str02)
    End Function

    Private Sub LugarTM_Prev_Sum_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class