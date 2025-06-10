Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class AnaOrdAte
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl() As List(Of E_IRIS_WEBF_BUSCA_AÑO_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_AÑO_ACTIVO)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_BUSCA_AÑO_ACTIVO
        'If (Data_Prev_Activo.Count > 0) Then
        '    'Serializar a Json
        '    Serializer.Serialize(Data_Prev_Activo, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
        Return Data_Prev_Activo
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Proce() As List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Proce As New List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)
        'Consultar por previsiones activas
        Data_Proce = NN_Activos.IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO()
        'If (Data_Proce.Count > 0) Then
        '    'Serializar a Json
        '    Serializer.Serialize(Data_Proce, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
        Return Data_Proce
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal Dll As Integer, ByVal Año As String) As List(Of E_GraficoVisor_Json)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoTM_Todo
        Dim NN_MM As New N_GraficoAteOrd
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS)
        Dim nnnnn As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_ORDEN_ATE)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        'Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)
        Dim MM As Integer
        Dim yyyy As Integer
        yyyy = Format(Date.Now, "yyyy")
        MM = Format(Date.Now, "MM")
        If (Dll = 0) Then
            For dd = 1 To 12
                Dim Item As New E_GraficoVisor_Json
                Data_Med = NN_Med.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS(Año, dd)
                If (Data_Med.Count <> 0) Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = Data_Med(0).CANT_ATE
                    Item.CANT_EXA = Data_Med(0).CANT_EXA
                    date_json_rial.Add(Item)
                ElseIf (Data_Med.Count = 0) Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = 0
                    Item.CANT_EXA = 0
                    date_json_rial.Add(Item)
                End If
            Next dd
        Else
            For dd = 1 To 12
                Dim Item As New E_GraficoVisor_Json
                nnnnn = NN_MM.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_ORDEN_ATE(Dll, Año, dd)
                If (nnnnn.Count <> 0) Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = nnnnn(0).CANT_ATE
                    Item.CANT_EXA = nnnnn(0).CANT_EXA
                    date_json_rial.Add(Item)
                ElseIf (nnnnn.Count = 0) Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = 0
                    Item.CANT_EXA = 0
                    date_json_rial.Add(Item)
                End If
            Next dd
        End If

        'If (date_json_rial.Count > 0) Then
        '    'Serializar con JSON
        '    Serializer.MaxJsonLength = 999999999
        '    Serializer.Serialize(date_json_rial, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
        Return date_json_rial
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal Dll As Long, ByVal Año As Long) As String
        Dim NN_Usuario_Sum As New N_AnaOrdAte
        Return NN_Usuario_Sum.Gen_Excel(DOMAIN_URL, Dll, Año)
    End Function

    Private Sub AnaOrdAte_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class