Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class LugarTM_Det
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
    Public Shared Function Llenar_Ddl_Proce() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Proce As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Consultar por previsiones activas
        Data_Proce = NN_Activos.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        Return Data_Proce
        'If (Data_Proce.Count > 0) Then
        '    'Serializar a Json
        '    Serializer.Serialize(Data_Proce, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_T_Pago() As List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_T_Pago As New List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        'Consultar por previsiones activas
        Data_T_Pago = NN_Activos.IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE()
        Return Data_T_Pago
        'If (Data_T_Pago.Count > 0) Then
        '    'Serializar a Json
        '    Serializer.Serialize(Data_T_Pago, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Integer, ByVal ID_FP As Integer, ByVal ID_PREV As Integer, ByVal E_DESDE As Integer, ByVal E_HASTA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim retorno As String
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_TM_Prevision As New N_LugarTM_Det
        Dim Data_TM_Provision As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        Dim Date_01 As Date = NN_Date.strToDate(Split(DESDE, "/")(2), Split(DESDE, "/")(1), Split(DESDE, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(HASTA, "/")(2), Split(HASTA, "/")(1), Split(HASTA, "/")(0))
        retorno = ""
        If (E_DESDE = 0) And (E_HASTA = 0) Then
            Data_TM_Provision = NN_TM_Prevision.IRIS_WEB_BUSCA_EST_ESTADOS_INFORMAR46(DESDE, HASTA, ID_CF, ID_FP, ID_PREV)
            Return Data_TM_Provision
            'If (Data_TM_Provision.Count > 0) Then
            '    'Serializar con JSON
            '    Serializer.MaxJsonLength = 999999999
            '    Serializer.Serialize(Data_TM_Provision, str_Builder)
            '    retorno = str_Builder.ToString
            'Else
            '    retorno = ("null")
            'End If
        ElseIf (E_DESDE < E_HASTA) Then
            Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6(DESDE, HASTA, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA)
            Return Data_TM_Provision
            'If (Data_TM_Provision.Count > 0) Then
            '    'Serializar con JSON
            '    Serializer.MaxJsonLength = 999999999
            '    Serializer.Serialize(Data_TM_Provision, str_Builder)
            '    retorno = str_Builder.ToString
            'Else
            '    retorno = ("null")
            'End If
        Else
            Return Nothing
            'retorno = ("null")
        End If
        'Return retorno
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal MAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Integer, ByVal ID_FP As Integer, ByVal ID_PREV As Integer, ByVal E_DESDE As Integer, ByVal E_HASTA As Integer) As String
        Dim NN_TM_Prevision As New N_LugarTM_Det
        Return NN_TM_Prevision.Gen_Excel(MAIN_URL, DESDE, HASTA, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA)
    End Function

    Private Sub LugarTM_Det_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class