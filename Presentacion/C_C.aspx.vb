
Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization

Public Class C_C
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function B_C(ByVal id As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_procedencia As List(Of E_IRIS_WEBF_BUSCA_PASS)
        Dim NN_Procedencia As New N_C_C
        data_procedencia = NN_Procedencia.IRIS_WEBF_BUSCA_PASS(id)
        If data_procedencia.Count > 0 Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_procedencia, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function G_C(ByVal NContraseña As String, ByVal id As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_procedencia As Integer
        Dim NN_Procedencia As New N_C_C
        data_procedencia = NN_Procedencia.IRIS_WEBF_G_PASS(NContraseña, id)

        If data_procedencia > 0 Then
            Return data_procedencia
        Else
            datas = "null"
            Return datas
        End If


    End Function
End Class