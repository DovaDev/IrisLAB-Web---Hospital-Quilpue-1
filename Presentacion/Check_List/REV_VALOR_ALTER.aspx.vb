Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class REV_VALOR_ALTER
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
    Public Shared Function Llenar_Ddl_22() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO
        If (Data_Prev_Activo.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Prev_Activo, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Call_DataTable(ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_EXAM As Long, ByVal ID_PREV As Long, ByVal ID_STAT As Integer,
                                          ByVal SECCION As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim NN_Table As New N_Check_Val_Criticos
        Dim List_Obj As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)

        List_Obj = NN_Table.IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_ALTERADOS(DATE_str01, DATE_str02, ID_EXAM, ID_PREV, ID_STAT, SECCION)

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
    Public Shared Function Call_Export(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_EXAM As Long, ByVal ID_PREV As Long, ByVal ID_STAT As Integer, ByVal SECCION As String) As String

        Dim NN_Table As New N_Check_Val_Criticos
        Dim URL As String
        URL = NN_Table.Gen_Excel2(DOMAIN_URL, DATE_str01, DATE_str02, ID_EXAM, ID_PREV, ID_STAT, SECCION)

        Return URL
    End Function
End Class