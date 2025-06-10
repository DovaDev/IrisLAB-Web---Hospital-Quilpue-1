Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Val_Criticos
    Inherits System.Web.UI.Page

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (CInt(C_P_ADMIN.Value))
            Case 1, 3
            Case Else
                Response.Redirect("~/Index.aspx")
        End Select
    End Sub

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Exam() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS()
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
        Dim Data_Prevision As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Data_Prevision = NN_Prevision.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
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
    Public Shared Function Call_DataTable(ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_EXAM As Long, ByVal ID_PREV As Long, ByVal ID_STAT As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim NN_Table As New N_Check_Val_Criticos
        Dim List_Obj As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)

        List_Obj = NN_Table.IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS(DATE_str01, DATE_str02, ID_EXAM, ID_PREV, ID_STAT)

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
    Public Shared Function Call_Export(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_EXAM As Long, ByVal ID_PREV As Long, ByVal ID_STAT As Integer) As String

        Dim NN_Table As New N_Check_Val_Criticos
        Dim URL As String
        URL = NN_Table.Gen_Excel(DOMAIN_URL, DATE_str01, DATE_str02, ID_EXAM, ID_PREV, ID_STAT)

        Return URL
    End Function
End Class