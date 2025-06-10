Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization

Public Class DET_ATE_X_USU
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
    Public Shared Function Llenar_Ddl() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Usuarios As New N_Usuario_Sum
        Dim Data_Usuarios_Resumen As New List(Of E_IRIS_WEBF_BUSCA_USUARIO2)
        'Consultar por previsiones activas
        Data_Usuarios_Resumen = NN_Usuarios.IRIS_WEBF_BUSCA_USUARIO2()
        If (Data_Usuarios_Resumen.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Usuarios_Resumen, str_Builder)
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
    Public Shared Function Llenar_DataTable(ByVal ID_PRE As Long, ByVal ID_PROCE As Long, ByVal ID_TP_PAGO As Long, ByVal USUARIO As Long,
                                            ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal EDAD_DESDE As Long, ByVal EDAD_HASTA As Long, ByVal radio As Long) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_TM_Prevision As New N_DET_ATE_USU
        Dim Data_TM_Provision As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE)
        DATE_str01 = DATE_str01.Replace("-", "/")
        DATE_str02 = DATE_str02.Replace("-", "/")
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))

        If (EDAD_DESDE <> 0) And (EDAD_HASTA <> 0) Then
            If (radio = 0) Then
                Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE(Date_01, Date_02, ID_PROCE, ID_TP_PAGO, ID_PRE, EDAD_DESDE, EDAD_HASTA, USUARIO)
                If (Data_TM_Provision.Count > 0) Then
                    'Serializar con JSON
                    Serializer.MaxJsonLength = 999999999
                    Serializer.Serialize(Data_TM_Provision, str_Builder)
                    Return str_Builder.ToString
                Else
                    Return "null"
                End If
            Else
                Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION(Date_01, Date_02, ID_PROCE, ID_TP_PAGO, ID_PRE, EDAD_DESDE, EDAD_HASTA, USUARIO)
                If (Data_TM_Provision.Count > 0) Then
                    'Serializar con JSON
                    Serializer.MaxJsonLength = 999999999
                    Serializer.Serialize(Data_TM_Provision, str_Builder)
                    Return str_Builder.ToString
                Else
                    Return "null"
                End If
            End If
        Else
            If (radio = 0) Then
                Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE(Date_01, Date_02, ID_PROCE, ID_TP_PAGO, ID_PRE, EDAD_DESDE, EDAD_HASTA, USUARIO)
                If (Data_TM_Provision.Count > 0) Then
                    'Serializar con JSON
                    Serializer.MaxJsonLength = 999999999
                    Serializer.Serialize(Data_TM_Provision, str_Builder)
                    Return str_Builder.ToString
                Else
                    Return "null"
                End If
            Else
                Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION(Date_01, Date_02, ID_PROCE, ID_TP_PAGO, ID_PRE, EDAD_DESDE, EDAD_HASTA, USUARIO)
                If (Data_TM_Provision.Count > 0) Then
                    'Serializar con JSON
                    Serializer.MaxJsonLength = 999999999
                    Serializer.Serialize(Data_TM_Provision, str_Builder)
                    Return str_Builder.ToString
                Else
                    Return "null"
                End If
            End If
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal ID_PRE As Long, ByVal ID_PROCE As Long, ByVal ID_TP_PAGO As Long, ByVal USUARIO As Long,
                                            ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal EDAD_DESDE As Long, ByVal EDAD_HASTA As Long, ByVal radio As Long) As String
        Dim NN_TM_Prevision As New N_DET_ATE_USU
        Return NN_TM_Prevision.Gen_Excel(DOMAIN_URL, ID_PRE, ID_PROCE, ID_TP_PAGO, USUARIO, DATE_str01, DATE_str02, EDAD_DESDE, EDAD_HASTA, radio)
    End Function

    Private Sub DET_ATE_X_USU_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class