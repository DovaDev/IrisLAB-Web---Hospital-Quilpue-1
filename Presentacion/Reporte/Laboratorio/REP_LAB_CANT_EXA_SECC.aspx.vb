Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class REP_LAB_CANT_EXA_SECC
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_BUSCA_SECCIONES_ACTIVO()
        If (Data_Prev_Activo.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Prev_Activo, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_SECC As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datos As String = ""
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_REP_LAB_CANT_EXA_SECC
        Dim Data_JSON As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_SECCION)
        DATE_str01 = DATE_str01.Replace("-", "/")
        DATE_str02 = DATE_str02.Replace("-", "/")
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))
        Data_JSON = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_SECCION(ID_SECC, Date_01, Date_02)
        'Agregar Código Fonasa sin el guión y número que le sigue
        For y = 0 To (Data_JSON.Count - 1)
            Select Case (InStr(Data_JSON(y).CF_COD, "-"))
                Case 0
                    Continue For
                Case Else
                    Dim Cod_Fonasa() As String = Split(Data_JSON(y).CF_COD, "-")
                    Data_JSON(y).CF_COD = Cod_Fonasa(0)
            End Select
        Next y
        If (Data_JSON.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_JSON, str_Builder)
            datos = str_Builder.ToString
        Else
            datos = "null"
        End If
        Return datos
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal ID_SECC As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        Dim NN_Med As New N_REP_LAB_CANT_EXA_SECC
        Return NN_Med.Gen_Excel(DOMAIN_URL, ID_SECC, DATE_str01, DATE_str02)
    End Function

    Private Sub REP_LAB_CANT_EXA_SECC_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class