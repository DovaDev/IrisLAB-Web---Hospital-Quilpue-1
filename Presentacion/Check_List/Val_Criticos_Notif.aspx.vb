Imports Datos
Imports Negocio
Imports System.Data.SqlClient
Imports System.Web.Script.Serialization
Imports System.Web.Services
Public Class Val_Criticos_Notif
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (CInt(C_P_ADMIN.Value))
            Case 1, 3, 8
            Case Else
                'Response.Redirect("~/Index.aspx")
        End Select
    End Sub

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Exam() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS()
        If (Data_Exam.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Exam, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Tp_Criticos() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_TP_VALORES_CRITICOS_ACTIVOS()
        If (Data_Exam.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Exam, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Prevision() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Prevision As New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Dim Data_Prevision = NN_Prevision.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        If (Data_Prevision.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Prevision, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Call_Ddl_Stat() As String
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        str_Builder.Append("[")
        str_Builder.Append("{")
        str_Builder.Append("'Text': 'Bajo', ")
        str_Builder.Append("'Value': 1")
        str_Builder.Append("}, ")
        str_Builder.Append("{")
        str_Builder.Append("'Text': 'Alto', ")
        str_Builder.Append("'Value': 2")
        str_Builder.Append("}")
        str_Builder.Append("]")

        Return str_Builder.ToString.Replace("'", Chr(34))
    End Function

    <Services.WebMethod()>
    Public Shared Function Call_DataTable(DATE_str01 As String, DATE_str02 As String, ID_EXAM As Long, ID_PREV As Long, ID_STAT As Integer, ID_TP_ATENCION As Integer, ID_RLS_LS As Integer) As Object
        Return D_Check_Val_Criticos.IRIS_WEB_BUSCA_RESULTADOS_CRITICOS_Y_TIEMPO_RESPUESTA(DATE_str01, DATE_str02, ID_EXAM, ID_PREV, ID_STAT, ID_TP_ATENCION, ID_RLS_LS)
    End Function
    <Services.WebMethod()>
    Public Shared Function Call_DataTable_Det(ByVal ID_ATE_RES As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim NN_Table As New N_Check_Val_Criticos
        Dim List_Obj = NN_Table.IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO(ID_ATE_RES)

        If (List_Obj.Count > 0) Then
            'Serializar Objeto en formato JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(List_Obj, str_Builder)

            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Call_DataTable_Det_past(ID_ATE_RES As Integer, ES_SAPU As Boolean) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim NN_Table As New N_Check_Val_Criticos
        Dim List_Obj = NN_Table.IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES(ID_ATE_RES, ES_SAPU)

        If (List_Obj.Count > 0) Then
            'Serializar Objeto en formato JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(List_Obj, str_Builder)

            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Call_Guardar(ID_ATE_RES_SUPREME As Integer, S_Id_User As Integer, DATE_str01 As String, NOTIFICADO As String, ID_TP_CRITICO As Integer, CAUSA As String, LLAMADO As Integer, CORREO As Integer, ESTADO_NOTIFICADO As Integer) As String
        Return (New N_Check_Val_Criticos).IRIS_WEBF_GRABA_DET_VALORES_CRITICOS_DESCRIPCION(ID_ATE_RES_SUPREME, S_Id_User, DATE_str01, NOTIFICADO, ID_TP_CRITICO, CAUSA, LLAMADO, CORREO, ESTADO_NOTIFICADO).ToString()
    End Function
    <Services.WebMethod()>
    Public Shared Function Finalizar_Proceso(ID_ATE_RES_SUPREME As Integer, S_Id_User As Integer, NOTIFICADO As String, ID_TP_CRITICO As Integer, ESTADO_NOTIFICADO As Integer) As String
        Return (New N_Check_Val_Criticos).IRIS_WEBF_FINALIZAR_PROCESO(ID_ATE_RES_SUPREME, S_Id_User, NOTIFICADO, ID_TP_CRITICO, ESTADO_NOTIFICADO).ToString()
    End Function

    <Services.WebMethod()>
    Public Shared Function Call_Export(DOMAIN_URL As String, DATE_str01 As String, DATE_str02 As String, ID_EXAM As Long, ID_PREV As Long, ID_STAT As Integer, ID_TP_ATENCION As Integer, ID_RLS_LS As Integer) As String

        Return (New N_Check_Val_Criticos).Gen_Excel_FINAL(DOMAIN_URL, DATE_str01, DATE_str02, ID_EXAM, ID_PREV, ID_STAT, ID_TP_ATENCION, ID_RLS_LS)

    End Function

    <Services.WebMethod()>
    Public Shared Function GetNotificationCounts(ID_ATE_RES As Integer) As Object
        Dim neg As New N_Check_Val_Criticos()
        Dim counts = neg.IRIS_WEB_GET_NOTIFICATION_COUNTS(ID_ATE_RES)
        Return New With {
            .numLlamadas = counts.numLlamadas,
            .numCorreos = counts.numCorreos
        }
    End Function



End Class