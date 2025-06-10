Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Res_Peñalolen_Sum
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_TM() As String
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
    Public Shared Function Llenar_Ddl_Prev(ByVal ID_TM As Long) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos_01 As New N_Gen_Activos
        Dim NN_Activos_02 As New N_Res_Peñalolen_Sum
        Dim Data_Prev_01 As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim Data_Prev_02 As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_POR_PROCEDENCIA_ID_PROCE)
        'Consultar por previsiones activas
        Select Case (ID_TM)
            Case 0
                Data_Prev_01 = NN_Activos_01.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()

                If (Data_Prev_01.Count > 0) Then
                    'Serializar a Json
                    Serializer.Serialize(Data_Prev_01, str_Builder)
                    Return str_Builder.ToString
                Else
                    Return "null"
                End If
            Case Else
                Data_Prev_02 = NN_Activos_02.IRIS_WEBF_BUSCA_PREVISION_POR_PROCEDENCIA_ID_PROCE(ID_TM)

                If (Data_Prev_02.Count > 0) Then
                    'Serializar a Json
                    Serializer.Serialize(Data_Prev_02, str_Builder)
                    Return str_Builder.ToString
                Else
                    Return "null"
                End If
        End Select
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Prog(ByVal ID_PREV As Long) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos_01 As New N_Gen_Activos
        Dim Data_Aten_Activo_01 As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        Dim NN_Activos_02 As New N_Gen_Activos
        Dim Data_Aten_Activo_02 As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO)
        Select Case (ID_PREV)
            Case 0
                'Consultar por previsiones activas
                Data_Aten_Activo_01 = NN_Activos_01.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO()
                If (Data_Aten_Activo_01.Count > 0) Then
                    'Serializar a Json
                    Serializer.Serialize(Data_Aten_Activo_01, str_Builder)
                    Return str_Builder.ToString
                Else
                    Return "null"
                End If
            Case Else
                'Consultar por previsiones activas
                Data_Aten_Activo_02 = NN_Activos_02.IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO(ID_PREV)
                If (Data_Aten_Activo_02.Count > 0) Then
                    'Serializar a Json
                    Serializer.Serialize(Data_Aten_Activo_02, str_Builder)
                    Return str_Builder.ToString
                Else
                    Return "null"
                End If
        End Select
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Sub_Prog(ByVal ID_PREV As Integer, ByVal ID_PROG As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Sub As New List(Of E_IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG)
        'Consultar por previsiones activas
        Data_Sub = NN_Activos.IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG(ID_PREV, ID_PROG)
        If (Data_Sub.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Sub, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal EMAIL As String, ByVal ALL As Boolean, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Long, ByVal ID_TM As Long, ByVal ID_PREV As Long, ByVal ID_PROG As Long, ByVal ID_SUBPROG As Long) As String
        Dim NN_Usuario_Sum As New N_Res_Peñalolen_Sum
        Return NN_Usuario_Sum.Gen_Excel(DOMAIN_URL, EMAIL, ALL, DESDE, HASTA, ID_CF, ID_TM, ID_PREV, ID_PROG, ID_SUBPROG)
    End Function

    Private Sub Res_Peñalolen_Sum_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class