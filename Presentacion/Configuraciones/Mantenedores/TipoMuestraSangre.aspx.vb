Imports Entidades
Imports Negocio
Imports System.Web.Script.Serialization

Public Class TipoMuestraSangre
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

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
    Public Shared Function IRIS_WEBF_BUSCA_MUESTRA_SANGRE() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE)
        Dim NN As N_IRIS_WEBF_BUSCA_TP_MUESTRA = New N_IRIS_WEBF_BUSCA_TP_MUESTRA
        data_paciente = NN.IRIS_WEBF_BUSCA_MUESTRA_SANGRE()
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
    Public Shared Function IRIS_WEBF_GRABA_TP_DE_MUESTRA_SANGRE(ByVal MUESTRA_SANGRE_COD As String, ByVal MUESTRA_SANGRE_DESC As String, ByVal ID_ESTADO As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_TP_MUESTRA = New N_IRIS_WEBF_BUSCA_TP_MUESTRA
        numerin = NN.IRIS_WEBF_GRABA_TP_DE_MUESTRA_SANGRE(MUESTRA_SANGRE_COD, MUESTRA_SANGRE_DESC, ID_ESTADO)

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
    Public Shared Function IRIS_WEBF_UPDATE_TP_MUESTRA_SANGRE(ByVal ID_MUESTRA_SANGRE As Integer, ByVal MUESTRA_SANGRE_COD As String, ByVal MUESTRA_SANGRE_DESC As String, ByVal ID_ESTADO As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_TP_MUESTRA = New N_IRIS_WEBF_BUSCA_TP_MUESTRA
        numerin = NN.IRIS_WEBF_UPDATE_TP_MUESTRA_SANGRE(ID_MUESTRA_SANGRE, MUESTRA_SANGRE_COD, MUESTRA_SANGRE_DESC, ID_ESTADO)
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
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE)
        Dim NN As N_IRIS_WEBF_BUSCA_TP_MUESTRA = New N_IRIS_WEBF_BUSCA_TP_MUESTRA
        data_paciente = NN.IRIS_WEBF_BUSCA_MUESTRA_SANGRE()
        Dim titulo As String = "Tipos de Muestra de Sangre"
        Dim Mx(3, 0) As Object
        For y = 0 To (data_paciente.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx(3, y)
            End If
            Mx(0, y) = data_paciente(y).ID_MUESTRA_SANGRE
            Mx(1, y) = data_paciente(y).MUESTRA_SANGRE_COD
            Mx(2, y) = data_paciente(y).MUESTRA_SANGRE_DESC
            Mx(3, y) = data_paciente(y).ID_ESTADO
        Next y
        Return NN_Excel.Excel(DOMAIN_URL, Mx, titulo)
    End Function

End Class