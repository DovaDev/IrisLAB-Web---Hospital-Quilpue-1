Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class T_Resultado
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR)
        Dim NN As N_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR = New N_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR

        data_paciente = NN.IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR()
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO)
        Dim NN As N_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO = New N_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO

        data_paciente = NN.IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO()
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_TP_RESULTADO(ByVal ID_TP As Integer, ByVal TP_COD As String, ByVal TP_DES As String, ByVal ID_ESTADO As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_UPDATE_TP_RESULTADO = New N_IRIS_WEBF_UPDATE_TP_RESULTADO

        numerin = NN.IRIS_WEBF_UPDATE_TP_RESULTADO(ID_TP, TP_COD, TP_DES, ID_ESTADO)

        If (numerin > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(numerin, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_GRABA_TP_RESULTADO(ByVal TP_COD As String, ByVal TP_DES As String, ByVal ID_ESTADO As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_GRABA_TP_RESULTADO = New N_IRIS_WEBF_GRABA_TP_RESULTADO

        numerin = NN.IRIS_WEBF_GRABA_TP_RESULTADO(TP_COD, TP_DES, ID_ESTADO)

        If (numerin > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(numerin, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If

        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String) As String
        Dim NN_Excel As New N_Excel

        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO)
        Dim NN As N_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO = New N_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO

        data_paciente = NN.IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO()
        Dim titulo As String = "Tipo de Resultados"

        Dim Mx(3, 0) As Object
        For y = 0 To (data_paciente.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx(3, y)
            End If

            Mx(0, y) = data_paciente(y).ID_TP_RESULTADO
            Mx(1, y) = data_paciente(y).TP_RESUL_COD
            Mx(2, y) = data_paciente(y).TP_RESUL_DESC
            Mx(3, y) = data_paciente(y).ID_ESTADO
        Next y

        Return NN_Excel.Excel(DOMAIN_URL, Mx, titulo)
    End Function

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (C_P_ADMIN.Value)
            Case Is <> 1
                Response.Redirect("~/Index.aspx")
        End Select
    End Sub
End Class