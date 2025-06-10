Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class GraficoSecre
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
    Public Shared Function Llenar_Ddl_Secre() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Proce As New List(Of E_IRIS_WEBF_BUSCA_EST_TECNOLGOS_ACTIVOS)
        'Consultar por previsiones activas
        Data_Proce = NN_Activos.IRIS_WEBF_BUSCA_EST_TECNOLGOS_ACTIVOS()
        If (Data_Proce.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Proce, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal Dll As Integer, ByVal Año As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoTM_Todo
        Dim NN_Secre As New N_GraficoSecre
        Dim NN_TP As New N_GraficoAteTP
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS)
        Dim data_Secre As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_USUARIO)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        'Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)
        Dim mm As Integer
        Dim yyyy As Integer
        yyyy = Format(Date.Now, "yyyy")
        mm = Format(Date.Now, "MM")
        For dd = 1 To 12
            Dim Item As New E_GraficoVisor_Json
            If Dll <> 0 Then
                data_Secre = NN_Secre.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_USUARIO(Dll, Año, dd)
                If data_Secre.Count <> 0 Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = data_Secre(0).CANT_ATE
                    Item.CANT_EXA = data_Secre(0).CANT_EXA
                    date_json_rial.Add(Item)
                ElseIf (data_Secre.Count = 0) Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = 0
                    Item.CANT_EXA = 0
                    date_json_rial.Add(Item)
                End If
            Else
                Data_Med = NN_Med.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS(Año, dd)
                If (Data_Med.Count = 0) Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = 0
                    Item.CANT_EXA = 0
                    date_json_rial.Add(Item)
                Else
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = Data_Med(0).CANT_ATE
                    Item.CANT_EXA = Data_Med(0).CANT_EXA
                    date_json_rial.Add(Item)
                End If
            End If
        Next dd
        If (date_json_rial.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(date_json_rial, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal MAIN_URL As String, ByVal Dll As String, ByVal Año As String) As String
        Dim NN_Grafico_Ate As New N_GraficoSecre
        Return NN_Grafico_Ate.Gen_Excel(MAIN_URL, Dll, Año)
    End Function

    Private Sub GraficoSecre_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class