Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class GraficoPAC_Mensual
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_AÑO_ACTIVO)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_BUSCA_AÑO_ACTIVO
        If (Data_Prev_Activo.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Prev_Activo, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal Mes As String, ByVal Año As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)
        For dd = 1 To days
            Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
            Dim Item As New E_GraficoVisor_Json
            If (Format(Date_01, "dddd") = "domingo") Then
            Else
                Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_TOTAL_PACIENTE(Date_01, Date_01)
                Item.E_Fecha = Date_01
                Item.E_Cantidad = Data_Med(0).TOTA_USU
                Item.E_Dias = Format(Date_01, "dddd")
                date_json_rial.Add(Item)
            End If
        Next dd
        If (Data_Med.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(date_json_rial, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal MAIN_URL As String, ByVal Mes As String, ByVal Año As String) As String
        Dim NN_Prev As New N_GraficoVisor
        Return NN_Prev.Gen_ExcelPAC(MAIN_URL, Mes, Año)
    End Function

    Private Sub GraficoPAC_Mensual_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class