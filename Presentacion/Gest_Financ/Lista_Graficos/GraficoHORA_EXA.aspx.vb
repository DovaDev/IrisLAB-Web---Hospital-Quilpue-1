Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class GraficoHORA_EXA
    Inherits System.Web.UI.Page

    Private Sub GraficoHORA_EXA_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
    <Services.WebMethod>
    Public Shared Function Data_Graph(ByVal str_Date As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Search As New N_GraficoVisor
        Dim Data_Out As New List(Of E_IRIS_WEBF_BUSCA_HORA_CONTEO_EXAMENES)
        Dim days As Integer = System.DateTime.DaysInMonth(2017, 1)
        Debug.WriteLine(">>>ATENCIONES POR CONSULTA<<<")
        For h = 0 To 23
            str_Date = str_Date.Replace("-", "/")
            Dim dRef() As String = str_Date.Split("/")
            Dim Date_Out As Date = NN_Date.strToDate(dRef(2), dRef(1), dRef(0), h)
            Dim Value As Long = 0
            Value = NN_Search.IRIS_WEBF_BUSCA_HORA_CONTEO_EXAMENES(Date_Out, Date_Out)
            Debug.WriteLine("Fecha: " & Format(Date_Out, "dd/MM/yyyy HH:mm:ss"))
            Debug.WriteLine("Valor: " & Format(Value, "###,###,##0.##"))
            Debug.WriteLine("")
            Dim E_Item As New E_IRIS_WEBF_BUSCA_HORA_CONTEO_EXAMENES
            E_Item.FECHA = Date_Out
            E_Item.NUMERO = Value
            Data_Out.Add(E_Item)
        Next h
        Debug.WriteLine("Llenado Completado")
        If (Data_Out.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Out, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal MAIN_URL As String, ByVal str_Date As String) As String
        Dim NN_Prev As New N_GraficoVisor
        Return NN_Prev.Gen_ExcelHoraEXA(MAIN_URL, str_Date)
    End Function
End Class